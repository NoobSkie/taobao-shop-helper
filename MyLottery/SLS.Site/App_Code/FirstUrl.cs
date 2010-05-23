using Shove;
using Shove._Web;
using System;
using System.Web;

namespace SLS.Site.App_Code
{
    public class FirstUrl
    {
        private string CpsIDKey = "SLS.TWZT.CpsID";
        private string DefaultUrl = Utility.GetUrlWithoutHttp();
        private string Key = "FirstUrl";
        private string PidKey = "SLS.TWZT.UnionPid";
        private string UserIDKey = "SLS.TWZT.UnionUserID";

        public string Get()
        {
            object obj2 = HttpContext.Current.Session[this.Key];
            if ((obj2 != null) && !string.IsNullOrEmpty(obj2.ToString()))
            {
                return obj2.ToString();
            }
            return this.DefaultUrl;
        }

        public void Save()
        {
            if (HttpContext.Current.Session[this.Key] == null)
            {
                long num = _Convert.StrToLong(Utility.GetRequest("cpsid"), -1L);
                long num2 = _Convert.StrToLong(Utility.GetRequest("ID"), -1L);
                string str = Utility.FilteSqlInfusion(Utility.GetRequest("PID"));
                if (!string.IsNullOrEmpty(str))
                {
                    HttpContext.Current.Session[this.PidKey] = str;
                }
                HttpContext.Current.Session[this.CpsIDKey] = num;
                HttpContext.Current.Session[this.UserIDKey] = num2;
                HttpContext.Current.Session[this.Key] = this.DefaultUrl;
            }
        }

        public string CpsID
        {
            get
            {
                if (HttpContext.Current.Session[this.CpsIDKey] != null)
                {
                    return HttpContext.Current.Session[this.CpsIDKey].ToString();
                }
                return string.Empty;
            }
        }

        public string PID
        {
            get
            {
                if (HttpContext.Current.Session[this.PidKey] != null)
                {
                    return HttpContext.Current.Session[this.PidKey].ToString();
                }
                return string.Empty;
            }
        }

        public string USERID
        {
            get
            {
                if (HttpContext.Current.Session[this.UserIDKey] != null)
                {
                    return HttpContext.Current.Session[this.UserIDKey].ToString();
                }
                return string.Empty;
            }
        }
    }
}
