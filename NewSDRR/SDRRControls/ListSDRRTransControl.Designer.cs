namespace NewSDRR
{
    partial class ListSDRRTransControl
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
            this.grd = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lblindex = new DevComponents.DotNetBar.LabelX();
            this.lblsdrrno = new DevComponents.DotNetBar.LabelX();
            this.btnback = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grd);
            this.panel1.Location = new System.Drawing.Point(3, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 422);
            this.panel1.TabIndex = 3;
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.grd.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.grd.Location = new System.Drawing.Point(0, 0);
            this.grd.Name = "grd";
            // 
            // 
            // 
            this.grd.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.grd.PrimaryGrid.EnableColumnFiltering = true;
            this.grd.PrimaryGrid.EnableFiltering = true;
            // 
            // 
            // 
            this.grd.PrimaryGrid.Filter.Visible = true;
            this.grd.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row;
            this.grd.PrimaryGrid.UseAlternateRowStyle = true;
            this.grd.Size = new System.Drawing.Size(951, 422);
            this.grd.TabIndex = 2;
            this.grd.Text = "superGridControl1";
            this.grd.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.grd_CellClick);
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
            this.labelX1.Size = new System.Drawing.Size(954, 40);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "List of SDRR";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(82)))), ((int)(((byte)(221)))));
            this.panel2.Controls.Add(this.labelX2);
            this.panel2.Controls.Add(this.lblindex);
            this.panel2.Controls.Add(this.lblsdrrno);
            this.panel2.Controls.Add(this.btnback);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(3, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(957, 536);
            this.panel2.TabIndex = 4;
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
            this.labelX2.Location = new System.Drawing.Point(11, 61);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(151, 36);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "SDRR Number:";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblindex
            // 
            this.lblindex.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblindex.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblindex.Font = new System.Drawing.Font("Stencil", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblindex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblindex.Location = new System.Drawing.Point(-5, 55);
            this.lblindex.Name = "lblindex";
            this.lblindex.Size = new System.Drawing.Size(117, 21);
            this.lblindex.TabIndex = 7;
            this.lblindex.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblindex.Visible = false;
            // 
            // lblsdrrno
            // 
            this.lblsdrrno.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblsdrrno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblsdrrno.Font = new System.Drawing.Font("Stencil", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsdrrno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(219)))), ((int)(((byte)(251)))));
            this.lblsdrrno.Location = new System.Drawing.Point(169, 27);
            this.lblsdrrno.Name = "lblsdrrno";
            this.lblsdrrno.Size = new System.Drawing.Size(292, 70);
            this.lblsdrrno.TabIndex = 6;
            this.lblsdrrno.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnback
            // 
            this.btnback.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnback.CausesValidation = false;
            this.btnback.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnback.Location = new System.Drawing.Point(845, 55);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(92, 49);
            this.btnback.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnback.TabIndex = 5;
            this.btnback.Text = "Back To SDRR Menu";
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.Location = new System.Drawing.Point(845, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 49);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "View SDRR Record";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ListSDRRTransControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelX1);
            this.Name = "ListSDRRTransControl";
            this.Size = new System.Drawing.Size(963, 588);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.LabelX lblindex;
        public DevComponents.DotNetBar.SuperGrid.SuperGridControl grd;
        public System.Windows.Forms.Panel panel1;
        public DevComponents.DotNetBar.LabelX labelX1;
        public System.Windows.Forms.Panel panel2;
        public DevComponents.DotNetBar.LabelX lblsdrrno;
        public DevComponents.DotNetBar.ButtonX btnUpdate;
        public DevComponents.DotNetBar.ButtonX btnback;
        public DevComponents.DotNetBar.LabelX labelX2;

    }
}
