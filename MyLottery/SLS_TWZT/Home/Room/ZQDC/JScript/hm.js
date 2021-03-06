var hm = {};
hm.minBuy = 0.10; 		//最小认购比例
hm.minBaodi = 0.00; 		//最小保底比例
hm.mustInt = true;

//合买初始化
hm.init = function() {
    //    trade.ishm = true;
    trade.confirm = false;
    trade.onShowBack = hm.showPerMoney;
    hm.obj = fw.dom.getToObject(
	    "bonusScale",                   //佣金比例
		"divideCount", 				//分成份数
		"perMoney", 					//每份金额
		"buyCount", 					//认购份数
		"buyScale", 					//认购比例
		"buyMoney", 					//认购金额
		"buyUser", 					//认购网友
		"baodiCount", 				//保底份数
		"baodiScale", 				//保底比例
		"baodiMoney"					//保底金额
	);
    hm.divCount = 0; 				//分成份数
    hm.totalMoney = 0; 				//总金额
    hm.perMoney = 0; 				//每份金额
    fw.callEach([
		{obj: "divideCount", handle: trade.chkNumber.call(fw.getId("divideCount"), hm.showPerMoney), evt: "keyup" }, 		//显示每份金额
		{obj: "buyCount", handle: trade.chkNumber.call(fw.getId("buyCount"), hm.showBuyMoney), evt: "keyup" }, 		        //显示认购金额
		{obj: "buyCount", handle: trade.chkNumber.call(fw.getId("buyCount"), hm.showBuyMoney), evt: "blur" }, 		        //判断认购金额
		{obj: "baodiCount", handle: trade.chkNumber.call(fw.getId("baodiCount"), hm.showBaodiMoney), evt: "keyup" }, 		//显示保底金额
		{obj: "baodiCount", handle: trade.chkNumber.call(fw.getId("baodiCount"), hm.showBaodiMoney), evt: "blur"}			//设置保底金额
	], trade.addEvent);


    trade.addInputEvent("bonusScale", function() { hm.checkBonusScale() }); 			//检查佣金比例
    hm.showPerMoney(fw.conv.rmb2number(fw.getId("caseMoney").innerHTML));
}

//显示每份金额(这是由总份数来激活的，调用这里，将更新认购、保底等数据)
hm.showPerMoney = function(money) {

    //份数不能为空或者0
    if (hm.obj.divideCount.value == '' || hm.obj.divideCount.value == '0') {

        hm.obj.divideCount.value = 1;
        hm.showPerMoney();
        return;
    }
    
    hm.obj.divideCount.readOnly && (hm.obj.divideCount.value = trade.baseCount * trade.multiple);
    !isNaN(money) && (hm.totalMoney = money);
    hm.divCount = hm.obj.divideCount.value - 0;
    hm.obj.buyCount.value = hm.divCount;
    hm.obj.baodiCount.value = 0;
    hm.updateInfo(hm.divCount > 0 ? hm.totalMoney / hm.divCount : 0);

    if (hm.totalMoney > 0 && hm.divCount > 0 && hm.mustInt && trade.ishm) {

        var tm = hm.totalMoney / hm.divCount + '';

        //判断是否可以除尽，并且每份不能小于1元
        if (!/^\d+(?:\.\d\d?)?$/.test(tm)) {
            hm.obj.divideCount.value = 1;
            hm.showPerMoney();

        }
        else if (hm.perMoney < 1) {
            hm.obj.divideCount.value = 1;
            hm.showPerMoney();
        }


    }
}

//更新UI
hm.updateInfo = function(money) {
    hm.perMoney = money;
    hm.obj.perMoney.innerHTML = trade.formatRMB(money);
    hm.showBuyMoney();
    hm.showBaodiMoney();
}

//显示认购金额
hm.showBuyMoney = function() {

    hm.calInfo(hm.obj.buyCount, hm.obj.buyMoney, hm.obj.buyScale);
    if (window.event && window.event.srcElement && window.event.srcElement.id == 'buyCount' && window.event.type == 'blur') {
        //最小认购金额不能小于10%
        if (hm.obj.buyCount.value != '' && hm.obj.buyCount.value != '0') {
            if (hm.obj.buyCount.value < hm.divCount * hm.minBuy) {

                var mm = hm.divCount * hm.minBuy;
                mm = mm < 1 ? 1 : Math.ceil(mm);
                hm.obj.buyCount.value = mm;
                hm.showBuyMoney();

            }
            //最大认购不能超过总份数
            if (hm.obj.buyCount.value > hm.divCount) {
                hm.obj.buyCount.value = hm.divCount;
                hm.showBuyMoney();

            }
        }
        else {
            hm.obj.buyCount.value = 1;
            hm.showBuyMoney();
        }
    }
}

//显示保底金额
hm.showBaodiMoney = function() {
    hm.calInfo(hm.obj.baodiCount, hm.obj.baodiMoney, hm.obj.baodiScale);

    if (window.event && window.event.srcElement && window.event.srcElement.id == 'baodiCount' && window.event.type == 'blur') {
        //最大保底份数
        if (hm.obj.baodiCount.value != '' && hm.obj.baodiCount.value != '0') {

            var mm = hm.divCount - Number(hm.obj.buyCount.value);

            if (hm.obj.baodiCount.value > mm) {
                hm.obj.baodiCount.value = mm;
                hm.showBaodiMoney();
            }
        }
        else {
            if (hm.obj.baodiCount.value != '0') {
                hm.obj.baodiCount.value = 0;
                hm.showBaodiMoney();
            }
        }
    }
}

//calInfo
hm.calInfo = function(objCount, objMoney, objScale) {
    var count = Number(objCount.value);
    objMoney.innerHTML = trade.formatRMB(count * hm.perMoney);
    fw.setHTML(objScale, Math.floor((hm.divCount > 0 ? count / hm.divCount : 0) * 10000) / 100 + "%");
}

//设置每份金额
hm.setPerMoney = function(count, money) {
    var money2 = money * 100;
    while (count < money && money2 % count) {
        count++;
    }
    if (window.confirm("分成的份数除不尽方案总金额,可能会造成误差,系统建议您分成" + count + "份,要分成" + count + "份吗?")) {
        hm.obj.divideCount.value = hm.divCount = count;
        hm.updateInfo(money / count);
        return true;
    }
    hm.obj.divideCount.select();
    return false;
}

//设置佣金比例
hm.checkBonusScale = function() {

    trade.chkNumberBack(hm.obj.bonusScale);

    if (hm.obj.bonusScale.value == "") return;

    if (hm.obj.bonusScale.value > 10 || hm.obj.bonusScale.value < 0) {
        hm.obj.bonusScale.value = 4;
        return false;
    }
}

//检查表单（第二步）
hm.chkForm = function(money) {

    var n = hm.divCount;
    var rg = Number(hm.obj.buyCount.value);
    var bd = Number(hm.obj.baodiCount.value);
    var isbd = bd > 0 ? true : false;
    var isset_buyuser = hm.obj.buyUser.value == '' ? false : true;

    if (hm.obj.divideCount.value == "") {
        return trade.alert(hm.obj.divideCount, "你要分成的份数不能为空！");
    } else if (n < 1) {
        return trade.alert(hm.obj.divideCount, "你要分成的份数必须大于等于1！");
    } else if (money / n < 1) {
        return trade.alert(hm.obj.divideCount, "每份金额必须大于等于1！");
    } else if (isset_buyuser && !(/^[\w\-\u4e00-\u9fa5]+(?:,[\w\-\u4e00-\u9fa5]+)*$/.test(fw.trim(hm.obj.buyUser.value)))) {
        return trade.alert(hm.obj.buyUser, "限定网友的格式不对");
    } else if (hm.obj.buyCount.value == "") {
        return trade.alert(hm.obj.buyCount, "你要认购的份数不能为空！");
    } else if (rg > n) {
        return trade.alert(hm.obj.buyCount, "你要认购的份数不能大于所分的份数！");
    } else if (rg / n < hm.minBuy) {
        return trade.alert(hm.obj.buyCount, "认购金额至少为总金额的" + hm.minBuy * 100 + "%,至少" + trade.formatRMB(money * hm.minBuy) + "元！");
    } else if (isbd && hm.obj.baodiCount.value == "") {
        return trade.alert(hm.obj.baodiCount, "你要保底的份数不能为空！");
    } else if (isbd && bd > n) {
        return trade.alert(hm.obj.baodiCount, "你要保底的份数不能大于所分的份数！");
    } else if (isbd && bd / n < hm.minBaodi) {
        return trade.alert(hm.obj.baodiCount, "保底金额至少为总金额的" + hm.minBaodi * 100 + "%,至少" + trade.formatRMB(money * hm.minBaodi) + "元！");
    } else if (isbd && rg + bd > n) {
        return !!alert("你要认购的份数和保底的份数之和不能大于所分的份数！");
    } else if (hm.obj.bonusScale.value == '') {
        return trade.alert(hm.obj.bonusScale, "佣金提成不能为空！");
    } else if (hm.obj.bonusScale.value < 0 || hm.obj.bonusScale.value>10) {
        return trade.alert(hm.obj.bonusScale, "佣金提成只能在0~10%之间！");
    }
    
    if (money * 100 % n) {
        if (hm.setPerMoney(n, money) == false) return false;
    }

    return { money: (rg + bd) / n * money };
}
