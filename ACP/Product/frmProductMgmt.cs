using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace ACP
{
    public partial class frmProductMgmt : Form
    {
        productCreation pc = new productCreation();
        acpEntities db = new acpEntities();
        public frmProductMgmt()
        {
            InitializeComponent();
           
        }

        public void productList()
        {
            DataTable dt = pc.fetchRecords("sp_Product", "Product", "fetchProductList", null);
            dgvProduct.DataSource = dt;

            dgvProduct.Columns["prodTypeID"].Visible = false;
            dgvProduct.Columns["prodSubTypeID"].Visible = false;
            dgvProduct.Columns["RID"].Visible = false;
            dgvProduct.Columns["brandID"].Visible = false;
            dgvProduct.Columns["bDesc"].Visible = false;
            //dgvProduct.Columns["SKU"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns["itemDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dgvProduct.Columns["suppID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dgvProduct.Columns["prodTypeDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns["prodSubTypeDesc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns["pDimension"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns["desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dgvProduct.Columns["isConcession"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns["transDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvProduct.Columns["itemDesc"].HeaderText = "Item description";
            dgvProduct.Columns["suppID"].HeaderText = "Supplier ID";
            dgvProduct.Columns["name"].HeaderText = "Name";
            dgvProduct.Columns["prodTypeDesc"].HeaderText = "Product type";
            dgvProduct.Columns["prodSubTypeDesc"].HeaderText = "Product type";
            dgvProduct.Columns["pDimension"].HeaderText = "Product dimension group";
            dgvProduct.Columns["desc"].HeaderText = "Sub category";
            dgvProduct.Columns["transDate"].HeaderText = "Date created";

            //dgvProduct.DataSource = (from a in db.vwProductLists 
            //                         select new 
            //                         {
            //                         a.SKU,
            //                         a.itemDesc,
            //                         a.prodTypeDesc,
            //                         a.pDimension,
            //                         a.desc,
            //                         a.isConcession,
            //                         a.transDate
            //                         }).ToList(); 
            //dgvProduct.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvProduct.Columns[1].HeaderText = "Item description";
            //dgvProduct.Columns[2].HeaderText = "Product type";
            //dgvProduct.Columns[3].HeaderText = "Product dimension group";
            //dgvProduct.Columns[4].HeaderText = "Sub category";
            //dgvProduct.Columns[5].HeaderText = "isConcession";
            //dgvProduct.Columns[6].HeaderText = "Date created";
        }

        //private void dgvlines()
        //{
        //    if(dgvLines.SelectedRows.Count > 0)
        //    {
        //        pLines.Visible = true;
        //        dgvLines.Visible = true;
        //    }
        //    else
        //    {
        //        int h, w;
        //        w = dgvProduct.Size.Width;
        //        h = 558;
        //        dgvProduct.Size = new System.Drawing.Size(w, h);
        //    }
        //}

        private void frmProductMgmt_Load(object sender, EventArgs e)
        {
            productList();
        }

        bool show;

        private void btnNewProd_Click(object sender, EventArgs e)
        {
            Id.button = "Create";
            //int autoIncSKU = pc.autoInc("SKU", "product");
            //Id.SKU = string.Format("{0:0000000}", autoIncSKU);
            //pc.createUpdateProduct("Product", "Create", Id.SKU, Id.userID, 0, 0, null, null, null, null, false, Id.userID);
            pc.createUpdateProduct("Create", null, null, 0, 0, 0, null, 0, null, null, false, Id.userID);
            Id.SKU = string.Format("{0:0000000}", Convert.ToInt32(Id.autoIncSKU));
            frmModifyProd modify = new frmModifyProd();
            //frmNewProduct modify = new frmNewProduct();
            modify.btnCreate.Text = "Create";
            modify.btnClose.Text = "Cancel";
            DialogResult res = modify.ShowDialog();
            if(res == DialogResult.OK)
            {
                productList();
            }
        //Product Info
        //Id.desc2 = "@SKU";
        //Id.desc3 = "@suppID";
        //Id.desc4 = "@brandID";
        //Id.desc5 = "@itemDesc";
        //Id.desc6 = "@lineDisc";
        //Id.desc7 = "@isConcession";
        //Id.desc8 = "@userID";

        ////barcode Info
        //Id.desc9 = "@barcode";
        //Id.desc12 = "@RID";
        //Id.desc15 = "@retailPrice";
        //Id.desc16 = "@costPrice";
        //Id.desc17 = "@posDesc";
        //Id.desc18 = "@salesTax";
        //Id.desc19 = "@purchaseTax";
        //Id.desc20 = "@bmrx";
        //Id.desc21 = "@isActive";
        //Id.desc26 = "@prodTypeID";
        //Id.desc27 = "@prodSubTypeID";
        //Id.desc28 = "@CPuomID";
        //Id.desc29 = "@RPuomID";
        //DialogResult res = modify.ShowDialog();
        //   string suppID = modify.cmbSuppID.GetItemText(modify.cmbSuppID.SelectedValue);
        //   string sku = modify.txtSKU.Text;
        //   string lineDesc = modify.cmbLine.Text;
        //   string prod_name = modify.txtProdName.Text;
        //   string brandID = modify.cmbBrand.GetItemText(modify.cmbBrand.SelectedValue);
        //if (res == DialogResult.OK)
        //{
        //    //pc.modifyProduct("CRUD","PRODUCT",sku,suppID,brandID,prod_name,lineDesc,Id.isConcession,"1","","","",
        //    //    "","","","","","","","","","","","","","",0,0,0,0);
        //    //productList();
        //}
        }

        private void btnOtherPrice_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count > 0)
            {
                frmOtherPrice op = new frmOtherPrice();
                op.lblSKU.Text = Id.SKU;
                op.lblBarcode.Text = Id.globalString;
                op.lblProdName.Text = Id.globalString2;
                op.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select product", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnCatHierarchy_Click(object sender, EventArgs e)
        {
            frmCatHierarchy ch = new frmCatHierarchy();
            ch.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            ch.WindowState = System.Windows.Forms.FormWindowState.Normal;
            ch.ShowDialog();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            productList();
            int h, w;
            w = dgvProduct.Size.Width;
            h = 558;
            dgvProduct.Size = new System.Drawing.Size(w, h);
        }

        private void dgvProduct_Paint(object sender, PaintEventArgs e)
        {
            foreach(DataGridViewColumn col in dgvProduct.Columns)
            {
                col.HeaderText = col.HeaderText.Replace("_", " ");
            }
        }

        private void dgvProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProduct.ClearSelection();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvProduct.Rows[e.RowIndex];

                //Id.productID = row.Cells["Barcode"].Value.ToString();
                Id.SKU = row.Cells["SKU"].Value.ToString();
                Id.globalString2 = row.Cells["itemDesc"].Value.ToString();
                if (dgvProduct.SelectedRows.Count > 0)
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

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Id.button = "Update";
            if(dgvProduct.SelectedRows.Count > 0)
            {
                frmModifyProd modyProd = new frmModifyProd();
                modyProd.btnCreate.Text = "Update";
                modyProd.btnClose.Text = "Close";
                modyProd.lblProdDetails.Enabled = true;
                int rowIndex = dgvProduct.SelectedRows[0].Index;

                modyProd.txtCategory.Text = dgvProduct.Rows[rowIndex].Cells["desc"].Value.ToString();
                Id.RIDL = Convert.ToInt64(dgvProduct.Rows[rowIndex].Cells["RID"].Value);
                DataTable dt = pc.fetchDept("sp_catValidation", "rid", Id.RIDL);
                
                foreach(DataRow dr in dt.Rows)
                {
                    modyProd.txtDepartment.Text = dr["dept_desc"].ToString();
                }
                modyProd.cmbBrand.Text = dgvProduct.Rows[rowIndex].Cells["bDesc"].Value.ToString();
                modyProd.cmbProdType.Text = dgvProduct.Rows[rowIndex].Cells["prodTypeDesc"].Value.ToString();
                modyProd.cmbProdSubType.Text = dgvProduct.Rows[rowIndex].Cells["prodSubTypeDesc"].Value.ToString();
                modyProd.cmbProdDimension.Text = dgvProduct.Rows[rowIndex].Cells["pDimension"].Value.ToString();
                modyProd.txtSKU.Text = dgvProduct.Rows[rowIndex].Cells["SKU"].Value.ToString();
                modyProd.txtProdName.Text = dgvProduct.Rows[rowIndex].Cells["itemDesc"].Value.ToString();
                modyProd.txtSupplier.Text = dgvProduct.Rows[rowIndex].Cells["name"].Value.ToString();
                Id.suppID = dgvProduct.Rows[rowIndex].Cells["suppID"].Value.ToString();
                modyProd.cbConcession.Checked = Convert.ToBoolean(dgvProduct.Rows[rowIndex].Cells["isConcession"].Value);

                DialogResult res = modyProd.ShowDialog();
                if(res == DialogResult.OK)
                {
                    productList();
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
                //var product = db.vwProducts.Where(a => a.SKU.Equals(Id.productID)).FirstOrDefault();
                //bool isConcession = Convert.ToBoolean(product.isConcession);
                //var chTree = db.sp_catValidation("rid", product.RID).SingleOrDefault();
                //modyProd.txtSKU.Text = product.SKU;
                //modyProd.txtCategory.Text = product.RID.ToString();
                //modyProd.txtDepartment.Text = chTree.dept_desc;
                //modyProd.txtSupplier.Text = product.suppID;
                //modyProd.cmbProdType.Text = product.Product_type;
                //modyProd.cmbProdSubType.Text = product.prodSubTypeDesc;
                //modyProd.cmbProdDimension.Text = product.pDimension;
                //modyProd.cbConcession.Checked = isConcession;
                ////modyProd.cmbLine.Text = product.lineDisc;
                //modyProd.txtProdName.Text = product.itemDesc;
                //modyProd.cmbBrand.Text = product.bDesc;

                //var item = db.vwProducts.Where(a => a.SKU.Equals(Id.productID)).ToList();
                //foreach(vwProduct barcode in item)
                //{
                //    modyProd.dgvBarcode.Rows.Add(barcode.Barcode, barcode.Product_description, barcode.CPuomID, barcode.PO_Unit, barcode.Cost_price, barcode.factor, barcode.RPuomID, barcode.Retail_Unit, barcode.Retail_price, barcode.inventoryCost, barcode.discountID, barcode.dDesc, barcode.purchaseTax, barcode.salesTax, barcode.DID, barcode.BMRX, barcode.PID, barcode.Privilege_setup, barcode.itemModelID, barcode.itemModelDesc, barcode.isDiscountable, barcode.isActive, barcode.chargeID, barcode.chargeDesc, barcode.kitCode, barcode.LID, barcode.Location, barcode.siteID, barcode.whDesc, barcode.Location);
                //}
                //modyProd.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Delete product and its barcode?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(res == DialogResult.Yes)
            {
                pc.deleteProduct("sp_Product", "Product", "Delete", Id.SKU);
                productList();
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnKitSetup_Click(object sender, EventArgs e)
        {
            frmKitComponents kit = new frmKitComponents();

            kit.ShowDialog();
        }
    }
}
