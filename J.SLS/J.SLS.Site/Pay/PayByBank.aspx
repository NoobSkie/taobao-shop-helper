<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="PayByBank.aspx.cs" Inherits="Pay_PayByBank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="wrap">
        <ul class="cznav">
            <li class="on"><a href="ChargeByBank.aspx" class="wifff" onfocus="this.blur()">我要充值</a></li>
            <li class="off"><a href="../MembersWithdrawal2.aspx" onfocus="this.blur()">我要提现</a></li>
            <li class="off"><a href="../MembersAccount2.aspx" onfocus="this.blur()">我的658</a></li>
        </ul>
    </div>
    <div class="czHomeBox">
        <div class="leftConBox">
            <div class='leftCzMenu' id='userLeftDiv'>
                <ul>
                    <li id="ctl00_li1" class="topLine">&nbsp;</li>
                    <li id="ctl00_li2" class="CzOn"><a href='ChargeByBank.aspx'>网银充值</a></li>
                    <li id="ctl00_li3" class="CzOff"><a href='mypay5173.aspx'>5173余额充值</a></li>
                    <li id="ctl00_li5" class="CzOff"><a href='alipay.aspx'>支付宝</a></li>
                    <li id="ctl00_li11" class="CzOff"><a href='YeePay.aspx'>易宝</a></li>
                    <li id="ctl00_li7" class="CzOff" onclick="javascript:showhone();"><a href="javascript:;">
                        电话充值</a></li>
                    <li id="ctl00_li8" class="xCzOff" style="display: none"><a href='javascript:;'>网盈声讯充值</a></li>
                    <li id="ctl00_li14" class="xCzOff" style="display: none" onclick="location.href='PhoneQS.aspx'">
                        <a href='Ebilling.aspx'>eBilling固话充值</a></li>
                    <li id="ctl00_li9" class="xCzOff" style="display: none" onclick="location.href='PhoneQS.aspx'">
                        <a href='PhoneQS.aspx'>齐顺声讯充值</a></li>
                    <li id="ctl00_li10" class="CzOff"><a href='TenPay.aspx'>财付通</a></li>
                    <li id="ctl00_li6" class="CzOff"><a href='ips.aspx'>IPS</a></li>
                    <li id="ctl00_li15" class="CzOff"><a href='99BillPay.aspx'>快钱</a></li>
                    <li id="ctl00_li16" class="CzOff" onclick="location.href='ChargeByVouchers.aspx'"><a
                        href="ChargeByVouchers.aspx" id="ctl00_A2">658折扣券</a></li>
                    <li id="ctl00_li4" class="CzOff" onclick="location.href='ChargeByCoupon.aspx'"><a
                        href="ChargeByCoupon.aspx" id="ctl00_A1">658购彩券</a></li>
                    <li id="ctl00_li17" class="CzOff"><a href='YeePaySZX.aspx'>神州行卡号充值</a></li>
                    <li id="ctl00_li13" class="CzOff" onclick="location.href='myPay5914.aspx'"><a href='myPay5914.aspx'>
                        上门服务</a></li>
                    <li id="ctl00_li12" class="Line">&nbsp;</li>
                    <li class='bottomLine'>&nbsp;</li>
                </ul>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="rightConBox">
            <div class="wrap745">

                <script type="text/javascript">
    function select(id)
    {
      document.getElementById(id).checked=true;
    }
    
    function Display()
    {
     document.getElementById('other').style.display="none";
     document.getElementById('otherDisplay').style.display="block";
    }

function getCheckedValue(radioObj) {
    if(!radioObj)
        return false;
    var radioLength = radioObj.length;
    if(radioLength == undefined)
        if(radioObj.checked)
            return true;
        else
            return false;
    for(var i = 0; i < radioLength; i++) {
        if(radioObj[i].checked) {
            return true;
        }
    }
    return false;
}

function valiDate() {
    var ret = true;
    var retBank = true;
    var money = document.getElementById("txtFillMoney")==null? "nonObject":document.getElementById("txtFillMoney").value;
    if(money=="nonObject"){
        return true;
    }
    if(money == '') {
        document.getElementById("cueDiv").innerHTML = "<img src='/images/v2/wrong.gif' align='absmiddle' />&nbsp;<span class='red fnont12'>请填写充值金额！</span>";
        ret = false;
    }
    if(money.search( /^(([0-9]+\.[0-9]{2})|([0-9]+\.[0-9]{1})|([0-9]*[1-9][0-9]*))$/) == -1) {
        document.getElementById("cueDiv").innerHTML = "<img src='/images/v2/wrong.gif' align='absmiddle' />&nbsp;<span class='red fnont12'>请正确填写充值金额！</span>";
        ret = false;
    }
    if(money < 5) {
        document.getElementById("cueDiv").innerHTML = "<img src='/images/v2/wrong.gif' align='absmiddle' />&nbsp;<span class='red fnont12'>每次充值最低限额为5元，请修改后继续操作！</span>";
        ret = false;
    }
    if(money > 50000) {
        document.getElementById("cueDiv").innerHTML = "<img src='/images/v2/wrong.gif' align='absmiddle' />&nbsp;<span class='red fnont12'>充值金额不能大于50000！</span>";
        ret = false;
    }
    if (ret) {
        document.getElementById("cueDiv").innerHTML = "";
    }

    var bank = document.getElementsByName("radioGroupBank");
    if (!getCheckedValue(bank)) {
        alert('请选择银行！');
        //document.getElementById("msgBankDiv").innerHTML = "<img src='/images/v2/wrong.gif' align='absmiddle' />&nbsp;<span class='red fnont12'>请选择银行！</span>";
        retBank = false;
    }
    if (retBank) {
        document.getElementById("msgBankDiv").innerHTML = "";
    }
    return (ret && retBank);
}

function moreBanks()
{
   if(document.getElementById('trhid').style.display=="none")
   {
       document.getElementById('trhid').style.display="";
   }
   else
   {
       document.getElementById('trhid').style.display="none";
   }
}

function noNumbers(e)   
{   
var keynum;      
if(window.event) // IE   
    {   
    keynum = e.keyCode;   
    }   
else if(e.which) // Netscape/Firefox/Opera   
    {   
    keynum = e.which;   
    } 
      
 if(keynum==13) 
{  
 document.getElementById("Add").focus();
 document.getElementById("Add").submit();
}
} 



                </script>

                <div class="nav">
                    <div class="tit">
                        充值流程：</div>
                    <div class="number">
                        <span class="img">
                            <img src="/images/v2/first_on.gif"></span> <span class="on">选择银行并填写金额</span>
                        <span class="arrow">
                            <img src="/images/v2/arrow_on.gif"></span>
                    </div>
                    <div class="number">
                        <span class="img">
                            <img src="/images/v2/second_off.gif"></span> <span class="off">确认充值信息</span>
                        <span class="arrow">
                            <img src="/images/v2/arrow_off.gif"></span>
                    </div>
                    <div class="number">
                        <span class="img">
                            <img src="/images/v2/third_off.gif"></span> <span class="off">进入网上银行充值</span>
                    </div>
                </div>
                <div id="ChargeEBank1_divBankMsg" style="display: none;" class="paycue">
                </div>
                <div class="box">
                    <div class="left mt10">
                        <span class="red">*</span>选择网上银行：<span id="msgBankDiv" class="red f12"></span></div>
                    <div class="right">
                        <table id='tb' width='100%' border='0' align='left' cellpadding='0' cellspacing='4'>
                            <tr>
                                <td width='20' height='40'>
                                    <input name='radioGroupBank' type='radio' value='中国工商银行（个人）' id="1" />
                                </td>
                                <td width='140'>
                                    <div onclick="select('1');" style='background-image: url(/images/v2/bank/中国工商银行（个人）.jpg);
                                        cursor: hand; width: 140px; height: 40px;' title='中国工商银行（个人）'>
                                    </div>
                                </td>
                                <td width='20' height='40'>
                                    <input name='radioGroupBank' type='radio' value='中国工商银行（公司）' id="2" />
                                </td>
                                <td width='140'>
                                    <div onclick="select('2');" style='background-image: url(/images/v2/bank/中国工商银行（公司）.jpg);
                                        cursor: hand; width: 140px; height: 40px;' title='中国工商银行（公司）'>
                                    </div>
                                </td>
                                <td width='20' height='40'>
                                    <input name='radioGroupBank' type='radio' value='中国建设银行' id="3" />
                                </td>
                                <td>
                                    <div onclick="select('3');" style='background-image: url(/images/v2/bank/中国建设银行.jpg);
                                        cursor: hand; width: 140px; height: 40px;' title='中国建设银行'>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='招商银行（个人）' id="4" />
                                </td>
                                <td>
                                    <div onclick="select('4');" style='background-image: url(/images/v2/bank/招商银行（个人）.jpg);
                                        cursor: hand; width: 140px; height: 40px;' title='招商银行（个人）'>
                                    </div>
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='深圳农村商业银行' id="5" />
                                </td>
                                <td>
                                    <div onclick="select('5');" style='background-image: url(/images/v2/bank/深圳农村商业银行.jpg);
                                        cursor: hand; width: 140px; height: 40px;' title='深圳农村商业银行'>
                                    </div>
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='中国银行' id="6" />
                                </td>
                                <td>
                                    <div onclick="select('6');" style='background-image: url(/images/v2/bank/中国银行.jpg);
                                        cursor: hand; width: 140px; height: 40px;' title='中国银行'>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='农业银行（个人）' id="7" />
                                </td>
                                <td>
                                    <div onclick="select('7');" style='background-image: url(/images/v2/bank/农业银行（个人）.jpg);
                                        cursor: hand; width: 140px; height: 40px;' title='农业银行（个人）'>
                                    </div>
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='农业银行（公司）' id="8" />
                                </td>
                                <td>
                                    <div onclick="select('8');" style='background-image: url(/images/v2/bank/农业银行（公司）.jpg);
                                        cursor: hand; width: 140px; height: 40px;' title='农业银行（公司）'>
                                    </div>
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='交通银行' id="9" />
                                </td>
                                <td>
                                    <div onclick="select('9');" style='background-image: url(/images/v2/bank/交通银行.jpg);
                                        cursor: hand; width: 140px; height: 40px;' title='交通银行'>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='浦东发展银行（个人）' id="10" />
                                </td>
                                <td>
                                    <div onclick="select('10');" style='background-image: url(/images/v2/bank/浦东发展银行（个人）.jpg);
                                        cursor: hand; width: 140px; height: 40px;' title='浦东发展银行（个人）'>
                                    </div>
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='浦东发展银行（公司）' id="11" />
                                </td>
                                <td>
                                    <div onclick="select('11');" style='background-image: url(/images/v2/bank/浦东发展银行（公司）.jpg);
                                        cursor: hand; width: 140px; height: 40px;' title='浦东发展银行（公司）'>
                                    </div>
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='光大银行' id="12" />
                                </td>
                                <td>
                                    <div onclick="select('12');" style='background-image: url(/images/v2/bank/光大银行.jpg);
                                        cursor: hand; width: 140px; height: 40px;' title='光大银行'>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table id="other" width='100%' border='0' align='left' cellpadding='0' cellspacing='4'
                            style="clear: both;">
                            <tr>
                                <td colspan="6" height='40'>
                                    &nbsp;&nbsp;<a href='javascript:void(0);' class='c00579e f12' onclick="Display();"
                                        style="text-decoration: underline;">选择其他银行 </a>
                                </td>
                            </tr>
                        </table>
                        <table style="display: none; clear: both;" id="otherDisplay" width='100%' border='0'
                            align='left' cellpadding='0' cellspacing='4'>
                            <tr>
                                <td width='20' height='40'>
                                    <input name='radioGroupBank' type='radio' value='深圳发展银行' id="13" />
                                </td>
                                <td width='140'>
                                    <img onclick="select('13');" src="/images/v2/bank/深圳发展银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='深圳发展银行' />
                                </td>
                                <td width='20' height='40'>
                                    <input name='radioGroupBank' type='radio' value='广东发展银行' id="14" />
                                </td>
                                <td width='140'>
                                    <img onclick="select('14');" src="/images/v2/bank/广东发展银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='广东发展银行' />
                                </td>
                                <td width='20' height='40'>
                                    <input name='radioGroupBank' type='radio' value='民生银行' id="15" />
                                </td>
                                <td>
                                    <img onclick="select('15');" src="/images/v2/bank/民生银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='民生银行' />
                                </td>
                            </tr>
                            <tr>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='兴业银行' id="16" />
                                </td>
                                <td>
                                    <img onclick="select('16');" src="/images/v2/bank/兴业银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='兴业银行' />
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='中信银行' id="17" />
                                </td>
                                <td>
                                    <img onclick="select('17');" src="/images/v2/bank/中信银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='中信银行' />
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='广州市农村信用合作联社' id="18" />
                                </td>
                                <td>
                                    <img onclick="select('18');" src="/images/v2/bank/广州市农村信用合作联社.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='广州市农村信用合作联社' />
                                </td>
                            </tr>
                            <tr>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='华夏银行' id="19" />
                                </td>
                                <td>
                                    <img onclick="select('19');" src="/images/v2/bank/华夏银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='华夏银行' />
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='北京银行' id="20" />
                                </td>
                                <td>
                                    <img onclick="select('20');" src="/images/v2/bank/北京银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='北京银行' />
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='杭州银行' id="21" />
                                </td>
                                <td>
                                    <img onclick="select('21');" src="/images/v2/bank/杭州银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='杭州银行' />
                                </td>
                            </tr>
                            <tr>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='南京银行' id="22" />
                                </td>
                                <td>
                                    <img onclick="select('22');" src="/images/v2/bank/南京银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='南京银行' />
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='广州市商业银行' id="23" />
                                </td>
                                <td>
                                    <img onclick="select('23');" src="/images/v2/bank/广州市商业银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='广州市商业银行' />
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='广银联' id="24" />
                                </td>
                                <td>
                                    <img onclick="select('24');" src="/images/v2/bank/广银联.jpg" style='cursor: hand; width: 140px;
                                        height: 40px;' title='广银联' />
                                </td>
                            </tr>
                            <tr>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='深圳平安银行' id="25" />
                                </td>
                                <td>
                                    <img onclick="select('25');" src="/images/v2/bank/深圳平安银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='深圳平安银行' />
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='顺德信用社' id="26" />
                                </td>
                                <td>
                                    <img onclick="select('26');" src="/images/v2/bank/顺德信用社.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='顺德信用社' />
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='上海农村商业银行' id="27" />
                                </td>
                                <td>
                                    <img onclick="select('27');" src="/images/v2/bank/上海农村商业银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='上海农村商业银行' />
                                </td>
                            </tr>
                            <tr>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='北京农村商业银行' id="28" />
                                </td>
                                <td>
                                    <img onclick="select('28');" src="/images/v2/bank/北京农村商业银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='北京农村商业银行' />
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='中国邮政储蓄银行' id="29" />
                                </td>
                                <td>
                                    <img onclick="select('29');" src="/images/v2/bank/中国邮政储蓄银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='中国邮政储蓄银行' />
                                </td>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='渤海银行' id="30" />
                                </td>
                                <td>
                                    <img onclick="select('30');" src="/images/v2/bank/渤海银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='渤海银行' />
                                </td>
                            </tr>
                            <tr>
                                <td height='40'>
                                    <input name='radioGroupBank' type='radio' value='东亚银行' id="31" />
                                </td>
                                <td>
                                    <img onclick="select('31');" src="/images/v2/bank/东亚银行.jpg" style='cursor: hand;
                                        width: 140px; height: 40px;' title='东亚银行' />
                                </td>
                                <td height='40'>
                                </td>
                                <td>
                                </td>
                                <td height='40'>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="paycue2">
                    <span class="zhu">注:网银充值不需手续费</span>请确保您已经在银行柜台开通了网上支付功能，否则将无法支付成功。</div>
                <div class="box mt10">
                    <div id="ctl00_ContentPlaceHolder1_PanNormailCharge">
                        <div class="left mt10">
                            <span class="red">*</span>请输入充值金额：</div>
                        <div class="right mt10">
                            <input name="txtFillMoney" type="text" maxlength="9" id="txtFillMoney" onkeydown="noNumbers(event)"
                                style="width: 100px;" />&nbsp;元&nbsp;&nbsp;<span id="cueDiv" class="red f12">(每次充值最低限额5元)</span>
                            <br />
                            <br />
                            <span class="mt10">
                                <input type="submit" id="Add" name="Add" value="下一步" class="input_button82" /><br />
                            </span>
                            <br>
                        </div>
                    </div>
                </div>
                <div class="textright c00579e f12 mt10" style="width: 745px; overflow: hidden;">
                    [<a href='/Helps/HelpPageDetails.aspx?connentTypeID=62&classTypeID=2' target='_blank'><u>如何开通网上银行</u></a>]
                    如需咨询，[<a href='/Helps/Default.aspx' target='_blank'><u>请点击</u></a>]</div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="wrap hr_btom">
</asp:Content>
