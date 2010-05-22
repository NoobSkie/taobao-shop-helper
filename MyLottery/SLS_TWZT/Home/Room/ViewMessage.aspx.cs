using ASP;
using Shove;
using Shove._Web;
using Shove.Database;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_ViewMessage : RoomPageBase, IRequiresSessionState
{

    private void bindData()
    {
        long num = _Convert.StrToLong(Utility.GetRequest("ID"), -1L);
        DataTable table = MSSQL.Select("select Content from T_StationSMS where isShow = 1 and Type = 2 and AimID = " + base._User.ID.ToString() + " and ID = " + num.ToString(), new MSSQL.Parameter[0]);
        if ((table == null) || (table.Rows.Count == 0))
        {
            PF.GoError(7, "你要查看的站内信不存在或数据已被删除！", base.GetType().BaseType.FullName);
        }
        else
        {
            this.lbAim.Text = "系统消息";
            this.lbContent.Text = table.Rows[0]["Content"].ToString();
            try
            {
                string commandText = "update T_StationSMS set isRead = 1 where ID = @ID";
                MSSQL.ExecuteNonQuery(commandText, new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, num) });
                Shove._Web.Cache.ClearCache("MemberMessage_System" + base._User.ID.ToString());
            }
            catch (Exception exception)
            {
                new Log("System").Write("查看短消息页面ViewMessage.aspx，修改消息状态出错" + exception.Message);
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
            this.bindData();
        }
    }
}

