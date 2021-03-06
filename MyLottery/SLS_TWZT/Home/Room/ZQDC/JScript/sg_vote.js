var ErrorInfo = []; //用来存储错误信息.
function logError(func, vars, log) {
    ErrorInfo.push(['执行函数:' + func, ('[' + vars.join('\t') + ']'), log].join('\t'));
}
function showErrorInfo() {
    alert(ErrorInfo.join('\n'));
    return false;
}
var sg_vote = {};
//初始化
sg_vote.init = function() {

    trade.getList = sg_vote.getList;
    trade.onSubmitBefore = sg_vote.onSubmitBefore;
    trade.onSubmitBack = sg_vote.onSubmitBack;

    sg_vote.nb = [];
    sg_vote.ggtype = 1; 	//1.普通过关		2.组合过关		3.自由过关
    sg_vote.ggmode = "";
    sg_vote.ggmList = [];
    sg_vote.hideNum = 0; //隐藏的场次
    sg_vote.endItem = {};
    sg_vote.endTimeList = {}; //结束时间
    sg_vote.name = { 4501: "sf", 4503: "ds", 4502: "jq", 4505: "bq", 4504: "bf"}[trade.playid],
  sg_vote.MAX = {
      4501: [0, 1, 2],
      4502: [0, 1, 2, 3, 4, 5, 6, 7],
      4503: [0, 1, 2, 3],
      4504: [fw.array.createNum(0, 9), [10, 11, 12, 13, 14], fw.array.createNum(15, 24)],
      4505: fw.array.createNum(0, 8)
}[trade.playid];
    sg_vote.maxCount = { bf: 3, sf: 15}[sg_vote.name] || 6;
    sg_vote.spv = ({
        sf: [11, 12, 13],
        ds: [10, 11, 12, 13],
        jq: fw.array.createNum(7, 14),
        bq: fw.array.createNum(7, 15),
        bf: [fw.array.createNum(1, 10), [1, 2, 3, 4, 5], fw.array.createNum(1, 10)]
    })[sg_vote.name];
    sg_vote.cols = sg_vote.spv.length;

    if (window.sg_league) {
        sg_vote.setData();
        sg_league.create();
    }

    sg_vote.maxRow = 100;
    sg_vote.isCutRepeat = true;
    sg_vote.danCount = 0;

    sg_vote.class0 = "sp_bg";
    sg_vote.class1 = "sp_sbg";
    fw.callEach([
		{ obj: "CoBuy", handle: sg_vote.onCoBuy },
		{ obj: "clearOptionBtn", handle: sg_vote.clearOptionBefore }
	], trade.addEvent);

    fw.callEach(['rq_changci', 'frq_changci', 'jz_changci'], function(v, i) {
        if (fw.get(v + '_span')) {
            fw.get(v + '_span').innerHTML = (fw.get(v) && fw.get(v).value) || 0;
        }
    });

    //初始化过关数据
    sg_vote.setGgMode();

    //如果，所有的赛事都结束了，那么就默认显示截止的赛事
    if (fw.get("noMatch") && fw.get("noMatch").value == 0) {
        sg_league.showEndByText();
        fw.getId("showEndBtn").checked = true;
        fw.getId("showEndBtn").disabled = true;
    }
    else {
        //否则，启动SP自动更新
        window.sg_sp && sg_sp.init();
    }
}

//设置过关数据
sg_vote.setData = function() {
    sg_vote.data = [];
    sg_vote.serial2row = [];
    var r = 0, tb = fw.getId("mathList"), tr, o, obj;

    for (var i = 0, l = tb.rows.length; i < l; i++) {
        tr = tb.rows[i];
        if (tr.style.display == "none") {
            if (sg_vote.name == 'bf') {
                sg_vote.endItem['_' + i] = 1;
                sg_vote.endItem['_' + (i + 1)] = 1;
                sg_league.lgList.end = sg_league.lgList.end.concat([i, ++i]);
            } else {
                sg_league.lgList.end = sg_league.lgList.end.concat(i);
                sg_vote.endItem['_' + i] = 1;
            }
            continue;
        }

        if (tr.cells.length == 1) continue;
        o = sg_vote.data[r] = { obj: [], sp: [], die: [] };
        if (sg_vote.name == "bf") {
            sg_vote.setBfData(tb.rows, i, o, r);
            t = [i, ++i];
        } else {
            sg_vote.setOtherData(tb.rows, i, o, r);
            t = i;
        }
        sg_vote.serial2row[o.serialNumber] = r;
        sg_league.lgList[o.lg] = (sg_league.lgList[o.lg] || []).concat(t);
        r++;
    }
}
//设置其他过关数据
sg_vote.setOtherData = function(rows, i, o, r) {
    var td = rows[i].cells;
    o.serialNumber = fw.trim(td[0].innerHTML.replace(/<.+?>/g, ''));

    o.lg = td[1].innerHTML.replace(/<.+?>/g, '');

    o.main = td[4].innerHTML.replace(/<.+?>/g, '');

    o.guest = td[6].innerHTML.replace(/<.+?>/g, '');

    if (sg_vote.name != 'sf') {
        o.guest = td[5].innerHTML.replace(/<.+?>/g, '');
    } else {
        o.rq = +(td[5].innerHTML.replace(/<.+?>/g, '')); //如果是让球胜平负
    }

    //获取本赛事普通过关、自由过关的销售时间
    sg_vote.endTimeList[o.serialNumber] = [
      td[3].getAttribute('tradeendtime'),
      td[3].getAttribute('zhggendtime')
    ];

    //定义SP值
    for (var c = 0; c < sg_vote.cols; c++) {
        obj = o.obj[c] = td[sg_vote.spv[c]];
        obj.onclick = sg_vote.onItemClick(r, c);
        obj.style.cursor = "pointer";
        o.sp[c] = sg_vote.getspbyhtml(obj.innerHTML);
        o.die[c] = 1 == "--";
    }
}

//设置比分过关数据
sg_vote.setBfData = function(rows, i, o, r) {
    var td = rows[i].cells;
    o.serialNumber = +td[0].innerHTML.replace(/<.+?>/g, '');
    o.lg = td[1].innerHTML.replace(/<.+?>/g, ''); //赛事类型
    o.main = td[4].innerHTML.replace(/<.+?>/g, ''); //主队
    o.guest = td[5].innerHTML.replace(/<.+?>/g, ''); //客队

    //获取本赛事普通过关、自由过关的销售时间
    sg_vote.endTimeList[o.serialNumber] = [
      td[3].getAttribute('tradeendtime'),
      td[3].getAttribute('zhggendtime')
    ];

    var c = 0;
    i++;
    fw.callEach(sg_vote.spv, function(a, VV) {
        td = rows[i].cells[0].getElementsByTagName('table')[0].rows[VV].cells;
        fw.callEach(a, function(j) {
            obj = o.obj[c] = td[j];
            obj.onclick = sg_vote.onItemClick(r, c);
            obj.style.cursor = "pointer";
            o.sp[c] = sg_vote.getspbyhtml(obj.innerHTML.replace(/<.+?>/g, '').split(/[\(\)]/)[1]);
            o.die[c++] = 1 == "--";
        });
    });
}
sg_vote.getspbyhtml = function(sphtml) {

    sphtml = fw.trim(sphtml.replace(/<.+?>/ig, '').replace(/\s+/g, '').replace(/↑|↓/g, ''))

    return +sphtml >= 0 ? +sphtml : { "": 0, "--": -1, "0.00": 0}[sphtml];
}
sg_vote.setPanel = function(o, i) {
    o.className = 'tab_op1';
    fw.get('panel_' + i).className = 'tab_op2';
    fw.get('table_vs').className = 'ttd ' + ((['b', 'a'])[i - 1]);
    if (fw.isie) {
        fw.get('table_vs').rows[3].cells[([11, 8][i - 1])].style.display = 'none';
        fw.get('table_vs').rows[3].cells[([8, 11][i - 1])].style.display = 'block';
    }
}
sg_vote.fixNum = function(n) {
    n = parseFloat(n);
    if (isNaN(n)) return '--';
    if (n <= 0) return '--';
    n = n + ((('' + n).indexOf('.') != -1) ? '' : '.') + '00';
    n = n.replace(/(.+?\.\d\d).*/g, '$1');
    if (parseFloat(n) >= 1000) return ('' + n).split('.')[0];
    return n;
}

//显示和买分成
sg_vote.showHmDiv = function() {
    if (/_1\.gif$/i.test(this.src)) return !!alert("对不起，合买发起时间已截止");
    with (fw.getId("hmDiv").style) {
        display = display != "" ? "" : "none";
    }
    trade.Resize();
}

//单击某个场次结果
sg_vote.onItemClick = function(r, c) {
    return function() {
        sg_vote.data[r].obj[c].className != sg_vote.class1 ? sg_vote.add(r, c) : sg_vote.del(r, c);
    }
}

//添加到已选列表
sg_vote.add = function(r, c) {
    var o = sg_vote.data[r];
    if (o.die[c]) return !!alert("对不起，此赛道的参赛者已弃权！");

    var i = fw.oa.getIdxBy(sg_vote.nb, "row", r);
    if (i > -1) {
        sg_vote.nb[i].arr.push(c);
        fw.array.sortNumber(sg_vote.nb[i].arr);
    } else if (sg_vote.count >= sg_vote.maxRow) {
        return !!alert("最多只能选择" + sg_vote.maxRow + "场比赛!");
    } else {
        sg_vote.nb.push({ row: r, dan: false, arr: [c], index: fw.get('index_' + r).getAttribute('index') });
        fw.oa.sortNumberBy(sg_vote.nb, "row");
    }
    o.obj[c].className = sg_vote.class1;
    var tInput = o.obj[c].getElementsByTagName('input'); //选中复选框
    if (tInput.length > 0) {
        tInput[0].checked = true;
    }
    (sg_vote.name == 'bf') ? sg_vote.checkStatus(r, c) : sg_vote.checkStatus(r);
    sg_vote.chgRt();
}
sg_vote.checkStatus = function(i, M) {
    if (!sg_vote.MAX) {
        return !!alert('未定义sg_vote.MAX!\n' + sg_vote.name);
    }
    var s = true, TEMP = sg_vote.MAX, v;
    var id = 'ck_' + i;
    if (sg_vote.name == 'bf') {
        v = M > 14 ? 2 : M > 9 ? 1 : 0;
        TEMP = sg_vote.MAX[v];
        id = 'ALL_' + i + '_' + v;
    }
    var l = TEMP.length;
    for (var m = 0; m < l; m++) {
        try {
            if (!fw.get('ck_' + i + '_' + TEMP[m]).checked) {
                s = false;
                break;
            }
        } catch (e) {
            logError('checkStatus', ['i:' + i, 'm:' + m, ('temp[m]:' + temp[m])], e.description);
        }
    }
    fw.get(id).checked = s;
}
//清除已选列表
sg_vote.del = function(r, c) {
    var o = sg_vote.data[r];
    if (!o) return false;
    o.obj[c].className = sg_vote.class0;
    var tInput = o.obj[c].getElementsByTagName('input'); //取消复选框
    if (tInput.length > 0) {
        tInput[0].checked = false;
    }

    var i = fw.oa.getIdxBy(sg_vote.nb, "row", r);
    if (!sg_vote.nb[i]) return false;
    i > -1 && fw.array.removeText(sg_vote.nb[i].arr, c);
    sg_vote.nb[i].arr.length == 0 && sg_vote.nb[i].dan && sg_vote.danCount--;
    sg_vote.nb[i].arr.length == 0 && sg_vote.nb.splice(i, 1);
    (sg_vote.name == 'bf') ? sg_vote.checkStatus(r, c) : sg_vote.checkStatus(r);
    sg_vote.chgRt();
    return true;
}

//清空选项之前
sg_vote.clearOptionBefore = function() {
    window.confirm("你确认要清空选项么？") && sg_vote.clearOption();
}

//清空选项
sg_vote.clearOption = function() {
    fw.callEach(sg_vote.nb, function(o, I) {
        if (sg_vote.name != 'bf') {
            fw.get('ck_' + o.row).checked = false;
        } else {
            fw.callEach([0, 1, 2], function(i) {
                fw.get('ALL_' + o.row + '_' + i).checked = false;
            });
        }
        fw.callEach(o.arr, function(c) {
            sg_vote.data[o.row].obj[c].className = sg_vote.class0;
            var tInput = sg_vote.data[o.row].obj[c].getElementsByTagName('input'); //选中复选框
            if (tInput.length > 0) {
                tInput[0].checked = false;
            }
        });
    });
    sg_vote.nb = [];
    sg_vote.ggmList = [];
    sg_vote.chgRt();

    //重置倍数
    trade.obj.multiple.value = 1;
    trade.chkMultiple();

    //隐藏合买区域
    if (fw.getId("CoBuy").checked)
        fw.getId("CoBuy").click();
}

//改变场次结果
sg_vote.chgRt = function(sp) {
    fw.get('jiangjinYS').innerHTML = '0-0';
    if (sg_vote.count != sg_vote.nb.length) {
        var n = sg_vote.ggmode != "" ? sg.type2nm[sg_vote.ggmode].n : 0;
        sg_vote.ggtype == 1 && (sg_vote.ggmode = "");
        sg_vote.ggtype == 2 && sg_vote.nb.length < n && (sg_vote.ggmode = "");
        sg_vote.ggtype == 3 && fw.each(sg_vote.ggmList, function(s) { if (sg.type2nm[s].n <= sg_vote.nb.length) return s }) && (sg_vote.ggmode = sg_vote.ggmList.length > 0 ? sg_vote.ggmList[0] : "");
        sg_vote.count = sg_vote.nb.length;
    }
    fw.dom.insertRows2("selectList", sg_vote.rt_html(), true);
    fw.dom.insertRows2("ggList", sg_vote.gg_html(), true);
    if (fw.get("mathCount")) fw.get("mathCount").innerHTML = sg_vote.count;
    sg_vote.ggmode == "" && sg_vote.clearDan();
    
    //如果本函数是由更新SP值时调用的，那么就不做数据的更新
    !sp && sg_vote.update();
    
    sg_vote.chkDan();
    sg_vote.grayGgType();
    setTimeout(sg_vote.setEndTime, 100);
    trade.Resize();
}

sg_vote.setEndTime = function() {
    var maxID = 9999;
    for (var i = 0, l = sg_vote.nb.length; i < l; i++) {
        if (sg_vote.nb[i].index < maxID) maxID = sg_vote.nb[i].index;
    }
    if (maxID == 9999) {
        fw.get('normal_endTime').innerHTML = '--';
        fw.get('zh_endTime').innerHTML = '--';
        fw.getId('zh_stopTime').value = '--';
        fw.getId('normal_stopTime').value = '--';
        return;
    }
    if (sg_vote.endTimeList[maxID]) {
        fw.get('normal_endTime').innerHTML = sg_vote.endTimeList[maxID][0] || '';
        fw.get('zh_endTime').innerHTML = sg_vote.endTimeList[maxID][1] || '';
        fw.getId('normal_stopTime').value = sg_vote.endTimeList[maxID][0] || '';
        fw.getId('zh_stopTime').value = sg_vote.endTimeList[maxID][1] || '';
    }
}
//场次结果HTML
sg_vote.rt_html = function() {
    var html = [];
    fw.callEach(sg_vote.nb, function(o, i) {
        var data = sg_vote.data[o.row];
        var t = sg_vote.ball_html(o);
        var ball = t.ball.join('');
        var sp = t.sp.join(' ');
        var dan = '<input type="checkbox"' + (o.dan ? ' checked="true" ' : ' ') + 'onclick="sg_vote.setDan(' + i + ',this)" />';
        if (sg_vote.name == 'bf') {
            var NN = fw.toNum(data.serialNumber) - 1;
            if (fw.get('ttr_' + NN)) fw.get('ttr_' + NN).style.display = '';
            if (fw.get('ttr_img_' + NN)) fw.get('ttr_img_' + NN).src = 'images/btn_sp_hide.gif';
        }
        html[i] = '<tr><td align="center" height="24" bgcolor="#FFFFFF" class="black12"><input type="checkbox" checked="checked" onclick="sg_vote.cancelSelect(' + o.row + ')"/>' + data.serialNumber + '</td><td align="center" bgcolor="#FFFFFF" class="black12">' + data.main + ' VS ' + data.guest + '</td><td align="center" bgcolor="#FFFFFF" class="black12">' + ball + '</td><td align="center" bgcolor="#FFFFFF" width="1" style="display:none;">' + sp + '</td><td align="center" bgcolor="#FFFFFF" style="display:none;" class="black12">' + dan + '</td></tr>';
    });
    html = html.join("");

    return html;
}
sg_vote.selectAll = function(i, o, W) {//全选
    if (!sg_vote.MAX) return false;
    var TEMP = sg_vote.MAX;
    if (typeof W != 'undefined') TEMP = sg_vote.MAX[W];
    fw.callEach(TEMP, function(v) {
        try {
            if ((o && !fw.get('ck_' + i + '_' + v).checked) || (!o && fw.get('ck_' + i + '_' + v).checked)) sg_vote[o ? 'add' : 'del'](i, v);
        } catch (e) {
            logError('sg_vote.selectAll', ['i:' + i, 'v:' + v], e.description);
        }
    });
}
sg_vote.cancelSelect = function(i, o) {
    if (!sg_vote.MAX) return false;
    if (sg_vote.name == 'bf') {
        fw.callEach([0, 1, 2], function(I) {
            fw.callEach(sg_vote.MAX[I], function(v) {
                if (fw.get('ck_' + i + '_' + v).checked) {
                    sg_vote.del(i, v);
                }
            });
        });
    } else {
        fw.callEach(sg_vote.MAX, function(v) {
            if (fw.get('ck_' + i + '_' + v).checked) {
                sg_vote.del(i, v);
            }
        });
    }
    if (o) {
        if (sg_vote.name == 'bf') {
            o.parentNode.parentNode.nextSibling.style.display = 'none';
        }
        o.parentNode.parentNode.style.display = 'none';
        sg_vote.hideNum++;
        sg_vote.showHideNum();
        o.checked = true;
    }
}

/////////////////新添加的//////////////////////
//隐藏SP
sg_vote.hideSP = function(o, img, g) {
    o = fw.get(o);
    if (o) {
        var s = o.style.display;
        o.style.display = ((s == '') ? 'none' : '');
        img.src = 'images/' + ((s == '') ? (!g ? 'btn_sp_show.gif' : 'btn_sp.gif') : 'btn_sp_hide.gif');
    }
    trade.Resize(); //自动撑开Iframe的高度
    return false;
}
///////////////////////////////////////////////


sg_vote.showHideNum = function(v) {
    fw.get('showHideNum').innerHTML = sg_vote.hideNum;
    if (!v && sg_vote.hideNum < 1 && sg_vote.name == 'sf') {
        var rq = fw.dom.getName("rangqiu");
        rq[0].checked = rq[1].checked = true;
    }
}
//过关HTML
sg_vote.gg_html = function() {
    var j = 0;
    var tr = null;
    var a = [], w = 70, K = 0;
    var f = function(s, ipt) {
        if (j) {
            j++ % 5 == 0 && a.push('</tr><tr>');
        }
        else {
            j++;
        }
        var cs = (j - (Math.floor(j / 5) * 5 + 1)) % 2 == 1 ? ' class="td01"' : ' class="td02"';
        a.push('<td width="' + w + '"' + cs + '><input type="' + ipt + '"' + ((sg_vote.ggtype == 3 ? fw.array.getIdx(sg_vote.ggmList, s) > -1 : sg_vote.ggmode == s) ? ' checked="true" ' : ' ') + 'name="ggtype_radio" onclick="sg_vote.chgGgType(this);" id="ggtype_radio_' + j + '" value="' + s + '" /><label for="ggtype_radio_' + j + '">' + s + '</label></td>');
    };
    for (var i = sg_vote.ggtype == 1 ? sg_vote.count - 1 : 0; i >= 0 && i < sg_vote.count && i < sg_vote.maxCount; i++) {
        sg_vote.ggtype == 3 ? f(sg.collection[i][0], "checkbox") : fw.callEach(sg.collection[i], function(s) { f(s, "radio") });
    }
    var NN = 6;
    if (sg_vote.name == 'bf') NN = 3;
    if (sg_vote.name == 'sf') NN = 15;

    return '<tr>' + a.join("") + ((j == 0 && sg_vote.count > 0) ? ('<td colspan="5">超过' + NN + '场比赛，请选择“组合过关”或者“自由过关”</span>') : ((j % 5 != 0 && sg_vote.count > 0) ? (new Array(6 - j % 5).join('<td width="' + w + '">&nbsp;</td>')) : '')) + '</tr>';
}

//球HTML
sg_vote.ball_html = function(o) {
    var r = { ball: [], sp: [] };

    fw.callEach(o.arr, function(c, i) {
        var cc = sg.mr[c];

        r.ball[i] = '<input type="checkbox" checked="true" onclick="sg_vote.del(' + o.row + ',' + c + ')" />' + cc;
        r.sp[i] = cc + "(" + sg_vote.data[o.row].sp[c] + ")";
    });
    return r;
}

//设置胆
sg_vote.setDan = function(idx, obj) {
    if (obj.checked && !sg_vote.onAddDanBefore()) return (obj.checked = false);
    sg_vote.nb[idx].dan = obj.checked;
    obj.checked ? sg_vote.danCount++ : sg_vote.danCount--;
    sg_vote.grayGgType();
    sg_vote.update();
}

//加胆之前
sg_vote.onAddDanBefore = function(obj) {
    if (sg_vote.ggtype == 1) {
        return !!alert('胆码只适用"组合过关"和"自由过关"');
    } else if (sg_vote.ggmode != "" && sg_vote.danCount + 1 == sg.type2nm[sg_vote.ggmode].n) {
        return !!alert("您选择的过关方式是：" + (sg_vote.ggtype < 3 ? sg_vote.ggmode : sg_vote.ggmList) + "，胆码个数不能超过" + sg_vote.danCount + "个!");
    } else if (sg_vote.danCount + 1 == sg_vote.count) {
        return !!alert("不能把所有场次设为胆码!");
    }
    return true;
}

//check胆
sg_vote.chkDan = function() {
    if (sg_vote.ggmode == "") return sg_vote.grayDan(false);
    var o = sg.type2nm[sg_vote.ggmode];
    sg_vote.grayDan(o.n == 1 || o.n == sg_vote.count && o.m == 1);
}

//历遍胆
sg_vote.eachDan = function(cb) {
    var rs = fw.getId("selectList").rows;
    fw.callEach(sg_vote.nb, function(o, i) {
        cb(fw.dom.getObjTag(rs[i].cells[4], "input")[0], o);
    });
}

//清空胆
sg_vote.clearDan = function() {
    sg_vote.eachDan(function(obj, o) {
        obj.checked = false;
        o.dan = false;
    });
    sg_vote.danCount = 0;
    sg_vote.grayGgType();
}

//是否灰掉胆
sg_vote.grayDan = function(b) {
    sg_vote.eachDan(function(obj) {
        obj.disabled = b;
    });
    b && sg_vote.clearDan();
}

//设置过关方式
sg_vote.setGgMode = function() {
    var CB = function(n) {
        sg_vote.ggtype = [1, 2, 3][n];
        sg_vote.ggmode = "";
        sg_vote.ggmList = "";
        fw.get('jiangjinYS').innerHTML = '0-0';
        fw.dom.insertRows2("ggList", sg_vote.gg_html(), true);
        sg_vote.update();
        sg_vote.clearDan();
        sg_vote.chkDan();
        trade.Resize();
    }

    if (fw.get('ggType_1')) {
        fw.array.callEach(['ggType_1', 'ggType_2', 'ggType_3'], function(v, i) {
            if (fw.get(v)) {
                fw.get(v).onclick = function() {
                    CB(i);
                }
            }
        });
    }
}

//改变过关类型
sg_vote.chgGgType = function(obj) {
    sg_vote.ggmode = obj.value;
    sg_vote.ggtype == 3 && (sg_vote.ggmList = fw.dom.getCheckbox("ggtype_radio")) && (sg_vote.ggmode = sg_vote.ggmList.length > 0 ? sg_vote.ggmList[0] : "");
    sg_vote.chkDan();
    sg_vote.update();
}

//灰掉过关类型
sg_vote.grayGgType = function() {
    var objR = fw.dom.getName("ggtype_radio");
    for (var i = 0; i < objR.length; i++) {
        objR[i].disabled = sg.type2nm[objR[i].value].n <= sg_vote.danCount;
    }
}

//更新
sg_vote.update = function() {
    trade.baseCount = 0;
    if (sg_vote.ggmode != "") {
        var t = [], d = [];
        fw.callEach(sg_vote.nb, function(o) {
            (o.dan ? d : t).push(o.arr.length);
        });
        t = fw.array.getNum(t);
        d = fw.array.getNum(d);
        var ar = sg_vote.ggtype == 3 ? fw.each(sg_vote.ggmList, function(s) { return sg.type2nm[s].n }, []).reverse() : sg.ggm2num[sg_vote.ggmode];
        var b = sg_vote.isCutRepeat || sg_vote.ggtype != 2 || sg.type2nm[sg_vote.ggmode].m == 1;

        trade.baseCount = d.length == 0 ? sg.C(t, ar) : sg_vote.calCount(t, d, ar);
    }
    trade.updateInfo();
}

//计算注数(去重复有胆)
sg_vote.calCount = function(t, d, ar) {
    var dn = 0, mp = 1;
    for (var i = 0, l = d.length; i < l; i++) {
        dn += d[i][1];
        mp *= Math.pow(d[i][0], d[i][1]);
    }
    var n = 0;
    fw.callEach(ar, function(m) {
        n += m > dn ? sg.C(t, m - dn) * mp : sg.C(d, m);
    });
    return n;
}

//合买
sg_vote.onCoBuy = function() {

    //当选择合买，显示合买信息
    if (this.checked) {
        trade.ishm = true;
        trade.ISHM = 1;
        fw.getId("trShowJion").style.display = "";
    }
    else {
        trade.ishm = false;
        trade.ISHM = 0;
        fw.getId("trShowJion").style.display = "none";
    }

    fw.getId("ishm").value = trade.ISHM;

    trade.Resize();
}

//提交前工作（第四步）
sg_vote.onSubmitBefore = function() {

    trade.confirm = true;
    var a = sg_vote.getList().split("/");   //所选比赛
    var d = [];                             //所有比赛的胆码

    fw.callEach(sg_vote.nb, function(o, i) {
        o.dan && d.push(a[i]);
    });
    if (a == "" || a.length == 0) {
        return !!alert("请先选择比赛及参考sp值!");
    } else if (sg_vote.ggmode == "") {
        return !!alert("请选择过关方式!");
    } else if (d.length == a.length) {
        return !!alert("胆码个数必须小于总场数!");
    } else if (fw.getId("maxmoney") && trade.baseCount * trade.singlePrice > fw.getId("maxmoney").value) {
        return !!alert("单倍认购金额最大不能超过" + fw.getId("maxmoney").value + "元");
    }

    fw.getId("ggtypegroupid").value = sg_vote.ggtype;

    var ggm = fw.getId("ggtypename").value = sg_vote.ggmode;
    var tl = fw.json.parse(fw.getId("jsonggtype").value);
    fw.getId("ggtypeid").value = tl[sg_vote.ggmode];

    if (sg_vote.ggtype == 3) {
        ggm = fw.getId("ggtypename").value = sg_vote.ggmList.join(",");
        fw.getId("ggtypeid").value = fw.each(sg_vote.ggmList, function(s) { return tl[s] }, []);
    }

    fw.getId("danma").value = d.join("/");

    return true;
}

//提交成功回调
sg_vote.onSubmitBack = function(result) {
    if (result == "true") {
        alert((trade.ishm ? "合买" : "代购") + "方案发起成功！");
        sg_vote.clearOption();

        //更新余额
        parent.UpdateBindData();
    } else if (result == "") {
        alert((trade.ishm ? "合买" : "代购") + "方案发起失败！");
    } else {
        alert(unescape(result));
    }
    trade.graySubmit(false);
}

//获取列表
sg_vote.getList = function() {
    var a = fw.each(sg_vote.nb, function(o) {
        return sg_vote.data[o.row].serialNumber + ":[" + fw.each(o.arr, sg.idx2mr, []).join(",") + "]";
    }, []);
    return a.join("/");
}

//全选公用接口
sg_vote.onSelectAll = function() {
    for (var r = 0; r < sg_vote.data.length; r++) {
        var a = sg_vote.data[r];
        sg_vote.nb[r] = { row: r, dan: false, arr: [] };
        for (var c = 0; c < a.length; c++) {
            a[c].obj.className = sg_vote.class1;
            sg_vote.nb[r].arr[c] = c;
        }
    }
    sg_vote.chgRt();
}
fw.onReady(function() {
    if (fw.get('sel_Expect')) {
        fw.get('sel_Expect').onchange = function() {
            var url = location.href;
            if (url.indexOf('expect') != -1) {
                url = url.replace(/expect=.+?(&.*?|$)/ig, 'expect=' + this.value.split('|')[0]);
            } else {
                url += '&expect=' + this.value.split('|')[0];
            }
            location.replace(url);
        }
    }
});