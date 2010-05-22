<%@ page language="C#" autoeventwireup="true" CodeFile="ImageNewsAdd.aspx.cs" inherits="Admin_ImageNewsAdd" validaterequest="false" enableEventValidation="false" %>

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
        <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0" style="line-height: 2;">
          
            <tr>
                <td>
                    标题
                    <asp:TextBox ID="tbTitle" runat="server" Width="668px" MaxLength="50"></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="cbIsBig" runat="server"  Checked="true"/>是否大图片新闻
                </td>
               </tr>
            <tr>
                    <td>
                        <font face="宋体">链接地址
                            </font><asp:TextBox ID="tbContent" runat="server" Width="520px"></asp:TextBox></td>
                </tr>
            <tr>
                <td>
                    <font face="宋体">使用一个新的图片
                        <input id="tbImage" style="width: 600px; height: 21px" type="file" size="80" name="tbImage"
                            runat="server"><br />
                        <font color="#ff0000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            (如果选择了新图片，下面“已存在的图片”选择将无效)</font></font>
                </td>
            </tr>
            <tr>
                <td>
                    <font face="宋体">使用已存在的图片
                        <asp:DropDownList ID="ddlImage" runat="server" Width="250px">
                        </asp:DropDownList>
                    </font>
                </td>
            </tr>
            <tr>
                <td style="height: 50px" align="center">
                    <ShoveWebUI:ShoveConfirmButton ID="btnAdd" runat="server" Width="60px" Height="20px"
                        BackgroupImage="../Images/Admin/buttbg.gif" Text="增加" AlertText="确信输入无误，并立即增加此图片新闻吗？"
                        OnClick="btnAdd_Click" />
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
