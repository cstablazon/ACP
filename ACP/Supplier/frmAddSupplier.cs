using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ACP
{
    public partial class frmAddSupplier : Form
    {
        supplierClass supClass = new supplierClass();
        TextInfo txtInfo = CultureInfo.CurrentCulture.TextInfo;
        acpEntities db = new acpEntities();
        string msg;
        // The TextBox
        public frmAddSupplier()
        {
            InitializeComponent();
           // tvCatHierarchy.DrawNode += tvCatHierarchy_DrawNode;
            //recordType();
            formLoad();
        }

        private void formLoad()
        {
            if (Id.button == "Create")
            {
                btnSave.Text = "Create";
                retailStore();
                showPayTerm();
                showSGroup();
                itemTax();
            }
            else if (Id.button == "Update")
            {
                btnSave.Text = "Update";
                //blankCMB();

                retailStore();
                showPayTerm();
                showSGroup();
                itemTax();
            }
        }

        //private void blankCMB()
        //{
        //    if (Id.button == "Update")
        //    {
        //        cmbPayTerms.Text = "";
        //        cmbType.Text = "";
        //        cmbGroup.Text = "";
        //        cmbItemTax.Text = "";
        //    }
        //}

        private void showPayTerm() {

            DataSet ds = supClass.showPayterms();
            cmbPayTerms.DataSource = ds.Tables["days"];
            cmbPayTerms.DisplayMember = "days";
            cmbPayTerms.ValueMember = "payID";
            cmbPayTerms.Text = "";
        }

        private void showSGroup()
        {
            DataSet ds = supClass.showSuppGroup();
            cmbGroup.DataSource = ds.Tables["desc"];
            cmbGroup.DisplayMember = "desc";
            cmbGroup.ValueMember = "sGroupID";
            //cmbGroup.Text = Id.groupID;
            cmbGroup.Text = "";
        }

        public void retailStore()
        {
            
        }

        private void itemTax()
        {
            DataSet ds = supClass.itemTax();
            cmbItemTax.DataSource = ds.Tables["Tax ID"];
            cmbItemTax.DisplayMember = "Tax ID";
            cmbItemTax.ValueMember = "Tax ID";
            cmbItemTax.Text = "";
        }

        private void frmAddSupplier_Load(object sender, EventArgs e)
        {
            if(Id.button == "Create")
            {
                cmbGroup.Text = "";
                cmbPayTerms.Text = "";
                cmbType.Text = "";
                cmbItemTax.Text = "";
            }
        }
        public void clear()
        {
            cmbGroup.Text = "";
            cmbPayTerms.Text = "";
            cmbType.Text = "";
            cmbItemTax.Text = "";
            txtSupCode.Clear();
            txtAgent.Clear();
            txtName.Clear();
        }

        string suppRID;
        bool isDistributor;
        bool isActive;
        int? userID;
        public void  createUpdate()
        {
            try
            {
                if (string.IsNullOrEmpty(cmbType.Text) || string.IsNullOrWhiteSpace(cmbType.Text))
                {
                    MessageBox.Show("Record type is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbType.Focus();
                }
                else if (string.IsNullOrEmpty(cmbItemTax.Text) || string.IsNullOrWhiteSpace(cmbItemTax.Text))
                {
                    MessageBox.Show("Item sales tax is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbItemTax.Focus();
                }
                else if (string.IsNullOrEmpty(cmbGroup.Text) || string.IsNullOrWhiteSpace(cmbGroup.Text))
                {
                    MessageBox.Show("Group is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbGroup.Focus();
                }

                else if (string.IsNullOrEmpty(txtSupCode.Text) || string.IsNullOrWhiteSpace(txtSupCode.Text))
                {
                    MessageBox.Show("Supplier code is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSupCode.Focus();
                }
                else if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Supplier name is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Focus();
                }
                else
                {
                    if (Id.button.Equals("Create"))
                    {
                        if (!db.suppliers.Any(a => a.suppID == txtSupCode.Text))
                        {
                            string itemTax = cmbItemTax.SelectedValue.ToString();
                            int? payID;
                            int? sGroupID;
                            if (!string.IsNullOrEmpty(cmbPayTerms.Text) || !string.IsNullOrEmpty(cmbGroup.Text) || !string.IsNullOrWhiteSpace(cmbPayTerms.Text) || !string.IsNullOrWhiteSpace(cmbGroup.Text))
                            {
                                payID = Convert.ToInt32(cmbPayTerms.SelectedValue);
                                sGroupID = Convert.ToInt32(cmbGroup.SelectedValue);
                            }
                            else
                            {
                                payID = null;
                                sGroupID = null;
                            }
                            supClass.createUpdateSupplier("Supplier", "Create", txtSupCode.Text.Trim(), itemTax, payID, sGroupID, txtInfo.ToTitleCase(txtName.Text.Trim()), txtInfo.ToTitleCase(cmbType.Text), txtInfo.ToTitleCase(txtAgent.Text.Trim()), null, true, true, Id.userID);

                            MessageBox.Show("Successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Supplier ID already exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (Id.button.Equals("Update"))
                    {
                        string itemTax = cmbItemTax.SelectedValue.ToString();
                        int? payID;
                        int? sGroupID;
                        if (!string.IsNullOrEmpty(cmbPayTerms.Text) || !string.IsNullOrEmpty(cmbGroup.Text) || !string.IsNullOrWhiteSpace(cmbPayTerms.Text) || !string.IsNullOrWhiteSpace(cmbGroup.Text))
                        {
                            payID = Convert.ToInt32(cmbPayTerms.SelectedValue);
                            sGroupID = Convert.ToInt32(cmbGroup.SelectedValue);
                        }
                        else
                        {
                            payID = null;
                            sGroupID = null;
                        }

                        var objExcept = db.suppliers.Where(a => a.suppID == Id.suppID);
                        if (!db.suppliers.Except(objExcept).Any(a => a.suppID == txtSupCode.Text))
                        {
                            DataTable dt = supClass.getSupplierById("fetchSupplierById", Id.suppID);
                            foreach (DataRow row in dt.Rows)
                            {
                                suppRID = row["RID"].ToString();
                                isDistributor = Convert.ToBoolean(row["isDistributor"]);
                                isActive = Convert.ToBoolean(row["isActive"]);
                                userID = Convert.ToInt32(row["userID"]);
                            }
                            supClass.createUpdateSupplier("Supplier", "Update", txtSupCode.Text.Trim(), itemTax, payID, sGroupID, txtInfo.ToTitleCase(txtName.Text.Trim()), cmbType.Text, txtInfo.ToTitleCase(txtAgent.Text.Trim()), suppRID, isDistributor, isActive, userID);

                            MessageBox.Show("Successfully updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Supplier ID already exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            createUpdate();
        }


        
        private void clearPerson() {

            lblName.Text = "Name:";
            //txtFn.Clear();
            //txtMn.Clear();
            //txtLn.Clear();
            //txtSuffix.Clear();
            
        }
        private void hidePerson()
        {
            //txtFn.Hide();
            //txtMn.Hide();
            //txtLn.Hide();
            //txtSuffix.Hide();
            

            lblName.Text = "Name:";
            lblMn.Text = "";
            lblSuffix.Text = "";
            lblDob.Text = "";
            lblStatus.Text = "";
            lblGender.Text = "";
        }
        private void showPerson() {
            //txtFn.Show();
            //txtMn.Show();
            //txtLn.Show();
            //txtSuffix.Show();
            
            lblName.Text = "Firstname:";
            lblMn.Text = "Middlename:";
            lblSuffix.Text = "Suffix:";
            lblDob.Text = "Date Of Birth:";
            lblStatus.Text = "Marital Status:";
            lblGender.Text = "Gender:";
        }
        private void lblClosed_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void lblView_Click(object sender, EventArgs e)
        {
            //frmPersonInfo person = new frmPersonInfo();
            //person.ShowDialog();
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
           // this.Hide();
           // this.Close();
        }
        //private void recordType()
        //{
        //    DataGridViewComboBoxColumn _con = (DataGridViewComboBoxColumn)dgvCon.Columns["_Contact"];
        //    DataSet ds = supClass.showType();
        //    _con.DataSource = ds.Tables["tDesc"];
        //    _con.DisplayMember = "tDesc";
        //    _con.ValueMember = "typeID";
        //    // cbType.Text = Id.payId;
        //}

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Controls.RemoveByKey("RtypeError");
            cmbType.FlatStyle = FlatStyle.Standard;
        }

        int x, y;
        string pName;
        int w, h;
        int oW, oH;
        Panel p = new Panel();
        public void redBorder()
        {
            p.Name = pName;
            p.Size = new System.Drawing.Size(w, h);
            p.Location = new Point(x, y);
            p.BackColor = Color.Crimson;
            p.BorderStyle = System.Windows.Forms.BorderStyle.None;
            groupBox1.Controls.Add(p);
        }

        private void cmbType_Leave(object sender, EventArgs e)
        {
            if(cmbType.Text.Equals(""))
            {
                pName = "RtypeError";
                oW = cmbType.Size.Width;
                oH = cmbType.Size.Height;
                x = cmbType.Location.X - 2;
                y = cmbType.Location.Y -2;
                w = oW + 4;
                h = oH + 4;
                redBorder();
                cmbType.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                groupBox1.Controls.RemoveByKey("RtypeError");
                cmbType.FlatStyle = FlatStyle.Standard;
            }
        }

        private void cmbType_MouseHover(object sender, EventArgs e)
        {
            if(cmbType.FlatStyle == FlatStyle.Flat)
            {
                if(cmbType.Text.Equals(""))
                {
                    toolTip1.Show("Record type is required", cmbType);
                }
                else
                {
                    toolTip1.Hide(cmbType);
                }
            }
        }

        private void cmbGroup_Leave(object sender, EventArgs e)
        {
            if(cmbGroup.Text.Equals(""))
            {
                pName = "groupError";
                oW = cmbGroup.Size.Width;
                oH = cmbGroup.Size.Height;
                x = cmbGroup.Location.X - 2;
                y = cmbGroup.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                groupBox1.Controls.RemoveByKey("groupError");
                redBorder();
                cmbGroup.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                groupBox1.Controls.RemoveByKey("groupError");
                cmbGroup.FlatStyle = FlatStyle.Standard;
            }
        }

        private void cmbGroup_MouseHover(object sender, EventArgs e)
        {
            if(cmbGroup.FlatStyle == FlatStyle.Flat)
            {
                if(cmbGroup.Text.Equals(""))
                {
                    toolTip1.Show("Group is required", cmbGroup);
                }
                else
                {
                    toolTip1.Hide(cmbGroup);
                }
            }
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Controls.RemoveByKey("groupError");
            cmbGroup.FlatStyle = FlatStyle.Standard;
        }

        private void txtSupCode_Leave(object sender, EventArgs e)
        {
            if (Id.button.Equals("Create"))
            {
                if (txtSupCode.Text.Equals(""))
                {
                    pName = "suppCodeError";
                    oW = txtSupCode.Size.Width;
                    oH = txtSupCode.Size.Height;
                    x = txtSupCode.Location.X - 2;
                    y = txtSupCode.Location.Y - 2;
                    w = oW + 4;
                    h = oH + 4;
                    groupBox1.Controls.RemoveByKey("suppCodeError");
                    redBorder();
                    //txtSupCode.BorderStyle = BorderStyle.None;
                    //txtSupCode.Size = new System.Drawing.Size(oW, oH);
                    //label3.Text = oH.ToString();
                }
                else if (!db.suppliers.Any(a => a.suppID == txtSupCode.Text))
                {
                    groupBox1.Controls.RemoveByKey("suppCodeError");
                    //txtSupCode.BorderStyle = BorderStyle.Fixed3D;
                    //label6.Text = oH.ToString();
                }
                else
                {
                    pName = "suppCodeError";
                    oW = txtSupCode.Size.Width;
                    oH = txtSupCode.Size.Height;
                    x = txtSupCode.Location.X - 2;
                    y = txtSupCode.Location.Y - 2;
                    w = oW + 4;
                    h = oH + 4;
                    groupBox1.Controls.RemoveByKey("suppCodeError");
                    redBorder();
                    //txtSupCode.BorderStyle = BorderStyle.None;
                    //txtSupCode.Size = new System.Drawing.Size(oW, oH);
                }
            }
            else if(Id.button.Equals("Update"))
            {
                var objExcept = db.suppliers.Where(a => a.suppID.Equals(Id.suppID));
                var objExist = db.suppliers.Where(a => a.suppID.Equals(txtSupCode.Text)).Except(objExcept);
                if(objExist.Any())
                {
                    pName = "suppCodeError";
                    oW = txtSupCode.Size.Width;
                    oH = txtSupCode.Size.Height;
                    x = txtSupCode.Location.X - 2;
                    y = txtSupCode.Location.Y - 2;
                    w = oW + 4;
                    h = oH + 4;
                    groupBox1.Controls.RemoveByKey("suppCodeError");
                    redBorder();
                    //txtSupCode.BorderStyle = BorderStyle.None;
                    txtSupCode.Size = new System.Drawing.Size(oW, oH);
                   
                }
                else
                {
                    groupBox1.Controls.RemoveByKey("suppCodeError");
                    //txtSupCode.BorderStyle = BorderStyle.Fixed3D;
                }
            }
        }

        private void txtSupCode_MouseHover(object sender, EventArgs e)
        {
            var objExcept = db.suppliers.Where(a => a.suppID == Id.suppID);
            if (txtSupCode.Text.Equals(""))
            {
                toolTip1.Show("Supplier ID is required", txtSupCode);
            }
            else if (db.suppliers.Except(objExcept).Any(a => a.suppID == txtSupCode.Text))
            {
                toolTip1.Show("Supplier ID already in use", txtSupCode);
            }
            else
            {
                toolTip1.Hide(txtSupCode);
            }
        }

        private void txtSupCode_TextChanged(object sender, EventArgs e)
        {
            groupBox1.Controls.RemoveByKey("suppCodeError");
            //txtSupCode.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text))
            {
                pName = "nameError";
                oW = txtName.Size.Width;
                oH = txtName.Size.Height;
                x = txtName.Location.X - 2;
                y = txtName.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                groupBox1.Controls.RemoveByKey("nameError");
                redBorder();
            }
            else
            {
                DataTable dt = supClass.getSupplierById("supplierValidation", Id.suppID);
                foreach(DataRow row in dt.Rows)
                {
                    if(txtName.Text != row["name"].ToString())
                    {
                        groupBox1.Controls.RemoveByKey("nameError");
                    }
                    else
                    {
                        pName = "nameError";
                        oW = txtName.Size.Width;
                        oH = txtName.Size.Height;
                        x = txtName.Location.X - 2;
                        y = txtName.Location.Y - 2;
                        w = oW + 4;
                        h = oH + 4;
                        groupBox1.Controls.RemoveByKey("nameError");
                        redBorder();
                    }
                }
                
            }
            //if(txtName.Text.Equals(""))
            //{
            //    pName = "nameError";
            //    oW = txtName.Size.Width;
            //    oH = txtName.Size.Height;
            //    x = txtName.Location.X - 2;
            //    y = txtName.Location.Y - 2;
            //    w = oW + 4;
            //    h = oH + 4;
            //    groupBox1.Controls.RemoveByKey("nameError");
            //    redBorder();
            //    //txtName.BorderStyle = BorderStyle.None;
            //    //txtName.Multiline = true;
            //    //txtName.Size = new System.Drawing.Size(oW, oH);
            //}
            //else if(!db.suppliers.Any(a => a.name == txtName.Text))
            //{
            //    groupBox1.Controls.RemoveByKey("nameError");
            //    //txtName.Multiline = false;
            //    //txtName.BorderStyle = BorderStyle.Fixed3D;
            //}
            //else
            //{
            //    pName = "nameError";
            //    oW = txtName.Size.Width;
            //    oH = txtName.Size.Height;
            //    x = txtName.Location.X - 2;
            //    y = txtName.Location.Y - 2;
            //    w = oW + 4;
            //    h = oH + 4;
            //    groupBox1.Controls.RemoveByKey("nameError");
            //    redBorder();
            //    //txtName.BorderStyle = BorderStyle.None;
            //    //txtName.Multiline = true;
            //    //txtName.Size = new System.Drawing.Size(oW, oH);
            //}
        }

        private void txtName_MouseHover(object sender, EventArgs e)
        {
            if (txtName.Text.Equals(""))
            {
                toolTip1.Show("Name is required", txtName);
            }
            else
            {
                DataTable dt = supClass.getSupplierById("supplierValidation", Id.suppID);
                foreach(DataRow row in dt.Rows)
                {
                    if(txtName.Text != row["name"].ToString())
                    {
                        toolTip1.Hide(txtName);
                    }
                    else
                    {
                        toolTip1.Show("Name is already in use", txtName);
                    }
                }
            }
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            groupBox1.Controls.RemoveByKey("nameError");
            //txtName.Multiline = false;
            //txtName.BorderStyle = BorderStyle.Fixed3D;
        }

        public bool checkOpen(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach(Form frm in fc)
            {
                if(frm.Text == name)
                {
                    return true;
                }
                
            }
            return false;
        }

        private void btnAddPrincipal_Click(object sender, EventArgs e)
        {
            Id.param = "distriToPrincipal";
            if (Application.OpenForms.OfType<frmPrincipal>().Count() == 1)
                Application.OpenForms.OfType<frmPrincipal>().First().Close();

            frmPrincipal principal = new frmPrincipal(Program.CurrentUserId);
            principal.txtDistriName.BorderStyle = BorderStyle.Fixed3D;
            this.Hide();
            principal.ShowDialog();
           
            //Form frm = Application.OpenForms["frmPrincipal"];
            //frmPrincipal principal = new frmPrincipal();
            //if(checkOpen("frmPrincipal") == true)
            //{
            //    frm.Close();
            //    frm = null;
            //    principal.Show();
            //    principal.BringToFront();
            //}
            //else
            //{
            //    principal.Show();
            //    principal.BringToFront();
            //}
            //Form frm = Application.OpenForms[""];
            //Form frm = Application.OpenForms["frmPrincipal"];
            //frmPrincipal principal = new frmPrincipal();
            //if(frm != null)
            //{
            //    MessageBox.Show(frm.Name.ToString());
            //    //frm.Close();
            //    //principal.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show(frm.Name.ToString());
            //    //principal.ShowDialog();
            //}
            //this.Hide();
            //principal.ShowDialog();
        }

        private void lblNew_Click(object sender, EventArgs e)
        {
            Id.button = "Create";
            frmPaymentTerm pTerm = new frmPaymentTerm();
            pTerm.WindowState = FormWindowState.Normal;
            pTerm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            pTerm.StartPosition = FormStartPosition.CenterScreen;
            pTerm.btnCreate.Text = "Create";
            DialogResult res = pTerm.ShowDialog();
            if(res == DialogResult.OK)
            {
                showPayTerm();
            }
        }



        

        bool focus = false;

        private void cmbItemTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbPayTerms_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        
        private void lblNewSalesTax_Click(object sender, EventArgs e)
        {
            frmItemSalesTaxGroup itemSalesTax = new frmItemSalesTaxGroup();
            DialogResult res = itemSalesTax.ShowDialog();

            if(res == DialogResult.OK)
            {
                itemTax();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //private void txtSupCode_Enter(object sender, EventArgs e)
        //{
        //    focus = true;
        //    this.Refresh();
        //}

        //private void groupBox1_Paint(object sender, PaintEventArgs e)
        //{
        //    if (focus)
        //    {
        //        //txtSupCode.BorderStyle = BorderStyle.None;
        //        Pen p = new Pen(Color.Red);
        //        Graphics g = e.Graphics;
        //        int variance = 3;
        //        g.DrawRectangle(p, new Rectangle(txtSupCode.Location.X - variance, txtSupCode.Location.Y - variance, txtSupCode.Width + variance, txtSupCode.Height + variance));
        //    }
        //    else
        //    {
        //        //txtSupCode.BorderStyle = BorderStyle.FixedSingle;
        //    }
        //}


    }
}