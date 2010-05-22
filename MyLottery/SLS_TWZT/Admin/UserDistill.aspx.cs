using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial  class Admin_UserDistill : AdminPageBase, IRequiresSessionState
{
    private SystemOptions so = new SystemOptions();

    private void BindData()
    {
        short num = 0;
        DataTable table = new Views.V_UserDistills().Open("", "Result = " + num.ToString(), "[DateTime]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            this.g.DataSource = table;
            this.g.DataBind();
            this.labTip.Visible = table.Rows.Count == 0;
        }
    }

    protected void g_ItemCommand(object source, DataListCommandEventArgs e)
    {
        long siteid = _Convert.StrToLong(((HtmlInputHidden)e.Item.FindControl("tbSiteID")).Value, -1L);
        long distillID = _Convert.StrToLong(((HtmlInputHidden)e.Item.FindControl("tbID")).Value, -1L);
        long num3 = _Convert.StrToLong(((HtmlInputHidden)e.Item.FindControl("tbUserID")).Value, -1L);
        double num4 = Math.Round(_Convert.StrToDouble(((HtmlInputHidden)e.Item.FindControl("tbMoney")).Value, 0.0), 2);
        HtmlInputHidden hidden = (HtmlInputHidden)e.Item.FindControl("tbBankName");
        HtmlInputHidden hidden2 = (HtmlInputHidden)e.Item.FindControl("tbBankUserName");
        HtmlInputHidden hidden3 = (HtmlInputHidden)e.Item.FindControl("tbBankCardNumber");
        HtmlInputHidden hidden1 = (HtmlInputHidden)e.Item.FindControl("tbProvince");
        HtmlInputHidden hidden7 = (HtmlInputHidden)e.Item.FindControl("tbCity");
        HtmlInputHidden hidden8 = (HtmlInputHidden)e.Item.FindControl("tbRealityName");
        HtmlInputHidden hidden4 = (HtmlInputHidden)e.Item.FindControl("tbAlipayID");
        HtmlInputHidden hidden5 = (HtmlInputHidden)e.Item.FindControl("tbAlipayName");
        HtmlInputHidden hidden9 = (HtmlInputHidden)e.Item.FindControl("tbMemo");
        HtmlInputHidden hidden6 = (HtmlInputHidden)e.Item.FindControl("tbIsCps");
        if (((siteid < 0L) || (distillID < 0L)) || (num3 < 0L))
        {
            PF.GoError(1, "参数错误", base.GetType().BaseType.FullName);
        }
        else
        {
            Users users = new Users(siteid)[siteid, num3];
            if (users == null)
            {
                PF.GoError(1, "参数错误", base.GetType().BaseType.FullName);
            }
            else if (e.CommandName == "btnNoAccept")
            {
                TextBox box = (TextBox)e.Item.FindControl("tbMemo1");
                if (box.Text.Trim() == "")
                {
                    JavaScript.Alert(this.Page, "请输入拒绝理由。");
                }
                else
                {
                    string returnDescription = "";
                    if (users.DistillNoAccept(distillID, box.Text.Trim(), base._User.ID, ref returnDescription) < 0)
                    {
                        PF.GoError(1, returnDescription, base.GetType().BaseType.FullName);
                    }
                    else
                    {
                        this.BindData();
                    }
                }
            }
            else if (e.CommandName == "btnAccept")
            {
                TextBox box2 = (TextBox)e.Item.FindControl("tbMemo2");
                if (!_Convert.StrToBool(hidden6.Value, false))
                {
                    if (users.Freeze < num4)
                    {
                        JavaScript.Alert(this.Page, "用户冻结账户余额不足以提款。");
                        return;
                    }
                }
                else if (base._User.Freeze < num4)
                {
                    JavaScript.Alert(this.Page, "用户冻结账户余额不足以提款。");
                    return;
                }
                if (hidden3.Value != "")
                {
                    if (hidden2.Value == "")
                    {
                        JavaScript.Alert(this.Page, "用户没有输入开户名。");
                        return;
                    }
                    if (hidden.Value == "")
                    {
                        JavaScript.Alert(this.Page, "用户没有输入开户银行。");
                        return;
                    }
                    if (hidden3.Value == "")
                    {
                        JavaScript.Alert(this.Page, "用户没有输入银行卡号。");
                        return;
                    }
                }
                else if (hidden5.Value == "")
                {
                    JavaScript.Alert(this.Page, "用户没有输入支付宝账号");
                    return;
                }
                if (this.so["OnlinePayOut_Alipay_DistillFormalitiesFeesScale"].ToDouble(0.0) >= 1.0)
                {
                    JavaScript.Alert(this.Page, "提款手续费比例设置错误。");
                }
                else
                {
                    string str2 = "";
                    if (users.DistillAccept(distillID, hidden2.Value, hidden.Value, hidden3.Value, hidden4.Value, hidden5.Value, box2.Text.Trim(), base._User.ID, ref str2) < 0)
                    {
                        JavaScript.Alert(this.Page, "出错:" + str2);
                    }
                    else
                    {
                        JavaScript.Alert(this.Page, "已经接受提款! 请到待付款一览表进行付款操作.");
                        this.BindData();
                    }
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = "Admin/UserDistill.aspx";
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "DistillMoney" });
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

