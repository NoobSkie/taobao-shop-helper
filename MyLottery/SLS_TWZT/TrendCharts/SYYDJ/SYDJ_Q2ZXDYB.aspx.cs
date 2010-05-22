using ASP;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class DefaultQ2Z : TrendChartPageBase, IRequiresSessionState
{
    private int[] allCount = new int[0x13];
    private int[] avgCount = new int[0x13];
    private int dtcount;
    private int[] lianCount = new int[0x13];
    private int[] maxCount = new int[0x13];

    private void ColorBind()
    {
        for (int i = 0; i < this.gvtable.Rows.Count; i++)
        {
            for (int k = 4; k <= 0x16; k++)
            {
                if (Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) <= 0)
                {
                    this.allCount[k - 4]++;
                    if ((Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1) > this.lianCount[k - 4])
                    {
                        this.lianCount[k - 4] = Convert.ToInt32(this.gvtable.Rows[i].Cells[k].Text) * -1;
                    }
                    if (Convert.ToInt32(this.gvtable.Rows[i].Cells[1].Text) > Convert.ToInt32(this.gvtable.Rows[i].Cells[2].Text))
                    {
                        this.gvtable.Rows[i].Cells[k].CssClass = "cbg4";
                    }
                    else
                    {
                        this.gvtable.Rows[i].Cells[k].CssClass = "cbg5";
                    }
                    this.gvtable.Rows[i].Cells[k].Text = this.gvtable.Rows[i].Cells[1].Text + "&nbsp;" + this.gvtable.Rows[i].Cells[2].Text;
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
        }
        for (int j = 0; j < 0x13; j++)
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
        output.Write("<td  height='36px'>出现总次数  </td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int i = 0; i < 0x13; i++)
        {
            if (this.allCount[i].ToString().Length >= 3)
            {
                output.Write("<td class='cfont_small'>" + this.allCount[i].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.allCount[i].ToString() + "</td>");
            }
        }
        output.Write("<tr  >");
        output.Write("<td  height='36px'>平均遗漏值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int j = 0; j < 0x13; j++)
        {
            if (this.avgCount[j].ToString().Length >= 3)
            {
                output.Write("<td class='cfont_small'>" + this.avgCount[j].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.avgCount[j].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>最大遗漏值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int k = 0; k < 0x13; k++)
        {
            if (this.maxCount[k].ToString().Length >= 3)
            {
                output.Write("<td class='cfont_small'>" + this.maxCount[k].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.maxCount[k].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td  height='36px'>最大连出值</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        output.Write("<td >&nbsp;</td>");
        for (int m = 0; m < 0x13; m++)
        {
            if (this.lianCount[m].ToString().Length >= 3)
            {
                output.Write("<td class='cfont_small'>" + this.lianCount[m].ToString() + "</td>");
            }
            else
            {
                output.Write("<td >" + this.lianCount[m].ToString() + "</td>");
            }
        }
        output.Write("</tr  >");
        output.Write("<tr class= 'thbg01' >");
        output.Write("<td rowspan='6' class='td_bg'   width='80px' align='middle'  > &nbsp;</td>");
        output.Write("<td rowspan='6' class='cfont1 td_bg' colSpan='2'  >开奖号码</td>");
        output.Write("<td width='35' rowspan='6' class='cbg1' style='background:#EFF7FE' ><strong>和值</strong></td>");
        for (int n = 3; n <= 0x15; n++)
        {
            output.Write("<TD width=44><STRONG>" + n.ToString() + "</STRONG></TD>");
        }
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td height='19'>01  02</td>");
        output.Write("<td>01 03</td>");
        output.Write("<td>01 04</td>");
        output.Write("<td>01 05</td>");
        output.Write("<td>01 06</td>");
        output.Write("<td>01 07</td>");
        output.Write("<td>01 08</td>");
        output.Write("<td>01 09</td>");
        output.Write("<td>01 10</td>");
        output.Write("<td>01 11</td>");
        output.Write("<td>02 11</td>");
        output.Write("<td>03 11</td>");
        output.Write("<td>04 11</td>");
        output.Write("<td>05 11</td>");
        output.Write("<td>07 10</td>");
        output.Write("<td>07 11</td>");
        output.Write("<td>08 11</td>");
        output.Write("<td>09 11</td>");
        output.Write("<td>10 11</td>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td height='19'>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td height='15'>02 03</td>");
        output.Write("<td>02 04</td>");
        output.Write("<td>02 05</td>");
        output.Write("<td>02 06</td>");
        output.Write("<td>02 07</td>");
        output.Write("<td>02 08</td>");
        output.Write("<td>02 09</td>");
        output.Write("<td>02 10</td>");
        output.Write("<td>03 10</td>");
        output.Write("<td>04 10</td>");
        output.Write("<td>05 10</td>");
        output.Write("<td>06 10</td>");
        output.Write("<td>08 09</td>");
        output.Write("<td>08 10</td>");
        output.Write("<td>09 10</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td height='19'>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td height='15'>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>03 04</td>");
        output.Write("<td>03 05</td>");
        output.Write("<td>03 06</td>");
        output.Write("<td>03 07</td>");
        output.Write("<td>03 08</td>");
        output.Write("<td>03 09</td>");
        output.Write("<td>04 09</td>");
        output.Write("<td>05 09</td>");
        output.Write("<td>06 09</td>");
        output.Write("<td>07 09</td>");
        output.Write("<td>06 11</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td height='19'>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td height='15'>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td height='15'>04 05</td>");
        output.Write("<td>04 06</td>");
        output.Write("<td>04 07</td>");
        output.Write("<td>04 08</td>");
        output.Write("<td>05 08</td>");
        output.Write("<td>06 08</td>");
        output.Write("<td>07 08</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("</tr  >");
        output.Write("<tr  >");
        output.Write("<td height='19'>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td height='15'>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td height='15'>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>05 06</td>");
        output.Write("<td>05 07</td>");
        output.Write("<td>06 07</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        output.Write("</tr  >");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td width='80' rowspan='2' align='center' ><strong>期号</strong></td>");
        output.Write("<td rowspan='2' class='cfont1'  colSpan='2'  >开奖号码</td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<td width='35' rowspan='2'  class='cbg1 '><strong>和值</strong></td>");
        output.Write("<td colspan='19'><strong>前二组选和值</strong></td>");
        output.Write("<TD style='BACKGROUND: #ccc' rowspan = " + this.dtcount.ToString() + " width=2>&nbsp;</TD>");
        output.Write("<tr class= 'thbg01' >");
        for (int i = 3; i <= 0x15; i++)
        {
            output.Write("<TD ><STRONG>" + i.ToString() + "</STRONG></TD>");
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
            e.Row.Cells[3].CssClass = "cbg1";
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
        DataTable table = new TheadChart().SYDJ_Q2ZXDYB(DaySpan, Type, ref returnValue, ref returnDescription);
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

