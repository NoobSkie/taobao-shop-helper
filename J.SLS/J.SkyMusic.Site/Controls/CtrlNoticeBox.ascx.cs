using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

public partial class Controls_CtrlNoticeBox : BaseControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NoticeFacade facade = new NoticeFacade();
            IList<NoticeInfo> noticeList = facade.GetCurrentNoticeList();
            rptNoticeList.DataSource = noticeList;
            rptNoticeList.DataBind();

            _hasNotice = (noticeList != null && noticeList.Count > 0);
        }
    }

    private bool _hasNotice = false;
    protected bool HasNotice { get { return _hasNotice; } }

    protected void rptNoticeList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            NoticeInfo notice = e.Item.DataItem as NoticeInfo;
            HyperLink hlnk = e.Item.FindControl("hlnk") as HyperLink;
            string name = notice.Title;
            if (notice.IsForeRed)
            {
                name = "<font color='red'>" + name + "</font>";
            }
            if (notice.IsForeBold)
            {
                name = "<b>" + name + "</b>";
            }
            hlnk.Text = name;
            //if (e.Item.ItemIndex != 0)
            //{
            //    hlnk.Attributes["style"] = "display: none;";
            //}
            if (notice.IsHasDetail)
            {
                hlnk.NavigateUrl = string.Format("~/ShowNotice.aspx?n={0}", notice.Id);
            }
        }
    }
}
