using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using J.SLS.Common;

namespace J.SLS.Database.DBAccess
{
    [Serializable]
    internal abstract class LHDBAccess : ILHDBAccess
    {
        internal DbEngine _engine = null;

        protected LHDBAccess(string constr)
        {
            PreconditionAssert.IsNotNullOrEmpty(constr, ErrorMessages.DBConnectionStringIsNullOrEmpty);

            _engine = new DbEngine(Factory, constr);
        }

        protected abstract DbProviderFactory Factory { get; }

        protected abstract string GetParamPlaceHolder(int paramindex);

        private int _Timeout = 60;
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
        public int CommandTimeout
        {
            get { return _CommandTimeout; }
            set
            {
                if (value <= 0) { _CommandTimeout = 60; }
                else { _CommandTimeout = value; }
            }
        }

        public DbCommand CreateDbCommand()
        {
            DbCommand cmd = _engine.CreateCommand();
            _engine.InitDbCommand(cmd);
            cmd.CommandTimeout = CommandTimeout;
            return cmd;
        }

        public DbParameter CreateDbParameter()
        {
            return _engine.CreateParameter();
        }

        public string GetDbObjectName(string objectName)
        {
            using (DbCommandBuilder cmdBuilder = _engine.CreateCommandBuilder())
            {
                return cmdBuilder.QuotePrefix + objectName + cmdBuilder.QuoteSuffix;
            }
        }

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

        public DataTable GetDataTableByCommand(DbCommand cmd)
        {
            PreconditionAssert.IsNotNull(cmd, ErrorMessages.CommandTextIsNullOrEmpty);

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
            PreconditionAssert.IsNotNull(cmd, ErrorMessages.CommandTextIsNullOrEmpty);

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

        public void SaveDataTable(DataTable datatb)
        {
            PreconditionAssert.IsNotNull(datatb, ErrorMessages.CommandTextIsNullOrEmpty);
            PreconditionAssert.IsNotNullOrEmpty(datatb.TableName, ErrorMessages.TableNameIsEmpty);

            DoTransaction(() =>
            {
                DoSaveDataTable(datatb);
            });
        }

        public void SaveDataRow(string tablename, DataRow row)
        {
            PreconditionAssert.IsNotNull(row, ErrorMessages.CommandTextIsNullOrEmpty);
            PreconditionAssert.IsNotNullOrEmpty(tablename, ErrorMessages.CommandTextIsNullOrEmpty);

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
            PreconditionAssert.IsNotNull(cmd, ErrorMessages.CommandTextIsNullOrEmpty);

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

        private int DoExecCommand(DbCommand cmd)
        {
            try
            {
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                throw new DbAccessException(cmd.Connection, "Exec database command error.", ex, cmd);
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
                    adp.Fill(tb);
                    return tb;
                }
                catch (Exception ex)
                {
                    throw new DbAccessException(cmd.Connection, "Get DataTable by command error.", ex, cmd);
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
                    throw new DbAccessException(cmd.Connection, "Get DataSet by command error.", ex, cmd);
                }
            }
        }

        private object DoGetRC1Value(DbCommand cmd)
        {
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new DbAccessException(cmd.Connection, "Get RC1 by command error.", ex, cmd);
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
                        catch (Exception ex)
                        {
                            throw new DbAccessException(cmd.Connection, "Save DataTable error.", ex, adap.SelectCommand, adap.InsertCommand, adap.UpdateCommand, adap.DeleteCommand);
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
            catch (Exception ex)
            {
                throw new DbAccessException(adap.SelectCommand.Connection, "Save DataRow error.", ex, adap.SelectCommand, adap.InsertCommand, adap.UpdateCommand, adap.DeleteCommand);
            }
        }

        private string GetParamName(int paramindex)
        {
            return GetParamPlaceHolder(paramindex);
        }

        private void ValidateSqlStrAndParams(string sqlString, params object[] values)
        {
            PreconditionAssert.IsNotNullOrEmpty(sqlString, ErrorMessages.CommandTextIsNullOrEmpty);
            try
            {
                string.Format(sqlString, values);
            }
            catch (Exception ex)
            {
                throw new SqlParameterNotMatchException(sqlString, "Validate sql string and params match failed.", ex, values);
            }
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
    }
}
