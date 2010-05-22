using ASP;
using Shove;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class View_PL3_YS : TrendChartPageBase, IRequiresSessionState
{
    private int[] sum = new int[15];

    private void ColorBind()
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            for (int n = 2; n < 9; n++)
            {
                this.GridView1.Rows[i].Cells[n].BackColor = Color.FromArgb(0xed, 0xff, 0xd7);
            }
        }
        for (int j = 0; j < this.GridView1.Rows.Count; j++)
        {
            for (int num4 = 9; num4 < 14; num4++)
            {
                this.GridView1.Rows[j].Cells[num4].BackColor = Color.FromArgb(0xff, 0xff, 0xff);
            }
        }
        for (int k = 0; k < this.GridView1.Rows.Count; k++)
        {
            for (int num6 = 14; num6 < 0x11; num6++)
            {
                this.GridView1.Rows[k].Cells[num6].BackColor = Color.FromArgb(210, 0xe1, 240);
            }
        }
        for (int m = 2; m < this.GridView1.Columns.Count; m++)
        {
            for (int num8 = 0; num8 < this.GridView1.Rows.Count; num8++)
            {
                this.GridView1.Rows[num8].Cells[1].ForeColor = Color.Blue;
                if (this.GridView1.Rows[num8].Cells[m].Text == "0")
                {
                    this.GridView1.Rows[num8].Cells[m].Text = "&nbsp";
                }
                if (this.GridView1.Rows[num8].Cells[m].Text == "1")
                {
                    this.GridView1.Rows[num8].Cells[m].ForeColor = Color.FromArgb(0xff, 0, 0);
                }
                if (this.GridView1.Rows[num8].Cells[m].Text == "2")
                {
                    this.GridView1.Rows[num8].Cells[m].ForeColor = Color.FromArgb(0, 0, 0xff);
                }
                if (this.GridView1.Rows[num8].Cells[m].Text == "3")
                {
                    this.GridView1.Rows[num8].Cells[m].ForeColor = Color.FromArgb(0x80, 0x80, 0x40);
                }
            }
        }
    }

    private void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td >");
        output.Write("出现次数</td>");
        output.Write("<td>");
        output.Write("&nbsp</td>");
        for (int i = 2; i < 9; i++)
        {
            int num2 = 0;
            for (int m = 0; m < this.GridView1.Rows.Count; m++)
            {
                num2 += _Convert.StrToInt(this.GridView1.Rows[m].Cells[i].Text.ToString(), 0);
            }
            this.sum[i - 2] = num2;
            output.Write("<td align='center' style='background-color: #F3F3F3'>");
            output.Write(this.sum[i - 2].ToString() + "</td>");
        }
        for (int j = 9; j < 14; j++)
        {
            int num5 = 0;
            for (int n = 0; n < this.GridView1.Rows.Count; n++)
            {
                num5 += _Convert.StrToInt(this.GridView1.Rows[n].Cells[j].Text.ToString(), 0);
            }
            this.sum[j - 2] = num5;
            output.Write("<td align='center' style='background-color:#F3F3F3'>");
            output.Write(this.sum[j - 2].ToString() + "</td>");
        }
        for (int k = 14; k < 0x11; k++)
        {
            int num8 = 0;
            for (int num9 = 0; num9 < this.GridView1.Rows.Count; num9++)
            {
                num8 += _Convert.StrToInt(this.GridView1.Rows[num9].Cells[k].Text.ToString(), 0);
            }
            this.sum[k - 2] = num8;
            output.Write("<td align='center'style='background-color:#F3F3F3'>");
            output.Write(this.sum[k - 2].ToString() + "</td>");
        }
    }

    private void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td width='60' rowspan='2'>期  数</td>");
        output.Write("<td width='60' rowspan='2'>");
        output.Write("开奖号码</td>");
        output.Write("<td colspan='7'>");
        output.Write("除以<strong><font color='#FF0000'>7</font></strong></td>");
        output.Write("<td colspan='5'>");
        output.Write("除以<strong><font color='#FF0000'>5</font></strong></td>");
        output.Write("<td colspan='3'>");
        output.Write("除以<strong><font color='#FF0000'>3</font></strong></td></tr>");
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td width='16' align='center' valign='middle' bgColor=#D9F9A4>");
        output.Write("0</td>");
        output.Write("<td align='center' valign='middle' bgColor=#D9F9A4>");
        output.Write("1</td>");
        output.Write("<td align='center' valign='middle' bgColor=#D9F9A4>");
        output.Write("2</td>");
        output.Write("<td align='center' valign='middle' bgColor=#D9F9A4>");
        output.Write("3</td>");
        output.Write("<td align='center' valign='middle' bgColor=#D9F9A4>");
        output.Write("4</td>");
        output.Write("<td align='center' valign='middle' bgColor=#D9F9A4>");
        output.Write("5</td>");
        output.Write("<td align='center' valign='middle' bgColor=#D9F9A4> ");
        output.Write("6</td>");
        output.Write("<td align='center' valign='middle' bgColor=#F6F6F6>");
        output.Write("0</td>");
        output.Write("<td align='center' valign='middle' bgColor=#F6F6F6>");
        output.Write("1</td>");
        output.Write("<td align='center' valign='middle' bgColor=#F6F6F6>");
        output.Write("2</td>");
        output.Write("<td align='center' valign='middle' bgColor=#F6F6F6 >");
        output.Write("3</td>");
        output.Write("<td align='center' valign='middle' bgColor=#F6F6F6>");
        output.Write("4</td>");
        output.Write("<td align='center' valign='middle' bgColor=#BBD1E8>");
        output.Write("0</td>");
        output.Write("<td align='center' valign='middle' bgColor=#BBD1E8>");
        output.Write("1</td>");
        output.Write("<td align='center' valign='middle' bgColor=#BBD1E8>");
        output.Write("2</td></tr>");
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

    private void GridViewBind()
    {
        this.GridView1.DataSource = BLL.PL3_YS_SeleteByNum(30);
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
        DataTable table = BLL.PL3_YS_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_YS_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_YS_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_YS_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_YS_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }
}

