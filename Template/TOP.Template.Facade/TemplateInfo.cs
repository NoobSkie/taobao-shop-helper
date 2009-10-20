using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.Logic;
using TOP.Common.DbHelper;

namespace TOP.Template.Facade
{
    [DbTable(DbTableName = "v_Template_All", DbObjectType = DbObjectType.View)]
    public class TemplateInfo : FacadeInfoBase
    {
        [DbField(DbFieldName = "Name", DbFieldType = DbDataType.NVARCHAR, Length = 100)]
        public string Name { get; set; }
    }
}
