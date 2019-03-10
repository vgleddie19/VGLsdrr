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

namespace NewSDRR
{
    public partial class NudRegisterControl : UserControl
    {
        ReportDocument ReportDocs;
        Dictionary<String, DataTable> printableData;
        public NudRegisterControl()
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
            try
            {

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


            return result;
        }
        private ReportDocument getReportDocument(Dictionary<String, Object> param, String printouttype)
        {
            ReportDocument rviewer = new ReportDocument();
            //rviewer = new SDRR_program.Report.crtNUDRegister();
            rviewer.Database.Tables[0].SetDataSource(printableData["main"]);
            rviewer.SetParameterValue("clientname", param["client"]);
            rviewer.SetParameterValue("cycle", param["cycle"]);
            rviewer.SetParameterValue("branch", param["branch"]);

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
