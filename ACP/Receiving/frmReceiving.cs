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
    public partial class frmReceiving : Form
    {
        acpEntities db = new acpEntities();
        public frmReceiving()
        {
            InitializeComponent();
        }

        private void btnPosting_Click(object sender, EventArgs e)
        {
            frmPostingReceipt posting = new frmPostingReceipt();
            posting.tsPosting.Visible = false;
            posting.dgvReceipt.Dock = DockStyle.Fill;
            posting.ShowDialog();
        }
        public void fetchPO()
        {
            var fetchPO = (from a in db.vwPO_Line
                           where a.orderNo.Equals(Id.orderNo)
                           select a).ToList();
            int i = 1;
            int n = 0;
            //DataGridViewCellStyle style = new DataGridViewCellStyle();
            //style.BackColor = Color.LightGreen;
            //style.ForeColor = Color.Black;
            foreach(vwPO_Line line in fetchPO)
            {
                dgvLines.Rows.Add(i++, line.SKU, line.barcode, line.posDesc, line.subcat_desc, line.qty, line.rcve, "", line.CPuomDesc, line.costPrice, line.retailPrice, line.lineDisc, line.Net_amount, line.remarks);
                dgvLines.Rows[n].Cells["receiveNow"].Style.BackColor = Color.LightGreen;
                n++;
            }
            dgvLines.Columns[0].ReadOnly = true;
            dgvLines.Columns[1].ReadOnly = true;
            dgvLines.Columns[2].ReadOnly = true;
            dgvLines.Columns[3].ReadOnly = true;
            dgvLines.Columns[4].ReadOnly = true;
            dgvLines.Columns[5].ReadOnly = true;
            dgvLines.Columns[6].ReadOnly = true;
            dgvLines.Columns[7].ReadOnly = false;
            dgvLines.Columns[8].ReadOnly = true;
            dgvLines.Columns[9].ReadOnly = true;
            dgvLines.Columns[10].ReadOnly = true;
            dgvLines.Columns[11].ReadOnly = true;
            dgvLines.Columns[12].ReadOnly = true;
            dgvLines.Columns[13].ReadOnly = true;
        }
        

        private void frmReceiving_Load(object sender, EventArgs e)
        {
            fetchPO();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {

            frmPostingReceipt posting = new frmPostingReceipt();
            
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

            var poLines = db.PO_Line.Where(a => a.orderNo.Equals(Id.orderNo)).ToList();
            
            int i = 0;
            foreach (PO_Line lines in poLines)
            {
                decimal rcvNow = Convert.ToDecimal(dgvLines.Rows[i].Cells["receiveNow"].Value);
                string barcode = dgvLines.Rows[i].Cells["barcode"].Value.ToString();
                db.PO_Line.Where(a => a.orderNo.Equals(Id.orderNo) && a.barcode.Equals(barcode)).ToList().ForEach(b => { b.rcve = rcvNow; });
                i++;
            }

            var update = db.purchase_order.Where(a => a.orderNo.Equals(Id.orderNo)).SingleOrDefault();

            update.status = "Received";

            db.SaveChanges();
            DialogResult res = MessageBox.Show("Successfully saved. Create packing slip?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(res == DialogResult.Yes)
            {
                posting.dgvReceipt.Rows.Add(Id.orderNo, Id.globalString, "", isConcession, "", "", "", "", "");
                posting.dgvReceipt.Columns[0].ReadOnly = true;
                posting.dgvReceipt.Columns[1].ReadOnly = true;
                posting.dgvReceipt.Columns[2].ReadOnly = false;
                posting.dgvReceipt.Columns[3].ReadOnly = true;
                posting.dgvReceipt.Columns[4].ReadOnly = false;
                posting.dgvReceipt.Columns[5].ReadOnly = false;
                posting.dgvReceipt.Columns[6].ReadOnly = false;
                posting.dgvReceipt.Columns[7].ReadOnly = false;
                posting.dgvReceipt.Columns[8].ReadOnly = false;
                DialogResult result = posting.ShowDialog();
                if(result == DialogResult.No)
                {
                    this.DialogResult = DialogResult.No;
                    this.Hide();
                }
            }
            else
            {
                this.DialogResult = DialogResult.No;
                this.Hide();
            }
            
        }

        private void dgvLines_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 7 && e.RowIndex != -1)
            {
                Cursor.Current = Cursors.IBeam;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
