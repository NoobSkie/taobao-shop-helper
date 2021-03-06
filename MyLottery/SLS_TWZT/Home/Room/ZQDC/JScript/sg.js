var sg = {};

//初始化
sg.init = function() {
    sg.setX();
    sg.mr = ({						//mr=mathResult
        "4501": ["胜", "平", "负"],
        "4503": ["上+单", "上+双", "下+单", "下+双"],
        "4502": ["0", "1", "2", "3", "4", "5", "6", "7+"],
        "4505": ["胜-胜", "胜-平", "胜-负", "平-胜", "平-平", "平-负", "负-胜", "负-平", "负-负"],
        "4504": ["1:0", "2:0", "2:1", "3:0", "3:1", "3:2", "4:0", "4:1", "4:2", "胜其他", "0:0", "1:1", "2:2", "3:3", "平其他", "0:1", "0:2", "1:2", "0:3", "1:3", "2:3", "0:4", "1:4", "2:4", "负其他"]
    })[trade.playid];

    sg.idx2mr = function(n) { return sg.mr[n] };
    sg.mr2idx = {};


    fw.callEach(sg.mr, function(s, i) { sg.mr2idx[s] = i });

    window.sg_league && sg_league.init(); 		    //赛事初始化
    window.sg_vote && sg_vote.init(); 			    //投注初始化
    window.sg_bonus && sg_bonus.init(); 			//奖金评测初始化

}
window.init = sg.init;

//设置串
sg.setX = function() {
    sg.ggm2num = { "单关": [1] };
    sg.type2nm = { "单关": { n: 1, m: 1} };
    sg.num2ggm = { "1": "单关" };
    var a = [["单关"]], n, m, s, t;
    for (var i = 1; i < 15; i++) {
        a[i] = [], n = i + 1, m = 0, t = [];
        sg.num2ggm[n] = n + "串1";
        for (var j = i + 1; j > (i < 6 ? 0 : i); j--) {
            m += fw.math.C(n, j);
            s = n + "串" + m;
            a[i].push(s);
            sg.ggm2num[s] = t.concat(j);
            t = t.concat(j);
            sg.type2nm[s] = { n: n, m: m };
        }
    }
    sg.collection = a;
}

//计算串
sg.C = function(a, num) {

    if (typeof (a[0]) == "number") a = fw.array.getNum(a);
    if (typeof (num) == "number") num = [num];
    var r = 0;
    var n = a.length;

    var ff = function(n, i) { return Math.pow(a[i][0], n) * fw.math.C(a[i][1], n) };
    (function f(t, i) {
        if (i == n) {
            if (fw.array.getIdx(num, fw.array.add(t)) > -1) r += fw.array.multiple(fw.each(t, ff, []));
            return;
        }
        for (var j = 0; j <= a[i][1]; j++) f(t.concat(j), i + 1);
    })([], 0);
    return r;
}

//反向分析
sg.parse = function(codeStr, danStr) {
    if (codeStr == "") return [];
    var d = danStr.split("/"), a, rt;
    return fw.each(codeStr.split("/"), function(txt) {
        a = txt.split(":[");
        rt = a[1].slice(0, -1).split(",")
        return { row: a[0], dan: fw.array.getIdx(d, txt) > -1, rt: rt, rtx: fw.each(rt, function(s) { return sg.mr2idx[s] }, []) };
    });
}


