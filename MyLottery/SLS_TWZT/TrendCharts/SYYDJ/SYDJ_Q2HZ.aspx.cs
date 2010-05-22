using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default2HZ : TrendChartPageBase, IRequiresSessionState
{
    private int[] allCount = new int[0x2d];
    private int[] avgCount = new int[0x2d];
    private int dtcount;
    private int[] lianCount = new int[0x2d];
    private int[] maxCount = new int[0x2d];

    private void ColorBind()
    {
        for (int i = 0; i < this.gvtable.Rows.Count; i++)
        {
            for (int k = 3; k <= 0x2f; k++)
            {
                try
                {
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) <= 0)
                    {
                        this.allCount[k - 3]++;
                        if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1) > this.lianCount[k - 3])
                        {
                            this.lianCount[k - 3] = Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1;
                        }
                        if (k <= 0x15)
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "chartBall04";
                            this.gvtable.Rows[i].Cells[k].Text = Convert.ToString(k);
                        }
                        if ((k > 0x15) && (k <= 0x1f))
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "cbg4";
                            this.gvtable.Rows[i].Cells[k].Text = Convert.ToString((int)(k - 0x16));
                        }
                        if ((k >= 0x20) && (k <= 0x22))
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "cbg8";
                            this.gvtable.Rows[i].Cells[k].Text = Convert.ToString((int)(k - 0x20));
                        }
                        if ((k >= 0x23) && (k <= 0x26))
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "cbg4";
                            this.gvtable.Rows[i].Cells[k].Text = Convert.ToString((int)(k - 0x23));
                        }
                        if ((k >= 0x27) && (k <= 0x2b))
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "cbg8";
                            this.gvtable.Rows[i].Cells[k].Text = Convert.ToString((int)(k - 0x27));
                        }
                        if (k == 0x2c)
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "cbg4";
                            this.gvtable.Rows[i].Cells[k].Text = "大";
                        }
                        if (k == 0x2d)
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "cbg8";
                            this.gvtable.Rows[i].Cells[k].Text = "小";
                        }
                        if (k == 0x2e)
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "cbg4";
                            this.gvtable.Rows[i].Cells[k].Text = "奇";
                        }
                        if (k == 0x2f)
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "cbg8";
                            this.gvtable.Rows[i].Cells[k].Text = "偶";
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
                        if (Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) > this.maxCount[k - 3])
                        {
                            this.maxCount[k - 3] = Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text);
                        }
                    }
                }
                catch (Exception exception)
                {
                    new Log("System").Write("SYDJ_Q2HZ.aspx" + exception.Message + " 页面异常");
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
        for (int i = 3; i <= 0x15; i++)
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
        for (int m = 0; m <= 3; m++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(m) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int n = 0; n <= 4; n++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(n) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<TD onClick=ShowImg(this,'大',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选2</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num6 = 3; num6 <= 0x15; num6++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num6) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num7 = 0; num7 <= 9; num7++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num7) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num8 = 0; num8 <= 2; num8++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num8) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num9 = 0; num9 <= 3; num9++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num9) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num10 = 0; num10 <= 4; num10++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num10) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<TD onClick=ShowImg(this,'大',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选3</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num11 = 3; num11 <= 0x15; num11++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num11) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num12 = 0; num12 <= 9; num12++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num12) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num13 = 0; num13 <= 2; num13++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num13) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num14 = 0; num14 <= 3; num14++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num14) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num15 = 0; num15 <= 4; num15++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num15) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<TD onClick=ShowImg(this,'大',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选4</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num16 = 3; num16 <= 0x15; num16++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num16) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num17 = 0; num17 <= 9; num17++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num17) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num18 = 0; num18 <= 2; num18++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num18) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num19 = 0; num19 <= 3; num19++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num19) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num20 = 0; num20 <= 4; num20++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num20) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<TD onClick=ShowImg(this,'大',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选5</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num21 = 3; num21 <= 0x15; num21++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num21) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num22 = 0; num22 <= 9; num22++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num22) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num23 = 0; num23 <= 2; num23++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num23) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num24 = 0; num24 <= 3; num24++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num24) + ",2)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        for (int num25 = 0; num25 <= 4; num25++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(num25) + ",3)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<TD onClick=ShowImg(this,'大',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>出现总次数</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num26 = 0; num26 < 0x2d; num26++)
        {
            if (this.allCount[num26].ToString().Length >= 3)
            {
                output.Write("<td class='cfont_small'>" + this.allCount[num26].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.allCount[num26].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>平均遗漏值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num27 = 0; num27 < 0x2d; num27++)
        {
            if (this.avgCount[num27].ToString().Length >= 3)
            {
                output.Write("<td class='cfont_small'>" + this.avgCount[num27].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.avgCount[num27].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>最大遗漏值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num28 = 0; num28 < 0x2d; num28++)
        {
            if (this.maxCount[num28].ToString().Length >= 3)
            {
                output.Write("<td class='cfont_small'>" + this.maxCount[num28].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.maxCount[num28].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>最大连出值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num29 = 0; num29 < 0x2d; num29++)
        {
            if (this.lianCount[num29].ToString().Length >= 3)
            {
                output.Write("<td class='cfont_small'>" + this.lianCount[num29].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.lianCount[num29].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr class= 'thbg01' >");
        output.Write("<td rowspan='2' class='td_bg'   width='80px' align='middle'  > &nbsp;</td>");
        output.Write("<td rowspan='2' class='cfont1 td_bg' colSpan='2'  >开奖号码</td>");
        for (int num30 = 3; num30 <= 0x15; num30++)
        {
            output.Write("<TD width=17><STRONG>" + num30.ToString() + "</STRONG></TD>");
        }
        for (int num31 = 0; num31 <= 9; num31++)
        {
            output.Write("<TD width=18><STRONG>" + num31.ToString() + "</STRONG></TD>");
        }
        for (int num32 = 0; num32 < 3; num32++)
        {
            output.Write("<TD width=18><STRONG>" + num32.ToString() + "</STRONG></TD>");
        }
        for (int num33 = 0; num33 < 4; num33++)
        {
            output.Write("<TD width=18><STRONG>" + num33.ToString() + "</STRONG></TD>");
        }
        for (int num34 = 0; num34 < 5; num34++)
        {
            output.Write("<TD width=18><STRONG>" + num34.ToString() + "</STRONG></TD>");
        }
        output.Write("<TD width=25><STRONG>大</STRONG></TD>");
        output.Write("<TD width=25><STRONG>小</STRONG></TD>");
        output.Write("<TD width=25><STRONG>奇</STRONG></TD>");
        output.Write("<TD width=25><STRONG>偶</STRONG></TD>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td colspan='19'><strong>和值</strong></td>");
        output.Write("<td colspan='10'><strong>和尾</strong></td>");
        output.Write("<td colspan='3'><strong>除3余数</strong></td>");
        output.Write("<td colspan='4'><strong>除4余数</strong></td>");
        output.Write("<td colspan='5'><strong>除5余数</strong></td>");
        output.Write("<td colspan='2'><strong>大小</strong></td>");
        output.Write("<td colspan='2'><strong>奇偶</strong></td>");
        output.Write("</tr  >");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td width='80' rowspan='2' align='center' ><strong>期号</strong></td>");
        output.Write("<td rowspan='2' class='cfont1'  colSpan='2'  >开奖号码</td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='19'><strong>和值</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='10'><strong>和尾</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='3'><strong>除3余数</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='4'><strong>除4余数</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='5'><strong>除5余数</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='2'><strong>大小</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='2'><strong>奇偶</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<tr class= 'thbg01' >");
        for (int i = 3; i <= 0x15; i++)
        {
            output.Write("<TD width=17><STRONG>" + i.ToString() + "</STRONG></TD>");
        }
        for (int j = 0; j <= 9; j++)
        {
            output.Write("<TD width=18><STRONG>" + j.ToString() + "</STRONG></TD>");
        }
        for (int k = 0; k < 3; k++)
        {
            output.Write("<TD width=18><STRONG>" + k.ToString() + "</STRONG></TD>");
        }
        for (int m = 0; m < 4; m++)
        {
            output.Write("<TD width=18><STRONG>" + m.ToString() + "</STRONG></TD>");
        }
        for (int n = 0; n < 5; n++)
        {
            output.Write("<TD width=18><STRONG>" + n.ToString() + "</STRONG></TD>");
        }
        output.Write("<TD width=25><STRONG>大</STRONG></TD>");
        output.Write("<TD width=25><STRONG>小</STRONG></TD>");
        output.Write("<TD width=25><STRONG>奇</STRONG></TD>");
        output.Write("<TD width=25><STRONG>偶</STRONG></TD>");
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
        DataTable table = new TheadChart().SYDJ_Q2HZ(DaySpan, Type, ref returnValue, ref returnDescription);
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

