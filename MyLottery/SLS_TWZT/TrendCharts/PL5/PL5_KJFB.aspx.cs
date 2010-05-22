using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class PL5_PL5_KJFB : TrendChartPageBase, IRequiresSessionState
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
        for (int j = 0; j < 3; j++)
        {
            for (int num4 = 0; num4 < this.GridView1.Rows.Count; num4++)
            {
                if ((num4 % 2) == 1)
                {
                    this.GridView1.Rows[num4].Cells[j].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
                }
            }
        }
        for (int k = 3; k < 13; k++)
        {
            int num6 = 0;
            for (int num7 = 0; num7 < this.GridView1.Rows.Count; num7++)
            {
                if ((num7 % 2) == 1)
                {
                    this.GridView1.Rows[num7].Cells[k].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
                }
                if (this.GridView1.Rows[num7].Cells[k].Text == "0")
                {
                    this.GridView1.Rows[num7].Cells[k].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[num7].Cells[k].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    num6++;
                    this.GridView1.Rows[num7].Cells[k].Text = (k - 3).ToString();
                }
            }
            this.num[k - 3] = num6;
            int num9 = this.RadioSelete();
            this.sum[k - 3] = (50 * num6) / num9;
        }
        for (int m = 13; m < 0x17; m++)
        {
            int num11 = 0;
            for (int num12 = 0; num12 < this.GridView1.Rows.Count; num12++)
            {
                if (this.GridView1.Rows[num12].Cells[m].Text == "0")
                {
                    this.GridView1.Rows[num12].Cells[m].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[num12].Cells[m].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    num11++;
                    this.GridView1.Rows[num12].Cells[m].Text = (m - 13).ToString();
                }
            }
            this.num[m - 3] = num11;
            int num14 = this.RadioSelete();
            this.sum[m - 3] = (50 * num11) / num14;
        }
        for (int n = 0x17; n < 0x21; n++)
        {
            int num16 = 0;
            for (int num17 = 0; num17 < this.GridView1.Rows.Count; num17++)
            {
                if ((num17 % 2) == 1)
                {
                    this.GridView1.Rows[num17].Cells[n].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
                }
                if (this.GridView1.Rows[num17].Cells[n].Text == "0")
                {
                    this.GridView1.Rows[num17].Cells[n].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[num17].Cells[n].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    num16++;
                    this.GridView1.Rows[num17].Cells[n].Text = (n - 0x17).ToString();
                }
            }
            this.num[n - 3] = num16;
            int num19 = this.RadioSelete();
            this.sum[n - 3] = (50 * num16) / num19;
        }
        for (int num20 = 0x21; num20 < 0x2b; num20++)
        {
            int num21 = 0;
            for (int num22 = 0; num22 < this.GridView1.Rows.Count; num22++)
            {
                if (this.GridView1.Rows[num22].Cells[num20].Text == "0")
                {
                    this.GridView1.Rows[num22].Cells[num20].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[num22].Cells[num20].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    num21++;
                    this.GridView1.Rows[num22].Cells[num20].Text = (num20 - 0x21).ToString();
                }
            }
            this.num[num20 - 3] = num21;
            int num24 = this.RadioSelete();
            this.sum[num20 - 3] = (50 * num21) / num24;
        }
        for (int num25 = 0x2b; num25 < 0x35; num25++)
        {
            int num26 = 0;
            for (int num27 = 0; num27 < this.GridView1.Rows.Count; num27++)
            {
                if ((num27 % 2) == 1)
                {
                    this.GridView1.Rows[num27].Cells[num25].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
                }
                if (this.GridView1.Rows[num27].Cells[num25].Text == "0")
                {
                    this.GridView1.Rows[num27].Cells[num25].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[num27].Cells[num25].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    num26++;
                    this.GridView1.Rows[num27].Cells[num25].Text = (num25 - 0x2b).ToString();
                }
            }
            this.num[num25 - 3] = num26;
            int num29 = this.RadioSelete();
            this.sum[num25 - 3] = (50 * num26) / num29;
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan = '5' colspan='2'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        output.Write("<td bgcolor ='#FFFFFF'>&nbsp</td>");
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
            output.Write("<td bgcolor ='#FFFFFF'>&nbsp</td>");
            for (int num7 = 0; num7 < 10; num7++)
            {
                output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
                output.Write(num7.ToString() + "</td>");
            }
            for (int num8 = 0; num8 < 10; num8++)
            {
                output.Write("<td bgcolor='#D0E6F7' style='color:#D0E6F7;'>");
                output.Write(num8.ToString() + "</td>");
            }
            for (int num9 = 0; num9 < 10; num9++)
            {
                output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
                output.Write(num9.ToString() + "</td>");
            }
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
            for (int num12 = 0; num12 < 4; num12++)
            {
            }
        }
        output.Write("<tr align = 'center' valign='middle'>");
        output.Write("<td rowspan ='2'>序号</td>");
        output.Write("<td colspan ='1' height='50'>出现次数</td>");
        output.Write("<td colspan ='1'>&nbsp</td>");
        for (int num13 = 0; num13 < 50; num13++)
        {
            output.Write("<td bgcolor='#FFFFFF' align='center' valign='bottom'>");
            output.Write(this.num[num13].ToString() + "<br><img src='../image/01[1].gif' width='8' height='" + this.sum[num13].ToString() + "' title='" + this.num[num13].ToString() + "'></td>");
        }
        output.Write("<tr align = 'center' valign='middle'>");
        output.Write("<td align = 'center' valign='middle'>数字序号</td>");
        output.Write("<td align = 'center'>开奖号</td>");
        for (int num14 = 0; num14 < 10; num14++)
        {
            output.Write("<td bgcolor ='#F8EFEF'><font color ='#FF0000'>");
            output.Write(num14.ToString() + "</font></td>");
        }
        for (int num15 = 0; num15 < 10; num15++)
        {
            output.Write("<td bgcolor ='#CAD9E8'><font color ='#OO33CC'>");
            output.Write(num15.ToString() + "</font></td>");
        }
        for (int num16 = 0; num16 < 10; num16++)
        {
            output.Write("<td bgcolor ='#F8EFEF'><font color ='#FF0000'>");
            output.Write(num16.ToString() + "</font></td>");
        }
        for (int num17 = 0; num17 < 10; num17++)
        {
            output.Write("<td bgcolor ='#CAD9E8'><font color ='#OO33CC'>");
            output.Write(num17.ToString() + "</font></td>");
        }
        for (int num18 = 0; num18 < 10; num18++)
        {
            output.Write("<td bgcolor ='#F8EFEF'><font color ='#FF0000'>");
            output.Write(num18.ToString() + "</font></td>");
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3' align='center' valign='middle'>序号</td>");
        output.Write("<td rowspan='3' align='center' valign='middle'>期数</td>");
        output.Write("<td rowspan='3' align='center' valign='middle'>开奖号</td>");
        output.Write("<td rowspan='1' colspan ='50' align='center' valign='middle'><strong><font color ='#FF0000'>排列五开奖号码</font></strong></td>");
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td colspan='10'>第一位</td>");
        output.Write("<td colspan='10'>第二位</td>");
        output.Write("<td colspan='10'>第三位</td>");
        output.Write("<td colspan='10'>第四位</td>");
        output.Write("<td colspan='10'>第五位</td>");
        output.Write("<tr align='center' valign='middle'>");
        for (int i = 0; i < 10; i++)
        {
            output.Write("<td bgcolor ='#F8EFEF'><font color ='#FF0000'>");
            output.Write(i.ToString() + "</font></td>");
        }
        for (int j = 0; j < 10; j++)
        {
            output.Write("<td bgcolor ='#CAD9E8'><font color ='#OO33CC'>");
            output.Write(j.ToString() + "</font></td>");
        }
        for (int k = 0; k < 10; k++)
        {
            output.Write("<td bgcolor ='#F8EFEF'><font color ='#FF0000'>");
            output.Write(k.ToString() + "</font></td>");
        }
        for (int m = 0; m < 10; m++)
        {
            output.Write("<td bgcolor ='#CAD9E8'><font color ='#OO33CC'>");
            output.Write(m.ToString() + "</font></td>");
        }
        for (int n = 0; n < 10; n++)
        {
            output.Write("<td bgcolor ='#F8EFEF'><font color ='#FF0000'>");
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
        table = BLL.PL5_HMFB_SeleteByNum(30);
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
        DataTable table = BLL.PL5_HMFB_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_HMFB_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_HMFB_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_HMFB_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_HMFB_SeleteByNum(10);
        this.GridView1.DataSource = table;
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

