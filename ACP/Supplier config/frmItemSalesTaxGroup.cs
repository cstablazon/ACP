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
    public partial class frmItemSalesTaxGroup : Form
    {
        acpEntities db = new acpEntities();
        supplierClass supClass = new supplierClass();
        public frmItemSalesTaxGroup()
        {
            InitializeComponent();
        }

        private void itemTaxGroup()
        {
            if(Id.category == "All")
            {
                DataTable dt = supClass.getRecords("itemSalesTaxGroup", "fetchItemSalesTaxGroup2", "", "");
                dgvItemSalesTax.DataSource = dt;

                dgvItemSalesTax.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvItemSalesTax.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            else if(Id.category == "Supplier")
            {
                DataTable dt = supClass.getRecords("itemSalesTaxGroup", "fetchItemSalesTaxGroup", "", "");
                dgvItemSalesTax.DataSource = dt;

                dgvItemSalesTax.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvItemSalesTax.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            
        }

        private void itemTaxSetup()
        {
            DataTable dt = supClass.getRecords("itemSalesTaxGroup", "fetchItemSalesTaxGroupSetup", "", Id.itemTaxID);
            dgvSetup.DataSource = dt;

            dgvSetup.Columns["SID"].Visible = false;
            dgvSetup.Columns["Percent"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSetup.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void frmItemSalesTaxGroup_Load(object sender, EventArgs e)
        {
            itemTaxGroup();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Id.button = "Create";
            btnCreate.Text = "Create";
            txtDescription.Clear();
            txtItemTax.Clear();
            txtItemTax.Enabled = true;
            txtDescription.Enabled = true;
            btnCreate.Enabled = true;
        }

        private void dgvItemSalesTax_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvItemSalesTax.Rows[e.RowIndex];
                Id.itemTaxID = row.Cells["Tax ID"].Value.ToString();
                itemTaxSetup();
                if(dgvItemSalesTax.SelectedRows.Count > 0)
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    tsbNew.Enabled = true;
                }
                else
                {
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    tsbNew.Enabled = false;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemSalesTax.SelectedRows.Count > 0)
                {
                    Id.button = "Update";
                    btnCreate.Text = "Update";
                    int rowIndex = dgvItemSalesTax.SelectedRows[0].Index;
                    txtItemTax.Text = dgvItemSalesTax.Rows[rowIndex].Cells["Tax ID"].Value.ToString();
                    txtDescription.Text = dgvItemSalesTax.Rows[rowIndex].Cells["Tax Description"].Value.ToString();
                    btnCreate.Enabled = true;
                    txtItemTax.Enabled = true;
                    txtDescription.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvItemSalesTax_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvItemSalesTax.ClearSelection();
        }

        private void disableAndClear()
        {
            txtDescription.Clear();
            txtItemTax.Clear();
            btnCreate.Text = "Create";
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtDescription.Enabled = false;
            txtItemTax.Enabled = false;
            btnCreate.Enabled = false;
            tsbNew.Enabled = false;
            tsbEdit.Enabled = false;
            tsbRemove.Enabled = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtItemTax.Text) && !string.IsNullOrEmpty(txtDescription.Text))
                {
                    if (Id.button == "Create")
                    {
                        supClass.createUpdateItemTax("itemSalesTaxGroup", "Create", Id.itemTaxID, txtItemTax.Text, txtDescription.Text, Id.userID);
                        MessageBox.Show("Successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        itemTaxGroup();
                        dgvSetup.DataSource = null;
                        disableAndClear();
                    }
                    else if (Id.button == "Update")
                    {
                        supClass.createUpdateItemTax("itemSalesTaxGroup", "Update", Id.itemTaxID, txtItemTax.Text, txtDescription.Text, Id.userID);
                        MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        itemTaxGroup();
                        dgvSetup.DataSource = null;
                        disableAndClear();
                        btnCreate.Text = "Create";

                    }
                }
                else
                {
                    MessageBox.Show("Please fill necessary information", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DialogResult res = MessageBox.Show("Are you sure to delete item sales tax?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    supClass.deleteItemTax("itemSalesTaxGroup", "Delete", Id.itemTaxID);

                    MessageBox.Show("Successfully deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    itemTaxGroup();
                    dgvSetup.DataSource = null;
                    disableAndClear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            itemTaxGroup();
            dgvSetup.DataSource = null;
            disableAndClear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void dgvSetup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSetup.Rows[e.RowIndex];
                Id.iGlobalID = Convert.ToInt32(row.Cells["SID"].Value);
                if(dgvSetup.SelectedRows.Count > 0)
                {
                    tsbEdit.Enabled = true;
                    tsbRemove.Enabled = true;
                }
                else
                {
                    tsbEdit.Enabled = false;
                    tsbRemove.Enabled = false;
                }
            }
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmTaxSetup setup = new frmTaxSetup();
            setup.btnCreate.Text = "Create";
            DialogResult res = setup.ShowDialog();
            if (res == DialogResult.OK)
            {
                itemTaxSetup();
                tsbEdit.Enabled = false;
                tsbRemove.Enabled = false;
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmTaxSetup setup = new frmTaxSetup();
                setup.btnCreate.Text = "Update";
                int rowIndex = dgvSetup.SelectedRows[0].Index;

                setup.txtName.Text = dgvSetup.Rows[rowIndex].Cells["name"].Value.ToString();
                setup.txtPercent.Text = dgvSetup.Rows[rowIndex].Cells["percent"].Value.ToString();
                DialogResult res = setup.ShowDialog();
                if (res == DialogResult.OK)
                {
                    itemTaxSetup();
                    tsbEdit.Enabled = false;
                    tsbRemove.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Are you sure to delete setup?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    supClass.deleteItemTaxSetup("taxSetup", "Delete", Id.iGlobalID);
                    MessageBox.Show("Successfully deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    itemTaxSetup();
                    tsbEdit.Enabled = false;
                    tsbRemove.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvItemSalesTax_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void dgvSetup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbEdit.PerformClick();
        }

        private void dgvSetup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSetup.ClearSelection();
        }
    }
}
