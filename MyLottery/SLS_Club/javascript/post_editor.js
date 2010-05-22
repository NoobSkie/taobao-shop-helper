/*
	[Discuz!] (C)2001-2007 Comsenz Inc.
	This is NOT a freeware, use is title to license terms

	$RCSfile: post_editor.js,v $
	$Revision: 1.10 $
	$Date: 2007/06/25 21:47:26 $
*/

function checklength(theform) {
	var message = bbinsert && wysiwyg ? html2bbcode(getEditorContents()) : (!theform.parseurloff.checked ? parseurl(theform.message.value) : theform.message.value);
	var showmessage = postmaxchars != 0 ? lang['board_allowed'] + ': ' + postminchars + ' ' + lang['lento'] + ' ' + postmaxchars + ' ' + lang['bytes'] : '';
	alert('\n' + lang['post_curlength'] + ': ' + mb_strlen(message) + ' ' + lang['bytes'] + '\n\n' + showmessage);
}

function validate(theform, previewpost) {
    if (in_array($('postsubmit').name, ['topicsubmit', 'editsubmit']))
    {
        if (theform.title.value.length <= 0) {
            alert("标题不能为空");
            theform.title.focus();
            return false;
        }
    }
	if (typeof (titleEditor) != 'undefined' && titleEditor != null)
	{
		theform.title.value = html2bbcode(titleEditor.GetHtml().replace(/<[^>]*>/ig, '')).toString().substr(0, 60);
		if (theform.htmltitle)
		{
			theform.htmltitle.value = titleEditor.GetHtml();
		}
    }
    if (theform.title.value.replace(/[^x00-xFF]/g, '**').length > 60) {
        alert(lang['post_title_toolong']);
        try { theform.title.focus(); } catch (e) { };
        return false;
    }

    try {
        switchEditor(0);
        switchEditor(1);
        switchEditor(0);
    
	
	var message = bbinsert && wysiwyg ? html2bbcode(getEditorContents()) : (!theform.parseurloff.checked ? parseurl(theform.message.value) : theform.message.value);
	if (($('postsubmit').name != 'replysubmit' && !($('postsubmit').name == 'editsubmit' && !isfirstpost) && theform.title.value == "") || message.replace(unescape("%0A"), "") == "") {
	    alert(lang['post_title_and_message_isnull']);
	    if (special != 2) {
	        try { theform.title.focus(); } catch (e) { };
	    }
	    return false;
	}
	else if (theform.title.value.replace(/[^x00-xFF]/g, '**').length > 60) {
	    alert(lang['post_title_toolong']);
	    try { theform.title.focus(); } catch (e) { };
	    return false;
	}

	
	
	if(in_array($('postsubmit').name, ['topicsubmit', 'editsubmit'])) {
		if ((theform.postbytopictype) && (theform.typeid) && (theform.postbytopictype.value == "1") && (theform.typeid.value == "0")) { 
			alert(lang['post_type_isnull']);
			theform.typeid.focus();
			return false;
		} 
		if ($("createpoll")||$("updatepoll")){
			var pollcount = 0;
			var polls = document.getElementsByName("pollitemid");
			var polloptionids = document.getElementsByName("optionid");
			var displayorders = document.getElementsByName("displayorder");
			
			for ( var i = 0; i < polls.length; i++){
				if (polls[i].value != "")
				{
					pollcount ++;
					if ($("PollItemname").value == ""){
						$("PollItemname").value = polls[i].value;			
						if($("updatepoll"))
						{
						    $("PollOptionID").value = (polloptionids[i].value == '' ? '0' : polloptionids[i].value);		
						    $("PollOptionDisplayOrder").value = displayorders[i].value;
						}
					}
					else{
					     $("PollItemname").value = $("PollItemname").value + "\r\n" + polls[i].value;
        			
					     if($("updatepoll"))
					     {
					         $("PollOptionID").value = $("PollOptionID").value + "\r\n" + (polloptionids[i].value == '' ? '0' : polloptionids[i].value);
					         $("PollOptionDisplayOrder").value = $("PollOptionDisplayOrder").value  + "\r\n" + displayorders[i].value;
					     }
					}
				}
			}
			
			if (pollcount < 2){
				alert("投票项不得少于2个");
				$("PollItemname").value = "";
				return false;
			}
			
			if (pollcount > maxpolloptions){
				alert("系统设置为投票项不得多于" + maxpolloptions + "个");
				$("PollItemname").value = "";
				return false;
			}
		}

		/*
		if(theform.typeid && (theform.typeid.options && theform.typeid.options[theform.typeid.selectedIndex].value == 0) && typerequired) {
			alert(lang['post_type_isnull']);
			theform.typeid.focus();
			return false;
		}
		if(special == 2 && !tradefirst) {
			if(theform.item_name.value == "") {
				alert(lang['post_trade_goodsname_null']);
				theform.item_name.focus();
				return false;
			} else if(theform.item_price.value == "") {
				alert(lang['post_trade_price_null']);
				theform.item_price.focus();
				return false;
			}
		} else if(special == 3 && isfirstpost) {
			if(theform.rewardprice.value == "") {
				alert(lang['post_reward_credits_null']);
				theform.rewardprice.focus();
				return false;
			}
		} else if(special == 4 && isfirstpost) {
			if(theform.activityclass.value == "") {
				alert(lang['post_activity_sort_null']);
				theform.activityclass.focus();
				return false;
			} else if($('starttimefrom_0').value == "" && $('starttimefrom_1').value == "") {
				alert(lang['post_activity_fromtime_null']);
				return false;
			} else if(theform.activityplace.value == "") {
				alert(lang['post_activity_addr_null']);
				theform.activityplace.focus();
				return false;
			}
		}
		*/
	}

	if(!disablepostctrl && ((postminchars != 0 && mb_strlen(message) < postminchars) || (postmaxchars != 0 && mb_strlen(message) > postmaxchars))) {
		alert(lang['post_message_length_invalid'] + '\n\n' + lang['post_curlength'] + ': ' + mb_strlen(message) + ' ' + lang['bytes'] + '\n' +lang['board_allowed'] + ': ' + postminchars + ' ' + lang['lento'] + ' ' + postmaxchars + ' ' + lang['bytes']);
		return false;
	}
	theform.message.value = message;

	//商品信息检查
	if($('amount') != null) {
	   if(!validategoods()) {//该方法的具体实现详见javascript目录下的template_postgoods.js或template_eidtgoods.js文件
		   return false;
	   }
	}
	/*else{
		if(in_array($('postsubmit').name, ['topicsubmit', 'replysubmit'])){
			//seccheck(theform, seccodecheck, secqaacheck, previewpost);
		}    
	}*/
		
	
	if(previewpost || $('postsubmit').name == 'editsubmit') {
		theform.title.disabled = false;
		//alert(theform.title.disabled);
		return true;
	}

	if(in_array($('postsubmit').name, ['topicsubmit'])) {
		if (theform.title.value == getcookie("dnt_title")) {
			alert("请勿重复发帖,稍后再试");
			return false;
		}
		else {
			setcookie("dnt_title", theform.title.value, 300);
		}
	}

	theform.title.disabled = false;
} catch (e) { };

	return true;


}

function seccheck(theform, seccodecheck, secqaacheck, previewpost) {
	if(!previewpost && (seccodecheck || secqaacheck)) {
		var url = 'ajax.php?inajax=1&action=';
		if(seccodecheck) {
			var x = new Ajax();
			x.get(url + 'checkseccode&seccodeverify=' + $('seccodeverify').value, function(s) {
				if(s != 'succeed') {
					alert(s);
					$('seccodeverify').focus();
				} else if(secqaacheck) {
					checksecqaa(url, theform);
				} else {
					postsubmit(theform);
				}
			});
		} else if(secqaacheck) {
			checksecqaa(url, theform);
		}
	} else {
		postsubmit(theform, previewpost);
	}
}

function checksecqaa(url, theform) {
	var x = new Ajax();
	var secanswer = $('secanswer').value;
	secanswer = is_ie && document.charset == 'utf-8' ? encodeURIComponent(secanswer) : secanswer;
	x.get(url + 'checksecanswer&secanswer=' + secanswer, function(s) {
		if(s != 'succeed') {
			alert(s);
			$('secanswer').focus();
		} else {
			postsubmit(theform);
		}
	});
}

function postsubmit(theform, previewpost) {
	if(!previewpost) {
		theform.replysubmit ? theform.replysubmit.disabled = true : theform.topicsubmit.disabled = true;
		theform.submit();
	}
}

function previewpost(){
	if(!validate($('postform'), true)) {
		try{$('title').focus();}catch(e){}
		return;
	}
	$("previewmessage").innerHTML = '<span class="bold"><span class="smalltxt">' + $('title').value + '</span></span><br /><br /><span style="font-size: {MSGFONTSIZE}">' + bbcode2html($('postform').message.value) + '</span>';
	$("previewtable").style.display = '';
	window.scroll(0, 0);
}

function clearcontent() {
	if(wysiwyg && bbinsert) {
		editdoc.body.innerHTML = is_moz ? '<br />' : '';
	} else {
		textobj.value = '';
	}
}

function resizeEditor(change) {
	var editorbox = bbinsert ? editbox : textobj;
	var newheight = parseInt(editorbox.style.height, 10) + change;
	if(newheight >= 100) {
		editorbox.style.height = newheight + 'px';
	}
}

function encodeURL(a) {
	return window.encodeURIComponent?encodeURIComponent(a):escape(a)
}

function relatekw(title, message) {
	if (typeof title=='undefined')
	{
		title = $('title').value;
	}
	if (typeof message=='undefined')
	{
		message = getEditorContents();
	}		
	title = encodeURL(title);
	message = message.replace(/&/ig, '', message);
	message = encodeURL(message);
	_sendRequest('tools/ajax.aspx?t=relatekw', relatedkw, true, 'titleenc=' + title + '&contentenc=' + message);
}

function relatedkw(obj) {
	if (obj == null || typeof(obj) != "object" || obj.firstChild == null)
	{
		return;
	}
	if (is_ie)
	{
		evalscript(obj.text);
	}
	else
	{
		evalscript(obj.firstChild.firstChild.nodeValue);
	}
}
