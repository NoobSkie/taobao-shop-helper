using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Common.Logic
{
    public interface IQuery
    {
        string GenerateCreateViewSql(Type infoType, string baseDir);

        string GenerateDropViewSql(Type infoType, string baseDir);

        string GenerateSelectViewSql(Type infoType);

        string GenerateCountViewSql(Type infoType);
    }
}
