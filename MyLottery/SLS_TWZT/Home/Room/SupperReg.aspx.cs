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

public partial class Home_Room_SupperReg : RoomPageBase, IRequiresSessionState
{

    private void BianData()
    {
        this.lbUserName.Text = base._User.Name;
        string key = "dtLotteriesUseLotteryList";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Lotteries().Open("[ID], [Name], [Code]", "[ID] in(" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ")", "[ID]");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-39)");
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        if (cacheAsDataTable == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-49)");
        }
        else
        {
            this.ddlLotteries.Items.Clear();
            this.ddlLotteries.Items.Add(new ListItem("选择彩种", "0"));
            foreach (DataRow row in cacheAsDataTable.Rows)
            {
                this.ddlLotteries.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
            }
            this.ddlPlayTypes.Items.Clear();
            this.ddlPlayTypes.Items.Add(new ListItem("选择玩法", "0"));
            string request = Utility.GetRequest("LotteryID");
            string str3 = Utility.GetRequest("PlayTypeID");
            if ((request != null) && (request != ""))
            {
                try
                {
                    this.ddlLotteries.SelectedValue = request;
                    this.ddlLotteries_SelectedIndexChanged(this.ddlLotteries, null);
                }
                catch
                {
                }
            }
            if ((str3 != null) && (str3 != ""))
            {
                try
                {
                    this.ddlPlayTypes.SelectedValue = str3;
                }
                catch
                {
                }
            }
        }
    }

    protected void btn_OK_Click(object sender, EventArgs e)
    {
        if (this.ddlLotteries.SelectedValue == "0")
        {
            JavaScript.Alert(this, "请选择彩种");
        }
        else
        {
            long newUserForInitiateFollowSchemeTryID = 0L;
            string returnDescription = "";
            if (this.textarea.Value == "")
            {
                JavaScript.Alert(this.Page, "申请内容不能为空");
            }
            else if (Procedures.P_UserForInitiateFollowSchemeTry(base._Site.ID, base._User.ID, int.Parse(this.ddlPlayTypes.SelectedValue), this.textarea.Value, ref newUserForInitiateFollowSchemeTryID, ref returnDescription) < 0)
            {
                PF.GoError(1, "数据添加错误", base.GetType().FullName + "(-142)");
            }
            else if ((newUserForInitiateFollowSchemeTryID < 1L) || (returnDescription != ""))
            {
                PF.GoError(1, returnDescription, base.GetType().FullName + "(-149)");
            }
            else
            {
                this.textarea.Value = "";
                JavaScript.Alert(this.Page, @"您申请的超级发起人成功，\n 耐心等待，我们会在第一时间审核您的申请！");
            }
        }
    }

    protected void ddlLotteries_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlLotteries.SelectedValue == "0")
        {
            this.ddlPlayTypes.Items.Clear();
            this.ddlPlayTypes.Items.Add(new ListItem("选择玩法", "0"));
        }
        else
        {
            string key = "dtPlayTypes_" + this.ddlLotteries.SelectedValue;
            DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
            if (cacheAsDataTable == null)
            {
                cacheAsDataTable = new Tables.T_PlayTypes().Open("", "LotteryID in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ") and LotteryID = " + _Convert.StrToInt(this.ddlLotteries.SelectedValue, -1).ToString(), "[ID]");
                if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
                {
                    PF.GoError(7, "数据库繁忙，请重试", base.GetType().FullName + "(-85)");
                    return;
                }
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
            }
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName + "(-95)");
            }
            else
            {
                this.ddlPlayTypes.Items.Clear();
                foreach (DataRow row in cacheAsDataTable.Rows)
                {
                    this.ddlPlayTypes.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BianData();
        }
    }

}

