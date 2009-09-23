using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Management.Domain;
using TOP.Common.DbHelper;
using TOP.Common.Logic;
using System.Data;

namespace TOP.Management.Facade
{
    public class ItemCategoryFacade : FacadeBase
    {
        public ItemCategoryInfo GetItemCategoryById(string categoryId)
        {
            string sqlSelect = sqlHelper.GenerateSelectViewSql(typeof(ItemCategoryInfo));
            sqlSelect += string.Format("WHERE [CategoryId] = N'{0}'", categoryId);
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                DataTable dt = dbOperator.GetTable(sqlSelect);
                if (dt.Rows.Count > 0)
                {
                    return TransferInfo<ItemCategoryInfo>(dt.Rows[0]);
                }
                else
                {
                    return null;
                }
            }
        }

        public void DeleteItemCategoryByParentId(string categoryId)
        {
            ItemCategory category = new ItemCategory();
            ItemCategoryManager manager = new ItemCategoryManager();
            string sqlDelete = manager.GetDeleteSql(category);
            sqlDelete += string.Format("WHERE [ParentId] = N'{0}'", categoryId);
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                dbOperator.ExecSql(sqlDelete);
            }
        }

        public List<ItemCategoryInfo> GetItemCategoryListByParent(string parentId)
        {
            if (string.IsNullOrEmpty(parentId))
            {
                parentId = "0";
            }
            string sqlSelect = sqlHelper.GenerateSelectViewSql(typeof(ItemCategoryInfo));
            sqlSelect += string.Format("WHERE [ParentId] = N'{0}' ", parentId);
            sqlSelect += "ORDER BY [SortOrder] ASC";
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                List<ItemCategoryInfo> list = new List<ItemCategoryInfo>();
                DataTable dt = dbOperator.GetTable(sqlSelect);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(TransferInfo<ItemCategoryInfo>(row));
                }
                return list;
            }
        }

        public bool IsItemCategoryExist(string categoryId)
        {
            string sqlCheck = sqlHelper.GenerateCountViewSql(typeof(ItemCategoryInfo));
            sqlCheck += string.Format("WHERE [CategoryId] = N'{0}'", categoryId);
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                DataTable dt = dbOperator.GetTable(sqlCheck);
                int i = (int)dt.Rows[0][0];
                return i > 0;
            }
        }

        public string AddItemCategory(string id, string categoryId, string parentId, string name, bool isParent, string status, int sortOrder)
        {
            #region 构造要新增的对象

            if (string.IsNullOrEmpty(id) || id == Guid.Empty.ToString())
            {
                id = Guid.NewGuid().ToString();
            }

            ItemCategory category = new ItemCategory();
            category.Id = id;
            category.CategoryId = categoryId;
            category.ParentId = parentId;
            category.Name = name;
            category.IsParent = isParent;
            category.Status = status;
            category.SortOrder = sortOrder;

            #endregion

            #region 执行SQL以创建对象

            ItemCategoryManager manager = new ItemCategoryManager();
            string sqlCreate = manager.GetCreateSql(category);
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                try
                {
                    dbOperator.BeginTran();
                    dbOperator.ExecSql(sqlCreate);
                    dbOperator.CommintTran();

                    return id;
                }
                catch (Exception ex)
                {
                    dbOperator.RollbackTran();
                    throw new FacadeException("新增类目发生异常 - ", ex);
                }
            }

            #endregion
        }
    }
}
