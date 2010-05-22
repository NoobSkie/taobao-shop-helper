
// onmousedown=""MyMove.Move('divID',event,0或者1)"" 
// id 要移动的层ID 
// Evt 是 event, window.event; 要在FF 中可以用    e ? e :window.event;
// T 为 int 有数字1是拖动 0是慢慢移动



//通用 移动 Div 类
//请保留一下我的信息,谢谢
//Edit By Skybot
//QQ:35287352
function Tong_MoveDiv() {
    //参数说明
    // id 要移动的层ID 
    // Evt 是 event, window.event; 要在FF 中可以用    e ? e :window.event;
    // T 为 int 有数字是拖动 没有是慢慢移动
    this.Move = function(Id, Evt, T) {
        if (Id == "") return;
        var o = document.getElementById(Id);
        if (!o) return; //如果这个东东不在
        evt = Evt ? Evt : window.event;
        var obj = evt.srcElement ? evt.srcElement : evt.target; //得到个原素 使它在FF中也可以用
        //得到当前对要移动对象的 坐标
        var w = o.offsetWidth;
        var h = o.offsetHeight;
        var l = o.offsetLeft;
        var t = o.offsetTop;
        var div = document.createElement("DIV"); //新原素DIV
        document.body.appendChild(div);
        div.style.cssText = "filter:alpha(Opacity=10,style=0);opacity:0.2;width:" + w + "px;height:" + h + "px;top:" + t + "px;left:" + l + "px;position:absolute;background:#000"; //设定 filter； 注意opacity 是FF中的 Opacity
        div.setAttribute("id", Id + "temp");

        //拖动
        this.Move_OnlyMove(Id, evt, T);
    }

    //移动函数
    //参数 Id 要移动的层ID 
    //Evt 是 event, window.event; 要在FF 中可以用    e ? e :window.event;
    this.Move_OnlyMove = function(Id, Evt, T) {
        var o = document.getElementById(Id + "temp");
        if (!o) return;
        evt = Evt ? Evt : window.event; //都是FF 才要这么写的
        var relLeft = evt.clientX - o.offsetLeft; //得到左边的 宽度
        var relTop = evt.clientY - o.offsetTop; //得到上边的 宽度
        //抓取 事件
        if (!window.captureEvents) {
            o.setCapture(); //指定 抓取 事件

        }
        else {
            window.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP);
        }

        //文档的 onmousemove 事件
        document.onmousemove = function(e) {
            if (!o) return;
            e = e ? e : window.event;
            if (e.clientX - relLeft <= 0)
            { o.style.left = 230 + "px"; }
            else if (e.clientX - relLeft >= document.documentElement.clientWidth - o.offsetWidth - 2)
                o.style.left = (document.documentElement.clientWidth - o.offsetWidth - 2+220) + "px";
            else
                o.style.left = e.clientX - relLeft+220+ "px";
            if (e.clientY - relTop <= 1)
                o.style.top = 1+"px";
            else if (e.clientY - relTop >= document.documentElement.scrollHeight - o.offsetHeight - 30)
                o.style.top = (document.documentElement.scrollHeight - o.offsetHeight - 30) + "px";
            else
                o.style.top = e.clientY - relTop+ "px";
        }

        //文档的 onmouseup 事件
        document.onmouseup = function() {
            if (!o) return;
            if (!window.captureEvents)
                o.releaseCapture();
            else
                window.releaseEvents(Event.MOUSEMOVE | Event.MOUSEUP);
            var o1 = document.getElementById(Id);
            if (!o1) return;
            var l0 = o.offsetLeft;
            var t0 = o.offsetTop;
            var l = o1.offsetLeft;
            var t = o1.offsetTop;
            MyMove.Move_e(Id, l0, t0, l, t, T);
            document.body.removeChild(o);
            o = null;
        }
    }

    this.Move_e = function(Id, l0, t0, l, t, T) {
        if (typeof (window["ct" + Id]) != "undefined") clearTimeout(window["ct" + Id]);
        var o = document.getElementById(Id);
        if (!o) return;
        var sl = st = 8;
        var s_l = Math.abs(l0 - l);
        var s_t = Math.abs(t0 - t);
        if (s_l - s_t > 0)
            if (s_t)
            sl = Math.round(s_l / s_t) > 8 ? 8 : Math.round(s_l / s_t) * 6;
        else
            sl = 0;
        else
            if (s_l)
            st = Math.round(s_t / s_l) > 8 ? 8 : Math.round(s_t / s_l) * 6;
        else
            st = 0;
        if (l0 - l < 0) sl *= -1;
        if (t0 - t < 0) st *= -1;
        if (Math.abs(l + sl - l0) < 52 && sl) sl = sl > 0 ? 2 : -2;
        if (Math.abs(t + st - t0) < 52 && st) st = st > 0 ? 2 : -2;
        if (Math.abs(l + sl - l0) < 16 && sl) sl = sl > 0 ? 1 : -1;
        if (Math.abs(t + st - t0) < 16 && st) st = st > 0 ? 1 : -1;
        if (s_l == 0 && s_t == 0) return;
        if (T) {
            o.style.left = l0 + "px";
            o.style.top = t0 + "px";
            return;
        }
        else {
            if (Math.abs(l + sl - l0) < 2)
                o.style.left = l0 + "px";
            else
                o.style.left = l + sl + "px";
            if (Math.abs(t + st - t0) < 2)
                o.style.top = t0 + "px";
            else
                o.style.top = t + st + "px";
            window["ct" + Id] = window.setTimeout("MyMove.Move_e('" + Id + "', " + l0 + " , " + t0 + ", " + (l + sl) + ", " + (t + st) + "," + T + ")", 1);
        }
    }


}
var MyMove = new Tong_MoveDiv();