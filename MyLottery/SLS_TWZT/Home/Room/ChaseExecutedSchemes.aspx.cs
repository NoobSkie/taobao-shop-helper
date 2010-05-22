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

public partial class Home_Room_ChaseExecutedSchemes : RoomPageBase, IRequiresSessionState
{

    private void BindData(int ChaseID)
    {
        string key = "Home_Room_ChaseExecutedSchemes_BindData_" + ChaseID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        StringBuilder builder = new StringBuilder();
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
        {
            builder.Append("select Title,Name,IsuseCount,IsuseCount*Multiple*Nums*Price as SumMoney,Money,QuashStatus,ExecutedCount,ExecutedCount*Multiple*Nums*Price as ExcutedMoney,").Append("IsuseCount-ExecutedCount as NoExecutedCount,Title,StopTypeWhenWin,StopTypeWhenWinMoney from T_Chases a inner join T_Lotteries b ").Append("on a.LotteryID = b.ID and a.ID=" + ChaseID.ToString() + " ").Append("left join (select ChaseID,count(SchemeID) as ExecutedCount from  T_ExecutedChases group by ChaseID)c on a.ID = c.ChaseID");
            cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
            {
                PF.GoError(4, "此记录不存在或已被删除！", base.GetType().FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable);
        }
        DataRow row = cacheAsDataTable.Rows[0];
        this.lbLotteryName.Text = row["Name"].ToString();
        this.lbTitle.Text = row["Title"].ToString();
        if (row["StopTypeWhenWin"].ToString() == "1")
        {
            this.lbStopCondition.Text = "完成方案";
        }
        else
        {
            this.lbStopCondition.Text = "单期中奖金额达到" + row["StopTypeWhenWinMoney"].ToString();
        }
        double num = _Convert.StrToDouble(row["SumMoney"].ToString(), 0.0);
        int num2 = _Convert.StrToInt(row["IsuseCount"].ToString(), 0);
        int num3 = _Convert.StrToInt(row["ExecutedCount"].ToString(), 0);
        int num4 = _Convert.StrToInt(row["NoExecutedCount"].ToString(), 0);
        double num5 = _Convert.StrToDouble(row["ExcutedMoney"].ToString(), 0.0);
        double num6 = _Convert.StrToDouble(row["Money"].ToString(), 0.0);
        this.lbDescription.Text = "</font>共<font color='red'>" + num2.ToString() + "</font>期<font color='red'>" + num.ToString("N") + "</font>元; 已完成<font color='red'>" + num3.ToString() + "</font>期<font color='red'>" + num5.ToString("N") + "</font>元; 未执行<font color='red'>" + num4.ToString() + "</font>期<font color='red'>" + num6.ToString("N") + "</font>元。";
        key = "Home_Room_ChaseExecutedSchemes_BindDataDetails_" + ChaseID.ToString();
        DataTable table2 = Shove._Web.Cache.GetCacheAsDataTable(key);
        builder = new StringBuilder();
        if (table2 == null)
        {
            builder.Append("select PlayTypeName,ID,IsuseName,LotteryNumber,Multiple,Money,QuashStatus,Buyed from T_ExecutedChases a inner join V_Schemes b ").Append("on a.SchemeID = b.ID and a.ChaseID =" + ChaseID.ToString() + " order by ID");
            table2 = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
            if (table2 == null)
            {
                PF.GoError(4, "您还没有追号！", base.GetType().FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, table2);
        }
        if (table2.Rows.Count > 0)
        {
            this.lbPlayTypeName.Text = table2.Rows[0]["PlayTypeName"].ToString();
        }
        PF.DataGridBindData(this.g, table2);
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            TableCell cell1 = e.Item.Cells[0];
            cell1.Text = cell1.Text + "期";
            e.Item.Cells[1].Text = _Convert.ToHtmlCode(e.Item.Cells[1].Text);
            e.Item.Cells[2].Text = "倍数:" + e.Item.Cells[2].Text;
            double num = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            e.Item.Cells[3].Text = (num == 0.0) ? "" : num.ToString("N");
            int num2 = _Convert.StrToInt(e.Item.Cells[6].Text, 0);
            long num3 = _Convert.StrToLong(e.Item.Cells[8].Text, -1L);
            if (num2 != 0)
            {
                e.Item.Cells[4].Text = "系统撤单";
            }
            else if (num3 > 0L)
            {
                e.Item.Cells[4].Text = "<font color='#330099'>已成功</font>";
                e.Item.Cells[5].Text = "<a href='Scheme.aspx?id=" + num3.ToString() + "' target='_blank'><font color=\"#330099\">查看方案</Font></a>";
            }
            else
            {
                e.Item.Cells[4].Text = "<font color='Red'>进行中</font>";
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int chaseID = _Convert.StrToInt(Utility.GetRequest("id"), -1);
        if (chaseID < 0)
        {
            base.Response.Redirect("ViewChase.aspx");
        }
        else if (!base.IsPostBack)
        {
            this.BindData(chaseID);
        }
    }
}

