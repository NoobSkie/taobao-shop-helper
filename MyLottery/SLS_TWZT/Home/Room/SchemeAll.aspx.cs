using ASP;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_SchemeAll : RoomPageBase, IRequiresSessionState
{

    private void BindData()
    {
        long num = _Convert.StrToLong(this.HidLotteryID.Value, 0L);
        long num2 = _Convert.StrToLong(Utility.FilteSqlInfusion(this.HidIsuseID.Value), 0L);
        string str = this.HidSearch.Value;
        string str2 = this.HidSort.Value;
        int num3 = _Convert.StrToInt(this.HidFilter.Value, 7);
        int num4 = _Convert.StrToInt(this.HidPageNumber.Value, 1);
        this.HidSortID.Value = this.HidSortID.Value;
        string key = "Home_Room_SchemeAll_BindData" + num2.ToString();
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("select a.ID,b.Name as InitiateName,AtTopStatus,b.Level,Money, c.Name as PlayTypeName, Share, BuyedShare, Schedule, AssureMoney, ").AppendLine("\tInitiateUserID, QuashStatus, PlayTypeID, Buyed, SecrecyLevel, EndTime, d.IsOpened, LotteryNumber,case Schedule when 100 then 1 else 0 end as IsFull ").AppendLine("from").AppendLine("\t(").AppendLine("\t\tselect ID, EndTime,IsOpened from T_Isuses where ID = @ID ").AppendLine("\t) as d").AppendLine("inner join T_Schemes a on a.IsuseID = d.ID").AppendLine("inner join T_Users b on a.InitiateUserID = b.ID").AppendLine("inner join T_PlayTypes c on a.PlayTypeID = c.ID").AppendLine("order by a.QuashStatus asc,IsFull asc, a.AtTopStatus desc, a.[Money] desc");
            cacheAsDataTable = MSSQL.Select(builder.ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.BigInt, 0, ParameterDirection.Input, num2.ToString()) });
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
                return;
            }
            if (num == 1L)
            {
                DataTable table2 = cacheAsDataTable.Clone();
                DataRow[] rowArray = null;
                if (this.HidNumber.Value == "9")
                {
                    rowArray = cacheAsDataTable.Select("PlayTypeID in (103,104)", "QuashStatus asc,IsFull asc, AtTopStatus desc, [Money] desc");
                }
                else
                {
                    rowArray = cacheAsDataTable.Select("PlayTypeID in (101,102)", "QuashStatus asc,IsFull asc, AtTopStatus desc, [Money] desc");
                }
                foreach (DataRow row in rowArray)
                {
                    table2.Rows.Add(row.ItemArray);
                }
                cacheAsDataTable = table2;
            }
            DataTable table3 = new DataTable();
            DataColumn[] columns = new DataColumn[cacheAsDataTable.Columns.Count];
            for (int k = 0; k < columns.Length; k++)
            {
                columns[k] = new DataColumn(cacheAsDataTable.Columns[k].ColumnName, typeof(string));
            }
            table3.Columns.AddRange(columns);
            table3.Columns["Money"].DataType = Type.GetType("System.Double");
            table3.Columns["Share"].DataType = Type.GetType("System.Int32");
            table3.Columns["Schedule"].DataType = Type.GetType("System.Double");
            foreach (DataRow row2 in cacheAsDataTable.Rows)
            {
                table3.Rows.Add(row2.ItemArray);
            }
            table3.Columns.Add("TmpID", Type.GetType("System.Int32"));
            table3.Columns.Add("EachMoney", typeof(string));
            table3.Columns.Add("Color", typeof(string));
            table3.Columns.Add("State", typeof(string));
            table3.Columns.Add("Join", typeof(string));
            for (int m = 0; m < cacheAsDataTable.Rows.Count; m++)
            {
                table3.Rows[m]["EachMoney"] = (_Convert.StrToDouble(cacheAsDataTable.Rows[m]["Money"].ToString(), 0.0) / _Convert.StrToDouble(cacheAsDataTable.Rows[m]["Share"].ToString(), 0.0)).ToString("N");
                table3.Rows[m]["Money"] = _Convert.StrToDouble(cacheAsDataTable.Rows[m]["Money"].ToString(), 0.0).ToString("N");
                table3.Rows[m]["Color"] = ((m % 2) > 0) ? "#F7FEFA" : "White";
                string str4 = cacheAsDataTable.Rows[m]["InitiateName"].ToString();
                if (str4.Length > 10)
                {
                    str4 = str4.Substring(0, 10);
                }
                if (_Convert.StrToDouble(cacheAsDataTable.Rows[m]["AssureMoney"].ToString(), 0.0) > 0.0)
                {
                    str4 = str4 + "<font color='#FF0065'>(保)</font>";
                }
                int num11 = _Convert.StrToInt(cacheAsDataTable.Rows[m]["Level"].ToString(), 0);
                if (num11 > 5)
                {
                    num11 = 5;
                }
                table3.Rows[m]["InitiateName"] = "<a style='cursor:hand' href='../Web/Score.aspx?id=" + cacheAsDataTable.Rows[m]["InitiateUserID"].ToString() + "&LotteryID=" + this.HidLotteryID.Value + "' title='点击查看历史战绩' target='_blank'>" + str4 + "</a>";
                if (num11 > 0)
                {
                    string[] strArray2 = new string[] { "<a style='cursor:hand' href='../Web/Score.aspx?id=", cacheAsDataTable.Rows[m]["InitiateUserID"].ToString(), "&LotteryID=", this.HidLotteryID.Value, "' title='点击查看历史战绩' target='_blank'> <div style='background-image:url(Images/gold.gif); width:", (9 * num11).ToString(), "px;background-repeat:repeat-x;'></div></a>" };
                    table3.Rows[m]["Level"] = string.Concat(strArray2);
                }
                else
                {
                    table3.Rows[m]["Level"] = "&nbsp;";
                }
                string str5 = table3.Rows[m]["ID"].ToString();
                string str6 = table3.Rows[m]["LotteryNumber"].ToString().Trim();
                short num13 = _Convert.StrToShort(table3.Rows[m]["QuashStatus"].ToString(), 0);
                bool flag = _Convert.StrToBool(table3.Rows[m]["Buyed"].ToString(), false);
                short num14 = _Convert.StrToShort(table3.Rows[m]["SecrecyLevel"].ToString(), 0);
                bool flag2 = _Convert.StrToDateTime(table3.Rows[m]["EndTime"].ToString(), DateTime.Now.ToString()) <= DateTime.Now;
                bool flag3 = _Convert.StrToBool(table3.Rows[m]["IsOpened"].ToString(), false);
                long num15 = _Convert.StrToLong(table3.Rows[m]["InitiateUserID"].ToString(), 0L);
                if (((num14 == 1) && !flag2) && ((base._User == null) || (((base._User != null) && (num15 != base._User.ID)) && !base._User.isOwnedViewSchemeCompetence())))
                {
                    table3.Rows[m]["LotteryNumber"] = "已保密，截止后公开";
                }
                else if (((num14 == 2) && !flag3) && ((base._User == null) || (((base._User != null) && (num15 != base._User.ID)) && !base._User.isOwnedViewSchemeCompetence())))
                {
                    table3.Rows[m]["LotteryNumber"] = "已保密，开奖后公开";
                }
                else if ((num14 == 3) && ((base._User == null) || (((base._User != null) && (num15 != base._User.ID)) && !base._User.isOwnedViewSchemeCompetence())))
                {
                    table3.Rows[m]["LotteryNumber"] = "已保密";
                }
                else if (str6.Length > 0x1c)
                {
                    table3.Rows[m]["LotteryNumber"] = "<a href='Scheme.aspx?id=" + str5.ToString() + "' target='_blank' title='点击查看方案详细信息'><font color=\"#FF0065\">投注内容</font></a>";
                }
                else if ((((num == 1L) || (num == 2L)) || (num == 15L)) && (str6 == ""))
                {
                    table3.Rows[m]["LotteryNumber"] = "<a href='Scheme.aspx?id=" + str5.ToString() + "' target='_blank'><font color=\"#FF0065\">未上传方案</font></a>";
                }
                else
                {
                    table3.Rows[m]["LotteryNumber"] = "<a href='Scheme.aspx?id=" + str5.ToString() + "' target='_blank' title='点击查看方案详细信息'>" + str6 + "</a>";
                }
                switch (num13)
                {
                    case 0:
                        goto Label_0A63;

                    case 2:
                        table3.Rows[m]["State"] = "<font color='blue'>撤单</font>";
                        break;

                    default:
                        table3.Rows[m]["State"] = "撤单";
                        break;
                }
                table3.Rows[m]["Join"] = "<Font color='#000000'>--</font>";
                continue;
            Label_0A63:
                if (flag)
                {
                    table3.Rows[m]["State"] = "<Font color='#FF0065'>已成功</font>";
                    table3.Rows[m]["Join"] = "<Font color='#000000'>--</font>";
                }
                else if (table3.Rows[m]["Schedule"].ToString() == "100")
                {
                    table3.Rows[m]["State"] = "<Font color='#FF0065'>满员</font>";
                    table3.Rows[m]["Join"] = "<Font color='#000000'>--</font>";
                }
                else if (flag2)
                {
                    table3.Rows[m]["State"] = "未成功";
                    table3.Rows[m]["Join"] = "<Font color='#000000'>--</font>";
                }
                else
                {
                    table3.Rows[m]["State"] = "未满";
                    table3.Rows[m]["Join"] = "<a href='Scheme.aspx?id=" + str5.ToString() + "' target='_blank' title='点击查看方案详细信息'><font color=\"#FF0065\">入伙</font></a>";
                }
            }
            cacheAsDataTable = table3;
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, ((this.HidLotteryID.Value == "29") || (this.HidLotteryID.Value == "62")) ? 60 : 600);
        }
        DataRow[] rowArray3 = null;
        if ((str != "") && (str != "输入用户名"))
        {
            rowArray3 = cacheAsDataTable.Select("InitiateName like '%" + Utility.FilteSqlInfusion(this.TxtName.Text.Trim()) + "%'");
        }
        switch (num3)
        {
            case 1:
                rowArray3 = cacheAsDataTable.Select("Convert([Money],System.Double) >= 1000");
                break;

            case 2:
                rowArray3 = cacheAsDataTable.Select("Convert([Money],System.Double) < 1000");
                break;

            case 3:
                rowArray3 = cacheAsDataTable.Select("Convert(Share,System.Int32) >= BuyedShare");
                break;

            case 4:
                rowArray3 = cacheAsDataTable.Select("Convert(Share,System.Int32) > BuyedShare");
                break;

            case 5:
                rowArray3 = cacheAsDataTable.Select("Convert(QuashStatus,System.Int32) <> 0");
                break;

            case 6:
                rowArray3 = cacheAsDataTable.Select("Convert(AssureMoney,System.Double) > 0");
                break;
        }
        if (str2 != "")
        {
            rowArray3 = cacheAsDataTable.Select("", str2 + " " + this.HidOrder.Value);
        }
        if (rowArray3 != null)
        {
            cacheAsDataTable = cacheAsDataTable.Clone();
            foreach (DataRow row3 in rowArray3)
            {
                cacheAsDataTable.Rows.Add(row3.ItemArray);
            }
        }
        int count = cacheAsDataTable.Rows.Count;
        for (int i = 0; i < count; i++)
        {
            cacheAsDataTable.Rows[i]["TmpID"] = i + 1;
        }
        int num20 = 20;
        int num21 = cacheAsDataTable.Rows.Count;
        int num22 = ((num21 % num20) == 0) ? (num21 / num20) : ((num21 / num20) + 1);
        if (num4 > num22)
        {
            num4 = num22;
        }
        int num23 = 10;
        int num24 = ((num4 % num23) == 0) ? ((num23 * ((num4 / num23) - 1)) + 1) : ((num23 * (num4 / num23)) + 1);
        int num25 = (((num24 / num23) + 1) == 1) ? 1 : ((num23 * ((num24 / num23) - 1)) + 1);
        int num26 = (num22 > (num23 * ((num4 / num23) + 2))) ? ((num23 * ((num4 / num23) + 1)) + 1) : num22;
        if ((num24 + num23) > num22)
        {
            num24 = (num22 - num23) + 1;
        }
        if (num24 <= 0)
        {
            num24 = 1;
        }
        DataRow[] rowArray5 = cacheAsDataTable.Select("TmpID > " + ((num20 * (num4 - 1))).ToString() + " and TmpID < " + (((num20 * num4) + 1)).ToString());
        DataTable table4 = cacheAsDataTable.Clone();
        foreach (DataRow row4 in rowArray5)
        {
            table4.Rows.Add(row4.ItemArray);
        }
        this.rptSchemes.DataSource = table4;
        this.rptSchemes.DataBind();
        StringBuilder builder2 = new StringBuilder();
        builder2.Append("<tr>").Append("<td width='31%' height='36' align='left' class='black12'>").Append("第<span class='red'>").Append(num4.ToString()).Append("/").Append(num22.ToString()).Append("</span>页 <span class='red'>").Append(num20.ToString()).Append("</span>条/页 共<span class='red'>").Append(num21.ToString()).Append("</span>条").Append("</td>").Append("<td width='69%' align='right'>").Append("<table border='0' cellspacing='4' cellpadding='0'>").Append("<tbody style='text-align:center; width:20px;'>").Append("<tr>").Append("<td valign='middle' class='ball' onclick='showPage(1);'>").Append("<img src='images/page_first.gif' width='9' height='8' />").Append("</td>").Append("<td class='ball' onclick='showPage(").Append(num25.ToString()).Append(");'>").Append("<img src='images/page_previous.gif' width='9' height='8' />");
        for (int j = num24; (j < (num24 + num23)) && (j <= num22); j++)
        {
            builder2.Append("</td>").Append("<td id='page_").Append(j.ToString()).Append("' class='ball").Append((num4 == j) ? "_r" : ((j <= num22) ? "" : "_c")).Append("'");
            if (j <= num22)
            {
                builder2.Append(" onclick='showPage(").Append(j.ToString()).Append(");'");
            }
            builder2.Append(">").Append(j.ToString()).Append("</td>");
        }
        builder2.Append("<td class='ball' onclick='showPage(").Append(num26.ToString()).Append(");'>").Append("<img src='images/page_3.gif' width='9' height='8' />").Append("</td>").Append("<td class='ball' onclick='showPage(").Append(num22.ToString()).Append(");'>").Append("<img src='images/page_4.gif' width='9' height='8' />").Append("</td>").Append("<td >").Append("<input type='text' class='ball_50' id='txtgopage' maxlength='").Append(num22.ToString().Length.ToString()).Append("' />").Append("</td>").Append("<td style='width:25px; height=5; font-family:tahoma;font-weight:bold; color:#FFFFFF; cursor:hand; background:#6B96CB;font-size: 13px;' onclick=\"showPage(document.getElementById('txtgopage').value);\">").Append("GO").Append("</td>").Append("</tr>").Append("</tbody>").Append("</table>").Append("</td>").Append("</tr>");
        this.tbPaging.InnerHtml = builder2.ToString();
    }

    protected void btnPaging_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.HidSearch.Value = Utility.FilteSqlInfusion(this.TxtName.Text.Trim());
        this.HidSort.Value = "";
        this.HidPageNumber.Value = "1";
        this.HidFilter.Value = "";
        this.BindData();
    }

    protected void btnSorting_Click(object sender, EventArgs e)
    {
        if (this.HidOrder.Value == "")
        {
            this.HidOrder.Value = "asc";
        }
        else if (this.HidOrder.Value == "asc")
        {
            this.HidOrder.Value = "desc";
        }
        else
        {
            this.HidOrder.Value = "asc";
        }
        this.BindData();
    }

    protected void btnType_1_Click(object sender, EventArgs e)
    {
        this.HidFilter.Value = ((LinkButton)sender).ID.Substring(8, 1);
        this.HidOrder.Value = "";
        this.HidSort.Value = "";
        this.HidPageNumber.Value = "1";
        this.BindData();
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.isRequestLogin = false;
        base.isAtFramePageLogin = false;
        base.isAllowPageCache = true;
        base.PageCacheSeconds = 60;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.HidIsuseID.Value = Utility.GetRequest("IsuseID");
            this.HidLotteryID.Value = Utility.GetRequest("LotteryID");
            this.HidNumber.Value = Utility.GetRequest("Number");
            this.BindData();
        }
    }
}

