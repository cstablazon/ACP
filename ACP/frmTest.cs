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
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsPurchaseOrder.sp_reportPO' table. You can move, or remove it, as needed.
            
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            this.sp_reportPOTableAdapter.Fill(this.dsPurchaseOrder.sp_reportPO, "00001");


            ReportParameter[] parameters = new ReportParameter[1];

            if (cbCostPrice.Checked == true && cbRetailPrice.Checked == false)
            {
                parameters[0] = new ReportParameter("Hide", "Cost price");
                //    //new ReportParameter("hiddenColumn", "True");
                //    //new ReportParameter("nullParam", "Cost price");
            }
            else if (cbCostPrice.Checked == false && cbRetailPrice.Checked == true)
            {
                parameters[0] = new ReportParameter("Hide", "Retail price");
                //   //new ReportParameter("nullParam", "Retail price");
            }
            else if (cbCostPrice.Checked == true && cbRetailPrice.Checked == true)
            {
                parameters[0] = new ReportParameter("Hide", "Retail and Cost");
            }
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
