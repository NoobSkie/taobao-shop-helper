using AjaxPro;
using ASP;
using DAL;
using Shove._Security;
using Shove._Web;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_UserControls_UserMyIcaile : UserControlBase
{

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public string GetBackUrl(string urls)
    {
        string s = "MyIcaile.aspx";
        return Encrypt.EncryptString(PF.GetCallCert(), s);
    }

    [AjaxMethod(HttpSessionStateRequirement.ReadWrite)]
    public string isLoginsas()
    {
        return Users.GetCurrentUser(1L).ID.ToString();
    }

    private void MenuByStatus()
    {
        Users users1 = base._User;
        DataTable table = new Tables.T_Sites().Open("Opt_Promotion_Status_ON", "", "");
        if ((table != null) && (table.Rows.Count > 0))
        {
            bool.Parse(table.Rows[0]["Opt_Promotion_Status_ON"].ToString());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_UserControls_UserMyIcaile), this.Page);
        if (!base.IsPostBack)
        {
            string request = Shove._Web.Utility.GetRequest("SubPage");
            if ((request != null) && (request != ""))
            {
                this.HidScript.Value = "mainFrame.location.href='" + request + "';";
                return;
            }
        }
        this.MenuByStatus();
        string str2 = base.Request.Url.AbsoluteUri.ToLower();
        if ((str2.Contains("http://www.caiyou.net") || str2.Contains("http://caiyou.net")) || (str2.Contains("http://www.caiyou.net.cn") || str2.Contains("http://caiyou.net.cn")))
        {
            this.divPromotion.Visible = true;
        }
    }

}

