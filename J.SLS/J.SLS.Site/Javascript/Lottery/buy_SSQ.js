
//************************************************************全局变量定义区*******************************************

//当前彩种编号
var currentLotteryID = null;
//当前游戏编码 ssq
var currentGameName = null;
//彩种名称
var lotteryName = null;

var o_tb_LotteryNumber;
var o_list_LotteryNumber;
var o_tb_Multiple;
var o_tb_Share;
var o_tb_AssureShare;
var o_tb_BuyShare;
var o_tb_Title;
var o_lab_Num;
var o_lab_SumMoney;
var o_lab_ShareMoney;
var o_lab_AssureMoney;
var o_lab_BuyMoney;
var o_lb_LbSumMoney;
var o_tb_Price;


//************************************************************方法函数定义区***************************************


//---------------------------------------页面加载功能区代码-------------------------------------------------

//初始化全局变量数据
function init() {
    o_tb_LotteryNumber = $Id("tb_LotteryNumber");
    o_list_LotteryNumber = $Id("list_LotteryNumber");
    o_tb_Multiple = $Id("tb_Multiple");
    o_tb_Title = $Id("tb_Title");
    o_lab_Num = $Id("lab_Num");
    o_lab_SumMoney = $Id("lab_SumMoney");

    o_tb_LotteryNumber.value = "";
    o_tb_Multiple.value = "1";

    o_lab_Num.innerText = "0";
    o_lab_SumMoney.innerText = "0.00";

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

//定时读取最近的开奖信息的定时器
var time_GetServerTime = null;

//获取服务器时间
function GetServerTime(lotteryID) {
    currentLotteryID = lotteryID;
    try {
        Lottery_SSQ_Buy.GetSysTime(GetServerTime_callback);
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

    var IsuseEndTime = new Date($Id(GetHidIsuseEndTime()).value.replace(new RegExp("-", "g"), "/"));
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
    var IsuseEndTime = new Date($Id(GetHidIsuseEndTime()).value.replace(new RegExp("-", "g"), "/"));
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
function GetIsuseInfo() {
    try {
        Lottery_SSQ_Buy.GetIsuseInfo(currentGameName, GetIsuseInfo_callback);
    }
    catch (e) {
        time_GetIsuseInfo = setTimeout("GetIsuseInfo();", 2000);
    }
}

function GetIsuseInfo_callback(response) {
    if (response == null || response.value == null) {
        time_GetIsuseInfo = setTimeout("GetIsuseInfo();", 2000);
        return;
    }

    //将time_GetIsuseInfo移除
    if (time_GetIsuseInfo != null) {
        clearTimeout(time_GetIsuseInfo);
    }

    if (response.value == "") {
        return;
    }

    var currIsuse = response.value;
    var arrcurrIsuse = currIsuse.split(',');
    $Id(GetHidIsuseID()).value = arrcurrIsuse[0];
    currIsuseName.innerText = arrcurrIsuse[1];
    $Id(GetHidIsuseNumber()).value = arrcurrIsuse[1];
    currIsuseEndTime.innerText = arrcurrIsuse[2].replace("/", "-").replace("/", "-");
    $Id(GetHidIsuseEndTime()).value = arrcurrIsuse[2];
}

//获取已开奖号
var time_GetBindWinNumber = null;
function GetBindWinNumber(lotteryID) {
    currentLotteryID = lotteryID;
    try {
        Lottery_SSQ_Buy.GetWinNumber(lotteryID, GetBindWinNumber_callback);
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

    headHtm += "<div style=\"text-align:right;\"><span id=\"Span1\" class=\"hui12\" ><a href=\"../TrendCharts/SSQ/SSQ_CGXMB.aspx\" target=\"_blank\">更多&gt;&gt;</a></span></div>";

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


function CalcResult() {
    var multiple = StrToInt(o_tb_Multiple.value);
    multiple = multiple == 0 ? 1 : multiple;
    var SumNum = StrToInt(o_lab_Num.innerText);
    var SumMoney = Round(multiple * o_tb_Price * SumNum, 2);

    o_lab_SumMoney.innerText = SumMoney;
}

function calculateAllMoney() {
    var btnId = GetBtnOKId();
    $Id(btnId).disabled = "";
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
}

//重置页面
function resetPage() {
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

function newBuy(lotteryID) {
    $Id("divNewBuy").style.display = "";
    $Id("divPlayTypeIntroduce").style.display = "none";

    var menu = document.getElementById("tbPlayTypeMenu" + String(lotteryID));

    if (menu == null) {
        $Id("playType" + String(lotteryID) + "01").checked = true;
        clickPlayType(100 * lotteryID + 01);
    } else {
        menu.rows[0].cells[1].click();
    }
}

function PlayTypeIntroduce(lotteryID) {
    $Id("divNewBuy").style.display = "none";
    $Id("divCoBuy").style.display = "none";
    $Id("divFollowScheme").style.display = "none";
    $Id("divPlayTypeIntroduce").style.display = "";
    $Id("divSchemeAll").style.display = "none";
    $Id("iframePlayTypeIntroduce").src = "../Home/Room/Help/help_" + lotteryID + ".htm";
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

function btn_Close() {
    document.body.removeChild(bgDiv2);
    document.body.removeChild(msgDiv2);

    try {
        document.getElementById("list_LotteryNumber").style.display = "";
    } catch (e) { }
    document.getElementById("list_LotteryNumber").style.display = "";
}

function btn_OKClick() {
    if (!$Id(GetCheckAgreementId()).checked) {
        alert("请先阅读用户电话短信投注协议，谢谢！");
        return false;
    }
    if ($Id("currIsuseEndTime").innerHTML == "本期已截止投注" < 0) {
        alert("本期投注已截止，谢谢。");
        return false;
    }

    var multiple = StrToInt(o_tb_Multiple.value);
    var SumNum = StrToInt(o_lab_Num.innerText);
    var SumMoney = StrToInt(o_lab_SumMoney.innerText);

    if (SumNum < 1) {
        alert("请输入投注内容。");
        return false;
    }
    if (multiple < 1) {
        alert("请输入正确的倍数。");
        o_tb_Multiple.focus();
        return false;
    }

    //    var TipStr = '您要发起' + LotteryName + $Id("tbPlayTypeName").value + '方案，详细内容：\n\n';
    //    TipStr += "　　注　数：　" + SumNum + "\n";
    //    TipStr += "　　倍　数：　" + multiple + "\n";
    //    TipStr += "　　总金额：　" + o_lab_SumMoney.innerText + " 元\n\n";
    //    TipStr += "　　总份数：　" + Share + " 份\n";
    //    TipStr += "　　每　份：　" + o_lab_ShareMoney.innerText + " 元\n\n";
    //    TipStr += "　　保　底：　" + AssureShare + " 份，" + o_lab_AssureMoney.innerText + " 元\n";
    //    TipStr += "　　购　买：　" + BuyShare + " 份，" + o_lab_BuyMoney.innerText + " 元\n\n";

    var TipStr = '您要投注方案，详细内容：\n\n';
    if (!confirm(TipStr + "按“确定”即表示您已阅读《投注协议》并立即提交方案，确定要提交吗？"))
        return false;

    $Id("tb_hide_SumMoney").value = o_lab_SumMoney.innerText;
    $Id("tb_hide_SumNum").value = o_lab_Num.innerText;

    __doPostBack(GetBtnOKName(), '');
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
}

function clickPlayType(t) {
    document.getElementById('tbPlayTypeID').value = t;
    var playTypeName = '';
    switch (t) {
        case '502':
            playTypeName = '复式';
            iframe_playtypes.location.href = 'SSQ_F.htm';
            break;
        case '503':
            playTypeName = '胆拖';
            iframe_playtypes.location.href = 'SSQ_DanT.htm';
            break;
        case '504':
            document.getElementById('tbPlayTypeID').value = '501';
            playTypeName = '单式';
            iframe_playtypes.location.href = 'SSQ_ZNJX.htm';
            break;
        default:
            t = '501';
            playTypeName = '单式';
            iframe_playtypes.location.href = 'SSQ_D.htm';
            break;
    }

    $Id('tbPlayTypeName').value = playTypeName;
    HidBtnRand(playTypeName);
    resetPage();
}
//************************************************************事件执行区***************************************

//页面加载的时候，加载相应的数据
function Page_load(lotteryId, gameName) {
    //初始化彩种信息
    currentLotteryID = lotteryId;
    currentGameName = gameName;
    //第一步（加载彩种）
    loadLottery(currentLotteryID);
}