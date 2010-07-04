<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlBackground.ascx.cs"
    Inherits="Controls_CtrlBackground" %>

<script type="text/javascript" src="swfobject.js"></script>

<script type="text/javascript">

    function SetIframeHeight() {
        var a = iframe_sub.document.body.scrollHeight;
        // var c = iframe_sub.document.documentElement.scrollHeight;
        document.getElementById('iframe_sub').style.height = a;
    }

    function play() {
        var dewp = document.getElementById("dewplayer");
        if (dewp != null) {
            dewp.dewplay();
        }
    }

    function playMusicByUrl(url) {
        var dewp = document.getElementById("dewplayer");
        if (dewp != null) {
            dewp.dewset(url);
        }
    }
    
</script>

<div style="width: 1000px; height: 300px; clear: both;">
    <div style="background-image: url(Images/header/header_01.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_02.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_03.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_04.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_05.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_06.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_07.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_08.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_09.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_10.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_11.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_12.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_13.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_14.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_15.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_16.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_17.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_18.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_19.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_20.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_21.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_22.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_23.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_24.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div style="background-image: url(Images/header/header_25.gif); float: left; width: 200px;
        height: 60px;">
    </div>
    <div class="MusicPlayer" id="dewplayer_content">
        <object type="application/x-shockwave-flash" data="dewplayer.swf?mp3=Player/liangzhu.mp3&javascript=on"
            width="200" height="20" id="dewplayer">
            <param name="wmode" value="transparent" />
            <param name="flashvars" value="mp3=Player/liangzhu.mp3&javascript=on" />
            <param name="movie" value="dewplayer.swf?mp3=Player/liangzhu.mp3&javascript=on" />
        </object>
    </div>

    <script type="text/javascript">
        var flashvars = {
            mp3: "Player/liangzhu.mp3",
            javascript: "on"
        };
        var params = {
            wmode: "transparent"
        };
        var attributes = {
            id: "dewplayer"
        };
        try {
            swfobject.embedSWF("dewplayer.swf", "dewplayer_content", "200", "20", "9.0.0", false, flashvars, params, attributes);
        } catch (e) {
        }

        var showMusicPlayer = '<%= IsShowMusicPlayer %>'.toLowerCase();
        if (showMusicPlayer != 'true') {
            document.getElementById("dewplayer_content").style.display = "none";
        }
    </script>

</div>
