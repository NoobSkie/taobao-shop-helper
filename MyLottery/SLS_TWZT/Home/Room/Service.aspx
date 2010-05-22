<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/Service.aspx.cs" inherits="Home_Room_Service" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
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
                                            在线提问 &gt; 我要提问
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
                                        <td height="30" colspan="2" align="left" bgcolor="#E9F1F8" class="black12" style="padding-left: 20px;">
                                            ·请您仔细填写带 <span class="red">*</span> 的项目，以便我们更好地为您服务。
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" colspan="2" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 20px;">
                                            <span class="red">
                                                <asp:Label ID="labUserName" runat="server"></asp:Label></span>，您好，欢迎您提问！ <a href="../../Help.aspx?Section=常见问题解答"
                                                    target="_blank">常见问题与详细解答</a> | <a href="QuestionList.aspx">我的问题列表</a> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="18%" height="30" align="right" bgcolor="f7f7f7" class="black12">
                                            问题类型：
                                        </td>
                                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 15px;">
                                            <asp:DropDownList ID="ddlQuestionType" runat="server">
                                            </asp:DropDownList>
                                            <span class="red">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="right" bgcolor="f7f7f7" class="black12">
                                            联系电话：
                                        </td>
                                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 15px;">
                                            <asp:TextBox ID="tbUserTelphone" runat="server" CssClass="in_text_hui" Width="192px"
                                                MaxLength="25"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="right" bgcolor="f7f7f7" class="black12">
                                            问题描述：
                                        </td>
                                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding: 6px 15px 6px 15px;">
                                            <asp:TextBox ID="tbContent" runat="server" Width="100%" Height="144px" TextMode="MultiLine"
                                                MaxLength="500"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="right" bgcolor="f7f7f7" class="black12">
                                            &nbsp;
                                        </td>
                                        <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 15px; padding-right: 10px;">
                                            您可以在“我的信使( <a href="Message.aspx">我的账户中的短消息</a> )”中，查看您提交问题的处理进度和答复情况。<br />
                                            若有其他疑问请联系客服热线：<span class="red"><%=_Site.SiteOptions["ServiceTelephone"].ToString("")%></span><br />
                                            <span class="red">处理时间：9:30～18:00，20:30～22:00 (其中方案撤单：9:30～18:00)</span>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="10">
                                    <tr>
                                        <td align="center" class="black12">
                                            <ShoveWebUI:ShoveConfirmButton runat="server" ID="btnSave" BackgroupImage="images/button_tj.jpg"
                                                Style="font-size: 9pt; cursor: pointer" Height="38px" Width="127px" AlertText="您确定要提交此问题吗？"
                                                OnClick="btnSave_Click" />
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
    </form>
<!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
