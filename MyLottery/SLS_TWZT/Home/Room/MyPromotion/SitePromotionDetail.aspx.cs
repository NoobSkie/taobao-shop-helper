using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_MyPromotion_SitePromotionDetail : RoomPageBase, IRequiresSessionState
{


    private void BindUserAccount()
    {
        string request = Utility.GetRequest("dt");
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("SiteID={0} and Buyed=1 and replace(CONVERT(char(10),[DateTime],111),'/','-')='{1}' ", base._Site.ID, request);
        builder.AppendFormat("and UserID in (Select ID from T_Users where CpsID in (Select ID from T_Cps where CommendID={0})) ", base._User.ID);
        DataTable dt = new Views.V_BuyDetails().Open("IsuseName, SchemeNumber, LotteryName, PlayTypeName,Money,DetailMoney, DateTime", builder.ToString(), "DateTime desc");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
            this.gPager.Visible = this.g.PageCount > 1;
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            e.Item.Cells[4].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            e.Item.Cells[5].Text = (num == 0.0) ? "" : num.ToString("N");
            e.Item.Cells[6].Text = _Convert.StrToDateTime(e.Item.Cells[6].Text, "2009-01-01").ToShortDateString();
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindUserAccount();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindUserAccount();
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindUserAccount();
        }
    }

  
}

