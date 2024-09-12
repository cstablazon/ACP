﻿using System;
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
        public frmPOlines()
        {
            InitializeComponent();
        }

        public void newItems()
        {
            dgvNewItems.Columns.Clear();
            dgvNewItems.DataSource = (from a in db.vwProducts
                                      where a.suppID == Id.suppID && a.RID.Equals(Id.RID)
                                      select new
                                      {
                                          a.SKU,
                                          a.Barcode,
                                          a.Product_description,
                                      }).ToList();

            dgvNewItems.Columns[0].HeaderText = "SKU";
            dgvNewItems.Columns[1].HeaderText = "Barcode";
            dgvNewItems.Columns[2].HeaderText = "Product description";
            DataGridViewTextBoxColumn qtyCol = new DataGridViewTextBoxColumn();
            qtyCol.Name = "qty";
            qtyCol.HeaderText = "Quantity";
            dgvNewItems.Columns.Insert(3, qtyCol);
            dgvNewItems.Columns["qty"].ReadOnly = false;
        }

        public void fetchByCode()
        {
            dgvNewItems.Columns.Clear();
            var objCode = db.sp_catValidation("code", Convert.ToInt64(txtDepartment.Text)).SingleOrDefault();
            Id.globalString = objCode.subcat_RID;
            dgvNewItems.DataSource = (from a in db.vwProducts
                                      where a.suppID.Equals(Id.suppID) && a.RID.Equals(Id.globalString)
                                      select new 
                                      {
                                          a.SKU,
                                          a.Barcode,
                                          a.Product_description,
                                      }).ToList();
            dgvNewItems.Columns[0].HeaderText = "SKU";
            dgvNewItems.Columns[1].HeaderText = "Barcode";
            dgvNewItems.Columns[2].HeaderText = "Product description";
            DataGridViewTextBoxColumn qtyCol = new DataGridViewTextBoxColumn();
            qtyCol.Name = "qty";
            qtyCol.HeaderText = "Quantity";
            dgvNewItems.Columns.Insert(3, qtyCol);
            dgvNewItems.Columns["qty"].ReadOnly = false;

        }

        private void frmPOlines_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvNewItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
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

        private void tv_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                var category = (from a in db.categoryHierarchies where a.RID == Id.RID select a).SingleOrDefault();
                //txtCategory.Text = category.code.Trim();
                //var dept = db.sp_catValidation("rid", Id.RID);
                //txtCategory.Text = dept.subcat_code.Trim();
                //txtDepartment.Text = dept.FirstOrDefault().subcat_desc;
                txtDepartment.Text = category.desc.Trim();
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
            categoryForm();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Regex check = new Regex(@"^[a-zA-Z\s]*$");
            if (string.IsNullOrEmpty(txtDepartment.Text))
            {
                MessageBox.Show("Fill up filter to load products", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(check.IsMatch(txtDepartment.Text.Trim()))
            {
                //MessageBox.Show("letters");
                newItems();
            }
            else
            {
                //MessageBox.Show("mnumbers");
                fetchByCode();
            }
            //newItems();

        }

        string dgv;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Hide();
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

        //private void qty_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
    }
}
