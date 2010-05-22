using ASP;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Collections;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_MessageSend : RoomPageBase, IRequiresSessionState
{
    protected void btnSend_Click(object sender, EventArgs e)
    {
        this.tbAim.Text = "admin";
        if (this.tbContent.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入短消息内容。");
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
                string msg = "";
                for (int i = 0; i < aimNames.Length; i++)
                {
                    if (aimNames[i] == base._User.Name)
                    {
                        num++;
                        msg = msg + "用户 " + aimNames[i] + " 不能发送消息给自己！";
                    }
                    else
                    {
                        Users users = new Users(base._Site.ID)
                        {
                            Name = aimNames[i]
                        };
                        string returnDescription = "";
                        int userInformationByName = users.GetUserInformationByName(ref returnDescription);
                        if (((userInformationByName != 0) && (userInformationByName != -3)) && (returnDescription != ""))
                        {
                            num++;
                            msg = msg + "用户 " + aimNames[i] + " 不存在！<br />";
                        }
                        else
                        {
                            PF.SendStationSMS(base._Site, base._User.ID, users.ID, 1, this.tbContent.Text.Trim());
                        }
                    }
                }
                if (num > 0)
                {
                    JavaScript.Alert(this.Page, msg);
                }
                else
                {
                    this.tbAim.Text = "";
                    this.tbContent.Text = "";
                    JavaScript.Alert(this.Page, "发送成功。");
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
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}

