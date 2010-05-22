<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/UserQQBind.aspx.cs" inherits="Home_Room_UserQQBind" enableEventValidation="false" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>绑定QQ号码-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %></title>
    <meta name="keywords" content="绑定QQ号码" />
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form1" runat="server">
     <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc3:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;
            margin-top: 3px;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
    <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
        <tr>
            <td width="40" height="30" align="right" valign="middle" class="red14">
                <img src="images/user_icon_man.gif" width="19" height="16" />
            </td>
            <td valign="middle" class="red14" style="padding-left: 10px;">
                我的资料
            </td>
        </tr>
    </table>
    <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
        <tr>
            <td width="20" height="29">
                &nbsp;
            </td>
            <td width="100" align="center" background="images/admin_qh_100_1.jpg" class="blue12">
                <a href="UserQQBind.aspx"><strong>绑定QQ号码</strong></a>
            </td>
            <td width="4">
                &nbsp;
            </td>
            <td width="6">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td height="1" colspan="11" bgcolor="#FFFFFF">
            </td>
        </tr>
        <tr>
            <td height="2" colspan="11" bgcolor="#6699CC">
            </td>
        </tr>
    </table>
    <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#DDDDDD">
        <tr>
            <td height="30" align="left" bgcolor="#F3F3F3" class="black12" style="padding: 10px;">
                <p>
                    尊敬的会员<span class="red12">
                        <asp:Label ID="lbName" runat="server"></asp:Label>
                    </span>：
                    <br />
                    <asp:Label ID="lbStatus" runat="server"></asp:Label>QQ号码，请确认。</p>
            </td>
        </tr>
    </table>
    <table width="842" border="0" cellpadding="0" cellspacing="0" bgcolor="#C0DBF9">
        <tr>
            <td width="100%" height="30" align="center" bgcolor="#FFFFFF" class="black12" style="padding: 10px;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                    <tr bgcolor="#C0DBF9">
                        <td width="20%" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                            用户名：<span class="red12"></span>
                        </td>
                        <td width="80%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:Label ID="labName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr bgcolor="#C0DBF9">
                        <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                            已绑定QQ号码：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:Label ID="labQQ" runat="server" Text=""></asp:Label>
                            <asp:Label ID="labBindState" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                   <%-- <tr bgcolor="#C0DBF9">
                        <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                            QQ号码：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:TextBox ID="tbQQ" runat="server" CssClass="in_text_hui" Width="200px"></asp:TextBox>
                        </td>
                    </tr>--%>
                    <tr bgcolor="#C0DBF9">
                        <td height="20" colspan="2" align="right" bgcolor="#FFFFFF" class="black12">
                            <div id="hr">
                            </div>
                        </td>
                    </tr>
                    <tr bgcolor="#C0DBF9">
                        <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="red12" style="padding-left: 10px;">
                            （为了您的账户安全，请您输入以下信息进行确认：）
                        </td>
                    </tr>
                    <tr bgcolor="#C0DBF9">
                        <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                            核对真实姓名：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:TextBox ID="tbRealityName" runat="server" Text=""></asp:TextBox>
                        </td>
                    </tr>
                    <tr bgcolor="#C0DBF9">
                        <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                            安全保护问题：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:Label ID="lbQuestion" runat="server"></asp:Label>
                            &nbsp;&nbsp;<span class="blue12"><a href="SafeSet.aspx?FromUrl='UserQQBind.aspx'">
                                <asp:Label ID="lbQuestionInfo" runat="server"></asp:Label>
                            </a><span class="blue12">
                        </td>
                    </tr>
                    <tr bgcolor="#C0DBF9">
                        <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                            答案：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:TextBox ID="tbMyA" runat="server"></asp:TextBox>
                            <span class="red12">*</span>
                        </td>
                    </tr>
                    <tr bgcolor="#C0DBF9">
                        <td height="20" colspan="2" align="right" bgcolor="#FFFFFF" class="black12">
                            <div id="hr">
                            </div>
                        </td>
                    </tr>
                    <tr bgcolor="#C0DBF9">
                        <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding: 10px;">
                            <label>
                                <ShoveWebUI:ShoveConfirmButton ID="ShoveConfirmButton1" runat="server" Text="确定绑定" OnClick="btnOK_Click" Style="cursor: pointer;" /><span class="blue12">（点击之后，将进行用户安全验证。）</span>
                            </label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="842" border="0" cellspacing="1" cellpadding="0" bgcolor="#D8D8D8" style="margin-top: 10px;">
        <tr>
            <td width="775" bgcolor="#FFFEDF" class="blue14" style="padding: 5px 10px 5px 10px;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <span class="blue14" style="padding: 5px 10px 5px 10px;">如有其他问题，请联系网站客服：<span class="red14"><%= _Site.ServiceTelephone %>
                            </span></span>
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
