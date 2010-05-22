<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/ZQDC/Buy_ZJQS.aspx.cs" inherits="Home_Room_ZCDC_Buy_ZJQS" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>足球单场</title>
    <meta name="description" content="<%=_Site.Name %>" />
    <meta name="keywords" content="足球单场" />
    <link href="Style/zc.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="JScript/boot.js"></script>
    <script type="text/javascript" src="JScript/trade.js"></script>
    <script type="text/javascript" src="JScript/hm.js"></script>
    <script type="text/javascript" src="JScript/sg.js"></script>
    <script type="text/javascript" src="JScript/sg_vote.js"></script>
    <script type="text/javascript" src="JScript/sg_league.js"></script>
    <script type="text/javascript" src="JScript/sg_bonus.js"></script>
    <script src="JScript/sg_sp.js" type="text/javascript"></script>

</head>
<body>
    <form id="buy_form" runat="server" ajax="Buy_Handler.ashx">
    <div id="cont_box">
        <!-- 联赛列表 开始 -->
        <div id="divLeagues" style="position: absolute; left: 21px; top: 80px; display: none">
            <table id="LeagueTable" bgcolor="#91d4ff" cellpadding="2" cellspacing="1" width="140">
                <tr>
                    <td bgcolor="#d1e7fc">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="blue12">
                                    &nbsp;赛事选择
                                </td>
                                <td width="1" align="right">
                                    <img src="images/btnClose.gif" alt="关闭" style="cursor: pointer;" onclick="document.getElementById('divLeagues').style.display='none'" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f1f8fe">
                        <table cellspacing="0" cellpadding="1" width="100%" border="0">
                            <tbody id="mgList">
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="25" align="center" bgcolor="#f1f8fe">
                        <img src="images/select_all.gif" alt="全选" style="cursor: pointer;" id="selectAllBtn" />
                        <img src="images/select_alt.gif" alt="反选" style="cursor: pointer;" id="selectOppBtn" />
                        <img src="images/close2.gif" alt="关闭" style="cursor: pointer;" onclick="document.getElementById('divLeagues').style.display='none'" />
                    </td>
                </tr>
            </table>
        </div>
        <!-- 联赛列表 结束-->
        <!--vs.Start -->
        <div id="Div1" style="margin-top: 10px;">
            <table width="1002" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="100" height="28" align="center" bgcolor="#E8E8E8" class="black14">
                        <a href="Buy_SPF.aspx">让球胜负平</a>
                    </td>
                    <td width="3" align="center">
                        &nbsp;
                    </td>
                    <td width="100" align="center" bgcolor="#508AC5" class="bai14">
                        <a href="Buy_ZJQS.aspx">总进球数</a>
                    </td>
                    <td width="3" align="center">
                        &nbsp;
                    </td>
                    <td width="100" align="center" bgcolor="#E8E8E8" class="black14">
                        <a href="Buy_SXDS.aspx">上下单双</a>
                    </td>
                    <td width="3" align="center">
                        &nbsp;
                    </td>
                    <td width="100" align="center" bgcolor="#E8E8E8" class="black14">
                        <a href="Buy_ZQBF.aspx">比分</a>
                    </td>
                    <td width="3" align="center">
                        &nbsp;
                    </td>
                    <td width="100" align="center" bgcolor="#E8E8E8" class="black14">
                        <a href="Buy_BQC.aspx">半全场</a>
                    </td>
                    <td width="3" align="center">
                        &nbsp;
                    </td>
                                       <td width="100" align="center" bgcolor="#E8E8E8" class="black14">
                        <a href="FollowZQDCScheme.aspx">定制跟单</a>
                    </td>
                    <td width="3" align="center">
                        &nbsp;
                    </td>
                    <td width="100" align="center" bgcolor="#E8E8E8" class="black14">
                        <a href="SchemeAll.aspx">全部方案</a>
                    </td>
                    <td width="3" align="center">
                        &nbsp;
                    </td>
                    <td width="100" align="center" bgcolor="#E8E8E8" class="red14">
                        <a href="CoBuyDC.aspx">方案合买</a>
                    </td>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="3" colspan="16" bgcolor="#508AC5">
                    </td>
                </tr>
            </table>
            <table width="1002" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="100" height="40" background="images/bg_blue_36.jpg" class="black12" style="padding-left: 20px;"
                        valign="middle">
                        <a href="#">
                            <img src="images/bt_xuanzhe.jpg" alt="选择赛事" width="68" height="20" border="0" style="cursor: pointer;"
                                id="mathSelectBtn" />
                        </a>
                    </td>
                    <td width="730" background="images/bg_blue_36.jpg" class="black12">
                        已隐藏<span class="red12" id="showHideNum">0</span>场比赛 <a href="#" onclick="return sg_league.showMatch();">
                            <span class="red12">恢复</span></a> |
                        <input type="checkbox" id="showEndBtn" />
                        <label for="showEndBtn" id="showEndLabel">
                            显示已截止场次</label>[<span class="red12"><span id="jz_changci_span">0</span>场</span>]
                    </td>
                                       <td width="172" style="background:url(images/bg_blue_36.jpg);text-align:right;"  class="black12">
                        查看：
                        <asp:DropDownList ID="ddlIssues" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlIssues_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="1" colspan="3" bgcolor="#BCD2E9">
                    </td>
                </tr>
            </table>
            <table width="1002" border="0" cellspacing="0" cellpadding="0" bgcolor="#F6FAFD">
                <tr>
                    <td height="30" colspan="2" class="hui12" style="padding-left: 30px;">
                        <span class="red12">截止时间：</span>普通过关赛前<span class="red12">10</span>分钟；组合及自由过关赛前<span
                            class="red12">30</span>分钟。
                    </td>
                    <td class="black12" align="center">
                        <a href="#">玩法介绍</a> | <a href="#">投注规则</a> | <a href="#">过滤软件</a> | <a href="#">即时比分</a>
                    </td>
                </tr>
            </table>
            <table width="1002" border="1" cellspacing="0" cellpadding="0" bordercolor="#FFFFFF"
                bordercolorlight="#BCD2E9" bgcolor="#E9F1F8">
                <tr>
                    <td width="58" height="52" rowspan="2" align="center" bgcolor="#8FB5DA" class="bai12">
                        场次
                    </td>
                    <td width="79" rowspan="2" align="center" bgcolor="#8FB5DA" class="bai12">
                        赛事类型
                    </td>
                    <td width="62" rowspan="2" align="center" bgcolor="#8FB5DA" class="bai12">
                        开赛时间
                    </td>
                    <td width="68" rowspan="2" align="center" bgcolor="#8FB5DA" class="bai12">
                        截止时间
                    </td>
                    <td width="70" rowspan="2" align="center" bgcolor="#8FB5DA" class="bai12">
                        主队
                    </td>
                    <td width="81" rowspan="2" align="center" bgcolor="#8FB5DA" class="bai12">
                        客队
                    </td>
                    <td width="48" rowspan="2" align="center" bgcolor="#8FB5DA" class="bai12">
                        比分
                    </td>
                    <td colspan="9" align="center" bgcolor="#8FB5DA" class="bai12">
                        请选择投注/参考SP值
                    </td>
                </tr>
                <tr>
                    <td width="55" height="25" align="center" bgcolor="#8FB5DA" class="bai12">
                        0
                    </td>
                    <td width="55" align="center" bgcolor="#8FB5DA" class="bai12">
                        1
                    </td>
                    <td width="55" align="center" bgcolor="#8FB5DA" class="bai12">
                        2
                    </td>
                    <td width="55" align="center" bgcolor="#8FB5DA" class="bai12">
                        3
                    </td>
                    <td width="55" align="center" bgcolor="#8FB5DA" class="bai12">
                        4
                    </td>
                    <td width="55" align="center" bgcolor="#8FB5DA" class="bai12">
                        5
                    </td>
                    <td width="55" align="center" bgcolor="#8FB5DA" class="bai12">
                        6
                    </td>
                    <td width="55" align="center" bgcolor="#8FB5DA" class="bai12">
                        7+
                    </td>
                    <td width="27" align="center" bgcolor="#8FB5DA" class="bai12">
                        包
                    </td>
                </tr>
                <tbody id="mathList">
                    <%= MatchList %>
                </tbody>
            </table>
        </div>

        <!--vs.End -->

        <!-- 奖金评测开始 !-->
        <div id="bonus_box" style="position: absolute; z-index: 9999; left: 20px; top: 100px;
            background: #2196C4; display: none;" class="flickdiv">
            <div id="bonus_head" class="f_box1" style="background-image: url('images/tantopbg.gif')">
                <span style="float: left; font-size: 16px; color: #fff; font-weight: bold;">&nbsp;&nbsp;足球单场奖金预测</span><span
                    id="bonus_close"><img style="cursor: pointer;" src="images/tantopx.gif" /></span></div>
            <div style="background: #FFFFFF; padding: 15px 0; height: 300px; overflow: auto;
                text-align: center">
                <table width='500' border='0' cellpadding='2' cellspacing='1' class='table1' style="margin: 0 auto 10px auto;">
                    <caption align="center">
                        <span style="font-size: 16px; font-weight: bold; color: #FF0000">足球单场奖金预测</span></caption>
                    <tr class="td12">
                        <td class="td12" width="15%">
                            场次
                        </td>
                        <td class="td12">
                            比赛
                        </td>
                        <td class="td12" style="display: none">
                            您的选择
                        </td>
                        <td class="td12">
                            您的选择(SP)
                        </td>
                        <td class="td12">
                            最小SP值
                        </td>
                        <td class="td12">
                            最大SP值
                        </td>
                        <td class="td12">
                            胆码
                        </td>
                    </tr>
                    <tbody id="bonus_vote">
                    </tbody>
                </table>
                <br />
                <br />
                <table width='500' border='0' cellpadding='2' cellspacing='1' class='table1' style="margin: 0 auto 10px auto;">
                    <tbody id="bonus_prize">
                    </tbody>
                </table>
                <br />
                <br />
                <table width='500' border='0' cellpadding='2' cellspacing='1' class='table1' style="margin: 0 auto 10px auto;">
                    <tbody id="bonus_more">
                    </tbody>
                </table>
            </div>
        </div>
        <!-- 奖金评测结束 !-->
        <!-- 投注区域开始 !-->
        <div style="margin-top: 10px;">
            <div id="gc_left">
                <table width="450" border="1" cellspacing="0" cellpadding="0" bordercolor="#FFFFFF"
                    bordercolorlight="#BCD2E9" bgcolor="#E9F1F8">
                    <tr>
                        <td height="30" colspan="5" bgcolor="#8FB5DA" class="bai14" style="padding-left: 15px;">
                            您选择的场次及投注选项
                        </td>
                    </tr>
                    <tr>
                        <td width="58" height="25" align="center" bgcolor="#E9F1F8" class="blue12">
                            <strong>场次</strong>
                        </td>
                        <td width="158" align="center" bgcolor="#E9F1F8" class="blue12">
                            <strong>比赛</strong>
                        </td>
                        <td width="174" align="center" bgcolor="#E9F1F8" class="blue12">
                            <strong>您的投注</strong>
                        </td>
                        <td width="50" style="display: none;" align="center" bgcolor="#E9F1F8" class="blue12">
                            <strong>定胆</strong>
                        </td>
                    </tr>
                    <tbody id="selectList">
                    </tbody>
                    <tr>
                        <td colspan="5" align="center" bgcolor="#FFFFFF">
                            <span style="line-height: 22px;">
                                <img src="images/b_img_014.gif" id="clearOptionBtn" style="cursor: pointer;" /></span>
                        </td>
                    </tr>
                    <tr>
                        <td height="24" colspan="5" bgcolor="#E9F1F8" class="black12" style="padding: 5px 15px 5px 15px;">
                            本方案截止时间为：
                            <br />
                            普通过关：<span class="red12" id="normal_endTime">--</span> 组合/自由过关：<span class="red12"
                                id="zh_endTime">--</span>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="gc_right">
                <table width="542" border="1" cellspacing="0" cellpadding="0" bordercolor="#FFFFFF"
                    bordercolorlight="#BCD2E9" bgcolor="#E9F1F8">
                    <tr>
                        <td height="30" bgcolor="#8FB5DA" class="bai14" style="padding-left: 15px;" colspan="5">
                            确认投注信息及购买
                        </td>
                    </tr>
                    <tr>
                        <td height="25" class="blue12" style="padding-left: 10px;" colspan="5">
                            <strong>1、选择过关类型</strong>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" bgcolor="#FFFFFF" class="black12" style="padding-left: 5px;" colspan="5">
                            <input type="radio" name="ggType" id="ggType_1" value="0" checked="checked" /><label
                                for="ggType_1">普通过关</label>
                            <input type="radio" name="ggType" id="ggType_2" value="1" /><label for="ggType_2">组合过关</label>
                            <input type="radio" name="ggType" id="ggType_3" value="2" /><label for="ggType_3">自由过关</label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" class="blue12" style="padding-left: 10px;" colspan="5">
                            <strong>2、选择过关方式</strong>
                        </td>
                    </tr>
                    <tbody id="ggList">
                    </tbody>
                    <tr>
                        <td height="25" class="blue12" style="padding-left: 10px;" colspan="5">
                            <strong>3、选择投注倍数</strong>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;" colspan="5">
                            <label for="multiple">
                                倍数：</label><input name="multiple" id="multiple"  maxlength="2" type="text" value="1" size="3" />(倍数必须为 0~99 范围的整数)
                        </td>
                    </tr>
                    <tr>
                        <td height="25" class="blue12" style="padding-left: 10px;" colspan="5">
                            <strong>4、确认投注结果 </strong>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;" colspan="3">
                            方案注数<span class="red12" id="baseCount">0</span>注，倍数<span class="red12" id="showCount">1</span>倍，总金额<span
                                class="red12" id="caseMoney">￥0.00</span>元 <span class="red12" id="jiangjinYS" style="display: none">
                                    区间：0-0元</span>
                        </td>
                        <td bgcolor="#FFFFFF" class="black12" style="text-align: center;" colspan="2">
                            <a href="javascript:void(0);" id="bonusEvaluating">
                                <img src="images/bt_yuche.jpg" width="81" height="24" alt="奖金预测" border="0" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td height="30" bgcolor="#FFCCFF" class="red14_2" style="padding-left: 10px;" colspan="5">
                            <input id="CoBuy" name="CoBuy" type="checkbox" />我要发起合买方案
                        </td>
                    </tr>
                                        <tbody id="trShowJion" style="display: none; line-height: 2; height: 36px; background-color: #FFEEEE;
                        text-align: center; padding-left: 10px; padding-right: 10px;">
                        <tr>
                            <td align="left" colspan="5" class="black12">
                                佣金比率：<input type="text" id="bonusScale" name="bonusScale" value="4" style="width: 56px;"
                                    maxlength="10" />% &nbsp;&nbsp;&nbsp;<font color="#ff0000">【注】</font>佣金比例只能为:0%~10%，默认:4%。
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="5" class="black12">
                                我要分成：<input type="text" id="divideCount" name="divideCount" style="width: 56px;"
                                    maxlength="10" value="1" />份，每份 <span id="perMoney" style="color: Red">0.00</span>&nbsp;元。&nbsp;&nbsp;
                                <font color="#ff0000">【注】</font>份数不能为空，且能整除总金额。
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="5" class="black12">
                                我要认购：<input type="text" id="buyCount" name="buyCount" style="width: 56px;" value="1" />份，金额
                                <span id="buyMoney" name="buyMoney" style="color: Red">0.00</span>&nbsp;元(<span id="buyScale" class="red12">0%</span>
                                )。<font color="#ff0000">【注】</font>至少认购方案总额的10%。<span id="divCountByInfo" style="display: none"><br />
                                    您至少需认购 <span id="needbuy" class="red12">0</span> 份，共计 <span id="needmoney" class="red12">
                                        0</span> 元</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="5" class="black12">
                                我要保底：<input type="text" id="baodiCount" name="baodiCount" style="width: 56px;" value="0">份，保底
                                <span id="baodiMoney" name="baodiMoney" style="color: Red">0.00</span>&nbsp;元。&nbsp; <font color="#ff0000">
                                    【注】</font>保底资金将被暂时冻结,在当期截止销售时、或根据此方案的销售、撤单情况,冻结资金将返还到您的电话投注卡账户中。
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="5" class="black12">
                                招股对象：<input type="text" id="buyUser" name="buyUser" style="width: 98%;" maxlength="4000" /><br />
                                <font color="#ff0000">【注】</font>您可以选择一些用户作为招股对象，用户名之间用 , 隔开。<br />
                                如：icaile,中个500万,双色球高手,...填写错误的用户名、格式不正确、或者没有填写则表示向全部会员招股。
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="5" class="black12">
                                方案标题：<input type="text" id="caseTitle" name="caseTitle" style="width: 98%;" maxlength="50" /><font
                                    color="#ff0000">【注】</font>标题不能为空,长度不能超过 <font color="#ff0000">50</font> 个字符。
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="5" class="black12">
                                方案描述：<textarea id="caseDescription" name="caseDescription" style="width: 98%; height: 100px;"></textarea>
                            </td>
                        </tr>
                    </tbody>
                    <tr>
                        <td height="30" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;" colspan="5">
                            方案保密：
                            <input type="radio" name="secrecyLevel" id="SecrecyLevel0" value="0" checked="checked" />
                            <span>不保密</span>
                            <input type="radio" name="secrecyLevel" id="SecrecyLevel1" value="1" />
                            <span>保密到截止</span>
                            <input type="radio" name="secrecyLevel" id="SecrecyLevel2" value="2" />
                            <span>保密到开奖</span>
                            <input type="radio" name="secrecyLevel" id="SecrecyLevel3" value="3" />
                            <span>永久保密</span>
                        </td>
                    </tr>
                    <tr>
                        <td height="66" align="center" valign="middle" bgcolor="#FFFFFF" 
                            colspan="5">
                            <a href="#" onclick="return false;">
                                <img src="images/bt_touzhu_2.jpg" alt="" border="0" id="btn_OK"  /></a>
                            <input id="agreement" type="checkbox" checked="checked" />我已经阅读并同意<span class="blue12"><a href="../BuyProtocol.aspx?LotteryID=45" target="_blank">《用户电话短信投注协议》</a></span>&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <!-- 投注区域结束 !-->

        <!-- A区 开始 -->
        <input type="hidden" id="jsonggtype" value="{'单关':1,'2串1':4,'2串3':5,'3串1':6,'3串4':7,'3串7':8,'4串1':9,'4串5':'A','4串11':'B','4串15':'C','5串1':'D','5串6':'E','5串16':'F','5串26':'G','5串31':'H','6串1':'I','6串7':'J','6串22':'K','6串42':'L','6串57':'M','6串63':'N','7串1':'O','8串1':'P','9串1':'Q','10串1':'R','11串1':'S','12串1':'T','13串1':'U','14串1':'V','15串1':'W'}" />
        <input type="hidden" id="expect" name="expect" runat="server" />
        <input type="hidden" id="isuseid" name="isuseid" runat="server" /> 
        <input type="hidden" id="lotid" name="lotid" value="45" />
        <input type="hidden" id="playid" name="playid" value="4502" />
        <input type='hidden' id="minmoney" name='minmoney' value='2' />
        <input type='hidden' id="maxmoney" name='maxmoney' value='20000' />
        
        <!-- A区 结束 -->        
        <!-- B区 开始 -->
        <input type="hidden" id="jz_changci" runat="server" />
        <input type="hidden" id="noMatch" runat="server" />  
        <!-- B区 结束 -->
        <!-- C区 开始 -->
        <input type="hidden" id="codes" name="codes" />
        <input name="totalmoney" id="totalMoney" type="hidden" value="0" />
        <input type="hidden" id="zhushu" name="zhushu" value="0" />
        <input type="hidden" id="ggtypegroupid" name="ggtypegroupid" />
        <input type="hidden" id="ggtypename" name="ggtypename" />
        <input type="hidden" id="ggtypeid" name="ggtypeid" />
        <input type="hidden" id="danma" name="danma" />
        <input type="hidden" id="ishm" name="ishm" value="0" />
        <input type="hidden" id="normal_stopTime" name="normal_stopTime" />   
        <input type="hidden" id="zh_stopTime" name="zh_stopTime" />    
        <!-- C区 结束 -->
    </div>

    <script type="text/javascript">window.trade && trade.init();</script>

    </form>
</body>
</html>
