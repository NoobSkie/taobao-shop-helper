using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class ShowNotice : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NoticeFacade facade = new NoticeFacade();
            string noticeId = Request["n"];
            if (!string.IsNullOrEmpty(noticeId))
            {
                NoticeInfo noticeInfo = facade.GetNoticeMessage(noticeId);
                if (noticeInfo != null)
                {
                    lblContent.Text = noticeInfo.Message;
                }
            }
        }
    }
}
