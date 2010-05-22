using ASP;
using DAL;
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

public partial class Admin_LotteryGateway : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        SystemOptions options = new SystemOptions();
        this.tb1.Text = options["ElectronTicket_HPCQ_Getway"].ToString("");
        this.tb2.Text = options["ElectronTicket_HPCQ_UserName"].ToString("");
        this.tb3.Attributes.Add("value", options["ElectronTicket_HPCQ_UserPassword"].ToString(""));
        ControlExt.SetDownListBoxTextFromValue(this.ddlNotFull1, options["ElectronTicket_HPCQ_NotFull"].ToString("1"));
        this.cb1.Checked = options["ElectronTicket_HPCQ_Status_ON"].ToBoolean(false);
        this.tb4.Text = options["ElectronTicket_Shove_UserName"].ToString("");
        this.tb5.Attributes.Add("value", options["ElectronTicket_Shove_UserPassword"].ToString(""));
        ControlExt.SetDownListBoxTextFromValue(this.ddlNotFull2, options["ElectronTicket_Shove_NotFull"].ToString("1"));
        this.cb2.Checked = options["ElectronTicket_Shove_Status_ON"].ToBoolean(false);
    }

    private void BindDataForLottery()
    {
        DataTable table = new Tables.T_Lotteries().Open("[ID], [Name], PrintOutType", "[ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ")", "[Order]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
        }
        else
        {
            this.g.DataSource = table;
            this.g.DataBind();
            this.g.Columns[2].Visible = false;
            this.g.Columns[3].Visible = false;
            for (int i = 0; i < this.g.Rows.Count; i++)
            {
                DropDownList ddl = (DropDownList)this.g.Rows[i].Cells[1].FindControl("ddlElectronTicket");
                if (_Convert.StrToInt(this.g.Rows[i].Cells[2].Text, -1) >= 1)
                {
                    ControlExt.SetDownListBoxTextFromValue(ddl, _Convert.StrToShort(this.g.Rows[i].Cells[3].Text, 0).ToString());
                }
            }
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        SystemOptions options = new SystemOptions();
        options["ElectronTicket_HPCQ_Getway"] = new OptionValue(this.tb1.Text);
        options["ElectronTicket_HPCQ_UserName"] = new OptionValue(this.tb2.Text);
        options["ElectronTicket_HPCQ_UserPassword"] = new OptionValue(this.tb3.Text);
        options["ElectronTicket_HPCQ_Status_ON"] = new OptionValue(this.cb1.Checked);
        options["ElectronTicket_HPCQ_NotFull"] = new OptionValue(this.ddlNotFull1.SelectedValue);
        options["ElectronTicket_Shove_UserName"] = new OptionValue(this.tb4.Text);
        options["ElectronTicket_Shove_UserPassword"] = new OptionValue(this.tb5.Text);
        options["ElectronTicket_Shove_Status_ON"] = new OptionValue(this.cb2.Checked);
        options["ElectronTicket_Shove_NotFull"] = new OptionValue(this.ddlNotFull2.SelectedValue);
        for (int i = 0; i < this.g.Rows.Count; i++)
        {
            DropDownList list = (DropDownList)this.g.Rows[i].Cells[1].FindControl("ddlElectronTicket");
            MSSQL.ExecuteNonQuery("update T_Lotteries set PrintOutType = " + list.SelectedValue + " where [ID] = " + this.g.Rows[i].Cells[2].Text, new MSSQL.Parameter[0]);
        }
        this.tb3.Attributes.Add("value", this.tb3.Text);
        this.tb5.Attributes.Add("value", this.tb5.Text);
        JavaScript.Alert(this.Page, "站点资料已经保存成功。");
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Options", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
            this.BindDataForLottery();
            this.btnOK.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "Options" }));
        }
    }


}

