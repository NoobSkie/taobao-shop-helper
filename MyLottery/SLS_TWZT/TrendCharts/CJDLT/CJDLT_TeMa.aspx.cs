using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class CJDLT_CJDLT_TeMa : Page, IRequiresSessionState
{
    private int[] num = new int[0x12];

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
                if (this.GridView1.Rows[m].Cells[i].Text != "0")
                {
                    this.GridView1.Rows[m].Cells[i].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[m].Cells[i].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[m].Cells[i].Text = ("0" + ((i - 1)).ToString()).ToString();
                    num4++;
                }
                else
                {
                    this.GridView1.Rows[m].Cells[i].Text = "&nbsp;";
                }
            }
            this.num[i - 2] = num4;
        }
        for (int j = 11; j < 14; j++)
        {
            int num8 = 0;
            for (int n = 0; n < this.GridView1.Rows.Count; n++)
            {
                if (this.GridView1.Rows[n].Cells[j].Text != "0")
                {
                    this.GridView1.Rows[n].Cells[j].BackColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[n].Cells[j].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[n].Cells[j].Text = (j - 1).ToString();
                    num8++;
                }
                else
                {
                    this.GridView1.Rows[n].Cells[j].Text = "&nbsp;";
                }
            }
            this.num[j - 2] = num8;
        }
        for (int k = 14; k < 20; k++)
        {
            int num12 = 0;
            for (int num13 = 0; num13 < this.GridView1.Rows.Count; num13++)
            {
                if (this.GridView1.Rows[num13].Cells[k].Text == "1")
                {
                    num12++;
                }
                if (this.GridView1.Rows[num13].Cells[k].Text == "2")
                {
                    num12 += 2;
                }
                if ((k > 15) && (this.GridView1.Rows[num13].Cells[k].Text == "0"))
                {
                    this.GridView1.Rows[num13].Cells[k].Text = "&nbsp";
                }
            }
            this.num[k - 2] = num12;
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td align='center' valign='middle'>序号</td>");
        output.Write("<td align='center' valign='middle'>出现次数</td>");
        for (int i = 0; i < 0x12; i++)
        {
            output.Write("<td align='center' valign='middle'>");
            output.Write(this.num[i].ToString() + "</td>");
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3'　align='center' valign='middle'>序号</td>");
        output.Write("<td rowspan='3' align='center' valign='middle'>期数</td>");
        output.Write("<td colspan='18' align='center' valign='middle'><strong><font color='#0000FF'>后区号码</font></strong></td>");
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td colspan='3'>A</td>");
        output.Write("<td colspan='3'>B</td>");
        output.Write("<td colspan='3'>C</td>");
        output.Write("<td colspan='3'>D</td>");
        output.Write("<td colspan='2'>奇偶比</td>");
        output.Write("<td colspan='4'>区域分布</td>");
        output.Write("<tr align='center' valign='middle'>");
        for (int i = 1; i < 10; i++)
        {
            output.Write("<td><font color='#0000FF'>");
            output.Write(0 + i.ToString() + "</font></td>");
        }
        for (int j = 10; j < 13; j++)
        {
            output.Write("<td ><font color='#0000FF'>");
            output.Write(j.ToString() + "</font></td>");
        }
        output.Write("<td>奇</td>");
        output.Write("<td >偶</td>");
        output.Write("<td >一区</td>");
        output.Write("<td >二区</td>");
        output.Write("<td >三区</td>");
        output.Write("<td >四区</td>");
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
        table = BLL.CJDLT_TeMa_SeleteByNum(30);
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
        DataTable table = BLL.CJDLT_TeMa_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_TeMa_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_TeMa_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_TeMa_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_TeMa_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }
}

