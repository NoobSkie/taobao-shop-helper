using ASP;
using DAL;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_ExpertsReg : RoomPageBase, IRequiresSessionState
{

    private void BindData(CheckBoxList list, string temp)
    {
        DataTable table = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ") " + temp, "[Order]");
        if (table == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            list.Items.Clear();
            foreach (DataRow row in table.Rows)
            {
                list.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
            }
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        bool flag = true;
        if (this.tbDescription.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入申请描述！");
        }
        else
        {
            long newExpertsTryID = 0L;
            string returnDescription = "";
            string msg = "";
            foreach (ListItem item in this.cblLotteryListZC.Items)
            {
                if (item.Selected)
                {
                    flag = false;
                    Procedures.P_ExpertsTry(base._Site.ID, base._User.ID, int.Parse(item.Value), Utility.FilteSqlInfusion(this.tbDescription.Text.Trim()), 0.0, 0.0, ref newExpertsTryID, ref returnDescription);
                    if (newExpertsTryID < 0L)
                    {
                        string str3 = msg;
                        msg = str3 + item.Text + " " + returnDescription + @"\n";
                    }
                    else if (newExpertsTryID > 0L)
                    {
                        msg = msg + item.Text + @"申请信息提交成功\n";
                    }
                }
            }
            foreach (ListItem item2 in this.cblLotteryListFC.Items)
            {
                if (item2.Selected)
                {
                    flag = false;
                    Procedures.P_ExpertsTry(base._Site.ID, base._User.ID, int.Parse(item2.Value), Utility.FilteSqlInfusion(this.tbDescription.Text.Trim()), 0.0, 0.0, ref newExpertsTryID, ref returnDescription);
                    if (newExpertsTryID < 0L)
                    {
                        string str4 = msg;
                        msg = str4 + item2.Text + " " + returnDescription + @"\n";
                    }
                    else if (newExpertsTryID > 0L)
                    {
                        msg = msg + item2.Text + @"申请信息提交成功\n";
                    }
                }
            }
            if (msg != "")
            {
                JavaScript.Alert(this.Page, msg);
            }
            else if (flag)
            {
                JavaScript.Alert(this.Page, "您没有选择任何彩种");
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
        if (base._Site.SiteOptions["Opt_Experts_Status_ON"].ToBoolean(false) && !base.IsPostBack)
        {
            this.BindData(this.cblLotteryListZC, "and [TypeID]=2");
            this.BindData(this.cblLotteryListFC, " and ID in (5,58,59,6,13)");
        }
    }
}

