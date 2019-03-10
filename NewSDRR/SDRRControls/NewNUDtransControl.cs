using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace NewSDRR
{
    public partial class NewNUDtransControl : UserControl
    {
        public Decimal totalinvoicev = 0;
        public DataTable printableData;
        public Dictionary<String, List<String>> _invoice { get; set; }
        bool formload = false;
        string _nudindex;
        public string _entrytype;

        #region Form Initialization
        public NewNUDtransControl(String EntryType, String NUDINDEX)
        {
            InitializeComponent();
            _nudindex = NUDINDEX;
            _entrytype = EntryType;
            _invoice = new Dictionary<string, List<string>>();
            Utils.printpreview_formuse = "NewNUDtransControl";
            cboclientname = UIControlSupport.SetComboBoxEx(cboclientname, Utils.GetDataTable("SELECT * FROM base_client ORDER BY clientcode"), "clientcode,clientname", "clientname", "clientcode", AutoCompleteSource.ListItems, AutoCompleteMode.SuggestAppend, ComboBoxStyle.DropDown);
            cboclientname.DropDownWidth = 450;
            cboclientname.DropDownHeight = 150;
            cboclientname.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCustomer = UIControlSupport.SetComboBoxEx(cboCustomer, Utils.GetDataTable("SELECT DISTINCT customer_name,client FROM GLOBAL_producttrans PT JOIN global_sdrrmaster SM ON PT.sdrrno = SM.sdrrno WHERE client = '" + cboclientname.SelectedValue + "' ORDER BY customer_name"), "customer_name", "customer_name", "customer_name", AutoCompleteSource.ListItems, AutoCompleteMode.SuggestAppend, ComboBoxStyle.DropDown);
            cboCustomer.DropDownWidth = 450;
            cboCustomer.DropDownHeight = 150;

            display_NUDColums();
        }
        private void NewNUDtransControl_Load(object sender, EventArgs e)
        {
            formload = true;
            if (_entrytype == "UPDATE")
            {
                ShowNUDDetails();
            }
        }
        #endregion

        #region Commands
        protected override void OnResize(EventArgs e)
        {
            // Center the panel
            panel1.Location = new Point((this.Width - panel1.Width) / 2 + 16, ((this.Height - labelX1.Height - 16) - panel1.Height) / 2 + labelX1.Height + 16);
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
                btnback.Command = newValue.NUDCommands.Cancel;
                btnSave.Command = newValue.NUDCommands.New;
                btnAddInvoices.Command = newValue.NUDCommands.New;
            }
            else
            {
                btnback.Command = null;
                btnSave.Command = null;
                btnAddInvoices.Command = null;
            }
        }
        #endregion

        #region Initialize Grid and Events
        public void display_NUDColums()
        {
            nudgrid.Rows.Clear();
            nudgrid.Columns.Clear();
            DataGridViewLabelXColumn colno = new DataGridViewLabelXColumn();
            colno.HeaderText = "Row #";
            colno.Name = "numberIncrement";
            colno.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nudgrid.Columns.Add(colno);

            DataGridViewTextBoxColumn colinvoice = new DataGridViewTextBoxColumn();
            colinvoice.HeaderText = "sdrrno";
            colinvoice.Name = "sdrrno";
            colinvoice.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nudgrid.Columns.Add(colinvoice);

            colinvoice = new DataGridViewTextBoxColumn();
            colinvoice.HeaderText = "Invoice #";
            colinvoice.Name = "invoice_no";
            colinvoice.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nudgrid.Columns.Add(colinvoice);

            DataGridViewTextBoxColumn colInvoiceValue = new DataGridViewTextBoxColumn();
            colInvoiceValue.HeaderText = "NUD Amount";
            colInvoiceValue.Name = "nudvalue";
            colInvoiceValue.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nudgrid.Columns.Add(colInvoiceValue);

            DataGridViewDateTimeInputColumn colnumber = new DataGridViewDateTimeInputColumn();
            colnumber.HeaderText = "Invoice Date";
            colnumber.Name = "invoice_date";
            colnumber.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            colnumber.ButtonClear.Checked = true;
            colnumber.ButtonClear.Visible = true;
            colnumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colnumber.ReadOnly = true;
            nudgrid.Columns.Add(colnumber);

            DataGridViewComboBoxExColumn colreason = new DataGridViewComboBoxExColumn();
            colreason.HeaderText = "Reason";
            colreason.Name = "reason";
            colreason.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nudgrid.Columns.Add(colreason);

            DataGridViewComboBoxExColumn colstat = new DataGridViewComboBoxExColumn();
            colstat.HeaderText = "Delivery Status";
            colstat.Name = "delstat";
            colstat.Items.Add("CANCELLED");
            colstat.Items.Add("CUT-ITEMS");
            colstat.Items.Add("FULL-RETURN");
            colstat.Items.Add("RE-DELIVERY");
            colstat.DropDownStyle = ComboBoxStyle.DropDownList;
            colstat.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nudgrid.Columns.Add(colstat);

            colstat = new DataGridViewComboBoxExColumn();
            colstat.HeaderText = "Accountability";
            colstat.Name = "account";
            colstat.Items.Add("CLIENT");
            colstat.Items.Add("VGL");
            colstat.DropDownStyle = ComboBoxStyle.DropDownList;
            colstat.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nudgrid.Columns.Add(colstat);

            DataGridViewTextBoxColumn colzone = new DataGridViewTextBoxColumn();
            colzone.HeaderText = "zone";
            colzone.Name = "zone";
            colzone.Visible = false;
            colzone.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nudgrid.Columns.Add(colzone);

            DataGridViewTextBoxColumn colTindex = new DataGridViewTextBoxColumn();
            colTindex.HeaderText = "Index";
            colTindex.Name = "index";
            colTindex.Visible = false;
            colTindex.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nudgrid.Columns.Add(colTindex);

            nudgrid.Columns["numberIncrement"].Width = 35;
            nudgrid.Columns["invoice_date"].Width = 80;
            nudgrid.Columns["delstat"].Width = 160;
            nudgrid.Columns["account"].Width = 130;
            nudgrid.Columns["reason"].Width = 250;
        }

        public void ShowNUDDetails()
        {
            try
            {
                this.Text = "Update UnAccepted Delivery";
                foreach (DataRow dRow in Utils.GetDataTable("SELECT Top 1 * FROM global_NUD WHERE _nudindex = '" + _nudindex + "'", null).Rows)
                {
                    dtdelivered.Value = Convert.ToDateTime(dRow["deldate"]);
                    dtprepared.Value = Convert.ToDateTime(dRow["dateprepared"]);
                    txtdelman.Text = dRow["delman"].ToString();
                    cboclientname.SelectedValue = dRow["clientname"].ToString();
                    cboCustomer.Text = dRow["customer_name"].ToString();
                    cboTerms.Text = dRow["terms"].ToString();
                    foreach (DataRow dRow_details in Utils.GetDataTable("SELECT * FROM global_NUDdetails WHERE nudindex = '" + _nudindex + "'", null).Rows)
                    {
                        String[] addRow = new String[nudgrid.ColumnCount];
                        addRow[nudgrid.Columns["invoice_no"].Index] = dRow_details["invoice_no"].ToString();
                        addRow[nudgrid.Columns["nudvalue"].Index] = dRow_details["amount"].ToString();
                        addRow[nudgrid.Columns["invoice_date"].Index] = dRow_details["invoice_date"].ToString();
                        addRow[nudgrid.Columns["reason"].Index] = dRow_details["reason"].ToString();
                        addRow[nudgrid.Columns["delstat"].Index] = dRow_details["delstat"].ToString();
                        addRow[nudgrid.Columns["account"].Index] = dRow_details["paidby"].ToString();
                        addRow[nudgrid.Columns["sdrrno"].Index] = dRow_details["sdrrno"].ToString();
                        addRow[nudgrid.Columns["index"].Index] = dRow_details["_index"].ToString();
                        nudgrid.Rows.Add(addRow);

                        String search = String.Format("{0}-{1}", dRow_details["sdrrno"].ToString(), dRow_details["invoice_no"].ToString());
                        List<String> details = new List<string>();
                        details.Add(dRow_details["sdrrno"].ToString());
                        details.Add(dRow_details["invoice_no"].ToString());
                        details.Add(dRow_details["amount"].ToString());
                        details.Add(dRow_details["invoice_date"].ToString());
                        details.Add(dRow_details["reason"].ToString());
                        details.Add(dRow_details["delstat"].ToString());
                        details.Add(dRow_details["paidby"].ToString());
                        details.Add("0");//zone?
                        details.Add(dRow_details["_index"].ToString());
                        _invoice.Add(search, details);

                    }
                    compute();
                }    
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message, "Error!", MessageBoxButtons.OK);
            }
        }
        private void compute()
        {
            totalinvoicev = 0;

            foreach (DataGridViewRow dRow in nudgrid.Rows)
            {
                nudgrid.Rows[dRow.Index].Cells["numberIncrement"].Value = dRow.Index + 1;
                totalinvoicev += Convert.ToDecimal(dRow.Cells["nudvalue"].Value);
            }
        }

        public void InitializeDataGrid()
        {
            int coutrow = 1;
            nudgrid.Rows.Clear();
            foreach (KeyValuePair<String, List<String>> item in _invoice)
            {
                DataGridViewRow gRow = (DataGridViewRow)nudgrid.RowTemplate.Clone();
                gRow.CreateCells(nudgrid);

                gRow.Cells[nudgrid.Columns["numberIncrement"].Index].Value = coutrow;
                gRow.Cells[nudgrid.Columns["sdrrno"].Index].Value = item.Value[0];
                gRow.Cells[nudgrid.Columns["invoice_no"].Index].Value = item.Value[1];
                gRow.Cells[nudgrid.Columns["nudvalue"].Index].Value = item.Value[2];
                gRow.Cells[nudgrid.Columns["invoice_date"].Index].Value = item.Value[3];
                gRow.Cells[nudgrid.Columns["reason"].Index].Value = item.Value[4];
                gRow.Cells[nudgrid.Columns["delstat"].Index].Value = item.Value[5];
                gRow.Cells[nudgrid.Columns["account"].Index].Value = item.Value[6];
                gRow.Cells[nudgrid.Columns["zone"].Index].Value = item.Value[7];
                gRow.Cells[nudgrid.Columns["index"].Index].Value = item.Value[8];
                nudgrid.Rows.Add(gRow);
                coutrow++;
            }        
        }
        #endregion

        #region Saving and Updating
        private void btnSave_Click(object sender, EventArgs e)
        {
            Utils.ListOfActiveControls.Add("PRINT");
            printableData = getPrintableData(nudgrid);
        }

        public bool save()
        {
            try
            {
                if (!validateentry())
                    return false;

                Dictionary<String, Object> Params = new Dictionary<String, Object>();
                Params.Add("customer_name", cboCustomer.Text);
                Params.Add("totalamount", totalinvoicev);
                Params.Add("terms", cboTerms.Text);
                Params.Add("clientname", cboclientname.SelectedValue);
                Params.Add("deldate", dtdelivered.Value.ToShortDateString());
                Params.Add("dateprepared", dtprepared.Value.ToShortDateString());
                Params.Add("datestamp", DateTime.Now.Date);
                Params.Add("delman", txtdelman.Text);
                string sql = DataSupport.GetInsert("global_NUD", Params);

                foreach (DataGridViewRow row in nudgrid.Rows)
                {
                    if (row.IsNewRow) continue;
                    Dictionary<String, Object> Param1 = new Dictionary<String, Object>();
                    Param1.Add("nudindex", "MAX(_nudindex)");
                    Param1.Add("invoice_no", row.Cells["invoice_no"].Value.ToString().Trim());
                    Param1.Add("invoice_date", row.Cells["invoice_date"].Value.ToString().Trim());
                    Param1.Add("amount", row.Cells["nudvalue"].Value.ToString().Trim());
                    Param1.Add("reason", row.Cells["reason"].Value.ToString().Trim());
                    Param1.Add("delstat", row.Cells["delstat"].Value.ToString().Trim());
                    Param1.Add("datestamp", DateTime.Now.Date);
                    Param1.Add("paidby", row.Cells["account"].Value.ToString().Trim());
                    Param1.Add("sdrrno", row.Cells["sdrrno"].Value.ToString().Trim());

                    sql += DataSupport.GetInsertUsingSelect("global_NUDDetails", Param1, "global_nud");
                }
                Utils.ExecuteNonQuery(sql, null);
                DevComponents.DotNetBar.MessageBoxEx.Show("Save Complete");
                return true;
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message + " \n Please Report this to the programmer!");
                return false;
            }
        }

        public bool update()
        {
            try
            {

                Dictionary<String, Object> Params = new Dictionary<String, Object>();
                Params.Add("_nudindex", _nudindex);
                Params.Add("customer_name", cboCustomer.Text);
                Params.Add("totalamount", totalinvoicev);
                Params.Add("terms", cboTerms.Text);
                Params.Add("clientname", cboclientname.SelectedValue);
                Params.Add("deldate", dtdelivered.Value.ToShortDateString());
                Params.Add("dateprepared", dtprepared.Value.ToShortDateString());
                Params.Add("datestamp", DateTime.Now.Date);
                Params.Add("delman", txtdelman.Text);

                List<String> primary = new List<String>();
                primary.Add("_nudindex");

                string sql = DataSupport.GetUpdate("global_NUD", Params, primary);

                foreach (DataGridViewRow row in nudgrid.Rows)
                {
                    if (row.IsNewRow) continue;
                    Dictionary<String, Object> Param1 = new Dictionary<String, Object>();
                    Param1.Add("_index", row.Cells["index"].Value.ToString().Trim());
                    Param1.Add("invoice_no", row.Cells["invoice_no"].Value.ToString().Trim());
                    Param1.Add("invoice_date", row.Cells["invoice_date"].Value.ToString().Trim());
                    Param1.Add("amount", row.Cells["nudvalue"].Value.ToString().Trim());
                    Param1.Add("reason", row.Cells["reason"].Value.ToString().Trim());
                    Param1.Add("delstat", row.Cells["delstat"].Value.ToString().Trim());
                    Param1.Add("datestamp", DateTime.Now.Date);
                    Param1.Add("paidby", row.Cells["account"].Value.ToString().Trim());
                    Param1.Add("sdrrno", row.Cells["sdrrno"].Value.ToString().Trim());

                    primary = new List<String>();
                    primary.Add("_index");

                    sql += DataSupport.GetUpdate("global_NUDDetails", Param1, primary);
                }
                Utils.ExecuteNonQuery(sql, null);
                DevComponents.DotNetBar.MessageBoxEx.Show("Update Complete");
                return true;
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message + " \n Please Report this to the programmer!");
                return false;
            }
        }

        public bool validateentry()
        {
            bool result = false;
            string error = "";

            if (dtdelivered.Text == "")
                error += "Missing Date Delivered\n";
            else if (dtprepared.Text == "")
                error += "Missing Date Prepared\n";
            else if (txtdelman.Text == "")
                error += "Missing Delivery Man\n";
            else if (cboCustomer.Text.Trim().Length <= 0)
                error += "Missing Customer Name\n";
            else if (cboTerms.Text.Trim().Length <= 0)
                error += "Missing Terms\n";
            else if (nudgrid.Rows.Count == 1)
                error += "Missing Grid Details\n";

            foreach (DataGridViewRow dRow in nudgrid.Rows)
            {
                if (dRow.Index == nudgrid.Rows.Count - 1)
                    break;
                if (dRow.Cells["invoice_no"].Value == null)
                    error += "Row #" + (dRow.Index + 1) + " Invoice Number missing\n";
                if (dRow.Cells["nudvalue"].Value == null)
                    error += "Row #" + (dRow.Index + 1) + " Invoice value missing\n";
                if (dRow.Cells["invoice_date"].Value.ToString() == "")
                    error += "Row #" + (dRow.Index + 1) + " Invoice Date missing\n";
                if (dRow.Cells["reason"].Value == null)
                    error += "Row #" + (dRow.Index + 1) + " Reason missing\n";
                if (dRow.Cells["delstat"].Value == null)
                    error += "Row #" + (dRow.Index + 1) + " Delivery Status missing\n";
                if (dRow.Cells["account"].Value == null)
                    error += "Row #" + (dRow.Index + 1) + " Accountability missing\n";
                if (dRow.Cells["sdrrno"].Value == null)
                    error += "Row #" + (dRow.Index + 1) + " Delivery Attempts missing\n";
            }

            if (error == "")
                result = true;
            else
            {
                error += "Please check your entry data!\n";
                DevComponents.DotNetBar.MessageBoxEx.Show(error, "Message", MessageBoxButtons.OK);
            }

            return result;
        }     

        #endregion
        #region Buttons
        private void btnAddReason_Click(object sender, EventArgs e)
        {
            NewReasonForm reason = new NewReasonForm();
            reason.StartPosition = FormStartPosition.CenterScreen;
            reason.ShowDialog();
        }

        private void btnAddInvoices_Click(object sender, EventArgs e)
        {
            Utils.ListOfActiveControls.Add("NUDINVOICEPICK");
        }
        #endregion

        private DataTable getPrintableData(DataGridView sdrrgrid)
        {
            System.Data.DataTable result = new System.Data.DataTable();
            result.Columns.Add(new DataColumn("invoice_no", typeof(string)));
            result.Columns.Add(new DataColumn("invoice_date", typeof(string)));
            result.Columns.Add(new DataColumn("amount", typeof(Decimal)));
            result.Columns.Add(new DataColumn("reason", typeof(string)));
            result.Columns.Add(new DataColumn("delstat", typeof(string)));
            result.Columns.Add(new DataColumn("paidby", typeof(string)));
            result.Columns.Add(new DataColumn("attempts", typeof(string)));

            DataRow resultRow = result.NewRow();
            int rowindex = 0;
            foreach (DataGridViewRow dRow in sdrrgrid.Rows)//gi sud ang mga value sa result row
            {
                if (dRow.Index == sdrrgrid.Rows.Count - 1)
                    break;
                resultRow = result.NewRow();

                resultRow["invoice_no"] = dRow.Cells["invoice_no"].Value.ToString();
                resultRow["invoice_date"] = Convert.ToDateTime(dRow.Cells["invoice_date"].Value.ToString()).ToShortDateString();
                if (dRow.Cells["nudvalue"].Value != null)
                    resultRow["amount"] = dRow.Cells["nudvalue"].Value.ToString();
                else
                    resultRow["amount"] = 0;

                resultRow["reason"] = dRow.Cells["reason"].Value.ToString();
                resultRow["delstat"] = dRow.Cells["delstat"].Value.ToString();
                resultRow["paidby"] = dRow.Cells["account"].Value.ToString();
                resultRow["attempts"] = dRow.Cells["sdrrno"].Value.ToString();

                result.Rows.Add(resultRow);
                rowindex += 1;
            }

            return result;
        }

        private void cboclientname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formload)
            {
                cboCustomer = UIControlSupport.SetComboBoxEx(cboCustomer, Utils.GetDataTable("SELECT DISTINCT customer_name,client FROM GLOBAL_producttrans PT JOIN global_sdrrmaster SM ON PT.sdrrno = SM.sdrrno WHERE client = '" + cboclientname.SelectedValue + "' ORDER BY customer_name"), "customer_name", "customer_name", "customer_name", AutoCompleteSource.ListItems, AutoCompleteMode.SuggestAppend, ComboBoxStyle.DropDown);
                cboCustomer.DropDownWidth = 450;
                cboCustomer.DropDownHeight = 150;
            }
        }

        private void nudgrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (nudgrid.CurrentCell.ColumnIndex == nudgrid.Columns["reason"].Index)
            {
                ((ComboBoxEx)e.Control).DataSource = Utils.GetDataTable("SELECT distinct reason FROM base_reason", null);
                ((ComboBoxEx)e.Control).DisplayMember = "reason";
                ((ComboBoxEx)e.Control).ValueMember = "reason";
                ((ComboBoxEx)e.Control).DropDownStyle = ComboBoxStyle.DropDownList;
                ((ComboBoxEx)e.Control).Width = 350;
            }
        }       
    }
}
