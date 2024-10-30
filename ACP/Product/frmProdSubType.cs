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
    public partial class frmProdSubType : Form
    {
        productCreation pc = new productCreation();
        TextInfo txtInfo = CultureInfo.CurrentCulture.TextInfo;
        public frmProdSubType()
        {
            InitializeComponent();
        }

        public void prodSubType()
        {
            DataTable dt = pc.fetch("sp_productOperations", "product_type", "fetchProduct_type");
            BindingSource source = new BindingSource();
            source.DataSource = dt;
            dgvProdSubType.DataSource = source;
        }

        private void frmProdSubType_Load(object sender, EventArgs e)
        {
            prodSubType();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCreate.Text = "Create";
            Id.button = "CREATE";
            btnCreate.Enabled = true;
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProdSubType.SelectedRows.Count > 0)
                {
                    btnCreate.Text = "Update";
                    Id.button = "UPDATE";
                    txtDesc.Text = Id.globalString;
                    btnCreate.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Id.button == "CREATE")
                {
                    string description = txtDesc.Text;
                    DataTable dt = pc.fetch("sp_productOperations", "product_subType", "fetchProduct_subType");
                    if (dt.Select("prodSubTypeDesc = " + txtDesc.Text + "").Any())
                    {
                        errorProvider1.SetError(txtDesc, "Description already exist");
                        txtDesc.Focus();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtDesc.Text))
                        {
                            pc.createUpdateProduct_subType("create", null, txtInfo.ToTitleCase(txtDesc.Text), Id.userID);
                            prodSubType();
                            txtDesc.Clear();
                            btnCreate.Enabled = false;
                            MessageBox.Show("Successfull saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (Id.button == "UPDATE")
                {
                    string description2 = txtDesc.Text;
                    DataTable dt = pc.fetch("sp_productOperations", "product_subType", "fetchProduct_subType");
                    if (dt.Select("prodSubTypeID != "+prodSubTypeID+" AND prodSubTypeDesc = "+txtDesc.Text+"").Any())
                    {
                        errorProvider1.SetError(txtDesc, "Description already exist");
                        txtDesc.Focus();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtDesc.Text))
                        {
                            pc.createUpdateProduct_subType("create", prodSubTypeID, txtInfo.ToTitleCase(txtDesc.Text), Id.userID);
                            prodSubType();
                            txtDesc.Clear();
                            btnCreate.Enabled = false;
                            MessageBox.Show("Successfull updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProdSubType.SelectedRows.Count > 0)
                {
                    //pc.modifyProduct("DELETE", "PRODSUBTYPE", Id.globalID, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    prodSubType();
                    btnCreate.Enabled = false;
                    txtDesc.Clear();
                }
                else
                {
                    MessageBox.Show("Please select a row to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            prodSubType();
            txtDesc.Clear();
            btnCreate.Enabled = false;
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }
        int prodSubTypeID;
        private void dgvProdSubType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvProdSubType.Rows[e.RowIndex];

            prodSubTypeID = Convert.ToInt32(row.Cells["ID"].Value);
        }

        private void dgvProdSubType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProdSubType.ClearSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
