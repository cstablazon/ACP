using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;

namespace ACP
{
    public partial class frmModifyProd : Form
    {
        bool dropdownBtn;
        bool dropdownBtn2;
        bool dropdownBtn6;
        frmProductDetails barcodeInfo = new frmProductDetails();
        productCreation pc = new productCreation();
        supplierClass supClass = new supplierClass();
        CatHierarchyClass cat = new CatHierarchyClass();
        productClass prod = new productClass();
        acpEntities db = new acpEntities();
        barcodeClass barcode = new barcodeClass();
        public frmModifyProd()
        {
            InitializeComponent();
            brand();
            prodType();
            prodSubType();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            //Id.dropdown = "General";
            //timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Id.dropdown == "General")
            {
                if (dropdownBtn)
                {
                    pGeneral.Height += 20;
                    flowLayoutPanel1.Height += 15;
                    if (pGeneral.Height == pGeneral.MaximumSize.Height)
                    {
                        lblGeneral.Image = Properties.Resources.arrowDown10px;
                        dropdownBtn = false;
                        timer1.Stop();
                    }
                }
                else
                {
                    pGeneral.Height -= 20;
                    flowLayoutPanel1.Height -= 15;
                    if (pGeneral.Height == pGeneral.MinimumSize.Height)
                    {
                        lblGeneral.Image = Properties.Resources.arrowRight10px;
                        dropdownBtn = true;
                        timer1.Stop();
                    }
                }
            }
            else if (Id.dropdown == "Product Details")
            {
                if (dropdownBtn2)
                {
                    pProdCategory.Height -= 20;
                    flowLayoutPanel1.Height -= 20;
                    if (pProdCategory.Height == pProdCategory.MinimumSize.Height)
                    {
                        lblProdDetails.Image = Properties.Resources.arrowRight10px;
                        dropdownBtn2 = false;
                        timer1.Stop();
                    }
                }
                else
                {
                    pProdCategory.Height += 20;
                    flowLayoutPanel1.Height += 20;
                    if (pProdCategory.Height == pProdCategory.MaximumSize.Height)
                    {
                        lblProdDetails.Image = Properties.Resources.arrowDown10px;
                        dropdownBtn2 = true;
                        timer1.Stop();
                    }
                }
            }
            else if (Id.dropdown == "Financials")
            {
                if (dropdownBtn6)
                {
                    pFinancials.Height -= 20;
                    flowLayoutPanel1.Height -= 19;
                    if (pFinancials.Height == pFinancials.MinimumSize.Height)
                    {
                        lblFinancials.Image = Properties.Resources.arrowRight10px;
                        dropdownBtn6 = false;
                        timer1.Stop();
                    }

                }
                else
                {
                    pFinancials.Height += 20;
                    flowLayoutPanel1.Height += 19;
                    if (pFinancials.Height == pFinancials.MaximumSize.Height)
                    {
                        lblFinancials.Image = Properties.Resources.arrowDown10px;
                        dropdownBtn6 = true;
                        timer1.Stop();
                    }
                }
            }
        }
        public void brand()
        {
            DataSet ds = pc.cbRecords("Brand", "fetchBrand", "Brand");
            cmbBrand.DataSource = ds.Tables["Brand"];
            cmbBrand.DisplayMember = "Brand";
            cmbBrand.ValueMember = "brandID";
            cmbBrand.Text = "";
        }
       
        public  void prodType()
        {
            DataSet ds = pc.cbRecords("product_type", "fetchProduct_type", "prodTypeDesc");
            cmbProdType.DataSource = ds.Tables["prodTypeDesc"];
            cmbProdType.DisplayMember = "prodTypeDesc";
            cmbProdType.ValueMember = "prodTypeID";
            cmbProdType.Text = "";
            //var pType = db.product_type.Where(a => a.prodTypeDesc != "" && a.prodTypeDesc != null).Select(b => b.prodTypeDesc).ToArray();
            //cmbProdType.DataSource = db.product_type.ToList();
            //cmbProdType.ValueMember = "prodTypeID";
            //cmbProdType.DisplayMember = "prodTypeDesc";
            //cmbProdType.Text = "";
            
        }
        public void prodSubType()
        {
            DataSet ds = pc.cbRecords("product_subType", "fetchProduct_subType", "prodSubTypeDesc");
            cmbProdSubType.DataSource = ds.Tables["prodSubTypeDesc"];
            cmbProdSubType.DisplayMember = "prodSubTypeDesc";
            cmbProdSubType.ValueMember = "prodSubTypeID";
            cmbProdSubType.Text = "";
            //var pSubType = (from a in db.product_subType where a.prodSubTypeDesc != "" && a.prodSubTypeDesc != null select a.prodSubTypeDesc).ToArray();
            //cmbProdSubType.AutoCompleteCustomSource.AddRange(pSubType);
            //cmbProdSubType.DataSource = (from a in db.product_subType select a).ToList();
            //cmbProdSubType.ValueMember = "prodSubTypeID";
            //cmbProdSubType.DisplayMember = "prodSubTypeDesc";
            //cmbProdSubType.Text = "";
        }

        private void barcodeHideColumn()
        {

            dgvBarcode.Columns["CPuomID"].Visible = false;
            dgvBarcode.Columns["RPuomID"].Visible = false;
            dgvBarcode.Columns["bmrxID"].Visible = false;
            dgvBarcode.Columns["PID"].Visible = false;
            dgvBarcode.Columns["itemModelID"].Visible = false;
            dgvBarcode.Columns["chargeID"].Visible = false;
            dgvBarcode.Columns["LID"].Visible = false;
            //dgvBarcode.Columns["site"].Visible = false;
            dgvBarcode.Columns["discountID"].Visible = false;
            dgvBarcode.Columns["whID"].Visible = false;
        }
        
        private void fetchBarcode()
        {
            DataTable dt = pc.fetchRecords("sp_Product", "Product", "fetchBarcodeList", Id.SKU);
            dgvBarcode.DataSource = dt;
            //if(Id.button == "Create")
            //{
            //    Id.dtBarcode.Columns.Add("barcode", typeof(string));
            //    Id.dtBarcode.Columns.Add("posDesc", typeof(string));
            //    Id.dtBarcode.Columns.Add("CPuomID", typeof(int));
            //    Id.dtBarcode.Columns.Add("costUnit", typeof(string));
            //    Id.dtBarcode.Columns.Add("costPrice", typeof(decimal));
            //    Id.dtBarcode.Columns.Add("factor", typeof(decimal));
            //    Id.dtBarcode.Columns.Add("RPuomID", typeof(int));
            //    Id.dtBarcode.Columns.Add("retailUnit", typeof(string));
            //    Id.dtBarcode.Columns.Add("retailPrice", typeof(decimal));
            //    Id.dtBarcode.Columns.Add("inventoryCost", typeof(decimal));
            //    Id.dtBarcode.Columns.Add("bomID", typeof(int));
            //    Id.dtBarcode.Columns.Add("bom", typeof(string));
            //    Id.dtBarcode.Columns.Add("discountID", typeof(int));
            //    Id.dtBarcode.Columns.Add("purchaseDiscount", typeof(string));
            //    Id.dtBarcode.Columns.Add("purchaseTax", typeof(string));
            //    Id.dtBarcode.Columns.Add("salesTax", typeof(string));
            //    Id.dtBarcode.Columns.Add("bmrxID", typeof(long));
            //    Id.dtBarcode.Columns.Add("BMRX", typeof(string));
            //    Id.dtBarcode.Columns.Add("PID", typeof(long));
            //    Id.dtBarcode.Columns.Add("privilegeSetup", typeof(string));
            //    Id.dtBarcode.Columns.Add("itemModelID", typeof(string));
            //    Id.dtBarcode.Columns.Add("itemModelGroup", typeof(string));
            //    Id.dtBarcode.Columns.Add("isDiscountable", typeof(bool));
            //    Id.dtBarcode.Columns.Add("chargeID", typeof(int));
            //    Id.dtBarcode.Columns.Add("chargeGroup", typeof(string));
            //    Id.dtBarcode.Columns.Add("kitCode", typeof(int));
            //    Id.dtBarcode.Columns.Add("LID", typeof(long));
            //    Id.dtBarcode.Columns.Add("issueLoc", typeof(string));
            //    Id.dtBarcode.Columns.Add("Site", typeof(string));
            //    Id.dtBarcode.Columns.Add("whID", typeof(string));
            //    Id.dtBarcode.Columns.Add("warehouse", typeof(string));

            //    dgvBarcode.DataSource = Id.dtBarcode;

            //    dgvBarcode.Columns["barcode"].HeaderText = "Barcode";
            //    dgvBarcode.Columns["posDesc"].HeaderText = "Product description";
            //    dgvBarcode.Columns["costUnit"].HeaderText = "Cost unit";
            //    dgvBarcode.Columns["costPrice"].HeaderText = "Cost price";
            //    dgvBarcode.Columns["factor"].HeaderText = "Factor";
            //    dgvBarcode.Columns["retailUnit"].HeaderText = "Retail unit";
            //    dgvBarcode.Columns["retailPrice"].HeaderText = "Retail price";
            //    dgvBarcode.Columns["inventoryCost"].HeaderText = "Inventory cost";
            //    dgvBarcode.Columns["bom"].HeaderText = "BOM";
            //    dgvBarcode.Columns["purchaseDiscount"].HeaderText = "Purchase discount";
            //    dgvBarcode.Columns["purchaseTax"].HeaderText = "Purchase tax";
            //    dgvBarcode.Columns["salesTax"].HeaderText = "sales tax";
            //    dgvBarcode.Columns["Privilegesetup"].HeaderText = "Privilege setup";
            //    dgvBarcode.Columns["itemModelGroup"].HeaderText = "Item model group";
            //    dgvBarcode.Columns["chargeGroup"].HeaderText = "Charge group";
            //    dgvBarcode.Columns["kitCode"].HeaderText = "Kit code";
            //    dgvBarcode.Columns["issueLoc"].HeaderText = "Issue location";
            //    dgvBarcode.Columns["Warehouse"].HeaderText = "Warehouse";
            //    //var col1 = new DataGridViewTextBoxColumn();
            //    //var col2 = new DataGridViewTextBoxColumn();
            //    //var col3 = new DataGridViewTextBoxColumn();
            //    //var col4 = new DataGridViewTextBoxColumn();
            //    //var col5 = new DataGridViewTextBoxColumn();
            //    //var col6 = new DataGridViewTextBoxColumn();
            //    //var col7 = new DataGridViewTextBoxColumn();
            //    //var col8 = new DataGridViewTextBoxColumn();
            //    //var col9 = new DataGridViewTextBoxColumn();
            //    //var col10 = new DataGridViewTextBoxColumn();
            //    //var col11 = new DataGridViewTextBoxColumn();
            //    //var col12 = new DataGridViewTextBoxColumn();
            //    //var col13 = new DataGridViewTextBoxColumn();
            //    //var col14 = new DataGridViewTextBoxColumn();
            //    //var col15 = new DataGridViewTextBoxColumn();
            //    //var col16 = new DataGridViewTextBoxColumn();
            //    //var col17 = new DataGridViewTextBoxColumn();
            //    //var col18 = new DataGridViewTextBoxColumn();
            //    //var col19 = new DataGridViewTextBoxColumn();
            //    //var col20 = new DataGridViewTextBoxColumn();
            //    //var col21 = new DataGridViewCheckBoxColumn();
            //    //var col22 = new DataGridViewCheckBoxColumn();
            //    //var col23 = new DataGridViewTextBoxColumn();
            //    //var col24 = new DataGridViewTextBoxColumn();
            //    //var col25 = new DataGridViewTextBoxColumn();
            //    //var col26 = new DataGridViewTextBoxColumn();
            //    //var col27 = new DataGridViewTextBoxColumn();
            //    //var col28 = new DataGridViewTextBoxColumn();
            //    //var col29 = new DataGridViewTextBoxColumn();
            //    //var col30 = new DataGridViewTextBoxColumn();

            //    //col1.HeaderText = "Barcode";
            //    //col1.Name = "barcode";
            //    //col2.HeaderText = "Product description";
            //    //col2.Name = "_productDesc";
            //    //col3.Name = "CPuomID";
            //    //col4.HeaderText = "Cost unit";
            //    //col4.Name = "PO Unit";
            //    //col5.HeaderText = "Cost price";
            //    //col5.Name = "Cost price";
            //    //col6.HeaderText = "Factor";
            //    //col6.Name = "Factor";
            //    //col7.Name = "RPuomID";
            //    //col8.HeaderText = "Retail unit";
            //    //col8.Name = "Retail Unit";
            //    //col9.HeaderText = "Retail Price";
            //    //col9.Name = "Retail price";
            //    //col10.HeaderText = "Inventory cost";
            //    //col10.Name = "Inventory cost";
            //    //col11.Name = "discountID";
            //    //col12.HeaderText = "Purchase discount";
            //    //col12.Name = "Purchase discount";
            //    //col13.HeaderText = "Purchase tax";
            //    //col14.Name = "Purchase tax";
            //    //col14.HeaderText = "Sales tax";
            //    //col14.Name = "Sales tax";
            //    //col15.Name = "DID";
            //    //col16.HeaderText = "BMRX";
            //    //col16.Name = "BMRX";
            //    //col17.Name = "PID";
            //    //col18.HeaderText = "Privilege setup";
            //    //col18.Name = "Privilege setup";
            //    //col19.Name = "itemModelID";
            //    //col20.HeaderText = "Item model group";
            //    //col20.Name = "Item model group";
            //    //col21.HeaderText = "isDiscountable";
            //    //col21.Name = "isDiscountable";
            //    //col22.HeaderText = "isActive";
            //    //col22.Name = "isActive";
            //    //col23.Name = "chargeID";
            //    //col24.HeaderText = "Charge description";
            //    //col24.Name = "Charge description";
            //    //col25.HeaderText = "Kit code";
            //    //col25.Name = "Kit code";
            //    //col26.Name = "LID";
            //    //col27.HeaderText = "Location";
            //    //col27.Name = "Location";
            //    //col28.HeaderText = "Site ID";
            //    //col28.Name = "Site ID";
            //    //col29.Name = "whID";
            //    //col30.HeaderText = "Warehouse";
            //    //col30.Name = "Warehouse";

            //    //dgvBarcode.Columns.AddRange(new DataGridViewColumn[] {col1, col2, col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16, col17, col18, col19, col20, col21, col22, col23, col24, col25, col26, col27, col28, col29, col30});

            //}
            //else if(Id.button == "Update")
            //{
            //}
        }
        
        private void frmModifyProd_Load(object sender, EventArgs e)
        {
            fetchBarcode();
            barcodeHideColumn();
            categoryForm();
            p.Hide();
            supplierForm();
            panel.Hide();
            if(Id.button.Equals("Create"))
            {
                cmbProdSubType.Text = "";
                cmbProdType.Text = "";
                cmbBrand.Text = "";
            }
            
            dgvBarcode.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvBarcode, true, null);
            dgvBarcode.ClearSelection();
             flowLayoutPanel1.Height = 376;

        }

        

        

        private void lblInventory_Click(object sender, EventArgs e)
        {
            Id.dropdown = "Inventory";
            timer1.Start();
        }

        private void lblFinancials_Click(object sender, EventArgs e)
        {
            Id.dropdown = "Financials";
            timer1.Start();
        }

        private void storageDimensionGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStorageGroup sg = new frmStorageGroup();
            sg.ShowDialog();
        }

        private void itemModelGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemModelGroup im = new frmItemModelGroup();
            im.ShowDialog();
        }

        private void trackingDimensionGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrackingGroup tg = new frmTrackingGroup();
            tg.ShowDialog();
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
                isConcession();
                productDetails();
        }

        private void createUpdate()
        {
            int prodTypeID = Convert.ToInt32(cmbProdType.SelectedValue);
            int prodSubTypeID = Convert.ToInt32(cmbProdSubType.SelectedValue);
            int? brandID;
            if (string.IsNullOrEmpty(cmbBrand.Text))
            {
                brandID = null;
            }
            else
            {
                brandID = Convert.ToInt32(cmbBrand.SelectedValue);
            }
            if (Id.button == "Create")
            {
                MessageBox.Show("4");
                if (cmbProdSubType.Text == "Product master")
                {
                    MessageBox.Show("3");
                    if (string.IsNullOrEmpty(cmbProdDimension.Text))
                    {

                        MessageBox.Show("Fillup necessary information", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbProdDimension.Focus();
                        pName = "ProdDimensionError";
                        oW = cmbProdDimension.Size.Width;
                        oH = cmbProdDimension.Size.Height;
                        x = cmbProdDimension.Location.X - 2;
                        y = cmbProdDimension.Location.Y - 2;
                        w = oW + 4;
                        h = oH + 4;
                        Controls.RemoveByKey("prodDimensionError");
                        redBorder();
                        cmbProdDimension.FlatStyle = FlatStyle.Flat;
                    }
                    else
                    {
                        MessageBox.Show("2");
                        pc.createUpdateProduct("Update", Id.SKU, txtSKU.Text, Id.RIDL, prodTypeID, prodSubTypeID, Id.suppID, brandID, cmbProdDimension.Text, txtProdName.Text, cbConcession.Checked, Id.userID);
                        Id.SKU = txtSKU.Text;
                        lblProdDetails.Enabled = true;
                        btnClose.Text = "Close";
                        MessageBox.Show("Successfull created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("1");
                    pc.createUpdateProduct("Update", Id.SKU, txtSKU.Text, Id.RIDL, prodTypeID, prodSubTypeID, Id.suppID, brandID, cmbProdDimension.Text, txtProdName.Text, cbConcession.Checked, Id.userID);
                    Id.SKU = txtSKU.Text;
                    lblProdDetails.Enabled = true;
                    btnClose.Text = "Close";
                    MessageBox.Show("Successfull created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if(Id.button == "Update")
            {
                pc.createUpdateProduct("Update", Id.SKU, txtSKU.Text, Id.RIDL, prodTypeID, prodSubTypeID, Id.suppID, brandID, cmbProdDimension.Text, txtProdName.Text, cbConcession.Checked, Id.userID);
                Id.SKU = txtSKU.Text;
                MessageBox.Show("Successfull updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        int costTemp;
        int retailTemp;
        private void productDetails() {
           
            //try
            //{
            if (string.IsNullOrEmpty(txtCategory.Text))
            {
                MessageBox.Show("Category is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategory.Focus();
            }
            else if (string.IsNullOrEmpty(cmbProdType.Text))
            {
                MessageBox.Show("Product type is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbProdType.Focus();
            }
            else if (string.IsNullOrEmpty(cmbProdSubType.Text))
            {
                MessageBox.Show("Product sub type is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbProdSubType.Focus();
            }
            else if (cmbProdSubType.Text == "Product master" && string.IsNullOrEmpty(cmbProdDimension.Text))
            {
                MessageBox.Show("Product dimension is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbProdDimension.Focus();
            }
            else if (string.IsNullOrEmpty(txtSKU.Text))
            {
                MessageBox.Show("SKU is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSKU.Focus();
            }
            else if (string.IsNullOrEmpty(txtProdName.Text))
            {
                MessageBox.Show("Product name is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProdName.Focus();
            }
            else if (string.IsNullOrEmpty(txtSupplier.Text))
            {
                MessageBox.Show("Supplier is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSupplier.Focus();
            }
            else
            {
                createUpdate();
            }
        
        }
        private void tsBtnSave_Click(object sender, EventArgs e)
        {

        }
        private void lblOtherPrice_Click(object sender, EventArgs e)
        {
            Id.dropdown = "otherPrice";
            timer1.Start();
        }
        private void txtPOcostP_TextChanged(object sender, EventArgs e)
        {
        }
        private void lblProdDetails_Click(object sender, EventArgs e)
        {
            Id.dropdown = "Product Details";
            timer1.Start();
        }
        private void lblInventory_Click_1(object sender, EventArgs e)
        {
            Id.dropdown = "Inventory";
        }

        private void templateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdTemplate template = new frmProdTemplate();
            template.ShowDialog();
        }
        private void isConcession()
        {
            if (cbConcession.Checked == true)
            {
                Id.isConcession = true;
            }
            else
            {

                Id.isConcession = false;
            }
        }

        private void cbConcession_CheckedChanged(object sender, EventArgs e)
        {
            isConcession();
        }
        private void cbCategoryCode_Click(object sender, EventArgs e)
        {

            //if (Id.access == "NEWPROD")
            //{
            //    if (Id.shown)
            //    {
            //        pGeneral.Controls.RemoveByKey("pCatHierarchy");
            //        cmbCategoryCode.Focus();
            //        //cbCategoryCode.DroppedDown = false;
            //        //this.BeginInvoke(new Action(() => cbCategoryCode.SelectionLength = 0));
            //        Id.shown = false;
            //    }
            //    else
            //    {
            //        pGeneral.Controls.RemoveByKey("pSupplier");
            //        Panel p = new Panel();
            //        p.Size = new System.Drawing.Size(239, 196);
            //        p.Location = new Point(152, 148);
            //        p.Name = "pCatHierarchy";
            //        p.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //        pGeneral.Controls.Add(p);
            //        p.BringToFront();
            //        frmCatHierarchy ch = new frmCatHierarchy { TopLevel = false };
            //        ch.panel1.Visible = false;
            //        p.Controls.Clear();
            //        //ch.LostFocus += new EventHandler(f_LostFocus);
            //        p.Controls.Add(ch);
            //        ch.BringToFront();
            //        ch.Show();
            //        cmbCategoryCode.Focus();
            //        //cbCategoryCode.DroppedDown = false;z
            //        //this.BeginInvoke(new Action(() => cbCategoryCode.SelectionLength = 0));
            //        Id.shown = true;
            //    }
            //}
        }
        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsBtnNewBarcode_Click(object sender, EventArgs e)
        {
            frmProductDetails additionalInfo = new frmProductDetails();
            additionalInfo.btnCreate.Text = "Create";
            additionalInfo.btnClose.Text = "Cancel";
            Id.barcode = barcode.GenerateEan13();
            pc.createUpdateBarcode("Create", Id.barcode, Id.SKU, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, true, Id.userID, Id.barcode);
            additionalInfo.txtPosDesc.Text = Id.globalString2;
            //int autoIncBarcode = pc.autoInc("barcode", "barcode");
            //Id.barcode = string.Format("{0:0000000000000}", autoIncBarcode);
            //pc.createUpdateBarcode("Barcode", "Create", Id.barcode, Id.SKU, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, true, Id.userID, Id.barcode);
            if(additionalInfo.ShowDialog() == DialogResult.OK)
            {
                //if (Id.button == "Create")
                //{
                //    dgvBarcode.DataSource = Id.dtBarcode;
                //    //dgvBarcode.Rows.Add(additionalInfo.txtBarcode.Text, char.ToUpper(additionalInfo.txtPosDesc.Text[0]) + additionalInfo.txtPosDesc.Text.Substring(1), additionalInfo.cmbPOunit.SelectedValue, additionalInfo.cmbPOunit.Text, additionalInfo.txtPOcostP.Text, additionalInfo.txtFactor.Text, additionalInfo.cmbRetailUnit.SelectedValue, additionalInfo.cmbRetailUnit.Text, additionalInfo.txtRetailP.Text, additionalInfo.txtInventoryCost.Text, Id.discountID, additionalInfo.txtPurchaseDiscount.Text, additionalInfo.cmbPurchaseTax.SelectedValue, additionalInfo.cmbSalesTax.SelectedValue, Id.bmrxID, additionalInfo.txtBMRX.Text, Id.privilegeID, additionalInfo.txtPrivilege.Text, additionalInfo.cmbItemModel.SelectedValue, additionalInfo.cmbItemModel.Text, additionalInfo.cbNotDiscountable.Checked, true, additionalInfo.cmbCharges.SelectedValue, additionalInfo.cmbCharges.Text, additionalInfo.txtConfig.Text, Id.LID, additionalInfo.txtIssueLoc.Text, additionalInfo.txtSite.Text, Id.whID, additionalInfo.txtWarehouse.Text);
                //    barcodeHideColumn();
                //}
                //else if(Id.button == "Update")
                //{
                    fetchBarcode();
                //}
            }
            //dgvBarcode.Rows.Add();
        }

        DataGridView dgvSupp;
        private void cbSuppID_Click(object sender, EventArgs e)
        {
            //if(Id.access == "NEWPROD")
            //{
            //    if(Id.shownSupp)
            //    {
            //        pGeneral.Controls.RemoveByKey("pSupplier");
            //        cmbSuppID.Focus();
            //        cmbSuppID.DroppedDown = false;
            //        Id.shownSupp = false;
            //    }
            //    else
            //    {
            //        cmbSuppID.DroppedDown = false;
            //        pGeneral.Controls.RemoveByKey("pCatHierarchy");
            //        Panel pSupp = new Panel();
            //        pSupp.Size = new System.Drawing.Size(239, 196);
            //        pSupp.Location = new Point(152, 173);
            //        pSupp.Name = "pSupplier";
            //        pSupp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //        pGeneral.Controls.Add(pSupp);
            //        pSupp.BringToFront();
            //        dgvSupp = new DataGridView();
            //        dgvSupp.AllowUserToAddRows = false;
            //        dgvSupp.AllowUserToDeleteRows = false;
            //        dgvSupp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //        dgvSupp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //        dgvSupp.Dock = System.Windows.Forms.DockStyle.Fill;
            //        dgvSupp.MultiSelect = false;
            //        dgvSupp.ReadOnly = true;
            //        dgvSupp.RowHeadersVisible = false;
            //        dgvSupp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //        pSupp.Controls.Clear();
            //        pSupp.Controls.Add(dgvSupp);
            //        cmbSuppID.Focus();
            //        DataTable dt = pc.fetchRecord("VIEW", "FETCHCBSUPP", "", "", "", "", "", "");
            //        BindingSource source = new BindingSource();
            //        source.DataSource = dt;
            //        dgvSupp.DataSource = source;
            //        //dgvSupp.CellClick += dgvSupp_CellClick;
            //        dgvSupp.DataBindingComplete += dgvSupp_DataBindingComplete;
            //        dgvSupp.CellDoubleClick += dgvSupp_CellDoubleClick;

            //        Id.shownSupp = true;
            //    }
            //}
        }

        private void dgvSupp_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSupp.ClearSelection();
        }

        private void dgvBarcode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lbNewCat_Click(object sender, EventArgs e)
        {
            Id.access = "";
            frmCatHierarchy ch = new frmCatHierarchy();
            ch.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            ch.WindowState = System.Windows.Forms.FormWindowState.Normal;
            ch.ShowDialog();
        }

        private void lblNewSupp_Click(object sender, EventArgs e)
        {
            Id.access = "";
            Id.button = "Create";
            frmAddSupplier addSupp = new frmAddSupplier();
            if(addSupp.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void cbSuppID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Id.button = "Update";
            frmAddSupplier addSupp = new frmAddSupplier();
            addSupp.ShowDialog();
        }
        private void tsBtnAdditionalInfo_Click(object sender, EventArgs e)
        {
            frmProductDetails additionalInfo = new frmProductDetails();
            additionalInfo.ShowDialog();
        }

        private void frmModifyProd_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Id.access = "";
            //Id.dtBarcode.Columns.Clear();
            //Id.dtBarcode.Rows.Clear();
            btnClose.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text == "Cancel")
            {
                DialogResult res = MessageBox.Show("Cancel product creation? This product will not be saved", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    pc.deleteProduct("sp_productCreation", "", "Delete", Id.SKU);
                    this.Hide();
                }
            }
            else
            {
                this.hide();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtSKU_Enter(object sender, EventArgs e)
        {
            hide();
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
            pGeneral.Controls.Add(p);
            
        }

        private void txtSKU_Leave(object sender, EventArgs e)
        {

        }

        private void txtSKU_MouseHover(object sender, EventArgs e)
        {
            //if(txtSKU.BorderStyle == BorderStyle.None)
            //{
            //    if(txtSKU.Text.Equals(""))
            //    {
            //        toolTip1.Show("SKU is requried", txtSKU);
            //    }
            //    else if (db.products.Any(a => a.SKU == txtSKU.Text))
            //    {
            //        toolTip1.Show("SKU already exist", txtSKU);
            //    }
            //    else
            //    {
            //        toolTip1.Hide(txtSKU);
            //    }
            //}
        }

        private void cmbCategoryCode_Enter(object sender, EventArgs e)
        {
            //focus = true;
            //this.Refresh();
        }

        private void txtSKU_TextChanged(object sender, EventArgs e)
        {
            pGeneral.Controls.RemoveByKey("SKUerror");
        }

        private void cmbProdType_Leave(object sender, EventArgs e)
        {
            if(cmbProdType.Text.Equals(""))
            {
                pName = "prodTypeError";
                oW = cmbProdType.Size.Width;
                oH = cmbProdType.Size.Height;
                x = cmbProdType.Location.X - 2;
                y = cmbProdType.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                pGeneral.Controls.RemoveByKey("prodTypeError");
                redBorder();
                cmbProdType.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                pGeneral.Controls.RemoveByKey("prodTypeError");
                cmbProdType.FlatStyle = FlatStyle.Standard;
            }
        }

        private void cmbProdType_MouseHover(object sender, EventArgs e)
        {
            if(cmbProdType.FlatStyle == FlatStyle.Flat)
            {
                if(cmbProdType.Text.Equals(""))
                {
                    toolTip1.Show("Product type is required", cmbProdType);
                }
                else
                {
                    toolTip1.Hide(cmbProdType);
                }
            }
        }

        private void cmbProdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pGeneral.Controls.RemoveByKey("prodTypeError");
            cmbProdType.FlatStyle = FlatStyle.Standard;
        }

        private void cmbProdSubType_Leave(object sender, EventArgs e)
        {
            if(cmbProdSubType.Text.Equals(""))
            {
                pName = "prodSubTypeError";
                oW = cmbProdSubType.Size.Width;
                oH = cmbProdSubType.Size.Height;
                x = cmbProdSubType.Location.X - 2;
                y = cmbProdSubType.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                pGeneral.Controls.RemoveByKey("prodSubTypeError");
                redBorder();
                cmbProdSubType.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                pGeneral.Controls.RemoveByKey("prodSubTypeError");
                cmbProdSubType.FlatStyle = FlatStyle.Standard;
            }
        }

        private void cmbProdSubType_MouseHover(object sender, EventArgs e)
        {
            if(cmbProdSubType.FlatStyle == FlatStyle.Flat)
            {
                if(cmbProdSubType.Text.Equals(""))
                {
                    toolTip1.Show("Product sub type is required", cmbProdSubType);
                }
                else
                {
                    toolTip1.Hide(cmbProdSubType);
                }
            }
        }

        private void cmbProdSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pGeneral.Controls.RemoveByKey("prodSubTypeError");
            cmbProdSubType.FlatStyle = FlatStyle.Standard;
            if(cmbProdSubType.Text == "Product master")
            {
                cmbProdDimension.Enabled = true;
            }
            else
            {
                cmbProdDimension.Enabled = false;
            }
        }

        private void cmbLine_Leave(object sender, EventArgs e)
        {
            //if(cmbLine.Text.Equals(""))
            //{
            //    pName = "lineDiscError";
            //    oW = cmbLine.Size.Width;
            //    oH = cmbLine.Size.Height;
            //    x = cmbLine.Location.X - 2;
            //    y = cmbLine.Location.Y - 2;
            //    w = oW + 4;
            //    h = oH + 4;
            //    pGeneral.Controls.RemoveByKey("lineDiscError");
            //    redBorder();
            //    cmbLine.FlatStyle = FlatStyle.Flat;
            //}
            //else
            //{
            //    pGeneral.Controls.RemoveByKey("lineDiscError");
            //    cmbLine.FlatStyle = FlatStyle.Standard;
            //}
        }

        private void cmbLine_MouseHover(object sender, EventArgs e)
        {
            //if(cmbLine.FlatStyle == FlatStyle.Flat)
            //{
            //    if(cmbLine.Text.Equals(""))
            //    {
            //        toolTip1.Show("Line discount is required", cmbLine);
            //    }
            //    else
            //    {
            //        toolTip1.Hide(cmbLine);
            //    }
            //}
        }

        private void txtProdName_Leave(object sender, EventArgs e)
        {
            if(txtProdName.Text.Equals(""))
            {
                pName = "prodNameError";
                oW = txtProdName.Size.Width;
                oH = txtProdName.Size.Height;
                x = txtProdName.Location.X - 2;
                y = txtProdName.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                pGeneral.Controls.RemoveByKey("prodNameError");
                redBorder();
                //txtProdName.BorderStyle = BorderStyle.None;
                //txtProdName.Multiline = true;
                //txtProdName.Size = new System.Drawing.Size(oW, oH);
            }
            else
            {
                pGeneral.Controls.RemoveByKey("prodNameError");
                Id.globalString = txtProdName.Text;
                //txtProdName.Multiline = false;
                //txtProdName.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void txtProdName_MouseHover(object sender, EventArgs e)
        {
            if(txtProdName.BorderStyle == BorderStyle.None)
            {
                if(txtProdName.Text.Equals(""))
                {
                    toolTip1.Show("Product name is required", txtProdName);
                }
                else
                {
                    toolTip1.Hide(txtProdName);
                }
            }
        }

        private void txtProdName_TextChanged(object sender, EventArgs e)
        {
            pGeneral.Controls.RemoveByKey("prodNameError");
            //txtProdName.Multiline = false;
            //txtProdName.BorderStyle = BorderStyle.Fixed3D;
        }

        TreeView tv = new TreeView();
        Panel p = new Panel();
        //bool hideCat = true;
        public void categoryForm()
        {
            //if (hideCat == false)
            //{
            //    p.Show();
            //}
            //else
            //{
                //hideCat = false;
                p.Name = "pCategory";
                p.Size = new System.Drawing.Size(271, 182);
                p.Location = new Point(344, 62);
                pGeneral.Controls.Add(p);
                p.BringToFront();

                tv.AfterSelect += tv_AfterSelect;
                tv.DrawNode += tv_DrawNode;
                tv.NodeMouseDoubleClick += tv_NodeMouseDoubleClick;
                populateTreeView();
                tv.Name = "catHierarchy";
                tv.Dock = DockStyle.Fill;
                tv.DrawMode = TreeViewDrawMode.OwnerDrawText;
                p.Controls.Add(tv);
            //}
        }

        private TreeNode lastAddedNode = null;

        private void populateTreeView()
        {
            try
            {
                // Clears any existing nodes in the TreeView
                tv.Nodes.Clear();
                // Resets the lastAddedNode variable to null
                lastAddedNode = null;
                // Fetches a DataTable containing category hierarchy data
                DataTable dataTable = cat.fetchCatHierarchy();
                // Creates a dictionary to store TreeNode objects, with string keys and TreeNode values
                Dictionary<string, TreeNode> nodeDict = new Dictionary<string, TreeNode>();
                // Iterates through each row in the DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    // Extracts values from the current DataRow
                    string RID = row["RID"].ToString();
                    string desc = row["desc"].ToString();
                    string lbl = row["code"].ToString().Trim();
                    string rtype = Convert.IsDBNull(row["rType"]) ? "0" : row["rType"].ToString();
                    // Creates a new TreeNode with a label that combines "lbl" and "desc"
                    TreeNode node = new TreeNode(lbl + " " + desc);
                    // Sets the Tag property of the TreeNode to the value of "RID"
                    node.Tag = RID;
                    // Adds the TreeNode to the TreeView's root if "rtype" is "0"
                    if (rtype == "0")
                    {
                        tv.Nodes.Add(node);
                    }
                    // Adds the TreeNode to the parent node if the corresponding key exists in the dictionary
                    else
                    {
                        if (nodeDict.ContainsKey(rtype))
                        {
                            TreeNode parentNode = nodeDict[rtype];
                            parentNode.Nodes.Add(node);
                        }
                    }
                    // Adds the current TreeNode to the dictionary using "RID" as the key
                    nodeDict.Add(RID, node);
                    // Updates the lastAddedNode variable with the current TreeNode
                    lastAddedNode = node;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TreeNode FindNodeById(TreeNodeCollection nodes, string rType)
        {
            // Iterates through each TreeNode in the given TreeNodeCollection
            foreach (TreeNode node in nodes)
            {
                // Checks if the Tag property of the current node is equal to the provided "rType"
                if (node.Tag.Equals(rType))
                {
                    // Returns the current node if the Tag property matches "rType"
                    return node;
                }
                // Recursively calls the FindNodeById method on the child nodes of the current node
                TreeNode foundNode = FindNodeById(node.Nodes, rType);
                // Returns the found node if it is not null (indicating a match)
                if (foundNode != null)
                {
                    return foundNode;
                }
            }
            // Returns null if no matching node is found in the entire TreeNode hierarchy
            return null;
        }

        private void tv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void txtCategory_Click(object sender, EventArgs e)
        {
            //categoryForm();
            p.Show();
        }
        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Retrieves the currently selected TreeNode from the TreeView
            TreeNode selectedNode = tv.SelectedNode;
            // Retrieves the Tag property of the selected node and converts it to a string
            string selectedNodeID = selectedNode.Tag.ToString();
            // Sets a static property "rtypeID" in the "Id" class to the value of the selected node's ID
            Id.RID = selectedNodeID;
            Id.RIDL = Convert.ToInt64(selectedNodeID);
            // Checks if the selected node's text matches a specific condition
            
        }

        private void tv_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
                var category = (from a in db.hierarchies where a.RID == Id.RIDL select a).SingleOrDefault();
                if(!string.IsNullOrEmpty(category.rType))
                {
                    txtCategory.Text = category.code.Trim();
                    var dept = db.sp_catValidation("rid", Id.RIDL);
                    //txtCategory.Text = dept.subcat_code.Trim();
                    txtDepartment.Text = dept.FirstOrDefault().dept_desc;
                    ////p.Hide();
                    //hideCat = true;
                    txtCategory.BorderStyle = BorderStyle.Fixed3D;
                    p.Hide();
                }
                else
                {
                    MessageBox.Show("Please select under subcategory", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        DataGridView dgvSupplier = new DataGridView();
        Panel panel = new Panel();
        ComboBox cmbFilter = new ComboBox();
        TextBox txtSearch = new TextBox();
        public void supplierForm()
        {
            panel.Name = "pSupplier";
            panel.Size = new System.Drawing.Size(271, 204);
            panel.Location = new Point(345, 33);
            panel.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            //groupBox1.Controls.Add(p);

            DataTable dt = supClass.fetchSupplier("fetchSupplier", "");
            dgvSupplier.DataSource = dt;
            //dgvSupplier.DataSource = (from a in db.suppliers where a.isActive == true
            //                          select new
            //                          {
            //                              a.suppID,
            //                              a.name
            //                          }).ToList();

            cmbFilter.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            //cmbFilter.Size = new System.Drawing.Size(90, 25);
            cmbFilter.Dock = DockStyle.Top;
            cmbFilter.BringToFront();
            txtSearch.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            //txtSearch.Size = new System.Drawing.Size(139, 25);
            txtSearch.Dock = DockStyle.Top;
            txtSearch.BringToFront();
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("Supplier_ID");
            cmbFilter.Items.Add("Name");

            //dgvSupplier.Dock = DockStyle.Fill;
            dgvSupplier.Size = new System.Drawing.Size(271, 160);
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
            panel.Controls.Add(txtSearch);
            panel.Controls.Add(cmbFilter);
            panel.Controls.Add(dgvSupplier);
            pGeneral.Controls.Add(panel);
            dgvSupplier.Dock = DockStyle.Bottom;
            dgvSupplier.Columns["Agent"].Visible = false;
            dgvSupplier.Columns["Record_type"].Visible = false;
            dgvSupplier.Columns["group"].Visible = false;
            dgvSupplier.Columns["Payment_term"].Visible = false;
            dgvSupplier.Columns["itemTaxID"].Visible = false;
            dgvSupplier.Columns["Date_created"].Visible = false;
            dgvSupplier.Columns["isDistributor"].Visible = false;
            dgvSupplier.Columns["isActive"].Visible = false;
            dgvSupplier.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSupplier.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSupplier.Columns[0].HeaderText = "Supplier ID";
            dgvSupplier.Columns[1].HeaderText = "Name";
            panel.BorderStyle = BorderStyle.FixedSingle;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (cmbFilter.Text.Equals(""))
            {
                MessageBox.Show("Please select search filter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Clear();
            }
            else if (cmbFilter.Text.Equals("Supplier_ID"))
            {
                if (txtSearch.Text.Equals(""))
                {
                    DataTable dt = supClass.fetchSupplier("fetchSupplier", "");
                    dgvSupplier.DataSource = dt;
                    //dgvSupplier.DataSource = (from a in db.suppliers
                    //                          select new
                    //                          {
                    //                              a.suppID,
                    //                              a.name
                    //                          }).ToList();
                }
                else
                {
                    dgvSupplier.DataSource = (from a in db.suppliers
                                              where a.suppID.Contains(txtSearch.Text)
                                              select new
                                              {
                                                  a.suppID,
                                                  a.name
                                              }).ToList();
                }
            }
            else if (cmbFilter.Text.Equals("Name"))
            {
                if (txtSearch.Text.Equals(""))
                {
                    dgvSupplier.DataSource = (from a in db.suppliers
                                              select new
                                              {
                                                  a.suppID,
                                                  a.name
                                              }).ToList();
                }
                else
                {
                    dgvSupplier.DataSource = (from a in db.suppliers
                                              where a.name.Contains(txtSearch.Text)
                                              select new
                                              {
                                                  a.suppID,
                                                  a.name
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

        private void dgvSupplier_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSupplier.ClearSelection();
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSupplier.Rows[e.RowIndex];

                Id.globalID = row.Cells["Supplier_ID"].Value.ToString();
            }
        }
        

        private void txtSupplier_Click(object sender, EventArgs e)
        {
            panel.Show();
            panel.BringToFront();
        }

        private void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSupplier.Rows[e.RowIndex];

                txtSupplier.Text = row.Cells["Supplier_ID"].Value.ToString();
                Id.suppID = row.Cells["Supplier_ID"].Value.ToString();
                txtSupplier.BorderStyle = BorderStyle.Fixed3D;
                panel.Hide();
            }
        }

        public void hide()
        {
            p.Hide();
            panel.Hide();
        }

        private void txtSKU_Click(object sender, EventArgs e)
        {
            hide();
        }

        private void txtCategory_Enter(object sender, EventArgs e)
        {
            panel.Hide();
        }

        private void txtSupplier_Enter(object sender, EventArgs e)
        {
            hide();
        }

        private void txtProdName_Enter(object sender, EventArgs e)
        {
            hide();
        }

        private void cmbProdType_Enter(object sender, EventArgs e)
        {
            hide();
        }

        private void cmbProdSubType_Enter(object sender, EventArgs e)
        {
            hide();
        }

        private void cmbLine_Enter(object sender, EventArgs e)
        {
            hide();
        }

        private void cmbBrand_Enter(object sender, EventArgs e)
        {
            hide();
        }

        private void txtCategory_Leave(object sender, EventArgs e)
        {
            if(txtCategory.Text.Equals(""))
            {
                pName = "catError";
                oW = txtCategory.Size.Width;
                oH = txtCategory.Size.Height;
                x = txtCategory.Location.X - 2;
                y = txtCategory.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                pGeneral.Controls.RemoveByKey("catError");
                redBorder();
                //txtCategory.BorderStyle = BorderStyle.None;
                //txtCategory.Multiline = true;
                //txtCategory.Size = new System.Drawing.Size(oW, oH);
            }
            else
            {
                pGeneral.Controls.RemoveByKey("catError");
                //txtCategory.Multiline = false;
                //txtCategory.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void txtCategory_MouseHover(object sender, EventArgs e)
        {
            if(txtCategory.BorderStyle == BorderStyle.None)
            {
                if(txtCategory.Text.Equals(""))
                {
                    toolTip1.Show("Category is required", txtCategory);
                }
                else
                {
                    toolTip1.Hide(txtCategory);
                }
            }
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            pGeneral.Controls.RemoveByKey("catError");
            //txtCategory.Multiline = false;
            //txtSupplier.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtSupplier_Leave(object sender, EventArgs e)
        {
            if(txtSupplier.Text.Equals(""))
            {
                pName = "suppError";
                oW = txtSupplier.Size.Width;
                oH = txtSupplier.Size.Height;
                x = txtSupplier.Location.X - 2;
                y = txtSupplier.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                pGeneral.Controls.RemoveByKey("suppError");
                redBorder();
                //txtSupplier.BorderStyle = BorderStyle.None;
                //txtSupplier.Multiline = true;
                //txtSupplier.Size = new System.Drawing.Size(oW, oH);
            }
            else
            {
                pGeneral.Controls.RemoveByKey("suppError");
                Id.globalString = txtProdName.Text;
                //txtSupplier.Multiline = false;
                //txtSupplier.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            pGeneral.Controls.RemoveByKey("suppError");
            //txtSupplier.Multiline = false;
            //txtSupplier.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtSupplier_MouseHover(object sender, EventArgs e)
        {
            if(txtSupplier.BorderStyle == BorderStyle.None)
            {
                if(txtCategory.Text.Equals(""))
                {
                    toolTip1.Show("Supplier is requried", txtSupplier);
                }
                else
                {
                    toolTip1.Hide(txtSupplier);
                }
            }
        }

        private void cbSKU_CheckedChanged(object sender, EventArgs e)
        {
            txtSKU.Text = Id.SKU;
            //if (cbSKU.Checked)
            //{
            //    string ean8 = sku.GenerateEan8();
            //    txtSKU.Text = ean8;
            //}
            //else
            //{
            //    txtSKU.Clear();
            //}
        }

        private void tsbDeleteBarcode_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Delete product and its barcode?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                pc.deleteProduct("sp_Product", "Barcode", "Delete", Id.SKU);
                fetchBarcode();
                tsbDeleteBarcode.Enabled = false;
                tsbEdit.Enabled = false;
            }
            //DialogResult res = MessageBox.Show("Delete barcode?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if(res == DialogResult.Yes)
            //{
            //    if(Id.button.Equals("Create"))
            //    {
            //        if(dgvBarcode.SelectedRows.Count > 0)
            //        {
            //            dgvBarcode.Rows.RemoveAt(dgvBarcode.SelectedRows[0].Index);
            //        }
            //    }
            //    else if(Id.button.Equals("Update"))
            //    {
            //        var objDelete = db.barcodes.Where(a => a.barcode1.Equals(Id.barcode)).SingleOrDefault();

            //        db.barcodes.Remove(objDelete);
            //        db.SaveChanges();
            //        MessageBox.Show("Successfully deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dgvBarcode.Rows.Clear();
            //        fetchBarcode();
            //        dgvBarcode.ClearSelection();
            //    }
            //}
            
        }
        //private void fetchBarcode()
        //{
        //    var item = db.vwProducts.Where(a => a.SKU.Equals(Id.productID)).ToList();
        //    foreach (vwProduct barcode in item)
        //    {
        //        dgvBarcode.Rows.Add(barcode.Barcode, barcode.Product_description, barcode.CPuomID, barcode.PO_Unit, barcode.Cost_price, barcode.factor, barcode.RPuomID, barcode.Retail_Unit, barcode.Retail_price, barcode.inventoryCost, barcode.purchaseTax, barcode.salesTax, barcode.DID, barcode.BMRX, barcode.PID, barcode.Privilege_setup, barcode.itemModelID, barcode.itemModelDesc, barcode.isDiscountable, barcode.isActive, barcode.chargeID, barcode.chargeDesc, barcode.kitCode);
        //    }
        //}

        private void dgvBarcode_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmProductDetails addInfo = new frmProductDetails();
            addInfo.btnCreate.Text = "Update";
            if(Id.button.Equals("Update"))
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvBarcode.Rows[e.RowIndex];

                    Id.globalString2 = row.Cells["_barcode"].Value.ToString();
                    addInfo.txtBarcode.Text = row.Cells["_barcode"].Value.ToString();
                    addInfo.txtPosDesc.Text = row.Cells["_purchaseDesc"].Value.ToString();
                    addInfo.cmbPOunit.Text = row.Cells["_costUnit"].Value.ToString();
                    addInfo.cmbRetailUnit.Text = row.Cells["_retailUnit"].Value.ToString();
                    //addInfo.cmbBMRX.Text = row.Cells["_bmrx"].Value.ToString();
                    addInfo.txtPOcostP.Text = row.Cells["_costPrice"].Value.ToString();
                    addInfo.txtRetailP.Text = row.Cells["_retailPrice"].Value.ToString();
                    addInfo.cmbPurchaseTax.Text = row.Cells["purchaseTax"].Value.ToString();
                    addInfo.cmbSalesTax.Text = row.Cells["salesTax"].Value.ToString();
                    //if (!string.IsNullOrEmpty(row.Cells["_factor"].Value.ToString()))
                    //{
                        addInfo.txtFactor.Text = row.Cells["_factor"].Value as string;
                    //}
                    addInfo.cmbItemModel.Text = row.Cells["_itemModelGroup"].Value.ToString();
                    Id.discountID = Convert.ToInt32(row.Cells["discountID"].Value);
                    addInfo.txtPurchaseDiscount.Text = row.Cells["purchaseDiscount"].Value.ToString();
                    addInfo.txtInventoryCost.Text = row.Cells["inventoryCost"].Value.ToString();
                    Id.LID = row.Cells["LID"].Value.ToString();
                    addInfo.txtIssueLoc.Text = row.Cells["location"].Value.ToString();
                    addInfo.txtSite.Text = row.Cells["site"].Value.ToString();
                    addInfo.txtWarehouse.Text = row.Cells["warehouse"].Value.ToString();
                    Id.bmrxID = Convert.ToInt64(row.Cells["bmrxID"].Value);
                    addInfo.txtBMRX.Text = row.Cells["_bmrx"].Value.ToString();
                    addInfo.cbNotDiscountable.Checked = Convert.ToBoolean(row.Cells["isDiscountable"].Value);
                    addInfo.cmbCharges.Text = row.Cells["chargeGroup"].Value as string;
                    Id.privilegeID = Convert.ToInt64(row.Cells["privilegeID"].Value);
                    addInfo.txtPrivilege.Text = row.Cells["_privilegeSetup"].Value.ToString();
                    addInfo.txtConfig.Text = row.Cells["config"].Value as string;

                    DialogResult res = addInfo.ShowDialog();
                    if(res == DialogResult.OK)
                    {

                        var objUpdate = db.barcodes.Where(a => a.barcode1.Equals(addInfo.txtBarcode.Text)).SingleOrDefault();
                        decimal costPrice = Convert.ToDecimal(addInfo.txtPOcostP.Text);
                        decimal retailPrice = Convert.ToDecimal(addInfo.txtRetailP.Text);
                        int costID = Convert.ToInt32(addInfo.cmbPOunit.GetItemText(addInfo.cmbPOunit.SelectedValue));
                        int retailID = Convert.ToInt32(addInfo.cmbRetailUnit.GetItemText(addInfo.cmbRetailUnit.SelectedValue));
                        objUpdate.barcode1 = addInfo.txtBarcode.Text;
                        objUpdate.costPrice = costPrice;
                        objUpdate.retailPrice = retailPrice;
                        objUpdate.CPuomID = costID;
                        objUpdate.RPuomID = retailID;
                        objUpdate.posDesc = addInfo.txtPosDesc.Text;
                        objUpdate.DID = Id.bmrxID;

                        db.SaveChanges();
                        dgvBarcode.Rows.Clear();
                        fetchBarcode();
                    }
                }
            }
            else if(Id.button.Equals("Create"))
            {
                if(e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvBarcode.Rows[e.RowIndex];

                    Id.globalString2 = row.Cells["_barcode"].Value.ToString();
                    //addInfo.txtBarcode.Text = row.Cells["_barcode"].Value.ToString();
                    //addInfo.txtPosDesc.Text = row.Cells["_purchaseDesc"].Value.ToString();
                    //addInfo.cmbPOunit.Text = row.Cells["_costUnit"].Value.ToString();
                    //addInfo.cmbRetailUnit.Text = row.Cells["_retailPrice"].Value.ToString();
                    ////addInfo.cmbBMRX.Text = row.Cells["_bmrx"].Value.ToString();
                    //addInfo.txtPOcostP.Text = row.Cells["_costPrice"].Value.ToString();
                    //addInfo.txtRetailP.Text = row.Cells["_retailPrice"].Value.ToString();
                    //Id.isActive = Convert.ToBoolean(row.Cells["_isActive"].Value);
                    addInfo.txtBarcode.Text = row.Cells["_barcode"].Value.ToString();
                    addInfo.txtPosDesc.Text = row.Cells["_purchaseDesc"].Value.ToString();
                    addInfo.cmbPOunit.Text = row.Cells["_costUnit"].Value.ToString();
                    addInfo.cmbRetailUnit.Text = row.Cells["_retailUnit"].Value.ToString();
                    //addInfo.cmbBMRX.Text = row.Cells["_bmrx"].Value.ToString();
                    addInfo.txtPOcostP.Text = row.Cells["_costPrice"].Value.ToString();
                    addInfo.txtRetailP.Text = row.Cells["_retailPrice"].Value.ToString();
                    addInfo.cmbPurchaseTax.Text = row.Cells["purchaseTax"].Value.ToString();
                    addInfo.cmbSalesTax.Text = row.Cells["salesTax"].Value.ToString();
                    addInfo.txtFactor.Text = row.Cells["factor"].Value.ToString();
                    addInfo.cmbItemModel.Text = row.Cells["_itemModelGroup"].Value.ToString();
                    Id.discountID = Convert.ToInt32(row.Cells["discountID"].Value);
                    addInfo.txtPurchaseDiscount.Text = row.Cells["purchaseDiscount"].Value.ToString();
                    addInfo.txtInventoryCost.Text = row.Cells["invetoryCost"].Value.ToString();
                    Id.LID = row.Cells["LID"].Value.ToString();
                    addInfo.txtIssueLoc.Text = row.Cells["location"].Value.ToString();
                    addInfo.txtSite.Text = row.Cells["site"].Value.ToString();
                    addInfo.txtWarehouse.Text = row.Cells["warehouse"].Value.ToString();
                    Id.bmrxID = Convert.ToInt64(row.Cells["bmrxID"].Value);
                    addInfo.txtBMRX.Text = row.Cells["_bmrx"].Value.ToString();
                    addInfo.cbNotDiscountable.Checked = Convert.ToBoolean(row.Cells["isDiscountable"].Value);
                    addInfo.cmbCharges.Text = row.Cells["chargeGroup"].Value.ToString();
                    Id.privilegeID = Convert.ToInt64(row.Cells["privilegeID"].Value);
                    addInfo.txtPrivilege.Text = row.Cells["_privilegeSetup"].Value.ToString();
                    addInfo.txtConfig.Text = row.Cells["config"].Value.ToString();
                    DialogResult res = addInfo.ShowDialog();
                    if(res == DialogResult.OK)
                    {
                        dgvBarcode.Rows.RemoveAt(dgvBarcode.SelectedRows[0].Index);
                        dgvBarcode.Rows.Add(addInfo.txtBarcode.Text, char.ToUpper(addInfo.txtPosDesc.Text[0]) + addInfo.txtPosDesc.Text.Substring(1), addInfo.cmbPOunit.SelectedValue, addInfo.cmbPOunit.Text, addInfo.txtPOcostP.Text, addInfo.txtFactor.Text, addInfo.cmbRetailUnit.SelectedValue, addInfo.cmbRetailUnit.Text, addInfo.txtRetailP.Text, addInfo.txtInventoryCost.Text, Id.discountID, addInfo.txtPurchaseDiscount.Text, addInfo.cmbPurchaseTax.SelectedValue, addInfo.cmbSalesTax.SelectedValue, Id.bmrxID, addInfo.txtBMRX.Text, Id.privilegeID, addInfo.txtPrivilege.Text, addInfo.cmbItemModel.SelectedValue, addInfo.cmbItemModel.Text, addInfo.cbNotDiscountable.Checked, true, addInfo.cmbCharges.SelectedValue, addInfo.cmbCharges.Text, addInfo.txtConfig.Text, Id.LID, addInfo.txtIssueLoc.Text, addInfo.txtSite.Text, addInfo.txtWarehouse.Text);
                    }
                }
            }
        }

        private void toolStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dgvBarcode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBarcode.Rows[e.RowIndex];
                Id.barcode = row.Cells["barcode"].Value.ToString();
                if(dgvBarcode.SelectedRows.Count > 0)
                {
                    if (cmbProdSubType.Text == "Product master")
                    {
                        btnKitSetup.Enabled = true;
                    }
                    else
                    {
                        btnKitSetup.Enabled = false;
                    }
                    tsbEdit.Enabled = true;
                    tsbDeleteBarcode.Enabled = true;
                }
                else
                {
                    tsbEdit.Enabled = false;
                    tsbDeleteBarcode.Enabled = false;
                }
            }
        }

        private void dgvBarcode_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvBarcode.ClearSelection();
        }

        private void pGeneral_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && p.Visible == true)
            {
                p.Visible = false;
            }
            else if (e.Button == MouseButtons.Left && panel.Visible == true)
            {
                panel.Visible = false;
            }
        }

        private void txtPurchaseDiscount_Enter(object sender, EventArgs e)
        {
            p.Hide();
            panel.Hide();
        }

        private void cmbProdDimension_Enter(object sender, EventArgs e)
        {
            hide();
        }

        private void cbConcession_Enter(object sender, EventArgs e)
        {
            hide();
        }

        private void pProdCategory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && p.Visible == true)
            {
                p.Visible = false;
            }
            else if (e.Button == MouseButtons.Left && panel.Visible == true)
            {
                panel.Visible = false;
            }
        }

        private void lblGeneral_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && p.Visible == true)
            {
                p.Visible = false;
            }
            else if (e.Button == MouseButtons.Left && panel.Visible == true)
            {
                panel.Visible = false;
            }
        }


        private void lblProdDetails_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && p.Visible == true)
            {
                p.Visible = false;
            }
            else if (e.Button == MouseButtons.Left && panel.Visible == true)
            {
                panel.Visible = false;
            }
        }

        private void dgvBarcode_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbProdDimension_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controls.RemoveByKey("ProdDimensionError");
            cmbProdDimension.FlatStyle = FlatStyle.Standard;
        }

        private void cmbProdDimension_Leave(object sender, EventArgs e)
        {
            if (cmbProdDimension.Enabled == true)
            {
                if (cmbProdDimension.Text == "")
                {
                    pName = "ProdDimensionError";
                    oW = cmbProdDimension.Size.Width;
                    oH = cmbProdDimension.Size.Height;
                    x = cmbProdDimension.Location.X - 2;
                    y = cmbProdDimension.Location.Y - 2;
                    w = oW + 4;
                    h = oH + 4;
                    Controls.RemoveByKey("prodDimensionError");
                    redBorder();
                    cmbProdDimension.FlatStyle = FlatStyle.Flat;
                }
                else
                {
                    Controls.RemoveByKey("ProdDimensionError");
                    cmbProdDimension.FlatStyle = FlatStyle.Standard;
                }
            }
        }

        private void cmbProdDimension_MouseHover(object sender, EventArgs e)
        {
            if(cmbProdDimension.FlatStyle == FlatStyle.Flat)
            {
                if(cmbProdDimension.Text == "")
                {
                    toolTip1.Show("Product dimension is requried when product variant is Product Master", cmbProdDimension);
                }
                else
                {
                    toolTip1.Hide(cmbProdDimension);
                }
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnKitSetup_Click(object sender, EventArgs e)
        {
            frmKitComponents kit = new frmKitComponents();
            kit.ShowDialog();
        }

        private void pGeneral_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
