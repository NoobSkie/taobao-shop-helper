<%@ page language="C#" autoeventwireup="true" CodeFile="SelectDefaultFirstPage.aspx.cs" inherits="Admin_SelectDefaultFirstPage" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/Admin.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table width="707" height="34" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#85BDE2">
                <tr>
                    <td height="32" bgcolor="#B0D5EC" class="STYLE14">
                        <div align="left" class="STYLE4">
                            <div align="center">
                                选择默认的站点首页</div>
                        </div>
                    </td>
                </tr>
            </table>
            <table width="707" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#85BDE2" style="color: #000000; height: 160px;">
                <tr>
                    <td colspan="2" bgcolor="#FFFFFF" style="height: 27px;" class="hon">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 站点资料：站点名称：<asp:Label ID="labName" runat="server" ForeColor="Red"></asp:Label>
                        级别：<asp:Label ID="labLevel" runat="server" ForeColor="Red"></asp:Label>
                        状态：<asp:Image ID="imgON" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td height="25" bgcolor="#FFFFFF" style="width: 144px">
                        <div align="right">
                            默认首页选择：</div>
                    </td>
                    <td bgcolor="#FFFFFF">
                        <asp:RadioButton ID="rb1" runat="server" Text="公司网站" GroupName="DefaultFirstPage" />
                        <asp:RadioButton ID="rb2" runat="server" Text="综合版面" GroupName="DefaultFirstPage" />
                        <asp:RadioButton ID="rb3" runat="server" Text="足彩版面" GroupName="DefaultFirstPage" />
                        <asp:RadioButton ID="rb4" runat="server" Text="单场专版" GroupName="DefaultFirstPage" />
                        <asp:RadioButton ID="rb5" runat="server" Text="重庆时时彩" GroupName="DefaultFirstPage" />
                        <asp:RadioButton ID="rb6" runat="server" Text="上海时时乐" GroupName="DefaultFirstPage" />
                        <asp:RadioButton ID="rb7" runat="server" Text="快乐扑克" GroupName="DefaultFirstPage" /></td>
                </tr>
                <tr>
                    <td colspan="2" bgcolor="#FFFFFF" align="center" style="height: 40px">
                        &nbsp;<ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server" AlertText="确信输入的资料无误，并立即保存资料吗？" BackgroupImage="../Images/Admin/buttbg.gif" BorderStyle="None" Height="20px" Text="修改" Width="60px" OnClick="btnOK_Click" /></td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
