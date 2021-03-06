var trade = {};
trade.ishm = false; 			//是否合买
trade.isReDraw = false;
trade.ISHM = 0;
trade.ischase = false; 		//是否追号
trade.islogin = false; 		//是否登陆
trade.isrt = false; 			//是否倒计时
trade.baseCount = 0; 		//基本注数
trade.multiple = 1; 			//总倍数
trade.isstop = 0;               //是否停止追号
trade.confirm = true; 		//是否确认
trade.confirmMsg = false; 	//确认消息
trade.debug = false; 		//是否调试模式
trade.userInfo = null; 	//用户信息
trade.onSubmitBefore = new Function("return true");
trade.onSubmitBack = new Function("return false");
trade.onShowBack = new Function("return false");
trade.getList = new Function("return ''"); 	//获取号码列表
trade.submitMode = "ajax";                  //数据提交方式（ajax,form）
trade.baseUrl = "http://youth8.gicp.net/SLS.TWZT";

/////////////////////////////////公用代码begin/////////////////////
//获取Class
trade.getClass = function(obj, tag, cls) {
    var a = [];
    var o = fw.dom.getObjTag(obj, tag);
    for (var i = 0, l = o.length; i < l; i++) {
        if (o[i].className == cls) {
            a.push(o[i]);
        }
    }
    return a;
}

//获取单选框的值
trade.getRadio = function(name) {
    var o = fw.dom.getName(name);
    for (var i = o.length - 1; i > -1 && !o[i].checked; i--);
    return i > -1 ? o[i].value : false;
}

//获取元素绝对位置
trade.getXy = function(o) {
    o = fw.get(o);
    for (var _pos = { x: 0, y: 0 }; o; o = o.offsetParent) {
        _pos.x += o.offsetLeft;
        _pos.y += o.offsetTop;
    };
    return _pos;
}

//批量获取隐藏域的值
trade.getInput = function() {
    var json = {};
    for (var i = 0, a = arguments, l = a.length; i < l; i++) {
        json[a[i]] = fw.getId(a[i]) ? fw.getId(a[i]).value : "";
    }
    return json;
}

//批量设置隐藏域的值
trade.setInput = function(json) {
    for (var id in json) {
        if (fw.getId(id)) {
            fw.getId(id).value = json[id];
        }
    }
}

//input集体转换编码
trade.escape = function(a) {
    for (var i = 0, l = a.length; i < l; i++) {
        if (fw.getId(a[i])) {
            fw.getId(a[i]).value = escape(fw.getId(a[i]).value);
        }
    }
}

//input集体转换解编
trade.unescape = function(a) {
    for (var i = 0, l = a.length; i < l; i++) {
        if (fw.getId(a[i])) {
            fw.getId(a[i]).value = unescape(fw.getId(a[i]).value);
        }
    }
}

//批量获取URL的值
trade.getUrl = function(url) {
    var json = {};
    url.replace(/[\?\&](\w+)=(\w+)/g, function(s, s1, s2) {
        json[s1] = s2;
    });
    return json;
}

//批量设置URL的值
trade.setUrl = function(u, o) {
    var a = [];
    for (var i in o) {
        a.push(i + "=" + o[i]);
    }
    return u + "?" + a.join("&");
}

//检查数字回调
trade.chkNumberBack = function(obj, callBack) {
    var s = obj.value.replace(/\D/g, "");
    obj.value = s != "" ? Number(s) : "";
    if (callBack) {
        callBack(obj);
    }
}

//检查数字回调函数
trade.chkNumber = function(cb) {
    var _this = this;
    return function() { trade.chkNumberBack(_this, cb) };
}

//格式化数字
trade.formatNum = function(num) {
    return Math.round(num * 100) / 100;
}

//复式组合个数
trade.C = function(a, num) {
    if (typeof (a[0]) == "number") a = fw.array.getNum(a);
    var r = 0;
    var n = a.length;
    var ff = function(n, i) { return Math.pow(a[i][0], n) * fw.math.C(a[i][1], n) };
    (function f(t, i) {
        if (i == n) {
            if (fw.array.add(t) == num) r += fw.array.multiple(fw.each(t, ff));
            return;
        }
        for (var j = 0; j <= a[i][1]; j++) f(t.concat(j), i + 1);
    })([], 0);
    return r;
}

//弹出警告及获取焦点
trade.alert = function(obj, msg) {
    alert(msg);
    fw.get(obj).focus();
    return false;
}

//弹出表单信息
function alertForm() {
    alert(fw.json.tostring(fw.dom.getForm(document.buy_form)).replace(/:".*?",/g, "$&\n").slice(1, -1));
}
/////////////////////////////////公用代码end/////////////////////

//初始化
trade.init = function() {

    trade.newTip = (typeof TIPS == 'undefined'); //新旧提示
    if (trade.obj) return;
    trade.obj = fw.dom.getToObject(
		"multiple", 				//倍数输入框
		"baseCount", 			    //基本注数
		"showCount", 			    //倍数或期数
		"caseMoney"					//方案金额
	);

    trade.multiple = trade.obj.multiple ? Number(trade.obj.multiple.value) : 1;
    fw.getId("lotid") && (trade.lotid = Number(fw.getId("lotid").value));
    fw.getId("playid") && (trade.playid = Number(fw.getId("playid").value));
    fw.getId("expect") && (trade.period = fw.getId("expect").value);
    fw.getId("responseJson") && fw.object.merge(trade, fw.json.parse(fw.getId("responseJson").value));
    trade.singlePrice = trade.singlePrice || 2;

    fw.callEach([
    	{ obj: "btn_OK", handle: trade.onSubmit}								//提交方案
	], trade.addEvent);

    trade.addInputEvent("multiple", function() { trade.chkMultiple() }); 			//检查倍数

    //自适应高度
    trade.Resize = parent.autoHeight ? parent.autoHeight : new Function("return");

    window.hm && hm.init(); 									//发起合买初始化
    window.init && window.init(); 								//页面初始化
}

//添加事件
trade.addEvent = function(o) {
    if (!o.obj || !fw.get(o.obj)) {
        return false;
    }
    var obj = fw.get(o.obj);
    fw.dom.addEvent(obj, o.evt || "click", function() { o.handle.call(obj) });
}

trade.addInputEvent = function(obj, handle) {

    if (!obj || !fw.get(obj)) {
        return false;
    }

    obj = fw.get(obj);
    fw.dom.addEvent(obj, "input", handle);
    fw.dom.addEvent(obj, "keyup", handle);
    fw.dom.addEvent(obj, "change", handle);
    fw.dom.addEvent(obj, "blur", handle);
    fw.dom.addEvent(obj, "beforepaste", handle);
}

//计算金额
trade.calMoney = function(count) {
    return fw.conv.formatRMB(count * trade.singlePrice);
}

//格式化RMB
trade.formatRMB = function(m) {
    if (Number(m) == 0) {
        return "￥0.00";
    } else if (Number(m) < 0.01) {
        return "￥0.01";
    } else if (/^(\d+\.\d{2})[1-9]+$/.test(String(m))) {
        m = Number(RegExp.$1) + 0.01;
    }
    return fw.conv.formatRMB(m);
}

//获取总注数
trade.getTotalCount = function() {
    return trade.baseCount * trade.multiple;
}

//检查倍数
trade.chkMultiple = function() {

    trade.chkNumberBack(trade.obj.multiple);
    if (trade.multiple == trade.obj.multiple.value) return;
    trade.multiple = trade.obj.multiple.value;
    trade.multiple = Number(trade.multiple);
    trade.showTotalCount();
    sg_bonus.showfromvote(1);
}

//改变数据区信息
trade.updateInfo = function(m) {
    trade.showTotalCount(m);
}

//显示总注数
trade.showTotalCount = function(m) {
    var money = trade.getTotalCount() * trade.singlePrice;
    fw.setHTML('baseCount', trade.formatNum(trade.baseCount));
    if (fw.get('zhushu')) fw.get('zhushu').value = trade.formatNum(trade.baseCount);
    fw.setHTML("showCount", trade.multiple);
    fw.setHTML('caseMoney', trade.formatRMB(money));

    trade.onShowBack(money);
}

//提交方案句柄（第一步：开始数据准备）
trade.onSubmit = function() {

    //判断是否重复提交
    if (trade.submiting) return !!alert("请不要重复提交！");

    //灰掉提交按钮
    trade.graySubmit(true);

    //判断是否存在停售的赛事


    //第二步：登录及余额判断
    trade.islogin = parent.CreateLogin("");
    if (!trade.islogin) {
        trade.graySubmit(false);
        return;
    }

    //第二步：验证和准备提交前的数据
    if (!trade.chkForm()) {
        trade.graySubmit(false); //恢复提交按钮
        return;
    }

    //计算总注数和金额
    trade.totalcount = trade.getTotalCount();
    trade.totalmoney = trade.totalcount * trade.singlePrice;


    //如果是合买也要对合买数据进行验证
    if (trade.ishm) {
        //合买数据验证
        trade.hmdata = hm.chkForm(trade.totalmoney);
        if (!trade.hmdata) {
            trade.graySubmit(false); //恢复提交按钮
            return;
        }
    }

    trade.chkMoney();
}

//验证表单（第二步：表单数据验证）
trade.chkForm = function() {

    if (fw.getId("agreement") && !fw.getId("agreement").checked) {
        return !!alert("您需要阅读并且同意《用户合买代购协议》，才能够使用我们的服务。");
    } else if (!trade.onSubmitBefore()) {
        return false;
    }

    if (trade.obj.multiple && trade.obj.multiple.value == "") {
        return trade.alert("multiple", "倍数不能为空！");
    } else if (trade.multiple <= 0) {
        return trade.alert("multiple", "倍数必须为大于0的整数！");
    } else if (trade.multiple > 99) {
        return trade.alert("multiple", "倍数必须为小于100的整数！");
    }

    return true;
}

//检查用户余额是否充足（第四步）
trade.chkMoney = function() {

    var money = trade.hmdata ? trade.hmdata.money : trade.totalmoney;
    var blanceMoney = parent.getBalance().replace(",", "");

    if (parseFloat(money) > parseFloat(blanceMoney)) {
        var url = trade.baseUrl + "/Home/Room/OnlinePay/Default.aspx";
        trade.graySubmit(false);
        return window.confirm('\t您的可投注余额不足，请先充值！\n\n（点“确定”跳到充值页面,点“取消”返回修改）！\n\n') && window.open(url);
    }
    else {
        return trade.submitCase();
    }
}

//提交表单
trade.submitCase = function() {

    trade.setInput({
        codes: trade.getList(), 			//号码列表
        zhushu: trade.baseCount, 			//基本注数
        totalmoney: trade.totalmoney 		//总金额
    });

    var form = document.buy_form;
    var mode = trade.submitMode;
    var o = trade.hmdata;

    //合买
    if (o) {

        var s = fw.getId("buyMoney") ? "，您认购" + fw.getId("buyMoney").innerHTML + "元" : "";

        if (trade.confirm && !confirm(trade.confirmMsg || "本次合买金额" + trade.calMoney(trade.totalcount) + "元" + s + "，是否发起？")) {
            trade.graySubmit(false); 		//恢复按钮为可以点击
            return;
        }
        //提交数据
        return trade.submitBy(mode == "" ? "form" : mode, form);
    } else {

        var tip = "本次代购金额" + trade.calMoney(trade.totalcount) + "元，是否发起？";
        if (trade.confirm && !confirm(trade.confirmMsg || tip)) {
            return trade.graySubmit(false);
        }

        return trade.submitBy(mode, form);

    }

}

//提交方式
trade.submitBy = function(mode, form) {
    trade.graySubmit(true);
    trade.debug && alertForm();
    if (mode == "ajax") trade.submitByAjax(form);
    else if (mode == "form") form.submit();
}

//提交成功回调
trade.submitBack = function(o) {
    trade.graySubmit(false);
    trade.debug && alert(fw.json.tostring(o));
    trade.onSubmitBack(o);
}

//是否禁用提交按钮
trade.graySubmit = function(b) {
    trade.submiting = b;
    fw.getId("btn_OK") && (fw.getId("btn_OK").disabled = b);
}

//ajax提交
trade.submitByAjax = function(form) {
    trade.escape(["codes", "danma", "title", "content", "setbuyuser", "ggtypename"]);
    var json = {
        url: form.ajax,
        form: form,
        onsuccess: trade.submitBack,
        onfail: function() {
            alert("提交失败！");
            trade.graySubmit(false);
        }
    };

    fw.ajax.request(json);
    trade.unescape(["codes", "danma", "title", "content", "setbuyuser", "ggtypename"]);
}

//调试信息开关（双击）
document.ondblclick = function() {
    if (!fw.event.getEvent().altKey) return;
    alert("调试模式已" + ["关闭", "打开"][Number(trade.debug = !trade.debug)]);
    document.body.setAttribute("oncontextmenu", "return " + trade.debug);
    fw.isie && (document.body.oncontextmenu = function() { return trade.debug });
    trade.addSelectAllBtn();
}

//增加全选按钮
trade.addSelectAllBtn = function() {
    if (fw.getId("quanxuan")) {
        with (fw.getId("quanxuan").style) display = display != "" ? "" : "none";
        return;
    }
    var obj = fw.create("button", { id: "quanxuan", html: "全选" });
    window.gg && (obj.onclick = gg.onSelectAll);
    var ol = fw.getId("mathList") || fw.getId("numberList");
    var po = ol.parentNode.parentNode;
    po.insertBefore(obj, po.lastChild);
}

//光标跳到某行
trade.setLine = function(Id, i) {
    var e = document.getElementById(Id);
    var va = (e.value + "\n").replace(/\n+$/, "\n");
    var s1 = va.match(eval("/^(.+\\n){" + (i - 1) + "}/ig"));
    if (!s1) return;
    var s2 = va.match(eval("/^(.+\\n){" + (i) + "}/ig"));
    var count = va.match(/.+\n/ig).length + 5;
    var startPos = s1[0].length;
    var endPos = s2[0].length;
    if (e.createTextRange) {
        var r = e.createTextRange();
        r.collapse();
        r.moveStart('character', startPos - i + 1);
        r.moveEnd('character', endPos - startPos - 1);
        r.select();
    } else {
        e.selectionStart = startPos;
        e.selectionEnd = endPos;
        e.scrollTop = e.scrollHeight / count * (i - 1);
        e.focus();
    }
};
