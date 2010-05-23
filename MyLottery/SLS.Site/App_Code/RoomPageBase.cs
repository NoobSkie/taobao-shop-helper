using SLS.Site.App_Code.DAL;
using Shove._Web;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shove._IO;

namespace SLS.Site.App_Code
{
    public class RoomPageBase : Page
    {
        public Sites _Site;
        public Users _User;
        public static string FloatNotifyPageList = WebConfig.GetAppSettingsString("FloatNotifyPageList");
        public static int FloatNotifyTimeOut = WebConfig.GetAppSettingsInt("FloatNotifyTimeOut", 0);
        public bool isAllowPageCache;
        public bool isAtFramePageLogin = true;
        public bool isRequestLogin = true;
        public int PageCacheSeconds;
        public string PageUrl;
        public string RequestLoginPage = "";
        public DateTime StartTime = DateTime.Now;

        public override void Dispose()
        {
            TimeSpan span = (TimeSpan)(DateTime.Now - this.StartTime);
            if (span.Seconds >= 10)
            {
                new Log("Page").Write("耗时：" + span.Minutes.ToString("00") + "分" + span.Seconds.ToString("00") + "秒" + span.Milliseconds.ToString("000") + "毫秒，" + this.PageUrl);
            }
            base.Dispose();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!base.IsPostBack)
            {
                new FirstUrl().Save();
            }
            this.PageUrl = base.Request.Url.AbsoluteUri;
            this._Site = new Sites()[1L];
            if (this._Site == null)
            {
                PF.GoError(1, "域名无效，限制访问", "SitePageBase");
            }
            else
            {
                this._User = Users.GetCurrentUser(this._Site.ID);
                if (this.isRequestLogin && (this._User == null))
                {
                    PF.GoLogin(this.RequestLoginPage, this.isAtFramePageLogin);
                }
                else
                {
                    try
                    {
                        PlaceHolder holder = this.Page.FindControl("phHead") as PlaceHolder;
                        if (holder != null)
                        {
                            UserControl child = this.Page.LoadControl("~/Home/Room/UserControls/WebHead.ascx") as UserControl;
                            holder.Controls.Add(child);
                        }
                        PlaceHolder holder2 = this.Page.FindControl("phFoot") as PlaceHolder;
                        if (holder2 != null)
                        {
                            UserControl control2 = this.Page.LoadControl("~/Home/Room/UserControls/WebFoot.ascx") as UserControl;
                            holder2.Controls.Add(control2);
                        }
                    }
                    catch
                    {
                    }
                    string str = ((base.Request.Url.Query == "") ? base.Request.Url.AbsoluteUri : base.Request.Url.AbsoluteUri.Replace(base.Request.Url.Query, "")).Replace(Utility.GetUrl(), "").Replace("/", "_").Replace(".aspx", "");
                    if (str.StartsWith("_"))
                    {
                        str = str.Remove(0, 1);
                    }
                    if (FloatNotifyPageList.IndexOf("," + str + ",") > -1)
                    {
                        StringBuilder builder = new StringBuilder();
                        string key = "FloatNotifyContent";
                        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
                        if (cacheAsDataTable == null)
                        {
                            cacheAsDataTable = new Tables.T_FloatNotify().Open("", "", "[Order] asc,[DateTime] desc");
                            if ((cacheAsDataTable != null) && (cacheAsDataTable.Rows.Count > 0))
                            {
                                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xea60);
                            }
                        }
                        bool flag = false;
                        int num = this._Site.SiteOptions["Opt_FloatNotifiesTime"].ToInt(3);
                        string name = "LastLoginShowFloatNotifyUserID";
                        switch (num)
                        {
                            case 1:
                                {
                                    HttpCookie cookie = base.Request.Cookies[name];
                                    if ((cookie != null) && !string.IsNullOrEmpty(cookie.Value))
                                    {
                                        flag = true;
                                    }
                                    break;
                                }
                            case 2:
                                flag = DateTime.Now.Minute == 0;
                                break;

                            case 3:
                                flag = true;
                                break;
                        }
                        if (((cacheAsDataTable != null) && (cacheAsDataTable.Rows.Count > 0)) && flag)
                        {
                            DataRow[] rowArray = cacheAsDataTable.Select("isShow=1");
                            for (int i = 0; i < rowArray.Length; i++)
                            {
                                if (i == 2)
                                {
                                    break;
                                }
                                int num4 = i + 1;
                                builder.Append("<font color='" + rowArray[i]["Color"].ToString() + "'>").Append(num4.ToString()).Append(".</font>").Append("<a href='").Append(rowArray[i]["Url"].ToString()).Append("' target='_blank' style='text-decoration: none;color:").Append(rowArray[i]["Color"].ToString()).Append(";' onmouseover=\"this.style.color='#ff6600';\" onmouseout=\"this.style.color='").Append(rowArray[i]["Color"].ToString()).Append("';\">").Append(rowArray[i]["Title"].ToString()).Append("</a><br />");
                            }
                            string html = HmtlManage.GetHtml(AppDomain.CurrentDomain.BaseDirectory + "Home/Web/Template/FloatNotify.html");
                            Label label = new Label();
                            int num5 = FloatNotifyTimeOut * 100;
                            label.Text = html.Replace("$FloatNotifyTimeOut$", num5.ToString()).Replace("$FloatNotifyContent$", builder.ToString());
                            try
                            {
                                base.Form.Controls.AddAt(0, label);
                            }
                            catch (Exception exception)
                            {
                                new Log("Page").Write(str + exception.Message);
                            }
                            HttpCookie cookie2 = new HttpCookie(name)
                            {
                                Value = "",
                                Expires = DateTime.Now.AddYears(-20)
                            };
                            try
                            {
                                HttpContext.Current.Response.Cookies.Add(cookie2);
                            }
                            catch
                            {
                            }
                        }
                    }
                    if (this.isAllowPageCache && (this.PageCacheSeconds > 0))
                    {
                        base.Response.Cache.SetExpires(DateTime.Now.AddSeconds((double)this.PageCacheSeconds));
                        base.Response.Cache.SetCacheability(HttpCacheability.Server);
                        base.Response.Cache.VaryByParams["*"] = true;
                        base.Response.Cache.SetValidUntilExpires(true);
                        base.Response.Cache.SetVaryByCustom("SitePage");
                    }
                    base.OnLoad(e);
                }
            }
        }
    }
}
