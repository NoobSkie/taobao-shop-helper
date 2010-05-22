<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shove.Web.UI.ShoveWebPart_AscxAttribute" EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑窗口内容控件属性</title>
    <base target="_self" />
    <style type="text/css">
        body
        {
            scrollbar-face-color: #CECBCE;
            scrollbar-highlight-color: WHITE;
            scrollbar-shadow-color: #848284;
            scrollbar-3dlight-color: #848284;
            scrollbar-arrow-color: WHITE;
            scrollbar-track-color: #EAEAEA;
            scrollbar-darkshadow-color: WHITE;
            font-family: "宋体";
            color: #3C3C3C;
            font-size: 9pt;
            line-height: 14pt;
            margin-left: 0px;
            margin-right: 0px;
            margin-top: 0px;
        }
    </style>
    <link href="../Style/css.css" type="text/css" rel="Stylesheet" />

    <script type="text/javascript">

    function showObj(num) 
    {
        var DivId = "odiv" + num;
        var ImgID = "Img" + num;

        var div = document.getElementById(DivId);
        var img = document.getElementById(ImgID);

        if(div.style.display == "inline")
        {
            div.style.display = "none";
            img.src = "../Images/dian_2.jpg";
        }
        else
        {
            div.style.display = "inline";
            img.src = "../Images/dian_1.jpg";
        }
    }
    
    function btnCancel_onclick()
    {
        var o_hiControlAttributes = document.getElementById("hiControlAttributes");

        window.returnValue = o_hiControlAttributes.value;

        window.opener = null;
        window.close();
    }

    function btnColor_onclick(Key)
    {
        var sColor = dlgHelper.ChooseColorDlg();
        var color = "txt" + Key;

        document.getElementById(color).value = "#" + LeftPad(sColor.toString(16), 6, "0");
    }
    
    function LeftPad(Str, Len,  PadChar)
    {
        while (Str.length < Len)
        {
            Str = PadChar + Str;
        }

        return Str;
    }
    
    function btnImg_onclick(Key)
    {
        var maxWidth = 810 + "px";   
        var maxHeight = screen.availHeight + "px"; 

        var SiteDir = document.getElementById("hiSiteDir").value;
        var UserID = document.getElementById("hiUserID").value;

        var txtImg = window.showModalDialog("ImageLibrary.aspx?SiteDir=" + SiteDir + "&UserID=" + UserID, "", "dialogWidth=" + maxWidth + ",dialogHeight=" + maxWidth + ",dialogTop:10px");

        if ((txtImg == null) || (txtImg == "undefined"))
        {
            return false;
        }

        document.getElementById("txt" + Key).value = txtImg;
    }
    </script>

</head>
<body style="margin: 0px; background-color: buttonface;">
    <object id="dlgHelper" classid="clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b" width="0px" height="0px">
    </object>
    <form id="form1" runat="server">
    <div style="overflow: auto;">
        <div style="width: 100%;">
            <asp:Button ID="btnSave" runat="server" Text="确 定" Style="position: absolute; top: 10px; left: 300px" OnClick="btnSave_OnClick" Width="71px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <input id="btnCancel" runat="server" type="button" value="取消" onclick="btnCancel_onclick()" style="width: 71px; position: absolute; top: 10px; left: 385px;" />
            <hr color="#6666ff" style="border-right: #0099ff thin solid; border-top: #0099ff thin solid; border-left: #0099ff thin solid; border-bottom: #0099ff thin solid; position: absolute; width: 480px; top: 40px; left: 10px; height: 2px;" />
        </div>
        <br />
        <br />
        <div align="center" style="width: 100%;">
            <table width="500" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr id="BoolRow" runat="server" visible="false">
                    <td style="width: 500px;" align="left">
                        &nbsp;<a href="#" onclick="showObj(0)"><img src="../Images/dian_1.jpg" id="Img0" alt="" style="border: 0;" /></a> <b>是否显示属性：</b><br />
                        <div id="odiv0" style="display: inline; text-align: center;">
                            <table width="490" border="0" runat="server" id="tbBool" align="center" cellpadding="0" cellspacing="1" style="background-color: #CCCCCC;">
                            </table>
                        </div>
                    </td>
                </tr>
                <tr id="EnumRow" runat="server" visible="false">
                    <td style="width: 500px;" align="left">
                        &nbsp;<a href="#" onclick="showObj(1)"><img src="../Images/dian_1.jpg" id="Img1" alt="" style="border: 0;" /></a> <b>下拉选择属性：</b><br />
                        <div id="odiv1" style="display: inline; text-align: center;">
                            <table width="490" border="0" runat="server" id="tbEnum" align="center" cellpadding="0" cellspacing="1" style="background-color: #CCCCCC;">
                            </table>
                        </div>
                    </td>
                </tr>
                <tr id="IntRow" runat="server" visible="false">
                    <td style="width: 500px;" align="left">
                        &nbsp;<a href="#" onclick="showObj(2)"><img src="../Images/dian_1.jpg" id="Img2" alt="" style="border: 0;" /></a> <b>数字类属性：</b><br />
                        <div id="odiv2" style="display: inline; text-align: center;">
                            <table width="490" border="0" runat="server" id="tbInt" align="center" cellpadding="0" cellspacing="1" style="background-color: #CCCCCC;">
                            </table>
                        </div>
                    </td>
                </tr>
                <tr id="ColorRow" runat="server" visible="false">
                    <td style="width: 500px;" align="left">
                        &nbsp;<a href="#" onclick="showObj(3)"><img src="../Images/dian_1.jpg" id="Img3" alt="" style="border: 0;" /></a> <b>颜色属性：</b><br />
                        <div id="odiv3" style="display: inline; text-align: center;">
                            <table width="490" border="0" runat="server" id="tbColor" align="center" cellpadding="0" cellspacing="1" style="background-color: #CCCCCC;">
                            </table>
                        </div>
                    </td>
                </tr>
                <tr id="ImageRow" runat="server" visible="false">
                    <td style="width: 500px;" align="left">
                        &nbsp;<a href="#" onclick="showObj(4)"><img src="../Images/dian_1.jpg" id="Img4" alt="" style="border: 0;" /></a> <b>图片属性：</b><br />
                        <div id="odiv4" style="display: inline; text-align: center;">
                            <table width="490" runat="server" id="tbImage" border="0" align="center" cellpadding="0" cellspacing="1" style="background-color: #CCCCCC;">
                            </table>
                        </div>
                    </td>
                </tr>
                <tr id="PageRow" runat="server" visible="false">
                    <td style="width: 500px;" align="left">
                        &nbsp;<a href="#" onclick="showObj(5)"><img src="../Images/dian_1.jpg" id="Img5" alt="" style="border: 0;" /></a> <b>页面导航属性：</b><br />
                        <div id="odiv5" style="display: inline; text-align: center;">
                            <table width="490" border="0" runat="server" id="tbPage" align="center" cellpadding="0" cellspacing="1" style="background-color: #CCCCCC;">
                            </table>
                        </div>
                    </td>
                </tr>
                <tr id="TextRow" runat="server" visible="false">
                    <td style="width: 500px;" align="left">
                        &nbsp;<a href="#" onclick="showObj(6)"><img src="../Images/dian_1.jpg" id="Img6" alt="" style="border: 0;" /></a> <b>文本标签属性：</b><br />
                        <div id="odiv6" style="display: inline; text-align: center;">
                            <table width="490" border="0" runat="server" id="tbText" align="center" cellpadding="0" cellspacing="1" style="background-color: #CCCCCC;">
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="hiControlAttributes" runat="server" />
        <asp:HiddenField ID="hiSiteDir" runat="server" />
        <asp:HiddenField ID="hiUserID" runat="server" />
        &nbsp; &nbsp; &nbsp; &nbsp;
    </div>
    </form>
</body>
</html>
