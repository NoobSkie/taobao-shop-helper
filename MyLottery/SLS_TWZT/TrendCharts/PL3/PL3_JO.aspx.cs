using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class View_PL3_JO : TrendChartPageBase, IRequiresSessionState
{

    protected void ColorBind()
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            this.GridView1.Rows[i].Cells[1].ForeColor = Color.FromArgb(0, 0, 0xff);
        }
        for (int j = 0; j < this.GridView1.Rows.Count; j++)
        {
            for (int num3 = 2; num3 < 7; num3++)
            {
                this.GridView1.Rows[j].Cells[num3].BackColor = Color.FromArgb(0xfc, 0xdf, 0xc5);
                if ((this.GridView1.Rows[j].Cells[num3].Text == "奇") || (this.GridView1.Rows[j].Cells[num3].Text == "偶"))
                {
                    this.GridView1.Rows[j].Cells[num3].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[j].Cells[num3].ForeColor = Color.White;
                }
            }
        }
        for (int k = 0; k < this.GridView1.Rows.Count; k++)
        {
            for (int num5 = 7; num5 < 12; num5++)
            {
                this.GridView1.Rows[k].Cells[num5].BackColor = Color.FromArgb(0xdd, 0xff, 230);
                if ((this.GridView1.Rows[k].Cells[num5].Text == "奇") || (this.GridView1.Rows[k].Cells[num5].Text == "偶"))
                {
                    this.GridView1.Rows[k].Cells[num5].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[k].Cells[num5].ForeColor = Color.White;
                }
            }
        }
        for (int m = 0; m < this.GridView1.Rows.Count; m++)
        {
            for (int num7 = 12; num7 < 0x11; num7++)
            {
                this.GridView1.Rows[m].Cells[num7].BackColor = Color.FromArgb(0xc1, 0xe7, 0xff);
                if ((this.GridView1.Rows[m].Cells[num7].Text == "奇") || (this.GridView1.Rows[m].Cells[num7].Text == "偶"))
                {
                    this.GridView1.Rows[m].Cells[num7].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[m].Cells[num7].ForeColor = Color.White;
                }
            }
        }
        for (int n = 0; n < this.GridView1.Rows.Count; n++)
        {
            for (int num9 = 0x11; num9 < 0x15; num9++)
            {
                this.GridView1.Rows[n].Cells[num9].BackColor = Color.FromArgb(0xff, 0xcc, 0x33);
                if (this.GridView1.Rows[n].Cells[num9].Text == "0")
                {
                    this.GridView1.Rows[n].Cells[num9].BackColor = Color.FromArgb(0, 0, 0xcc);
                    this.GridView1.Rows[n].Cells[num9].ForeColor = Color.White;
                }
            }
        }
        for (int num10 = 0; num10 < this.GridView1.Rows.Count; num10++)
        {
            if (this.GridView1.Rows[num10].Cells[0x11].Text == "0")
            {
                this.GridView1.Rows[num10].Cells[0x11].Text = "A";
                this.GridView1.Rows[num10].Cells[0x11].ForeColor = Color.White;
            }
            if (this.GridView1.Rows[num10].Cells[0x12].Text == "0")
            {
                this.GridView1.Rows[num10].Cells[0x12].Text = "B";
                this.GridView1.Rows[num10].Cells[0x12].ForeColor = Color.White;
            }
            if (this.GridView1.Rows[num10].Cells[0x13].Text == "0")
            {
                this.GridView1.Rows[num10].Cells[0x13].Text = "C";
                this.GridView1.Rows[num10].Cells[0x13].ForeColor = Color.White;
            }
            if (this.GridView1.Rows[num10].Cells[20].Text == "0")
            {
                this.GridView1.Rows[num10].Cells[20].Text = "D";
                this.GridView1.Rows[num10].Cells[20].ForeColor = Color.White;
            }
        }
        for (int num11 = 0; num11 < this.GridView1.Rows.Count; num11++)
        {
            for (int num12 = 0x15; num12 < 0x1d; num12++)
            {
                this.GridView1.Rows[num11].Cells[num12].BackColor = Color.FromArgb(0xd8, 0xea, 0xce);
                if (this.GridView1.Rows[num11].Cells[num12].Text == "0")
                {
                    this.GridView1.Rows[num11].Cells[num12].BackColor = Color.FromArgb(0x33, 0x80, 0xbd);
                }
            }
        }
        for (int num13 = 0; num13 < this.GridView1.Rows.Count; num13++)
        {
            if (this.GridView1.Rows[num13].Cells[0x15].Text == "0")
            {
                this.GridView1.Rows[num13].Cells[0x15].Text = "0";
                this.GridView1.Rows[num13].Cells[0x15].ForeColor = Color.White;
            }
            if (this.GridView1.Rows[num13].Cells[0x16].Text == "0")
            {
                this.GridView1.Rows[num13].Cells[0x16].Text = "1";
                this.GridView1.Rows[num13].Cells[0x16].ForeColor = Color.White;
            }
            if (this.GridView1.Rows[num13].Cells[0x17].Text == "0")
            {
                this.GridView1.Rows[num13].Cells[0x17].Text = "2";
                this.GridView1.Rows[num13].Cells[0x17].ForeColor = Color.White;
            }
            if (this.GridView1.Rows[num13].Cells[0x18].Text == "0")
            {
                this.GridView1.Rows[num13].Cells[0x18].Text = "3";
                this.GridView1.Rows[num13].Cells[0x18].ForeColor = Color.White;
            }
            if (this.GridView1.Rows[num13].Cells[0x19].Text == "0")
            {
                this.GridView1.Rows[num13].Cells[0x19].Text = "4";
                this.GridView1.Rows[num13].Cells[0x19].ForeColor = Color.White;
            }
            if (this.GridView1.Rows[num13].Cells[0x1a].Text == "0")
            {
                this.GridView1.Rows[num13].Cells[0x1a].Text = "5";
                this.GridView1.Rows[num13].Cells[0x1a].ForeColor = Color.White;
            }
            if (this.GridView1.Rows[num13].Cells[0x1b].Text == "0")
            {
                this.GridView1.Rows[num13].Cells[0x1b].Text = "6";
                this.GridView1.Rows[num13].Cells[0x1b].ForeColor = Color.White;
            }
            if (this.GridView1.Rows[num13].Cells[0x1c].Text == "0")
            {
                this.GridView1.Rows[num13].Cells[0x1c].Text = "7";
                this.GridView1.Rows[num13].Cells[0x1c].ForeColor = Color.White;
            }
        }
        for (int num14 = 0; num14 < this.GridView1.Rows.Count; num14++)
        {
            for (int num15 = 0x11; num15 < 0x16; num15++)
            {
                if (this.GridView1.Rows[num14].Cells[num15].BackColor == Color.FromArgb(0xff, 0xcc, 0x33))
                {
                    this.GridView1.Rows[num14].Cells[num15].ForeColor = Color.FromArgb(0x80, 0x80, 0x80);
                }
            }
        }
        for (int num16 = 0; num16 < this.GridView1.Rows.Count; num16++)
        {
            for (int num17 = 0x15; num17 < 0x1d; num17++)
            {
                if (this.GridView1.Rows[num16].Cells[num17].BackColor == Color.FromArgb(0xd8, 0xea, 0xce))
                {
                    this.GridView1.Rows[num16].Cells[num17].ForeColor = Color.FromArgb(170, 170, 170);
                }
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='2' rowspan='5'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>奇</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>偶</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>奇</td>");
        output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>偶</td>");
        output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
        output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>奇</td>");
        output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>偶</td>");
        output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        output.Write("<td bgcolor='#FFCC33' onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33'>A</td>");
        output.Write("<td bgcolor='#FFCC33' onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33'>B</td>");
        output.Write("<td bgcolor='#FFCC33' onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33'>C</td>");
        output.Write("<td bgcolor='#FFCC33' onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33'>D</td>");
        for (int i = 0; i < 8; i++)
        {
            output.Write("<td bgcolor='#D8EACE'onclick=Style(this,'#3380BD','#D8EACE') style='color:#D8EACE'>");
            output.Write(i.ToString() + "</td>");
        }
        for (int j = 0; j < 4; j++)
        {
            output.Write("<tr align='center' valign='middle'>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>奇</td>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>偶</td>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>奇</td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>偶</td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>奇</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>偶</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#FFCC33'onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33;'>A</td>");
            output.Write("<td bgcolor='#FFCC33'onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33;'>B</td>");
            output.Write("<td bgcolor='#FFCC33'onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33;'>C</td>");
            output.Write("<td bgcolor='#FFCC33'onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33;'>d</td>");
            for (int m = 0; m < 8; m++)
            {
                output.Write("<td bgcolor='#D8EACE'onclick=Style(this,'#3380BD','#D8EACE') style='color:#D8EACE'>");
                output.Write(m.ToString() + "</td>");
            }
        }
        output.Write("<tr align='center' vlign = 'middle'>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'><strong><font color='DD0000'>奇</font></strong></td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'><strong><font color='DD0000'>偶</font></strong></td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
        output.Write("<td bgcolor='#DDFFE6'><strong><font color='DD0000'>奇</font></strong></td>");
        output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
        output.Write("<td bgcolor='#DDFFE6'><strong><font color='DD0000'>偶</font></strong></td>");
        output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
        output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        output.Write("<td bgcolor='#C1E7FF'><strong><font color='DD0000'>奇</font></strong></td>");
        output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        output.Write("<td bgcolor='#C1E7FF'><strong><font color='DD0000'>偶</font></strong></td>");
        output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        output.Write("<td bgcolor='#FFCC33'><strong><font color='DD0000'>A</font></strong></td>");
        output.Write("<td bgcolor='#FFCC33'><strong><font color='DD0000'>B</font></strong></td>");
        output.Write("<td bgcolor='#FFCC33'><strong><font color='DD0000'>C</font></strong></td>");
        output.Write("<td bgcolor='#FFCC33'><strong><font color='DD0000'>D</font></strong></td>");
        for (int k = 0; k < 8; k++)
        {
            output.Write("<td bgcolor='#D8EACE'><strong><font color ='DD0000'>");
            output.Write(k.ToString() + "</font></strong></td>");
        }
        output.Write("<tr align='center' vlign='center'>");
        output.Write("<td>期数</td>");
        output.Write("<td>开奖号码</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>百位</td>");
        output.Write("<td colspan ='5'bgcolor='#DDFFE6'>十位</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>个位</td>");
        output.Write("<td colspan ='4'bgcolor='#FFCC33'<strong><font color='#DD0000'>");
        output.Write("组选组合</td>");
        output.Write("<td colspan ='8'bgcolor='#C9E1BB'>单选大小组合</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan ='2' align ='center' vlign='middle'>期  数</td>");
        output.Write("<td rowspan ='2'>开奖号码</td>");
        output.Write("<td colspan = '5'>百位</td>");
        output.Write("<td colspan = '5'>十位</td>");
        output.Write("<td colspan = '5'>个位</td>");
        output.Write("<td colspan = '4'><strong><font color='#DD0000'>组选组合</font></strong></td>");
        output.Write("<td colspan = '8'>单选组合</td>");
        output.Write("<tr align ='center' vlign='center'>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>奇</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>偶</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>奇</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>偶</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>奇</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>偶</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>A</td>");
        output.Write("<td>B</td>");
        output.Write("<td>C</td>");
        output.Write("<td>D</td>");
        output.Write("<td>0</td>");
        output.Write("<td>1</td>");
        output.Write("<td>2</td>");
        output.Write("<td>3</td>");
        output.Write("<td>4</td>");
        output.Write("<td>5</td>");
        output.Write("<td>6</td>");
        output.Write("<td>7</td>");
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
        DataTable table = new DataTable();
        table = BLL.PL3_JO_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.GridViewBind();
            this.ColorBind();
            this.GridView1.Style["border-collapse"] = "";
        }
    }

    protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_JO_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_JO_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_JO_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_JO_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_JO_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }
}

