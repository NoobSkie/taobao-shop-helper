<%@ control language="C#" autoeventwireup="true" CodeFile="UserMyIcaile.ascx.cs" inherits="Home_Room_UserControls_UserMyIcaile" %>
<link href="../Style/css.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .blue14
    {
        font-size: 14px;
        color: #0066BA;
        font-family: "tahoma";
        line-height: 20px;
    }
    .blue14 A:link
    {
        font-family: "tahoma";
        color: #0066BA;
        text-decoration: none;
    }
    .blue14 A:active
    {
        font-family: "tahoma";
        color: #0066BA;
        text-decoration: none;
    }
    .blue14 A:visited
    {
        font-family: "tahoma";
        color: #0066BA;
        text-decoration: none;
    }
    .blue14 A:hover
    {
        font-family: "tahoma";
        color: #0066BA;
        text-decoration: none;
    }
</style>

<script type="text/javascript">
    var lastCheckMenu = null;

    function mOver(obj, styleClass) {
        if (obj != lastCheckMenu) {
            obj.className = styleClass;
        }
    }

    function mOut(obj, styleClass) {
        if (obj != lastCheckMenu) {
            obj.className = styleClass;
        }
    }
    function isLoginsas() {
        if (Home_Room_UserControls_UserMyIcaile.isLoginsas().value == null) {
            return false;
        }
        else {
            return true;
        }
    }

    function GetBackUrl(url) {
        return Home_Room_UserControls_UserMyIcaile.GetBackUrl(url).value;
    }



    function mClick(obj, url, styleClass, isNeedLogin) {
        var result;

        if (!isLoginsas()) {
            if (url == "") {
                if (lastCheckMenu != null) {
                    lastCheckMenu.className = "mOut";
                }

                obj.className = styleClass;
                lastCheckMenu = obj;
            }
            else {
                if (isNeedLogin) {
                    location.href = "/UserLogin.aspx?Rollback=" + GetBackUrl(url);
                }

                if (result || isNeedLogin == false) {
                    if (lastCheckMenu != null) {
                        lastCheckMenu.className = "mOut";
                    }

                    obj.className = styleClass;
                    lastCheckMenu = obj;
                }
            }
        }
        else {
            if (url == "") {
                if (lastCheckMenu != null) {
                    lastCheckMenu.className = "mOut";
                }

                obj.className = styleClass;
                lastCheckMenu = obj;
            }
            else {

                if (isNeedLogin) {
                    //登陆后..
                    result = CreateLogin("document.mainFrame.location.href='" + url + "';");
                }

                if (result || isNeedLogin == false) {
                    if (lastCheckMenu != null) {
                        lastCheckMenu.className = "mOut";
                    }

                    obj.className = styleClass;
                    lastCheckMenu = obj;
                    //登陆后..
                    document.getElementById("mainFrame").src = url;
                }
            }
        }

    }


    function mOver(obj, type) {
        if (type == 1) {
            obj.style.textDecoration = "none";
            obj.style.color = "#FF0065";
        }
        else {
            obj.style.textDecoration = "none";
            obj.style.color = "#226699";


        }
    }

    function clickTabMenu(obj, backgroundImage, tabId) {
        var tabMenu = obj.offsetParent.cells;
        var tabContent = document.getElementById(tabId).cells;
        for (var i = 0; i < tabMenu.length; i++) {
            if (obj == tabMenu[i]) {
                obj.style.backgroundImage = backgroundImage;
                tabContent[i].style.display = "";
            }
            else {
                tabMenu[i].style.backgroundImage = "";
                tabContent[i].style.display = "none";
            }
        }
    }
    
    
</script>

<asp:HiddenField ID="HidUserID" runat="server" Value="-1" />
<asp:HiddenField ID="HidScript" runat="server" Value="" />
<table cellpadding="0" cellspacing="0" style="width: 100%;">
    <tr>
        <td>
            <table width="148" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="35" height="27" align="left" bgcolor="#F4F9FC">
                        <img src="<%=ResolveUrl("~/Home/Room/images/icon_5.gif") %>" width="19" height="20"
                            style="margin-left: 8px;" />
                    </td>
                    <td align="left" height="34" bgcolor="#F4F9FC" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)"
                        class="blue14">
                        <strong>我的账户</strong>
                    </td>
                </tr>
            </table>
            <table width="148" border="0" cellspacing="0" cellpadding="0" style="margin-top: 8px;
                margin-bottom: 7px">
                <tr>
                    <td width="23" height="27" align="center">
                        &nbsp;
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a href="<%=ResolveUrl("../OnlinePay/Default.aspx") %>"><%=Shove._Web.Utility.GetUrl() == "http://caipiao1.58.com"?"彩票":""%>帐户充值</a>
                    </td>
                </tr>
               <%-- <tr>
                    <td height="27" align="right">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a href="<%=ResolveUrl("../OnlinePay/CardPassword/Default.aspx") %>"><%=Shove._Web.Utility.GetUrl() == "http://caipiao1.58.com"?"彩票":""%>卡密充值</a>
                    </td>
                </tr>--%>
                <tr>
                    <td height="27" align="right">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a href="<%=ResolveUrl("~/Home/Room/Distill.aspx") %>">我要提款 </a>
                    </td>
                </tr>
             <%--   <tr>
                    <td colspan="2" align="center" height="15">
                        <hr width="140" style="height: 1px; color: #BCD2E9;" />
                    </td>
                </tr>--%>
                <tr>
                    <td height="27" align="right">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a href="<%=ResolveUrl("~/Home/Room/ViewAccount.aspx") %>"><%=Shove._Web.Utility.GetUrl() == "http://caipiao1.58.com"?"彩票":""%>账户全览</a>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="right">
                    </td>
                    <td align="left" height="22" id="td_Accountdetails" class="blue14" style="font-weight: normal;">
                        <a href="<%=ResolveUrl("~/Home/Room/AccountDetail.aspx") %>"><%=Shove._Web.Utility.GetUrl() == "http://caipiao1.58.com"?"彩票":""%>账户交易明细</a>
                    </td>
                </tr>
                 
                 <%-- <tr>
                    <td height="27" align="right">
                    </td>
                    <td align="left" height="22" id="td1" class="blue14" style="font-weight: normal;">
                        <a href="<%=ResolveUrl("~/Home/Room/UserLogOut.aspx") %>">账户注销</a>
                    </td>
                </tr>--%>
                <tr >
                        <td style="width:69px; height:8px;" colspan="2" >
                        &nbsp
                        </td>
                        </tr>
            </table>
            <table width="148" border="0" cellspacing="0" cellpadding="0" style="border-top: 1px solid #BCD2E9;">
                <tr>
                    <td width="35" height="27" align="left" bgcolor="#F4F9FC">
                        <img src="<%=ResolveUrl("~/Home/Room/images/icon_6.gif") %>" width="18" height="19"
                            style="margin-left: 8px;" />
                    </td>
                    <td height="34" bgcolor="#F4F9FC" class="blue14" align="left" onmouseover="mOver(this,1)"
                        onmouseout="mOver(this,2)">
                        <strong>我的彩票记录</strong>
                    </td>
                </tr>
            </table>
            <table width="148" border="0" cellspacing="0" cellpadding="0" style="margin-top: 8px;
                margin-bottom: 7px">
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" id="td_Accountdetails" class="blue14" style="font-weight: normal;">
                        <a href="<%=ResolveUrl("~/Home/Room/Invest.aspx") %>">中奖查询</a>
                    </td>
                </tr>
                <tr>
                    <td height="25" align="center" width="25">
                    </td>
                    <td align="left" height="22" id="td_Accountdetails" class="blue14" style="font-weight: normal;">
                        <a href="<%=ResolveUrl("~/Home/Room/FollowSchemeHistory.aspx") %>">我的自动跟单</a>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a href="<%=ResolveUrl("~/Home/Room/ViewChase.aspx") %>">我的追号 </a>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a href="<%=ResolveUrl("~/Home/Room/Message.aspx") %>">我的站内信 </a>
                    </td>
                </tr>
            </table>
            <table width="148" border="0" cellspacing="0" cellpadding="0" style="border-top: 1px solid #BCD2E9;">
                <tr>
                    <td width="35" height="27" align="left" bgcolor="#F4F9FC">
                        <img src="<%=ResolveUrl("~/Home/Room/images/user_icon_man.gif")%>" width="19" height="16"
                            style="margin-left: 8px;" />
                    </td>
                    <td height="34" bgcolor="#F4F9FC" class="blue14" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)">
                        <strong>我的资料</strong>
                    </td>
                </tr>
            </table>
            <table width="148" border="0" cellspacing="0" cellpadding="0" style="margin-top: 8px;">
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td width="116" align="left" height="22" class="blue14" style="font-weight: normal">
                        <a target="_parent" href="<%=ResolveUrl("~/Home/Room/UserEdit.aspx") %>">修改基本资料</a>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" class="red14" style="font-weight: normal;">
                        <a target="_parent" href="<%=ResolveUrl("~/Home/Room/UserMobileBind.aspx") %>" title=" 2009年11月8日后 ，通过账户安全验证（手机安全验证或保密邮箱激活）的会员才能进行正常投注。">手机验证</a>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" class="red14" style="font-weight: normal;">
                        <a target="_parent" href="<%=ResolveUrl("~/Home/Room/UserEmailBind.aspx") %>"  title=" 2009年11月8日后 ，通过账户安全验证（手机安全验证或保密邮箱激活）的会员才能进行正常投注。">邮箱激活</a>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a target="_parent" href="<%=ResolveUrl("~/Home/Room/EditPassWord.aspx") %>">修改<%=Shove._Web.Utility.GetUrl() == "http://caipiao1.58.com"?"交易":""%>密码
                        </a>
                    </td>
                </tr>
                
                <%-- <tr>
                            <td colspan="2" align="center" height="10">
                                <hr width="140" style="height: 1px; color: #BCD2E9;" />
                            </td>
                        </tr>  --%>
                        <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a target="_parent" href="<%=ResolveUrl("~/Home/Room/SafeSet.aspx?FromUrl=SafeSet.aspx") %>">设置安全问题</a>
                    </td>
                </tr>
              <%--  <tr>
                    <td colspan="2" align="center" height="15">
                        <hr width="140" style="height: 1px; color: #BCD2E9;" />
                    </td>
                </tr>--%>
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a target="_parent" href="<%=ResolveUrl("~/Home/Room/BindBankCard.aspx") %>">绑定银行卡
                        
                        
                        </a>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a target="_parent" href="<%=ResolveUrl("~/Home/Room/BindAlipay.aspx") %>">绑定支付宝</a>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a target="_parent" href="<%=ResolveUrl("~/Home/Room/UserQQBind.aspx") %>">绑定QQ号码</a>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a target="_parent" href="<%=ResolveUrl("~/Home/Room/ExpertsReg.aspx") %>">专家申请</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" height="15">
                        <hr width="140" style="height: 1px; color: #BCD2E9;" />
                    </td>
                </tr>
            </table>
            <div id="divPromotion" runat="server">
             <table width="148" border="0" cellspacing="0" cellpadding="0" style="border-top: 1px solid #BCD2E9;">
                <tr>
                    <td width="35" height="27" align="left" bgcolor="#F4F9FC">
                        <img src="<%=ResolveUrl("~/Home/Room/images/icon_13.gif")%>" width="19" height="16"
                            style="margin-left: 8px;" />
                    </td>
                    <td height="34" bgcolor="#F4F9FC" class="blue14" onmouseover="mOver(this,1)" onmouseout="mOver(this,2)">
                        我的推广(<font color="red">佣金</font>)
                    </td>
                </tr>
            </table>
            <table width="148" border="0" cellspacing="0" cellpadding="0" style="margin-top: 8px;">
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td width="116" align="left" height="22" class="blue14" style="font-weight: normal">
                        <a target="_parent" href="<%=ResolveUrl("~/Home/Room/MyPromotion/MemberPromotion.aspx") %>">我推广的会员</a>
                    </td>
                </tr>
             
                <%--<tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a target="_parent" href="<%=ResolveUrl("~/Home/Room/MyPromotion/SitePromotion.aspx") %>">我推广的站长商家
                        </a>
                    </td>
                </tr>--%>
                <tr>
                    <td height="27" align="center" width="25">
                    </td>
                    <td align="left" height="22" class="blue14" style="font-weight: normal;">
                        <a target="_parent" href="<%=ResolveUrl("~/Home/Room/Distill.aspx?IsCps=1") %>">佣金提款
                        </a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" height="15">
                        <hr width="140" style="height: 1px; color: #BCD2E9;" />
                    </td>
                </tr>
            </table>
            </div>
            <table width="130" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="22" colspan="2" class="blue12">
                        免费<%=Shove._Web.Utility.GetUrl() == "http://caipiao1.58.com"?"彩票":""%>客服电话：
                    </td>
                </tr>
                <tr>
                    <td height="22" colspan="2" class="red14">
                        <%= _Site.ServiceTelephone %>
                    </td>
                </tr>
                <tr>
                    <td height="10" colspan="2" class="blue12">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<div style="display: none;">

    <script src="../JavaScript/Public.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        //document.body.style.height = window.screen.availHeight - window.screenTop - 26;
        eval(document.getElementById("<%=HidScript.ClientID %>").value);
           
    </script>

</div>
