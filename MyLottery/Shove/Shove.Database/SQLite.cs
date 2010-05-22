namespace Shove.Database
{
    using Shove;
    using Shove._Security;
    using Shove._Web;
    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Data.SQLite;
    using System.Reflection;

    public class SQLite
    {
        private const string key = "Q56GtyNkop97Ht334Ttyurfg";

        public static SQLiteConnection CreateDataConnection()
        {
            return CreateDataConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        }

        public static SQLiteConnection CreateDataConnection(string ConnectionString)
        {
            if (ConnectionString.StartsWith("0x78AD"))
            {
                ConnectionString = Encrypt.Decrypt3DES("ShoveSoft CO.,Ltd -- by Shove 20050709 深圳宝安", ConnectionString.Substring(6), "Q56GtyNkop97Ht334Ttyurfg");
            }
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
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

        public static int ExecuteNonQuery(string CommandText, params Parameter[] Params)
        {
            return ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandText, Params);
        }

        public static int ExecuteNonQuery(SQLiteConnection conn, string CommandText, params Parameter[] Params)
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
            SQLiteCommand command = new SQLiteCommand(CommandText, conn);
            SetCommandParameters(ref command, Params);
            SQLiteTransaction transaction = conn.BeginTransaction();
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
            SQLiteConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return -1001;
            }
            int num = ExecuteNonQuery(conn, CommandText, Params);
            conn.Close();
            return num;
        }

        public static int ExecuteNonQueryNoTranscation(SQLiteConnection conn, string CommandText, params Parameter[] Params)
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
            SQLiteCommand command = new SQLiteCommand(CommandText, conn);
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

        public static object ExecuteScalar(SQLiteConnection conn, string CommandText, params Parameter[] Params)
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
            SQLiteCommand command = new SQLiteCommand(CommandText, conn);
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
            SQLiteConnection conn = CreateDataConnection(ConnectionString);
            if (conn == null)
            {
                return null;
            }
            object obj2 = ExecuteScalar(conn, CommandText, Params);
            conn.Close();
            return obj2;
        }

        private static SQLiteParameter GetReturnParameter(SQLiteCommand cmd)
        {
            if (cmd != null)
            {
                if (cmd.Parameters.Count == 0)
                {
                    return null;
                }
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    SQLiteParameter parameter = cmd.Parameters[i];
                    if (parameter.Direction == ParameterDirection.ReturnValue)
                    {
                        return parameter;
                    }
                }
            }
            return null;
        }

        public static string GetConnectString(string DatabaseFileName)
        {
            return string.Format("data source={0}", DatabaseFileName);
        }

        public static string GetConnectString(string DatabaseFileName, string Version)
        {
            return string.Format("data source={0};version={1}", DatabaseFileName, Version);
        }

        private static void SetOutputParameter(SQLiteCommand cmd, ref OutputParameter outParam)
        {
            if ((cmd != null) && (cmd.Parameters.Count != 0))
            {
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    SQLiteParameter parameter = cmd.Parameters[i];
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

        public static DataTable Select(SQLiteConnection conn, string CommandText, params Parameter[] Params)
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
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("", conn);
            SQLiteCommand command = new SQLiteCommand(CommandText, conn);
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
            SQLiteConnection conn = CreateDataConnection(ConnectionString);
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

        private static void SetCommandParameters(ref SQLiteCommand cmd, params Parameter[] paras)
        {
            if ((paras != null) && (cmd != null))
            {
                for (int i = 0; i < paras.Length; i++)
                {
                    if (paras[i] != null)
                    {
                        SQLiteParameter parameter = new SQLiteParameter();
                        parameter.ParameterName = paras[i].Name.StartsWith("@") ? paras[i].Name : ("@" + paras[i].Name);
                        parameter.DbType = paras[i].Type;
                        if (paras[i].Size > 0)
                        {
                            parameter.Size = paras[i].Size;
                        }
                        parameter.Direction = paras[i].Direction;
                        if (((paras[i].Direction == ParameterDirection.InputOutput) || (paras[i].Direction == ParameterDirection.Input)) && (paras[i].Value != null))
                        {
                            if ((((parameter.DbType == DbType.Time) || (parameter.DbType == DbType.Date)) || ((parameter.DbType == DbType.DateTime) || (parameter.DbType == DbType.AnsiString))) || (((parameter.DbType == DbType.AnsiStringFixedLength) || (parameter.DbType == DbType.Single)) || ((parameter.DbType == DbType.StringFixedLength) || (parameter.DbType == DbType.Xml))))
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
            public System.Data.DbType DbType;
            public string Name;
            public object Parent;
            public bool ReadOnly;
            private object ReturnValue;

            public Field(object parent, string name, string canonicalidentifiername, System.Data.DbType dbtype, bool _readonly)
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
                        ((SQLite.TableBase) this.Parent).Fields.Add(this);
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

            public SQLite.Field this[int Index]
            {
                get
                {
                    if (((this.Count >= 1) && (Index >= 0)) && (Index <= this.Count))
                    {
                        return (SQLite.Field) this.fields[Index];
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
            public DbType Type;
            public object Value;

            public Parameter(string name, DbType type, int size, ParameterDirection direction, object value)
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
            public SQLite.FieldCollection Fields = new SQLite.FieldCollection();
            public string TableName = "";

            public long Delete(string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = SQLite.ExecuteScalar("delete from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + "; select ifnull(changes(), -99999999)", new SQLite.Parameter[0]);
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

            public long Delete(SQLiteConnection conn, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = SQLite.ExecuteScalar(conn, "delete from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + "; select ifnull(changes(), -99999999)", new SQLite.Parameter[0]);
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
                object obj2 = SQLite.ExecuteScalar(ConnectionString, "delete from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + "; select ifnull(changes(), -99999999)", new SQLite.Parameter[0]);
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
                object obj2 = SQLite.ExecuteScalar("select count(*) from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)), new SQLite.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long GetCount(SQLiteConnection conn, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = SQLite.ExecuteScalar(conn, "select count(*) from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)), new SQLite.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long GetCount(string ConnectionString, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = SQLite.ExecuteScalar(ConnectionString, "select count(*) from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)), new SQLite.Parameter[0]);
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
                SQLite.Parameter[] paras = new SQLite.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        str = str + ", ";
                        str2 = str2 + ", ";
                    }
                    str = str + "[" + this.Fields[i].Name + "]";
                    str2 = str2 + "@" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new SQLite.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                object obj2 = SQLite.ExecuteScalar("insert into [" + this.TableName + "] (" + str + ") values (" + str2 + "); select ifnull(last_insert_rowid(), -99999999)", paras);
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

            public long Insert(SQLiteConnection conn)
            {
                if (this.Fields.Count < 1)
                {
                    return -101L;
                }
                string str = "";
                string str2 = "";
                SQLite.Parameter[] paras = new SQLite.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        str = str + ", ";
                        str2 = str2 + ", ";
                    }
                    str = str + "[" + this.Fields[i].Name + "]";
                    str2 = str2 + "@" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new SQLite.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                string commandText = "insert into [" + this.TableName + "] (" + str + ") values (" + str2 + "); select ifnull(last_insert_rowid(), -99999999)";
                object obj2 = SQLite.ExecuteScalar(conn, commandText, paras);
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
                SQLite.Parameter[] paras = new SQLite.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        str = str + ", ";
                        str2 = str2 + ", ";
                    }
                    str = str + "[" + this.Fields[i].Name + "]";
                    str2 = str2 + "@" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new SQLite.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                string commandText = "insert into [" + this.TableName + "] (" + str + ") values (" + str2 + "); select ifnull(last_insert_rowid(), -99999999)";
                object obj2 = SQLite.ExecuteScalar(ConnectionString, commandText, paras);
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
                return SQLite.Select("select " + ((FieldList == "") ? "*" : FieldList) + " from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)), new SQLite.Parameter[0]);
            }

            public DataTable Open(SQLiteConnection conn, string FieldList, string Condition, string Order)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                return SQLite.Select(conn, "select " + ((FieldList == "") ? "*" : FieldList) + " from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)), new SQLite.Parameter[0]);
            }

            public DataTable Open(string ConnectionString, string FieldList, string Condition, string Order)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                return SQLite.Select(ConnectionString, "select " + ((FieldList == "") ? "*" : FieldList) + " from [" + this.TableName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)), new SQLite.Parameter[0]);
            }

            public long Update(string Condition)
            {
                if (this.Fields.Count < 1)
                {
                    return -101L;
                }
                Condition = Condition.Trim();
                string str = "update [" + this.TableName + "] set ";
                SQLite.Parameter[] paras = new SQLite.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        str = str + ", ";
                    }
                    string str2 = str;
                    str = str2 + "[" + this.Fields[i].Name + "] = @" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new SQLite.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                if (!string.IsNullOrEmpty(Condition))
                {
                    str = str + " where " + Condition;
                }
                object obj2 = SQLite.ExecuteScalar(str + "; select ifnull(changes(), -99999999)", paras);
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

            public long Update(SQLiteConnection conn, string Condition)
            {
                if (this.Fields.Count < 1)
                {
                    return -101L;
                }
                Condition = Condition.Trim();
                string commandText = "update [" + this.TableName + "] set ";
                SQLite.Parameter[] paras = new SQLite.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        commandText = commandText + ", ";
                    }
                    string str2 = commandText;
                    commandText = str2 + "[" + this.Fields[i].Name + "] = @" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new SQLite.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                if (!string.IsNullOrEmpty(Condition))
                {
                    commandText = commandText + " where " + Condition;
                }
                commandText = commandText + "; select ifnull(changes(), -99999999)";
                object obj2 = SQLite.ExecuteScalar(conn, commandText, paras);
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
                SQLite.Parameter[] paras = new SQLite.Parameter[this.Fields.Count];
                for (int i = 0; i < this.Fields.Count; i++)
                {
                    if (i > 0)
                    {
                        commandText = commandText + ", ";
                    }
                    string str2 = commandText;
                    commandText = str2 + "[" + this.Fields[i].Name + "] = @" + this.Fields[i].CanonicalIdentifierName;
                    paras[i] = new SQLite.Parameter(this.Fields[i].CanonicalIdentifierName, this.Fields[i].DbType, 0, ParameterDirection.Input, this.Fields[i].Value);
                }
                if (!string.IsNullOrEmpty(Condition))
                {
                    commandText = commandText + " where " + Condition;
                }
                commandText = commandText + "; select ifnull(changes(), -99999999)";
                object obj2 = SQLite.ExecuteScalar(ConnectionString, commandText, paras);
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
                object obj2 = SQLite.ExecuteScalar("select count(*) from [" + this.ViewName + "]" + ((Condition == "") ? "" : (" where " + Condition)), new SQLite.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long GetCount(SQLiteConnection conn, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = SQLite.ExecuteScalar(conn, "select count(*) from [" + this.ViewName + "]" + ((Condition == "") ? "" : (" where " + Condition)), new SQLite.Parameter[0]);
                if (obj2 == null)
                {
                    return 0L;
                }
                return long.Parse(obj2.ToString());
            }

            public long GetCount(string ConnectionString, string Condition)
            {
                Condition = Condition.Trim();
                object obj2 = SQLite.ExecuteScalar(ConnectionString, "select count(*) from [" + this.ViewName + "]" + ((Condition == "") ? "" : (" where " + Condition)), new SQLite.Parameter[0]);
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
                return SQLite.Select("select " + ((FieldList == "") ? "*" : FieldList) + " from [" + this.ViewName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)), new SQLite.Parameter[0]);
            }

            public DataTable Open(SQLiteConnection conn, string FieldList, string Condition, string Order)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                return SQLite.Select(conn, "select " + ((FieldList == "") ? "*" : FieldList) + " from [" + this.ViewName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)), new SQLite.Parameter[0]);
            }

            public DataTable Open(string ConnectionString, string FieldList, string Condition, string Order)
            {
                FieldList = FieldList.Trim();
                Condition = Condition.Trim();
                Order = Order.Trim();
                return SQLite.Select(ConnectionString, "select " + ((FieldList == "") ? "*" : FieldList) + " from [" + this.ViewName + "]" + ((Condition == "") ? "" : (" where " + Condition)) + ((Order == "") ? "" : (" order by " + Order)), new SQLite.Parameter[0]);
            }
        }
    }
}

