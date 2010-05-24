using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using J.SLS.Common;

namespace J.SLS.Database.DBAccess
{
    [Serializable]
    internal class LHDBTran : ILHDBTran
    {
        private LHDBAccess _Owner = null;

        protected internal LHDBTran(LHDBAccess owner)
        {
            _Owner = owner;
            _Owner._engine.BeginTransaction();
        }

        #region 接口 IDisposable 成员

        private bool _commited = false;
        private bool _disposed = false;
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (_disposed) { return; }
            if (!_commited) { Rollback(); }

            _disposed = true;
            GC.SuppressFinalize(this);
        }

        #endregion

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <exception cref="RException(DatabaseErrorCode.CommitTransactionError - 0x00010108)">
        /// 提交事务失败时引发该异常
        /// </exception>
        public void Commit()
        {
            CheckCommit();
            try
            {
                _Owner._engine.FinishTransaction(true);
            }
            finally
            {
                _commited = true;
            }
        }

        /// <summary>
        /// 事务回滚,不会产生异常
        /// </summary>
        public void Rollback()
        {
            CheckCommit();
            _Owner._engine.FinishTransaction(false);
            _commited = true;
        }

        /// <summary>
        /// 创建DbCommand对象实例，不引发异常
        /// </summary>
        /// <returns>DbCommand对象实例</returns>
        public DbCommand CreateDbCommand()
        {
            CheckCommit();
            return _Owner.CreateDbCommand();
        }

        /// <summary>
        /// 创建一个DbParameter对象实例，不引发异常
        /// </summary>
        /// <returns>DbParameter对象实例</returns>
        public DbParameter CreateDbParameter()
        {
            CheckCommit();
            return _Owner.CreateDbParameter();
        }

        /// <summary>
        /// 在事务中执行DbCommand数据库命令，并返回受影响的行数
        /// </summary>
        /// <param name="cmd">要执行的DbCommand数据库命令，参数的数据库命令cmd不允许为null</param>
        /// <returns>返回受影响的行数</returns>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        ///  其他情况导致对数据库操作失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.IdexConflict - 0x00010107)">
        ///  索引冲突时会引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.PrimaryKeyConflict - 0x00010106)">
        ///  主键冲突时会引发此异常
        /// </exception>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 传入的数据库命令cmd为null时。
        /// </exception>
        /// 前置条件
        /// 传入的cmd参数不能为null
        public int ExecCommand(DbCommand cmd)
        {
            CheckCommit();
            return _Owner.ExecCommand(cmd);
        }

        /// <summary>
        /// 在事务中执行一个不返回结果集的SQL语句,并返回受影响的行数
        /// </summary>
        /// <param name="sqlstr">要执行的SQL语句,参数sqlstr不允许为null或空串,传入的sqlstr语句必须与参数列表匹配。
        /// 如果是一个带参数的SQL语句,那么此SQL需要是有有效格式化标识的字符串。
        /// 例如#xx3ASELECT * FROM [Table] WHERE [Name]={0}</param>
        /// <param name="values">SQL语句中参数的值,对应到SQL语句中的参数序号。
        /// 如果提供的SQL不需要参数,则不需要传入此参数。</param>
        /// <returns>返回受影响的行数</returns>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        ///  其他情况导致对数据库操作失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.IdexConflict - 0x00010107)">
        ///  索引冲突时会引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.PrimaryKeyConflict - 0x00010106)">
        ///  主键冲突时会引发此异常
        /// </exception>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常
        /// 1.传入SQL语句为null或为空串时;
        /// 2.传入的参数列表与SQL语句的参数不匹配时。
        /// </exception>
        /// 前置条件
        /// 传入的参数sqlstr不允许为空
        /// 传入的参数values与sql语句的参数要匹配，如果sql语句中不带参数，此参数可以不填
        public int ExecSQL(string sqlstr, params object[] values)
        {
            CheckCommit();
            return _Owner.ExecSQL(sqlstr, values);
        }

        /// <summary>
        /// 在事务中执行SQL语句,并返回查询到的DataTable结果集
        /// </summary>
        /// <param name="sqlstr">要执行的SQL语句,参数sqlstr不允许为null或空串,传入的sqlstr语句必须与参数列表匹配。
        /// 如果是一个带参数的SQL语句,那么此SQL需要是有有效格式化标识的字符串。
        /// 例如#xx3ASELECT * FROM [Table] WHERE [Name]={0}</param>
        /// <param name="values">SQL语句中参数的值,对应到SQL语句中的参数序号。
        /// 如果提供的SQL不需要参数,则不需要传入此参数</param>
        /// <returns>返回查询到的DataTable结果集。如果没有查到任何数据,则返回没有数据的DataTable对象</returns>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        ///  其他情况导致对数据库操作失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常
        /// 1.传入SQL语句为null或为空串时;
        /// 2.传入的参数列表与SQL语句的参数不匹配时。
        /// </exception>
        /// 前置条件
        /// 传入的参数sqlstr不允许为空
        /// 传入的参数values与sql语句的参数要匹配,如果sql语句中不带参数，此参数可以不填
        public DataTable GetDataTableBySQL(string sqlstr, params object[] values)
        {
            CheckCommit();
            return _Owner.GetDataTableBySQL(sqlstr, values);
        }

        /// <summary>
        /// 在事务中执行一个返回结果集的sql语句,并返回结果集中第一行第一列的值
        /// </summary>
        /// <param name="sqlstr">要执行的SQL语句,不允许为null或空串如果是一个带参数的SQL语句,
        /// 那么此SQL需要是有有效格式化标识的字符串。
        /// 例如#xx3ASELECT * FROM [Table] WHERE [Name]={0}</param>
        /// <param name="values">SQL语句中参数的值,对应到SQL语句中的参数序号。
        /// 如果提供的SQL不需要参数,则不需要传入此参数。</param>
        /// <returns>结果集中第一行第一列的值。如果查询结果集中没有数据,则返回null</returns>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        ///  其他情况导致对数据库操作失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常
        /// 1.传入SQL语句为null或为空串时;
        /// 2.传入的参数列表与SQL语句的参数不匹配时。
        /// </exception>
        /// 前置条件
        /// 传入的参数sqlstr不允许为空
        /// 传入的参数values与sql语句的参数要匹配，如果sql语句中不带参数，此参数可以不填
        public object GetRC1BySQL(string sqlstr, params object[] values)
        {
            CheckCommit();
            return _Owner.GetRC1BySQL(sqlstr, values);
        }

        public object GetRC1ByCommand(DbCommand cmd)
        {
            CheckCommit();
            return _Owner.GetRC1ByCommand(cmd);
        }

        /// <summary>
        /// 在事务中把DataTable的数据保存到数据库中,仅保存DataTable中变动过的数据
        /// </summary>
        /// <param name="datatb">要保存到数据库的DataTable对象。不能为null,而且必须具有对应到数据库的名称</param>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        ///  其他情况导致对数据库操作失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常
        /// 1.传入的DataTable对象为null时;
        /// 2.传入的DataTable对象的TableName属性为null或空串。。
        /// </exception>
        /// 前置条件
        /// 1.传入的DataTable对象不能为null;
        /// 2.传入的DataTable对象的TableName属性不能为null或空串
        public void SaveDataTable(DataTable datatb)
        {
            CheckCommit();
            _Owner.SaveDataTable(datatb);
        }

        /// <summary>
        /// 在事务中把DataRow保存到数据库中
        /// </summary>
        /// <param name="tablename">要保存到的数据库表名称。不允许为null或空串</param>
        /// <param name="row">要保存到数据库的DataRow对象。不能为null</param>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        ///  其他情况导致对数据库操作失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// </exception>
        /// 前置条件
        /// 1.传入的DataRow对象不能为null
        public void SaveDataRow(string tablename, DataRow row)
        {
            CheckCommit();
            _Owner.SaveDataRow(tablename, row);
        }

        /// <summary>
        /// 获取对应数据库的对象名称。如对应MS Sql server，输入TableName，则返回[TableName]
        /// </summary>
        /// <param name="objectName">对象名称。可以为表名，字段名</param>
        /// <returns>添加数据库标识以后的数据库安全名称</returns>
        public string GetDbObjectName(string objectName)
        {
            CheckCommit();
            return _Owner.GetDbObjectName(objectName);
        }

        /// <summary>
        /// 连接超时间时间，以秒为单位，默认为60。
        /// 如果设置的时间为负数，则自动重置为默认值。
        /// </summary>
        public int ConnectionTimeout
        {
            get { return _Owner.ConnectionTimeout; }
            set { _Owner.ConnectionTimeout = value; }
        }

        /// <summary>
        /// 命令执行超时时间。以秒为单位，默认为60。
        /// 如果设置的时间为负数，则自动重置为默认值。
        /// </summary>
        public int CommandTimeout
        {
            get { return _Owner.CommandTimeout; }
            set { _Owner.CommandTimeout = value; }
        }

        /// <summary>
        /// 在事务中执行DbCommand数据库命令,并返回查询到的DataTable结果集
        /// </summary>
        /// <param name="cmd">要执行的DbCommand数据库命令,不允许为null。</param>
        /// <returns>返回查询到的DataTable结果集。如果没有查到任何数据,则返回没有数据的DataTable对象</returns>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        ///  其他情况导致对数据库操作失败时会引发此异常
        /// </exception>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 传入的数据库命令cmd为null时
        /// 前置条件
        /// 传入的参数不允许为空
        public DataTable GetDataTableByCommand(DbCommand cmd)
        {
            CheckCommit();
            return _Owner.GetDataTableByCommand(cmd);
        }

        public DataSet GetDataSetByCommand(DbCommand cmd)
        {
            CheckCommit();
            return _Owner.GetDataSetByCommand(cmd);
        }

        public DataSet GetDataSetBySQL(string sqlstr, params object[] values)
        {
            CheckCommit();
            return _Owner.GetDataSetBySQL(sqlstr, values);
        }

        private void CheckCommit()
        {
            if (_commited == true)
            {
                throw new DbAccessException(ErrorMessages.TransactionCommited);
            }
        }
    }
}
