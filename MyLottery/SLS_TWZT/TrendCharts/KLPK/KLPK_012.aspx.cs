using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class KLPK_KLPK_012 : Page, IRequiresSessionState
{

    protected void ColorBind()
    {
        for (int i = 4; i < 0x18; i++)
        {
            for (int j = 0; j < this.GridView1.Rows.Count; j++)
            {
                if (((this.GridView1.Rows[j].Cells[i].Text == "0") || (this.GridView1.Rows[j].Cells[i].Text == "1")) || (this.GridView1.Rows[j].Cells[i].Text == "2"))
                {
                    this.GridView1.Rows[j].Cells[i].BackColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[j].Cells[i].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='4' rowspan='5'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        for (int i = 0; i < 2; i++)
        {
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>0</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>1</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>2</td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>0</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>1</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>2</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        }
        output.Write("<td bgcolor='#00FF80'>&nbsp;</td>");
        output.Write("<td bgcolor='#00FF80'>&nbsp;</td>");
        output.Write("<td bgcolor='#00FF80'>&nbsp;</td>");
        for (int j = 0; j < 4; j++)
        {
            output.Write("<tr align='center' valign='middle'>");
            for (int m = 0; m < 2; m++)
            {
                output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
                output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>0</td>");
                output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>1</td>");
                output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>2</td>");
                output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
                output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
                output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>0</td>");
                output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>1</td>");
                output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>2</td>");
                output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            }
            output.Write("<td bgcolor='#00FF80'>&nbsp;</td>");
            output.Write("<td bgcolor='#00FF80'>&nbsp;</td>");
            output.Write("<td bgcolor='#00FF80'>&nbsp;</td>");
        }
        output.Write("<tr align='center' vlign = 'middle'>");
        output.Write("<td><strong><font font-size='8px'>期号</font></strong></td>");
        output.Write("<td><strong><font font-size='8px'>开奖号码</font></strong></td>");
        output.Write("<td><strong><font font-size='8px'>和</font></strong></td>");
        output.Write("<td><strong><font font-size='8px'>跨</font></strong></td>");
        for (int k = 0; k < 2; k++)
        {
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'><font color='DD0000' font-size='8px'>0</font></td>");
            output.Write("<td bgcolor='#DDFFE6'><font color='DD0000' font-size='8px'>1</font></td>");
            output.Write("<td bgcolor='#DDFFE6'><font color='DD0000' font-size='8px'>2</font></td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'><strong><font color='DD0000' font-size='8px'>0</font></strong></td>");
            output.Write("<td bgcolor='#C1E7FF'><strong><font color='DD0000' font-size='8px'>1</font></strong></td>");
            output.Write("<td bgcolor='#C1E7FF'><strong><font color='DD0000' font-size='8px'>2</font></strong></td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        }
        output.Write("<td bgcolor='#00FF80'>&nbsp;</td>");
        output.Write("<td bgcolor='#00FF80'>&nbsp;</td>");
        output.Write("<td bgcolor='#00FF80'>&nbsp;</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan ='4' align='center' valign='middle'><strong><font font-size='8px'> 号  码  表</font></strong></td>");
        output.Write("<td colspan = '5' align='center' valign='middle'><strong><font font-size='8px'> 第一位012路</font></strong></td>");
        output.Write("<td colspan = '5' align='center' valign='middle'><strong><font font-size='8px'> 第二位012路</font></strong></td>");
        output.Write("<td colspan = '5' align='center' valign='middle'><strong><font font-size='8px'> 第三位012路</font></strong></td>");
        output.Write("<td colspan = '5' align='center' valign='middle'><strong><font font-size='8px'> 第四位012路</font></strong></td>");
        output.Write("<td rowspan='2' align='center' valign='middle' ><strong><font font-size='8px'> 0 数个数</font></strong></td>");
        output.Write("<td  rowspan='2' align='center' valign='middle' ><strong><font font-size='8px'> 1 数个数</font></strong></td>");
        output.Write("<td rowspan='2' align='center' valign='middle' ><strong><font font-size='8px'> 2 数个数</font></strong></td>");
        output.Write("<tr align ='center' vlign='center'>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'> 期号</font></strong></td>");
        output.Write("<td align='center' valign='middle'><strong><font font-size='8px'>开奖号码</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>和</font></strong></td>");
        output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>跨</font></strong></td>");
        for (int i = 0; i < 4; i++)
        {
            output.Write("<td>&nbsp;</td>");
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>0</font></strong></td>");
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>1</font></strong></td>");
            output.Write("<td align='center' valign='middle' ><strong><font font-size='8px'>2</font></strong></td>");
            output.Write("<td>&nbsp;</td>");
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
        DataTable table = new DataTable();
        table = BLL.KLPK_012_SeleteByNum(30);
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
        DataTable table = BLL.KLPK_012_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.KLPK_012_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.KLPK_012_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.KLPK_012_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.KLPK_012_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }
}

