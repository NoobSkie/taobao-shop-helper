using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using J.SLS.Facade;

public abstract class LotteryBasePage : BasePage
{
    protected LotteryFacade lotteryFacade = new LotteryFacade();

    protected abstract string LotteryCode { get; }

    protected abstract string LotteryId { get; }

    protected override void OnLoad(EventArgs e)
    {
        LotterySimpleInfo lotteryInfo = lotteryFacade.GetLotteryInfoByCode<LotterySimpleInfo>(LotteryCode);
        if (!lotteryInfo.IsUsed)
        {
            Response.Redirect("~/Default.aspx");
        }

        base.OnLoad(e);
    }
}
