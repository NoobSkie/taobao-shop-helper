<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WithTopLotteryMenu.master"
    AutoEventWireup="true" CodeFile="Buy.aspx.cs" Inherits="Lottery_SHSSL_Buy" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Src="../../Components/WebControls/CtrlInnerUserInfo.ascx" TagName="CtrlInnerUserInfo"
    TagPrefix="uc1" %>
<%@ Register Src="../../Components/WebControls/CtrlInnerLogin.ascx" TagName="CtrlInnerLogin"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="../../JavaScript/Lottery/ExplorerCheck.js"></script>

    <script type="text/javascript" src="../../JavaScript/Lottery/Public.js"></script>

    <script type="text/javascript" src="../../JavaScript/Lottery/buy_SSL.js"></script>

    <link type="text/css" href="../../CSS/BuyLottery.css" rel="stylesheet" />

    <script type="text/javascript" src="../../JavaScript/Lottery/Marquee.js"></script>

    <link rel="shortcut icon" href="../../favicon.ico" />

    <script type="text/javascript">

        function CheckAmountNumber(obj) {
            var txt = obj.value;
            if (txt == "") {
                obj.value = "0";
            }
            if (isNaN(txt)) {
                alert("请输入正确的倍数！");
                obj.value = "0";
            }
            var amount = Number(txt);
            if (amount < 0) {
                obj.value = "0";
            }
            if (amount > 999) {
                obj.value = "999";
            }
        }

        function SelectChase(obj, amountId) {
            document.getElementById(amountId).disabled = !obj.checked;
            if (obj.checked) {
                if (document.getElementById(amountId).value == "0") {
                    document.getElementById(amountId).value = "1";
                }
                document.getElementById(amountId).focus();
            }
        }

        function SelectAllChase(obj) {
            var inputList = document.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                if (inputList[i].type == "checkbox" && inputList[i].id.indexOf("_cbGoNumberSelectIssuse") > 0) {
                    if (inputList[i].checked != obj.checked) {
                        inputList[i].click();
                    }
                }
            }
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <input id="tbPlayTypeID" name="tbPlayTypeID" type="hidden" />
    <asp:HiddenField ID="HidIsuseEndTime" runat="server" />
    <asp:HiddenField ID="HidIsuseID" runat="server" />
    <asp:HiddenField ID="HidIsuseNumber" runat="server" />
    <div class="center">
        <uc1:CtrlInnerUserInfo ID="CtrlInnerUserInfo1" runat="server" />
        <uc2:CtrlInnerLogin ID="CtrlInnerLogin1" runat="server" />
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
                            <asp:Label ID="lblPrevInfo" runat="server" Text="20100024期开奖："></asp:Label></div>
                        <div class="Ball">
                            <asp:Label ID="lblNum1" runat="server" Text="27"></asp:Label></div>
                        <div class="Ball">
                            <asp:Label ID="lblNum2" runat="server" Text="27"></asp:Label></div>
                        <div class="Ball">
                            <asp:Label ID="lblNum3" runat="server" Text="27"></asp:Label></div>
                    </div>
                    <div style="clear: left; height: 48px; line-height: 48px;">
                        <span style="font-size: 18px; font-weight: bold; color: Blue;">上海时时乐：2元赢取1000元</span>
                        每30分钟一期，全天23期</div>
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
            padding-bottom: 0px; width: 100%; display: block; overflow: hidden;">
            <div style="float: left; width: 10px;">
            </div>
            <div class="redMenu" onclick="GotoNewBuy();">
                选号投注
            </div>
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
                        <td width='70' style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;"
                            align="center" bgcolor="#f7b809">
                            选择玩法
                        </td>
                        <td style="border-bottom: #fe8625 1px solid;">
                            <table width='100%' cellpadding='0' border='0' cellspacing='0' style='text-align: center;
                                margin-top: 5px;' id='tbPlayTypeMenu29'>
                                <tr>
                                    <td width='10' height='29'>
                                        &nbsp;
                                    </td>
                                    <td class='msplay' onclick='clickPlayClass(0,this);' onmouseover='mOver(this,1)'
                                        onmouseout='mOver(this,2)'>
                                        直选
                                    </td>
                                    <td width='1'>
                                    </td>
                                    <td class='nsplay' onclick='clickPlayClass(1,this);' onmouseover='mOver(this,1)'
                                        onmouseout='mOver(this,2)'>
                                        组选单式
                                    </td>
                                    <td width='1'>
                                    </td>
                                    <td class='nsplay' onclick='clickPlayClass(2,this);' onmouseover='mOver(this,1)'
                                        onmouseout='mOver(this,2)'>
                                        组选6
                                    </td>
                                    <td width='1'>
                                    </td>
                                    <td class='nsplay' onclick='clickPlayClass(3,this);' onmouseover='mOver(this,1)'
                                        onmouseout='mOver(this,2)'>
                                        组选3
                                    </td>
                                    <td width='1'>
                                    </td>
                                    <td class='nsplay' onclick='clickPlayClass(4,this)' onmouseover='mOver(this,1)' onmouseout='mOver(this,2)'>
                                        前一后一
                                    </td>
                                    <td width='1'>
                                    </td>
                                    <td class='nsplay' onclick='clickPlayClass(5,this);' onmouseover='mOver(this,1)'
                                        onmouseout='mOver(this,2)'>
                                        前二后二
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id='playTypes'>
                        <td style="border-bottom: #fe8625 1px solid; height: 36px; border-right: #fe8625 1px solid;"
                            align="center" bgcolor="#f7b809">
                            投注方式
                        </td>
                        <td style="border-bottom: #fe8625 1px solid;">
                            <span id='playTypes0'>
                                <input type='radio' name='playType' id='playType2901' value='2901' checked='checked'
                                    onclick='clickPlayType(this.value)' />直选单式
                                <input type='radio' name='playType' id='playType2902' value='2902' onclick='clickPlayType(this.value)' />直选复式
                            </span><span id='playTypes1' style='display: none;'>
                                <input type='radio' name='playType' id='playType2903' value='2903' onclick='clickPlayType(this.value)' />组选单式
                            </span><span id='playTypes2' style='display: none;'>
                                <input type='radio' name='playType' id='playType2904' value='2904' onclick='clickPlayType(this.value)' />组选6
                            </span><span id='playTypes3' style='display: none;'>
                                <input type='radio' name='playType' id='playType2905' value='2905' onclick='clickPlayType(this.value)' />组选3
                            </span><span id='playTypes4' style='display: none;'>
                                <input type='radio' name='playType' id='playType2912' value='2912' onclick='clickPlayType(this.value)' />前一单式
                                <input type='radio' name='playType' id='playType2913' value='2913' onclick='clickPlayType(this.value)' />前一复式
                                <input type='radio' name='playType' id='playType2914' value='2914' onclick='clickPlayType(this.value)' />后一单式
                                <input type='radio' name='playType' id='playType2915' value='2915' onclick='clickPlayType(this.value)' />后一复式<br />
                            </span><span id='playTypes5' style='display: none;'>
                                <input type='radio' name='playType' id='playType2908' value='2908' onclick='clickPlayType(this.value)' />前二单式
                                <input type='radio' name='playType' id='playType2909' value='2909' onclick='clickPlayType(this.value)' />前二复式
                                <input type='radio' name='playType' id='playType2910' value='2910' onclick='clickPlayType(this.value)' />后二单式
                                <input type='radio' name='playType' id='playType2911' value='2911' onclick='clickPlayType(this.value)' />后二复式<br />
                            </span><span id="labShowWinMoney"></span>
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
                            scrolling="no" onload="document.getElementById('iframe_playtypes').style.height=iframe_playtypes.document.body.scrollHeight;">
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
                    <td style="border-bottom: #fe8625 1px solid; height: 36px; border-right: #fe8625 1px solid;"
                        align="center" bgcolor="#f7b809">
                        追号合买
                    </td>
                    <td valign="top" style="border-bottom: #fe8625 1px solid;" align="center">
                        <asp:CheckBox ID="cbGoNumber" Text="我要追号" runat="server" />
                    </td>
                </tr>
                <tr id="trGoNumberIssuse">
                    <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" align="center"
                        bgcolor="#f7b809">
                        追号奖期
                    </td>
                    <td valign="top" style="border-bottom: #fe8625 1px solid;" align="center">
                        <asp:GridView ID="gvIssueList" runat="server" Width="100%" AutoGenerateColumns="False"
                            OnRowDataBound="gvIssueList_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="选择">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbGoNumberSelectAll" runat="server" Text="选择" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbGoNumberSelectIssuse" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="期号" DataField="IssuseNumber" />
                                <asp:TemplateField HeaderText="投注倍数">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGoNumberAmount" Enabled="false" runat="server">0</asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="购买金额"></asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
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
                frameborder="0" scrolling="no" onload="document.getElementById('iframePlayTypeIntroduce').style.height=iframePlayTypeIntroduce.document.body.scrollHeight;">
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
   
    setTimeout("Page_load(<%= LotteryId %>, '<%= LotteryCode %>');",500);
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

        function GetHidIsuseNumber() {
            return "<%= HidIsuseNumber.ClientID %>";
        }
        
    </script>

</asp:Content>
