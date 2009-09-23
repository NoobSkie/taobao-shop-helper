using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using TOP.Common.DbHelper;
using TOP.Management.Domain;
using TOP.Common.Logic;
using TOP.Management.Facade;
using System.Data;

namespace TOP.Management.Test
{
    [TestClass]
    public class AreaFacadeTest
    {
        private readonly DbSqlCreater dbSqlCreater;
        private readonly string connString;

        public AreaFacadeTest()
        {
            string dbTypeId = ConfigurationManager.AppSettings["DbType"];
            TOP.Common.DbHelper.DbType dbType = (TOP.Common.DbHelper.DbType)short.Parse(dbTypeId);
            dbSqlCreater = DbSqlCreater.GetDbSqlCreater(dbType);

            connString = ConfigurationManager.AppSettings["ConnString"];
        }

        public TestContext TestContext { get; set; }

        #region 初始化数据库

        [TestInitialize()]
        public void DbInitialize()
        {
            string sqlDropTable = dbSqlCreater.GenerateDropTableSql(typeof(Area));
            string sqlCreateTable = dbSqlCreater.GenerateCreateTableSql(typeof(Area));
            using (DbOperator dbOperator = new DbOperator(connString))
            {
                try
                {
                    dbOperator.BeginTran();
                    dbOperator.ExecSql(sqlDropTable);
                    dbOperator.ExecSql(sqlCreateTable);
                    dbOperator.CommintTran();
                }
                catch (Exception ex)
                {
                    dbOperator.RollbackTran();
                    Assert.Fail("初始化数据库错误 - " + ex.Message);
                }
            }
        }

        #endregion

        #region 添加区域

        [TestMethod]
        public void TestAddArea_正确添加区域()
        {
            string id = "c2ecf0ef-dc5b-4308-9f38-037453d53919";

            #region 验证前置条件

            MSSql2005Query query = new MSSql2005Query();
            string sqlQuery = query.GenerateSelectViewSql(typeof(AreaInfo));
            sqlQuery += string.Format("WHERE [Id] = N'{0}'", id);
            using (DbOperator dbOperator = new DbOperator(connString))
            {
                DataTable dt = dbOperator.GetTable(sqlQuery);

                Assert.AreEqual(0, dt.Rows.Count);
            }

            #endregion

            AreaFacade facade = new AreaFacade();
            string idNew = facade.AddArea(id, "401331", AreaType.Province, "重庆市", "", "401331");

            #region 验证后置条件

            Assert.AreEqual("c2ecf0ef-dc5b-4308-9f38-037453d53919", idNew, true);

            using (DbOperator dbOperator = new DbOperator(connString))
            {
                DataTable dt = dbOperator.GetTable(sqlQuery);

                Assert.AreEqual(1, dt.Rows.Count);
                Assert.AreEqual("c2ecf0ef-dc5b-4308-9f38-037453d53919", dt.Rows[0]["Id"].ToString(), true);
                Assert.AreEqual("401331", dt.Rows[0]["AreaId"].ToString(), true);
                Assert.AreEqual("2", dt.Rows[0]["AreaType"].ToString(), true);
                Assert.AreEqual("重庆市", dt.Rows[0]["AreaName"].ToString(), true);
                Assert.AreEqual("", dt.Rows[0]["ParentId"].ToString(), true);
                Assert.AreEqual("401331", dt.Rows[0]["Zip"].ToString(), true);
            }

            #endregion
        }

        #endregion
    }
}
