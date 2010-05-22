using ASP;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

public partial class Admin_Backup : AdminPageBase, IRequiresSessionState
{
    protected void btnOK_2_Click(object sender, EventArgs e)
    {
        SqlConnection connection = MSSQL.CreateDataConnection();
        if (connection == null)
        {
            JavaScript.Alert(this.Page, "数据库备份失败！");
        }
        else
        {
            string backupFileName = base.Server.MapPath("../App_Data/" + connection.Database + ".bak");
            string str2 = connection.Database + ".zip";
            connection.Close();
            if (MSSQL.BackupDatabase(backupFileName, true, true) < 0)
            {
                JavaScript.Alert(this.Page, "数据库备份失败！");
            }
            else
            {
                HttpResponse response = this.Page.Response;
                response.AppendHeader("Content-Disposition", "attachment;filename=" + str2);
                base.Response.ContentType = "application/octet-stream";
                base.Response.WriteFile(backupFileName + ".zip");
                base.Response.Flush();
                response.End();
            }
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        byte[] buffer = MSSQL.BackupDataToZipStream();
        if (buffer == null)
        {
            JavaScript.Alert(this.Page, "数据表备份失败！");
        }
        else
        {
            HttpResponse response = this.Page.Response;
            response.AppendHeader("Content-Disposition", "attachment;filename=ShoveLottery_DataBackup_" + DateTime.Now.ToString().Replace("-", "_").Replace(" ", "_").Replace(":", "_") + ".zip");
            base.Response.ContentType = "application/octet-stream";
            base.Response.BinaryWrite(buffer);
            base.Response.Flush();
            response.End();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "Administrator" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.btnOK_2.Enabled = false;
    }
}

