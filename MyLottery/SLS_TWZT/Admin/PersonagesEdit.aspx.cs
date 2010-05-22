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

public partial class Admin_PersonagesEdit : AdminPageBase, IRequiresSessionState
{

    private void BindLotteryType()
    {
        string key = "dtLotteriesUseLotteryList";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Lotteries().Open("[ID], [Name], [Code]", "[ID] in(" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[ID]");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-46)");
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        this.ddlLotteries.DataSource = cacheAsDataTable;
        this.ddlLotteries.DataTextField = "Name";
        this.ddlLotteries.DataValueField = "ID";
        this.ddlLotteries.DataBind();
        this.hidID.Value = Utility.GetRequest("ID");
        DataTable table2 = new Tables.T_Personages().Open("", "ID=" + Utility.FilteSqlInfusion(this.hidID.Value), "");
        if ((table2 == null) || (table2.Rows.Count == 0))
        {
            JavaScript.Alert(this.Page, "记录不存在！");
        }
        else
        {
            if (this.ddlLotteries.Items.FindByValue(table2.Rows[0]["LotteryID"].ToString()) != null)
            {
                this.ddlLotteries.SelectedValue = table2.Rows[0]["LotteryID"].ToString();
            }
            this.tbOrder.Text = table2.Rows[0]["Order"].ToString();
            this.cbisShow.Checked = _Convert.StrToBool(table2.Rows[0]["IsShow"].ToString(), true);
            this.tbName.Text = table2.Rows[0]["UserName"].ToString();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string str = Utility.FilteSqlInfusion(this.tbName.Text.Trim());
        if (str == "")
        {
            JavaScript.Alert(this.Page, "请输入名人用户名！");
        }
        else
        {
            int num = _Convert.StrToInt(this.tbOrder.Text.Trim(), -1);
            if (num < 0)
            {
                JavaScript.Alert(this.Page, "顺序输入非法！");
            }
            else
            {
                DataTable table = new Tables.T_Users().Open("ID", "Name='" + str + "'", "");
                if ((table == null) || (table.Rows.Count == 0))
                {
                    JavaScript.Alert(this.Page, "不存在" + str + "用户！");
                }
                else
                {
                    table = new Tables.T_Personages().Open("ID", "UserName='" + str + "' and LotteryID=" + Utility.FilteSqlInfusion(this.ddlLotteries.SelectedValue) + " and ID<>" + Utility.FilteSqlInfusion(this.hidID.Value), "");
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        JavaScript.Alert(this.Page, str + "已经是" + this.ddlLotteries.SelectedItem.Text + "的名人了！");
                    }
                    else if (new Tables.T_Personages { Order = { Value = num }, UserName = { Value = str }, LotteryID = { Value = this.ddlLotteries.SelectedValue }, IsShow = { Value = this.cbisShow.Checked } }.Update("ID =" + Utility.FilteSqlInfusion(this.hidID.Value)) > 0L)
                    {
                        Shove._Web.Cache.ClearCache("Admin_Personages");
                        JavaScript.Alert(this, "修改成功", "Personages.aspx?LotteryID=" + this.ddlLotteries.SelectedValue);
                    }
                    else
                    {
                        JavaScript.Alert(this, "修改失败");
                    }
                }
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("Personages.aspx?LotteryID=" + this.ddlLotteries.SelectedValue, true);
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "FillContent" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindLotteryType();
        }
    }


}

