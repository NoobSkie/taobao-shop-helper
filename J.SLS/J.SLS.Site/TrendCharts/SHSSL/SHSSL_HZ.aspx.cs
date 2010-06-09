using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shove;
using System.Drawing;
using System.Data;

public partial class TrendCharts_SHSSL_SHSSL_HZ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.GridViewBind();
            this.ColorBind();
            this.GridView1.Style["border-collapse"] = "";
        }
    }

    protected void ColorBind()
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            for (int j = 3; j < 0x1f; j++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, -1) == 0)
                {
                    this.GridView1.Rows[i].Cells[j].Text = (j - 3).ToString();
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[j].Font.Bold = true;
                }
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        for (int i = 1; i < 4; i++)
        {
            output.Write("<tr>");
            output.Write("<td height='22'>预选");
            output.Write(i.ToString() + "</td>");
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            for (int k = 0; k < 0x1c; k++)
            {
                output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>");
                output.Write(k.ToString() + "</td>");
            }
        }
        output.Write("<tr align='center' valign='center' bgcolor='#e8f1f8' height='18px'>");
        output.Write("<td rowspan='3'　>期号</td>");
        output.Write("<td rowspan='3'　>开奖号码</td>");
        output.Write("<td rowspan='2' >和值</td>");
        for (int j = 0; j < 0x1c; j++)
        {
            output.Write("<td ><font color='blue'>");
            output.Write(j.ToString() + "</font></td>");
        }
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8' >");
        output.Write("<td colspan='28' height='18px'>位置分布</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8'>");
        output.Write("<td colspan='29'  height='18px'><strong><font color='red'>和值走势</font></strong></td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>开奖号码</td>");
        output.Write("<td colspan='29' align='center' valign='middle' bgcolor='#e8f1f8' height='18px'><strong><font color='red'>和值走势</font></strong></td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8' height='18px'>");
        output.Write("<td rowspan='2'>和值</td>");
        output.Write("<td colspan='28' height='18px'>位置分布</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8'>");
        for (int i = 0; i < 0x1c; i++)
        {
            output.Write("<td align='center' valign='middle' bgcolor='#e8f1f8' height='18px'><font color='blue'>");
            output.Write(i.ToString() + "</font></td>");
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.SetRenderMethodDelegate(new RenderMethod(this.DrawGridFooter));
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.SetRenderMethodDelegate(new RenderMethod(this.DrawGridHeader));
        }
    }

    protected void GridViewBind()
    {
        string result = "";
        DataTable table = new DataTable();
        //table = new TrendChart().SHSSL_HZ_Select(30, "", "", ref result);
        if ((table != null) && (table.Rows.Count >= 1))
        {
            int count = table.Rows.Count;
            this.tb1.Text = table.Rows[0]["Isuse"].ToString();
            this.tb2.Text = table.Rows[count - 1]["Isuse"].ToString();
        }
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
    }
}
