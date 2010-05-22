<!--
function SetFontStyle(obj, StyleName)	//Bold,Italic,Underline,StrikeThrough...
{
	var m_objTextRange = obj.document.selection.createRange();
	m_objTextRange.execCommand(StyleName);
}

function SetFontName(obj, FontName)
{
	var m_objTextRange = obj.document.selection.createRange();
	m_objTextRange.execCommand("FontName", false, FontName);
}

function SetFontSize(obj, FontSize)
{
	var m_objTextRange = obj.document.selection.createRange();
	m_objTextRange.execCommand("FontSize", "", FontSize);
}

function SetFontForeColor(obj, FontColor)
{
	var m_objTextRange = obj.document.selection.createRange();
	m_objTextRange.execCommand("ForeColor", "", FontColor);
}

function SetFontBackColor(obj, FontColor)
{
	var m_objTextRange = obj.document.selection.createRange();
	m_objTextRange.execCommand("BackColor", "", FontColor);
}

function InsertImage(obj, ImageFileName)
{
	obj.insertAdjacentHTML("BeforeEnd", "<img src=\"" + ImageFileName + "\">");
}
-->