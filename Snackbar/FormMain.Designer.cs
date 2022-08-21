namespace Snackbar
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moneyQuickAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryQuickAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSaveLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_LoggedIn = new System.Windows.Forms.Panel();
            this.label_LoggedIn = new System.Windows.Forms.Label();
            this.groupBox_Login = new System.Windows.Forms.GroupBox();
            this.button_LoginClear = new System.Windows.Forms.Button();
            this.button_Login = new System.Windows.Forms.Button();
            this.textBox_Login = new System.Windows.Forms.TextBox();
            this.label_UserID = new System.Windows.Forms.Label();
            this.groupBox_PurchaseList = new System.Windows.Forms.GroupBox();
            this.Label_UPCErrorMessage = new System.Windows.Forms.Label();
            this.button_Logout = new System.Windows.Forms.Button();
            this.button_RemoveItemFromCart = new System.Windows.Forms.Button();
            this.button_AddItemToCart = new System.Windows.Forms.Button();
            this.button_ClearCart = new System.Windows.Forms.Button();
            this.button_Checkout = new System.Windows.Forms.Button();
            this.listBox_PurchaseList = new System.Windows.Forms.ListBox();
            this.purchaseListItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label_PurchaseTotal = new System.Windows.Forms.Label();
            this.textBox_PurchaseUPC = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_LoggedIn.SuspendLayout();
            this.groupBox_Login.SuspendLayout();
            this.groupBox_PurchaseList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseListItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminModeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // adminModeToolStripMenuItem
            // 
            this.adminModeToolStripMenuItem.Name = "adminModeToolStripMenuItem";
            this.adminModeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.adminModeToolStripMenuItem.Text = "Enable Admin Mode";
            this.adminModeToolStripMenuItem.Click += new System.EventHandler(this.adminModeToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDataToolStripMenuItem,
            this.toolStripSeparator1,
            this.moneyQuickAddToolStripMenuItem,
            this.inventoryQuickAddToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.openSaveLocationToolStripMenuItem});
            this.adminToolStripMenuItem.Enabled = false;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // saveDataToolStripMenuItem
            // 
            this.saveDataToolStripMenuItem.Name = "saveDataToolStripMenuItem";
            this.saveDataToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveDataToolStripMenuItem.Text = "Data Management";
            this.saveDataToolStripMenuItem.ToolTipText = "Opens a panel to edit any data stored in the application.";
            this.saveDataToolStripMenuItem.Click += new System.EventHandler(this.dataManagementToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // moneyQuickAddToolStripMenuItem
            // 
            this.moneyQuickAddToolStripMenuItem.Name = "moneyQuickAddToolStripMenuItem";
            this.moneyQuickAddToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.moneyQuickAddToolStripMenuItem.Text = "Money Quick Add";
            this.moneyQuickAddToolStripMenuItem.ToolTipText = "Add money to user quickly";
            this.moneyQuickAddToolStripMenuItem.Click += new System.EventHandler(this.moneyQuickAddToolStripMenuItem_Click);
            // 
            // inventoryQuickAddToolStripMenuItem
            // 
            this.inventoryQuickAddToolStripMenuItem.Name = "inventoryQuickAddToolStripMenuItem";
            this.inventoryQuickAddToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.inventoryQuickAddToolStripMenuItem.Text = "Inventory Quick Add";
            this.inventoryQuickAddToolStripMenuItem.ToolTipText = "Add Items/stock quickly";
            this.inventoryQuickAddToolStripMenuItem.Click += new System.EventHandler(this.inventoryQuickAddToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.ToolTipText = "Manually save all data in application.";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openSaveLocationToolStripMenuItem
            // 
            this.openSaveLocationToolStripMenuItem.Name = "openSaveLocationToolStripMenuItem";
            this.openSaveLocationToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.openSaveLocationToolStripMenuItem.Text = "Open Save Location";
            this.openSaveLocationToolStripMenuItem.ToolTipText = "Opens the folder where all files are saved.";
            this.openSaveLocationToolStripMenuItem.Click += new System.EventHandler(this.openSaveLocationToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel_LoggedIn);
            this.panel1.Controls.Add(this.groupBox_Login);
            this.panel1.Controls.Add(this.groupBox_PurchaseList);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 426);
            this.panel1.TabIndex = 1;
            // 
            // panel_LoggedIn
            // 
            this.panel_LoggedIn.Controls.Add(this.label_LoggedIn);
            this.panel_LoggedIn.Location = new System.Drawing.Point(195, 3);
            this.panel_LoggedIn.Name = "panel_LoggedIn";
            this.panel_LoggedIn.Size = new System.Drawing.Size(593, 82);
            this.panel_LoggedIn.TabIndex = 5;
            // 
            // label_LoggedIn
            // 
            this.label_LoggedIn.BackColor = System.Drawing.Color.Maroon;
            this.label_LoggedIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LoggedIn.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LoggedIn.ForeColor = System.Drawing.Color.White;
            this.label_LoggedIn.Location = new System.Drawing.Point(0, 0);
            this.label_LoggedIn.Name = "label_LoggedIn";
            this.label_LoggedIn.Size = new System.Drawing.Size(593, 82);
            this.label_LoggedIn.TabIndex = 0;
            this.label_LoggedIn.Text = "Not Logged In!";
            this.label_LoggedIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox_Login
            // 
            this.groupBox_Login.Controls.Add(this.button_LoginClear);
            this.groupBox_Login.Controls.Add(this.button_Login);
            this.groupBox_Login.Controls.Add(this.textBox_Login);
            this.groupBox_Login.Controls.Add(this.label_UserID);
            this.groupBox_Login.Location = new System.Drawing.Point(12, 3);
            this.groupBox_Login.Name = "groupBox_Login";
            this.groupBox_Login.Size = new System.Drawing.Size(177, 82);
            this.groupBox_Login.TabIndex = 4;
            this.groupBox_Login.TabStop = false;
            this.groupBox_Login.Text = "User Login";
            // 
            // button_LoginClear
            // 
            this.button_LoginClear.Location = new System.Drawing.Point(90, 42);
            this.button_LoginClear.Name = "button_LoginClear";
            this.button_LoginClear.Size = new System.Drawing.Size(75, 23);
            this.button_LoginClear.TabIndex = 3;
            this.button_LoginClear.Text = "Clear";
            this.toolTip1.SetToolTip(this.button_LoginClear, "Clears the text stored in the above text box.");
            this.button_LoginClear.UseVisualStyleBackColor = true;
            this.button_LoginClear.Click += new System.EventHandler(this.Button_LoginClear_Click);
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(9, 42);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(75, 23);
            this.button_Login.TabIndex = 2;
            this.button_Login.Text = "Login";
            this.toolTip1.SetToolTip(this.button_Login, "Click to log in with the current ID entered in the above text box.");
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.Button_Login_Click);
            // 
            // textBox_Login
            // 
            this.textBox_Login.Location = new System.Drawing.Point(58, 16);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(107, 20);
            this.textBox_Login.TabIndex = 1;
            this.textBox_Login.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_Login_KeyDown);
            // 
            // label_UserID
            // 
            this.label_UserID.AutoSize = true;
            this.label_UserID.Location = new System.Drawing.Point(6, 19);
            this.label_UserID.Name = "label_UserID";
            this.label_UserID.Size = new System.Drawing.Size(46, 13);
            this.label_UserID.TabIndex = 0;
            this.label_UserID.Text = "User ID:";
            this.toolTip1.SetToolTip(this.label_UserID, "Enter a unique ID set by the Snackbar manager.");
            // 
            // groupBox_PurchaseList
            // 
            this.groupBox_PurchaseList.Controls.Add(this.Label_UPCErrorMessage);
            this.groupBox_PurchaseList.Controls.Add(this.button_Logout);
            this.groupBox_PurchaseList.Controls.Add(this.button_RemoveItemFromCart);
            this.groupBox_PurchaseList.Controls.Add(this.button_AddItemToCart);
            this.groupBox_PurchaseList.Controls.Add(this.button_ClearCart);
            this.groupBox_PurchaseList.Controls.Add(this.button_Checkout);
            this.groupBox_PurchaseList.Controls.Add(this.listBox_PurchaseList);
            this.groupBox_PurchaseList.Controls.Add(this.label_PurchaseTotal);
            this.groupBox_PurchaseList.Controls.Add(this.textBox_PurchaseUPC);
            this.groupBox_PurchaseList.Enabled = false;
            this.groupBox_PurchaseList.Location = new System.Drawing.Point(12, 91);
            this.groupBox_PurchaseList.Name = "groupBox_PurchaseList";
            this.groupBox_PurchaseList.Size = new System.Drawing.Size(776, 323);
            this.groupBox_PurchaseList.TabIndex = 3;
            this.groupBox_PurchaseList.TabStop = false;
            this.groupBox_PurchaseList.Text = "Purchase List";
            // 
            // Label_UPCErrorMessage
            // 
            this.Label_UPCErrorMessage.AutoSize = true;
            this.Label_UPCErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.Label_UPCErrorMessage.Location = new System.Drawing.Point(465, 19);
            this.Label_UPCErrorMessage.Name = "Label_UPCErrorMessage";
            this.Label_UPCErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.Label_UPCErrorMessage.TabIndex = 8;
            // 
            // button_Logout
            // 
            this.button_Logout.BackColor = System.Drawing.SystemColors.Control;
            this.button_Logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Logout.ForeColor = System.Drawing.Color.Black;
            this.button_Logout.Location = new System.Drawing.Point(632, 279);
            this.button_Logout.Name = "button_Logout";
            this.button_Logout.Size = new System.Drawing.Size(138, 44);
            this.button_Logout.TabIndex = 7;
            this.button_Logout.Text = "Logout";
            this.toolTip1.SetToolTip(this.button_Logout, "Cancels purchase and logs the current user out.");
            this.button_Logout.UseVisualStyleBackColor = false;
            this.button_Logout.Click += new System.EventHandler(this.Button_Logout_Click);
            // 
            // button_RemoveItemFromCart
            // 
            this.button_RemoveItemFromCart.Location = new System.Drawing.Point(294, 71);
            this.button_RemoveItemFromCart.Name = "button_RemoveItemFromCart";
            this.button_RemoveItemFromCart.Size = new System.Drawing.Size(99, 23);
            this.button_RemoveItemFromCart.TabIndex = 6;
            this.button_RemoveItemFromCart.Text = "Remove Item";
            this.toolTip1.SetToolTip(this.button_RemoveItemFromCart, "Removes selected item from cart to the left.");
            this.button_RemoveItemFromCart.UseVisualStyleBackColor = true;
            this.button_RemoveItemFromCart.Click += new System.EventHandler(this.Button_RemoveItemFromCart_Click);
            // 
            // button_AddItemToCart
            // 
            this.button_AddItemToCart.Location = new System.Drawing.Point(294, 42);
            this.button_AddItemToCart.Name = "button_AddItemToCart";
            this.button_AddItemToCart.Size = new System.Drawing.Size(99, 23);
            this.button_AddItemToCart.TabIndex = 5;
            this.button_AddItemToCart.Text = "Add Item";
            this.toolTip1.SetToolTip(this.button_AddItemToCart, "Adds item to cart that matches UPC in above text box.");
            this.button_AddItemToCart.UseVisualStyleBackColor = true;
            this.button_AddItemToCart.Click += new System.EventHandler(this.Button_AddItemToCart_Click);
            // 
            // button_ClearCart
            // 
            this.button_ClearCart.BackColor = System.Drawing.SystemColors.Control;
            this.button_ClearCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearCart.Location = new System.Drawing.Point(150, 273);
            this.button_ClearCart.Name = "button_ClearCart";
            this.button_ClearCart.Size = new System.Drawing.Size(138, 44);
            this.button_ClearCart.TabIndex = 4;
            this.button_ClearCart.Text = "Clear Cart";
            this.toolTip1.SetToolTip(this.button_ClearCart, "Clears all items from the cart.");
            this.button_ClearCart.UseVisualStyleBackColor = false;
            this.button_ClearCart.Click += new System.EventHandler(this.Button_ClearCart_Click);
            // 
            // button_Checkout
            // 
            this.button_Checkout.BackColor = System.Drawing.SystemColors.Control;
            this.button_Checkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Checkout.Location = new System.Drawing.Point(6, 273);
            this.button_Checkout.Name = "button_Checkout";
            this.button_Checkout.Size = new System.Drawing.Size(138, 44);
            this.button_Checkout.TabIndex = 3;
            this.button_Checkout.Text = "Purchase";
            this.toolTip1.SetToolTip(this.button_Checkout, "Purchases all the items in the cart. Can also press Shift + Enter");
            this.button_Checkout.UseVisualStyleBackColor = false;
            this.button_Checkout.Click += new System.EventHandler(this.Button_Checkout_Click);
            // 
            // listBox_PurchaseList
            // 
            this.listBox_PurchaseList.DataSource = this.purchaseListItemBindingSource;
            this.listBox_PurchaseList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_PurchaseList.FormattingEnabled = true;
            this.listBox_PurchaseList.ItemHeight = 16;
            this.listBox_PurchaseList.Location = new System.Drawing.Point(6, 16);
            this.listBox_PurchaseList.Name = "listBox_PurchaseList";
            this.listBox_PurchaseList.Size = new System.Drawing.Size(282, 180);
            this.listBox_PurchaseList.TabIndex = 0;
            this.toolTip1.SetToolTip(this.listBox_PurchaseList, "Displays a list of items currently in the cart to purchase.");
            // 
            // purchaseListItemBindingSource
            // 
            this.purchaseListItemBindingSource.DataSource = typeof(Snackbar.controller.Checkout.PurchaseListItem);
            // 
            // label_PurchaseTotal
            // 
            this.label_PurchaseTotal.AutoSize = true;
            this.label_PurchaseTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PurchaseTotal.Location = new System.Drawing.Point(3, 199);
            this.label_PurchaseTotal.Name = "label_PurchaseTotal";
            this.label_PurchaseTotal.Size = new System.Drawing.Size(58, 16);
            this.label_PurchaseTotal.TabIndex = 2;
            this.label_PurchaseTotal.Text = "Total: $0";
            // 
            // textBox_PurchaseUPC
            // 
            this.textBox_PurchaseUPC.Location = new System.Drawing.Point(294, 16);
            this.textBox_PurchaseUPC.Name = "textBox_PurchaseUPC";
            this.textBox_PurchaseUPC.Size = new System.Drawing.Size(165, 20);
            this.textBox_PurchaseUPC.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox_PurchaseUPC, "Enter an Items UPC and then press enter or click the Add Item button.");
            this.textBox_PurchaseUPC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_PurchaseUPC_KeyDown);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "FormMain";
            this.Text = "Snackbar";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel_LoggedIn.ResumeLayout(false);
            this.groupBox_Login.ResumeLayout(false);
            this.groupBox_Login.PerformLayout();
            this.groupBox_PurchaseList.ResumeLayout(false);
            this.groupBox_PurchaseList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseListItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_PurchaseUPC;
        private System.Windows.Forms.ListBox listBox_PurchaseList;
        private System.Windows.Forms.BindingSource purchaseListItemBindingSource;
        private System.Windows.Forms.Label label_PurchaseTotal;
        private System.Windows.Forms.GroupBox groupBox_Login;
        private System.Windows.Forms.GroupBox groupBox_PurchaseList;
        private System.Windows.Forms.Button button_LoginClear;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.TextBox textBox_Login;
        private System.Windows.Forms.Label label_UserID;
        private System.Windows.Forms.Panel panel_LoggedIn;
        private System.Windows.Forms.Label label_LoggedIn;
        private System.Windows.Forms.Button button_Checkout;
        private System.Windows.Forms.Button button_ClearCart;
        private System.Windows.Forms.Button button_RemoveItemFromCart;
        private System.Windows.Forms.Button button_AddItemToCart;
        private System.Windows.Forms.Button button_Logout;
        private System.Windows.Forms.Label Label_UPCErrorMessage;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryQuickAddToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem moneyQuickAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSaveLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

