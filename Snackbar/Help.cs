using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Snackbar
{
    internal partial class Help : Form
    {
        internal Help()
        {
            InitializeComponent();
            label_Version.Text = String.Format("Version {0}", AssemblyVersion);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Icon = Properties.Resources.icon;
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString().Substring(0, Assembly.GetExecutingAssembly().GetName().Version.ToString().LastIndexOf('.'));
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.freepik.com/vectors/lemon-background");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.vecteezy.com/free-vector/hand");
        }
    }
}
