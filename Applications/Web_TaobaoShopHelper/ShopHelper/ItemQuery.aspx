<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ShopHelper/NestedShopHelperPage.master"
    CodeBehind="ItemQuery.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.ItemQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">

    <script type="text/javascript">

        var queryType = "item";
        function Query() {
            location = "QueryResult.aspx?q=" + key + "&t=" + queryType;
        }

        var currentCategory;
        function ChangeType(type, obj) {
            document.getElementById("hiddenSearchType").value = type;
            if (currentCategory) {
                currentCategory.parentNode.className = "";
            }
            obj.parentNode.className = "Selected";
            currentCategory = obj;
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
    <form id="formSearch" action="QueryResult.aspx" method="get">
    <div class="SearchDiv">
        <input type="hidden" id="hiddenSearchType" name="t" value="item" />
        <ul class="SearchCategory">
            <li>
                <asp:HyperLink ID="hlnkType_Item" NavigateUrl="javascript:void(0);" onclick="ChangeType('item', this);"
                    runat="server">宝贝</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="hlnkType_Shop" NavigateUrl="javascript:void(0);" onclick="ChangeType('shop', this);"
                    runat="server">店铺</asp:HyperLink></li>
        </ul>
        <div class="SearchForm">
            <span class="Key">
                <input type="text" name="q" /></span>
            <input type="submit" class="Do" value="搜索" />
        </div>
    </div>
    </form>

    <script type="text/javascript">
        ChangeType("item", document.getElementById("<%= hlnkType_Item.ClientID %>"));
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HolderContent" runat="server">
</asp:Content>
