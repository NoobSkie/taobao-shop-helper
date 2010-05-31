using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;

namespace J.SkyMusic.Domain
{
    public class MenuManager
    {
        private readonly ObjectPersistence persistence = null;
        public MenuManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public void AddMenu(MenuEntity entity)
        {
            persistence.Add(entity);
        }
    }
}
