/*
	[Discuz!] (C)2001-2007 Comsenz Inc.
	This is NOT a freeware, use is subject to license terms

	$RCSfile: bbcode.js,v $
	$Revision: 1.54 $
	$Date: 2007/07/02 13:49:27 $
*/

var is_mac = userAgent.indexOf('mac') != -1;

var re;
var pcodecount = '-1';
var codecount = 0;
var codehtml = new Array();

/* Used for Discuz!NT */
function ParseSmilies(){
	if (!smilies.length){
		return;
	}
	for (var i = 0; i < smilies.length; i++){
		if (smilies[i][0]==arguments[1]){
			return smilies[i][1];
		}
	}
	return arguments[0];
}
/* end */
function addslashes(str) {
	return preg_replace(['\\\\', '\\\'', '\\\/', '\\\(', '\\\)', '\\\[', '\\\]', '\\\{', '\\\}', '\\\^', '\\\$', '\\\?', '\\\.', '\\\*', '\\\+', '\\\|'], ['\\\\', '\\\'', '\\/', '\\(', '\\)', '\\[', '\\]', '\\{', '\\}', '\\^', '\\$', '\\?', '\\.', '\\*', '\\+', '\\|'], str);
}

function atag(aoptions, text) {
	if(trim(text) == '') {
		return '';
	}

	href = getoptionvalue('href', aoptions);

	if(href.substr(0, 11) == 'javascript:') {
		return trim(recursion('a', text, 'atag'));
	} else if(href.substr(0, 7) == 'mailto:') {
		tag = 'email';
		href = href.substr(7);
	} else {
		tag = 'url';
	}

	return '[' + tag + '=' + href + ']' + trim(recursion('a', text, 'atag')) + '[/' + tag + ']';
}

function bbcode2html(str) {

	str = trim(str);

	if(str == '') {
		return '';
	}

	if(!fetchCheckbox('bbcodeoff') && allowbbcode) {
		str= str.replace(/\s*\[code\]([\s\S]+?)\[\/code\]\s*/ig, function($1, $2) {return parsecode($2);});
	}

	if(!forumallowhtml && !(allowhtml && fetchCheckbox('htmlon'))) {
		str = str.replace(/</g, '&lt;');
		str = str.replace(/>/g, '&gt;');
		if(!fetchCheckbox('parseurloff')) {
			str = parseurl(str, 'html');
		}
	}

/* Discuz!NT  start */

	/*if(!fetchCheckbox('smileyoff') && allowsmilies) {
		for(id in smilies) {
			re = new RegExp(addslashes(smilies[id]['code']), "g");
			str = str.replace(re, '<img src="./images/smilies/' + smilies[id]['url'] + '" border="0" smilieid="' + id + '" alt="' + smilies[id]['code'] + '" />');
		}
	}*/
	if(!fetchCheckbox('smileyoff') && allowsmilies) {
		for(i in smilies_HASH) {
			for(id in smilies_HASH[i]) {
				re = new RegExp(addslashes(smilies_HASH[i][id]['code']), "g");
				str = str.replace(re, '<img src="editor/images/smilies/' + smilies_HASH[i][id]['url'] + '" border="0" smiliecode="' + smilies_HASH[i][id]['code'] + '" alt="" />');
			}
		}
	}
/* Discuz!NT  end */

	if(!fetchCheckbox('bbcodeoff') && allowbbcode) {
		str= str.replace(/\[url\]\s*(www.|https?:\/\/|ftp:\/\/|gopher:\/\/|news:\/\/|telnet:\/\/|rtsp:\/\/|mms:\/\/|callto:\/\/|bctp:\/\/|ed2k:\/\/){1}([^\[\"']+?)\s*\[\/url\]/ig, function($1, $2, $3) {return cuturl($2 + $3);});
		str= str.replace(/\[url=www.([^\[\"']+?)\](.+?)\[\/url\]/ig, '<a href="http://www.$1" target="_blank">$2</a>');
		str= str.replace(/\[url=(https?|ftp|gopher|news|telnet|rtsp|mms|callto|bctp|ed2k){1}:\/\/([^\[\"']+?)\]([\s\S]+?)\[\/url\]/ig, '<a href="$1://$2" target="_blank">$3</a>');
		str= str.replace(/\[email\](.*?)\[\/email\]/ig, '<a href="mailto:$1">$1</a>');
		str= str.replace(/\[email=(.[^\[]*)\](.*?)\[\/email\]/ig, '<a href="mailto:$1" target="_blank">$2</a>');
		str = str.replace(/\[color=([^\[\<]+?)\]/ig, '<font color="$1">');
		str = str.replace(/\[size=(\d+?)\]/ig, '<font size="$1">');
		str = str.replace(/\[size=(\d+(\.\d+)?(px|pt|in|cm|mm|pc|em|ex|%)+?)\]/ig, '<font style="font-size: $1">');
		str = str.replace(/\[font=([^\[\<]+?)\]/ig, '<font face="$1">');
		str = str.replace(/\[align=([^\[\<]+?)\]/ig, '<p align="$1">');
		str = str.replace(/\[float=([^\[\<]+?)\]/ig, '<br style="clear: both"><span style="float: $1;">');

		re = /\[table(?:=(\d{1,4}%?)(?:,([\(\)%,#\w ]+))?)?\]\s*([\s\S]+?)\s*\[\/table\]/ig;
		for (i = 0; i < 4; i++) {
			str = str.replace(re, function($1, $2, $3, $4) {return parsetable($2, $3, $4);});
		}

		str = preg_replace([
			'\\\[\\\/color\\\]', '\\\[\\\/size\\\]', '\\\[\\\/font\\\]', '\\\[\\\/align\\\]', '\\\[b\\\]', '\\\[\\\/b\\\]',
			'\\\[i\\\]', '\\\[\\\/i\\\]', '\\\[u\\\]', '\\\[\\\/u\\\]', '\\\[list\\\]', '\\\[list=1\\\]', '\\\[list=a\\\]',
			'\\\[list=A\\\]', '\\\[\\\*\\\]', '\\\[\\\/list\\\]', '\\\[indent\\\]', '\\\[\\\/indent\\\]', '\\\[\\\/float\\\]'
			], [
			'</font>', '</font>', '</font>', '</p>', '<b>', '</b>', '<i>',
			'</i>', '<u>', '</u>', '<ul>', '<ul type=1>', '<ul type=a>',
			'<ul type=A>', '<li>', '</ul>', '<blockquote>', '</blockquote>', '</span>'
			], str);
	}

	if(!fetchCheckbox('bbcodeoff')) {
		if(allowimgcode) {
			str = str.replace(/\[localimg=(\d{1,4}),(\d{1,4})\](\d+)\[\/localimg\]/ig, function ($1, $2, $3, $4) {if($('attach_' + $4)) {var src = $('attach_' + $4).value; if(src != '') return '<img style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=\'scale\',src=\'' + src + '\');width:' + $2 + ';height=' + $3 + '" src=\'images/common/none.gif\' border="0" aid="attach_' + $4 + '" alt="" />';}});
			str = str.replace(/\[img\]\s*([^\[\<\r\n]+?)\s*\[\/img\]/ig, '<img src="$1" border="0" alt="" />');
			//str = str.replace(/\[attachimg\](\d+)\[\/attachimg\]/ig, function ($1, $2) {eval('var attachimg = $(\'preview_' + $2 + '\')');return '<img src="' + attachimg.src + '" border="0" aid="attachimg_' + $2 + '" width="' + attachimg.clientWidth + '" alt="" />';});
			str = str.replace(/\[attachimg\](\d+)\[\/attachimg\]/ig, '<img src="attachment.aspx?attachmentid=$1" border="0" aid="attachimg_$1" alt="" />');

			str = str.replace(/\[img=(\d{1,4})[x|\,](\d{1,4})\]\s*([^\[\<\r\n]+?)\s*\[\/img\]/ig, '<img width="$1" height="$2" src="$3" border="0" alt="" />');
		} else {
			str = str.replace(/\[img\]\s*([^\[\<\r\n]+?)\s*\[\/img\]/ig, '<a href="$1" target="_blank">$1</a>');
			str = str.replace(/\[img=(\d{1,4})[x|\,](\d{1,4})\]\s*([^\[\<\r\n]+?)\s*\[\/img\]/ig, '<a href="$1" target="_blank">$1</a>');
		}
	}

	for(var i = 0; i <= pcodecount; i++) {
		str = str.replace("[\tDISCUZ_CODE_" + i + "\t]", codehtml[i]);
	}

	if(!forumallowhtml && !(allowhtml && fetchCheckbox('htmlon'))) {
		str = preg_replace(['\t', '   ', '  ', '(\r\n|\n|\r)'], ['&nbsp; &nbsp; &nbsp; &nbsp; ', '&nbsp; &nbsp;', '&nbsp;&nbsp;', '<br />'], str);
	}

	return str;
}

function codetag(text) {
	pcodecount++;
	text = text.replace(/<br[^\>]*>/ig, '\n');
	text = text.replace(/^[\n\r]*([\s\S]+?)[\n\r]*$/ig, '$1');
	text = text.replace(/<(\/|)[A-Za-z].*?>/ig, '');
	codehtml[pcodecount] = '[code]' + text + '[/code]';
	codecount++;
	return '[\tDISCUZ_CODE_' + pcodecount + '\t]';
}

function cuturl(url) {
	var length = 65;
	var urllink = '<a href="' + (url.toLowerCase().substr(0, 4) == 'www.' ? 'http://' + url : url) + '" target="_blank">';
	if(url.length > length) {
		url = url.substr(0, parseInt(length * 0.5)) + ' ... ' + url.substr(url.length - parseInt(length * 0.3));
	}
	urllink += url + '</a>';
	return urllink;
}

function dpstag(options, text, tagname) {
	if(trim(text) == '') {
		return '\n';
	}
	var pend = parsestyle(options, '', '');
	var prepend = pend['prepend'];
	var append = pend['append'];
	if(in_array(tagname, ['div', 'p'])) {
		align = getoptionvalue('align', options);
		if(in_array(align, ['left', 'center', 'right'])) {
			prepend = '[align=' + align + ']' + prepend;
			append += '[/align]';
		} else {
			append += '\n';
		}
	}
	return prepend + recursion(tagname, text, 'dpstag') + append;
}

function fetchoptionvalue(option, text) {
	if((position = strpos(text, option)) !== false) {
		delimiter = position + option.length;
		if(text.charAt(delimiter) == '"') {
			delimchar = '"';
		} else if(text.charAt(delimiter) == '\'') {
			delimchar = '\'';
		} else {
			delimchar = ' ';
		}
		delimloc = strpos(text, delimchar, delimiter + 1);
		if(delimloc === false) {
			delimloc = text.length;
		} else if(delimchar == '"' || delimchar == '\'') {
			delimiter++;
		}
		return trim(text.substr(delimiter, delimloc - delimiter));
	} else {
		return '';
	}
}

function fonttag(fontoptions, text) {
	var prepend = '';
	var append = '';
	var tags = new Array();
	tags = {'font' : 'face=', 'size' : 'size=', 'color' : 'color='};
	for(bbcode in tags) {
		optionvalue = fetchoptionvalue(tags[bbcode], fontoptions);
		if(optionvalue) {
			prepend += '[' + bbcode + '=' + optionvalue + ']';
			append = '[/' + bbcode + ']' + append;
		}
	}

	var pend = parsestyle(fontoptions, prepend, append);
	return pend['prepend'] + recursion('font', text, 'fonttag') + pend['append'];
}

function getoptionvalue(option, text) {
	re = new RegExp(option + "(\s+?)?\=(\s+?)?[\"']?(.+?)([\"']|$|>)", "ig");
	var matches = re.exec(text);
	if(matches != null) {
		return trim(matches[3]);
	}
	return '';
}

function html2bbcode(str) {

	if(forumallowhtml || (allowhtml && fetchCheckbox('htmlon')) || trim(str) == '') {
		str = str.replace(/<img([^>]*aid=[^>]*)>/ig, function($1, $2) {return imgtag($2);});
		return str;
	}

	str= str.replace(/\s*\[code\]([\s\S]+?)\[\/code\]\s*/ig, function($1, $2) {return codetag($2);});

	str = preg_replace(['<style.*?>[\\\s\\\S]*?<\/style>', '<script.*?>[\\\s\\\S]*?<\/script>', '<noscript.*?>[\\\s\\\S]*?<\/noscript>', '<select.*?>[\s\S]*?<\/select>', '<object.*?>[\s\S]*?<\/object>', '<!--[\\\s\\\S]*?-->', 'on[a-zA-Z]{3,16}\\\s?=\\\s?"[\\\s\\\S]*?"'], '', str);

	str= str.replace(/(\r\n|\n|\r)/ig, '');

	str= trim(str.replace(/&((#(32|127|160|173))|shy|nbsp);/ig, ' '));

	if(!fetchCheckbox('parseurloff')) {
		str = parseurl(str, 'bbcode');
	}

	if(!fetchCheckbox('bbcodeoff') && allowbbcode) {
		str = preg_replace(['<table([^>]*(width|background|background-color|bgcolor)[^>]*)>', '<table[^>]*>', '<tr[^>]*(?:background|background-color|bgcolor)[:=]\\\s*(["\']?)([\(\)%,#\\\w]+)(\\1)[^>]*>', '<tr[^>]*>', '<t[dh]([^>]*(width|colspan|rowspan)[^>]*)>', '<t[dh][^>]*>', '<\/t[dh]>', '<\/tr>', '<\/table>'], [function($1, $2) {return tabletag($2);}, '[table]', function($1, $2, $3) {return '[tr=' + $3 + ']';}, '[tr]', function($1, $2) {return tdtag($2);}, '[td]', '[/td]', '[/tr]', '[/table]'], str);

		str = str.replace(/<h([0-9]+)[^>]*>(.*)<\/h\\1>/ig, "[size=$1]$2[/size]\n\n");
		/*   Discuz!NT  */
		//str = str.replace(/<img[^>]+smilieid=(["']?)(\d+)(\1)[^>]*>/ig, function($1, $2, $3) {return smilies[$3]['code'];});
		//str = str.replace(/<img[^>]+smilieid=(["']?)(\d+)(\1)[^>]*>/ig, function($1, $2, $3) {return ParseSmilies($1,$3);});
		str = str.replace(/<img[^>]+smiliecode=(["']?)([\s\S]+?)(\1)[^>]*>/ig, function($1, $2, $3) {return $3;});
		/*   Discuz!NT  */

		str = str.replace(/<img([^>]*src[^>]*)>/ig, function($1, $2) {return imgtag($2);});
		str = str.replace(/<a\s+?name=(["']?)(.+?)(\1)[\s\S]*?>([\s\S]*?)<\/a>/ig, '$4');		

		str = recursion('b', str, 'simpletag', 'b');
		str = recursion('strong', str, 'simpletag', 'b');
		str = recursion('i', str, 'simpletag', 'i');
		str = recursion('em', str, 'simpletag', 'i');
		str = recursion('u', str, 'simpletag', 'u');
		str = recursion('a', str, 'atag');
		str = recursion('font', str, 'fonttag');
		str = recursion('blockquote', str, 'simpletag', 'indent');
		str = recursion('ol', str, 'listtag');
		str = recursion('ul', str, 'listtag');
		str = recursion('div', str, 'dpstag');
		str = recursion('p', str, 'dpstag');
		str = recursion('span', str, 'dpstag');
	}

	str = str.replace(/<br\s+?style=(["']?)clear: both;?(\1)[^\>]*>/ig, '');
	str = str.replace(/<br[^\>]*>/ig, "\n");
	str = str.replace(/<[\/\!]*?[^<>]*?>/ig, '');

	for(var i = 0; i <= pcodecount; i++) {
		str = str.replace("[\tDISCUZ_CODE_" + i + "\t]", codehtml[i]);
	}

	return preg_replace(['&amp;', '&nbsp;', '&lt;', '&gt;'], ['&', ' ', '<', '>'], str);
}

function htmlspecialchars(str) {
	return preg_replace([(is_mac && is_ie ? '&' : '&(?!#[0-9]+;)'), '<', '>', '"'], ['&amp;', '&lt;', '&gt;', '&quot;'], str);
}

function imgtag(attributes) {
	var width = '';
	var height = '';

	re = /src=(["']?)([\s\S]*?)(\1)/i;
	var matches = re.exec(attributes);
	if(matches != null) {
		var src = matches[2];
	} else {
		return '';
	}

	re = /width\s?:\s?(\d{1,4})(px)?/ig;
	var matches = re.exec(attributes);
	if(matches != null) {
		width = matches[1];
	}

	re = /height\s?:\s?(\d{1,4})(px)?/ig;
	var matches = re.exec(attributes);
	if(matches != null) {
		height = matches[1];
	}

	if(!width || !height) {
		re = /width=(["']?)(\d+)(\1)/i;
		var matches = re.exec(attributes);
		if(matches != null) {
			width = matches[2];
		}

		re = /height=(["']?)(\d+)(\1)/i;
		var matches = re.exec(attributes);
		if(matches != null) {
			height = matches[2];
		}
	}

	re = /aid=(["']?)attach_(\d+)(\1)/i;
	var matches = re.exec(attributes);
	var imgtag = 'img';
	if(matches != null) {
		imgtag = 'localimg';
		src = matches[2];
	}
	re = /aid=(["']?)attachimg_(\d+)(\1)/i;
	var matches = re.exec(attributes);
	if(matches != null) {
		return '[attachimg]' + matches[2] + '[/attachimg]';
	}
	return width > 0 && height > 0 ?
		'[' + imgtag + '=' + width + ',' + height + ']' + src + '[/' + imgtag + ']' :
		'[img]' + src + '[/img]';
}

function listtag(listoptions, text, tagname) {
	text = text.replace(/<li>(([\s\S](?!<\/li))*?)(?=<\/?ol|<\/?ul|<li|\[list|\[\/list)/ig, '<li>$1</li>') + (is_opera ? '</li>' : '');
	text = recursion('li', text, 'litag');
	var opentag = '[list]';
	var listtype = fetchoptionvalue('type=', listoptions);
	listtype = listtype != '' ? listtype : (tagname == 'ol' ? '1' : '');
	if(in_array(listtype, ['1', 'a', 'A'])) {
		opentag = '[list=' + listtype + ']';
	}
	return text ? opentag + recursion(tagname, text, 'listtag') + '[/list]' : '';
}

function litag(listoptions, text) {
	return '[*]' + text.replace(/(\s+)$/g, '');
}

function parsecode(text) {
	pcodecount++;

	text = text.replace(/^[\n\r]*([\s\S]+?)[\n\r]*$/ig, '$1');
	text = htmlspecialchars(text);

	codehtml[pcodecount] = '[code]' + text + '[/code]';

	codecount++;
	return "[\tDISCUZ_CODE_" + pcodecount + "\t]";
}

function parsestyle(tagoptions, prepend, append) {
	var searchlist = [
		['align', true, 'text-align:\\s*(left|center|right);?', 1],
		['float', true, 'float:\\s*(left|right);?', 1],
		['color', true, '^(?:\\s|)color:\\s*([^;]+);?', 1],
		['font', true, 'font-family:\\s*([^;]+);?', 1],
		['size', true, 'font-size:\\s*(\\d+(\\.\\d+)?(px|pt|in|cm|mm|pc|em|ex|%|));?', 1],
		['b', false, 'font-weight:\\s*(bold);?'],
		['i', false, 'font-style:\\s*(italic);?'],
		['u', false, 'text-decoration:\\s*(underline);?']
	];
	var style = getoptionvalue('style', tagoptions);
	re = /^(?:\s|)color:\s*rgb\((\d+),\s*(\d+),\s*(\d+)\)(;?)/ig;
	style = style.replace(re, function($1, $2, $3, $4, $5) {return("color:#" + parseInt($2).toString(16) + parseInt($3).toString(16) + parseInt($4).toString(16) + $5);});
	var len = searchlist.length;
	for(var i = 0; i < len; i++) {
		re = new RegExp(searchlist[i][2], "ig");
		match = re.exec(style);
		if(match != null) {
			opnvalue = match[searchlist[i][3]];
			prepend += '[' + searchlist[i][0] + (searchlist[i][1] == true ? '=' + opnvalue + ']' : ']');
			append = '[/' + searchlist[i][0] + ']' + append;
		}
	}
	return {'prepend' : prepend, 'append' : append};
}

function parsetable(width, bgcolor, str) {

	if(isUndefined(width)) {
		var width = '';
	} else {
		width = width.substr(width.length - 1, width.length) == '%' ? (width.substr(0, width.length - 1) <= 98 ? width : '98%') : (width <= 560 ? width : '98%');
	}

	str = str.replace(/\[tr(?:=([\(\)%,#\w]+))?\]\s*\[td(?:=(\d{1,2}),(\d{1,2})(?:,(\d{1,4}%?))?)?\]/ig, function($1, $2, $3, $4, $5) {
		return '<tr' + ($2 ? ' style="background: ' + $2 + '"' : '') + '><td' + ($3 ? ' colspan="' + $3 + '"' : '') + ($4 ? ' rowspan="' + $4 + '"' : '') + ($5 ? ' width="' + $5 + '"' : '') + '>';
	});
	str = str.replace(/\[\/td\]\s*\[td(?:=(\d{1,2}),(\d{1,2})(?:,(\d{1,4}%?))?)?\]/ig, function($1, $2, $3, $4) {
		return '</td><td' + ($2 ? ' colspan="' + $2 + '"' : '') + ($3 ? ' rowspan="' + $3 + '"' : '') + ($4 ? ' width="' + $4 + '"' : '') + '>';
	});
	str = str.replace(/\[\/td\]\s*\[\/tr\]/ig, '</td></tr>');

	return '<table ' + (width == '' ? '' : 'width="' + width + '" ') + 'class="t_table"' + (isUndefined(bgcolor) ? '' : ' style="background: ' + bgcolor + '"') + '>' + str + '</table>';
}

function preg_replace(search, replace, str) {
	var len = search.length;
	for(var i = 0; i < len; i++) {
		re = new RegExp(search[i], "ig");
		str = str.replace(re, typeof replace == 'string' ? replace : (replace[i] ? replace[i] : replace[0]));
	}
	return str;
}

function recursion(tagname, text, dofunction, extraargs) {
	if(extraargs == null) {
		extraargs = '';
	}
	tagname = tagname.toLowerCase();

	var open_tag = '<' + tagname;
	var open_tag_len = open_tag.length;
	var close_tag = '</' + tagname + '>';
	var close_tag_len = close_tag.length;
	var beginsearchpos = 0;

	do {
		var textlower = text.toLowerCase();
		var tagbegin = textlower.indexOf(open_tag, beginsearchpos);
		if(tagbegin == -1) {
			break;
		}

		var strlen = text.length;

		var inquote = '';
		var found = false;
		var tagnameend = false;
		var optionend = 0;
		var t_char = '';

		for(optionend = tagbegin; optionend <= strlen; optionend++) {
			t_char = text.charAt(optionend);
			if((t_char == '"' || t_char == "'") && inquote == '') {
				inquote = t_char;
			} else if((t_char == '"' || t_char == "'") && inquote == t_char) {
				inquote = '';
			} else if(t_char == '>' && !inquote) {
				found = true;
				break;
			} else if((t_char == '=' || t_char == ' ') && !tagnameend) {
				tagnameend = optionend;
			}
		}

		if(!found) {
			break;
		}
		if(!tagnameend) {
			tagnameend = optionend;
		}

		var offset = optionend - (tagbegin + open_tag_len);
		var tagoptions = text.substr(tagbegin + open_tag_len, offset)
		var acttagname = textlower.substr(tagbegin * 1 + 1, tagnameend - tagbegin - 1);

		if(acttagname != tagname) {
			beginsearchpos = optionend;
			continue;
		}

		var tagend = textlower.indexOf(close_tag, optionend);
		if(tagend == -1) {
			break;
		}

		var nestedopenpos = textlower.indexOf(open_tag, optionend);
		while(nestedopenpos != -1 && tagend != -1) {
			if(nestedopenpos > tagend) {
				break;
			}
			tagend = textlower.indexOf(close_tag, tagend + close_tag_len);
			nestedopenpos = textlower.indexOf(open_tag, nestedopenpos + open_tag_len);
		}

		if(tagend == -1) {
			beginsearchpos = optionend;
			continue;
		}

		var localbegin = optionend + 1;
		var localtext = eval(dofunction)(tagoptions, text.substr(localbegin, tagend - localbegin), tagname, extraargs);

		text = text.substring(0, tagbegin) + localtext + text.substring(tagend + close_tag_len);

		beginsearchpos = tagbegin + localtext.length;

	} while(tagbegin != -1);

	return text;
}

function simpletag(options, text, tagname, parseto) {
	if(trim(text) == '') {
		return '';
	}
	text = recursion(tagname, text, 'simpletag', parseto);
	return '[' + parseto + ']' + text + '[/' + parseto + ']';
}

function strpos(haystack, needle, offset) {
	if(isUndefined(offset)) {
		offset = 0;
	}

	index = haystack.toLowerCase().indexOf(needle.toLowerCase(), offset);

	return index == -1 ? false : index;
}

function tabletag(attributes) {
	var width = '';
	re = /width=(["']?)(\d{1,4}%?)(\1)/i;
	var matches = re.exec(attributes);

	if(matches != null) {
		width = matches[2].substr(matches[2].length - 1, matches[2].length) == '%' ?
			(matches[2].substr(0, matches[2].length - 1) <= 98 ? matches[2] : '98%') :
			(matches[2] <= 560 ? matches[2] : '98%');
	} else {
		re = /width\s?:\s?(\d{1,4})([px|%])/ig;
		var matches = re.exec(attributes);
		if(matches != null) {
			width = matches[2] == '%' ? (matches[1] <= 98 ? matches[1] : '98%') : (matches[1] <= 560 ? matches[1] : '98%');
		}
	}

	var bgcolor = '';
	re = /(?:background|background-color|bgcolor)[:=]\s*(["']?)((rgb\(\d{1,3}%?,\s*\d{1,3}%?,\s*\d{1,3}%?\))|(#[0-9a-fA-F]{3,6})|([a-zA-Z]{1,20}))(\1)/i;
	var matches = re.exec(attributes);
	if(matches != null) {
		bgcolor = matches[2];
		width = width ? width : '98%';
	}

	return bgcolor ? '[table=' + width + ',' + bgcolor + ']' : (width ? '[table=' + width + ']' : '[table]');
}

function tdtag(attributes) {

	var colspan = 1;
	var rowspan = 1;
	var width = '';

	re = /colspan=(["']?)(\d{1,2})(\1)/ig;
	var matches = re.exec(attributes);
	if(matches != null) {
		colspan = matches[2];
	}

	re = /rowspan=(["']?)(\d{1,2})(\1)/ig;
	var matches = re.exec(attributes);
	if(matches != null) {
		rowspan = matches[2];
	}

	re = /width=(["']?)(\d{1,4}%?)(\1)/ig;
	var matches = re.exec(attributes);
	if(matches != null) {
		width = matches[2];
	}

	return in_array(width, ['', '0', '100%']) ?
		(colspan == 1 && rowspan == 1 ? '[td]' : '[td=' + colspan + ',' + rowspan + ']') :
		'[td=' + colspan + ',' + rowspan + ',' + width + ']';
}
