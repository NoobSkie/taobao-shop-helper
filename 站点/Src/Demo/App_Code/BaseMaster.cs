using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

public class BaseMaster : System.Web.UI.MasterPage
{
    /// <summary>
    /// 站点名称
    /// </summary>
    public string SiteName
    {
        get
        {
            string name = "天之歌音乐教育";
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SiteName"]))
            {
                name = ConfigurationManager.AppSettings["SiteName"];
            }
            return name;
        }
    }
}
