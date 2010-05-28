﻿
//************************************************************全局变量定义区*******************************************

//当前彩种编号
var currentLotteryID = null;

var o_tb_LotteryNumber;
var o_list_LotteryNumber;
var o_tb_Multiple;
var o_tb_Share;
var o_tb_AssureShare;
var o_tb_BuyShare;
var o_tb_Title;
//合买佣金比率
var o_tb_SchemeBonusScale;
//追号佣金比例
var o_tb_SchemeBonusScalec;
var o_lab_Num;
var o_lab_SumMoney;
var o_lab_ShareMoney;
var o_lab_AssureMoney;
var o_lab_BuyMoney;
var o_lb_LbSumMoney;
var o_tb_Price;

//发起方案条件
var Opt_InitiateSchemeLimitLowerScaleMoney = 100;           // = <%=_Site.SiteOptions["Opt_InitiateSchemeLimitLowerScaleMoney"].ToDouble(100) %>;
var Opt_InitiateSchemeLimitLowerScale = 0.2;                // = <%=_Site.SiteOptions["Opt_InitiateSchemeLimitLowerScale"].ToDouble(0.2) %>;
var Opt_InitiateSchemeLimitUpperScaleMoney = 10000;         // = <%=_Site.SiteOptions["Opt_InitiateSchemeLimitUpperScaleMoney"].ToDouble(10000) %>;
var Opt_InitiateSchemeLimitUpperScale = 0.05;               // <%=_Site.SiteOptions["Opt_InitiateSchemeLimitUpperScale"].ToDouble(0.05) %>;

//彩种名称
var LotteryName;


//************************************************************方法函数定义区***************************************


//---------------------------------------页面加载功能区代码-------------------------------------------------

//初始化全局变量数据
function init() {
    o_tb_LotteryNumber = $Id("tb_LotteryNumber");
    o_list_LotteryNumber = $Id("list_LotteryNumber");
    o_tb_Multiple = $Id("tb_Multiple");
    o_tb_Share = $Id("tb_Share");
    o_tb_AssureShare = $Id("tb_AssureShare");
    o_tb_BuyShare = $Id("tb_BuyShare");
    o_tb_Title = $Id("tb_Title");
    o_tb_SchemeBonusScale = $Id("tb_SchemeBonusScale");
    o_tb_SchemeBonusScalec = $Id("tb_SchemeBonusScalec");
    o_lab_Num = $Id("lab_Num");
    o_lab_SumMoney = $Id("lab_SumMoney");
    o_lab_ShareMoney = $Id("lab_ShareMoney");
    o_lab_AssureMoney = $Id("lab_AssureMoney");
    o_lab_BuyMoney = $Id("lab_BuyMoney");

    o_tb_LotteryNumber.value = "";
    o_tb_Multiple.value = "1";
    o_tb_Share.value = "1";

    GetSchemeBonusScalec();

    o_tb_AssureShare.value = "0";
    o_tb_BuyShare.value = "1";
    o_tb_Title.value = "";
    o_lab_Num.innerText = "0";
    o_lab_SumMoney.innerText = "0.00";
    o_lab_ShareMoney.innerText = "0.00";
    o_lab_AssureMoney.innerText = "0.00";
    o_lab_BuyMoney.innerText = "0.00";
    o_tb_Price = 2;
    o_lb_LbSumMoney = $Id("LbSumMoney");

    try {
        if (parent.lockBindData == null) {
            parent.BindDataForFromAli();
            parent.lockBindData = 1;
        }
    }
    catch (e) { }
}

//获得佣金比例
var isGetSchemeBonusScalec = false;
var time_GetSchemeBonusScalec = null;
function GetSchemeBonusScalec() {

//    if (!isGetSchemeBonusScalec) {
//        try {

//            Lottery_CQSSC_Buy.GetSchemeBonusScalec(GetSchemeBonusScalec_callback);

//            isGetSchemeBonusScalec = true;
//        }
//        catch (e) {
//            time_GetSchemeBonusScalec = setTimeout("Lottery_CQSSC_Buy.GetSchemeBonusScalec(GetSchemeBonusScalec_callback);", 2000);
//        }
//    }
}

function GetSchemeBonusScalec_callback(response) {

//    if (response == null || response.value == null) {

//        time_GetSchemeBonusScalec = setTimeout("Lottery_CQSSC_Buy.GetSchemeBonusScalec(GetSchemeBonusScalec_callback);", 2000);

//        return;
//    }


//    //将time_GetSchemeBonusScalec移除
//    if (time_GetSchemeBonusScalec != null) {
//        clearTimeout(time_GetSchemeBonusScalec);
//    }

//    var v = response.value.split('|');

//    o_tb_SchemeBonusScale.value = v[0];
//    o_tb_SchemeBonusScalec.value = v[0];

//    Opt_InitiateSchemeLimitLowerScaleMoney = v[1];
//    Opt_InitiateSchemeLimitLowerScale = v[2];
//    Opt_InitiateSchemeLimitUpperScaleMoney = v[3];
//    Opt_InitiateSchemeLimitUpperScale = v[4];

//    LotteryName = v[5];
//    isGetSchemeBonusScalec = true;
}

//定时读取最近的开奖信息的定时器
var time_GetServerTime = null;

//获取服务器时间
function GetServerTime(lotteryID) {

    currentLotteryID = lotteryID;

    try {

        Lottery_CQSSC_Buy.GetSysTime(GetServerTime_callback);

    }
    catch (e) {
        //如果失败了，就继续读取
        time_GetServerTime = setTimeout("GetServerTime(" + lotteryID + ");", 2000);
    }
}

function GetServerTime_callback(response) {


    if (response == null || response.value == null) {

        time_GetServerTime = setTimeout("GetServerTime(" + currentLotteryID + ");", 2000);

        return;
    }

    //将time_GetServerTime移除
    if (time_GetServerTime != null) {
        clearTimeout(time_GetServerTime);
    }

    var serverTime = response.value;

    var IsuseEndTime = new Date($Id("HidIsuseEndTime").value.replace(new RegExp("-", "g"), "/"));
    var TimePoor = new Date(serverTime.replace(new RegExp("-", "g"), "/")).getTime() - new Date().getTime();
    var to = IsuseEndTime.getTime() - new Date(serverTime.replace(new RegExp("-", "g"), "/")).getTime();

    var d = Math.floor(to / (1000 * 60 * 60 * 24));
    var h = Math.floor(to / (1000 * 60 * 60)) % 24;
    var m = Math.floor(to / (1000 * 60)) % 60;
    var s = Math.floor(to / 1000) % 60;



    if (!isNaN(d)) {
        if (d < 0) {
            $Id("toCurrIsuseEndTime").innerHTML = "本期已截止投注";

            var lottery = setTimeout("loadLottery(" + currentLotteryID + ");", 20000);

            return;
        }
        else {
            clearTimeout(lottery);
            $Id("toCurrIsuseEndTime").innerHTML = (d > 0 ? ((d > 9 ? String(d) : "0" + String(d)) + "天") : "") + ((h > 0 || d > 0) ? ((h > 9 ? String(h) : "0" + String(h)) + "时") : "") + ((m > 9 ? String(m) : "0" + String(m)) + "分") + ((s > 9 ? String(s) : "0" + String(s)) + "秒");
        }
    }

    showIsuseTime(IsuseEndTime.getTime(), TimePoor, 1000, currentLotteryID);
}


//显示当前期的投注时间
var lockIsuseTime = null;
function showIsuseTime(eTime, tPoor, goTime, lotteryID) {

    if (goTime >= 300000)//8分钟
    {
        GetServerTime(lotteryID);

        return;
    }

    var serverTime = new Date().getTime() + tPoor;
    var IsuseEndTime = new Date($Id("HidIsuseEndTime").value.replace(new RegExp("-", "g"), "/"));
    var to = IsuseEndTime.getTime() - serverTime;

    var d = Math.floor(to / (1000 * 60 * 60 * 24));
    var h = Math.floor(to / (1000 * 60 * 60)) % 24;
    var m = Math.floor(to / (1000 * 60)) % 60;
    var s = Math.floor(to / 1000) % 60;

    if (!isNaN(d)) {
        if (d < 0) {
            $Id("toCurrIsuseEndTime").innerHTML = "本期已截止投注";

            var lottery = setTimeout("loadLottery(" + lotteryID + ");", 20000);

            return;
        }
        else {
            clearTimeout(lottery);
            $Id("toCurrIsuseEndTime").innerHTML = (d > 0 ? ((d > 9 ? String(d) : "0" + String(d)) + "天") : "") + ((h > 0 || d > 0) ? ((h > 9 ? String(h) : "0" + String(h)) + "时") : "") + ((m > 9 ? String(m) : "0" + String(m)) + "分") + ((s > 9 ? String(s) : "0" + String(s)) + "秒");
        }
    }

    if (lockIsuseTime != null) {
        clearTimeout(lockIsuseTime);
    }

    lockIsuseTime = setTimeout("showIsuseTime(" + eTime + "," + tPoor + "," + (goTime + 1000) + "," + lotteryID + ")", 1000);
}

//获取当前投注奖期信息，及追号奖期
var time_GetIsuseInfo = null;
function GetIsuseInfo(lotteryID) {

    currentLotteryID = lotteryID;

//    try {

//        Lottery_CQSSC_Buy.GetIsuseInfo(lotteryID, GetIsuseInfo_callback);

//    }
//    catch (e) {

//        time_GetIsuseInfo = setTimeout("GetIsuseInfo(" + lotteryID + ");", 2000);
//    }
}

function GetIsuseInfo_callback(response) {

    if (response == null || response.value == null) {

        time_GetIsuseInfo = setTimeout("GetIsuseInfo(" + currentLotteryID + ");", 2000);

        return;
    }

    //将time_GetIsuseInfo移除
    if (time_GetIsuseInfo != null) {
        clearTimeout(time_GetIsuseInfo);
    }

    var v = response.value;

    if (v.indexOf('|') == -1) {
        return;
    }

    var arrInfo = v.split('|');

    if (arrInfo.length != 2) {
        return;
    }

    var currIsuse = arrInfo[0];
    var chaseIsuse = arrInfo[1];


    $Id("div_QH_Today").innerHTML = chaseIsuse;

    try {
        var firstChase = $Id("div_QH_Today").childNodes[0].rows[0].cells[0].childNodes[0];
        if (firstChase != undefined) {
            firstChase.checked = true;
            check(firstChase);
        }
    } catch (e) { }

    var arrcurrIsuse = currIsuse.split(',');
    $Id("HidIsuseID").value = arrcurrIsuse[0];
    $Id("currIsuseName").innerText = arrcurrIsuse[1];
    $Id("currIsuseEndTime").innerText = arrcurrIsuse[2].replace("/", "-").replace("/", "-");
    $Id("HidIsuseEndTime").value = arrcurrIsuse[2];

    //获取投注时间信息
    GetServerTime(currentLotteryID);
}

//获取新闻资讯
var time_GetNewsInfo = null;
function GetNewsInfo(lotteryID) {

    currentLotteryID = lotteryID;

//    try {

//        Lottery_CQSSC_Buy.GetNewsInfo(lotteryID, GetNewsInfo_callback);

//    }
//    catch (e) {

//        time_GetNewsInfo = setTimeout("GetNewsInfo(" + lotteryID + ");", 2000);
//    }
}

function GetNewsInfo_callback(response) {

    if (response == null || response.value == null) {

        time_GetNewsInfo = setTimeout("GetNewsInfo(" + currentLotteryID + ");", 2000);

        return;
    }

    //将time_GetNewsInfo移除
    if (time_GetNewsInfo != null) {
        clearTimeout(time_GetNewsInfo);
    }

    var v = response.value;

    if (v == null) {
        return;
    }

    $Id("tbNews").innerHTML = "<table width=\"98%\" border=\"0\" style=\"margin:8px;\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">" + v + "</table>";

}


//加载彩票信息
var lockInit = null;
function loadLottery(lotteryID) {

    if (lockInit == null) {
        init();
        lockInit = 1;
    }

    //获取当前投注奖期信息
    GetIsuseInfo(lotteryID);

    //获取上期开奖号码(Jscript.js文件中)
    loadPage(lotteryID);

    //加载资讯信息
    GetNewsInfo(lotteryID);

}

//---------------------------------------投注功能区代码-------------------------------------------------
function btn_ClearClick() {
    try {
        while (o_list_LotteryNumber.length > 0) {
            o_list_LotteryNumber.remove(0);
        }

        o_tb_LotteryNumber.value = "";
        o_lab_Num.innerText = "0";
        CalcResult();
        return true;
    }
    catch (e) {
        return false;
    }
}

function btn_ClearSelectClick() {
    if (o_list_LotteryNumber.length < 1) {
        alert("您还没有输入投注内容。");
        return true;
    }

    var SelectNum = 0;
    var i = 0;
    for (i = 0; i < o_list_LotteryNumber.length; i++) {
        if (o_list_LotteryNumber.options[i].selected)
            SelectNum++;
    }

    if (SelectNum < 1) {
        alert("请选择要删除的投注内容(按住 Ctrl 键可以多选)。");
        return true;
    }

    for (i = o_list_LotteryNumber.length - 1; i >= 0; i--) {
        if (o_list_LotteryNumber.options[i].selected) {
            var Num = parseInt(o_list_LotteryNumber.options[i].value, 10);
            o_lab_Num.innerText = StrToInt(o_lab_Num.innerText) - Num;
            o_list_LotteryNumber.remove(i);
        }
    }
    o_tb_LotteryNumber.value = "";
    if (o_list_LotteryNumber.length > 0) {
        for (i = 0; i < o_list_LotteryNumber.length; i++)
            o_tb_LotteryNumber.value += (o_list_LotteryNumber.options[i].text + "\n");
    }

    if (o_list_LotteryNumber.length == 0) {
        resetPage();
    }
    CalcResult();
    return true;
}

function ClearSMS() {

}

function InputMask_Number() {
    if (window.event.keyCode < 48 || window.event.keyCode > 57)
        return false;
    return true;
}

function CheckMultiple() {
    var multiple = StrToInt(o_tb_Multiple.value);
    if (multiple < 1 || multiple > 999) {
        if (confirm("倍数不正确，按“确定”重新输入，按“取消”自动更正为 1 倍，请选择。")) {
            o_tb_Multiple.focus();
            return;
        }
        else {
            multiple = 1;
            o_tb_Multiple.value = 1;
        }
    }
    CalcResult();
}

function CheckMultiple2(sender) {
    var multiple = StrToInt(sender.value);
    if (multiple < 1 || multiple > 999) {
        if (confirm("倍数不正确，按“确定”重新输入，按“取消”自动更正为 1 倍，请选择。")) {
            sender.focus();
            return;
        }
        else {
            multiple = 1;
            sender.value = 1;
        }
    }

    accountAllMoney();
}

//判断合买佣金比率
function SchemeBonusScale() {
    if (isNaN(o_tb_SchemeBonusScale.value)) {
        alert('请输入数字');
        o_tb_SchemeBonusScale.focus();

        return;
    }
    var SchemeBonusScale = StrToInt(o_tb_SchemeBonusScale.value);
    o_tb_SchemeBonusScale.value = SchemeBonusScale;
    if (SchemeBonusScale < 0) {
        alert("输入的佣金比率非法。");
        o_tb_SchemeBonusScale.focus();

        return false;
    }
    if (SchemeBonusScale > 10) {
        alert("输入的佣金比率不能大于10%")
        o_tb_SchemeBonusScale.focus();

        return false;
    }

    return true;
}
//判断追号佣金比例
function SchemeBonusScalec() {
    if (isNaN(o_tb_SchemeBonusScalec.value)) {
        alert('请输入数字');
        o_tb_SchemeBonusScalec.focus();

        return;
    }
    var SchemeBonusScalec = StrToInt(o_tb_SchemeBonusScalec.value);
    o_tb_SchemeBonusScalec.value = SchemeBonusScalec;
    if (SchemeBonusScalec < 0) {
        alert("输入的佣金比率非法。");
        o_tb_SchemeBonusScalec.focus();

        return false;
    }
    if (SchemeBonusScalec > 10) {
        alert("输入的佣金比率不能大于10%")
        o_tb_SchemeBonusScalec.focus();

        return false;
    }

    return true;
}

function CheckShare() {
    var Share = StrToInt(o_tb_Share.value);
    var OK = false;

    o_tb_Share.value = Share;

    if (Share < 0) {
        alert("输入的份数非法。");

        OK = false;
    }
    else if (Share == 1) {
        OK = true;
    }
    else {
        if (Share > 1) {
            var multiple = StrToInt(o_tb_Multiple.value);
            var SumNum = StrToInt(o_lab_Num.innerText);
            var SumMoney = multiple * o_tb_Price * SumNum;
            var ShareMoney = SumMoney / Share;
            var ShareMoney2 = Math.round(ShareMoney * 100) / 100;

            if (ShareMoney == ShareMoney2)
                OK = true;

            if (ShareMoney < 1) {
                OK = false;
            }
        }
    }

    if (!OK) {
        if (confirm("份数为 0 或者不能除尽，将产生误差，并且金额不能小于 1 元。按“确定”重新输入，按“取消”自动更正为 1 份，请选择。")) {
            o_tb_Share.focus();
            return;
        }
        else {
            Share = 1;
            o_tb_Share.value = 1;
        }
    }

    o_tb_AssureShare.value = "0";
    o_tb_BuyShare.value = Share;
    CalcResult();
}

function CheckAssureShare() {
    var Share = StrToInt(o_tb_Share.value);
    var AssureShare = StrToInt(o_tb_AssureShare.value);
    var BuyShare = StrToInt(o_tb_BuyShare.value);

    o_tb_Share.value = Share;
    o_tb_AssureShare.value = AssureShare;
    o_tb_BuyShare.value = BuyShare;

    if (AssureShare < 0) {
        alert("输入的保底份数非法。");
        o_tb_AssureShare.value = "0";
        CalcResult();
        return;
    }

    if ((Share == 1) && (AssureShare > 0)) {
        alert("此方案只分为 1 份，不能保底。");
        o_tb_AssureShare.value = "0";
        CalcResult();
        return;
    }
    if (AssureShare > (Share - 1)) {
        var AutoAssureShare = Math.round(Share / 2);
        if ((AutoAssureShare + BuyShare) > Share)
            AutoAssureShare = Share - BuyShare;
        if (confirm("保底份数不能大于和等于总份数。按“确定”重新输入，按“取消”自动更正为 " + AutoAssureShare + " 份，请选择。")) {
            o_tb_AssureShare.focus();
            return;
        }
        else {
            o_tb_AssureShare.value = AutoAssureShare;
            AssureShare = AutoAssureShare;
        }
    }
    if ((BuyShare + AssureShare) > Share) {
        BuyShare = Share - AssureShare;
        alert("购买份数与保底份数和大于总份数，购买份数自动调整为 " + BuyShare + " 份。");
        o_tb_BuyShare.value = BuyShare;
    }

    CalcResult();
    return;
}

function CheckBuyShare() {
    var BuyShare = StrToInt(o_tb_BuyShare.value);
    var Share = StrToInt(o_tb_Share.value);
    var AssureShare = StrToInt(o_tb_AssureShare.value);

    o_tb_BuyShare.value = BuyShare;
    o_tb_Share.value = Share;
    o_tb_AssureShare.value = AssureShare;

    if ((BuyShare < 1) || (BuyShare > Share)) {
        if (confirm("购买份数不能为 0 以及大于总份数同时份数必须为整数。按“确定”重新输入，按“取消”自动更正为 " + Share + " 份，请选择。")) {
            o_tb_BuyShare.focus();
            return;
        }
        else {
            o_tb_BuyShare.value = Share;
            BuyShare = Share;
        }
    }

    if ((BuyShare + AssureShare) > Share) {
        AssureShare = Share - BuyShare;
        alert("购买和保底份数大于总份数，保底份数自动调整为 " + AssureShare + "。");
        o_tb_AssureShare.value = AssureShare;
    }

    CalcResult();
    return;
}

function CalcResult() {

    var multiple = StrToInt(o_tb_Multiple.value);
    multiple = multiple == 0 ? 1 : multiple;
    var SumNum = StrToInt(o_lab_Num.innerText);
    var Share = StrToInt(o_tb_Share.value);
    var BuyShare = StrToInt(o_tb_BuyShare.value);
    var AssureShare = StrToInt(o_tb_AssureShare.value);

    var SumMoney = Round(multiple * o_tb_Price * SumNum, 2);
    var ShareMoney = Round(SumMoney / Share, 2);

    var AssureMoney = Round(AssureShare * ShareMoney, 2);
    var BuyMoney = Round(BuyShare * ShareMoney, 2);

    o_lab_SumMoney.innerText = SumMoney;
    o_lab_ShareMoney.innerText = ShareMoney;
    o_lab_AssureMoney.innerText = AssureMoney;
    o_lab_BuyMoney.innerText = BuyMoney;

    if ($Id("Chase").checked)
        accountAllMoney();
}

function oncbInitiateTypeClick(sender) {

    if (sender.id == "CoBuy") {
        $Id("Chase").checked = false;
        //$Id("tb_Multiple").value = "1";
        $Id("tb_Share").value = "1";
        $Id("tb_BuyShare").value = "1";
        $Id("tb_AssureShare").value = "0";
        $Id("tb_OpenUserList").value = "";
        $Id("tb_Title").value = "";
        $Id("tb_Description").value = "";
    }
    else {
        $Id("CoBuy").checked = false;
    }

    if ($Id("CoBuy").checked) {
        $Id("DivChase").style.display = "none";
    }
    else {
        $Id("DivChase").style.display = "";
    }

    if ($Id("Chase").checked) {
        $Id("DivBuy").style.display = "none";
    }
    else {
        $Id("DivBuy").style.display = "";
    }

    $Id("trShowJion").style.display = $Id("CoBuy").checked == true ? "" : "none";
    $Id("trGoon").style.display = $Id("Chase").checked == true ? "" : "none";

    if ($Id("Chase").checked == true) {
        $Id("tb_Multiple").disabled = "disabled";
        $Id("tb_Multiple").innerText = "1";
    }
    else {
        $Id("tb_Multiple").disabled = "";
    }

    showSameHeight();

    CalcResult();
}

function calculateAllMoney() {
    var btnId = GetBtnOKId();
    $Id(btnId).disabled = "";
    try { accountAllMoney(); } catch (e) { }
    return true;
}

function HidBtnRand(playTypeName) {

    var isHidRandTR = playTypeName.indexOf("组合") > -1 || playTypeName.indexOf("复式") > -1 || playTypeName.indexOf("包点") > -1 || playTypeName.indexOf("包胆") > -1 || playTypeName.indexOf("小单") > -1 || playTypeName.indexOf("组三") > -1 || playTypeName.indexOf("组六") > -1;
    if (isHidRandTR) {
        $Id("btn_2_Rand").disabled = "false";
        $Id("btn_2_Rand5").disabled = "false";
        $Id("btn_2_Rand").style.cursor = '';
        $Id("btn_2_Rand5").style.cursor = '';
    }
    else {
        $Id("btn_2_Rand").disabled = "";
        $Id("btn_2_Rand5").disabled = "";
        $Id("btn_2_Rand").style.cursor = 'pointer';
        $Id("btn_2_Rand5").style.cursor = 'pointer';
    }
}

function check(obj) {
    if (obj == undefined) {
        return;
    }

    var obj_TxtBNum = $Id(obj.id.replace("check", "times"));
    var obj_TxtMoney = $Id(obj.id.replace("check", "money"));
    var obj_TxtShare = $Id(obj.id.replace("check", "share"));
    var obj_TxtBuyedShare = $Id(obj.id.replace("check", "buyedShare"));
    var obj_TxtAssureShare = $Id(obj.id.replace("check", "assureShare"));

    if (obj.checked != true) {
        obj_TxtBNum.disabled = "disabled";
        obj_TxtShare.disabled = "disabled";
        obj_TxtBuyedShare.disabled = "disabled";
        obj_TxtAssureShare.disabled = "disabled";
        obj_TxtBNum.value = "1";
        obj_TxtMoney.value = "0";
        obj_TxtShare.value = "1";
        obj_TxtBuyedShare.value = "1";
        obj_TxtAssureShare.value = "0";
    }
    else {
        obj_TxtBNum.disabled = "";
        obj_TxtShare.disabled = "";
        obj_TxtBuyedShare.disabled = "";
        obj_TxtAssureShare.disabled = "";
    }

    accountAllMoney();
}

function accountAllMoney() {

    var arrTable = new Array();
    var needMoney = 0;
    var obj_Name = "";
    var buyedMoney = 0;
    var isuseCount = 0;
    var lastNum = 0;
    var lastShare = 0;
    var BuyShare = 0;

    arrTable[0] = window.$Id("div_QH_Today");
    for (j = 0; j < arrTable.length; j++) {
        var objs = arrTable[j].getElementsByTagName("input");
        var obj_txtMoney, obj_txtBNum, obj_txtShare, obj_txtBuyedShare, obj_txtAssureShare;
        for (var i = 0; i < objs.length; i++) {
            if (objs[i].type.toLowerCase() == "checkbox")
                if (objs[i].checked == true) {
                obj_txtBNum = $Id(objs[i].id.replace("check", "times"));
                obj_txtMoney = $Id(objs[i].id.replace("check", "money"));
                obj_txtShare = $Id(objs[i].id.replace("check", "share"));
                obj_txtBuyedShare = $Id(objs[i].id.replace("check", "buyedShare"));
                obj_txtAssureShare = $Id(objs[i].id.replace("check", "assureShare"));
                obj_Name = $Id(objs[i].id.substring(0, (objs[i].id.length - 6)));
                obj_txtMoney.value = parseInt(obj_txtBNum.value) * parseInt(lab_SumMoney.innerText);
                obj_txtMoney.innerText = obj_txtMoney.value;
                needMoney = parseInt(needMoney) + parseInt(obj_txtMoney.value);
                buyedMoney = parseInt(buyedMoney) + Math.round(parseFloat(obj_txtMoney.value) / parseInt(obj_txtShare.value)) * (parseInt(obj_txtBuyedShare.value) + parseInt(obj_txtAssureShare.value));
                isuseCount++;
                lastNum = parseInt(obj_txtBNum.value);
                lastShare = parseInt(obj_txtShare.value);
                BuyShare = parseInt(obj_txtBuyedShare.value) + parseInt(obj_txtAssureShare.value);
            }
        }
    }

    $Id("LbSumMoney").innerText = needMoney;
    $Id("LbChaseMoney").innerText = buyedMoney;
    if (needMoney < 1) {
        $Id("spanChaseIsuseCount").innerText = "0";
        $Id("spanWinMoney").innerText = "0";
        $Id("spanSchemeProfit").innerText = "0";
        $Id("spanFJL").innerText = "0";
    } else {

        $Id("spanChaseIsuseCount").innerText = isuseCount;

        $Id("spanWinMoney").innerText = lastNum * parseFloat(document.getElementById("spanPlayTypeMoney").innerText);

        $Id("spanSchemeProfit").innerText = parseFloat($Id("spanWinMoney").innerText) - needMoney;

        $Id("spanFJL").innerText = Round(parseFloat($Id("spanWinMoney").innerText) / lastShare * BuyShare / buyedMoney, 2);

    }

}

function onTextChange(obj) {
    //判断输入必须为数字
    if ((isNaN(obj.value) == true) || (obj.value <= 0)) {
        alert("倍数格式有误，已自动重置为 1");
        obj.value = 1;
    }

    //判断范围
    if (Number(obj.value) > Number($Id("HidMaxTimes").value) - 1) {
        alert("倍数超出范围，最大倍数为 " + String(Number($Id("HidMaxTimes").value) - 1) + "，已自动重置为 1");
        obj.value = 1;
    }

    //accountAllMoney();
}

//重置页面
function resetPage() {
    $Id("Chase").checked = false;
    $Id("CoBuy").checked = false;
    $Id("trShowJion").style.display = "none";
    $Id("trGoon").style.display = "none";

    btn_ClearClick();
    init();
}

function Cb_CheckAll() {
    var o_cb_All = $Id("cb_All");

    var table = $Id("div_QH_Today").childNodes[0];
    var rows = table.rows;
    var num = rows.length;

    for (var i = 1; i < num; i++) {
        var obj = rows[i].cells[0].childNodes[0];
        obj.checked = o_cb_All.checked;
        check(obj);
    }
}


//刘志方修改
function ChangeBackImage(index) {
    var table = document.getElementById("TabMenu");
    var arr = new Array(1, 3, 5, 7, 9);

    for (var i = 0; i < arr.length; i++) {
        if (index == arr[i]) {

            table.childNodes[arr[i]].className = "redMenu";


        }
        else {
            if (arr[i] == 9) {
                table.childNodes[arr[i]].className = "whiteMenu1";
            }
            else {
                table.childNodes[arr[i]].className = "whiteMenu";
            }

        }
    }
}


function newBuy(lotteryID) {
    $Id("divNewBuy").style.display = "";
    $Id("divCoBuy").style.display = "none";
    $Id("divFollowScheme").style.display = "none";
    $Id("divSchemeAll").style.display = "none";
    $Id("divPlayTypeIntroduce").style.display = "none";
    ChangeBackImage(1);

    var menu = document.getElementById("tbPlayTypeMenu" + String(lotteryID));

    if (menu == null) {
        $Id("playType" + String(lotteryID) + "01").checked = true;
        clickPlayType(100 * lotteryID + 01);
    } else {
        menu.rows[0].cells[1].click();
    }
}

function newCoBuy(lotteryID, isuseId) {
    $Id("divNewBuy").style.display = "none";
    $Id("divCoBuy").style.display = "";
    $Id("divFollowScheme").style.display = "none";
    $Id("divSchemeAll").style.display = "none";
    $Id("divPlayTypeIntroduce").style.display = "none";

    var coBuyUrl = "../CoBuy.aspx?Radom=" + Math.random() + "&LotteryID=" + lotteryID + "&IsuseID=" + isuseId;
    $Id("iframeCoBuy").src = coBuyUrl;

    ChangeBackImage(3);
}

function followScheme(lotteryID) {
    $Id("divNewBuy").style.display = "none";
    $Id("divCoBuy").style.display = "none";
    $Id("divFollowScheme").style.display = "";
    $Id("divSchemeAll").style.display = "none";
    $Id("divPlayTypeIntroduce").style.display = "none";

    if ($Id("iframeFollowScheme").src == "") {
        $Id("iframeFollowScheme").src = "../../Core/Follow/FollowScheme.aspx?LotteryID=" + lotteryID;
    }

    ChangeBackImage(5);
}

function schemeAll(lotteryID, isuseId) {
    $Id("divNewBuy").style.display = "none";
    $Id("divCoBuy").style.display = "none";
    $Id("divFollowScheme").style.display = "none";
    $Id("divPlayTypeIntroduce").style.display = "none";
    $Id("divSchemeAll").style.display = "";

    $Id("divLoding").style.display = "";
    $Id("iframeSchemeAll").style.display = "none";

    $Id("iframeSchemeAll").src = "../../Core/Scheme/SchemeAll.aspx?Radom=" + Math.random() + "&LotteryID=" + lotteryID + "&IsuseID=" + isuseId;

    ChangeBackImage(7);
}

function playTypeIntroduce(lotteryCode) {
    $Id("divNewBuy").style.display = "none";
    $Id("divCoBuy").style.display = "none";
    $Id("divFollowScheme").style.display = "none";
    $Id("divSchemeAll").style.display = "none";
    $Id("divPlayTypeIntroduce").style.display = "";

    if ($Id("iframePlayTypeIntroduce").src == "") {
        $Id("iframePlayTypeIntroduce").src = "../../Help/Core/help_" + lotteryCode + ".htm";
    }

    ChangeBackImage(9);
}

function clickPlayType(t) {


    var playTypeName = '';
    switch (t) {
        case 'playType2801':
            playTypeName = '单式';

            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp投注号码万、千、百、十、个位与开奖号码全部相同且顺序一致，奖金 <span style="color:red" id="spanPlayTypeMoney">100000</span>元。';
            iframe_playtypes.location.href = 'CQSSC_5XDS.htm';
            break;

        case 'playType2802':
            playTypeName = '复选';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 包括五星、三星、二星、一星投注号码各一注，最高奖金可达<span style="color:red" id="spanPlayTypeMoney">100000</span>元。';
            iframe_playtypes.location.href = 'CQSSC_5XFS.htm';
            break;

        case 'playType2803':
            playTypeName = '组合';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp投注号码万、千、百、十、个位与开奖号码全部相同且顺序一致，奖金<span style="color:red" id="spanPlayTypeMoney">100000</span>元。';
            iframe_playtypes.location.href = 'CQSSC_5XZH.htm';
            break;

        case 'playType2804':
            playTypeName = '五星通选单式';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp一注号码，三个奖级通吃，五次中奖机会，大奖<span style="color:red" id="spanPlayTypeMoney">20000</span> 元。';
            iframe_playtypes.location.href = 'CQSSC_5XTXDS.htm';
            break;

        case 'playType2805':
            playTypeName = '五星通选复式';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp一注号码，三个奖级通吃，五次中奖机会，大奖 <span style="color:red" id="spanPlayTypeMoney">20000</span>元。';
            iframe_playtypes.location.href = 'CQSSC_5XTXFS.htm';
            break;

        case 'playType2806':
            playTypeName = '单式';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 投注号码百、十、个位与开奖号码全部相同且顺序一致，奖金 <span style="color:red" id="spanPlayTypeMoney">1000</span>元。  ';
            iframe_playtypes.location.href = 'CQSSC_3XDS.htm';
            break;

        case 'playType2807':
            playTypeName = '复选';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 包括三星、二星、一星投注号码各一注，最高奖金可达 <span style="color:red" id="spanPlayTypeMoney">1000</span>元。';
            iframe_playtypes.location.href = 'CQSSC_3XFS.htm';
            break;

        case 'playType2808':
            playTypeName = '组合';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 投注号码百、十、个位与开奖号码全部相同且顺序一致，奖金<span style="color:red" id="spanPlayTypeMoney">1000</span>元。';
            iframe_playtypes.location.href = 'CQSSC_3XZH.htm';
            break;

        case 'playType2809':
            playTypeName = '三星组三单式';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 选择2个数字(其中有一个数字必须选择两次)进行组三投注。奖金<span style="color:red" id="spanPlayTypeMoney">320</span>元。';
            iframe_playtypes.location.href = 'CQSSC_2_3.htm';
            break;

        case 'playType2810':
            playTypeName = '三星组三复式';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 从0-9共10个数中任选2-10个号码进行组三的投注。奖金<span style="color:red" id="spanPlayTypeMoney">320</span>元。'
            iframe_playtypes.location.href = 'CQSSC_2_4.htm';
            break;

        case 'playType2811':
            playTypeName = '三星组六单式';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 选择3个数字(不能出现重复)进行组六投注。奖金<span style="color:red" id="spanPlayTypeMoney">160</span>元。';
            iframe_playtypes.location.href = 'CQSSC_2_5.htm';
            break;

        case 'playType2812':
            playTypeName = '三星组六复式';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 从0-9共10个数中任选4-10个号码进行组六的投注。奖金<span style="color:red" id="spanPlayTypeMoney">160</span>元。'
            iframe_playtypes.location.href = 'CQSSC_2_6.htm';
            break;

        case 'playType2813':
            playTypeName = '单式';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 投注号码十、个位与开奖号码全部相同且顺序一致，奖金<span style="color:red" id="spanPlayTypeMoney">100</span>元。  ';
            iframe_playtypes.location.href = 'CQSSC_2XDS.htm';
            break;

        case 'playType2814':
            playTypeName = '复选';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 包括二星、一星投注号码各一注，最高奖金可达<span style="color:red" id="spanPlayTypeMoney">100</span>元。';
            iframe_playtypes.location.href = 'CQSSC_2XFS.htm';
            break;

        case 'playType2815':
            playTypeName = '组合';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 选择十、个位两个号码进行投注，奖金<span style="color:red" id="spanPlayTypeMoney">100</span>元。';
            iframe_playtypes.location.href = 'CQSSC_2XZH.htm';
            break;

        case 'playType2816':
            playTypeName = '二星组选单式';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 选择两个数字进行投注，不包含对子，奖金<span style="color:red" id="spanPlayTypeMoney">50</span>元。 '
            iframe_playtypes.location.href = 'CQSSC_2XZXDS.htm';
            break;

        case 'playType2817':
            playTypeName = '二星组选复式';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 任选3至7个不同数字进行投注，开奖号码不排序，奖金<span style="color:red" id="spanPlayTypeMoney">50</span>元，开奖号码为对子奖金<span style="color:red">  100</span>元。';
            iframe_playtypes.location.href = 'CQSSC_2XZXFS.htm';
            break;

        case 'playType2818':
            playTypeName = '二星组选包点';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 十、个位两个号码之和，开奖号码不排序，奖金<span style="color:red" id="spanPlayTypeMoney">50</span>元，开奖号码为对子奖金<span style="color:red">  100</span>元。 '
            iframe_playtypes.location.href = 'CQSSC_2XZXBD.htm';
            break;

        case 'playType2819':
            playTypeName = '二星组选包胆';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 选择一个数字进行投注，奖金<span style="color:red" id="spanPlayTypeMoney">50</span>元，开奖号码为对子奖金<span style="color:red"> 100</span>元。  ';
            iframe_playtypes.location.href = 'CQSSC_2XZXBDan.htm';
            break;

        case 'playType2820':
            playTypeName = '单式';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 投注号码个位与开奖号码全部相同且顺序一致，奖金<span style="color:red" id="spanPlayTypeMoney">10</span>元。  '
            iframe_playtypes.location.href = 'CQSSC_1XDS.htm';
            break;

        case 'playType2821':
            playTypeName = '组合';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 投注号码个位与开奖号码全部相同且顺序一致，奖金<span style="color:red" id="spanPlayTypeMoney">10</span>元。;'
            iframe_playtypes.location.href = 'CQSSC_1XZH.htm';
            break;

        case 'playType2822':
            playTypeName = '大小单双';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 分别从个、十位中任选一种性质组成一注投注号码，奖金<span style="color:red" id="spanPlayTypeMoney">4</span>元。 '
            iframe_playtypes.location.href = 'CQSSC_CDX.htm';
            break;

        default:
            t = 'playType2801';
            playTypeName = '五星单式';
            $Id("labShowWinMoney").innerHTML = '<br/><br/>&nbsp&nbsp 投注号码万、千、百、十、个位与开奖号码全部相同且顺序一致，奖金<span style="color:red" id="spanPlayTypeMoney">100000</span>元。';
            iframe_playtypes.location.href = 'CQSSC_5XDS.htm';
            break;
    }
    document.getElementById('tbPlayTypeID').value = document.getElementById(t).value;

    $Id('tbPlayTypeName').value = playTypeName;

    HidBtnRand(playTypeName);

    resetPage();
}
function mOver(obj, type) {
    if (type == 1) {
        obj.style.textDecoration = 'underline';
        obj.style.color = '#FF0065';
    }
    else {
        obj.style.textDecoration = 'none';
        obj.style.color = '#226699';


    }
}

function clickPlayClass(i, obj) {
    $Id("labShowWinMoney").style.display = 'none';
    for (var a = 0; a < 5; a++) {
        if ($Id('playTypes' + String(a)) != null) {
            $Id('playTypes' + String(a)).style.display = 'none'
        }
    }
    var pt = $Id('playTypes' + String(i));
    pt.style.display = ''

    switch (i) {
        case 0:
            $Id("labShowWinMoney").style.display = '';
            $Id("labShowWinMoney").innerText = '\n\n 投注号码万、千、百、十、个位与开奖号码全部相同且顺序一致，奖金100000元。';
            break;
        case 1:
            $Id("labShowWinMoney").style.display = '';
            $Id("labShowWinMoney").innerText = '\n\n 投注号码百、十、个位与开奖号码全部相同且顺序一致，奖金1000元。';
            break;
        case 2:
            $Id("labShowWinMoney").style.display = '';
            $Id("labShowWinMoney").innerText = '\n\n 投注号码十、个位与开奖号码全部相同且顺序一致，奖金100元。';
            break;
        case 3:
            $Id("labShowWinMoney").style.display = '';
            $Id("labShowWinMoney").innerText = ' \n\n 投注号码个位与开奖号码全部相同且顺序一致，奖金10元。';
            break;
        case 4:
            $Id("labShowWinMoney").style.display = '';
            $Id("labShowWinMoney").innerText = '\n\n 分别从个、十位中任选一种性质组成一注投注号码，奖金4元。 ';
            break;
        default:
            $Id("labShowWinMoney").style.display = '';
            $Id("labShowWinMoney").innerText = '\n\n 投注号码万、千、百、十、个位与开奖号码全部相同且顺序一致，奖金100000元。';
            break;
    }
    obj.className = 'msplay';

    pt.childNodes[0].checked = true;
    clickPlayType(pt.childNodes[0].id);
}

function SelectXing(r) {
//    if (r <= 5) {
//        var tempR = 5 - r;
//        document.getElementById("tbMiss").value = Lottery_CQSSC_Buy.BindHotAndCoolAndMiss(tempR).value;
//    }
}

function ReloadSchedule() {
    if ($Id("divSchemeAll").style.display == "") {
        schemeAll(28);
    } else {
        newCoBuy(28);
    }
}

//-------------------------------------------------前台页面js代码区----------------------------------------------------

function StrToInt(str) {
    str = str.trim();
    if (str == "")
        return 0;

    var i = parseInt(str, 10);
    if (isNaN(i))
        return 0;

    return i;
}

function CreateUplaodDialog() {

    var o_tbPlayTypeID = document.getElementById("tbPlayTypeID");

    var msgw, msgh, bordercolor;
    msgw = 580; //提示窗口的宽度 
    msgh = 450; //提示窗口的高度 
    //titleheight=25 //提示窗口标题高度 
    //bordercolor="#336699";//提示窗口的边框颜色
    //titlecolor="#99CCFF";//提示窗口的标题颜色
    var sWidth, sHeight;
    sWidth = document.body.offsetWidth;
    sHeight = document.body.offsetHeight;
    var bgObj = document.createElement("div");
    bgObj.setAttribute('id', 'bgDiv2');
    bgObj.style.position = "absolute";
    bgObj.style.top = "0";
    bgObj.style.background = "#777";
    bgObj.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75";
    bgObj.style.opacity = "0.6";
    bgObj.style.left = "0";
    bgObj.style.width = sWidth + "px";
    bgObj.style.height = sHeight + "px";
    bgObj.style.zIndex = "10000";
    document.body.appendChild(bgObj);

    var msgObj = document.createElement("div")
    msgObj.setAttribute("id", "msgDiv2");
    msgObj.setAttribute("align", "center");
    msgObj.style.backcolor = "white";
    //msgObj.style.border="1px solid " + bordercolor; 
    msgObj.style.position = "absolute";
    msgObj.style.left = "50%";
    msgObj.style.top = "20%";
    msgObj.style.font = "12px/1.6em Verdana, Geneva, Arial, Helvetica, sans-serif";
    msgObj.style.marginLeft = "-225px";
    msgObj.style.marginTop = document.documentElement.scrollTop + "px";
    msgObj.style.width = msgw + "px";
    msgObj.style.height = msgh + "px";
    msgObj.style.textAlign = "center";
    msgObj.style.lineHeight = "25px";
    msgObj.style.zIndex = "10001";

    document.body.appendChild(msgObj);

    var txt = document.createElement("p");
    txt.style.margin = "1em 0"
    txt.setAttribute("id", "msgTxt2");

    var dialog = '<table><tr><td style="background-color: #AFBCD6; padding: 10px;font-size:12px"><table style="width: 100%;background-color:White;" border="0" cellpadding="0" cellspacing="1"><tr><td height="36" bgcolor="#6D84B4" class="bai14" style="padding: 0px 10px 0px 15px;text-align:left;"><span id="lbLotteryName"></span> 第 <span id="lbIsuse"></span>&nbsp;期 粘贴投注</td></tr><tr><td style="padding: 5px;" align="center"><textarea id="tbLotteryNumbers" style="width:98%; height:160px;"></textarea></td></tr><tr><td><table width="100%" border="0" align="right" cellpadding="0" cellspacing="0"><tr><td style="text-align:left;"><table cellpadding="0" cellspacing="0" style="width:100%;"><tr><td style="text-align:right;">方案上传：</td><td colspan="2"><iframe id="frame_Upload" name="frame_Upload" frameborder="0" src="../Home/Room/SchemeUpload.aspx?id=' + document.getElementById('HidLotteryID').value + '&amp;PlayType=' + document.getElementById("tbPlayTypeID").value + '&amp;Isuse=' + document.getElementById('HidIsuseID').value + '" width="100%" scrolling="no" height="30"></iframe></td></tr></table></td></tr><tr><td style="text-align:right; padding-right:10px;"><font color="#ff0000">【注】</font>如果选择方案文件<font color="#ff0000">(.txt格式)</font>上传,上面的投注内容将被清除并被替换成方案文件里面的内容。<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 方案文件中请输入规范的投注内容，多注请用回车换行。 <span class="blue12"><a href="../Home/Room/SchemeExemple.aspx?id=' + document.getElementById("HidLotteryID").value + '" target="_blank">请参看格式规范</a></span></td></tr><tr><td style="background-color:#f2f2f2; padding:10px;"><table width="280" border="0" align="right" cellpadding="0" cellspacing="0"><tbody style="cursor: pointer; color: White;"><tr><td width="19%" align="right"><table width="88" border="0" cellpadding="0" cellspacing="1" bgcolor="#FF3300"><tr><td height="23" align="center" bgcolor="#FD9A00" onclick=" btn_OK();">确定</td></tr></table></td><td width="32%" align="right"><table width="88" border="0" cellpadding="0" cellspacing="1" bgcolor="#FF3300"><tr><td height="23" align="center" bgcolor="#FD9A00" onclick=" btn_Close();">取消</td></tr></table></td><td width="32%" align="right"><table width="88" border="0" cellpadding="0" cellspacing="1" bgcolor="#FF3300"><tr><td height="23" align="center" bgcolor="#FD9A00" onclick=" btn_Close();">关闭窗口</td></tr></table></td></tr></tbody></table></td></tr></table></td></tr></table></td></tr></table>';

    txt.innerHTML = dialog;

    document.getElementById("msgDiv2").appendChild(txt);
    document.getElementById("tbLotteryNumbers").focus();

    document.getElementById("lbIsuse").innerHTML = document.getElementById('currIsuseName').innerHTML;
    document.getElementById("lbLotteryName").innerHTML = LotteryName;

    document.getElementById("list_LotteryNumber").style.display = "none";
}

function btn_Close() {
    document.body.removeChild(bgDiv2);
    document.body.removeChild(msgDiv2);

    try {
        document.getElementById("list_LotteryNumber").style.display = "";
    } catch (e) { }
    document.getElementById("list_LotteryNumber").style.display = "";
}

function showSameHeight() {
//    if (document.getElementById("menu_left").clientHeight < document.getElementById("menu_right").clientHeight) {
//        document.getElementById("menu_left").style.height = document.getElementById("menu_right").offsetHeight + "px";
//    }
//    else {
//        if (document.getElementById("menu_right").offsetHeight >= 860) {
//            document.getElementById("menu_left").style.height = document.getElementById("menu_right").offsetHeight + "px";
//        }
//        else {
//            document.getElementById("menu_left").style.height = "860px";
//        }
//    }
}


function btn_OK() {
    document.getElementById("list_LotteryNumber").style.display = "";

    try {
        var LotteryNumber = Lottery_CQSSC_Buy.AnalyseScheme(document.getElementById("tbLotteryNumbers").value, document.getElementById('HidLotteryID').value, document.getElementById('tbPlayTypeID').value);

        if (LotteryNumber == null || LotteryNumber.value == null) {
            document.body.removeChild(bgDiv2);
            document.body.removeChild(msgDiv2);
            alert("从方案文件中没有提取到符合书写规则的投注内容。");

            return;
        }

        while (o_list_LotteryNumber.length > 0) {
            o_list_LotteryNumber.remove(0);
        }

        var r = LotteryNumber.value;

        if (typeof (r) != "string") {
            document.body.removeChild(bgDiv2);
            document.body.removeChild(msgDiv2);
            alert("从方案文件中没有提取到符合书写规则的投注内容。");

            return;
        }
    }
    catch (e) {
        document.body.removeChild(bgDiv2);
        document.body.removeChild(msgDiv2);
        alert("从方案文件中没有提取到符合书写规则的投注内容。");

        return;
    }

    o_tb_LotteryNumber.value = "";
    o_lab_Num.innerText = "0";

    var Lotterys = r.split("\n");

    for (var i = 0; i < Lotterys.length; i++) {
        var str = Lotterys[i].trim();
        if (str == "")
            continue;
        strs = str.split("|");

        if (strs.length != 2) {
            continue;
        }

        str = strs[0].trim();
        if (str == "") {
            continue;
        }
        var Num = StrToInt(strs[1]);
        if (Num < 1)
            continue;

        var customOptions = document.createElement("OPTION");
        customOptions.text = str;
        customOptions.value = Num;
        o_list_LotteryNumber.add(customOptions, o_list_LotteryNumber.length);

        o_tb_LotteryNumber.value += str + "\n";
        o_lab_Num.innerText = StrToInt(o_lab_Num.innerText) + Num;
    }

    //document.all["tbLotteryNumbers"].value = "";

    CalcResult();

    document.body.removeChild(bgDiv2);
    document.body.removeChild(msgDiv2);
}

function btn_OKClick() {

    if (!$Id("chkAgrrement").checked) {
        alert("请先阅读用户电话短信投注协议，谢谢！");
        return false;
    }
    if ($Id("currIsuseEndTime").innerHTML == "本期已截止投注" < 0) {
        alert("本期投注已截止，谢谢。");

        return false;
    }

    var multiple = StrToInt(o_tb_Multiple.value);
    var SumNum = StrToInt(o_lab_Num.innerText);
    var Share = StrToInt(o_tb_Share.value);
    var BuyShare = StrToInt(o_tb_BuyShare.value);
    var AssureShare = StrToInt(o_tb_AssureShare.value);
    var SumMoney = StrToInt(o_lab_SumMoney.innerText);
    var AssureMoney = StrToFloat(o_lab_AssureMoney.innerText);
    var BuyMoney = StrToFloat(o_lab_BuyMoney.innerText);

    if (SumNum < 1) {
        alert("请输入投注内容。");
        return false;
    }
    if (multiple < 1) {
        alert("请输入正确的倍数。");
        o_tb_Multiple.focus();
        return false;
    }
    if (Share < 1) {
        alert("请输入正确的份数。");
        o_tb_Share.focus();
        return false;
    }
    if (StrToFloat(o_lab_ShareMoney.innerText) < 1) {
        alert("每份金额不能小于 1 元。");
        o_tb_Share.focus();
        return false;
    }

    //追号
    if ($Id("Chase").checked) {
        if (StrToInt($Id("LbSumMoney").innerText) > 0) {

            if (StrToInt($Id("tbAutoStopAtWinMoney").value) < 0) {
                alert("追号截止金额错误!");

                return;
            }

            $Id("tb_hide_ChaseBuyedMoney").value = $Id("LbChaseMoney").innerText;

            var TipStr = '您要申请' + LotteryName + $Id("tbPlayTypeName").value + '投注，详细内容：\n\n';

            TipStr += "　　您的认购和保底保底金额：　" + $Id("LbChaseMoney").innerText + " 元\n\n";

            if (!confirm(TipStr + "按“确定”即表示您已阅读《" + LotteryName + "用户投注协议》并立即提交代购方案，确定要提交投注方案吗？"))
                return false;
        }
        else {
            alert("请输入投注内容!");
            return false;
        }
    }
    else {

        var Opt_InitiateSchemeLimitScale = 0;

        if ((Opt_InitiateSchemeLimitLowerScaleMoney > 0) && (Opt_InitiateSchemeLimitUpperScaleMoney > Opt_InitiateSchemeLimitLowerScaleMoney) && (Opt_InitiateSchemeLimitUpperScale > 0) && (Opt_InitiateSchemeLimitLowerScale > Opt_InitiateSchemeLimitUpperScale)) {
            if (SumMoney <= Opt_InitiateSchemeLimitLowerScaleMoney) {
                Opt_InitiateSchemeLimitScale = Opt_InitiateSchemeLimitLowerScale;
            }
            else if (SumMoney >= Opt_InitiateSchemeLimitUpperScaleMoney) {
                Opt_InitiateSchemeLimitScale = Opt_InitiateSchemeLimitUpperScale;
            }
            else {
                Opt_InitiateSchemeLimitScale = Opt_InitiateSchemeLimitLowerScale - ((SumMoney - Opt_InitiateSchemeLimitLowerScaleMoney) * ((Opt_InitiateSchemeLimitLowerScale - Opt_InitiateSchemeLimitUpperScale) / (Opt_InitiateSchemeLimitUpperScaleMoney - Opt_InitiateSchemeLimitLowerScaleMoney)));
            }
        }
        else if (Opt_InitiateSchemeLimitLowerScale == Opt_InitiateSchemeLimitUpperScale) {
            Opt_InitiateSchemeLimitScale = Opt_InitiateSchemeLimitLowerScale;
        }

        if (Opt_InitiateSchemeLimitScale <= 0) {
            Opt_InitiateSchemeLimitScale = 0.1;
        }

        if ((BuyShare) < Math.round(Share * Opt_InitiateSchemeLimitScale)) {
            if (Opt_InitiateSchemeLimitLowerScale == Opt_InitiateSchemeLimitUpperScale) {
                alert("发起人最少必须认购 " + (Opt_InitiateSchemeLimitLowerScale * 100) + "%。(" + Math.round(Share * Opt_InitiateSchemeLimitLowerScale) + ' 份， ' + (Math.round(Share * Opt_InitiateSchemeLimitLowerScale) * StrToFloat(o_lab_ShareMoney.innerText)) + ' 元)');
            }
            else {
                alert("此方案发起人认购(不含保底)最少必须达到 " + Math.round(Share * Opt_InitiateSchemeLimitScale) + " 份。\r\n\r\n" +
                    "发起方案最少认购比例说明：\r\n" +
                    "方案金额小于或等于 " + Opt_InitiateSchemeLimitLowerScaleMoney + " 元，最少认购 " + Opt_InitiateSchemeLimitLowerScale * 100 + "%，\r\n" +
                    "方案金额大于或等于 " + Opt_InitiateSchemeLimitUpperScaleMoney + " 元，最少认购 " + Opt_InitiateSchemeLimitUpperScale * 100 + "%，\r\n" +
                    "方案金额在 " + Opt_InitiateSchemeLimitLowerScaleMoney + " 元至 " + Opt_InitiateSchemeLimitUpperScaleMoney + " 元之间的最少认购比例平滑递减。\r\n\r\n" +
                    "此方案金额的最少认购比例是 " + Round(Opt_InitiateSchemeLimitScale, 2) * 100 + "% 。");
            }

            o_tb_BuyShare.focus();
            return false;
        }

        if ((BuyShare + AssureShare) > Share) {
            alert("保底和购买的份数大于总份数。");
            o_tb_AssureShare.focus();
            return false;
        }

        if ((SumMoney < o_tb_Price) || (SumMoney > 1000000)) {
            alert("单个方案的总金额必须在" + o_tb_Price + "元至 1000000 元之间。");
            return false;
        }

        var TipStr = '您要发起' + LotteryName + $Id("tbPlayTypeName").value + '方案，详细内容：\n\n';
        TipStr += "　　注　数：　" + SumNum + "\n";
        TipStr += "　　倍　数：　" + multiple + "\n";
        TipStr += "　　总金额：　" + o_lab_SumMoney.innerText + " 元\n\n";
        TipStr += "　　总份数：　" + Share + " 份\n";
        TipStr += "　　每　份：　" + o_lab_ShareMoney.innerText + " 元\n\n";
        TipStr += "　　保　底：　" + AssureShare + " 份，" + o_lab_AssureMoney.innerText + " 元\n";
        TipStr += "　　购　买：　" + BuyShare + " 份，" + o_lab_BuyMoney.innerText + " 元\n\n";

        if (!confirm(TipStr + "按“确定”即表示您已阅读《" + LotteryName + "投注协议》并立即提交方案，确定要提交方案吗？"))
            return false;
    }

    $Id("tb_hide_SumMoney").value = o_lab_SumMoney.innerText;
    $Id("tb_hide_AssureMoney").value = o_lab_AssureMoney.innerText;
    $Id("tb_hide_SumNum").value = o_lab_Num.innerText;

    __doPostBack('btn_OK', '');
}

function Cancel() {
    document.body.removeChild(bgDiv);
    document.body.removeChild(msgDiv);

    try {
        document.getElementById("list_LotteryNumber").style.display = "";
    } catch (e) { }

    return false;
}

function showAgreement(t) {
    if (t.checked) {
        document.getElementById('btnOK').disabled = "";

    }
    else {
        document.getElementById('btnOK').disabled = "disabled";
    }

}

function mOver(obj, type) {
    if (type == 1) {
        obj.style.textDecoration = "underline";
        obj.style.color = "#FF0065";
    }
    else {
        obj.style.textDecoration = "none";
        obj.style.color = "#226699";


    }
}
function CheckShare2(type, obj) {
    if (obj == undefined) {
        return;
    }

    var v;
    switch (type) {
        case 1:
            v = "share";
            break;
        case 2:
            v = "buyedShare";
            break;
        case 3:
            v = "assureShare";
            break;
    }

    var obj_TxtMoney = $Id(obj.id.replace(v, "money"));
    var obj_TxtShare = $Id(obj.id.replace(v, "share"));
    var obj_TxtBuyedShare = $Id(obj.id.replace(v, "buyedShare"));
    var obj_TxtAssureShare = $Id(obj.id.replace(v, "assureShare"));

    var money = StrToInt(obj_TxtMoney.value);
    var share = StrToInt(obj_TxtShare.value);
    var buyedShare = StrToInt(obj_TxtBuyedShare.value);
    var assureShare = StrToInt(obj_TxtAssureShare.value);

    var OK = false;

    if (share < 1 || buyedShare < 1 || assureShare < 0) {
        alert("输入的份数非法。");
        obj_TxtShare.value = "1";
        obj_TxtBuyedShare.value = "1";
        obj_TxtAssureShare.value = "0";
        OK = false;
        return;
    }
    else if (share == 1) {
        OK = true;
    }
    else {
        if (share > 1) {

            var ShareMoney = money / share;
            var ShareMoney2 = Math.round(ShareMoney * 100) / 100;

            if (ShareMoney == ShareMoney2)
                OK = true;

            if (ShareMoney < 1) {
                OK = false;
            }
        }
    }

    if (!OK) {
        if (confirm("份数为 0 或者不能除尽，将产生误差，并且金额不能小于 1 元。按“确定”重新输入，按“取消”自动更正为 1 份，请选择。")) {
            obj_TxtShare.focus();
            return;
        }
        else {
            obj_TxtShare.value = "1";
            obj_TxtBuyedShare.value = "1";
            obj_TxtAssureShare.value = "0";
        }
    } else {
        if (share < buyedShare) {
            alert("认购份数不能大于总份数！");
            obj_TxtBuyedShare.value = share;
            obj_TxtAssureShare.value = "0";
            return;
        }

        if (share < assureShare) {
            alert("保底份数不能大于总份数！");
            obj_TxtAssureShare.value = share - buyedShare;
            return;
        }

        if (share < buyedShare + assureShare) {
            alert("认购份数和保底份数的和不能大于总份数！");
            obj_TxtAssureShare.value = share - buyedShare;
            return;
        }

        var Opt_InitiateSchemeLimitScale = 0;

        if ((Opt_InitiateSchemeLimitLowerScaleMoney > 0) && (Opt_InitiateSchemeLimitUpperScaleMoney > Opt_InitiateSchemeLimitLowerScaleMoney) && (Opt_InitiateSchemeLimitUpperScale > 0) && (Opt_InitiateSchemeLimitLowerScale > Opt_InitiateSchemeLimitUpperScale)) {
            if (money <= Opt_InitiateSchemeLimitLowerScaleMoney) {
                Opt_InitiateSchemeLimitScale = Opt_InitiateSchemeLimitLowerScale;
            }
            else if (money >= Opt_InitiateSchemeLimitUpperScaleMoney) {
                Opt_InitiateSchemeLimitScale = Opt_InitiateSchemeLimitUpperScale;
            }
            else {
                Opt_InitiateSchemeLimitScale = Opt_InitiateSchemeLimitLowerScale - ((money - Opt_InitiateSchemeLimitLowerScaleMoney) * ((Opt_InitiateSchemeLimitLowerScale - Opt_InitiateSchemeLimitUpperScale) / (Opt_InitiateSchemeLimitUpperScaleMoney - Opt_InitiateSchemeLimitLowerScaleMoney)));
            }
        }
        else if (Opt_InitiateSchemeLimitLowerScale == Opt_InitiateSchemeLimitUpperScale) {
            Opt_InitiateSchemeLimitScale = Opt_InitiateSchemeLimitLowerScale;
        }

        if (Opt_InitiateSchemeLimitScale <= 0) {
            Opt_InitiateSchemeLimitScale = 0.1;
        }

        if ((buyedShare) < Math.round(share * Opt_InitiateSchemeLimitScale)) {
            if (Opt_InitiateSchemeLimitLowerScale == Opt_InitiateSchemeLimitUpperScale) {
                alert("发起人最少必须认购 " + (Opt_InitiateSchemeLimitLowerScale * 100) + "%。(" + Math.round(share * Opt_InitiateSchemeLimitLowerScale) + ' 份， ' + (Math.round(share * Opt_InitiateSchemeLimitLowerScale) * money / share) + ' 元)');
            }
            else {
                alert("此方案发起人认购(不含保底)最少必须达到 " + Math.round(share * Opt_InitiateSchemeLimitScale) + " 份。\r\n\r\n" +
                    "发起方案最少认购比例说明：\r\n" +
                    "方案金额小于或等于 " + Opt_InitiateSchemeLimitLowerScaleMoney + " 元，最少认购 " + Opt_InitiateSchemeLimitLowerScale * 100 + "%，\r\n" +
                    "方案金额大于或等于 " + Opt_InitiateSchemeLimitUpperScaleMoney + " 元，最少认购 " + Opt_InitiateSchemeLimitUpperScale * 100 + "%，\r\n" +
                    "方案金额在 " + Opt_InitiateSchemeLimitLowerScaleMoney + " 元至 " + Opt_InitiateSchemeLimitUpperScaleMoney + " 元之间的最少认购比例平滑递减。\r\n\r\n" +
                    "此方案金额的最少认购比例是 " + Round(Opt_InitiateSchemeLimitScale, 2) * 100 + "% 。");
            }

            obj_TxtBuyedShare.focus();
            obj_TxtBuyedShare.value = share;
            obj_TxtAssureShare.value = "0";
        }
    }
    accountAllMoney();
}

//当页面加载完后，要执行的系列事件
function PageEvent() {

    //第二步（根据url参数显示相应的内容）
    var fromUrlParam = location.search;
    if (fromUrlParam.indexOf("CoBuy") != -1) {
        newCoBuy(28);
    }
    else {
        newBuy(28);
    }

    scrollTo(0, 147);
}

//************************************************************事件执行区***************************************

//页面加载的时候，加载相应的数据
function Page_load() {

    //第一步（加载彩种）
    loadLottery(28);

}