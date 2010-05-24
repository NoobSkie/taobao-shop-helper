using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using LHBIS.Common;

namespace LHBIS.Database.DBAccess
{
    /// <summary>
    /// 访问MS SQL的数据库访问对象
    /// </summary>
    [Serializable]
    internal class LHDBMSSql : LHDBAccess
    {
        /// <summary>
        /// 根据数据库连接字符串初始化对象
        /// </summary>
        /// <param name="constr">提供数据库连接字符串，不能为null或空串</param>
        /// <exception cref="RException(DatabaseErrorCode.ConnectionStringIsEmpty - 0x00010101)">
        /// 传入数据库连接字符串为null或为空串时，引发此异常
        /// </exception>
        public LHDBMSSql(string constr)
            : base(constr)
        {
        }

        protected override DbProviderFactory Factory
        {
            get { return SqlClientFactory.Instance; }
        }

        protected override string GetParamPlaceHolder(int paramindex)
        {
            return "@p" + paramindex.ToString();
        }

        protected override RException HandleDbException(DbConnection db, DbException ex, params DbCommand[] cmdList)
        {
            SqlException sqlEx = ex as SqlException;
            string errorMsg;
            switch (sqlEx.Number)
            {
                case 2627:
                    // 主键冲突
                    errorMsg = ErrorMessages.PrimaryKeyConflict + "\n" + DBAccessHelper.GetDbCommandErrorMsg(db, cmdList);
                    return new RException(DatabaseErrorCode.PrimaryKeyConflict, errorMsg, ex);
                case 2601:
                    // 索引冲突
                    errorMsg = ErrorMessages.IndexConflict + "\n" + DBAccessHelper.GetDbCommandErrorMsg(db, cmdList);
                    return new RException(DatabaseErrorCode.IndexConflict, errorMsg, ex);
                default:
                    // 抛出执行SQL命令错误异常
                    errorMsg = "Exec database command error." + "\n" + DBAccessHelper.GetDbCommandErrorMsg(db, cmdList);
                    return new RException(DatabaseErrorCode.ExecDbCommandError, errorMsg, ex);
            }
        }
    }
}
