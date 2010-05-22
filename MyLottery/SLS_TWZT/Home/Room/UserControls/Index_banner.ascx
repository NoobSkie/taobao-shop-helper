<%@ control language="C#" autoeventwireup="true" CodeFile="Index_banner.ascx.cs" inherits="Home_Room_UserControls_Index_banner" %>
<div align="center">
<script type="text/javascript" language="javascript">
    var pic_width = 350; //图片宽度
    var pic_height = 212; //图片高度
    var button_pos = 4; //按扭位置 1左 2右 3上 4下
    var stop_time = 5000; //图片停留时间(1000为1秒钟)
    var show_text = 0; //是否显示文字标签 1显示 0不显示
    var txtcolor = "000000"; //文字色
    var bgcolor = "DDDDDD"; //背景色
   
    var imag = new Array();
    var link = new Array();
    var text = new Array();

    var images = '<%=imagsBanner %>'.split(',');
    var links = '<%=linksBanner %>'.split(',');
    var texts = '<%=textBanner %>'.split(',');
    
    for (var i = 1; i < images.length; i++) {
        imag[i] = images[i-1].toString();
        link[i] = links[i-1].toString();
        text[i] = texts[i-1].toString();
    }
    //可编辑内容结束
    var swf_height = show_text == 1 ? pic_height + 20 : pic_height;
    var pics = "", links = "", texts = "";
    for (var i = 1; i < imag.length; i++) {
        pics = pics + ("|" + imag[i]);
        links = links + ("|" + link[i]);
        texts = texts + ("|" + text[i]);
    }
    pics = pics.substring(1);
    links = links.substring(1);
    texts = texts.substring(1);

    ShoveWebUI_ShoveImagePlayerFlash_Onload('aa', 350, 212, 0, pics, links, '', 'ShoveWebUI_client/Images/PixviewerYellow.swf', '#F4FBFF');

    function ShoveWebUI_ShoveImagePlayerFlash_Onload(ID, FocusWidth, FocusHeight, TextHeight, Pics, Links, Texts, FlashAddress, TitleBgColor) {
        var ShoveWebUI_ShoveImagePlayer_FocusWidth = FocusWidth;
        var ShoveWebUI_ShoveImagePlayer_FocusHeight = FocusHeight;
        var ShoveWebUI_ShoveImagePlayer_TextHeight = TextHeight;
        var ShoveWebUI_ShoveImagePlayer_SwfHeight = ShoveWebUI_ShoveImagePlayer_FocusHeight + ShoveWebUI_ShoveImagePlayer_TextHeight;
        document.write('<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0\" width=\"' + ShoveWebUI_ShoveImagePlayer_FocusWidth + '\" height=\"' + ShoveWebUI_ShoveImagePlayer_SwfHeight + '\">');
        document.write('<param name=\"allowScriptAccess\" value=\"sameDomain\"><param name=\"movie\" value=\"' + FlashAddress + '\"> <param name=\"quality\" value=\"high\"><param name=\"bgcolor\" value=\"' + TitleBgColor + '\">');
        document.write('<param name=\"menu\" value=\"false\"><param name=wmode value=\"opaque\">');
        document.write('<param name=\"FlashVars\" value=\"pics=' + Pics + '&links=' + Links + '&texts=' + Texts + '&borderwidth=' + ShoveWebUI_ShoveImagePlayer_FocusWidth + '&borderheight=' + ShoveWebUI_ShoveImagePlayer_FocusHeight + '&textheight=' + ShoveWebUI_ShoveImagePlayer_TextHeight + '\">');
        document.write('<embed src=\"' + FlashAddress + '\" wmode=\"opaque\" FlashVars=\"pics=' + Pics + '&links=' + Links + '&texts=' + Texts + '&borderwidth=' + ShoveWebUI_ShoveImagePlayer_FocusWidth + '&borderheight=' + ShoveWebUI_ShoveImagePlayer_FocusHeight + '&textheight=' + ShoveWebUI_ShoveImagePlayer_TextHeight + '\" menu=\"false\" bgcolor=\"#ffffff\" quality=\"high\" width=\"' + ShoveWebUI_ShoveImagePlayer_FocusWidth + '\" height=\"' + ShoveWebUI_ShoveImagePlayer_SwfHeight + '\" allowScriptAccess=\"sameDomain\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />');
        document.write('</object>');
    }
</script>
</div>