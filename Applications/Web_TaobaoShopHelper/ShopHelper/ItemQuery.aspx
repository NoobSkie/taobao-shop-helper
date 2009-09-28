<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ShopHelper/NestedShopHelperPage.master"
    CodeBehind="ItemQuery.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.ItemQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">

    <script type="text/javascript">

        var queryType = "item";
        function Query() {
            var key = document.getElementById("<%= txtQuery.ClientID %>").value;
            location = "QueryResult.aspx?q=" + key + "&t=" + queryType;
        }

        var currentCategory;
        function ChangeType(type, obj) {
            queryType = type;
            if (currentCategory) {
                currentCategory.parentNode.className = "";
            }
            obj.parentNode.className = "Selected";
            currentCategory = obj;

            document.getElementById("<%= txtQuery.ClientID %>").focus();
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
    <div class="SearchDiv">
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
                <asp:TextBox ID="txtQuery" runat="server"></asp:TextBox></span>
            <asp:Button ID="btnQuery" class="Do" runat="server" Text="搜索" />
        </div>
    </div>

    <script type="text/javascript">
        ChangeType("item", document.getElementById("<%= hlnkType_Item.ClientID %>"));
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HolderContent" runat="server">
</asp:Content>
