using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_MyPromotion_PromoteSiteBuyDetail : RoomPageBase, IRequiresSessionState
{

    private void BindBuyDetailData()
    {
        long cpsID = _Convert.StrToLong(Utility.GetRequest("CpsID"), -1L);
        DateTime fromTime = _Convert.StrToDateTime(this.tbBeginTime.Text + " 0:0:0", DateTime.Now.ToString());
        DateTime toTime = _Convert.StrToDateTime(this.tbEndTime.Text + " 23:59:59", DateTime.Now.ToString());
        if (cpsID < 1L)
        {
            PF.GoError(1, "参数错误", base.GetType().BaseType.FullName);
        }
        else
        {
            string key = string.Concat(new object[] { "Home_Room_MyPromotion_PromoteSiteBuyDetail_", base._User.ID, "_", cpsID, "_", fromTime.ToString("yyyyMMdd"), toTime.ToString("yyyyMMdd") });
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                int returnValue = -1;
                string returnDescription = "";
                DataSet ds = null;
                if (Procedures.P_CpsGetCommendSiteBuyDetail(ref ds, base._Site.ID, base._User.ID, cpsID, -1L, fromTime, toTime, ref returnValue, ref returnDescription) < 0)
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
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (!_String.Valid.isDate(this.tbBeginTime.Text) || !_String.Valid.isDate(this.tbEndTime.Text))
        {
            JavaScript.Alert(this.Page, "请输正确的查询日期格式.如 2009-01-01");
        }
        else
        {
            this.BindBuyDetailData();
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindBuyDetailData();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindBuyDetailData();
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
            this.BindBuyDetailData();
            if ((base.Request["StartTime"] != null) && (base.Request["EndTime"] != null))
            {
                this.tbBeginTime.Text = _Convert.StrToDateTime(Utility.GetRequest("StartTime") + " 0:0:0", DateTime.Now.ToString()).ToString("yyyy-MM-dd");
                this.tbEndTime.Text = _Convert.StrToDateTime(Utility.GetRequest("EndTime") + " 23:59:59", DateTime.Now.ToString()).ToString("yyyy-MM-dd");
            }
            else
            {
                this.tbBeginTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.tbEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
    }

   
}

