using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACP
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsPurchaseOrder.sp_reportPO' table. You can move, or remove it, as needed.
            this.sp_reportPOTableAdapter.Fill(this.dsPurchaseOrder.sp_reportPO, "00001");
           
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            if (cbCostPrice.Checked == false && cbRetailPrice.Checked == false)
            {
                MessageBox.Show("Please select an option to preview", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // TODO: This line of code loads data into the 'dsPO.sp_reportPO' table. You can move, or remove it, as needed.
                //this.sp_reportPOTableAdapter.Fill(this.dsPO.sp_reportPO, Id.orderNo);

                //this.sp_reportPOTableAdapter.Fill(this.dsPurchaseOrder.sp_reportPO, Id.orderNo);
                //ReportParameter[] parameters = new ReportParameter[1];

                if(cbCostPrice.Checked == true && cbRetailPrice.Checked == false)
                {
                    reportViewer1.Reset();
                    //ReportDataSource rds = new ReportDataSource("costPrice", bind);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("costPrice", this.sp_reportPOBindingSource));
                    reportViewer1.LocalReport.ReportEmbeddedResource = "ACP.reportPOcostPrice.rdlc";
                    this.reportViewer1.RefreshReport();
                    //var bind = new BindingSource();
                    //bind.DataSource = dsPurchaseOrder;
                    //reportViewer1.Reset();
                    //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("costPrice", bind));
                    //reportViewer1.LocalReport.ReportEmbeddedResource = "ACP.reportPOcostPrice.rdlc";
                    //this.reportViewer1.RefreshReport();

                    //parameters[0] = new ReportParameter("hiddenColumn", "Cost price");
                //    //new ReportParameter("hiddenColumn", "True");
                //    //new ReportParameter("nullParam", "Cost price");
                }
                else if (cbCostPrice.Checked == false && cbRetailPrice.Checked == true)
                {
                    reportViewer1.Reset();
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("retailPrice", this.sp_reportPOBindingSource));
                    reportViewer1.LocalReport.ReportEmbeddedResource = "ACP.reportPOretailPrice.rdlc";
                    this.reportViewer1.RefreshReport();
                  //new ReportParameter("hiddenColumn", "Retail price");
                //   //new ReportParameter("nullParam", "Retail price");
                }
                else if (cbCostPrice.Checked == true && cbRetailPrice.Checked == true)
                {
                    reportViewer1.Reset();
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("retailAndCost", this.sp_reportPOBindingSource));
                    reportViewer1.LocalReport.ReportEmbeddedResource = "ACP.reportPOretailAndCost.rdlc";
                    this.sp_reportPOTableAdapter.Fill(this.dsPurchaseOrder.sp_reportPO, Id.orderNo);
                    this.reportViewer1.RefreshReport();
                    //new ReportParameter("hiddenColumn", "Retail and Cost");
                }

                //this.sp_reportPOTableAdapter.Fill(this.dsPurchaseOrder.sp_reportPO, Id.orderNo);
                //this.reportViewer1.LocalReport.SetParameters(parameters);
                //this.reportViewer1.RefreshReport();
            }
        }

        private void cbCostPrice_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cbRetailPrice_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
