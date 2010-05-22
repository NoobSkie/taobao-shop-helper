using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Agent_CardPassword_QueryCardPassword : CardPasswordPageBase, IRequiresSessionState
{


    private void BindData()
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("CardPassword_QueryCardPassword_" + base._CardPasswordAgentUser.ID.ToString());
        if (cacheAsDataTable == null)
        {
            string condition = "AgentID = " + base._CardPasswordAgentUser.ID.ToString();
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
            cacheAsDataTable = new Tables.T_CardPasswords().Open("ID, Money, Period, State", condition, "");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "CardPassword_QueryCardPassword");
                return;
            }
            Shove._Web.Cache.SetCache("CardPassword_QueryCardPassword_" + base._CardPasswordAgentUser.ID.ToString(), cacheAsDataTable);
        }
        PF.DataGridBindData(this.g, cacheAsDataTable, this.gPager);
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable("CardPassword_QueryCardPassword_" + base._CardPasswordAgentUser.ID.ToString());
        if (cacheAsDataTable == null)
        {
            string condition = "AgentID = " + base._CardPasswordAgentUser.ID.ToString();
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
            cacheAsDataTable = new Tables.T_CardPasswords().Open("ID, Money, Period, State", condition, "");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "CardPassword_QueryCardPassword");
                return;
            }
            Shove._Web.Cache.SetCache("CardPassword_QueryCardPassword_" + base._CardPasswordAgentUser.ID.ToString(), cacheAsDataTable);
        }
        cacheAsDataTable.Columns.Add("Number", typeof(string));
        CardPassword password = new CardPassword();
        for (int i = 0; i < cacheAsDataTable.Rows.Count; i++)
        {
            cacheAsDataTable.Rows[i]["Number"] = "[" + password.GenNumber(PF.GetCallCert(), base._CardPasswordAgentUser.ID, _Convert.StrToLong(cacheAsDataTable.Rows[i]["ID"].ToString(), -1L)) + "]";
            cacheAsDataTable.AcceptChanges();
        }
        cacheAsDataTable.Columns.Remove(cacheAsDataTable.Columns[0]);
        string str2 = "T_CardPassword.xls";
        HttpResponse response = this.Page.Response;
        response.AppendHeader("Content-Disposition", "attachment;filename=" + str2);
        base.Response.ContentType = "application/ms-excel";
        response.ContentEncoding = Encoding.GetEncoding("gb2312");
        foreach (DataColumn column in cacheAsDataTable.Columns)
        {
            response.Write(column.ColumnName + "\t");
        }
        response.Write("\n");
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            for (int j = 0; j < cacheAsDataTable.Columns.Count; j++)
            {
                response.Write(row[j].ToString() + "\t");
            }
            response.Write("\n");
        }
        response.End();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Shove._Web.Cache.ClearCache("CardPassword_QueryCardPassword_" + base._CardPasswordAgentUser.ID.ToString());
        this.BindData();
    }

    protected void g_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            e.Item.Cells[0].Text = new CardPassword().GenNumber(PF.GetCallCert(), _Convert.StrToInt(base._CardPasswordAgentUser.ID.ToString(), 0), _Convert.StrToLong(e.Item.Cells[4].Text, 0L));
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
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindData();
        }
    }


}

