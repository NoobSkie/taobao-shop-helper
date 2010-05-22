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

public partial class Home_Room_FollowSchemeHistory : RoomPageBase, IRequiresSessionState
{

    private void BindData()
    {
        string str = " a.[UserID] = " + base._User.ID.ToString() + "  and (EndTime < GetDate() or StartTime < GetDate()) ";
        if (this.ddlLottery.SelectedValue != "-1")
        {
            str = str + " and LotteryID=" + _Convert.StrToInt(this.ddlLottery.SelectedValue, -1).ToString();
        }
        if (this.ddlPlayType.SelectedValue != "-1")
        {
            str = str + " and PlayTypeID = " + _Convert.StrToInt(this.ddlPlayType.SelectedValue, -1).ToString();
        }
        if (str != "")
        {
            str = str + " and isAutoFollowScheme = 1";
        }
        else
        {
            str = "isAutoFollowScheme = 1";
        }
        DataTable dt = MSSQL.Select("select a.*,b.Memo  from V_BuyDetailsWithQuashedAll a left join (select Memo,SchemeID from T_UserDetails where OperatorType = 9)b on a.SchemeID = b.SchemeID where  " + str + " order by a.ID desc", new MSSQL.Parameter[0]);
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Room_InvestHistory");
        }
        else
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
            this.gPager.Visible = true;
            this.lblPageBuyMoney.Text = PF.GetSumByColumn(dt, 10, true, this.gPager.PageSize, this.gPager.PageIndex).ToString("N");
            this.lblPageReward.Text = PF.GetSumByColumn(dt, 8, true, this.gPager.PageSize, this.gPager.PageIndex).ToString("N");
            this.lblTotalBuyMoney.Text = PF.GetSumByColumn(dt, 10, false, this.gPager.PageSize, this.gPager.PageIndex).ToString("N");
            this.lblTotalReward.Text = PF.GetSumByColumn(dt, 8, false, this.gPager.PageSize, this.gPager.PageIndex).ToString("N");
        }
    }

    private void BindDataForFriendFollowScheme()
    {
        long iD = -1L;
        if (base._User != null)
        {
            iD = base._User.ID;
        }
        DataTable table = null;
        string str = Utility.FilteSqlInfusion(this.TxtName.Text.Trim());
        if (str != "")
        {
            string commandText = "SELECT ID,[NAME],[Level],MaxFollowNumber FROM dbo.T_Users ";
            if ((str != "") && (str != "输入用户名"))
            {
                string str3 = commandText;
                commandText = str3 + " WHERE [Name] LIKE '%" + str + "%' and ID not in (select FollowUserID from T_CustomFriendFollowSchemes where UserID = " + iD.ToString() + " and LotteryID in(-1," + this.ddlLotterySet.SelectedValue + "))";
            }
            else
            {
                commandText = commandText + " WHERE 0=1";
            }
            if (iD > 0L)
            {
                commandText = commandText + " and ID <> " + iD.ToString();
            }
            table = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
            if (table == null)
            {
                PF.GoError(1, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
        }
        else
        {
            string str4 = "select FollowUserID from T_CustomFriendFollowSchemes where UserID = " + base._User.ID.ToString();
            if (this.ddlLotterySet.SelectedValue != "-1")
            {
                str4 = str4 + " and LotteryID = " + this.ddlLotterySet.SelectedValue;
            }
            if (this.ddlPlayTypeSet.SelectedValue != "-1")
            {
                str4 = str4 + " and PlayTypeID = " + this.ddlPlayTypeSet.SelectedValue;
            }
            table = MSSQL.Select("SELECT ID,[Name],[Level],MaxFollowNumber FROM dbo.T_Users WHERE ID in (" + str4 + ")", new MSSQL.Parameter[0]);
            if (table == null)
            {
                PF.GoError(1, "参数错误，系统异常。", base.GetType().FullName);
            }
        }
        this.gSetFollowScheme.DataSource = table;
        this.gSetFollowScheme.DataBind();
        this.gPager.Visible = true;
    }

    private void BindDataForLottery()
    {
        this.ddlLottery.Items.Clear();
        this.ddlLottery.Items.Add(new ListItem("全部彩种", "-1"));
        this.ddlLotterySet.Items.Clear();
        this.ddlLotterySet.Items.Add(new ListItem("全部彩种", "-1"));
        this.BindDataForPlayType(2);
        this.ddlWhoLottery.Items.Clear();
        this.ddlWhoLottery.Items.Add(new ListItem("全部彩种", "-1"));
        this.BindDataForPlayType(3);
        if (base._Site.UseLotteryList == "")
        {
            PF.GoError(1, "暂无玩法", "Room_InvestHistory");
        }
        else
        {
            DataTable table = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[Order]");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Room_InvestHistory");
            }
            else
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string text = table.Rows[i]["Name"].ToString();
                    if (table.Rows[i]["ID"].ToString() == "61")
                    {
                        text = text.Replace("江西", "");
                    }
                    this.ddlLottery.Items.Add(new ListItem(text, table.Rows[i]["ID"].ToString()));
                    this.ddlLotterySet.Items.Add(new ListItem(text, table.Rows[i]["ID"].ToString()));
                    this.ddlWhoLottery.Items.Add(new ListItem(text, table.Rows[i]["ID"].ToString()));
                }
            }
        }
    }

    private void BindDataForPlayType(int type)
    {
        DataTable table = null;
        if (type == 1)
        {
            if (this.ddlLottery.Items.Count < 1)
            {
                return;
            }
            this.ddlPlayType.Items.Clear();
            this.ddlPlayType.Items.Add(new ListItem("全部玩法", "-1"));
            table = new Views.V_PlayTypes().Open("ID,LotteryID,Name,LotteryName,BuyFileName", "LotteryID=" + this.ddlLottery.SelectedValue, "");
        }
        else if (type == 2)
        {
            if (this.ddlLotterySet.Items.Count < 1)
            {
                return;
            }
            this.ddlPlayTypeSet.Items.Clear();
            this.ddlPlayTypeSet.Items.Add(new ListItem("全部玩法", "-1"));
            table = new Views.V_PlayTypes().Open("ID,LotteryID,Name,LotteryName,BuyFileName", "LotteryID=" + this.ddlLotterySet.SelectedValue, "");
        }
        else if (type == 3)
        {
            if (this.ddlWhoLottery.Items.Count < 1)
            {
                return;
            }
            this.ddlWhoPlaytype.Items.Clear();
            this.ddlWhoPlaytype.Items.Add(new ListItem("全部玩法", "-1"));
            table = new Views.V_PlayTypes().Open("ID,LotteryID,Name,LotteryName,BuyFileName", "LotteryID=" + this.ddlWhoLottery.SelectedValue, "");
        }
        if (table == null)
        {
            PF.GoError(1, "暂无玩法", base.GetType().FullName);
        }
        else if (type == 1)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string text = table.Rows[i]["Name"].ToString().ToString();
                if (table.Rows[i]["Name"].ToString() == "61")
                {
                    text = text.Replace("江西", "");
                }
                if (table.Rows[i]["Name"].ToString() != "混合投注")
                {
                    this.ddlPlayType.Items.Add(new ListItem(text, table.Rows[i]["ID"].ToString()));
                }
            }
        }
        else if (type == 2)
        {
            for (int j = 0; j < table.Rows.Count; j++)
            {
                string str2 = table.Rows[j]["Name"].ToString().ToString();
                if (table.Rows[j]["Name"].ToString() == "61")
                {
                    str2 = str2.Replace("江西", "");
                }
                if (table.Rows[j]["Name"].ToString() != "混合投注")
                {
                    this.ddlPlayTypeSet.Items.Add(new ListItem(str2, table.Rows[j]["ID"].ToString()));
                }
            }
        }
        else if (type == 3)
        {
            for (int k = 0; k < table.Rows.Count; k++)
            {
                string str3 = table.Rows[k]["Name"].ToString().ToString();
                if (table.Rows[k]["Name"].ToString() == "61")
                {
                    str3 = str3.Replace("江西", "");
                }
                if (table.Rows[k]["Name"].ToString() != "混合投注")
                {
                    this.ddlWhoPlaytype.Items.Add(new ListItem(str3, table.Rows[k]["ID"].ToString()));
                }
            }
        }
    }

    private void BindWhoFollowScheme()
    {
        DataTable dt = null;
        string commandText = "select UserID , LotteryID , PlayTypeID,MoneyStart,MoneyEnd , [DateTime] from T_CustomFriendFollowSchemes where FollowUserID = " + base._User.ID.ToString();
        if (this.ddlLotterySet.SelectedValue != "-1")
        {
            commandText = commandText + " and LotteryID = " + this.ddlLotterySet.SelectedValue;
        }
        if (this.ddlPlayTypeSet.SelectedValue != "-1")
        {
            commandText = commandText + " and PlayTypeID = " + this.ddlPlayTypeSet.SelectedValue;
        }
        dt = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
        if (dt == null)
        {
            PF.GoError(1, "参数错误，系统异常。", base.GetType().FullName);
        }
        PF.DataGridBindData(this.gWhoFollowSchemes, dt, this.gPageWhoFollowSchemes);
    }

    protected void btnFollowScheme_Click(object sender, EventArgs e)
    {
        this.BindWhoFollowScheme();
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindDataForFriendFollowScheme();
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = (DropDownList)sender;
        if (list.ID == "ddlLottery")
        {
            this.BindDataForPlayType(1);
        }
        else if (list.ID == "ddlWhoLottery")
        {
            this.BindDataForPlayType(3);
            this.BindWhoFollowScheme();
        }
        else
        {
            this.BindDataForPlayType(2);
            this.BindDataForFriendFollowScheme();
        }
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
        {
            if (base._User == null)
            {
                JavaScript.Alert(this, "已退出登陆，请重新登陆", base.Request.Url.AbsoluteUri);
            }
            else
            {
                int num = _Convert.StrToInt(e.Item.Cells[6].Text, -1);
                if (num < 0)
                {
                    JavaScript.Alert(this, "取消定制失败！");
                }
                else if (MSSQL.ExecuteNonQuery("delete from T_CustomFriendFollowSchemes where FollowUserID = " + num.ToString() + " and UserID = " + base._User.ID.ToString(), new MSSQL.Parameter[0]) < 0)
                {
                    JavaScript.Alert(this, "取消定制失败！");
                }
                else
                {
                    Shove._Web.Cache.ClearCache("T_CustomFriendFollowSchemes" + this.ddlLotterySet.SelectedValue);
                    this.BindDataForFriendFollowScheme();
                    JavaScript.Alert(this, "取消定制成功！");
                }
            }
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            long num = _Convert.StrToLong(e.Item.Cells[12].Text, 0L);
            string text = e.Item.Cells[1].Text;
            if (text.Length > 6)
            {
                text = text.Substring(0, 5) + "..";
            }
            e.Item.Cells[1].Text = "<span class='red12_2'><a href='Scheme.aspx?id=" + num.ToString() + "' target='_blank'>" + text + "</a></span>";
            text = e.Item.Cells[2].Text.Trim();
            if (text.Length > 6)
            {
                text = text.Substring(0, 5) + "..";
            }
            e.Item.Cells[2].Text = text;
            double num2 = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            e.Item.Cells[4].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            num2 = _Convert.StrToDouble(e.Item.Cells[6].Text, 0.0);
            e.Item.Cells[6].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            double num3 = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            double num4 = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            if (num4 >= num3)
            {
                e.Item.Cells[7].Text = "100%";
            }
            else if (num3 > 0.0)
            {
                e.Item.Cells[7].Text = Math.Round((double)((num4 / num3) * 100.0), 2).ToString() + "%";
            }
            num2 = _Convert.StrToDouble(e.Item.Cells[8].Text, 0.0);
            e.Item.Cells[8].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            num2 = _Convert.StrToDouble(e.Item.Cells[9].Text, 0.0);
            e.Item.Cells[9].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            short num6 = _Convert.StrToShort(e.Item.Cells[13].Text, 0);
            if (num6 != 0)
            {
                e.Item.Cells[11].Text = "已撤单";
                if (num6 == 1)
                {
                    e.Item.Cells[11].Text = "用户撤单";
                }
                else if (!string.IsNullOrEmpty(e.Item.Cells[0x11].Text.Trim()))
                {
                    e.Item.Cells[11].Text = e.Item.Cells[0x11].Text;
                }
            }
            else if (_Convert.StrToBool(e.Item.Cells[14].Text, false))
            {
                e.Item.Cells[11].Text = "<Font color='Red'>已成功</font>";
            }
            else
            {
                int num7 = _Convert.StrToInt(e.Item.Cells[0x10].Text, 0);
                int num8 = _Convert.StrToInt(e.Item.Cells[3].Text, 0);
                if (num7 >= num8)
                {
                    e.Item.Cells[11].Text = "<Font color='Red'>已满员</font>";
                }
                else
                {
                    e.Item.Cells[11].Text = "未成功";
                }
            }
        }
    }

    protected void g_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        DataGrid grid = (DataGrid)source;
        if (grid.ID == "g")
        {
            this.BindData();
        }
        else if (grid.ID == "gSetFollowScheme")
        {
            this.BindDataForFriendFollowScheme();
        }
        else
        {
            bool flag1 = grid.ID == "gWhoFollowSchemes";
        }
    }

    protected string GetLottery(object _lotteryId)
    {
        int num = _Convert.StrToInt(_lotteryId.ToString(), 0);
        if (num < 1)
        {
            return "全部彩种";
        }
        return new Tables.T_Lotteries().Open("Name", "id = " + num, "").Rows[0][0].ToString();
    }

    protected string GetPlayType(object _playTypeId)
    {
        int num = _Convert.StrToInt(_playTypeId.ToString(), 0);
        if (num < 1)
        {
            return "全部玩法";
        }
        return new Tables.T_PlayTypes().Open("Name", "id = " + num, "").Rows[0][0].ToString();
    }

    protected string GetUserName(object _userId)
    {
        string str = _userId.ToString();
        return new Tables.T_Users().Open("Name", "id = " + str, "").Rows[0][0].ToString();
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        ShoveGridPager pager = (ShoveGridPager)Sender;
        if (pager.ID == "gPager")
        {
            this.hdCurDiv.Value = "divMyFollowSchemes";
            this.BindData();
        }
        else if (pager.ID == "gPagerSetFollowScheme")
        {
            this.hdCurDiv.Value = "divSetMyFollowSchemes";
            this.BindDataForFriendFollowScheme();
        }
    }

    protected void gSetFollowScheme_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            DataRowView dataItem = (DataRowView)e.Item.DataItem;
            DataRow row = dataItem.Row;
            if (row != null)
            {
                TableCell cell = e.Item.Cells[1];
                cell.CssClass = "blue12";
                if (row["Level"].ToString() == "0")
                {
                    cell.Text = "<a href='../Web/Score.aspx?id=" + row["ID"].ToString() + "' title='点击查看' target='_blank'>-</a>";
                }
                else
                {
                    cell.Text = "<a href='../Web/Score.aspx?id=" + row["ID"].ToString() + "' title='点击查看' target='_blank'><span style='background-image:url(Images/gold.gif); width:" + row["Level"].ToString() + "px;background-repeat:repeat-x;'></span></a>";
                }
                TableCell cell2 = e.Item.Cells[2];
                string key = "T_CustomFriendFollowSchemes" + this.ddlLotterySet.SelectedValue;
                DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
                if (cacheAsDataTable == null)
                {
                    if (this.ddlLotterySet.SelectedValue == "-1")
                    {
                        cacheAsDataTable = MSSQL.Select("select * from T_CustomFriendFollowSchemes", new MSSQL.Parameter[0]);
                    }
                    else
                    {
                        cacheAsDataTable = MSSQL.Select("select * from T_CustomFriendFollowSchemes where LotteryID in (-1," + this.ddlLotterySet.SelectedValue + ")", new MSSQL.Parameter[0]);
                    }
                    if ((cacheAsDataTable != null) && (cacheAsDataTable.Rows.Count > 0))
                    {
                        Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
                    }
                }
                int length = 0;
                if ((cacheAsDataTable != null) && (cacheAsDataTable.Rows.Count > 0))
                {
                    length = cacheAsDataTable.Select("FollowUserID = " + row["ID"].ToString()).Length;
                }
                cell2.Text = length.ToString() + "/" + row["MaxFollowNumber"].ToString();
                TableCell cell3 = e.Item.Cells[3];
                if (length > 0)
                {
                    cell3.CssClass = "blue12";
                    cell3.Text = "<a href='javascript:;' onclick=\"showDialog('FollowFriendView.aspx?ID=" + row["ID"].ToString() + "&FollowUserName=" + HttpUtility.UrlEncode(row["Name"].ToString()) + "');\">查看</a>";
                }
                else
                {
                    cell3.Text = "-";
                }
                TableCell cell4 = e.Item.Cells[4];
                int num2 = -1;
                if (base._User == null)
                {
                    cell4.Text = "未知";
                }
                else if (cacheAsDataTable.Select("UserID = " + base._User.ID.ToString() + " and FollowUserID = " + row["ID"].ToString()).Length > 0)
                {
                    cell4.Text = "已定制";
                    num2 = 1;
                }
                else
                {
                    cell4.Text = "未定制";
                    num2 = 0;
                }
                TableCell cell5 = e.Item.Cells[5];
                if (num2 == -1)
                {
                    cell5.Text = "-";
                }
                else
                {
                    Label label = (Label)cell5.FindControl("lbEdit");
                    LinkButton button = (LinkButton)cell5.FindControl("Cancel");
                    button.Visible = false;
                    cell5.CssClass = "blue12";
                    switch (num2)
                    {
                        case 0:
                            if (length >= _Convert.StrToInt(row["MaxFollowNumber"].ToString(), 200))
                            {
                                cell5.Text = "已满额";
                            }
                            else
                            {
                                cell5.Text = "<a href='FollowFriendSchemeAdd_User.aspx?FollowUserID=" + row["ID"].ToString() + "&FollowUserName=" + HttpUtility.UrlEncode(row["Name"].ToString()) + "&LotteryID=" + this.ddlLotterySet.SelectedValue + "'>定制</a>";
                            }
                            button.Visible = false;
                            return;

                        case 1:
                            label.Text = "<a href='javascript:;' onclick=\"showDialog('FollowFriendSchemeEdit.aspx?FollowUserID=" + row["ID"].ToString() + "&FollowUserName=" + HttpUtility.UrlEncode(row["Name"].ToString()) + "&UserID=" + base._User.ID.ToString() + "')\">修改</a>";
                            button.Visible = true;
                            button.Attributes.Add("onclick", "return isCancelFollowScheme()");
                            break;
                    }
                }
            }
        }
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
            this.BindDataForLottery();
            this.hdCurDiv.Value = Utility.GetRequest("Type");
            this.BindDataForPlayType(1);
            this.BindDataForPlayType(2);
            this.BindDataForPlayType(3);
            this.BindDataForFriendFollowScheme();
            this.BindWhoFollowScheme();
            this.btnGo_Click(this.btnGo, e);
        }
    }
}

