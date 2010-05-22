using ASP;
using Shove;
using Shove._Web;
using Shove.Database;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_CardPasswordAgentsAdd : Page, IRequiresSessionState
{


    protected void btnOK_Click(object sender, EventArgs e)
    {
        int num = _Convert.StrToInt(this.tbAgentNO.Text, 0);
        if ((num < 0x3e8) || (num > 0x270f))
        {
            JavaScript.Alert(this.Page, "请输入4位长度的编号");
        }
        else
        {
            string str = Utility.FilteSqlInfusion(this.tbAgentName.Text);
            if (str == "")
            {
                JavaScript.Alert(this.Page, "请输入用户名");
            }
            else
            {
                double num2 = _Convert.StrToDouble(Utility.FilteSqlInfusion(this.tbMoney.Text), 0.0);
                if (num2 <= 0.0)
                {
                    JavaScript.Alert(this.Page, "请输入金额");
                }
                else
                {
                    string text = this.tbAgentPassword.Text;
                    if ((text == "") || (text.Length < 6))
                    {
                        JavaScript.Alert(this.Page, "请输入至少6位长度的密码");
                    }
                    else if (MSSQL.ExecuteNonQuery(string.Concat(new object[] { "INSERT INTO [SLS_mhb].[dbo].[T_CardPasswordAgents]([ID],[Name],[Password],[Company],[Url],[State],[Balance])VALUES(", num, ",'", str, "','", Utility.FilteSqlInfusion(PF.EncryptPassword(text)), "','", Utility.FilteSqlInfusion(this.tbAgentCompanyName.Text), "','", Utility.FilteSqlInfusion(this.tbAgentSiteName.Text), "',1,'", num2, "')" }), new MSSQL.Parameter[0]) < 0)
                    {
                        JavaScript.Alert(this.Page, "代理商添加失败!");
                    }
                    else
                    {
                        JavaScript.Alert(this.Page, "代理商添加成功!");
                    }
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

}

