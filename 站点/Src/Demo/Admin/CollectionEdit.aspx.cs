using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using J.SkyMusic.Facade;

public partial class Admin_CollectionEdit : BaseAdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string type = Request["t"];
            string collectionId = Request["cid"];
            string url = "CollectionManagement.aspx?cid=" + collectionId;

            Guid cid = new Guid(collectionId);
            ItemCollectionFacade facade = new ItemCollectionFacade();
            ItemCollectionInfo collection = facade.GetItemById(cid) as ItemCollectionInfo;
            if (collection == null)
            {
                JavascriptAlertAndRedirect("参数错误 - 未找到集合！", url);
                return;
            }
            else
            {
                hlnkCancel.NavigateUrl = url;
            }

            switch (type.ToLower())
            {
                case "a":
                    ClearText();
                    lbtnSave.Text = "添加";
                    break;
                case "e":
                    string id = Request["id"];
                    BindItem(id, url);
                    lbtnSave.Text = "修改";
                    break;
                default:
                    JavascriptAlertAndRedirect("参数错误 - 缺少类型！", url);
                    break;
            }
        }
    }

    private void ClearText()
    {
        txtName.Text = "";
        txtTitle.Text = "";
        txtContent.Text = "";
        txtSummary.Text = "";
    }

    private void BindItem(string itemId, string url)
    {
        Guid id = new Guid(itemId);
        ItemDetailFacade facade = new ItemDetailFacade();
        ItemDetailInfo itemInfo = facade.GetItemById(id) as ItemDetailInfo;
        if (itemInfo != null)
        {
            txtName.Text = itemInfo.Name;
            txtTitle.Text = itemInfo.TitleHtml;
            txtContent.Text = itemInfo.AllHtml;
            txtSummary.Text = itemInfo.SummaryHtml;
        }
        else
        {
            JavascriptAlertAndRedirect("参数错误 - 对象不存在！", url);
        }
    }

    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        string type = Request["t"];
        string collectionId = Request["cid"];
        string url = "CollectionManagement.aspx?cid=" + collectionId;
        switch (type.ToLower())
        {
            case "a":
                AddItem(collectionId);
                JavascriptAlertAndRedirect("新增成功！", url);
                break;
            case "e":
                string id = Request["id"];
                UpdateItem(id, url);
                JavascriptAlertAndRedirect("修改成功！", url);
                break;
            default:
                JavascriptAlertAndRedirect("参数错误 - 缺少类型！", url);
                break;
        }
    }

    private void AddItem(string pid)
    {
        ItemDetailFacade facade = new ItemDetailFacade();
        ItemDetailInfo itemInfo = new ItemDetailInfo();
        itemInfo.Id = Guid.NewGuid();
        itemInfo.ItsCollectionId = new Guid(pid);
        itemInfo.Name = txtName.Text;
        itemInfo.TitleHtml = txtTitle.Text;
        itemInfo.AllHtml = txtContent.Text;
        itemInfo.SummaryHtml = txtSummary.Text;
        facade.AddItem(itemInfo);
    }

    private void UpdateItem(string id, string url)
    {
        Guid iid = new Guid(id);
        ItemDetailFacade facade = new ItemDetailFacade();
        ItemDetailInfo itemInfo = facade.GetItemById(iid) as ItemDetailInfo;
        if (itemInfo != null)
        {
            itemInfo.Name = txtName.Text;
            itemInfo.TitleHtml = txtTitle.Text;
            itemInfo.AllHtml = txtContent.Text;
            itemInfo.SummaryHtml = txtSummary.Text;
            facade.UpdateItem(itemInfo);
        }
        else
        {
            JavascriptAlertAndRedirect("参数错误 - 对象不存在！", url);
        }
    }
}
