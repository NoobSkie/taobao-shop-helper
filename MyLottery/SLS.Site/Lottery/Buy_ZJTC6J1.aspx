<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buy_ZJTC6J1.aspx.cs" Inherits="SLS.Site.Lottery.Buy_ZJTC6J1" %>

<%@ Register Src="~/Home/Room/UserControls/UserMyIcaile.ascx" TagName="UserMyIcaile" TagPrefix="uc2" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Src="~/Home/Room/UserControls/Lotteries.ascx" TagName="Lotteries" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 <%= _Site.Url %>//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-<%= _Site.Url %>.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>浙江体彩6+1投注、合买、玩法介绍－<%=_Site.Name %></title>
    <meta name="keywords" content="浙江体彩6+1选号投注、浙江体彩6+1合买、浙江体彩6+1玩法介绍" />
    <meta name="description" content="<%=_Site.Name %>提供浙江体彩6+1选号投注、合买、玩法介绍等服务。" />
    
    <link href="~/Home/Room/Style/css.css" rel="stylesheet" type="text/css" />
    <link href="~/Home/Room/Style/Buy_SSL.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../Home/Room/JavaScript/Public.js"></script>
    <script src="~/Home/Room/JavaScript/buy_ZJTC6J1.js" type="text/javascript"></script>
    <script src="~/Home/Room/JavaScript/ExplorerCheck.js" type="text/javascript"></script>  
     <link rel="shortcut icon" href="~/favicon.ico" />
</head>

<body onload="showSameHeight();">
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
        <div id="menu_right" style="overflow: hidden;">
            <div id="cz_center">
                <div style="margin-bottom: 10px;">
                    <img src="../Home/Room/Images/cz_banner_ssl.gif" alt="" border="0"/>
                </div>
                <!-- 期信息开始 -->
 <div style="border: #C0DBF9 1px solid; background-image: url(../Home/Room/Images/bg_hui.jpg);
                    background-repeat: repeat-x; background-position: top; background-color: #F9FDFF;
                    margin-bottom: 5px; height: 100%; overflow: hidden;">
                    <div style="float: left; width: 19%; text-align: center;">
                        <img id="LotteryImg" alt="浙江体彩6+1" src="../Home/Room/Images/logo_41.jpg" width="105" height="108" />
                    </div>
                    <div style="float: left; width: 80%; margin-top: 6px;">
                        <div id="lastIsuseInfo" style="line-height: 25px; height: 25px;">
                            <img src='../Home/Room/Images/londing.gif' style="position: relative; left: 25%;" alt="" />
                        </div>
                        <div id="tdLotteryIntroduce" class="hui12" style="padding: 18px 0px 2px 0px;">
                            <h1 class='blue18' style="display:inline; "><%=LotteryName %>：2元赢取￥500万</h1> &nbsp;&nbsp;&nbsp;
                        </div>
                        <div class="black12" style="width: 100%; height: 24px; line-height: 24px;">
                            当期第<span id='currIsuseName' class='red12' style='font-weight: bold;'> 正在加载 </span>期&nbsp;&nbsp;离投注截止还有:&nbsp;&nbsp;<span
                                id='toCurrIsuseEndTime' style='background-color: Black; font-weight: bold; color: #00FF00;
                                padding: 2px; font-size: 13px; font-family: 宋体; text-align: center; border-right: 1px solid red;'>本期已截止投注</span>&nbsp;&nbsp;<br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<span id="currIsuseEndTime"
                                class="black12" style="display: none;"></span>
                        </div>
                    </div>
                </div>
                <!-- 期信息结束 -->
                <!-- 选项卡开始 -->
                <div id="TabMenu" style="margin-top: 15px; border-bottom: #FF6600 2px solid; text-align: center;
                    padding-bottom: 0px; width: 100%;">
                    <div style="float: left; width: 10px;">
                    </div>
                    <div class="redMenu" onclick="newBuy(41);showSameHeight();">
                        选号投注
                    </div>
                    <div style="float: left; width: 2px;">
                    </div>
                    <div class="whiteMenu" onclick="newCoBuy(41);showSameHeight();">
                        参与合买</div>
                    <div style="float: left; width: 2px;">
                    </div>
                    <div class="whiteMenu" onclick="followScheme(41);showSameHeight();">
                        定制跟单</div>
                    <div style="float: left; width: 2px;">
                    </div>
                    <div class="whiteMenu" onclick="schemeAll(41);showSameHeight();">
                        全部方案</div>
                    <div style="float: left; width: 2px;">
                    </div>
                    <div class="whiteMenu1" onclick="playTypeIntroduce(41);showSameHeight();">
                        <strong>玩法介绍</strong></div>
                    
                </div>
                <!-- 选项卡结束 -->
                <div id="divNewBuy">
                    <table width="612" cellspacing="1" cellpadding="0" bgcolor="#C0DBF9" style="margin-top: 10px;">
                        <tbody>
                            <tr id='playTypes'>
                                <td height='30' bgcolor='#F7FCFF' align='center'>
                                    投注方式
                                </td>
                                <td bgcolor='#FFFFFF' style='padding-left: 5px; text-align: left;' onload="showSameHeight()">
                                    <span id='playTypes0'>
                                        <input type='radio' name='playType' id='playType4101' value='4101' checked='checked'
                                            onclick='clickPlayType(this.value)' />单式
                                        <input type='radio' name='playType' id='playType4102' value='4102' onclick='clickPlayType(this.value)' />复式
                                    </span>
                                    <span id="labShowWinMoney" visible="false">
                                    </span>
                                </td>
                            </tr>
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
                                                    <td style="width: 20%;">
                                                        期号
                                                    </td>
                                                    <td style="width: 13%;">
                                                        投注倍数
                                                    </td>
                                                    <td style="width: 14%;">
                                                        购买金额
                                                    </td>
                                                    <td style="width: 12%;">
                                                        总份数
                                                    </td>
                                                    <td style="width: 13%;">
                                                        认购份数
                                                    </td>
                                                    <td style="width: 15%;">
                                                        保底份数
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
                                    共追号<span id="spanChaseIsuseCount"  style="color: red;">0</span>期，任务总金额<span id="LbSumMoney" style="color: red;">0.00</span>&nbsp;元，认购和保底金额<span
                                        id="LbChaseMoney" style="color: red;">0.00</span>元；<br/>如最后一期中出，奖金总额<span id="spanWinMoney" style="color:Red">0.00</span>元，方案盈利<span id="spanSchemeProfit" style="color:Red">0.00</span>元，投资回报率<span id="spanFJL" style="color:Red"></span>倍
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    佣金比率
                                </td>
                                <td align="left">
                                    <input type="text" onkeypress="return InputMask_Number();" id="tb_SchemeBonusScalec"
                                        name="tb_SchemeBonusScalec" onblur="return SchemeBonusScalec();" style="width: 56px;"
                                        maxlength="10" value="0" />% &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;佣金比例只能为0~10。
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
                        <tr>
                            <td height="30" colspan="2" bgcolor="#F7F7F7" align="center" style="padding-bottom: 20px;
                                padding-top: 20px">
                                <ShoveWebUI:ShoveConfirmButton ID="btn_OK" Style="cursor: pointer;" runat="server"
                                    Width="170px" Height="32px" CausesValidation="False" BackgroupImage="../Home/Room/Images/zfb_bt_touzhu.jpg"
                                    BorderStyle="None" OnClientClick="return CreateLogin('btn_OKClick();');" OnClick="btn_OK_Click" />
                                <asp:CheckBox ID="chkAgrrement" runat="server" Checked="true" />
                                我已经阅读并同意 <span class="blue12">
                                    <asp:HyperLink runat="server" ID="hlAgreement" NavigateUrl="../Home/Room/BuyProtocol.aspx?LotteryID=41"
                                        Target="_blank">《用户电话短信投注协议》</asp:HyperLink></span>
                                       
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
                        <img src='../Home/Room/Images/londing.gif' style="position: relative; top: 10%; left: 40%;" alt="" />
                    </div>
                    <iframe id="iframeSchemeAll" name="iframeSchemeAll" width="100%" frameborder="0"
                        scrolling="no" onload="$Id('iframeSchemeAll').style.display ='';document.getElementById('divLoding').style.display='none';document.getElementById('iframeSchemeAll').style.height=iframeSchemeAll.document.body.scrollHeight;showSameHeight();">
                    </iframe>
                </div>
                <div id="divPlayTypeIntroduce" style="display: none;">
                    <iframe id="iframe1" name="iframePlayTypeIntroduce" width="100%" frameborder="0"
                        scrolling="no" onload="document.getElementById('iframePlayTypeIntroduce').style.height=iframePlayTypeIntroduce.document.body.scrollHeight;showSameHeight();">
                    </iframe>
                </div>
            </div>
            <div id="cz_right">
                <!-- 资讯开始-->
                <div id="divCaiyouZiXun" style="width: 218px; background-color: #E7F1FA; border: solid 1px #BCD2E9;">
                    <div style="float: left; width: 120px; line-height: 28px; padding-left: 15px;" class="blue12_1">
                        <strong>浙江体彩6+1资讯</strong>
                    </div>
                  
                </div>
                <div id="tbNews" style="width: 210px; border: solid 1px #BCD2E9; border-top: none;
                    height: 100%; overflow: hidden; margin-bottom: 10px; padding: 4px;">
                    <br />
                    <img src='../Home/Room/Images/londing.gif' style="position: relative; left: 15%;" alt="" />
                    <br />
                    
                </div>
                <!--显示欧体商家自定义浙江体彩6+1资讯-->
                <div id="divOTZiXun" style="width: 218px;background-color: #E7F1FA; border: solid 1px #BCD2E9; display:none;">
                        <iframe id="iframeOTZiXun" scrolling="no" frameborder="0"  width="100%"  height="180"; src="#" style="background-color:Black; " scrolling="no" >
                        </iframe>
                        <br />
                 </div>
                <script type="text/javascript" language="javascript">
                    try {

                        var url = window.location.href;
                        if (url.indexOf("lottery.usportnews.com") > 0)//欧体专版首页
                        {
                            document.getElementById("divCaiyouZiXun").style.display = "none";
                            document.getElementById("tbNews").style.display = "none";
                            document.getElementById("divOTZiXun").style.display = "";
                            document.getElementById('iframeOTZiXun').src = "http://video.usportnews.com/Consultation1.asp";
                        }
                    }
                    catch (ex) { }
                </script>
                <!-- 资讯结束-->
                <!-- 开奖列表开始-->
                <div style="width: 218px; background-color: #E7F1FA; border: solid 1px #BCD2E9;">
                    <div style="float: left; width: 140px; line-height: 28px; padding-left: 15px;" class="blue12_1">
                        <strong>开奖号码</strong>
                    </div>
                    <div style="float: left; width: 60px; margin-top: 7px; text-align: right;" class="hui12">
                        <span style="cursor: pointer" onclick="BindWinNumber(0);">
                            <img src='../Home/Room/Images/page_first.gif' width='9' alt="" height='8' /></span> <span style="cursor: pointer"
                                onclick="BindWinNumber(1);">
                                <img src='../Home/Room/Images/page_previous.gif' width='9' height='8' alt="" /></span><span style="padding-left: 10px;
                                    cursor: pointer" onclick="BindWinNumber(2);"><img src='../Home/Room/Images/page_next.gif' width='9'
                                        alt="" height='8' /></span> <span style="cursor: pointer" onclick="BindWinNumber(3);">
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
                <div style="margin-top: 10px; margin-bottom: 10px;">
                    
                        <img src="../Home/Room/Images/ad_250_80.gif" alt="浙江体彩6+1代购/合买" width="220" height="80" border="0" />
                </div>
                 <!-- 中奖排行榜 开始-->
                <div style="width: 218px; background-color: #E7F1FA; border: solid 1px #BCD2E9; overflow: hidden;">
                    <div style="width: 100%; line-height: 28px; float: left;padding-left: 15px;" class="blue12_1">
                        <strong>中奖排行榜</strong>
                    </div>
                   
                </div>
                <div style="width: 210px; border: solid 1px #BCD2E9; border-top: none; height: 100%;
                    overflow: hidden; margin-bottom: 10px; padding: 4px;">
                    <table cellspacing="1" cellpadding="0" style="text-align: center; margin: 1%;" width="98%">
                        <tbody id="tbWin1" runat="server">
                        </tbody>
                      
                    </table>
                </div>
                <!-- 中奖排行榜 结束-->
            </div>
        </div>
    </div>
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    <input id="tbPlayTypeName" name="tbPlayTypeName" type="hidden" value="直选单式" />
    <input id="tb_LotteryNumber" name="tb_LotteryNumber" type="hidden" />
    <input id="tb_SchemeFileName" name="tb_SchemeFileName" type="hidden" />
    <input id="tb_hide_SumMoney" name="tb_hide_SumMoney" type="hidden" />
    <input id="tb_hide_ChaseBuyedMoney" name="tb_hide_ChaseBuyedMoney" type="hidden" />
    <input id="tb_hide_AssureMoney" name="tb_hide_AssureMoney" type="hidden" />
    <input id="tb_hide_SumNum" name="tb_hide_SumNum" type="hidden" />
    <input id="HidMaxTimes" name="HidMaxTimes" type="hidden" value="1000" />
    <input id="HidLotteryID" name="HidLotteryID" type="hidden" value="41" />
    <input id="HidSelectedLotteryNumber" name="HidSelectedLotteryNumber" type="hidden" />
    
    </form>
</body>
</html>

<script type="text/javascript">

    setTimeout("Page_load();",500);
    PageEvent();
    <%=DZ %>
    
</script>

<%=script %>
