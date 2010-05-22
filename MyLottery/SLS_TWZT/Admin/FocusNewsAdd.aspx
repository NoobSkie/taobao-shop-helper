<%@ page language="C#" autoeventwireup="true" CodeFile="FocusNewsAdd.aspx.cs" inherits="Admin_FocusNewsAdd" validaterequest="false" enableEventValidation="false" %>

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
            <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
                <tr>
                    <td>
                        <font face="宋体">排序
                            <asp:TextBox ID="tbOrder" runat="server" Width="51px" Text="1"></asp:TextBox></font></td>
                </tr>
                <tr>
                    <td>
                        <font face="宋体">标题
                            <asp:TextBox ID="tbTitle" runat="server" Width="520px" MaxLength="100"></asp:TextBox></font></td>
                </tr>
               <tr>
                <td>
                    <asp:CheckBox ID="cbIsMaster" runat="server"  Checked="true"/>是否主标题
                </td>
               </tr>
                <tr>
                    <td>
                        <font face="宋体">链接地址
                            </font><asp:TextBox ID="tbContent" runat="server" Width="520px"></asp:TextBox></td>
                </tr>
               
                <tr>
                    <td style="height: 49px" align="center">
                        <ShoveWebUI:ShoveConfirmButton ID="btnAdd" runat="server" Width="60px" Height="20px" BackgroupImage="../Images/Admin/buttbg.gif" Text="增加" AlertText="确信输入无误，并立即增加此新闻吗？" OnClick="btnAdd_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <asp:HiddenField ID="hID" runat="server" />
    </form>
   
</body>
</html>
