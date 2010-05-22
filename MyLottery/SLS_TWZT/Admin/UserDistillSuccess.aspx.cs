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

public partial class Admin_UserDistillSuccess : AdminPageBase, IRequiresSessionState
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

    private void BindData(bool IsReload)
    {
        this.lblTotalDistillMoney.Text = "0";
        this.lblTotalFormalitiesFees.Text = "0";
        this.lblTotalPayMoney.Text = "0";
        DateTime now = DateTime.Now;
        DateTime result = DateTime.Now;
        if (!DateTime.TryParse(this.tbBeginTime.Text, out now) || !DateTime.TryParse(this.tbEndTime.Text, out result))
        {
            JavaScript.Alert(this.Page, "请输入正确的日期范围!");
        }
        else
        {
            string text1 = "Admin_UserDistillSuccess_Data_" + this.tbBeginTime.Text + "_" + this.tbEndTime.Text;
            string filterCondition = this.GetFilterCondition();
            DataTable dt = new Views.V_UserDistills().Open("", filterCondition, "[DateTime] desc");
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_FinanceDistill");
            }
            else
            {
                double num = 0.0;
                double num2 = 0.0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    num += _Convert.StrToDouble(dt.Rows[i]["Money"].ToString(), 0.0);
                    num2 += _Convert.StrToDouble(dt.Rows[i]["FormalitiesFees"].ToString(), 0.0);
                }
                this.lblTotalDistillMoney.Text = num.ToString();
                this.lblTotalFormalitiesFees.Text = num2.ToString();
                this.lblTotalPayMoney.Text = (num - num2).ToString();
                PF.DataGridBindData(this.g, dt, this.gPager);
                for (int j = 0; j < this.g.Columns.Count; j++)
                {
                    if ((((this.g.Columns[j].HeaderText == "提款银行卡帐号") || (this.g.Columns[j].HeaderText == "开户银行")) || ((this.g.Columns[j].HeaderText == "支行名称") || (this.g.Columns[j].HeaderText == "所在省"))) || ((this.g.Columns[j].HeaderText == "所在市") || (this.g.Columns[j].HeaderText == "持卡人姓名")))
                    {
                        this.g.Columns[j].Visible = (this.hfCurPayType.Value == "所有") || (this.hfCurPayType.Value == "银行卡");
                    }
                    else if (this.g.Columns[j].HeaderText == "支付宝账号")
                    {
                        this.g.Columns[j].Visible = true;
                        this.g.Columns[j].Visible = (this.hfCurPayType.Value == "所有") || (this.hfCurPayType.Value == "支付宝");
                    }
                }
            }
        }
    }

    protected void btnDownLoadExcel_Click(object sender, EventArgs e)
    {
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if ((this.tbBeginTime.Text.Trim() != "") && (this.tbEndTime.Text.Trim() != ""))
        {
            DateTime now = DateTime.Now;
            DateTime result = DateTime.Now;
            if (!DateTime.TryParse(this.tbBeginTime.Text, out now) && !DateTime.TryParse(this.tbEndTime.Text, out result))
            {
                JavaScript.Alert(this.Page, "请输入正确的日期格式:2008-8-8");
                return;
            }
        }
        this.BindData(false);
    }

    protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData(false);
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if ((e.Item.ItemType != ListItemType.Item) && (e.Item.ItemType != ListItemType.AlternatingItem))
        {
            ListItemType itemType = e.Item.ItemType;
        }
    }

    private string GetFilterCondition()
    {
        string str = " Result=1 ";
        if ((this.tbBeginTime.Text.Trim() != "") && (this.tbEndTime.Text.Trim() != ""))
        {
            DateTime now = DateTime.Now;
            DateTime result = DateTime.Now;
            if (DateTime.TryParse(this.tbBeginTime.Text, out now) && DateTime.TryParse(this.tbEndTime.Text, out result))
            {
                if (this.rbByDistillTime.Checked)
                {
                    string str2 = str;
                    str = str2 + " and ( DateTime >= '" + now.ToString("yyyy-MM-dd") + "' and DateTime <= '" + result.ToString("yyyy-MM-dd") + " 23:59:59' )";
                }
                else
                {
                    string str3 = str;
                    str = str3 + " and ( HandleDateTime >= '" + now.ToString("yyyy-MM-dd") + "' and HandleDateTime <= '" + result.ToString("yyyy-MM-dd") + " 23:59:59' )";
                }
            }
            else
            {
                JavaScript.Alert(this.Page, "请输入正确的日期格式:2008-8-8");
            }
        }
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
        this.BindData(false);
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindData(false);
    }

    protected void lbtnAllPay_Click(object sender, EventArgs e)
    {
        this.hfCurPayType.Value = "所有";
        this.BindData(false);
        this.PayByAlipay.Attributes["class"] = "NotSelectedTab";
        this.PayByBank.Attributes["class"] = "NotSelectedTab";
        this.AllPay.Attributes["class"] = "SelectedTab";
    }

    protected void lbtnPayByAlipay_Click(object sender, EventArgs e)
    {
        this.hfCurPayType.Value = "支付宝";
        this.BindData(false);
        this.PayByAlipay.Attributes["class"] = "SelectedTab";
        this.PayByBank.Attributes["class"] = "NotSelectedTab";
        this.AllPay.Attributes["class"] = "NotSelectedTab";
    }

    protected void lbtnPayByBank_Click(object sender, EventArgs e)
    {
        this.hfCurPayType.Value = "银行卡";
        this.BindData(false);
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
            this.tbBeginTime.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
            this.tbEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.BindBankType();
            this.hfCurPayType.Value = "支付宝";
            this.PayByAlipay.Attributes["class"] = "SelectedTab";
            this.PayByBank.Attributes["class"] = "NotSelectedTab";
            this.AllPay.Attributes["class"] = "NotSelectedTab";
            this.BindData(true);
        }
    }


}

