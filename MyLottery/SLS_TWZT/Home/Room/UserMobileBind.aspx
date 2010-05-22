<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/UserMobileBind.aspx.cs" inherits="Home_Room_UserMobileBind" enableEventValidation="false" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register src="UserControls/UserMyIcaile.ascx" tagname="UserMyIcaile" tagprefix="uc2" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>手机绑定-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <meta name="keywords" content="手机绑定" />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <link href="Style/div.css" rel="stylesheet" type="text/css" />
<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
     <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
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
                                            我的资料 &gt; 绑定手机号码
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="5">
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#9FC8EA">
                                    <tr>
                                        <td height="30" colspan="2" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 15px;">
                                            资料修改：您的用户名是：<span class="red12"><asp:Label ID="labName" runat="server"></asp:Label></span>
                                            类型：<span class="red12"><asp:Label ID="labUserType" runat="server"></asp:Label></span>
                                            等级：<asp:Label ID="labLevel" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="18%" height="30" align="right" bgcolor="f7f7f7" class="black12">
                                            真实姓名：
                                        </td>
                                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 15px;">
                                            <asp:Label ID="tbRealityName" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="right" bgcolor="f7f7f7" class="black12">
                                            手机号码：
                                        </td>
                                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 15px;">
                                            <asp:Label ID="tbMobile" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="right" bgcolor="f7f7f7" class="black12">
                                            状态：
                                        </td>
                                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 15px;">
                                            <asp:Label ID="labIsMobileVailded" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td height="30" align="right" bgcolor="f7f7f7" class="black12">
                                            申请绑定：
                                        </td>
                                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 15px;">
                                            <asp:Button ID="btnBind" runat="server" Text="申请绑定" OnClick="btnBind_Click" />
                                            &nbsp;<asp:Button ID="btnReBind" runat="server" Text="重新绑定" OnClick="btnBind_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <div style="height: 20px;">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
      </div> 
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
