using ASP;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Options : AdminPageBase, IRequiresSessionState
{
    private void BindData()
    {
        this.tbForumUrl.Text = base._Site.SiteOptions["Opt_ForumUrl"].ToString("");
        ControlExt.SetDownListBoxTextFromValue(this.ddlMobileCheckCharset, base._Site.SiteOptions["Opt_MobileCheckCharset"].ToString(""));
        this.tbMobileCheckStringLength.Text = base._Site.SiteOptions["Opt_MobileCheckStringLength"].ToString("");
        ControlExt.SetDownListBoxTextFromValue(this.ddlSMSPayType, base._Site.SiteOptions["Opt_SMSPayType"].ToString(""));
        this.tbSMSPrice.Text = base._Site.SiteOptions["Opt_SMSPrice"].ToString("");
        ControlExt.SetDownListBoxTextFromValue(this.ddlCheckCodeCharset, base._Site.SiteOptions["Opt_CheckCodeCharset"].ToString(""));
        this.cbisUseCheckCode.Checked = base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
        this.cbisWriteLog.Checked = base._Site.SiteOptions["Opt_isWriteLog"].ToBoolean(true);
        this.tbInitiateSchemeLimitLowerScaleMoney.Text = base._Site.SiteOptions["Opt_InitiateSchemeLimitLowerScaleMoney"].ToString("");
        this.tbInitiateSchemeLimitLowerScale.Text = base._Site.SiteOptions["Opt_InitiateSchemeLimitLowerScale"].ToString("");
        this.tbInitiateSchemeLimitUpperScaleMoney.Text = base._Site.SiteOptions["Opt_InitiateSchemeLimitUpperScaleMoney"].ToString("");
        this.tbInitiateSchemeLimitUpperScale.Text = base._Site.SiteOptions["Opt_InitiateSchemeLimitUpperScale"].ToString("");
        this.tbInitiateSchemeBonusScale.Text = base._Site.SiteOptions["Opt_InitiateSchemeBonusScale"].ToString("");
        this.tbInitiateSchemeMinBuyScale.Text = base._Site.SiteOptions["Opt_InitiateSchemeMinBuyScale"].ToString("");
        this.tbInitiateSchemeMinBuyAndAssureScale.Text = base._Site.SiteOptions["Opt_InitiateSchemeMinBuyAndAssureScale"].ToString("");
        this.tbInitiateSchemeMaxNum.Text = base._Site.SiteOptions["Opt_InitiateSchemeMaxNum"].ToString("");
        this.tbInitiateFollowSchemeMaxNum.Text = base._Site.SiteOptions["Opt_InitiateFollowSchemeMaxNum"].ToString("");
        this.tbQuashSchemeMaxNum.Text = base._Site.SiteOptions["Opt_QuashSchemeMaxNum"].ToString("");
        this.cbFullSchemeCanQuash.Checked = base._Site.SiteOptions["Opt_FullSchemeCanQuash"].ToBoolean(true);
        this.tbSchemeMinMoney.Text = base._Site.SiteOptions["Opt_SchemeMinMoney"].ToString("");
        this.tbSchemeMaxMoney.Text = base._Site.SiteOptions["Opt_SchemeMaxMoney"].ToString("");
        this.tbFirstPageUnionBuyMaxRows.Text = base._Site.SiteOptions["Opt_FirstPageUnionBuyMaxRows"].ToString("");
        this.cbisFirstPageUnionBuyWithAll.Checked = base._Site.SiteOptions["Opt_isFirstPageUnionBuyWithAll"].ToBoolean(true);
        this.tbMaxShowLotteryNumberRows.Text = base._Site.SiteOptions["Opt_MaxShowLotteryNumberRows"].ToString("");
        this.tbLotteryCountOfMenuBarRow.Text = base._Site.SiteOptions["Opt_LotteryCountOfMenuBarRow"].ToString("");
        this.cbisBuyValidPasswordAdv.Checked = base._Site.SiteOptions["Opt_isBuyValidPasswordAdv"].ToBoolean(true);
        this.tbScoringOfSelfBuy.Text = base._Site.SiteOptions["Opt_ScoringOfSelfBuy"].ToString("");
        this.tbScoringOfCommendBuy.Text = base._Site.SiteOptions["Opt_ScoringOfCommendBuy"].ToString("");
        this.tbScoringExchangeRate.Text = base._Site.SiteOptions["Opt_ScoringExchangeRate"].ToString("");
        this.cbScoring_Status_ON.Checked = base._Site.SiteOptions["Opt_Scoring_Status_ON"].ToBoolean(true);
        this.tbSchemeChatRoom_StopChatDaysAfterOpened.Text = base._Site.SiteOptions["Opt_SchemeChatRoom_StopChatDaysAfterOpened"].ToString("");
        this.tbSchemeChatRoom_MaxChatNumberOf.Text = base._Site.SiteOptions["Opt_SchemeChatRoom_MaxChatNumberOf"].ToString("");
        this.tbPromotionMemberBonusScale.Text = base._Site.SiteOptions["Opt_PromotionMemberBonusScale"].ToString("");
        this.tbPromotionSiteBonusScale.Text = base._Site.SiteOptions["Opt_PromotionSiteBonusScale"].ToString("");
        this.cbCps_Status_ON.Checked = base._Site.SiteOptions["Opt_Cps_Status_ON"].ToBoolean(true);
        this.cbPromotion_Status_ON.Checked = base._Site.SiteOptions["Opt_Promotion_Status_ON"].ToBoolean(true);
        this.tbCpsBonusScale.Text = base._Site.SiteOptions["Opt_CpsBonusScale"].ToString("");
        this.tbPageTitle.Text = base._Site.SiteOptions["Opt_PageTitle"].ToString("");
        this.tbPageKeywords.Text = base._Site.SiteOptions["Opt_PageKeywords"].ToString("");
        this.cbisShowFloatAD.Checked = base._Site.SiteOptions["Opt_isShowFloatAD"].ToBoolean(true);
        this.cbMemberSharing_Alipay_Status_ON.Checked = base._Site.SiteOptions["Opt_MemberSharing_Alipay_Status_ON"].ToBoolean(true);
        this.tbBettingStationName.Text = base._Site.SiteOptions["Opt_BettingStationName"].ToString("");
        this.tbBettingStationNumber.Text = base._Site.SiteOptions["Opt_BettingStationNumber"].ToString("");
        this.tbBettingStationAddress.Text = base._Site.SiteOptions["Opt_BettingStationAddress"].ToString("");
        this.tbBettingStationTelephone.Text = base._Site.SiteOptions["Opt_BettingStationTelephone"].ToString("");
        this.tbBettingStationContactPreson.Text = base._Site.SiteOptions["Opt_BettingStationContactPreson"].ToString("");
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if ((_Convert.StrToDouble(this.tbInitiateSchemeBonusScale.Text, 0.0) > 1.0) || (_Convert.StrToDouble(this.tbInitiateSchemeBonusScale.Text, 0.0) < 0.0))
        {
            JavaScript.Alert(this.Page, "方案制作佣金设置有错误，设置范围是( 0 - 1 ) 例如 0.03　！");
        }
        else if ((_Convert.StrToDouble(this.tbPromotionMemberBonusScale.Text, 0.0) > 1.0) || (_Convert.StrToDouble(this.tbPromotionMemberBonusScale.Text, 0.0) < 0.0))
        {
            JavaScript.Alert(this.Page, "推广会员佣金设置有错误，设置范围是( 0 - 1 ) 例如 0.03　！");
        }
        else if ((_Convert.StrToDouble(this.tbPromotionSiteBonusScale.Text, 0.0) > 1.0) || (_Convert.StrToDouble(this.tbPromotionSiteBonusScale.Text, 0.0) < 0.0))
        {
            JavaScript.Alert(this.Page, "推广站长佣金设置有错误，设置范围是( 0 - 1 ) 例如 0.03　！");
        }
        else if ((_Convert.StrToDouble(this.tbCpsBonusScale.Text, 0.0) > 1.0) || (_Convert.StrToDouble(this.tbCpsBonusScale.Text, 0.0) < 0.0))
        {
            JavaScript.Alert(this.Page, "联盟推广佣金比例设置有错误，设置范围是( 0 - 1 ) 例如 0.03　！");
        }
        else
        {
            try
            {
                base._Site.SiteOptions["Opt_ForumUrl"] = new OptionValue(this.tbForumUrl.Text.Trim());
                base._Site.SiteOptions["Opt_MobileCheckCharset"] = new OptionValue(this.ddlMobileCheckCharset.SelectedValue);
                base._Site.SiteOptions["Opt_MobileCheckStringLength"] = new OptionValue(_Convert.StrToShort(this.tbMobileCheckStringLength.Text, 6));
                base._Site.SiteOptions["Opt_SMSPayType"] = new OptionValue(this.ddlSMSPayType.SelectedValue);
                base._Site.SiteOptions["Opt_SMSPrice"] = new OptionValue(_Convert.StrToDouble(this.tbSMSPrice.Text, 0.0));
                base._Site.SiteOptions["Opt_CheckCodeCharset"] = new OptionValue(this.ddlCheckCodeCharset.SelectedValue);
                base._Site.SiteOptions["Opt_isUseCheckCode"] = new OptionValue(this.cbisUseCheckCode.Checked);
                base._Site.SiteOptions["Opt_isWriteLog"] = new OptionValue(this.cbisWriteLog.Checked);
                base._Site.SiteOptions["Opt_InitiateSchemeLimitLowerScaleMoney"] = new OptionValue(_Convert.StrToDouble(this.tbInitiateSchemeLimitLowerScaleMoney.Text, 0.0));
                base._Site.SiteOptions["Opt_InitiateSchemeLimitLowerScale"] = new OptionValue(_Convert.StrToDouble(this.tbInitiateSchemeLimitLowerScale.Text, 0.0));
                base._Site.SiteOptions["Opt_InitiateSchemeLimitUpperScaleMoney"] = new OptionValue(_Convert.StrToDouble(this.tbInitiateSchemeLimitUpperScaleMoney.Text, 0.0));
                base._Site.SiteOptions["Opt_InitiateSchemeLimitUpperScale"] = new OptionValue(_Convert.StrToDouble(this.tbInitiateSchemeLimitUpperScale.Text, 0.0));
                base._Site.SiteOptions["Opt_InitiateSchemeBonusScale"] = new OptionValue(_Convert.StrToDouble(this.tbInitiateSchemeBonusScale.Text, 0.0));
                base._Site.SiteOptions["Opt_InitiateSchemeMinBuyScale"] = new OptionValue(_Convert.StrToDouble(this.tbInitiateSchemeMinBuyScale.Text, 0.0));
                base._Site.SiteOptions["Opt_InitiateSchemeMinBuyAndAssureScale"] = new OptionValue(_Convert.StrToDouble(this.tbInitiateSchemeMinBuyAndAssureScale.Text, 0.0));
                base._Site.SiteOptions["Opt_InitiateSchemeMaxNum"] = new OptionValue(_Convert.StrToShort(this.tbInitiateSchemeMaxNum.Text, 0x3e8));
                base._Site.SiteOptions["Opt_InitiateFollowSchemeMaxNum"] = new OptionValue(_Convert.StrToShort(this.tbInitiateFollowSchemeMaxNum.Text, 1));
                base._Site.SiteOptions["Opt_QuashSchemeMaxNum"] = new OptionValue(_Convert.StrToShort(this.tbQuashSchemeMaxNum.Text, 3));
                base._Site.SiteOptions["Opt_FullSchemeCanQuash"] = new OptionValue(this.cbFullSchemeCanQuash.Checked);
                base._Site.SiteOptions["Opt_SchemeMinMoney"] = new OptionValue(_Convert.StrToDouble(this.tbSchemeMinMoney.Text, 2.0));
                base._Site.SiteOptions["Opt_SchemeMaxMoney"] = new OptionValue(_Convert.StrToDouble(this.tbSchemeMaxMoney.Text, 300000.0));
                base._Site.SiteOptions["Opt_FirstPageUnionBuyMaxRows"] = new OptionValue(_Convert.StrToShort(this.tbFirstPageUnionBuyMaxRows.Text, 10));
                base._Site.SiteOptions["Opt_isFirstPageUnionBuyWithAll"] = new OptionValue(this.cbisFirstPageUnionBuyWithAll.Checked);
                base._Site.SiteOptions["Opt_MaxShowLotteryNumberRows"] = new OptionValue(_Convert.StrToShort(this.tbMaxShowLotteryNumberRows.Text, 5));
                base._Site.SiteOptions["Opt_LotteryCountOfMenuBarRow"] = new OptionValue(_Convert.StrToShort(this.tbLotteryCountOfMenuBarRow.Text, 8));
                base._Site.SiteOptions["Opt_isBuyValidPasswordAdv"] = new OptionValue(this.cbisBuyValidPasswordAdv.Checked);
                base._Site.SiteOptions["Opt_ScoringOfSelfBuy"] = new OptionValue(_Convert.StrToDouble(this.tbScoringOfSelfBuy.Text, 0.0));
                base._Site.SiteOptions["Opt_ScoringOfCommendBuy"] = new OptionValue(_Convert.StrToDouble(this.tbScoringOfCommendBuy.Text, 0.0));
                base._Site.SiteOptions["Opt_ScoringExchangeRate"] = new OptionValue(_Convert.StrToDouble(this.tbScoringExchangeRate.Text, 100.0));
                base._Site.SiteOptions["Opt_Scoring_Status_ON"] = new OptionValue(this.cbScoring_Status_ON.Checked);
                base._Site.SiteOptions["Opt_SchemeChatRoom_StopChatDaysAfterOpened"] = new OptionValue(_Convert.StrToShort(this.tbSchemeChatRoom_StopChatDaysAfterOpened.Text, 0));
                base._Site.SiteOptions["Opt_SchemeChatRoom_MaxChatNumberOf"] = new OptionValue(_Convert.StrToShort(this.tbSchemeChatRoom_MaxChatNumberOf.Text, 200));
                base._Site.SiteOptions["Opt_PromotionMemberBonusScale"] = new OptionValue(_Convert.StrToDouble(this.tbPromotionMemberBonusScale.Text, 0.0));
                base._Site.SiteOptions["Opt_PromotionSiteBonusScale"] = new OptionValue(_Convert.StrToDouble(this.tbPromotionSiteBonusScale.Text, 0.0));
                base._Site.SiteOptions["Opt_Cps_Status_ON"] = new OptionValue(this.cbCps_Status_ON.Checked);
                base._Site.SiteOptions["Opt_Promotion_Status_ON"] = new OptionValue(this.cbPromotion_Status_ON.Checked);
                base._Site.SiteOptions["Opt_CpsBonusScale"] = new OptionValue(_Convert.StrToDouble(this.tbCpsBonusScale.Text, 0.0));
                base._Site.SiteOptions["Opt_PageTitle"] = new OptionValue(this.tbPageTitle.Text);
                base._Site.SiteOptions["Opt_PageKeywords"] = new OptionValue(this.tbPageKeywords.Text);
                base._Site.SiteOptions["Opt_isShowFloatAD"] = new OptionValue(this.cbisShowFloatAD.Checked);
                base._Site.SiteOptions["Opt_MemberSharing_Alipay_Status_ON"] = new OptionValue(this.cbMemberSharing_Alipay_Status_ON.Checked);
                base._Site.SiteOptions["Opt_BettingStationName"] = new OptionValue(this.tbBettingStationName.Text);
                base._Site.SiteOptions["Opt_BettingStationNumber"] = new OptionValue(this.tbBettingStationNumber.Text);
                base._Site.SiteOptions["Opt_BettingStationAddress"] = new OptionValue(this.tbBettingStationAddress.Text);
                base._Site.SiteOptions["Opt_BettingStationTelephone"] = new OptionValue(this.tbBettingStationTelephone.Text);
                base._Site.SiteOptions["Opt_BettingStationContactPreson"] = new OptionValue(this.tbBettingStationContactPreson.Text);
            }
            catch (Exception exception)
            {
                PF.GoError(1, exception.Message, base.GetType().BaseType.FullName);
                return;
            }
            JavaScript.Alert(this.Page, "系统参数已经保存成功。");
        }
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
    }


}

