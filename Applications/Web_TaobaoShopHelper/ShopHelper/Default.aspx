<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMainMenu.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HolderContent" runat="server">
    <div class="MenuDivLevelTwo">
        <table border="0" cellpadding="0" cellspacing="0" style="padding-top: 3px; padding-left: 5px;">
            <tr>
                <td>
                    <a href="ItemQuery.aspx" target="ShopHelperFrame" class="OnmouseTwo">导入宝贝</a>
                </td>
            </tr>
        </table>
    </div>
    <u class="Corner_Bottom_Two"><u class="H4"></u><u class="H3"></u><u class="H2"></u><u
        class="H1"></u></u>
    <div>
        <iframe class="SubPageFrame" name="ShopHelperFrame"></iframe>
    </div>
</asp:Content>
