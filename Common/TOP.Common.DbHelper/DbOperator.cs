using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TOP.Common.DbHelper
{
    public class DbOperator : IDisposable
    {
        private string _connString = string.Empty;
        private bool isInTran = false;
        private SqlConnection conn = null;
        private SqlTransaction tran = null;

        public DbOperator(string connString)
        {
            _connString = connString;
        }

        public void BeginTran()
        {
            conn = new SqlConnection(_connString);
            conn.Open();
            tran = conn.BeginTransaction();

            isInTran = true;
        }

        public void CommintTran()
        {
            tran.Commit();
            conn.Close();
        }

        public void RollbackTran()
        {
            tran.Rollback();
            conn.Close();
        }

        public int ExecSql(string sql)
        {
            if (isInTran)
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
            else
            {
                using (conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public DataTable GetTable(string sql)
        {
            DataTable dt = new DataTable();
            using (conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (SqlDataAdapter ada = new SqlDataAdapter(sql, conn))
                {
                    ada.Fill(dt);
                }
                conn.Close();
            }
            return dt;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (tran != null)
            {
                tran.Dispose();
            }
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        #endregion
    }
}
