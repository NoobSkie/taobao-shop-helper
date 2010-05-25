using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Components_WebControls_LotteryImageItem : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        imgMain.ImageUrl = string.Format("~/Images/game_{0}.jpg", ImageIndex);
        hlnkDrawa.NavigateUrl = string.Format("~/Core/DrawaLotteryInfo.aspx?Lottery={0}", LotteryCode);
        hlnkBehavior.NavigateUrl = string.Format("~/Core/DataBehavior.aspx?Lottery={0}", LotteryCode);
        hlnkBuy.NavigateUrl = string.Format("~/Lottery/{0}/Buy.aspx", LotteryCode);
    }

    public string LotteryCode { get; set; }

    public string ImageIndex { get; set; }
}
