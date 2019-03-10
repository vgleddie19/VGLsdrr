using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;

namespace NewSDRR
{
    public partial class NUDInvoicePickingControl : UserControl
    {
        String[] _param;
        public Dictionary<String, List<String>> _invoice { get; set; }
        DataTable invoicedata = new DataTable();

        #region Form Initialization
        public NUDInvoicePickingControl(string[] param ,Dictionary<String, List<String>> invoice)
        {
            InitializeComponent();
            _param = param;
            _invoice = invoice;
            InitializeGrid();
        }
        
        private void SDRRInvoicePickingControl_Load(object sender, EventArgs e)
        {
            if (_param[2] == "UPDATE")
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
                btnOK.Command = newValue.NUDCommands.Cancel;
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
            lblSDRRNo.Text = _param[0];
            lblpath.Text = _param[0];
            invoicedata = Utils.GetDataTable(String.Format("SELECT '0'[gridcolno],PT.sdrrno[gridcolsdrrno],PT.invoice_no[gridcolinv],PT.customer_name[gridcolcust], SM.tvalueship[gridcolamt], PT.Zone[gridcolzone],PT.invoice_date[gridcolinvdate],'0'[gridcolindex] FROM GLOBAL_sdrrmaster SM JOIN GLOBAL_ProductTrans PT ON SM.sdrrNo = PT.sdrrNo WHERE SM.[client] = '{0}' AND customer_name = '{1}'", _param[0], _param[1]), null);
            if (_invoice.Count >= 1)
            {
                foreach (KeyValuePair<String, List<String>> item in _invoice)
                {
                    foreach (DataRow invoice in invoicedata.Select(String.Format("gridcolinv= {1} and gridcolsdrrno = {0}", item.Value[0], item.Value[1])))
                    {
                        invoice["gridcolno"] = true;
                        invoice["gridcolindex"] = item.Value[item.Value.Count - 1];
                    }
                }
            }
            gridinvoice.PrimaryGrid.DataSource = invoicedata;
        }
        private void gridinvoice_CellValueChanged(object sender, DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs e)
        {
            if (e.GridCell.ColumnIndex == gridinvoice.PrimaryGrid.Columns["gridcolno"].ColumnIndex)
            {
                String search = String.Format("{0}-{1}", gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolsdrrno"].ColumnIndex).Value.ToString(), gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolinv"].ColumnIndex).Value.ToString());
                if (Convert.ToBoolean(e.NewValue))
                {
                    if (!_invoice.ContainsKey(search))
                    {
                        List<String> details = new List<string>();
                        details.Add(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolsdrrno"].ColumnIndex).Value.ToString());
                        details.Add(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolinv"].ColumnIndex).Value.ToString());
                        details.Add("0");
                        details.Add(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolinvdate"].ColumnIndex).Value.ToString());
                        details.Add("");
                        details.Add("");
                        details.Add("");
                        details.Add("");
                        details.Add(gridinvoice.PrimaryGrid.GetCell(e.GridCell.RowIndex, gridinvoice.PrimaryGrid.Columns["gridcolzone"].ColumnIndex).Value.ToString());
                        details.Add("0");
                        _invoice.Add(search, details);
                    }
                }
                else
                {
                    if (_invoice.ContainsKey(search))
                        _invoice.Remove(search);
                }
            }
        }
        #endregion  

    }
}
