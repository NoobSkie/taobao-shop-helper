using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class Admin_RecallingRecord : AdminPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    #region Web 窗体设计器生成的代码

    override protected void OnInit(EventArgs e)
    {
        RequestLoginPage = this.Request.Url.AbsoluteUri;

        RequestCompetences = Competences.BuildCompetencesList(Competences.EditNews, Competences.QueryData);

        base.OnInit(e);
    }

    #endregion

    private void BindData()
    {
        string Key = "Admin_RecallingRecord_BindData";

        DataTable dt = Shove._Web.Cache.GetCacheAsDataTable(Key);

        if (dt == null)
        {
            string sql = @"select b.ID,a.State,LotteryID,Level,InitiateUserID, LotteryName,InitiateName,Money,WinMoney,
                WinMoney/Money as Win from T_RecallingAllBuyStar a inner join V_Schemes  b 
                on a.SchemesID = b.ID and WinMoney>0 and Buyed = 1 and IsOpened = 1 and a.State = 0
                order by WinMoney desc ";

            dt = Shove.Database.MSSQL.Select(sql);

            if (dt == null)
            {
                return;
            }

            Shove._Web.Cache.SetCache(Key, dt, 6000);
        }

        PF.DataGridBindData(g, dt, gPager);
    }

    protected void gPager_PageWillChange(object Sender, Shove.Web.UI.PageChangeEventArgs e)
    {
        BindData();
    }

    protected void gPager_SortBefore(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        BindData();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        string scheme = tbScheme.Text.Trim();

        if (scheme == "")
        {
            Shove._Web.JavaScript.Alert(this.Page, "请输入方案地址！");

            return;
        }

        Regex regex = new Regex(@"([\w-]+\.)+[\w-]+.([^a-z])(/[\w- ./?%&=]*)?|[a-zA-Z0-9\-\.][\w-]+.([^a-z])(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        Match m = regex.Match(scheme);

        if (!m.Success)
        {
            Shove._Web.JavaScript.Alert(this, "地址格式错误，请仔细检查。");

            return;
        }

        scheme = scheme.ToLower();

        if (!scheme.Contains("scheme.aspx?id="))
        {
            Shove._Web.JavaScript.Alert(this, "方案地址格式错误，请仔细检查。");

            return;
        }
        
        scheme = scheme.Split(new string[] {"scheme.aspx?id="},StringSplitOptions.None)[1].Trim().Split('&')[0].Trim();

        //if (new DAL.Tables.T_Schemes().GetCount("ID=" + scheme + " and WinMoney>0") < 1)
        //{
        //    Shove._Web.JavaScript.Alert(this, "方案地址不存在或方案未中奖。");

        //    return;
        //}


        DAL.Tables.T_RecallingAllBuyStar t = new DAL.Tables.T_RecallingAllBuyStar();

        if (t.GetCount("SchemesID=" + scheme + "") > 0)
        {
            Shove._Web.JavaScript.Alert(this.Page, "此方案已存在！");

            return;
        }

        t.SchemesID.Value = scheme;
        t.Insert();

        Shove._Web.Cache.ClearCache("Admin_RecallingRecord_BindData");

        Shove._Web.JavaScript.Alert(this.Page, "操作成功！", "RecallingRecord.aspx");
    }
    protected void g_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            DAL.Tables.T_RecallingAllBuyStar t = new DAL.Tables.T_RecallingAllBuyStar();

            t.Delete("SchemesID=" + e.Item.Cells[6].Text + "");

            Shove._Web.Cache.ClearCache("Admin_RecallingRecord_BindData");

            Shove._Web.JavaScript.Alert(this.Page, "删除成功！", "RecallingRecord.aspx");
        }
    }
}
