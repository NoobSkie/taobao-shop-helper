/*
	[Discuz!] (C)2001-2007 Comsenz Inc.
	This is NOT a freeware, use is subject to license terms

	$RCSfile: editor.js,v $
	$Revision: 1.55 $
	$Date: 2007/07/23 12:34:55 $
*/

var editbox = editwin = editdoc = editcss = null;
var cursor = -1;
var stack = new Array();
var initialized = false;

//newEditor(wysiwyg);

function newEditor(mode, initialtext) {

	wysiwyg = parseInt(mode);
	if(!(is_ie || is_moz || (is_opera >= 9))) {
		allowswitcheditor = wysiwyg = 0;
	}
	var bbcodemode = $('bbcodemode');
	var wysiwygmode = $('wysiwygmode');
	bbcodemode.className = wysiwyg ? 'editor_switcher' : 'editor_switcher_highlight';
	wysiwygmode.className = wysiwyg ? 'editor_switcher_highlight' : 'editor_switcher';
	if(!allowswitcheditor) {
		$(editorid + '_switcher').style.display = 'none';
	}

	$(editorid + '_popup_table').style.display = wysiwyg ? '' : 'none';

	if(wysiwyg) {
		if($(editorid + '_iframe')) {
			editbox = $(editorid + '_iframe');
		} else {
			var iframe = document.createElement('iframe');
			editbox = textobj.parentNode.appendChild(iframe);
			editbox.id = editorid + '_iframe';
		}

		editwin = editbox.contentWindow;
		editdoc = editwin.document;
		writeEditorContents(isUndefined(initialtext) ?  bbcode2html(textobj.value) : initialtext);
	} else {
		editbox = editwin = editdoc = textobj;
		if(!isUndefined(initialtext)) {
			writeEditorContents(initialtext);
		}
		addSnapshot(textobj.value);
	}
	setEditorEvents();
	initEditor();
}

function initEditor() {
	var buttons = $(editorid + '_controls').getElementsByTagName('a');
	for(var i = 0; i < buttons.length; i++) {
		if(buttons[i].id.indexOf(editorid + '_cmd_') != -1) {
			buttons[i].href = '###';
			buttons[i].onclick = function(e) {discuzcode(this.id.substr(this.id.lastIndexOf('_cmd_') + 5))};
		} else if(buttons[i].id.indexOf(editorid + '_popup_') != -1) {
			buttons[i].href = '###';
			buttons[i].onclick = function(e) {showMenu(this.id, true, 0, 3)};
		}
	}
	setUnselectable($(editorid + '_controls'));
	textobj.onselect = textobj.onclick = textobj.onkeyup = function(e) {storeCaret(this)};
	textobj.onkeydown = function(e) {ctlent(e ? e : event)};
	$('bbcodemode').onclick = function() {switchEditor(0)};
	$('wysiwygmode').onclick = function() {switchEditor(1)};
	$(editorid + '_buttonctrl').href = '###';
	$(editorid + '_buttonctrl').onclick = function() {advanceeditor()};
}

function setUnselectable(obj) {
	if(is_ie && is_ie > 4 && typeof obj.tagName != 'undefined') {
		if(obj.hasChildNodes()) {
			for(var i = 0; i < obj.childNodes.length; i++) {
				setUnselectable(obj.childNodes[i]);
			}
		}
		obj.unselectable = 'on';
	}
}

function writeEditorContents(text) {
	if(wysiwyg) {
		if(text == '' && is_moz) {
			text = '<br />';
		}
		if(initialized) {
			editdoc.body.innerHTML = text;
		} else {
			editdoc.designMode = 'on';
			editdoc = editwin.document;
			editdoc.open('text/html', 'replace');
			editdoc.write(text);
			editdoc.close();
			editdoc.body.contentEditable = true;
			initialized = true;
		}
	} else {
		textobj.value = text;
	}

	setEditorStyle();

}

function getEditorContents() {
	return wysiwyg ? editdoc.body.innerHTML : editdoc.value;
}

function setEditorStyle() {
	if(wysiwyg) {
		textobj.style.display = 'none';
		editbox.style.display = '';

		if(editcss == null) {
			editcss = editdoc.createElement('link');
			editcss.type = 'text/css';
			editcss.rel = 'stylesheet';
			editcss.href = editorcss;
			var headNode = editdoc.getElementsByTagName("head")[0];
			headNode.appendChild(editcss);
		}

		if(is_moz || is_opera) {
			editbox.style.border = '0px';
		} else if(is_ie) {
			editdoc.body.style.border = '0px';
			try
			{
				editdoc.body.addBehavior('#default#userData');
			}
			catch (e)
			{
			}
		}
		editbox.style.width = textobj.style.width;
		editbox.style.height = textobj.style.height;
		editdoc.body.style.background = '';
		editdoc.body.style.textAlign = 'left';
		editdoc.body.id = 'wysiwyg';

	} else {
		var iframe = textobj.parentNode.getElementsByTagName('iframe')[0];
		if(iframe) {
			textobj.style.display = '';
			textobj.style.width = iframe.style.width;
			textobj.style.height = iframe.style.height;
			iframe.style.display = 'none';
		}
	}
}

function setEditorEvents() {
	if(wysiwyg) {
		if(is_moz || is_opera) {
			editdoc.addEventListener('mouseup', function(e) {setContext();}, true);
			editdoc.addEventListener('keyup', function(e) {setContext();}, true);
			editwin.addEventListener('focus', function(e) {this.hasfocus = true;}, true);
			editwin.addEventListener('blur', function(e) {this.hasfocus = false;}, true);
			editwin.addEventListener('keydown', function(e) {ctlent(e);}, true);
		} else {
			editdoc.onmouseup = function(e) {setContext();};
			editdoc.onkeyup = function(e) {setContext();};
			if(editdoc.attachEvent) {
				editdoc.body.attachEvent("onkeydown", ctlent);
			}
		}
	}
	editwin.onfocus = function(e) {this.hasfocus = true;};
	editwin.onblur = function(e) {this.hasfocus = false;};
}

function wrapTags(tagname, useoption, selection) {

	if(isUndefined(selection)) {
		var selection = getSel();
		if(selection === false) {
			selection = '';
		} else {
			selection += '';
		}
	}

	var sel;
	if(is_ie) {
		sel = wysiwyg ? editdoc.selection.createRange() : document.selection.createRange();
		var pos = getCaret();
	}

	if(useoption !== false) {
		var opentag = '[' + tagname + '=' + useoption + ']';
	} else {
		var opentag = '[' + tagname + ']';
	}

	var closetag = '[/' + tagname + ']';
	var text = opentag + selection + closetag;
	if(selection == '' && in_array(tagname, ['code', 'quote', 'free', 'hide'])) {
		if(is_ie) {
			var pos = getCaret();
		}
		var ctrlid = editorid + '_cmd_' + tagname;
		var str = lang['post_discuzcode_' + tagname] + ':<br /><textarea id="' + ctrlid + '_content' + '" cols="50" rows="5"></textarea><br />';
		var div = editorMenu(ctrlid, str);
		$(ctrlid + '_content').focus();
		$(ctrlid + '_submit').onclick = function() {
			checkFocus();
			if(is_ie) {
				setCaret(pos);
			}
			selection = wysiwyg ? $(ctrlid + '_content').value.replace(/\r?\n/g, '<br />') : $(ctrlid + '_content').value;
			text = opentag + selection + closetag;
			insertText(text, strlen(opentag), strlen(closetag), false);
			hideMenu();
			document.body.removeChild(div);
		}
		return;
	}

	insertText(text, strlen(opentag), strlen(closetag), in_array(tagname, ['code', 'quote', 'free', 'hide']) ? true : false, sel);

}

function applyFormat(cmd, dialog, argument) {

	if(wysiwyg) {
		editdoc.execCommand(cmd, (isUndefined(dialog) ? false : dialog), (isUndefined(argument) ? true : argument));
		return;
	}
	switch(cmd) {
		case 'bold':
		case 'italic':
		case 'underline':
			wrapTags(cmd.substr(0, 1), false);
			break;
		case 'justifyleft':
		case 'justifycenter':
		case 'justifyright':
			wrapTags('align', cmd.substr(7));
			break;
		case 'floatleft':
		case 'floatright':
			wrapTags('float', cmd.substr(5));
			break;
		case 'indent':
			wrapTags(cmd, false);
			break;
		case 'fontname':
			wrapTags('font', argument);
			break;
		case 'fontsize':
			wrapTags('size', argument);
			break;
		case 'forecolor':
			wrapTags('color', argument);
			break;
		case 'createlink':
			var sel = getSel();
			if(sel) {
				wrapTags('url', argument);
			} else {
				wrapTags('url', argument, argument);
			}
			break;
		case 'insertimage':
			wrapTags('img', false, argument);
			break;
	}
}

function getCaret() {
	
	if(wysiwyg) {
		var obj = editdoc.body;
		
		var s = document.selection.createRange();
		s.setEndPoint("StartToStart", obj.createTextRange());

		return s.text.replace(/\r?\n/g, ' ').length;
	} else {
		var obj = editbox;
		var wR = document.selection.createRange();
		obj.select();
		var aR = document.selection.createRange();
		wR.setEndPoint("StartToStart", aR);
		var len = wR.text.replace(/\r?\n/g, ' ').length;
		wR.collapse(false);
		wR.select();
		return len;
	}
}

function setCaret(pos) {
	var obj = wysiwyg ? editdoc.body : editbox;
	var r = obj.createTextRange();
	r.moveStart('character', pos);
	r.collapse(true);
	r.select();
}

function insertlink(cmd) {
	var sel;
	if(is_ie) {
		sel = wysiwyg ? editdoc.selection.createRange() : document.selection.createRange();
		var pos = getCaret();
	}
	var selection = sel ? (wysiwyg ? sel.htmlText : sel.text) : getSel();
	var ctrlid = editorid + '_cmd_' + cmd;
	var tag = cmd == 'insertimage' ? 'img' : (cmd == 'createlink' ? 'url' : 'email');
	var str = (tag == 'img' ? lang['enter_image_url'] : (tag == 'url' ? lang['enter_link_url'] : lang['enter_email_link'])) + '<br /><input type="text" id="' + ctrlid + '_param_1" size="50" value="">';
	var div = editorMenu(ctrlid, str);
	$(ctrlid + '_param_1').focus();
	$(ctrlid + '_param_1').onkeydown = editorMenuEvent_onkeydown;
	$(ctrlid + '_submit').onclick = function() {
		checkFocus();
		if(is_ie) {
			setCaret(pos);
		}
		var input = $(ctrlid + '_param_1').value;

		if(input != '') {

			var v = selection ? selection : input;

			var href = tag != 'email' && /^(www\.)/.test(input) ? 'http://' + input : input;

			var text = wysiwyg ? (tag == 'img' ? '<img src="' + input + '" border="0">' : '<a href="' + (tag == 'email' ? 'mailto:' : '') + href + '">' + v + '</a>') : (tag == 'img' ? '[' + tag + ']' + input + '[/' + tag + ']' : '[' + tag + '=' + href + ']' + v + '[/' + tag + ']');

			var closetaglen = tag == 'email' ? 8 : 6;

			if(wysiwyg) insertText(text, text.length - v.length, 0, (selection ? true : false), sel);

			else insertText(text, text.length - v.length - closetaglen, closetaglen, (selection ? true : false), sel);

		}
		hideMenu();
		document.body.removeChild(div);
	}
}

function editorMenuEvent_onkeydown(e) {

	e = e ? e : event;

	var ctrlid = this.id.substr(0, this.id.lastIndexOf('_param_'));

	if((this.type == 'text' && e.keyCode == 13) || (this.type == 'textarea' && e.ctrlKey && e.keyCode == 13)) {

		$(ctrlid + '_submit').click();

		doane(e);

	} else if(e.keyCode == 27) {

		hideMenu();

		document.body.removeChild($(ctrlid + '_menu'));

	}

}

function customTags(tagname, params) {
	var sel;

	if(is_ie) {

		sel = wysiwyg ? editdoc.selection.createRange() : document.selection.createRange();

		var pos = getCaret();

	}
	var selection = sel ? (wysiwyg ? sel.htmlText : sel.text) : getSel();
	var opentag = '[' + tagname + ']';
	var closetag = '[/' + tagname + ']';
	var haveSel = selection == null || selection == false || in_array(trim(selection), ['', 'null', 'undefined', 'false']) ? 0 : 1;
	if(params == 1 && haveSel) {
		return insertText((opentag + selection + closetag), strlen(opentag), strlen(closetag), true, sel);
	}
	var ctrlid = editorid + '_cmd_custom' + params + '_' + tagname;
	var ordinal = {1 : 'first', 2 : 'second', 3 : 'third'}
	//var promptlang = custombbcodes[tagname]['prompt'].split("\t");
	var promptlang;
	try
	{
		promptlang = custombbcodes[tagname][3];
	}
	catch (e)
	{
		promptlang = custombbcodes[tagname]['prompt'].split("\t");
	}

	var str = '';
	for(var i = 1; i <= params; i++) {
		if(i != 1 || !haveSel) {
			str += '<br />' + (promptlang[i - 1] ? promptlang[i - 1] : 'Please input the ' + ordinal[i] + ' parameter:') + '<br /><input type="text" id="' + ctrlid + '_param_' + i + '" size="50" value=""><br />';
		}
	}
	var div = editorMenu(ctrlid, str);
	if($(ctrlid + '_param_1')) {
		try{
		$(ctrlid + '_param_1').focus();
		}catch (e){}
	}
	for(var i = 1; i <= params; i++) {if(i != 1 || !haveSel) $(ctrlid + '_param_' + i).onkeydown = editorMenuEvent_onkeydown;}
	$(ctrlid + '_submit').onclick = function() {
		if($(ctrlid + '_param_1')) 
			var first = $(ctrlid + '_param_1').value;
		else
			var first = selection;
		if($(ctrlid + '_param_2')) 
			var second = $(ctrlid + '_param_2').value;
		if($(ctrlid + '_param_3')) 
			var third = $(ctrlid + '_param_3').value;
		checkFocus();
		if(is_ie) {
			setCaret(pos);
		}
		if((params == 1 && first) || (params == 2 && first && (haveSel || second)) || (params == 3 && first && second && (haveSel || third))) {
			var text;
			if(params == 1) {
				text = first;
			} else if(params == 2) {
				//text = haveSel ? selection : second;
				text = haveSel ? selection : first;
				//opentag = '[' + tagname + '=' + first + ']';
				opentag = '[' + tagname + '=' + second + ']';
			} else {
				//text = haveSel ? selection : third;
				//opentag = '[' + tagname + '=' + first + ',' + second + ']';
				text = haveSel ? selection : first;
				opentag = '[' + tagname + '=' + second + ',' + third + ']';
			}
			insertText((opentag + text + closetag), strlen(opentag), strlen(closetag), true, sel);
		}
		hideMenu();
		div.parentNode.removeChild(div);
	};
}

function editorMenu(ctrlid, str) {
	var div = document.createElement('div');
	div.id = ctrlid + '_menu';
	div.style.display = 'none';
	div.className = 'popupmenu_popup';
	document.body.appendChild(div);
	div.innerHTML = '<div class="popupmenu_option" unselectable="on">' + str + '<br /><center><input type="button" id="' + ctrlid + '_submit" value="' + lang['submit'] + '" /> &nbsp; <input type="button" onClick="hideMenu();try{$(\'' + div.id + '\').parentNode.removeChild($(\'' + div.id + '\'))}catch(e){}" value="' + lang['cancel'] + '" /></center><br /></div>';
	showMenu(ctrlid, true, 0, 3);
	return div;
}

function discuzcode(cmd, arg) {
	if(cmd != 'redo') {
		addSnapshot(getEditorContents());
	}

	checkFocus();
	if(in_array(cmd, ['quote', 'code', 'free', 'hide'])) {
		var ret = wrapTags(cmd, false);
	} else if(cmd.substr(0, 6) == 'custom') {
		var ret = customTags(cmd.substr(8), cmd.substr(6, 1));
	} else if(!wysiwyg && cmd == 'removeformat') {
		var simplestrip = new Array('b', 'i', 'u');
		var complexstrip = new Array('font', 'color', 'size');

		var str = getSel();
		if(str === false) {
			return;
		}
		for(var tag in simplestrip) {
			str = stripSimple(simplestrip[tag], str);
		}
		for(var tag in complexstrip) {
			str = stripComplex(complexstrip[tag], str);
		}
		insertText(str);
	} else if(!wysiwyg && cmd == 'undo') {
		addSnapshot(getEditorContents());
		moveCursor(-1);
		if((str = getSnapshot()) !== false) {
			editdoc.value = str;
		}
	} else if(!wysiwyg && cmd == 'redo') {
		moveCursor(1);
		if((str = getSnapshot()) !== false) {
			editdoc.value = str;
		}
	} else if(!wysiwyg && in_array(cmd, ['insertorderedlist', 'insertunorderedlist'])) {
		var listtype = cmd == 'insertorderedlist' ? '1' : '';
		var opentag = '[list' + (listtype ? ('=' + listtype) : '') + ']\n';
		var closetag = '[/list]';

		if(txt = getSel()) {
			var regex = new RegExp('([\r\n]+|^[\r\n]*)(?!\\[\\*\\]|\\[\\/?list)(?=[^\r\n])', 'gi');
			txt = opentag + trim(txt).replace(regex, '$1[*]') + '\n' + closetag;
			insertText(txt, strlen(txt), 0);
		} else {
			insertText(opentag + closetag, opentag.length, closetag.length);

			while(listvalue = prompt(lang['enter_list_item'], '')) {
				if(is_opera > 8) {
					listvalue = '\n' + '[*]' + listvalue;
					insertText(listvalue, strlen(listvalue) + 1, 0);
				} else {
					listvalue = '[*]' + listvalue + '\n';
					insertText(listvalue, strlen(listvalue), 0);
				}
			}
		}
	} else if(!wysiwyg && cmd == 'outdent') {
		var sel = getSel();
		sel = stripSimple('indent', sel, 1);
		insertText(sel);
	} else if(cmd == 'createlink') {
		insertlink('createlink');
	} else if(!wysiwyg && cmd == 'unlink') {
		var sel = getSel();
		sel = stripSimple('url', sel);
		sel = stripComplex('url', sel);
		insertText(sel);
	} else if(cmd == 'email') {
		insertlink('email');
	} else if(cmd == 'insertimage') {
		insertlink('insertimage');
	} else if(cmd == 'table') {
		if(wysiwyg) {
			var rows = $(editorid + '_table_rows').value;
			var columns = $(editorid + '_table_columns').value;
			var width = $(editorid + '_table_width').value;
			var bgcolor = $(editorid + '_table_bgcolor').value;
			rows = /^[-\+]?\d+$/.test(rows) && rows > 0 && rows <= 30 ? rows : 2;
			columns = /^[-\+]?\d+$/.test(columns) && columns > 0 && columns <= 30 ? columns : 2;
			width = width.substr(width.length - 1, width.length) == '%' ? (width.substr(0, width.length - 1) <= 98 ? width : '98%') : (width <= 560 ? width : '98%');
			bgcolor = /[\(\)%,#\w]+/.test(bgcolor) ? bgcolor : '';
			var html = '<table cellspacing="0" cellpadding="0" width="' + (width ? width : '50%') + '" class="t_table"' + (bgcolor ? ' bgcolor="' + bgcolor + '"' : '') + '>';
			for (var row = 0; row < rows; row++) {
				html += '<tr>\n';
				for (col = 0; col < columns; col++) {
					html += '<td>&nbsp;</td>\n';
				}
				html+= '</tr>\n';
			}
			html += '</table>\n';
			insertText(html);
			hideMenu();
		}
		return false;
	} else if(cmd == 'floatleft' || cmd == 'floatright') {
		if(wysiwyg) {
			var selection = getSel();
			if(selection) {
				insertText('<br style="clear: both"><span style="float: ' + cmd.substr(5) + '">' + selection + '</span>', true);
			}
		} else {
			return applyFormat(cmd, false);
		}
	} else {
		try {
			var ret = applyFormat(cmd, false, (isUndefined(arg) ? true : arg));
		} catch(e) {
			var ret = false;
		}
	}

	if(cmd != 'undo') {
		addSnapshot(getEditorContents());
	}
	if(wysiwyg) {
		setContext(cmd);
		if(cmd == 'forecolor') {
			$(editorid + '_color_bar').style.backgroundColor = arg;
		}
	}
	//checkFocus();
	return ret;
}

function setContext(cmd) {
	var contextcontrols = new Array('bold', 'italic', 'underline', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist', 'insertunorderedlist');
	for(var i in contextcontrols) {
		var obj = $(editorid + '_cmd_' + contextcontrols[i]);
		if(obj != null) {
			try {
				var state = editdoc.queryCommandState(contextcontrols[i]);
			} catch(e) {
				var state = false;
			}
			if(isUndefined(obj.state)) {
				obj.state = false;
			}
			if(obj.state != state) {
				obj.state = state;
				buttonContext(obj, (obj.id.substr(obj.id.indexOf('_cmd_') + 5) == cmd ? 'mouseover' : 'mouseout'));
			}
		}
	}
    try{
	    var fs = editdoc.queryCommandValue('fontname');
	    if(fs == '' && !is_ie && window.getComputedStyle) {
		    fs = editdoc.body.style.fontFamily;
	    } else if(fs == null) {
		    fs = '';
	    }
	    if(fs != $(editorid + '_font_out').fontstate) {
		    thingy = fs.indexOf(',') > 0 ? fs.substr(0, fs.indexOf(',')) : fs;
		    $(editorid + '_font_out').innerHTML = thingy;
		    $(editorid + '_font_out').fontstate = fs;
	    }

	    var ss = editdoc.queryCommandValue('fontsize');
	    if(ss == null || ss == '') {
		    ss = formatFontsize(editdoc.body.style.fontSize);
	    }
	    if(ss != $(editorid + '_size_out').sizestate) {
		    if($(editorid + '_size_out').sizestate == null) {
			    $(editorid + '_size_out').sizestate = '';
		    }
		    $(editorid + '_size_out').innerHTML = ss;
		    $(editorid + '_size_out').sizestate = ss;
	    }
    
	    var cs = editdoc.queryCommandValue('forecolor');
	    $(editorid + '_color_bar').style.backgroundColor = rgbToColor(cs);
    }
    catch(firefox3bug){
    }
}

function buttonContext(obj, state) {
	if(state == 'mouseover') {
		obj.style.cursor = 'pointer';
		var mode = obj.state ? 'down' : 'hover';
		if(obj.mode != mode) {
			obj.mode = mode;
			obj.className = 'hover';
		}
	} else {
		var mode = obj.state ? 'selected' : 'normal';
		if(obj.mode != mode) {
			obj.mode = mode;
			obj.className = mode == 'selected' ? 'hover' : '';
		}
	}
}

function menuContext(obj, state) {
	obj.style.cursor = 'pointer';
	var mode = state == 'mouseover' ? 'hover' : 'normal';
	obj.className = 'editor_button' + mode;
	var tds = obj.getElementsByTagName('td');
	for(var i = 0; i < tds.length; i++) {
		if(tds[i].id.substr(0, tds[i].id.lastIndexOf('_')) == editorid + '_menu') {
			tds[i].className = 'editor_menu' + mode;
		} else if(tds[i].id == editorid + '_colormenu') {
			tds[i].className = 'editor_colormenu' + mode;
		}
	}
}

function colorContext(obj, state) {
	obj.style.cursor = 'pointer';
	var mode = state == 'mouseover' ? 'hover' : 'normal';
	obj.className = 'editor_color' + mode;
}

function getSel() {
	if(wysiwyg) {
		if(is_moz || is_opera) {
			selection = editwin.getSelection();
			checkFocus();
			range = selection ? selection.getRangeAt(0) : editdoc.createRange();
			return readNodes(range.cloneContents(), false);
		} else {
			var range = editdoc.selection.createRange();
			if(range.htmlText && range.text) {
				return range.htmlText;
			} else {
				var htmltext = '';
				for(var i = 0; i < range.length; i++) {
					htmltext += range.item(i).outerHTML;
				}
				return htmltext;
			}
		}
	} else {
		if(!isUndefined(editdoc.selectionStart)) {
			return editdoc.value.substr(editdoc.selectionStart, editdoc.selectionEnd - editdoc.selectionStart);
		} else if(document.selection && document.selection.createRange) {
			return document.selection.createRange().text;
		} else if(window.getSelection) {
			return window.getSelection() + '';
		} else {
			return false;
		}
	}
}

function insertText(text, movestart, moveend, select, sel) {
	if(wysiwyg) {
		if(is_moz || is_opera) {
			applyFormat('removeformat');
			var fragment = editdoc.createDocumentFragment();
			var holder = editdoc.createElement('span');
			holder.innerHTML = text;

			while(holder.firstChild) {
				fragment.appendChild(holder.firstChild);
			}
			insertNodeAtSelection(fragment);
		} else {
			checkFocus();
			if(!isUndefined(editdoc.selection) && editdoc.selection.type != 'Text' && editdoc.selection.type != 'None') {
				movestart = false;
				editdoc.selection.clear();
			}

			if(isUndefined(sel)) {
				sel = document.selection.createRange();
			}

			sel.pasteHTML(text);

			if(text.indexOf('\n') == -1) {
				if(!isUndefined(movestart)) {
					sel.moveStart('character', -strlen(text) + movestart);
					sel.moveEnd('character', -moveend);
				} else if(movestart != false) {
					sel.moveStart('character', -strlen(text));
				}
				if(!isUndefined(select) && select) {
					sel.select();
				}
			}
		}
	} else {
		checkFocus();
		if(!isUndefined(editdoc.selectionStart)) {
			var opn = editdoc.selectionStart + 0;
			editdoc.value = editdoc.value.substr(0, editdoc.selectionStart) + text + editdoc.value.substr(editdoc.selectionEnd);

			if(!isUndefined(movestart)) {
				editdoc.selectionStart = opn + movestart;
				editdoc.selectionEnd = opn + strlen(text) - moveend;
			} else if(movestart !== false) {
				editdoc.selectionStart = opn;
				editdoc.selectionEnd = opn + strlen(text);
			}
		} else if(document.selection && document.selection.createRange) {
			if(isUndefined(sel)) {
				sel = document.selection.createRange();
			}
			sel.text = text.replace(/\r?\n/g, '\r\n');
			if(!isUndefined(movestart)) {
				sel.moveStart('character', -strlen(text) +movestart);
				sel.moveEnd('character', -moveend);
			} else if(movestart !== false) {
				sel.moveStart('character', -strlen(text));
			}
			sel.select();
		} else {
			editdoc.value += text;
		}
	}
}

function stripSimple(tag, str, iterations) {
	var opentag = '[' + tag + ']';
	var closetag = '[/' + tag + ']';

	if(isUndefined(iterations)) {
		iterations = -1;
	}
	while((startindex = stripos(str, opentag)) !== false && iterations != 0) {
		iterations --;
		if((stopindex = stripos(str, closetag)) !== false) {
			var text = str.substr(startindex + opentag.length, stopindex - startindex - opentag.length);
			str = str.substr(0, startindex) + text + str.substr(stopindex + closetag.length);
		} else {
			break;
		}
	}
	return str;
}

function stripComplex(tag, str, iterations) {
	var opentag = '[' + tag + '=';
	var closetag = '[/' + tag + ']';

	if(isUndefined(iterations)) {
		iterations = -1;
	}
	while((startindex = stripos(str, opentag)) !== false && iterations != 0) {
		iterations --;
		if((stopindex = stripos(str, closetag)) !== false) {
			var openend = stripos(str, ']', startindex);
			if(openend !== false && openend > startindex && openend < stopindex) {
				var text = str.substr(openend + 1, stopindex - openend - 1);
				str = str.substr(0, startindex) + text + str.substr(stopindex + closetag.length);
			} else {
				break;
			}
		} else {
			break;
		}
	}
	return str;
}

function stripos(haystack, needle, offset) {
	if(isUndefined(offset)) {
		offset = 0;
	}
	var index = haystack.toLowerCase().indexOf(needle.toLowerCase(), offset);

	return (index == -1 ? false : index);
}

function switchEditor(mode) {

	mode = parseInt(mode);
	if(mode == wysiwyg || !allowswitcheditor)  {
		return;
	}
	if(!mode) {
		var controlbar = $(editorid + '_controls');
		var controls = new Array();
		var buttons = controlbar.getElementsByTagName('a');
		var buttonslength = buttons.length;
		for(var i = 0; i < buttonslength; i++) {
			if(buttons[i].id) {
				controls[controls.length] = buttons[i].id;
			}
		}
		var controlslength = controls.length;
		for(var i = 0; i < controlslength; i++) {
			var control = $(controls[i]);

			if(control.id.indexOf(editorid + '_cmd_') != -1) {
				control.className = '';
				control.state = false;
				control.mode = 'normal';
			} else if(control.id.indexOf(editorid + '_popup_') != -1) {
				control.state = false;
			}
		}
	}
	cursor = -1;
	stack = new Array();
	$(editorid + '_font_out').innerHTML = lang['fontname'];
	$(editorid + '_size_out').innerHTML = lang['fontsize'];
	$(editorid + '_font_out').fontstate = null;
	$(editorid + '_size_out').sizestate = null;
	$(editorid + '_color_bar').style.backgroundColor = '#000000';
	var parsedtext = getEditorContents();
	parsedtext = mode ? bbcode2html(parsedtext) : html2bbcode(parsedtext);
	wysiwyg = mode;
	$(editorid + '_mode').value = mode;

	newEditor(mode, parsedtext);
	checkFocus();
	setCaretAtEnd();
}

function formatFontsize(csssize) {
	switch(csssize) {
		case '7.5pt':
		case '10px': return 1;
		case '10pt': return 2;
		case '12pt': return 3;
		case '14pt': return 4;
		case '18pt': return 5;
		case '24pt': return 6;
		case '36pt': return 7;
		default:     return lang['fontsize'];
	}
}

function rgbToColor(forecolor) {
	if(!is_moz && !is_opera) {
		return rgbhexToColor((forecolor & 0xFF).toString(16), ((forecolor >> 8) & 0xFF).toString(16), ((forecolor >> 16) & 0xFF).toString(16));
	}
	if(forecolor == '' || forecolor == null) {
		forecolor = window.getComputedStyle(editdoc.body, null).getPropertyValue('color');
	}
	if(forecolor.toLowerCase().indexOf('rgb') == 0) {
		var matches = forecolor.match(/^rgb\s*\(([0-9]+),\s*([0-9]+),\s*([0-9]+)\)$/);
		if(matches) {
			return rgbhexToColor((matches[1] & 0xFF).toString(16), (matches[2] & 0xFF).toString(16), (matches[3] & 0xFF).toString(16));
		} else {
			return rgbToColor(null);
		}
	} else {
		return forecolor;
	}
}

function rgbhexToColor(r, g, b) {
	var coloroptions = {'#000000' : 'Black', '#a0522d' : 'Sienna', '#556b2f' : 'DarkOliveGreen', '#006400' : 'DarkGreen', '#483d8b' : 'DarkSlateBlue', '#000080' : 'Navy', '#4b0082' : 'Indigo', '#2f4f4f' : 'DarkSlateGray', '#8b0000' : 'DarkRed', '#ff8c00' : 'DarkOrange', '#808000' : 'Olive', '#008000' : 'Green', '#008080' : 'Teal', '#0000ff' : 'Blue', '#708090' : 'SlateGray', '#696969' : 'DimGray', '#ff0000' : 'Red', '#f4a460' : 'SandyBrown', '#9acd32' : 'YellowGreen', '#2e8b57' : 'SeaGreen', '#48d1cc' : 'MediumTurquoise', '#4169e1' : 'RoyalBlue', '#800080' : 'Purple', '#808080' : 'Gray', '#ff00ff' : 'Magenta', '#ffa500' : 'Orange', '#ffff00' : 'Yellow', '#00ff00' : 'Lime', '#00ffff' : 'Cyan', '#00bfff' : 'DeepSkyBlue', '#9932cc' : 'DarkOrchid', '#c0c0c0' : 'Silver', '#ffc0cb' : 'Pink', '#f5deb3' : 'Wheat', '#fffacd' : 'LemonChiffon', '#98fb98' : 'PaleGreen', '#afeeee' : 'PaleTurquoise', '#add8e6' : 'LightBlue', '#dda0dd' : 'Plum', '#ffffff' : 'White'};
	return coloroptions['#' + (str_pad(r, 2, 0) + str_pad(g, 2, 0) + str_pad(b, 2, 0))];
}

function str_pad(text, length, padstring) {
	text += '';
	padstring += '';

	if(text.length < length) {
		padtext = padstring;

		while(padtext.length < (length - text.length)) {
			padtext += padstring;
		}

		text = padtext.substr(0, (length - text.length)) + text;
	}

	return text;
}

function insertNodeAtSelection(text) {
	checkFocus();

	var sel = editwin.getSelection();
	var range = sel ? sel.getRangeAt(0) : editdoc.createRange();
	sel.removeAllRanges();
	range.deleteContents();

	var node = range.startContainer;
	var pos = range.startOffset;

	switch(node.nodeType) {
		case Node.ELEMENT_NODE:
			if(text.nodeType == Node.DOCUMENT_FRAGMENT_NODE) {
				selNode = text.firstChild;
			} else {
				selNode = text;
			}
			node.insertBefore(text, node.childNodes[pos]);
			add_range(selNode);
			break;

		case Node.TEXT_NODE:
			if(text.nodeType == Node.TEXT_NODE) {
				var text_length = pos + text.length;
				node.insertData(pos, text.data);
				range = editdoc.createRange();
				range.setEnd(node, text_length);
				range.setStart(node, text_length);
				sel.addRange(range);
			} else {
				node = node.splitText(pos);
				var selNode;
				if(text.nodeType == Node.DOCUMENT_FRAGMENT_NODE) {
					selNode = text.firstChild;
				} else {
					selNode = text;
				}
				node.parentNode.insertBefore(text, node);
				add_range(selNode);
			}
			break;
	}
}

function add_range(node) {
	checkFocus();
	var sel = editwin.getSelection();
	var range = editdoc.createRange();
	range.selectNodeContents(node);
	sel.removeAllRanges();
	sel.addRange(range);
}

function readNodes(root, toptag) {
	var html = "";
	var moz_check = /_moz/i;

	switch(root.nodeType) {
		case Node.ELEMENT_NODE:
		case Node.DOCUMENT_FRAGMENT_NODE:
			var closed;
			if(toptag) {
				closed = !root.hasChildNodes();
				html = '<' + root.tagName.toLowerCase();
				var attr = root.attributes;
				for(var i = 0; i < attr.length; ++i) {
					var a = attr.item(i);
					if(!a.specified || a.name.match(moz_check) || a.value.match(moz_check)) {
						continue;
					}
					html += " " + a.name.toLowerCase() + '="' + a.value + '"';
				}
				html += closed ? " />" : ">";
			}
			for(var i = root.firstChild; i; i = i.nextSibling) {
				html += readNodes(i, true);
			}
			if(toptag && !closed) {
				html += "</" + root.tagName.toLowerCase() + ">";
			}
			break;

		case Node.TEXT_NODE:
			html = htmlspecialchars(root.data);
			break;
	}
	return html;
}

function moveCursor(increment) {
	var test = cursor + increment;
	if(test >= 0 && stack[test] != null && !isUndefined(stack[test])) {
		cursor += increment;
	}
}

function addSnapshot(str) {
	if(stack[cursor] == str) {
		return;
	} else {
		cursor++;
		stack[cursor] = str;

		if(!isUndefined(stack[cursor + 1])) {
			stack[cursor + 1] = null;
		}
	}
}

function getSnapshot() {
	if(!isUndefined(stack[cursor]) && stack[cursor] != null) {
		return stack[cursor];
	} else {
		return false;
	}
}

function advanceeditor() {
	if($(editorid + '_morebuttons').style.display == '') {
		$(editorid + '_morebuttons').style.display = 'none';
		$(editorid + '_left').style.display = 'none';
		$(editorid + '_bottom').style.display = 'none';
		$(editorid + '_buttonctrl').innerHTML = lang['post_advanceeditor'];
	} else {
		$(editorid + '_morebuttons').style.display = '';
		$(editorid + '_left').style.display = '';
		$(editorid + '_bottom').style.display = '';
		$(editorid + '_buttonctrl').innerHTML = lang['post_simpleeditor'];
	}
}
