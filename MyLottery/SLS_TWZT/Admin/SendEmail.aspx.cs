using ASP;
using DAL;
using FreeTextBoxControls;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Collections;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_SendEmail : AdminPageBase, IRequiresSessionState
{


    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (this.tbSubject.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入邮件标题。");
        }
        else if (this.tbContent.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入邮件内容。");
        }
        else if (this.cbSystemMessage.Checked)
        {
            this.SendSystemMessage();
        }
        else if (this.tbAim.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入接收方用户名。");
        }
        else
        {
            string[] aimNames = this.GetAimNames(this.tbAim.Text.Trim());
            if (aimNames.Length < 1)
            {
                JavaScript.Alert(this.Page, "请输入正确的接收方用户名。");
            }
            else
            {
                int num = 0;
                int num2 = 0;
                string str = "";
                for (int i = 0; i < aimNames.Length; i++)
                {
                    Users users = new Users(base._Site.ID)[base._Site.ID, aimNames[i]];
                    if (users == null)
                    {
                        num2++;
                        str = str + "用户 " + aimNames[i] + " 不存在！<br />";
                    }
                    else if (users.Email.Trim() == "")
                    {
                        num2++;
                        str = str + "用户 " + aimNames[i] + " 没有输入邮件地址！<br />";
                    }
                    else if (PF.SendEmail(base._Site, users.Email, this.tbSubject.Text.Trim(), this.tbContent.Text.Trim()) < 0)
                    {
                        num2++;
                        str = str + "用户 " + aimNames[i] + " 发送错误！<br />";
                    }
                    else
                    {
                        num++;
                        str = str + "用户 " + aimNames[i] + " 发送成功。<br />";
                    }
                }
                this.labSendResult.Text = "发送结果：成功 " + num.ToString() + " 个，失败 " + num2.ToString() + " 个。<br />" + str;
                if (num2 == 0)
                {
                    this.tbAim.Text = "";
                    this.tbContent.Text = "";
                    this.cbSystemMessage.Checked = false;
                }
            }
        }
    }

    private string[] GetAimNames(string str)
    {
        string[] strArray = str.Split(new char[] { ',' });
        ArrayList list = new ArrayList();
        for (int i = 0; i < strArray.Length; i++)
        {
            strArray[i] = strArray[i].Trim();
            if (strArray[i] != "")
            {
                bool flag = false;
                for (int k = 0; k < list.Count; k++)
                {
                    if (list[k].ToString() == strArray[i])
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    list.Add(strArray[i]);
                }
            }
        }
        while (list.Count > 10)
        {
            list.RemoveAt(list.Count - 1);
        }
        string[] strArray2 = new string[list.Count];
        for (int j = 0; j < list.Count; j++)
        {
            strArray2[j] = list[j].ToString();
        }
        return strArray2;
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "SendMessage" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private void SendSystemMessage()
    {
        DataTable table = new Tables.T_Users().Open("", "SiteID = " + base._Site.ID.ToString() + " and Email <> ''", "");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_SendEmail");
        }
        else
        {
            int num = 0;
            int num2 = 0;
            string str = "";
            foreach (DataRow row in table.Rows)
            {
                if (PF.SendEmail(base._Site, row["Email"].ToString(), this.tbSubject.Text.Trim(), this.tbContent.Text.Trim()) < 0)
                {
                    num2++;
                    str = str + "用户 " + row["Name"].ToString() + " 发送错误！<br />";
                }
                else
                {
                    num++;
                    str = str + "用户 " + row["Name"].ToString() + " 发送成功。<br />";
                }
            }
            this.labSendResult.Text = "发送结果：成功 " + num.ToString() + " 个，失败 " + num2.ToString() + " 个。<br />" + str;
            if (num2 == 0)
            {
                this.tbAim.Text = "";
                this.tbContent.Text = "";
                this.cbSystemMessage.Checked = false;
            }
        }
    }


}

