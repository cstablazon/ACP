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
    public partial class frmPaymentTerm : Form
    {
        acpEntities db = new acpEntities();
        supplierClass supClass = new supplierClass();
        public frmPaymentTerm()
        {
            InitializeComponent();
            fetchPaymentTerms();
        }
        string msg;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCreate.Enabled = true;
            Id.button = "Create";
            btnCreate.Text = "Create";

            txtDays.Enabled = true;
            txtDesc.Enabled = true;
            txtDesc.Clear();
            txtDays.Clear();
            btnCreate.Enabled = true;
        }

        private void fetchPaymentTerms() 
        {
            DataTable dt = supClass.getRecords("paymentTerms", "fetchPaymentTerms", "", "");
            dgvPayTerm.DataSource = dt;
            dgvPayTerm.Columns["payID"].Visible = false;
            dgvPayTerm.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPayTerm.Columns["Days"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPayTerm.Columns["Date created"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Id.button.Equals("Create"))
                {
                    btnCreate.Text = "Create";
                    if (!string.IsNullOrEmpty(txtDesc.Text) && !string.IsNullOrWhiteSpace(txtDesc.Text))
                    {
                        supClass.createUpdatePaymentTerm("paymentTerms", "Create", null, txtDesc.Text, txtDays.Text, Id.userID);
                        fetchPaymentTerms();
                        disableAndClear();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Fill up necessary information", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Id.button.Equals("Update"))
                {
                    btnCreate.Text = "Update";
                    supClass.createUpdatePaymentTerm("paymentTerms", "Update", Id.payID, txtDesc.Text, txtDays.Text, Id.userID);
                    fetchPaymentTerms();
                    disableAndClear();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.KeyChar) || e.KeyChar == '\b');
        }

        private void disableAndClear()
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtDays.Enabled = false;
            txtDesc.Enabled = false;
            txtDesc.Clear();
            txtDays.Clear();
            btnCreate.Enabled = false;
            btnCreate.Text = "Create";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fetchPaymentTerms();
            disableAndClear();
        }

        private void dgvPayTerm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(dgvPayTerm.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvPayTerm.Rows[e.RowIndex];
                    Id.payID = Convert.ToInt32(row.Cells["payID"].Value);

                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Id.button = "Update";
                btnCreate.Text = "Update";
                txtDays.Enabled = true;
                txtDesc.Enabled = true;
                btnCreate.Enabled = true;
                if (dgvPayTerm.SelectedRows.Count > 0)
                {
                    int rowIndex = dgvPayTerm.SelectedRows[0].Index;

                    txtDesc.Text = dgvPayTerm.Rows[rowIndex].Cells["Description"].Value.ToString();
                    txtDays.Text = dgvPayTerm.Rows[rowIndex].Cells["Days"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Are you sure to delete payment term?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    supClass.deletePaymentTerm("paymentTerms", "Delete", Id.payID);

                    fetchPaymentTerms();
                    disableAndClear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frmPaymentTerm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.FixedSingle)
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
            {
                this.Hide();
            }
        }

        private void dgvPayTerm_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPayTerm.ClearSelection();
        }
    }
}
