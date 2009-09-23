using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Authorize.Facade
{
    public class SecurityFacade
    {
        /// <summary>
        /// 检查用户是否具有权限访问指定URL的页面
        /// </summary>
        /// <param name="userId">用户Id，GUID格式。不能为null，不能为""。</param>
        /// <param name="url">指定页面的URL</param>
        /// <param name="appRelativeVirtualPath">应用程序关联的相对虚拟目录路径</param>
        /// <returns>是：有访问权限；否：无访问权限。</returns>
        public bool CheckIfCanAccessPage(string userId, string url, string appRelativeVirtualPath)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException("UserId", "验证权限，用户不能为空。");
            }
            return false;
        }
    }
}
