using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utility.ModifyRegistry;

namespace NewSDRR
{
    public partial class ChangeConnection : Form
    {
        Boolean _isAdminconnection;
        public ChangeConnection(Boolean isAdminconnection)
        {
            InitializeComponent();
            _isAdminconnection = isAdminconnection;
            if (!_isAdminconnection)
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
            this.Icon = Properties.Resources.Settings;
        }

        private void ChangeConnection_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (_isAdminconnection)
                {
                    RegistrySupport registry = new RegistrySupport();
                    String data = registry.Read(Settings.PROGRAM_GRID_KEY);
                    String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (String program in programs)
                    {
                        String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                        programsGrid.Rows.Add(records);
                    }
                }
                else
                {
                    RegistrySupport registry = new RegistrySupport();
                    String data = registry.Read(Settings.CLIENT_GRID_KEY);
                    String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (String program in programs)
                    {
                        String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                        clientgrid.Rows.Add(records);
                    }                
                }
            }
            catch (Exception)
            {

            }
        }

        private void SaveData()
        {
            String data = "";
            if (_isAdminconnection)
            {
                foreach (DataGridViewRow row in programsGrid.Rows)
                {
                    // Ignore last row
                    if (row.Index == programsGrid.Rows.Count - 1)
                        break;
                    String name = row.Cells["names"].Value.ToString();
                    String server = row.Cells["server"].Value.ToString();
                    String directory = row.Cells["directory"].Value.ToString();
                    String user = row.Cells["user"].Value.ToString();
                    String password = row.Cells["password"].Value.ToString();
                    String local = row.Cells["local"].Value.ToString();
                    String isAbbot = "false";
                    if (row.Cells["isAbbot"].Value != null)
                        isAbbot = row.Cells["isAbbot"].Value.ToString();
                    String dbname = row.Cells["dbname"].Value.ToString();
                    data += String.Format("{0}<limiter>{1}<limiter>{2}<limiter>{3}<limiter>{4}<limiter>{5}<limiter>{6}<limiter>{7}<limiter1>", name, server, directory, user, password, local, isAbbot, dbname);//, exe, dbname);
                }
                RegistrySupport registry = new RegistrySupport();
                if (registry.Write(Settings.PROGRAM_GRID_KEY, data))
                    DevComponents.DotNetBar.MessageBoxEx.Show("Settings Saved");
            }
            else
            {
                foreach (DataGridViewRow row in clientgrid.Rows)
                {
                    // Ignore last row
                    if (row.Index == clientgrid.Rows.Count - 1)
                        break;
                    String name = row.Cells[clientname.Name.ToString()].Value.ToString();
                    String directory = row.Cells[clientdir.Name.ToString()].Value.ToString();
                    String dbtype = row.Cells[clientdbtype.Name.ToString()].Value.ToString();
                    data += String.Format("{0}<limiter>{1}<limiter>{2}<limiter1>", name, directory,dbtype);
                }
                RegistrySupport registry = new RegistrySupport();
                if (registry.Write(Settings.CLIENT_GRID_KEY, data))
                    DevComponents.DotNetBar.MessageBoxEx.Show("Settings Saved");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            Utils.SetConnectionDetails();
            this.Close();
        }

        private void programsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_isAdminconnection)
            {
                programsGrid.Rows[e.RowIndex].Tag = e.Value;
                if (programsGrid.Columns[e.ColumnIndex].Name == "password" && e.Value != null)
                {
                    e.Value = new String('*', e.Value.ToString().Length);
                }
            }
        }

        private void programsGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (programsGrid.CurrentRow.Tag != null)
                e.Control.Text = programsGrid.CurrentRow.Tag.ToString();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isAdminconnection)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Program Launcher Settings|*.prs";
                openFileDialog1.Title = "Open an Program Launcher Settings";
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != "")
                {
                    programsGrid.Rows.Clear();
                    System.IO.FileStream fs2 = new System.IO.FileStream(openFileDialog1.FileName.ToString(), FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(fs2);
                    String data = reader.ReadToEnd();
                    String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
                    reader.Close();
                    foreach (String program in programs)
                    {
                        String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                        programsGrid.Rows.Add(records);
                    }
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isAdminconnection)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Program Launcher Settings|*.prs";
                saveFileDialog1.Title = "Save an settings";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs1 = new System.IO.FileStream(saveFileDialog1.FileName.ToString(), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    String program = "";
                    foreach (DataGridViewRow dRow in programsGrid.Rows)
                    {
                        if (dRow.Index == programsGrid.Rows.Count - 1)
                            break;
                        String name = dRow.Cells["names"].Value.ToString();
                        String server = dRow.Cells["server"].Value.ToString();
                        String directory = dRow.Cells["directory"].Value.ToString();
                        String user = dRow.Cells["user"].Value.ToString();
                        String password = dRow.Cells["password"].Value.ToString();
                        String local = dRow.Cells["local"].Value.ToString();
                        String isabbot = dRow.Cells["isabbot"].Value.ToString();
                        String dbname = dRow.Cells["dbname"].Value.ToString();
                        program += String.Format("{0}<limiter>{1}<limiter>{2}<limiter>{3}<limiter>{4}<limiter>{5}<limiter>{6}<limiter1>{7}<limiter>", name, server, directory, user, password, local, isabbot, dbname);//, exe, dbname);
                    }

                    StreamWriter writer = new StreamWriter(fs1);
                    writer.Write(program);
                    writer.Close();
                    fs1.Dispose();
                }
            }
        }
    }
}

