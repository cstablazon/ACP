namespace ACP
{
    partial class frmReports
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.sp_reportPOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPurchaseOrder = new ACP.dsPurchaseOrder();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReview = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbRetailPrice = new System.Windows.Forms.CheckBox();
            this.cbCostPrice = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sp_reportPOTableAdapter = new ACP.dsPurchaseOrderTableAdapters.sp_reportPOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_reportPOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPurchaseOrder)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // sp_reportPOBindingSource
            // 
            this.sp_reportPOBindingSource.DataMember = "sp_reportPO";
            this.sp_reportPOBindingSource.DataSource = this.dsPurchaseOrder;
            // 
            // dsPurchaseOrder
            // 
            this.dsPurchaseOrder.DataSetName = "dsPurchaseOrder";
            this.dsPurchaseOrder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "costPrice";
            reportDataSource1.Value = this.sp_reportPOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ACP.reportPOcostPrice.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 58);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1076, 471);
            this.reportViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(473, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 35);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cost price:";
            // 
            // btnReview
            // 
            this.btnReview.Location = new System.Drawing.Point(203, 20);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(75, 23);
            this.btnReview.TabIndex = 5;
            this.btnReview.Text = "Preview";
            this.btnReview.UseVisualStyleBackColor = true;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Retail price:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 10);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbRetailPrice);
            this.panel3.Controls.Add(this.cbCostPrice);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnReview);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1076, 48);
            this.panel3.TabIndex = 9;
            // 
            // cbRetailPrice
            // 
            this.cbRetailPrice.AutoSize = true;
            this.cbRetailPrice.Location = new System.Drawing.Point(182, 25);
            this.cbRetailPrice.Name = "cbRetailPrice";
            this.cbRetailPrice.Size = new System.Drawing.Size(15, 14);
            this.cbRetailPrice.TabIndex = 8;
            this.cbRetailPrice.UseVisualStyleBackColor = true;
            this.cbRetailPrice.CheckedChanged += new System.EventHandler(this.cbRetailPrice_CheckedChanged);
            // 
            // cbCostPrice
            // 
            this.cbCostPrice.AutoSize = true;
            this.cbCostPrice.Location = new System.Drawing.Point(74, 25);
            this.cbCostPrice.Name = "cbCostPrice";
            this.cbCostPrice.Size = new System.Drawing.Size(15, 14);
            this.cbCostPrice.TabIndex = 7;
            this.cbCostPrice.UseVisualStyleBackColor = true;
            this.cbCostPrice.CheckedChanged += new System.EventHandler(this.cbCostPrice_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Parameters";
            // 
            // sp_reportPOTableAdapter
            // 
            this.sp_reportPOTableAdapter.ClearBeforeFill = true;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 529);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmReports";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_reportPOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPurchaseOrder)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbRetailPrice;
        private System.Windows.Forms.CheckBox cbCostPrice;
        private System.Windows.Forms.BindingSource sp_reportPOBindingSource;
        private dsPurchaseOrder dsPurchaseOrder;
        private dsPurchaseOrderTableAdapters.sp_reportPOTableAdapter sp_reportPOTableAdapter;
    }
}