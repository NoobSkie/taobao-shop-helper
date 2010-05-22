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

public partial class Admin_AdvertisementsEdit : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        this.HidID.Value = Utility.GetRequest("ID");
        this.HidLotteryID.Value = Utility.GetRequest("LotteryID");
        this.HidTypeID.Value = Utility.GetRequest("TypeID");
        int num = _Convert.StrToInt(this.HidID.Value, 0);
        if (num < 0)
        {
            PF.GoError(1, "参数错误或数据被删除", this.Page.GetType().BaseType.FullName);
        }
        else
        {
            DataTable table = new Tables.T_Advertisements().Open("", "ID=" + num.ToString(), "");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
            }
            else if (table.Rows.Count == 0)
            {
                PF.GoError(1, "参数错误或数据被删除", this.Page.GetType().BaseType.FullName);
            }
            else
            {
                DataRow row = table.Rows[0];
                string[] strArray2 = row["Title"].ToString().Split(new string[] { "Color" }, StringSplitOptions.None);
                this.tbName.Text = strArray2[0];
                this.tbUrl.Text = row["Url"].ToString();
                this.tbOrder.Text = row["Order"].ToString();
                this.cbisShow.Checked = _Convert.StrToBool(row["isShow"].ToString(), true);
                if (strArray2.Length == 2)
                {
                    this.HidColor.Value = strArray2[1];
                }
            }
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string str = this.tbName.Text.Trim();
        if (str == "")
        {
            JavaScript.Alert(this.Page, "请输入广告标题！");
        }
        else
        {
            string input = this.tbUrl.Text.Trim();
            Regex regex = new Regex(@"([\w-]+\.)+[\w-]+.([^a-z])(/[\w- ./?%&=]*)?|[a-zA-Z0-9\-\.][\w-]+.([^a-z])(/[\w- ./?%&=]*)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
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
                    advertisements.Title.Value = str + "Color" + request;
                    advertisements.Order.Value = num;
                    advertisements.Url.Value = input;
                    advertisements.isShow.Value = this.cbisShow.Checked;
                    advertisements.LotteryID.Value = this.HidLotteryID.Value;
                    advertisements.Name.Value = (this.HidTypeID.Value == "1") ? "广告一" : ((this.HidTypeID.Value == "2") ? "广告二" : ((this.HidTypeID.Value == "3") ? "广告三" : ((this.HidTypeID.Value == "4") ? "广告四" : ((this.HidTypeID.Value == "5") ? "广告五" : ((this.HidTypeID.Value == "6") ? "广告六" : "广告七")))));
                    if (advertisements.Update("ID = " + Utility.FilteSqlInfusion(this.HidID.Value)) > 0L)
                    {
                        string key = "Advertisements";
                        Shove._Web.Cache.ClearCache(key);
                        JavaScript.Alert(this, "修改成功", "Advertisements.aspx?LotteryID=" + this.HidLotteryID.Value + "&TypeID=" + this.HidTypeID.Value);
                    }
                    else
                    {
                        JavaScript.Alert(this, "修改失败");
                    }
                }
            }
        }
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
            this.BindData();
        }
    }


}

