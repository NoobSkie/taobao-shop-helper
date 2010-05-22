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

public partial class Admin_PrintOutNotFull : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable table = new Views.V_SchemeSchedules().Open("", "LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue) + " and Schedule >= 100 and QuashStatus = 0 and Buyed = 0 and EndTime < GetDate() and not [ID] in (select SchemeID from T_SchemesSendToCenter where HandleResult <> 1)", "[Money] desc");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
            }
            else
            {
                table.Columns.Add("LocateWaysAndMultiples", Type.GetType("System.String"));
                string buyContent = "";
                string cnLocateWaysAndMultiples = "";
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i]["Money"] = double.Parse(table.Rows[i]["Money"].ToString()).ToString("N");
                    if (new Lottery()["45"].CheckPlayType(int.Parse(table.Rows[i]["PlayTypeID"].ToString())))
                    {
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
                    }
                    table.AcceptChanges();
                }
                this.g.DataSource = table;
                this.g.DataBind();
            }
        }
    }

    private void BindDataForElectronTicket()
    {
        this.ddlElectronTicket.Items.Clear();
        SystemOptions options = new SystemOptions();
        if (options["ElectronTicket_HPCQ_Status_ON"].ToBoolean(false))
        {
            this.ddlElectronTicket.Items.Add(new ListItem("深圳恒朋-重庆福彩中心", "101"));
        }
    }

    private void BindDataForLottery()
    {
        if (this.ddlElectronTicket.Items.Count >= 1)
        {
            DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "PrintOutType = " + Utility.FilteSqlInfusion(this.ddlElectronTicket.SelectedValue) + " and [ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ")", "[Order]");
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
            }
            else
            {
                ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
            }
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void ddlElectronTicket_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindDataForLottery();
        this.BindData();
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void g_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "btnQuash")
        {
            long siteid = _Convert.StrToLong(((HtmlInputHidden)e.Item.FindControl("tbSiteID")).Value, -1L);
            long num2 = _Convert.StrToLong(((HtmlInputHidden)e.Item.FindControl("tbInitiateUserID")).Value, -1L);
            long schemeID = _Convert.StrToLong(((HtmlInputHidden)e.Item.FindControl("tbSchemeID")).Value, -1L);
            if (((siteid < 0L) || (num2 < 0L)) || (schemeID < 0L))
            {
                PF.GoError(1, "参数错误", this.Page.GetType().BaseType.FullName);
            }
            else
            {
                Users users = new Users(siteid)[siteid, num2];
                if (users == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
                }
                else
                {
                    string returnDescription = "";
                    if (users.QuashScheme(schemeID, true, ref returnDescription) < 0)
                    {
                        PF.GoError(1, returnDescription, this.Page.GetType().BaseType.FullName);
                    }
                    else
                    {
                        this.BindData();
                    }
                }
            }
        }
        else if (e.CommandName == "btnPrintOut")
        {
            int returnValue = -1;
            string str2 = "";
            if (Procedures.P_SchemePrintOut(_Convert.StrToLong(((HtmlInputHidden)e.Item.FindControl("tbSiteID")).Value, -1L), _Convert.StrToLong(((HtmlInputHidden)e.Item.FindControl("tbSchemeID")).Value, -1L), base._User.ID, short.Parse(this.ddlElectronTicket.SelectedValue), "请电询", true, ref returnValue, ref str2) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
            }
            else if (returnValue < 0)
            {
                PF.GoError(1, str2, this.Page.GetType().BaseType.FullName);
            }
            else
            {
                this.BindData();
            }
        }
    }

    protected void g_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            ShoveConfirmButton button = e.Item.FindControl("btnQuash") as ShoveConfirmButton;
            button.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme" }));
            ShoveConfirmButton button2 = e.Item.FindControl("btnPrintOut") as ShoveConfirmButton;
            button2.Visible = button.Visible;
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
        if (!base.IsPostBack)
        {
            this.BindDataForElectronTicket();
            this.BindDataForLottery();
            this.BindData();
        }
    }


}

