using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace J.SLS.Database.DBAccess
{
    public class DbAccessException : Exception
    {
        public DbAccessException(string message)
            : base(message)
        {
            ContextDbConnection = null;
            ContextDbCommandList = new List<DbCommand>();
        }

        public DbAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
            ContextDbConnection = null;
            ContextDbCommandList = new List<DbCommand>();
        }

        public DbAccessException(DbConnection dbConnection, string message, Exception innerException, params DbCommand[] cmdList)
            : base(message, innerException)
        {
            ContextDbConnection = dbConnection;
            ContextDbCommandList = new List<DbCommand>();
            if (cmdList != null && cmdList.Length > 0)
            {
                ContextDbCommandList.AddRange(cmdList);
            }
        }

        public DbConnection ContextDbConnection { get; set; }

        public List<DbCommand> ContextDbCommandList { get; set; }

        public override string Message
        {
            get
            {
                StringBuilder errorMsgBuilder = new StringBuilder();
                if (!string.IsNullOrEmpty(base.Message))
                {
                    errorMsgBuilder.AppendLine(base.Message);
                }
                errorMsgBuilder.AppendLine("Connection String: " + (ContextDbConnection == null ? "Null" : ContextDbConnection.ConnectionString));
                foreach (DbCommand cmd in ContextDbCommandList)
                {
                    if (cmd == null) continue;

                    errorMsgBuilder.AppendLine("Type: " + cmd.GetType().FullName);
                    errorMsgBuilder.AppendLine("Command Type: " + cmd.CommandType.ToString());
                    errorMsgBuilder.AppendLine("Command Text: " + cmd.CommandText);
                    if (cmd.Transaction != null)
                    {
                        errorMsgBuilder.AppendLine("Transaction: " + cmd.Transaction.IsolationLevel.ToString());
                    }
                    else
                    {
                        errorMsgBuilder.AppendLine("Transaction: None");
                    }
                    if (cmd.Parameters != null && cmd.Parameters.Count > 0)
                    {
                        errorMsgBuilder.AppendLine("Parameters: " + cmd.Parameters.Count);
                        for (int i = 0; i < cmd.Parameters.Count; i++)
                        {
                            DbParameter p = cmd.Parameters[i];
                            errorMsgBuilder.Append("[" + i + "]" + "");
                            errorMsgBuilder.Append(p.ParameterName);
                            errorMsgBuilder.Append("(" + p.Direction.ToString() + ")");
                            errorMsgBuilder.Append(p.DbType.ToString());
                            errorMsgBuilder.Append("(" + p.Size.ToString() + ")");
                            errorMsgBuilder.AppendLine();
                            errorMsgBuilder.AppendLine("    Value: " + (p.Value == null ? "NULL" : p.Value.ToString()));
                        }
                    }
                    else
                    {
                        errorMsgBuilder.AppendLine("Parameters: None");
                    }
                    errorMsgBuilder.AppendLine();
                }
                return errorMsgBuilder.ToString();
            }
        }
    }
}
