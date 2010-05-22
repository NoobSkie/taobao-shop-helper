using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using SLS;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Web_Score : SitePageBase, IRequiresSessionState
{
    public string dingZhi = "";
    private bool IsShow;
    public int LotteryID = -1;
    public int Source = -1;

    private void BindData(long UserID, int LotteryID)
    {
        string returnDescription = "";
        string str2 = "";
        Users users = new Users(base._Site.ID)
        {
            ID = UserID
        };
        if (users.GetUserInformationByID(ref returnDescription) != 0)
        {
            PF.GoError(1, returnDescription, base.GetType().FullName);
        }
        else
        {
            this.labUserName.Text = users.Name;
            this.labUserRegisterTime.Text = users.RegisterTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.labUserType.Text = (users.UserType == 1) ? "普通会员" : ((users.UserType == 3) ? "VIP" : "高级会员");
            this.dingZhi = string.Concat(new object[] { "&FollowUserID=", UserID, "&FollowUserName=", HttpUtility.UrlEncode(users.Name), "\"" });
            DataTable cacheAsDataTable = null;
            if (this.Source == -1)
            {
                cacheAsDataTable = new Tables.T_Lotteries().Open("[ID], [Name]", "[id] = " + LotteryID.ToString(), "");
            }
            else if (this.Source == 1)
            {
                cacheAsDataTable = MSSQL.Select("Select ID,Name from  T_Lotteries where ID=" + LotteryID.ToString(), new MSSQL.Parameter[0]);
            }
            else if (this.Source == 2)
            {
                cacheAsDataTable = MSSQL.Select("Select ID,Name from  T_Lotteries where ID=" + LotteryID.ToString(), new MSSQL.Parameter[0]);
            }
            else
            {
                cacheAsDataTable = new Tables.T_Lotteries().Open("[ID], [Name]", "[id] = " + LotteryID.ToString(), "");
            }
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
            }
            else
            {
                if (this.cbShowWin.Checked)
                {
                    str2 = " where WinMoney>0";
                }
                string key = string.Concat(new object[] { users.ID, "_", LotteryID.ToString(), "_Home_Web_Score_", this.cbShowWin.Checked });
                cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
                if ((cacheAsDataTable == null) || this.IsShow)
                {
                    string str5 = "select * from (";
                    cacheAsDataTable = MSSQL.Select(str5 + this.GetSQL(UserID, LotteryID, "", ",source=1") + ") d  " + str2 + "  order by TopMoney desc,id desc", new MSSQL.Parameter[0]);
                    if (cacheAsDataTable == null)
                    {
                        PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
                        return;
                    }
                    Shove._Web.Cache.SetCache(key, cacheAsDataTable, 300);
                }
                PF.DataGridBindData(this.g, cacheAsDataTable, this.gPager);
                this.gPager.Visible = true;
            }
        }
    }

    protected void btn_All_Click(object sender, ImageClickEventArgs e)
    {
        if (((this.LotteryID == 0x1d) || (this.LotteryID == 0x3d)) || (this.LotteryID == 0x3e))
        {
            this.ResponseTailor("followScheme(-1);$Id(\"iframeFollowScheme\").src=\"FollowFriendSchemeAdd.aspx?LotteryID=-1&FollowFriendID=-1");
        }
        else
        {
            this.ResponseTailor("followScheme(-1);$Id(\"iframeFollowScheme\").src=\"../Home/Room/FollowFriendSchemeAdd.aspx?LotteryID=-1&FollowFriendID=-1");
        }
    }

    protected void btn_Single_Click(object sender, ImageClickEventArgs e)
    {
        if (((this.LotteryID == 0x1d) || (this.LotteryID == 0x3d)) || (this.LotteryID == 0x3e))
        {
            this.ResponseTailor(string.Concat(new object[] { "followScheme(", this.LotteryID, ");$Id(\"iframeFollowScheme\").src=\"FollowFriendSchemeAdd.aspx?LotteryID=", this.LotteryID, "&DzLotteryID=", this.LotteryID }));
        }
        else
        {
            this.ResponseTailor(string.Concat(new object[] { "followScheme(", this.LotteryID, ");$Id(\"iframeFollowScheme\").src=\"../Home/Room/FollowFriendSchemeAdd.aspx?LotteryID=", this.LotteryID, "&DzLotteryID=", this.LotteryID }));
        }
    }

    protected void cbShowWin_CheckedChanged(object sender, EventArgs e)
    {
        this.IsShow = true;
        this.BindData(_Convert.StrToLong(Utility.GetRequest("id"), -1L), this.LotteryID);
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            switch (_Convert.StrToInt(e.Item.Cells[11].Text, 0))
            {
                case 1:
                    e.Item.Cells[1].Text = "<a href='../Room/Scheme.aspx?id=" + e.Item.Cells[10].Text + "' target=_blank>" + e.Item.Cells[1].Text + "</a>";
                    break;

                case 2:
                    e.Item.Cells[1].Text = "<a href='../Room/Scheme.aspx?Source=1&id=" + e.Item.Cells[10].Text + "' target=_blank>" + e.Item.Cells[1].Text + "</a>";
                    break;

                case 3:
                    e.Item.Cells[1].Text = "<a href='../Room/Scheme.aspx?Source=2&id=" + e.Item.Cells[10].Text + "' target=_blank>" + e.Item.Cells[1].Text + "</a>";
                    break;
            }
            string text = e.Item.Cells[3].Text;
            if (text.Length > 0x19)
            {
                text = text.Substring(0, 0x17) + "..";
            }
            e.Item.Cells[3].Text = text;
            double num2 = _Convert.StrToDouble(e.Item.Cells[4].Text, 0.0);
            e.Item.Cells[4].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            num2 = _Convert.StrToDouble(e.Item.Cells[5].Text, 0.0);
            e.Item.Cells[5].Text = (num2 == 0.0) ? "" : num2.ToString("N");
            short num3 = _Convert.StrToShort(e.Item.Cells[7].Text, 0);
            bool flag = _Convert.StrToBool(e.Item.Cells[8].Text, false);
            int num4 = _Convert.StrToInt(e.Item.Cells[9].Text, 0);
            if (flag)
            {
                e.Item.Cells[6].Text = "<font color='red'>已成功</font>";
            }
            else if (num3 != 0)
            {
                e.Item.Cells[6].Text = "未成功";
            }
            else if (num4 < 100)
            {
                e.Item.Cells[6].Text = "未成功";
            }
            else
            {
                e.Item.Cells[6].Text = "<font color='blue'>未录入</font>";
            }
        }
    }

    private string GetSQL(long userID, int lotteryID, string dataBaseName, string source)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("(select  WinMoneyNoWithTax as TopMoney,").AppendLine("IsuseName, SchemeNumber, PlayTypeName, Title, [Money],WinMoney, QuashStatus, Buyed, Schedule, id" + source).AppendLine(" from " + dataBaseName + "V_Schemes where InitiateUserID = " + userID.ToString() + " and LotteryID = " + lotteryID.ToString() + " and SystemEndTime < GetDate())");
        return builder.ToString();
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        long userID = -1L;
        try
        {
            userID = _Convert.StrToLong(Utility.GetRequest("id"), -1L);
        }
        catch
        {
        }
        if (userID < 1L)
        {
            PF.GoError(1, "参数错误", base.GetType().FullName);
        }
        else if (!new Lottery().ValidID(this.LotteryID))
        {
            PF.GoError(1, "参数错误！(彩种)", base.GetType().FullName);
        }
        else
        {
            this.BindData(userID, this.LotteryID);
        }
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        long userID = -1L;
        try
        {
            userID = _Convert.StrToLong(Utility.GetRequest("id"), -1L);
        }
        catch
        {
        }
        if (userID < 1L)
        {
            PF.GoError(1, "参数错误", base.GetType().FullName);
        }
        else if (!new Lottery().ValidID(this.LotteryID))
        {
            PF.GoError(1, "参数错误！(彩种)", base.GetType().FullName);
        }
        else
        {
            this.BindData(userID, this.LotteryID);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        long userID = -1L;
        try
        {
            userID = _Convert.StrToLong(Utility.GetRequest("id"), -1L);
            this.Source = _Convert.StrToInt(Utility.GetRequest("Source"), -1);
        }
        catch
        {
        }
        if (userID < 1L)
        {
            PF.GoError(1, "参数错误", base.GetType().FullName);
            return;
        }
        if (!base.IsPostBack)
        {
            try
            {
                this.LotteryID = _Convert.StrToInt(Utility.GetRequest("LotteryID"), -1);
                goto Label_0126;
            }
            catch
            {
                goto Label_0126;
            }
        }
        ControlCollection controls = this.rbList.Controls;
        for (int i = 0; i < controls.Count; i++)
        {
            if (((controls[i].ID != null) && !(controls[i].ID == "")) && (controls[i].ID.IndexOf("rb") > -1))
            {
                CheckBox box = controls[i] as CheckBox;
                if (box.Checked)
                {
                    this.LotteryID = _Convert.StrToInt(box.ID.Substring(2), this.LotteryID);
                    break;
                }
            }
        }
    Label_0126:
        if (!new Lottery().ValidID(this.LotteryID))
        {
            PF.GoError(1, "参数错误！(彩种)", base.GetType().FullName);
        }
        else
        {
            string request = Utility.GetRequest("__EVENTTARGET");
            if (!request.Equals("cbShowWin") && !request.Equals("gPager"))
            {
                this.BindData(userID, this.LotteryID);
            }
        }
    }

    private void ResponseTailor(string headMethod)
    {
        long num = -1L;
        try
        {
            num = _Convert.StrToLong(Utility.GetRequest("id"), -1L);
        }
        catch
        {
        }
        if (num < 1L)
        {
            PF.GoError(1, "参数错误", base.GetType().FullName);
        }
        else if (!new Lottery().ValidID(this.LotteryID))
        {
            PF.GoError(1, "参数错误！(彩种)", base.GetType().FullName);
        }
        else
        {
            Users users = new Users(base._Site.ID)
            {
                ID = num
            };
            string returnDescription = "";
            if (users.GetUserInformationByID(ref returnDescription) != 0)
            {
                PF.GoError(1, returnDescription, base.GetType().FullName);
            }
            else
            {
                this.dingZhi = Encrypt.EncryptString(PF.GetCallCert(), headMethod + this.dingZhi);
                if (this.LotteryID == 0x1d)
                {
                    base.Response.Redirect("../Room/Buy_SSL.aspx?DZ=" + this.dingZhi);
                }
                else if (this.LotteryID == 0x3e)
                {
                    base.Response.Redirect("../Room/Buy_SYYDJ.aspx?DZ=" + this.dingZhi);
                }
                else if (this.LotteryID == 0x3d)
                {
                    base.Response.Redirect("../Room/Buy_SSC.aspx?DZ=" + this.dingZhi);
                }
                else if (((this.LotteryID == 1) || (this.LotteryID == 2)) || (this.LotteryID == 15))
                {
                    base.Response.Redirect(string.Concat(new object[] { "../Room/Buy_ZC.aspx?LotteryID=", this.LotteryID, "&DZ=", this.dingZhi }));
                }
                else
                {
                    base.Response.Redirect(string.Concat(new object[] { "../Room/Buy.aspx?LotteryID=", this.LotteryID, "&ID=", this.LotteryID, "&DZ=", this.dingZhi }));
                }
            }
        }
    }
}

