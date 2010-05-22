using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _Default : TrendChartPageBase, IRequiresSessionState
{
    private int[] allCount = new int[0x18];
    private int[] avgCount = new int[0x18];
    private int dtcount;
    private int[] lianCount = new int[0x18];
    private int[] maxCount = new int[0x18];
    private static int WeiSpan = 1;
    private static int WeiType = 1;

    private void ColorBind()
    {
        for (int i = 0; i < this.gvtable.Rows.Count; i++)
        {
            for (int k = 1; k <= 11; k++)
            {
                if (Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) <= 0)
                {
                    this.gvtable.Rows[i].Cells[k].CssClass = "chartBall01";
                    this.allCount[k - 1]++;
                    if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1) > this.lianCount[k - 1])
                    {
                        this.lianCount[k - 1] = Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1;
                    }
                    this.gvtable.Rows[i].Cells[k].Text = Convert.ToString(k);
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
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) > this.maxCount[k - 1])
                    {
                        this.maxCount[k - 1] = Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text);
                    }
                }
            }
            for (int m = 12; m <= 0x11; m++)
            {
                if (Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) <= 0)
                {
                    this.gvtable.Rows[i].Cells[m].CssClass = "cbg4";
                    this.allCount[m - 1]++;
                    if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) * -1) > this.lianCount[m - 1])
                    {
                        this.lianCount[m - 1] = Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) * -1;
                    }
                    if (m == 12)
                    {
                        this.gvtable.Rows[i].Cells[m].Text = "小奇质";
                    }
                    if (m == 13)
                    {
                        this.gvtable.Rows[i].Cells[m].Text = "小偶质";
                    }
                    if (m == 14)
                    {
                        this.gvtable.Rows[i].Cells[m].Text = "小偶合";
                    }
                    if (m == 15)
                    {
                        this.gvtable.Rows[i].Cells[m].Text = "大奇质";
                    }
                    if (m == 0x10)
                    {
                        this.gvtable.Rows[i].Cells[m].Text = "大奇合";
                    }
                    if (m == 0x11)
                    {
                        this.gvtable.Rows[i].Cells[m].Text = "大偶合";
                    }
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
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text) > this.maxCount[m - 1])
                    {
                        this.maxCount[m - 1] = Convert.ToInt32(this.gvtable.Rows[i].Cells[m].Text);
                    }
                }
            }
            for (int n = 0x12; n <= 20; n++)
            {
                if (Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text) <= 0)
                {
                    this.gvtable.Rows[i].Cells[n].CssClass = "cbg3";
                    this.allCount[n - 1]++;
                    if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text) * -1) > this.lianCount[n - 1])
                    {
                        this.lianCount[n - 1] = Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text) * -1;
                    }
                    this.gvtable.Rows[i].Cells[n].Text = Convert.ToString((int)(n - 0x12));
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
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text) > this.maxCount[n - 1])
                    {
                        this.maxCount[n - 1] = Convert.ToInt32(this.gvtable.Rows[i].Cells[n].Text);
                    }
                }
            }
            for (int num5 = 0x15; num5 <= 0x18; num5++)
            {
                try
                {
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[num5].Text) <= 0)
                    {
                        this.gvtable.Rows[i].Cells[num5].CssClass = "cbg1";
                        this.allCount[num5 - 1]++;
                        if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[num5].Text) * -1) > this.lianCount[num5 - 1])
                        {
                            this.lianCount[num5 - 1] = Convert.ToInt32(this.gvtable.Rows[i].Cells[num5].Text) * -1;
                        }
                        switch (num5)
                        {
                            case 0x15:
                                {
                                    this.gvtable.Rows[i].Cells[num5].Text = "重";
                                    continue;
                                }
                            case 0x16:
                                {
                                    this.gvtable.Rows[i].Cells[num5].Text = "邻";
                                    continue;
                                }
                            case 0x17:
                                {
                                    this.gvtable.Rows[i].Cells[num5].Text = "间";
                                    continue;
                                }
                            case 0x18:
                                {
                                    this.gvtable.Rows[i].Cells[num5].Text = "孤";
                                    continue;
                                }
                        }
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
                        if (Convert.ToInt32(this.gvtable.Rows[i].Cells[num5].Text) > this.maxCount[num5 - 1])
                        {
                            this.maxCount[num5 - 1] = Convert.ToInt32(this.gvtable.Rows[i].Cells[num5].Text);
                        }
                    }
                }
                catch (Exception exception)
                {
                    new Log("System").Write("SYDJ_DWZS.aspx" + exception.Message + " 页面异常");
                }
            }
        }
        for (int j = 0; j < 0x18; j++)
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

    protected void ddlNearDay_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void ddlSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        int num = Convert.ToInt32(this.ddlSelect.Items[this.ddlSelect.SelectedIndex].Value);
        WeiSpan = num - 1;
        WeiType = 1;
        this.MyDataBind(num - 1, 1, 1);
        this.ColorBind();
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td  height='36px'>预选1</td>");
        for (int i = 0; i < 11; i++)
        {
            output.Write("<td onClick=ShowImg(this," + Convert.ToString((int)(i + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("<td onClick=ShowImg(this,'小奇质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'小偶质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'小偶合',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大奇质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大奇合',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大偶合',2)  style='cursor:pointer;'>&nbsp;</td>");
        for (int j = 0; j < 3; j++)
        {
            output.Write("<td onClick=ShowImg(this," + j.ToString() + ",3)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("<td onClick=ShowImg(this,'重',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'邻',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'间',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'孤',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选2</td>");
        for (int k = 0; k < 11; k++)
        {
            output.Write("<td onClick=ShowImg(this," + Convert.ToString((int)(k + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("<td onClick=ShowImg(this,'小奇质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'小偶质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'小偶合',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大奇质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大奇合',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大偶合',2)  style='cursor:pointer;'>&nbsp;</td>");
        for (int m = 0; m < 3; m++)
        {
            output.Write("<td onClick=ShowImg(this," + m.ToString() + ",3)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("<td onClick=ShowImg(this,'重',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'邻',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'间',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'孤',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选3</td>");
        for (int n = 0; n < 11; n++)
        {
            output.Write("<td onClick=ShowImg(this," + Convert.ToString((int)(n + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("<td onClick=ShowImg(this,'小奇质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'小偶质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'小偶合',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大奇质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大奇合',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大偶合',2)  style='cursor:pointer;'>&nbsp;</td>");
        for (int num6 = 0; num6 < 3; num6++)
        {
            output.Write("<td onClick=ShowImg(this," + num6.ToString() + ",3)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("<td onClick=ShowImg(this,'重',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'邻',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'间',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'孤',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选4</td>");
        for (int num7 = 0; num7 < 11; num7++)
        {
            output.Write("<td onClick=ShowImg(this," + Convert.ToString((int)(num7 + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("<td onClick=ShowImg(this,'小奇质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'小偶质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'小偶合',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大奇质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大奇合',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大偶合',2)  style='cursor:pointer;'>&nbsp;</td>");
        for (int num8 = 0; num8 < 3; num8++)
        {
            output.Write("<td onClick=ShowImg(this," + num8.ToString() + ",3)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("<td onClick=ShowImg(this,'重',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'邻',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'间',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'孤',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选5</td>");
        for (int num9 = 0; num9 < 11; num9++)
        {
            output.Write("<td onClick=ShowImg(this," + Convert.ToString((int)(num9 + 1)) + ",1)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("<td onClick=ShowImg(this,'小奇质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'小偶质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'小偶合',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大奇质',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大奇合',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'大偶合',2)  style='cursor:pointer;'>&nbsp;</td>");
        for (int num10 = 0; num10 < 3; num10++)
        {
            output.Write("<td onClick=ShowImg(this," + num10.ToString() + ",3)  style='cursor:pointer;'>&nbsp;</td>");
        }
        output.Write("<td onClick=ShowImg(this,'重',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'邻',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'间',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("<td onClick=ShowImg(this,'孤',2)  style='cursor:pointer;'>&nbsp;</td>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>出现总次数</td>");
        for (int num11 = 0; num11 < 0x18; num11++)
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
        for (int num12 = 0; num12 < 0x18; num12++)
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
        for (int num13 = 0; num13 < 0x18; num13++)
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
        for (int num14 = 0; num14 < 0x18; num14++)
        {
            if (this.lianCount[num14].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.lianCount[num14].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.lianCount[num14].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<td width='80' rowspan='2' align='center'  ><strong>&nbsp;</strong></td>");
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
        output.Write("<TD width=45><STRONG>小奇质</STRONG></TD>");
        output.Write("<TD width=45><STRONG>小偶质</STRONG></TD>");
        output.Write("<TD width=45><STRONG>小偶合</STRONG></TD>");
        output.Write("<TD width=45><STRONG>大奇质</STRONG></TD>");
        output.Write("<TD width=45><STRONG>大奇合</STRONG></TD>");
        output.Write("<TD width=45><STRONG>大偶合</STRONG></TD>");
        output.Write("<TD width=45><STRONG>余0</STRONG></TD>");
        output.Write("<TD width=45><STRONG>余1</STRONG></TD>");
        output.Write("<TD width=45><STRONG>余2</STRONG></TD>");
        output.Write("<TD width=45><STRONG>重</STRONG></TD>");
        output.Write("<TD width=45><STRONG>邻</STRONG></TD>");
        output.Write("<TD width=45><STRONG>间</STRONG></TD>");
        output.Write("<TD width=45><STRONG>孤</STRONG></TD>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td colspan='12'><strong>开奖号码分布图</strong></td>");
        output.Write("<td colspan='7'><strong>数字特征</strong></td>");
        output.Write("<td colspan='4'><strong>除3余数</strong></td>");
        output.Write("<td colspan='6'><strong>重邻间孤</strong></td>");
        output.Write("</tr  >");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td width='80' rowspan='2' align='center'  ><strong>期号</strong></td>");
        output.Write("<td colspan='11'><strong>开奖号码分布图</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='6'><strong>数字特征</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='3'><strong>除3余数</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='5'><strong>重邻间孤</strong></td>");
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
        output.Write("<TD width=45><STRONG>小奇质</STRONG></TD>");
        output.Write("<TD width=45><STRONG>小偶质</STRONG></TD>");
        output.Write("<TD width=45><STRONG>小偶合</STRONG></TD>");
        output.Write("<TD width=45><STRONG>大奇质</STRONG></TD>");
        output.Write("<TD width=45><STRONG>大奇合</STRONG></TD>");
        output.Write("<TD width=45><STRONG>大偶合</STRONG></TD>");
        output.Write("<TD width=45><STRONG>余0</STRONG></TD>");
        output.Write("<TD width=45><STRONG>余1</STRONG></TD>");
        output.Write("<TD width=45><STRONG>余2</STRONG></TD>");
        output.Write("<TD width=45><STRONG>重</STRONG></TD>");
        output.Write("<TD width=45><STRONG>邻</STRONG></TD>");
        output.Write("<TD width=45><STRONG>间</STRONG></TD>");
        output.Write("<TD width=45><STRONG>孤</STRONG></TD>");
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
        DataControlRowType rowType = e.Row.RowType;
    }

    protected void lbLastDay_Click(object sender, EventArgs e)
    {
    }

    protected void lbtn1_Click(object sender, EventArgs e)
    {
        this.MyDataBind(WeiSpan, WeiType, 1);
        this.ColorBind();
    }

    protected void lbtn2_Click(object sender, EventArgs e)
    {
        this.MyDataBind(WeiSpan, WeiType, 2);
        this.ColorBind();
    }

    protected void lbtn3_Click(object sender, EventArgs e)
    {
        this.MyDataBind(WeiSpan, WeiType, 3);
        this.ColorBind();
    }

    protected void lbtn4_Click(object sender, EventArgs e)
    {
        this.MyDataBind(WeiSpan, WeiType, 4);
        this.ColorBind();
    }

    protected void lbtn5_Click(object sender, EventArgs e)
    {
        this.MyDataBind(WeiSpan, WeiType, 5);
        this.ColorBind();
    }

    protected void lbtnLast_Click(object sender, EventArgs e)
    {
        WeiSpan = 1;
        WeiType = 0;
        this.MyDataBind(1, 0, 1);
        this.ColorBind();
    }

    protected void lbtnToday_Click(object sender, EventArgs e)
    {
        WeiSpan = 0;
        WeiType = 0;
        this.MyDataBind(0, 0, 1);
        this.ColorBind();
    }

    protected void lbToday_Click(object sender, EventArgs e)
    {
    }

    private void MyDataBind(int dataSpan, int Type, int number)
    {
        int returnValue = 0;
        string returnDescription = "";
        DataTable table = new TheadChart().SYDJ_DWZS(dataSpan, Type, number, ref returnValue, ref returnDescription);
        this.dtcount = table.Rows.Count + 13;
        this.gvtable.DataSource = table;
        this.gvtable.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            this.MyDataBind(1, 1, 1);
            this.ColorBind();
        }
    }
}

