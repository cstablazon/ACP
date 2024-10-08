namespace ACP
{
    partial class frMain
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Product Management");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("All purchase order");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Purchase Order", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("All return order");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Return Order", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Process", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode3,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Hierarchy");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Storage Dimension Group");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Item Model Group");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Tracking Dimension Group");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Reservation Hierarchy");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Unit of Measure");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Inventory Location");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Site");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Warehouse", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Inventory", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Product Type");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Product Subtype");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Discount");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Item Tax Group");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Discounts", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Product", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Brand");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Setup", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode16,
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Reports");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Warehouse & Inventory", 6, 6, new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode24,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Process");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Setup");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Reports");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Retail", 7, 7, new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode28,
            treeNode29});
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Process");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Setup");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Reports");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Human Resource", 8, 8, new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode32,
            treeNode33});
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Supplier Management");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Process", new System.Windows.Forms.TreeNode[] {
            treeNode35});
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Payment Terms");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Group");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Contact type");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Setup", new System.Windows.Forms.TreeNode[] {
            treeNode37,
            treeNode38,
            treeNode39});
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Reports");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Accounting", new System.Windows.Forms.TreeNode[] {
            treeNode36,
            treeNode40,
            treeNode41});
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Process");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Item Sales Tax Group");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Setup", new System.Windows.Forms.TreeNode[] {
            treeNode44});
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Reports");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Administration", 4, 4, new System.Windows.Forms.TreeNode[] {
            treeNode43,
            treeNode45,
            treeNode46});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frMain));
            this.pHeader = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pSidebar = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.imageModule = new System.Windows.Forms.ImageList(this.components);
            this.lblUserRole = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pHeader.SuspendLayout();
            this.pSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.Crimson;
            this.pHeader.Controls.Add(this.label4);
            this.pHeader.Controls.Add(this.label1);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1022, 30);
            this.pHeader.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(968, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "[ CLOSE ]";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "MALL OF ACE CENTERPOINT";
            // 
            // pSidebar
            // 
            this.pSidebar.BackColor = System.Drawing.Color.White;
            this.pSidebar.Controls.Add(this.lblUser);
            this.pSidebar.Controls.Add(this.tvModule);
            this.pSidebar.Controls.Add(this.lblUserRole);
            this.pSidebar.Controls.Add(this.pictureBox2);
            this.pSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pSidebar.Location = new System.Drawing.Point(0, 30);
            this.pSidebar.Name = "pSidebar";
            this.pSidebar.Size = new System.Drawing.Size(287, 668);
            this.pSidebar.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(9, 74);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(272, 20);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "Juan D. Dela Cruz";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tvModule
            // 
            this.tvModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvModule.BackColor = System.Drawing.Color.White;
            this.tvModule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvModule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvModule.ImageIndex = 0;
            this.tvModule.ImageList = this.imageModule;
            this.tvModule.Location = new System.Drawing.Point(3, 110);
            this.tvModule.Name = "tvModule";
            treeNode1.Name = "ProductMgt";
            treeNode1.Text = "Product Management";
            treeNode2.Name = "allPO";
            treeNode2.Text = "All purchase order";
            treeNode3.Name = "po";
            treeNode3.Text = "Purchase Order";
            treeNode4.Name = "allReturnOrder";
            treeNode4.Text = "All return order";
            treeNode5.Name = "returnOrder";
            treeNode5.Text = "Return Order";
            treeNode6.Name = "cWareProcesss";
            treeNode6.Text = "Process";
            treeNode7.Name = "catHierarchy";
            treeNode7.Text = "Hierarchy";
            treeNode8.Name = "storage_dimension_group";
            treeNode8.Text = "Storage Dimension Group";
            treeNode9.Name = "item_model_group";
            treeNode9.Text = "Item Model Group";
            treeNode10.Name = "tracking_group";
            treeNode10.Text = "Tracking Dimension Group";
            treeNode11.Name = "reserv_hierarchy";
            treeNode11.Text = "Reservation Hierarchy";
            treeNode12.Name = "uom";
            treeNode12.Text = "Unit of Measure";
            treeNode13.Name = "inventLocation";
            treeNode13.Text = "Inventory Location";
            treeNode14.Name = "site";
            treeNode14.Text = "Site";
            treeNode15.Name = "warehouse";
            treeNode15.Text = "Warehouse";
            treeNode16.Name = "inventory";
            treeNode16.Text = "Inventory";
            treeNode17.Name = "prodType";
            treeNode17.Text = "Product Type";
            treeNode18.Name = "prodSubType";
            treeNode18.Text = "Product Subtype";
            treeNode19.Name = "discount";
            treeNode19.Text = "Discount";
            treeNode20.Name = "item_tax_group";
            treeNode20.Text = "Item Tax Group";
            treeNode21.Name = "discounts";
            treeNode21.Text = "Discounts";
            treeNode22.Name = "product";
            treeNode22.Text = "Product";
            treeNode23.Name = "brand";
            treeNode23.Text = "Brand";
            treeNode24.Name = "cWareSetup";
            treeNode24.Text = "Setup";
            treeNode25.Name = "cWareReports";
            treeNode25.Text = "Reports";
            treeNode26.ImageIndex = 6;
            treeNode26.Name = "pWI";
            treeNode26.SelectedImageIndex = 6;
            treeNode26.Text = "Warehouse & Inventory";
            treeNode27.Name = "cRetailProcess";
            treeNode27.Text = "Process";
            treeNode28.Name = "cRetailSetup";
            treeNode28.Text = "Setup";
            treeNode29.Name = "cRetailReports";
            treeNode29.Text = "Reports";
            treeNode30.ImageIndex = 7;
            treeNode30.Name = "pRetail";
            treeNode30.SelectedImageIndex = 7;
            treeNode30.Text = "Retail";
            treeNode31.Name = "cHRProcess";
            treeNode31.Text = "Process";
            treeNode32.Name = "cHRSetup";
            treeNode32.Text = "Setup";
            treeNode33.Name = "cHRReports";
            treeNode33.Text = "Reports";
            treeNode34.ImageIndex = 8;
            treeNode34.Name = "pHR";
            treeNode34.SelectedImageIndex = 8;
            treeNode34.Text = "Human Resource";
            treeNode35.Name = "supp";
            treeNode35.Text = "Supplier Management";
            treeNode36.Name = "cAccountingProcess";
            treeNode36.Text = "Process";
            treeNode37.Name = "paymentTerm";
            treeNode37.Text = "Payment Terms";
            treeNode38.Name = "group";
            treeNode38.Text = "Group";
            treeNode39.Name = "contactType";
            treeNode39.Text = "Contact type";
            treeNode40.Name = "cAccountingSetup";
            treeNode40.Text = "Setup";
            treeNode41.Name = "cAccountingReports";
            treeNode41.Text = "Reports";
            treeNode42.ImageIndex = 0;
            treeNode42.Name = "pAccounting";
            treeNode42.Text = "Accounting";
            treeNode43.Name = "cAdminProcess";
            treeNode43.Text = "Process";
            treeNode44.Name = "itemSalesTaxGroup";
            treeNode44.Text = "Item Sales Tax Group";
            treeNode45.Name = "cAdminSetup";
            treeNode45.Text = "Setup";
            treeNode46.Name = "cAdminReports";
            treeNode46.Text = "Reports";
            treeNode47.ImageIndex = 4;
            treeNode47.Name = "pAdmin";
            treeNode47.SelectedImageIndex = 4;
            treeNode47.Text = "Administration";
            this.tvModule.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode30,
            treeNode34,
            treeNode42,
            treeNode47});
            this.tvModule.SelectedImageIndex = 0;
            this.tvModule.Size = new System.Drawing.Size(278, 546);
            this.tvModule.TabIndex = 6;
            this.tvModule.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterSelect);
            // 
            // imageModule
            // 
            this.imageModule.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageModule.ImageStream")));
            this.imageModule.TransparentColor = System.Drawing.Color.Transparent;
            this.imageModule.Images.SetKeyName(0, "accounting.png");
            this.imageModule.Images.SetKeyName(1, "basket.png");
            this.imageModule.Images.SetKeyName(2, "budget.png");
            this.imageModule.Images.SetKeyName(3, "contract.png");
            this.imageModule.Images.SetKeyName(4, "engineer.png");
            this.imageModule.Images.SetKeyName(5, "inventory.png");
            this.imageModule.Images.SetKeyName(6, "received.png");
            this.imageModule.Images.SetKeyName(7, "report.png");
            this.imageModule.Images.SetKeyName(8, "resource (1).png");
            this.imageModule.Images.SetKeyName(9, "settings.png");
            // 
            // lblUserRole
            // 
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserRole.Location = new System.Drawing.Point(9, 94);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(272, 13);
            this.lblUserRole.TabIndex = 5;
            this.lblUserRole.Text = "Administrator";
            this.lblUserRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(103, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(81, 65);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pBody
            // 
            this.pBody.BackColor = System.Drawing.Color.White;
            this.pBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBody.Location = new System.Drawing.Point(287, 30);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(735, 668);
            this.pBody.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(287, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 668);
            this.panel1.TabIndex = 4;
            // 
            // frMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 698);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pBody);
            this.Controls.Add(this.pSidebar);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frMain_Load);
            this.Resize += new System.EventHandler(this.frMain_Resize);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pSidebar;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ImageList imageModule;
        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
    }
}