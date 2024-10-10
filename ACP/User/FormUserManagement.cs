using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACP.User;

namespace ACP.User
{
    public partial class FormUserManagement : Form
    {
        UserManager _userManager;
        public FormUserManagement()
        {
            InitializeComponent();
            _userManager = new UserManager();
        }

        private void RefreshUserList()
        {
            _userManager.PopulateUserDataGridView(dgvUsers);
        }

        private void FormUserManagement_Load(object sender, EventArgs e)
        {
            RefreshUserList();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            using (var userEntry = new FormUserEntry())
            {
                if (userEntry.ShowDialog() == DialogResult.OK)
                {
                    RefreshUserList();
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                UserManager.User selectedUser = (UserManager.User)dgvUsers.SelectedRows[0].DataBoundItem;
                using (var userEntry = new FormUserEntry(selectedUser))
                {
                    if (userEntry.ShowDialog() == DialogResult.OK)
                    {
                        RefreshUserList();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to edit.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUserRole_Click(object sender, EventArgs e)
        {

        }

        private void btnRolePermissions_Click(object sender, EventArgs e)
        {
            using (var roleEntry = new FormRolePermissionEntry())
            {
                if (roleEntry.ShowDialog() == DialogResult.OK)
                {
                    RefreshUserList();
                }
            }
        }
    }
}
