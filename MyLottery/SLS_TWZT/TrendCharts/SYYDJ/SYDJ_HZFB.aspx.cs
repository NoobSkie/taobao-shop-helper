using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class DefualtHZ : TrendChartPageBase, IRequiresSessionState
{
    private int[] allCount = new int[0x29];
    private int[] avgCount = new int[0x29];
    private int dtcount;
    private int[] lianCount = new int[0x29];
    private int[] maxCount = new int[0x29];

    private void ColorBind()
    {
        try
        {
            for (int i = 0; i < this.gvtable.Rows.Count; i++)
            {
                for (int k = 6; k <= 0x24; k++)
                {
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) <= 0)
                    {
                        this.gvtable.Rows[i].Cells[k].CssClass = "chartBall04";
                        this.allCount[k - 6]++;
                        if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1) > this.lianCount[k - 6])
                        {
                            this.lianCount[k - 6] = Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1;
                        }
                        this.gvtable.Rows[i].Cells[k].Text = Convert.ToString((int)(k + 9));
                    }
                    else
                    {
                        if (this.gvtable.Rows[i].Cells[k].Text.Length >= 3)
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "yl01 cfont_small";
                        }
                        else
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "yl01";
                        }
                        if (Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) > this.maxCount[k - 6])
                        {
                            this.maxCount[k - 6] = Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text);
                        }
                    }
                }
                for (int m = 0x25; m < 0x2f; m++)
                {
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) <= 0)
                    {
                        this.gvtable.Rows[i].Cells[m].CssClass = "cbg4";
                        this.allCount[m - 6]++;
                        if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) * -1) > this.lianCount[m - 6])
                        {
                            this.lianCount[m - 6] = Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) * -1;
                        }
                        this.gvtable.Rows[i].Cells[m].Text = Convert.ToString((int)(m - 0x25));
                    }
                    else
                    {
                        if (this.gvtable.Rows[i].Cells[m].Text.Length >= 3)
                        {
                            this.gvtable.Rows[i].Cells[m].CssClass = "yl01 cfont_small";
                        }
                        else
                        {
                            this.gvtable.Rows[i].Cells[m].CssClass = "yl01";
                        }
                        if (Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) > this.maxCount[m - 6])
                        {
                            this.maxCount[m - 6] = Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text);
                        }
                    }
                }
            }
            for (int j = 0; j < 0x29; j++)
            {
                if (this.allCount[j] != 0)
                {
                    this.avgCount[j] = (this.dtcount - 13) / this.allCount[j];
                }
                else
                {
                    this.avgCount[j] = this.maxCount[j];
                }
            }
        }
        catch (Exception exception)
        {
            new Log("System").Write("SYDJ_HZFB.aspx" + exception.Message + " 页面异常");
        }
    }

    protected void ddlSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        int num = Convert.ToInt32(this.ddlSelect.Items[this.ddlSelect.SelectedIndex].Value);
        this.MyDataBind(num - 1, 1);
        this.ColorBind();
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td  height='36px'>预选1</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int i = 15; i <= 0x2d; i++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(i + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int j = 0; j < 10; j++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(j + 1)) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选2</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int k = 15; k <= 0x2d; k++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(k + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int m = 0; m < 10; m++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(m + 1)) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选3</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int n = 15; n <= 0x2d; n++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(n + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num6 = 0; num6 < 10; num6++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num6 + 1)) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选4</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num7 = 15; num7 <= 0x2d; num7++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num7 + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num8 = 0; num8 < 10; num8++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num8 + 1)) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选5</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num9 = 15; num9 <= 0x2d; num9++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num9 + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num10 = 0; num10 < 10; num10++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num10 + 1)) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>出现总次数</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num11 = 0; num11 <= 40; num11++)
        {
            if (this.allCount[num11].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.allCount[num11].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.allCount[num11].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>平均遗漏值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num12 = 0; num12 <= 40; num12++)
        {
            if (this.avgCount[num12].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.avgCount[num12].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.avgCount[num12].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>最大遗漏值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num13 = 0; num13 <= 40; num13++)
        {
            if (this.maxCount[num13].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.maxCount[num13].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.maxCount[num13].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>最大连出值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num14 = 0; num14 <= 40; num14++)
        {
            if (this.maxCount[num14].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.maxCount[num14].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.maxCount[num14].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr class= 'thbg01' >");
        output.Write("<td rowspan='2' class='td_bg'   width='80px' align='middle'  > &nbsp;</td>");
        output.Write("<td rowspan='2' class='cfont1 td_bg'  rowSpan='2' colSpan='5'  >开奖号码</td>");
        for (int num15 = 15; num15 <= 0x2d; num15++)
        {
            output.Write("<TD width=18><STRONG>" + num15.ToString() + "</STRONG></TD>");
        }
        for (int num16 = 0; num16 < 10; num16++)
        {
            output.Write("<TD width=18><STRONG>" + num16.ToString() + "</STRONG></TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write(" <td colspan='32'><strong>和值</strong></td>");
        output.Write("<td colspan='11'><strong>和尾</strong></td>");
        output.Write("</tr  >");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td width='80' rowspan='2' align='center' ><strong>期号</strong></td>");
        output.Write("<td rowspan='2' class='cfont1'  colSpan='5'  >开奖号码</td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write(" <td colspan='31'><strong>和值</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='10'><strong>和尾</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<tr class= 'thbg01' >");
        for (int i = 15; i <= 0x2d; i++)
        {
            output.Write("<TD width=18><STRONG>" + i.ToString() + "</STRONG></TD>");
        }
        for (int j = 0; j < 10; j++)
        {
            output.Write("<TD width=18><STRONG>" + j.ToString() + "</STRONG></TD>");
        }
        output.Write("</tr  >");
    }

    protected void gvtable_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.SetRenderMethodDelegate(new RenderMethod(this.DrawGridFooter));
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.SetRenderMethodDelegate(new RenderMethod(this.DrawGridHeader));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].CssClass = "chartBall01";
            e.Row.Cells[2].CssClass = "chartBall01";
            e.Row.Cells[3].CssClass = "chartBall01";
            e.Row.Cells[4].CssClass = "chartBall01";
            e.Row.Cells[5].CssClass = "chartBall01";
        }
    }

    protected void lbtnLast_Click(object sender, EventArgs e)
    {
        this.MyDataBind(1, 0);
        this.ColorBind();
    }

    protected void lbtnToday_Click(object sender, EventArgs e)
    {
        this.MyDataBind(0, 0);
        this.ColorBind();
    }

    private void MyDataBind(int DaySpan, int Type)
    {
        int returnValue = 0;
        string returnDescription = "";
        DataTable table = new TheadChart().SYDJ_HZFB(DaySpan, Type, ref returnValue, ref returnDescription);
        this.dtcount = table.Rows.Count + 13;
        this.gvtable.DataSource = table;
        this.gvtable.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.MyDataBind(1, 1);
            this.ColorBind();
        }
    }
}

