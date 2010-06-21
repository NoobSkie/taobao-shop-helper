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
                alert("��������ȷ�ı�����");
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
        <!-- ����Ϣ��ʼ -->
        <div style="border: #C0DBF9 1px solid; background-image: url(../images/l.jpg); background-repeat: repeat-x;
            background-position: top; margin-bottom: 5px; height: 100%; overflow: hidden;">
            <div style="float: left; width: 19%; text-align: center; vertical-align: middle;
                height: 100%; overflow: hidden;">
                <asp:Image ID="LotteryImg" ImageUrl="~/Images/22_5.gif" runat="server" AlternateText="ʱʱ��"
                    Width="105" Height="108" />
            </div>
            <div style="float: left; width: 80%; margin-top: 6px;">
                <div>
                    <div>
                        <div style="float: left; height: 28px; line-height: 28px; font-size: 14px; font-weight: bold;">
                            <asp:Label ID="lblPrevInfo" runat="server" Text="20100024�ڿ�����"></asp:Label></div>
                        <div class="Ball">
                            <asp:Label ID="lblNum1" runat="server" Text="27"></asp:Label></div>
                        <div class="Ball">
                            <asp:Label ID="lblNum2" runat="server" Text="27"></asp:Label></div>
                        <div class="Ball">
                            <asp:Label ID="lblNum3" runat="server" Text="27"></asp:Label></div>
                    </div>
                    <div style="clear: left; height: 48px; line-height: 48px;">
                        <span style="font-size: 18px; font-weight: bold; color: Blue;">�Ϻ�ʱʱ�֣�2ԪӮȡ1000Ԫ</span>
                        ÿ30����һ�ڣ�ȫ��23��</div>
                    <div>
                        ���ڵ�<span id="currIsuseName" style="font-weight: bold; color: #fe8625;"></span>��&nbsp;&nbsp;Ͷע��ֹʱ�䣺<span
                            id="currIsuseEndTime" style="background-color: Red; color: White; font-weight: bold;"></span>&nbsp;&nbsp;��Ͷע��ֹ���У�<span
                                id="toCurrIsuseEndTime" style="background-color: Red; color: White; font-weight: bold;"></span></div>
                    <span id="currIsuseEndTime11" class="black12" style="display: none;"></span>
                    <div style="height: 24px; line-height: 24px;">
                        <a href="DataBehaviour.aspx" class="red">ʱʱ������ͼ</a> <a href="DrawaLotteryInfo.aspx"
                            class="red">ʱʱ���н���ѯ</a></div>
                </div>
            </div>
        </div>
        <!-- ����Ϣ���� -->
        <!-- ѡ���ʼ -->
        <div id="TabMenu" style="margin-top: 15px; border-bottom: #FF6600 2px solid; text-align: center;
            padding-bottom: 0px; width: 100%; display: block; overflow: hidden;">
            <div style="float: left; width: 10px;">
            </div>
            <div class="redMenu" onclick="GotoNewBuy();">
                ѡ��Ͷע
            </div>
            <div style="float: left; width: 2px;">
            </div>
            <div class="whiteMenu1" onclick="GotoPlayIntroduce();">
                <strong>�淨����</strong></div>
        </div>
        <!-- ѡ����� -->
        <div id="divNewBuy" style="clear: both;">
            <table border="0" cellpadding="0" cellspacing="0" width="650" style="border-bottom: #fe8625 1px solid;
                border-left: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                <tbody>
                    <tr>
                        <td width='70' style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;"
                            align="center" bgcolor="#f7b809">
                            ѡ���淨
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
                                        ֱѡ
                                    </td>
                                    <td width='1'>
                                    </td>
                                    <td class='nsplay' onclick='clickPlayClass(1,this);' onmouseover='mOver(this,1)'
                                        onmouseout='mOver(this,2)'>
                                        ��ѡ��ʽ
                                    </td>
                                    <td width='1'>
                                    </td>
                                    <td class='nsplay' onclick='clickPlayClass(2,this);' onmouseover='mOver(this,1)'
                                        onmouseout='mOver(this,2)'>
                                        ��ѡ6
                                    </td>
                                    <td width='1'>
                                    </td>
                                    <td class='nsplay' onclick='clickPlayClass(3,this);' onmouseover='mOver(this,1)'
                                        onmouseout='mOver(this,2)'>
                                        ��ѡ3
                                    </td>
                                    <td width='1'>
                                    </td>
                                    <td class='nsplay' onclick='clickPlayClass(4,this)' onmouseover='mOver(this,1)' onmouseout='mOver(this,2)'>
                                        ǰһ��һ
                                    </td>
                                    <td width='1'>
                                    </td>
                                    <td class='nsplay' onclick='clickPlayClass(5,this);' onmouseover='mOver(this,1)'
                                        onmouseout='mOver(this,2)'>
                                        ǰ�����
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
                            Ͷע��ʽ
                        </td>
                        <td style="border-bottom: #fe8625 1px solid;">
                            <span id='playTypes0'>
                                <input type='radio' name='playType' id='playType2901' value='2901' checked='checked'
                                    onclick='clickPlayType(this.value)' />ֱѡ��ʽ
                                <input type='radio' name='playType' id='playType2902' value='2902' onclick='clickPlayType(this.value)' />ֱѡ��ʽ
                            </span><span id='playTypes1' style='display: none;'>
                                <input type='radio' name='playType' id='playType2903' value='2903' onclick='clickPlayType(this.value)' />��ѡ��ʽ
                            </span><span id='playTypes2' style='display: none;'>
                                <input type='radio' name='playType' id='playType2904' value='2904' onclick='clickPlayType(this.value)' />��ѡ6
                            </span><span id='playTypes3' style='display: none;'>
                                <input type='radio' name='playType' id='playType2905' value='2905' onclick='clickPlayType(this.value)' />��ѡ3
                            </span><span id='playTypes4' style='display: none;'>
                                <input type='radio' name='playType' id='playType2912' value='2912' onclick='clickPlayType(this.value)' />ǰһ��ʽ
                                <input type='radio' name='playType' id='playType2913' value='2913' onclick='clickPlayType(this.value)' />ǰһ��ʽ
                                <input type='radio' name='playType' id='playType2914' value='2914' onclick='clickPlayType(this.value)' />��һ��ʽ
                                <input type='radio' name='playType' id='playType2915' value='2915' onclick='clickPlayType(this.value)' />��һ��ʽ<br />
                            </span><span id='playTypes5' style='display: none;'>
                                <input type='radio' name='playType' id='playType2908' value='2908' onclick='clickPlayType(this.value)' />ǰ����ʽ
                                <input type='radio' name='playType' id='playType2909' value='2909' onclick='clickPlayType(this.value)' />ǰ����ʽ
                                <input type='radio' name='playType' id='playType2910' value='2910' onclick='clickPlayType(this.value)' />�����ʽ
                                <input type='radio' name='playType' id='playType2911' value='2911' onclick='clickPlayType(this.value)' />�����ʽ<br />
                            </span><span id="labShowWinMoney"></span>
                        </td>
                    </tr>
                </tbody>
                <tr>
                    <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" align="center"
                        bgcolor="#f7b809">
                        ѡ��
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
                        Ͷע����
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
                                                <input id="btn_2_Rand" name="btn_2_Rand" type="button" value="��ѡ1ע" onclick="if(this.disabled){this.style.cursor='';return false;}return iframe_playtypes.btn_2_RandClick();"
                                                    style="cursor: pointer; width: 80px;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30">
                                                <input id="btn_2_Rand5" name="btn_2_Rand5" type="button" value="��ѡ5ע" onclick="if(this.disabled){this.style.cursor='';return false;}return iframe_playtypes.btn_2_RandManyClick(5);"
                                                    style="cursor: pointer; width: 80px;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30">
                                                <input type="button" name="btn_ClearSelect" id="btn_ClearSelect" value="ɾ��ѡ��" style="cursor: pointer;
                                                    width: 80px;" onclick="return btn_ClearSelectClick();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30">
                                                <input type="button" name="btn_Clear" id="btn_Clear" value="���ȫ��" style="cursor: pointer;
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
                                    ��ѡ����<span class="red" id="lab_Num">0</span>ע��������<input type="text" onkeypress="return InputMask_Number();"
                                        id="tb_Multiple" name="tb_Multiple" onblur="CheckMultiple();" value="1" maxlength="3"
                                        style="width: 30px;" />�ܽ��<span class="red" id="lab_SumMoney">0.00</span>Ԫ��<span
                                            class="red" style="font-weight: bold">[ע]</span>Ͷע�������Ϊ999����
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom: #fe8625 1px solid; height: 36px; border-right: #fe8625 1px solid;"
                        align="center" bgcolor="#f7b809">
                        ׷�ź���
                    </td>
                    <td valign="top" style="border-bottom: #fe8625 1px solid;" align="center">
                        <asp:CheckBox ID="cbGoNumber" Text="��Ҫ׷��" runat="server" />
                    </td>
                </tr>
                <tr id="trGoNumberIssuse">
                    <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" align="center"
                        bgcolor="#f7b809">
                        ׷�Ž���
                    </td>
                    <td valign="top" style="border-bottom: #fe8625 1px solid;" align="center">
                        <asp:GridView ID="gvIssueList" runat="server" Width="100%" AutoGenerateColumns="False"
                            OnRowDataBound="gvIssueList_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ѡ��">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="cbGoNumberSelectAll" runat="server" Text="ѡ��" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbGoNumberSelectIssuse" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="�ں�" DataField="IssuseNumber" />
                                <asp:TemplateField HeaderText="Ͷע����">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGoNumberAmount" Enabled="false" runat="server">0</asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="������"></asp:TemplateField>
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
                                            <input type="checkbox" name="cb_All" id="cb_All" onclick="Cb_CheckAll();" />ѡ��
                                        </td>
                                        <td style="width: 20%;">
                                            �ں�
                                        </td>
                                        <td style="width: 13%;">
                                            Ͷע����
                                        </td>
                                        <td style="width: 14%;">
                                            ������
                                        </td>
                                        <td style="width: 12%;">
                                            �ܷ���
                                        </td>
                                        <td style="width: 13%;">
                                            �Ϲ�����
                                        </td>
                                        <td style="width: 15%;">
                                            ���׷���
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
                        ���Ѿ��Ķ���ͬ�� <span class="blue12">
                            <asp:HyperLink runat="server" ID="hlAgreement" NavigateUrl="../Home/Room/BuyProtocol.aspx?LotteryID=28"
                                Target="_blank">���û��绰����ͶעЭ�顷</asp:HyperLink></span>
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
    <input id="tbPlayTypeName" name="tbPlayTypeName" type="hidden" value="��ʽ" />
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
