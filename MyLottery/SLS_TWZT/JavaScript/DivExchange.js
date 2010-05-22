function BrowserType() {
    this.ver = navigator.appVersion;
    this.agent = navigator.userAgent;
    this.dom = document.getElementById ? 1 : 0;
    this.opera5 = this.agent.indexOf("Opera 5") > -1;
    this.ie5 = (this.ver.indexOf("MSIE 5") > -1 && this.dom && !this.opera5) ? 1 : 0;
    this.ie6 = (this.ver.indexOf("MSIE 6") > -1 && this.dom && !this.opera5) ? 1 : 0;
    this.ie4 = (document.all && !this.dom && !this.opera5) ? 1 : 0;
    this.ie = this.ie4 || this.ie5 || this.ie6
    this.mac = this.agent.indexOf("Mac") > -1
    this.ns6 = (this.dom && parseInt(this.ver) >= 5) ? 1 : 0;
    this.ns4 = (document.layers && !this.dom) ? 1 : 0;
    this.bwt = (this.ie6 || this.ie5 || this.ie4 || this.ns4 || this.ns6 || this.opera5)

    return this;
}

function ExchangeDiv(ObjPrefix, Num, NumCount) {

    for (var i = 1; i <= parseInt(NumCount); i++) {
        var TmpObjself = eval(ObjPrefix + i);
        var TmpObj = eval(ObjPrefix + i + "_1");
        if (i == Num.toString()) {
            TmpObjself.className = "OpenWinIndex";
            TmpObj.style.display = '';
        }
        else {
            TmpObjself.className = "OpenWinOther";
            TmpObj.style.display = 'none';
        }
    }
}

function ExchangeDiv(ObjPrefix, Num, NumCount, SelectStyle, OtherStyle)
{
	for(var i = 1; i <= parseInt(NumCount); i++)
	{
	    var TmpObjself = document.getElementById(ObjPrefix + i);
	    var TmpObj = document.getElementById(ObjPrefix + i + "_1");
		if(i == Num.toString())
		{
		   TmpObjself.className = SelectStyle;
		   TmpObj.style.display='';
		}
		else
		{
		   TmpObjself.className = OtherStyle;
		   TmpObj.style.display='none';
		}
	}
}

function ExchangeDivChange(ObjPrefix, Num, NumCount, SelectStyle, OtherStyle)
{
    var o_cb_All = document.getElementById("cb_All");
    o_cb_All.checked =false;
    
	for(var i = 1; i <= parseInt(NumCount); i++)
	{
	    var TmpObjself = document.getElementById(ObjPrefix + i);
	    var TmpObj = document.getElementById(ObjPrefix + i + "_1");
		if(i == Num.toString())
		{
		   TmpObjself.className = SelectStyle;
		   TmpObj.style.display='';
		}
		else
		{
		   TmpObjself.className = OtherStyle;
		   TmpObj.style.display='none';
		}
	}
}

function ExchangeTr(ObjPrefix, Num, NumCount, SelectStyle, OtherStyle)
{
    var o_MoreInvest = document.getElementById("MoreInvest");
    
	for(var i = 1; i <= parseInt(NumCount); i++)
	{
	    var TmpObjself = document.getElementById(ObjPrefix + i);
	    var TmpObj = document.getElementById(ObjPrefix + i + "_1");
	    
	    if (i == Num.toString()) 
	    {
		   TmpObjself.className = SelectStyle;
		   TmpObj.style.display = '';
		}
		else
		{
		   TmpObjself.className = OtherStyle;
		   TmpObj.style.display='none';
		}
    }

	if(Num.toString() == "1")
	{
	   o_MoreInvest.href="../../../Home/Room/MyIcaile.aspx?Subpage=Invest.aspx";
	   
	    return;
	}

    if(Num.toString() == "2")
	{
	    o_MoreInvest.href="../../../Home/Room/MyIcaile.aspx?Subpage=ViewChase.aspx";
	   
	    return;
	}
	
	if(Num.toString() == "3")
	{
	    o_MoreInvest.href="../../../Home/Room/MyIcaile.aspx?Subpage=Welcome.aspx";
	    
	    return;
	}

	if (Num.toString() == "4") {
	    window.frames["IframeAgreement_Iframe"].location.href = "../../../Html/Helps/Regulations/SHSSL.html";
	}
}

function makeObj(obj, nest) {
    var bwt = new BrowserType();

    nest = (!nest) ? "" : 'document.' + nest + '.';
    this.el = bwt.dom ? document.getElementById(obj) : bwt.ie4 ? document.all[obj] : bwt.ns4 ? eval(nest + 'document.' + obj) : 0;
    this.style = bwt.dom ? document.getElementById(obj).style : bwt.ie4 ? document.all[obj].style : bwt.ns4 ? eval(nest + 'document.' + obj) : 0;
    this.scrollHeight = bwt.ns4 ? this.style.document.height : this.el.offsetHeight;
    this.clipHeight = bwt.ns4 ? this.style.clip.height : this.el.offsetHeight;

    this.x = 0; this.y = 0;
    this.obj = obj + "Object";
    eval(this.obj + "=this")
    return this
}

function ExchangeDivMenu(ObjPrefix, Num, NumCount) {
    for (var i = 1; i <= parseInt(NumCount); i++) {
        var TmpObjself = eval(ObjPrefix + i);
        var TmpObj = eval(ObjPrefix + i + "_1");
        if (i == Num.toString()) {
            TmpObjself.className = "NewsListIndex";
            TmpObj.style.display = '';
        }
        else {
            TmpObjself.className = "NewsListOther";
            TmpObj.style.display = 'none';
        }
    }
}

function ExchangeDivMenu1(ObjPrefix, Num, NumCount) {
    for (var i = 1; i <= parseInt(NumCount); i++) {
        var TmpObjself = eval(ObjPrefix + i);
        var TmpObj = eval(ObjPrefix + i + "_1");
        if (i == Num.toString()) {
            TmpObjself.className = "ExpertsCommendsIndex";
            TmpObj.style.display = '';
        }
        else {
            TmpObjself.className = "ExpertsCommendsOther";
            TmpObj.style.display = 'none';
        }
    }
}

function ExchangeDivMenu2(ObjPrefix, Num, NumCount) {
    for (var i = 1; i <= parseInt(NumCount); i++) {
        var TmpObjself = eval(ObjPrefix + i);
        var TmpObj = eval(ObjPrefix + i + "_1");
        if (i == Num.toString()) {
            TmpObjself.className = "RoomWelcome";
            TmpObj.style.display = '';
        }
        else {
            TmpObjself.className = "RoomWelcomeOther";
            TmpObj.style.display = 'none';
        }
    }
}

function ExchangeDivMenu3(ObjPrefix, Num, NumCount) {
    for (var i = 1; i <= parseInt(NumCount); i++) {
        var TmpObjself = eval(ObjPrefix + i);
        var TmpObj = eval(ObjPrefix + i + "_1");

        var Url = parent.window.frames["mainFrame"].location.href.split("/");
        thisHPage = Url[Url.length - 1];

        if (thisHPage != "Welcome.aspx") {
            if ((i == Num.toString()) && (TmpObj.style.display == '')) {
                if (i == 1) {
                    document.getElementById("aMenu1").href = document.getElementById("aMenu2").href;
                }
                else {
                    document.getElementById("aMenu" + i.toString()).href = document.getElementById("aMenu" + (i - 1).toString()).href;
                }
            }
            else if ((i == Num.toString()) && (TmpObj.style.display != '')) {
                document.getElementById("aMenu" + i.toString()).href = "Welcome.aspx";
                document.getElementById("aMenu" + i.toString()).target = "mainFrame";
            }
        }

        if (i == Num.toString()) {
            TmpObjself.className = ObjPrefix + "Index";
            TmpObj.style.display = '';
        }
        else {
            TmpObjself.className = ObjPrefix + "Other";
            TmpObj.style.display = 'none';
        }
    }
}