using ASP;
using DAL;
using FreeTextBoxControls;
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

public partial class Admin_OpenManual : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        if (this.ddlIsuse.Items.Count >= 1)
        {
            DataTable table = new Views.V_Schemes().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue) + " and Buyed = 1 and SchemeIsOpened = 0", "");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_OpenManual");
            }
            else
            {
                table.Columns.Add("LocateWaysAndMultiples", Type.GetType("System.String"));
                if (this.ddlIsuse.SelectedValue == "45")
                {
                    string buyContent = "";
                    string cnLocateWaysAndMultiples = "";
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        table.Rows[i]["Money"] = double.Parse(table.Rows[i]["Money"].ToString()).ToString("N");
                        table.Rows[i]["Multiple"] = 0;
                        try
                        {
                            buyContent = "";
                            cnLocateWaysAndMultiples = "";
                            if (new Lottery()["45"].GetSchemeSplit(table.Rows[i]["LotteryNumber"].ToString(), ref buyContent, ref cnLocateWaysAndMultiples))
                            {
                                table.Rows[i]["LocateWaysAndMultiples"] = cnLocateWaysAndMultiples;
                            }
                            else
                            {
                                table.Rows[i]["LocateWaysAndMultiples"] = "<font color='red'>读取错误！</font>";
                            }
                        }
                        catch
                        {
                            table.Rows[i]["LocateWaysAndMultiples"] = "<font color='red'>读取错误！</font>";
                        }
                        table.AcceptChanges();
                    }
                }
                this.g.DataSource = table.DefaultView;
                this.g.DataBind();
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
                PF.GoError(4, "数据库繁忙，请重试", "Admin_OpenManual");
            }
            else
            {
                ControlExt.FillDropDownList(this.ddlIsuse, dt, "Name", "ID");
                if (this.ddlIsuse.Items.Count > 0)
                {
                    this.ddlIsuse_SelectedIndexChanged(this.ddlIsuse, new EventArgs());
                    if (this.ddlIsuse.SelectedValue == "45")
                    {
                        this.Label1.Visible = false;
                        this.tbWinLotteryNumber.Visible = false;
                        this.lbTipLotteryNumber.Visible = false;
                        this.tbWinLotteryNumber.Enabled = true;
                        this.lbTipLotteryNumber.Visible = true;
                        this.btnEnd.Enabled = true;
                        this.tbOpenAffiche.ReadOnly = false;
                    }
                    else
                    {
                        this.Label1.Visible = true;
                        this.tbWinLotteryNumber.Visible = true;
                        this.lbTipLotteryNumber.Visible = true;
                        this.tbWinLotteryNumber.Enabled = true;
                        this.lbTipLotteryNumber.Visible = true;
                        this.btnEnd.Enabled = true;
                        this.tbOpenAffiche.ReadOnly = false;
                    }
                }
                else
                {
                    this.Label1.Visible = true;
                    this.tbWinLotteryNumber.Visible = true;
                    this.lbTipLotteryNumber.Visible = true;
                    this.tbWinLotteryNumber.Enabled = false;
                    this.lbTipLotteryNumber.Visible = false;
                    this.btnEnd.Enabled = false;
                    this.tbOpenAffiche.ReadOnly = true;
                }
            }
        }
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ")", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_OpenManual");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
        }
    }

    protected void btnEnd_Click(object sender, EventArgs e)
    {
        string str = this.tbWinLotteryNumber.Text.Trim();
        if ((this.ddlIsuse.SelectedValue != "45") && (str == ""))
        {
            JavaScript.Alert(this.Page, "请输入开奖号码。");
        }
        else
        {
            MSSQL.ExecuteNonQuery("update T_Isuses set isOpened = 1, WinLotteryNumber = @p1, OpenAffiche = @p2 where [ID] = " + this.ddlIsuse.SelectedValue, new MSSQL.Parameter[] { new MSSQL.Parameter("p1", SqlDbType.VarChar, 0, ParameterDirection.Input, str), new MSSQL.Parameter("p2", SqlDbType.VarChar, 0, ParameterDirection.Input, this.tbOpenAffiche.Text) });
            this.BindData();
        }
    }

    protected void ddlIsuse_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
        string str = "";
        try
        {
            str = Convert.ToString(MSSQL.ExecuteScalar("select WinLotteryNumber from T_Isuses where [ID] = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue), new MSSQL.Parameter[0]));
        }
        catch
        {
        }
        this.tbWinLotteryNumber.Text = str;
        this.lbTipLotteryNumber.Text = "格式：" + this.GetWinLotteryNumberTip(int.Parse(this.ddlLottery.SelectedValue));
        this.tbOpenAffiche.Text = new OpenAfficheTemplates()[int.Parse(this.ddlLottery.SelectedValue)];
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindDataForIsuse();
    }

    protected void g_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "btnWin")
        {
            double winMoney = _Convert.StrToDouble(((TextBox)e.Item.FindControl("tbWinMoney")).Text, 0.0);
            double winMoneyNoWithTax = _Convert.StrToDouble(((TextBox)e.Item.FindControl("tbWinMoneyNoWithTax")).Text, 0.0);
            string winDescription = ((TextBox)e.Item.FindControl("tbWinDescription")).Text.Trim();
            long schemeID = _Convert.StrToLong(((HtmlInputHidden)e.Item.FindControl("tbSchemeID")).Value, -1L);
            if (schemeID < 1L)
            {
                PF.GoError(1, "参数错误", "Admin_OpenManual");
            }
            else if (((winMoney <= 0.0) || (winMoneyNoWithTax <= 0.0)) || (winDescription == ""))
            {
                JavaScript.Alert(this.Page, "输入不完整。");
            }
            else
            {
                int returnValue = -1;
                string returnDescription = "";
                DataSet ds = null;
                if (Procedures.P_WinByOpenManual(ref ds, base._Site.ID, schemeID, winMoney, winMoneyNoWithTax, winDescription, base._User.ID, ref returnValue, ref returnDescription) < 0)
                {
                    PF.GoError(4, "数据库繁忙，请重试", "Admin_OpenManual");
                }
                else if (returnValue < 0)
                {
                    JavaScript.Alert(this.Page, returnDescription);
                }
                else if ((ds == null) || (returnDescription != ""))
                {
                    PF.GoError(1, "开奖错误：" + returnDescription, "Admin_OpenManual");
                }
                else
                {
                    PF.SendWinNotification(ds);
                    this.BindData();
                }
            }
        }
    }

    protected void g_PageIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    private string GetWinLotteryNumberTip(int LotteryID)
    {
        return Functions.F_GetLotteryWinNumberExemple(LotteryID);
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

