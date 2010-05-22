using ASP;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_BindAlipay : RoomPageBase, IRequiresSessionState
{

    private void BindData()
    {
        this.Label1.Text = base._User.Name;
        this.labName.Text = base._User.Name;
        if (base._User.isAlipayNameValided)
        {
            this.labAlipayAccountOld.Text = this.GetAlipayNam();
            this.lbStatus.Text = "您已经绑定";
        }
        else
        {
            this.labBindState.Text = "(未绑定)";
            this.lbStatus.Text = "您一旦绑定";
        }
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

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            if (base._User.RealityName == "")
            {
                base.Response.Write("<script type='text/javascript'>alert('请完善您的基本资料，真实姓名不能为空，谢谢！');window.location='UserEdit.aspx?FromUrl=BindAlipay.aspx';</script>");
            }
            if (this.lbQuestion.Text == "")
            {
                base.Response.Write("<script type='text/javascript'>alert('为了您的账户安全，请先设置安全保护问题，谢谢！');window.location='SafeSet.aspx?FromUrl=BindAlipay.aspx';</script>");
            }
            if (this.tbRealityName.Text != base._User.RealityName)
            {
                JavaScript.Alert(this.Page, "请核实您的真实姓名，谢谢！");
            }
            else if (this.tbMyA.Text.Trim() != base._User.SecurityAnswer)
            {
                JavaScript.Alert(this.Page, "安全保护问题回答错误。");
            }
            else
            {
                Shove._Web.Cache.SetCache("BindAlipay_" + base._User.ID, base._User.ID.ToString());
                base.Response.Redirect("Login.aspx");
            }
        }
    }

    private string GetAlipayNam()
    {
        string str2 = "**********************";
        int index = base._User.AlipayName.IndexOf("@");
        int num3 = base._User.AlipayName.Length - index;
        try
        {
            if (base._User.AlipayName.IndexOf("@") == -1)
            {
                return (base._User.AlipayName.Substring(0, 3) + "********");
            }
            return (str2.Substring(0, index - 1) + base._User.AlipayName.Substring(base._User.AlipayName.IndexOf("@") - 1, num3 + 1));
        }
        catch
        {
            return "";
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
        }
    }

    private void Reward(long UserID, string AlipayName)
    {
        int agentID = 0x3f8;
        if ((UserID >= 1L) && (AlipayName != ""))
        {
            DataTable table = MSSQL.Select("select * from T_ActivitiesMytv365 where Convert(varchar(10), DateTime, 120) = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'", new MSSQL.Parameter[0]);
            if (table != null)
            {
                DataRow[] rowArray = table.Select("AlipayName = '" + AlipayName + "'");
                int num2 = 0;
                if ((rowArray.Length == 0) && (table.Rows.Count < 12))
                {
                    string returnDescription = "";
                    CardPassword password = new CardPassword();
                    long cardPasswordID = password.Add(agentID, 1, 2.0, 1, ref returnDescription);
                    if (cardPasswordID < 0L)
                    {
                        new Log("System").Write("添加卡密失败。" + returnDescription + base.GetType().FullName + "(150)");
                    }
                    else if (password.Use(password.GenNumber(PF.GetCallCert(), agentID, cardPasswordID), 1L, UserID, ref returnDescription) < 0)
                    {
                        new Log("System").Write("卡密使用失败。" + returnDescription + base.GetType().FullName + "(159)");
                    }
                    else
                    {
                        num2 = 1;
                        if (MSSQL.ExecuteNonQuery("insert into T_ActivitiesMytv365 (IsReward1,UserID,AlipayName)values(" + num2.ToString() + "," + UserID.ToString() + ",'" + AlipayName + "')", new MSSQL.Parameter[0]) < 0)
                        {
                            new Log("System").Write("写入 T_ActivitiesMytv365 失败。" + base.GetType().FullName + "(178)");
                        }
                    }
                }
            }
        }
    }
}

