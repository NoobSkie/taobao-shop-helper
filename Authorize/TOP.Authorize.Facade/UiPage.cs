using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Authorize.Facade
{
    /// <summary>
    /// 界面页面
    /// </summary>
    public class UiPage
    {
        public UiPage()
        {
        }

        public UiPage(string url, string appRelativeDirectory)
        {
            AnalyseUrl(url, appRelativeDirectory);
        }

        #region 系统扩展属性

        public string PageCode { get; set; }

        public string PageName { get; set; }

        public string Description { get; set; }

        #endregion

        #region 链接自身属性

        /// <summary>
        /// 原始页面路径字符串。
        /// http://localhost:808/TaobaoShopHelper/TestPages/TestStyles.aspx?a=a1&b=b1
        /// </summary>
        public string OrginUrl { get; set; }

        /// <summary>
        /// 原始应用程序关联文件夹。
        /// ~/TestPages/
        /// </summary>
        public string OrginAppRelativeDirectory { get; set; }

        /// <summary>
        /// 域名，包括端口号。localhost:808
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// 虚拟目录名称。TaobaoShopHelper
        /// </summary>
        public string VirtualName { get; set; }

        /// <summary>
        /// 相对路径，不包括虚拟目录名。/TestPages/
        /// </summary>
        public string RelativeDirectory { get; set; }

        /// <summary>
        /// 文件名。TestStyles.aspx
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 参数字符串。a=a1&b=b1
        /// </summary>
        private string _ParameterString;
        public string ParameterString
        {
            get
            {
                return _ParameterString;
            }
            set
            {
                _ParameterString = value;

                Parameters = AnalyseParameters(_ParameterString);
                IsHasParamters = !string.IsNullOrEmpty(_ParameterString);
            }
        }

        /// <summary>
        /// 是否具有参数。
        /// </summary>
        public bool IsHasParamters { get; private set; }

        private Dictionary<string, string> _Parameters;
        /// <summary>
        /// 参数列表。由参数字符串解析而来。
        /// </summary>
        public Dictionary<string, string> Parameters
        {
            get
            {
                if (_Parameters == null)
                {
                    _Parameters = new Dictionary<string, string>();
                }
                return _Parameters;
            }
            private set
            {
                _Parameters = value;
            }
        }

        #endregion

        #region 链接地址分析

        public void AnalyseUrl(string url, string appRelativeDirectory)
        {
            OrginUrl = url;
            OrginAppRelativeDirectory = appRelativeDirectory;
            // ~/TestPages/     ->     /TestPages/
            appRelativeDirectory = appRelativeDirectory.TrimStart('~');
            int flagIndex = url.IndexOf("?");
            if (flagIndex >= 0)
            {
                // 如果页面链接包含参数，则设置并解析参数。
                // a=a1&b=b1
                ParameterString = url.Substring(flagIndex + 1);
                // 截取页面链接的文件部分。
                // http://localhost:808/TaobaoShopHelper/TestPages/TestStyles.aspx
                url = url.Substring(0, flagIndex);
            }
            int domainIndex = url.IndexOf("://");
            if (domainIndex >= 0)
            {
                // localhost:808/TaobaoShopHelper/TestPages/TestStyles.aspx
                url = url.Substring(domainIndex + 3);
            }
            int firstIndex = url.IndexOf("/");
            int lastIndex = url.LastIndexOf("/");
            // localhost:808
            DomainName = url.Substring(0, firstIndex);
            // TestStyles.aspx
            FileName = url.Substring(lastIndex + 1);
            // TaobaoShopHelper/TestPages/TestStyles.aspx
            url = url.Substring(firstIndex + 1);
            // /TestPages/
            RelativeDirectory = appRelativeDirectory;
            // 查询/TestPages/TestStyles.aspx位置
            int virtualIndex = url.IndexOf(RelativeDirectory + FileName);
            if (virtualIndex >= 0)
            {
                VirtualName = url.Substring(0, virtualIndex);
            }
        }

        public Dictionary<string, string> AnalyseParameters(string parameterString)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (string field in parameterString.Split('&'))
            {
                string[] keyValue = field.Split('=');
                if (keyValue.Length == 1)
                {
                    parameters.Add(keyValue[0], string.Empty);
                }
                else
                {
                    parameters.Add(keyValue[0], keyValue[1]);
                }
            }
            return parameters;
        }

        #endregion
    }
}
