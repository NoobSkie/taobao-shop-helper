using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Threading;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_PromoteCpsReg : SitePageBase, IRequiresSessionState
{
    private string KeyPromotionUserID = "SLS.TWZT.PromotionUserID";

    private void BindAffiches()
    {
        this.BindWinUsers();
        string key = "Home_Room_PromoteUserReg_BindAffiches";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            string commandText = "select top 7 * from V_News where isShow=1 and SiteID=1 and [TypeName]='中奖公告'  order by datetime desc";
            cacheAsDataTable = MSSQL.Select(commandText, new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable);
        }
        this.rptWinAffiches.DataSource = cacheAsDataTable;
        this.rptWinAffiches.DataBind();
    }

    private void BindWinUsers()
    {
        string key = "Home_Room_PromoteUserReg_BindWinUsers";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        StringBuilder builder = new StringBuilder();
        if (cacheAsDataTable == null)
        {
            builder.AppendLine("select b.Name as UserName,c.Name as PlayName,WinMoneyNoWithTax from").AppendLine("(select top 27 InitiateUserID,PlayTypeID,WinMoneyNoWithTax from T_Schemes a inner join").AppendLine("T_Isuses b on a.IsuseID = b.ID  and  WinMoneyNoWithTax > 0 and  LotteryID = 62  order by DateTime desc)a").AppendLine("inner join T_Users b on a.InitiateUserID = b.ID inner join T_PlayTypes c on a.PlayTypeID = c.ID");
            cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 300);
        }
        builder = new StringBuilder();
        builder.AppendLine("<div id='scrollWinUsers' style='overflow: hidden; height:100px';>").AppendLine("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            builder.AppendLine("<tr><td width='33%'class='black12'align='center' style='padding-bottom:5px'>").AppendLine(_String.Cut(row["UserName"].ToString(), 4)).AppendLine("</td>").AppendLine("<td width='33%' class='black12' align='center'>").AppendLine(_String.Cut(row["PlayName"].ToString(), 4)).AppendLine("</td>").AppendLine("<td width='33%' class='red12' align='center'>").AppendLine(_Convert.StrToDouble(row["WinMoneyNoWithTax"].ToString(), 0.0).ToString("N")).Append("元").Append("</td></tr>");
        }
        builder.AppendLine("</table>").AppendLine("</div>");
        this.divWinUsers.InnerHtml = builder.ToString();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string returnDescription = "";
        if (new Login().LoginSubmit(this.Page, base._Site, this.tbFormUserName.Text, this.tbFormUserPassword.Text, this.tbFormCheckCode.Text, this.ShoveCheckCode1, ref returnDescription) < 0)
        {
            JavaScript.Alert(this.Page, returnDescription);
        }
        else
        {
            base.Response.Redirect("../../Default.aspx");
        }
    }

    protected void btnReg_Click(object sender, EventArgs e)
    {
        string str = "";
        if (!PF.CheckUserName(this.tbUserName.Text))
        {
            str = str + "对不起用户名中含有禁止使用的字符.\r\n";
        }
        if ((_String.GetLength(this.tbUserName.Text) < 5) || (_String.GetLength(this.tbUserName.Text) > 0x10))
        {
            str = str + "用户名长度在 5-16 个英文字符或数字、中文 3-8 之间.\r\n";
        }
        if ((this.tbPassword.Text.Length < 6) || (this.tbPassword.Text.Length > 0x10))
        {
            str = str + "密码长度必须在 6-16 位之间.\r\n";
        }
        if (this.tbSiteName.Text.Trim().Length == 0)
        {
            str = str + "网站名称不能为空.\r\n";
        }
        if (this.tbSiteURL.Text.Trim().Length == 0)
        {
            str = str + "网站地址不能为空.\r\n";
        }
        if (!_String.Valid.isEmail(this.tbEmail.Text))
        {
            str = str + "电子邮件地址格式不正确.\r\n";
        }
        if (!this.ckbAgree.Checked)
        {
            str = str + "必须同意本站会员注册协议才能注册会员。\r\n";
        }
        if (this.CheckCode2.Visible)
        {
            if (this.tbCheckCode.Text.Trim() == "")
            {
                str = str + "请输入验证码！\n";
            }
            else if (!this.ShoveCheckCode1.Valid(this.tbCheckCode.Text.Trim()))
            {
                str = str + "验证码输入有误！\n";
            }
        }
        if (str != "")
        {
            this.lblInputError.Visible = true;
            this.lblInputError.Text = "输入资料错误:\r\n" + str;
        }
        else
        {
            long num = -1L;
            long num2 = -1L;
            if (this.Session[this.KeyPromotionUserID] != null)
            {
                num2 = _Convert.StrToLong(this.Session[this.KeyPromotionUserID].ToString(), -1L);
            }
            object obj2 = MSSQL.ExecuteScalar("select ID from T_Cps where OwnerUserID=" + num2, new MSSQL.Parameter[0]);
            if (obj2 != null)
            {
                num = _Convert.StrToLong(obj2.ToString(), -1L);
            }
            Thread.Sleep(500);
            string str2 = this.tbUserName.Text.Trim();
            string str3 = this.tbPassword.Text.Trim();
            string str4 = this.tbEmail.Text.Trim();
            string str5 = this.tbTel.Text.Trim();
            string str6 = this.tbQQ.Text.Trim();
            Users users = new Users(base._Site.ID)
            {
                Name = str2,
                Password = str3,
                Email = str4,
                Mobile = str5,
                QQ = str6,
                UserType = 2
            };
            if (num > 0L)
            {
                users.CommenderID = -1L;
                users.CpsID = num;
            }
            else
            {
                users.CommenderID = num2;
                users.CpsID = -1L;
            }
            string returnDescription = "";
            if (users.Add(ref returnDescription) < 0)
            {
                JavaScript.Alert(this, returnDescription);
            }
            else
            {
                double num4 = 0.0;
                DataTable table = new Tables.T_Sites().Open("Opt_CpsBonusScale", "", "");
                if ((table != null) && (table.Rows.Count > 0))
                {
                    num4 = double.Parse(table.Rows[0]["Opt_CpsBonusScale"].ToString());
                }
                users.cps.SiteID = 1L;
                users.cps.CommendID = num2;
                users.cps.Name = this.tbSiteName.Text;
                users.cps.Url = this.tbSiteURL.Text;
                users.cps.BonusScale = num4;
                users.cps.ON = true;
                users.cps.Telephone = this.tbTel.Text.Trim();
                users.cps.Email = str4;
                users.cps.QQ = str6;
                users.cps.Type = 2;
                users.cps.DomainName = users.GetPromotionURL(0);
                if (users.cps.Add(ref returnDescription) < 0)
                {
                    JavaScript.Alert(this, returnDescription);
                }
                else if (users.Login(ref returnDescription) < 0)
                {
                    JavaScript.Alert(this, returnDescription);
                }
                else
                {
                    base.Response.Redirect("../../Default.aspx");
                }
            }
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string CheckReg(string name, string password, string email)
    {
        name = name.Trim();
        password = password.Trim();
        email = email.Trim();
        if (!PF.CheckUserName(name))
        {
            return "对不起用户名中含有禁止使用的字符";
        }
        if ((_String.GetLength(name) < 5) || (_String.GetLength(name) > 0x10))
        {
            return "用户名长度在 5-16 个英文字符或数字、中文 3-8 之间。";
        }
        if ((password.Length < 6) || (password.Length > 0x10))
        {
            return "密码长度必须在 6-16 位之间。";
        }
        if (!_String.Valid.isEmail(email))
        {
            return "电子邮件地址格式不正确。";
        }
        return "";
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public int CheckUserName(string name)
    {
        if (!PF.CheckUserName(name))
        {
            return -1;
        }
        DataTable table = new Tables.T_Users().Open("ID", "Name = '" + Shove._Web.Utility.FilteSqlInfusion(name) + "'", "");
        if ((table != null) && (table.Rows.Count > 0))
        {
            return -2;
        }
        if ((_String.GetLength(name) >= 5) && (_String.GetLength(name) <= 0x10))
        {
            return 0;
        }
        return -3;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_PromoteCpsReg), this.Page);
        if (!base.IsPostBack)
        {
            bool flag = base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
            this.CheckCode1.Visible = flag;
            this.CheckCode2.Visible = flag;
            new Login().SetCheckCode(base._Site, this.ShoveCheckCode1);
            new Login().SetCheckCode(base._Site, this.ShoveCheckCode2);
            if (base._User != null)
            {
                base.Response.Redirect("../../Default.aspx");
            }
            this.BindAffiches();
            this.SetCommenderName("");
            this.pnlShowPromotionInfo.Visible = false;
            this.pnlShowErrorInfo.Visible = false;
            this.lblInputError.Visible = false;
            this.lblInputError.Text = "";
            long num = -1L;
            string request = Shove._Web.Utility.GetRequest("id");
            if (string.IsNullOrEmpty(request) || (request.Length != 11))
            {
                this.pnlShowErrorInfo.Visible = true;
                this.lblShowErrorInfo.Text = "无效的推荐人ID.用户可以正常注册站长商家!";
            }
            else
            {
                num = _Convert.StrToLong(request.Substring(0, 10), -1L);
                object obj2 = MSSQL.ExecuteScalar("select name from T_Users where ID=" + num, new MSSQL.Parameter[0]);
                if ((obj2 == null) || (obj2.ToString() == ""))
                {
                    this.pnlShowErrorInfo.Visible = true;
                    this.lblShowErrorInfo.Text = "不存在推荐人ID.用户可以正常注册站长商家!";
                }
                else
                {
                    this.pnlShowPromotionInfo.Visible = true;
                    this.SetCommenderName(obj2.ToString());
                }
            }
            if (num > 0L)
            {
                this.Session[this.KeyPromotionUserID] = num.ToString();
            }
        }
    }

    protected void rptWinAffiches_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            if (e.Item.DataItem == null)
            {
                base.Response.Write("e.Item.DataItem == null");
            }
            else
            {
                DataRowView dataItem = (DataRowView)e.Item.DataItem;
                HyperLink link = e.Item.FindControl("hlWinAffichesTitle") as HyperLink;
                string input = dataItem["Title"].ToString();
                link.Text = _String.HtmlTextCut(input, 10);
                link.NavigateUrl = dataItem["Content"].ToString();
            }
        }
    }

    private void SetCommenderName(string name)
    {
        this.lblCommenderName1.Text = name;
        this.lblCommenderName2.Text = name;
    }
}

