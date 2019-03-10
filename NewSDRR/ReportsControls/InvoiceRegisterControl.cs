using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevComponents.DotNetBar;
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;
using System.Globalization;

namespace NewSDRR
{
    public partial class InvoiceRegisterControl : UserControl
    {
        ReportDocument ReportDocs;
        Dictionary<String, DataTable> printableData;
        Dictionary<String, String> sbs_total = new Dictionary<String, String>();
        String HeaderName;
        public InvoiceRegisterControl()
        {
            InitializeComponent();
            cboClient.Items.Add("ALL CLIENTS");
            foreach (DataRow item in Utils.GetDataTable("SELECT * FROM [base_client]").Rows)
            {
                cboClient.Items.Add(item["clientcode"]);
            }
            cbodelstat.Items.Add("ALL STATUS");
            cbodelstat.Items.Add("ALL NON-DELIVERED");
            foreach (DataRow item in Utils.GetDataTable("SELECT DISTINCT [delstat] FROM [SDRR].[dbo].[GLOBAL_ProductTrans] WHERE delstat IS NOT NULL ORDER BY delstat").Rows)
            {
                if (item["delstat"].ToString().Trim() != "")
                    cbodelstat.Items.Add(item["delstat"]);
            }

            dtMonth.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToUniversalTime();
            cboClient.SelectedIndex = 0;
            cbodelstat.SelectedIndex = 0;
            loading.Visible = false;
        }
        private void InvoiceRegisterControl_Load(object sender, EventArgs e)
        {
            dtMonth.Focus();
        }
        #region Commands
        protected override void OnResize(EventArgs e)
        {
            // Center the panel
            loading.Location = new Point((this.Width) / 2 - 100, ((this.Height - labelX1.Height - 16)) / 2 - labelX1.Height);
            base.OnResize(e);
        }
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
                btncancel.Command = newValue.ReportCommands.Cancel;
            }
            else
            {
                btncancel.Command = null;
            }
        }
        #endregion

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<String, Object> param = new Dictionary<string, object>();
                param.Add("client", cboClient.Text);
                param.Add("monthcycle", dtMonth.Value.Month);
                param.Add("yearcycle", dtMonth.Value.Year);
                param.Add("delstat", cbodelstat.Text);

                Dictionary<String, Object> param1 = new Dictionary<string, object>();
                param1.Add("monthly", dtMonth.Value.Month);
                param1.Add("clientname", cboClient.Text);
                param1.Add("delstat", cbodelstat.Text);

                Thread thread = new Thread(() =>
                {
                    printableData = getPrintableData(param);
                    ReportDocs = getReportDocument(param1, null);
                    Action action = new Action(SetReportViewer);
                    this.BeginInvoke(action);
                });
                thread.Start();
            }
            catch (SqlException ex)
            {
                hide_loading();
                if (ex.Number == 4060 || ex.Number == 53)
                {
                    MessageBoxEx.Show("Unable to connect to the server! Please make sure you have an stable internet connection.\n" + ex.Message, "Log in Failed!", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBoxEx.Show("Report this to the programmer.\n" + ex.Message, "Log in Failed!", MessageBoxButtons.OK);
                }
            }
            catch (SystemException ex)
            {
                hide_loading();
                MessageBoxEx.Show("Report this to the programmer.\n" + ex.Message, "Log in Failed!", MessageBoxButtons.OK);
            }
        }

        private Dictionary<String, DataTable> getPrintableData(Dictionary<String, Object> param)
        {
            Dictionary<String, DataTable> result = new Dictionary<String, DataTable>();
            System.Data.DataTable tbl = new System.Data.DataTable();

            tbl.Columns.Add(new DataColumn("TripNo", typeof(string)));
            tbl.Columns.Add(new DataColumn("PlateNo", typeof(string)));
            tbl.Columns.Add(new DataColumn("TruckType", typeof(string)));
            tbl.Columns.Add(new DataColumn("Client", typeof(string)));
            tbl.Columns.Add(new DataColumn("SDRRNo", typeof(string)));
            tbl.Columns.Add(new DataColumn("Customer", typeof(string)));
            tbl.Columns.Add(new DataColumn("Zone", typeof(string)));
            tbl.Columns.Add(new DataColumn("isCovered", typeof(string)));
            tbl.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
            tbl.Columns.Add(new DataColumn("Amount", typeof(Decimal)));
            tbl.Columns.Add(new DataColumn("DateRec", typeof(string)));
            tbl.Columns.Add(new DataColumn("Status", typeof(string)));
            tbl.Columns.Add(new DataColumn("Remarks", typeof(string)));
            tbl.Columns.Add(new DataColumn("invoicedate", typeof(string)));

            Dictionary<String, DataRow> sdrrmast = new Dictionary<String, DataRow>();
            sdrrmast = Utils.BuildIndex_SQL("SELECT * FROM GLOBAL_SDRRMaster", "sdrrno");

            Dictionary<String, DataRow> updatedsdrr = new Dictionary<String, DataRow>();
            List<String> col = new List<string>();
            col.Add("sdrrno");
            col.Add("invoice_no");
            updatedsdrr = Utils.BuildIndex_SQL("SELECT * FROM GLOBAL_ProductTrans", col, " ");

            DataSupport.setDBConnection("Integrated Security=SSPI;Initial Catalog=dispatch;Data Source=.\\SQLEXPRESS; User Id = vgl_data; Password = tqbfjotld;");
            Dictionary<String, DataRow> sdrrtrip = new Dictionary<String, DataRow>();
            sdrrtrip = Utils.BuildIndex_SQL("select SD.tripindex,SD.SDRRNo, TT.VehlIndex FROM GLOBAL_SDRRTrip sd LEFT JOIN GLOBAL_tRIPtICKET tt ON tt.tripno = sd.tripindex AND TT.yearcycle = sd.yearcycle", "SDRRno");

            Dictionary<String, DataRow> vehltrip = new Dictionary<String, DataRow>();
            vehltrip = Utils.BuildIndex_SQL("select * FROM BASE_Vehicle", "_VehlIndex");


            DataSupport.setDBConnection("Integrated Security=SSPI;Initial Catalog=sdrr;Data Source=.\\SQLEXPRESS; User Id = vgl_data; Password = tqbfjotld;");
            DataTable zone_sbs = new DataTable();
            zone_sbs.Columns.Add(new DataColumn("zone1", typeof(Decimal)));
            zone_sbs.Columns.Add(new DataColumn("zone2", typeof(Decimal)));
            zone_sbs.Columns.Add(new DataColumn("zone3", typeof(Decimal)));
            zone_sbs.Columns.Add(new DataColumn("zone4", typeof(Decimal)));
            zone_sbs.Columns.Add(new DataColumn("zone5", typeof(Decimal)));
            zone_sbs.Columns.Add(new DataColumn("zone6", typeof(Decimal)));
            zone_sbs.Columns.Add(new DataColumn("zone7", typeof(Decimal)));
            zone_sbs.Columns.Add(new DataColumn("zone8", typeof(Decimal)));
            zone_sbs.Columns.Add(new DataColumn("totalamt", typeof(Decimal)));

            DataRow tblRow;
            String SQLCommand = "";

            
            if (param["client"].ToString() == "ALL CLIENTS")
            {
                if (param["delstat"].ToString() == "DELIVERED")
                {
                    HeaderName = "SUMMARY OF BILLING SUPPORT DELIVERED";
                    SQLCommand = "SELECT DISTINCT US.*, SM.Client FROM GLOBAL_ProductTrans US JOIN GLOBAL_SDRRMaster SM ON SM.SDRRNO = US.SDRRNO WHERE US.[delstat] = '" + param["delstat"].ToString() + "' AND MONTH(US.[datedel]) = " + param["monthcycle"].ToString() + " AND Year(US.[datedel]) = " + param["yearcycle"].ToString() + " AND invoice_date IS NOT NULL  ORDER BY [zone],[datedel],US.[invoice_no] ASC,US.[delstat] DESC";
                }
                else if (param["delstat"].ToString() == "ALL NON-DELIVERED")
                {
                    HeaderName = "SUMMARY OF BILLING SUPPORT " + param["delstat"].ToString();
                    SQLCommand = "SELECT DISTINCT US.*, SM.Client FROM GLOBAL_ProductTrans US JOIN GLOBAL_SDRRMaster SM ON SM.SDRRNO = US.SDRRNO WHERE US.[delstat] != 'DELIVERED' AND US.[delstat] != '' AND MONTH(SM.[date]) = " + param["monthcycle"].ToString() + " AND Year(SM.[date]) = " + param["yearcycle"].ToString() + " AND invoice_date IS NOT NULL ORDER BY [zone],US.[datedel],US.[invoice_no] ASC, US.[delstat] DESC";

                }
                else if (param["delstat"].ToString() == "ALL STATUS")
                {
                    HeaderName = "SUMMARY OF BILLING SUPPORT " + param["delstat"].ToString();
                    SQLCommand = "SELECT DISTINCT US.*, SM.Client FROM GLOBAL_ProductTrans US JOIN GLOBAL_SDRRMaster SM ON SM.SDRRNO = US.SDRRNO WHERE US.[delstat] != 'DELIVERED' AND MONTH(SM.[date]) = " + param["monthcycle"].ToString() + " AND Year(SM.[date]) = " + param["yearcycle"].ToString() + " AND invoice_date IS NOT NULL ORDER BY [zone],US.[datedel],US.[invoice_no] ASC, US.[delstat] DESC";
                }
                else
                {
                    HeaderName = "SUMMARY OF BILLING SUPPORT " + param["delstat"].ToString();
                    SQLCommand = "SELECT DISTINCT US.*, SM.Client FROM GLOBAL_ProductTrans US JOIN GLOBAL_SDRRMaster SM ON SM.SDRRNO = US.SDRRNO WHERE US.[delstat] = '" + param["delstat"].ToString() + "' AND US.[delstat] != '' AND MONTH(SM.[date]) = " + param["monthcycle"].ToString() + " AND Year(SM.[date]) = " + param["yearcycle"].ToString() + " AND invoice_date IS NOT NULL ORDER BY [zone],US.[datedel],US.[invoice_no] ASC, US.[delstat] DESC";                
                }
            }
            else
            {
                //if (param["delstat"].ToString() == "DELIVERED")
                //    SQLCommand = "SELECT DISTINCT US.*, SM.Client FROM GLOBAL_ProductTrans US JOIN GLOBAL_SDRRMaster SM ON SM.SDRRNO = US.SDRRNO WHERE US.[delstat] = '" + param["delstat"].ToString() + "' AND SM.Client = '" + param["client"].ToString() + "' AND MONTH(US.[datedel]) = " + param["monthcycle"].ToString() + " AND Year(US.[datedel]) = " + param["yearcycle"].ToString() + "  ORDER BY [zone],[datedel],US.[invoice_no] ASC,US.[delstat] DESC";
                //else
                //{
                //    HeaderName = "SUMMARY OF BILLING SUPPORT OTHERS";
                //    SQLCommand = "SELECT DISTINCT US.*, SM.Client FROM GLOBAL_ProductTrans US JOIN GLOBAL_SDRRMaster SM ON SM.SDRRNO = US.SDRRNO WHERE US.[delstat] != 'DELIVERED' AND US.[delstat] != '' AND SM.Client = '" + param["client"].ToString() + "' AND MONTH(SM.[date]) = " + param["monthcycle"].ToString() + " AND Year(SM.[date]) = " + param["yearcycle"].ToString() + "  ORDER BY [zone],US.[datedel],US.[invoice_no] ASC, US.[delstat] DESC";
                //}            
            }
            DataTable dtRep = Utils.GetDataTable(SQLCommand);
            decimal billedamt = 0;
            decimal[] zone = new decimal[8];

            foreach (DataRow dRow in dtRep.Rows)
            {
                DataRow Rowmast = null;
                DataRow RowUpdate = null;
                DataRow RowTrip = null;
                DataRow RowVehl = null;
                tblRow = tbl.NewRow();
                if (sdrrtrip.TryGetValue(dRow["sdrrno"].ToString().Trim(), out RowTrip))
                {
                    tblRow["TripNo"] = RowTrip["tripindex"].ToString();
                    if (vehltrip.TryGetValue(RowTrip["VehlIndex"].ToString(), out RowVehl))
                    {
                        tblRow["PlateNo"] = RowVehl["TruckType"].ToString();
                        tblRow["TruckType"] = RowVehl["maker"].ToString();
                    }
                }
                if (sdrrmast.TryGetValue(dRow["sdrrno"].ToString().Trim(), out Rowmast))
                {
                    tblRow["Client"] = Rowmast["Client"].ToString();
                }

                String cols = dRow["sdrrno"].ToString().Trim() + " " + dRow["invoice_no"].ToString().Trim();
                if (updatedsdrr.TryGetValue(cols, out RowUpdate))
                {
                    tblRow["SDRRNo"] = RowUpdate["sdrrno"].ToString();
                    tblRow["Customer"] = RowUpdate["Customer_name"].ToString();
                    tblRow["Zone"] = RowUpdate["Zone"].ToString();
                    tblRow["isCovered"] = RowUpdate["isCovered"].ToString();

                }
                if (dRow["DateDel"].ToString() != "")
                    tblRow["DateRec"] = Convert.ToDateTime(dRow["DateDel"].ToString()).ToShortDateString();
                tblRow["InvoiceNo"] = dRow["invoice_no"].ToString(); ;
                tblRow["Amount"] = dRow["invoice_value"].ToString();
                tblRow["Status"] = dRow["delStat"].ToString();
                tblRow["Remarks"] = dRow["remarks"].ToString();
                if (dRow["invoice_date"].ToString() != "")
                    tblRow["invoicedate"] = Convert.ToDateTime(dRow["invoice_date"]).ToShortDateString();
                else
                    tblRow["invoicedate"] = dRow["invoice_date"].ToString();

                tbl.Rows.Add(tblRow);
                billedamt += Convert.ToDecimal(tblRow["Amount"]);



                switch (tblRow["Zone"].ToString())
                {
                    case "1":
                        zone[0] += Convert.ToDecimal(tblRow["Amount"]);
                        break;
                    case "2":
                        zone[1] += Convert.ToDecimal(tblRow["Amount"]);
                        break;
                    case "3":
                        zone[2] += Convert.ToDecimal(tblRow["Amount"]);
                        break;
                    case "4":
                        zone[3] += Convert.ToDecimal(tblRow["Amount"]);
                        break;
                    case "5":
                        zone[4] += Convert.ToDecimal(tblRow["Amount"]);
                        break;
                    case "6":
                        zone[5] += Convert.ToDecimal(tblRow["Amount"]);
                        break;
                    case "7":
                        zone[6] += Convert.ToDecimal(tblRow["Amount"]);
                        break;
                    case "8":
                        zone[7] += Convert.ToDecimal(tblRow["Amount"]);
                        break;
                }
            }
            //if (_reportname == "GENBILLREPORT")
            //{
            sbs_total = new Dictionary<String, String>();
            sbs_total.Add("totalinvoice", dtRep.Rows.Count.ToString());
            sbs_total.Add("billedamt", billedamt.ToString());
            tblRow = zone_sbs.NewRow();
            tblRow["zone1"] = zone[0];
            tblRow["zone2"] = zone[1];
            tblRow["zone3"] = zone[2];
            tblRow["zone4"] = zone[3];
            tblRow["zone5"] = zone[4];
            tblRow["zone6"] = zone[5];
            tblRow["zone7"] = zone[6];
            tblRow["zone8"] = zone[7];
            tblRow["totalamt"] = zone[0] + zone[1] + zone[2] + zone[3] + zone[4] + zone[5] + zone[6] + zone[7];
            zone_sbs.Rows.Add(tblRow);
            result.Add("zone", zone_sbs);
            sbs_total.Add("batchcode", "");
            //}
            result.Add("main", tbl);

            return result;
        }
        private ReportDocument getReportDocument(Dictionary<String, Object> param, String printouttype)
        {
            ReportDocument rviewer = new ReportDocument();

            rviewer = new crtInvoiceRegister();
            rviewer.SetDataSource(printableData["main"]);
            rviewer.Subreports["crtSummaryBillSupport.rpt"].SetDataSource(printableData["zone"]);
            rviewer.SetParameterValue("HeaderName", HeaderName);
            rviewer.SetParameterValue("branch", Utils.branchcode);
            rviewer.SetParameterValue("monthly", param["monthly"]);
            rviewer.SetParameterValue("clientname", param["clientname"]);
            rviewer.SetParameterValue("delstat", param["delstat"]);
            rviewer.SetParameterValue("totalinvoice", sbs_total["totalinvoice"]);
            rviewer.SetParameterValue("batchcode", sbs_total["batchcode"]);
            rviewer.SetParameterValue("billedamt", sbs_total["billedamt"], "crtSummaryBillSupport.rpt");
            rviewer.SetParameterValue("monthcycle", param["monthly"] + " CYCLE", "crtSummaryBillSupport.rpt");

            return rviewer;
        }
        private void SetReportViewer()
        {
            this.crtviewer.ReportSource = ReportDocs;
            this.crtviewer.Zoom(110);
            hide_loading();
        }
        private void hide_loading()
        {
            loading.Visible = false;
            loading.Active = false;
        }
    }
}
