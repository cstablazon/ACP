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
    public partial class FormRoleManagement : Form
    {
        private RoleManager roleManager;
        private bool isNewMode = false;
        private bool isEditMode = false;

        public FormRoleManagement()
        {
            InitializeComponent();
            roleManager = new RoleManager();
        }

        private void FormRoleManagement_Load(object sender, EventArgs e)
        {
            RefreshRoleList();
            SetControlState(false);

            // Add event handler for CellContentClick
            dgvRoles.CellContentClick += DgvRoles_CellContentClick;
        }

        private void DgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvRoles.Columns["DeleteColumn"].Index)
            {
                DataGridViewRow row = dgvRoles.Rows[e.RowIndex];
                RoleManager.Role role = row.DataBoundItem as RoleManager.Role;

                if (role != null)
                {
                    DialogResult result = MessageBox.Show(
                        "Are you sure you want to delete the role: " + role.RoleName + "?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (roleManager.DeleteRole(role.RoleID))
                        {
                            MessageBox.Show("Role deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshRoleList();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete role. It may be in use or an error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private void RefreshRoleList()
        {
            roleManager.PopulateRoleDataGridView(dgvRoles);
        }

        private void SetControlState(bool isEditing)
        {
            txtRole.Enabled = isEditing;
            txtDescription.Enabled = isEditing;
            btnNew.Text = isNewMode ? "Save" : "New";
            btnEdit.Text = isEditMode ? "Update" : "Edit";
            btnNew.Enabled = !isEditMode;
            btnEdit.Enabled = !isNewMode && dgvRoles.SelectedRows.Count > 0;
            btnCancel.Enabled = isEditing;
            dgvRoles.Enabled = !isEditing;
        }

        private void ClearInputs()
        {
            txtRole.Clear();
            txtDescription.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!isNewMode)
            {
                isNewMode = true;
                isEditMode = false;
                ClearInputs();
                SetControlState(true);
                txtRole.Focus();
            }
            else
            {
                if (ValidateInputs())
                {
                    CreateNewRole();
                    isNewMode = false;
                    SetControlState(false);
                    RefreshRoleList();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                if (dgvRoles.SelectedRows.Count > 0)
                {
                    isEditMode = true;
                    isNewMode = false;
                    SetControlState(true);
                    txtRole.Focus();
                }
            }
            else
            {
                if (ValidateInputs())
                {
                    UpdateExistingRole();
                    isEditMode = false;
                    SetControlState(false);
                    RefreshRoleList();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isNewMode = false;
            isEditMode = false;
            SetControlState(false);
            if (dgvRoles.SelectedRows.Count > 0)
            {
                DisplaySelectedRole();
            }
            else
            {
                ClearInputs();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtRole.Text))
            {
                ShowError("Role name is required.");
                txtRole.Focus();
                return false;
            }

            if (txtRole.Text.Length > 50) // Assuming a maximum length of 50 characters for role name
            {
                ShowError("Role name cannot exceed 50 characters.");
                txtRole.Focus();
                return false;
            }

            if (txtDescription.Text.Length > 255) // Assuming a maximum length of 255 characters for description
            {
                ShowError("Description cannot exceed 255 characters.");
                txtDescription.Focus();
                return false;
            }

            // Check for duplicate role name when creating a new role
            if (isNewMode && roleManager.RoleExists(txtRole.Text.Trim()))
            {
                ShowError("A role with this name already exists.");
                txtRole.Focus();
                return false;
            }

            // Check for duplicate role name when editing, excluding the current role
            if (isEditMode && dgvRoles.SelectedRows.Count > 0)
            {
                var selectedRole = (RoleManager.Role)dgvRoles.SelectedRows[0].DataBoundItem;
                if (txtRole.Text.Trim() != selectedRole.RoleName && roleManager.RoleExists(txtRole.Text.Trim()))
                {
                    ShowError("A role with this name already exists.");
                    txtRole.Focus();
                    return false;
                }
            }

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CreateNewRole()
        {
            var newRole = new RoleManager.Role
            {
                RoleName = txtRole.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            int newRoleId = roleManager.CreateRole(newRole);
            if (newRoleId != -1)
            {
                MessageBox.Show("New role created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowError("Failed to create new role. Please try again.");
            }
        }

        private void UpdateExistingRole()
        {
            if (dgvRoles.SelectedRows.Count > 0)
            {
                var selectedRole = (RoleManager.Role)dgvRoles.SelectedRows[0].DataBoundItem;
                selectedRole.RoleName = txtRole.Text.Trim();
                selectedRole.Description = txtDescription.Text.Trim();

                if (roleManager.UpdateRole(selectedRole))
                {
                    MessageBox.Show("Role updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ShowError("Failed to update role. Please try again.");
                }
            }
        }

        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dgvRoles.SelectedRows.Count > 0 && !isNewMode && !isEditMode;
            if (dgvRoles.SelectedRows.Count > 0 && !isNewMode && !isEditMode)
            {
                DisplaySelectedRole();
            }
            else if (!isNewMode && !isEditMode)
            {
                ClearInputs();
            }
        }

        private void DisplaySelectedRole()
        {
            if (dgvRoles.SelectedRows.Count > 0)
            {
                var selectedRole = (RoleManager.Role)dgvRoles.SelectedRows[0].DataBoundItem;
                txtRole.Text = selectedRole.RoleName;
                txtDescription.Text = selectedRole.Description;
            }
        }

    }
}
