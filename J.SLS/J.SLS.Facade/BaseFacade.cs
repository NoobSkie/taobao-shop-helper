using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;
using J.SLS.Database.Configuration;

namespace J.SLS.Facade
{
    public abstract class BaseFacade
    {
        public BaseFacade()
        {
        }

        protected ObjectPersistence GetPersistence(IDBAccess dbAccess)
        {
            return new ObjectPersistence(dbAccess);
        }

        protected ILHDBAccess DbAccess
        {
            get
            {
                return CurrentConfig.DbAccess;
            }
        }

        protected ILHDBTran DbTran
        {
            get
            {
                return CurrentConfig.DbTran;
            }
        }

        private static ConnectionConfiguration config = null;
        private object lockObj = new object();
        private ConnectionConfiguration CurrentConfig
        {
            get
            {
                if (config == null)
                {
                    lock (lockObj)
                    {
                        if (config == null)
                        {
                            config = ConnectionConfiguration.GetConfiguration("J.SLS.Conn");
                        }
                    }
                }
                return config;
            }
        }
    }
}
