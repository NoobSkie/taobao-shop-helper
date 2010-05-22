using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Room_UserBuySuccess : RoomPageBase
{
    public string URL = "";
    public string script = "";
    public static Dictionary<int, string> Lotteries = new Dictionary<int, string>();

    static Home_Room_UserBuySuccess()
    {
        Lotteries[59] = "15X5";
        Lotteries[9] = "22X5";
        Lotteries[65] = "31X7";
        Lotteries[6] = "3D";
        Lotteries[39] = "CJDLT";
        Lotteries[58] = "DF6J1";
        Lotteries[2] = "JQC";
        Lotteries[15] = "LCBQC";
        Lotteries[63] = "PL3";
        Lotteries[64] = "PL5";
        Lotteries[13] = "QLC";
        Lotteries[3] = "QXC";
        Lotteries[1] = "SFC";
        Lotteries[61] = "SSC";
        Lotteries[29] = "SSL";
        Lotteries[28] = "CQSSC";
        Lotteries[5] = "SSQ";
        Lotteries[62] = "SYYDJ";
        Lotteries[70] = "JX11X5";
        Lotteries[41] = "ZJTC6J1";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbName.Text = _User.Name;
            lbName1.Text = _User.Name;
            lbBalance.Text = _User.Balance.ToString("N");

            string Type = Shove._Web.Utility.GetRequest("Type");
            int LotteryID = Shove._Convert.StrToInt( Shove._Web.Utility.GetRequest("LotteryID"),5);
            string SchemeID = Shove._Web.Utility.GetRequest("SchemeID");
            string Money = Shove._Web.Utility.GetRequest("Money");

            SystemOptions so = new SystemOptions();
            lbScore.Text = (Shove._Convert.StrToDouble(_Site.SiteOptions["Opt_ScoringExchangeRate"].ToString("1"), 1) * Shove._Convert.StrToDouble(Money, 0)).ToString("N");

            if (Type == "2")
            {
                lbType.Text = "追号";
                lbType1.Text = "[继续追号]";
                Look.Visible = false;
            }
            if (Type == "3")
            {
                lbType.Text = "入伙";
                lbType1.Text = "[继续入伙]";
            }

            if (Type == "3")
            {
                Buy.HRef = "Scheme.aspx?id="+SchemeID;
            }
            else
            {
                Buy.HRef = "../../Lottery/Buy_" + Lotteries[LotteryID] + ".aspx";
            }

            Look.HRef = "Scheme.aspx?id="+SchemeID;
            URL = Buy.HRef;
            script = "window.setInterval('DisplayTimer()', 1000);";
        }
    }

    #region Web 窗体设计器生成的代码

    override protected void OnInit(EventArgs e)
    {
        RequestLoginPage = this.Request.Url.AbsoluteUri;

        base.OnInit(e);
    }

    #endregion
}
