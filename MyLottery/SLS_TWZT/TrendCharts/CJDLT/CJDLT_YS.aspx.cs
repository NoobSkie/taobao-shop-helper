using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class CJDLT_CJDLT_YS : Page, IRequiresSessionState
{
    private int[] num = new int[0x1c];

    protected void ColorBind()
    {
        for (int i = 3; i < 0x1f; i++)
        {
            int num2 = 0;
            for (int j = 0; j < this.GridView1.Rows.Count; j++)
            {
                if (this.GridView1.Rows[j].Cells[i].Text == "0")
                {
                    this.GridView1.Rows[j].Cells[i].Text = "&nbsp;";
                }
                if (this.GridView1.Rows[j].Cells[i].Text == "1")
                {
                    num2++;
                    this.GridView1.Rows[j].Cells[i].ForeColor = Color.FromArgb(0xff, 0, 0);
                }
                if (this.GridView1.Rows[j].Cells[i].Text == "2")
                {
                    num2 += 2;
                    this.GridView1.Rows[j].Cells[i].ForeColor = Color.FromArgb(0, 0, 0xff);
                }
                if (this.GridView1.Rows[j].Cells[i].Text == "3")
                {
                    num2 += 3;
                    this.GridView1.Rows[j].Cells[i].ForeColor = Color.FromArgb(0xff, 0x99, 0);
                }
                if (this.GridView1.Rows[j].Cells[i].Text == "4")
                {
                    num2 += 4;
                    this.GridView1.Rows[j].Cells[i].ForeColor = Color.FromArgb(0x33, 0x99, 0);
                }
                if (this.GridView1.Rows[j].Cells[i].Text == "5")
                {
                    num2 += 5;
                    this.GridView1.Rows[j].Cells[i].ForeColor = Color.FromArgb(0xd4, 0xd0, 200);
                }
            }
            this.num[i - 3] = num2;
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td>出现次数</td>");
        output.Write("<td rowspan='1' colspan='2'>&nbsp;</td>");
        for (int i = 0; i < 0x1c; i++)
        {
            output.Write("<td bgcolor='#F3F3F3'>");
            output.Write(this.num[i].ToString() + "</td>");
        }
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2' align='center' valign='middle'>期数</td>");
        output.Write("<td colspan='2' align='center' valign='middle'>开奖号码</td>");
        output.Write("<td colspan='11'>除11余数</td>");
        output.Write("<td colspan='9'>除9余数</td>");
        output.Write("<td colspan='5'>除5余数</td>");
        output.Write("<td colspan='3'>除3余数</td>");
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td align='center' valign='middle'>前 区</td>");
        output.Write("<td align='center' valign='middle'>后区</td>");
        for (int i = 0; i < 11; i++)
        {
            output.Write("<td >");
            output.Write(i.ToString() + "</td >");
        }
        for (int j = 0; j < 9; j++)
        {
            output.Write("<td bgcolor='#EDFFD7'>");
            output.Write(j.ToString() + "</td>");
        }
        for (int k = 0; k < 5; k++)
        {
            output.Write("<td>");
            output.Write(k.ToString() + "</td>");
        }
        for (int m = 0; m < 3; m++)
        {
            output.Write("<td bgcolor='#D2E1F0'>");
            output.Write(m.ToString() + "</td>");
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
        table = BLL.CJDLT_YS_SeleteByNum(30);
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
        DataTable table = BLL.CJDLT_YS_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_YS_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_YS_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_YS_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_YS_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }
}

