using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;
using J.SLS.Common.Exceptions;

public partial class Admins_EditNotice : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NoticeFacade facade = new NoticeFacade();
            if (IsAdd)
            {
                lblTitle.Text = "添加新通知";
            }
            else
            {
                string noticeId = Request["id"];
                NoticeInfo noticeInfo = facade.GetNoticeMessage(noticeId);
                if (noticeInfo != null)
                {
                    BindNoticeInfo(noticeInfo);
                    lblTitle.Text = "编辑通知 -> " + noticeInfo.Name;
                }
            }
        }
    }
    private void BindNoticeInfo(NoticeInfo noticeInfo)
    {
        txtName.Text = noticeInfo.Name;
        txtTitle.Text = noticeInfo.Title;
        txtContent.Text = noticeInfo.Message;
        txtStartTime.Text = noticeInfo.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
        txtEndTime.Text = noticeInfo.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
        cbHasDetail.Checked = noticeInfo.IsHasDetail;
        cbIsForeBold.Checked = noticeInfo.IsForeBold;
        cbIsForeRed.Checked = noticeInfo.IsForeRed;
        cbIsEnd.Checked = noticeInfo.IsEnd;
    }
    private bool IsAdd
    {
        get
        {
            return string.IsNullOrEmpty(Request["id"]);
        }
    }
    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            NoticeFacade facade = new NoticeFacade();
            NoticeInfo notice = new NoticeInfo();
            notice.Name = txtName.Text.Trim();
            notice.Title = txtTitle.Text.Trim();
            notice.Message = txtContent.Text;
            DateTime startTime = DateTime.Now;
            if (txtStartTime.Text.Trim() != "")
            {
                startTime = DateTime.Parse(txtStartTime.Text);
            }
            notice.StartTime = startTime;
            DateTime endTime = DateTime.Now.AddYears(100);
            if (txtEndTime.Text.Trim() != "")
            {
                endTime = DateTime.Parse(txtEndTime.Text);
            }
            notice.EndTime = endTime;
            notice.IsHasDetail = cbHasDetail.Checked;
            notice.IsForeBold = cbIsForeBold.Checked;
            notice.IsForeRed = cbIsForeRed.Checked;
            notice.IsEnd = cbIsEnd.Checked;

            string msg;
            if (IsAdd)
            {
                facade.AddNotice(notice);
                msg = string.Format("添加通知成功 - \"{0}\"", txtName.Text.Trim());
            }
            else
            {
                notice.Id = Request["id"];
                facade.ModifyNotice(notice);
                msg = string.Format("修改通知成功 - \"{0}\"", txtName.Text.Trim());
            }
            JavascriptAlertAndRedirect(msg, "NoticeManagement.aspx");
        }
        catch (FacadeException ex)
        {
            JavascriptAlert(ex.Message);
        }
        catch
        {
            JavascriptAlert(@"保存通知发生未知错误，请联系系统配置人员！");
        }
    }
}
