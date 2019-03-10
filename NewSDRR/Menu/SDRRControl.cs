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
    public partial class SDRRControl : DevComponents.DotNetBar.Controls.SlidePanel
    {
        public SDRRControl()
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
                EditNew_tile.Command = newValue.SDRRCommands.New;
                SDRRNew_tile.Command = newValue.SDRRCommands.New;
                EditDelStattile.Command = newValue.SDRRCommands.New;
                back_tile.Command = newValue.SDRRCommands.Cancel;
            }
            else
            {
                EditNew_tile.Command = null;
                SDRRNew_tile.Command = null;
                EditDelStattile.Command = null;
                back_tile.Command = null;
            }
        }
        #endregion

        private void SDRRNew_tile_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.ListOfActiveControls.Add("NEWSDRR");
            Utils.SDRRListType = "newSDRRtransControl";
            Utils.isNewRecord = true;
        }

        private void EditNew_tile_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.ListOfActiveControls.Add("SDRRLIST");
            Utils.SDRRListType = "newSDRRtransControl";
            Utils.isNewRecord = false;
        }

        private void EditDelStattile_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.ListOfActiveControls.Add("SDRRLIST");
            Utils.SDRRListType = "DeliveryStatusControl";
            Utils.isNewRecord = false;
        }
    }
}
