<%@ Page Language="C#" MasterPageFile="~/FrontWebPage/FrontSubMasterPage.master"
    AutoEventWireup="true" CodeFile="UserLottery.aspx.cs" Inherits="FrontWebPage_UserLottery"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="center">
        <div style="margin: 15px auto;">
            您好！&nbsp;faacai&nbsp;&nbsp;&nbsp;&nbsp;您的余额：<strong class="red">￥888.00</strong>
            元&nbsp;&nbsp;&nbsp;&nbsp;积分：<strong class="red">888</strong><a href="#">中奖查询</a><a
                href="#" class="red">充值</a><a href="#">提现</a><a href="#">我的658</a><a href="#">安全退出</a></div>
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="650" height="155" style="border-bottom: #fe8625 1px solid;
                        border-left: #fe8625 1px solid; border-top: #fe8625 1px solid; border-right: #fe8625 1px solid;"
                        background="../images/l.jpg">
                        <tr>
                            <td align="center" width="132">
                                <img src="../images/22_5.gif" />
                            </td>
                            <td>
                                <div>
                                    <div style="float: left; height: 28px; line-height: 28px; font-size: 14px; font-weight: bold;">
                                        20100024期开奖：</div>
                                    <div style="background-image: url(../images/kch_bg.gif); width: 28px; height: 28px;
                                        line-height: 28px; text-align: center; float: left; margin-left: 5px; font-size: 16px;
                                        color: White; font-weight: bold;">
                                        07</div>
                                    <div style="background-image: url(../images/kch_bg.gif); width: 28px; height: 28px;
                                        line-height: 28px; text-align: center; float: left; margin-left: 5px; font-size: 16px;
                                        color: White; font-weight: bold;">
                                        16</div>
                                    <div style="background-image: url(../images/kch_bg.gif); width: 28px; height: 28px;
                                        line-height: 28px; text-align: center; float: left; margin-left: 5px; font-size: 16px;
                                        color: White; font-weight: bold;">
                                        26</div>
                                    <div style="background-image: url(../images/kch_bg.gif); width: 28px; height: 28px;
                                        line-height: 28px; text-align: center; float: left; margin-left: 5px; font-size: 16px;
                                        color: White; font-weight: bold;">
                                        27</div>
                                    <div style="background-image: url(../images/kch_bg.gif); width: 28px; height: 28px;
                                        line-height: 28px; text-align: center; float: left; margin-left: 5px; font-size: 16px;
                                        color: White; font-weight: bold;">
                                        29</div>
                                </div>
                                <div style="clear: left; height: 48px; line-height: 48px;">
                                    <span style="font-size: 18px; font-weight: bold; color: Blue;">22选5：3元赢取￥2400万</span>
                                    每周一、三、六开奖</div>
                                <div>
                                    第<span style="font-weight: bold; color: #fe8625;">20100024</span>期投注截止时间：2010-03-08
                                    19：27：00 离投注截止还有：<span style="background-color: Red; color: White; font-weight: bold;">01时48分21秒</span></div>
                                <div style="height: 24px; line-height: 24px;">
                                    <a href="DataBehaviour.aspx" class="red">22选5走势图</a> <a href="DrawaLotteryInfo.aspx"class="red">22选5中奖查询</a></div>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0" width="650" style="margin: 5px auto 35px auto;
                        background-repeat: no-repeat;" background="../images/m.jpg">
                        <tr>
                            <td style="height: 30xp; line-height: 30px;">
                                <span style="margin-left: 108px;"><a href="#">参与合买</a></span><span style="margin-left: 40px;"><a
                                    href="#">定制跟单</a></span><span style="margin-left: 40px;"><a href="#">全部方案</a></span><span
                                        style="margin-left: 40px;"><a href="#">玩法介绍</a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0" width="650" style="border-bottom: #fe8625 1px solid;
                                    border-left: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                                    <tr>
                                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" width="90"
                                            height="45" align="center" bgcolor="#fef4d1">
                                            选择玩法
                                        </td>
                                        <td style="border-bottom: #fe8625 1px solid;" bgcolor="#fef4d1">
                                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                                margin-left: 15px; float: left; padding: 0 10px; background-image: url(images/b.jpg);">
                                                <a href="#">五星</a></div>
                                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                                margin-left: 15px; float: left; padding: 0 10px;">
                                                <a href="#">四星</a></div>
                                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                                margin-left: 15px; float: left; padding: 0 10px;">
                                                <a href="#">三星</a></div>
                                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                                margin-left: 15px; float: left; padding: 0 10px;">
                                                <a href="#">二星</a></div>
                                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                                margin-left: 15px; float: left; padding: 0 10px;">
                                                <a href="#">一星</a></div>
                                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                                margin-left: 15px; float: left; padding: 0 10px;">
                                                <a href="#">大小单双</a></div>
                                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                                margin-left: 15px; float: left; padding: 0 10px;">
                                                <a href="#">任选</a></div>
                                            <div style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-top: #fe8625 1px solid;
                                                border-right: #fe8625 1px solid; height: 26px; line-height: 26px; text-align: center;
                                                margin-left: 15px; float: left; padding: 0 10px;">
                                                <a href="#">七乐彩</a></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" height="45"
                                            align="center" bgcolor="#fef4d1">
                                            投注方式
                                        </td>
                                        <td style="border-bottom: #fe8625 1px solid;">
                                            <input id="Radio5" type="radio" checked="checked" />单选<input id="Radio6" type="radio" />复选<input
                                                id="Radio7" type="radio" />组合<input id="Radio8" type="radio" />通选<input id="Radio9"
                                                    type="radio" />单式<input id="Radio10" type="radio" />复式
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" align="center"
                                            bgcolor="#f7b809">
                                            选号
                                        </td>
                                        <td style="border-bottom: #fe8625 1px solid;" align="center">
                                            <div style="font-size: 16px; font-weight: bold; margin: 20px auto 5px auto;">
                                                百位<img src="../images/test.gif" /></div>
                                            <div style="text-align: left; margin-left: 20px;">
                                                遗漏 11 6 33 3 9 0 2 4 20 1</div>
                                            <div style="font-size: 16px; font-weight: bold; margin: 5px auto;">
                                                十位<img src="../images/test.gif" /></div>
                                            <div style="text-align: left; margin-left: 20px;">
                                                遗漏 11 6 33 3 9 0 2 4 20 1</div>
                                            <div style="font-size: 16px; font-weight: bold; margin: 5px auto;">
                                                个位<img src="../images/test.gif" /></div>
                                            <div style="text-align: left; margin-left: 20px;">
                                                遗漏 11 6 33 3 9 0 2 4 20 1</div>
                                            <div style="margin: 20px auto 5px auto; font-size: 14px;">
                                                您当前选择<span class="red">0</span>注，共<span class="red" style="font-weight: bold">0.00</span></div>
                                            <div style="margin: 5px auto 20px auto;">
                                                <input type="image" src="../images/b3.jpg" /></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" align="center"
                                            bgcolor="#ffdf6e">
                                            投注内容
                                        </td>
                                        <td style="border-bottom: #fe8625 1px solid; padding: 15px;">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="border-bottom: #fe8625 3px solid; border-left: #fe8625 3px solid; border-top: #fe8625 3px solid;
                                                        border-right: #fe8625 3px solid; padding: 15px;">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <input id="Text1" type="text" style="width: 400px; height: 150px;" />
                                                                </td>
                                                                <td>
                                                                    <div>
                                                                        <input value="机选1注" style="background-image: url(images/b2.jpg); border-style: none;
                                                                            width: 78px; height: 23px;" type="button" /></div>
                                                                    <div style="margin-top: 10px;">
                                                                        <input value="机选5注" style="background-image: url(images/b2.jpg); border-style: none;
                                                                            width: 78px; height: 23px;" type="button" /></div>
                                                                    <div style="margin-top: 10px;">
                                                                        <input value="粘帖上传" style="background-image: url(images/b2.jpg); border-style: none;
                                                                            width: 78px; height: 23px;" type="button" /></div>
                                                                    <div style="margin-top: 10px;">
                                                                        <input value="删除选择" style="background-image: url(images/b2.jpg); border-style: none;
                                                                            width: 78px; height: 23px;" type="button" /></div>
                                                                    <div style="margin-top: 10px;">
                                                                        <input value="清空全部" style="background-image: url(images/b2.jpg); border-style: none;
                                                                            width: 78px; height: 23px;" type="button" /></div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table border="0" cellpadding="0" cellspacing="0" style="border-bottom: #fe8625 1px solid;
                                                border-left: #fe8625 1px solid; border-top: #fe8625 1px solid; border-right: #fe8625 1px solid;
                                                padding: 15px; margin-top: 15px; background-color: #fef4d1" width="100%">
                                                <tr>
                                                    <td>
                                                        您选择了<span class="red">0</span>注，倍数：<input id="Text2" type="text" style="width: 30px;" />总金额<span
                                                            class="red">0.00</span>元。<span class="red" style="font-weight: bold">[注]</span>投注倍数最高为999倍。
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" height="45"
                                            align="center" bgcolor="#fef4d1">
                                            合买代购
                                        </td>
                                        <td style="border-bottom: #fe8625 1px solid; color: Red;">
                                            <input id="Checkbox1" type="checkbox" />我要发起合买方案<input id="Checkbox2" type="checkbox" />我要追号
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;" height="45"
                                            align="center" bgcolor="#fef4d1">
                                            方案保密
                                        </td>
                                        <td style="border-bottom: #fe8625 1px solid;">
                                            <input id="Radio1" type="radio" checked="checked" />不保密<input id="Radio2" type="radio" />保密至截止<input
                                                id="Radio3" type="radio" />保密到开奖<input id="Radio4" type="radio" />永久保密
                                        </td>
                                    </tr>
                                    <tr>
                                        <td bgcolor="#fef4d1">
                                        </td>
                                        <td bgcolor="#fef4d1" style="height: 76px; line-height: 76px;">
                                            <input type="image" src="../images/b4.jpg" />
                                            <input id="Checkbox3" type="checkbox" />我已阅读并同意《用户电话短信投注协议》
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="vertical-align: top;">
                    <table border="0" cellpadding="0" cellspacing="0" width="202" style="margin-left: 20px;">
                        <tr>
                            <td style="height: 28px; line-height: 28px; border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid;
                                border-top: #fe8625 1px solid; border-right: #fe8625 1px solid;" background="../images/l2.jpg">
                                <span style="font-weight: bold; margin-left: 10px;">时时彩资讯</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                                <div>
                                    <ul>
                                        <li style="margin: 5px auto;">·<a href="#">重庆时时彩三个常用技巧</a></li>
                                        <li style="margin: 5px auto;">·<a href="#">重庆时时彩三个常用技巧</a></li>
                                        <li style="margin: 5px auto;">·<a href="#">重庆时时彩三个常用技巧</a></li>
                                        <li style="margin: 5px auto;">·<a href="#">重庆时时彩三个常用技巧</a></li>
                                        <li style="margin: 5px auto;">·<a href="#">重庆时时彩三个常用技巧</a></li>
                                        <li style="margin: 5px auto;">·<a href="#">重庆时时彩三个常用技巧</a></li>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0" width="202" style="margin-left: 20px;
                        margin-top: 5px;">
                        <tr>
                            <td style="height: 28px; line-height: 28px; border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid;
                                border-top: #fe8625 1px solid; border-right: #fe8625 1px solid;" background="../images/l2.jpg">
                                <span style="font-weight: bold; margin-left: 10px;">时时彩开奖号码</span><span style="margin-left: 60px;"><a
                                    href="DrawaLotteryInfo.aspx">更多</a></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-bottom: #fe8625 1px solid; border-left: #fe8625 1px solid; border-right: #fe8625 1px solid;
                                padding: 10px;">
                                <table border="0" cellpadding="0" cellspacing="0" height="200" width="100%" style="border-bottom: #fe8625 1px solid;
                                    border-left: #fe8625 1px solid; border-top: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                                    <tr>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;"
                                            bgcolor="#fef4d1">
                                            期号
                                        </td>
                                        <td align="center" style="border-bottom: #fe8625 1px solid;" bgcolor="#fef4d1">
                                            中奖号码
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                                            2010024
                                        </td>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; color: #fe8625">
                                            07 16 26 27 29 31 <span style="color: Blue;">14</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                                            2010024
                                        </td>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; color: #fe8625">
                                            07 16 26 27 29 31 <span style="color: Blue;">14</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                                            2010024
                                        </td>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; color: #fe8625">
                                            07 16 26 27 29 31 <span style="color: Blue;">14</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                                            2010024
                                        </td>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; color: #fe8625">
                                            07 16 26 27 29 31 <span style="color: Blue;">14</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                                            2010024
                                        </td>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; color: #fe8625">
                                            07 16 26 27 29 31 <span style="color: Blue;">14</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                                            2010024
                                        </td>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; color: #fe8625">
                                            07 16 26 27 29 31 <span style="color: Blue;">14</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                                            2010024
                                        </td>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; color: #fe8625">
                                            07 16 26 27 29 31 <span style="color: Blue;">14</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; border-right: #fe8625 1px solid;">
                                            2010024
                                        </td>
                                        <td align="center" style="border-bottom: #fe8625 1px solid; color: #fe8625">
                                            07 16 26 27 29 31 <span style="color: Blue;">14</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="border-right: #fe8625 1px solid;">
                                            2010024
                                        </td>
                                        <td align="center" style="color: #fe8625">
                                            07 16 26 27 29 31 <span style="color: Blue;">14</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0" width="202" style="margin-left: 20px;
                        margin-top: 5px; background-repeat: no-repeat; border-bottom: #fe8625 1px solid;
                        border-left: #fe8625 1px solid; border-top: #fe8625 1px solid; border-right: #fe8625 1px solid;"
                        background="images/t2.jpg">
                        <tr>
                            <td>
                                <table style="margin-top: 40px;">
                                    <tr>
                                        <td>
                                            <img src="../images/ser1.gif" width="46" height="40" />
                                        </td>
                                        <td>
                                            <a href="#">客服01<br />
                                                QQ交谈</a>
                                        </td>
                                        <td>
                                            <img src="../images/ser1.gif" width="46" height="40" />
                                        </td>
                                        <td>
                                            <a href="#">客服01<br />
                                                QQ交谈</a>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center" style="color: #fe8625">
                                    <tr>
                                        <td>
                                            ------------------------------
                                        </td>
                                    </tr>
                                </table>
                                <div class="tel" style="text-align: center;">
                                    客服热线：400-8882-658<br />
                                    <a href="#" style="color: Blue">5173余额如何充值？</a></div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div class="notice">
            <strong>健康游戏公告:</strong> 彩市有风险，投注须谨慎，注意自我保护，谨防受骗上当。未满18周岁严禁购买彩票。</div>
        <div class="cb">
        </div>
    </div>
</asp:Content>
