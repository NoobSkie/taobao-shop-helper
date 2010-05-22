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

public partial class Home_TrendCharts_SHSSL_SHSSL_ZHFB : TrendChartPageBase, IRequiresSessionState
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
            table = new TrendChart().SHSSL_ZHFB_Select(0, this.tb1.Text.ToString(), this.tb2.Text.ToString(), ref result);
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
        table = new TrendChart().SHSSL_ZHFB_Select(100, "", "", ref result);
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
        table = new TrendChart().SHSSL_ZHFB_Select(30, "", "", ref result);
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
        table = new TrendChart().SHSSL_ZHFB_Select(50, "", "", ref result);
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
            for (int j = 2; j < 12; j++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, -1) == 0)
                {
                    this.GridView1.Rows[i].Cells[j].Text = (j - 2).ToString();
                    this.GridView1.Rows[i].Cells[j].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[j].Font.Bold = true;
                }
            }
            for (int k = 12; k < 0x16; k++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[k].Text, -1) == 0)
                {
                    this.GridView1.Rows[i].Cells[k].Text = (k - 12).ToString();
                    this.GridView1.Rows[i].Cells[k].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[k].Font.Bold = true;
                }
            }
            for (int m = 0x16; m < 0x20; m++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[m].Text, -1) == 0)
                {
                    this.GridView1.Rows[i].Cells[m].Text = (m - 0x16).ToString();
                    this.GridView1.Rows[i].Cells[m].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[m].Font.Bold = true;
                }
            }
            for (int n = 0x22; n < 0x2c; n++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[n].Text, -1) == 0)
                {
                    this.GridView1.Rows[i].Cells[n].Text = (n - 0x22).ToString();
                    this.GridView1.Rows[i].Cells[n].ForeColor = Color.FromArgb(0, 0, 0xff);
                    this.GridView1.Rows[i].Cells[n].Font.Bold = true;
                    int num10 = _Convert.StrToInt(this.GridView1.DataKeys[i].Values[0].ToString(), -1);
                    int num11 = _Convert.StrToInt(this.GridView1.DataKeys[i].Values[1].ToString(), -2);
                    int num12 = _Convert.StrToInt(this.GridView1.DataKeys[i].Values[2].ToString(), -3);
                    if ((((num10 == num11) && (num10 == (n - 0x22))) || ((num11 == num12) && (num11 == (n - 0x22)))) || ((num10 == num12) && (num12 == (n - 0x22))))
                    {
                        this.GridView1.Rows[i].Cells[n].ForeColor = Color.FromArgb(0xff, 0, 0);
                    }
                }
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x2c].Text, -1) == 0)
            {
                int num13 = _Convert.StrToInt(this.GridView1.DataKeys[i].Values[0].ToString(), -1);
                int num14 = _Convert.StrToInt(this.GridView1.DataKeys[i].Values[1].ToString(), -2);
                if (num13 == num14)
                {
                    this.GridView1.Rows[i].Cells[0x2c].Text = num14.ToString();
                    this.GridView1.Rows[i].Cells[0x2c].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[0x2c].Font.Bold = true;
                }
                else
                {
                    this.GridView1.Rows[i].Cells[0x2c].Text = this.GridView1.DataKeys[i].Values[2].ToString();
                    this.GridView1.Rows[i].Cells[0x2c].ForeColor = Color.FromArgb(0xff, 0, 0);
                    this.GridView1.Rows[i].Cells[0x2c].Font.Bold = true;
                }
            }
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[0x2d].Text, -1) == 0)
            {
                this.GridView1.Rows[i].Cells[0x2d].Text = this.GridView1.DataKeys[i].Value.ToString();
                this.GridView1.Rows[i].Cells[0x2d].ForeColor = Color.FromArgb(0, 0, 0xff);
                this.GridView1.Rows[i].Cells[0x2d].Font.Bold = true;
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
            for (int num2 = 0; num2 < 10; num2++)
            {
                output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;cursor:pointer;' ><strong>");
                output.Write(num2.ToString() + "</td>");
            }
            for (int num3 = 0; num3 < 10; num3++)
            {
                output.Write("<td bgcolor='#ffffff' onClick=Style(this,'#0000ff','#ffffff') style='color:#ffffff;cursor:pointer;'><strong>");
                output.Write(num3.ToString() + "</td>");
            }
            for (int num4 = 0; num4 < 10; num4++)
            {
                output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;cursor:pointer;'><strong>");
                output.Write(num4.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            output.Write("<td bgcolor='#ffffff'>&nbsp;</td>");
            for (int num5 = 0; num5 < 10; num5++)
            {
                output.Write("<td bgcolor='#fdfcdf' onClick=Style(this,'#ff0000','#fdfcdf') style='color:#fdfcdf;cursor:pointer;' ><strong>");
                output.Write(num5.ToString() + "</td>");
            }
            output.Write("<td bgcolor='#fdfcdf'>&nbsp;</td>");
            output.Write("<td bgcolor='#fdfcdf'>&nbsp;</td>");
        }
        output.Write("<tr align='center' valign='center' bgcolor='#e8f1f8'>");
        output.Write("<td rowspan='3'　height='18px'>期号</td>");
        output.Write("<td rowspan='3'　>开奖号码</td>");
        for (int j = 0; j < 10; j++)
        {
            output.Write("<td ><font color='blue'>");
            output.Write(j.ToString() + "</font></td>");
        }
        for (int k = 0; k < 10; k++)
        {
            output.Write("<td ><font color='red'>");
            output.Write(k.ToString() + "</font></td>");
        }
        for (int m = 0; m < 10; m++)
        {
            output.Write("<td ><font color='blue'>");
            output.Write(m.ToString() + "</font></td>");
        }
        output.Write("<td rowspan='2' bgcolor='#e8f1f8'>奇偶比</td>");
        output.Write("<td rowspan='2' bgcolor='#e8f1f8'>大小比</td>");
        for (int n = 0; n < 10; n++)
        {
            output.Write("<td ><font color='red'>");
            output.Write(n.ToString() + "</font></td>");
        }
        output.Write("<td rowspan='3'　>组选3</td>");
        output.Write("<td rowspan='3'　>豹子号</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8' height='18px'>");
        output.Write("<td colspan='10'>第一位</td>");
        output.Write("<td colspan='10'>第二位</td>");
        output.Write("<td colspan='10'>第三位</td>");
        output.Write("<td colspan='10' height='18px'>0-9综合分布</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8'>");
        output.Write("<td colspan='42'  height='18px'><strong><font color='red'>基本走势</font></strong></td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>开奖号码</td>");
        output.Write("<td colspan='42' align='center' valign='middle' bgcolor='#e8f1f8' height='18px'><strong><font color='red'>基本走势</font></strong></td>");
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>组选3</td>");
        output.Write("<td rowspan='3'　align='center' valign='middle' bgcolor='#e8f1f8'>豹子号</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8' height='18px'>");
        output.Write("<td colspan='10'>第一位</td>");
        output.Write("<td colspan='10'>第二位</td>");
        output.Write("<td colspan='10'>第三位</td>");
        output.Write("<td rowspan='2'>奇偶比</td>");
        output.Write("<td rowspan='2'>大小比</td>");
        output.Write("<td colspan='10' height='18px'>0-9综合分布</td>");
        output.Write("<tr align='center' valign='middle' bgcolor='#e8f1f8'>");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                output.Write("<td align='center' valign='middle' bgcolor='#e8f1f8' height='18px'><font color='blue'>");
                output.Write(j.ToString() + "</font></td>");
            }
            for (int k = 0; k < 10; k++)
            {
                output.Write("<td align='center' valign='middle' bgcolor='#e8f1f8' height='18px'><font color='red'>");
                output.Write(k.ToString() + "</font></td>");
            }
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
        table = new TrendChart().SHSSL_ZHFB_Select(30, "", "", ref result);
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

