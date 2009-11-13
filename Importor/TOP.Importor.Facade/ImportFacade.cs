using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.Logic;
using TOP.Importor.Domain;
using TOP.Common.Enumerations;
using TOP.Common.DbHelper;
using System.Data;

namespace TOP.Importor.Facade
{
    public class ImportFacade : FacadeBase
    {
        public void AddImportGroup(string groupId, string operatorUserId, string operatorUserName, int totalCount
            , string fromNick, string fromTitle, string fromImageUrl, string toNick, string toTitle
            , ImportorEnumerations.ImportType importType, string userId)
        {
            ImportGroup groupEntity = new ImportGroup();
            groupEntity.Id = groupId;
            groupEntity.OperatorUserId = operatorUserId;
            groupEntity.OperatorUserName = operatorUserName;
            groupEntity.TotalCount = totalCount;
            groupEntity.SuccessCount = 0;
            groupEntity.FailCount = 0;
            groupEntity.ImportFormSellerNick = fromNick;
            groupEntity.ImportFormShopTitle = fromTitle;
            groupEntity.ImportFormShopImageUrl = fromImageUrl;
            groupEntity.ImportToSellerNick = toNick;
            groupEntity.ImportToShopTitle = toTitle;
            groupEntity.ImportType = importType;
            groupEntity.ImportState = ImportorEnumerations.ImportState.Waitting;
            groupEntity.ImportResult = ImportorEnumerations.ImportGroupResult.Pending;
            groupEntity.ListDateTime = DateTime.Now;
            groupEntity.StartDateTime = null;
            groupEntity.FinishDateTime = null;

            groupEntity.CreateDate = DateTime.Now;
            groupEntity.CreateUserId = userId;
            groupEntity.LastUpdateDate = DateTime.Now;
            groupEntity.LastUpdateUserId = userId;

            ImportGroupManager groupManager = new ImportGroupManager();
            string sqlCreateGroup = groupManager.GetCreateSql(groupEntity);

            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                try
                {
                    dbOperator.BeginTran();
                    dbOperator.ExecSql(sqlCreateGroup);
                    dbOperator.CommintTran();
                }
                catch (Exception ex)
                {
                    dbOperator.RollbackTran();
                    throw new FacadeException("添加导入组发生异常 - ", ex);
                }
            }
        }

        public void AddImportItem(string itemId, string groupId, string operatorUserId, string operatorUserName
            , string fromItemIid, string fromItemTitle, string fromItemPrice, string fromSellerNick, string fromShopTitle, string userId)
        {
            ImportItem itemEntity = new ImportItem();
            itemEntity.Id = itemId;
            itemEntity.OperatorUserId = operatorUserId;
            itemEntity.OperatorUserName = operatorUserName;
            itemEntity.ItsImportGroupId = groupId;
            itemEntity.ImportFormItemIid = fromItemIid;
            itemEntity.ImportFormItemTitle = fromItemTitle;
            itemEntity.ImportFormItemPrice = fromItemPrice;
            itemEntity.ImportFormSellerNick = fromSellerNick;
            itemEntity.ImportFormShopTitle = fromShopTitle;
            itemEntity.ImportState = ImportorEnumerations.ImportState.Waitting;
            itemEntity.ImportResult = ImportorEnumerations.ImportItemResult.Pending;
            itemEntity.ListDateTime = DateTime.Now;
            itemEntity.StartDateTime = null;
            itemEntity.FinishDateTime = null;

            itemEntity.CreateDate = DateTime.Now;
            itemEntity.CreateUserId = userId;
            itemEntity.LastUpdateDate = DateTime.Now;
            itemEntity.LastUpdateUserId = userId;

            ImportItemManager itemManager = new ImportItemManager();
            string sqlCreateItem = itemManager.GetCreateSql(itemEntity);

            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                try
                {
                    dbOperator.BeginTran();
                    dbOperator.ExecSql(sqlCreateItem);
                    dbOperator.CommintTran();
                }
                catch (Exception ex)
                {
                    dbOperator.RollbackTran();
                    throw new FacadeException("添加导入项发生异常 - ", ex);
                }
            }
        }

        public void StartImport(string groupId, int version, string userId)
        {
            ImportGroup groupEntity = new ImportGroup();
            groupEntity.Id = groupId;
            groupEntity.ImportState = ImportorEnumerations.ImportState.Importing;

            groupEntity.LastUpdateDate = DateTime.Now;
            groupEntity.LastUpdateUserId = userId;
            groupEntity.CurrentVersion = version;

            #region 执行SQL以修改对象

            ImportGroupManager manager = new ImportGroupManager();
            string sqlUpdate = manager.GetUpdateSql(groupEntity, "ImportState");
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                try
                {
                    dbOperator.BeginTran();
                    dbOperator.ExecSql(sqlUpdate);
                    dbOperator.CommintTran();
                }
                catch (Exception ex)
                {
                    dbOperator.RollbackTran();
                    throw new FacadeException("启动导入过程发生异常 - ", ex);
                }
            }

            #endregion
        }

        public void StartImportItem(string itemId, int version, string userId)
        {
            ImportItem itemEntity = new ImportItem();
            itemEntity.Id = itemId;
            itemEntity.ImportState = ImportorEnumerations.ImportState.Importing;
            itemEntity.StartDateTime = DateTime.Now;

            itemEntity.LastUpdateDate = DateTime.Now;
            itemEntity.LastUpdateUserId = userId;
            itemEntity.CurrentVersion = version;

            ImportItemManager manager = new ImportItemManager();
            string sqlUpdateItem = manager.GetUpdateSql(itemEntity, "ImportState", "StartDateTime");

            #region 执行SQL以修改对象

            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                try
                {
                    dbOperator.BeginTran();
                    dbOperator.ExecSql(sqlUpdateItem);
                    dbOperator.CommintTran();
                }
                catch (Exception ex)
                {
                    dbOperator.RollbackTran();
                    throw new FacadeException("启动导入宝贝发生异常 - ", ex);
                }
            }

            #endregion
        }

        public void FinishImportItem(string groupId, int groupVersion, string itemId, int itemVersion
            , ImportorEnumerations.ImportItemResult result
            , string toItemIid, string toItemTitle, string toItemPrice, string toSellerNick, string toShopTitle
            , int successCount, int failCount, string message, string userId)
        {
            ImportGroup groupEntity = new ImportGroup();
            groupEntity.Id = groupId;
            groupEntity.SuccessCount = successCount;
            groupEntity.FailCount = failCount;

            groupEntity.LastUpdateDate = DateTime.Now;
            groupEntity.LastUpdateUserId = userId;
            groupEntity.CurrentVersion = groupVersion;

            ImportGroupManager managerGroup = new ImportGroupManager();
            string sqlUpdateGroup = managerGroup.GetUpdateSql(groupEntity, "SuccessCount", "FailCount");

            ImportItem itemEntity = new ImportItem();
            itemEntity.Id = itemId;
            itemEntity.ImportState = ImportorEnumerations.ImportState.Finished;
            itemEntity.ImportResult = result;
            itemEntity.FinishDateTime = DateTime.Now;
            itemEntity.ImportToItemIid = toItemIid;
            itemEntity.ImportToItemTitle = toItemTitle;
            itemEntity.ImportToItemPrice = toItemPrice;
            itemEntity.ImportToSellerNick = toSellerNick;
            itemEntity.ImportToShopTitle = toShopTitle;
            itemEntity.ResultMessage = message;

            itemEntity.LastUpdateDate = DateTime.Now;
            itemEntity.LastUpdateUserId = userId;
            itemEntity.CurrentVersion = itemVersion;

            ImportItemManager managerItem = new ImportItemManager();
            string sqlUpdateItem = managerItem.GetUpdateSql(itemEntity
                , "ImportState"
                , "ImportResult"
                , "FinishDateTime"
                , "ImportToItemIid"
                , "ImportToItemTitle"
                , "ImportToItemPrice"
                , "ImportToSellerNick"
                , "ImportToShopTitle"
                , "ResultMessage");

            #region 执行SQL以修改对象

            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                try
                {
                    dbOperator.BeginTran();
                    dbOperator.ExecSql(sqlUpdateGroup);
                    dbOperator.ExecSql(sqlUpdateItem);
                    dbOperator.CommintTran();
                }
                catch (Exception ex)
                {
                    dbOperator.RollbackTran();
                    throw new FacadeException("结束导入宝贝发生异常 - ", ex);
                }
            }

            #endregion
        }

        public void FinishImport(string groupId, int version, ImportorEnumerations.ImportGroupResult result, string userId)
        {
            ImportGroup groupEntity = new ImportGroup();
            groupEntity.Id = groupId;
            groupEntity.ImportState = ImportorEnumerations.ImportState.Finished;
            groupEntity.ImportResult = result;

            groupEntity.LastUpdateDate = DateTime.Now;
            groupEntity.LastUpdateUserId = userId;
            groupEntity.CurrentVersion = version;

            #region 执行SQL以修改对象

            ImportGroupManager manager = new ImportGroupManager();
            string sqlUpdate = manager.GetUpdateSql(groupEntity, "ImportState", "ImportResult");
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                try
                {
                    dbOperator.BeginTran();
                    dbOperator.ExecSql(sqlUpdate);
                    dbOperator.CommintTran();
                }
                catch (Exception ex)
                {
                    dbOperator.RollbackTran();
                    throw new FacadeException("结束导入过程发生异常 - ", ex);
                }
            }

            #endregion
        }

        public ImportGroupInfo GetImportGroup(string groupId)
        {
            string sqlSelect = sqlHelper.GenerateSelectViewSql(typeof(ImportGroupInfo));
            sqlSelect += string.Format("WHERE [Id] = N'{0}'", groupId);
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                DataTable dt = dbOperator.GetTable(sqlSelect);
                if (dt.Rows.Count > 0)
                {
                    return TransferInfo<ImportGroupInfo>(dt.Rows[0]);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<ImportItemInfo> GetImportItemList(string groupId)
        {
            string sqlSelect = sqlHelper.GenerateSelectViewSql(typeof(ImportItemInfo));
            sqlSelect += string.Format("WHERE [ItsImportGroupId] = N'{0}'", groupId);
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                DataTable dt = dbOperator.GetTable(sqlSelect);
                return TransferList<ImportItemInfo>(dt);
            }
        }

        public List<ImportItemInfo> GetImportItemList(string groupId, int pageIndex, int pageSize)
        {
            int start = pageIndex * pageSize + 1;
            int end = start + pageSize - 1;
            string sqlSelect = sqlHelper.GenerateSelectViewSql(typeof(ImportItemInfo));
            sqlSelect += string.Format("WHERE [ItsImportGroupId] = N'{0}'", groupId);
            sqlSelect = "SELECT * FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY [LastUpdateDate] DESC) AS [RowNum] FROM ("
                + sqlSelect
                + string.Format(") AS [MyTable]) AS [T1] WHERE [T1].[RowNum] BETWEEN {0} AND {1}", start, end);

            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                DataTable dt = dbOperator.GetTable(sqlSelect);
                return TransferList<ImportItemInfo>(dt);
            }
        }
    }
}
