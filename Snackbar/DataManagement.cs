using Snackbar.controller;
using Snackbar.model;
using Snackbar.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Snackbar.model.Settings;

namespace Snackbar
{
    internal partial class DataManagement : Form
    {
        private UserList _userList;
        private Inventory _inventory;
        private PurchaseHistory _purchaseHistory;
        private Settings _settings;

        private int _solemnlySwearCount;
        private string _solemnlySwear = "I solemnly swear that I am up to no good.";


        internal DataManagement(UserList userList, Inventory inventory, PurchaseHistory purchaseHistory, Settings settings)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this._userList = userList;
            this._inventory = inventory;
            this._purchaseHistory = purchaseHistory;
            this._settings = settings;

            //Set DataGrid Data Sources
            dataGrid_Users.DataSource = userList.GetUserList();
            dataGrid_Inventory.DataSource = inventory.GetItemList();
            dataGrid_Purchases.DataSource = purchaseHistory.GetPurchaseHistoryList();

            //Cell Validators
            dataGrid_Users.CellValidating += new DataGridViewCellValidatingEventHandler(DataGrid_Users_CellValidating);
            dataGrid_Users.CellEndEdit += new DataGridViewCellEventHandler(DataGrid_Users_CellEndEdit);
            dataGrid_Inventory.CellValidating += new DataGridViewCellValidatingEventHandler(DataGrid_Inventory_CellValidating);
            dataGrid_Inventory.CellEndEdit += new DataGridViewCellEventHandler(DataGrid_Inventory_CellEndEdit);

            //Initialize Settings tab to values from settings
            checkBox_NegativeBalance.Checked = settings.NegativeBalancesEnabled;
            checkBox_Warn.Checked = settings.WarnUserEnabled;
            numeric_WarnLevel.Value = settings.WarnUserValue;
            checkBox_Shame.Checked = settings.ShameUserEnabled;
            numeric_ShameLevel.Value = settings.ShameUserValue;
            checkBox_LimitDebt.Checked = settings.LimitDebtEnabled;
            numeric_MaxDebt.Value = settings.MaxDebtValue;

            checkBox_Guest.Checked = settings.GuestAccountEnabled;
            textBox_GuestID.Text = settings.GuestAccountID;

            checkBox_EnableEasterEggs.Checked = settings.EasterEggsEnabled;
            checkBox_FridaySongEnabled.Checked = settings.FridaySongEnabled;
            numeric_FridaySongChance.Value = settings.FridaySongChance;
            checkBox_DejaVuEnabled.Checked = settings.DejaVuEnabled;
            numeric_DejaVuChance.Value = settings.DejaVuChance;
            checkBox_JeopardyEnabled.Checked = settings.JeopardyEnabled;
            numeric_JeopardyChance.Value = settings.JeopardyChance;
            listBox_EasterEggUsers.DataSource = settings.EasterEggUsers;

            InitializeEasterEggComp();

            if (!settings.EasterEggsEnabled)
                tabControl_DataManagement.TabPages.Remove(tab_EasterEggs);

            this.Icon = Properties.Resources.icon;
            dataGrid_Purchases.Sort(timestampDataGridViewTextBoxColumn, ListSortDirection.Descending);
        }

        //Save data on window close.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            FileIO.SaveData(_userList, _purchaseHistory, _inventory, _settings);
        }

        //Initializes components on the EasterEgg tab to correct values after changes have occured.
        private void InitializeEasterEggComp()
        {
            if (_settings.EasterEggUsers.Count != _userList.GetUserList().Count + 1)
            {
                SortableBindingList<EasterEggUser> temp = new SortableBindingList<EasterEggUser>(_settings.EasterEggUsers);
                _settings.EasterEggUsers.Clear();

                _settings.EasterEggUsers.Add(new EasterEggUser(_settings.ALL_USERS, _settings.ALL_USERS));

                foreach (User u in _userList.GetUserList())
                {
                    _settings.EasterEggUsers.Add(new EasterEggUser(u.ID, u.Name));
                }

                foreach (EasterEggUser u in _settings.EasterEggUsers)
                {
                    try
                    {
                        EasterEggUser u2 = temp.SingleOrDefault(x => x.UserID.Equals(u.UserID));
                        if (u2 != null)
                        {
                            u.LoginSounds = u2.LoginSounds;
                            u.LoginChance = u2.LoginChance;
                            u.ScanSounds = u2.ScanSounds;
                            u.ScanChance = u2.ScanChance;
                            u.CheckoutSounds = u2.CheckoutSounds;
                            u.CheckoutChance = u2.CheckoutChance;
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        throw new InvalidOperationException();
                    }
                }

                _settings.AllUsersUser = _settings.EasterEggUsers.Find(x => x.UserID.Equals(_settings.ALL_USERS));

                UpdateEasterEggControlsForNewUser();
            }
        }

        private void Timer_SolemnlySwear_Tick(object sender, EventArgs e)
        {
            if (_solemnlySwearCount > 80)
            {
                timer_SolemnlySwear.Enabled = false;
                label_SolemnlySwear.Visible = false;
                label_SolemnlySwear.Text = "";
                panel_EasterEggs.Controls.Remove(label_SolemnlySwear);
                panel_EasterEgg_MainLeft.Visible = true;
                panel_EasterEgg_MainLeft.Enabled = true;
                panel_EasterEgg_MainRight.Visible = true;
                panel_EasterEgg_MainRight.Enabled = true;
                listBox_EasterEggUsers.SelectedItem = listBox_EasterEggUsers.GetSelected(0);
            }

            if (_solemnlySwearCount <= _solemnlySwear.Length)
            {
                label_SolemnlySwear.Text = _solemnlySwear.Substring(0, _solemnlySwearCount);
            }

            if (_solemnlySwearCount >= 60)
            {
                int color = (_solemnlySwearCount - 60) * 25;
                color = color <= 255 ? color : 255;

                label_SolemnlySwear.ForeColor = Color.FromArgb(255, color, color, color);
            }

            _solemnlySwearCount++;
        }

        private void UpdateEasterEggControlsForNewUser()
        {
            EasterEggUser u = (EasterEggUser)listBox_EasterEggUsers.SelectedItem;

            if (u != null)
            {
                panel_EasterEgg_LeftBottom.Enabled = u.UserID.Equals(_settings.ALL_USERS);
                numeric_LoginChance.Value = u.LoginChance;
                numeric_ScanChance.Value = u.ScanChance;
                numeric_CheckoutChance.Value = u.CheckoutChance;
                listBox_Login.DataSource = u.LoginSounds;
                listBox_Scan.DataSource = u.ScanSounds;
                listBox_Checkout.DataSource = u.CheckoutSounds;
            }
        }

        #region Finished Event Methods - Do not touch

        private void Panel_EasterEggs_DoubleClick(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                _solemnlySwearCount = 0;
                timer_SolemnlySwear.Interval = 100;
                timer_SolemnlySwear.Enabled = true;
                timer_SolemnlySwear.Tick += new EventHandler(Timer_SolemnlySwear_Tick);
                this.toolTip1.SetToolTip(this.panel_EasterEggs, "");
            }
        }

        private void CheckBox_EnableEasterEggs_CheckedChanged(object sender, EventArgs e)
        {
            _settings.EasterEggsEnabled = checkBox_EnableEasterEggs.Checked;
            if (!_settings.EasterEggsEnabled)
                tabControl_DataManagement.TabPages.Remove(tab_EasterEggs);
            else
            {
                if (!tabControl_DataManagement.TabPages.Contains(tab_EasterEggs))
                    tabControl_DataManagement.TabPages.Add(tab_EasterEggs);
            }
        }

        private void CheckBox_NegativeBalance_CheckedChanged(object sender, EventArgs e)
        {
            panel_NegativeBalanceGroup.Enabled = checkBox_NegativeBalance.Checked;
            _settings.NegativeBalancesEnabled = checkBox_NegativeBalance.Checked;
        }

        private void CheckBox_Warn_CheckedChanged(object sender, EventArgs e)
        {
            numeric_WarnLevel.Enabled = checkBox_Warn.Checked;
            _settings.WarnUserEnabled = checkBox_Warn.Checked;
        }

        private void CheckBox_Shame_CheckedChanged(object sender, EventArgs e)
        {
            numeric_ShameLevel.Enabled = checkBox_Shame.Checked;
            _settings.ShameUserEnabled = checkBox_Shame.Checked;
        }

        private void CheckBox_Guest_CheckedChanged(object sender, EventArgs e)
        {
            textBox_GuestID.Enabled = checkBox_Guest.Checked;
            _settings.GuestAccountEnabled = checkBox_Guest.Checked;
        }

        private void CheckBox_FridaySongEnabled_CheckedChanged(object sender, EventArgs e)
        {
            numeric_FridaySongChance.Enabled = checkBox_FridaySongEnabled.Checked;
            _settings.FridaySongEnabled = checkBox_FridaySongEnabled.Checked;
        }

        private void Numeric_FridaySongChance_ValueChanged(object sender, EventArgs e)
        {
            _settings.FridaySongChance = (int)numeric_FridaySongChance.Value;
        }

        private void CheckBox_DejaVuEnabled_CheckedChanged(object sender, EventArgs e)
        {
            numeric_DejaVuChance.Enabled = checkBox_DejaVuEnabled.Checked;
            _settings.DejaVuEnabled = checkBox_DejaVuEnabled.Checked;
        }

        private void Numeric_DejaVuChance_ValueChanged(object sender, EventArgs e)
        {
            _settings.DejaVuChance = (int)numeric_DejaVuChance.Value;
        }

        private void CheckBox_JeopardyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_JeopardyEnabled.Enabled = checkBox_JeopardyEnabled.Checked;
            _settings.JeopardyEnabled = checkBox_JeopardyEnabled.Checked;
        }

        private void Numeric_JeopardyChance_ValueChanged(object sender, EventArgs e)
        {
            _settings.JeopardyChance = (int)numeric_JeopardyChance.Value;
        }

        private void Numeric_LoginChance_ValueChanged(object sender, EventArgs e)
        {
            EasterEggUser u = (EasterEggUser)listBox_EasterEggUsers.SelectedItem;
            u.LoginChance = (int)numeric_LoginChance.Value;
        }

        private void Numeric_ScanChance_ValueChanged(object sender, EventArgs e)
        {
            EasterEggUser u = (EasterEggUser)listBox_EasterEggUsers.SelectedItem;
            u.ScanChance = (int)numeric_ScanChance.Value;
        }

        private void Numeric_CheckoutChance_ValueChanged(object sender, EventArgs e)
        {
            EasterEggUser u = (EasterEggUser)listBox_EasterEggUsers.SelectedItem;
            u.CheckoutChance = (int)numeric_CheckoutChance.Value;
        }

        private void Numeric_WarnLevel_ValueChanged(object sender, EventArgs e)
        {
            _settings.WarnUserValue = (int)numeric_WarnLevel.Value;
        }

        private void Numeric_ShameLevel_ValueChanged(object sender, EventArgs e)
        {
            _settings.ShameUserValue = (int)numeric_ShameLevel.Value;
        }

        private void TextBox_GuestID_TextChanged(object sender, EventArgs e)
        {
            if(_userList.UserIDExists(textBox_GuestID.Text))
            {
                Label_GuestIDError.Text = "User ID already exists!";
            }
            else
            {
                Label_GuestIDError.Text = "";
                _settings.GuestAccountID = textBox_GuestID.Text;
            }
        }

        //Attempts to add a new user to the list up to 100.
        private void Button_AddUser_Click(object sender, EventArgs e)
        {
            dataGrid_Users.DataSource = this._userList.GetUserList();

            if (!_userList.AddUser(new User("New User ID", "New User Name", 0m)))
            {
                int count = 1;
                while (_userList.UserIDExists("New User ID_" + count) && count < 100)
                    count++;

                _userList.AddUser(new User("New User ID_" + count, "New User Name", 0m));
            }
        }

        //Delete selected users from userlist
        private void Button_DeleteUser_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> removeList = new List<DataGridViewRow>();

            foreach (DataGridViewCell cell in dataGrid_Users.SelectedCells)
            {
                if (!removeList.Contains(cell.OwningRow))
                    removeList.Add(cell.OwningRow);
            }

            if (removeList.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + removeList.Count + " user(s)?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                    foreach (DataGridViewRow row in removeList)
                    {
                        User u = (User)row.DataBoundItem;
                        _userList.GetUserList().Remove(u);
                    }
            }
            else
            {
                MessageBox.Show("No items selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Add item to inventory list
        private void Button_AddItem_Click(object sender, EventArgs e)
        {
            dataGrid_Inventory.DataSource = this._inventory.GetItemList();
            _inventory.GetItemList().Add(new Item("Item Name", "Item UPC", 0m, 0));
        }

        //Delete selected items from inventory list
        private void Button_DeleteItem_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> removeList = new List<DataGridViewRow>();

            foreach (DataGridViewCell cell in dataGrid_Inventory.SelectedCells)
            {
                if (!removeList.Contains(cell.OwningRow))
                    removeList.Add(cell.OwningRow);
            }

            if (removeList.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + removeList.Count + " item(s)?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                    foreach (DataGridViewRow row in removeList)
                        _inventory.GetItemList().Remove((Item)row.DataBoundItem);
            }
            else
            {
                MessageBox.Show("No items selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Filters Inventory list for UPCs/Item Names that match current text in search box
        private void TextBox_InventorySearch_TextChanged(object sender, EventArgs e)
        {
            SortableBindingList<Item> filteredList = new SortableBindingList<Item>(_inventory.GetItemList().Where(i =>
            i.Name.ToLower().Contains(textBox_InventorySearch.Text.ToLower()) ||
            i.UPC.ToLower().Contains(textBox_InventorySearch.Text.ToLower())
            ).ToList());
            dataGrid_Inventory.DataSource = filteredList;
        }

        //Filters Users list for IDs/User Names that match current text in search box
        private void TextBox_UsersSearch_TextChanged(object sender, EventArgs e)
        {
            SortableBindingList<User> filteredList = new SortableBindingList<User>(_userList.GetUserList().Where(i =>
            i.Name.ToLower().Contains(textBox_UsersSearch.Text.ToLower()) ||
            i.ID.ToLower().Contains(textBox_UsersSearch.Text.ToLower())
            ).ToList());
            dataGrid_Users.DataSource = filteredList;
        }

        //Filters Purchase list for User IDs/Item Names/Dates that match current text in search box
        private void TextBox_PurchaseSearch_TextChanged(object sender, EventArgs e)
        {
            SortableBindingList<Purchase> filteredList = new SortableBindingList<Purchase>(_purchaseHistory.GetPurchaseHistoryList().Where(i =>
            i.UserID.ToLower().Contains(textBox_PurchaseSearch.Text.ToLower()) ||
            i.ItemName.ToLower().Contains(textBox_PurchaseSearch.Text.ToLower()) ||
            i.Timestamp.ToString().ToLower().Contains(textBox_PurchaseSearch.Text.ToLower())
            ).ToList());
            dataGrid_Purchases.DataSource = filteredList;
        }

        //Changes Admin password
        private void Button_ChangeAdminPassword_Click(object sender, EventArgs e)
        {
            if (textBox_AdminPassword.Text.Length == 0)
            {
                Label_AdminPasswordError.ForeColor = System.Drawing.Color.Red;
                Label_AdminPasswordError.Text = "Text cannot be empty!";
                return;
            }

            if (!textBox_AdminPassword.Text.Equals(textBox_AdminPassword2.Text))
            {
                Label_AdminPasswordError.ForeColor = System.Drawing.Color.Red;
                Label_AdminPasswordError.Text = "Passwords must match!";
                return;
            }

            //Text is not empty and matches each other.
            Label_AdminPasswordError.ForeColor = System.Drawing.Color.Green;
            Label_AdminPasswordError.Text = "Password updated!";
            _settings.AdminPassword = textBox_AdminPassword.Text;
        }

        //Validates User datagrid
        private void DataGrid_Users_CellValidating(Object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Ensure text fields reject commas
            if ((e.ColumnIndex == 0 || e.ColumnIndex == 1) && e.FormattedValue.ToString().Contains(","))
            {
                dataGrid_Users.Rows[e.RowIndex].ErrorText = "Can't use commas!";
                e.Cancel = true;
            }

            //UserID col
            if (e.ColumnIndex == 0)
            {
                //Checks if user is attempting to change value of user ID
                if (!dataGrid_Users.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals(e.FormattedValue.ToString()))
                {
                    if (e.FormattedValue.ToString().Equals(_settings.ALL_USERS) || 
                        e.FormattedValue.ToString().Equals(_settings.GuestAccountID) ||
                        _userList.UserIDExists(e.FormattedValue.ToString()))
                    {
                        dataGrid_Users.Rows[e.RowIndex].ErrorText = "UserID already exists!";
                        e.Cancel = true;
                    }
                }
            }
            else if (e.ColumnIndex == 2) //Balance col
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal result))
                {
                    dataGrid_Users.Rows[e.RowIndex].ErrorText = "Not a valid decimal value!";
                    e.Cancel = true;
                }
            }
        }

        //Clears error messages if user hits ESC to revert cell value
        private void DataGrid_Users_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGrid_Users.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        //Validates Inventory datagrid
        private void DataGrid_Inventory_CellValidating(Object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Ensure text fields reject commas
            if((e.ColumnIndex == 0 || e.ColumnIndex == 3) && e.FormattedValue.ToString().Contains(","))
            {
                dataGrid_Inventory.Rows[e.RowIndex].ErrorText = "Can't use commas!";
                e.Cancel = true;
            }

            //UPC col
            if (e.ColumnIndex == 3)
            {
                //Checks if user is attempting to change value of UPC
                if (!dataGrid_Inventory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals(e.FormattedValue.ToString()))
                {
                    if (_inventory.GetItem(e.FormattedValue.ToString()) != null)
                    {
                        dataGrid_Inventory.Rows[e.RowIndex].ErrorText = "UPC already exists!";
                        e.Cancel = true;
                    }
                }
            }
            else if (e.ColumnIndex == 1) //Cost col
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal result))
                {
                    dataGrid_Inventory.Rows[e.RowIndex].ErrorText = "Not a valid decimal value!";
                    e.Cancel = true;
                }
            }
            else if (e.ColumnIndex == 2) //Amount col
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out int result))
                {
                    dataGrid_Inventory.Rows[e.RowIndex].ErrorText = "Not a valid integer value!";
                    e.Cancel = true;
                }
            }

        }

        //Clears error messages if user hits ESC to revert cell value
        private void DataGrid_Inventory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGrid_Inventory.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void Button_SelectLogin_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.soundFileDialog.ShowDialog();
            EasterEggUser u = (EasterEggUser)listBox_EasterEggUsers.SelectedItem;
            u.LoginSounds.Clear();
            if (dr == DialogResult.OK)
            {
                foreach (string str in soundFileDialog.FileNames.ToList())
                {
                    u.LoginSounds.Add(str);
                }
            }
        }

        private void Button_SelectScan_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.soundFileDialog.ShowDialog();
            EasterEggUser u = (EasterEggUser)listBox_EasterEggUsers.SelectedItem;
            u.ScanSounds.Clear();
            if (dr == DialogResult.OK)
            {
                foreach (string str in soundFileDialog.FileNames.ToList())
                {
                    u.ScanSounds.Add(str);
                }
            }

        }

        private void Button_SelectCheckout_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.soundFileDialog.ShowDialog();
            EasterEggUser u = (EasterEggUser)listBox_EasterEggUsers.SelectedItem;
            u.CheckoutSounds.Clear();
            if (dr == DialogResult.OK)
            {
                foreach (string str in soundFileDialog.FileNames.ToList())
                {
                    u.CheckoutSounds.Add(str);
                }
            }
        }

        private void TabControl_DataManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Resets Easter egg tab incase users were added or removed from user tab.
            if (tabControl_DataManagement.SelectedTab.Equals(tab_EasterEggs))
                InitializeEasterEggComp();

            //Clears text from errors after leaving tab.
            if (!tabControl_DataManagement.SelectedTab.Equals(tab_Settings))
                Label_AdminPasswordError.Text = "";
        }

        private void ListBox_EasterEggUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEasterEggControlsForNewUser();
        }

        private void CheckBox_LimitDebt_CheckedChanged(object sender, EventArgs e)
        {
            numeric_MaxDebt.Enabled = checkBox_LimitDebt.Checked;
            _settings.LimitDebtEnabled = checkBox_LimitDebt.Checked;
        }

        private void Numeric_MaxDebt_ValueChanged(object sender, EventArgs e)
        {
            _settings.MaxDebtValue = (int)numeric_MaxDebt.Value;
        }

        #endregion


    }
}
