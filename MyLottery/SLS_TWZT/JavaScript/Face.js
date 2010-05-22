<!--
var imgWidth = 20;
var imgHeight = 20;
var imgSrc = "../Images/Face/__FaceFileName__.gif";
var selectedNo = 1;

var myHTML = '<SPAN onmouseover="isin=true" onmouseout="isin=false">';
myHTML += '<table width="1" onclick="showlist(this)" border="0" cellspacing="0" cellpadding="0"><tr><td><img name="imgselected" border=0 src="' + imgSrc.replace("__FaceFileName__", selectedNo) + '" WIDTH=' + imgWidth + ' HEIGHT=' + imgHeight + '></td><td valign=bottom><img src="../Images/Chat/Arrow_Down01.gif"></td></tr></table>';
myHTML += '<DIV id="imgBox_Face" \n';
myHTML += 'style="position:absolute;left=-800;top=0;background-color:#FFFFFF;border: 1px solid #000000;overflow-x:hidden;overflow-y:hidden; width:'+(imgWidth * 8 + 4) + 'px; height: ' + (imgHeight * 6 + 3) + 'px">';
var j = 0;
for(var i = 1; i <= 48; i++)
{
	j ++;
	myHTML += "<img listID=" + i +" src='" + imgSrc.replace("__FaceFileName__",i) + "' alt='" + imgSrc.replace("__FaceFileName__", i) + "' width=" + imgWidth + " height=" + imgHeight + " onclick='selectme(this)' onload='if(init)init()'>";
	if (j == 8)
	{
		j = 0;
		myHTML += "<br />";
	}
}
myHTML += "</DIV></SPAN>";
imgBox_Face.outerHTML = myHTML;

function showlist(obj)
{    
	if (imgBox_Face.style.pixelLeft != -800)
	{
		imgBox_Face.style.pixelLeft = -800;
		return;
	}

	var mytop = obj.offsetTop; 
	var myleft = obj.offsetLeft;
	
	while (obj = obj.offsetParent)
	{
		myleft += obj.offsetLeft;
		mytop += obj.offsetTop;
	}

	imgBox_Face.style.left = myleft;
	imgBox_Face.style.top = mytop + imgHeight + 2;
}

var isin = false;
function selectme(obj)
{
	if (!isin || obj)
		imgBox_Face.style.pixelLeft = -800;
	if(obj)
	{
		document.images["imgselected"].src = imgSrc.replace("__FaceFileName__", obj.listID);
		InsertImage(div_Msg, imgSrc.replace("__FaceFileName__", obj.listID));
		div_Msg.focus();
	}
}

var mytime = setTimeout("", 0);
var pre_X = 0;

function scrollud()
{
	var current_X = imgBox_Face.scrollTop;
	if (current_X > pre_X && imgBox_Face.scrollTop < Math.ceil(imgBox_Face.scrollTop / imgHeight) * imgHeight)
	{
		clearTimeout(mytime);
		mytime = setTimeout("imgBox_Face.scrollTop=Math.round(imgBox_Face.scrollTop+1);", 1);
	}
	else if (current_X < pre_X && imgBox_Face.scrollTop > Math.floor(imgBox_Face.scrollTop/imgHeight)*imgHeight)
	{
		clearTimeout(mytime);
		mytime = setTimeout("imgBox_Face.scrollTop=Math.round(imgBox_Face.scrollTop-1);", 1);
	}
	pre_X = current_X;
}

function init()
{
	imgBox_Face.scrollTop = selectedNo * imgHeight;
	//SelectedFace = imgSrc.replace("__FaceFileName__", selectedNo);
}

myActivation = "selectme(null)";

if (document.body.onclick)
{
	eval(document.body.onclick.toString().replace('anonymous()','bodyclick()'));
	document.body.onclick = new Function("bodyclick();" + myActivation);
}
else
	document.body.onclick = new Function(myActivation);
-->