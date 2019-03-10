using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading;
using System.Web;

namespace NewSDRR
{
    public class DataSupport 
    {

        private static SqlConnection TestSQLConnection { get; set; }
        private static SqlTransaction TestSQLTransaction { get; set; }

        /// <summary>
        /// Gets the a SQL Connection From the Configuration File
        /// </summary>
        private static String _connectString;
        public String DBConnectionString { get { return _connectString; } set { _connectString = value; } }
        public static SqlConnection Connection { get { return new SqlConnection(_connectString); } }


        /// <summary>
        /// Sets the Global Connection to the Database to Test Mode. Test Mode would not commit anything to the database and any query under this mode will be Rolled Back.
        /// </summary>
        /// <param name="IsTestMode">On / Off</param>
        public static void SetTestMode(Boolean IsTestMode)
        {
            if (IsTestMode)
            {
                TestSQLConnection = Connection;
                TestSQLConnection.Open();
                TestSQLTransaction = TestSQLConnection.BeginTransaction();
            }
            else
            {
                if (TestSQLTransaction != null)
                    TestSQLTransaction.Rollback();
                TestSQLTransaction = null;
                TestSQLConnection = null;
            }
        }

        public static Boolean IsTestMode()
        {
            if (TestSQLConnection == null)
                return false;
            else
                return true;
        }

        static DataSupport()
        {
            if (IsUnitTest())
                SetTestMode(true);
        }

        #region Database Connection and Query

        public static Object RunScalar(String sql, params Object[] parameters)
        {
            DataTable dt = RunDataSet(sql, parameters).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0];
            return "";
        }

        /// <summary>
        /// Reads from the Database
        /// </summary>
        /// <param name="sql">The Query</param>
        /// <param name="parameters">Parameters of the Query</param>
        /// <returns>The Result Set of the Query</returns>
        public static System.Data.DataSet RunDataSet(String sql, params Object[] parameters)
        {
            return RunDataSet(sql, Utils.ToDict(parameters));
        }

        /// <summary>
        /// Reads from the Database
        /// </summary>
        /// <param name="sql">The Query</param>
        /// <param name="parameters">Parameters of the Query</param>
        /// <returns>The Result Set of the Query</returns>
        public static System.Data.DataSet RunDataSet(String sql, Dictionary<String, Object> parameters)
        {
            if (IsUnitTest() && !IsTestMode())
                throw new AccessViolationException();
            System.Data.DataSet result = null;
            // In order to read, you need a connection and a transaction for rollback or commit purposes
            SqlConnection conn = null;
            SqlTransaction trans = null;

            // If it's test mode, use the test connection, otherwise, create a new connection
            if (TestSQLConnection != null)
                conn = TestSQLConnection;
            else
                conn = Connection;
            // If it's test mode, use the test transaction
            if (TestSQLTransaction != null)
                trans = TestSQLTransaction;
            try
            {
                // If it's not test mode, open the connection, test mode connection is already open
                if (TestSQLTransaction == null)
                    conn.Open();
               
                SqlCommand command = conn.CreateCommand();
                if (TestSQLTransaction != null)
                    command.Transaction = trans;
                command.CommandText = sql;
                command.CommandTimeout = 60000;
                if (parameters != null)
                {
                    foreach (KeyValuePair<String, Object> kvp in parameters)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                }
                result = command.ExecuteReader().ToDataSet();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                // If it's not test mode, close the connection, test mode connections will be closed automatically
                if (TestSQLTransaction == null)
                    SqlConnection.ClearAllPools(); conn.Close();
            }

            return result;
        }

        public static System.Data.DataSet RunDataSetFast(String sql, Dictionary<String, Object> parameters)
        {
            if (IsUnitTest() && !IsTestMode())
                throw new AccessViolationException();
            System.Data.DataSet result = null;
            // In order to read, you need a connection and a transaction for rollback or commit purposes
            SqlConnection conn = null;
            SqlTransaction trans = null;

            // If it's test mode, use the test connection, otherwise, create a new connection
            if (TestSQLConnection != null)
                conn = TestSQLConnection;
            else
                conn = Connection;
            // If it's test mode, use the test transaction
            if (TestSQLTransaction != null)
                trans = TestSQLTransaction;
            try
            {
                // If it's not test mode, open the connection, test mode connection is already open
                if (TestSQLTransaction == null)
                    conn.Open();

                SqlCommand command = conn.CreateCommand();
                if (TestSQLTransaction != null)
                    command.Transaction = trans;
                command.CommandText = sql;
                command.CommandTimeout = 60000;
                if (parameters != null)
                {
                    foreach (KeyValuePair<String, Object> kvp in parameters)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                }
                result = new System.Data.DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                // If it's not test mode, close the connection, test mode connections will be closed automatically
                if (TestSQLTransaction == null)
                    SqlConnection.ClearAllPools(); conn.Close();
            }

            return result;
        }


        /// <summary>
        /// Writes to the Database
        /// </summary>
        /// <param name="sql">The Query</param>
        /// <param name="parameters">Paramters of the Query</param>
        /// <returns># of rows affected</returns>
        public static int RunNonQuery(String sql, params Object[] parameters)
        {
            return RunNonQuery(sql, Utils.ToDict(parameters));
        }

        /// <summary>
        /// Writes to the Database
        /// </summary>
        /// <param name="sql">The Query</param>
        /// <param name="parameters">Paramters of the Query</param>
        /// <returns># of rows affected</returns>
        public static int RunNonQuery(String sql, Dictionary<String, Object> parameters)
        {
            if (IsUnitTest() && !IsTestMode())
                throw new AccessViolationException();
            int result = -1;
            // In order to write, you need a connection and a transaction for rollback or commit purposes
            SqlConnection conn = null;
            SqlTransaction trans = null;

            // If it's test mode, use the test connection, otherwise, create a new connection
            if (TestSQLConnection != null)
                conn = TestSQLConnection;
            else
                conn = Connection;
            // If it's test mode, use the test transaction
            if (TestSQLTransaction != null)
                trans = TestSQLTransaction;
            try
            {
                // If it's not test mode, open the connection, test mode connection is already open
                if (TestSQLTransaction == null)
                    conn.Open();
                // If it's not test mode, create a new transaction, test mode transaction is already created
                if (TestSQLTransaction == null)
                    trans = conn.BeginTransaction();
                
                SqlCommand command = new SqlCommand(sql, conn);
                //SqlCommand command = conn.CreateCommand();
                command.Transaction = trans;
                command.CommandText = sql;
                command.CommandTimeout = 60000;
                if (parameters != null)
                {
                    foreach (KeyValuePair<String, Object> kvp in parameters)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                }
                result = command.ExecuteNonQuery();
                // If it's not test mode, commit the transaction, test mode transactions are meant to be rollback
                if (TestSQLTransaction == null)
                    trans.Commit();
            }
            catch (SqlException ex)
            {
                result = 0;
                result = 0;
                if (ex.Number == 4060 || ex.Number == 53)
                { throw ex; }

                // If it's not test mode, rollback the transaction on error, test mode transactions will be rollbacked automatically
                if (TestSQLTransaction == null)
                    trans.Rollback();
                throw ex;
            }
            finally
            {
                // If it's not test mode, close the connection, test mode connections will be closed automatically
                if (TestSQLTransaction == null)
                    SqlConnection.ClearAllPools(); conn.Close();
            }

            return result;
        }
        
        public static DataTable ExecuteStoredProcedure(String ProcedureName, Dictionary<String, Object> parameters)
        {
            if (IsUnitTest() && !IsTestMode())
                throw new AccessViolationException();
            System.Data.DataSet result = new System.Data.DataSet();
            // In order to write, you need a connection and a transaction for rollback or commit purposes
            SqlConnection conn = null;
            SqlTransaction trans = null;

            // If it's test mode, use the test connection, otherwise, create a new connection
            if (TestSQLConnection != null)
                conn = TestSQLConnection;
            else
                conn = Connection;
            // If it's test mode, use the test transaction
            if (TestSQLTransaction != null)
                trans = TestSQLTransaction;
            try
            {
                // If it's not test mode, open the connection, test mode connection is already open
                if (TestSQLTransaction == null)
                    conn.Open();
                // If it's not test mode, create a new transaction, test mode transaction is already created
                if (TestSQLTransaction == null)
                    trans = conn.BeginTransaction();

                SqlCommand command = new SqlCommand(ProcedureName, conn);
                //SqlCommand command = conn.CreateCommand();
                command.Transaction = trans;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 60000;
                if (parameters != null)
                {
                    foreach (KeyValuePair<String, Object> kvp in parameters)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(result);
                // If it's not test mode, commit the transaction, test mode transactions are meant to be rollback
                //if (TestSQLTransaction == null)
                //    trans.Commit();
            }
            catch (SqlException ex)
            {
                result = null;
                if (ex.Number == 4060 || ex.Number == 53)
                { throw ex; }

                // If it's not test mode, rollback the transaction on error, test mode transactions will be rollbacked automatically
                if (TestSQLTransaction == null)
                    trans.Rollback();
                 throw ex;
            }
            finally
            {
                // If it's not test mode, close the connection, test mode connections will be closed automatically
                if (TestSQLTransaction == null)
                    SqlConnection.ClearAllPools(); conn.Close();
            }
            return result.Tables[0];
        }
        public static int ExecuteStoredProcedureNonQuery(String ProcedureName, Dictionary<String, Object> parameters)
        {
            if (IsUnitTest() && !IsTestMode())
                throw new AccessViolationException();
            int result = -1;
            // In order to write, you need a connection and a transaction for rollback or commit purposes
            SqlConnection conn = null;
            SqlTransaction trans = null;

            // If it's test mode, use the test connection, otherwise, create a new connection
            if (TestSQLConnection != null)
                conn = TestSQLConnection;
            else
                conn = Connection;
            // If it's test mode, use the test transaction
            if (TestSQLTransaction != null)
                trans = TestSQLTransaction;
            try
            {
                // If it's not test mode, open the connection, test mode connection is already open
                if (TestSQLTransaction == null)
                    conn.Open();
                // If it's not test mode, create a new transaction, test mode transaction is already created
                if (TestSQLTransaction == null)
                    trans = conn.BeginTransaction();

                SqlCommand command = new SqlCommand(ProcedureName, conn);
                //SqlCommand command = conn.CreateCommand();
                command.Transaction = trans;
                command.CommandText = ProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 60000;
                if (parameters != null)
                {
                    foreach (KeyValuePair<String, Object> kvp in parameters)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                }
                result = command.ExecuteNonQuery();
                // If it's not test mode, commit the transaction, test mode transactions are meant to be rollback
                if (TestSQLTransaction == null)
                    trans.Commit();
            }
            catch (SqlException ex)
            {
                result = 0;
                if (ex.Number == 4060 || ex.Number == 53)
                { throw ex; }

                // If it's not test mode, rollback the transaction on error, test mode transactions will be rollbacked automatically
                if (TestSQLTransaction == null)
                    trans.Rollback();
                throw ex;
            }
            finally
            {
                // If it's not test mode, close the connection, test mode connections will be closed automatically
                if (TestSQLTransaction == null)
                    SqlConnection.ClearAllPools(); conn.Close();
            }

            return result;
        }
        /// <summary>
        /// Determines if it's a unit test. The primary purpose is to make sure that Unit Test can't run non-test mode datasupport
        /// </summary>
        /// <returns></returns>
        private static Boolean IsUnitTest()
        {
            string testAssemblyName = "Microsoft.VisualStudio.QualityTools.UnitTestFramework";
            return AppDomain.CurrentDomain.GetAssemblies()
                .Any(a => a.FullName.StartsWith(testAssemblyName));
        }
        #endregion

        #region SQL SCRIPT GENERATORS
        public static String GetInsert(String table, Dictionary<String, Object> insert_list)
        {
            String result = "";
            var converted_list = ConvertToStringValues(insert_list);
            DBTable dbtable = new DBTable(table, converted_list, new List<String>());
            result = dbtable.GenerateInsert(converted_list);
            return result;
        }
        public static String GetInsertUsingSelect(String table, Dictionary<String, Object> insert_list, String SelectTable)
        {
            String result = "";
            var converted_list = ConvertToStringValues(insert_list);
            DBTable dbtable = new DBTable(table, converted_list, new List<String>());
            result = dbtable.GenerateInsertUsingSelect(converted_list, SelectTable);
            return result;
        }
        public static String GetDelete(String table, params Object[] filters)
        {
            return GetDelete(table, Utils.ToDictionary(filters));
        }

        public static String GetDelete(String table, Dictionary<String, String> filters)
        {
            String result = String.Format("DELETE FROM " + table + " WHERE ");
            List<String> keys = filters.Keys.ToList();
            foreach (String key in keys)
            {
                if (keys.IndexOf(key) > 0)
                    result += " AND ";
                result += String.Format(" {0} = '{1}' ", key, filters[key]);
            }
            result += "\r\n";
            return result;
        }
        public static String GetUpsert(String table, Dictionary<String, Object> insert_list, params String[] parameters)
        {
            return GetUpsert(table, insert_list, parameters.ToList());
        }
        public static String GetUpsert(String table, Dictionary<String, Object> insert_list,  List<String> primary_keys)
        {
            return GetUpsert(table, insert_list, primary_keys, null, null);
        }

        public static String GetUpsert(String table, Dictionary<String, Object> insert_list, List<String> primary_keys, String compare_field, String compare_value)
        {
            String result = "";
            var converted_list = ConvertToStringValues(insert_list);
            DBTable dbtable = new DBTable(table, converted_list, primary_keys);
            Dictionary<String, String> primary_values = new Dictionary<String, String>();
            foreach (String key in primary_keys)
            {
                primary_values.Add(key, insert_list[key].ToString());
            }
            result += dbtable.GenerateCreateUpdate(converted_list, primary_values, compare_field, compare_value);
            return result;

        }

        public static String GetUpdate(String table, Dictionary<String, Object> insert_list, List<String> primary_keys)
        {
            return GetUpdate(table, insert_list, primary_keys, null, null);
        }

        public static String GetUpdate(String table, Dictionary<String, Object> insert_list, List<String> primary_keys, String compare_field, String compare_value)
        {
            String result = "";
            var converted_list = ConvertToStringValues(insert_list);
            DBTable dbtable = new DBTable(table, converted_list, primary_keys);
            Dictionary<String, String> primary_values = new Dictionary<String, String>();
            foreach (String key in primary_keys)
            {
                primary_values.Add(key, insert_list[key].ToString());
            }
            result = dbtable.GenerateUpdate(converted_list, primary_values, compare_field, compare_field);            
            return result;
        }

        public static String GetWhereClause(Dictionary<String, String> filters)
        {
            String result = "";
            DBTable dbtable = new DBTable("", new Dictionary<String, String>(), filters.Keys.ToList());
            result = dbtable.GenerateFilter(filters);
            return result;
        }
        #endregion

        #region TRANSACTION CODE MANAGEMENT
        public static String GetDaybookUpdateSQL(String table,String id_col,String id_val, String daybook)
        {
            return @"UPDATE "+table+@" SET document = (SELECT current_sequence FROM daybook_mast WHERE daybook_id = '"+daybook+@"') WHERE "+id_col+@" ='"+id_val+@"'
                     UPDATE daybook_mast SET current_sequence = current_sequence +1 WHERE daybook_id ='" + daybook + @"'";
        }

        public static String GetNextMenuCode(String menu, String menu_prefix)
        {
            String result = "";
            String building_id = "WEB";

            System.Data.DataSet ds = DataSupport.RunDataSet(String.Format("SELECT menu_current FROM MENU WHERE menu_id = '{0}' ", menu));
            String next_value = ds.Tables[0].Rows[0][0].ToString();
            result = String.Format("{0}-{1}-{2}", building_id, menu_prefix, next_value);
            return result;
        }

        private static Boolean IsInConflict(String value, String table, String id)
        {
            String sql = "SELECT " + id + " FROM " + table + " WHERE " + id + " = @id ";
            DataTable dt = DataSupport.RunDataSet(sql, "id", value).Tables[0];
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        public static String GetNextMenuCodeInt(String menu, String table, String id)
        {
            String result = null;
            do
            {
                result = GetNextMenuCodeInt(menu);
            } while (IsInConflict(result,table, id));
            return result;
        }
        public static String GetNextMenuCodeInt(String menu)
        {
            String result = "";

            System.Data.DataSet ds = DataSupport.RunDataSet(String.Format("SELECT menu_current FROM MENU WHERE menu_id = '{0}' ", menu) + UpdateMenuCode(menu));
            String next_value = ds.Tables[0].Rows[0][0].ToString();
            result = next_value;
            return result;
        }

        public static String UpdateMenuCode(String menu)
        {
            String result = "";
            result = String.Format(" UPDATE MENU SET menu_current = menu_current + 1 WHERE menu_id = '{0}';", menu);
            return result;
        }
        #endregion

        #region LOG MANAGEMENT
        public static String GetLog(String activity, String desc)
        {
            return "";
            //return GetLog(activity, RegistrationSupport.GetUsername(), DateTime.Now.AsPhilippineTimeZone(), desc);
        }

        public static String GetLog(String activity, String employee, DateTime datetime, String desc)
        {
            String result = "";
            result = DataSupport.GetInsert("Logs", new Dictionary<String, Object>() { { "activity", activity }, { "employee", employee }, { "datetime", datetime }, { "remarks", desc } });
            return result;
        }
        #endregion

        private static void WrapExceptionInFriendlyMessage(SqlException ex)
        {
            if (ex.Number == 2627) // Primary Key
                throw new Exception("Save Failed. The CODE / ID you inputted is a duplicate. ", ex);
            if (ex.Number == 8114) // Parse Error Into Numeric
                throw new Exception("Save Failed. Typed LETTERS or SYMBOLS into textboxes that require only NUMBERS", ex);
        }

        private static System.Data.DataSet ConvertDataReaderToDataSet(SqlDataReader reader)
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
                //dt.FormatEncodeHTML();
            }

            return dataSet;
        }
        
        private static Dictionary<String, String> ConvertToStringValues(Dictionary<String, Object> list)
        {
            Dictionary<String, String> result = new Dictionary<String, String>();
            foreach (String key in list.Keys)
            {
                if (list[key] != null)
                    if (list[key].ToString() != "")
                        result.Add(key, list[key].ToString());
            }
            return result;
        }

        public static void setDBConnection(String connectionString)
        {
            _connectString = connectionString;
        }

        public  static int CheckDBConnectivity()
        {
            try
            {
                SqlConnection SQLConnection = new SqlConnection();
                SQLConnection = Connection;
                SQLConnection.Open();
                if (SQLConnection.State == ConnectionState.Open)
                    return 1;
                else
                    return 0;
            }
            catch (Exception)
            { return 0; }
        }

        #region TestSupport

        public static System.Data.DataSet ExecuteDataSet(SqlCommand cmd)
        {
            return ExecuteDataSet(cmd, new Dictionary<string, object>());
        }
        public static System.Data.DataSet ExecuteDataSet(SqlCommand cmd, params Object[] list)
        {
            return ExecuteDataSet(cmd, ConvertToDict(list));
        }

        private static Dictionary<string, object> ConvertToDict(Object[] list)
        {
            Dictionary<String, Object> dict = new Dictionary<string, object>();
            if (list.Length % 2 != 0)
                throw new ArgumentException("Must be odd number in the list");
            for (int i = 0; i < list.Length; i += 2)
                dict.Add(list[i].ToString(), list[i + 1]);
            return dict;
        }

        public static System.Data.DataSet ExecuteDataSet(SqlCommand cmd, Dictionary<String, Object> parameters)
        {
            System.Data.DataSet result = null;
            if (parameters != null)
                foreach (KeyValuePair<String, Object> kvp in parameters)
                    cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
            result = ConvertDataReaderToDataSet(cmd.ExecuteReader());
            return result;
        }
        #endregion
    }

   
}
