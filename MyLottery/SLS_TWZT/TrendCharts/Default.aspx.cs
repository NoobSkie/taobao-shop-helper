using ASP;
using Shove;
using Shove._Web;
using Shove.Database;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class TrendCharts_Default : SitePageBase, IRequiresSessionState
{

    private string BindNewsForLottery(int LotteryID, string TypeName)
    {
        if (TypeName == "福彩3D")
        {
            TypeName = "3D";
        }
        string key = "Home_Room_Buy_BindNewsForLotterys" + LotteryID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            string commandText = "";
            commandText = "select Top 9 Title,Content,DateTime,b.Name as TypeName from (select ID,Title,Content,TypeID,[DateTime],isCommend from dbo.T_News where isShow = 1 ) a inner join dbo.T_NewsTypes b on a.TypeID = b.ID where b.Name = @Name order by isCommend,DateTime desc";
            cacheAsDataTable = MSSQL.Select(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("Name", SqlDbType.VarChar, 0, ParameterDirection.Input, TypeName) });
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                return "";
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        StringBuilder builder = new StringBuilder();
        builder.Append("<table width='95%' border='0' cellspacing='0' cellpadding='0'>");
        string input = "";
        string str4 = "";
        int num = 0;
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            num++;
            input = row["Title"].ToString().Trim();
            if (num > 5)
            {
                break;
            }
            if ((input.IndexOf("<font class=red12>") > -1) || (input.IndexOf("<font class=black12>") > -1))
            {
                if (input.Contains("<font class=red12>"))
                {
                    str4 = "red12";
                }
                if (input.Contains("<font class=black12>"))
                {
                    str4 = "black12";
                }
                input = input.Replace("<font class=red12>", "").Replace("<font class=black12>", "").Replace("</font>", "");
                builder.Append("<tr>").Append("<td width='2' height='28' align='left'>").Append("<span class='hui14'>&#9642;</span>").Append("</td>").Append("<td width='96%' align='left' class='blue12_3'>").Append("<a href='" + row["Content"].ToString() + "' target='_blank'>").Append("<font class = '" + str4 + "'>").Append(_String.Cut(input, 15)).Append("</font>").Append("</a></td></tr>");
                continue;
            }
            builder.Append("<tr>").Append("<td width='2' height='28' align='left'>").Append("<span class='hui14'>&#9642;</span>").Append("</td>").Append("<td width='96%' align='left' class='blue12_3'>").Append("<a href='" + row["Content"].ToString() + "' target='_blank'>").Append(_String.Cut(input, 15)).Append("</a></td></tr>");
        }
        builder.Append("</table>");
        return builder.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.tdSSQ.InnerHtml = this.BindNewsForLottery(5, "双色球预测");
            this.td3D.InnerHtml = this.BindNewsForLottery(6, "3D预测");
        }
    }
}

