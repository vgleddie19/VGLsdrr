using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro.ColorTables;
using System.Diagnostics;
using CrystalDecisions.CrystalReports.Engine;
using System.Threading;
using MRG.Controls.UI;
using System.Data.SqlClient;

namespace NewSDRR
{
    public partial class MainMenu : MetroAppForm
    {
        StartControl _StartControl = null; // Start control displayed on startup
        MetroBillCommands _Commands = null; // All application commands
        #region Initialization Form
        public MainMenu()
        {
            Utils.SetConnectionDetails();
            InitializeComponent();

            DataSupport.setDBConnection("Integrated Security=SSPI;Initial Catalog=sdrr;Data Source=.\\SQLEXPRESS; User Id = vgl_data; Password = tqbfjotld;");
            // Prepare commands
            _Commands = new MetroBillCommands();

            _Commands.ToggleStartControl = new Command(components);
            _Commands.ToggleStartControl.Executed += new EventHandler(ToggleStartControlExecuted);

            // Delivery Status Report commands
            _Commands.SDRRCommands.MenuCotrol = new Command(components); // We pass in components from Form so the command gets disposed automatically when form is disposed
            _Commands.SDRRCommands.MenuCotrol.Executed += OpenMenuControlExecute;
            _Commands.SDRRCommands.New = new Command(components);
            _Commands.SDRRCommands.New.Executed += SDRROpenNewControls;
            _Commands.SDRRCommands.Cancel = new Command(components);
            _Commands.SDRRCommands.Cancel.Executed += SDRRCloseCurrentControlExecute;
            _Commands.SDRRCommands.Save = new Command(components);
            _Commands.SDRRCommands.Save.Executed += SDDRSaveExecuted;
            _Commands.SDRRCommands.ShowTransactionForm = new Command(components);
            _Commands.SDRRCommands.ShowTransactionForm.Executed += SDRRShowTransactionFormExecuted;

            _Commands.NUDCommands.MenuCotrol = new Command(components); // We pass in components from Form so the command gets disposed automatically when form is disposed
            _Commands.NUDCommands.MenuCotrol.Executed += OpenMenuControlExecute;
            _Commands.NUDCommands.New = new Command(components);
            _Commands.NUDCommands.New.Executed += NUDOpenNewControls;
            _Commands.NUDCommands.Cancel = new Command(components);
            _Commands.NUDCommands.Cancel.Executed += NUDCloseCurrentControlExecute;
            _Commands.NUDCommands.Save = new Command(components);
            _Commands.NUDCommands.Save.Executed += NUDSaveExecuted;
            _Commands.NUDCommands.ShowTransactionForm = new Command(components);
            _Commands.NUDCommands.ShowTransactionForm.Executed += NUDShowTransactionFormExecuted;

            _Commands.ReportCommands.MenuCotrol = new Command(components); // We pass in components from Form so the command gets disposed automatically when form is disposed
            _Commands.ReportCommands.MenuCotrol.Executed += OpenMenuControlExecute;
            _Commands.ReportCommands.New = new Command(components);
            _Commands.ReportCommands.New.Executed += ReportOpenNewControls;
            _Commands.ReportCommands.Cancel = new Command(components);
            _Commands.ReportCommands.Cancel.Executed += ReportCloseCurrentControlExecute;


            // General commands
            _Commands.ChangeMetroTheme = new Command(components, new EventHandler(ChangeMetroThemeExecuted));
            _Commands.NotImplemented = new Command(components, new EventHandler(NotImplementedExecuted));
            _Commands.DevComponents = new Command(components, new EventHandler(DevComponentsExecuted));
            _Commands.GettingStartedCommand = new Command(components, new EventHandler(GettingStartedExecuted));

            this.SuspendLayout();
            _StartControl = new StartControl();
            _StartControl.Commands = _Commands;
            this.Controls.Add(_StartControl);
            _StartControl.BringToFront();
            _StartControl.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;
            _StartControl.Click += new EventHandler(StartControl_Click);
            this.ResumeLayout(false);

            Utils.ListOfActiveControls = new List<string>();
            Utils.ListOfActiveControls.Add("MAIN");
            Utils.ListOfControls = new Dictionary<String, Boolean>();
            Utils.ListOfControls.Add("MAIN", true);
            Utils.ListOfControls.Add("PRINT", true);
            #region SDRR
            Utils.ListOfControls.Add("SDRRMENU", true);
            Utils.ListOfControls.Add("NEWSDRR", true);
            Utils.ListOfControls.Add("INVOICEPICK", true);
            Utils.ListOfControls.Add("SDRRSAVEEXECUTE", true);
            Utils.ListOfControls.Add("SDRRLIST", true);
            Utils.ListOfControls.Add("UPDATESDRR", true);
            #endregion
            #region NUD
            Utils.ListOfControls.Add("NUDMENU", true);
            Utils.ListOfControls.Add("NEWNUD", true);
            Utils.ListOfControls.Add("NUDINVOICEPICK", true);
            Utils.ListOfControls.Add("NUDSAVEEXECUTE", true);
            Utils.ListOfControls.Add("NUDLIST", true);
            Utils.ListOfControls.Add("UPDATENUD", true);
            #endregion
            #region Reports
            Utils.ListOfControls.Add("REPORTSMENU", true);
            Utils.ListOfControls.Add("SDRRREGISTER_REPORT", true);
            Utils.ListOfControls.Add("INVREG_REPORT", true);
            Utils.ListOfControls.Add("NUDREG_REPORT", true);
            Utils.ListOfControls.Add("DELSTATUS_REPORT", true);
            #endregion

            Utils.branchcode = Utils.GetDataTable("SELECT TOP 1 branchcode FROM base_branch", null).Rows[0][0].ToString();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            //loginform.Show();
        }
        #endregion

        #region Command Execution
        SDRRControl sdrrmenu = null;
        NUDControl nudmenu = null;
        ReportsControl reportmenu = null;
        #region Back to MainMenu
        /// <summary>
        /// Return to main
        /// </summary>
        private void OpenMenuControlExecute(object sender, EventArgs e)
        {
            if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "SDRRMENU")
            {
                if (Utils.ListOfControls["SDRRMENU"])
                {
                    Debug.Assert(sdrrmenu == null);
                    Utils.ListOfControls["SDRRMENU"] = false;
                    sdrrmenu = new SDRRControl();
                    sdrrmenu.Dock = DockStyle.Fill;
                    sdrrmenu.Commands = _Commands;
                    this.ShowModalPanel(sdrrmenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NUDMENU")
            {
                if (Utils.ListOfControls["NUDMENU"])
                {
                    Debug.Assert(nudmenu == null);
                    Utils.ListOfControls["NUDMENU"] = false;
                    nudmenu = new NUDControl();
                    nudmenu.Dock = DockStyle.Fill;
                    nudmenu.Commands = _Commands;
                    this.ShowModalPanel(nudmenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "REPORTSMENU")
            {
                if (Utils.ListOfControls["REPORTSMENU"])
                {
                    Debug.Assert(reportmenu == null);
                    Utils.ListOfControls["REPORTSMENU"] = false;
                    reportmenu = new ReportsControl();
                    reportmenu.Dock = DockStyle.Fill;
                    reportmenu.Commands = _Commands;
                    this.ShowModalPanel(reportmenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }
        }      
        #endregion

        reportviewercontrol cviewer = null;
        ListSDRRTransControl sdrrlist = null;
        newSDRRtransControl newsdrr = null;
        DeliveryStatusControl delstatus = null;
        SDRRInvoicePickingControls invoicepick = null;
        #region SDRR         
        private void SDRROpenNewControls(object sender, EventArgs e)
        {
            if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NEWSDRR")
            {
                if (Utils.ListOfControls["NEWSDRR"])
                {
                    Debug.Assert(newsdrr == null);
                    Utils.ListOfControls["NEWSDRR"] = false;
                    newsdrr = new newSDRRtransControl("SAVE", null);
                    newsdrr.Dock = DockStyle.Fill;
                    newsdrr.Commands = _Commands;
                    this.ShowModalPanel(newsdrr, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "INVOICEPICK")
            {
                if (Utils.ListOfControls["INVOICEPICK"])
                {
                    Debug.Assert(invoicepick == null);

                    Utils.ListOfControls["INVOICEPICK"] = false;
                    invoicepick = new SDRRInvoicePickingControls(new string[] { newsdrr.cboClient.SelectedValue.ToString(), newsdrr.cboClient.Text, newsdrr._entrytype }, newsdrr._invoice);
                    newsdrr.GetGridInvoice();
                    invoicepick.Dock = DockStyle.Fill;
                    invoicepick.Commands = _Commands;
                    this.ShowModalPanel(invoicepick, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "PRINT")
            {
                if (Utils.ListOfControls["PRINT"])
                {                    
                    Debug.Assert(cviewer == null);
                    Utils.ListOfControls["PRINT"] = false;
                    Utils.ListOfControls["SDRRSAVEEXECUTE"] = false;
                    ReportDocument rviewer = new ReportDocument();
                    if (Utils.printpreview_formuse == "newSDRRtransControl")
                    {
                        if (Utils.SDRRprintoutType == "REGULAR")
                        {
                            rviewer = new crtPrintSDRR();
                            rviewer.Database.Tables[0].SetDataSource(newsdrr.printableData);
                            rviewer.SetParameterValue("prepby", newsdrr.prepbtTxt.Text);
                            rviewer.SetParameterValue("tvalueship", newsdrr.tvalueshipTxt.Text);
                            rviewer.SetParameterValue("chckby", newsdrr.chckbyTxt.Text);
                            rviewer.SetParameterValue("#ofDrops", newsdrr.txtnoofdrops.Text);
                            rviewer.SetParameterValue("carrier", newsdrr.cboVehl.Text);
                        }
                        else if (Utils.SDRRprintoutType == "MATRIX")
                        {
                            rviewer = new crtSDRR();
                            rviewer.Database.Tables[0].SetDataSource(newsdrr.printableData);
                            rviewer.SetParameterValue("prepby", newsdrr.prepbtTxt.Text);
                            rviewer.SetParameterValue("tvalueship", newsdrr.tvalueshipTxt.Text);
                            rviewer.SetParameterValue("chckby", newsdrr.chckbyTxt.Text);
                            rviewer.SetParameterValue("helper2", newsdrr.cboHelper.Text);
                        }
                    }
                    else if (Utils.printpreview_formuse == "DeliveryStatusControl")
                    {
                        rviewer = new updateSdrr();
                        rviewer.Database.Tables[0].SetDataSource(delstatus.printableData);
                    }
                    cviewer = new reportviewercontrol();
                    cviewer.crtviewer.ReportSource = rviewer;
                    cviewer.Dock = DockStyle.Fill;
                    cviewer.Commands = _Commands;
                    this.ShowModalPanel(cviewer, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "SDRRLIST")
            {
                if (Utils.ListOfControls["SDRRLIST"])
                {
                    Utils.ListOfControls["SDRRLIST"] = false;
                    Debug.Assert(sdrrlist == null);

                    sdrrlist = new ListSDRRTransControl();
                    sdrrlist.Dock = DockStyle.Fill;
                    sdrrlist.Commands = _Commands;
                    this.ShowModalPanel(sdrrlist, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }
        }
        private void SDRRCloseCurrentControlExecute(object sender, EventArgs e)
        {
            if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "SDRRMENU")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;
                    Debug.Assert(sdrrmenu != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    this.CloseModalPanel(sdrrmenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    sdrrmenu.Commands = null;
                    sdrrmenu.Dispose();
                    sdrrmenu = null;                    
                }
                RemoveActiveControl_onList("SDRRMENU");
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NEWSDRR" || Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "UPDATESDRR")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;
                    if (Utils.SDRRListType == "newSDRRtransControl")
                    {
                        Debug.Assert(newsdrr != null);
                        if (!_StartControl.Visible)
                            _StartControl.SlideOutButtonVisible = true;

                        this.CloseModalPanel(newsdrr, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        newsdrr.Commands = null;
                        newsdrr.Dispose();
                        newsdrr = null;
                    }
                    else if (Utils.SDRRListType == "DeliveryStatusControl")
                    {
                        Debug.Assert(delstatus != null);
                        if (!_StartControl.Visible)
                            _StartControl.SlideOutButtonVisible = true;

                        this.CloseModalPanel(delstatus, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        delstatus.Commands = null;
                        delstatus.Dispose();
                        delstatus = null;                        
                    }
                }
                RemoveActiveControl_onList("NEWSDRR");
                RemoveActiveControl_onList("UPDATESDRR");
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "INVOICEPICK")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;

                    Debug.Assert(newsdrr != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    newsdrr._invoice = invoicepick._invoice;
                    newsdrr.InitGridData();
                    this.CloseModalPanel(invoicepick, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    invoicepick.Commands = null;
                    invoicepick.Dispose();
                    invoicepick = null;
                }
                RemoveActiveControl_onList("INVOICEPICK");
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "SDRRSAVEEXECUTE")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;

                    Utils.ListOfControls["SDRRSAVEEXECUTE"] = true;
                    Utils.ListOfControls["PRINT"] = true;

                    Debug.Assert(cviewer != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    this.CloseModalPanel(cviewer, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    cviewer.Commands = null;
                    cviewer.Dispose();
                    cviewer = null;
                }
                RemoveActiveControl_onList("SDRRSAVEEXECUTE");
                RemoveActiveControl_onList("PRINT");
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "SDRRLIST")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;

                    Utils.ListOfControls["SDRRLIST"] = true;

                    Debug.Assert(sdrrlist != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    this.CloseModalPanel(sdrrlist, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    sdrrlist.Commands = null;
                    sdrrlist.Dispose();
                    sdrrlist = null;
                }
                RemoveActiveControl_onList("SDRRLIST");
            }
        }

        private void SDDRSaveExecuted(object sender, EventArgs e)
        {
            if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "SDRRSAVEEXECUTE")
            {
                if (!Utils.ListOfControls["SDRRSAVEEXECUTE"])
                {
                    Debug.Assert(cviewer != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;
                    this.CloseModalPanel(cviewer, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    cviewer.Commands = null;
                    cviewer.Dispose();
                    cviewer = null;

                    if (Utils.isNewRecord)
                    {
                        if (newsdrr.save())
                        {
                            Utils.ListOfControls["SDRRSAVEEXECUTE"] = true;
                            Utils.ListOfControls["PRINT"] = true;
                            Utils.ListOfControls["NEWSDRR"] = true;
                            RemoveActiveControl_onList("SDRRSAVEEXECUTE");
                            RemoveActiveControl_onList("PRINT");
                            RemoveActiveControl_onList("NEWSDRR");
                            Debug.Assert(newsdrr != null);
                            if (!_StartControl.Visible)
                                _StartControl.SlideOutButtonVisible = true;

                            this.CloseModalPanel(newsdrr, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            newsdrr.Commands = null;
                            newsdrr.Dispose();
                            newsdrr = null;
                        }
                        else
                        {
                            Utils.ListOfControls["SDRRSAVEEXECUTE"] = true;
                            Utils.ListOfControls["PRINT"] = true;
                            RemoveActiveControl_onList("SDRRSAVEEXECUTE");
                            RemoveActiveControl_onList("PRINT");                        
                        }
                    }
                    else
                    {
                        if (Utils.SDRRListType == "newSDRRtransControl")
                        {
                            if (newsdrr.update())
                            {
                                Utils.ListOfControls["SDRRSAVEEXECUTE"] = true;
                                Utils.ListOfControls["PRINT"] = true;
                                Utils.ListOfControls["UPDATESDRR"] = true;
                                RemoveActiveControl_onList("SDRRSAVEEXECUTE");
                                RemoveActiveControl_onList("PRINT");
                                RemoveActiveControl_onList("UPDATESDRR");
                                Debug.Assert(newsdrr != null);
                                if (!_StartControl.Visible)
                                    _StartControl.SlideOutButtonVisible = true;

                                this.CloseModalPanel(newsdrr, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                                newsdrr.Commands = null;
                                newsdrr.Dispose();
                                newsdrr = null;
                            }
                            else 
                            {
                                Utils.ListOfControls["SDRRSAVEEXECUTE"] = true;
                                Utils.ListOfControls["PRINT"] = true;
                                RemoveActiveControl_onList("SDRRSAVEEXECUTE");
                                RemoveActiveControl_onList("PRINT");
                            }
                        }
                        else if (Utils.SDRRListType == "DeliveryStatusControl")
                        {
                            if (delstatus.updatedelstatus())
                            {
                                Utils.ListOfControls["SDRRSAVEEXECUTE"] = true;
                                Utils.ListOfControls["PRINT"] = true;
                                Utils.ListOfControls["UPDATESDRR"] = true;
                                RemoveActiveControl_onList("SDRRSAVEEXECUTE");
                                RemoveActiveControl_onList("PRINT");
                                RemoveActiveControl_onList("UPDATESDRR");

                                Debug.Assert(delstatus != null);
                                if (!_StartControl.Visible)
                                    _StartControl.SlideOutButtonVisible = true;

                                this.CloseModalPanel(delstatus, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                                delstatus.Commands = null;
                                delstatus.Dispose();
                                delstatus = null;
                            }
                            else
                            {
                                Utils.ListOfControls["SDRRSAVEEXECUTE"] = true;
                                Utils.ListOfControls["PRINT"] = true;
                                RemoveActiveControl_onList("SDRRSAVEEXECUTE");
                                RemoveActiveControl_onList("PRINT");
                            }
                        }

                    }
                }
            }
        }
        
        private void SDRRShowTransactionFormExecuted(object sender, EventArgs e)
        {
            if (sdrrlist.lblindex.Text != "")
            {
                if (Utils.ListOfControls["UPDATESDRR"])
                {
                    if (Utils.SDRRListType == "newSDRRtransControl")
                    {
                        if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "UPDATESDRR")
                        {
                            Utils.ListOfControls["UPDATESDRR"] = false;
                            Debug.Assert(newsdrr == null);

                            newsdrr = new newSDRRtransControl("UPDATE", sdrrlist.lblindex.Text);
                            newsdrr.Dock = DockStyle.Fill;
                            newsdrr.Commands = _Commands;
                            newsdrr.labelX1.Text = "Edit SDRR Record";
                            newsdrr.btnbacksdrrmenu.Text = "Back to List of SDRR";
                            this.ShowModalPanel(newsdrr, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            if (!_StartControl.Visible)
                                _StartControl.SlideOutButtonVisible = false;
                        }
                    }
                    else if (Utils.SDRRListType == "DeliveryStatusControl")
                    {
                        if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "UPDATESDRR")
                        {
                            Utils.ListOfControls["UPDATESDRR"] = false;
                            Debug.Assert(delstatus == null);

                            delstatus = new DeliveryStatusControl(sdrrlist.lblsdrrno.Text);
                            delstatus.Dock = DockStyle.Fill;
                            delstatus.Commands = _Commands;
                            this.ShowModalPanel(delstatus, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            if (!_StartControl.Visible)
                                _StartControl.SlideOutButtonVisible = false;
                        }
                    }
                }
            }
        }
        #endregion

        NewNUDtransControl newnud = null;
        NUDInvoicePickingControl nudinvoicepick = null;
        ListNUDTransControl nudlist = null;
        #region NUD
        private void NUDOpenNewControls(object sender, EventArgs e)
        {
            if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NEWNUD")
            {
                if (Utils.ListOfControls["NEWNUD"])
                {
                    Debug.Assert(newnud == null);
                    Utils.ListOfControls["NEWNUD"] = false;
                    newnud = new NewNUDtransControl("NEW",null);
                    newnud.Dock = DockStyle.Fill;
                    newnud.Commands = _Commands;
                    this.ShowModalPanel(newnud, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NUDINVOICEPICK")
            {
                if (Utils.ListOfControls["NUDINVOICEPICK"])
                {
                    
                    Debug.Assert(nudinvoicepick == null);
                    Utils.ListOfControls["NUDINVOICEPICK"] = false;
                    nudinvoicepick = new NUDInvoicePickingControl(new string[] { newnud.cboclientname.SelectedValue.ToString(), newnud.cboCustomer.Text, newnud._entrytype }, newnud._invoice);
                    nudinvoicepick.Dock = DockStyle.Fill;
                    nudinvoicepick.Commands = _Commands;
                    this.ShowModalPanel(nudinvoicepick, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }            
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "PRINT")
            {
                if (Utils.ListOfControls["PRINT"])
                {
                    if (newnud.validateentry())
                    {
                        Debug.Assert(cviewer == null);
                        Utils.ListOfControls["PRINT"] = false;
                        Utils.ListOfControls["NUDSAVEEXECUTE"] = false;
                        ReportDocument rviewer = new ReportDocument();

                        rviewer = new crtNUD();
                        rviewer.Database.Tables[0].SetDataSource(newnud.printableData);
                        rviewer.SetParameterValue("delman", newnud.txtdelman.Text);
                        rviewer.SetParameterValue("custname", newnud.cboCustomer.Text);
                        rviewer.SetParameterValue("deldate", newnud.dtdelivered.Value);
                        rviewer.SetParameterValue("totalamnt", newnud.totalinvoicev);
                        rviewer.SetParameterValue("terms", newnud.cboTerms.Text);
                        rviewer.SetParameterValue("dateprep", newnud.dtprepared.Value);
                        rviewer.SetParameterValue("clientname", newnud.cboclientname.Text);

                        cviewer = new reportviewercontrol();
                        cviewer.crtviewer.ReportSource = rviewer;
                        cviewer.Dock = DockStyle.Fill;
                        cviewer.Commands = _Commands;
                        this.ShowModalPanel(cviewer, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        if (!_StartControl.Visible)
                            _StartControl.SlideOutButtonVisible = false;
                    }
                }
                RemoveActiveControl_onList("PRINT"); 
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NUDLIST")
            {
                if (Utils.ListOfControls["NUDLIST"])
                {
                    Utils.ListOfControls["NUDLIST"] = false;
                    Debug.Assert(nudlist == null);

                    nudlist = new ListNUDTransControl();
                    nudlist.Dock = DockStyle.Fill;
                    nudlist.Commands = _Commands;
                    this.ShowModalPanel(nudlist, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }
        }
        private void NUDCloseCurrentControlExecute(object sender, EventArgs e)
        {
            if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NUDMENU")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;
                    Debug.Assert(nudmenu != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    this.CloseModalPanel(nudmenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    nudmenu.Commands = null;
                    nudmenu.Dispose();
                    nudmenu = null;
                }
                RemoveActiveControl_onList("NUDMENU");
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NEWNUD" || Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "UPDATENUD")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;
                    Debug.Assert(newnud != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    this.CloseModalPanel(newnud, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    newnud.Commands = null;
                    newnud.Dispose();
                    newnud = null;
                }
                RemoveActiveControl_onList("NEWNUD");
                RemoveActiveControl_onList("UPDATENUD");
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NUDINVOICEPICK")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;

                    Debug.Assert(nudinvoicepick != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    newnud._invoice = nudinvoicepick._invoice;
                    newnud.InitializeDataGrid();
                    this.CloseModalPanel(nudinvoicepick, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    nudinvoicepick.Commands = null;
                    nudinvoicepick.Dispose();
                    nudinvoicepick = null;
                }
                RemoveActiveControl_onList("NUDINVOICEPICK");
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NUDSAVEEXECUTE")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;

                    Utils.ListOfControls["NUDSAVEEXECUTE"] = true;
                    Utils.ListOfControls["PRINT"] = true;

                    Debug.Assert(cviewer != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    this.CloseModalPanel(cviewer, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    cviewer.Commands = null;
                    cviewer.Dispose();
                    cviewer = null;
                }
                RemoveActiveControl_onList("NUDSAVEEXECUTE");
                RemoveActiveControl_onList("PRINT");
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NUDLIST")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;

                    Utils.ListOfControls["NUDLIST"] = true;

                    Debug.Assert(nudlist != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    this.CloseModalPanel(nudlist, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    nudlist.Commands = null;
                    nudlist.Dispose();
                    nudlist = null;
                }
                RemoveActiveControl_onList("NUDLIST");
            }
        }
        private void NUDSaveExecuted(object sender, EventArgs e)
        {
            if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NUDSAVEEXECUTE")
            {
                if (!Utils.ListOfControls["NUDSAVEEXECUTE"])
                {
                    if (newnud .validateentry())
                    {
                        Debug.Assert(cviewer != null);
                        if (!_StartControl.Visible)
                            _StartControl.SlideOutButtonVisible = true;
                        this.CloseModalPanel(cviewer, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        cviewer.Commands = null;
                        cviewer.Dispose();
                        cviewer = null;
                        if (Utils.isNewRecord)
                        {
                            newnud.save();
                            Utils.ListOfControls["NUDSAVEEXECUTE"] = true;
                            Utils.ListOfControls["PRINT"] = true;
                            Utils.ListOfControls["NEWNUD"] = true;
                            Debug.Assert(newnud != null);
                            if (!_StartControl.Visible)
                                _StartControl.SlideOutButtonVisible = true;

                            this.CloseModalPanel(newnud, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            newnud.Commands = null;
                            newnud.Dispose();
                            newnud = null;

                        }
                        else
                        {
                            newnud.update();
                            Utils.ListOfControls["NUDSAVEEXECUTE"] = true;
                            Utils.ListOfControls["PRINT"] = true;
                            Utils.ListOfControls["UPDATENUD"] = true;
                            Debug.Assert(newnud != null);
                            if (!_StartControl.Visible)
                                _StartControl.SlideOutButtonVisible = true;

                            this.CloseModalPanel(newnud, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                            newnud.Commands = null;
                            newnud.Dispose();
                            newnud = null;
                        }
                    }
                    RemoveActiveControl_onList("NUDSAVEEXECUTE");
                    RemoveActiveControl_onList("PRINT");
                    RemoveActiveControl_onList("UPDATENUD");
                    RemoveActiveControl_onList("NEWNUD");
                }
            }
        }
        private void NUDShowTransactionFormExecuted(object sender, EventArgs e)
        {
            if (nudlist.lblnudindex.Text != "")
            {
                if (Utils.ListOfControls["UPDATENUD"])
                {
                    if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "UPDATENUD")
                    {
                        Utils.ListOfControls["UPDATENUD"] = false;
                        Debug.Assert(newnud == null);

                        newnud = new NewNUDtransControl("UPDATE", nudlist.lblnudindex.Text);
                        newnud.Dock = DockStyle.Fill;
                        newnud.Commands = _Commands;
                        newnud.labelX1.Text = "Edit NUD Record";
                        newnud.btnback.Text = "Back to List of NUD";
                        this.ShowModalPanel(newnud, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                        if (!_StartControl.Visible)
                            _StartControl.SlideOutButtonVisible = false;
                    }
                }
            }
        }
        #endregion

        SdrrRegisterControl sdrrregister = null;
        InvoiceRegisterControl invoiceregister = null;
        NudRegisterControl nudregister = null;
        DeliveryStatusReportControl delstatusreport = null;
        #region Reports
        private void ReportOpenNewControls(object sender, EventArgs e)
        {
            if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "SDRRREGISTER_REPORT")
            {
                if (Utils.ListOfControls["SDRRREGISTER_REPORT"])
                {
                    Debug.Assert(sdrrregister == null);
                    Utils.ListOfControls["SDRRREGISTER_REPORT"] = false;
                    sdrrregister = new SdrrRegisterControl();
                    sdrrregister.Dock = DockStyle.Fill;
                    sdrrregister.Commands = _Commands;
                    this.ShowModalPanel(sdrrregister, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "INVREG_REPORT")
            {
                if (Utils.ListOfControls["INVREG_REPORT"])
                {
                    Debug.Assert(invoiceregister == null);
                    Utils.ListOfControls["INVREG_REPORT"] = false;
                    invoiceregister = new InvoiceRegisterControl();
                    invoiceregister.Dock = DockStyle.Fill;
                    invoiceregister.Commands = _Commands;
                    this.ShowModalPanel(invoiceregister, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NUDREG_REPORT")
            {
                if (Utils.ListOfControls["NUDREG_REPORT"])
                {
                    Debug.Assert(nudregister == null);
                    Utils.ListOfControls["NUDREG_REPORT"] = false;
                    nudregister = new NudRegisterControl();
                    nudregister.Dock = DockStyle.Fill;
                    nudregister.Commands = _Commands;
                    this.ShowModalPanel(nudregister, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "DELSTATUS_REPORT")
            {
                if (Utils.ListOfControls["DELSTATUS_REPORT"])
                {
                    Debug.Assert(delstatusreport == null);
                    Utils.ListOfControls["DELSTATUS_REPORT"] = false;
                    delstatusreport = new DeliveryStatusReportControl();
                    delstatusreport.Dock = DockStyle.Fill;
                    delstatusreport.Commands = _Commands;
                    this.ShowModalPanel(delstatusreport, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = false;
                }
            }

        }        
        private void ReportCloseCurrentControlExecute(object sender, EventArgs e)
        {
            if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "REPORTSMENU")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;
                    Debug.Assert(reportmenu != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    this.CloseModalPanel(reportmenu, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    reportmenu.Commands = null;
                    reportmenu.Dispose();
                    reportmenu = null;
                }
                RemoveActiveControl_onList("REPORTSMENU");
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "SDRRREGISTER_REPORT")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;
                    Debug.Assert(sdrrregister != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    this.CloseModalPanel(sdrrregister, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    sdrrregister.Commands = null;
                    sdrrregister.Dispose();
                    sdrrregister = null;                    
                }
                RemoveActiveControl_onList("SDRRREGISTER_REPORT");
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "INVREG_REPORT")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;
                    Debug.Assert(invoiceregister != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    this.CloseModalPanel(invoiceregister, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    invoiceregister.Commands = null;
                    invoiceregister.Dispose();
                    invoiceregister = null;                    
                }
                RemoveActiveControl_onList("INVREG_REPORT");
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "NUDREG_REPORT")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;
                    Debug.Assert(nudregister != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    this.CloseModalPanel(nudregister, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    nudregister.Commands = null;
                    nudregister.Dispose();
                    nudregister = null;
                }
                RemoveActiveControl_onList("NUDREG_REPORT");
            }
            else if (Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1] == "DELSTATUS_REPORT")
            {
                if (!Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]])
                {
                    Utils.ListOfControls[Utils.ListOfActiveControls[Utils.ListOfActiveControls.Count - 1]] = true;
                    Debug.Assert(delstatusreport != null);
                    if (!_StartControl.Visible)
                        _StartControl.SlideOutButtonVisible = true;

                    this.CloseModalPanel(delstatusreport, DevComponents.DotNetBar.Controls.eSlideSide.Left);
                    delstatusreport.Commands = null;
                    delstatusreport.Dispose();
                    delstatusreport = null;                    
                }
                RemoveActiveControl_onList("DELSTATUS_REPORT");
            }          
        }
        #endregion

        #region
        #endregion
        #region Standard Command
        private void GettingStartedExecuted(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.devcomponents.com/kb2/?p=1160");
        }
        private void NotImplementedExecuted(object sender, EventArgs e)
        {
            MessageBoxEx.Show(this, "Undercontruction!", "SDRR Generator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void DevComponentsExecuted(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.devcomponents.com/dotnetbar/");
        }

        private void ChangeMetroThemeExecuted(object sender, EventArgs e)
        {
            ICommandSource source = (ICommandSource)sender;
            MetroColorGeneratorParameters theme = (MetroColorGeneratorParameters)source.CommandParameter;
            StyleManager.MetroColorGeneratorParameters = theme;
        }
        private void ToggleStartControlExecuted(object sender, EventArgs e)
        {
            _StartControl.IsOpen = !_StartControl.IsOpen;
        }
        #endregion
        #endregion

        #region UI Code
        void StartControl_Click(object sender, EventArgs e)
        {
            if (Utils.ListOfControls["MAIN"] == false)
            {
                _StartControl.IsOpen = false;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            UpdateControlsSizeAndLocation();
            base.OnLoad(e);
        }

        private Rectangle GetStartControlBounds()
        {
            int captionHeight = metroShell1.MetroTabStrip.GetCaptionHeight() + 2;
            Thickness borderThickness = this.GetBorderThickness();
            return new Rectangle((int)borderThickness.Left, captionHeight, this.Width - (int)borderThickness.Horizontal, this.Height - captionHeight - 1);
        }
        private void UpdateControlsSizeAndLocation()
        {
            if (_StartControl != null)
            {
                if (!_StartControl.IsOpen)
                {
                    //_StartControl.OpenBounds = GetStartControlBounds();
                }
                else
                    _StartControl.Bounds = GetStartControlBounds();
                if (!IsModalPanelDisplayed)
                    _StartControl.BringToFront();
            }
        }
        protected override void OnResize(EventArgs e)
        {
            UpdateControlsSizeAndLocation();
            base.OnResize(e);
        }

        private void metroAppButton1_ExpandChange(object sender, EventArgs e)
        {
            //if (!_StartControl.Visible)
                //_StartControl.SlideOutButtonVisible = !metroAppButton1.Expanded;
        }

        private void metroShell1_SettingsButtonClick(object sender, EventArgs e)
        {
            //MessageBoxEx.Show(this, "MetroShell Settings Button Clicked", "Metro Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ChangeConnection cc = new ChangeConnection(false);
            cc.StartPosition = FormStartPosition.CenterScreen;
            cc.Icon = this.Icon;
            cc.ShowDialog();
        }

        private void metroShell1_HelpButtonClick(object sender, EventArgs e)
        {
            MessageBoxEx.Show(this, "MetroShell Help Button Clicked", "Metro Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroShell1_SelectedTabChanged(object sender, EventArgs e)
        {
            UpdateControlsSizeAndLocation();
        }
        #endregion

        private void RemoveActiveControl_onList(String name)
        {
            List<String> Clean = new List<string>();
            foreach (String item in Utils.ListOfActiveControls)
                Clean.Add(item);

            foreach (String item in Utils.ListOfActiveControls)
            {
                if(item == name)
                    Clean.Remove(item);
            }
                
            Utils.ListOfActiveControls = Clean;
        }
        private void MainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.F12)
                LoginAdministrator();
        }
        public void LoginAdministrator()
        {
            PasswordDialogForm password_dialog = new PasswordDialogForm();
            password_dialog.Icon = this.Icon;
            if (password_dialog.ShowDialog() == DialogResult.OK)
            {
                String password = password_dialog.Password;
                if (password == "tqbfjotld")
                {
                    this.Visible = false;
                    ChangeConnection dialog = new ChangeConnection(true);
                    dialog.Icon = this.Icon;
                    dialog.ShowDialog();
                    this.Visible = true;
                }
                else
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show("Password is wrong!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}