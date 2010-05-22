using ASP;
using Shove;
using Shove._Web;
using Shove.Database;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Home_Room_SSQ_WinNotice : Page, IRequiresSessionState
{
    public int width;

    private void GetWinNotice()
    {
        string key = "GetWinNoticeByID5";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        StringBuilder builder = new StringBuilder();
        if (cacheAsDataTable == null)
        {
            builder.AppendLine("select a.ID, WinMoney,b.Name as LotteryName,b.Name as PlayTypeName,c.Name as InitiateName from                            \r\n(select top 12 ID,InitiateUserID,PlayTypeID,WinMoney\r\nfrom T_Schemes a where WinMoney >0 and PlayTypeID in(select ID from T_PlayTypes b where LotteryID = 5) order by ID desc)a\r\ninner join T_PlayTypes b on a.PlayTypeID = b.ID inner join T_Users c on a.InitiateUserID = b.ID");
            cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据读写错错误", base.GetType().BaseType.FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x708);
        }
        builder = new StringBuilder();
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            builder.Append("&nbsp;&nbsp;&nbsp;<a target=\"_blank\" href=\"Scheme.aspx?id=").Append(row["ID"].ToString()).Append("\">").Append("<span class=\"hui12\">").Append("恭喜<span class =\"red12_2\">").Append(_String.Cut(row["InitiateName"].ToString(), 4)).Append("</span>&nbsp;喜中").Append("&nbsp;" + row["PlayTypeName"].ToString()).Append("&nbsp</span><span class =\"red12_2\">").Append(_Convert.StrToDouble(row["WinMoney"].ToString(), 0.0).ToString("N")).Append("&nbsp</span><span class=\"hui12\">元</span></a>");
        }
        if (builder.ToString() == "")
        {
            builder.Append("<span class=\"hui12\">暂无中奖信息</span>");
        }
        this.width = builder.Length * 2;
        this.divWinNotice.InnerHtml = builder.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.GetWinNotice();
        }
    }
}

