using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Common.DbHelper.Test.TestClasses
{
    [DbTable(DbTableName = "NotDbEnityClass", DbObjectType = DbObjectType.Table)]
    public class NotDbEnityClass
    {
        public string Name { get; set; }
    }

    [DbTable(DbTableName = "NoneFieldDbEnityClass", DbObjectType = DbObjectType.Table)]
    public class NoneFieldDbEnityClass : DbEntity
    {
    }

    [DbTable(DbTableName = "SingleFieldDbEnityClass", DbObjectType = DbObjectType.Table)]
    public class SingleFieldDbEnityClass : DbEntity
    {
        [DbField(DbFieldName = "Name", DbFieldType = DbDataType.NVARCHAR, Length = 100)]
        public string Name { get; set; }
    }

    [DbTable(DbTableName = "MultiFieldDbEnityClass", DbObjectType = DbObjectType.Table)]
    public class MultiFieldDbEnityClass : DbEntity
    {
        [DbField(DbFieldName = "Name", DbFieldType = DbDataType.NVARCHAR, Length = 100)]
        public string Name { get; set; }

        [DbField(DbFieldName = "Description", DbFieldType = DbDataType.NVARCHAR, Length = 0)]
        public string Description { get; set; }

        [DbField(DbFieldName = "IsSystem", DbFieldType = DbDataType.BIT)]
        public bool IsSystem { get; set; }

        [DbField(DbFieldName = "IsNew", DbFieldType = DbDataType.BIT, IsNotNull = true, DefaultValue = "0")]
        public bool IsNew { get; set; }

        [DbField(DbFieldName = "Age", DbFieldType = DbDataType.INT)]
        public int Age { get; set; }

        [DbField(DbFieldName = "ItsOrg", DbFieldType = DbDataType.UNIQUEIDENTIFIER)]
        public Guid ItsOrg { get; set; }
    }
}
