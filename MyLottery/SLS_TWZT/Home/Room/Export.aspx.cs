using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_Export : RoomPageBase, IRequiresSessionState
{

    [AjaxMethod(HttpSessionStateRequirement.None)]
    public string GetData(int LotteryID)
    {
        string key = "Home_Room_Export";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        cacheAsDataTable = null;
        StringBuilder builder = new StringBuilder();
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Isuses().Open("top 1000 Name, WinLotteryNumber, EndTime ", "LotteryID=" + LotteryID + " and IsOpened = 1 and IsNull(WinLotteryNumber,'')<>''", "EndTime Desc");
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return null;
            }
            cacheAsDataTable.Columns.Add("TempID", typeof(int));
            for (int i = 0; i < cacheAsDataTable.Rows.Count; i++)
            {
                cacheAsDataTable.Rows[i]["TempID"] = i + 1;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
        }
        builder.AppendLine("<table width=\"400\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" bgcolor=\"#DDDDDD\">");
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            builder.AppendLine("<tr >").AppendLine("<td  align=\"center\" bgcolor=\"#FFFFFF\" class=\"blue12\">").AppendLine(row["TempID"].ToString()).AppendLine("</td>").AppendLine("<td align=\"center\" bgcolor=\"#FFFFFF\"  class=\"blue12\">").AppendLine(row["Name"].ToString()).AppendLine("</td>").AppendLine("<td  align=\"center\" bgcolor=\"#FFFFFF\"  class=\"hui12\">").AppendLine(row["WinLotteryNumber"].ToString()).AppendLine("</td>").AppendLine("</tr>");
        }
        builder.AppendLine("</table>");
        return builder.ToString();
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isRequestLogin = false;
        base.isAtFramePageLogin = false;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_Export), this.Page);
        this.LotteryID.Value = Shove._Web.Utility.GetRequest("LotteryID");
        int lotteryID = _Convert.StrToInt(this.LotteryID.Value, 1);
        this.GetData(lotteryID);
    }
}

