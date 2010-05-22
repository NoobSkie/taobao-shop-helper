using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _7Xing_7X_HMFB : TrendChartPageBase, IRequiresSessionState
{
    private int[] num = new int[70];
    private int[] sum = new int[70];

    protected void ColorBind()
    {
        for (int i = 1; i < 11; i++)
        {
            for (int num2 = 0; num2 < this.GridView1.Rows.Count; num2++)
            {
                if ((num2 % 2) == 1)
                {
                    this.GridView1.Rows[num2].Cells[i].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
                }
                if (this.GridView1.Rows[num2].Cells[i].Text != "-1")
                {
                    this.GridView1.Rows[num2].Cells[i].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[num2].Cells[i].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
        }
        for (int j = 11; j < 0x15; j++)
        {
            for (int num4 = 0; num4 < this.GridView1.Rows.Count; num4++)
            {
                if (this.GridView1.Rows[num4].Cells[j].Text != "-1")
                {
                    this.GridView1.Rows[num4].Cells[j].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[num4].Cells[j].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
        }
        for (int k = 0x15; k < 0x1f; k++)
        {
            for (int num6 = 0; num6 < this.GridView1.Rows.Count; num6++)
            {
                if ((num6 % 2) == 1)
                {
                    this.GridView1.Rows[num6].Cells[k].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
                }
                if (this.GridView1.Rows[num6].Cells[k].Text != "-1")
                {
                    this.GridView1.Rows[num6].Cells[k].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[num6].Cells[k].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
        }
        for (int m = 0x1f; m < 0x29; m++)
        {
            for (int num8 = 0; num8 < this.GridView1.Rows.Count; num8++)
            {
                if (this.GridView1.Rows[num8].Cells[m].Text != "-1")
                {
                    this.GridView1.Rows[num8].Cells[m].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[num8].Cells[m].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
        }
        for (int n = 0x29; n < 0x33; n++)
        {
            for (int num10 = 0; num10 < this.GridView1.Rows.Count; num10++)
            {
                if ((num10 % 2) == 1)
                {
                    this.GridView1.Rows[num10].Cells[n].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
                }
                if (this.GridView1.Rows[num10].Cells[n].Text != "-1")
                {
                    this.GridView1.Rows[num10].Cells[n].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[num10].Cells[n].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
        }
        for (int num11 = 0x33; num11 < 0x3d; num11++)
        {
            for (int num12 = 0; num12 < this.GridView1.Rows.Count; num12++)
            {
                if (this.GridView1.Rows[num12].Cells[num11].Text != "-1")
                {
                    this.GridView1.Rows[num12].Cells[num11].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[num12].Cells[num11].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
        }
        for (int num13 = 0x3d; num13 < 0x47; num13++)
        {
            for (int num14 = 0; num14 < this.GridView1.Rows.Count; num14++)
            {
                if ((num14 % 2) == 1)
                {
                    this.GridView1.Rows[num14].Cells[num13].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
                }
                if (this.GridView1.Rows[num14].Cells[num13].Text != "-1")
                {
                    this.GridView1.Rows[num14].Cells[num13].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[num14].Cells[num13].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                }
            }
        }
        for (int num15 = 0; num15 < this.GridView1.Rows.Count; num15++)
        {
            if ((num15 % 2) == 1)
            {
                this.GridView1.Rows[num15].Cells[0].BackColor = Color.FromArgb(0xe9, 0xf8, 0xcf);
            }
        }
        for (int num16 = 1; num16 < 0x47; num16++)
        {
            int num17 = 0;
            for (int num18 = 0; num18 < this.GridView1.Rows.Count; num18++)
            {
                if (this.GridView1.Rows[num18].Cells[num16].Text != "-1")
                {
                    num17++;
                }
                this.num[num16 - 1] = num17;
                int num19 = this.RadioSelete();
                this.sum[num16 - 1] = (50 * num17) / num19;
                if (this.GridView1.Rows[num18].Cells[num16].Text == "-1")
                {
                    this.GridView1.Rows[num18].Cells[num16].Text = "&nbsp;";
                }
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan = '5'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
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
        for (int num6 = 0; num6 < 10; num6++)
        {
            output.Write("<td bgcolor='#D0E6F7' onClick=Style(this,'#0000FF','#D0E6F7') style='color:#D0E6F7;'>");
            output.Write(num6.ToString() + "</td>");
        }
        for (int num7 = 0; num7 < 10; num7++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
            output.Write(num7.ToString() + "</td>");
        }
        for (int num8 = 0; num8 < 4; num8++)
        {
            output.Write("<tr align ='center' valign='middle'>");
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
            for (int num12 = 0; num12 < 10; num12++)
            {
                output.Write("<td bgcolor='#D0E6F7' onClick=Style(this,'#0000FF','#D0E6F7') style='color:#D0E6F7;'>");
                output.Write(num12.ToString() + "</td>");
            }
            for (int num13 = 0; num13 < 10; num13++)
            {
                output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
                output.Write(num13.ToString() + "</td>");
            }
            for (int num14 = 0; num14 < 10; num14++)
            {
                output.Write("<td bgcolor='#D0E6F7' onClick=Style(this,'#0000FF','#D0E6F7') style='color:#D0E6F7;'>");
                output.Write(num14.ToString() + "</td>");
            }
            for (int num15 = 0; num15 < 10; num15++)
            {
                output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
                output.Write(num15.ToString() + "</td>");
            }
            for (int num16 = 0; num16 < 4; num16++)
            {
            }
        }
        output.Write("<tr align = 'center' valign='middle'>");
        output.Write("<td colspan ='1'>出现次数</td>");
        for (int num17 = 0; num17 < 70; num17++)
        {
            output.Write("<td bgcolor='#FFFFFF' align='center' valign='bottom' height='50px'>");
            output.Write(this.num[num17].ToString() + "<br><img src='../image/01[1].gif' width='8' height='" + this.sum[num17].ToString() + "' title='" + this.num[num17].ToString() + "'></td>");
        }
        output.Write("<tr align = 'center' valign='middle'>");
        output.Write("<td align = 'center' valign='middle'>数字序号</td>");
        for (int num18 = 0; num18 < 3; num18++)
        {
            for (int num19 = 0; num19 < 10; num19++)
            {
                output.Write("<td bgcolor ='#F8EFEF'><font color ='#FF0000'>");
                output.Write(num19.ToString() + "</font></td>");
            }
            for (int num20 = 0; num20 < 10; num20++)
            {
                output.Write("<td bgcolor ='#CAD9E8'><font color ='#OO33CC'>");
                output.Write(num20.ToString() + "</font></td>");
            }
        }
        for (int num21 = 0; num21 < 10; num21++)
        {
            output.Write("<td bgcolor ='#F8EFEF'><font color ='#FF0000'>");
            output.Write(num21.ToString() + "</font></td>");
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3' align='center' valign='middle'>期数</td>");
        output.Write("<td rowspan='1' colspan ='70' align='center' valign='middle'><strong><font color ='#FF0000'>七星彩区号码</font></strong></td>");
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td colspan='10'>第一位</td>");
        output.Write("<td colspan='10'>第二位</td>");
        output.Write("<td colspan='10'>第三位</td>");
        output.Write("<td colspan='10'>第四位</td>");
        output.Write("<td colspan='10'>第五位</td>");
        output.Write("<td colspan='10'>第六位</td>");
        output.Write("<td colspan='10'>第七位</td>");
        output.Write("<tr align='center' valign='middle'>");
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 10; k++)
            {
                output.Write("<td><font color ='#FF0000'>");
                output.Write(k.ToString() + "</font></td>");
            }
            for (int m = 0; m < 10; m++)
            {
                output.Write("<td bgcolor='#D0E6F7'><font color ='#OO33CC'>");
                output.Write(m.ToString() + "</font></td>");
            }
        }
        for (int j = 0; j < 10; j++)
        {
            output.Write("<td><font color ='#FF0000'>");
            output.Write(j.ToString() + "</font></td>");
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
        table = BLL.X7_HMFB_SeleteByNum(30);
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
        DataTable table = BLL.X7_HMFB_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_HMFB_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_HMFB_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_HMFB_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_HMFB_SeleteByNum(10);
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

