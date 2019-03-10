using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;

namespace NewSDRR
{
    public partial class ListNUDTransControl : UserControl
    {
        public ListNUDTransControl()
        {
            InitializeComponent();
            PopulateDatagrid();
        }
        #region Commands
        protected override void OnResize(EventArgs e)
        {
            // Center the panel
            panel2.Location = new Point((this.Width - panel2.Width) / 2 , (this.Height - panel2.Height) / 2 + labelX1.Height - 25);
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
                btnUpdate.Command = newValue.NUDCommands.ShowTransactionForm;
                btnback.Command = newValue.NUDCommands.Cancel;
            }
            else
            {
                btnUpdate.Command = null;
            }
        }
        #endregion

        #region Initialize Grid and Events
        private void PopulateDatagrid()
        {
            AddGridColumn(grd.PrimaryGrid);
            grd.PrimaryGrid.DataSource = Utils.GetDataTable("SELECT _nudindex,clientname,customer_name,totalamount,dateprepared FROM GLOBAL_nud");
        }
        private void AddGridColumn(GridPanel panel)
        {
            panel.Columns.Clear();
            panel.Rows.Clear();

            GridColumn col = new GridColumn();
            col.Name = "_nudindex";
            col.HeaderText = "NUD Number";
            col.EditorType = typeof(GridLabelEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "clientname";
            col.HeaderText = "Client Name";
            col.EditorType = typeof(GridLabelEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "customer_name";
            col.HeaderText = "Customer Name";
            col.EditorType = typeof(GridLabelEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "dateprepared";
            col.HeaderText = "Date Prepared";
            col.EditorType = typeof(GridLabelEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "totalamount";
            col.HeaderText = "NUD Amount";
            col.EditorType = typeof(GridLabelEditControl);
            panel.Columns.Add(col);
        }

        private void grd_CellClick(object sender, GridCellClickEventArgs e)
        {
            lblnudindex.Text = grd.PrimaryGrid.GetCell(e.GridCell.RowIndex, grd.PrimaryGrid.Columns["_nudindex"].ColumnIndex).Value.ToString();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblnudindex.Text != "")
                Utils.ListOfActiveControls.Add("UPDATENUD");
        }
        #endregion
    }
}
