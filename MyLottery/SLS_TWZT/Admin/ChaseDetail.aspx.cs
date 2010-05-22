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

public partial class Admin_ChaseDetail : AdminPageBase, IRequiresSessionState
{


    private void BindData(int ChaseID)
    {
        DataTable dt = new Views.V_ChaseTasksTotal().Open("", "ID = " + ChaseID.ToString(), "");
        if ((dt == null) || (dt.Rows.Count < 1))
        {
            PF.GoError(4, "没有追号！", "Admin_ChaseDetail");
        }
        else
        {
            DataRow row = dt.Rows[0];
            this.labChase_id.Text = ChaseID.ToString();
            this.labTitle.Text = row["Title"].ToString().Trim();
            this.Label1.Text = row["LotteryName"].ToString();
            this.tbInitiateUserID.Value = row["UserID"].ToString();
            this.Label3.Text = row["Description"].ToString();
            double num = _Convert.StrToDouble(row["SumMoney"].ToString(), 0.0);
            int num2 = _Convert.StrToInt(row["SumIsuseNum"].ToString(), 0);
            int num3 = _Convert.StrToInt(row["BuyedIsuseNum"].ToString(), 0);
            int num4 = _Convert.StrToInt(row["QuashedIsuseNum"].ToString(), 0);
            double num5 = _Convert.StrToDouble(row["BuyedMoney"].ToString(), 0.0);
            double num6 = _Convert.StrToDouble(row["QuashedMoney"].ToString(), 0.0);
            try
            {
                double num1 = num / ((double)num2);
            }
            catch
            {
                PF.GoError(4, "投注记录有错误", "Admin_ChaseDetail");
                return;
            }
            this.Label4.Text = "</font>; 共<font color='red'>" + num2.ToString() + "</font>期<font color='red'>" + num.ToString("N") + "</font>元; 已完成<font color='red'>" + num3.ToString() + "</font>期<font color='red'>" + num5.ToString("N") + "</font>元; 已取消<font color='red'>" + num4.ToString() + "</font>期<font color='red'>" + num6.ToString("N") + "</font>元。";
            this.btnQuash.Enabled = num2 > (num3 + num4);
            dt = new Views.V_ChaseTaskDetails().Open("", "ChaseTaskID = " + ChaseID.ToString(), "[DateTime]");
            if (dt != null)
            {
                this.LbPlayTypeName.Text = dt.Rows[0]["PlayTypeName"].ToString();
                PF.DataGridBindData(this.g, dt);
            }
            else
            {
                PF.GoError(4, "没有追号记录", "Room_ChaseDetail");
            }
        }
    }

    protected void btnQuash_Click(object sender, EventArgs e)
    {
        int chaseID = _Convert.StrToInt(this.labChase_id.Text, 0);
        if (chaseID < 1)
        {
            PF.GoError(7, "没有记录!", "Admin_ChaseDetail");
        }
        else
        {
            long num2 = _Convert.StrToLong(this.tbInitiateUserID.Value, -1L);
            Users users = new Users(base._Site.ID)[base._Site.ID, num2];
            if (users == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_ChaseDetail");
            }
            else
            {
                string returnDescription = "";
                int num3 = users.QuashChaseTask((long)chaseID, true, ref returnDescription);
                if ((returnDescription != "") || (num3 != 0))
                {
                    PF.GoError(4, returnDescription, "Admin_ChaseDetail");
                }
                else
                {
                    this.BindData(chaseID);
                }
            }
        }
    }

    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "QuashIsuse")
        {
            int num = _Convert.StrToInt(e.Item.Cells[10].Text, 0);
            if (num < 1)
            {
                PF.GoError(7, "找不到追号记录", "Admin_ChaseDetail");
            }
            else
            {
                long num2 = _Convert.StrToLong(this.tbInitiateUserID.Value, -1L);
                Users users = new Users(base._Site.ID)[base._Site.ID, num2];
                if (users == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试", "Admin_ChaseDetail");
                }
                else
                {
                    string returnDescription = "";
                    int num3 = users.QuashChaseTaskDetail((long)num, true, ref returnDescription);
                    if ((returnDescription != "") || (num3 != 0))
                    {
                        PF.GoError(4, returnDescription, "Admin_ChaseDetail");
                    }
                    else
                    {
                        int chaseID = _Convert.StrToInt(this.labChase_id.Text, 0);
                        if (chaseID < 1)
                        {
                            PF.GoError(7, "没有记录!", "Admin_ChaseDetail");
                        }
                        else
                        {
                            this.BindData(chaseID);
                        }
                    }
                }
            }
        }
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            TableCell cell1 = e.Item.Cells[0];
            cell1.Text = cell1.Text + "期";
            e.Item.Cells[1].Text = _Convert.ToHtmlCode(e.Item.Cells[1].Text);
            e.Item.Cells[2].Text = "倍数:" + e.Item.Cells[2].Text;
            double num = _Convert.StrToDouble(e.Item.Cells[3].Text, 0.0);
            e.Item.Cells[3].Text = (num == 0.0) ? "" : num.ToString("N");
            int num2 = _Convert.StrToInt(e.Item.Cells[7].Text, 0);
            long num3 = _Convert.StrToLong(e.Item.Cells[9].Text, -1L);
            switch (num2)
            {
                case 0:
                    if (num3 > 0L)
                    {
                        e.Item.Cells[4].Text = "<font color='#330099'>已成功</font>";
                        e.Item.Cells[5].Text = "<a href='../Home/Room/Scheme.aspx?id=" + num3.ToString() + "' target='_blank'><font color=\"#330099\">查看方案</Font></a>";
                        return;
                    }
                    e.Item.Cells[4].Text = "<font color='Red'>进行中</font>";
                    ((Button)e.Item.Cells[6].FindControl("btnQuashIsuse")).Enabled = true;
                    return;

                case 2:
                    e.Item.Cells[4].Text = "系统撤单";
                    return;

                default:
                    e.Item.Cells[4].Text = "用户撤消";
                    return;
            }
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
        int chaseID = _Convert.StrToInt(Utility.GetRequest("id"), -1);
        if (chaseID < 0)
        {
            base.Response.Redirect("ChaseList.aspx");
        }
        else if (!base.IsPostBack)
        {
            this.BindData(chaseID);
        }
    }


}

