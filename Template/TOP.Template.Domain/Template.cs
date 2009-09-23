using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.DbHelper;

namespace TOP.Template.Domain
{
    [DbTable(DbTableName = "Template", DbObjectType = DbObjectType.Table)]
    public class Template : DbEntity
    {
    }
}
