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

public partial class Admin_CardPasswordAdd : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        DataTable dt = new Tables.T_CardPasswordAgents().Open("[ID], [Name]", "", "[ID]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_CardPasswordAdd");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlCardPasswordAgents, dt, "Name", "ID");
        }
    }

    protected void btnGO_Click(object sender, EventArgs e)
    {
        int agentID = _Convert.StrToInt(this.ddlCardPasswordAgents.SelectedValue, -1);
        if (agentID < 0)
        {
            JavaScript.Alert(this.Page, "请输入有效的代理商编号。");
            this.ddlCardPasswordAgents.Focus();
        }
        else
        {
            int periodMonths = _Convert.StrToInt(this.tbDateTime.Text, 0);
            if (periodMonths < 1)
            {
                JavaScript.Alert(this.Page, "请输入正确的过期时间。");
                this.tbDateTime.Focus();
            }
            else
            {
                double money = _Convert.StrToDouble(this.tbMoney.Text, 0.0);
                if (money == 0.0)
                {
                    JavaScript.Alert(this.Page, "请输入有效的金额。");
                    this.tbMoney.Focus();
                }
                else
                {
                    int count = _Convert.StrToInt(this.tbCount.Text, 0);
                    if (count < 1)
                    {
                        JavaScript.Alert(this.Page, "请输入正确的卡密总数。");
                        this.tbCount.Focus();
                    }
                    else
                    {
                        string returnDescription = "";
                        if (new CardPassword().Add(agentID, periodMonths, money, count, ref returnDescription) < 0)
                        {
                            PF.GoError(4, "数据库繁忙，请重试", "Admin_CardPasswordAdd");
                        }
                        else if (returnDescription != "")
                        {
                            JavaScript.Alert(this.Page, returnDescription);
                        }
                        else
                        {
                            JavaScript.Alert(this.Page, "卡密增加成功!");
                        }
                    }
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = "Admin/CardPasswordAdd.aspx";
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Finance" });
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

