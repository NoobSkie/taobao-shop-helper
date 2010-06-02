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
        <!--��ҳ����-->
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
        <!--Flash���-->
    </div>
    <div class="center" style="clear: left;">
        <uc2:UserDisplayArea ID="UserDisplayArea1" runat="server" />
        <!--��¼-->
        <div class="left_bottom fl cl">
            <a href="Register.aspx">
                <img src="Images/bt_reg.jpg" /></a> <a href="HelpCenter.aspx">
                    <img src="Images/bt_begin.jpg" /></a> <a href="#">
                        <img src="Images/bt_pay.jpg" /></a>
            <div class="contract">
                <ul>
                    <li>�ͷ����ߣ�400-800-5286</li>
                    <li></li>
                    <li></li>
                    <li></li>
                </ul>
            </div>
        </div>
        <!--�ͷ�����-->
        <div class="right_bottom fr">
            <div class="title">
                <strong>��Ʊ��Ϸ</strong>
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
            <!--��Ϸ�б�-->
            <div class="footer">
            </div>
            <div class="alert">
                <div class="fleft fl">
                </div>
                <div class="text fl">
                    <strong>������Ϸ����:</strong>�����з��գ�Ͷע�������ע�����ұ�����������ƭ�ϵ���δ��18�����Ͻ������Ʊ��</div>
                <div class="fright fr">
                </div>
            </div>
            <!--δ���꾯��-->
        </div>
        <div class="link1 fl cl">
            <img src="Images/link_helper.jpg" class="fr" alt="" />
            ������飺
            <img src="Images/link_alipay.jpg" />
            <img src="Images/link_ipay.jpg" />
        </div>
        <!--�������-->
        <div class="link2 fl cl">
            <img src="Images/link2_5.jpg" class="fr" alt="" />
            <img src="Images/link2_1.jpg" />
            <img src="Images/link2_2.jpg" />
            <img src="Images/link2_3.jpg" />
            <img src="Images/link2_4.jpg" />
        </div>
        <div class="link3 fl cl">
            <div class="title">
                ��������:</div>
            51.com ���� ��ҳ��Ϸ 17173��ҳ��Ϸ �ξ��� ������ �й������� ��Ѷ��Ϸ �������� һ�𷢲� ������� 52pk ������ �����ʿ �����й� 114����
            ȫ���� ӯ���� 766��ҳ��Ϸ ����facebo ������̳ 04060վ��֮�� ���ѽ����� 5617������Ϸ ����С˵�� �ý����� ���и��� ��������Ƶ�� �ṷ������
            ֱ�������� ��Ӱ�������� ������ 966��ҳ��Ϸ 265��Ϸ���� �칫��Ʒ�� �й������ ��ũ�� �þý���� ���װ������� ���������� �������ֺ� ��ҳ��Ϸ����
            ��Ϸ�� С˵�Ķ��� PCHOME.NET ���ӵ��� ������Ϸ�� �й���վ ����С˵ ��һ�� ����ʱ���� �����Ϸ�� С˵��¥ ���Ӵ����� �ڱ���Ͷ 520�����
        </div>
        <!--��������-->
        <div class="cb">
        </div>
    </div>
</asp:Content>
