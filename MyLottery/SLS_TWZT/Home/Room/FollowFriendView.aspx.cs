using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_FollowFriendView : RoomPageBase, IRequiresSessionState
{

    private void BindData()
    {
        DataTable dt = MSSQL.Select("select a.*,b.Name from T_CustomFriendFollowSchemes a join T_Users b on a.UserID = b.ID where a.FollowUserID = " + this.HidID.Value, new MSSQL.Parameter[0]);
        if (dt == null)
        {
            PF.GoError(1, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            this.lbFollowCount.Text = dt.Rows.Count.ToString();
            PF.DataGridBindData(this.g, dt, this.gPager);
            this.gPager.Visible = true;
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            DataRow row = dataItem.Row;
            e.Item.Cells[0].Text = _Convert.StrToDateTime(row["DateTime"].ToString(), DateTime.Now.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            string key = "dtLotteriesUseLotteryList";
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Tables.T_Lotteries().Open("[ID], [Name], [Code]", "[ID] in(" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[ID]");
                if (cacheAsDataTable == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-39)");
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
            }
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-49)");
            }
            else
            {
                if (row["LotteryID"].ToString() == "-1")
                {
                    e.Item.Cells[2].Text = "全部彩种";
                }
                else
                {
                    e.Item.Cells[2].Text = cacheAsDataTable.Select("ID = " + row["LotteryID"].ToString())[0]["Name"].ToString();
                }
                key = "dtPlayTypes";
                DataTable table2 = Shove._Web.Cache.GetCacheAsDataTable(key);
                if (table2 == null)
                {
                    table2 = new Tables.T_PlayTypes().Open("", "LotteryID in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[ID]");
                    if ((table2 == null) || (table2.Rows.Count < 1))
                    {
                        PF.GoError(7, "数据库繁忙，请重试", base.GetType().FullName + "(-85)");
                        return;
                    }
                    Shove._Web.Cache.SetCache(key, table2, 0x1770);
                }
                if (table2 == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-95)");
                }
                else
                {
                    if (row["PlayTypeID"].ToString() == "-1")
                    {
                        e.Item.Cells[3].Text = "全部玩法";
                    }
                    else
                    {
                        e.Item.Cells[3].Text = table2.Select("ID = " + row["PlayTypeID"].ToString())[0]["Name"].ToString();
                    }
                    e.Item.Cells[4].Text = _Convert.StrToDouble(row["MoneyStart"].ToString(), 0.0).ToString("N") + "&nbsp;至&nbsp;" + _Convert.StrToDouble(row["MoneyEnd"].ToString(), 0.0).ToString("N") + " 元";
                    e.Item.Cells[5].Text = (row["Type"].ToString() == "1") ? "用户定制" : "发起人指定";
                }
            }
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindData();
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isRequestLogin = false;
        base.isAtFramePageLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.lbUserName.Text = HttpUtility.UrlDecode(Utility.GetRequest("FollowUserName"));
            int num = _Convert.StrToInt(Utility.GetRequest("ID"), -1);
            if ((num < 0) || (this.lbUserName.Text == ""))
            {
                PF.GoError(1, "参数错误，系统异常。", base.GetType().BaseType.FullName);
            }
            else
            {
                this.HidID.Value = num.ToString();
                this.BindData();
            }
        }
    }
}

