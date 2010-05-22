<%@ Page Language="C#" MasterPageFile="~/FrontWebPage/FrontSubMasterPage.master"
    AutoEventWireup="true" CodeFile="UserCenter.aspx.cs" Inherits="FrontWebPage_UserCenter"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="center">
        <div style="margin: 15px auto;">
            您好！&nbsp;faacai&nbsp;&nbsp;&nbsp;&nbsp;您的余额：<strong class="red">￥888.00</strong>
            元&nbsp;&nbsp;&nbsp;&nbsp;积分：<strong class="red">888</strong><a href="#">中奖查询</a><a
                href="#" class="red">充值</a><a href="#">提现</a><a href="#">我的658</a><a href="#">安全退出</a></div>
        <div class="user_title">
        </div>
        <div class="user_list">
            <div class="left fl">
                <img src="../images/mylt.gif" />
                <ul>
                    <li>·<a href="#">投注记录</a></li>
                    <li>·<a href="#">我的追号</a></li>
                </ul>
                <img src="../images/mymoney.gif" />
                <ul>
                    <li>·<a href="#">资金明细</a></li>
                    <li>·<a href="#">我要充值</a></li>
                    <li>·<a href="#">我要提现</a></li>
                    <li>·<a href="#">我的折扣券</a></li>
                </ul>
                <img src="../images/myinfo.gif" />
                <ul>
                    <li>·<a href="#">我的积分</a></li>
                    <li class="now">·<a href="#">修改个人资料</a></li>
                    <li>·<a href="#">VIP专区</a></li>
                    <li style="list-style: none;"></li>
                </ul>
            </div>
            <div class="right fl">
                <ul class="user_menu">
                    <li class="now" id="1"><a href="#" onclick="document.getElementById('1').className='now';document.getElementById('2').className='';document.getElementById('3').className='';document.getElementById('4').className='';">
                        个人资料</a></li>
                    <li id="2"><a href="#" onclick="document.getElementById('1').className='';document.getElementById('2').className='now';document.getElementById('3').className='';document.getElementById('4').className='';">
                        登陆断码</a></li>
                    <li id="3"><a href="#" onclick="document.getElementById('1').className='';document.getElementById('2').className='';document.getElementById('3').className='now';document.getElementById('4').className='';">
                        资金密码</a></li>
                    <li id="4"><a href="#" onclick="document.getElementById('1').className='';document.getElementById('2').className='';document.getElementById('3').className='';document.getElementById('4').className='now';">
                        提现资料</a></li>
                </ul>
                <div class="alert">
                    <strong class="red">提示：</strong>以下信息为领取大奖重要凭证，请务必认真填写。</div>
                <div class="myform">
                    <div>
                        <span>昵称 <font class="red">*</font> ：</span><font class="black">chenny</font></div>
                    <div>
                        <span>真实姓名 <font class="red">*</font> ：</span><font class="black">王**</font></div>
                    <div>
                        <span>电子邮箱 <font class="red">*</font> ：</span><font class="black">******@msn.com</font></div>
                    <div class="noline">
                        <span>手机号码 <font class="red">*</font> ：</span><input type="text" />填写您的真实手机，中大奖后658会及时通知您，避免遗漏。</div>
                    <div>
                        <span></span>
                        <input type="checkbox" class="checkbox" /><font class="black">接收手机中奖短信通知</font><font
                            class="red">(免费)</font>
                    </div>
                    <div>
                        <span>身份证号码：</span><input type="text" />填写您的身份证号码，<font class="red">填写后不可修改。</font>
                    </div>
                    <div class="noline">
                        <span>QQ号码：</span><input type="text" />大奖通知备用联系方式。
                    </div>
                    <div>
                        <span></span>
                        <input type="submit" class="submit" value="" /></div>
                </div>
                <div class="text">
                    说明：
                    <br />
                    为保证您的资金安全，昵称、真实姓名、身份证号码和电子邮件地址填写后将不可自行修改。
                    <br />
                    如需修改，请点击 在线客服 咨询处理流程。
                </div>
            </div>
            <div class="cb">
            </div>
        </div>
        <div class="user_footer">
        </div>
        <div class="notice">
            <strong>健康游戏公告:</strong> 彩市有风险，投注须谨慎，注意自我保护，谨防受骗上当。未满18周岁严禁购买彩票。</div>
        <div class="cb">
        </div>
    </div>
</asp:Content>
