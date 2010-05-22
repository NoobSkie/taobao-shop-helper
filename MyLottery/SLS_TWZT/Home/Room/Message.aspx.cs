using ASP;
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

public partial class Home_Room_Message : RoomPageBase, IRequiresSessionState
{

    private void BindDataForSystemMessage()
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("MemberMessage_System" + base._User.ID.ToString());
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = MSSQL.Select("select '系统消息' as SourceUserName,ID,DateTime,Content,isRead from T_StationSMS where isShow = 1 and Type = 2 and AimID = " + base._User.ID.ToString() + " order by isRead asc", new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Room_Message");
                return;
            }
            Shove._Web.Cache.SetCache("MemberMessage_System" + base._User.ID.ToString(), cacheAsDataTable);
        }
        PF.DataGridBindData(this.g1, cacheAsDataTable, this.gPager1);
    }

    protected void cbisRead_CheckedChanged(object sender, EventArgs e)
    {
        string str = ((CheckBox)sender).ClientID.Substring(7);
        int num = _Convert.StrToInt(str.Substring(0, str.IndexOf("_")), -1) - 3;
        if (num > this.gPager1.PageSize)
        {
            num = num % this.gPager1.PageSize;
        }
        this.UpdateStationSMSStatus(_Convert.StrToInt(this.g1.Items[num].Cells[5].Text, -1));
    }

    protected void g1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            long num = _Convert.StrToLong(e.Item.Cells[5].Text, 0L);
            if (MSSQL.ExecuteNonQuery("update T_StationSMS set isShow = 0 where [ID] = " + num.ToString(), new MSSQL.Parameter[0]) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Room_Message");
            }
            else
            {
                Shove._Web.Cache.ClearCache("MemberMessage_System" + base._User.ID.ToString());
                this.BindDataForSystemMessage();
            }
        }
        else if (e.CommandName == "View")
        {
            long num3 = _Convert.StrToLong(e.Item.Cells[5].Text, 0L);
            base.Response.Redirect("ViewMessage.aspx?ID=" + num3);
        }
    }

    protected void g1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        CheckBox box = (CheckBox)e.Item.Cells[4].FindControl("cbisRead");
        if (box != null)
        {
            box.Checked = _Convert.StrToBool(e.Item.Cells[6].Text, false);
            if (!box.Checked)
            {
                box.Enabled = true;
            }
        }
        e.Item.Cells[1].Text = _String.Cut(e.Item.Cells[1].Text, 20);
    }

    protected void gPager1_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindDataForSystemMessage();
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
            this.BindDataForSystemMessage();
        }
    }

    private void UpdateStationSMSStatus(int id)
    {
        try
        {
            string commandText = "update T_StationSMS set isRead = 1 where ID = @ID";
            MSSQL.ExecuteNonQuery(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, id) });
            Shove._Web.Cache.ClearCache("MemberMessage_System" + base._User.ID.ToString());
            this.BindDataForSystemMessage();
        }
        catch (Exception exception)
        {
            new Log("System").Write("短消息页面Message.aspx，修改消息状态出错" + exception.Message);
        }
    }
}

