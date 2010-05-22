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

public partial class Home_Room_MyPromotion_MemberPromotion : RoomPageBase, IRequiresSessionState
{



    private void BindData()
    {
        string key = "Home_Room_MyPromotion_MemberPromotion_BindData" + base._User.ID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        double num2 = 0.0;
        double num3 = 0.0;
        double num4 = 0.0;
        double num5 = 0.0;
        if (cacheAsDataTable == null)
        {
            int returnValue = -1;
            string returnDescription = "";
            DataSet ds = null;
            if (Procedures.P_CpsGetCommendMemberList(ref ds, base._User.ID, ref returnValue, ref returnDescription) < 0)
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
        DataTable dt = cacheAsDataTable.Clone();
        dt.Columns.Add("Count", typeof(int));
        string filterExpression = "1=1";
        if ((this.tbUserName.Text != "") && (this.tbUserName.Text != "请输入用户名"))
        {
            filterExpression = "Name like '%" + Utility.FilteSqlInfusion(this.tbUserName.Text) + "%'";
        }
        DataRow[] rowArray = cacheAsDataTable.Select(filterExpression);
        for (int i = 0; i < rowArray.Length; i++)
        {
            dt.Rows.Add(rowArray[i].ItemArray);
            dt.Rows[i]["Count"] = i + 1;
            num2 += _Convert.StrToDouble(rowArray[i]["TodayTradeMoney"].ToString(), 0.0);
            num3 += _Convert.StrToDouble(rowArray[i]["YesterdayTradeMoney"].ToString(), 0.0);
            num4 += _Convert.StrToDouble(rowArray[i]["ThisMonthTradeMoney"].ToString(), 0.0);
            num5 += _Convert.StrToDouble(rowArray[i]["TotalTradeMoney"].ToString(), 0.0);
        }
        this.lbTodaySales1.Text = string.Format("{0:0.00}", num2);
        this.lbYesterdaySales1.Text = string.Format("{0:0.00}", num3);
        this.lbMonthSales1.Text = string.Format("{0:0.00}", num4);
        this.lbSales1.Text = string.Format("{0:0.00}", num5);
        PF.DataGridBindData(this.g, dt, this.gPager);
    }

    private void BindDataForYearMonth()
    {
        this.ddlYear.Items.Clear();
        DateTime now = DateTime.Now;
        int year = now.Year;
        int month = now.Month;
        if (year < 0x7d8)
        {
            this.btnSearch.Enabled = false;
        }
        else
        {
            for (int i = 0x7d8; i <= year; i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString() + "年", i.ToString()));
            }
            this.ddlYear.SelectedIndex = this.ddlYear.Items.Count - 1;
        }
    }

    private void BindTransactionList()
    {
        DateTime time2;
        DateTime time4;
        if (this.ddlMonth.SelectedValue == "0")
        {
            time2 = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
            time4 = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-12-31");
        }
        else
        {
            time2 = Convert.ToDateTime(this.ddlYear.SelectedValue + "-" + this.ddlMonth.SelectedValue + "-1");
            time4 = time2.AddMonths(1).AddTicks(-1L);
        }
        string key = "Home_Room_MyPromotion_MemberPromotion_BindTransactionList" + base._User.ID.ToString() + time2.ToShortDateString() + time4.ToShortDateString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            DataSet ds = null;
            int returnValue = 0;
            string returnDescription = "";
            if (Procedures.P_GetCpsPopularizeAccountRevenue(ref ds, base._Site.ID, base._User.ID, time2, time4, 2, ref returnValue, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            if (returnValue < 0)
            {
                JavaScript.Alert(this.Page, returnDescription);
                return;
            }
            if (ds == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            if (ds.Tables.Count > 0)
            {
                cacheAsDataTable = ds.Tables[0];
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable);
        }
        PF.DataGridBindData(this.g1, cacheAsDataTable, this.gPager1);
        this.summation(cacheAsDataTable);
        this.gPager1.Visible = this.g1.PageCount > 1;
        if (this.ddlMonth.SelectedValue == "0")
        {
            this.lbShow.Text = "本年";
        }
        else
        {
            this.lbShow.Text = "本月";
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        this.trLink.Style.Add("display", "");
        this.trMoney.Style.Add("display", "");
        if (this.rblMoney.SelectedValue == "0")
        {
            this.divOther.Style.Add("display", "");
        }
        int num = 0;
        if (this.rblMoney.SelectedValue == "0")
        {
            num = _Convert.StrToInt(base.Request.Form["tbMoney"], -1);
        }
        else
        {
            num = _Convert.StrToInt(this.rblMoney.SelectedValue, -1);
        }
        if (num < 1)
        {
            JavaScript.Alert(this.Page, "红包金额只能为整数金额！");
        }
        else
        {
            this.lbShowInfo.Text = "此链接包含" + num.ToString() + "元红包！";
            Tables.T_UserHongbaoPromotion promotion = new Tables.T_UserHongbaoPromotion
            {
                UserID = { Value = base._User.ID },
                Money = { Value = num },
                ExpiryDate = { Value = DateTime.Now.AddDays((double)_Convert.StrToInt(this.ddlDate.SelectedValue, 7)) }
            };
            long num2 = promotion.Insert();
            SynchronizeSessionID nid = new SynchronizeSessionID(this.Page);
            string str = base._User.ID.ToString();
            string str2 = nid.GenSign(new string[] { num2.ToString(), str });
            string str3 = Utility.GetUrl() + "/Home/Room/PromoteUserReg.aspx?id=" + num2.ToString() + "&userID=" + str + "&Sign=" + str2;
            promotion.URL.Value = str3;
            promotion.Update("ID=" + num2.ToString());
            this.tbUrl.Text = str3;
            Shove._Web.Cache.ClearCache("Home_Room_MyPromotion_HongBaoRecord" + base._User.ID.ToString());
            this.lbShowCreateResult.Text = "生成红包链接成功！";
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void btnSearch1_Click(object sender, EventArgs e)
    {
        this.BindTransactionList();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.EditItem)) || (e.Item.ItemType == ListItemType.Item))
        {
            Label label = e.Item.FindControl("lbDetail") as Label;
            label.Attributes.Add("onclick", "return GetUserAccountDetail(" + e.Item.Cells[8].Text + ");");
        }
    }

    protected void g1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.EditItem)) || (e.Item.ItemType == ListItemType.Item))
        {
            Label label = e.Item.FindControl("lbDetail") as Label;
            if (this.ddlMonth.SelectedValue == "0")
            {
                label.Attributes.Add("onclick", "return GetUserPromotionDetailByYear('" + _Convert.StrToInt(e.Item.Cells[0].Text.Split(new char[] { '-' })[1], 1) + "');");
            }
            else
            {
                label.Attributes.Add("onclick", "return GetUserPromotionDetail('" + _Convert.StrToDateTime(e.Item.Cells[0].Text, DateTime.Now.ToString()).ToString("yyyy-MM-dd") + "');");
            }
        }
        if (e.Item.ItemType == ListItemType.Header)
        {
            if (this.ddlMonth.SelectedValue == "0")
            {
                e.Item.Cells[1].Text = "当月会员交易量";
            }
            else
            {
                e.Item.Cells[1].Text = "本日会员交易量";
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

    protected void gPager1_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindTransactionList();
    }

    protected void gPager1_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindTransactionList();
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
            this.tbUrl.Text = base._User.GetPromotionURL(0);
            this.hidLink.Value = this.tbUrl.Text;
            this.BindDataForYearMonth();
            this.BindTransactionList();
            this.lbTotalBonus.Text = base._User.Bonus.ToString("N");
        }
    }

    public void summation(DataTable dt)
    {
        double num = 0.0;
        double num2 = 0.0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            num += _Convert.StrToDouble(dt.Rows[i]["DayTradeMoney"].ToString(), 0.0);
            num2 += _Convert.StrToDouble(dt.Rows[i]["DayBonusMoney"].ToString(), 0.0);
        }
        this.lbTradeSum.Text = num.ToString("N2");
        this.lbBonusSum.Text = num2.ToString("N2");
    }

 
}

