<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="Controls/CtrlBlock.ascx" TagName="CtrlBlock" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ph_head" runat="Server">
    <link href="Styles/MainLayout.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ph_content" runat="Server">
    <div class="LeftArea">
        <asp:Repeater ID="rptLeftBlocks" runat="server">
            <ItemTemplate>
                <uc1:CtrlBlock ID="ctrlBlockLeft" BlockInfo="<%# Container.DataItem %>" runat="server" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="MiddleArea">
        <asp:Repeater ID="rptMiddleBlocks" runat="server">
            <ItemTemplate>
                <uc1:CtrlBlock ID="ctrlBlockMiddle" BlockInfo="<%# Container.DataItem %>" runat="server" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="RightArea">
        <asp:Repeater ID="rptRightBlocks" runat="server">
            <ItemTemplate>
                <uc1:CtrlBlock ID="ctrlBlockRight" BlockInfo="<%# Container.DataItem %>" runat="server" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
