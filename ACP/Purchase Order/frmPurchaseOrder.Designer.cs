namespace ACP
{
    partial class frmPurchaseOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnPOreport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnReceive = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNewOder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvPO = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.pLines = new System.Windows.Forms.Panel();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.lineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineDisc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).BeginInit();
            this.pLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(994, 120);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(986, 94);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Product";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 88);
            this.panel1.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnConfirm);
            this.panel5.Controls.Add(this.btnPOreport);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(265, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(228, 88);
            this.panel5.TabIndex = 3;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirm.Location = new System.Drawing.Point(81, 4);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(81, 58);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "Confimation";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnPOreport
            // 
            this.btnPOreport.Enabled = false;
            this.btnPOreport.FlatAppearance.BorderSize = 0;
            this.btnPOreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPOreport.Image = ((System.Drawing.Image)(resources.GetObject("btnPOreport.Image")));
            this.btnPOreport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPOreport.Location = new System.Drawing.Point(13, 4);
            this.btnPOreport.Margin = new System.Windows.Forms.Padding(0);
            this.btnPOreport.Name = "btnPOreport";
            this.btnPOreport.Size = new System.Drawing.Size(55, 58);
            this.btnPOreport.TabIndex = 7;
            this.btnPOreport.Text = "Report";
            this.btnPOreport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPOreport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPOreport.UseVisualStyleBackColor = true;
            this.btnPOreport.Click += new System.EventHandler(this.btnPOreport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Generate";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnReceive);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(198, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(67, 88);
            this.panel4.TabIndex = 2;
            // 
            // btnReceive
            // 
            this.btnReceive.Enabled = false;
            this.btnReceive.FlatAppearance.BorderSize = 0;
            this.btnReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceive.Image = ((System.Drawing.Image)(resources.GetObject("btnReceive.Image")));
            this.btnReceive.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReceive.Location = new System.Drawing.Point(5, 4);
            this.btnReceive.Margin = new System.Windows.Forms.Padding(0);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(55, 58);
            this.btnReceive.TabIndex = 2;
            this.btnReceive.Text = "Receive";
            this.btnReceive.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReceive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Receiving";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(61, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(137, 88);
            this.panel3.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(51, 34);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 25);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(51, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 25);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Maintain";
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEdit.Location = new System.Drawing.Point(3, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(39, 58);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnNewOder);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(61, 88);
            this.panel2.TabIndex = 0;
            // 
            // btnNewOder
            // 
            this.btnNewOder.FlatAppearance.BorderSize = 0;
            this.btnNewOder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewOder.Image = ((System.Drawing.Image)(resources.GetObject("btnNewOder.Image")));
            this.btnNewOder.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNewOder.Location = new System.Drawing.Point(1, 3);
            this.btnNewOder.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewOder.Name = "btnNewOder";
            this.btnNewOder.Size = new System.Drawing.Size(55, 58);
            this.btnNewOder.TabIndex = 1;
            this.btnNewOder.Text = "Order";
            this.btnNewOder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNewOder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewOder.UseVisualStyleBackColor = true;
            this.btnNewOder.Click += new System.EventHandler(this.btnNewOder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(986, 94);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(790, 124);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(623, 124);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 23);
            this.textBox1.TabIndex = 11;
            // 
            // dgvPO
            // 
            this.dgvPO.AllowUserToAddRows = false;
            this.dgvPO.AllowUserToDeleteRows = false;
            this.dgvPO.AllowUserToResizeColumns = false;
            this.dgvPO.AllowUserToResizeRows = false;
            this.dgvPO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPO.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvPO.BackgroundColor = System.Drawing.Color.White;
            this.dgvPO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPO.Location = new System.Drawing.Point(0, 154);
            this.dgvPO.MultiSelect = false;
            this.dgvPO.Name = "dgvPO";
            this.dgvPO.ReadOnly = true;
            this.dgvPO.RowHeadersVisible = false;
            this.dgvPO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPO.Size = new System.Drawing.Size(983, 416);
            this.dgvPO.TabIndex = 14;
            this.dgvPO.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPO_CellClick);
            this.dgvPO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPO_CellDoubleClick);
            this.dgvPO.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPO_DataBindingComplete);
            this.dgvPO.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvPO_Paint);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(915, 122);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 26);
            this.button5.TabIndex = 13;
            this.button5.Text = "Search";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // pLines
            // 
            this.pLines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLines.Controls.Add(this.dgvLines);
            this.pLines.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pLines.Location = new System.Drawing.Point(0, 576);
            this.pLines.Name = "pLines";
            this.pLines.Size = new System.Drawing.Size(994, 158);
            this.pLines.TabIndex = 15;
            this.pLines.Visible = false;
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.AllowUserToResizeColumns = false;
            this.dgvLines.AllowUserToResizeRows = false;
            this.dgvLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvLines.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvLines.BackgroundColor = System.Drawing.Color.White;
            this.dgvLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lineID,
            this.barcode,
            this.productDesc,
            this.subCategory,
            this.costUnit,
            this.costPrice,
            this.retailPrice,
            this.lineDisc,
            this.netAmount,
            this.remarks});
            this.dgvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLines.EnableHeadersVisualStyles = false;
            this.dgvLines.Location = new System.Drawing.Point(0, 0);
            this.dgvLines.MultiSelect = false;
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.ReadOnly = true;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.Size = new System.Drawing.Size(992, 156);
            this.dgvLines.TabIndex = 12;
            this.dgvLines.Visible = false;
            // 
            // lineID
            // 
            this.lineID.HeaderText = "Line ID";
            this.lineID.Name = "lineID";
            this.lineID.ReadOnly = true;
            this.lineID.Width = 62;
            // 
            // barcode
            // 
            this.barcode.HeaderText = "Barcode";
            this.barcode.Name = "barcode";
            this.barcode.ReadOnly = true;
            this.barcode.Width = 73;
            // 
            // productDesc
            // 
            this.productDesc.HeaderText = "Product Description";
            this.productDesc.Name = "productDesc";
            this.productDesc.ReadOnly = true;
            this.productDesc.Width = 123;
            // 
            // subCategory
            // 
            this.subCategory.HeaderText = "Sub category";
            this.subCategory.Name = "subCategory";
            this.subCategory.ReadOnly = true;
            this.subCategory.Width = 91;
            // 
            // costUnit
            // 
            this.costUnit.HeaderText = "Unit";
            this.costUnit.Name = "costUnit";
            this.costUnit.ReadOnly = true;
            this.costUnit.Width = 54;
            // 
            // costPrice
            // 
            this.costPrice.HeaderText = "Cost price";
            this.costPrice.Name = "costPrice";
            this.costPrice.ReadOnly = true;
            this.costPrice.Width = 77;
            // 
            // retailPrice
            // 
            this.retailPrice.HeaderText = "Retail price";
            this.retailPrice.Name = "retailPrice";
            this.retailPrice.ReadOnly = true;
            this.retailPrice.Width = 82;
            // 
            // lineDisc
            // 
            this.lineDisc.HeaderText = "Line disc";
            this.lineDisc.Name = "lineDisc";
            this.lineDisc.ReadOnly = true;
            this.lineDisc.Width = 70;
            // 
            // netAmount
            // 
            this.netAmount.HeaderText = "Net amount";
            this.netAmount.Name = "netAmount";
            this.netAmount.ReadOnly = true;
            this.netAmount.Width = 86;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Width = 75;
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 734);
            this.Controls.Add(this.pLines);
            this.Controls.Add(this.dgvPO);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPurchaseOrder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPurchaseOrder_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).EndInit();
            this.pLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNewOder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvPO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnConfirm;
        public System.Windows.Forms.Button btnPOreport;
        public System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Panel pLines;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn costUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineDisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn netAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;


    }
}