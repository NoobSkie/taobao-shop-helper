using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_FollowFriendSchemeEdit : RoomPageBase, IRequiresSessionState
{

    private void BindData(int FollowUserID)
    {
        DataTable table = new Tables.T_CustomFriendFollowSchemes().Open("", "FollowUserID = " + FollowUserID.ToString() + " and UserID = " + Utility.FilteSqlInfusion(this.HidUserID.Value), "");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else if (table.Rows.Count == 0)
        {
            PF.GoError(4, "参数错误", base.GetType().BaseType.FullName);
        }
        else
        {
            DataRow row = table.Rows[0];
            int num = _Convert.StrToInt(row["LotteryID"].ToString(), -1);
            int num2 = _Convert.StrToInt(row["PlayTYpeID"].ToString(), -1);
            double num3 = _Convert.StrToDouble(row["MoneyStart"].ToString(), 0.0);
            double num4 = _Convert.StrToDouble(row["MoneyEnd"].ToString(), 0.0);
            int num5 = _Convert.StrToInt(row["BuyShareStart"].ToString(), 1);
            int num6 = _Convert.StrToInt(row["BuyShareEnd"].ToString(), 1);
            this.tbMaxMoney.Text = num4.ToString().Replace(".0000", "");
            this.tbMinMoney.Text = num3.ToString().Replace(".0000", "");
            this.tbBuyShareStart.Text = num5.ToString();
            this.tbBuyShareEnd.Text = num6.ToString();
            this.HidFollowUserID.Value = row["FollowUserID"].ToString();
            this.HidPlayTypeID.Value = num2.ToString();
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
                foreach (DataRow row2 in cacheAsDataTable.Rows)
                {
                    string text = row2["Name"].ToString();
                    if (row2["ID"].ToString() == "61")
                    {
                        text = text.Replace("江西", "");
                    }
                    this.ddlLotteries.Items.Add(new ListItem(text, row2["ID"].ToString()));
                }
                if (this.ddlLotteries.Items.FindByValue(num.ToString()) != null)
                {
                    this.ddlLotteries.SelectedValue = num.ToString();
                }
                this.ddlLotteries_SelectedIndexChanged(this.ddlLotteries, new EventArgs());
            }
        }
    }

    protected void btn_OK_Click(object sender, EventArgs e)
    {
        double num = 0.0;
        double num2 = 0.0;
        int num3 = 1;
        int num4 = 1;
        if (string.IsNullOrEmpty(base._User.IDCardNumber) || string.IsNullOrEmpty(base._User.RealityName))
        {
            JavaScript.Alert(this.Page, "对不起，您的身份证号码或者真实姓名没有填写，为了不影响您的领奖，请先完善这些资料。谢谢！", "UserEdit.aspx");
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
                else if (base._User.ID == _Convert.StrToLong(this.HidFollowUserID.Value, 0L))
                {
                    JavaScript.Alert(this.Page, "您不能定制自己的跟单!");
                }
                else if (new Tables.T_CustomFriendFollowSchemes { SiteID = { Value = 1 }, UserID = { Value = base._User.ID }, FollowUserID = { Value = this.HidFollowUserID.Value }, LotteryID = { Value = this.ddlLotteries.SelectedValue }, PlayTypeID = { Value = this.ddlPlayTypes.SelectedValue }, MoneyStart = { Value = num }, MoneyEnd = { Value = num2 }, BuyShareStart = { Value = num3 }, BuyShareEnd = { Value = num4 }, Type = { Value = 1 } }.Update("FollowUserID = " + Utility.FilteSqlInfusion(this.HidFollowUserID.Value) + " and UserID = " + Utility.FilteSqlInfusion(this.HidUserID.Value)) > 0L)
                {
                    Shove._Web.Cache.ClearCache("T_CustomFriendFollowSchemes" + this.ddlLotteries.SelectedValue);
                    if (this.ddlLotteries.SelectedValue == "-1")
                    {
                        foreach (KeyValuePair<int, string> pair in DataCache.Lotteries)
                        {
                            Shove._Web.Cache.ClearCache("T_CustomFriendFollowSchemes" + pair.Key.ToString());
                        }
                    }
                    base.Response.Write("<script>window.returnValue=1;alert('修改自动跟单成功');window.close();</script>");
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
                if (this.ddlPlayTypes.Items.FindByValue(this.HidPlayTypeID.Value) != null)
                {
                    this.ddlPlayTypes.SelectedValue = this.HidPlayTypeID.Value;
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
            this.lbUserName.Text = HttpUtility.UrlDecode(Utility.GetRequest("FollowUserName"));
            int followUserID = _Convert.StrToInt(Utility.GetRequest("FollowUserID"), -1);
            int num2 = _Convert.StrToInt(Utility.GetRequest("UserID"), -1);
            if (((followUserID < 0) || (this.lbUserName.Text == "")) || (num2 < 0))
            {
                PF.GoError(1, "参数错误，系统异常。", base.GetType().BaseType.FullName);
            }
            else
            {
                this.HidFollowUserID.Value = followUserID.ToString();
                this.HidUserID.Value = num2.ToString();
                this.BindData(followUserID);
            }
        }
    }
}

