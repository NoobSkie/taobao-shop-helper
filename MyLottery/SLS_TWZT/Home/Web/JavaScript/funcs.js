function getDownloadUrl(productName) {
			var random = parseInt(Math.random()*100);
			var temp = 0;
	
			for(var i = 0; i < productName.length && random > temp; i++) {
				temp += parseInt(productName[i].percent);
			}
			i = (random == 0 ? 0 : i - 1);

			return "<a href=\"" + productName[i].url + "\">" + productName[i].name + "</a>";
}
function switchTab(identify,index,count) {
	for(i=0;i<count;i++) {
		var CurTabObj = document.getElementById("Tab_"+identify+"_"+i) ;
		var CurListObj = document.getElementById("List_"+identify+"_"+i) ;
		if (i != index) {
			fRemoveClass(CurTabObj , "upH3") ;
			fRemoveClass(CurListObj , "upBox") ;
		}
	}
	fAddClass(document.getElementById("Tab_"+identify+"_"+index),"upH3") ;
	fAddClass(document.getElementById("List_"+identify+"_"+index),"upBox") ;
}

function switchSideTab(identify,index,count) {
	for(i=0;i<count;i++) {
		var CurTabObj = document.getElementById("Tab_"+identify+"_"+i) ;
		var CurListObj = document.getElementById("List_"+identify+"_"+i) ;
		if (i != index) {
			fRemoveClass(CurTabObj , "upH3") ;
			fRemoveClass(CurListObj , "upUL") ;
		}
	}
	fAddClass(document.getElementById("Tab_"+identify+"_"+index),"upH3") ;
	fAddClass(document.getElementById("List_"+identify+"_"+index),"upUL") ;
}

function fAddClass(XEle, XClass)
{/* shawl.qiu code, void return */
  if(!XClass) throw new Error("XClass 不能为空!");
  if(XEle.className!="") 
  {
    var Re = new RegExp("\\b"+XClass+"\\b\\s*", "");
    XEle.className = XEle.className.replace(Re, "");
	var OldClassName = XEle.className.replace(/^\s+|\s+$/g,"") ;
	if (OldClassName == "" ) {
		 XEle.className = XClass;
	}
	else {
		XEle.className = OldClassName + " " + XClass;
	}
   
  }
  else XEle.className = XClass;
}/* end function fAddClass(XEle, XClass) */

function fRemoveClass(XEle, XClass)
{/* shawl.qiu code, void return */
  if(!XClass) throw new Error("XClass 不能为空!");
  var OldClassName = XEle.className.replace(/^\s+|\s+$/g,"") ;
  if(OldClassName!="") 
  {
	
    var Re = new RegExp("\\b"+XClass+"\\b\\s*", "");
    XEle.className = OldClassName.replace(Re, "");
  }
}/* function fRemoveClass(XEle, XClass) */
function switchPic(screen) {
	if (screen > MaxScreen) {
		screen = 1 ;
	}
	
	for (i=1;i<=MaxScreen;i++) {
		document.getElementById("Switch_"+i).style.display = "none" ;
	}
	document.getElementById("Switch_"+screen).style.display = "block" ;
	showSwitchNav(screen);
	showSwitchTitle(screen);
	//Effect.Appear("Switch_"+screen);
			
	//switchLittlePic(screen);
	//showSwitchTitles(screen);
	CurScreen = screen  ;
}
function showSwitchNav(screen) {
	var NavStr = "" ;
	for (i=1;i<=MaxScreen;i++) {
		if (i == screen) {
			NavStr += '<li onmouseover="pauseSwitch();" onmouseout="goonSwitch();"><a href="javascript://" target="_self" class="sel">'+i+'</a></li>' ;
		}
		else {
			NavStr += '<li onmouseover="pauseSwitch();" onmouseout="goonSwitch();" onclick="goManSwitch('+i+');"><a href="javascript://" target="_self">'+i+'</a></li>' ;
		}
		
	}
	document.getElementById("SwitchNav").innerHTML = NavStr ;
}
function showSwitchTitle(screen) {
	var titlestr = "" ;
	titlestr = '<h3><a href="'+Switcher[screen]['link']+'" target="_blank">'+Switcher[screen]['title']+'</a></h3><p><a href="'+Switcher[screen]['link']+'" target="_blank">'+Switcher[screen]['stitle']+'</a></p>' ;
	document.getElementById("SwitchTitle").innerHTML = titlestr ;
}
function reSwitchPic() {
	refreshSwitchTimer = null;
	switchPic(CurScreen+1);
	refreshSwitchTimer = setTimeout('reSwitchPic();', 3000);
}
function pauseSwitch() {
	clearTimeout(refreshSwitchTimer);
}
function goonSwitch() {
	clearTimeout(refreshSwitchTimer);
	refreshSwitchTimer = setTimeout('reSwitchPic();', 3000);
}
function goManSwitch(index) {
	clearTimeout(refreshSwitchTimer);
	
	CurScreen = index - 1 ;
	reSwitchPic();
}
function floatAdMove() {
	try{BigAd = document.getElementById("BigAd")}catch(e){}
	if (BigAd.style.display != "none") {
		if (document.ns) {
			BigAd.style.top=bdy.scrollTop+bdy.clientHeight-imgheight_close -360;
			BigAd.style.left=bdy.offsetWidth/2-bdy.scrollLeft-300;
		}
		else {
			BigAd_style_left=bdy.offsetWidth/2-bdy.scrollLeft-300;
			BigAd_style_top = 200 ;
			BigAd.style.top=BigAd_style_top + "px";
			BigAd.style.left=BigAd_style_left + "px";
		}
	}
	setTimeout("floatAdMove();",50) ;
 }

function FloatCtrlMove() {
	try{FloatCtrl = document.getElementById("FloatCtrl")}catch(e){}
	if (FloatCtrl.style.display != "none") {
		if (document.ns) {
			FloatCtrl.style.top=bdy.scrollTop+bdy.clientHeight-imgheight_close;
			FloatCtrl.style.left=bdy.scrollLeft+bdy.offsetWidth-150;
		}
		else {
			FloatCtrl_style_left=bdy.scrollLeft+bdy.offsetWidth-150;
			FloatCtrl_style_top = 500 ;
			FloatCtrl.style.top=FloatCtrl_style_top + "px";
			FloatCtrl.style.left=FloatCtrl_style_left + "px";
		}
	}
	setTimeout("FloatCtrlMove();",50) ;
}

function showFloatAd() {
	cleanTimer();
	try{floatbig = document.getElementById("floatbig")}catch(e){}
	if (floatbig.innerHTML != "") {
		BigAdStartTimer = setTimeout("Effect.Appear('BigAd');",500);
		BigAdEndTimer = setTimeout("hiddenFloatAd();",6000);
		hiddenFloatCtrl();
	}
}

 function hiddenFloatAd() {
	cleanTimer();
	Effect.Fade('BigAd');
	showFloatCtrl();
 }

 function showFloatCtrl() {
	try {FloatCtrl = getElementById("FloatCtrl")} catch(e){}
	FloatCtrl.style.display = "block" ;
 }
 function hiddenFloatCtrl() {
	try {FloatCtrl = getElementById("FloatCtrl")} catch(e){}
	FloatCtrl.style.display = "none" ;
 }
 function cleanTimer() {
	clearTimeout(BigAdStartTimer) ;
	clearTimeout(BigAdEndTimer);
 }