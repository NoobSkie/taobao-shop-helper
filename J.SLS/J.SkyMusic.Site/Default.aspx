<%@ Page Title="" Language="C#" MasterPageFile="~/MenuMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" EnableViewState="false" %>

<%@ Register Src="Controls/CtrlSubMenu.ascx" TagName="CtrlSubMenu" TagPrefix="uc4" %>
<%@ Register Src="Controls/CtrlBackground.ascx" TagName="CtrlBackground" TagPrefix="uc5" %>
<%@ Register Src="Controls/CtrlNoticeBox.ascx" TagName="CtrlNoticeBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <uc1:CtrlNoticeBox ID="CtrlNoticeBox1" runat="server" />
    <uc5:CtrlBackground ID="CtrlBackground1" IsShowMusicPlayer="true" runat="server" />
    <div id="divSubMenu" class="Menu2">
        <uc4:CtrlSubMenu ID="ctrlSubMenu4" runat="server" />
    </div>
    <div class="SplitLeft" style="height: 600px;">
    </div>
    <div class="Content">
        <iframe id="iframe_sub" name="iframe_sub" width="600px" frameborder="0" scrolling="no"
            onload="SetIframeHeight();"></iframe>
    </div>
</asp:Content>
