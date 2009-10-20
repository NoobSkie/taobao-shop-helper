using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Common.DbHelper
{
    public abstract class DbEntity
    {
        [DbField(true, DbFieldName = "Id")]
        public string Id { get; set; }

        [DbField(DbFieldName = "CreateDate", DbFieldType = DbDataType.DATETIME, IsNotNull = true)]
        public DateTime CreateDate { get; set; }

        [DbField(DbFieldName = "CreateUserId", DbFieldType = DbDataType.UNIQUEIDENTIFIER, IsNotNull = true)]
        public string CreateUserId { get; set; }

        [DbField(DbFieldName = "LastUpdateDate", DbFieldType = DbDataType.DATETIME, IsNotNull = true)]
        public DateTime LastUpdateDate { get; set; }

        [DbField(DbFieldName = "LastUpdateUserId", DbFieldType = DbDataType.UNIQUEIDENTIFIER, IsNotNull = true)]
        public string LastUpdateUserId { get; set; }

        [DbField(DbFieldName = "CurrentVersion", DbFieldType = DbDataType.INT, DefaultValue = "1", IsNotNull = true)]
        public int CurrentVersion { get; set; }
    }
}
