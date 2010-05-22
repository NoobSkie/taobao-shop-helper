using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using SLS;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_ReBuildWinDescription : AdminPageBase, IRequiresSessionState
{
    private void BindDataForIsuse()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable dt = new Tables.T_Isuses().Open("[ID], [Name]", "LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue) + " and isOpened = 1", "EndTime desc");
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                ControlExt.FillDropDownList(this.ddlIsuse, dt, "Name", "ID");
                if (this.ddlIsuse.Items.Count > 0)
                {
                    this.WinNumberOther.Visible = true;
                    this.btnGO.Enabled = true;
                    this.ddlIsuse_SelectedIndexChanged(this.ddlIsuse, new EventArgs());
                }
                else
                {
                    this.WinNumberOther.Visible = true;
                    this.btnGO.Enabled = false;
                }
            }
        }
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ")", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
            if (this.ddlLottery.Items.Count < 1)
            {
                this.btnGO.Enabled = false;
            }
            else
            {
                this.ddlLottery_SelectedIndexChanged(this.ddlLottery, new EventArgs());
            }
        }
    }

    private void BindDataForWinMoney()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable table = new Tables.T_WinTypes().Open("", "LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue), "[Order]");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                this.g.DataSource = table.DefaultView;
                this.g.DataBind();
            }
        }
    }

    protected void btnGO_Click(object sender, EventArgs e)
    {
        this.tbWinNumber.Text = _Convert.ToDBC(this.tbWinNumber.Text.Trim().Replace("　", " ")).Trim();
        if (!new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].AnalyseWinNumber(this.tbWinNumber.Text))
        {
            JavaScript.Alert(this.Page, "开奖号码不正确！");
        }
        else
        {
            double[] winMoneyList = new double[this.g.Rows.Count * 2];
            for (int i = 0; i < this.g.Rows.Count; i++)
            {
                winMoneyList[i * 2] = _Convert.StrToDouble(((TextBox)this.g.Rows[i].Cells[1].FindControl("tbMoney")).Text, 0.0);
                winMoneyList[(i * 2) + 1] = _Convert.StrToDouble(((TextBox)this.g.Rows[i].Cells[2].FindControl("tbMoneyNoWithTax")).Text, 0.0);
                if (winMoneyList[i * 2] < 0.0)
                {
                    JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 项奖金输入错误！");
                    return;
                }
            }
            Tables.T_Schemes schemes = new Tables.T_Schemes();
            DataTable table = schemes.Open("", "IsuseID = " + this.ddlIsuse.SelectedValue + " and isOpened = 1", "");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    string number = table.Rows[j]["LotteryNumber"].ToString();
                    string description = "";
                    double winMoneyNoWithTax = 0.0;
                    double num5 = new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].ComputeWin(number, this.tbWinNumber.Text.Trim(), ref description, ref winMoneyNoWithTax, int.Parse(table.Rows[j]["PlayTypeID"].ToString()), winMoneyList);
                    int num6 = _Convert.StrToInt(table.Rows[j]["Multiple"].ToString(), 1);
                    schemes.PreWinMoney.Value = num5 * num6;
                    schemes.PreWinMoneyNoWithTax.Value = num5 * num6;
                    schemes.WinDescription.Value = description;
                    schemes.Update("[ID] = " + table.Rows[j]["ID"].ToString());
                }
                JavaScript.Alert(this.Page, "重构中奖描述成功。");
            }
        }
    }

    protected void ddlIsuse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable table = new Tables.T_Isuses().Open("WinLotteryNumber, isOpened", "[ID] = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue), "");
            if ((table == null) || (table.Rows.Count < 1))
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                bool flag = _Convert.StrToBool(table.Rows[0]["isOpened"].ToString(), true);
                string str = table.Rows[0]["WinLotteryNumber"].ToString();
                if (!flag)
                {
                    this.btnGO.Enabled = false;
                    PF.GoError(1, "此期还没有开奖，不能重构中奖描述。", base.GetType().BaseType.FullName);
                }
                else
                {
                    this.tbWinNumber.Text = str;
                    this.btnGO.Enabled = true;
                }
            }
        }
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindDataForWinMoney();
        this.BindDataForIsuse();
    }

    protected void g_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Web.UI.WebControls.DataKey key = this.g.DataKeys[this.g.DataKeys.Count - 1];
            double num = _Convert.StrToDouble(key.Values[0].ToString(), 0.0);
            ((TextBox)e.Row.Cells[1].FindControl("tbMoney")).Text = (num == 0.0) ? "" : num.ToString();
            num = _Convert.StrToDouble(key.Values[1].ToString(), 0.0);
            ((TextBox)e.Row.Cells[2].FindControl("tbMoneyNoWithTax")).Text = (num == 0.0) ? "" : num.ToString();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "LotteryWin" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForLottery();
            this.BindDataForIsuse();
        }
    }


}

