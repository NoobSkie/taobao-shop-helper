using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class TC22X5_22X5_LH : Page, IRequiresSessionState
{
    public int[] sum = new int[5];
    public int tem;
    public int temp;
    public string[] tr = new string[5];

    private void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td align='center' vlign='middle'>序 号</td>");
        output.Write("<td align='center' vlign='middle'>期 数</td>");
        output.Write("<td align='center' vlign='middle'>体彩22选5开奖号码</td>");
        output.Write("<td align='center' vlign='middle'><font color='FF0000'> 连号数</font></td>");
        output.Write("<td bgcolor='#DCEDDC'>");
        output.Write("0</td>");
        output.Write("<td bgcolor='#DFD0DF'>1</td>");
        output.Write("<td bgcolor='#DFDFFF'>2</td>");
        output.Write("<td bgcolor='#D9F5FF'>3</td>");
        output.Write("<td bgcolor='#F1F7D2'>4</td>");
    }

    private void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan ='2'align ='center' vlign='middle'>序  号</td>");
        output.Write("<td rowspan ='2'align ='center' vlign='middle'>期　数</td>");
        output.Write("<td rowspan ='2'align ='center' vlign='middle'>体彩22选5开奖号码</td>");
        output.Write("<td rowspan ='2'align ='center' vlign='middle' ><font color='#FF0000'>");
        output.Write("连号数</font></td>");
        output.Write("<TD align ='center' vlign='middle'colspan ='5'bgcolor='#99CC99'><font color='#FF0000'>连号个数</font></td>");
        output.Write("<tr align ='center' vlign='middle'>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DCEDDC'>0</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DFD0DF'>1</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DFDFFF'>2</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#D9F5FF'>3</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#F1F7D2'>4</td>");
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
        this.GridView1.DataSource = BLL.TC22X5_LH_SeleteByNum(30);
        this.GridView1.DataBind();
    }

    private void GridViewbindColor()
    {
        for (int i = this.GridView1.Rows.Count; i > 0; i--)
        {
            int num2 = this.GridView1.Rows.Count - i;
            this.GridView1.Rows[num2].Cells[0].Text = i.ToString();
        }
        this.tem = this.GridView1.Rows.Count;
        for (int j = 4; j < 9; j++)
        {
            int num4 = 0;
            for (int n = 0; n < this.GridView1.Rows.Count; n++)
            {
                if (this.GridView1.Rows[n].Cells[j].Text == "0")
                {
                    num4++;
                }
            }
            this.sum[j - 4] = num4;
        }
        float num6 = (((this.sum[0] + this.sum[1]) + this.sum[2]) + this.sum[3]) + this.sum[4];
        float num7 = (((float)this.sum[0]) / num6) * 100f;
        float num8 = (((float)this.sum[1]) / num6) * 100f;
        float num9 = (((float)this.sum[2]) / num6) * 100f;
        float num10 = (((float)this.sum[3]) / num6) * 100f;
        float num11 = (((float)this.sum[4]) / num6) * 100f;
        string str = num7.ToString();
        string str2 = num8.ToString();
        string str3 = num9.ToString();
        string str4 = num10.ToString();
        string str5 = num11.ToString();
        string[] strArray2 = new string[] { str, str2, str3, str4, str5 };
        for (int k = 0; k < 5; k++)
        {
            if (!strArray2[k].Contains("."))
            {
                this.tr[k] = strArray2[k] + "%";
            }
            else if (strArray2[k].IndexOf('.') == 1)
            {
                this.tr[k] = strArray2[k].Substring(0, 4) + "%";
            }
            else
            {
                this.tr[k] = strArray2[k].Substring(0, 5) + "%";
            }
        }
        for (int m = 0; m < this.GridView1.Rows.Count; m++)
        {
            for (int num14 = 4; num14 < 9; num14++)
            {
                if (this.GridView1.Rows[m].Cells[num14].Text == "0")
                {
                    this.GridView1.Rows[m].Cells[num14].Text = "●";
                    this.GridView1.Rows[m].Cells[num14].ForeColor = Color.FromArgb(0xcc, 0, 0);
                }
                if (this.GridView1.Rows[m].Cells[num14].Text == "-1")
                {
                    this.GridView1.Rows[m].Cells[num14].Text = "&nbsp;";
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
        DataTable table = BLL.TC22X5_LH_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.TC22X5_LH_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.TC22X5_LH_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.TC22X5_LH_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.TC22X5_LH_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }
}

