

//************************************************************全局变量定义区*******************************************

//当前彩种编号
var currentLotteryID = null;
//彩种名称
var LotteryName = null;

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

var FCExperts_lcal = null;               //本地福彩专家列表值
var bonusNumbers_lcal = null;            //本地中奖列表值

//发起方案条件
var Opt_InitiateSchemeLimitLowerScaleMoney = 100;
var Opt_InitiateSchemeLimitLowerScale = 0.2;
var Opt_InitiateSchemeLimitUpperScaleMoney = 10000;
var Opt_InitiateSchemeLimitUpperScale = 0.05;



//************************************************************方法函数定义区***************************************


//---------------------------------------页面加载功能区代码-------------------------------------------------

//初始化全局变量数据
function init() {
    o_tb_LotteryNumber = $Id("tb_LotteryNumber");
    o_list_LotteryNumber = $Id("list_LotteryNumber");
    o_tb_Multiple = $Id("tb_Multiple");
    o_tb_Share = $Id("tb_Share");
    o_tb_SchemeBonusScale = $Id("tb_SchemeBonusScale");
    o_tb_SchemeBonusScalec = $Id("tb_SchemeBonusScalec");
    o_tb_AssureShare = $Id("tb_AssureShare");
    o_tb_BuyShare = $Id("tb_BuyShare");
    o_tb_Title = $Id("tb_Title");
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

    o_lb_LbSumMoney = $Id("LbSumMoney");

    try {
        o_tb_Price = $Id("HidPrice").value;
    } catch (ex) { o_tb_Price = 2; }


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

    if (!isGetSchemeBonusScalec) {
        try {

            Lottery_Buy_22X5.GetSchemeBonusScalec(currentLotteryID, GetSchemeBonusScalec_callback);

        }
        catch (e) {
            time_GetSchemeBonusScalec = setTimeout("Lottery_Buy_22X5.GetSchemeBonusScalec(" + currentLotteryID + ",GetSchemeBonusScalec_callback);", 2000);
        }
    }
}

function GetSchemeBonusScalec_callback(response) {

    if (response == null || response.value == null) {

        time_GetSchemeBonusScalec = setTimeout("Lottery_Buy_22X5.GetSchemeBonusScalec(" + currentLotteryID + ",GetSchemeBonusScalec_callback);", 2000);

        return;
    }

    //将time_GetSchemeBonusScalec移除
    if (time_GetSchemeBonusScalec != null) {
        clearTimeout(time_GetSchemeBonusScalec);
    }

    var v = response.value.split('|');

    if (v.length != 7) {

        return;
    }

    o_tb_SchemeBonusScale.value = v[0];
    o_tb_SchemeBonusScalec.value = v[0];

    Opt_InitiateSchemeLimitLowerScaleMoney = v[1];
    Opt_InitiateSchemeLimitLowerScale = v[2];
    Opt_InitiateSchemeLimitUpperScaleMoney = v[3];
    Opt_InitiateSchemeLimitUpperScale = v[4];

    currentLotteryID = v[5];
    LotteryName = v[6];

    isGetSchemeBonusScalec = true;
}

//定时读取最近的开奖信息的定时器
var time_GetServerTime = null;

//获取服务器时间
function GetServerTime(lotteryID) {

    currentLotteryID = lotteryID;

    try {

        Lottery_Buy_22X5.GetSysTime(GetServerTime_callback);

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

    setTimeout("showIsuseTime(" + IsuseEndTime.getTime() + ", " + TimePoor + ", " + 1000 + "," + currentLotteryID + ")", 1000);

}

//显示当前期的投注时间
var lockIsuseTime = null;
function showIsuseTime(eTime, tPoor, goTime, lotteryID) {

    if (goTime >= 600000)//10分钟
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


//获取当前投注奖期信息
var time_GetIsuseInfo = null;
function GetIsuseInfo(lotteryID) {

    currentLotteryID = lotteryID;

    try {

        Lottery_Buy_22X5.GetIsuseInfo(lotteryID, GetIsuseInfo_callback);

    }
    catch (e) {

        time_GetIsuseInfo = setTimeout("GetIsuseInfo(" + lotteryID + ");", 2000);
    }
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

    if (v.indexOf("|") == -1) {
        return;
    }

    var arrInfo = v.split('|');

    if (arrInfo.length != 3) {
        return;
    }

    var lastIsuse = arrInfo[1];
    var currIsuse = arrInfo[0];
    var chaseIsuse = arrInfo[2];
  
    lastIsuseInfo.innerHTML = lastIsuse;

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
    currIsuseName.innerText = arrcurrIsuse[1];
    currIsuseEndTime.innerText = arrcurrIsuse[2].replace("/", "-").replace("/", "-");
    $Id("HidIsuseEndTime").value = arrcurrIsuse[2];
}

//获取已开奖号
var time_GetBindWinNumber = null;
function GetBindWinNumber(lotteryID) {

    currentLotteryID = lotteryID;

    try {

        Lottery_Buy_22X5.GetWinNumber(lotteryID, GetBindWinNumber_callback);

    }
    catch (e) {

        time_GetBindWinNumber = setTimeout("GetBindWinNumber(" + lotteryID + ");", 2000);
    }
}

function GetBindWinNumber_callback(response) {


    if (response == null || response.value == null) {

        time_GetBindWinNumber = setTimeout("GetBindWinNumber(" + currentLotteryID + ");", 2000);

        return;
    }

    //将time_GetBindWinNumber移除
    if (time_GetBindWinNumber != null) {
        clearTimeout(time_GetBindWinNumber);
    }

    bonusNumbers_lcal = response.value;

    BindWinNumber(0);

}

function BindWinNumber(type) {

    if (bonusNumbers_lcal == null) {

        time_GetBindWinNumber = setTimeout("GetBindWinNumber(" + currentLotteryID + ");", 2000);

        return;
    }

    var numbers = bonusNumbers_lcal.split('|');
    var pageCount = numbers.length - 1;

    if (type == 1) {
        currentPage--;
        if (currentPage < 0) {
            currentPage = 0;
        }
    }
    else if (type == 2) {
        currentPage++;
        if (currentPage >= pageCount) {
            currentPage--;
        }
    }
    else if (type == 3) {
        currentPage = pageCount;
    }
    else {
        currentPage = 0;
    }

    var headHtm = "<table width=\"210\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\" style=\"margin-top:3px;\" bgcolor=\"#DDDDDD\">";
    headHtm += "<tr>";
    headHtm += "<td align=\"center\" bgcolor=\"#F4F9FC\" class=\"blue12\">期号</td>";

    if (currentLotteryID != 39 && currentLotteryID != 13 && currentLotteryID != 65 && currentLotteryID != 5) {
        headHtm += "<td  height=\"25\" align=\"center\" bgcolor=\"#F4F9FC\" class=\"blue12\">";
        headHtm += "日期";
        headHtm += "</td>";
    }

    headHtm += "<td align=\"center\" bgcolor=\"#F4F9FC\" class=\"blue12\">号码</td></tr>";
    headHtm += numbers[currentPage];
    headHtm += "</table>";

    headHtm += "<div style=\"text-align:right;\"><span id=\"Span1\" class=\"hui12\" ><a href=\"../TrendCharts/TC22X5/Default.aspx\" target=\"_blank\">更多&gt;&gt;</a></span></div>";

    $Id("tdWinLotteryNumber").innerHTML = headHtm;

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

    //获取投注时间信息
    GetServerTime(lotteryID);

    //获取开奖号码列表信息
    GetBindWinNumber(lotteryID);
}

//---------------------------------------投注功能区代码-------------------------------------------------

function HidBtnRand(playTypeName) {
    var isHidRandTR = playTypeName.indexOf("单式") < 0 || playTypeName.indexOf("组选") > -1;

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
    $Id("btn_OK").disabled = "";
    try { accountAllMoney(); } catch (e) { }
    return true;
}

function HidBtnRand(playTypeName) {
    var isHidRandTR = playTypeName.indexOf("单式") < 0 || playTypeName.indexOf("组选") > -1;

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

    if (obj.checked != true) {
        obj_TxtBNum.disabled = "disabled";
        obj_TxtBNum.value = "1";
        obj_TxtMoney.value = "0";
    }
    else {
        obj_TxtBNum.disabled = "";
    }

    accountAllMoney();
}

function accountAllMoney() {
    var arrTable = new Array();
    var needMoney = 0;
    var obj_Name = "";
    var i = 0;

    arrTable[0] = window.$Id("div_QH_Today");
    for (j = 0; j < arrTable.length; j++) {
        var objs = arrTable[j].getElementsByTagName("input");
        var obj_txtMoney, obj_txtBNum;
        for (var i = 0; i < objs.length; i++) {
            if (objs[i].type.toLowerCase() == "checkbox")
                if (objs[i].checked == true) {
                obj_txtBNum = $Id(objs[i].id.replace("check", "times"));
                obj_txtMoney = $Id(objs[i].id.replace("check", "money"));
                obj_Name = $Id(objs[i].id.substring(0, (objs[i].id.length - 6)));
                obj_txtMoney.value = parseInt(obj_txtBNum.value) * parseInt(lab_SumMoney.innerText);
                obj_txtMoney.innerText = obj_txtMoney.value;
                needMoney = parseInt(needMoney) + parseInt(obj_txtMoney.value);
                i++;
            }
        }
    }

    $Id("LbSumMoney").innerText = needMoney;
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
function ChangeBackImage(index, lotteryID) {
    var table = document.getElementById("TabMenu");
    var arr = new Array(1, 3, 5, 7, 9);
    for (var i = 0; i < arr.length; i++) {
        if (index == arr[i]) {
            table.childNodes[arr[i]].className = "redMenu";
            table.childNodes[arr[i]].style.fontWeight = "bold";
            table.childNodes[arr[i]].style.cursor = "pointer";


        }
        else {
            table.childNodes[arr[i]].className = "whiteMenu";
            table.childNodes[arr[i]].style.fontWeight = "normal";
            table.childNodes[arr[i]].style.cursor = "pointer";
        }
    }
}

function newBuy(lotteryID) {

    $Id("divNewBuy").style.display = "";
    $Id("divCoBuy").style.display = "none";
    $Id("divFollowScheme").style.display = "none";
    $Id("divSchemeAll").style.display = "none";
    $Id("divPlayTypeIntroduce").style.display = "none";
    ChangeBackImage(1, lotteryID);

    var menu = document.getElementById("tbPlayTypeMenu" + String(lotteryID));

    if (menu == null) {
        $Id("playType" + String(lotteryID) + "01").checked = true;
        clickPlayType(100 * lotteryID + 01);
    } else {
        menu.rows[0].cells[1].click();
    }
}

function newCoBuy(lotteryID) {
    $Id("divNewBuy").style.display = "none";
    $Id("divCoBuy").style.display = "";
    $Id("divFollowScheme").style.display = "none";
    $Id("divSchemeAll").style.display = "none";
    $Id("divPlayTypeIntroduce").style.display = "none";

    $Id("iframeCoBuy").src = "../Home/Room/CoBuy.aspx?Radom=" + Math.random() + "&LotteryID=" + lotteryID + "&IsuseID=" + $Id("HidIsuseID").value;

    ChangeBackImage(3, lotteryID);
}

function followScheme(lotteryID) {
    $Id("divNewBuy").style.display = "none";
    $Id("divCoBuy").style.display = "none";
    $Id("divFollowScheme").style.display = "";
    $Id("divSchemeAll").style.display = "none";
    $Id("divPlayTypeIntroduce").style.display = "none";

    if ($Id("iframeFollowScheme").src == "") {
        $Id("iframeFollowScheme").src = "../Home/Room/FollowScheme.aspx?LotteryID=" + lotteryID;
    }

    ChangeBackImage(5, lotteryID);
}

function schemeAll(lotteryID) {
    $Id("divNewBuy").style.display = "none";
    $Id("divCoBuy").style.display = "none";
    $Id("divFollowScheme").style.display = "none";
    $Id("divPlayTypeIntroduce").style.display = "none";
    $Id("divSchemeAll").style.display = "";

    $Id("divLoding").style.display = "";
    $Id("iframeSchemeAll").style.display = "none";
    
    $Id("iframeSchemeAll").src = "../Home/Room/SchemeAll.aspx?Radom=" + Math.random() + "&LotteryID=" + lotteryID + "&IsuseID=" + $Id("HidIsuseID").value;

    ChangeBackImage(7, lotteryID);
}


function PlayTypeIntroduce(lotteryID) {
    $Id("divNewBuy").style.display = "none";
    $Id("divCoBuy").style.display = "none";
    $Id("divFollowScheme").style.display = "none";
    $Id("divPlayTypeIntroduce").style.display = "";
    $Id("divSchemeAll").style.display = "none";

    $Id("iframePlayTypeIntroduce").src = "../Home/Room/Help/help_" + lotteryID + ".htm";

    ChangeBackImage(9, lotteryID);
}

//幸运号的上一个选项卡
var lastXYJX = null;
function ClickXYJX(obj, type) {

    if (lastXYJX == null)
        lastXYJX = $Id("hrefXZ");

    if (lastXYJX != null) {
        lastXYJX.parentNode.background = "";
        document.getElementById(lastXYJX.id.replace("href", "span")).style.display = "none";
    }

    if (obj.id == "hrefCSRQ") {
        obj.parentNode.background = "../Home/Room/images/ssq_qh_2.jpg";
    } else {
    obj.parentNode.background = "../Home/Room/images/ssq_qh_1.jpg";
    }

    document.getElementById(obj.id.replace("href", "span")).style.display = "";
    document.getElementById("HidType").value = type;

    lastXYJX = obj;
    document.getElementById("HidLuckNumber").value = "";
    var tds = document.getElementById("tdLuckNumber").getElementsByTagName("td");
    for (var i = 0; i < tds.length; i++) {
        if (tds[i].id.indexOf("tdLuckNumber") > -1) {
            tds[i].innerHTML = "-";
        }
    }

    return false;
}

var moving;
var number;
var isMove = true;
function GetLuckNumber(lotteryID) {
    var type = document.getElementById("HidType").value;
    var name = "";
    switch (type) {
        case "1":
            name = document.getElementById("ddlXiZuo").value;
            break;
        case "2":
            name = document.getElementById("ddlSX").value;
            break;
        case "3":
            var date = document.getElementById("tbDate").value;

            if (date == "") {
                alert("请输入出生日期！");
                document.getElementById("tbDate").focus();
                return false;
            }

            name = date;
            break;
        case "4":
            name = document.getElementById("tbName").value;

            if (name == "" || name == "支持中英文") {
                alert("请输入姓名！");
                document.getElementById("tbName").focus();
                return false;
            } break;
    }

    var v = Lottery_Buy_22X5.GenerateLuckLotteryNumber(lotteryID, type, name).value;
    if (v.split("|").length < 2) {
        alert(v);
        document.getElementById("tbDate").value = "";
    } else {
        document.getElementById("HidLuckNumber").value = v.split("|")[0];

        number = v.split("|")[1].split(" ");

        moving = setInterval("BallMoving()", 50);

        setTimeout("BindLuckNumber()", 1000);
        isMove = true;
    }

}

//球滚动
function BallMoving() {
    if (isMove) {
        for (var i = 0; i < number.length; i++) {
            document.getElementById("tdLuckNumber" + i.toString()).innerHTML = number[GetRandNumber(number.length - 1)];
        }
    }
}

function BindLuckNumber() {
    clearInterval(moving);
    isMove = false;
    for (var i = 0; i < number.length; i++) {
        document.getElementById("tdLuckNumber" + i.toString()).innerHTML = number[i];
    }
}

function BetLuckNumber(lotteryID) {
    if (document.getElementById("HidLuckNumber").value == "") {
        alert("请先获取幸运号码！");

        return false;
    }
    $Id("playType" + String(lotteryID) + "01").checked = true;
    clickPlayType(100 * lotteryID + 01);

    var customOptions = document.createElement("OPTION");
    customOptions.text = document.getElementById("HidLuckNumber").value;
    customOptions.value = 1;
    o_list_LotteryNumber.add(customOptions, o_list_LotteryNumber.length);
    o_tb_LotteryNumber.value += document.getElementById("HidLuckNumber").value + "\n";
    o_lab_Num.innerText = StrToInt(o_lab_Num.innerText) + 1;
    CalcResult();
    calculateAllMoney();

    return CreateLogin('btn_OKClick();');
}

function UpdateLotteryNumber() {
    if (o_list_LotteryNumber.length < 1) {
        alert("您还没有输入投注内容。");
        return false;
    }

    for (i = 0; i < o_list_LotteryNumber.length; i++) {
        if (o_list_LotteryNumber.options[i].selected)
            document.getElementById("HidSelectedLotteryNumber").value = o_list_LotteryNumber.options[i].text.trim();
    }

    iframe_playtypes.SelectLotteryNumber();
}

//---------------------------------------页面Js代码区---------------------------------------------------------


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

    var dialog = '<table><tr><td style="background-color: #AFBCD6; padding: 10px;font-size:12px"><table style="width: 100%;background-color:White;" border="0" cellpadding="0" cellspacing="1"><tr><td height="36" bgcolor="#6D84B4" class="bai14" style="padding: 0px 10px 0px 15px;text-align:left;"><span id="lbLotteryName"></span> 第 <span id="lbIsuse"></span>&nbsp;期 粘贴投注</td></tr><tr><td style="padding: 5px;" align="center"><textarea id="tbLotteryNumbers" style="width:98%; height:160px;"></textarea></td></tr><tr><td><table width="100%" border="0" align="right" cellpadding="0" cellspacing="0"><tr><td style="text-align:left;"><table cellpadding="0" cellspacing="0" style="width:100%;"><tr><td style="text-align:right;">方案上传：</td><td colspan="2"><iframe id="frame_Upload" name="frame_Upload" frameborder="0" src="../Home/Room/SchemeUpload.aspx?id=' + document.getElementById('HidLotteryID').value + '&amp;PlayType=' + o_tbPlayTypeID.value + '&amp;Isuse=' + document.getElementById('HidIsuseID').value + '" width="100%" scrolling="no" height="30"></iframe></td></tr></table></td></tr><tr><td style="text-align:right; padding-right:10px;"><font color="#ff0000">【注】</font>如果选择方案文件<font color="#ff0000">(.txt格式)</font>上传,上面的投注内容将被清除并被替换成方案文件里面的内容。<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 方案文件中请输入规范的投注内容，多注请用回车换行。 <span class="blue12"><a href="../Home/Room/SchemeExemple.aspx?id=' + document.getElementById("HidLotteryID").value + '" target="_blank">请参看格式规范</a></span></td></tr><tr><td style="background-color:#f2f2f2; padding:10px;"><table width="280" border="0" align="right" cellpadding="0" cellspacing="0"><tbody style="cursor: pointer; color: White;"><tr><td width="19%" align="right"><table width="88" border="0" cellpadding="0" cellspacing="1" bgcolor="#FF3300"><tr><td height="23" align="center" bgcolor="#FD9A00" onclick=" btn_OK();">确定</td></tr></table></td><td width="32%" align="right"><table width="88" border="0" cellpadding="0" cellspacing="1" bgcolor="#FF3300"><tr><td height="23" align="center" bgcolor="#FD9A00" onclick=" btn_Close();">取消</td></tr></table></td><td width="32%" align="right"><table width="88" border="0" cellpadding="0" cellspacing="1" bgcolor="#FF3300"><tr><td height="23" align="center" bgcolor="#FD9A00" onclick=" btn_Close();">关闭窗口</td></tr></table></td></tr></tbody></table></td></tr></table></td></tr></table></td></tr></table>';

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
    if (document.getElementById("menu_left").clientHeight < document.getElementById("menu_right").clientHeight) {
        document.getElementById("menu_left").style.height = document.getElementById("menu_right").offsetHeight + "px";
    }
    else {
        if (document.getElementById("menu_right").offsetHeight >= 860) {
            document.getElementById("menu_left").style.height = (document.getElementById("menu_right").offsetHeight + 150) + "px";
        }
        else {
            document.getElementById("menu_left").style.height = "860px";
        }
    }
}

function btn_OK() {
    document.getElementById("list_LotteryNumber").style.display = "";

    try {
        var LotteryNumber = Lottery_Buy_22X5.AnalyseScheme(document.getElementById("tbLotteryNumbers").value, document.getElementById('HidLotteryID').value, document.getElementById('tbPlayTypeID').value);

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
            $Id("tb_hide_ChaseBuyedMoney").value = $Id("LbSumMoney").innerText;

            var TipStr = '您要申请' + LotteryName + $Id("tbPlayTypeName").value + '投注，详细内容：\n\n';

            TipStr += "　　总金额：　" + $Id("LbSumMoney").innerText + " 元\n\n";

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


function ReloadSchedule() {
    if ($Id("divSchemeAll").style.display == "") {
        schemeAll(currentLotteryID);
    } else {
        newCoBuy(currentLotteryID);
    }
}

//当页面加载完后，要执行的系列事件
function PageEvent(lotteryID) {

    //第二步（根据url参数显示相应的内容）
    var fromUrlParam = location.search;
    if (fromUrlParam.indexOf("CoBuy") != -1) {
        newCoBuy(lotteryID);
    }
    else {
        newBuy(lotteryID);
    }

    ClickXYJX(document.getElementById("hrefXZ"), 1);

}

function clickPlayType(t) {document.getElementById('tbPlayTypeID').value = t;
        var playTypeName = '';
        switch (t) {
        case '902':
            playTypeName = '复式';
            iframe_playtypes.location.href = '../Home/Room/playtypes/TC22X5/TC22X5_F.htm';
            break;

        default:
            t = '901';
            playTypeName = '单式';
            iframe_playtypes.location.href = '../Home/Room/playtypes/TC22X5/TC22X5_D.htm';
            break;
        }

            $Id('tbPlayTypeName').value = playTypeName;
          
            HidBtnRand(playTypeName);

            resetPage();
        }
        
//************************************************************事件执行区***************************************

//页面加载的时候，加载相应的数据
function Page_load(lotteryId) {

    //初始化彩种信息
    currentLotteryID = lotteryId

    //第一步（加载彩种）
    loadLottery(currentLotteryID);
}









