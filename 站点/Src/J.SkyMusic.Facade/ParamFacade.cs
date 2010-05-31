using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SkyMusic.Domain;
using J.SLS.Database.DBAccess;

namespace J.SkyMusic.Facade
{
    public class ParamFacade : BaseFacade
    {
        public ParamInfo GetParam(string key)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            return persistence.GetByKey<ParamInfo>(key);
        }

        public void SaveParam(ParamInfo param)
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
    }
}
