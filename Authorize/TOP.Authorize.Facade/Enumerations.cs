using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Authorize.Facade
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

    /// <summary>
    /// 权限控制类型
    /// </summary>
    public enum ControlType
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,
        /// <summary>
        /// 控制功能权限
        /// </summary>
        Function = 1,
        /// <summary>
        /// 控制数据权限
        /// </summary>
        Data = 2,
    }
}
