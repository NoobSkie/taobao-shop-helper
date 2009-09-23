using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Authorize.Facade
{
    /// <summary>
    /// 功能访问控制项
    /// </summary>
    public class AccessFunctionControlItem : AccessControlItem
    {
        public override bool CheckAccess(out string code, out string message, params string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
