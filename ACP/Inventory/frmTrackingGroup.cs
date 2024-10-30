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
    public partial class frmTrackingGroup : Form
    {
        productCreation pc = new productCreation();
        public frmTrackingGroup()
        {
            InitializeComponent();
        }

        public void trackingGroup()
        {
            //DataTable dt = pc.fetchRecord("VIEW", "FETCHTRACKINGDMNSN", "", "", "", "", "", "");
            //BindingSource source = new BindingSource();
            //source.DataSource = dt;
            //dgvTrackingDmnsn.DataSource = source;
        }

        private void frmTrackingGroup_Load(object sender, EventArgs e)
        {
            trackingGroup();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Id.button == "CREATE")
            {
                string description = txtDesc.Text;
                DataTable dt = pc.fetchRecord("VIEW", "FETCHTRACKINGDMNSNBYDESC", "", txtDesc.Text, "", "", "", "");
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
                        //pc.modifyProduct("CRUD", "TRACKINGDMNSN", pc.autoIncrementID("tdGroupID", "trackingDmnsnGroup").ToString(), description, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                        trackingGroup();
                        txtDesc.Clear();
                        btnCreate.Enabled = false;
                        MessageBox.Show("Successfull saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (Id.button == "UPDATE")
            {
                string description2 = txtDesc.Text;
                DataTable dt = pc.fetchRecord("VIEW", "FETCHTRACKINGDMNSNFORUPDATE", Id.globalID, txtDesc.Text, "", "", "", "");
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
                        //pc.modifyProduct("CRUD", "TRACKINGDMNSN", Id.globalID, txtDesc.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                        trackingGroup();
                        txtDesc.Clear();
                        btnCreate.Enabled = false;
                        MessageBox.Show("Successfull updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCreate.Text = "Create";
            btnCreate.Enabled = true;
            Id.button = "CREATE";
        }

        private void dgvTrackingDmnsn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvTrackingDmnsn.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTrackingDmnsn.Rows[e.RowIndex];
                Id.globalID = row.Cells["Tracking ID"].Value.ToString();
                Id.globalString = row.Cells["Description"].Value.ToString();
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if(dgvTrackingDmnsn.SelectedRows.Count > 0)
            {
                btnCreate.Text = "Update";
                btnCreate.Enabled = true;
                txtDesc.Text = Id.globalString;
                Id.button = "UPDATE";
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(Id.button == "CREATE")
            {
                DataTable dt = pc.fetchRecord("VIEW", "FETCHTRACKINGDMNSNBYDESC", "", txtDesc.Text, "", "", "", "");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtDesc, "Description already exist");
                    txtDesc.Focus();
                }
            }
            else
            {
                DataTable dt2 = pc.fetchRecord("VIEW", "FETCHTRACKINGDMNSNFORUPDATE", Id.globalID, txtDesc.Text, "", "", "", "");
                if (dt2.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtDesc, "Description already exist");
                    txtDesc.Focus();
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvTrackingDmnsn.SelectedRows.Count > 0)
            {
                //pc.modifyProduct("DELETE", "TRACKINGDMNSN", Id.globalID, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                trackingGroup();
                btnCreate.Enabled = false;
                txtDesc.Clear();
            }
            else
            {
                MessageBox.Show("Please select a row to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvTrackingDmnsn_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvTrackingDmnsn.ClearSelection();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            trackingGroup();
            btnCreate.Text = "Create";
            btnCreate.Enabled = false;
            txtDesc.Clear();
        }
    }
}
