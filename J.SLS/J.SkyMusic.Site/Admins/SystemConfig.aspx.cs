using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class Admins_SystemConfig : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ParamFacade facade = new ParamFacade();
            ParamInfo paraSiteName = facade.GetParam("SiteName");
            if (paraSiteName != null)
            {
                txtSiteName.Text = paraSiteName.Value;
            }
            ParamInfo paraLogoFileName = facade.GetParam("LogoFileName");
            if (paraLogoFileName != null)
            {
                txtLogoFileName.Text = paraLogoFileName.Value;
            }
            ParamInfo paraAddress = facade.GetParam("Address");
            if (paraAddress != null)
            {
                txtAddress.Text = paraAddress.Value;
            }
            ParamInfo paraPhoneNumber = facade.GetParam("PhoneNumber");
            if (paraPhoneNumber != null)
            {
                txtPhone.Text = paraPhoneNumber.Value;
            }
            ParamInfo paraFaxNumber = facade.GetParam("FaxNumber");
            if (paraFaxNumber != null)
            {
                txtFax.Text = paraFaxNumber.Value;
            }
            ParamInfo paraQQNumber = facade.GetParam("QQNumber");
            if (paraQQNumber != null)
            {
                txtQQ.Text = paraQQNumber.Value;
            }
            ParamInfo paraNoticeDelay = facade.GetParam("NoticeDelay");
            if (paraNoticeDelay != null)
            {
                txtDelay.Text = paraNoticeDelay.Value;
            }
            ParamInfo paraAutoPlayMusic = facade.GetParam("AutoPlayMusic");
            if (paraAutoPlayMusic != null)
            {
                cbAutoMusic.Checked = paraAutoPlayMusic.Value == "1";
            }
        }
    }

    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ParamFacade facade = new ParamFacade();
            ParamInfo paraInfo = new ParamInfo();

            paraInfo.Key = "SiteName";
            paraInfo.Value = txtSiteName.Text;
            facade.SaveParam(paraInfo);
            Application["SiteName"] = null;

            paraInfo.Key = "LogoFileName";
            paraInfo.Value = txtLogoFileName.Text;
            facade.SaveParam(paraInfo);
            Application["LogoFileName"] = null;

            paraInfo.Key = "Address";
            paraInfo.Value = txtAddress.Text;
            facade.SaveParam(paraInfo);
            Application["Address"] = null;

            paraInfo.Key = "PhoneNumber";
            paraInfo.Value = txtPhone.Text;
            facade.SaveParam(paraInfo);
            Application["PhoneNumber"] = null;

            paraInfo.Key = "FaxNumber";
            paraInfo.Value = txtFax.Text;
            facade.SaveParam(paraInfo);
            Application["FaxNumber"] = null;

            paraInfo.Key = "QQNumber";
            paraInfo.Value = txtQQ.Text;
            facade.SaveParam(paraInfo);
            Application["QQNumber"] = null;

            paraInfo.Key = "NoticeDelay";
            paraInfo.Value = txtDelay.Text;
            facade.SaveParam(paraInfo);
            Application["NoticeDelay"] = null;

            paraInfo.Key = "AutoPlayMusic";
            paraInfo.Value = cbAutoMusic.Checked ? "1" : "0";
            facade.SaveParam(paraInfo);
            Application["AutoPlayMusic"] = null;

            JavascriptAlertAndRedirectAndRefreshParent("保存系统参数成功！", Request.Url.AbsoluteUri);
        }
        catch (Exception ex)
        {
            JavascriptAlert(ex.Message);
        }
    }
}
