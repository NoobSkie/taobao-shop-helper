using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _7Xing_7X_HZheng : TrendChartPageBase, IRequiresSessionState
{
    private int[] num = new int[0x2a];
    private int[] sum = new int[0x2a];

    private void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        this.RadioSelete();
        output.Write("<td width = '60px' height='50px'>");
        output.Write("出现次数</td>");
        output.Write("<td>&nbsp;</TD>");
        output.Write("<td width = '30px'>&nbsp;</TD>");
        for (int i = 3; i < 0x2d; i++)
        {
            output.Write("<td align='center' valign='bottom'>");
            output.Write(this.num[i - 3].ToString() + "<br><img src='../image/01[1].gif' height='" + this.sum[i - 3].ToString() + "px' title = '" + this.num[i - 3].ToString() + "' width= '8px'></td>");
        }
        output.Write("<tr align='center' valign='middle' height='13px'>");
        output.Write("<td height='13px'>期 数</td>");
        output.Write("<td height='13px'>开奖号码</td>");
        output.Write("<td height='13px'>和值</td>");
        for (int j = 10; j < 0x34; j++)
        {
            output.Write("<td bgcolor='#E1EFFF' width='14px'><font color='#FF0000'>");
            output.Write(j.ToString() + "</font></td>");
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'>期 数</td>");
        output.Write("<td rowspan='2'>开奖号码</td>");
        output.Write("<td rowspan='2'>和值</td>");
        output.Write("<td align='center' valign='middle' colspan='42' rowspan='1'>七星彩和值区</td>");
        output.Write("<tr align='center' valign='middle' height='13px'>");
        for (int i = 10; i < 0x34; i++)
        {
            output.Write("<td bgcolor='#E1EFFF' height='13px'><font color='#FF0000'>");
            output.Write(i.ToString() + "</font></td>");
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

    private void GridViewbind()
    {
        this.GridView1.DataSource = BLL.X7_HZHeng_SeleteByNum(30);
        this.GridView1.DataBind();
    }

    private void GridViewbindColor()
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            for (int k = 3; k < this.GridView1.Columns.Count; k++)
            {
                if (this.GridView1.Rows[i].Cells[k].Text == "")
                {
                    this.GridView1.Rows[i].Cells[k].Text = "&nbsp;";
                }
                if (this.GridView1.Rows[i].Cells[k].Text != "&nbsp;")
                {
                    this.GridView1.Rows[i].Cells[k].ForeColor = Color.White;
                    this.GridView1.Rows[i].Cells[k].BackColor = Color.FromArgb(0xff, 0, 0);
                }
            }
        }
        for (int j = 3; j < 0x2d; j++)
        {
            int num4 = 0;
            for (int m = 0; m < this.GridView1.Rows.Count; m++)
            {
                if (this.GridView1.Rows[m].Cells[j].Text != "&nbsp;")
                {
                    num4++;
                }
            }
            this.num[j - 3] = num4;
            int num6 = this.RadioSelete();
            this.sum[j - 3] = (num4 * 50) / num6;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.GridViewbind();
            this.GridViewbindColor();
            this.GridView1.Style["border-collapse"] = "";
        }
    }

    protected void RadioButton1_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_HZHeng_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_HZHeng_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_HZHeng_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_HZHeng_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_HZHeng_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
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

