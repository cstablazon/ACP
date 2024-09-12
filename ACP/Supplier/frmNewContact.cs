﻿using System;
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
    public partial class frmNewContact : Form
    {
        acpEntities db = new acpEntities();
        supplierClass supClass = new supplierClass();
        public frmNewContact()
        {
            InitializeComponent();
            contactType();
        }

        private void disableAndClear()
        {
            contactType();
            txtDesc.Clear();
            cbPrimary.Checked = false;
            btnConEdit.Enabled = false;
            btnConDelete.Enabled = false;
            btnCreate.Text = "Create";
        }

        private void isPrimary()
        {
            if (cbPrimary.Checked == true)
            {
                Id.isPrimary = true;
            }
            else
            {
                Id.isPrimary = false;
            }
        }

        private void createUpdate()
        {
            if (!string.IsNullOrEmpty(cmbCtype.Text) || !string.IsNullOrEmpty(txtDesc.Text))
            {
                if(Id.button == "Create")
                {
                    int typeID = Convert.ToInt32(cmbCtype.SelectedValue);
                    supClass.createUpdateContact("contactDIR", "Create", null, Id.suppID, typeID, txtDesc.Text, cbPrimary.Checked, Id.userID);
                    fetchContact();
                    disableAndClear();
                }
                else if(Id.button == "Update")
                {
                    int typeID = Convert.ToInt32(cmbCtype.SelectedValue);
                    supClass.createUpdateContact("contactDIR", "Update", Id.contactID, Id.suppID, typeID, txtDesc.Text, cbPrimary.Checked, Id.userID);
                    fetchContact();
                    disableAndClear();
                }
            }
            else
            {
                MessageBox.Show("Fillup necessary information", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            isPrimary();
            createUpdate();
        }

        private void contactType()
        {
            cmbCtype.DataSource = (from a in db.contactTypes select a).ToList();
            cmbCtype.ValueMember = "typeID";
            cmbCtype.DisplayMember = "tDesc";
        }

        private void fetchContact()
        {
            DataTable dt = supClass.getRecords("contactDIR", "fetchContact", Id.suppID, "");
            dgvCon.DataSource = dt;


            dgvCon.Columns["contactID"].Visible = false;
            dgvCon.Columns["TID"].Visible = false;
            dgvCon.Columns["typeID"].Visible = false;
            dgvCon.Columns["Contact information"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void frmNewContact_Load(object sender, EventArgs e)
        {
            fetchContact();
        }

        private void lblNew_Click(object sender, EventArgs e)
        {
            frmContactType ct = new frmContactType();
            ct.WindowState = FormWindowState.Normal;
            ct.ControlBox = true;
            ct.ShowDialog();
            contactType();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvCon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(dgvCon.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvCon.Rows[e.RowIndex];

                    Id.contactID = Convert.ToInt32(row.Cells["contactID"].Value);

                    btnConEdit.Enabled = true;
                    btnConDelete.Enabled = true;
                }
                else
                {
                    btnConEdit.Enabled = false;
                    btnConDelete.Enabled = false;
                }
            }
        }

        private void dgvCon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnConEdit.PerformClick();
        }

        private void dgvCon_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCon.ClearSelection();
        }

        private void btnConEdit_Click(object sender, EventArgs e)
        {
            if (dgvCon.SelectedRows.Count > 0)
            {
                Id.button = "Update";
                btnCreate.Text = "Update";

                int rowIndex = dgvCon.SelectedRows[0].Index;
                Id.contactID = Convert.ToInt32(dgvCon.Rows[rowIndex].Cells["contactID"].Value);
                cmbCtype.Text = dgvCon.Rows[rowIndex].Cells["Contact Type"].Value.ToString();
                txtDesc.Text = dgvCon.Rows[rowIndex].Cells["Contact information"].Value.ToString();
                cbPrimary.Checked = Convert.ToBoolean(dgvCon.Rows[rowIndex].Cells["isPrimary"].Value);
            }
        }

        private void btnConDelete_Click(object sender, EventArgs e)
        {
            int contactID = Convert.ToInt32(Id.contactID);
            supClass.deleteContact("contactDIR", "Delete", Id.contactID);

            fetchContact();
            disableAndClear();
            btnConEdit.Enabled = false;
            btnConDelete.Enabled = false;
        }

        private void cmbCtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
