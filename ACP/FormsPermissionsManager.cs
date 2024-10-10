using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACP
{
    class FormsPermissionsManager
    {
        private RolePermissionManager _rolePermissionManager = new RolePermissionManager();

        public DataTable GetAllForms()
        {
            return DatabaseHelper.GetRecords("sp_ManageForms", "Read");
        }

        public DataTable GetAllPermissions()
        {
            return DatabaseHelper.GetRecords("sp_ManagePermissions", "Read");
        }

        public void PopulateTreeView(TreeView treeView, int? roleId = null)
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();

            DataTable forms = GetAllForms();
            DataTable permissions = GetAllPermissions();
            List<RolePermissionManager.RolePermission> rolePermissions =
                roleId.HasValue ? _rolePermissionManager.GetRolePermissionsByRoleID(roleId.Value) : new List<RolePermissionManager.RolePermission>();

            System.Diagnostics.Debug.WriteLine(string.Format("Retrieved {0} role permissions for role ID: {1}", rolePermissions.Count, roleId));

            foreach (DataRow formRow in forms.Rows)
            {
                int formId = Convert.ToInt32(formRow["FormID"]);
                string formName = formRow["FormName"].ToString();
                TreeNode formNode = new TreeNode
                {
                    Text = formName,
                    Tag = new NodeTag { Id = formId, Type = NodeType.Form }
                };

                bool allPermissionsChecked = true;

                foreach (DataRow permissionRow in permissions.Rows)
                {
                    int permissionId = Convert.ToInt32(permissionRow["PermissionID"]);
                    string permissionName = permissionRow["PermissionName"].ToString();
                    TreeNode permissionNode = new TreeNode
                    {
                        Text = permissionName,
                        Tag = new NodeTag { Id = permissionId, Type = NodeType.Permission }
                    };

                    bool isChecked = rolePermissions.Any(rp =>
                        rp.FormID == formId &&
                        rp.PermissionID == permissionId);

                    permissionNode.Checked = isChecked;
                    allPermissionsChecked = allPermissionsChecked && isChecked;

                    System.Diagnostics.Debug.WriteLine(string.Format("Form: {0}, Permission: {1}, Checked: {2}", formName, permissionName, isChecked));

                    formNode.Nodes.Add(permissionNode);
                }

                formNode.Checked = allPermissionsChecked;
                treeView.Nodes.Add(formNode);
            }

            treeView.ExpandAll();
            treeView.EndUpdate();

            System.Diagnostics.Debug.WriteLine(string.Format("Total nodes added to TreeView: {0}", treeView.GetNodeCount(true)));
            System.Diagnostics.Debug.WriteLine(string.Format("Number of checked nodes: {0}", CountCheckedNodes(treeView.Nodes)));
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

        public void SaveRolePermissions(int roleId, TreeView treeView)
        {
            List<RolePermissionManager.RolePermission> existingPermissions = _rolePermissionManager.GetRolePermissionsByRoleID(roleId);

            foreach (TreeNode formNode in treeView.Nodes)
            {
                int formId = ((NodeTag)formNode.Tag).Id;

                foreach (TreeNode permissionNode in formNode.Nodes)
                {
                    int permissionId = ((NodeTag)permissionNode.Tag).Id;
                    bool shouldExist = permissionNode.Checked;
                    bool doesExist = existingPermissions.Any(ep => ep.FormID == formId && ep.PermissionID == permissionId);

                    if (shouldExist && !doesExist)
                    {
                        _rolePermissionManager.CreateRolePermission(roleId, permissionId, formId);
                    }
                    else if (!shouldExist && doesExist)
                    {
                        var rolePermissionToDelete = existingPermissions.First(ep => ep.FormID == formId && ep.PermissionID == permissionId);
                        _rolePermissionManager.DeleteRolePermission(rolePermissionToDelete.RolePermissionID);
                    }
                }
            }
        }
    }

    public enum NodeType
    {
        Form,
        Permission
    }

    public class NodeTag
    {
        public int Id { get; set; }
        public NodeType Type { get; set; }
    }
    
}
