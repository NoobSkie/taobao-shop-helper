<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBlock_Display.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Template.CtrlBlock_Display" %>
<%@ Register Src="CtrlDisplayItem_Image.ascx" TagName="CtrlDisplayItem_Image" TagPrefix="uc1" %>
<%@ Register Src="CtrlDisplayItem_Text.ascx" TagName="CtrlDisplayItem_Text" TagPrefix="uc2" %>
<uc1:CtrlDisplayItem_Image ID="ucCtrlDisplayItemImage" runat="server" />
<uc2:CtrlDisplayItem_Text ID="ucCtrlDisplayItemText" runat="server" />
