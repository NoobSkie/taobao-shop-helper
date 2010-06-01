using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;

public partial class Admin_CollectionManagement : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string collectionId = Request["cid"];
        if (string.IsNullOrEmpty(collectionId))
        {
            RedirectToUrl("Default.aspx");
        }
        Guid id = new Guid(collectionId);
        ItemCollectionFacade facade = new ItemCollectionFacade();
        hlnkAdd.Text = "添加 - " + facade.GetItemById(id).Name;
        hlnkAdd.NavigateUrl = "CollectionEdit.aspx?t=a&cid=" + collectionId;
        BindCollection(id);
    }

    private void BindCollection(Guid id)
    {
        ItemCollectionFacade facade = new ItemCollectionFacade();
        int totalCount;
        IList<ItemDetailInfo> list = facade.GetChildrenItemList(id, gvList.PageIndex, gvList.PageSize, out totalCount, "LastUpdateDate", J.SLS.Database.ORM.SortDirection.Desc);
        gvList.DataSource = list;
        gvList.DataBind();
    }
}
