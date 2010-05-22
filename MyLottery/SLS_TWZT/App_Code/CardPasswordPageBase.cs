using System;
using System.Web.UI;

public class CardPasswordPageBase : Page
{
    public CardPasswordAgentUsers _CardPasswordAgentUser;
    public Sites _Site;
    public bool isAtFramePageLogin = true;
    public bool isRequestLogin = true;
    public string RequestLoginPage = "";

    protected override void OnLoad(EventArgs e)
    {
        this._Site = new Sites()[1L];
        if (this._Site == null)
        {
            PF.GoError(1, "域名无效，限制访问", base.GetType().FullName);
        }
        else
        {
            this._CardPasswordAgentUser = CardPasswordAgentUsers.GetCurrentUser();
            if (this.isRequestLogin && (this._CardPasswordAgentUser == null))
            {
                base.Response.Redirect("Login.aspx");
            }
            else
            {
                base.OnLoad(e);
            }
        }
    }
}

