using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;

namespace J.SkyMusic.Facade
{
    public class PageBlockFacade : BaseFacade
    {
        public IList<PageBlockInfo> GetBlockList(int xIndex)
        {
            ObjectPersistence persistence = new ObjectPersistence(DbAccess);
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("XIndex", xIndex));
            return persistence.GetList<PageBlockInfo>(cri, new SortInfo("YIndex"));
        }
    }
}
