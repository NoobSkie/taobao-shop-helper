<%@ page language="C#" autoeventwireup="true" CodeFile="AgentQueryTicket.aspx.cs" inherits="Agent_ElectronTicket_AgentQueryTicket" enableEventValidation="false" %>

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
        <div>
        <table align="center" border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;"
            width="50%">
            <tr>
                <td style="background-color: #f5f5f5;" width="100" align="right">
                    票标识:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td style="width: 50%; background-color: White;">
                    <asp:TextBox ID="tbTicket" runat="server" Width="250px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_ok" runat="server" Text="查询" Width="100px" OnClick="btn_ok_Click" />
                </td>
            </tr>
        </table>
        </div>
        <br />
        <div id="div_Ticket" runat="server" visible= "false">
        <table width="50%" align="center" border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse;">
            <tr>
                <td>
                    <table width="100%" align="center" border="0" cellpadding="1" cellspacing="1" style="border-collapse: collapse;
                        background-color: #E0E0E0; height: 170px;">
                        <tr style="background-color: Silver;">
                            <td align="center" colspan="2">
                                查看票信息
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
                                中奖描述:
                            </td>
                            <td bgcolor="#ffffff">
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbDescription" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100" align="right" bgcolor="#f5f5f5">
                                中奖金额:
                            </td>
                            <td bgcolor="#ffffff">
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lbWinMoney" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
    </div>
    </form>
</body>
</html>
