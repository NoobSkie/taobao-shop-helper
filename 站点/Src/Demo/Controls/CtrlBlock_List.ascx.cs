using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;
using ORM = J.SLS.Database.ORM;

public partial class Controls_CtrlBlock_List : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (BlockObject != null)
        {
            if (BlockObject is ItemCollectionInfo)
            {
                ItemCollectionFacade facade = new ItemCollectionFacade();
                int totalCount;
                int pageIndex = 0;
                IList<ItemDetailInfo> itemList = facade.GetChildrenItemList(BlockObject.Id, pageIndex, DisplayCount, out totalCount, OrderBy, Direction);
                rptList.DataSource = itemList;
                rptList.DataBind();
            }
            else
            {
                throw new ArgumentOutOfRangeException("类型\"" + BlockObject.GetType().FullName + "\"的内容不能在列表模块中展示。");
            }
        }
    }

    public ItemBase BlockObject { get; set; }

    public int DisplayCount { get; set; }

    public string OrderBy { get; set; }

    public ORM.SortDirection Direction { get; set; }
}
