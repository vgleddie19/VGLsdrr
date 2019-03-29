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
        public NewReasonForm(bool isreason)
        {           
            InitializeComponent();

            this.Icon = Properties.Resources.truck_icon;
            if (isreason)
                grpreason.Visible = true;
            else
                groupBox2.Visible = true;
        }

        public bool save()
        {
            try
            {
                if (txtreason.Text.Trim().Length <= 0)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Empty reason!");
                    txtreason.Focus();
                    return false;
                }
                if(Utils.ExecuteNonQuery("INSERT INTO base_reason(reason) values('" + txtreason.Text.ToUpper() + "')", null) >= 1)
                    return true;

                return false;
            }
            catch (Exception ex)
            { DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message); return false; }

        }

        public void AddNewDH()
        {
            try
            {
                Dictionary<String, Object> Param = new Dictionary<String, Object>();
                Param.Add("@position", cboPosition.Text);
                Param.Add("@name", fnameTxt.Text);
                Param.Add("@contactno", contactnoTxt.Text);

                Utils.ExecuteStoredProcedureNonQuery("[dbo].[sp_BASE_AddNewDH]", Param);
                DevComponents.DotNetBar.MessageBoxEx.Show("Saving Complete");
                this.Close();

            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            }
        }

        private void btnreason_Click(object sender, EventArgs e)
        {
            if (!save())
                DevComponents.DotNetBar.MessageBoxEx.Show("Unable to save!");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewDH();
        }
    }
}
