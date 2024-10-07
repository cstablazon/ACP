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
    public partial class frmProductDetails : Form
    {
        productCreation pc = new productCreation();
        barcodeClass barcode = new barcodeClass();
        acpEntities db = new acpEntities();
        supplierClass suppClass = new supplierClass();
        public frmProductDetails()
        {
            InitializeComponent();
            //itemModel();
            BOM();
            UOM();
            UOMretail();
            site();
            PurchaseTax();
            salesTax();
            inventLoc();
            itemModel();
            charges();
        }

        private void itemModel()
        {
            DataSet ds = pc.cbRecords("itemModelGroup", "fetchItemModelGroup", "itemModelDesc");
            cmbItemModel.DataSource = ds.Tables["itemModelDesc"];
            cmbItemModel.DisplayMember = "itemModelDesc";
            cmbItemModel.ValueMember = "itemModelID";
            cmbItemModel.Text = "";
            //cmbItemModel.DataSource = (from a in db.itemModelGroups select a).ToList();
            //cmbItemModel.ValueMember = "itemModelID";
            //cmbItemModel.DisplayMember = "itemModelDesc";
        }
        
        //comboBox unit of measure
        private void BOM()
        {
            DataSet ds = pc.cbRecords("UOM", "fetchUOM", "uomDesc");
            cmbBOM.DataSource = ds.Tables["uomDesc"];
            cmbBOM.DisplayMember = "uomDesc";
            cmbBOM.ValueMember = "uomID";
        }

        private void UOM()
        {
            DataSet ds = pc.cbRecords("UOM", "fetchUOM", "uomDesc");
            cmbPOunit.DataSource = ds.Tables["uomDesc"];
            cmbPOunit.DisplayMember = "uomDesc";
            cmbPOunit.ValueMember = "uomID";
        }

        //Pricing(comboBox retail unit)
        private void UOMretail()
        {
            DataSet ds = pc.cbRecords("UOM", "fetchUOM", "uomDesc");
            cmbRetailUnit.DataSource = ds.Tables["uomDesc"];
            cmbRetailUnit.DisplayMember = "uomDesc";
            cmbRetailUnit.ValueMember = "uomID";
        }

        private void charges()
        {
            DataSet ds = pc.cbRecords("charges", "fetchCharges", "chargeDesc");
            cmbCharges.DataSource = ds.Tables["chargeDesc"];
            cmbCharges.DisplayMember = "chargeDesc";
            cmbCharges.ValueMember = "chargeID";
        }

        private void site()
        {
            cmbSite.DataSource = (from a in db.sites select a).ToList();
            cmbSite.ValueMember = "siteID";
            cmbSite.DisplayMember = "siteDesc";
            //DataSet ds = pc.fetchData("VIEW", "FETCHSITE", "Name");
            //cbSite.DataSource = ds.Tables["Name"];
            //cbSite.DisplayMember = "Name";
            //cbSite.ValueMember = "ID";
            //cbSite.Text = Id.siteID;
        }

        private void inventLoc()
        {
            //DataSet ds = pc.fetchData("VIEW", "FETCHINVENTLOC", "Name");
            //cbWarehouse.DataSource = ds.Tables["Name"];
            //cbWarehouse.DisplayMember = "Name";
            //cbWarehouse.ValueMember = "ID";
            //cbWarehouse.Text = Id.discountID;
        }

        private void PurchaseTax()
        {
            DataSet ds = pc.cbRecords("itemSalesTaxGroup", "fetchItemSalesTaxGroup", "Tax ID");
            cmbPurchaseTax.DataSource = ds.Tables["Tax ID"];
            cmbPurchaseTax.DisplayMember = "Tax ID";
            cmbPurchaseTax.ValueMember = "Tax ID";
            cmbPurchaseTax.Text = "";
            
        }

        private void salesTax()
        {
            DataSet ds = pc.cbRecords("itemSalesTaxGroup", "fetchItemSalesTaxGroup", "Tax ID");
            cmbSalesTax.DataSource = ds.Tables["Tax ID"];
            cmbSalesTax.DisplayMember = "Tax ID";
            cmbSalesTax.ValueMember = "Tax ID";
            cmbSalesTax.Text = "";
        }
        

        public void hide()
        {
            pPopup.Hide();
            pPurchaseDiscount.Hide();
            pWarehouse.Hide();
        }
        
        private void frmProdAdditionalInfo_Load(object sender, EventArgs e)
        {
            if(Id.button == "Create")
            {
                cmbRetailUnit.Text = "";
                cmbPOunit.Text = "";
                cmbItemModel.Text = "";
                cmbCharges.Text = "";
            }
            txtPOcostP.Text = 0.ToString("N2");
            txtRetailP.Text = 0.ToString("N2");
            txtInventoryCost.Text = 0.ToString("N2");
            //txtFactor.Text = 0.ToString("N2");
            txtFactor.Enabled = false;
            discountCriteria();
            pPopup.Hide();
            purchaseDiscount();
            pPurchaseDiscount.Hide();
            warehouse();
            pWarehouse.Hide();

            if(Id.isConcession == true)
            {
                txtPOcostP.Enabled = false;
                txtInventoryCost.Enabled = false;
                txtPurchaseDiscount.Enabled = false;
            }
            else
            {
                txtPOcostP.Enabled = true;
                txtInventoryCost.Enabled = true;
                txtPurchaseDiscount.Enabled = true;
            }
            //if(Id.isProductMaster == true)
            //{
            //    txtConfig.Enabled = true;
            //}
            //else
            //{
            //    txtConfig.Enabled = false;
            //}
        }

        private void txtDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 45)
            {
                TextBox t = (TextBox)sender;
                int cursorPosition = t.Text.Length - t.SelectionStart;      // Text in the box and Cursor position

                if (e.KeyChar == 45)                    
                    t.Text = t.Text[0] == 45 ? t.Text = t.Text[1].ToString() : "-" + t.Text;                    
                else                    
                    if ( t.Text.Length < 20)
                        t.Text = ( decimal.Parse( t.Text.Insert( t.SelectionStart, e.KeyChar.ToString())
                                                .Replace(",", "").Replace(".", "")) / 100).ToString("N2");

                t.SelectionStart = (t.Text.Length - cursorPosition < 0 ? 0 : t.Text.Length - cursorPosition);
            }
            e.Handled = true;
        }

        private void txtDecimal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)     // Deals with BackSpace e Delete keys
            {
                TextBox t = (TextBox)sender;
                int cursorPosition = t.Text.Length - t.SelectionStart;

                string Left = t.Text.Substring(0, t.Text.Length - cursorPosition).Replace(".", "").Replace(",", "");
                string Right = t.Text.Substring(t.Text.Length - cursorPosition).Replace(".", "").Replace(",", "");

                if (Left.Length > 0)
                {
                    Left = Left.Remove(Left.Length - 1);                            // Take out the rightmost digit
                    t.Text = (decimal.Parse(Left + Right) / 100).ToString("N2");
                    t.SelectionStart = (t.Text.Length - cursorPosition < 0 ? 0 : t.Text.Length - cursorPosition);
                }
                e.Handled = true;
            }

            if (e.KeyCode == Keys.End)                                  
            {
                TextBox t = (TextBox)sender;
                t.SelectionStart = t.Text.Length;                       // Moves the cursor o the rightmost position
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Home)                                 
            {
                TextBox t = (TextBox)sender;
                t.Text = 0.ToString("N2");                              // Set field value to zero 
                t.SelectionStart = t.Text.Length;                       // Moves the cursor o the rightmost position
                e.Handled = true;
            }    
        }

        private void txtDecimal_Enter(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender; 
            t.SelectionStart = t.Text.Length;
            hide();
        }

        //Warehouse setup
        Panel pWarehouse = new Panel();
        DataGridView dgvWarehouse = new DataGridView();
        ComboBox cmbWarehouseFilter = new ComboBox();
        TextBox txtWarehouseSearch = new TextBox();
        private void warehouse()
        {
            pWarehouse.Name = "pWarehouse";
            pWarehouse.Size = new Size(450, 269);
            pWarehouse.Location = new Point(30, 45);
            pWarehouse.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            pWarehouse.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pWarehouse);
            dgvWarehouse.DataSource = (from a in db.vwWarehouseSetups
                                       select new
                                       {
                                           a.LID,
                                           a.desc,
                                           a.whID,
                                           a.whDesc,
                                           a.siteID
                                       }).ToList();

            cmbWarehouseFilter.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            cmbWarehouseFilter.Dock = DockStyle.Top;
            cmbWarehouseFilter.BringToFront();
            txtWarehouseSearch.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            txtWarehouseSearch.Dock = DockStyle.Top;
            txtWarehouseSearch.BringToFront();
            cmbWarehouseFilter.Items.Clear();
            cmbWarehouseFilter.Items.Add("Issue location ID");
            cmbWarehouseFilter.Items.Add("Location description");
            dgvWarehouse.Size = new System.Drawing.Size(367, 220);
            dgvWarehouse.BringToFront();
            dgvWarehouse.AllowUserToAddRows = false;
            dgvWarehouse.AllowUserToDeleteRows = false;
            dgvWarehouse.ReadOnly = true;
            dgvWarehouse.MultiSelect = false;
            dgvWarehouse.RowHeadersVisible = false;
            dgvWarehouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvWarehouse.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvWarehouse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWarehouse.Dock = DockStyle.Bottom;
            dgvWarehouse.CellDoubleClick += dgvWarehouse_CellDoubleClick;
            dgvWarehouse.DataBindingComplete += dgvWarehouse_DataBindingComplete;
            txtWarehouseSearch.TextChanged += txtWarehouseSearch_TextChanged;
            cmbWarehouseFilter.KeyPress += cmbWarehouseFilter_KeyPress;
            cmbWarehouseFilter.SelectionChangeCommitted += cmbWarehouseFilter_SelectionChangeCommitted;
            pWarehouse.Controls.Add(cmbWarehouseFilter);
            pWarehouse.Controls.Add(txtWarehouseSearch);
            pWarehouse.Controls.Add(dgvWarehouse);

            if (dgvWarehouse.Rows.Count > 0)
            {
                dgvWarehouse.Columns[0].HeaderText = "Issue location ID";
                dgvWarehouse.Columns[1].HeaderText = "Location";
                dgvWarehouse.Columns[2].HeaderText = "Warehouse ID";
                dgvWarehouse.Columns[3].HeaderText = "Warehouse";
                dgvWarehouse.Columns[4].HeaderText = "Site";

                dgvWarehouse.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvWarehouse.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvWarehouse.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvWarehouse.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvWarehouse.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        string whID, LID;
        private void dgvWarehouse_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvWarehouse.Rows[e.RowIndex];
                LID = row.Cells["LID"].Value.ToString();

                txtIssueLoc.Text = row.Cells["desc"].Value.ToString();
                txtSite.Text = row.Cells["siteID"].Value.ToString();
                whID = row.Cells["whID"].Value.ToString();
                txtWarehouse.Text = row.Cells["whDesc"].Value.ToString();
                pWarehouse.Hide();
            }
        }

        private void dgvWarehouse_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvWarehouse.ClearSelection();
        }

        private void txtWarehouseSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbWarehouseFilter.Text))
            {
                MessageBox.Show("Please select search filter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWarehouseSearch.Clear();
            }
            else if (cmbWarehouseFilter.Text == "Issue location ID")
            {
                if (txtWarehouseSearch.Text == "")
                {
                    dgvWarehouse.DataSource = (from a in db.vwWarehouseSetups
                                               select new
                                               {
                                                   a.LID,
                                                   a.desc,
                                                   a.whID,
                                                   a.whDesc,
                                                   a.siteID
                                               }).ToList();
                }
                else
                {
                    dgvWarehouse.DataSource = (from a in db.vwWarehouseSetups
                                               where a.LID.Contains(txtWarehouseSearch.Text)
                                               select new
                                               {
                                                   a.LID,
                                                   a.desc,
                                                   a.whID,
                                                   a.whDesc,
                                                   a.siteID
                                               }).ToList();
                }
            }
            else if (cmbWarehouseFilter.Text == "Location description")
            {
                if (txtWarehouseSearch.Text == "")
                {
                    dgvWarehouse.DataSource = (from a in db.vwWarehouseSetups
                                               select new
                                               {
                                                   a.LID,
                                                   a.desc,
                                                   a.whID,
                                                   a.whDesc,
                                                   a.siteID
                                               }).ToList();
                }
                else
                {
                    dgvWarehouse.DataSource = (from a in db.vwWarehouseSetups
                                               where a.desc.Contains(txtWarehouseSearch.Text)
                                               select new
                                               {
                                                   a.LID,
                                                   a.desc,
                                                   a.whID,
                                                   a.whDesc,
                                                   a.siteID
                                               }).ToList();
                }
            }
            
        }

        private void cmbWarehouseFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbWarehouseFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtWarehouseSearch.Clear();
        }

        //Purchase discount popup form
        Panel pPurchaseDiscount = new Panel();
        DataGridView dgvPurchaseDiscount = new DataGridView();
        ComboBox cmbDiscountFilter = new ComboBox();
        TextBox txtDiscountSearch = new TextBox();
        private void purchaseDiscount()
        {
            pPurchaseDiscount.Name = "pPurchaseDiscount";
            pPurchaseDiscount.Size = new Size(241, 195);
            pPurchaseDiscount.Location = new Point(250, 140);
            pPurchaseDiscount.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            pPurchaseDiscount.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pPurchaseDiscount);

            //dgvPurchaseDiscount.DataSource = (from a in db.discounts
            //                                  where a.discountType == "Purchase discount"
            //                                  select new
            //                                  {
            //                                      a.discountID,
            //                                      a.code,
            //                                      a.dDesc,
            //                                      a.percentage
            //                                  }).ToList();

            DataTable dt = pc.fetch("sp_productOperations", "discount", "fetchPopupDiscount");
            dgvPurchaseDiscount.DataSource = dt;

            cmbDiscountFilter.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            cmbDiscountFilter.Dock = DockStyle.Top;
            cmbDiscountFilter.BringToFront();
            txtDiscountSearch.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            txtDiscountSearch.Dock = DockStyle.Top;
            txtDiscountSearch.BringToFront();
            cmbDiscountFilter.Items.Clear();
            cmbDiscountFilter.Items.Add("Code");
            cmbDiscountFilter.Items.Add("Description");
            dgvPurchaseDiscount.Size = new System.Drawing.Size(271, 155);
            dgvPurchaseDiscount.BringToFront();
            dgvPurchaseDiscount.AllowUserToAddRows = false;
            dgvPurchaseDiscount.AllowUserToDeleteRows = false;
            dgvPurchaseDiscount.ReadOnly = true;
            dgvPurchaseDiscount.MultiSelect = false;
            dgvPurchaseDiscount.RowHeadersVisible = false;
            dgvPurchaseDiscount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvPurchaseDiscount.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvPurchaseDiscount.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPurchaseDiscount.Dock = DockStyle.Bottom;
            dgvPurchaseDiscount.CellDoubleClick += dgvPurchaseDiscount_CellDoubleClick;
            dgvPurchaseDiscount.DataBindingComplete += dgvPurchaseDiscount_DataBindingComplete;
            txtDiscountSearch.TextChanged += txtDiscountSearch_TextChanged;
            cmbDiscountFilter.KeyPress += cmbDiscountFilter_KeyPress;
            cmbDiscountFilter.SelectionChangeCommitted += cmbDiscountFilter_SelectionChangeCommitted;
            pPurchaseDiscount.Controls.Add(cmbDiscountFilter);
            pPurchaseDiscount.Controls.Add(txtDiscountSearch);
            pPurchaseDiscount.Controls.Add(dgvPurchaseDiscount);

            if (dgvPurchaseDiscount.Rows.Count > 0)
            {
                dgvPurchaseDiscount.Columns[1].HeaderText = "Code";
                dgvPurchaseDiscount.Columns[2].HeaderText = "Description";
                dgvPurchaseDiscount.Columns[3].HeaderText = "Percentage";

                dgvPurchaseDiscount.Columns["discountID"].Visible = false;
                dgvPurchaseDiscount.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvPurchaseDiscount.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvPurchaseDiscount.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }


        }

        int discountID;
        private void dgvPurchaseDiscount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPurchaseDiscount.Rows[e.RowIndex];
                discountID = Convert.ToInt32(row.Cells["discountID"].Value);
                Id.percent = Convert.ToDecimal(row.Cells["percentage"].Value);

                txtPurchaseDiscount.Text = row.Cells["dDesc"].Value.ToString();
                if (!string.IsNullOrEmpty(txtPOcostP.Text) && txtPOcostP.Text != "0.00")
                {
                    if (Id.isConcession != true)
                    {
                        if (!string.IsNullOrEmpty(Id.suppID))
                        {
                            DataTable dt = suppClass.getSupplierById("fetchSupplierById", Id.suppID);
                            //var objTax = db.vwSuppliers.Where(a => a.Supplier_ID == Id.suppID);
                            if (dt.Rows.Count > 0)
                            {
                                decimal factor;
                                string itemTaxID;// = objTax.SingleOrDefault().itemTaxID;
                                //var objPercent = db.taxSetups.Where(a => a.itemTaxID == itemTaxID).SingleOrDefault();
                                decimal itemTax = 0.00m;// = Convert.ToDecimal(objPercent.percent);
                                decimal costP = Convert.ToDecimal(txtPOcostP.Text);
                                foreach (DataRow rows in dt.Rows)
                                {
                                    itemTaxID = rows["itemTaxID"].ToString();
                                    itemTax = Convert.ToDecimal(rows["percent"].ToString());
                                }
                                //decimal factor;
                                //string itemTaxID = //objTax.SingleOrDefault().itemTaxID;
                                //var objPercent = db.taxSetups.Where(a => a.itemTaxID == itemTaxID).SingleOrDefault();
                                //decimal itemTax = Convert.ToDecimal(objPercent.percent);
                                //decimal costP = Convert.ToDecimal(txtPOcostP.Text);
                                if (txtFactor.Enabled == true && !string.IsNullOrEmpty(txtFactor.Text))
                                {
                                    factor = Convert.ToDecimal(txtFactor.Text);
                                }
                                else
                                {
                                    factor = 1;
                                }
                                decimal result;
                                if (txtFactor.Enabled == false && Id.percent == 0)
                                {
                                    txtInventoryCost.Text = Convert.ToString(Decimal.Round((costP / ((itemTax + 100) / 100)), 2));
                                    //result = ;
                                    //txtInventoryCost.Text = result.ToString();
                                }
                                else if (txtFactor.Enabled == false && Id.percent != 0)
                                {
                                    txtInventoryCost.Text = Convert.ToString(Decimal.Round((costP * Id.percent) / ((itemTax + 100) / 100), 2));
                                    //result = (costP * Id.percent) / itemTax;
                                    //txtInventoryCost.Text = result.ToString();
                                }
                                else if (txtFactor.Enabled == true && Id.percent != 0)
                                {
                                    txtInventoryCost.Text = Convert.ToString(Decimal.Round(((costP * Id.percent) / factor) / ((itemTax + 100) / 100), 2));
                                    //result = ((costP / factor) * Id.percent)  / itemTax;
                                    //txtInventoryCost.Text = result.ToString();
                                }
                                else if (txtFactor.Enabled == true && Id.percent == 0)
                                {
                                    txtInventoryCost.Text = Convert.ToString(Decimal.Round((costP / factor) / ((itemTax + 100) / 100), 2));
                                    //result = (costP / factor) / itemTax;
                                    //txtInventoryCost.Text = result.ToString();
                                }

                            }

                        }
                        else
                        {
                            MessageBox.Show("Supplier ID is required for inventory cost", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                pPurchaseDiscount.Hide();
            }
        }

        private void dgvPurchaseDiscount_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPurchaseDiscount.ClearSelection();
        }

        private void txtDiscountSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDiscountFilter.Text))
            {
                MessageBox.Show("Please select search filter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiscountSearch.Clear();
            }
            else if (cmbDiscountFilter.Text == "Code")
            {
                if (txtDiscountSearch.Text == "")
                {
                    dgvPurchaseDiscount.DataSource = (from a in db.discounts
                                                      select new
                                                      {
                                                          a.discountID,
                                                          a.code,
                                                          a.dDesc,
                                                          a.percentage
                                                      }).ToList();
                }
                else
                {
                    dgvPurchaseDiscount.DataSource = (from a in db.discounts
                                                      where a.code.Contains(txtDiscountSearch.Text)
                                                      select new
                                                      {
                                                          a.discountID,
                                                          a.code,
                                                          a.dDesc,
                                                          a.percentage
                                                      }).ToList();
                }
            }
            else if (cmbDiscountFilter.Text == "Description")
            {
                if (txtDiscountSearch.Text == "")
                {
                    dgvPurchaseDiscount.DataSource = (from a in db.discounts
                                                      select new
                                                      {
                                                          a.discountID,
                                                          a.code,
                                                          a.dDesc,
                                                          a.percentage
                                                      }).ToList();
                }
                else
                {
                    dgvPurchaseDiscount.DataSource = (from a in db.discounts
                                                      where a.dDesc.Contains(txtDiscountSearch.Text)
                                                      select new
                                                      {
                                                          a.discountID,
                                                          a.code,
                                                          a.dDesc,
                                                          a.percentage
                                                      }).ToList();
                }
            }
        }
        private void cmbDiscountFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }



        private void cmbDiscountFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtDiscountSearch.Clear();
        }

        TreeView tvPopup = new TreeView();
        Panel pPopup = new Panel();
        int profileID;
        public void discountCriteria()
        {
            pPopup.Name = "pDiscountCriteria";
            Controls.Add(pPopup);
            pPopup.BringToFront();

            tvPopup.AfterSelect += tvPopup_AfterSelect;
            tvPopup.DrawNode += tvPopup_DrawNode;
            tvPopup.NodeMouseDoubleClick += tvPopup_NodeMouseDoubleClick;
            tvPopup.Name = "tvDiscountCriteria";
            tvPopup.Dock = DockStyle.Fill;
            tvPopup.DrawMode = TreeViewDrawMode.OwnerDrawText;
            pPopup.Controls.Add(tvPopup);
        }

        private TreeNode lastAddedNode = null;

        private void populateTreeView()
        {
            try
            {
                // Clears any existing nodes in the TreeView
                tvPopup.Nodes.Clear();
                // Resets the lastAddedNode variable to null
                lastAddedNode = null;
                // Fetches a DataTable containing category hierarchy data
                //DataTable dataTable = cat.fetchCatHierarchy();
                var objDiscountCriteria = db.sp_Hierarchy(profileID).ToList();
                // Creates a dictionary to store TreeNode objects, with string keys and TreeNode values
                Dictionary<string, TreeNode> nodeDict = new Dictionary<string, TreeNode>();
                // Iterates through each row in the DataTable
                foreach (sp_Hierarchy_Result item in objDiscountCriteria)
                {
                    // Extracts values from the current DataRow
                    long RID = item.RID;
                    string desc = item.desc;
                    string code = item.code;
                    string rType = item.rType;

                    // Creates a new TreeNode with a label that combines "code" and "desc"
                    TreeNode node = new TreeNode(desc);
                    if(!string.IsNullOrEmpty(item.code))
                    {
                        code = item.code.Trim();
                        node = new TreeNode(code +" "+ desc);
                    }
                    else
                    {
                        node = new TreeNode(desc);
                    }

                    // Sets the Tag property of the TreeNode to the value of "RID"
                    node.Tag = RID;
                    // Adds the TreeNode to the TreeView's root if "rtype" is "0"
                    if (string.IsNullOrEmpty(rType))
                    {
                        tvPopup.Nodes.Add(node);
                    }
                    // Adds the TreeNode to the parent node if the corresponding key exists in the dictionary
                    else
                    {
                        if (nodeDict.ContainsKey(rType))
                        {
                            TreeNode parentNode = nodeDict[rType];
                            parentNode.Nodes.Add(node);
                        }
                    }
                    // Adds the current TreeNode to the dictionary using "RID" as the key
                    nodeDict.Add(RID.ToString(), node);
                    // Updates the lastAddedNode variable with the current TreeNode
                    lastAddedNode = node;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Declares a method named FindNodeById that returns a TreeNode
        private TreeNode FindNodeById(TreeNodeCollection nodes, string RID)
        {
            // Iterates through each TreeNode in the given TreeNodeCollection
            foreach (TreeNode node in nodes)
            {
                // Checks if the Tag property of the current node is equal to the provided "rType"
                if (node.Tag.ToString() == RID)
                {
                    // Returns the current node if the Tag property matches "rType"
                    return node;
                }
                // Recursively calls the FindNodeById method on the child nodes of the current node
                TreeNode foundNode = FindNodeById(node.Nodes, RID);
                // Returns the found node if it is not null (indicating a match)
                if (foundNode != null)
                {
                    return foundNode;
                }
            }
            // Returns null if no matching node is found in the entire TreeNode hierarchy
            return null;
        }

        private void tvPopup_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
        }

        long bmrxID, privilegeID;
        private void tvPopup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Retrieves the currently selected TreeNode from the TreeView
            TreeNode selectedNode = tvPopup.SelectedNode;
            // Retrieves the Tag property of the selected node and converts it to a string
            string selectedNodeID = selectedNode.Tag.ToString();
            Id.RIDL = Convert.ToInt64(selectedNodeID);
            // Sets a static property "rtypeID" in the "Id" class to the value of the selected node's ID
            if(profile == "BMRX")
            {
                bmrxID = Convert.ToInt64(selectedNodeID);
            }
            else if(profile == "Privilege")
            {
                privilegeID = Convert.ToInt64(selectedNodeID);
            }
            // Checks if the selected node's text matches a specific condition

        }

        private void tvPopup_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var objDiscountCriteria = (from a in db.hierarchies where a.RID == Id.RIDL select a).SingleOrDefault();
            //string rType = objDiscountCriteria.rType;
            if (!string.IsNullOrEmpty(objDiscountCriteria.rType))
            {
                if(profile == "BMRX")
                {
                    txtBMRX.Text = objDiscountCriteria.desc.Trim();
                }
                else if (profile == "Privilege")
                {
                    txtPrivilege.Text = objDiscountCriteria.desc.Trim();
                }
                pPopup.Hide();
            }
            else
            {
                MessageBox.Show("Please select under Criteria", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        DataGridView dgvSite;
        private void cbSite_Click(object sender, EventArgs e)
        {
            if(Id.access == "NEWPROD")
            {
                if(Id.showSite)
                {
                    this.Controls.RemoveByKey("pSite");
                    //cbSite.Focus();
                    Id.showSite = false;
                }
                else
                {
                    this.Controls.RemoveByKey("pWarehouse");
                    Panel pSite = new Panel();
                    pSite.Size = new System.Drawing.Size(219, 165);
                    pSite.Location = new Point(495, 184);
                    pSite.Name = "pSite";
                    pSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    this.Controls.Add(pSite);
                    pSite.BringToFront();
                    dgvSite = new DataGridView();
                    dgvSite.AllowUserToAddRows = false;
                    dgvSite.AllowUserToDeleteRows = false;
                    dgvSite.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvSite.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    dgvSite.Dock = System.Windows.Forms.DockStyle.Fill;
                    dgvSite.MultiSelect = false;
                    dgvSite.ReadOnly = true;
                    dgvSite.RowHeadersVisible = false;
                    dgvSite.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //frmSite site = new frmSite { TopLevel = false };
                    //site.panel1.Visible = false;
                    //site.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
                    //site.sidebar.Size = new System.Drawing.Size(219, 165);
                    //site.dgvSite.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    pSite.Controls.Clear();
                    pSite.Controls.Add(dgvSite);
                    dgvSite.Show();
                //    cbSite.Focus();

                    DataTable dt = pc.fetchRecord("VIEW", "FETCHCBSITE", "", "", "", "", "", "");
                    BindingSource source = new BindingSource();
                    source.DataSource = dt;
                    dgvSite.DataSource = source;
                    dgvSite.CellDoubleClick += dgvSite_CellDoubleClick;
                    dgvSite.CellClick += dgvSite_CellClick;
                    Id.showSite = true;
                }
            }
        }

        private void dgvSite_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvSite.Rows[e.RowIndex];

            //cbSite.Text = row.Cells["Name"].Value.ToString();
            //cbWarehouse.Focus();
            this.Controls.RemoveByKey("pSite");
            Id.showSite = false;
        }

        private void dgvSite_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvSite.Rows[e.RowIndex];

            Id.siteID = row.Cells["Name"].Value.ToString();
        }

        private void createUpdate()
        {
            string itemModelID = cmbItemModel.SelectedValue.ToString();
            int? chargeID = Convert.ToInt32(cmbCharges.SelectedValue);
            int CPuomID = Convert.ToInt32(cmbPOunit.SelectedValue);
            int RPuomID = Convert.ToInt32(cmbRetailUnit.SelectedValue);
            int bomID = Convert.ToInt32(cmbBOM.SelectedValue);
            decimal? factor, costPrice, inventoryCost;
            decimal retailPrice = Convert.ToDecimal(txtRetailP.Text);

            if (cmbPOunit.Text != cmbRetailUnit.Text)
            {
                factor = Convert.ToDecimal(txtFactor.Text);
            }
            else
            {
                factor = null;
            }
            costPrice = Convert.ToDecimal(txtPOcostP.Text);
            inventoryCost = Convert.ToDecimal(txtInventoryCost.Text);
            Id.dt.Columns.Add("Barcode", typeof(string));
            Id.dt.Columns.Add("SKU", typeof(string));
            Id.dt.Columns.Add("Item model ID", typeof(string));
            Id.dt.Columns.Add("chargeID", typeof(int));
            Id.dt.Columns.Add("Charge", typeof(string));
            Id.dt.Columns.Add("PID", typeof(long));
            Id.dt.Columns.Add("Privilege", typeof(string));
            Id.dt.Columns.Add("BMRXID", typeof(long));
            Id.dt.Columns.Add("BMRX", typeof(string));
            Id.dt.Columns.Add("LID", typeof(long));
            Id.dt.Columns.Add("discountID", typeof(int));
            Id.dt.Columns.Add("Discount", typeof(string));
            Id.dt.Columns.Add("CPuomID", typeof(int));
            Id.dt.Columns.Add("Purchase unit", typeof(string));
            Id.dt.Columns.Add("Cost price", typeof(decimal));
            Id.dt.Columns.Add("Inventory cost", typeof(decimal));
            Id.dt.Columns.Add("RPuomID", typeof(int));
            Id.dt.Columns.Add("Retail unit", typeof(string));
            Id.dt.Columns.Add("Retail price", typeof(decimal));
            Id.dt.Columns.Add("BOMid", typeof(int));
            Id.dt.Columns.Add("BOM unit", typeof(string));
            Id.dt.Columns.Add("factor", typeof(decimal));
            Id.dt.Columns.Add("Product description", typeof(string));
            Id.dt.Columns.Add("Sales tax", typeof(string));
            Id.dt.Columns.Add("Purchase tax", typeof(string));
            Id.dt.Columns.Add("isDiscountable", typeof(bool));
            Id.dt.Columns.Add("isActive", typeof(bool));
            Id.dt.Columns.Add("userID", typeof(int));

            DataRow dRow = Id.dt.NewRow();
            dRow[0] = txtBarcode.Text;
            dRow[1] = Id.SKU;
            dRow[2] = itemModelID;
            dRow[3] = chargeID;
            dRow[4] = cmbCharges.Text;
            dRow[5] = privilegeID;
            dRow[6] = txtPrivilege.Text;
            dRow[7] = bmrxID;
            dRow[8] = txtBMRX.Text;
            dRow[9] = LID;
            dRow[10] = discountID;
            dRow[11] = txtPurchaseDiscount.Text;
            dRow[12] = CPuomID;
            dRow[13] = cmbPOunit.Text;
            dRow[14] = costPrice;
            dRow[15] = inventoryCost;
            dRow[16] = RPuomID;
            dRow[17] = cmbRetailUnit.Text;
            dRow[18] = retailPrice;
            dRow[19] = bomID;
            dRow[20] = cmbBOM.Text;
            dRow[21] = factor ?? (object)DBNull.Value;
            dRow[22] = txtPosDesc.Text;
            dRow[23] = cmbSalesTax.Text;
            dRow[24] = cmbPurchaseTax.Text;
            dRow[25] = cbNotDiscountable.Checked;
            dRow[26] = true;
            dRow[27] = Id.userID;
            Id.dt.Rows.Add(dRow);
            //MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Hide();
            
            //    costPrice = Convert.ToDecimal(txtPOcostP.Text);
            //    inventoryCost = Convert.ToDecimal(txtInventoryCost.Text);
            
            ////if (btnCreate.Text == "Create")
            ////{
            //    //if (!string.IsNullOrEmpty(txtConfig.Text))
            //    //{
            //    pc.createUpdateBarcode("Update", txtBarcode.Text, Id.SKU, itemModelID, chargeID, Id.privilegeID, Id.bmrxID, Id.LID, Id.discountID, CPuomID, RPuomID, bomID, factor, retailPrice, costPrice, inventoryCost, txtPosDesc.Text, cmbSalesTax.Text, cmbPurchaseTax.Text, cbNotDiscountable.Checked, true, Id.userID, Id.barcode);
            //    Id.barcode = txtBarcode.Text;
            //    MessageBox.Show("Successfully created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Id.discountID = 0;
            //    Id.percent = 0;
            //    this.Hide();
            //    this.DialogResult = DialogResult.OK;
                //}
                //else
                //{
                //    MessageBox.Show("Configuration is required for Product Master", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                
                    //DataRow dr = Id.dtBarcode.NewRow();
                    //dr[0] = txtBarcode.Text;
                    //dr[1] = txtPosDesc.Text;
                    //dr[2] = cmbPOunit.SelectedValue;
                    //dr[3] = cmbPOunit.Text;
                    //if (Id.isConcession == true)
                    //{
                    //    dr[4] = DBNull.Value;
                    //    dr[9] = DBNull.Value;
                    //    dr[13] = DBNull.Value;
                    //}
                    //else
                    //{
                    //    dr[4] = txtPOcostP.Text;
                    //    dr[9] = txtInventoryCost.Text;
                    //    dr[13] = txtPurchaseDiscount.Text;
                    //}
                    //if (cmbPOunit.Text != cmbRetailUnit.Text)
                    //{
                    //    dr[5] = txtFactor.Text;
                    //}
                    //else
                    //{
                    //    dr[5] = DBNull.Value;
                    //}
                    //dr[6] = cmbRetailUnit.SelectedValue;
                    //dr[7] = cmbRetailUnit.Text;
                    //dr[8] = txtRetailP.Text;
                    //dr[10] = cmbBOM.SelectedValue;
                    //dr[11] = cmbBOM.Text;
                    //dr[12] = Id.discountID;
                    //dr[14] = cmbPurchaseTax.SelectedValue;
                    //dr[15] = cmbSalesTax.SelectedValue;
                    //dr[16] = Id.bmrxID;
                    //dr[17] = txtBMRX.Text;
                    //dr[18] = Id.privilegeID;
                    //dr[19] = txtPrivilege.Text;
                    //dr[20] = cmbItemModel.SelectedValue;
                    //dr[21] = cmbItemModel.Text;
                    //dr[22] = cbNotDiscountable.Checked;
                    //if (string.IsNullOrEmpty(cmbCharges.Text))
                    //{
                    //    dr[23] = DBNull.Value;
                    //    dr[24] = DBNull.Value;
                    //}
                    //else
                    //{
                    //    dr[23] = cmbCharges.SelectedValue;
                    //    dr[24] = cmbCharges.Text;
                    //}
                    //if (txtConfig.Enabled == false)
                    //{
                    //    dr[25] = DBNull.Value;
                    //}
                    //else
                    //{
                    //    dr[25] = txtConfig.Text;
                    //}
                    //dr[26] = Id.LID;
                    //dr[27] = txtIssueLoc.Text;
                    //dr[28] = txtSite.Text;
                    //dr[29] = Id.whID;
                    //dr[30] = txtWarehouse.Text;

                    //Id.dtBarcode.Rows.Add(dr);
                    //this.DialogResult = DialogResult.OK;
                    //this.Hide();
                
            //}
            //else if (btnCreate.Text == "Update")
            //{
            //    pc.createUpdateBarcode("Barcode", "Update", txtBarcode.Text, Id.SKU, itemModelID, chargeID, Id.privilegeID, Id.bmrxID, Id.LID, Id.discountID, CPuomID, RPuomID, factor, retailPrice, costPrice, inventoryCost, txtPosDesc.Text, cmbSalesTax.Text, cmbPurchaseTax.Text, cbNotDiscountable.Checked, true, Id.userID);
                //    var objExcept = db.barcodes.Where(a => a.barcode1.Equals(Id.globalString2));
                //    var objExist = db.barcodes.Where(a => a.barcode1.Equals(txtBarcode.Text)).Except(objExcept);
                //    if (objExist.Any())
                //    {
                //        MessageBox.Show("Barcode already exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    else
                //    {
                //        MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        this.DialogResult = DialogResult.OK;
                //        this.Hide();
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Fillup necessary information", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            //}
        }

        private void validation()
        {
            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                MessageBox.Show("Barcode is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBarcode.Focus();
            }
            else if(string.IsNullOrEmpty(txtPosDesc.Text))
            {
                MessageBox.Show("Product description is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPosDesc.Focus();
            }
            else if(string.IsNullOrEmpty(cmbPOunit.Text))
            {
                MessageBox.Show("Purchase unit is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbPOunit.Focus();
            }
            else if(string.IsNullOrEmpty(cmbRetailUnit.Text))
            {
                MessageBox.Show("Retail unit is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbRetailUnit.Focus();
            }
            else if(string.IsNullOrEmpty(cmbBOM.Text))
            {
                MessageBox.Show("BOM unit is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBOM.Focus();
            }
            else if(string.IsNullOrEmpty(txtRetailP.Text))
            {
                MessageBox.Show("Retail price is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRetailP.Focus();
            }
            else if(string.IsNullOrEmpty(cmbPurchaseTax.Text))
            {
                MessageBox.Show("Purchase tax is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbPurchaseTax.Focus();
            }
            else if(string.IsNullOrEmpty(cmbSalesTax.Text))
            {
                MessageBox.Show("Sales tax is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSalesTax.Focus();
            }
            else if(string.IsNullOrEmpty(cmbItemModel.Text))
            {
                MessageBox.Show("Item model group is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbItemModel.Focus();
            }
            else if(string.IsNullOrEmpty(txtIssueLoc.Text))
            {
                MessageBox.Show("Issue location is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIssueLoc.Focus();
            }
            else if(string.IsNullOrEmpty(txtBMRX.Text))
            {
                MessageBox.Show("Issue location is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBMRX.Focus();
            }
            else if (string.IsNullOrEmpty(txtPrivilege.Text))
            {
                MessageBox.Show("Issue location is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrivilege.Focus();
            }
            else if (txtFactor.Enabled == true && string.IsNullOrEmpty(txtFactor.Text) || txtFactor.Text == "0.00")
            {
                MessageBox.Show("Factor is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFactor.Focus();
            }
            else
            {
                createUpdate();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            validation();
        }
        //DataGridView dgvWarehouse;
        //private void cbWarehouse_Click(object sender, EventArgs e)
        //{

        //    if (Id.access == "NEWPROD")
        //    {
        //        if (Id.showWH)
        //        {
        //            this.Controls.RemoveByKey("pWarehouse");
        //           // cbWarehouse.Focus();
        //            Id.showWH = false;
        //        }
        //        else
        //        {
        //            this.Controls.RemoveByKey("pSite");
        //            Panel pWarehouse = new Panel();
        //            pWarehouse.Size = new System.Drawing.Size(220, 142);
        //            pWarehouse.Location = new Point(494, 213);
        //            pWarehouse.Name = "pWarehouse";
        //            pWarehouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        //            this.Controls.Add(pWarehouse);
        //            pWarehouse.BringToFront();
        //            dgvWarehouse = new DataGridView();
        //            dgvWarehouse.AllowUserToAddRows = false;
        //            dgvWarehouse.AllowUserToDeleteRows = false;
        //            dgvWarehouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //            dgvWarehouse.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        //            dgvWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
        //            dgvWarehouse.MultiSelect = false;
        //            dgvWarehouse.ReadOnly = true;
        //            dgvWarehouse.RowHeadersVisible = false;
        //            dgvWarehouse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //            //pWarehouse.Show();
        //            //frmInventLocation inventLoc = new frmInventLocation { TopLevel = false };
        //            //inventLoc.panel1.Visible = false;
        //            //inventLoc.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
        //            pWarehouse.Controls.Clear();
        //            pWarehouse.Controls.Add(dgvWarehouse);
        //            dgvWarehouse.BringToFront();
        //            dgvWarehouse.Show();
        //            DataTable dt = pc.fetchRecord("VIEW", "FETCHCBINVENTLOC", "", "", "", "", "", "");
        //            BindingSource source = new BindingSource();
        //            source.DataSource = dt;
        //            dgvWarehouse.DataSource = source;
        //            dgvWarehouse.CellClick += dgvWarehouse_CellClick;
        //            dgvWarehouse.CellDoubleClick += dgvWarehouse_CellDoubleClick;
        //            Id.showWH = true;
        //        }
        //    }
        //}
        //private void dgvWarehouse_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewRow row = dgvWarehouse.Rows[e.RowIndex];

        //    //cbWarehouse.Text = row.Cells["Name"].Value.ToString();
        //    //this.Controls.RemoveByKey("pWarehouse");
        //    //cbWarehouse.Focus();
        //    //Id.showWH = false;
        //}

        //private void dgvWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewRow row = dgvWarehouse.Rows[e.RowIndex];

        //    Id.inventLocID = row.Cells["Name"].Value.ToString();
        //}

        

        private void txtFactor_TextChanged(object sender, EventArgs e)
        {
            lblConLabel.Text = "1 " + cmbPOunit.Text + " = " + txtFactor.Text + " "+ cmbRetailUnit.Text +"";
            lblConLabel.Visible = true;
            Controls.RemoveByKey("factorError");
            txtFactor.Multiline = false;
            txtFactor.BorderStyle = BorderStyle.Fixed3D;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtBarcode.Text = Id.barcode;
                //string ean13 = barcode.GenerateEan13();
                //txtBarcode.Text = ean13;
                //txtPosDesc.Text = Id.globalString;
                //Id.barcode = txtBarcode.Text;
            }
            else 
            {
                txtBarcode.Clear();
            }
        }

        private void cmbPOunit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Id.CPuomID = Convert.ToInt32(cmbPOunit.GetItemText(cmbPOunit.SelectedValue));
            Controls.RemoveByKey("poUnitError");
            cmbPOunit.FlatStyle = FlatStyle.Standard;
        }

        private void cmbRetailUnit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Id.RPuomID = Convert.ToInt32(cmbRetailUnit.GetItemText(cmbRetailUnit.SelectedValue));
            Controls.RemoveByKey("retailUnitError");
            cmbRetailUnit.FlatStyle = FlatStyle.Standard;
        }

        private void cmbRetailUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbPOunit.Text != cmbRetailUnit.Text)
            {
                txtFactor.Enabled = true;
            }
            else
            {
                txtFactor.Enabled = false;
            }
        }

        private void cmbPOunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbRetailUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Id.isConcession == false)
            {
                if (cmbRetailUnit.Text == cmbPOunit.Text)
                {
                    lblFactor.Enabled = false;
                    txtFactor.Enabled = false;
                    lblConLabel.Enabled = false;
                }
                else
                {
                    lblFactor.Enabled = true;
                    txtFactor.Enabled = true;
                    lblConLabel.Enabled = true;
                }
            }
        }

        private void cmbPOunit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Id.isConcession == false)
            {
                if (cmbPOunit.Text == cmbRetailUnit.Text)
                {
                    lblFactor.Enabled = false;
                    txtFactor.Enabled = false;
                    lblConLabel.Enabled = false;
                }
                else
                {
                    lblFactor.Enabled = true;
                    txtFactor.Enabled = true;
                    lblConLabel.Enabled = true;
                }
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
            Controls.Add(p);

        }

        private void txtPosDesc_Leave(object sender, EventArgs e)
        {
            //if(txtPosDesc.Text.Equals(""))
            //{
            //    pName = "descError";
            //    oW = txtPosDesc.Size.Width;
            //    oH = txtPosDesc.Size.Height;
            //    x = txtPosDesc.Location.X - 2;
            //    y = txtPosDesc.Location.Y - 2;
            //    w = oW + 4;
            //    h = oH + 4;
            //    redBorder();
            //    txtPosDesc.BorderStyle = BorderStyle.None;
            //    txtPosDesc.Multiline = true;
            //    txtPosDesc.Size = new System.Drawing.Size(oW, oH);
            //}
            //else if(db.barcodes.Where(a => a.posDesc.Equals(txtPosDesc.Text)).Any())
            //{
            //    pName = "descError";
            //    oW = txtPosDesc.Size.Width;
            //    oH = txtPosDesc.Size.Height;
            //    x = txtPosDesc.Location.X - 2;
            //    y = txtPosDesc.Location.Y - 2;
            //    w = oW + 4;
            //    h = oH + 4;
            //    redBorder();
            //    txtPosDesc.BorderStyle = BorderStyle.None;
            //    txtPosDesc.Multiline = true;
            //    txtPosDesc.Size = new System.Drawing.Size(oW, oH);
            //}
            //else
            //{
            //    Controls.RemoveByKey("descError");
            //    txtPosDesc.Multiline = false;
            //    txtPosDesc.BorderStyle = BorderStyle.Fixed3D;
            //}
        }

        private void txtPosDesc_TextChanged(object sender, EventArgs e)
        {
            //Controls.RemoveByKey("descError");
            //txtPosDesc.Multiline = false;
            //txtPosDesc.BorderStyle = BorderStyle.Fixed3D;
        }

        private void barcodeError()
        {
            pName = "barcodeError";
            oW = txtBarcode.Size.Width;
            oH = txtBarcode.Size.Height;
            x = txtBarcode.Location.X - 2;
            y = txtBarcode.Location.Y - 2;
            w = oW + 4;
            h = oH + 4;
            Controls.RemoveByKey("barcodeError");
            //txtBarcode.BorderStyle = BorderStyle.None;
            //txtBarcode.Multiline = true;
            redBorder();
            txtBarcode.Size = new System.Drawing.Size(oW, oH);
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            //if(Id.button.Equals("Create"))
            //{
            //    if(txtBarcode.Text.Equals(""))
            //    {
            //        barcodeError();
            //    }
            //    else
            //    {
            //        if(!db.barcodes.Any(a => a.barcode1.Equals(txtBarcode.Text)))
            //        {
            //            Controls.RemoveByKey("barcodeError");
            //            //txtBarcode.Multiline = false;
            //            //txtBarcode.BorderStyle = BorderStyle.Fixed3D;
            //        }

            //        else
            //        {
            //            barcodeError();
            //        }
            //    }
            //}
            //else if(Id.button.Equals("Update"))
            //{
            //    DataTable dt = pc.fetchRecordById("sp_Product", "Barcode", "fetchBarcodeById", txtBarcode.Text);
            //    DataView dv = new DataView();
            //    dt.TableName = "validate";
            //    dv.Table = dt;
            //    if(dt.Rows.Count > 0)
            //    {
            //        MessageBox.Show();
            //    }
            //    //var objExcept = db.barcodes.Where(a => a.barcode1.Equals(Id.barcode));
            //    //var objExist = db.barcodes.Where(a => a.barcode1.Equals(txtBarcode.Text)).Except(objExcept);
            //    //if(objExist.Any())
            //    //{
            //    //    barcodeError();
            //    //}
            //    //else
            //    //{
            //    //    Controls.RemoveByKey("barcodeError");
            //    //    //txtBarcode.Multiline = false;
            //    //    //txtBarcode.BorderStyle = BorderStyle.Fixed3D;
            //    //}
            //}
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            Controls.RemoveByKey("barcodeError");
            //txtBarcode.Multiline = false;
            //txtBarcode.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtBarcode_MouseHover(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Equals(""))
            {
                toolTip1.Show("Barcode is required", txtBarcode);
            }
            else if (db.barcodes.Any(a => a.barcode1.Equals(txtBarcode.Text)))
            {
                toolTip1.Show("Barcode already exist", txtBarcode);
            }
            else
            {
                toolTip1.Hide(txtBarcode);
            }
        }

        private void cmbPOunit_Leave(object sender, EventArgs e)
        {
            if(cmbPOunit.Text.Equals(""))
            {
                pName = "poUnitError";
                oW = cmbPOunit.Size.Width;
                oH = cmbPOunit.Size.Height;
                x = cmbPOunit.Location.X - 2;
                y = cmbPOunit.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                Controls.RemoveByKey("poUnitError");
                redBorder();
                cmbPOunit.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                Controls.RemoveByKey("poUnitError");
                cmbPOunit.FlatStyle = FlatStyle.Standard;
            }
        }

        private void cmbPOunit_MouseHover(object sender, EventArgs e)
        {
            if(cmbPOunit.FlatStyle == FlatStyle.Flat)
            {
                toolTip1.Show("Purchase unit is required", cmbPOunit);
            }
            else
            {
                toolTip1.Hide(cmbPOunit);
            }
        }

        private void cmbRetailUnit_Leave(object sender, EventArgs e)
        {
            if(cmbRetailUnit.Text.Equals(""))
            {
                pName = "retailUnitError";
                oW = cmbRetailUnit.Size.Width;
                oH = cmbRetailUnit.Size.Height;
                x = cmbRetailUnit.Location.X - 2;
                y = cmbRetailUnit.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                Controls.RemoveByKey("retailUnitError");
                redBorder();
                cmbRetailUnit.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                Controls.RemoveByKey("retailUnitError");
                cmbRetailUnit.FlatStyle = FlatStyle.Standard;
            }
        }

        private void cmbRetailUnit_MouseHover(object sender, EventArgs e)
        {
            if(cmbRetailUnit.FlatStyle == FlatStyle.Flat)
            {
                toolTip1.Show("Retail unit is required", cmbRetailUnit);
            }
            else
            {
                toolTip1.Hide(cmbRetailUnit);
            }
        }

        private void txtFactor_Leave(object sender, EventArgs e)
        {
            if(txtFactor.Visible == true)
            {
                if(txtFactor.Text.Equals(""))
                {
                    pName = "factorError";
                    oW = txtFactor.Size.Width;
                    oH = txtFactor.Size.Height;
                    x = txtFactor.Location.X - 2;
                    y = txtFactor.Location.Y - 2;
                    w = oW + 4;
                    h = oH + 4;
                    Controls.RemoveByKey("factorError");
                    redBorder();
                    txtFactor.Size = new Size(oW, oH);
                }
                else
                {
                    Controls.RemoveByKey("factorError");
                }
                if(!string.IsNullOrEmpty(txtPOcostP.Text) && txtPOcostP.Text != "0.00")
                {
                    if (Id.isConcession != true)
                    {
                        if (!string.IsNullOrEmpty(Id.suppID))
                        {
                            DataTable dt = suppClass.getSupplierById("fetchSupplierById", Id.suppID);
                            //var objTax = db.vwSuppliers.Where(a => a.Supplier_ID == Id.suppID);
                            if (dt.Rows.Count > 0)
                            {
                                decimal factor;
                                string itemTaxID;// = objTax.SingleOrDefault().itemTaxID;
                                //var objPercent = db.taxSetups.Where(a => a.itemTaxID == itemTaxID).SingleOrDefault();
                                decimal itemTax = 0.00m;// = Convert.ToDecimal(objPercent.percent);
                                decimal costP = Convert.ToDecimal(txtPOcostP.Text);
                                foreach (DataRow row in dt.Rows)
                                {
                                    itemTaxID = row["itemTaxID"].ToString();
                                    itemTax = Convert.ToDecimal(row["percent"].ToString());
                                }
                                //decimal factor;
                                //string itemTaxID = //objTax.SingleOrDefault().itemTaxID;
                                //var objPercent = db.taxSetups.Where(a => a.itemTaxID == itemTaxID).SingleOrDefault();
                                //decimal itemTax = Convert.ToDecimal(objPercent.percent);
                                //decimal costP = Convert.ToDecimal(txtPOcostP.Text);
                                if (txtFactor.Enabled == true && !string.IsNullOrEmpty(txtFactor.Text))
                                {
                                    factor = Convert.ToDecimal(txtFactor.Text);
                                }
                                else
                                {
                                    factor = 1;
                                }
                                decimal result;
                                if (txtFactor.Enabled == false && Id.percent == 0)
                                {
                                    txtInventoryCost.Text = Convert.ToString(Decimal.Round((costP / ((itemTax + 100) / 100)), 2));
                                    //result = ;
                                    //txtInventoryCost.Text = result.ToString();
                                }
                                else if (txtFactor.Enabled == false && Id.percent != 0)
                                {
                                    txtInventoryCost.Text = Convert.ToString(Decimal.Round((costP * Id.percent) / ((itemTax + 100) / 100), 2));
                                    //result = (costP * Id.percent) / itemTax;
                                    //txtInventoryCost.Text = result.ToString();
                                }
                                else if (txtFactor.Enabled == true && Id.percent != 0)
                                {
                                    txtInventoryCost.Text = Convert.ToString(Decimal.Round(((costP * Id.percent) / factor) / ((itemTax + 100) / 100), 2));
                                    //result = ((costP / factor) * Id.percent)  / itemTax;
                                    //txtInventoryCost.Text = result.ToString();
                                }
                                else if (txtFactor.Enabled == true && Id.percent == 0)
                                {
                                    txtInventoryCost.Text = Convert.ToString(Decimal.Round((costP / factor) / ((itemTax + 100) / 100), 2));
                                    //result = (costP / factor) / itemTax;
                                    //txtInventoryCost.Text = result.ToString();
                                }

                            }

                        }
                        else
                        {
                            MessageBox.Show("Supplier ID is required for inventory cost", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void txtFactor_MouseHover(object sender, EventArgs e)
        {
            if(txtFactor.Visible == true && txtFactor.Text.Equals(""))
            {
                toolTip1.Show("Factor is required", txtFactor);
            }
            else
            {
                toolTip1.Hide(txtFactor);
            }
        }

        private void txtPOcostP_Leave(object sender, EventArgs e)
        {
            if(txtPOcostP.Text.Equals(""))
            {
                pName = "POcostError";
                oW = txtPOcostP.Size.Width;
                oH = txtPOcostP.Size.Height;
                x = txtPOcostP.Location.X - 2;
                y = txtPOcostP.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                Controls.RemoveByKey("POcostError");
                redBorder();
                txtPOcostP.Size = new Size(oW, oH);
            }
            else
            {
                Controls.RemoveByKey("POcostError");
            }
            if (Id.isConcession != true)
            {
                if (!string.IsNullOrEmpty(Id.suppID))
                {
                    DataTable dt = suppClass.getSupplierById("fetchSupplierById", Id.suppID);
                    //var objTax = db.vwSuppliers.Where(a => a.Supplier_ID == Id.suppID);
                    if (dt.Rows.Count > 0)
                    {
                        decimal factor;
                        string itemTaxID;// = objTax.SingleOrDefault().itemTaxID;
                        //var objPercent = db.taxSetups.Where(a => a.itemTaxID == itemTaxID).SingleOrDefault();
                        decimal itemTax = 0.00m;// = Convert.ToDecimal(objPercent.percent);
                        decimal costP = Convert.ToDecimal(txtPOcostP.Text);
                        foreach(DataRow row in dt.Rows)
                        {
                            itemTaxID = row["itemTaxID"].ToString();
                            itemTax = Convert.ToDecimal(row["percent"].ToString());
                        }
                        //decimal factor;
                        //string itemTaxID = //objTax.SingleOrDefault().itemTaxID;
                        //var objPercent = db.taxSetups.Where(a => a.itemTaxID == itemTaxID).SingleOrDefault();
                        //decimal itemTax = Convert.ToDecimal(objPercent.percent);
                        //decimal costP = Convert.ToDecimal(txtPOcostP.Text);
                        if(txtFactor.Enabled == true && !string.IsNullOrEmpty(txtFactor.Text))
                        {
                            factor = Convert.ToDecimal(txtFactor.Text);
                        }
                        else
                        {
                            factor = 1;
                        }
                        decimal result;
                        if (txtFactor.Enabled == false && Id.percent == 0)
                        {
                            txtInventoryCost.Text = Convert.ToString(Decimal.Round((costP / ((itemTax + 100) / 100)), 2));
                            //result = ;
                            //txtInventoryCost.Text = result.ToString();
                        }
                        else if (txtFactor.Enabled == false && Id.percent != 0)
                        {
                            txtInventoryCost.Text = Convert.ToString(Decimal.Round((costP * Id.percent) / ((itemTax + 100) / 100), 2));
                            //result = (costP * Id.percent) / itemTax;
                            //txtInventoryCost.Text = result.ToString();
                        }
                        else if (txtFactor.Enabled == true && Id.percent != 0)
                        {
                            txtInventoryCost.Text = Convert.ToString(Decimal.Round(((costP * Id.percent) / factor) / ((itemTax + 100) / 100), 2));
                            //result = ((costP / factor) * Id.percent)  / itemTax;
                            //txtInventoryCost.Text = result.ToString();
                        }
                        else if (txtFactor.Enabled == true && Id.percent == 0)
                        {
                            txtInventoryCost.Text = Convert.ToString(Decimal.Round((costP / factor) / ((itemTax + 100) / 100), 2));
                            //result = (costP / factor) / itemTax;
                            //txtInventoryCost.Text = result.ToString();
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Supplier ID is required for inventory cost", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtPOcostP_MouseHover(object sender, EventArgs e)
        {
            if(txtPOcostP.Text.Equals(""))
            {
                toolTip1.Show("Cost price is required", txtPOcostP);
            }
            else
            {
                toolTip1.Hide(txtPOcostP);
            }
        }

        private void txtPOcostP_TextChanged(object sender, EventArgs e)
        {
            Controls.RemoveByKey("POcostError");
        }

        private void txtRetailP_Leave(object sender, EventArgs e)
        {
            if (txtRetailP.Text.Equals(""))
            {
                pName = "retailPerror";
                oW = txtRetailP.Size.Width;
                oH = txtRetailP.Size.Height;
                x = txtRetailP.Location.X - 2;
                y = txtRetailP.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                Controls.RemoveByKey("retailPerror");
                redBorder();
                txtRetailP.Size = new Size(oW, oH);
            }
            else
            {
                Controls.RemoveByKey("retailPerror");
            }
        }

        private void txtRetailP_TextChanged(object sender, EventArgs e)
        {
            Controls.RemoveByKey("retailPerror");
        }

        private void txtRetailP_MouseHover(object sender, EventArgs e)
        {
            if (txtRetailP.Text.Equals(""))
            {
                toolTip1.Show("Cost price is required", txtRetailP);
            }
            else
            {
                toolTip1.Hide(txtRetailP);
            }
        }

        string profile;
        private void txtBMRX_Click(object sender, EventArgs e)
        {
            profile = "BMRX";
            pPopup.Hide();
            pPopup.Size = new Size(241, 195);
            pPopup.Location = new Point(250, 284);
            profileID = 2;
            populateTreeView();
            pPopup.Show();
        }

        private void txtPrivilege_Click(object sender, EventArgs e)
        {
            profile = "Privilege";
            pPopup.Hide();
            pPopup.Size = new Size(233, 193);
            pPopup.Location = new Point(163, 286);
            profileID = 3;
            populateTreeView();
            pPopup.Show();
            pPurchaseDiscount.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(btnClose.Text == "Cancel")
            {
                DialogResult res = MessageBox.Show("Cancel creation of product details? This will not be saved", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if(res == DialogResult.Yes)
                {
                    pc.deleteBarcode("sp_productDetails", "", "Delete", Id.barcode);
                    this.Hide();
                }
            }
            else if (btnClose.Text == "Close")
            {
                this.Hide();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtPurchaseDiscount_Click(object sender, EventArgs e)
        {
            pPurchaseDiscount.Show();
            pPurchaseDiscount.BringToFront();
            pWarehouse.Hide();
        }

        private void txtPrivilege_Enter(object sender, EventArgs e)
        {
            pPurchaseDiscount.Hide();
            pWarehouse.Hide();
        }

        private void txtBMRX_Enter(object sender, EventArgs e)
        {
            pPurchaseDiscount.Hide();
            pWarehouse.Hide();
        }

        private void txtPurchaseDiscount_Enter(object sender, EventArgs e)
        {
            pPopup.Hide();
            pWarehouse.Hide();
        }

        private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string siteID = cmbSite.SelectedValue.ToString();
            //cmbWarehouse.DataSource = (from a in db.warehouses where a.siteID == siteID select a).ToList();
            //cmbWarehouse.ValueMember = "whID";
            //cmbWarehouse.DisplayMember = "whDesc";
        }

        private void cmbWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string whID = cmbWarehouse.SelectedValue.ToString();
            //cmbIssueLocation.DataSource = (from a in db.whLocations where a.whID == whID select a).ToList();
            //cmbIssueLocation.ValueMember = "LID";
            //cmbIssueLocation.DisplayMember = "LID";

            //cmbReceiptLocation.DataSource = (from a in db.whLocations where a.whID == whID select a).ToList();
            //cmbReceiptLocation.ValueMember = "LID";
            //cmbReceiptLocation.DisplayMember = "LID";
        }

        private void txtConfig_Click(object sender, EventArgs e)
        {
            if (Id.button == "Create")
            {
                frmKitComponents kit = new frmKitComponents();
                if (!string.IsNullOrEmpty(txtConfig.Text) || !string.IsNullOrWhiteSpace(txtConfig.Text))
                {
                    MessageBox.Show("a");
                    int kitID = Convert.ToInt32(txtConfig.Text);

                    foreach(DataRow row in Id.dt.Rows)
                    {
                        kit.dgvComponents.Rows.Add(row["code"], row["barcode"], row["description"], row["qty"], row["unitID"], row["unit"]);
                    }
                    //var objGet = db.componentSetups.Where(a => a.kitID == kitID);
                    //if (objGet.Any())
                    //{
                    //    MessageBox.Show("b");
                    //    var objGetKit = (from a in db.componentSetups
                    //                     join b in db.barcodes on a.prodBarcode equals b.barcode1
                    //                     join c in db.UOMs on b.RPuomID equals c.uomID
                    //                     where a.code == objGet.SingleOrDefault().code
                    //                     select new 
                    //                     {
                    //                         a.kitID,
                    //                         a.code,
                    //                         a.prodBarcode,
                    //                         b.posDesc,
                    //                         a.qty,
                    //                         b.RPuomID,
                    //                         c.uomDesc
                    //                     }).ToList();
                            //db.componentSetups.Where(a => a.code == objGet.SingleOrDefault().code).ToList();

                    //    foreach(var item in objGetKit)
                    //    {
                    //        kit.dgvComponents.Rows.Add(item.prodBarcode, item.posDesc, item.qty, item.RPuomID, item.uomDesc);
                    //    }
                    //}
                    kit.ShowDialog();
                }
                else
                {
                    DialogResult res = kit.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        txtConfig.Text = Id.kitCode;
                    }
                }
            }
            else if(Id.button == "Update")
            {
                frmKitComponents kit = new frmKitComponents();
                DialogResult res = kit.ShowDialog();
                if (res == DialogResult.OK)
                {
                    txtConfig.Text = Id.kitCode;
                }
            }
        }

        private void txtBMRX_TextChanged(object sender, EventArgs e)
        {
            if(txtBMRX.Text.Contains("NO DISCOUNT"))
            {
                cbNotDiscountable.Checked = true;
            }
            else
            {
                cbNotDiscountable.Checked = false;
            }
        }

        private void txtConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtIssueLoc_Click(object sender, EventArgs e)
        {
            pWarehouse.Show();
            pWarehouse.BringToFront();
            pPopup.Hide();
            pPurchaseDiscount.Hide();
        }

        //try

        private void hidePopupForms_Enter(object sender, EventArgs e)
        {
            hide();
        }

        private void frmProductDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnClose.PerformClick();
        }
    }
}
