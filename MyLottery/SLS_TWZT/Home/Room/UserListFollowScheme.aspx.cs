using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using SLS;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_UserListFollowScheme : RoomPageBase, IRequiresSessionState
{
    public int i = 1;
    public int LotteryID;
    public string LotteryName;
    public string Name;
    public int PlayTypeID;
    public string PlayTypeName;
    public long UserID;

    private void BindData()
    {
        DataTable dt = new Views.V_CustomFollowSchemes().Open("[UserName],MoneyStart,[MoneyEnd],BuyShareStart,BuyShareEnd,[TypeName],Convert(varchar,[DateTime],120)[DateTime]", "UsersForInitiateFollowSchemeUserID = " + Utility.FilteSqlInfusion(this.tbUserID.Value) + " and PlayTypeID = " + Utility.FilteSqlInfusion(this.tbPlayTypeID.Value), "[DateTime] desc");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
        }
        else
        {
            this.lbCountUser.Text = dt.Rows.Count.ToString();
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
            e.Item.Cells[2].Text = _Convert.StrToDouble(row["MoneyStart"].ToString(), 0.0).ToString("N") + "&nbsp;至&nbsp;" + _Convert.StrToDouble(row["MoneyEnd"].ToString(), 0.0).ToString("N") + " 元";
        }
    }

    private void GetID()
    {
        this.LotteryID = _Convert.StrToInt(this.tbLotteryID.Value, -1);
        this.PlayTypeID = _Convert.StrToInt(this.tbPlayTypeID.Value, -1);
        this.UserID = _Convert.StrToInt(this.tbUserID.Value, -1);
        Lottery lottery = new Lottery();
        if (!lottery.ValidID(this.LotteryID))
        {
            PF.GoError(1, "参数错误，系统异常。", base.GetType().FullName);
        }
        else if (!lottery[this.LotteryID].CheckPlayType(this.PlayTypeID))
        {
            PF.GoError(1, "参数错误，系统异常。", base.GetType().FullName);
        }
        else
        {
            this.LotteryName = lottery[this.LotteryID].name;
            this.PlayTypeName = lottery.GetPlayTypeName(this.PlayTypeID);
            this.Name = new Users(1L)[1L, this.UserID].Name;
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
            this.tbLotteryID.Value = Utility.GetRequest("LotteryID");
            this.tbPlayTypeID.Value = Utility.GetRequest("PlayTypeID");
            this.tbUserID.Value = Utility.GetRequest("UserID");
            this.GetID();
            this.BindData();
        }
    }
}

