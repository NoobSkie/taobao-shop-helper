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

public partial class Home_Room_Chase : RoomPageBase, IRequiresSessionState
{
    public string IframeUrl;
    public string LotteryID;
    public string LotteryName;
    public string PlayTypeName;

    private void BindPlay()
    {
        DataTable table = new Views.V_PlayTypes().Open("ID, LotteryID, Name, LotteryName, BuyFileName, Price", "LotteryID=" + _Convert.StrToInt(this.LotteryID, -1).ToString(), "[ID]");
        if ((table == null) || (table.Rows.Count == 0))
        {
            PF.GoError(1, "此玩法没有开通", "Room_Chase");
        }
        else
        {
            this.LotteryName = table.Rows[0]["LotteryName"].ToString();
            this.PlayTypeName = table.Rows[0]["Name"].ToString();
            this.IframeUrl = table.Rows[0]["BuyFileName"].ToString().Replace("Surrogate", "ChasePage").Replace("[Lottery]", table.Rows[0]["LotteryID"].ToString()).Replace("[PlayType]", table.Rows[0]["ID"].ToString());
            int num2 = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string text = this.LbPlay.Text;
                this.LbPlay.Text = text + "<a href =" + table.Rows[i]["BuyFileName"].ToString().Replace("Surrogate", "ChasePage").Replace("[Lottery]", table.Rows[i]["LotteryID"].ToString()).Replace("[PlayType]", table.Rows[i]["ID"].ToString()) + "&Price=" + table.Rows[i]["Price"].ToString() + " target='iframeplay' class='hei'>" + table.Rows[i]["Name"].ToString() + "追号</a>&nbsp;&nbsp;&nbsp;&nbsp;";
                if (((num2 % 6) == 0) && (num2 > 0))
                {
                    this.LbPlay.Text = this.LbPlay.Text.Trim() + " </br>";
                }
                num2++;
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
            this.LotteryID = Utility.GetRequest("LotteryID");
            this.BindPlay();
        }
    }
}

