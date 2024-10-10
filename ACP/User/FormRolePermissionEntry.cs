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
    public partial class FormRolePermissionEntry : Form
    {
        private FormsPermissionsManager _manager = new FormsPermissionsManager();
        private RoleManager _role = new RoleManager();
        private int? _selectedRoleId = null;

        public FormRolePermissionEntry()
        {
            InitializeComponent();
        }

        private void FormRolePermissionEntry_Load(object sender, EventArgs e)
        {
            _role.PopulateRoleDataGridView(dgvUsers);
            tvFormPermissions.CheckBoxes = true;

            // Select the first row in the DataGridView if there are any rows
            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Rows[0].Selected = true;
                _selectedRoleId = Convert.ToInt32(dgvUsers.Rows[0].Cells["RoleID"].Value);
                string roleName = dgvUsers.Rows[0].Cells["RoleName"].Value.ToString();
                System.Diagnostics.Debug.WriteLine(string.Format("Initially Selected Role ID: {0}, Role Name: {1}", _selectedRoleId, roleName));
            }
            else
            {
                _selectedRoleId = null;
                System.Diagnostics.Debug.WriteLine("No roles available");
            }

            // Populate the TreeView with the initially selected role (or null if no roles)
            _manager.PopulateTreeView(tvFormPermissions, _selectedRoleId);

            // Ensure the TreeView is refreshed
            tvFormPermissions.Refresh();

            // Debug: Output the number of checked nodes after populating
            System.Diagnostics.Debug.WriteLine(string.Format("Number of checked nodes on load: {0}", CountCheckedNodes(tvFormPermissions.Nodes)));

            // Add event handlers
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            tvFormPermissions.AfterCheck += tvFormPermissions_AfterCheck;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedRoleId.HasValue)
            {
                _manager.SaveRolePermissions(_selectedRoleId.Value, tvFormPermissions);
                MessageBox.Show("Role permissions have been saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Refresh the treeview to reflect the saved changes
                _manager.PopulateTreeView(tvFormPermissions, _selectedRoleId);
            }
            else
            {
                MessageBox.Show("Please select a role before saving permissions.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                _selectedRoleId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["RoleID"].Value);
                string roleName = dgvUsers.SelectedRows[0].Cells["RoleName"].Value.ToString();
                System.Diagnostics.Debug.WriteLine(string.Format("Selected Role ID: {0}, Role Name: {1}", _selectedRoleId, roleName));

                _manager.PopulateTreeView(tvFormPermissions, _selectedRoleId);
            }
            else
            {
                _selectedRoleId = null;
                System.Diagnostics.Debug.WriteLine("No role selected");
                _manager.PopulateTreeView(tvFormPermissions);
            }

            // Ensure the TreeView is refreshed
            tvFormPermissions.Refresh();

            // Debug: Output the number of checked nodes after populating
            System.Diagnostics.Debug.WriteLine(string.Format("Number of checked nodes: {0}", CountCheckedNodes(tvFormPermissions.Nodes)));
        }

        private int CountCheckedNodes(TreeNodeCollection nodes)
        {
            int count = 0;
            foreach (TreeNode node in nodes)
            {
                if (node.Checked) count++;
                count += CountCheckedNodes(node.Nodes);
            }
            return count;
        }

        private void tvFormPermissions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Prevent infinite recursion
            if (e.Action != TreeViewAction.Unknown)
            {
                if (((NodeTag)e.Node.Tag).Type == NodeType.Form)
                {
                    foreach (TreeNode child in e.Node.Nodes)
                    {
                        child.Checked = e.Node.Checked;
                    }
                }
                else
                {
                    // Update parent node
                    TreeNode parent = e.Node.Parent;
                    parent.Checked = parent.Nodes.Cast<TreeNode>().All(n => n.Checked);
                }
            }
        }
    }
}
