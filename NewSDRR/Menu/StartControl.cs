using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace NewSDRR
{
    public partial class StartControl : DevComponents.DotNetBar.Controls.SlidePanel
    {
        public StartControl()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            // Center the panel
            itemPanel1.Location = new Point((this.Width - itemPanel1.Width) / 2 + 16, ((this.Height - labelX1.Height - 16) - itemPanel1.Height) / 2 + labelX1.Height + 16);
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
                SDRR_tile.Command = newValue.SDRRCommands.MenuCotrol;
                NUD_tile.Command = newValue.NUDCommands.MenuCotrol;
                Report_tile.Command = newValue.ReportCommands.MenuCotrol;
                appViewTile.Command = newValue.ToggleStartControl;
            }
            else
            {
                NUD_tile.Command = null;
                SDRR_tile.Command = null;
                Report_tile.Command = null;
                appViewTile.Command = null;
            }
        }

        private void SDRR_tile_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.ListOfActiveControls.Add("SDRRMENU");
        }

        private void NUD_tile_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.ListOfActiveControls.Add("NUDMENU");
        }

        private void Report_tile_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.ListOfActiveControls.Add("REPORTSMENU");
        }
    }
}
