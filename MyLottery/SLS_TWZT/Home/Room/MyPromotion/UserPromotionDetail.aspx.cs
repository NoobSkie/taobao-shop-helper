using ASP;
using DAL;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_MyPromotion_UserPromotionDetail : RoomPageBase, IRequiresSessionState
{
 
    private void BindUserAccount()
    {
        string request = Utility.GetRequest("dt");
        DateTime now = DateTime.Now;
        DateTime toTime = DateTime.Now;
        try
        {
            now = Convert.ToDateTime(request + " 0:0:0");
            toTime = now.AddDays(1.0);
        }
        catch
        {
            JavaScript.Alert(this.Page, "参数出错!");
            return;
        }
        string key = string.Concat(new object[] { "Home_Room_MyPromotion_UserPromotionDetail_", base._User.ID, "_", now.ToString("yyyyMMdd"), toTime.ToString("yyyyMMdd") });
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            int returnValue = -1;
            string returnDescription = "";
            DataSet ds = null;
            if (Procedures.P_CpsGetCommendMemberBuyDetail(ref ds, base._Site.ID, base._User.ID, -1L, now, toTime, ref returnValue, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            if (returnValue < 0)
            {
                JavaScript.Alert(this.Page, returnDescription);
                return;
            }
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            cacheAsDataTable = ds.Tables[0];
            Shove._Web.Cache.SetCache(key, cacheAsDataTable);
        }
        PF.DataGridBindData(this.g, cacheAsDataTable, this.gPager);
        this.gPager.Visible = this.g.PageCount > 1;
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

