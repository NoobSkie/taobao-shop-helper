using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;
using System.IO;
using System.Xml;
using J.SkyMusic.DbFacade.Domain;

namespace J.SkyMusic.DbFacade.Services
{
    public class ParamFacade : BaseFacade
    {
        public ParamInfo GetParam(string key)
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                return persistence.GetByKey<ParamInfo>(key);
            }
            catch (Exception ex)
            {
                throw HandleException("Param", "Get parameter by key error. - " + key, ex);
            }
        }

        public void SaveParam(ParamInfo param)
        {
            try
            {
                ParamEntity entity = new ParamEntity();
                entity.Key = param.Key;
                entity.Value = param.Value;

                using (ILHDBTran tran = BeginTran())
                {
                    ParamManager manager = new ParamManager(tran);
                    manager.DeleteParam(entity);
                    manager.AddParam(entity);
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                throw HandleException("Param", "Save parameter error. - " + param.Key, ex);
            }
        }
    }
}
