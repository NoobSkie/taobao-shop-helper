<%@ page language="C#" autoeventwireup="true" CodeFile="~/NewsPapers/Default.aspx.cs" inherits="NewsPapers_Default" enableEventValidation="false" %>

<%@ Register TagPrefix="ShoveWebUI" Namespace="Shove.Web.UI" Assembly="Shove.Web.UI.4 For.NET 3.5" %>
<%@ Register Src="../Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>彩友报列表－彩友报－<%=_Site.Name %>主办－手机买彩票，就上<%=_Site.Name %>！</title>
    <meta runat="server" id="key" name="keywords" content="彩友报列表" />
    <meta runat="server" id="des" name="description" content="彩友报是<%=_Site.Name %>为广大彩民定期提供的一份彩票咨询电子期刊。" />
    <link href="../Home/Room/Style/css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
    <div align="center">
        <table width="1002" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <img src="Images/222.jpg" width="1002" height="66" />
                </td>
            </tr>
            <tr>
                <td>
                    <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                        <tr>
                            <td>
                                <table width="1002" border="0" cellpadding="0" cellspacing="0" class="table"  background="Images/tit_bg2.jpg">
                                    <tr>
                                        <td width="135" height="28">
                                            <img src="images/bt2.gif" width="152" height="32" alt="走势图工具" />
                                      </td>
                                        <td width="867" align="left">
                                            <table width="98%" border="0" cellspacing="0" cellpadding="0" style="margin-left: 5px;">
                                                <tr>
                                                    <td width="122" height="30" align="center" class="blue12_4">
                                                        彩友报列表
                                                    </td>
                                                    <%--                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="70" align="center" class="blue12_3">
                                                        &nbsp;<a href="#">双彩投注报</a>&nbsp;
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="80" align="center" class="blue12_3">
                                                        &nbsp;<a href="#">图谜·字谜报</a>&nbsp;
                                                    </td>
                                                    <td width="5" align="center" class="blue12">
                                                        |
                                                    </td>
                                                    <td width="100" align="center" class="blue12_3">
                                                        &nbsp;<a href="#">点播彩票手机报</a>&nbsp;
                                                    </td>--%>
                                                  <td width="711" align="right" class="blue12_3" style="padding-right: 30px;">
                                                        <%=_Site.Name %>第<asp:DropDownList ID="ddlIsusesID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIsusesID_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        期报
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="49%">
                                                        <table width="360" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                                                            <tr>
                                                                <td>
                                                                    <a href="4.aspx">
                                                                        <img src="Images/cyb_0903.jpg" alt="彩友报第0903期" /></a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="28" background="Images/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12" align="center">
                                                                    <h1 class="blue12" style="display: inline;">
                                                                        彩友报第0903期
                                                                    </h1>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="51%">
                                                        <table width="370" height="399px" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9"
                                                            style="margin-left: 10px;">
                                                            <tr>
                                                                <td height="28" align="left" bgcolor="#DDF0F9">
                                                                    <span class="red14">&nbsp;&nbsp;本期导读</span><br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="50%" style="padding: 5px 10px 5px 10px;" align="left" bgcolor="#DDF0F9" class="blue12">
                                                                    <span class="blue14">每日推荐：</span><br />
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;<span class="hui14">&#9642;</span>&nbsp;双色球专家麒麟第09126期：红球和值上升蓝盯1路<br />                                                                        
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;<span class="hui14">&#9642;</span>&nbsp;福彩3D专家杨哥第09292期：看好2奇1偶<br />                                                                        
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;<span class="hui14">&#9642;</span>&nbsp;大乐透专家田野09125期：二区10-12范围热<br />                                                                        
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;<span class="hui14">&#9642;</span>&nbsp;上海时时乐今日最具投资价值遗漏推荐<br />                                                                        
                                                                    <hr style="border: 1px dashed gray; height: 1px" />
                                                        
                                                                    <span class="blue14">专家作品(<%=_Site.Name %>首发)：</span><br />
                                                                     &nbsp;&nbsp;&nbsp;&nbsp;<span class="hui14">&#9642;</span>&nbsp;双色球用&quot;012&quot;路预测蓝球走势(彩市黑马）<br />                                                                        
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;<span class="hui14">&#9642;</span>&nbsp;追买3D今后可用多线杀球法(小马哥）<br />
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;<span class="hui14">&#9642;</span>&nbsp;双色球稳定决杀红垃圾方法(六红美女)<br />                           
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;<span class="hui14">&#9642;</span>&nbsp;时时乐每日最具价值遗漏推荐(专攻遗漏)<br />
                                                                    <hr style="border: 1px dashed gray; height: 1px" />
                                                             
                                                                    <span class="blue14">购彩常识“万能充”：</span><br />
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;<span class="hui14">&#9642;</span>&nbsp;[双色球]实战技巧:三步跨&quot;蓝&quot;准确率高<br />                                                                    
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;<span class="hui14">&#9642;</span>&nbsp;[大乐透]投注技巧：后区玩法技巧揭秘<br />                                                                        
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;<span class="hui14">&#9642;</span>&nbsp;[时时乐]玩高频彩时应当注意的风险控制<br />                                                                        
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;<span class="hui14">&#9642;</span>&nbsp;[3D]投注技巧：学会三招功夫吃遍天下奖<br />
                                                                        
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="padding-top: 10px; padding-bottom: 10px;">
                                                <img src="Images/banner.jpg" alt="彩友报" /></div>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <table width="360" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9">
                                                            <tr>
                                                                <td>
                                                                    <a href="1.aspx">
                                                                        <img src="Images/cyb_0901.jpg" alt="彩友报第0901期" /></a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="28" background="Images/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12" align="center">
                                                                    <h1 class="blue12" style="display: inline;">
                                                                        彩友报第0901期
                                                                    </h1>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table width="360" border="0" cellspacing="1" cellpadding="0" bgcolor="#BCD2E9" align="right">
                                                            <tr>
                                                                <td>
                                                                    <a href="3.aspx">
                                                                        <img src="Images/cyb_0902.jpg" alt="彩友报第0902期" /></a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="28" background="Images/tit_bg.jpg" bgcolor="#FFFFFF" class="blue12" align="center">
                                                                    <h1 class="blue12" style="display: inline;">
                                                                        彩友报第0902期
                                                                    </h1>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="252" align="right" valign="top">
                                            <table width="243" border="0" cellpadding="0" cellspacing="0" bgcolor="#BCD2E9" class="table">
                                                <tr>
                                                    <td height="29" align="left" valign="bottom" background="Images/tc_r1_c1.jpg" style="padding-left: 5px;">
                                                        <table width="178" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="89" align="center" background="Images/tit.jpg" class="blue12">
                                                                    <strong>专家预测</strong>
                                                                </td>
                                                                <td width="89" height="25" align="center" class="blue12">
                                                                    <strong>&nbsp;</strong>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="252" align="center" bgcolor="#FCFDFE" style="padding: 5px;" id="tdSSQ"
                                                        runat="server" valign="top">
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="243" border="0" cellpadding="0" cellspacing="0" bgcolor="#BCD2E9" class="table"
                                                style="margin-top: 10px;">
                                                <tr>
                                                    <td height="29" align="left" valign="bottom" background="Images/tc_r1_c1.jpg" style="padding-left: 5px;">
                                                        <table width="178" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="89" align="center" background="Images/tit.jpg" class="blue12">
                                                                    <strong>专家预测</strong>
                                                                </td>
                                                                <td width="89" height="25" align="center" class="blue12">
                                                                    <strong>&nbsp;</strong>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="252" align="center" bgcolor="#FCFDFE" style="padding: 5px;" id="td3D"
                                                        runat="server" valign="top">
                                                    </td>
                                                </tr>
                                            </table>
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
