<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSearchButton_Multi.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Search.CtrlSearchButton_Multi" %>

<script src="<%= GetRootURI() %>/Scripts/PageOperate.js" type="text/javascript"></script>

<script src="<%= GetRootURI() %>/Scripts/SearchButtonJS.js" type="text/javascript"></script>

<asp:HyperLink ID="hlnkSearch" runat="server" NavigateUrl="javascript:void(0);" Text="选择"></asp:HyperLink>
<asp:LinkButton ID="lbtnDoPostBack" runat="server" OnClick="lbtnDoPostBack_Click"></asp:LinkButton>