<%@ page language="C#" autoeventwireup="true" CodeFile="CardPasswordAdd.aspx.cs" inherits="Admin_CardPasswordAdd" enableEventValidation="false" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
                            &nbsp;
                            <asp:Label ID="Label4" runat="server" 
                                Style="z-index: 103; left: 45px; position: absolute; top: 94px">选择代理商</asp:Label>
                            <asp:TextBox ID="tbMoney" Style="z-index: 102; left: 149px; position: absolute; top: 123px" runat="server" BorderStyle="Solid" Width="168px" BorderWidth="1px"></asp:TextBox>
                            <asp:TextBox ID="tbCount" 
                                Style="z-index: 102; left: 149px; position: absolute; top: 171px" 
                                runat="server" BorderStyle="Solid" Width="168px" BorderWidth="1px"></asp:TextBox>
                            <asp:Label ID="Label2" 
                                Style="z-index: 104; left: 44px; position: absolute; top: 123px" runat="server">卡密金额</asp:Label>
                            <asp:Label ID="Label15" Style="z-index: 105; left: 16px; position: absolute; top: 32px" runat="server" Width="160px" ForeColor="#336699" Font-Size="12pt" Height="8px" Font-Names="黑体">为代理商增加卡密</asp:Label>
                            <asp:Label ID="Label3" 
                                Style="z-index: 104; left: 45px; position: absolute; top: 174px" 
                                runat="server">生成卡密总数</asp:Label>
                            &nbsp;
                            <asp:DropDownList ID="ddlCardPasswordAgents" runat="server" Style="z-index: 103; left: 149px; position: absolute; top: 94px" Width="172px">
                            </asp:DropDownList>
                            &nbsp;
                            <ShoveWebUI:ShoveConfirmButton id="btnGO" style="z-index: 107; left: 192px; position: absolute; top: 208px; width: 120px" runat="server" text="立即生成" alerttext="确定输入正确并立即生成吗？" onclick="btnGO_Click"></ShoveWebUI:ShoveConfirmButton>
                            <asp:Label ID="Label16" 
                                Style="z-index: 104; left: 42px; position: absolute; top: 147px" 
                                runat="server">卡密有效月份</asp:Label>
                            <asp:TextBox ID="tbDateTime" 
                                Style="z-index: 102; left: 149px; position: absolute; top: 147px" 
                                runat="server" BorderStyle="Solid" Width="168px" BorderWidth="1px"></asp:TextBox>
                            </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
