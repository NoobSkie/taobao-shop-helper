using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOP.Management.Domain;
using TOP.Common.DbHelper;
using System.Configuration;
using TOP.Management.Facade;
using TOP.Common.Logic;
using System.Data;

namespace TOP.Management.Test
{
    [TestClass]
    public class ItemCategoryFacadeTest : DbUnitTestBase
    {
        private readonly DbSqlCreater dbSqlCreater;
        private readonly string connString;

        public ItemCategoryFacadeTest()
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
            string sqlDropTable = dbSqlCreater.GenerateDropTableSql(typeof(ItemCategory));
            string sqlCreateTable = dbSqlCreater.GenerateCreateTableSql(typeof(ItemCategory));
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

        #region 测试添加类目

        [TestMethod]
        public void TestAddItemCategory_正确添加()
        {
            string id = "c2ecf0ef-dc5b-4308-9f38-047453d53919";

            #region 验证前置条件

            MSSql2005Query query = new MSSql2005Query();
            string sqlQuery = query.GenerateSelectViewSql(typeof(ItemCategoryInfo));
            sqlQuery += string.Format("WHERE [Id] = N'{0}'", id);
            using (DbOperator dbOperator = new DbOperator(connString))
            {
                DataTable dt = dbOperator.GetTable(sqlQuery);

                Assert.AreEqual(0, dt.Rows.Count);
            }

            #endregion

            ItemCategoryFacade facade = new ItemCategoryFacade();
            string idNew = facade.AddItemCategory(id, "50011665", "0", "网游装备/游戏币/帐号/代练", false, "normal", 0);

            #region 验证后置条件

            Assert.AreEqual("c2ecf0ef-dc5b-4308-9f38-047453d53919", idNew, true);

            using (DbOperator dbOperator = new DbOperator(connString))
            {
                DataTable dt = dbOperator.GetTable(sqlQuery);

                Assert.AreEqual(1, dt.Rows.Count);
                Assert.AreEqual("c2ecf0ef-dc5b-4308-9f38-047453d53919", dt.Rows[0]["Id"].ToString(), true);
                Assert.AreEqual("50011665", dt.Rows[0]["CategoryId"].ToString(), true);
                Assert.AreEqual("0", dt.Rows[0]["ParentId"].ToString(), true);
                Assert.AreEqual("网游装备/游戏币/帐号/代练", dt.Rows[0]["Name"].ToString(), true);
                Assert.AreEqual("false", dt.Rows[0]["IsParent"].ToString(), true);
                Assert.AreEqual("normal", dt.Rows[0]["Status"].ToString(), true);
                Assert.AreEqual("0", dt.Rows[0]["SortOrder"].ToString(), true);
            }

            #endregion
        }

        #endregion

        #region 检查类目是否已经存在

        [TestMethod]
        public void TestIsItemCategoryExist_不存在的情况()
        {
            ItemCategoryFacade facade = new ItemCategoryFacade();
            bool isExist = facade.IsItemCategoryExist("50011665");

            Assert.AreEqual(false, isExist);
        }

        [TestMethod]
        public void TestIsItemCategoryExist_已经存在的情况()
        {
            #region 验证前置条件

            ItemCategory category = new ItemCategory();
            category.Id = "c2ecf0ef-dc5b-4308-9f38-047453d53919";
            category.CategoryId = "50011665";
            ItemCategoryManager manager = new ItemCategoryManager();
            string sqlCreate = manager.GetCreateSql(category);
            using (DbOperator dbOperator = new DbOperator(connString))
            {
                dbOperator.ExecSql(sqlCreate);
            }

            #endregion

            ItemCategoryFacade facade = new ItemCategoryFacade();
            bool isExist = facade.IsItemCategoryExist("50011665");

            Assert.AreEqual(true, isExist);
        }

        #endregion

        #region 获取类目信息

        [TestMethod]
        public void TestGetItemCategory_不存在的情况()
        {
            ItemCategoryFacade facade = new ItemCategoryFacade();
            ItemCategoryInfo categoryInfo = facade.GetItemCategoryById("50011665");

            #region 验证后置条件

            Assert.IsNull(categoryInfo);

            #endregion
        }

        [TestMethod]
        public void TestGetItemCategory_已经存在的情况()
        {
            #region 验证前置条件

            ItemCategory category = new ItemCategory();
            category.Id = "c2ecf0ef-dc5b-4308-9f38-047453d53919";
            category.CategoryId = "50011665";
            category.Name = "测试类目";
            category.ParentId = "0";
            category.IsParent = true;
            category.SortOrder = 1;
            category.Status = "normal";
            ItemCategoryManager manager = new ItemCategoryManager();
            string sqlCreate = manager.GetCreateSql(category);
            using (DbOperator dbOperator = new DbOperator(connString))
            {
                dbOperator.ExecSql(sqlCreate);
            }

            #endregion

            ItemCategoryFacade facade = new ItemCategoryFacade();
            ItemCategoryInfo categoryInfo = facade.GetItemCategoryById("50011665");

            #region 验证后置条件

            Assert.IsNotNull(categoryInfo);
            Assert.AreEqual("c2ecf0ef-dc5b-4308-9f38-047453d53919", categoryInfo.Id);
            Assert.AreEqual("50011665", categoryInfo.CategoryId);
            Assert.AreEqual("测试类目", categoryInfo.Name);
            Assert.AreEqual("0", categoryInfo.ParentId);
            Assert.AreEqual(true, categoryInfo.IsParent);
            Assert.AreEqual(1, categoryInfo.SortOrder);
            Assert.AreEqual("normal", categoryInfo.Status);

            #endregion
        }

        #endregion

        #region 获取类目列表

        [TestMethod]
        public void TestGetItemCategoryListByParent_没有数据()
        {
            ItemCategoryFacade facade = new ItemCategoryFacade();
            List<ItemCategoryInfo> list = facade.GetItemCategoryListByParent(string.Empty);

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestGetItemCategoryListByParent_有一条根数据()
        {
            #region 验证前置条件

            ItemCategory category = new ItemCategory();
            category.Id = "c2ecf0ef-dc5b-4308-9f38-047453d53919";
            category.CategoryId = "50011665";
            category.Name = "测试类目";
            category.ParentId = "0";
            category.IsParent = true;
            category.SortOrder = 1;
            category.Status = "normal";
            ItemCategoryManager manager = new ItemCategoryManager();
            string sqlCreate = manager.GetCreateSql(category);
            using (DbOperator dbOperator = new DbOperator(connString))
            {
                dbOperator.ExecSql(sqlCreate);
            }

            #endregion

            ItemCategoryFacade facade = new ItemCategoryFacade();
            List<ItemCategoryInfo> list = facade.GetItemCategoryListByParent(string.Empty);

            #region 验证后置条件

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("c2ecf0ef-dc5b-4308-9f38-047453d53919", list[0].Id);
            Assert.AreEqual("50011665", list[0].CategoryId);
            Assert.AreEqual("测试类目", list[0].Name);
            Assert.AreEqual("0", list[0].ParentId);
            Assert.AreEqual(true, list[0].IsParent);
            Assert.AreEqual(1, list[0].SortOrder);
            Assert.AreEqual("normal", list[0].Status);

            #endregion
        }

        [TestMethod]
        public void TestGetItemCategoryListByParent_有二条根数据()
        {
            #region 验证前置条件

            ItemCategory category1 = new ItemCategory();
            category1.Id = "c2ecf0ef-dc5b-4308-9f38-047453d53919";
            category1.CategoryId = "50011665";
            category1.Name = "测试类目1";
            category1.ParentId = "0";
            category1.IsParent = true;
            category1.SortOrder = 1;
            category1.Status = "normal";

            ItemCategory category2 = new ItemCategory();
            category2.Id = "c2ecf0ef-dc5b-4308-9f38-047453d53929";
            category2.CategoryId = "50011667";
            category2.Name = "测试类目2";
            category2.ParentId = "0";
            category2.IsParent = true;
            category2.SortOrder = 0;
            category2.Status = "deleted";

            ItemCategoryManager manager = new ItemCategoryManager();
            string sqlCreate1 = manager.GetCreateSql(category1);
            string sqlCreate2 = manager.GetCreateSql(category2);

            using (DbOperator dbOperator = new DbOperator(connString))
            {
                dbOperator.ExecSql(sqlCreate1);
                dbOperator.ExecSql(sqlCreate2);
            }

            #endregion

            ItemCategoryFacade facade = new ItemCategoryFacade();
            List<ItemCategoryInfo> list = facade.GetItemCategoryListByParent(string.Empty);

            #region 验证后置条件

            Assert.AreEqual(2, list.Count);

            ItemCategoryInfo categoryInfo1 = list[0];
            Assert.AreEqual("c2ecf0ef-dc5b-4308-9f38-047453d53929", categoryInfo1.Id);
            Assert.AreEqual("50011667", categoryInfo1.CategoryId);
            Assert.AreEqual("测试类目2", categoryInfo1.Name);
            Assert.AreEqual("0", categoryInfo1.ParentId);
            Assert.AreEqual(true, categoryInfo1.IsParent);
            Assert.AreEqual(0, categoryInfo1.SortOrder);
            Assert.AreEqual("deleted", categoryInfo1.Status);

            ItemCategoryInfo categoryInfo2 = list[1];
            Assert.AreEqual("c2ecf0ef-dc5b-4308-9f38-047453d53919", categoryInfo2.Id);
            Assert.AreEqual("50011665", categoryInfo2.CategoryId);
            Assert.AreEqual("测试类目1", categoryInfo2.Name);
            Assert.AreEqual("0", categoryInfo2.ParentId);
            Assert.AreEqual(true, categoryInfo2.IsParent);
            Assert.AreEqual(1, categoryInfo2.SortOrder);
            Assert.AreEqual("normal", categoryInfo2.Status);

            #endregion
        }

        [TestMethod]
        public void TestGetItemCategoryListByParent_父子数据情况()
        {
            #region 验证前置条件

            ItemCategory category1 = new ItemCategory();
            category1.Id = "c2ecf0ef-dc5b-4308-9f38-047453d53919";
            category1.CategoryId = "50011665";
            category1.Name = "测试类目1";
            category1.ParentId = "0";
            category1.IsParent = true;
            category1.SortOrder = 1;
            category1.Status = "normal";

            ItemCategory category2 = new ItemCategory();
            category2.Id = "c2ecf0ef-dc5b-4308-9f38-047453d53929";
            category2.CategoryId = "50011667";
            category2.Name = "测试类目2";
            category2.ParentId = "50011665";
            category2.IsParent = true;
            category2.SortOrder = 0;
            category2.Status = "deleted";

            ItemCategoryManager manager = new ItemCategoryManager();
            string sqlCreate1 = manager.GetCreateSql(category1);
            string sqlCreate2 = manager.GetCreateSql(category2);

            using (DbOperator dbOperator = new DbOperator(connString))
            {
                dbOperator.ExecSql(sqlCreate1);
                dbOperator.ExecSql(sqlCreate2);
            }

            #endregion

            ItemCategoryFacade facade = new ItemCategoryFacade();

            #region 验证后置条件

            List<ItemCategoryInfo> list1 = facade.GetItemCategoryListByParent(string.Empty);

            Assert.AreEqual(1, list1.Count);
            ItemCategoryInfo categoryInfo1 = list1[0];
            Assert.AreEqual("c2ecf0ef-dc5b-4308-9f38-047453d53919", categoryInfo1.Id);
            Assert.AreEqual("50011665", categoryInfo1.CategoryId);
            Assert.AreEqual("测试类目1", categoryInfo1.Name);
            Assert.AreEqual("0", categoryInfo1.ParentId);
            Assert.AreEqual(true, categoryInfo1.IsParent);
            Assert.AreEqual(1, categoryInfo1.SortOrder);
            Assert.AreEqual("normal", categoryInfo1.Status);

            List<ItemCategoryInfo> list2 = facade.GetItemCategoryListByParent("50011665");

            ItemCategoryInfo categoryInfo2 = list2[0];
            Assert.AreEqual("c2ecf0ef-dc5b-4308-9f38-047453d53929", categoryInfo2.Id);
            Assert.AreEqual("50011667", categoryInfo2.CategoryId);
            Assert.AreEqual("测试类目2", categoryInfo2.Name);
            Assert.AreEqual("50011665", categoryInfo2.ParentId);
            Assert.AreEqual(true, categoryInfo2.IsParent);
            Assert.AreEqual(0, categoryInfo2.SortOrder);
            Assert.AreEqual("deleted", categoryInfo2.Status);

            #endregion
        }

        #endregion
    }
}
