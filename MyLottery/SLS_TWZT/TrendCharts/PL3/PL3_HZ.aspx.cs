using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class View_PL3_HZ : TrendChartPageBase, IRequiresSessionState
{
    private int[] num = new int[0x2a];
    private int[] sum = new int[0x2a];

    protected void ColorBind()
    {
        for (int i = 4; i < 11; i++)
        {
            int num2 = 0;
            for (int num3 = 0; num3 < this.GridView1.Rows.Count; num3++)
            {
                if (this.GridView1.Rows[num3].Cells[i].Text == "0")
                {
                    this.GridView1.Rows[num3].Cells[i].BackColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[num3].Cells[i].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[num3].Cells[i].Text = (i - 4).ToString();
                    num2++;
                }
            }
            this.num[i - 4] = num2;
            int num5 = this.RadioSelete();
            this.sum[i - 4] = (50 * num2) / num5;
        }
        for (int j = 12; j < 0x13; j++)
        {
            int num7 = 0;
            for (int num8 = 0; num8 < this.GridView1.Rows.Count; num8++)
            {
                if (this.GridView1.Rows[num8].Cells[j].Text == "0")
                {
                    this.GridView1.Rows[num8].Cells[j].BackColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[num8].Cells[j].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[num8].Cells[j].Text = (j - 5).ToString();
                    num7++;
                }
            }
            this.num[j - 5] = num7;
            int num10 = this.RadioSelete();
            this.sum[j - 5] = (50 * num7) / num10;
        }
        for (int k = 20; k < 0x1b; k++)
        {
            int num12 = 0;
            for (int num13 = 0; num13 < this.GridView1.Rows.Count; num13++)
            {
                if (this.GridView1.Rows[num13].Cells[k].Text == "0")
                {
                    this.GridView1.Rows[num13].Cells[k].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[num13].Cells[k].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[num13].Cells[k].Text = (k - 6).ToString();
                    num12++;
                }
            }
            this.num[k - 6] = num12;
            int num15 = this.RadioSelete();
            this.sum[k - 6] = (50 * num12) / num15;
        }
        for (int m = 0x1c; m < 0x23; m++)
        {
            int num17 = 0;
            for (int num18 = 0; num18 < this.GridView1.Rows.Count; num18++)
            {
                if (this.GridView1.Rows[num18].Cells[m].Text == "0")
                {
                    this.GridView1.Rows[num18].Cells[m].BackColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[num18].Cells[m].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[num18].Cells[m].Text = (m - 7).ToString();
                    num17++;
                }
            }
            this.num[m - 7] = num17;
            int num20 = this.RadioSelete();
            this.sum[m - 7] = (50 * num17) / num20;
        }
        for (int n = 0x24; n < 0x2e; n++)
        {
            int num22 = 0;
            for (int num23 = 0; num23 < this.GridView1.Rows.Count; num23++)
            {
                if (this.GridView1.Rows[num23].Cells[n].Text == "0")
                {
                    this.GridView1.Rows[num23].Cells[n].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[num23].Cells[n].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[num23].Cells[n].Text = (n - 0x24).ToString();
                    num22++;
                }
            }
            this.num[n - 8] = num22;
            int num25 = this.RadioSelete();
            this.sum[n - 8] = (50 * num22) / num25;
        }
        for (int num26 = 0x2f; num26 < 0x31; num26++)
        {
            int num27 = 0;
            for (int num28 = 0; num28 < this.GridView1.Rows.Count; num28++)
            {
                if ((this.GridView1.Rows[num28].Cells[num26].Text == "奇") || (this.GridView1.Rows[num28].Cells[num26].Text == "偶"))
                {
                    this.GridView1.Rows[num28].Cells[num26].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[num28].Cells[num26].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    num27++;
                }
            }
            this.num[num26 - 9] = num27;
            int num29 = this.RadioSelete();
            this.sum[num26 - 9] = (50 * num27) / num29;
        }
        for (int num30 = 50; num30 < 0x34; num30++)
        {
            int num31 = 0;
            for (int num32 = 0; num32 < this.GridView1.Rows.Count; num32++)
            {
                if ((this.GridView1.Rows[num32].Cells[num30].Text == "大") || (this.GridView1.Rows[num32].Cells[num30].Text == "小"))
                {
                    this.GridView1.Rows[num32].Cells[num30].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[num32].Cells[num30].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    num31++;
                }
            }
            this.num[num30 - 10] = num31;
            int num33 = this.RadioSelete();
            this.sum[num30 - 10] = (50 * num31) / num33;
        }
        for (int num34 = 0; num34 < this.GridView1.Rows.Count; num34++)
        {
            for (int num35 = 0; num35 < this.GridView1.Columns.Count; num35++)
            {
                if (this.GridView1.Rows[num34].Cells[num35].Text == "-1")
                {
                    this.GridView1.Rows[num34].Cells[num35].Text = "&nbsp;";
                }
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan = '5' colspan='2'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int i = 0; i < 7; i++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#FF0000','#FFFFFF') style='color:#FFFFFF;'>");
            output.Write(i.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int j = 7; j < 14; j++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#FF0000','#FFFFFF') style='color:#FFFFFF;'>");
            output.Write(j.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int k = 14; k < 0x15; k++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#FF0000','#FFFFFF') style='color:#FFFFFF;'>");
            output.Write(k.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int m = 0x15; m < 0x1c; m++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#FF0000','#FFFFFF') style='color:#FFFFFF;'>");
            output.Write(m.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int n = 0; n < 10; n++)
        {
            output.Write("<td bgcolor='#E3F4E3' onClick=Style(this,'#0000FF','#E3F4E3') style='color:#E3F4E3;'>");
            output.Write(n.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>奇</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>偶</td>");
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000FF','#FFFFFF') style='color:#FFFFFF;'>大</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000FF','#FFFFFF') style='color:#FFFFFF;'>小</td>");
        for (int num6 = 0; num6 < 4; num6++)
        {
            output.Write("<tr align ='center' valign='middle'>");
            output.Write("<td>&nbsp</td>");
            output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
            for (int num7 = 0; num7 < 7; num7++)
            {
                output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#FF0000','#FFFFFF') style='color:#FFFFFF;'>");
                output.Write(num7.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
            for (int num8 = 7; num8 < 14; num8++)
            {
                output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#FF0000','#FFFFFF') style='color:#FFFFFF;'>");
                output.Write(num8.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
            for (int num9 = 14; num9 < 0x15; num9++)
            {
                output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#FF0000','#FFFFFF') style='color:#FFFFFF;'>");
                output.Write(num9.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
            for (int num10 = 0x15; num10 < 0x1c; num10++)
            {
                output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#FF0000','#FFFFFF') style='color:#FFFFFF;'>");
                output.Write(num10.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
            for (int num11 = 0; num11 < 10; num11++)
            {
                output.Write("<td bgcolor='#E3F4E3' onClick=Style(this,'#0000FF','#E3F4E3') style='color:#E3F4E3;'>");
                output.Write(num11.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>奇</td>");
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>偶</td>");
            output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000FF','#FFFFFF') style='color:#FFFFFF;'>大</td>");
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000FF','#FFFFFF') style='color:#FFFFFF;'>小</td>");
        }
        output.Write("<tr align = 'center' valign='middle'>");
        output.Write("<td height='50'>出现次数</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int num12 = 0; num12 < 7; num12++)
        {
            output.Write("<td bgcolor='#FFFFFF' align='center' valign='bottom'>");
            output.Write(this.num[num12].ToString() + "<br><img src='../image/01[1].gif' width='8' height='" + this.sum[num12].ToString() + "' title='" + this.num[num12].ToString() + "'></td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int num13 = 7; num13 < 14; num13++)
        {
            output.Write("<td bgcolor='#FFFFFF' align='center' valign='bottom'>");
            output.Write(this.num[num13].ToString() + "<br><img src='../image/01[1].gif' width='8' height='" + this.sum[num13].ToString() + "' title='" + this.num[num13].ToString() + "'></td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int num14 = 14; num14 < 0x15; num14++)
        {
            output.Write("<td bgcolor='#FFFFFF' align='center' valign='bottom'>");
            output.Write(this.num[num14].ToString() + "<br><img src='../image/01[1].gif' width='8' height='" + this.sum[num14].ToString() + "' title='" + this.num[num14].ToString() + "'></td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int num15 = 0x15; num15 < 0x1c; num15++)
        {
            output.Write("<td bgcolor='#FFFFFF' align='center' valign='bottom'>");
            output.Write(this.num[num15].ToString() + "<br><img src='../image/01[1].gif' width='8' height='" + this.sum[num15].ToString() + "' title='" + this.num[num15].ToString() + "'></td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int num16 = 0x1c; num16 < 0x26; num16++)
        {
            output.Write("<td bgcolor='#FFFFFF' align='center' valign='bottom'>");
            output.Write(this.num[num16].ToString() + "<br><img src='../image/01[1].gif' width='8' height='" + this.sum[num16].ToString() + "' title='" + this.num[num16].ToString() + "'></td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int num17 = 0x26; num17 < 40; num17++)
        {
            output.Write("<td bgcolor='#FFFFFF' align='center' valign='bottom'>");
            output.Write(this.num[num17].ToString() + "<br><img src='../image/01[1].gif' width='8' height='" + this.sum[num17].ToString() + "' title='" + this.num[num17].ToString() + "'></td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int num18 = 40; num18 < 0x2a; num18++)
        {
            output.Write("<td bgcolor='#FFFFFF' align='center' valign='bottom'>");
            output.Write(this.num[num18].ToString() + "<br><img src='../image/01[1].gif' width='8' height='" + this.sum[num18].ToString() + "' title='" + this.num[num18].ToString() + "'></td>");
        }
        output.Write("<tr align = 'center' valign='middle'>");
        output.Write("<td >期  数</td>");
        output.Write("<td >开奖号</td>");
        output.Write("<td >和值</td>");
        for (int num19 = 0; num19 < 4; num19++)
        {
            int num20 = num19 * 7;
            output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
            for (int num21 = 0; num21 < 7; num21++)
            {
                output.Write("<td bgcolor='#E1EFFF'><strong><font color='#FF0000'>");
                output.Write(num20.ToString() + "</td>");
                num20++;
            }
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int num22 = 0; num22 < 10; num22++)
        {
            output.Write("<td bgcolor='#C9E9CA'><strong><font color='#FF0000'>");
            output.Write(num22.ToString() + "</font></strong></td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        output.Write("<td bgcolor='#CACAFF'><strong><font color='#DD0000'>奇</font></strong></td>");
        output.Write("<td bgcolor='#CACAFF'><strong><font color='#DD0000'>偶</font></strong></td>");
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        output.Write("<td bgcolor='#C9E9CA'><strong><font color='#DD0000'>大</font></strong></td>");
        output.Write("<td bgcolor='#C9E9CA'><strong><font color='#DD0000'>小</font></strong></td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'>期  数</td>");
        output.Write("<td rowspan='2'>开奖号</td>");
        output.Write("<td rowspan='2'>和<br>值</td>");
        output.Write("<td colspan ='33' align='center' valign='middle'>排列3和值区</td>");
        output.Write("<td colspan ='11' align='center' valign='middle'>合值区</td>");
        output.Write("<td colspan ='3' align='center' valign='middle'>奇偶</td>");
        output.Write("<td colspan ='2' align='center' valign='middle'>大小</td>");
        output.Write("<tr align = 'center' valign='middle'>");
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int i = 0; i < 7; i++)
        {
            output.Write("<td align = 'center' valign='middle' bgcolor='#E1EFFF'><strong><font color='#FF0000'>");
            output.Write(i.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int j = 7; j < 14; j++)
        {
            output.Write("<td align = 'center' valign='middle' bgcolor='#E1EFFF'><strong><font color='#FF0000'>");
            output.Write(j.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int k = 14; k < 0x15; k++)
        {
            output.Write("<td align = 'center' valign='middle' bgcolor='#E1EFFF'><strong><font color='#FF0000'>");
            output.Write(k.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int m = 0x15; m < 0x1c; m++)
        {
            output.Write("<td align = 'center' valign='middle' bgcolor='#E1EFFF'><strong><font color='#FF0000'>");
            output.Write(m.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        for (int n = 0; n < 10; n++)
        {
            output.Write("<td align = 'center' valign='middle' bgcolor='#C9E9CA'><strong><font color='#FF0000'>");
            output.Write(n.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        output.Write("<td bgcolor='#CACAFF'><strong><font color='#DD0000'>奇</font></strong></td>");
        output.Write("<td bgcolor='#CACAFF'><strong><font color='#DD0000'>偶</font></strong></td>");
        output.Write("<td bgcolor='#CCCCCC' width='2px'>&nbsp</td>");
        output.Write("<td bgcolor='#C9E9CA'><strong><font color='#DD0000'>大</font></strong></td>");
        output.Write("<td bgcolor='#C9E9CA'><strong><font color='#DD0000'>小</font></strong></td>");
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
        table = BLL.PL3_HZ_SeleteByNum(30);
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
        DataTable table = BLL.PL3_HZ_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_HZ_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_HZ_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_HZ_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        BLL.PL3_WH_SeleteByNum(10);
        this.GridView1.DataSource = BLL.PL3_HZ_SeleteByNum(10);
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

