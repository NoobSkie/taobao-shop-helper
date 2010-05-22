using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class View_PL3_WH : TrendChartPageBase, IRequiresSessionState
{
    private int[] num = new int[0x39];
    private int[] sum = new int[0x39];

    protected void ColorBind()
    {
        for (int i = 3; i < 0x16; i++)
        {
            int num2 = 0;
            for (int m = 0; m < this.GridView1.Rows.Count; m++)
            {
                if (this.GridView1.Rows[m].Cells[i].Text == "0")
                {
                    this.GridView1.Rows[m].Cells[i].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[m].Cells[i].Text = (i - 3).ToString();
                    this.GridView1.Rows[m].Cells[i].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    num2++;
                }
            }
            this.num[i - 3] = num2;
            int num5 = this.RadioSelete();
            this.sum[i - 3] = (50 * num2) / num5;
        }
        for (int j = 0x16; j < 0x29; j++)
        {
            int num7 = 0;
            for (int n = 0; n < this.GridView1.Rows.Count; n++)
            {
                if (this.GridView1.Rows[n].Cells[j].Text == "0")
                {
                    this.GridView1.Rows[n].Cells[j].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[n].Cells[j].Text = (j - 0x16).ToString();
                    this.GridView1.Rows[n].Cells[j].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    num7++;
                }
            }
            this.num[j - 3] = num7;
            int num10 = this.RadioSelete();
            this.sum[j - 3] = (50 * num7) / num10;
        }
        for (int k = 0x29; k < 60; k++)
        {
            int num12 = 0;
            for (int num13 = 0; num13 < this.GridView1.Rows.Count; num13++)
            {
                if (this.GridView1.Rows[num13].Cells[k].Text == "0")
                {
                    this.GridView1.Rows[num13].Cells[k].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[num13].Cells[k].Text = (k - 0x29).ToString();
                    this.GridView1.Rows[num13].Cells[k].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    num12++;
                }
            }
            this.num[k - 3] = num12;
            int num15 = this.RadioSelete();
            this.sum[k - 3] = (50 * num12) / num15;
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan = '5' colspan='2'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        output.Write("<td>&nbsp</td>");
        for (int i = 0; i < 0x13; i++)
        {
            output.Write("<td bgcolor='#E3EAF9' onClick=Style(this,'#DD0000','#E3EAF9') style='color:#E3EAF9;'>");
            output.Write(i.ToString() + "</td>");
        }
        for (int j = 0; j < 0x13; j++)
        {
            output.Write("<td bgcolor='#DCEDD3' onClick=Style(this,'#0000FF','#DCEDD3') style='color:#DCEDD3;'>");
            output.Write(j.ToString() + "</td>");
        }
        for (int k = 0; k < 0x13; k++)
        {
            output.Write("<td bgcolor='#FFE1F0' onClick=Style(this,'#DD0000','#FFE1F0') style='color:#FFE1F0;'>");
            output.Write(k.ToString() + "</td>");
        }
        for (int m = 0; m < 4; m++)
        {
            output.Write("<tr align ='center' valign='middle'>");
            output.Write("<td bgcolor ='#FFFFFF'>&nbsp</td>");
            for (int num5 = 0; num5 < 0x13; num5++)
            {
                output.Write("<td bgcolor='#E3EAF9' onClick=Style(this,'#DD0000','#E3EAF9') style='color:#E3EAF9;'>");
                output.Write(num5.ToString() + "</td>");
            }
            for (int num6 = 0; num6 < 0x13; num6++)
            {
                output.Write("<td bgcolor='#DCEDD3' onClick=Style(this,'#0000FF','#DCEDD3') style='color:#DCEDD3;'>");
                output.Write(num6.ToString() + "</td>");
            }
            for (int num7 = 0; num7 < 0x13; num7++)
            {
                output.Write("<td bgcolor='#FFE1F0' onClick=Style(this,'#DD0000','#FFE1F0') style='color:#FFE1F0;'>");
                output.Write(num7.ToString() + "</td>");
            }
        }
        output.Write("<tr align = 'center' valign='middle'>");
        output.Write("<td height='50'>出现次数</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>&nbsp</td>");
        for (int n = 0; n < 0x39; n++)
        {
            output.Write("<td bgcolor='#FFFFFF' align='center' valign='bottom'>");
            output.Write(this.num[n].ToString() + "<br><img src='../image/01[1].gif' width='8' height='" + this.sum[n].ToString() + "' title='" + this.num[n].ToString() + "'></td>");
        }
        output.Write("<tr align = 'center' valign='middle'>");
        output.Write("<td height='20'>期　数</td>");
        output.Write("<td>奖号</td>");
        output.Write("<td>和值</td>");
        for (int num9 = 0; num9 < 3; num9++)
        {
            for (int num10 = 0; num10 < 0x13; num10++)
            {
                output.Write("<td bgcolor ='#E1EFFF'><strong><font color ='#DD0000' Font-Bold='false'>");
                output.Write(num10.ToString() + "</font></strong></td>");
            }
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'>期  数</td>");
        output.Write("<td rowspan='2'>开奖号码</td>");
        output.Write("<td rowspan='2'>和<br>值</td>");
        output.Write("<td rowspan='1' colspan ='19' align ='center' valign='middle'><strong><font Font-Bold='false'>百位　＋　十位</font></strong></td>");
        output.Write("<td rowspan='1' colspan ='19' align ='center' valign='middle'><strong><font Font-Bold='false'>十位　＋　个位</font></strong></td>");
        output.Write("<td rowspan='1' colspan ='19' align ='center' valign='middle'><strong><font Font-Bold='false'>百位　＋　个位</font></strong></td>");
        output.Write("<tr align ='center' valign='middle'>");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 0x13; j++)
            {
                output.Write("<td bgcolor ='#E1EFFF'><strong><font color ='#DD0000' Font-Bold='false'>");
                output.Write(j.ToString() + "</font></strong></td>");
            }
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
        table = BLL.PL3_WH_SeleteByNum(30);
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
        DataTable table = BLL.PL3_WH_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_WH_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_WH_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_WH_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        BLL.PL3_WH_SeleteByNum(10);
        this.GridView1.DataSource = BLL.PL3_WH_SeleteByNum(10);
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

