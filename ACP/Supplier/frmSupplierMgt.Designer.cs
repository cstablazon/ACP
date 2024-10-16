namespace ACP
{
    partial class frmSupplierMgt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierMgt));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvSupplier = new System.Windows.Forms.DataGridView();
            this.cmsStatus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsInactiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnContact = new System.Windows.Forms.Button();
            this.btnAddress = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddPrincipal = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSuppDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNewProd = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbSearchFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDisplay = new System.Windows.Forms.ComboBox();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
            this.cmsStatus.SuspendLayout();
            this.header.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvSupplier);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1059, 440);
            this.panel2.TabIndex = 10;
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.AllowUserToAddRows = false;
            this.dgvSupplier.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvSupplier.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSupplier.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvSupplier.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSupplier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplier.ContextMenuStrip = this.cmsStatus;
            this.dgvSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupplier.Location = new System.Drawing.Point(0, 0);
            this.dgvSupplier.MultiSelect = false;
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplier.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSupplier.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSupplier.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupplier.Size = new System.Drawing.Size(1059, 440);
            this.dgvSupplier.TabIndex = 0;
            this.dgvSupplier.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplier_CellClick);
            this.dgvSupplier.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplier_CellContentClick);
            this.dgvSupplier.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplier_CellDoubleClick);
            this.dgvSupplier.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSupplier_CellMouseDown);
            this.dgvSupplier.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSupplier_DataBindingComplete);
            this.dgvSupplier.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvSupplier_Paint);
            // 
            // cmsStatus
            // 
            this.cmsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsActiveToolStripMenuItem,
            this.setAsInactiveToolStripMenuItem});
            this.cmsStatus.Name = "cmsStatus";
            this.cmsStatus.Size = new System.Drawing.Size(149, 48);
            this.cmsStatus.Opening += new System.ComponentModel.CancelEventHandler(this.cmsStatus_Opening);
            // 
            // setAsActiveToolStripMenuItem
            // 
            this.setAsActiveToolStripMenuItem.Name = "setAsActiveToolStripMenuItem";
            this.setAsActiveToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.setAsActiveToolStripMenuItem.Text = "Set as active";
            this.setAsActiveToolStripMenuItem.Click += new System.EventHandler(this.setAsActiveToolStripMenuItem_Click);
            // 
            // setAsInactiveToolStripMenuItem
            // 
            this.setAsInactiveToolStripMenuItem.Name = "setAsInactiveToolStripMenuItem";
            this.setAsInactiveToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.setAsInactiveToolStripMenuItem.Text = "Set as Inactive";
            this.setAsInactiveToolStripMenuItem.Click += new System.EventHandler(this.setAsInactiveToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 2);
            this.panel1.TabIndex = 9;
            // 
            // header
            // 
            this.header.Controls.Add(this.panel5);
            this.header.Controls.Add(this.panel4);
            this.header.Controls.Add(this.panel3);
            this.header.Controls.Add(this.cmbSearchFilter);
            this.header.Controls.Add(this.label1);
            this.header.Controls.Add(this.cmbDisplay);
            this.header.Controls.Add(this.lblDisplay);
            this.header.Controls.Add(this.lblSearch);
            this.header.Controls.Add(this.txtSearch);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1059, 87);
            this.header.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnContact);
            this.panel5.Controls.Add(this.btnAddress);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.btnAddPrincipal);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(352, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(245, 87);
            this.panel5.TabIndex = 41;
            // 
            // btnContact
            // 
            this.btnContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContact.Enabled = false;
            this.btnContact.FlatAppearance.BorderSize = 0;
            this.btnContact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnContact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContact.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContact.ForeColor = System.Drawing.Color.Crimson;
            this.btnContact.Image = ((System.Drawing.Image)(resources.GetObject("btnContact.Image")));
            this.btnContact.Location = new System.Drawing.Point(169, 4);
            this.btnContact.Name = "btnContact";
            this.btnContact.Size = new System.Drawing.Size(65, 56);
            this.btnContact.TabIndex = 45;
            this.btnContact.Text = "Contact";
            this.btnContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnContact.UseVisualStyleBackColor = true;
            this.btnContact.Click += new System.EventHandler(this.btnContact_Click);
            // 
            // btnAddress
            // 
            this.btnAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddress.Enabled = false;
            this.btnAddress.FlatAppearance.BorderSize = 0;
            this.btnAddress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAddress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddress.ForeColor = System.Drawing.Color.Crimson;
            this.btnAddress.Image = ((System.Drawing.Image)(resources.GetObject("btnAddress.Image")));
            this.btnAddress.Location = new System.Drawing.Point(98, 4);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(65, 58);
            this.btnAddress.TabIndex = 41;
            this.btnAddress.Text = "Address";
            this.btnAddress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddress.UseVisualStyleBackColor = true;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(51, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Additional Information";
            // 
            // btnAddPrincipal
            // 
            this.btnAddPrincipal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPrincipal.Enabled = false;
            this.btnAddPrincipal.FlatAppearance.BorderSize = 0;
            this.btnAddPrincipal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAddPrincipal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnAddPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPrincipal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPrincipal.ForeColor = System.Drawing.Color.Crimson;
            this.btnAddPrincipal.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPrincipal.Image")));
            this.btnAddPrincipal.Location = new System.Drawing.Point(5, 4);
            this.btnAddPrincipal.Name = "btnAddPrincipal";
            this.btnAddPrincipal.Size = new System.Drawing.Size(87, 56);
            this.btnAddPrincipal.TabIndex = 44;
            this.btnAddPrincipal.Text = "Principal list";
            this.btnAddPrincipal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddPrincipal.UseVisualStyleBackColor = true;
            this.btnAddPrincipal.Click += new System.EventHandler(this.btnAddPrincipal_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btnSuppDel);
            this.panel4.Controls.Add(this.btnEdit);
            this.panel4.Controls.Add(this.btnRefresh);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(145, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 87);
            this.panel4.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(78, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Actions";
            // 
            // btnSuppDel
            // 
            this.btnSuppDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuppDel.Enabled = false;
            this.btnSuppDel.FlatAppearance.BorderSize = 0;
            this.btnSuppDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnSuppDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSuppDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuppDel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuppDel.ForeColor = System.Drawing.Color.Crimson;
            this.btnSuppDel.Image = ((System.Drawing.Image)(resources.GetObject("btnSuppDel.Image")));
            this.btnSuppDel.Location = new System.Drawing.Point(63, 3);
            this.btnSuppDel.Name = "btnSuppDel";
            this.btnSuppDel.Size = new System.Drawing.Size(60, 56);
            this.btnSuppDel.TabIndex = 39;
            this.btnSuppDel.Text = "\r\nDelete";
            this.btnSuppDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSuppDel.UseVisualStyleBackColor = true;
            this.btnSuppDel.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Crimson;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.Location = new System.Drawing.Point(7, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(50, 56);
            this.btnEdit.TabIndex = 38;
            this.btnEdit.Text = "\r\nEdit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Crimson;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(129, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 56);
            this.btnRefresh.TabIndex = 40;
            this.btnRefresh.Text = "\r\nRefresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnNewProd);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(145, 87);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(51, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "New";
            // 
            // btnNewProd
            // 
            this.btnNewProd.FlatAppearance.BorderSize = 0;
            this.btnNewProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewProd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewProd.ForeColor = System.Drawing.Color.Crimson;
            this.btnNewProd.Image = ((System.Drawing.Image)(resources.GetObject("btnNewProd.Image")));
            this.btnNewProd.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNewProd.Location = new System.Drawing.Point(75, 0);
            this.btnNewProd.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewProd.Name = "btnNewProd";
            this.btnNewProd.Size = new System.Drawing.Size(68, 58);
            this.btnNewProd.TabIndex = 38;
            this.btnNewProd.Text = "Product";
            this.btnNewProd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNewProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewProd.UseVisualStyleBackColor = true;
            this.btnNewProd.Click += new System.EventHandler(this.btnNewProd_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Crimson;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.Location = new System.Drawing.Point(3, 1);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 57);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "Supplier";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // cmbSearchFilter
            // 
            this.cmbSearchFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSearchFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchFilter.FormattingEnabled = true;
            this.cmbSearchFilter.Items.AddRange(new object[] {
            "Supplier ID",
            "Name"});
            this.cmbSearchFilter.Location = new System.Drawing.Point(729, 38);
            this.cmbSearchFilter.Name = "cmbSearchFilter";
            this.cmbSearchFilter.Size = new System.Drawing.Size(121, 25);
            this.cmbSearchFilter.TabIndex = 46;
            this.cmbSearchFilter.SelectionChangeCommitted += new System.EventHandler(this.cmbSearchFilter_SelectionChangeCommitted);
            this.cmbSearchFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSearchFilter_KeyPress);
            this.cmbSearchFilter.MouseHover += new System.EventHandler(this.cmbSearchFilter_MouseHover);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(634, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 23);
            this.label1.TabIndex = 45;
            this.label1.Text = "Search filter:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDisplay
            // 
            this.cmbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDisplay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDisplay.FormattingEnabled = true;
            this.cmbDisplay.Items.AddRange(new object[] {
            "All",
            "Distributor",
            "Principal"});
            this.cmbDisplay.Location = new System.Drawing.Point(930, 38);
            this.cmbDisplay.Name = "cmbDisplay";
            this.cmbDisplay.Size = new System.Drawing.Size(121, 25);
            this.cmbDisplay.TabIndex = 43;
            this.cmbDisplay.SelectedIndexChanged += new System.EventHandler(this.cmbDisplay_SelectedIndexChanged);
            this.cmbDisplay.SelectionChangeCommitted += new System.EventHandler(this.cmbDisplay_SelectionChangeCommitted);
            this.cmbDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDisplay_KeyPress);
            // 
            // lblDisplay
            // 
            this.lblDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDisplay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDisplay.Location = new System.Drawing.Point(853, 38);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(71, 23);
            this.lblDisplay.TabIndex = 42;
            this.lblDisplay.Text = "Display:";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.Crimson;
            this.lblSearch.Image = ((System.Drawing.Image)(resources.GetObject("lblSearch.Image")));
            this.lblSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSearch.Location = new System.Drawing.Point(652, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(71, 23);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(729, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(322, 25);
            this.txtSearch.TabIndex = 41;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmSupplierMgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 529);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSupplierMgt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSupplierMgt_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
            this.cmsStatus.ResumeLayout(false);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSuppDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dgvSupplier;
        private System.Windows.Forms.ContextMenuStrip cmsStatus;
        private System.Windows.Forms.ToolStripMenuItem setAsActiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAsInactiveToolStripMenuItem;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Label lblSearch;
        public System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.ComboBox cmbDisplay;
        public System.Windows.Forms.Label lblDisplay;
        public System.Windows.Forms.Button btnAddPrincipal;
        public System.Windows.Forms.ComboBox cmbSearchFilter;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel header;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNewProd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnContact;
        private System.Windows.Forms.Button btnAddress;
        private System.Windows.Forms.Label label4;
    }
}