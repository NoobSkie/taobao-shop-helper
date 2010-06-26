using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace J.SLS.Database.DBAccess
{
    internal class DbEngine
    {
        private DbProviderFactory _factory;
        private string _connString;
        private object _lockobj = new object();

        public DbEngine(DbProviderFactory factory, string connString)
        {
            _factory = factory;
            _connString = connString;
        }

        internal DbConnection CreateConnection()
        {
            DbConnection conn = null;
            lock (_lockobj)
            {
                conn = _factory.CreateConnection();
            }
            OpenDB(conn, _connString);
            return conn;
        }

        private void OpenDB(DbConnection dbConn, string connString)
        {
            try
            {
                dbConn.ConnectionString = connString;
                if (dbConn.State == ConnectionState.Closed)
                {
                    dbConn.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("打开数据库连接失败 - " + connString, ex);
            }
        }

        internal DbCommand CreateCommand()
        {
            lock (_lockobj)
            {
                return _factory.CreateCommand();
            }
        }

        internal DbDataAdapter CreateDataAdapter()
        {
            lock (_lockobj)
            {
                return _factory.CreateDataAdapter();
            }
        }

        internal DbCommandBuilder CreateCommandBuilder()
        {
            lock (_lockobj)
            {
                return _factory.CreateCommandBuilder();
            }
        }

        internal DbParameter CreateParameter()
        {
            lock (_lockobj)
            {
                return _factory.CreateParameter();
            }
        }

        internal void InitDbCommand(DbCommand cmd)
        {
            Util.DoAction(this, (item) =>
            {
                item.InitDbCommand(cmd);
            });
        }

        internal void BeginAction()
        {
            Util.DoAction(this, (item) =>
            {
                item.BeginAction();
            });
        }

        internal void FinishAction()
        {
            Util.DoAction(this, (item) =>
            {
                item.FinishAction();
            });
        }

        internal void BeginTransaction()
        {
            Util.DoAction(this, (item) =>
            {
                item.BeginAction();
                item.BeginTransaction();
            });
        }

        internal void FinishTransaction(bool success)
        {
            Util.DoAction(this, (item) =>
            {
                try
                {
                    item.FinishTransaction(success);
                }
                finally
                {
                    item.FinishAction();
                }
            });
        }

        internal void DoCommand(Action<DbCommand> action)
        {
            Util.DoAction(this, (item) =>
            {
                try
                {
                    item.BeginAction();
                    item.DoCommand(action);
                }
                finally
                {
                    item.FinishAction();
                }
            });
        }

        private class Util
        {
            private DbEngine _db;
            private Util(DbEngine db)
            {
                _db = db;
            }
            private int _ref = 0;
            private DbConnection _conn = null;
            private void DoAction(Action<Util> action)
            {
                action(this);
            }

            public void BeginAction()
            {
                _ref++;
            }

            public void FinishAction()
            {
                _ref--;
                if (_ref == 0)
                {
                    _map.Remove(_db);
                    if (_conn != null)
                    {
                        _conn.Dispose();
                        _conn = null;
                    }
                }
            }

            [ThreadStatic]
            private static Dictionary<DbEngine, Util> _map = null;
            public static void DoAction(DbEngine db, Action<Util> action)
            {
                Util item = null;
                if (_map == null)
                {
                    _map = new Dictionary<DbEngine, Util>();
                    item = new Util(db);
                    _map[db] = item;
                }
                else if (!_map.TryGetValue(db, out item))
                {
                    item = new Util(db);
                    _map[db] = item;
                }
                item.DoAction(action);
            }

            public void DoCommand(Action<DbCommand> action)
            {
                using (DbCommand cmd = _db.CreateCommand())
                {
                    InitDbCommand(cmd);
                    action(cmd);
                }
            }

            public void InitDbCommand(DbCommand cmd)
            {
                if (_conn == null)
                    _conn = _db.CreateConnection();
                cmd.Connection = _conn;
                if (_level > 0)
                {
                    if (_trans == null)
                        _trans = _conn.BeginTransaction();
                    cmd.Transaction = _trans;
                }
            }

            private int _level = 0;
            private DbTransaction _trans = null;
            public void DoTransaction(Action action)
            {
                bool succeed = false;
                try
                {
                    BeginTransaction();
                    action();
                    succeed = true;
                }
                finally
                {
                    FinishTransaction(succeed);
                }
            }

            public void BeginTransaction()
            {
                _level++;
            }

            public void FinishTransaction(bool success)
            {
                _level--;
                if (_level == 0 && _trans != null)
                {
                    try
                    {
                        if (success) { _trans.Commit(); }
                        else { _trans.Rollback(); }
                    }
                    finally
                    {
                        _trans.Dispose();
                        _trans = null;
                    }
                }
            }
        }
    }
}
