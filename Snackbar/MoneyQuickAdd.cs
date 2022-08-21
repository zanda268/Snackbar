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

namespace Snackbar
{
    public partial class MoneyQuickAdd : Form
    {
        public User SelectedUser { get; set; }
        private UserList userList;

        public MoneyQuickAdd(UserList userList)
        {
            InitializeComponent();
            this.listBox1.DataSource = userList.GetUserList();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.userList = userList;
            this.TextBox_Search.Focus();
            this.Icon = Properties.Resources.icon;
        }

        private void Button_Select_Click(object sender, EventArgs e)
        {
            this.SelectedUser = (User)listBox1.SelectedValue;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TextBox_Search_TextChanged(object sender, EventArgs e)
        {
            SortableBindingList<User> filteredList = new SortableBindingList<User>(userList.GetUserList().Where(i =>
            i.Name.ToLower().Contains(TextBox_Search.Text.ToLower()) ||
            i.ID.ToLower().Contains(TextBox_Search.Text.ToLower())
            ).ToList());
            listBox1.DataSource = filteredList;
        }

        private void TextBox_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if(Keys.Enter == e.KeyCode)
            {
                Button_Select.PerformClick();
            }
        }
    }
}
