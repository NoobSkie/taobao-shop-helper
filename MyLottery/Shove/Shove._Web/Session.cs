namespace Shove._Web
{
    using Shove.Database;
    using System;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Web;
    using System.Web.SessionState;

    public class Session
    {
        public static void ClearSession(string Key)
        {
            ClearSession(HttpContext.Current, Key);
        }

        public static void ClearSession(HttpContext context, string Key)
        {
            Key = "" + Key;
            context.Session.Remove(Key);
        }

        public static object GetSession(string Key)
        {
            return GetSession(HttpContext.Current, Key);
        }

        public static object GetSession(HttpContext context, string Key)
        {
            Key = "" + Key;
            return context.Session[Key];
        }

        public static bool GetSessionAsBoolean(string Key, bool Default)
        {
            return GetSessionAsBoolean(HttpContext.Current, Key, Default);
        }

        public static bool GetSessionAsBoolean(HttpContext context, string Key, bool Default)
        {
            object session = GetSession(context, Key);
            try
            {
                return Convert.ToBoolean(session);
            }
            catch
            {
                return Default;
            }
        }

        public static DataSet GetSessionAsDataSet(string Key)
        {
            return GetSessionAsDataSet(HttpContext.Current, Key);
        }

        public static DataSet GetSessionAsDataSet(HttpContext context, string Key)
        {
            object session = GetSession(context, Key);
            try
            {
                return (DataSet) session;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetSessionAsDataTable(string Key)
        {
            return GetSessionAsDataTable(HttpContext.Current, Key);
        }

        public static DataTable GetSessionAsDataTable(HttpContext context, string Key)
        {
            object session = GetSession(context, Key);
            try
            {
                return (DataTable) session;
            }
            catch
            {
                return null;
            }
        }

        public static int GetSessionAsInt(string Key, int Default)
        {
            return GetSessionAsInt(HttpContext.Current, Key, Default);
        }

        public static int GetSessionAsInt(HttpContext context, string Key, int Default)
        {
            object session = GetSession(context, Key);
            try
            {
                return Convert.ToInt32(session);
            }
            catch
            {
                return Default;
            }
        }

        public static long GetSessionAsLong(string Key, long Default)
        {
            return GetSessionAsLong(HttpContext.Current, Key, Default);
        }

        public static long GetSessionAsLong(HttpContext context, string Key, long Default)
        {
            object session = GetSession(context, Key);
            try
            {
                return Convert.ToInt64(session);
            }
            catch
            {
                return Default;
            }
        }

        public static string GetSessionAsString(string Key, string Default)
        {
            return GetSessionAsString(HttpContext.Current, Key, Default);
        }

        public static string GetSessionAsString(HttpContext context, string Key, string Default)
        {
            object session = GetSession(context, Key);
            try
            {
                return session.ToString();
            }
            catch
            {
                return Default;
            }
        }

        public static void SetSession(string Key, object Value)
        {
            SetSession(HttpContext.Current, Key, Value);
        }

        public static void SetSession(HttpContext context, string Key, object Value)
        {
            Key = "" + Key;
            context.Session.Remove(Key);
            context.Session.Add(Key, Value);
        }

        public class SQLServerSession
        {
            private int nt2YWlTkO = 720;
            private string TKThXs85j = "";
            private string W9Trg5rgK = "";

            public SQLServerSession(string _ConnectionString, string _SessionID, int _TimeOut)
            {
                this.TKThXs85j = _ConnectionString;
                this.W9Trg5rgK = _SessionID.ToLower();
                this.nt2YWlTkO = _TimeOut;
            }

            public object this[string Key]
            {
                get
                {
                    DataTable table = MSSQL.Select(this.TKThXs85j, "select top 1 * from ASPStateTempSessions where substring(SessionId, 1, 24) = @SessionId", new MSSQL.Parameter[] { new MSSQL.Parameter("SessionId", SqlDbType.VarChar, 0, ParameterDirection.Input, this.W9Trg5rgK) });
                    if ((table == null) || (table.Rows.Count < 1))
                    {
                        return null;
                    }
                    MemoryStream input = new MemoryStream();
                    BinaryReader reader = new BinaryReader(input);
                    byte[] buffer = (byte[]) table.Rows[0]["SessionItemShort"];
                    input.SetLength(0L);
                    input.Write(buffer, 0, buffer.Length);
                    input.Seek(0L, SeekOrigin.Begin);
                    reader.ReadInt32();
                    bool flag = reader.ReadBoolean();
                    reader.ReadBoolean();
                    if (!flag)
                    {
                        return null;
                    }
                    return SessionStateItemCollection.Deserialize(reader)[Key];
                }
                set
                {
                    DataTable table = MSSQL.Select(this.TKThXs85j, "select top 1 * from ASPStateTempSessions where substring(SessionId, 1, 24) = @SessionId", new MSSQL.Parameter[] { new MSSQL.Parameter("SessionId", SqlDbType.VarChar, 0, ParameterDirection.Input, this.W9Trg5rgK) });
                    if (table == null)
                    {
                        throw new Exception("写入 Session 发生错误：读取数据库发生错误！");
                    }
                    byte[] buffer = null;
                    SessionStateItemCollection items = null;
                    int num = 720;
                    bool flag = true;
                    bool flag2 = false;
                    if (table.Rows.Count < 1)
                    {
                        items = new SessionStateItemCollection();
                        items[Key] = value;
                    }
                    else
                    {
                        MemoryStream input = new MemoryStream();
                        BinaryReader reader = new BinaryReader(input);
                        buffer = (byte[]) table.Rows[0]["SessionItemShort"];
                        input.SetLength(0L);
                        input.Write(buffer, 0, buffer.Length);
                        input.Seek(0L, SeekOrigin.Begin);
                        num = reader.ReadInt32();
                        flag = reader.ReadBoolean();
                        flag2 = reader.ReadBoolean();
                        items = SessionStateItemCollection.Deserialize(reader);
                        items[Key] = value;
                    }
                    MemoryStream output = new MemoryStream();
                    BinaryWriter writer = new BinaryWriter(output);
                    output.SetLength(0L);
                    writer.Write(num);
                    writer.Write(flag);
                    writer.Write(flag2);
                    items.Serialize(writer);
                    writer.Write((byte) 0xff);
                    byte[] buffer2 = output.ToArray();
                    if (table.Rows.Count < 1)
                    {
                        MSSQL.ExecuteNonQuery(this.TKThXs85j, "insert into ASPStateTempSessions (SessionId, Created, Expires, LockDate, LockDateLocal, LockCookie, Timeout, Locked, SessionItemShort) values (@SessionId, @Created, @Expires, @LockDate, @LockDateLocal, @LockCookie, @Timeout, @Locked, @SessionItemShort)", new MSSQL.Parameter[] { new MSSQL.Parameter("SessionId", SqlDbType.VarChar, 0, ParameterDirection.Input, this.W9Trg5rgK), new MSSQL.Parameter("Created", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now), new MSSQL.Parameter("Expires", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now.AddMinutes((double) this.nt2YWlTkO)), new MSSQL.Parameter("LockDate", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now), new MSSQL.Parameter("LockDateLocal", SqlDbType.DateTime, 0, ParameterDirection.Input, DateTime.Now), new MSSQL.Parameter("LockCookie", SqlDbType.Int, 0, ParameterDirection.Input, 0), new MSSQL.Parameter("Timeout", SqlDbType.Int, 0, ParameterDirection.Input, this.nt2YWlTkO), new MSSQL.Parameter("Locked", SqlDbType.Bit, 0, ParameterDirection.Input, false), new MSSQL.Parameter("SessionItemShort", SqlDbType.Image, 0, ParameterDirection.Input, buffer2) });
                    }
                    else
                    {
                        MSSQL.ExecuteNonQuery(this.TKThXs85j, "update ASPStateTempSessions set SessionItemShort = @SessionItemShort where substring(SessionId, 1, 24) = @SessionId", new MSSQL.Parameter[] { new MSSQL.Parameter("SessionItemShort", SqlDbType.Image, 0, ParameterDirection.Input, buffer2), new MSSQL.Parameter("SessionId", SqlDbType.VarChar, 0, ParameterDirection.Input, this.W9Trg5rgK) });
                    }
                }
            }
        }
    }
}

