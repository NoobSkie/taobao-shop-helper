using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Web_Live800UserInfo : Page, IRequiresSessionState
{

    private void BindInvest(Users _User)
    {
        if (_User == null)
        {
            long num = _Convert.StrToLong(Encrypt.Decrypt3DES(PF.GetCallCert(), this.HiddenUserID.Value, PF.DesKey), -1L);
            if (num < 1L)
            {
                return;
            }
            _User = new Users(1L)[1L, num];
            if (_User.ID < 0L)
            {
                return;
            }
        }
        DateTime now = DateTime.Now;
        string key = "Home_Lottery_Invest_" + _User.ID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Views.V_BuyDetailsWithQuashedAll().Open("", "[UserID] = " + _User.ID.ToString(), " [DateTime] desc,[id]");
            if (cacheAsDataTable == null)
            {
                PF.GoError(1, "没有投注记录", base.GetType().FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
        }
        PF.DataGridBindData(this.gInvest, cacheAsDataTable, this.gPagerInvest);
        this.gPagerInvest.Visible = true;
        TimeSpan span = (TimeSpan)(DateTime.Now - now);
        if (span.TotalSeconds > 5.0)
        {
            new Log("Page").Write("函数" + base.GetType().FullName + ".BindInvest()耗时," + span.TotalSeconds.ToString());
        }
    }

    private void BindWin(Users _User)
    {
        if (_User == null)
        {
            long num = _Convert.StrToLong(Encrypt.Decrypt3DES(PF.GetCallCert(), this.HiddenUserID.Value, PF.DesKey), -1L);
            if (num < 1L)
            {
                return;
            }
            _User = new Users(1L)[1L, num];
            if (_User.ID < 0L)
            {
                return;
            }
        }
        DateTime now = DateTime.Now;
        string key = "Home_Lottery_BindRpReward_" + _User.ID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Views.V_BuyDetailsWithQuashedAll().Open("", "[UserID] = " + _User.ID.ToString() + " and WinMoneyNoWithTax > 0", " [DateTime] desc,[id]");
            if (cacheAsDataTable == null)
            {
                PF.GoError(1, "没有投注记录", base.GetType().FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
        }
        PF.DataGridBindData(this.gWin, cacheAsDataTable, this.gPagerWin);
        this.gPagerWin.Visible = true;
        TimeSpan span = (TimeSpan)(DateTime.Now - now);
        if (span.TotalSeconds > 5.0)
        {
            new Log("Page").Write("函数" + base.GetType().FullName + ".BindRpReward()耗时," + span.TotalSeconds.ToString());
        }
    }

    protected void g_ItemDataBoundInvest(object sender, DataGridItemEventArgs e)
    {
        if ((e.Item.ItemType != ListItemType.Item) && (e.Item.ItemType != ListItemType.AlternatingItem))
        {
            ListItemType itemType = e.Item.ItemType;
        }
    }

    protected void g_ItemDataBoundWin(object sender, DataGridItemEventArgs e)
    {
        if ((e.Item.ItemType != ListItemType.Item) && (e.Item.ItemType != ListItemType.AlternatingItem))
        {
            ListItemType itemType = e.Item.ItemType;
        }
    }

    protected void gPagerInvest_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindInvest(null);
    }

    protected void gPagerInvest_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindInvest(null);
    }

    protected void gPagerWin_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindWin(null);
    }

    protected void gPagerWin_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindWin(null);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            string request = Utility.GetRequest("userId");
            this.HiddenUserID.Value = request;
            long num = _Convert.StrToLong(Encrypt.Decrypt3DES(PF.GetCallCert(), request, PF.DesKey), -1L);
            if (num >= 1L)
            {
                Users users = new Users(1L)[1L, num];
                if (users.ID >= 0L)
                {
                    this.lbName.Text = users.Name;
                    this.lbRegTime.Text = users.RegisterTime.ToString("yyyy-MM-dd HH:mm:ss");
                    this.lbRealityName.Text = users.RealityName;
                    this.lbBalance.Text = users.Balance.ToString("N");
                    this.lbTel.Text = users.Telephone;
                    this.lbMobile.Text = users.Mobile;
                    this.lbQQ.Text = users.QQ;
                    this.lbEmail.Text = users.Email;
                    this.lbAlipayName.Text = users.AlipayName;
                    this.BindInvest(users);
                    this.BindWin(users);
                }
            }
        }
    }
}

