
function scrollingAD(_id, _width, _height, _bgColor, _direction, _delay, _pauseTime, _size, _isHover) {
    this.id = _id;
    this.width = _width;
    this.height = _height;
    this.bgColor = _bgColor;
    this.direction = _direction;
    this.delay = _delay;
    this.pauseTime = _pauseTime;
    this.size = _size;
    this.object = null;
    this.isMove = true;

    if ((this.id == "") || (this.id == null)) {
        this.isMove = false;
        return false;
    }

    if (document.getElementById(this.id)) {
        this.object = document.getElementById(this.id);
    } else {
        this.isMove = false;
        return false;
    }
}
scrollingAD.prototype.checkNumber = function(_attribute, defaultValue) {
    if (isNaN(_attribute)) {
        return defaultValue;
    } else {
        return ((typeof (parseInt(_attribute)) == "number") ? parseInt(_attribute) : defaultValue);
    }
}
scrollingAD.prototype.move = function() {
    if (this.isMove == false) return false;

    var defaultWidth = 200;
    var defaultHeight = 50;
    var defaultDelay = 50;
    var defaultPauseTime = 2000;
    var defaultIsHover = true;
    var defaultBgColor = "transparent";
    var defaultDirection = "up";

    this.width = this.checkNumber(this.width, defaultWidth);
    this.height = this.checkNumber(this.height, defaultHeight);
    this.delay = this.checkNumber(this.delay, defaultDelay);
    this.pauseTime = this.checkNumber(this.pauseTime, defaultPauseTime);
    this.isHover = (typeof (this.isHover) == "boolean") ? this.isHover : defaultIsHover;

    if (this.direction == "left") {
        this.size = this.checkNumber(this.size, this.width);
    } else {
        this.size = this.checkNumber(this.size, this.height);
    }

    if ((this.bgColor == null) || (typeof (this.bgColor) == undefined)) {
        this.bgColor = defaultBgColor;
    } else {
        this.bgColor = this.bgColor;
    }

    if ((this.direction == null) || (typeof (this.direction) == undefined)) {
        this.direction = defaultDirection;
    } else {
        this.direction = (this.direction.search(/(^up$)|(^left$)/gi) != -1) ? this.direction.toLowerCase() : defaultDirection;
    }

    // 创建滚动区域；
    with (this.object) {
        style.display = "block";
        style.width = this.width + "px";
        style.height = this.height + "px";
        style.overflow = "hidden";
        style.backgroundColor = this.bgColor;
    }

    if (this.direction == "up") {
        this.object.innerHTML = "<div id=\"" + this.id + "_mirror\">" + this.object.innerHTML + "</div>" + "<div>" + this.object.innerHTML + "</div><input type=\"hidden\" value=\"1\" id=\"" + this.id + "_isHover\" />";
    } else {
        this.object.innerHTML = "<span id=\"" + this.id + "_mirror\">" + this.object.innerHTML + "</span>" + "<span>" + this.object.innerHTML + "</span><input type=\"hidden\" value=\"1\" id=\"" + this.id + "_isHover\" />";
    }

    if (document.getElementById(this.id)) {
        var evalString;
        if (this.direction == "up") {
            evalString = "scrollToUp(\"" + this.id + "\", " + this.isHover + ", " + this.delay + ", " + this.size + ", " + this.pauseTime + ", 0) ";
        } else {
            evalString = "scrollToLeft(\"" + this.id + "\", " + this.isHover + ", " + this.delay + ", " + this.size + ", " + this.pauseTime + ", 0) ";
        }
        eval(evalString);

    } else {
        return false;
    }

    function pixelToNum(_string) {
        //该函数用于去掉数值后面的px，并将之转化为数字。
        if (_string.slice(_string.length - 2) == "px") {
            return parseInt(_string.slice(0, (_string.length - 2)));
        } else {
            return _string;
        }
    }

    function scrollToLeft(_id, _isHover, _delay, _size, _pauseTime, _s) {
        var obj = document.getElementById(_id);
        var mirror = document.getElementById(_id + "_mirror");

        if (_size * (1 + parseInt(_s)) + pixelToNum(mirror.style.marginLeft) >= 0) {
            var evalString = _id + "_timer = window.setTimeout(function() {scrollToLeft(\"" + _id + "\", " + _isHover + ", " + _delay + ", " + _size + ", " + _pauseTime + ", " + _s + ");}, " + _delay + ")";

            if (_isHover) {
                mirror.onmouseover = function() { document.getElementById(_id + "_isHover").value = 0; }
                mirror.onmouseout = function() { document.getElementById(_id + "_isHover").value = 1; }
                var step = parseInt(document.getElementById(_id + "_isHover").value);
                mirror.style.marginLeft = (pixelToNum(mirror.style.marginLeft) - step) + "px";
                eval("var " + evalString);
            } else {
                mirror.style.marginLeft = (pixelToNum(mirror.style.marginLeft) - 1) + "px";
                eval("var " + evalString);
            }
        } else {
            if (mirror.offsetWidth + pixelToNum(mirror.style.marginLeft) >= 0) {
                _s += 1;
                window.setTimeout(function() { scrollToLeft(_id, _isHover, _delay, _size, _pauseTime, _s) }, _pauseTime);
            } else {
                mirror.style.marginLeft = mirror.offsetWidth + pixelToNum(mirror.style.marginLeft) + "px"; ;
                window.setTimeout(function() { scrollToLeft(_id, _isHover, _delay, _size, _pauseTime, 0) }, _pauseTime);
            }
        }

    }
    function scrollToUp(_id, _isHover, _delay, _size, _pauseTime, _s) {
        var obj = document.getElementById(_id);
        var mirror = document.getElementById(_id + "_mirror");

        if (_size * (1 + parseInt(_s)) + pixelToNum(mirror.style.marginTop) >= 0) {
            var evalString = _id + "_timer = window.setTimeout(function() {scrollToUp(\"" + _id + "\", " + _isHover + ", " + _delay + ", " + _size + ", " + _pauseTime + ", " + _s + ");}, " + _delay + ")";

            if (_isHover) {
                mirror.onmouseover = function() { document.getElementById(_id + "_isHover").value = 0; }
                mirror.onmouseout = function() { document.getElementById(_id + "_isHover").value = 1; }
                var step = parseInt(document.getElementById(_id + "_isHover").value);
                mirror.style.marginTop = (pixelToNum(mirror.style.marginTop) - step) + "px";
                eval("var " + evalString);
            } else {
                mirror.style.marginTop = (pixelToNum(mirror.style.marginTop) - 1) + "px";
                eval("var " + evalString);
            }
        } else {
            if (mirror.offsetHeight + pixelToNum(mirror.style.marginTop) >= 0) {
                _s += 1;
                window.setTimeout(function() { scrollToUp(_id, _isHover, _delay, _size, _pauseTime, _s) }, _pauseTime);
            } else {
                mirror.style.marginTop = mirror.offsetHeight + pixelToNum(mirror.style.marginTop) + "px"; ;
                window.setTimeout(function() { scrollToUp(_id, _isHover, _delay, _size, _pauseTime, 0) }, _pauseTime);
            }
        }
    }
}


function scrolls(id, dir) {
    this.id = id; // id的对象的id
    this.dir = dir; //方向  "up","down","left","right"
    //this.dec; //方向决定 代表的scrollLeft,scrollTop
    this.h; //子层高度
    this.w; //子层宽度
    var pro;
}
scrolls.prototype = {
    addNodes: function() { //在主层下添加复制元素

        //var p = id;
        var _this = this;
        var c = document.createElement("div"); //子层
        var c1 = document.createElement("div"); //双子层 1
        var c2 = document.createElement("div"); //双子层 2
        var dir = _this.getDirection();

        if (this.dir == "err") {
            alert("方向参数错误!");
            return false;
        }

        //定死外框高度宽度
        _this.$(_this.id).style.height = _this.$(_this.id).offsetHeight + "px";
        _this.$(_this.id).style.width = _this.$(_this.id).offsetWidth + "px";


        c1.innerHTML = _this.$(_this.id).innerHTML; //复制层内的节点
        c2 = c1.cloneNode(true); //双子层2

        _this.$(_this.id).appendChild(c1);
        _this.$(_this.id).appendChild(c2);

        if (dir == "ud")//设置样式
        {
            _this.h = c1.offsetHeight > _this.$(_this.id).offsetHeight ? c1.offsetHeight : _this.$(_this.id).offsetHeight;
            _this.w = _this.$(_this.id).offsetWidth;
            c1.style.cssText = "float:left;width:" + _this.w + "px;height:" + _this.h + "px;"
            c2.style.cssText = c1.style.cssText;
            c.style.cssText = "width:" + c1.offsetWidth + "px;height:" + c1.offsetHeight * 2 + "px;overflow:hidden;margin:0px;padding:0px;border-width:0px;"
        }
        else {
            _this.w = c1.offsetWidth > _this.$(_this.id).offsetWidth ? c1.offsetWidth : _this.$(_this.id).offsetWidth;
            _this.h = _this.$(_this.id).offsetHeight;
            c1.style.cssText = "float:left;width:" + _this.w + "px;height:" + _this.h + "px;"
            c2.style.cssText = c1.style.cssText;
            c.style.cssText = "width:" + (c1.offsetWidth * 2) + "px;height:" + c1.offsetWidth + "px;overflow:auto;margin:0px;padding:0px;border-width:0px;"

        }
        c.appendChild(c1);
        c.appendChild(c2);
        var pc = _this.$(_this.id).childNodes;
        for (var i = 0; i < pc.length; i++) {
            pc[i].removeNode;
            _this.$(_this.id).removeChild(pc[i]);
        }
        _this.$(_this.id).innerHTML = "";
        _this.$(_this.id).appendChild(c);

        _this.maxSize = _this.getDirection() == "lr" ? _this.$(_this.id).getElementsByTagName("div")[0].offsetWidth / 2 : _this.$(_this.id).getElementsByTagName("div")[0].offsetHeight / 2;
        //alert(maxSize);
        _this.dec = _this.getDirection() == "lr" ? _this.$(_this.id).scrollLeft : _this.$(_this.id).scrollTop;

        //alert(_this.$(id).scrollWidth);
        //_this.$(id).scrollTop =20;

    },


    scrollPro: function() {
        var _this = this;
        //alert(_this.dir)
        switch (_this.dir) {
            case "up": _this.pro = setInterval(function() { _this.scrollUp() }, 1); break;
            case "down": _this.pro = setInterval(function() { _this.scrollDown() }, 1); break;
            case "left": _this.pro = setInterval(function() { _this.scrollLeft() }, 1); break;
            case "right": _this.pro = setInterval(function() { _this.scrollRight() }, 1); break;
        }
        _this.$(_this.id).onmouseover = function() { clearTimeout(_this.pro) };
        _this.$(_this.id).onmouseout = function() {
            switch (_this.dir) {
                case "up": _this.pro = setInterval(function() { _this.scrollUp() }, 1); break;
                case "down": _this.pro = setInterval(function() { _this.scrollDown() }, 1); break;
                case "left": _this.pro = setInterval(function() { _this.scrollLeft() }, 1); break;
                case "right": _this.pro = setInterval(function() { _this.scrollRight() }, 1); break;
            }
        }
    },

    scrollUp: function() {

        var _this = this;
        //alert(_this.$(_this.id).scrollTop);
        //alert(_this.maxSize);
        if (_this.$(this.id).scrollTop < _this.maxSize) {
            _this.$(this.id).scrollTop++;
        }
        else {
            _this.$(this.id).scrollTop = 0;
        }

    },

    scrollDown: function() {

        var _this = this;
        //alert(_this.$(_this.id).scrollTop);
        //alert(_this.maxSize);
        if (_this.$(this.id).scrollTop <= 0) {
            _this.$(this.id).scrollTop = _this.maxSize;
        }
        else {
            _this.$(this.id).scrollTop--;
        }

    },

    scrollRight: function() {

        var _this = this;
        //alert(_this.$(_this.id).scrollTop);
        //alert(_this.maxSize);
        if (_this.$(this.id).scrollLeft <= 0) {
            _this.$(this.id).scrollLeft = _this.maxSize;
        }
        else {
            _this.$(this.id).scrollLeft--;
        }

    },
    scrollLeft: function() {

        var _this = this;
        if (_this.$(this.id).scrollLeft < _this.maxSize) {
            _this.$(this.id).scrollLeft++;
        }
        else {
            _this.$(this.id).scrollLeft = 0;
        }

    },

    $: function(o) { //获取对象
        if (typeof (o) == "string") {
            if (document.getElementById(o)) {
                return document.getElementById(o);
            }
            else {
                alert("err" + "\"o" + "\"");
                return false;
            }
        }
        else {
            return o;
        }
    },


    getDirection: function() { //获取方向
        switch (this.dir) {
            case "up": return "ud"; break;
            case "down": return "ud"; break;
            case "left": return "lr"; break;
            case "right": return "lr"; break;
            default: return "err";
        }
    }
}
