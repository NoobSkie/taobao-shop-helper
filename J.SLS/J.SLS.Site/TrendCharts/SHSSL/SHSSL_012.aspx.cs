using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shove;
using System.Drawing;
using System.Data;

public partial class TrendCharts_SHSSL_SHSSL_012 : System.Web.UI.Page
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
            for (int j = 2; j < 7; j++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[j].Text = (j - 3).ToString();
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[j].Font.Bold = true;
                }
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, 0) == -1)
                {
                    this.GridView1.Rows[i].Cells[j].Text = "&nbsp;";
                }
            }
            for (int k = 7; k < 12; k++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[k].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[k].Text = (k - 8).ToString();
                    this.GridView1.Rows[i].Cells[k].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[k].Font.Bold = true;
                }
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[k].Text, 0) == -1)
                {
                    this.GridView1.Rows[i].Cells[k].Text = "&nbsp;";
                }
            }
            for (int m = 12; m < 0x11; m++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[m].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[m].Text = (m - 13).ToString();
                    this.GridView1.Rows[i].Cells[m].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[m].Font.Bold = true;
                }
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[m].Text, 0) == -1)
                {
                    this.GridView1.Rows[i].Cells[m].Text = "&nbsp;";
                }
            }
            for (int n = 0x11; n < 0x15; n++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[n].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[n].Text = (n - 0x11).ToString();
                    this.GridView1.Rows[i].Cells[n].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[n].Font.Bold = true;
                }
            }
            for (int num10 = 0x15; num10 < 0x19; num10++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[num10].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[num10].Text = (num10 - 0x15).ToString();
                    this.GridView1.Rows[i].Cells[num10].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[num10].Font.Bold = true;
                }
            }
            for (int num12 = 0x19; num12 < 0x1d; num12++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[num12].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[num12].Text = (num12 - 0x19).ToString();
                    this.GridView1.Rows[i].Cells[num12].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[num12].Font.Bold = true;
                }
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1d].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x1d].Text = "A";
                this.GridView1.Rows[i].Cells[0x1d].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[30].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[30].Text = "B";
                this.GridView1.Rows[i].Cells[30].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1f].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x1f].Text = "C";
                this.GridView1.Rows[i].Cells[0x1f].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x20].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x20].Text = "D";
                this.GridView1.Rows[i].Cells[0x20].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x21].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x21].Text = "E";
                this.GridView1.Rows[i].Cells[0x21].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x22].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x22].Text = "F";
                this.GridView1.Rows[i].Cells[0x22].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x23].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x23].Text = "G";
                this.GridView1.Rows[i].Cells[0x23].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x24].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x24].Text = "H";
                this.GridView1.Rows[i].Cells[0x24].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x25].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x25].Text = "I";
                this.GridView1.Rows[i].Cells[0x25].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x26].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x26].Text = "J";
                this.GridView1.Rows[i].Cells[0x26].ForeColor = Color.FromArgb(0, 0, 0);
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
            output.Write("<td bgcolor='#fdfcdf'>&nbsp;</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>0</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>1</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>2</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf'>&nbsp;</td>");
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>0</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>1</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>2</strong></span></td>");
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            output.Write("<td bgcolor='#fdfcdf'>&nbsp;</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;' ><strong>0</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;' ><strong>1</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;' ><strong>2</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf'>&nbsp;</td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>0</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>1</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>2</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff;  cursor:pointer;' ><strong>3</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>0</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>1</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>2</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>3</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>0</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>1</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>2</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>3</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' >A</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>B</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>C</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>D</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>E</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>F</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>G</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>H</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>I</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>J</td>");
        }
        output.Write("<tr  bgcolor='#e8f1f8'>");
        output.Write("<td rowspan='3'　 bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td rowspan='3'  bgcolor='#e8f1f8' >开奖号码</td>");
        for (int j = 0; j < 3; j++)
        {
            output.Write("<td bgcolor='#e8f1f8'>&nbsp;</td>");
            output.Write("<td bgcolor='#e8f1f8'>0</td>");
            output.Write("<td bgcolor='#e8f1f8'>1</td>");
            output.Write("<td bgcolor='#e8f1f8'>2</td>");
            output.Write("<td bgcolor='#e8f1f8'>&nbsp;</td>");
        }
        for (int k = 0; k < 3; k++)
        {
            for (int m = 0; m < 4; m++)
            {
                output.Write("<td bgcolor='#e8f1f8'>");
                output.Write(m.ToString() + "</td>");
            }
        }
        output.Write("<td bgcolor='#e8f1f8' height='18px'>A</td>");
        output.Write("<td bgcolor='#e8f1f8' >B</td>");
        output.Write("<td bgcolor='#e8f1f8' >C</td>");
        output.Write("<td bgcolor='#e8f1f8' >D</td>");
        output.Write("<td bgcolor='#e8f1f8' >E</td>");
        output.Write("<td bgcolor='#e8f1f8' >F</td>");
        output.Write("<td bgcolor='#e8f1f8' >G</td>");
        output.Write("<td bgcolor='#e8f1f8' >H</td>");
        output.Write("<td bgcolor='#e8f1f8' >I</td>");
        output.Write("<td bgcolor='#e8f1f8' >J</td>");
        output.Write("<tr  bgcolor='#e8f1f8' height='18px'>");
        output.Write("<td colspan='5'>百位</td>");
        output.Write("<td colspan='5'>十位</td>");
        output.Write("<td colspan='5'>个位</td>");
        output.Write("<td colspan='4'>0码个数</td>");
        output.Write("<td colspan='4'>1码个数</td>");
        output.Write("<td colspan='4'>2码个数</td>");
        output.Write("<td colspan='10'>总体走势分析</td>");
        output.Write("<tr  bgcolor='#e8f1f8'>");
        output.Write("<td colspan='37'　 bgcolor='#e8f1f8' height='18px'>012路</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3'　 bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td rowspan='3'  bgcolor='#e8f1f8' >开奖号码</td>");
        output.Write("<td colspan='37'　 bgcolor='#e8f1f8' height='18px'>012路</td>");
        output.Write("<tr  bgcolor='#e8f1f8' height='18px'>");
        output.Write("<td colspan='5'>百位</td>");
        output.Write("<td colspan='5'>十位</td>");
        output.Write("<td colspan='5'>个位</td>");
        output.Write("<td colspan='4'>0码个数</td>");
        output.Write("<td colspan='4'>1码个数</td>");
        output.Write("<td colspan='4'>2码个数</td>");
        output.Write("<td colspan='10'>总体走势分析</td>");
        output.Write("<tr  bgcolor='#e8f1f8'>");
        for (int i = 0; i < 3; i++)
        {
            output.Write("<td>&nbsp;</td>");
            output.Write("<td>0</td>");
            output.Write("<td>1</td>");
            output.Write("<td>2</td>");
            output.Write("<td>&nbsp;</td>");
        }
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 4; k++)
            {
                output.Write("<td>");
                output.Write(k.ToString() + "</td>");
            }
        }
        output.Write("<td bgcolor='#e8f1f8' height='18px'>A</td>");
        output.Write("<td bgcolor='#e8f1f8' >B</td>");
        output.Write("<td bgcolor='#e8f1f8' >C</td>");
        output.Write("<td bgcolor='#e8f1f8' >D</td>");
        output.Write("<td bgcolor='#e8f1f8' >E</td>");
        output.Write("<td bgcolor='#e8f1f8' >F</td>");
        output.Write("<td bgcolor='#e8f1f8' >G</td>");
        output.Write("<td bgcolor='#e8f1f8' >H</td>");
        output.Write("<td bgcolor='#e8f1f8' >I</td>");
        output.Write("<td bgcolor='#e8f1f8' >J</td>");
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
        //table = new TrendChart().SHSSL_012_Select(30, "", "", ref result);
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
