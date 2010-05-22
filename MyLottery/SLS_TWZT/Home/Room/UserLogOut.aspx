<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/UserLogOut.aspx.cs" inherits="Home_Room_UserLogOut" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户注销-<%=_Site.Name %>-手机买彩票，就上<%=_Site.Name %>！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球、时时乐、时时彩、足彩等众多彩种的实时开奖信息、图表走势、分析预测等。"/>
    <meta name="keywords" content="用户注销" />
     
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
                        <img src="images/icon_5.gif" width="19" height="20" />
                    </td>
                    <td valign="middle" class="red14" style="padding-left: 10px;">
                        我的账户
                    </td>
                </tr>
            </table>
            <table width="842" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                <tr>
                    <td width="20" height="29">
                        &nbsp;
                    </td>
                    <td width="100" align="center" background="images/admin_qh_100_1.jpg" class="blue12">
                        <a href="ViewAccount.aspx"><strong>帐户注销</strong></a>
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
                    <td height="30" colspan="2" align="left" bgcolor="#E9F1F8" class="black12" style="padding-left: 20px;">
                        您好，<span class="red12"><%=UserName%></span>！您当前帐户余额为：￥<span class="red12"><%= Balance%>
                        </span>元
                    </td>
                </tr>
            </table>
            <br />
            <table width="842" border="0" cellpadding="0" cellspacing="0" bgcolor="#C0DBF9" style="padding-left: 10px; padding-top :10px;"
                align="center">
                <tr>
                    <td width="93" height="150"  bgcolor="#FFFFFF" class="black12" style =" padding-top:10px;" valign="top">
                        <span class="red12">*</span>输入注销原因：</td>
                    <td width="685" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr bgcolor="#C0DBF9">
                                <td width="98%" align="left" bgcolor="#FFFFFF" class="black12">
                                        <asp:TextBox ID="tbReason" runat="server" Height="150px" 
                                        TextMode="MultiLine" Width="700px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                 <tr>
                        <td height="20" colspan="2" align="right" bgcolor="#FFFFFF" class="black12">
                            <div id="hr">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" bgcolor="#FFFFFF" class="black12">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="red12" style="padding-left: 10px;">
                            （为了您的账户安全，请您输入以下信息进行确认：）
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" bgcolor="#FFFFFF" class="black12">
                            核对登录密码：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:TextBox ID="tbPassWord" runat="server" Text="" TextMode="Password"></asp:TextBox><span class="red12">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" bgcolor="#FFFFFF" class="black12">
                            安全保护问题：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:Label ID="lbQuestion" runat="server"></asp:Label>
                            &nbsp;&nbsp;<span class="blue12"><a href="SafeSet.aspx?FromUrl='UserLogOut.aspx'">
                                <asp:Label ID="lbQuestionInfo" runat="server"></asp:Label>
                            </a><span class="blue12">
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" bgcolor="#FFFFFF" class="black12">
                            答案：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:TextBox ID="tbMyA" runat="server"></asp:TextBox>
                            <span class="red12">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td height="20" colspan="2" align="right" bgcolor="#FFFFFF" class="black12">
                            <div id="hr">
                            </div>
                        </td>
                    </tr>
                <tr>
                    <td height="30" align="right" valign="top" bgcolor="#FFFFFF" class="black12" style="padding-top: 10px;">
                        &nbsp;</td>
                    <td height="30" align="center" valign="top" bgcolor="#FFFFFF" class="black12" style="padding: 10px 0px 10px 10px;">
                            <asp:LinkButton ID="btnDownLoad" runat="server" Text="导出投注记录" OnClick="btnDownLoad_Click" Font-Underline="true" Visible="false"></asp:LinkButton>
                    <asp:ImageButton ID="btnOK" runat="server" Width="56px" Height="28px" ImageUrl="images/bt_zhuxiao.jpg"  OnClick="btnOK_Click" OnClientClick="return btnOK();"/>
                           
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right" valign="top" bgcolor="#FFFFFF" class="black12" style="padding-top: 10px;">
                        &nbsp;
                    </td>
                    <td height="30" align="left" valign="top" bgcolor="#FFFFFF" class="black12" style="padding: 10px 0px 10px 10px;">
                        <table width="98%" border="0" cellspacing="1" cellpadding="0" bgcolor="#FFCD33">
                            <tr>
                                <td bgcolor="#FFFFE1" class="red12" style="padding: 15px;">
                                    温馨提示：一旦注销，账号将被永久删除，无法登录！
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
<script language="javascript">
    function btnOK() {
        if (document.getElementById("tbReason").value == "") {
            alert("请输入注销的原因！");

            return false;
        }
    }
</script>