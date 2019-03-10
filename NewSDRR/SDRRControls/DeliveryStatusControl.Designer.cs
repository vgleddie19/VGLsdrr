namespace NewSDRR
{
    partial class DeliveryStatusControl
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lblsdrrno = new DevComponents.DotNetBar.LabelX();
            this.btnback = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.gridSDRRUpdate = new System.Windows.Forms.DataGridView();
            this.InvoiceNo = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.datedel = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_name = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.cases = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSDRRUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(82)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Controls.Add(this.lblsdrrno);
            this.panel1.Controls.Add(this.btnback);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.gridSDRRUpdate);
            this.panel1.Location = new System.Drawing.Point(16, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(935, 438);
            this.panel1.TabIndex = 0;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Stencil", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.labelX2.Location = new System.Drawing.Point(15, 6);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(169, 36);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "SDRR Number:";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblsdrrno
            // 
            this.lblsdrrno.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblsdrrno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblsdrrno.Font = new System.Drawing.Font("Stencil", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsdrrno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(219)))), ((int)(((byte)(251)))));
            this.lblsdrrno.Location = new System.Drawing.Point(190, 6);
            this.lblsdrrno.Name = "lblsdrrno";
            this.lblsdrrno.Size = new System.Drawing.Size(229, 36);
            this.lblsdrrno.TabIndex = 8;
            this.lblsdrrno.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnback
            // 
            this.btnback.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnback.CausesValidation = false;
            this.btnback.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnback.Location = new System.Drawing.Point(686, 394);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(117, 41);
            this.btnback.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnback.TabIndex = 7;
            this.btnback.Text = "Back";
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.Location = new System.Drawing.Point(809, 394);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(108, 41);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "&Save";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // gridSDRRUpdate
            // 
            this.gridSDRRUpdate.AllowUserToAddRows = false;
            this.gridSDRRUpdate.AllowUserToDeleteRows = false;
            this.gridSDRRUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSDRRUpdate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSDRRUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSDRRUpdate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceNo,
            this.datedel,
            this.status,
            this.remarks,
            this.invoice_value,
            this.customer_name,
            this.cases});
            this.gridSDRRUpdate.Location = new System.Drawing.Point(15, 48);
            this.gridSDRRUpdate.Name = "gridSDRRUpdate";
            this.gridSDRRUpdate.Size = new System.Drawing.Size(903, 340);
            this.gridSDRRUpdate.TabIndex = 2;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.HeaderText = "Invoice #";
            this.InvoiceNo.Name = "InvoiceNo";
            // 
            // datedel
            // 
            this.datedel.AutoAdvance = true;
            // 
            // 
            // 
            this.datedel.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.datedel.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.datedel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.datedel.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.datedel.ButtonClear.Checked = true;
            this.datedel.ButtonClear.Visible = true;
            this.datedel.HeaderText = "Date Received by Customer";
            this.datedel.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.datedel.MinDate = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            // 
            // 
            // 
            this.datedel.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.datedel.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.datedel.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.datedel.MonthCalendar.DisplayMonth = new System.DateTime(2018, 6, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.datedel.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.datedel.Name = "datedel";
            this.datedel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.datedel.ShowUpDown = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Items.AddRange(new object[] {
            "DELIVERED",
            "CANCELLED",
            "RETURNED",
            "WITH CUT ITEM",
            "IN ROUTE",
            "RE DELIVERY",
            "DELIVERED WITH CUT ITEM",
            "WITH DELIVERY DATE SCHEDULE"});
            this.status.Name = "status";
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.remarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // invoice_value
            // 
            this.invoice_value.HeaderText = "Invoice Value";
            this.invoice_value.Name = "invoice_value";
            this.invoice_value.Visible = false;
            // 
            // customer_name
            // 
            this.customer_name.HeaderText = "Customer Name";
            this.customer_name.Name = "customer_name";
            this.customer_name.Visible = false;
            // 
            // cases
            // 
            this.cases.HeaderText = "Cases";
            this.cases.Name = "cases";
            this.cases.Visible = false;
            this.cases.WordWrap = true;
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
            this.labelX1.Location = new System.Drawing.Point(16, 21);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(735, 40);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "UPDATE DELIVERY STATUS";
            // 
            // DeliveryStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.panel1);
            this.Name = "DeliveryStatusControl";
            this.Size = new System.Drawing.Size(963, 514);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSDRRUpdate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridSDRRUpdate;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn InvoiceNo;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn datedel;
        private System.Windows.Forms.DataGridViewComboBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_value;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn customer_name;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn cases;
        public DevComponents.DotNetBar.LabelX labelX1;
        public DevComponents.DotNetBar.ButtonX btnback;
        public DevComponents.DotNetBar.ButtonX btnUpdate;
        public DevComponents.DotNetBar.LabelX labelX2;
        public DevComponents.DotNetBar.LabelX lblsdrrno;
    }
}
