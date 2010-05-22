using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class PL5_PL5_HZ : TrendChartPageBase, IRequiresSessionState
{
    private int[] num = new int[0x26];
    private int[] sum = new int[0x26];

    protected void ColorBind()
    {
        for (int i = 3; i < 0x1f; i++)
        {
            int num2 = 0;
            for (int k = 0; k < this.GridView1.Rows.Count; k++)
            {
                if (this.GridView1.Rows[k].Cells[i].Text == "0")
                {
                    this.GridView1.Rows[k].Cells[i].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[k].Cells[i].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[k].Cells[i].Text = (i + 7).ToString();
                    num2++;
                }
            }
            this.num[i - 3] = num2;
            int num5 = this.RadioSelete();
            this.sum[i - 3] = (50 * num2) / num5;
        }
        for (int j = 0x1f; j < 0x29; j++)
        {
            int num7 = 0;
            for (int m = 0; m < this.GridView1.Rows.Count; m++)
            {
                if (this.GridView1.Rows[m].Cells[j].Text == "0")
                {
                    this.GridView1.Rows[m].Cells[j].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[m].Cells[j].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[m].Cells[j].Text = (j - 0x1f).ToString();
                    num7++;
                }
            }
            this.num[j - 3] = num7;
            int num10 = this.RadioSelete();
            this.sum[j - 3] = (50 * num7) / num10;
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='2' rowspan='5'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        output.Write("<td>&nbsp</td>");
        for (int i = 10; i < 0x26; i++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
            output.Write(i.ToString() + "</td>");
        }
        for (int j = 0; j < 10; j++)
        {
            output.Write("<td bgcolor='#E3F4E3' onClick=Style(this,'#0000FF','#E3F4E3') style='color:#E3F4E3;'>");
            output.Write(j.ToString() + "</td>");
        }
        for (int k = 0; k < 4; k++)
        {
            output.Write("<tr align='center' valign='middle'>");
            output.Write("<td>&nbsp</td>");
            for (int num4 = 10; num4 < 0x26; num4++)
            {
                output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#DD0000','#FFFFFF') style='color:#FFFFFF;'>");
                output.Write(num4.ToString() + "</td>");
            }
            for (int num5 = 0; num5 < 10; num5++)
            {
                output.Write("<td bgcolor='#E3F4E3' onClick=Style(this,'#0000FF','#E3F4E3') style='color:#E3F4E3;'>");
                output.Write(num5.ToString() + "</td>");
            }
        }
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td height='50px' align='center' valign='middle'>出现次数</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>&nbsp</td>");
        for (int m = 0; m < 0x26; m++)
        {
            output.Write("<td align='center' valign='bottom'>");
            output.Write(this.num[m].ToString() + "<br><img src='../Image/01[1].gif' height='" + this.sum[m].ToString() + "'' title='" + this.num[m].ToString() + "' width='8px'></td>");
        }
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td>期 数</td>");
        output.Write("<td>开奖号码</td>");
        output.Write("<td>和值</td>");
        for (int n = 10; n < 0x26; n++)
        {
            output.Write("<td bgcolor='#E1EFFF'><font color='#DD0000'>");
            output.Write(n.ToString() + "</font></td>");
        }
        for (int num8 = 0; num8 < 10; num8++)
        {
            output.Write("<td bgcolor='#C9E9CA'><font color='#DD0000'>");
            output.Write(num8.ToString() + "</font></td>");
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan ='2' align='center' valign='middle'>期 数</td>");
        output.Write("<td rowspan ='2' align='center' valign='middle'>开奖号码</td>");
        output.Write("<td rowspan ='2' align='center' valign='middle'>和值</td>");
        output.Write("<td colspan ='28' align='center' valign='middle'>排列5和值</td>");
        output.Write("<td colspan ='10' align='center' valign='middle'>合值区</td>");
        output.Write("<tr align='center' valign='middle'>");
        for (int i = 10; i < 0x26; i++)
        {
            output.Write("<td bgcolor='#E1EFFF'><font color='#DD0000'>");
            output.Write(i.ToString() + "</font></td>");
        }
        for (int j = 0; j < 10; j++)
        {
            output.Write("<td bgcolor='#C9E9CA'><font color='#DD0000'>");
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
        table = BLL.PL5_HZ_SeleteByNum(30);
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
        DataTable table = BLL.PL5_HZ_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_HZ_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_HZ_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_HZ_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_HZ_SeleteByNum(10);
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

