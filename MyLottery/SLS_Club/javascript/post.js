/*
	[Discuz!] (C)2001-2007 Comsenz Inc.
	This is NOT a freeware, use is subject to license terms

	$RCSfile: post.js,v $
	$Revision: 1.24 $
	$Date: 2007/07/20 12:20:51 $
*/

var postSubmited = false;
var smdiv = new Array();

function AddText(txt) {
	obj = $('postform').message;
	selection = document.selection;
	checkFocus();
	if(!isUndefined(obj.selectionStart)) {
		var opn = obj.selectionStart + 0;
		obj.value = obj.value.substr(0, obj.selectionStart) + txt + obj.value.substr(obj.selectionEnd);
	} else if(selection && selection.createRange) {
		var sel = selection.createRange();
		sel.text = txt;
		sel.moveStart('character', -strlen(txt));
	} else {
		obj.value += txt;
	}
}

function checkFocus() {
	var obj = typeof wysiwyg == 'undefined' || !wysiwyg ? $('postform').message : editwin;
	if(!obj.hasfocus) {
		obj.focus();
	}
}

function ctlent(event) {
	if(postSubmited == false && (event.ctrlKey && event.keyCode == 13) || (event.altKey && event.keyCode == 83) && $('postsubmit')) {
	    try {
		    if(in_array($('postsubmit').name, ['topicsubmit', 'replysubmit', 'editsubmit', 'pmsubmit']) && !validate($('postform'))) {
			    doane(event);
			    return;
		    }
		    postSubmited = true;
		    $('postsubmit').disabled = true;
		    $('postform').submit();
		}
		catch(e)
		{
		    return;
		}
	}
}

function ctlentParent(event) {	
    var pForm = parent.window.document.getElementById('postform');	
    var pSubmit = parent.window.document.getElementById('postsubmit');
	
	if(postSubmited == false && (event.ctrlKey && event.keyCode == 13) || (event.altKey && event.keyCode == 83) && pSubmit) {
		if (parent.window.validate && !parent.window.validate(pForm))
		{
			doane(event);
			return;	
		}
		postSubmited = true;
		pSubmit.disabled = true;
		pForm.submit();
	}
}

function deleteData() {
	if(is_ie) {
		saveData('', 'delete');
	} else if(window.sessionStorage) {
		try {
			sessionStorage.removeItem('Discuz!');
		} catch(e) {}
	}
}
/*
function insertSmiley(smilieid) {
	checkFocus();
	var src = $('smilie_' + smilieid).src;
	var code = $('smilie_' + smilieid).pop;
	if(typeof wysiwyg != 'undefined' && wysiwyg && allowsmilies && (!$('smileyoff') || $('smileyoff').checked == false)) {
		if(is_moz) {
			applyFormat('InsertImage', false, src);
			var smilies = editdoc.body.getElementsByTagName('img');
			for(var i = 0; i < smilies.length; i++) {
				if(smilies[i].src == src && smilies[i].getAttribute('smilieid') < 1) {
					smilies[i].setAttribute('smilieid', smilieid);
					smilies[i].setAttribute('border', "0");
				}
			}
		} else {
			insertText('<img src="' + src + '" border="0" smilieid="' + smilieid + '" alt="" /> ', false);
		}
	} else {
		code += ' ';
		AddText(code);
	}
}
*/
function smileyMenu(ctrl) {
	ctrl.style.cursor = 'pointer';
	if(ctrl.alt) {
		ctrl.pop = ctrl.alt;
		ctrl.alt = '';
	}
	if(ctrl.title) {
		ctrl.lw = ctrl.title;
		ctrl.title = '';
	}
	//if(!smdiv[ctrl.id]) {
		smdiv[ctrl.id] = document.createElement('div');
		smdiv[ctrl.id].id = ctrl.id + '_menu';
		smdiv[ctrl.id].style.display = 'none';
		smdiv[ctrl.id].style.width = '60px';
		smdiv[ctrl.id].style.height = '60px';
		smdiv[ctrl.id].className = 'popupmenu_popup';
		ctrl.parentNode.appendChild(smdiv[ctrl.id]);
	//}
	smdiv[ctrl.id].innerHTML = '<table width="100%" height="100%"><tr><td align="center" valign="middle"><img src="' + ctrl.src + '" border="0" /></td></tr></table>';
	showMenu(ctrl.id, 0, 0, 1, 0);
}

function insertSmiley(code) {
	checkFocus();
	var src = $('smilie_' + code).src;
	//var code = $('smilie_' + code).pop;
	if(typeof wysiwyg != 'undefined' && wysiwyg && allowsmilies && (!$('smileyoff') || $('smileyoff').checked == false)) {
		if(is_moz) {
			applyFormat('InsertImage', false, src);
			var smilies = findtags(editdoc.body, 'img');
			for(var i = 0; i < smilies.length; i++) {
				if(smilies[i].src == src && !smilies[i].getAttribute('smiliecode')) {
					smilies[i].setAttribute('smiliecode', code);
					smilies[i].setAttribute('border', "0");
				}
			}
		} else {
			insertText('<img src="' + src + '" border="0" smiliecode="' + code + '" alt="" /> ', false);
		}
	} else {
		code += ' ';
		AddText(code);
	}
}

function showsmiles(index, typename, pageindex)
{
	$("s_" + index).className = "lian";
	var cIndex = 1;
	for (i in smilies_HASH) {
		if (cIndex != index) {
			$("s_" + cIndex).className = "";
		}		
		$("s_" + cIndex).style.display = "";
		cIndex ++;
	}

	var pagesize = (typeof smiliePageSize) == 'undefined' ? 12 : smiliePageSize;
	var s = smilies_HASH[typename];
	var pagecount = Math.ceil(s.length/pagesize);

	if (isUndefined(pageindex)) {
		pageindex = 1;
	}
	if (pageindex > pagecount) {
		pageindex = pagecount;
	}
	
	var maxIndex = pageindex*pagesize;
	if (maxIndex > s.length) {
		maxIndex = s.length;
	}
	maxIndex = maxIndex - 1;

	var minIndex = (pageindex-1)*pagesize;

	var html = '<table align="center" border="0" cellpadding="3" cellspacing="0" width="90%"><tr>';

	var ci = 1;
	for (var id = minIndex; id <= maxIndex; id++) {
		html += '<td valign="middle"><img style="cursor: pointer;" src="editor/images/smilies/' + s[id]['url'] + '" id=smilie_' + s[id]['code'] + ' alt="" onclick="insertSmiley(\'' + addslashes(s[id]['code']) + '\')" onmouseover="smileyMenu(this)" title="" border="0" height="20" width="20" /></td>';
		if (ci%4 == 0) {
			html += '</tr><tr>'
		}
		ci ++;
	}

	html += '<td colspan="' + (4 - ((ci-1) % 4)) + '"></td>';
	html += '</tr>';
	html += '</table>';
	$("showsmilie").innerHTML = html;

	if (pagecount > 1) {
		html = '<div class="p_bar">';
		for (var i = 1; i <= pagecount; i++) {
			if (i == pageindex) {
				html += "<a class=\"p_curpage\">" + i + "</a>";
			}
			else {
				html += "<a class=\"p_num\" href='#smiliyanchor' onclick=\"showsmiles(" + index + ", '" + typename + "', " + i + ")\">" + i + "</a>"
			}
		}
		html += '</div>'
		$("showsmilie_pagenum").innerHTML = html;
	}
	else {
		$("showsmilie_pagenum").innerHTML = "";
	}
}

function showFirstPageSmilies(firstpagesmilies, defaulttypename, maxcount)
{
	var html = '<table align="center" border="0" cellpadding="3" cellspacing="0" width="90%"><tr>';
	var ci = 1;
	var s = firstpagesmilies[defaulttypename];
	for (var id = 0; id <= maxcount - 1; id++) {
		if(s[id] == null)
			continue;
		html += '<td valign="middle"><img style="cursor: pointer;" src="editor/images/smilies/' + s[id]['url'] + '" id=smilie_' + s[id]['code'] + ' alt="" onclick="insertSmiley(\'' + addslashes(s[id]['code']) + '\')" onmouseover="smileyMenu(this)" title="" border="0" height="20" width="20" /></td>';
		if (ci%4 == 0) {
			html += '</tr><tr>'
		}
		ci ++;
	}
	html += '<td colspan="' + (4 - ((ci-1) % 4)) + '"></td>';
	html += '</tr>';
	html += '</table>';

	$("showsmilie").innerHTML = html;
}

function scrollSmilieTypeBar(bar, scrollwidth)
{	
	//bar.scrollLeft += scrollwidth;
	var i = 0;
	if (scrollwidth > 0) {
		var scl = window.setInterval(function(){
			if (i < scrollwidth) {
				bar.scrollLeft += 1;
				i++
			}
			else
				window.clearInterval(scl);
		}, 1);
	}
	else {
		var scl = window.setInterval(function(){
			if (i > scrollwidth) {
				bar.scrollLeft -= 1;
				i--
			}
			else
				window.clearInterval(scl);
		}, 1);
	}
}
/*Discuz!NT end*/
function parseurl(str, mode) {
	str = str.replace(/([^>=\]"'\/]|^)((((https?|ftp):\/\/)|www\.)([\w\-]+\.)*[\w\-\u4e00-\u9fa5]+\.([\.a-zA-Z0-9]+|\u4E2D\u56FD|\u7F51\u7EDC|\u516C\u53F8)((\?|\/|:)+[\w\.\/=\?%\-&~`@':+!]*)+\.(jpg|gif|png|bmp))/ig, mode == 'html' ? '$1<img src="$2" border="0">' : '$1[img]$2[/img]');
	str = str.replace(/([^>=\]"'\/@]|^)((((https?|ftp|gopher|news|telnet|rtsp|mms|callto|bctp|ed2k|thunder|synacast):\/\/))([\w\-]+\.)*[:\.@\-\w\u4e00-\u9fa5]+\.([\.a-zA-Z0-9]+|\u4E2D\u56FD|\u7F51\u7EDC|\u516C\u53F8)((\?|\/|:)+[\w\.\/=\?%\-&~`@':+!#]*)*)/ig, mode == 'html' ? '$1<a href="$2" target="_blank">$2</a>' : '$1[url]$2[/url]');
	str = str.replace(/([^\w>=\]"'\/@]|^)((www\.)([\w\-]+\.)*[:\.@\-\w\u4e00-\u9fa5]+\.([\.a-zA-Z0-9]+|\u4E2D\u56FD|\u7F51\u7EDC|\u516C\u53F8)((\?|\/|:)+[\w\.\/=\?%\-&~`@':+!#]*)*)/ig, mode == 'html' ? '$1<a href="$2" target="_blank">$2</a>' : '$1[url]$2[/url]');
	str = str.replace(/([^\w->=\]:"'\.\/]|^)(([\-\.\w]+@[\.\-\w]+(\.\w+)+))/ig, mode == 'html' ? '$1<a href="mailto:$2">$2</a>' : '$1[email]$2[/email]');
	return str;
}

function getData(tagname) {
	if (typeof tagname == 'undefined' || tagname == '')
	{
		tagname = 'Discuz!';
	}
	var message = '';
	if(is_ie) {
		try {
			textobj.load(tagname);
			var oXMLDoc = textobj.XMLDocument;
			var nodes = oXMLDoc.documentElement.childNodes;
			message = nodes.item(nodes.length - 1).getAttribute('message');
		} catch(e) {}
	} else if(window.sessionStorage) {
		try {
			message = sessionStorage.getItem(tagname);
		} catch(e) {}
	}
	return message.toString();
	
}

function loadData(silent) {
	var message = '';
	message = getData('Discuz!');
	
	if (!silent)
	{	
		if(in_array((message = trim(message)), ['', 'null', 'false', null, false])) {
			alert(lang['post_autosave_none']);
			return;
		}
		if(!confirm(lang['post_autosave_confirm'])) {
			return;
		}
	}

	var formdata = message.split(/\x09\x09/);
	for(var i = 0; i < $('postform').elements.length; i++) {
		var el = $('postform').elements[i];
		if(el.name != '' && (el.tagName == 'TEXTAREA' || el.tagName == 'INPUT' && el.type == 'text')) {
			for(var j = 0; j < formdata.length; j++) {
				var ele = formdata[j].split(/\x09/);
				if(ele[0] == el.name) {
					elvalue = !isUndefined(ele[3]) ? ele[3] : '';
					if(ele[1] == 'INPUT') {
						if(ele[2] == 'text') {
							el.value = elvalue;
						} else if(ele[2] == 'checkbox' || ele[2] == 'radio') {
							el.checked = true;
						}
					} else if(ele[1] == 'TEXTAREA') {
						if(ele[0] == 'message') {
							if(typeof wysiwyg == 'undefined' || !wysiwyg) {
								textobj.value = elvalue;
							} else {
								editdoc.body.innerHTML = bbcode2html(elvalue);
							}
						} else {
							el.value = elvalue;
						}
					}
					break
				}
			}
		}
	}
}

function setData(data, tagname) {
	if (typeof tagname == 'undefined' || tagname == '')
	{
		tagname = 'Discuz!';
	}
	if(is_ie) {
		try {
			var oXMLDoc = textobj.XMLDocument;
			var root = oXMLDoc.firstChild;
			if(root.childNodes.length > 0) {
				root.removeChild(root.firstChild);
			}
			var node = oXMLDoc.createNode(1, 'POST', '');
			var oTimeNow = new Date();
			oTimeNow.setHours(oTimeNow.getHours() + 24);
			textobj.expires = oTimeNow.toUTCString();
			node.setAttribute('message', data);
			oXMLDoc.documentElement.appendChild(node);
			textobj.save(tagname);
		} catch(e) {}
	} else if(window.sessionStorage) {
		try {
			sessionStorage.setItem(tagname, data);
		} catch(e) {}
	}

}

function saveData(data, del) {
	if(!data && typeof del == 'undefined') {
		return;
	}

	if(typeof wysiwyg != 'undefined' && typeof editorid != 'undefined' && typeof bbinsert != 'undefined' && bbinsert && $(editorid + '_mode') && $(editorid + '_mode').value == 1) {
		data = html2bbcode(data);
	}

	var formdata = '';
	for(var i = 0; i < $('postform').elements.length; i++) {
		var el = $('postform').elements[i];
		if(el.name != '' && (el.tagName == 'TEXTAREA' || el.tagName == 'INPUT' && el.type == 'text') && el.name.substr(0, 6) != 'attach') {
			var elvalue = el.name == 'message' ? data : el.value;
			formdata += el.name + String.fromCharCode(9) + el.tagName + String.fromCharCode(9) + el.type + String.fromCharCode(9) + elvalue + String.fromCharCode(9, 9);
		}
	}

	setData(formdata, 'Discuz!');
}

function setCaretAtEnd() {
	var obj = typeof wysiwyg == 'undefined' || !wysiwyg ? $('postform').message : editwin;
	if(typeof wysiwyg != 'undefined' && wysiwyg) {
		if(is_moz || is_opera) {

		} else {
			var sel = editdoc.selection.createRange();
			sel.moveStart('character', strlen(getEditorContents()));
			sel.select();
		}
	} else {
		if(obj.createTextRange)  {
			var sel = obj.createTextRange();
			sel.moveStart('character', strlen(obj.value));
			sel.collapse();
			sel.select();
		}
	}
}

function storeCaret(textEl){
	if(textEl.createTextRange){
		textEl.caretPos = document.selection.createRange().duplicate();
	}
}

if(is_ie >= 5 || is_moz >= 2) {
	window.onbeforeunload = function () {
		try {
			saveData(wysiwyg && bbinsert ? editdoc.body.innerHTML : textobj.value);
		} catch(e) {}
	};
}

function setmediacode(editorid) {
	insertText('[media='+$(editorid + '_mediatype').value+
		','+$(editorid + '_mediawidth').value+
		','+$(editorid + '_mediaheight').value+
		','+$(editorid + '_mediaautostart').value+']'+
		$(editorid + '_mediaurl').value+'[/media]');
	hideMenu();
}

function setmediatype(editorid) {
	var ext = $(editorid + '_mediaurl').value.lastIndexOf('.') == -1 ? '' : $(editorid + '_mediaurl').value.substr($(editorid + '_mediaurl').value.lastIndexOf('.') + 1, $(editorid + '_mediaurl').value.length).toLowerCase();
	if(ext == 'rmvb') {
		ext = 'rm';
	}
	if($(editorid + '_mediatyperadio_' + ext)) {
		$(editorid + '_mediatyperadio_' + ext).checked = true;
		$(editorid + '_mediatype').value = ext;
	}
}

var divdragstart = new Array();
function divdrag(e, op, obj) {
	if(op == 1) {
		divdragstart = is_ie ? [event.clientX, event.clientY] : [e.clientX, e.clientY];
		divdragstart[2] = parseInt(obj.style.left);
		divdragstart[3] = parseInt(obj.style.top);
		doane(e);
	} else if(op == 2 && divdragstart[0]) {
		var divdragnow = is_ie ? [event.clientX, event.clientY] : [e.clientX, e.clientY];
		obj.style.left = (divdragstart[2] + divdragnow[0] - divdragstart[0]) + 'px';
		obj.style.top = (divdragstart[3] + divdragnow[1] - divdragstart[1]) + 'px';
		doane(e);
	} else if(op == 3) {
		divdragstart = [];
		doane(e);
	}
}