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
            using (ILHDBTran tran = BeginTran())
            {
                ParamManager manager = new ParamManager(tran);
                manager.DeleteParam(param);
                manager.AddParam(param);
                tran.Commit();
            }
        }
    }
}
