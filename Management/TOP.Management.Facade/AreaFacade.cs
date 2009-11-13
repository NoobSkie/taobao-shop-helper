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
    public class AreaFacade : FacadeBase
    {
        public string AddArea(string id, string areaId, AreaType areaType, string areaName, string parentId, string zip, string createUserId)
        {
            string areaTypeId = string.Empty;
            switch (areaType)
            {
                case AreaType.Country:
                    areaTypeId = "1";
                    break;
                case AreaType.Province:
                    areaTypeId = "2";
                    break;
                case AreaType.City:
                    areaTypeId = "3";
                    break;
                case AreaType.Distrct:
                    areaTypeId = "4";
                    break;
                case AreaType.Abroad:
                    areaTypeId = "abroad";
                    break;
                default:
                    throw new FacadeException("不能添加此类型的区域 - " + areaType.ToString());
            }
            return AddArea(id, areaId, areaTypeId, areaName, parentId, zip, createUserId);
        }

        public string AddArea(string id, string areaId, string areaTypeId, string areaName, string parentId, string zip, string createUserId)
        {
            #region 构造要新增的对象

            if (string.IsNullOrEmpty(id) || id == Guid.Empty.ToString())
            {
                id = Guid.NewGuid().ToString();
            }

            Area area = new Area();
            area.Id = id;
            area.AreaId = areaId;
            area.AreaTypeId = areaTypeId;
            area.AreaName = areaName;
            area.ParentId = parentId;
            area.Zip = zip;
            area.CreateDate = DateTime.Now;
            area.CreateUserId = createUserId;
            area.LastUpdateDate = DateTime.Now;
            area.LastUpdateUserId = createUserId;

            #endregion

            #region 执行SQL以创建对象

            AreaManager manager = new AreaManager();
            string sqlCreate = manager.GetCreateSql(area);
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
                    throw new FacadeException("新增区域发生异常 - ", ex);
                }
            }

            #endregion
        }

        public void UpdateArea(string areaId, string areaTypeId, string areaName, string parentId, string zip, string updateUserId)
        {
            #region 构造要修改的对象

            Area area = new Area();
            area.AreaTypeId = areaTypeId;
            area.AreaName = areaName;
            area.ParentId = parentId;
            area.Zip = zip;
            area.LastUpdateDate = DateTime.Now;
            area.LastUpdateUserId = updateUserId; 

            #endregion

            #region 执行SQL以修改对象

            AreaManager manager = new AreaManager();
            string sqlUpdate = manager.GetUpdateSql(area);
            sqlUpdate += string.Format("WHERE [AreaId] = N'{0}'", areaTypeId);
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
                    throw new FacadeException("修改区域发生异常 - ", ex);
                }
            }

            #endregion
        }

        public AreaInfo GetAreaById(string areaId)
        {
            string sqlSelect = sqlHelper.GenerateSelectViewSql(typeof(AreaInfo));
            sqlSelect += string.Format("WHERE [AreaId] = N'{0}'", areaId);
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                DataTable dt = dbOperator.GetTable(sqlSelect);
                if (dt.Rows.Count > 0)
                {
                    return TransferInfo<AreaInfo>(dt.Rows[0]);
                }
                else
                {
                    return null;
                }
            }
        }

        public bool IsHasChildren(string parentId)
        {
            string sqlSelect = sqlHelper.GenerateCountViewSql(typeof(AreaInfo));
            sqlSelect += string.Format("WHERE [ParentId] = N'{0}'", parentId);
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                DataTable dt = dbOperator.GetTable(sqlSelect);
                return (int)dt.Rows[0]["RowCount"] > 0;
            }
        }

        public bool IsAreaExist(string areaId)
        {
            string sqlCheck = sqlHelper.GenerateCountViewSql(typeof(AreaInfo));
            sqlCheck += string.Format("WHERE [AreaId] = N'{0}'", areaId);
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                DataTable dt = dbOperator.GetTable(sqlCheck);
                return (int)dt.Rows[0]["RowCount"] > 0;
            }
        }

        public List<AreaInfo> GetAreaListByParentId(string parentId)
        {
            string sqlSelect = sqlHelper.GenerateSelectViewSql(typeof(AreaInfo));
            sqlSelect += string.Format("WHERE [ParentId] = N'{0}'", parentId);
            sqlSelect += " ORDER BY [AreaId]";
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                DataTable dt = dbOperator.GetTable(sqlSelect);
                List<AreaInfo> list = new List<AreaInfo>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(TransferInfo<AreaInfo>(row));
                }
                return list;
            }
        }

        public List<AreaInfo> GetAllRootAreaList()
        {
            string sqlSelect = sqlHelper.GenerateSelectViewSql(typeof(AreaInfo));
            sqlSelect += "WHERE [ParentId] = N'0'";
            sqlSelect += " ORDER BY [AreaId]";
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                DataTable dt = dbOperator.GetTable(sqlSelect);
                List<AreaInfo> list = new List<AreaInfo>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(TransferInfo<AreaInfo>(row));
                }
                return list;
            }
        }

        public List<AreaInfo> GetAllProvinceAreaList()
        {
            string sqlSelect = sqlHelper.GenerateSelectViewSql(typeof(AreaInfo));
            sqlSelect += string.Format("WHERE [AreaType] = N'{0}'", (int)AreaType.Province);
            sqlSelect += " ORDER BY [AreaId]";
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                DataTable dt = dbOperator.GetTable(sqlSelect);
                List<AreaInfo> list = new List<AreaInfo>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(TransferInfo<AreaInfo>(row));
                }
                return list;
            }
        }
    }
}
