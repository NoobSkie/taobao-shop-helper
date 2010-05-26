using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using AjaxPro;
using Shove._Web;
using Shove;
using Shove._IO;
using System.Data;

public partial class Lottery_CQSSC_Buy : LotteryBasePage
{
    protected override string LotteryCode
    {
        get { return "CQSSC"; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(this.GetType(), this.Page);
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetSysTime()
    {
        return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    }

    protected void btn_OK_Click(object sender, EventArgs e)
    {
        //if (!PF.IsSystemRegister())
        //{
        //    PF.GoError(4, "请联系网站管理员输入软件序列号", base.GetType().BaseType.FullName);
        //}
        //else
        //{
        //    this.Buy(base._User);
        //}
    }
}
