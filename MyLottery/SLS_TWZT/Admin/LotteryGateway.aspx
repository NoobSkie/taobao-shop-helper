<%@ page language="C#" autoeventwireup="true" CodeFile="LotteryGateway.aspx.cs" inherits="Admin_LotteryGateway" enableEventValidation="false" %>

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
    <table border="0" cellpadding="0" cellspacing="0" align="center" style="width: 567px">
                <tr>
                    <td colspan="2" style="height: 30px">
                        <strong>
                        电子票设置</strong></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="g" runat="server" Width="100%" AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1px" CellPadding="0" ForeColor="#333333" GridLines="None">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="彩种" />
                                <asp:TemplateField HeaderText="出票方式">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlElectronTicket" runat="server">
                                            <asp:ListItem Value="0">本地出票</asp:ListItem>
                                            <asp:ListItem Value="101">深圳恒朋-重庆福彩中心</asp:ListItem>
                                            <asp:ListItem Value="10001">自动开奖</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="id" />
                                <asp:BoundField DataField="PrintOutType" />
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 30px">
                        <strong>
                        深圳恒朋-重庆福彩中心代理商参数：</strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        网关地址：
                    </td>
                    <td>
                        <asp:TextBox ID="tb1" runat="server" Width="328px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        代理商编号：
                    </td>
                    <td>
                        <asp:TextBox ID="tb2" runat="server" Width="328px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        代理商密码：
                    </td>
                    <td>
                        <asp:TextBox ID="tb3" runat="server" Width="328px" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        出票不完整时：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNotFull1" runat="server" Width="130px">
                            <asp:ListItem Value="1">撤单</asp:ListItem>
                            <asp:ListItem Value="2">当作已出票</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        是否启用：
                    </td>
                    <td>
                        <asp:CheckBox ID="cb1" runat="server"></asp:CheckBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 25px"></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 30px">
                        <strong>
                        自动开奖参数：</strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户编号：
                    </td>
                    <td>
                        <asp:TextBox ID="tb4" runat="server" Width="328px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        用户密码：
                    </td>
                    <td>
                        <asp:TextBox ID="tb5" runat="server" Width="328px" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 19px">
                        出票不完整时：
                    </td>
                    <td style="height: 19px">
                        <asp:DropDownList ID="ddlNotFull2" runat="server" Width="130px">
                            <asp:ListItem Value="1">撤单</asp:ListItem>
                            <asp:ListItem Value="2">当作已出票</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        是否启用：
                    </td>
                    <td>
                        <asp:CheckBox ID="cb2" runat="server"></asp:CheckBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 40px" align="center">
                        <ShoveWebUI:ShoveConfirmButton ID="btnOK" BackgroupImage="../Images/Admin/buttbg.gif"
                            runat="server" Width="60px" Height="20px" Text="保存" AlertText="确认书写无误吗？" OnClick="btnOK_Click" />
                    </td>
                </tr>
            </table>
            <br />
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
