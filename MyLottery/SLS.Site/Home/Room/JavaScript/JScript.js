
//************************************************************常量定义区***************************************


var SYYDJ_SCRIPT = "BonusNumber_SYYDJ.js";                      //lotteryId=62
var JXSSC_SCRIPT = "BonusNumber_JXSSC.js";                      //lotteryId=61
var JX11X5_SCRIPT = "BonusNumber_JX11X5.js";                    //lotteryId=70
var CQSSC_SCRIPT = "BonusNumber_CQSSC.js";                      //lotteryId=28

var FileUrl = "JavaScript/";//"http://58.56.110.157/cache/Allcai_Resource/";    //资源文件服务器


//************************************************************变量定义区***************************************

var currentScript = SYYDJ_SCRIPT;     //当前脚本文件(默认为让球胜负彩)

var time_LoadJSFile = null;           //定时更新bonusNumber文件，当

var time_UpdateData = null;           //更新bonusNumber定时器，由加载bonusNumber文件的时候开启，并在更新执行后就关闭

var bonusNumber_lcal = null;               //本地bonusNumber值
var bonusNumbers_lcal = null;               //本地bonusNumbers值

var currentPage = 0;                        //开奖列表当前页码
 
var IsNewsOpenInfo = false;                 //标记上期是否开了奖

var currentLotteryId = null;                //彩种编号


//************************************************************方法函数定义区***************************************

//加载bonusNumber文件，更新本地bonusNumber值
function loadBonusNumber() {

    //先在开始执行加载之前将定时器清空，等结束了这次更新之后，再开启定时器
    
    if (time_LoadJSFile != null) {
        clearTimeout(time_LoadJSFile);
    }
    
    var bnScript = document.getElementById('BN_script');
    var head = document.getElementsByTagName('head').item(0);

    if (bnScript != undefined && bnScript != null) {

        head.removeChild(bnScript);
    }

    bnScript = document.createElement("script");
    bnScript.id = "Sp_script";
    bnScript.type = "text/javascript";

    bnScript.src = FileUrl + currentScript + "?version=" + new Date().toTimeString();

    head.appendChild(bnScript);

    //在加载文件后的n秒钟,更新本地SP值，开启定时器(此处一定要等一会才能运行，不然无法会出现js还没有加载完的情况)

    time_UpdateData = setTimeout("updateData();", 500);
}

//更新本地数据
function updateData() {

    try {

        //当定时执行到这的时候，要先把定时器给关闭（关闭定时器）
        if (time_UpdateData != null) {
            clearTimeout(time_UpdateData);
        }

        //更新开奖号码
        updateBonusNumber();

        //更新开奖列表
        updateBonusNumbers();

        IsNewsOpenInfo = true;
    }
    catch (e) {

        //如果出现异常，那么半秒钟后重新执行 loadBonusNumber()
        time_LoadJSFile = setTimeout("loadBonusNumber();", 500);
    }

    //完成了更新后，再开启定时器(8秒加载一次文件)
    time_LoadJSFile = setInterval("loadBonusNumber();", 8000);
    
}


//更新本地bonusNumber值
function updateBonusNumber() {

    //更新本地bonusNumber值
    if (bonusNumber != undefined && bonusNumber != null && bonusNumber_lcal != bonusNumber) {

        bonusNumber_lcal = bonusNumber;

        bonusNumber_lcal = bonusNumber_lcal.replace("WORD_ONE", "期开奖").replace("WORD_TWO", "今日已开").replace("WORD_THREE", "期，还剩").replace("WORD_FOUR", "期");

        $Id("lastIsuseInfo").innerHTML = bonusNumber_lcal;


        return;
    }

    if (bonusNumber_lcal == null) bonusNumber_lcal = "";

}

//显示开奖列表信息
function updateBonusNumbers() {

    //更新本地bonusNumbers值
    if (bonusNumbers != undefined && bonusNumbers != null && bonusNumbers_lcal != bonusNumbers) {

        bonusNumbers_lcal = bonusNumbers;

        bindWinNumber(0);
       
        return;

    }
    if (bonusNumbers_lcal == null) bonusNumbers_lcal = "";

}

//绑定开奖列表
function bindWinNumber(type) {

    try {
    
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
        headHtm += "<td height=\"25\" align=\"center\" bgcolor=\"#F4F9FC\" class=\"blue12\">时间</td>";
        headHtm += "<td align=\"center\" bgcolor=\"#F4F9FC\" class=\"blue12\">号码</td></tr>";
        headHtm += numbers[currentPage];
        headHtm += "</table>";

        var moreUrl = currentLotteryId == "61" ? "../TrendCharts/JXSSC/SSC_5X_ZHFB.aspx" : "../TrendCharts/SYYDJ/SYDJ_FBZS.aspx";

        headHtm += "<div style=\"text-align:right;\"><span id=\"Span1\" class=\"hui12\" ><a href=\"" + moreUrl + "\" target=\"_blank\">更多&gt;&gt;</a></span></div>";

        $Id("tdWinLotteryNumber").innerHTML = headHtm;
        
        
    }
    catch (e) {
    
    }

}

//确定Js文件的域名Url
function changeFileUrl(url) {

    if(url!=null)
    {
        url = url.toLowerCase();

        if (url.indexOf("http://localhost") >= 0 || url.indexOf("http://127.0.0.1") >= 0) {

            FileUrl = "../Home/Room/JavaScript/";   //资源文件服务器（本地）

        }
        else {
            FileUrl = "http://mhb.shovesoft.com/Home/Room/JavaScript/";   //资源文件服务器(即时读取十一运，时时彩开奖号码)
        }

    }

}

//确定要引用什么数据文件
function changeScript(lotteryId) {

    //先确定FileUrl
    changeFileUrl(window.location.href);

    if (lotteryId == undefined || lotteryId == null) {
        lotteryId = 62;
    }

    switch (lotteryId) {
        case 28:
            currentScript = CQSSC_SCRIPT;
            break;
        case 62:
            currentScript = SYYDJ_SCRIPT;
            break;
        case 61:
            currentScript = JXSSC_SCRIPT;
            break;
        case 70:
            currentScript = JX11X5_SCRIPT;
            break;
        default:
            currentScript = SYYDJ_SCRIPT;
            break;

    }
}

//页面加载事件
function loadPage(lotteryId) {

    currentLotteryId = lotteryId;

    changeScript(currentLotteryId);

    loadBonusNumber();

    if (IsNewsOpenInfo == true) {
        if (lotteryId == 62) {
            Lottery_Buy_SYYDJ.ClearTheadChartCache();
        }
        if (lotteryId == 61) {
            Lottery_Buy_SSC.ClearTheadChartCache();
        }
        if (lotteryId == 28) {
            Lottery_Buy_CQSSC.ClearTheadChartCache();
        }
    }  
}


//************************************************************事件执行区***************************************

//window.document.body.attachEvent("onload", loadPage);







