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
    partial class DataManagement : Form
    {
        private UserList userList;
        private Inventory inventory;
        private PurchaseHistory purchaseHistory;
        private Settings settings;

        private int SolemnlySwearCount;
        private string SolemnlySwear = "I solemnly swear that I am up to no good.";
        

        public DataManagement(UserList userList, Inventory inventory, PurchaseHistory purchaseHistory, Settings settings)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.userList = userList;
            this.inventory = inventory;
            this.purchaseHistory = purchaseHistory;
            this.settings = settings;

            //Set DataGrid Data Sources
            DataGrid_Users.DataSource = userList.GetUserList();
            DataGrid_Inventory.DataSource = inventory.GetItemList();
            DataGrid_Purchases.DataSource = purchaseHistory.GetPurchaseHistoryList();

            //Cell Validators
            DataGrid_Users.CellValidating += new DataGridViewCellValidatingEventHandler(DataGrid_Users_CellValidating);
            DataGrid_Users.CellEndEdit += new DataGridViewCellEventHandler(DataGrid_Users_CellEndEdit);
            DataGrid_Inventory.CellValidating += new DataGridViewCellValidatingEventHandler(DataGrid_Inventory_CellValidating);
            DataGrid_Inventory.CellEndEdit += new DataGridViewCellEventHandler(DataGrid_Inventory_CellEndEdit);

            //Initialize Settings tab to values from settings
            CheckBox_NegativeBalance.Checked = settings.NegativeBalancesEnabled;
            CheckBox_Warn.Checked = settings.WarnUserEnabled;
            Numeric_WarnLevel.Value = settings.WarnUserValue;
            CheckBox_Shame.Checked = settings.ShameUserEnabled;
            Numeric_ShameLevel.Value = settings.ShameUserValue;
            CheckBox_LimitDebt.Checked = settings.LimitDebtEnabled;
            Numeric_MaxDebt.Value = settings.MaxDebtValue;
            CheckBox_Guest.Checked = settings.GuestAccountEnabled;
            TextBox_GuestID.Text = settings.GuestAccountID;
            CheckBox_EnableEasterEggs.Checked = settings.EasterEggsEnabled;
            CheckBox_FridaySongEnabled.Checked = settings.FridaySongEnabled;
            Numeric_FridaySongChance.Value = settings.FridaySongChance;
            CheckBox_DejaVuEnabled.Checked = settings.DejaVuEnabled;
            Numeric_DejaVuChance.Value = settings.DejaVuChance;
            CheckBox_JeopardyEnabled.Checked = settings.JeopardyEnabled;
            Numeric_JeopardyChance.Value = settings.JeopardyChance;
            ListBox_EasterEggUsers.DataSource = settings.EasterEggUsers;

            initializeEasterEggComp();

            if (!settings.EasterEggsEnabled)
                TabControl_DataManagement.TabPages.Remove(Tab_EasterEggs);

            this.Icon = Properties.Resources.icon;
            DataGrid_Purchases.Sort(timestampDataGridViewTextBoxColumn, ListSortDirection.Descending);
        }

        //Save data on window close.
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            FileIO.SaveData(userList, purchaseHistory, inventory, settings);
        }

        //Initializes components on the EasterEgg tab to correct values after changes have occured.
        private void initializeEasterEggComp()
        {
            if (settings.EasterEggUsers.Count != userList.GetUserList().Count + 1)
            {
                SortableBindingList<EasterEggUser> temp = new SortableBindingList<EasterEggUser>(settings.EasterEggUsers);
                settings.EasterEggUsers.Clear();

                settings.EasterEggUsers.Add(new EasterEggUser(settings.ALL_USERS, settings.ALL_USERS));

                foreach (User u in userList.GetUserList())
                {
                    settings.EasterEggUsers.Add(new EasterEggUser(u.ID, u.Name));
                }

                foreach (EasterEggUser u in settings.EasterEggUsers)
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

                settings.AllUsersUser = settings.EasterEggUsers.Find(x => x.UserID.Equals(settings.ALL_USERS));

                UpdateEasterEggControlsForNewUser();
            }
        }

        private void Timer_SolemnlySwear_Tick(object sender, EventArgs e)
        {
            if (SolemnlySwearCount > 80)
            {
                Timer_SolemnlySwear.Enabled = false;
                Label_SolemnlySwear.Visible = false;
                Label_SolemnlySwear.Text = "";
                Panel_EasterEggs.Controls.Remove(Label_SolemnlySwear);
                Panel_EasterEgg_MainLeft.Visible = true;
                Panel_EasterEgg_MainLeft.Enabled = true;
                Panel_EasterEgg_MainRight.Visible = true;
                Panel_EasterEgg_MainRight.Enabled = true;
                ListBox_EasterEggUsers.SelectedItem = ListBox_EasterEggUsers.GetSelected(0);
            }

            if (SolemnlySwearCount <= SolemnlySwear.Length)
            {
                Label_SolemnlySwear.Text = SolemnlySwear.Substring(0, SolemnlySwearCount);
            }

            if (SolemnlySwearCount >= 60)
            {
                int color = (SolemnlySwearCount - 60) * 25;
                color = color <= 255 ? color : 255;

                Label_SolemnlySwear.ForeColor = Color.FromArgb(255, color, color, color);
            }

            SolemnlySwearCount++;
        }

        private void UpdateEasterEggControlsForNewUser()
        {
            EasterEggUser u = (EasterEggUser)ListBox_EasterEggUsers.SelectedItem;

            if (u != null)
            {
                Panel_EasterEgg_LeftBottom.Enabled = u.UserID.Equals(settings.ALL_USERS);
                Numeric_LoginChance.Value = u.LoginChance;
                Numeric_ScanChance.Value = u.ScanChance;
                Numeric_CheckoutChance.Value = u.CheckoutChance;
                ListBox_Login.DataSource = u.LoginSounds;
                ListBox_Scan.DataSource = u.ScanSounds;
                ListBox_Checkout.DataSource = u.CheckoutSounds;
            }
        }

        #region Finished Event Methods - Do not touch

        private void Panel_EasterEggs_DoubleClick(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                SolemnlySwearCount = 0;
                Timer_SolemnlySwear.Interval = 100;
                Timer_SolemnlySwear.Enabled = true;
                Timer_SolemnlySwear.Tick += new EventHandler(Timer_SolemnlySwear_Tick);
                this.toolTip1.SetToolTip(this.Panel_EasterEggs, "");
            }
        }

        private void CheckBox_EnableEasterEggs_CheckedChanged(object sender, EventArgs e)
        {
            settings.EasterEggsEnabled = CheckBox_EnableEasterEggs.Checked;
            if (!settings.EasterEggsEnabled)
                TabControl_DataManagement.TabPages.Remove(Tab_EasterEggs);
            else
            {
                if (!TabControl_DataManagement.TabPages.Contains(Tab_EasterEggs))
                    TabControl_DataManagement.TabPages.Add(Tab_EasterEggs);
            }
        }

        private void CheckBox_NegativeBalance_CheckedChanged(object sender, EventArgs e)
        {
            Panel_NegativeBalanceGroup.Enabled = CheckBox_NegativeBalance.Checked;
            settings.NegativeBalancesEnabled = CheckBox_NegativeBalance.Checked;
        }

        private void CheckBox_Warn_CheckedChanged(object sender, EventArgs e)
        {
            Numeric_WarnLevel.Enabled = CheckBox_Warn.Checked;
            settings.WarnUserEnabled = CheckBox_Warn.Checked;
        }

        private void CheckBox_Shame_CheckedChanged(object sender, EventArgs e)
        {
            Numeric_ShameLevel.Enabled = CheckBox_Shame.Checked;
            settings.ShameUserEnabled = CheckBox_Shame.Checked;
        }

        private void CheckBox_Guest_CheckedChanged(object sender, EventArgs e)
        {
            TextBox_GuestID.Enabled = CheckBox_Guest.Checked;
            settings.GuestAccountEnabled = CheckBox_Guest.Checked;
        }

        private void CheckBox_FridaySongEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Numeric_FridaySongChance.Enabled = CheckBox_FridaySongEnabled.Checked;
            settings.FridaySongEnabled = CheckBox_FridaySongEnabled.Checked;
        }

        private void Numeric_FridaySongChance_ValueChanged(object sender, EventArgs e)
        {
            settings.FridaySongChance = (int)Numeric_FridaySongChance.Value;
        }

        private void CheckBox_DejaVuEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Numeric_DejaVuChance.Enabled = CheckBox_DejaVuEnabled.Checked;
            settings.DejaVuEnabled = CheckBox_DejaVuEnabled.Checked;
        }

        private void Numeric_DejaVuChance_ValueChanged(object sender, EventArgs e)
        {
            settings.DejaVuChance = (int)Numeric_DejaVuChance.Value;
        }

        private void CheckBox_JeopardyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox_JeopardyEnabled.Enabled = CheckBox_JeopardyEnabled.Checked;
            settings.JeopardyEnabled = CheckBox_JeopardyEnabled.Checked;
        }

        private void Numeric_JeopardyChance_ValueChanged(object sender, EventArgs e)
        {
            settings.JeopardyChance = (int)Numeric_JeopardyChance.Value;
        }

        private void Numeric_LoginChance_ValueChanged(object sender, EventArgs e)
        {
            EasterEggUser u = (EasterEggUser)ListBox_EasterEggUsers.SelectedItem;
            u.LoginChance = (int)Numeric_LoginChance.Value;
        }

        private void Numeric_ScanChance_ValueChanged(object sender, EventArgs e)
        {
            EasterEggUser u = (EasterEggUser)ListBox_EasterEggUsers.SelectedItem;
            u.ScanChance = (int)Numeric_ScanChance.Value;
        }

        private void Numeric_CheckoutChance_ValueChanged(object sender, EventArgs e)
        {
            EasterEggUser u = (EasterEggUser)ListBox_EasterEggUsers.SelectedItem;
            u.CheckoutChance = (int)Numeric_CheckoutChance.Value;
        }

        private void Numeric_WarnLevel_ValueChanged(object sender, EventArgs e)
        {
            settings.WarnUserValue = (int)Numeric_WarnLevel.Value;
        }

        private void Numeric_ShameLevel_ValueChanged(object sender, EventArgs e)
        {
            settings.ShameUserValue = (int)Numeric_ShameLevel.Value;
        }

        private void TextBox_GuestID_TextChanged(object sender, EventArgs e)
        {
            if(userList.UserIDExists(TextBox_GuestID.Text))
            {
                Label_GuestIDError.Text = "User ID already exists!";
            }
            else
            {
                Label_GuestIDError.Text = "";
                settings.GuestAccountID = TextBox_GuestID.Text;
            }
        }

        //Attempts to add a new user to the list up to 100.
        private void Button_AddUser_Click(object sender, EventArgs e)
        {
            if (!userList.AddUser(new User("New User ID", "New User Name", 0m)))
            {
                int count = 1;
                while (userList.UserIDExists("New User ID_" + count) && count < 100)
                    count++;

                userList.AddUser(new User("New User ID_" + count, "New User Name", 0m));
            }
        }

        //Delete selected users from userlist
        private void Button_DeleteUser_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> removeList = new List<DataGridViewRow>();

            foreach (DataGridViewCell cell in DataGrid_Users.SelectedCells)
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
                        userList.GetUserList().Remove(u);
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
            inventory.GetItemList().Add(new Item("Item Name", "Item UPC", 0m, 0));
        }

        //Delete selected items from inventory list
        private void Button_DeleteItem_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> removeList = new List<DataGridViewRow>();

            foreach (DataGridViewCell cell in DataGrid_Inventory.SelectedCells)
            {
                if (!removeList.Contains(cell.OwningRow))
                    removeList.Add(cell.OwningRow);
            }

            if (removeList.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + removeList.Count + " item(s)?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                    foreach (DataGridViewRow row in removeList)
                        inventory.GetItemList().Remove((Item)row.DataBoundItem);
            }
            else
            {
                MessageBox.Show("No items selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Filters Inventory list for UPCs/Item Names that match current text in search box
        private void TextBox_InventorySearch_TextChanged(object sender, EventArgs e)
        {
            SortableBindingList<Item> filteredList = new SortableBindingList<Item>(inventory.GetItemList().Where(i =>
            i.Name.ToLower().Contains(TextBox_InventorySearch.Text.ToLower()) ||
            i.UPC.ToLower().Contains(TextBox_InventorySearch.Text.ToLower())
            ).ToList());
            DataGrid_Inventory.DataSource = filteredList;
        }

        //Filters Users list for IDs/User Names that match current text in search box
        private void TextBox_UsersSearch_TextChanged(object sender, EventArgs e)
        {
            SortableBindingList<User> filteredList = new SortableBindingList<User>(userList.GetUserList().Where(i =>
            i.Name.ToLower().Contains(TextBox_UsersSearch.Text.ToLower()) ||
            i.ID.ToLower().Contains(TextBox_UsersSearch.Text.ToLower())
            ).ToList());
            DataGrid_Users.DataSource = filteredList;
        }

        //Filters Purchase list for User IDs/Item Names/Dates that match current text in search box
        private void TextBox_PurchaseSearch_TextChanged(object sender, EventArgs e)
        {
            SortableBindingList<Purchase> filteredList = new SortableBindingList<Purchase>(purchaseHistory.GetPurchaseHistoryList().Where(i =>
            i.UserID.ToLower().Contains(TextBox_PurchaseSearch.Text.ToLower()) ||
            i.ItemName.ToLower().Contains(TextBox_PurchaseSearch.Text.ToLower()) ||
            i.Timestamp.ToString().ToLower().Contains(TextBox_PurchaseSearch.Text.ToLower())
            ).ToList());
            DataGrid_Purchases.DataSource = filteredList;
        }

        //Changes Admin password
        private void Button_ChangeAdminPassword_Click(object sender, EventArgs e)
        {
            if (TextBox_AdminPassword.Text.Length == 0)
            {
                Label_AdminPasswordError.Text = "Text cannot be empty!";
                return;
            }

            if (!TextBox_AdminPassword.Text.Equals(TextBox_AdminPassword2.Text))
            {
                Label_AdminPasswordError.Text = "Passwords must match!";
                return;
            }

            //Text is not empty and matches each other.
            Label_AdminPasswordError.ForeColor = System.Drawing.Color.Green;
            Label_AdminPasswordError.Text = "Password updated!";
            settings.AdminPassword = TextBox_AdminPassword.Text;
        }

        //Validates User datagrid
        private void DataGrid_Users_CellValidating(Object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Ensure text fields reject commas
            if ((e.ColumnIndex == 0 || e.ColumnIndex == 1) && e.FormattedValue.ToString().Contains(","))
            {
                DataGrid_Users.Rows[e.RowIndex].ErrorText = "Can't use commas!";
                e.Cancel = true;
            }

            //UserID col
            if (e.ColumnIndex == 0)
            {
                //Checks if user is attempting to change value of user ID
                if (!DataGrid_Users.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals(e.FormattedValue.ToString()))
                {
                    if (e.FormattedValue.ToString().Equals(settings.ALL_USERS) || 
                        e.FormattedValue.ToString().Equals(settings.GuestAccountID) ||
                        userList.UserIDExists(e.FormattedValue.ToString()))
                    {
                        DataGrid_Users.Rows[e.RowIndex].ErrorText = "UserID already exists!";
                        e.Cancel = true;
                    }
                }
            }
            else if (e.ColumnIndex == 2) //Balance col
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal result))
                {
                    DataGrid_Users.Rows[e.RowIndex].ErrorText = "Not a valid decimal value!";
                    e.Cancel = true;
                }
            }
        }

        //Clears error messages if user hits ESC to revert cell value
        private void DataGrid_Users_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGrid_Users.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        //Validates Inventory datagrid
        private void DataGrid_Inventory_CellValidating(Object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Ensure text fields reject commas
            if((e.ColumnIndex == 0 || e.ColumnIndex == 3) && e.FormattedValue.ToString().Contains(","))
            {
                DataGrid_Inventory.Rows[e.RowIndex].ErrorText = "Can't use commas!";
                e.Cancel = true;
            }

            //UPC col
            if (e.ColumnIndex == 3)
            {
                //Checks if user is attempting to change value of UPC
                if (!DataGrid_Inventory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals(e.FormattedValue.ToString()))
                {
                    if (inventory.GetItem(e.FormattedValue.ToString()) != null)
                    {
                        DataGrid_Inventory.Rows[e.RowIndex].ErrorText = "UPC already exists!";
                        e.Cancel = true;
                    }
                }
            }
            else if (e.ColumnIndex == 1) //Cost col
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal result))
                {
                    DataGrid_Inventory.Rows[e.RowIndex].ErrorText = "Not a valid decimal value!";
                    e.Cancel = true;
                }
            }
            else if (e.ColumnIndex == 2) //Amount col
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out int result))
                {
                    DataGrid_Inventory.Rows[e.RowIndex].ErrorText = "Not a valid integer value!";
                    e.Cancel = true;
                }
            }

        }

        //Clears error messages if user hits ESC to revert cell value
        private void DataGrid_Inventory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGrid_Inventory.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void Button_SelectLogin_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.soundFileDialog.ShowDialog();
            EasterEggUser u = (EasterEggUser)ListBox_EasterEggUsers.SelectedItem;
            u.LoginSounds.Clear();
            foreach (string str in soundFileDialog.FileNames.ToList())
            {
                u.LoginSounds.Add(str);
            }
        }

        private void Button_SelectScan_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.soundFileDialog.ShowDialog();
            EasterEggUser u = (EasterEggUser)ListBox_EasterEggUsers.SelectedItem;
            u.ScanSounds.Clear();
            foreach (string str in soundFileDialog.FileNames.ToList())
            {
                u.ScanSounds.Add(str);
            }
        }

        private void Button_SelectCheckout_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.soundFileDialog.ShowDialog();
            EasterEggUser u = (EasterEggUser)ListBox_EasterEggUsers.SelectedItem;
            u.CheckoutSounds.Clear();
            foreach (string str in soundFileDialog.FileNames.ToList())
            {
                u.CheckoutSounds.Add(str);
            }
        }

        private void TabControl_DataManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl_DataManagement.SelectedTab.Equals(Tab_EasterEggs))
                initializeEasterEggComp();
        }

        private void ListBox_EasterEggUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEasterEggControlsForNewUser();
        }

        private void CheckBox_LimitDebt_CheckedChanged(object sender, EventArgs e)
        {
            Numeric_MaxDebt.Enabled = CheckBox_LimitDebt.Checked;
            settings.LimitDebtEnabled = CheckBox_LimitDebt.Checked;
        }

        private void Numeric_MaxDebt_ValueChanged(object sender, EventArgs e)
        {
            settings.MaxDebtValue = (int)Numeric_MaxDebt.Value;
        }

        #endregion


    }
}
