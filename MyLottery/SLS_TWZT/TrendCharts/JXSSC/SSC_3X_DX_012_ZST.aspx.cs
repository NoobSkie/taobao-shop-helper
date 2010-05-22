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

public partial class Home_TrendCharts_JXSSC_SSC_3X_DX_012_ZST : TrendChartPageBase, IRequiresSessionState
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
            table = new TrendChart().SSC_3X_DX_012_ZST_Select(0, this.tb1.Text.ToString(), this.tb2.Text.ToString(), ref result);
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
        table = new TrendChart().SSC_3X_DX_012_ZST_Select(100, "", "", ref result);
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
        table = new TrendChart().SSC_3X_DX_012_ZST_Select(30, "", "", ref result);
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
        table = new TrendChart().SSC_3X_DX_012_ZST_Select(50, "", "", ref result);
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
                    Text = this.GridView1.Rows[i].Cells[1].Text.Substring(0, 2) + "<font color='red'>" + this.GridView1.Rows[i].Cells[1].Text.Substring(2, 3) + "</font>"
                };
                this.GridView1.Rows[i].Cells[1].Controls.Add(child);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[3].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[3].Text = "000";
                this.GridView1.Rows[i].Cells[3].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[3].Font.Bold = true;
                this.GridView1.Rows[i].Cells[3].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[4].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[4].Text = "001";
                this.GridView1.Rows[i].Cells[4].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[4].Font.Bold = true;
                this.GridView1.Rows[i].Cells[4].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[5].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[5].Text = "002";
                this.GridView1.Rows[i].Cells[5].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[5].Font.Bold = true;
                this.GridView1.Rows[i].Cells[5].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[6].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[6].Text = "010";
                this.GridView1.Rows[i].Cells[6].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[6].Font.Bold = true;
                this.GridView1.Rows[i].Cells[6].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[7].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[7].Text = "011";
                this.GridView1.Rows[i].Cells[7].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[7].Font.Bold = true;
                this.GridView1.Rows[i].Cells[7].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[8].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[8].Text = "012";
                this.GridView1.Rows[i].Cells[8].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[8].Font.Bold = true;
                this.GridView1.Rows[i].Cells[8].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[9].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[9].Text = "020";
                this.GridView1.Rows[i].Cells[9].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[9].Font.Bold = true;
                this.GridView1.Rows[i].Cells[9].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[10].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[10].Text = "021";
                this.GridView1.Rows[i].Cells[10].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[10].Font.Bold = true;
                this.GridView1.Rows[i].Cells[10].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[11].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[11].Text = "022";
                this.GridView1.Rows[i].Cells[11].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[11].Font.Bold = true;
                this.GridView1.Rows[i].Cells[11].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[12].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[12].Text = "100";
                this.GridView1.Rows[i].Cells[12].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[12].Font.Bold = true;
                this.GridView1.Rows[i].Cells[12].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[13].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[13].Text = "101";
                this.GridView1.Rows[i].Cells[13].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[13].Font.Bold = true;
                this.GridView1.Rows[i].Cells[13].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[14].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[14].Text = "102";
                this.GridView1.Rows[i].Cells[14].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[14].Font.Bold = true;
                this.GridView1.Rows[i].Cells[14].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[15].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[15].Text = "110";
                this.GridView1.Rows[i].Cells[15].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[15].Font.Bold = true;
                this.GridView1.Rows[i].Cells[15].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x10].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x10].Text = "111";
                this.GridView1.Rows[i].Cells[0x10].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x10].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x10].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x11].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x11].Text = "112";
                this.GridView1.Rows[i].Cells[0x11].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x11].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x11].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x12].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x12].Text = "120";
                this.GridView1.Rows[i].Cells[0x12].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x12].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x12].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x13].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x13].Text = "121";
                this.GridView1.Rows[i].Cells[0x13].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x13].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x13].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[20].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[20].Text = "122";
                this.GridView1.Rows[i].Cells[20].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[20].Font.Bold = true;
                this.GridView1.Rows[i].Cells[20].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x15].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x15].Text = "200";
                this.GridView1.Rows[i].Cells[0x15].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x15].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x15].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x16].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x16].Text = "201";
                this.GridView1.Rows[i].Cells[0x16].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x16].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x16].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x17].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x17].Text = "202";
                this.GridView1.Rows[i].Cells[0x17].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x17].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x17].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x18].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x18].Text = "210";
                this.GridView1.Rows[i].Cells[0x18].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x18].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x18].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x19].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x19].Text = "211";
                this.GridView1.Rows[i].Cells[0x19].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x19].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x19].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1a].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x1a].Text = "212";
                this.GridView1.Rows[i].Cells[0x1a].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x1a].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x1a].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1b].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x1b].Text = "220";
                this.GridView1.Rows[i].Cells[0x1b].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x1b].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x1b].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1c].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x1c].Text = "221";
                this.GridView1.Rows[i].Cells[0x1c].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x1c].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x1c].Style.Value = "background-color:Red";
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1d].Text, 0) == 0)
            {
                this.GridView1.Rows[i].Cells[0x1d].Text = "222";
                this.GridView1.Rows[i].Cells[0x1d].ForeColor = Color.FromArgb(0xff, 0xff, 0xff);
                this.GridView1.Rows[i].Cells[0x1d].Font.Bold = true;
                this.GridView1.Rows[i].Cells[0x1d].Style.Value = "background-color:Red";
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2' colspan='2'　align='center' valign='middle'  bgcolor='#FFFFFF'>预测行</td>");
        for (int i = 0; i < 2; i++)
        {
            if (i == 1)
            {
                output.Write("<tr align='center' valign='middle'>");
            }
            output.Write("<td 　align='center' valign='middle' bgcolor='#FFFFFF' height='20px'>&nbsp;</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>000</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>001</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>002</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>010</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>011</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>012</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>020</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>021</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>022</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>100</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>101</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>102</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>110</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>111</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>112</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>120</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>121</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>122</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>200</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>201</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>202</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>210</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>211</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>212</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>220</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>221</td>");
            output.Write("<td 　align='center' valign='middle' bgcolor='#fdfcdf' onClick=Style1(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>222</td>");
        }
        output.Write("<tr align='center' valign='middle' >");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'><b>期号</b></td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'><b>奖号</b></td>");
        output.Write("<td rowspan='2'　 bgcolor='#E8F1F8'><b>类型</b></td>");
        output.Write("<td 　bgcolor='#F7F7F7' height='20'><b>000</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>001</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>002</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>010</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>011</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>012</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>020</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>021</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>022</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>100</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>101</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>102</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>110</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>111</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>112</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>120</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>121</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>122</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>200</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>201</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>202</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>210</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>211</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>212</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>220</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>221</b></td>");
        output.Write("<td 　 bgcolor='#F7F7F7'><b>222</b></td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#E8F1F8'>");
        output.Write("<td colspan='27'　 bgcolor='#E8F1F8' height='20px'><b>012路</b></td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'　align='center' valign='middle' bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td rowspan='2'　align='center' valign='middle' bgcolor='#e8f1f8'>奖号</td>");
        output.Write("<td rowspan='2'　align='center' valign='middle' bgcolor='#e8f1f8'>类型</td>");
        output.Write("<td colspan='27'　align='center' valign='middle' bgcolor='#e8f1f8' height='20'>012路</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#f7f7f7'>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7' height='20px'><b>000</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>001</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>002</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>010</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>011</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>012</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>020</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>021</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>022</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>100</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>101</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>102</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>110</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>111</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>112</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>120</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>121</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>122</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>200</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>201</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>202</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>210</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>211</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>212</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>220</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>221</b></td>");
        output.Write("<td 　align='center' valign='middle' bgcolor='#f7f7f7'><b>222</b></td>");
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
        table = new TrendChart().SSC_3X_DX_012_ZST_Select(30, "", "", ref result);
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

