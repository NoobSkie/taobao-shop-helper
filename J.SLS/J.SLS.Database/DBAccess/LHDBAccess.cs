using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace LHBIS.Database.DBAccess
{
    /// <summary>
    /// 数据库访问的抽象类。
    /// 此类提供对数据库读写的基础函数。
    /// </summary>
    /// <remarks>Craeted by HQ, 2010/3/8</remarks>
    [Serializable]
    internal abstract class LHDBAccess : ILHDBAccess
    {
        internal DbEngine _engine = null;

        /// <summary>
        /// 根据数据库连接字符串初始化对象
        /// </summary>
        /// <param name="dbtype">数据库类型</param>
        /// <param name="constr">提供数据库连接字符串，不能为null或空串</param>
        /// <exception cref="RException(DatabaseErrorCode.ConnectionStringIsEmpty - 0x00010101)">
        /// 传入数据库连接字符串为null或为空串时，引发此异常
        /// </exception>
        protected LHDBAccess(string constr)
        {
            // 断言连接字符串不为null或空串
            PreconditionAssert.IsFalse(string.IsNullOrEmpty(constr), ErrorMessages.DBConnectionStringIsNullOrEmpty);

            _engine = new DbEngine(Factory, constr);
        }

        #region 抽象方法定义

        protected abstract DbProviderFactory Factory { get; }

        /// <summary>
        /// 返回一个参数占位符
        /// </summary>
        /// <param name="paramindex">参数位置</param>
        /// <returns>参数占位符</returns>
        protected abstract string GetParamPlaceHolder(int paramindex);

        protected abstract RException HandleDbException(DbConnection db, DbException ex, params DbCommand[] cmdList);

        #endregion

        #region 接口 IDBAccess 成员

        private int _Timeout = 60;
        /// <summary>
        /// 连接超时间时间，以秒为单位，默认为60。
        /// 如果设置的时间为负数，则自动重置为默认值。
        /// </summary>
        public int ConnectionTimeout
        {
            get { return _Timeout; }
            set
            {
                if (value <= 0) { _Timeout = 60; }
                else { _Timeout = value; }
            }
        }

        private int _CommandTimeout = 60;
        /// <summary>
        /// 命令执行超时时间。以秒为单位，默认为60。
        /// 如果设置的时间为负数，则自动重置为默认值。
        /// </summary>
        public int CommandTimeout
        {
            get { return _CommandTimeout; }
            set
            {
                if (value <= 0) { _CommandTimeout = 60; }
                else { _CommandTimeout = value; }
            }
        }

        /// <summary>
        /// 创建一个DbCommand对象实例，不引发异常
        /// </summary>
        /// <returns>DbCommand对象实例</returns>
        public DbCommand CreateDbCommand()
        {
            DbCommand cmd = _engine.CreateCommand();
            _engine.InitDbCommand(cmd);
            cmd.CommandTimeout = CommandTimeout;
            return cmd;
        }

        /// <summary>
        /// 创建一个DbParameter对象实例，不引发异常
        /// </summary>
        /// <returns>DbParameter对象实例</returns>
        public DbParameter CreateDbParameter()
        {
            return _engine.CreateParameter();
        }

        /// <summary>
        /// 获取对应数据库的对象名称。如对应MS Sql server，输入TableName，则返回[TableName]
        /// </summary>
        /// <param name="objectName">对象名称。可以为表名，字段名</param>
        /// <returns>添加数据库标识以后的数据库安全名称</returns>
        public string GetDbObjectName(string objectName)
        {
            using (DbCommandBuilder cmdBuilder = _engine.CreateCommandBuilder())
            {
                return cmdBuilder.QuotePrefix + objectName + cmdBuilder.QuoteSuffix;
            }
        }

        /// <summary>
        /// 需要在一个事务中执行的方法，action为一个空参数的委托
        /// 只需要传入对应委托，该方法便可以在事务中执行，会抛出需要执行的所有函数的异常
        /// </summary>
        /// <param name="action"></param>
        public void DoTransaction(Action action)
        {
            try
            {
                _engine.BeginAction();
                bool succeed = false;
                try
                {
                    _engine.BeginTransaction();
                    action();
                    succeed = true;
                }
                finally
                {
                    _engine.FinishTransaction(succeed);
                }
            }
            finally
            {
                _engine.FinishAction();
            }
        }

        /// <summary>
        /// 执行一个不返回结果集的SQL语句，并返回受影响的行数。
        /// </summary>
        /// <param name="sqlstr">
        /// 要执行的SQL语句。不允许为null或空串。
        /// 如果是一个带参数的SQL语句，那么此SQL需要是有有效格式化标识的字符串。
        /// 例如：SELECT * FROM [Table] WHERE [Name]={0}
        /// </param>
        /// <param name="values">
        /// SQL语句中参数的值，对应到SQL语句中的参数序号。
        /// 如果提供的SQL不需要参数，则不需要传入此参数。
        /// </param>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常：
        /// 1.传入SQL语句为null或为空串时；
        /// 2.传入的参数列表与SQL语句的参数不匹配时。
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.PrimaryKeyConflict - 0x00010106)">
        /// 主键冲突时引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.IdexConflict - 0x00010107)">
        /// 索引冲突时引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        /// 其他情况导致对数据库操作失败时，会引发此异常
        /// </exception>
        /// <returns>返回受影响的行数</returns>
        public int ExecSQL(string sqlstr, params object[] values)
        {
            ValidateSqlStrAndParams(sqlstr, values);

            int result = 0;
            _engine.DoCommand((cmd) =>
            {
                InitDbCommand(cmd, sqlstr, values);
                result = this.DoExecCommand(cmd);
            });
            return result;
        }

        /// <summary>
        /// 执行DbCommand数据库命令，并返回受影响的行数。
        /// </summary>
        /// <param name="cmd">
        /// 要执行的DbCommand数据库命令。不允许为null。
        /// </param>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常：
        /// 1.传入的数据库命令cmd为null时。
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.PrimaryKeyConflict - 0x00010106)">
        /// 主键冲突时引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.IdexConflict - 0x00010107)">
        /// 索引冲突时引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        /// 其他情况导致对数据库操作失败时，会引发此异常
        /// </exception>
        /// <returns>返回受影响的行数</returns>
        public int ExecCommand(DbCommand cmd)
        {
            PreconditionAssert.IsFalse(cmd == null, ErrorMessages.CommandTextIsNullOrEmpty);

            try
            {
                _engine.BeginAction();
                return this.DoExecCommand(cmd);
            }
            finally
            {
                _engine.FinishAction();
            }
        }

        /// <summary>
        /// 执行SQL语句，并返回查询到的DataTable结果集。
        /// </summary>
        /// <param name="sqlstr">
        /// 要执行的SQL语句。不允许为null或空串。
        /// 如果是一个带参数的SQL语句，那么此SQL需要是有有效格式化标识的字符串。
        /// 例如：SELECT * FROM [Table] WHERE [Name]={0}
        /// </param>
        /// <param name="values">
        /// SQL语句中参数的值，对应到SQL语句中的参数序号。
        /// 如果提供的SQL不需要参数，则不需要传入此参数。
        /// </param>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常：
        /// 1.传入SQL语句为null或为空串时；
        /// 2.传入的参数列表与SQL语句的参数不匹配时。
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        /// 其他情况导致对数据库操作失败时，会引发此异常
        /// </exception>
        /// <returns>返回查询到的DataTable结果集。如果没有查到任何数据，则返回没有数据的DataTable对象。</returns>
        public DataTable GetDataTableBySQL(string sqlstr, params object[] values)
        {
            ValidateSqlStrAndParams(sqlstr, values);

            DataTable result = null;
            _engine.DoCommand((cmd) =>
            {
                InitDbCommand(cmd, sqlstr, values);
                result = this.DoGetDataTableByCommand(cmd);
            });
            return result;
        }

        /// <summary>
        /// 执行DbCommand数据库命令，并返回查询到的DataTable结果集。
        /// </summary>
        /// <param name="cmd">
        /// 要执行的DbCommand数据库命令。不允许为nul。
        /// </param>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常：
        /// 1.传入的数据库命令cmd为null时。
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        /// 其他情况导致对数据库操作失败时，会引发此异常
        /// </exception>
        /// <returns>返回查询到的DataTable结果集。如果没有查到任何数据，则返回没有数据的DataTable对象。</returns>
        public DataTable GetDataTableByCommand(DbCommand cmd)
        {
            PreconditionAssert.IsFalse(cmd == null, ErrorMessages.CommandTextIsNullOrEmpty);

            try
            {
                _engine.BeginAction();
                return this.DoGetDataTableByCommand(cmd);
            }
            finally
            {
                _engine.FinishAction();
            }
        }


        public DataSet GetDataSetBySQL(string sqlstr, params object[] values)
        {
            ValidateSqlStrAndParams(sqlstr, values);

            DataSet result = null;
            _engine.DoCommand((cmd) =>
            {
                InitDbCommand(cmd, sqlstr, values);
                result = this.DoGetDataSetByCommand(cmd);
            });
            return result;
        }

        public DataSet GetDataSetByCommand(DbCommand cmd)
        {
            PreconditionAssert.IsFalse(cmd == null, ErrorMessages.CommandTextIsNullOrEmpty);

            try
            {
                _engine.BeginAction();
                return this.DoGetDataSetByCommand(cmd);
            }
            finally
            {
                _engine.FinishAction();
            }
        }

        /// <summary>
        /// 把DataTable的数据保存到数据库中，仅保存DataTable中变动过的数据
        /// </summary>
        /// <param name="datatb">要保存到数据库的DataTable对象。不能为null，而且必须具有对应到数据库的名称。</param>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常：
        /// 1.传入的DataTable对象为null时；
        /// 2.传入的DataTable对象的TableName属性为null或空串。
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        /// 其他情况导致对数据库操作失败时，会引发此异常
        /// </exception>
        public void SaveDataTable(DataTable datatb)
        {
            PreconditionAssert.IsFalse(datatb == null, ErrorMessages.CommandTextIsNullOrEmpty);
            PreconditionAssert.IsFalse(string.IsNullOrEmpty(datatb.TableName), ErrorMessages.TableNameIsEmpty);

            DoTransaction(() =>
            {
                DoSaveDataTable(datatb);
            });
        }

        /// <summary>
        /// 把DataRow保存到数据库中
        /// 判断DataRow的状态，根据不同的状态，对数据库执行相应的操作
        /// </summary>
        /// <param name="tablename">要保存到的数据库表名称。不允许为null或空串。</param>
        /// <param name="row">要保存到数据库的DataRow对象。不能为null。</param>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常：
        /// 1.传入的DataTable对象为null时；
        /// 2.传入的DataTable对象的TableName属性为null或空串。
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        /// 其他情况导致对数据库操作失败时，会引发此异常
        /// </exception>
        public void SaveDataRow(string tablename, DataRow row)
        {
            PreconditionAssert.IsFalse(row == null, ErrorMessages.CommandTextIsNullOrEmpty);
            PreconditionAssert.IsFalse(string.IsNullOrEmpty(tablename), ErrorMessages.CommandTextIsNullOrEmpty);

            _engine.DoCommand((cmd) =>
            {
                using (DbDataAdapter adapter = _engine.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    using (DbCommandBuilder dbCmdBuilder = _engine.CreateCommandBuilder())
                    {
                        this.DoSaveDataRow(adapter, dbCmdBuilder, tablename, row);
                    }
                }
            });
        }

        /// <summary>
        /// 执行一个返回结果集的sql语句，并返回结果集中第一行第一列的值
        /// </summary>
        /// <param name="sqlstr">
        /// 要执行的SQL语句，不允许为null或空串。
        /// 如果是一个带参数的SQL语句，那么此SQL需要是有有效格式化标识的字符串。
        /// 例如：SELECT * FROM [Table] WHERE [Name]={0}
        /// </param>
        /// <param name="values">
        /// SQL语句中参数的值，对应到SQL语句中的参数序号。
        /// 如果提供的SQL不需要参数，则不需要传入此参数。
        /// </param>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 以下几种情况会引发该异常：
        /// 1.传入SQL语句为null或为空串时；
        /// 2.传入的参数列表与SQL语句的参数不匹配时。
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ConnectDbServerError - 0x00010001)">
        /// 数据库连接失败时引发此异常
        /// </exception>
        /// <exception cref="RException(DatabaseErrorCode.ExecDbCommandError - 0x00010002)">
        /// 其他情况导致对数据库操作失败时，会引发此异常
        /// </exception>
        /// <returns>结果集中第一行第一列的值。如果查询结果集中没有数据，则返回null</returns>
        public object GetRC1BySQL(string sqlstr, params object[] values)
        {
            ValidateSqlStrAndParams(sqlstr, values);

            object value = null;
            _engine.DoCommand((cmd) =>
            {
                InitDbCommand(cmd, sqlstr, values);
                value = DoGetRC1Value(cmd);
            });
            return value;
        }

        public object GetRC1ByCommand(DbCommand cmd)
        {
            PreconditionAssert.IsFalse(cmd == null, ErrorMessages.CommandTextIsNullOrEmpty);

            try
            {
                _engine.BeginAction();
                return this.DoGetRC1Value(cmd);
            }
            finally
            {
                _engine.FinishAction();
            }
        }

        #endregion

        #region 内部 Do Command 函数

        private int DoExecCommand(DbCommand cmd)
        {
            try
            {
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (DbException ex)
            {
                throw HandleDbException(cmd.Connection, ex, cmd);
            }
            catch (Exception ex)
            {
                string errorMsg = "Exec database command error." + "\r\n" + DBAccessHelper.GetDbCommandErrorMsg(cmd.Connection, cmd);
                throw new RException(DatabaseErrorCode.ExecDbCommandError, errorMsg, ex);
            }
        }

        private DataTable DoGetDataTableByCommand(DbCommand cmd)
        {
            using (DbDataAdapter adp = _engine.CreateDataAdapter())
            {
                try
                {
                    adp.SelectCommand = cmd;

                    DataTable tb = new DataTable();
                    //adp.FillSchema(tb, SchemaType.Source);
                    adp.Fill(tb);
                    return tb;
                }
                catch (Exception ex)
                {
                    string errorMsg = "Get DataTable by command error." + "\r\n" + DBAccessHelper.GetDbCommandErrorMsg(cmd.Connection, cmd);
                    throw new RException(DatabaseErrorCode.ExecDbCommandError, errorMsg, ex);
                }
            }
        }

        private DataSet DoGetDataSetByCommand(DbCommand cmd)
        {
            using (DbDataAdapter adp = _engine.CreateDataAdapter())
            {
                try
                {
                    adp.SelectCommand = cmd;

                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    string errorMsg = "Get DataTable by command error." + "\r\n" + DBAccessHelper.GetDbCommandErrorMsg(cmd.Connection, cmd);
                    throw new RException(DatabaseErrorCode.ExecDbCommandError, errorMsg, ex);
                }
            }
        }

        private object DoGetRC1Value(DbCommand cmd)
        {
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (DbException ex)
            {
                throw HandleDbException(cmd.Connection, ex, cmd);
            }
            catch (Exception e)
            {
                string errorMsg = "Get RC1 value error." + "\r\n" + DBAccessHelper.GetDbCommandErrorMsg(cmd.Connection, cmd);
                throw new RException(DatabaseErrorCode.ExecDbCommandError, errorMsg, e);
            }
        }

        private void DoSaveDataTable(DataTable dataTable)
        {
            if (dataTable == null || dataTable.GetChanges() == null) { return; }

            DataTable dtChanges = dataTable.GetChanges();
            if (dtChanges == null || dtChanges.Rows.Count == 0) { return; }

            _engine.DoCommand((cmd) =>
            {
                using (DbDataAdapter adap = _engine.CreateDataAdapter())
                {
                    using (DbCommandBuilder dbCmdBuilder = _engine.CreateCommandBuilder())
                    {
                        try
                        {
                            dbCmdBuilder.ConflictOption = ConflictOption.OverwriteChanges;
                            dbCmdBuilder.DataAdapter = adap;

                            adap.SelectCommand = cmd;
                            adap.SelectCommand.CommandText = string.Format("SELECT TOP 1 * FROM [{0}]", dataTable.TableName);
                            adap.Update(dtChanges);
                            dataTable.AcceptChanges();
                        }
                        catch (DbException ex)
                        {
                            throw HandleDbException(adap.SelectCommand.Connection, ex, adap.SelectCommand, adap.InsertCommand, adap.UpdateCommand, adap.DeleteCommand);
                        }
                        catch (RException re)
                        {
                            throw re;
                        }
                        catch (Exception ex)
                        {
                            throw new RException(DatabaseErrorCode.ExecDbCommandError, "Exec DbCommand Error.", ex);
                        }
                    }
                }
            });
        }

        private void DoSaveDataRow(DbDataAdapter adap, DbCommandBuilder dbCmdBuilder, string tablename, DataRow row)
        {
            if (row == null
                || row.RowState == DataRowState.Unchanged
                || row.RowState == DataRowState.Detached)
            {
                return;
            }
            try
            {
                dbCmdBuilder.ConflictOption = ConflictOption.OverwriteChanges;
                dbCmdBuilder.DataAdapter = adap;

                adap.SelectCommand.CommandText = string.Format("SELECT TOP 1 * FROM [{0}]", tablename);
                adap.Update(new DataRow[] { row });
            }
            catch (DbException ex)
            {
                throw HandleDbException(adap.SelectCommand.Connection, ex, adap.SelectCommand, adap.InsertCommand, adap.UpdateCommand, adap.DeleteCommand);
            }
            catch (RException re)
            {
                throw re;
            }
            catch (Exception ex)
            {
                throw new RException(DatabaseErrorCode.ExecDbCommandError, "Exec DbCommand Error.", ex);
            }
        }

        #endregion

        #region 辅助性内部函数

        /// <summary>
        /// 获取参数名称
        /// </summary>
        private string GetParamName(int paramindex)
        {
            return GetParamPlaceHolder(paramindex);
        }

        private void ValidateSqlStrAndParams(string str, params object[] values)
        {
            // 断言传入SQL语句为null或不为空串
            PreconditionAssert.IsFalse(string.IsNullOrEmpty(str), ErrorMessages.CommandTextIsNullOrEmpty);
            // 断言传入的SQL参数与提供的参数值列表匹配
            string sqlDetail = ErrorMessages.SqlParameterNotMatchValues + "\n" + DBAccessHelper.GetFormatErrorMsg(str, values);
            PreconditionAssert.CanFormatString(str, values, sqlDetail);
        }

        private void InitDbCommand(DbCommand cmd, string formatedSql, object[] values)
        {
            cmd.CommandTimeout = CommandTimeout;

            string[] parameters = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                parameters[i] = GetParamPlaceHolder(i);

                DbParameter p = CreateDbParameter();
                p.ParameterName = GetParamName(i);
                p.Value = values[i] ?? DBNull.Value;
                cmd.Parameters.Add(p);
            }
            cmd.CommandText = string.Format(formatedSql, parameters);
        }

        #endregion
    }
}
