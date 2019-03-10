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
    public partial class ListSDRRTransControl : UserControl
    {
        public ListSDRRTransControl()
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
                btnUpdate.Command = newValue.SDRRCommands.ShowTransactionForm;
                btnback.Command = newValue.SDRRCommands.Cancel;
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
            String sql;
            sql = "SELECT DISTINCT PT.sdrrno, SM.[date], SM.client, SM.helper, SM.helper2, SM.driver,SM._sdrrIndex,SM.route,SM.tvalueship,isnull(delstat,'ENROUTE')[delstatus] FROM GLOBAL_sdrrmaster SM JOIN GLOBAL_ProductTrans PT ON SM.sdrrNo = PT.sdrrNo ORDER BY isnull(delstat,'ENROUTE') desc";

            GridPanel panel = grd.PrimaryGrid;
            panel.Rows.Clear();
            foreach (DataRow dRow in Utils.GetDataTable(sql).Rows)
            {
                panel.Rows.Add(new GridRow(dRow["sdrrNo"].ToString()
                    , Convert.ToDateTime(dRow["date"]).ToShortDateString()
                    , dRow["client"].ToString()
                    , dRow["driver"].ToString()
                    , dRow["helper"].ToString()
                    , dRow["helper2"].ToString()
                    , dRow["route"].ToString()
                    , dRow["tvalueship"].ToString()
                    , dRow["delstatus"].ToString()
                    , dRow["_sdrrIndex"].ToString()));
            }
        }
        private void AddGridColumn(GridPanel panel)
        {
            panel.Columns.Clear();
            panel.Rows.Clear();

            GridColumn col = new GridColumn();
            col.Name = "grdColSDRR";
            col.HeaderText = "SDRR Number";
            col.EditorType = typeof(GridLabelEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "grdcoldocdate";
            col.HeaderText = "SDRR Date";
            col.EditorType = typeof(GridLabelEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "grdcolclient";
            col.HeaderText = "Client Name";
            col.EditorType = typeof(GridLabelEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "grdcoldriver";
            col.HeaderText = "Driver";
            col.EditorType = typeof(GridLabelEditControl);
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "grdcolhelper";
            col.HeaderText = "Helper";
            col.EditorType = typeof(GridLabelEditControl);
            col.Visible = (Utils.SDRRListType == "newSDRRtransControl") ? true : false;
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "grdcolhelper2";
            col.HeaderText = "Helper 2";
            col.EditorType = typeof(GridLabelEditControl);
            col.Visible = false;
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "grdcolroute";
            col.HeaderText = "Route";
            col.EditorType = typeof(GridLabelEditControl);
            col.Visible = (Utils.SDRRListType == "newSDRRtransControl") ? true : false;
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "grdcolvalue";
            col.HeaderText = "SDRR Value";
            col.EditorType = typeof(GridLabelEditControl);
            col.Visible = (Utils.SDRRListType == "newSDRRtransControl") ? true : false;
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "grdcolstatus";
            col.HeaderText = "Delivery Status";
            col.EditorType = typeof(GridLabelEditControl);
            col.Visible = (Utils.SDRRListType != "newSDRRtransControl") ? true : false;
            panel.Columns.Add(col);

            col = new GridColumn();
            col.Name = "grdcolindex";
            col.HeaderText = " ";
            col.EditorType = typeof(GridLabelEditControl);
            col.Visible = false;
            panel.Columns.Add(col);
        }

        private void grd_CellClick(object sender, GridCellClickEventArgs e)
        {
            lblsdrrno.Text = grd.PrimaryGrid.GetCell(e.GridCell.RowIndex, grd.PrimaryGrid.Columns["grdColSDRR"].ColumnIndex).Value.ToString();
            lblindex.Text = grd.PrimaryGrid.GetCell(e.GridCell.RowIndex, grd.PrimaryGrid.Columns["grdColindex"].ColumnIndex).Value.ToString();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblindex.Text != "")
                Utils.ListOfActiveControls.Add("UPDATESDRR");
        }
        #endregion
    }
}
