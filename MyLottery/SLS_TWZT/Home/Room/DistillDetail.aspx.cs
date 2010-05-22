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

public partial class Home_Room_DistillDetail : RoomPageBase, IRequiresSessionState
{

    private void BindDistills()
    {
        if (base._User != null)
        {
            string key = "Home_Room_DistillDetail_" + base._User.ID.ToString();
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Views.V_UserDistills().Open("ID,[DateTime],[Money],FormalitiesFees,Result,Memo", "[UserID] = " + base._User.ID.ToString(), "[DateTime] desc, [ID]");
                if (cacheAsDataTable == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试(732)", base.GetType().FullName);
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 60);
            }
            this.gUserDistills.DataSource = cacheAsDataTable;
            this.gUserDistills.DataBind();
            this.lblDistillCount.Text = cacheAsDataTable.Rows.Count.ToString();
            this.lblDistillMoney.Text = PF.GetSumByColumn(cacheAsDataTable, 2, false, this.gUserDistills.PageSize, 0).ToString("N");
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindDistills();
    }

    protected void gUserDistills_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        HiddenField field = (HiddenField)e.Item.FindControl("tdDistillID");
        int num = _Convert.StrToInt(field.Value, 0);
        if (e.CommandName == "QuashDistills")
        {
            string key = "Home_Room_DistillDetail_" + base._User.ID.ToString();
            string returnDescription = "";
            if (base._User.DistillQuash((long)num, ref returnDescription) < 0)
            {
                JavaScript.Alert(this.Page, "数据库读写错误." + returnDescription);
            }
            else if (returnDescription != "")
            {
                JavaScript.Alert(this.Page, returnDescription);
            }
            else
            {
                JavaScript.Alert(this.Page, "撤销成功。");
                Shove._Web.Cache.ClearCache(key);
                this.BindDistills();
            }
        }
        else if (e.CommandName == "ShowDistillDetail")
        {
            this.isShowDistill.Visible = true;
            string str3 = "";
            string str4 = "";
            string str5 = "";
            DataTable table = new Tables.T_UserDistills().Open("BankCardNumber,AlipayName,[DateTime], BankTypeName, BankName, BankInProvince, BankInCity", "id = " + num, "");
            str3 = table.Rows[0]["BankCardNumber"].ToString();
            str4 = table.Rows[0]["AlipayName"].ToString();
            str5 = table.Rows[0]["DateTime"].ToString();
            if (str3 == "")
            {
                this.lblDistillBankType.Text = "支付宝提款";
                this.lblDistillBanks.Text = "支付宝账号: ";
                this.lblDistillBankDetail.Text = str4;
                this.divBankInfo.Visible = false;
            }
            else
            {
                this.lblDistillBankType.Text = "银行卡提款";
                this.lblDistillBankDetail.Text = str3;
                this.lblDistillBanks.Text = "银行卡号: ";
                this.divBankInfo.Visible = true;
                this.lbBankInProvince.Text = table.Rows[0]["BankInProvince"].ToString();
                this.lbBankInCity.Text = table.Rows[0]["BankInCity"].ToString();
                this.lbAccountBank.Text = table.Rows[0]["BankName"].ToString();
                this.lbBankTypeName.Text = table.Rows[0]["BankTypeName"].ToString();
            }
            this.lblDistillTime.Text = str5.ToString();
            this.BindDistills();
        }
    }

    protected void gUserDistills_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            double num = _Convert.StrToDouble(e.Item.Cells[1].Text, 0.0);
            e.Item.Cells[1].Text = (num == 0.0) ? "" : num.ToString("N");
            num = _Convert.StrToDouble(e.Item.Cells[2].Text, 0.0);
            e.Item.Cells[2].Text = (num == 0.0) ? "" : num.ToString("N");
            e.Item.Cells[3].Text = "提款";
            switch (e.Item.Cells[4].Text)
            {
                case "0":
                    e.Item.Cells[4].Text = "申请状态";
                    return;

                case "1":
                    e.Item.Cells[4].Text = "已付款";
                    return;

                case "-1":
                    e.Item.Cells[4].Text = "拒绝提款";
                    return;

                case "-2":
                    e.Item.Cells[4].Text = "用户撤销提款";
                    return;
            }
            e.Item.Cells[4].Text = "处理中...";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDistills();
            this.isShowDistill.Visible = false;
        }
    }
}

