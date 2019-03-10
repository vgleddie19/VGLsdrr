using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility.ModifyRegistry;

namespace NewSDRR
{
    public static class Utils
    {
        /// <summary>
        /// List Of Pre-defined Menu
        /// </summary>
        public static Dictionary<String, Boolean> ListOfControls { get; set; }
        /// <summary>
        /// Store List of Controls being open by the user
        /// </summary>
        public static List<String> ListOfActiveControls { get; set; }
        /// <summary>
        /// Determined the type of paper being used by the user
        /// </summary>
        public static String SDRRprintoutType { get; set; }
        /// <summary>
        /// Determined what SDRR form being open
        /// </summary>
        /// <value>
        /// if value = "NewSDRRtransControl"; open the SDRR Transaction
        /// else value = "DeliveryStatusControl"; open the Delivery Status Transaction
        /// </value>
        public static String SDRRListType { get; set; }
        /// <summary>
        /// Determined whos use the print preview
        /// </summary>
        public static String printpreview_formuse { get; set; }
        /// <summary>
        /// Determined if the record is new
        /// </summary>
        public static bool isNewRecord { get; set; }

        public static string branchcode { get; set; }

        public static Dictionary<String, Object> ToDictionary(List<Object> data)
        {
            Dictionary<String, Object> result = new Dictionary<String, Object>();

            return result;
        }

        public static string AsWords(this double number)
        {
            String result = "";
            int whole_number = (int)number;
            int fractional_number = (int)((number - whole_number) * 100);
            result += NumberToWords(whole_number);
            if (fractional_number > 0)
                result += " point " + NumberToWords(fractional_number);
            result = result.ToUpper();
            return result;
        }
     
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static DataTable CloneLastRow(this DataTable dt, int count)
        {
            DataRow last_row = dt.Rows[dt.Rows.Count - 1];
            int start = int.Parse(last_row[0].ToString()) + 1;
            for (int i = start; i <= count; i++)
            {
                dt.Rows.Add(last_row.ItemArray);
                DataRow new_row = dt.Rows[dt.Rows.Count - 1];
                new_row[0] = i;
            }

            return dt;
        }

        public static string FormatMoney(this String str, int decimal_places)
        {
            double result;
            if (!double.TryParse(str, out result))
                result = 0;
            String format = "0,0.";
            for (int i = 0; i < decimal_places; i++)
                format += "0";
            return result.ToString(format);
        }

        public static double AsMoney(this Object obj)
        {
            double result = 0;
            if (obj == null)
                return result;
            try
            {
                result = double.Parse(obj.ToString().Replace(",", ""));
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public static System.Data.DataSet ToDataSet(this SqlDataReader reader)
        {
            System.Data.DataSet dataSet = new System.Data.DataSet();
            do
            {
                // Create new data table

                DataTable schemaTable = reader.GetSchemaTable();
                DataTable dataTable = new DataTable();

                if (schemaTable != null)
                {
                    // A query returning records was executed

                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        DataRow dataRow = schemaTable.Rows[i];
                        // Create a column name that is unique in the data table
                        string columnName = (string)dataRow["ColumnName"]; //+ "<C" + i + "/>";
                        // Add the column definition to the data table
                        DataColumn column = new DataColumn(columnName);
                        try
                        {
                            dataTable.Columns.Add(column);
                        }
                        catch (DuplicateNameException)
                        {
                            int count = 0;
                            while (dataTable.Columns[columnName] != null)
                            {
                                columnName += count;
                                count++;
                            }
                            column.ColumnName = columnName;
                            dataTable.Columns.Add(column);
                        }
                    }

                    dataSet.Tables.Add(dataTable);

                    // Fill the data table we just created

                    while (reader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                            dataRow[i] = reader.GetValue(i);

                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    // No records were returned

                    DataColumn column = new DataColumn("RowsAffected");
                    dataTable.Columns.Add(column);
                    dataSet.Tables.Add(dataTable);
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = reader.RecordsAffected;
                    dataTable.Rows.Add(dataRow);
                }
            }
            while (reader.NextResult());

            foreach (DataTable dt in dataSet.Tables)
            {
                dt.AcceptChanges();
            }
            reader.Close();
            return dataSet;
        }

        public static System.Data.DataSet GetDataset(String sql)
        {
            return DataSupport.RunDataSet(sql);
        }

        public static System.Data.DataSet GetDatasetFast(String sql, params Object[] parameters)
        {
            return DataSupport.RunDataSetFast(sql, Utils.ToDict(parameters));
        }
        public static DataTable GetDataTable(String sql, params Object[] parameters)
        {
            return DataSupport.RunDataSet(sql).Tables[0];
        }
        public static decimal GetDataDecimal(String sql, params Object[] parameters)
        {
            DataTable dt = DataSupport.RunDataSet(sql).Tables[0];
            if (dt.Rows.Count == 0)
                return Convert.ToDecimal("0.00");
            else
                return Convert.ToDecimal(dt.Rows[0][0]);            
        }
        public static int GetDataInt(String sql, params Object[] parameters)
        {
            DataTable dt = DataSupport.RunDataSet(sql).Tables[0];
            if (dt.Rows.Count == 0)
                return 0;
            else
                return Convert.ToInt32(dt.Rows[0][0]);
        }
        public static string GetDataString(String sql, params Object[] parameters)
        {
            DataTable dt = DataSupport.RunDataSet(sql).Tables[0];
            if (dt.Rows.Count == 0)
                return "";
            else
                return dt.Rows[0][0].ToString();
        }
        public static DataTable ExecuteStoredProcedure(String ProcedureName, Dictionary<String, Object> parameters)
        {
            return DataSupport.ExecuteStoredProcedure(ProcedureName, parameters);
        }

        public static int ExecuteStoredProcedureNonQuery(String ProcedureName, Dictionary<String, Object> parameters)
        {
            return DataSupport.ExecuteStoredProcedureNonQuery(ProcedureName, parameters);
        }
        public static int ExecuteNonQuery(String sql, Dictionary<String, Object> parameters)
        {
            return DataSupport.RunNonQuery(sql, parameters);
        }


        public static List<Object> getList(String ProcedureName, Dictionary<String, Object> parameters, String ColumnName)
        {
            List<Object> result = new List<object>();
            DataTable dt = ExecuteStoredProcedure(ProcedureName, parameters);
            foreach (DataRow row in dt.Rows)
            {
                result.Add(row[ColumnName].ToString().ToUpper());
            }

            return result;
        }
        public static double GetTotal(this DataTable dt, String col_name)
        {
            double result = 0;
            foreach (DataRow row in dt.Rows)
            {
                double amount;
                if (!double.TryParse(row[col_name].ToString().Replace(",", ""), out amount))
                    amount = 0;
                result += amount;
            }
            return result;
        }

        public static List<String> GetDescendants(String table_name, String parent_key, String primary_key, String value)
        {
            var result = GetChildren(table_name, parent_key, primary_key, value);
            result.Add(value);
            return result;
        }

        public static List<String> GetChildren(String table_name, String parent_key, String primary_key, String value)
        {
            List<String> result = new List<string>();
            GetChildren(table_name, parent_key, primary_key, value, ref result);
            return result;
        }

        public static void GetChildren(String table_name, String parent_key, String primary_key, String value, ref List<String> result)
        {
            String sql = "SELECT " + primary_key + " FROM " + table_name + " WHERE " + parent_key + " = @value";
            var dt = DataSupport.RunDataSet(sql, "value", value).Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                String child_value = row[primary_key].ToString();
                result.Add(child_value);
                GetChildren(table_name, parent_key, primary_key, child_value, ref result);
            }

        }

        public static Dictionary<String, Object> ToJSON(this DataRow row)
        {
            var result = new Dictionary<String, Object>();
            foreach (DataColumn col in row.Table.Columns)
                result.Add(col.ColumnName, row[col]);
            return result;
        }

        public static Dictionary<String, Object> BuildTree(DataTable obj, String group_key, String parent_key, String children_key)
        {
            obj.Columns.Add("~");
            Dictionary<String, Object> result = new Dictionary<string, object>() { { group_key, -1 } };
            var root_groups = new List<Dictionary<String, Object>>();
            foreach (DataRow row in obj.Rows)
                if (row[parent_key].ToString() == "0" && row["~"].ToString().Length == 0)
                {
                    row["~"] = "~";
                    root_groups.Add(row.ToJSON());
                }
            result.Add(children_key, root_groups);
            foreach (var root_group in root_groups)
                BuildTree(obj, group_key, parent_key, children_key, root_group[group_key].ToString(), root_group);
            return result;
        }

        public static void BuildTree(DataTable obj, String group_key, String parent_key, String children_key, String group, Dictionary<String, Object> result)
        {

            var children = new List<Dictionary<String, Object>>();
            foreach (DataRow row in obj.Rows)
                if (row[parent_key].ToString() == group && row["~"].ToString().Length == 0)
                {
                    row["~"] = "~";
                    children.Add(row.ToJSON());
                }
            result.Add(children_key, children);

            foreach (var child in children)
                if (child[group_key].ToString() != child[parent_key].ToString())
                    BuildTree(obj, group_key, parent_key, children_key, child[group_key].ToString(), child);
        }

        public static Dictionary<String, Object> BuildTree(List<Dictionary<String, Object>> obj, String group_key, String parent_key, String children_key)
        {
            Dictionary<String, Object> result = new Dictionary<string, object>() { { group_key, -1 } };
            var root_groups = new List<Dictionary<String, Object>>();
            foreach (var row in obj)
                if (row[parent_key].ToString() == "0")
                    root_groups.Add(row);
            result.Add(children_key, root_groups);
            foreach (var root_group in root_groups)
                BuildTree(obj, group_key, parent_key, children_key, root_group[group_key].ToString(), root_group);
            return result;
        }

        public static void BuildTree(List<Dictionary<String, Object>> obj, String group_key, String parent_key, String children_key, String group, Dictionary<String, Object> result)
        {

            var children = new List<Dictionary<String, Object>>();
            foreach (var row in obj)
                if (row[parent_key].ToString() == group)
                    children.Add(row);
            result.Add(children_key, children);

            foreach (var child in children)
                if (child[group_key].ToString() != child[parent_key].ToString())
                    BuildTree(obj, group_key, parent_key, children_key, child[group_key].ToString(), child);
        }

        public static Dictionary<String, Object> GetGroup(Dictionary<String, Object> tree, String group, String children_key, String group_key)
        {
            Dictionary<String, Object> result = null;
            GetGroup(tree, group, children_key, group_key, ref result);
            return result;
        }

        public static void GetGroup(Dictionary<String, Object> tree, String group, String children_key, String group_key, ref Dictionary<String, Object> result)
        {

            if (!tree.Keys.Contains(group_key)) // an empty node
                return;
            if (tree[group_key].ToString() == group) // the matching node
            {
                result = tree;
                return;
            }
            if (!tree.Keys.Contains(children_key)) // a leaf non-matching node
                return;
            var children = (List<Dictionary<String, Object>>)tree[children_key];
            foreach (var child in children)
                GetGroup(child, group, children_key, group_key, ref result); // Go to children
            return;
        }

        public static Dictionary<String, DataRow> BuildIndex(String ProcedureName, String ColumnName, Dictionary<String, Object> param)
        {
            DataTable table = DataSupport.ExecuteStoredProcedure(ProcedureName ,param);
            Dictionary <String, DataRow> index = new Dictionary<String, DataRow>(table.Rows.Count);
            foreach (DataRow Row in table.Rows)
            { index[Row[ColumnName].ToString()] = Row; }
            return index;
        }

        public static Dictionary<String, DataRow> BuildIndex_SQL(String SQLCommand, String ColumnName)
        {
            DataTable table = DataSupport.RunDataSet(SQLCommand).Tables[0];
            Dictionary<String, DataRow> index = new Dictionary<String, DataRow>(table.Rows.Count);
            foreach (DataRow Row in table.Rows)
            { index[Row[ColumnName].ToString()] = Row; }
            return index;
        }
        public static Dictionary<String, DataRow> BuildIndex_SQL(String SQLCommand, List<String> ColumnName, String seperator)
        {
            DataTable table = DataSupport.RunDataSet(SQLCommand).Tables[0];
            Dictionary<String, DataRow> index = new Dictionary<String, DataRow>(table.Rows.Count);
            foreach (DataRow Row in table.Rows)
            { 
                String key="";
                int cnt = 0;

                foreach (String col in ColumnName)
                {
                    if(cnt == ColumnName.Count-1)
                        key += Row[col].ToString().Trim();
                    else
                        key += Row[col].ToString().Trim() + seperator;
                    cnt++;
                }

                index[key] = Row;           
            }
            return index;
        }

        
        public static Int32 ToInteger(this String str)
        {
            return ToInteger(str, 0);
        }

        public static Int32 ToInteger(this String str, Int32 default_value)
        {
            Int32 result = default_value;
            if (!Int32.TryParse(str, out result))
                result = default_value;
            return result;
        }

        public static Int32 ParseInteger(this String str, Int32 default_value)
        {
            Int32 result;
            if (String.IsNullOrEmpty(str))
                return default_value; 
            if (!Int32.TryParse(str.Replace(",", ""), out result))
                result = default_value;
            return result;
        }

        public static double ToDouble(this String str)
        {
            return ToDouble(str, 0);
        }

        public static double ToDouble(this String str, double default_value)
        {
            double result = default_value;
            if (String.IsNullOrEmpty(str))
                return default_value; 
            if (!double.TryParse(str, out result))
                result = default_value;
            return result;
        }

        public static double ParseDouble(this String str, double default_value)
        {
            double result;
            if (String.IsNullOrEmpty(str))
                return default_value; 
            if (!double.TryParse(str.Replace(",", ""), out result))
                result = default_value;
            return result;
        }

        public static Decimal ParseDecimal(this String str, decimal default_value)
        {
            decimal  result;
            if (String.IsNullOrEmpty(str)) 
                return default_value; 
            if (!decimal.TryParse(str.Replace(",", ""), out result))
                result = default_value;
            return result;
        }

        public static double Sum(this DataTable dt, String column)
        {
            double result = 0;
            dt.ForEvery((row) =>
            {
                double x;
                if (double.TryParse(row[column].ToString().Replace(",", ""), out x))
                    result += x;
                return row;
            });
            return result;
        }

        public static DataTable CalculateSum(this DataTable dt, params String[] columns)
        {
            DataRow last_row = dt.Rows[dt.Rows.Count - 1];

            foreach (String column in columns)
            {
                double total = 0;
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    DataRow row = dt.Rows[i];
                    String amt = row[column].ToString();
                    if (amt.Length > 0)
                        amt = amt.Substring(1);
                    double amount = 0;
                    if (!double.TryParse(amt, out amount))
                        amount = 0;
                    total += amount;
                }
                last_row[column] = total.ToString();
            }

            return dt;
        }

        public static T ParseAsEnum<T>(this String str)
        {
            foreach (T t in (T[])Enum.GetValues(typeof(T)))
                if (t.ToString() == str.Replace(" ", "_"))
                    return t;
            throw new KeyNotFoundException();
        }

        public static DataTable ForEvery(this DataTable dt, Func<DataRow, DataRow> func)
        {
            foreach (DataRow row in dt.Rows)
                func(row);
            return dt;
        }

        public static DataRow ForEvery(this DataRow row, Func<Object, Object> func)
        {
            DataTable dt = row.Table;
            foreach (DataColumn col in dt.Columns)
                row[col] = func(row[col]);
            return row;
        }

        public static List<String> ToList(params String[] parameters)
        {
            return parameters.ToList();
        }

        private static string GenerateSelectOptions(Dictionary<String, Object> items)
        {

            StringBuilder sb = new StringBuilder();
            foreach (var entry in items)
                sb.Append("<option value='" + entry.Key + "'>" + entry.Value + "</option>");
            String options = sb.ToString();
            return options;
        }

        public static Dictionary<string, object> GetPercentageDict()
        {

            var dict = new Dictionary<String, Object>();
            for (int i = 0; i <= 100; i++)
                dict.Add(i.ToString(), i.ToString("00") + " %");
            return dict;
        }

        public static Dictionary<String, Object> GetCount(int start, int end)
        {
            Dictionary<String, Object> result = new Dictionary<string, object>();
            for (int i = start; i <= end; i++)
                result.Add(i.ToString("00"), i.ToString("00"));
            return result;
        }

        public static Dictionary<String, String> ToDictionary(params Object[] arr)
        {
            Dictionary<string, String> result = new Dictionary<string, String>();
            String key = null;
            for (int i = 0; i < arr.Length; i++)
            {
                var str = arr[i].ToString();
                var is_even = i % 2 == 0;
                if (is_even)
                {
                    result.Add(str, null);
                    key = str;
                }
                else
                {
                    result[key] = str;
                }
            }
            return result;
        }

        public static DataTable GenerateTotalsRows(this DataTable dt, String label_column, params String[] exception_columns)
        {
            DataRow new_row = dt.Rows.Add();
            var exceptions = exception_columns.ToList();
            foreach (DataColumn col in dt.Columns)
            {
                if (exceptions.Contains(col.ColumnName))
                    continue;
                decimal total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    decimal amount = 0;
                    if (!decimal.TryParse(row[col].ToString(), out amount))
                        amount = 0;
                    total += amount;
                }
                new_row[col] = total;
            }


            new_row[label_column] = "<strong>TOTAL</strong>";
            return dt;
        }

        public static String AsHTMLSelect(this Dictionary<String, Object> dict, String attribute)
        {
            StringBuilder result = new StringBuilder();
            result.Append("<select " + attribute + ">");
            foreach (String key in dict.Keys)
                result.Append("<option value='" + key + "'>" + dict[key] + "</option>");
            result.Append("</select>");
            return result.ToString();
        }

        public static DataTable RemoveRow(this DataTable dt, string column, string value)
        {
            foreach (DataRow row in dt.Rows)
                if (row[column].ToString() == value)
                {
                    dt.Rows.Remove(row);
                    break;
                }
            return dt;
        }

        public static Dictionary<String, Object> AsDict(params Object[] arr)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            for (int i = 0; i < arr.Length; i++)
                result.Add(arr[i].ToString(), arr[i]);
            return result;
        }

        public static Dictionary<String, Object> ToDict(params Object[] arr)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            String key = null;
            for (int i = 0; i < arr.Length; i++)
            {
                var str = arr[i].ToString();
                var is_even = i % 2 == 0;
                if (is_even)
                {
                    result.Add(str, null);
                    key = str;
                }
                else
                {
                    result[key] = str;
                }
            }
            return result;
        }

        public static Dictionary<String, Dictionary<String, String>> DBConnection
        { get; set; }
        public static Dictionary<String, Dictionary<String, String>> ClientConnection
        { get; set; }
        public static void SetConnectionDetails()
        {
            RegistrySupport registry = new RegistrySupport();
            String data = registry.Read(Settings.PROGRAM_GRID_KEY);

            if (data == null)
                return;

            String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<String, Dictionary<String, String>> conn = new Dictionary<String, Dictionary<String, String>>();
            foreach (String program in programs)
            {
                String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<String, String> details = new Dictionary<String, String>();
                details.Add("SoftwareName", records[0]);
                details.Add("Server", records[1]);
                details.Add("Directory", records[2]);
                details.Add("User", records[3]);
                details.Add("password", records[4]);
                details.Add("Local", records[5]);
                details.Add("isAbbot", records[6]);
                if (records.Count() == 8)
                    details.Add("DatabaseName", records[7]);

                switch (records[0].ToUpper())
                {
                    case "DISPATCH":
                        conn.Add("DISPATCH", details);
                        break;
                    case "WMS":
                        conn.Add("WMS", details);
                        break;
                    case "ABBOT":
                        conn.Add("ABBOT", details);
                        break;
                    case "DONGA":
                        conn.Add("DONGA", details);
                        break;
                    case "OMS":
                        conn.Add("OMS", details);
                        break;
                }
            }
            DBConnection = conn;

            registry = new RegistrySupport();
            data = registry.Read(Settings.CLIENT_GRID_KEY);

            if (data == null)
                return;

            programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
            conn = new Dictionary<String, Dictionary<String, String>>();
            foreach (String program in programs)
            {
                String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<String, String> details = new Dictionary<String, String>();
                details.Add("ClientName", records[0]);
                details.Add("Directory", records[1]);
                details.Add("DBTYPE", records[2]);
                conn.Add(records[0], details);
            }
            ClientConnection = conn;             
        }
    }
    public static class UnitTestDetector
    {
        static UnitTestDetector()
        {
            string testAssemblyName = "Microsoft.VisualStudio.QualityTools.UnitTestFramework";
            UnitTestDetector.IsInUnitTest = AppDomain.CurrentDomain.GetAssemblies()
                .Any(a => a.FullName.StartsWith(testAssemblyName));
        }

        public static bool IsInUnitTest { get; private set; }
    }    
}