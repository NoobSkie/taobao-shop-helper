using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Home_Room_CheckCpsState : Page, IRequiresSessionState
{

    protected void Page_Load(object sender, EventArgs e)
    {
        FirstUrl url = new FirstUrl();
        string s = (("<br/>URL:" + url.Get()) + "<br/>CPSID:" + url.CpsID) + "<br/>PID:" + url.PID;
        base.Response.Write(s);
    }
}

