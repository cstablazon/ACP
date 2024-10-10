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

        private void FormUserManagement_Load(object sender, EventArgs e)
        {
            _userManager.PopulateUserDataGridView(dgvUsers);
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            FormUserEntry _userEntry = new FormUserEntry();
            _userEntry.ShowDialog();
        }
    }
}
