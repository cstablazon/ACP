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
    public partial class frmSite : Form
    {
        productCreation pc = new productCreation();
        public frmSite()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCreate.Text = "Create";
            btnCreate.Enabled = true;
            Id.button = "CREATE";
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            btnCreate.Text = "Update";
            btnCreate.Enabled = true;
            txtDesc.Text = Id.globalString;
            cbAddress.Text = Id.globalString2;
            Id.button = "UPDATE";
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvSite.SelectedRows.Count > 0)
            {
                //pc.modifyProduct("DELETE", "SITE", Id.globalID, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                site();
                btnCreate.Enabled = false;
                txtDesc.Clear();
                cbAddress.Text = "";
            }
            else
            {
                MessageBox.Show("Please select a row to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void site()
        {
            //con.Open();
            //SqlCommand cmd = new SqlCommand("Select inventDesc from inventLocation", con);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //dgvInventLocation.DataSource = dt;

            //DataTable dt = pc.fetchRecord("VIEW", "FETCHSITE", "", "", "", "", "", "");
            //BindingSource source = new BindingSource();
            //source.DataSource = dt;
            //dgvSite.DataSource = source;
        }

        public void address()
        {
            //DataSet ds = pc.fetchSupplierId("VIEW", "ADDRESS", "Address");
            //cbAddress.DataSource = ds.Tables["Address"];
            //cbAddress.DisplayMember = "Address";
            //cbAddress.ValueMember = "Address ID";
            //cbAddress.Text = Id.address;
        }

        private void frmSite_Load(object sender, EventArgs e)
        {
            site();
            address();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnCreate.Text = "Create";
            btnCreate.Enabled = false;
            txtDesc.Clear();
            cbAddress.Text = "";
            site();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Id.button == "CREATE")
            {
                string description = txtDesc.Text;
                description = char.ToUpper(description[0]) + description.Substring(1);
                DataTable dt = pc.fetchRecord("VIEW", "FETCHSITEBYDESC", "", txtDesc.Text, "", "", "", "");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtDesc, "Description already exist");
                    txtDesc.Focus();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtDesc.Text))
                    {
                        //pc.modifyProduct("CRUD", "SITE", pc.autoIncrementID("siteID", "site").ToString(), cbAddress.GetItemText(cbAddress.SelectedValue), description, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                        site();
                        txtDesc.Clear();
                        cbAddress.Text = "";
                        btnCreate.Enabled = false;
                        MessageBox.Show("Successfull saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (Id.button == "UPDATE")
            {
                string description = txtDesc.Text;
                DataTable dt = pc.fetchRecord("VIEW", "FETCHSITEFORUPDATE", Id.globalID, txtDesc.Text, "", "", "", "");
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
                        //pc.modifyProduct("CRUD", "SITE", Id.globalID, cbAddress.GetItemText(cbAddress.SelectedValue), description, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                        site();
                        txtDesc.Clear();
                        cbAddress.Text = "";
                        btnCreate.Enabled = false;
                        MessageBox.Show("Successfull updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgvSite_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvSite.Rows[e.RowIndex];

            if (Id.access == "NEWPROD")
            {
                Id.globalID = row.Cells["ID"].Value.ToString();
                Id.globalString = row.Cells["Name"].Value.ToString();
            }
            else
            {
                Id.globalID = row.Cells["ID"].Value.ToString();
                Id.globalString = row.Cells["Name"].Value.ToString();
                Id.globalString2 = row.Cells["Address"].Value.ToString();
            }
        }

        private void dgvSite_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSite.ClearSelection();
        }

        private void frmSite_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                //if (f.Name == "frmProdAdditionalInfo")
                //{
                //    //(f as frmProdAdditionalInfo).cbSite.Text = Id.globalString;
                //    //modifyProd.Controls.RemoveByKey("pCatHierarchy");
                //    (f as frmProdAdditionalInfo).Controls.RemoveByKey("pSite");
                //    (f as frmProdAdditionalInfo).cbSite.Focus();
                //    //(f as frmModifyProd).cbCategoryCode.BeginInvoke(new Action(() => (f as frmModifyProd).cbCategoryCode.SelectionLength = 0));
                //    Id.showSite = false;

                //}
            }
        }

        private void dgvSite_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvSite.Rows[e.RowIndex];

            //frmProdAdditionalInfo additionalInfo = new frmProdAdditionalInfo();
            //additionalInfo.cbSite.Text = row.Cells["Name"].Value.ToString();


            
        }
    }
}
