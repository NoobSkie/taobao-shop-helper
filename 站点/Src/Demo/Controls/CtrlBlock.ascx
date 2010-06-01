<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlBlock.ascx.cs" Inherits="Controls_CtrlBlock" %>
<%@ Register Src="CtrlBlock_List.ascx" TagName="CtrlBlock_List" TagPrefix="uc1" %>
<%@ Register Src="CtrlBlock_Html.ascx" TagName="CtrlBlock_Html" TagPrefix="uc2" %>
<div class="PageBlock">
    <div class="BlockTitle">
        <asp:Label ID="lblTitle" runat="server" Text="标题"></asp:Label>
    </div>
    <div class="BlockContent">
        <uc2:CtrlBlock_Html ID="ctrlBlockHtml" runat="server" />
        <uc1:CtrlBlock_List ID="ctrlBlockList" runat="server" Visible="false" />
    </div>
</div>
