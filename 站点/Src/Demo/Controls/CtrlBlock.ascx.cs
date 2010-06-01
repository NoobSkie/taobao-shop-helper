using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;
using ORM = J.SLS.Database.ORM;

public partial class Controls_CtrlBlock : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (BlockInfo != null)
        {
            PageBlockFacade facade = new PageBlockFacade();
            facade.LoadBlockContent(BlockInfo);
            if (BlockInfo.ContentItem != null)
            {
                lblTitle.Text = BlockInfo.ContentItem.Name;
                if (BlockInfo.ContentItem is ItemCollectionInfo)
                {
                    ctrlBlockHtml.Visible = false;
                    ctrlBlockList.Visible = true;
                    ctrlBlockList.BlockObject = BlockInfo.ContentItem;
                    ctrlBlockList.DisplayCount = BlockInfo.DisplayCount;
                    ctrlBlockList.OrderBy = BlockInfo.OrderBy;
                    ctrlBlockList.Direction = (ORM.SortDirection)BlockInfo.Direction;
                }
                else if (BlockInfo.ContentItem is ItemHtmlInfo
                    || BlockInfo.ContentItem is ItemDetailInfo)
                {
                    ctrlBlockHtml.Visible = true;
                    ctrlBlockList.Visible = false;
                    ctrlBlockHtml.BlockObject = BlockInfo.ContentItem;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("不支持类型\"" + BlockInfo.ContentItem.GetType().FullName + "\"在模块中展示。");
                }
            }
        }
    }

    public PageBlockInfo BlockInfo { get; set; }
}
