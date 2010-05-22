<%@ page language="C#" autoeventwireup="true" CodeFile="IsuseAddForKeno.aspx.cs" inherits="Admin_IsuseAddForKeno" enableEventValidation="false" %>

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
            <br />
            <table id="Table1" cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                <tr>
                    <td align="center">
                        <div style="width: 645px; position: relative; height: 104px; left: 0px; top: 0px;">
                            <asp:Label ID="Label2" Style="z-index: 103; left: 24px; position: absolute; top: 40px" runat="server">增加天数</asp:Label>
                            <asp:Label ID="Label1" Style="z-index: 102; left: 24px; position: absolute; top: 8px" runat="server">开始日期</asp:Label>
                            <asp:TextBox ID="tbDate" Style="z-index: 100; left: 88px; position: absolute; top: 8px" runat="server" Width="128px" MaxLength="10"></asp:TextBox>
                            <asp:TextBox ID="tbDays" Style="z-index: 105; left: 88px; position: absolute; top: 40px" runat="server" Width="128px" MaxLength="19">10</asp:TextBox>
                            <ShoveWebUI:ShoveConfirmButton id="btnAdd" style="z-index: 107; left: 254px; position: absolute; top: 39px;" BackgroupImage="../Images/Admin/buttbg.gif" runat="server" Width="60px" Height="20px" AlertText="确认书写无误并增加一期吗？" Text="增加" OnClick="btnAdd_Click" />
                            <asp:TextBox ID="tbLotteryID" Style="z-index: 108; left: 520px; position: absolute; top: 8px" runat="server" Visible="False" Width="48px"></asp:TextBox>
                            <asp:LinkButton ID="btnBack" Style="z-index: 109; left: 576px; position: absolute; top: 8px" runat="server" OnClick="btnBack_Click">【返回】</asp:LinkButton>
                            <asp:Label ID="Label3" Style="z-index: 105; left: 88px; position: absolute; top: 68px" runat="server" Text="高频性彩票，您只需要选择增加的天数，系统会自动在指定的天数内，增加每天的所有期号"></asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
