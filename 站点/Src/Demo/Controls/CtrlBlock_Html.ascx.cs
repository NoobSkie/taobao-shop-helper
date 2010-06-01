using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;

public partial class Controls_CtrlBlock_Html : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (BlockObject != null)
        {
            if (BlockObject is ItemDetailInfo)
            {
                lblContent.Text = (BlockObject as ItemDetailInfo).SummaryHtml;
            }
            else if (BlockObject is ItemHtmlInfo)
            {
                lblContent.Text = (BlockObject as ItemHtmlInfo).SummaryHtml;
            }
            else
            {
                throw new ArgumentOutOfRangeException("类型\"" + BlockObject.GetType().FullName + "\"的内容不能在HTML模块中展示。");
            }
        }
    }

    public ItemBase BlockObject { get; set; }
}
