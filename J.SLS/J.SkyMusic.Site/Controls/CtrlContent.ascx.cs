using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.DbFacade.Services;

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

    public HtmlItemFullInfo ContentItem { get; set; }

    private void LoadScripts(HtmlItemFullInfo htmlItem)
    {
        //if (htmlItem.IncludeScriptFileList != null && htmlItem.IncludeScriptFileList.Count > 0)
        //{
        //}
    }

    private void LoadStyles(HtmlItemFullInfo htmlItem)
    {
        //if (htmlItem.IncludeStyleFileList != null && htmlItem.IncludeStyleFileList.Count > 0)
        //{
        //}
    }

    private void LoadContent(HtmlItemFullInfo htmlItem)
    {
        lblTitle.Text = htmlItem.Title;
        lblCreateTime.Text = htmlItem.CreateTime.ToString("yyyy年MM月dd日 hh:mm:ss");
        lblUpdateTime.Text = htmlItem.LastUpdateTime.ToString("yyyy年MM月dd日 hh:mm:ss");
        lblContent.Text = htmlItem.Content;
    }
}
