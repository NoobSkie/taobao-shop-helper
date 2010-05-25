var hmax = 170; //最大高度
var hmin = 25; //最小高度
var h = 0;
function addCount() {
    if (h < hmax) {
        h += 190;
        setTimeout("addCount()", 1);
    }
    else {
        h = hmax;
        setTimeout("noneAds()", 10000); //停留时间自己适当调整 1000 = 1秒
    }
    document.getElementById("ads").style.display = "";
    document.getElementById("close").style.display = "";
    document.getElementById("ads").style.height = h + "px";
}
    function showAds() {
        document.getElementById("ads").style.display = "none";
        document.getElementById("close").style.display = "none";
    document.getElementById("ads").style.height = "0px";

    addCount(); //慢慢打开
}
function openAds() {
    h = 0; //高度
    addCount(); //慢慢打开
}
function noneAds() {
    if (h > hmin) {
        h -= 10;
        setTimeout("noneAds()", 1);
    }
    else {
        h = hmin;
        document.getElementById("ads").style.display = "none";
        document.getElementById("close").style.display = "none";
        return;
    }
    document.getElementById("ads").style.height = h + "px";
}
