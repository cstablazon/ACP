using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ACP
{
    class UserPermissionManager
    {
        private int _userId;

        public UserPermissionManager(int userId)
        {
            _userId = userId;
        }

        public bool CanOpenForm(string formName)
        {
            try
            {
                var permissions = GetUserPermissions();
                return permissions.Tables[1].AsEnumerable().Any(row =>
                    string.Equals(row.Field<string>("FormName"), formName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(row.Field<string>("PermissionName"), "Read", StringComparison.OrdinalIgnoreCase));
            }
            catch (SqlException ex)
            {
                DisplaySqlError(ex);
                return false;
            }
        }

        public bool CanPerformOperation(string formName, string operation)
        {
            try
            {
                var permissions = GetUserPermissions();
                return permissions.Tables[1].AsEnumerable().Any(row =>
                    string.Equals(row.Field<string>("FormName"), formName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(row.Field<string>("PermissionName"), operation, StringComparison.OrdinalIgnoreCase));
            }
            catch (SqlException ex)
            {
                DisplaySqlError(ex);
                return false;
            }
        }

        private DataSet GetUserPermissions()
        {
            var parameters = new Dictionary<string, object>
            {
                {"@UserID", _userId}
            };

            return DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_GetUserPermissions", parameters);
        }

        public string GetUserFullName()
        {
            var userDetails = GetUserPermissions().Tables[0];
            if (userDetails.Rows.Count > 0)
            {
                return userDetails.Rows[0].Field<string>("FullName");
            }
            return string.Empty;
        }

        public string GetUserRole()
        {
            var userDetails = GetUserPermissions().Tables[0];
            if (userDetails.Rows.Count > 0)
            {
                return userDetails.Rows[0].Field<string>("RoleName");
            }
            return string.Empty;
        }

        private static void DisplaySqlError(SqlException ex)
        {
            string errorMessage = ex.Message;
            if (ex.Number == 50000) // Custom error number for RAISERROR
            {
                errorMessage = ex.Message.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
            MessageBox.Show(errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
