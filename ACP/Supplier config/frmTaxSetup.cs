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
    public partial class frmTaxSetup : Form
    {
        supplierClass supClass = new supplierClass();
        public frmTaxSetup()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCreate.Text == "Create")
                {
                    if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtPercent.Text))
                    {
                        decimal percent = Convert.ToDecimal(txtPercent.Text);
                        supClass.createUpdateItemTaxSetup("taxSetup", "Create", Id.iGlobalID, Id.itemTaxID, txtName.Text, percent, Id.userID);
                        MessageBox.Show("Successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Fillup necessary information", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (btnCreate.Text == "Update")
                {
                    if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtPercent.Text))
                    {
                        decimal percent = Convert.ToDecimal(txtPercent.Text);
                        supClass.createUpdateItemTaxSetup("taxSetup", "Update", Id.iGlobalID, Id.itemTaxID, txtName.Text, percent, Id.userID);
                        MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Fillup necessary information", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.');
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
