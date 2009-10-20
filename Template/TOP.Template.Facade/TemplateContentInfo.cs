using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.DbHelper;
using TOP.Common.Logic;

namespace TOP.Template.Facade
{
    [DbTable(DbTableName = "v_Template_All", DbObjectType = DbObjectType.View)]
    public class TemplateContentInfo : FacadeInfoBase
    {
        [DbField(DbFieldName = "Name", DbFieldType = DbDataType.NVARCHAR, Length = 100)]
        public string Name { get; set; }

        [DbField(DbFieldName = "Content", DbFieldType = DbDataType.NVARCHAR, Length = 0)]
        public string Content { get; set; }
    }
}
