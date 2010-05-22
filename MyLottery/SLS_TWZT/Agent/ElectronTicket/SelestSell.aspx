<%@ page language="C#" autoeventwireup="true" CodeFile="SelestSell.aspx.cs" inherits="Agent_ElectronTicket_SelestSell" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../../Style/Surrogate.css" type="text/css" rel="stylesheet" />
</head><link rel="shortcut icon" href="../favicon.ico" />
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table width="50%" align="center" border="0" cellpadding="1" cellspacing="1" style="border-collapse: collapse;
             background-color:#E0E0E0; height: 170px;">
            <tr style="background-color:Silver;">
                <td align="center" colspan="2">
                    代理商查询销售额度信息
                </td>
            </tr>
            <tr>
                <td width="100" align="right" bgcolor="#f5f5f5">
                    代理商编号:
                </td>
                <td bgcolor="#ffffff">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbElectronTicketID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="100" align="right" bgcolor="#f5f5f5">
                    代理商名称:
                </td>
                <td bgcolor="#ffffff">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="100" align="right" bgcolor="#f5f5f5">
                    接入状态:
                </td>
                <td bgcolor="#ffffff">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbState" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="100" align="right" bgcolor="#f5f5f5">
                    可用额度:
                </td>
                <td bgcolor="#ffffff">
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbBalance" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
