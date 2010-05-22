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

public partial class Admin_UserDistillGeneralLedger : AdminPageBase, IRequiresSessionState
{
    private void BindBankDetailData(bool IsReload)
    {
        DateTime now = DateTime.Now;
        DateTime result = DateTime.Now;
        if (((this.tbBeginTime.Text.Trim() != "") && (this.tbEndTime.Text.Trim() != "")) && (!DateTime.TryParse(this.tbBeginTime.Text.Trim(), out now) || !DateTime.TryParse(this.tbEndTime.Text.Trim() + " 23:59:59", out result)))
        {
            JavaScript.Alert(this.Page, "请输入正确的日期格式:2009-08-08");
        }
        else
        {
            string key = "Admin_UserDistillGeneralLedger_BankDetailData_" + now.ToString("yyyyMMdd") + result.ToString("yyyyMMdd");
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if ((cacheAsDataTable == null) || IsReload)
            {
                DataSet ds = null;
                int returnValue = 0;
                string returnDescription = "";
                if (Procedures.P_GetDistillStatisticByAccount(ref ds, base._Site.ID, now, result, "", ref returnValue, ref returnDescription) < 0)
                {
                    PF.GoError(4, "数据读写错误", base.GetType().BaseType.FullName);
                    return;
                }
                if ((returnValue < 0) || (returnDescription != ""))
                {
                    JavaScript.Alert(this.Page, returnDescription);
                    return;
                }
                cacheAsDataTable = ds.Tables[0];
                Shove._Web.Cache.SetCache(key, cacheAsDataTable);
            }
            PF.DataGridBindData(this.dgBankDetail, cacheAsDataTable);
            string str3 = "Admin_UserDistillGeneralLedger_cacheKeyGetDistillMoneyAndAddMoney_" + now.ToString("yyyyMMdd") + result.ToString("yyyyMMdd");
            DataTable table2 = Shove._Web.Cache.GetCacheAsDataTable(str3);
            if ((table2 == null) || IsReload)
            {
                DataSet set2 = null;
                int num2 = 0;
                string str4 = "";
                if (Procedures.P_GetDistillMoneyAndAddMoney(ref set2, base._Site.ID, now, result, 0, ref num2, ref str4) < 0)
                {
                    PF.GoError(4, "数据读写错误", base.GetType().BaseType.FullName);
                    return;
                }
                if ((num2 < 0) || (str4 != ""))
                {
                    JavaScript.Alert(this.Page, str4);
                    return;
                }
                table2 = set2.Tables[0];
                Shove._Web.Cache.SetCache(str3, table2);
            }
            this.lblSumAddMoneyByDate2.Text = _Convert.StrToDouble(table2.Rows[0]["SumAddMoneyByDate"].ToString(), 0.0).ToString("N2");
            this.lblSumAddMoney2.Text = _Convert.StrToDouble(table2.Rows[0]["SumAddMoney"].ToString(), 0.0).ToString("N2");
            this.lblSumDistillMoneyByDate2.Text = _Convert.StrToDouble(table2.Rows[0]["SumDistillMoneyByDate"].ToString(), 0.0).ToString("N2");
            this.lblSumDistillMoney2.Text = _Convert.StrToDouble(table2.Rows[0]["SumDistillMoney"].ToString(), 0.0).ToString("N2");
            this.lblSumFormalitiesFeesByDate2.Text = _Convert.StrToDouble(table2.Rows[0]["SumFormalitiesFeesByDate"].ToString(), 0.0).ToString("N2");
            this.lblSumFormalitiesFees2.Text = _Convert.StrToDouble(table2.Rows[0]["SumFormalitiesFees"].ToString(), 0.0).ToString("N2");
        }
    }

    private void BindDuiZhangDanData(bool IsReload)
    {
        DateTime now = DateTime.Now;
        DateTime result = DateTime.Now;
        if (((this.tbBeginTime.Text.Trim() != "") && (this.tbEndTime.Text.Trim() != "")) && (!DateTime.TryParse(this.tbBeginTime.Text.Trim(), out now) || !DateTime.TryParse(this.tbEndTime.Text.Trim() + " 23:59:59", out result)))
        {
            JavaScript.Alert(this.Page, "请输入正确的日期格式:2009-08-08");
        }
        else
        {
            string key = "Admin_UserDistillGeneralLedger_" + now.ToString("yyyyMMdd") + result.ToString("yyyyMMdd");
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if ((cacheAsDataTable == null) || IsReload)
            {
                DataSet ds = null;
                int returnValue = 0;
                string returnDescription = "";
                if (Procedures.P_GetDistillStatisticByDistillType(ref ds, base._Site.ID, now, result, ref returnValue, ref returnDescription) < 0)
                {
                    PF.GoError(4, "数据读写错误", base.GetType().BaseType.FullName);
                    return;
                }
                if ((returnValue < 0) || (returnDescription != ""))
                {
                    JavaScript.Alert(this.Page, returnDescription);
                    return;
                }
                cacheAsDataTable = ds.Tables[0];
                Shove._Web.Cache.SetCache(key, cacheAsDataTable);
            }
            PF.DataGridBindData(this.dgDuiZhangDan, cacheAsDataTable);
            string str3 = "Admin_UserDistillGeneralLedger_cacheKeyGetDistillMoneyAndAddMoney_" + now.ToString("yyyyMMdd") + result.ToString("yyyyMMdd");
            DataTable table2 = Shove._Web.Cache.GetCacheAsDataTable(str3);
            if ((table2 == null) || IsReload)
            {
                DataSet set2 = null;
                int num2 = 0;
                string str4 = "";
                if (Procedures.P_GetDistillMoneyAndAddMoney(ref set2, base._Site.ID, now, result, 0, ref num2, ref str4) < 0)
                {
                    PF.GoError(4, "数据读写错误", base.GetType().BaseType.FullName);
                    return;
                }
                if ((num2 < 0) || (str4 != ""))
                {
                    JavaScript.Alert(this.Page, str4);
                    return;
                }
                table2 = set2.Tables[0];
                Shove._Web.Cache.SetCache(str3, table2);
            }
            this.lblSumAddMoneyByDate1.Text = _Convert.StrToDouble(table2.Rows[0]["SumAddMoneyByDate"].ToString(), 0.0).ToString("N2");
            this.lblSumAddMoney1.Text = _Convert.StrToDouble(table2.Rows[0]["SumAddMoney"].ToString(), 0.0).ToString("N2");
            this.lblSumDistillMoneyByDate1.Text = _Convert.StrToDouble(table2.Rows[0]["SumDistillMoneyByDate"].ToString(), 0.0).ToString("N2");
            this.lblSumDistillMoney1.Text = _Convert.StrToDouble(table2.Rows[0]["SumDistillMoney"].ToString(), 0.0).ToString("N2");
            this.lblSumFormalitiesFeesByDate1.Text = _Convert.StrToDouble(table2.Rows[0]["SumFormalitiesFeesByDate"].ToString(), 0.0).ToString("N2");
            this.lblSumFormalitiesFees1.Text = _Convert.StrToDouble(table2.Rows[0]["SumFormalitiesFees"].ToString(), 0.0).ToString("N2");
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.BindDuiZhangDanData(false);
        this.BindBankDetailData(false);
    }

    protected void lbtnBankDetail_Click(object sender, EventArgs e)
    {
        this.DuiZhangDan.Visible = false;
        this.BankDetail.Visible = true;
        this.hfCurPayType.Value = "银行明细";
        this.tdDuiZhangDan.Attributes["class"] = "NotSelectedTab";
        this.tdBankDetail.Attributes["class"] = "SelectedTab";
    }

    protected void lbtnDuiZhangDan_Click(object sender, EventArgs e)
    {
        this.DuiZhangDan.Visible = true;
        this.BankDetail.Visible = false;
        this.hfCurPayType.Value = "提款对帐单";
        this.tdDuiZhangDan.Attributes["class"] = "SelectedTab";
        this.tdBankDetail.Attributes["class"] = "NotSelectedTab";
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
            this.tbBeginTime.Text = DateTime.Now.ToString("yyyy-MM") + "-1";
            this.tbEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.hfCurPayType.Value = "提款对帐单";
            this.DuiZhangDan.Visible = true;
            this.BankDetail.Visible = false;
            this.tdDuiZhangDan.Attributes["class"] = "SelectedTab";
            this.tdBankDetail.Attributes["class"] = "NotSelectedTab";
            this.BindDuiZhangDanData(false);
            this.BindBankDetailData(false);
        }
    }


}

