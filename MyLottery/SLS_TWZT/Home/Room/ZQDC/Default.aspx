<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/ZQDC/Default.aspx.cs" inherits="Home_Room_ZCDC_Default" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Src="../UserControls/ZCDCHead.ascx" TagName="ZCDCHead" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>足球单场</title>
    <meta name="description" content="<%=_Site.Name %>" />
    <meta name="keywords" content="足球单场" />
    <link href="Style/zc.css" rel="stylesheet" type="text/css" />
    <script src="JScript/default.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="cont_box">
        <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
        <uc1:ZCDCHead ID="ZCDCHead1" runat="server" />
        <div id="zc_menu" style="margin-top: 10px;">
            <table width="1002" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="187" rowspan="2">
                        <img src="Images/zc_logo_dc.jpg" width="187" height="60" />
                    </td>
                    <td height="30" bgcolor="#669ACC" class="bai14" style="padding-left: 15px;">
                        <a href="#">单场赛程</a> | <a href="#">开奖SP值</a> | <a href="#">单场中奖查询</a> | <a href="#">
                            推荐分析</a> | <a href="#">中奖排行榜</a> | <a href="#">单场入门</a>
                    </td>
                    <td width="91" align="right" bgcolor="#669ACC">
                        <img src="images/right_pic.jpg" width="91" height="30" />
                    </td>
                </tr>
                <tr>
                    <td height="30" colspan="2" background="images/bg_hui_30.jpg" class="hui12" style="padding-left: 15px;">
                        <a href="#">单场数据分析</a>&nbsp; <span class="hui122">|</span> &nbsp;<a href="#">奖金计算器</a>&nbsp;
                        <span class="hui122">|</span> &nbsp;<a href="#">单场赔率</a>&nbsp; <span class="hui122">
                            |</span> &nbsp;<a href="#">单场比分</a>
                    </td>
                </tr>
            </table>
        </div>
        <div id="content_dc" style="margin-top: 10px;">
            <div id="zc_left">
                <div style="border: 1px  solid #BCD2E9; background-color: #DDECF2; background-image: url(images/zc_left_bg.jpg);
                    background-repeat: repeat-x; background-position: center top; padding: 13px;">
                    <div style="width: 210px; text-align: right;" class="black12">
                        <a href="#">更多>></a></div>
                    <div style="width: 208px; border: 1px solid #BCD2E9; background-color: #F2F9FB; margin-top: 6px;">
                        <div class="tab1" style="width: 208px; text-indent: 10px; padding-bottom: 10px;">
                            <li><a href="#" target="_blank">单场介绍</a>&nbsp;<a href="#" target="_blank">单场资料</a></li>
                            <li><a href="#" target="_blank">过关方式</a>&nbsp;<a href="#" target="_blank">中奖奖池</a></li>
                            <li><a href="#" target="_blank">五大玩法</a>&nbsp;<a href="#" target="_blank">拖胆过滤</a></li>
                            <li><a href="#" target="_blank">跟单定制</a>&nbsp;<a href="#" target="_blank">参与合买</a></li>
                            <li><a href="#" target="_blank">自动置顶</a>&nbsp;<a href="#" target="_blank">中奖奖池</a></li>
                        </div>
                    </div>
                </div>
            </div>
            <div id="zc_center">
                <table width="360" border="0" cellspacing="1" cellpadding="0" bgcolor="#BED2E9">
                    <tr>
                        <td height="26" background="images/bg_blue_28.jpg" style="padding: 0px 10px 0px 10px;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="4%">
                                        <img src="images/zc_point_red.jpg" width="3" height="14" />
                                    </td>
                                    <td width="62%" class="red14_2" style="padding-top: 3px;">
                                        焦点新闻
                                    </td>
                                    <td width="34%" align="right" class="hui12" style="padding-top: 3px;">
                                        <a href="#">更多&gt;&gt;</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" bgcolor="#FFFFFF" style="padding: 10px 10px 6px 10px; background-image: url(images/bg_foot.jpg);
                            background-repeat: repeat-x; background-position: center bottom;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="25" colspan="2" class="red14">
                                        <a href="#">“你贴票样我送金币，1亿金币大派送”中奖...</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div id="hr" style="height: 6px;">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="4%" height="22" align="center">
                                        <span class="hui14">&#9642;</span>
                                    </td>
                                    <td width="96%" class="black12">
                                        <a href="#">[紧急通知]11月27日至28日注册的新用户</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" align="center">
                                        <span class="hui14">&#9642;</span>
                                    </td>
                                    <td class="black12">
                                        <a href="#">[紧急通知]28日彩种玩法需手动派奖，明天1</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" align="center">
                                        <span class="hui14">&#9642;</span>
                                    </td>
                                    <td class="black12">
                                        <a href="#">通知：支付宝会员登陆网关已经全面恢复，实名制</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" align="center">
                                        <span class="hui14">&#9642;</span>
                                    </td>
                                    <td class="black12">
                                        <a href="#">3D组选3玩法1000万加奖26日（星期三）</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <div id="hr" style="height: 6px;">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" align="center">
                                        <span class="hui14">&#9642;</span>
                                    </td>
                                    <td class="black12">
                                        <a href="#">高手系列报道三：15选5高手蓝山持续小票击中</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="22" align="center">
                                        <span class="hui14">&#9642;</span>
                                    </td>
                                    <td class="black12">
                                        <a href="#">高手系列报道三：15选5高手蓝山持续小票击中</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="zc_right">
                <table width="382" border="0" cellspacing="1" cellpadding="0" bgcolor="#BED2E9">
                    <tr>
                        <td height="26" background="images/bg_blue_28.jpg" style="padding: 0px 10px 0px 10px;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="4%">
                                        <img src="images/zc_point_red.jpg" width="3" height="14" />
                                    </td>
                                    <td width="62%" class="red14_2" style="padding-top: 3px;">
                                        最新中奖
                                    </td>
                                    <td width="34%" align="right" class="hui12" style="padding-top: 3px;">
                                        <a href="#">排行榜</a> | <a href="#">更多&gt;&gt;</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellspacing="1" cellpadding="0">
                                <tr>
                                    <td width="15%" height="29" align="center" bgcolor="#DDECF2" class="blue12">
                                        期号
                                    </td>
                                    <td width="24%" align="center" bgcolor="#DDECF2" class="blue12">
                                        用户名
                                    </td>
                                    <td width="15%" align="center" bgcolor="#DDECF2" class="blue12">
                                        玩法
                                    </td>
                                    <td width="25%" align="center" bgcolor="#DDECF2" class="blue12">
                                        方案金额
                                    </td>
                                    <td width="21%" align="center" bgcolor="#DDECF2" class="blue12">
                                        奖金
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="center" class="black12">
                                        090905
                                    </td>
                                    <td align="center" class="black12">
                                        智慧运气中*
                                    </td>
                                    <td align="center" class="black12">
                                        胜平负
                                    </td>
                                    <td align="center" class="blue12">
                                        ￥1,428
                                    </td>
                                    <td align="center" class="red12_2">
                                        ￥2,701
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="center" bgcolor="#EDF5F8" class="black12">
                                        090905
                                    </td>
                                    <td align="center" bgcolor="#EDF5F8" class="black12">
                                        dmgg05
                                    </td>
                                    <td align="center" bgcolor="#EDF5F8" class="black12">
                                        半全场
                                    </td>
                                    <td align="center" bgcolor="#EDF5F8" class="blue12">
                                        ￥2,322
                                    </td>
                                    <td align="center" bgcolor="#EDF5F8" class="red12_2">
                                        ￥24,090
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="center" class="black12">
                                        090905
                                    </td>
                                    <td align="center" class="black12">
                                        金汇世家
                                    </td>
                                    <td align="center" class="black12">
                                        胜平负
                                    </td>
                                    <td align="center" class="blue12">
                                        ￥2,576
                                    </td>
                                    <td align="center" class="red12_2">
                                        ￥11,097
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="center" bgcolor="#EDF5F8" class="black12">
                                        090905
                                    </td>
                                    <td align="center" bgcolor="#EDF5F8" class="black12">
                                        全能博彩
                                    </td>
                                    <td align="center" bgcolor="#EDF5F8" class="black12">
                                        胜平负
                                    </td>
                                    <td align="center" bgcolor="#EDF5F8" class="blue12">
                                        ￥13,122
                                    </td>
                                    <td align="center" bgcolor="#EDF5F8" class="red12_2">
                                        ￥9,425
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="center" class="black12">
                                        090905
                                    </td>
                                    <td align="center" class="black12">
                                        一休哥3
                                    </td>
                                    <td align="center" class="black12">
                                        胜平负
                                    </td>
                                    <td align="center" class="blue12">
                                        ￥3,888
                                    </td>
                                    <td align="center" class="red12_2">
                                        ￥8,117
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="center" bgcolor="#EDF5F8" class="black12">
                                        090905
                                    </td>
                                    <td align="center" bgcolor="#EDF5F8" class="black12">
                                        瑜珈盈
                                    </td>
                                    <td align="center" bgcolor="#EDF5F8" class="black12">
                                        胜平负
                                    </td>
                                    <td align="center" bgcolor="#EDF5F8" class="blue12">
                                        ￥3,888
                                    </td>
                                    <td align="center" bgcolor="#EDF5F8" class="red12_2">
                                        ￥7,507
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="divNewBuy">
            <iframe id="iframeNewBuy" name="iframeNewBuy" width="100%" frameborder="0" scrolling="no" src="Buy_SPF.aspx" onload="autoHeight();">
            </iframe>
        </div>
        <div id="Div5" style="margin-top: 10px;">
            <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
        </div>
    </div>
    </form>
</body>
</html>
