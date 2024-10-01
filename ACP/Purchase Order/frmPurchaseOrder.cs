using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACP
{
    public partial class frmPurchaseOrder : Form
    {
        acpEntities db = new acpEntities();
        purchaseOrderClass po = new purchaseOrderClass();
        public frmPurchaseOrder()
        {
            InitializeComponent();
        }

        public void fetchPO()
        {
            DataTable dt = po.fetchRecords("sp_purchaseOrderOperations", "purchaseOrder", "fetchPO");
            dgvPO.DataSource = dt;

            dgvPO.Columns["order No."].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPO.Columns["Supplier ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPO.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPO.Columns["Agent"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPO.Columns["Date created"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPO.Columns["Delivery date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPO.Columns["Cancellation date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPO.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPO.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvPO.DataSource = (from a in db.vwPurchaseOrders
            //                    select new 
            //                    {
            //                    a.Order_No,
            //                    a.Supplier_ID,
            //                    a.Name,
            //                    a.agent,
            //                    a.Date_created,
            //                    a.Delivery_date,
            //                    a.Cancellation_date,
            //                    a.Status,
            //                    a.Amount,
            //                    }).ToList();
            //dgvPO.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvPO.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvPO.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dgvPO.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dgvPO.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvPO.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvPO.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvPO.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvPO.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnNewOder_Click(object sender, EventArgs e)
        {
            Id.button = "Create";
            frmAddOrder order = new frmAddOrder();
            po.createUpdatePurchaseOrder("Create", null, null, 0, null, null, 0, null, null, "Draft", null, Id.userID);
            order.txtOrderNo.Text = string.Format("{0:00000}", Convert.ToInt32(Id.autoIncOrderNo));
            Id.orderNo = string.Format("{0:00000}", Convert.ToInt32(Id.autoIncOrderNo));
            order.btnCreate.Text = "Save";
            order.btnClose.Text = "Cancel";
            DialogResult res = order.ShowDialog();
            if(res == DialogResult.OK)
            {
                fetchPO();
            }
            //order.btnCreate.Text = "Create";
            //order.cmbPOtype.Text = "Purchase order";
            //order.ShowDialog();
            //fetchPO();
        }

        //private void dgvPOlines()
        //{
        //    if(dgvPO.SelectedRows.Count > 0)
        //    {
        //        pLines.Visible = true;
        //        dgvLines.Visible = true;
        //    }
        //    else
        //    {
        //        pLines.Visible = false;
        //        dgvLines.Visible = false;
        //        int h, w;
        //        h = 569;
        //        w = dgvPO.Size.Width;
        //        dgvPO.Size = new Size(w, h);
        //    }

        //}

        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            fetchPO();
            //dgvPOlines();
        }

        private void dgvPO_Paint(object sender, PaintEventArgs e)
        {
            foreach(DataGridViewColumn col in dgvPO.Columns)
            {
                col.HeaderText = col.HeaderText.Replace("_", " ");
            }
        }

        private void dgvPO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(dgvPO.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvPO.Rows[e.RowIndex];

                    Id.orderNo = row.Cells["Order No."].Value.ToString();
                    Id.status = row.Cells["Status"].Value.ToString();
                    Id.globalString = row.Cells["Name"].Value.ToString();
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;

                    //var lines = db.vwPO_Line.Where(a => a.orderNo.Equals(Id.orderNo)).ToList();
                    //int i = 1;
                    //dgvLines.Rows.Clear();
                    //foreach(vwPO_Line line in lines)
                    //{
                    //    dgvLines.Rows.Add(i++, line.barcode, line.posDesc, line.subcat_desc, line.CPuomDesc, line.costPrice, line.retailPrice, line.lineDisc, line.Net_amount, line.remarks);
                    //}
                    int h, w;
                    h = 416;
                    w = dgvPO.Size.Width;
                    dgvPO.Size = new Size(w, h);
                    pLines.Visible = true;
                    dgvLines.Visible = true;

                    if(Id.status.Equals("Confirmed"))
                    {
                        btnReceive.Enabled = true;
                        btnPOreport.Enabled = true;
                    }
                    else
                    {
                        btnReceive.Enabled = false;
                        btnPOreport.Enabled = false;
                    }
                    if(Id.status.Equals("For approval"))
                    {
                        btnConfirm.Enabled = true;
                    }
                    else
                    {
                        btnConfirm.Enabled = false;
                    }
                    //if(Id.status.Equals("Received"))
                    //{
                    //    btnPosting.Enabled = true;
                    //}
                    //else
                    //{
                    //    btnPosting.Enabled = false;
                    //}
                }
                else
                {
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    pLines.Visible = false;
                    dgvLines.Visible = false;
                }
            }
        }

        private void btnPOreport_Click(object sender, EventArgs e)
        {
            frmReports po = new frmReports();
            po.ShowDialog();
        }

        private void dgvPO_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvPO.ClearSelection();
            //dgvPOlines();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Id.button = "Update";
            if(dgvPO.SelectedRows.Count > 0)
            {
                frmAddOrder addOrder = new frmAddOrder();
                addOrder.btnCreate.Text = "Update";
                var objEdit = db.vwPurchaseOrders.Where(a => a.Order_No.Equals(Id.orderNo)).SingleOrDefault();
                DateTime delivery = Convert.ToDateTime(objEdit.Delivery_date);
                DateTime cancellation = Convert.ToDateTime(objEdit.Cancellation_date);

                Id.suppID = objEdit.Supplier_ID;
                addOrder.txtOrderNo.Text = objEdit.Order_No;
                addOrder.cmbPOtype.Text = objEdit.poType;
                addOrder.txtSuppID.Text = objEdit.Supplier_ID;
                addOrder.txtName.Text = objEdit.Name;
                addOrder.txtAgent.Text = objEdit.agent;
                addOrder.txtPayTerm.Text = objEdit.payDesc;
                addOrder.cmbPool.Text = objEdit.Pool_ID;
                addOrder.txtPoolDesc.Text = objEdit.Pool_name;
                addOrder.cmbMOD.Text = objEdit.modDesc;
                addOrder.dtpDelivery.Value = delivery;
                addOrder.dtpCancel.Value = cancellation;
                addOrder.cmbDeliveryAdd.Text = objEdit.desc;
                addOrder.rtxtAddress.Text = objEdit.address + ", " + objEdit.city + ", " + objEdit.province + ", " + objEdit.delRemarks;
                addOrder.rtxtRemarks.Text = objEdit.remarks;

                int i = 1;
                using (var db2 = new acpEntities())
                {

                    var poLines = db2.vwPO_Line.Where(a => a.orderNo.Equals(Id.orderNo)).ToList();

                    foreach (vwPO_Line lines in poLines)
                    {
                        addOrder.dgvLines.Rows.Add(i++, lines.barcode, lines.qty, lines.subcat_desc, lines.CPuomDesc, lines.costPrice, lines.retailPrice, lines.lineDisc, lines.Net_amount);
                    }
                }
                //var poLines = db.vwPO_Line.Where(a => a.orderNo.Equals(Id.orderNo));
                DialogResult res = addOrder.ShowDialog();
                if(res == DialogResult.OK)
                {
                    fetchPO();

                    //var entity = db.ChangeTracker.Entries().ToArray();
                    //for (int y = 0; y < entity.Length; y++ )
                    //{
                    //    entity[y].Reload();
                    //}
                    //db.Entities(objRefresh).State = EntitySate.Detached;
                    //db.Entry(objRefresh).ReloadAsync();
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Confirm purchase order "+ Id.orderNo +"?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(res == DialogResult.Yes)
            {
                var objUpdate = db.purchase_order.Where(a => a.orderNo.Equals(Id.orderNo)).SingleOrDefault();

                objUpdate.status = "Confirmed";
                db.SaveChanges();
                fetchPO();

                frmReports report = new frmReports();
                report.ShowDialog();
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            frmReceiving receive = new frmReceiving();
            DialogResult res = receive.ShowDialog();
            if(res == DialogResult.No)
            {
                fetchPO();
            }
        }

        private void btnPosting_Click(object sender, EventArgs e)
        {
            frmPostingReceipt posting = new frmPostingReceipt();
            posting.tsPosting.Visible = true;
            var objExist = db.receivings.Where(a => a.orderNo.Equals(Id.orderNo));
            if(objExist.Any())
            {
                var objCol = db.vwPurchaseOrders.Where(a => a.Order_No.Equals(Id.orderNo)).SingleOrDefault();
                bool isOutright = Convert.ToBoolean(objCol.isConcession);
                string isConcession;
                if(isOutright)
                {
                    isConcession = "Concession";
                }
                else
                {
                    isConcession = "Outright";
                }
                posting.dgvReceipt.Rows.Clear();
                posting.dgvReceipt.Rows.Add(Id.orderNo, Id.globalString, "", isConcession, "", "", "", "", "");

                var lines = db.vwPO_Line.Where(a => a.orderNo.Equals(Id.orderNo)).ToList();
                int i = 1;
                posting.dgvLines.Rows.Clear();
                foreach(vwPO_Line line in lines)
                {
                    posting.dgvLines.Rows.Add(i++, line.SKU, line.barcode, line.posDesc, line.subcat_desc, line.qty, line.rcve, line.CPuomDesc, line.costPrice, line.retailPrice, line.lineDisc, line.Net_amount);
                }
            }
            DialogResult res = posting.ShowDialog();
            if(res == DialogResult.No)
            {
                fetchPO();
            }
        }

        private void dgvPO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fetchPO();
            //dgvPOlines();
        }
    }
}
