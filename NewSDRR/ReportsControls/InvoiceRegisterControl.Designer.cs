namespace NewSDRR
{
    partial class InvoiceRegisterControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbodelstat = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btncancel = new DevComponents.DotNetBar.ButtonX();
            this.btnGenerate = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crtviewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.loading = new MRG.Controls.UI.LoadingCircle();
            this.Label2 = new System.Windows.Forms.Label();
            this.dtMonth = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(82)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 508);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.Controls.Add(this.dtMonth);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cbodelstat);
            this.panel3.Controls.Add(this.Label1);
            this.panel3.Controls.Add(this.cboClient);
            this.panel3.Controls.Add(this.Label2);
            this.panel3.Location = new System.Drawing.Point(26, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(801, 81);
            this.panel3.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.label4.Location = new System.Drawing.Point(483, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 39);
            this.label4.TabIndex = 35;
            this.label4.Text = "DELIVERY STATUS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbodelstat
            // 
            this.cbodelstat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodelstat.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbodelstat.FormattingEnabled = true;
            this.cbodelstat.Location = new System.Drawing.Point(570, 40);
            this.cbodelstat.Name = "cbodelstat";
            this.cbodelstat.Size = new System.Drawing.Size(226, 29);
            this.cbodelstat.TabIndex = 4;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.Label1.Location = new System.Drawing.Point(493, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(71, 20);
            this.Label1.TabIndex = 31;
            this.Label1.Text = "CLIENT";
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(570, 7);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(226, 29);
            this.cboClient.TabIndex = 3;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.labelX1.Location = new System.Drawing.Point(3, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(824, 32);
            this.labelX1.TabIndex = 212;
            this.labelX1.Text = "  Invoice Register";
            // 
            // btncancel
            // 
            this.btncancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncancel.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btncancel.Location = new System.Drawing.Point(833, 67);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(162, 56);
            this.btncancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btncancel.TabIndex = 6;
            this.btncancel.Text = "&Cancel";
            // 
            // btnGenerate
            // 
            this.btnGenerate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(833, 7);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(162, 56);
            this.btnGenerate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "&Generate Report";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.loading);
            this.panel2.Controls.Add(this.crtviewer);
            this.panel2.Location = new System.Drawing.Point(3, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 362);
            this.panel2.TabIndex = 1;
            // 
            // crtviewer
            // 
            this.crtviewer.ActiveViewIndex = -1;
            this.crtviewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crtviewer.DisplayGroupTree = false;
            this.crtviewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtviewer.Location = new System.Drawing.Point(0, 0);
            this.crtviewer.Name = "crtviewer";
            this.crtviewer.SelectionFormula = "";
            this.crtviewer.ShowCloseButton = false;
            this.crtviewer.ShowGroupTreeButton = false;
            this.crtviewer.ShowRefreshButton = false;
            this.crtviewer.Size = new System.Drawing.Size(992, 362);
            this.crtviewer.TabIndex = 0;
            this.crtviewer.ViewTimeSelectionFormula = "";
            // 
            // loading
            // 
            this.loading.Active = false;
            this.loading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loading.Color = System.Drawing.Color.DarkGray;
            this.loading.InnerCircleRadius = 5;
            this.loading.Location = new System.Drawing.Point(397, 138);
            this.loading.Name = "loading";
            this.loading.NumberSpoke = 12;
            this.loading.OuterCircleRadius = 11;
            this.loading.RotationSpeed = 100;
            this.loading.Size = new System.Drawing.Size(199, 41);
            this.loading.SpokeThickness = 2;
            this.loading.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loading.TabIndex = 1;
            this.loading.Text = "loadingCircle1";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.Label2.Location = new System.Drawing.Point(23, 10);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 20);
            this.Label2.TabIndex = 30;
            this.Label2.Text = "MONTH";
            // 
            // dtMonth
            // 
            // 
            // 
            // 
            this.dtMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtMonth.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtMonth.ButtonDropDown.Visible = true;
            this.dtMonth.CustomFormat = "MMM yyyy";
            this.dtMonth.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtMonth.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.dtMonth.IsPopupCalendarOpen = false;
            this.dtMonth.Location = new System.Drawing.Point(100, 7);
            this.dtMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtMonth.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtMonth.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtMonth.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtMonth.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtMonth.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtMonth.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtMonth.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtMonth.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtMonth.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtMonth.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtMonth.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtMonth.MonthCalendar.DisplayMonth = new System.DateTime(2014, 9, 1, 0, 0, 0, 0);
            this.dtMonth.MonthCalendar.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtMonth.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtMonth.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtMonth.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtMonth.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtMonth.MonthCalendar.TodayButtonVisible = true;
            this.dtMonth.Name = "dtMonth";
            this.dtMonth.Size = new System.Drawing.Size(336, 29);
            this.dtMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.dtMonth.TabIndex = 36;
            // 
            // InvoiceRegisterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "InvoiceRegisterControl";
            this.Size = new System.Drawing.Size(1004, 508);
            this.Load += new System.EventHandler(this.InvoiceRegisterControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtMonth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox cboClient;
        public DevComponents.DotNetBar.LabelX labelX1;
        public DevComponents.DotNetBar.ButtonX btncancel;
        public DevComponents.DotNetBar.ButtonX btnGenerate;
        public System.Windows.Forms.Panel panel2;
        public MRG.Controls.UI.LoadingCircle loading;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crtviewer;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbodelstat;
        public System.Windows.Forms.Label Label2;
        internal DevComponents.Editors.DateTimeAdv.DateTimeInput dtMonth;

    }
}
