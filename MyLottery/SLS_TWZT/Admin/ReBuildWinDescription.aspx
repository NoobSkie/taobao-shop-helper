<%@ page language="C#" autoeventwireup="true" CodeFile="ReBuildWinDescription.aspx.cs" inherits="Admin_ReBuildWinDescription" validaterequest="false" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table id="Table1" cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
                <tr>
                    <td style="height: 30px">
                        <font face="宋体">&nbsp; 请选择
                            <asp:DropDownList ID="ddlLottery" runat="server" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged">
                            </asp:DropDownList>&nbsp;
                            <asp:DropDownList ID="ddlIsuse" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="ddlIsuse_SelectedIndexChanged">
                            </asp:DropDownList></font></td>
                </tr>
                <tr>
                    <td style="height: 30px">
                        <table id="WinNumberOther" runat="server" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tr>
                                <td style="height: 36px">
                                    &nbsp;
                                    <asp:Label ID="Label1" runat="server">开奖号码</asp:Label>
                                    <asp:TextBox ID="tbWinNumber" runat="server" Width="216px" ReadOnly="true"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    请输入各奖级的中奖金额<br />
                                    <asp:GridView ID="g" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="g_RowDataBound" Width="331px" BorderStyle="Solid" BorderWidth="1px" DataKeyNames="DefaultMoney,DefaultMoneyNoWithTax">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="Name" HeaderText="奖级" />
                                            <asp:TemplateField HeaderText="奖金">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="tbMoney" runat="server" Width="80"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="税后奖金">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="tbMoneyNoWithTax" runat="server" Width="80"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 39px" align="center">
                        <ShoveWebUI:ShoveConfirmButton ID="btnGO" runat="server" BackgroupImage="../Images/Admin/buttbg.gif" Width="60px" Height="20px" Text="重构" AlertText="确信输入无误，并立即重构中奖描述吗？" OnClick="btnGO_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
