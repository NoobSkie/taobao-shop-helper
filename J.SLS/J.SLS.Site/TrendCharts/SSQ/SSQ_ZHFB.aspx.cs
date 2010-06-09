using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Shove;
using System.Web.UI.HtmlControls;

public partial class TrendCharts_SSQ_SSQ_ZHFB : System.Web.UI.Page
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
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, -1) == 0)
                {
                    HtmlImage child = new HtmlImage
                    {
                        Src = "../Images/red_" + j.ToString() + ".gif"
                    };
                    this.GridView1.Rows[i].Cells[j].Controls.Add(child);
                }
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x22].Text, -1) < 10)
            {
                int num3 = _Convert.StrToInt(this.GridView1.Rows[i].Cells[0x22].Text, 0);
                HtmlImage image2 = new HtmlImage
                {
                    Src = "../Images/blue_" + num3.ToString() + ".gif"
                };
                this.GridView1.Rows[i].Cells[0x22].Controls.Add(image2);
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td bgcolor='#f7f7f7' height='18px'>预选1</td>");
        for (int i = 1; i < 0x22; i++)
        {
            output.Write("<td onClick=Style(this,'../Images/red_" + i + ".gif') style='cursor:pointer' >&nbsp;</td>");
        }
        for (int j = 1; j < 8; j++)
        {
            output.Write("<td>&nbsp;</td>");
        }
        output.Write("<tr  >");
        output.Write("<td  bgcolor='#f7f7f7' height='18px'>预选2</td>");
        for (int k = 1; k < 0x22; k++)
        {
            output.Write("<td onClick=Style(this,'../Images/red_" + k + ".gif') style='cursor:pointer' >&nbsp;</td>");
        }
        for (int m = 1; m < 8; m++)
        {
            output.Write("<td>&nbsp;</td>");
        }
        output.Write("<tr  >");
        output.Write("<td  bgcolor='#f7f7f7' height='18px'>预选3</td>");
        for (int n = 1; n < 0x22; n++)
        {
            output.Write("<td onClick=Style(this,'../Images/red_" + n + ".gif') style='cursor:pointer' >&nbsp;</td>");
        }
        for (int num6 = 1; num6 < 8; num6++)
        {
            output.Write("<td>&nbsp;</td>");
        }
        output.Write("<tr  bgcolor='#E8F1F8'>");
        output.Write("<td rowspan='3' >期号</td>");
        for (int num7 = 1; num7 < 10; num7++)
        {
            output.Write("<td bgcolor='#f7f7f7' height='18px' align='center'>");
            output.Write(0 + num7.ToString() + "</td>");
        }
        for (int num8 = 10; num8 < 0x22; num8++)
        {
            output.Write("<td bgcolor='#f7f7f7' align='center'>");
            output.Write(num8.ToString() + "</td>");
        }
        output.Write("<td rowspan='3' bgcolor='#E8F1F8'　>蓝码</td>");
        output.Write("<td rowspan='3'   >012路</td>");
        output.Write("<td rowspan='2'  >重号</td>");
        output.Write("<td rowspan='2'  >连号</td>");
        output.Write("<td rowspan='2'  >总和</td>");
        output.Write("<td rowspan='2'  >三区比</td>");
        output.Write("<td rowspan='2'  >奇偶比</td>");
        output.Write("<tr  bgcolor='#E8F1F8' height='18px'>");
        output.Write("<td colspan='11' >一区</td>");
        output.Write("<td colspan='11' >二区</td>");
        output.Write("<td colspan='11' >三区</td>");
        output.Write("<tr  bgcolor='#E8F1F8'>");
        output.Write("<td colspan='33'   height='18px'>红码走势</td>");
        output.Write("<td colspan='5'　>红球号码分析</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#E8F1F8'>期号</td>");
        output.Write("<td colspan='33' align='center' valign='middle' bgcolor='#E8F1F8' height='18px'>红码走势</td>");
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#E8F1F8'>蓝码</td>");
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#E8F1F8'>012路</td>");
        output.Write("<td colspan='5'　align='center' valign='middle' bgcolor='#E8F1F8'>红球号码分析</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#E8F1F8' height='18px'>");
        output.Write("<td colspan='11'>一区</td>");
        output.Write("<td colspan='11'>二区</td>");
        output.Write("<td colspan='11'>三区</td>");
        output.Write("<td rowspan='2'>重号</td>");
        output.Write("<td rowspan='2'>连号</td>");
        output.Write("<td rowspan='2'>总和</td>");
        output.Write("<td rowspan='2'>三区比</td>");
        output.Write("<td rowspan='2'>奇偶比</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#E8F1F8'>");
        for (int i = 1; i < 10; i++)
        {
            output.Write("<td bgcolor='#f7f7f7' height='18px'>");
            output.Write(0 + i.ToString() + "</td>");
        }
        for (int j = 10; j < 0x22; j++)
        {
            output.Write("<td bgcolor='#f7f7f7'>");
            output.Write(j.ToString() + "</td>");
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
        //table = new TrendChart().SSQ_ZHFB_Select(30, "", "", ref result);
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
