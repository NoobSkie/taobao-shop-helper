using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;

public partial class Controls_CtrlContent : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (ContentItem != null)
            {
                LoadScripts(ContentItem);
                LoadStyles(ContentItem);
                LoadContent(ContentItem);
            }
        }
    }

    public HtmlItem ContentItem { get; set; }

    private void LoadScripts(HtmlItem htmlItem)
    {
        if (htmlItem.IncludeScriptFileList != null && htmlItem.IncludeScriptFileList.Count > 0)
        {
        }
    }

    private void LoadStyles(HtmlItem htmlItem)
    {
        if (htmlItem.IncludeStyleFileList != null && htmlItem.IncludeStyleFileList.Count > 0)
        {
        }
    }

    private void LoadContent(HtmlItem htmlItem)
    {
        if (htmlItem.IncludeStyleFileList != null && htmlItem.IncludeStyleFileList.Count > 0)
        {
            lblTitle.Text = ContentItem.Title;
            lblCreateTime.Text = ContentItem.CreateTime.ToString("yyyy年MM月dd日 hh:mm:ss");
            lblUpdateTime.Text = ContentItem.LastUpdateTime.ToString("yyyy年MM月dd日 hh:mm:ss");
            lblContent.Text = ContentItem.Content;
        }
    }
}
