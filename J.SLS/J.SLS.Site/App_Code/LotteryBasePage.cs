using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using J.SLS.Facade;
using HPGatewayModels;
using System.Configuration;

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

    protected AccountNumber GetAccountNumber()
    {
        if (ConfigurationManager.AppSettings["AgenceAccount"] == null
            || ConfigurationManager.AppSettings["AgencePassword"] == null)
        {
            throw new ArgumentNullException("未配置代理商账号！");
        }
        AccountNumber accountN = new AccountNumber();
        accountN.UserName = ConfigurationManager.AppSettings["AgenceAccount"];
        accountN.UserPassword = ConfigurationManager.AppSettings["AgencePassword"];
        return accountN;
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

    public static string BuildIsuseAdditionasXmlFor1Team(int Count, params string[] str)
    {
        string str2 = "<Teams>";
        for (int i = 0; i < Count; i++)
        {
            string str3 = str2;
            string[] strArray = new string[] { str3, "<Team No=\"", (i + 1).ToString(), "\" Team=\"", str[i * 2], "\" Time=\"", str[(i * 2) + 1], "\"/>" };
            str2 = string.Concat(strArray);
        }
        return (str2 + "</Teams>");
    }

    public static string BuildIsuseAdditionasXmlFor2Team(int Count, params string[] str)
    {
        string str2 = "<Teams>";
        for (int i = 0; i < Count; i++)
        {
            string str3 = str2;
            string[] strArray = new string[] { str3, "<Team No=\"", (i + 1).ToString(), "\" HostTeam=\"", str[i * 3], "\" QuestTeam=\"", str[(i * 3) + 1], "\" Time=\"", str[(i * 3) + 2], "\"/>" };
            str2 = string.Concat(strArray);
        }
        return (str2 + "</Teams>");
    }

    public static string BuildIsuseAdditionasXmlForBJKL8(params string[] str)
    {
        string str2 = "<ChaseDetail>";
        for (int i = 0; i < (str.Length / 9); i++)
        {
            string str3 = str2;
            str2 = str3 + "<Isuse IsuseID=\"" + str[i * 9] + "\" PlayTypeID = \"" + str[(i * 9) + 1] + "\" LotteryNumber = \"" + str[(i * 9) + 2] + "\" Multiple = \"" + str[(i * 9) + 3] + "\" Money = \"" + str[(i * 9) + 4] + "\" SecrecyLevel =\"" + str[(i * 9) + 5] + "\" Share=\"" + str[(i * 9) + 6] + "\" BuyedShare=\"" + str[(i * 9) + 7] + "\" AssureShare=\"" + str[(i * 9) + 8] + "\"/>";
        }
        return (str2 = str2 + "</ChaseDetail>");
    }

    public static string BuildIsuseAdditionasXmlForChase(params string[] str)
    {
        string str2 = "<ChaseDetail>";
        for (int i = 0; i < (str.Length / 6); i++)
        {
            string str3 = str2;
            str2 = str3 + "<Isuse IsuseID=\"" + str[i * 6] + "\" PlayTypeID = \"" + str[(i * 6) + 1] + "\" LotteryNumber = \"" + str[(i * 6) + 2] + "\" Multiple = \"" + str[(i * 6) + 3] + "\" Money = \"" + str[(i * 6) + 4] + "\" SecrecyLevel =\"" + str[(i * 6) + 5] + "\" Share=\"1\" BuyedShare=\"1\" AssureShare=\"0\"/>";
        }
        return (str2 = str2 + "</ChaseDetail>");
    }

    public static string BuildIsuseAdditionasXmlForZCDC(params string[] str)
    {
        string str2 = "<Teams>";
        for (int i = 0; i < (str.Length / 5); i++)
        {
            string str3 = str2;
            string[] strArray = new string[] { str3, "<Team LeagueTypeID=\"", str[i * 5], "\" No=\"", (i + 1).ToString(), "\" HostTeam=\"", str[(i * 5) + 1], "\" QuestTeam=\"", str[(i * 5) + 2], "\" LetBall=\"", str[(i * 5) + 3], "\" Time=\"", str[(i * 5) + 4], "\"/>" };
            str2 = string.Concat(strArray);
        }
        return (str2 + "</Teams>");
    }
}
