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
        private UserManager _userManager = new UserManager();
        private UserManager.User _currentUser;
        private bool _isEditMode = false;

        public FormUserEntry(UserManager.User user = null)
        {
            InitializeComponent();
            if (user != null)
            {
                _currentUser = user;
                _isEditMode = true;
            }
        }

        private void FormUserEntry_Load(object sender, EventArgs e)
        {
            _userManager.PopulateRolesComboBox(cmbRole);
            if (_isEditMode)
            {
                PopulateUserData();
                this.Text = "Edit User";
                btnSave.Text = "Update";
            }
            else
            {
                this.Text = "Create New User";
                btnSave.Text = "Create";
            }
        }

        private void PopulateUserData()
        {
            txtUsername.Text = _currentUser.Username;
            cbActive.Checked = _currentUser.IsActive;
            txtFirstname.Text = _currentUser.FirstName;
            txtLastname.Text = _currentUser.LastName;
            txtEmail.Text = _currentUser.Email;
            txtPhone.Text = _currentUser.PhoneNumber;
            cmbRole.SelectedItem = cmbRole.Items.Cast<UserManager.Role>().FirstOrDefault(r => r.RoleName == _currentUser.RoleName);
            txtPassword.Text = string.Empty; // For security reasons, don't populate the password field
        }

        private void CreateUser()
        {
            UserManager.User newUser = new UserManager.User
            {
                Username = txtUsername.Text,
                IsActive = cbActive.Checked,
                FirstName = txtFirstname.Text,
                LastName = txtLastname.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhone.Text,
                RoleName = ((UserManager.Role)cmbRole.SelectedItem).RoleName,
                Password = txtPassword.Text
            };

            bool created = _userManager.CreateUser(newUser);
            MessageBox.Show(created ? "User created successfully!" : "Failed to create user!", "Message Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (created) this.DialogResult = DialogResult.OK;
        }

        private void UpdateUser()
        {
            _currentUser.Username = txtUsername.Text;
            _currentUser.IsActive = cbActive.Checked;
            _currentUser.FirstName = txtFirstname.Text;
            _currentUser.LastName = txtLastname.Text;
            _currentUser.Email = txtEmail.Text;
            _currentUser.PhoneNumber = txtPhone.Text;
            _currentUser.RoleName = ((UserManager.Role)cmbRole.SelectedItem).RoleName;

            // Only update password if a new one is provided
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                _currentUser.Password = txtPassword.Text;
            }

            bool updated = _userManager.UpdateUser(_currentUser);
            MessageBox.Show(updated ? "User updated successfully!" : "Failed to update user!", "Message Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (updated) this.DialogResult = DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                UpdateUser();
            }
            else
            {
                CreateUser();
            }
        }
    }
}
