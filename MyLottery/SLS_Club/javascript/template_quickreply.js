function createXMLHttp() {
	if(window.XMLHttpRequest){
		return new XMLHttpRequest();
	} else if(window.ActiveXObject){
		return new ActiveXObject("Microsoft.XMLHTTP");
	} 
	throw new Error("XMLHttp object could be created.");
}
function sendRequest(action, isendpage, templatepath) {
	var oForm = document.getElementById("postform");
	if (!isendpage || !isendpage == true)
	{
		oForm.submit();
		return;
	}
	var sBody = getRequestBody(oForm);
	var oXmlHttp = createXMLHttp();
	oXmlHttp.open("post", (action && action != '') ? action : oForm.action, true);
	oXmlHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
	oXmlHttp.onreadystatechange = function () {
		if (oXmlHttp.readyState == 4) {
			if (oXmlHttp.status == 200) {
				saveResult(oXmlHttp.responseXML, templatepath);
				oForm.replysubmit.disabled = false;
				if (document.getElementById("reloadvcade"))
				{
					document.getElementById("reloadvcade").click();
				}
				//bind current post;
			} else {
				alert("An error occurred: " + oXmlHttp.statusText);
			}
		}
	};
	oXmlHttp.send(sBody);
}
function getRequestBody(oForm) {
	var aParams = new Array();
	for (var i=0 ; i < oForm.elements.length; i++) {
		if (oForm.elements[i].type == "checkbox" && oForm.elements[i].checked == false)
		{
			continue;
		}
		var sParam = encodeURIComponent(oForm.elements[i].name);
		sParam += "=";
		sParam += encodeURIComponent(oForm.elements[i].value);
		aParams.push(sParam);
	}
	return aParams.join("&");
}

function ajaxctlent(event, objfrm, topicid, isendpage, templatepath) {
	if(postSubmited == false && (event.ctrlKey && event.keyCode == 13) || (event.altKey && event.keyCode == 83)) {
		if (!$("postsubmit").disabled)
		{
			if (validate(objfrm, false, false)) 
			{
				sendRequest('tools/ajax.aspx?topicid=' + topicid + '&t=quickreply', isendpage, templatepath);			
			}
		}
		else
		{
			alert('正在提交, 请稍候...');
		}
		
	}
}

function getStars(n, t, path) {
	var s = '';
	for (var i = 3; i > 0; i--) {
		var level = parseInt(n / Math.pow(t, i-1));
		n = n % Math.pow(t, i-1);
		for (var j = 0; j < level; j++) {
			s += '<img src="templates/' + path + '/images/star_level' + i + '.gif" />';
		}
	}
	return s;
}

function getInPostad(index){

	try{
		if (inpostad){
				var adstr = '';
				adstr += "<div class=\"line category\"><div style='float: left;'>[广告]&nbsp;</div><div>";
				var tempstr = inpostad[index];
				var ad = tempstr.split("\\r\\n");
				for (var i = 0; i < ad.length; i++)
				{
					adstr += ("\r\n" + ad[i]);
				}
				adstr += "\r\n</div></div>";
				return adstr;
			}
		}
	catch(e){}
	return "";
}
String.prototype.trim = function(){return this.replace(/(^[\s\t\xa0\u3000]+)|([\u3000\xa0\s\t]+$)/g, "")};
function saveResult(doc, templatepath)
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


	var invisible = getSingleNodeValue(doc, 'invisible');
	if (invisible == 1)
	{
		alert("回复成功，请等待审核");
		return;
	}

	var ismoder = getSingleNodeValue(doc, 'ismoder');
	var adindex = getSingleNodeValue(doc, 'adindex');
	var status = getSingleNodeValue(doc, 'status');
	var stars = getSingleNodeValue(doc, 'stars');
	var id = getSingleNodeValue(doc, 'id');
	var fid = getSingleNodeValue(doc, 'fid');
	
	var ip = getSingleNodeValue(doc, 'ip');
	var lastedit = getSingleNodeValue(doc, 'lastedit');
	var layer = getSingleNodeValue(doc, 'layer');
	var message = escape(getSingleNodeValue(doc, 'message'));
	var parentid = getSingleNodeValue(doc, 'parentid');
	var pid = getSingleNodeValue(doc, 'pid');
	var postdatetime = getSingleNodeValue(doc, 'postdatetime');
	var poster = getSingleNodeValue(doc, 'poster');
	var posterid = getSingleNodeValue(doc, 'posterid');
	var smileyoff = getSingleNodeValue(doc, 'smileyoff');
	var topicid = getSingleNodeValue(doc, 'topicid');
	var title = getSingleNodeValue(doc, 'title');
	var usesig = getSingleNodeValue(doc, 'usesig');
	var uid = getSingleNodeValue(doc, 'uid');
	var accessmasks = getSingleNodeValue(doc, 'accessmasks');
	var adminid = getSingleNodeValue(doc, 'adminid');
	var avatar = getSingleNodeValue(doc, 'avatar');
	var avatarheight = getSingleNodeValue(doc, 'avatarheight');
	var avatarshowid = getSingleNodeValue(doc, 'avatarshowid');
	var avatarwidth = getSingleNodeValue(doc, 'avatarwidth');
	var credits = getSingleNodeValue(doc, 'credits');
	var digestposts = getSingleNodeValue(doc, 'digestposts');
	var email = getSingleNodeValue(doc, 'email');
	var score1 = getSingleNodeValue(doc, 'score1');
	var score2 = getSingleNodeValue(doc, 'score2');
	var score3 = getSingleNodeValue(doc, 'score3');
	var score4 = getSingleNodeValue(doc, 'score4');
	var score5 = getSingleNodeValue(doc, 'score5');
	var score6 = getSingleNodeValue(doc, 'score6');
	var score7 = getSingleNodeValue(doc, 'score7');
	var score8 = getSingleNodeValue(doc, 'score8');
	var scoreunit1 = getSingleNodeValue(doc, 'scoreunit1');
	var scoreunit2 = getSingleNodeValue(doc, 'scoreunit2');
	var scoreunit3 = getSingleNodeValue(doc, 'scoreunit3');
	var scoreunit4 = getSingleNodeValue(doc, 'scoreunit4');
	var scoreunit5 = getSingleNodeValue(doc, 'scoreunit5');
	var scoreunit6 = getSingleNodeValue(doc, 'scoreunit6');
	var scoreunit7 = getSingleNodeValue(doc, 'scoreunit7');
	var scoreunit8 = getSingleNodeValue(doc, 'scoreunit8');
	var extcredits1 = getSingleNodeValue(doc, 'extcredits1');
	var extcredits2 = getSingleNodeValue(doc, 'extcredits2');
	var extcredits3 = getSingleNodeValue(doc, 'extcredits3');
	var extcredits4 = getSingleNodeValue(doc, 'extcredits4');
	var extcredits5 = getSingleNodeValue(doc, 'extcredits5');
	var extcredits6 = getSingleNodeValue(doc, 'extcredits6');
	var extcredits7 = getSingleNodeValue(doc, 'extcredits7');
	var extcredits8 = getSingleNodeValue(doc, 'extcredits8');
	var extgroupids = getSingleNodeValue(doc, 'extgroupids');
	var gender = getSingleNodeValue(doc, 'gender');
	var bday = getSingleNodeValue(doc, 'bday');
	var icq = getSingleNodeValue(doc, 'icq');
	var joindate = getSingleNodeValue(doc, 'joindate');
	var lastactivity = getSingleNodeValue(doc, 'lastactivity');
	var medals = getSingleNodeValue(doc, 'medals');
	var nickname = getSingleNodeValue(doc, 'nickname');
	var oltime = getSingleNodeValue(doc, 'oltime');
	var onlinestate = getSingleNodeValue(doc, 'onlinestate');
	var showemail = getSingleNodeValue(doc, 'showemail');
	var signature = getSingleNodeValue(doc, 'signature');
	var sigstatus = getSingleNodeValue(doc, 'sigstatus');
	var skype = getSingleNodeValue(doc, 'skype');
	var website = getSingleNodeValue(doc, 'website');
	var yahoo = getSingleNodeValue(doc, 'yahoo');
	var qq = getSingleNodeValue(doc, 'qq');
	var msn = getSingleNodeValue(doc, 'msn');
	var posts = getSingleNodeValue(doc, 'posts');
	var footerad = getSingleNodeValue(doc, 'ad_thread1');
	var topad = getSingleNodeValue(doc, 'ad_thread2');
	var rightad = getSingleNodeValue(doc, 'ad_thread3');

	var theLocation = getSingleNodeValue(doc, 'location');

	var showavatars = getSingleNodeValue(doc, 'showavatars');
	var userstatusby = getSingleNodeValue(doc, 'userstatusby');
	var starthreshold = getSingleNodeValue(doc, 'starthreshold');
	var forumtitle = getSingleNodeValue(doc, 'forumtitle');
	var showsignatures = getSingleNodeValue(doc, 'showsignatures');
	var maxsigrows = getSingleNodeValue(doc, 'maxsigrows');
	var enablespace = getSingleNodeValue(doc, 'enablespace');
	var enablealbum = getSingleNodeValue(doc, 'enablealbum');
    var medals=getSingleNodeValue(doc, 'medals');
	var debateopinion = getSingleNodeValue(doc, 'debateopinion');

	var container = document.getElementById("postsContainer");
	var divDetailnav = document.createElement("DIV");
	var divDetailnav2 = document.createElement("DIV");
	var divmenu = document.createElement("DIV");

	container.appendChild(divDetailnav);
	container.appendChild(divDetailnav2);
	container.appendChild(divmenu);

	divDetailnav.className = 'viewthread';
	divDetailnav2.className = 'threadline';
	divmenu.className = 'menuwindow';
	divmenu.id = 'memberinfo_' + id + '_menu';
	divmenu.style.display = 'none';
	//divmenu.style.width = '177px';
	
	var html = '';
	html += '		<table cellpadding="0" cellspacing="0" border="0">';
	html += '			<tbody>';
	html += '			<tr>';
	html += '			<td class="postauthor" id="' + pid + '">';
	html += '					<cite><a href="###" class="dropmenu" id="memberinfo_' + id + '" onmouseover="showMenu(this.id,false)">';
	html += '						<img src="templates/' + templatepath + '/images/useronline.gif" align="absmiddle" title="在线" />';
	html +=	poster;
	html += '					</a></cite>';
	//html += '				</div>';
	html += '				<div class="avatar">';
	if (avatar != '' && showavatars == '1')
	{
		html += '	<img class="avatar" onerror="this.onerror=null;this.src=\'templates/' + templatepath + '/images/noavatar.gif\';" src="' + avatar + '"';
			if (parseInt(avatarwidth) > 0)
			{
				html += '	width="' + avatarwidth + '"';
				html += '	height="' + avatarheight + '"';
			}
		html += '	/>';
	}
	html += '				</div>';
	if (nickname != "")
	{
		html += '			<p><em>';
		html += nickname;
		html += '			</em></p>';
	}
	html += '				<p>';
	html += getStars(stars, starthreshold, templatepath);
	html += '				</p>';
	//html += '			<div class="profile">';
	//html += '				<ul>';
	if (enablespace == 1 || enablealbum == 1)
	{
		html += '						<ul>';
	}
	
	if (enablespace == 1)
	{
		html += '<li class="space"><a href="space/?uid=' + posterid + '">个人空间</a></li>';
	}
	
	if (enablealbum == 1)
	{
		html += '<li class="albumpic"><a href="showalbumlist.aspx?uid=' + posterid + '">相册</a></li>';
	}


	if (enablespace == 1 || enablealbum == 1)
	{
	html += '				</ul>';
	}
	
	
	html += '				<ul class="otherinfo">';
	if (userstatusby == 1)
	{
		html += '				<li>组别:' + status +'</li>';
	}
	html += '					<li>性别:' + displayGender(gender) + '</li>';
	if (bday.trim() != '')
	{
		html += '				<li>生日: ' + bday + '</li>';
	}
	//html += '					<li>来自: ' + theLocation+ '</li>';
	html += '					<li>金币: ' + credits + '</li>';
	html += '					<li>帖子: ' + posts + '</li>';
	//html += '					<li>注册: ' + new Date(joindate.replace(/-/ig,'/')).format("yyyy-MM-dd")+ '</li>';
	html += '				</ul>';
	//html += '			</div>';
    html += '                       <div class="medals">';
	html += medals;                    
    html += '                       </div>';
	html += '			</td>';
	html += '			<td class="postcontent">';
	html += '			<div class="postinfo">';
	//html += '				<div class="postinfoleft">';
	//html += '					<span>' + postdatetime + '</span>';
	html += '					<em>' + postdatetime + '</em>';
	//html += '					<em>|';
	//html += '					</em>';
	//html += '				</div>';
	//html += '<em>';
	//html += '				<div class="postinfoitem">';
	html += '					<a href="showtree.aspx?topicid=' + topicid + '&postid=' + pid + '">树型</a><span class="see-line2">|</span>';
	html += '					<a href="favorites.aspx?topicid=' + topicid + '">收藏</a><span class="see-line2">|</span>';
	html += '					<a href="editpost.aspx?topicid=' + topicid + '&postid=' + pid + '&referer=' + escape(window.location) + '">编辑</a><span class="see-line2">|</span>';
	html += '					<a href="delpost.aspx?topicid=' + topicid + '&postid=' + pid + '" onclick="return confirm(\'确定要删除吗?\');">删除</a>&nbsp;';
	if(ismoder == 1)
	{
		html += '				<input name="postid" id="postid" value="'+pid+'" type="checkbox" />';
	}
	html += '					<a href="###" class="t_number" onclick="$(\'message' + pid + '\').className=\'t_smallfont\'">小</a>';
	html += '					<a href="###" class="t_number" onclick="$(\'message' + pid + '\').className=\'t_msgfont\'">中</a>';
	html += '					<a href="###" class="t_number" onclick="$(\'message' + pid + '\').className=\'t_bigfont\'">大</a>';
	html += '					<span>' + id + '<sup>#</sup></span>';
	//html += '				</div>';
	//html +='</em>';
	html += '			</div>';
	html += '			<div id="ad_thread2_' + id + '"></div>';
	html += '			<div class="postmessage defaultpost">';
	//html += '				<div class="forumarticle">';
	html += '					<h2>' + title + '</h2>';
	html += '					<div id="message' + pid + '" class="t_msgfont"><div id="ad_thread3_' + id + '"></div>' + unescape(message) + '</div>';
	//html += '				</div>';
	if (debateopinion == 1)
	{
		html += '正方';
	}
	else if (debateopinion == 2)
	{
		html += '反方';
	}
	html += '			</div>';
	if (usesig == 1 && signature != "" && showsignatures == 1)
	{
		html += '			<div class="postertext">';
		if (maxsigrows > 0)
		{
			var ieheight = maxsigrows*12;
			html += '			<div class="t_signature" style="overflow: hidden; max-height: ' + maxsigrows*1.6 + 'em;maxHeightIE:'+ieheight+'px;">'+signature+'</div>';
		}
		else
			html += signature;
		html += '			</div>';
	}
	html += '			</td>';
	html += '			</tr>';
	html += '			</tbody>';
	html += '			<tbody>';
	html += '			<tr>';
	html += '			<td class="postauthor">';
	html += '				&nbsp';
	html += '			</td>';
	html += '			<td class="postcontent">';
	html += '				<div class="postactions"><p>';
	html += '					<a href="postreply.aspx?topicid='+topicid+'&postid='+pid+'&quote=yes">引用</a>|';
	html += '					<a href="###" onclick="replyToFloor(\'' + id + '\', \'' + poster + '\', \'' + pid + '\')">回复</a>|';
	html += '                    <a href="###" onclick="window.scrollTo(0,0)">TOP</a></p>';
	html += '			         <div id="ad_thread1_' + id + '"></div>';
	html += '				</div>';
	html += '			</td>';
	html += '			</tr>';
	html += '			</tbody>';
	
	divDetailnav.innerHTML = html;

	divDetailnav2.innerHTML = '&nbsp;';

	html = '					<div class="popupmenu_popup userinfopanel" style="width:150px;">';
	//html += '						<div class="popupmenuitem" style="border-top:none;">';
	html += '							<p class="recivemessage">';
	html += '							<a href="usercppostpm.aspx?msgtoid=' + posterid + '" target="_blank">发送短消息</a></p>';
	//html += '						</div>';
	//html += '						<div class="popupmenuitem">';
	html += '							<p><a href="userinfo.aspx?userid=' + posterid + '" target="_blank">查看公共资料</a></p>';
	html += '							<p><a href="search.aspx?posterid=' + posterid + '">查找该会员全部帖子</a></p>';
	//html += '						</div>';
	//html += '						<div class="popupmenuitem">';
	html += '						<ul>';
	html += '						<li>UID:' + posterid + '</li>';
	html += '						<li>精华:';
	if (digestposts>0)
	{
		html += '						<a href="search.aspx?posterid=' + posterid + '&type=digest">' + digestposts + '</a>'
	}
	else
	{
		digestposts
	}
	html += '						</li>';
	if (score1 != "")
		html += '<li>'+score1 + ':  ' + extcredits1 + ' ' + scoreunit1 + '</li>';
	if (score2 != "")
		html += '<li>'+score2 + ':  ' + extcredits2 + ' ' + scoreunit2 + '</li>';
	if (score3 != "")
		html += '<li>'+score3 + ':  ' + extcredits3 + ' ' + scoreunit3 + '</li>';
	if (score4 != "")
		html += '<li>'+score4 + ':  ' + extcredits4 + ' ' + scoreunit4 + '</li>';
	if (score5 != "")
		html += '<li>'+score5 + ':  ' + extcredits5 + ' ' + scoreunit5 + '</li>';
	if (score6 != "")
		html += '<li>'+score6 + ':  ' + extcredits6 + ' ' + scoreunit6 + '</li>';
	if (score7 != "")
		html += '<li>'+score7 + ':  ' + extcredits7 + ' ' + scoreunit7 + '</li>';
	if (score8 != "")
	{
		html += '<li>'+score8 + ':  ' + extcredits8 + ' ' + scoreunit8 + '</li>';
	}
	html += '					<li>来自: ' + theLocation+ '</li>';
	html += '					<li>注册: ' + new Date(joindate.replace(/-/ig,'/')).format("yyyy-MM-dd")+ '</li>';
	html += '					</ul>';
	//html += '					</div>';
	//html += '						<div class="popupmenuitem">';
	html += '						<p>状态:<span>在线</span></p>';
	html += '						<ul class="tools">';
	if (msn !='')
	{
		html += '					<li>';
		html += '						<img src="templates/' + templatepath + '/images/msnchat.gif" title="MSN Messenger: ' + msn + '"/>';
		html += '						<a href="mailto:' + msn + '" target="_blank">' + msn + '</a>';
		html += '					</li>';
	}
	if (skype !='')
	{
		html += '					<li>';
		html += '						<img src="templates/' + templatepath + '/images/skype.gif" title="Skype: ' + skype + '"/>';
		html += '						<a href="skype:' + skype + '" target="_blank">' + skype + '</a>';
		html += '					</li>';
	}
	if (icq !='')
	{
		html += '					<li>';
		html += '						<img src="templates/' + templatepath + '/images/icq.gif" title="ICQ: ' + icq + '"/>';
		html += '						<a href="http://wwp.icq.com/scripts/search.dll?to=' + icq + '" target="_blank">' + icq + '</a>';
		html += '					</li>';
	}
	if (qq !='')
	{
		html += '					<li>';
		html += '						<img src="templates/' + templatepath + '/images/qq.gif" title="QQ: ' + qq + '" />';
		html += '						<a href="http://wpa.qq.com/msgrd?V=1&Uin=' + qq + '&Site=' + forumtitle + '&Menu=yes" target="_blank">' + qq + '</a>';
		html += '					</li>';
	}
	if (yahoo !='')
	{
		html += '					<li>';
		html += '						<img src="templates/' + templatepath + '/images/yahoo.gif" title="Yahoo Messager: ' + yahoo + '" />';
		html += '						<a href="http://edit.yahoo.com/config/send_webmesg?.target=' + yahoo + '&.src=pg" target="_blank">' + yahoo + '</a>';
		html += '					</li>';
	}
	html += '						</ul>';
	//html += '						</div>';

	divmenu.innerHTML = html;

	try
	{		
		document.getElementById("postform").reset();
	}
	catch (e)
	{
		alert(e.message);
	}
	delete doc;
}

function getSingleNodeValue(doc, tagname)
{
	try{
		var oNodes = doc.getElementsByTagName(tagname);
		if (oNodes[0] != null && oNodes[0] != undefined)
		{
			if (oNodes[0].childNodes.length > 1) {
				return oNodes[0].childNodes[1].nodeValue;
			} else {
				return oNodes[0].firstChild.nodeValue;    		
			}
		}
	}
	catch(e){}
	return '';
}
