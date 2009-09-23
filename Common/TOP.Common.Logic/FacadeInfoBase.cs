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
    }
}
