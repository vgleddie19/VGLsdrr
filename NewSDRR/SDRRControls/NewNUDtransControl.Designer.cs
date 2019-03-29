namespace NewSDRR
{
    partial class NewNUDtransControl
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
            this.btnAddInvoices = new DevComponents.DotNetBar.ButtonX();
            this.btnback = new DevComponents.DotNetBar.ButtonX();
            this.btnAddReason = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTerms = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.label6 = new System.Windows.Forms.Label();
            this.cboclientname = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboCustomer = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudgrid = new System.Windows.Forms.DataGridView();
            this.dtdelivered = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label5 = new System.Windows.Forms.Label();
            this.dtprepared = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdelman = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdelivered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtprepared)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(82)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.btnAddInvoices);
            this.panel1.Controls.Add(this.btnback);
            this.panel1.Controls.Add(this.btnAddReason);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboTerms);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboclientname);
            this.panel1.Controls.Add(this.cboCustomer);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.dtdelivered);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtprepared);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtdelman);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(935, 438);
            this.panel1.TabIndex = 0;
            // 
            // btnAddInvoices
            // 
            this.btnAddInvoices.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddInvoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnAddInvoices.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnAddInvoices.Location = new System.Drawing.Point(843, 48);
            this.btnAddInvoices.Name = "btnAddInvoices";
            this.btnAddInvoices.Size = new System.Drawing.Size(60, 40);
            this.btnAddInvoices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddInvoices.TabIndex = 50;
            this.btnAddInvoices.Text = "&Add Invoices";
            this.btnAddInvoices.Click += new System.EventHandler(this.btnAddInvoices_Click);
            // 
            // btnback
            // 
            this.btnback.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnback.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnback.Location = new System.Drawing.Point(621, 383);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(91, 40);
            this.btnback.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnback.TabIndex = 49;
            this.btnback.Text = "&Back";
            // 
            // btnAddReason
            // 
            this.btnAddReason.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddReason.Location = new System.Drawing.Point(718, 383);
            this.btnAddReason.Name = "btnAddReason";
            this.btnAddReason.Size = new System.Drawing.Size(91, 40);
            this.btnAddReason.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddReason.TabIndex = 49;
            this.btnAddReason.Text = "Add Reason";
            this.btnAddReason.Click += new System.EventHandler(this.btnAddReason_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Location = new System.Drawing.Point(812, 383);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 40);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.label8.Location = new System.Drawing.Point(26, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(648, 22);
            this.label8.TabIndex = 45;
            this.label8.Text = "            Please update the Invoice Date in your sdrr form before encoding NUD";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTerms
            // 
            this.cboTerms.DisplayMember = "Text";
            this.cboTerms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerms.FormattingEnabled = true;
            this.cboTerms.ItemHeight = 14;
            this.cboTerms.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem3});
            this.cboTerms.Location = new System.Drawing.Point(492, 68);
            this.cboTerms.Name = "cboTerms";
            this.cboTerms.Size = new System.Drawing.Size(345, 20);
            this.cboTerms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTerms.TabIndex = 40;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "COD";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "30Days";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.label6.Location = new System.Drawing.Point(391, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 22);
            this.label6.TabIndex = 44;
            this.label6.Text = "Terms";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboclientname
            // 
            this.cboclientname.DisplayMember = "Text";
            this.cboclientname.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboclientname.FormattingEnabled = true;
            this.cboclientname.ItemHeight = 14;
            this.cboclientname.Location = new System.Drawing.Point(492, 19);
            this.cboclientname.Name = "cboclientname";
            this.cboclientname.Size = new System.Drawing.Size(345, 20);
            this.cboclientname.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboclientname.TabIndex = 38;
            this.cboclientname.SelectedIndexChanged += new System.EventHandler(this.cboclientname_SelectedIndexChanged);
            // 
            // cboCustomer
            // 
            this.cboCustomer.DisplayMember = "Text";
            this.cboCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.ItemHeight = 14;
            this.cboCustomer.Location = new System.Drawing.Point(492, 45);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(345, 20);
            this.cboCustomer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboCustomer.TabIndex = 39;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudgrid);
            this.groupBox2.Location = new System.Drawing.Point(26, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(880, 269);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "To the following Customer";
            // 
            // nudgrid
            // 
            this.nudgrid.AllowUserToAddRows = false;
            this.nudgrid.AllowUserToDeleteRows = false;
            this.nudgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.nudgrid.ColumnHeadersHeight = 50;
            this.nudgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudgrid.Location = new System.Drawing.Point(3, 16);
            this.nudgrid.Name = "nudgrid";
            this.nudgrid.Size = new System.Drawing.Size(874, 250);
            this.nudgrid.TabIndex = 6;
            this.nudgrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.nudgrid_EditingControlShowing);
            // 
            // dtdelivered
            // 
            // 
            // 
            // 
            this.dtdelivered.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtdelivered.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtdelivered.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtdelivered.ButtonDropDown.Visible = true;
            this.dtdelivered.IsPopupCalendarOpen = false;
            this.dtdelivered.Location = new System.Drawing.Point(111, 45);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtdelivered.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtdelivered.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtdelivered.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtdelivered.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtdelivered.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtdelivered.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtdelivered.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtdelivered.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtdelivered.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtdelivered.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtdelivered.MonthCalendar.DisplayMonth = new System.DateTime(2018, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtdelivered.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtdelivered.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtdelivered.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtdelivered.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtdelivered.MonthCalendar.TodayButtonVisible = true;
            this.dtdelivered.Name = "dtdelivered";
            this.dtdelivered.Size = new System.Drawing.Size(281, 20);
            this.dtdelivered.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtdelivered.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.label5.Location = new System.Drawing.Point(391, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 22);
            this.label5.TabIndex = 31;
            this.label5.Text = "Client name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtprepared
            // 
            // 
            // 
            // 
            this.dtprepared.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtprepared.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtprepared.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtprepared.ButtonDropDown.Visible = true;
            this.dtprepared.IsPopupCalendarOpen = false;
            this.dtprepared.Location = new System.Drawing.Point(111, 19);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtprepared.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtprepared.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtprepared.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtprepared.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtprepared.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtprepared.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtprepared.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtprepared.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtprepared.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtprepared.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtprepared.MonthCalendar.DisplayMonth = new System.DateTime(2018, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtprepared.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtprepared.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtprepared.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtprepared.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtprepared.MonthCalendar.TodayButtonVisible = true;
            this.dtprepared.Name = "dtprepared";
            this.dtprepared.Size = new System.Drawing.Size(281, 20);
            this.dtprepared.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtprepared.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.label4.Location = new System.Drawing.Point(391, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 22);
            this.label4.TabIndex = 29;
            this.label4.Text = "Customer Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.label3.Location = new System.Drawing.Point(10, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 22);
            this.label3.TabIndex = 32;
            this.label3.Text = "Delivery Man";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 35;
            this.label2.Text = "Date Delivered";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtdelman
            // 
            this.txtdelman.Location = new System.Drawing.Point(111, 68);
            this.txtdelman.Name = "txtdelman";
            this.txtdelman.Size = new System.Drawing.Size(281, 20);
            this.txtdelman.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.label7.Location = new System.Drawing.Point(26, 377);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(648, 22);
            this.label7.TabIndex = 34;
            this.label7.Text = "Noted: One Customer per NUD";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 23);
            this.label1.TabIndex = 33;
            this.label1.Text = "Date Prepared";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.labelX1.Location = new System.Drawing.Point(16, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(935, 40);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "Create New NUD";
            // 
            // NewNUDtransControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.panel1);
            this.Name = "NewNUDtransControl";
            this.Size = new System.Drawing.Size(963, 514);
            this.Load += new System.EventHandler(this.NewNUDtransControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudgrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtdelivered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtprepared)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.LabelX labelX1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label8;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cboTerms;
        public DevComponents.Editors.ComboItem comboItem1;
        public DevComponents.Editors.ComboItem comboItem3;
        public System.Windows.Forms.Label label6;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cboclientname;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cboCustomer;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView nudgrid;
        public DevComponents.Editors.DateTimeAdv.DateTimeInput dtdelivered;
        public System.Windows.Forms.Label label5;
        public DevComponents.Editors.DateTimeAdv.DateTimeInput dtprepared;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtdelman;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label1;
        public DevComponents.DotNetBar.ButtonX btnAddReason;
        public DevComponents.DotNetBar.ButtonX btnSave;
        public DevComponents.DotNetBar.ButtonX btnback;
        public DevComponents.DotNetBar.ButtonX btnAddInvoices;
    }
}
