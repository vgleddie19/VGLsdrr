using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewSDRR
{
    public partial class NewReasonForm : Form
    {
        public NewReasonForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.sdrr1_TN8_2;
        }

        public bool save()
        {
            try
            {
                if (txtreason.Text.Trim().Length <= 0)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Empty reason!");
                    txtreason .Focus();
                    return false;
                }
                Utils.ExecuteNonQuery("INSERT INTO base_reason(reason) values('" + txtreason.Text.ToUpper() + "')", null);
                return false;
            }
            catch (Exception ex)
            { DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message); return false; }

        }

        private void btnreason_Click(object sender, EventArgs e)
        {
            if(save())
                this.Close();
        }
    }
}
