<%@ page language="C#" autoeventwireup="true" CodeFile="Scheme.aspx.cs" inherits="Agent_ElectronTicket_Scheme" enableEventValidation="false" %>

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
        <table width="50%" align="center" border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
            <tr>
                <td>
                    <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1" style="border-collapse: collapse;
                        background-color: #E0E0E0; height: 170px;">
                        <tr style="background-color: Silver;">
                            <td align="center" colspan="2">
                                查看投注明细数据
                            </td>
                        </tr>
                        <tr>
                            <td width="100" align="right" bgcolor="#f5f5f5">
                                方案编号:
                            </td>
                            <td bgcolor="#ffffff">
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbSchemeNumber" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" align="right" bgcolor="#f5f5f5">
                                投注时间:
                            </td>
                            <td bgcolor="#ffffff">
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbDateTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" align="right" bgcolor="#f5f5f5">
                                投注金额:
                            </td>
                            <td bgcolor="#ffffff">
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbAmount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" align="right" bgcolor="#f5f5f5">
                                投注倍数:
                            </td>
                            <td bgcolor="#ffffff">
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbMultiple" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" align="right" bgcolor="#f5f5f5">
                                投注状态:
                            </td>
                            <td bgcolor="#ffffff">
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbState" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Repeater ID="RpElectronTicket" runat="server">
                        <HeaderTemplate>
                            <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1" style="border-collapse: collapse;
                                background-color: #E0E0E0;">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td width="100" height="20" bgcolor="#f5f5f5" align="right" style="padding-right:5px;">
                                    投注号码 <%#Eval("count")%>
                                </td>
                                <td bgcolor="#ffffff" style="padding-left:5px; width:310px;">
                                     <%# Eval("Ticket")%>
                                </td>
                                <td bgcolor="#ffffff" style="padding-left:5px; padding-right:5px; width:20px;">
                                     <%# Eval("identifiers")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
