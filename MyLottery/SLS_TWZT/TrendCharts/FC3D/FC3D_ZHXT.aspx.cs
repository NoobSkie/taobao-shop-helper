﻿using ASP;
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

public partial class Home_TrendCharts_FC3D_FC3D_ZHXT : TrendChartPageBase, IRequiresSessionState
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
        DataRow[] rowArray = cacheAsDataTable.Select("LotteryID=6 and [Name] = '广告一'", "[Order]");
        DataRow[] rowArray2 = cacheAsDataTable.Select("LotteryID=6 and [Name] = '广告二'", "[Order]");
        DataRow[] rowArray3 = cacheAsDataTable.Select("LotteryID=6 and [Name] = '广告三'", "[Order]");
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
            table = new TrendChart().FC3D_ZHFB_Select(0, this.tb1.Text.ToString(), this.tb2.Text.ToString(), ref result);
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
        table = new TrendChart().FC3D_ZHFB_Select(100, "", "", ref result);
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
        table = new TrendChart().FC3D_ZHFB_Select(30, "", "", ref result);
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
        table = new TrendChart().FC3D_ZHFB_Select(50, "", "", ref result);
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
        this.lbline.Text = "<script type=\"text/javascript\">function DrawLines(){";
        string str = "";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[12].Text, 0) == 0)
            {
                HtmlImage child = new HtmlImage
                {
                    Src = "../../../Images/4[1].jpg"
                };
                this.GridView1.Rows[i].Cells[12].Controls.Add(child);
            }
            for (int j = 14; j < 0x18; j++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[j].Text, 0) == 0)
                {
                    Label label = new Label();
                    string[] strArray = new string[8];
                    strArray[0] = "<strong style='color:red;' id='GridView1_ctl";
                    int num3 = i + 2;
                    strArray[1] = num3.ToString().PadLeft(2, '0');
                    strArray[2] = "_";
                    strArray[3] = i.ToString();
                    strArray[4] = "_";
                    strArray[5] = j.ToString();
                    strArray[6] = "'>";
                    strArray[7] = (j - 14).ToString();
                    label.Text = string.Concat(strArray);
                    if ((str != null) && (str != ""))
                    {
                        string str5 = this.lbline.Text;
                        string[] strArray2 = new string[10];
                        strArray2[0] = str5;
                        strArray2[1] = "DrawLine('";
                        strArray2[2] = str;
                        strArray2[3] = "','GridView1_ctl";
                        int num5 = i + 2;
                        strArray2[4] = num5.ToString().PadLeft(2, '0');
                        strArray2[5] = "_";
                        strArray2[6] = i.ToString();
                        strArray2[7] = "_";
                        strArray2[8] = j.ToString();
                        strArray2[9] = "', '#A9A9A9');";
                        this.lbline.Text = string.Concat(strArray2);
                    }
                    this.GridView1.Rows[i].Cells[j].Controls.Add(label);
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
            for (int k = 0x19; k < 0x23; k++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[k].Text, 0) == 0)
                {
                    Label label2 = new Label();
                    string[] strArray4 = new string[8];
                    strArray4[0] = "<strong style='color:blue;' id='GridView1_ctl";
                    int num8 = i + 2;
                    strArray4[1] = num8.ToString().PadLeft(2, '0');
                    strArray4[2] = "_";
                    strArray4[3] = i.ToString();
                    strArray4[4] = "_";
                    strArray4[5] = k.ToString();
                    strArray4[6] = "'>";
                    strArray4[7] = (k - 0x19).ToString();
                    label2.Text = string.Concat(strArray4);
                    if ((str2 != null) && (str2 != ""))
                    {
                        string str6 = this.lbline.Text;
                        string[] strArray5 = new string[10];
                        strArray5[0] = str6;
                        strArray5[1] = "DrawLine('";
                        strArray5[2] = str2;
                        strArray5[3] = "','GridView1_ctl";
                        int num10 = i + 2;
                        strArray5[4] = num10.ToString().PadLeft(2, '0');
                        strArray5[5] = "_";
                        strArray5[6] = i.ToString();
                        strArray5[7] = "_";
                        strArray5[8] = k.ToString();
                        strArray5[9] = "', '#A9A9A9');";
                        this.lbline.Text = string.Concat(strArray5);
                    }
                    this.GridView1.Rows[i].Cells[k].Controls.Add(label2);
                    string[] strArray6 = new string[6];
                    strArray6[0] = "GridView1_ctl";
                    int num11 = i + 2;
                    strArray6[1] = num11.ToString().PadLeft(2, '0');
                    strArray6[2] = "_";
                    strArray6[3] = i.ToString();
                    strArray6[4] = "_";
                    strArray6[5] = k.ToString();
                    str2 = string.Concat(strArray6);
                }
            }
            for (int m = 0x23; m < 0x2d; m++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[m].Text, 0) == 0)
                {
                    Label label3 = new Label();
                    string[] strArray7 = new string[8];
                    strArray7[0] = "<strong style='color:red;' id='GridView1_ctl";
                    int num13 = i + 2;
                    strArray7[1] = num13.ToString().PadLeft(2, '0');
                    strArray7[2] = "_";
                    strArray7[3] = i.ToString();
                    strArray7[4] = "_";
                    strArray7[5] = m.ToString();
                    strArray7[6] = "'>";
                    strArray7[7] = (m - 0x23).ToString();
                    label3.Text = string.Concat(strArray7);
                    if ((str3 != null) && (str3 != ""))
                    {
                        string str7 = this.lbline.Text;
                        string[] strArray8 = new string[10];
                        strArray8[0] = str7;
                        strArray8[1] = "DrawLine('";
                        strArray8[2] = str3;
                        strArray8[3] = "','GridView1_ctl";
                        int num15 = i + 2;
                        strArray8[4] = num15.ToString().PadLeft(2, '0');
                        strArray8[5] = "_";
                        strArray8[6] = i.ToString();
                        strArray8[7] = "_";
                        strArray8[8] = m.ToString();
                        strArray8[9] = "', '#A9A9A9');";
                        this.lbline.Text = string.Concat(strArray8);
                    }
                    this.GridView1.Rows[i].Cells[m].Controls.Add(label3);
                    string[] strArray9 = new string[6];
                    strArray9[0] = "GridView1_ctl";
                    int num16 = i + 2;
                    strArray9[1] = num16.ToString().PadLeft(2, '0');
                    strArray9[2] = "_";
                    strArray9[3] = i.ToString();
                    strArray9[4] = "_";
                    strArray9[5] = m.ToString();
                    str3 = string.Concat(strArray9);
                }
            }
            for (int n = 0x2d; n < 0x37; n++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[n].Text, 0) == 0)
                {
                    Label label4 = new Label();
                    string[] strArray10 = new string[8];
                    strArray10[0] = "<strong style='color:red;' id='GridView1_ctl";
                    int num18 = i + 2;
                    strArray10[1] = num18.ToString().PadLeft(2, '0');
                    strArray10[2] = "_";
                    strArray10[3] = i.ToString();
                    strArray10[4] = "_";
                    strArray10[5] = n.ToString();
                    strArray10[6] = "'>";
                    strArray10[7] = (n - 0x2d).ToString();
                    label4.Text = string.Concat(strArray10);
                    if ((str4 != null) && (str4 != ""))
                    {
                        string str8 = this.lbline.Text;
                        string[] strArray11 = new string[10];
                        strArray11[0] = str8;
                        strArray11[1] = "DrawLine('";
                        strArray11[2] = str4;
                        strArray11[3] = "','GridView1_ctl";
                        int num20 = i + 2;
                        strArray11[4] = num20.ToString().PadLeft(2, '0');
                        strArray11[5] = "_";
                        strArray11[6] = i.ToString();
                        strArray11[7] = "_";
                        strArray11[8] = n.ToString();
                        strArray11[9] = "', '#A9A9A9');";
                        this.lbline.Text = string.Concat(strArray11);
                    }
                    this.GridView1.Rows[i].Cells[n].Controls.Add(label4);
                    string[] strArray12 = new string[6];
                    strArray12[0] = "GridView1_ctl";
                    int num21 = i + 2;
                    strArray12[1] = num21.ToString().PadLeft(2, '0');
                    strArray12[2] = "_";
                    strArray12[3] = i.ToString();
                    strArray12[4] = "_";
                    strArray12[5] = n.ToString();
                    str4 = string.Concat(strArray12);
                }
            }
            for (int num22 = 2; num22 < 12; num22++)
            {
                if (_Convert.StrToInt(this.GridView1.Rows[i].Cells[num22].Text, 0) == -1)
                {
                    this.GridView1.Rows[i].Cells[num22].Text = "&nbsp;";
                }
            }
            string text = this.GridView1.Rows[i].Cells[1].Text;
            int num23 = int.Parse(text.Substring(0, 1));
            int num24 = int.Parse(text.Substring(1, 1));
            int num25 = int.Parse(text.Substring(2, 1));
            if ((num23 == num24) || (num23 == num25))
            {
                switch (num23)
                {
                    case 0:
                        this.GridView1.Rows[i].Cells[2].ForeColor = Color.FromArgb(0xff, 0, 0);
                        goto Label_0B67;

                    case 1:
                        this.GridView1.Rows[i].Cells[3].ForeColor = Color.FromArgb(0xff, 0, 0);
                        goto Label_0B67;

                    case 2:
                        this.GridView1.Rows[i].Cells[4].ForeColor = Color.FromArgb(0xff, 0, 0);
                        goto Label_0B67;

                    case 3:
                        this.GridView1.Rows[i].Cells[5].ForeColor = Color.FromArgb(0xff, 0, 0);
                        goto Label_0B67;

                    case 4:
                        this.GridView1.Rows[i].Cells[6].ForeColor = Color.FromArgb(0xff, 0, 0);
                        goto Label_0B67;

                    case 5:
                        this.GridView1.Rows[i].Cells[7].ForeColor = Color.FromArgb(0xff, 0, 0);
                        goto Label_0B67;

                    case 6:
                        this.GridView1.Rows[i].Cells[8].ForeColor = Color.FromArgb(0xff, 0, 0);
                        goto Label_0B67;

                    case 7:
                        this.GridView1.Rows[i].Cells[9].ForeColor = Color.FromArgb(0xff, 0, 0);
                        goto Label_0B67;

                    case 8:
                        this.GridView1.Rows[i].Cells[10].ForeColor = Color.FromArgb(0xff, 0, 0);
                        goto Label_0B67;
                }
                this.GridView1.Rows[i].Cells[11].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
        Label_0B67:
            if (num24 == num25)
            {
                switch (num24)
                {
                    case 0:
                        {
                            this.GridView1.Rows[i].Cells[2].ForeColor = Color.FromArgb(0xff, 0, 0);
                            continue;
                        }
                    case 1:
                        {
                            this.GridView1.Rows[i].Cells[3].ForeColor = Color.FromArgb(0xff, 0, 0);
                            continue;
                        }
                    case 2:
                        {
                            this.GridView1.Rows[i].Cells[4].ForeColor = Color.FromArgb(0xff, 0, 0);
                            continue;
                        }
                    case 3:
                        {
                            this.GridView1.Rows[i].Cells[5].ForeColor = Color.FromArgb(0xff, 0, 0);
                            continue;
                        }
                    case 4:
                        {
                            this.GridView1.Rows[i].Cells[6].ForeColor = Color.FromArgb(0xff, 0, 0);
                            continue;
                        }
                    case 5:
                        {
                            this.GridView1.Rows[i].Cells[7].ForeColor = Color.FromArgb(0xff, 0, 0);
                            continue;
                        }
                    case 6:
                        {
                            this.GridView1.Rows[i].Cells[8].ForeColor = Color.FromArgb(0xff, 0, 0);
                            continue;
                        }
                    case 7:
                        {
                            this.GridView1.Rows[i].Cells[9].ForeColor = Color.FromArgb(0xff, 0, 0);
                            continue;
                        }
                    case 8:
                        {
                            this.GridView1.Rows[i].Cells[10].ForeColor = Color.FromArgb(0xff, 0, 0);
                            continue;
                        }
                }
                this.GridView1.Rows[i].Cells[11].ForeColor = Color.FromArgb(0xff, 0, 0);
            }
        }
        this.lbline.Text = this.lbline.Text + "}</script>";
    }

    protected void DrawGridFooter(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td  height='22px'>预选1</td>");
        output.Write("<td>&nbsp;</td>");
        for (int i = 0; i < 10; i++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;cursor:pointer;'><strong>");
            output.Write(i.ToString() + "</strong></span></td>");
        }
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        for (int j = 0; j < 10; j++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' ><strong>");
            output.Write(j.ToString() + "</strong></span></td>");
        }
        output.Write("<td>&nbsp;</td>");
        for (int k = 0; k < 10; k++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;cursor:pointer;' ><strong>");
            output.Write(k.ToString() + "</strong></span></td>");
        }
        for (int m = 0; m < 10; m++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(m.ToString() + "</strong></span></td>");
        }
        for (int n = 0; n < 10; n++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(n.ToString() + "</strong></span></td>");
        }
        output.Write("<tr  style='cursor:pointer;'>");
        output.Write("<td  height='22px'>预选2</td>");
        output.Write("<td>&nbsp;</td>");
        for (int num6 = 0; num6 < 10; num6++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(num6.ToString() + "</strong></span></td>");
        }
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        for (int num7 = 0; num7 < 10; num7++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(num7.ToString() + "</strong></span></td>");
        }
        output.Write("<td>&nbsp;</td>");
        for (int num8 = 0; num8 < 10; num8++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(num8.ToString() + "</strong></span></td>");
        }
        for (int num9 = 0; num9 < 10; num9++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(num9.ToString() + "</strong></span></td>");
        }
        for (int num10 = 0; num10 < 10; num10++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(num10.ToString() + "</strong></span></td>");
        }
        output.Write("<tr style='cursor:pointer;' >");
        output.Write("<td  height='22px'>预选3</td>");
        output.Write("<td>&nbsp;</td>");
        for (int num11 = 0; num11 < 10; num11++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#000000','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(num11.ToString() + "</strong></span></td>");
        }
        output.Write("<td>&nbsp;</td>");
        output.Write("<td>&nbsp;</td>");
        for (int num12 = 0; num12 < 10; num12++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(num12.ToString() + "</strong></span></td>");
        }
        output.Write("<td>&nbsp;</td>");
        for (int num13 = 0; num13 < 10; num13++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(num13.ToString() + "</strong></span></td>");
        }
        for (int num14 = 0; num14 < 10; num14++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#ff0000','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(num14.ToString() + "</strong></span></td>");
        }
        for (int num15 = 0; num15 < 10; num15++)
        {
            output.Write("<td bgcolor='#FFFFFF' onClick=Style(this,'#0000ff','#FFFFFF') style='color:#FFFFFF;' ><strong>");
            output.Write(num15.ToString() + "</strong></span></td>");
        }
        output.Write("<tr bgcolor='#e8f1f8'>");
        output.Write("<td rowspan='2'　 >期  号</td>");
        output.Write("<td rowspan='2'　 >开奖号码</td>");
        for (int num16 = 0; num16 < 10; num16++)
        {
            output.Write("<td  height='18px'>");
            output.Write(num16.ToString() + "</td>");
        }
        output.Write("<td rowspan='2'>组三间隔</td>");
        output.Write("<td rowspan='2'>和值</td>");
        for (int num17 = 0; num17 < 10; num17++)
        {
            output.Write("<td >");
            output.Write(num17.ToString() + "</td>");
        }
        output.Write("<td rowspan='2'　 bgcolor='#e8f1f8'>012路</td>");
        for (int num18 = 0; num18 < 3; num18++)
        {
            for (int num19 = 0; num19 < 10; num19++)
            {
                output.Write("<td bgcolor='#e8f1f8'  rowspan='1'>");
                output.Write(num19.ToString() + "</td>");
            }
        }
        output.Write("<tr  bgcolor='#e8f1f8' height='26px'>");
        output.Write("<td colspan='10'　>号码分布图</td>");
        output.Write("<td colspan='10'　>和值尾号走势图</td>");
        output.Write("<td colspan='10'　>第一位</td>");
        output.Write("<td colspan='10'　>第二位</td>");
        output.Write("<td colspan='10'　>第三位</td>");
    }

    protected void DrawGridHeader(HtmlTextWriter output, Control ctl)
    {
        output.Write("<td rowspan='2'　 bgcolor='#e8f1f8'>期号</td>");
        output.Write("<td rowspan='2'　 bgcolor='#e8f1f8'>开奖号码</td>");
        output.Write("<td colspan='10'　 bgcolor='#e8f1f8' height='26px'>号码分布图</td>");
        output.Write("<td rowspan='2'　 bgcolor='#e8f1f8'>组三间隔</td>");
        output.Write("<td rowspan='2'　 bgcolor='#e8f1f8'>和值</td>");
        output.Write("<td colspan='10'　 bgcolor='#e8f1f8'>和值尾数走势图</td>");
        output.Write("<td rowspan='2'　 bgcolor='#e8f1f8'>012路</td>");
        output.Write("<td colspan='10'　 bgcolor='#e8f1f8'>第一位</td>");
        output.Write("<td colspan='10'　 bgcolor='#e8f1f8'>第二位</td>");
        output.Write("<td colspan='10'　 bgcolor='#e8f1f8'>第三位</td>");
        output.Write("<tr  bgcolor='#e8f1f8' height='18px'>");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                output.Write("<td>");
                output.Write(j.ToString() + "</td>");
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
        table = new TrendChart().FC3D_ZHFB_Select(30, "", "", ref result);
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

