using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.DbHelper;

namespace TOP.Authorize.Domain
{
    [DbTable(DbTableName = "SystemUser", DbObjectType = DbObjectType.Table)]
    public class User : DbEntity
    {
        [DbField(DbFieldName = "LoginName", DbFieldType = DbDataType.NVARCHAR, IsNotNull = true, Length = 20)]
        public string LoginName { get; set; }

        [DbField(DbFieldName = "UserName", DbFieldType = DbDataType.NVARCHAR, IsNotNull = true, Length = 60)]
        public string UserName { get; set; }
    }
}
