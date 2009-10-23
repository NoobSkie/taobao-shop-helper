<%@ Page Title="" Language="C#" MasterPageFile="~/SearchWin/SearchWinBase.Master"
    AutoEventWireup="true" CodeBehind="Input_Text.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.SearchWin.Input_Text" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageHead" runat="server">

    <script type="text/javascript">

        function ReturnSearchWin_InForm() {
            var text = document.getElementById("<%= txtTextList.ClientID %>").value;
            if (text != null && text != "") {
                AddItem(text);
            }
            ReturnSearchWin();
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderHolder" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="请输入新增项内容"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentHolder" runat="server">
    <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <asp:TextBox ID="txtTextList" runat="server" TextMode="MultiLine"></asp:TextBox>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterHolder" runat="server">
    <asp:HyperLink ID="hlnkOk" NavigateUrl="javascript:ReturnSearchWin_InForm();" runat="server">确定</asp:HyperLink>
    <asp:HyperLink ID="hlnkCancel" NavigateUrl="javascript:CloseSearchWin();" runat="server">取消</asp:HyperLink>
</asp:Content>
