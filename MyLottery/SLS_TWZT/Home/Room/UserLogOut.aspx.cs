using ASP;
using Shove._Web;
using Shove.Database;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_UserLogOut : RoomPageBase, IRequiresSessionState
{
    public string Balance;
    public string UserName;

    protected void btnDownLoad_Click(object sender, EventArgs e)
    {
        string key = "Home_Room_Invest_BindHistoryData" + base._User.ID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select * from (select LotteryID,LotteryName,PlayTypeID,InitiateName,PlayTypeName, ").Append("SchemeShare,a.Money,b.Share,b.DetailMoney,SchemeWinMoney, b.WinMoneyNoWithTax,a.DateTime, ").Append("b.SchemeID,QuashStatus,Buyed,AssureMoney,BuyedShare,IsOpened,c.Memo  from   ").Append("(select UserID,SchemeID,SUM(Share) as Share,SUM(DetailMoney) as DetailMoney, ").Append("sum(WinMoneyNoWithTax) as  WinMoneyNoWithTax  from V_BuyDetailsWithQuashedAll   ").Append("where  UserID = " + base._User.ID.ToString() + " and InitiateUserID = UserID group by SchemeID,UserID)b ").Append("left join (select * from V_BuyDetailsWithQuashedAll where UserID = " + base._User.ID.ToString() + " and   ").Append("UserID = InitiateUserID and isWhenInitiate = 1)a ").Append("on a.UserID = b.UserID and ").Append("a.SchemeID = b.SchemeID  left join (select SchemeID,Memo from T_UserDetails where ").Append("OperatorType = 9 and UserID = " + base._User.ID.ToString() + ") c  ").Append("on b.SchemeID = c.SchemeID union select  LotteryID,LotteryName,PlayTypeID,InitiateName, ").Append("PlayTypeName,SchemeShare,a.Money,Share,DetailMoney,SchemeWinMoney, WinMoneyNoWithTax, ").Append("a.DateTime,a.SchemeID,QuashStatus,Buyed,AssureMoney,BuyedShare,IsOpened,b.Memo from  ").Append("(select * from V_BuyDetailsWithQuashedAll where UserID = " + base._User.ID.ToString() + " and UserID<>InitiateUserID) a left join (select SchemeID,Memo from T_UserDetails where  ").Append("OperatorType = 9 and UserID = " + base._User.ID.ToString() + ")b on a.SchemeID = b.SchemeID)a order by DateTime desc");
            cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
        }
        string str2 = "T_Invert.xls";
        HttpResponse response = this.Page.Response;
        response.AppendHeader("Content-Disposition", "attachment;filename=" + str2);
        base.Response.ContentType = "application/ms-excel";
        response.ContentEncoding = Encoding.GetEncoding("gb2312");
        foreach (DataColumn column in cacheAsDataTable.Columns)
        {
            response.Write(column.ColumnName + "\t");
        }
        response.Write("\n");
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            for (int i = 0; i < cacheAsDataTable.Columns.Count; i++)
            {
                response.Write(row[i].ToString() + "\t");
            }
            response.Write("\n");
        }
        response.End();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        string text = this.tbReason.Text;
        string returnDescription = "";
        if (string.IsNullOrEmpty(text))
        {
            JavaScript.Alert(this.Page, "请输入注销原因！");
        }
        else
        {
            string str3 = this.tbPassWord.Text.Trim();
            if (string.IsNullOrEmpty(str3))
            {
                JavaScript.Alert(this.Page, "请输入密码！");
            }
            else if (base._User != null)
            {
                if (this.lbQuestion.Text == "")
                {
                    base.Response.Write("<script type='text/javascript'>alert('为了您的账户安全，请先设置安全保护问题，谢谢！');window.location='SafeSet.aspx?FromUrl=UserLogOut.aspx';</script>");
                }
                else if (PF.EncryptPassword(str3) != base._User.Password)
                {
                    JavaScript.Alert(this.Page, "请核实您的密码，谢谢！");
                }
                else if (this.tbMyA.Text.Trim() != base._User.SecurityAnswer)
                {
                    JavaScript.Alert(this.Page, "安全保护问题回答错误。");
                }
                else
                {
                    base._User.Reason = text;
                    base._User.isCanLogin = false;
                    if (base._User.EditByID(ref returnDescription) < 0)
                    {
                        JavaScript.Alert(this.Page, returnDescription);
                    }
                    else if ((base._User != null) && (base._User.Logout(ref returnDescription) < 0))
                    {
                        PF.GoError(1, returnDescription, base.GetType().FullName);
                    }
                    else
                    {
                        string str4 = base.ResolveUrl("~/");
                        base.Response.Write("<script language=\"javascript\">try{window.location.href = '" + str4 + "';document.getElementById('HidUserID').value='-1';}catch(e){window.location.href = '" + str4 + "';}</script>");
                    }
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            this.Balance = base._User.Balance.ToString();
            this.UserName = base._User.Name.ToString();
            if (base._User.SecurityQuestion.StartsWith("自定义问题|"))
            {
                this.lbQuestion.Text = base._User.SecurityQuestion.Remove(0, 6);
            }
            else
            {
                this.lbQuestion.Text = base._User.SecurityQuestion;
            }
            if (this.lbQuestion.Text == "")
            {
                this.lbQuestionInfo.Text = "设置安全保护问题";
            }
            else
            {
                this.lbQuestionInfo.Text = "修改安全保护问题";
            }
        }
    }
}

