namespace ACP
{
    partial class frmKitComponents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKitComponents));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvComponents = new System.Windows.Forms.DataGridView();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsBtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProdDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtUOM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvComponents);
            this.groupBox1.Controls.Add(this.toolStrip3);
            this.groupBox1.Location = new System.Drawing.Point(12, 173);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(630, 338);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Components";
            // 
            // dgvComponents
            // 
            this.dgvComponents.AllowUserToAddRows = false;
            this.dgvComponents.AllowUserToDeleteRows = false;
            this.dgvComponents.AllowUserToResizeColumns = false;
            this.dgvComponents.AllowUserToResizeRows = false;
            this.dgvComponents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComponents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvComponents.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvComponents.Location = new System.Drawing.Point(3, 50);
            this.dgvComponents.MultiSelect = false;
            this.dgvComponents.Name = "dgvComponents";
            this.dgvComponents.RowHeadersVisible = false;
            this.dgvComponents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComponents.Size = new System.Drawing.Size(624, 284);
            this.dgvComponents.TabIndex = 3;
            this.dgvComponents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvComponents_CellFormatting);
            this.dgvComponents.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComponents_CellValueChanged);
            this.dgvComponents.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvComponents_EditingControlShowing);
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNew,
            this.tsbEdit,
            this.tsbDelete});
            this.toolStrip3.Location = new System.Drawing.Point(3, 22);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(624, 25);
            this.toolStrip3.TabIndex = 2;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsBtnNew
            // 
            this.tsBtnNew.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNew.Image")));
            this.tsBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNew.Name = "tsBtnNew";
            this.tsBtnNew.Size = new System.Drawing.Size(51, 22);
            this.tsBtnNew.Text = "New";
            this.tsBtnNew.Click += new System.EventHandler(this.tsBtnNew_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(60, 22);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDeleteBarcode_Click);
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
            this.btnClose.Location = new System.Drawing.Point(563, 57);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 30);
            this.btnClose.TabIndex = 125;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.Enabled = false;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.Location = new System.Drawing.Point(563, 20);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(79, 30);
            this.btnCreate.TabIndex = 124;
            this.btnCreate.Text = "Create";
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtQty);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtUOM);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtProdDesc);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtBarcode);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(15, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 154);
            this.groupBox2.TabIndex = 126;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 126;
            this.label1.Text = "Barcode:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBarcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Location = new System.Drawing.Point(137, 18);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(397, 25);
            this.txtBarcode.TabIndex = 127;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 128;
            this.label2.Text = "Product description:";
            // 
            // txtProdDesc
            // 
            this.txtProdDesc.Enabled = false;
            this.txtProdDesc.Location = new System.Drawing.Point(137, 49);
            this.txtProdDesc.Name = "txtProdDesc";
            this.txtProdDesc.Size = new System.Drawing.Size(397, 25);
            this.txtProdDesc.TabIndex = 129;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 130;
            this.label3.Text = "Quantity:";
            // 
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Location = new System.Drawing.Point(137, 80);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(397, 25);
            this.txtQty.TabIndex = 131;
            this.txtQty.Enter += new System.EventHandler(this.txtDecimal_Enter);
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDecimal_KeyDown);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDecimal_KeyPress);
            // 
            // txtUOM
            // 
            this.txtUOM.Enabled = false;
            this.txtUOM.Location = new System.Drawing.Point(137, 111);
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.Size = new System.Drawing.Size(397, 25);
            this.txtUOM.TabIndex = 132;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 133;
            this.label4.Text = "Unit of measure:";
            // 
            // tsbEdit
            // 
            this.tsbEdit.Enabled = false;
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(47, 22);
            this.tsbEdit.Text = "Edit";
            // 
            // frmKitComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 516);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKitComponents";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kit Components";
            this.Load += new System.EventHandler(this.frmKitComponents_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsBtnNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.DataGridView dgvComponents;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUOM;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProdDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label1;
    }
}