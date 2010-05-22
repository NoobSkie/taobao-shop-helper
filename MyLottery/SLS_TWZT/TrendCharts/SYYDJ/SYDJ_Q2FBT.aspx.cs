using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class DefaultQ2 : TrendChartPageBase, IRequiresSessionState
{
    private int[] allCount = new int[0x21];
    private int[] avgCount = new int[0x21];
    private int dtcount;
    private int[] lianCount = new int[0x21];
    private int[] maxCount = new int[0x21];

    private void ColorBind()
    {
        for (int i = 0; i < this.gvtable.Rows.Count; i++)
        {
            for (int k = 3; k <= 13; k++)
            {
                if (Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) <= 0)
                {
                    this.gvtable.Rows[i].Cells[k].CssClass = "chartBall04";
                    this.allCount[k - 3]++;
                    if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1) > this.lianCount[k - 3])
                    {
                        this.lianCount[k - 3] = Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1;
                    }
                    this.gvtable.Rows[i].Cells[k].Text = Convert.ToString((int)(k - 2));
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
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) > this.maxCount[k - 3])
                    {
                        this.maxCount[k - 3] = Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text);
                    }
                }
            }
            for (int m = 14; m <= 0x18; m++)
            {
                if (Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) <= 0)
                {
                    this.gvtable.Rows[i].Cells[m].CssClass = "chartBall03";
                    this.allCount[m - 3]++;
                    if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) * -1) > this.lianCount[m - 3])
                    {
                        this.lianCount[m - 3] = Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) * -1;
                    }
                    this.gvtable.Rows[i].Cells[m].Text = Convert.ToString((int)(m - 13));
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
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) > this.maxCount[m - 3])
                    {
                        this.maxCount[m - 3] = Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text);
                    }
                }
            }
            for (int n = 0x19; n <= 0x23; n++)
            {
                if (Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text) <= 0)
                {
                    this.gvtable.Rows[i].Cells[n].CssClass = "chartBall02";
                    this.allCount[n - 3]++;
                    if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text) * -1) > this.lianCount[n - 3])
                    {
                        this.lianCount[n - 3] = Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text) * -1;
                    }
                    this.gvtable.Rows[i].Cells[n].Text = Convert.ToString((int)(n - 0x18));
                }
                else
                {
                    if (this.gvtable.Rows[i].Cells[n].Text.Length >= 3)
                    {
                        this.gvtable.Rows[i].Cells[n].CssClass = "yl01 cfont_small";
                    }
                    else
                    {
                        this.gvtable.Rows[i].Cells[n].CssClass = "yl01";
                    }
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text) > this.maxCount[n - 3])
                    {
                        this.maxCount[n - 3] = Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text);
                    }
                }
            }
        }
        for (int j = 0; j < 0x21; j++)
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
        for (int i = 0; i <= 10; i++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(i + 1)) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int j = 0; j <= 10; j++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(j + 1)) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int k = 0; k <= 10; k++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(k + 1)) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选2</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int m = 0; m <= 10; m++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(m + 1)) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int n = 0; n <= 10; n++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(n + 1)) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num6 = 0; num6 <= 10; num6++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num6 + 1)) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选3</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num7 = 0; num7 <= 10; num7++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num7 + 1)) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num8 = 0; num8 <= 10; num8++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num8 + 1)) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num9 = 0; num9 <= 10; num9++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num9 + 1)) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选4</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num10 = 0; num10 <= 10; num10++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num10 + 1)) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num11 = 0; num11 <= 10; num11++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num11 + 1)) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num12 = 0; num12 <= 10; num12++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num12 + 1)) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选5</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num13 = 0; num13 <= 10; num13++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num13 + 1)) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num14 = 0; num14 <= 10; num14++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num14 + 1)) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num15 = 0; num15 <= 10; num15++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString((int)(num15 + 1)) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>出现总次数</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num16 = 0; num16 < 0x21; num16++)
        {
            if (this.allCount[num16].ToString().Length >= 3)
            {
                output.Write("<td class='cfont_small'>" + this.allCount[num16].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.allCount[num16].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>平均遗漏值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num17 = 0; num17 < 0x21; num17++)
        {
            if (this.avgCount[num17].ToString().Length >= 3)
            {
                output.Write("<td class='cfont_small'>" + this.avgCount[num17].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.avgCount[num17].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>最大遗漏值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num18 = 0; num18 < 0x21; num18++)
        {
            if (this.maxCount[num18].ToString().Length >= 3)
            {
                output.Write("<td class='cfont_small'>" + this.maxCount[num18].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.maxCount[num18].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>最大连出值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num19 = 0; num19 < 0x21; num19++)
        {
            if (this.lianCount[num19].ToString().Length >= 3)
            {
                output.Write("<td class='cfont_small'>" + this.lianCount[num19].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.lianCount[num19].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr class= 'thbg01' >");
        output.Write("<td rowspan='2' class='td_bg'   width='80px' align='middle'  > &nbsp;</td>");
        output.Write("<td rowspan='2' class='cfont1 td_bg' colSpan='2'  >开奖号码</td>");
        for (int num20 = 1; num20 <= 11; num20++)
        {
            output.Write("<TD width=25><STRONG>" + num20.ToString() + "</STRONG></TD>");
        }
        for (int num21 = 1; num21 <= 11; num21++)
        {
            output.Write("<TD width=25><STRONG>" + num21.ToString() + "</STRONG></TD>");
        }
        for (int num22 = 1; num22 <= 11; num22++)
        {
            output.Write("<TD width=25><STRONG>" + num22.ToString() + "</STRONG></TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write(" <td colspan='12'><strong>两码混合分布图</strong></td>");
        output.Write("<td colspan='12'><strong>第一个号码</strong></td>");
        output.Write("<td colspan='13'><strong>第二个号码</strong></td>");
        output.Write("</tr  >");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td width='80' rowspan='2' align='center' ><strong>期号</strong></td>");
        output.Write("<td rowspan='2' class='cfont1'  colSpan='2'  >开奖号码</td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write(" <td colspan='11'><strong>两码混合分布图</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='11'><strong>第一个号码</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='11'><strong>第二个号码</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<tr class= 'thbg01' >");
        for (int i = 1; i <= 11; i++)
        {
            output.Write("<TD width=25><STRONG>" + i.ToString() + "</STRONG></TD>");
        }
        for (int j = 1; j <= 11; j++)
        {
            output.Write("<TD width=25><STRONG>" + j.ToString() + "</STRONG></TD>");
        }
        for (int k = 1; k <= 11; k++)
        {
            output.Write("<TD width=25><STRONG>" + k.ToString() + "</STRONG></TD>");
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
        DataTable table = new TheadChart().SYDJ_Q2FBT(DaySpan, Type, ref returnValue, ref returnDescription);
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

