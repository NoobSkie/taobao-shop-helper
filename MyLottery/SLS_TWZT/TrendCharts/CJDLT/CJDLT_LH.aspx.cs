using ASP;
using System;
using System.Data;
using System.Drawing;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class CJDLT_CJDLT_LH : Page, IRequiresSessionState
{
    public int[] sum = new int[6];
    public int tem;
    public int temp;
    public string[] tr = new string[6];

    private void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td align='center' vlign='middle'>期 数</td>");
        output.Write("<td align='center' vlign='middle'>超级大乐透开奖号码</td>");
        output.Write("<td align='center' vlign='middle'><font color='FF0000'> 连号数</font></td>");
        output.Write("<td bgcolor='#DCEDDC'>");
        output.Write("0</td>");
        output.Write("<td bgcolor='#DFD0DF'>1</td>");
        output.Write("<td bgcolor='#DFDFFF'>2</td>");
        output.Write("<td bgcolor='#D9F5FF'>3</td>");
        output.Write("<td bgcolor='#F1F7D2'>4</td>");
        output.Write("<td bgcolor='#F1F7D4'>4</td>");
    }

    private void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan ='2'align ='center' vlign='middle'>期　数</td>");
        output.Write("<td rowspan ='2'align ='center' vlign='middle'>超级大乐透开奖号码</td>");
        output.Write("<td rowspan ='2'align ='center' vlign='middle' ><font color='#FF0000'>");
        output.Write("连号数</font></td>");
        output.Write("<TD align ='center' vlign='middle'colspan ='6'bgcolor='#99CC99'><font color='#FF0000'>连号个数</font></td>");
        output.Write("<tr align ='center' vlign='middle'>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DCEDDC'>0</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DFD0DF'>1</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#DFDFFF'>2</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#D9F5FF'>3</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#F1F7D2'>4</td>");
        output.Write("<td align ='center' vlign='middle' bgcolor='#F1F7D4'>5</td>");
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
        this.GridView1.DataSource = BLL.CJDLT_LH_SeleteByNum(30);
        this.GridView1.DataBind();
    }

    private void GridViewbindColor()
    {
        this.tem = this.GridView1.Rows.Count;
        for (int i = 3; i < 9; i++)
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
        float num4 = ((((this.sum[0] + this.sum[1]) + this.sum[2]) + this.sum[3]) + this.sum[4]) + this.sum[5];
        float num5 = (((float)this.sum[0]) / num4) * 100f;
        float num6 = (((float)this.sum[1]) / num4) * 100f;
        float num7 = (((float)this.sum[2]) / num4) * 100f;
        float num8 = (((float)this.sum[3]) / num4) * 100f;
        float num9 = (((float)this.sum[4]) / num4) * 100f;
        float num10 = (((float)this.sum[5]) / num4) * 100f;
        float[] numArray2 = new float[] { num5, num6, num7, num8, num9, num10 };
        double[] numArray3 = new double[6];
        for (int j = 0; j < 6; j++)
        {
            numArray3[j] = Math.Round((double)numArray2[j], 2);
            this.tr[j] = numArray3[j].ToString() + "%";
        }
        for (int k = 0; k < this.GridView1.Rows.Count; k++)
        {
            for (int n = 3; n < 9; n++)
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
        DataTable table = BLL.CJDLT_LH_SeleteByNum(100);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_LH_SeleteByNum(50);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_LH_SeleteByNum(30);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton4_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_LH_SeleteByNum(20);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }

    protected void RadioButton5_CheckedChanged1(object sender, EventArgs e)
    {
        DataTable table = BLL.CJDLT_LH_SeleteByNum(10);
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.GridViewbindColor();
    }
}

