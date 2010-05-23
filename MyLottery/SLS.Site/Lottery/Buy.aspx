﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buy.aspx.cs" Inherits="SLS.Site.Lottery.Buy" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Src="~/Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<%@ Register Src="~/Home/Room/UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>双色球-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %>
        ！彩票,体育彩票,福利彩票,双色球合买,超级大乐透代购,开奖信息。</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />

    <script type="text/javascript" src="~/Home/Room/JavaScript/ExplorerCheck.js"></script>

    <script src="~/Home/Room/JavaScript/Public.js" type="text/javascript"></script>

    <script src="~/Home/Room/JavaScript/buy_Lottery.js" type="text/javascript"></script>

    <link href="~/Home/Room/Style/css.css" rel="stylesheet" type="text/css" />
    <link href="~/Home/Room/Style/Buy.css" rel="stylesheet" type="text/css" />

    <script src="~/Home/Room/JavaScript/Marquee.js" type="text/javascript"></script>

    <link rel="shortcut icon" href="~/favicon.ico" />
</head>
<body onload="showSameHeight();showZXHeight();">
    <form id="form1" runat="server">
    <input id="tbPlayTypeID" name="tbPlayTypeID" type="hidden" />
    <asp:HiddenField ID="HidIsuseEndTime" runat="server" />
    <asp:HiddenField ID="HidIsuseID" runat="server" />
    <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
    <uc1:Lotteries ID="Lotteries1" runat="server" />
    <div id="content">
        <div id="menu_left" style="border: 1px solid #BCD2E9; background-color: #E1EFFC;">
            <uc2:UserMyIcaile ID="UserMyIcaile1" runat="server" />
        </div>
        <div id="menu_right">
            <div id="cz_center">
                <div style="margin-bottom: 10px;">
                    <img src="../Home/Room/Images/cz_banner.gif" border="0" alt="" /></div>
                <!-- 期信息开始 -->
                <div style="border: #C0DBF9 1px solid; background-image: url(../Home/Room/Images/bg_hui.jpg);
                    background-repeat: repeat-x; background-position: top; background-color: #F9FDFF;
                    margin-bottom: 5px; height: 100%; overflow: hidden;">
                    <div style="float: left; width: 19%; text-align: center; vertical-align: middle;
                        height: 100%; overflow: hidden;">
                        <img id="LotteryImg" src="../Home/Room/Images/logo_<%=LotteryID.ToString() %>.jpg"
                            alt="双色球" width="105" height="108" />
                    </div>
                    <div style="float: left; width: 81%; margin-top: 0px;">
                        <div id="lastIsuseInfo" style="height: 100%; overflow: hidden;">
                            <img src='../Home/Room/Images/londing.gif' style="position: relative; left: 25%;"
                                alt="" />
                        </div>
                        <div id="tdLotteryIntroduce" class="hui12" style="padding: 4px 0px 2px 0px;">
                            <%=LotteriesIntro[LotteryID]%>
                        </div>
                        <div class="black12" style="width: 100%; height: 24px; line-height: 24px;">
                            第<span id='currIsuseName' class='red12' style='font-weight: bold;'></span>期投注截止时间:&nbsp;<span
                                id="currIsuseEndTime" class="black12"></span>离投注截止还有:<span id='toCurrIsuseEndTime'
                                    style='background-color: Black; font-weight: bold; color: #00FF00; padding: 2px;
                                    font-size: 13px; font-family: 宋体; text-align: center; border-right: 1px solid red;'></span>
                            &nbsp;&nbsp;<span id="testNumber"></span>
                        </div>
                        <div class="red12" style="width: 100%; height: 24px; line-height: 24px;">
                            <a href="<%= ResolveUrl("~/TrendCharts/SSQ/SSQ_CGXMB.aspx") %>">双色球走势图</a>&nbsp;&nbsp;
                            <a href="<%= ResolveUrl("~/WinQuery/OpenInfo_ssq.aspx") %>">双色球中奖查询</a>
                        </div>
                    </div>
                </div>
                <!-- 期信息结束 -->
                <!-- 中奖播报开始 -->
                <div id="divWinNotice" style="width: 100%;" runat="server" visible="false">
                    <div style="float: left; width: 14%; float: left; padding-left: 5px; height: 25px;
                        background: url(../Home/Room/Images/ssl_zjbb_bg.gif)" class="red12_2">
                        中奖播报&nbsp;<img src="../Home/Room/Images/ssl_bb.gif" alt="" />
                    </div>
                    <div id="divSSQ" style="float: left; width: 85%;" runat="server" visible="false">
                        <iframe id="iframe2" name="iframeWinNotice" width="100%" height="25px" frameborder="0"
                            scrolling="no" src="../Home/Room/SSQ_WinNotice.aspx"></iframe>
                    </div>
                    <div id="div3D" style="float: left; width: 85%;" runat="server" visible="false">
                        <iframe id="iframe3" name="iframeWinNotice" width="100%" height="25px" frameborder="0"
                            scrolling="no" src="../Home/Room/3D_WinNotice.aspx"></iframe>
                    </div>
                </div>
                <!-- 中奖播报结束 -->
                <!-- 选项卡开始 -->
                <div id="TabMenu" style="margin-top: 15px; border-bottom: #FF6600 2px solid; text-align: center;
                    padding-bottom: 0px; width: 100%;">
                    <div style="float: left; width: 10px;">
                    </div>
                    <div class="redMenu" onclick="newBuy(<%=LotteryID %>);showSameHeight();">
                        选号投注
                    </div>
                    <div style="float: left; width: 2px;">
                    </div>
                    <div id="td2" class="whiteMenu" onclick="newCoBuy(<%=LotteryID %>);showSameHeight();">
                        参与合买</div>
                    <div style="float: left; width: 2px;">
                    </div>
                    <div class="whiteMenu" onclick="followScheme(<%=LotteryID %>);showSameHeight();">
                        定制跟单</div>
                    <div style="float: left; width: 2px;">
                    </div>
                    <div class="whiteMenu" onclick="schemeAll(<%=LotteryID %>);showSameHeight();">
                        全部方案</div>
                    <div style="float: left; width: 2px;">
                    </div>
                    <div class="whiteMenu" onclick="PlayTypeIntroduce(<%=LotteryID %>);showSameHeight();">
                        <strong>玩法介绍</strong></div>
                </div>
                <!-- 选项卡结束 -->
                <div id="divNewBuy">
                    <table width="612" cellspacing="1" cellpadding="0" bgcolor="#C0DBF9" style="margin-top: 10px;
                        border-bottom: 2px solid #C0DBF9;">
                        <tbody>
                            <%=LotteryPlayTypes[LotteryID]%>
                        </tbody>
                        <tr>
                            <td height="30" align="center" bgcolor="#F7FCFF" class="black12">
                                选号
                            </td>
                            <td valign="top" bgcolor="#FFFFFF">
                                <iframe id="iframe_playtypes" name="iframe_playtypes" width="100%" frameborder="0"
                                    scrolling="no" onload="document.getElementById('iframe_playtypes').style.height=iframe_playtypes.document.body.scrollHeight;showSameHeight();">
                                </iframe>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#ECF9FF" class="black12">
                                投注内容
                            </td>
                            <td valign="top" bgcolor="#FFFFFF">
                                <table width="95%" align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                                    <tr>
                                        <td width="426" valign="top">
                                            <select size="8" name="list_LotteryNumber" multiple="multiple" id="list_LotteryNumber"
                                                style="width: 100%; height: 150px;">
                                            </select>
                                        </td>
                                        <td width="134" style="padding-left: 10px;">
                                            <table width="100%" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="30">
                                                        <input id="btn_2_Rand" name="btn_2_Rand" type="button" value="机选1注" onclick="if(this.disabled){this.style.cursor='';return false;}return iframe_playtypes.btn_2_RandClick();"
                                                            style="cursor: pointer; width: 80px;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30">
                                                        <input id="btn_2_Rand5" name="btn_2_Rand5" type="button" value="机选5注" onclick="if(this.disabled){this.style.cursor='';return false;}return iframe_playtypes.btn_2_RandManyClick(5);"
                                                            style="cursor: pointer; width: 80px;" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30">
                                                        <input id="btnPaste" name="btnPaste" type="button" value="粘贴上传" onclick="CreateUplaodDialog();"
                                                            style="cursor: pointer; width: 80px;" />
                                                        <span id="spanJX" style="display: none">
                                                            <input id="tbJXNumbers" type="text" value="5" maxlength="3" style="width: 22px" onkeypress="return InputMask_Number();" />注<input
                                                                id="btn_2_Randn" style="color: Blue" name="btn_2_Randn" type="button" value="机选"
                                                                onclick="if(this.disabled){this.style.cursor='';return false;}if(StrToInt(tbJXNumbers.value)<1) {alert('请输入注数！'); tbJXNumbers.focus();return false;}else{return iframe_playtypes.btn_2_RandManyClick(StrToInt(tbJXNumbers.value));}"
                                                                style="cursor: pointer; width: 40px;" class="red2" /></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30">
                                                        <input type="button" name="btn_ClearSelect" id="btn_ClearSelect" value="删除选择" style="cursor: pointer;
                                                            width: 80px;" onclick="return btn_ClearSelectClick();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="30">
                                                        <input type="button" name="btn_Clear" id="btn_Clear" value="清空全部" style="cursor: pointer;
                                                            width: 80px;" onclick="return btn_ClearClick();" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table width="95%" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC"
                                    style="margin-top: 10px; margin-bottom: 10px;">
                                    <tr>
                                        <td height="30" bgcolor="#F9F9F9" class="hui12" style="padding-left: 8px;">
                                            <table cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        您选择了 <span class="red12" id="lab_Num">0</span> 注，倍数：
                                                    </td>
                                                    <td>
                                                        <input type="text" onkeypress="return InputMask_Number();" id="tb_Multiple" name="tb_Multiple"
                                                            onblur="CheckMultiple();" value="1" maxlength="3" style="width: 30px;" />
                                                    </td>
                                                    <td>
                                                        &nbsp;总金额 <span class="red12" id="lab_SumMoney">0.00</span> 元。<span class="red12">【注】</span>投注倍数最高为
                                                        999 倍。
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" align="center" bgcolor="#FEDEDE" class="black12">
                                合买代购
                            </td>
                            <td bgcolor="#FEECEC" class="red12" style="padding-left: 5px;">
                                <div id="DivBuy" style="float: left;">
                                    <input id="CoBuy" name="CoBuy" type="checkbox" onclick="oncbInitiateTypeClick(this);"
                                        value="2" />我要发起合买方案 <span style="margin-left: 50px;"></span>
                                </div>
                                <div id="DivChase" style="float: left;">
                                    <input id="Chase" name="Chase" type="checkbox" onclick="oncbInitiateTypeClick(this);"
                                        value="1" />我要追号</div>
                            </td>
                        </tr>
                        <tbody id="trShowJion" style="display: none; line-height: 2; height: 36px; background-color: #FFEEEE;
                            text-align: center; padding-left: 10px; padding-right: 10px;">
                            <tr>
                                <td>
                                    佣金比率
                                </td>
                                <td align="left">
                                    <input type="text" onkeypress="return InputMask_Number();" id="tb_SchemeBonusScale"
                                        name="tb_SchemeBonusScale" onblur="return SchemeBonusScale();" style="width: 56px;"
                                        maxlength="10" />% &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;佣金比例只能为0~10。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    我要分成
                                </td>
                                <td align="left">
                                    <input type="text" onkeypress="return InputMask_Number();" id="tb_Share" name="tb_Share"
                                        onblur="return CheckShare();" style="width: 56px;" maxlength="10" value="1" />份，每份
                                    <span id="lab_ShareMoney" style="color: Red">0.00</span>&nbsp;元。&nbsp;&nbsp; <font
                                        color="#ff0000">【注】</font>份数不能为空，且能整除总金额。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    我要认购
                                </td>
                                <td align="left">
                                    <input type="text" onkeypress="return InputMask_Number();" id="tb_BuyShare" name="tb_BuyShare"
                                        onblur="return CheckBuyShare();" style="width: 56px;" value="1" />份，金额 <span id="lab_BuyMoney"
                                            style="color: Red">0.00</span>&nbsp;元。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    我要保底
                                </td>
                                <td align="left">
                                    <input type="text" onkeypress="return InputMask_Number();" id="tb_AssureShare" name="tb_AssureShare"
                                        onblur="return CheckAssureShare();" style="width: 56px;" value="0">份，保底 <span id="lab_AssureMoney"
                                            style="color: Red">0.00</span>&nbsp;元。&nbsp; <font color="#ff0000">【注】</font>保底资金将被暂时冻结,在当期截止销售时、或根据此方案的销售、撤单情况,冻结资金将返还到您的电话投注卡账户中。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    招股对象
                                </td>
                                <td align="left">
                                    <input type="text" id="tb_OpenUserList" name="tb_OpenUserList" style="width: 99%;"
                                        maxlength="4000" /><br />
                                    <font color="#ff0000">【注】</font>您可以选择一些用户作为招股对象，用户名之间用 , 隔开。<br />
                                    如：icaile,中个500万,双色球高手,...填写错误的用户名、格式不正确、或者没有填写则表示向全部会员招股。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    方案标题
                                </td>
                                <td align="left">
                                    <input type="text" id="tb_Title" name="tb_Title" style="width: 99%;" maxlength="50" /><font
                                        color="#ff0000">【注】</font>标题不能为空,长度不能超过 <font color="#ff0000">50</font> 个字符。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    方案描述
                                </td>
                                <td align="left" style="padding: 10px;">
                                    <textarea id="tb_Description" name="tb_Description" style="width: 99%; height: 100px;"></textarea>
                                </td>
                            </tr>
                        </tbody>
                        <tbody id="trGoon" style="display: none; line-height: 2; height: 36px; background-color: #FFF3F3;
                            text-align: center; padding-left: 10px; padding-right: 10px;">
                            <tr>
                                <td>
                                    追号期间
                                </td>
                                <td align="left" style="padding: 10px;">
                                    <div>
                                        <table cellpadding="0" cellspacing="1" style="width: 100%; text-align: center; background-color: #E2EAED;">
                                            <tbody style="background-color: White;">
                                                <tr>
                                                    <td style="width: 10%;">
                                                        <input type="checkbox" name="cb_All" id="cb_All" onclick="Cb_CheckAll();" />选择
                                                    </td>
                                                    <td style="width: 40%;">
                                                        期号
                                                    </td>
                                                    <td style="width: 20%;">
                                                        投注倍数
                                                    </td>
                                                    <td style="width: 30%;">
                                                        购买金额
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <div id="div_QH_Today" style="height: 200px; overflow: scroll; width: 100%; overflow-x: hidden;">
                                            <table id="RpToday" cellpadding="0" cellspacing="1" style="width: 100%; text-align: center;
                                                background-color: #E2EAED;">
                                                <tbody style="background-color: White;">
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    追号金额
                                </td>
                                <td align="left">
                                    任务总金额 <span id="LbSumMoney" style="color: red;" text="0.00"></span>&nbsp;元
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td>
                                    佣金比率
                                </td>
                                <td align="left">
                                    <input type="text" onkeypress="return InputMask_Number();" id="tb_SchemeBonusScalec"
                                        name="tb_SchemeBonusScalec" onblur="return SchemeBonusScalec();" style="width: 56px;"
                                        maxlength="10" />% &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;佣金比例只能为0~10。
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    自动停止
                                </td>
                                <td align="left">
                                    当追号任务某期中奖金额达到
                                    <input type="text" id="tbAutoStopAtWinMoney" name="tbAutoStopAtWinMoney" maxlength="4"
                                        onkeypress="return InputMask_Number();" value="1" style="width: 60px;" />
                                    元时，系统<span style="color: #ff0000">中奖后自动停止</span>此追号任务。为<span style="color: #ff0000">&nbsp;0&nbsp;</span>时表示不启动自动终止功能。
                                </td>
                            </tr>
                        </tbody>
                        <tr>
                            <td height="30" align="center" bgcolor="#F7FCFF" class="black12">
                                方案保密
                            </td>
                            <td valign="middle" bgcolor="#FFFFFF" style="padding-left: 5px;">
                                <input type="radio" name="SecrecyLevel" id="SecrecyLevel0" value="0" checked="checked" />
                                <span>不保密</span>
                                <input type="radio" name="SecrecyLevel" id="SecrecyLevel1" value="1" />
                                <span>保密到截止</span>
                                <input type="radio" name="SecrecyLevel" id="SecrecyLevel2" value="2" />
                                <span>保密到开奖</span>
                                <input type="radio" name="SecrecyLevel" id="SecrecyLevel3" value="3" />
                                <span>永久保密</span>
                            </td>
                        </tr>
                        <%--                <tr>
                    <td bgcolor="#F7F7F7"></td>
                    <td height="30" bgcolor="#FFFFFF"  style="padding-left: 5px;">
                        <span class="blue12">目前账户余额是</span> <span id="spBalance" class="red12"><%=_User.Balance.ToString("N") %></span> <span class="blue12">
                            元</span> [<a href="javascript:g('Pay.aspx')">充值</a>]
                    </td>
                </tr>--%>
                        <tr>
                            <td height="30" colspan="2" bgcolor="#F7F7F7" align="center" style="padding-bottom: 20px;
                                padding-top: 20px">
                                <ShoveWebUI:ShoveConfirmButton ID="btn_OK" Style="cursor: pointer;" runat="server"
                                    Width="170px" Height="32px" CausesValidation="False" BackgroupImage="../Home/Room/Images/zfb_bt_touzhu.jpg"
                                    BorderStyle="None" OnClientClick="return CreateLogin('isYahoo();');" OnClick="btn_OK_Click" />
                                <asp:CheckBox ID="chkAgrrement" runat="server" Checked="true" />
                                我已经阅读并同意 <span class="blue12">
                                    <asp:HyperLink runat="server" ID="hlAgreement" Target="_blank">《用户电话短信投注协议》</asp:HyperLink></span>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divCoBuy" style="display: none;">
                    <iframe id="iframeCoBuy" name="iframeCoBuy" width="100%" frameborder="0" scrolling="no"
                        onload="document.getElementById('iframeCoBuy').style.height=iframeCoBuy.document.body.scrollHeight;showSameHeight();">
                    </iframe>
                </div>
                <div id="divFollowScheme" style="display: none;">
                    <iframe id="iframeFollowScheme" name="iframeFollowScheme" width="100%" frameborder="0"
                        scrolling="no" onload="document.getElementById('iframeFollowScheme').style.height=iframeFollowScheme.document.body.scrollHeight;showSameHeight();">
                    </iframe>
                </div>
                <div id="divSchemeAll" style="display: none;">
                    <div id="divLoding" style="line-height: 35px; height: 100%; overflow: hidden;">
                        <img src='../Home/Room/images/londing.gif' style="position: relative; top: 10%; left: 40%;"
                            alt="" />
                    </div>
                    <iframe id="iframeSchemeAll" name="iframeSchemeAll" width="100%" frameborder="0"
                        scrolling="no" onload="$Id('iframeSchemeAll').style.display ='';document.getElementById('divLoding').style.display='none';document.getElementById('iframeSchemeAll').style.height=iframeSchemeAll.document.body.scrollHeight;showSameHeight();">
                    </iframe>
                </div>
                <div id="divPlayTypeIntroduce" style="display: none;">
                    <iframe id="iframePlayTypeIntroduce" name="iframePlayTypeIntroduce" width="100%"
                        frameborder="0" scrolling="no" onload="document.getElementById('iframePlayTypeIntroduce').style.height=iframePlayTypeIntroduce.document.body.scrollHeight;showSameHeight();">
                    </iframe>
                </div>
                <div runat="server" id="divLotteryNews" visible="false">
                    <table width="300" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
                        <tr>
                            <td valign="top">
                                <div id="divXB">
                                    <table width="300" border="0" align="right" cellpadding="0" cellspacing="1" bgcolor="#DDDDDD">
                                        <tr>
                                            <td height="28" background="../Home/Room/Images/title_bg_hui.jpg" bgcolor="#FFFFFF"
                                                style="padding-left: 15px;">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="82%" class="blue14">
                                                            <strong>
                                                                <%=NewsType[LotteryID][1]%></strong>
                                                        </td>
                                                        <td width="18%" class="hui12">
                                                            更多&gt;&gt;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" style="padding: 8px 10px 8px 10px;" runat="server" id="tdXB">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td valign="top" rowspan="2" style="padding-left: 10px;">
                                <div id="divYC">
                                    <table width="300" cellspacing="0" cellpadding="0" bgcolor="#DDDDDD" style="border: 1px solid #DDDDDD;">
                                        <tr>
                                            <td height="28" background="../Home/Room/Images/title_bg_hui.jpg" bgcolor="#FFFFFF"
                                                style="padding-left: 15px; border-bottom: 1px solid #DDDDDD;">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="82%" class="blue14">
                                                            <strong>
                                                                <%=NewsType[LotteryID][0]%></strong>
                                                        </td>
                                                        <td width="18%" class="hui12">
                                                            更多&gt;&gt;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" style="padding: 8px 10px 8px 10px;" runat="server" id="tdYC">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdNull" bgcolor="#ffffff">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px" valign="top">
                                <div id="divJQ">
                                    <table width="300" border="0" cellspacing="1" cellpadding="0" bgcolor="#DDDDDD">
                                        <tr>
                                            <td height="28" background="../Home/Room/Images/title_bg_hui.jpg" bgcolor="#FFFFFF"
                                                style="padding-left: 15px;">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="82%" class="blue14">
                                                            <strong>
                                                                <%=NewsType[LotteryID][2]%></strong>
                                                        </td>
                                                        <td width="18%" class="hui12">
                                                            更多&gt;&gt;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="#FFFFFF" style="padding: 8px 10px 8px 10px;" runat="server" id="tdJQ">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="cz_right">
                <!-- 幸运号码 开始-->
                <div id="topxy">
                    <div style="width: 218px; background-image: url(../Home/Room/Images/title_bg_blue.jpg);
                        border: solid 1px #BCD2E9; overflow: hidden;">
                        <div style="width: 100%; line-height: 28px; margin-left: 15px;" class="blue14"">
                            <strong>幸运号码</strong>
                        </div>
                    </div>
                    <div style="width: 218px; border: solid 1px #BCD2E9; border-top: none; text-align: center;
                        height: 100%; overflow: hidden; margin-bottom: 10px;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" background="../Home/Room/Images/ssq_qh_bg.jpg">
                            <tr>
                                <td width="6" height="29">
                                    &nbsp;
                                </td>
                                <td width="40" align="center" background="../Home/Room/Images/ssq_qh_1.jpg" class="blue12">
                                    <a href="javascript:;" id="hrefXZ" onclick="return ClickXYJX(this,1)">星座</a>
                                </td>
                                <td width="4">
                                    &nbsp;
                                </td>
                                <td width="40" align="center" class="blue12">
                                    <a href="javascript:;" id="hrefSX" onclick="return ClickXYJX(this,2)">生肖</a>
                                </td>
                                <td width="4">
                                    &nbsp;
                                </td>
                                <td width="70" align="center" class="blue12">
                                    <a href="javascript:;" id="hrefCSRQ" onclick="return ClickXYJX(this,3)">出生日期</a>
                                </td>
                                <td width="4">
                                    &nbsp;
                                </td>
                                <td width="40" align="center" class="blue12">
                                    <a href="javascript:;" id="hrefXM" onclick="return ClickXYJX(this,4)">姓名</a>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-repeat: repeat-x;
                            background-position: center bottom; background-image: url(../Home/Room/Images/ssq_bg_di.jpg)">
                            <tr>
                                <td style="padding: 10px;">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="48%" height="30" align="left">
                                                <span id="spanXZ">
                                                    <asp:DropDownList ID="ddlXiZuo" runat="server">
                                                        <asp:ListItem Value="1">白羊座</asp:ListItem>
                                                        <asp:ListItem Value="2">金牛座</asp:ListItem>
                                                        <asp:ListItem Value="3">双子座</asp:ListItem>
                                                        <asp:ListItem Value="4">巨蟹座</asp:ListItem>
                                                        <asp:ListItem Value="5">狮子座</asp:ListItem>
                                                        <asp:ListItem Value="6">处女座</asp:ListItem>
                                                        <asp:ListItem Value="7">天秤座</asp:ListItem>
                                                        <asp:ListItem Value="8">天蝎座</asp:ListItem>
                                                        <asp:ListItem Value="9">射手座</asp:ListItem>
                                                        <asp:ListItem Value="10">摩羯座</asp:ListItem>
                                                        <asp:ListItem Value="11">水瓶座</asp:ListItem>
                                                        <asp:ListItem Value="12">双鱼座</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span id="spanSX" style="display: none">
                                                    <asp:DropDownList ID="ddlSX" runat="server">
                                                        <asp:ListItem Value="1">鼠</asp:ListItem>
                                                        <asp:ListItem Value="2">牛</asp:ListItem>
                                                        <asp:ListItem Value="3">虎</asp:ListItem>
                                                        <asp:ListItem Value="4">兔</asp:ListItem>
                                                        <asp:ListItem Value="5">龙</asp:ListItem>
                                                        <asp:ListItem Value="6">蛇</asp:ListItem>
                                                        <asp:ListItem Value="7">马</asp:ListItem>
                                                        <asp:ListItem Value="8">羊</asp:ListItem>
                                                        <asp:ListItem Value="9">猴</asp:ListItem>
                                                        <asp:ListItem Value="10">鸡</asp:ListItem>
                                                        <asp:ListItem Value="11">狗</asp:ListItem>
                                                        <asp:ListItem Value="12">猪</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span><span id="spanCSRQ" style="display: none">
                                                    <asp:TextBox ID="tbDate" runat="server" Width="80" CssClass="hui12" ToolTip="格式：1980-01-01"
                                                        Text="1980-01-01" onfocus="this.className='';this.value='';" onblur="if(this.value==''){this.className='hui12'; this.value='1980-01-01';}"></asp:TextBox>
                                                </span><span id="spanXM" style="display: none">
                                                    <asp:TextBox ID="tbName" runat="server" Width="80" CssClass="hui12" ToolTip="支持中英文"
                                                        Text="支持中英文" onfocus="if(this.value=='支持中英文') {this.className='';this.value='';}"
                                                        onblur="if(this.value=='') {this.className='hui12';this.value='支持中英文';}"></asp:TextBox>
                                                </span>
                                            </td>
                                            <td width="52%">
                                                <img src="../Home/Room/Images/ssq_bt_1.jpg" width="100" height="21" alt="" border="0"
                                                    style="cursor: pointer" onclick="return GetLuckNumber(<%=LotteryID %>)" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" runat="server" id="tdLuckNumber">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center" style="padding-top: 15px; padding-bottom: 5px">
                                                <img src="../Home/Room/Images/ssq_bt_2.jpg" width="140" height="30" alt="" border="0"
                                                    style="cursor: pointer" onclick="return BetLuckNumber(<%=LotteryID %>);" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <!-- 幸运号码 结束-->
                <!-- 福彩专家栏 开始-->
                <div id="FC" runat="server">
                    <div style="width: 218px; background-image: url(../Home/Room/Images/title_bg_blue.jpg);
                        border: solid 1px #BCD2E9;">
                        <div style="float: left; width: 140px; line-height: 28px; padding-left: 15px;" class="blue12_1">
                            <strong>福彩专家栏</strong>
                        </div>
                        <div style="float: left; width: 60px; margin-top: 5px; text-align: right;" class="hui12">
                            <span style="cursor: pointer" onclick="BindFCExpertList(0);">
                                <img src='../Home/Room/Images/page_first.gif' width='9' alt="" height='8' /></span>
                            <span style="cursor: pointer" onclick="BindFCExpertList(1);">
                                <img src='../Home/Room/Images/page_previous.gif' width='9' height='8' alt="" /></span><span
                                    style="padding-left: 10px; cursor: pointer" onclick="BindFCExpertList(2);"><img src='../Home/Room/Images/page_next.gif'
                                        width='9' alt="" height='8' /></span> <span style="cursor: pointer" onclick="BindFCExpertList(3);">
                                            <img src='../Home/Room/Images/page_last.gif' width='9' alt="" height='8' /></span>
                        </div>
                    </div>
                    <div id="ExpertList" style="width: 210px; border: solid 1px #BCD2E9; border-top: none;
                        text-align: center; height: 100%; overflow: hidden; margin-bottom: 10px; padding: 4px;">
                        <br />
                        <img src='../Home/Room/Images/londing.gif' alt="" />
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
                <!-- 福彩专家栏 结束-->
                <!--每期奖不停开始-->
                <%--        <div id="divWinNumber"> 
                     
                        <div id="divTitle" style="width: 218px; background-color: #E7F1FA; border: solid 1px #BCD2E9;">
                            <div style="float: left; width: 120px; line-height: 28px; padding-left: 15px;" class="blue12_1">
                                <strong>每期奖不停</strong>
                            </div>
                       
                        </div>
                        <div id="divNumber" style="width: 218px; border: solid 1px #BCD2E9; border-top: none; height:100px;
                             overflow: hidden; margin-bottom: 10px" runat="server">
                            <br />
                            <img src='../Home/Room/Images/londing.gif' style="position: relative; left: 7%; top: 0px;" alt="" />
                            <br />
                            <br />
                            <br />
                        </div>
                </div>--%>
                <table width="220" id="tdNumber" runat="server" visible="false" border="0" cellspacing="1"
                    cellpadding="0" style="margin-top: 10px; margin-bottom: 10px;" bgcolor="#BCD2E9">
                    <tr>
                        <td width="100%" height="28" style="padding-left: 15px; background-color: #E7F1FA;">
                            <table width="120" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="77%" class="blue14 ">
                                        每期奖不停
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#FFFFFF" width="100%" height="25px" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td id="divNumber" runat="server">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <!--每期奖不停结束-->
                <!-- 开奖列表开始-->
                <div style="width: 218px; background-image: url(../Home/Room/Images/title_bg_blue.jpg);
                    border: solid 1px #BCD2E9;">
                    <div style="float: left; width: 140px; line-height: 28px; padding-left: 15px;" class="blue12_1">
                        <strong>开奖号码</strong>
                    </div>
                    <div style="float: left; width: 60px; margin-top: 5px; text-align: right;" class="hui12">
                        <span style="cursor: pointer" onclick="BindWinNumber(0);">
                            <img src='../Home/Room/Images/page_first.gif' width='9' alt="" height='8' /></span>
                        <span style="cursor: pointer" onclick="BindWinNumber(1);">
                            <img src='../Home/Room/Images/page_previous.gif' width='9' height='8' alt="" /></span><span
                                style="padding-left: 10px; cursor: pointer" onclick="BindWinNumber(2);"><img src='../Home/Room/Images/page_next.gif'
                                    width='9' alt="" height='8' /></span> <span style="cursor: pointer" onclick="BindWinNumber(3);">
                                        <img src='../Home/Room/Images/page_last.gif' width='9' alt="" height='8' /></span>
                    </div>
                </div>
                <div id="tdWinLotteryNumber" style="width: 210px; border: solid 1px #BCD2E9; border-top: none;
                    text-align: center; height: 100%; overflow: hidden; margin-bottom: 10px; padding: 4px;">
                    <br />
                    <img src='../Home/Room/Images/londing.gif' alt="" />
                    <br />
                    <br />
                    <br />
                </div>
                <!-- 开奖列表结束-->
                <!-- 资讯开始-->
                <div id="zxdiv">
                    <div runat="server" id="InforMation">
                        <div id="divCaiyouZiXun" style="width: 218px; background-color: #E7F1FA; border: solid 1px #BCD2E9;">
                            <div style="float: left; width: 120px; line-height: 28px; padding-left: 15px; color: #226699">
                                <strong>
                                    <%=InforMationName %></strong>
                            </div>
                        </div>
                        <div id="tbNews" style="width: 218px; border: solid 1px #BCD2E9; border-top: none;
                            height: 100%; overflow: hidden; margin-bottom: 10px;">
                            <br />
                            <img src='../Home/Room/Images/londing.gif' style="position: relative; left: 7%; top: 0px;"
                                alt="" />
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
                <!--显示欧体商家自定义 资讯-->
                <div id="divOTZiXun" style="width: 218px; background-color: #E7F1FA; border: solid 1px #BCD2E9;
                    display: none;">
                    <iframe id="iframeOTZiXun" scrolling="no" frameborder="0" width="100%" height="180"
                        src="#" style="background-color: Black;" scrolling="no"></iframe>
                </div>
                <br />

                <script type="text/javascript" language="javascript">
                    var zx=document.getElementById("zxdiv").innerHTML;
                    var xy=document.getElementById("topxy").innerHTML;
                    if(CheckLotteryID(<%=LotteryID %>))
                    {
                       document.getElementById("topxy").innerHTML=zx;
                       document.getElementById("zxdiv").innerHTML=xy;
                    }
                    try 
                    {

                        var url = window.location.href;
                        if (url.indexOf("lottery.usportnews.com") > 0)//欧体专版首页
                        {
                            var lotteryID = Request("LotteryID");
                            document.getElementById("divCaiyouZiXun").style.display = "none";
                            document.getElementById("tbNews").style.display = "none";
                            document.getElementById("divOTZiXun").style.display = "";
                            if (lotteryID == "5") {
                                document.getElementById('iframeOTZiXun').src = "http://video.usportnews.com/Consultation4.asp";
                            }
                            else if (lotteryID == "6") {
                                document.getElementById('iframeOTZiXun').src = "http://video.usportnews.com/Consultation5.asp";
                            }
                            else if (lotteryID == "39") {
                                document.getElementById('iframeOTZiXun').src = "http://video.usportnews.com/Consultation6.asp";
                            }
                            else if (lotteryID == "63" || lotteryID == "64") {
                                document.getElementById('iframeOTZiXun').src = "http://video.usportnews.com/Consultation7.asp";
                            }
                            else {
                                document.getElementById("InforMation").style.display = "none";
                            }
                            
                        }
                        
                    }
                    catch (ex) { }
                </script>

                <!-- 资讯结束-->
                <!-- 帮助 开始-->
                <div style="width: 220px; background-color: #6699CC;">
                    <div style="width: 100%; line-height: 28px; margin-left: 15px;" class="white14"">
                        <strong>相关信息</strong>
                    </div>
                </div>
                <div style="width: 218px; border: solid 1px #BCD2E9; border-top: none; margin-bottom: 10px;">
                    <div style="text-align: center; padding: 15px 5px 10px 5px;">
                        <div id="divPlayIntroduce" style="background-image: url('../Home/Room/Images/zfb_playIntroduce.jpg');
                            width: 164px; height: 19px; text-align: center; padding-top: 15px; padding-bottom: 15px;
                            padding-left: 40px; cursor: hand;">
                            <a href="../Help/Play_Default.aspx" target="_blank" style="text-decoration: none;
                                cursor: hand;"><span style="font-size: 14px; color: #0066BA; font-family: tahoma;
                                    font-weight: bold;">
                                    <%=LotteryName%>玩法介绍</span> </a>
                        </div>
                    </div>
                    <div id="hr">
                    </div>
                    <table id="NewsList" width="208" cellspacing="0" cellpadding="0" style="margin-left: 10px">
                        <tr>
                            <td width="8%" height="22" class="gray12">
                                <p>
                                    &#9642;</p>
                            </td>
                            <td width="92%" class="gray12">
                                <a href="../Help/Help_Default.aspx" target="_blank">新手入门全过程</a>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="gray12">
                                <p>
                                    &#9642;</p>
                            </td>
                            <td class="gray12">
                                <a href="../Help/help_Account_Security.aspx" target="_blank">账户安全</a>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="gray12">
                                <p>
                                    &#9642;</p>
                            </td>
                            <td class="gray12">
                                <a href="../Help/help_buy_distill.aspx" target="_blank">购彩与提现 </a>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="gray12">
                                <p>
                                    &#9642;</p>
                            </td>
                            <td class="gray12">
                                <a href="../Help/help_Cobuy1.aspx" target="_blank">如何发起合买,参与合买 </a>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="gray12">
                                <p>
                                    &#9642;</p>
                            </td>
                            <td class="gray12">
                                <a href="../Help/help_viewbuy.aspx" target="_blank">查看投注记录</a>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="gray12">
                                <p>
                                    &#9642;</p>
                            </td>
                            <td class="gray12">
                                <a href="../Help/help_account_safe.aspx" target="_blank">方案保密</a>
                            </td>
                        </tr>
                        <tr>
                            <td height="22" class="gray12">
                                <p>
                                    &#9642;</p>
                            </td>
                            <td class="gray12">
                                <a href="../Help/help_FollowFriendScheme.aspx" target="_blank">如何定制跟单</a>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- 帮助 结束-->
                <div style="margin-top: 10px; margin-bottom: 10px;">
                    <a href="Buy_SYYDJ.aspx">
                        <img src="../Home/Room/Images/ad_250_80.gif" width="220" height="80" border="0" /></a>
                </div>
                <!-- 中奖排行榜 开始-->
                <div style="width: 218px; background-color: #E7F1FA; border: solid 1px #BCD2E9; overflow: hidden;">
                    <div style="width: 100%; line-height: 28px; float: left; padding-left: 15px;" class="blue12_1">
                        <strong>中奖排行榜</strong>
                    </div>
                    <%--<div style="width: 50%; line-height: 28px; float: left; background: #BCD2E9" class="blue12_1">
                        <span style="cursor: pointer; padding-left: 15px; font-weight: bold" id="spanWin1"
                            onclick="WinProfit(this)">中奖排行榜</span>
                    </div>
                    <div style="width: 50%; line-height: 28px; float: left" class="blue12_1">
                        <span style="cursor: pointer; padding-left: 15px" id="spanProfit" onclick="WinProfit(this)">
                            盈利排行榜</span>
                    </div>--%>
                </div>
                <div style="width: 210px; border: solid 1px #BCD2E9; border-top: none; height: 100%;
                    overflow: hidden; margin-bottom: 10px; padding: 4px;">
                    <table cellspacing="1" cellpadding="0" style="text-align: center; margin: 1%;" width="98%">
                        <tbody id="tbWin1" runat="server">
                        </tbody>
                        <%-- <tbody id="tbProfit" runat="server" style="display: none">
                        </tbody>--%>
                    </table>
                </div>
                <!-- 中奖排行榜 结束-->
            </div>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    <input id="tbPlayTypeName" name="tbPlayTypeName" type="hidden" value="单式" />
    <input id="tb_LotteryNumber" name="tb_LotteryNumber" type="hidden" />
    <input id="tb_hide_SumMoney" name="tb_hide_SumMoney" type="hidden" />
    <input id="tb_hide_AssureMoney" name="tb_hide_AssureMoney" type="hidden" />
    <input id="tb_hide_SumNum" name="tb_hide_SumNum" type="hidden" />
    <input id="HidMaxTimes" name="HidMaxTimes" type="hidden" value="1000" />
    <input id="HidLotteryID" name="HidLotteryID" type="hidden" value="<%=LotteryID %>" />
    <input id="HidPrice" name="HidPrice" type="hidden" value="2" />
    <input id="tb_hide_ChaseBuyedMoney" name="tb_hide_ChaseBuyedMoney" type="hidden" />
    <asp:HiddenField ID="HidSchemeUpload" runat="server" />
    <asp:HiddenField ID="HidType" runat="server" Value="1" />
    <asp:HiddenField ID="HidLuckNumber" runat="server" />
    <input id="HidSelectedLotteryNumber" name="HidSelectedLotteryNumber" type="hidden" />
    <div style="display: none">
        <asp:Label ID="lbMiss" runat="server"></asp:Label></div>
    </form>
    <!--#includefile="../Html/TrafficStatistics/1.htm"-->
    <!--#includefile="../Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script type="text/javascript">
    //      var sampleDiv = new scrollingAD("divwen");
    //      sampleDiv.width = 218;
    //      sampleDiv.height = 90;
    //      sampleDiv.delay = 100;
    //      sampleDiv.pauseTime = 5000;
    //      sampleDiv.move();
    //      // ]]>
    //      new Marquee({ obj: 'divwen', mode: 'y', speed: 20 });
</script>

<script type="text/javascript">
    var sampleDiv = new scrollingAD("divwen");
    sampleDiv.width = 218;
    sampleDiv.height = 22;
    sampleDiv.delay = 20;
    sampleDiv.pauseTime = 5000;
    sampleDiv.move();
    // ]]>
</script>

<script type="text/javascript">
    
    checkExplorerAndTip();
    
    <%=LotteryPlayTypesPages[LotteryID] %>
   
    setTimeout("Page_load(<%= LotteryID %>);",500);
    PageEvent(<%=LotteryID %>);
    <%=DZ %>
    
</script>

<%= script %>