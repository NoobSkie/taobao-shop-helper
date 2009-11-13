<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlPager.ascx.cs" Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Common.CtrlPager" %>
<div class="Pager">
    <asp:HyperLink ID="hlnkPrev" CssClass="Normal PageSignPrev" runat="server">上一页</asp:HyperLink>
    <asp:Repeater ID="rptPageNumber" runat="server">
        <ItemTemplate>
            <asp:HyperLink ID="hlnkPageNumber" runat="server" CssClass='<%# DataBinder.Eval(Container.DataItem, "CssName") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "CurrentUrl") %>'
                Text='<%# DataBinder.Eval(Container.DataItem, "DispalyName") %>'></asp:HyperLink>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HyperLink ID="hlnkNext" CssClass="Normal PageSignNext" runat="server">下一页</asp:HyperLink>
    <asp:Label ID="lblPageCount" CssClass="PageCount" runat="server" Text="共100页"></asp:Label>
    <span>到第</span><asp:TextBox ID="txtPageIndex" CssClass="PageIndex" runat="server"></asp:TextBox><span>页</span>
    <asp:LinkButton ID="lbtnGoPage" runat="server" OnClick="lbtnGoPage_Click">确定</asp:LinkButton>
</div>
