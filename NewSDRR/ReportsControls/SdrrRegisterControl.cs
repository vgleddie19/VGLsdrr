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
using System.Threading;
using CrystalDecisions.CrystalReports.Engine;

namespace NewSDRR
{
    public partial class SdrrRegisterControl : UserControl
    {
        ReportDocument ReportDocs;
        Dictionary<String, DataTable> printableData;
        public SdrrRegisterControl()
        {
            InitializeComponent();

            cboClient.Items.Add("ALL CLIENTS");
            foreach (DataRow item in Utils.GetDataTable("SELECT * FROM [base_client]").Rows)
            {
                cboClient.Items.Add(item["clientcode"]);
            }
            dtStarted.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToUniversalTime();
            dtEnded.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToUniversalTime();
            cboClient.SelectedIndex = 0;
            loading.Visible = false;
        }

        #region Commands
        protected override void OnResize(EventArgs e)
        {
            // Center the panel
           loading.Location = new Point((this.Width) / 2-100, ((this.Height - labelX1.Height - 16)) / 2 - labelX1.Height);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<String, Object> param = new Dictionary<string, object>();
                param.Add("client", cboClient.Text);
                param.Add("datefrom", dtStarted.Value);
                param.Add("dateto", dtEnded.Value);

                Thread thread = new Thread(() =>
                {
                    printableData = getPrintableData(param);
                    ReportDocs = getReportDocument();
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
            tbl = new System.Data.DataTable();
            tbl.Columns.Add(new DataColumn("TripNo", typeof(string)));
            tbl.Columns.Add(new DataColumn("SDRRDate", typeof(DateTime)));
            tbl.Columns.Add(new DataColumn("SDRRNo", typeof(string)));
            tbl.Columns.Add(new DataColumn("Client", typeof(string)));
            tbl.Columns.Add(new DataColumn("Route", typeof(string)));
            tbl.Columns.Add(new DataColumn("Zone", typeof(string)));
            tbl.Columns.Add(new DataColumn("Cartons", typeof(string)));
            tbl.Columns.Add(new DataColumn("Amount", typeof(Decimal)));
            DataRow tblRow;
            //HeaderName = "List of All SDRR for " + param["client"];
            String SQLCommand;
            if (param["client"].ToString() == "ALL CLIENTS")
                SQLCommand = "SELECT SM.[DATE],PT.[SDRRNO],SM.[CLIENT],SM.[ROUTE],MAX(ZONE) [zone],SUM(CONVERT(DECIMAL(18,2),NO_OF_CARTONS))[cartons],SUM(PT.invoice_value)[amount] FROM GLOBAL_SDRRMASTER SM JOIN GLOBAL_PRODUCTTRANS PT ON SM.SDRRNO = PT.SDRRNO WHERE SM.[Date] BETWEEN '" + param["datefrom"] + "' AND '" + param["dateto"] + "'  GROUP BY SM.[DATE],PT.[SDRRNO],SM.[CLIENT],SM.[ROUTE]";
            else
                SQLCommand = "SELECT SM.[DATE],PT.[SDRRNO],SM.[CLIENT],SM.[ROUTE],MAX(ZONE) [zone],SUM(CONVERT(DECIMAL(18,2),NO_OF_CARTONS))[cartons],SUM(PT.invoice_value)[amount] FROM GLOBAL_SDRRMASTER SM JOIN GLOBAL_PRODUCTTRANS PT ON SM.SDRRNO = PT.SDRRNO WHERE CLIENT = '" + param["client"] + "' AND SM.[Date] BETWEEN '" + param["datefrom"] + "' AND '" + param["dateto"] + "'  GROUP BY SM.[DATE],PT.[SDRRNO],SM.[CLIENT],SM.[ROUTE]";

            DataSupport.setDBConnection("Integrated Security=SSPI;Initial Catalog=dispatch;Data Source=.\\SQLEXPRESS; User Id = vgl_data; Password = tqbfjotld;");
            Dictionary<String, DataRow> sdrrtrip = new Dictionary<String, DataRow>();
            sdrrtrip = Utils.BuildIndex_SQL("select * FROM GLOBAL_SDRRTrip", "SDRRNo");
            DataSupport.setDBConnection("Integrated Security=SSPI;Initial Catalog=sdrr;Data Source=.\\SQLEXPRESS; User Id = vgl_data; Password = tqbfjotld;");

            foreach (DataRow dRow in Utils.GetDataTable(SQLCommand).Rows)
            {
                tblRow = tbl.NewRow();
                DataRow RowTrip = null;

                if (sdrrtrip.TryGetValue(dRow["sdrrno"].ToString().Trim(), out RowTrip))
                    tblRow["TripNo"] = RowTrip["tripindex"].ToString().Trim();
                tblRow["SDRRDate"] = Convert.ToDateTime(dRow["date"].ToString()).ToShortDateString();
                tblRow["SDRRNo"] = dRow["sdrrno"].ToString();
                tblRow["Client"] = dRow["Client"].ToString();
                tblRow["Route"] = dRow["route"].ToString();
                tblRow["Zone"] = dRow["zone"].ToString();
                tblRow["Cartons"] = dRow["cartons"].ToString();
                tblRow["Amount"] = dRow["amount"].ToString();
                tbl.Rows.Add(tblRow);
            }
            DataView dv = tbl.DefaultView;
            dv.Sort = "SDRRDate Asc, TripNo Asc,SDRRNo Asc";
            DataTable sortedDT = dv.ToTable();
            result.Add("main", sortedDT);

            return result;
        }
        private ReportDocument getReportDocument()
        {
            ReportDocument rviewer = new ReportDocument();
            rviewer = new crtSDRRregister();
            rviewer.Database.Tables[0].SetDataSource(printableData["main"]);
            return rviewer;
        }
        private void SetReportViewer()
        {
            this.crtviewer.ReportSource = ReportDocs;
            this.crtviewer.Zoom(110);
            hide_loading();
        }

        private void SdrrRegisterControl_Load(object sender, EventArgs e)
        {
            dtStarted.Focus();
        }
        private void hide_loading()
        {
            loading.Visible = false;
            loading.Active = false;
        }
    }
}
