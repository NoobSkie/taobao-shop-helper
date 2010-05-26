using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using AjaxPro;
using Shove._Web;
using Shove;
using Shove._IO;

public partial class Lottery_CQSSC_Buy : LotteryBasePage
{
    protected override string LotteryCode
    {
        get { return "CQSSC"; }
    }

    protected override string LotteryId
    {
        get { return "28"; }
    }
}
