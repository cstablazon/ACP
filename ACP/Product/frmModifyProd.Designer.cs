namespace ACP
{
    partial class frmModifyProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifyProd));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pGeneral = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbProdDimension = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.cbSKU = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbConcession = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProdSubType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbProdType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGeneral = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pProdCategory = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsBtnNewBarcode = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteBarcode = new System.Windows.Forms.ToolStripButton();
            this.dgvBarcode = new System.Windows.Forms.DataGridView();
            this.lblProdDetails = new System.Windows.Forms.Label();
            this.pFinancials = new System.Windows.Forms.Panel();
            this.label56 = new System.Windows.Forms.Label();
            this.cbSalesTax = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.cbPurchaseTax = new System.Windows.Forms.ComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.cbItemGroup = new System.Windows.Forms.ComboBox();
            this.lblFinancials = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnKitSetup = new System.Windows.Forms.Button();
            this.btnBrand = new System.Windows.Forms.Button();
            this.btnOtherPrice = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnCatHierarchy = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnNewBarcode = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.pGeneral.SuspendLayout();
            this.pProdCategory.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode)).BeginInit();
            this.pFinancials.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.pGeneral);
            this.flowLayoutPanel1.Controls.Add(this.pProdCategory);
            this.flowLayoutPanel1.Controls.Add(this.pFinancials);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 104);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(955, 483);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // pGeneral
            // 
            this.pGeneral.BackColor = System.Drawing.Color.White;
            this.pGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pGeneral.Controls.Add(this.label15);
            this.pGeneral.Controls.Add(this.cmbProdDimension);
            this.pGeneral.Controls.Add(this.label13);
            this.pGeneral.Controls.Add(this.txtDepartment);
            this.pGeneral.Controls.Add(this.label10);
            this.pGeneral.Controls.Add(this.txtSupplier);
            this.pGeneral.Controls.Add(this.txtCategory);
            this.pGeneral.Controls.Add(this.cmbBrand);
            this.pGeneral.Controls.Add(this.cbSKU);
            this.pGeneral.Controls.Add(this.label4);
            this.pGeneral.Controls.Add(this.cbConcession);
            this.pGeneral.Controls.Add(this.label2);
            this.pGeneral.Controls.Add(this.cmbProdSubType);
            this.pGeneral.Controls.Add(this.label6);
            this.pGeneral.Controls.Add(this.cmbProdType);
            this.pGeneral.Controls.Add(this.label8);
            this.pGeneral.Controls.Add(this.label1);
            this.pGeneral.Controls.Add(this.lblGeneral);
            this.pGeneral.Controls.Add(this.label14);
            this.pGeneral.Controls.Add(this.label12);
            this.pGeneral.Controls.Add(this.txtSKU);
            this.pGeneral.Controls.Add(this.label11);
            this.pGeneral.Controls.Add(this.label7);
            this.pGeneral.Controls.Add(this.txtProdName);
            this.pGeneral.Controls.Add(this.label3);
            this.pGeneral.Location = new System.Drawing.Point(3, 3);
            this.pGeneral.MaximumSize = new System.Drawing.Size(950, 258);
            this.pGeneral.MinimumSize = new System.Drawing.Size(854, 20);
            this.pGeneral.Name = "pGeneral";
            this.pGeneral.Size = new System.Drawing.Size(950, 258);
            this.pGeneral.TabIndex = 0;
            this.pGeneral.Paint += new System.Windows.Forms.PaintEventHandler(this.pGeneral_Paint);
            this.pGeneral.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pGeneral_MouseDown);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.Location = new System.Drawing.Point(799, 593);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(83, 30);
            this.btnCreate.TabIndex = 96;
            this.btnCreate.Text = "Save";
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(888, 593);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 30);
            this.btnClose.TabIndex = 97;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(16, 201);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 15);
            this.label15.TabIndex = 94;
            this.label15.Text = "Product variant";
            // 
            // cmbProdDimension
            // 
            this.cmbProdDimension.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbProdDimension.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbProdDimension.Enabled = false;
            this.cmbProdDimension.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdDimension.FormattingEnabled = true;
            this.cmbProdDimension.IntegralHeight = false;
            this.cmbProdDimension.Items.AddRange(new object[] {
            "KITTING",
            "REPACK"});
            this.cmbProdDimension.Location = new System.Drawing.Point(155, 218);
            this.cmbProdDimension.Name = "cmbProdDimension";
            this.cmbProdDimension.Size = new System.Drawing.Size(191, 23);
            this.cmbProdDimension.TabIndex = 93;
            this.cmbProdDimension.SelectedIndexChanged += new System.EventHandler(this.cmbProdDimension_SelectedIndexChanged);
            this.cmbProdDimension.Enter += new System.EventHandler(this.cmbProdDimension_Enter);
            this.cmbProdDimension.Leave += new System.EventHandler(this.cmbProdDimension_Leave);
            this.cmbProdDimension.MouseHover += new System.EventHandler(this.cmbProdDimension_MouseHover);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 221);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 15);
            this.label13.TabIndex = 92;
            this.label13.Text = "Product dimension:";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepartment.Location = new System.Drawing.Point(155, 72);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(191, 23);
            this.txtDepartment.TabIndex = 89;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 15);
            this.label10.TabIndex = 88;
            this.label10.Text = "Department:";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(621, 96);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(293, 23);
            this.txtSupplier.TabIndex = 87;
            this.txtSupplier.Click += new System.EventHandler(this.txtSupplier_Click);
            this.txtSupplier.TextChanged += new System.EventHandler(this.txtSupplier_TextChanged);
            this.txtSupplier.Enter += new System.EventHandler(this.txtSupplier_Enter);
            this.txtSupplier.Leave += new System.EventHandler(this.txtSupplier_Leave);
            this.txtSupplier.MouseHover += new System.EventHandler(this.txtSupplier_MouseHover);
            // 
            // txtCategory
            // 
            this.txtCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(155, 43);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(191, 23);
            this.txtCategory.TabIndex = 85;
            this.txtCategory.Click += new System.EventHandler(this.txtCategory_Click);
            this.txtCategory.TextChanged += new System.EventHandler(this.txtCategory_TextChanged);
            this.txtCategory.Enter += new System.EventHandler(this.txtCategory_Enter);
            this.txtCategory.Leave += new System.EventHandler(this.txtCategory_Leave);
            this.txtCategory.MouseHover += new System.EventHandler(this.txtCategory_MouseHover);
            // 
            // cmbBrand
            // 
            this.cmbBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbBrand.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.IntegralHeight = false;
            this.cmbBrand.Location = new System.Drawing.Point(155, 101);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(191, 23);
            this.cmbBrand.TabIndex = 84;
            this.cmbBrand.Enter += new System.EventHandler(this.cmbBrand_Enter);
            // 
            // cbSKU
            // 
            this.cbSKU.AutoSize = true;
            this.cbSKU.Location = new System.Drawing.Point(818, 41);
            this.cbSKU.Name = "cbSKU";
            this.cbSKU.Size = new System.Drawing.Size(101, 17);
            this.cbSKU.TabIndex = 2;
            this.cbSKU.Text = "Auto Generate";
            this.cbSKU.UseVisualStyleBackColor = true;
            this.cbSKU.CheckedChanged += new System.EventHandler(this.cbSKU_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 76;
            this.label4.Text = "Brand:";
            // 
            // cbConcession
            // 
            this.cbConcession.AutoSize = true;
            this.cbConcession.Location = new System.Drawing.Point(621, 127);
            this.cbConcession.Name = "cbConcession";
            this.cbConcession.Size = new System.Drawing.Size(15, 14);
            this.cbConcession.TabIndex = 10;
            this.cbConcession.UseVisualStyleBackColor = true;
            this.cbConcession.CheckedChanged += new System.EventHandler(this.cbConcession_CheckedChanged);
            this.cbConcession.Enter += new System.EventHandler(this.cbConcession_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(486, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 72;
            this.label2.Text = "Concession:";
            // 
            // cmbProdSubType
            // 
            this.cmbProdSubType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdSubType.FormattingEnabled = true;
            this.cmbProdSubType.Location = new System.Drawing.Point(155, 161);
            this.cmbProdSubType.Name = "cmbProdSubType";
            this.cmbProdSubType.Size = new System.Drawing.Size(191, 23);
            this.cmbProdSubType.TabIndex = 6;
            this.cmbProdSubType.SelectedIndexChanged += new System.EventHandler(this.cmbProdSubType_SelectedIndexChanged);
            this.cmbProdSubType.Enter += new System.EventHandler(this.cmbProdSubType_Enter);
            this.cmbProdSubType.Leave += new System.EventHandler(this.cmbProdSubType_Leave);
            this.cmbProdSubType.MouseHover += new System.EventHandler(this.cmbProdSubType_MouseHover);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 70;
            this.label6.Text = "Product subtype:";
            // 
            // cmbProdType
            // 
            this.cmbProdType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProdType.FormattingEnabled = true;
            this.cmbProdType.Location = new System.Drawing.Point(155, 132);
            this.cmbProdType.Name = "cmbProdType";
            this.cmbProdType.Size = new System.Drawing.Size(191, 23);
            this.cmbProdType.TabIndex = 5;
            this.cmbProdType.SelectedIndexChanged += new System.EventHandler(this.cmbProdType_SelectedIndexChanged);
            this.cmbProdType.Enter += new System.EventHandler(this.cmbProdType_Enter);
            this.cmbProdType.Leave += new System.EventHandler(this.cmbProdType_Leave);
            this.cmbProdType.MouseHover += new System.EventHandler(this.cmbProdType_MouseHover);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 15);
            this.label8.TabIndex = 68;
            this.label8.Text = "Product type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 64;
            this.label1.Text = "Category:";
            // 
            // lblGeneral
            // 
            this.lblGeneral.AutoSize = true;
            this.lblGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGeneral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGeneral.Location = new System.Drawing.Point(0, 0);
            this.lblGeneral.Name = "lblGeneral";
            this.lblGeneral.Size = new System.Drawing.Size(61, 15);
            this.lblGeneral.TabIndex = 0;
            this.lblGeneral.Text = "1 General";
            this.lblGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGeneral.Click += new System.EventHandler(this.label1_Click);
            this.lblGeneral.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblGeneral_MouseDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(485, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 15);
            this.label14.TabIndex = 61;
            this.label14.Text = "Product name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(486, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 15);
            this.label12.TabIndex = 60;
            this.label12.Text = "SKU:";
            // 
            // txtSKU
            // 
            this.txtSKU.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSKU.Location = new System.Drawing.Point(621, 38);
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(191, 23);
            this.txtSKU.TabIndex = 1;
            this.txtSKU.Click += new System.EventHandler(this.txtSKU_Click);
            this.txtSKU.TextChanged += new System.EventHandler(this.txtSKU_TextChanged);
            this.txtSKU.Enter += new System.EventHandler(this.txtSKU_Enter);
            this.txtSKU.Leave += new System.EventHandler(this.txtSKU_Leave);
            this.txtSKU.MouseHover += new System.EventHandler(this.txtSKU_MouseHover);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(485, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 58;
            this.label11.Text = "Identification";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 15);
            this.label7.TabIndex = 57;
            this.label7.Text = "Administration";
            // 
            // txtProdName
            // 
            this.txtProdName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdName.Location = new System.Drawing.Point(621, 67);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Size = new System.Drawing.Size(293, 23);
            this.txtProdName.TabIndex = 7;
            this.txtProdName.TextChanged += new System.EventHandler(this.txtProdName_TextChanged);
            this.txtProdName.Enter += new System.EventHandler(this.txtProdName_Enter);
            this.txtProdName.Leave += new System.EventHandler(this.txtProdName_Leave);
            this.txtProdName.MouseHover += new System.EventHandler(this.txtProdName_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(486, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 33;
            this.label3.Text = "Supplier:";
            // 
            // pProdCategory
            // 
            this.pProdCategory.BackColor = System.Drawing.Color.White;
            this.pProdCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pProdCategory.Controls.Add(this.groupBox1);
            this.pProdCategory.Controls.Add(this.lblProdDetails);
            this.pProdCategory.Location = new System.Drawing.Point(3, 267);
            this.pProdCategory.MaximumSize = new System.Drawing.Size(955, 320);
            this.pProdCategory.MinimumSize = new System.Drawing.Size(854, 20);
            this.pProdCategory.Name = "pProdCategory";
            this.pProdCategory.Size = new System.Drawing.Size(950, 96);
            this.pProdCategory.TabIndex = 1;
            this.pProdCategory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pProdCategory_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip3);
            this.groupBox1.Controls.Add(this.dgvBarcode);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(936, 285);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Additional Information and Barcode";
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNewBarcode,
            this.tsbEdit,
            this.tsbDeleteBarcode,
            this.tsbView});
            this.toolStrip3.Location = new System.Drawing.Point(3, 18);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(930, 25);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            this.toolStrip3.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip3_ItemClicked);
            // 
            // tsBtnNewBarcode
            // 
            this.tsBtnNewBarcode.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNewBarcode.Image")));
            this.tsBtnNewBarcode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNewBarcode.Name = "tsBtnNewBarcode";
            this.tsBtnNewBarcode.Size = new System.Drawing.Size(51, 22);
            this.tsBtnNewBarcode.Text = "New";
            this.tsBtnNewBarcode.Click += new System.EventHandler(this.tsBtnNewBarcode_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Enabled = false;
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(47, 22);
            this.tsbEdit.Text = "Edit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbDeleteBarcode
            // 
            this.tsbDeleteBarcode.Enabled = false;
            this.tsbDeleteBarcode.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteBarcode.Image")));
            this.tsbDeleteBarcode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteBarcode.Name = "tsbDeleteBarcode";
            this.tsbDeleteBarcode.Size = new System.Drawing.Size(60, 22);
            this.tsbDeleteBarcode.Text = "Delete";
            this.tsbDeleteBarcode.Click += new System.EventHandler(this.tsbDeleteBarcode_Click);
            // 
            // dgvBarcode
            // 
            this.dgvBarcode.AllowUserToAddRows = false;
            this.dgvBarcode.AllowUserToDeleteRows = false;
            this.dgvBarcode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBarcode.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvBarcode.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarcode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvBarcode.Location = new System.Drawing.Point(3, 46);
            this.dgvBarcode.MultiSelect = false;
            this.dgvBarcode.Name = "dgvBarcode";
            this.dgvBarcode.ReadOnly = true;
            this.dgvBarcode.RowHeadersVisible = false;
            this.dgvBarcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarcode.Size = new System.Drawing.Size(930, 236);
            this.dgvBarcode.TabIndex = 0;
            this.dgvBarcode.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBarcode_CellClick);
            this.dgvBarcode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBarcode_CellContentClick);
            this.dgvBarcode.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBarcode_CellDoubleClick);
            this.dgvBarcode.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBarcode_CellValueChanged);
            this.dgvBarcode.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvBarcode_DataBindingComplete);
            // 
            // lblProdDetails
            // 
            this.lblProdDetails.AutoSize = true;
            this.lblProdDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblProdDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProdDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdDetails.Image = global::ACP.Properties.Resources.arrowRight10px;
            this.lblProdDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProdDetails.Location = new System.Drawing.Point(0, 0);
            this.lblProdDetails.Name = "lblProdDetails";
            this.lblProdDetails.Size = new System.Drawing.Size(114, 15);
            this.lblProdDetails.TabIndex = 11;
            this.lblProdDetails.Text = "    2 Product Details";
            this.lblProdDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProdDetails.Click += new System.EventHandler(this.lblProdDetails_Click);
            this.lblProdDetails.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblProdDetails_MouseDown);
            // 
            // pFinancials
            // 
            this.pFinancials.BackColor = System.Drawing.Color.White;
            this.pFinancials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFinancials.Controls.Add(this.label56);
            this.pFinancials.Controls.Add(this.cbSalesTax);
            this.pFinancials.Controls.Add(this.label48);
            this.pFinancials.Controls.Add(this.cbPurchaseTax);
            this.pFinancials.Controls.Add(this.label52);
            this.pFinancials.Controls.Add(this.label53);
            this.pFinancials.Controls.Add(this.label54);
            this.pFinancials.Controls.Add(this.cbItemGroup);
            this.pFinancials.Controls.Add(this.lblFinancials);
            this.pFinancials.Location = new System.Drawing.Point(3, 369);
            this.pFinancials.MaximumSize = new System.Drawing.Size(955, 130);
            this.pFinancials.MinimumSize = new System.Drawing.Size(854, 20);
            this.pFinancials.Name = "pFinancials";
            this.pFinancials.Size = new System.Drawing.Size(950, 20);
            this.pFinancials.TabIndex = 32;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(290, 25);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(125, 15);
            this.label56.TabIndex = 32;
            this.label56.Text = "Item Sales Tax Group";
            // 
            // cbSalesTax
            // 
            this.cbSalesTax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSalesTax.FormattingEnabled = true;
            this.cbSalesTax.Items.AddRange(new object[] {
            "IVAT"});
            this.cbSalesTax.Location = new System.Drawing.Point(400, 79);
            this.cbSalesTax.Name = "cbSalesTax";
            this.cbSalesTax.Size = new System.Drawing.Size(123, 23);
            this.cbSalesTax.TabIndex = 32;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(291, 80);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(55, 15);
            this.label48.TabIndex = 30;
            this.label48.Text = "Sales tax:";
            // 
            // cbPurchaseTax
            // 
            this.cbPurchaseTax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPurchaseTax.FormattingEnabled = true;
            this.cbPurchaseTax.Items.AddRange(new object[] {
            "OVAT"});
            this.cbPurchaseTax.Location = new System.Drawing.Point(400, 46);
            this.cbPurchaseTax.Name = "cbPurchaseTax";
            this.cbPurchaseTax.Size = new System.Drawing.Size(123, 23);
            this.cbPurchaseTax.TabIndex = 31;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(12, 28);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(75, 15);
            this.label52.TabIndex = 23;
            this.label52.Text = "Cost Posting";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(290, 50);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(77, 15);
            this.label53.TabIndex = 22;
            this.label53.Text = "Purchase tax:";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(12, 53);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(69, 15);
            this.label54.TabIndex = 21;
            this.label54.Text = "Item group:";
            // 
            // cbItemGroup
            // 
            this.cbItemGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbItemGroup.FormattingEnabled = true;
            this.cbItemGroup.Location = new System.Drawing.Point(98, 50);
            this.cbItemGroup.Name = "cbItemGroup";
            this.cbItemGroup.Size = new System.Drawing.Size(123, 23);
            this.cbItemGroup.TabIndex = 30;
            // 
            // lblFinancials
            // 
            this.lblFinancials.AutoSize = true;
            this.lblFinancials.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFinancials.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFinancials.Enabled = false;
            this.lblFinancials.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinancials.Image = global::ACP.Properties.Resources.arrowRight10px;
            this.lblFinancials.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFinancials.Location = new System.Drawing.Point(0, 0);
            this.lblFinancials.Name = "lblFinancials";
            this.lblFinancials.Size = new System.Drawing.Size(81, 15);
            this.lblFinancials.TabIndex = 29;
            this.lblFinancials.Text = "    3 Financials";
            this.lblFinancials.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFinancials.Click += new System.EventHandler(this.lblFinancials_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 626);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(987, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(30, 17);
            this.toolStripStatusLabel1.Text = "User";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel2.Text = "Date";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel3.Text = "Status";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(987, 10);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(987, 88);
            this.panel3.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnKitSetup);
            this.panel4.Controls.Add(this.btnBrand);
            this.panel4.Controls.Add(this.btnOtherPrice);
            this.panel4.Controls.Add(this.button7);
            this.panel4.Controls.Add(this.btnCatHierarchy);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(202, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(335, 88);
            this.panel4.TabIndex = 3;
            // 
            // btnKitSetup
            // 
            this.btnKitSetup.Enabled = false;
            this.btnKitSetup.FlatAppearance.BorderSize = 0;
            this.btnKitSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKitSetup.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKitSetup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnKitSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnKitSetup.Image")));
            this.btnKitSetup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnKitSetup.Location = new System.Drawing.Point(250, -1);
            this.btnKitSetup.Margin = new System.Windows.Forms.Padding(0);
            this.btnKitSetup.Name = "btnKitSetup";
            this.btnKitSetup.Size = new System.Drawing.Size(82, 70);
            this.btnKitSetup.TabIndex = 10;
            this.btnKitSetup.Text = "Kit component";
            this.btnKitSetup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKitSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKitSetup.UseVisualStyleBackColor = true;
            this.btnKitSetup.Click += new System.EventHandler(this.btnKitSetup_Click);
            // 
            // btnBrand
            // 
            this.btnBrand.FlatAppearance.BorderSize = 0;
            this.btnBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrand.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrand.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrand.Image = ((System.Drawing.Image)(resources.GetObject("btnBrand.Image")));
            this.btnBrand.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBrand.Location = new System.Drawing.Point(2, -1);
            this.btnBrand.Margin = new System.Windows.Forms.Padding(0);
            this.btnBrand.Name = "btnBrand";
            this.btnBrand.Size = new System.Drawing.Size(63, 70);
            this.btnBrand.TabIndex = 9;
            this.btnBrand.Text = "Brand";
            this.btnBrand.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBrand.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBrand.UseVisualStyleBackColor = true;
            // 
            // btnOtherPrice
            // 
            this.btnOtherPrice.FlatAppearance.BorderSize = 0;
            this.btnOtherPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOtherPrice.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtherPrice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOtherPrice.Image = ((System.Drawing.Image)(resources.GetObject("btnOtherPrice.Image")));
            this.btnOtherPrice.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOtherPrice.Location = new System.Drawing.Point(190, -1);
            this.btnOtherPrice.Margin = new System.Windows.Forms.Padding(0);
            this.btnOtherPrice.Name = "btnOtherPrice";
            this.btnOtherPrice.Size = new System.Drawing.Size(60, 70);
            this.btnOtherPrice.TabIndex = 8;
            this.btnOtherPrice.Text = "Other price";
            this.btnOtherPrice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOtherPrice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOtherPrice.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button7.Location = new System.Drawing.Point(130, -1);
            this.button7.Margin = new System.Windows.Forms.Padding(0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(60, 70);
            this.button7.TabIndex = 7;
            this.button7.Text = "Unit of measure";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // btnCatHierarchy
            // 
            this.btnCatHierarchy.FlatAppearance.BorderSize = 0;
            this.btnCatHierarchy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatHierarchy.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatHierarchy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCatHierarchy.Image = ((System.Drawing.Image)(resources.GetObject("btnCatHierarchy.Image")));
            this.btnCatHierarchy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCatHierarchy.Location = new System.Drawing.Point(67, -1);
            this.btnCatHierarchy.Margin = new System.Windows.Forms.Padding(0);
            this.btnCatHierarchy.Name = "btnCatHierarchy";
            this.btnCatHierarchy.Size = new System.Drawing.Size(63, 70);
            this.btnCatHierarchy.TabIndex = 3;
            this.btnCatHierarchy.Text = "Product Hierarchy";
            this.btnCatHierarchy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCatHierarchy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCatHierarchy.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(140, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Setup";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.btnDelete);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(103, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(99, 88);
            this.panel6.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(5, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 55);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Save as Draft";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(29, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Action";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.btnNewBarcode);
            this.panel7.Controls.Add(this.label17);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(103, 88);
            this.panel7.TabIndex = 0;
            // 
            // btnNewBarcode
            // 
            this.btnNewBarcode.FlatAppearance.BorderSize = 0;
            this.btnNewBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewBarcode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewBarcode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNewBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnNewBarcode.Image")));
            this.btnNewBarcode.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNewBarcode.Location = new System.Drawing.Point(1, 3);
            this.btnNewBarcode.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewBarcode.Name = "btnNewBarcode";
            this.btnNewBarcode.Size = new System.Drawing.Size(95, 58);
            this.btnNewBarcode.TabIndex = 1;
            this.btnNewBarcode.Text = "Product details";
            this.btnNewBarcode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNewBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewBarcode.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(32, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "New";
            // 
            // tsbView
            // 
            this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
            this.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(89, 22);
            this.tsbView.Text = "View details";
            this.tsbView.Click += new System.EventHandler(this.tsbView_Click);
            // 
            // frmModifyProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(987, 648);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCreate);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModifyProd";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModifyProd_FormClosing);
            this.Load += new System.EventHandler(this.frmModifyProd_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pGeneral.ResumeLayout(false);
            this.pGeneral.PerformLayout();
            this.pProdCategory.ResumeLayout(false);
            this.pProdCategory.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode)).EndInit();
            this.pFinancials.ResumeLayout(false);
            this.pFinancials.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtProdName;
        public System.Windows.Forms.TextBox txtSKU;
        public System.Windows.Forms.ComboBox cbSalesTax;
        public System.Windows.Forms.ComboBox cbPurchaseTax;
        public System.Windows.Forms.ComboBox cbItemGroup;
        public System.Windows.Forms.ComboBox cmbProdType;
        public System.Windows.Forms.ComboBox cmbProdSubType;
        public System.Windows.Forms.CheckBox cbConcession;
        public System.Windows.Forms.CheckBox cbSKU;
        public System.Windows.Forms.Label lblGeneral;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Panel pGeneral;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Panel pProdCategory;
        public System.Windows.Forms.Label lblProdDetails;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        public System.Windows.Forms.Panel pFinancials;
        public System.Windows.Forms.Label label56;
        public System.Windows.Forms.Label label48;
        public System.Windows.Forms.Label label52;
        public System.Windows.Forms.Label label53;
        public System.Windows.Forms.Label label54;
        public System.Windows.Forms.Label lblFinancials;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsBtnNewBarcode;
        private System.Windows.Forms.ToolStripButton tsbDeleteBarcode;
        public System.Windows.Forms.DataGridView dgvBarcode;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status;
        public System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtCategory;
        public System.Windows.Forms.TextBox txtSupplier;
        public System.Windows.Forms.TextBox txtDepartment;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.ComboBox cmbProdDimension;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnKitSetup;
        private System.Windows.Forms.Button btnBrand;
        private System.Windows.Forms.Button btnOtherPrice;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnCatHierarchy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnNewBarcode;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbView;
    }
}