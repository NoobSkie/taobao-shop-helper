<%@ page language="C#" autoeventwireup="true" CodeFile="Help_Index.aspx.cs"  inherits="Home_Room_Help_Help_Index" enableEventValidation="false" %>

<%@ Register Src="~/Home/Room/UserControls/Lotteries.ascx"TagName="Lotteries" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../style/css.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../../../favicon.ico" />
    <script type="text/javascript">

        function mOver(obj, type) {
            if (type == 1) {
                obj.style.textDecoration = "underline";
                obj.style.color = "#FF0065";
            }
            else {
                obj.style.textDecoration = "none";
                obj.style.color = "#000000";


            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hdLotteryID" runat="server" />
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
    <div id="user">
        <div id="user_l">
            <table width="182" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="background-image: url('../images/user_left_top.jpg'); height: 9px;">
                    </td>
                </tr>
                <tr>
                    <td background="../images/user_left_bg.jpg" style="padding: 5px 10px 5px 12px;">
                        <asp:Panel ID="Panel1" runat="server">
                            <table width="155" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="106" height="30" class="blue14">
                                        <a href="Help_Index.aspx?Type=helpfirst.htm" target="_self">帮助中心 </a>
                                    </td>
                                    <td width="49" class="gray12">
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('UserReg')">
                                                    注册流程
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('UserLogin')">
                                                    登录流程
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Send')">
                                                    充值流程
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Buy')">
                                                    购彩流程
                                                </td>
                                            </tr>
                                               <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Prize')">
                                                    我中奖了，如何领奖
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22">
                                                    <div id="hr">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Invest')">
                                                    如何查看投注记录
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('FollowFriendScheme')">
                                                    如何定制跟单
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Chase')">
                                                    什么叫追号
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Double')">
                                                    什么叫倍投
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Miss')">
                                                    什么叫遗漏
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('HotAndCool')">
                                                    号码冷热的含义
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Cobuy1')">
                                                    如何合买
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Scheme')">
                                                    方案保密
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('DoubleAndChase')">
                                                    如何倍投追号
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('TrendChart')">
                                                    如何看走势图
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('NewsPaper')">
                                                    如何订阅彩友报
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Analyse_Miss')">
                                                    如何分析遗漏
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22">
                                                    <div id="hr">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Community')">
                                                    如何参与社区讨论
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('ChaseAndBuy')">
                                                    如何发追号合买
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Commission')">
                                                    如何设置佣金比例
                                                </td>
                                            </tr>
                                                  <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('card_pwd')">
                                                    如何使用卡密
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Account_Security ')">
                                                    帐户安全
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Email')">
                                                    邮箱绑定
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('BankAndAlipay')">
                                                    银行卡绑定与支付宝绑定
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('Draw_Money')">
                                                    提现
                                                </td>
                                            </tr>
                                            <!--
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('LogOut')">
                                                    注销用户
                                                </td>
                                            </tr>
                                            -->
                                        <%--    <tr>
                                                <td height="22">
                                                    <div id="hr">
                                                    </div>
                                                </td>
                                            </tr>--%>
                                         <%--   <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('index')">
                                                    新手入门全过程
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('account_safe')">
                                                    账户安全
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('buy_distill')">
                                                    购彩与提现
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('cobuy')">
                                                    如何发起合买,参与合买
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('viewbuy')">
                                                    查看投注记录
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('scheme_safe')">
                                                    方案保密
                                                </td>
                                            </tr>--%>
                                      
                                         <%--   <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('followscheme')">
                                                    什么是定制跟单
                                                </td>
                                            </tr>--%>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server">
                            <table width="155" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="30" class="blue14">
                                        <a onclick="loadHelpHtml(5)" style="cursor: hand;">玩法介绍 </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(5)">
                                                    双色球
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(6)">
                                                    福彩3D
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(59)">
                                                    15选5
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(13)">
                                                    七乐彩
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(58)">
                                                    东方6+1
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22">
                                                    <div id="hr">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(1)">
                                                    胜负彩
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(15)">
                                                    六场半全场
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml('1_9')">
                                                    任选九
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(2)">
                                                    四场进球
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22">
                                                    <div id="hr">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(39)">
                                                    超级大乐透
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(3)">
                                                    七星彩
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(9)">
                                                    22选5
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(65)">
                                                    31选7
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(63)">
                                                    排列三
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(64)">
                                                    排列五
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22">
                                                    <div id="hr">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(29)">
                                                    时时乐
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                    onclick="loadHelpHtml(62)">
                                                    十一运夺金
                                                </td>
                                            </tr>
                                               <tr>
                                                <td height="22" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)" class="black12"
                                                    background="../images/user_menu_bg_2.jpg" style="padding-left: 18px; cursor: pointer;"
                                                     onclick="loadHelpHtml('jxssc')">
                                                    时时彩
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="background-image: url('../images/user_left_foot.jpg'); height: 9px;">
                    </td>
                </tr>
            </table>
        </div>
        <div id="user_r">
            <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 10px;" width="842">
                <tr>
                    <td height="30" width="20">
                        &nbsp;
                    </td>
                    <td align="center" width="90" id="tdHelpCenter">
                        <a style="cursor: hand;" onclick="show(1);">帮助中心</a>
                    </td>
                    <td width="5">
                        &nbsp;
                    </td>
                    <td align="center" width="90" id="tdPlayType">
                        <a style="cursor: hand;" onclick="show(2);">玩法介绍</a>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#FF6600" colspan="5" height="2">
                    </td>
                </tr>
            </table>
            <%-- <iframe id="frmmain" name="frmmain" src="#" width="100%" height="300"></iframe>--%>

            <script language="javascript">
                function show(type) {

                    if (type == 1) {
                        Panel1.style.display = "";
                        Panel2.style.display = "none";
                        iframe_Help.location = 'helpfirst.htm';

                        document.getElementById("tdHelpCenter").style.backgroundColor = "#FF6600";
                        document.getElementById("tdHelpCenter").className = "bai14";

                        document.getElementById("tdPlayType").style.backgroundColor = "#E4E4E4";
                        document.getElementById("tdPlayType").className = "hui14";
                    }



                    else {
                        Panel1.style.display = "none";
                        Panel2.style.display = "";
                        iframe_Help.location = 'help_5.htm';


                        document.getElementById("tdPlayType").style.backgroundColor = "#FF6600";
                        document.getElementById("tdPlayType").className = "bai14";

                        document.getElementById("tdHelpCenter").style.backgroundColor = "#E4E4E4";
                        document.getElementById("tdHelpCenter").className = "hui14";


                    }

                }
            </script>

            <iframe id="iframe_Help" name="iframe_Help" width="100%" frameborder="0" scrolling="no"
                onload="document.getElementById('iframe_Help').style.height=iframe_Help.document.body.scrollHeight;">
            </iframe>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>

<script type="text/javascript">

    var fromUrlParam = location.search;
    if (fromUrlParam.indexOf("Type") != -1) {
        var lotteryId = fromUrlParam.substring(6, fromUrlParam.indexOf('&'));
        var Number = fromUrlParam.substring(fromUrlParam.length - 1);
        if (lotteryId == "?Type=") {
            lotteryId = fromUrlParam.substring(6);
        }

        if (lotteryId == 'helpfirst.htm') {
            iframe_Help.location.href = 'helpfirst.htm';
        }
        else {
            if (lotteryId == 1 && fromUrlParam.substring(fromUrlParam.length - 1) == 9) {
                iframe_Help.location.href = 'help_1_9.htm';
            }
            else {
                iframe_Help.location.href = 'help_' + lotteryId + '.htm';
            }
        }



        if ("0123456789".indexOf(lotteryId.substring(0, 1)) != -1) {
            Panel1.style.display = "none";
            Panel2.style.display = "";

            document.getElementById("tdPlayType").style.backgroundColor = "#FF6600";
            document.getElementById("tdPlayType").className = "bai14";

            document.getElementById("tdHelpCenter").style.backgroundColor = "#E4E4E4";
            document.getElementById("tdHelpCenter").className = "hui14";
        }
        else {
            Panel2.style.display = "none";
            Panel1.style.display = "";

            document.getElementById("tdHelpCenter").style.backgroundColor = "#FF6600";
            document.getElementById("tdHelpCenter").className = "bai14";

            document.getElementById("tdPlayType").style.backgroundColor = "#E4E4E4";
            document.getElementById("tdPlayType").className = "hui14";
        }
    }
    else {
        iframe_Help.location.href = 'helpfirst.htm';

        Panel1.style.display = "";
        Panel2.style.display = "none";

        document.getElementById("tdHelpCenter").style.backgroundColor = "#FF6600";
        document.getElementById("tdHelpCenter").className = "bai14";

        document.getElementById("tdPlayType").style.backgroundColor = "#E4E4E4";
        document.getElementById("tdPlayType").className = "hui14";

    }

    function loadHelpHtml(lotteryId) {
        if (lotteryId == 'index') {
            iframe_Help.location.href = 'index.htm';
        }
        else {
            iframe_Help.location.href = 'help_' + lotteryId + '.htm';
        }
    }
</script>

