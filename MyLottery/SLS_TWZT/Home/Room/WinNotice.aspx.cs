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
using System.Web.UI.WebControls;

public partial class Home_Room_WinNotice : Page, IRequiresSessionState
{
    private void GetWinNotice()
    {
        // This item is obfuscated and can not be translated.
        string key = "GetWinNoticeTotal";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        StringBuilder builder = new StringBuilder();
        if (cacheAsDataTable == null)
        {
            builder.AppendLine("select a.ID, WinMoney,b.Name as LotteryName,PlayTypeName,c.Name as InitiateName from                            \r\n                (select top 12 a.ID,InitiateUserID,LotteryID,Name as PlayTypeName, WinMoney\r\n                from T_Schemes a inner join T_PlayTypes b on a.PlayTypeID = b.ID where WinMoney > 0 order by a.ID desc)a\r\n                inner join T_Lotteries b on a.LotteryID = b.ID inner join T_Users c on a.InitiateUserID = c.ID");
            cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据读写错错误", base.GetType().BaseType.FullName);
                return;
            }
            cacheAsDataTable.Columns.Add("Content", typeof(string));
            string str2 = "";
            foreach (DataRow row in cacheAsDataTable.Rows)
            {
                str2 = row["LotteryName"].ToString();
                if (str2.IndexOf("江西") > -1)
                {
                    str2 = str2.Replace("江西", "");
                }
                builder = new StringBuilder();

                string text1 = row["PlayTypeName"].ToString();

                builder.Append("<a style=\"text-decoration:none;\"  target=\"_blank\" href=\"Scheme.aspx?id=" + row["ID"].ToString() + "\"/>").Append("<span class=\"hui12\">").Append("<span class =\"blue12\">").Append(_String.Cut(row["InitiateName"].ToString(), 4)).Append("</span>&nbsp;喜中").Append(text1).Append(str2).Append("</span><span class =\"red12_2\">").Append(_Convert.StrToDouble(row["WinMoney"].ToString(), 0.0).ToString()).Append("</span><span class=\"hui12\">元</span></a>");
                row["Content"] = builder.ToString();
                cacheAsDataTable.AcceptChanges();
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 900);
        }
        this.dlWinNotice.DataSource = cacheAsDataTable;
        this.dlWinNotice.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.GetWinNotice();
        }
    }
}

