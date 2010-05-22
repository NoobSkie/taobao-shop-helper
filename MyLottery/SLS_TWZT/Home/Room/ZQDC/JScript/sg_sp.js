var sg_sp = {};

//SP初始化
sg_sp.init = function() {

    sg_sp.spValues = null;
    sg_sp.spFile = "SpValues_" + trade.period + "_" + trade.playid + ".js";

    sg_sp.loadSPvalus();
    
    //按指定时间自动更新SP值.
    window.setInterval(sg_sp.loadSPvalus, 5 * 1 * 1000);

}

//加载SP值文件
sg_sp.loadSPvalus = function() {

    fw.getId("Sp_script") && fw.head.removeChild(fw.getId("Sp_script"));
    fw.append(fw.head, "script", { id: "Sp_script", type: "text/javascript", src: "SPJsFiles/" + sg_sp.spFile + "?version=" + Math.random() });

    setTimeout(sg_sp.updateSp, 1000);
}

//更新SP值
sg_sp.updateSp = function() {
    if (!sg_sp.spValues) return;

    var K = function(A, B) {
        var n = sg_vote.fixNum(A) || '--';
        if (n == '--' || n <= 0) return '<span>--</span>';
        return '<span>' + n + '</span>' + ((A > B) ? '<span style="color:red;font-weight:normal;">↑</span>' : '<span style="color:green;font-weight:normal;">↓</span>');
    }
    var J = function(html, sp, r) {//胜负
        html = html.replace(/<span.*?>.+?<\/span>/ig, '');
        return html + K(sp, r);
    };
    if (sg.mr.length == 25) {//比分
        J = function(html, sp, r) {
            return html.replace(/(.+?)\(.+?\)(.*?)/ig, '$1(' + K(sp, r) + ')$2');
        };
    };
    if (sg.mr.length == 8 || sg.mr.length == 9) {//总进球,半全场数字标红
        J = function(html, sp, r, o) {
        o.style.color = (sp > r) ? 'red' : 'green';
            return html.replace(/<span.*?>.+?<\/span>/ig, '<span>'+sg_vote.fixNum(r)+'</span>');
        }
    }
    if (sg_vote.name == 'ds') {//上下单双
        J = function(html, sp, r) {
            return html.replace(/<span.*?>.+?<\/span>/ig, '') + K(sp, r);
        }
    }
    var step = sg.mr.length == 25 ? 1 : 2;
    var sp, oError = false;
    try {
        fw.array.callEach(sg_vote.data, function(o) {
            var wsp = sg_sp.spValues["w" + o.serialNumber];
            if (!wsp) return;
            for (var c = 0, cols = o.sp.length; c < cols; c++) {
                sp = parseFloat(wsp[c] || 0);
                if (sp != parseFloat(o.sp[c])) {
                    o.obj[c].innerHTML = J(o.obj[c].innerHTML, sp, parseFloat(o.sp[c]), o.obj[c]);
                    o.sp[c] = sp == 0 ? -1 : sp;
                }
            }
        });
    } catch (e) {
        oError = true;
    }
    if (oError) return setTimeout(sg_vote.updateSp, 5000); //更新SP值出错时,自动延时5秒后重试.
    sg_vote.nb.length > 0 && sg_vote.chgRt(true);
}