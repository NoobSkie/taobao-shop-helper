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

public partial class Home_Web_Agreement : SitePageBase, IRequiresSessionState
{

    private void BindData(int LotteryID)
    {
        string key = "LotteryAgreements";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Lotteries().Open("[ID],[Code],[Agreement]", "[ID] in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "");
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
            {
                PF.GoError(7, "数据库繁忙，请重试", base.GetType().FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        DataRow[] rowArray = cacheAsDataTable.Select("[ID] = " + LotteryID.ToString());
        if (rowArray.Length > 0)
        {
            this.lbAgreement.Text = rowArray[0]["Agreement"].ToString().ToLower().Replace("[sitename]", base._Site.Name).Replace("[siteurl]", Utility.GetUrl());
            this.imgLogo.ImageUrl = "images/" + rowArray[0]["Code"].ToString().ToLower() + ".jpg";
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            int lotteryID = _Convert.StrToInt(Utility.GetRequest("LotteryID"), 5);
            if ((((lotteryID != 5) && (lotteryID != 6)) && ((lotteryID != 13) && (lotteryID != 0x1d))) && (((lotteryID != 0x3a) && (lotteryID != 0x3b)) && (lotteryID != 60)))
            {
                lotteryID = 5;
            }
            this.BindData(lotteryID);
        }
    }
}

