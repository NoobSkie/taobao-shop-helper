using ASP;
using DAL;
using FreeTextBoxControls;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_LotteryInformation : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable table = new Tables.T_Lotteries().Open("Explain, SchemeExemple, Agreement, OpenAfficheTemplate", "[ID] = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue), "");
            if ((table == null) || (table.Rows.Count < 1))
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_LotteryInformation");
            }
            else
            {
                this.tbExplain.Text = table.Rows[0]["Explain"].ToString();
                this.tbLotteryExemple.Text = table.Rows[0]["SchemeExemple"].ToString();
                this.tbAgreement.Text = table.Rows[0]["Agreement"].ToString();
                this.tbOpenAfficheTemplate.Text = table.Rows[0]["OpenAfficheTemplate"].ToString();
            }
        }
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_LotteryInformation");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            if (MSSQL.ExecuteNonQuery("update T_Lotteries set Explain = '" + Utility.FilteSqlInfusion(this.tbExplain.Text) + "', SchemeExemple = '" + Utility.FilteSqlInfusion(this.tbLotteryExemple.Text) + "', Agreement = '" + Utility.FilteSqlInfusion(this.tbAgreement.Text) + "', OpenAfficheTemplate = '" + Utility.FilteSqlInfusion(this.tbOpenAfficheTemplate.Text) + "' where [ID] = '" + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue) + "'", new MSSQL.Parameter[0]) < 0)
            {
                JavaScript.Alert(this.Page, "保存失败。");
            }
            else
            {
                JavaScript.Alert(this.Page, "保存成功。");
            }
        }
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "FillContent", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForLottery();
            this.BindData();
            this.btnOK.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "FillContent" }));
        }
    }


}

