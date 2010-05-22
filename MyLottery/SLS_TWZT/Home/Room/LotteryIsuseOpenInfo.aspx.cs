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

public partial class Home_Room_LotteryIsuseOpenInfo : SitePageBase, IRequiresSessionState
{
    private string dingZhi = "";

    private void BindDataForIsuses(int LotteryID)
    {
        string key = "Isuses";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Views.V_Isuses().Open("", "EndTime < GetDate() and IsOpened = 1", "EndTime desc");
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
        this.imgLogo.ImageUrl = "images/LotteryWinLogo/" + new Lottery()[LotteryID].code + ".jpg";
        int num2 = _Convert.StrToInt(Utility.GetRequest("IsuseID"), 0);
        if (this.ddlIsuses.Items.Count > 0)
        {
            if (this.ddlIsuses.Items.FindByValue(num2.ToString()) != null)
            {
                this.ddlIsuses.SelectedValue = num2.ToString();
            }
            this.ddlIsuses_SelectedIndexChanged(this.ddlIsuses, new EventArgs());
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
            this.ddlPlayTypes_SelectedIndexChanged(this.ddlPlayTypes, new EventArgs());
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
            if (Utility.FilteSqlInfusion(this.HidPlayType.Value) != "0")
            {
                cacheAsDataTable = MSSQL.Select("select * from V_SchemeSchedules where InitiateUserID <> 132011 and IsuseID = @IsuseID and WinMoney > 0 and QuashStatus = 0 and PlayTypeID = @PlayTypeID " + ((this.HidSearch.Value == "") ? "" : " and (InitiateName like @InitiateName or SchemeNumber like @InitiateName)") + " order by WinMoneyNoWithTax desc", new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.Int, 0, ParameterDirection.Input, Utility.FilteSqlInfusion(IsuseID.ToString())), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, Utility.FilteSqlInfusion(this.HidPlayType.Value)), new MSSQL.Parameter("InitiateName", SqlDbType.VarChar, 0, ParameterDirection.Input, "%" + Utility.FilteSqlInfusion(this.HidSearch.Value) + "%") });
            }
            else
            {
                cacheAsDataTable = MSSQL.Select("select * from V_SchemeSchedules where InitiateUserID <> 132011 and IsuseID = @IsuseID and WinMoney > 0 and QuashStatus = 0 " + ((this.HidSearch.Value == "") ? "" : " and (InitiateName like @InitiateName or SchemeNumber like @InitiateName)") + " order by WinMoneyNoWithTax desc", new MSSQL.Parameter[] { new MSSQL.Parameter("IsuseID", SqlDbType.Int, 0, ParameterDirection.Input, Utility.FilteSqlInfusion(IsuseID.ToString())), new MSSQL.Parameter("PlayTypeID", SqlDbType.Int, 0, ParameterDirection.Input, Utility.FilteSqlInfusion(this.HidPlayType.Value)), new MSSQL.Parameter("InitiateName", SqlDbType.VarChar, 0, ParameterDirection.Input, "%" + Utility.FilteSqlInfusion(this.HidSearch.Value) + "%") });
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
            string str3 = rowArray[i]["WinDescription"].ToString();
            table2.Rows[i]["WinDescription2"] = str3;
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
        StringBuilder builder = new StringBuilder();
        builder.Append("<tr>").Append("<td width='31%' height='36' align='left' class='black12'>").Append("第<span class='red'>").Append(num.ToString()).Append("/").Append(num6.ToString()).Append("</span>页 <span class='red'>").Append(num4.ToString()).Append("</span>条/页 共<span class='red'>").Append(count.ToString()).Append("</span>条").Append("</td>").Append("<td width='69%' align='right'>").Append("<table border='0' cellspacing='4' cellpadding='0'>").Append("<tbody style='text-align:center; width:20px;'>").Append("<tr>").Append("<td valign='middle' class='ball' onclick='showPage(1,").Append(LotteryID.ToString()).Append(",").Append(this.HidIsuseID.Value).Append(",").Append(this.HidPlayType.Value).Append(",\"").Append(HttpUtility.UrlEncode(this.HidSearch.Value)).Append("\");'>").Append("<img src='images/page_first.gif' width='9' height='8' />").Append("</td>").Append("<td class='ball' onclick='showPage(").Append(num9.ToString()).Append(",").Append(LotteryID.ToString()).Append(",").Append(this.HidIsuseID.Value).Append(",").Append(this.HidPlayType.Value).Append(",\"").Append(HttpUtility.UrlEncode(this.HidSearch.Value)).Append("\");'>").Append("<img src='images/page_previous.gif' width='9' height='8' />");
        for (int j = num8; (j < (num8 + num7)) && (j <= num6); j++)
        {
            builder.Append("</td>").Append("<td id='page_").Append(j.ToString()).Append("' class='ball").Append((num == j) ? "_r" : ((j <= num6) ? "" : "_c")).Append("'");
            if (j <= num6)
            {
                builder.Append(" onclick='showPage(").Append(j.ToString()).Append(",").Append(LotteryID.ToString()).Append(",").Append(this.HidIsuseID.Value).Append(",").Append(this.HidPlayType.Value).Append(",\"").Append(HttpUtility.UrlEncode(this.HidSearch.Value)).Append("\");'");
            }
            builder.Append(">").Append(j.ToString()).Append("</td>");
        }
        builder.Append("<td style='width:36px;'>").Append("<input type='text' class='ball_50' id='txtgopage' maxlength='").Append(num6.ToString().Length.ToString()).Append("' />").Append("</td>").Append("<td class='ball' onclick=\"showPage(document.getElementById('txtgopage').value,").Append(LotteryID.ToString()).Append(",").Append(this.HidIsuseID.Value).Append(",").Append(this.HidPlayType.Value).Append(",'").Append(HttpUtility.UrlEncode(this.HidSearch.Value)).Append("');\">").Append("<img src='images/page_go.gif' width='11' height='8' />").Append("</td>").Append("<td class='ball' onclick='showPage(").Append(num10.ToString()).Append(",").Append(LotteryID.ToString()).Append(",").Append(this.HidIsuseID.Value).Append(",").Append(this.HidPlayType.Value).Append(",\"").Append(HttpUtility.UrlEncode(this.HidSearch.Value)).Append("\");'>").Append("<img src='images/page_next.gif' width='9' height='8' />").Append("</td>").Append("<td class='ball' onclick='showPage(").Append(num6.ToString()).Append(",").Append(LotteryID.ToString()).Append(",").Append(this.HidIsuseID.Value).Append(",").Append(this.HidPlayType.Value).Append(",\"").Append(HttpUtility.UrlEncode(this.HidSearch.Value)).Append("\");'>").Append("<img src='images/page_last.gif' width='9' height='8' />").Append("</td>").Append("</tr>").Append("</tbody>").Append("</table>").Append("</td>").Append("</tr>");
        this.tbPaging.InnerHtml = builder.ToString();
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
        this.HidSearch.Value = ((this.tbSearch.Text.Trim() == "(可输入发起人ID或方案编号搜索)") || (this.tbSearch.Text.Trim() == "")) ? "" : this.tbSearch.Text.Trim();
        this.BindDataForWinDetail(int.Parse(this.HidLotteryID.Value), int.Parse(this.ddlIsuses.SelectedValue));
    }

    protected void ddlIsuses_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.lbIsuse.Text = this.ddlIsuses.SelectedItem.Text.Trim();
        this.HidIsuseID.Value = this.ddlIsuses.SelectedValue;
        string key = "Isuses";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Views.V_Isuses().Open("", "EndTime < GetDate() and IsOpened = 1", "EndTime desc");
            if ((cacheAsDataTable == null) || (cacheAsDataTable.Rows.Count < 1))
            {
                PF.GoError(7, "数据库繁忙，请重试", base.GetType().FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 600);
        }
        DataRow row = cacheAsDataTable.Select("ID = " + this.ddlIsuses.SelectedValue)[0];
        this.lbOpenDate.Text = Convert.ToDateTime(row["EndTime"]).ToString("yyyy年MM月dd日");
        this.lbGetPrizeEndTime.Text = Convert.ToDateTime(row["EndTime"]).AddDays(60.0).ToString("yyyy年MM月dd日");
        this.tbWinNumber.InnerHtml = this.FormatWinNumber(_Convert.StrToInt(this.HidLotteryID.Value, 5), row["WinLotteryNumber"].ToString());
        this.lbWinInfo.Text = row["OpenAffiche"].ToString();
        this.BindDataForPlayTypes(int.Parse(this.HidLotteryID.Value));
    }

    protected void ddlPlayTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.HidPlayType.Value = this.ddlPlayTypes.SelectedValue;
        this.BindDataForWinDetail(int.Parse(this.HidLotteryID.Value), int.Parse(this.HidIsuseID.Value));
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
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(winNumber.Substring(i, 1));
                        }
                        else if (i == (winNumber.Length - 1))
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(images/zfb_blueball.gif)'>").Append(winNumber.Substring(i, 1));
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
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(strArray3[j]);
                    }
                }
                break;

            case 0x3d:
            case 0x40:
                if (winNumber.Length > 0)
                {
                    for (int k = 0; k < winNumber.Length; k++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(winNumber.Substring(k, 1));
                    }
                }
                break;

            case 0x3e:
                if (winNumber.Length > 0)
                {
                    string[] strArray7 = winNumber.Split(new char[] { ' ' });
                    for (int m = 0; m < strArray7.Length; m++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(strArray7[m]);
                    }
                }
                break;

            case 0x3f:
                if (winNumber.Length > 0)
                {
                    for (int n = 0; n < winNumber.Length; n++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(winNumber.Substring(n, 1));
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
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(strArray8[num16]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(images/zfb_blueball.gif)'>").Append(strArray8[num16]);
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
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(strArray2[num6]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(images/zfb_blueball.gif)'>").Append(strArray2[num6]);
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
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(winNumber.Substring(num2, 1));
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
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(strArray[num3]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(images/zfb_blueball.gif)'>").Append(strArray[num3]);
                        }
                    }
                }
                break;

            case 6:
                if (winNumber.Length > 0)
                {
                    for (int num4 = 0; num4 < winNumber.Length; num4++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(winNumber.Substring(num4, 1));
                    }
                }
                break;

            case 9:
                if (winNumber.Length > 0)
                {
                    string[] strArray5 = winNumber.Split(new char[] { ' ' });
                    for (int num10 = 0; num10 < strArray5.Length; num10++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(strArray5[num10]);
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
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(strArray4[num9]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(images/zfb_blueball.gif)'>").Append(strArray4[num9]);
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
                            builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(strArray6[num11]);
                        }
                        else
                        {
                            builder.Append("</td><td align='center' class='white14' style='width: 25px;background-image: url(images/zfb_blueball.gif)'>").Append(strArray6[num11]);
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
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(winNumber.Substring(num14, 1));
                    }
                }
                break;

            case 0x1d:
                if (winNumber.Length > 0)
                {
                    for (int num5 = 0; num5 < winNumber.Length; num5++)
                    {
                        builder.Append("</td><td align='center' class='white14' style='width:25px;background-image: url(images/zfb_redball.gif)'>").Append(winNumber.Substring(num5, 1));
                    }
                }
                break;
        }
        return builder.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            int key = _Convert.StrToInt(Utility.GetRequest("LotteryID"), 5);
            if (!DataCache.Lotteries.ContainsKey(key))
            {
                key = DataCache.Lotteries.First().Key;
            }
            this.HidLotteryID.Value = key.ToString();
            this.HidSearch.Value = HttpUtility.UrlDecode(Utility.GetRequest("Search"));
            if (this.HidSearch.Value != "")
            {
                this.tbSearch.Text = this.HidSearch.Value;
            }
            this.BindDataForIsuses(key);
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
        string str = string.Concat(new object[] { "followScheme(", num2, ");$Id(\"iframeFollowScheme\").src=\"FollowFriendSchemeAdd.aspx?LotteryID=", num2, "&DzLotteryID=", num2 });
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
                        base.Response.Redirect("Buy_SSL.aspx?DZ=" + this.dingZhi);
                        return;

                    case 0x3e:
                        base.Response.Redirect("Buy_SYYDJ.aspx?DZ=" + this.dingZhi);
                        return;

                    case 0x3d:
                        base.Response.Redirect("Buy_SSC.aspx?DZ=" + this.dingZhi);
                        return;

                    case 1:
                    case 2:
                    case 15:
                        base.Response.Redirect(string.Concat(new object[] { "Buy_ZC.aspx?LotteryID=", lotteryID, "&DZ=", this.dingZhi }));
                        return;
                }
                base.Response.Redirect(string.Concat(new object[] { "Buy.aspx?LotteryID=", lotteryID, "&ID=", lotteryID, "&DZ=", this.dingZhi }));
            }
        }
    }
}

