using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Shove;
using System.Web.UI.HtmlControls;

public partial class TrendCharts_SSQ_SSQ_3FQ : System.Web.UI.Page
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
            for (int j = 1; j < 0x22; j++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, -1) != 0)
                {
                    int num3 = _Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, -1);
                    HtmlImage child = new HtmlImage
                    {
                        Src = "../Images/red_" + num3.ToString() + ".gif"
                    };
                    this.GridView1.Rows[i].Cells[j].Controls.Add(child);
                }
                else
                {
                    this.GridView1.Rows[i].Cells[j].Text = "&nbsp;";
                }
            }
            for (int k = 0x22; k < 0x2b; k++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[k].Text, -1) == 0)
                {
                    this.GridView1.Rows[i].Cells[k].Text = "&nbsp;";
                }
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td height='30' bgcolor='#f7f7f7'>预选行</td>");
        for (int i = 1; i < 0x22; i++)
        {
            output.Write("<td onClick=Style(this,'../Images/red_" + i + ".gif') style='cursor:pointer' align='center' valign='center'>&nbsp;</td>");
        }
        for (int j = 1; j < 10; j++)
        {
            output.Write("<td>&nbsp;</td>");
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3'　 bgcolor='#E8F1F8'>期号</td>");
        output.Write("<td colspan='11' bgcolor='#E8F1F8' height='20'>一区</td>");
        output.Write("<td colspan='11' bgcolor='#E8F1F8'>二区</td>");
        output.Write("<td colspan='11' bgcolor='#E8F1F8'>三区</td>");
        output.Write("<td colspan='9'　 bgcolor='#E8F1F8'>区间 出项个数</td>");
        output.Write("<tr  bgcolor='#E8F1F8' height='18px'>");
        output.Write("<td colspan='5'>一区左</td>");
        output.Write("<td colspan='6'>一区右</td>");
        output.Write("<td colspan='5'>二区左</td>");
        output.Write("<td colspan='6'>二区右</td>");
        output.Write("<td colspan='5'>三区左</td>");
        output.Write("<td colspan='6'>三区右</td>");
        output.Write("<td rowspan='2'>一区</td>");
        output.Write("<td rowspan='2'>二区</td>");
        output.Write("<td rowspan='2'>三区</td>");
        output.Write("<td rowspan='2'>一区左</td>");
        output.Write("<td rowspan='2'>一区右</td>");
        output.Write("<td rowspan='2'>二区左</td>");
        output.Write("<td rowspan='2'>二区右</td>");
        output.Write("<td rowspan='2'>三区左</td>");
        output.Write("<td rowspan='2'>三区右</td>");
        output.Write("<tr  bgcolor='#F7F7F7' height='18px'>");
        for (int i = 1; i < 10; i++)
        {
            output.Write("<td align='center' valign='center'><strong>");
            output.Write(0 + i.ToString() + "</strong></span></td>");
        }
        for (int j = 10; j < 0x22; j++)
        {
            output.Write("<td  align='center' valign='center'><strong>");
            output.Write(j.ToString() + "</strong></td>");
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
        // table = new TrendChart().SSQ_3QFB_Select(30, "", "", ref result);
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
