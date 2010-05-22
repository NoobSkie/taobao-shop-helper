using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_CardPasswordManage : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("CardPassword_QueryCardPassword_All");
        if (cacheAsDataTable == null)
        {
            string condition = "";
            if (this.rbExp.Checked)
            {
                condition = condition + "state = -1";
            }
            else if (this.rbUse.Checked)
            {
                condition = condition + "state = 1";
            }
            else if (this.rbNoUse.Checked)
            {
                condition = condition + "state = 0";
            }
            if (this.tbCardPasswordID.Text.Trim() != "")
            {
                int agentID = -1;
                condition = condition + " and ID = " + new CardPassword().GetCardPasswordID(PF.GetCallCert(), Utility.FilteSqlInfusion(this.tbCardPasswordID.Text.Trim()), ref agentID).ToString();
            }
            if (this.tbDateTime.Text.Trim() != "")
            {
                DateTime time = DateTime.Parse("1981-01-01");
                try
                {
                    time = DateTime.Parse(this.tbDateTime.Text.Trim());
                }
                catch
                {
                    JavaScript.Alert(this.Page, "时间格式填写有错误！");
                    return;
                }
                condition = condition + " and DateTime > '" + time.ToString() + "'";
            }
            cacheAsDataTable = new Views.V_CardPasswordDetails().Open("ID, Money, Period, State, AgentID, UseDateTime, RealityName", condition, "");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "CardPassword_QueryCardPassword");
                return;
            }
            Shove._Web.Cache.SetCache("CardPassword_QueryCardPassword_All", cacheAsDataTable);
        }
        PF.DataGridBindData(this.g, cacheAsDataTable, this.gPager);
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        base.Response.ClearContent();
        base.Response.Charset = "GB2312";
        base.Response.ContentEncoding = Encoding.GetEncoding("GB2312");
        base.Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
        base.Response.ContentType = "application/excel";
        StringWriter writer = new StringWriter();
        HtmlTextWriter writer2 = new HtmlTextWriter(writer);
        this.g.RenderControl(writer2);
        base.Response.Write(writer.ToString());
        base.Response.End();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Shove._Web.Cache.ClearCache("CardPassword_QueryCardPassword_All");
        this.BindData();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[0].Text = new CardPassword().GenNumber(PF.GetCallCert(), _Convert.StrToInt(e.Item.Cells[7].Text, 0), _Convert.StrToLong(e.Item.Cells[6].Text, 0L));
            e.Item.Cells[1].Text = _Convert.StrToDouble(e.Item.Cells[1].Text, 0.0).ToString("N");
            switch (e.Item.Cells[2].Text)
            {
                case "-1":
                    e.Item.Cells[2].Text = "<font color='blue'>已过期</font>";
                    return;

                case "0":
                    e.Item.Cells[2].Text = "未使用";
                    return;

                case "1":
                    e.Item.Cells[2].Text = "<font color='red'>已使用</font>";
                    break;
            }
        }
    }

    protected void gPager_PageWillChange(object Sender, PageChangeEventArgs e)
    {
        this.BindData();
    }

    protected void gPager_SortBefore(object source, DataGridSortCommandEventArgs e)
    {
        this.BindData();
    }

    protected override void OnInit(EventArgs e)
    {
        base.isRequestLogin = true;
        base.RequestLoginPage = "Admin/CardPasswordManage.aspx";
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Finance" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }


}

