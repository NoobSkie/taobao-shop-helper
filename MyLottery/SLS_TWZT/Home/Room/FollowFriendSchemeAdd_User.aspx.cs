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

public partial class Home_Room_FollowFriendSchemeAdd_User : RoomPageBase, IRequiresSessionState
{

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
                    base.Response.Redirect("FollowSchemeHistory.aspx?Type='divSetMyFollowSchemes", true);
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
        base.Response.Redirect("FollowSchemeHistory.aspx?Type='divSetMyFollowSchemes'", true);
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
            long num = _Convert.StrToLong(Utility.GetRequest("FollowUserID"), -1L);
            int key = _Convert.StrToInt(Utility.GetRequest("LotteryID"), -1);
            if (!DataCache.Lotteries.ContainsKey(key))
            {
                key = 5;
            }
            if ((num < 0L) || (this.lbUserName.Text == ""))
            {
                PF.GoError(1, "参数错误，系统异常。", base.GetType().BaseType.FullName);
            }
            else
            {
                this.HidFollowUserID.Value = num.ToString();
                this.BindDataForLottery(key);
                //this.ddlLotteries.SelectedValue = -1;
                this.ddlLotteries.SelectedIndex = -1;
            }
        }
    }
}

