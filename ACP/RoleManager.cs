using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace ACP
{
    class RoleManager
    {
        public class Role
        {
            public int RoleID { get; set; }
            public string RoleName { get; set; }
            public string Description { get; set; }
        }

        public Role GetRole(int roleID)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "ReadByID"},
                {"@RoleID", roleID}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRoles", parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                return new Role
                {
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString(),
                    Description = row["Description"].ToString()
                };
            }

            return null;
        }

        public int CreateRole(Role role)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "Create"},
                {"@RoleName", role.RoleName},
                {"@Description", role.Description}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRoles", parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["RoleID"]);
            }

            return -1; // Indicates failure
        }

        public bool UpdateRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            var parameters = new Dictionary<string, object>
            {
                {"@Action", "Update"},
                {"@RoleID", role.RoleID},
                {"@RoleName", role.RoleName},
                {"@Description", role.Description}
            };

            try
            {
                DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRoles", parameters);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToBoolean(ds.Tables[0].Rows[0]["Success"]);
                }

                return false;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine("Error updating role: " + ex.Message);
                return false;
            }
        }

        public bool DeleteRole(int roleID)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "Delete"},
                {"@RoleID", roleID}
            };

            try
            {
                DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRoles", parameters);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToBoolean(ds.Tables[0].Rows[0]["Success"]);
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting role: " + ex.Message);
                return false;
            }
        }

        public List<Role> GetAllRoles()
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "Read"}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRoles", parameters);

            List<Role> roles = new List<Role>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                roles.Add(new Role
                {
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString(),
                    Description = row["Description"].ToString()
                });
            }

            return roles;
        }

        public Role GetRoleByName(string roleName)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "ReadByName"},
                {"@RoleName", roleName}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRoles", parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                return new Role
                {
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString(),
                    Description = row["Description"].ToString()
                };
            }

            return null;
        }

        public bool RoleExists(string roleName)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "ReadByName"},
                {"@RoleName", roleName}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRoles", parameters);

            return ds.Tables[0].Rows.Count > 0;
        }

        public List<Role> SearchRolesByDescription(string description)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "ReadByDescription"},
                {"@Description", description}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRoles", parameters);

            List<Role> roles = new List<Role>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                roles.Add(new Role
                {
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString(),
                    Description = row["Description"].ToString()
                });
            }

            return roles;
        }

        public void PopulateRoleDataGridView(DataGridView dataGridView)
        {
            List<Role> roles = GetAllRoles();

            // Store the current position of the delete column
            int deleteColumnIndex = -1;
            DataGridViewColumn deleteColumn = null;
            if (dataGridView.Columns["DeleteColumn"] != null)
            {
                deleteColumnIndex = dataGridView.Columns["DeleteColumn"].Index;
                deleteColumn = dataGridView.Columns["DeleteColumn"];
                dataGridView.Columns.Remove("DeleteColumn");
            }

            dataGridView.DataSource = null;
            dataGridView.DataSource = roles;

            // Customize the columns
            dataGridView.Columns["RoleID"].Visible = false;
            dataGridView.Columns["RoleName"].HeaderText = "Role Name";
            dataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Re-add or add the delete button column
            if (deleteColumn == null)
            {
                deleteColumn = new DataGridViewLinkColumn
                {
                    Name = "DeleteColumn",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForLinkValue = true
                };
            }

            // Always add the delete column at the end
            dataGridView.Columns.Add(deleteColumn);

            // AutoSize the columns for better appearance
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        public void PopulateRolesComboBox(ComboBox comboBox)
        {
            List<Role> roles = GetAllRoles();

            comboBox.DataSource = roles;
            comboBox.DisplayMember = "RoleName";
            comboBox.ValueMember = "RoleID";
        }
    }
}
