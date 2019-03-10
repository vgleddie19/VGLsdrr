using System;
using System.Collections.Generic;
using System.Text;
using DevComponents.DotNetBar;

namespace NewSDRR
{
    /// <summary>
    /// Represents all application commands.
    /// </summary>
    public class MetroBillCommands
    {
        private DocumentCommands _SDRRCommands = new DocumentCommands();
        /// <summary>
        /// Gets the SDRR related commands.
        /// </summary>
        public DocumentCommands SDRRCommands
        {
            get { return _SDRRCommands; }
            set { _SDRRCommands = value; }
        }

        private DocumentCommands _DelStatCommands = new DocumentCommands();
        /// <summary>
        /// Gets the client related commands.
        /// </summary>
        public DocumentCommands DelStatCommands
        {
            get { return _DelStatCommands; }
            set { _DelStatCommands = value; }
        }

        private DocumentCommands _NUDCommands = new DocumentCommands();
        /// <summary>
        /// Gets document related commands.
        /// </summary>
        public DocumentCommands NUDCommands
        {
            get { return _NUDCommands; }
            set { _NUDCommands = value; }
        }

        private DocumentCommands _ReportCommands = new DocumentCommands();
        /// <summary>
        /// Gets document related commands.
        /// </summary>
        public DocumentCommands ReportCommands
        {
            get { return _ReportCommands; }
            set { _ReportCommands = value; }
        }

        private Command _SlideStartControl;
        /// <summary>
        /// Toggles start control visibility.
        /// </summary>
        public Command ToggleStartControl
        {
            get { return _SlideStartControl; }
            set { _SlideStartControl = value; }
        }

        private Command _ChangeMetroTheme;
        /// <summary>
        /// Changes the Metro theme.
        /// </summary>
        public Command ChangeMetroTheme
        {
            get { return _ChangeMetroTheme; }
            set { _ChangeMetroTheme = value; }
        }

        private Command _GettingStartedCommand;
        public Command GettingStartedCommand
        {
            get { return _GettingStartedCommand; }
            set { _GettingStartedCommand = value; }
        }

        private Command _NotImplemented;
        /// <summary>
        /// Not implemented command.
        /// </summary>
        public Command NotImplemented
        {
            get { return _NotImplemented; }
            set { _NotImplemented = value; }
        }

        private Command _DevComponents;
        /// <summary>
        /// Open DotNetBar web-site.
        /// </summary>
        public Command DevComponents
        {
            get { return _DevComponents; }
            set { _DevComponents = value; }
        }
    }

    public class DocumentCommands
    {
        private Command _New;
        public Command New
        {
            get { return _New; }
            set { _New = value; }
        }

        private Command _Save;
        public Command Save
        {
            get { return _Save; }
            set { _Save = value; }
        }

        private Command _Cancel;
        public Command Cancel
        {
            get { return _Cancel; }
            set { _Cancel = value; }
        }

        private Command _menucontrol;
        public Command MenuCotrol
        {
            get { return _menucontrol; }
            set { _menucontrol = value; }
        }

        private Command _showtransactionform;
        public Command ShowTransactionForm
        {
            get { return _showtransactionform; }
            set { _showtransactionform = value; }
        }
    }
}
