using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace ACP
{
    public partial class frmSupplierMgt : Form
    {
        supplierClass supClass = new supplierClass(); 
        acpEntities db = new acpEntities();
        public frmSupplierMgt()
        {
            InitializeComponent();
            cmbDisplay.Text = "Distributor";
            dgvSupplier.Focus();
            //fetchRecord();
            Id.globalString = "";
            Id.groupID = "";
        }
        private void frmSupplierMgt_Load(object sender, EventArgs e)
        {

        }

        public void dgvSetup()
        {
            //DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            //checkbox.ValueType = typeof(bool);
            //checkbox.Name = "cbDistri";
            //checkbox.HeaderText = "Distributor";
            //dgvSupplier.Columns.RemoveAt(8);
            //dgvSupplier.Columns.Insert(8, checkbox);
            //dgvSupplier.Columns[8].DataPropertyName = "isDistributor";

            //DataGridViewCheckBoxColumn cbActive = new DataGridViewCheckBoxColumn();
            //cbActive.ValueType = typeof(bool);
            //cbActive.Name = "cbActive";
            //cbActive.HeaderText = "Active";
            //dgvSupplier.Columns.RemoveAt(9);
            //dgvSupplier.Columns.Insert(9, cbActive);
            //dgvSupplier.Columns[9].DataPropertyName = "isActive";

            dgvSupplier.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[6].HeaderText = "Item tax";
            dgvSupplier.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        public void fetchSupplier()
        {
            
            btnAddPrincipal.Enabled = false;
            btnSuppDel.Enabled = false; 
            if (cmbDisplay.Text == "All")
            {
                DataTable dt = supClass.fetchSupplier("fetchSupplier", "");
                dgvSupplier.DataSource = dt;
                dgvSupplier.Columns[8].Visible = true;
                dgvSetup();
            }
            else if (cmbDisplay.Text == "Distributor")
            {
                DataTable dt = supClass.fetchSupplier("fetchDistributor", "");
                dgvSupplier.DataSource = dt;
                dgvSupplier.Columns[8].Visible = false;
                dgvSetup();
            }
            else
            {
                DataTable dt = supClass.fetchSupplier("fetchPrincipal", "");
                dgvSupplier.DataSource = dt;
                dgvSupplier.Columns[8].Visible = true;
                dgvSetup();
            }
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            Id.button = "Create";
            frmAddSupplier supplier = new frmAddSupplier();

            DialogResult res = supplier.ShowDialog();
            if(res == DialogResult.OK)
            {
                fetchSupplier();
                btnEdit.Enabled = false;
                btnSuppDel.Enabled = false;
                btnAddress.Enabled = false;
                btnContact.Enabled = false;
            }
        }

        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                Id.button = "Update";

                if (Id.isDistri == true)
                {
                    frmAddSupplier supplier = new frmAddSupplier();
                    DataTable dt = supClass.getSupplierById("fetchSupplierById", Id.suppID);
                    foreach (DataRow row in dt.Rows)
                    {
                        supplier.cmbGroup.Text = row["Group"].ToString();
                        supplier.cmbPayTerms.Text = row["Payment_term"].ToString();
                        supplier.txtSupCode.Text = row["Supplier_ID"].ToString();
                        supplier.cmbType.Text = row["Record_type"].ToString();
                        supplier.cmbItemTax.Text = row["itemTaxID"].ToString();
                        supplier.txtName.Text = row["Name"].ToString();
                        supplier.txtAgent.Text = row["Agent"].ToString();
                    }
                    DialogResult res = supplier.ShowDialog();

                    if (res == DialogResult.OK)
                    {
                        fetchSupplier();
                        btnEdit.Enabled = false;
                        btnSuppDel.Enabled = false;
                        btnAddress.Enabled = false;
                        btnContact.Enabled = false;
                        dgvSupplier.ClearSelection();
                    }
                }
                else
                {
                    frmPrincipal principal = new frmPrincipal();
                    DataTable dt = supClass.getSupplierById("fetchPrincipalById", Id.suppID);
                    foreach (DataRow row in dt.Rows)
                    {
                        principal.tabControl1.TabPages.RemoveAt(0);
                        principal.txtDistriID.Text = row["RID"].ToString();
                        principal.txtDistriName.Text = row["Distributor"].ToString();
                        principal.txtSupCode.Text = row["Supplier_ID"].ToString();
                        principal.cmbPayTerms.Text = row["Payment_term"].ToString();
                        principal.txtName.Text = row["Name"].ToString();
                        principal.txtAgent.Text = row["Agent"].ToString();
                    }
                    DialogResult res = principal.ShowDialog();
                    if(res == DialogResult.OK)
                    {
                        fetchSupplier();
                        btnEdit.Enabled = false;
                        btnSuppDel.Enabled = false;
                        dgvSupplier.ClearSelection();
                    }
                }
            }
        }

        private void viewSupplier(string suppID) {
            frmAddSupplier supplier = new frmAddSupplier();
                DataTable dt = supClass.getSuppByID(suppID);
                supplier.txtSupCode.Enabled = false;
                foreach (DataRow rows in dt.Rows)
                {
                    supplier.txtSupCode.Text = rows["suppID"].ToString();
                    supplier.txtName.Text = rows["name"].ToString();
                    //supplier.txtAgent.Text = rows["agent"].ToString();
                    supplier.cmbType.Text = rows["suppRtype"].ToString();
                    supplier.cmbPayTerms.Text = Id.payID.ToString();
                    supplier.cmbGroup.Text = Id.groupID;
                    //supplier.txtFn.Text = rows["firstname"].ToString();
                    //supplier.txtMn.Text = rows["middlename"].ToString();
                    //supplier.txtLn.Text = rows["lastname"].ToString();
                    //supplier.txtSuffix.Text = rows["suffix"].ToString();
                    

                    //gender = rows["gender"].ToString();
            }
        }

        private void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dgvSupplier.Rows[e.RowIndex];
            //    Id.suppID = row.Cells["supplier_ID"].Value.ToString();
            //    Id.isActive = Convert.ToBoolean(row.Cells["cbActive"].Value);
            //    Id.distriName = row.Cells["Name"].Value.ToString();
            //    if (cmbDisplay.Text == "All")
            //    {
            //        Id.isDistri = Convert.ToBoolean(row.Cells["cbDistri"].Value);
            //    }
            //    btnSuppDel.Enabled = true;
            //    if (cmbDisplay.Text == "All")
            //    {
            //        if (row.Cells["cbDistri"].Value.ToString() == "True")
            //        {
            //            btnAddPrincipal.Enabled = true;
            //        }
            //        else
            //        {
            //            btnAddPrincipal.Enabled = false;
            //        }
            //    }
            //    else if (cmbDisplay.Text == "Distributor")
            //    {
            //        btnAddPrincipal.Enabled = true;
            //    }
            //}
            btnEdit.PerformClick();
        }

        private void dgvSupplier_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           dgvSupplier.ClearSelection();
        }
       
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to delete ?", "Delete Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                supClass.deleteSupplier("Supplier", "Delete", Id.suppID);

                MessageBox.Show("Successfully deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fetchSupplier();
                btnEdit.Enabled = false;
                btnSuppDel.Enabled = false;
                btnAddress.Enabled = false;
                btnContact.Enabled = false;
            }
        }

        int x, y;
        string pName;
        int w, h;
        int oW, oH;
        public void redBorder()
        {
            Panel p = new Panel();
            p.Name = pName;
            p.Size = new System.Drawing.Size(w, h);
            p.Location = new Point(x, y);
            p.BackColor = Color.Crimson;
            p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            header.Controls.Add(p);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(cmbDisplay.Text.Equals("Distributor"))
            {
                if(cmbSearchFilter.Text.Equals(""))
                {
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        pName = "txtSearchError";
                        oW = cmbSearchFilter.Size.Width;
                        oH = cmbSearchFilter.Size.Height;
                        x = cmbSearchFilter.Location.X - 2;
                        y = cmbSearchFilter.Location.Y - 2;
                        w = oW + 4;
                        h = oH + 4;
                        redBorder();
                        cmbSearchFilter.FlatStyle = FlatStyle.Flat;
                    }
                    else
                    {
                        header.Controls.RemoveByKey("txtSearchError");
                        cmbSearchFilter.FlatStyle = FlatStyle.Standard;
                    }
                }
                else if(cmbSearchFilter.Text.Equals("Supplier ID"))
                {
                        dgvSupplier.DataSource = (from a in db.vwDistributors
                                                  where a.Supplier_ID.Contains(txtSearch.Text)
                                                  select new
                                                  {
                                                      a.Supplier_ID,
                                                      a.Name,
                                                      a.Agent,
                                                      a.Record_type,
                                                      a.Group,
                                                      a.Payment_term,
                                                      a.itemTaxID,
                                                      a.Date_created,
                                                      a.isDistributor,
                                                      a.isActive
                                                  }).ToList();
                }
                else if(cmbSearchFilter.Text.Equals("Name"))
                {
                        dgvSupplier.DataSource = (from a in db.vwDistributors
                                                  where a.Name.Contains(txtSearch.Text)
                                                  select new
                                                  {
                                                      a.Supplier_ID,
                                                      a.Name,
                                                      a.Agent,
                                                      a.Record_type,
                                                      a.Group,
                                                      a.Payment_term,
                                                      a.itemTaxID,
                                                      a.Date_created,
                                                      a.isDistributor,
                                                      a.isActive
                                                  }).ToList();
                }
            }
            else if(cmbDisplay.Text.Equals("Principal"))
            {
                if(cmbSearchFilter.Text == "")
                {
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        pName = "txtSearchError";
                        oW = cmbSearchFilter.Size.Width;
                        oH = cmbSearchFilter.Size.Height;
                        x = cmbSearchFilter.Location.X - 2;
                        y = cmbSearchFilter.Location.Y - 2;
                        w = oW + 4;
                        h = oH + 4;
                        redBorder();
                        cmbSearchFilter.FlatStyle = FlatStyle.Flat;
                    }
                    else
                    {
                        header.Controls.RemoveByKey("txtSearchError");
                        cmbSearchFilter.FlatStyle = FlatStyle.Standard;
                    }
                }
                else if(cmbSearchFilter.Text.Equals("Supplier ID"))
                {
                        dgvSupplier.DataSource = (from a in db.vwPrincipals where a.Supplier_ID.Contains(txtSearch.Text)
                                                  select new
                                                  {
                                                      a.Supplier_ID,
                                                      a.Name,
                                                      a.Agent,
                                                      a.Record_type,
                                                      a.Group,
                                                      a.Payment_term,
                                                      a.itemTaxID,
                                                      a.Date_created,
                                                      a.isDistributor,
                                                      a.isActive
                                                  }).ToList();
                }
                else if(cmbSearchFilter.Text.Equals("Name"))
                {
                        dgvSupplier.DataSource = (from a in db.vwPrincipals
                                                  where a.Name.Contains(txtSearch.Text)
                                                  select new
                                                  {
                                                      a.Supplier_ID,
                                                      a.Name,
                                                      a.Agent,
                                                      a.Record_type,
                                                      a.Group,
                                                      a.Payment_term,
                                                      a.itemTaxID,
                                                      a.Date_created,
                                                      a.isDistributor,
                                                      a.isActive
                                                  }).ToList();
                }
            }
            else if(cmbDisplay.Text.Equals("All"))
            {
                if(cmbSearchFilter.Text.Equals(""))
                {
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        pName = "txtSearchError";
                        oW = cmbSearchFilter.Size.Width;
                        oH = cmbSearchFilter.Size.Height;
                        x = cmbSearchFilter.Location.X - 2;
                        y = cmbSearchFilter.Location.Y - 2;
                        w = oW + 4;
                        h = oH + 4;
                        redBorder();
                        cmbSearchFilter.FlatStyle = FlatStyle.Flat;
                    }
                    else
                    {
                        header.Controls.RemoveByKey("txtSearchError");
                        cmbSearchFilter.FlatStyle = FlatStyle.Standard;
                    }
                }
                else if(cmbSearchFilter.Text.Equals("Supplier ID"))
                {
                    dgvSupplier.DataSource = (from a in db.vwSuppliers where a.Supplier_ID.Contains(txtSearch.Text)
                                              select new
                                              {
                                                  a.Supplier_ID,
                                                  a.Name,
                                                  a.Agent,
                                                  a.Record_type,
                                                  a.Group,
                                                  a.Payment_term,
                                                  a.itemTaxID,
                                                  a.Date_created,
                                                  a.isDistributor,
                                                  a.isActive
                                              }).ToList();
                }
                else if(cmbSearchFilter.Text.Equals("Name"))
                {
                    dgvSupplier.DataSource = (from a in db.vwSuppliers where a.Name.Contains(txtSearch.Text)
                                              select new
                                              {
                                                  a.Supplier_ID,
                                                  a.Name,
                                                  a.Agent,
                                                  a.Record_type,
                                                  a.Group,
                                                  a.Payment_term,
                                                  a.itemTaxID,
                                                  a.Date_created,
                                                  a.isDistributor,
                                                  a.isActive
                                              }).ToList();
                }
            }
        }

        private void cmbDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Id.param == "distriToPrincipal")
            {

            }
            else
            {
                fetchSupplier();
                dgvSupplier.ClearSelection();
            }
        }

        private void btnAddPrincipal_Click(object sender, EventArgs e)
        {
            Id.button = "Create";
            Id.param = "mngmtToPrincipal";
            frmPrincipal principal = new frmPrincipal();
            principal.txtDistriID.Text = Id.suppID;
            principal.lblDistriName.Text = Id.distriName;
            principal.txtDistriName.Text = Id.distriName;
            //principal.btnChangeDistri.Visible = false;
<<<<<<< HEAD
            //principal.tabControl1.TabPages.RemoveAt(1);
            //principal.tabControl1.TabPages.RemoveAt(1);
=======
>>>>>>> main
            principal.btnClear.Location = new Point(769, 15);
            principal.btnSave.Location = new Point(769, 55);
            //principal.dgvPrincipal.DataSource = (from a in db.vwPrincipals
            //                           where a.RID.Equals(Id.suppID)
            //                           select new
            //                           {
            //                               a.Supplier_ID,
            //                               a.Name,
            //                               a.Agent,
            //                               a.Date_created,
            //                               a.isActive
            //                           }).ToList();


            principal.ShowDialog();
            btnEdit.Enabled = false;
            btnSuppDel.Enabled = false;
            btnAddress.Enabled = false;
            btnContact.Enabled = false;
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSupplier.Rows[e.RowIndex];
                Id.suppID = row.Cells["supplier_ID"].Value.ToString();
                Id.isActive = Convert.ToBoolean(row.Cells["isActive"].Value);
                Id.distriName = row.Cells["Name"].Value.ToString();
                if (dgvSupplier.SelectedRows.Count > 0)
                {
                    btnEdit.Enabled = true;
                    btnSuppDel.Enabled = true;
                    btnAddress.Enabled = true;
                    btnContact.Enabled = true;
                    Id.isDistri = Convert.ToBoolean(row.Cells["isDistributor"].Value);
                    if (row.Cells["isDistributor"].Value.ToString() == "True")
                    {
                        btnAddPrincipal.Enabled = true;
                    }
                    else
                    {
                        btnAddPrincipal.Enabled = false;
                    }
                }
                else
                {
                    btnEdit.Enabled = false;
                    btnSuppDel.Enabled = false;
                    btnAddress.Enabled = false;
                    btnContact.Enabled = false;
                }
            }
        }

        private void cmsStatus_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(dgvSupplier.SelectedRows.Count > 0 )
            {
                if(Id.isActive.Equals(true))
                {
                    setAsActiveToolStripMenuItem.Enabled = false;
                    setAsInactiveToolStripMenuItem.Enabled = true;
                }
                else
                {
                    setAsActiveToolStripMenuItem.Enabled = true;
                    setAsInactiveToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                setAsActiveToolStripMenuItem.Enabled = false;
                setAsInactiveToolStripMenuItem.Enabled = false;
            }
        }

        private void setAsActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var setAsActive = (from a in db.suppliers where a.suppID == Id.suppID select a).FirstOrDefault();

            setAsActive.isActive = true;

            db.SaveChanges();
            MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fetchSupplier();
        }

        private void setAsInactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var setAsInactive = (from a in db.suppliers where a.suppID == Id.suppID select a).FirstOrDefault();

            setAsInactive.isActive = false;

            db.SaveChanges();
            MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fetchSupplier();
        }

        private void dgvSupplier_Paint(object sender, PaintEventArgs e)
        {
            foreach(DataGridViewColumn col in dgvSupplier.Columns)
            {
                col.HeaderText = col.HeaderText.Replace("_", " ");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fetchSupplier();
            btnEdit.Enabled = false;
            btnSuppDel.Enabled = false;
            btnAddress.Enabled = false;
            btnContact.Enabled = false;
            dgvSupplier.ClearSelection();
        }

        private void dgvSupplier_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if(e.RowIndex >= 0)
                {
                    this.dgvSupplier.Rows[e.RowIndex].Selected = true;
                    DataGridViewRow row = this.dgvSupplier.Rows[e.RowIndex];

                    Id.suppID = row.Cells["Supplier_ID"].Value.ToString();
                    Id.isActive = Convert.ToBoolean(row.Cells["isActive"].Value);
                }
            }
        }

        private void cmbSearchFilter_MouseHover(object sender, EventArgs e)
        {
            if (cmbSearchFilter.FlatStyle == FlatStyle.Flat)
            {
                toolTip1.Show("Please select search filter", cmbSearchFilter);
            }
            else
            {
                toolTip1.Hide(cmbSearchFilter);
            }
        }

        private void cmbSearchFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbSearchFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            header.Controls.RemoveByKey("txtSearchError");
            cmbSearchFilter.FlatStyle = FlatStyle.Standard;
            txtSearch.Clear();
        }

        private void cmbDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbDisplay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void btnNewProd_Click(object sender, EventArgs e)
        {
            frmModifyProd product = new frmModifyProd();
            product.txtSupplier.Text = Id.suppID;
            product.ShowDialog();
        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            Id.button = "Create";
            frmNewAddress address = new frmNewAddress();
            address.btnCreate.Text = "Create";
            address.ShowDialog();
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            Id.button = "Create";
            frmNewContact contact = new frmNewContact();
            contact.btnCreate.Text = "Create";
            contact.ShowDialog();
        }
    }
}
