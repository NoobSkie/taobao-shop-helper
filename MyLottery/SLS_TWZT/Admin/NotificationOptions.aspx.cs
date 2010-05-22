using ASP;
using DAL;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_NotificationOptions : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        for (short i = 1; i <= 3; i = (short)(i + 1))
        {
            string str = Functions.F_GetSiteSendNotificationTypes(base._Site.ID, i);
            for (short j = 1; j <= 0x15; j = (short)(j + 1))
            {
                CheckBox box = (CheckBox)this.FindControl("cb" + j.ToString() + "_" + i.ToString());
                if (box != null)
                {
                    box.Checked = str.IndexOf("[" + new NotificationTypes()[j] + "]") >= 0;
                }
            }
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        for (short i = 1; i <= 3; i = (short)(i + 1))
        {
            string sendNotificationTypeList = "";
            for (short j = 1; j <= 0x15; j = (short)(j + 1))
            {
                CheckBox box = (CheckBox)this.FindControl("cb" + j.ToString() + "_" + i.ToString());
                if ((box != null) && box.Checked)
                {
                    sendNotificationTypeList = sendNotificationTypeList + "[" + j.ToString() + "]";
                }
            }
            int returnValue = -1;
            string returnDescription = "";
            if (Procedures.P_SetSiteSendNotificationTypes(base._Site.ID, i, sendNotificationTypeList, ref returnValue, ref returnDescription) < 0)
            {
                PF.GoError(1, returnDescription, "Admin_NotificationOptions");
                return;
            }
            if (returnValue < 0)
            {
                JavaScript.Alert(this.Page, returnDescription);
                return;
            }
            JavaScript.Alert(this.Page, "通知、消息的发送选项已经保存成功。");
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Options", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            this.btnOK.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "Options" }));
        }
    }


}

