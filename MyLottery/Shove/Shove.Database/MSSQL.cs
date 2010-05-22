namespace Shove.Database
{
    using Shove;
    using Shove._IO;
    using Shove._Security;
    using Shove._Web;
    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public class MSSQL
    {
        private const string key = "Q56GtyNkop97Ht334Ttyurfg";

        public static int BackupDatabase(string BackupFileName, bool BreakLog, bool Shrink)
        {
            return BackupDatabase(ConfigurationSettings.AppSettings["ConnectionString"], BackupFileName, BreakLog, Shrink);
        }

        public static int BackupDatabase(SqlConnection conn, string BackupFileName, bool BreakLog, bool Shrink)
        {
            if (conn == null)
            {
                return -1001;
            }
            bool flag = true;
            if (conn.State != ConnectionState.Open)
            {
                flag = false;
                try
                {
                    conn.Open();
                }
                catch
                {
                    return -1001;
                }
            }
            string database = conn.Database;
            if (!database.StartsWith("["))
            {
                database = "[" + database + "]";
            }
            if (ExecuteNonQueryNoTranscation(conn, "use master", new Parameter[0]) < 0)
            {
                if (!flag)
                {
                    conn.Close();
                }
                return -1002;
            }
            if (BreakLog && (ExecuteNonQueryNoTranscation(conn, "backup log " + database + " with no_log", new Parameter[0]) < 0))
            {
                if (!flag)
                {
                    conn.Close();
                }
                return -1003;
            }
            if (Shrink && (ExecuteNonQueryNoTranscation(conn, "DBCC SHRINKDATABASE (" + database + ", 0)", new Parameter[0]) < 0))
            {
                if (!flag)
                {
                    conn.Close();
                }
                return -1004;
            }
            if (ExecuteNonQueryNoTranscation(conn, "Backup database " + database + " to disk='" + BackupFileName + "' with INIT", new Parameter[0]) < 0)
            {
                if (!flag)
                {
                    conn.Close();
                }
                return -1005;
            }
            if (ExecuteNonQueryNoTranscation(conn, "use " + database, new Parameter[0]) < 0)
            {
                if (!flag)
                {
                    conn.Close();
                }
                return -1006;
            }
            if (File.Compress(BackupFileName))
            {
                return 0;
            }
            if (!flag)
            {
                conn.Close();
            }
            return -1007;
        }

        public static int BackupDatabase(string ConnectionString, string BackupFileName, bool BreakLog, bool Shrink)
        {
            SqlConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return -1001;
            }
            int num = BackupDatabase(conn, BackupFileName, BreakLog, Shrink);
            conn.Close();
            return num;
        }

        public static byte[] BackupDataToZipStream()
        {
            return BackupDataToZipStream(ConfigurationSettings.AppSettings["ConnectionString"]);
        }

        public static byte[] BackupDataToZipStream(SqlConnection conn)
        {
            if (conn == null)
            {
                return null;
            }
            bool flag = true;
            if (conn.State != ConnectionState.Open)
            {
                flag = false;
                try
                {
                    conn.Open();
                }
                catch
                {
                    return null;
                }
            }
            DataTable table = Select(conn, "Select * from sysobjects where OBJECTPROPERTY(id, N'IsUserTable') = 1 and OBJECTPROPERTY(id,N'IsMSShipped')=0 and [name] <> 'sysdiagrams'", new Parameter[0]);
            if (table == null)
            {
                if (!flag)
                {
                    conn.Close();
                }
                return null;
            }
            DataSet set = new DataSet();
            foreach (DataRow row in table.Rows)
            {
                string str = row["name"].ToString();
                DataTable table2 = Select(conn, "select * from [" + str + "]", new Parameter[0]);
                if (table2 == null)
                {
                    if (!flag)
                    {
                        conn.Close();
                    }
                    return null;
                }
                table2.TableName = str;
                set.Tables.Add(table2);
            }
            if (!flag)
            {
                conn.Close();
            }
            return _String.Compress(set.GetXml());
        }

        public static byte[] BackupDataToZipStream(string ConnectionString)
        {
            SqlConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return null;
            }
            byte[] buffer = BackupDataToZipStream(conn);
            conn.Close();
            return buffer;
        }

        public static SqlConnection CreateDataConnection()
        {
            return CreateDataConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        }

        public static SqlConnection CreateDataConnection(string ConnectionString)
        {
            if (ConnectionString.StartsWith("0x78AD"))
            {
                ConnectionString = Encrypt.Decrypt3DES("ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安", ConnectionString.Substring(6), "Q56GtyNkop97Ht334Ttyurfg");
            }
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
            }
            catch
            {
                return null;
            }
            return connection;
        }

        public static object ExecuteFunction(string FunctionName, params Parameter[] Params)
        {
            return ExecuteFunction(ConfigurationSettings.AppSettings["ConnectionString"], FunctionName, Params);
        }

        public static object ExecuteFunction(SqlConnection conn, string FunctionName, params Parameter[] Params)
        {
            if (conn == null)
            {
                return null;
            }
            bool flag = true;
            if (conn.State != ConnectionState.Open)
            {
                flag = false;
                try
                {
                    conn.Open();
                }
                catch
                {
                    return null;
                }
            }
            if (FunctionName.ToLower().IndexOf(".") < 0)
            {
                string str = "";
                if (str.Trim() == "")
                {
                    str = "dbo";
                }
                FunctionName = "[" + str + "]." + FunctionName;
            }
            string commandText = "select " + FunctionName + "(";
            if (Params != null)
            {
                for (int i = 0; i < Params.Length; i++)
                {
                    if (Params[i] != null)
                    {
                        bool flag2 = false;
                        bool flag3 = false;
                        if ((((Params[i].Type == SqlDbType.Char) || (Params[i].Type == SqlDbType.DateTime)) || ((Params[i].Type == SqlDbType.SmallDateTime) || (Params[i].Type == SqlDbType.Text))) || ((Params[i].Type == SqlDbType.UniqueIdentifier) || (Params[i].Type == SqlDbType.VarChar)))
                        {
                            flag2 = true;
                        }
                        if (((Params[i].Type == SqlDbType.NChar) || (Params[i].Type == SqlDbType.NText)) || (Params[i].Type == SqlDbType.NVarChar))
                        {
                            flag3 = true;
                        }
                        if (!commandText.EndsWith("("))
                        {
                            commandText = commandText + ", ";
                        }
                        if (flag2)
                        {
                            commandText = commandText + "'";
                        }
                        if (flag3)
                        {
                            commandText = commandText + "N'";
                        }
                        commandText = commandText + Params[i].Value.ToString();
                        if (flag2 || flag3)
                        {
                            commandText = commandText + "'";
                        }
                    }
                }
                commandText = commandText + ")";
            }
            object obj2 = ExecuteScalar(conn, commandText, new Parameter[0]);
            if (!flag)
            {
                conn.Close();
            }
            return obj2;
        }

        public static object ExecuteFunction(string ConnectionString, string FunctionName, params Parameter[] Params)
        {
            SqlConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return null;
            }
            object obj2 = ExecuteFunction(conn, FunctionName, Params);
            conn.Close();
            return obj2;
        }

        public static int ExecuteNonQuery(string CommandText, params Parameter[] Params)
        {
            return ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandText, Params);
        }

        public static int ExecuteNonQuery(SqlConnection conn, string CommandText, params Parameter[] Params)
        {
            if (conn == null)
            {
                return -1001;
            }
            bool flag = true;
            if (conn.State != ConnectionState.Open)
            {
                flag = false;
                try
                {
                    conn.Open();
                }
                catch
                {
                    return -1001;
                }
            }
            SqlCommand command = new SqlCommand(CommandText, conn);
            SetCommandParameters(ref command, Params);
            SqlTransaction transaction = conn.BeginTransaction();
            command.Transaction = transaction;
            bool flag2 = false;
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
                flag2 = true;
            }
            catch
            {
                transaction.Rollback();
                flag2 = false;
            }
            if (!flag)
            {
                conn.Close();
            }
            if (!flag2)
            {
                return -1002;
            }
            return 0;
        }

        public static int ExecuteNonQuery(string ConnectionString, string CommandText, params Parameter[] Params)
        {
            SqlConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return -1001;
            }
            int num = ExecuteNonQuery(conn, CommandText, Params);
            conn.Close();
            return num;
        }

        public static int ExecuteNonQueryNoTranscation(SqlConnection conn, string CommandText, params Parameter[] Params)
        {
            if (conn == null)
            {
                return -1001;
            }
            bool flag = true;
            if (conn.State != ConnectionState.Open)
            {
                flag = false;
                try
                {
                    conn.Open();
                }
                catch
                {
                    return -1001;
                }
            }
            SqlCommand command = new SqlCommand(CommandText, conn);
            SetCommandParameters(ref command, Params);
            bool flag2 = false;
            try
            {
                command.ExecuteNonQuery();
                flag2 = true;
            }
            catch
            {
                flag2 = false;
            }
            if (!flag)
            {
                conn.Close();
            }
            if (!flag2)
            {
                return -1002;
            }
            return 0;
        }

        public static object ExecuteScalar(string CommandText, params Parameter[] Params)
        {
            return ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandText, Params);
        }

        public static object ExecuteScalar(SqlConnection conn, string CommandText, params Parameter[] Params)
        {
            if (conn == null)
            {
                return null;
            }
            bool flag = true;
            if (conn.State != ConnectionState.Open)
            {
                flag = false;
                try
                {
                    conn.Open();
                }
                catch
                {
                    return null;
                }
            }
            SqlCommand command = new SqlCommand(CommandText, conn);
            SetCommandParameters(ref command, Params);
            object obj2 = null;
            try
            {
                obj2 = command.ExecuteScalar();
            }
            catch
            {
                obj2 = null;
            }
            if (!flag)
            {
                conn.Close();
            }
            return obj2;
        }

        public static object ExecuteScalar(string ConnectionString, string CommandText, params Parameter[] Params)
        {
            SqlConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return null;
            }
            object obj2 = ExecuteScalar(conn, CommandText, Params);
            conn.Close();
            return obj2;
        }

        public static bool ExecuteSQLScript(string Script)
        {
            Script = Script.Trim();
            return ((Script == "") || ExecuteSQLScript(ConfigurationSettings.AppSettings["ConnectionString"], Script));
        }

        public static bool ExecuteSQLScript(SqlConnection conn, string Script)
        {
            Script = Script.Trim();
            if (Script != "")
            {
                Regex regex = new Regex(@"/[*][\S\s\t\r\n\v\f]*?[*]/", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Script = regex.Replace(Script, "");
                regex = new Regex(@"--[^\n]*?[\n]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                Script = regex.Replace(Script, "\r\n");
                Script = Script.Trim();
                if (Script == "")
                {
                    return false;
                }
                Script = Script + "\r\n";
                string[] strArray = new Regex(@"[\n]GO[\r\t\v\s]*?[\n]", RegexOptions.Compiled | RegexOptions.IgnoreCase).Split(Script);
                if ((strArray == null) || (strArray.Length == 0))
                {
                    return false;
                }
                if (conn == null)
                {
                    return false;
                }
                bool flag = true;
                if (conn.State != ConnectionState.Open)
                {
                    flag = false;
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        return false;
                    }
                }
                SqlCommand command = new SqlCommand("", conn);
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();
                SqlTransaction transaction = conn.BeginTransaction();
                command.Transaction = transaction;
                foreach (string str in strArray)
                {
                    string str2 = str.Trim();
                    if (str2 != "")
                    {
                        command.CommandText = str2;
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch
                        {
                            transaction.Rollback();
                            if (!flag)
                            {
                                conn.Close();
                            }
                            return false;
                        }
                    }
                }
                transaction.Commit();
                if (!flag)
                {
                    conn.Close();
                }
            }
            return true;
        }

        public static bool ExecuteSQLScript(string ConnectionString, string Script)
        {
            Script = Script.Trim();
            if (Script == "")
            {
                return true;
            }
            SqlConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return false;
            }
            bool flag = ExecuteSQLScript(conn, Script);
            conn.Close();
            return flag;
        }

        public static int ExecuteStoredProcedureNonQuery(string StoredProcedureName, ref OutputParameter Outputs, params Parameter[] Params)
        {
            return ExecuteStoredProcedureNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], StoredProcedureName, ref Outputs, Params);
        }

        public static int ExecuteStoredProcedureNonQuery(SqlConnection conn, string StoredProcedureName, ref OutputParameter Outputs, params Parameter[] Params)
        {
            if (conn == null)
            {
                return -1001;
            }
            bool flag = true;
            if (conn.State != ConnectionState.Open)
            {
                flag = false;
                try
                {
                    conn.Open();
                }
                catch
                {
                    return -1001;
                }
            }
            SqlCommand command = new SqlCommand(StoredProcedureName, conn);
            command.CommandType = CommandType.StoredProcedure;
            SetCommandParameters(ref command, Params);
            SqlParameter parameter = new SqlParameter("@Shove_Database_MSSQL_ExecuteStoredProcedureNonQuery_Rtn", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(parameter);
            SqlTransaction transaction = conn.BeginTransaction();
            command.Transaction = transaction;
            bool flag2 = false;
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
                flag2 = true;
            }
            catch
            {
                transaction.Rollback();
                flag2 = false;
            }
            if (!flag)
            {
                conn.Close();
            }
            if (!flag2)
            {
                return -1002;
            }
            SetOutputParameter(command, ref Outputs);
            parameter = GetReturnParameter(command);
            if (parameter != null)
            {
                return (int) parameter.Value;
            }
            return 0;
        }

        public static int ExecuteStoredProcedureNonQuery(string ConnectionString, string StoredProcedureName, ref OutputParameter Outputs, params Parameter[] Params)
        {
            SqlConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return -1001;
            }
            int num = ExecuteStoredProcedureNonQuery(conn, StoredProcedureName, ref Outputs, Params);
            conn.Close();
            return num;
        }

        public static int ExecuteStoredProcedureWithQuery(string StoredProcedureName, ref DataSet ds, ref OutputParameter Outputs, params Parameter[] Params)
        {
            return ExecuteStoredProcedureWithQuery(ConfigurationSettings.AppSettings["ConnectionString"], StoredProcedureName, ref ds, ref Outputs, Params);
        }

        public static int ExecuteStoredProcedureWithQuery(SqlConnection conn, string StoredProcedureName, ref DataSet ds, ref OutputParameter Outputs, params Parameter[] Params)
        {
            if (conn == null)
            {
                return -1001;
            }
            bool flag = true;
            if (conn.State != ConnectionState.Open)
            {
                flag = false;
                try
                {
                    conn.Open();
                }
                catch
                {
                    return -1001;
                }
            }
            SqlDataAdapter adapter = new SqlDataAdapter("", conn);
            SqlCommand command = new SqlCommand(StoredProcedureName, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            SetCommandParameters(ref command, Params);
            SqlParameter parameter = new SqlParameter("@Shove_Database_MSSQL_ExecuteStoredProcedureWithQuery_Rtn", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(parameter);
            if (ds == null)
            {
                ds = new DataSet();
            }
            SqlTransaction transaction = conn.BeginTransaction();
            command.Transaction = transaction;
            adapter.SelectCommand = command;
            bool flag2 = false;
            try
            {
                adapter.Fill(ds);
                transaction.Commit();
                flag2 = true;
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                flag2 = false;
            }
            if (!flag)
            {
                conn.Close();
            }
            if (!flag2)
            {
                return -1002;
            }
            SetOutputParameter(command, ref Outputs);
            parameter = GetReturnParameter(command);
            if (parameter != null)
            {
                return (int) parameter.Value;
            }
            return 0;
        }

        public static int ExecuteStoredProcedureWithQuery(string ConnectionString, string StoredProcedureName, ref DataSet ds, ref OutputParameter Outputs, params Parameter[] Params)
        {
            SqlConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return -1001;
            }
            int num = ExecuteStoredProcedureWithQuery(conn, StoredProcedureName, ref ds, ref Outputs, Params);
            conn.Close();
            return num;
        }

        private static SqlParameter GetReturnParameter(SqlCommand cmd)
        {
            if (cmd != null)
            {
                if (cmd.Parameters.Count == 0)
                {
                    return null;
                }
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    SqlParameter parameter = cmd.Parameters[i];
                    if (parameter.Direction == ParameterDirection.ReturnValue)
                    {
                        return parameter;
                    }
                }
            }
            return null;
        }

        public static string GetConnectString(string SQLServerName, string SQLDatabaseName)
        {
            return string.Format("data source=\"{0}\";persist security info=False;initial catalog=\"{1}\"", SQLServerName, SQLDatabaseName);
        }

        public static string GetConnectString(string SQLServerName, string SQLDatabaseName, string SQLUID, string SQLPassword)
        {
            return string.Format("PWD={0};UID={1};data source=\"{2}\";persist security info=False;initial catalog=\"{3}\"", new object[] { SQLPassword, SQLUID, SQLServerName, SQLDatabaseName });
        }

        private static void SetOutputParameter(SqlCommand cmd, ref OutputParameter outParam)
        {
            if ((cmd != null) && (cmd.Parameters.Count != 0))
            {
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    SqlParameter parameter = cmd.Parameters[i];
                    if ((parameter.Direction == ParameterDirection.InputOutput) || (parameter.Direction == ParameterDirection.Output))
                    {
                        outParam.Add(parameter.ParameterName, parameter.Value);
                    }
                }
            }
        }

        public static DataTable Select(string CommandText, params Parameter[] Params)
        {
            return Select(ConfigurationSettings.AppSettings["ConnectionString"], CommandText, Params);
        }

        public static DataTable Select(SqlConnection conn, string CommandText, params Parameter[] Params)
        {
            if (conn == null)
            {
                return null;
            }
            bool flag = true;
            if (conn.State != ConnectionState.Open)
            {
                flag = false;
                try
                {
                    conn.Open();
                }
                catch
                {
                    return null;
                }
            }
            SqlDataAdapter adapter = new SqlDataAdapter("", conn);
            SqlCommand command = new SqlCommand(CommandText, conn);
            SetCommandParameters(ref command, Params);
            adapter.SelectCommand = command;
            DataTable dataTable = new DataTable();
            bool flag2 = false;
            try
            {
                adapter.Fill(dataTable);
                flag2 = true;
            }
            catch
            {
                flag2 = false;
            }
            if (!flag)
            {
                conn.Close();
            }
            if (!flag2)
            {
                return null;
            }
            return dataTable;
        }

        public static DataTable Select(string ConnectionString, string CommandText, params Parameter[] Params)
        {
            SqlConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return null;
            }
            DataTable table = Select(conn, CommandText, Params);
            conn.Close();
            return table;
        }

        private static string GetCallCert()
        {
            string sSourceStr = "";
            string str2 = _String.Reverse("ShoveSoft" + " " + "CO.,Ltd ");
            str2 = _String.Reverse(_String.Reverse(str2) + ("--" + " by Shove "));
            sSourceStr = "20050709";
            sSourceStr = _String.Reverse(sSourceStr + " 深圳" + "宝安");
            return (_String.Reverse(str2) + _String.Reverse(sSourceStr));
        }

        private static void SetCommandParameters(ref SqlCommand cmd, params Parameter[] paras)
        {
            if ((paras != null) && (cmd != null))
            {
                for (int i = 0; i < paras.Length; i++)
                {
                    if (paras[i] != null)
                    {
                        SqlParameter parameter = new SqlParameter();
                        parameter.ParameterName = paras[i].Name.StartsWith("@") ? paras[i].Name : ("@" + paras[i].Name);
                        parameter.SqlDbType = paras[i].Type;
                        if (paras[i].Size > 0)
                        {
                            parameter.Size = paras[i].Size;
                        }
                        parameter.Direction = paras[i].Direction;
                        if (((paras[i].Direction == ParameterDirection.InputOutput) || (paras[i].Direction == ParameterDirection.Input)) && (paras[i].Value != null))
                        {
                            if ((((parameter.SqlDbType == SqlDbType.Char) || (parameter.SqlDbType == SqlDbType.NChar)) || ((parameter.SqlDbType == SqlDbType.NText) || (parameter.SqlDbType == SqlDbType.NVarChar))) || ((parameter.SqlDbType == SqlDbType.Text) || (parameter.SqlDbType == SqlDbType.VarChar)))
                            {
                                parameter.Value = Utility.FilteSqlInfusion(paras[i].Value.ToString());
                            }
                            else
                            {
                                parameter.Value = paras[i].Value;
                            }
                        }
                        cmd.Parameters.Add(parameter);
                    }
                }
            }
        }

        public class Field
        {
            public string CanonicalIdentifierName;
            public SqlDbType DbType;
            public string Name;
            public object Parent;
            public bool ReadOnly;
            private object ReturnValue;

            public Field(object parent, string name, string canonicalidentifiername, SqlDbType dbtype, bool _readonly)
            {
                this.Parent = parent;
                this.Name = name;
                this.CanonicalIdentifierName = canonicalidentifiername;
                this.DbType = dbtype;
                this.ReadOnly = _readonly;
            }

            public object Value
            {
                get
                {
                    return this.ReturnValue;
                }
                set
                {
                    if (this.ReadOnly)
                    {
                        throw new Exception("the member “" + this.Name + "” is ReadOnly.");
                    }
                    this.ReturnValue = value;
                    if (this.Parent != null)
                    {
                        ((MSSQL.TableBase) this.Parent).Fields.Add(this);
                    }
                }
            }
        }

        public class FieldCollection
        {
            private ArrayList fields = new ArrayList();

            public void Add(object obj)
            {
                this.fields.Add(obj);
            }

            public void Clear()
            {
                this.fields.Clear();
            }

            public int Count
            {
                get
                {
                    return this.fields.Count;
                }
            }

            public MSSQL.Field this[int Index]
            {
                get
                {
                    if (((this.Count >= 1) && (Index >= 0)) && (Index <= this.Count))
                    {
                        return (MSSQL.Field) this.fields[Index];
                    }
                    return null;
                }
            }
        }

        public class OutputParameter
        {
            public ArrayList ParametersName = new ArrayList();
            public ArrayList ParametersValue = new ArrayList();

            public void Add(string Name, object Value)
            {
                this.ParametersName.Add(Name.StartsWith("@") ? Name.Substring(1, Name.Length - 1) : Name);
                this.ParametersValue.Add(Value);
            }

            public void Clear()
            {
                this.ParametersName.Clear();
                this.ParametersValue.Clear();
            }

            public int Count
            {
                get
                {
                    if (this.ParametersName == null)
                    {
                        return 0;
                    }
                    return this.ParametersName.Count;
                }
            }

            public object this[string Name]
            {
                get
                {
                    if (this.ParametersValue != null)
                    {
                        for (int i = 0; i < this.ParametersName.Count; i++)
                        {
                            if (this.ParametersName[i].ToString() == Name)
                            {
                                return this.ParametersValue[i];
                            }
                        }
                    }
                    return null;
                }
            }

            public object this[int Index]
            {
                get
                {
                    if (this.ParametersValue == null)
                    {
                        return null;
                    }
                    if (this.ParametersValue.Count == 0)
                    {
                        return null;
                    }
                    return this.ParametersValue[Index];
                }
            }
        }

        public class Parameter
        {
            public ParameterDirection Direction;
            public string Name;
            public int Size;
            public SqlDbType Type;
            public object Value;

            public Parameter(string name, SqlDbType type, int size, ParameterDirection direction, object value)
            {
                this.Name = name;
                this.Type = type;
                this.Size = size;
                this.Direction = direction;
                this.Value = value;
            }
        }

        public class TableBase
        {
            public MSSQL.FieldCollection Fields = new MSSQL.FieldCollection();
            public string TableName = "";

            public long Delete(string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MSSQL.ExecuteScalar("delete from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + "; select isnull(cast(rowcount_big() as bigint), -99999999)", new MSSQL.Parameter[0]);
                if (obj2 == null)
                {
                    return -102L;
                }
                this.Fields.Clear();
                long num = (long) obj2;
                if (num == -99999999L)
                {
                    return 0L;
                }
                return num;
            }

            public long Delete(SqlConnection conn, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MSSQL.ExecuteScalar(conn, "delete from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + "; select isnull(cast(rowcount_big() as bigint), -99999999)", new MSSQL.Parameter[0]);
                if (obj2 == null)
                {
                    return -102L;
                }
                this.Fields.Clear();
                long num = (long) obj2;
                if (num == -99999999L)
                {
                    return 0L;
                }
                return num;
            }

            public long Delete(string ConnectionString, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MSSQL.ExecuteScalar(ConnectionString, "delete from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + "; select isnull(cast(rowcount_big() as bigint), -99999999)", new MSSQL.Parameter[0]);
                if (obj2 == null)
                {
                    return -102L;
                }
                this.Fields.Clear();
                long num = (long) obj2;
                if (num == -99999999L)
                {
                    return 0L;
                }
                return num;
            }

            public long GetCount(string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MSSQL.ExecuteScalar("select count(*) from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)), new MSSQL.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long GetCount(SqlConnection conn, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MSSQL.ExecuteScalar(conn, "select count(*) from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)), new MSSQL.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long GetCount(string ConnectionString, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MSSQL.ExecuteScalar(ConnectionString, "select count(*) from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)), new MSSQL.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long Insert()
            {
                if (this.Fields.Count < 1)
                {
                    return -101L;
                }
                string str = "";
                string str2 = "";
                MSSQL.Parameter[] paras = new MSSQL.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        str = str + ", ";
                        str2 = str2 + ", ";
                    }
                    str = str + "[" + this.Fields[i].Name + "]";
                    str2 = str2 + "@" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new MSSQL.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                object obj2 = MSSQL.ExecuteScalar("insert into [" + this.TableName + "] (" + str + ") values (" + str2 + "); select isnull(cast(scope_identity() as bigint), -99999999)", paras);
                if (obj2 == null)
                {
                    return -102L;
                }
                this.Fields.Clear();
                long num2 = (long) obj2;
                if (num2 == -99999999L)
                {
                    return 0L;
                }
                return num2;
            }

            public long Insert(SqlConnection conn)
            {
                if (this.Fields.Count < 1)
                {
                    return -101L;
                }
                string str = "";
                string str2 = "";
                MSSQL.Parameter[] paras = new MSSQL.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        str = str + ", ";
                        str2 = str2 + ", ";
                    }
                    str = str + "[" + this.Fields[i].Name + "]";
                    str2 = str2 + "@" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new MSSQL.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                string commandText = "insert into [" + this.TableName + "] (" + str + ") values (" + str2 + "); select isnull(cast(scope_identity() as bigint), -99999999)";
                object obj2 = MSSQL.ExecuteScalar(conn, commandText, paras);
                if (obj2 == null)
                {
                    return -102L;
                }
                this.Fields.Clear();
                long num2 = (long) obj2;
                if (num2 == -99999999L)
                {
                    return 0L;
                }
                return num2;
            }

            public long Insert(string ConnectionString)
            {
                if (this.Fields.Count < 1)
                {
                    return -101L;
                }
                string str = "";
                string str2 = "";
                MSSQL.Parameter[] paras = new MSSQL.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        str = str + ", ";
                        str2 = str2 + ", ";
                    }
                    str = str + "[" + this.Fields[i].Name + "]";
                    str2 = str2 + "@" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new MSSQL.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                string commandText = "insert into [" + this.TableName + "] (" + str + ") values (" + str2 + "); select isnull(cast(scope_identity() as bigint), -99999999)";
                object obj2 = MSSQL.ExecuteScalar(ConnectionString, commandText, paras);
                if (obj2 == null)
                {
                    return -102L;
                }
                this.Fields.Clear();
                long num2 = (long) obj2;
                if (num2 == -99999999L)
                {
                    return 0L;
                }
                return num2;
            }

            public DataTable Open(string FieldList, string Condition, string Order)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                return MSSQL.Select("select " + ((FieldList == "") ? "*" : FieldList) + " from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)), new MSSQL.Parameter[0]);
            }

            public DataTable Open(SqlConnection conn, string FieldList, string Condition, string Order)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                return MSSQL.Select(conn, "select " + ((FieldList == "") ? "*" : FieldList) + " from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)), new MSSQL.Parameter[0]);
            }

            public DataTable Open(string ConnectionString, string FieldList, string Condition, string Order)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                return MSSQL.Select(ConnectionString, "select " + ((FieldList == "") ? "*" : FieldList) + " from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)), new MSSQL.Parameter[0]);
            }

            public long Update(string Condition)
            {
                if (this.Fields.Count < 1)
                {
                    return -101L;
                }
                Condition = Condition.Trim();
                string str = "update [" + this.TableName + "] set ";
                MSSQL.Parameter[] paras = new MSSQL.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        str = str + ", ";
                    }
                    string str2 = str;
                    str = str2 + "[" + this.Fields[i].Name + "] = @" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new MSSQL.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                if (!string.IsNullOrEmpty(Condition))
                {
                    str = str + " where " + Condition;
                }
                object obj2 = MSSQL.ExecuteScalar(str + "; select isnull(cast(rowcount_big() as bigint), -99999999)", paras);
                if (obj2 == null)
                {
                    return -102L;
                }
                this.Fields.Clear();
                long num2 = (long) obj2;
                if (num2 == -99999999L)
                {
                    return 0L;
                }
                return num2;
            }

            public long Update(SqlConnection conn, string Condition)
            {
                if (this.Fields.Count < 1)
                {
                    return -101L;
                }
                Condition = Condition.Trim();
                string commandText = "update [" + this.TableName + "] set ";
                MSSQL.Parameter[] paras = new MSSQL.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        commandText = commandText + ", ";
                    }
                    string str2 = commandText;
                    commandText = str2 + "[" + this.Fields[i].Name + "] = @" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new MSSQL.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                if (!string.IsNullOrEmpty(Condition))
                {
                    commandText = commandText + " where " + Condition;
                }
                commandText = commandText + "; select isnull(cast(rowcount_big() as bigint), -99999999)";
                object obj2 = MSSQL.ExecuteScalar(conn, commandText, paras);
                if (obj2 == null)
                {
                    return -102L;
                }
                this.Fields.Clear();
                long num2 = (long) obj2;
                if (num2 == -99999999L)
                {
                    return 0L;
                }
                return num2;
            }

            public long Update(string ConnectionString, string Condition)
            {
                if (this.Fields.Count < 1)
                {
                    return -101L;
                }
                Condition = Condition.Trim();
                string commandText = "update [" + this.TableName + "] set ";
                MSSQL.Parameter[] paras = new MSSQL.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        commandText = commandText + ", ";
                    }
                    string str2 = commandText;
                    commandText = str2 + "[" + this.Fields[i].Name + "] = @" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new MSSQL.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                if (!string.IsNullOrEmpty(Condition))
                {
                    commandText = commandText + " where " + Condition;
                }
                commandText = commandText + "; select isnull(cast(rowcount_big() as bigint), -99999999)";
                object obj2 = MSSQL.ExecuteScalar(ConnectionString, commandText, paras);
                if (obj2 == null)
                {
                    return -102L;
                }
                this.Fields.Clear();
                long num2 = (long) obj2;
                if (num2 == -99999999L)
                {
                    return 0L;
                }
                return num2;
            }
        }

        public class ViewBase
        {
            public string ViewName = "";

            public long GetCount(string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MSSQL.ExecuteScalar("select count(*) from [" + this.ViewName + "]" + ((Condition == "") ? "" : (" where " + Condition)), new MSSQL.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long GetCount(SqlConnection conn, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MSSQL.ExecuteScalar(conn, "select count(*) from [" + this.ViewName + "]" + ((Condition == "") ? "" : (" where " + Condition)), new MSSQL.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long GetCount(string ConnectionString, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MSSQL.ExecuteScalar(ConnectionString, "select count(*) from [" + this.ViewName + "]" + ((Condition == "") ? "" : (" where " + Condition)), new MSSQL.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public DataTable Open(string FieldList, string Condition, string Order)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                return MSSQL.Select("select " + ((FieldList == "") ? "*" : FieldList) + " from [" + this.ViewName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)), new MSSQL.Parameter[0]);
            }

            public DataTable Open(SqlConnection conn, string FieldList, string Condition, string Order)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                return MSSQL.Select(conn, "select " + ((FieldList == "") ? "*" : FieldList) + " from [" + this.ViewName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)), new MSSQL.Parameter[0]);
            }

            public DataTable Open(string ConnectionString, string FieldList, string Condition, string Order)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                return MSSQL.Select(ConnectionString, "select " + ((FieldList == "") ? "*" : FieldList) + " from [" + this.ViewName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)), new MSSQL.Parameter[0]);
            }
        }
    }
}

