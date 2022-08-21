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
    public partial class FormMain : Form
    {
        private UserList userList;
        private PurchaseHistory purchaseHistory;
        private Inventory inventory;
        private Settings settings;
        private Checkout checkout;
        private LoginManager loginManager;
        private DataManagement dataManagement;
        private EasterEggManager easterEggManager;
        private SoundPlayer player;

        public FormMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            

            //Initialize components
            userList = new UserList();
            purchaseHistory = new PurchaseHistory();
            inventory = new Inventory();
            settings = new Settings();
            checkout = new Checkout(userList, purchaseHistory, inventory, settings, Label_UPCErrorMessage, TextBox_Login, Label_PurchaseTotal, TextBox_PurchaseUPC);
            loginManager = new LoginManager(userList, settings);
            easterEggManager = new EasterEggManager(settings);

            ListBox_PurchaseList.DataSource = checkout.PurchaseList;

            FileIO.Initialize(userList,purchaseHistory,inventory, settings);;

            this.Icon = Properties.Resources.icon;
            player = new SoundPlayer();

            dataManagement = new DataManagement(userList, inventory, purchaseHistory, settings);
        }

        //Save data on window close.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            FileIO.SaveData(userList, purchaseHistory, inventory, settings);
        }

        //User attempted to add purchase to cart with Enter keypress
        private void TextBox_PurchaseUPC_KeyDown(object sender, KeyEventArgs e)
        {
            if(Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Enter)
            {
                Button_Checkout.PerformClick();
                e.SuppressKeyPress = true; //Used to remove Ding after user presses enter.
            }
            else if(e.KeyCode == Keys.Enter)
            {
                Button_AddItemToCart.PerformClick();
                e.SuppressKeyPress = true; //Used to remove Ding after user presses enter.
            }
            else if(e.KeyCode == Keys.Escape)
            {
                Button_Logout.PerformClick();
                e.SuppressKeyPress = true; //Used to remove Ding after user presses esc.
            }
        }

        //User attempted to add purchase to cart with button
        private void Button_AddItemToCart_Click(object sender, EventArgs e)
        {
            if (checkout.AddPurchaseToList(TextBox_PurchaseUPC.Text))
                easterEggManager.Scan(TextBox_Login.Text, inventory.GetItem(TextBox_PurchaseUPC.Text));
            TextBox_PurchaseUPC.Clear();
            TextBox_PurchaseUPC.Focus();
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
                TextBox_Login.Clear();
                e.SuppressKeyPress = true;
            }
        }

        //Abstracted method to for login code
        private void AttemptLogin()
        {
            GroupBox_PurchaseList.Enabled = loginManager.IsUserAuthorized(TextBox_Login.Text);
            GroupBox_Login.Enabled = !GroupBox_PurchaseList.Enabled;

            if (GroupBox_PurchaseList.Enabled)
            {
                //User successfully logged in.
                User u = userList.GetUserFromID(TextBox_Login.Text);
                u = u != null ? u : new User(settings.GuestAccountID, "Guest", 0m);

                TextBox_PurchaseUPC.Focus();
                Label_LoggedIn.BackColor = System.Drawing.Color.DarkGreen;
                Label_LoggedIn.Text = $"Welcome, {u.Name.Split(' ')[0]}!   Balance: ${u.Balance}";
                Button_ClearCart.BackColor = System.Drawing.Color.LightCoral;
                Button_Checkout.BackColor = System.Drawing.Color.PaleGreen;
                Button_Logout.BackColor = System.Drawing.Color.SteelBlue;

                //Check balance for warns/shames
                if (settings.ShameUserEnabled && u.Balance <= settings.ShameUserValue)
                {
                    player = new SoundPlayer(Properties.Resources.ShameUserFinal);
                    player.Play();
                }

                if (settings.WarnUserEnabled && u.Balance <= settings.WarnUserValue)
                {
                    MessageBox.Show("Your funds are low. Please consider adding more.","Funds Low",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                easterEggManager.Login(u.ID);
            }
            else
            {
                //User Id not found.
                if(TextBox_Login.Text != "")
                    SystemSounds.Beep.Play();
                TextBox_Login.Clear();
                TextBox_Login.Focus();
                Label_LoggedIn.BackColor = System.Drawing.Color.Maroon;
                Label_LoggedIn.Text = "Not Logged In!";
                Button_ClearCart.BackColor = System.Drawing.SystemColors.Control;
                Button_Checkout.BackColor = System.Drawing.SystemColors.Control;
                Button_Logout.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        //User attempted to clear Login textbox
        private void Button_LoginClear_Click(object sender, EventArgs e)
        {
            TextBox_Login.Clear();
            TextBox_Login.Focus();
        }

        //User wants to purchase all items in their cart
        private void Button_Checkout_Click(object sender, EventArgs e)
        {
            easterEggManager.Cancel_Timer();

            //Process checkout as a guest.
            if (TextBox_Login.Text.Equals(settings.GuestAccountID))
            {
                MessageBox.Show($"Please pay ${checkout.Total()} in cash.", "Guest Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkout.PurchaseCartGuest();
                checkout.ClearCart();
                TextBox_Login.Clear();
                AttemptLogin();
                return;
            }

            //Ensure user has enough credit to cover transaction.
            if ((!settings.NegativeBalancesEnabled && userList.GetUserFromID(TextBox_Login.Text).Balance < checkout.Total()) ||
                (settings.LimitDebtEnabled && (userList.GetUserFromID(TextBox_Login.Text).Balance - checkout.Total()) < settings.MaxDebtValue))
            {
                MessageBox.Show("Insufficent funds! Please add more funds to your account.", "Insufficent funds!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            checkout.PurchaseCart();
            checkout.ClearCart();
            easterEggManager.Checkout(TextBox_Login.Text);
            TextBox_Login.Clear();
            AttemptLogin();

            //Write all data to files after each purchase
            FileIO.SaveData(userList, purchaseHistory, inventory, settings);
        }

        //User wants to clear items from cart
        private void Button_ClearCart_Click(object sender, EventArgs e)
        {
            checkout.ClearCart();
            TextBox_PurchaseUPC.Focus();
        }

        //User wants to log out.
        private void Button_Logout_Click(object sender, EventArgs e)
        {
            easterEggManager.Cancel_Timer();

            checkout.ClearCart();
            TextBox_PurchaseUPC.Clear();
            TextBox_Login.Clear();
            AttemptLogin();
        }

        //User wants to remove selected item from their cart
        private void Button_RemoveItemFromCart_Click(object sender, EventArgs e)
        {
            checkout.RemovePurchaseFromList(ListBox_PurchaseList.SelectedIndex);
        }

        private void dataManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataManagement.ShowDialog();
        }

        //User wants to toggle admin mode
        private void adminModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (adminModeToolStripMenuItem.Text.Equals("Enable Admin Mode"))
            {
                EnableAdmin enableAdmin = new EnableAdmin(settings, enableAdminMode, disableAdminMode);
                enableAdmin.ShowDialog();
            }
            else
            {
                disableAdminMode();
            }
        }

        //Abstraction of logic used when enabling Admin mode.
        private void enableAdminMode()
        {
            adminModeToolStripMenuItem.Text = "Disable Admin Mode";
            adminToolStripMenuItem.Enabled = true;
        }

        //Abstraction of logic needed when disabling Admin mode.
        //Close any windows with admin priviledges and reset Admin MenuItem
        private void disableAdminMode()
        {
            adminModeToolStripMenuItem.Text = "Enable Admin Mode";
            adminToolStripMenuItem.Enabled = false;
            dataManagement.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileIO.SaveData(userList, purchaseHistory, inventory, settings);
        }

        private void inventoryQuickAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = "";
            do
            {
                input = Interaction.InputBox("Scan the UPC you would like to add.", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);

                if (input.Length == 0)
                    return;

                Item i = inventory.GetItem(input);
                if (i == null)
                {
                    //Add item
                    string upc = input;
                    string name = Interaction.InputBox("New UPC detected. Enter the name of the item.", "Quick Add", "", this.Left + this.Size.Width / 2 - 200, this.Top + this.Size.Height / 2 - 100);
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

                    inventory.AddItem(new Item(name, upc, cost, amount));
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
        }

        private void moneyQuickAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoneyQuickAdd moneyQuickAdd = new MoneyQuickAdd(userList);
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
        }

        private void openSaveLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(FileIO.APP_PATH);
        }
    }
}
