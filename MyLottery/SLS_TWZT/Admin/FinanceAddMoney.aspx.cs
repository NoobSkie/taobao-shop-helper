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

public partial class Admin_FinanceAddMoney : AdminPageBase, IRequiresSessionState
{
 

    private void BindData()
    {
        if (this.ddlYear.Items.Count != 0)
        {
            long userID = _Convert.StrToLong(this.tbID.Text, -1L);
            int returnValue = -1;
            string returnDescription = "";
            DataSet ds = null;
            if (Procedures.P_GetFinanceAddMoney(ref ds, base._Site.ID, userID, int.Parse(this.ddlYear.SelectedValue), int.Parse(this.ddlMonth.SelectedValue), ref returnValue, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else if ((ds == null) || (ds.Tables.Count < 1))
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_FinanceAddMoney");
            }
            else if (returnValue < 0)
            {
                PF.GoError(1, returnDescription, "Admin_FinanceAddMoney");
            }
            else
            {
                PF.DataGridBindData(this.g, ds.Tables[0], this.gPager);
            }
        }
    }

    private void BindDataForYearMonth()
    {
        this.ddlYear.Items.Clear();
        DateTime now = DateTime.Now;
        int year = now.Year;
        int month = now.Month;
        if (year < 0x7d8)
        {
            this.btnRead.Enabled = false;
        }
        else
        {
            for (int i = 0x7d8; i <= year; i++)
            {
                this.ddlYear.Items.Add(new ListItem(i.ToString() + "年", i.ToString()));
            }
            this.ddlYear.SelectedIndex = this.ddlYear.Items.Count - 1;
            this.ddlMonth.SelectedIndex = month - 1;
        }
    }

    protected void btnRead_Click(object sender, EventArgs e)
    {
        if (this.tbUserName.Text.Trim() != "")
        {
            Users users = new Users(base._Site.ID)[base._Site.ID, this.tbUserName.Text.Trim()];
            if (users == null)
            {
                JavaScript.Alert(this.Page, "用户名不存在。");
                return;
            }
            this.tbID.Text = users.ID.ToString();
        }
        else
        {
            this.tbID.Text = "-1";
        }
        this.BindData();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[2].Text = this.getBankName(e.Item.Cells[2].Text);
            double num = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            e.Item.Cells[3].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            e.Item.Cells[4].Text = (num == 0.0) ? "" : num.ToString("N");
            string text = e.Item.Cells[5].Text;
            if (text == "1")
            {
                text = "True";
            }
            e.Item.Cells[5].Text = _Convert.StrToBool(text, false) ? "<font color='Red'>成功</font>" : "未成功";
            e.Item.Cells[0].Text = "<a href='UserDetail.aspx?SiteID=" + e.Item.Cells[7].Text + "&ID=" + e.Item.Cells[6].Text + "'>" + e.Item.Cells[0].Text + "</a>";
        }
    }

    private string getBankName(string bankCode)
    {
        string str = "";
        string[] strArray = bankCode.Split(new char[] { '_' });
        if (strArray.Length < 2)
        {
            return "未知银行";
        }
        if (strArray[0].ToUpper() == "ALIPAY")
        {
            switch (strArray[1].ToUpper())
            {
                case "ALIPAY":
                    return "支付宝";

                case "ICBCB2C":
                    return "中国工商银行";

                case "GDB":
                    return "广东发展银行";

                case "CEBBANK":
                    return "中国光大银行";

                case "CCB":
                    return "中国建设银行";

                case "COMM":
                    return "中国交通银行";

                case "ABC":
                    return "中国农业银行";

                case "SPDB":
                    return "上海浦发银行";

                case "SDB":
                    return "深圳发展银行";

                case "CIB":
                    return "兴业银行";

                case "HZCBB2C":
                    return "杭州银行";

                case "CMBC":
                    return "杭州银行";

                case "BOCB2C":
                    return "中国银行";

                case "CMB":
                    return "中国招商银行";

                case "CITIC":
                    return "中信银行";
            }
            return "支付宝";
        }
        if (strArray[0].ToUpper() == "TENPAY")
        {
            switch (strArray[1].ToUpper())
            {
                case "0":
                    return "财付通";

                case "1001":
                    return "招商银行";

                case "1002":
                    return "中国工商银行";

                case "1003":
                    return "中国建设银行";

                case "1004":
                    return "上海浦东发展银行";

                case "1005":
                    return "中国农业银行";

                case "1006":
                    return "中国民生银行";

                case "1008":
                    return "深圳发展银行";

                case "1009":
                    return "兴业银行";

                case "1028":
                    return "广州银联";

                case "1032":
                    return "   北京银行";

                case "1020":
                    return "   中国交通银行";

                case "1022":
                    return "   中国光大银行";
            }
            return "财付通";
        }
        if (!(strArray[0].ToUpper() == "51ZFK"))
        {
            return str;
        }
        switch (strArray[1].ToUpper())
        {
            case "SZX":
                return "神州行充值卡";

            case "ZFK":
                return "51支付卡";
        }
        return "神州行充值卡";
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
    }

    protected override void OnInit(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = "Admin/FinanceAddMoney.aspx";
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Finance" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.tbID.Text = Utility.GetRequest("id");
            if (this.tbID.Text == "")
            {
                this.tbID.Text = "-1";
            }
            this.BindDataForYearMonth();
            this.BindData();
        }
    }
}

