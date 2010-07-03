<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlMenu.ascx.cs" Inherits="Controls_CtrlMenu" %>

<script type="text/javascript">

    var selectedTopMenuId = null;
    function ShowSubMenu(topId) {
        var divId = "MenuContainer_" + topId;
        if (selectedTopMenuId != null) {
            if (selectedTopMenuId == divId) {
                return;
            }
            document.getElementById(selectedTopMenuId).style.display = "none";
        }
        document.getElementById(divId).style.display = "";
        selectedTopMenuId = divId;

        SelectFirstSubMenu(divId);
    }

    function SelectFirstSubMenu(containerId) {
        var container = document.getElementById(containerId);
        if (container.childNodes[0].childNodes.length > 0) {
            container.childNodes[0].childNodes[0].childNodes[0].click();
        }
        else {
            document.getElementById('iframe_sub').src = "";
        }
    }

</script>

<ul>
    <asp:Repeater ID="rptMenuList" runat="server" 
        onitemdatabound="rptMenuList_ItemDataBound">
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="hlnkMenu" runat="server"></asp:HyperLink></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
