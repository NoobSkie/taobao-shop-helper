using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Shove;
using System.Drawing;

public partial class TrendCharts_SHSSL_SHSSL_ZH : System.Web.UI.Page
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
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[2].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[2].Text = "质";
                this.GridView1.Rows[i].Cells[2].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[3].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[3].Text = "合";
                this.GridView1.Rows[i].Cells[3].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[4].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[4].Text = "质";
                this.GridView1.Rows[i].Cells[4].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[5].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[5].Text = "合";
                this.GridView1.Rows[i].Cells[5].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[6].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[6].Text = "质";
                this.GridView1.Rows[i].Cells[6].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[7].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[7].Text = "合";
                this.GridView1.Rows[i].Cells[7].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[9].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[9].Text = "A";
                this.GridView1.Rows[i].Cells[9].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[10].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[10].Text = "B";
                this.GridView1.Rows[i].Cells[10].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[11].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[11].Text = "C";
                this.GridView1.Rows[i].Cells[11].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[12].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[12].Text = "D";
                this.GridView1.Rows[i].Cells[12].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[13].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[13].Text = "A";
                this.GridView1.Rows[i].Cells[13].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[14].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[14].Text = "B";
                this.GridView1.Rows[i].Cells[14].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[15].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[15].Text = "C";
                this.GridView1.Rows[i].Cells[15].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x10].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x10].Text = "D";
                this.GridView1.Rows[i].Cells[0x10].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x11].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x11].Text = "E";
                this.GridView1.Rows[i].Cells[0x11].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x12].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x12].Text = "F";
                this.GridView1.Rows[i].Cells[0x12].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x13].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x13].Text = "G";
                this.GridView1.Rows[i].Cells[0x13].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[20].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[20].Text = "H";
                this.GridView1.Rows[i].Cells[20].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x16].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x16].Text = "质";
                this.GridView1.Rows[i].Cells[0x16].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x17].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x17].Text = "合";
                this.GridView1.Rows[i].Cells[0x17].ForeColor = Color.FromArgb(0, 0, 0xff);
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
            for (int k = 0; k < 3; k++)
            {
                output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>质</strong></span></td>");
                output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#0000ff','#fdfcdf') style='color:#fdfcdf;cursor:pointer;'><strong>合</strong></span></td>");
            }
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>A</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf ; cursor:pointer;'>B</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>C</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>D</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>A</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>B</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>C</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>D</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>E</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>F</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>G</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>H</td>");
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;cursor:pointer;' ><strong>质</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#0000ff','#fdfcdf') style='color:#fdfcdf;cursor:pointer;' ><strong>合</strong></span></td>");
        }
        output.Write("<tr align='center' valign='center' bgcolor='#e8f1f8'>");
        output.Write("<td rowspan='3'　>期号</td>");
        output.Write("<td rowspan='3' >开奖号码</td>");
        for (int j = 0; j < 3; j++)
        {
            output.Write("<td><font color='red'>质</font></td>");
            output.Write("<td ><font color='blue'>合</font></td>");
        }
        output.Write("<td rowspan='2' >质合比</td>");
        output.Write("<td  ><font color='red'>A</font></td>");
        output.Write("<td  ><font color='red'>B</font></td>");
        output.Write("<td  ><font color='red'>C</font></td>");
        output.Write("<td  ><font color='red'>D</font></td>");
        output.Write("<td  >A</td>");
        output.Write("<td  >B</td>");
        output.Write("<td  >C</td>");
        output.Write("<td  >D</td>");
        output.Write("<td  >E</td>");
        output.Write("<td  >F</td>");
        output.Write("<td  >G</td>");
        output.Write("<td  >H</td>");
        output.Write("<td ><font color='blue'>值</font></td>");
        output.Write("<td ><font color='red'>质</font></td>");
        output.Write("<td ><font color='blue'>合</font></td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8' height='18px'>");
        output.Write("<td colspan='2'>第一位</td>");
        output.Write("<td colspan='2'>第二位</td>");
        output.Write("<td colspan='2'>第三位</td>");
        output.Write("<td colspan='4'>组选</td>");
        output.Write("<td colspan='8'>单选</td>");
        output.Write("<td colspan='3'>合值</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8'>");
        output.Write("<td colspan='22'　 height='18px'>质合走势</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td rowspan='3' align='center' valign='middle' bgcolor='#e8f1f8' >开奖号码</td>");
        output.Write("<td colspan='22'　align='center' valign='middle' bgcolor='#e8f1f8' height='18px'>质合走势</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8' height='18px'>");
        output.Write("<td colspan='2'>第一位</td>");
        output.Write("<td colspan='2'>第二位</td>");
        output.Write("<td colspan='2'>第三位</td>");
        output.Write("<td rowspan='2'>质合比</td>");
        output.Write("<td colspan='4'>组选</td>");
        output.Write("<td colspan='8'>单选</td>");
        output.Write("<td colspan='3'>合值</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8'>");
        for (int i = 0; i < 3; i++)
        {
            output.Write("<td><font color='red'>质</font></td>");
            output.Write("<td><font color='blue'>合</font></td>");
        }
        output.Write("<td bgcolor='#e8f1f8' ><font color='red'>A</font></td>");
        output.Write("<td bgcolor='#e8f1f8' ><font color='red'>B</font></td>");
        output.Write("<td bgcolor='#e8f1f8' ><font color='red'>C</font></td>");
        output.Write("<td bgcolor='#e8f1f8' ><font color='red'>D</font></td>");
        output.Write("<td bgcolor='#e8f1f8' >A</td>");
        output.Write("<td bgcolor='#e8f1f8' >B</td>");
        output.Write("<td bgcolor='#e8f1f8' >C</td>");
        output.Write("<td bgcolor='#e8f1f8' >D</td>");
        output.Write("<td bgcolor='#e8f1f8' >E</td>");
        output.Write("<td bgcolor='#e8f1f8' >F</td>");
        output.Write("<td bgcolor='#e8f1f8' >G</td>");
        output.Write("<td bgcolor='#e8f1f8' >H</td>");
        output.Write("<td><font color='blue'>值</font></td>");
        output.Write("<td><font color='red'>质</font></td>");
        output.Write("<td><font color='blue'>合</font></td>");
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
        //table = new TrendChart().SHSSL_ZH_Select(30, "", "", ref result);
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
