namespace ACP
{
    partial class frmTest
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsPurchaseOrder = new ACP.dsPurchaseOrder();
            this.sp_reportPOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_reportPOTableAdapter = new ACP.dsPurchaseOrderTableAdapters.sp_reportPOTableAdapter();
            this.cbRetailPrice = new System.Windows.Forms.CheckBox();
            this.cbCostPrice = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsPurchaseOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_reportPOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sp_reportPOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.Location = new System.Drawing.Point(143, 57);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsPurchaseOrder
            // 
            this.dsPurchaseOrder.DataSetName = "dsPurchaseOrder";
            this.dsPurchaseOrder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_reportPOBindingSource
            // 
            this.sp_reportPOBindingSource.DataMember = "sp_reportPO";
            this.sp_reportPOBindingSource.DataSource = this.dsPurchaseOrder;
            // 
            // sp_reportPOTableAdapter
            // 
            this.sp_reportPOTableAdapter.ClearBeforeFill = true;
            // 
            // cbRetailPrice
            // 
            this.cbRetailPrice.AutoSize = true;
            this.cbRetailPrice.Location = new System.Drawing.Point(393, 17);
            this.cbRetailPrice.Name = "cbRetailPrice";
            this.cbRetailPrice.Size = new System.Drawing.Size(15, 14);
            this.cbRetailPrice.TabIndex = 13;
            this.cbRetailPrice.UseVisualStyleBackColor = true;
            // 
            // cbCostPrice
            // 
            this.cbCostPrice.AutoSize = true;
            this.cbCostPrice.Location = new System.Drawing.Point(285, 17);
            this.cbCostPrice.Name = "cbCostPrice";
            this.cbCostPrice.Size = new System.Drawing.Size(15, 14);
            this.cbCostPrice.TabIndex = 12;
            this.cbCostPrice.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Retail price:";
            // 
            // btnReview
            // 
            this.btnReview.Location = new System.Drawing.Point(414, 12);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(75, 23);
            this.btnReview.TabIndex = 11;
            this.btnReview.Text = "Preview";
            this.btnReview.UseVisualStyleBackColor = true;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cost price:";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 315);
            this.Controls.Add(this.cbRetailPrice);
            this.Controls.Add(this.cbCostPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPurchaseOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_reportPOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_reportPOBindingSource;
        private dsPurchaseOrder dsPurchaseOrder;
        private dsPurchaseOrderTableAdapters.sp_reportPOTableAdapter sp_reportPOTableAdapter;
        private System.Windows.Forms.CheckBox cbRetailPrice;
        private System.Windows.Forms.CheckBox cbCostPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.Label label1;
    }
}