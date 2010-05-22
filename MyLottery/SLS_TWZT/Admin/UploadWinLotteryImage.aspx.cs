using ASP;
using DAL;
using Shove;
using Shove._IO;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.IO;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_UploadWinLotteryImage : AdminPageBase, IRequiresSessionState
{

    protected void btnGO_Click(object sender, EventArgs e)
    {
        string str = Utility.FilteSqlInfusion(this.tbSchemeNumber.Text.Trim());
        if (str == "")
        {
            JavaScript.Alert(this.Page, "请输入方案号。");
        }
        else
        {
            DataTable table = new Tables.T_Schemes().Open("", "SchemeNumber='" + str + "'", "");
            if (table == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", "Admin_UploadWinLotteryImage");
            }
            else if (table.Rows.Count < 1)
            {
                JavaScript.Alert(this.Page, "方案号不存在。");
            }
            else
            {
                DataRow row = table.Rows[0];
                if (!_Convert.StrToBool(row["Buyed"].ToString(), false))
                {
                    JavaScript.Alert(this.Page, "该方案号没有出票。");
                }
                else if (Shove._IO.File.UploadFile(this.Page, this.fileImage, "../Temp/", "SchemeWinImage" + str + ".jpg", true, "image") < 0)
                {
                    JavaScript.Alert(this.Page, "文件上传错误。");
                }
                else
                {
                    string path = base.Server.MapPath("../Temp/SchemeWinImage" + str + ".jpg");
                    byte[] buffer = System.IO.File.ReadAllBytes(path);
                    System.IO.File.Delete(path);
                    if (buffer == null)
                    {
                        JavaScript.Alert(this.Page, "文件格式错误。");
                    }
                    else
                    {
                        MSSQL.ExecuteNonQuery("update T_Schemes set WinImage = @p1 where [SchemeNumber] = @p2", new MSSQL.Parameter[] { new MSSQL.Parameter("p1", SqlDbType.VarChar, 0, ParameterDirection.Input, buffer), new MSSQL.Parameter("p2", SqlDbType.VarChar, 0, ParameterDirection.Input, str) });
                        JavaScript.Alert(this.Page, "文件上传成功！");
                    }
                }
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "FillContent" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

}

