<%@ page language="C#" autoeventwireup="true" CodeFile="FriendLink.aspx.cs" inherits="BottomNavigationPages_FriendLink" enableeventvalidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>友情链接－<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %>!</title>
    <meta name="keywords" content="<%=_Site.Name %>" />
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站。" />
    <link href="../Home/Room/Style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #box
        {
            padding: 0px;
            overflow: hidden;
            width: 1002px;
            margin-right: auto;
            margin-left: auto;
        }
    </style>
    <link rel="shortcut icon" href="../favicon.ico" />
</head>

<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <div id="box">
        <table>
            <tr>
                <td width="8" rowspan="2">
                </td>
            </tr>
            <tr>
                <td height="3" colspan="2" bgcolor="#F0F0F0">
                    
                </td>
            </tr>
        </table>
        <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="15" height="27">
                                &nbsp;
                            </td>
                            <td width="80" align="center" bgcolor="#6699CC">
                                <h1 class="bai14" style="display:inline"> <a href="FriendLink.aspx">友情链接</a></h1>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td width="202" align="right" class="blue12" style="padding-right: 10px;">
                                免费咨询电话：<span class="red14"><%= _Site.ServiceTelephone %></span>
                            </td>
                            <td width="77">
                                <a href="javascript:;"">
                                    <img src="../Home/Room/Images/head_zixun.jpg" width="77" height="20" border="0" /></a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="2" bgcolor="#6699CC">
                </td>
            </tr>
            <tr>
                <td>
                    <table width="980" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <%--<tr>
                                        <td height="36" class="red14">
                                            合作商家列表
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="6" bgcolor="#DDDDDD">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <asp:DataList ID="dlFriendLinks" RepeatColumns="4" runat="server">
                                                <ItemTemplate>
                                                    <table width="220" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td height="65" align="center" bgcolor="#FFFFFF">
                                                                    <a href="#">
                                                                        <img src='<%=ResolveUrl("~/Private/1/FriendshipLinks/") %><%# Eval("LogoUrl")%>' width="172" height="47" border="0" /></a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="25" align="center" bgcolor="#F7F7F7" class="blue12">
                                                                    <a href='<%# Eval("Url")%>' target="_blank"><%# Eval("LinkName")%></a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                </ItemTemplate>
                                                <ItemStyle Width="260px" Height="19px" />
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DataList ID="dlFrindLinksNoImg" RepeatColumns="5" runat="server">
                                                <ItemTemplate>
                                                    <table width="176" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                                            <tr>
                                                                <td height="25" align="center" bgcolor="#F7F7F7" class="blue12">
                                                                    <a href='<%# Eval("Url")%>' target="_blank"><%# Eval("LinkName")%></a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                </ItemTemplate>
                                                <ItemStyle Width="260px" Height="19px" />
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
