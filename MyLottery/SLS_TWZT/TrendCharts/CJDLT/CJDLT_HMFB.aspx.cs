using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class CJDLT_CJDLT_HMFB : Page, IRequiresSessionState
{
    private int[] num = new int[0x2f];
    private int[] sum = new int[0x2f];

    protected void ColorBind()
    {
        int count = this.GridView1.Rows.Count;
        for (count = this.GridView1.Rows.Count; count > 0; count--)
        {
            int num2 = this.GridView1.Rows.Count - count;
            this.GridView1.Rows[num2].Cells[0].Text = count.ToString();
        }
        for (int i = 2; i < 11; i++)
        {
            int num4 = 0;
            for (int m = 0; m < this.GridView1.Rows.Count; m++)
            {
                if (this.GridView1.Rows[m].Cells[i].Text == "0")
                {
                    this.GridView1.Rows[m].Cells[i].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[m].Cells[i].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[m].Cells[i].Text = ("0" + ((i - 1)).ToString()).ToString();
                    num4++;
                }
            }
            this.num[i - 2] = num4;
            int num7 = this.RadioSelete();
            this.sum[i - 2] = (50 * num4) / num7;
        }
        for (int j = 11; j < 0x25; j++)
        {
            int num9 = 0;
            for (int n = 0; n < this.GridView1.Rows.Count; n++)
            {
                if (this.GridView1.Rows[n].Cells[j].Text == "0")
                {
                    this.GridView1.Rows[n].Cells[j].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[n].Cells[j].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[n].Cells[j].Text = (j - 1).ToString();
                    num9++;
                }
            }
            this.num[j - 2] = num9;
            int num12 = this.RadioSelete();
            this.sum[j - 2] = (50 * num9) / num12;
        }
        for (int k = 0x29; k < 0x35; k++)
        {
            int num14 = 0;
            for (int num15 = 0; num15 < this.GridView1.Rows.Count; num15++)
            {
                if (this.GridView1.Rows[num15].Cells[k].Text == "0")
                {
                    this.GridView1.Rows[num15].Cells[k].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[num15].Cells[k].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    if (k < 50)
                    {
                        string str2 = "0" + ((k - 40)).ToString();
                        this.GridView1.Rows[num15].Cells[k].Text = str2.ToString();
                    }
                    if (k > 0x31)
                    {
                        this.GridView1.Rows[num15].Cells[k].Text = (k - 40).ToString();
                    }
                    num14++;
                }
            }
            this.num[k - 6] = num14;
            int num18 = this.RadioSelete();
            this.sum[k - 6] = (50 * num14) / num18;
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='2' rowspan='5'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        for (int i = 1; i < 6; i++)
        {
            output.Write("<td bgcolor='#FFF4D2' onClick=Style(this,'#DD0000','#FFF4D2') style='color:#FFF4D2;'>");
            output.Write(0 + i.ToString() + "</td>");
        }
        for (int j = 6; j < 10; j++)
        {
            output.Write("<td bgcolor='#DDF9FE' onClick=Style(this,'#DD0000','#DDF9FE') style='color:#DDF9FE;'>");
            output.Write(0 + j.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#DDF9FE' onClick=Style(this,'#DD0000','#DDF9FE') style='color:#DDF9FE;'>10</td>");
        for (int k = 11; k < 0x10; k++)
        {
            output.Write("<td bgcolor='#FEEBE9' onClick=Style(this,'#DD0000','#FEEBE9') style='color:#FEEBE9;'>");
            output.Write(k.ToString() + "</td>");
        }
        for (int m = 0x10; m < 0x15; m++)
        {
            output.Write("<td bgcolor='#FFF4D2' onClick=Style(this,'#DD0000','#FFF4D2') style='color:#FFF4D2;'>");
            output.Write(m.ToString() + "</td>");
        }
        for (int n = 0x15; n < 0x1a; n++)
        {
            output.Write("<td bgcolor='#DDF9FE' onClick=Style(this,'#DD0000','#DDF9FE') style='color:#DDF9FE;'>");
            output.Write(n.ToString() + "</td>");
        }
        for (int num6 = 0x1a; num6 < 0x1f; num6++)
        {
            output.Write("<td bgcolor='#FEEBE9' onClick=Style(this,'#DD0000','#FEEBE9') style='color:#FEEBE9;'>");
            output.Write(num6.ToString() + "</td>");
        }
        for (int num7 = 0x1f; num7 < 0x24; num7++)
        {
            output.Write("<td bgcolor='#FFF4D2' onClick=Style(this,'#DD0000','#FFF4D2') style='color:#FFF4D2;'>");
            output.Write(num7.ToString() + "</td>");
        }
        for (int num8 = 0; num8 < 4; num8++)
        {
            output.Write("<td>&nbsp;</td>");
        }
        for (int num9 = 1; num9 < 7; num9++)
        {
            output.Write("<td bgcolor='#E1E6FF' onClick=Style(this,'#0000FF','#E1E6FF') style='color:#E1E6FF;'>");
            output.Write(0 + num9.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#BCD5FE' onClick=Style(this,'#0000FF','#BCD5FE') style='color:#BCD5FE;'>07</TD>");
        output.Write("<td bgcolor='#BCD5FE' onClick=Style(this,'#0000FF','#BCD5FE') style='color:#BCD5FE;'>08</TD>");
        output.Write("<td bgcolor='#BCD5FE' onClick=Style(this,'#0000FF','#BCD5FE') style='color:#BCD5FE;'>09</TD>");
        output.Write("<td bgcolor='#BCD5FE' onClick=Style(this,'#0000FF','#BCD5FE') style='color:#BCD5FE;'>10</TD>");
        output.Write("<td bgcolor='#BCD5FE' onClick=Style(this,'#0000FF','#BCD5FE') style='color:#BCD5FE;'>11</TD>");
        output.Write("<td bgcolor='#BCD5FE' onClick=Style(this,'#0000FF','#BCD5FE') style='color:#BCD5FE;'>12</TD>");
        for (int num10 = 0; num10 < 4; num10++)
        {
            output.Write("<tr align='center' valign='middle'>");
            for (int num11 = 1; num11 < 6; num11++)
            {
                output.Write("<td bgcolor='#FFF4D2' onClick=Style(this,'#DD0000','#FFF4D2') style='color:#FFF4D2;'>");
                output.Write(0 + num11.ToString() + "</td>");
            }
            for (int num12 = 6; num12 < 10; num12++)
            {
                output.Write("<td bgcolor='#DDF9FE' onClick=Style(this,'#DD0000','#DDF9FE') style='color:#DDF9FE;'>");
                output.Write(0 + num12.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#DDF9FE' onClick=Style(this,'#DD0000','#DDF9FE') style='color:#DDF9FE;'>10</td>");
            for (int num13 = 11; num13 < 0x10; num13++)
            {
                output.Write("<td bgcolor='#FEEBE9' onClick=Style(this,'#DD0000','#FEEBE9') style='color:#FEEBE9;'>");
                output.Write(num13.ToString() + "</td>");
            }
            for (int num14 = 0x10; num14 < 0x15; num14++)
            {
                output.Write("<td bgcolor='#FFF4D2' onClick=Style(this,'#DD0000','#FFF4D2') style='color:#FFF4D2;'>");
                output.Write(num14.ToString() + "</td>");
            }
            for (int num15 = 0x15; num15 < 0x1a; num15++)
            {
                output.Write("<td bgcolor='#DDF9FE' onClick=Style(this,'#DD0000','#DDF9FE') style='color:#DDF9FE;'>");
                output.Write(num15.ToString() + "</td>");
            }
            for (int num16 = 0x1a; num16 < 0x1f; num16++)
            {
                output.Write("<td bgcolor='#FEEBE9' onClick=Style(this,'#DD0000','#FEEBE9') style='color:#FEEBE9;'>");
                output.Write(num16.ToString() + "</td>");
            }
            for (int num17 = 0x1f; num17 < 0x24; num17++)
            {
                output.Write("<td bgcolor='#FFF4D2' onClick=Style(this,'#DD0000','#FFF4D2') style='color:#FFF4D2;'>");
                output.Write(num17.ToString() + "</td>");
            }
            for (int num18 = 0; num18 < 4; num18++)
            {
                output.Write("<td>&nbsp;</td>");
            }
            for (int num19 = 1; num19 < 7; num19++)
            {
                output.Write("<td bgcolor='#E1E6FF' onClick=Style(this,'#0000FF','#E1E6FF') style='color:#E1E6FF;'>");
                output.Write(0 + num19.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#BCD5FE' onClick=Style(this,'#0000FF','#BCD5FE') style='color:#BCD5FE;'>07</TD>");
            output.Write("<td bgcolor='#BCD5FE' onClick=Style(this,'#0000FF','#BCD5FE') style='color:#BCD5FE;'>08</TD>");
            output.Write("<td bgcolor='#BCD5FE' onClick=Style(this,'#0000FF','#BCD5FE') style='color:#BCD5FE;'>09</TD>");
            output.Write("<td bgcolor='#BCD5FE' onClick=Style(this,'#0000FF','#BCD5FE') style='color:#BCD5FE;'>10</TD>");
            output.Write("<td bgcolor='#BCD5FE' onClick=Style(this,'#0000FF','#BCD5FE') style='color:#BCD5FE;'>11</TD>");
            output.Write("<td bgcolor='#BCD5FE' onClick=Style(this,'#0000FF','#BCD5FE') style='color:#BCD5FE;'>12</TD>");
        }
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td align='center' valign='middle'>序号</td>");
        output.Write("<td height='50px' align='center' valign='middle'>出现次数</td>");
        for (int num20 = 0; num20 < 0x23; num20++)
        {
            output.Write("<td align='center' valign='bottom'>");
            output.Write(this.num[num20].ToString() + "<br><img src='../../Images/01[1].gif' height='" + this.sum[num20].ToString() + "'' title='" + this.num[num20].ToString() + "' width='8px'></td>");
        }
        for (int num21 = 0; num21 < 4; num21++)
        {
            output.Write("<td>&nbsp;</td>");
        }
        for (int num22 = 0x23; num22 < 0x2f; num22++)
        {
            output.Write("<td align='center' valign='bottom'>");
            output.Write(this.num[num22].ToString() + "<br><img src='../../Images/01[1].gif' height='" + this.sum[num22].ToString() + "'' title='" + this.num[num22].ToString() + "' width='8px'></td>");
        }
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td>序号</td>");
        output.Write("<td>出现次数</td>");
        for (int num23 = 1; num23 < 10; num23++)
        {
            output.Write("<td><font color='#FF0000'>");
            output.Write(0 + num23.ToString() + "</font></td>");
        }
        for (int num24 = 10; num24 < 0x24; num24++)
        {
            output.Write("<td ><font color='#FF0000'>");
            output.Write(num24.ToString() + "</font></td>");
        }
        for (int num25 = 0; num25 < 4; num25++)
        {
            output.Write("<td>&nbsp;</td>");
        }
        for (int num26 = 1; num26 < 10; num26++)
        {
            output.Write("<td><font color='#0000FF'>");
            output.Write(0 + num26.ToString() + "</font></td>");
        }
        for (int num27 = 10; num27 < 13; num27++)
        {
            output.Write("<td><font color='#0000FF'>");
            output.Write(num27.ToString() + "</font></td>");
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3'　align='center' valign='middle'>序号</td>");
        output.Write("<td rowspan='3' align='center' valign='middle'>期数</td>");
        output.Write("<td colspan='35' align='center' valign='middle'><strong><font color='#FF0000'>前区号码</font></strong></td>");
        output.Write("<td rowspan='2' colspan='4'　align='center' valign='middle'><strong><font color='#FF0000'>指标区</font></strong></td>");
        output.Write("<td colspan='12' align='center' valign='middle'><strong><font color='#0000FF'>后区号码</font></strong></td>");
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td colspan='5'>一区</td>");
        output.Write("<td colspan='5'>二区</td>");
        output.Write("<td colspan='5'>三区</td>");
        output.Write("<td colspan='5'>四区</td>");
        output.Write("<td colspan='5'>五区</td>");
        output.Write("<td colspan='5'>六区</td>");
        output.Write("<td colspan='5'>七区</td>");
        output.Write("<td colspan='3'>一区</td>");
        output.Write("<td colspan='3'>二区</td>");
        output.Write("<td colspan='3'>三区</td>");
        output.Write("<td colspan='3'>四区</td>");
        output.Write("<tr align='center' valign='middle'>");
        for (int i = 1; i < 6; i++)
        {
            output.Write("<td bgcolor='#FFF4D2'><font color='#FF0000'>");
            output.Write(0 + i.ToString() + "</font></td>");
        }
        for (int j = 6; j < 10; j++)
        {
            output.Write("<td bgcolor='#DDF9FE'><font color='#FF0000'>");
            output.Write(0 + j.ToString() + "</font></td>");
        }
        output.Write("<td bgcolor='#DDF9FE'><font color='#FF0000'>10</font></td>");
        for (int k = 11; k < 0x10; k++)
        {
            output.Write("<td bgcolor='#FEEBE9'><font color='#FF0000'>");
            output.Write(k.ToString() + "</font></td>");
        }
        for (int m = 0x10; m < 0x15; m++)
        {
            output.Write("<td bgcolor='#FFF4D2'><font color='#FF0000'>");
            output.Write(m.ToString() + "</font></td>");
        }
        for (int n = 0x15; n < 0x1a; n++)
        {
            output.Write("<td bgcolor='#DDF9FE'><font color='#FF0000'>");
            output.Write(n.ToString() + "</font></td>");
        }
        for (int num6 = 0x1a; num6 < 0x1f; num6++)
        {
            output.Write("<td bgcolor='#FEEBE9'><font color='#FF0000'>");
            output.Write(num6.ToString() + "</font></td>");
        }
        for (int num7 = 0x1f; num7 < 0x24; num7++)
        {
            output.Write("<td bgcolor='#FFF4D2'><font color='#FF0000'>");
            output.Write(num7.ToString() + "</font></td>");
        }
        output.Write("<td>和值</td>");
        output.Write("<td >大小</td>");
        output.Write("<td >奇偶</td>");
        output.Write("<td >尾和</td>");
        for (int num8 = 1; num8 < 7; num8++)
        {
            output.Write("<td bgcolor='#E1E6FF'><font color='#0000FF'>");
            output.Write(0 + num8.ToString() + "</font></td>");
        }
        output.Write("<td bgcolor='#BCD5FE'><font color='#0000FF'>07</font></td>");
        output.Write("<td bgcolor='#BCD5FE'><font color='#0000FF'>08</font></td>");
        output.Write("<td bgcolor='#BCD5FE'><font color='#0000FF'>09</font></td>");
        output.Write("<td bgcolor='#BCD5FE'><font color='#0000FF'>10</font></td>");
        output.Write("<td bgcolor='#BCD5FE'><font color='#0000FF'>11</font></td>");
        output.Write("<td bgcolor='#BCD5FE'><font color='#0000FF'>12</font></td>");
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
        table = BLL.CJDLT_HMFB_SeleteByNum(30);
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
        DataTable table = BLL.CJDLT_HMFB_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_HMFB_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_HMFB_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_HMFB_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_HMFB_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    private int RadioSelete()
    {
        int num = 1;
        if (this.RadioButton1.Checked)
        {
            num = 100;
        }
        if (this.RadioButton2.Checked)
        {
            num = 50;
        }
        if (this.RadioButton3.Checked)
        {
            num = 30;
        }
        if (this.RadioButton4.Checked)
        {
            num = 20;
        }
        if (this.RadioButton5.Checked)
        {
            num = 10;
        }
        return num;
    }
}

