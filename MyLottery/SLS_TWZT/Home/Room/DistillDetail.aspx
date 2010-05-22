<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/DistillDetail.aspx.cs" inherits="Home_Room_DistillDetail" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
        function Show() {
            parent.document.getElementById("tb_remind").style.display = "none";
            parent.document.getElementById("tb_times").style.display = "none";
            parent.document.getElementById("td_Tips").style.display = "none";
            parent.document.getElementById("tb_mains").style.backgroundColor = "#FFFFFF";
        }
    
    </script>
</head>
<body onload="Show();">
    <form id="form1" runat="server">
    <asp:DataGrid ID="gUserDistills" runat="server" Width="840" BorderStyle="None" AllowSorting="True"
        AllowPaging="True" PageSize="8" AutoGenerateColumns="False" CellPadding="0" BackColor="#DDDDDD"
        Font-Names="Tahoma" OnItemDataBound="gUserDistills_ItemDataBound" CellSpacing="1"
        GridLines="None" OnItemCommand="gUserDistills_ItemCommand">
        <SelectedItemStyle Font-Bold="True" ForeColor="#663399"></SelectedItemStyle>
        <HeaderStyle HorizontalAlign="Center" BackColor="#E9F1F8" ForeColor="#0066BA" Height="30px"
            CssClass="blue12_2"></HeaderStyle>
        <AlternatingItemStyle BackColor="#F8F8F8" />
        <ItemStyle BackColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center"
            CssClass="black12" />
        <Columns>
            <asp:TemplateColumn HeaderText="订单号">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDistillDetail" runat="server" CommandName="ShowDistillDetail"
                        ForeColor="#0066BA" Font-Underline="True"><%#Eval("ID").ToString()%></asp:LinkButton>
                    <asp:HiddenField ID="tdDistillID" runat="server" Value='<%#Eval("ID") %>' />
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="Money" HeaderText="支出(元)">
                <ItemStyle Width="10%" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="FormalitiesFees" HeaderText="(手续费)">
                <ItemStyle Width="10%" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="交易类型">
                <ItemStyle Width="10%" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Result" HeaderText="状态">
                <ItemStyle Width="10%" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="操作">
                <ItemStyle Width="10%" />
                <ItemTemplate>
                    <asp:LinkButton ID="btnModified" runat="server" ForeColor="#0066BA" Font-Underline="True"
                        CommandName="QuashDistills" Visible='<%# Eval("Result").ToString() == "0" ? true : false %>'>撤销提款</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="Memo" HeaderText="备注">
                <ItemStyle Width="25%" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="DateTime" HeaderText="交易时间">
                <ItemStyle Width="15%" />
            </asp:BoundColumn>
        </Columns>
        <PagerStyle Visible="False" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
        </PagerStyle>
    </asp:DataGrid>
    <ShoveWebUI:ShoveGridPager ID="gPagergDistills" runat="server" Width="840" PageSize="8"
        ShowSelectColumn="False" DataGrid="gUserDistills" AlternatingRowColor="#F8F8F8"
        GridColor="#E0E0E0" HotColor="MistyRose" OnPageWillChange="gPager_PageWillChange"
        AllowShorting="true" RowCursorStyle="" />
    <table width="840" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
        <tbody id="isShowDistill" runat="server">
            <tr>
                <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    提款类型： <span class="red12">
                        <asp:Label ID="lblDistillBankType" runat="server" Text=""></asp:Label>
                    </span>
                </td>
                <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    提款时间： <span class="red12">
                        <asp:Label ID="lblDistillTime" runat="server" Text=""></asp:Label>
                    </span>
                </td>
            <tr>
                <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    <asp:Label ID="lblDistillBanks" runat="server" Text=""></asp:Label>
                    <span class="red12">
                        <asp:Label ID="lblDistillBankDetail" runat="server" Text=""></asp:Label>
                    </span>
                </td>
                <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;">
                    <div id="divBankInfo" runat="server"  Visible="false" style="float:left">
                        <asp:Label ID="lbAccountBankDetail" runat="server" Text="开户银行："></asp:Label>
                        <asp:Label ID="lbBankInProvince" runat="server" CssClass="red12" Text="XXX省" ></asp:Label>&nbsp;
                        <asp:Label ID="lbBankInCity" runat="server" CssClass="red12" Text="XXX市" ></asp:Label>&nbsp;
                        <asp:Label ID="lbBankTypeName" runat="server" CssClass="red12" Text="XXX银行" ></asp:Label>&nbsp;
                        <asp:Label ID="lbAccountBank" runat="server" CssClass="red12"  Text="XXX支行" ></asp:Label>
                    </div>
                </td>
            </tr>
        </tbody>
        <tr>
            <td width="385" bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;"
                colspan="2">
                提款交易笔数： <span class="red12">
                    <asp:Label ID="lblDistillCount" runat="server" Text=""></asp:Label>
                </span>
            </td>
        </tr>
        <tr>
            <td bgcolor="#F8F8F8" class="black12" style="padding: 5px 10px 5px 10px;" colspan="2">
                提款金额合计： <span class="red12">
                    <asp:Label ID="lblDistillMoney" runat="server" Text=""></asp:Label>
                </span>
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFFEDF" class="black12" style="padding: 5px 10px 5px 10px;" colspan="2">
                <span class="blue12">说明：</span><br />
                1、您可以查询您的帐户在一段时间内的所有交易流水。<br />
                2、如果你已经充值，银行账户钱扣了，而您的账户还没有加上，请点击<span class="blue12_2">在线客服</span>告诉我们，我们将第一时间为您处理！<br />
                3、如有其他问题，请联系网站客服：<%= _Site.ServiceTelephone %>。
            </td>
        </tr>
    </table>
    </form>
        <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
