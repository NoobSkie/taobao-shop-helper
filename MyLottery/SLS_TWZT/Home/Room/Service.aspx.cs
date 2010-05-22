using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_Service : RoomPageBase, IRequiresSessionState
{

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.tbContent.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入问题描述。");
        }
        else
        {
            long newQuestionID = 0L;
            string returnDescription = "";
            if (Procedures.P_QuestionsAdd(base._Site.ID, base._User.ID, short.Parse(this.ddlQuestionType.SelectedValue), this.tbUserTelphone.Text.Trim(), this.tbContent.Text.Trim(), ref newQuestionID, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Room_Service");
            }
            else if (newQuestionID < 0L)
            {
                PF.GoError(1, returnDescription, "Room_Service");
            }
            else
            {
                this.tbContent.Text = "";
                Shove._Web.Cache.ClearCache("MemberQuestionList_1_" + base._User.ID.ToString());
                Shove._Web.Cache.ClearCache("MemberQuestionList_2_" + base._User.ID.ToString());
                JavaScript.Alert(this.Page, "问题提交成功。");
            }
        }
    }

    private void FillQuestionType()
    {
        DataTable dt = new Tables.T_QuestionTypes().Open("", "UseType = 1", "[ID]");
        if ((dt == null) || (dt.Rows.Count == 0))
        {
            PF.GoError(4, "数据库繁忙，请重试", "Room_Service");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlQuestionType, dt, "Name", "ID");
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.labUserName.Text = base._User.Name;
        if (!base.IsPostBack)
        {
            this.FillQuestionType();
            this.tbUserTelphone.Text = base._User.Telephone;
        }
    }
}

