<%@ page language="C#" autoeventwireup="true" CodeFile="FrameLeft.aspx.cs" inherits="Admin_FrameLeft" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Style/Admin.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
        function OnMenuBarClick(sender) {
            sender = document.getElementById(sender);

            for (var i = 1; i <= 8; i++) {
                var obj = document.getElementById("MenuBar_" + i);

                if (!obj) {
                    continue;
                }

                if (obj == sender) {
                    sender.style.display = (sender.style.display == "") ? "none" : "";
                }
                else {
                    obj.style.display = "none";
                }
            }
        }
    </script>

</head>
<body style="background-image: url(../Images/Admin/sqp_05.jpg)">
    <form id="form1" runat="server">
    <div>
        <table width="170px" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="166px" valign="top" background="../Images/Admin/sqp_05.jpg" align="center">
                    <table width="166px" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <a href="../Default.aspx" target="_top">
                                    <img src="../Images/Admin/sqp_03.jpg" alt="" width="166" height="35" border="0" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td height="3" valign="top">
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td valign="top">
                                <table width="146" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="32">
                                            <table width="146" height="32" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td background="../Images/Admin/b1bg.gif" class="bai2" align="left">
                                                        &nbsp; <a href="javascript:OnMenuBarClick('MenuBar_1')" class="STYLE17">&nbsp;+&nbsp;&nbsp;内容管理</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="MenuBar_1" runat="server">
                                        <td height="13" align="center" valign="top" bgcolor="C0E0FE">
                                            <table id="MenuBar_1_0" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="FocusNews.aspx" target="mainFrame">焦点新闻</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="Table6" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="ImageNews.aspx" target="mainFrame">图片新闻</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_1_2" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="News.aspx" target="mainFrame">新闻资讯</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_1_3" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="SiteAffiches.aspx" target="mainFrame">站点公告</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_1_6" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="FriendshipLinks.aspx" target="mainFrame">友情链接</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_1_15" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="Advertisements.aspx" target="mainFrame">广告管理</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_1_16" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="FloatNotifies.aspx" target="mainFrame">弹出通知管理</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_1_22" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="ExpertsPredict.aspx" target="mainFrame">专家预测管理</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_1_20" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="Personages.aspx" target="mainFrame">名人管理</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_1_21" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="SupperCobuy.aspx?TypeState=1" target="mainFrame">超级合买</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <%--<table id="MenuBar_1_23" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="Admin_NewsPaper.aspx" target="mainFrame">彩友报信息</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>--%>
                                            <table id="MenuBar_1_9" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="RegisterAgreement.aspx" target="mainFrame">用户注册协议</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_1_30" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="AllBuyFocus.aspx" target="mainFrame">活跃合买明星</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_1_31" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="RecallingRecord.aspx" target="mainFrame">合买明星战绩回顾</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_1_32" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="SupperCobuy.aspx?TypeState=2" target="mainFrame">足彩合买控制</a>
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
                        <tr>
                            <td valign="top">
                                <table width="146" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="32">
                                            <table width="146" height="32" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td background="../Images/Admin/b1bg.gif" class="bai2" align="left">
                                                        &nbsp; <a href="javascript:OnMenuBarClick('MenuBar_2')" class="STYLE17">&nbsp;+&nbsp;&nbsp;用户管理</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="MenuBar_2" runat="server" style="display: none">
                                        <td height="13" align="center" valign="top" bgcolor="C0E0FE">
                                            <table id="MenuBar_2_1" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="Users.aspx" target="mainFrame">用户一览表</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_2_2" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="UserAccountDetail.aspx" target="mainFrame">用户账户明细</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_2_3" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="UserAddMoney.aspx" target="mainFrame">为用户账户充值</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_2_6" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="Experts.aspx" target="mainFrame">专家管理</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_2_7" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="ExpertsTrys.aspx" target="mainFrame">处理专家申请</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="136" height="10" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="1" border="0" cellpadding="0" cellspacing="0" bgcolor="92BBDD">
                                                            <tr>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_2_10" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="LoginLog.aspx" target="mainFrame">用户登录日志</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_2_11" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="LoginCount.aspx" target="mainFrame">用户访问统计</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <%-- <table id="MenuBar_2_12" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="Admin_UserLogOut.aspx" target="mainFrame">注销详情</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="146" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="32">
                                            <table width="146" height="32" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td background="../Images/Admin/b1bg.gif" class="bai2" align="left">
                                                        &nbsp; <a href="javascript:OnMenuBarClick('MenuBar_3')" class="STYLE17">&nbsp;+&nbsp;&nbsp;彩票业务中心</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="MenuBar_3" runat="server" style="display: none">
                                        <td height="13" align="center" valign="top" bgcolor="C0E0FE">
                                            <table id="MenuBar_3_1" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="LotteryInformation.aspx" target="mainFrame">各彩种规则、说明</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_2" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="LotteryTimeSet.aspx" target="mainFrame">各玩法时间设置</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_3" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="Isuse.aspx" target="mainFrame">期号管理</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_4" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="SchemeAtTop.aspx" target="mainFrame">方案置顶</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_5" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="SchemeQuash.aspx" target="mainFrame">方案撤单</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_6" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="PrintOutput.aspx" target="mainFrame">出票</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_7" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="InputWinNumber.aspx" target="mainFrame">录入开奖号码</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_8" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="PrintOutNotFull.aspx" target="mainFrame">不完整出票方案</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_9" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="Open.aspx" target="mainFrame">开奖&amp;派奖</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_10" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="OpenManual.aspx" target="mainFrame">开奖&amp;派奖(手工)</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_11" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="InputOpenAffiche.aspx" target="mainFrame">录入开奖公告、视频</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_12" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="UploadWinLotteryImage.aspx" target="mainFrame">中奖图片上传</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_13" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="SchemeList.aspx" target="mainFrame">方案查询</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_14" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="WinList.aspx" target="mainFrame">中奖查询</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_3_15" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="ChaseList.aspx" target="mainFrame">追号查询</a>
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
                        <tr>
                            <td valign="top">
                                <table width="146" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="32">
                                            <table width="146" height="32" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td background="../Images/Admin/b1bg.gif" class="bai2" align="left">
                                                        &nbsp; <a href="javascript:OnMenuBarClick('MenuBar_4')" class="STYLE17">&nbsp;+&nbsp;&nbsp;消息管理</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="MenuBar_4" runat="server" style="display: none">
                                        <td height="13" align="center" valign="top" bgcolor="C0E0FE">
                                            <table id="MenuBar_4_1" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="OptionEmail.aspx" target="mainFrame">邮件参数设置</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_4_2" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="OptionISP.aspx" target="mainFrame">ISP接口参数设置</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_4_3" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="NotificationTemplates.aspx" target="mainFrame">各种消息模板</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_4_4" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="NotificationOptions.aspx" target="mainFrame">发送消息选项</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_4_5" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="SendEmail.aspx" target="mainFrame">发送 Email</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_4_6" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="SendStationSMS.aspx" target="mainFrame">发送站内信</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_4_7" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="SendSMS.aspx" target="mainFrame">发送手机短信</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_4_8" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="ReceiveSMS.aspx" target="mainFrame">接收手机短信</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_4_9" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="SendSMSList.aspx" target="mainFrame">已发送手机短信</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_4_10" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="ISPAccount.aspx" target="mainFrame">ISP 账户信息</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_4_11" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="StationSMSList.aspx" target="mainFrame">站内信内容监控</a>
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
                        <tr>
                            <td valign="top">
                                <table width="146" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="32">
                                            <table width="146" height="32" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td background="../Images/Admin/b1bg.gif" class="bai2" align="left">
                                                        &nbsp; <a href="javascript:OnMenuBarClick('MenuBar_6')" class="STYLE17">&nbsp;+&nbsp;&nbsp;服务支持中心</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="MenuBar_6" runat="server" style="display: none">
                                        <td height="13" align="center" valign="top" bgcolor="C0E0FE">
                                            <table id="MenuBar_6_1" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="Questions.aspx" target="mainFrame">处理用户反馈问题</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_6_2" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="UserDistill.aspx" target="mainFrame">处理用户提款申请</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_6_3" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="ProcessingMoney.aspx" target="mainFrame">处理用户充值问题</a>
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
                        <tr>
                            <td valign="top">
                                <table width="146" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="32">
                                            <table width="146" height="32" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td background="../Images/Admin/b1bg.gif" class="bai2" align="left">
                                                        &nbsp; <a href="javascript:OnMenuBarClick('MenuBar_7')" class="STYLE17">&nbsp;+&nbsp;&nbsp;财务中心</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="MenuBar_7" runat="server" style="display: none">
                                        <td height="13" align="center" valign="top" bgcolor="C0E0FE">
                                            <table id="MenuBar_7_1" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="FinanceAddMoney.aspx" target="mainFrame">用户充值明细表</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_7_2" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="FinanceWin.aspx" target="mainFrame">用户中奖明细表</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_7_4" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="FinanceDistill.aspx" target="mainFrame">用户提款明细表</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="Table1" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="UserDistillWaitPay.aspx" target="mainFrame">待付款用户一览表</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="Table5" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="UserDistillProcessing.aspx" target="mainFrame">支付宝付款处理中提款</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="Table2" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="UserDistillUnsuccess.aspx" target="mainFrame">支付宝付款失败一览表</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="Table3" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="UserDistillSuccess.aspx" target="mainFrame">提款成功用户一览表</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="Table4" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="UserDistillGeneralLedger.aspx" target="mainFrame">提款对帐单</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <%--<table id="MenuBar_7_6" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="FinanceCps.aspx" target="mainFrame">联盟推广业务明细表</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>--%>
                                            <table id="MenuBar_7_8" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="FinanceBalance.aspx" target="mainFrame">公司收支汇总表</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_7_11" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0" >
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="CardPasswordAgentsAdd.aspx" target="mainFrame">增加卡密代理商</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_7_9" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="CardPasswordAdd.aspx" target="mainFrame">增加卡密</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_7_10" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="CardPasswordManage.aspx" target="mainFrame">卡密管理</a>
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
                        <tr>
                            <td valign="top">
                                <table width="146" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="32">
                                            <table width="146" height="32" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td background="../Images/Admin/b1bg.gif" class="bai2" align="left">
                                                        &nbsp; <a href="javascript:OnMenuBarClick('MenuBar_8')" class="STYLE17">&nbsp;+&nbsp;&nbsp;系统管理</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="MenuBar_8" runat="server" style="display: none">
                                        <td height="13" align="center" valign="top" bgcolor="C0E0FE">
                                            <table id="MenuBar_8_7" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="SoftKey.aspx" target="mainFrame">软件序列号</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_8_1" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="SelectDefaultFirstPage.aspx" target="mainFrame">缺省首页选择</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_8_2" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="Site.aspx" target="mainFrame">站点资料</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_8_3" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="Options.aspx" target="mainFrame">系统参数设置</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_8_4" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="Competence.aspx" target="mainFrame">权限管理</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_8_5" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="LotteryGateway.aspx" target="mainFrame">电子票接口设置</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="MenuBar_8_6" runat="server" width="136" height="28" border="0" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <table width="136" height="24" border="0" cellpadding="0" cellspacing="1" bgcolor="92BBDD">
                                                            <tr>
                                                                <td bgcolor="#C0E0FE">
                                                                    <a href="OnlinePayGateway.aspx" target="mainFrame">在线支付参数设置</a>
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
                </td>
            </tr>
        </table>
    </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
