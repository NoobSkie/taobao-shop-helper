using ASP;
using DAL;
using FreeTextBoxControls;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_QuestionAnswer : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        DataTable table = new Tables.T_Questions().Open("", "SiteID = " + base._Site.ID.ToString() + " and [ID] = " + Utility.FilteSqlInfusion(this.tbID.Text), "");
        if ((table == null) || (table.Rows.Count < 1))
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_QuestionAnswer");
        }
        else
        {
            this.tbDateTime.Text = table.Rows[0]["DateTime"].ToString();
            this.tbTelphone.Text = table.Rows[0]["Telephone"].ToString();
            this.labContent.Text = table.Rows[0]["Content"].ToString();
            if (_Convert.StrToShort(table.Rows[0]["AnswerStatus"].ToString(), 0) == 2)
            {
                this.tbAnswer.Text = table.Rows[0]["Answer"].ToString();
                this.btnAnswer.Enabled = false;
            }
        }
    }

    protected void btnAnswer_Click(object sender, EventArgs e)
    {
        if ((this.tbUserID.Text == "") || (this.tbID.Text == ""))
        {
            PF.GoError(1, "参数错误", "Admin_QuestionAnswer");
        }
        else if (this.tbAnswer.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入答复内容。");
        }
        else
        {
            int returnValue = -1;
            string returnDescription = "";
            if (Procedures.P_QuestionsAnswer(base._Site.ID, long.Parse(this.tbID.Text), this.tbAnswer.Text, base._User.ID, ref returnValue, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_QuestionAnswer");
            }
            else if (returnValue < 0)
            {
                JavaScript.Alert(this.Page, returnDescription);
            }
            else
            {
                PF.SendStationSMS(base._Site, base._User.ID, long.Parse(this.tbUserID.Text), 1, "您有问题已经被管理员答复，请到“我的问题列表”查看，谢谢。");
                JavaScript.Alert(this.Page, "回复成功！", "Questions.aspx");
            }
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "MemberService" });
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            long num = _Convert.StrToLong(Utility.GetRequest("id"), -1L);
            long num2 = _Convert.StrToLong(Utility.GetRequest("UserID"), -1L);
            if ((num < 0L) | (num2 < 0L))
            {
                PF.GoError(1, "参数错误", "Admin_QuestionAnswer");
            }
            else
            {
                this.tbID.Text = num.ToString();
                this.tbUserID.Text = num2.ToString();
                this.BindData();
            }
        }
    }
}

