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

public partial class Admin_IsuseAdd2 : AdminPageBase, IRequiresSessionState
{
    private DataTable dt_FootballLeagueTypes;

    protected void btCompetitionNum_Click(object sender, EventArgs e)
    {
        if (this.CompetitionNum.Text.Trim() == "")
        {
            JavaScript.Alert(this.Page, "请输入本期比赛的总场数！");
        }
        else
        {
            int num = _Convert.StrToInt(this.CompetitionNum.Text.Trim(), 0);
            if (num < 0x10)
            {
                JavaScript.Alert(this.Page, "输入的本期比赛总场数输入有误！");
            }
            else
            {
                this.DataListZCDC.Visible = true;
                this.tableCompetitionNum.Visible = false;
                DataTable table = new DataTable();
                DataColumn column = new DataColumn("ID", Type.GetType("System.Int32"));
                table.Columns.Add(column);
                column = new DataColumn("HostTeam", Type.GetType("System.String"));
                table.Columns.Add(column);
                column = new DataColumn("QuestTeam", Type.GetType("System.String"));
                table.Columns.Add(column);
                column = new DataColumn("Time", Type.GetType("System.String"));
                table.Columns.Add(column);
                for (int i = 0; i < num; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i + 1;
                    table.Rows.Add(row);
                }
                this.DataListZCDC.DataSource = table.DefaultView;
                this.DataListZCDC.DataBind();
                this.btnAdd.Enabled = true;
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
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
            DataTable table = new Tables.T_Isuses().Open("[ID]", "[Name] = '" + name + "' and LotteryID = " + Utility.FilteSqlInfusion(this.tbLotteryID.Text), "");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
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
                                int lotteryID = int.Parse(this.tbLotteryID.Text);
                                long isuseID = -1L;
                                string returnDescription = "";
                                if (Procedures.P_IsuseAdd(lotteryID, name, startTime, endTime, additionasXml, ref isuseID, ref returnDescription) < 0)
                                {
                                    PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
                                }
                                else if (isuseID < 0L)
                                {
                                    PF.GoError(1, returnDescription, base.GetType().FullName);
                                }
                                else
                                {
                                    if ((this.cbAutoNext10Isuse.Visible && this.cbAutoNext10Isuse.Checked) && (additionasXml == ""))
                                    {
                                        string str4 = name.Substring(0, name.Length - 3);
                                        int num4 = _Convert.StrToInt(name.Substring(name.Length - 3, 3), 0);
                                        for (int i = 1; i <= 9; i++)
                                        {
                                            num4++;
                                            string str5 = str4 + num4.ToString().PadLeft(3, '0');
                                            startTime = startTime.AddDays(1.0);
                                            endTime = endTime.AddDays(1.0);
                                            if (Procedures.P_IsuseAdd(lotteryID, str5, startTime, endTime, "", ref isuseID, ref returnDescription) < 0)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    base.Response.Redirect("Isuse2.aspx?LotteryID=" + this.tbLotteryID.Text, true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("Isuse2.aspx?LotteryID=" + this.tbLotteryID.Text, true);
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
        int num = _Convert.StrToInt(this.CompetitionNum.Text.Trim(), 0);
        if (num < 10)
        {
            JavaScript.Alert(this.Page, "输入的本期比赛总场数输入有误！");
            return -1;
        }
        TextBox[] boxArray = new TextBox[num];
        TextBox[] boxArray2 = new TextBox[num];
        TextBox[] boxArray3 = new TextBox[num];
        DropDownList[] listArray = new DropDownList[num];
        DropDownList[] listArray2 = new DropDownList[num];
        string[] str = new string[num * 5];
        int count = this.DataListZCDC.Items.Count;
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

    protected void DataListZCDC_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.EditItem))
        {
            DropDownList ddl = (DropDownList)e.Item.FindControl("ddlLeagueType");
            this.ddlLeagueTypeDataBind(ddl);
        }
    }

    private void ddlLeagueTypeDataBind(DropDownList ddl)
    {
        if (this.dt_FootballLeagueTypes == null)
        {
            this.dt_FootballLeagueTypes = MSSQL.Select("select * from T_FootballLeagueTypes where isUse = 1 order by [Order]", new MSSQL.Parameter[0]);
        }
        if ((this.dt_FootballLeagueTypes == null) || (this.dt_FootballLeagueTypes.Rows.Count == 0))
        {
            JavaScript.Alert(this.Page, "请先添加联赛类别！");
        }
        else
        {
            ControlExt.FillDropDownList(ddl, this.dt_FootballLeagueTypes, "Name", "ID");
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "LotteryIsuseScheme" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            int lotteryID = _Convert.StrToInt(Utility.GetRequest("LotteryID"), -1);
            if (((((lotteryID != 1) && (lotteryID != 2)) && ((lotteryID != 3) && (lotteryID != 4))) && (((lotteryID != 9) && (lotteryID != 10)) && ((lotteryID != 14) && (lotteryID != 15)))) && (lotteryID != 0x27))
            {
                PF.GoError(1, "参数错误", base.GetType().FullName);
            }
            else
            {
                this.tbLotteryID.Text = lotteryID.ToString();
                string str = Functions.F_GetLotteryIntervalType(lotteryID);
                if (str.StartsWith("分"))
                {
                    base.Response.Redirect("IsuseAddForKeno.aspx?LotteryID=" + lotteryID.ToString(), true);
                }
                else
                {
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
                            this.btnAdd.Enabled = false;
                            break;
                    }
                    this.cbAutoNext10Isuse.Visible = str == "天";
                }
            }
        }
    }


}

