using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_TrendCharts_C15X5_C15X5_ZHZST : TrendChartPageBase, IRequiresSessionState
{

    private void BindDataForAD()
    {
        this.lbAd.Text = "&nbsp;";
        string key = "Advertisements";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_Advertisements().Open("", "isShow=1", "");
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
            {
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 600);
        }
        DataRow[] rowArray = cacheAsDataTable.Select("LotteryID=59 and [Name] = '广告一'", "[Order]");
        DataRow[] rowArray2 = cacheAsDataTable.Select("LotteryID=59 and [Name] = '广告二'", "[Order]");
        DataRow[] rowArray3 = cacheAsDataTable.Select("LotteryID=59 and [Name] = '广告三'", "[Order]");
        if (rowArray.Length >= 1)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<div id='icefable1'>").AppendLine("<table width='200' border='0' cellpadding='0' cellspacing='0'>").AppendLine("<tbody style='height: 20px;'>");
            foreach (DataRow row in rowArray)
            {
                string[] strArray2 = row["Title"].ToString().Split(new string[] { "Color" }, StringSplitOptions.None);
                builder.Append("<tr><td class='blue'><a style='color:").Append((strArray2.Length == 2) ? strArray2[1] : "#000000").Append(";' href=\"").Append(row["Url"].ToString()).Append("\" target='_blank'>").Append(strArray2[0]).AppendLine("</a></td></tr>");
            }
            builder.AppendLine("</tbody>").AppendLine("</table>").AppendLine("</div>").AppendLine("<script type='text/jscript' language='javascript'>").AppendLine("marqueesHeight=20;").AppendLine("stopscroll=false;").AppendLine("with(icefable1){").AppendLine("style.height=marqueesHeight;").AppendLine("style.overflowX='visible';").AppendLine("style.overflowY='hidden';").AppendLine("noWrap=true;").AppendLine("onmouseover=new Function('stopscroll=true');").AppendLine("onmouseout=new Function('stopscroll=false');").AppendLine("}").AppendLine("preTop=0; currentTop=marqueesHeight; stoptime=0;").AppendLine("icefable1.innerHTML+=icefable1.innerHTML;").AppendLine("").AppendLine("function init_srolltext(){").AppendLine("icefable1.scrollTop=0;").AppendLine("scrollUpInterval = setInterval('scrollUp()',1);").AppendLine("}").AppendLine("").AppendLine("function scrollUp(){").AppendLine("if(stopscroll==true) return;").AppendLine("currentTop+=1;").AppendLine("if(currentTop==marqueesHeight+1)").AppendLine("{").AppendLine("stoptime+=1;").AppendLine("currentTop-=1;").AppendLine("if(stoptime==300) ").AppendLine("{").AppendLine("currentTop=0;").AppendLine("stoptime=0;  \t\t").AppendLine("}").AppendLine("}").AppendLine("else {  \t").AppendLine("preTop=icefable1.scrollTop;").AppendLine("icefable1.scrollTop+=1;").AppendLine("if(preTop==icefable1.scrollTop){").AppendLine("icefable1.scrollTop=marqueesHeight;").AppendLine("icefable1.scrollTop+=1;").AppendLine("}").AppendLine("}").AppendLine("}").AppendLine("init_srolltext();");
            if (rowArray.Length == 1)
            {
                builder.AppendLine("clearInterval(scrollUpInterval);");
            }
            builder.AppendLine("</script>");
            this.lbAd.Text = builder.ToString();
            builder = new StringBuilder();
            if (rowArray2.Length > 0)
            {
                builder.AppendLine("<div id='icefable2'>").AppendLine("<table width='100%' border='0' cellpadding='0' cellspacing='0'>").AppendLine("<tbody style='height: 20px;'>");
                foreach (DataRow row2 in rowArray2)
                {
                    string[] strArray4 = row2["Title"].ToString().Split(new string[] { "Color" }, StringSplitOptions.None);
                    builder.Append("<tr><td class='blue'><a style='color:").Append((strArray4.Length == 2) ? strArray4[1] : "#000000").Append(";' href=\"").Append(row2["Url"].ToString()).Append("\" target='_blank'>").Append(strArray4[0]).AppendLine("</a></td></tr>");
                }
                builder.AppendLine("</tbody>").AppendLine("</table>").AppendLine("</div>").AppendLine("<script type='text/jscript' language='javascript'>").AppendLine("marqueesHeight2=20;").AppendLine("stopscroll2=false;").AppendLine("with(icefable2){").AppendLine("style.height=marqueesHeight2;").AppendLine("style.overflowX='visible';").AppendLine("style.overflowY='hidden';").AppendLine("noWrap=true;").AppendLine("onmouseover=new Function('stopscroll=true');").AppendLine("onmouseout=new Function('stopscroll=false');").AppendLine("}").AppendLine("preTop2=0; currentTop2=marqueesHeight2; stoptime2=0;").AppendLine("icefable2.innerHTML+=icefable2.innerHTML;").AppendLine("").AppendLine("function init_srolltext2(){").AppendLine("icefable2.scrollTop=0;").AppendLine("scrollUpInterval2 = setInterval('scrollUp1()',1);").AppendLine("}").AppendLine("").AppendLine("function scrollUp1(){").AppendLine("if(stopscroll2==true) return;").AppendLine("currentTop2+=1;").AppendLine("if(currentTop2==marqueesHeight2+1)").AppendLine("{").AppendLine("stoptime2+=1;").AppendLine("currentTop2-=1;").AppendLine("if(stoptime2==300) ").AppendLine("{").AppendLine("currentTop2=0;").AppendLine("stoptime2=0;  \t\t").AppendLine("}").AppendLine("}").AppendLine("else {  \t").AppendLine("preTop2=icefable2.scrollTop;").AppendLine("icefable2.scrollTop+=1;").AppendLine("if(preTop==icefable2.scrollTop){").AppendLine("icefable2.scrollTop=marqueesHeight2;").AppendLine("icefable2.scrollTop+=1;").AppendLine("}").AppendLine("}").AppendLine("}").AppendLine("init_srolltext2();");
                if (rowArray2.Length == 1)
                {
                    builder.AppendLine("clearInterval(scrollUpInterval2);");
                }
                builder.AppendLine("</script>");
            }
            this.lbAd1.Text = builder.ToString();
            builder = new StringBuilder();
            if (rowArray3.Length > 0)
            {
                builder.AppendLine("<div id='icefable3'>").AppendLine("<table width='100%' border='0' cellpadding='0' cellspacing='0'>").AppendLine("<tbody style='height: 20px;'>");
                foreach (DataRow row3 in rowArray3)
                {
                    string[] strArray6 = row3["Title"].ToString().Split(new string[] { "Color" }, StringSplitOptions.None);
                    builder.Append("<tr><td class='blue'><a style='color:").Append((strArray6.Length == 2) ? strArray6[1] : "#000000").Append(";' href=\"").Append(row3["Url"].ToString()).Append("\" target='_blank'>").Append(strArray6[0]).AppendLine("</a></td></tr>");
                }
                builder.AppendLine("</tbody>").AppendLine("</table>").AppendLine("</div>").AppendLine("").AppendLine("<script type='text/jscript' language='javascript'>").AppendLine("marqueesHeight3=20;").AppendLine("stopscroll3=false;").AppendLine("with(icefable3){").AppendLine("style.height=marqueesHeight3;").AppendLine("style.overflowX='visible';").AppendLine("style.overflowY='hidden';").AppendLine("noWrap=true;").AppendLine("onmouseover=new Function('stopscroll=true');").AppendLine("onmouseout=new Function('stopscroll=false');").AppendLine("}").AppendLine("preTop3=0; currentTop3=marqueesHeight; stoptime3=0;").AppendLine("icefable3.innerHTML+=icefable3.innerHTML;").AppendLine("").AppendLine("function init_srolltext3(){").AppendLine("icefable3.scrollTop=0;").AppendLine("scrollUpInterval3 = setInterval('scrollUp3()',1);").AppendLine("}").AppendLine("").AppendLine("function scrollUp3(){").AppendLine("if(stopscroll3==true) return;").AppendLine("currentTop3+=1;").AppendLine("if(currentTop3==marqueesHeight3+1)").AppendLine("{").AppendLine("stoptime3+=1;").AppendLine("currentTop3-=1;").AppendLine("if(stoptime3==300) ").AppendLine("{").AppendLine("currentTop3=0;").AppendLine("stoptime3=0;  \t\t").AppendLine("}").AppendLine("}").AppendLine("else {  \t").AppendLine("preTop3=icefable3.scrollTop;").AppendLine("icefable3.scrollTop+=1;").AppendLine("if(preTop3==icefable3.scrollTop){").AppendLine("icefable3.scrollTop=marqueesHeight;").AppendLine("icefable3.scrollTop+=1;").AppendLine("}").AppendLine("}").AppendLine("}").AppendLine("init_srolltext3();");
                if (rowArray3.Length == 1)
                {
                    builder.AppendLine("clearInterval(scrollUpInterval3);");
                }
                builder.AppendLine("</script>");
            }
            this.lbAd2.Text = builder.ToString();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (((this.tb1.Text == "") || (this.tb1.Text == null)) || ((this.tb2.Text == "") || (this.tb2.Text == null)))
        {
            JavaScript.Alert(this.Page, "请输入起止期数！");
        }
        int num = _Convert.StrToInt(this.tb1.Text, 0);
        int num2 = _Convert.StrToInt(this.tb2.Text, 0);
        if (num > num2)
        {
            JavaScript.Alert(this.Page, "起始期数输入有误，请查证在输入！");
        }
        else
        {
            string result = "";
            DataTable table = null;
            table = new TrendChart().C15X5_ZHZST_Select(0, this.tb1.Text.ToString(), this.tb2.Text.ToString(), ref result);
            if ((table != null) && (table.Rows.Count >= 1))
            {
                int count = table.Rows.Count;
                this.tb1.Text = table.Rows[0]["Isuse"].ToString();
                this.tb2.Text = table.Rows[count - 1]["Isuse"].ToString();
            }
            this.GridView1.DataSource = table;
            this.GridView1.DataBind();
            this.ColorBind();
        }
    }

    protected void btnTop100_Click(object sender, EventArgs e)
    {
        string result = "";
        DataTable table = new DataTable();
        table = new TrendChart().C15X5_ZHZST_Select(100, "", "", ref result);
        if ((table != null) && (table.Rows.Count >= 1))
        {
            int count = table.Rows.Count;
            this.tb1.Text = table.Rows[0]["Isuse"].ToString();
            this.tb2.Text = table.Rows[count - 1]["Isuse"].ToString();
        }
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void btnTop30_Click(object sender, EventArgs e)
    {
        string result = "";
        DataTable table = new DataTable();
        table = new TrendChart().C15X5_ZHZST_Select(30, "", "", ref result);
        if ((table != null) && (table.Rows.Count >= 1))
        {
            int count = table.Rows.Count;
            this.tb1.Text = table.Rows[0]["Isuse"].ToString();
            this.tb2.Text = table.Rows[count - 1]["Isuse"].ToString();
        }
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void btnTop50_Click(object sender, EventArgs e)
    {
        string result = "";
        DataTable table = new DataTable();
        table = new TrendChart().C15X5_ZHZST_Select(50, "", "", ref result);
        if ((table != null) && (table.Rows.Count >= 1))
        {
            int count = table.Rows.Count;
            this.tb1.Text = table.Rows[0]["Isuse"].ToString();
            this.tb2.Text = table.Rows[count - 1]["Isuse"].ToString();
        }
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
        this.ColorBind();
    }

    protected void ColorBind()
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            for (int j = 2; j < 0x1f; j++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, -2) == -1)
                {
                    this.GridView1.Rows[i].Cells[j].Text = "&nbsp;";
                }
            }
            for (int k = 2; k < 11; k++)
            {
                if ((_Convert.StrToInt(this.GridView1.Rows[i].Cells[k].Text, 0) < 10) && (_Convert.StrToInt(this.GridView1.Rows[i].Cells[k].Text, 0) > 0))
                {
                    this.GridView1.Rows[i].Cells[k].Text = "0" + this.GridView1.Rows[i].Cells[k].Text;
                }
            }
            if (this.GridView1.Rows[i].Cells[0x15].Text == "Blue|0")
            {
                this.GridView1.Rows[i].Cells[0x15].Text = "0";
                this.GridView1.Rows[i].Cells[0x15].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (this.GridView1.Rows[i].Cells[0x15].Text == "Red|0")
            {
                this.GridView1.Rows[i].Cells[0x15].Text = "0";
                this.GridView1.Rows[i].Cells[0x15].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (this.GridView1.Rows[i].Cells[0x16].Text == "Blue|1")
            {
                this.GridView1.Rows[i].Cells[0x16].Text = "1";
                this.GridView1.Rows[i].Cells[0x16].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (this.GridView1.Rows[i].Cells[0x16].Text == "Red|1")
            {
                this.GridView1.Rows[i].Cells[0x16].Text = "1";
                this.GridView1.Rows[i].Cells[0x16].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (this.GridView1.Rows[i].Cells[0x17].Text == "Blue|2")
            {
                this.GridView1.Rows[i].Cells[0x17].Text = "2";
                this.GridView1.Rows[i].Cells[0x17].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (this.GridView1.Rows[i].Cells[0x17].Text == "Red|2")
            {
                this.GridView1.Rows[i].Cells[0x17].Text = "2";
                this.GridView1.Rows[i].Cells[0x17].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (this.GridView1.Rows[i].Cells[0x18].Text == "Blue|3")
            {
                this.GridView1.Rows[i].Cells[0x18].Text = "3";
                this.GridView1.Rows[i].Cells[0x18].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (this.GridView1.Rows[i].Cells[0x18].Text == "Red|3")
            {
                this.GridView1.Rows[i].Cells[0x18].Text = "3";
                this.GridView1.Rows[i].Cells[0x18].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (this.GridView1.Rows[i].Cells[0x19].Text == "Blue|4")
            {
                this.GridView1.Rows[i].Cells[0x19].Text = "4";
                this.GridView1.Rows[i].Cells[0x19].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (this.GridView1.Rows[i].Cells[0x19].Text == "Red|4")
            {
                this.GridView1.Rows[i].Cells[0x19].Text = "4";
                this.GridView1.Rows[i].Cells[0x19].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (this.GridView1.Rows[i].Cells[0x1a].Text == "Blue|5")
            {
                this.GridView1.Rows[i].Cells[0x1a].Text = "5";
                this.GridView1.Rows[i].Cells[0x1a].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (this.GridView1.Rows[i].Cells[0x1a].Text == "Red|5")
            {
                this.GridView1.Rows[i].Cells[0x1a].Text = "5";
                this.GridView1.Rows[i].Cells[0x1a].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (this.GridView1.Rows[i].Cells[0x1b].Text == "Blue|6")
            {
                this.GridView1.Rows[i].Cells[0x1b].Text = "6";
                this.GridView1.Rows[i].Cells[0x1b].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (this.GridView1.Rows[i].Cells[0x1b].Text == "Red|6")
            {
                this.GridView1.Rows[i].Cells[0x1b].Text = "6";
                this.GridView1.Rows[i].Cells[0x1b].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (this.GridView1.Rows[i].Cells[0x1c].Text == "Blue|7")
            {
                this.GridView1.Rows[i].Cells[0x1c].Text = "7";
                this.GridView1.Rows[i].Cells[0x1c].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (this.GridView1.Rows[i].Cells[0x1c].Text == "Red|7")
            {
                this.GridView1.Rows[i].Cells[0x1c].Text = "7";
                this.GridView1.Rows[i].Cells[0x1c].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (this.GridView1.Rows[i].Cells[0x1d].Text == "Blue|8")
            {
                this.GridView1.Rows[i].Cells[0x1d].Text = "8";
                this.GridView1.Rows[i].Cells[0x1d].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (this.GridView1.Rows[i].Cells[0x1d].Text == "Red|8")
            {
                this.GridView1.Rows[i].Cells[0x1d].Text = "8";
                this.GridView1.Rows[i].Cells[0x1d].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (this.GridView1.Rows[i].Cells[30].Text == "Blue|9")
            {
                this.GridView1.Rows[i].Cells[30].Text = "9";
                this.GridView1.Rows[i].Cells[30].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (this.GridView1.Rows[i].Cells[30].Text == "Red|9")
            {
                this.GridView1.Rows[i].Cells[30].Text = "9";
                this.GridView1.Rows[i].Cells[30].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            for (int m = 0x1f; m < 0x22; m++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[m].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[m].Text = "&nbsp;";
                }
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td Height='18px'>预选1</td>");
        output.Write("<td>&nbsp;</td>");
        for (int i = 1; i < 10; i++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' align='center' valign='center'><strong>");
            output.Write(0 + i.ToString() + "</strong></span></td>");
        }
        for (int j = 10; j < 0x10; j++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' align='center' valign='center'><strong>");
            output.Write(j.ToString() + "</strong></td>");
        }
        for (int k = 0; k < 0x11; k++)
        {
            output.Write("<td>&nbsp;</td>");
        }
        output.Write("<tr align='center' valign='center' ></tr>");
        output.Write("<td align='center' valign='center' Height='18px'>预选2</td>");
        output.Write("<td>&nbsp;</td>");
        for (int m = 1; m < 10; m++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' align='center' valign='center'><strong>");
            output.Write(0 + m.ToString() + "</strong></span></td>");
        }
        for (int n = 10; n < 0x10; n++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' align='center' valign='center'><strong>");
            output.Write(n.ToString() + "</strong></td>");
        }
        for (int num6 = 0; num6 < 0x11; num6++)
        {
            output.Write("<td>&nbsp;</td>");
        }
        output.Write("<tr align='center' valign='center' ></tr>");
        output.Write("<td align='center' valign='center' Height='18px'>预选3</td>");
        output.Write("<td>&nbsp;</td>");
        for (int num7 = 1; num7 < 10; num7++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' align='center' valign='center'><strong>");
            output.Write(0 + num7.ToString() + "</strong></span></td>");
        }
        for (int num8 = 10; num8 < 0x10; num8++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' align='center' valign='center'><strong>");
            output.Write(num8.ToString() + "</strong></td>");
        }
        for (int num9 = 0; num9 < 0x11; num9++)
        {
            output.Write("<td>&nbsp;</td>");
        }
        output.Write("<tr align='center' valign='center' bgcolor='#e8f1f8'>");
        output.Write("<td rowspan='2'　align='center' valign='middle' bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td rowspan='2'　align='center' valign='middle' bgcolor='#e8f1f8'>开奖号码</td>");
        for (int num10 = 1; num10 < 10; num10++)
        {
            output.Write("<td bgcolor='#e8f1f8' height='18px'>");
            output.Write(0 + num10.ToString() + "</td>");
        }
        for (int num11 = 10; num11 < 0x10; num11++)
        {
            output.Write("<td bgcolor='#e8f1f8'>");
            output.Write(num11.ToString() + "</td>");
        }
        output.Write("<td rowspan='2' bgcolor='#e8f1f8'>重号</td>");
        output.Write("<td rowspan='2' bgcolor='#e8f1f8'>连号</td>");
        output.Write("<td rowspan='2' bgcolor='#e8f1f8'>总和</td>");
        output.Write("<td rowspan='2' bgcolor='#e8f1f8'>奇偶比</td>");
        for (int num12 = 0; num12 < 10; num12++)
        {
            output.Write("<td bgcolor='#e8f1f8' height='18px'>");
            output.Write(num12.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#e8f1f8'>一</td>");
        output.Write("<td  bgcolor='#e8f1f8'>二</td>");
        output.Write("<td bgcolor='#e8f1f8'>三</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8'>");
        output.Write("<td colspan='5' height='18px'>一区</td>");
        output.Write("<td colspan='5'>二区</td>");
        output.Write("<td colspan='5'>三区</td>");
        output.Write("<td colspan='10'　align='center' valign='middle' bgcolor='#e8f1f8'>个位分布</td>");
        output.Write("<td colspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>区间分布</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'　align='center' valign='middle' bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td rowspan='2'　align='center' valign='middle' bgcolor='#e8f1f8'>开奖号码</td>");
        output.Write("<td colspan='5' height='18px' bgcolor='#e8f1f8'>一区</td>");
        output.Write("<td colspan='5' bgcolor='#e8f1f8'>二区</td>");
        output.Write("<td colspan='5' bgcolor='#e8f1f8'>三区</td>");
        output.Write("<td rowspan='2' bgcolor='#e8f1f8'>重号</td>");
        output.Write("<td rowspan='2' bgcolor='#e8f1f8'>连号</td>");
        output.Write("<td rowspan='2' bgcolor='#e8f1f8'>总和</td>");
        output.Write("<td rowspan='2' bgcolor='#e8f1f8'>奇偶比</td>");
        output.Write("<td colspan='10'　align='center' valign='middle' bgcolor='#e8f1f8'>个位分布</td>");
        output.Write("<td colspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>区间分布</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8'>");
        for (int i = 1; i < 10; i++)
        {
            output.Write("<td bgcolor='#e8f1f8' height='18px'>");
            output.Write(0 + i.ToString() + "</td>");
        }
        for (int j = 10; j < 0x10; j++)
        {
            output.Write("<td bgcolor='#e8f1f8'>");
            output.Write(j.ToString() + "</td>");
        }
        for (int k = 0; k < 10; k++)
        {
            output.Write("<td bgcolor='#e8f1f8' height='18px'>");
            output.Write(k.ToString() + "</td>");
        }
        output.Write("<td bgcolor='#e8f1f8'>一</td>");
        output.Write("<td  bgcolor='#e8f1f8'>二</td>");
        output.Write("<td  bgcolor='#e8f1f8'>三</td>");
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

    protected void GridViewBind()
    {
        string result = "";
        DataTable table = new DataTable();
        table = new TrendChart().C15X5_ZHZST_Select(30, "", "", ref result);
        if ((table != null) && (table.Rows.Count >= 1))
        {
            int count = table.Rows.Count;
            this.tb1.Text = table.Rows[0]["Isuse"].ToString();
            this.tb2.Text = table.Rows[count - 1]["Isuse"].ToString();
        }
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.GridViewBind();
            this.ColorBind();
            this.GridView1.Style["border-collapse"] = "";
            this.BindDataForAD();
        }
    }
}

