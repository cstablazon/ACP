using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using ACP.User;

namespace ACP
{
    public partial class frmSupplierMgt : Form
    {
        supplierClass supClass = new supplierClass();
        UserPermissionManager _userPermission;
        productCreation pc = new productCreation();
        acpEntities db = new acpEntities();
        public frmSupplierMgt(int userId)
        {
            InitializeComponent();
            cmbDisplay.Text = "Distributor";
            dgvSupplier.Focus();
            //fetchRecord();
            Id.globalString = "";
            Id.groupID = "";
            _userPermission = new UserPermissionManager(userId);
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

            dgvSupplier.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSupplier.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSupplier.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSupplier.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSupplier.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSupplier.Columns[6].HeaderText = "Item tax";
            dgvSupplier.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSupplier.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public void fetchSupplier()
        {
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
                DataTable dt = supClass.fetchSupplier("fetchPrincipal2", "");
                dgvSupplier.DataSource = dt;
                dgvSupplier.Columns[8].Visible = true;
                dgvSetup();
            }
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            if (_userPermission.CanPerformOperation("Supplier Management Form", "Create"))
            {
                Id.button = "Create";
                frmAddSupplier supplier = new frmAddSupplier();

                DialogResult res = supplier.ShowDialog();
                if (res == DialogResult.OK)
                {
                    fetchSupplier();
                    //btnEdit.Enabled = false;
                    //btnSuppDel.Enabled = false;
                    //btnAddress.Enabled = false;
                    //btnContact.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("You don't have permission to create new supplier.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSupplier.SelectedRows.Count > 0)
                {
                    if (_userPermission.CanPerformOperation("Supplier Management Form", "Update"))
                    {
                        Id.button = "Update";
                        int rowIndex = dgvSupplier.SelectedRows[0].Index;
                        Id.suppID = dgvSupplier.Rows[rowIndex].Cells["Supplier_ID"].Value.ToString();
                        Id.isDistri = Convert.ToBoolean(dgvSupplier.Rows[rowIndex].Cells["isDistributor"].Value);
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
                                //btnEdit.Enabled = false;
                                //btnSuppDel.Enabled = false;
                                //btnAddress.Enabled = false;
                                //btnContact.Enabled = false;
                                //dgvSupplier.ClearSelection();
                            }
                        }
                        else
                        {
                            frmPrincipal principal = new frmPrincipal(Program.CurrentUserId);
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
                            if (res == DialogResult.OK)
                            {
                                fetchSupplier();
                                //btnEdit.Enabled = false;
                                //btnSuppDel.Enabled = false;
                                //dgvSupplier.ClearSelection();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You don't have permission to update a supplier.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        }
       
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_userPermission.CanPerformOperation("Supplier Management Form", "Delete"))
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete ?", "Delete Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (res == DialogResult.Yes)
                    {
                        DataTable dTable = supClass.ifTransExist("fetchProductBySupplier", Id.suppID);
                        if (dTable.Rows.Count > 0)
                        {
                            MessageBox.Show("Unable to delete because supplier is linked to a product", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            int rowIndex = dgvSupplier.SelectedRows[0].Index;
                            Id.suppID = dgvSupplier.Rows[rowIndex].Cells["Supplier_ID"].Value.ToString();
                            DataTable dt = supClass.getSupplierByRID("fetchSupplierByRID", Id.suppID);
                            foreach (DataRow dRow in dt.Rows)
                            {
                                string id = dRow["Supplier_ID"].ToString();
                                supClass.deleteContactByTID("ContactDIR", "deleteByTID", id);
                                supClass.deleteAddressByTID("addressDIR", "deleteByTID", id);
                            }
                            supClass.deleteSupplierByRID("Supplier", "deleteByRID", Id.suppID);
                            supClass.deleteSupplier("Supplier", "Delete", Id.suppID);
                            MessageBox.Show("Successfully deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fetchSupplier();
                            //btnEdit.Enabled = false;
                            //btnSuppDel.Enabled = false;
                            //btnAddress.Enabled = false;
                            //btnContact.Enabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You don't have permission to delete a supplier.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }

        private void btnAddPrincipal_Click(object sender, EventArgs e)
        {
            if (_userPermission.CanOpenForm("Principal Management Form"))
            {
                int rowIndex = dgvSupplier.SelectedRows[0].Index;
                if (dgvSupplier.Rows[rowIndex].Cells["isDistributor"].Value.ToString() == "True")
                {
                    Id.button = "Create";
                    Id.param = "mngmtToPrincipal";
                    Id.isDistri = Convert.ToBoolean(dgvSupplier.Rows[rowIndex].Cells["isDistributor"].Value);
                    Id.distriName = dgvSupplier.Rows[rowIndex].Cells["Name"].Value.ToString();
                    frmPrincipal principal = new frmPrincipal(Program.CurrentUserId);
                    Id.suppID = dgvSupplier.Rows[rowIndex].Cells["Supplier_ID"].Value.ToString();
                    principal.txtDistriID.Text = Id.suppID;
                    principal.lblDistriName.Text = Id.distriName;
                    principal.txtDistriName.Text = Id.distriName;
                    //principal.btnChangeDistri.Visible = false;

                    //principal.tabControl1.TabPages.RemoveAt(1);
                    //principal.tabControl1.TabPages.RemoveAt(1);

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
                    fetchSupplier();
                    //btnEdit.Enabled = false;
                    //btnSuppDel.Enabled = false;
                    //btnAddress.Enabled = false;
                    //btnContact.Enabled = false;
                    //btnAddPrincipal.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Select a distributor", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
            {
                MessageBox.Show("You don't have permission to open the form Principal.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
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
                    //btnEdit.Enabled = true;
                    //btnSuppDel.Enabled = true;
                    //btnAddress.Enabled = true;
                    //btnContact.Enabled = true;
                    Id.isDistri = Convert.ToBoolean(row.Cells["isDistributor"].Value);
                    if (row.Cells["isDistributor"].Value.ToString() == "True")
                    {
                        //btnAddPrincipal.Enabled = true;
                    }
                    else
                    {
                        //btnAddPrincipal.Enabled = false;
                    }
                }
                else
                {
                    //btnEdit.Enabled = false;
                    //btnSuppDel.Enabled = false;
                    //btnAddress.Enabled = false;
                    //btnContact.Enabled = false;
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
            //btnEdit.Enabled = false;
            //btnSuppDel.Enabled = false;
            //btnAddress.Enabled = false;
            //btnContact.Enabled = false;
            //dgvSupplier.ClearSelection();
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
            txtSearch.Focus();
        }

        private void cmbDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbDisplay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
        }

        private void btnNewProd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_userPermission.CanPerformOperation("Product Management Form", "Create"))
                {
                    Id.button = "Create";
                    int rowIndex = dgvSupplier.SelectedRows[0].Index;
                    Id.suppID = dgvSupplier.Rows[rowIndex].Cells["Supplier ID"].Value.ToString();
                    //int autoIncSKU = pc.autoInc("SKU", "product");
                    //Id.SKU = string.Format("{0:0000000}", autoIncSKU);
                    //pc.createUpdateProduct("Product", "Create", Id.SKU, Id.userID, 0, 0, null, null, null, null, false, Id.userID);
                    pc.createUpdateProduct("Create", null, null, 0, 0, 0, null, 0, null, null, false, Id.userID);
                    Id.SKU = string.Format("{0:0000000}", Convert.ToInt32(Id.autoIncSKU));
                    frmModifyProd modify = new frmModifyProd();
                    //frmNewProduct modify = new frmNewProduct();
                    modify.btnCreate.Text = "Create";
                    modify.btnClose.Text = "Cancel";
                    Id.dt.Rows.Clear();
                    Id.dt.Columns.Clear();
                    Id.isConcession = false;
                    DialogResult res = modify.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You don't have permission to create new Product.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            if (_userPermission.CanOpenForm("Address Management Form"))
            {
                Id.button = "Create";
                int rowIndex = dgvSupplier.SelectedRows[0].Index;
                Id.suppID = dgvSupplier.Rows[rowIndex].Cells["Supplier_ID"].Value.ToString();
                frmNewAddress address = new frmNewAddress();
                address.btnCreate.Text = "Create";
                address.ShowDialog();
            }
            else
            {
                MessageBox.Show("You don't have permission to open the form Address.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            if (_userPermission.CanOpenForm("Contact Management Form"))
            {
                Id.button = "Create";
                int rowIndex = dgvSupplier.SelectedRows[0].Index;
                Id.suppID = dgvSupplier.Rows[rowIndex].Cells["Supplier_ID"].Value.ToString();
                frmNewContact contact = new frmNewContact();
                contact.btnCreate.Text = "Create";
                contact.ShowDialog();
            }
            else
            {
                MessageBox.Show("You don't have permission to open the form Contact.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
