<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlSubMenu.ascx.cs" Inherits="Controls_CtrlSubMenu" %>

<script type="text/javascript">

    var selectedMenuLinkId = null;
    function SelectMenu(lId) {
        if (selectedMenuLinkId != null) {
            document.getElementById(selectedMenuLinkId).parentNode.className = "";
        }
        document.getElementById(lId).parentNode.className = "Selected";
        selectedMenuLinkId = lId;
    }

</script>

<asp:Repeater ID="rptTopMenu" runat="server" OnItemDataBound="rptTopMenu_ItemDataBound">
    <ItemTemplate>
        <div id='<%# Eval("Id", "MenuContainer_{0}") %>' style="display: none;">
            <ul>
                <asp:Repeater ID="rptMenuList" runat="server" OnItemDataBound="rptMenuList_ItemDataBound">
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="hlnkUrl" Target="iframe_sub" runat="server"></asp:HyperLink></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </ItemTemplate>
</asp:Repeater>