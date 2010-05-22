function displayGender(gender)
{
	var gendername = '女';
	gender = parseInt(gender);
	switch (gender)
	{
		case 0:
			gendername = '保密';
			break;
		case 1:
			gendername = '男';
			break;
		case 2:
			gendername = '女';
			break;
	}
	return gendername;
}
function replyToFloor(floor,poster, postid)
{
	if ($('title'))
	{
		$('postform').postid.value = postid;
		$('title').value = '回复 ' + floor + '# ' + poster + ' 的帖子';
		//$('message').focus();
		var oFCKeditor = FCKeditorAPI.GetInstance('message');
		oFCKeditor.Focus();
	}
}

function nospace(username)
{
	alert('抱歉, 用户 ' + username + ' 尚未开通个人空间');
}
function validate(theform, previewpost, switcheditormode) {
	var message = !theform.parseurloff.checked ? parseurl(theform.message.value) : theform.message.value;

	if (message == "") {
		alert("请完成标题或内容栏。");
		theform.message.focus();
		try{$("postsubmit").disabled = false;}catch(e){}
		return false;
	} else if (theform.title.value.length > 60) {
		alert("您的标题超过 60 个字符的限制。");
		theform.title.focus();
		try{$("postsubmit").disabled = false;}catch(e){}
		return false;
	}

	if ($('debateopinion') && $('debateopinion').value == 0)
	{
		alert('请选择您在辩论中的观点');
		return false;
	}

	if(!disablepostctrl && ((postminchars != 0 && mb_strlen(message) < postminchars) || (postmaxchars != 0 && mb_strlen(message) > postmaxchars))) {
		alert("您的帖子长度不符合要求。\n\n当前长度: " + mb_strlen(message) + " 字节\n系统限制: " + postminchars + " 到 " + postmaxchars + " 字节");
		return false;
	}

	if (!switcheditormode && !previewpost) {
		try{$("postsubmit").disabled = true;}catch(e){}
	}

	theform.message.value = message;
	return true;
}

function ShowStars(n, t) {
	var s = '';
	for(var i=3; i>0; i--) {
		level = parseInt(n / Math.pow(t, i-1));
		n = n % Math.pow(t, i-1);
		for(var j=0; j<level; j++) {
			s += '<img src="templates/' + templatepath + '/images/star_level'+i+'.gif" />';
		}
	}
	document.write(s);
}

function copycode(obj) {

	if(is_ie && obj.style.display != 'none') {

		var rng = document.body.createTextRange();

		rng.moveToElementText(obj);

		rng.scrollIntoView();

		rng.select();

		rng.execCommand("Copy");

		rng.collapse(false);
	}
}

function signature(obj) {
	if(obj.style.maxHeightIE != '') {
		var height = (obj.scrollHeight > parseInt(obj.style.maxHeightIE)) ? obj.style.maxHeightIE : obj.scrollHeight;
		if(obj.innerHTML.indexOf('<IMG ') == -1) {
			obj.style.maxHeightIE = '';
		}
		return height;
	}
}

function imgzoom(o)
{
	if(event.ctrlKey)
	{
		var zoom = parseInt(o.style.zoom, 10) || 100;
		zoom -= event.wheelDelta / 12;
		if(zoom > 0)
		{
			o.style.zoom = zoom + '%';
		}
		return false;
	}
	else
	{
		return true;
	}
}
 
function printinpostad(index){
	try{
		if (inpostad){
				document.write("<div class=\"line category\"><div style='float: left;'>[广告]&nbsp;</div><div style='text-align:left;'>");
				var tempstr = inpostad[index];
				var ad = tempstr.split("\\r\\n");
				for (var i = 0; i < ad.length; i++)
				{
					document.writeln(ad[i]);
				}
				document.write("</div>");
				document.write("</div>");
			}
		}
	catch(e){
	}
}

function showrate(pid,aspxrewrite)
{
	var rr = $("rate_" + pid + "_real");
	var rf = $("rate_" + pid + "_fake");
	
	if (rr.style.display == "none")
	{
		rr.style.display = "";
		rf.style.display = "none";
	}
	else
	{
		rr.style.display = "none";
		rf.style.display = "";
	}

	var ratediv = $("rate_" + pid);
	if (ratediv.innerHTML == "")
	{
		ratediv.innerHTML = "请稍侯..."
		var action = "tools/ajax.aspx?t=ratelist";



		var oXmlHttp = createXMLHttp();
		oXmlHttp.open("post", action, true);
		oXmlHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		oXmlHttp.onreadystatechange = function () {
			if (oXmlHttp.readyState == 4) {
				if (oXmlHttp.status == 200) {
					outputRatelog(oXmlHttp.responseXML, pid, aspxrewrite);
					//bind current post;
				} else {
					alert("An error occurred: " + oXmlHttp.statusText);
				}
			}
		};
		oXmlHttp.send("pid=" + pid);


		//ratediv.appendChild(form);

	}


}

function outputRatelog(doc, pid, aspxrewrite)
{
	var err = doc.getElementsByTagName('error');
	if (err[0] != null && err[0] != undefined)
	{
		if (err[0].childNodes.length > 1) {
		    alert(err[0].childNodes[1].nodeValue);
		} else {
		    alert(err[0].firstChild.nodeValue);    		
		}
		return;
	}

	var ratediv = $("rate_" + pid);
    /*
	var html = "<table border='0' cellpadding='0' cellspacing='0' width='95%'>";
	var ratelist = doc.getElementsByTagName('ratelog');
	for (var i = 0; i < ratelist.length; i++ )
	{
		var uid = getSpecificNodeValue(doc, "uid", i);
		var username = getSpecificNodeValue(doc, "username", i);
		var extcreditsname = getSpecificNodeValue(doc, "extcreditsname", i);
		var extcreditsunit = getSpecificNodeValue(doc, "extcreditsunit", i);
		var postdatetime = getSpecificNodeValue(doc, "postdatetime", i);
		var score = getSpecificNodeValue(doc, "score", i);
		var reason = getSpecificNodeValue(doc, "reason", i);

        if(aspxrewrite == 1)
        {
		    html += "<tr><td><a target='_blank' href='userinfo-" + uid + ".aspx'>" + username + "</a></td><td>&nbsp;&nbsp;" + postdatetime + "</td><td>&nbsp;&nbsp;" + extcreditsname + "&nbsp;&nbsp;<b>" + score + "</b>&nbsp;" + extcreditsunit + "</td><td>&nbsp;&nbsp;" + reason + "</td></tr>";
		}
		else
		{
		    html += "<tr><td><a target='_blank' href='userinfo.aspx?userid=" + uid + "'>" + username + "</a></td><td>&nbsp;&nbsp;" + postdatetime + "</td><td>&nbsp;&nbsp;" + extcreditsname + "&nbsp;&nbsp;<b>" + score + "</b>&nbsp;" + extcreditsunit + "</td><td>&nbsp;&nbsp;" + reason + "</td></tr>";
		}
	}
	html += "</table>";*/


	var html = "";
	var ratelist = doc.getElementsByTagName('ratelog');
	for (var i = 0; i < ratelist.length; i++) {
	    var uid = getSpecificNodeValue(doc, "uid", i);
	    var username = getSpecificNodeValue(doc, "username", i);
	    var extcreditsname = getSpecificNodeValue(doc, "extcreditsname", i);
	    var extcreditsunit = getSpecificNodeValue(doc, "extcreditsunit", i);
	    var postdatetime = getSpecificNodeValue(doc, "postdatetime", i);
	    var score = getSpecificNodeValue(doc, "score", i);
	    var reason = getSpecificNodeValue(doc, "reason", i);

	    if (aspxrewrite == 1) {
	        html += "<div style='width:95%;'>&nbsp;&nbsp;<div style='float:left;width:15%;'><a target='_blank' href='userinfo-" + uid + ".aspx' style='color:#DD0000;'>" + username + "</a></div>&nbsp;&nbsp;<div style='float:left;width:22%;'>" + postdatetime + "</div>&nbsp;&nbsp;<div style='float:left;width:18%;'>" + extcreditsname + "&nbsp;&nbsp;<b>" + score + "</b>&nbsp;" + extcreditsunit + "</div>&nbsp;&nbsp;<div style='float:left;width:43%;'>" + reason + "</div></div>";
	    }
	    else {
	        html += "<div style='width:95%;'>&nbsp;&nbsp;<div style='float:left;width:15%;'><a target='_blank' href='userinfo.aspx?userid=" + uid + "' style='color:#DD0000;'>" + username + "</a></div>&nbsp;&nbsp;<div style='float:left;width:22%;'>" + postdatetime + "</div>&nbsp;&nbsp;<div style='float:left;width:18%;'>" + extcreditsname + "&nbsp;&nbsp;<b>" + score + "</b>&nbsp;" + extcreditsunit + "</div>&nbsp;&nbsp;<div style='float:left;width:43%;'>" + reason + "</div></div>";
	    }
	}
	if (ratelist.length == 0)
	{
		html = "";
	}

	ratediv.innerHTML = html;

}

var msgwidth=0;
function attachimg(obj,action)
{
	if(action=='load')
	{
		if(is_ie&&is_ie<7)
		{
			var objinfo=fetchOffset(obj);
			msgwidth=document.body.clientWidth-objinfo['left']-20;
		}else 
		{
			if(!msgwidth)
			{
				var re=/postcontent|msgborder/i;
				var testobj=obj;
				while((testobj=testobj.parentNode)!=null)
				{
					var matches=re.exec(testobj.className);
					if(matches!=null)
					{
						msgwidth=testobj.clientWidth-20;
						break;						
					}
				};
				if(msgwidth<1)
				{
					msgwidth=window.screen.width;					
				}
			}
		};
		if(obj.width>msgwidth)
		{
			obj.resized=true;
			obj.width=msgwidth;
			obj.style.cursor='pointer';
			
		}else 
		{
			obj.onclick=null;			
		}
	}else if(action=='mouseover')
	{
		if(obj.resized)
		{
			obj.style.cursor='pointer';			
		}
	}
}

function attachimginfo(obj, infoobj, show, event) {
	objinfo = fetchOffset(obj);
	if(show) {
		$(infoobj).style.left = objinfo['left'] + 'px';
		$(infoobj).style.top = obj.offsetHeight < 40 ? (objinfo['top'] + obj.offsetHeight) + 'px' : objinfo['top'] + 'px';
		$(infoobj).style.display = '';
	} else {
		if(is_ie) {
			$(infoobj).style.display = 'none';
			return;
		} else {
			var mousex = document.body.scrollLeft + event.clientX;
			var mousey = document.documentElement.scrollTop + event.clientY;
			if(mousex < objinfo['left'] || mousex > objinfo['left'] + objinfo['width'] || mousey < objinfo['top'] || mousey > objinfo['top'] + objinfo['height']) {
				$(infoobj).style.display = 'none';
			}
		}
	}
}

var zoomobj = Array();var zoomadjust;var zoomstatus = 1;
function zoom(obj, zimg) {
	if(!zoomstatus) {
		window.open(zimg, '', '');
		return;
	}
	if(!zimg) {
		zimg = obj.src;
	}
	if(!$('zoomimglayer_bg')) {
		div = document.createElement('div');div.id = 'zoomimglayer_bg';
		div.style.position = 'absolute';
		div.style.left = div.style.top = '0px';
		div.style.width = '100%';
		div.style.height = document.body.scrollHeight + 'px';
		div.style.backgroundColor = '#000';
		div.style.display = 'none';
		div.style.filter = 'progid:DXImageTransform.Microsoft.Alpha(opacity=80,finishOpacity=100,style=0)';
		div.style.opacity = 0.8;
		$('append_parent').appendChild(div);
		div = document.createElement('div');div.id = 'zoomimglayer';
		div.style.position = 'absolute';
		div.className = 'popupmenu_popup';
		div.style.padding = 0;
		$('append_parent').appendChild(div);
	}
	zoomobj['srcinfo'] = fetchOffset(obj);
	zoomobj['srcobj'] = obj;
	zoomobj['zimg'] = zimg;
	$('zoomimglayer').style.display = '';
	$('zoomimglayer').style.left = zoomobj['srcinfo']['left'] + 'px';
	$('zoomimglayer').style.top = zoomobj['srcinfo']['top'] + 'px';
	$('zoomimglayer').style.width = zoomobj['srcobj'].width + 'px';
	$('zoomimglayer').style.height = zoomobj['srcobj'].height + 'px';
	$('zoomimglayer').style.filter = 'progid:DXImageTransform.Microsoft.Alpha(opacity=40,finishOpacity=100,style=0)';
	$('zoomimglayer').style.opacity = 0.4;
	$('zoomimglayer').style.zIndex = 999;
	$('zoomimglayer').innerHTML = '<table width="100%" height="100%" cellspacing="0" cellpadding="0"><tr><td align="center" valign="middle"><img src="images/common/loading.gif"></td></tr></table><div style="position:absolute;top:-100000px;visibility:hidden"><img onload="zoomimgresize(this)" src="' + zoomobj['zimg'] + '"></div>';
}
var zoomdragstart = new Array();
var zoomclick = 0;
function zoomdrag(e, op) {
	if(op == 1) {
		zoomclick = 1;
		zoomdragstart = is_ie ? [event.clientX, event.clientY] : [e.clientX, e.clientY];
		zoomdragstart[2] = parseInt($('zoomimglayer').style.left);
		zoomdragstart[3] = parseInt($('zoomimglayer').style.top);
		doane(e);
	} else if(op == 2 && zoomdragstart[0]) {
		zoomclick = 0;
		var zoomdragnow = is_ie ? [event.clientX, event.clientY] : [e.clientX, e.clientY];
		$('zoomimglayer').style.left = (zoomdragstart[2] + zoomdragnow[0] - zoomdragstart[0]) + 'px';
		$('zoomimglayer').style.top = (zoomdragstart[3] + zoomdragnow[1] - zoomdragstart[1]) + 'px';
		doane(e);
	} else if(op == 3) {
		if(zoomclick) zoomclose();
		zoomdragstart = [];
		doane(e);
	}
}
function zoomimgresize(obj) {
	zoomobj['zimginfo'] = [obj.width, obj.height];
	var r = obj.width / obj.height;
	var w = document.body.clientWidth * 0.95;
	w = obj.width > w ? w : obj.width;
	var h = w / r;
	var clientHeight = document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body.clientHeight;
	var scrollTop = document.body.scrollTop ? document.body.scrollTop : document.documentElement.scrollTop;
	if(h > clientHeight) {
		h = clientHeight;
		w = h * r;
	}
	var l = (document.body.clientWidth - w) / 2;
	var t = h < clientHeight ? (clientHeight - h) / 2 : 0;
	t += + scrollTop;
	zoomobj['x'] = (l - zoomobj['srcinfo']['left']) / 5;
	zoomobj['y'] = (t - zoomobj['srcinfo']['top']) / 5;
	zoomobj['w'] = (w - zoomobj['srcobj'].width) / 5;
	zoomobj['h'] = (h - zoomobj['srcobj'].height) / 5;
	$('zoomimglayer').style.filter = '';
	$('zoomimglayer').innerHTML = '';
	setTimeout('zoomST(1)', 5);
}

function zoomST(c) {
	if($('zoomimglayer').style.display == '') {
		$('zoomimglayer').style.left = (parseInt($('zoomimglayer').style.left) + zoomobj['x']) + 'px';
		$('zoomimglayer').style.top = (parseInt($('zoomimglayer').style.top) + zoomobj['y']) + 'px';
		$('zoomimglayer').style.width = (parseInt($('zoomimglayer').style.width) + zoomobj['w']) + 'px';
		$('zoomimglayer').style.height = (parseInt($('zoomimglayer').style.height) + zoomobj['h']) + 'px';
		var opacity = c * 20;
		$('zoomimglayer').style.filter = 'progid:DXImageTransform.Microsoft.Alpha(opacity=' + opacity + ',finishOpacity=100,style=0)';
		$('zoomimglayer').style.opacity = opacity / 100;
		c++;
		if(c <= 5) {
			setTimeout('zoomST(' + c + ')', 5);
		} else {
			zoomadjust = 1;
			$('zoomimglayer').style.filter = '';
			$('zoomimglayer_bg').style.display = '';
			$('zoomimglayer').innerHTML = '<table cellspacing="0" cellpadding="2"><tr><td style="text-align: right">鼠标滚轮缩放图片 <a href="' + zoomobj['zimg'] + '" target="_blank"><img src="images/common/newwindow.gif" border="0" style="vertical-align: middle" title="在新窗口打开" /></a> <a href="###" onclick="zoomimgadjust(event, 1)"><img src="images/common/resize.gif" border="0" style="vertical-align: middle" title="实际大小" /></a> <a href="###" onclick="zoomclose()"><img style="vertical-align: middle" src="images/common/close.gif" title="关闭" /></a>&nbsp;</td></tr><tr><td align="center" id="zoomimgbox"><img id="zoomimg" style="cursor: move; margin: 5px;" src="' + zoomobj['zimg'] + '" width="' + $('zoomimglayer').style.width + '" height="' + $('zoomimglayer').style.height + '"></td></tr></table>';
			$('zoomimglayer').style.overflow = 'visible';
			$('zoomimglayer').style.width = $('zoomimglayer').style.height = 'auto';
			if(is_ie){
				$('zoomimglayer').onmousewheel = zoomimgadjust;
			} else {
				$('zoomimglayer').addEventListener("DOMMouseScroll", zoomimgadjust, false);
			}
			$('zoomimgbox').onmousedown = function(event) {try{zoomdrag(event, 1);}catch(e){}};
			$('zoomimgbox').onmousemove = function(event) {try{zoomdrag(event, 2);}catch(e){}};
			$('zoomimgbox').onmouseup = function(event) {try{zoomdrag(event, 3);}catch(e){}};
		}
	}
}

function zoomimgadjust(e, a) {
	if(!a) {
		if(!e) e = window.event;
		if(e.altKey || e.shiftKey || e.ctrlKey) return;
		var l = parseInt($('zoomimglayer').style.left);
		var t = parseInt($('zoomimglayer').style.top);
		if(e.wheelDelta <= 0 || e.detail > 0) {
			if($('zoomimg').width <= 200 || $('zoomimg').height <= 200) {
				doane(e);return;
			}
			$('zoomimg').width -= zoomobj['zimginfo'][0] / 10;
			$('zoomimg').height -= zoomobj['zimginfo'][1] / 10;
			l += zoomobj['zimginfo'][0] / 20;
			t += zoomobj['zimginfo'][1] / 20;
		} else {
			if($('zoomimg').width >= zoomobj['zimginfo'][0]) {
				zoomimgadjust(e, 1);return;
			}
			$('zoomimg').width += zoomobj['zimginfo'][0] / 10;
			$('zoomimg').height += zoomobj['zimginfo'][1] / 10;
			l -= zoomobj['zimginfo'][0] / 20;
			t -= zoomobj['zimginfo'][1] / 20;
		}
	} else {
		var clientHeight = document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body.clientHeight;
		var scrollTop = document.body.scrollTop ? document.body.scrollTop : document.documentElement.scrollTop;
		$('zoomimg').width = zoomobj['zimginfo'][0];$('zoomimg').height = zoomobj['zimginfo'][1];
		var l = (document.body.clientWidth - $('zoomimg').clientWidth) / 2;l = l > 0 ? l : 0;
		var t = (clientHeight - $('zoomimg').clientHeight) / 2 + scrollTop;t = t > 0 ? t : 0;
	}
	$('zoomimglayer').style.left = l + 'px';
	$('zoomimglayer').style.top = t + 'px';
	$('zoomimglayer_bg').style.height = t + $('zoomimglayer').clientHeight > $('zoomimglayer_bg').clientHeight ? (t + $('zoomimglayer').clientHeight) + 'px' : $('zoomimglayer_bg').style.height;
	doane(e);
}
function zoomclose() {
	$('zoomimglayer').innerHTML = '';
	$('zoomimglayer').style.display = 'none';
	$('zoomimglayer_bg').style.display = 'none';
}

function setIdentify(identify)
{
	identify.style.left = ((document.body.clientWidth - $('container').clientWidth)/2 + $('container').clientWidth - 400) + 'px';
	identify.style.top = identify.offsetTop + 25 + 'px';
}

var tags = new Array();
if (typeof (closedtags)=='undefined')
{	
	var closedtags;
}
if (typeof (colorfultags)=='undefined')
{	
	var colorfultags;
}
function getTopicTags(topicid)
{
	_sendRequest('tools/ajax.aspx?t=gettopictags&topicid=' + topicid, function(responseText){
		if (responseText)
		{
			var topic_tags = eval('('+responseText+')');
			if (topic_tags.length > 0)
			{			
				var html = '搜索更多相关主题的帖子: ';
				for (var i in topic_tags)
				{
					html += '<a href="';
					if (aspxrewrite == 1)
					{
						html += 'topictag-' + topic_tags[i].tagid + '.aspx"';
					}
					else
					{
						html += 'tags.aspx?t=topic&tagid=' + topic_tags[i].tagid +'"';
					}
					
					if (colorfultags && colorfultags[topic_tags[i].tagid])
					{
						html += ' style="color:#' + colorfultags[topic_tags[i].tagid].color + ';"';
					}
					html += '>' + topic_tags[i].tagname + '</a>&nbsp;' ;
					tags[tags.length] = topic_tags[i];
				}
				$('topictag').innerHTML = html;
			}			
		}	
		parsetag();
	});
}

function isexisttaginarray(tagarray, tag)
{
	if (tag)
	{	
		for (var i = 0; i < tagarray.length; i++)
		{
			if (tagarray[i] && tagarray[i].tagid == tag.tagid)
			{
				return true;
			}
		}
		return false;
	}
	return false;
}

function parsetag() {
	var tagfindarray = new Array();	
	var str = $('firstpost').innerHTML.replace(/(^|>)([^<]+)(?=<(?!\/script)|$)/ig, function($1, $2, $3, $4) {
		for(i in tags) {
			if(tags[i] && !in_array(tags[i].tagid, closedtags) && !isexisttaginarray(tagfindarray, tags[i]) && ($3.indexOf(tags[i].tagname) != -1)) {
				$3 = $3.replace(tags[i].tagname, '<h_ ' + i + '>');
				tagfindarray[i] = tags[i];
				tags[i] = '';
			}
		}
		return $2 + $3;
	});
	
	$('firstpost').innerHTML = str.replace(/<h_ (\d+)>/ig, function($1, $2) {
		var temp_html = '<span href=\"tools/ajax.aspx?t=topicswithsametag&tagid=' + tagfindarray[$2].tagid + '\" onclick=\"tagshow(event)\" class=\"t_tag\"';
		if (colorfultags && colorfultags[tagfindarray[$2].tagid])
		{
			temp_html += ' style=\"color: #' + colorfultags[tagfindarray[$2].tagid].color + '\"';
		}		
		temp_html += '>' + tagfindarray[$2].tagname + '</span>';
		return temp_html;
	});
}

function tagshow(event) {
	var obj = is_ie ? event.srcElement : event.target;
	obj.id = !obj.id ? 'tag_' + Math.random() : obj.id;
	ajaxmenu(event, obj.id, 0, '', 1, 3, 0);
	obj.onclick = null;
}