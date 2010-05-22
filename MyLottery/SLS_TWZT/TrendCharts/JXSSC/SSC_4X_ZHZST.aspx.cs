using ASP;
using DAL;
using Shove;
using Shove._Web;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_TrendCharts_JXSSC_SSC_4X_ZHZST : TrendChartPageBase, IRequiresSessionState
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
        DataRow[] rowArray = cacheAsDataTable.Select("LotteryID=61 and [Name] = '广告一'", "[Order]");
        DataRow[] rowArray2 = cacheAsDataTable.Select("LotteryID=61 and [Name] = '广告二'", "[Order]");
        DataRow[] rowArray3 = cacheAsDataTable.Select("LotteryID=61 and [Name] = '广告三'", "[Order]");
        if (rowArray.Length >= 1)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<div id='icefable1'>").AppendLine("<table width='200' border='0' cellpadding='0' cellspacing='0'>").AppendLine("<tbody style='height: 20px;'>");
            foreach (DataRow row in rowArray)
            {
                string[] strArray2 = row["Title"].ToString().Split(new string[] { "Color" }, StringSplitOptions.None);
                builder.Append("<tr><td class='blue'><a style='color:").Append((strArray2.Length == 2) ? strArray2[1] : "#000000").Append(";' href=\"").Append(row["Url"].ToString().ToLower()).Append("\" target='_blank'>").Append(strArray2[0]).AppendLine("</a></td></tr>");
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
                    builder.Append("<tr><td class='blue'><a style='color:").Append((strArray4.Length == 2) ? strArray4[1] : "#000000").Append(";' href=\"").Append(row2["Url"].ToString().ToLower()).Append("\" target='_blank'>").Append(strArray4[0]).AppendLine("</a></td></tr>");
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
                    builder.Append("<tr><td class='blue'><a style='color:").Append((strArray6.Length == 2) ? strArray6[1] : "#000000").Append(";' href=\"").Append(row3["Url"].ToString().ToLower()).Append("\" target='_blank'>").Append(strArray6[0]).AppendLine("</a></td></tr>");
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
            table = new TrendChart().SSC_4X_ZHZST_Select(0, this.tb1.Text.ToString(), this.tb2.Text.ToString(), ref result);
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
        table = new TrendChart().SSC_4X_ZHZST_Select(100, "", "", ref result);
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
        table = new TrendChart().SSC_4X_ZHZST_Select(30, "", "", ref result);
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
        table = new TrendChart().SSC_4X_ZHZST_Select(50, "", "", ref result);
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
            if (this.GridView1.Rows[i].Cells[1].Text.Length == 5)
            {
                Label child = new Label
                {
                    Text = this.GridView1.Rows[i].Cells[1].Text.Substring(0, 1) + "<font color='red'>" + this.GridView1.Rows[i].Cells[1].Text.Substring(1, 4) + "</font>"
                };
                this.GridView1.Rows[i].Cells[1].Controls.Add(child);
            }
            if (this.GridView1.Rows[i].Cells[8].Text == "0")
            {
                HtmlImage image = new HtmlImage
                {
                    Src = "../Images/blue_kong.gif"
                };
                this.GridView1.Rows[i].Cells[8].Controls.Add(image);
            }
            if (this.GridView1.Rows[i].Cells[20].Text == "0")
            {
                HtmlImage image2 = new HtmlImage
                {
                    Src = "../Images/red_kong.gif"
                };
                this.GridView1.Rows[i].Cells[20].Controls.Add(image2);
            }
            if (this.GridView1.Rows[i].Cells[14].Text == "0")
            {
                HtmlImage image3 = new HtmlImage
                {
                    Src = "../Images/orange_kong.gif"
                };
                this.GridView1.Rows[i].Cells[14].Controls.Add(image3);
            }
            if (this.GridView1.Rows[i].Cells[0x1a].Text == "0")
            {
                HtmlImage image4 = new HtmlImage
                {
                    Src = "../Images/blue_kong.gif"
                };
                this.GridView1.Rows[i].Cells[0x1a].Controls.Add(image4);
            }
            for (int j = 9; j < 12; j++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, -1) == 0)
                {
                    int num3 = j - 8;
                    HtmlImage image5 = new HtmlImage
                    {
                        Src = "../Images/blue_" + num3.ToString() + ".gif"
                    };
                    this.GridView1.Rows[i].Cells[j].Controls.Add(image5);
                }
            }
            int num4 = 12;
            for (int k = 5; num4 < 14; k += 2)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[num4].Text, -1) == 0)
                {
                    HtmlImage image6 = new HtmlImage
                    {
                        Src = "../Images/blue_" + k.ToString() + ".gif"
                    };
                    this.GridView1.Rows[i].Cells[num4].Controls.Add(image6);
                }
                num4++;
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[15].Text, -1) == 0)
            {
                HtmlImage image7 = new HtmlImage
                {
                    Src = "../Images/orange_0.gif"
                };
                this.GridView1.Rows[i].Cells[15].Controls.Add(image7);
            }
            int num6 = 0x10;
            for (int m = 4; num6 < 0x13; m += 2)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[num6].Text, 0) == 0)
                {
                    HtmlImage image8 = new HtmlImage
                    {
                        Src = "../Images/orange_" + m.ToString() + ".gif"
                    };
                    this.GridView1.Rows[i].Cells[num6].Controls.Add(image8);
                }
                num6++;
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x13].Text, 0) == 0)
            {
                HtmlImage image9 = new HtmlImage
                {
                    Src = "../Images/orange_9.gif"
                };
                this.GridView1.Rows[i].Cells[0x13].Controls.Add(image9);
            }
            int num8 = 0x15;
            for (int n = 1; num8 < 0x18; n++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[num8].Text, 0) == 0)
                {
                    HtmlImage image10 = new HtmlImage
                    {
                        Src = "../Images/red_" + n.ToString() + ".gif"
                    };
                    this.GridView1.Rows[i].Cells[num8].Controls.Add(image10);
                }
                num8++;
            }
            int num10 = 0x18;
            for (int num11 = 5; num10 < 0x1a; num11 += 2)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[num10].Text, 0) == 0)
                {
                    HtmlImage image11 = new HtmlImage
                    {
                        Src = "../Images/red_" + num11.ToString() + ".gif"
                    };
                    this.GridView1.Rows[i].Cells[num10].Controls.Add(image11);
                }
                num10++;
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1b].Text, 0) == 0)
            {
                HtmlImage image12 = new HtmlImage
                {
                    Src = "../Images/blue_0.gif"
                };
                this.GridView1.Rows[i].Cells[0x1b].Controls.Add(image12);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1f].Text, 0) == 0)
            {
                HtmlImage image13 = new HtmlImage
                {
                    Src = "../Images/blue_9.gif"
                };
                this.GridView1.Rows[i].Cells[0x1f].Controls.Add(image13);
            }
            int num12 = 0x1c;
            for (int num13 = 4; num12 < 0x1f; num13 += 2)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[num12].Text, 0) == 0)
                {
                    HtmlImage image14 = new HtmlImage
                    {
                        Src = "../Images/blue_" + num13.ToString() + ".gif"
                    };
                    this.GridView1.Rows[i].Cells[num12].Controls.Add(image14);
                }
                num12++;
            }
            if (this.GridView1.Rows[i].Cells[3].Text.Length > 1)
            {
                string str = "";
                ArrayList list = new ArrayList();
                for (int num14 = 0; num14 < this.GridView1.Rows[i].Cells[3].Text.Length; num14++)
                {
                    list.Add(this.GridView1.Rows[i].Cells[3].Text.Substring(num14, 1));
                }
                list.Sort();
                for (int num15 = 0; num15 < list.Count; num15++)
                {
                    str = str + list[num15] + ",";
                }
                this.GridView1.Rows[i].Cells[3].Text = str.Substring(0, str.Length - 1);
            }
            if (this.GridView1.Rows[i].Cells[4].Text.Length > 1)
            {
                string str2 = "";
                ArrayList list2 = new ArrayList();
                for (int num16 = 0; num16 < this.GridView1.Rows[i].Cells[4].Text.Length; num16++)
                {
                    list2.Add(this.GridView1.Rows[i].Cells[4].Text.Substring(num16, 1));
                }
                list2.Sort();
                for (int num17 = 0; num17 < list2.Count; num17++)
                {
                    str2 = str2 + list2[num17] + ",";
                }
                this.GridView1.Rows[i].Cells[4].Text = str2.Substring(0, str2.Length - 1);
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>期号</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>奖号</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>质合类型</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>质数</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>合数</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>质合比</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>质数和</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>合数和</td>");
        for (int i = 0; i < 2; i++)
        {
            output.Write("<td 　 bgcolor='#F7F7F7' height='20px'>空</td>");
            output.Write("<td 　 bgcolor='#F7F7F7'>1</td>");
            output.Write("<td 　 bgcolor='#F7F7F7'>2</td>");
            output.Write("<td 　 bgcolor='#F7F7F7'>3</td>");
            output.Write("<td 　 bgcolor='#F7F7F7'>5</td>");
            output.Write("<td 　 bgcolor='#F7F7F7'>7</td>");
            output.Write("<td 　 bgcolor='#F7F7F7'>空</td>");
            output.Write("<td 　 bgcolor='#F7F7F7'>0</td>");
            output.Write("<td 　 bgcolor='#F7F7F7'>4</td>");
            output.Write("<td 　 bgcolor='#F7F7F7'>6</td>");
            output.Write("<td 　 bgcolor='#F7F7F7'>8</td>");
            output.Write("<td 　 bgcolor='#F7F7F7' >9</td>");
        }
        output.Write("<tr  bgcolor='#E8F1F8'>");
        output.Write("<td colspan='6'　>质数最大数</td>");
        output.Write("<td colspan='6'　>合数最大数</td>");
        output.Write("<td colspan='6'>质数最小数</td>");
        output.Write("<td colspan='6'>合数最小数</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>期号</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>奖号</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>质合类型</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>质数</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>合数</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>质合比</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>质数和</td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'>合数和</td>");
        output.Write("<td colspan='6'　 bgcolor='#E8F1F8'>质数最大数</td>");
        output.Write("<td colspan='6'　 bgcolor='#E8F1F8'>合数最大数</td>");
        output.Write("<td colspan='6'　 bgcolor='#E8F1F8'>质数最小数</td>");
        output.Write("<td colspan='6'　 bgcolor='#E8F1F8' height='20'>合数最小数</td>");
        output.Write("<tr  bgcolor='#f7f7f7'>");
        for (int i = 0; i < 2; i++)
        {
            output.Write("<td 　 height='20px'>空</td>");
            output.Write("<td 　>1</td>");
            output.Write("<td 　>2</td>");
            output.Write("<td 　>3</td>");
            output.Write("<td 　>5</td>");
            output.Write("<td 　>7</td>");
            output.Write("<td 　>空</td>");
            output.Write("<td 　>0</td>");
            output.Write("<td 　>4</td>");
            output.Write("<td 　>6</td>");
            output.Write("<td 　>8</td>");
            output.Write("<td 　 >9</td>");
        }
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
        table = new TrendChart().SSC_4X_ZHZST_Select(30, "", "", ref result);
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

