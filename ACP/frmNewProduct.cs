﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACP
{
    public partial class frmNewProduct : Form
    {
        public frmNewProduct()
        {
            InitializeComponent();
        }

        private void btnNewBarcode_Click(object sender, EventArgs e)
        {
            frmProdDetails details = new frmProdDetails();
            details.ShowDialog();
        }
    }
}
