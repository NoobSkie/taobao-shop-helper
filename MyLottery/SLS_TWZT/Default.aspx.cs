using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default : RoomPageBase, IRequiresSessionState
{
    public string script = "";

    private void BindData()
    {
        if (base._User != null)
        {
            this.lbUserName.Text = base._User.Name;
            this.lbUserType.Text = (base._User.UserType == 1) ? "普通用户" : ((base._User.UserType == 3) ? "VIP" : "高级用户");
            this.trAdmin.Visible = base._User.Competences.CompetencesList != "";
            this.hlAdmin.NavigateUrl = base.ResolveUrl("~/Admin/Default.aspx");
            this.pLoginning.Visible = true;
        }
        else
        {
            this.pNoLogin.Visible = true;
        }
        this.tbSSQ.InnerHtml = this.GetIsuseInfo(5);
        this.tbSSL.InnerHtml = this.GetIsuseInfo(0x1d);
        this.tbFC3D.InnerHtml = this.GetIsuseInfo(6);
        this.tbDLT.InnerHtml = this.GetIsuseInfo(0x27);
        this.tbSYYDJ.InnerHtml = this.GetIsuseInfo(0x3e);
        this.tdSSQWinList.InnerHtml = this.GetWinNoticeByLotteryID(5);
        this.tdDLTWinList.InnerHtml = this.GetWinNoticeByLotteryID(0x27);
        this.tdFC3DWinList.InnerHtml = this.GetWinNoticeByLotteryID(6);
        this.tdSSLWinList.InnerHtml = this.GetWinNoticeByLotteryID(0x1d);
        this.tdSYYDJWinList.InnerHtml = this.GetWinNoticeByLotteryID(0x3e);
        this.tbFCZX.InnerHtml = this.BindNews("福彩资讯");
        this.tbTCZX.InnerHtml = this.BindNews("体彩资讯");
        this.tbZCZX.InnerHtml = this.BindNews("足彩资讯");
        this.BindWinList();
        this.BindFocusNews();
        this.BindSiteAffiches();
        this.BindImageNews();
        this.divFriendLinks.InnerHtml = this.GetFriendLinks();
    }

    private void BindFocusNews()
    {
        DataTable focusNews = this.GetFocusNews();
        DataRow[] rowArray = focusNews.Select("IsMaster=1");
        if (rowArray.Length != 0)
        {
            this.tdFocusNews.InnerHtml = "<a href='" + rowArray[0]["Url"].ToString() + "' target='_blank' class='red16'>" + _String.Cut(rowArray[0]["Title"].ToString(), 20) + "</a>";
            rowArray = focusNews.Select("IsMaster=0", "[Order] asc,ID desc");
            StringBuilder builder = new StringBuilder();
            builder.Append("<table width='100%'>");
            for (int i = 0; i < rowArray.Length; i++)
            {
                if ((i % 2) == 0)
                {
                    builder.Append("<tr>");
                    builder.Append("<td align='left'><a href='" + rowArray[i]["Url"].ToString() + "' target='_blank'>[" + _String.Cut(rowArray[i]["Title"].ToString(), 0x1d) + "]</a></td>");
                }
                else
                {
                    builder.Append("<td align='left'><a href='" + rowArray[i]["Url"].ToString() + "' target='_blank'>[" + _String.Cut(rowArray[i]["Title"].ToString(), 0x1d) + "]</a></td>");
                    builder.Append("</tr>");
                }
            }
            builder.Append("</table>");
            this.tbFocusNews.InnerHtml = builder.ToString();
        }
    }

    private void BindImageNews()
    {
        string key = "Home_Room_UserControls_Index_banner_ImagePlay";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_FocusImageNews().Open("", "", "ID Desc");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
        }
        DataRow[] rowArray = cacheAsDataTable.Select("IsBig=0", "ID desc");
        if (rowArray.Length > 0)
        {
            this.tbImageNews.Visible = true;
            this.ImageHref1.HRef = rowArray[0]["Url"].ToString();
            this.Image1.Src = "Private/" + base._Site.ID.ToString() + "/NewsImages/" + rowArray[0]["ImageUrl"].ToString();
            this.tdTitle1.InnerHtml = _String.Cut(rowArray[0]["Title"].ToString(), 8);
            this.Image1.Alt = this.tdTitle1.InnerHtml;
            if (rowArray.Length > 1)
            {
                this.tdTitle2.Visible = true;
                this.tdImage2.Visible = true;
                this.ImageHref2.HRef = rowArray[1]["Url"].ToString();
                this.Image2.Src = "Private/" + base._Site.ID.ToString() + "/NewsImages/" + rowArray[1]["ImageUrl"].ToString();
                this.tdTitle2.InnerHtml = _String.Cut(rowArray[1]["Title"].ToString(), 8);
                this.Image2.Alt = this.tdTitle2.InnerHtml;
            }
        }
    }

    private string BindNews(string typeName)
    {
        DataRow[] rowArray = this.GetNews().Select("TypeName='" + typeName + "'", "ID desc");
        StringBuilder builder = new StringBuilder();
        string input = "";
        bool flag = false;
        string str2 = "";
        foreach (DataRow row in rowArray)
        {
            input = row["Title"].ToString();
            if ((input.IndexOf("<font class=red12>") > -1) || (input.IndexOf("<font class=black12>") > -1))
            {
                if (input.Contains("<font class=red12>"))
                {
                    str2 = "red12";
                }
                if (input.Contains("<font class=black12>"))
                {
                    str2 = "black12";
                }
                input = input.Replace("<font class=red12>", "").Replace("<font class=black12>", "").Replace("</font>", "");
                flag = true;
            }
            builder.AppendLine("<tr>").AppendLine("<td width=\"5%\" height=\"26\"><span class=\"red18\">&#9642;&nbsp;</span></td>").Append("<td width=\"95%\" height=\"26\" class=\"blue12_3\">").Append("<a href='");
            builder.Append(row["Content"].ToString());
            builder.Append("' target='_blank'>");
            if (flag)
            {
                builder.Append("<font class='" + str2 + "'>").Append(_String.Cut(input, 0x18)).Append("</font>");
            }
            else
            {
                builder.Append(_String.Cut(input, 0x18));
            }
            builder.AppendLine("</a></td>").AppendLine("</tr>");
        }
        return builder.ToString();
    }

    private void BindSiteAffiches()
    {
        StringBuilder builder = new StringBuilder();
        string input = "";
        bool flag = false;
        foreach (DataRow row in this.GetSiteAffiches().Rows)
        {
            input = row["Title"].ToString();
            flag = input.IndexOf("class=red12") > 0;
            if (flag)
            {
                input = input.Replace("<font class=red12>", "").Replace("</font>", "");
            }
            builder.AppendLine("<tr>").AppendLine("<td width=\"5%\" height=\"24\"><span class=\"red18\">&#9642;&nbsp;</span></td>").Append("<td width=\"95%\" height=\"24\" class=\"blue12_4\" align='left'>").Append("<a href='");
            builder.Append(row["Content"].ToString());
            builder.Append("' target='_blank'>");
            if (flag)
            {
                builder.Append("<font class=red12>").Append(_String.Cut(input, 0x1d)).Append("</font>");
            }
            else
            {
                builder.Append(_String.Cut(input, 0x1d));
            }
            builder.AppendLine("</a></td>").AppendLine("</tr>");
        }
        this.tbSiteAffiches.InnerHtml = builder.ToString();
    }

    private void BindWinList()
    {
        StringBuilder builder = new StringBuilder();
        DataTable userListByWinMoney = this.GetUserListByWinMoney();
        int num = 0;
        string s = "";
        string str2 = "";
        string input = "";
        foreach (DataRow row in userListByWinMoney.Rows)
        {
            str2 = _Convert.StrToDouble(row["Win"].ToString(), 0.0).ToString("N0").Split(new char[] { '.' })[0];
            input = row["InitiateName"].ToString();
            num++;
            builder.AppendLine("<tr>").Append("<td width=\"10%\" height=\"28\" align='center'>").Append("<img src=\"Home/Room/images/num_" + num.ToString() + ".gif\" width=\"13\" height=\"13\" />").AppendLine("</td>").Append("<td width=\"31%\" class=\"blue12\" align='left' title='" + input + "'>").Append("<a href='Home/Web/Score.aspx?id=").Append(row["InitiateUserID"].ToString()).Append("&LotteryID=62' target='_blank'>&nbsp;").Append(_String.Cut(input, 4)).Append("</a>").AppendLine("</td>").Append("<td width=\"35%\" class=\"hui12\" align='right'>");
            builder.Append(str2).AppendLine("元</td>").Append("<td width=\"24%\" class=\"red12_3\" align='center'>");
            s = "followScheme(62);$Id(\"iframeFollowScheme\").src=\"../Home/Room/FollowFriendSchemeAdd.aspx?LotteryID=62&FollowUserID=" + row["InitiateUserID"].ToString() + "&FollowUserName=" + HttpUtility.UrlEncode(row["InitiateName"].ToString()) + "\"";
            s = Encrypt.EncryptString(PF.GetCallCert(), s);
            s = "<a href='Lottery/Buy_SYYDJ.aspx?DZ=" + s + "' onclick=\"return CreateLogin();\">";
            builder.Append(s + "定制</a>").AppendLine("</td>").AppendLine("</tr>");
        }
        this.tbWin.InnerHtml = builder.ToString();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string returnDescription = "";
        int num = -1;
        if (this.Panel1.Visible)
        {
            num = new Login().LoginSubmit(this.Page, base._Site, this.tbFormUserName.Text, this.tbFormUserPassword.Text, this.tbFormCheckCode.Text, this.ShoveCheckCode1, ref returnDescription);
        }
        else
        {
            num = new Login().LoginSubmit(this.Page, base._Site, this.tbFormUserName.Text, this.tbFormUserPassword.Text, ref returnDescription);
        }
        if (num < 0)
        {
            this.Panel1.Visible = true;
            JavaScript.Alert(this.Page, returnDescription);
        }
        else
        {
            new Login().GoToRequestLoginPage("~/");
        }
    }

    private string FormatWinNumber(int LotteryID, string winNumber)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<td width=\"68%\" style=\"font-weight:bold\">").Append("<table border=\"0\" cellspacing=\"3\" cellpadding=\"0\">").Append("<tr>");
        switch (LotteryID)
        {
            case 0x27:
                if (winNumber.IndexOf(" + ") > 0)
                {
                    winNumber = winNumber.Replace(" + ", " ");
                    string[] strArray2 = winNumber.Split(new char[] { ' ' });
                    for (int i = 0; i < strArray2.Length; i++)
                    {
                        if (i < (strArray2.Length - 2))
                        {
                            builder.Append("<td width=\"25\" height='25' align=\"center\" background=\"Home/Room/images/cyw_redball.gif\" class=\"bai12_2\">").Append(strArray2[i]).AppendLine("</td>");
                        }
                        else
                        {
                            builder.Append("<td width=\"25\" height='25' align=\"center\" background=\"Home/Room/images/cyw_blueball.gif\" class=\"bai12_2\">").Append(strArray2[i]).AppendLine("</td>");
                        }
                    }
                }
                break;

            case 0x3e:
                if (winNumber.Length > 0)
                {
                    string[] strArray3 = winNumber.Split(new char[] { ' ' });
                    for (int j = 0; j < strArray3.Length; j++)
                    {
                        builder.Append("<td width=\"25\" height='25' align=\"center\" background=\"Home/Room/images/cyw_redball.gif\" class=\"bai12_2\">").Append(strArray3[j]).AppendLine("</td>");
                    }
                }
                break;

            case 5:
                if (winNumber.IndexOf(" + ") > 0)
                {
                    winNumber = winNumber.Replace(" + ", " ");
                    string[] strArray = winNumber.Split(new char[] { ' ' });
                    for (int k = 0; k < strArray.Length; k++)
                    {
                        if (k < (strArray.Length - 1))
                        {
                            builder.Append("<td width=\"25\" height='25' align=\"center\" background=\"Home/Room/images/cyw_redball.gif\" class=\"bai12_2\">").Append(strArray[k]).AppendLine("</td>");
                        }
                        else
                        {
                            builder.Append("<td width=\"25\" height='25' align=\"center\" background=\"Home/Room/images/cyw_blueball.gif\" class=\"bai12_2\">").Append(strArray[k]).AppendLine("</td>");
                        }
                    }
                }
                break;

            case 6:
                if (winNumber.Length > 0)
                {
                    for (int m = 0; m < winNumber.Length; m++)
                    {
                        builder.Append("<td width=\"25\" height='25' align=\"center\" background=\"Home/Room/images/cyw_redball.gif\" class=\"bai12_2\">").Append(winNumber.Substring(m, 1)).AppendLine("</td>");
                    }
                }
                break;

            case 0x1d:
                if (winNumber.Length > 0)
                {
                    for (int n = 0; n < winNumber.Length; n++)
                    {
                        builder.Append("<td width=\"25\" height='25' align=\"center\" background=\"Home/Room/images/cyw_redball.gif\" class=\"bai12_2\">").Append(winNumber.Substring(n, 1)).AppendLine("</td>");
                    }
                }
                break;
        }
        builder.Append("</tr></table></td>");
        return builder.ToString();
    }

    private DataTable GetFocusNews()
    {
        string key = "Default_GetFocusNews";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_FocusNews().Open("", "", "");
            if (cacheAsDataTable == null)
            {
                return null;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
        }
        return cacheAsDataTable;
    }

    private string GetFriendLinks()
    {
        StringBuilder builder = new StringBuilder();
        string key = "T_FriendshipLinks_Default";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = MSSQL.Select("select LinkName,Url from T_FriendshipLinks where isShow = 1 and SiteID = @SiteID order by [Order] asc ", new MSSQL.Parameter[] { new MSSQL.Parameter("SiteID", SqlDbType.Int, 0, ParameterDirection.Input, base._Site.ID) });
        }
        try
        {
            int count = cacheAsDataTable.Rows.Count;
            if (count > 0)
            {
                Shove._Web.Cache.SetCache(key, cacheAsDataTable);
                int num2 = 1;
                foreach (DataRow row in cacheAsDataTable.Rows)
                {
                    if (num2 < count)
                    {
                        builder.Append("<nobr><a href='" + row["Url"].ToString() + "' target='_blank'>" + row["LinkName"].ToString() + "</a></nobr>&nbsp;&nbsp;|&nbsp;&nbsp;");
                    }
                    else
                    {
                        builder.Append("<nobr><a href='" + row["Url"].ToString() + "' target='_blank'>" + row["LinkName"].ToString() + "</a></nobr>&nbsp;&nbsp;");
                    }
                    num2++;
                }
            }
        }
        catch
        {
            new Log("System").Write("首页读取友情链接数据出错");
        }
        return builder.ToString();
    }

    private string GetIsuseInfo(int LotteryID)
    {
        try
        {
            DataRow[] rowArray = DataCache.GetIsusesInfo(LotteryID).Select("EndTime < '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' and WinLotteryNumber<>''", "EndTime desc");
            if (rowArray.Length == 0)
            {
                return "";
            }
            string str3 = rowArray[0]["Name"].ToString();
            string winNumber = rowArray[0]["WinLotteryNumber"].ToString().Trim();
            winNumber = this.FormatWinNumber(LotteryID, winNumber);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<table width=\"98%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"").AppendLine("<tr>").Append("<td width=\"32%\" algin='left' class=\"hui12\" style=\"font-weight:bold\">").Append(str3).Append("期开奖：").AppendLine("</td>").Append(winNumber).AppendLine("</tr>").AppendLine("</table>");
            return builder.ToString();
        }
        catch (Exception exception)
        {
            new Log("System").Write(base.GetType() + exception.Message);
            return "";
        }
    }

    private DataTable GetNews()
    {
        string key = "Default_GetNews";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
        {
            string commandText = "select * from\r\n                                (select top 11 ID,Title,Content,TypeName from V_News where isShow = 1  and [TypeName] = '福彩资讯'\r\n                                order by isCommend,ID desc)a\r\n                            union\r\n                            select * from\r\n                                (select top 11 ID,Title,Content,TypeName from V_News where isShow = 1  and [TypeName] = '体彩资讯'\r\n                                order by isCommend,ID desc)b\r\n                            union\r\n                            select * from\r\n                                (select top 11 ID,Title,Content,TypeName from V_News where isShow = 1  and [TypeName] = '足彩资讯'\r\n                                order by isCommend,ID desc)c";
            cacheAsDataTable = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                return null;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
        }
        return cacheAsDataTable;
    }

    private DataTable GetSiteAffiches()
    {
        string key = "Default_GetSiteAffiches";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_SiteAffiches().Open("top 10 Title,Content", "isShow = 1", " DateTime desc");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return null;
            }
            if (cacheAsDataTable.Rows.Count > 0)
            {
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
            }
        }
        return cacheAsDataTable;
    }

    private DataTable GetUserListByWinMoney()
    {
        string key = "Default_GetUserListByWinMoney";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            string commandText = "select InitiateUserID,b.Name as InitiateName, Win, 62 as LotteryID from\r\n                                (select top 9 InitiateUserID, sum(WinMoney) as Win from T_Schemes WITH (nolock) where WinMoney > 0 group by\r\n                                 InitiateUserID order by Win desc)a inner join T_Users b on a.InitiateUserID = b.ID order by Win desc";
            cacheAsDataTable = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return null;
            }
            if (cacheAsDataTable.Rows.Count > 0)
            {
                Shove._Web.Cache.SetCache("WinList", cacheAsDataTable, 600);
            }
        }
        return cacheAsDataTable;
    }

    private string GetWinNoticeByLotteryID(int LotteryID)
    {
        string key = "Default_GetWinNoticeByLotteryID" + LotteryID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        StringBuilder builder = new StringBuilder();
        if (cacheAsDataTable == null)
        {
            builder.AppendLine("select a.ID,WinMoney,b.Name as LotteryName,PlayTypeName,c.Name as InitiateName from").AppendLine("(").AppendLine("select top 30 a.ID,InitiateUserID,PlayTypeID,WinMoney,Name as PlayTypeName,LotteryID from T_Schemes a").AppendLine("inner join T_PlayTypes b on a.PlayTypeID = b.ID where WinMoney > 0 and LotteryID = " + LotteryID.ToString() + " ");
            if (LotteryID == 5)
            {
                builder.AppendLine("and WinMoney > 99");
            }
            builder.AppendLine("order by a.ID desc)a").AppendLine("inner join T_Lotteries b on a.LotteryID = b.ID").AppendLine("inner join T_Users c on a.InitiateUserID = c.ID");
            cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据读写错错误", base.GetType().BaseType.FullName);
                return "";
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x708);
        }
        builder = new StringBuilder();
        builder.AppendLine("<table width=\"79%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
        for (int i = 0; (i < cacheAsDataTable.Rows.Count) && (i < 4); i++)
        {
            builder.AppendLine("<tr><td height=\"18\" class=\"blue12_3\" style=\"padding-left: 10px;overflow:hidden\">").AppendLine("<nobr><a href='Home/Room/Scheme.aspx?id=" + cacheAsDataTable.Rows[i]["ID"].ToString() + "' target='_blank'>" + _String.Cut(cacheAsDataTable.Rows[i]["InitiateName"].ToString(), 4) + "喜中" + cacheAsDataTable.Rows[i]["PlayTypeName"].ToString() + _String.Cut(_Convert.StrToDouble(cacheAsDataTable.Rows[i]["WinMoney"].ToString(), 0.0).ToString("N0"), 4) + "元</a>").AppendLine("</nobr></td></tr>");
        }
        builder.AppendLine("</table>");
        return builder.ToString();
    }

    protected void imgbtnLogout_Click(object sender, EventArgs e)
    {
        string returnDescription = "";
        if ((base._User != null) && (base._User.Logout(ref returnDescription) < 0))
        {
            PF.GoError(1, returnDescription, base.GetType().FullName);
        }
        else
        {
            string str2 = base.ResolveUrl("~/");
            base.Response.Write("<script language=\"javascript\">try{window.location.href = '" + str2 + "';document.getElementById('HidUserID').value='-1';}catch(e){window.location.href = '" + str2 + "';}</script>");
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsolutePath;
        base.isRequestLogin = false;
        base.isAtFramePageLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Default), this.Page);
        if (!base.IsPostBack)
        {
            if (_Convert.StrToInt(base.Request.QueryString["Logout"], -1) != -1)
            {
                this.imgbtnLogout_Click(this.Page, new EventArgs());
            }
            if (base._User != null)
            {
                object cache = Shove._Web.Cache.GetCache("UserLoginScript_" + base._User.ID.ToString());
                if (cache != null)
                {
                    this.script = cache.ToString();
                }
                Shove._Web.Cache.ClearCache("UserLoginScript_" + base._User.ID.ToString());
                this.hUserID.Value = base._User.ID.ToString();
            }
            bool flag = base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
            this.CheckCode.Visible = flag;
            new Login().SetCheckCode(base._Site, this.ShoveCheckCode1);
        }
        this.BindData();
    }
}

