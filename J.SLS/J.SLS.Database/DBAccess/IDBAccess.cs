using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace J.SLS.Database.DBAccess
{
    /// <summary>
    /// 数据库连接类型枚举
    /// </summary>
    public enum RDatabaseType
    {
        MSSQL,
        OleDB,
    }

    /// <summary>
    /// 数据库访问接口
    /// </summary>
    public interface IDBAccess
    {
        string GetDbObjectName(string objectName);

        int ConnectionTimeout { get; set; }

        int CommandTimeout { get; set; }

        DbCommand CreateDbCommand();

        DbParameter CreateDbParameter();

        int ExecCommand(DbCommand cmd);

        int ExecSQL(string sqlstr, params object[] values);

        DataTable GetDataTableBySQL(string sqlstr, params object[] values);

        DataTable GetDataTableByCommand(DbCommand cmd);

        DataSet GetDataSetByCommand(DbCommand cmd);

        DataSet GetDataSetBySQL(string sqlstr, params object[] values);

        void SaveDataTable(DataTable datatb);

        void SaveDataRow(string tablename, DataRow row);

        object GetRC1BySQL(string sqlstr, params object[] values);

        object GetRC1ByCommand(DbCommand cmd);
    }

    public interface ILHDBAccess : IDBAccess
    {
        void DoTransaction(Action action);
    }

    public interface ILHDBTran : IDBAccess, IDisposable
    {
        void Commit();

        void Rollback();
    }
}
