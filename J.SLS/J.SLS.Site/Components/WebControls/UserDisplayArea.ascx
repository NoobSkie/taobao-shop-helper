<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserDisplayArea.ascx.cs"
    Inherits="Components_WebControls_UserDisplayArea" %>
<%@ Register Src="UserLoginCtrl.ascx" TagName="UserLoginCtrl" TagPrefix="uc1" %>
<%@ Register Src="UserInfoCtrl.ascx" TagName="UserInfoCtrl" TagPrefix="uc2" %>
<uc1:UserLoginCtrl ID="UserLoginCtrl1" runat="server" />
<uc2:UserInfoCtrl ID="UserInfoCtrl1" runat="server" Visible="false" />
