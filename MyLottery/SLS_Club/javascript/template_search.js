var keywordtypes = document.getElementsByName('keywordtype');
var keywordtype = '0';
for (var i = 0; i < keywordtypes.length; i++)
{
	if (keywordtypes[i].checked)
	{
		keywordtype = keywordtypes[i].value;
		break;
	}
}
var postoptions = $('postoptions').innerHTML;
var spacepostoptions = $('spacepostoptions').innerHTML;
var albumoptions = $('albumoptions').innerHTML;
$('options_item').parentNode.removeChild($('options_item'));
switch (keywordtype)
{
	case '0':
	case '1':
		changeoption('post');
		break;
	case '2':
		changeoption('spacepost');
		break;
	case '3':
		changeoption('album');
		break;
	default:
		changeoption('post');
		break;
}
function changeoption(optionname)
{
	switch (optionname)
	{
		case 'post':
			$('options').innerHTML = postoptions;
			break;
		case 'spacepost':
			$('options').innerHTML = spacepostoptions;
			break;
		case 'album':
			$('options').innerHTML = albumoptions;
			break;
		default:
			$('options').innerHTML = postoptions;
			break;	
	}
	try{
	    $('type').value = optionname;
	}
	catch(e){
	}
}

function checkauthoroption(obj)
{
    if(obj.checked) { 
        $('divsearchtype').style.display = 'none';
        $('divkeyword').style.display = 'none'; 
        $('divsearchoption').style.display = 'none'; 
    }else { 
        $('divsearchtype').style.display = '';
        $('divkeyword').style.display = ''; 
        $('divsearchoption').style.display = ''; 
    }
}
