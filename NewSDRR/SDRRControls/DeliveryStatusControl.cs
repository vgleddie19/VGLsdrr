using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewSDRR
{
    public partial class DeliveryStatusControl : UserControl
    {
        public String ClientName;
        public List<String> ListPersonel;
        public String _sdrrno;
        public DataTable printableData;
        public DeliveryStatusControl(String sdrrno)
        {
            InitializeComponent();
            _sdrrno = sdrrno;
            lblsdrrno.Text = sdrrno;
            populategrid();
            Utils.printpreview_formuse = "DeliveryStatusControl";
            Utils.isNewRecord = false;
        
        }
        #region Commands
        private MetroBillCommands _Commands;
        /// <summary>
        /// Gets or sets the commands associated with the control.
        /// </summary>
        public MetroBillCommands Commands
        {
            get { return _Commands; }
            set
            {
                if (value != _Commands)
                {
                    MetroBillCommands oldValue = _Commands;
                    _Commands = value;
                    OnCommandsChanged(oldValue, value);
                }
            }
        }
        /// <summary>
        /// Called when Commands property has changed.
        /// </summary>
        /// <param name="oldValue">Old property value</param>
        /// <param name="newValue">New property value</param>
        protected virtual void OnCommandsChanged(MetroBillCommands oldValue, MetroBillCommands newValue)
        {
            if (newValue != null)
            {
                btnback.Command = newValue.SDRRCommands.Cancel;
                btnUpdate.Command = newValue.SDRRCommands.New;                
            }
            else
            {
                btnback.Command = null;
                btnUpdate.Command = null;
            }
        }
        #endregion

        public bool updatedelstatus()
        {
            try
            {
                String sql = "";
                foreach (DataGridViewRow gRow in gridSDRRUpdate.Rows)
                {
                    Dictionary<String, Object> param = new Dictionary<String, Object>();
                    param.Add("sdrrno", _sdrrno);
                    param.Add("invoice_no", gRow.Cells["invoiceno"].Value);
                    param.Add("datedel", gRow.Cells["datedel"].Value);
                    param.Add("delstat", gRow.Cells["status"].Value);
                    param.Add("dateupdated", DateTime.Now.Date);
                    param.Add("remarks", gRow.Cells["remarks"].Value);

                    List<String> primary = new List<string>();
                    primary.Add("sdrrno");
                    primary.Add("invoice_no");

                    sql += DataSupport.GetUpdate("GLOBAL_ProductTrans", param, primary);


                }
                if (sql != "")
                    Utils.ExecuteNonQuery(sql, null);

                DevComponents.DotNetBar.MessageBoxEx.Show("Delivery Status successfully updated");
                return true;
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(String.Format("{0}\nUnable to update the transaction",ex.Message));
                return false;
            }
        }
        private void populategrid()
        {
            try
            {
                foreach (DataRow dRow in Utils.GetDataTable("SELECT * FROM GLOBAL_producttrans WHERE sdrrno = " + _sdrrno).Rows)
                {
                    String[] addRow = new String[gridSDRRUpdate.ColumnCount];

                    addRow[0] = dRow["invoice_no"].ToString().Trim();
                    if (dRow["datedel"] != null)
                        addRow[1] = dRow["datedel"].ToString().Trim();
                    if (dRow["delstat"] != null)
                        addRow[2] = dRow["delstat"].ToString().Trim();
                    if (dRow["remarks"] != null)
                        addRow[3] = dRow["remarks"].ToString().Trim();
                    addRow[4] = dRow["invoice_value"].ToString().Trim();

                    addRow[5] = dRow["customer_name"].ToString().Trim();
                    addRow[6] = dRow["no_of_cartons"].ToString().Trim();
                    gridSDRRUpdate.Rows.Add(addRow);
                }
                foreach (DataRow dRow in Utils.GetDataTable("SELECT * FROM GLOBAL_SdrrMaster WHERE sdrrno = " + _sdrrno).Rows)
                {
                    ClientName = dRow["client"].ToString().Trim();
                    ListPersonel = new List<string>();
                    ListPersonel.Add(dRow["driver"].ToString().Trim());
                    ListPersonel.Add(dRow["helper"].ToString().Trim());
                    ListPersonel.Add(dRow["helper2"].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message + "\nReport this to the programmer!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Utils.ListOfActiveControls.Add("PRINT");
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add("sdrrno", _sdrrno);
            printableData = getPrintableData(gridSDRRUpdate, param);
        }
        private DataTable getPrintableData(DataGridView sdrrgrid, Dictionary<String, Object> param)
        {
            System.Data.DataTable result = new System.Data.DataTable();
            result.Columns.Add(new DataColumn("sdrrNo", typeof(string)));
            result.Columns.Add(new DataColumn("driver", typeof(string)));
            result.Columns.Add(new DataColumn("helper", typeof(string)));
            result.Columns.Add(new DataColumn("helper2", typeof(string)));
            result.Columns.Add(new DataColumn("client", typeof(string)));
            result.Columns.Add(new DataColumn("invoice_no", typeof(string)));
            result.Columns.Add(new DataColumn("dateDel", typeof(string)));
            result.Columns.Add(new DataColumn("status", typeof(string)));
            result.Columns.Add(new DataColumn("remarks", typeof(string)));
            result.Columns.Add(new DataColumn("invoice_value", typeof(Decimal)));
            result.Columns.Add(new DataColumn("customer_name", typeof(string)));
            result.Columns.Add(new DataColumn("cases", typeof(string)));

            foreach (DataGridViewRow dRows in gridSDRRUpdate.Rows)
            {
                DataRow resultRow = result.NewRow();
                resultRow["sdrrNo"] = param["sdrrno"];
                resultRow["invoice_no"] = dRows.Cells["invoiceno"].Value.ToString();
                if (dRows.Cells["status"].Value.ToString() != "CANCELLED" ||
                    dRows.Cells["status"].Value.ToString() != "RETURNED" ||
                    dRows.Cells["status"].Value.ToString() != "IN ROUTE" ||
                    dRows.Cells["status"].Value.ToString() != "RE DELIVERY" ||
                    dRows.Cells["status"].Value.ToString() != "W/ DELIVERY DATE SCHEDULE")
                    resultRow["dateDel"] = dRows.Cells["datedel"].Value;//DateTime.Parse(String.Format("{0:MM/dd/yyyy}", dRows.Cells["datedel"].Value));

                resultRow["driver"] = ListPersonel[0];
                resultRow["helper"] = ListPersonel[1];
                resultRow["helper2"] = ListPersonel[2];
                resultRow["client"] = ClientName;
                resultRow["status"] = dRows.Cells["status"].Value.ToString();
                resultRow["remarks"] = dRows.Cells["remarks"].Value.ToString();
                resultRow["invoice_value"] = dRows.Cells["invoice_value"].Value.ToString();
                resultRow["customer_name"] = dRows.Cells["customer_name"].Value.ToString();
                resultRow["cases"] = dRows.Cells["cases"].Value.ToString();
                result.Rows.Add(resultRow);
            }

            return result;
        }

    }
}
