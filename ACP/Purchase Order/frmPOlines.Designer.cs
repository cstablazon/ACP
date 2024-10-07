namespace ACP
{
    partial class frmPOlines
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOlines));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpExistItems = new System.Windows.Forms.TabPage();
            this.dgvExistItems = new System.Windows.Forms.DataGridView();
            this.tpNewItems = new System.Windows.Forms.TabPage();
            this.dgvNewItems = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpExistItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistItems)).BeginInit();
            this.tpNewItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewItems)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(15, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 427);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpExistItems);
            this.tabControl1.Controls.Add(this.tpNewItems);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(586, 406);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tpExistItems
            // 
            this.tpExistItems.Controls.Add(this.dgvExistItems);
            this.tpExistItems.Location = new System.Drawing.Point(4, 24);
            this.tpExistItems.Name = "tpExistItems";
            this.tpExistItems.Padding = new System.Windows.Forms.Padding(3);
            this.tpExistItems.Size = new System.Drawing.Size(578, 378);
            this.tpExistItems.TabIndex = 0;
            this.tpExistItems.Text = "Existing items";
            this.tpExistItems.UseVisualStyleBackColor = true;
            // 
            // dgvExistItems
            // 
            this.dgvExistItems.AllowUserToAddRows = false;
            this.dgvExistItems.AllowUserToDeleteRows = false;
            this.dgvExistItems.AllowUserToResizeColumns = false;
            this.dgvExistItems.AllowUserToResizeRows = false;
            this.dgvExistItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvExistItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvExistItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvExistItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvExistItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExistItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExistItems.Location = new System.Drawing.Point(3, 3);
            this.dgvExistItems.MultiSelect = false;
            this.dgvExistItems.Name = "dgvExistItems";
            this.dgvExistItems.ReadOnly = true;
            this.dgvExistItems.RowHeadersVisible = false;
            this.dgvExistItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExistItems.Size = new System.Drawing.Size(572, 372);
            this.dgvExistItems.TabIndex = 5;
            this.dgvExistItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvExistItems_CellFormatting);
            // 
            // tpNewItems
            // 
            this.tpNewItems.Controls.Add(this.dgvNewItems);
            this.tpNewItems.Location = new System.Drawing.Point(4, 24);
            this.tpNewItems.Name = "tpNewItems";
            this.tpNewItems.Padding = new System.Windows.Forms.Padding(3);
            this.tpNewItems.Size = new System.Drawing.Size(578, 378);
            this.tpNewItems.TabIndex = 1;
            this.tpNewItems.Text = "New items";
            this.tpNewItems.UseVisualStyleBackColor = true;
            // 
            // dgvNewItems
            // 
            this.dgvNewItems.AllowUserToAddRows = false;
            this.dgvNewItems.AllowUserToDeleteRows = false;
            this.dgvNewItems.AllowUserToResizeColumns = false;
            this.dgvNewItems.AllowUserToResizeRows = false;
            this.dgvNewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvNewItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvNewItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvNewItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNewItems.Location = new System.Drawing.Point(3, 3);
            this.dgvNewItems.Name = "dgvNewItems";
            this.dgvNewItems.RowHeadersVisible = false;
            this.dgvNewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNewItems.Size = new System.Drawing.Size(572, 372);
            this.dgvNewItems.TabIndex = 6;
            this.dgvNewItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jm);
            this.dgvNewItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvNewItems_CellFormatting);
            this.dgvNewItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvNewItems_EditingControlShowing);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Department code:";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(120, 6);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(189, 22);
            this.txtDepartment.TabIndex = 1;
            this.txtDepartment.Click += new System.EventHandler(this.txtDepartment_Click);
            this.txtDepartment.TextChanged += new System.EventHandler(this.txtDepartment_TextChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(315, 6);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
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
            this.btnCreate.Location = new System.Drawing.Point(446, 469);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(83, 30);
            this.btnCreate.TabIndex = 99;
            this.btnCreate.Text = "OK";
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
            this.btnClose.Location = new System.Drawing.Point(535, 469);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 30);
            this.btnClose.TabIndex = 100;
            this.btnClose.Text = " Cancel";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPOlines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 511);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPOlines";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPOlines_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpExistItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistItems)).EndInit();
            this.tpNewItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpExistItems;
        private System.Windows.Forms.DataGridView dgvExistItems;
        private System.Windows.Forms.TabPage tpNewItems;
        public System.Windows.Forms.DataGridView dgvNewItems;
    }
}