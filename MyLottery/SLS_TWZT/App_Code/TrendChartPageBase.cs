using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class TrendChartPageBase : Page
{
    public Sites _Site;
    public int CacheSeconds = 0xe10;
    public string PageUrl;
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
        if (this.CacheSeconds > 0)
        {
            base.Response.Cache.SetExpires(DateTime.Now.AddSeconds((double)this.CacheSeconds));
            base.Response.Cache.SetCacheability(HttpCacheability.Server);
            base.Response.Cache.VaryByParams["*"] = true;
            base.Response.Cache.SetValidUntilExpires(true);
            base.Response.Cache.SetVaryByCustom("SitePage");
        }
        this._Site = new Sites()[1L];
        if (this._Site == null)
        {
            PF.GoError(1, "域名无效，限制访问", base.GetType().FullName);
        }
        else
        {
            this.PageUrl = base.Request.Url.AbsoluteUri;
            base.OnLoad(e);
        }
    }
}

