<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" EnableEventValidation="false"
    Inherits="TOP.Applications.TaobaoShopHelper.Templates.WebForm2" %>

<%@ Register Src="../WebControls/Template/CtrlBlock_Container.ascx" TagName="CtrlBlock_Container"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnPreview" runat="server" Text="预览" OnClick="btnPreview_Click" />
        <asp:HyperLink ID="hlnkReset" NavigateUrl="~/Templates/WebForm2.aspx" runat="server">重新开始</asp:HyperLink><br />
        <asp:Label ID="lblPreview" runat="server"></asp:Label>
    </div>
    <div class="TemplateContainer">
        <asp:Repeater ID="rptBlocks" runat="server">
            <ItemTemplate>
                <uc1:CtrlBlock_Container ID="ucCtrlBlockContainer" TemplateInfo="<%# Container.DataItem %>"
                    runat="server" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
