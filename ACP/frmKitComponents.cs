using System;
using System.Collections;
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
    public partial class frmKitComponents : Form
    {
        acpEntities db = new acpEntities();
        productClass prod = new productClass();
        productCreation pc = new productCreation();
        public frmKitComponents()
        {
            InitializeComponent();
        }
        int kitID;
        public void autoInc()
        {
            kitID = pc.autoInc("kitID", "componentSetup");
        }

        private void dgvComponents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.ColumnIndex == 1 && e.RowIndex != -1)
            //{
            //    Cursor.Current = Cursors.IBeam;
            //    DataGridViewRow row = dgvComponents.Rows[e.RowIndex];
            //    if(!string.IsNullOrEmpty(row.Cells["barcode"].Value as string))
            //    {
            //        string barcodeLine = row.Cells["barcode"].Value.ToString();
            //        var prod = db.vwProducts.Where(a => a.Barcode == barcodeLine);
            //        if(prod.Any())
            //        {
            //            string sku = prod.SingleOrDefault().SKU;
            //            string description = prod.SingleOrDefault().Product_description;
            //            int unitID = prod.SingleOrDefault().RPuomID;
            //            string unit = prod.SingleOrDefault().Retail_Unit;
            //            row.Cells["description"].Value = description;
            //            row.Cells["unitID"].Value = unitID;
            //            row.Cells["unit"].Value = unit;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Barcode doesn't exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            row.Cells["barcode"].Value = "";
            //        }
            //    }
            //}
        }

        private void fetchComponent()
        {
            DataTable dt = pc.fetchComponentSetup("sp_componentSetup", "fetchComponentSetup");

            dgvComponents.DataSource = dt;

            dgvComponents.Columns["kitID"].Visible = false;
            dgvComponents.Columns["RPuomID"].Visible = false;
            dgvComponents.Columns["masterBarcode"].HeaderText = "Master barcode";
            dgvComponents.Columns["prodBarcode"].HeaderText = "Product barcode";
            dgvComponents.Columns["qty"].HeaderText = "Quantity";
            dgvComponents.Columns["masterBarcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvComponents.Columns["prodBarcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dgvComponents.Columns["Product description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvComponents.Columns["qty"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvComponents.Columns["Retail Unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void autoCompleteBarcode()
        {
            DataSet ds = pc.cbRecords("Barcode", "fetchBarcode", "barcode");

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (DataRow dr in ds.Tables["barcode"].Rows)
            {
                data.Add(dr["barcode"].ToString());
            }

            txtBarcode.AutoCompleteCustomSource = data;
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

        private void frmKitComponents_Load(object sender, EventArgs e)
        {
            autoCompleteBarcode();
            txtQty.Text = 0.ToString("N2");
            fetchComponent();
            //if (Id.button == "Create")
            //{
            //    autoInc();
            //}
        }

        private void disableAndClear()
        {
            btnCreate.Text = "Create";
            btnCreate.Enabled = false;
            txtBarcode.Enabled = false;
            txtBarcode.Clear();
            txtProdDesc.Clear();
            txtQty.Enabled = false;
            txtQty.Clear();
            txtQty.Text = 0.ToString("N2");
            txtUOM.Clear();
        }

        bool isBlank = true;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(btnCreate.Text == "Create")
            {
                autoInc();
                decimal quantity = Convert.ToDecimal(txtQty.Text);
                pc.createUpdateComponent("Create",kitID, Id.barcode, txtBarcode.Text, quantity, Id.userID);
                MessageBox.Show("Successfully created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fetchComponent();
                disableAndClear();
            }
            else if(btnCreate.Text == "Update")
            {

            }
            //if (Id.button == "Create")
            //{
            //    MessageBox.Show("a");
            //    if (dgvComponents.Rows.Count > 0)
            //    {
            //        MessageBox.Show("b");
            //        Id.dt.Columns.Add("code", typeof(string));
            //        Id.dt.Columns.Add("barcode", typeof(string));
            //        Id.dt.Columns.Add("description", typeof(string));
            //        Id.dt.Columns.Add("qty", typeof(decimal));
            //        Id.dt.Columns.Add("unitID", typeof(int));
            //        Id.dt.Columns.Add("unit", typeof(string));
            //        componentSetup kit = new componentSetup();
            //        for (int i = 0; dgvComponents.Rows.Count > i; i++)
            //        {
            //            MessageBox.Show("c");
            //            //for (int c = 0; dgvComponents.Columns.Count > c; c++)
            //            //{
            //                MessageBox.Show("d");
            //                if (!string.IsNullOrEmpty(dgvComponents.Rows[i].Cells["barcode"].Value as string) || !string.IsNullOrEmpty(dgvComponents.Rows[i].Cells["qty"].Value as string))
            //                {
            //                    MessageBox.Show("e");
            //                    isBlank = false;
            //                    //kit.kitID = Id.kitID;
            //                    //kit.code = Id.kitCode;
            //                    //kit.masterBarcode = Id.barcode;
            //                    //kit.prodBarcode = dgvComponents.Rows[i].Cells["barcode"].Value.ToString();
            //                    //kit.qty = Convert.ToDecimal(dgvComponents.Rows[i].Cells["qty"].Value);
            //                    //kit.transDate = DateTime.Now;
            //                    //kit.userID = null;

            //                    //db.componentSetups.Add(kit);
            //                    foreach(DataGridViewRow row in dgvComponents.Rows)
            //                    {
            //                        DataRow dRow = Id.dt.NewRow();
            //                        foreach(DataGridViewCell cell in row.Cells)
            //                        {
            //                            dRow[cell.ColumnIndex] = cell.Value;
            //                        }
            //                        Id.dt.Rows.Add(dRow);
            //                    }
            //                    //DataTable dt = prod.dgvToDt(dgvComponents);
            //                    //var name = dt.Rows[0][1];
            //                    //dataGridView1.DataSource = dt;

                                
            //                    break;
            //                }
            //                else
            //                {
            //                    isBlank = true;
            //                }
            //            //}

            //        }
            //        MessageBox.Show("Successfully created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.Hide();
            //        this.DialogResult = DialogResult.OK;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Data grid is empty", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //else if(Id.button == "Update")
            //{

            //}
        }

        private void dgvComponents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if(e.ColumnIndex == 3 && e.RowIndex != this.dgvComponents.NewRowIndex)
            //{
            //    if(dgvComponents.Rows[e.RowIndex].Cells[0].Value != null && dgvComponents.Rows[e.RowIndex].Cells[3].Value != null)
            //    {
            //        decimal val = decimal.Parse(e.Value.ToString());
            //        e.Value = val.ToString("N2");
                    
            //    }
            //}
        }

        private void dgvComponents_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if(dgvComponents.CurrentCell.ColumnIndex == 3)
            //{
            //    int rowIndex = dgvComponents.SelectedRows[0].Index;
            //    if(string.IsNullOrEmpty(dgvComponents.Rows[rowIndex].Cells["barcode"].Value as string))
            //    {
            //        MessageBox.Show("Barcode is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dgvComponents.CurrentCell = dgvComponents.Rows[rowIndex].Cells["barcode"];
            //    }
            //}
        }

        private void tsbDeleteBarcode_Click(object sender, EventArgs e)
        {
            if(dgvComponents.SelectedRows.Count > 0)
            {
                if (Id.button == "Create")
                {
                    dgvComponents.Rows.RemoveAt(dgvComponents.SelectedRows[0].Index);
                }
            }
        }

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            //dgvComponents.Rows.Add();
            btnCreate.Text = "Create";
            btnCreate.Enabled = true;
            txtBarcode.Enabled = true;
            txtBarcode.Clear();
            txtQty.Enabled = true;
            txtQty.Clear();
            txtQty.Text = 0.ToString("N2");
            txtProdDesc.Clear();
            txtUOM.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IEnumerable components = (from a in Id.dt.AsEnumerable() select a);
            //foreach (DataRow dr in components)
            //{
            //    MessageBox.Show(dr.Field<string>("barcode"));
            //}
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Id.columnName = "@barcode";
                e.SuppressKeyPress = true;
                DataTable dt = pc.fetchRecordById("sp_Product", "Barcode", "fetchBarcodeById", txtBarcode.Text);

                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        txtProdDesc.Text = row["PosDesc"].ToString();
                        txtUOM.Text = row["Retail Unit"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Barcode does not exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
