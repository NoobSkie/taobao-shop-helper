using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Home_Web_DownloadSchemeFile : SitePageBase, IRequiresSessionState
{

    private void BindData()
    {
        long schemeID = _Convert.StrToLong(Utility.GetRequest("id"), -1L);
        if (schemeID < 0L)
        {
            PF.GoError(1, "参数错误", base.GetType().FullName);
        }
        else
        {
            DataTable table = new Tables.T_Schemes().Open("InitiateUserID,LotteryNumber", "SiteID = " + base._Site.ID.ToString() + " and [ID] = " + schemeID.ToString(), "");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
            }
            else if (table.Rows.Count < 1)
            {
                PF.GoError(1, "参数错误", base.GetType().FullName);
            }
            else
            {
                _Convert.StrToLong(table.Rows[0]["InitiateUserID"].ToString(), -1L);
                if ((base._User != null) && !base._User.isCanViewSchemeContent(schemeID))
                {
                    PF.GoError(1, "对不起，您不在此方案的招股对象之内。", base.GetType().FullName);
                }
                else
                {
                    string sourceStr = table.Rows[0]["LotteryNumber"].ToString();
                    base.Response.Write((sourceStr == "") ? "未找到相关数据。" : (_Convert.ToHtmlCode(sourceStr) + "&nbsp;"));
                    base.Response.End();
                }
            }
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
        }
    }
}

