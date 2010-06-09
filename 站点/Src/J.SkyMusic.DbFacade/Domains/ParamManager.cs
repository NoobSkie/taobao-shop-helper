using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;
using System.IO;
using System.Xml;

namespace J.SkyMusic.DbFacade.Domain
{
    public class ParamManager
    {
        private readonly ObjectPersistence persistence = null;
        public ParamManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public void AddParam(ParamEntity entity)
        {
            persistence.Add(entity);
        }

        public void DeleteParam(ParamEntity entity)
        {
            persistence.Delete(entity);
        }
    }
}
