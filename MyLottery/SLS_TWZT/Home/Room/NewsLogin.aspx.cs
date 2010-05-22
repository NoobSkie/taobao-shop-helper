using ASP;
using DAL;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_NewsLogin : SitePageBase, IRequiresSessionState
{

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string returnDescription = "";
        if (new Login().LoginSubmit(this.Page, base._Site, this.tbUserName.Text, this.tbUserPassword.Text, this.tbCheckCode.Text, this.ShoveCheckCode1, ref returnDescription) < 0)
        {
            JavaScript.Alert(this.Page, returnDescription);
        }
        else
        {
            base.Response.Write("<script>window.top.location.href='AccountDetail.aspx';</script>");
            base.Response.End();
        }
    }

    protected void imgbtnLogout_Click(object sender, EventArgs e)
    {
        if (base._User != null)
        {
            string returnDescription = "";
            base._User.Logout(ref returnDescription);
        }
        base.Response.Redirect(base.Request.Url.AbsoluteUri);
    }

    private void InitLayOut()
    {
        this.tdRoom.Height = "25px";
        this.tdRoom.Attributes.Add("class", "white_a");
        this.aroom.HRef = "../../Default.aspx";
        this.aroom.Target = "_blank";
        this.tdAccount.Height = "25px";
        this.tdAccount.Attributes.Add("class", "white_a");
        this.aAccount.HRef = "MyIcaile.aspx?SubPage=AccountDetail.aspx";
        this.aAccount.Target = "_blank";
        this.tdUserInfo.Height = "25px";
        this.tdUserInfo.Attributes.Add("class", "white_a");
        this.aUserInfo.HRef = "MyIcaile.aspx?SubPage=UserEdit.aspx";
        this.aUserInfo.Target = "_blank";
        this.tdtouzhu.Height = "25px";
        this.tdtouzhu.Attributes.Add("class", "white_a");
        this.atouzhu.HRef = "MyIcaile.aspx?SubPage=InvestHistory.aspx";
        this.atouzhu.Target = "_blank";
        this.tdAdmin.Height = "25px";
        this.tdAdmin.Attributes.Add("class", "white_a");
        this.hlAdmin.NavigateUrl = "../../Admin/Default.aspx";
        this.hlAdmin.Target = "_blank";
        this.tdPro.Height = "25px";
        this.tdPro.Attributes.Add("class", "white_a");
        this.hlCps.NavigateUrl = "../../Cps/Default.aspx";
        this.hlCps.Target = "_blank";
        this.tdOut.Height = "30px";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        bool flag = base._Site.SiteOptions["Opt_isUseCheckCode"].ToBoolean(true);
        this.InitLayOut();
        if (base._User == null)
        {
            this.NoLogin.Visible = true;
            this.Longining.Visible = false;
            this.CheckCode.Visible = flag;
            new Login().SetCheckCode(base._Site, this.ShoveCheckCode1);
            goto Label_01EC;
        }
        this.NoLogin.Visible = false;
        this.Longining.Visible = true;
        this.lbUserName.Text = base._User.Name + ",您好!";
        if (base._User.Competences.CompetencesList != "")
        {
            this.lbUserType.Text = "级别:管理员";
        }
        else if (base._User.OwnerSites != "")
        {
            this.lbUserType.Text = "级别:代理商";
        }
        else
        {
            switch (base._User.UserType)
            {
                case 1:
                    this.lbUserType.Text = "级别:普通";
                    goto Label_0127;

                case 2:
                    this.lbUserType.Text = "级别:高级";
                    goto Label_0127;

                case 3:
                    this.lbUserType.Text = "级别:VIP";
                    goto Label_0127;
            }
        }
    Label_0127:
        if (Functions.F_GetExpertsLotteryList(base._Site.ID, base._User.ID) != "")
        {
            this.lbUserType.Text = this.lbUserType.Text + "(专家)";
        }
        this.hlCps.Visible = base._User.CpsID > 0L;
        this.hlAdmin.Visible = base._User.Competences.CompetencesList != "";
    Label_01EC:
        this.tbUserName.Attributes.Add("onkeypress", "if (window.event.keyCode == 13) {" + this.tbUserPassword.UniqueID.Replace(':', '_') + ".focus();}");
        if (flag)
        {
            this.tbUserPassword.Attributes.Add("onkeypress", "if (window.event.keyCode == 13) {" + this.tbCheckCode.UniqueID.Replace(':', '_') + ".focus();}");
            this.tbCheckCode.Attributes.Add("onkeypress", "if (window.event.keyCode == 13) {__doPostBack('" + this.btnLogin.UniqueID + "','');}");
            this.tbCheckCode.Attributes.Add("onKeydown", "if(event.keyCode   ==   13){document.getElementById('" + this.btnLogin.UniqueID + "').click();return   false;}");
        }
        else
        {
            this.tbUserPassword.Attributes.Add("onkeypress", "if (window.event.keyCode == 13) {__doPostBack('" + this.btnLogin.UniqueID + "','');}");
        }
        if (base._User != null)
        {
            if (base._User.isAlipayNameValided)
            {
                this.lbAlipay.Text = "您的支付宝账号已通过验证!";
                this.hyReg.Visible = false;
                this.lbAlipay.Visible = true;
            }
            else
            {
                this.lbAlipay.Text = "您的支付宝账号还未验证通过!";
                this.hyReg.Visible = true;
                this.lbAlipay.Visible = true;
            }
        }
    }
}

