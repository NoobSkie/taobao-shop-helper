using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_AdvertisementsAdd : AdminPageBase, IRequiresSessionState
{


    private void BindType()
    {
        string request = Utility.GetRequest("LotteryID");
        string str2 = Utility.GetRequest("TypeID");
        if (this.ddlType.Items.FindByValue(str2) != null)
        {
            this.ddlType.SelectedValue = str2;
        }
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
        if (this.ddlLotteries.Items.FindByValue(request) != null)
        {
            this.ddlLotteries.SelectedValue = request;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string str = this.tbName.Text.Trim();
        if (str == "")
        {
            JavaScript.Alert(this.Page, "请输入广告标题！");
        }
        else
        {
            string input = this.tbUrl.Text.Trim();
            Regex regex = new Regex(@"^([\w-]+\.)+[\w-]+.([^a-z])(/[\w- ./?%&=]*)?|[a-zA-Z0-9\-\.][\w-]+.([^a-z])(/[\w- ./?%&=]*)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!regex.Match(input).Success)
            {
                JavaScript.Alert(this, "输入的URL地址格式错误，请仔细检查。");
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
                    Tables.T_Advertisements advertisements = new Tables.T_Advertisements();
                    string request = Utility.GetRequest("highlight_color");
                    if (request == "")
                    {
                        request = "#000000";
                    }
                    advertisements.Order.Value = num;
                    advertisements.Url.Value = input;
                    advertisements.Title.Value = str + "Color" + request;
                    advertisements.LotteryID.Value = this.ddlLotteries.SelectedValue;
                    advertisements.Name.Value = this.ddlType.SelectedItem.Text;
                    if (advertisements.Insert() > 0L)
                    {
                        string key = "Advertisements";
                        Shove._Web.Cache.ClearCache(key);
                        JavaScript.Alert(this, "添加成功", "Advertisements.aspx?LotteryID=" + this.ddlLotteries.SelectedValue + "&TypeID=" + this.ddlType.SelectedValue);
                    }
                    else
                    {
                        JavaScript.Alert(this, "添加失败");
                    }
                }
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("Advertisements.aspx?LotteryID=" + this.ddlLotteries.SelectedValue + "&TypeID=" + this.ddlType.SelectedValue, true);
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
            this.BindType();
        }
    }


}

