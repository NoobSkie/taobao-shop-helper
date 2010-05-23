
function checkExplorerAndTip()
{
	if (!window.ActiveXObject)
	{
		alert('尊敬的用户您好，由于您当前使用浏览器不支持网银操作，为了更好地体验购彩服务，请使用以IE为核心的浏览器(例如:IE浏览器、360浏览器、傲游浏览器、TT浏览器，TheWorld、Avant Browser 、GreenBrowser.)');
	}
	
}

var lastID = null;
function WinProfit(obj) {
    if (lastID == null) {
        lastID = document.getElementById("spanWin1");
    }

    if (lastID != null) {
        lastID.style.fontWeight = "normal";
        document.getElementById(lastID.id.replace("span", "tb")).style.display = "none";
        lastID.parentNode.style.background = "";
    }

    obj.style.fontWeight = "bold";
    document.getElementById(obj.id.replace("span", "tb")).style.display = "";
    obj.parentNode.style.background = "#BCD2E9";
    
    lastID = obj;
}

function ProfitWin(obj) {
    if (lastID == null) {
        lastID = document.getElementById("tdWin");
    }

    if (lastID != null) {
        lastID.style.fontWeight = "normal";
        document.getElementById(lastID.id.replace("td", "tb")).style.display = "none";
        lastID.bgColor = "#E7F1FA";
    }

    obj.style.fontWeight = "bold";
    document.getElementById(obj.id.replace("td", "tb")).style.display = "";
    obj.bgColor = "#BCD2E9";

    lastID = obj;
}