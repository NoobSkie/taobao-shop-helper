using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Authorize.Facade
{
    /// <summary>
    /// 功能页面
    /// </summary>
    public class FunctionPage
    {
        public string Id { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 相对目录
        /// </summary>
        public string RelativeDirectory { get; set; }

        /// <summary>
        /// 应用程序关联路径
        /// </summary>
        public string AppRelativeUrl { get; set; }

        public bool IsParent { get; set; }

        public string ParentId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
