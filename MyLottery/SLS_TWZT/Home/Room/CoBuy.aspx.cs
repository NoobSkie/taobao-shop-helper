using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_CoBuy : RoomPageBase, IRequiresSessionState
{
    protected StringBuilder script = new StringBuilder();
    private void BindDataForType()
    {
        // This item is obfuscated and can not be translated.
        long num = _Convert.StrToLong(Utility.FilteSqlInfusion(this.HidIsuseID.Value), 0L);
        StringBuilder builder = new StringBuilder();
        string text1 = ((this.TxtName.Text.Trim() == "") || (this.TxtName.Text.Trim() == "输入用户名")) ? "" : (" and T_Users.Name like '%" + Utility.FilteSqlInfusion(this.TxtName.Text.Trim()) + "%' ");

        if (text1 != null && text1 != string.Empty)
        {
            builder.AppendLine("select SchemeNumber, InitiateName, Level, Money, d.Name as PlayTypeName, Share, Schedule, AssureMoney, a.ID, InitiateUserID, QuashStatus, PlayTypeID, Buyed, SecrecyLevel, EndTime, b.IsOpened, LotteryNumber,b.LotteryID ").AppendLine("from ").AppendLine("\t(").AppendLine("\t\tselect T_Schemes.ID,IsuseID,AtTopStatus,T_Users.Name as InitiateName, T_Users.Level, SchemeNumber,ReSchedule,Money,Share, Schedule, AssureMoney, InitiateUserID, QuashStatus, PlayTypeID, Buyed, SecrecyLevel, LotteryNumber ").AppendLine("\t\tfrom T_Schemes  left join T_Users  on T_Schemes.InitiateUserID = T_Users.id").AppendLine("\t\twhere IsuseID = @IsuseID and QuashStatus = 0 and Share > BuyedShare ").AppendLine(text1).AppendLine("\t\t\tand T_Schemes.SiteID = @SiteID ").AppendLine("\t)as a").AppendLine("inner join T_Isuses b on a.IsuseID = b.ID").AppendLine("inner join T_PlayTypes d on d.ID = a.PlayTypeID").AppendLine("order by AtTopStatus desc, ReSchedule desc, [Money] desc");
            string key = "Home_Room_CoBuy_BindDataForType" + this.HidIsuseID.Value;
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.BigInt, 0, ParameterDirection.Input, num), new MSSQL.Parameter("SiteID", SqlDbType.Int, 0, ParameterDirection.Input, base._Site.ID) });
                if (cacheAsDataTable == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
                    return;
                }
                if (cacheAsDataTable.Rows.Count > 0)
                {
                    Shove._Web.Cache.SetCache(key, cacheAsDataTable, ((this.HidLotteryID.Value == "29") || (this.HidLotteryID.Value == "62")) ? 60 : 600);
                }
            }
            if (this.HidLotteryID.Value == "1")
            {
                DataTable dt = cacheAsDataTable.Clone();
                DataRow[] rowArray = null;
                if (this.HidNumber.Value == "9")
                {
                    rowArray = cacheAsDataTable.Select("PlayTypeID in (103,104)");
                }
                else
                {
                    rowArray = cacheAsDataTable.Select("PlayTypeID in (101,102)");
                }
                foreach (DataRow row in rowArray)
                {
                    dt.Rows.Add(row.ItemArray);
                }
                PF.DataGridBindData(this.g, dt, this.gPager);
            }
            else
            {
                PF.DataGridBindData(this.g, cacheAsDataTable, this.gPager);
            }

            if (this.g.Items.Count == 0)
            {
                string str2 = Utility.FilteSqlInfusion(this.TxtName.Text.Trim());
                if (((str2 != "") && (str2 != "输入用户名")) && this.Personages.InnerHtml.Contains(str2))
                {
                    builder.AppendLine("select SchemeNumber,InitiateName, Level, Money, d.Name as PlayTypeName, Share, Schedule, AssureMoney, a.ID, InitiateUserID, QuashStatus, PlayTypeID, Buyed, SecrecyLevel, EndTime, IsOpened, LotteryNumber,a.LotteryID").AppendLine("from ").AppendLine("(").AppendLine("\tselect top 5 SchemeNumber, Money, Share, Schedule, AssureMoney, s.ID,u.Name as InitiateName,Level, InitiateUserID, QuashStatus, PlayTypeID, Buyed, SecrecyLevel, EndTime, s.isOpened, LotteryNumber,LotteryID ").AppendLine("\tfrom T_Schemes  s left join T_Isuses t on s.IsuseID = t.ID ").AppendLine("\tleft join T_Users u on s.InitiateUserID = u.ID").AppendLine("\twhere InitiateUserID not in(132011,71432) and s.Share > 1 and t.LotteryID = @LotteryID ").AppendLine("\tand u.Name like @InitiateName and s.SiteID = @SiteID").AppendLine("   order by QuashStatus asc,[Datetime] desc,[Money] desc").AppendLine(") as a").AppendLine("inner join T_PlayTypes d on d.ID = a.PlayTypeID");
                    key = string.Concat(new object[] { str2, "CoBuySchemes_", this.HidLotteryID.Value, "_Top5", builder });
                    cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
                    if (cacheAsDataTable == null)
                    {
                        cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("LotteryID", SqlDbType.Int, 0, ParameterDirection.Input, _Convert.StrToLong(Utility.FilteSqlInfusion(this.HidLotteryID.Value), 0L)), new MSSQL.Parameter("InitiateName", SqlDbType.VarChar, 0, ParameterDirection.Input, "'%" + str2 + "%'"), new MSSQL.Parameter("SiteID", SqlDbType.Int, 0, ParameterDirection.Input, base._Site.ID) });
                        if (cacheAsDataTable == null)
                        {
                            PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
                            return;
                        }
                        if (cacheAsDataTable.Rows.Count > 0)
                        {
                            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xea60);
                        }
                    }
                    PF.DataGridBindData(this.g, cacheAsDataTable, this.gPager);
                }
            }
        }
        this.divData.Visible = true;
        this.divLoding.Visible = false;
    }

    private void BindPersonages()
    {
        string key = "Admin_Personages";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Personages().Open("", "", "[Order]");
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        DataRow[] rowArray = cacheAsDataTable.Select("IsShow=1 and LotteryID=" + this.HidLotteryID.Value, "[Order]");
        this.Personages.InnerHtml = "合买名人：";
        int num = 0;
        foreach (DataRow row in rowArray)
        {
            object innerHtml = this.Personages.InnerHtml;
            this.Personages.InnerHtml = string.Concat(new object[] { innerHtml, "<a href='FollowFriendSchemeAdd.aspx?LotteryID=", this.HidLotteryID.Value, "&FollowUserID=", row["ID"], "&FollowUserName=", HttpUtility.UrlEncode(row["UserName"].ToString()), "' style=' text-decoration:none;padding-left:15px;color:#FF0065'>", row["UserName"].ToString(), "</a>" });
            num++;
            if (num == 6)
            {
                return;
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindDataForType();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[1].Text = "<font color='#000000'>" + e.Item.Cells[1].Text + "</font>";
            if (_Convert.StrToDouble(e.Item.Cells[12].Text, 0.0) > 0.0)
            {
                TableCell cell1 = e.Item.Cells[1];
                cell1.Text = cell1.Text + "<font color='red'>(保)</font>";
            }
            double num = _Convert.StrToDouble(e.Item.Cells[2].Text, 0.0);
            if (num > 0.0)
            {
                e.Item.Cells[2].Text = "<a href='../Web/Score.aspx?id=" + e.Item.Cells[14].Text + "&LotteryID=" + e.Item.Cells[0x15].Text + "' target='_blank' title='点击查看历史战绩'>";
                for (int i = 0; i < num; i++)
                {
                    TableCell cell2 = e.Item.Cells[2];
                    cell2.Text = cell2.Text + "<img src='Images/gold.gif' border='0'>";
                }
                TableCell cell3 = e.Item.Cells[2];
                cell3.Text = cell3.Text + "</a>";
            }
            else
            {
                e.Item.Cells[2].Text = "&nbsp;";
            }
            double num3 = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            e.Item.Cells[3].Text = (num3 == 0.0) ? "&nbsp;" : num3.ToString("N");
            short num4 = _Convert.StrToShort(e.Item.Cells[15].Text, 0);
            bool flag = _Convert.StrToBool(e.Item.Cells[0x11].Text, false);
            short num5 = _Convert.StrToShort(e.Item.Cells[0x12].Text, 0);
            bool flag2 = _Convert.StrToDateTime(e.Item.Cells[0x13].Text, DateTime.Now.ToString()) <= DateTime.Now;
            bool flag3 = _Convert.StrToBool(e.Item.Cells[20].Text, false);
            long num6 = _Convert.StrToLong(e.Item.Cells[14].Text, 0L);
            if (((num5 == 1) && !flag2) && ((base._User == null) || (((base._User != null) && (num6 != base._User.ID)) && !base._User.isOwnedViewSchemeCompetence())))
            {
                e.Item.Cells[5].Text = "已保密，截止后公开";
            }
            else if (((num5 == 2) && !flag3) && ((base._User == null) || (((base._User != null) && (num6 != base._User.ID)) && !base._User.isOwnedViewSchemeCompetence())))
            {
                e.Item.Cells[5].Text = "已保密，开奖后公开";
            }
            else if ((num5 == 3) && ((base._User == null) || (((base._User != null) && (num6 != base._User.ID)) && !base._User.isOwnedViewSchemeCompetence())))
            {
                e.Item.Cells[5].Text = "已保密";
            }
            else if (e.Item.Cells[5].Text.Trim().Length > 0x1c)
            {
                e.Item.Cells[5].Text = "<a href='Scheme.aspx?id=" + e.Item.Cells[13].Text + "' target='_blank' title='点击查看方案详细信息'><font color=\"red\">投注内容</font></a>";
            }
            else if ((((this.HidLotteryID.Value == "1") || (this.HidLotteryID.Value == "2")) || (this.HidLotteryID.Value == "3")) && (string.IsNullOrEmpty(e.Item.Cells[5].Text.Trim()) || (e.Item.Cells[5].Text == "&nbsp;")))
            {
                e.Item.Cells[5].Text = "<a href='Scheme.aspx?id=" + e.Item.Cells[13].Text + "' target='_blank'><font color=\"red\">未上传方案</font></a>";
            }
            else
            {
                e.Item.Cells[5].Text = "<a href='Scheme.aspx?id=" + e.Item.Cells[13].Text + "' target='_blank' title='点击查看方案详细信息'>" + e.Item.Cells[5].Text.Trim() + "</a>";
            }
            int num7 = _Convert.StrToInt(e.Item.Cells[6].Text, 1);
            e.Item.Cells[7].Text = Math.Round((double)(num3 / ((double)num7)), 2).ToString("N");
            TableCell cell4 = e.Item.Cells[8];
            cell4.Text = cell4.Text + "%";
            switch (num4)
            {
                case 0:
                    if (flag)
                    {
                        e.Item.Cells[9].Text = "<Font color='Red'>已成功</font>";
                        e.Item.Cells[10].Text = "--";
                        return;
                    }
                    if (e.Item.Cells[8].Text == "100%")
                    {
                        e.Item.Cells[9].Text = "<Font color='Red'>满员</font>";
                        e.Item.Cells[10].Text = "--";
                        return;
                    }
                    if (flag2)
                    {
                        e.Item.Cells[9].Text = "未成功";
                        e.Item.Cells[9].Text = "--";
                        return;
                    }
                    e.Item.Cells[9].Text = "未满";
                    e.Item.Cells[10].Text = "<a href='Scheme.aspx?id=" + e.Item.Cells[13].Text + "' target='_blank' title='点击查看方案详细信息'><font color=\"red\">入伙</font></a>";
                    return;

                case 2:
                    e.Item.Cells[9].Text = "<font color='blue'>撤单</font>";
                    break;

                default:
                    e.Item.Cells[9].Text = "撤单";
                    break;
            }
            e.Item.Cells[10].Text = "--";
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

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isRequestLogin = false;
        base.isAtFramePageLogin = false;
        base.isAllowPageCache = true;
        base.PageCacheSeconds = 60;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.HidIsuseID.Value = Utility.GetRequest("IsuseID");
            this.HidLotteryID.Value = Utility.GetRequest("LotteryID");
            this.HidNumber.Value = Utility.GetRequest("Number");
            this.BindPersonages();
            this.script.AppendLine("__doPostBack('btnSearch', '');");
        }
        else
        {
            this.script.AppendLine("document.getElementById(\"g\").setAttribute(\"border\", \"1\");").AppendLine("document.getElementById(\"g\").removeAttribute(\"style\");").AppendLine("document.getElementById(\"g\").setAttribute(\"width\", \"100%\");");
        }
    }
}

