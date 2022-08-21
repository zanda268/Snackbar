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
            this.Panel_LoggedIn = new System.Windows.Forms.Panel();
            this.Label_LoggedIn = new System.Windows.Forms.Label();
            this.GroupBox_Login = new System.Windows.Forms.GroupBox();
            this.Button_LoginClear = new System.Windows.Forms.Button();
            this.Button_Login = new System.Windows.Forms.Button();
            this.TextBox_Login = new System.Windows.Forms.TextBox();
            this.Label_UserID = new System.Windows.Forms.Label();
            this.GroupBox_PurchaseList = new System.Windows.Forms.GroupBox();
            this.Label_UPCErrorMessage = new System.Windows.Forms.Label();
            this.Button_Logout = new System.Windows.Forms.Button();
            this.Button_RemoveItemFromCart = new System.Windows.Forms.Button();
            this.Button_AddItemToCart = new System.Windows.Forms.Button();
            this.Button_ClearCart = new System.Windows.Forms.Button();
            this.Button_Checkout = new System.Windows.Forms.Button();
            this.ListBox_PurchaseList = new System.Windows.Forms.ListBox();
            this.purchaseListItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Label_PurchaseTotal = new System.Windows.Forms.Label();
            this.TextBox_PurchaseUPC = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Panel_LoggedIn.SuspendLayout();
            this.GroupBox_Login.SuspendLayout();
            this.GroupBox_PurchaseList.SuspendLayout();
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
            this.moneyQuickAddToolStripMenuItem.Click += new System.EventHandler(this.moneyQuickAddToolStripMenuItem_Click);
            // 
            // inventoryQuickAddToolStripMenuItem
            // 
            this.inventoryQuickAddToolStripMenuItem.Name = "inventoryQuickAddToolStripMenuItem";
            this.inventoryQuickAddToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.inventoryQuickAddToolStripMenuItem.Text = "Inventory Quick Add";
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
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openSaveLocationToolStripMenuItem
            // 
            this.openSaveLocationToolStripMenuItem.Name = "openSaveLocationToolStripMenuItem";
            this.openSaveLocationToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.openSaveLocationToolStripMenuItem.Text = "Open Save Location";
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
            this.panel1.Controls.Add(this.Panel_LoggedIn);
            this.panel1.Controls.Add(this.GroupBox_Login);
            this.panel1.Controls.Add(this.GroupBox_PurchaseList);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 426);
            this.panel1.TabIndex = 1;
            // 
            // Panel_LoggedIn
            // 
            this.Panel_LoggedIn.Controls.Add(this.Label_LoggedIn);
            this.Panel_LoggedIn.Location = new System.Drawing.Point(195, 3);
            this.Panel_LoggedIn.Name = "Panel_LoggedIn";
            this.Panel_LoggedIn.Size = new System.Drawing.Size(593, 82);
            this.Panel_LoggedIn.TabIndex = 5;
            // 
            // Label_LoggedIn
            // 
            this.Label_LoggedIn.BackColor = System.Drawing.Color.Maroon;
            this.Label_LoggedIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_LoggedIn.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_LoggedIn.ForeColor = System.Drawing.Color.White;
            this.Label_LoggedIn.Location = new System.Drawing.Point(0, 0);
            this.Label_LoggedIn.Name = "Label_LoggedIn";
            this.Label_LoggedIn.Size = new System.Drawing.Size(593, 82);
            this.Label_LoggedIn.TabIndex = 0;
            this.Label_LoggedIn.Text = "Not Logged In!";
            this.Label_LoggedIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox_Login
            // 
            this.GroupBox_Login.Controls.Add(this.Button_LoginClear);
            this.GroupBox_Login.Controls.Add(this.Button_Login);
            this.GroupBox_Login.Controls.Add(this.TextBox_Login);
            this.GroupBox_Login.Controls.Add(this.Label_UserID);
            this.GroupBox_Login.Location = new System.Drawing.Point(12, 3);
            this.GroupBox_Login.Name = "GroupBox_Login";
            this.GroupBox_Login.Size = new System.Drawing.Size(177, 82);
            this.GroupBox_Login.TabIndex = 4;
            this.GroupBox_Login.TabStop = false;
            this.GroupBox_Login.Text = "User Login";
            // 
            // Button_LoginClear
            // 
            this.Button_LoginClear.Location = new System.Drawing.Point(90, 42);
            this.Button_LoginClear.Name = "Button_LoginClear";
            this.Button_LoginClear.Size = new System.Drawing.Size(75, 23);
            this.Button_LoginClear.TabIndex = 3;
            this.Button_LoginClear.Text = "Clear";
            this.toolTip1.SetToolTip(this.Button_LoginClear, "Clears the text stored in the above text box.");
            this.Button_LoginClear.UseVisualStyleBackColor = true;
            this.Button_LoginClear.Click += new System.EventHandler(this.Button_LoginClear_Click);
            // 
            // Button_Login
            // 
            this.Button_Login.Location = new System.Drawing.Point(9, 42);
            this.Button_Login.Name = "Button_Login";
            this.Button_Login.Size = new System.Drawing.Size(75, 23);
            this.Button_Login.TabIndex = 2;
            this.Button_Login.Text = "Login";
            this.toolTip1.SetToolTip(this.Button_Login, "Click to log in with the current ID entered in the above text box.");
            this.Button_Login.UseVisualStyleBackColor = true;
            this.Button_Login.Click += new System.EventHandler(this.Button_Login_Click);
            // 
            // TextBox_Login
            // 
            this.TextBox_Login.Location = new System.Drawing.Point(58, 16);
            this.TextBox_Login.Name = "TextBox_Login";
            this.TextBox_Login.Size = new System.Drawing.Size(107, 20);
            this.TextBox_Login.TabIndex = 1;
            this.TextBox_Login.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_Login_KeyDown);
            // 
            // Label_UserID
            // 
            this.Label_UserID.AutoSize = true;
            this.Label_UserID.Location = new System.Drawing.Point(6, 19);
            this.Label_UserID.Name = "Label_UserID";
            this.Label_UserID.Size = new System.Drawing.Size(46, 13);
            this.Label_UserID.TabIndex = 0;
            this.Label_UserID.Text = "User ID:";
            this.toolTip1.SetToolTip(this.Label_UserID, "Enter a unique ID set by the Snackbar manager.");
            // 
            // GroupBox_PurchaseList
            // 
            this.GroupBox_PurchaseList.Controls.Add(this.Label_UPCErrorMessage);
            this.GroupBox_PurchaseList.Controls.Add(this.Button_Logout);
            this.GroupBox_PurchaseList.Controls.Add(this.Button_RemoveItemFromCart);
            this.GroupBox_PurchaseList.Controls.Add(this.Button_AddItemToCart);
            this.GroupBox_PurchaseList.Controls.Add(this.Button_ClearCart);
            this.GroupBox_PurchaseList.Controls.Add(this.Button_Checkout);
            this.GroupBox_PurchaseList.Controls.Add(this.ListBox_PurchaseList);
            this.GroupBox_PurchaseList.Controls.Add(this.Label_PurchaseTotal);
            this.GroupBox_PurchaseList.Controls.Add(this.TextBox_PurchaseUPC);
            this.GroupBox_PurchaseList.Enabled = false;
            this.GroupBox_PurchaseList.Location = new System.Drawing.Point(12, 91);
            this.GroupBox_PurchaseList.Name = "GroupBox_PurchaseList";
            this.GroupBox_PurchaseList.Size = new System.Drawing.Size(776, 323);
            this.GroupBox_PurchaseList.TabIndex = 3;
            this.GroupBox_PurchaseList.TabStop = false;
            this.GroupBox_PurchaseList.Text = "Purchase List";
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
            // Button_Logout
            // 
            this.Button_Logout.BackColor = System.Drawing.SystemColors.Control;
            this.Button_Logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Logout.ForeColor = System.Drawing.Color.Black;
            this.Button_Logout.Location = new System.Drawing.Point(632, 279);
            this.Button_Logout.Name = "Button_Logout";
            this.Button_Logout.Size = new System.Drawing.Size(138, 44);
            this.Button_Logout.TabIndex = 7;
            this.Button_Logout.Text = "Logout";
            this.toolTip1.SetToolTip(this.Button_Logout, "Cancels purchase and logs the current user out.");
            this.Button_Logout.UseVisualStyleBackColor = false;
            this.Button_Logout.Click += new System.EventHandler(this.Button_Logout_Click);
            // 
            // Button_RemoveItemFromCart
            // 
            this.Button_RemoveItemFromCart.Location = new System.Drawing.Point(294, 71);
            this.Button_RemoveItemFromCart.Name = "Button_RemoveItemFromCart";
            this.Button_RemoveItemFromCart.Size = new System.Drawing.Size(99, 23);
            this.Button_RemoveItemFromCart.TabIndex = 6;
            this.Button_RemoveItemFromCart.Text = "Remove Item";
            this.toolTip1.SetToolTip(this.Button_RemoveItemFromCart, "Removes selected item from cart to the left.");
            this.Button_RemoveItemFromCart.UseVisualStyleBackColor = true;
            this.Button_RemoveItemFromCart.Click += new System.EventHandler(this.Button_RemoveItemFromCart_Click);
            // 
            // Button_AddItemToCart
            // 
            this.Button_AddItemToCart.Location = new System.Drawing.Point(294, 42);
            this.Button_AddItemToCart.Name = "Button_AddItemToCart";
            this.Button_AddItemToCart.Size = new System.Drawing.Size(99, 23);
            this.Button_AddItemToCart.TabIndex = 5;
            this.Button_AddItemToCart.Text = "Add Item";
            this.toolTip1.SetToolTip(this.Button_AddItemToCart, "Adds item to cart that matches UPC in above text box.");
            this.Button_AddItemToCart.UseVisualStyleBackColor = true;
            this.Button_AddItemToCart.Click += new System.EventHandler(this.Button_AddItemToCart_Click);
            // 
            // Button_ClearCart
            // 
            this.Button_ClearCart.BackColor = System.Drawing.SystemColors.Control;
            this.Button_ClearCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_ClearCart.Location = new System.Drawing.Point(150, 273);
            this.Button_ClearCart.Name = "Button_ClearCart";
            this.Button_ClearCart.Size = new System.Drawing.Size(138, 44);
            this.Button_ClearCart.TabIndex = 4;
            this.Button_ClearCart.Text = "Clear Cart";
            this.toolTip1.SetToolTip(this.Button_ClearCart, "Clears all items from the cart.");
            this.Button_ClearCart.UseVisualStyleBackColor = false;
            this.Button_ClearCart.Click += new System.EventHandler(this.Button_ClearCart_Click);
            // 
            // Button_Checkout
            // 
            this.Button_Checkout.BackColor = System.Drawing.SystemColors.Control;
            this.Button_Checkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Checkout.Location = new System.Drawing.Point(6, 273);
            this.Button_Checkout.Name = "Button_Checkout";
            this.Button_Checkout.Size = new System.Drawing.Size(138, 44);
            this.Button_Checkout.TabIndex = 3;
            this.Button_Checkout.Text = "Purchase";
            this.toolTip1.SetToolTip(this.Button_Checkout, "Purchases all the items in the cart. Can also press Shift + Enter");
            this.Button_Checkout.UseVisualStyleBackColor = false;
            this.Button_Checkout.Click += new System.EventHandler(this.Button_Checkout_Click);
            // 
            // ListBox_PurchaseList
            // 
            this.ListBox_PurchaseList.DataSource = this.purchaseListItemBindingSource;
            this.ListBox_PurchaseList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox_PurchaseList.FormattingEnabled = true;
            this.ListBox_PurchaseList.ItemHeight = 16;
            this.ListBox_PurchaseList.Location = new System.Drawing.Point(6, 16);
            this.ListBox_PurchaseList.Name = "ListBox_PurchaseList";
            this.ListBox_PurchaseList.Size = new System.Drawing.Size(282, 180);
            this.ListBox_PurchaseList.TabIndex = 0;
            this.toolTip1.SetToolTip(this.ListBox_PurchaseList, "Displays a list of items currently in the cart to purchase.");
            // 
            // purchaseListItemBindingSource
            // 
            this.purchaseListItemBindingSource.DataSource = typeof(Snackbar.controller.Checkout.PurchaseListItem);
            // 
            // Label_PurchaseTotal
            // 
            this.Label_PurchaseTotal.AutoSize = true;
            this.Label_PurchaseTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_PurchaseTotal.Location = new System.Drawing.Point(3, 199);
            this.Label_PurchaseTotal.Name = "Label_PurchaseTotal";
            this.Label_PurchaseTotal.Size = new System.Drawing.Size(58, 16);
            this.Label_PurchaseTotal.TabIndex = 2;
            this.Label_PurchaseTotal.Text = "Total: $0";
            // 
            // TextBox_PurchaseUPC
            // 
            this.TextBox_PurchaseUPC.Location = new System.Drawing.Point(294, 16);
            this.TextBox_PurchaseUPC.Name = "TextBox_PurchaseUPC";
            this.TextBox_PurchaseUPC.Size = new System.Drawing.Size(165, 20);
            this.TextBox_PurchaseUPC.TabIndex = 1;
            this.toolTip1.SetToolTip(this.TextBox_PurchaseUPC, "Enter an Items UPC and then press enter or click the Add Item button.");
            this.TextBox_PurchaseUPC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_PurchaseUPC_KeyDown);
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
            this.Panel_LoggedIn.ResumeLayout(false);
            this.GroupBox_Login.ResumeLayout(false);
            this.GroupBox_Login.PerformLayout();
            this.GroupBox_PurchaseList.ResumeLayout(false);
            this.GroupBox_PurchaseList.PerformLayout();
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
        private System.Windows.Forms.TextBox TextBox_PurchaseUPC;
        private System.Windows.Forms.ListBox ListBox_PurchaseList;
        private System.Windows.Forms.BindingSource purchaseListItemBindingSource;
        private System.Windows.Forms.Label Label_PurchaseTotal;
        private System.Windows.Forms.GroupBox GroupBox_Login;
        private System.Windows.Forms.GroupBox GroupBox_PurchaseList;
        private System.Windows.Forms.Button Button_LoginClear;
        private System.Windows.Forms.Button Button_Login;
        private System.Windows.Forms.TextBox TextBox_Login;
        private System.Windows.Forms.Label Label_UserID;
        private System.Windows.Forms.Panel Panel_LoggedIn;
        private System.Windows.Forms.Label Label_LoggedIn;
        private System.Windows.Forms.Button Button_Checkout;
        private System.Windows.Forms.Button Button_ClearCart;
        private System.Windows.Forms.Button Button_RemoveItemFromCart;
        private System.Windows.Forms.Button Button_AddItemToCart;
        private System.Windows.Forms.Button Button_Logout;
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

