using ASP;
using DAL;
using FreeTextBoxControls;
using Shove;
using Shove._IO;
using Shove._Web;
using Shove.Database;
using Shove.Web.UI;
using System;
using System.Data;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Admin_InputOpenAffiche2 : AdminPageBase, IRequiresSessionState
{


    private void BindData()
    {
        if (this.ddlIsuse.Items.Count >= 1)
        {
            object obj2 = MSSQL.ExecuteScalar("select OpenAffiche from T_Isuses where [ID] = " + Utility.FilteSqlInfusion(this.ddlIsuse.SelectedValue), new MSSQL.Parameter[0]);
            if (obj2 == null)
            {
                this.tbOpenAffiche.Text = new OpenAfficheTemplates()[int.Parse(this.ddlLottery.SelectedValue)];
            }
            else
            {
                string str = obj2.ToString();
                if (str == "")
                {
                    this.tbOpenAffiche.Text = new OpenAfficheTemplates()[int.Parse(this.ddlLottery.SelectedValue)];
                }
                else
                {
                    this.tbOpenAffiche.Text = str;
                }
            }
        }
    }

    private void BindDataForIsuse()
    {
        if (this.ddlLottery.Items.Count >= 1)
        {
            DataTable dt = new Tables.T_Isuses().Open("[ID], [Name]", "LotteryID = " + Utility.FilteSqlInfusion(this.ddlLottery.SelectedValue) + " and EndTime < GetDate() and isnull(WinLotteryNumber,'')<>''", "EndTime");
            if (dt == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
            }
            else
            {
                ControlExt.FillDropDownList(this.ddlIsuse, dt, "Name", "ID");
                if (this.ddlIsuse.Items.Count > 0)
                {
                    this.btnOK.Enabled = true;
                    this.tbOpenAffiche.ReadOnly = false;
                }
                else
                {
                    this.btnOK.Enabled = false;
                    this.tbOpenAffiche.ReadOnly = true;
                }
                this.BindData();
            }
        }
    }

    private void BindDataForLottery()
    {
        DataTable dt = new Tables.T_Lotteries().Open("[ID], [Name]", "[ID] in (1,2,3,4,9,10,14,15,39)", "[Order]");
        if (dt == null)
        {
            PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
        }
        else
        {
            ControlExt.FillDropDownList(this.ddlLottery, dt, "Name", "ID");
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (this.ddlIsuse.Items.Count >= 1)
        {
            if ((this.fileVideo.Value != "") && (File.UploadFile(this.Page, this.fileVideo, "../Images/Video/", this.ddlIsuse.SelectedValue + ".avi", true, "video") < 0))
            {
                JavaScript.Alert(this.Page, "文件上传错误。");
            }
            else if (MSSQL.ExecuteNonQuery("update T_Isuses set OpenAffiche = @p1 where [ID] = " + this.ddlIsuse.SelectedValue, new MSSQL.Parameter[] { new MSSQL.Parameter("p1", SqlDbType.VarChar, 0, ParameterDirection.Input, this.tbOpenAffiche.Text) }) < 0)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().FullName);
            }
            else
            {
                JavaScript.Alert(this.Page, "数据保存成功。");
            }
        }
    }

    protected void ddlIsuse_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindData();
    }

    protected void ddlLottery_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindDataForIsuse();
    }

    protected override void OnInit(EventArgs e)
    {
        base.RequestLoginPage = base.Request.Url.AbsoluteUri;
        base.RequestCompetences = Competences.BuildCompetencesList(new string[] { "FillContent" });
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.BindDataForLottery();
            this.BindDataForIsuse();
            this.BindData();
        }
    }


}

