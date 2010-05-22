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

public partial class View_PL3_LH : TrendChartPageBase, IRequiresSessionState
{
    public string[] bbb = new string[2];
    public int qq;
    public int[] sum = new int[3];
    public int tem;
    public int temp;
    public string[] tr = new string[3];

    private void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        int[] numArray = new int[5];
        int count = this.GridView1.Rows.Count;
        int num2 = _Convert.StrToInt(this.GridView1.Rows[count - 1].Cells[0].Text, 0);
        numArray[0] = num2 + 1;
        numArray[1] = numArray[0] + 1;
        numArray[2] = numArray[1] + 1;
        numArray[3] = numArray[2] + 1;
        numArray[4] = numArray[3] + 1;
        output.Write("<td align='center' vlign='middle'>");
        output.Write(numArray[0].ToString() + "</td>");
        output.Write("<td rowspan ='5'>预测方法：用鼠标<br>点击方格即可显示<br>为开奖号色</td>");
        output.Write("<td>&nbsp;");
        for (int i = 0; i < 3; i++)
        {
            output.Write("<td  style='color:#FFFFFF;' bgcolor='#FFFFFF' onClick=Style(this,'#FFFFFF','#FFFFFF')>●</td>");
        }
        for (int j = 0; j < 2; j++)
        {
            output.Write("<td>&nbsp;");
        }
        for (int k = 0; k < 4; k++)
        {
            output.Write("<tr align='center' vlign='middle'>");
            output.Write("<td align='center' vlign='middle'>");
            output.Write(numArray[k + 1].ToString() + "</td>");
            output.Write("<td>&nbsp;");
            for (int m = 0; m < 3; m++)
            {
                output.Write("<td  style='color:#FFFFFF;' bgcolor='#FFFFFF' onClick=Style(this,'#FFFFFF','#FFFFFF')>●</td>");
            }
            for (int n = 0; n < 2; n++)
            {
                output.Write("<td>&nbsp;");
            }
        }
        output.Write("<tr align='center' vlign='middle'>");
        output.Write("<td align='center' vlign='middle'>期数</td>");
        output.Write("<td align='center' vlign='middle'>排列3开奖号码</td>");
        output.Write("<td align='center' vlign='middle'><strong><font color='FF0000'> 连号数</font></strong></td>");
        output.Write("<td bgcolor='#DCEDDC'>");
        output.Write("0</td>");
        output.Write("<td bgcolor='#DFD0DF'>1</td>");
        output.Write("<td bgcolor='#DFDFFF'>2</td>");
        output.Write("<td  bgcolor='#D9F5FF'>1-2</td>");
        output.Write("<td  bgcolor='#F1F7D2'>2-3</td>");
    }

    private void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan ='2'align ='center' vlign='middle'>期　数</td>");
        output.Write("<td rowspan ='2'align ='center' vlign='middle'>开奖号码</td>");
        output.Write("<td rowspan ='2'align ='center' vlign='middle' ><strong><font color='#FF0000'>");
        output.Write("连号数</font></strong></td>");
        output.Write("<TD align ='center' vlign='middle'colspan ='3'bgcolor='#99CC99'><strong><font color='#FF0000'>连号个数</font></strong></td>");
        output.Write("<td align ='center' vlign='middle'colspan ='2' bgcolor='#FFCC99'><strong><font color='#FF0000'>排序</font></strong></td>");
        output.Write("<tr align ='center' vlign='middle'>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DCEDDC'>0</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DFD0DF'>1</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DFDFFF'>2</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#D9F5FF'>1-2</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#F1F7D2'>2-3</td>");
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
        this.GridView1.DataSource = BLL.PL3_LH_SeleteByNum(30);
        this.GridView1.DataBind();
    }

    private void GridViewbindColor()
    {
        this.tem = this.GridView1.Rows.Count;
        for (int i = 3; i < 6; i++)
        {
            int num2 = 0;
            for (int n = 0; n < this.GridView1.Rows.Count; n++)
            {
                if (this.GridView1.Rows[n].Cells[i].Text == "0")
                {
                    num2++;
                }
            }
            this.sum[i - 3] = num2;
        }
        float num4 = (this.sum[0] + this.sum[1]) + this.sum[2];
        float num5 = (((float)this.sum[0]) / num4) * 100f;
        float num6 = (((float)this.sum[1]) / num4) * 100f;
        float num7 = (((float)this.sum[2]) / num4) * 100f;
        string str = num5.ToString();
        string str2 = num6.ToString();
        string str3 = num7.ToString();
        string[] strArray2 = new string[] { str, str2, str3 };
        for (int j = 0; j < 3; j++)
        {
            if (!strArray2[j].Contains("."))
            {
                this.tr[j] = strArray2[j] + "%";
            }
            else if (strArray2[j].IndexOf('.') == 1)
            {
                this.tr[j] = strArray2[j].Substring(0, 4) + "%";
            }
            else
            {
                this.tr[j] = strArray2[j].Substring(0, 5) + "%";
            }
        }
        for (int k = 0; k < this.GridView1.Rows.Count; k++)
        {
            if (this.GridView1.Rows[k].Cells[2].Text == "0")
            {
                this.GridView1.Rows[k].Cells[2].Text = "&nbsp";
            }
            for (int num10 = 3; num10 < 6; num10++)
            {
                if (this.GridView1.Rows[k].Cells[num10].Text == "-1")
                {
                    this.GridView1.Rows[k].Cells[num10].Text = "&nbsp";
                }
                if (this.GridView1.Rows[k].Cells[num10].Text == "0")
                {
                    this.GridView1.Rows[k].Cells[num10].Text = " ●";
                    this.GridView1.Rows[k].Cells[num10].ForeColor = Color.FromArgb(0xcc, 0, 0);
                }
            }
            for (int num11 = 6; num11 <= 7; num11++)
            {
                if (this.GridView1.Rows[k].Cells[num11].Text == "降")
                {
                    this.temp++;
                    this.GridView1.Rows[k].Cells[num11].ForeColor = Color.FromArgb(0, 0, 0xff);
                }
                if (this.GridView1.Rows[k].Cells[num11].Text == "升")
                {
                    this.qq++;
                    this.GridView1.Rows[k].Cells[num11].ForeColor = Color.FromArgb(0xff, 0, 0);
                }
            }
        }
        float num12 = this.qq + this.temp;
        float num13 = (((float)this.temp) / num12) * 100f;
        float num14 = (((float)this.qq) / num12) * 100f;
        string str4 = num13.ToString();
        string str5 = num14.ToString();
        string[] strArray4 = new string[] { str4, str5 };
        for (int m = 0; m < 2; m++)
        {
            if (!strArray4[m].Contains("."))
            {
                this.bbb[m] = strArray4[m] + "%";
            }
            else if (strArray4[m].IndexOf('.') == 1)
            {
                this.bbb[m] = strArray4[m].Substring(0, 4) + "%";
            }
            else
            {
                this.bbb[m] = strArray4[m].Substring(0, 5) + "%";
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
        DataTable table = BLL.PL3_LH_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_LH_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_LH_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_LH_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL3_LH_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }
}

