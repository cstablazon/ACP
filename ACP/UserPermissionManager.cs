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

        public static UserLoginResult Login(string username, string password)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    {"@Action", "LOGIN"},
                    {"@Username", username},
                    {"@Password", password}
                };

                var result = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageUser", parameters);

                if (result.Tables[0].Rows.Count > 0)
                {
                    var row = result.Tables[0].Rows[0];
                    return new UserLoginResult
                    {
                        Success = true,
                        UserId = Convert.ToInt32(row["userID"]),
                        Username = row["username"].ToString(),
                        AuthId = row["authID"].ToString(),
                        AuthDesc = row["authDesc"].ToString(),
                        RID = row["RID"].ToString(),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        IsActive = Convert.ToBoolean(row["isActive"]),
                        TransDate = Convert.ToDateTime(row["transDate"]),
                        RoleName = row["RoleName"].ToString()
                    };
                }
                else
                {
                    return new UserLoginResult { Success = false, ErrorMessage = "Invalid username or password." };
                }
            }
            catch (SqlException ex)
            {
                DisplaySqlError(ex);
                return new UserLoginResult { Success = false, ErrorMessage = "An error occurred during login." };
            }
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

    public class UserLoginResult
    {
        public bool Success { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string AuthId { get; set; }
        public string AuthDesc { get; set; }
        public string RID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime TransDate { get; set; }
        public string RoleName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
