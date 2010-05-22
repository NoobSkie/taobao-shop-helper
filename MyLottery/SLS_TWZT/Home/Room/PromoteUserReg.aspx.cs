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

public partial class Home_Room_PromoteUserReg : SitePageBase, IRequiresSessionState
{
    private string KeyHongbaoPromotionID = "SLS.TWZT.HongbaoPromotionID";
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
        this.lblInputError.Visible = false;
        this.lblInputError.Text = "";
        string str = "";
        if (!PF.CheckUserName(this.tbUserName.Text))
        {
            str = str + "对不起用户名中含有禁止使用的字符\n";
        }
        if ((_String.GetLength(this.tbUserName.Text) < 5) || (_String.GetLength(this.tbUserName.Text) > 0x10))
        {
            str = str + "用户名长度在 5-16 个英文字符或数字、中文 3-8 之间。\n";
        }
        if ((this.tbPassword.Text.Length < 6) || (this.tbPassword.Text.Length > 0x10))
        {
            str = str + "密码长度必须在 6-16 位之间。\n";
        }
        if (string.IsNullOrEmpty(this.tbRealyName.Text))
        {
            str = str + "真实姓名不能为空。\n";
        }
        if (!_String.Valid.isEmail(this.tbEmail.Text))
        {
            str = str + "电子邮件地址格式不正确。\n";
        }
        if (!this.ckbAgree.Checked)
        {
            str = str + "必须同意本站会员注册协议才能注册会员。\n";
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
            long fromUserID = -1L;
            long userHongbaoPromotionID = -1L;
            if (this.Session[this.KeyPromotionUserID] != null)
            {
                fromUserID = _Convert.StrToLong(this.Session[this.KeyPromotionUserID].ToString(), -1L);
            }
            if (this.Session[this.KeyHongbaoPromotionID] != null)
            {
                userHongbaoPromotionID = _Convert.StrToLong(this.Session[this.KeyHongbaoPromotionID].ToString(), -1L);
            }
            object obj2 = MSSQL.ExecuteScalar("select ID from T_Cps where OwnerUserID=" + fromUserID, new MSSQL.Parameter[0]);
            if (obj2 != null)
            {
                num = _Convert.StrToLong(obj2.ToString(), -1L);
            }
            Thread.Sleep(500);
            string str2 = this.tbUserName.Text.Trim();
            string str3 = this.tbPassword.Text.Trim();
            string str4 = this.tbEmail.Text.Trim();
            string str5 = this.tbRealyName.Text.Trim();
            string str6 = this.tbQQ.Text.Trim();
            Users users = new Users(base._Site.ID)
            {
                Name = str2,
                Password = str3,
                Email = str4,
                RealityName = str5,
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
                users.CommenderID = fromUserID;
                users.CpsID = -1L;
            }
            string returnDescription = "";
            if (users.Add(ref returnDescription) < 0)
            {
                JavaScript.Alert(this, returnDescription);
            }
            else
            {
                string str8 = "<span style='font-size: 14px; color: #CC3300; font-weight: bold;'>注册成功,恭喜您成为" + base._Site.Name + "的高级会员!让我们一起共同搏击1000万大奖!</span><br/>";
                if (userHongbaoPromotionID > 0L)
                {
                    DataTable table = MSSQL.Select(string.Concat(new object[] { "select * from T_UserHongbaoPromotion where ID=", userHongbaoPromotionID, " and UserID=", fromUserID }), new MSSQL.Parameter[0]);
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        double num5 = 0.0;
                        num5 = _Convert.StrToDouble(table.Rows[0]["Money"].ToString(), 0.0);
                        int returnValue = -1;
                        Procedures.P_AcceptUserHongbaoPromotion(fromUserID, users.ID, userHongbaoPromotionID, ref returnValue, ref returnDescription);
                        if (returnValue != 0)
                        {
                            str8 = "<span style='font-size: 14px; color: #CC3300; font-weight: bold;'>注册成功,恭喜您成为" + base._Site.Name + "的高级会员!</span><br/>由以下原因未能获得推荐者的彩票红包：" + returnDescription + "<br/>";
                        }
                        else
                        {
                            str8 = "<span style='font-size: 14px; color: #CC3300; font-weight: bold;'>注册成功,恭喜您成为" + base._Site.Name + "的高级会员,并获得" + num5.ToString() + "元彩票红包!" + num5.ToString() + "元已注入您的" + base._Site.Name + "现金帐户,您可以到我们的购彩页面购买彩票啦,祝君好运!</span><br/>";
                        }
                    }
                }
                if (users.Login(ref returnDescription) < 0)
                {
                    JavaScript.Alert(this, returnDescription);
                }
                else
                {
                    this.MultiView1.ActiveViewIndex = 1;
                    this.divRegResultInfo.InnerHtml = str8;
                }
            }
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string CheckReg(string name, string password, string realyName, string email)
    {
        name = name.Trim();
        password = password.Trim();
        realyName = realyName.Trim();
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
        if (string.IsNullOrEmpty(realyName))
        {
            return "真实姓名不能为空.";
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_PromoteUserReg), this.Page);
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
            this.pnlShowInfoWithHongbao.Visible = false;
            this.pnlShowInfoWithoutHongbao.Visible = false;
            this.pnlShowInfoPromotion.Visible = false;
            this.lblInputError.Visible = false;
            this.lblInputError.Text = "";
            this.SetCommenderName("");
            this.SetCommenderGifMoney("0");
            long num = -1L;
            long num2 = -1L;
            string request = Shove._Web.Utility.GetRequest("id");
            if (string.IsNullOrEmpty(Shove._Web.Utility.GetRequest("Sign")) && !string.IsNullOrEmpty(request))
            {
                if (request.Length != 11)
                {
                    this.pnlShowInfoPromotion.Visible = true;
                    this.lblShowInfoPromotion.Text = "无效的推荐人ID.用户可以正常注册会员!";
                }
                else
                {
                    this.pnlShowInfoWithoutHongbao.Visible = true;
                    this.lblAgreeTip.Visible = false;
                    num = _Convert.StrToLong(request.Substring(0, 10), -1L);
                    object obj2 = MSSQL.ExecuteScalar("select name from T_Users where ID=" + num, new MSSQL.Parameter[0]);
                    if ((obj2 == null) || (obj2.ToString() == ""))
                    {
                        this.pnlShowInfoPromotion.Visible = true;
                        this.lblShowInfoPromotion.Text = "不存在推荐人的ID.用户可以正常注册会员!";
                    }
                    else
                    {
                        this.SetCommenderName(obj2.ToString());
                    }
                }
            }
            else if (new SynchronizeSessionID(this).ValidSign(base.Request))
            {
                num = _Convert.StrToLong(Shove._Web.Utility.GetRequest("UserID"), -1L);
                num2 = _Convert.StrToLong(Shove._Web.Utility.GetRequest("id"), -1L);
                DataTable table = MSSQL.Select(string.Concat(new object[] { "select * from T_UserHongbaoPromotion where ID=", num2, " and UserID=", num }), new MSSQL.Parameter[0]);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    string str3 = "";
                    long num3 = -1L;
                    double num4 = 0.0;
                    double num5 = 0.0;
                    str3 = MSSQL.ExecuteScalar("select name from T_Users where ID=" + num, new MSSQL.Parameter[0]).ToString();
                    num3 = _Convert.StrToLong(table.Rows[0]["AcceptUserID"].ToString(), -1L);
                    DateTime time = (table.Rows[0]["ExpiryDate"] == null) ? DateTime.MinValue : Convert.ToDateTime(table.Rows[0]["ExpiryDate"]);
                    num4 = _Convert.StrToDouble(table.Rows[0]["Money"].ToString(), 0.0);
                    num5 = _Convert.StrToDouble(MSSQL.ExecuteScalar("select Balance from T_Users where ID=" + num.ToString(), new MSSQL.Parameter[0]).ToString(), 0.0);
                    if (num3 > 0L)
                    {
                        this.pnlShowInfoPromotion.Visible = true;
                        this.lblShowInfoPromotion.Text = "欢迎您通过你的好友 " + str3 + " 的推荐来到" + base._Site.Name + "上购彩中心，此推荐链接送出的红包已经被他人领取。您可以继续注册用户，但不会获得推荐人送出的彩票红包。但我们热情期待您加入,共同博击1000万的大奖!";
                        this.lblAgreeTip.Visible = false;
                    }
                    else if (time < DateTime.Now)
                    {
                        this.pnlShowInfoPromotion.Visible = true;
                        this.lblShowInfoPromotion.Text = "欢迎您通过你的好友 " + str3 + " 的推荐来到" + base._Site.Name + "上购彩中心，由于此推荐注册链接已经过期,继续注册不会获得推荐者送出的红包.但我们热情期待您加入,共同博击1000万的大奖!";
                        this.lblAgreeTip.Visible = false;
                    }
                    else if (num5 < num4)
                    {
                        this.pnlShowInfoPromotion.Visible = true;
                        this.lblShowInfoPromotion.Text = "欢迎您通过你的好友 " + str3 + " 的推荐来到" + base._Site.Name + "上购彩中心，由于推荐人余额不足,继续注册不会获得推荐者送出的红包.但我们热情期待您加入,共同博击1000万的大奖!";
                        this.lblAgreeTip.Visible = false;
                    }
                    else
                    {
                        this.pnlShowInfoWithHongbao.Visible = true;
                        this.SetCommenderName(MSSQL.ExecuteScalar("select name from T_Users where ID=" + num, new MSSQL.Parameter[0]).ToString());
                        this.SetCommenderGifMoney(num4.ToString());
                    }
                }
                else
                {
                    this.pnlShowInfoPromotion.Visible = true;
                    this.lblShowInfoPromotion.Text = "无效的推荐链接。我们热情期待您加入,共同博击1000万的大奖!";
                }
            }
            else
            {
                this.pnlShowInfoPromotion.Visible = true;
                this.lblShowInfoPromotion.Text = "红包推广推荐链接已被他人修改过。我们热情期待您加入,共同博击1000万的大奖!";
            }
            if (num > 0L)
            {
                this.Session[this.KeyPromotionUserID] = num.ToString();
                if (num2 > 0L)
                {
                    this.Session[this.KeyHongbaoPromotionID] = num2.ToString();
                }
                else
                {
                    this.Session[this.KeyHongbaoPromotionID] = null;
                }
            }
            else
            {
                this.pnlShowInfoPromotion.Visible = true;
                this.lblShowInfoPromotion.Text = "无效的推荐链接。继续注册，我们热情期待您加入,共同博击1000万的大奖!";
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

    private void SetCommenderGifMoney(string moneyValue)
    {
        this.lblGifMoney1.Text = moneyValue;
    }

    private void SetCommenderName(string name)
    {
        this.lblCommenderName1.Text = name;
        this.lblCommenderName2.Text = name;
        this.lblCommenderName3.Text = name;
    }
}

