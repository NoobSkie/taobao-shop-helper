using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class View_PL3_ZX : TrendChartPageBase, IRequiresSessionState
{
    public int[] aa = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int[] bb = new int[20];


    protected void ColorBind()
    {
        for (int i = 2; i <= 6; i++)
        {
            for (int m = 0; m < this.GridView1.Rows.Count; m++)
            {
                this.GridView1.Rows[m].Cells[i].BackColor = Color.FromArgb(0xc2, 0xdf, 0xc1);
                this.GridView1.Rows[m].Cells[i].ForeColor = Color.FromArgb(0x80, 0x80, 0x80);
                if (this.GridView1.Rows[m].Cells[i].Text == "0")
                {
                    this.GridView1.Rows[m].Cells[i].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[m].Cells[i].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[m].Cells[i].Text = this.aa[i + 3].ToString();
                }
            }
        }
        for (int j = 7; j <= 0x10; j++)
        {
            for (int n = 0; n < this.GridView1.Rows.Count; n++)
            {
                this.GridView1.Rows[n].Cells[j].BackColor = Color.FromArgb(0xe1, 0xef, 0xff);
                this.GridView1.Rows[n].Cells[j].ForeColor = Color.FromArgb(0x80, 0x80, 0x80);
                if (this.GridView1.Rows[n].Cells[j].Text == "0")
                {
                    this.GridView1.Rows[n].Cells[j].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[n].Cells[j].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[n].Cells[j].Text = this.aa[j - 7].ToString();
                }
            }
        }
        for (int k = 0x11; k <= 0x15; k++)
        {
            for (int num6 = 0; num6 < this.GridView1.Rows.Count; num6++)
            {
                this.GridView1.Rows[num6].Cells[k].BackColor = Color.FromArgb(0xc2, 0xdf, 0xc1);
                this.GridView1.Rows[num6].Cells[k].ForeColor = Color.FromArgb(0x80, 0x80, 0x80);
                if (this.GridView1.Rows[num6].Cells[k].Text == "0")
                {
                    this.GridView1.Rows[num6].Cells[k].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[num6].Cells[k].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[num6].Cells[k].Text = this.aa[k - 0x11].ToString();
                }
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='2' rowspan='5'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        for (int i = 5; i < 10; i++)
        {
            output.Write("<td bgcolor='#C2DFC1'onClick=Style(this,'#DD0000','#C2DFC1') style='color:#C2DFC1'>");
            output.Write(i.ToString() + "</td>");
        }
        for (int j = 0; j < 10; j++)
        {
            output.Write("<td bgcolor='#E1EFFF' onClick=Style(this,'#DD0000','#E1EFFF') style='color:#E1EFFF'>");
            output.Write(j.ToString() + "</td>");
        }
        for (int k = 0; k < 5; k++)
        {
            output.Write("<td bgcolor='#C2DFC1' onClick=Style(this,'#DD0000','#C2DFC1') style='color:#C2DFC1'>");
            output.Write(k.ToString() + "</td>");
        }
        for (int m = 0; m < 4; m++)
        {
            output.Write("<tr align='center' valign='middle'>");
            for (int num5 = 5; num5 < 10; num5++)
            {
                output.Write("<td bgcolor='#C2DFC1' onClick=Style(this,'#DD0000','#C2DFC1') style='color:#C2DFC1'>");
                output.Write(num5.ToString() + "</td>");
            }
            for (int num6 = 0; num6 < 10; num6++)
            {
                output.Write("<td bgcolor='#E1EFFF' onClick=Style(this,'#DD0000','#E1EFFF') style='color:#E1EFFF'>");
                output.Write(num6.ToString() + "</td>");
            }
            for (int num7 = 0; num7 < 5; num7++)
            {
                output.Write("<td bgcolor='#C2DFC1' onClick=Style(this,'#DD0000','#C2DFC1') style='color:#C2DFC1'>");
                output.Write(num7.ToString() + "</td>");
            }
        }
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td >出现次数</td>");
        output.Write("<td >&nbsp;</td>");
        for (int n = 2; n < this.GridView1.Columns.Count; n++)
        {
            int num9 = 0;
            for (int num10 = 0; num10 < this.GridView1.Rows.Count; num10++)
            {
                if (this.GridView1.Rows[num10].Cells[n].BackColor == Color.FromArgb(0xdd, 0, 0))
                {
                    num9++;
                }
            }
            this.bb[n - 2] = num9;
            output.Write("<td>");
            output.Write(this.bb[n - 2].ToString() + "</td>");
        }
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td >期 数</td>");
        output.Write("<td >开奖号码</td>");
        for (int num11 = 5; num11 < 10; num11++)
        {
            output.Write("<td> <strong><font color ='DD0000'>");
            output.Write(num11.ToString() + "</font></strong></td>");
        }
        for (int num12 = 0; num12 < 10; num12++)
        {
            output.Write("<td> <strong><font color ='DD0000'>");
            output.Write(num12.ToString() + "</font></strong></td>");
        }
        for (int num13 = 0; num13 < 5; num13++)
        {
            output.Write("<td><strong><font color ='DD0000'>");
            output.Write(num13.ToString() + "</font></strong></td>");
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'>期 数</td>");
        output.Write("<td rowspan='2'>开奖号码</td>");
        output.Write("<td colspan='20' align='center' valign='middle'>排列3组选分布</td>");
        output.Write("<tr align='center' valign='middle'>");
        for (int i = 5; i < 10; i++)
        {
            output.Write("<td bgcolor='#B0D6AF'><strong><font color='#DD0000'>");
            output.Write(i.ToString() + "</td>");
        }
        for (int j = 0; j < 10; j++)
        {
            output.Write("<td bgcolor='#B5D2FF'><strong><font color='#DD0000'>");
            output.Write(j.ToString() + "</td>");
        }
        for (int k = 0; k < 5; k++)
        {
            output.Write("<td bgcolor='#B0D6AF'><strong><font color='#DD0000'>");
            output.Write(k.ToString() + "</td>");
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
        table = BLL.PL3_ZX_SeleteByNum(30);
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
        DataTable table = BLL.PL3_ZX_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_ZX_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_ZX_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_ZX_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        BLL.PL3_ZX_SeleteByNum(10);
        this.GridView1.DataSource = BLL.PL3_ZX_SeleteByNum(10);
        this.GridView1.DataBind();
        this.ColorBind();
    }
}

