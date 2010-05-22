<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/SafeSet.aspx.cs" inherits="Home_Room_SafeSet" enableEventValidation="false" %>

<%@ Register Src="UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc3" %>
<%@ Register Src="UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>用户安全问题设置-我的资料-用户中心-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-size: 12px;
            color: #000000;
            font-family: tahoma;
            line-height: 18px;
            height: 17px;
        }
    </style>
<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hdFromUrl" runat="server" />
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
            <table width="842" border="0" cellspacing="0" cellpadding="0" background="images/zfb_left_bg_2.jpg"
                style="margin-top: 10px;">
                <tr>
                    <td width="10" height="29" align="left">
                        &nbsp;
                    </td>
                    <td width="100" align="center" background="images/admin_qh_100_1.jpg" class="blue12">
                        <strong>设置安全问题</strong>
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
            <table width="842" border="0" cellpadding="0" cellspacing="1" bgcolor="#DDDDDD" style="margin-top: 10px;">
                <tr bgcolor="#C0DBF9">
                    <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                        用户名：<span class="red12"></span>
                    </td>
                    <td width="80%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                        <asp:Label ID="tbName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tbody id="tbUserRName" runat="server">
                    <tr bgcolor="#C0DBF9">
                        <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                            真实姓名：<span class="red12"></span>
                        </td>
                        <td width="80%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:TextBox ID="tbRealityName" runat="server" />
                        </td>
                    </tr>
                    <tr bgcolor="#C0DBF9">
                        <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                            密 码：<span class="red12"></span>
                        </td>
                        <td width="80%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:TextBox ID="tbPassWord" runat="server" TextMode="Password"/>
                        </td>
                    </tr>
                </tbody>
                <tbody id="tbOldQF" runat="server">
                    <tr id="trOldQue" runat="server" visible="false">
                        <td height="30" align="right" bgcolor="#F8F8F8" class="black12">
                            原安全保护问题：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:Label ID="lbOQuestion" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trOldAns" runat="server" visible="false">
                        <td height="30" align="right" bgcolor="#F8F8F8" class="black12">
                            原答案：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" style="padding-left: 10px;">
                            <asp:TextBox ID="tbOAnswer" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
                <tbody id="tbNewQF" runat="server">
                    <tr width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                        <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                            安全保护问题
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:DropDownList ID="ddlQuestion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlQuestion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr bgcolor="#C0DBF9" id="trMQ" runat="server" visible="false">
                        <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                            自定义问题：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:TextBox ID="tbMyQuestion" runat="server" MaxLength="90" Width="550"></asp:TextBox>
                        </td>
                    </tr>
                    <tr bgcolor="#C0DBF9">
                        <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">
                            答案：
                        </td>
                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                            <asp:TextBox ID="tbAnswer" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
                <tr>
                    <td bgcolor="#F8F8F8">
                    </td>
                    <td align="left" bgcolor="#FFFFE1" class="red12" style="padding: 10px;">
                        友情提示：<br />
                        1、安全保护问题是最重要的安全凭证，为了您的安全，请牢牢记住您的安全保护问题。<br />
                        2、不要向他人泄露您的安全保护问题。<br />
                    </td>
                </tr>
                <tr bgcolor="#C0DBF9">
                    <td align="right" bgcolor="#FFFFFF" class="style1">
                        &nbsp;
                    </td>
                    <td align="left" bgcolor="#FFFFFF" class="style1" style="padding: 10px;">
                        <asp:Panel ID="Panel1" runat="server">
                            <ShoveWebUI:ShoveConfirmButton ID="btnOK" runat="server" Text="确定修改" AlertText="确信输入的资料无误，并立即保存资料吗？"
                                OnClick="btnOK_Click" Style="cursor: pointer;" />
                            <asp:Button ID="btnGoReset" runat="server" Text=" 重　置 " OnClick="btnGoReset_Click" />
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server">
                            <ShoveWebUI:ShoveConfirmButton ID="btnGoEmail" runat="server" Text="确认重置" AlertText="点击确认后，系统将发送信息至您的绑定邮箱，是否继续？"
                                Style="cursor: pointer;" OnClick="btnGoEmail_Click" />
                            <asp:Button ID="btnReturn" runat="server" Text=" 返　回 " 
                                onclick="btnReturn_Click" />
                            <asp:Label ID="lblTips" runat="server" ForeColor="Red"></asp:Label>
                        </asp:Panel>
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
