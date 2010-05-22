namespace Shove.Database
{
    using MySql.Data.MySqlClient;
    using Shove;
    using Shove._Security;
    using Shove._Web;
    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Reflection;

    public class MySQL
    {
        private const string key = "Q56GtyNkop97Ht334Ttyurfg";

        public static MySqlConnection CreateDataConnection()
        {
            return CreateDataConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        }

        public static MySqlConnection CreateDataConnection(string ConnectionString)
        {
            if (ConnectionString.StartsWith("0x78AD"))
            {
                ConnectionString = Encrypt.Decrypt3DES("ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安", ConnectionString.Substring(6), "Q56GtyNkop97Ht334Ttyurfg");
            }
            MySqlConnection connection = new MySqlConnection(ConnectionString);
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

        public static object ExecuteFunction(MySqlConnection conn, string FunctionName, params Parameter[] Params)
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
            string commandText = "select " + FunctionName + "(";
            if (Params != null)
            {
                for (int i = 0; i < Params.Length; i++)
                {
                    if (Params[i] != null)
                    {
                        bool flag2 = false;
                        if (((((Params[i].Type == MySqlDbType.Date) || (Params[i].Type == MySqlDbType.DateTime)) || ((Params[i].Type == MySqlDbType.DateTime) || (Params[i].Type == MySqlDbType.Guid))) || (((Params[i].Type == MySqlDbType.LongText) || (Params[i].Type == MySqlDbType.MediumText)) || ((Params[i].Type == MySqlDbType.Newdate) || (Params[i].Type == MySqlDbType.String)))) || ((((Params[i].Type == MySqlDbType.Text) || (Params[i].Type == MySqlDbType.Time)) || ((Params[i].Type == MySqlDbType.Timestamp) || (Params[i].Type == MySqlDbType.TinyText))) || ((Params[i].Type == MySqlDbType.VarChar) || (Params[i].Type == MySqlDbType.VarString))))
                        {
                            flag2 = true;
                        }
                        if (!commandText.EndsWith("("))
                        {
                            commandText = commandText + ", ";
                        }
                        if (flag2)
                        {
                            commandText = commandText + "'";
                        }
                        commandText = commandText + Params[i].Value.ToString();
                        if (flag2)
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
            MySqlConnection conn = CreateDataConnection(ConnectionString);
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

        public static int ExecuteNonQuery(MySqlConnection conn, string CommandText, params Parameter[] Params)
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
            MySqlCommand command = new MySqlCommand(CommandText, conn);
            SetCommandParameters(ref command, Params);
            MySqlTransaction transaction = conn.BeginTransaction();
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
            MySqlConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return -1001;
            }
            int num = ExecuteNonQuery(conn, CommandText, Params);
            conn.Close();
            return num;
        }

        public static int ExecuteNonQueryNoTranscation(MySqlConnection conn, string CommandText, params Parameter[] Params)
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
            MySqlCommand command = new MySqlCommand(CommandText, conn);
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

        public static object ExecuteScalar(MySqlConnection conn, string CommandText, params Parameter[] Params)
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
            MySqlCommand command = new MySqlCommand(CommandText, conn);
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
            MySqlConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return null;
            }
            object obj2 = ExecuteScalar(conn, CommandText, Params);
            conn.Close();
            return obj2;
        }

        public static int ExecuteStoredProcedureNonQuery(string StoredProcedureName, ref OutputParameter Outputs, params Parameter[] Params)
        {
            return ExecuteStoredProcedureNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], StoredProcedureName, ref Outputs, Params);
        }

        public static int ExecuteStoredProcedureNonQuery(MySqlConnection conn, string StoredProcedureName, ref OutputParameter Outputs, params Parameter[] Params)
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
            MySqlCommand command = new MySqlCommand(StoredProcedureName, conn);
            command.CommandType = CommandType.StoredProcedure;
            SetCommandParameters(ref command, Params);
            MySqlTransaction transaction = conn.BeginTransaction();
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
            return 0;
        }

        public static int ExecuteStoredProcedureNonQuery(string ConnectionString, string StoredProcedureName, ref OutputParameter Outputs, params Parameter[] Params)
        {
            MySqlConnection conn = CreateDataConnection(ConnectionString);
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

        public static int ExecuteStoredProcedureWithQuery(MySqlConnection conn, string StoredProcedureName, ref DataSet ds, ref OutputParameter Outputs, params Parameter[] Params)
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
            MySqlDataAdapter adapter = new MySqlDataAdapter("", conn);
            MySqlCommand command = new MySqlCommand(StoredProcedureName, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            SetCommandParameters(ref command, Params);
            if (ds == null)
            {
                ds = new DataSet();
            }
            MySqlTransaction transaction = conn.BeginTransaction();
            command.Transaction = transaction;
            adapter.SelectCommand = command;
            bool flag2 = false;
            try
            {
                adapter.Fill(ds);
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
            return 0;
        }

        public static int ExecuteStoredProcedureWithQuery(string ConnectionString, string StoredProcedureName, ref DataSet ds, ref OutputParameter Outputs, params Parameter[] Params)
        {
            MySqlConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return -1001;
            }
            int num = ExecuteStoredProcedureWithQuery(conn, StoredProcedureName, ref ds, ref Outputs, Params);
            conn.Close();
            return num;
        }

        private static MySqlParameter GetReturnParameter(MySqlCommand cmd)
        {
            if (cmd != null)
            {
                if (cmd.Parameters.Count == 0)
                {
                    return null;
                }
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    MySqlParameter parameter = cmd.Parameters[i];
                    if (parameter.Direction == ParameterDirection.ReturnValue)
                    {
                        return parameter;
                    }
                }
            }
            return null;
        }

        public static string GetConnectString(string UID, string Password, string DatabaseName)
        {
            return string.Format("server=localhost; user id={0}; password={1}; database={2};", UID, Password, DatabaseName);
        }

        public static string GetConnectString(string ServerName, string UID, string Password, string DatabaseName)
        {
            return string.Format("server={0}; user id={1}; password={2}; database={3};", new object[] { ServerName, UID, Password, DatabaseName });
        }

        public static string GetConnectString(string ServerName, string UID, string Password, string DatabaseName, string Port)
        {
            return string.Format("server={0}; user id={1}; password={2}; database={3}; port={4}", new object[] { ServerName, UID, Password, DatabaseName, Port });
        }

        public static string GetConnectString(string ServerName, string UID, string Password, string DatabaseName, string Port, string Charset)
        {
            return string.Format("server={0}; user id={1}; password={2}; database={3}; port={4}; charset={5}", new object[] { ServerName, UID, Password, DatabaseName, Port, Charset });
        }

        public static string GetConnectString(string ServerName, string UID, string Password, string DatabaseName, string Port, string Charset, bool Pooling)
        {
            return string.Format("server={0}; user id={1}; password={2}; database={3}; port={4}; charset={5}; pooling={6}", new object[] { ServerName, UID, Password, DatabaseName, Port, Charset, Pooling ? "true" : "false" });
        }

        private static void SetOutputParameter(MySqlCommand cmd, ref OutputParameter outParam)
        {
            if ((cmd != null) && (cmd.Parameters.Count != 0))
            {
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    MySqlParameter parameter = cmd.Parameters[i];
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

        public static DataTable Select(MySqlConnection conn, string CommandText, params Parameter[] Params)
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
            MySqlDataAdapter adapter = new MySqlDataAdapter("", conn);
            MySqlCommand command = new MySqlCommand(CommandText, conn);
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
            MySqlConnection conn = CreateDataConnection(ConnectionString);
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

        private static void SetCommandParameters(ref MySqlCommand cmd, params Parameter[] paras)
        {
            if ((paras != null) && (cmd != null))
            {
                for (int i = 0; i < paras.Length; i++)
                {
                    if (paras[i] != null)
                    {
                        MySqlParameter parameter = new MySqlParameter();
                        parameter.ParameterName = paras[i].Name.StartsWith("?") ? paras[i].Name : ("?" + paras[i].Name);
                        parameter.MySqlDbType = paras[i].Type;
                        if (paras[i].Size > 0)
                        {
                            parameter.Size = paras[i].Size;
                        }
                        parameter.Direction = paras[i].Direction;
                        if (((paras[i].Direction == ParameterDirection.InputOutput) || (paras[i].Direction == ParameterDirection.Input)) && (paras[i].Value != null))
                        {
                            if ((((parameter.MySqlDbType == MySqlDbType.LongText) || (parameter.MySqlDbType == MySqlDbType.MediumText)) || ((parameter.MySqlDbType == MySqlDbType.String) || (parameter.MySqlDbType == MySqlDbType.Text))) || (((parameter.MySqlDbType == MySqlDbType.TinyText) || (parameter.MySqlDbType == MySqlDbType.VarChar)) || (parameter.MySqlDbType == MySqlDbType.VarString)))
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
            public MySqlDbType DbType;
            public string Name;
            public object Parent;
            public bool ReadOnly;
            private object ReturnValue;

            public Field(object parent, string name, string canonicalidentifiername, MySqlDbType dbtype, bool _readonly)
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
                        ((MySQL.TableBase) this.Parent).Fields.Add(this);
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

            public MySQL.Field this[int Index]
            {
                get
                {
                    if (((this.Count >= 1) && (Index >= 0)) && (Index <= this.Count))
                    {
                        return (MySQL.Field) this.fields[Index];
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
                this.ParametersName.Add(Name.StartsWith("?") ? Name.Substring(1, Name.Length - 1) : Name);
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
            public MySqlDbType Type;
            public object Value;

            public Parameter(string name, MySqlDbType type, int size, ParameterDirection direction, object value)
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
            public MySQL.FieldCollection Fields = new MySQL.FieldCollection();
            public string TableName = "";

            public long Delete(string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MySQL.ExecuteScalar("delete from `" + this.TableName + "`" + ((Condition == "") ? "" : (" where " + Condition)) + "; select ifnull(ROW_COUNT(), -99999999)", new MySQL.Parameter[0]);
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

            public long Delete(MySqlConnection conn, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MySQL.ExecuteScalar(conn, "delete from `" + this.TableName + "`" + ((Condition == "") ? "" : (" where " + Condition)) + "; select ifnull(ROW_COUNT(), -99999999)", new MySQL.Parameter[0]);
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
                object obj2 = MySQL.ExecuteScalar(ConnectionString, "delete from `" + this.TableName + "`" + ((Condition == "") ? "" : (" where " + Condition)) + "; select ifnull(ROW_COUNT(), -99999999)", new MySQL.Parameter[0]);
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
                object obj2 = MySQL.ExecuteScalar("select count(*) from `" + this.TableName + "`" + ((Condition == "") ? "" : (" where " + Condition)), new MySQL.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long GetCount(MySqlConnection conn, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MySQL.ExecuteScalar(conn, "select count(*) from `" + this.TableName + "`" + ((Condition == "") ? "" : (" where " + Condition)), new MySQL.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long GetCount(string ConnectionString, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MySQL.ExecuteScalar(ConnectionString, "select count(*) from `" + this.TableName + "`" + ((Condition == "") ? "" : (" where " + Condition)), new MySQL.Parameter[0]);
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
                MySQL.Parameter[] paras = new MySQL.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        str = str + ", ";
                        str2 = str2 + ", ";
                    }
                    str = str + "`" + this.Fields[i].Name + "`";
                    str2 = str2 + "?" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new MySQL.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                object obj2 = MySQL.ExecuteScalar("insert into `" + this.TableName + "` (" + str + ") values (" + str2 + "); select ifnull(LAST_INSERT_ID(), -99999999)", paras);
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

            public long Insert(MySqlConnection conn)
            {
                if (this.Fields.Count < 1)
                {
                    return -101L;
                }
                string str = "";
                string str2 = "";
                MySQL.Parameter[] paras = new MySQL.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        str = str + ", ";
                        str2 = str2 + ", ";
                    }
                    str = str + "`" + this.Fields[i].Name + "`";
                    str2 = str2 + "?" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new MySQL.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                string commandText = "insert into `" + this.TableName + "` (" + str + ") values (" + str2 + "); select ifnull(LAST_INSERT_ID(), -99999999)";
                object obj2 = MySQL.ExecuteScalar(conn, commandText, paras);
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
                MySQL.Parameter[] paras = new MySQL.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        str = str + ", ";
                        str2 = str2 + ", ";
                    }
                    str = str + "`" + this.Fields[i].Name + "`";
                    str2 = str2 + "?" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new MySQL.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                string commandText = "insert into `" + this.TableName + "` (" + str + ") values (" + str2 + "); select ifnull(LAST_INSERT_ID(), -99999999)";
                object obj2 = MySQL.ExecuteScalar(ConnectionString, commandText, paras);
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

            public DataTable Open(string FieldList, string Condition, string Order, long LimitStart, long LimitCount)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                string str = "";
                if (LimitStart >= 0L)
                {
                    str = " limit " + LimitStart.ToString();
                    if (LimitCount >= 1L)
                    {
                        str = str + ", " + LimitCount.ToString();
                    }
                }
                return MySQL.Select("select " + ((FieldList == "") ? "*" : FieldList) + " from `" + this.TableName + "`" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)) + str, new MySQL.Parameter[0]);
            }

            public DataTable Open(MySqlConnection conn, string FieldList, string Condition, string Order, long LimitStart, long LimitCount)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                string str = "";
                if (LimitStart >= 0L)
                {
                    str = " limit " + LimitStart.ToString();
                    if (LimitCount >= 1L)
                    {
                        str = str + ", " + LimitCount.ToString();
                    }
                }
                return MySQL.Select(conn, "select " + ((FieldList == "") ? "*" : FieldList) + " from `" + this.TableName + "`" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)) + str, new MySQL.Parameter[0]);
            }

            public DataTable Open(string ConnectionString, string FieldList, string Condition, string Order, long LimitStart, long LimitCount)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                string str = "";
                if (LimitStart >= 0L)
                {
                    str = " limit " + LimitStart.ToString();
                    if (LimitCount >= 1L)
                    {
                        str = str + ", " + LimitCount.ToString();
                    }
                }
                return MySQL.Select(ConnectionString, "select " + ((FieldList == "") ? "*" : FieldList) + " from `" + this.TableName + "`" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)) + str, new MySQL.Parameter[0]);
            }

            public long Update(string Condition)
            {
                if (this.Fields.Count < 1)
                {
                    return -101L;
                }
                Condition = Condition.Trim();
                string str = "update `" + this.TableName + "` set ";
                MySQL.Parameter[] paras = new MySQL.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        str = str + ", ";
                    }
                    string str2 = str;
                    str = str2 + "`" + this.Fields[i].Name + "` = ?" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new MySQL.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                if (!string.IsNullOrEmpty(Condition))
                {
                    str = str + " where " + Condition;
                }
                object obj2 = MySQL.ExecuteScalar(str + "; select ifnull(ROW_COUNT(), -99999999)", paras);
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

            public long Update(MySqlConnection conn, string Condition)
            {
                if (this.Fields.Count < 1)
                {
                    return -101L;
                }
                Condition = Condition.Trim();
                string commandText = "update `" + this.TableName + "` set ";
                MySQL.Parameter[] paras = new MySQL.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        commandText = commandText + ", ";
                    }
                    string str2 = commandText;
                    commandText = str2 + "`" + this.Fields[i].Name + "` = ?" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new MySQL.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                if (!string.IsNullOrEmpty(Condition))
                {
                    commandText = commandText + " where " + Condition;
                }
                commandText = commandText + "; select ifnull(ROW_COUNT(), -99999999)";
                object obj2 = MySQL.ExecuteScalar(conn, commandText, paras);
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
                string commandText = "update `" + this.TableName + "` set ";
                MySQL.Parameter[] paras = new MySQL.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        commandText = commandText + ", ";
                    }
                    string str2 = commandText;
                    commandText = str2 + "`" + this.Fields[i].Name + "` = ?" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new MySQL.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                if (!string.IsNullOrEmpty(Condition))
                {
                    commandText = commandText + " where " + Condition;
                }
                commandText = commandText + "; select ifnull(ROW_COUNT(), -99999999)";
                object obj2 = MySQL.ExecuteScalar(ConnectionString, commandText, paras);
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
                object obj2 = MySQL.ExecuteScalar("select count(*) from `" + this.ViewName + "`" + ((Condition == "") ? "" : (" where " + Condition)), new MySQL.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long GetCount(MySqlConnection conn, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MySQL.ExecuteScalar(conn, "select count(*) from `" + this.ViewName + "`" + ((Condition == "") ? "" : (" where " + Condition)), new MySQL.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long GetCount(string ConnectionString, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = MySQL.ExecuteScalar(ConnectionString, "select count(*) from `" + this.ViewName + "`" + ((Condition == "") ? "" : (" where " + Condition)), new MySQL.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public DataTable Open(string FieldList, string Condition, string Order, long LimitStart, long LimitCount)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                string str = "";
                if (LimitStart >= 0L)
                {
                    str = " limit " + LimitStart.ToString();
                    if (LimitCount >= 1L)
                    {
                        str = str + ", " + LimitCount.ToString();
                    }
                }
                return MySQL.Select("select " + ((FieldList == "") ? "*" : FieldList) + " from `" + this.ViewName + "`" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)) + str, new MySQL.Parameter[0]);
            }

            public DataTable Open(MySqlConnection conn, string FieldList, string Condition, string Order, long LimitStart, long LimitCount)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                string str = "";
                if (LimitStart >= 0L)
                {
                    str = " limit " + LimitStart.ToString();
                    if (LimitCount >= 1L)
                    {
                        str = str + ", " + LimitCount.ToString();
                    }
                }
                return MySQL.Select(conn, "select " + ((FieldList == "") ? "*" : FieldList) + " from `" + this.ViewName + "`" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)) + str, new MySQL.Parameter[0]);
            }

            public DataTable Open(string ConnectionString, string FieldList, string Condition, string Order, long LimitStart, long LimitCount)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                string str = "";
                if (LimitStart >= 0L)
                {
                    str = " limit " + LimitStart.ToString();
                    if (LimitCount >= 1L)
                    {
                        str = str + ", " + LimitCount.ToString();
                    }
                }
                return MySQL.Select(ConnectionString, "select " + ((FieldList == "") ? "*" : FieldList) + " from `" + this.ViewName + "`" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)) + str, new MySQL.Parameter[0]);
            }
        }
    }
}

