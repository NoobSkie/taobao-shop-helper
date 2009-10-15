<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlBlock_Input.ascx.cs"
    EnableViewState="true" Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Template.CtrlBlock_Input" %>
<%@ Register Src="CtrlInputItem_Text.ascx" TagName="CtrlInputItem_Text" TagPrefix="uc1" %>
<%@ Register Src="CtrlInputItem_ImageUrl.ascx" TagName="CtrlInputItem_ImageUrl" TagPrefix="uc2" %>
<uc1:CtrlInputItem_Text ID="ucCtrlInputItemText" runat="server" />
<uc2:CtrlInputItem_ImageUrl ID="ucCtrlInputItemImageUrl" runat="server" />
