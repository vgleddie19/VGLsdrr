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
    public partial class ReportsControl : DevComponents.DotNetBar.Controls.SlidePanel
    {
        public ReportsControl()
        {
            InitializeComponent();
        }

        #region Commands
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
                invoicereg_tile.Command = newValue.ReportCommands.New;
                allsdrr_tile.Command = newValue.ReportCommands.New;
                delstatus_tile.Command =  newValue.ReportCommands.New;
                nudreg_tile.Command = newValue.ReportCommands.New;
                back_tile.Command = newValue.ReportCommands.Cancel;
            }
            else
            {
                invoicereg_tile.Command = null;
                allsdrr_tile.Command = null;
                delstatus_tile.Command = null;
                nudreg_tile.Command = null;
                back_tile.Command = null;
            }
        }
        #endregion

        private void SDRRNew_tile_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.ListOfActiveControls.Add("SDRRREGISTER_REPORT");
        }

        private void invoicereg_tile_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.ListOfActiveControls.Add("INVREG_REPORT");
        }

        private void nudreg_tile_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.ListOfActiveControls.Add("NUDREG_REPORT");
        }

        private void delstatus_tile_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.ListOfActiveControls.Add("DELSTATUS_REPORT");
        }

    }
}
