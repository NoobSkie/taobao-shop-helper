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

public partial class Home_TrendCharts_SHSSL_SHSSL_012 : TrendChartPageBase, IRequiresSessionState
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
        DataRow[] rowArray = cacheAsDataTable.Select("LotteryID=29 and [Name] = '广告一'", "[Order]");
        DataRow[] rowArray2 = cacheAsDataTable.Select("LotteryID=29 and [Name] = '广告二'", "[Order]");
        DataRow[] rowArray3 = cacheAsDataTable.Select("LotteryID=29 and [Name] = '广告三'", "[Order]");
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
            table = new TrendChart().SHSSL_012_Select(0, this.tb1.Text.ToString(), this.tb2.Text.ToString(), ref result);
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
        table = new TrendChart().SHSSL_012_Select(100, "", "", ref result);
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
        table = new TrendChart().SHSSL_012_Select(30, "", "", ref result);
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
        table = new TrendChart().SHSSL_012_Select(50, "", "", ref result);
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
            for (int j = 2; j < 7; j++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[j].Text = (j - 3).ToString();
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[j].Font.Bold = true;
                }
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, 0) == -1)
                {
                    this.GridView1.Rows[i].Cells[j].Text = "&nbsp;";
                }
            }
            for (int k = 7; k < 12; k++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[k].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[k].Text = (k - 8).ToString();
                    this.GridView1.Rows[i].Cells[k].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[k].Font.Bold = true;
                }
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[k].Text, 0) == -1)
                {
                    this.GridView1.Rows[i].Cells[k].Text = "&nbsp;";
                }
            }
            for (int m = 12; m < 0x11; m++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[m].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[m].Text = (m - 13).ToString();
                    this.GridView1.Rows[i].Cells[m].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[m].Font.Bold = true;
                }
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[m].Text, 0) == -1)
                {
                    this.GridView1.Rows[i].Cells[m].Text = "&nbsp;";
                }
            }
            for (int n = 0x11; n < 0x15; n++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[n].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[n].Text = (n - 0x11).ToString();
                    this.GridView1.Rows[i].Cells[n].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[n].Font.Bold = true;
                }
            }
            for (int num10 = 0x15; num10 < 0x19; num10++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[num10].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[num10].Text = (num10 - 0x15).ToString();
                    this.GridView1.Rows[i].Cells[num10].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[num10].Font.Bold = true;
                }
            }
            for (int num12 = 0x19; num12 < 0x1d; num12++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[num12].Text, 0) == 0)
                {
                    this.GridView1.Rows[i].Cells[num12].Text = (num12 - 0x19).ToString();
                    this.GridView1.Rows[i].Cells[num12].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[num12].Font.Bold = true;
                }
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1d].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x1d].Text = "A";
                this.GridView1.Rows[i].Cells[0x1d].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[30].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[30].Text = "B";
                this.GridView1.Rows[i].Cells[30].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x1f].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x1f].Text = "C";
                this.GridView1.Rows[i].Cells[0x1f].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x20].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x20].Text = "D";
                this.GridView1.Rows[i].Cells[0x20].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x21].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x21].Text = "E";
                this.GridView1.Rows[i].Cells[0x21].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x22].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x22].Text = "F";
                this.GridView1.Rows[i].Cells[0x22].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x23].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x23].Text = "G";
                this.GridView1.Rows[i].Cells[0x23].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x24].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x24].Text = "H";
                this.GridView1.Rows[i].Cells[0x24].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x25].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x25].Text = "I";
                this.GridView1.Rows[i].Cells[0x25].ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x26].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x26].Text = "J";
                this.GridView1.Rows[i].Cells[0x26].ForeColor = Color.FromArgb(0, 0, 0);
            }
        }
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        for (int i = 1; i < 4; i++)
        {
            output.Write("<tr>");
            output.Write("<td height='22'>预选");
            output.Write(i.ToString() + "</td>");
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            output.Write("<td bgcolor='#fdfcdf'>&nbsp;</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>0</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>1</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>2</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf'>&nbsp;</td>");
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>0</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>1</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>2</strong></span></td>");
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            output.Write("<td bgcolor='#fdfcdf'>&nbsp;</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;' ><strong>0</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;' ><strong>1</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;' ><strong>2</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf'>&nbsp;</td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>0</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>1</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>2</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff;  cursor:pointer;' ><strong>3</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>0</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>1</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>2</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' ><strong>3</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>0</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>1</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>2</strong></span></td>");
            output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff; cursor:pointer;' ><strong>3</strong></span></td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;' >A</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>B</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>C</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>D</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>E</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>F</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>G</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>H</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>I</td>");
            output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#000000','#fdfcdf') style='color:#fdfcdf; cursor:pointer;'>J</td>");
        }
        output.Write("<tr  bgcolor='#e8f1f8'>");
        output.Write("<td rowspan='3'　 bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td rowspan='3'  bgcolor='#e8f1f8' >开奖号码</td>");
        for (int j = 0; j < 3; j++)
        {
            output.Write("<td bgcolor='#e8f1f8'>&nbsp;</td>");
            output.Write("<td bgcolor='#e8f1f8'>0</td>");
            output.Write("<td bgcolor='#e8f1f8'>1</td>");
            output.Write("<td bgcolor='#e8f1f8'>2</td>");
            output.Write("<td bgcolor='#e8f1f8'>&nbsp;</td>");
        }
        for (int k = 0; k < 3; k++)
        {
            for (int m = 0; m < 4; m++)
            {
                output.Write("<td bgcolor='#e8f1f8'>");
                output.Write(m.ToString() + "</td>");
            }
        }
        output.Write("<td bgcolor='#e8f1f8' height='18px'>A</td>");
        output.Write("<td bgcolor='#e8f1f8' >B</td>");
        output.Write("<td bgcolor='#e8f1f8' >C</td>");
        output.Write("<td bgcolor='#e8f1f8' >D</td>");
        output.Write("<td bgcolor='#e8f1f8' >E</td>");
        output.Write("<td bgcolor='#e8f1f8' >F</td>");
        output.Write("<td bgcolor='#e8f1f8' >G</td>");
        output.Write("<td bgcolor='#e8f1f8' >H</td>");
        output.Write("<td bgcolor='#e8f1f8' >I</td>");
        output.Write("<td bgcolor='#e8f1f8' >J</td>");
        output.Write("<tr  bgcolor='#e8f1f8' height='18px'>");
        output.Write("<td colspan='5'>百位</td>");
        output.Write("<td colspan='5'>十位</td>");
        output.Write("<td colspan='5'>个位</td>");
        output.Write("<td colspan='4'>0码个数</td>");
        output.Write("<td colspan='4'>1码个数</td>");
        output.Write("<td colspan='4'>2码个数</td>");
        output.Write("<td colspan='10'>总体走势分析</td>");
        output.Write("<tr  bgcolor='#e8f1f8'>");
        output.Write("<td colspan='37'　 bgcolor='#e8f1f8' height='18px'>012路</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3'　 bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td rowspan='3'  bgcolor='#e8f1f8' >开奖号码</td>");
        output.Write("<td colspan='37'　 bgcolor='#e8f1f8' height='18px'>012路</td>");
        output.Write("<tr  bgcolor='#e8f1f8' height='18px'>");
        output.Write("<td colspan='5'>百位</td>");
        output.Write("<td colspan='5'>十位</td>");
        output.Write("<td colspan='5'>个位</td>");
        output.Write("<td colspan='4'>0码个数</td>");
        output.Write("<td colspan='4'>1码个数</td>");
        output.Write("<td colspan='4'>2码个数</td>");
        output.Write("<td colspan='10'>总体走势分析</td>");
        output.Write("<tr  bgcolor='#e8f1f8'>");
        for (int i = 0; i < 3; i++)
        {
            output.Write("<td>&nbsp;</td>");
            output.Write("<td>0</td>");
            output.Write("<td>1</td>");
            output.Write("<td>2</td>");
            output.Write("<td>&nbsp;</td>");
        }
        for (int j = 0; j < 3; j++)
        {
            for (int k = 0; k < 4; k++)
            {
                output.Write("<td>");
                output.Write(k.ToString() + "</td>");
            }
        }
        output.Write("<td bgcolor='#e8f1f8' height='18px'>A</td>");
        output.Write("<td bgcolor='#e8f1f8' >B</td>");
        output.Write("<td bgcolor='#e8f1f8' >C</td>");
        output.Write("<td bgcolor='#e8f1f8' >D</td>");
        output.Write("<td bgcolor='#e8f1f8' >E</td>");
        output.Write("<td bgcolor='#e8f1f8' >F</td>");
        output.Write("<td bgcolor='#e8f1f8' >G</td>");
        output.Write("<td bgcolor='#e8f1f8' >H</td>");
        output.Write("<td bgcolor='#e8f1f8' >I</td>");
        output.Write("<td bgcolor='#e8f1f8' >J</td>");
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
        table = new TrendChart().SHSSL_012_Select(30, "", "", ref result);
        if ((table != null) && (table.Rows.Count >= 1))
        {
            int count = table.Rows.Count;
            this.tb1.Text = table.Rows[0]["Isuse"].ToString();
            this.tb2.Text = table.Rows[count - 1]["Isuse"].ToString();
        }
        this.GridView1.DataSource = table;
        this.GridView1.DataBind();
    }

    protected override void OnInit(EventArgs e)
    {
        base.CacheSeconds = 300;
        base.OnInit(e);
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

