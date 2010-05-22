using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _7Xing_7X_LH : TrendChartPageBase, IRequiresSessionState
{
    public string[] bbb = new string[2];
    public int qq;
    public int[] sum = new int[7];
    public int tem;
    public int temp;
    public string[] tr = new string[7];

    private void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td align='center' vlign='middle'>期 数</td>");
        output.Write("<td align='center' vlign='middle'>七星彩开奖号码</td>");
        output.Write("<td align='center' vlign='middle'><font color='FF0000'> 连号数</font></td>");
        output.Write("<td bgcolor='#DCEDDC'>");
        output.Write("0</td>");
        output.Write("<td bgcolor='#DCEDDC'>1</td>");
        output.Write("<td bgcolor='#DCEDDC'>2</td>");
        output.Write("<td bgcolor='#FFC9C8'>3</td>");
        output.Write("<td bgcolor='#FFC9C8'>4</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#E6FFE6'>5</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#FFE1E1'>6</td>");
        output.Write("<td  bgcolor='#D9F5FF'>1-2</td>");
        output.Write("<td  bgcolor='#D9F5FF'>2-3</td>");
        output.Write("<td  bgcolor='#F1F7D2'>3-4</td>");
        output.Write("<td  bgcolor='#F1F7D2'>4-5</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#E1E1FF'>5-6</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#E6FFE6'>6-7</td>");
    }

    private void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan ='2'align ='center' vlign='middle'>期　数</td>");
        output.Write("<td rowspan ='2'align ='center' vlign='middle'>七星彩开奖号码</td>");
        output.Write("<td rowspan ='2'align ='center' vlign='middle' ><font color='#FF0000'>");
        output.Write("连号数</font></td>");
        output.Write("<TD align ='center' vlign='middle'colspan ='7'bgcolor='#99CC99'><font color='#FF0000'>连号个数</font></td>");
        output.Write("<td align ='center' vlign='middle'colspan ='6' bgcolor='#FFCC99'><font color='#FF0000'>排序</font></td>");
        output.Write("<tr align ='center' vlign='middle'>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DCEDDC'>0</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DCEDDC'>1</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DCEDDC'>2</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#FFC9C8'>3</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#FFC9C8'>4</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#E6FFE6'>5</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#FFE1E1'>6</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#D9F5FF'>1-2</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#D9F5FF'>2-3</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#F1F7D2'>3-4</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#F1F7D2'>4-5</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#E1E1FF'>5-6</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#E6FFE6'>6-7</td>");
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
        this.GridView1.DataSource = BLL.X7_LH_SeleteByNum(30);
        this.GridView1.DataBind();
    }

    private void GridViewbindColor()
    {
        this.tem = this.GridView1.Rows.Count;
        for (int i = 3; i < 10; i++)
        {
            int num2 = 0;
            for (int m = 0; m < this.GridView1.Rows.Count; m++)
            {
                if (this.GridView1.Rows[m].Cells[i].Text == "0")
                {
                    num2++;
                }
            }
            this.sum[i - 3] = num2;
        }
        float num4 = (((((this.sum[0] + this.sum[1]) + this.sum[2]) + this.sum[3]) + this.sum[4]) + this.sum[5]) + this.sum[6];
        float num5 = (((float)this.sum[0]) / num4) * 100f;
        float num6 = (((float)this.sum[1]) / num4) * 100f;
        float num7 = (((float)this.sum[2]) / num4) * 100f;
        float num8 = (((float)this.sum[3]) / num4) * 100f;
        float num9 = (((float)this.sum[4]) / num4) * 100f;
        float num10 = (((float)this.sum[5]) / num4) * 100f;
        float num11 = (((float)this.sum[6]) / num4) * 100f;
        string str = num5.ToString();
        string str2 = num6.ToString();
        string str3 = num7.ToString();
        string str4 = num8.ToString();
        string str5 = num9.ToString();
        string str6 = num10.ToString();
        string str7 = num11.ToString();
        string[] strArray2 = new string[] { str, str2, str3, str4, str5, str6, str7 };
        for (int j = 0; j < 7; j++)
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
                this.GridView1.Rows[k].Cells[2].Text = "&nbsp;";
            }
            if (this.GridView1.Rows[k].Cells[2].Text == "1")
            {
                this.GridView1.Rows[k].Cells[2].Text = "01";
            }
            for (int n = 3; n < 10; n++)
            {
                if (this.GridView1.Rows[k].Cells[n].Text == "0")
                {
                    this.GridView1.Rows[k].Cells[n].Text = "●";
                    this.GridView1.Rows[k].Cells[n].ForeColor = Color.FromArgb(0xcc, 0, 0);
                }
                if (this.GridView1.Rows[k].Cells[n].Text == "-1")
                {
                    this.GridView1.Rows[k].Cells[n].Text = "&nbsp;";
                }
            }
            for (int num15 = 10; num15 < 0x10; num15++)
            {
                if (this.GridView1.Rows[k].Cells[num15].Text == "升")
                {
                    this.qq++;
                    this.GridView1.Rows[k].Cells[num15].ForeColor = Color.FromArgb(0xff, 0, 0);
                }
                if (this.GridView1.Rows[k].Cells[num15].Text == "降")
                {
                    this.temp++;
                    this.GridView1.Rows[k].Cells[num15].ForeColor = Color.FromArgb(0, 0, 0xff);
                }
            }
            float num16 = this.qq + this.temp;
            float num17 = (((float)this.temp) / num16) * 100f;
            float num18 = (((float)this.qq) / num16) * 100f;
            string str8 = num17.ToString();
            string str9 = num18.ToString();
            string[] strArray4 = new string[] { str8, str9 };
            for (int num19 = 0; num19 < 2; num19++)
            {
                if (!strArray4[num19].Contains("."))
                {
                    this.bbb[num19] = strArray4[num19] + "%";
                }
                else if (strArray4[num19].IndexOf('.') == 1)
                {
                    this.bbb[num19] = strArray4[num19].Substring(0, 3) + "%";
                }
                else
                {
                    this.bbb[num19] = strArray4[num19].Substring(0, 4) + "%";
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
        DataTable table = BLL.X7_LH_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_LH_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_LH_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_LH_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.X7_LH_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }
}

