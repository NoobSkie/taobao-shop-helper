<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shove.Web.UI.ShoveWebPartAttributes" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑窗口控件属性</title>
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

    <script type="text/javascript">
     
    function btnBorderColor_onclick()
    {
        var sColor = dlgHelper.ChooseColorDlg();
        
        document.getElementById("tbBorderColor").value = "#" + LeftPad(sColor.toString(16), 6, "0");
    }

    function btnBackColor_onclick()
    {
        var sColor = dlgHelper.ChooseColorDlg();
        
        document.getElementById("tbBackColor").value = "#" + LeftPad(sColor.toString(16), 6, "0");
    }
    
    function cbAutoHeight_onclick(sender)
    {
        var o_tbHeight = document.getElementById("tbHeight");
        
        if (sender.checked)
        {
            o_tbHeight.value = "auto";
        }
        else
        {
            if ((o_tbHeight.value == "auto") || (o_tbHeight.value == ""))
            {
                o_tbHeight.value = "100px";
            }
            else
            {
                var Height = parseInt(o_tbHeight.value.replace("px", ""), 10);

                if (isNaN(Height))
                {
                    Height = 0;
                }
                
                if(Height <= 0)
                {
                    Height = 100;
                }
                
                o_tbHeight.value = Height + "px";
            }
        }
    }
    
    function fileBackImage_onchange(sender)
    {
        var o_btnUploadImage = document.getElementById("btnUploadImage");
        
        o_btnUploadImage.disabled = ((sender.value == "") ? "disabled" : "");

        var o_labTip = document.getElementById("labTip");
        
        if (o_labTip)
        {
            o_labTip.style.visibility = "hidden";
        }
    }
    
    function ddlTitleImage_onchange(sender)
    {
        var o_imgTitleImage = document.getElementById("imgTitleImage");
        
        if (sender.value == "不使用标题图片")
        {
            o_imgTitleImage.disabled = "disabled";
            o_imgTitleImage.src = "";
            o_imgTitleImage.style.backgroundColor = "buttonface";
            o_imgTitleImage.alt = "未设置图片";
        }
        else
        {
            o_imgTitleImage.disabled = "";
            o_imgTitleImage.src = "../../" + sender.value;
            o_imgTitleImage.style.backgroundColor = "white";
            o_imgTitleImage.alt = "";
        }
    }

    function ddlBackImage_onchange(sender)
    {
        var o_imgBackImage = document.getElementById("imgBackImage");
        
        if (sender.value == "不使用背景图片")
        {
            o_imgBackImage.disabled = "disabled";
            o_imgBackImage.src = "";
            o_imgBackImage.style.backgroundColor = "buttonface";
            o_imgBackImage.alt = "未设置图片";
        }
        else
        {
            o_imgBackImage.disabled = "";
            o_imgBackImage.src = "../../" + sender.value;
            o_imgBackImage.style.backgroundColor = "white";
            o_imgBackImage.alt = "";
        }
    }

    function ddlBottomImage_onchange(sender)
    {
        var o_imgBottomImage = document.getElementById("imgBottomImage");
        
        if (sender.value == "不使用底部图片")
        {
            o_imgBottomImage.disabled = "disabled";
            o_imgBottomImage.src = "";
            o_imgBottomImage.style.backgroundColor = "buttonface";
            o_imgBottomImage.alt = "未设置图片";
        }
        else
        {
            o_imgBottomImage.disabled = "";
            o_imgBottomImage.src = "../../" + sender.value;
            o_imgBottomImage.style.backgroundColor = "white";
            o_imgBottomImage.alt = "";
        }
    }

    function LeftPad(Str, Len,  PadChar)
    {
        while (Str.length < Len)
        {
            Str = PadChar + Str;
        }
        
        return Str;
    }

    function btnOK_onclick()
    {
        var o_ddlAscxFileName = document.getElementById("ddlAscxFileName");
        var o_ddlAscxAlign = document.getElementById("ddlAscxAlign");
        var o_ddlAscxVAlign = document.getElementById("ddlAscxVAlign");
        var o_ddlBorderStyle = document.getElementById("ddlBorderStyle");
        var o_tbBorderWidth = document.getElementById("tbBorderWidth");
        var o_tbBorderColor = document.getElementById("tbBorderColor");
        var o_tbBackColor = document.getElementById("tbBackColor");
        var o_ddlTitleImage = document.getElementById("ddlTitleImage");
        var o_ddlBackImage = document.getElementById("ddlBackImage");
        var o_ddlBottomImage = document.getElementById("ddlBottomImage");
        var o_cbAutoHeight = document.getElementById("cbAutoHeight");
        var o_tbLeft = document.getElementById("tbLeft");
        var o_tbTop = document.getElementById("tbTop");
        var o_tbWidth = document.getElementById("tbWidth");
        var o_tbHeight = document.getElementById("tbHeight");
        var o_tbCssClass = document.getElementById("tbCssClass");
        var o_cbTopUpLimit = document.getElementById("cbTopUpLimit");
        var o_tbTitleImageUrlLink = document.getElementById("tbTitleImageUrlLink");
        var o_tbBottomImageUrlLink = document.getElementById("tbBottomImageUrlLink");
        var o_ddlTitleImageUrlLinkTarget = document.getElementById("ddlTitleImageUrlLinkTarget");
        var o_ddlBottomImageUrlLinkTarget = document.getElementById("ddlBottomImageUrlLinkTarget");
        var o_hiControlAttributes = document.getElementById("hiControlAttributes");
        var o_cbApplyToAllPage = document.getElementById("cbApplyToAllPage");
        var o_cbAddToNoExistPage = document.getElementById("cbAddToNoExistPage");

        var BorderWidth = parseInt(o_tbBorderWidth.value.replace("px", ""), 10) + "px";
        
        if (BorderWidth == "NaNpx")
        {
            BorderWidth = "0px";
        }
       
        var BorderColor = (o_tbBorderColor.value == "") ? "Black" : o_tbBorderColor.value;
        var BackColor = (o_tbBackColor.value == "") ? "Window" : o_tbBackColor.value;

        var Left = parseInt(o_tbLeft.value.replace("px", ""), 10) + "px";
        
        if (Left == "NaNpx")
        {
            Left = "0px";
        }
        
        var Top = parseInt(o_tbTop.value.replace("px", ""), 10) + "px";
        
        if (Top == "NaNpx")
        {
            Top = "0px";
        }

        var Width = parseInt(o_tbWidth.value.replace("px", ""), 10) + "px";
        
        if (Width == "NaNpx")
        {
            Width = "100px";
        }

        var Height = parseInt(o_tbHeight.value.replace("px", ""), 10) + "px";
        
        if (Height == "NaNpx")
        {
            Height = "auto";
            
            o_cbAutoHeight.checked = true;
        }

        var TitleImage = o_ddlTitleImage.value;
        
        if (TitleImage == "不使用标题图片")
        {
            TitleImage = "";
        }

        var BackgroundImage = o_ddlBackImage.value;
        
        if (BackgroundImage == "不使用背景图片")
        {
            BackgroundImage = "";
        }
        
        var BottomImage = o_ddlBottomImage.value;
        
        if (BottomImage == "不使用底部图片")
        {
            BottomImage = "";
        }

        var AscxFileName = o_ddlAscxFileName.value;
        
        var oldascxFileName = document.getElementById("hiascxFileName").value;
        
        var ControlAttributes = o_hiControlAttributes.value;
        
        if (AscxFileName == "不需要填充内容")
        {
            AscxFileName = "";
            ControlAttributes = "";
        }
        if((AscxFileName != oldascxFileName) && (oldascxFileName != ""))
        {
           ControlAttributes = "";
        }
        
        var TitleImageUrlLink = o_tbTitleImageUrlLink.value;
        var BottomImageUrlLink = o_tbBottomImageUrlLink.value;
        var TitleImageUrlLinkTarget = o_ddlTitleImageUrlLinkTarget.value;
        var BottomImageUrlLinkTarget = o_ddlBottomImageUrlLinkTarget.value;
        
        var ReturnParams = new Object();
        
        ReturnParams.AscxFileName = AscxFileName;
        ReturnParams.AscxAlign = o_ddlAscxAlign.value;
        ReturnParams.AscxVAlign = o_ddlAscxVAlign.value;
        ReturnParams.BorderStyle = o_ddlBorderStyle.value;
        ReturnParams.BorderWidth = BorderWidth;
        ReturnParams.BorderColor = BorderColor;
        ReturnParams.BackColor = BackColor;
        ReturnParams.TitleImage = TitleImage;
        ReturnParams.BackgroundImage = BackgroundImage;
        ReturnParams.BottomImage = BottomImage;
        ReturnParams.AutoHeight = o_cbAutoHeight.checked ? "True" : "False";
        ReturnParams.Left = Left;
        ReturnParams.Top = Top;
        ReturnParams.Width = Width;
        ReturnParams.Height = Height;
        ReturnParams.CssClass = o_tbCssClass.value;
        ReturnParams.TopUpLimit = o_cbTopUpLimit.checked ? "True" : "False";
        ReturnParams.TitleImageUrlLink = TitleImageUrlLink;
        ReturnParams.BottomImageUrlLink = BottomImageUrlLink;
        ReturnParams.TitleImageUrlLinkTarget = TitleImageUrlLinkTarget;
        ReturnParams.BottomImageUrlLinkTarget = BottomImageUrlLinkTarget;
        ReturnParams.ControlAttributes = ControlAttributes;
        ReturnParams.ApplyToAllPage = o_cbApplyToAllPage.checked ? "True" : "False";
        ReturnParams.AddToNoExistPage = o_cbAddToNoExistPage.checked ? "True" : "False";

        window.returnValue = ReturnParams;
        window.opener = null;
        window.close();
       
        return true;
    }
    
    function btnCancel_onclick()
    {
        window.opener = null;
        window.close();
        
        return true;
    }
    
    function btnEditAscxAttribute_onclick()
    {
        var o_ddlAscxFileName = document.getElementById("ddlAscxFileName");
        var o_hiControlAttributes = document.getElementById("hiControlAttributes");
        var oldascxFileName = document.getElementById("hiascxFileName").value;
        var SiteDir = document.getElementById("hiSiteDir").value;
        var AscxFileName = o_ddlAscxFileName.value;
        var UserID = document.getElementById("hiUserID").value;
            
        if(AscxFileName != oldascxFileName)
        {
            o_hiControlAttributes.value = "";
        }
        
        if ((o_ddlAscxFileName.value != "不需要填充内容") )
        { 
            var AscxParams = new Object();

            AscxParams.SiteDir = SiteDir;
            AscxParams.UserID = UserID;
            AscxParams.AscxFileName = o_ddlAscxFileName.value;
            AscxParams.ControlAttributes = o_hiControlAttributes.value;

            var returnValue = window.showModalDialog("ShoveWebPart_AscxAttribute.htm", AscxParams, "dialogWidth:550px;");

            if((returnValue == null) || (returnValue == "undefined"))
            {
                return false;
            }

            document.getElementById("hiControlAttributes").value = returnValue;
        }
        else
        {
            if (o_ddlAscxFileName.value == "")
            {
                alert('请先选择填充内容！');
            }
        }
    }
     
    function btnChooseImg(num)
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

        // 遍历 ddlTitleImage，如果是新上传的图片，则增加一项
        var ddlTitleImage = document.getElementById("ddlTitleImage");
        var ddlBackImage = document.getElementById("ddlBackImage");
        var ddlBottomImage = document.getElementById("ddlBottomImage");
        
        var isExists = false;
        
        for (var i = 0; i < ddlTitleImage.length; i++)
        {
            if (ddlTitleImage.options[i].value == txtImg)
            {
                isExists = true;
                
                break;
            }
        }
        
        if (!isExists)
        {
            var customOptions = document.createElement("OPTION");

            customOptions.text = txtImg;
            customOptions.value = txtImg;
            ddlTitleImage.add(customOptions, ddlTitleImage.length);

            customOptions = document.createElement("OPTION");

            customOptions.text = txtImg;
            customOptions.value = txtImg;
            ddlBackImage.add(customOptions, ddlBackImage.length);

            customOptions = document.createElement("OPTION");

            customOptions.text = txtImg;
            customOptions.value = txtImg;
            ddlBottomImage.add(customOptions, ddlBottomImage.length);
        }
        
        switch(num.toString())
        {
            case "0":
                ddlTitleImage.value = txtImg;
                break;

            case "1":
                ddlBackImage.value = txtImg;
                break;

            case "2":
                ddlBottomImage.value = txtImg;
                break;

            default:
                break;
        }
    }
     
    function btnChooseUserControl()
    {
        var maxWidth = 810 + "px";   
        var maxHeight = screen.availHeight + "px"; 

        var UserID = document.getElementById("hiUserID").value;

        window.open("ShoveWebPartUserControlLibrary.aspx?UserID=" + UserID, "", "dialogWidth=" + maxWidth + ",dialogHeight=" + maxWidth + ",dialogTop:10px");
    }
    
    </script>

</head>
<body style="margin: 0px; background-color: buttonface;">
    <object id="dlgHelper" classid="clsid:3050f819-98b5-11cf-bb82-00aa00bdce0b" width="0px" height="0px">
    </object>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="调整窗口控件属性" Style="z-index: 0; position: absolute; left: 26px; top: 8px;" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="ddlBorderStyle" runat="server" Style="z-index: 3; left: 82px; position: absolute; top: 44px;" Width="166px">
        </asp:DropDownList>
        <hr style="border-right: #0099ff thick solid; border-top: #0099ff thick solid; border-left: #0099ff thick solid; border-bottom: #0099ff thick solid; width: 664px; position: absolute; left: 14px; top: 38px;" />
        <asp:Label ID="Label2" runat="server" Style="z-index: 1; left: 15px; position: absolute; top: 46px" Text="边线类型："></asp:Label>
        <asp:Label ID="Label3" runat="server" Style="z-index: 2; left: 258px; position: absolute; top: 46px" Text="边线宽度："></asp:Label>
        <asp:Label ID="labTip" runat="server" ForeColor="Red" Style="z-index: 2; left: 383px; position: absolute; top: 266px" Text="上传成功。" Visible="False" Width="75px"></asp:Label>
        <asp:TextBox ID="tbBorderWidth" runat="server" Style="z-index: 4; left: 324px; position: absolute; top: 44px;" Width="108px"></asp:TextBox>
        <asp:Label ID="Label12" runat="server" Style="z-index: 2; left: 15px; position: absolute; top: 75px" Text="定位－左："></asp:Label>
        <asp:Label ID="Label13" runat="server" Style="z-index: 2; left: 136px; position: absolute; top: 75px" Text="定位－顶："></asp:Label>
        <asp:TextBox ID="tbTop" runat="server" Style="z-index: 4; left: 202px; position: absolute; top: 73px" Width="40px"></asp:TextBox>
        <asp:Label ID="Label14" runat="server" Style="z-index: 2; left: 258px; position: absolute; top: 75px" Text="定位－宽："></asp:Label>
        <asp:TextBox ID="tbWidth" runat="server" Style="z-index: 4; left: 324px; position: absolute; top: 73px" Width="40px"></asp:TextBox>
        <asp:Label ID="Label15" runat="server" Style="z-index: 2; left: 378px; position: absolute; top: 75px" Text="定位－高："></asp:Label>
        <asp:TextBox ID="tbHeight" runat="server" Style="z-index: 4; left: 444px; position: absolute; top: 73px" Width="40px"></asp:TextBox>
        <asp:TextBox ID="tbLeft" runat="server" Style="z-index: 4; left: 81px; position: absolute; top: 73px" Width="40px"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Style="z-index: 5; left: 446px; position: absolute; top: 48px" Text="边线颜色："></asp:Label>
        <asp:TextBox ID="tbBorderColor" runat="server" Style="z-index: 6; left: 511px; position: absolute; top: 44px" Width="133px"></asp:TextBox>
        <input id="btnBorderColor" type="button" value="..." style="z-index: 7; left: 656px; position: absolute; top: 43px; width: 22px;" name="btnBorderColor" onclick="return btnBorderColor_onclick()" />
        <hr style="border-right: #0099ff thin solid; border-top: #0099ff thin solid; border-left: #0099ff thin solid; border-bottom: #0099ff thin solid; width: 664px; position: absolute; left: 14px; top: 102px; height: 1px;" />
        <hr style="border-right: #0099ff thin solid; border-top: #0099ff thin solid; border-left: #0099ff thin solid; border-bottom: #0099ff thin solid; width: 664px; position: absolute; left: 14px; top: 294px; height: 1px;" />
        <hr style="border-right: #0099ff thin solid; border-top: #0099ff thin solid; border-left: #0099ff thin solid; border-bottom: #0099ff thin solid; width: 664px; position: absolute; left: 14px; top: 332px; height: 1px;" />
        <asp:Label ID="Label5" runat="server" Style="z-index: 8; left: 15px; position: absolute; top: 169px" Text="背景图片："></asp:Label>
        <asp:DropDownList ID="ddlBackImage" runat="server" Style="z-index: 9; left: 82px; position: absolute; top: 168px;" Width="330px">
        </asp:DropDownList>
        <input id="btnBackImg" type="button" value="..." style="z-index: 10; left: 420px; position: absolute; top: 168px; width: 20px;" name="btnBackImg" onclick="return btnChooseImg('1')" />
        <asp:Label ID="Label8" runat="server" Style="z-index: 8; left: 15px; position: absolute; top: 198px" Text="底部图片："></asp:Label>
        <asp:DropDownList ID="ddlBottomImage" runat="server" Style="z-index: 9; left: 82px; position: absolute; top: 197px;" Width="330px">
        </asp:DropDownList>
        <input id="btnFootImg" type="button" value="..." style="z-index: 10; left: 420px; position: absolute; top: 197px; width: 20px;" name="btnFootImg" onclick="return btnChooseImg('2')" />
        <asp:Label ID="Label11" runat="server" Style="z-index: 9; left: 15px; position: absolute; top: 111px" Text="标题图片："></asp:Label>
        <asp:DropDownList ID="ddlTitleImage" runat="server" Style="z-index: 10; left: 82px; position: absolute; top: 110px;" Width="330px">
        </asp:DropDownList>
        <input id="btnTitleImg" type="button" value="..." style="z-index: 10; left: 420px; position: absolute; top: 111px; width: 20px;" name="btnTitleImg" onclick="return btnChooseImg('0')" />
        <hr style="border-right: #0099ff thin solid; border-top: #0099ff thin solid; border-left: #0099ff thin solid; border-bottom: #0099ff thin solid; width: 456px; position: absolute; left: 15px; top: 256px; height: 1px;" />
        <img id="imgTitleImage" src="about:blank" alt="未设置图片" name="imgTitleImage" style="z-index: 11; position: absolute; left: 497px; top: 109px; background-color: buttonface; height: 25px; width: 179px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 0px solid;" runat="server" />
        <img id="imgBottomImage" src="about:blank" alt="未设置图片" name="imgBottomImage" style="z-index: 11; position: absolute; left: 497px; top: 258px; background-color: buttonface; height: 25px; width: 179px; border-right: black 1px solid; border-top: black 0px solid; border-left: black 1px solid; border-bottom: black 1px solid;" runat="server" />
        <img id="imgBackImage" src="about:blank" alt="未设置图片" name="imgBackImage" style="z-index: 11; position: absolute; left: 497px; top: 135px; background-color: buttonface; width: 179px; border-right: black 1px solid; border-top: black 0px solid; border-left: black 1px solid; border-bottom: black 0px solid;" runat="server" height="123" />
        <asp:Label ID="Label6" runat="server" Style="z-index: 12; left: 15px; position: absolute; top: 266px" Text="上传图片：" Visible="false"></asp:Label>
        <input onchange="fileBackImage_onchange(this)" id="fileBackImage" type="file" style="z-index: 13; left: 81px; position: absolute; top: 264px; width: 233px;" name="fileBackImage" runat="server" visible="false" />
        <asp:Button ID="btnUploadImage" runat="server" Text="上传" Style="z-index: 14; position: absolute; left: 320px; top: 264px;" Height="22px" Width="53px" Enabled="False" OnClick="btnUploadImage_Click" Visible="false" />
        <asp:Label ID="Label10" runat="server" Style="z-index: 16; left: 16px; position: absolute; top: 303px" Text="背景颜色："></asp:Label>
        <asp:TextBox ID="tbBackColor" runat="server" Style="z-index: 17; left: 81px; position: absolute; top: 302px" Width="110px"></asp:TextBox>
        <asp:Label ID="Label16" runat="server" Style="z-index: 16; left: 286px; position: absolute; top: 303px" Text="样式名称：" Width="61px"></asp:Label>
        <asp:TextBox ID="tbCssClass" runat="server" Style="z-index: 17; left: 351px; position: absolute; top: 302px" Width="320px"></asp:TextBox>
        <input id="btnBackColor" type="button" value="..." style="z-index: 18; left: 205px; position: absolute; top: 301px; width: 22px;" name="btnBackColor" onclick="return btnBackColor_onclick()" />
        <asp:Label ID="Label7" runat="server" Style="z-index: 19; left: 15px; position: absolute; top: 342px" Text="窗口内容："></asp:Label>
        <asp:DropDownList ID="ddlAscxFileName" runat="server" Style="z-index: 20; left: 82px; position: absolute; top: 340px;" Width="200px">
        </asp:DropDownList>
        <input id="btnChooseUC" runat="server" type="button" value="..." disabled="disabled" style="z-index: 20; left: 285px; position: absolute; top: 340px; width: 20px;" name="btnChooseUC" onclick="return btnChooseUserControl()" />
        &nbsp;
        <asp:Label ID="Label9" runat="server" Style="z-index: 21; left: 310px; position: absolute; top: 341px" Text="水平对齐："></asp:Label>
        <asp:DropDownList ID="ddlAscxAlign" runat="server" Style="z-index: 22; left: 378px; position: absolute; top: 339px;" Width="110px">
        </asp:DropDownList>
        <asp:Label ID="Label17" runat="server" Style="z-index: 21; left: 502px; position: absolute; top: 341px" Text="垂直对齐："></asp:Label>
        <asp:DropDownList ID="ddlAscxVAlign" runat="server" Style="z-index: 22; left: 568px; position: absolute; top: 339px;" Width="110px">
        </asp:DropDownList>
        <hr style="border-right: #0099ff thick solid; border-top: #0099ff thick solid; border-left: #0099ff thick solid; border-bottom: #0099ff thick solid; width: 664px; position: absolute; left: 14px; top: 397px;" />
        <input id="btnOK" type="button" value="确定" onclick="return btnOK_onclick();" style="z-index: 24; position: absolute; left: 453px; top: 411px; width: 60px;" />
        <input id="btnCancel" type="button" value="取消" onclick="return btnCancel_onclick();" style="z-index: 25; position: absolute; left: 533px; top: 411px; width: 60px;" />
        <asp:CheckBox ID="cbAutoHeight" runat="server" Text="自适应高度" Style="z-index: 25; position: absolute; left: 493px; top: 74px;" Width="84px" />
        <asp:CheckBox ID="cbTopUpLimit" runat="server" Text="限制自动上移" Style="z-index: 25; position: absolute; left: 581px; top: 74px;" Width="97px" />
        <asp:Label ID="Label20" runat="server" Style="z-index: 8; left: 15px; position: absolute; top: 141px" Text="头部超链地址："></asp:Label>
        <asp:TextBox ID="tbTitleImageUrlLink" runat="server" Style="z-index: 17; left: 107px; position: absolute; top: 140px" Width="205px"></asp:TextBox>
        <asp:Label ID="Label21" runat="server" Style="z-index: 8; left: 325px; position: absolute; top: 141px" Text="目标："></asp:Label>
        <asp:DropDownList ID="ddlTitleImageUrlLinkTarget" runat="server" Style="z-index: 10; left: 370px; position: absolute; top: 139px;" Width="104px">
            <asp:ListItem>_blank</asp:ListItem>
            <asp:ListItem>_self</asp:ListItem>
            <asp:ListItem>_parent</asp:ListItem>
            <asp:ListItem>_top</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label22" runat="server" Style="z-index: 8; left: 15px; position: absolute; top: 227px" Text="底部超链地址："></asp:Label>
        <asp:TextBox ID="tbBottomImageUrlLink" runat="server" Style="z-index: 17; left: 107px; position: absolute; top: 226px" Width="205px"></asp:TextBox>
        <asp:Label ID="Label23" runat="server" Style="z-index: 8; left: 325px; position: absolute; top: 227px" Text="目标："></asp:Label>
        <asp:DropDownList ID="ddlBottomImageUrlLinkTarget" runat="server" Style="z-index: 10; left: 370px; position: absolute; top: 225px;" Width="104px">
            <asp:ListItem>_blank</asp:ListItem>
            <asp:ListItem>_self</asp:ListItem>
            <asp:ListItem>_parent</asp:ListItem>
            <asp:ListItem>_top</asp:ListItem>
        </asp:DropDownList>
        <input type="button" value="编辑窗口内容属性" id="btnEditAscxAttribute" onclick="return btnEditAscxAttribute_onclick();" style="z-index: 16; left: 16px; position: absolute; top: 366px; width: 136px;" />
        <asp:CheckBox ID="cbApplyToAllPage" runat="server" Text="将属性修改应用于其他页面的相同 Part" Style="z-index: 16; left: 166px; position: absolute; top: 368px;" Width="250px" />
        <asp:CheckBox ID="cbAddToNoExistPage" runat="server" Text="在未包含此 Part 的页面增加此 Part" Style="z-index: 16; left: 430px; position: absolute; top: 368px;" Width="250px" />
        <asp:HiddenField ID="hiControlAttributes" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="hiascxFileName" runat="server" />
        <asp:HiddenField ID="hiSiteDir" runat="server" />
        <asp:HiddenField ID="hiUserID" runat="server" />
        <asp:HiddenField ID="hiSiteID" runat="server" />
    </div>
    </form>
</body>
</html>
