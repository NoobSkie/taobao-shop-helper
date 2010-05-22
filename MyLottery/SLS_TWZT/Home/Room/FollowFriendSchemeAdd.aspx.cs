using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_FollowFriendSchemeAdd : RoomPageBase, IRequiresSessionState
{
    public string Source = "";

    private void BindDataForLottery(int LotteryID)
    {
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
            this.ddlLotteries.Items.Clear();
            this.ddlLotteries.Items.Add(new ListItem("全部彩种", "-1"));
            foreach (DataRow row in cacheAsDataTable.Rows)
            {
                string text = row["Name"].ToString();
                if (row["ID"].ToString() == "61")
                {
                    text = text.Replace("江西", "");
                }
                this.ddlLotteries.Items.Add(new ListItem(text, row["ID"].ToString()));
            }
            if (this.ddlLotteries.Items.FindByValue(LotteryID.ToString()) != null)
            {
                this.ddlLotteries.SelectedValue = LotteryID.ToString();
            }
            this.ddlLotteries_SelectedIndexChanged(this.ddlLotteries, new EventArgs());
        }
    }

    private void BindFollowList()
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("FollowList");
        if (cacheAsDataTable == null)
        {
            string commandText = "select top 10 t1.FollowUserID,t1.FollowCount,t2.Name,(select LotteryID from (select top 1 LotteryID,sum(DetailMoney) as DetailMoney from V_BuyDetails as s where s.UserID=t2.ID group by LotteryID order by DetailMoney desc) as W) as LotteryID from (select COUNT(FollowUserID) as FollowCount,FollowUserID from T_CustomFriendFollowSchemes group by FollowUserID) as t1 inner join T_Users as t2 on t1.FollowUserID=t2.ID order by  t1.FollowCount desc";
            cacheAsDataTable = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            if (cacheAsDataTable.Rows.Count > 0)
            {
                Shove._Web.Cache.SetCache("FollowList", cacheAsDataTable, 60);
            }
        }
        StringBuilder builder = new StringBuilder();
        if (cacheAsDataTable.Rows.Count == 0)
        {
            builder.AppendLine("<tr>").AppendLine("<td height=\"20\" colspan=\"3\" align=\"center\" class=\"blue12\">").AppendLine("暂无数据").AppendLine("</td>").AppendLine("</tr>");
        }
        else
        {
            int num = 0;
            foreach (DataRow row in cacheAsDataTable.Rows)
            {
                int num2 = 0;
                if (_Convert.StrToInt((row["LotteryID"] == null) ? "" : row["LotteryID"].ToString(), 0) == 0)
                {
                    num2 = 5;
                }
                else
                {
                    num2 = _Convert.StrToInt(Utility.FilteSqlInfusion(row["LotteryID"].ToString()), 0);
                }
                string str2 = row["Name"].ToString();
                string str3 = "";
                string str4 = "SELECT TOP 1 ID FROM dbo.V_Schemes with (nolock) WHERE SiteID =@SiteID AND InitiateUserID = @InitiateUserID AND QuashStatus = 0 AND isOpened = 0 ORDER BY Money desc,Schedule desc,  CONVERT(Datetime,[Datetime]) desc ";
                DataTable table2 = MSSQL.Select(str4, new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.Int, 0, ParameterDirection.Input, base._Site.ID), new MSSQL.Parameter("InitiateUserID", SqlDbType.Int, 0, ParameterDirection.Input, Utility.FilteSqlInfusion(row["FollowUserID"].ToString())) });
                if (((table2 != null) && (table2.Rows.Count > 0)) && (table2.Rows.Count == 1))
                {
                    str3 = "<a href='" + Utility.GetUrl() + "/Home/Room/Scheme.aspx?id=" + table2.Rows[0]["ID"].ToString() + "' target='_blank'>查看</a>";
                }
                num++;
                builder.AppendLine("<tr>").Append("<td width=\"8%\" height=\"28\" align=\"center\" bgcolor=\"#FFFFFF\" class=\"blue12\">").Append("<img src=\"images/num_" + num.ToString() + ".gif\" width=\"13\" height=\"13\" />").AppendLine("</td>").Append("<td width=\"30%\" height=\"28\" align=\"center\" bgcolor=\"#FFFFFF\" class=\"blue12\" title='" + str2 + "'>").Append(@"<a href='..\Web\Score.aspx?id=").Append(row["FollowUserID"].ToString()).Append("&LotteryID=" + num2.ToString() + "' target='_blank'>").Append(str2).Append("</a>").AppendLine("</td>").Append("<td width=\"11%\"  bgcolor=\"#FFFFFF\" align=\"center\" class=\"blue12\">");
                builder.Append(row["FollowCount"].ToString()).AppendLine("</td>").Append("<td width=\"22%\"  bgcolor=\"#FFFFFF\" class=\"red12_2\" align='center'>");
                str4 = "Select SUM(DetailMoney) AS DetailMoney From T_BuyDetails b Left Join T_CustomFriendFollowSchemes c on b.UserID = c.UserID Left Join T_Schemes s on b.SchemeID = s.ID where s.InitiateUserID = @UserID and c.FollowUserID = @UserID";
                DataTable table3 = MSSQL.Select(str4, new MSSQL.Parameter[] { new MSSQL.Parameter("UserID", SqlDbType.BigInt, 0, ParameterDirection.Input, Utility.FilteSqlInfusion(row["FollowUserID"].ToString())) });
                if ((table3 != null) && (table3.Rows.Count > 0))
                {
                    builder.Append(_Convert.StrToDouble(table3.Rows[0]["DetailMoney"].ToString(), 0.0).ToString("N0"));
                }
                builder.AppendLine("</td>").Append("<td width=\"20%\" height=\"28\" align=\"center\" bgcolor=\"#FFFFFF\" class=\"blue12\">");
                if (str3 != "")
                {
                    builder.Append(str3);
                }
                else
                {
                    builder.Append("无");
                }
                builder.Append("</td>").Append("<td width=\"9%\"  bgcolor=\"#FFFFFF\" class=\"red12_2\" align='center'>");
                builder.Append("<a  href='FollowFriendSchemeAdd.aspx?Source=1&FollowUserID=" + row["FollowUserID"].ToString() + "&FollowUserName=" + HttpUtility.UrlEncode(str2) + "&LotteryID=-1'>定制</a>").AppendLine("</td>").AppendLine("</tr>");
            }
        }
        this.tbFollowList.InnerHtml = this.tbFollowList.InnerHtml + builder.ToString();
    }

    protected void btn_OK_Click(object sender, EventArgs e)
    {
        double num = 0.0;
        double num2 = 0.0;
        int num3 = 1;
        int num4 = 1;
        if ((this.Source == "1") && (this.lbUserName.Text == ""))
        {
            JavaScript.Alert(this.Page, "对不起，用户访问错误.");
            base.Response.Write("<scrpit type=\"text/javascript\" language=\"javascript\">top.location = \"UserEdit.aspx\" </script>");
        }
        else if (string.IsNullOrEmpty(base._User.IDCardNumber) || string.IsNullOrEmpty(base._User.RealityName))
        {
            base.Response.Write("<script>alert('对不起，您的身份证号码或者真实姓名没有填写，为了不影响您的领奖，请先完善这些资料。谢谢');parent.location.href ='UserEdit.aspx';</script>");
        }
        else
        {
            try
            {
                num2 = double.Parse(this.tbMaxMoney.Text);
                num = double.Parse(this.tbMinMoney.Text);
            }
            catch
            {
                JavaScript.Alert(this.Page, "输入有误");
                return;
            }
            if (num2 >= num)
            {
                num3 = _Convert.StrToInt(this.tbBuyShareStart.Text, -1);
                num4 = _Convert.StrToInt(this.tbBuyShareEnd.Text, -1);
                if (((num3 < 1) || (num4 < 1)) || (num3 > num4))
                {
                    JavaScript.Alert(this.Page, "份数输入有误");
                }
                else if (new Tables.T_CustomFriendFollowSchemes().GetCount("LotteryID in(" + this.ddlLotteries.SelectedValue + ",-1) and PlayTypeID in(" + this.ddlPlayTypes.SelectedValue + ",-1) and UserID=" + base._User.ID.ToString() + " and FollowUserID=" + this.HidFollowUserID.Value) > 0L)
                {
                    JavaScript.Alert(this.Page, "您已经订制过此好友的跟单！");
                }
                else if (base._User.ID == _Convert.StrToLong(this.HidFollowUserID.Value, 0L))
                {
                    JavaScript.Alert(this.Page, "您不能定制自己的跟单!");
                }
                else if (new Tables.T_CustomFriendFollowSchemes { SiteID = { Value = 1 }, UserID = { Value = base._User.ID }, FollowUserID = { Value = this.HidFollowUserID.Value }, LotteryID = { Value = this.ddlLotteries.SelectedValue }, PlayTypeID = { Value = this.ddlPlayTypes.SelectedValue }, MoneyStart = { Value = num }, MoneyEnd = { Value = num2 }, BuyShareStart = { Value = num3 }, BuyShareEnd = { Value = num4 }, Type = { Value = 1 } }.Insert() > 0L)
                {
                    Shove._Web.Cache.ClearCache("T_CustomFriendFollowSchemes" + this.ddlLotteries.SelectedValue);
                    if (this.ddlLotteries.SelectedValue == "-1")
                    {
                        foreach (KeyValuePair<int, string> pair in DataCache.Lotteries)
                        {
                            Shove._Web.Cache.ClearCache("T_CustomFriendFollowSchemes" + pair.Key.ToString());
                        }
                    }
                    base.Response.Redirect("FollowScheme.aspx?LotteryID=" + _Convert.StrToInt(Utility.GetRequest("LotteryID"), 5) + "&Go=-1", true);
                }
                else
                {
                    PF.GoError(1, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                }
            }
            else
            {
                JavaScript.Alert(this.Page, "输入有误，最低金额不能大于最高金额");
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("FollowFriendScheme.aspx?LotteryID=" + _Convert.StrToInt(Utility.GetRequest("LotteryID"), 5), true);
    }

    protected void ddlLotteries_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlLotteries.SelectedValue == "-1")
        {
            this.ddlPlayTypes.Items.Clear();
            this.ddlPlayTypes.Items.Add(new ListItem("全部玩法", "-1"));
        }
        else
        {
            string key = "dtPlayTypes_" + this.ddlLotteries.SelectedValue;
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Tables.T_PlayTypes().Open("", "LotteryID in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ") and LotteryID = " + _Convert.StrToInt(this.ddlLotteries.SelectedValue, -1).ToString(), "[ID]");
                if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
                {
                    PF.GoError(7, "数据库繁忙，请重试", base.GetType().FullName + "(-85)");
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
            }
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-95)");
            }
            else
            {
                this.ddlPlayTypes.Items.Clear();
                this.ddlPlayTypes.Items.Add(new ListItem("全部玩法", "-1"));
                foreach (DataRow row in cacheAsDataTable.Rows)
                {
                    this.ddlPlayTypes.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
                }
                if ((this.ddlLotteries.SelectedValue == "1") && (this.HidNumber.Value == "9"))
                {
                    this.ddlPlayTypes.SelectedValue = "103";
                }
            }
        }
    }

    private string GetUserName(long id)
    {
        DataTable table = MSSQL.Select("select name from T_Users where id = " + id, new MSSQL.Parameter[0]);
        if ((table != null) && (table.Rows.Count >= 1))
        {
            return table.Rows[0][0].ToString();
        }
        return "";
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
            long id = 0L;
            this.Source = HttpUtility.UrlDecode(Utility.GetRequest("Source"));
            if (this.Source == "1")
            {
                id = _Convert.StrToLong(Utility.GetRequest("FollowUserID"), -1L);
                if (id.ToString() == "-1")
                {
                    return;
                }
                this.lbUserName.Text = this.GetUserName(id);
            }
            else
            {
                this.lbUserName.Text = HttpUtility.UrlDecode(Utility.GetRequest("FollowUserName"));
                if (id.ToString() == "-1")
                {
                    JavaScript.Alert(this.Page, "该用户已退隐江湖.", "../../JoinAllBuy.aspx");
                }
                id = _Convert.StrToLong(Utility.GetRequest("FollowUserID"), -1L);
            }
            int key = _Convert.StrToInt(Utility.GetRequest("LotteryID"), -1);
            this.HidNumber.Value = Utility.GetRequest("Number");
            if (key == -1)
            {
                key = 1;
            }
            if ((!DataCache.Lotteries.ContainsKey(key) || (id < 0L)) || (this.lbUserName.Text == ""))
            {
                PF.GoError(1, "参数错误，系统异常。", base.GetType().BaseType.FullName);
            }
            else
            {
                this.HidFollowUserID.Value = id.ToString();
                _Convert.StrToInt(Utility.GetRequest("FollowFriendID"), 0);
                this.BindDataForLottery(key);
                this.ddlLotteries.SelectedValue = _Convert.StrToInt(Utility.GetRequest("DzLotteryID"), -1).ToString();
                this.BindFollowList();
            }
        }
    }
}

