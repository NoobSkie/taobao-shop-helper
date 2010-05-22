using ASP;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_OnlinePayGateway : AdminPageBase, IRequiresSessionState
{
    private SystemOptions so = new SystemOptions();




    private void BindData()
    {
        SystemOptions options = new SystemOptions();
        this.tbAlipayName.Text = options["OnlinePay_Alipay_UserName"].ToString("");
        this.tbAlipayNumber.Text = options["OnlinePay_Alipay_UserNumber"].ToString("");
        this.tbAlipayKey.Text = options["OnlinePay_Alipay_MD5Key"].ToString("");
        this.tbAlipayPayFormalitiesFeesScale.Text = options["OnlinePay_Alipay_PayFormalitiesFeesScale"].ToString("0.00");
        this.tbAlipayOutKey.Text = options["OnlinePayOut_Alipay_MD5Key"].ToString("");
        this.tbAlipayDistillFormalitiesFeesScale.Text = options["OnlinePayOut_Alipay_DistillFormalitiesFeesScale"].ToString("0.00");
        this.cbAlipayON.Checked = options["OnlinePay_Alipay_Status_ON"].ToBoolean(false);
        this.tbOnlinePay_Alipay_ForUserDistill_UserName.Text = options["OnlinePay_Alipay_ForUserDistill_UserName"].ToString("");
        this.tbOnlinePay_Alipay_ForUserDistill_UserNumber.Text = options["OnlinePay_Alipay_ForUserDistill_UserNumber"].ToString("");
        this.tbOnlinePay_Alipay_ForUserDistill_MD5Key.Text = options["OnlinePay_Alipay_ForUserDistill_MD5Key"].ToString("");
        this.tbOnlinePay_Alipay_ForUserDistill_MD5Key_ForPayOut.Text = options["OnlinePay_Alipay_ForUserDistill_MD5Key_ForPayOut"].ToString("");
        this.cbOnlinePay_Alipay_ForUserDistill_Status_ON.Checked = options["OnlinePay_Alipay_ForUserDistill_Status_ON"].ToBoolean(false);
        this.tb99BillName.Text = options["OnlinePay_99Bill_UserName"].ToString("");
        this.tb99BillNumber.Text = options["OnlinePay_99Bill_UserNumber"].ToString("");
        this.tb99BillKey.Text = options["OnlinePay_99Bill_MD5Key"].ToString("");
        this.tb99BillPayFormalitiesFeesScale.Text = options["OnlinePay_99Bill_PayFormalitiesFeesScale"].ToString("0.00");
        this.tb99BillOutKey.Text = options["OnlinePayOut_99Bill_MD5Key"].ToString("");
        this.tb99BillQueryKey.Text = options["OnlinePay_99Bill_QueryMD5Key"].ToString("");
        this.tb99BillDistillFormalitiesFeesScale.Text = options["OnlinePayOut_99Bill_DistillFormalitiesFeesScale"].ToString("0.00");
        this.cb99BillON.Checked = options["OnlinePay_99Bill_Status_ON"].ToBoolean(false);
        this.tbTenpayName.Text = options["OnlinePay_Tenpay_UserName"].ToString("");
        this.tbTenpayNumber.Text = options["OnlinePay_Tenpay_UserNumber"].ToString("");
        this.tbTenpayKey.Text = options["OnlinePay_Tenpay_MD5Key"].ToString("");
        this.tbTenpayPayFormalitiesFeesScale.Text = options["OnlinePay_Tenpay_PayFormalitiesFeesScale"].ToString("0.00");
        this.tbTenpayOutKey.Text = options["OnlinePayOut_Tenpay_MD5Key"].ToString("");
        this.tbTenpayDistillFormalitiesFeesScale.Text = options["OnlinePayOut_Tenpay_DistillFormalitiesFeesScale"].ToString("0.00");
        this.cbTenpayON.Checked = options["OnlinePay_Tenpay_Status_ON"].ToBoolean(false);
        this.tbCBPayMentName.Text = options["OnlinePay_CBPayMent_UserName"].ToString("");
        this.tbCBPayMentNumber.Text = options["OnlinePay_CBPayMent_UserNumber"].ToString("");
        this.tbCBPayMentKey.Text = options["OnlinePay_CBPayMent_MD5Key"].ToString("");
        this.tbCBPayMentPayFormalitiesFeesScale.Text = options["OnlinePay_CBPayMent_PayFormalitiesFeesScale"].ToString("0.00");
        this.tbCBPayMentOutKey.Text = options["OnlinePayOut_CBPayMent_MD5Key"].ToString("");
        this.tbCBPayMentDistillFormalitiesFeesScale.Text = options["OnlinePayOut_CBPayMent_DistillFormalitiesFeesScale"].ToString("0.00");
        this.cbCBPayMentON.Checked = options["OnlinePay_CBPayMent_Status_ON"].ToBoolean(false);
        this.tbYeePayName.Text = options["OnlinePay_YeePay_UserName"].ToString("");
        this.tbYeePayNumber.Text = options["OnlinePay_YeePay_UserNumber"].ToString("");
        this.tbYeePayKey.Text = options["OnlinePay_YeePay_MD5Key"].ToString("");
        this.tbYeePayFormalitiesFeesScale.Text = options["OnlinePay_YeePay_PayFormalitiesFeesScale"].ToString("0.00");
        this.tbYeePayOutKey.Text = options["OnlinePayOut_YeePay_MD5Key"].ToString("");
        this.tbYeePayDistillFormalitiesFeesScale.Text = options["OnlinePayOut_YeePay_DistillFormalitiesFeesScale"].ToString("0.00");
        this.cbYeePayON.Checked = options["OnlinePay_YeePay_Status_ON"].ToBoolean(false);
        this.tb007Ka_FormalitiesFees.Text = options["OnlinePay_007Ka_FormalitiesFees"].ToString("0.00");
        this.tb007Ka_MerAccount.Text = options["OnlinePay_007Ka_MerAccount"].ToString("");
        this.tb007Ka_MerchantId.Text = options["OnlinePay_007Ka_MerchantId"].ToString("");
        this.cb007KaON.Checked = options["OnlinePay_007Ka_Status_ON"].ToBoolean(false);
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        SystemOptions options = new SystemOptions();
        try
        {
            options["OnlinePay_Alipay_UserName"] = new OptionValue(this.tbAlipayName.Text);
            options["OnlinePay_Alipay_UserNumber"] = new OptionValue(this.tbAlipayNumber.Text);
            options["OnlinePay_Alipay_MD5Key"] = new OptionValue(this.tbAlipayKey.Text);
            options["OnlinePay_Alipay_PayFormalitiesFeesScale"] = new OptionValue(_Convert.StrToDouble(this.tbAlipayPayFormalitiesFeesScale.Text, 0.0));
            options["OnlinePayOut_Alipay_MD5Key"] = new OptionValue(this.tbAlipayOutKey.Text);
            options["OnlinePayOut_Alipay_DistillFormalitiesFeesScale"] = new OptionValue(_Convert.StrToDouble(this.tbAlipayDistillFormalitiesFeesScale.Text, 0.0));
            options["OnlinePay_Alipay_Status_ON"] = new OptionValue(this.cbAlipayON.Checked);
            options["OnlinePay_Alipay_ForUserDistill_UserName"] = new OptionValue(this.tbOnlinePay_Alipay_ForUserDistill_UserName.Text);
            options["OnlinePay_Alipay_ForUserDistill_UserNumber"] = new OptionValue(this.tbOnlinePay_Alipay_ForUserDistill_UserNumber.Text);
            options["OnlinePay_Alipay_ForUserDistill_MD5Key"] = new OptionValue(this.tbOnlinePay_Alipay_ForUserDistill_MD5Key.Text);
            options["OnlinePay_Alipay_ForUserDistill_MD5Key_ForPayOut"] = new OptionValue(this.tbOnlinePay_Alipay_ForUserDistill_MD5Key_ForPayOut.Text);
            options["OnlinePay_Alipay_ForUserDistill_Status_ON"] = new OptionValue(this.cbOnlinePay_Alipay_ForUserDistill_Status_ON.Checked);
            options["OnlinePay_99Bill_UserName"] = new OptionValue(this.tb99BillName.Text);
            options["OnlinePay_99Bill_UserNumber"] = new OptionValue(this.tb99BillNumber.Text);
            options["OnlinePay_99Bill_MD5Key"] = new OptionValue(this.tb99BillKey.Text);
            options["OnlinePay_99Bill_PayFormalitiesFeesScale"] = new OptionValue(_Convert.StrToDouble(this.tb99BillPayFormalitiesFeesScale.Text, 0.0));
            options["OnlinePayOut_99Bill_MD5Key"] = new OptionValue(this.tb99BillOutKey.Text);
            options["OnlinePay_99Bill_QueryMD5Key"] = new OptionValue(this.tb99BillQueryKey.Text);
            options["OnlinePayOut_99Bill_DistillFormalitiesFeesScale"] = new OptionValue(_Convert.StrToDouble(this.tb99BillDistillFormalitiesFeesScale.Text, 0.0));
            options["OnlinePay_99Bill_Status_ON"] = new OptionValue(this.cb99BillON.Checked);
            options["OnlinePay_Tenpay_UserName"] = new OptionValue(this.tbTenpayName.Text);
            options["OnlinePay_Tenpay_UserNumber"] = new OptionValue(this.tbTenpayNumber.Text);
            options["OnlinePay_Tenpay_MD5Key"] = new OptionValue(this.tbTenpayKey.Text);
            options["OnlinePay_Tenpay_PayFormalitiesFeesScale"] = new OptionValue(_Convert.StrToDouble(this.tbTenpayPayFormalitiesFeesScale.Text, 0.0));
            options["OnlinePayOut_Tenpay_MD5Key"] = new OptionValue(this.tbTenpayOutKey.Text);
            options["OnlinePayOut_Tenpay_DistillFormalitiesFeesScale"] = new OptionValue(_Convert.StrToDouble(this.tbTenpayDistillFormalitiesFeesScale.Text, 0.0));
            options["OnlinePay_Tenpay_Status_ON"] = new OptionValue(this.cbTenpayON.Checked);
            options["OnlinePay_CBPayMent_UserName"] = new OptionValue(this.tbCBPayMentName.Text);
            options["OnlinePay_CBPayMent_UserNumber"] = new OptionValue(this.tbCBPayMentNumber.Text);
            options["OnlinePay_CBPayMent_MD5Key"] = new OptionValue(this.tbCBPayMentKey.Text);
            options["OnlinePay_CBPayMent_PayFormalitiesFeesScale"] = new OptionValue(_Convert.StrToDouble(this.tbCBPayMentPayFormalitiesFeesScale.Text, 0.0));
            options["OnlinePayOut_CBPayMent_MD5Key"] = new OptionValue(this.tbCBPayMentOutKey.Text);
            options["OnlinePayOut_CBPayMent_DistillFormalitiesFeesScale"] = new OptionValue(_Convert.StrToDouble(this.tbCBPayMentDistillFormalitiesFeesScale.Text, 0.0));
            options["OnlinePay_CBPayMent_Status_ON"] = new OptionValue(this.cbCBPayMentON.Checked);
            options["OnlinePay_YeePay_UserName"] = new OptionValue(this.tbYeePayName.Text);
            options["OnlinePay_YeePay_UserNumber"] = new OptionValue(this.tbYeePayNumber.Text);
            options["OnlinePay_YeePay_MD5Key"] = new OptionValue(this.tbYeePayKey.Text);
            options["OnlinePay_YeePayy_PayFormalitiesFeesScale"] = new OptionValue(_Convert.StrToDouble(this.tbYeePayFormalitiesFeesScale.Text, 0.0));
            options["OnlinePayOut_YeePay_MD5Key"] = new OptionValue(this.tbYeePayOutKey.Text);
            options["OnlinePayOut_YeePay_DistillFormalitiesFeesScale"] = new OptionValue(_Convert.StrToDouble(this.tbYeePayDistillFormalitiesFeesScale.Text, 0.0));
            options["OnlinePay_YeePay_Status_ON"] = new OptionValue(this.cbYeePayON.Checked);
            options["OnlinePay_007Ka_FormalitiesFees"] = new OptionValue(this.tb007Ka_FormalitiesFees.Text);
            options["OnlinePay_007Ka_MerAccount"] = new OptionValue(this.tb007Ka_MerAccount.Text);
            options["OnlinePay_007Ka_MerchantId"] = new OptionValue(this.tb007Ka_MerchantId.Text);
            options["OnlinePay_007Ka_Status_ON"] = new OptionValue(this.cb007KaON.Checked);
        }
        catch (Exception exception)
        {
            PF.GoError(1, exception.Message, "Admin_OnlinePayGateway");
            return;
        }
        JavaScript.Alert(this.Page, "设置保存成功。");
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Options", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            this.btnOK.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "Options" }));
        }
        this.tbAlipayKey.Attributes.Add("value", this.tbAlipayKey.Text);
        this.tbAlipayOutKey.Attributes.Add("value", this.tbAlipayOutKey.Text);
        this.tbOnlinePay_Alipay_ForUserDistill_MD5Key.Attributes.Add("value", this.tbOnlinePay_Alipay_ForUserDistill_MD5Key.Text);
        this.tbOnlinePay_Alipay_ForUserDistill_MD5Key_ForPayOut.Attributes.Add("value", this.tbOnlinePay_Alipay_ForUserDistill_MD5Key_ForPayOut.Text);
        this.tb99BillKey.Attributes.Add("value", this.tb99BillKey.Text);
        this.tb99BillOutKey.Attributes.Add("value", this.tb99BillOutKey.Text);
        this.tb99BillQueryKey.Attributes.Add("value", this.tb99BillQueryKey.Text);
        this.tbTenpayKey.Attributes.Add("value", this.tbTenpayKey.Text);
        this.tbTenpayOutKey.Attributes.Add("value", this.tbTenpayOutKey.Text);
        this.tbCBPayMentKey.Attributes.Add("value", this.tbCBPayMentKey.Text);
        this.tbCBPayMentOutKey.Attributes.Add("value", this.tbCBPayMentOutKey.Text);
        this.tbYeePayKey.Attributes.Add("value", this.tbYeePayKey.Text);
        this.tbYeePayKey.Attributes.Add("value", this.tbYeePayKey.Text);
    }
}

