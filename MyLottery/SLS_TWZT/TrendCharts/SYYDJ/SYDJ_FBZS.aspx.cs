using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class DefaultFB : TrendChartPageBase, IRequiresSessionState
{
    private int[] allCount = new int[0x1d];
    private int[] avgCount = new int[0x1d];
    private int dtcount;
    private int[] lianCount = new int[0x1d];
    private int[] maxCount = new int[0x1d];

    private void ColorBind()
    {
        try
        {
            for (int i = 0; i < this.gvtable.Rows.Count; i++)
            {
                for (int k = 6; k <= 0x10; k++)
                {
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) <= 0)
                    {
                        this.gvtable.Rows[i].Cells[k].CssClass = "chartBall04";
                        this.allCount[k - 6]++;
                        if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1) > this.lianCount[k - 6])
                        {
                            this.lianCount[k - 6] = Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1;
                        }
                        this.gvtable.Rows[i].Cells[k].Text = Convert.ToString((int)(k - 5));
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
                for (int m = 0x11; m <= 0x16; m++)
                {
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) <= 0)
                    {
                        this.gvtable.Rows[i].Cells[m].CssClass = "cbg4";
                        this.allCount[m - 6]++;
                        if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) * -1) > this.lianCount[m - 6])
                        {
                            this.lianCount[m - 6] = Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) * -1;
                        }
                        this.gvtable.Rows[i].Cells[m].Text = Convert.ToString((int)(m - 0x11));
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
                for (int n = 0x17; n <= 0x1c; n++)
                {
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text) <= 0)
                    {
                        this.gvtable.Rows[i].Cells[n].CssClass = "cbg5";
                        this.allCount[n - 6]++;
                        if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text) * -1) > this.lianCount[n - 6])
                        {
                            this.lianCount[n - 6] = Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text) * -1;
                        }
                        this.gvtable.Rows[i].Cells[n].Text = Convert.ToString((int)(n - 0x17));
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
                        if (Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text) > this.maxCount[n - 6])
                        {
                            this.maxCount[n - 6] = Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text);
                        }
                    }
                }
                for (int num5 = 0x1d; num5 <= 0x22; num5++)
                {
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[num5].Text) <= 0)
                    {
                        this.gvtable.Rows[i].Cells[num5].CssClass = "cbg4";
                        this.allCount[num5 - 6]++;
                        if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[num5].Text) * -1) > this.lianCount[num5 - 6])
                        {
                            this.lianCount[num5 - 6] = Convert.ToInt32(this.gvtable.Rows[i].Cells[num5].Text) * -1;
                        }
                        this.gvtable.Rows[i].Cells[num5].Text = Convert.ToString((int)(num5 - 0x1d));
                    }
                    else
                    {
                        if (this.gvtable.Rows[i].Cells[num5].Text.Length >= 3)
                        {
                            this.gvtable.Rows[i].Cells[num5].CssClass = "yl01 cfont_small";
                        }
                        else
                        {
                            this.gvtable.Rows[i].Cells[num5].CssClass = "yl01";
                        }
                        if (Convert.ToInt32(this.gvtable.Rows[i].Cells[num5].Text) > this.maxCount[num5 - 6])
                        {
                            this.maxCount[num5 - 6] = Convert.ToInt32(this.gvtable.Rows[i].Cells[num5].Text);
                        }
                    }
                }
            }
            for (int j = 0; j < 0x1d; j++)
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
            new Log("System").Write("SYDJ_FBZS.aspx" + exception.Message + " 页面异常");
        }
    }

    private void DataBind(int DaySpan, int Type)
    {
        int returnValue = 0;
        string returnDescription = "";
        DataTable table = new TheadChart().SYDJ_FBZS(DaySpan, Type, ref returnValue, ref returnDescription);
        this.dtcount = table.Rows.Count + 13;
        this.gvtable.DataSource = table;
        this.gvtable.DataBind();
    }

    protected void ddlSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        int num = Convert.ToInt32(this.ddlSelect.Items[this.ddlSelect.SelectedIndex].Value);
        this.DataBind(num - 1, 1);
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
        for (int i = 0; i < 11; i++)
        {
            output.Write("<td onClick=ShowImg(this," + Convert.ToString((int)(i + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int j = 0; j < 6; j++)
        {
            output.Write("<td onClick=ShowImg(this," + j.ToString() + ",2)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int k = 0; k < 6; k++)
        {
            output.Write("<td onClick=ShowImg(this," + k.ToString() + ",3)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int m = 0; m < 6; m++)
        {
            output.Write("<td onClick=ShowImg(this," + m.ToString() + ",2)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选2</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int n = 0; n < 11; n++)
        {
            output.Write("<td onClick=ShowImg(this," + Convert.ToString((int)(n + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int num6 = 0; num6 < 6; num6++)
        {
            output.Write("<td onClick=ShowImg(this," + num6.ToString() + ",2)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int num7 = 0; num7 < 6; num7++)
        {
            output.Write("<td onClick=ShowImg(this," + num7.ToString() + ",3)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int num8 = 0; num8 < 6; num8++)
        {
            output.Write("<td onClick=ShowImg(this," + num8.ToString() + ",2)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选3</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num9 = 0; num9 < 11; num9++)
        {
            output.Write("<td onClick=ShowImg(this," + Convert.ToString((int)(num9 + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int num10 = 0; num10 < 6; num10++)
        {
            output.Write("<td onClick=ShowImg(this," + num10.ToString() + ",2)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int num11 = 0; num11 < 6; num11++)
        {
            output.Write("<td onClick=ShowImg(this," + num11.ToString() + ",3)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int num12 = 0; num12 < 6; num12++)
        {
            output.Write("<td onClick=ShowImg(this," + num12.ToString() + ",2)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选4</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num13 = 0; num13 < 11; num13++)
        {
            output.Write("<td onClick=ShowImg(this," + Convert.ToString((int)(num13 + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int num14 = 0; num14 < 6; num14++)
        {
            output.Write("<td onClick=ShowImg(this," + num14.ToString() + ",2)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int num15 = 0; num15 < 6; num15++)
        {
            output.Write("<td onClick=ShowImg(this," + num15.ToString() + ",3)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int num16 = 0; num16 < 6; num16++)
        {
            output.Write("<td onClick=ShowImg(this," + num16.ToString() + ",2)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选5</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num17 = 0; num17 < 11; num17++)
        {
            output.Write("<td onClick=ShowImg(this," + Convert.ToString((int)(num17 + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int num18 = 0; num18 < 6; num18++)
        {
            output.Write("<td onClick=ShowImg(this," + num18.ToString() + ",2)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int num19 = 0; num19 < 6; num19++)
        {
            output.Write("<td onClick=ShowImg(this," + num19.ToString() + ",3)  style='cursor:pointer;'>&nbsp;</td>");
        }
        for (int num20 = 0; num20 < 6; num20++)
        {
            output.Write("<td onClick=ShowImg(this," + num20.ToString() + ",2)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>出现总次数</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num21 = 0; num21 < 0x1d; num21++)
        {
            if (this.allCount[num21].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.allCount[num21].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.allCount[num21].ToString() + "</td>");
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
        for (int num22 = 0; num22 < 0x1d; num22++)
        {
            if (this.avgCount[num22].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.avgCount[num22].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.avgCount[num22].ToString() + "</td>");
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
        for (int num23 = 0; num23 < 0x1d; num23++)
        {
            if (this.maxCount[num23].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.maxCount[num23].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.maxCount[num23].ToString() + "</td>");
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
        for (int num24 = 0; num24 < 0x1d; num24++)
        {
            if (this.lianCount[num24].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.lianCount[num24].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.lianCount[num24].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr class= 'thbg01' >");
        output.Write("<td rowspan='2' class='td_bg'   width='80px' align='middle'  > &nbsp;</td>");
        output.Write("<td rowspan='2' class='cfont1 td_bg'  rowSpan='2' colSpan='5'  >开奖号码</td>");
        output.Write("<TD width=26><STRONG>1</STRONG></TD>");
        output.Write("<TD width=26><STRONG>2</STRONG></TD>");
        output.Write("<TD width=26><STRONG>3</STRONG></TD>");
        output.Write("<TD width=26><STRONG>4</STRONG></TD>");
        output.Write("<TD width=26><STRONG>5</STRONG></TD>");
        output.Write("<TD width=26><STRONG>6</STRONG></TD>");
        output.Write("<TD width=26><STRONG>7</STRONG></TD>");
        output.Write("<TD width=26><STRONG>8</STRONG></TD>");
        output.Write("<TD width=26><STRONG>9</STRONG></TD>");
        output.Write("<TD width=26><STRONG>10</STRONG></TD>");
        output.Write("<TD width=26><STRONG>11</STRONG></TD>");
        output.Write("<TD width=26><STRONG>0</STRONG></TD>");
        output.Write("<TD width=26><STRONG>1</STRONG></TD>");
        output.Write("<TD width=26><STRONG>2</STRONG></TD>");
        output.Write("<TD width=26><STRONG>3</STRONG></TD>");
        output.Write("<TD width=26><STRONG>4</STRONG></TD>");
        output.Write("<TD width=26><STRONG>5</STRONG></TD>");
        output.Write("<TD width=26><STRONG>0</STRONG></TD>");
        output.Write("<TD width=26><STRONG>1</STRONG></TD>");
        output.Write("<TD width=26><STRONG>2</STRONG></TD>");
        output.Write("<TD width=26><STRONG>3</STRONG></TD>");
        output.Write("<TD width=26><STRONG>4</STRONG></TD>");
        output.Write("<TD width=26><STRONG>5</STRONG></TD>");
        output.Write("<TD width=26><STRONG>0</STRONG></TD>");
        output.Write("<TD width=26><STRONG>1</STRONG></TD>");
        output.Write("<TD width=26><STRONG>2</STRONG></TD>");
        output.Write("<TD width=26><STRONG>3</STRONG></TD>");
        output.Write("<TD width=26><STRONG>4</STRONG></TD>");
        output.Write("<TD width=26><STRONG>5</STRONG></TD>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<TD colSpan=12><STRONG>开奖号码分布图</STRONG></TD>");
        output.Write("<TD colSpan=7><STRONG>奇数个数遗漏 </STRONG></TD>");
        output.Write("<TD colSpan=7><STRONG>小数个数遗漏 </STRONG></TD>");
        output.Write("<TD colSpan=7><STRONG>质数个数遗漏 </STRONG></TD>");
        output.Write("</tr  >");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'  width='80px' align='middle'  >期号</td>");
        output.Write("<td rowspan='2' class='cfont1' rowSpan='2' colSpan='5'  >开奖号码</td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<TD colSpan=11><STRONG>开奖号码分布图</STRONG></TD>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<TD colSpan=6><STRONG>奇数个数遗漏 </STRONG></TD>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<TD colSpan=6><STRONG>小数个数遗漏 </STRONG></TD>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<TD colSpan=6><STRONG>质数个数遗漏 </STRONG></TD>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<tr class= 'thbg01' >");
        output.Write("<TD width=26><STRONG>1</STRONG></TD>");
        output.Write("<TD width=26><STRONG>2</STRONG></TD>");
        output.Write("<TD width=26><STRONG>3</STRONG></TD>");
        output.Write("<TD width=26><STRONG>4</STRONG></TD>");
        output.Write("<TD width=26><STRONG>5</STRONG></TD>");
        output.Write("<TD width=26><STRONG>6</STRONG></TD>");
        output.Write("<TD width=26><STRONG>7</STRONG></TD>");
        output.Write("<TD width=26><STRONG>8</STRONG></TD>");
        output.Write("<TD width=26><STRONG>9</STRONG></TD>");
        output.Write("<TD width=26><STRONG>10</STRONG></TD>");
        output.Write("<TD width=26><STRONG>11</STRONG></TD>");
        output.Write("<TD width=26><STRONG>0</STRONG></TD>");
        output.Write("<TD width=26><STRONG>1</STRONG></TD>");
        output.Write("<TD width=26><STRONG>2</STRONG></TD>");
        output.Write("<TD width=26><STRONG>3</STRONG></TD>");
        output.Write("<TD width=26><STRONG>4</STRONG></TD>");
        output.Write("<TD width=26><STRONG>5</STRONG></TD>");
        output.Write("<TD width=26><STRONG>0</STRONG></TD>");
        output.Write("<TD width=26><STRONG>1</STRONG></TD>");
        output.Write("<TD width=26><STRONG>2</STRONG></TD>");
        output.Write("<TD width=26><STRONG>3</STRONG></TD>");
        output.Write("<TD width=26><STRONG>4</STRONG></TD>");
        output.Write("<TD width=26><STRONG>5</STRONG></TD>");
        output.Write("<TD width=26><STRONG>0</STRONG></TD>");
        output.Write("<TD width=26><STRONG>1</STRONG></TD>");
        output.Write("<TD width=26><STRONG>2</STRONG></TD>");
        output.Write("<TD width=26><STRONG>3</STRONG></TD>");
        output.Write("<TD width=26><STRONG>4</STRONG></TD>");
        output.Write("<TD width=26><STRONG>5</STRONG></TD>");
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
        this.DataBind(1, 0);
        this.ColorBind();
    }

    protected void lbtnToday_Click(object sender, EventArgs e)
    {
        this.DataBind(0, 0);
        this.ColorBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.DataBind(1, 1);
            this.ColorBind();
        }
    }
}

