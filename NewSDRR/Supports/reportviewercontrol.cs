using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewSDRR
{
    public partial class reportviewercontrol : UserControl
    {
        public reportviewercontrol()
        {
            InitializeComponent();
        }

        #region Commands
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
                if (Utils.printpreview_formuse == "newSDRRtransControl")
                {
                    btnSave.Command = newValue.SDRRCommands.Save;
                    btncancel.Command = newValue.SDRRCommands.Cancel;
                }
                else if (Utils.printpreview_formuse == "NewNUDtransControl")
                {
                    btnSave.Command = newValue.NUDCommands.Save;
                    btncancel.Command = newValue.NUDCommands.Cancel;                
                }
            }
            else
            {
                btnSave.Command = null;
                btncancel.Command = null;
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Utils.printpreview_formuse == "newSDRRtransControl")            
                Utils.ListOfActiveControls.Add("SDRRSAVEEXECUTE");            
            else if (Utils.printpreview_formuse == "NewNUDtransControl")
                Utils.ListOfActiveControls.Add("NUDSAVEEXECUTE");
            
            crtviewer.PrintReport();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (Utils.printpreview_formuse == "newSDRRtransControl")
                Utils.ListOfActiveControls.Add("SDRRSAVEEXECUTE");
            else if (Utils.printpreview_formuse == "NewNUDtransControl")
                Utils.ListOfActiveControls.Add("NUDSAVEEXECUTE");
        }
    }
}
