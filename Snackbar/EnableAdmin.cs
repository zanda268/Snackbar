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
    internal partial class EnableAdmin : Form
    {
        private Action EnableAdminMode;
        private Action DisableAdminMode;
        private Settings _settings;

        internal EnableAdmin(Settings settings, Action enableAdminMode, Action disableAdminMode)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.EnableAdminMode = enableAdminMode;
            this.DisableAdminMode = disableAdminMode;
            this._settings = settings;

            this.Icon = Properties.Resources.icon;
        }

        //Activates when Admin Disable timer ends
        private void Timer_DisableAdmin_Tick(object sender, EventArgs e)
        {
            timer_DisableAdmin.Enabled = false;
            DisableAdminMode();
        }

        //User wants to enable admin mode. Check/set timer
        private void Button_EnableAdmin_Click(object sender, EventArgs e)
        {
            if(checkBox_DisableTimer.Checked)
            {
                timer_DisableAdmin.Interval = (int)numeric_DisableTimer.Value * 1000 * 60;
                timer_DisableAdmin.Enabled = true;
                timer_DisableAdmin.Tick += new EventHandler(Timer_DisableAdmin_Tick);
            }

            EnableAdminMode();
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
            if(!_settings.AdminPassword.Equals(textBox_Password.Text))
            {
                button_EnableAdmin.Enabled = false;
                Label_PasswordCheck.Text = "Incorrect!";
                Label_PasswordCheck.ForeColor = System.Drawing.Color.Red;
            }
        }

        //Focused on password box. Clear it and reset label.
        private void TextBox_Password_Enter(object sender, EventArgs e)
        {
            textBox_Password.Clear();
            Label_PasswordCheck.Text = "";
            button_EnableAdmin.Enabled = false;
        }

        //User enabled/disabled timer group
        private void CheckBox_DisableTimer_CheckedChanged(object sender, EventArgs e)
        {
            label_Disable1.Enabled = !label_Disable1.Enabled;
            label_Disable2.Enabled = !label_Disable2.Enabled;
            numeric_DisableTimer.Enabled = !numeric_DisableTimer.Enabled;
        }

        private void TextBox_Password_TextChanged(object sender, EventArgs e)
        {
            //Validate password
            if (_settings.AdminPassword.Equals(textBox_Password.Text))
            {
                button_EnableAdmin.Enabled = true;
                Label_PasswordCheck.Text = "Correct!";
                Label_PasswordCheck.ForeColor = System.Drawing.Color.Green;
                button_EnableAdmin.Focus();
            }
        }

        private void TextBox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                textBox_Password.Clear();
                e.SuppressKeyPress = true;
            }
        }
    }
}
