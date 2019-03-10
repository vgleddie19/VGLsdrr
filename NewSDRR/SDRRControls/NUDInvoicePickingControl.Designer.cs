namespace NewSDRR
{
    partial class NUDInvoicePickingControl
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.gridcolinv = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcolcust = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcolzone = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcolamt = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.lblpath = new System.Windows.Forms.Label();
            this.groupList = new System.Windows.Forms.GroupBox();
            this.gridinvoice = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridcolno = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcolsdrrno = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcolinvdate = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridcolindex = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSDRRNo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupList.SuspendLayout();
            this.SuspendLayout();
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
            this.labelX1.Location = new System.Drawing.Point(8, 7);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(815, 40);
            this.labelX1.TabIndex = 25;
            this.labelX1.Text = "N.U.D.  Invoice Picking";
            // 
            // gridcolinv
            // 
            this.gridcolinv.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcolinv.HeaderText = "Invoice #";
            this.gridcolinv.Name = "gridcolinv";
            // 
            // gridcolcust
            // 
            this.gridcolcust.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.gridcolcust.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcolcust.HeaderText = "Customer Name";
            this.gridcolcust.Name = "gridcolcust";
            this.gridcolcust.Width = 250;
            // 
            // gridcolzone
            // 
            this.gridcolzone.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcolzone.HeaderText = "Zone";
            this.gridcolzone.Name = "gridcolzone";
            this.gridcolzone.Width = 60;
            // 
            // gridcolamt
            // 
            this.gridcolamt.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcolamt.HeaderText = "Amount";
            this.gridcolamt.Name = "gridcolamt";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(82)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblpath);
            this.panel1.Controls.Add(this.groupList);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblSDRRNo);
            this.panel1.Location = new System.Drawing.Point(8, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 436);
            this.panel1.TabIndex = 24;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.Location = new System.Drawing.Point(721, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 38);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "&OK";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "CLIENT NAME";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblpath
            // 
            this.lblpath.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(219)))), ((int)(((byte)(251)))));
            this.lblpath.Location = new System.Drawing.Point(168, 34);
            this.lblpath.Name = "lblpath";
            this.lblpath.Size = new System.Drawing.Size(547, 21);
            this.lblpath.TabIndex = 16;
            this.lblpath.Text = "SDRR DETAILS";
            // 
            // groupList
            // 
            this.groupList.Controls.Add(this.gridinvoice);
            this.groupList.Location = new System.Drawing.Point(9, 58);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(800, 375);
            this.groupList.TabIndex = 11;
            this.groupList.TabStop = false;
            // 
            // gridinvoice
            // 
            this.gridinvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridinvoice.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.gridinvoice.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.gridinvoice.Location = new System.Drawing.Point(3, 16);
            this.gridinvoice.Name = "gridinvoice";
            // 
            // 
            // 
            this.gridinvoice.PrimaryGrid.Columns.Add(this.gridcolno);
            this.gridinvoice.PrimaryGrid.Columns.Add(this.gridcolsdrrno);
            this.gridinvoice.PrimaryGrid.Columns.Add(this.gridcolinv);
            this.gridinvoice.PrimaryGrid.Columns.Add(this.gridcolinvdate);
            this.gridinvoice.PrimaryGrid.Columns.Add(this.gridcolcust);
            this.gridinvoice.PrimaryGrid.Columns.Add(this.gridcolzone);
            this.gridinvoice.PrimaryGrid.Columns.Add(this.gridcolamt);
            this.gridinvoice.PrimaryGrid.Columns.Add(this.gridcolindex);
            this.gridinvoice.PrimaryGrid.EnableColumnFiltering = true;
            this.gridinvoice.PrimaryGrid.EnableFiltering = true;
            // 
            // 
            // 
            this.gridinvoice.PrimaryGrid.Filter.RowHeight = 30;
            this.gridinvoice.PrimaryGrid.Filter.Visible = true;
            this.gridinvoice.Size = new System.Drawing.Size(794, 356);
            this.gridinvoice.TabIndex = 8;
            this.gridinvoice.Text = "superGridControl1";
            this.gridinvoice.CellValueChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs>(this.gridinvoice_CellValueChanged);
            // 
            // gridcolno
            // 
            this.gridcolno.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridcolno.HeaderText = " ";
            this.gridcolno.Name = "gridcolno";
            this.gridcolno.Width = 60;
            // 
            // gridcolsdrrno
            // 
            this.gridcolsdrrno.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.gridcolsdrrno.HeaderText = "SDRR Number";
            this.gridcolsdrrno.Name = "gridcolsdrrno";
            // 
            // gridcolinvdate
            // 
            this.gridcolinvdate.HeaderText = "Invoice Date";
            this.gridcolinvdate.Name = "gridcolinvdate";
            // 
            // gridcolindex
            // 
            this.gridcolindex.Name = "gridcolindex";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.label3.Location = new System.Drawing.Point(2, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Customer Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSDRRNo
            // 
            this.lblSDRRNo.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDRRNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(219)))), ((int)(((byte)(251)))));
            this.lblSDRRNo.Location = new System.Drawing.Point(168, 6);
            this.lblSDRRNo.Name = "lblSDRRNo";
            this.lblSDRRNo.Size = new System.Drawing.Size(547, 21);
            this.lblSDRRNo.TabIndex = 14;
            this.lblSDRRNo.Text = "SDRR DETAILS";
            // 
            // NUDInvoicePickingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.panel1);
            this.Name = "NUDInvoicePickingControl";
            this.Size = new System.Drawing.Size(829, 495);
            this.Load += new System.EventHandler(this.SDRRInvoicePickingControl_Load);
            this.panel1.ResumeLayout(false);
            this.groupList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolinv;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolcust;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolzone;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolamt;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblpath;
        private System.Windows.Forms.GroupBox groupList;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridinvoice;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSDRRNo;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolsdrrno;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolinvdate;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridcolindex;
    }
}
