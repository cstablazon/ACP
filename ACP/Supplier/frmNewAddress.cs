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
    public partial class frmNewAddress : Form
    {
        acpEntities db = new acpEntities();
        supplierClass supClass = new supplierClass();
        UserPermissionManager _userPermission;
        TextInfo txtInfo = CultureInfo.CurrentCulture.TextInfo;
        string msg;
        public frmNewAddress()
        {
            InitializeComponent();
            cmbPurpose.Focus();
            _userPermission = new UserPermissionManager(Program.CurrentUserId);
        }

        private void createUpdate()
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbPurpose.Text) || !string.IsNullOrEmpty(txtAddress.Text) || !string.IsNullOrEmpty(txtCity.Text) || !string.IsNullOrEmpty(txtProvince.Text))
                {
                    if (Id.button == "Create")
                    {
                        supClass.createUpdateAddress("addressDIR", "Create", null, txtInfo.ToTitleCase(txtAddress.Text), Id.suppID, txtInfo.ToTitleCase(txtCity.Text), txtInfo.ToTitleCase(txtProvince.Text), txtInfo.ToTitleCase(cmbPurpose.Text), cbPrimary.Checked, Id.userID);
                        MessageBox.Show("Successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fetchAddress();
                        disableAndClear();

                    }
                    else if (Id.button == "Update")
                    {
                        supClass.createUpdateAddress("addressDIR", "Update", Id.addressID, txtInfo.ToTitleCase(txtAddress.Text), "", txtInfo.ToTitleCase(txtCity.Text), txtInfo.ToTitleCase(txtProvince.Text), txtInfo.ToTitleCase(cmbPurpose.Text), cbPrimary.Checked, Id.userID);
                        MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fetchAddress();
                        disableAndClear();
                    }
                    //if (Id.button == "Create")
                    //{
                    //    if (btnCreate.Text.Equals("Create"))
                    //    {
                    //        this.DialogResult = DialogResult.OK;
                    //        this.Hide();

                    //    }
                    //    else if (btnCreate.Text.Equals("Update"))
                    //    {

                    //        //supClass.createUpdateAddress("addressDIR", "Create", Id.addressID, txtAddress.Text, txtCity.Text, txtProvince.Text, cmbPurpose.Text, Id.isPrimary);
                    //        this.DialogResult = DialogResult.OK;
                    //        this.Hide();
                    //    }

                    //}
                    //else if (Id.button == "Update")
                    //{
                    //    if (btnCreate.Text.Equals("Create"))
                    //    {
                    //        supClass.createUpdateAddress("addressDIR", "Create", null, txtInfo.ToTitleCase(txtAddress.Text), Id.suppID, txtInfo.ToTitleCase(txtCity.Text), txtInfo.ToTitleCase(txtProvince.Text), txtInfo.ToTitleCase(cmbPurpose.Text), cbPrimary.Checked, Id.userID);
                    //        this.DialogResult = DialogResult.OK;
                    //        this.Hide();

                    //    }
                    //    else if (btnCreate.Text.Equals("Update"))
                    //    {
                    //        supClass.createUpdateAddress("addressDIR", "Update", Id.addressID, txtInfo.ToTitleCase(txtAddress.Text), "", txtInfo.ToTitleCase(txtCity.Text), txtInfo.ToTitleCase(txtProvince.Text), txtInfo.ToTitleCase(cmbPurpose.Text), cbPrimary.Checked, null);
                    //        this.DialogResult = DialogResult.OK;
                    //        this.Hide();
                    //    }
                    //}
                }
                else
                {
                    MessageBox.Show("Fillup necessary information", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (_userPermission.CanPerformOperation("Address Management Form", "Create"))
            {
                isPrimary();
                createUpdate();
            }
            else
            {
                MessageBox.Show("You don't have permission to create new Address.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbYes.Checked)
            //{
            //    Id.globalString2 = "true";
            //}
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbNo.Checked)
            //{
            //    Id.globalString2 = "false";
            //}
        }

        private void fetchAddress()
        {
            DataTable dt = supClass.getRecords("addressDIR", "fetchAddress", Id.suppID, "");

            dgvAddress.DataSource = dt;
            dgvAddress.Columns["addressID"].Visible = false;
            dgvAddress.Columns["address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void disableAndClear()
        {
            txtAddress.Clear();
            txtCity.Clear();
            txtProvince.Clear();
            cbPrimary.Checked = false;
            cmbPurpose.Text = "";
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnCreate.Text = "Create";
        }

        private void frmNewAddress_Load(object sender, EventArgs e)
        {
            fetchAddress();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
           // this.Dispose();
        }

        private void label6_Click(object sender, EventArgs e)
        {
           // this.Close();
        }

        private void cbPrimary_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(dgvAddress.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvAddress.Rows[e.RowIndex];

                    Id.addressID = Convert.ToInt32(row.Cells["addressID"].Value);

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

        private void dgvAddress_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void dgvAddress_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAddress.ClearSelection();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_userPermission.CanPerformOperation("Address Management Form", "Update"))
                {
                    if (dgvAddress.SelectedRows.Count > 0)
                    {
                        Id.button = "Update";
                        btnCreate.Text = "Update";

                        int rowIndex = dgvAddress.SelectedRows[0].Index;
                        Id.addressID = Convert.ToInt32(dgvAddress.Rows[rowIndex].Cells["addressID"].Value);
                        txtAddress.Text = dgvAddress.Rows[rowIndex].Cells["address"].Value.ToString();
                        txtCity.Text = dgvAddress.Rows[rowIndex].Cells["city"].Value.ToString();
                        txtProvince.Text = dgvAddress.Rows[rowIndex].Cells["province"].Value.ToString();
                        cmbPurpose.Text = dgvAddress.Rows[rowIndex].Cells["purpose"].Value.ToString();
                        cbPrimary.Checked = Convert.ToBoolean(dgvAddress.Rows[rowIndex].Cells["isPrimary"].Value);
                    }
                }
                else
                {
                    MessageBox.Show("You don't have permission to update Address.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_userPermission.CanPerformOperation("Address Management Form", "Delete"))
                {
                    if (dgvAddress.SelectedRows.Count > 0)
                    {
                        DialogResult res = MessageBox.Show("Are you sure to delete address?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            supClass.deleteAddress("addressDIR", "Delete", Id.addressID);

                            fetchAddress();
                            disableAndClear();
                            btnEdit.Enabled = false;
                            btnDelete.Enabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You don't have permission to create new Address.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
