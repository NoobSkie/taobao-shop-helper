using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_LotteryTimeSet : AdminPageBase, IRequiresSessionState
{
    public Color PreLotteryColor = Color.Linen;
    public int PreLotteryID = -1;

    private void BindData()
    {
        DataTable dt = new Views.V_PlayTypes().Open("", "LotteryID in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[Order], [ID]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_LotteryTimeSet");
        }
        else
        {
            PF.DataGridBindData(this.g, dt);
        }
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "btnOK")
        {
            int num = _Convert.StrToInt(e.Item.Cells[5].Text, -1);
            int num2 = _Convert.StrToInt(e.Item.Cells[6].Text, -1);
            int num3 = _Convert.StrToInt(((TextBox)e.Item.Cells[2].FindControl("tbSystemEndAheadMinute")).Text, -1);
            int num4 = _Convert.StrToInt(((TextBox)e.Item.Cells[3].FindControl("tbChaseExecuteDeferMinute")).Text, -1);
            if (num3 < 2)
            {
                JavaScript.Alert(this.Page, "提前截止分钟数最少必须 2 分钟，否则系统执行可能会因时间过短而不能及时处理，导致数据错误！");
            }
            else
            {
                string str = e.Item.Cells[7].Text.Replace("&nbsp;", "").Trim();
                if ((str != "") && (num4 < 1))
                {
                    JavaScript.Alert(this.Page, "追号任务自动执行必须在开始时间后最少 1 分钟！");
                }
                else if (new Tables.T_PlayTypes { SystemEndAheadMinute = { Value = num3 } }.Update("[ID] = " + num.ToString()) < 0L)
                {
                    PF.GoError(4, "数据库繁忙，请重试", "Admin_LotteryTimeSet");
                }
                else if ((str != "") && (MSSQL.ExecuteNonQuery("update T_Lotteries set ChaseExecuteDeferMinute = " + num4.ToString() + " where [ID] = " + num2.ToString(), new MSSQL.Parameter[0]) < 0))
                {
                    PF.GoError(4, "数据库繁忙，请重试", "Admin_LotteryTimeSet");
                }
                else
                {
                    this.BindData();
                    JavaScript.Alert(this.Page, "保存成功。");
                }
            }
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            TextBox box = (TextBox)e.Item.Cells[2].FindControl("tbSystemEndAheadMinute");
            box.Text = e.Item.Cells[8].Text;
            TextBox box2 = (TextBox)e.Item.Cells[3].FindControl("tbChaseExecuteDeferMinute");
            box2.Text = e.Item.Cells[9].Text;
            if (e.Item.Cells[7].Text.Replace("&nbsp;", "").Trim() == "")
            {
                box2.Visible = false;
            }
            int num = _Convert.StrToInt(e.Item.Cells[6].Text, -1);
            if (num != this.PreLotteryID)
            {
                this.PreLotteryID = num;
                if (this.PreLotteryColor.Name == Color.Linen.Name)
                {
                    this.PreLotteryColor = Color.White;
                }
                else
                {
                    this.PreLotteryColor = Color.Linen;
                }
            }
            e.Item.BackColor = this.PreLotteryColor;
            box.BackColor = this.PreLotteryColor;
            box2.BackColor = this.PreLotteryColor;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            this.g.Columns[4].Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme" }));
        }
    }

}

