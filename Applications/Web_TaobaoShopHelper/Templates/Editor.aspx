<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editor.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.Templates.Editor" %>

<%@ Register Src="~/WebControls/Template/CtrlTemplateEditor.ascx" TagName="CtrlTemplateEditor"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Button ID="btnPreview" runat="server" Text="预览" OnClick="btnPreview_Click" />
            <asp:HyperLink ID="hlnkReset" NavigateUrl="~/Templates/WebForm2.aspx" runat="server">重新开始</asp:HyperLink><br />
            <asp:Label ID="lblPreview" runat="server"></asp:Label>
        </div>
        <div class="TemplateContainer">
            <uc2:CtrlTemplateEditor ID="ucTemplateEditor" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
