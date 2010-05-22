using ASP;
using DAL;
using FredCK.FCKeditorV2;
using Shove;
using Shove._Web;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_Admin_NPIsusesAdd : AdminPageBase, IRequiresSessionState
{


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int num = 0;
        try
        {
            num = _Convert.StrToInt(this.tbIsuse.Text.Trim(), 0);
        }
        catch
        {
        }
        if (num == 0)
        {
            JavaScript.Alert(this.Page, "彩友报期号只能是整数！");
        }
        else
        {
            DateTime time;
            DateTime time2;
            try
            {
                time = Convert.ToDateTime(this.tbStartTime.Text);
            }
            catch
            {
                JavaScript.Alert(this.Page, "开始时间格式输入错误！");
                return;
            }
            try
            {
                time2 = Convert.ToDateTime(this.tbEndTime.Text);
            }
            catch
            {
                JavaScript.Alert(this.Page, "截止时间格式输入错误！");
                return;
            }
            if (time2 >= time)
            {
                string str = _Convert.ToTextCode(this.tbContent.Value.Trim());
                if (str == "")
                {
                    JavaScript.Alert(this.Page, "请输入开奖信息！");
                }
                else if (this.HidID.Value == "")
                {
                    DataTable table = new Tables.T_NewsPaperIsuses().Open("[ID]", "[Name] = '" + num.ToString().PadLeft(this.tbIsuse.Text.Length, '0') + "'", "");
                    if (table == null)
                    {
                        PF.GoError(4, "数据库繁忙，请重试", "Admin_Admin_NPIsusesAdd");
                    }
                    else if (table.Rows.Count > 0)
                    {
                        JavaScript.Alert(this.Page, "期号已经存在，请不要输入重名期号！");
                    }
                    else if (new Tables.T_NewsPaperIsuses { Name = { Value = num.ToString().PadLeft(this.tbIsuse.Text.Length, '0') }, StartTime = { Value = time.ToString("yyyy-MM-dd") }, EndTime = { Value = time2.ToString("yyyy-MM-dd") }, NPMessage = { Value = str } }.Insert() < 0L)
                    {
                        JavaScript.Alert(this.Page, "添加彩友报期号失败！");
                    }
                    else
                    {
                        Shove._Web.Cache.ClearCache("Home_Room_NewsPaper_BindNewsPaper_" + this.HidID.Value);
                        JavaScript.Alert(this.Page, "添加期号成功！");
                    }
                }
                else
                {
                    DataTable table2 = new Tables.T_NewsPaperIsuses().Open("[ID]", "[Name] = '" + num.ToString().PadLeft(this.tbIsuse.Text.Length, '0') + "' and ID<>" + this.HidID.Value, "");
                    if (table2 == null)
                    {
                        PF.GoError(4, "数据库繁忙，请重试", "Admin_IsuseAdd");
                    }
                    else if (table2.Rows.Count > 0)
                    {
                        JavaScript.Alert(this.Page, "期号已经存在，请不要输入重名期号！");
                    }
                    else if (new Tables.T_NewsPaperIsuses { Name = { Value = num.ToString().PadLeft(this.tbIsuse.Text.Length, '0') }, StartTime = { Value = time }, EndTime = { Value = time2 }, NPMessage = { Value = str } }.Update("ID=" + this.HidID.Value) < 0L)
                    {
                        JavaScript.Alert(this.Page, "修改失败！");
                    }
                    else
                    {
                        Shove._Web.Cache.ClearCache("Home_Room_NewsPaper_BindNewsPaper_" + this.HidID.Value);
                        JavaScript.Alert(this.Page, "修改成功！");
                    }
                }
            }
            else
            {
                JavaScript.Alert(this.Page, "截止时间应该在开始时间之后！");
            }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("Admin_NewsPaper.aspx");
    }

    private string FormatWinNumber()
    {
        return "<table cellspacing='1' cellpadding='0' width='450' bgcolor='#dddddd' border='0'>\r\n                            <tbody>\r\n                                <tr>\r\n                                    <td class='blue14' align='center' width='75' bgcolor='#ecf9ff' height='30'><strong>彩种</strong></td>\r\n                                    <td class='blue14' align='center' width='62' bgcolor='#ecf9ff'><strong>期号</strong></td>\r\n                                    <td class='blue14' align='center' width='191' bgcolor='#ecf9ff'><strong>开奖号码</strong></td>\r\n                                    <td class='blue14' align='center' width='117' bgcolor='#ecf9ff'><strong>开奖时间</strong></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#ffffff' height='30'>双色球</td>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#ffffff'>09095</td>\r\n                                    <td class='hui14_2' style='padding-left: 10px' align='left' bgcolor='#ffffff' height='60'><span class='red14_2'>08 09 14 28 31 33</span> +<span class='blue14'>15</span>\r\n                                    <table cellspacing='0' cellpadding='0' width='92%' border='0'>\r\n                                        <tbody>\r\n                                            <tr>\r\n                                                <td height='8'>\r\n                                                <div id='hr'>&nbsp;</div>\r\n                                                </td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td class='blue12'>奖池滚存：284,973,985元</td>\r\n                                            </tr>\r\n                                        </tbody>\r\n                                    </table>\r\n                                    </td>\r\n                                    <td class='hui12' align='center' bgcolor='#ffffff'>二 四 日 (明天开奖)</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#f7f7f7' height='30'>大乐透</td>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#f7f7f7'>09094</td>\r\n                                    <td class='hui14_2' style='padding-left: 10px' align='left' bgcolor='#f7f7f7' height='60'><span class='red14_2'>01 05 21 23 29</span> + <span class='blue14'>05 12</span>\r\n                                    <table cellspacing='0' cellpadding='0' width='92%' border='0'>\r\n                                        <tbody>\r\n                                            <tr>\r\n                                                <td height='8'>\r\n                                                <div id='hr'>&nbsp;</div>\r\n                                                </td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td class='blue12'>奖池滚存：284,973,985元</td>\r\n                                            </tr>\r\n                                        </tbody>\r\n                                    </table>\r\n                                    </td>\r\n                                    <td class='hui12' align='center' bgcolor='#f7f7f7'>一 三 六 (今日开奖)</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#ffffff' height='30'>七乐彩</td>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#ffffff'>09094</td>\r\n                                    <td class='hui14_2' style='padding-left: 10px' align='left' bgcolor='#ffffff'><span class='red14_2'>07 14 18 22 23 25 30</span> +<span class='blue14'>04</span></td>\r\n                                    <td class='hui12' align='center' bgcolor='#ffffff'>一 三 五 (今日开奖)</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#f7f7f7' height='30'>东方6+1</td>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#f7f7f7'>09094</td>\r\n                                    <td class='hui14_2' style='padding-left: 10px' align='left' bgcolor='#f7f7f7' height='60'><span class='red14_2'>7 8 1 5 6 1</span> +<span class='blue14'> 牛</span>\r\n                                    <table cellspacing='0' cellpadding='0' width='92%' border='0'>\r\n                                        <tbody>\r\n                                            <tr>\r\n                                                <td height='8'>\r\n                                                <div id='hr'>&nbsp;</div>\r\n                                                </td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td class='blue12'>奖池滚存：284,973,985元</td>\r\n                                            </tr>\r\n                                        </tbody>\r\n                                    </table>\r\n                                    </td>\r\n                                    <td class='hui12' align='center' bgcolor='#f7f7f7'>一 三 六 (今日开奖)</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#ffffff' height='30'>福彩3D</td>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#ffffff'>09221</td>\r\n                                    <td class='red14_2' style='padding-left: 10px' align='left' bgcolor='#ffffff'>8 5 6</td>\r\n                                    <td class='hui12' align='center' bgcolor='#ffffff'>每日</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#f7f7f7' height='30'>七星彩</td>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#f7f7f7'>09095</td>\r\n                                    <td class='red14_2' style='padding-left: 10px' align='left' bgcolor='#f7f7f7' height='60'>3 3 1 3 9 7 2\r\n                                    <table cellspacing='0' cellpadding='0' width='92%' border='0'>\r\n                                        <tbody>\r\n                                            <tr>\r\n                                                <td height='8'>\r\n                                                <div id='hr'>&nbsp;</div>\r\n                                                </td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td class='blue12'>奖池滚存：284,973,985元</td>\r\n                                            </tr>\r\n                                        </tbody>\r\n                                    </table>\r\n                                    </td>\r\n                                    <td class='hui12' align='center' bgcolor='#f7f7f7'>二 五 日(明天开奖)</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#ffffff' height='30'>15选5</td>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#ffffff'>09221</td>\r\n                                    <td class='red14_2' style='padding-left: 10px' align='left' bgcolor='#ffffff'>03 04 06 12 15</td>\r\n                                    <td class='hui12' align='center' bgcolor='#ffffff'>每日</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#f7f7f7' height='30'>22选5</td>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#f7f7f7'>09221</td>\r\n                                    <td class='red14_2' style='padding-left: 10px' align='left' bgcolor='#f7f7f7'>03 09 15 17 20</td>\r\n                                    <td class='hui12' align='center' bgcolor='#f7f7f7'>每日</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#ffffff' height='30'>排列3</td>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#ffffff'>09221</td>\r\n                                    <td class='red14_2' style='padding-left: 10px' align='left' bgcolor='#ffffff'>8 2 2</td>\r\n                                    <td class='hui12' align='center' bgcolor='#ffffff'>每日</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#f7f7f7' height='30'>排列5</td>\r\n                                    <td class='hui12' style='padding-left: 10px' align='left' bgcolor='#f7f7f7'>09221</td>\r\n                                    <td class='red14_2' style='padding-left: 10px' align='left' bgcolor='#f7f7f7'>8 2 2 9 7</td>\r\n                                    <td class='hui12' align='center' bgcolor='#f7f7f7'>每日</td>\r\n                                </tr>\r\n                            </tbody>\r\n                        </table>";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.HidID.Value = Utility.GetRequest("ID");
            if (!string.IsNullOrEmpty(this.HidID.Value))
            {
                DataTable table = new Tables.T_NewsPaperIsuses().Open("", "ID=" + this.HidID.Value, "");
                if ((table == null) || (table.Rows.Count == 0))
                {
                    PF.GoError(4, "期号不存在！", base.GetType().BaseType.FullName);
                }
                else
                {
                    DataRow row = table.Rows[0];
                    this.tbStartTime.Text = row["StartTime"].ToString();
                    this.tbEndTime.Text = row["EndTime"].ToString();
                    this.tbIsuse.Text = row["Name"].ToString();
                    this.tbContent.Value = row["NPMessage"].ToString();
                    this.btnAdd.Text = "修改";
                }
            }
        }
    }

}

