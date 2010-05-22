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

public partial class TC22X5_22X5 : Page, IRequiresSessionState
{
    private int m;
    private int mm;
    private int n;
    private int nn;
    private int nnn;
    private int[] num = new int[0x16];
    private int[] sum = new int[0x16];

    protected void ColorBind()
    {
        int count = this.GridView1.Rows.Count;
        for (count = this.GridView1.Rows.Count; count > 0; count--)
        {
            int num2 = this.GridView1.Rows.Count - count;
            this.GridView1.Rows[num2].Cells[0].Text = count.ToString();
        }
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            this.m += _Convert.StrToInt(this.GridView1.Rows[i].Cells[0x18].Text, 0);
            this.mm += _Convert.StrToInt(this.GridView1.Rows[i].Cells[0x19].Text, 0);
            this.n += _Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1d].Text, 0);
            this.nn += _Convert.StrToInt(this.GridView1.Rows[i].Cells[30].Text, 0);
            this.nnn += _Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1f].Text, 0);
            for (int m = 0x1d; m < 0x20; m++)
            {
                if (this.GridView1.Rows[i].Cells[m].Text == "0")
                {
                    this.GridView1.Rows[i].Cells[m].Text = "&nbsp;";
                }
            }
        }
        for (int j = 2; j < 11; j++)
        {
            int num6 = 0;
            for (int n = 0; n < this.GridView1.Rows.Count; n++)
            {
                if (this.GridView1.Rows[n].Cells[j].Text == "0")
                {
                    this.GridView1.Rows[n].Cells[j].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[n].Cells[j].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[n].Cells[j].Text = ("0" + ((j - 1)).ToString()).ToString();
                    num6++;
                }
            }
            this.num[j - 2] = num6;
            int num9 = this.RadioSelete();
            this.sum[j - 2] = (50 * num6) / num9;
        }
        for (int k = 11; k < 0x18; k++)
        {
            int num11 = 0;
            for (int num12 = 0; num12 < this.GridView1.Rows.Count; num12++)
            {
                if (this.GridView1.Rows[num12].Cells[k].Text == "0")
                {
                    this.GridView1.Rows[num12].Cells[k].BackColor = Color.FromArgb(0xe1, 0, 0);
                    this.GridView1.Rows[num12].Cells[k].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                    this.GridView1.Rows[num12].Cells[k].Text = (k - 1).ToString();
                    num11++;
                }
            }
            this.num[k - 2] = num11;
            int num14 = this.RadioSelete();
            this.sum[k - 2] = (50 * num11) / num14;
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='2' rowspan='5'>预测方法：<br>用鼠标点击<br>方格即可显示<br>为开奖号色</td>");
        for (int i = 1; i < 8; i++)
        {
            output.Write("<td bgcolor='#EBFCEF' onClick=Style(this,'#DD0000','#EBFCEF') style='color:#EBFCEF;'>");
            output.Write(0 + i.ToString() + "</td>");
        }
        for (int j = 8; j < 10; j++)
        {
            output.Write("<td bgcolor='#FEEFF5' onClick=Style(this,'#DD0000','#FEEFF5') style='color:#FEEFF5;'>");
            output.Write(0 + j.ToString() + "</td>");
        }
        for (int k = 10; k < 15; k++)
        {
            output.Write("<td bgcolor='#FEEFF5' onClick=Style(this,'#DD0000','#FEEFF5') style='color:#FEEFF5;'>");
            output.Write(k.ToString() + "</td>");
        }
        for (int m = 15; m < 0x17; m++)
        {
            output.Write("<td bgcolor='#EBFCEF' onClick=Style(this,'#DD0000','#EBFCEF') style='color:#EBFCEF;'>");
            output.Write(m.ToString() + "</td>");
        }
        for (int n = 0; n < 8; n++)
        {
            output.Write("<td>&nbsp</td>");
        }
        for (int num6 = 0; num6 < 4; num6++)
        {
            output.Write("<tr align='center' valign='middle'>");
            for (int num7 = 1; num7 < 8; num7++)
            {
                output.Write("<td bgcolor='#EBFCEF' onClick=Style(this,'#DD0000','#EBFCEF') style='color:#EBFCEF;'>");
                output.Write(0 + num7.ToString() + "</td>");
            }
            for (int num8 = 8; num8 < 10; num8++)
            {
                output.Write("<td bgcolor='#FEEFF5' onClick=Style(this,'#DD0000','#FEEFF5') style='color:#FEEFF5;'>");
                output.Write(0 + num8.ToString() + "</td>");
            }
            for (int num9 = 10; num9 < 15; num9++)
            {
                output.Write("<td bgcolor='#FEEFF5' onClick=Style(this,'#DD0000','#FEEFF5') style='color:#FEEFF5;'>");
                output.Write(num9.ToString() + "</td>");
            }
            for (int num10 = 15; num10 < 0x17; num10++)
            {
                output.Write("<td bgcolor='#EBFCEF' onClick=Style(this,'#DD0000','#EBFCEF') style='color:#EBFCEF;'>");
                output.Write(num10.ToString() + "</td>");
            }
            for (int num11 = 0; num11 < 8; num11++)
            {
                output.Write("<td>&nbsp</td>");
            }
        }
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td height='50px' colspan='2' align='center' valign='middle'>出现次数</td>");
        for (int num12 = 0; num12 < 0x16; num12++)
        {
            output.Write("<td align='center' valign='bottom'>");
            output.Write(this.num[num12].ToString() + "<br><img src='../Image/01[1].gif' height='" + this.sum[num12].ToString() + "'' title='" + this.num[num12].ToString() + "' width='8px'></td>");
        }
        output.Write("<td valign='bottom'>");
        output.Write(this.m.ToString() + "</td>");
        output.Write("<td valign='bottom'>");
        output.Write(this.mm.ToString() + "</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td>&nbsp</td>");
        output.Write("<td valign='bottom'>");
        output.Write(this.n.ToString() + "</td>");
        output.Write("<td valign='bottom'>");
        output.Write(this.nn.ToString() + "</td>");
        output.Write("<td valign='bottom'>");
        output.Write(this.nnn.ToString() + "</td>");
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td>序号</td>");
        output.Write("<td>期 数</td>");
        for (int num13 = 1; num13 < 8; num13++)
        {
            output.Write("<td bgcolor='#EBFCEF'><font color='#FF0000'>");
            output.Write(0 + num13.ToString() + "</font></td>");
        }
        output.Write("<td ><font color='#FF0000'>08</font></td>");
        output.Write("<td ><font color='#FF0000'>09</font></td>");
        for (int num14 = 10; num14 < 0x17; num14++)
        {
            output.Write("<td bgcolor='#ffffff'><font color='#FF0000'>");
            output.Write(0 + num14.ToString() + "</font></td>");
        }
        output.Write("<td>奇</td>");
        output.Write("<td>偶</td>");
        output.Write("<td>大</td>");
        output.Write("<td>小</td>");
        output.Write("<td>和值</td>");
        output.Write("<td>一区</td>");
        output.Write("<td>二区</td>");
        output.Write("<td>三区</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3'　align='center' valign='middle'>序号</td>");
        output.Write("<td rowspan='3' align='center' valign='middle'>期数</td>");
        output.Write("<td colspan='30' align='center' valign='middle'><strong><font color='#FF0000'>开奖号码区</font></strong></td>");
        output.Write("<tr align='center' valign='middle'>");
        output.Write("<td colspan='7'>一区</td>");
        output.Write("<td colspan='7'>二区</td>");
        output.Write("<td colspan='8'>三区</td>");
        output.Write("<td colspan='2'>奇偶</td>");
        output.Write("<td colspan='2'>大小</td>");
        output.Write("<td  rowspan='2' bgcolor='#B3EEA8'>和值</td>");
        output.Write("<td colspan='3'>区域分布</td>");
        output.Write("<tr align='center' valign='middle'>");
        for (int i = 1; i < 8; i++)
        {
            output.Write("<td bgcolor='#C0F3C9'><font color='#FF0000'>");
            output.Write(0 + i.ToString() + "</font></td>");
        }
        for (int j = 8; j < 10; j++)
        {
            output.Write("<td bgcolor='#FFCCFF'><font color='#FF0000'>");
            output.Write(0 + j.ToString() + "</font></td>");
        }
        for (int k = 10; k < 15; k++)
        {
            output.Write("<td bgcolor='#FFCCFF'><font color='#FF0000'>");
            output.Write(k.ToString() + "</font></td>");
        }
        for (int m = 15; m < 0x17; m++)
        {
            output.Write("<td bgcolor='#C0F3C9'><font color='#FF0000'>");
            output.Write(m.ToString() + "</font></td>");
        }
        output.Write("<td bgcolor='#FFE67D'>奇</td>");
        output.Write("<td bgcolor='#FFE67D'>偶</td>");
        output.Write("<td bgcolor='#FFF7D2'>大</td>");
        output.Write("<td bgcolor='#FFF7D2'>小</td>");
        output.Write("<td>一区</td>");
        output.Write("<td>二区</td>");
        output.Write("<td>三区</td>");
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
        table = BLL.TC22X5_HMFB_SeleteByNum(30);
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
        DataTable table = BLL.TC22X5_HMFB_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.TC22X5_HMFB_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.TC22X5_HMFB_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.TC22X5_HMFB_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.TC22X5_HMFB_SeleteByNum(10);
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

