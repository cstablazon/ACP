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
    class RolePermissionManager
    {
        public class RolePermission
        {
            public int RolePermissionID { get; set; }
            public string RoleName { get; set; }
            public string PermissionName { get; set; }
            public string FormName { get; set; }
            public string RoleDescription { get; set; }
            public string PermissionDescription { get; set; }
            public string FormDescription { get; set; }
            public int RoleID { get; set; }
            public int PermissionID { get; set; }
            public int FormID { get; set; }
        }

        public int CreateRolePermission(int roleID, int permissionID, int formID)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "Create"},
                {"@RoleID", roleID},
                {"@PermissionID", permissionID},
                {"@FormID", formID}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRolePermission", parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["RolePermissionID"]);
            }

            return -1; // Indicates failure
        }

        public List<RolePermission> GetAllRolePermissions()
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "Read"}
            };

            return GetRolePermissionsFromDataSet(DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRolePermission", parameters));
        }

        public RolePermission GetRolePermissionByID(int rolePermissionID)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "ReadByID"},
                {"@RolePermissionID", rolePermissionID}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRolePermission", parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return CreateRolePermissionFromDataRow(ds.Tables[0].Rows[0]);
            }

            return null;
        }

        public bool UpdateRolePermission(int rolePermissionID, int roleID, int permissionID, int formID)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "Update"},
                {"@RolePermissionID", rolePermissionID},
                {"@RoleID", roleID},
                {"@PermissionID", permissionID},
                {"@FormID", formID}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRolePermission", parameters);

            return ds.Tables[0].Rows.Count > 0;
        }

        public bool DeleteRolePermission(int rolePermissionID)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "Delete"},
                {"@RolePermissionID", rolePermissionID}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRolePermission", parameters);

            return ds.Tables[0].Rows.Count > 0;
        }

        //public List<RolePermission> GetRolePermissionsByRoleID(int roleID)
        //{
        //    var parameters = new Dictionary<string, object>
        //    {
        //        {"@Action", "ReadByRoleID"},
        //        {"@RoleID", roleID}
        //    };

        //    return GetRolePermissionsFromDataSet(DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRolePermission", parameters));
        //}

        public List<RolePermission> GetRolePermissionsByPermissionID(int permissionID)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "ReadByPermissionID"},
                {"@PermissionID", permissionID}
            };

            return GetRolePermissionsFromDataSet(DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRolePermission", parameters));
        }

        public List<RolePermission> GetRolePermissionsByFormID(int formID)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "ReadByFormID"},
                {"@FormID", formID}
            };

            return GetRolePermissionsFromDataSet(DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRolePermission", parameters));
        }

        public List<RolePermission> GetRolePermissionsByRoleID(int roleID)
        {
            var parameters = new Dictionary<string, object>
    {
        {"@Action", "ReadByRoleID"},
        {"@RoleID", roleID}
    };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageRolePermission", parameters);

            List<RolePermission> rolePermissions = new List<RolePermission>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    rolePermissions.Add(new RolePermission
                    {
                        RolePermissionID = Convert.ToInt32(row["RolePermissionID"]),
                        RoleName = row["RoleName"].ToString(),
                        PermissionName = row["PermissionName"].ToString(),
                        FormName = row["FormName"].ToString(),
                        RoleDescription = row["RoleDescription"].ToString(),
                        PermissionDescription = row["PermissionDescription"].ToString(),
                        FormDescription = row["FormDescription"].ToString(),
                        RoleID = roleID,
                        PermissionID = Convert.ToInt32(row["PermissionID"]),
                        FormID = Convert.ToInt32(row["FormID"])
                    });
                }
            }

            System.Diagnostics.Debug.WriteLine(string.Format("Retrieved {0} role permissions for role ID: {1}", rolePermissions.Count, roleID));
            return rolePermissions;
        }

        private List<RolePermission> GetRolePermissionsFromDataSet(DataSet ds)
        {
            List<RolePermission> rolePermissions = new List<RolePermission>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                rolePermissions.Add(CreateRolePermissionFromDataRow(row));
            }

            return rolePermissions;
        }

        private RolePermission CreateRolePermissionFromDataRow(DataRow row)
        {
            return new RolePermission
            {
                RolePermissionID = GetValueOrDefault<int>(row, "RolePermissionID"),
                RoleName = GetValueOrDefault<string>(row, "RoleName"),
                PermissionName = GetValueOrDefault<string>(row, "PermissionName"),
                FormName = GetValueOrDefault<string>(row, "FormName"),
                RoleDescription = GetValueOrDefault<string>(row, "RoleDescription"),
                PermissionDescription = GetValueOrDefault<string>(row, "PermissionDescription"),
                FormDescription = GetValueOrDefault<string>(row, "FormDescription"),
                RoleID = GetValueOrDefault<int>(row, "RoleID"),
                PermissionID = GetValueOrDefault<int>(row, "PermissionID"),
                FormID = GetValueOrDefault<int>(row, "FormID")
            };
        }

        private T GetValueOrDefault<T>(DataRow row, string columnName)
        {
            if (row.Table.Columns.Contains(columnName) && !row.IsNull(columnName))
            {
                return (T)Convert.ChangeType(row[columnName], typeof(T));
            }
            return default(T);
        }

        public void PopulateRolePermissionDataGridView(DataGridView dataGridView)
        {
            List<RolePermission> rolePermissions = GetAllRolePermissions();

            dataGridView.DataSource = null;
            dataGridView.DataSource = rolePermissions;

            // Customize the columns
            dataGridView.Columns["RolePermissionID"].Visible = false;
            dataGridView.Columns["RoleID"].Visible = false;
            dataGridView.Columns["PermissionID"].Visible = false;
            dataGridView.Columns["FormID"].Visible = false;
            dataGridView.Columns["RoleName"].HeaderText = "Role";
            dataGridView.Columns["PermissionName"].HeaderText = "Permission";
            dataGridView.Columns["FormName"].HeaderText = "Form";
            dataGridView.Columns["RoleDescription"].HeaderText = "Role Description";
            dataGridView.Columns["PermissionDescription"].HeaderText = "Permission Description";
            dataGridView.Columns["FormDescription"].HeaderText = "Form Description";

            // AutoSize the columns for better appearance
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
