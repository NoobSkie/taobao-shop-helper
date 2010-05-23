using DAL;
using System;
using System.Reflection;

public class Competences
{
    public const string AddMoney = "AddMoney";
    public const string Administrator = "Administrator";
    public const string Competence = "Competence";
    public const string CpsManage = "CpsManage";
    public const string DistillMoney = "DistillMoney";
    public const string EditNews = "EditNews";
    public const string FillContent = "FillContent";
    public const string Finance = "Finance";
    public const string Log = "Log";
    public const string LotteryBuy = "LotteryBuy";
    public const string LotteryIsuseScheme = "LotteryIsuseScheme";
    public const string LotteryWin = "LotteryWin";
    public const string MemberManagement = "MemberManagement";
    public const string MemberService = "MemberService";
    public const string Options = "Options";
    public const string QueryData = "QueryData";
    public const string Score = "Score";
    public const string SendMessage = "SendMessage";
    public Users User;

    public Competences()
    {
        this.User = null;
    }

    public Competences(Users user)
    {
        this.User = user;
    }

    public static string BuildCompetencesList(params string[] CompetenceList)
    {
        string str = "";
        foreach (string str2 in CompetenceList)
        {
            str = str + "[" + str2 + "]";
        }
        return str;
    }

    public bool IsOwnedCompetences(string RequestCompetencesList)
    {
        if ((this.User == null) || (this.User.ID < 1L))
        {
            throw new Exception("没有初始化 Competences 类的 User 变量");
        }
        string competencesList = this.CompetencesList;
        if (competencesList.IndexOf("[Administrator]") >= 0)
        {
            return true;
        }
        RequestCompetencesList = RequestCompetencesList.Trim();
        if (RequestCompetencesList == "")
        {
            return true;
        }
        RequestCompetencesList = RequestCompetencesList.Replace("][", ",");
        RequestCompetencesList = RequestCompetencesList.Substring(1, RequestCompetencesList.Length - 2);
        string[] strArray = RequestCompetencesList.Split(new char[] { ',' });
        bool flag = false;
        foreach (string str2 in strArray)
        {
            if ((competencesList.IndexOf("[" + str2 + "]") >= 0) && !flag)
            {
                flag = true;
            }
        }
        return flag;
    }

    public int SetUserCompetences(string CompetencesList, string GroupsList, ref string ReturnDescription)
    {
        if ((this.User == null) || (this.User.ID < 1L))
        {
            throw new Exception("没有初始化 Competences 类的 User 变量");
        }
        int returnValue = -1;
        ReturnDescription = "";
        if (Procedures.P_SetUserCompetences(this.User.Site.ID, this.User.ID, CompetencesList, GroupsList, ref returnValue, ref ReturnDescription) < 0)
        {
            ReturnDescription = "数据库读写错误";
            return -1;
        }
        if (returnValue < 0)
        {
            return returnValue;
        }
        return 0;
    }

    public string CompetencesList
    {
        get
        {
            if ((this.User == null) || (this.User.ID < 1L))
            {
                throw new Exception("没有初始化 Competences 类的 User 变量");
            }
            return Functions.F_GetUserCompetencesList(this.User.ID);
        }
    }

    public bool this[string CompetenceName]
    {
        get
        {
            if ((this.User == null) || (this.User.ID < 1L))
            {
                throw new Exception("没有初始化 Competences 类的 User 变量");
            }
            return (Functions.F_GetUserCompetencesList(this.User.ID).IndexOf("[" + CompetenceName + "]") >= 0);
        }
    }
}

