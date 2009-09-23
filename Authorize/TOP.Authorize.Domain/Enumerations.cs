using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Authorize.Domain
{
    /// <summary>
    ///可访问性类型
    /// </summary>
    public enum AccessibilityType
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,
        /// <summary>
        /// 允许
        /// </summary>
        Allow = 1,
        /// <summary>
        /// 拒绝
        /// </summary>
        Deny = 2,
    }
}
