using ASP;
using System;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_UserMobileBind : RoomPageBase, IRequiresSessionState
{
    private void BindData()
    {
        this.labName.Text = base._User.Name;
        this.labUserType.Text = (base._User.UserType == 1) ? "普通用户" : ((base._User.UserType == 3) ? "VIP" : "高级用户");
        this.labLevel.Text = base._User.Level.ToString();
        if (base._User.RealityName != "")
        {
            this.tbRealityName.Text = "*".PadLeft(base._User.RealityName.Length - 1, '*') + base._User.RealityName.Substring(base._User.RealityName.Length - 1);
        }
        else
        {
            this.tbRealityName.Text = "";
        }
        try
        {
            if (base._User.isMobileValided)
            {
                this.tbMobile.Text = base._User.Mobile.Substring(0, 3) + "*****" + base._User.Mobile.Substring(8, 3);
            }
            else
            {
                this.tbMobile.Text = "";
            }
        }
        catch
        {
            this.tbMobile.Text = "";
        }
        this.labIsMobileVailded.Text = base._User.isMobileValided ? "<font color='red'>已绑定成功</font>" : "未绑定";
        this.btnBind.Enabled = !base._User.isMobileValided;
        this.btnReBind.Enabled = base._User.isMobileValided;
    }

    protected void btnBind_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("MobileReg.aspx", true);
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
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

