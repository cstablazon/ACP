using System;
using System.Windows.Forms;
using ACP;

namespace ACP
{
    public partial class frMain : Form
    {
        public frMain()
        {
            InitializeComponent();
        }

        private void frMain_Load(object sender, EventArgs e)
        {
            pictureBox2.Focus();
        }

        private void tvModule_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = tvModule.SelectedNode;

            switch (selectedNode.Name)
            {

                case "ProductMgt":
                    //2nd commit

                    

                    frmProductMgmt prodmgmt = new frmProductMgmt { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(prodmgmt);
                    prodmgmt.BringToFront();
                    prodmgmt.Show();
                    
                    break;

                case "allPO":

                    frmPurchaseOrder po = new frmPurchaseOrder { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(po);
                    po.BringToFront();
                    po.Show();

                    break;

                case "catHierarchy":

                    frmCatHierarchy prodierar = new frmCatHierarchy { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(prodierar);
                    prodierar.BringToFront();
                    prodierar.Show();
                    break;


                case "supp":
                    frmSupplierMgt sup = new frmSupplierMgt { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(sup);
                    sup.BringToFront();
                    sup.Show();
                    break;

                case "storage_dimension_group":
                    frmStorageGroup sdg = new frmStorageGroup { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(sdg);
                    
                    Id.desc2 = "@sdGroupID";
                    Id.desc3 = "@sdDesc";
                    sdg.BringToFront();
                    sdg.Show();
                    break;

                case "item_model_group":
                    frmItemModelGroup img = new frmItemModelGroup { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(img);
                    
                    Id.desc2 = "@itemModelID";
                    Id.desc3 = "@sdGroupID";
                    Id.desc4 = "itemModelDesc";
                    img.BringToFront();
                    img.Show();
                    break;

                case "tracking_group":
                    frmTrackingGroup tg = new frmTrackingGroup { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(tg);
                   
                    Id.desc2 = "@tdGroupID";
                    Id.desc3 = "@tdGroupDesc";
                    tg.BringToFront();
                    tg.Show();
                    break;

                case "uom":
                    frmUOM uom = new frmUOM { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(uom);

                    Id.desc2 = "@uomID";
                    Id.desc3 = "@uomDesc";
                    uom.BringToFront();
                    uom.Show();
                    break;

                case "prodType":
                    frmProdType pt = new frmProdType { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(pt);
                    
                    Id.desc2 = "@prodTypeID";
                    Id.desc3 = "@prodTypeDesc";
                    pt.BringToFront();
                    pt.Show();
                    break;

                case "prodSubType":
                    frmProdSubType pst = new frmProdSubType { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(pst);
                    
                    Id.desc2 = "@prodSubTypeID";
                    Id.desc3 = "@prodSubTypeDesc";
                    pst.BringToFront();
                    pst.Show();
                    break;

                case "discount":
                    frmDiscount disc = new frmDiscount { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(disc);
                    Id.desc2 = "@discountID";
                    Id.desc3 = "@dDesc";
                    Id.desc4 = "@percentage";
                    disc.BringToFront();
                    disc.Show();
                    break;

                case "item_tax_group":
                    frmItemTax itemTax = new frmItemTax { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(itemTax);
                    Id.desc2 = "@Id";
                    Id.desc3 = "@itemTaxID";
                    Id.desc4 = "@itemTaxDesc";
                    Id.desc5 = "@percent";
                    itemTax.BringToFront();
                    itemTax.Show();
                    break;

                    case "inventLocation":
                    frmInventLocation it = new frmInventLocation { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(it);
                    Id.desc2 = "@inventLocID";
                    Id.desc3 = "@siteID";
                    Id.desc4 = "@inventLocDesc";
                    Id.desc5 = "@location";
                    it.BringToFront();
                    it.Show();
                    break;

                    case "site":
                    frmSite site = new frmSite { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(site);
                    Id.desc2 = "@siteID";
                    Id.desc3 = "@addressID";
                    Id.desc4 = "@siteDesc";
                    site.BringToFront();
                    site.Show();
                    break;

                    case "paymentTerm":
                    frmPaymentTerm pay = new frmPaymentTerm { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(pay);
                    pay.BringToFront();
                    pay.Show();
                    break;

                case "contactType":
                    frmContactType ct = new frmContactType { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(ct);
                    ct.BringToFront();
                    ct.Show();
                    break;

                case "itemSalesTaxGroup":
                    frmItemSalesTaxGroup tax = new frmItemSalesTaxGroup { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(tax);
                    tax.Dock = DockStyle.Fill;
                    tax.BringToFront();
                    tax.Show();
                    break;

                case "brand":
                    frmBrand brand = new frmBrand { TopLevel = false };
                    pBody.Controls.Clear();
                    pBody.Controls.Add(brand);
                    brand.Dock = DockStyle.Fill;
                    brand.BringToFront();
                    brand.Show();
                    break;

                default:
                    break;
            }
        }

      
        private void frMain_Resize(object sender, EventArgs e)
        {
            int intX = Screen.PrimaryScreen.Bounds.Width;
            int intY = Screen.PrimaryScreen.Bounds.Height;
            this.Width = intX;
            this.Height = intY;
            this.Top = 0;
            this.Left = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
