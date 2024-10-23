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
    public partial class frmProdSubType : Form
    {
        productCreation pc = new productCreation();
        public frmProdSubType()
        {
            InitializeComponent();
        }

        public void prodSubType()
        {
            DataTable dt = pc.fetchRecord("VIEW", "FETCHPRODSUBTYPE", "", "", "", "", "", "");
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
                    DataTable dt = pc.fetchRecord("VIEW", "FETCHPRODSUBTYPEBYDESC", "", txtDesc.Text, "", "", "", "");
                    if (dt.Rows.Count > 0)
                    {
                        errorProvider1.SetError(txtDesc, "Description already exist");
                        txtDesc.Focus();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtDesc.Text))
                        {
                            description = char.ToUpper(description[0]) + description.Substring(1);
                            //pc.modifyProduct("CRUD", "PRODSUBTYPE", pc.autoIncrementID("prodSubTypeID", "product_subType").ToString(), description, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
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
                    DataTable dt = pc.fetchRecord("VIEW", "FETCHPRODSUBTYPEFORUPDATE", Id.globalID, txtDesc.Text, "", "", "", "");
                    if (dt.Rows.Count > 0)
                    {
                        errorProvider1.SetError(txtDesc, "Description already exist");
                        txtDesc.Focus();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtDesc.Text))
                        {
                            description2 = char.ToUpper(description2[0]) + description2.Substring(1);
                            //pc.modifyProduct("CRUD", "PRODSUBTYPE", Id.globalID, txtDesc.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
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
            errorProvider1.Clear();
            DataTable dt = pc.fetchRecord("VIEW", "FETCHPRODSUBTYPEBYDESC", "", txtDesc.Text, "", "", "", "");
            if(Id.button == "CREATE")
            {
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtDesc, "Description already exist");
                    txtDesc.Focus();
                }
            }
            else
            {
                DataTable dt2 = pc.fetchRecord("VIEW", "FETCHPRODSUBTYPEFORUPDATE", Id.globalID, txtDesc.Text, "", "", "", "");
                if (dt2.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtDesc, "Description already exist");
                    txtDesc.Focus();
                }
            }

        }

        private void dgvProdSubType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvProdSubType.Rows[e.RowIndex];

            Id.globalID = row.Cells["ID"].Value.ToString();
            Id.globalString = row.Cells["Description"].Value.ToString();
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
