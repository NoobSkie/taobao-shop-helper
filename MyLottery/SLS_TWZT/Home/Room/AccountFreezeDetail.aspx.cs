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

public partial class Home_Room_AccountFreezeDetail : RoomPageBase, IRequiresSessionState
{

    private void BindData()
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(base._Site.ID.ToString() + "AccountFreezeDetail_" + base._User.ID.ToString());
        if (cacheAsDataTable == null)
        {
            int returnValue = 0;
            string returnDescription = "";
            DataSet ds = null;
            Procedures.P_GetUserFreezeDetail(ref ds, base._Site.ID, base._User.ID, ref returnValue, ref returnDescription);
            if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(4, "数据库繁忙，请重试", "Room_AccountFreezeDetail");
                return;
            }
            cacheAsDataTable = ds.Tables[0];
            Shove._Web.Cache.SetCache(base._Site.ID.ToString() + "AccountFreezeDetail_" + base._User.ID.ToString(), cacheAsDataTable);
        }
        PF.DataGridBindData(this.g, cacheAsDataTable);
        if (((this.gPager.PageIndex + 1) * this.gPager.PageSize) > cacheAsDataTable.Rows.Count)
        {
            this.lblPageFreezeCount.Text = (cacheAsDataTable.Rows.Count % this.gPager.PageSize).ToString();
        }
        else
        {
            this.lblPageFreezeCount.Text = this.gPager.PageSize.ToString();
        }
        this.lblPageFreezeSum.Text = PF.GetSumByColumn(cacheAsDataTable, 1, true, this.gPager.PageSize, this.gPager.PageIndex).ToString("N");
        this.lblTotalFreezeCount.Text = cacheAsDataTable.Rows.Count.ToString();
        this.lblTotalFreezeSum.Text = PF.GetSumByColumn(cacheAsDataTable, 1, false, this.gPager.PageSize, this.gPager.PageIndex).ToString("N");
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[1].Text = _Convert.StrToDouble(e.Item.Cells[1].Text, 0.0).ToString("N");
        }
    }

    protected void g_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        this.BindData();
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
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
            this.BindData();
        }
    }
}

