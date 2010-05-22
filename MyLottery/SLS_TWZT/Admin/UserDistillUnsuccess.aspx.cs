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

public partial class Admin_UserDistillUnsuccess : AdminPageBase, IRequiresSessionState
{
    private void BindBankType()
    {
        string key = "Admin_UserDistillUnsuccess_BankType";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Banks().Open("", "", "[Name]");
        }
        this.ddlAccountType.DataSource = cacheAsDataTable;
        this.ddlAccountType.DataTextField = "Name";
        this.ddlAccountType.DataValueField = "Name";
        this.ddlAccountType.DataBind();
        this.ddlAccountType.Items.Insert(0, "");
        this.ddlAccountType.Items.Add("支付宝");
    }

    private void BindData()
    {
        string filterCondition = this.GetFilterCondition();
        DataTable dt = new Views.V_UserDistills().Open("", filterCondition, "[DateTime] desc");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_FinanceDistill");
        }
        else
        {
            PF.DataGridBindData(this.g, dt, this.gPager);
            for (int i = 0; i < this.g.Columns.Count; i++)
            {
                if ((((this.g.Columns[i].HeaderText == "提款银行卡帐号") || (this.g.Columns[i].HeaderText == "开户银行")) || ((this.g.Columns[i].HeaderText == "支行名称") || (this.g.Columns[i].HeaderText == "所在省"))) || ((this.g.Columns[i].HeaderText == "所在市") || (this.g.Columns[i].HeaderText == "持卡人姓名")))
                {
                    this.g.Columns[i].Visible = (this.hfCurPayType.Value == "所有") || (this.hfCurPayType.Value == "银行卡");
                }
                else if (this.g.Columns[i].HeaderText == "支付宝账号")
                {
                    this.g.Columns[i].Visible = true;
                    this.g.Columns[i].Visible = (this.hfCurPayType.Value == "所有") || (this.hfCurPayType.Value == "支付宝");
                }
            }
        }
    }

    protected void btnDownLoadExcel_Click(object sender, EventArgs e)
    {
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        long distillID = _Convert.StrToLong(this.g.DataKeys[e.Item.ItemIndex].ToString(), -1L);
        long userID = _Convert.StrToLong(e.Item.Cells[0].Text, -1L);
        if (e.CommandName == "Pay")
        {
            int returnValue = 0;
            string returnDescription = "";
            if (Procedures.P_DistillPaySuccess(base._Site.ID, userID, distillID, "付款成功", base._User.ID, ref returnValue, ref returnDescription) < 0)
            {
                JavaScript.Alert(this.Page, "出错!请联技术人员!");
            }
            else if (returnValue < 0)
            {
                JavaScript.Alert(this.Page, "出错!请联技术人员:" + returnDescription);
            }
            else
            {
                this.BindData();
                JavaScript.Alert(this.Page, "操作成功.");
            }
        }
        else if (e.CommandName == "DistillNoAccept")
        {
            string memo = ((TextBox)e.Item.FindControl("tbMemo")).Text.Trim();
            if ((memo == "") || (memo.IndexOf("接受提款") > 0))
            {
                memo = "提款资料不完整";
            }
            int num6 = 0;
            string str3 = "";
            if (Procedures.P_DistillNoAccept(base._Site.ID, userID, distillID, memo, base._User.ID, ref num6, ref str3) < 0)
            {
                JavaScript.Alert(this.Page, "出错!请联技术人员!");
            }
            else if (num6 < 0)
            {
                JavaScript.Alert(this.Page, "出错!请联技术人员:" + str3);
            }
            else
            {
                this.BindData();
                JavaScript.Alert(this.Page, "操作成功!该笔提款已拒绝提款.");
            }
        }
    }

    private string GetFilterCondition()
    {
        string str = " Result=12 ";
        if (this.hfCurPayType.Value == "银行卡")
        {
            str = str + " and DistillType =2 ";
        }
        else if (this.hfCurPayType.Value == "支付宝")
        {
            str = str + " and DistillType =1 ";
        }
        if (this.tbUserName.Text.Trim() != "")
        {
            str = str + " and Name='" + Utility.FilteSqlInfusion(this.tbUserName.Text.Trim()) + "' ";
        }
        if (!(this.ddlAccountType.Text.Trim() != ""))
        {
            return str;
        }
        if (this.ddlAccountType.Text != "支付宝")
        {
            return (str + " and BankTypeName = '" + this.ddlAccountType.Text + "'");
        }
        return (str + " and DistillType =1 ");
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindData();
    }

    protected void lbtnAllPay_Click(object sender, EventArgs e)
    {
        this.hfCurPayType.Value = "所有";
        this.BindData();
        this.PayByAlipay.Attributes["class"] = "NotSelectedTab";
        this.PayByBank.Attributes["class"] = "NotSelectedTab";
        this.AllPay.Attributes["class"] = "SelectedTab";
    }

    protected void lbtnPayByAlipay_Click(object sender, EventArgs e)
    {
        this.hfCurPayType.Value = "支付宝";
        this.BindData();
        this.PayByAlipay.Attributes["class"] = "SelectedTab";
        this.PayByBank.Attributes["class"] = "NotSelectedTab";
        this.AllPay.Attributes["class"] = "NotSelectedTab";
    }

    protected void lbtnPayByBank_Click(object sender, EventArgs e)
    {
        this.hfCurPayType.Value = "银行卡";
        this.BindData();
        this.PayByAlipay.Attributes["class"] = "NotSelectedTab";
        this.PayByBank.Attributes["class"] = "SelectedTab";
        this.AllPay.Attributes["class"] = "NotSelectedTab";
    }

    protected override void OnInit(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Finance" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindBankType();
            this.hfCurPayType.Value = "支付宝";
            this.PayByAlipay.Attributes["class"] = "SelectedTab";
            this.PayByBank.Attributes["class"] = "NotSelectedTab";
            this.AllPay.Attributes["class"] = "NotSelectedTab";
            this.BindData();
        }
    }
}

