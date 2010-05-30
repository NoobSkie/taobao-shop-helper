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

    public int InitiateChaseTask(UserInfo userInfo, string Title, string Description, int LotteryID, double StopWhenWinMoney, string DetailXML, string LotteryNumber, double SchemeBonusScalec, ref string ReturnDescription)
    {
        if (userInfo == null)
        {
            throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
        }
        ReturnDescription = "";
        long chaseTaskID = -1L;
        if (Procedures.P_InitiateChaseTask(this.Site.ID, this.ID, Title, Description, LotteryID, StopWhenWinMoney, DetailXML, LotteryNumber, SchemeBonusScalec, ref chaseTaskID, ref ReturnDescription) < 0)
        {
            ReturnDescription = "数据库读写错误";
            return -1;
        }
        if (chaseTaskID >= 0L)
        {
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            if ((this.Email != "") && Functions.F_GetIsSendNotification(this.SiteID, 2, "InitiateChaseTask", this.ID))
            {
                string subject = "";
                string body = "";
                this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "InitiateChaseTask"], ref subject, ref body);
                if ((subject != "") && (body != ""))
                {
                    subject = subject.Replace("[UserName]", this.Name);
                    body = body.Replace("[UserName]", this.Name).Replace("[Chase_id]", chaseTaskID.ToString());
                    PF.SendEmail(this.Site, this.Email, subject, body);
                }
            }
            if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "InitiateChaseTask", this.ID))
            {
                string content = this.Site.SiteNotificationTemplates[1, "InitiateChaseTask"];
                if (content != "")
                {
                    content = content.Replace("[UserName]", this.Name).Replace("[Chase_id]", chaseTaskID.ToString());
                    PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                }
            }
            if (Functions.F_GetIsSendNotification(this.SiteID, 3, "InitiateChaseTask", this.ID))
            {
                string str5 = this.Site.SiteNotificationTemplates[3, "InitiateChaseTask"];
                if (str5 != "")
                {
                    str5 = str5.Replace("[UserName]", this.Name).Replace("[Chase_id]", chaseTaskID.ToString());
                    PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str5);
                }
            }
        }
        return (int)chaseTaskID;
    }

    public int InitiateCustomChase(int LotteryID, int PlayTypeID, int Price, short Type, DateTime EndTime, int IsuseCount, int Multiple, int Nums, short BetType, string LotteryNumber, short StopType, double stopMoney, double Money, string Title, string ChaseXML, ref string ReturnDescription)
    {
        if (this.ID < 0L)
        {
            throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
        }
        ReturnDescription = "";
        int chaseID = -1;
        if (Procedures.P_ChasesAdd(this.ID, LotteryID, PlayTypeID, Price, Type, DateTime.Now, EndTime, IsuseCount, Multiple, Nums, BetType, LotteryNumber, StopType, stopMoney, Money, Title, ChaseXML, ref chaseID, ref ReturnDescription) < 0)
        {
            ReturnDescription = "数据库读写错误";
            return -1;
        }
        if (chaseID >= 0)
        {
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            if (((this.Email != "") && this.isEmailValided) && Functions.F_GetIsSendNotification(this.SiteID, 2, "IntiateCustomChase", this.ID))
            {
                string subject = "";
                string body = "";
                this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "IntiateCustomChase"], ref subject, ref body);
                if ((subject != "") && (body != ""))
                {
                    subject = subject.Replace("[UserName]", this.Name);
                    body = body.Replace("[UserName]", this.Name).Replace("[Chase_id]", chaseID.ToString());
                    PF.SendEmail(this.Site, this.Email, subject, body);
                }
            }
            if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "IntiateCustomChase", this.ID))
            {
                string content = this.Site.SiteNotificationTemplates[1, "IntiateCustomChase"];
                if (content != "")
                {
                    content = content.Replace("[UserName]", this.Name).Replace("[Chase_id]", chaseID.ToString());
                    PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                }
            }
            if (Functions.F_GetIsSendNotification(this.SiteID, 3, "IntiateCustomChase", this.ID))
            {
                string str5 = this.Site.SiteNotificationTemplates[3, "IntiateCustomChase"];
                if (str5 != "")
                {
                    str5 = str5.Replace("[UserName]", this.Name).Replace("[ChaseID]", chaseID.ToString());
                    PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str5);
                }
            }
        }
        return chaseID;
    }


    public long InitiateScheme(UserInfo user, long IsuseID, int PlayTypeID, string Title, string Description, string LotteryNumber, string UpdateloadFileContent, int Multiple, double Money, double AssureMoney, int Share, int BuyShare, string OpenUsers, short SecrecyLevel, double SchemeBonusScale, ref string ReturnDescription)
    {
        if (string.IsNullOrEmpty(this.UserId))
        {
            throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
        }
        ReturnDescription = "";
        if ((SecrecyLevel < 0) || (SecrecyLevel > 3))
        {
            SecrecyLevel = 0;
        }
        long schemeID = -1L;
        if (Procedures.P_InitiateScheme(this.SiteID, user.UserId, IsuseID, PlayTypeID, Title, Description, LotteryNumber, UpdateloadFileContent, Multiple, Money, AssureMoney, Share, BuyShare, OpenUsers.Replace('，', ','), SecrecyLevel, SchemeBonusScale, ref schemeID, ref ReturnDescription) < 0)
        {
            ReturnDescription = "数据库读写错误";
            return -1L;
        }
        if (schemeID >= 0L)
        {
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            if ((this.Email != "") && Functions.F_GetIsSendNotification(this.SiteID, 2, "InitiateScheme", this.ID))
            {
                string subject = "";
                string body = "";
                this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "InitiateScheme"], ref subject, ref body);
                if ((subject != "") && (body != ""))
                {
                    subject = subject.Replace("[UserName]", this.Name);
                    body = body.Replace("[UserName]", this.Name).Replace("[SchemeID]", schemeID.ToString()).Replace("[LotteryNumber]", LotteryNumber.Replace("\n", "<BR />")).Replace("[Multiple]", Multiple.ToString()).Replace("[Money]", Money.ToString("N")).Replace("[AssureMoney]", AssureMoney.ToString("N")).Replace("[Share]", Share.ToString()).Replace("[BuyShare]", BuyShare.ToString()).Replace("[OpenUserList]", OpenUsers);
                    PF.SendEmail(this.Site, this.Email, subject, body);
                }
            }
            if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "InitiateScheme", this.ID))
            {
                string content = this.Site.SiteNotificationTemplates[1, "InitiateScheme"];
                if (content != "")
                {
                    content = content.Replace("[UserName]", this.Name).Replace("[SchemeID]", schemeID.ToString());
                    PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                }
            }
            if (Functions.F_GetIsSendNotification(this.SiteID, 3, "InitiateScheme", this.ID))
            {
                string str5 = this.Site.SiteNotificationTemplates[3, "InitiateScheme"];
                if (str5 != "")
                {
                    str5 = str5.Replace("[UserName]", this.Name).Replace("[SchemeID]", schemeID.ToString());
                    PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str5);
                }
            }
        }
        return schemeID;
    }
}
