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

public partial class PL5_PL5_LH : TrendChartPageBase, IRequiresSessionState
{
    public string[] bbb = new string[2];
 
    public int qq;

    public int[] sum = new int[5];
    public int tem;
    public int temp;
    public string[] tr = new string[5];

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
        for (int i = 0; i < 5; i++)
        {
            output.Write("<td  style='color:#FFFFFF;' bgcolor='#FFFFFF' onClick=Style(this,'#FFFFFF','#FFFFFF')>●</td>");
        }
        for (int j = 0; j < 4; j++)
        {
            output.Write("<td>&nbsp;");
        }
        for (int k = 0; k < 4; k++)
        {
            output.Write("<tr align='center' vlign='middle'>");
            output.Write("<td align='center' vlign='middle'>");
            output.Write(numArray[k + 1].ToString() + "</td>");
            output.Write("<td>&nbsp;");
            for (int m = 0; m < 5; m++)
            {
                output.Write("<td  style='color:#FFFFFF;' bgcolor='#FFFFFF' onClick=Style(this,'#FFFFFF','#FFFFFF')>●</td>");
            }
            for (int n = 0; n < 4; n++)
            {
                output.Write("<td>&nbsp;");
            }
        }
        output.Write("<tr align='center' vlign='middle'>");
        output.Write("<td align='center' vlign='middle'>期 数</td>");
        output.Write("<td align='center' vlign='middle'>排列5开奖号码</td>");
        output.Write("<td align='center' vlign='middle'><font color='FF0000'> 连号数</font></td>");
        output.Write("<td bgcolor='#DCEDDC'>");
        output.Write("0</td>");
        output.Write("<td bgcolor='#DCEDDC'>1</td>");
        output.Write("<td bgcolor='#DCEDDC'>2</td>");
        output.Write("<td bgcolor='#FFC9C8'>3</td>");
        output.Write("<td bgcolor='#FFC9C8'>4</td>");
        output.Write("<td  bgcolor='#D9F5FF'>1-2</td>");
        output.Write("<td  bgcolor='#D9F5FF'>2-3</td>");
        output.Write("<td  bgcolor='#F1F7D2'>3-4</td>");
        output.Write("<td  bgcolor='#F1F7D2'>4-5</td>");
    }

    private void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan ='2'align ='center' vlign='middle'>期　数</td>");
        output.Write("<td rowspan ='2'align ='center' vlign='middle'>排列5开奖号码</td>");
        output.Write("<td rowspan ='2'align ='center' vlign='middle' ><font color='#FF0000'>");
        output.Write("连号数</font></td>");
        output.Write("<TD align ='center' vlign='middle'colspan ='5'bgcolor='#99CC99'><font color='#FF0000'>连号个数</font></td>");
        output.Write("<td align ='center' vlign='middle'colspan ='4' bgcolor='#FFCC99'><font color='#FF0000'>排序</font></td>");
        output.Write("<tr align ='center' vlign='middle'>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DCEDDC'>0</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DCEDDC'>1</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DCEDDC'>2</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#FFC9C8'>3</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#FFC9C8'>4</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#D9F5FF'>1-2</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#D9F5FF'>2-3</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#F1F7D2'>3-4</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#F1F7D2'>4-5</td>");
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
        this.GridView1.DataSource = BLL.PL5_LH_SeleteByNum(30);
        this.GridView1.DataBind();
    }

    private void GridViewbindColor()
    {
        this.tem = this.GridView1.Rows.Count;
        for (int i = 3; i < 8; i++)
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
        float num4 = (((this.sum[0] + this.sum[1]) + this.sum[2]) + this.sum[3]) + this.sum[4];
        float num5 = (((float)this.sum[0]) / num4) * 100f;
        float num6 = (((float)this.sum[1]) / num4) * 100f;
        float num7 = (((float)this.sum[2]) / num4) * 100f;
        float num8 = (((float)this.sum[3]) / num4) * 100f;
        float num9 = (((float)this.sum[4]) / num4) * 100f;
        string str = num5.ToString();
        string str2 = num6.ToString();
        string str3 = num7.ToString();
        string str4 = num8.ToString();
        string str5 = num9.ToString();
        string[] strArray2 = new string[] { str, str2, str3, str4, str5 };
        for (int j = 0; j < 5; j++)
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
            for (int n = 3; n < 8; n++)
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
            for (int num13 = 8; num13 < 12; num13++)
            {
                if (this.GridView1.Rows[k].Cells[num13].Text == "升")
                {
                    this.qq++;
                    this.GridView1.Rows[k].Cells[num13].ForeColor = Color.FromArgb(0xff, 0, 0);
                }
                if (this.GridView1.Rows[k].Cells[num13].Text == "降")
                {
                    this.temp++;
                    this.GridView1.Rows[k].Cells[num13].ForeColor = Color.FromArgb(0, 0, 0xff);
                }
            }
            float num14 = this.qq + this.temp;
            float num15 = (((float)this.temp) / num14) * 100f;
            float num16 = (((float)this.qq) / num14) * 100f;
            string str6 = num15.ToString();
            string str7 = num16.ToString();
            string[] strArray4 = new string[] { str6, str7 };
            for (int num17 = 0; num17 < 2; num17++)
            {
                if (!strArray4[num17].Contains("."))
                {
                    this.bbb[num17] = strArray4[num17] + "%";
                }
                else if (strArray4[num17].IndexOf('.') == 1)
                {
                    this.bbb[num17] = strArray4[num17].Substring(0, 4) + "%";
                }
                else
                {
                    this.bbb[num17] = strArray4[num17].Substring(0, 5) + "%";
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
        DataTable table = BLL.PL5_LH_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_LH_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_LH_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_LH_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.PL5_LH_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }
}

