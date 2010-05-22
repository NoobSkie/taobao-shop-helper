using ASP;
using Shove._Web;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_Distill : RoomPageBase, IRequiresSessionState
{
    public string IsCps = "0";

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.IsCps = Utility.GetRequest("IsCps");
            if (string.IsNullOrEmpty(this.IsCps))
            {
                this.IsCps = "0";
            }
            if (this.IsCps == "1")
            {
                this.tdDistill.InnerHtml = "我的推广佣金";
                this.imgDistill.Src = "images/icon_13.gif";
            }
            this.distillFrame.Attributes.Add("onload", "handleOnLoad()");
        }
    }
}

