using ASP;
using DAL;
using Shove;
using Shove._IO;
using Shove._Security;
using Shove._Web;
using Shove.Web.UI;
using SLS;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

public partial class Admin_PrintOutput : AdminPageBase, IRequiresSessionState
{

    private void BindData()
    {
        if (this.ddlIsuse.Items.Count >= 1)
        {
            DataTable table = new Views.V_SchemeSchedules().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue) + " and Schedule >= 100 and QuashStatus = 0 and Buyed = 0 and isOpened = 0", "[Money] desc");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_PrintOutput");
            }
            else
            {
                table.Columns.Add("LocateWaysAndMultiples", Type.GetType("System.String"));
                string buyContent = "";
                string cnLocateWaysAndMultiples = "";
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i]["Money"] = double.Parse(table.Rows[i]["Money"].ToString()).ToString("N");
                    if (new Lottery()["45"].CheckPlayType(int.Parse(table.Rows[i]["PlayTypeID"].ToString())))
                    {
                        table.Rows[i]["Multiple"] = 0;
                        try
                        {
                            buyContent = "";
                            cnLocateWaysAndMultiples = "";
                            string str3 = "";
                            string scheme = table.Rows[i]["LotteryNumber"].ToString();
                            if (new Lottery()["45"].GetSchemeSplit(scheme, ref buyContent, ref cnLocateWaysAndMultiples))
                            {
                                string vote = "";
                                DataTable table2 = PF.GetZCDCBuyContent(scheme, _Convert.StrToLong(table.Rows[i]["ID"].ToString(), -1L), ref vote);
                                if (table2 == null)
                                {
                                    PF.GoError(4, "数据访问错误", base.GetType().BaseType.FullName);
                                    return;
                                }
                                foreach (DataRow row in table2.Rows)
                                {
                                    if (str3 == "")
                                    {
                                        string str6 = str3;
                                        str3 = str6 + row["No"].ToString() + " " + row["LeagueTypeName"].ToString() + " " + row["HostTeam"].ToString() + " VS " + row["QuestTeam"].ToString() + " " + row["Content"].ToString() + " " + row["LotteryResult"].ToString();
                                    }
                                    else
                                    {
                                        string str7 = str3;
                                        str3 = str7 + "<br />" + row["No"].ToString() + " " + row["LeagueTypeName"].ToString() + " " + row["HostTeam"].ToString() + " VS " + row["QuestTeam"].ToString() + " " + row["Content"].ToString() + " " + row["LotteryResult"].ToString();
                                    }
                                }
                                table.Rows[i]["LocateWaysAndMultiples"] = cnLocateWaysAndMultiples;
                            }
                            else
                            {
                                table.Rows[i]["LocateWaysAndMultiples"] = "<font color='red'>读取错误！</font>";
                            }
                        }
                        catch
                        {
                            table.Rows[i]["LocateWaysAndMultiples"] = "<font color='red'>读取错误！</font>";
                        }
                    }
                    table.AcceptChanges();
                }
                this.g.DataSource = table;
                this.g.DataBind();
                this.btnDownload.Enabled = table.Rows.Count > 0;
                this.btnDownload_txt.Enabled = table.Rows.Count > 0;
                this.btnBuyAll.Visible = table.Rows.Count > 0;
                this.fileUp.Disabled = table.Rows.Count < 1;
                this.btnUpload.Enabled = table.Rows.Count > 0;
            }
        }
    }

    private void BindDataForIsuse()
    {
        DataTable dt = new Tables.T_Isuses().Open("[ID], [Name]", "LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue) + " and StartTime < GetDate() and IsOpened = 0", "EndTime");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_PrintOutput");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlIsuse, dt, "Name", "ID");
            this.g.Visible = this.ddlIsuse.Items.Count > 0;
        }
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ")", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", "Admin_PrintOutput");
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
        }
    }

    protected void btnBuyAll_Click(object sender, EventArgs e)
    {
        if (this.g.Items.Count < 0)
        {
            JavaScript.Alert(this.Page, "没有数据。");
        }
        else
        {
            int returnValue = -1;
            string returnDescription = "";
            int num2 = 0;
            int num3 = 0;
            foreach (DataListItem item in this.g.Items)
            {
                long siteID = _Convert.StrToLong(((HtmlInputHidden)item.FindControl("tbSiteID")).Value, -1L);
                long schemeID = _Convert.StrToLong(((HtmlInputHidden)item.FindControl("tbID")).Value, -1L);
                if ((siteID < 1L) || (schemeID < 1L))
                {
                    num2++;
                    continue;
                }
                returnDescription = "";
                if (Procedures.P_SchemePrintOut(siteID, schemeID, base._User.ID, 0, "请电询", true, ref returnValue, ref returnDescription) < 0)
                {
                    num2++;
                }
                else
                {
                    if (returnValue < 0)
                    {
                        num2++;
                        continue;
                    }
                    num3++;
                }
            }
            this.BindData();
            JavaScript.Alert(this.Page, string.Format("操作完成，其中成功出票 {0} 个方案，失败 {1} 个方案。", num3, num2));
        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        DataTable table = new Views.V_Isuses().Open("", "[id] = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue), "");
        if ((table == null) || (table.Rows.Count < 1))
        {
            PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
        }
        else
        {
            string str = table.Rows[0]["Code"].ToString() + table.Rows[0]["Name"].ToString() + ".xls";
            table = new Views.V_SchemeSchedules().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue) + " and Schedule >= 100 and QuashStatus = 0 and Buyed = 0", "[Money] desc");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
            }
            else if (table.Rows.Count < 1)
            {
                JavaScript.Alert(this.Page, "没有数据。");
            }
            else
            {
                HttpResponse response = this.Page.Response;
                response.AppendHeader("Content-Disposition", "attachment;filename=" + str);
                base.Response.ContentType = "application/ms-excel";
                response.ContentEncoding = Encoding.GetEncoding("gb2312");
                response.Write("站点编号\t内部编号\t方案编号\t类别\t购买内容\t倍数\t金额\t彩票标识号\n");
                foreach (DataRow row in table.Rows)
                {
                    string str2 = "";
                    try
                    {
                        str2 = "| " + row["LotteryNumber"].ToString().Replace("\r\n", " | ") + " |";
                    }
                    catch
                    {
                    }
                    response.Write(row["SiteID"].ToString() + "\t" + row["ID"].ToString() + "\t" + row["SchemeNumber"].ToString() + "\t" + row["PlayTypeName"].ToString() + "\t" + str2 + "\t" + row["Multiple"].ToString() + "\t" + row["Money"].ToString() + "\t<请输入标识号>\n");
                }
                response.End();
            }
        }
    }

    protected void btnDownload_txt_Click(object sender, EventArgs e)
    {
        DataTable table = new Views.V_Isuses().Open("", "[ID] = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue), "");
        if ((table == null) || (table.Rows.Count < 1))
        {
            PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
        }
        else
        {
            string str = table.Rows[0]["Code"].ToString() + table.Rows[0]["Name"].ToString() + ".txt";
            table = new Views.V_SchemeSchedules().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue) + " and Schedule >= 100 and QuashStatus = 0 and Buyed = 0", "[Money] desc");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
            }
            else if (table.Rows.Count < 1)
            {
                JavaScript.Alert(this.Page, "没有数据。");
            }
            else
            {
                HttpResponse response = this.Page.Response;
                response.AppendHeader("Content-Disposition", "attachment;filename=" + str);
                base.Response.ContentType = "application/ms-txt";
                response.ContentEncoding = Encoding.GetEncoding("utf-8");
                foreach (DataRow row in table.Rows)
                {
                    string s = row["LotteryNumber"].ToString();
                    response.Write("***********************************************\r\n");
                    response.Write("站点编号: " + row["SiteID"].ToString() + "\r\n");
                    response.Write("方案编号: " + row["SchemeNumber"].ToString() + "\t内部编号:" + row["ID"].ToString() + "\r\n");
                    response.Write("方案类别: " + row["PlayTypeName"].ToString() + "\r\n");
                    response.Write("方案倍数: " + row["Multiple"].ToString() + "\t方案金额:" + double.Parse(row["Money"].ToString()).ToString("N") + "\r\n");
                    response.Write("***********************************************\r\n");
                    response.Write(s);
                    response.Write("\r\n\r\n\r\n");
                }
                response.End();
            }
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string newFileName = "";
        if (Shove._IO.File.UploadFile(this.Page, this.fileUp, "../Temp/", ref newFileName, "execl") != 0)
        {
            JavaScript.Alert(this.Page, "文件上传失败。");
        }
        else
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + base.Server.MapPath("../Temp/" + newFileName) + ";Extended Properties=Excel 8.0;");
            try
            {
                connection.Open();
            }
            catch
            {
                System.IO.File.Delete(this.Page.Server.MapPath("../Temp/" + newFileName));
                JavaScript.Alert(this.Page, "上传的文件读取错误。");
                return;
            }
            DataTable oleDbSchemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            OleDbCommand command = new OleDbCommand("select 站点编号 as SiteID, 内部编号 as [id], 彩票标识号 as LotteryCode from [" + oleDbSchemaTable.Rows[0][2].ToString().Trim() + "]", connection);
            OleDbDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
            }
            catch
            {
                connection.Close();
                System.IO.File.Delete(this.Page.Server.MapPath("../Temp/" + newFileName));
                JavaScript.Alert(this.Page, "上传的文件数据格式不正确。");
                return;
            }
            int num = 0;
            int num2 = 0;
            while (reader.Read())
            {
                long siteID = _Convert.StrToLong(reader["SiteID"].ToString(), -1L);
                long schemeID = _Convert.StrToLong(reader["id"].ToString(), -1L);
                string identifiers = reader["LotteryCode"].ToString().Trim();
                if ((siteID < 1L) || (schemeID < 1L))
                {
                    num2++;
                }
                else
                {
                    switch (identifiers)
                    {
                        case "":
                        case "<请输入标识号>":
                            identifiers = "请电询";
                            break;
                    }
                    int returnValue = -1;
                    string returnDescription = "";
                    if (Procedures.P_SchemePrintOut(siteID, schemeID, base._User.ID, 0, identifiers, true, ref returnValue, ref returnDescription) < 0)
                    {
                        num2++;
                    }
                    else
                    {
                        if (returnValue < 0)
                        {
                            num2++;
                            continue;
                        }
                        num++;
                    }
                }
            }
            reader.Close();
            connection.Close();
            this.BindData();
            System.IO.File.Delete(this.Page.Server.MapPath("../Temp/" + newFileName));
            JavaScript.Alert(this.Page, string.Format("操作完成，其中成功出票 {0} 个方案，失败 {1} 个方案。", num, num2));
        }
    }

    protected void ddlIsuse_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindDataForIsuse();
        this.BindData();
    }

    protected void g_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "btnBuy")
        {
            string identifiers = ((TextBox)e.Item.FindControl("tbLotteryCode")).Text.Trim();
            int returnValue = -1;
            string returnDescription = "";
            if (Procedures.P_SchemePrintOut(_Convert.StrToLong(((HtmlInputHidden)e.Item.FindControl("tbSiteID")).Value, -1L), _Convert.StrToLong(((HtmlInputHidden)e.Item.FindControl("tbID")).Value, -1L), base._User.ID, 0, identifiers, true, ref returnValue, ref returnDescription) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
            }
            else if (returnValue < 0)
            {
                PF.GoError(1, returnDescription, this.Page.GetType().BaseType.FullName);
            }
            else
            {
                this.BindData();
            }
        }
        else if (e.CommandName == "btnSerach")
        {
            long schemeID = _Convert.StrToLong(((HtmlInputHidden)e.Item.FindControl("tbID")).Value, -1L);
            DataTable table = new Tables.T_SchemesSendToCenter().Open("top 1 *", "schemeid=" + schemeID.ToString() + " and (Sends > 0) AND (Sends < 100)", "ID");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
            }
            else if (table.Rows.Count < 1)
            {
                JavaScript.Alert(this.Page, "此方案暂未拆票．");
            }
            else
            {
                SystemOptions options = new SystemOptions();
                string url = options["ElectronTicket_HPSD_Getway"].Value.ToString();
                string str4 = options["ElectronTicket_HPSD_UserName"].Value.ToString();
                string str5 = options["ElectronTicket_HPSD_UserPassword"].Value.ToString();
                int timeoutSeconds = 120;
                string str6 = table.Rows[0]["Identifiers"].ToString();
                string str7 = "<body><ticketQuery><ticket id=\"" + str6 + "\"/></ticketQuery></body>";
                string str8 = str4 + DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss") + "99";
                string str9 = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmmss");
                string str10 = "<?xml version=\"1.0\" encoding=\"GBK\"?>";
                str10 = (((((((str10 + "<message version=\"1.0\" id=\"" + str8 + "\">") + "<header>") + "<messengerID>" + str4 + "</messengerID>") + "<timestamp>" + str9 + "</timestamp>") + "<transactionType>105</transactionType>") + "<digest>" + Encrypt.MD5(str8 + str9 + str5 + str7, "gb2312") + "</digest>") + "</header>") + str7 + "</message>";
                new Log("System").Write("105|transType=105&transMessage=" + str10);
                string str11 = "";
                try
                {
                    str11 = Post(url, "transType=105&transMessage=" + str10, timeoutSeconds);
                }
                catch
                {
                    return;
                }
                if (str11.Length > 10)
                {
                    string[] strArray = str11.Split(new char[] { '&' });
                    if ((strArray != null) && (strArray.Length >= 1))
                    {
                        string str12 = strArray[0];
                        string s = strArray[1];
                        str12 = str12.Substring(10);
                        s = s.Substring(13);
                        new Log("System").Write(str12 + "|" + str11);
                        XmlDocument document = new XmlDocument();
                        XmlNodeList elementsByTagName = null;
                        try
                        {
                            document.Load(new StringReader(s));
                            elementsByTagName = document.GetElementsByTagName("ticket");
                        }
                        catch
                        {
                        }
                        if (elementsByTagName != null)
                        {
                            for (int i = 0; i < elementsByTagName.Count; i++)
                            {
                                string str14 = elementsByTagName[i].Attributes["id"].Value;
                                string str15 = elementsByTagName[i].Attributes["status"].Value;
                                string msg = elementsByTagName[i].Attributes["message"].Value;
                                if (str15 == "0000")
                                {
                                    string str = elementsByTagName[i].Attributes["dealTime"].Value;
                                    int num6 = 0;
                                    string str18 = "";
                                    if ((Procedures.P_SchemesSendToCenterHandleUniteAnte(schemeID, DateTime.Now, false, ref num6, ref str18) < 0) || (num6 < 0))
                                    {
                                        JavaScript.Alert(this.Page, "对所查询到的电子票数据第一次处理出错(QueryTickets)：数据读写错误。票号：" + str14 + "，" + str18);
                                        new Log("System").Write("对所查询到的电子票数据第一次处理出错(QueryTickets)：数据读写错误。票号：" + str14 + "，" + str18);
                                        Thread.Sleep(0x3e8);
                                        num6 = 0;
                                        str18 = "";
                                        if ((Procedures.P_SchemesSendToCenterHandleUniteAnte(schemeID, _Convert.StrToDateTime(str, DateTime.Now.ToString()), false, ref num6, ref str18) < 0) || (num6 < 0))
                                        {
                                            JavaScript.Alert(this.Page, "对所查询到的电子票数据第二次处理出错(QueryTickets)：数据读写错误。票号：" + str14 + "，" + str18);
                                            new Log("System").Write("对所查询到的电子票数据第二次处理出错(QueryTickets)：数据读写错误。票号：" + str14 + "，" + str18);
                                        }
                                    }
                                }
                                else
                                {
                                    JavaScript.Alert(this.Page, msg);
                                    Tables.T_SchemesSendToCenter center = new Tables.T_SchemesSendToCenter();
                                    if ("0010 0011 0012 0014 0015 0016 0098 0097 1008 1009 1010 1012 1013 1016 1017 2001 2002 2003 2004 2010 2011 2012 2013 2014 2015 2016 2017 2018 2030 2031 2040 2041 2042 -1 2043 2044 2046 3000 3002 3003 3004 3005 3010 3011 3012 3013 3014 3015 3220 3221 3222 3223 3224 3225 9001 9002 9003 9004 9005 9006 9007 4001 4002 4003 4004 4005 4006 4007".IndexOf(str15) >= 0)
                                    {
                                        center.Sends.Value = str15 + 100;
                                        center.Update("SchemeID = " + schemeID.ToString());
                                        this.BindData();
                                        return;
                                    }
                                    if (str15 == "2052")
                                    {
                                        Thread.Sleep(0x3e8);
                                        this.BindData();
                                        return;
                                    }
                                    if (str15 == "2032")
                                    {
                                        center.Sends.Value = "99";
                                        center.Update("SchemeID = " + schemeID.ToString());
                                        this.BindData();
                                        return;
                                    }
                                }
                            }
                            this.BindData();
                        }
                    }
                }
            }
        }
    }

    protected void g_ItemDataBound(object sender, DataListItemEventArgs e)
    {
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "LotteryBuy", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForLottery();
            this.BindDataForIsuse();
            this.BindData();
            this.btnBuyAll.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "LotteryBuy" }));
        }
    }

    private static string Post(string Url, string RequestString, int TimeoutSeconds)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        if (TimeoutSeconds > 0)
        {
            request.Timeout = 0x3e8 * TimeoutSeconds;
        }
        request.Method = "POST";
        request.AllowAutoRedirect = true;
        byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(RequestString);
        request.ContentType = "application/x-www-form-urlencoded";
        request.Accept = "";
        Stream requestStream = request.GetRequestStream();
        requestStream.Write(bytes, 0, bytes.Length);
        requestStream.Close();
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        response.Headers.Get("Content-Type");
        StreamReader reader = null;
        reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GBK"));
        return reader.ReadToEnd();
    }


    protected void g_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

