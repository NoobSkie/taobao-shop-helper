using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Shove;
using System.Drawing;

public partial class TrendCharts_SSQ_SSQ_BQZST : System.Web.UI.Page
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
        string str = "";
        this.lbline.Text = "<script type=\"text/javascript\">function DrawLines(){";
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            for (int j = 3; j < 0x13; j++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, 0) == 0)
                {
                    Label child = new Label();
                    string[] strArray = new string[8];
                    strArray[0] = "<strong style='color:Red' id='GridView1_ctl";
                    int num3 = i + 2;
                    strArray[1] = num3.ToString().PadLeft(2, '0');
                    strArray[2] = "_";
                    strArray[3] = i.ToString();
                    strArray[4] = "_";
                    strArray[5] = j.ToString();
                    strArray[6] = "' />";
                    strArray[7] = (j - 2).ToString();
                    child.Text = string.Concat(strArray);
                    if (str != "")
                    {
                        string text = this.lbline.Text;
                        string[] strArray2 = new string[10];
                        strArray2[0] = text;
                        strArray2[1] = "DrawLine('";
                        strArray2[2] = str;
                        strArray2[3] = "','GridView1_ctl";
                        int num5 = i + 2;
                        strArray2[4] = num5.ToString().PadLeft(2, '0');
                        strArray2[5] = "_";
                        strArray2[6] = i.ToString();
                        strArray2[7] = "_";
                        strArray2[8] = j.ToString();
                        strArray2[9] = "', 'blue');";
                        this.lbline.Text = string.Concat(strArray2);
                    }
                    this.GridView1.Rows[i].Cells[j].Controls.Add(child);
                    string[] strArray3 = new string[6];
                    strArray3[0] = "GridView1_ctl";
                    int num6 = i + 2;
                    strArray3[1] = num6.ToString().PadLeft(2, '0');
                    strArray3[2] = "_";
                    strArray3[3] = i.ToString();
                    strArray3[4] = "_";
                    strArray3[5] = j.ToString();
                    str = string.Concat(strArray3);
                }
            }
            for (int k = 0x13; k < 0x17; k++)
            {
                if (this.GridView1.Rows[i].Cells[k].Text == "0")
                {
                    this.GridView1.Rows[i].Cells[k].Text = "&nbsp;";
                }
            }
            for (int m = 0x17; m < 0x1a; m++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[m].Text, 0) == -1)
                {
                    this.GridView1.Rows[i].Cells[m].Text = "&nbsp;";
                }
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x17].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x17].Text = "◎";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x18].Text, 0) == 1)
            {
                this.GridView1.Rows[i].Cells[0x18].Text = "①";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x19].Text, 0) == 2)
            {
                this.GridView1.Rows[i].Cells[0x19].Text = "②";
            }
            for (int n = 0x1a; n < 30; n++)
            {
                int num10 = _Convert.StrToInt(this.GridView1.Rows[i].Cells[2].Text, 0);
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[n].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[n].Text = num10.ToString();
                    this.GridView1.Rows[i].Cells[n].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[n].Font.Bold = true;
                }
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[30].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[30].Text = "金";
                this.GridView1.Rows[i].Cells[30].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1f].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x1f].Text = "木";
                this.GridView1.Rows[i].Cells[0x1f].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x20].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x20].Text = "水";
                this.GridView1.Rows[i].Cells[0x20].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x21].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x21].Text = "火";
                this.GridView1.Rows[i].Cells[0x21].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x22].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x22].Text = "土";
                this.GridView1.Rows[i].Cells[0x22].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
        }
        this.lbline.Text = this.lbline.Text + "}</script>";
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='3' rowspan='2' height='20px'>预选行</td>");
        for (int i = 1; i < 10; i++)
        {
            output.Write("<td bgcolor='#FFFFFF' height='20' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' ><strong>");
            output.Write(i.ToString() + "</strong></span></td>");
        }
        for (int j = 10; j < 0x11; j++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' ><strong>");
            output.Write(j.ToString() + "</strong></td>");
        }
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >奇</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >偶</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >质</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >合</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >0</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >1</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >2</td>");
        for (int k = 1; k < 5; k++)
        {
            output.Write("<td>&nbsp;</td>");
        }
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >金</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >木</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >水</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >火</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >土</td>");
        output.Write("<tr  bgcolor='#e8f1f8' style='cursor:pointer;' >");
        for (int m = 1; m < 10; m++)
        {
            output.Write("<td bgcolor='#FFFFFF' height='20' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(m.ToString() + "</strong></span></td>");
        }
        for (int n = 10; n < 0x11; n++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(n.ToString() + "</strong></td>");
        }
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;' >奇</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' >偶</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;' >质</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' >合</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;' >0</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' >1</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' >2</td>");
        for (int num6 = 1; num6 < 5; num6++)
        {
            output.Write("<td bgcolor='#FFFFFF'>&nbsp;</td>");
        }
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' >金</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' >木</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' >水</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' >火</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' >土</td>");
        output.Write("<tr  bgcolor='#e8f1f8' >");
        output.Write("<td rowspan='2'　 >期号</td>");
        output.Write("<td  height='42px'>红球</td>");
        output.Write("<td >蓝球</td>");
        for (int num7 = 1; num7 < 10; num7++)
        {
            output.Write("<td  >");
            output.Write(0 + num7.ToString() + "</td>");
        }
        for (int num8 = 10; num8 < 0x11; num8++)
        {
            output.Write("<td >");
            output.Write(num8.ToString() + "</td>");
        }
        output.Write("<td >奇</td>");
        output.Write("<td >偶</td>");
        output.Write("<td >质</td>");
        output.Write("<td >合</td>");
        output.Write("<td >0</td>");
        output.Write("<td >1</td>");
        output.Write("<td >2</td>");
        output.Write("<td >1-4</td>");
        output.Write("<td >5-8</td>");
        output.Write("<td >9-12</td>");
        output.Write("<td >13-16</td>");
        output.Write("<td >金</td>");
        output.Write("<td >木</td>");
        output.Write("<td >水</td>");
        output.Write("<td >火</td>");
        output.Write("<td >土</td>");
        output.Write("<tr  bgcolor='#e8f1f8' >");
        output.Write("<td colspan='2'　 bgcolor='#e8f1f8'>奖号</td>");
        output.Write("<td colspan='16'　  height='28px'>蓝球分布</td>");
        output.Write("<td colspan='2'　>奇偶走势</td>");
        output.Write("<td colspan='2'　>质合走势</td>");
        output.Write("<td colspan='3'　>012路</td>");
        output.Write("<td colspan='4'　>四区分布</td>");
        output.Write("<td colspan='5'　>蓝球五行属性</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'　 bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td colspan='2'　 bgcolor='#e8f1f8'>奖号</td>");
        output.Write("<td colspan='16'　 bgcolor='#e8f1f8' height='28px'>蓝球分布</td>");
        output.Write("<td colspan='2'　 bgcolor='#e8f1f8'>奇偶走势</td>");
        output.Write("<td colspan='2'　 bgcolor='#e8f1f8'>质合走势</td>");
        output.Write("<td colspan='3'　 bgcolor='#e8f1f8'>012路</td>");
        output.Write("<td colspan='4'　 bgcolor='#e8f1f8'>四区分布</td>");
        output.Write("<td colspan='5'　 bgcolor='#e8f1f8'>蓝球五行属性</td>");
        output.Write("<tr  bgcolor='#e8f1f8' >");
        output.Write("<td  height='42px'>红球</td>");
        output.Write("<td >蓝球</td>");
        for (int i = 1; i < 10; i++)
        {
            output.Write("<td  >");
            output.Write(0 + i.ToString() + "</td>");
        }
        for (int j = 10; j < 0x11; j++)
        {
            output.Write("<td >");
            output.Write(j.ToString() + "</td>");
        }
        output.Write("<td >奇</td>");
        output.Write("<td >偶</td>");
        output.Write("<td >质</td>");
        output.Write("<td >合</td>");
        output.Write("<td >0</td>");
        output.Write("<td >1</td>");
        output.Write("<td >2</td>");
        output.Write("<td >1-4</td>");
        output.Write("<td >5-8</td>");
        output.Write("<td >9-12</td>");
        output.Write("<td >13-16</td>");
        output.Write("<td >金</td>");
        output.Write("<td >木</td>");
        output.Write("<td >水</td>");
        output.Write("<td >火</td>");
        output.Write("<td >土</td>");
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
        //table = new TrendChart().SSQ_BQZH_Select(30, "", "", ref result);
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
