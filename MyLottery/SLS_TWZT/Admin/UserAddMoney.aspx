<%@ page language="C#" autoeventwireup="true" CodeFile="UserAddMoney.aspx.cs" inherits="Admin_UserAddMoney" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td align="center">
                        <div style="width: 720px; position: relative; height: 329px; left: 0px; top: 0px;">
                            <asp:TextBox ID="tbUserName" Style="z-index: 101; left: 149px; position: absolute; top: 99px" runat="server" BorderStyle="Solid" MaxLength="50" Width="168px" BorderWidth="1px"></asp:TextBox>
                            &nbsp;
                            <asp:Label ID="Label4" runat="server" Style="z-index: 103; left: 69px; position: absolute; top: 74px">选择站点</asp:Label>
                            <asp:TextBox ID="tbMoney" Style="z-index: 102; left: 149px; position: absolute; top: 123px" runat="server" BorderStyle="Solid" Width="168px" BorderWidth="1px"></asp:TextBox>
                            <asp:Label ID="Label1" Style="z-index: 103; left: 69px; position: absolute; top: 99px" runat="server">用户名称</asp:Label>
                            <asp:Label ID="Label2" Style="z-index: 104; left: 69px; position: absolute; top: 123px" runat="server">充值金额</asp:Label>
                            <asp:Label ID="Label5" runat="server" Style="z-index: 104; left: 69px; position: absolute; top: 186px">摘要</asp:Label>
                            <asp:Label ID="Label15" Style="z-index: 105; left: 16px; position: absolute; top: 32px" runat="server" Width="160px" ForeColor="#336699" Font-Size="12pt" Height="8px" Font-Names="黑体">为用户账户手工充值</asp:Label>
                            &nbsp;
                            <asp:Label ID="Label3" Style="z-index: 108; left: 152px; position: absolute; top: 267px" runat="server" ForeColor="Red">提示：如果发生充值错误，可以再次用负数进行充减。</asp:Label>
                            <asp:DropDownList ID="ddlSites" runat="server" Style="z-index: 103; left: 149px; position: absolute; top: 74px" Width="172px">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:RadioButton ID="rb1" runat="server" Style="z-index: 103; left: 149px; position: absolute; top: 151px" Checked="True" GroupName = "rb" Text="正常手工充值"/><asp:RadioButton ID="rb2" runat="server" Style="z-index: 103; left: 254px; position: absolute; top: 151px" Text="奖励" GroupName = "rb"/>
                            <asp:RadioButton ID="rb3" runat="server" Style="z-index: 103; left: 311px; position: absolute; top: 151px" Text="购彩" GroupName = "rb"/>
                            <asp:RadioButton ID="rb4" runat="server" Style="z-index: 103; left: 369px; position: absolute; top: 151px" Text="预付款" GroupName = "rb"/>
                            <asp:RadioButton ID="rb5" runat="server" Style="z-index: 103; left: 439px; position: absolute; top: 151px" Text="转帐户" GroupName = "rb"/>
                            <asp:TextBox ID="tbMessage" runat="server" Style="z-index: 103; left: 149px; position: absolute; top: 185px" Width="540px" Height="16px">摘要：</asp:TextBox>
                            <ShoveWebUI:ShoveConfirmButton id="btnGO" style="z-index: 107; left: 192px; position: absolute; top: 228px; width: 120px" runat="server" text="立即充值" alerttext="确定输入正确并立即充值吗？" onclick="btnGO_Click"></ShoveWebUI:ShoveConfirmButton>
                            </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
