using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class KLPK_KLPK_KJFB : Page, IRequiresSessionState
{

    protected void ColorBind()
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            for (int j = 4; j < 0x11; j++)
            {
                if (this.GridView1.Rows[i].Cells[j].Text != "&nbsp;")
                {
                    this.GridView1.Rows[i].Cells[j].BackColor = Color.FromArgb(0xff, 0, 0);
                }
            }
            for (int k = 0x11; k < 30; k++)
            {
                if (this.GridView1.Rows[i].Cells[k].Text != "&nbsp;")
                {
                    this.GridView1.Rows[i].Cells[k].BackColor = Color.FromArgb(0, 0, 0xff);
                }
            }
            for (int m = 30; m < 0x2b; m++)
            {
                if (this.GridView1.Rows[i].Cells[m].Text != "&nbsp;")
                {
                    this.GridView1.Rows[i].Cells[m].BackColor = Color.FromArgb(0xff, 0, 0);
                }
            }
            for (int n = 0x2b; n < 0x38; n++)
            {
                if (this.GridView1.Rows[i].Cells[n].Text != "&nbsp;")
                {
                    this.GridView1.Rows[i].Cells[n].BackColor = Color.FromArgb(0, 0, 0xff);
                }
            }
            for (int num6 = 0x38; num6 < 0x40; num6++)
            {
                if (this.GridView1.Rows[i].Cells[num6].Text != "&nbsp;")
                {
                    this.GridView1.Rows[i].Cells[num6].BackColor = Color.FromArgb(0xff, 0, 0);
                }
            }
            for (int num7 = 0x40; num7 < 70; num7++)
            {
                if (this.GridView1.Rows[i].Cells[num7].Text != "&nbsp;")
                {
                    this.GridView1.Rows[i].Cells[num7].BackColor = Color.FromArgb(0, 0, 0xff);
                }
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='4' rowspan='5'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        for (int i = 0; i < 2; i++)
        {
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>A</td>");
            for (int m = 2; m < 10; m++)
            {
                output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>");
                output.Write(m.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>T</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>J</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>Q</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>K</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>A</td>");
            for (int n = 2; n < 10; n++)
            {
                output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>");
                output.Write(n.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>T</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>J</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>Q</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>K</td>");
        }
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>A</td>");
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>B</td>");
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>C</td>");
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>D</td>");
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>E</td>");
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>F</td>");
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>G</td>");
        output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>H</td>");
        output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>N</td>");
        output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>0</td>");
        output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>1</td>");
        output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>2</td>");
        output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>3</td>");
        output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>4</td>");
        for (int j = 0; j < 4; j++)
        {
            output.Write("<tr align='center' valign='middle'>");
            for (int num5 = 0; num5 < 2; num5++)
            {
                output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>A</td>");
                for (int num6 = 2; num6 < 10; num6++)
                {
                    output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>");
                    output.Write(num6.ToString() + "</td>");
                }
                output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>T</td>");
                output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>J</td>");
                output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>Q</td>");
                output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>K</td>");
                output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>A</td>");
                for (int num7 = 2; num7 < 10; num7++)
                {
                    output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>");
                    output.Write(num7.ToString() + "</td>");
                }
                output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>T</td>");
                output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>J</td>");
                output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>Q</td>");
                output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>K</td>");
            }
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>A</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>B</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>C</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>D</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>E</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>F</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>G</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>H</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>N</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>0</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>1</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>2</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>3</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#0000FF','#C1E7FF') style='color:#C1E7FF'>4</td>");
        }
        output.Write("<tr align ='center' vlign='center'>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'> 期号</font></strong></td>");
        output.Write("<td align='center' valign='middle'><strong><font font-size='8px'>开奖号码</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>和</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>跨</font></strong></td>");
        for (int k = 0; k < 4; k++)
        {
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>A</font></strong></td>");
            for (int num9 = 2; num9 < 10; num9++)
            {
                output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>");
                output.Write(num9.ToString() + "</font></strong></td>");
            }
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>T</font></strong></td>");
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>J</font></strong></td>");
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>Q</font></strong></td>");
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>K</font></strong></td>");
        }
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>A</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>B</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>C</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>D</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>E</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>F</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>G</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>H</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>N</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>0</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>1</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>2</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>3</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>4</font></strong></td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan ='4' align='center' valign='middle'><strong><font font-size='8px'> 号  码  表</font></strong></td>");
        output.Write("<td colspan = '13' align='center' valign='middle'><strong><font font-size='8px'> 第一位号码</font></strong></td>");
        output.Write("<td colspan = '13' align='center' valign='middle'><strong><font font-size='8px'> 第二位号码</font></strong></td>");
        output.Write("<td colspan = '13' align='center' valign='middle'><strong><font font-size='8px'> 第三位号码</font></strong></td>");
        output.Write("<td colspan = '13' align='center' valign='middle'><strong><font font-size='8px'> 第四位号码</font></strong></td>");
        output.Write("<td colspan = '8' align='center' valign='middle' ><strong><font font-size='8px'> 类型走试图</font></strong></td>");
        output.Write("<td  colspan = '6' align='center' valign='middle' ><strong><font font-size='8px'>等差走试图</font></strong></td>");
        output.Write("<tr align ='center' vlign='center'>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'> 期号</font></strong></td>");
        output.Write("<td align='center' valign='middle'><strong><font font-size='8px'>开奖号码</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>和</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>跨</font></strong></td>");
        for (int i = 0; i < 4; i++)
        {
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>A</font></strong></td>");
            for (int j = 2; j < 10; j++)
            {
                output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>");
                output.Write(j.ToString() + "</font></strong></td>");
            }
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>T</font></strong></td>");
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>J</font></strong></td>");
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>Q</font></strong></td>");
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>K</font></strong></td>");
        }
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>A</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>B</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>C</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>D</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>E</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>F</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>G</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>H</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>N</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>0</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>1</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>2</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>3</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>4</font></strong></td>");
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
        table = BLL.KLPK_KJFB_SeleteByNum(30);
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
        DataTable table = BLL.KLPK_KJFB_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.KLPK_KJFB_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.KLPK_KJFB_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.KLPK_KJFB_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.KLPK_KJFB_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }
}

