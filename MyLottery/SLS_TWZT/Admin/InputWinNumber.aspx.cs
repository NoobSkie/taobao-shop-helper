using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using SLS;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_InputWinNumber : AdminPageBase, IRequiresSessionState
{
    private void BindData()
    {
        if (this.ddlIsuse.Items.Count >= 1)
        {
            string str = "格式：" + Functions.F_GetLotteryWinNumberExemple(int.Parse(this.ddlLottery.SelectedValue));
            this.labTip.Text = str;
            this.tbWinNumber.MaxLength = str.Length - 3;
            object obj2 = MSSQL.ExecuteScalar("select WinLotteryNumber from T_Isuses where [ID] = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue), new MSSQL.Parameter[0]);
            if (obj2 != null)
            {
                this.tbWinNumber.Text = Convert.ToString(obj2);
            }
            bool flag = true;
            try
            {
                flag = Convert.ToBoolean(MSSQL.ExecuteScalar("select isOpened from T_Isuses where [ID] = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue), new MSSQL.Parameter[0]));
            }
            catch
            {
            }
            if (flag)
            {
                this.btnGO.Enabled = false;
                this.tbWinNumber.Enabled = false;
                JavaScript.Alert(this.Page, "此期已经开奖了，不能修改中奖号码。");
            }
            else
            {
                this.btnGO.Enabled = true;
                this.tbWinNumber.Enabled = true;
            }
        }
    }

    private void BindDataForIsuse()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable dt = new Tables.T_Isuses().Open("[ID], [Name]", "LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue) + " and EndTime < GetDate() and isOpened = 0", "EndTime");
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_InputWinNumber");
            }
            else
            {
                ControlExt.FillDropDownList(this.ddlIsuse, dt, "Name", "ID");
                if (this.ddlIsuse.Items.Count > 0)
                {
                    this.btnGO.Enabled = true;
                    this.tbWinNumber.Enabled = true;
                }
                else
                {
                    this.btnGO.Enabled = false;
                    this.tbWinNumber.Enabled = false;
                    this.tbWinNumber.Text = "";
                }
            }
        }
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ") and [ID] <> 45", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_InputWinNumber");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
            if (this.ddlLottery.Items.Count < 1)
            {
                this.btnGO.Enabled = false;
                this.tbWinNumber.Enabled = false;
            }
        }
    }

    protected void btnGO_Click(object sender, EventArgs e)
    {
        this.tbWinNumber.Text = this.tbWinNumber.Text.Trim();
        if (!new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].AnalyseWinNumber(this.tbWinNumber.Text))
        {
            JavaScript.Alert(this.Page, "中奖号码格式不正确！");
        }
        else if (new Tables.T_Isuses { WinLotteryNumber = { Value = this.tbWinNumber.Text } }.Update("[ID] = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue)) < 0L)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_InputWinNumber");
        }
        else
        {
            Shove._Web.Cache.ClearCache(DataCache.IsusesInfo + this.ddlLottery.SelectedValue);
            JavaScript.Alert(this.Page, "中奖号码填写成功。");
        }
    }

    protected void ddlIsuse_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindDataForIsuse();
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
            this.BindDataForIsuse();
            this.BindData();
            this.btnGO.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "FillContent" }));
        }
    }
}

