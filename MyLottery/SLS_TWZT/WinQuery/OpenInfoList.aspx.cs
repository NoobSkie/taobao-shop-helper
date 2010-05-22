using ASP;
using DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using SLS;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class WinQuery_OpenInfoList : SitePageBase, IRequiresSessionState
{
    public string BuyUrl = "";
    private string dingZhi = "";
    public string IsusesName = "";
    private string LotteryCode = "";
    public int LotteryID = 5;
    public string LotteryName = "";
    public string TrendUrl = "";

    private void BindDataForIsuses(int LotteryID)
    {
        string key = "Isuses";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = MSSQL.Select("select ID,EndTime,WinLotteryNumber,OpenAffiche,Name,LotteryID from T_Isuses where IsOpened = 1 and EndTime < GETDATE() order by EndTime desc", new MSSQL.Parameter[0]);
            if (cacheAsDataTable == null)
            {
                PF.GoError(7, "数据库繁忙，请重试", base.GetType().FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 600);
        }
        this.ddlIsuses.Items.Clear();
        foreach (DataRow row in cacheAsDataTable.Select("LotteryID=" + LotteryID.ToString()))
        {
            ListItem item = new ListItem(row["Name"].ToString(), row["ID"].ToString());
            this.ddlIsuses.Items.Add(item);
        }
        this.imgLogo.ImageUrl = "../Home/Room/Images/LotteryWinLogo/" + new Lottery()[LotteryID].code + ".jpg";
        int num2 = _Convert.StrToInt(this.HidIsuseID.Value, 0);
        if (this.ddlIsuses.Items.Count > 0)
        {
            if (this.ddlIsuses.Items.FindByValue(num2.ToString()) != null)
            {
                this.ddlIsuses.SelectedValue = num2.ToString();
            }
            this.lbIsuse.Text = this.ddlIsuses.SelectedItem.Text.Trim();
            this.IsusesName = this.lbIsuse.Text;
            this.HidIsuseID.Value = this.ddlIsuses.SelectedValue;
            string str2 = "Isuses";
            DataTable table2 = Shove._Web.Cache.GetCacheAsDataTable(str2);
            if (table2 == null)
            {
                table2 = MSSQL.Select("select ID,EndTime,WinLotteryNumber,OpenAffiche,Name,LotteryID from T_Isuses where IsOpened = 1 and EndTime < GETDATE() order by EndTime desc", new MSSQL.Parameter[0]);
                if ((table2 == null) || (table2.Rows.Count < 1))
                {
                    PF.GoError(7, "数据库繁忙，请重试", base.GetType().FullName);
                    return;
                }
                Shove._Web.Cache.SetCache(str2, table2, 600);
            }
            DataRow row2 = table2.Select("ID = " + this.ddlIsuses.SelectedValue)[0];
            this.lbOpenDate.Text = Convert.ToDateTime(row2["EndTime"]).ToString("yyyy年MM月dd日");
            this.lbGetPrizeEndTime.Text = Convert.ToDateTime(row2["EndTime"]).AddDays(60.0).ToString("yyyy年MM月dd日");
            this.tbWinNumber.InnerHtml = this.FormatWinNumber(_Convert.StrToInt(this.HidLotteryID.Value, 5), row2["WinLotteryNumber"].ToString());
            this.lbWinInfo.Text = row2["OpenAffiche"].ToString();
            this.BindDataForPlayTypes(int.Parse(this.HidLotteryID.Value));
        }
    }

    private void BindDataForPlayTypes(int LotteryID)
    {
        string key = "dtPlayTypes_" + LotteryID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_PlayTypes().Open("", "LotteryID in (" + ((base._Site.UseLotteryList == "") ? "-1" : base._Site.UseLotteryList) + ") and LotteryID = " + LotteryID.ToString(), "[ID]");
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
            {
                PF.GoError(7, "数据库繁忙，请重试", base.GetType().FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        this.ddlPlayTypes.Items.Clear();
        this.ddlPlayTypes.Items.Add(new ListItem("全部玩法", "0"));
        foreach (DataRow row in cacheAsDataTable.Rows)
        {
            ListItem item = new ListItem(row["Name"].ToString(), row["ID"].ToString());
            this.ddlPlayTypes.Items.Add(item);
        }
        int num = _Convert.StrToInt(Utility.GetRequest("PlayTypeID"), 0);
        if (this.ddlPlayTypes.Items.Count > 0)
        {
            if (this.ddlPlayTypes.Items.FindByValue(num.ToString()) != null)
            {
                this.ddlPlayTypes.SelectedValue = num.ToString();
            }
            this.HidPlayType.Value = this.ddlPlayTypes.SelectedValue;
            this.BindDataForWinDetail(int.Parse(this.HidLotteryID.Value), int.Parse(this.HidIsuseID.Value));
        }
    }

    private void BindDataForWinDetail(int LotteryID, int IsuseID)
    {
        this.rptWinDetail.DataBind();
        int num = _Convert.StrToInt(Utility.GetRequest("PID"), 1);
        if (num <= 0)
        {
            num = 1;
        }
        string key = "WinDetailIsuse_" + IsuseID.ToString() + "_" + this.HidPlayType.Value + ((this.HidSearch.Value == "") ? "" : (" and (InitiateName like '%" + this.HidSearch.Value + "%' or SchemeNumber like '%" + this.HidSearch.Value + "%')"));
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            StringBuilder builder = new StringBuilder();
            if (Utility.FilteSqlInfusion(this.HidPlayType.Value) != "0")
            {
                builder.AppendLine("select a.*,b.Name as InitiateName,c.Name as PlayTypeName from ").AppendLine("(").AppendLine("\tselect ID,InitiateUserID,PlayTypeID,[Money],SchemeNumber,Share,WinDescription,Multiple,WinMoneyNoWithTax,InitiateBonus  from T_Schemes ").AppendLine("\t\twhere WinMoney > 0 and IsuseID = @IsuseID and  QuashStatus = 0 and InitiateUserID <> 132011  and PlayTypeID = @PlayTypeID").AppendLine(") a").AppendLine("inner join T_Users b on a.InitiateUserID = b.ID").AppendLine("inner join T_PlayTypes c on a.PlayTypeID = c.ID").AppendLine((this.HidSearch.Value == "") ? "" : " where (b.Name like @InitiateName or a.SchemeNumber like @InitiateName)").AppendLine("order by a.WinMoneyNoWithTax desc");
                cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.Int, 0, ParameterDirection.Input, Utility.FilteSqlInfusion(IsuseID.ToString())), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, Utility.FilteSqlInfusion(this.HidPlayType.Value)), new MSSQL.Parameter("InitiateName", SqlDbType.VarChar, 0, ParameterDirection.Input, "%" + Utility.FilteSqlInfusion(this.HidSearch.Value) + "%") });
            }
            else
            {
                builder.AppendLine("select a.*,b.Name as InitiateName,c.Name as PlayTypeName from ").AppendLine("(").AppendLine("\tselect ID,InitiateUserID,PlayTypeID,[Money],SchemeNumber,Share,WinDescription,Multiple,WinMoneyNoWithTax,InitiateBonus  from T_Schemes ").AppendLine("\t\twhere WinMoney > 0 and IsuseID = @IsuseID and  QuashStatus = 0 and InitiateUserID <> 132011 ").AppendLine(") a").AppendLine("inner join T_Users b on a.InitiateUserID = b.ID").AppendLine("inner join T_PlayTypes c on a.PlayTypeID = c.ID").AppendLine((this.HidSearch.Value == "") ? "" : " where (b.Name like @InitiateName or a.SchemeNumber like @InitiateName)").AppendLine("order by a.WinMoneyNoWithTax desc");
                cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.Int, 0, ParameterDirection.Input, Utility.FilteSqlInfusion(IsuseID.ToString())), new MSSQL.Parameter("InitiateName", SqlDbType.VarChar, 0, ParameterDirection.Input, "%" + Utility.FilteSqlInfusion(this.HidSearch.Value) + "%") });
            }
            if (cacheAsDataTable == null)
            {
                PF.GoError(7, "数据库繁忙，请重试", base.GetType().FullName);
                return;
            }
            if (cacheAsDataTable.Rows.Count < 1)
            {
                return;
            }
            cacheAsDataTable.Columns.Add("TmpID", Type.GetType("System.Int32"));
            cacheAsDataTable.Columns.Add("WinDescription2", Type.GetType("System.String"));
            cacheAsDataTable.Columns.Add("ShareWinMoney", Type.GetType("System.String"));
            cacheAsDataTable.Columns.Add("EachMonney", Type.GetType("System.String"));
            int num2 = cacheAsDataTable.Rows.Count;
            for (int k = 0; k < num2; k++)
            {
                cacheAsDataTable.Rows[k]["TmpID"] = k + 1;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 600);
        }
        int num4 = 20;
        int count = cacheAsDataTable.Rows.Count;
        int num6 = ((count % num4) == 0) ? (count / num4) : ((count / num4) + 1);
        if (num > num6)
        {
            num = num6;
        }
        int num7 = 10;
        int num8 = ((num % num7) == 0) ? ((num7 * ((num / num7) - 1)) + 1) : ((num7 * (num / num7)) + 1);
        int num9 = (((num8 / num7) + 1) == 1) ? 1 : ((num7 * ((num8 / num7) - 1)) + 1);
        int num10 = (num6 > (num7 * ((num / num7) + 2))) ? ((num7 * ((num / num7) + 1)) + 1) : num6;
        if ((num8 + num7) > num6)
        {
            num8 = (num6 - num7) + 1;
        }
        if (num8 <= 0)
        {
            num8 = 1;
        }
        DataRow[] rowArray = cacheAsDataTable.Select("TmpID > " + ((num4 * (num - 1))).ToString() + " and TmpID < " + (((num4 * num) + 1)).ToString());
        DataTable table2 = cacheAsDataTable.Clone();
        foreach (DataRow row in rowArray)
        {
            table2.Rows.Add(row.ItemArray);
        }
        int num14 = table2.Rows.Count;
        for (int i = 0; i < num14; i++)
        {
            string str2 = rowArray[i]["WinDescription"].ToString();
            table2.Rows[i]["WinDescription2"] = str2;
            double num16 = _Convert.StrToDouble(rowArray[i]["WinMoneyNoWithTax"].ToString(), 0.0);
            double num17 = _Convert.StrToDouble(rowArray[i]["InitiateBonus"].ToString(), 0.0);
            int num18 = _Convert.StrToInt(rowArray[i]["Share"].ToString(), 0);
            _Convert.StrToInt(rowArray[i]["PlayTypeID"].ToString(), 0);
            double num19 = _Convert.StrToDouble(rowArray[i]["Money"].ToString(), 0.0);
            if (num18 == 1)
            {
                table2.Rows[i]["ShareWinMoney"] = num16.ToString("N");
                table2.Rows[i]["EachMonney"] = num19;
            }
            else
            {
                table2.Rows[i]["ShareWinMoney"] = Math.Round((double)((num16 - num17) / ((double)num18)), 2).ToString("N");
                table2.Rows[i]["EachMonney"] = Convert.ToDouble((double)(num19 / ((double)num18))).ToString("N");
            }
            table2.Rows[i]["Money"] = _Convert.StrToDouble(rowArray[i]["Money"].ToString(), 0.0).ToString("N");
            table2.Rows[i]["WinMoneyNoWithTax"] = num16.ToString("N");
            table2.AcceptChanges();
        }
        this.rptWinDetail.DataSource = table2;
        this.rptWinDetail.DataBind();
        StringBuilder builder2 = new StringBuilder();
        builder2.Append("<tr>").Append("<td width='31%' height='36' align='left' class='black12'>").Append("第<span class='red'>").Append(num.ToString()).Append("/").Append(num6.ToString()).Append("</span>页 <span class='red'>").Append(num4.ToString()).Append("</span>条/页 共<span class='red'>").Append(count.ToString()).Append("</span>条").Append("</td>").Append("<td width='69%' align='right'>").Append("<table border='0' cellspacing='4' cellpadding='0'>").Append("<tbody style='text-align:center; width:20px;'>").Append("<tr>").Append("<td valign='middle' class='ball' onclick='showPage(1,").Append(LotteryID.ToString()).Append(",").Append(this.HidIsuseID.Value).Append(",").Append(this.HidPlayType.Value).Append(",\"").Append(HttpUtility.UrlEncode(this.HidSearch.Value)).Append("\");'>").Append("<img src='../Home/Room/Images/page_first.gif' width='9' height='8' />").Append("</td>").Append("<td class='ball' onclick='showPage(").Append(num9.ToString()).Append(",").Append(LotteryID.ToString()).Append(",").Append(this.HidIsuseID.Value).Append(",").Append(this.HidPlayType.Value).Append(",\"").Append(HttpUtility.UrlEncode(this.HidSearch.Value)).Append("\");'>").Append("<img src='../Home/Room/Images/page_previous.gif' width='9' height='8' />");
        for (int j = num8; (j < (num8 + num7)) && (j <= num6); j++)
        {
            builder2.Append("</td>").Append("<td id='page_").Append(j.ToString()).Append("' class='ball").Append((num == j) ? "_r" : ((j <= num6) ? "" : "_c")).Append("'");
            if (j <= num6)
            {
                builder2.Append(" onclick='showPage(").Append(j.ToString()).Append(",").Append(LotteryID.ToString()).Append(",").Append(this.HidIsuseID.Value).Append(",").Append(this.HidPlayType.Value).Append(",\"").Append(HttpUtility.UrlEncode(this.HidSearch.Value)).Append("\");'");
            }
            builder2.Append(">").Append(j.ToString()).Append("</td>");
        }
        builder2.Append("<td style='width:36px;'>").Append("<input type='text' class='ball_50' id='txtgopage' maxlength='").Append(num6.ToString().Length.ToString()).Append("' />").Append("</td>").Append("<td class='ball' onclick=\"showPage(document.getElementById('txtgopage').value,").Append(LotteryID.ToString()).Append(",").Append(this.HidIsuseID.Value).Append(",").Append(this.HidPlayType.Value).Append(",'").Append(HttpUtility.UrlEncode(this.HidSearch.Value)).Append("');\">").Append("<img src='../Home/Room/Images/page_go.gif' width='11' height='8' />").Append("</td>").Append("<td class='ball' onclick='showPage(").Append(num10.ToString()).Append(",").Append(LotteryID.ToString()).Append(",").Append(this.HidIsuseID.Value).Append(",").Append(this.HidPlayType.Value).Append(",\"").Append(HttpUtility.UrlEncode(this.HidSearch.Value)).Append("\");'>").Append("<img src='../Home/Room/Images/page_next.gif' width='9' height='8' />").Append("</td>").Append("<td class='ball' onclick='showPage(").Append(num6.ToString()).Append(",").Append(LotteryID.ToString()).Append(",").Append(this.HidIsuseID.Value).Append(",").Append(this.HidPlayType.Value).Append(",\"").Append(HttpUtility.UrlEncode(this.HidSearch.Value)).Append("\");'>").Append("<img src='../Home/Room/Images/page_last.gif' width='9' height='8' />").Append("</td>").Append("</tr>").Append("</tbody>").Append("</table>").Append("</td>").Append("</tr>");
        this.tbPaging.InnerHtml = builder2.ToString();
    }

    private void BindOpenInfoList(int LotteryID, string LotteryCode)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("");
        string str = "";
        string str2 = "";
        DataTable winNumber = this.GetWinNumber(LotteryID, LotteryCode);
        builder.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
        for (int i = 0; i < winNumber.Rows.Count; i++)
        {
            str = winNumber.Rows[i]["Name"].ToString();
            str2 = winNumber.Rows[i]["WinLotteryNumber"].ToString();
            if ((i % 2) == 0)
            {
                builder.AppendLine("<tr>").AppendLine("<td width='50%' height='28'>").Append(string.Concat(new object[] { "<a href='", LotteryID, "-", winNumber.Rows[i]["ID"].ToString(), "-0.aspx' target='_blank'><span class='hui14'>&#9642;</span>&nbsp;第", str, "期&nbsp;&nbsp;&nbsp;&nbsp;" })).Append("<span class='red12'>" + str2 + "</span>").AppendLine("</a></td>");
            }
            else
            {
                builder.AppendLine("<td width='50%' height='28'>").Append(string.Concat(new object[] { "<a href='", LotteryID, "-", winNumber.Rows[i]["ID"].ToString(), "-0.aspx' target='_blank'><span class='hui14'>&#9642;</span>&nbsp;第", str, "期&nbsp;&nbsp;&nbsp;&nbsp;" })).Append("<span class='red12'>" + str2 + "</span>").AppendLine("</a></td>").AppendLine("</tr>");
            }
        }
        builder.Append("</table>");
        this.LatestOpenInfo.InnerHtml = builder.ToString();
    }

    protected void btn_All_Click(object sender, ImageClickEventArgs e)
    {
        this.ResponseTailor(false, _Convert.StrToLong(((ImageButton)sender).CommandArgument, 0L));
    }

    protected void btn_Single_Click(object sender, EventArgs e)
    {
        this.ResponseTailor(true, _Convert.StrToLong(((ImageButton)sender).CommandArgument, 0L));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string str = ((this.tbSearch.Text.Trim() == "(可输入发起人ID或方案编号搜索)") || (this.tbSearch.Text.Trim() == "")) ? "" : this.tbSearch.Text.Trim();
        string key = DateTime.Now.ToString("yyyyMMddhhmmss");
        Shove._Web.Cache.SetCache(key, str);
        base.Response.Redirect(Utility.FilteSqlInfusion(this.HidLotteryID.Value) + "-" + Utility.FilteSqlInfusion(this.HidIsuseID.Value) + "-" + Utility.FilteSqlInfusion(this.ddlPlayTypes.SelectedValue) + "-" + key + ".aspx");
    }

    protected void ddlIsuses_SelectedIndexChanged(object sender, EventArgs e)
    {
        base.Response.Redirect(Utility.FilteSqlInfusion(this.HidLotteryID.Value) + "-" + Utility.FilteSqlInfusion(this.ddlIsuses.SelectedValue) + "-0.aspx");
    }

    protected void ddlPlayTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        base.Response.Redirect(Utility.FilteSqlInfusion(this.HidLotteryID.Value) + "-" + Utility.FilteSqlInfusion(this.HidIsuseID.Value) + "-" + Utility.FilteSqlInfusion(this.ddlPlayTypes.SelectedValue) + ".aspx");
    }

    private string FormatWinNumber(int LotteryID, string winNumber)
    {
        StringBuilder builder = new StringBuilder();
        switch (LotteryID)
        {
            case 0x3a:
                if (winNumber.IndexOf("+") > 0)
                {
                    for (int i = 0; i < winNumber.Length; i++)
                    {
                        if (i < (winNumber.Length - 2))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(i, 1));
                        }
                        else if (i == (winNumber.Length - 1))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(../Home/Room/Images/zfb_blueball.gif)'>").Append(winNumber.Substring(i, 1));
                        }
                    }
                }
                break;

            case 0x3b:
                if (winNumber.Length > 0)
                {
                    string[] strArray3 = winNumber.Split(new char[] { ' ' });
                    for (int j = 0; (j < strArray3.Length) && (j < 5); j++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray3[j]);
                    }
                }
                break;

            case 0x3d:
            case 0x40:
                if (winNumber.Length > 0)
                {
                    for (int k = 0; k < winNumber.Length; k++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(k, 1));
                    }
                }
                break;

            case 0x3e:
                if (winNumber.Length > 0)
                {
                    string[] strArray7 = winNumber.Split(new char[] { ' ' });
                    for (int m = 0; m < strArray7.Length; m++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray7[m]);
                    }
                }
                break;

            case 0x3f:
                if (winNumber.Length > 0)
                {
                    for (int n = 0; n < winNumber.Length; n++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(n, 1));
                    }
                }
                break;

            case 0x41:
                if (winNumber.IndexOf(" + ") > 0)
                {
                    winNumber = winNumber.Replace(" + ", " ");
                    string[] strArray8 = winNumber.Split(new char[] { ' ' });
                    for (int num16 = 0; num16 < strArray8.Length; num16++)
                    {
                        if (num16 < (strArray8.Length - 1))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray8[num16]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(../Home/Room/Images/zfb_blueball.gif)'>").Append(strArray8[num16]);
                        }
                    }
                }
                break;

            case 0x27:
                if (winNumber.IndexOf(" + ") > 0)
                {
                    winNumber = winNumber.Replace(" + ", " ");
                    string[] strArray2 = winNumber.Split(new char[] { ' ' });
                    for (int num6 = 0; num6 < strArray2.Length; num6++)
                    {
                        if (num6 < (strArray2.Length - 2))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray2[num6]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(../Home/Room/Images/zfb_blueball.gif)'>").Append(strArray2[num6]);
                        }
                    }
                }
                break;

            case 1:
                if (winNumber.Length > 0)
                {
                    builder.Append("</td><td align='center' class='red14'>").Append(winNumber);
                }
                break;

            case 2:
                if (winNumber.Length > 0)
                {
                    builder.Append("</td><td align='center' class='red14'>").Append(winNumber);
                }
                break;

            case 3:
                if (winNumber.Length > 0)
                {
                    for (int num2 = 0; num2 < winNumber.Length; num2++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(num2, 1));
                    }
                }
                break;

            case 5:
                if (winNumber.IndexOf(" + ") > 0)
                {
                    winNumber = winNumber.Replace(" + ", " ");
                    string[] strArray = winNumber.Split(new char[] { ' ' });
                    for (int num3 = 0; num3 < strArray.Length; num3++)
                    {
                        if (num3 < (strArray.Length - 1))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray[num3]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(../Home/Room/Images/zfb_blueball.gif)'>").Append(strArray[num3]);
                        }
                    }
                }
                break;

            case 6:
                if (winNumber.Length > 0)
                {
                    for (int num4 = 0; num4 < winNumber.Length; num4++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(num4, 1));
                    }
                }
                break;

            case 9:
                if (winNumber.Length > 0)
                {
                    string[] strArray5 = winNumber.Split(new char[] { ' ' });
                    for (int num10 = 0; num10 < strArray5.Length; num10++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray5[num10]);
                    }
                }
                break;

            case 13:
                if (winNumber.IndexOf(" + ") > 0)
                {
                    winNumber = winNumber.Replace(" + ", " ");
                    string[] strArray4 = winNumber.Split(new char[] { ' ' });
                    for (int num9 = 0; num9 < strArray4.Length; num9++)
                    {
                        if (num9 < (strArray4.Length - 1))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray4[num9]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(../Home/Room/Images/zfb_blueball.gif)'>").Append(strArray4[num9]);
                        }
                    }
                }
                break;

            case 14:
                if (winNumber.IndexOf(" + ") > 0)
                {
                    winNumber = winNumber.Replace(" + ", " ");
                    string[] strArray6 = winNumber.Split(new char[] { ' ' });
                    for (int num11 = 0; num11 < strArray6.Length; num11++)
                    {
                        if (num11 < (strArray6.Length - 1))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(strArray6[num11]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(../Home/Room/Images/zfb_blueball.gif)'>").Append(strArray6[num11]);
                        }
                    }
                }
                break;

            case 15:
                if (winNumber.Length > 0)
                {
                    builder.Append("</td><td align='center' class='red14'>").Append(winNumber);
                }
                break;

            case 0x13:
                if (winNumber.Length > 0)
                {
                    for (int num14 = 0; num14 < winNumber.Length; num14++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(num14, 1));
                    }
                }
                break;

            case 0x1d:
                if (winNumber.Length > 0)
                {
                    for (int num5 = 0; num5 < winNumber.Length; num5++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(../Home/Room/Images/zfb_redball.gif)'>").Append(winNumber.Substring(num5, 1));
                    }
                }
                break;
        }
        return builder.ToString();
    }

    private DataTable GetWinNumber(int LotteryID, string LotteryCode)
    {
        string key = LotteryCode + "WinNumber" + LotteryID.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count == 0))
        {
            cacheAsDataTable = new Tables.T_Isuses().Open("top 10 ID, Name, WinLotteryNumber, EndTime", "LotteryID=" + LotteryID + " and IsOpened = 1 and IsNull(WinLotteryNumber,'')<>''", "EndTime Desc");
            if (cacheAsDataTable == null)
            {
                return null;
            }
            if (cacheAsDataTable.Rows.Count > 0)
            {
                Shove._Web.Cache.SetCache(key, cacheAsDataTable, 600);
            }
        }
        return cacheAsDataTable;
    }

    private void GoToBuy()
    {
        if (this.LotteryID == 5)
        {
            this.BuyUrl = "../Lottery/Buy_SSQ.aspx";
            this.TrendUrl = "../TrendCharts/SSQ/SSQ_CGXMB.aspx";
            this.LotteryCode = "ssq";
        }
        else if (this.LotteryID == 6)
        {
            this.BuyUrl = "../Lottery/Buy_3D.aspx";
            this.TrendUrl = "../TrendCharts/FC3D/FC3D_ZHXT.aspx";
            this.LotteryCode = "fc3d";
        }
        else if (this.LotteryID == 0x3b)
        {
            this.BuyUrl = "../Lottery/Buy_15X5.aspx";
            this.TrendUrl = "../TrendCharts/HD15X5/C15X5_CGXMB.aspx";
            this.LotteryCode = "15x5";
        }
        else if (this.LotteryID == 13)
        {
            this.BuyUrl = "../Lottery/Buy_QLC.aspx";
            this.TrendUrl = "../TrendCharts/QLC/7LC_CGXMB.aspx";
            this.LotteryCode = "qlc";
        }
        else if (this.LotteryID == 0x3a)
        {
            this.BuyUrl = "../Lottery/Buy_DF6J1.aspx";
            this.TrendUrl = "../TrendCharts/DF6J1/DF61_ZHFB.aspx";
            this.LotteryCode = "df6j1";
        }
        else if (this.LotteryID == 0x27)
        {
            this.BuyUrl = "../Lottery/Buy_CJDLT.aspx";
            this.TrendUrl = "../TrendCharts/CJDLT/Default.aspx";
            this.LotteryCode = "cjdlt";
        }
        else if (this.LotteryID == 0x3f)
        {
            this.BuyUrl = "../Lottery/Buy_PL3.aspx";
            this.TrendUrl = "../TrendCharts/PL3/Default.aspx";
            this.LotteryCode = "pl3";
        }
        else if (this.LotteryID == 3)
        {
            this.BuyUrl = "../Lottery/Buy_QXC.aspx";
            this.TrendUrl = "../TrendCharts/7Xing/Default.aspx";
            this.LotteryCode = "qxc";
        }
        else if (this.LotteryID == 0x40)
        {
            this.BuyUrl = "../Lottery/Buy_PL5.aspx";
            this.TrendUrl = "../TrendCharts/PL5/Default.aspx";
            this.LotteryCode = "pl5";
        }
        else if (this.LotteryID == 9)
        {
            this.BuyUrl = "../Lottery/Buy_22X5.aspx";
            this.TrendUrl = "../TrendCharts/TC22X5/Default.aspx";
            this.LotteryCode = "22x5";
        }
        else if (this.LotteryID == 0x41)
        {
            this.BuyUrl = "../Lottery/Buy_31X7.aspx";
            this.TrendUrl = "../TrendCharts/SSQ/SSQ_CGXMB.aspx";
            this.LotteryCode = "31x7";
        }
        else if (this.LotteryID == 0x1d)
        {
            this.BuyUrl = "../Lottery/Buy_SSL.aspx";
            this.TrendUrl = "../TrendCharts/SHSSL/SHSSL_ZHFB.aspx";
            this.LotteryCode = "ssl";
        }
        else if (this.LotteryID == 0x3e)
        {
            this.BuyUrl = "../Lottery/Buy_SYYDJ.aspx";
            this.TrendUrl = "../TrendCharts/SYYDJ/SYDJ_FBZS.aspx";
            this.LotteryCode = "syydj";
        }
        else if (this.LotteryID == 1)
        {
            this.BuyUrl = "../Lottery/Buy_SFC.aspx";
            this.TrendUrl = "../TrendCharts/SSQ/SSQ_CGXMB.aspx";
            this.LotteryCode = "sfc";
        }
        else if (this.LotteryID == 2)
        {
            this.BuyUrl = "../Lottery/Buy_JQC.aspx";
            this.TrendUrl = "../TrendCharts/SSQ/SSQ_CGXMB.aspx";
            this.LotteryCode = "jqc";
        }
        else if (this.LotteryID == 15)
        {
            this.BuyUrl = "../Lottery/Buy_LCBQC.aspx";
            this.TrendUrl = "../TrendCharts/SSQ/SSQ_CGXMB.aspx";
            this.LotteryCode = "lcbqc";
        }
        else if (this.LotteryID == 0x3d)
        {
            this.BuyUrl = "../Lottery/Buy_SSC.aspx";
            this.TrendUrl = "../TrendCharts/JXSSC/SSC_5X_ZHFB.aspx";
            this.LotteryCode = "ssc";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.LotteryID = _Convert.StrToInt(Utility.GetRequest("LotteryID"), 5);
            if (!DataCache.Lotteries.ContainsKey(this.LotteryID))
            {
                this.LotteryID = DataCache.Lotteries.First().Key;
            }
            this.GoToBuy();
            this.LotteryName = DataCache.Lotteries[this.LotteryID];
            this.HidLotteryID.Value = this.LotteryID.ToString();
            this.BindOpenInfoList(this.LotteryID, this.LotteryCode);
            this.HidIsuseID.Value = _Convert.StrToLong(Utility.GetRequest("IsuseID"), 0L).ToString();
            this.HidPlayType.Value = _Convert.StrToLong(Utility.GetRequest("PlayTypeID"), 0L).ToString();
            string key = HttpUtility.UrlDecode(Utility.GetRequest("Search"));
            if ((key != "") && (key != "0"))
            {
                this.HidSearch.Value = Shove._Web.Cache.GetCache(key).ToString();
                this.tbSearch.Text = this.HidSearch.Value;
                Shove._Web.Cache.ClearCache(this.HidSearch.Value);
            }
            this.BindDataForIsuses(this.LotteryID);
        }
    }

    private void ResponseTailor(bool b, long userid)
    {
        int lotteryID = _Convert.StrToInt(this.HidLotteryID.Value, -1);
        int num2 = -1;
        if (b)
        {
            num2 = lotteryID;
        }
        string str = string.Concat(new object[] { "followScheme(", num2, ");$Id(\"iframeFollowScheme\").src=\"../Home/Room/FollowFriendSchemeAdd.aspx?LotteryID=", num2, "&DzLotteryID=", num2 });
        if (userid < 1L)
        {
            PF.GoError(1, "参数错误", base.GetType().FullName);
        }
        else if (!new Lottery().ValidID(lotteryID))
        {
            PF.GoError(1, "参数错误！(彩种)", base.GetType().FullName);
        }
        else
        {
            Users users = new Users(base._Site.ID)
            {
                ID = userid
            };
            this.dingZhi = string.Concat(new object[] { "&FollowUserID=", userid, "&FollowUserName=", HttpUtility.UrlEncode(users.Name), "\"" });
            string returnDescription = "";
            if (users.GetUserInformationByID(ref returnDescription) == 0)
            {
                this.dingZhi = Encrypt.EncryptString(PF.GetCallCert(), str + this.dingZhi);
                switch (lotteryID)
                {
                    case 0x1d:
                        base.Response.Redirect("../Lottery/Buy_SSL.aspx?DZ=" + this.dingZhi);
                        return;

                    case 0x3e:
                        base.Response.Redirect("../Lottery/Buy_SYYDJ.aspx?DZ=" + this.dingZhi);
                        return;

                    case 0x3d:
                        base.Response.Redirect("../Lottery/Buy_SSC.aspx?DZ=" + this.dingZhi);
                        return;

                    case 1:
                    case 2:
                    case 15:
                        base.Response.Redirect(string.Concat(new object[] { "../Home/Room/Buy_ZC.aspx?LotteryID=", lotteryID, "&DZ=", this.dingZhi }));
                        return;
                }
                base.Response.Redirect(string.Concat(new object[] { "../Home/Room/Buy.aspx?LotteryID=", lotteryID, "&ID=", lotteryID, "&DZ=", this.dingZhi }));
            }
        }
    }
}

