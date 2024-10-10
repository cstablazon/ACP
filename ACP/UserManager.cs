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
    public class UserManager
    {
        public class User
        {
            public int UserID { get; set; }
            public string AuthID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string RID { get; set; }
            public bool IsActive { get; set; }
            public DateTime TransDate { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string RoleName { get; set; }
        }

        public class Role
        {
            public int RoleID { get; set; }
            public string RoleName { get; set; }
            public string Description { get; set; }
        }

        public User GetUser(int userID)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "READBYID"},
                {"@UserID", userID}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageUser", parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                return new User
                {
                    UserID = Convert.ToInt32(row["userID"]),
                    AuthID = row["authID"].ToString(),
                    Username = row["username"].ToString(),
                    RID = row["RID"].ToString(),
                    IsActive = Convert.ToBoolean(row["isActive"]),
                    TransDate = Convert.ToDateTime(row["transDate"]),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    RoleName = row["RoleName"].ToString()
                };
                
            }

            return null;
        }

        public bool CreateUser(User user)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "CREATE"},
                {"@AuthID", user.AuthID},
                {"@Username", user.Username},
                {"@Password", user.Password},
                {"@RID", user.RID},
                {"@IsActive", user.IsActive},
                {"@FirstName", user.FirstName},
                {"@LastName", user.LastName},
                {"@Email", user.Email},
                {"@PhoneNumber", user.PhoneNumber},
                {"@RoleName", user.RoleName}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageUser", parameters);

            return ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Message"].ToString().Contains("successfully");
        }

        public bool UpdateUser(User user)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "UPDATE"},
                {"@UserID", user.UserID},
                {"@Username", user.Username},
                {"@Password", user.Password},
                {"@RID", user.RID},
                {"@IsActive", user.IsActive},
                {"@TransDate", user.TransDate},
                {"@FirstName", user.FirstName},
                {"@LastName", user.LastName},
                {"@Email", user.Email},
                {"@PhoneNumber", user.PhoneNumber},
                {"@RoleName", user.RoleName}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageUser", parameters);

            return ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Message"].ToString().Contains("successfully");
        }

        public bool DeleteUser(int userID)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "DELETE"},
                {"@UserID", userID}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageUser", parameters);

            return ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["Message"].ToString().Contains("successfully");
        }

        // New method for LOGIN action
        public User LoginUser(string username, string password)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "LOGIN"},
                {"@Username", username},
                {"@Password", password}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageUser", parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                return new User
                {
                    UserID = Convert.ToInt32(row["userID"]),
                    Username = row["username"].ToString(),
                    AuthID = row["authID"].ToString(),
                    RID = row["RID"].ToString(),
                    IsActive = Convert.ToBoolean(row["isActive"]),
                    TransDate = Convert.ToDateTime(row["transDate"]),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    RoleName = row["RoleName"].ToString()
                    // Note: Password is not included in the return object for security reasons
                };
            }

            return null;
        }

        // New method for READALL action
        public List<User> GetAllUsers()
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "READALL"}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageUser", parameters);

            List<User> users = new List<User>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                users.Add(new User
                {
                    UserID = Convert.ToInt32(row["userID"]),
                    AuthID = row["authID"].ToString(),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Email = row["Email"].ToString(),
                    Username = row["username"].ToString(),
                    RID = row["RID"].ToString(),
                    IsActive = Convert.ToBoolean(row["isActive"]),
                    TransDate = Convert.ToDateTime(row["transDate"]),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    RoleName = row["RoleName"].ToString()
                });
            }

            return users;
        }

        public void PopulateUserDataGridView(DataGridView dataGridView)
        {
            List<User> users = GetAllUsers();

            dataGridView.DataSource = null;
            dataGridView.DataSource = users;

            // Optionally, you can customize the columns
            dataGridView.Columns["Password"].Visible = false; // Hide the password column
            dataGridView.Columns["UserID"].Visible = false;
            dataGridView.Columns["AuthID"].Visible = false;
            dataGridView.Columns["RID"].Visible = false;
            dataGridView.Columns["email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns["FirstName"].HeaderText = "First Name";
            dataGridView.Columns["LastName"].HeaderText = "Last Name";
            dataGridView.Columns["RoleName"].HeaderText = "Role";

            // AutoSize the columns for better appearance
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        public List<Role> GetRoles()
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Action", "GETROLES"}
            };

            DataSet ds = DatabaseHelper.ExecuteStoredProcedureWithDataSet("sp_ManageUser", parameters);

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

        public void PopulateRolesComboBox(ComboBox comboBox)
        {
            List<Role> roles = GetRoles();

            comboBox.DataSource = roles;
            comboBox.DisplayMember = "RoleName";
            comboBox.ValueMember = "RoleID";
        }
    }
}
