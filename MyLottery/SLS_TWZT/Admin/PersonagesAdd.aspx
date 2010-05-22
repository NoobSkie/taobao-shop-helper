<%@ page language="C#" autoeventwireup="true" CodeFile="PersonagesAdd.aspx.cs" inherits="Admin_PersonagesAdd" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
            <tr>
                <td style="text-align: left; padding-bottom: 15px; padding-top: 15px;">
                   <asp:DropDownList ID="ddlLotteries" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    顺序
                    <asp:TextBox ID="tbOrder" runat="server" MaxLength="10" Width="100px">1</asp:TextBox>&nbsp;<asp:CheckBox
                        ID="cbisShow" runat="server" Text="是否显示" Checked="True"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td>
                    用户名
                        <asp:TextBox ID="tbName" runat="server" Width="400px" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td style="height: 50px" align="center">
                    <ShoveWebUI:ShoveConfirmButton ID="btnAdd" runat="server" Width="60px" Height="20px"
                        BackgroupImage="../Images/Admin/buttbg.gif" Text="保存" OnClick="btnAdd_Click" />
                    <span style="margin-left: 100px;"></span>
                    <ShoveWebUI:ShoveConfirmButton ID="btnCancel" runat="server" Width="60px" Height="20px"
                        BackgroupImage="../Images/Admin/buttbg.gif" Text="取消" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>	
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
