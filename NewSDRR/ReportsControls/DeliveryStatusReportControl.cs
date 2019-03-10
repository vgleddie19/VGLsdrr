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
    public partial class DeliveryStatusReportControl : UserControl
    {
        ReportDocument ReportDocs;
        Dictionary<String, DataTable> printableData;
        public DeliveryStatusReportControl()
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
            Dictionary<String, Object> param = new Dictionary<string, object>();
            param.Add("clientname", "ALL");
            param.Add("reportname", "GENDELSTATUSREPORT");
            param.Add("datefrom", dtStarted.Value.ToShortDateString());
            param.Add("dateto", dtEnded.Value.ToShortDateString());
            param.Add("nooftrips", 0);
            param.Add("nooftripsweek", 0);
            param.Add("invoicevalue_mtd", 0);
            param.Add("invoicevalue_ytd", 0);
            param.Add("hired", 0);
            param.Add("totaltripdelivered", 0);
            param.Add("totaltripundelivered", 0);
            param.Add("nooftripsdelweek", 0);
            param.Add("nooftripsundelweek", 0);
            param.Add("commute", 0);
            param.Add("owned", 0);
            param.Add("amounthired", 0);
            param.Add("amountcommute", 0);
            param.Add("amountowned", 0);
            param.Add("hiredweek", 0);
            param.Add("commuteweek", 0);
            param.Add("ownweek", 0);
            param.Add("amounthiredweek", 0);
            param.Add("amountcommuteweek", 0);
            param.Add("totalothertruckweek", 0);
            param.Add("totalothertruck", 0);
            param.Add("totalvehlusedweek", 0);
            param.Add("totalvehlused", 0);
            param.Add("allinvoicemonth", 0);
            param.Add("monthname", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dtStarted.Value.Month));

            Thread thread = new Thread(() =>
            {
                //try
                //{
                    printableData = getPrintableData(param);
                    ReportDocs = getReportDocument(param, null);
                    Action action = new Action(SetReportViewer);
                    this.BeginInvoke(action);
                //}
                //catch (SqlException ex)
                //{
                //    Action action = new Action(hide_loading);
                //    this.BeginInvoke(action);
                //    if (ex.Number == 4060 || ex.Number == 53)
                //    {
                //        MessageBoxEx.Show("Unable to connect to the server! Please make sure you have an stable internet connection.\n" + ex.Message, "Log in Failed!", MessageBoxButtons.OK);
                //    }
                //    else
                //    {
                //        MessageBoxEx.Show("Report this to the programmer.\n" + ex.Message, "Log in Failed!", MessageBoxButtons.OK);
                //    }
                //}
                //catch (SystemException ex)
                //{
                //    Action action = new Action(hide_loading);
                //    this.BeginInvoke(action);
                //    MessageBoxEx.Show("Report this to the programmer.\n" + ex.Message, "Log in Failed!", MessageBoxButtons.OK);
                //}
            });
            thread.Start();

            loading.Visible = true;
            loading.Active = true;

        }

        private Dictionary<String, DataTable> getPrintableData(Dictionary<String, Object> param)
        {
            Dictionary<String, DataTable> result = new Dictionary<String, DataTable>();
            System.Data.DataTable tbl = new System.Data.DataTable();
            StringBuilder SQL;
            DataRow tblRow = null;

            tbl.Columns.Add(new DataColumn("sdrrno", typeof(string)));
            tbl.Columns.Add(new DataColumn("invoice_no", typeof(string)));
            tbl.Columns.Add(new DataColumn("invoice_value", typeof(Decimal)));
            tbl.Columns.Add(new DataColumn("invoice_date", typeof(string)));
            tbl.Columns.Add(new DataColumn("datedel", typeof(string)));
            tbl.Columns.Add(new DataColumn("delstat", typeof(string)));
            tbl.Columns.Add(new DataColumn("tripdate", typeof(string)));
            tbl.Columns.Add(new DataColumn("tripno", typeof(string)));
            tbl.Columns.Add(new DataColumn("customer", typeof(string)));
            tbl.Columns.Add(new DataColumn("client", typeof(string)));
            tbl.Columns.Add(new DataColumn("ismtd", typeof(string)));
            tbl.Columns.Add(new DataColumn("triptype", typeof(string)));

            SQL = new StringBuilder();
            SQL.AppendFormat("select sd.tripindex[tripno],sd.SDRRNo, v.Vehlcode,sd.yearcycle,sd.clientname FROM dispatch.[dbo].global_sdrrtrip sd LEFT JOIN dispatch.[dbo].global_tripticket tt ON tt.tripno = sd.tripindex AND tt.yearcycle = sd.yearcycle  join dispatch.[dbo].base_vehicle v on v._VehlIndex = tt.VehlIndex");
            Dictionary<String, DataRow> sdrrtrip = new Dictionary<String, DataRow>();
            sdrrtrip = Utils.BuildIndex_SQL(SQL.ToString(), "SDRRno");

            DataTable tripsdrr = new DataTable();
            tripsdrr = Utils.GetDataTable(SQL.ToString());

            SQL = new StringBuilder();
            SQL.AppendFormat("select *,(CAST(tripno as varchar(50)) + '-' + CAST(YearCycle as varchar(50)))[search] FROM dispatch.[dbo].global_tripticket");
            Dictionary<String, DataRow> trip = new Dictionary<String, DataRow>();
            trip = Utils.BuildIndex_SQL(SQL.ToString(), "search");

            SQL = new StringBuilder();
            SQL.AppendFormat("SELECT * FROM global_sdrrmaster");
            Dictionary<String, DataRow> sdrrmast = new Dictionary<String, DataRow>();
            sdrrmast = Utils.BuildIndex_SQL(SQL.ToString(), "sdrrno");


            Dictionary<string, string> nooftrips = new Dictionary<string, string>();
            Dictionary<string, string> nooftripsweeks = new Dictionary<string, string>();
            Decimal invoicevalue_mtd = 0;
            Decimal invoicevalue_ytd = 0;
            Int32 hired = 0;
            Int32 owned = 0;
            Int32 commute = 0;
            Decimal nooftripsdelweek = 0;
            Decimal nooftripsundelweek = 0;
            Decimal totaltripdelivered = 0;
            Decimal totaltripundelivered = 0;
            Decimal amounthired = 0;
            Decimal amountowned = 0;
            Decimal amountcommute = 0;
            Int32 hiredweek = 0;
            Int32 ownedweek = 0;
            Int32 commuteweek = 0;
            Decimal amounthiredweek = 0;
            Decimal amountownedweek = 0;
            Decimal amountcommuteweek = 0;
            Decimal allinvoicemonth = 0;
            StringBuilder search = new StringBuilder();
            int weekm = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(Convert.ToDateTime(param["dateto"].ToString()), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            SQL = new StringBuilder();
            if (param["clientname"].ToString() == "ALL")
            {
                SQL.AppendFormat("SELECT * FROM global_producttrans INV WHERE (delstat = 'DELIVERED' OR delstat = 'DELIVERED WITH CUT ITEM' OR delstat = 'WITH CUT ITEM' OR delstat = 'RE DELIVERY') AND [invoice_date] BETWEEN '{0}' AND '{1}'  ORDER BY [invoice_date] ASC"
                                 , param["datefrom"].ToString()
                                 , param["dateto"].ToString());
            }
            else
            {
                SQL.AppendFormat("SELECT * FROM [global_producttrans] INV WHERE (delstat = 'DELIVERED' OR delstat = 'DELIVERED WITH CUT ITEM' OR delstat = 'WITH CUT ITEM' OR delstat = 'RE DELIVERY') AND ([invoice_date] BETWEEN '{0}' AND '{1}') AND (SELECT TOP 1 client FROM global_sdrrmaster WHERE sdrrno = INV.sdrrno) = '{2}' ORDER BY [invoice_date] ASC"
                                 , param["datefrom"].ToString()
                                 , param["dateto"].ToString()
                                 , param["clientname"].ToString());
            }
            foreach (DataRow dRow in Utils.GetDataTable(SQL.ToString()).Rows)
            {
                tblRow = tbl.NewRow();
                DataRow sRow = null;
                if (sdrrmast.TryGetValue(dRow["sdrrno"].ToString(), out sRow))
                {
                    tblRow["sdrrno"] = dRow["sdrrno"];
                    tblRow["invoice_no"] = dRow["invoice_no"];
                    tblRow["invoice_value"] = dRow["invoice_value"];
                    tblRow["delstat"] = dRow["delstat"];
                    tblRow["customer"] = dRow["customer_name"];
                    tblRow["client"] = sRow["client"];
                    tblRow["invoice_date"] = dRow["invoice_date"] == DBNull.Value ? dRow["invoice_date"] : Convert.ToDateTime(dRow["invoice_date"]).ToShortDateString();
                    tblRow["datedel"] = dRow["datedel"] == DBNull.Value ? dRow["datedel"] : Convert.ToDateTime(dRow["datedel"]).ToShortDateString();
                    DataRow sRow1 = null;
                    if (sdrrtrip.TryGetValue(dRow["sdrrno"].ToString(), out sRow1))
                    {
                        tblRow["tripno"] = sRow1["tripno"];
                        DataRow sRow2 = null;
                        search = new StringBuilder();
                        search.AppendFormat("{0}-{1}", sRow1["tripno"].ToString(), Convert.ToDateTime(param["dateto"]).Year);
                        if (trip.TryGetValue(search.ToString(), out sRow2))
                        {
                            tblRow["tripdate"] = sRow2["TripDate"];
                            if (Convert.ToDateTime(sRow2["TripDate"]).Month == Convert.ToDateTime(param["datefrom"].ToString()).Month)
                            {
                                if (!nooftrips.ContainsKey(sRow1["tripno"].ToString()))
                                {
                                    nooftrips.Add(sRow1["tripno"].ToString(), sRow1["tripno"].ToString());

                                    if (sRow2["triptype"].ToString() == "1")
                                    {
                                        tblRow["triptype"] = "Owned";
                                        amountowned += Convert.ToDecimal(sRow2["paidamount"]);
                                        owned += 1;
                                    }
                                    else if (sRow2["triptype"].ToString() == "2")
                                    {
                                        tblRow["triptype"] = "Hired";
                                        amounthired += Convert.ToDecimal(sRow2["paidamount"]);
                                        hired += 1;
                                    }
                                    else if (sRow2["triptype"].ToString() == "3")
                                    {
                                        tblRow["triptype"] = "Commute";
                                        amountcommute += Convert.ToDecimal(sRow2["paidamount"]);
                                        commute += 1;
                                    }
                                }
                                if (!nooftripsweeks.ContainsKey(sRow1["tripno"].ToString()))
                                {
                                    if (Convert.ToDateTime(sRow2["TripDate"]).Month == Convert.ToDateTime(param["datefrom"].ToString()).Month)
                                    {
                                        if (weekm == CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(Convert.ToDateTime(sRow2["TripDate"].ToString()), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                                        {
                                            nooftripsweeks.Add(sRow1["tripno"].ToString(), sRow1["tripno"].ToString());
                                            if (sRow2["triptype"].ToString() == "1")
                                            {
                                                tblRow["triptype"] = "Owned";
                                                amountownedweek += Convert.ToDecimal(sRow2["paidamount"]);
                                                ownedweek += 1;
                                            }
                                            else if (sRow2["triptype"].ToString() == "2")
                                            {
                                                tblRow["triptype"] = "Hired";
                                                amounthiredweek += Convert.ToDecimal(sRow2["paidamount"]);
                                                hiredweek += 1;
                                            }
                                            else if (sRow2["triptype"].ToString() == "3")
                                            {
                                                tblRow["triptype"] = "Commute";
                                                amountcommuteweek += Convert.ToDecimal(sRow2["paidamount"]);
                                                commuteweek += 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                        tblRow["tripno"] = "no trip ticket";

                    invoicevalue_mtd += Convert.ToDecimal(tblRow["invoice_value"]);
                    tblRow["ismtd"] = "Month To Date ";
                    tbl.Rows.Add(tblRow);
                }
            }

            SQL = new StringBuilder();
            if (param["clientname"].ToString() == "ALL")
            {
                SQL.AppendFormat("SELECT * FROM global_producttrans WHERE (delstat = 'DELIVERED' OR delstat = 'DELIVERED WITH CUT ITEM' OR delstat = 'WITH CUT ITEM' OR delstat = 'RE DELIVERY') AND [datedel] BETWEEN '{0}' AND '{1}'  ORDER BY [invoice_date] ASC"
                                 , param["datefrom"].ToString()
                                 , param["dateto"].ToString());
            }
            else
            {
                SQL.AppendFormat("SELECT * FROM global_producttrans INV WHERE (delstat = 'DELIVERED' OR delstat = 'DELIVERED WITH CUT ITEM' OR delstat = 'WITH CUT ITEM' OR delstat = 'RE DELIVERY') AND ([datedel] BETWEEN '{0}' AND '{1}') AND (SELECT TOP 1 client FROM global_sdrrmaster WHERE sdrrno = INV.sdrrno) = '{2}'  ORDER BY [invoice_date] ASC"
                                 , param["datefrom"].ToString()
                                 , param["dateto"].ToString()
                                 , param["clientname"].ToString());
            }
            foreach (DataRow dRow in Utils.GetDataTable(SQL.ToString()).Rows)
            {
                tblRow = tbl.NewRow();
                DataRow sRow = null;
                if (sdrrmast.TryGetValue(dRow["sdrrno"].ToString(), out sRow))
                {
                    tblRow["sdrrno"] = dRow["sdrrno"];
                    tblRow["invoice_no"] = dRow["invoice_no"];
                    tblRow["invoice_value"] = dRow["invoice_value"];
                    tblRow["delstat"] = dRow["delstat"];
                    tblRow["customer"] = dRow["customer_name"];
                    tblRow["client"] = sRow["client"];
                    tblRow["invoice_date"] = dRow["invoice_date"] == DBNull.Value ? dRow["invoice_date"] : Convert.ToDateTime(dRow["invoice_date"]).ToShortDateString();
                    tblRow["datedel"] = dRow["datedel"] == DBNull.Value ? dRow["datedel"] : Convert.ToDateTime(dRow["datedel"]).ToShortDateString();
                    DataRow sRow1 = null;
                    if (sdrrtrip.TryGetValue(dRow["sdrrno"].ToString(), out sRow1))
                    {
                        tblRow["tripno"] = sRow1["tripno"];
                        DataRow sRow2 = null;
                        search = new StringBuilder();
                        search.AppendFormat("{0}-{1}", sRow1["tripno"].ToString(), sRow1["yearcycle"].ToString());
                        if (trip.TryGetValue(search.ToString(), out sRow2))
                        {
                            tblRow["tripdate"] = sRow2["TripDate"];
                            if (Convert.ToDateTime(sRow2["TripDate"]).Month == Convert.ToDateTime(param["datefrom"].ToString()).Month)
                            {
                                if (!nooftrips.ContainsKey(sRow1["tripno"].ToString()))
                                {
                                    nooftrips.Add(sRow1["tripno"].ToString(), sRow1["tripno"].ToString());
                                    if (sRow2["triptype"].ToString() == "1")
                                    {
                                        tblRow["triptype"] = "Owned";
                                        amountowned += Convert.ToDecimal(sRow2["paidamount"]);
                                        owned += 1;
                                    }
                                    else if (sRow2["triptype"].ToString() == "2")
                                    {
                                        tblRow["triptype"] = "Hired";
                                        amounthired += Convert.ToDecimal(sRow2["paidamount"]);
                                        hired += 1;
                                    }
                                    else if (sRow2["triptype"].ToString() == "3")
                                    {
                                        tblRow["triptype"] = "Commute";
                                        amountcommute += Convert.ToDecimal(sRow2["paidamount"]);
                                        commute += 1;
                                    }
                                }
                                if (!nooftripsweeks.ContainsKey(sRow1["tripno"].ToString()))
                                {
                                    if (Convert.ToDateTime(sRow2["TripDate"]).Month == Convert.ToDateTime(param["datefrom"].ToString()).Month)
                                    {
                                        if (weekm == CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(Convert.ToDateTime(sRow2["TripDate"].ToString()), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                                        {
                                            nooftripsweeks.Add(sRow1["tripno"].ToString(), sRow1["tripno"].ToString());
                                            if (sRow2["triptype"].ToString() == "1")
                                            {
                                                tblRow["triptype"] = "Owned";
                                                amountownedweek += Convert.ToDecimal(sRow2["paidamount"]);
                                                ownedweek += 1;
                                            }
                                            else if (sRow2["triptype"].ToString() == "2")
                                            {
                                                tblRow["triptype"] = "Hired";
                                                amounthiredweek += Convert.ToDecimal(sRow2["paidamount"]);
                                                hiredweek += 1;
                                            }
                                            else if (sRow2["triptype"].ToString() == "3")
                                            {
                                                tblRow["triptype"] = "Commute";
                                                amountcommuteweek += Convert.ToDecimal(sRow2["paidamount"]);
                                                commuteweek += 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                        tblRow["tripno"] = "no trip ticket";

                    invoicevalue_ytd += Convert.ToDecimal(tblRow["invoice_value"]);
                    tblRow["ismtd"] = "Year To Date";
                    tbl.Rows.Add(tblRow);
                }
            }
            totaltripdelivered = nooftrips.Count();
            nooftripsdelweek = nooftripsweeks.Count();
            SQL = new StringBuilder();
            SQL.AppendFormat("SELECT * FROM dispatch.[dbo].global_tripticket WHERE [tripdate] BETWEEN '{0}' AND '{1}'  ORDER BY [tripno] ASC"
                             , param["datefrom"].ToString()
                             , param["dateto"].ToString());
            bool found;
            foreach (DataRow dRow in Utils.GetDataTable(SQL.ToString()).Rows)
            {
                found = false;
                if (param["clientname"].ToString() == "ALL")
                {
                    found = true;
                }
                else
                {
                    if (istriphasclient(tripsdrr, param["clientname"].ToString()))
                    { found = true; }
                }
                if (found)
                {

                    if (!nooftrips.ContainsKey(dRow["tripno"].ToString()))
                    {
                        nooftrips.Add(dRow["tripno"].ToString(), dRow["tripno"].ToString());
                        totaltripundelivered += 1;
                        if (dRow["triptype"].ToString() == "1")
                        {
                            amountowned += Convert.ToDecimal(dRow["paidamount"]);
                            owned += 1;
                        }
                        else if (dRow["triptype"].ToString() == "2")
                        {
                            amounthired += Convert.ToDecimal(dRow["paidamount"]);
                            hired += 1;
                        }
                        else if (dRow["triptype"].ToString() == "3")
                        {
                            amountcommute += Convert.ToDecimal(dRow["paidamount"]);
                            commute += 1;
                        }
                    }
                    if (!nooftripsweeks.ContainsKey(dRow["tripno"].ToString()))
                    {
                        if (Convert.ToDateTime(dRow["TripDate"]).Month == Convert.ToDateTime(param["datefrom"].ToString()).Month)
                        {
                            if (weekm == CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(Convert.ToDateTime(dRow["TripDate"].ToString()), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                            {
                                nooftripsweeks.Add(dRow["tripno"].ToString(), dRow["tripno"].ToString());
                                nooftripsundelweek += 1;
                                if (dRow["triptype"].ToString() == "1")
                                {
                                    amountownedweek += Convert.ToDecimal(dRow["paidamount"]);
                                    ownedweek += 1;
                                }
                                else if (dRow["triptype"].ToString() == "2")
                                {
                                    amounthiredweek += Convert.ToDecimal(dRow["paidamount"]);
                                    hiredweek += 1;
                                }
                                else if (dRow["triptype"].ToString() == "3")
                                {
                                    amountcommuteweek += Convert.ToDecimal(dRow["paidamount"]);
                                    commuteweek += 1;
                                }
                            }
                        }
                    }
                }
            }

            SQL = new StringBuilder();
            if (param["clientname"].ToString() == "ALL")
            {
                SQL.AppendFormat("select isnull(SUM(pt.invoice_value),0) from " +
                                                     "dispatch.[dbo].global_tripticket tt join dispatch.[dbo].global_sdrrtrip st ON tt.TripNo = st.tripindex " +
                                                     "join global_producttrans pt ON  st.sdrrno = pt.sdrrNo " +
                                                     "WHERE (tt.tripdate BETWEEN '{0}' AND '{1}')", param["datefrom"].ToString(), param["dateto"].ToString());
            }
            else
            {
                SQL.AppendFormat("select isnull(SUM(pt.invoice_value),0) from " +
                                 "dispatch.[dbo].global_tripticket tt join dispatch.[dbo].global_sdrrtrip st ON tt.TripNo = st.tripindex " +
                                 "join global_producttrans pt ON  st.sdrrno = pt.sdrrNo " +
                                 "WHERE (tt.tripdate BETWEEN '{0}' AND '{1}') AND st.clientname = '{2}'", param["datefrom"].ToString(), param["dateto"].ToString(), param["clientname"].ToString());
            }
            foreach (DataRow dRow in Utils.GetDataTable(SQL.ToString()).Rows)
            {
                string s = dRow[0].ToString();
                allinvoicemonth = Convert.ToDecimal(dRow[0].ToString());
            }
            
            param["totalvehlused"] = hired + commute + owned;
            param["totalvehlusedweek"] = hiredweek + commuteweek + ownedweek;
            param["totalothertruckweek"] = Convert.ToDecimal(amounthiredweek) + Convert.ToDecimal(amountcommuteweek);
            param["totalothertruck"] = Convert.ToDecimal(amounthired) + Convert.ToDecimal(amountcommute);
            param["nooftripsdelweek"] = nooftripsdelweek;
            param["nooftripsundelweek"] = nooftripsundelweek;
            param["totaltripdelivered"] = totaltripdelivered;
            param["totaltripundelivered"] = totaltripundelivered;
            param["invoicevalue_mtd"] = invoicevalue_mtd;
            param["invoicevalue_ytd"] = invoicevalue_ytd;
            param["hired"] = hired;
            param["commute"] = commute;
            param["owned"] = owned;
            param["amounthired"] = amounthired;
            param["amountcommute"] = amountcommute;
            param["amountowned"] = amountowned;
            param["hiredweek"] = hiredweek;
            param["commuteweek"] = commuteweek;
            param["ownweek"] = ownedweek;
            param["amounthiredweek"] = amounthiredweek;
            param["amountcommuteweek"] = amountcommuteweek;
            param["nooftrips"] = nooftrips.Count;
            param["nooftripsweek"] = nooftripsweeks.Count;
            param["allinvoicemonth"] = allinvoicemonth;

            result.Add("main", tbl);

            return result;
        }
        private ReportDocument getReportDocument(Dictionary<String, Object> param, String printouttype)
        {
            ReportDocument rviewer = new ReportDocument();
            rviewer = new crtDelStatusReport();
            rviewer.SetDataSource(printableData["main"]);
            rviewer.SetParameterValue("nooftrips", param["nooftrips"]);
            rviewer.SetParameterValue("nooftripsweek", param["nooftripsweek"]);
            rviewer.SetParameterValue("datefrom", param["datefrom"]);
            rviewer.SetParameterValue("dateto", param["dateto"]);
            rviewer.SetParameterValue("totalinvoicevaluemtd", param["invoicevalue_mtd"]);
            rviewer.SetParameterValue("totalinvoicevalueytd", param["invoicevalue_ytd"]);
            rviewer.SetParameterValue("hired", param["hired"]);
            rviewer.SetParameterValue("commute", param["commute"]);
            rviewer.SetParameterValue("owned", param["owned"]);
            rviewer.SetParameterValue("amounthired", param["amounthired"]);
            rviewer.SetParameterValue("amountcommute", param["amountcommute"]);
            rviewer.SetParameterValue("amountowned", param["amountowned"]);
            rviewer.SetParameterValue("hireweek", param["hiredweek"]);
            rviewer.SetParameterValue("commuteweek", param["commuteweek"]);
            rviewer.SetParameterValue("ownweek", param["ownweek"]);
            rviewer.SetParameterValue("amounthiredweek", param["amounthiredweek"]);
            rviewer.SetParameterValue("amountcommuteweek", param["amountcommuteweek"]);
            rviewer.SetParameterValue("totaltripdelivered", param["totaltripdelivered"]);
            rviewer.SetParameterValue("totaltripundelivered", param["totaltripundelivered"]);
            rviewer.SetParameterValue("nooftripsdelweek", param["nooftripsdelweek"]);
            rviewer.SetParameterValue("nooftripsundelweek", param["nooftripsundelweek"]);
            rviewer.SetParameterValue("totalothertruckweek", param["totalothertruckweek"]);
            rviewer.SetParameterValue("totalothertruck", param["totalothertruck"]);
            rviewer.SetParameterValue("totalvehlused", param["totalvehlused"]);
            rviewer.SetParameterValue("totalvehlusedweek", param["totalvehlusedweek"]);
            rviewer.SetParameterValue("allinvoicemonth", param["allinvoicemonth"]);
            rviewer.SetParameterValue("monthname", param["monthname"]);
            rviewer.SetParameterValue("branchname", Utils.branchcode);
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
        static Boolean istriphasclient(DataTable tripsdrr, String clientname)
        {
            bool result = false;

            foreach (DataRow item in tripsdrr.Select("clientname = '" + clientname + "'"))
            { result = true; break; }
            return result;
        }
    }
}
