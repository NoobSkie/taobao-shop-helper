using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_AllBuyFocus : AdminPageBase, IRequiresSessionState
{


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
        }
    }

    protected void btnSubMit_Click(object sender, EventArgs e)
    {
        string str = this.tbUserName.Text.Trim();
        if (str == "")
        {
            JavaScript.Alert(this.Page, "请输入合买活跃明星！");
        }
        else
        {
            string[] strArray = str.Replace("，", ",").Split(new char[] { ',' });
            str = "";
            foreach (string str2 in strArray)
            {
                Users users = new Users(base._Site.ID)[base._Site.ID, str2.Trim()];
                if (users == null)
                {
                    JavaScript.Alert(this.Page, "对不起，您输入的" + str2 + "不存在！");
                    return;
                }
                string str3 = str;
                str = str3 + users.Name + "|" + users.ID.ToString() + ",";
            }
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            Tables.T_ActiveAllBuyStar star = new Tables.T_ActiveAllBuyStar
            {
                LotterieID = { Value = this.ddlLottery.SelectedValue },
                UserList = { Value = str },
                Order = { Value = _Convert.StrToInt(this.tbOrder.Text, 1) }
            };
            if (star.GetCount("LotterieID=" + this.ddlLottery.SelectedValue) > 0L)
            {
                star.Update("LotterieID=" + this.ddlLottery.SelectedValue);
            }
            else
            {
                star.Insert();
            }
            Shove._Web.Cache.ClearCache("Home_Room_JoinAllBuy_BindActiveMembers");
            JavaScript.Alert(this.Page, "操作成功！");
        }
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable table = new Tables.T_ActiveAllBuyStar().Open("LotterieID,UserList,[Order]", "LotterieID = " + this.ddlLottery.SelectedValue, "");
        if ((table == null) || (table.Rows.Count < 1))
        {
            this.tbUserName.Text = "";
        }
        else
        {
            this.tbUserName.Text = table.Rows[0]["UserList"].ToString();
            string[] strArray = this.tbUserName.Text.Trim().Split(new char[] { ',' });
            this.tbUserName.Text = "";
            foreach (string str in strArray)
            {
                this.tbUserName.Text = this.tbUserName.Text + str.Split(new char[] { '|' })[0] + ",";
            }
            if (this.tbUserName.Text.EndsWith(","))
            {
                this.tbUserName.Text = this.tbUserName.Text.Substring(0, this.tbUserName.Text.Length - 1);
            }
            this.tbOrder.Text = table.Rows[0]["Order"].ToString();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "EditNews", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForLottery();
            this.ddlLottery_SelectedIndexChanged(this.ddlLottery, new EventArgs());
        }
    }

    
}

