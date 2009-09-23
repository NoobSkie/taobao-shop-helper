using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Authorize.Facade
{
    /// <summary>
    /// 控制项列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ControlList<T> : List<T>
        where T : ControlItem
    {
    }
}
