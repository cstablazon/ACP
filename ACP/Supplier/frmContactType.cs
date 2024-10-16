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
    public partial class frmContactType : Form
    {
        acpEntities db = new acpEntities();
        supplierClass supClass = new supplierClass();
        TextInfo txtInfo = CultureInfo.CurrentCulture.TextInfo;
        public frmContactType()
        {
            InitializeComponent();
            fetch_contactType();
        }

        private void fetch_contactType()
        {
            DataTable dt = supClass.getRecords("contactType", "fetchContactType", "", "");
            dgvContactType.DataSource = dt;
            dgvContactType.Columns["typeID"].Visible = false;
            //dgvContactType.DataSource = (from a in db.contactTypes
            //                             select new
            //                                 {
            //                                     a.typeID,
            //                                     a.tDesc
            //                                 }).ToList();
            //dgvContactType.Columns[0].Visible = false;
            //dgvContactType.Columns[1].HeaderText = "Description";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDesc.Text))
            {
                if (Id.button.Equals("Create"))
                {
                    supClass.createUpdateContactType("contactType", "Create", null, txtInfo.ToTitleCase(txtDesc.Text), Id.userID);
                    MessageBox.Show("Successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fetch_contactType();
                    refresh();
                    
                }
                else if(Id.button.Equals("Update"))
                {
                    supClass.createUpdateContactType("contactType", "Update", Id.contactTypeID, txtInfo.ToTitleCase(txtDesc.Text), Id.userID);
                    MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fetch_contactType();
                    refresh();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Id.button = "Create";
            btnCreate.Text = "Create";
            txtDesc.Clear();
            txtDesc.Enabled = true;
            btnCreate.Enabled = true;
        }

        private void dgvContactType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvContactType.Rows[e.RowIndex];
                Id.contactTypeID = Convert.ToInt32(row.Cells["typeID"].Value);
                if(dgvContactType.SelectedRows.Count > 0)
                {
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

        private void refresh()
        {
            fetch_contactType();
            txtDesc.Clear();
            txtDesc.Enabled = false;
            btnCreate.Text = "Create";
            btnCreate.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fetch_contactType();
            refresh();
        }

        private void dgvContactType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Id.button = "Update";
            btnCreate.Text = "Update";

            txtDesc.Enabled = true;
            btnCreate.Enabled = true;
            if(dgvContactType.SelectedRows.Count > 0)
            {
                int rowIndex = dgvContactType.SelectedRows[0].Index;
                txtDesc.Text = dgvContactType.Rows[rowIndex].Cells["Contact Type"].Value.ToString();
            }
        }

        private void dgvContactType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvContactType.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to delete contact type?", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                supClass.deleteContactType("contactType", "Delete", Id.contactTypeID);
                MessageBox.Show("Successfully deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fetch_contactType();
                refresh();
            }
        }
    }
}
