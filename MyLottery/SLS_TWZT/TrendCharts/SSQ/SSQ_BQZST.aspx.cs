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

public partial class Home_TrendCharts_SSQ_SSQ_BQZST : TrendChartPageBase, IRequiresSessionState
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
        DataRow[] rowArray = cacheAsDataTable.Select("LotteryID=5 and [Name] = '广告一'", "[Order]");
        DataRow[] rowArray2 = cacheAsDataTable.Select("LotteryID=5 and [Name] = '广告二'", "[Order]");
        DataRow[] rowArray3 = cacheAsDataTable.Select("LotteryID=5 and [Name] = '广告三'", "[Order]");
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
            table = new TrendChart().SSQ_BQZH_Select(0, this.tb1.Text.ToString(), this.tb2.Text.ToString(), ref result);
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
        table = new TrendChart().SSQ_BQZH_Select(100, "", "", ref result);
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
        table = new TrendChart().SSQ_BQZH_Select(30, "", "", ref result);
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
        table = new TrendChart().SSQ_BQZH_Select(50, "", "", ref result);
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
        string str = "";
        this.lbline.Text = "<script type=\"text/javascript\">function DrawLines(){";
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            for (int j = 3; j < 0x13; j++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, 0) == 0)
                {
                    Label child = new Label();
                    string[] strArray = new string[8];
                    strArray[0] = "<strong style='color:Red' id='GridView1_ctl";
                    int num3 = i + 2;
                    strArray[1] = num3.ToString().PadLeft(2, '0');
                    strArray[2] = "_";
                    strArray[3] = i.ToString();
                    strArray[4] = "_";
                    strArray[5] = j.ToString();
                    strArray[6] = "' />";
                    strArray[7] = (j - 2).ToString();
                    child.Text = string.Concat(strArray);
                    if (str != "")
                    {
                        string text = this.lbline.Text;
                        string[] strArray2 = new string[10];
                        strArray2[0] = text;
                        strArray2[1] = "DrawLine('";
                        strArray2[2] = str;
                        strArray2[3] = "','GridView1_ctl";
                        int num5 = i + 2;
                        strArray2[4] = num5.ToString().PadLeft(2, '0');
                        strArray2[5] = "_";
                        strArray2[6] = i.ToString();
                        strArray2[7] = "_";
                        strArray2[8] = j.ToString();
                        strArray2[9] = "', 'blue');";
                        this.lbline.Text = string.Concat(strArray2);
                    }
                    this.GridView1.Rows[i].Cells[j].Controls.Add(child);
                    string[] strArray3 = new string[6];
                    strArray3[0] = "GridView1_ctl";
                    int num6 = i + 2;
                    strArray3[1] = num6.ToString().PadLeft(2, '0');
                    strArray3[2] = "_";
                    strArray3[3] = i.ToString();
                    strArray3[4] = "_";
                    strArray3[5] = j.ToString();
                    str = string.Concat(strArray3);
                }
            }
            for (int k = 0x13; k < 0x17; k++)
            {
                if (this.GridView1.Rows[i].Cells[k].Text == "0")
                {
                    this.GridView1.Rows[i].Cells[k].Text = "&nbsp;";
                }
            }
            for (int m = 0x17; m < 0x1a; m++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[m].Text, 0) == -1)
                {
                    this.GridView1.Rows[i].Cells[m].Text = "&nbsp;";
                }
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x17].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x17].Text = "◎";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x18].Text, 0) == 1)
            {
                this.GridView1.Rows[i].Cells[0x18].Text = "①";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x19].Text, 0) == 2)
            {
                this.GridView1.Rows[i].Cells[0x19].Text = "②";
            }
            for (int n = 0x1a; n < 30; n++)
            {
                int num10 = _Convert.StrToInt(this.GridView1.Rows[i].Cells[2].Text, 0);
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[n].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[n].Text = num10.ToString();
                    this.GridView1.Rows[i].Cells[n].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[n].Font.Bold = true;
                }
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[30].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[30].Text = "金";
                this.GridView1.Rows[i].Cells[30].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1f].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x1f].Text = "木";
                this.GridView1.Rows[i].Cells[0x1f].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x20].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x20].Text = "水";
                this.GridView1.Rows[i].Cells[0x20].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x21].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x21].Text = "火";
                this.GridView1.Rows[i].Cells[0x21].ForeColor = Color.FromArgb(0, 0, 0xff);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x22].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x22].Text = "土";
                this.GridView1.Rows[i].Cells[0x22].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
        }
        this.lbline.Text = this.lbline.Text + "}</script>";
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td colspan='3' rowspan='2' height='20px'>预选行</td>");
        for (int i = 1; i < 10; i++)
        {
            output.Write("<td bgcolor='#FFFFFF' height='20' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' ><strong>");
            output.Write(i.ToString() + "</strong></span></td>");
        }
        for (int j = 10; j < 0x11; j++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' ><strong>");
            output.Write(j.ToString() + "</strong></td>");
        }
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >奇</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >偶</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >质</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >合</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >0</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >1</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >2</td>");
        for (int k = 1; k < 5; k++)
        {
            output.Write("<td>&nbsp;</td>");
        }
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >金</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >木</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >水</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >火</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' >土</td>");
        output.Write("<tr  bgcolor='#e8f1f8' style='cursor:pointer;' >");
        for (int m = 1; m < 10; m++)
        {
            output.Write("<td bgcolor='#FFFFFF' height='20' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(m.ToString() + "</strong></span></td>");
        }
        for (int n = 10; n < 0x11; n++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(n.ToString() + "</strong></td>");
        }
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;' >奇</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' >偶</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;' >质</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' >合</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;' >0</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' >1</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' >2</td>");
        for (int num6 = 1; num6 < 5; num6++)
        {
            output.Write("<td bgcolor='#FFFFFF'>&nbsp;</td>");
        }
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' >金</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' >木</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' >水</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' >火</td>");
        output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' >土</td>");
        output.Write("<tr  bgcolor='#e8f1f8' >");
        output.Write("<td rowspan='2'　 >期号</td>");
        output.Write("<td  height='42px'>红球</td>");
        output.Write("<td >蓝球</td>");
        for (int num7 = 1; num7 < 10; num7++)
        {
            output.Write("<td  >");
            output.Write(0 + num7.ToString() + "</td>");
        }
        for (int num8 = 10; num8 < 0x11; num8++)
        {
            output.Write("<td >");
            output.Write(num8.ToString() + "</td>");
        }
        output.Write("<td >奇</td>");
        output.Write("<td >偶</td>");
        output.Write("<td >质</td>");
        output.Write("<td >合</td>");
        output.Write("<td >0</td>");
        output.Write("<td >1</td>");
        output.Write("<td >2</td>");
        output.Write("<td >1-4</td>");
        output.Write("<td >5-8</td>");
        output.Write("<td >9-12</td>");
        output.Write("<td >13-16</td>");
        output.Write("<td >金</td>");
        output.Write("<td >木</td>");
        output.Write("<td >水</td>");
        output.Write("<td >火</td>");
        output.Write("<td >土</td>");
        output.Write("<tr  bgcolor='#e8f1f8' >");
        output.Write("<td colspan='2'　 bgcolor='#e8f1f8'>奖号</td>");
        output.Write("<td colspan='16'　  height='28px'>蓝球分布</td>");
        output.Write("<td colspan='2'　>奇偶走势</td>");
        output.Write("<td colspan='2'　>质合走势</td>");
        output.Write("<td colspan='3'　>012路</td>");
        output.Write("<td colspan='4'　>四区分布</td>");
        output.Write("<td colspan='5'　>蓝球五行属性</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'　 bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td colspan='2'　 bgcolor='#e8f1f8'>奖号</td>");
        output.Write("<td colspan='16'　 bgcolor='#e8f1f8' height='28px'>蓝球分布</td>");
        output.Write("<td colspan='2'　 bgcolor='#e8f1f8'>奇偶走势</td>");
        output.Write("<td colspan='2'　 bgcolor='#e8f1f8'>质合走势</td>");
        output.Write("<td colspan='3'　 bgcolor='#e8f1f8'>012路</td>");
        output.Write("<td colspan='4'　 bgcolor='#e8f1f8'>四区分布</td>");
        output.Write("<td colspan='5'　 bgcolor='#e8f1f8'>蓝球五行属性</td>");
        output.Write("<tr  bgcolor='#e8f1f8' >");
        output.Write("<td  height='42px'>红球</td>");
        output.Write("<td >蓝球</td>");
        for (int i = 1; i < 10; i++)
        {
            output.Write("<td  >");
            output.Write(0 + i.ToString() + "</td>");
        }
        for (int j = 10; j < 0x11; j++)
        {
            output.Write("<td >");
            output.Write(j.ToString() + "</td>");
        }
        output.Write("<td >奇</td>");
        output.Write("<td >偶</td>");
        output.Write("<td >质</td>");
        output.Write("<td >合</td>");
        output.Write("<td >0</td>");
        output.Write("<td >1</td>");
        output.Write("<td >2</td>");
        output.Write("<td >1-4</td>");
        output.Write("<td >5-8</td>");
        output.Write("<td >9-12</td>");
        output.Write("<td >13-16</td>");
        output.Write("<td >金</td>");
        output.Write("<td >木</td>");
        output.Write("<td >水</td>");
        output.Write("<td >火</td>");
        output.Write("<td >土</td>");
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
        table = new TrendChart().SSQ_BQZH_Select(30, "", "", ref result);
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

