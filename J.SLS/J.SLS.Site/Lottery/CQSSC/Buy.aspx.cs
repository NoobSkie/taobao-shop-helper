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
using J.SLS.Facade;
using Shove._Security;

public partial class Lottery_CQSSC_Buy : LotteryBasePage
{
    protected override string LotteryCode
    {
        get { return "CQSSC"; }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    protected override void OnPreInit(EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(this.GetType());
        base.OnPreInit(e);
    }

    protected override void OnPreLoad(EventArgs e)
    {
        base.OnPreLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    #region 客户端AJAX调用

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetSysTime()
    {
        CommonFacade facade = new CommonFacade();
        return facade.GetCurrentTime().ToString("yyyy/MM/dd HH:mm:ss");
    }

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetIsuseInfo(int lotteryId)
    {
        try
        {
            IsuseInfo isuseInfo = lotteryFacade.GetCurrentIsuse(lotteryId);
            if (isuseInfo == null)
            {
                return "";
            }
            int num = isuseInfo.Id;
            string str3 = isuseInfo.Name;
            int num2 = DataCache.LotteryEndAheadMinute[lotteryId];
            string str4 = isuseInfo.EndTime.AddMinutes((double)(num2 * -1)).ToString("yyyy/MM/dd HH:mm:ss");
            StringBuilder builder = new StringBuilder();
            builder.Append(num.ToString()).Append(",").Append(str3).Append(",").Append(str4).Append("|").Append(this.GetIsuseChase(lotteryId));
            return builder.ToString();
        }
        catch (Exception ex)
        {
            LogWriter.Write(GetType().FullName, "Get Isuse Info", ex);
            return "";
        }
    }

    private string GetIsuseChase(int lotteryId)
    {
        try
        {
            int num = DataCache.LotteryEndAheadMinute[lotteryId];
            IList<IsuseInfo> isuseList = lotteryFacade.GetChaseIsuseList(lotteryId, num);
            if (isuseList.Count == 0)
            {
                return "";
            }
            StringBuilder builder = new StringBuilder();
            int num2 = 0;
            builder.Append("<table cellpadding='0' cellspacing='1' style='width: 100%; text-align: center; background-color: #E2EAED;'><tbody style='background-color: White;'>");
            foreach (IsuseInfo isuseInfo in isuseList)
            {
                num2++;
                builder.Append("<tr>")
                    .Append("<td style='width: 10%;'>")
                    .Append("<input id='check")
                    .Append(isuseInfo.Id)
                    .Append("' type='checkbox' name='check")
                    .Append(isuseInfo.Id)
                    .Append("' onclick='check(this);' value='")
                    .Append(isuseInfo.Id)
                    .Append("'/>")
                    .Append("</td>")
                    .Append("<td style='width: 20%;'>")
                    .Append("<span>")
                    .Append(isuseInfo.Name)
                    .Append("</span>")
                    .Append("<span>")
                    .Append((num2 == 1) ? "<font color='red'>[本期]</font>" : ((num2 == 2) ? "<font color='red'>[下期]</font>" : ""))
                    .Append("</span>")
                    .Append("</td>")
                    .Append("<td style='width: 13%;'>")
                    .Append("<input name='times")
                    .Append(isuseInfo.Id)
                    .Append("' type='text' value='1' id='times")
                    .Append(isuseInfo.Id)
                    .Append("' class='TextBox' onchange='onTextChange(this);' onkeypress='return InputMask_Number();' disabled='disabled' onblur='CheckMultiple2(this);' style='width: 30px;' />倍")
                    .Append("</td>")
                    .Append("<td style='width: 14%;'>")
                    .Append("<input name='money")
                    .Append(isuseInfo.Id)
                    .Append("' type='text' value='0' id='money")
                    .Append(isuseInfo.Id)
                    .Append("' class='TextBox' disabled='disabled' style='width: 35px;' />元")
                    .Append("</td>")
                    .Append("<td style='width: 12%;'>")
                    .Append("<input name='share")
                    .Append(isuseInfo.Id)
                    .Append("' type='text' value='1' id='share")
                    .Append(isuseInfo.Id)
                    .Append("' class='TextBox'  onkeypress='return InputMask_Number();' disabled='disabled'  style='width: 30px;' onblur='CheckShare2(1,this);'/>份")
                    .Append("</td>")
                    .Append("<td style='width: 13%;'>")
                    .Append("<input name='buyedShare")
                    .Append(isuseInfo.Id)
                    .Append("' type='text' value='1' id='buyedShare")
                    .Append(isuseInfo.Id)
                    .Append("' class='TextBox'  onkeypress='return InputMask_Number();' disabled='disabled' onblur='CheckShare2(2,this);'  style='width: 35px;' />份")
                    .Append("</td>")
                    .Append("<td style='width: 15%;'>")
                    .Append("<input name='assureShare")
                    .Append(isuseInfo.Id)
                    .Append("' type='text' value='0' id='assureShare")
                    .Append(isuseInfo.Id)
                    .Append("' class='TextBox'  onkeypress='return InputMask_Number();' onblur='CheckShare2(3,this);' disabled='disabled'  style='width: 35px;' />份")
                    .Append("</td>")
                    .Append("</tr>");
            }
            builder.Append("</tbody></table>");
            return builder.ToString();
        }
        catch (Exception ex)
        {
            LogWriter.Write(GetType().FullName, "AlipayTask Running Error", ex);
            return "";
        }
    }

    #endregion

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
