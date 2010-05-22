using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_OnlinePay_OK : RoomPageBase, IRequiresSessionState
{
    public string script = "";
    public string Url = "";

    private void BindData()
    {
        string request = Shove._Web.Utility.GetRequest("errMsg");
        this.lab1.Text = string.IsNullOrEmpty(request) ? base._Site.Name : HttpUtility.UrlDecode(request, Encoding.GetEncoding("GB2312"));
        long buyID = _Convert.StrToLong(Shove._Web.Utility.GetRequest("BuyID"), 0L);
        if (buyID > 0L)
        {
            this.GoBuy(buyID);
        }
        else
        {
            object cache = Shove._Web.Cache.GetCache("OnAlipayFromUrl");
            if (cache != null)
            {
                Shove._Web.Cache.ClearCache("OnAlipayFromUrl");
                this.Url = cache.ToString();
                this.HidScript.Value = "window.setInterval('DisplayTimer()', 1000);";
            }
        }
    }

    private void GoBuy(long BuyID)
    {
        DataTable table = new Tables.T_AlipayBuyTemp().Open("", "ID=" + BuyID.ToString(), "");
        if ((table != null) && (table.Rows.Count == 1))
        {
            string str = table.Rows[0]["LotteryID"].ToString();
            string str2 = table.Rows[0]["Number"].ToString();
            switch (str)
            {
                case "29":
                    this.Url = "../Buy_SSL.aspx?BuyID=" + BuyID.ToString();
                    break;

                case "62":
                    this.Url = "../Buy_SYYDJ.aspx?BuyID=" + BuyID.ToString();
                    break;

                case "61":
                    this.Url = "../Buy_SSC.aspx?BuyID=" + BuyID.ToString();
                    break;

                case "1":
                case "2":
                case "15":
                    this.Url = "../Buy_ZC.aspx?LotteryID=" + str + "&Number=" + str2 + "&BuyID=" + BuyID.ToString();
                    break;

                default:
                    this.Url = "../Buy.aspx?LotteryID=" + str + "&BuyID=" + BuyID.ToString();
                    break;
            }
            this.HidScript.Value = "window.setInterval('DisplayTimer()', 1000);";
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isAllowPageCache = false;
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_OnlinePay_OK), this.Page);
        if (!base.IsPostBack)
        {
            this.BindData();
        }
    }
}

