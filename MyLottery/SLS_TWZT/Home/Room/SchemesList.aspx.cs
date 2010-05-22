using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_SchemesList : SitePageBase, IRequiresSessionState
{

    private void BindDataForType()
    {
        int num = 7;
        try
        {
            num = int.Parse(this.ViewState["Home_Lottery_Shssl_Play_Type"].ToString());
        }
        catch
        {
            num = 7;
        }
        if ((num < 1) || (num > 7))
        {
            PF.GoError(1, "参数错误", base.GetType().FullName);
        }
        else
        {
            DataTable table = new Tables.T_Isuses().Open("top 1 ID", "StartTime < Getdate() and LotteryID=" + this.HidLotteryID.Value, " EndTime desc");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
            }
            else if (table.Rows.Count != 0)
            {
                string str = table.Rows[0]["ID"].ToString();
                string str2 = string.Concat(new object[] { "SiteID = ", base._Site.ID, " and IsuseID = ", str, " and LotteryID = ", this.HidLotteryID.Value });
                string key = "";
                switch (num)
                {
                    case 1:
                        key = "select SchemeNumber, InitiateName, Level, Money, PlayTypeName, Schedule, ID, InitiateUserID, QuashStatus, PlayTypeID, Buyed, SecrecyLevel, EndTime, IsOpened, LotteryNumber, IsuseName from V_Schemes with (nolock) where " + str2 + " and [Money] >= 1000 order by QuashStatus, AtTopStatus desc, ReSchedule desc, [Money] desc";
                        break;

                    case 2:
                        key = "select SchemeNumber, InitiateName, Level, Money, PlayTypeName, Schedule, ID, InitiateUserID, QuashStatus, PlayTypeID, Buyed, SecrecyLevel, EndTime, IsOpened, LotteryNumber, IsuseName from V_Schemes with (nolock) where " + str2 + " and [Money] < 1000 order by QuashStatus, AtTopStatus desc, ReSchedule desc, [Money] desc";
                        break;

                    case 3:
                        key = "select SchemeNumber, InitiateName, Level, Money, PlayTypeName, Schedule, ID, InitiateUserID, QuashStatus, PlayTypeID, Buyed, SecrecyLevel, EndTime, IsOpened, LotteryNumber, IsuseName from V_Schemes with (nolock) where " + str2 + " and Share = BuyedShare order by QuashStatus, AtTopStatus desc, ReSchedule desc, [Money] desc";
                        break;

                    case 4:
                        key = "select SchemeNumber, InitiateName, Level, Money, PlayTypeName, Schedule, ID, InitiateUserID, QuashStatus, PlayTypeID, Buyed, SecrecyLevel, EndTime, IsOpened, LotteryNumber, IsuseName from V_Schemes with (nolock) where " + str2 + " and Share > BuyedShare order by QuashStatus, AtTopStatus desc, ReSchedule desc, [Money] desc";
                        break;

                    case 5:
                        key = "select SchemeNumber, InitiateName, Level, Money, PlayTypeName, Schedule, ID, InitiateUserID, QuashStatus, PlayTypeID, Buyed, SecrecyLevel, EndTime, IsOpened, LotteryNumber, IsuseName from V_Schemes with (nolock) where " + str2 + " and (QuashStatus <> 0) order by AtTopStatus desc, ReSchedule desc, [Money] desc";
                        break;

                    case 6:
                        key = "select SchemeNumber, InitiateName, Level, Money, PlayTypeName, Schedule, ID, InitiateUserID, QuashStatus, PlayTypeID, Buyed, SecrecyLevel, EndTime, IsOpened, LotteryNumber, IsuseName from V_Schemes with (nolock) where " + str2 + " and AssureMoney > 0 order by QuashStatus, AtTopStatus desc, ReSchedule desc, [Money] desc";
                        break;

                    case 7:
                        key = "select SchemeNumber, InitiateName, Level, Money, PlayTypeName, Schedule, ID, InitiateUserID, QuashStatus, PlayTypeID, Buyed, SecrecyLevel, EndTime, IsOpened, LotteryNumber, IsuseName from V_Schemes with (nolock) where " + str2 + " order by QuashStatus, AtTopStatus desc, ReSchedule desc, [Money] desc";
                        break;
                }
                DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
                if (cacheAsDataTable == null)
                {
                    cacheAsDataTable = MSSQL.Select(key, new MSSQL.Parameter[0]);
                    if (cacheAsDataTable == null)
                    {
                        PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
                        return;
                    }
                    Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
                }
                PF.DataGridBindData(this.g, cacheAsDataTable, this.gPager);
                this.gPager.Visible = true;
            }
        }
    }

    protected void btnType_1_Click(object sender, EventArgs e)
    {
        int num = _Convert.StrToInt(((LinkButton)sender).ID.Substring(8, 1), 7);
        this.ViewState["Home_Lottery_Shssl_Play_Type"] = num;
        this.BindDataForType();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[0].Text = "<a href='Scheme.aspx?id=" + e.Item.Cells[9].Text + "' target=\"_blank\"><font color='#000000'>" + e.Item.Cells[0].Text + "</font></a>";
            if (e.Item.Cells[1].Text.Trim().Length > 0x18)
            {
                e.Item.Cells[1].Text = "<font color='#000000'>" + e.Item.Cells[1].Text.Substring(0, 0x18) + "*</font>";
            }
            else
            {
                e.Item.Cells[1].Text = "<font color='#000000'>" + e.Item.Cells[1].Text + "</font>";
            }
            double num = _Convert.StrToDouble(e.Item.Cells[2].Text, 0.0);
            e.Item.Cells[2].Text = "";
            for (int i = 0; i < num; i++)
            {
                TableCell cell1 = e.Item.Cells[2];
                cell1.Text = cell1.Text + "<img src='Images/gold.gif' border='0'>";
            }
            double num3 = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            e.Item.Cells[4].Text = (num3 == 0.0) ? "" : num3.ToString("N");
            short num4 = _Convert.StrToShort(e.Item.Cells[11].Text, 0);
            bool flag = _Convert.StrToBool(e.Item.Cells[13].Text, false);
            short num5 = _Convert.StrToShort(e.Item.Cells[14].Text, 0);
            bool flag2 = _Convert.StrToDateTime(e.Item.Cells[15].Text, DateTime.Now.ToString()) <= DateTime.Now;
            bool flag3 = _Convert.StrToBool(e.Item.Cells[8].Text, false);
            long num6 = _Convert.StrToLong(e.Item.Cells[11].Text, 0L);
            if (((num5 == 1) && !flag2) && ((base._User == null) || (((base._User != null) && (num6 != base._User.ID)) && !base._User.isOwnedViewSchemeCompetence())))
            {
                e.Item.Cells[3].Text = "<font color=\"red\"><a href='Scheme.aspx?id=" + e.Item.Cells[9].Text + "' target='_blank'><font color=\"red\">已保密，截止后公开</a></Font>";
            }
            else if (((num5 == 2) && !flag3) && ((base._User == null) || (((base._User != null) && (num6 != base._User.ID)) && !base._User.isOwnedViewSchemeCompetence())))
            {
                e.Item.Cells[3].Text = "<font color=\"red\"><a href='Scheme.aspx?id=" + e.Item.Cells[9].Text + "' target='_blank'><font color=\"red\">已保密，开奖后公开</a></Font>";
            }
            else if ((num5 == 3) && ((base._User == null) || (((base._User != null) && (num6 != base._User.ID)) && !base._User.isOwnedViewSchemeCompetence())))
            {
                e.Item.Cells[3].Text = "<font color=\"red\"><a href='Scheme.aspx?id=" + e.Item.Cells[9].Text + "' target='_blank'><font color=\"red\">已保密</a></Font>";
            }
            else
            {
                e.Item.ToolTip = e.Item.Cells[3].Text.Trim();
                if (e.Item.Cells[3].Text.Trim().Length > 40)
                {
                    e.Item.Cells[3].Text = "<a href='Scheme.aspx?id=" + e.Item.Cells[9].Text + "' target='_blank'><font color=\"red\">投注内容</Font></a>";
                }
                else
                {
                    e.Item.Cells[3].Text = "<a href='Scheme.aspx?id=" + e.Item.Cells[9].Text + "' target='_blank'><font color=\"red\">" + e.Item.Cells[3].Text + "</Font></a>";
                }
            }
            TableCell cell2 = e.Item.Cells[7];
            cell2.Text = cell2.Text + "%";
            switch (num4)
            {
                case 0:
                    if (flag)
                    {
                        e.Item.Cells[8].Text = "<Font color='Red'>已成功</font>";
                        return;
                    }
                    if (e.Item.Cells[7].Text == "100%")
                    {
                        e.Item.Cells[8].Text = "<Font color='Red'>满员</font>";
                        return;
                    }
                    if (flag2)
                    {
                        e.Item.Cells[8].Text = "未成功";
                        return;
                    }
                    e.Item.Cells[8].Text = "未满";
                    return;

                case 2:
                    e.Item.Cells[10].Text = "<font color='blue'>撤单</font>";
                    return;

                default:
                    e.Item.Cells[10].Text = "撤单";
                    return;
            }
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindDataForType();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindDataForType();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.HidLotteryID.Value = Utility.GetRequest("LotteryID");
            this.BindDataForType();
        }
    }
}

