<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/UserAlipayReg.aspx.cs" inherits="Home_Room_UserAlipayReg" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .style1
        {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
            <tr>
                <td valign="top" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/bg_blue_30.jpg">
                        <tr>
                            <td height="30">
                                <table width="738" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="40" height="30" align="center">
                                            <img src="images/jiantou_5.gif" width="12" height="8" />
                                        </td>
                                        <td class="blue_num">
                                            我的资料 &gt; 绑定支付宝帐户
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table cellspacing="0" cellpadding="3" width="100%" align="center" border="0" id="Table3"
                        runat="server">
                        <tr>
                            <td valign="middle" align="right" height="28">
                                请输入您想申请的支付宝帐户：
                            </td>
                            <td align="left">
                                <font face="Tahoma">
                                    <asp:TextBox ID="tb_2_AlipayName" runat="server" Width="200px" MaxLength="25"></asp:TextBox>
                                </font>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left" class="style1">
                                （由支付宝提供 API 注册接口）
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" align="center" colspan="2" style="padding: 15px;">
                                <ShoveWebUI:ShoveConfirmButton ID="btn_AppAliapy" runat="server" Text=" 下一步 " OnClick="btn_AppAliapy_OK_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
