using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Microsoft.VisualBasic;
using System.Drawing;

namespace NewSDRR
{
    public static class UIControlSupport
    {
        public static ComboBoxEx SetComboBoxEx(ComboBoxEx cbo, DataTable  dt, String DropDownColumns, String DisplayMember,
                                               String ValueMember, AutoCompleteSource AutoSource, AutoCompleteMode  AutoMode, ComboBoxStyle DropStyle)
        {
            cbo.DataSource = dt;
            cbo.DisplayMember = DisplayMember;
            cbo.DropDownColumns = DropDownColumns;
            cbo.ValueMember = ValueMember;
            cbo.AutoCompleteSource = AutoSource;
            cbo.AutoCompleteMode = AutoMode;
            cbo.DropDownStyle = DropStyle;
            return cbo;
        }
        public static ComboBox SetComboBox(ComboBox cbo, String DisplayMember, String ValueMember,
                                           AutoCompleteSource  AutoSource, AutoCompleteMode AutoMode, ComboBoxStyle DropStyle)
        {
            cbo.ValueMember = ValueMember;
            cbo.DisplayMember = DisplayMember;
            cbo.AutoCompleteSource = AutoSource;
            cbo.AutoCompleteMode = AutoMode;
            cbo.DropDownStyle = DropStyle;            
            return cbo;
        }
        public static DataGridViewComboBoxExColumn setGridComboBox(DataTable dt, String DisplayMember,
                                               String ValueMember, AutoCompleteSource AutoSource, AutoCompleteMode AutoMode, ComboBoxStyle DropStyle)
        {   DataGridViewComboBoxExColumn cboCol = new DataGridViewComboBoxExColumn();
            cboCol.DataSource = dt;
            cboCol.DisplayMember = DisplayMember;
            cboCol.ValueMember = ValueMember;
            cboCol.AutoCompleteSource = AutoSource;
            cboCol.AutoCompleteMode = AutoMode;
            cboCol.DropDownStyle = DropStyle;
            return cboCol;        
        }
        public static DataGridViewComboBoxColumn setGridComboBox(DataTable dt, String DisplayMember, String ValueMember)
        {
            DataGridViewComboBoxColumn cboCol = new DataGridViewComboBoxColumn();
            cboCol.DataSource = dt;
            cboCol.DisplayMember = DisplayMember;
            cboCol.ValueMember = ValueMember;
            cboCol.AutoComplete = true;
            return cboCol;
        }       
        public static DataGridViewComboBoxExColumn AddGridColumnComboEditable(String HeaderText,DataTable DataSource,
                            String Displaymember,String ValueMember, Int32 DisplayIndex, ComboBoxStyle DropDownStyle,Int32 MaxInput, Int32 DropWidth) 
        {
            DataGridViewComboBoxExColumn cbCol = new DataGridViewComboBoxExColumn();
            cbCol.HeaderText = HeaderText;
            cbCol.Name = HeaderText;
            cbCol.DataSource = DataSource;
            cbCol.DisplayMember = Displaymember;
            cbCol.DisplayIndex = DisplayIndex;
            cbCol.ValueMember = ValueMember;
            cbCol.AutoCompleteSource = AutoCompleteSource.ListItems ;
            cbCol.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCol.DropDownStyle = DropDownStyle;
            cbCol.MaxLength  = MaxInput;
            cbCol.ReadOnly = false;
            cbCol.DropDownWidth = DropWidth;         
            

            return cbCol;
        }

        private static void AdjustWidthComboBox_DropDown(object sender, System.EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }

    }
}
