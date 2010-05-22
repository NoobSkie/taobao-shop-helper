<%@ control language="C#" autoeventwireup="true" CodeFile="WebHead.ascx.cs" inherits="Home_Room_UserControls_WebHead" %>
<style>
    #top
    {
        height: 24px;
        margin-right: auto;
        margin-left: auto;
        background-color: #f0f0f0;
        border-bottom-width: 1px;
        border-bottom-style: solid;
        border-bottom-color: #e0e0e0;
    }
    #wenzi
    {
        height: 24px;
        width: 980px;
        margin-top: 0px;
        margin-right: auto;
        margin-bottom: auto;
        margin-left: auto;
    }
    .blue12_3
    {
        font-size: 12px;
        color: #1F6598;
        font-family: "tahoma";
        line-height: 16px;
    }
    .blue12_3 A:link
    {
        font-family: "tahoma";
        color: #1F6598;
        text-decoration: none;
    }
    .blue12_3 A:active
    {
        font-family: tahoma;
        color: #1F6598;
        text-decoration: underline;
    }
    .blue12_3 A:visited
    {
        font-family: tahoma;
        color: #1F6598;
        text-decoration: none;
    }
    .blue12_3 A:hover
    {
        font-family: tahoma;
        color: #CC0000;
        text-decoration: underline;
    }
</style>
<asp:HiddenField ID="HidUserID" runat="server" Value="-1" />
<div style="display: none;">
    <iframe id="Login_Iframe" name="Login_Iframe" width="100%" frameborder="0" scrolling="no"
        src="<%=LoginIframeUrl %>"></iframe>
</div>
<div id="top">
    <div id="wenzi">
        <table width="1002" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="766" height="24" valign="middle" style="padding-left: 10px;" class="hui12">
                    <a style="cursor: hand" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('<%=HomePage %>');">
                        设为首页 </a>|<span class="b13"> <a style="cursor: hand" onclick="window.external.AddFavorite(location.href,'彩票俱乐部-手机买彩票，就上彩票俱乐部');"
                            class="hui12">加入收藏</a></span>
                    <asp:Substitution ID="Substitution1" runat="server" MethodName="SetNoCache" />
                </td>
                <td width="189" height="24" align="right" valign="middle" class="hui12">
                    免费客服电话：<%= _Site.ServiceTelephone %>
                </td>
                <td width="112" height="24" align="right" valign="middle">
                   <%-- <img src="<%= ResolveUrl("~/Images/bt_service.gif") %>" width="80" height="18" border="0" />--%>
                </td>
            </tr>
        </table>
    </div>
</div>
<div id="box">
    <table width="1002" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="249">
                <a href="<%= _Site.Url %>">
                    <img src="<%= ResolveUrl("~/Images/1_r1_c1.jpg") %>" width="232" height="91" alt="彩票俱乐部-手机买彩票，就上彩票俱乐部"
                        border="0" /></a>
            </td>
            <td width="753" align="center" valign="bottom" style="padding-bottom: 5px;">
                <table width="95%" border="0" align="right" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100" align="center" valign="bottom">
                            <a href="<%=ResolveUrl("~/UserReg.aspx") %>">
                                <img src="<%= ResolveUrl("~/Images/top_r1_c1.jpg") %>" width="57" height="53" border="0" /></a>
                        </td>
                        <td width="100" align="center" valign="bottom">
                            <a href="<%=ResolveUrl("~/Home/Room/OnlinePay/Default.aspx") %>">
                                <img src="<%= ResolveUrl("~/Images/top_r1_c4.jpg") %>" width="57" height="53" border="0" /></a>
                        </td>
                        <td width="100" align="center" valign="bottom">
                            <a href="<%=ResolveUrl("~/Lottery/Buy_SSQ.aspx") %>">
                                <img src="<%= ResolveUrl("~/Images/top_r1_c7.jpg") %>" width="57" height="53" border="0" /></a>
                        </td>
                        <td width="100" align="center" valign="bottom">
                            <a href="<%=ResolveUrl("~/Home/Room/Distill.aspx") %>">
                                <img src="<%= ResolveUrl("~/Images/top_r1_c10.jpg") %>" width="57" height="53" border="0" /></a>
                        </td>
                        <td width="100" align="center" valign="bottom">
                            <a href="<%= _Site.Url %>/bbs/showforum-120.aspx" target="_blank">
                                <img src="<%= ResolveUrl("~/Images/top_r1_c13.jpg") %>" width="57" height="53" border="0" /></a>
                        </td>
                        <td width="100" align="center" valign="bottom">
                            <a href="javascript: alert('新功能即将出，敬请期待！');" disabled="false">
                                <img src="<%= ResolveUrl("~/Images/top_r1_c16.jpg") %>" width="57" height="53" border="0" /></a>
                        </td>
                    </tr>
                    <tr>
                        <td width="100" height="24" align="center" class="blue12_3">
                            <a href="<%=ResolveUrl("~/UserReg.aspx") %>">免费注册</a>
                        </td>
                        <td width="100" height="24" align="center" class="blue12_3">
                            <asp:LinkButton ID="lbAlipay" runat="server" Text="账号充值" OnClick="lbAlipay_Click"></asp:LinkButton>
                        </td>
                        <td width="100" height="24" align="center" class="blue12_3">
                            <a href="<%=ResolveUrl("~/Lottery/Buy_SSQ.aspx") %>">购买彩票</a>
                        </td>
                        <td width="100" height="24" align="center" class="blue12_3">
                            <a href="<%=ResolveUrl("~/Home/Room/Distill.aspx") %>">快速提款</a>
                        </td>
                        <td width="100" height="24" align="center" class="blue12_3">
                            <a href="<%= _Site.Url %>/bbs/showforum-120.aspx" target="_blank">口碑相传</a>
                        </td>
                        <td width="100" height="24" align="center" class="blue12_3">
                            <a href="<%=ResolveUrl("~/Home/Room/MyPromotion/MemberPromotion.aspx") %>">推广佣金</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>

<script type="text/javascript" language="javascript">

    function CreateLogin(script) {
        if (Number(document.getElementById("<%=HidUserID.ClientID %>").value) > 0) {
            eval(script);
            return true;
        }
        try {
            document.getElementById("list_LotteryNumber").style.display = "none";
        } catch (e) { }

        window.evalscript = script;
        var msgw, msgh, bordercolor;
        msgw = 400; //提示窗口的宽度 
        msgh = 450; //提示窗口的高度 
        //titleheight=25 //提示窗口标题高度 
        //bordercolor="#336699";//提示窗口的边框颜色 
        //titlecolor="#99CCFF";//提示窗口的标题颜色 

        var sWidth, sHeight;
        sWidth = document.body.offsetWidth;
        sHeight = document.body.offsetHeight;
        var bgObj = document.createElement("div");
        bgObj.setAttribute('id', 'bgDiv');
        bgObj.style.position = "absolute";
        bgObj.style.top = "0";
        bgObj.style.background = "#777";
        bgObj.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75";
        bgObj.style.opacity = "0.6";
        bgObj.style.left = "0";
        bgObj.style.width = sWidth + "px";
        bgObj.style.height = sHeight + "px";
        bgObj.style.zIndex = "10000";
        document.body.appendChild(bgObj);

        var msgObj = document.createElement("div")
        msgObj.setAttribute("id", "msgDiv");
        msgObj.setAttribute("align", "center");
        msgObj.style.backcolor = "white";
        //msgObj.style.border="1px solid " + bordercolor; 
        msgObj.style.position = "absolute";
        msgObj.style.left = "50%";
        msgObj.style.top = "20%";
        msgObj.style.font = "12px/1.6em Verdana, Geneva, Arial, Helvetica, sans-serif";
        msgObj.style.marginLeft = "-225px";
        msgObj.style.marginTop = document.documentElement.scrollTop + "px";
        msgObj.style.width = msgw + "px";
        msgObj.style.height = msgh + "px";
        msgObj.style.textAlign = "center";
        msgObj.style.lineHeight = "25px";
        msgObj.style.zIndex = "10001";

        document.body.appendChild(msgObj);

        var txt = document.createElement("p");
        txt.style.margin = "1em 0"
        txt.setAttribute("id", "msgTxt");

        var s_str = "<table style='border:White 1px solid; background-color:#659FCB;width:400px;' cellspacing=\"0\" cellpadding=\"0\"><tr><td style='padding:5px;'><div style='background-image:url(<%=LoginTopSrcUrl %>); height:55px;'></div><table style='background-image:url(<%=LoginBackSrcUrl %>)' width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" valign=\"middle\"><tr style=\"padding-top: 10px;\"><td width=\"20%\" style=\"height: 24px;\" align=\"right\">用户名：";
        s_str += "</td><td width=\"80%\" style=\"height: 24px\" align=\"left\"><input id=\"tbUserName\" class='in_text' type=\"text\" onkeypress=\"if (window.event.keyCode == 13) {tbPassword.focus();}\" class='in_text' style=\"width:204px;\"/>";
        s_str += "</td></tr><tr><td style=\"height: 29px\"><div align=\"right\">密&nbsp; 码：</div></td><td align=\"left\" style=\"height: 29px\"><input class='in_text' id=\"tbPassWord\" type=\"password\" style=\"width:204px;\" />";
        s_str += "</tr><tr><td height=\"33\" align=\"right\">验证码：</td><td align=\"left\"><table cellspacing=\"0\" cellpadding=\"0\"><tr><td>";
        s_str += "<input name=\"tbCheckCode\" class='in_text' type=\"text\" id=\"tbCheckCode\" style=\"width:64px;\"/></td><td><img id=\"imCheckCode\" name=\"imCheckCode\" style=\"height:24px;width:64px;\"></td><td style='padding-left:10px;'>";
        s_str += "<a href=\"JavaScript:ReloadImage();\" style='color:#0266C5;'>看不清</a></td></tr></table></td></tr><tr><td></td><td height=\"33\" align='left'><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr style='padding-top:8px;padding-bottom:10px'><td align=\"left\">";
        s_str += "<input type=submit id=imb_Ok name=imb_Ok value=\"登录\" onclick=\"Login()\" style='height:22px;width:58px'></td><td style='padding-left:10px; padding-right:10px;'><input type=button id=imb_Cancel name=imb_Cancel value=\"取消\" onclick=\"Cancel()\" style='height:22px;width:58px'></td><td class='blue'><a href=\"<%=RegisterUrl %>\" target=\"_blank\">免费注册</a><span style='margin-left:10px;'></span><a href=\"<%=ForgetPwdUrl %>\" target=\"_blank\">忘记密码</a></td></tr></table></td></tr>";
        s_str += "</table></td></tr></table>";
        txt.innerHTML = s_str;

        document.getElementById("msgDiv").appendChild(txt);

        var o_CheckCode = document.getElementById("Login_Iframe").contentWindow.document.getElementById("ShoveCheckCode1_imgCode");
        document.getElementById("imCheckCode").src = o_CheckCode.src;
        document.getElementById("imb_Ok").focus();

        return false;
    }

    function ReloadImage() {
        Login_Iframe.location.href = "<%=LoginIframeUrl %>";
    }

    function Login() {
        var UserName = document.getElementById("tbUserName").value;
        var PassWord = document.getElementById("tbPassword").value;
        var CheckCode = document.getElementById("tbCheckCode").value;

        if (UserName == "") {
            alert("用户名不能为空");

            return;
        }

        if (PassWord == "") {
            alert("密码不能为空");

            return;
        }

        if (CheckCode == "") {
            alert("验证码不能为空");

            return;
        }

        var inputCheckCode = document.getElementById("Login_Iframe").contentWindow.document.getElementById("ShoveCheckCode1_tbCode").value;

        var Result = Home_Room_UserControls_WebHead.Login(UserName, PassWord, CheckCode, inputCheckCode, 1).value;


        if (Result == null || isNaN(Result)) {
            Result = Home_Room_UserControls_WebHead.Login(UserName, PassWord, CheckCode, inputCheckCode, 1).value;
        }

        if (Result == null) {
            alert("登录异常，请重试一次，谢谢。可能是网络延时原因。");

            return;
        }

        if (isNaN(Result)) {
            alert(Result);

            return;
        }

        document.getElementById("<%=HidUserID.ClientID %>").value = Result;

        UserInit();
        Cancel();
//        if (!IsValid()) {
//            return Valid();
//        }

        location.href = location.href;

        if (window.evalscript != "") {
            eval(window.evalscript);
        }
    }

    function Cancel() {
        document.body.removeChild(parent.document.getElementById("bgDiv"));
        document.body.removeChild(parent.document.getElementById("msgDiv"));

        try {
            document.getElementById("list_LotteryNumber").style.display = "";
        } catch (e) { }

        return false;
    }

    function UserInit() {
        if (document.getElementById("imCheckCode") != null) {
            var o_CheckCode = document.getElementById("Login_Iframe").contentWindow.document.getElementById("ShoveCheckCode1_imgCode");
            document.getElementById("imCheckCode").src = o_CheckCode.src;
        }
    }

    function UpdateBindData() {

        var Balance = Home_Room_UserControls_WebHead.UpdateBindData().value;
        document.getElementById("lbUserBalance").innerText = Balance;
    }

    //获取用户余额
    function getBalance() {
        return Home_Room_UserControls_WebHead.UpdateBindData().value;
    }

    function Valid() {

        try {
            document.getElementById("list_LotteryNumber").style.display = "none";
        } catch (e) { }

        var msgw, msgh, bordercolor;
        msgw = 400; //提示窗口的宽度 
        msgh = 450; //提示窗口的高度 
        //titleheight=25 //提示窗口标题高度 
        //bordercolor="#336699";//提示窗口的边框颜色 
        //titlecolor="#99CCFF";//提示窗口的标题颜色 

        var sWidth, sHeight;
        sWidth = document.body.offsetWidth;
        sHeight = document.body.offsetHeight;
        var bgObj = document.createElement("div");
        bgObj.setAttribute('id', 'bgDiv');
        bgObj.style.position = "absolute";
        bgObj.style.top = "0";
        bgObj.style.background = "#777";
        bgObj.style.filter = "progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75";
        bgObj.style.opacity = "0.6";
        bgObj.style.left = "0";
        bgObj.style.width = sWidth + "px";
        bgObj.style.height = sHeight + "px";
        bgObj.style.zIndex = "10000";
        document.body.appendChild(bgObj);

        var msgObj = document.createElement("div")
        msgObj.setAttribute("id", "msgDiv");
        msgObj.setAttribute("align", "center");
        msgObj.style.backcolor = "white";
        msgObj.style.position = "absolute";
        msgObj.style.left = "50%";
        msgObj.style.top = "20%";
        msgObj.style.font = "12px/1.6em Verdana, Geneva, Arial, Helvetica, sans-serif";
        msgObj.style.marginLeft = "-225px";
        msgObj.style.marginTop = document.documentElement.scrollTop + "px";
        msgObj.style.width = msgw + "px";
        msgObj.style.height = msgh + "px";
        msgObj.style.textAlign = "center";
        msgObj.style.lineHeight = "25px";
        msgObj.style.zIndex = "10001";

        document.body.appendChild(msgObj);

        var txt = document.createElement("p");
        txt.style.margin = "1em 0"
        txt.setAttribute("id", "msgTxt");

        var s_str = "<table style='border:black 1px solid; width:350px;background-color:white;' cellspacing=\"0\" cellpadding=\"0\"><tr><td style='padding-top:40px;padding-left:20px'><img src=\"Home/Room/images/valid.bmp\"></td>";
        s_str += "<td  style='color:#000000; font-size:13px;width:250px;padding-top:40px;padding-right:10px'>亲爱的用户您好！您的账户还未通过安全验证，为了您的账户资金安全，请先完成手机安全验证或激活安全邮箱。谢谢！</td>";
        s_str += "</tr><tr><td style='text-align: center;padding-top:20px;padding-bottom:20px;' colspan='2'><img width='104' height='34' src='Images/btMobileReg.jpg' onclick=\"Cancel();window.location='Home/Room/UserMobileBind.aspx'\"></img>&nbsp;&nbsp;<img width='104' height='34' src='Images/btEmailReg.jpg' onclick=\"Cancel();window.location='Home/Room/UserEmailBind.aspx'\"></img></td></tr></table> ";

        txt.innerHTML = s_str;

        document.getElementById("msgDiv").appendChild(txt);

        return false;
    }

    function IsValid() {
        return Home_Room_UserControls_WebHead.IsValid().value;
    }
</script>

