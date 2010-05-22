using ASP;
using DAL;
using FreeTextBoxControls;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using SLS;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Open : AdminPageBase, IRequiresSessionState
{
    private bool Step1IsOpen;
    private bool Step2IsOpen;

    private void BindDataForIsuse()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            string str = "";
            if (this.ddlLottery.SelectedValue != "45")
            {
                str = "and EndTime < GetDate()";
            }
            DataTable dt = new Tables.T_Isuses().Open("[ID], [Name]", "LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue) + str + " and isOpened = 0", "EndTime");
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                ControlExt.FillDropDownList(this.ddlIsuse, dt, "Name", "ID");
                if (this.ddlIsuse.Items.Count > 0)
                {
                    if (this.ddlLottery.SelectedValue == "45")
                    {
                        this.BindDataForZCDC();
                        this.WinNumberZCDC.Visible = true;
                        this.WinNumberOther.Visible = false;
                        this.tbOpenAffiche.ReadOnly = false;
                        this.btnGO.Visible = true;
                        this.btnGO.Enabled = true;
                        this.btnGO_Step1.Visible = true;
                        this.btnGO_Step1.Enabled = true;
                        this.btnGO_Step2.Visible = true;
                        this.btnGO_Step2.Enabled = false;
                        this.btnGO_Step3.Visible = true;
                        this.btnGO_Step3.Enabled = false;
                    }
                    else
                    {
                        this.WinNumberZCDC.Visible = false;
                        this.WinNumberOther.Visible = true;
                        this.tbOpenAffiche.ReadOnly = false;
                        this.btnGO.Enabled = true;
                        this.btnGO_Step1.Enabled = true;
                        this.btnGO_Step2.Enabled = false;
                        this.btnGO_Step3.Enabled = false;
                        this.tbWinNumber.Enabled = true;
                    }
                }
                else
                {
                    this.WinNumberZCDC.Visible = false;
                    this.WinNumberOther.Visible = true;
                    this.tbOpenAffiche.ReadOnly = true;
                    this.btnGO.Enabled = false;
                    this.btnGO_Step1.Enabled = false;
                    this.btnGO_Step2.Enabled = false;
                    this.btnGO_Step3.Enabled = false;
                    this.tbWinNumber.Enabled = false;
                }
            }
        }
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (" + ((base._Site.UseLotteryListRestrictions == "") ? "-1" : base._Site.UseLotteryListRestrictions) + ")", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
            if (this.ddlLottery.Items.Count < 1)
            {
                this.tbOpenAffiche.ReadOnly = true;
                this.btnGO.Enabled = false;
                this.btnGO_Step1.Enabled = false;
                this.btnGO_Step2.Enabled = false;
                this.btnGO_Step3.Enabled = false;
                this.tbWinNumber.Enabled = false;
            }
            else
            {
                this.ddlLottery_SelectedIndexChanged(this.ddlLottery, new EventArgs());
            }
        }
    }

    private void BindDataForWinMoney()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable table = new Tables.T_WinTypes().Open("", "LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue), "[Order]");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                this.g.DataSource = table.DefaultView;
                this.g.DataBind();
            }
        }
    }

    private void BindDataForZCDC()
    {
        if (_Convert.StrToLong(this.ddlIsuse.SelectedValue, -1L) > 0L)
        {
            DataTable table = new Views.V_IsuseForZCDC().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue) + "and DateTime < getdate()", "[No]");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                this.DataListZCDC.DataSource = table.DefaultView;
                this.DataListZCDC.DataBind();
            }
        }
    }

    protected void btnGO_Click(object sender, EventArgs e)
    {
        if (this.ddlLottery.SelectedValue == "45")
        {
            this.btnGO_ClickForZCDC();
        }
        else
        {
            this.tbWinNumber.Text = _Convert.ToDBC(this.tbWinNumber.Text.Trim().Replace("　", " ")).Trim();
            if (!new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].AnalyseWinNumber(this.tbWinNumber.Text))
            {
                JavaScript.Alert(this.Page, "开奖号码不正确！");
            }
            else
            {
                SystemOptions options = new SystemOptions();
                bool flag = options["isCompareWinMoneyNoWithFax"].ToBoolean(true);
                double[] winMoneyList = new double[this.g.Rows.Count * 2];
                for (int i = 0; i < this.g.Rows.Count; i++)
                {
                    winMoneyList[i * 2] = _Convert.StrToDouble(((TextBox)this.g.Rows[i].Cells[1].FindControl("tbMoney")).Text, 0.0);
                    winMoneyList[(i * 2) + 1] = _Convert.StrToDouble(((TextBox)this.g.Rows[i].Cells[2].FindControl("tbMoneyNoWithTax")).Text, 0.0);
                    if (winMoneyList[i * 2] < 0.0)
                    {
                        JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 项奖金输入错误！");
                        return;
                    }
                    if ((winMoneyList[i * 2] < winMoneyList[(i * 2) + 1]) && flag)
                    {
                        JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 项税后奖金输入错误(不能大于税前奖金)！");
                        return;
                    }
                }
                if (_Convert.ToTextCode(this.tbOpenAffiche.Text.Trim()) == "")
                {
                    JavaScript.Alert(this.Page, "请输入开奖公告！");
                }
                else
                {
                    DataTable table = new Tables.T_Schemes().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue) + " and isOpened = 0", "[ID]");
                    if (table == null)
                    {
                        PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                    }
                    else
                    {
                        for (int j = 0; j < table.Rows.Count; j++)
                        {
                            string number = table.Rows[j]["LotteryNumber"].ToString();
                            string description = "";
                            double winMoneyNoWithTax = 0.0;
                            double num6 = new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].ComputeWin(number, this.tbWinNumber.Text.Trim(), ref description, ref winMoneyNoWithTax, int.Parse(table.Rows[j]["PlayTypeID"].ToString()), winMoneyList);
                            MSSQL.ExecuteNonQuery("update T_Schemes set PreWinMoney = @p1, PreWinMoneyNoWithTax = @p2, EditWinMoney = @p3, EditWinMoneyNoWithTax = @p4, WinDescription = @p5 where [ID] = " + table.Rows[j]["ID"].ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("p1", SqlDbType.Money, 0, ParameterDirection.Input, num6 * _Convert.StrToInt(table.Rows[j]["Multiple"].ToString(), 1)), new MSSQL.Parameter("p2", SqlDbType.Money, 0, ParameterDirection.Input, winMoneyNoWithTax * _Convert.StrToInt(table.Rows[j]["Multiple"].ToString(), 1)), new MSSQL.Parameter("p3", SqlDbType.Money, 0, ParameterDirection.Input, num6 * _Convert.StrToInt(table.Rows[j]["Multiple"].ToString(), 1)), new MSSQL.Parameter("p4", SqlDbType.Money, 0, ParameterDirection.Input, winMoneyNoWithTax * _Convert.StrToInt(table.Rows[j]["Multiple"].ToString(), 1)), new MSSQL.Parameter("p5", SqlDbType.VarChar, 0, ParameterDirection.Input, description) });
                        }
                        JavaScript.Alert(this.Page, "奖金已经计算完成，请执行第三步进行派奖!。");
                        this.BindDataForIsuse();
                    }
                }
            }
        }
    }

    private void btnGO_ClickForZCDC()
    {
        if (_Convert.ToTextCode(this.tbOpenAffiche.Text.Trim()) == "")
        {
            JavaScript.Alert(this.Page, "请输入开奖公告！");
        }
        else
        {
            DataTable table = MSSQL.Select("select * from T_IsuseForZCDC where IsuseID = " + this.ddlIsuse.SelectedValue + " order by [NO]", new MSSQL.Parameter[0]);
            if ((table == null) || (table.Rows.Count < 1))
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                int count = table.Rows.Count;
                string number = "";
                string str2 = "";
                string str3 = "";
                string str4 = "";
                string str5 = "";
                string str6 = "";
                for (int i = 0; i < count; i++)
                {
                    if (((table.Rows[i]["Result"].ToString() == "") || (table.Rows[i]["SPFResult"].ToString() == "")) || (table.Rows[i]["SPF_SP"].ToString() == ""))
                    {
                        JavaScript.Alert(this.Page, "第" + table.Rows[i]["No"].ToString() + "场比赛的彩果没有输入！请先输入！！");
                        return;
                    }
                    string str7 = str2;
                    str2 = str7 + table.Rows[i]["No"].ToString() + "(" + _Convert.ToDBC(table.Rows[i]["SPFResult"].ToString()).Trim() + "," + _Convert.ToDBC(table.Rows[i]["SPF_SP"].ToString()).Trim() + ")|";
                    string str8 = str3;
                    str3 = str8 + table.Rows[i]["No"].ToString() + "(" + _Convert.ToDBC(table.Rows[i]["ZJQResult"].ToString()).Trim() + "," + _Convert.ToDBC(table.Rows[i]["ZJQ_SP"].ToString()).Trim() + ")|";
                    string str9 = str4;
                    str4 = str9 + table.Rows[i]["No"].ToString() + "(" + _Convert.ToDBC(table.Rows[i]["SXDSResult"].ToString()).Trim() + "," + _Convert.ToDBC(table.Rows[i]["SXDS_SP"].ToString()).Trim() + ")|";
                    string str10 = str5;
                    str5 = str10 + table.Rows[i]["No"].ToString() + "(" + _Convert.ToDBC(table.Rows[i]["ZQBFResult"].ToString()).Trim() + "," + _Convert.ToDBC(table.Rows[i]["ZQBF_SP"].ToString()).Trim() + ")|";
                    string str11 = str6;
                    str6 = str11 + table.Rows[i]["No"].ToString() + "(" + _Convert.ToDBC(table.Rows[i]["BQCSPFResult"].ToString()).Trim() + "," + _Convert.ToDBC(table.Rows[i]["BQCSPF_SP"].ToString()).Trim() + ")|";
                }
                str2 = str2.Substring(0, str2.Length - 1);
                str3 = str3.Substring(0, str3.Length - 1);
                str4 = str4.Substring(0, str4.Length - 1);
                str5 = str5.Substring(0, str5.Length - 1);
                str6 = str6.Substring(0, str6.Length - 1);
                number = str2 + ";" + str3 + ";" + str4 + ";" + str5 + ";" + str6;
                if (!new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].AnalyseWinNumber(number, table.Rows.Count))
                {
                    JavaScript.Alert(this.Page, "开奖号码不正确！");
                }
                else
                {
                    DataTable table2 = new Tables.T_Schemes().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue) + " and isOpened = 0", "");
                    if (table2 == null)
                    {
                        PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                    }
                    else
                    {
                        for (int j = 0; j < table2.Rows.Count; j++)
                        {
                            string scheme = table2.Rows[j]["LotteryNumber"].ToString();
                            int playType = _Convert.StrToInt(scheme.Trim().Split(new char[] { ';' })[0].ToString(), 0);
                            string description = "";
                            double winMoneyNoWithTax = 0.0;
                            double num6 = new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].ComputeWin(scheme, number, ref description, ref winMoneyNoWithTax, playType, count, "");
                            MSSQL.ExecuteNonQuery("update T_Schemes set PreWinMoney = @p1, PreWinMoneyNoWithTax = @p2, EditWinMoney = @p3, EditWinMoneyNoWithTax = @p4, WinDescription = @p5 where [ID] = " + table2.Rows[j]["ID"].ToString(), new MSSQL.Parameter[] { new MSSQL.Parameter("p1", SqlDbType.Money, 0, ParameterDirection.Input, num6 * _Convert.StrToInt(table2.Rows[j]["Multiple"].ToString(), 1)), new MSSQL.Parameter("p2", SqlDbType.Money, 0, ParameterDirection.Input, winMoneyNoWithTax * _Convert.StrToInt(table2.Rows[j]["Multiple"].ToString(), 1)), new MSSQL.Parameter("p3", SqlDbType.Money, 0, ParameterDirection.Input, num6 * _Convert.StrToInt(table2.Rows[j]["Multiple"].ToString(), 1)), new MSSQL.Parameter("p4", SqlDbType.Money, 0, ParameterDirection.Input, winMoneyNoWithTax * _Convert.StrToInt(table2.Rows[j]["Multiple"].ToString(), 1)), new MSSQL.Parameter("p5", SqlDbType.VarChar, 0, ParameterDirection.Input, description) });
                        }
                        int num7 = 0;
                        int num8 = 0;
                        int num9 = 0;
                        int num10 = 0;
                        this.BindDataForIsuse();
                        this.tbWinNumber.Text = "";
                        JavaScript.Alert(this.Page, string.Format("开奖成功，总方案 {0} 个，撤单未满员或未出票方案 {1} 个，有效中奖方案 {2} 个，中奖但未成功方案 {3} 个。", new object[] { num7, num8, num9, num10 }));
                    }
                }
            }
        }
    }

    protected void btnGO_Step1_Click(object sender, EventArgs e)
    {
        this.btnGO_Step1.AlertText = "";
        if (this.ddlLottery.SelectedValue == "45")
        {
            JavaScript.Alert(this.Page, "足彩单场不支持分步开奖。");
        }
        else
        {
            this.tbWinNumber.Text = _Convert.ToDBC(this.tbWinNumber.Text.Trim().Replace("　", " ")).Trim();
            if (!new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].AnalyseWinNumber(this.tbWinNumber.Text))
            {
                JavaScript.Alert(this.Page, "开奖号码不正确！");
            }
            else
            {
                SystemOptions options = new SystemOptions();
                bool flag = options["isCompareWinMoneyNoWithFax"].ToBoolean(true);
                string winListXML = "<WinLists>";
                double[] winMoneyList = new double[this.g.Rows.Count * 2];
                for (int i = 0; i < this.g.Rows.Count; i++)
                {
                    winMoneyList[i * 2] = _Convert.StrToDouble(((TextBox)this.g.Rows[i].Cells[1].FindControl("tbMoney")).Text, 0.0);
                    winMoneyList[(i * 2) + 1] = _Convert.StrToDouble(((TextBox)this.g.Rows[i].Cells[2].FindControl("tbMoneyNoWithTax")).Text, 0.0);
                    if (winMoneyList[i * 2] < 0.0)
                    {
                        JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 项奖金输入错误！");
                        return;
                    }
                    if ((winMoneyList[i * 2] < winMoneyList[(i * 2) + 1]) && flag)
                    {
                        JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 项税后奖金输入错误(不能大于税前奖金)！");
                        return;
                    }
                    string str2 = winListXML;
                    winListXML = str2 + "<WinList defaultMoney=\"" + winMoneyList[i * 2].ToString() + "\" DefaultMoneyNoWithTax=\"" + winMoneyList[(i * 2) + 1].ToString() + "\"/>";
                }
                winListXML = winListXML + "</WinLists>";
                DataTable table = new Tables.T_IsuseBonuses().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue), "");
                if (table == null)
                {
                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                }
                else if (table.Rows.Count < 1)
                {
                    int returnValue = -1;
                    string returnDescription = "";
                    if (Procedures.P_IsuseBonusesAdd(_Convert.StrToLong(this.ddlIsuse.SelectedValue, 0L), base._User.ID, winListXML, ref returnValue, ref returnDescription) < 0)
                    {
                        PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                    }
                    else if (returnValue < 0)
                    {
                        JavaScript.Alert(this.Page, returnDescription);
                    }
                    else
                    {
                        JavaScript.Alert(this.Page, "请让下一位开奖操作员继续下一步开奖操作！");
                    }
                }
                else if (table.Rows[0]["UserID"].ToString() == base._User.ID.ToString())
                {
                    JavaScript.Alert(this.Page, "请让下一位开奖操作员继续下一步开奖操作！");
                }
                else
                {
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        if ((winMoneyList[j * 2] != _Convert.StrToDouble(table.Rows[j]["defaultMoney"].ToString(), 0.0)) || (winMoneyList[(j * 2) + 1] != _Convert.StrToDouble(table.Rows[j]["DefaultMoneyNoWithTax"].ToString(), 0.0)))
                        {
                            new Tables.T_IsuseBonuses().Delete("IsuseID = " + this.ddlIsuse.SelectedValue);
                            JavaScript.Alert(this.Page, "两次奖项输入不一致，请联系上一次开奖操作员！");
                            return;
                        }
                    }
                    DataTable table2 = new Tables.T_Schemes().Open("top 500 * ", "IsuseID = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue) + " and isOpened = 0 and ID > " + Utility.FilteSqlInfusion(this.h_SchemeID.Value) + " and Buyed = 1", "[ID]");
                    if (table2 == null)
                    {
                        PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                    }
                    else
                    {
                        StringBuilder builder = new StringBuilder();
                        for (int k = 0; k < table2.Rows.Count; k++)
                        {
                            string number = table2.Rows[k]["LotteryNumber"].ToString();
                            string description = "";
                            double winMoneyNoWithTax = 0.0;
                            double num10 = 0.0;
                            try
                            {
                                num10 = new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].ComputeWin(number, this.tbWinNumber.Text.Trim(), ref description, ref winMoneyNoWithTax, int.Parse(table2.Rows[k]["PlayTypeID"].ToString()), winMoneyList);
                            }
                            catch
                            {
                                num10 = 0.0;
                                new Log("System").Write("方案 ID:" + table2.Rows[k]["ID"].ToString() + " 算奖出现错误!");
                                PF.SendEmail(base._Site, "thc@3km.cc", "方案 ID:" + table2.Rows[k]["ID"].ToString() + " 算奖出现错误!", "方案 ID:" + table2.Rows[k]["ID"].ToString() + " 算奖出现错误!");
                                PF.SendEmail(base._Site, "wangxinyuan@3km.cc", "方案 ID:" + table2.Rows[k]["ID"].ToString() + " 算奖出现错误!", "方案 ID:" + table2.Rows[k]["ID"].ToString() + " 算奖出现错误!");
                            }
                            builder.Append("update T_Schemes set PreWinMoney = ").Append((double)(num10 * _Convert.StrToInt(table2.Rows[k]["Multiple"].ToString(), 1))).Append(", PreWinMoneyNoWithTax = ").Append((double)(winMoneyNoWithTax * _Convert.StrToInt(table2.Rows[k]["Multiple"].ToString(), 1))).Append(", EditWinMoney = ").Append((double)(num10 * _Convert.StrToInt(table2.Rows[k]["Multiple"].ToString(), 1))).Append(", EditWinMoneyNoWithTax = ").Append((double)(winMoneyNoWithTax * _Convert.StrToInt(table2.Rows[k]["Multiple"].ToString(), 1))).Append(", WinDescription = '").Append(description).Append("'").Append(" where [ID] = ").AppendLine(table2.Rows[k]["ID"].ToString());
                        }
                        MSSQL.ExecuteNonQuery(builder.ToString(), new MSSQL.Parameter[0]);
                        if (table2.Rows.Count > 1)
                        {
                            this.h_SchemeID.Value = table2.Rows[table2.Rows.Count - 1]["ID"].ToString();
                        }
                        this.Step1IsOpen = table2.Rows.Count == 500;
                        if (!this.Step1IsOpen)
                        {
                            table2 = new Tables.T_Schemes().Open("top 1 * ", "IsuseID = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue) + " and isOpened = 0 and Buyed = 1 and WinMoney is null", "[ID]");
                            if (table2 == null)
                            {
                                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                                return;
                            }
                            this.Step1IsOpen = table2.Rows.Count > 0;
                        }
                        this.btnGO_Step1.Enabled = this.Step1IsOpen;
                        this.btnGO_Step2.Enabled = !this.Step1IsOpen;
                        this.btnGO_Step3.Enabled = !this.Step1IsOpen && !this.Step2IsOpen;
                        string msg = "请再次执行第一步";
                        if (!this.Step1IsOpen)
                        {
                            msg = "开奖步骤一已经完成，请执行第二步.";
                        }
                        JavaScript.Alert(this.Page, msg);
                    }
                }
            }
        }
    }

    protected void btnGO_Step2_Click(object sender, EventArgs e)
    {
        this.btnGO_Step1.AlertText = "";
        if (this.ddlLottery.SelectedValue == "45")
        {
            JavaScript.Alert(this.Page, "足彩单场不支持分步开奖。");
        }
        else
        {
            this.tbWinNumber.Text = _Convert.ToDBC(this.tbWinNumber.Text.Trim().Replace("　", " ")).Trim();
            if (!new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].AnalyseWinNumber(this.tbWinNumber.Text))
            {
                JavaScript.Alert(this.Page, "开奖号码不正确！");
            }
            else
            {
                SystemOptions options = new SystemOptions();
                bool flag = options["isCompareWinMoneyNoWithFax"].ToBoolean(true);
                double[] winMoneyList = new double[this.g.Rows.Count * 2];
                for (int i = 0; i < this.g.Rows.Count; i++)
                {
                    winMoneyList[i * 2] = _Convert.StrToDouble(((TextBox)this.g.Rows[i].Cells[1].FindControl("tbMoney")).Text, 0.0);
                    winMoneyList[(i * 2) + 1] = _Convert.StrToDouble(((TextBox)this.g.Rows[i].Cells[2].FindControl("tbMoneyNoWithTax")).Text, 0.0);
                    if (winMoneyList[i * 2] < 0.0)
                    {
                        JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 项奖金输入错误！");
                        return;
                    }
                    if ((winMoneyList[i * 2] < winMoneyList[(i * 2) + 1]) && flag)
                    {
                        JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 项税后奖金输入错误(不能大于税前奖金)！");
                        return;
                    }
                }
                if (_Convert.ToTextCode(this.tbOpenAffiche.Text.Trim()) == "")
                {
                    JavaScript.Alert(this.Page, "请输入开奖公告！");
                }
                else
                {
                    DataTable table = new Tables.T_ElectronTicketAgentSchemes().Open("top 500 *", "IsuseID = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue) + " and WinMoney is null and state = 1", "[ID]");
                    if (table == null)
                    {
                        PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                    }
                    else
                    {
                        Tables.T_ElectronTicketAgentSchemes schemes = new Tables.T_ElectronTicketAgentSchemes();
                        for (int j = 0; j < table.Rows.Count; j++)
                        {
                            string number = table.Rows[j]["LotteryNumber"].ToString();
                            string description = "";
                            double winMoneyNoWithTax = 0.0;
                            double num6 = new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].ComputeWin(number, this.tbWinNumber.Text.Trim(), ref description, ref winMoneyNoWithTax, int.Parse(table.Rows[j]["PlayTypeID"].ToString()), winMoneyList);
                            schemes.WinMoney.Value = num6 * _Convert.StrToInt(table.Rows[j]["Multiple"].ToString(), 1);
                            schemes.WinMoneyWithoutTax.Value = winMoneyNoWithTax * _Convert.StrToInt(table.Rows[j]["Multiple"].ToString(), 1);
                            schemes.WinDescription.Value = description;
                            schemes.Update("[ID] =" + table.Rows[j]["ID"].ToString());
                        }
                        this.Step2IsOpen = table.Rows.Count == 500;
                        if (!this.Step2IsOpen)
                        {
                            table = new Tables.T_ElectronTicketAgentSchemes().Open("top 1 * ", "IsuseID = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue) + " and state = 1 and WinMoney is null", "[ID]");
                            if (table == null)
                            {
                                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                                return;
                            }
                            this.Step2IsOpen = table.Rows.Count > 0;
                        }
                        this.btnGO_Step2.Enabled = this.Step2IsOpen;
                        this.btnGO_Step3.Enabled = !this.Step2IsOpen;
                        string msg = "请再次执行第二步";
                        if (!this.Step2IsOpen)
                        {
                            msg = "开奖步骤二已经完成，请执行第三步.";
                        }
                        JavaScript.Alert(this.Page, msg);
                    }
                }
            }
        }
    }

    protected void btnGO_Step3_Click(object sender, EventArgs e)
    {
        this.btnGO_Step1.AlertText = "";
        if (this.ddlLottery.SelectedValue == "45")
        {
            JavaScript.Alert(this.Page, "足彩单场不支持分步开奖。");
        }
        else
        {
            this.tbWinNumber.Text = _Convert.ToDBC(this.tbWinNumber.Text.Trim().Replace("　", " ")).Trim();
            if (!new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].AnalyseWinNumber(this.tbWinNumber.Text))
            {
                JavaScript.Alert(this.Page, "开奖号码不正确！");
            }
            else
            {
                int schemeCount = 0;
                int quashCount = 0;
                int winCount = 0;
                int winNoBuyCount = 0;
                int returnValue = -1;
                string returnDescription = "";
                DataSet ds = null;
                bool isEndOpen = false;
                new Log("System").Write("开奖1");
                int num6 = Procedures.P_Win(ref ds, long.Parse(this.ddlIsuse.SelectedValue), this.tbWinNumber.Text.Trim(), this.tbOpenAffiche.Text, base._User.ID, true, ref schemeCount, ref quashCount, ref winCount, ref winNoBuyCount, ref isEndOpen, ref returnValue, ref returnDescription);
                new Log("System").Write("开奖1");
                if (((ds == null) || (returnDescription != "")) || ((returnValue < 0) || (num6 < 0)))
                {
                    base.Response.Write(this.ddlIsuse.SelectedValue + "<br>");
                    base.Response.Write(this.tbWinNumber.Text.Trim() + "<br>");
                    base.Response.Write(this.tbOpenAffiche.Text + "<br>");
                    base.Response.Write(base._User.ID.ToString() + "<br>");
                    base.Response.Write(schemeCount.ToString() + "<br>");
                    base.Response.Write(quashCount.ToString() + "<br>");
                    base.Response.Write(winCount.ToString() + "<br>");
                    base.Response.Write(winNoBuyCount.ToString() + "<br>");
                    base.Response.Write(isEndOpen.ToString() + "<br>");
                    base.Response.Write(returnValue.ToString() + "<br>");
                    base.Response.Write(returnDescription.ToString() + "<br>");
                    base.Response.Write(num6.ToString() + "<br>");
                }
                else
                {
                    PF.SendWinNotification(ds);
                    this.btnGO_Step1.Enabled = false;
                    this.btnGO_Step2.Enabled = false;
                    this.btnGO_Step3.Enabled = true;
                    string format = "开奖成功，总方案 {0} 个，撤单未满员或未出票方案 {1} 个，有效中奖方案 {2} 个，中奖但未成功方案 {3} 个。本期开奖还未全部完成, 请继续操作第三步。";
                    if (isEndOpen)
                    {
                        this.BindDataForIsuse();
                        this.btnGO_Step3.Enabled = false;
                        format = "开奖成功，总方案 {0} 个，撤单未满员或未出票方案 {1} 个，有效中奖方案 {2} 个，中奖但未成功方案 {3} 个。本期开奖已全部完成。";
                    }
                    Shove._Web.Cache.ClearCache(DataCache.IsusesInfo + this.ddlLottery.SelectedValue);
                    JavaScript.Alert(this.Page, string.Format(format, new object[] { schemeCount, quashCount, winCount, winNoBuyCount }));
                }
            }
        }
    }

    protected void DataListZCDC_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            if (e.CommandName == "btEdit")
            {
                this.DataListZCDC.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "btUpdate")
            {
                if (e.Item.ItemType == ListItemType.EditItem)
                {
                    string result = "";
                    string halftimeResult = "";
                    string str3 = "";
                    string str4 = "";
                    string str5 = "";
                    string letBall = "0";
                    string sPFResult = "";
                    string zJQResult = "";
                    string sXDSResult = "";
                    string zQBFResult = "";
                    string bQCSPFResult = "";
                    double num = 0.0;
                    double num2 = 0.0;
                    double num3 = 0.0;
                    double num4 = 0.0;
                    double num5 = 0.0;
                    int num6 = 0;
                    CheckBox box = (CheckBox)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("cbResultDelay");
                    HiddenField field = (HiddenField)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("hfId");
                    if (box.Checked)
                    {
                        result = "*";
                        halftimeResult = "*";
                        sPFResult = "*";
                        zJQResult = "*";
                        sXDSResult = "*";
                        zQBFResult = "*";
                        bQCSPFResult = "*";
                        num = 1.0;
                        num2 = 1.0;
                        num3 = 1.0;
                        num4 = 1.0;
                        num5 = 1.0;
                    }
                    else
                    {
                        DropDownList list = (DropDownList)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("ddlLetBall");
                        DropDownList list2 = (DropDownList)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("ddlGame1");
                        DropDownList list3 = (DropDownList)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("ddlGame2");
                        DropDownList list4 = (DropDownList)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("ddlHalftime1");
                        DropDownList list5 = (DropDownList)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("ddlHalftime2");
                        DropDownList list6 = (DropDownList)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("ddlZQBF");
                        DropDownList list7 = (DropDownList)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("ddlBQCSPF");
                        TextBox box2 = (TextBox)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("tbSPF_SP");
                        TextBox box3 = (TextBox)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("tbZJQ_SP");
                        TextBox box4 = (TextBox)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("tbSXDS_SP");
                        TextBox box5 = (TextBox)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("tbZQBF_SP");
                        TextBox box6 = (TextBox)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("tbBQCSPF_SP");
                        result = list2.SelectedValue + ":" + list3.SelectedValue;
                        halftimeResult = list4.SelectedValue + ":" + list5.SelectedValue;
                        letBall = list.SelectedValue;
                        if ((int.Parse(list2.SelectedValue) + int.Parse(list.SelectedValue)) > int.Parse(list3.SelectedValue))
                        {
                            sPFResult = "3";
                        }
                        else if ((int.Parse(list2.SelectedValue) + int.Parse(list.SelectedValue)) == int.Parse(list3.SelectedValue))
                        {
                            sPFResult = "1";
                        }
                        else
                        {
                            sPFResult = "0";
                        }
                        num6 = int.Parse(list2.SelectedValue) + int.Parse(list3.SelectedValue);
                        if (num6 >= 7)
                        {
                            zJQResult = "7";
                        }
                        else
                        {
                            zJQResult = num6.ToString();
                        }
                        if (num6 >= 3)
                        {
                            if ((num6 % 2) != 0)
                            {
                                sXDSResult = "1";
                            }
                            else
                            {
                                sXDSResult = "2";
                            }
                        }
                        else if ((num6 % 2) != 0)
                        {
                            sXDSResult = "3";
                        }
                        else
                        {
                            sXDSResult = "4";
                        }
                        if (int.Parse(list2.SelectedValue) > int.Parse(list3.SelectedValue))
                        {
                            if (int.Parse(list2.SelectedValue) > 4)
                            {
                                if (_Convert.StrToInt(list6.SelectedValue, -1) != 10)
                                {
                                    JavaScript.Alert(this.Page, "请正确选择本场比赛的正确比分结果！");
                                    return;
                                }
                                zQBFResult = list6.SelectedValue;
                            }
                            else
                            {
                                if ((int.Parse(list2.SelectedValue) == 4) && (int.Parse(list3.SelectedValue) == 3))
                                {
                                    if (list6.SelectedItem.Text.Trim() != "胜其他")
                                    {
                                        JavaScript.Alert(this.Page, "请正确选择本场比赛的正确比分结果！");
                                        return;
                                    }
                                }
                                else if (list6.SelectedItem.Text != result)
                                {
                                    JavaScript.Alert(this.Page, "请正确选择本场比赛的正确比分结果！");
                                    return;
                                }
                                zQBFResult = list6.SelectedValue;
                            }
                        }
                        else if (int.Parse(list2.SelectedValue) == int.Parse(list3.SelectedValue))
                        {
                            if (int.Parse(list2.SelectedValue) > 3)
                            {
                                if (_Convert.StrToInt(list6.SelectedValue, -1) != 15)
                                {
                                    JavaScript.Alert(this.Page, "请正确选择本场比赛的正确比分结果！");
                                    return;
                                }
                                zQBFResult = list6.SelectedValue;
                            }
                            else
                            {
                                if (list6.SelectedItem.Text != result)
                                {
                                    JavaScript.Alert(this.Page, "请正确选择本场比赛的正确比分结果！");
                                    return;
                                }
                                zQBFResult = list6.SelectedValue;
                            }
                        }
                        else if (int.Parse(list3.SelectedValue) > 4)
                        {
                            if (_Convert.StrToInt(list6.SelectedValue, -1) != 0x19)
                            {
                                JavaScript.Alert(this.Page, "请正确选择本场比赛的正确比分结果！");
                                return;
                            }
                            zQBFResult = list6.SelectedValue;
                        }
                        else
                        {
                            if ((int.Parse(list2.SelectedValue) == 3) && (int.Parse(list3.SelectedValue) == 4))
                            {
                                if (list6.SelectedItem.Text != "负其他")
                                {
                                    JavaScript.Alert(this.Page, "请正确选择本场比赛的正确比分结果！");
                                    return;
                                }
                            }
                            else if (list6.SelectedItem.Text != result)
                            {
                                JavaScript.Alert(this.Page, "请正确选择本场比赛的正确比分结果！");
                                return;
                            }
                            zQBFResult = list6.SelectedValue;
                        }
                        if (int.Parse(list4.SelectedValue) > int.Parse(list5.SelectedValue))
                        {
                            str4 = "胜";
                        }
                        else if (int.Parse(list4.SelectedValue) == int.Parse(list5.SelectedValue))
                        {
                            str4 = "平";
                        }
                        else
                        {
                            str4 = "负";
                        }
                        if (int.Parse(list2.SelectedValue) > int.Parse(list3.SelectedValue))
                        {
                            str3 = "胜";
                        }
                        else if (int.Parse(list2.SelectedValue) == int.Parse(list3.SelectedValue))
                        {
                            str3 = "平";
                        }
                        else
                        {
                            str3 = "负";
                        }
                        str5 = str4 + "-" + str3;
                        if (list7.SelectedItem.Text != str5)
                        {
                            JavaScript.Alert(this.Page, "请正确选择本场比赛半全场胜平负的结果！");
                            return;
                        }
                        bQCSPFResult = list7.SelectedValue;
                        if (_Convert.StrToDouble(box2.Text.Trim(), -1.0) < 0.0)
                        {
                            JavaScript.Alert(this.Page, "请正确输入全场比赛胜平负的SP结果值！");
                            return;
                        }
                        if (_Convert.StrToDouble(box3.Text.Trim(), -1.0) < 0.0)
                        {
                            JavaScript.Alert(this.Page, "请正确输入全场比赛总进球的SP结果值！");
                            return;
                        }
                        if (_Convert.StrToDouble(box4.Text.Trim(), -1.0) < 0.0)
                        {
                            JavaScript.Alert(this.Page, "请正确输入全场比赛上下单双的SP结果值！");
                            return;
                        }
                        if (_Convert.StrToDouble(box5.Text.Trim(), -1.0) < 0.0)
                        {
                            JavaScript.Alert(this.Page, "请正确输入全场比赛正确比分的SP结果值！");
                            return;
                        }
                        if (_Convert.StrToDouble(box6.Text.Trim(), -1.0) < 0.0)
                        {
                            JavaScript.Alert(this.Page, "请正确输入本场比赛半全场胜平负的SP结果值！");
                            return;
                        }
                        num = _Convert.StrToDouble(box2.Text.Trim(), 0.0);
                        num2 = _Convert.StrToDouble(box3.Text.Trim(), 0.0);
                        num3 = _Convert.StrToDouble(box4.Text.Trim(), 0.0);
                        num4 = _Convert.StrToDouble(box5.Text.Trim(), 0.0);
                        num5 = _Convert.StrToDouble(box6.Text.Trim(), 0.0);
                    }
                    long iD = int.Parse(field.Value);
                    int returnValue = 0;
                    string returnDescription = "";
                    Procedures.P_IsuseInsertOneResultForZCDC(iD, halftimeResult, result, letBall, sPFResult, num, zJQResult, num2, sXDSResult, num3, zQBFResult, num4, bQCSPFResult, num5, ref returnValue, ref returnDescription);
                    if (returnValue < 0)
                    {
                        JavaScript.Alert(this.Page, returnDescription);
                        return;
                    }
                    JavaScript.Alert(this.Page, "更新成功!");
                }
                this.DataListZCDC.EditItemIndex = -1;
            }
            if (e.CommandName == "btOpenWin")
            {
                if (e.Item.ItemType == ListItemType.EditItem)
                {
                    Label label = (Label)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("lbZCDC");
                    DataTable table = MSSQL.Select("select * from T_IsuseForZCDC where IsuseID = " + this.ddlIsuse.SelectedValue + " order by [NO]", new MSSQL.Parameter[0]);
                    if ((table == null) || (table.Rows.Count < 1))
                    {
                        PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                        return;
                    }
                    int count = table.Rows.Count;
                    DataTable table2 = MSSQL.Select("select * from T_IsuseForZCDC where IsuseID = " + this.ddlIsuse.SelectedValue + " and [NO] <= " + label.Text + "  order by [NO]", new MSSQL.Parameter[0]);
                    if ((table2 == null) || (table2.Rows.Count < 1))
                    {
                        PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                        return;
                    }
                    int competitionCount = table2.Rows.Count;
                    string number = "";
                    string str14 = "";
                    string str15 = "";
                    string str16 = "";
                    string str17 = "";
                    string str18 = "";
                    for (int i = 0; i < competitionCount; i++)
                    {
                        if (((table2.Rows[i]["Result"].ToString() == "") || (table2.Rows[i]["SPFResult"].ToString() == "")) || (table2.Rows[i]["SPF_SP"].ToString() == ""))
                        {
                            JavaScript.Alert(this.Page, "第" + table2.Rows[i]["No"].ToString() + "场比赛的彩果没有输入！请先输入！！");
                            return;
                        }
                        string str19 = str14;
                        str14 = str19 + table2.Rows[i]["No"].ToString() + "(" + table2.Rows[i]["SPFResult"].ToString() + "," + table2.Rows[i]["SPF_SP"].ToString() + ")|";
                        str19 = str15;
                        str15 = str19 + table2.Rows[i]["No"].ToString() + "(" + table2.Rows[i]["ZJQResult"].ToString() + "," + table2.Rows[i]["ZJQ_SP"].ToString() + ")|";
                        str19 = str16;
                        str16 = str19 + table2.Rows[i]["No"].ToString() + "(" + table2.Rows[i]["SXDSResult"].ToString() + "," + table2.Rows[i]["SXDS_SP"].ToString() + ")|";
                        str19 = str17;
                        str17 = str19 + table2.Rows[i]["No"].ToString() + "(" + table2.Rows[i]["ZQBFResult"].ToString() + "," + table2.Rows[i]["ZQBF_SP"].ToString() + ")|";
                        str19 = str18;
                        str18 = str19 + table2.Rows[i]["No"].ToString() + "(" + table2.Rows[i]["BQCSPFResult"].ToString() + "," + table2.Rows[i]["BQCSPF_SP"].ToString() + ")|";
                    }
                    str14 = str14.Substring(0, str14.Length - 1);
                    str15 = str15.Substring(0, str15.Length - 1);
                    str16 = str16.Substring(0, str16.Length - 1);
                    str17 = str17.Substring(0, str17.Length - 1);
                    str18 = str18.Substring(0, str18.Length - 1);
                    number = str14 + ";" + str15 + ";" + str16 + ";" + str17 + ";" + str18;
                    if (!new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].AnalyseWinNumber(number, table2.Rows.Count))
                    {
                        JavaScript.Alert(this.Page, "开奖号码不正确！");
                        return;
                    }
                    DataTable table3 = new Tables.T_Schemes().Open("", "IsuseID = " + this.ddlIsuse.SelectedValue + " and isOpened = 0", "");
                    if (table3 == null)
                    {
                        PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                        return;
                    }
                    int num12 = 0;
                    int num13 = 0;
                    int num14 = 0;
                    for (int j = 0; j < table3.Rows.Count; j++)
                    {
                        string scheme = table3.Rows[j]["LotteryNumber"].ToString();
                        int playType = _Convert.StrToInt(scheme.Trim().Split(new char[] { ';' })[0].ToString(), 0);
                        string str22 = scheme.Trim().Split(new char[] { ';' })[1].ToString();
                        string[] strArray2 = str22.Substring(1, str22.Length - 1).Substring(0, str22.Length - 2).ToString().Trim().Split(new char[] { '|' });
                        string str = strArray2[strArray2.Length - 1].Substring(0, strArray2[strArray2.Length - 1].IndexOf('('));
                        if (competitionCount >= _Convert.StrToInt(str, 0))
                        {
                            num12++;
                            string description = "";
                            double winMoneyNoWithTax = 0.0;
                            double winMoney = new Lottery()[int.Parse(this.ddlLottery.SelectedValue)].ComputeWin(scheme, number, ref description, ref winMoneyNoWithTax, playType, competitionCount, "");
                            if (winMoney > 0.0)
                            {
                                num14++;
                            }
                            int num19 = 0;
                            string str26 = "";
                            DataSet ds = null;
                            Procedures.P_WinByOpenManual(ref ds, base._Site.ID, _Convert.StrToLong(table3.Rows[j]["ID"].ToString(), 0L), winMoney, winMoneyNoWithTax, description, base._User.ID, ref num19, ref str26);
                            if ((ds == null) || (str26 != ""))
                            {
                                num13++;
                                new Log("System").Write(table3.Rows[j]["ID"].ToString() + "方案派奖错误!");
                            }
                            PF.SendWinNotification(ds);
                        }
                    }
                    if (count == competitionCount)
                    {
                        MSSQL.ExecuteNonQuery("update T_Isuses set isOpened = 1, OpenAffiche = @p2 where [ID] = " + this.ddlIsuse.SelectedValue, new MSSQL.Parameter[] { new MSSQL.Parameter("p1", SqlDbType.VarChar, 0, ParameterDirection.Input, number), new MSSQL.Parameter("p2", SqlDbType.VarChar, 0, ParameterDirection.Input, "无开奖模板") });
                    }
                    this.BindDataForIsuse();
                    JavaScript.Alert(this.Page, string.Format("开奖成功，总方案 {0} 个，失败方案 {1} 个，有效中奖方案 {2} 个。", num12, num13, num14));
                }
                this.DataListZCDC.EditItemIndex = -1;
            }
            this.BindDataForZCDC();
        }
    }

    protected void DataListZCDC_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.EditItem)
        {
            TextBox box = (TextBox)e.Item.FindControl("tbResult");
            TextBox box2 = (TextBox)e.Item.FindControl("tbHalftimeResult");
            TextBox box3 = (TextBox)e.Item.FindControl("tbLetBall");
            TextBox box4 = (TextBox)e.Item.FindControl("tbSPFResult");
            TextBox box5 = (TextBox)e.Item.FindControl("tbZJQResult");
            TextBox box6 = (TextBox)e.Item.FindControl("tbSXDSResult");
            TextBox box7 = (TextBox)e.Item.FindControl("tbZQBFResult");
            TextBox box8 = (TextBox)e.Item.FindControl("tbBQCSPFResult");
            DropDownList ddl = (DropDownList)e.Item.FindControl("ddlLetBall");
            DropDownList list2 = (DropDownList)e.Item.FindControl("ddlGame1");
            DropDownList list3 = (DropDownList)e.Item.FindControl("ddlGame2");
            DropDownList list4 = (DropDownList)e.Item.FindControl("ddlHalftime1");
            DropDownList list5 = (DropDownList)e.Item.FindControl("ddlHalftime2");
            DropDownList list6 = (DropDownList)e.Item.FindControl("ddlSPF");
            DropDownList list7 = (DropDownList)e.Item.FindControl("ddlZJQ");
            DropDownList list8 = (DropDownList)e.Item.FindControl("ddlSXDS");
            DropDownList list9 = (DropDownList)e.Item.FindControl("ddlZQBF");
            DropDownList list10 = (DropDownList)e.Item.FindControl("ddlBQCSPF");
            Button button = (Button)e.Item.FindControl("btOpenWin");
            CheckBox box9 = (CheckBox)e.Item.FindControl("cbResultDelay");
            if (box.Text != "")
            {
                if (box.Text != "*")
                {
                    string[] strArray = box.Text.Split(new char[] { ':' });
                    this.DropDownListDefault(list2, strArray[0], true);
                    this.DropDownListDefault(list3, strArray[1], true);
                }
                else
                {
                    box9.Checked = true;
                }
                button.Enabled = true;
            }
            else
            {
                button.Enabled = false;
            }
            if ((box2.Text != "") && (box2.Text != "*"))
            {
                string[] strArray2 = box2.Text.Split(new char[] { ':' });
                this.DropDownListDefault(list4, strArray2[0], true);
                this.DropDownListDefault(list5, strArray2[1], true);
            }
            if (box3.Text != "")
            {
                this.DropDownListDefault(ddl, box3.Text, true);
            }
            if (box4.Text != "")
            {
                this.DropDownListDefault(list6, box4.Text, false);
            }
            if (box5.Text != "")
            {
                this.DropDownListDefault(list7, box5.Text, false);
            }
            if (box6.Text != "")
            {
                this.DropDownListDefault(list8, box6.Text, false);
            }
            if (box7.Text != "")
            {
                this.DropDownListDefault(list9, box7.Text, true);
            }
            if (box8.Text != "")
            {
                this.DropDownListDefault(list10, box8.Text, true);
            }
        }
    }

    protected void ddlIsuse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable table = new Tables.T_Isuses().Open("WinLotteryNumber, isOpened", "[ID] = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue), "");
            if ((table == null) || (table.Rows.Count < 1))
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
            }
            else
            {
                bool flag = _Convert.StrToBool(table.Rows[0]["isOpened"].ToString(), true);
                string str = table.Rows[0]["WinLotteryNumber"].ToString();
                if (flag)
                {
                    this.tbOpenAffiche.ReadOnly = true;
                    this.btnGO.Enabled = false;
                    this.btnGO_Step1.Enabled = false;
                    this.btnGO_Step2.Enabled = false;
                    this.btnGO_Step3.Enabled = false;
                    this.tbWinNumber.Enabled = false;
                    PF.GoError(1, "此期已经开奖了，不能重复开奖。", base.GetType().BaseType.FullName);
                }
                else if (this.ddlLottery.SelectedValue == "45")
                {
                    this.BindDataForZCDC();
                    this.WinNumberZCDC.Visible = true;
                    this.WinNumberOther.Visible = false;
                    this.tbOpenAffiche.ReadOnly = false;
                    this.btnGO.Visible = true;
                    this.btnGO.Enabled = true;
                    this.btnGO_Step1.Visible = true;
                    this.btnGO_Step1.Enabled = true;
                    this.btnGO_Step2.Visible = true;
                    this.btnGO_Step2.Enabled = false;
                    this.btnGO_Step3.Visible = true;
                    this.btnGO_Step3.Enabled = false;
                }
                else
                {
                    this.WinNumberZCDC.Visible = false;
                    this.WinNumberOther.Visible = true;
                    this.tbOpenAffiche.ReadOnly = false;
                    this.btnGO.Enabled = true;
                    this.btnGO_Step1.Enabled = true;
                    this.btnGO_Step2.Enabled = false;
                    this.btnGO_Step3.Enabled = false;
                    this.tbWinNumber.Enabled = true;
                    if (str != "")
                    {
                        this.tbWinNumber.Text = str;
                    }
                }
            }
        }
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindDataForWinMoney();
        string str = "格式：" + Functions.F_GetLotteryWinNumberExemple(int.Parse(this.ddlLottery.SelectedValue));
        this.labTip.Text = str;
        this.tbWinNumber.MaxLength = str.Length - 3;
        this.tbOpenAffiche.Text = new OpenAfficheTemplates()[int.Parse(this.ddlLottery.SelectedValue)];
        this.BindDataForIsuse();
    }

    private void DropDownListDefault(DropDownList ddl, string defaultValue, bool UserEnabled)
    {
        if (!ddl.Enabled)
        {
            ddl.Enabled = true;
        }
        foreach (ListItem item in ddl.Items)
        {
            if (item.Value == defaultValue)
            {
                item.Selected = true;
            }
        }
        ddl.Enabled = UserEnabled;
    }

    protected void g_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Web.UI.WebControls.DataKey key = this.g.DataKeys[this.g.DataKeys.Count - 1];
            double num = _Convert.StrToDouble(key.Values[0].ToString(), 0.0);
            ((TextBox)e.Row.Cells[1].FindControl("tbMoney")).Text = (num == 0.0) ? "" : num.ToString();
            num = _Convert.StrToDouble(key.Values[1].ToString(), 0.0);
            ((TextBox)e.Row.Cells[2].FindControl("tbMoneyNoWithTax")).Text = (num == 0.0) ? "" : num.ToString();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "LotteryWin" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        base.Server.ScriptTimeout = 600;
        if (!base.IsPostBack)
        {
            this.BindDataForLottery();
            this.BindDataForIsuse();
            this.h_SchemeID.Value = "0";
        }
        this.btnGO_Step1.AlertText = "确信输入无误，并立即执行开奖第一步骤吗？";
    }


}

