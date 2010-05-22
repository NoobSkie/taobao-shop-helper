using AjaxPro;
using ASP;
using DAL;
using Shove;
using Shove._Web;
using Shove.Database;
using System;
using System.Data;
using System.Text;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Home_Room_QuestionnaireSurvey : SitePageBase, IRequiresSessionState
{

    private void BindQuestionnaireSurvey()
    {
        StringBuilder builder = new StringBuilder();
        DataTable questionnaireSurveyQuestions = this.GetQuestionnaireSurveyQuestions();
        DataTable questionnaireSurveyAnswer = this.GetQuestionnaireSurveyAnswer();
        for (int i = 0; i < questionnaireSurveyQuestions.Rows.Count; i++)
        {
            int num2 = i + 1;
            builder.Append("<tr>").Append("<td height=\"30\">").Append("<strong>").Append(num2.ToString()).Append("、").Append(questionnaireSurveyQuestions.Rows[i]["Name"].ToString()).Append("：</strong>");
            bool flag = _Convert.StrToBool(questionnaireSurveyQuestions.Rows[i]["IsCanSelectMuch"].ToString(), false);
            if (flag)
            {
                builder.Append("（可多选）");
            }
            builder.Append("</td>").Append("</tr>").Append("<tr>").Append("<td>").Append("<table width=\"700\" border=\"0\" align=\"left\" cellpadding=\"0\" cellspacing=\"0\">");
            DataRow[] rowArray = questionnaireSurveyAnswer.Select("IsSystem = 1 and QuestionID=" + questionnaireSurveyQuestions.Rows[i]["ID"].ToString());
            int length = rowArray.Length;
            bool flag2 = _Convert.StrToBool(questionnaireSurveyQuestions.Rows[i]["IsCustomAnswer"].ToString(), false);
            int num4 = 0;
            bool flag3 = false;
            foreach (DataRow row in rowArray)
            {
                if ((num4 % 4) == 0)
                {
                    flag3 = false;
                    builder.Append("<tr>");
                }
                else
                {
                    flag3 = true;
                }
                builder.Append("<td height=\"26\" ");
                if ((num4 == (length - 1)) && ((length % 4) != 0))
                {
                    int num6 = 5 - (length % 4);
                    builder.Append(string.Concat(new object[] { "colspan='", num6, "' width='", 170 * num6, "'>" }));
                }
                else
                {
                    builder.Append("width='170'>");
                }
                if (flag)
                {
                    builder.Append("<input type='checkbox' ");
                }
                else
                {
                    builder.Append("<input type='radio' name='radioAnswer" + row["QuestionID"].ToString() + "' ");
                    if (row["Name"].ToString() == "其它")
                    {
                        builder.Append("onclick=\"this.nextSibling.nextSibling.disabled = false;\" ");
                    }
                    else
                    {
                        builder.Append("onclick=\"if(document.getElementById('tbQuestion" + row["QuestionID"].ToString() + "')!=null) {document.getElementById('tbQuestion" + row["QuestionID"].ToString() + "').disabled = true;}\" ");
                    }
                }
                builder.Append("id='cb" + row["ID"].ToString() + "' value='" + row["ID"].ToString() + "'/>").Append(row["Name"].ToString());
                if ((num4 == (length - 1)) && flag2)
                {
                    builder.Append("<input  type='text' id='tbQuestion" + row["QuestionID"].ToString() + "' size='20' class='wenben'  disabled='true'/>");
                }
                builder.Append("</td>");
                if (flag3 && (((num4 % 4) == 3) || (num4 >= (length - 1))))
                {
                    builder.Append("</tr>");
                }
                num4++;
            }
            builder.Append("</table>").Append("</td>").Append("</tr>").Append("<tr>").Append("<td height='10'></td>").Append("</tr>");
        }
        this.tbQuestion.InnerHtml = builder.ToString();
    }

    private DataTable GetQuestionnaireSurveyAnswer()
    {
        string key = "Home_Room_QuestionnaireSurvey_GetQuestionnaireSurveyAnswer";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_QuestionnaireSurveyAnswer().Open("", "", "ID asc");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试！", base.GetType().BaseType.FullName);
                return null;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        return cacheAsDataTable;
    }

    private DataTable GetQuestionnaireSurveyQuestions()
    {
        string key = "Home_Room_QuestionnaireSurvey_GetQuestionnaireSurveyQuestions";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_QuestionnaireSurveyQuestions().Open("", "", "ID asc");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试！", base.GetType().BaseType.FullName);
                return null;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0x1770);
        }
        return cacheAsDataTable;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Home_Room_QuestionnaireSurvey), this.Page);
        if (!base.IsPostBack)
        {
            this.BindQuestionnaireSurvey();
        }
    }

    [AjaxMethod(HttpSessionStateRequirement.Read)]
    public void SubmitQuestionnaireSurvey(string check, string input, string suggestion)
    {
        check = Shove._Web.Utility.FilteSqlInfusion(check.Trim());
        input = Shove._Web.Utility.FilteSqlInfusion(input.Trim());
        suggestion = Shove._Web.Utility.FilteSqlInfusion(suggestion.Trim());
        if (!string.IsNullOrEmpty(check))
        {
            foreach (string str in check.Split(new char[] { ',' }))
            {
                if (!string.IsNullOrEmpty(str))
                {
                    MSSQL.ExecuteNonQuery("update T_QuestionnaireSurveyAnswer set SelectCount = SelectCount + 1 where ID = @ID", new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.Int, 0, ParameterDirection.Input, str) });
                }
            }
        }
        if (!string.IsNullOrEmpty(input))
        {
            foreach (string str2 in input.Split(new char[] { ',' }))
            {
                if (!string.IsNullOrEmpty(str2) && !string.IsNullOrEmpty(str2.Split(new char[] { '|' })[1]))
                {
                    DataTable table = MSSQL.Select("select ID from T_QuestionnaireSurveyAnswer where QuestionID = @ID and IsSystem = 0", new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.Int, 0, ParameterDirection.Input, str2.Split(new char[] { '|' })[0]) });
                    if (table.Rows.Count == 0)
                    {
                        new Tables.T_QuestionnaireSurveyAnswer { Name = { Value = str2.Split(new char[] { '|' })[1] }, QuestionID = { Value = str2.Split(new char[] { '|' })[0] }, SelectCount = { Value = 1 }, IsSystem = { Value = false } }.Insert();
                    }
                    else
                    {
                        MSSQL.ExecuteNonQuery("update T_QuestionnaireSurveyAnswer set SelectCount = SelectCount + 1 where ID = @ID", new MSSQL.Parameter[] { new MSSQL.Parameter("ID", SqlDbType.Int, 0, ParameterDirection.Input, table.Rows[0]["ID"].ToString()) });
                    }
                }
            }
        }
        if (!string.IsNullOrEmpty(suggestion))
        {
            new Tables.T_QuestionnaireSurveySuggestions { Suggestions = { Value = suggestion } }.Insert();
        }
    }
}

