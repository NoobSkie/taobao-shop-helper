using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default3HZ : TrendChartPageBase, IRequiresSessionState
{
    private int[] allCount = new int[0x26];
    private int[] avgCount = new int[0x26];
    private int dtcount;
    private int[] lianCount = new int[0x26];
    private int[] maxCount = new int[0x26];

    private void ColorBind()
    {
        for (int i = 0; i < this.gvtable.Rows.Count; i++)
        {
            for (int k = 4; k <= 0x29; k++)
            {
                try
                {
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) <= 0)
                    {
                        this.allCount[k - 4]++;
                        if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1) > this.lianCount[k - 4])
                        {
                            this.lianCount[k - 4] = Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1;
                        }
                        if (k <= 0x1c)
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "chartBall04";
                            this.gvtable.Rows[i].Cells[k].Text = Convert.ToString((int)(k + 2));
                        }
                        if ((k > 0x1c) && (k <= 0x26))
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "cbg4";
                            this.gvtable.Rows[i].Cells[k].Text = Convert.ToString((int)(k - 0x1d));
                        }
                        if ((k >= 0x27) && (k <= 0x29))
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "cbg8";
                            this.gvtable.Rows[i].Cells[k].Text = Convert.ToString((int)(k - 0x27));
                        }
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
                        if (Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) > this.maxCount[k - 4])
                        {
                            this.maxCount[k - 4] = Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text);
                        }
                    }
                }
                catch (Exception exception)
                {
                    new Log("System").Write("SYDJ_Q3HZT.aspx" + exception.Message + " 页面异常");
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
        output.Write("<td >&nbsp;</td>");
        for (int i = 6; i <= 30; i++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(i) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int j = 0; j <= 9; j++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(j) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int k = 0; k <= 2; k++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(k) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选2</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int m = 6; m <= 30; m++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(m) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int n = 0; n <= 9; n++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(n) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num6 = 0; num6 <= 2; num6++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num6) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选3</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num7 = 6; num7 <= 30; num7++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num7) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num8 = 0; num8 <= 9; num8++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num8) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num9 = 0; num9 <= 2; num9++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num9) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选4</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num10 = 6; num10 <= 30; num10++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num10) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num11 = 0; num11 <= 9; num11++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num11) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num12 = 0; num12 <= 2; num12++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num12) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选5</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num13 = 6; num13 <= 30; num13++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num13) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num14 = 0; num14 <= 9; num14++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num14) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num15 = 0; num15 <= 2; num15++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num15) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>出现总次数</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num16 = 0; num16 < 0x26; num16++)
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
        output.Write("<td >&nbsp;</td>");
        for (int num17 = 0; num17 < 0x26; num17++)
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
        output.Write("<td >&nbsp;</td>");
        for (int num18 = 0; num18 < 0x26; num18++)
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
        output.Write("<td >&nbsp;</td>");
        for (int num19 = 0; num19 < 0x26; num19++)
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
        output.Write("<td rowspan='2' class='cfont1 td_bg' colSpan='3'  >开奖号码</td>");
        for (int num20 = 6; num20 <= 30; num20++)
        {
            output.Write("<TD width=21><STRONG>" + num20.ToString() + "</STRONG></TD>");
        }
        for (int num21 = 0; num21 <= 9; num21++)
        {
            output.Write("<TD width=21><STRONG>" + num21.ToString() + "</STRONG></TD>");
        }
        for (int num22 = 0; num22 < 3; num22++)
        {
            output.Write("<TD width=21><STRONG>" + num22.ToString() + "</STRONG></TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td colspan='25'><strong>和值</strong></td>");
        output.Write("<td colspan='10'><strong>和尾</strong></td>");
        output.Write("<td colspan='3'><strong>除3余数</strong></td>");
        output.Write("</tr  >");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td width='80' rowspan='2' align='center' ><strong>期号</strong></td>");
        output.Write("<td rowspan='2' class='cfont1'  colSpan='3'  >开奖号码</td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='25'><strong>和值</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='10'><strong>和尾</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='3'><strong>除3余数</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<tr class= 'thbg01' >");
        for (int i = 6; i <= 30; i++)
        {
            output.Write("<TD width=21><STRONG>" + i.ToString() + "</STRONG></TD>");
        }
        for (int j = 0; j <= 9; j++)
        {
            output.Write("<TD width=21><STRONG>" + j.ToString() + "</STRONG></TD>");
        }
        for (int k = 0; k < 3; k++)
        {
            output.Write("<TD width=21><STRONG>" + k.ToString() + "</STRONG></TD>");
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
        DataTable table = new TheadChart().SYDJ_Q3HZT(DaySpan, Type, ref returnValue, ref returnDescription);
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

