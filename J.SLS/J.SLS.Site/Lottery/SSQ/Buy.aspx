<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WithTopLotteryMenu.master"
    AutoEventWireup="true" CodeFile="Buy.aspx.cs" Inherits="Lottery_SSQ_Buy" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="../../JavaScript/Lottery/ExplorerCheck.js"></script>

    <script src="../../JavaScript/Lottery/Public.js" type="text/javascript"></script>

    <script src="../../JavaScript/Lottery/buy_SSQ.js" type="text/javascript"></script>

    <link href="../../CSS/BuyLottery.css" rel="stylesheet" type="text/css" />

    <script src="../../JavaScript/Lottery/Marquee.js" type="text/javascript"></script>

    <link rel="shortcut icon" href="../../favicon.ico" />
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
                        当期第<span id="currIsuseName" style="font-weight: bold; color: #fe8625;"></span>期&nbsp;&nbsp;投注截止时间：<span
                            id="currIsuseEndTime" style="background-color: Red; color: White; font-weight: bold;"></span>&nbsp;&nbsp;离投注截止还有：<span
                                id="toCurrIsuseEndTime" style="background-color: Red; color: White; font-weight: bold;"></span></div>
                    <span id="currIsuseEndTime11" class="black12" style="display: none;"></span>
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
            <div style="float: left; width: 2px; display: none;">
            </div>
            <div class="whiteMenu" onclick="GotoCoBuy();" style="display: none;">
                参与合买</div>
            <div style="float: left; width: 2px; display: none;">
            </div>
            <div class="whiteMenu" onclick="GotoFollowScheme();" style="display: none;">
                定制跟单</div>
            <div style="float: left; width: 2px; display: none;">
            </div>
            <div class="whiteMenu" onclick="GotoSchemeAll();" style="display: none;">
                全部方案</div>
            <div style="float: left; width: 2px;">
            </div>
            <div class="whiteMenu1" onclick="GotoPlayIntroduce();">
                <strong>玩法介绍</strong></div>
        </div>
        <!-- 选项卡结束 -->
        <div id="divNewBuy" style="clear: both;">
            <table border="0" cellpadding="0" cellspacing="0" width="650" style="border-bottom: #fe8625 1px solid;
                border-left: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                <tbody>
                    <tr>
                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" width="90"
                            height="45" align="center" bgcolor="#fef4d1">
                            选择玩法
                        </td>
                        <td style="border-bottom: #fe8625 1px solid;" bgcolor="#fef4d1">
                            <input type='radio' name='playType' id='playType501' value='501' checked='checked'
                                onclick='clickPlayType(this.value)' />
                            <label for="playType501">
                                单式</label>
                            <input type='radio' name='playType' id='playType502' value='502' onclick='clickPlayType(this.value)' />
                            <label for="playType502">
                                复式</label>
                            <input type='radio' name='playType' id='playType503' value='503' onclick='clickPlayType(this.value)' />
                            <label for="playType503">
                                胆拖</label>
                            <input type='radio' name='playType' id='playType504' value='504' onclick='clickPlayType(this.value)' /><span
                                class='blue12'><label for="playType504">智能机选</label></span>
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
        <div id="divPlayTypeIntroduce" style="display: none;">
            <iframe id="iframePlayTypeIntroduce" name="iframePlayTypeIntroduce" width="100%"
                frameborder="0" scrolling="no" onload="document.getElementById('iframePlayTypeIntroduce').style.height=iframePlayTypeIntroduce.document.body.scrollHeight;showSameHeight();">
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

    <script type="text/javascript">

    checkExplorerAndTip();
   
    setTimeout("Page_load(<%= LotteryId %>);",500);
    PageEvent(<%= LotteryId %>);

        function GetBtnOKId() {
            return "<%= btn_OK.ClientID %>";
        }

        function GetBtnOKName() {
            return "<%= btn_OK.UniqueID %>";
        }

        function GetCheckAgreementId() {
            return "<%= chkAgrrement.ClientID %>";
        }

        function GetHidIsuseID() {
            return "<%= HidIsuseID.ClientID %>";
        }

        function GetHidIsuseEndTime() {
            return "<%= HidIsuseEndTime.ClientID %>";
        }
        
    </script>

</asp:Content>
