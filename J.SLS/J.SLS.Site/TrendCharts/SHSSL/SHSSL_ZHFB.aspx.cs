using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shove;
using System.Drawing;
using System.Data;

public partial class TrendCharts_SHSSL_SHSSL_ZHFB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.GridViewBind();
            this.ColorBind();
            this.GridView1.Style["border-collapse"] = "";
        }
    }

    protected void GridViewBind()
    {
        string result = "";
        DataTable table = new DataTable();
        // table = new TrendChart().SHSSL_ZHFB_Select(30, "", "", ref result);
        if ((table != null) && (table.Rows.Count >= 1))
        {
            int count = table.Rows.Count;
            this.tb1.Text = table.Rows[0]["Isuse"].ToString();
            this.tb2.Text = table.Rows[count - 1]["Isuse"].ToString();
        }
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
    }

    protected void ColorBind()
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            for (int j = 2; j < 12; j++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, -1) == 0)
                {
                    this.GridView1.Rows[i].Cells[j].Text = (j - 2).ToString();
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[j].Font.Bold = true;
                }
            }
            for (int k = 12; k < 0x16; k++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[k].Text, -1) == 0)
                {
                    this.GridView1.Rows[i].Cells[k].Text = (k - 12).ToString();
                    this.GridView1.Rows[i].Cells[k].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[k].Font.Bold = true;
                }
            }
            for (int m = 0x16; m < 0x20; m++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[m].Text, -1) == 0)
                {
                    this.GridView1.Rows[i].Cells[m].Text = (m - 0x16).ToString();
                    this.GridView1.Rows[i].Cells[m].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[m].Font.Bold = true;
                }
            }
            for (int n = 0x22; n < 0x2c; n++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[n].Text, -1) == 0)
                {
                    this.GridView1.Rows[i].Cells[n].Text = (n - 0x22).ToString();
                    this.GridView1.Rows[i].Cells[n].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[n].Font.Bold = true;
                    int num10 = _Convert.StrToInt(this.GridView1.DataKeys[i].Values[0].ToString(), -1);
                    int num11 = _Convert.StrToInt(this.GridView1.DataKeys[i].Values[1].ToString(), -2);
                    int num12 = _Convert.StrToInt(this.GridView1.DataKeys[i].Values[2].ToString(), -3);
                    if ((((num10 == num11) && (num10 == (n - 0x22))) || ((num11 == num12) && (num11 == (n - 0x22)))) || ((num10 == num12) && (num12 == (n - 0x22))))
                    {
                        this.GridView1.Rows[i].Cells[n].ForeColor = Color.FromArgb(0xff, 0, 0);
                    }
                }
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x2c].Text, -1) == 0)
            {
                int num13 = _Convert.StrToInt(this.GridView1.DataKeys[i].Values[0].ToString(), -1);
                int num14 = _Convert.StrToInt(this.GridView1.DataKeys[i].Values[1].ToString(), -2);
                if (num13 == num14)
                {
                    this.GridView1.Rows[i].Cells[0x2c].Text = num14.ToString();
                    this.GridView1.Rows[i].Cells[0x2c].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[0x2c].Font.Bold = true;
                }
                else
                {
                    this.GridView1.Rows[i].Cells[0x2c].Text = this.GridView1.DataKeys[i].Values[2].ToString();
                    this.GridView1.Rows[i].Cells[0x2c].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[0x2c].Font.Bold = true;
                }
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x2d].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x2d].Text = this.GridView1.DataKeys[i].Value.ToString();
                this.GridView1.Rows[i].Cells[0x2d].ForeColor = Color.FromArgb(0, 0, 0xff);
                this.GridView1.Rows[i].Cells[0x2d].Font.Bold = true;
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
            for (int num2 = 0; num2 < 10; num2++)
            {
                output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;cursor:pointer;' ><strong>");
                output.Write(num2.ToString() + "</td>");
            }
            for (int num3 = 0; num3 < 10; num3++)
            {
                output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff;cursor:pointer;'><strong>");
                output.Write(num3.ToString() + "</td>");
            }
            for (int num4 = 0; num4 < 10; num4++)
            {
                output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;cursor:pointer;'><strong>");
                output.Write(num4.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            for (int num5 = 0; num5 < 10; num5++)
            {
                output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;cursor:pointer;' ><strong>");
                output.Write(num5.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#fdfcdf'>&nbsp;</td>");
            output.Write("<td bgcolor='#fdfcdf'>&nbsp;</td>");
        }
        output.Write("<tr align='center' valign='center' bgcolor='#e8f1f8'>");
        output.Write("<td rowspan='3'　height='18px'>期号</td>");
        output.Write("<td rowspan='3'　>开奖号码</td>");
        for (int j = 0; j < 10; j++)
        {
            output.Write("<td ><font color='blue'>");
            output.Write(j.ToString() + "</font></td>");
        }
        for (int k = 0; k < 10; k++)
        {
            output.Write("<td ><font color='red'>");
            output.Write(k.ToString() + "</font></td>");
        }
        for (int m = 0; m < 10; m++)
        {
            output.Write("<td ><font color='blue'>");
            output.Write(m.ToString() + "</font></td>");
        }
        output.Write("<td rowspan='2' bgcolor='#e8f1f8'>奇偶比</td>");
        output.Write("<td rowspan='2' bgcolor='#e8f1f8'>大小比</td>");
        for (int n = 0; n < 10; n++)
        {
            output.Write("<td ><font color='red'>");
            output.Write(n.ToString() + "</font></td>");
        }
        output.Write("<td rowspan='3'　>组选3</td>");
        output.Write("<td rowspan='3'　>豹子号</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8' height='18px'>");
        output.Write("<td colspan='10'>第一位</td>");
        output.Write("<td colspan='10'>第二位</td>");
        output.Write("<td colspan='10'>第三位</td>");
        output.Write("<td colspan='10' height='18px'>0-9综合分布</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8'>");
        output.Write("<td colspan='42'  height='18px'><strong><font color='red'>基本走势</font></strong></td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>开奖号码</td>");
        output.Write("<td colspan='42' align='center' valign='middle' bgcolor='#e8f1f8' height='18px'><strong><font color='red'>基本走势</font></strong></td>");
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>组选3</td>");
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>豹子号</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8' height='18px'>");
        output.Write("<td colspan='10'>第一位</td>");
        output.Write("<td colspan='10'>第二位</td>");
        output.Write("<td colspan='10'>第三位</td>");
        output.Write("<td rowspan='2'>奇偶比</td>");
        output.Write("<td rowspan='2'>大小比</td>");
        output.Write("<td colspan='10' height='18px'>0-9综合分布</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8'>");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                output.Write("<td align='center' valign='middle' bgcolor='#e8f1f8' height='18px'><font color='blue'>");
                output.Write(j.ToString() + "</font></td>");
            }
            for (int k = 0; k < 10; k++)
            {
                output.Write("<td align='center' valign='middle' bgcolor='#e8f1f8' height='18px'><font color='red'>");
                output.Write(k.ToString() + "</font></td>");
            }
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
}
