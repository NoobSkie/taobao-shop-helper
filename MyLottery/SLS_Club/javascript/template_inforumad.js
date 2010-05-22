	var evalscripts = new Array();
	var divs = $('ad_none').getElementsByTagName('div');
	var adobj = null;

	for(var i = 0; i < divs.length; i++) {
		if(divs[i].id.substr(0, 3) == 'ad_' && (adobj = $(divs[i].id.substr(0, divs[i].id.length - 5)))) {
			if(divs[i].innerHTML) {
				evalscript(divs[i].innerHTML);
				adobj.innerHTML = divs[i].innerHTML;
				adobj.className = divs[i].className;
			}

		}
	}
	$('ad_none').parentNode.removeChild($('ad_none'));

function evalscript(s) {

	if(s.indexOf('<script') == -1) return s;

	var p = /<script[^\>]*src=\"([^\x00]+?)\"[^\>]*( reload=\"1\")?><\/script>/ig;

	var arr = new Array();

	while(arr = p.exec(s)) appendscript(arr[1], '', arr[2]);

	p = /<script[^\>]*( reload=\"1\")?>([^\x00]+?)<\/script>/ig;

	while(arr = p.exec(s)) appendscript('', arr[2], arr[1]);

	return s;

}

function appendscript(src, text, reload) {

	var id = hash(src + text);
	if(!reload && in_array(id, evalscripts)) return;

	if(reload && $(id)) {

		$(id).parentNode.removeChild($(id));

	}

	evalscripts.push(id);

	var scriptNode = document.createElement("script");

	scriptNode.type = "text/javascript";

	scriptNode.id = id;

	try {

		if(src) {

			scriptNode.src = src;

		} else if(text){

			scriptNode.text = text;

		}

		$('append_parent').appendChild(scriptNode);

	} catch(e) {}

}

function hash(string, length) {

	var length = length ? length : 32;

	var start = 0;

	var i = 0;

	var result = '';

	filllen = length - string.length % length;

	for(i = 0; i < filllen; i++){

		string += "0";

	}

	while(start < string.length) {

		result = stringxor(result, string.substr(start, length));

		start += length;

	}

	return result;

}

function stringxor(s1, s2) {

	var s = '';

	var hash = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';

	var max = Math.max(s1.length, s2.length);

	for(var i=0; i<max; i++) {

		var k = s1.charCodeAt(i) ^ s2.charCodeAt(i);

		s += hash.charAt(k % 52);

	}

	return s;

}
