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

public partial class CJDLT_CJDLT_jima : Page, IRequiresSessionState
{
    private int[] num = new int[0x23];
    private int[] sum = new int[0x23];
    private int[] tem = new int[9];

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
            for (int n = 0; n < this.GridView1.Rows.Count; n++)
            {
                if (this.GridView1.Rows[n].Cells[i].Text != "0")
                {
                    this.GridView1.Rows[n].Cells[i].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[n].Cells[i].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[n].Cells[i].Text = ("0" + ((i - 1)).ToString()).ToString();
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
            for (int num10 = 0; num10 < this.GridView1.Rows.Count; num10++)
            {
                if (this.GridView1.Rows[num10].Cells[j].Text != "0")
                {
                    this.GridView1.Rows[num10].Cells[j].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[num10].Cells[j].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[num10].Cells[j].Text = (j - 1).ToString();
                    num9++;
                }
            }
            this.num[j - 2] = num9;
            int num12 = this.RadioSelete();
            this.sum[j - 2] = (50 * num9) / num12;
        }
        for (int k = 0; k < this.GridView1.Rows.Count; k++)
        {
            for (int num14 = 2; num14 < 0x25; num14++)
            {
                if (this.GridView1.Rows[k].Cells[num14].Text == "0")
                {
                    this.GridView1.Rows[k].Cells[num14].Text = "&nbsp";
                }
            }
            for (int num15 = 0x27; num15 < 0x2e; num15++)
            {
                if (this.GridView1.Rows[k].Cells[num15].Text == "0")
                {
                    this.GridView1.Rows[k].Cells[num15].Text = "&nbsp";
                }
            }
        }
        for (int m = 0; m < this.GridView1.Rows.Count; m++)
        {
            this.tem[0] += _Convert.StrToInt(this.GridView1.Rows[m].Cells[0x25].Text, 0);
            this.tem[1] += _Convert.StrToInt(this.GridView1.Rows[m].Cells[0x26].Text, 0);
            this.tem[2] += _Convert.StrToInt(this.GridView1.Rows[m].Cells[0x27].Text, 0);
            this.tem[3] += _Convert.StrToInt(this.GridView1.Rows[m].Cells[40].Text, 0);
            this.tem[4] += _Convert.StrToInt(this.GridView1.Rows[m].Cells[0x29].Text, 0);
            this.tem[5] += _Convert.StrToInt(this.GridView1.Rows[m].Cells[0x2a].Text, 0);
            this.tem[6] += _Convert.StrToInt(this.GridView1.Rows[m].Cells[0x2b].Text, 0);
            this.tem[7] += _Convert.StrToInt(this.GridView1.Rows[m].Cells[0x2c].Text, 0);
            this.tem[8] += _Convert.StrToInt(this.GridView1.Rows[m].Cells[0x2d].Text, 0);
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td align='center' valign='middle'>序号</td>");
        output.Write("<td height='50px' align='center' valign='middle'>出现次数</td>");
        for (int i = 0; i < 0x23; i++)
        {
            output.Write("<td align='center' valign='bottom'>");
            output.Write(this.num[i].ToString() + "<br><img src='../../Images/01[1].gif' height='" + this.sum[i].ToString() + "'' title='" + this.num[i].ToString() + "' width='8px'></td>");
        }
        for (int j = 0; j < 9; j++)
        {
            output.Write("<td align='center' valign='bottom'>");
            output.Write(this.tem[j].ToString() + "</td>");
        }
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td>序号</td>");
        output.Write("<td>期 数</td>");
        for (int k = 1; k < 10; k++)
        {
            output.Write("<td><font color='#FF0000'>");
            output.Write(0 + k.ToString() + "</font></td>");
        }
        for (int m = 10; m < 0x24; m++)
        {
            output.Write("<td ><font color='#FF0000'>");
            output.Write(m.ToString() + "</font></td>");
        }
        output.Write("<td>奇</td>");
        output.Write("<td >偶</td>");
        output.Write("<td >一区</td>");
        output.Write("<td >二区</td>");
        output.Write("<td >三区</td>");
        output.Write("<td >四区</td>");
        output.Write("<td >五区</td>");
        output.Write("<td >六区</td>");
        output.Write("<td >七区</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3'　align='center' valign='middle'>序号</td>");
        output.Write("<td rowspan='3' align='center' valign='middle'>期数</td>");
        output.Write("<td colspan='44' align='center' valign='middle'><strong><font color='#FF0000'>前区号码</font></strong></td>");
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td colspan='5'>一区</td>");
        output.Write("<td colspan='5'>二区</td>");
        output.Write("<td colspan='5'>三区</td>");
        output.Write("<td colspan='5'>四区</td>");
        output.Write("<td colspan='5'>五区</td>");
        output.Write("<td colspan='5'>六区</td>");
        output.Write("<td colspan='5'>七区</td>");
        output.Write("<td colspan='2'>奇偶</td>");
        output.Write("<td colspan='7'>区域分布</td>");
        output.Write("<tr align='center' valign='middle'>");
        for (int i = 1; i < 10; i++)
        {
            output.Write("<td><font color='#FF0000'>");
            output.Write(0 + i.ToString() + "</font></td>");
        }
        for (int j = 10; j < 0x24; j++)
        {
            output.Write("<td ><font color='#FF0000'>");
            output.Write(j.ToString() + "</font></td>");
        }
        output.Write("<td>奇</td>");
        output.Write("<td >偶</td>");
        output.Write("<td >一区</td>");
        output.Write("<td >二区</td>");
        output.Write("<td >三区</td>");
        output.Write("<td >四区</td>");
        output.Write("<td >五区</td>");
        output.Write("<td >六区</td>");
        output.Write("<td >七区</td>");
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
        table = BLL.CJDLT_jima_SeleteByNum(30);
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
        DataTable table = BLL.CJDLT_jima_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_jima_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_jima_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_jima_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_jima_SeleteByNum(10);
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

