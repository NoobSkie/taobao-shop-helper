sg_league = {};

//赛事初始化
sg_league.init = function() {
    sg_league.mgObj = fw.getId("mgList");
    sg_league.mtObj = fw.getId("mathList");
    sg_league.lgList = {};
    sg_league.lgList.end = [];
    if (!sg_league.mgObj) return;
    fw.each([
		{ obj: "mathSelectBtn", handle: sg_league.show },
		{ obj: "showEndBtn", handle: sg_league.showEndByText },
		{ obj: "selectAllBtn", handle: sg_league.selectAll },
		{ obj: "selectOppBtn", handle: sg_league.selectOpposite }
	], trade.addEvent);
    var rq = fw.dom.getName("rangqiu");
    if (rq.length > 0) rq[0].onclick = rq[1].onclick = sg_league.giveBall;
}

//添加赛事
sg_league.create = function() {
    if (!sg_league.mgObj) return;
    var html = [];
    for (var i in sg_league.lgList) {
        i = i.replace(/<.+?>/g, '');
        i !== "end" && html.push('<tr><td><input id="lg' + i + '" onclick="sg_league.showHide(\'' + i + '\', this.checked);" type="checkbox" checked="checked"><label for="lg' + i + '">' + i + '</label></td></tr>');
    }
    html = html.join("");
    fw.dom.insertRows2("mgList", html, true);
}

//显示赛事框
sg_league.show = function() {
with (fw.getId("divLeagues").style) {
        display = display != "none" ? "none" : "";
    }
}

//全选
sg_league.selectAll = function() {
    var rows = sg_league.mgObj.rows;
    for (var i = 0, l = rows.length; i < l; i++) {
        with (rows[i].cells[0].firstChild) {
            !checked && (checked = true) && sg_league.showHide(id.slice(2), true);
        }
    }
}

//反选
sg_league.selectOpposite = function() {
    var rows = sg_league.mgObj.rows;
    for (var i = 0, l = rows.length; i < l; i++) {
        with (rows[i].cells[0].firstChild) {
            checked = !checked;
            sg_league.showHide(id.slice(2), checked);
        }
    }
}

//显示已截止对阵
sg_league.showEndByText = function() {
    var txt;
    with (fw.getId("showEndBtn")) {
        if (tagName.toLowerCase() == 'input') {//复选框
            var l = fw.get('showEndLabel');
            if (l.getAttribute('status') == null) {
                txt = '隐藏';
                l.setAttribute('status', 1);
            } else {
                txt = '显示';
                l.removeAttribute('status');
            }
        } else {
            var txt = /隐藏/.test(innerHTML) ? "显示" : "隐藏";
            innerHTML = txt + "已截止场次";
        }
    }
    if (txt == "显示") {
        sg_league.showHide("end", false);
        if (sg_vote.name == 'sf') {
            fw.get('frq_changci_span').innerHTML = fw.get('frq_changci').value;
            fw.get('rq_changci_span').innerHTML = fw.get('rq_changci').value;
        }
    } else {
        sg_league.showAll();
        if (sg_vote.name == 'sf') {
            fw.get('frq_changci_span').innerHTML = fw.toNum(fw.get('frq_changci').value) + fw.toNum(fw.get('jzfrq_changci').value);
            fw.get('rq_changci_span').innerHTML = fw.toNum(fw.get('rq_changci').value) + fw.toNum(fw.get('jzrq_changci').value);
        }
    }
}

//显示或隐藏
sg_league.showHide = function(lg, isshow) {
    var s;
    if (typeof sg_league.lgList[lg] == 'undefined') return false;
    fw.callEach(sg_league.lgList[lg], function(r) {
        if (!sg_league.mtObj.rows[r]) return false;
        s = sg_league.mtObj.rows[r].style;
        if (isshow && s.display != '' && (sg_league.mtObj.rows[r].id == '' || sg_league.mtObj.rows[r].id.substr(0, 3) != 'ttr')) sg_vote.hideNum--;
        if (lg != 'end' && !isshow && s.display != 'none' && (sg_league.mtObj.rows[r].id == '' || sg_league.mtObj.rows[r].id.substr(0, 3) != 'ttr')) sg_vote.hideNum++;
        if (sg_league.mtObj.rows[r].id.substr(0, 3) != 'ttr') {
            isshow ? s.display != "" && (s.display = "") : s.display != "none" && (s.display = "none");
        }
    });
    sg_vote.showHideNum();
    trade.Resize();
}
//显示隐藏的场次
sg_league.showMatch = function() {
    if (sg_vote.hideNum > 0) {
        var rows = sg_league.mgObj.rows;
        var p = [];
        for (var i = 0, l = rows.length; i < l; i++) {
            sg_league.showHide(rows[i].cells[0].firstChild.id.slice(2), true);
        }
    }
    sg_vote.hideNum = 0;
    sg_vote.showHideNum(1);
    var rows = sg_league.mgObj.rows;
    for (var i = 0, l = rows.length; i < l; i++) {
        with (rows[i].cells[0].firstChild) {
            !checked && (checked = true);
        }
    }
    return false;
}
//显示所有对阵
sg_league.showAll = function() {
    for (var i = 0, l = sg_league.mtObj.rows.length; i < l; i++) {
        if (sg_league.mtObj.rows[i].id == '' || sg_vote.name != 'bf') with (sg_league.mtObj.rows[i].style) display != "" && (display = "");
    }
    trade.Resize();
    var rows = sg_league.mgObj.rows;
    for (var i = 0, l = rows.length; i < l; i++) {
        rows[i].cells[0].firstChild.checked = true;
    }
    sg_vote.hideNum = 0;
    sg_vote.showHideNum();
}

//让球
sg_league.giveBall = function() {
    var rq = fw.dom.getName("rangqiu");
    var rows = sg_league.mtObj.rows, n, isshow;
    var mm = fw.get('showEndBtn').checked;
    var k = 0;
    for (var i = 0, l = rows.length; i < l; i++) {
        if (rows[i].cells.length < 10) continue;
        n = +(rows[i].cells[5].innerHTML.replace(/<.+?>/g, '')); //非0 让球   0非让球

        isshow = rq[0].checked && n != 0 || rq[1].checked && n == 0;
        if (!mm && ((typeof sg_vote.endItem['_' + i]) != 'undefined')) continue;
        with (rows[i].style) {
            isshow ? display != "" && (display = "", (rows[i].getAttribute('isdisable') == 0 ? sg_vote.hideNum-- : void (0))) : display != "none" && (display = "none", (rows[i].getAttribute('isdisable') == 0 ? (sg_vote.hideNum++, sg_vote.cancelSelect(rows[i].getAttribute('index'))) : void (0)));
        }
    }
    trade.Resize();
    sg_vote.showHideNum(1);
}