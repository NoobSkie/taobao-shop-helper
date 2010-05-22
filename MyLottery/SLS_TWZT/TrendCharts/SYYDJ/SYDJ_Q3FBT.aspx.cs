using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Default3FB : TrendChartPageBase, IRequiresSessionState
{
    private int[] allCount = new int[0x1b];
    private int[] avgCount = new int[0x1b];
    private int dtcount;
    private int[] lianCount = new int[0x1b];
    private int[] maxCount = new int[0x1b];


    private void ColorBind()
    {
        for (int i = 0; i < this.gvtable.Rows.Count; i++)
        {
            for (int k = 4; k <= 30; k++)
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
                        if (k <= 14)
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "chartBall04";
                            this.gvtable.Rows[i].Cells[k].Text = Convert.ToString((int)(k - 3));
                        }
                        if ((k > 14) && (k <= 0x16))
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "cbg4";
                            switch (k)
                            {
                                case 15:
                                    this.gvtable.Rows[i].Cells[k].Text = "奇奇奇";
                                    break;

                                case 0x10:
                                    this.gvtable.Rows[i].Cells[k].Text = "奇奇偶";
                                    break;

                                case 0x11:
                                    this.gvtable.Rows[i].Cells[k].Text = "奇偶奇";
                                    break;

                                case 0x12:
                                    this.gvtable.Rows[i].Cells[k].Text = "偶奇奇";
                                    break;

                                case 0x13:
                                    this.gvtable.Rows[i].Cells[k].Text = "奇偶偶";
                                    break;

                                case 20:
                                    this.gvtable.Rows[i].Cells[k].Text = "偶奇偶";
                                    break;

                                case 0x15:
                                    this.gvtable.Rows[i].Cells[k].Text = "偶偶奇";
                                    break;

                                case 0x16:
                                    this.gvtable.Rows[i].Cells[k].Text = "偶偶偶";
                                    break;
                            }
                        }
                        if ((k >= 0x17) && (k <= 30))
                        {
                            this.gvtable.Rows[i].Cells[k].CssClass = "cbg8";
                            switch (k)
                            {
                                case 0x17:
                                    {
                                        this.gvtable.Rows[i].Cells[k].Text = "小小小";
                                        continue;
                                    }
                                case 0x18:
                                    {
                                        this.gvtable.Rows[i].Cells[k].Text = "小小大";
                                        continue;
                                    }
                                case 0x19:
                                    {
                                        this.gvtable.Rows[i].Cells[k].Text = "小大小";
                                        continue;
                                    }
                                case 0x1a:
                                    {
                                        this.gvtable.Rows[i].Cells[k].Text = "大小小";
                                        continue;
                                    }
                                case 0x1b:
                                    {
                                        this.gvtable.Rows[i].Cells[k].Text = "小大大";
                                        continue;
                                    }
                                case 0x1c:
                                    {
                                        this.gvtable.Rows[i].Cells[k].Text = "大小大";
                                        continue;
                                    }
                                case 0x1d:
                                    {
                                        this.gvtable.Rows[i].Cells[k].Text = "大大小";
                                        continue;
                                    }
                                case 30:
                                    {
                                        this.gvtable.Rows[i].Cells[k].Text = "大大大";
                                        continue;
                                    }
                            }
                        }
                        continue;
                    }
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
                catch (Exception exception)
                {
                    new Log("System").Write("SYDJ_Q3FBT.aspx" + exception.Message + " 页面异常");
                }
            }
        }
        for (int j = 0; j < 0x1b; j++)
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
        for (int i = 1; i <= 11; i++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(i) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<TD onClick=ShowImg(this,'奇奇奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇奇偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇偶奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶奇奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇偶偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶奇偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶偶奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶偶偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小小小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小小大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小大小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大小小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小大大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大小大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大大小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大大大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选2</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int j = 1; j <= 11; j++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(j) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<TD onClick=ShowImg(this,'奇奇奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇奇偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇偶奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶奇奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇偶偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶奇偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶偶奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶偶偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小小小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小小大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小大小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大小小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小大大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大小大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大大小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大大大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选3</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int k = 1; k <= 11; k++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(k) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<TD onClick=ShowImg(this,'奇奇奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇奇偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇偶奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶奇奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇偶偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶奇偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶偶奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶偶偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小小小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小小大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小大小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大小小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小大大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大小大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大大小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大大大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选4</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int m = 1; m <= 11; m++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(m) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<TD onClick=ShowImg(this,'奇奇奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇奇偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇偶奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶奇奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇偶偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶奇偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶偶奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶偶偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小小小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小小大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小大小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大小小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小大大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大小大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大大小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大大大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>预选5</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int n = 1; n <= 11; n++)
        {
            output.Write("<TD onClick=ShowImg(this," + Convert.ToString(n) + ",4)  style='cursor:pointer;'>&nbsp;</TD>");
        }
        output.Write("<TD onClick=ShowImg(this,'奇奇奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇奇偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇偶奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶奇奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'奇偶偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶奇偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶偶奇',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'偶偶偶',5) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小小小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小小大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小大小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大小小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'小大大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大小大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大大小',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("<TD onClick=ShowImg(this,'大大大',6) style='cursor:pointer;'>&nbsp;</TD>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>出现总次数</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num6 = 0; num6 < 0x1b; num6++)
        {
            if (this.allCount[num6].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.allCount[num6].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.allCount[num6].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>平均遗漏值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num7 = 0; num7 < 0x1b; num7++)
        {
            if (this.avgCount[num7].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.avgCount[num7].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.avgCount[num7].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>最大遗漏值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num8 = 0; num8 < 0x1b; num8++)
        {
            if (this.maxCount[num8].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.maxCount[num8].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.maxCount[num8].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>最大连出值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int num9 = 0; num9 < 0x1b; num9++)
        {
            if (this.lianCount[num9].ToString().Length >= 3)
            {
                output.Write("<td class ='cfont_small'>" + this.lianCount[num9].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.lianCount[num9].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr class= 'thbg01' >");
        output.Write("<td rowspan='2' class='td_bg' align='middle'  > &nbsp;</td>");
        output.Write("<td rowspan='2' class='cfont1 td_bg' colSpan='3'  >开奖号码</td>");
        for (int num10 = 1; num10 <= 11; num10++)
        {
            output.Write("<TD width=20>" + num10.ToString() + "</TD>");
        }
        output.Write("<td height='15' >奇奇奇</td>");
        output.Write("<td  >奇奇偶</td>");
        output.Write("<td  >奇偶奇</td>");
        output.Write("<td  >偶奇奇</td>");
        output.Write("<td  >奇偶偶</td>");
        output.Write("<td  >偶奇偶</td>");
        output.Write("<td  >偶偶奇</td>");
        output.Write("<td  >偶偶偶</td>");
        output.Write("<td  height='15' >小小小</td>");
        output.Write("<td  >小小大</td>");
        output.Write("<td  >小大小</td>");
        output.Write("<td  >大小小</td>");
        output.Write("<td  >小大大</td>");
        output.Write("<td  >大小大</td>");
        output.Write("<td  >大大小</td>");
        output.Write("<td  >大大大</td>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td colspan='11'><strong>开奖号码分布图</strong></td>");
        output.Write("<td colspan='8'><strong>奇偶组合</strong></td>");
        output.Write("<td colspan='8'><strong>大小组合</strong></td>");
        output.Write("</tr  >");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td  rowspan='2' align='center' ><strong>期号</strong></td>");
        output.Write("<td rowspan='2' class='cfont1'  colSpan='3'  >开奖号码</td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='11'><strong>开奖号码分布图</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='8'><strong>奇偶组合</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td colspan='8'><strong>大小组合</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<tr class= 'thbg01' >");
        for (int i = 1; i <= 11; i++)
        {
            output.Write("<TD width=20> " + i.ToString() + "</TD>");
        }
        output.Write("<td  >奇奇奇</td>");
        output.Write("<td  >奇奇偶</td>");
        output.Write("<td  >奇偶奇</td>");
        output.Write("<td  >偶奇奇</td>");
        output.Write("<td  >奇偶偶</td>");
        output.Write("<td  >偶奇偶</td>");
        output.Write("<td  >偶偶奇</td>");
        output.Write("<td  >偶偶偶</td>");
        output.Write("<td height='15' >小小小</td>");
        output.Write("<td  >小小大</td>");
        output.Write("<td  >小大小</td>");
        output.Write("<td  >大小小</td>");
        output.Write("<td  >小大大</td>");
        output.Write("<td  >大小大</td>");
        output.Write("<td  >大大小</td>");
        output.Write("<td  >大大大</td>");
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
        DataTable table = new TheadChart().SYDJ_Q3FBT(DaySpan, Type, ref returnValue, ref returnDescription);
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

