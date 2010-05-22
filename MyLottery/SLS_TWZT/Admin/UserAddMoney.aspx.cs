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

public partial class Admin_UserAddMoney : AdminPageBase, IRequiresSessionState
{
    private void BindData()
    {
        DataTable dt = new Tables.T_Sites().Open("[ID], [Name]", "", "[Level], [ID]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_UserAddMoney");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlSites, dt, "Name", "ID");
        }
    }

    protected void btnGO_Click(object sender, EventArgs e)
    {
        long siteid = _Convert.StrToLong(this.ddlSites.SelectedValue, -1L);
        if (siteid < 0L)
        {
            JavaScript.Alert(this.Page, "请输入有效的站点编号。");
        }
        else if (this.tbUserName.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入用户名称。");
        }
        else
        {
            double money = _Convert.StrToDouble(this.tbMoney.Text, 0.0);
            if (money == 0.0)
            {
                JavaScript.Alert(this.Page, "请输入有效的金额。");
            }
            else
            {
                Users users = new Users(siteid)[siteid, this.tbUserName.Text.Trim()];
                if (users == null)
                {
                    PF.GoError(1, "用户不存在", "Admin_UserAddMoney");
                }
                else
                {
                    string memo = "手工充值";
                    string returnDescription = "";
                    if (this.rb2.Checked)
                    {
                        memo = memo + "，获得的奖励";
                    }
                    else if (this.rb3.Checked)
                    {
                        memo = memo + "，购彩";
                    }
                    else if (this.rb4.Checked)
                    {
                        memo = memo + "，预付款";
                    }
                    else if (this.rb5.Checked)
                    {
                        memo = memo + "，转帐户";
                    }
                    if (this.tbMessage.Text.Trim() != "")
                    {
                        memo = memo + "，" + this.tbMessage.Text.Trim();
                    }
                    if (users.AddUserBalanceManual(money, memo, base._User.ID, ref returnDescription) < 0)
                    {
                        PF.GoError(1, returnDescription, "Admin_UserAddMoney");
                    }
                    else
                    {
                        this.tbUserName.Text = "";
                        this.tbMoney.Text = "";
                        this.tbMessage.Text = "";
                        JavaScript.Alert(this, "为用户充值成功。");
                    }
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = "Admin/UserAddMoney.aspx";
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "AddMoney" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
        }
    }


}

