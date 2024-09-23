namespace ACP
{
    partial class frmAddOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOder = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnApproval = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pline1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pLine = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNewProd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabMange = new System.Windows.Forms.TabPage();
            this.tabRecieve = new System.Windows.Forms.TabPage();
            this.tabInvoce = new System.Windows.Forms.TabPage();
            this.tabRetail = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.dtpEntry = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSuppID = new System.Windows.Forms.TextBox();
            this.cmbDeliveryAdd = new System.Windows.Forms.ComboBox();
            this.txtPayTerm = new System.Windows.Forms.TextBox();
            this.rtxtRemarks = new System.Windows.Forms.RichTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.cmbCheckedBy = new System.Windows.Forms.ComboBox();
            this.cmbApprovedBy = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cmbOrderBy = new System.Windows.Forms.ComboBox();
            this.cmbEncodedBy = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.rtxtAddress = new System.Windows.Forms.RichTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbMOD = new System.Windows.Forms.ComboBox();
            this.dtpCancel = new System.Windows.Forms.DateTimePicker();
            this.dtpDelivery = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPoolDesc = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbPool = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbDiscount = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAgent = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPOtype = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pLines = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAddLine = new System.Windows.Forms.ToolStripButton();
            this.tsbAddLines = new System.Windows.Forms.ToolStripButton();
            this.tsbAddProd = new System.Windows.Forms.ToolStripButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.lineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.retailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineDisc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLines = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabOder.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.pLines.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 7;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 10);
            this.panel1.TabIndex = 1;
            // 
            // tabPanel
            // 
            this.tabPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.tabPanel.Controls.Add(this.tabControl1);
            this.tabPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPanel.Location = new System.Drawing.Point(0, 10);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.Size = new System.Drawing.Size(1111, 121);
            this.tabPanel.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOder);
            this.tabControl1.Controls.Add(this.tabMange);
            this.tabControl1.Controls.Add(this.tabRecieve);
            this.tabControl1.Controls.Add(this.tabInvoce);
            this.tabControl1.Controls.Add(this.tabRetail);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1111, 121);
            this.tabControl1.TabIndex = 0;
            // 
            // tabOder
            // 
            this.tabOder.BackColor = System.Drawing.SystemColors.Control;
            this.tabOder.Controls.Add(this.panel4);
            this.tabOder.Controls.Add(this.panel5);
            this.tabOder.Controls.Add(this.pline1);
            this.tabOder.Controls.Add(this.panel3);
            this.tabOder.Controls.Add(this.pLine);
            this.tabOder.Controls.Add(this.panel2);
            this.tabOder.Location = new System.Drawing.Point(4, 22);
            this.tabOder.Name = "tabOder";
            this.tabOder.Padding = new System.Windows.Forms.Padding(3);
            this.tabOder.Size = new System.Drawing.Size(1103, 95);
            this.tabOder.TabIndex = 0;
            this.tabOder.Text = "Order";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(453, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(3, 89);
            this.panel4.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnApproval);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(280, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(173, 89);
            this.panel5.TabIndex = 4;
            // 
            // btnApproval
            // 
            this.btnApproval.FlatAppearance.BorderSize = 0;
            this.btnApproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproval.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproval.Image = ((System.Drawing.Image)(resources.GetObject("btnApproval.Image")));
            this.btnApproval.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnApproval.Location = new System.Drawing.Point(3, 3);
            this.btnApproval.Margin = new System.Windows.Forms.Padding(0);
            this.btnApproval.Name = "btnApproval";
            this.btnApproval.Size = new System.Drawing.Size(79, 58);
            this.btnApproval.TabIndex = 4;
            this.btnApproval.Text = "Submit for approval";
            this.btnApproval.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnApproval.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnApproval.UseVisualStyleBackColor = true;
            this.btnApproval.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Generate";
            // 
            // pline1
            // 
            this.pline1.BackColor = System.Drawing.Color.LightGray;
            this.pline1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pline1.Location = new System.Drawing.Point(277, 3);
            this.pline1.Name = "pline1";
            this.pline1.Size = new System.Drawing.Size(3, 89);
            this.pline1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(172, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(105, 89);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Show";
            // 
            // pLine
            // 
            this.pLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLine.Location = new System.Drawing.Point(169, 3);
            this.pLine.Name = "pLine";
            this.pLine.Size = new System.Drawing.Size(3, 89);
            this.pLine.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNewProd);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 89);
            this.panel2.TabIndex = 0;
            // 
            // btnNewProd
            // 
            this.btnNewProd.FlatAppearance.BorderSize = 0;
            this.btnNewProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewProd.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewProd.Image = ((System.Drawing.Image)(resources.GetObject("btnNewProd.Image")));
            this.btnNewProd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNewProd.Location = new System.Drawing.Point(1, 3);
            this.btnNewProd.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewProd.Name = "btnNewProd";
            this.btnNewProd.Size = new System.Drawing.Size(79, 58);
            this.btnNewProd.TabIndex = 3;
            this.btnNewProd.Text = "Recalculate prices";
            this.btnNewProd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNewProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewProd.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Maintain";
            // 
            // tabMange
            // 
            this.tabMange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.tabMange.Location = new System.Drawing.Point(4, 22);
            this.tabMange.Name = "tabMange";
            this.tabMange.Padding = new System.Windows.Forms.Padding(3);
            this.tabMange.Size = new System.Drawing.Size(1103, 95);
            this.tabMange.TabIndex = 1;
            this.tabMange.Text = "Manage";
            // 
            // tabRecieve
            // 
            this.tabRecieve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.tabRecieve.Location = new System.Drawing.Point(4, 22);
            this.tabRecieve.Name = "tabRecieve";
            this.tabRecieve.Size = new System.Drawing.Size(1103, 95);
            this.tabRecieve.TabIndex = 2;
            this.tabRecieve.Text = "Receive";
            // 
            // tabInvoce
            // 
            this.tabInvoce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.tabInvoce.Location = new System.Drawing.Point(4, 22);
            this.tabInvoce.Name = "tabInvoce";
            this.tabInvoce.Size = new System.Drawing.Size(1103, 95);
            this.tabInvoce.TabIndex = 3;
            this.tabInvoce.Text = "Invoice";
            // 
            // tabRetail
            // 
            this.tabRetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.tabRetail.Location = new System.Drawing.Point(4, 22);
            this.tabRetail.Name = "tabRetail";
            this.tabRetail.Size = new System.Drawing.Size(1103, 95);
            this.tabRetail.TabIndex = 4;
            this.tabRetail.Text = "Retail";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 131);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1111, 2);
            this.panel7.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pHeader);
            this.flowLayoutPanel1.Controls.Add(this.pLines);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 133);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1111, 464);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // pHeader
            // 
            this.pHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pHeader.Controls.Add(this.dtpEntry);
            this.pHeader.Controls.Add(this.label1);
            this.pHeader.Controls.Add(this.txtSuppID);
            this.pHeader.Controls.Add(this.cmbDeliveryAdd);
            this.pHeader.Controls.Add(this.txtPayTerm);
            this.pHeader.Controls.Add(this.rtxtRemarks);
            this.pHeader.Controls.Add(this.label31);
            this.pHeader.Controls.Add(this.cmbCheckedBy);
            this.pHeader.Controls.Add(this.cmbApprovedBy);
            this.pHeader.Controls.Add(this.label30);
            this.pHeader.Controls.Add(this.label29);
            this.pHeader.Controls.Add(this.label28);
            this.pHeader.Controls.Add(this.cmbOrderBy);
            this.pHeader.Controls.Add(this.cmbEncodedBy);
            this.pHeader.Controls.Add(this.label32);
            this.pHeader.Controls.Add(this.label33);
            this.pHeader.Controls.Add(this.cmbDepartment);
            this.pHeader.Controls.Add(this.label34);
            this.pHeader.Controls.Add(this.label35);
            this.pHeader.Controls.Add(this.rtxtAddress);
            this.pHeader.Controls.Add(this.label23);
            this.pHeader.Controls.Add(this.cmbMOD);
            this.pHeader.Controls.Add(this.dtpCancel);
            this.pHeader.Controls.Add(this.dtpDelivery);
            this.pHeader.Controls.Add(this.label22);
            this.pHeader.Controls.Add(this.label21);
            this.pHeader.Controls.Add(this.label20);
            this.pHeader.Controls.Add(this.label19);
            this.pHeader.Controls.Add(this.txtPoolDesc);
            this.pHeader.Controls.Add(this.label25);
            this.pHeader.Controls.Add(this.cmbPool);
            this.pHeader.Controls.Add(this.label26);
            this.pHeader.Controls.Add(this.label27);
            this.pHeader.Controls.Add(this.textBox5);
            this.pHeader.Controls.Add(this.label15);
            this.pHeader.Controls.Add(this.textBox4);
            this.pHeader.Controls.Add(this.label16);
            this.pHeader.Controls.Add(this.cmbDiscount);
            this.pHeader.Controls.Add(this.label17);
            this.pHeader.Controls.Add(this.label18);
            this.pHeader.Controls.Add(this.label10);
            this.pHeader.Controls.Add(this.txtAgent);
            this.pHeader.Controls.Add(this.label11);
            this.pHeader.Controls.Add(this.txtName);
            this.pHeader.Controls.Add(this.label12);
            this.pHeader.Controls.Add(this.label13);
            this.pHeader.Controls.Add(this.label14);
            this.pHeader.Controls.Add(this.txtOrderNo);
            this.pHeader.Controls.Add(this.label8);
            this.pHeader.Controls.Add(this.cmbPOtype);
            this.pHeader.Controls.Add(this.label9);
            this.pHeader.Controls.Add(this.label6);
            this.pHeader.Controls.Add(this.lblHeader);
            this.pHeader.Location = new System.Drawing.Point(3, 3);
            this.pHeader.MaximumSize = new System.Drawing.Size(1111, 380);
            this.pHeader.MinimumSize = new System.Drawing.Size(2, 22);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1086, 368);
            this.pHeader.TabIndex = 0;
            // 
            // dtpEntry
            // 
            this.dtpEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEntry.Location = new System.Drawing.Point(491, 138);
            this.dtpEntry.Name = "dtpEntry";
            this.dtpEntry.Size = new System.Drawing.Size(223, 21);
            this.dtpEntry.TabIndex = 143;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(365, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 142;
            this.label1.Text = "Entry date:";
            // 
            // txtSuppID
            // 
            this.txtSuppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuppID.Location = new System.Drawing.Point(129, 132);
            this.txtSuppID.Name = "txtSuppID";
            this.txtSuppID.Size = new System.Drawing.Size(182, 23);
            this.txtSuppID.TabIndex = 141;
            this.txtSuppID.Click += new System.EventHandler(this.txtSuppID_Click);
            this.txtSuppID.TextChanged += new System.EventHandler(this.txtSuppID_TextChanged);
            this.txtSuppID.Leave += new System.EventHandler(this.txtSuppID_Leave);
            this.txtSuppID.MouseHover += new System.EventHandler(this.txtSuppID_MouseHover);
            // 
            // cmbDeliveryAdd
            // 
            this.cmbDeliveryAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDeliveryAdd.FormattingEnabled = true;
            this.cmbDeliveryAdd.Location = new System.Drawing.Point(491, 219);
            this.cmbDeliveryAdd.Name = "cmbDeliveryAdd";
            this.cmbDeliveryAdd.Size = new System.Drawing.Size(223, 24);
            this.cmbDeliveryAdd.TabIndex = 139;
            this.cmbDeliveryAdd.SelectionChangeCommitted += new System.EventHandler(this.cmbDeliveryAdd_SelectionChangeCommitted);
            this.cmbDeliveryAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDeliveryAdd_KeyPress);
            this.cmbDeliveryAdd.Leave += new System.EventHandler(this.cmbDeliveryAdd_Leave);
            this.cmbDeliveryAdd.MouseHover += new System.EventHandler(this.cmbDeliveryAdd_MouseHover);
            // 
            // txtPayTerm
            // 
            this.txtPayTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayTerm.Location = new System.Drawing.Point(129, 219);
            this.txtPayTerm.Name = "txtPayTerm";
            this.txtPayTerm.ReadOnly = true;
            this.txtPayTerm.Size = new System.Drawing.Size(182, 23);
            this.txtPayTerm.TabIndex = 138;
            this.txtPayTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayTerm_KeyPress);
            // 
            // rtxtRemarks
            // 
            this.rtxtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtRemarks.Location = new System.Drawing.Point(867, 257);
            this.rtxtRemarks.Name = "rtxtRemarks";
            this.rtxtRemarks.Size = new System.Drawing.Size(203, 91);
            this.rtxtRemarks.TabIndex = 137;
            this.rtxtRemarks.Text = "";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label31.Location = new System.Drawing.Point(766, 261);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(61, 17);
            this.label31.TabIndex = 136;
            this.label31.Text = "Remarks:";
            // 
            // cmbCheckedBy
            // 
            this.cmbCheckedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCheckedBy.FormattingEnabled = true;
            this.cmbCheckedBy.Location = new System.Drawing.Point(867, 218);
            this.cmbCheckedBy.Name = "cmbCheckedBy";
            this.cmbCheckedBy.Size = new System.Drawing.Size(203, 24);
            this.cmbCheckedBy.TabIndex = 135;
            // 
            // cmbApprovedBy
            // 
            this.cmbApprovedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbApprovedBy.FormattingEnabled = true;
            this.cmbApprovedBy.Items.AddRange(new object[] {
            "Lao, Sonny Tan"});
            this.cmbApprovedBy.Location = new System.Drawing.Point(867, 181);
            this.cmbApprovedBy.Name = "cmbApprovedBy";
            this.cmbApprovedBy.Size = new System.Drawing.Size(203, 24);
            this.cmbApprovedBy.TabIndex = 134;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label30.Location = new System.Drawing.Point(766, 225);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(78, 17);
            this.label30.TabIndex = 133;
            this.label30.Text = "Checked by:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label29.Location = new System.Drawing.Point(764, 188);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(87, 17);
            this.label29.TabIndex = 132;
            this.label29.Text = "Approved by:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label28.Location = new System.Drawing.Point(762, 159);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(82, 19);
            this.label28.TabIndex = 131;
            this.label28.Text = "Signatories:";
            // 
            // cmbOrderBy
            // 
            this.cmbOrderBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrderBy.FormattingEnabled = true;
            this.cmbOrderBy.Location = new System.Drawing.Point(867, 114);
            this.cmbOrderBy.Name = "cmbOrderBy";
            this.cmbOrderBy.Size = new System.Drawing.Size(203, 24);
            this.cmbOrderBy.TabIndex = 130;
            // 
            // cmbEncodedBy
            // 
            this.cmbEncodedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEncodedBy.FormattingEnabled = true;
            this.cmbEncodedBy.Location = new System.Drawing.Point(867, 83);
            this.cmbEncodedBy.Name = "cmbEncodedBy";
            this.cmbEncodedBy.Size = new System.Drawing.Size(203, 24);
            this.cmbEncodedBy.TabIndex = 129;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label32.Location = new System.Drawing.Point(764, 121);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(79, 17);
            this.label32.TabIndex = 128;
            this.label32.Text = "Ordered by:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label33.Location = new System.Drawing.Point(763, 90);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(80, 17);
            this.label33.TabIndex = 127;
            this.label33.Text = "Encoded by:";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(867, 53);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(203, 24);
            this.cmbDepartment.TabIndex = 126;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label34.Location = new System.Drawing.Point(763, 57);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(80, 17);
            this.label34.TabIndex = 125;
            this.label34.Text = "Department:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label35.Location = new System.Drawing.Point(762, 21);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(105, 19);
            this.label35.TabIndex = 124;
            this.label35.Text = "Administration:";
            // 
            // rtxtAddress
            // 
            this.rtxtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtAddress.Location = new System.Drawing.Point(491, 249);
            this.rtxtAddress.Name = "rtxtAddress";
            this.rtxtAddress.Size = new System.Drawing.Size(223, 121);
            this.rtxtAddress.TabIndex = 123;
            this.rtxtAddress.Text = "";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label23.Location = new System.Drawing.Point(366, 249);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 17);
            this.label23.TabIndex = 122;
            this.label23.Text = "Address:";
            // 
            // cmbMOD
            // 
            this.cmbMOD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMOD.FormattingEnabled = true;
            this.cmbMOD.Location = new System.Drawing.Point(491, 106);
            this.cmbMOD.Name = "cmbMOD";
            this.cmbMOD.Size = new System.Drawing.Size(223, 24);
            this.cmbMOD.TabIndex = 120;
            this.cmbMOD.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            this.cmbMOD.SelectionChangeCommitted += new System.EventHandler(this.cmbMOD_SelectionChangeCommitted);
            this.cmbMOD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMOD_KeyPress);
            this.cmbMOD.Leave += new System.EventHandler(this.cmbMOD_Leave);
            this.cmbMOD.MouseHover += new System.EventHandler(this.cmbMOD_MouseHover);
            // 
            // dtpCancel
            // 
            this.dtpCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCancel.Location = new System.Drawing.Point(491, 192);
            this.dtpCancel.Name = "dtpCancel";
            this.dtpCancel.Size = new System.Drawing.Size(223, 21);
            this.dtpCancel.TabIndex = 119;
            // 
            // dtpDelivery
            // 
            this.dtpDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDelivery.Location = new System.Drawing.Point(491, 165);
            this.dtpDelivery.Name = "dtpDelivery";
            this.dtpDelivery.Size = new System.Drawing.Size(223, 21);
            this.dtpDelivery.TabIndex = 118;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label22.Location = new System.Drawing.Point(366, 222);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(108, 17);
            this.label22.TabIndex = 116;
            this.label22.Text = "Delivery address:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label21.Location = new System.Drawing.Point(366, 114);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(111, 17);
            this.label21.TabIndex = 115;
            this.label21.Text = "Mode of delivery:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label20.Location = new System.Drawing.Point(365, 198);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(111, 17);
            this.label20.TabIndex = 114;
            this.label20.Text = "Cancellation date:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.Location = new System.Drawing.Point(365, 169);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 17);
            this.label19.TabIndex = 113;
            this.label19.Text = "Delivery date:";
            // 
            // txtPoolDesc
            // 
            this.txtPoolDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoolDesc.Location = new System.Drawing.Point(491, 78);
            this.txtPoolDesc.Name = "txtPoolDesc";
            this.txtPoolDesc.ReadOnly = true;
            this.txtPoolDesc.Size = new System.Drawing.Size(223, 23);
            this.txtPoolDesc.TabIndex = 111;
            this.txtPoolDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPoolDesc_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label25.Location = new System.Drawing.Point(365, 84);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(101, 17);
            this.label25.TabIndex = 110;
            this.label25.Text = "Pool desciption:";
            // 
            // cmbPool
            // 
            this.cmbPool.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPool.FormattingEnabled = true;
            this.cmbPool.Location = new System.Drawing.Point(491, 48);
            this.cmbPool.Name = "cmbPool";
            this.cmbPool.Size = new System.Drawing.Size(223, 24);
            this.cmbPool.TabIndex = 109;
            this.cmbPool.SelectedIndexChanged += new System.EventHandler(this.cbPool_SelectedIndexChanged);
            this.cmbPool.SelectionChangeCommitted += new System.EventHandler(this.cmbPool_SelectionChangeCommitted);
            this.cmbPool.SelectedValueChanged += new System.EventHandler(this.cmbPool_SelectedValueChanged);
            this.cmbPool.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPool_KeyPress);
            this.cmbPool.Leave += new System.EventHandler(this.cmbPool_Leave);
            this.cmbPool.MouseHover += new System.EventHandler(this.cmbPool_MouseHover);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label26.Location = new System.Drawing.Point(365, 53);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 17);
            this.label26.TabIndex = 108;
            this.label26.Text = "Pool:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label27.Location = new System.Drawing.Point(364, 23);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 19);
            this.label27.TabIndex = 107;
            this.label27.Text = "Delivery:";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(129, 332);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(182, 23);
            this.textBox5.TabIndex = 106;
            this.textBox5.Text = "0.0";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.Location = new System.Drawing.Point(13, 334);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 17);
            this.label15.TabIndex = 105;
            this.label15.Text = "Total discount %:";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(129, 303);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(182, 23);
            this.textBox4.TabIndex = 104;
            this.textBox4.Text = "0.0";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label16.Location = new System.Drawing.Point(13, 305);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 17);
            this.label16.TabIndex = 103;
            this.label16.Text = "Percentage:";
            // 
            // cmbDiscount
            // 
            this.cmbDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDiscount.FormattingEnabled = true;
            this.cmbDiscount.Location = new System.Drawing.Point(129, 269);
            this.cmbDiscount.Name = "cmbDiscount";
            this.cmbDiscount.Size = new System.Drawing.Size(182, 24);
            this.cmbDiscount.TabIndex = 102;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label17.Location = new System.Drawing.Point(12, 276);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 17);
            this.label17.TabIndex = 101;
            this.label17.Text = "Cash discount:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label18.Location = new System.Drawing.Point(12, 252);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 19);
            this.label18.TabIndex = 100;
            this.label18.Text = "Discount:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(12, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 17);
            this.label10.TabIndex = 97;
            this.label10.Text = "Payment terms:";
            // 
            // txtAgent
            // 
            this.txtAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgent.Location = new System.Drawing.Point(129, 190);
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.ReadOnly = true;
            this.txtAgent.Size = new System.Drawing.Size(182, 23);
            this.txtAgent.TabIndex = 95;
            this.txtAgent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrincipal_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(13, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 17);
            this.label11.TabIndex = 96;
            this.label11.Text = "Agent:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(129, 161);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(182, 23);
            this.txtName.TabIndex = 93;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Location = new System.Drawing.Point(12, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 17);
            this.label12.TabIndex = 92;
            this.label12.Text = "Supplier account:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(12, 167);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 17);
            this.label13.TabIndex = 94;
            this.label13.Text = "Name:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Location = new System.Drawing.Point(10, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 19);
            this.label14.TabIndex = 91;
            this.label14.Text = "Vendor:";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrderNo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNo.ForeColor = System.Drawing.Color.Crimson;
            this.txtOrderNo.Location = new System.Drawing.Point(129, 45);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(182, 22);
            this.txtOrderNo.TabIndex = 88;
            this.txtOrderNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderNo_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(12, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 17);
            this.label8.TabIndex = 87;
            this.label8.Text = "Order:";
            // 
            // cmbPOtype
            // 
            this.cmbPOtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPOtype.FormattingEnabled = true;
            this.cmbPOtype.Items.AddRange(new object[] {
            "Purchase order",
            "Return order"});
            this.cmbPOtype.Location = new System.Drawing.Point(129, 76);
            this.cmbPOtype.Name = "cmbPOtype";
            this.cmbPOtype.Size = new System.Drawing.Size(182, 24);
            this.cmbPOtype.TabIndex = 90;
            this.cmbPOtype.SelectionChangeCommitted += new System.EventHandler(this.cmbPOtype_SelectionChangeCommitted);
            this.cmbPOtype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPOtype_KeyPress);
            this.cmbPOtype.Leave += new System.EventHandler(this.cmbPOtype_Leave);
            this.cmbPOtype.MouseHover += new System.EventHandler(this.cmbPOtype_MouseHover);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(11, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 89;
            this.label9.Text = "Purchase type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(5, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 19);
            this.label6.TabIndex = 86;
            this.label6.Text = "Purchase Order:";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Image = global::ACP.Properties.Resources.arrowDown10px;
            this.lblHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Location = new System.Drawing.Point(3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(64, 17);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "   Header";
            this.lblHeader.Click += new System.EventHandler(this.lblHeader_Click);
            // 
            // pLines
            // 
            this.pLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pLines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLines.Controls.Add(this.groupBox1);
            this.pLines.Controls.Add(this.lblLines);
            this.pLines.Location = new System.Drawing.Point(3, 377);
            this.pLines.MaximumSize = new System.Drawing.Size(1104, 304);
            this.pLines.MinimumSize = new System.Drawing.Size(2, 22);
            this.pLines.Name = "pLines";
            this.pLines.Size = new System.Drawing.Size(1086, 22);
            this.pLines.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.dgvLines);
            this.groupBox1.Location = new System.Drawing.Point(6, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1070, 271);
            this.groupBox1.TabIndex = 139;
            this.groupBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddLine,
            this.tsbAddLines,
            this.tsbAddProd,
            this.tsbRemove});
            this.toolStrip1.Location = new System.Drawing.Point(3, 18);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1064, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAddLine
            // 
            this.tsbAddLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddLine.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddLine.Image")));
            this.tsbAddLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddLine.Name = "tsbAddLine";
            this.tsbAddLine.Size = new System.Drawing.Size(55, 22);
            this.tsbAddLine.Text = "Add line";
            this.tsbAddLine.Click += new System.EventHandler(this.tsbAddLine_Click);
            // 
            // tsbAddLines
            // 
            this.tsbAddLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddLines.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddLines.Image")));
            this.tsbAddLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddLines.Name = "tsbAddLines";
            this.tsbAddLines.Size = new System.Drawing.Size(60, 22);
            this.tsbAddLines.Text = "Add lines";
            this.tsbAddLines.Click += new System.EventHandler(this.tsbAddLines_Click);
            // 
            // tsbAddProd
            // 
            this.tsbAddProd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddProd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddProd.Image")));
            this.tsbAddProd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddProd.Name = "tsbAddProd";
            this.tsbAddProd.Size = new System.Drawing.Size(83, 22);
            this.tsbAddProd.Text = "Add products";
            this.tsbAddProd.Visible = false;
            // 
            // tsbRemove
            // 
            this.tsbRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemove.Image")));
            this.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Size = new System.Drawing.Size(54, 22);
            this.tsbRemove.Text = "Remove";
            this.tsbRemove.Click += new System.EventHandler(this.tsbRemove_Click);
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.AllowUserToResizeColumns = false;
            this.dgvLines.AllowUserToResizeRows = false;
            this.dgvLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLines.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLines.BackgroundColor = System.Drawing.Color.White;
            this.dgvLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lineID,
            this.barcode,
            this.productDesc,
            this.qty,
            this.department,
            this.po_unit,
            this.po_price,
            this.retailPrice,
            this.lineDisc,
            this.netAmount});
            this.dgvLines.Location = new System.Drawing.Point(5, 52);
            this.dgvLines.MultiSelect = false;
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.Size = new System.Drawing.Size(1058, 209);
            this.dgvLines.TabIndex = 3;
            this.dgvLines.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLines_CellClick);
            this.dgvLines.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLines_CellValueChanged);
            this.dgvLines.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvLines_EditingControlShowing);
            // 
            // lineID
            // 
            this.lineID.HeaderText = "Line ID";
            this.lineID.Name = "lineID";
            // 
            // barcode
            // 
            this.barcode.HeaderText = "Barcode";
            this.barcode.Name = "barcode";
            this.barcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // productDesc
            // 
            this.productDesc.HeaderText = "Product description";
            this.productDesc.Name = "productDesc";
            // 
            // qty
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = ".00";
            this.qty.DefaultCellStyle = dataGridViewCellStyle1;
            this.qty.HeaderText = "Quantity";
            this.qty.Name = "qty";
            // 
            // department
            // 
            this.department.HeaderText = "Department";
            this.department.Name = "department";
            // 
            // po_unit
            // 
            this.po_unit.HeaderText = "Unit";
            this.po_unit.Name = "po_unit";
            // 
            // po_price
            // 
            this.po_price.HeaderText = "Unit price";
            this.po_price.Name = "po_price";
            // 
            // retailPrice
            // 
            this.retailPrice.HeaderText = "Retail price";
            this.retailPrice.Name = "retailPrice";
            // 
            // lineDisc
            // 
            this.lineDisc.HeaderText = "Discount percent";
            this.lineDisc.Name = "lineDisc";
            // 
            // netAmount
            // 
            this.netAmount.HeaderText = "Net amount";
            this.netAmount.Name = "netAmount";
            // 
            // lblLines
            // 
            this.lblLines.AutoSize = true;
            this.lblLines.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLines.Image = global::ACP.Properties.Resources.arrowRight10px;
            this.lblLines.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLines.Location = new System.Drawing.Point(2, 1);
            this.lblLines.Name = "lblLines";
            this.lblLines.Size = new System.Drawing.Size(50, 17);
            this.lblLines.TabIndex = 138;
            this.lblLines.Text = "   Lines";
            this.lblLines.Click += new System.EventHandler(this.lblLines_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnCreate);
            this.panel6.Controls.Add(this.btnClose);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 606);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1111, 40);
            this.panel6.TabIndex = 8;
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
            this.btnCreate.Location = new System.Drawing.Point(914, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(83, 30);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "  Create";
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
            this.btnClose.Location = new System.Drawing.Point(1003, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = " Cancel";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // frmAddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1111, 646);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.tabPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(243, 30);
            this.MaximizeBox = false;
            this.Name = "frmAddOrder";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddOrder_Load);
            this.tabPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabOder.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pLines.ResumeLayout(false);
            this.pLines.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel tabPanel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOder;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnApproval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pline1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pLine;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNewProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabMange;
        private System.Windows.Forms.TabPage tabRecieve;
        private System.Windows.Forms.TabPage tabInvoce;
        private System.Windows.Forms.TabPage tabRetail;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbDiscount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cmbCheckedBy;
        private System.Windows.Forms.ComboBox cmbApprovedBy;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cmbOrderBy;
        private System.Windows.Forms.ComboBox cmbEncodedBy;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Panel pLines;
        private System.Windows.Forms.Label lblLines;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAddLines;
        private System.Windows.Forms.ToolStripButton tsbAddProd;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripButton tsbAddLine;
        public System.Windows.Forms.ComboBox cmbPOtype;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.DataGridView dgvLines;
        public System.Windows.Forms.TextBox txtAgent;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtOrderNo;
        public System.Windows.Forms.RichTextBox rtxtAddress;
        public System.Windows.Forms.ComboBox cmbMOD;
        public System.Windows.Forms.DateTimePicker dtpCancel;
        public System.Windows.Forms.DateTimePicker dtpDelivery;
        public System.Windows.Forms.TextBox txtPoolDesc;
        public System.Windows.Forms.ComboBox cmbPool;
        public System.Windows.Forms.RichTextBox rtxtRemarks;
        public System.Windows.Forms.TextBox txtPayTerm;
        public System.Windows.Forms.ComboBox cmbDeliveryAdd;
        public System.Windows.Forms.TextBox txtSuppID;
        public System.Windows.Forms.DateTimePicker dtpEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn department;
        private System.Windows.Forms.DataGridViewTextBoxColumn po_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn po_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn retailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineDisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn netAmount;
    }
}