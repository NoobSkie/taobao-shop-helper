var lastLottery;
var lastTC;
var o_list_LotteryNumber;
var o_tb_LotteryNumber;
var o_lab_Num1;
var lastXH; 
function init() {
    lastLottery = document.getElementById("tdLottery5");
    lastTC = document.getElementById("tdTC1");
    o_list_LotteryNumber = document.getElementById("list_LotteryNumber");
    o_tb_LotteryNumber = document.getElementById("HidLotteryNumber");
    o_lab_Num1 = document.getElementById("spanLotteryNum1");
    lastXH = document.getElementById("hrefSYXH");
}
    
    var lottery = [[5, "SSQ", "双色球", 14], [6, "FC3D", "福彩3D", 30], [39, "DLT", "大乐透", 14], [63, "SZPL3", "排列3", 30], [64, "SZPL5", "排列5", 30], [59, "AHFC15X5", "15选5", 30], [58, "DF6J1", "东方6+1", 14], [13, "QLC", "七乐彩", 14], [9, "TC22X5", "22选5", 30]];
    var isuseCount = 14;
    var playPage = "SSQ";
    function ClickLottery(obj, type) {
            document.getElementById("CustomChaseOne").style.display = "";
            document.getElementById("CustomChaseTwo").style.display = "none";
            
            lastLottery.className = "hui14";
            lastLottery.bgColor = "#FFFFFF";

            obj.parentNode.className = "bai14";
            obj.parentNode.bgColor = "#FF6600";

            lastLottery = obj.parentNode;

            isuseCount = lottery[type][3];
            playPage = lottery[type][1];
            
            document.getElementById("HidLotteryID").value = lottery[type][0];
            document.getElementById("spanLotteryName").innerHTML = lottery[type][2];
            document.getElementById("radioJX").click();
            
            document.getElementById("tdLuckNumber").innerHTML = LotteryPackage.InitLuckLotteryNumber(lottery[type][0]).value;
            document.getElementById("HidLotteryNumber").value = "";
            document.getElementById("hrefXYXH").click();

            if (type == 2) {
                document.getElementById("spanZJ").style.display = "";
            } else {
            document.getElementById("spanZJ").style.display = "none";
        }
        document.getElementById("cbZJ").checked = false;
        document.getElementById("HidPlayTypeID").value = lottery[type][0] * 100 + 1;
            return false;
    }

    
    var chaseType = [[1, "包月", "吉祥套餐"], [3, "包季", "如意套餐"], [6, "包半年", "幸福套餐"], [12, "包年", "安康套餐"]];
    var month = 1;
    function ClickTC(obj, type) {
            document.getElementById("CustomChaseOne").style.display = "";
            document.getElementById("CustomChaseTwo").style.display = "none";

            lastTC.className = "blue24";
            lastTC.bgColor = "#E1F1FF";

            obj.parentNode.className = "bai14";
            obj.parentNode.bgColor = "#6699CC";

            lastTC = obj.parentNode;

            document.getElementById("HidType").value = type.toString();

            month = chaseType[type - 1][0];
            
            document.getElementById("spanMonthCount").innerHTML = month;
            
            calculateMoney();
            
             return false;
    }

    function calculateMoney() {
            document.getElementById("spanIsuseCount1").innerHTML = month * isuseCount;
            document.getElementById("HidIsuseCount").value = document.getElementById("spanIsuseCount1").innerHTML;
            document.getElementById("HidNums").value = document.getElementById("spanLotteryNum1").innerHTML;
            var price = 2;
            if(document.getElementById("HidPlayTypeID").value == "3903")
            {
                price = 3;
            }

            if (document.getElementById("HidBetType").value == "1") {
                document.getElementById("HidMultiple").value = "1";
                document.getElementById("spanLotteryNum1").innerHTML = document.getElementById("selectMultiple").value;
                document.getElementById("HidNums").value = document.getElementById("selectMultiple").value; 
            } else {
            document.getElementById("HidMultiple").value = document.getElementById("selectMultiple").value; 
            }
            
            document.getElementById("spanMoney1").innerHTML = month * isuseCount * parseInt(document.getElementById("spanLotteryNum1").innerHTML) * price * parseInt(document.getElementById("HidMultiple").value);
            document.getElementById("HidMoney").value = document.getElementById("spanMoney1").innerHTML;
    }

    function changeMultiple() {
        
        calculateMoney();
    }

    function changeBetType(obj) {
        document.getElementById("spanLotteryNum1").innerHTML = "0";
        document.getElementById("HidBetType").value = "2";
        document.getElementById("HidLotteryNumber").value = "";
          
        if (obj.value == "1") {
            document.getElementById("trPlayTypes").style.display = "none";
            document.getElementById("trPlayTypes1").style.display = "none";
            document.getElementById("trPlayTypes2").style.display = "none";
            document.getElementById("trPlayTypes_JX").style.display = "";
            
            btn_ClearClick();
            document.getElementById("hrefXYXH").click();
            
        } else {
        document.getElementById("trPlayTypes").style.display = "";
        document.getElementById("trPlayTypes1").style.display = "";
        document.getElementById("trPlayTypes2").style.display = "";
        document.getElementById("iframe_playtypes").src = "Home/Room/Chase/"+playPage+".htm";
        document.getElementById("trPlayTypes_JX").style.display = "none";
        }
        document.getElementById("spanNumOrMultiple1").innerHTML = "倍";
        document.getElementById("spanNumOrMultiple2").innerHTML = "倍";
        calculateMoney();
    }

    function btnNext_OK() {
        if (parseInt(document.getElementById("spanMoney1").innerHTML) < 2) {
            alert("请选择号码！");

            return;
        }
      
        document.getElementById("spanChaseType").innerHTML = chaseType[parseInt(document.getElementById("HidType").value) - 1][2] + "(" + chaseType[parseInt(document.getElementById("HidType").value) - 1][1] + ")";
        document.getElementById("tbTitle1").value = document.getElementById("tbTitle").value;
        
        if(document.getElementById("trPlayTypes_JX").style.display == "")
        {
            document.getElementById("spanBetType").innerHTML = "机选";
        }else 
        {
            document.getElementById("spanBetType").innerHTML = "自选";
        }
        
        document.getElementById("spanLotteryNum2").innerHTML = o_lab_Num1.innerHTML;
        document.getElementById("spanIsuseCount2").innerHTML = document.getElementById("spanIsuseCount1").innerHTML; 
        document.getElementById("spanMultiple").innerHTML = document.getElementById("HidMultiple").value;
        document.getElementById("spanMoney2").innerHTML = document.getElementById("spanMoney1").innerHTML;
        CustomChaseOne.style.display = "none";
        CustomChaseTwo.style.display = "";
        var iframe = document.getElementById("iframe_Login");
        if(iframe!=null)
        {
            iframe_Login.location.href = "Home/Room/ChaseLogin.aspx";
        }
    }

    
        function ClickSJXH(obj,type)
        {
            if(lastXH!=null)
            {
                document.getElementById(lastXH.id.replace("href","td")).background = "";
                document.getElementById(lastXH.id.replace("href","tr")).style.display = "none";
            }
            
            document.getElementById(obj.id.replace("href","td")).background = "Home/Room/images/by_bg_r1_c1.gif";
            document.getElementById(obj.id.replace("href","tr")).style.display = "";
            
            if(type == 1)
            {
                document.getElementById("spanNumOrMultiple1").innerHTML = "注";
                document.getElementById("spanNumOrMultiple2").innerHTML = "注";
                document.getElementById("spanLotteryNum1").innerHTML = "1";
                
                var tds = document.getElementById("tdLuckNumber").getElementsByTagName("td");
                for (var i = 0; i < tds.length; i++) {
                if (tds[i].id.indexOf("tdLuckNumber") > -1) {
                    tds[i].innerHTML = "-";
                 }
                 }
                 
                 document.getElementById("HidLotteryNumber").value = "";
            }else 
            {
                document.getElementById("spanNumOrMultiple1").innerHTML = "倍";
                document.getElementById("spanNumOrMultiple2").innerHTML = "倍";
                if(lastXH!=obj)
                {
                    document.getElementById("spanLotteryNum1").innerHTML = "0";
                }
            }
            
            lastXH = obj;
            document.getElementById("HidBetType").value = type;
            
            calculateMoney();
            return false;
        }
        
 var lastXYJX = null;
function ClickXYJX(obj, type) {

    if (lastXYJX == null)
        lastXYJX = document.getElementById("hrefXZ");

    if (lastXYJX != null) {
        lastXYJX.parentNode.background = "";
        document.getElementById(lastXYJX.id.replace("href", "span")).style.display = "none";
    }

    if (obj.id == "hrefCSRQ") {
        obj.parentNode.background = "Home/Room/images/ssq_qh_2.jpg";
    } else {
        obj.parentNode.background = "Home/Room/images/ssq_qh_1.jpg";
    }

    document.getElementById(obj.id.replace("href", "span")).style.display = "";
    document.getElementById("HidXYXHType").value = type;

    lastXYJX = obj;
   
    var tds = document.getElementById("tdLuckNumber").getElementsByTagName("td");
    for (var i = 0; i < tds.length; i++) {
        if (tds[i].id.indexOf("tdLuckNumber") > -1) {
            tds[i].innerHTML = "-";
        }
    }
    
    document.getElementById("HidLotteryNumber").value = "";
    document.getElementById("spanLotteryNum1").innerHTML = "0";
    calculateMoney();
    return false;
}

var moving;
var number;
var isMove = true;
function GetLuckNumber() {
    var type = document.getElementById("HidXYXHType").value;
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

    var v = LotteryPackage.GenerateLuckLotteryNumber(parseInt(document.getElementById("HidLotteryID").value), type, name).value;
    if (v.split("|").length < 2) {
        alert(v);
        document.getElementById("tbDate").value = "";
    } else {
        document.getElementById("HidLotteryNumber").value = v.split("|")[0];

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
    
    document.getElementById("spanLotteryNum1").innerHTML = "1";
    
    calculateMoney();
}

function GetRandNumber(Number) {
    return Math.ceil(Math.random() * Number);
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
            o_lab_Num1.innerText = parseInt(o_lab_Num1.innerText) - 1;
            o_list_LotteryNumber.remove(i);
        }
    }

    o_tb_LotteryNumber.value = "";
    if (o_list_LotteryNumber.length > 0) {
        for (i = 0; i < o_list_LotteryNumber.length; i++)
            o_tb_LotteryNumber.value += (o_list_LotteryNumber.options[i].text + "\n");
    }

    calculateMoney();
    return true;
}

function btn_ClearClick() {
    try {
        while (o_list_LotteryNumber.length > 0) {
            o_list_LotteryNumber.remove(0);
        }

        o_tb_LotteryNumber.value = "";
        o_lab_Num1.innerText = "0";
        calculateMoney();
        return true;
    }
    catch (e) {
        return false;
    }
}

function splitScheme(lotteryNumber) {
    return LotteryPackage.SplitScheme(lotteryNumber, parseInt(document.getElementById("HidLotteryID").value)).value;
}

function CreateUplaodDialog() {

    var o_tbPlayTypeID = parseInt(document.getElementById("HidPlayTypeID").value);

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

    var dialog = '<table><tr><td style="background-color: #AFBCD6; padding: 10px;font-size:12px"><table style="width: 100%;background-color:White;" border="0" cellpadding="0" cellspacing="1"><tr><td height="36" bgcolor="#6D84B4" class="bai14" style="padding: 0px 10px 0px 15px;text-align:left;"><span id="lbLotteryName"></span>粘贴投注</td></tr><tr><td style="padding: 5px;" align="center"><textarea id="tbLotteryNumbers" style="width:98%; height:160px;"></textarea></td></tr><tr><td><table width="100%" border="0" align="right" cellpadding="0" cellspacing="0"><tr><td style="text-align:left;"><table cellpadding="0" cellspacing="0" style="width:100%;"><tr><td style="text-align:right;">方案上传：</td><td colspan="2"><iframe id="frame_Upload" name="frame_Upload" frameborder="0" src="Home/Room/SchemeUpload.aspx?id=' + document.getElementById('HidLotteryID').value + '&amp;PlayType=' + o_tbPlayTypeID + '" width="100%" scrolling="no" height="30"></iframe></td></tr></table></td></tr><tr><td style="text-align:right; padding-right:10px;"><font color="#ff0000">【注】</font>如果选择方案文件<font color="#ff0000">(.txt格式)</font>上传,上面的投注内容将被清除并被替换成方案文件里面的内容。<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 方案文件中请输入规范的投注内容，多注请用回车换行。 <span class="blue12"><a href="Home/Room/SchemeExemple.aspx?id=' + document.getElementById("HidLotteryID").value + '" target="_blank">请参看格式规范</a></span></td></tr><tr><td style="background-color:#f2f2f2; padding:10px;"><table width="280" border="0" align="right" cellpadding="0" cellspacing="0"><tbody style="cursor: pointer; color: White;"><tr><td width="19%" align="right"><table width="88" border="0" cellpadding="0" cellspacing="1" bgcolor="#FF3300"><tr><td height="23" align="center" bgcolor="#FD9A00" onclick=" btn_OK();">确定</td></tr></table></td><td width="32%" align="right"><table width="88" border="0" cellpadding="0" cellspacing="1" bgcolor="#FF3300"><tr><td height="23" align="center" bgcolor="#FD9A00" onclick=" btn_Close();">取消</td></tr></table></td><td width="32%" align="right"><table width="88" border="0" cellpadding="0" cellspacing="1" bgcolor="#FF3300"><tr><td height="23" align="center" bgcolor="#FD9A00" onclick=" btn_Close();">关闭窗口</td></tr></table></td></tr></tbody></table></td></tr></table></td></tr></table></td></tr></table>';

    txt.innerHTML = dialog;

    document.getElementById("msgDiv2").appendChild(txt);
    document.getElementById("tbLotteryNumbers").focus();

    document.getElementById("lbLotteryName").innerHTML = document.getElementById("spanLotteryName").innerHTML;

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

function btn_OK() {
    document.getElementById("list_LotteryNumber").style.display = "";

    try {
        var LotteryNumber = LotteryPackage.AnalyseScheme(document.getElementById("tbLotteryNumbers").value,parseInt(document.getElementById('HidLotteryID').value));

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
    o_lab_Num1.innerText = "0";
    
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
        var Num = parseInt(strs[1]);
        if (Num < 1)
            continue;

        var customOptions = document.createElement("OPTION");
        customOptions.text = str;
        customOptions.value = Num;
        o_list_LotteryNumber.add(customOptions, o_list_LotteryNumber.length);

        o_tb_LotteryNumber.value += str + "\n";
        o_lab_Num1.innerText = parseInt(o_lab_Num1.innerText) + Num;
    }
    calculateMoney();
    document.body.removeChild(bgDiv2);
    document.body.removeChild(msgDiv2);
}