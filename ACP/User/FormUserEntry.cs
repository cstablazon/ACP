using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACP.User
{
    public partial class FormUserEntry : Form
    {
        UserManager _userManager = new UserManager();
        public FormUserEntry()
        {
            InitializeComponent();
        }

        private void FormUserEntry_Load(object sender, EventArgs e)
        {
            _userManager.PopulateRolesComboBox(cmbRole);
        }

        public void CreateUser()
        {
            UserManager.User newUser = new UserManager.User
            {
                Username = txtUsername.Text,
                IsActive = cbActive.Checked,
                FirstName = txtFirstname.Text,
                LastName = txtLastname.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhone.Text,
                RoleName = cmbRole.SelectedText,
                Password = txtPassword.Text
            };
            bool created = _userManager.CreateUser(newUser);
            MessageBox.Show(created ? "User created successfully!" : "Failed to create user!", "Message Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CreateUser();
        }
    }
}
