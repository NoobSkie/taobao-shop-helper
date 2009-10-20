using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.DbHelper;

namespace TOP.Common.Logic
{
    public abstract class FacadeInfoBase
    {
        [DbField(DbFieldName = "Id", DbFieldType = DbDataType.UNIQUEIDENTIFIER, DefaultValue = "NEWID()", IsNotNull = true)]
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

        public static T GetEmptyObject<T>()
            where T : FacadeInfoBase, new()
        {
            T t = new T();
            t.Id = Guid.Empty.ToString();
            return t;
        }
    }
}
