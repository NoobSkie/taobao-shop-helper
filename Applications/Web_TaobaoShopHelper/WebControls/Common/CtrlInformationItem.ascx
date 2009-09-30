<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInformationItem.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Common.CtrlInformationItem" %>
<li class="<%= CssName %>">
    <asp:Label ID="lblMessage" runat="server" Text="<%# Message %>"></asp:Label>
    <asp:Repeater ID="rptLinkList" runat="server" DataSource="<%# LinkList %>">
        <ItemTemplate>
            <asp:HyperLink ID="lnk" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'
                NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Url") %>'></asp:HyperLink>
        </ItemTemplate>
    </asp:Repeater>
</li>
