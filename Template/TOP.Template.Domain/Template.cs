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
        [DbField(DbFieldName = "Name", DbFieldType = DbDataType.NVARCHAR, IsNotNull = true, Length = 100)]
        public string Name { get; set; }

        [DbField(DbFieldName = "Content", DbFieldType = DbDataType.NVARCHAR, IsNotNull = true, Length = 0)]
        public string Content { get; set; }
    }
}
