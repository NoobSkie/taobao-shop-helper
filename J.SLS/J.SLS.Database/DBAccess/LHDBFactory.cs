using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Drawing;
using LHBIS.Common.Log;
using LHBIS.Common;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;

namespace LHBIS.Database.DBAccess
{
    public static class LHDBFactory
    {
        public static ILHDBTran BeginTransaction(RDatabaseType dbtype, string constr)
        {
            // return null;
            PreconditionAssert.IsFalse(string.IsNullOrEmpty(constr), ErrorMessages.DBConnectionStringIsNullOrEmpty);
            return new LHDBTran(GetLHDBAccess(dbtype, constr));
        }

        /// <summary>
        /// 根据数据库类型，以及数据库连接字符串。
        /// 创建LHDBAccess的对象实例
        /// </summary>
        /// <param name="dbtype">数据库类型</param>
        /// <param name="constr">数据库连接串，不能为null或空串</param>
        /// <returns>LHDBAccess的实例</returns>
        /// <exception cref="RException(RErrorCode.ArgmentesError - 0x00000014)">
        /// 传入数据库连接字符串为null或为空串时(DatabaseErrorCode.ConnectionStringIsEmpty - 0x00010101)
        /// </exception>
        public static ILHDBAccess CreateDBAccessInstance(RDatabaseType dbtype, string constr)
        {
            // 断言连接字符串不为null或空串
            PreconditionAssert.IsFalse(string.IsNullOrEmpty(constr), ErrorMessages.DBConnectionStringIsNullOrEmpty);
            return GetLHDBAccess(dbtype, constr);
        }

        private static LHDBAccess GetLHDBAccess(RDatabaseType dbtype, string constr)
        {
            try
            {
                LHDBAccess accessor;
                switch (dbtype)
                {
                    case RDatabaseType.MSSQL:
                        accessor = new LHDBMSSql(constr);
                        break;
                    case RDatabaseType.Oracle:
                        accessor = new LHDBOracle(constr);
                        break;
                    case RDatabaseType.OLEDB:
                        accessor = new LHDBOleDB(constr);
                        break;
                    case RDatabaseType.ODBC:
                        accessor = new LHDBODBC(constr);
                        break;
                    default:
                        throw new RException(DatabaseErrorCode.NotSupportedDatabaseType, ErrorMessages.NotSupportedDatabaseType + " - " + dbtype.ToString());
                }
                return accessor;
            }
            catch (RException ex)
            {
                switch (ex.ErrorCode)
                {
                    case DatabaseErrorCode.ConnectionStringIsEmpty: // 数据库连接字符串为null或空串
                    case DatabaseErrorCode.NotSupportedDatabaseType:// 数据库类型不支持
                        // 抛出参数错误的异常
                        throw new RException(RErrorCode.ArgmentesError, ErrorMessages.PreconditionAssertFailed, ex);
                    default:
                        // 其他类型封装为  未处理的异常
                        throw new RException(RErrorCode.None, ErrorMessages.NotHandledException + " - " + ex.ErrorCode, ex);
                }
            }
            catch (Exception ex)
            {
                // 未处理的异常
                throw new RException(RErrorCode.None, ErrorMessages.NotHandledException + " - " + ex.GetType().FullName, ex);
            }
        }
    }
}
