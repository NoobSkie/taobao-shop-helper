using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class View_PL3_HMFB : TrendChartPageBase, IRequiresSessionState
{
    private int[] num = new int[50];
    private int[] sum = new int[50];

    protected void ColorBind()
    {
        for (int i = this.GridView1.Rows.Count; i > 0; i--)
        {
            int num2 = this.GridView1.Rows.Count - i;
            this.GridView1.Rows[num2].Cells[0].Text = i.ToString();
        }
        for (int j = 3; j < 0x21; j++)
        {
            int num4 = 0;
            for (int n = 0; n < this.GridView1.Rows.Count; n++)
            {
                if (this.GridView1.Rows[n].Cells[j].Text == "0")
                {
                    num4++;
                }
            }
            this.num[j - 3] = num4;
            int num6 = this.RadioSelete();
            this.sum[j - 3] = (50 * num4) / num6;
        }
        for (int k = 0x24; k < 0x38; k++)
        {
            int num8 = 0;
            for (int num9 = 0; num9 < this.GridView1.Rows.Count; num9++)
            {
                if (this.GridView1.Rows[num9].Cells[k].Text == "0")
                {
                    num8++;
                }
            }
            this.num[k - 6] = num8;
            int num10 = this.RadioSelete();
            this.sum[k - 6] = (50 * num8) / num10;
        }
        for (int m = 0; m < this.GridView1.Rows.Count; m++)
        {
            for (int num12 = 0; num12 < 2; num12++)
            {
                if ((m % 2) == 1)
                {
                    this.GridView1.Rows[m].Cells[num12].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
                }
            }
            for (int num13 = 3; num13 < 13; num13++)
            {
                if ((m % 2) == 1)
                {
                    this.GridView1.Rows[m].Cells[num13].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
                }
                if (this.GridView1.Rows[m].Cells[num13].Text == "0")
                {
                    this.GridView1.Rows[m].Cells[num13].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[m].Cells[num13].Text = (num13 - 3).ToString();
                    this.GridView1.Rows[m].Cells[num13].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
            for (int num15 = 13; num15 < 0x17; num15++)
            {
                if (this.GridView1.Rows[m].Cells[num15].Text == "0")
                {
                    this.GridView1.Rows[m].Cells[num15].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[m].Cells[num15].Text = (num15 - 13).ToString();
                    this.GridView1.Rows[m].Cells[num15].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
            for (int num17 = 0x17; num17 < 0x21; num17++)
            {
                if ((m % 2) == 1)
                {
                    this.GridView1.Rows[m].Cells[num17].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
                }
                if (this.GridView1.Rows[m].Cells[num17].Text == "0")
                {
                    this.GridView1.Rows[m].Cells[num17].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[m].Cells[num17].Text = (num17 - 0x17).ToString();
                    this.GridView1.Rows[m].Cells[num17].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
            for (int num19 = 0x24; num19 < 0x2e; num19++)
            {
                if (this.GridView1.Rows[m].Cells[num19].Text == "0")
                {
                    this.GridView1.Rows[m].Cells[num19].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[m].Cells[num19].Text = (num19 - 0x24).ToString();
                    this.GridView1.Rows[m].Cells[num19].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
            for (int num21 = 0x2e; num21 < 0x38; num21++)
            {
                if ((m % 2) == 1)
                {
                    this.GridView1.Rows[m].Cells[num21].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
                }
                if (this.GridView1.Rows[m].Cells[num21].Text == "0")
                {
                    this.GridView1.Rows[m].Cells[num21].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[m].Cells[num21].Text = (num21 - 0x2e).ToString();
                    this.GridView1.Rows[m].Cells[num21].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan = '5' colspan='2'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        output.Write("<td bgcolor ='#CAD9E8'>&nbsp</td>");
        for (int i = 0; i < 10; i++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
            output.Write(i.ToString() + "</td>");
        }
        for (int j = 0; j < 10; j++)
        {
            output.Write("<td bgcolor='#D0E6F7' onClick=Style(this,'#0000FF','#D0E6F7') style='color:#D0E6F7;'>");
            output.Write(j.ToString() + "</td>");
        }
        for (int k = 0; k < 10; k++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
            output.Write(k.ToString() + "</td>");
        }
        output.Write("<td bgcolor ='#FFD7EB'>&nbsp</td>");
        output.Write("<td bgcolor ='#DFF0F0'>&nbsp</td>");
        output.Write("<td bgcolor ='#FFF1D9'>&nbsp</td>");
        for (int m = 0; m < 10; m++)
        {
            output.Write("<td bgcolor='#D0E6F7' onClick=Style(this,'#0000FF','#D0E6F7') style='color:#D0E6F7;'>");
            output.Write(m.ToString() + "</td>");
        }
        for (int n = 0; n < 10; n++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
            output.Write(n.ToString() + "</td>");
        }
        for (int num6 = 0; num6 < 4; num6++)
        {
            output.Write("<tr align ='center' valign='middle'>");
            output.Write("<td bgcolor ='#CAD9E8'>&nbsp</td>");
            for (int num7 = 0; num7 < 10; num7++)
            {
                output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
                output.Write(num7.ToString() + "</td>");
            }
            for (int num8 = 0; num8 < 10; num8++)
            {
                output.Write("<td bgcolor='#D0E6F7' onClick=Style(this,'#0000FF','#D0E6F7') style='color:#D0E6F7;'>");
                output.Write(num8.ToString() + "</td>");
            }
            for (int num9 = 0; num9 < 10; num9++)
            {
                output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
                output.Write(num9.ToString() + "</td>");
            }
            output.Write("<td bgcolor ='#FFD7EB'>&nbsp</td>");
            output.Write("<td bgcolor ='#DFF0F0'>&nbsp</td>");
            output.Write("<td bgcolor ='#FFF1D9'>&nbsp</td>");
            for (int num10 = 0; num10 < 10; num10++)
            {
                output.Write("<td bgcolor='#D0E6F7' onClick=Style(this,'#0000FF','#D0E6F7') style='color:#D0E6F7;'>");
                output.Write(num10.ToString() + "</td>");
            }
            for (int num11 = 0; num11 < 10; num11++)
            {
                output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
                output.Write(num11.ToString() + "</td>");
            }
        }
        output.Write("<tr align = 'center' valign='middle'>");
        output.Write("<td rowspan ='2'>序号</td>");
        output.Write("<td colspan ='1' heigh='50px'>出现次数</td>");
        output.Write("<td colspan ='1' heigh='50px'>&nbsp</td>");
        for (int num12 = 0; num12 < 30; num12++)
        {
            output.Write("<td bgcolor='#FFFFFF' align='center' valign='bottom'>");
            output.Write(this.num[num12].ToString() + "<br><img src='../image/01[1].gif' width='8' height='" + this.sum[num12].ToString() + "' title='" + this.num[num12].ToString() + "'></td>");
        }
        output.Write("<td rowspan='2' align ='center' valign='middle' width='15'>和数值</td>");
        output.Write("<td rowspan='2' align ='center' valign='middle' width='20'>奇偶比</td>");
        output.Write("<td rowspan='2' align ='center' valign='middle' width='20'>大小比</td>");
        for (int num13 = 30; num13 < 50; num13++)
        {
            output.Write("<td bgcolor='#FFFFFF' align='center' valign='bottom'>");
            output.Write(this.num[num13].ToString() + "<br><img src='../image/01[1].gif'  height='" + this.sum[num13].ToString() + "px' title='" + this.num[num13].ToString() + "' width='8px'></td>");
        }
        output.Write("<tr align = 'center' valign='middle'>");
        output.Write("<td align = 'center' valign='middle'>数字序号</td>");
        output.Write("<td align = 'center'>开奖号</td>");
        for (int num14 = 0; num14 < 10; num14++)
        {
            output.Write("<td bgcolor='#F8EFEF'><font color ='#FF0000'>");
            output.Write(num14.ToString() + "</td>");
        }
        for (int num15 = 0; num15 < 10; num15++)
        {
            output.Write("<td bgcolor='#CAD9E8'><font color ='#0033CC'>");
            output.Write(num15.ToString() + "</td>");
        }
        for (int num16 = 0; num16 < 10; num16++)
        {
            output.Write("<td bgcolor='#F8EFEF'><font color ='#FF0000'>");
            output.Write(num16.ToString() + "</td>");
        }
        for (int num17 = 0; num17 < 10; num17++)
        {
            output.Write("<td bgcolor='#CAD9E8'><font color ='#0033CC'>");
            output.Write(num17.ToString() + "</td>");
        }
        for (int num18 = 0; num18 < 10; num18++)
        {
            output.Write("<td bgcolor='#F8EFEF'><font color ='#FF0000'>");
            output.Write(num18.ToString() + "</td>");
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3' align ='center' valign='middle'>序号</td>");
        output.Write("<td rowspan='3'>期数</td>");
        output.Write("<td rowspan='3'>开奖号</td>");
        output.Write("<td rowspan='1' colspan ='30'><font color='#FF0000'>排列三开奖号码</font></td>");
        output.Write("<td rowspan='3'>和数值</td>");
        output.Write("<td rowspan='3'>奇偶比</td>");
        output.Write("<td rowspan='3'>大小比</td>");
        output.Write("<td rowspan='2' colspan='10'>跨度走试</td>");
        output.Write("<td  rowspan='2' colspan='10'>跨度走试</td>");
        output.Write("<tr align ='center' valign='middle'>");
        output.Write("<td colspan='10'>第一位</td>");
        output.Write("<td colspan='10'>第二位</td>");
        output.Write("<td colspan='10'>第三位</td>");
        output.Write("<tr align ='center' valign='middle'>");
        for (int i = 0; i < 10; i++)
        {
            output.Write("<td BackColor ='#F8EFEF'><font color ='#FF0000'>");
            output.Write(i.ToString() + "</font></td>");
        }
        for (int j = 0; j < 10; j++)
        {
            output.Write("<td BackColor ='#CAD9E8'><font color ='#OO33CC'>");
            output.Write(j.ToString() + "</font></td>");
        }
        for (int k = 0; k < 10; k++)
        {
            output.Write("<td BackColor ='#F8EFEF'><font color ='#FF0000'>");
            output.Write(k.ToString() + "</font></td>");
        }
        for (int m = 0; m < 10; m++)
        {
            output.Write("<td BackColor ='#CAD9E8'><font color ='#OO33CC'>");
            output.Write(m.ToString() + "</font></td>");
        }
        for (int n = 0; n < 10; n++)
        {
            output.Write("<td BackColor ='#F8EFEF'><font color ='#FF0000'>");
            output.Write(n.ToString() + "</font></td>");
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
        table = BLL.PL3_HMFB_SeleteByNum(30);
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
        DataTable table = BLL.PL3_HMFB_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_HMFB_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_HMFB_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_HMFB_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        BLL.PL3_HMFB_SeleteByNum(10);
        this.GridView1.DataSource = BLL.PL3_HMFB_SeleteByNum(10);
        this.GridView1.DataBind();
        this.ColorBind();
    }

    private int RadioSelete()
    {
        int num = 1;
        if (this.RadioButton1.Checked)
        {
            num = 80;
        }
        if (this.RadioButton2.Checked)
        {
            num = 40;
        }
        if (this.RadioButton3.Checked)
        {
            num = 0x19;
        }
        if (this.RadioButton4.Checked)
        {
            num = 15;
        }
        if (this.RadioButton5.Checked)
        {
            num = 8;
        }
        return num;
    }
}

