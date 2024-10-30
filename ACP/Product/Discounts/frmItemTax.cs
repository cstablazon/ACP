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
    public partial class frmItemTax : Form
    {
        productCreation pc = new productCreation();
        public frmItemTax()
        {
            InitializeComponent();
        }

        public void itemTax()
        {
            //DataTable dt = pc.fetchRecord("VIEW", "FETCHITEMTAX", "", "", "", "", "", "");
            //BindingSource source = new BindingSource();
            //source.DataSource = dt;
            //dgvItemTax.DataSource = source;
        }

        private void frmItemTax_Load(object sender, EventArgs e)
        {
            itemTax();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCreate.Text = "Create";
            btnCreate.Enabled = true;
            Id.button = "CREATE";
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dgvItemTax.SelectedRows.Count > 0)
            {
                btnCreate.Text = "Update";
                btnCreate.Enabled = true;
                txtName.Text = Id.globalID;
                txtDesc.Text = Id.globalString;
                cbPercent.Text = Id.globalString2;
                Id.button = "UPDATE";
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvItemTax.SelectedRows.Count > 0)
            {
                //pc.modifyProduct("DELETE", "ITEMTAX", "", Id.globalID, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                itemTax();
                btnCreate.Enabled = false;
                txtDesc.Clear();
                txtName.Clear();
                cbPercent.Text = "";
            }
            else
            {
                MessageBox.Show("Please select a row to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            itemTax();
            btnCreate.Text = "Create";
            btnCreate.Enabled = false;
            txtDesc.Clear();
            txtName.Clear();
            cbPercent.Text = "";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Id.button == "CREATE")
            {
                string description = txtDesc.Text;
                DataTable dt = pc.fetchRecord("VIEW", "FETCHITEMTAXBYDESC", "", txtDesc.Text, "", "", "", "");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtDesc, "Description already exist");
                    txtDesc.Focus();
                }
                else
                {
                    if (txtName.Text == "")
                    {
                        errorProvider1.SetError(txtName, "Name is required");
                    }
                    else if (txtDesc.Text == "")
                    {
                        errorProvider1.SetError(txtDesc, "Description is required");
                    }
                    else if (cbPercent.Text == "")
                    {
                        errorProvider1.SetError(cbPercent, "Percent is required");
                    }
                    else
                    {
                        description = char.ToUpper(description[0]) + description.Substring(1);
                        //pc.modifyProduct("CRUD", "ITEMTAX", "", txtName.Text, description, cbPercent.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                        itemTax();
                        txtDesc.Clear();
                        txtName.Clear();
                        cbPercent.Text = "";
                        btnCreate.Enabled = false;
                        MessageBox.Show("Successfull saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (Id.button == "UPDATE")
            {
                string description2 = txtDesc.Text;
                DataTable dt = pc.fetchRecord("VIEW", "FETCHITEMTAXFORUPDATE", Id.globalID, txtDesc.Text, "", "", "", "");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtDesc, "Description already exist");
                    txtDesc.Focus();
                }
                else
                {
                    if (txtName.Text == "")
                    {
                        errorProvider1.SetError(txtName, "Name is required");
                    }
                    else if(txtDesc.Text == "")
                    {
                        errorProvider1.SetError(txtDesc, "Description is required");
                    }
                    else if(cbPercent.Text == "")
                    {
                        errorProvider1.SetError(txtDesc, "Percent is required");
                    }
                    else
                    {
                        description2 = char.ToUpper(description2[0]) + description2.Substring(1);
                        //pc.modifyProduct("UPDATE", "ITEMTAX", Id.globalID, txtName.Text, txtDesc.Text, cbPercent.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                        itemTax();
                        txtDesc.Clear();
                        txtName.Clear();
                        cbPercent.Text = "";
                        btnCreate.Enabled = false;
                        MessageBox.Show("Successfull updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgvItemTax_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvItemTax.Rows[e.RowIndex];

            Id.globalID = row.Cells["Item Tax ID"].Value.ToString();
            Id.globalString = row.Cells["Description"].Value.ToString();
            Id.globalString2 = row.Cells["Percent"].Value.ToString();
        }
    }
}
