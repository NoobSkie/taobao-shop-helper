using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _7Xing_7X_CF : TrendChartPageBase, IRequiresSessionState
{
    private int[] num = new int[10];
    private int[] sum = new int[10];

    private void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        int num = this.RadioSelete();
        output.Write("<td width = '100px' height='50px'>");
        output.Write("出现次数</td>");
        output.Write("<td width = '100px'>");
        output.Write("&nbsp</td>");
        for (int i = 2; i < this.GridView1.Columns.Count; i++)
        {
            int num3 = 0;
            for (int j = 0; j < this.GridView1.Rows.Count; j++)
            {
                if ((this.GridView1.Rows[j].Cells[i].Text == "0") || (this.GridView1.Rows[j].Cells[i].Text == "1"))
                {
                    //num3 = num3;
                    this.num[i - 2] = num3;
                    this.sum[i - 2] = (num3 * 50) / num;
                }
                if ((((this.GridView1.Rows[j].Cells[i].Text == "2") || (this.GridView1.Rows[j].Cells[i].Text == "3")) || ((this.GridView1.Rows[j].Cells[i].Text == "4") || (this.GridView1.Rows[j].Cells[i].Text == "5"))) || ((this.GridView1.Rows[j].Cells[i].Text == "6") || (this.GridView1.Rows[j].Cells[i].Text == "7")))
                {
                    num3++;
                    this.num[i - 2] = num3;
                    this.sum[i - 2] = (num3 * 50) / num;
                }
            }
            output.Write("<td align='center' valign='bottom'>");
            output.Write(this.num[i - 2].ToString() + "<br><img src='../image/01[1].gif' height='" + this.sum[i - 2].ToString() + "px' title = '" + this.num[i - 2].ToString() + "' width= '8px'></td>");
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.SetRenderMethodDelegate(new RenderMethod(this.DrawGridFooter));
        }
    }

    private void GridViewbind()
    {
        this.GridView1.DataSource = BLL.X7_CF_SeleteByNum(30);
        this.GridView1.DataBind();
    }

    private void GridViewbindColor()
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            for (int j = 2; j < this.GridView1.Columns.Count; j++)
            {
                this.GridView1.Rows[i].Cells[1].ForeColor = Color.Blue;
                if (this.GridView1.Rows[i].Cells[j].Text == "0")
                {
                    this.GridView1.Rows[i].Cells[j].Text = "&nbsp;";
                }
                if (this.GridView1.Rows[i].Cells[j].Text == "1")
                {
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.Black;
                    this.GridView1.Rows[i].Cells[j].BackColor = Color.FromArgb(0xee, 0xee, 0xee);
                }
                if (this.GridView1.Rows[i].Cells[j].Text == "2")
                {
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.White;
                    this.GridView1.Rows[i].Cells[j].BackColor = Color.FromArgb(0xdd, 0, 0);
                }
                if (this.GridView1.Rows[i].Cells[j].Text == "3")
                {
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.White;
                    this.GridView1.Rows[i].Cells[j].BackColor = Color.FromArgb(0, 0, 0xff);
                }
                if (this.GridView1.Rows[i].Cells[j].Text == "4")
                {
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.White;
                    this.GridView1.Rows[i].Cells[j].BackColor = Color.FromArgb(250, 0xd6, 0x54);
                }
                if (this.GridView1.Rows[i].Cells[j].Text == "5")
                {
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.White;
                    this.GridView1.Rows[i].Cells[j].BackColor = Color.FromArgb(0x62, 0xc0, 0x62);
                }
                if (this.GridView1.Rows[i].Cells[j].Text == "6")
                {
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.White;
                    this.GridView1.Rows[i].Cells[j].BackColor = Color.FromArgb(0x3e, 0xb8, 0xd3);
                }
                if (this.GridView1.Rows[i].Cells[j].Text == "7")
                {
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.White;
                    this.GridView1.Rows[i].Cells[j].BackColor = Color.FromArgb(0x59, 0x9b, 0xcd);
                }
            }
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
        DataTable table = BLL.X7_CF_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_CF_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_CF_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_CF_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_CF_SeleteByNum(10);
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

