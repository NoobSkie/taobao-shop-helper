using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOP.Common.DbHelper.Test.TestClasses;

namespace TOP.Common.DbHelper.Test
{
    [TestClass]
    public class MSSqlCreaterTest
    {
        #region 生成创建表的SQL

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "必须是TOP.Common.DbHelper.DbEntity类型的对象才能执行此操作。 - TOP.Common.DbHelper.Test.TestClasses.NotDbEnityClass")]
        public void TestGenerateCreateTableSql_不是DbEntity类型()
        {
            MSSql2005Creater creater = new MSSql2005Creater();
            string sql = creater.GenerateCreateTableSql(typeof(NotDbEnityClass));
        }

        [TestMethod]
        public void TestGenerateCreateTableSql_没有其他字段()
        {
            MSSql2005Creater creater = new MSSql2005Creater();
            string sql = creater.GenerateCreateTableSql(typeof(NoneFieldDbEnityClass));
            StringBuilder sqlCreate = new StringBuilder();
            sqlCreate.AppendLine("SET ANSI_NULLS ON");
            sqlCreate.AppendLine("GO");
            sqlCreate.AppendLine("SET QUOTED_IDENTIFIER ON");
            sqlCreate.AppendLine("GO");
            sqlCreate.AppendLine("CREATE TABLE [NoneFieldDbEnityClass]");
            sqlCreate.AppendLine("(");
            sqlCreate.AppendLine("[Id] [UNIQUEIDENTIFIER] ROWGUIDCOL NOT NULL CONSTRAINT [DF_NoneFieldDbEnityClass_Id] DEFAULT(NEWID()),");
            sqlCreate.AppendLine("CONSTRAINT [PK_NoneFieldDbEnityClass] PRIMARY KEY CLUSTERED");
            sqlCreate.AppendLine("(");
            sqlCreate.AppendLine("[Id] ASC");
            sqlCreate.AppendLine(")");
            sqlCreate.AppendLine(")");
            sqlCreate.AppendLine("GO");

            Assert.AreEqual(sqlCreate.ToString(), sql);
        }

        [TestMethod]
        public void TestGenerateCreateTableSql_有一个字段()
        {
            MSSql2005Creater creater = new MSSql2005Creater();
            string sql = creater.GenerateCreateTableSql(typeof(SingleFieldDbEnityClass));

            Assert.IsTrue(sql.Contains("CREATE TABLE [SingleFieldDbEnityClass]"), "创建表");
            Assert.IsTrue(sql.Contains("[Id] [UNIQUEIDENTIFIER] ROWGUIDCOL NOT NULL CONSTRAINT [DF_SingleFieldDbEnityClass_Id] DEFAULT(NEWID()),"), "主键");
            Assert.IsTrue(sql.Contains("[Name] [NVARCHAR] (100) NULL ,"), "姓名");
        }

        [TestMethod]
        public void TestGenerateCreateTableSql_有多个字段()
        {
            MSSql2005Creater creater = new MSSql2005Creater();
            string sql = creater.GenerateCreateTableSql(typeof(MultiFieldDbEnityClass));

            Assert.IsTrue(sql.Contains("CREATE TABLE [MultiFieldDbEnityClass]"), "创建表");
            Assert.IsTrue(sql.Contains("[Id] [UNIQUEIDENTIFIER] ROWGUIDCOL NOT NULL CONSTRAINT [DF_MultiFieldDbEnityClass_Id] DEFAULT(NEWID()),"), "主键");
            Assert.IsTrue(sql.Contains("[Name] [NVARCHAR] (100) NULL ,"), "姓名");
            Assert.IsTrue(sql.Contains("[Description] [NVARCHAR] (MAX) NULL ,"), "描述");
            Assert.IsTrue(sql.Contains("[IsSystem] [BIT] NULL ,"), "是否系统");
            Assert.IsTrue(sql.Contains("[IsNew] [BIT] NOT NULL DEFAULT(0) ,"), "是否新增");
            Assert.IsTrue(sql.Contains("[Age] [INT] NULL ,"), "年龄");
            Assert.IsTrue(sql.Contains("[ItsOrg] [UNIQUEIDENTIFIER] NULL ,"), "所属机构");
        }

        #endregion

        #region 生成删除表的SQL

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "必须是TOP.Common.DbHelper.DbEntity类型的对象才能执行此操作。 - TOP.Common.DbHelper.Test.TestClasses.NotDbEnityClass")]
        public void TestGenerateDropTableSql_不是DbEntity类型()
        {
            MSSql2005Creater creater = new MSSql2005Creater();
            string sql = creater.GenerateDropTableSql(typeof(NotDbEnityClass));
        }

        [TestMethod]
        public void TestGenerateDropTableSql_没有其他字段()
        {
            MSSql2005Creater creater = new MSSql2005Creater();
            string sql = creater.GenerateDropTableSql(typeof(NoneFieldDbEnityClass));

            StringBuilder sqlCreate = new StringBuilder();
            sqlCreate.AppendLine("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[NoneFieldDbEnityClass]') AND type in (N'U'))");
            sqlCreate.AppendLine("DROP TABLE [NoneFieldDbEnityClass]");
            sqlCreate.AppendLine("GO");

            Assert.AreEqual(sqlCreate.ToString(), sql);
        }

        [TestMethod]
        public void TestGenerateDropTableSql_有一个字段()
        {
            MSSql2005Creater creater = new MSSql2005Creater();
            string sql = creater.GenerateDropTableSql(typeof(SingleFieldDbEnityClass));

            StringBuilder sqlCreate = new StringBuilder();
            sqlCreate.AppendLine("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SingleFieldDbEnityClass]') AND type in (N'U'))");
            sqlCreate.AppendLine("DROP TABLE [SingleFieldDbEnityClass]");
            sqlCreate.AppendLine("GO");

            Assert.AreEqual(sqlCreate.ToString(), sql);
        }

        [TestMethod]
        public void TestGenerateDropTableSql_有多个字段()
        {
            MSSql2005Creater creater = new MSSql2005Creater();
            string sql = creater.GenerateDropTableSql(typeof(MultiFieldDbEnityClass));

            StringBuilder sqlCreate = new StringBuilder();
            sqlCreate.AppendLine("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[MultiFieldDbEnityClass]') AND type in (N'U'))");
            sqlCreate.AppendLine("DROP TABLE [MultiFieldDbEnityClass]");
            sqlCreate.AppendLine("GO");

            Assert.AreEqual(sqlCreate.ToString(), sql);
        }

        #endregion
    }
}
