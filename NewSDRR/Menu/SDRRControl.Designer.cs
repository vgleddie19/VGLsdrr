namespace NewSDRR
{
    partial class SDRRControl
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
            this.SDRRNew_tile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.EditNew_tile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.EditDelStattile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.back_tile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.chartUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
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
            this.labelX1.Size = new System.Drawing.Size(538, 40);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "SDRR MENU";
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
            this.SDRRNew_tile,
            this.EditNew_tile,
            this.EditDelStattile,
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
            // SDRRNew_tile
            // 
            this.SDRRNew_tile.Name = "SDRRNew_tile";
            this.SDRRNew_tile.SymbolColor = System.Drawing.Color.Empty;
            this.SDRRNew_tile.Text = "<font size=\"+4\">Create New<br/>SDRR</font>";
            this.SDRRNew_tile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.SDRRNew_tile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(83)))), ((int)(((byte)(117)))));
            this.SDRRNew_tile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(50)))));
            this.SDRRNew_tile.TileStyle.BackColorGradientAngle = 45;
            this.SDRRNew_tile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SDRRNew_tile.TileStyle.PaddingBottom = 4;
            this.SDRRNew_tile.TileStyle.PaddingLeft = 4;
            this.SDRRNew_tile.TileStyle.PaddingRight = 4;
            this.SDRRNew_tile.TileStyle.PaddingTop = 4;
            this.SDRRNew_tile.TileStyle.TextColor = System.Drawing.Color.White;
            this.SDRRNew_tile.TitleText = "SDRR";
            this.SDRRNew_tile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SDRRNew_tile_MouseDown);
            // 
            // EditNew_tile
            // 
            this.EditNew_tile.Name = "EditNew_tile";
            this.EditNew_tile.SymbolColor = System.Drawing.Color.Empty;
            this.EditNew_tile.Text = "<font size=\"+4\">Edit <br/>SDRR</font>";
            this.EditNew_tile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            // 
            // 
            // 
            this.EditNew_tile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(131)))), ((int)(((byte)(0)))));
            this.EditNew_tile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.EditNew_tile.TileStyle.BackColorGradientAngle = 45;
            this.EditNew_tile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.EditNew_tile.TileStyle.PaddingBottom = 4;
            this.EditNew_tile.TileStyle.PaddingLeft = 4;
            this.EditNew_tile.TileStyle.PaddingRight = 4;
            this.EditNew_tile.TileStyle.PaddingTop = 4;
            this.EditNew_tile.TileStyle.TextColor = System.Drawing.Color.White;
            this.EditNew_tile.TitleText = "Vehicle";
            this.EditNew_tile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditNew_tile_MouseDown);
            // 
            // EditDelStattile
            // 
            this.EditDelStattile.Name = "EditDelStattile";
            this.EditDelStattile.SymbolColor = System.Drawing.Color.Empty;
            this.EditDelStattile.Text = "<font size=\"+4\">Edit SDRR<br/>Delivery Status</font>";
            this.EditDelStattile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta;
            // 
            // 
            // 
            this.EditDelStattile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.EditDelStattile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(128)))), ((int)(((byte)(250)))));
            this.EditDelStattile.TileStyle.BackColorGradientAngle = 45;
            this.EditDelStattile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.EditDelStattile.TileStyle.PaddingBottom = 4;
            this.EditDelStattile.TileStyle.PaddingLeft = 4;
            this.EditDelStattile.TileStyle.PaddingRight = 4;
            this.EditDelStattile.TileStyle.PaddingTop = 4;
            this.EditDelStattile.TileStyle.TextColor = System.Drawing.Color.White;
            this.EditDelStattile.TitleText = "Vehicle";
            this.EditDelStattile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditDelStattile_MouseDown);
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
            this.back_tile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(52)))), ((int)(((byte)(113)))));
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
            this.labelX2.Location = new System.Drawing.Point(555, 7);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(59, 47);
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
            this.pictureBox1.Location = new System.Drawing.Point(617, 14);
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
            // SDRRControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.itemPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SDRRControl";
            this.Size = new System.Drawing.Size(667, 361);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem SDRRNew_tile;
        private DevComponents.DotNetBar.Metro.MetroTileItem EditDelStattile;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer chartUpdateTimer;
        private DevComponents.DotNetBar.Metro.MetroTileItem EditNew_tile;
        private DevComponents.DotNetBar.Metro.MetroTileItem back_tile;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
    }
}
