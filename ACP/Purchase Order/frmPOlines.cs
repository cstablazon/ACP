using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACP
{
    public partial class frmPOlines : Form
    {
        CatHierarchyClass cat = new CatHierarchyClass();
        acpEntities db = new acpEntities();
        purchaseOrderClass po = new purchaseOrderClass();
        public frmPOlines()
        {
            InitializeComponent();
        }

        string catRID;
        string subCatRID;
        public void newItems()
        {
            dgvNewItems.Columns.Clear();
            DataTable dt = po.fetchProductLine("sp_purchaseOrderOperations", "purchaseOrder", "fetchProductLine", Id.suppID, txtDepartment.Text);

            //DataTable catDT = po.fetchCategoryHierarchy("sp_purchaseOrderOperations", "categoryHierarchy", "code", null, txtDepartment.Text);


            //if (catDT.Rows.Count > 0)
            //{
                //catRID = catDT.Rows[0].Field<string>("cat_RID").ToString().Trim();
                //subCatRID = catDT.Rows[0].Field<string>("subcat_RID").ToString().Trim();
                //MessageBox.Show(Id.suppID);
                //MessageBox.Show(subCatRID);
                //MessageBox.Show(catRID);
                //DataTable dt = po.fetchProductLine("sp_purchaseOrderOperations", "purchaseOrder", "fetchProductLine", Id.suppID, catRID, subCatRID);

                //DataRow[] productDR = dt.Select("suppID = '" + Id.suppID + "' AND RID in ('" + catRID + "', '" + subCatRID + "')");
                //if (productDR.Length > 0)
                //{
                //    dgvNewItems.DataSource = productDR.CopyToDataTable();
                //}
                dgvNewItems.DataSource = dt;

                DataGridViewTextBoxColumn qtyCol = new DataGridViewTextBoxColumn();
                qtyCol.Name = "qtyCol";
                qtyCol.HeaderText = "Quantity";
                dgvNewItems.Columns.Add(qtyCol);
                dgvNewItems.Columns["qtyCol"].ReadOnly = false;

                //dgvNewItems.Columns["qtyCol"].DefaultCellStyle.Format = "N2";

            //}
            //else
            //{
            //    MessageBox.Show("2");
            //}
            //dgvNewItems.Columns.Clear();
            //dgvNewItems.DataSource = (from a in db.vwProducts
            //                          where a.suppID == Id.suppID && a.RID.Equals(Id.RID)
            //                          select new
            //                          {
            //                              a.SKU,
            //                              a.Barcode,
            //                              a.Product_description,
            //                          }).ToList();

            //dgvNewItems.Columns[0].HeaderText = "SKU";
            //dgvNewItems.Columns[1].HeaderText = "Barcode";
            //dgvNewItems.Columns[2].HeaderText = "Product description";
            //DataGridViewTextBoxColumn qtyCol = new DataGridViewTextBoxColumn();
            //qtyCol.Name = "qty";
            //qtyCol.HeaderText = "Quantity";
            //dgvNewItems.Columns.Insert(3, qtyCol);
            //dgvNewItems.Columns["qty"].ReadOnly = false;
        }

        public void fetchByCode()
        {
            //dgvNewItems.Columns.Clear();
            //var objCode = db.sp_catValidation("code", Convert.ToInt64(txtDepartment.Text)).SingleOrDefault();
            //Id.globalString = objCode.subcat_RID;
            //dgvNewItems.DataSource = (from a in db.vwProducts
            //                          where a.suppID.Equals(Id.suppID) && a.RID.Equals(Id.globalString)
            //                          select new 
            //                          {
            //                              a.SKU,
            //                              a.Barcode,
            //                              a.Product_description,
            //                          }).ToList();
            //dgvNewItems.Columns[0].HeaderText = "SKU";
            //dgvNewItems.Columns[1].HeaderText = "Barcode";
            //dgvNewItems.Columns[2].HeaderText = "Product description";
            //DataGridViewTextBoxColumn qtyCol = new DataGridViewTextBoxColumn();
            //qtyCol.Name = "qty";
            //qtyCol.HeaderText = "Quantity";
            //dgvNewItems.Columns.Insert(3, qtyCol);
            //dgvNewItems.Columns["qty"].ReadOnly = false;

        }

        private void frmPOlines_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvNewItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            dgvNewItems.Columns["qtyCol"].DefaultCellStyle.Format = "N2";
            //e.Control.KeyPress -= new KeyPressEventHandler(qty_KeyPress);
            //if(dgvNewItems.CurrentCell.ColumnIndex == 4)
            //{
            //    TextBox tb = e.Control as TextBox;
            //    if(tb != null)
            //    {
            //        tb.KeyPress += new KeyPressEventHandler(qty_KeyPress);;
            //    }
            //}
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        TreeView tv = new TreeView();
        Panel p = new Panel();
        bool hideCat = false;
        public void categoryForm()
        {
            if (hideCat == true)
            {
                p.Show();
            }
            else
            {
                p.Name = "pCategory";
                p.Size = new System.Drawing.Size(294, 254);
                p.Location = new Point(89, 34);
                Controls.Add(p);
                p.BringToFront();

                tv.AfterSelect += tv_AfterSelect;
                tv.DrawNode += tv_DrawNode;
                tv.NodeMouseDoubleClick += tv_NodeMouseDoubleClick;
                populateTreeView();
                tv.Name = "catHierarchy";
                tv.Dock = DockStyle.Fill;
                tv.DrawMode = TreeViewDrawMode.OwnerDrawText;
                p.Controls.Add(tv);
            }
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
                DataTable dataTable = cat.fetchDepartment();
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
                    if (rtype == "0" || string.IsNullOrEmpty(rtype))
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

         
        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Retrieves the currently selected TreeNode from the TreeView
            TreeNode selectedNode = tv.SelectedNode;
            // Retrieves the Tag property of the selected node and converts it to a string
            string selectedNodeID = selectedNode.Tag.ToString();
            // Sets a static property "rtypeID" in the "Id" class to the value of the selected node's ID
            Id.RID = selectedNodeID;
            // Checks if the selected node's text matches a specific condition

        }

        //string catRID;
        //string subCatRID;
        private void tv_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                DataTable dt = po.fetchRecords("sp_purchaseOrderOperations", "categoryHierarchy", "code");
                //DataRow[] dr = dt.Select("code = '" + lbl + "'");

                //catRID = dr[0]["cat_RID"].ToString().Trim();
                //subCatRID = dr[0]["subcat_RID"].ToString().Trim();
                //var category = (from a in db.categoryHierarchies where a.RID == Id.RID select a).SingleOrDefault();
                //txtCategory.Text = category.code.Trim();
                //var dept = db.sp_catValidation("rid", Id.RID);
                //txtCategory.Text = dept.subcat_code.Trim();
                //txtDepartment.Text = dept.FirstOrDefault().subcat_desc;
                //txtDepartment.Text = dr[0][].ToString().Trim();
                p.Hide();
                hideCat = true;
                //txtCategory.BorderStyle = BorderStyle.Fixed3D;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select under subcategory", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
            p.Hide();
            hideCat = true;
        }

        private void txtDepartment_Click(object sender, EventArgs e)
        {
            //categoryForm();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Regex check = new Regex(@"^[a-zA-Z\s]*$");
            if (string.IsNullOrEmpty(txtDepartment.Text))
            {
                MessageBox.Show("Fill up filter to load products", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                newItems();
            }
            //else if(check.IsMatch(txtDepartment.Text.Trim()))
            //{
            //    //MessageBox.Show("letters");
            //    newItems();
            //}
            //else
            //{
            //    //MessageBox.Show("mnumbers");
            //    fetchByCode();
            //}
            ////newItems();

        }

        string dgv;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(dgvNewItems.Rows.Count > 0)
            {
                bool isEmpty = false;
                for (int i = 0; dgvNewItems.Rows.Count > i; i++ )
                {
                    if(string.IsNullOrEmpty(dgvNewItems.Rows[i].Cells["qtyCol"].Value as string))
                    {
                        isEmpty = true;
                        break;
                    }
                    else
                    {
                        isEmpty = false;
                    }
                }
                if(isEmpty == true)
                {
                    MessageBox.Show("Quantity is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for(int i = 0; dgvNewItems.Rows.Count > i; i++ )
                    {
                        string barcode = dgvNewItems.Rows[i].Cells["barcode"].Value.ToString();
                        decimal qty = Convert.ToDecimal(dgvNewItems.Rows[i].Cells["qtyCol"].Value);
                        po.createUpdatePOlines("Create", Id.orderNo, barcode, qty, Id.userID);
                    }
                    MessageBox.Show("Successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Hide();

                }
            }

            
            //if(dgv.Equals("newItems"))
            //{
            //    int i = 1;
            //    foreach(DataGridViewRow row in dgvNewItems.Rows)
            //    {
            //        i++;
            //        if(row.Cells["qty"].Value == null)
            //        {

            //        }
            //        else
            //        {
            //            frmAddOrder addOrder = new frmAddOrder();
            //            addOrder.dgvLines.Rows.Add(i, row.Cells["Barcode"].Value.ToString(), row.Cells["qty"].Value.ToString(), "", "", "", "", "");
            //        }
            //    }
            //    this.Hide();
            //}
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            dgv = "newItems";
        }

        private void dgvExistItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void dgvNewItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 3 && e.RowIndex != dgvNewItems.NewRowIndex)
            {
                if(dgvNewItems.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    double qty = double.Parse(e.Value.ToString());
                    e.Value = qty.ToString("N2");
                }
            }
            //if (e.ColumnIndex == 3)
            //{
            //    e.CellStyle.Format = "N2";
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //private void qty_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
    }
}
