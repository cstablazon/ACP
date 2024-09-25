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
    public partial class frmPrincipal : Form
    {
        acpEntities db = new acpEntities();
        supplierClass supClass = new supplierClass();
        TextInfo txtInfo = CultureInfo.CurrentCulture.TextInfo;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        

        public void payTerms()
        {
            //cmbPayTerms.DataSource = (from a in db.paymentTerms select a).ToList();
            //cmbPayTerms.ValueMember = "payID";
            //cmbPayTerms.DisplayMember = "payDesc";
            //cmbPayTerms.Text = "";
        }

        string currentMaxID;
        public void autoInc()
        {
           // var inc = (from a in db.suppliers where a.isDistributor == false select a).Max(b => Int32.Parse(b.suppID));
           // currentID = Convert.ToInt32(inc) + 1;
           //txtSupCode.Text = currentID.ToString();
            //var inc = db.sp_autoInc("Principal");
            //txtSupCode.Text = inc.FirstOrDefault().Value.ToString();
            //string currentMaxID = inc.FirstOrDefault().Value.ToString();

            int inc = supClass.autoIncrementID("suppID", "supplier");
            txtSupCode.Text = inc.ToString();

        }

        private void noPrincipal()
        {
            if(dgvPrincipal.Rows.Count > 0)
            {
                btnCdistri.Enabled = true;
                btnSelect.Enabled = true;
            }
            else
            {
                btnCdistri.Enabled = false;
                btnSelect.Enabled = false;
            }
        }
        private void blankCMB()
        {
            //if(Id.button.Equals("Create"))
            //{
            //    cmbPayTerms.Text = "";
            //}
        }
        
        private void fetchPrincipal()
        {
            if (Id.button == "Create")
            {
                DataTable dt = supClass.fetchSupplier("fetchPrincipal", txtDistriID.Text);
                dgvPrincipal.DataSource = dt;
                dgvPrincipal.AutoGenerateColumns = false;
                dgvPrincipal.Columns[3].Visible = false;
                dgvPrincipal.Columns[4].Visible = false;
                dgvPrincipal.Columns[5].Visible = false;
                dgvPrincipal.Columns[6].Visible = false;
                dgvPrincipal.Columns[8].Visible = false;
            }
            ////DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            ////checkbox.ValueType = typeof(bool);
            ////checkbox.Name = "cbActive";
            ////checkbox.HeaderText = "Active";
            ////dgvPrincipal.Columns.RemoveAt(4);
            ////dgvPrincipal.Columns.Insert(4, checkbox);
            ////dgvPrincipal.Columns[4].DataPropertyName = "isActive";
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //fetchPrincipal();
            fetchPrincipal();
            noPrincipal();
            blankCMB();
            dgvPrincipal.ClearSelection();
            if(Id.button == "Create")
            {
                btnSave.Text = "Create";
                autoInc();
            }
            else
            {
                btnSave.Text = "Update";
            }
        }
        public void clear()
        {
            cmbPayTerms.Text = "";
            autoInc();
            txtAgent.Clear();
            txtName.Clear();
        }

        string itemTaxId;
        int? paytermId;
        int? suppGroupId;
        string suppRtype;
        string suppRID;
        bool isDistributor;
        bool isActive;
        int? userID;
        public void createUpdate()
        {
            if (txtSupCode.Text.Equals(""))
            {
                MessageBox.Show("Supplier code is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtName.Text.Equals(""))
            {
                MessageBox.Show("Supplier name is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string agent;
                if (Id.button.Equals("Create"))
                {
                    int? payID;
                    if (!string.IsNullOrEmpty(cmbPayTerms.Text) || !string.IsNullOrWhiteSpace(cmbPayTerms.Text))
                    {
                        payID = Convert.ToInt32(cmbPayTerms.SelectedValue);
                    }
                    else
                    {
                        payID = null;
                    }
                    supClass.createUpdateSupplier("Supplier", "Create", txtSupCode.Text, null, payID, null, txtInfo.ToTitleCase(txtName.Text), null, txtInfo.ToTitleCase(txtAgent.Text), txtDistriID.Text, false, true, Id.userID);

                    fetchPrincipal();
                    autoInc();
                    noPrincipal();
                    blankCMB();
                    txtName.Clear();
                    txtAgent.Clear();
                }
                else if (Id.button.Equals("Update"))
                {
                    if (string.IsNullOrEmpty(txtName.Text))
                    {
                        MessageBox.Show("Name is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtName.Focus();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(currentMaxID))
                        {
                            int payID = Convert.ToInt32(cmbPayTerms.SelectedValue);
                            DataTable dt = supClass.getSupplierById("fetchSupplierById", txtSupCode.Text);
                            foreach (DataRow row in dt.Rows)
                            {
                                itemTaxId = row["itemTaxID"].ToString();
                                if (!string.IsNullOrEmpty(row["payID"] as string))
                                {
                                    paytermId = Convert.ToInt32(row["payID"]);
                                }
                                else
                                {
                                    paytermId = null;
                                }
                                suppGroupId = null;
                                suppRtype = row["Record_type"].ToString();
                                suppRID = row["RID"].ToString();
                                isDistributor = Convert.ToBoolean(row["isDistributor"]);
                                isActive = Convert.ToBoolean(row["isActive"]);
                                userID = Convert.ToInt32(row["userID"]);
                            }
                            supClass.createUpdateSupplier("Supplier", "Update", txtSupCode.Text, itemTaxId, paytermId, suppGroupId, txtInfo.ToTitleCase(txtName.Text), suppRtype, txtInfo.ToTitleCase(txtAgent.Text), txtDistriID.Text, isDistributor, isActive, userID);

                            this.DialogResult = DialogResult.OK;
                            this.Hide();
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtAgent.Text))
                            {
                                agent = txtAgent.Text;
                            }
                            else
                            {
                                agent = char.ToUpper(txtAgent.Text[0]) + txtAgent.Text.Substring(1);
                            }
                            //payID = Convert.ToInt32(cmbPayTerms.GetItemText(cmbPayTerms.SelectedValue));
                            var objUpdate = db.suppliers.Where(a => a.suppID == Id.principalID).SingleOrDefault();
                            //objUpdate.payID = payID;
                            objUpdate.name = char.ToUpper(txtName.Text[0]) + txtName.Text.Substring(1);
                            objUpdate.agent = agent;

                            db.SaveChanges();
                            fetchPrincipal();
                            txtName.Clear();
                            txtAgent.Clear();
                            autoInc();
                            noPrincipal();
                            blankCMB();
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            createUpdate();
        }

        private void dgvPrincipal_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPrincipal.ClearSelection();
        }

        private void dgvPrincipal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPrincipal.Rows[e.RowIndex];
                Id.principalID = row.Cells["Supplier_ID"].Value.ToString();
                Id.isActive = Convert.ToBoolean(row.Cells["isActive"].Value.ToString());

                if(dgvPrincipal.SelectedRows.Count > 0)
                {
                    btnEdit.Enabled = true;
                    btnDel.Enabled = true;
                }
                else
                {
                    btnEdit.Enabled = false;
                    btnDel.Enabled = false;
                }
            }
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvPrincipal.SelectedRows.Count > 0)
            {
                btnSave.Text = "Update";
                Id.button = "Update";
                if(dgvPrincipal.SelectedRows.Count > 0)
                {
                    int rowIndex = dgvPrincipal.SelectedRows[0].Index;

                    txtSupCode.Text = dgvPrincipal.Rows[rowIndex].Cells["Supplier_ID"].Value.ToString();
                    cmbPayTerms.Text = dgvPrincipal.Rows[rowIndex].Cells["Payment_term"].Value.ToString();
                    txtName.Text = dgvPrincipal.Rows[rowIndex].Cells["Name"].Value.ToString();
                    txtAgent.Text = dgvPrincipal.Rows[rowIndex].Cells["Agent"].Value.ToString();
                }
                //var editPrincipal = (from a in db.vwPrincipals where a.Supplier_ID == Id.principalID select a).SingleOrDefault();

                ////cmbPayTerms.Text = editPrincipal.Payment_term;
                //txtSupCode.Text = editPrincipal.Supplier_ID;
                //txtName.Text = editPrincipal.Name;
                //txtAgent.Text = editPrincipal.Agent;
            }
            else
            {
                MessageBox.Show("Please select principal to edit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Create";
            autoInc();
            txtName.Clear();
            txtAgent.Clear();
        }

        private void cmsStatus_Opening(object sender, CancelEventArgs e)
        {
            if(dgvPrincipal.SelectedRows.Count > 0)
            {
                if (Id.isActive == true)
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
            var setAsActive = (from a in db.suppliers where a.suppID == Id.principalID select a).SingleOrDefault();

            setAsActive.isActive = true;

            db.SaveChanges();
            MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fetchPrincipal();
        }

        private void setAsInactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var setAsInactive = (from a in db.suppliers where a.suppID == Id.principalID select a).SingleOrDefault();

            setAsInactive.isActive = false;

            db.SaveChanges();
            MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            fetchPrincipal();
        }

        Panel p = new Panel();
        ComboBox cmbFilter = new ComboBox();
        TextBox txtSearch = new TextBox();
        public void supplierForm()
        {
            p.Name = "pSupplier";
            p.Size = new System.Drawing.Size(335, 279);
            p.Location = new Point(410, 21);
            p.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            //groupBox1.Controls.Add(p);
            p.BringToFront();

            DataTable dt = supClass.getRecords("Supplier", "changeDistributor", txtDistriID.Text, "");
            dgvSupplier.DataSource = dt;

            //dgvSupplier.DataSource = (from a in db.vwDistributors
            //                          where a.isActive == true && a.Supplier_ID != txtDistriID.Text
            //                          select new
            //                          {
            //                              a.Supplier_ID,
            //                              a.Name
            //                          }).ToList();
            
            cmbFilter.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            cmbFilter.Size = new System.Drawing.Size(90, 25);
            cmbFilter.Dock = DockStyle.Top;
            cmbFilter.BringToFront();
            txtSearch.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            txtSearch.Size = new System.Drawing.Size(139, 25);
            txtSearch.Dock = DockStyle.Top;
            txtSearch.BringToFront();
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("Supplier_ID");
            cmbFilter.Items.Add("Name");

            //dgvSupplier.Dock = DockStyle.Fill;
            dgvSupplier.BringToFront();
            dgvSupplier.AllowUserToAddRows = false;
            dgvSupplier.AllowUserToDeleteRows = false;
            dgvSupplier.ReadOnly = true;
            dgvSupplier.MultiSelect = false;
            dgvSupplier.RowHeadersVisible = false;
            dgvSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvSupplier.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSupplier.DataBindingComplete += dgvSupplier_DataBindingComplete;
            dgvSupplier.CellDoubleClick += dgvSupplier_CellDoubleClick;
            dgvSupplier.CellClick += dgvSupplier_CellClick;
            txtSearch.TextChanged += txtSearch_TextChanged;
            cmbFilter.KeyPress += cmbFilter_KeyPress;
            cmbFilter.SelectionChangeCommitted += cmbFilter_SelectionChangeCommitted;
            p.Controls.Add(txtSearch);
            p.Controls.Add(cmbFilter);
            p.Controls.Add(dgvSupplier);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            if(cmbFilter.Text.Equals(""))
            {
                MessageBox.Show("Please select search filter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Clear();
            }
            else if(cmbFilter.Text.Equals("Supplier_ID"))
            {
                if (txtSearch.Text.Equals(""))
                {
                    dgvSupplier.DataSource = (from a in db.vwDistributors
                                              select new
                                              {
                                                  a.Supplier_ID,
                                                  a.Name
                                              }).ToList();
                }
                else
                {
                    dgvSupplier.DataSource = (from a in db.vwDistributors
                                              where a.Supplier_ID.Contains(txtSearch.Text)
                                              select new
                                              {
                                                  a.Supplier_ID,
                                                  a.Name
                                              }).ToList();
                }
            }
            else if(cmbFilter.Text.Equals("Name"))
            {
                if (txtSearch.Text.Equals(""))
                {
                    dgvSupplier.DataSource = (from a in db.vwDistributors
                                              select new
                                              {
                                                  a.Supplier_ID,
                                                  a.Name
                                              }).ToList();
                }
                else
                {
                    dgvSupplier.DataSource = (from a in db.vwDistributors
                                              where a.Name.Contains(txtSearch.Text)
                                              select new
                                              {
                                                  a.Supplier_ID,
                                                  a.Name
                                              }).ToList();
                }
            }
        }

        private void cmbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        DataGridView dgvSupplier = new DataGridView();
        private void txtDistriName_Click(object sender, EventArgs e)
        {
            //if(Id.button.Equals("Create"))
            //{
            //    supplierForm();
            //}
        }

        private void dgvSupplier_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSupplier.ClearSelection();
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSupplier.Rows[e.RowIndex];

                Id.globalID = row.Cells["Supplier_ID"].Value.ToString();
                Id.globalString = row.Cells["Name"].Value.ToString();
            }
        }

        private void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //if (btnChangeDistri.Visible == true)
                //{
                //    DataGridViewRow row = this.dgvSupplier.Rows[e.RowIndex];

                //    txtDistriID.Text = row.Cells["Supplier_ID"].Value.ToString();
                //    txtDistriName.Text = row.Cells["Name"].Value.ToString();
                //    txtDistriName.BorderStyle = BorderStyle.None;
                //    groupBox1.Controls.RemoveByKey("pSupplier");
                //    //if(Id.button.Equals("changeDistri"))
                //    //{
                //    //    //Do nothing
                //    //}
                //    //else
                //    //{
                //    //    //fetchPrincipal();
                //    //}
                //}
            }
        }

        private void txtDistriName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtDistriName_DoubleClick(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtDistriName.Text))
            {
                groupBox1.Controls.RemoveByKey("pSupplier");
                txtDistriName.SelectAll();
                Id.suppID = txtDistriID.Text;
                Id.button = "Update";

                frmAddSupplier addSupp = new frmAddSupplier();
                var objEditSupp = db.vwDistributors.Where(a => a.Supplier_ID.Equals(Id.suppID)).SingleOrDefault();

                addSupp.txtSupCode.Text = objEditSupp.Supplier_ID;
                addSupp.cmbGroup.Text = objEditSupp.Group;
                addSupp.cmbType.Text = objEditSupp.Record_type;
                addSupp.cmbPayTerms.Text = objEditSupp.Payment_term;
                addSupp.txtName.Text = objEditSupp.Name;
                addSupp.txtAgent.Text = objEditSupp.Agent;

                DialogResult res = addSupp.ShowDialog();
                if(res == DialogResult.OK)
                {
                    Id.suppID = addSupp.txtSupCode.Text;
                    txtDistriID.Text = addSupp.txtSupCode.Text;
                    txtDistriName.Text = addSupp.txtName.Text;
                }
                //frmSupplierMgt mngmt = new frmSupplierMgt();
                //mngmt.WindowState = FormWindowState.Normal;
                //mngmt.ControlBox = true;
                //mngmt.dgvSupplier.DataSource = (from a in db.vwDistributors
                //                                where a.Supplier_ID == txtDistriID.Text
                //                                select new 
                //                                {
                //                                    a.Supplier_ID,
                //                                    a.Name,
                //                                    a.Record_type,
                //                                    a.Group,
                //                                    a.Payment_term,
                //                                    a.Date_created,
                //                                    a.isDistributor,
                //                                    a.isActive
                //                                }).ToList();
                //DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
                //checkbox.ValueType = typeof(bool);
                //checkbox.Name = "cbDistri";
                //checkbox.HeaderText = "Distributor";
                //mngmt.dgvSupplier.Columns.RemoveAt(6);
                //mngmt.dgvSupplier.Columns.Insert(6, checkbox);
                //mngmt.dgvSupplier.Columns[6].DataPropertyName = "isDistributor";
                //DataGridViewCheckBoxColumn cbActive = new DataGridViewCheckBoxColumn();
                //cbActive.ValueType = typeof(bool);
                //cbActive.Name = "cbActive";
                //cbActive.HeaderText = "Active";
                //mngmt.dgvSupplier.Columns.RemoveAt(7);
                //mngmt.dgvSupplier.Columns.Insert(7, cbActive);
                //mngmt.dgvSupplier.Columns[7].DataPropertyName = "isActive";
                //mngmt.btnAdd.Enabled = false;
                //mngmt.btnAddPrincipal.Visible = false;
                //mngmt.lblDisplay.Visible = false;
                //mngmt.lblSearch.Visible = false;
                //mngmt.cmbDisplay.Visible = false;
                //mngmt.txtSearch.Visible = false;
                //mngmt.ShowDialog();



                //groupBox1.Controls.RemoveByKey("pSupplier");
                //txtDistriName.SelectAll();

                //frmAddSupplier supp = new frmAddSupplier();

                //var distri = (from a in db.vwDistributors where a.Supplier_ID == Id.suppID select a).SingleOrDefault();

                //supp.cmbGroup.Enabled = false;
                //supp.cmbType.Enabled = false;
                //supp.cmbPayTerms.Enabled = false;
                //supp.txtSupCode.Enabled = false;
                //supp.txtAgent.Enabled = false;
                //supp.txtName.Enabled = false;
                //supp.btnAddPrincipal.Visible = false;
                //supp.btnClear.Visible = false;
                //supp.btnSave.Visible = false;

                //supp.cmbGroup.Text = distri.Group;
                //supp.cmbType.Text = distri.Record_type;
                //supp.cmbPayTerms.Text = distri.Payment_term;
                //supp.txtSupCode.Text = distri.Supplier_ID;
                //supp.txtAgent.Text = distri.agent;
                //supp.txtName.Text = distri.Name;

                //supp.ShowDialog();
            }
        }

        public bool checkOpen(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }

            }
            return false;
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Id.param == "distriToPrincipal")
            {
                if (Application.OpenForms.OfType<frmAddSupplier>().Count() >= 1)
                    Application.OpenForms.OfType<frmAddSupplier>().First().Close();

                frmAddSupplier addSupp = new frmAddSupplier();
                this.Hide();
                addSupp.ShowDialog();
            }
        }

        CheckBox headerCB = null;
        bool isHeaderCBclicked = false;
        private void headerCheckBox()
        {
            headerCB = new CheckBox();
            headerCB.Size = new Size(15, 15);
            this.dgvPrincipal.Controls.Add(headerCB);
            Rectangle rect = dgvPrincipal.GetCellDisplayRectangle(0, -1, false);
            rect.X = rect.Location.X + (rect.Width / 6);
            rect.Y = rect.Location.Y + (rect.Height / 4);
            headerCB.Location = rect.Location;
        }

        //private void changeDistri()
        //{
        //    if (tabControl1.TabPages.Contains(tabPage1))
        //    {
        //        btnChangeDistri.Visible = false;
        //        btnCdistri.Visible = true;
        //        btnClear.Location = new Point(769, 15);
        //        btnSave.Location = new Point(769, 55);
        //    }
        //    else
        //    {
        //        btnClear.Location = new Point(769, 95);
        //        btnSave.Location = new Point(769, 135);
        //        if (btnChangeDistri.Text.Equals("Change distributor"))
        //        {
        //            supplierForm();
        //            groupBox1.Controls.Add(p);
        //            dgvSupplier.Dock = DockStyle.Bottom;
        //            dgvSupplier.Size = new System.Drawing.Size(230, 229);
        //            dgvSupplier.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //            dgvSupplier.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        //            p.BringToFront();
        //            p.BorderStyle = BorderStyle.FixedSingle;
        //            btnChangeDistri.Text = "Cancel";
        //            //Id.button = "changeDistri";
        //            btnSave.Text = "Update";
        //            btnClear.Enabled = false;
        //            //DataGridViewCheckBoxColumn cbPrincipal = new DataGridViewCheckBoxColumn();
        //            //cbPrincipal.Name = "cbPrincipal";
        //            //cbPrincipal.HeaderText = "";
        //            //cbPrincipal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //            //cbPrincipal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //            //dgvPrincipal.Columns.Insert(0, cbPrincipal);

        //            //headerCheckBox();
        //            //headerCB.MouseClick += headerCB_MouseClick;
        //        }
        //        else
        //        {
        //            //var cancelBtn = db.vwPrincipals.Where(a => a.RID.Equals(Id.suppID)).FirstOrDefault();
        //            txtDistriID.Text = Id.RID;
        //            txtDistriName.Text = Id.distriName;
        //            btnChangeDistri.Text = "Change distributor";
        //            groupBox1.Controls.RemoveByKey("pSupplier");
        //            //dgvPrincipal.Columns.RemoveAt(0);
        //            //dgvPrincipal.Controls.Remove(headerCB);
        //            btnClear.Enabled = true;
        //        }
        //    }
        //}

        private void headerCBclick(CheckBox hCheckBox)
        {
            isHeaderCBclicked = true;
            
            foreach(DataGridViewRow row in dgvPrincipal.Rows)
                ((DataGridViewCheckBoxCell)row.Cells["cbPrincipal"]).Value = hCheckBox.Checked;

            dgvPrincipal.RefreshEdit();

            isHeaderCBclicked = false;
        }

        private void headerCB_MouseClick(object sender, MouseEventArgs e)
        {
            headerCBclick((CheckBox)sender);
        }


        private void btnChangeDistri_Click(object sender, EventArgs e)
        {

        }

        private void txtDistriID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        Button btnUpdate = new Button();
        Button btnCancel = new Button();
        Form distriForm = new Form();
        private void changeMultiPrincipal()
        {
            frmPrincipal principal = new frmPrincipal();
            distriForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            distriForm.MinimizeBox = false;
            distriForm.MaximizeBox = false;
            distriForm.ShowIcon = false;
            distriForm.WindowState = FormWindowState.Normal;
            distriForm.StartPosition = FormStartPosition.CenterScreen;
            distriForm.Text = "";
            distriForm.Font = new Font("Segeo UI", 8, FontStyle.Regular);
            distriForm.Size = new System.Drawing.Size(374, 409);
            distriForm.Load += distriForm_Load;
            

            btnUpdate.Size = new System.Drawing.Size(75, 23);
            btnUpdate.Location = new Point(91, 338);
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.Location = new Point(172, 338);
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;

            supplierForm();
            p.Dock = DockStyle.None;
            p.Size = new System.Drawing.Size(358, 332);
            p.Location = new Point(0, 0);
            dgvSupplier.Dock = DockStyle.None;
            dgvSupplier.Size = new System.Drawing.Size(355, 284);
            dgvSupplier.Location = new Point(0, 45);

            distriForm.Controls.Add(p);
            distriForm.Controls.Add(btnUpdate);
            distriForm.Controls.Add(btnCancel);


            distriRes = distriForm.ShowDialog();
            if (distriRes == DialogResult.OK)
            {
                fetchPrincipal();
            }
        }

        private void btnCdistri_Click(object sender, EventArgs e)
        {
            changeMultiPrincipal();
        }

        DialogResult distriRes;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dRes = MessageBox.Show("Change distributor to "+Id.globalString+"?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            frmPrincipal principal = new frmPrincipal();
            if (dRes == DialogResult.Yes)
            {
                if (btnSelect.Text.Equals("Cancel"))
                {
                    List<string> ids = new List<string>();
                    string id;
                    foreach (DataGridViewRow row in dgvPrincipal.Rows)
                    {
                        bool select = Convert.ToBoolean(row.Cells["cbPrincipal"].Value);
                        if (select)
                        {
                            ids.Add(row.Cells["Supplier_ID"].Value.ToString());
                            id = row.Cells["Supplier_ID"].Value.ToString();
                            //db.suppliers.Where(a => a.RID.Equals(Id.suppID) && a.suppID.Equals(id)).ToList().ForEach(a => a.RID = Id.globalID);
                            DataTable dt = supClass.fetchPrincipalToBeUpdated("principalToBeUpdated", Id.suppID, id, Id.globalID);
                            
                        }
                    }
                    if (ids.Count == 0)
                    {
                        MessageBox.Show("No principal selected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //db.SaveChanges();
                        Id.suppID = txtDistriID.Text;
                        DialogResult distriRes = MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSelect.Text = "Select";
                        btnSelect.Image = Properties.Resources.check_mark__2_;
                        distriRes = DialogResult.OK;
                        dgvPrincipal.Columns.RemoveAt(0);
                        dgvPrincipal.Controls.Remove(headerCB);
                        distriForm.Hide();
                        fetchPrincipal();
                    }
                }
                else
                {
                    MessageBox.Show("Please select principal", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            distriForm.Hide();
        }

        private void distriForm_Load(object sender, EventArgs e)
        {
            dgvSupplier.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tabControl1.TabPages.Contains(tabPage1))
            {
                MessageBox.Show("Y");
            }
            else
            {
                MessageBox.Show("X");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if(btnSelect.Text.Equals("Select"))
            {
                btnSelect.Text = "Cancel";
                btnSelect.Image = Properties.Resources.forbidden;
                btnCdistri.Enabled = true;
                DataGridViewCheckBoxColumn cbPrincipal = new DataGridViewCheckBoxColumn();
                cbPrincipal.Name = "cbPrincipal";
                cbPrincipal.HeaderText = "";
                cbPrincipal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                cbPrincipal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPrincipal.Columns.Insert(0, cbPrincipal);
                headerCheckBox();
                headerCB.MouseClick += headerCB_MouseClick;
            }
            else if(btnSelect.Text.Equals("Cancel"))
            {
                btnSelect.Text = "Select";
                btnSelect.Image = Properties.Resources.check_mark__2_;
                btnCdistri.Enabled = false;
                dgvPrincipal.Columns.RemoveAt(0);
                dgvPrincipal.Controls.Remove(headerCB);
            }
        }



        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void dgvPrincipal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Delete principal?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(res == DialogResult.Yes)
            {
                //if (Id.button.Equals("Create"))
                //{
                //    if (dgvPrincipal.SelectedRows.Count > 0)
                //    {
                //        dgvPrincipal.Rows.RemoveAt(dgvPrincipal.SelectedRows[0].Index);

                //    }
                //}
                //if (Id.button.Equals("Create"))
                //{
                    if (!string.IsNullOrEmpty(Id.principalID))
                    {
                        if (btnSelect.Text.Equals("Cancel"))
                        {
                            List<int> ids = new List<int>();
                            string id;
                            foreach (DataGridViewRow row in dgvPrincipal.Rows)
                            {
                                bool select = Convert.ToBoolean(row.Cells["cbPrincipal"].Value);
                                if (select)
                                {
                                    ids.Add(Convert.ToInt32(row.Cells["Supplier_ID"].Value));
                                    id = (row.Cells["Supplier_ID"].Value.ToString());
                                    supClass.deleteSupplier("Supplier", "Delete", id);
                                    //var objMultiDel = db.suppliers.Where(a => a.suppID.Equals(id)).SingleOrDefault();
                                    //db.suppliers.Remove(objMultiDel);
                                }
                            }
                            //db.SaveChanges();
                            MessageBox.Show("Successfully deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fetchPrincipal();
                        } 
                        else if(btnSelect.Text.Equals("Select"))
                        {
                            supClass.deleteSupplier("Supplier", "Delete", Id.principalID);
                            //var objDel = db.suppliers.Where(a => a.suppID.Equals(Id.principalID)).SingleOrDefault();

                            //db.suppliers.Remove(objDel);
                            //db.SaveChanges();
                            MessageBox.Show("Successfully deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fetchPrincipal();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please select principal", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                //}
            }
        
        }

        

        

        
    }
}
