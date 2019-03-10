namespace NewSDRR
{
    partial class ReportsControl
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
            this.components = new System.ComponentModel.Container();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.allsdrr_tile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.invoicereg_tile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.nudreg_tile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.delstatus_tile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.back_tile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.chartUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem4 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem5 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem6 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(176)))), ((int)(((byte)(76)))));
            this.labelX1.Location = new System.Drawing.Point(16, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(538, 40);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "REPORT MENU";
            // 
            // itemPanel1
            // 
            this.itemPanel1.AutoScroll = true;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.DragDropSupport = true;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new System.Drawing.Point(37, 63);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.ReserveLeftSpace = false;
            this.itemPanel1.Size = new System.Drawing.Size(572, 295);
            this.itemPanel1.TabIndex = 3;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.ItemSpacing = 6;
            this.itemContainer1.MinimumSize = new System.Drawing.Size(560, 290);
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.ResizeItemsToFit = false;
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.allsdrr_tile,
            this.invoicereg_tile,
            this.nudreg_tile,
            this.delstatus_tile,
            this.back_tile});
            // 
            // 
            // 
            this.itemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // allsdrr_tile
            // 
            this.allsdrr_tile.Name = "allsdrr_tile";
            this.allsdrr_tile.SymbolColor = System.Drawing.Color.Empty;
            this.allsdrr_tile.Text = "<font size=\"+4\">SDRR<br/>Register</font>";
            this.allsdrr_tile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.allsdrr_tile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(104)))), ((int)(((byte)(224)))));
            this.allsdrr_tile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(82)))), ((int)(((byte)(237)))));
            this.allsdrr_tile.TileStyle.BackColorGradientAngle = 45;
            this.allsdrr_tile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.allsdrr_tile.TileStyle.PaddingBottom = 4;
            this.allsdrr_tile.TileStyle.PaddingLeft = 4;
            this.allsdrr_tile.TileStyle.PaddingRight = 4;
            this.allsdrr_tile.TileStyle.PaddingTop = 4;
            this.allsdrr_tile.TileStyle.TextColor = System.Drawing.Color.White;
            this.allsdrr_tile.TitleText = "SDRR";
            this.allsdrr_tile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SDRRNew_tile_MouseDown);
            // 
            // invoicereg_tile
            // 
            this.invoicereg_tile.Name = "invoicereg_tile";
            this.invoicereg_tile.SymbolColor = System.Drawing.Color.Empty;
            this.invoicereg_tile.Text = "<font size=\"+4\">Invoice <br/>Register</font>";
            this.invoicereg_tile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            // 
            // 
            // 
            this.invoicereg_tile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(67)))));
            this.invoicereg_tile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(71)))), ((int)(((byte)(87)))));
            this.invoicereg_tile.TileStyle.BackColorGradientAngle = 45;
            this.invoicereg_tile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.invoicereg_tile.TileStyle.PaddingBottom = 4;
            this.invoicereg_tile.TileStyle.PaddingLeft = 4;
            this.invoicereg_tile.TileStyle.PaddingRight = 4;
            this.invoicereg_tile.TileStyle.PaddingTop = 4;
            this.invoicereg_tile.TileStyle.TextColor = System.Drawing.Color.White;
            this.invoicereg_tile.TitleText = "Vehicle";
            this.invoicereg_tile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.invoicereg_tile_MouseDown);
            // 
            // nudreg_tile
            // 
            this.nudreg_tile.Name = "nudreg_tile";
            this.nudreg_tile.SymbolColor = System.Drawing.Color.Empty;
            this.nudreg_tile.Text = "<font size=\"+4\">NUD <br/>Register</font>";
            this.nudreg_tile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            // 
            // 
            // 
            this.nudreg_tile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(82)))), ((int)(((byte)(83)))));
            this.nudreg_tile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(2)))));
            this.nudreg_tile.TileStyle.BackColorGradientAngle = 45;
            this.nudreg_tile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.nudreg_tile.TileStyle.PaddingBottom = 4;
            this.nudreg_tile.TileStyle.PaddingLeft = 4;
            this.nudreg_tile.TileStyle.PaddingRight = 4;
            this.nudreg_tile.TileStyle.PaddingTop = 4;
            this.nudreg_tile.TileStyle.TextColor = System.Drawing.Color.White;
            this.nudreg_tile.TitleText = "Vehicle";
            this.nudreg_tile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nudreg_tile_MouseDown);
            // 
            // delstatus_tile
            // 
            this.delstatus_tile.Name = "delstatus_tile";
            this.delstatus_tile.SymbolColor = System.Drawing.Color.Empty;
            this.delstatus_tile.Text = "<font size=\"+4\">Delivery Status<br/>Report</font>";
            this.delstatus_tile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.delstatus_tile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(189)))), ((int)(((byte)(227)))));
            this.delstatus_tile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(155)))));
            this.delstatus_tile.TileStyle.BackColorGradientAngle = 45;
            this.delstatus_tile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.delstatus_tile.TileStyle.PaddingBottom = 4;
            this.delstatus_tile.TileStyle.PaddingLeft = 4;
            this.delstatus_tile.TileStyle.PaddingRight = 4;
            this.delstatus_tile.TileStyle.PaddingTop = 4;
            this.delstatus_tile.TileStyle.TextColor = System.Drawing.Color.White;
            this.delstatus_tile.TitleText = "SDRR";
            this.delstatus_tile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.delstatus_tile_MouseDown);
            // 
            // back_tile
            // 
            this.back_tile.Name = "back_tile";
            this.back_tile.SymbolColor = System.Drawing.Color.Empty;
            this.back_tile.Text = "<font size=\"+4\">Back To Main<br/></font>";
            this.back_tile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Plum;
            // 
            // 
            // 
            this.back_tile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.back_tile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(129)))));
            this.back_tile.TileStyle.BackColorGradientAngle = 45;
            this.back_tile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.back_tile.TileStyle.PaddingBottom = 4;
            this.back_tile.TileStyle.PaddingLeft = 4;
            this.back_tile.TileStyle.PaddingRight = 4;
            this.back_tile.TileStyle.PaddingTop = 4;
            this.back_tile.TileStyle.TextColor = System.Drawing.Color.White;
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(548, 7);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(69, 47);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "<div align=\"center\"><font size=\"+4\">VGL</font><br/>E. Cabellon</div>";
            // 
            // chartUpdateTimer
            // 
            this.chartUpdateTimer.Enabled = true;
            this.chartUpdateTimer.Interval = 10000;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(615, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 33);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem1.Text = "<font size=\"+4\">Update SDRR<br/>Delivery Status</font>";
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange;
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.metroTileItem1.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(57)))), ((int)(((byte)(0)))));
            this.metroTileItem1.TileStyle.BackColorGradientAngle = 45;
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem1.TileStyle.PaddingBottom = 4;
            this.metroTileItem1.TileStyle.PaddingLeft = 4;
            this.metroTileItem1.TileStyle.PaddingRight = 4;
            this.metroTileItem1.TileStyle.PaddingTop = 4;
            this.metroTileItem1.TileStyle.TextColor = System.Drawing.Color.White;
            // 
            // metroTileItem4
            // 
            this.metroTileItem4.Name = "metroTileItem4";
            this.metroTileItem4.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem4.Text = "<font size=\"+4\">Invoice <br/>Register</font>";
            this.metroTileItem4.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            // 
            // 
            // 
            this.metroTileItem4.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(131)))), ((int)(((byte)(0)))));
            this.metroTileItem4.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(136)))), ((int)(((byte)(0)))));
            this.metroTileItem4.TileStyle.BackColorGradientAngle = 45;
            this.metroTileItem4.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem4.TileStyle.PaddingBottom = 4;
            this.metroTileItem4.TileStyle.PaddingLeft = 4;
            this.metroTileItem4.TileStyle.PaddingRight = 4;
            this.metroTileItem4.TileStyle.PaddingTop = 4;
            this.metroTileItem4.TileStyle.TextColor = System.Drawing.Color.White;
            this.metroTileItem4.TitleText = "Vehicle";
            // 
            // metroTileItem5
            // 
            this.metroTileItem5.Name = "metroTileItem5";
            this.metroTileItem5.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem5.Text = "<font size=\"+4\">List Of All<br/>SDRR</font>";
            this.metroTileItem5.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileItem5.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(83)))), ((int)(((byte)(117)))));
            this.metroTileItem5.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(155)))));
            this.metroTileItem5.TileStyle.BackColorGradientAngle = 45;
            this.metroTileItem5.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem5.TileStyle.PaddingBottom = 4;
            this.metroTileItem5.TileStyle.PaddingLeft = 4;
            this.metroTileItem5.TileStyle.PaddingRight = 4;
            this.metroTileItem5.TileStyle.PaddingTop = 4;
            this.metroTileItem5.TileStyle.TextColor = System.Drawing.Color.White;
            this.metroTileItem5.TitleText = "SDRR";
            // 
            // metroTileItem6
            // 
            this.metroTileItem6.Name = "metroTileItem6";
            this.metroTileItem6.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem6.Text = "<font size=\"+4\">Invoice <br/>Register</font>";
            this.metroTileItem6.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            // 
            // 
            // 
            this.metroTileItem6.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(132)))));
            this.metroTileItem6.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(183)))), ((int)(((byte)(49)))));
            this.metroTileItem6.TileStyle.BackColorGradientAngle = 45;
            this.metroTileItem6.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem6.TileStyle.PaddingBottom = 4;
            this.metroTileItem6.TileStyle.PaddingLeft = 4;
            this.metroTileItem6.TileStyle.PaddingRight = 4;
            this.metroTileItem6.TileStyle.PaddingTop = 4;
            this.metroTileItem6.TileStyle.TextColor = System.Drawing.Color.White;
            this.metroTileItem6.TitleText = "Vehicle";
            // 
            // ReportsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.itemPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ReportsControl";
            this.Size = new System.Drawing.Size(667, 361);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem allsdrr_tile;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer chartUpdateTimer;
        private DevComponents.DotNetBar.Metro.MetroTileItem invoicereg_tile;
        private DevComponents.DotNetBar.Metro.MetroTileItem back_tile;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private DevComponents.DotNetBar.Metro.MetroTileItem nudreg_tile;
        private DevComponents.DotNetBar.Metro.MetroTileItem delstatus_tile;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem4;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem5;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem6;
    }
}
