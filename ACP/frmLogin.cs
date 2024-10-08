using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ACP
{
    public partial class frmLogin : Form
    {
        acpEntities db = new acpEntities();
        loginClass login = new loginClass();
        public frmLogin()
        {
            InitializeComponent();
        }

        public void authenticateUser()
        {
            if(string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
            }
            else if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
            }
            else
            {
                DataTable dt = login.authenticateUser(txtUsername.Text, txtPassword.Text);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (Convert.ToInt32(row["authID"]) == 1 || Convert.ToInt32(row["authID"]) == 2 || Convert.ToInt32(row["authID"]) == 3)
                        {
                            Program.CurrentUserId = Convert.ToInt32(row["userID"]);
                            frMain main = new frMain(Convert.ToInt32(row["userID"]));
                            main.Show();
                            this.Hide();
                        }
                        else
                        {

                        }
                    }
                }
            }
            //var sqlQuery = db.user_tbl.SqlQuery("OPEN SYMMETRIC KEY encryptUserPass DECRYPTION BY PASSWORD = 'inh0used3v'; SELECT userID, username, pass = CAST(DECRYPTBYKEY(pass) AS nvarchar), authID, RID, isActive, timestamp, transDate FROM user_tbl WHERE username = @username AND CAST(DECRYPTBYKEY(pass) AS nvarchar) = @pass", new System.Data.SqlClient.SqlParameter("@username", txtUsername.Text), new System.Data.SqlClient.SqlParameter("@pass", txtPassword.Text)).ToList();
            
            //if(sqlQuery.Any())
            //{
            //    Id.RID = sqlQuery.FirstOrDefault().RID;
            //    string authority = sqlQuery.FirstOrDefault().authID;
            //    if (Convert.ToInt32(authority).Equals(1))
            //    {
            //        frMain main = new frMain();
            //        main.Show();
            //        this.Hide();
            //    }
            //    else
            //    {

            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Invalid account, please contact your administrator", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //label1.Text = Id.percent.ToString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            authenticateUser();
        }

        string pName;
        int x, y; 
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
            Controls.Add(p);
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if(txtUsername.Text.Equals(""))
            {
                pName = "uNameError";
                oW = txtUsername.Size.Width;
                oH = txtUsername.Size.Height;
                x = txtUsername.Location.X - 2;
                y = txtUsername.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                Controls.RemoveByKey("uNameError");
                redBorder();
                //txtUsername.BorderStyle = BorderStyle.None;
                //txtUsername.Multiline = true;
                txtUsername.Size = new System.Drawing.Size(oW, oH);
            }
            else
            {
                Controls.RemoveByKey("uNameError");
                //txtUsername.Multiline = false;
                //txtUsername.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void txtUsername_MouseHover(object sender, EventArgs e)
        {
            if(txtUsername.BorderStyle == BorderStyle.None)
            {
                if(txtUsername.Text.Equals(""))
                {
                    toolTip1.Show("Username is required", txtUsername);
                }
                else
                {
                    toolTip1.Hide(txtUsername);
                }
            }

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            Controls.RemoveByKey("uNameError");
            //txtUsername.Multiline = false;
            //txtUsername.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if(txtPassword.Text.Equals(""))
            {
                pName = "passError";
                oW = txtPassword.Size.Width;
                oH = txtPassword.Size.Height;
                x = txtPassword.Location.X - 2;
                y = txtPassword.Location.Y - 2;
                w = oW + 4;
                h = oH + 4;
                Controls.RemoveByKey("passError");
                redBorder();
               // txtPassword.BorderStyle = BorderStyle.None;
                //txtPassword.Multiline = true;
                txtPassword.Size = new System.Drawing.Size(oW, oH);
            }
            else
            {
                Controls.RemoveByKey("passError");
                //txtPassword.Multiline = false;
                //txtPassword.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            if(txtPassword.BorderStyle == BorderStyle.None)
            {
                if(txtPassword.Text.Equals(""))
                {
                    toolTip1.Show("Password is required", txtPassword);
                }
                else
                {
                    toolTip1.Hide(txtPassword);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Exit application?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if(res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Exit application?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtUsername.Text) && string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Fill up necessary information", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    authenticateUser();
                }
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            Controls.RemoveByKey("passError");
            txtPassword.Multiline = false;
            txtPassword.BorderStyle = BorderStyle.Fixed3D;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productCreation pc = new productCreation();
            int num = pc.autoInc("SKU", "product");
            string tempNum = string.Format("{0:0000000}", num);
            MessageBox.Show(tempNum);
        }
    }
}
