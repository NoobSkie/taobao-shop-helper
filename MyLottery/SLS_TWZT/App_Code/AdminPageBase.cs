using System;
using System.Web.UI;
using Shove._IO;

public class AdminPageBase : Page
{
    public Sites _Site;
    public Users _User;
    public bool isAtFramePageLogin = true;
    public bool isRequestLogin = true;
    public string PageUrl;
    public string RequestCompetences = "";
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
        this._Site = new Sites()[1L];
        if (this._Site == null)
        {
            PF.GoError(1, "域名无效，限制访问", base.GetType().FullName);
        }
        else
        {
            this._User = Users.GetCurrentUser(this._Site.ID);
            if (this.isRequestLogin && (this._User == null))
            {
                PF.GoLogin(this.RequestLoginPage, this.isAtFramePageLogin);
            }
            else if ((this.isRequestLogin && (this.RequestCompetences != "")) && !this._User.Competences.IsOwnedCompetences(this.RequestCompetences))
            {
                PF.GoError(3, "对不起，您没有足够的权限访问此页面", base.GetType().FullName);
            }
            else
            {
                this.PageUrl = base.Request.Url.AbsoluteUri;
                base.OnLoad(e);
            }
        }
    }
}

