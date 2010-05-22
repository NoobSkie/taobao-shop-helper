using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _7Xing_X7_DZX : TrendChartPageBase, IRequiresSessionState
{

    protected void ColorBind()
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            for (int j = 3; j < 0x25; j++)
            {
                if (((this.GridView1.Rows[i].Cells[j].Text == "大") || (this.GridView1.Rows[i].Cells[j].Text == "小")) || (this.GridView1.Rows[i].Cells[j].Text == "中"))
                {
                    this.GridView1.Rows[i].Cells[j].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.White;
                }
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='2' rowspan='5'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>大</td>");
        output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>中</td>");
        output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>小</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        for (int i = 0; i < 3; i++)
        {
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
        }
        for (int j = 0; j < 4; j++)
        {
            output.Write("<tr align='center' valign='middle'>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>大</td>");
            output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>中</td>");
            output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>小</td>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            for (int m = 0; m < 3; m++)
            {
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
            }
        }
        output.Write("<tr align='center' vlign = 'middle'>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'><font color='DD0000'>大</font></td>");
        output.Write("<td bgcolor='#FCDFC5'><font color='DD0000'>中</font></td>");
        output.Write("<td bgcolor='#FCDFC5'><font color='DD0000'>小</font></td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        for (int k = 0; k < 3; k++)
        {
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'><font color='DD0000'>大</font></td>");
            output.Write("<td bgcolor='#DDFFE6'><font color='DD0000'>中</font></td>");
            output.Write("<td bgcolor='#DDFFE6'><font color='DD0000'>小</font></td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'><font color='DD0000'>大</font></td>");
            output.Write("<td bgcolor='#C1E7FF'><font color='DD0000'>中</font></td>");
            output.Write("<td bgcolor='#C1E7FF'><font color='DD0000'>小</font></td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        }
        output.Write("<tr align='center' vlign='center'>");
        output.Write("<td>期  数</td>");
        output.Write("<td>开奖号码</td>");
        output.Write("<td colspan ='5'bgcolor='#FFC9C8'>第一位</td>");
        output.Write("<td colspan ='5'bgcolor='#DDFFE6'>第二位</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>第三位</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>第四位</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>第五位</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>第六位</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>第七位</td>");
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
        output.Write("<td colspan = '5'>第六位</td>");
        output.Write("<td colspan = '5'>第七位</td>");
        output.Write("<tr align ='center' vlign='center'>");
        for (int i = 0; i < 7; i++)
        {
            output.Write("<td>&nbsp;</td>");
            output.Write("<td>大</td>");
            output.Write("<td>中</td>");
            output.Write("<td>小</td>");
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
        table = BLL.X7_DZX_SeleteByNum(30);
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
        DataTable table = BLL.X7_DZX_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_DZX_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_DZX_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_DZX_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_DZX_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }
}

