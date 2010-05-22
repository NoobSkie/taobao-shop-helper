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

public partial class Admin_SchemeQuash : AdminPageBase, IRequiresSessionState
{
    private void BindData()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            string condition = "LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue) + " and QuashStatus = 0 and Buyed = 0 and isOpened = 0";
            if (this.tbQuash.Text.Trim() != "")
            {
                if (this.rb1.Checked)
                {
                    condition = condition + " and SchemeNumber = '" + Utility.FilteSqlInfusion(this.tbQuash.Text.Trim()) + "'";
                }
                else
                {
                    condition = condition + " and InitiateName = '" + Utility.FilteSqlInfusion(this.tbQuash.Text.Trim()) + "'";
                }
            }
            DataTable table = new Views.V_SchemeSchedules().Open("", condition, "[Money] desc");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeQuash");
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

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ")", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
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
                PF.GoError(1, "参数错误", "Admin_SchemeQuash");
            }
            else
            {
                Users users = new Users(siteid)[siteid, num2];
                if (users == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试", "Admin_SchemeQuash");
                }
                else
                {
                    string returnDescription = "";
                    if (users.QuashScheme(schemeID, true, ref returnDescription) < 0)
                    {
                        PF.GoError(1, returnDescription, "Admin_SchemeQuash");
                    }
                    else
                    {
                        new Tables.T_UserDetails { Memo = { Value = "投注通讯故障撤单" } }.Update("SchemeID = " + schemeID.ToString() + " and OperatorType = 9");
                        this.BindData();
                    }
                }
            }
        }
    }

    protected void g_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.Item)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            ShoveConfirmButton button = e.Item.FindControl("btnQuash") as ShoveConfirmButton;
            button.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme" }));
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
            this.BindDataForLottery();
            this.BindData();
        }
    }
}

