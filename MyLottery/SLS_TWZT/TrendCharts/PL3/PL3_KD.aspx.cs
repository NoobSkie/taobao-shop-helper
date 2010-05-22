using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class View_PL3_KD : TrendChartPageBase, IRequiresSessionState
{
    private int[] num = new int[10];
    private int[] sum = new int[10];

    private void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='2' rowspan='5'>预测方法：用鼠标点击方格<BR>即可显示为开奖号色</td>");
        output.Write("<TD bgcolor ='#E4F1D8'>&nbsp</td>");
        for (int i = 0; i < 10; i++)
        {
            output.Write("<td bgcolor ='#E1EFFF'onClick=Style(this,'#DD0000','#E1EFFF') style='color:#E1EFFF' ForeColor='#FFFFFF'>");
            output.Write(i.ToString() + "</td>");
        }
        for (int j = 0; j < 4; j++)
        {
            output.Write("<tr align='center' valign ='middle'>");
            output.Write("<td bgcolor ='#E4F1D8'>&nbsp</td>");
            for (int n = 0; n < 10; n++)
            {
                output.Write("<td bgcolor ='#E1EFFF'onClick=Style(this,'#DD0000','#E1EFFF') style='color:#E1EFFF' ForeColor='#FFFFFF'>");
                output.Write(n.ToString() + "</td>");
            }
        }
        output.Write("<tr align='center' valign ='middle'>");
        output.Write("<td align='center' valign ='middle' height='50'>出现次数</td>");
        output.Write("<td colspan ='2'>&nbsp</td>");
        for (int k = 0; k < 10; k++)
        {
            output.Write("<td align='center' valign='bottom'>");
            output.Write(this.num[k].ToString() + "<br><img src='../image/01[1].gif' height='" + this.sum[k].ToString() + "px' title = '" + this.num[k].ToString() + "' width= '8px'></td>");
        }
        output.Write("<tr align='center' valign ='middle'>");
        output.Write("<td align='center' valign ='middle'>期  数</td>");
        output.Write("<td align='center' valign ='middle'>开奖号码</td>");
        output.Write("<td bgcolor='#E4F1D8'><strong><font Color='#DD0000'>跨度</font></strong></td>");
        for (int m = 0; m < 10; m++)
        {
            output.Write("<td bgcolor ='#E1EFFF'<strong><font Color='#DD0000'>");
            output.Write(m.ToString() + "</font></strong></td>");
        }
    }

    private void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'>期  数</td>");
        output.Write("<td rowspan='2'>开奖号码</td>");
        output.Write("<td colspan='11' align='center' valign='middle'>排列3跨度分布</td>");
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td bgcolor='#E4F1D8'><strong><font Color='#DD0000'>跨度</font></strong></td>");
        for (int i = 0; i < 10; i++)
        {
            output.Write("<td bgcolor='#E1EFFF' align='center' valign='middle' <strong><font Color='#DD0000'>");
            output.Write(i.ToString() + "</font></strong></td>");
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
        this.GridView1.DataSource = BLL.PL3_KD_SeleteByNum(30);
        this.GridView1.DataBind();
    }

    private void GridViewbindColor()
    {
        for (int i = 3; i < this.GridView1.Columns.Count; i++)
        {
            int num2 = 0;
            for (int j = 0; j < this.GridView1.Rows.Count; j++)
            {
                if (this.GridView1.Rows[j].Cells[i].Text == "0")
                {
                    this.GridView1.Rows[j].Cells[i].BackColor = Color.FromArgb(0xdd, 0, 0);
                    this.GridView1.Rows[j].Cells[i].Text = (i - 3).ToString();
                    this.GridView1.Rows[j].Cells[i].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    num2++;
                }
            }
            this.num[i - 3] = num2;
            int num5 = this.RadioSelete();
            this.sum[i - 3] = (this.num[i - 3] * 50) / num5;
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
        DataTable table = BLL.PL3_KD_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_KD_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_KD_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_KD_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_KD_SeleteByNum(10);
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

