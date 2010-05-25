function floatbig_openURL(url) {
	window.open(url);
	if(false){
		try{
			top.fn_banner_click();
		}catch(e){}
	}
}

function floatbig_sendInfo() {
	var d = new Date();
	var divId = "floatbig";
	var div = document.getElementById(divId);
	if (!div || div.style.display == "none")
		return;
	if(d.getMinutes() == 1 && d.getSeconds() < 10)
		return;
	
	// zero means don't send randomly
	var isRandom = 20;
	if (Math.floor(Math.random() * isRandom) == 0) {
		var img = document.createElement("img");	
		img.src = getUrlWithPID("http://mediapv.sandai.net/commstat/banner_stat?itemid=1&domain=" + encodeURI(window.location.host) + "&position=1331&ramdon="+Math.random());
	}
}

if (typeof(peerID) == "undefined" || peerID == null) {
	peerID = null;
	try {
		peeridobj = new ActiveXObject("MediaAddin.MediaComm");
		if (peeridobj != null)
			peerID = "xlpeeruuid=" + peeridobj.peerid;
	} catch(e) {
	 peerID = null;
	}
}
if(false && (typeof(peerID)=="undefined"||peerID==null)) {
	peerID=null;
	try{
		thunder_server=new ActiveXObject("ThunderServer.WebThunder.1");
		if(thunder_server!=null){
			peerID="xlpeeruuid="+thunder_server.GetVariable("PEERID");
		}
	}catch(e) {
		peerID=null;
	}
}

if (typeof(window.getUrlWithPID) == "undefined") {
	eval(
		  "function getUrlWithPID(fullurl, split) {"
		+ "	if(peerID == null || fullurl == null) "
		+ "		return fullurl;"
		+ "	var index = fullurl.indexOf('?'); "
		+ "	if(index < 0) return fullurl;"
		+ "	if (index == fullurl.length - 1) "
		+ "		return  fullurl + peerID;"
		+ "	if (split == null) {"
		+ "		split = '&';"
		+ "		var search = fullurl.indexOf('&amp;');"
		+ "		if (search > index) {"
		+ "			split = '&amp;';"
		+ "		} else {"
		+ "			search = fullurl.indexOf('%26');"
		+ "			if (search > index)"
		+ "				split = '%26';"
		+ "		}"
		+ "	}"
		+ "	return fullurl.substring(0, index + 1) + peerID + split + fullurl.substring(index + 1);"
		+ "}"
	);
}

if (true)
	setTimeout("floatbig_sendInfo()", 10);
    if(document.getElementById('floatbig')) { 
    var str = ""; 

 str += "<div style='position:relative;width:600;height:250;display:block' id='div_174229_1331_0'> ";
 str += "<img src='images/ad_index_gg.jpg' style='border:0px;'></div>";
 document.getElementById('floatbig').innerHTML = str;

   }

