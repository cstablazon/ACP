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
    public partial class frmProdType : Form
    {
        productCreation pc = new productCreation();
        public frmProdType()
        {
            InitializeComponent();
        }

        public void prodType()
        {
            DataTable dt = pc.fetchRecord("VIEW", "FETCHPRODTYPE", "", "", "", "", "", "");
            BindingSource source = new BindingSource();
            source.DataSource = dt;
            dgvProdType.DataSource = source;
        }

        private void frmProdType_Load(object sender, EventArgs e)
        {
            prodType();
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
                if (dgvProdType.SelectedRows.Count > 0)
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
                    DataTable dt = pc.fetchRecord("VIEW", "FETCHPRODTYPEBYDESC", "", txtDesc.Text, "", "", "", "");
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
                            //pc.modifyProduct("CRUD", "PRODTYPE", pc.autoIncrementID("prodTypeID", "product_type").ToString(), description, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            prodType();
                            txtDesc.Clear();
                            btnCreate.Enabled = false;
                            MessageBox.Show("Successfull saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (Id.button == "UPDATE")
                {
                    string description2 = txtDesc.Text;
                    DataTable dt = pc.fetchRecord("VIEW", "FETCHPRODTYPEFORUPDATE", Id.globalID, txtDesc.Text, "", "", "", "");
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
                            //pc.modifyProduct("CRUD", "PRODTYPE", Id.globalID, txtDesc.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            prodType();
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
                if (dgvProdType.SelectedRows.Count > 0)
                {
                    //pc.modifyProduct("DELETE", "PRODTYPE", Id.globalID, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    prodType();
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

        private void dgvProdType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvProdType.Rows[e.RowIndex];

            Id.globalID = row.Cells["ID"].Value.ToString();
            Id.globalString = row.Cells["Description"].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            prodType();
            txtDesc.Clear();
            btnCreate.Enabled = false;
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(Id.button == "CREATE")
            {
                DataTable dt = pc.fetchRecord("VIEW", "FETCHPRODTYPEBYDESC", "", txtDesc.Text, "", "", "", "");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtDesc, "Description already exist");
                    txtDesc.Focus();
                }
            }
            else
            {
                DataTable dt2 = pc.fetchRecord("VIEW", "FETCHPRODTYPEFORUPDATE", Id.globalID, txtDesc.Text, "", "", "", "");
                if (dt2.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtDesc, "Description already exist");
                    txtDesc.Focus();
                }
            }
        }

        private void dgvProdType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProdType.ClearSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
