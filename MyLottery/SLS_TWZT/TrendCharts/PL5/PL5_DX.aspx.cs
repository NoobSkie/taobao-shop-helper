using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class PL5_PL5_DX : TrendChartPageBase, IRequiresSessionState
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
                if ((this.GridView1.Rows[j].Cells[num3].Text == "大") || (this.GridView1.Rows[j].Cells[num3].Text == "小"))
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
                if ((this.GridView1.Rows[k].Cells[num5].Text == "大") || (this.GridView1.Rows[k].Cells[num5].Text == "小"))
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
                if ((this.GridView1.Rows[m].Cells[num7].Text == "大") || (this.GridView1.Rows[m].Cells[num7].Text == "小"))
                {
                    this.GridView1.Rows[m].Cells[num7].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[m].Cells[num7].ForeColor = Color.White;
                }
            }
        }
        for (int n = 0; n < this.GridView1.Rows.Count; n++)
        {
            for (int num9 = 0x11; num9 < 0x16; num9++)
            {
                this.GridView1.Rows[n].Cells[num9].BackColor = Color.FromArgb(0xdd, 0xff, 230);
                if ((this.GridView1.Rows[n].Cells[num9].Text == "大") || (this.GridView1.Rows[n].Cells[num9].Text == "小"))
                {
                    this.GridView1.Rows[n].Cells[num9].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[n].Cells[num9].ForeColor = Color.White;
                }
            }
        }
        for (int num10 = 0; num10 < this.GridView1.Rows.Count; num10++)
        {
            for (int num11 = 0x16; num11 < 0x1b; num11++)
            {
                this.GridView1.Rows[num10].Cells[num11].BackColor = Color.FromArgb(0xc1, 0xe7, 0xff);
                if ((this.GridView1.Rows[num10].Cells[num11].Text == "大") || (this.GridView1.Rows[num10].Cells[num11].Text == "小"))
                {
                    this.GridView1.Rows[num10].Cells[num11].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[num10].Cells[num11].ForeColor = Color.White;
                }
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='2' rowspan='5'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>大</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>小</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        for (int i = 0; i < 2; i++)
        {
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>大</td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>小</td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>大</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>小</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        }
        for (int j = 0; j < 4; j++)
        {
            output.Write("<tr align='center' valign='middle'>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>大</td>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            output.Write("<td bgcolor='#FCDFC5'onClick=Style(this,'#DD0000','#FCDFC5') style='color:#FCDFC5'>小</td>");
            output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
            for (int m = 0; m < 2; m++)
            {
                output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
                output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>大</td>");
                output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
                output.Write("<td bgcolor='#DDFFE6'onClick=Style(this,'#DD0000','#DDFFE6') style='color:#DDFFE6'>小</td>");
                output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
                output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
                output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>大</td>");
                output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
                output.Write("<td bgcolor='#C1E7FF'onClick=Style(this,'#DD0000','#C1E7FF') style='color:#C1E7FF'>小</td>");
                output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            }
        }
        output.Write("<tr align='center' vlign = 'middle'>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'><font color='DD0000'>大</font></td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        output.Write("<td bgcolor='#FCDFC5'><font color='DD0000'>小</font></td>");
        output.Write("<td bgcolor='#FCDFC5'>&nbsp;</td>");
        for (int k = 0; k < 2; k++)
        {
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'><font color='DD0000'>大</font></td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#DDFFE6'><font color='DD0000'>小</font></td>");
            output.Write("<td bgcolor='#DDFFE6'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'><font color='DD0000'>大</font></td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
            output.Write("<td bgcolor='#C1E7FF'><font color='DD0000'>小</font></td>");
            output.Write("<td bgcolor='#C1E7FF'>&nbsp;</td>");
        }
        output.Write("<tr align='center' vlign='center'>");
        output.Write("<td>期　数</td>");
        output.Write("<td>开奖号码</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>万位</td>");
        output.Write("<td colspan ='5'bgcolor='#DDFFE6'>千位</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>百位</td>");
        output.Write("<td colspan ='5'bgcolor='#DDFFE6'>十位</td>");
        output.Write("<td colspan ='5'bgcolor='#C1E7FF'>个位</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan ='2' align ='center' vlign='middle'>期  数</td>");
        output.Write("<td rowspan ='2'>开奖号码</td>");
        output.Write("<td colspan = '5'>万位</td>");
        output.Write("<td colspan = '5'>千位</td>");
        output.Write("<td colspan = '5'>百位</td>");
        output.Write("<td colspan = '5'>十位</td>");
        output.Write("<td colspan = '5'>个位</td>");
        output.Write("<tr align ='center' vlign='center'>");
        for (int i = 0; i < 5; i++)
        {
            output.Write("<td>&nbsp;</td>");
            output.Write("<td>大</td>");
            output.Write("<td>&nbsp;</td>");
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
        table = BLL.PL5_DX_SeleteByNum(30);
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
        DataTable table = BLL.PL5_DX_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_DX_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_DX_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_DX_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_DX_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }
}

