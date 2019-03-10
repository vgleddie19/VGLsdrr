using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System.Threading;

namespace NewSDRR
{
    public partial class newSDRRtransControl : DevComponents.DotNetBar.Controls.SlidePanel
    {
        #region Variables
        public string _entrytype;
        private string _sdrrindex;
        private bool MaxRows = false;
        public Dictionary<String, List<String>> _invoice { get; set; }
        Dictionary<String, Object> Param = new Dictionary<String, Object>();
        Dictionary<String, DataRow> EncodedInvoice = new Dictionary<String, DataRow>();
        Dictionary<String, DataRow> Driver = new Dictionary<String, DataRow>();
        Dictionary<String, DataRow> Helper = new Dictionary<String, DataRow>();
        List<String> Customer = new List<String>();
        public DataTable printableData;
        public String clientuse { get; set; }
        int oldindex = 0;        
        #endregion
        
        #region Form Initialization
        public newSDRRtransControl(String EntryType, String SDRRINDEX)
        {
            InitializeComponent();            
            _invoice = new Dictionary<string, List<string>>();
            _entrytype = EntryType;
            _sdrrindex = SDRRINDEX;

            Dictionary<String, String> conn = new Dictionary<String, String>();
            Utils.DBConnection.TryGetValue("DISPATCH", out conn);
            DataSupport.setDBConnection("Initial Catalog=" + conn["DatabaseName"].ToString() + ";Data Source=" + conn["Server"].ToString() + "\\SQLEXPRESS; User Id = vgl_data; Password = tqbfjotld;");
            if (DataSupport.CheckDBConnectivity() == 0)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Can't Connect to Dispatch!\n Please report this to the hardware specialist", "Error!", MessageBoxButtons.OK); return;
            }
            else
            {
                cboVehl.DataSource = Utils.GetDataset("SELECT _vehlindex,(VehlCode + ' ' + Maker) AS DISP FROM BASE_Vehicle WHERE TripType = 1").Tables[0];
                cboVehl = UIControlSupport.SetComboBox(cboVehl, "DISP", "DISP", AutoCompleteSource.ListItems, AutoCompleteMode.SuggestAppend, ComboBoxStyle.DropDown);
            }

            Utils.printpreview_formuse = "newSDRRtransControl";
            DataSupport.setDBConnection("Integrated Security=SSPI;Initial Catalog=sdrr;Data Source=.\\SQLEXPRESS; User Id = vgl_data; Password = tqbfjotld;");

            _invoice = new Dictionary<string, List<string>>();
            Driver = Utils.BuildIndex("[dbo].[sp_BASE_GetDriver]", "name", null);
            Helper = Utils.BuildIndex("[dbo].[sp_BASE_GetHelper]", "name", null);
            EncodedInvoice = Utils.BuildIndex_SQL("SELECT * FROM GLOBAL_ProductTrans WHERE delstat = 'DELIVERED' or delstat = ''", "INVOICE_NO");

            cboDriver.DataSource = Utils.ExecuteStoredProcedure("[dbo].[sp_BASE_GetDriver]", null);
            cboDriver.DisplayMember = "name";
            cboDriver.ValueMember = "_DriverHelperIndex";

            cboHelper.DataSource = Utils.ExecuteStoredProcedure("[dbo].[sp_BASE_GetHelper]", null);
            cboHelper.DisplayMember = "name";
            cboHelper.ValueMember = "_DriverHelperIndex";

            cboHelper2.DataSource = Utils.ExecuteStoredProcedure("[dbo].[sp_BASE_GetHelper]", null);
            cboHelper2.DisplayMember = "name";
            cboHelper2.ValueMember = "_DriverHelperIndex";
            cboHelper2.Text = "";
            cboHelper.Text = "";

            cboClient = UIControlSupport.SetComboBoxEx(cboClient, Utils.GetDataTable("SELECT * FROM base_client ORDER BY clientcode"), "clientcode,clientname", "clientname", "clientcode", AutoCompleteSource.ListItems, AutoCompleteMode.SuggestAppend, ComboBoxStyle.DropDown);
            cboClient.DropDownWidth = 450;
            cboClient.DropDownHeight = 150;
            cboClient.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClient.SelectedIndexChanged += new System.EventHandler(this.cboClient_SelectedIndexChanged);
            
            display_sdrrColums();
            if (_entrytype == "UPDATE")
            {
                ShowSDRRDetails();
            }
            //btnback.colort
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
                btnbacksdrrmenu.Command = newValue.SDRRCommands.Cancel;
                btninvoice.Command = newValue.SDRRCommands.New;
                btnregprint.Command = newValue.SDRRCommands.New;
                btnmatrixprint.Command = newValue.SDRRCommands.New;
            }
            else
            {
                btnregprint.Command = null;
                btnbacksdrrmenu.Command = null;
                btninvoice.Command = null;
                btnmatrixprint.Command = null;
            }
        }
        #endregion

        #region Buttons
        private void btnProceed_Click(object sender, EventArgs e)
        {
            Param = new Dictionary<String, Object>();
            Param.Add("@sdrrNo", sdrrNoTxt.Text);
            if (_entrytype == "SAVE")
            {
                if (Convert.ToInt32(Utils.ExecuteStoredProcedure("[dbo].[sp_BASE_CheckSDRRNO]", Param).Rows[0][0]) == 1)
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("SDRR No. " + sdrrNoTxt.Text.ToString() + " ALREADY EXIST", "Message", MessageBoxButtons.OK);
                    sdrrNoTxt.SelectAll();
                    sdrrNoTxt.Focus();
                    return;
                }
            }
            if (sdrrNoTxt.Text.Trim() == "")
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Empty SDRR No.", "Message", MessageBoxButtons.OK);
                sdrrNoTxt.Focus();
                return;
            }
            String RowErrorMessages = "";
            if(gridsdrr.Rows.Count == 1)
                RowErrorMessages = RowErrorMessages + "Empty Grid";

            foreach (DataGridViewRow row in gridsdrr.Rows)
            {
                if (row.IsNewRow) continue;
                if (Convert.ToString(row.Cells["cboInvoice"].Value) == string.Empty)
                    RowErrorMessages = RowErrorMessages + "Empty Invoice Number in Row #" + (row.Index + 1);
                if (Convert.ToString(row.Cells["numberOfcartons"].Value) == string.Empty)
                    RowErrorMessages = RowErrorMessages + "Empty Invoice Number in Row #" + row.Index;
                if (Convert.ToString(row.Cells["custname"].Value) == string.Empty)
                    RowErrorMessages = RowErrorMessages + "\n Empty Customer Name in Row #" + (row.Index + 1);
                if (Convert.ToString(row.Cells["pdcamt"].Value) == string.Empty)
                    RowErrorMessages = RowErrorMessages + "\n Empty PDC Amount in Row #" + (row.Index + 1);
                if (Convert.ToString(row.Cells["codamt"].Value) == string.Empty)
                    RowErrorMessages = RowErrorMessages + "\n Empty COD Amount in Row #" + (row.Index + 1);
                if (Convert.ToString(row.Cells["pdcamount1"].Value) == string.Empty)
                    RowErrorMessages = RowErrorMessages + "\n Empty PDC/30Days Amount in Row #" + (row.Index + 1);
            }

            if (RowErrorMessages != "") { DevComponents.DotNetBar.MessageBoxEx.Show(RowErrorMessages, "Message", MessageBoxButtons.OK); }
            else
            {
                panel1.Location = new Point(878, 438);
                page2form.Location = new Point((this.Width - page2form.Width) / 2 - 30, (this.Height - page2form.Height) / 2 + labelX1.Height); ;
                panel1.Enabled = false;
                panel1.Visible = false;
                page2form.Enabled = true;
                page2form.Visible = true;
                prepbtTxt.Focus();
            }

        }
        private void btnback_Click(object sender, EventArgs e)
        {
            panel1.Location = new Point(878, 438);
            panel1.Location = new Point((this.Width - panel1.Width) / 2, (this.Height - panel1.Height) / 2 + labelX1.Height);
            panel1.Enabled = true;
            panel1.Visible = true;
            page2form.Enabled = false;
            page2form.Visible = false;
            prepbtTxt.Focus();
        }
        #endregion

        #region Initialize Grid and Events

        public void display_sdrrColums()
        {
            gridsdrr.Rows.Clear();
            gridsdrr.Columns.Clear();
            DataGridViewLabelXColumn colno = new DataGridViewLabelXColumn();
            colno.HeaderText = "#";
            colno.Name = "numberIncrement";
            colno.Width = 20;
            gridsdrr.Columns.Add(colno);

            DataGridViewComboBoxExColumn colinvoice = new DataGridViewComboBoxExColumn();
            colinvoice.HeaderText = "Invoice #";
            colinvoice.Name = "cboInvoice";
            colinvoice.MaxDropDownItems = 4;            
            colinvoice.DisplayMember = "DocNo";
            colinvoice.ValueMember = "DocNo";
            colinvoice.DropDownStyle = ComboBoxStyle.DropDown;
            colinvoice.AutoCompleteSource = AutoCompleteSource.ListItems;
            colinvoice.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            colinvoice.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridsdrr.Columns.Add(colinvoice);

            DataGridViewDateTimeInputColumn colnumber = new DataGridViewDateTimeInputColumn();
            colnumber.HeaderText = "Invoice Date";
            colnumber.Name = "invoice_date";
            colnumber.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            colnumber.ButtonClear.Checked = true;
            colnumber.ButtonClear.Visible = true;
            colnumber.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridsdrr.Columns.Add(colnumber);


            DataGridViewTextBoxColumn colnumbers = new DataGridViewTextBoxColumn();
            colnumbers.HeaderText = "# OF CARTONS";
            colnumbers.Name = "numberOfcartons";
            colnumbers.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridsdrr.Columns.Add(colnumbers);

            DataGridViewComboBoxExColumn colcustname = new DataGridViewComboBoxExColumn();
            colcustname.HeaderText = "CUSTOMER'S NAME";
            colcustname.Name = "custname";
            colcustname.Width = 100;
            colcustname.MaxDropDownItems = 4;
            colcustname.DisplayMember = "customer_name";
            colcustname.ValueMember = "customer_name";
            colcustname.DropDownStyle = ComboBoxStyle.DropDown;
            colcustname.AutoCompleteSource = AutoCompleteSource.ListItems;
            colcustname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            colcustname.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridsdrr.Columns.Add(colcustname);

            DataGridViewTextBoxColumn colpdc = new DataGridViewTextBoxColumn();
            colpdc.HeaderText = "PDC AMOUNT";
            colpdc.Name = "pdcamt";
            colno.Width = 100;
            colpdc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridsdrr.Columns.Add(colpdc);

            DataGridViewTextBoxColumn colcodamt = new DataGridViewTextBoxColumn();
            colcodamt.HeaderText = "C.O.D AMOUNT";
            colcodamt.Name = "codamt";
            colno.Width = 100;
            colcodamt.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridsdrr.Columns.Add(colcodamt);

            DataGridViewTextBoxColumn coldpdcamt1 = new DataGridViewTextBoxColumn();
            coldpdcamt1.HeaderText = "PDC/30DAYS AMOUNT";
            coldpdcamt1.Name = "pdcamount1";
            colno.Width = 100;
            coldpdcamt1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridsdrr.Columns.Add(coldpdcamt1);

            DataGridViewLabelXColumn colInvoiceValue = new DataGridViewLabelXColumn();
            colInvoiceValue.HeaderText = "INVOICE VALUE";
            colInvoiceValue.Name = "invoicevalue";
            colInvoiceValue.Width = 90;
            colno.Width = 100;
            colInvoiceValue.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridsdrr.Columns.Add(colInvoiceValue);

            DataGridViewTextBoxColumn colTindex = new DataGridViewTextBoxColumn();
            colTindex.HeaderText = "Index";
            colTindex.Name = "index";
            colTindex.Width = 90;
            colTindex.Visible = false;
            colTindex.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridsdrr.Columns.Add(colTindex);

            DataGridViewTextBoxColumn colZone = new DataGridViewTextBoxColumn();
            colZone.HeaderText = "Zone";
            colZone.Name = "zone";
            colZone.Width = 40;
            colZone.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridsdrr.Columns.Add(colZone);

            gridsdrr.Columns["numberIncrement"].Width = 20;
            gridsdrr.Columns["cboInvoice"].Width = 70;
            gridsdrr.Columns["numberOfcartons"].Width = 70;
            gridsdrr.Columns["custname"].Width = 250;
            gridsdrr.Columns["pdcamt"].Width = 80;
            gridsdrr.Columns["codamt"].Width = 80;
            gridsdrr.Columns["pdcamount1"].Width = 80;
            gridsdrr.Columns["invoicevalue"].Width = 100;
            gridsdrr.Columns["zone"].Width = 50;

            DataGridViewTextBoxColumn colCovered = new DataGridViewTextBoxColumn();
            colCovered.HeaderText = "C/NC";
            colCovered.Name = "isCovered";
            colCovered.Visible = false;
            colCovered.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridsdrr.Columns.Add(colCovered);

            if (cboClient.SelectedValue.ToString() == "ABBOTT" || cboClient.SelectedValue.ToString() == "ABBOT")
            {
                gridsdrr.Columns["isCovered"].Visible = true;
                gridsdrr.Columns["isCovered"].Width = 50;
                gridsdrr.Columns["custname"].Width = gridsdrr.Columns["custname"].Width - 50;
            }
        }

        public void InitGridData()
        {
            MaxRows = false;
            gridsdrr.Rows.Clear();
            int coutrow = 1;
            List<string> removeinvoice = new List<string>();
            foreach (KeyValuePair<String, List<String>> item in _invoice)
            {
                DataGridViewRow gRow = (DataGridViewRow)gridsdrr.RowTemplate.Clone();
                gRow.CreateCells(gridsdrr);

                gRow.Cells[gridsdrr.Columns["numberIncrement"].Index].Value =  coutrow;
                gRow.Cells[gridsdrr.Columns["cboinvoice"].Index].Value = item.Value[0];
                gRow.Cells[gridsdrr.Columns["invoice_date"].Index].Value = item.Value[1];
                gRow.Cells[gridsdrr.Columns["numberofcartons"].Index].Value = item.Value[2];
                gRow.Cells[gridsdrr.Columns["custname"].Index].Value = item.Value[3];
                gRow.Cells[gridsdrr.Columns["pdcamt"].Index].Value = item.Value[4];
                gRow.Cells[gridsdrr.Columns["codamt"].Index].Value = item.Value[5];
                gRow.Cells[gridsdrr.Columns["pdcamount1"].Index].Value = item.Value[6];
                gRow.Cells[gridsdrr.Columns["invoicevalue"].Index].Value = item.Value[7];
                gRow.Cells[gridsdrr.Columns["index"].Index].Value = item.Value[8];
                gRow.Cells[gridsdrr.Columns["zone"].Index].Value = item.Value[9];
                gRow.Cells[gridsdrr.Columns["isCovered"].Index].Value = item.Value[10];

                if (coutrow >= 15)
                {
                    MaxRows = true;
                    removeinvoice.Add(item.Value[2]);
                }
                else
                    gridsdrr.Rows.Add(gRow);
                coutrow ++;
            }
            foreach (String item in removeinvoice)
            {
                _invoice.Remove(item);
            }
            getTotal();
            txtnoofdrops.Text = Customer.Count.ToString();
        }

        public void GetGridInvoice()
        {
            
            foreach (DataGridViewRow row in gridsdrr.Rows)
            {
                if (gridsdrr.Rows.Count-1 == row.Index)
                    break;
                if (!_invoice.ContainsKey(row.Cells["cboInvoice"].Value.ToString().Trim()))
                {
                    List<String> details = new List<string>();
                    details.Add(row.Cells["cboInvoice"].Value.ToString().Trim());
                    details.Add(row.Cells["invoice_date"].Value.ToString().Trim());
                    details.Add(row.Cells["numberOfcartons"].Value.ToString().Trim());
                    details.Add(row.Cells["custname"].Value.ToString().Trim());
                    details.Add(row.Cells["pdcamt"].Value.ToString().Trim());
                    details.Add(row.Cells["codamt"].Value.ToString().Trim());
                    details.Add(row.Cells["pdcamount1"].Value.ToString().Trim());
                    details.Add(row.Cells["invoicevalue"].Value.ToString().Trim());
                    details.Add(row.Cells["index"].Value.ToString().Trim());
                    details.Add(row.Cells["zone"].Value.ToString().Trim());
                    if (cboClient.SelectedValue.ToString() == "ABBOTT" || cboClient.Text == "ABBOT")
                        details.Add(row.Cells["isCovered"].Value.ToString());
                    else
                        details.Add("");

                    _invoice.Add(details[0], details);
                }

            }
        }

        public void ShowSDRRDetails()
        {
            try
            {
                foreach (DataRow dRow in Utils.GetDataTable("SELECT * FROM [GLOBAL_SdrrMaster] WHERE _sdrrindex = " + _sdrrindex).Rows)
                {
                    cboDriver.Text = dRow["driver"].ToString();
                    cboHelper.Text = dRow["helper"].ToString();
                    cboHelper2.Text = dRow["helper2"].ToString();

                    cboClient.SelectedValue = dRow["client"].ToString();
                    sdrrDate.Value = Convert.ToDateTime(dRow["date"]);
                    codtotal.Text = dRow["totalcodamt"].ToString();
                    pdctotal.Text = dRow["totalpdcamt1"].ToString();
                    route.Text = dRow["route"].ToString();
                    telno.Text = dRow["telno"].ToString();
                    sdrrNoTxt.Text = dRow["sdrrno"].ToString();
                    prepbtTxt.Text = dRow["prepby"].ToString();
                    chckbyTxt.Text = dRow["chckby"].ToString();
                    txtnoofdrops.Text = dRow["noofdrops"].ToString();
                    tinvoice.Text = dRow["invoicevalue"].ToString();

                    foreach (DataRow dRow_details in Utils.GetDataTable("SELECT * FROM [GLOBAL_ProductTrans] WHERE sdrrno = " + dRow["sdrrno"].ToString()).Rows)
                    {
                        String[] addRow = new String[gridsdrr.ColumnCount];
                        addRow[gridsdrr.Columns["numberIncrement"].Index] = gridsdrr.RowCount.ToString();
                        addRow[gridsdrr.Columns["cboinvoice"].Index] = dRow_details["invoice_no"].ToString();
                        addRow[gridsdrr.Columns["invoice_date"].Index] = dRow_details["invoice_date"].ToString();
                        addRow[gridsdrr.Columns["numberOfcartons"].Index] = dRow_details["no_of_cartons"].ToString();
                        addRow[gridsdrr.Columns["custname"].Index] = dRow_details["customer_name"].ToString();
                        addRow[gridsdrr.Columns["pdcamt"].Index] = dRow_details["pdc_amt"].ToString();
                        addRow[gridsdrr.Columns["codamt"].Index] = dRow_details["cod_amt"].ToString();
                        addRow[gridsdrr.Columns["pdcamount1"].Index] = dRow_details["pdc_amt1"].ToString();
                        addRow[gridsdrr.Columns["invoicevalue"].Index] = dRow_details["invoice_value"].ToString();
                        addRow[gridsdrr.Columns["index"].Index] = dRow_details["TransIndex"].ToString();
                        addRow[gridsdrr.Columns["zone"].Index] = dRow_details["zone"].ToString();
                        if (cboClient.SelectedValue.ToString() == "ABBOTT" || cboClient.Text == "ABBOT")
                        {
                            if (dRow_details["iscovered"].ToString() == "C")
                                addRow[gridsdrr.Columns["iscovered"].Index] = "C";
                            else
                                addRow[gridsdrr.Columns["iscovered"].Index] = "NC";
                        }

                        List<String> details = new List<string>();
                        details.Add(dRow_details["invoice_no"].ToString());
                        details.Add(dRow_details["invoice_date"].ToString());
                        details.Add(dRow_details["no_of_cartons"].ToString());
                        details.Add(dRow_details["customer_name"].ToString());
                        details.Add(dRow_details["pdc_amt"].ToString());
                        details.Add(dRow_details["pdc_amt"].ToString());
                        details.Add(dRow_details["pdc_amt1"].ToString());
                        details.Add(dRow_details["invoice_value"].ToString());
                        details.Add(dRow_details["TransIndex"].ToString());
                        details.Add(dRow_details["zone"].ToString());
                        if (cboClient.SelectedValue.ToString() == "ABBOTT" || cboClient.Text == "ABBOT")
                            details.Add(dRow_details["iscovered"].ToString());
                        else
                            details.Add("");

                        _invoice.Add(details[0], details);

                        gridsdrr.Rows.Add(addRow);

                    }
                    getTotal();
                }
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message, "Error!", MessageBoxButtons.OK);
            }
        }

        private void getTotal()
        {
            try
            {
                decimal totalcod = 0;
                decimal totalpdc1 = 0;
                decimal totalpdc = 0;
                decimal totalbox = 0;
                decimal totalinvoicev = 0;

                foreach (DataGridViewRow dRow in gridsdrr.Rows)
                {
                    if (dRow.Index == gridsdrr.Rows.Count - 1)

                        break;

                    totalbox += Convert.ToDecimal(dRow.Cells["numberOfcartons"].Value);
                    totalcod += Convert.ToDecimal(dRow.Cells["codamt"].Value);
                    totalpdc += Convert.ToDecimal(dRow.Cells["pdcamt"].Value);
                    totalpdc1 += Convert.ToDecimal(dRow.Cells["pdcamount1"].Value);
                    dRow.Cells["invoicevalue"].Value = totalcod + totalpdc + totalpdc1;
                    totalinvoicev += Convert.ToDecimal(dRow.Cells["invoicevalue"].Value);
                    if (dRow.Cells["custname"].Value != null)
                        if (!Customer.Contains(dRow.Cells["custname"].Value.ToString()))
                            Customer.Add(dRow.Cells["custname"].Value.ToString());
                }
                pdctotal.Text = totalpdc1.ToString();
                codtotal.Text = totalcod.ToString();
                tinvoice.Text = totalinvoicev.ToString();
                tcartons.Text = totalbox.ToString();
                tpdc.Text = totalpdc.ToString();
                tcod.Text = totalcod.ToString();
                tvalueshipTxt.Text = (totalcod + totalpdc + totalpdc1).ToString();
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message);
            }
        }

        private void gridsdrr_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress -= new KeyPressEventHandler(KeyBoardSupport.ForAlhpaNumeric_KeyPress);
                e.Control.KeyPress -= new KeyPressEventHandler(KeyBoardSupport.ForCurrencyOnly_Keypress);
                e.Control.KeyPress -= new KeyPressEventHandler(KeyBoardSupport.ForNumericOnly_KeyPress);
                TextBox tb = e.Control as TextBox;
                if (gridsdrr.CurrentCell.ColumnIndex == gridsdrr.Columns["numberOfcartons"].Index || gridsdrr.CurrentCell.ColumnIndex == gridsdrr.Columns["pdcamt"].Index
                    || gridsdrr.CurrentCell.ColumnIndex == gridsdrr.Columns["invoicevalue"].Index || gridsdrr.CurrentCell.ColumnIndex == gridsdrr.Columns["codamt"].Index
                    || gridsdrr.CurrentCell.ColumnIndex == gridsdrr.Columns["pdcamount1"].Index) //Desired Column
                {
                    if (tb != null)
                        tb.KeyPress += new KeyPressEventHandler(KeyBoardSupport.ForCurrencyOnly_Keypress);
                }
                else if (gridsdrr.CurrentCell.ColumnIndex == gridsdrr.Columns["custname"].Index)
                {
                    if (tb != null)
                        tb.KeyPress += new KeyPressEventHandler(KeyBoardSupport.ForAlhpaNumeric_KeyPress);
                }
                else if (gridsdrr.CurrentCell.ColumnIndex == gridsdrr.Columns["zone"].Index || gridsdrr.CurrentCell.ColumnIndex == gridsdrr.Columns["cboInvoice"].Index)
                {
                    if (tb != null)
                        tb.KeyPress += new KeyPressEventHandler(KeyBoardSupport.ForNumericOnly_KeyPress);
                }
            }
            catch (Exception ex)
            { DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message); }
        }

        private void gridsdrr_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridsdrr.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    getTotal();
                    txtnoofdrops.Text = Customer.Count.ToString();
                }
            }
            catch (Exception ex)
            { DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message); }
        }

        private void gridsdrr_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                if (MaxRows)
                    return;
            }
            catch (Exception ex)
            { DevComponents.DotNetBar.MessageBoxEx.Show(ex.Message); }
        }

        private void gridsdrr_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridsdrr.Rows.Count >= 15)//14>=15
                {
                    gridsdrr.AllowUserToAddRows = false;
                    gridsdrr.Rows.RemoveAt(gridsdrr.CurrentRow.Index);
                    gridsdrr.AllowUserToAddRows = true;
                    MessageBox.Show("Maximum Number of Invoice has been reach!", "Message", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    if (gridsdrr.Rows.Count == 1)
                        return;

                    if (e.ColumnIndex == gridsdrr.Columns["cboInvoice"].Index)
                    {
                        String docNo = gridsdrr.Rows[e.RowIndex].Cells["cboInvoice"].Value.ToString();
                        DataRow dresult = null;
                        if (EncodedInvoice.TryGetValue(docNo, out dresult))
                        {
                            gridsdrr.AllowUserToAddRows = false;
                            gridsdrr.Rows.RemoveAt(gridsdrr.CurrentRow.Index);
                            gridsdrr.AllowUserToAddRows = true;
                            MessageBox.Show("Document Number Already Exist!", "Message", MessageBoxButtons.OK);
                            return;
                        }
                        gridsdrr.Rows[e.RowIndex].Cells["pdcamt"].Value = "0.00";
                        gridsdrr.Rows[e.RowIndex].Cells["codamt"].Value = "0.00";
                        gridsdrr.Rows[e.RowIndex].Cells["pdcamount1"].Value = "0.00";
                        gridsdrr.Rows[e.RowIndex].Cells["zone"].Value = 0;
                        if (gridsdrr.Rows[e.RowIndex].Cells["index"].Value == null)
                            gridsdrr.Rows[e.RowIndex].Cells["index"].Value = 0;

                    }
                    else
                    {
                        if (gridsdrr.Rows.Count - 1 != e.RowIndex)
                            this.gridsdrr.Rows[e.RowIndex].Cells["invoicevalue"].Value = Convert.ToDecimal(this.gridsdrr.Rows[e.RowIndex].Cells["pdcamt"].Value) + Convert.ToDecimal(this.gridsdrr.Rows[e.RowIndex].Cells["pdcamount1"].Value) + Convert.ToDecimal(this.gridsdrr.Rows[e.RowIndex].Cells["codamt"].Value);
                        if (gridsdrr.Rows[e.RowIndex].Cells["index"].Value == null)
                            gridsdrr.Rows[e.RowIndex].Cells["index"].Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + "Report this to the programmer!", "Error!", MessageBoxButtons.OK);
            }
        }
        #endregion
        
        #region onchange
        private void cboClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gridsdrr.Columns.Count >= 1)
            {
                clientuse = cboClient.SelectedValue.ToString();
                if (_invoice.Count >= 1)
                {
                    if (oldindex != cboClient.SelectedIndex)
                    {
                        if (DevComponents.DotNetBar.MessageBoxEx.Show("Are you sure you want to change client?\nThis invoices you pick will be emtpty!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            _invoice = new Dictionary<string, List<string>>();
                            if (cboClient.SelectedValue.ToString() == "ABBOTT" || cboClient.SelectedValue.ToString() == "ABBOT")
                                display_sdrrColums();
                            else
                            {   display_sdrrColums();  }
                            oldindex = cboClient.SelectedIndex;
                        }
                        else
                        {   cboClient.SelectedIndex = oldindex;  }
                    }
                }
                else
                {
                    if (cboClient.SelectedValue.ToString() == "ABBOTT" || cboClient.SelectedValue.ToString() == "ABBOT")
                        display_sdrrColums();
                    else
                    {   display_sdrrColums();  }
                    oldindex = cboClient.SelectedIndex;
                }
            }

        }

        private void telno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void sdrrNoTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtnoofdrops_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void prepbtTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void chckbyTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion

        #region Saving and Updating
        private void btnregprint_Click(object sender, EventArgs e)
        {
            Utils.ListOfActiveControls.Add("PRINT");
            Utils.SDRRprintoutType = "REGULAR";
            Dictionary<String, Object> sdrrmast = new Dictionary<string, object>();
            sdrrmast.Add("_sdrrno", sdrrNoTxt.Text);
            sdrrmast.Add("driver", cboDriver.Text);
            sdrrmast.Add("helper", cboHelper.Text);
            sdrrmast.Add("helper1", cboHelper2.Text);
            sdrrmast.Add("client", cboClient.SelectedValue.ToString());
            sdrrmast.Add("route", route.Text);
            sdrrmast.Add("date", sdrrDate.Text);
            sdrrmast.Add("telno", telno.Text);
            sdrrmast.Add("totalcod", codtotal.Text);
            sdrrmast.Add("totalpdc", pdctotal.Text);
            sdrrmast.Add("prepby", prepbtTxt.Text);
            sdrrmast.Add("tvalueship", tvalueshipTxt.Text);
            sdrrmast.Add("checkby", chckbyTxt.Text);
            printableData = getPrintableData(gridsdrr, sdrrmast); 
        }

        private void btnmatrixprint_Click(object sender, EventArgs e)
        {
            Utils.ListOfActiveControls.Add("PRINT");
            Utils.SDRRprintoutType = "MATRIX";
            Dictionary<String, Object> sdrrmast = new Dictionary<string, object>();
            sdrrmast.Add("_sdrrno", sdrrNoTxt.Text);
            sdrrmast.Add("driver", cboDriver.Text);
            sdrrmast.Add("helper", cboHelper.Text);
            sdrrmast.Add("helper1", cboHelper2.Text);
            sdrrmast.Add("client", cboClient.SelectedValue.ToString());
            sdrrmast.Add("route", route.Text);
            sdrrmast.Add("date", sdrrDate.Text);
            sdrrmast.Add("telno", telno.Text);
            sdrrmast.Add("totalcod", codtotal.Text);
            sdrrmast.Add("totalpdc", pdctotal.Text);
            sdrrmast.Add("prepby", prepbtTxt.Text);
            sdrrmast.Add("tvalueship", tvalueshipTxt.Text);
            sdrrmast.Add("checkby", chckbyTxt.Text);
            printableData = getPrintableData(gridsdrr, sdrrmast); 
        }

        public bool save()
        {
            try
            {
                Dictionary<String, Object> Params = new Dictionary<String, Object>();
                Params.Add("sdrrno", Convert.ToInt32(sdrrNoTxt.Text));
                Params.Add("driver", cboDriver.Text.Trim());
                Params.Add("helper", cboHelper.Text.Trim());
                Params.Add("helper2", cboHelper2.Text.Trim());
                Params.Add("client", cboClient.SelectedValue.ToString().Trim());
                Params.Add("[date]", sdrrDate.Value.ToShortDateString());
                Params.Add("totalcodamt", codtotal.Text.Trim());
                Params.Add("totalpdcamt1", pdctotal.Text.Trim());
                Params.Add("route", route.Text.Trim());
                Params.Add("telno", telno.Text.Trim());
                Params.Add("prepby", prepbtTxt.Text.Trim());
                Params.Add("tvalueship", tvalueshipTxt.Text.Trim());
                Params.Add("chckby", chckbyTxt.Text);
                Params.Add("invoicevalue", tinvoice.Text.Trim());
                Params.Add("status", 1);
                Params.Add("flag", 1);
                Params.Add("carrier", cboVehl.Text.Trim());
                Params.Add("uploaded", 0);
                Params.Add("noofdrops", txtnoofdrops.Text);

                string sql = DataSupport.GetInsert("global_sdrrmaster", Params);
                foreach (DataGridViewRow row in gridsdrr.Rows)
                {
                    if (row.IsNewRow) continue;

                    Dictionary<String, Object> Param1 = new Dictionary<String, Object>();
                    //int TransIndex = Convert.ToInt32(Utils.ExecuteStoredProcedure("sp_BASE_GetLastTransIndex", null).Rows[0][0]) + 1;
                    //Param1.Add("TransPindex", TransIndex);
                    Param1.Add("sdrrno", Convert.ToInt32(sdrrNoTxt.Text));
                    if (row.Cells["numberOfcartons"].Value != null)
                        Param1.Add("no_of_cartons", row.Cells["numberOfcartons"].Value.ToString().Trim());
                    else
                        Param1.Add("no_of_cartons", 0);
                    Param1.Add("customer_name", row.Cells["custname"].Value.ToString().Trim());
                    Param1.Add("invoice_no", row.Cells["cboInvoice"].Value.ToString().Trim());
                    Param1.Add("pdc_amt", row.Cells["pdcamt"].Value.ToString().Trim());
                    Param1.Add("cod_amt", row.Cells["codamt"].Value.ToString().Trim());
                    Param1.Add("pdc_amt1", row.Cells["pdcamount1"].Value.ToString().Trim());
                    Param1.Add("invoice_value", row.Cells["invoicevalue"].Value.ToString().Trim());
                    Param1.Add("invoice_date", row.Cells["invoice_date"].Value);
                    if (row.Cells["zone"].Value != null)
                        Param1.Add("zone", row.Cells["zone"].Value.ToString().Trim());
                    else
                        Param1.Add("zone", 0);

                    if (cboClient.SelectedValue.ToString() == "ABBOTT" || cboClient.SelectedValue.ToString() == "ABBOT")
                    {
                        if (row.Cells["isCovered"].Value != null)
                            Param1.Add("isCovered", row.Cells["isCovered"].Value.ToString().Trim());
                        else
                            Param1.Add("isCovered", "");
                    }
                    else
                        Param1.Add("isCovered", "");
                    Param1.Add("uploaded", 0);

                    sql += DataSupport.GetInsert("global_producttrans", Param1);
                }
                Utils.ExecuteNonQuery(sql, null);

                DevComponents.DotNetBar.MessageBoxEx.Show("Save Successfull", "SDRR Save Complete", MessageBoxButtons.OK);
                return true;
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(String.Format("{0}\nUnable to update the transaction", ex.Message));
                return false;
            }
        }

        public bool update()
        {
            try
            {
                Dictionary<String, Object> Params = new Dictionary<String, Object>();
                Params.Add("_sdrrIndex", _sdrrindex);
                Params.Add("sdrrno", Convert.ToInt32(sdrrNoTxt.Text));
                Params.Add("driver", cboDriver.Text.Trim());
                Params.Add("helper", cboHelper.Text.Trim());
                Params.Add("helper2", cboHelper2.Text.Trim());
                Params.Add("client", cboClient.SelectedValue);
                Params.Add("[date]", sdrrDate.Value.ToShortDateString());
                Params.Add("totalcodamt", codtotal.Text.Trim());
                Params.Add("totalpdcamt1", pdctotal.Text.Trim());
                Params.Add("route", route.Text.Trim());
                Params.Add("telno", telno.Text.Trim());
                Params.Add("prepby", prepbtTxt.Text.Trim());
                Params.Add("tvalueship", tvalueshipTxt.Text.Trim());
                Params.Add("chckby", chckbyTxt.Text);
                Params.Add("invoicevalue", tinvoice.Text.Trim());
                Params.Add("carrier", cboVehl.Text.Trim());
                Params.Add("uploaded", 0);

                List<String> primary = new List<string>();
                primary.Add("_sdrrIndex");
                string sql = DataSupport.GetUpdate("global_sdrrmaster", Params, primary) + ";\r\n";

                foreach (DataGridViewRow row in gridsdrr.Rows)
                {
                    Dictionary<String, object> Param1 = new Dictionary<string, object>();
                    if (row.IsNewRow) continue;

                    int TransIndex = 0;
                    //if (row.Cells["index"].Value.ToString() == "0")
                    //{
                    //    TransIndex = Convert.ToInt32(Utils.ExecuteStoredProcedure("sp_BASE_GetLastTransIndex", null).Rows[0][0]) + 1;
                    //    Param1.Add("Transindex", TransIndex);
                    //}
                    //else
                    //{
                        TransIndex = Convert.ToInt32(row.Cells["index"].Value.ToString().Trim());
                        Param1.Add("transindex", row.Cells["index"].Value.ToString().Trim());
                    //}

                    Param1.Add("sdrrno", Convert.ToInt32(sdrrNoTxt.Text));
                    if (row.Cells["numberOfcartons"].Value != null)
                        Param1.Add("no_of_cartons", row.Cells["numberOfcartons"].Value.ToString().Trim());
                    else
                        Param1.Add("no_of_cartons", 0);
                    Param1.Add("customer_name", row.Cells["custname"].Value.ToString().Trim());
                    Param1.Add("invoice_no", row.Cells["cboInvoice"].Value.ToString().Trim());
                    Param1.Add("pdc_amt", row.Cells["pdcamt"].Value.ToString().Trim());
                    Param1.Add("cod_amt", row.Cells["codamt"].Value.ToString().Trim());
                    Param1.Add("pdc_amt1", row.Cells["pdcamount1"].Value.ToString().Trim());
                    Param1.Add("invoice_value", row.Cells["invoicevalue"].Value.ToString().Trim());
                    Param1.Add("invoice_date", row.Cells["invoice_date"].Value);
                    Param1.Add("zone", row.Cells["zone"].Value.ToString().Trim());
                    if (cboClient.SelectedValue.ToString() == "ABBOTT")
                    {
                        if (row.Cells["isCovered"].Value != null)
                            Param1.Add("isCovered", row.Cells["isCovered"].Value.ToString().Trim());
                        else
                            Param1.Add("isCovered", "");
                    }
                    else
                        Param1.Add("isCovered", "");
                    Param1.Add("uploaded", 0);

                    //if (row.Cells["index"].Value.ToString() == "0")
                    //    sql += DataSupport.GetInsert("global_producttrans", Param1) + ";\r\n";
                    //else
                    //{
                        primary.Clear();
                        primary.Add("Transindex");
                        sql += DataSupport.GetUpsert("global_producttrans", Param1, new List<String> { "transindex","sdrrno"}) + ";\r\n";
                    //}
                }
                Utils.ExecuteNonQuery(sql, null);
                DevComponents.DotNetBar.MessageBoxEx.Show("Update Successfull", "Message", MessageBoxButtons.OK);
                return true;
            }
            catch (Exception ex)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(String.Format("{0}\nUnable to update the transaction", ex.Message));
                return false;
            }
        }

        private DataTable getPrintableData(DataGridView sdrrgrid, Dictionary<String, Object> sdrrmast)
        {
            System.Data.DataTable result = new System.Data.DataTable();
            result.Columns.Add(new DataColumn("_sdrrno", typeof(Int32)));
            result.Columns.Add(new DataColumn("invoice_no", typeof(Decimal)));
            result.Columns.Add(new DataColumn("invoice_date", typeof(string)));
            result.Columns.Add(new DataColumn("noOfBox", typeof(Decimal)));
            result.Columns.Add(new DataColumn("custName", typeof(string)));
            result.Columns.Add(new DataColumn("pdcamt", typeof(Decimal)));
            result.Columns.Add(new DataColumn("codamt", typeof(Decimal)));
            result.Columns.Add(new DataColumn("pdcamt1", typeof(Decimal)));
            result.Columns.Add(new DataColumn("driver", typeof(string)));
            result.Columns.Add(new DataColumn("helper", typeof(string)));
            result.Columns.Add(new DataColumn("helper1", typeof(string)));
            result.Columns.Add(new DataColumn("client", typeof(string)));
            result.Columns.Add(new DataColumn("route", typeof(string)));
            result.Columns.Add(new DataColumn("date", typeof(DateTime)));
            result.Columns.Add(new DataColumn("telno", typeof(string)));
            result.Columns.Add(new DataColumn("totalcod", typeof(Decimal)));
            result.Columns.Add(new DataColumn("totalpdc", typeof(Decimal)));
            result.Columns.Add(new DataColumn("prepby", typeof(string)));
            result.Columns.Add(new DataColumn("checkby", typeof(string)));
            result.Columns.Add(new DataColumn("tvalueship", typeof(Decimal)));
            result.Columns.Add(new DataColumn("nc", typeof(string)));

            DataRow resultRow = result.NewRow();
            Customer = new List<String>();
            int rowindex = 0;
            for (int rows = 0; rows < sdrrgrid.Rows.Count - 1; rows++)//gi sud ang mga value sa result row
            {
                if (rowindex == sdrrgrid.Rows.Count - 1)
                    break;
                resultRow = result.NewRow();

                resultRow["_sdrrno"] = sdrrmast["_sdrrno"];
                resultRow["driver"] = sdrrmast["driver"];
                resultRow["helper"] = sdrrmast["helper"];
                resultRow["helper1"] = sdrrmast["helper1"];
                resultRow["client"] = sdrrmast["client"];
                resultRow["route"] = sdrrmast["route"];
                resultRow["date"] = sdrrmast["date"];
                resultRow["telno"] = sdrrmast["telno"];
                resultRow["totalcod"] = sdrrmast["totalcod"];
                resultRow["totalpdc"] = sdrrmast["totalpdc"];
                resultRow["prepby"] = sdrrmast["prepby"];
                resultRow["tvalueship"] = sdrrmast["tvalueship"];
                resultRow["checkby"] = sdrrmast["checkby"];

                resultRow["invoice_no"] = sdrrgrid.Rows[rows].Cells["cboInvoice"].Value.ToString();
                if (sdrrgrid.Rows[rows].Cells["numberOfcartons"].Value != null)
                    resultRow["noOfBox"] = sdrrgrid.Rows[rows].Cells["numberOfcartons"].Value.ToString();
                else
                    resultRow["noOfBox"] = 0;

                resultRow["custName"] = sdrrgrid.Rows[rows].Cells["custname"].Value.ToString();
                if (sdrrgrid.Rows[rows].Cells["codamt"].Value != null)
                    resultRow["codamt"] = sdrrgrid.Rows[rows].Cells["codamt"].Value.ToString();
                else
                    resultRow["codamt"] = 0;

                if (sdrrgrid.Rows[rows].Cells["pdcamt"].Value != null)
                    resultRow["pdcamt"] = sdrrgrid.Rows[rows].Cells["pdcamt"].Value.ToString();
                else
                    resultRow["pdcamt1"] = 0;

                if (sdrrgrid.Rows[rows].Cells["pdcamt"].Value != null)
                    resultRow["pdcamt1"] = sdrrgrid.Rows[rows].Cells["pdcamount1"].Value.ToString();
                else
                    resultRow["pdcamt1"] = 0;

                resultRow["nc"] = sdrrgrid.Rows[rows].Cells["zone"].Value.ToString();
                if (sdrrmast["client"].ToString() == "ABBOTT")
                {
                    if (sdrrgrid.Rows[rows].Cells["iscovered"].Value != null)
                        resultRow["nc"] = sdrrgrid.Rows[rows].Cells["zone"].Value.ToString() + " - " + sdrrgrid.Rows[rows].Cells["iscovered"].Value.ToString();
                    else
                        resultRow["nc"] = sdrrgrid.Rows[rows].Cells["zone"].Value.ToString();
                }

                result.Rows.Add(resultRow);
                rowindex += 1;
            }

            return result;
        }
        #endregion

        private void btninvoice_Click(object sender, EventArgs e)
        {
            Utils.ListOfActiveControls.Add("INVOICEPICK");
        }
    }
}
