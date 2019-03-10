namespace NewSDRR
{
    partial class StartControl
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
            this.SDRR_tile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.NUD_tile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.Report_tile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.appViewTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.chartUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.labelX1.Location = new System.Drawing.Point(16, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(509, 40);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "SDRR GENERATOR";
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
            this.SDRR_tile,
            this.NUD_tile,
            this.Report_tile,
            this.appViewTile});
            // 
            // 
            // 
            this.itemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // SDRR_tile
            // 
            this.SDRR_tile.Name = "SDRR_tile";
            this.SDRR_tile.SymbolColor = System.Drawing.Color.Empty;
            this.SDRR_tile.Text = "<font size=\"+4\">SDRR Menu</font>";
            this.SDRR_tile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.SDRR_tile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(83)))), ((int)(((byte)(117)))));
            this.SDRR_tile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(161)))), ((int)(((byte)(255)))));
            this.SDRR_tile.TileStyle.BackColorGradientAngle = 45;
            this.SDRR_tile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SDRR_tile.TileStyle.PaddingBottom = 4;
            this.SDRR_tile.TileStyle.PaddingLeft = 4;
            this.SDRR_tile.TileStyle.PaddingRight = 4;
            this.SDRR_tile.TileStyle.PaddingTop = 4;
            this.SDRR_tile.TileStyle.TextColor = System.Drawing.Color.White;
            this.SDRR_tile.TitleText = "SDRR";
            this.SDRR_tile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SDRR_tile_MouseDown);
            // 
            // NUD_tile
            // 
            this.NUD_tile.Name = "NUD_tile";
            this.NUD_tile.SymbolColor = System.Drawing.Color.Empty;
            this.NUD_tile.Text = "<font size=\"+4\">NUD Menu</font>";
            this.NUD_tile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            // 
            // 
            // 
            this.NUD_tile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(131)))), ((int)(((byte)(0)))));
            this.NUD_tile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(99)))), ((int)(((byte)(72)))));
            this.NUD_tile.TileStyle.BackColorGradientAngle = 45;
            this.NUD_tile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NUD_tile.TileStyle.PaddingBottom = 4;
            this.NUD_tile.TileStyle.PaddingLeft = 4;
            this.NUD_tile.TileStyle.PaddingRight = 4;
            this.NUD_tile.TileStyle.PaddingTop = 4;
            this.NUD_tile.TileStyle.TextColor = System.Drawing.Color.White;
            this.NUD_tile.TitleText = "NUD";
            this.NUD_tile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NUD_tile_MouseDown);
            // 
            // Report_tile
            // 
            this.Report_tile.Name = "Report_tile";
            this.Report_tile.SymbolColor = System.Drawing.Color.Empty;
            this.Report_tile.Text = "<font size=\"+4\">Report Menu</font>";
            this.Report_tile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta;
            // 
            // 
            // 
            this.Report_tile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.Report_tile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(237)))), ((int)(((byte)(159)))));
            this.Report_tile.TileStyle.BackColorGradientAngle = 45;
            this.Report_tile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Report_tile.TileStyle.PaddingBottom = 4;
            this.Report_tile.TileStyle.PaddingLeft = 4;
            this.Report_tile.TileStyle.PaddingRight = 4;
            this.Report_tile.TileStyle.PaddingTop = 4;
            this.Report_tile.TileStyle.TextColor = System.Drawing.Color.White;
            this.Report_tile.TitleText = "Reports";
            this.Report_tile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Report_tile_MouseDown);
            // 
            // appViewTile
            // 
            this.appViewTile.Name = "appViewTile";
            this.appViewTile.SymbolColor = System.Drawing.Color.Empty;
            this.appViewTile.Text = "<font size=\"+4\">Switch to<br/>app view</font>";
            this.appViewTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            // 
            // 
            // 
            this.appViewTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(55)))), ((int)(((byte)(76)))));
            this.appViewTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(237)))), ((int)(((byte)(159)))));
            this.appViewTile.TileStyle.BackColorGradientAngle = 45;
            this.appViewTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.appViewTile.TileStyle.PaddingBottom = 4;
            this.appViewTile.TileStyle.PaddingLeft = 4;
            this.appViewTile.TileStyle.PaddingRight = 4;
            this.appViewTile.TileStyle.PaddingTop = 4;
            this.appViewTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.appViewTile.TitleText = "Application";
            this.appViewTile.Visible = false;
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(531, 7);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(78, 47);
            this.labelX2.TabIndex = 4;
            this.labelX2.Text = "<div align=\"center\"><font size=\"+4\">VGL</font><br/>E.Cabellon</div>";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
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
            // StartControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Lime;
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.itemPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StartControl";
            this.Size = new System.Drawing.Size(667, 361);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Metro.MetroTileItem appViewTile;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem SDRR_tile;
        private DevComponents.DotNetBar.Metro.MetroTileItem Report_tile;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer chartUpdateTimer;
        private DevComponents.DotNetBar.Metro.MetroTileItem NUD_tile;
    }
}
