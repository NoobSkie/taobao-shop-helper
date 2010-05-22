using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_IsuseEdit : AdminPageBase, IRequiresSessionState
{
    private DataTable dt_FootballLeagueTypes;
  
    private void BindData()
    {
        DataTable table = new Tables.T_Isuses().Open("", "[ID]=" + Utility.FilteSqlInfusion(this.tbIsuseID.Text), "");
        if ((table == null) || (table.Rows.Count < 1))
        {
            PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
        }
        else
        {
            this.tbIsuse.Text = table.Rows[0]["Name"].ToString();
            this.tbStartTime.Text = _Convert.StrToDateTime(table.Rows[0]["StartTime"].ToString(), "0000-00-00 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
            this.tbEndTime.Text = _Convert.StrToDateTime(table.Rows[0]["EndTime"].ToString(), "0000-00-00 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
            if (this.tbLotteryID.Text == "1")
            {
                table = new Tables.T_IsuseForSFC().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.tbIsuseID.Text), "[No]");
                if ((table == null) || (table.Rows.Count < 14))
                {
                    PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
                    return;
                }
                for (int i = 0; i < 14; i++)
                {
                    int num2 = i + 1;
                    TextBox box = (TextBox)this.FindControl("tbSFC" + num2.ToString());
                    int num3 = i + 1;
                    TextBox box2 = (TextBox)this.FindControl("tbSFC" + num3.ToString() + "_1");
                    int num4 = i + 1;
                    TextBox box3 = (TextBox)this.FindControl("tbSFC" + num4.ToString() + "_2");
                    box.Text = table.Rows[i]["HostTeam"].ToString();
                    box2.Text = table.Rows[i]["QuestTeam"].ToString();
                    box3.Text = table.Rows[i]["DateTime"].ToString();
                }
            }
            if (this.tbLotteryID.Text == "2")
            {
                table = new Tables.T_IsuseForJQC().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.tbIsuseID.Text), "[No]");
                if ((table == null) || (table.Rows.Count < 8))
                {
                    PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
                    return;
                }
                for (int j = 0; j < 8; j++)
                {
                    int num6 = j + 1;
                    TextBox box4 = (TextBox)this.FindControl("tbJQC" + num6.ToString());
                    int num7 = j + 1;
                    TextBox box5 = (TextBox)this.FindControl("tbJQC" + num7.ToString() + "_2");
                    box4.Text = table.Rows[j]["Team"].ToString();
                    box5.Text = table.Rows[j]["DateTime"].ToString();
                }
            }
            if (this.tbLotteryID.Text == "15")
            {
                table = new Tables.T_IsuseForLCBQC().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.tbIsuseID.Text), "[No]");
                if ((table == null) || (table.Rows.Count < 6))
                {
                    PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
                    return;
                }
                for (int k = 0; k < 6; k++)
                {
                    int num9 = k + 1;
                    TextBox box6 = (TextBox)this.FindControl("tbLCBQC" + num9.ToString());
                    int num10 = k + 1;
                    TextBox box7 = (TextBox)this.FindControl("tbLCBQC" + num10.ToString() + "_1");
                    int num11 = k + 1;
                    TextBox box8 = (TextBox)this.FindControl("tbLCBQC" + num11.ToString() + "_2");
                    box6.Text = table.Rows[k]["HostTeam"].ToString();
                    box7.Text = table.Rows[k]["QuestTeam"].ToString();
                    box8.Text = table.Rows[k]["DateTime"].ToString();
                }
            }
            if (this.tbLotteryID.Text == "19")
            {
                table = new Tables.T_IsuseForLCDC().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.tbIsuseID.Text), "[No]");
                if ((table == null) || (table.Rows.Count < 1))
                {
                    PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
                    return;
                }
                for (int m = 0; m < 1; m++)
                {
                    int num13 = m + 1;
                    TextBox box9 = (TextBox)this.FindControl("tbLCDC" + num13.ToString());
                    int num14 = m + 1;
                    TextBox box10 = (TextBox)this.FindControl("tbLCDC" + num14.ToString() + "_1");
                    int num15 = m + 1;
                    TextBox box11 = (TextBox)this.FindControl("tbLCDC" + num15.ToString() + "_2");
                    box9.Text = table.Rows[m]["HostTeam"].ToString();
                    box10.Text = table.Rows[m]["QuestTeam"].ToString();
                    box11.Text = table.Rows[m]["DateTime"].ToString();
                }
            }
            if (this.tbLotteryID.Text == "45")
            {
                table = new Tables.T_IsuseForZCDC().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.tbIsuseID.Text), "[No]");
                if ((table == null) || (table.Rows.Count < 1))
                {
                    PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
                    return;
                }
                this.DataListZCDC.DataSource = table.DefaultView;
                this.DataListZCDC.DataBind();
            }
            DataTable table2 = new Tables.T_TestNumber().Open("", "IsuseID = " + Utility.FilteSqlInfusion(this.tbIsuseID.Text), "");
            DataTable table3 = new Tables.T_TotalMoney().Open("", "IsuseID= " + Utility.FilteSqlInfusion(this.tbIsuseID.Text), "");
            if (table2 == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
            }
            else if (table3 == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
            }
            else
            {
                if (table2.Rows.Count > 0)
                {
                    this.tbTestNumber.Text = table2.Rows[0]["TestNumber"].ToString();
                    this.hidID.Value = table2.Rows[0]["ID"].ToString();
                }
                if (table3.Rows.Count > 0)
                {
                    this.tbMoney.Text = table3.Rows[0]["TotalMoney"].ToString();
                    this.moneyID.Value = table3.Rows[0]["ID"].ToString();
                }
            }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("Isuse.aspx?LotteryID=" + this.tbLotteryID.Text, true);
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string name = "";
        try
        {
            name = Utility.FilteSqlInfusion(this.tbIsuse.Text.Trim());
        }
        catch
        {
        }
        if (name == "")
        {
            JavaScript.Alert(this.Page, "期号不能为空！");
        }
        else
        {
            DataTable table = new Tables.T_Isuses().Open("[ID]", "[Name]='" + name + "' and LotteryID=" + Utility.FilteSqlInfusion(this.tbLotteryID.Text) + " and [ID] <> " + Utility.FilteSqlInfusion(this.tbIsuseID.Text), "");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
            }
            else if (table.Rows.Count > 0)
            {
                JavaScript.Alert(this.Page, "期号已经存在，请不要输入重名期号！");
            }
            else
            {
                object obj2 = PF.ValidLotteryTime(this.tbStartTime.Text);
                if (obj2 == null)
                {
                    JavaScript.Alert(this.Page, "开始时间格式输入错误！");
                }
                else
                {
                    DateTime startTime = (DateTime)obj2;
                    obj2 = PF.ValidLotteryTime(this.tbEndTime.Text);
                    if (obj2 == null)
                    {
                        JavaScript.Alert(this.Page, "截止时间格式输入错误！");
                    }
                    else
                    {
                        DateTime endTime = (DateTime)obj2;
                        if (endTime <= startTime)
                        {
                            JavaScript.Alert(this.Page, "截止时间应该在开始时间之后！");
                        }
                        else
                        {
                            string additionasXml = "";
                            if ((((((this.tbLotteryID.Text != "1") || (this.BuildAdditionasXmlForSFC(ref additionasXml) >= 0)) && ((this.tbLotteryID.Text != "2") || (this.BuildAdditionasXmlForJQC(ref additionasXml) >= 0))) && ((this.tbLotteryID.Text != "15") || (this.BuildAdditionasXmlForLCBQC(ref additionasXml) >= 0))) && ((this.tbLotteryID.Text != "19") || (this.BuildAdditionasXmlForLCDC(ref additionasXml) >= 0))) && ((this.tbLotteryID.Text != "45") || (this.BuildAdditionasXmlForZCDC(ref additionasXml) >= 0)))
                            {
                                long isuseID = long.Parse(this.tbIsuseID.Text);
                                int returnValue = -1;
                                string returnDescription = "";
                                if (Procedures.P_IsuseEdit(isuseID, name, startTime, endTime, additionasXml, ref returnValue, ref returnDescription) < 0)
                                {
                                    PF.GoError(4, "数据库繁忙，请重试", this.Page.GetType().BaseType.FullName);
                                }
                                else if (returnValue < 0)
                                {
                                    PF.GoError(1, returnDescription, this.Page.GetType().BaseType.FullName);
                                }
                                else
                                {
                                    if (this.tbTestNumber.Text.Trim() != "")
                                    {
                                        Tables.T_TestNumber number = new Tables.T_TestNumber
                                        {
                                            TestNumber = { Value = this.tbTestNumber.Text.Trim() },
                                            IsuseID = { Value = isuseID.ToString() }
                                        };
                                        if (_Convert.StrToLong(this.hidID.Value, 0L) > 0L)
                                        {
                                            number.Update("ID=" + this.hidID.Value);
                                        }
                                        else
                                        {
                                            number.Insert();
                                        }
                                    }
                                    if (this.tbMoney.Text.Trim() != "")
                                    {
                                        Tables.T_TotalMoney money = new Tables.T_TotalMoney
                                        {
                                            TotalMoney = { Value = this.tbMoney.Text.Trim() },
                                            IsuseID = { Value = this.tbIsuseID.Text }
                                        };
                                        if (_Convert.StrToLong(this.moneyID.Value, 0L) > 0L)
                                        {
                                            money.Update("ID=" + this.moneyID.Value);
                                        }
                                        else
                                        {
                                            money.Insert();
                                        }
                                    }
                                    Shove._Web.Cache.ClearCache("LotteryCalendar");
                                    Shove._Web.Cache.ClearCache(DataCache.IsusesInfo + this.tbLotteryID.Text.Trim());
                                    base.Response.Redirect("Isuse.aspx?LotteryID=" + this.tbLotteryID.Text, true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private int BuildAdditionasXmlForJQC(ref string AdditionasXml)
    {
        TextBox[] boxArray = new TextBox[8];
        TextBox[] boxArray2 = new TextBox[8];
        for (int i = 0; i < 8; i++)
        {
            int num2 = i + 1;
            boxArray[i] = (TextBox)this.FindControl("tbJQC" + num2.ToString());
            int num3 = i + 1;
            boxArray2[i] = (TextBox)this.FindControl("tbJQC" + num3.ToString() + "_2");
            if (boxArray[i].Text.Trim() == "")
            {
                JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 个球队名称输入不完整！");
                return -1;
            }
        }
        AdditionasXml = PF.BuildIsuseAdditionasXmlFor1Team(8, new string[] { boxArray[0].Text.Trim(), boxArray2[0].Text.Trim(), boxArray[1].Text.Trim(), boxArray2[0].Text.Trim(), boxArray[2].Text.Trim(), boxArray2[2].Text.Trim(), boxArray[3].Text.Trim(), boxArray2[2].Text.Trim(), boxArray[4].Text.Trim(), boxArray2[4].Text.Trim(), boxArray[5].Text.Trim(), boxArray2[4].Text.Trim(), boxArray[6].Text.Trim(), boxArray2[6].Text.Trim(), boxArray[7].Text.Trim(), boxArray2[6].Text.Trim() });
        return 0;
    }

    private int BuildAdditionasXmlForLCBQC(ref string AdditionasXml)
    {
        TextBox[] boxArray = new TextBox[6];
        TextBox[] boxArray2 = new TextBox[6];
        TextBox[] boxArray3 = new TextBox[6];
        for (int i = 0; i < 6; i++)
        {
            int num2 = i + 1;
            boxArray[i] = (TextBox)this.FindControl("tbLCBQC" + num2.ToString());
            int num3 = i + 1;
            boxArray2[i] = (TextBox)this.FindControl("tbLCBQC" + num3.ToString() + "_1");
            int num4 = i + 1;
            boxArray3[i] = (TextBox)this.FindControl("tbLCBQC" + num4.ToString() + "_2");
            if ((boxArray[i].Text.Trim() == "") || (boxArray2[i].Text.Trim() == ""))
            {
                JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 场比赛球队名称输入不完整！");
                return -1;
            }
        }
        AdditionasXml = PF.BuildIsuseAdditionasXmlFor2Team(6, new string[] { 
            boxArray[0].Text.Trim(), boxArray2[0].Text.Trim(), boxArray3[0].Text.Trim(), boxArray[1].Text.Trim(), boxArray2[1].Text.Trim(), boxArray3[1].Text.Trim(), boxArray[2].Text.Trim(), boxArray2[2].Text.Trim(), boxArray3[2].Text.Trim(), boxArray[3].Text.Trim(), boxArray2[3].Text.Trim(), boxArray3[3].Text.Trim(), boxArray[4].Text.Trim(), boxArray2[4].Text.Trim(), boxArray3[4].Text.Trim(), boxArray[5].Text.Trim(), 
            boxArray2[5].Text.Trim(), boxArray3[5].Text.Trim()
         });
        return 0;
    }

    private int BuildAdditionasXmlForLCDC(ref string AdditionasXml)
    {
        TextBox[] boxArray = new TextBox[1];
        TextBox[] boxArray2 = new TextBox[1];
        TextBox[] boxArray3 = new TextBox[1];
        for (int i = 0; i < 1; i++)
        {
            int num2 = i + 1;
            boxArray[i] = (TextBox)this.FindControl("tbLCDC" + num2.ToString());
            int num3 = i + 1;
            boxArray2[i] = (TextBox)this.FindControl("tbLCDC" + num3.ToString() + "_1");
            int num4 = i + 1;
            boxArray3[i] = (TextBox)this.FindControl("tbLCDC" + num4.ToString() + "_2");
            if ((boxArray[i].Text.Trim() == "") || (boxArray2[i].Text.Trim() == ""))
            {
                JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 场比赛球队名称输入不完整！");
                return -1;
            }
        }
        AdditionasXml = PF.BuildIsuseAdditionasXmlFor2Team(1, new string[] { boxArray[0].Text.Trim(), boxArray2[0].Text.Trim(), boxArray3[0].Text.Trim() });
        return 0;
    }

    private int BuildAdditionasXmlForSFC(ref string AdditionasXml)
    {
        TextBox[] boxArray = new TextBox[14];
        TextBox[] boxArray2 = new TextBox[14];
        TextBox[] boxArray3 = new TextBox[14];
        for (int i = 0; i < 14; i++)
        {
            int num2 = i + 1;
            boxArray[i] = (TextBox)this.FindControl("tbSFC" + num2.ToString());
            int num3 = i + 1;
            boxArray2[i] = (TextBox)this.FindControl("tbSFC" + num3.ToString() + "_1");
            int num4 = i + 1;
            boxArray3[i] = (TextBox)this.FindControl("tbSFC" + num4.ToString() + "_2");
            if ((boxArray[i].Text.Trim() == "") || (boxArray2[i].Text.Trim() == ""))
            {
                JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 场比赛球队名称输入不完整！");
                return -1;
            }
        }
        AdditionasXml = PF.BuildIsuseAdditionasXmlFor2Team(14, new string[] { 
            boxArray[0].Text.Trim(), boxArray2[0].Text.Trim(), boxArray3[0].Text.Trim(), boxArray[1].Text.Trim(), boxArray2[1].Text.Trim(), boxArray3[1].Text.Trim(), boxArray[2].Text.Trim(), boxArray2[2].Text.Trim(), boxArray3[2].Text.Trim(), boxArray[3].Text.Trim(), boxArray2[3].Text.Trim(), boxArray3[3].Text.Trim(), boxArray[4].Text.Trim(), boxArray2[4].Text.Trim(), boxArray3[4].Text.Trim(), boxArray[5].Text.Trim(), 
            boxArray2[5].Text.Trim(), boxArray3[5].Text.Trim(), boxArray[6].Text.Trim(), boxArray2[6].Text.Trim(), boxArray3[6].Text.Trim(), boxArray[7].Text.Trim(), boxArray2[7].Text.Trim(), boxArray3[7].Text.Trim(), boxArray[8].Text.Trim(), boxArray2[8].Text.Trim(), boxArray3[8].Text.Trim(), boxArray[9].Text.Trim(), boxArray2[9].Text.Trim(), boxArray3[9].Text.Trim(), boxArray[10].Text.Trim(), boxArray2[10].Text.Trim(), 
            boxArray3[10].Text.Trim(), boxArray[11].Text.Trim(), boxArray2[11].Text.Trim(), boxArray3[11].Text.Trim(), boxArray[12].Text.Trim(), boxArray2[12].Text.Trim(), boxArray3[12].Text.Trim(), boxArray[13].Text.Trim(), boxArray2[13].Text.Trim(), boxArray3[13].Text.Trim()
         });
        return 0;
    }

    private int BuildAdditionasXmlForZCDC(ref string AdditionasXml)
    {
        int count = this.DataListZCDC.Items.Count;
        if (count < 10)
        {
            JavaScript.Alert(this.Page, "本期比赛的总场数输入有误！");
            return -1;
        }
        TextBox[] boxArray = new TextBox[count];
        TextBox[] boxArray2 = new TextBox[count];
        TextBox[] boxArray3 = new TextBox[count];
        DropDownList[] listArray = new DropDownList[count];
        DropDownList[] listArray2 = new DropDownList[count];
        string[] str = new string[count * 5];
        for (int i = 0; i < count; i++)
        {
            boxArray[i] = (TextBox)this.DataListZCDC.Items[i].FindControl("tb1ZCDC");
            boxArray2[i] = (TextBox)this.DataListZCDC.Items[i].FindControl("tb2ZCDC");
            boxArray3[i] = (TextBox)this.DataListZCDC.Items[i].FindControl("tb3ZCDC");
            listArray[i] = (DropDownList)this.DataListZCDC.Items[i].FindControl("ddlLetBall");
            listArray2[i] = (DropDownList)this.DataListZCDC.Items[i].FindControl("ddlLeagueType");
            if (((boxArray[i].Text.Trim() == "") || (boxArray2[i].Text.Trim() == "")) || (boxArray3[i].Text.Trim() == ""))
            {
                JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 场比赛球队名称输入不完整！");
                return -2;
            }
            object obj2 = PF.ValidLotteryTime(boxArray3[i].Text.Trim());
            if (obj2 == null)
            {
                JavaScript.Alert(this.Page, "第 " + ((i + 1)).ToString() + " 场比赛球队时间输入不正确！(格式：0000-00-00 00:00:00)");
                return -3;
            }
            str[i * 5] = listArray2[i].SelectedValue;
            str[(i * 5) + 1] = boxArray[i].Text.Trim();
            str[(i * 5) + 2] = boxArray2[i].Text.Trim();
            str[(i * 5) + 3] = listArray[i].SelectedValue;
            str[(i * 5) + 4] = obj2.ToString();
        }
        AdditionasXml = PF.BuildIsuseAdditionasXmlForZCDC(str);
        return 0;
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
                try
                {
                    TextBox box = (TextBox)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("tb1ZCDC");
                    TextBox box2 = (TextBox)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("tb2ZCDC");
                    TextBox box3 = (TextBox)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("tb3ZCDC");
                    DropDownList list1 = (DropDownList)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("ddlLetBall");
                    DropDownList list2 = (DropDownList)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("ddlLeagueType");
                    HiddenField field = (HiddenField)this.DataListZCDC.Items[e.Item.ItemIndex].FindControl("hfId");
                    if (((box.Text.Trim() == "") || (box2.Text.Trim() == "")) || (box3.Text.Trim() == ""))
                    {
                        JavaScript.Alert(this.Page, "本场比赛球队名称输入不完整！");
                        return;
                    }
                    if (PF.ValidLotteryTime(box3.Text.Trim()) == null)
                    {
                        JavaScript.Alert(this.Page, "本场比赛球队时间输入不正确！(格式：0000-00-00 00:00:00)");
                        return;
                    }
                    int.Parse(field.Value);
                    int.Parse(this.tbIsuseID.Text);
                }
                catch
                {
                    PF.GoError(1, "单场信息更新错误。", this.Page.GetType().BaseType.FullName);
                    return;
                }
                this.DataListZCDC.EditItemIndex = -1;
            }
            this.BindData();
        }
    }

    protected void DataListZCDC_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            HiddenField field = (HiddenField)e.Item.FindControl("hfTypeid");
            DropDownList ddl = (DropDownList)e.Item.FindControl("ddlLeagueType");
            this.ddlLeagueTypeDataBind(ddl);
            this.DropDownListDefault(ddl, field.Value);
            HiddenField field2 = (HiddenField)e.Item.FindControl("hfLetBall");
            DropDownList list2 = (DropDownList)e.Item.FindControl("ddlLetBall");
            this.DropDownListDefault(list2, field2.Value);
        }
    }

    private void ddlLeagueTypeDataBind(DropDownList ddl)
    {
        if (this.dt_FootballLeagueTypes == null)
        {
            this.dt_FootballLeagueTypes = MSSQL.Select("select ID, Name from T_FootballLeagueTypes where isUse = 1 order by [Order]", new MSSQL.Parameter[0]);
        }
        if ((this.dt_FootballLeagueTypes == null) || (this.dt_FootballLeagueTypes.Rows.Count == 0))
        {
            JavaScript.Alert(this.Page, "请先添加联赛类别！");
        }
        else
        {
            ddl.DataSource = this.dt_FootballLeagueTypes.DefaultView;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "ID";
            ddl.DataBind();
        }
    }

    private void DropDownListDefault(DropDownList ddl, string defaultValue)
    {
        foreach (ListItem item in ddl.Items)
        {
            if (item.Value == defaultValue)
            {
                item.Selected = true;
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme", "QueryData" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            long num = _Convert.StrToLong(Utility.GetRequest("IsuseID"), -1L);
            if (num < 0L)
            {
                PF.GoError(1, "参数错误", "Admin_IsuseEdit");
            }
            else
            {
                int lotteryID = _Convert.StrToInt(Utility.GetRequest("LotteryID"), -1);
                if (!PF.ValidLotteryID(base._Site, lotteryID))
                {
                    PF.GoError(1, "参数错误", "Admin_IsuseEdit");
                }
                else
                {
                    this.tbIsuseID.Text = num.ToString();
                    this.tbLotteryID.Text = lotteryID.ToString();
                    switch (lotteryID)
                    {
                        case 1:
                            this.pSFC.Visible = true;
                            break;

                        case 2:
                            this.pJQC.Visible = true;
                            break;

                        case 15:
                            this.pLCBQC.Visible = true;
                            break;

                        case 0x13:
                            this.pLCDC.Visible = true;
                            break;

                        case 0x2d:
                            this.ZCDC.Visible = true;
                            break;
                    }
                    this.BindData();
                    this.btnEdit.Visible = base._User.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme" }));
                }
            }
        }
    }


}

