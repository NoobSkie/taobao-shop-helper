using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_OnlinePay_CardPassword_Default : RoomPageBase, IRequiresSessionState
{
    public string Balance;
    public string UserName;

    protected void btnOK_Click(object sender, EventArgs e)
    {
        int freeze = 0;
        int returnValue = 0;
        string returnDescription = "";
        if ((Procedures.P_CardPasswordTryErrorFreeze(base._Site.ID, base._User.ID, ref freeze, ref returnValue, ref returnDescription) < 0) || (returnValue < 0))
        {
            PF.GoError(4, "数据库繁忙，请重试", "Room_ViewChase");
        }
        else if (freeze > 0)
        {
            JavaScript.Alert(this.Page, "您输入错误的卡密号码次数过多，系统已经暂时锁定。" + freeze.ToString() + "分钟后才可以使用卡密支付功能。");
        }
        else
        {
            string str2 = _Convert.ToDBC(this.tbCardPassword.Text.Trim());
            if (string.IsNullOrEmpty(str2))
            {
                JavaScript.Alert(this.Page, "请输入充值卡密。");
            }
            else
            {
                Thread.Sleep(0x3e8);
                if (!Regex.IsMatch(str2, @"^[\d]{20}$", RegexOptions.Compiled | RegexOptions.IgnoreCase))
                {
                    returnValue = 0;
                    returnDescription = "";
                    Procedures.P_CardPasswordTryErrorAdd(base._User.ID, str2, ref returnValue, ref returnDescription);
                    JavaScript.Alert(this.Page, "您输入的卡密号码错误!");
                }
                else if (str2.Substring(0, 4) == "1008")
                {
                    base.Response.Redirect("CardPasswordValid.aspx?Num=" + str2);
                }
                else
                {
                    returnDescription = "";
                    if (new CardPassword().Use(str2, base._Site.ID, base._User.ID, ref returnDescription) < 0)
                    {
                        JavaScript.Alert(this.Page, returnDescription);
                    }
                    else
                    {
                        JavaScript.Alert(this.Page, "卡密充值成功, 请点击“查看我的账户”查看投注卡账户余额情况。");
                    }
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            this.Balance = base._User.Balance.ToString();
            this.UserName = base._User.Name.ToString();
        }
    }

 
}

