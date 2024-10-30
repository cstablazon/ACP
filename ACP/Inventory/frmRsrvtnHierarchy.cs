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
    public partial class frmRsrvtnHierarchy : Form
    {
        productCreation pc = new productCreation();
        public frmRsrvtnHierarchy()
        {
            InitializeComponent();
        }

        public void rsrvtn()
        {
            //DataTable dt = pc.fetchRecord("VIEW", "FETCHRSRVTN", "", "", "", "", "", "");
            //BindingSource source = new BindingSource();
            //source.DataSource = dt;
            //dgvRsrvtn.DataSource = source;
        }

        private void frmRsrvtnHierarchy_Load(object sender, EventArgs e)
        {
            rsrvtn();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //if (Id.button == "CREATE")
            //{
            //    string description = txtDesc.Text;
            //    description = char.ToUpper(description[0]) + description.Substring(1);
            //    DataTable dt = pc.fetchRecord("VIEW", "FETCHRSRVTNBYDESC", "", txtDesc.Text, "", "", "", "");
            //    if (dt.Rows.Count > 0)
            //    {
            //        errorProvider1.SetError(txtDesc, "Description already exist");
            //        txtDesc.Focus();
            //    }
            //    else
            //    {
            //        if (!string.IsNullOrEmpty(txtDesc.Text))
            //        {
            //            //action/desc/sdID/sdDesc/tdID/tdDesc/rsrvtnID/rsrvtnDesc
            //            pc.modifyProduct("CRUD", "RSRVTN", "", "", "", "", "", "", pc.autoIncrementID().ToString(), description);
            //            rsrvtn();
            //            txtDesc.Clear();
            //        }
            //    }
            //}
            //else if (Id.button == "UPDATE")
            //{
            //    string description = txtDesc.Text;
            //    DataTable dt = pc.fetchRecord("VIEW", "FETCHRSRVTNBFORUPDATE", "", "", "", "", Id.globalID, txtDesc.Text);
            //    if (dt.Rows.Count > 0)
            //    {
            //        errorProvider1.SetError(txtDesc, "Description already exist");
            //        txtDesc.Focus();
            //    }
            //    else
            //    {
            //        if (!string.IsNullOrEmpty(txtDesc.Text))
            //        {
            //            description = char.ToUpper(description[0]) + description.Substring(1);
            //            pc.modifyProduct("CRUD", "RSRVTN", "", "", "", "", "", "", Id.globalID, description);
            //            rsrvtn();
            //            txtDesc.Clear();
            //            btnAdd.Enabled = false;
            //        }
            //    }
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCreate.Enabled = true;
            Id.button = "CREATE";
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            btnCreate.Enabled = true;
            txtDesc.Text = Id.globalString;
            Id.button = "UPDATE";
        }

        private void dgvRsrvtn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvRsrvtn.Rows[e.RowIndex];

            if(dgvRsrvtn.SelectedRows.Count > 0)
            {
                Id.globalID = row.Cells["ID"].Value.ToString();
                Id.globalString = row.Cells["Description"].Value.ToString();
            }
        }

        private void dgvRsrvtn_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvRsrvtn.ClearSelection();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            //if (dgvRsrvtn.SelectedRows.Count > 0)
            //{
            //    pc.modifyProduct("DELETE", "RSRVTN", "", "", "", "", "", "", Id.globalID, "");
            //    rsrvtn();
            //    btnCreate.Enabled = false;
            //    txtDesc.Clear();
            //}
            //else
            //{
            //    MessageBox.Show("Please select a row to delete", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            rsrvtn();
            txtDesc.Clear();
            btnCreate.Enabled = false;
        }

        
    }
}
