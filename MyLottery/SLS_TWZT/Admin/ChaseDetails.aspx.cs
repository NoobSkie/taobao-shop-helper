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

public partial class Admin_ChaseDetails : AdminPageBase, IRequiresSessionState
{


    private void BindData(int ChaseID)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("select Title,Name,IsuseCount,IsuseCount*Multiple*Nums*Price as SumMoney,Money,QuashStatus,ExecutedCount,ExecutedCount*Multiple*Nums*Price as ExcutedMoney,").Append("IsuseCount-ExecutedCount as NoExecutedCount,Title,StopTypeWhenWin,StopTypeWhenWinMoney from T_Chases a inner join T_Lotteries b ").Append("on a.LotteryID = b.ID and a.ID=" + ChaseID.ToString() + " ").Append("left join (select ChaseID,count(SchemeID) as ExecutedCount from  T_ExecutedChases group by ChaseID)c on a.ID = c.ChaseID");
        DataTable table = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[0]);
        if ((table == null) || (table.Rows.Count == 0))
        {
            PF.GoError(4, "您还没有追号！", base.GetType().FullName);
        }
        else
        {
            DataRow row = table.Rows[0];
            this.lbLotteryName.Text = row["Name"].ToString();
            this.labTitle.Text = row["Title"].ToString();
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
            string commandText = "select c.Name as PlayTypeName,b.ID,d.Name as IsuseName,LotteryNumber,Multiple,Money,QuashStatus,Buyed from T_ExecutedChases a inner join T_Schemes b on a.SchemeID = b.ID and a.ChaseID =@ChaseID inner join T_PlayTypes c on b.PlayTypeID = c.ID inner join T_Isuses d on b.IsuseID = d.ID";
            DataTable dt = MSSQL.Select(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("ChaseID", SqlDbType.BigInt, 0, ParameterDirection.Input, ChaseID.ToString()) });
            if (dt == null)
            {
                PF.GoError(4, "您还没有追号！", base.GetType().FullName);
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    this.lbPlayTypeName.Text = dt.Rows[0]["PlayTypeName"].ToString();
                }
                PF.DataGridBindData(this.g, dt);
            }
        }
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
                e.Item.Cells[5].Text = "<a href='../Home/Room/Scheme.aspx?id=" + num3.ToString() + "' target='_blank'><font color=\"#330099\">查看方案</Font></a>";
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
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int chaseID = _Convert.StrToInt(Utility.GetRequest("id"), -1);
        if (chaseID < 0)
        {
            base.Response.Redirect("ChaseList.aspx");
        }
        else if (!base.IsPostBack)
        {
            this.BindData(chaseID);
        }
    }
}

