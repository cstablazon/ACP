using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACP
{
    public partial class frmBrand : Form
    {
        productCreation pc = new productCreation();
        TextInfo txtInfo = CultureInfo.CurrentCulture.TextInfo;
        public frmBrand()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void fetchBrand()
        {
            DataTable dt = pc.fetchRecords("sp_Product", "Brand", "fetchBrand", null);
            dgvBrand.DataSource = dt;

            dgvBrand.Columns["brandID"].Visible = false;
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            fetchBrand();
        }

        private void disableAndClear()
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtDesc.Clear();
            txtDesc.Enabled = false;
            btnCreate.Text = "Create";
            btnCreate.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Id.button = "Create";
            btnCreate.Text = "Create";
            btnCreate.Enabled = true;
            txtDesc.Enabled = true;
            txtDesc.Clear();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Id.button == "Create")
            {
                if (string.IsNullOrEmpty(txtDesc.Text))
                {
                    MessageBox.Show("Description is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDesc.Focus();
                }
                else
                {
                    Id.brandID = pc.autoInc("brandID", "brand");
                    pc.createUpdateBrand("Brand", "Create", Id.brandID, txtInfo.ToTitleCase(txtDesc.Text), Id.userID);

                    fetchBrand();
                    disableAndClear();
                }
            }
            else if(Id.button == "Update")
            {
                if (string.IsNullOrEmpty(txtDesc.Text))
                {
                    MessageBox.Show("Description is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDesc.Focus();
                }
                else
                {
                    pc.createUpdateBrand("Brand", "Update", Id.brandID, txtInfo.ToTitleCase(txtDesc.Text), Id.userID);

                    fetchBrand();
                    disableAndClear();
                }
            }
        }

        private void dgvBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBrand.Rows[e.RowIndex];
                if(dgvBrand.SelectedRows.Count > 0)
                {
                    Id.brandID = Convert.ToInt32(row.Cells["brandID"].Value);

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
            if(dgvBrand.SelectedRows.Count > 0)
            {
                Id.button = "Update";
                btnCreate.Text = "Update";
                btnCreate.Enabled = true;
                txtDesc.Enabled = true;
                int rowIndex = dgvBrand.SelectedRows[0].Index;

                txtDesc.Text = dgvBrand.Rows[rowIndex].Cells["Brand"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to delete brand?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(res == DialogResult.Yes)
            {
                pc.deleteBrand("Brand", "Delete", Id.brandID);

                fetchBrand();
                disableAndClear();
            }
        }

        private void dgvBrand_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void dgvBrand_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvBrand.ClearSelection();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fetchBrand();
            disableAndClear();
        }
    }
}
