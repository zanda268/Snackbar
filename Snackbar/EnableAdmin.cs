using Snackbar.controller;
using Snackbar.model;
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
    public partial class EnableAdmin : Form
    {
        Action enableAdminMode;
        Action disableAdminMode;
        Settings settings;

        public EnableAdmin(Settings settings, Action enableAdminMode, Action disableAdminMode)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.enableAdminMode = enableAdminMode;
            this.disableAdminMode = disableAdminMode;
            this.settings = settings;

            this.Icon = Properties.Resources.icon;
        }

        //Activates when Admin Disable timer ends
        private void Timer_DisableAdmin_Tick(object sender, EventArgs e)
        {
            Timer_DisableAdmin.Enabled = false;
            disableAdminMode();
        }

        //User wants to enable admin mode. Check/set timer
        private void Button_EnableAdmin_Click(object sender, EventArgs e)
        {
            if(CheckBox_DisableTimer.Checked)
            {
                Timer_DisableAdmin.Interval = (int)Numeric_DisableTimer.Value * 1000 * 60;
                Timer_DisableAdmin.Enabled = true;
                Timer_DisableAdmin.Tick += new EventHandler(Timer_DisableAdmin_Tick);
            }

            enableAdminMode();
            this.Close();
        }

        //User wants to cancel and close the admin form
        private void Button_CancelAdmin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Focus Left password box. Validate password
        private void TextBox_Password_Leave(object sender, EventArgs e)
        {
            //Validate password
            if(!settings.AdminPassword.Equals(TextBox_Password.Text))
            {
                Button_EnableAdmin.Enabled = false;
                Label_PasswordCheck.Text = "Incorrect!";
                Label_PasswordCheck.ForeColor = System.Drawing.Color.Red;
            }
        }

        //Focused on password box. Clear it and reset label.
        private void TextBox_Password_Enter(object sender, EventArgs e)
        {
            TextBox_Password.Clear();
            Label_PasswordCheck.Text = "";
            Button_EnableAdmin.Enabled = false;
        }

        //User enabled/disabled timer group
        private void CheckBox_DisableTimer_CheckedChanged(object sender, EventArgs e)
        {
            Label_Disable1.Enabled = !Label_Disable1.Enabled;
            Label_Disable2.Enabled = !Label_Disable2.Enabled;
            Numeric_DisableTimer.Enabled = !Numeric_DisableTimer.Enabled;
        }

        private void TextBox_Password_TextChanged(object sender, EventArgs e)
        {
            //Validate password
            if (settings.AdminPassword.Equals(TextBox_Password.Text))
            {
                Button_EnableAdmin.Enabled = true;
                Label_PasswordCheck.Text = "Correct!";
                Label_PasswordCheck.ForeColor = System.Drawing.Color.Green;
                Button_EnableAdmin.Focus();
            }
        }
    }
}
