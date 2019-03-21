using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.OleDb;
using DevComponents.DotNetBar.SuperGrid;

namespace NewSDRR
{
    public partial class SDRRInvoicePickingControls : UserControl
    {
        String[] _clientname;
        public Dictionary<String, List<String>> _invoice { get; set; }
        DataTable invoicedata = new DataTable();
        #region Initialize Form
        public SDRRInvoicePickingControls(string[] clientname,Dictionary<String, List<String>> invoice)
        {
            InitializeComponent();
            _clientname = clientname;
            _invoice = invoice;
            InitializeGrid();
        }
        private void invoicepickingControls_Load(object sender, EventArgs e)
        {
            if (_clientname[2] == "UPDATE")
            {
                foreach (GridRow item in gridinvoice.PrimaryGrid.Rows)
                {
                    if (item["gridcolindex"].Value.ToString() != "0")
                        gridinvoice.PrimaryGrid.GetCell(item.Index, gridinvoice.PrimaryGrid.Columns["gridcolno"].ColumnIndex).ReadOnly = true;
                }
            }
        }
        #endregion
        #region Commands
        protected override void OnResize(EventArgs e)
        {
            // Center the panel
            panel1.Location = new Point((this.Width - panel1.Width) / 2 - 30, ((this.Height - labelX1.Height - 16) - panel1.Height) / 2 + labelX1.Height + 16);
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
                btnOK.Command = newValue.SDRRCommands.Cancel;
            }
            else
            {
                btnOK.Command = null;
            }
        }
        #endregion
        #region Initialization Grid and Events
        private void InitializeGrid()
        {
            String ConnectionString;
            lblSDRRNo.Text = _clientname[1];
            lblpath.Text = "";
            invoicedata.Columns.Add(new DataColumn("gridcolno", typeof(Boolean)));
            invoicedata.Columns.Add(new DataColumn("gridcolinvno", typeof(string)));
            invoicedata.Columns.Add(new DataColumn("gridcolamt", typeof(string)));
            invoicedata.Columns.Add(new DataColumn("Invoice_Date", typeof(string)));
            invoicedata.Columns.Add(new DataColumn("gridcolcust", typeof(string)));
            invoicedata.Columns.Add(new DataColumn("gridcolzone", typeof(string)));
            invoicedata.Columns.Add(new DataColumn("Term", typeof(string)));
            invoicedata.Columns.Add(new DataColumn("gridcolindex", typeof(string)));

            if (Utils.ClientConnection.ContainsKey(_clientname[0]))
            {
                if (Utils.ClientConnection[_clientname[0]]["DBTYPE"] == "DOS")
                {
                    try
                    {
                        ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = {0};Extended Properties =dBase IV;", Utils.ClientConnection[_clientname[0]]["Directory"]);
                        MessageBox.Show(ConnectionString);
                        using (OleDbConnection dBaseConnection = new OleDbConnection(ConnectionString))
                        {
                            MessageBox.Show(ConnectionString);
                            dBaseConnection.Open();
                            System.Data.OleDb.OleDbCommand dBaseCommand;
                            dBaseCommand = new System.Data.OleDb.OleDbCommand("SELECT TERM, ZONEFLAG, SINUMBER, SIDATE, GROSSAMT, CUSTNAME FROM SIMASTER ORDER BY sidate DESC", dBaseConnection);
                            System.Data.OleDb.OleDbDataReader dBaseDataReader;
                            dBaseDataReader = dBaseCommand.ExecuteReader();
                            while (dBaseDataReader.Read())
                            {
                                DataRow tblRow = invoicedata.NewRow();
                                tblRow["gridcolno"] = false;
                                tblRow["term"] = dBaseDataReader["term"];
                                tblRow["gridcolzone"] = dBaseDataReader["zoneflag"];
                                tblRow["gridcolinvno"] = dBaseDataReader["sinumber"];
                                tblRow["invoice_date"] = dBaseDataReader["sidate"];
                                tblRow["gridcolamt"] = dBaseDataReader["grossamt"];
                                tblRow["gridcolcust"] = dBaseDataReader["custname"];
                                tblRow["gridcolindex"] = 0;

                                invoicedata.Rows.Add(tblRow);
                            }
                        }
                        lblpath.Text = Utils.ClientConnection[_clientname[0]]["Directory"];
                    }
                    catch (OleDbException ex)
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show(String.Format("{0}:{1}", ex.ErrorCode, ex.Message));
                    }
                }
                else if (Utils.ClientConnection[_clientname[0]]["DBTYPE"] == "SQL")
                {
                    DataSupport.setDBConnection(Utils.ClientConnection[_clientname[0]]["Directory"]);
                    invoicedata = Utils.GetDataTable("SELECT 'false'[gridcolno],R.terms[term],R.zone[gridcolzone],docno[gridcolinvno],R.docdate[invoice_date],grossamt[gridcolamt],c.name[gridcolcust],0[gridcolindex] FROM REPORT_register R join base_customer C ON C._custindex = R.sourcecode WHERE R.DocType = 2 order by convert(datetime, R.docdate, 101) DESC", null);
                }
                else if (Utils.ClientConnection[_clientname[0]]["DBTYPE"] == "SDF")
                {

                }
                if (_invoice.Count >= 1)
                {
                    foreach (KeyValuePair<String, List<String>> item in _invoice)
                    {
                        foreach (DataRow invoice in invoicedata.Select(String.Format("gridcolinvno={0}", item.Value[0])))
                        {
                            invoice["gridcolno"] = true;
                            invoice["gridcolindex"] = item.Value[item.Value.Count - 3];
                            string s = item.Value[item.Value.Count - 3];
                        }
                    }
                }
                gridinvoice.PrimaryGrid.DataSource = invoicedata;
                DataSupport.setDBConnection("Integrated Security=SSPI;Initial Catalog=sdrr;Data Source=.\\SQLEXPRESS; User Id = vgl_data; Password = tqbfjotld;");
            }
        }
        private void gridinvoice_CellValueChanged(object sender, DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs e)
        {
            if (e.GridCell.ColumnIndex == gridinvoice.PrimaryGrid.Columns["gridcolno"].ColumnIndex)
            {
                if (Convert.ToBoolean(e.NewValue))
                {
                    if (!_invoice.ContainsKey(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolinvno"].ColumnIndex).Value.ToString()))
                    {
                        List<String> details = new List<string>();
                        details.Add(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolinvno"].ColumnIndex).Value.ToString());
                        details.Add(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["invoice_date"].ColumnIndex).Value.ToString());
                        details.Add("0");
                        details.Add(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolcust"].ColumnIndex).Value.ToString());
                        details.Add(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolamt"].ColumnIndex).Value.ToString());
                        details.Add("0");
                        details.Add("0");
                        details.Add(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolamt"].ColumnIndex).Value.ToString());
                        details.Add(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolindex"].ColumnIndex).Value.ToString());
                        details.Add(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolzone"].ColumnIndex).Value.ToString());
                        details.Add("C");
                        _invoice.Add(details[0], details);
                    }
                }
                else
                {
                    if (_invoice.ContainsKey(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolinvno"].ColumnIndex).Value.ToString()))
                        _invoice.Remove(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolinvno"].ColumnIndex).Value.ToString());
                }
            }
        }
        #endregion        


    }
}
