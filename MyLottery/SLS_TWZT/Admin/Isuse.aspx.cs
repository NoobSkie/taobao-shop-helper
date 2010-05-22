using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Isuse : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable table = new Tables.T_Isuses().Open("", "LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue) + " and EndTime > GetDate()", "EndTime");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                this.g.DataSource = table;
                this.g.DataBind();
                DataTable table2 = new Tables.T_Isuses().Open("top 1 [Name], StartTime, EndTime", "LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue), "EndTime desc");
                if (table2 == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                }
                else if (table2.Rows.Count < 1)
                {
                    this.labLastIsuseTip.Text = "此彩种还没有添加过任何期号。";
                }
                else
                {
                    this.labLastIsuseTip.Text = "已添加的最后期号：" + table2.Rows[0]["Name"].ToString() + "，开始时间：" + _Convert.StrToDateTime(table2.Rows[0]["StartTime"].ToString(), "0000-00-00 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "，截止时间：" + _Convert.StrToDateTime(table2.Rows[0]["EndTime"].ToString(), "0000-00-00 00:00:00").ToString("yyyy-MM-dd HH:mm:ss") + "。";
                }
            }
        }
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
            string request = Utility.GetRequest("LotteryID");
            if (request != "")
            {
                ControlExt.SetDownListBoxTextFromValue(this.ddlLottery, request);
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            base.Response.Redirect("IsuseAdd.aspx?LotteryID=" + this.ddlLottery.SelectedValue, true);
        }
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
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
            this.BindDataForLottery();
            this.BindData();
            this.btnAdd.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme" }));
        }
    }


}

