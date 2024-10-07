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
                this.sp_reportPOTableAdapter.Fill(this.dsPO.sp_reportPO, Id.orderNo);
                ReportParameter[] parameters = new ReportParameter[1];
                if(cbCostPrice.Checked == true && cbRetailPrice.Checked == false)
                {
                    parameters[0] = new ReportParameter("hiddenColumn", "True");
                    parameters[1] = new ReportParameter("nullParam", "Cost price");
                }
                else if (cbCostPrice.Checked == false && cbRetailPrice.Checked == true)
                {
                    parameters[0] = new ReportParameter("hiddenColumn", "False");
                    parameters[1] = new ReportParameter("nullParam", "Retail price");
                }
                else if (cbCostPrice.Checked == true && cbRetailPrice.Checked == true)
                {

                }
                //if (Id.condition)
                //{
                //    parameters[0] = new ReportParameter("HiddenColumn", "False");
                //}
                //else
                //{
                //    parameters[0] = new ReportParameter("HiddenColumn", "True");
                //}
                this.reportViewer1.LocalReport.SetParameters(parameters);
                this.reportViewer1.RefreshReport();
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
