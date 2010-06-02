<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WithMenuPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="Components/WebControls/LotteryImageItem.ascx" TagName="LotteryImageItem"
    TagPrefix="uc1" %>
<%@ Register Src="Components/WebControls/UserDisplayArea.ascx" TagName="UserDisplayArea"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="center">
        <!--首页导航-->
        <div style="margin-top: 5px; float: left;">
            <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=10,0,0,0"
                width="873" height="270" id="caipiao" align="middle">
                <param name="allowScriptAccess" value="sameDomain" />
                <param name="allowFullScreen" value="false" />
                <param name="movie" value="SWF/caipiao.swf" />
                <param name="flashVars" value="" />
                <param name="quality" value="high" />
                <param name="bgcolor" value="#ffffff" />
                <embed src="caipiao.swf" quality="high" bgcolor="#ffffff" width="873" height="270"
                    name="caipiao" align="middle" allowscriptaccess="sameDomain" allowfullscreen="false"
                    type="application/x-shockwave-flash" flashvars="" pluginspage="http://www.adobe.com/go/getflashplayer_cn" />
            </object>
        </div>
        <!--Flash广告-->
    </div>
    <div class="center" style="clear: left;">
        <uc2:UserDisplayArea ID="UserDisplayArea1" runat="server" />
        <!--登录-->
        <div class="left_bottom fl cl">
            <a href="Register.aspx">
                <img src="Images/bt_reg.jpg" /></a> <a href="HelpCenter.aspx">
                    <img src="Images/bt_begin.jpg" /></a> <a href="#">
                        <img src="Images/bt_pay.jpg" /></a>
            <div class="contract">
                <ul>
                    <li>客服热线：400-800-5286</li>
                    <li></li>
                    <li></li>
                    <li></li>
                </ul>
            </div>
        </div>
        <!--客服热线-->
        <div class="right_bottom fr">
            <div class="title">
                <strong>彩票游戏</strong>
            </div>
            <div class="list">
                <ul class="cb">
                    <li>
                        <uc1:LotteryImageItem ID="lottery_CQSSC" LotteryCode="CQSSC" ImageIndex="01" runat="server" />
                    </li>
                    <li>
                        <img src="Images/game_02.jpg" />
                        <span class="cb"><a href="DrawaLotteryInfo.aspx" class="fl">
                            <img src="Images/jiqiao.jpg" /></a><a href="DataBehavior.aspx" class="fr"><img src="Images/zhoushi.jpg" /></a></span>
                        <a href="UserLottery.aspx">
                            <img src="Images/startgame.jpg" /></a> </li>
                    <li>
                        <img src="Images/game_03.jpg" />
                        <span class="cb"><a href="DrawaLotteryInfo.aspx" class="fl">
                            <img src="Images/jiqiao.jpg" /></a><a href="DataBehavior.aspx" class="fr"><img src="Images/zhoushi.jpg" /></a></span>
                        <a href="UserLottery.aspx">
                            <img src="Images/startgame.jpg" /></a> </li>
                    <li>
                        <img src="Images/game_04.jpg" />
                        <span class="cb"><a href="DrawaLotteryInfo.aspx" class="fl">
                            <img src="Images/jiqiao.jpg" /></a><a href="DataBehavior.aspx" class="fr"><img src="Images/zhoushi.jpg" /></a></span>
                        <a href="UserLottery.aspx">
                            <img src="Images/startgame.jpg" /></a> </li>
                    <li>
                        <img src="Images/game_05.jpg" />
                        <span class="cb"><a href="DrawaLotteryInfo.aspx" class="fl">
                            <img src="Images/jiqiao.jpg" /></a><a href="DataBehavior.aspx" class="fr"><img src="Images/zhoushi.jpg" /></a></span>
                        <a href="UserLottery.aspx">
                            <img src="Images/startgame.jpg" /></a> </li>
                    <li>
                        <img src="Images/game_06.jpg" />
                        <span class="cb"><a href="DrawaLotteryInfo.aspx" class="fl">
                            <img src="Images/jiqiao.jpg" /></a><a href="DataBehavior.aspx" class="fr"><img src="Images/zhoushi.jpg" /></a></span>
                        <a href="UserLottery.aspx">
                            <img src="Images/startgame.jpg" /></a> </li>
                    <li>
                        <img src="Images/game_07.jpg" />
                        <span class="cb"><a href="DrawaLotteryInfo.aspx" class="fl">
                            <img src="Images/jiqiao.jpg" /></a><a href="DataBehavior.aspx" class="fr"><img src="Images/zhoushi.jpg" /></a></span>
                        <a href="UserLottery.aspx">
                            <img src="Images/startgame.jpg" /></a> </li>
                    <li>
                        <img src="Images/game_08.jpg" />
                        <span class="cb"><a href="DrawaLotteryInfo.aspx" class="fl">
                            <img src="Images/jiqiao.jpg" /></a><a href="DataBehavior.aspx" class="fr"><img src="Images/zhoushi.jpg" /></a></span>
                        <a href="UserLottery.aspx">
                            <img src="Images/startgame.jpg" /></a> </li>
                    <li>
                        <uc1:LotteryImageItem ID="lottery_SSQ" LotteryCode="SSQ" ImageIndex="09" runat="server" />
                    </li>
                    <li>
                        <img src="Images/game_10.jpg" />
                        <span class="cb"><a href="DrawaLotteryInfo.aspx" class="fl">
                            <img src="Images/jiqiao.jpg" /></a><a href="DataBehavior.aspx" class="fr"><img src="Images/zhoushi.jpg" /></a></span>
                        <a href="UserLottery.aspx">
                            <img src="Images/startgame.jpg" /></a> </li>
                    <li>
                        <img src="Images/game_11.jpg" />
                        <span class="cb"><a href="DrawaLotteryInfo.aspx" class="fl">
                            <img src="Images/jiqiao.jpg" /></a><a href="DataBehavior.aspx" class="fr"><img src="Images/zhoushi.jpg" /></a></span>
                        <a href="UserLottery.aspx">
                            <img src="Images/startgame.jpg" /></a> </li>
                    <li>
                        <img src="Images/game_12.jpg" />
                        <span class="cb"><a href="DrawaLotteryInfo.aspx" class="fl">
                            <img src="Images/jiqiao.jpg" /></a><a href="DataBehavior.aspx" class="fr"><img src="Images/zhoushi.jpg" /></a></span>
                        <a href="UserLottery.aspx">
                            <img src="Images/startgame.jpg" /></a> </li>
                </ul>
            </div>
            <!--游戏列表-->
            <div class="footer">
            </div>
            <div class="alert">
                <div class="fleft fl">
                </div>
                <div class="text fl">
                    <strong>健康游戏公告:</strong>彩市有风险，投注须谨慎，注意自我保护，谨防受骗上当。未满18周岁严禁购买彩票。</div>
                <div class="fright fr">
                </div>
            </div>
            <!--未成年警告-->
        </div>
        <div class="link1 fl cl">
            <img src="Images/link_helper.jpg" class="fr" alt="" />
            合作伙伴：
            <img src="Images/link_alipay.jpg" />
            <img src="Images/link_ipay.jpg" />
        </div>
        <!--合作伙伴-->
        <div class="link2 fl cl">
            <img src="Images/link2_5.jpg" class="fr" alt="" />
            <img src="Images/link2_1.jpg" />
            <img src="Images/link2_2.jpg" />
            <img src="Images/link2_3.jpg" />
            <img src="Images/link2_4.jpg" />
        </div>
        <div class="link3 fl cl">
            <div class="title">
                友情链接:</div>
            51.com 新浪 网页游戏 17173网页游戏 游久网 青娱乐 中国娱乐网 腾讯游戏 网友天下 一起发财 电子相册 52pk 优搜网 电玩巴士 宠物中国 114导航
            全客网 盈彩网 766网页游戏 交友facebo 动网论坛 04060站长之家 亿友交友网 5617网络游戏 玄幻小说网 幻剑书盟 流行歌曲 久游网游频道 酷狗音乐网
            直销批发区 火影忍者漫画 家天下 966网页游戏 265游戏导航 办公用品网 中国麦克网 新农网 久久结婚网 周易八字算命 慢慢看漫画 酷我音乐盒 网页游戏集合
            游戏库 小说阅读网 PCHOME.NET 悠视导航 大众游戏网 中国建站 言情小说 辽一网 海报时尚网 天空游戏网 小说书楼 点子创意网 挖贝创投 520友情吧
        </div>
        <!--友情链接-->
        <div class="cb">
        </div>
    </div>
</asp:Content>
