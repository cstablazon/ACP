using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Data.Entity;
using System.Data.Linq;

namespace ACP
{
    
    public partial class frmAddOrder : Form
    {
        bool dropdownBtn;
        bool dropdownBtn2;
        acpEntities db = new acpEntities();
        barcodeClass code = new barcodeClass();
        purchaseOrderClass po = new purchaseOrderClass();
        public frmAddOrder()
        {
            InitializeComponent();
        }

        public void autocomplete()
        {
            //DataTable dt = po.fetch_supplier();
            //AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            //foreach (DataRow rows in dt.Rows)
            //{
            //    coll.Add(rows["suppID"].ToString());
            //}
        }

        public void fetch_pool() 
        {
            DataSet ds = po.cbRecords("pool", "fetchPool", "PoolID");
            cmbPool.DataSource = ds.Tables["PoolID"];
            cmbPool.DisplayMember = "poolID";
            cmbPool.ValueMember = "poolID";
            cmbPool.Text = "";
            //DataSet ds = po.fetch_pool();
            //cbPool.DataSource = ds.Tables["poolID"];
            //cbPool.DisplayMember = "poolID";
            //cbPool.ValueMember = "poolID".Trim(); ;
            //cbPool.Text = Id.payId;
        }

        string dropdown;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dropdown == "Header")
            {
                if (dropdownBtn)
                {
                     pHeader.Height += 20;
                    flowLayoutPanel1.Height += 15;
                    if (pHeader.Height == pHeader.MaximumSize.Height)
                    {
                        lblHeader.Image = Properties.Resources.arrowDown10px;
                        dropdownBtn = false;
                        timer1.Stop();
                    }
                }
                else
                {
                    pHeader.Height -= 20;
                    flowLayoutPanel1.Height -= 15;
                    if (pHeader.Height == pHeader.MinimumSize.Height)
                    {
                        lblHeader.Image = Properties.Resources.arrowRight10px;
                        dropdownBtn = true;
                        timer1.Stop();
                    }
                }

            }
            else if (dropdown == "Lines")
            {

                if (dropdownBtn2)
                {
                    pLines.Height -= 20;
                    flowLayoutPanel1.Height -= 15;
                    if (pLines.Height == pLines.MinimumSize.Height)
                    {
                        lblLines.Image = Properties.Resources.arrowRight10px;
                        dropdownBtn2 = false;
                        timer1.Stop();
                    }
                }
                else
                {
                    pLines.Height += 20;
                    flowLayoutPanel1.Height += 15;
                    if (pLines.Height == pLines.MaximumSize.Height)
                    {
                        lblLines.Image = Properties.Resources.arrowDown10px;
                        dropdownBtn2 = true;
                        timer1.Stop();
                    }
                    
                }
            }
            else if(dropdown == "lineDetails")
            {
                if (dropdownBtn2)
                {
                    pLines.Height -= 20;
                    flowLayoutPanel1.Height -= 15;
                    if (pLines.Height == pLines.MinimumSize.Height)
                    {
                        lblLines.Image = Properties.Resources.arrowRight10px;
                        dropdownBtn2 = false;
                        timer1.Stop();
                    }
                }
                else
                {
                    pLines.Height += 20;
                    flowLayoutPanel1.Height += 15;
                    if (pLines.Height == pLines.MaximumSize.Height)
                    {
                        lblLines.Image = Properties.Resources.arrowDown10px;
                        dropdownBtn2 = true;
                        timer1.Stop();
                    }

                }
            }
               
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            dropdown = "Header";
            timer1.Start();
        }

        private void lblLines_Click(object sender, EventArgs e)
        {
            dropdown = "Lines";
            timer1.Start();
        }

        //public void supplier()
        //{
        //    //var supp = (from a in db.suppliers where a.suppID != "" && a.suppID != null select a.suppID).ToArray();
        //    //cmbSuppID.AutoCompleteCustomSource.AddRange(supp);
        //    //cmbSuppID.DataSource = (from a in db.suppliers select a).ToList();
        //    //cmbSuppID.ValueMember = "suppID";
        //    //cmbSuppID.DisplayMember = "suppID";
        //    //cmbSuppID.Text = "";
        //}

        public void modeOfDelivery()
        {
            DataSet ds = po.cbRecords("modeOfDelivery", "fetchModeOfDelivery", "Mode of delivery");
            cmbMOD.DataSource = ds.Tables["Mode of delivery"];
            cmbMOD.DisplayMember = "Mode of delivery";
            cmbMOD.ValueMember = "modID";
            cmbMOD.Text = "";
        }

        public void deliveryAdd()
        {
            DataSet ds = po.cbRecords("deliveryAddress", "fetchDeliveryAddress", "Name");
            cmbDeliveryAdd.DataSource = ds.Tables["Name"];
            cmbDeliveryAdd.DisplayMember = "Name";
            cmbDeliveryAdd.ValueMember = "delAddressID";
            cmbDeliveryAdd.Text = "";
        }

        private void fetchDiscount()
        {

        }

        //public void editableDGV()
        //{
        //    //foreach(DataGridViewColumn dc in dgvLines.Columns)
        //    //{
        //    //    if(dc.Index.Equals(1) || dc.Index.Equals(2))
        //    //    {
        //    //        dc.ReadOnly = false;
                    
        //    //    }
        //    //}
        //    dgvLines.Columns[1].ReadOnly = false;
        //    dgvLines.Columns[2].ReadOnly = false;
        //}

        //public void readOnly()
        //{
        //    dgvLines.Columns[0].ReadOnly = true;
        //    dgvLines.Columns[4].ReadOnly = true;
        //    dgvLines.Columns[5].ReadOnly = true;
        //    dgvLines.Columns[6].ReadOnly = true;
        //    dgvLines.Columns[7].ReadOnly = true;
        //    //dgvLines.Columns[8].ReadOnly = true;
        //}

        //private void orderNo()
        //{
        //    if(Id.button.Equals("Create"))
        //    {
        //        txtOrderNo.Text = code.GenerateEan5();
        //        cmbPool.Text = "";
        //        cmbMOD.Text = "";
        //        cmbDeliveryAdd.Text = "";
        //    }
        //}

        private void fetchPOlines()
        {
            DataTable dt = po.fetchPOline("sp_purchaseOrderOperations", "POlines", "fetchPOline", txtOrderNo.Text);

            dgvLines.DataSource = dt;
            dgvLines.Columns["lineID"].Visible = false;
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
                    if (t.Text.Length < 20)
                        t.Text = (decimal.Parse(t.Text.Insert(t.SelectionStart, e.KeyChar.ToString())
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
        }

        private void frmAddOrder_Load(object sender, EventArgs e)
        {
            deliveryAdd();
            modeOfDelivery();
            fetch_pool();
            fetchPOlines();

            txtTotalDiscount.Text = 0.ToString("N2");
            txtPercentage.Text = 0.ToString("N2");
            txtPesoDiscount.Text = 0.ToString("N2");
            txtPriceUnit.Text = 0.ToString("N2");
            txtDiscountDesc.Text = 0.ToString("N2");
            txtPurchaseDiscount.Text = 0.ToString("N2");
            //orderNo();
            //readOnly();
            //editableDGV();
            //supplier();
            
            autocomplete();
        //   fetch_poolID();
            if(Id.button == "Create")
            {
                lblLines.Enabled = false;
            }
            else
            {
                lblLines.Enabled = true;
            }
        }

        private void fetch_poolID() {

            //DataTable dt = po.fetch_poolID(cmbPool.Text);
            //if (dt.Rows.Count > 0)
            //{
            //    foreach (DataRow rows in dt.Rows)
            //    {
            //        txtPoolDesc.Text = rows["poolDesc"].ToString();
            //    }
            //}
        }

        private void cbPool_SelectedIndexChanged(object sender, EventArgs e)
        {


            fetch_poolID();
            //MessageBox.Show(cbPool.Text);
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            DateTime currenDate = DateTime.Now;

            DateTime futureDate = currenDate.AddDays(8);

            dtpDelivery.Text = futureDate.ToShortDateString();
            //MessageBox.Show("Current Date is: " + currenDate.ToShortDateString() + "Future Date is: " + 
              //  futureDate.ToShortDateString());
        }

        private void dtpEntry_ValueChanged(object sender, EventArgs e)
        {
            int days = Convert.ToInt32(Id.desc10);
        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (cmbMOD.Text)
            //{
            //    case "Air":
            //        Id.desc10 = "7";
            //        break;
            //    case "Land":
            //        Id.desc10 = "14";
            //        break;
            //    case "Sea":
            //        Id.desc10 = "14";
            //        break;
            //}

            //int days = Convert.ToInt32(Id.desc10);

        }

        private void cmbSuppID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Id.suppID = cmbSuppID.GetItemText(cmbSuppID.SelectedValue);
            //var supplier = (from a in db.suppliers 
            //                join b in db.paymentTerms on a.payID equals b.payID 
            //                where a.suppID == Id.suppID 
            //                select new
            //                {
            //                   a.name,
            //                   b.payDesc

            //                }).SingleOrDefault();
            //txtName.Text = supplier.name;
            //txtPayTerm.Text = supplier.payDesc;

            //this.barcode.DataSource = (from a in db.vwProducts where a.suppID == cmbSuppID.Text select a).ToList();
            //this.barcode.ValueMember = "barcode";
            //this.barcode.DisplayMember = "barcode";
            //txtName.Text = supplier.name;
            //txtPrincipal.Text = principal.name;
            //txtPayTerm.Text = supplier.payDesc;


        }

        private void cmbPool_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
        string address;
        private void cmbDeliveryAdd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmbDeliveryAdd.SelectedValue);
            DataTable dt = po.fetchRecords("sp_purchaseOrderOperations", "deliveryAddress", "fetchDeliveryAddress");

            DataRow[] dr = dt.Select("delAddressID = "+ id +"");
            rtxtAddress.Text = dr[0]["fullAddress"].ToString();
        }

        public void createUpdate()
        {
            if (Id.button.Equals("Create"))
            {
                if (string.IsNullOrEmpty(txtOrderNo.Text) || string.IsNullOrEmpty(cmbPOtype.Text) || string.IsNullOrEmpty(txtSuppID.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPayTerm.Text) || string.IsNullOrEmpty(cmbPool.Text) || string.IsNullOrEmpty(cmbMOD.Text) || string.IsNullOrEmpty(cmbDeliveryAdd.Text) || string.IsNullOrEmpty(rtxtAddress.Text))
                {

                    MessageBox.Show("Please fill up all necessary information");
                }
                else
                {
                    int modID = Convert.ToInt32(cmbMOD.SelectedValue);
                    int deliveryAddressID = Convert.ToInt32(cmbDeliveryAdd.SelectedValue);
                    int discountID = Convert.ToInt32(cmbCashDiscount.SelectedValue);
                    decimal seasonalDiscount = Convert.ToDecimal(txtTotalDiscount.Text);
                    po.createUpdatePurchaseOrder("Update", txtOrderNo.Text, cmbPOtype.Text, modID, cmbPool.Text, seasonalDiscount, deliveryAddressID, dtpDelivery.Value, dtpCancel.Value, "Draft", rtxtRemarks.Text, Id.userID);

                    if(cmbDiscountType.Text == "Peso discount")
                    {
                        if(txtPesoDiscount.Text != "0.00" && txtPriceUnit.Text != "0.00")
                        {
                            decimal peso = Convert.ToDecimal(txtPesoDiscount.Text);
                            decimal priceUnit = Convert.ToDecimal(txtPriceUnit.Text);
                            po.createUpdatePesoDiscount("Create", null, txtOrderNo.Text, peso, priceUnit, Id.userID);
                        }
                    }

                    lblLines.Enabled = true;
                    //purchase_order po = new purchase_order();
                    //po.orderNo = txtOrderNo.Text;

                    //po.modID = cmbMOD.GetItemText(cmbMOD.SelectedValue);
                    //po.poType = cmbPOtype.Text;
                    //po.poolID = cmbPool.GetItemText(cmbPool.SelectedValue);
                    //po.delAddressID = cmbDeliveryAdd.GetItemText(cmbDeliveryAdd.SelectedValue);
                    //po.discountID = null;
                    //po.deliveryDate = dtpDelivery.Value;
                    //po.cancelDate = dtpCancel.Value;
                    //po.salesTax = null;
                    //po.status = "For approval";
                    //po.remarks = rtxtRemarks.Text;
                    //po.transDate = DateTime.Now;
                    //po.userID = null;

                    //db.purchase_order.Add(po);
                    //db.SaveChanges();

                    //for (int i = 0; dgvLines.Rows.Count > i; i++)
                    //{
                    //    PO_Line poLine = new PO_Line();

                    //    poLine.orderNo = txtOrderNo.Text;
                    //    poLine.barcode = dgvLines.Rows[i].Cells["barcode"].Value.ToString();
                    //    poLine.qty = Convert.ToDecimal(dgvLines.Rows[i].Cells["qty"].Value);
                    //    poLine.transDate = DateTime.Now;
                    //    poLine.userID = null;

                    //    db.PO_Line.Add(poLine);
                    //    db.SaveChanges();
                    //}
                }
            }
            else if(Id.button.Equals("Update"))
            {
                if (string.IsNullOrEmpty(txtOrderNo.Text) || string.IsNullOrEmpty(cmbPOtype.Text) || string.IsNullOrEmpty(txtSuppID.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAgent.Text) || string.IsNullOrEmpty(txtPayTerm.Text) || string.IsNullOrEmpty(cmbCashDiscount.Text) || string.IsNullOrEmpty(cmbPool.Text) || string.IsNullOrEmpty(cmbMOD.Text) || string.IsNullOrEmpty(cmbDeliveryAdd.Text) || string.IsNullOrEmpty(rtxtAddress.Text) || string.IsNullOrEmpty(cmbDepartment.Text) || string.IsNullOrEmpty(cmbEncodedBy.Text) || string.IsNullOrEmpty(cmbOrderBy.Text) || string.IsNullOrEmpty(cmbApprovedBy.Text) || string.IsNullOrEmpty(cmbCheckedBy.Text))
                {
                    MessageBox.Show("Please fill up all necessary information");
                }
                else
                {
                    
                    //int i = 0;

                    //Check if lines are existing in dgv
                    //foreach(PO_Line lines in updateLines)
                    //{

                        //for (int i = 0; dgvLines.Rows.Count > i; i++)
                        //{
                            //MessageBox.Show(i.ToString());
                            //if (lines.barcode != dgvLines.Rows[i].Cells["barcode"].Value as String)
                            //{
                            //    exist = false;
                            //    MessageBox.Show(i.ToString());
                            //    MessageBox.Show(lines.barcode + " " + dgvLines.Rows[i].Cells["barcode"].Value.ToString() + " " + dgvLines.Rows.Count + " " + i);
                            //    i++;
                            //    //var objDel = db.PO_Line.Where(a => a.barcode.Equals(lines.barcode)).FirstOrDefault();

                            //    //db.PO_Line.Remove(objDel);
                            //    //db.SaveChanges();
                            //}
                            //else
                            //{
                            //    i++;
                            //    MessageBox.Show(lines.barcode + " " + dgvLines.Rows[i].Cells["barcode"].Value.ToString() + " " + dgvLines.Rows.Count + " " + i);
                            //    exist = true;
                            //}

                            //if(exist.Equals(true))
                            //{
                            //    var objUpdate = db.PO_Line.Where(a => a.barcode.Equals(lines.barcode)).SingleOrDefault();
                            //    decimal qty = Convert.ToDecimal(dgvLines.Rows[i].Cells["qty"].Value);
                            //    objUpdate.qty = qty;

                            //    db.SaveChanges();
                            //}
                            //else
                            //{
                            //    var objDelete = db.PO_Line.Where(a => a.barcode.Equals(lines.barcode)).SingleOrDefault();

                            //    db.PO_Line.Remove(objDelete);
                            //    db.SaveChanges();
                            //}
                            //else if (dgvLines.Rows[i].Cells["barcode"].Value as String != lines.barcode)
                            //{
                            //    PO_Line line = new PO_Line();
                            //    decimal qty = Convert.ToDecimal(dgvLines.Rows[i].Cells["qty"].Value);
                            //    line.barcode = dgvLines.Rows[i].Cells["barcode"].Value.ToString();
                            //    line.qty = qty;
                            //    line.transDate = DateTime.Now;

                            //    db.PO_Line.Add(line);
                            //    db.SaveChanges();
                            //}
                            //else if (dgvLines.Rows[i].Cells["barcode"].Value as String == lines.barcode)
                            //{
                            //    var updateLine = db.PO_Line.Where(a => a.barcode.Equals(lines.barcode)).FirstOrDefault();
                                
                            //    decimal qty = Convert.ToDecimal(dgvLines.Rows[i].Cells["qty"].Value);
                            //    updateLine.qty = qty;

                            //    db.SaveChanges();
                            //}
                        //}
                    //}

                    var update = db.purchase_order.Where(a => a.orderNo.Equals(txtOrderNo.Text)).SingleOrDefault();

                    update.poType = cmbPOtype.Text;
                    update.modID = cmbMOD.GetItemText(cmbMOD.SelectedValue);
                    update.poolID = cmbPool.GetItemText(cmbPool.SelectedValue);
                    update.delAddressID = cmbDeliveryAdd.GetItemText(cmbDeliveryAdd.SelectedValue);
                    update.deliveryDate = dtpDelivery.Value;
                    update.cancelDate = dtpCancel.Value;

                    var updateLines = db.PO_Line.Where(a => a.orderNo.Equals(txtOrderNo.Text)).ToList();

                    //Check if dgv rows are existing in po_line tablethen update qty if not. Add the new row to the database
                    string barcode;
                    decimal qty;
                    for (int i = 0; dgvLines.Rows.Count > i; i++)
                    {
                        barcode = dgvLines.Rows[i].Cells["barcode"].Value.ToString();
                        var objExist = db.PO_Line.Where(a => a.barcode.Equals(barcode) && a.orderNo.Equals(txtOrderNo.Text));
                        if (objExist.Any())
                        {
                            qty = Convert.ToDecimal(dgvLines.Rows[i].Cells["qty"].Value);
                            //objExist.FirstOrDefault().qty = qty;
                            db.PO_Line.Where(a => a.barcode.Equals(barcode) && a.orderNo.Equals(txtOrderNo.Text)).ToList().ForEach(b => { b.qty = qty; });
                            
                        }
                        else
                        {
                            PO_Line line = new PO_Line();

                            qty = Convert.ToDecimal(dgvLines.Rows[i].Cells["qty"].Value);
                            line.orderNo = txtOrderNo.Text;
                            line.barcode = barcode;
                            line.qty = qty;
                            line.transDate = DateTime.Now;

                            db.PO_Line.Add(line);
                            db.SaveChanges();
                        }
                    }

                    //Check if po_lines are existing in datagridview . If not delete line in po_line table
                    bool isExist = true;
                    foreach(PO_Line lines in updateLines)
                    {
                        for (int i = 0; dgvLines.Rows.Count > i; i++ )
                        {
                            if(lines.barcode == dgvLines.Rows[i].Cells["barcode"].Value as String)
                            {
                                //MessageBox.Show("Equals " + lines.barcode + " " + dgvLines.Rows[i].Cells["barcode"].Value.ToString() +" "+ i);
                                isExist = true;
                                break;
                            }
                            else
                            {
                                //MessageBox.Show("Not equals " + lines.barcode + " " + dgvLines.Rows[i].Cells["barcode"].Value.ToString() + " " + i);
                                isExist = false;
                            }
                            
                        }
                        if(!isExist)
                        {
                            var objDel = db.PO_Line.Where(a => a.barcode.Equals(lines.barcode) && a.orderNo.Equals(txtOrderNo.Text)).SingleOrDefault();

                            db.PO_Line.Remove(objDel);
                            //db.SaveChanges();
                            //MessageBox.Show("Removed "+ lines.barcode, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            createUpdate();
        }

        private void tsbAddLines_Click(object sender, EventArgs e)
        {
            if (txtSuppID.Text.Equals(""))
            {
                MessageBox.Show("Supplier ID is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string barcode, RID, unit, productDesc;
                decimal unitPrice, retailPrice, qty, netAmount, discPrice, lineDisc;
                int i = 1;
                frmPOlines lines = new frmPOlines();
                DialogResult res = lines.ShowDialog();
                if(res == DialogResult.OK)
                {
                    fetchPOlines();
                    //foreach(DataGridViewRow row in lines.dgvNewItems.Rows)
                    //{
                    //    if (row.Cells["qty"].Value == null)
                    //    {

                    //    }
                    //    else
                    //    {
                    //        //barcode = row.Cells["Barcode"].Value.ToString();
                    //        //productDesc = row.Cells["Product_description"].Value.ToString();
                    //        //qty = Convert.ToDecimal(row.Cells["qty"].Value);
                    //        //var objCol = db.vwProducts.Where(a => a.Barcode.Equals(barcode)).SingleOrDefault();
                    //        //RID = objCol.RID;
                    //        //unit = objCol.Unit;
                    //        //unitPrice = Convert.ToDecimal(objCol.Cost_price);
                    //        //retailPrice = Convert.ToDecimal(objCol.Retail_price);
                    //        //lineDisc = Convert.ToDecimal(objCol.lineDisc);
                    //        //discPrice = (lineDisc / 100) * (qty * unitPrice);
                    //        //netAmount = (qty * unitPrice) - discPrice;
                    //        //var objDept = db.sp_catValidation("rid", RID);

                    //        //dgvLines.Rows.Add(i++, barcode, productDesc, qty, objDept.SingleOrDefault().dept_desc, unit, unitPrice, retailPrice, lineDisc, Math.Round(netAmount, 2));
                    //    }
                    //}
                    
                }
                //frmAddLines sorting = new frmAddLines();
                //sorting.ShowDialog();
            }
        }

        //public AutoCompleteStringCollection SKUline()
        //{
        //    AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
        //    var data =(from a in db.vwProducts where a.suppID == cmbSuppID.Text select a.SKU).ToArray();
        //    if(!string.IsNullOrEmpty(cmbSuppID.Text))
        //    {
        //        acsc.AddRange(data);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Supplier ID is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    return acsc;
        //}

        private void dgvLines_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dgvLines.CurrentCell.ColumnIndex == 1)
            //{

            //    if (string.IsNullOrEmpty(txtSuppID.Text))
            //    {
            //        MessageBox.Show("Supplier ID is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtSuppID.Focus();
            //    }
            //    //else if (string.IsNullOrEmpty(Id.skuLine))
            //    //{
            //    //    MessageBox.Show("SKU is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //}
            //    else
            //    {
            //        //this.barcode.DataSource = (from a in db.vwProducts where a.suppID == cmbSuppID.Text select a).ToList();
            //        //this.barcode.ValueMember = "barcode";
            //        //this.barcode.DisplayMember = "barcode";
            //    }
            //    e.CellStyle.BackColor = this.dgvLines.DefaultCellStyle.BackColor;
            //    //}

            //}
            //else if (dgvLines.CurrentCell.ColumnIndex == 2)
            //{
            //    int rowIndex = dgvLines.CurrentRow.Index;
            //    if (string.IsNullOrEmpty(dgvLines.Rows[rowIndex].Cells["barcode"].Value as String))
            //    {
            //        MessageBox.Show("Fill up barcode first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dgvLines.CurrentCell = dgvLines.Rows[rowIndex].Cells["barcode"];
            //        e.CellStyle.BackColor = Color.White;
            //    }
            //}
        }
        long lineID;
        private void dgvLines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLines.Rows[e.RowIndex];
                if(dgvLines.SelectedRows.Count > 0)
                {
                    lineID = Convert.ToInt64(row.Cells["lineID"].Value);

                    tsbRemove.Enabled = true;
                }
                else
                {
                    tsbRemove.Enabled = false;
                }
            }
        }

        private void dgvLines_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //decimal costPrice, retailPrice, lineDisc;
            //if (e.ColumnIndex == 1 && e.RowIndex != -1)
            //{
            //    Cursor.Current = Cursors.IBeam;
            //    DataGridViewRow row = dgvLines.Rows[e.RowIndex];
            //    if (!string.IsNullOrEmpty(row.Cells["barcode"].Value.ToString()))
            //    {
            //        string barcodeLine = row.Cells["barcode"].Value.ToString();
            //        var prodCol = (from a in db.vwProducts where a.Barcode == barcodeLine select a);
            //        if (prodCol.Any())
            //        {
            //            long rid = prodCol.SingleOrDefault().RID;
            //            var objDept = db.sp_catValidation("rid", rid).SingleOrDefault();
            //            costPrice = Convert.ToDecimal(prodCol.SingleOrDefault().Cost_price);
            //            retailPrice = Convert.ToDecimal(prodCol.SingleOrDefault().Retail_price);
            //            //lineDisc = Convert.ToDecimal(prodCol.SingleOrDefault().lineDisc);
            //            row.Cells["department"].Value = objDept.subcat_desc;
            //            row.Cells["po_unit"].Value = prodCol.SingleOrDefault().PO_Unit;
            //            row.Cells["po_price"].Value = costPrice;
            //            //row.Cells["lineDisc"].Value = lineDisc;
            //            row.Cells["retailPrice"].Value = retailPrice;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Barcode doesn't exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            row.Cells["barcode"].Value = "";
            //        }

            //        //discPrice = (Convert.ToDecimal(row.Cells["lineDisc"].Value) / 100) * (Convert.ToDecimal(row.Cells["qty"].Value) * Convert.ToDecimal(row.Cells["po_price"].Value));
            //    }
            //}
            //if (e.ColumnIndex == 2 && e.RowIndex != -1)
            //{
            //    int rowIndex = dgvLines.CurrentRow.Index;
            //    DataGridViewRow row = dgvLines.Rows[e.RowIndex];
            //    if (!string.IsNullOrEmpty(row.Cells["barcode"].Value as String))
            //    {
            //        row.Cells["netAmount"].Value = Convert.ToDecimal(row.Cells["qty"].Value) * Convert.ToDecimal(row.Cells["po_price"].Value) - (Convert.ToDecimal(row.Cells["lineDisc"].Value) / 100) * (Convert.ToDecimal(row.Cells["qty"].Value) * Convert.ToDecimal(row.Cells["po_price"].Value));
            //    }
            //    else
            //    {
            //        MessageBox.Show("Fill up barcode first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dgvLines.CurrentCell = dgvLines.Rows[rowIndex].Cells["barcode"];
            //    }
            //}

        }

        private void cmbPool_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pHeader.Controls.RemoveByKey("poolError");
            cmbPool.FlatStyle = FlatStyle.Standard;

            DataTable dt = po.fetchRecords("sp_purchaseOrderOperations", "pool", "fetchPool");
            DataRow[] dr = dt.Select("poolID = '" + cmbPool.SelectedValue + "'");

            txtPoolDesc.Text = dr[0]["Pool"].ToString();
            //string pool = cmbPool.GetItemText(cmbPool.SelectedValue);
            //var pDesc = (from a in db.C_pool where a.poolID == pool select a).SingleOrDefault();

            //txtPoolDesc.Text = pDesc.poolDesc;
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Remove product line?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                int rowIndex = dgvLines.SelectedRows[0].Index;

                long lineID = Convert.ToInt64(dgvLines.Rows[rowIndex].Cells["lineID"].Value);
                po.deletePOline("sp_purchaseOrderOperations", "POlines", "Delete", lineID);

                MessageBox.Show("Successfully deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fetchPOlines();
                tsbRemove.Enabled = false;
            }
        }

        private void tsbAddLine_Click(object sender, EventArgs e)
        {
            int n = dgvLines.Rows.Add();
            var maxID = dgvLines.Rows.Cast<DataGridViewRow>().Max(a => Convert.ToInt32(a.Cells["lineID"].Value));
            dgvLines.Rows[n].Cells["lineID"].Value = maxID + 1;
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
            pHeader.Controls.Add(p);

        }

        private void cmbPOtype_Leave(object sender, EventArgs e)
        {
            if(cmbPOtype.Text.Equals(""))
            {
                pName = "POtypeError";
                oW = cmbPOtype.Size.Width;
                oH = cmbPOtype.Size.Height;
                x = cmbPOtype.Location.X - 2;
                y = cmbPOtype.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                pHeader.Controls.RemoveByKey("POtypeError");
                redBorder();
                cmbPOtype.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                pHeader.Controls.RemoveByKey("POtypeError");
                cmbPOtype.FlatStyle = FlatStyle.Standard;
            }
        }

        private void cmbPOtype_MouseHover(object sender, EventArgs e)
        {
            if(cmbPOtype.FlatStyle == FlatStyle.Flat)
            {
                toolTip1.Show("Purchase type is required", cmbPOtype);
            }
            else
            {
                toolTip1.Hide(cmbPOtype);
            }
        }

        private void cmbPOtype_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pHeader.Controls.RemoveByKey("POtypeError");
            cmbPOtype.FlatStyle = FlatStyle.Standard;
        }

        private void cmbSuppID_Leave(object sender, EventArgs e)
        {
            if(txtSuppID.Text.Equals(""))
            {
                pName = "suppError";
                oW = txtSuppID.Size.Width;
                oH = txtSuppID.Size.Height;
                x = txtSuppID.Location.X - 2;
                y = txtSuppID.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                pHeader.Controls.RemoveByKey("suppError");
                redBorder();
                txtSuppID.BorderStyle = BorderStyle.None;
                txtSuppID.Size = new Size(oW, oH);
            }
            else
            {
                pHeader.Controls.RemoveByKey("suppError");
                txtSuppID.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        Panel p = new Panel();
        ComboBox cmbFilter = new ComboBox();
        TextBox txtSearch = new TextBox();
        public void supplierForm()
        {
            p.Name = "pSupplier";
            p.Size = new System.Drawing.Size(400, 219);
            p.Location = new Point(317, 23); //317, 133
            p.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            //groupBox1.Controls.Add(p);
            p.BringToFront();

            dgvSupplier.DataSource = (from a in db.suppliers
                                      where a.isActive == true
                                      select new
                                      {
                                          a.suppID,
                                          a.name
                                      }).ToList();

            cmbFilter.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            //cmbFilter.Size = new System.Drawing.Size(90, 25);
            cmbFilter.Dock = DockStyle.Top;
            //cmbFilter.BringToFront();
            txtSearch.Font = new System.Drawing.Font("Segeo UI", 8, FontStyle.Regular);
            //txtSearch.Size = new System.Drawing.Size(139, 25);
            txtSearch.Dock = DockStyle.Top;
            //txtSearch.BringToFront();
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("Supplier_ID");
            cmbFilter.Items.Add("Name");

            //dgvSupplier.Dock = DockStyle.Fill;
            //dgvSupplier.BringToFront();
            dgvSupplier.Dock = DockStyle.Bottom;
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

             if (cmbFilter.Text.Equals(""))
            {
                MessageBox.Show("Please select search filter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Clear();
            }
            else if (cmbFilter.Text.Equals("Supplier_ID"))
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
            //p.BringToFront();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSupplier.Rows[e.RowIndex];

                Id.globalID = row.Cells["suppID"].Value.ToString();
                //Id.globalString = row.Cells["Name"].Value.ToString();
            }
        }

        private void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgvSupplier.Rows[e.RowIndex];

                Id.suppID = row.Cells["suppID"].Value.ToString();
                txtSuppID.Text = row.Cells["suppID"].Value.ToString();
                txtName.Text = row.Cells["name"].Value.ToString();
                //var suppDetails = db.suppliers.Where(a => a.suppID.Equals(Id.suppID)).SingleOrDefault();
                var suppDetails = db.suppliers.Join(db.paymentTerms, s => s.payID,
                    a => a.payID, (s, a) => new { s = s, a = a }).Where(sa => sa.s.suppID.Equals(Id.suppID)).SingleOrDefault();
                txtPayTerm.Text = suppDetails.a.payDesc;
                txtAgent.Text = suppDetails.s.agent;
                txtSuppID.BorderStyle = BorderStyle.Fixed3D;
                pHeader.Controls.RemoveByKey("pSupplier");

                //if(Id.button.Equals("changeDistri"))
                //{
                //    //Do nothing
                //}
                //else
                //{
                //    //fetchPrincipal();
                //}
                
            }
        }

        private void txtSuppID_Click(object sender, EventArgs e)
        {
            supplierForm();
            pHeader.Controls.Add(p);
            p.BorderStyle = BorderStyle.FixedSingle;
            dgvSupplier.Size = new System.Drawing.Size(400, 174);
            dgvSupplier.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSupplier.Columns[0].HeaderText = "Supplier ID";
            dgvSupplier.Columns[1].HeaderText = "Name";
            p.BringToFront();
        }

        private void txtSuppID_Leave(object sender, EventArgs e)
        {
            if(txtSuppID.Text.Equals(""))
            {
                pName = "suppError";
                oW = txtSuppID.Size.Width;
                oH = txtSuppID.Size.Height;
                x = txtSuppID.Location.X - 2;
                y = txtSuppID.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                pHeader.Controls.RemoveByKey("suppError");
                redBorder();
                //txtSuppID.BorderStyle = BorderStyle.None;
                //txtSuppID.Multiline = true;
                //txtSuppID.Size = new System.Drawing.Size(oW, oH);
                
            }
            else
            {
                pHeader.Controls.RemoveByKey("suppError");
                //txtSuppID.Multiline = false;
                //txtSuppID.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void txtSuppID_MouseHover(object sender, EventArgs e)
        {
            if(txtSuppID.BorderStyle == BorderStyle.None)
            {
                toolTip1.Show("Supplier ID is required", txtSuppID);
            }
            else
            {
                toolTip1.Hide(txtSuppID);
            }
        }

        private void txtSuppID_TextChanged(object sender, EventArgs e)
        {
            pHeader.Controls.RemoveByKey("suppError");
            //txtSuppID.Multiline = false;
            //txtSuppID.BorderStyle = BorderStyle.Fixed3D;
        }

        private void cmbPool_Leave(object sender, EventArgs e)
        {
            if(cmbPool.Text.Equals(""))
            {
                pName = "poolError";
                oW = cmbPool.Size.Width;
                oH = cmbPool.Size.Height;
                x = cmbPool.Location.X - 2;
                y = cmbPool.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                pHeader.Controls.RemoveByKey("poolError");
                redBorder();
                cmbPool.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                pHeader.Controls.RemoveByKey("poolError");
                cmbPool.FlatStyle = FlatStyle.Standard;
            }
        }

        private void cmbPool_MouseHover(object sender, EventArgs e)
        {
            if(cmbPool.FlatStyle == FlatStyle.Flat)
            {
                toolTip1.Show("Pool is required", cmbPool);
            }
            else
            {
                toolTip1.Hide(cmbPool);
            }
        }

        private void cmbMOD_Leave(object sender, EventArgs e)
        {
            if(cmbMOD.Text.Equals(""))
            {
                pName = "modError";
                oW = cmbMOD.Size.Width;
                oH = cmbMOD.Size.Height;
                x = cmbMOD.Location.X - 2;
                y = cmbMOD.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                pHeader.Controls.RemoveByKey("modError");
                redBorder();
                cmbMOD.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                pHeader.Controls.RemoveByKey("modError");
                cmbMOD.FlatStyle = FlatStyle.Standard;
            }
        }

        private void cmbMOD_MouseHover(object sender, EventArgs e)
        {
            if(cmbMOD.FlatStyle == FlatStyle.Flat)
            {
                toolTip1.Show("Mode of delivery is required", cmbMOD);
            }
            else
            {
                toolTip1.Hide(cmbMOD);
            }
        }

        private void cmbMOD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pHeader.Controls.RemoveByKey("modError");
            cmbMOD.FlatStyle = FlatStyle.Standard;
            int modID = Convert.ToInt32(cmbMOD.SelectedValue);
            DataTable dt = po.fetchRecords("sp_purchaseOrderOperations", "modeOfDelivery", "fetchModeOfDelivery");
            DataRow[] dr = dt.Select("modID = "+ modID +"");
            int days = Convert.ToInt32(dr[0]["Days"]);
            dtpDelivery.Value = DateTime.Now.AddDays(days);
            dtpCancel.Value = dtpDelivery.Value.AddDays(days);
            //Id.iGlobalID = Convert.ToInt32(cmbMOD.GetItemText(cmbMOD.SelectedValue));
            //var days = db.modeOfDeliveries.Where(a => a.modID.Equals(Id.iGlobalID)).SingleOrDefault();
            //double delivery = Convert.ToDouble(days.days);
            //dtpDelivery.Value = dtpEntry.Value.AddDays(delivery);
            //dtpCancel.Value = dtpEntry.Value.AddDays(delivery + delivery);
        }

        private void cmbDeliveryAdd_Leave(object sender, EventArgs e)
        {
            if(cmbDeliveryAdd.Text.Equals(""))
            {
                pName = "deliveryError";
                oW = cmbDeliveryAdd.Size.Width;
                oH = cmbDeliveryAdd.Size.Height;
                x = cmbDeliveryAdd.Location.X - 2;
                y = cmbDeliveryAdd.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                pHeader.Controls.RemoveByKey("deliveryError");
                redBorder();
                cmbDeliveryAdd.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                pHeader.Controls.RemoveByKey("deliveryError");
                cmbDeliveryAdd.FlatStyle = FlatStyle.Standard;
            }
        }

        private void cmbDeliveryAdd_MouseHover(object sender, EventArgs e)
        {
            if(cmbDeliveryAdd.FlatStyle == FlatStyle.Flat)
            {
                toolTip1.Show("Delivery address is required", cmbDeliveryAdd);
            }
            else
            {
                toolTip1.Hide(cmbDeliveryAdd);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtPayTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbPOtype_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbPool_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtPoolDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbMOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbDeliveryAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvLines.ClearSelection();
        }

        private void lblLineDetails_Click(object sender, EventArgs e)
        {
            dropdown = "lineDetails";
            timer1.Start();
        }

        private void cmbDiscountType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDiscountType.Text))
            {
                txtTotalDiscount.Enabled = false;
                txtPesoDiscount.Enabled = false;
                txtPriceUnit.Enabled = false;
            }
            else if (cmbDiscountType.Text == "Seasonal discount")
            {
                txtTotalDiscount.Enabled = true;
                txtPesoDiscount.Enabled = false;
                txtPriceUnit.Enabled = false;
            }
            else if (cmbDiscountType.Text == "Peso discount")
            {
                txtTotalDiscount.Enabled = false;
                txtPesoDiscount.Enabled = true;
                txtPriceUnit.Enabled = true;
            }
        }

       

       
       
    }
}
