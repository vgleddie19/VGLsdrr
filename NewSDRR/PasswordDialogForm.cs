using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NewSDRR
{
    public partial class PasswordDialogForm : Form
    {

        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public PasswordDialogForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Settings;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            password = txtPassword.Text;
            this.Close();
        }
    }
}
