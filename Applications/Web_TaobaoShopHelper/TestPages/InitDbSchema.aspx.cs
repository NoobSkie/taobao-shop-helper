using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using ComponentArt.Web.UI;
using TOP.Common.DbHelper;
using System.Configuration;
using TOP.Common.Logic;

namespace TOP.Applications.TaobaoShopHelper.TestPages
{
    public partial class InitDbSchema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitSchema();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string value = tvSchema.SelectedNode.Value;
            if (value != "table" && value != "view")
            {
                Type type = Type.GetType(value);
                string dbTypeId = ConfigurationManager.AppSettings["DbType"];
                TOP.Common.DbHelper.DbType dbType = (TOP.Common.DbHelper.DbType)short.Parse(dbTypeId);
                string connString = ConfigurationManager.AppSettings["ConnString"];

                string sqlDrop = string.Empty;
                string sqlCreate = string.Empty;

                string parent = tvSchema.SelectedNode.ParentNode.Value;
                if (parent == "table")
                {
                    DbSqlCreater dbSqlCreater = DbSqlCreater.GetDbSqlCreater(dbType);
                    sqlDrop = dbSqlCreater.GenerateDropTableSql(type);
                    sqlCreate = dbSqlCreater.GenerateCreateTableSql(type);
                }
                else if (parent == "view")
                {
                    string baseDir = Server.MapPath("~");
                    baseDir += @"\..\..\Database\Scripts";
                    DbQuery dbQuery = DbQuery.GetDbQuery(dbType);
                    sqlDrop = dbQuery.GenerateDropViewSql(type, baseDir);
                    sqlCreate = dbQuery.GenerateCreateViewSql(type, baseDir);
                }
                else
                {
                    throw new ArgumentException("不能更新的类型 - " + parent + " - " + value);
                }

                using (DbOperator dbOperator = new DbOperator(connString))
                {
                    try
                    {
                        dbOperator.BeginTran();
                        dbOperator.ExecSql(sqlDrop);
                        dbOperator.ExecSql(sqlCreate);
                        dbOperator.CommintTran();

                        lblMessage.Text = "更新成功 - " + parent + " - " + value;
                    }
                    catch
                    {
                        dbOperator.RollbackTran();
                        throw new Exception("更新数据库对象错误 - " + parent + " - " + value);
                    }
                }
            }
            else
            {
                lblMessage.Text = "所选择对象无效，请选择要更新的数据库对象。";
            }
        }

        private void InitSchema()
        {
            TreeViewNode node;

            node = new TreeViewNode();
            node.Text = "Area";
            node.Value = "TOP.Management.Domain.Area, TOP.Management.Domain";
            nodeTable.Nodes.Add(node);

            node = new TreeViewNode();
            node.Text = "ItemCategory";
            node.Value = "TOP.Management.Domain.ItemCategory, TOP.Management.Domain";
            nodeTable.Nodes.Add(node);

            node = new TreeViewNode();
            node.Text = "AreaInfo";
            node.Value = "TOP.Management.Facade.AreaInfo, TOP.Management.Facade";
            nodeView.Nodes.Add(node);

            node = new TreeViewNode();
            node.Text = "ItemCategoryInfo";
            node.Value = "TOP.Management.Facade.ItemCategoryInfo, TOP.Management.Facade";
            nodeView.Nodes.Add(node);
        }
    }
}
