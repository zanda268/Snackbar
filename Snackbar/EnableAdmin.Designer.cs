namespace Snackbar
{
    partial class EnableAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_CancelAdmin = new System.Windows.Forms.Button();
            this.button_EnableAdmin = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_DisableTimer = new System.Windows.Forms.CheckBox();
            this.label_Disable2 = new System.Windows.Forms.Label();
            this.numeric_DisableTimer = new System.Windows.Forms.NumericUpDown();
            this.label_Disable1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Label_PasswordCheck = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.timer_DisableAdmin = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_DisableTimer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(302, 195);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_CancelAdmin);
            this.panel2.Controls.Add(this.button_EnableAdmin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 158);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 37);
            this.panel2.TabIndex = 6;
            // 
            // button_CancelAdmin
            // 
            this.button_CancelAdmin.Location = new System.Drawing.Point(84, 6);
            this.button_CancelAdmin.Name = "button_CancelAdmin";
            this.button_CancelAdmin.Size = new System.Drawing.Size(75, 23);
            this.button_CancelAdmin.TabIndex = 5;
            this.button_CancelAdmin.Text = "Cancel";
            this.button_CancelAdmin.UseVisualStyleBackColor = true;
            this.button_CancelAdmin.Click += new System.EventHandler(this.Button_CancelAdmin_Click);
            // 
            // button_EnableAdmin
            // 
            this.button_EnableAdmin.Enabled = false;
            this.button_EnableAdmin.Location = new System.Drawing.Point(3, 6);
            this.button_EnableAdmin.Name = "button_EnableAdmin";
            this.button_EnableAdmin.Size = new System.Drawing.Size(75, 23);
            this.button_EnableAdmin.TabIndex = 2;
            this.button_EnableAdmin.Text = "Enable";
            this.button_EnableAdmin.UseVisualStyleBackColor = true;
            this.button_EnableAdmin.Click += new System.EventHandler(this.Button_EnableAdmin_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_DisableTimer);
            this.groupBox2.Controls.Add(this.label_Disable2);
            this.groupBox2.Controls.Add(this.numeric_DisableTimer);
            this.groupBox2.Controls.Add(this.label_Disable1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(5, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Timer";
            // 
            // checkBox_DisableTimer
            // 
            this.checkBox_DisableTimer.AutoSize = true;
            this.checkBox_DisableTimer.Checked = true;
            this.checkBox_DisableTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_DisableTimer.Location = new System.Drawing.Point(10, 20);
            this.checkBox_DisableTimer.Name = "checkBox_DisableTimer";
            this.checkBox_DisableTimer.Size = new System.Drawing.Size(65, 17);
            this.checkBox_DisableTimer.TabIndex = 3;
            this.checkBox_DisableTimer.Text = "Enabled";
            this.toolTip1.SetToolTip(this.checkBox_DisableTimer, "Turns off admin mode automatically");
            this.checkBox_DisableTimer.UseVisualStyleBackColor = true;
            this.checkBox_DisableTimer.CheckedChanged += new System.EventHandler(this.CheckBox_DisableTimer_CheckedChanged);
            // 
            // label_Disable2
            // 
            this.label_Disable2.AutoSize = true;
            this.label_Disable2.Location = new System.Drawing.Point(77, 72);
            this.label_Disable2.Name = "label_Disable2";
            this.label_Disable2.Size = new System.Drawing.Size(44, 13);
            this.label_Disable2.TabIndex = 2;
            this.label_Disable2.Text = "Minutes";
            // 
            // numeric_DisableTimer
            // 
            this.numeric_DisableTimer.Location = new System.Drawing.Point(10, 70);
            this.numeric_DisableTimer.Name = "numeric_DisableTimer";
            this.numeric_DisableTimer.Size = new System.Drawing.Size(61, 20);
            this.numeric_DisableTimer.TabIndex = 4;
            this.toolTip1.SetToolTip(this.numeric_DisableTimer, "How many minutes until admin mode is disabled");
            this.numeric_DisableTimer.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label_Disable1
            // 
            this.label_Disable1.AutoSize = true;
            this.label_Disable1.Location = new System.Drawing.Point(7, 54);
            this.label_Disable1.Name = "label_Disable1";
            this.label_Disable1.Size = new System.Drawing.Size(132, 13);
            this.label_Disable1.TabIndex = 0;
            this.label_Disable1.Text = "Disable Admin Mode After:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label_PasswordCheck);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Password);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 53);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enable Admin";
            // 
            // Label_PasswordCheck
            // 
            this.Label_PasswordCheck.AutoSize = true;
            this.Label_PasswordCheck.Location = new System.Drawing.Point(175, 25);
            this.Label_PasswordCheck.Name = "Label_PasswordCheck";
            this.Label_PasswordCheck.Size = new System.Drawing.Size(0, 13);
            this.Label_PasswordCheck.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password:";
            this.toolTip1.SetToolTip(this.label1, "Default password is \"password\"");
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(69, 22);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(100, 20);
            this.textBox_Password.TabIndex = 1;
            this.textBox_Password.TextChanged += new System.EventHandler(this.TextBox_Password_TextChanged);
            this.textBox_Password.Enter += new System.EventHandler(this.TextBox_Password_Enter);
            this.textBox_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_Password_KeyDown);
            this.textBox_Password.Leave += new System.EventHandler(this.TextBox_Password_Leave);
            // 
            // EnableAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 195);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(318, 234);
            this.Name = "EnableAdmin";
            this.Text = "Admin Mode";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_DisableTimer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_DisableTimer;
        private System.Windows.Forms.Label label_Disable2;
        private System.Windows.Forms.NumericUpDown numeric_DisableTimer;
        private System.Windows.Forms.Label label_Disable1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_CancelAdmin;
        private System.Windows.Forms.Button button_EnableAdmin;
        private System.Windows.Forms.Label Label_PasswordCheck;
        private System.Windows.Forms.Timer timer_DisableAdmin;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}