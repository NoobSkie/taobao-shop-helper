<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/SchemeUpload.aspx.cs" inherits="Home_Room_SchemeUpload" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
     
    <link href="../../Style/css.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
    form
    {
        display:inline;
    }
    </style>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Public.js"></script>

    <script type="text/javascript" language="javascript">
<!--
function btnfileUpClick()
{
	var o_btnfile = document.all["btnfile"];
	var filename = o_btnfile.value.trim();
	if (filename == "")
	{
		alert("请选择一个方案文件。");
		return false;
	}
	return true;
}
-->
    </script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td>
                <input id="btnfile" style="width: 300px; height: 21px" type="file" size="59" name="btnfile"
                    runat="server" onchange="btnfileUp.disabled=false;"/>
            </td>
            <td style="text-align:left; padding-left:5px;">
                <ShoveWebUI:ShoveConfirmButton ID="btnfileUp" runat="server" Text="上传" Width="60px"
                    Height="22px" OnClick="btnfileUp_Click" OnClientClick="if (!btnfileUpClick()) return false; this.disabled=true;" /><input
                        id="tbSchemeFileName" style="width: 64px; height: 21px" type="hidden" value="<%=strSchemeFileName%>"
                        name="tbSchemeFileName" runat="server" /><input id="tbLotteryNumber" style="width: 64px;
                            height: 21px" type="hidden" value="<%=strLotteryNumber%>" name="tbLotteryNumber"
                            runat="server" /><input id="tbLotteryID" style="width: 64px; height: 21px" type="hidden"
                                value="<%=strLotteryID%>" name="tbLotteryID" runat="server" /><input id="tbPlayType"
                                    style="width: 64px; height: 21px" type="hidden" value="<%=strPlayType%>" name="tbPlayType"
                                    runat="server" /><input id="tbPanelNum" style="width: 64px; height: 21px" type="hidden"
                                        value="<%=strPanelNum%>" name="tbPanelNum" runat="server" /><input id="tbIsuse" style="width: 64px;
                                            height: 21px" type="hidden" value="<%=strIsuse%>" name="tbIsuse" runat="server" />
            </td>
        </tr>
    </table>
    </form>

    <script type="text/javascript">
<!--				
var o_tbSchemeFileName = document.all["tbSchemeFileName"];
var o_tbLotteryNumber = document.all["tbLotteryNumber"];

var SchemeFileName = o_tbSchemeFileName.value.trim();
var LotteryNumber = o_tbLotteryNumber.value.trim();

if (SchemeFileName == "null")
	SchemeFileName = "";
if (LotteryNumber == "null")
	LotteryNumber = "";

if ((SchemeFileName != "") && (LotteryNumber != ""))
{
        LotteryNumber = document.all["tbLotteryNumber"].value;
        	
		var Lotterys = LotteryNumber.split("\n");
		for (var i = 0; i < Lotterys.length; i ++)
		{
			var str = Lotterys[i].trim();
			if (str == "")
				continue;
			strs = str.split("|");
			if (strs.length < 2)
				continue;
            str = str.substr(0, str.lastIndexOf("|"));
			if (str == "")
				continue;
			var Num = StrToInt(strs[strs.length-1]);
			if (Num < 1)
				continue;

            window.parent.document.all["tbLotteryNumbers"].value += str + "\n";
            
		}
}
LotteryNumber.value = "null";
-->
    </script>

    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
