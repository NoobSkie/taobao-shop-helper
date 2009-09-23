using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Authorize.Domain
{
    public abstract class CtrlList<T> : List<T>
        where T : CtrlItem
    {
    }
}
