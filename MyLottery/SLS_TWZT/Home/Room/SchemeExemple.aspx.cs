using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_SchemeExemple : RoomPageBase, IRequiresSessionState
{

    private void BindData(int id)
    {
        DataTable table = new Tables.T_Lotteries().Open("[ID],[Name],[SchemeExemple]", "[ID] = " + id.ToString() + " and [ID] in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Room_SchemeExemple");
        }
        else if (table.Rows.Count == 0)
        {
            JavaScript.ClosePage(this.Page);
        }
        else
        {
            this.labContent.Text = table.Rows[0]["SchemeExemple"].ToString().Replace("[SiteName]", base._Site.Name).Replace("[SiteUrl]", base._Site.Urls).Replace("[siteurl]", base._Site.Urls);
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.isRequestLogin = false;
        base.isAtFramePageLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = _Convert.StrToInt(Utility.GetRequest("id"), -1);
        if (id < 0)
        {
            PF.GoError(1, "参数错误", "Room_SchemeExemple");
        }
        else if (!base.IsPostBack)
        {
            this.BindData(id);
        }
    }

  
}

