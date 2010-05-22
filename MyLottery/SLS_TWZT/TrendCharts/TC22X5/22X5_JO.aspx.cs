using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class TC22X5_22X5_JO : Page, IRequiresSessionState
{

    protected void ColorBind()
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            for (int j = 3; j < 0x1b; j++)
            {
                if ((this.GridView1.Rows[i].Cells[j].Text == "偶") || (this.GridView1.Rows[i].Cells[j].Text == "奇"))
                {
                    this.GridView1.Rows[i].Cells[j].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.White;
                }
            }
            for (int k = 0x1b; k < 0x1d; k++)
            {
                if (this.GridView1.Rows[i].Cells[k].Text == "0")
                {
                    this.GridView1.Rows[i].Cells[k].Text = "&nbsp;";
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
        for (int i = 0; i < 2; i++)
        {
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
        }
        for (int j = 0; j < 4; j++)
        {
            output.Write("<td bgcolor='#EDFFD7'>&nbsp</td>");
        }
        for (int k = 0; k < 4; k++)
        {
            output.Write("<tr align='center' valign='middle'>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>奇</td>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>偶</td>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            for (int num4 = 0; num4 < 2; num4++)
            {
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
            }
            for (int num5 = 0; num5 < 4; num5++)
            {
                output.Write("<td bgcolor='#EDFFD7'>&nbsp</td>");
            }
        }
        output.Write("<tr align='center' vlign = 'middle'>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'><font color='DD0000'>奇</font></td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'><font color='DD0000'>偶</font></td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        for (int m = 0; m < 2; m++)
        {
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'><font color='DD0000'>奇</font></td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'><font color='DD0000'>偶</font></td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'><font color='DD0000'>奇</font></td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'><font color='DD0000'>偶</font></td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        }
        for (int n = 0; n < 4; n++)
        {
            output.Write("<td bgcolor='#EDFFD7'>&nbsp</td>");
        }
        output.Write("<tr align='center' vlign='center'>");
        output.Write("<td>期  数</td>");
        output.Write("<td>开奖号码</td>");
        output.Write("<td colspan ='5'bgcolor='#FFC9C8'>第一位</td>");
        output.Write("<td colspan ='5'bgcolor='#DDFFE6'>第二位</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>第三位</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>第四位</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>第五位</td>");
        for (int num8 = 0; num8 < 4; num8++)
        {
            output.Write("<td bgcolor='#EDFFD7'>&nbsp</td>");
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan ='2' align ='center' vlign='middle'>期  数</td>");
        output.Write("<td rowspan ='2'>开奖号码</td>");
        output.Write("<td colspan = '5'>第一位</td>");
        output.Write("<td colspan = '5'>第二位</td>");
        output.Write("<td colspan = '5'>第三位</td>");
        output.Write("<td colspan = '5'>第四位</td>");
        output.Write("<td colspan = '5'>第五位</td>");
        output.Write("<td rowspan ='2' width='30'>奇数个数</td>");
        output.Write("<td rowspan ='2' width='30'>偶数个数</td>");
        output.Write("<td rowspan ='2' width='30'>奇偶比</td>");
        output.Write("<td rowspan ='2' width='30'>奇偶差值</td>");
        output.Write("<tr align ='center' vlign='center'>");
        for (int i = 0; i < 5; i++)
        {
            output.Write("<td>&nbsp;</td>");
            output.Write("<td>奇</td>");
            output.Write("<td>&nbsp;</td>");
            output.Write("<td>偶</td>");
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
        table = BLL.TC22X5_JO_SeleteByNum(30);
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
        DataTable table = BLL.TC22X5_JO_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.TC22X5_JO_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.TC22X5_JO_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.TC22X5_JO_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.TC22X5_JO_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }
}

