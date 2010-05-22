
function scrollingAD(_id, _width, _height, _bgColor, _direction, _delay, _pauseTime, _size, _isHover) {
	this.id              = _id;
	this.width           = _width;
	this.height          = _height;
	this.bgColor         = _bgColor;
	this.direction       = _direction;
	this.delay           = _delay;
	this.pauseTime       = _pauseTime;
	this.size            = _size;
	this.object          = null;
	this.isMove          = true;
	
	if((this.id == "") || (this.id == null)) {
		this.isMove = false;
		return false;
	}
	
	if(document.getElementById(this.id)) {
		this.object = document.getElementById(this.id);
	} else {
		this.isMove = false;
		return false;
	}
}
scrollingAD.prototype.checkNumber = function(_attribute, defaultValue) {	
	if(isNaN(_attribute)) {
		return defaultValue;
	} else {
		return ((typeof(parseInt(_attribute)) == "number") ? parseInt(_attribute) : defaultValue);
	}
}
scrollingAD.prototype.move = function() {
	if(this.isMove == false) return false;
	
	var defaultWidth           = 200;
	var defaultHeight          = 50;
	var defaultDelay           = 20;
	var defaultPauseTime       = 2000;
	var defaultIsHover         = true;
	var defaultBgColor         = "transparent";
	var defaultDirection       = "up";
	
	this.width          = this.checkNumber(this.width, defaultWidth);
	this.height         = this.checkNumber(this.height, defaultHeight);
	this.delay          = this.checkNumber(this.delay, defaultDelay);
	this.pauseTime      = this.checkNumber(this.pauseTime, defaultPauseTime);
	this.isHover        = (typeof(this.isHover) == "boolean") ? this.isHover : defaultIsHover;
	
	if(this.direction == "left") {
		this.size       = this.checkNumber(this.size, this.width);
	} else {
		this.size       = this.checkNumber(this.size, this.height);
	}
	
	if((this.bgColor == null) || (typeof(this.bgColor) == undefined)) {
		this.bgColor = defaultBgColor;
	} else {
		this.bgColor = this.bgColor;
	}
	
	if((this.direction == null) || (typeof(this.direction) == undefined)) {
		this.direction = defaultDirection;	
	} else {
		this.direction = (this.direction.search(/(^up$)|(^left$)/gi) != -1) ? this.direction.toLowerCase() : defaultDirection;
	}
	
	// 创建滚动区域；
	with(this.object) {
		style.display         = "block";
		style.width           = this.width + "px";
		style.height          = this.height + "px";
		style.overflow        = "hidden";
		style.backgroundColor = this.bgColor;
	}
	
	if(this.direction == "up") {
		this.object.innerHTML = "<div id=\"" + this.id + "_mirror\">" + this.object.innerHTML + "</div>" + "<div>" + this.object.innerHTML + "</div><input type=\"hidden\" value=\"1\" id=\"" + this.id + "_isHover\" />";
	} else {
		this.object.innerHTML = "<span id=\"" + this.id + "_mirror\">" + this.object.innerHTML + "</span>" + "<span>" + this.object.innerHTML + "</span><input type=\"hidden\" value=\"1\" id=\"" + this.id + "_isHover\" />";
	}
		
	if(document.getElementById(this.id)) {
		var evalString;
		if(this.direction == "up") {
			evalString = "scrollToUp(\"" + this.id + "\", " + this.isHover + ", " + this.delay + ", " + this.size + ", " + this.pauseTime + ", 0) ";
		} else {
			evalString = "scrollToLeft(\"" + this.id + "\", " + this.isHover + ", " + this.delay + ", " + this.size + ", " + this.pauseTime + ", 0) ";
		}
		eval(evalString);
		
	} else {
		return false;
	}
	
	function pixelToNum(_string)	{
	//该函数用于去掉数值后面的px，并将之转化为数字。
		if(_string.slice(_string.length - 2) == "px") {
			return parseInt(_string.slice(0, (_string.length - 2)));
		} else  {
			return _string;
		}
	}
	
	function scrollToLeft(_id, _isHover, _delay, _size, _pauseTime, _s) {
		var obj = document.getElementById(_id);
		var mirror = document.getElementById(_id + "_mirror");	
		
		if(_size*(1 + parseInt(_s)) + pixelToNum(mirror.style.marginLeft) >= 0) {
			var evalString =_id + "_timer = window.setTimeout(function() {scrollToLeft(\"" + _id + "\", " + _isHover + ", " + _delay + ", " + _size + ", " + _pauseTime + ", " + _s + ");}, " + _delay + ")";
		
			if(_isHover) {
				mirror.onmouseover = function() {document.getElementById(_id + "_isHover").value = 0;}
				mirror.onmouseout  = function() {document.getElementById(_id + "_isHover").value = 1;}
				var step = parseInt(document.getElementById(_id + "_isHover").value);
				mirror.style.marginLeft = (pixelToNum(mirror.style.marginLeft) - step) + "px";	
				eval("var " + evalString);
			} else {				
				mirror.style.marginLeft = (pixelToNum(mirror.style.marginLeft) - 1) + "px";	
				eval("var " + evalString);
			}
		} else {
			if(mirror.offsetWidth + pixelToNum(mirror.style.marginLeft) >= 0) {
				_s += 1;
				window.setTimeout(function() {scrollToLeft(_id, _isHover, _delay, _size, _pauseTime, _s)}, _pauseTime);
			} else {
				mirror.style.marginLeft = mirror.offsetWidth + pixelToNum(mirror.style.marginLeft) + "px";;
				window.setTimeout(function() {scrollToLeft(_id, _isHover, _delay, _size, _pauseTime, 0)}, _pauseTime);
			}
		}
		
	}
	function scrollToUp(_id, _isHover, _delay, _size, _pauseTime, _s) {
		var obj = document.getElementById(_id);
		var mirror = document.getElementById(_id + "_mirror");	
		
		if(_size*(1 + parseInt(_s)) + pixelToNum(mirror.style.marginTop) >= 0) {
			var evalString =_id + "_timer = window.setTimeout(function() {scrollToUp(\"" + _id + "\", " + _isHover + ", " + _delay + ", " + _size + ", " + _pauseTime + ", " + _s + ");}, " + _delay + ")";
		
			if(_isHover) {
				mirror.onmouseover = function() {document.getElementById(_id + "_isHover").value = 0;}
				mirror.onmouseout  = function() {document.getElementById(_id + "_isHover").value = 1;}
				var step = parseInt(document.getElementById(_id + "_isHover").value);
				mirror.style.marginTop = (pixelToNum(mirror.style.marginTop) - step) + "px";	
				eval("var " + evalString);
			} else {				
				mirror.style.marginTop = (pixelToNum(mirror.style.marginTop) - 1) + "px";	
				eval("var " + evalString);
			}
		} else {
			if(mirror.offsetHeight + pixelToNum(mirror.style.marginTop) >= 0) {
				_s += 1;
				window.setTimeout(function() {scrollToUp(_id, _isHover, _delay, _size, _pauseTime, _s)}, _pauseTime);
			} else {
				mirror.style.marginTop = mirror.offsetHeight + pixelToNum(mirror.style.marginTop) + "px";;
				window.setTimeout(function() {scrollToUp(_id, _isHover, _delay, _size, _pauseTime, 0)}, _pauseTime);
			}
		}
	}
}

