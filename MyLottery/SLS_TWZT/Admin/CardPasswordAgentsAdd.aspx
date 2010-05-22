<%@ page language="C#" autoeventwireup="true" CodeFile="CardPasswordAgentsAdd.aspx.cs" inherits="Admin_CardPasswordAgentsAdd" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../Style/Admin.css" type="text/css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 130px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" 
            style="margin-top:100px; width: 425px; margin-right: 135px;">
            <tr>
                <td class="style1">
                    代理商用编号：
                </td>
                <td>
                    <asp:TextBox ID="tbAgentNO" runat="server" Width="300px"></asp:TextBox><br /><span>必填项，4位数字 如：1001，否则该代理商无效。该编号作为代理平台的管理员帐号。代理平台地址：域名/Agent/CardPassword/Default.aspx</span>
                </td>
            </tr>
            <%-- <tr>
                <td class="style1">
                    卡号：
                </td>
                <td>
                    <asp:TextBox ID="tbCardNo" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td class="style1">
                    用户名：
                </td>
                <td>
                    <asp:TextBox ID="tbAgentName" runat="server" Width="300px"></asp:TextBox><br /><span>必填项</span>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    密码：
                </td>
                <td>
                    <asp:TextBox ID="tbAgentPassword" runat="server" Width="300px"></asp:TextBox><br /><span>该密码作为代理平台的管理员帐号密码</span>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    代理商公司名称：
                </td>
                <td>
                    <asp:TextBox ID="tbAgentCompanyName" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    代理商网址：
                </td>
                <td>
                    <asp:TextBox ID="tbAgentSiteName" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style1">
                    金额：
                </td>
                <td>
                    <asp:TextBox ID="tbMoney" runat="server" Width="300px"></asp:TextBox><br /><span>必填项</span>
                </td>
            </tr>
            <%-- <tr>
                <td class="style1">
                    是否启用：
                </td>
                <td>
                    <asp:CheckBox ID="chkIsUse" runat="server" />
                </td>
            </tr>--%>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnOK" runat="server" Text="添加" width="62px" 
                        onclick="btnOK_Click"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
