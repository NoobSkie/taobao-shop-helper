<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBlock_Container.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Template.CtrlBlock_Container" %>
<%@ Register Src="CtrlBlock_Item.ascx" TagName="CtrlBlock_Item" TagPrefix="uc1" %>
<%@ Register Src="CtrlBlock_List.ascx" TagName="CtrlBlock_List" TagPrefix="uc2" %>
<uc1:CtrlBlock_Item ID="ucCtrlBlockItem" runat="server" />
<uc2:CtrlBlock_List ID="ucCtrlBlockList" runat="server" />
