<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestInformationBox.aspx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.TestPages.ControlTest.TestInformationBox" %>

<%@ Register Src="../../WebControls/Common/CtrlInformationBox.ascx" TagName="CtrlInformationBox"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="InformationBox.Test.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnOneMessage" runat="server" Text="只有一条信息" OnClick="btnOneMessage_Click" />
        <asp:Button ID="btnMultiMessageNoSperator" runat="server" Text="简单的多条信息" OnClick="btnMultiMessageNoSperator_Click" />
        <asp:Button ID="btnMultiMessageCustomerSperator" runat="server" Text="自定义多条信息" OnClick="btnMultiMessageCustomerSperator_Click" />
    </div>
    <div id="divInformationBox" runat="server">
        <uc1:CtrlInformationBox ID="ucInformationBox" runat="server" />
    </div>
    </form>
</body>
</html>
