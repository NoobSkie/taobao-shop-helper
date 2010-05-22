namespace Shove._Web
{
    using System;
    using System.Web.UI;

    public class JavaScript
    {
        public static void AddFavorite(Page page, string url, string SiteName)
        {
            page.Response.Write("<script language=javascript>window.external.addFavorite('" + url + "','" + SiteName + "');</script>");
        }

        public static void Alert(Page page, string Msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<Script language=javascript>alert('" + Msg + "');</script>");
        }

        public static void Alert(Page page, string Msg, string RedirectUrl)
        {
            Alert(page, Msg, RedirectUrl, "");
        }

        public static void Alert(Page page, string Msg, string RedirectUrl, string FrameName)
        {
            FrameName = FrameName.Trim();
            if (!string.IsNullOrEmpty(FrameName))
            {
                FrameName = FrameName + ".";
            }
            if (!string.IsNullOrEmpty(RedirectUrl))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "", "<Script language=javascript>alert('" + Msg + "');window." + FrameName + "location.replace('" + RedirectUrl + "')</script>");
            }
            else
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "", "<Script language=javascript>alert('" + Msg + "');window." + FrameName + "location.href = window." + FrameName + "location.href</script>");
            }
        }

        public static void ClosePage(Page page)
        {
            page.Response.Write("<script language=javascript>window.opener=null;window.close();</script>");
        }

        public static void OpenModalWindow(Page page, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script language=javascript>window.showModalDialog('" + url + "',null,'center: Yes; help: No; resizable: No; status: No; maximize:No; minimize:no; scrollbars:no');</script>");
        }

        public static void OpenModalWindow(Page page, string url, int width, int height)
        {
            string str = "dialogHeight:" + height.ToString() + "px; dialogWidth:" + width.ToString() + "px; center: Yes; help: No; resizable: No; status: No; maximize:No; minimize:no; scrollbars:no";
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script language=javascript>window.showModalDialog('" + url + "',null,'" + str + "');</script>");
        }

        public static void OpenModalWindow(Page page, string url, int width, int height, int top, int left)
        {
            string str = "dialogHeight:" + height.ToString() + "px; dialogLeft:" + left.ToString() + "px; dialogWidth:" + width.ToString() + "px;dialogTop:" + top.ToString() + "px; center: No; help: No; resizable: No; status: No; maximize:no; minimize:no; scrollbars:no";
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "<script language=javascript>window.showModalDialog('" + url + "',null,'" + str + "');</script>");
        }

        public static void OpenWindow(Page page, string url)
        {
            page.Response.Write("<script Language=JavaScript>ChildWindow = window.open('" + url + "', 'newwindow', '')</script>");
        }

        public static void PopupWindow(Page page, string url)
        {
            page.Response.Write("<script Language=JavaScript>ChildWindow = window.open('" + url + "', 'popupwindow', 'toolbar=no,status=no,location=no,menubar=no,directories=no,scrollbars=no,resizable=no')</script>");
        }

        public static void PopupWindow(Page page, string url, int width, int height, int top, int left)
        {
            page.Response.Write("<script Language=JavaScript>ChildWindow = window.open('" + url + "', 'popupwindow', 'width=" + width.ToString() + ",height=" + height.ToString() + ",top=" + top.ToString() + ",left=" + left.ToString() + ",toolbar=no,status=no,location=no,menubar=no,directories=no,scrollbars=no,resizable=no')</script>");
        }

        public static void RefreshFrame(Page page, string FrameName)
        {
            page.Response.Write("<script language=javascript>window.parent.frames[\"" + FrameName + "\"].document.location.href=window.parent.frames[\"" + FrameName + "\"].document.location.href;</script>");
        }

        public static void SetHomePage(Page page, string url)
        {
            page.Response.Write("<script language=javascript>this.style.behavior='url(#default#homepage)';this.setHomePage('" + url + "');return false;</script>");
        }

        public static void SetWindowSize(Page page, int x, int y)
        {
            page.Response.Write("<script language='javascript'>window.resizeTo(" + x.ToString() + "," + y.ToString() + ");</script>");
        }
    }
}

