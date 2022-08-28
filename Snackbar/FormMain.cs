using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Snackbar.controller;
using Snackbar.model;
using Snackbar.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Windows.Forms;
using System.Xml.Linq;
using Settings = Snackbar.model.Settings;
using User = Snackbar.model.User;

namespace Snackbar
{
    internal partial class FormMain : Form
    {
        private UserList _userList;
        private PurchaseHistory _purchaseHistory;
        private Inventory _inventory;
        private Settings _settings;
        private Checkout _checkout;
        private DataManagement _dataManagement;
        private EasterEggManager _easterEggManager;
        private SoundPlayer _player;
        private Lottery _lottery;

        internal FormMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            //Initialize components
            _settings = new Settings();
            _purchaseHistory = new PurchaseHistory();
            _inventory = new Inventory();
            _lottery = new Lottery(_settings);
            _userList = new UserList(_settings);
            _easterEggManager = new EasterEggManager(_settings);
            _checkout = new Checkout(_userList, _purchaseHistory, _inventory, _settings, _lottery, Label_UPCErrorMessage, textBox_Login, label_PurchaseTotal);

            listBox_PurchaseList.DataSource = _checkout.PurchaseList;

            FileIO.ReadData(_userList,_purchaseHistory,_inventory, _settings);;

            this.Icon = Properties.Resources.icon;
            _player = new SoundPlayer();

            _dataManagement = new DataManagement(_userList, _inventory, _purchaseHistory, _settings);
        }

        //Save data on window close.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            FileIO.SaveData(_userList, _purchaseHistory, _inventory, _settings);
        }

        //User attempted to add purchase to cart with Enter keypress
        private void TextBox_PurchaseUPC_KeyDown(object sender, KeyEventArgs e)
        {
            if(Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Enter)
            {
                button_Checkout.PerformClick();
                e.SuppressKeyPress = true; //Used to remove Ding after user presses enter.
            }
            else if(e.KeyCode == Keys.Enter)
            {
                button_AddItemToCart.PerformClick();
                e.SuppressKeyPress = true; //Used to remove Ding after user presses enter.
            }
            else if(e.KeyCode == Keys.Escape)
            {
                _player = new SoundPlayer(Properties.Resources.PurchaseCancelled);
                _player.PlaySync();
                button_Logout.PerformClick();
                e.SuppressKeyPress = true; //Used to remove Ding after user presses esc.
            }
        }

        //User attempted to add purchase to cart with button
        private void Button_AddItemToCart_Click(object sender, EventArgs e)
        {
            if (_checkout.AddPurchaseToList(textBox_PurchaseUPC.Text))
                _easterEggManager.Scan(textBox_Login.Text, _inventory.GetItem(textBox_PurchaseUPC.Text));
            textBox_PurchaseUPC.Clear();
            textBox_PurchaseUPC.Focus();
        }

        //User attempted to login with button press
        private void Button_Login_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }

        //User attempted to login with Enter keypress
        private void TextBox_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AttemptLogin();
                e.SuppressKeyPress = true; //Used to remove Ding after user presses enter.
            }
            else if(e.KeyCode == Keys.Escape)
            {
                textBox_Login.Clear();
                e.SuppressKeyPress = true;
            }
        }

        //Abstracted method to for login code
        private void AttemptLogin()
        {
            groupBox_PurchaseList.Enabled = _userList.IsUserAuthorized(textBox_Login.Text);
            groupBox_Login.Enabled = !groupBox_PurchaseList.Enabled;

            if (groupBox_PurchaseList.Enabled)
            {
                //User successfully logged in.
                User u = _userList.GetUserFromID(textBox_Login.Text);
                u = u != null ? u : new User(_settings.GuestAccountID, "Guest", 0m);

                textBox_PurchaseUPC.Focus();
                label_LoggedIn.BackColor = System.Drawing.Color.DarkGreen;
                label_LoggedIn.Text = $"Welcome, {u.Name.Split(' ')[0]}!   Balance: ${u.Balance}";
                button_ClearCart.BackColor = System.Drawing.Color.LightCoral;
                button_Checkout.BackColor = System.Drawing.Color.PaleGreen;
                button_Logout.BackColor = System.Drawing.Color.SteelBlue;

                //Check balance for warns/shames
                if (_settings.ShameUserEnabled && u.Balance <= _settings.ShameUserValue)
                {
                    _player = new SoundPlayer(Properties.Resources.ShameUserFinal);
                    _player.Play();
                }

                if (_settings.WarnUserEnabled && u.Balance <= _settings.WarnUserValue)
                {
                    MessageBox.Show("Your funds are low. Please consider adding more.","Funds Low",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _easterEggManager.Login(u.ID);
            }
            else
            {
                //User Id not found.
                if(textBox_Login.Text != "")
                    SystemSounds.Beep.Play();
                textBox_Login.Clear();
                textBox_Login.Focus();
                label_LoggedIn.BackColor = System.Drawing.Color.Maroon;
                label_LoggedIn.Text = "Not Logged In!";
                button_ClearCart.BackColor = System.Drawing.SystemColors.Control;
                button_Checkout.BackColor = System.Drawing.SystemColors.Control;
                button_Logout.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        //User attempted to clear Login textbox
        private void Button_LoginClear_Click(object sender, EventArgs e)
        {
            textBox_Login.Clear();
            textBox_Login.Focus();
        }

        //User wants to purchase all items in their cart
        private void Button_Checkout_Click(object sender, EventArgs e)
        {
            _player.Stop();
            _easterEggManager.Cancel_Timer();

            //Process checkout as a guest.
            if (textBox_Login.Text.Equals(_settings.GuestAccountID))
            {
                MessageBox.Show($"Please pay ${_checkout.Total()} in cash.", "Guest Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _checkout.PurchaseCartGuest();
                _checkout.ClearCart();
                textBox_Login.Clear();
                AttemptLogin();
                return;
            }

            //Ensure user has enough credit to cover transaction.
            if ((!_settings.NegativeBalancesEnabled && _userList.GetUserFromID(textBox_Login.Text).Balance < _checkout.Total()) ||
                (_settings.LimitDebtEnabled && (_userList.GetUserFromID(textBox_Login.Text).Balance - _checkout.Total()) < _settings.MaxDebtValue))
            {
                MessageBox.Show("Insufficent funds! Please add more funds to your account.", "Insufficent funds!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            _checkout.PurchaseCart();
            _checkout.ClearCart();
            _easterEggManager.Checkout(textBox_Login.Text);
            textBox_Login.Clear();
            AttemptLogin();

            //Write all data to files after each purchase
            FileIO.SaveData(_userList, _purchaseHistory, _inventory, _settings);
        }

        //User wants to clear items from cart
        private void Button_ClearCart_Click(object sender, EventArgs e)
        {
            _checkout.ClearCart();
            textBox_PurchaseUPC.Focus();
        }

        //User wants to log out.
        private void Button_Logout_Click(object sender, EventArgs e)
        {
            _easterEggManager.Cancel_Timer();

            _checkout.ClearCart();
            textBox_PurchaseUPC.Clear();
            textBox_Login.Clear();
            AttemptLogin();
        }

        //User wants to remove selected item from their cart
        private void Button_RemoveItemFromCart_Click(object sender, EventArgs e)
        {
            _checkout.RemovePurchaseFromList(listBox_PurchaseList.SelectedIndex);
        }

        private void dataManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dataManagement.ShowDialog();
        }

        //User wants to toggle admin mode
        private void adminModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (adminModeToolStripMenuItem.Text.Equals("Enable Admin Mode"))
            {
                EnableAdmin enableAdmin = new EnableAdmin(_settings, enableAdminMode, disableAdminMode);
                enableAdmin.ShowDialog();
            }
            else
            {
                disableAdminMode();
            }
        }

        //Reference of logic used when enabling Admin mode.
        private void enableAdminMode()
        {
            adminModeToolStripMenuItem.Text = "Disable Admin Mode";
            adminToolStripMenuItem.Enabled = true;
        }

        //Reference of logic needed when disabling Admin mode.
        //Close any windows with admin priviledges and reset Admin MenuItem
        //Unable to close Quick Add tools.
        private void disableAdminMode()
        {
            adminModeToolStripMenuItem.Text = "Enable Admin Mode";
            adminToolStripMenuItem.Enabled = false;
            _dataManagement.Close();
        }

        //Toolbar - Help window
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        //Toolbar - Save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileIO.SaveData(_userList, _purchaseHistory, _inventory, _settings);
        }

        //Toolbar - Inventory Quick Add Tool
        private void inventoryQuickAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = "";
            do
            {
                input = Interaction.InputBox("Scan the UPC you would like to add.", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);

                if (input.Length == 0)
                    return;

                Item i = _inventory.GetItem(input);
                if (i == null)
                {
                    //Add item
                    string upc = input;
                    string name = Interaction.InputBox("New UPC detected. Enter the name of the item.", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);
                    while (name.Contains(","))
                    {
                        name = Interaction.InputBox("Unable to use commas in name. Please enter a different name.", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);
                    }
                    input = Interaction.InputBox($"Item: {name}.{Environment.NewLine}Enter cost of item.", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);
                    if (input.Length == 0)
                        return;

                    decimal cost;
                    while(!decimal.TryParse(input, out cost))
                    {
                        input = Interaction.InputBox($"Item: {name}.{Environment.NewLine}Invalid cost. Please enter a decimal value.{Environment.NewLine}E.g. 1.75", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);
                        if (input.Length == 0)
                            return;
                    }
                    input = Interaction.InputBox($"Item: {name}.{Environment.NewLine}Enter the initial amount of the item.", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);
                    int amount;
                    while (!int.TryParse(input, out amount))
                    {
                        input = Interaction.InputBox($"Item: {name}.{Environment.NewLine}Invalid amount. Please enter an integer value.{Environment.NewLine}E.g. 3", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);
                        if (input.Length == 0)
                            return;
                    }

                    _inventory.AddItem(new Item(name, upc, cost, amount));
                }
                else
                {
                    //Update item
                    input = Interaction.InputBox($"Item: {i.Name}.{Environment.NewLine}Enter the amount to add to inventory.", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);
                    if (input.Length == 0)
                        return;
                    int amount;
                    while (!int.TryParse(input, out amount))
                    {
                        input = Interaction.InputBox($"Item: {i.Name}.{Environment.NewLine}Invalid amount. Please enter an integer value.{Environment.NewLine}E.g. 3", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);
                        if (input.Length == 0)
                            return;
                    }

                    i.Amount += amount;
                }

            } while (input != "");

            FileIO.SaveData(_userList, _purchaseHistory, _inventory, _settings);
        }

        //Toolbar - Money Quick Add Tool
        private void moneyQuickAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoneyQuickAdd moneyQuickAdd = new MoneyQuickAdd(_userList);
            DialogResult result = moneyQuickAdd.ShowDialog();

            if(result == DialogResult.OK)
            {
                User u = moneyQuickAdd.SelectedUser;

                String input = Interaction.InputBox($"User: {u.Name}. Balance: ${u.Balance}.{Environment.NewLine}Enter the amount of money to add to user.", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);
                if (input.Length == 0)
                    return;
                decimal amount;
                while (!decimal.TryParse(input, out amount))
                {
                    input = Interaction.InputBox($"User: {u.Name}. Balance: ${u.Balance}.{Environment.NewLine}Invalid input. Please enter a decimal value.{Environment.NewLine}E.g. 50.25", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);
                    if (input.Length == 0)
                        return;
                }

                u.Balance += amount;
            }

            FileIO.SaveData(_userList, _purchaseHistory, _inventory, _settings);
        }

        //Toolbar - Open save location
        private void openSaveLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(FileIO.APP_PATH);
        }
    }
}
