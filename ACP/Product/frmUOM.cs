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
    public partial class frmUOM : Form
    {
        productCreation pc = new productCreation();
        public frmUOM()
        {
            InitializeComponent();
        }

        public void uom()
        {
            DataTable dt = pc.fetchRecord("VIEW", "FETCHUOM", "", "", "", "", "", "");
            BindingSource source = new BindingSource();
            source.DataSource = dt;
            dgvUOM.DataSource = source;
        }

        private void frmUOM_Load(object sender, EventArgs e)
        {
            uom();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCreate.Text = "Create";
            btnCreate.Enabled = true;
            Id.button = "CREATE";
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvUOM.SelectedRows.Count > 0)
            {
                btnCreate.Text = "Update";
                btnCreate.Enabled = true;
                txtDesc.Text = Id.globalString;
                Id.button = "UPDATE";
            }
            else
            {
                MessageBox.Show("Please select a row to edit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvUOM.SelectedRows.Count > 0)
            {
                //pc.modifyProduct("DELETE", "UOM", Id.globalID, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                uom();
                btnCreate.Enabled = false;
                txtDesc.Clear();
            }
            else
            {
                MessageBox.Show("Please select a row to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            uom();
            txtDesc.Clear();
            btnCreate.Enabled = false;
            btnCreate.Text = "Create";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Id.button == "CREATE")
            {
                string description = txtDesc.Text;
                description = char.ToUpper(description[0]) + description.Substring(1);
                DataTable dt = pc.fetchRecord("VIEW", "FETCHUOMBYDESC", "", txtDesc.Text, "", "", "", "");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtDesc, "Description already exist");
                    txtDesc.Focus();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtDesc.Text))
                    {
                        //pc.modifyProduct("CRUD", "UOM", pc.autoIncrementID("uomID", "UOM").ToString(), description, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                        uom();
                        txtDesc.Clear();
                    }
                }
            }
            else if (Id.button == "UPDATE")
            {
                string description = txtDesc.Text;
                DataTable dt = pc.fetchRecord("VIEW", "FETCHUOMFORUPDATE", Id.globalID, txtDesc.Text, "", "", "", "");
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
                        //pc.modifyProduct("CRUD", "UOM", Id.globalID, description, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                        uom();
                        txtDesc.Clear();
                        btnAdd.Enabled = false;
                    }
                }
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (Id.button == "CREATE")
            {
                DataTable dt = pc.fetchRecord("VIEW", "FETCHSTORAGEDMNSNBYDESC", "", txtDesc.Text, "", "", "", "");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtDesc, "Description already exist");
                    txtDesc.Focus();
                }
            }
            else
            {
                DataTable dt = pc.fetchRecord("VIEW", "FETCHSTORAGEDMNSNFORUPDATE", Id.globalID, txtDesc.Text, "", "", "", "");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtDesc, "Description already exist");
                    txtDesc.Focus();
                }
            }
        }

        private void dgvUOM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvUOM.Rows[e.RowIndex];

            Id.globalID = row.Cells["Unit ID"].Value.ToString();
            Id.globalString = row.Cells["Description"].Value.ToString();
        }
    }
}
