// Public.js 文件
function Request(strName) {
    var url = location.search;
    var reg = new RegExp("(^|&)" + strName + "=([^&]*)(&|$)");
    var r = url.substr(url.indexOf("?") + 1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;
}

function GetRandNumber(Number) {
    return Math.ceil(Math.random() * Number);
}

//增加 trim(),ltrim(),rtrim() 四个函数
String.prototype.ltrim = function() { return ltrim(this); }
String.prototype.rtrim = function() { return rtrim(this); }
String.prototype.rtrimWithReturn = function() { return rtrimWithReturn(this); }
String.prototype.trim = function() { return trim(this); }

//此处为独立函数 
function ltrim(str) {
    var i;
    for (i = 0; i < str.length; i++) {
        if ((str.charAt(i) != " ") && (str.charAt(i) != " ") && (str.charAt(i).charCodeAt() != 13) && (str.charAt(i).charCodeAt() != 10) && (str.charAt(i).charCodeAt() != 32))
            break;
    }
    str = str.substring(i, str.length);
    return str;
}

function rtrim(str) {
    var i;
    for (i = str.length - 1; i >= 0; i--) {
        if ((str.charAt(i) != " ") && (str.charAt(i) != " ") && (str.charAt(i).charCodeAt() != 13) && (str.charAt(i).charCodeAt() != 10) && (str.charAt(i).charCodeAt() != 32))
            break;
    }
    str = str.substring(0, i + 1);
    return str;
}

function rtrimWithReturn(str) {
    var i;
    for (i = str.length - 1; i >= 0; i--) {
        if (str.charAt(i) != " " && str.charAt(i) != " " && str.charAt(i) != "\n")
            break;
    }
    str = str.substring(0, i + 1);
    return str;
}

function trim(str) {
    return ltrim(rtrim(str));
}

function DateToString(datetime) {
    return datetime.getYear() + "-" + (datetime.getMonth() + 1) + "-" + datetime.getDate() + " " + datetime.getHours() + ":" + datetime.getMinutes() + ":" + datetime.getSeconds();
}

function StrToInt(str) {
    str = str.trim();
    if (str == "")
        return 0;

    var i = parseInt(str, 10);
    if (isNaN(i))
        return 0;

    return i;
}

function StrToFloat(str) {
    var NewStr = "";
    for (var i = 0; i < str.length; i++) {
        if (str.charAt(i) != "," && str.charAt(i) != " ")
            NewStr += str.charAt(i);
    }

    if (NewStr == "")
        return 0;

    var f = parseFloat(NewStr);
    if (isNaN(f))
        return 0;

    return f;
}

function Round(Num, Len) {
    var temp = 1;
    for (var i = 0; i < Len; i++)
        temp *= 10;

    return Math.round(Num * temp) / 100;
}

document.onkeydown = function()//关F5
{
    if (event.keyCode == 116) {
        event.keyCode = 0;
        event.cancelBubble = true;
        return false;
    }
}

//function document.oncontextmenu()//关右键菜单
//{
//	return false;
//}

function CheckMoneyOnPress() {
    if (window.event.keyCode < 48 || window.event.keyCode > 57) {
        return false;
    }

    return true;
}

function CheckMoneyOnPressDecimal(sender) {
    //if(sender.value.search(/[0-9]{1,}.[0-9]{1,}/) != 0) 
    if (sender.value.search(/[0|1].[0-9]{1,}/) != 0) {
        sender.value = "";
        sender.focus();
    }
}
