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
    }
}
