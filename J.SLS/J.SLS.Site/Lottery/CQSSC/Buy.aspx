<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WithTopLotteryMenu.master"
    AutoEventWireup="true" CodeFile="Buy.aspx.cs" Inherits="Lottery_CQSSC_Buy" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../CSS/BuyLottery.css" rel="stylesheet" type="text/css" />

    <script src="../../JavaScript/Lottery/JScript.js" type="text/javascript"></script>

    <script src="../../JavaScript/Lottery/Public.js" type="text/javascript"></script>

    <script src="../../JavaScript/Lottery/buy_CQSSC.js" type="text/javascript"></script>

    <script type="text/javascript">

        function GotoNewBuy() {
            newBuy('<%= LotteryId %>');
            showSameHeight();
        }

        function GotoCoBuy() {
            newCoBuy('<%= LotteryId %>', '');
            showSameHeight();
        }

        function GotoFollowScheme() {
            followScheme('<%= LotteryId %>');
            showSameHeight();
        }

        function GotoSchemeAll() {
            schemeAll('<%= LotteryId %>', '');
            showSameHeight();
        }

        function GotoPlayIntroduce() {
            playTypeIntroduce('<%= LotteryCode %>');
            showSameHeight();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <input id="tbPlayTypeID" name="tbPlayTypeID" type="hidden" />
    <asp:HiddenField ID="HidIsuseEndTime" runat="server" />
    <asp:HiddenField ID="HidIsuseID" runat="server" />
    <div class="center">
        <div style="margin: 15px auto;">
            您好！&nbsp;faacai&nbsp;&nbsp;&nbsp;&nbsp;您的余额：<strong class="red">￥888.00</strong>
            元&nbsp;&nbsp;&nbsp;&nbsp;积分：<strong class="red">888</strong><a href="#">中奖查询</a><a
                href="#" class="red">充值</a><a href="#">提现</a><a href="#">我的658</a><asp:HyperLink
                    ID="hlnkLogout" NavigateUrl="~/Users/Logout.aspx" runat="server">安全退出</asp:HyperLink></div>
        <!-- 期信息开始 -->
        <div style="border: #C0DBF9 1px solid; background-image: url(../images/l.jpg); background-repeat: repeat-x;
            background-position: top; margin-bottom: 5px; height: 100%; overflow: hidden;">
            <div style="float: left; width: 19%; text-align: center; vertical-align: middle;
                height: 100%; overflow: hidden;">
                <asp:Image ID="LotteryImg" ImageUrl="~/Images/22_5.gif" runat="server" AlternateText="时时彩"
                    Width="105" Height="108" />
            </div>
            <div style="float: left; width: 80%; margin-top: 6px;">
                <div>
                    <div>
                        <div style="float: left; height: 28px; line-height: 28px; font-size: 14px; font-weight: bold;">
                            20100024期开奖：</div>
                        <div class="Ball">
                            07</div>
                        <div class="Ball">
                            16</div>
                        <div class="Ball">
                            26</div>
                        <div class="Ball">
                            27</div>
                        <div class="Ball">
                            29</div>
                    </div>
                    <div style="clear: left; height: 48px; line-height: 48px;">
                        <span style="font-size: 18px; font-weight: bold; color: Blue;">重庆时时彩：2元赢取10万元</span>
                        每周一、三、六开奖</div>
                    <div>
                        当期第<span style="font-weight: bold; color: #fe8625;">20100024</span>期&nbsp;&nbsp;投注截止时间：2010-03-08
                        19：27：00&nbsp;&nbsp;离投注截止还有：<span id="toCurrIsuseEndTime" style="background-color: Red;
                            color: White; font-weight: bold;">01时48分21秒</span></div>
                    <span id="currIsuseEndTime" class="black12" style="display: none;"></span>
                    <div style="height: 24px; line-height: 24px;">
                        <a href="DataBehaviour.aspx" class="red">时时彩走势图</a> <a href="DrawaLotteryInfo.aspx"
                            class="red">时时彩中奖查询</a></div>
                </div>
            </div>
        </div>
        <!-- 期信息结束 -->
        <!-- 选项卡开始 -->
        <div id="TabMenu" style="margin-top: 15px; border-bottom: #FF6600 2px solid; text-align: center;
            padding-bottom: 0px; width: 100%;">
            <div style="float: left; width: 10px;">
            </div>
            <div class="redMenu" onclick="GotoNewBuy();">
                选号投注
            </div>
            <div style="float: left; width: 2px;">
            </div>
            <div class="whiteMenu" onclick="GotoCoBuy();">
                参与合买</div>
            <div style="float: left; width: 2px;">
            </div>
            <div class="whiteMenu" onclick="GotoFollowScheme();">
                定制跟单</div>
            <div style="float: left; width: 2px;">
            </div>
            <div class="whiteMenu" onclick="GotoSchemeAll();">
                全部方案</div>
            <div style="float: left; width: 2px;">
            </div>
            <div class="whiteMenu1" onclick="GotoPlayIntroduce();">
                <strong>玩法介绍</strong></div>
        </div>
        <!-- 选项卡结束 -->
        <div id="divNewBuy">
            <table border="0" cellpadding="0" cellspacing="0" width="650" style="border-bottom: #fe8625 1px solid;
                border-left: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                <tbody>
                    <tr>
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" width="90"
                            height="45" align="center" bgcolor="#fef4d1">
                            选择玩法
                        </td>
                        <td style="border-bottom: #fe8625 1px solid;" bgcolor="#fef4d1">
                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                margin-left: 15px; float: left; padding: 0 10px; background-image: url(images/b.jpg);">
                                <a href="javascript:void(0);" onclick='clickPlayClass(0,this);showSameHeight();SelectXing(0)'>
                                    五星</a></div>
                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                margin-left: 15px; float: left; padding: 0 10px;">
                                <a href="javascript:void(0);" onclick='clickPlayClass(1,this);showSameHeight();SelectXing(1)'>
                                    三星</a></div>
                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                margin-left: 15px; float: left; padding: 0 10px;">
                                <a href="javascript:void(0);" onclick='clickPlayClass(2,this);showSameHeight();SelectXing(2)'>
                                    二星</a></div>
                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                margin-left: 15px; float: left; padding: 0 10px;">
                                <a href="javascript:void(0);" onclick='clickPlayClass(3,this);showSameHeight();SelectXing(3)'>
                                    一星</a></div>
                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                margin-left: 15px; float: left; padding: 0 10px;">
                                <a href="javascript:void(0);" onclick='clickPlayClass(4,this);showSameHeight();SelectXing(4)'>
                                    大小单双</a></div>
                        </td>
                    </tr>
                    <tr id='playTypes'>
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" height="45"
                            align="center" bgcolor="#fef4d1">
                            投注方式
                        </td>
                        <td style="border-bottom: #fe8625 1px solid;" onload="showSameHeight()">
                            <span id='playTypes0'>
                                <input type='radio' name='playType' id='playType2801' value='2801' checked='checked'
                                    onclick='clickPlayType(this.id)' /><label for="playType2801">单式</label>
                                <input type='radio' name='playType' id='playType2802' value='2802' onclick='clickPlayType(this.id)' /><label
                                    for="playType2802">复选</label>
                                <input type='radio' name='playType' id='playType2803' value='2803' onclick='clickPlayType(this.id)' /><label
                                    for="playType2803">组合</label>
                                &nbsp;&nbsp;&nbsp; <font style="font-weight: bolder">通选:</font>
                                <input type='radio' name='playType' id='playType2804' value='2805' onclick='clickPlayType(this.id)' /><label
                                    for="playType2804">单式</label>
                                <input type='radio' name='playType' id='playType2805' value='2806' onclick='clickPlayType(this.id)' /><label
                                    for="playType2805">复式</label>
                            </span><span id='playTypes1' style='display: none;'>
                                <input type='radio' name='playType' id='playType2806' value='2801' onclick='clickPlayType(this.id)' /><label
                                    for="playType2806">单式</label>
                                <input type='radio' name='playType' id='playType2807' value='2802' onclick='clickPlayType(this.id)' /><label
                                    for="playType2807">复选</label>
                                <input type='radio' name='playType' id='playType2808' value='2803' onclick='clickPlayType(this.id)' /><label
                                    for="playType2808">组合</label>
                                &nbsp;&nbsp;&nbsp; <font style="font-weight: bolder">组三:</font>
                                <input id="playType2809" name="playType" type="radio" value="2813" onclick="clickPlayType(this.id)" /><label
                                    for="playType2809">单式</label>
                                <input id="playType2810" name="playType" type="radio" value="2814" onclick="clickPlayType(this.id)" /><label
                                    for="playType2810">复式</label>
                                &nbsp;&nbsp;&nbsp; <font style="font-weight: bolder">组六:</font>
                                <input id="playType2811" name="playType" type="radio" value="2815" onclick="clickPlayType(this.id)" /><label
                                    for="playType2811">单式</label>
                                <input id="playType2812" name="playType" type="radio" value="2816" onclick="clickPlayType(this.id)" /><label
                                    for="playType2812">复式</label>
                            </span><span id='playTypes2' style='display: none;'>
                                <input type='radio' name='playType' id='playType2813' value='2801' onclick='clickPlayType(this.id)' /><label
                                    for="playType2813">单式</label>
                                <input type='radio' name='playType' id='playType2814' value='2802' onclick='clickPlayType(this.id)' /><label
                                    for="playType2814">复选</label>
                                <input type='radio' name='playType' id='playType2815' value='2803' onclick='clickPlayType(this.id)' /><label
                                    for="playType2815">组合</label>
                                &nbsp;&nbsp;&nbsp; <font style="font-weight: bolder">组选:</font>
                                <input type='radio' name='playType' id='playType2816' value='2807' onclick='clickPlayType(this.id)' /><label
                                    for="playType2816">单式</label>
                                <input type='radio' name='playType' id='playType2817' value='2808' onclick='clickPlayType(this.id)' /><label
                                    for="playType2817">复式</label>
                                <input type='radio' name='playType' id='playType2818' value='2810' onclick='clickPlayType(this.id)' /><label
                                    for="playType2818">包点</label>
                                <input type='radio' name='playType' id='playType2819' value='2811' onclick='clickPlayType(this.id)' /><label
                                    for="playType2819">包胆</label>
                            </span><span id='playTypes3' style='display: none;'>
                                <input type='radio' name='playType' id='playType2820' value='2801' onclick='clickPlayType(this.id)' /><label
                                    for="playType2820">单式</label>
                                <input type='radio' name='playType' id='playType2821' value='2803' onclick='clickPlayType(this.id)' /><label
                                    for="playType2821">组合</label>
                            </span><span id='playTypes4' style='display: none;'>
                                <input type='radio' name='playType' id='playType2822' value='2804' onclick='clickPlayType(this.id)' /><label
                                    for="playType2822">复式</label>
                            </span>
                            <label id="labShowWinMoney">
                            </label>
                        </td>
                    </tr>
                </tbody>
                <tr>
                    <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" align="center"
                        bgcolor="#f7b809">
                        选号
                    </td>
                    <td valign="top" style="border-bottom: #fe8625 1px solid;" align="center">
                        <iframe id="iframe_playtypes" name="iframe_playtypes" width="100%" frameborder="0"
                            scrolling="no" onload="document.getElementById('iframe_playtypes').style.height=iframe_playtypes.document.body.scrollHeight;showSameHeight();">
                        </iframe>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" align="center"
                        bgcolor="#ffdf6e">
                        投注内容
                    </td>
                    <td style="border-bottom: #fe8625 1px solid; padding: 15px;">
                        <table border="0" cellpadding="0" cellspacing="0" style="border-bottom: #fe8625 3px solid;
                            border-left: #fe8625 3px solid; border-top: #fe8625 3px solid; border-right: #fe8625 3px solid;
                            padding: 15px;">
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
                        <table border="0" cellpadding="0" cellspacing="0" style="border-bottom: #fe8625 1px solid;
                            border-left: #fe8625 1px solid; border-top: #fe8625 1px solid; border-right: #fe8625 1px solid;
                            padding: 15px; margin-top: 15px; background-color: #fef4d1" width="100%">
                            <tr>
                                <td>
                                    您选择了<span class="red" id="lab_Num">0</span>注，倍数：<input type="text" onkeypress="return InputMask_Number();"
                                        id="tb_Multiple" name="tb_Multiple" onblur="CheckMultiple();" value="1" maxlength="3"
                                        style="width: 30px;" />总金额<span class="red" id="lab_SumMoney">0.00</span>元。<span
                                            class="red" style="font-weight: bold">[注]</span>投注倍数最高为999倍。
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" height="45"
                        align="center" bgcolor="#f7b809">
                        合买代购
                    </td>
                    <td style="border-bottom: #fe8625 1px solid; color: Red;" bgcolor="#fef4d1">
                        <div id="DivBuy" style="float: left;">
                            <input id="CoBuy" name="CoBuy" type="checkbox" onclick="oncbInitiateTypeClick(this);"
                                value="2" /><label for="CoBuy">我要发起合买方案</label>
                        </div>
                        <div id="DivChase" style="float: left;">
                            <input id="Chase" name="Chase" type="checkbox" onclick="oncbInitiateTypeClick(this);"
                                value="1" /><label for="Chase">我要追号</label>
                        </div>
                    </td>
                </tr>
                <tbody id="trShowJion" style="display: none; line-height: 2; height: 36px; background-color: #fef4d1;
                    text-align: center; padding-left: 10px; padding-right: 10px;">
                    <tr>
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                            佣金比率
                        </td>
                        <td align="left" style="border-bottom: #fe8625 1px solid;">
                            <input type="text" onkeypress="return InputMask_Number();" id="tb_SchemeBonusScale"
                                name="tb_SchemeBonusScale" onblur="return SchemeBonusScale();" style="width: 56px;"
                                maxlength="10" />% &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;佣金比例只能为0~10。
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                            我要分成
                        </td>
                        <td align="left" style="border-bottom: #fe8625 1px solid;">
                            <input type="text" onkeypress="return InputMask_Number();" id="tb_Share" name="tb_Share"
                                onblur="return CheckShare();" style="width: 56px;" maxlength="10" value="1" />份，每份
                            <span id="lab_ShareMoney" style="color: Red">0.00</span>&nbsp;元。&nbsp;&nbsp; <font
                                color="#ff0000">【注】</font>份数不能为空，且能整除总金额。
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                            我要认购
                        </td>
                        <td align="left" style="border-bottom: #fe8625 1px solid;">
                            <input type="text" onkeypress="return InputMask_Number();" id="tb_BuyShare" name="tb_BuyShare"
                                onblur="return CheckBuyShare();" style="width: 56px;" value="1" />份，金额 <span id="lab_BuyMoney"
                                    style="color: Red">0.00</span>&nbsp;元。
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                            我要保底
                        </td>
                        <td align="left" style="border-bottom: #fe8625 1px solid;">
                            <input type="text" onkeypress="return InputMask_Number();" id="tb_AssureShare" name="tb_AssureShare"
                                onblur="return CheckAssureShare();" style="width: 56px;" value="0">份，保底 <span id="lab_AssureMoney"
                                    style="color: Red">0.00</span>&nbsp;元。&nbsp; <font color="#ff0000">【注】</font>保底资金将被暂时冻结,在当期截止销售时、或根据此方案的销售、撤单情况,冻结资金将返还到您的电话投注卡账户中。
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                            招股对象
                        </td>
                        <td align="left" style="border-bottom: #fe8625 1px solid;">
                            <input type="text" id="tb_OpenUserList" name="tb_OpenUserList" style="width: 99%;"
                                maxlength="4000" /><br />
                            <font color="#ff0000">【注】</font>您可以选择一些用户作为招股对象，用户名之间用 , 隔开。<br />
                            如：icaile,中个500万,双色球高手,...填写错误的用户名、格式不正确、或者没有填写则表示向全部会员招股。
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                            方案标题
                        </td>
                        <td align="left" style="border-bottom: #fe8625 1px solid;">
                            <input type="text" id="tb_Title" name="tb_Title" style="width: 99%;" maxlength="50" /><font
                                color="#ff0000">【注】</font>标题不能为空,长度不能超过 <font color="#ff0000">50</font> 个字符。
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                            方案描述
                        </td>
                        <td align="left" style="padding: 10px; border-bottom: #fe8625 1px solid;">
                            <textarea id="tb_Description" name="tb_Description" style="width: 99%; height: 100px;"></textarea>
                        </td>
                    </tr>
                </tbody>
                <tbody id="trGoon" style="display: none; line-height: 2; height: 36px; background-color: #fef4d1;
                    text-align: center; padding-left: 10px; padding-right: 10px;">
                    <tr>
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                            追号期间
                        </td>
                        <td align="left" style="padding: 10px; border-bottom: #fe8625 1px solid;">
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
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                            追号金额
                        </td>
                        <td align="left" style="border-bottom: #fe8625 1px solid;">
                            共追号<span id="spanChaseIsuseCount" style="color: red;">0</span>期，任务总金额<span id="LbSumMoney"
                                style="color: red;">0.00</span>&nbsp;元，认购和保底金额<span id="LbChaseMoney" style="color: red;">0.00</span>元；<br />
                            如最后一期中出，奖金总额<span id="spanWinMoney" style="color: Red">0.00</span>元，方案盈利<span id="spanSchemeProfit"
                                style="color: Red">0.00</span>元，投资回报率<span id="spanFJL" style="color: Red"></span>倍
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                            佣金比率
                        </td>
                        <td align="left" style="display: none; border-bottom: #fe8625 1px solid;">
                            <input type="text" onkeypress="return InputMask_Number();" id="tb_SchemeBonusScalec"
                                name="tb_SchemeBonusScalec" onblur="return SchemeBonusScalec();" style="width: 56px;"
                                maxlength="10" value="0" />% &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;佣金比例只能为0~10。
                        </td>
                    </tr>
                    <tr>
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                            自动停止
                        </td>
                        <td align="left" style="border-bottom: #fe8625 1px solid;">
                            当追号任务某期中奖金额达到
                            <input type="text" id="tbAutoStopAtWinMoney" name="tbAutoStopAtWinMoney" maxlength="4"
                                onkeypress="return InputMask_Number();" value="1" style="width: 60px;" />
                            元时，系统<span style="color: #ff0000">中奖后自动停止</span>此追号任务。为<span style="color: #ff0000">&nbsp;0&nbsp;</span>时表示不启动自动终止功能。
                        </td>
                    </tr>
                </tbody>
                <tr>
                    <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" height="45"
                        align="center" bgcolor="#ffdf6e">
                        方案保密
                    </td>
                    <td style="border-bottom: #fe8625 1px solid;">
                        <input type="radio" name="SecrecyLevel" id="SecrecyLevel0" value="0" checked="checked" />
                        <label for="SecrecyLevel0">
                            不保密</label>
                        <input type="radio" name="SecrecyLevel" id="SecrecyLevel1" value="1" />
                        <label for="SecrecyLevel1">
                            保密到截止</label>
                        <input type="radio" name="SecrecyLevel" id="SecrecyLevel2" value="2" />
                        <label for="SecrecyLevel2">
                            保密到开奖</label>
                        <input type="radio" name="SecrecyLevel" id="SecrecyLevel3" value="3" />
                        <label for="SecrecyLevel3">
                            永久保密</label>
                    </td>
                </tr>
                <tr>
                    <td height="30" colspan="2" bgcolor="#F7F7F7" align="center" style="padding-bottom: 20px;
                        padding-top: 20px">
                        <ShoveWebUI:ShoveConfirmButton ID="btn_OK" Style="cursor: pointer;" runat="server"
                            Width="170px" Height="32px" CausesValidation="False" BackgroupImage="../../Images/b4.jpg"
                            BorderStyle="None" OnClientClick="return CreateLogin('btn_OKClick();');" OnClick="btn_OK_Click" />
                        <asp:CheckBox ID="chkAgrrement" runat="server" Checked="true" />
                        我已经阅读并同意 <span class="blue12">
                            <asp:HyperLink runat="server" ID="hlAgreement" NavigateUrl="../Home/Room/BuyProtocol.aspx?LotteryID=28"
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
                <img src='../Home/Room/Images/londing.gif' style="position: relative; top: 10%; left: 40%;"
                    alt="" />
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
    <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
    <input id="tbPlayTypeName" name="tbPlayTypeName" type="hidden" value="单式" />
    <input id="tb_LotteryNumber" name="tb_LotteryNumber" type="hidden" />
    <input id="tb_SchemeFileName" name="tb_SchemeFileName" type="hidden" />
    <input id="tb_hide_SumMoney" name="tb_hide_SumMoney" type="hidden" />
    <input id="tb_hide_ChaseBuyedMoney" name="tb_hide_ChaseBuyedMoney" type="hidden" />
    <input id="tb_hide_AssureMoney" name="tb_hide_AssureMoney" type="hidden" />
    <input id="tb_hide_SumNum" name="tb_hide_SumNum" type="hidden" />
    <input id="HidMaxTimes" name="HidMaxTimes" type="hidden" value="1000" />
    <input id="HidLotteryID" name="HidLotteryID" type="hidden" value="28" />
    <button title="Test" onclick="alert('1');Page_load();alert('2');">Test
    </button>

    <script type="text/javascript">

        window.onload = showSameHeight;
        Page_load();
        PageEvent();

        function GetBtnOKId() {
            return "<%= btn_OK.ClientID %>";
        }

        function GetCheckAgreementId() {
            return "<%= chkAgrrement.ClientID %>";
        }
    </script>

</asp:Content>
