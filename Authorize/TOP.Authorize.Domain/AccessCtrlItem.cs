using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Authorize.Domain
{
    /// <summary>
    /// 访问控制项
    /// </summary>
    public abstract class AccessCtrlItem : CtrlItem
    {
        /// <summary>
        /// 所属功能
        /// </summary>
        public FunctionItem ItsFunction { get; set; }

        /// <summary>
        /// 可访问性类型
        /// </summary>
        public AccessibilityType AccessibilityType { get; set; }

        /// <summary>
        /// 访问控制项描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 检查是否具有权限
        /// </summary>
        /// <param name="code">返回代码</param>
        /// <param name="message">返回消息</param>
        /// <param name="args">参数列表</param>
        /// <returns>是，否。</returns>
        public abstract bool CheckAccess(out string code, out string message, params string[] args);
    }
}
