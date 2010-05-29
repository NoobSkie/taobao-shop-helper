using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using J.SLS.Facade;

public abstract class LotteryBasePage : BasePage
{
    protected LotteryFacade lotteryFacade = new LotteryFacade();

    private LotterySimpleInfo lotteryInfo = null;
    protected LotteryInfoBase CurrentLottery
    {
        get
        {
            return lotteryInfo;
        }
    }

    protected int LotteryId
    {
        get
        {
            return 28;
            // return CurrentLottery.Id;
        }
    }

    protected abstract string LotteryCode { get; }

    protected string LotteryName
    {
        get
        {
            return "重庆时时彩";
            // return CurrentLottery.Name;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }
}
