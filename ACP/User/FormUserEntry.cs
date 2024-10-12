using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            txtConfirmPassword.Text = string.Empty;
        }

        private bool ValidateForm()
        {
            // Username validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowError("Username is required.");
                return false;
            }

            // First name validation
            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                ShowError("First name is required.");
                return false;
            }

            // Last name validation
            if (string.IsNullOrWhiteSpace(txtLastname.Text))
            {
                ShowError("Last name is required.");
                return false;
            }

            // Email validation
            if (!IsValidEmail(txtEmail.Text))
            {
                ShowError("Invalid email address.");
                return false;
            }

            // Phone number validation
            if (!IsValidPhoneNumber(txtPhone.Text))
            {
                ShowError("Invalid phone number.");
                return false;
            }

            // Role validation
            if (cmbRole.SelectedItem == null)
            {
                ShowError("Please select a role.");
                return false;
            }

            // Password validation
            if (!_isEditMode || !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (!IsValidPassword(txtPassword.Text))
                {
                    ShowError("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");
                    return false;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    ShowError("Passwords do not match.");
                    return false;
                }
            }

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
        }

        private bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
        }

        private void CreateUser()
        {
            if (!ValidateForm()) return;

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
            if (!ValidateForm()) return;

            _currentUser.Username = txtUsername.Text;
            _currentUser.IsActive = cbActive.Checked;
            _currentUser.FirstName = txtFirstname.Text;
            _currentUser.LastName = txtLastname.Text;
            _currentUser.Email = txtEmail.Text;
            _currentUser.PhoneNumber = txtPhone.Text;
            _currentUser.RoleName = ((UserManager.Role)cmbRole.SelectedItem).RoleName;

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
