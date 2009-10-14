<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSearchItems_Multi.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Search.CtrlSearchItems_Multi" %>
<%@ Register Src="CtrlItem_Check.ascx" TagName="CtrlItem_Check" TagPrefix="uc1" %>

<script src="<%= GetRootUrl() %>/Scripts/Item.js" type="text/javascript"></script>

<script type="text/javascript">
    function SelectItem(ctrlObj, type, iid, title, imgUrl, price) {
        if (ctrlObj.checked) {
            var item = new Item();
            item.Id = iid;
            item.Title = title;
            item.ImageUrl = imgUrl;
            item.Price = price;

            AddItem(item);
        }
        else {
            RemoveItem(iid);
        }
    }
    
    function AddItem(item) {
        // Interface funcion
    }

    function RemoveItem(itemId) {
        // Interface funcion
    }
</script>

<div class="ItemList CheckItemList">
    <asp:Repeater ID="rptItems" runat="server">
        <ItemTemplate>
            <uc1:CtrlItem_Check ID="ucCtrlItemCheck" DisplayType="<%# DisplayType %>" Item="<%# Container.DataItem %>"
                runat="server" />
        </ItemTemplate>
    </asp:Repeater>
</div>
