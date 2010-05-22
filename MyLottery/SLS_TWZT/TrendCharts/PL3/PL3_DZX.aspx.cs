using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class View_PL3_DZX : TrendChartPageBase, IRequiresSessionState
{

    protected void databind()
    {
        this.GridView1.DataSource = BLL.PL3_DZX_SeleteByNum(30);
        this.GridView1.DataBind();
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='2' rowspan='5'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>大</td>");
        output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>中</td>");
        output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>小</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>大</td>");
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>中</td>");
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>小</td>");
        output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
        output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>大</td>");
        output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>中</td>");
        output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>小</td>");
        output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        output.Write("<td bgcolor='#FFCC33' onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33'>0</td>");
        output.Write("<td bgcolor='#FFCC33' onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33'>1</td>");
        output.Write("<td bgcolor='#FFCC33' onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33'>2</td>");
        output.Write("<td bgcolor='#FFCC33' onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33'>3</td>");
        for (int i = 0; i < 4; i++)
        {
            output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF'>");
            output.Write(i.ToString() + "</td>");
        }
        for (int j = 0; j < 4; j++)
        {
            output.Write("<td bgcolor='#A6D7C1'onclick=Style(this,'#0000CC','#A6D7C1') style='color:#A6D7C1'>");
            output.Write(j.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>A</TD>");
        output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>B</TD>");
        output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>C</TD>");
        output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>D</TD>");
        output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>E</TD>");
        output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>F</TD>");
        output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>G</TD>");
        output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>H</TD>");
        output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>I</TD>");
        output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>J</TD>");
        for (int k = 0; k < 4; k++)
        {
            output.Write("<tr align='center' valign='middle'>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>大</td>");
            output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>中</td>");
            output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>小</td>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>大</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>中</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>小</td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>大</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>中</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>小</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#FFCC33' onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33'>0</td>");
            output.Write("<td bgcolor='#FFCC33' onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33'>1</td>");
            output.Write("<td bgcolor='#FFCC33' onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33'>2</td>");
            output.Write("<td bgcolor='#FFCC33' onClick=Style(this,'#0000CC','#FFCC33') style='color:#FFCC33'>3</td>");
            for (int m = 0; m < 4; m++)
            {
                output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF'>");
                output.Write(m.ToString() + "</td>");
            }
            for (int n = 0; n < 4; n++)
            {
                output.Write("<td bgcolor='#A6D7C1'onclick=Style(this,'#0000CC','#A6D7C1') style='color:#A6D7C1'>");
                output.Write(n.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>A</TD>");
            output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>B</TD>");
            output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>C</TD>");
            output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>D</TD>");
            output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>E</TD>");
            output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>F</TD>");
            output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>G</TD>");
            output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>H</TD>");
            output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>I</TD>");
            output.Write("<td bgcolor='#FFFFFF'onclick=Style(this,'#3380BD','#FFFFFF') style='color:#FFFFFF'>J</TD>");
        }
        output.Write("<tr align='center' vlign = 'middle'>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'><strong><font color='DD0000'>大</font></strong></td>");
        output.Write("<td bgcolor='#FCDFC5'><strong><font color='DD0000'>中</font></strong></td>");
        output.Write("<td bgcolor='#FCDFC5'><strong><font color='DD0000'>小</font></strong></td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
        output.Write("<td bgcolor='#DDFFE6'><strong><font color='DD0000'>大</font></strong></td>");
        output.Write("<td bgcolor='#DDFFE6'><strong><font color='DD0000'>中</font></strong></td>");
        output.Write("<td bgcolor='#DDFFE6'><strong><font color='DD0000'>小</font></strong></td>");
        output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
        output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        output.Write("<td bgcolor='#C1E7FF'><strong><font color='DD0000'>大</font></strong></td>");
        output.Write("<td bgcolor='#C1E7FF'><strong><font color='DD0000'>中</font></strong></td>");
        output.Write("<td bgcolor='#C1E7FF'><strong><font color='DD0000'>小</font></strong></td>");
        output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        output.Write("<td bgcolor='#FFCC33'><strong><font color='DD0000'>0</font></strong></td>");
        output.Write("<td bgcolor='#FFCC33'><strong><font color='DD0000'>1</font></strong></td>");
        output.Write("<td bgcolor='#FFCC33'><strong><font color='DD0000'>2</font></strong></td>");
        output.Write("<td bgcolor='#FFCC33'><strong><font color='DD0000'>3</font></strong></td>");
        output.Write("<td bgcolor='#FFFFFF'><strong><font color='DD0000'>0</font></strong></td>");
        output.Write("<td bgcolor='#FFFFFF'><strong><font color='DD0000'>1</font></strong></td>");
        output.Write("<td bgcolor='#FFFFFF'><strong><font color='DD0000'>2</font></strong></td>");
        output.Write("<td bgcolor='#FFFFFF'><strong><font color='DD0000'>3</font></strong></td>");
        output.Write("<td bgcolor='#A6D7C1'><strong><font color='DD0000'>0</font></strong></td>");
        output.Write("<td bgcolor='#A6D7C1'><strong><font color='DD0000'>1</font></strong></td>");
        output.Write("<td bgcolor='#A6D7C1'><strong><font color='DD0000'>2</font></strong></td>");
        output.Write("<td bgcolor='#A6D7C1'><strong><font color='DD0000'>3</font></strong></td>");
        output.Write("<td bgcolor='#C9E1BB'>A</TD>");
        output.Write("<td bgcolor='#C9E1BB'>B</TD>");
        output.Write("<td bgcolor='#C9E1BB'>C</TD>");
        output.Write("<td bgcolor='#C9E1BB'>D</TD>");
        output.Write("<td bgcolor='#C9E1BB'>E</TD>");
        output.Write("<td bgcolor='#C9E1BB'>F</TD>");
        output.Write("<td bgcolor='#C9E1BB'>G</TD>");
        output.Write("<td bgcolor='#C9E1BB'>H</TD>");
        output.Write("<td bgcolor='#C9E1BB'>I</TD>");
        output.Write("<td bgcolor='#C9E1BB'>J</TD>");
        output.Write("<tr align='center' vlign='center'>");
        output.Write("<td>期 数</td>");
        output.Write("<td>开奖号码</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>百位</td>");
        output.Write("<td colspan ='5'bgcolor='#DDFFE6'>十位</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>个位</td>");
        output.Write("<td colspan ='4'bgcolor='#FFCC33'<strong><font color='#DD0000'>大码个数</font></strong>");
        output.Write("<td colspan ='4'bgcolor='#FFFFFF'<strong><font color='#DD0000'>中码个数</font></strong>");
        output.Write("<td colspan ='4'bgcolor='#A6D7C1'<strong><font color='#DD0000'>小码个数</font></strong>");
        output.Write("<td colspan ='10'bgcolor='#C9E1BB'>总体走试分析</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan ='2' align ='center' vlign='middle'>期  数</td>");
        output.Write("<td rowspan ='2'>开奖号码</td>");
        output.Write("<td colspan = '5'>百位</td>");
        output.Write("<td colspan = '5'>十位</td>");
        output.Write("<td colspan = '5'>个位</td>");
        output.Write("<td colspan = '4'><strong><font color='#DD0000'>大码个数</font></strong></td>");
        output.Write("<td colspan = '4'><strong><font color='#DD0000'>中码个数</font></strong></td>");
        output.Write("<td colspan = '4'><strong><font color='#DD0000'>小码个数</font></strong></td>");
        output.Write("<td colspan = '10'>总体走试分析</td>");
        output.Write("<tr align ='center' vlign='center'>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>大</td>");
        output.Write("<td>中</td>");
        output.Write("<td>小</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>大</td>");
        output.Write("<td>中</td>");
        output.Write("<td>小</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>大</td>");
        output.Write("<td>中</td>");
        output.Write("<td>小</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>0</td>");
        output.Write("<td>1</td>");
        output.Write("<td>2</td>");
        output.Write("<td>3</td>");
        output.Write("<td>0</td>");
        output.Write("<td>1</td>");
        output.Write("<td>2</td>");
        output.Write("<td>3</td>");
        output.Write("<td>0</td>");
        output.Write("<td>1</td>");
        output.Write("<td>2</td>");
        output.Write("<td>3</td>");
        output.Write("<td>A</td>");
        output.Write("<td>B</td>");
        output.Write("<td>C</td>");
        output.Write("<td>D</td>");
        output.Write("<td>E</td>");
        output.Write("<td>F</td>");
        output.Write("<td>G</td>");
        output.Write("<td>H</td>");
        output.Write("<td>I</td>");
        output.Write("<td>J</td>");
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

    protected void GridViewbindColor()
    {
        for (int i = 2; i < 0x11; i++)
        {
            for (int num2 = 0; num2 < this.GridView1.Rows.Count; num2++)
            {
                if (this.GridView1.Rows[num2].Cells[i].Text == null)
                {
                    this.GridView1.Rows[num2].Cells[i].Text = "&nbsp";
                }
                if (((this.GridView1.Rows[num2].Cells[i].Text == "大") || (this.GridView1.Rows[num2].Cells[i].Text == "小")) || (this.GridView1.Rows[num2].Cells[i].Text == "中"))
                {
                    this.GridView1.Rows[num2].Cells[i].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[num2].Cells[i].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
        }
        for (int j = 0x11; j < 0x15; j++)
        {
            int num4 = j - 0x11;
            for (int num5 = 0; num5 < this.GridView1.Rows.Count; num5++)
            {
                if (this.GridView1.Rows[num5].Cells[j].Text == "0")
                {
                    this.GridView1.Rows[num5].Cells[j].BackColor = Color.FromArgb(0, 0, 0xcc);
                    this.GridView1.Rows[num5].Cells[j].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[num5].Cells[j].Text = num4.ToString();
                }
                else
                {
                    this.GridView1.Rows[num5].Cells[j].ForeColor = Color.FromArgb(0x80, 0x80, 0x80);
                }
            }
        }
        for (int k = 0x15; k < 0x19; k++)
        {
            int num7 = k - 0x15;
            for (int num8 = 0; num8 < this.GridView1.Rows.Count; num8++)
            {
                if (this.GridView1.Rows[num8].Cells[k].Text == "0")
                {
                    this.GridView1.Rows[num8].Cells[k].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[num8].Cells[k].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[num8].Cells[k].Text = num7.ToString();
                }
                else
                {
                    this.GridView1.Rows[num8].Cells[k].ForeColor = Color.FromArgb(0xb3, 0xb3, 0xb3);
                }
            }
        }
        for (int m = 0x19; m < 0x1d; m++)
        {
            int num10 = m - 0x19;
            for (int num11 = 0; num11 < this.GridView1.Rows.Count; num11++)
            {
                if (this.GridView1.Rows[num11].Cells[m].Text == "0")
                {
                    this.GridView1.Rows[num11].Cells[m].BackColor = Color.FromArgb(0, 0, 0xcc);
                    this.GridView1.Rows[num11].Cells[m].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[num11].Cells[m].Text = num10.ToString();
                }
                else
                {
                    this.GridView1.Rows[num11].Cells[m].ForeColor = Color.FromArgb(0x80, 0x80, 0x80);
                }
            }
        }
        for (int n = 0; n < this.GridView1.Rows.Count; n++)
        {
            for (int num13 = 0x1d; num13 < 0x27; num13++)
            {
                if (this.GridView1.Rows[n].Cells[num13].Text == "0")
                {
                    this.GridView1.Rows[n].Cells[num13].BackColor = Color.FromArgb(0x33, 0x80, 0xbd);
                    this.GridView1.Rows[n].Cells[num13].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
                else
                {
                    this.GridView1.Rows[n].Cells[num13].ForeColor = Color.FromArgb(0xb3, 0xb3, 0xb3);
                }
            }
        }
        for (int num14 = 0; num14 < this.GridView1.Rows.Count; num14++)
        {
            if (this.GridView1.Rows[num14].Cells[0x1d].Text == "0")
            {
                this.GridView1.Rows[num14].Cells[0x1d].Text = "A";
            }
            if (this.GridView1.Rows[num14].Cells[30].Text == "0")
            {
                this.GridView1.Rows[num14].Cells[30].Text = "B";
            }
            if (this.GridView1.Rows[num14].Cells[0x1f].Text == "0")
            {
                this.GridView1.Rows[num14].Cells[0x1f].Text = "C";
            }
            if (this.GridView1.Rows[num14].Cells[0x20].Text == "0")
            {
                this.GridView1.Rows[num14].Cells[0x20].Text = "D";
            }
            if (this.GridView1.Rows[num14].Cells[0x21].Text == "0")
            {
                this.GridView1.Rows[num14].Cells[0x21].Text = "E";
            }
            if (this.GridView1.Rows[num14].Cells[0x22].Text == "0")
            {
                this.GridView1.Rows[num14].Cells[0x22].Text = "F";
            }
            if (this.GridView1.Rows[num14].Cells[0x23].Text == "0")
            {
                this.GridView1.Rows[num14].Cells[0x23].Text = "G";
            }
            if (this.GridView1.Rows[num14].Cells[0x24].Text == "0")
            {
                this.GridView1.Rows[num14].Cells[0x24].Text = "H";
            }
            if (this.GridView1.Rows[num14].Cells[0x25].Text == "0")
            {
                this.GridView1.Rows[num14].Cells[0x25].Text = "I";
            }
            if (this.GridView1.Rows[num14].Cells[0x26].Text == "0")
            {
                this.GridView1.Rows[num14].Cells[0x26].Text = "J";
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.databind();
            this.GridViewbindColor();
            this.GridView1.Style["border-collapse"] = "";
        }
    }

    protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_DZX_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_DZX_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_DZX_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_DZX_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_DZX_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }
}

