<%@ control language="C#" autoeventwireup="true" CodeFile="WebFoot.ascx.cs" inherits="Home_Room_UserControls_WebFoot" %>
<style>
    .cyw_menu
    {
        font-size: 12px;
        color: #FFFFFF;
        font-family: "tahoma";
        line-height: 20px;
    }
    .cyw_menu A:link
    {
        font-family: "tahoma";
        color: #FFFFFF;
        text-decoration: none;
    }
    .cyw_menu A:active
    {
        font-family: "tahoma";
        color: #FFFFFF;
        text-decoration: none;
    }
    .cyw_menu A:visited
    {
        font-family: "tahoma";
        color: #FFFFFF;
        text-decoration: none;
    }
    .cyw_menu A:hover
    {
        font-family: "tahoma";
        color: #FFFF00;
        text-decoration: none;
    }
    .qq1
    {
    	background-image: url(<%= ResolveUrl("~/Home/Room/images/qq_t.png") %>);
        filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src='images/qq_t.png', sizingMethod='scale');
        width: 101px;
        height: 28px;
    }
    .qq2
    {
    	background-image: url(<%= ResolveUrl("~/Home/Room/images/qq_b.png") %>);
        filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src='images/qq_b.png', sizingMethod='scale');
        width: 101px;
        height: 22px;
    }
    .qq3
    {
    	background-image: url(<%= ResolveUrl("~/Home/Room/images/qq.jpg") %>);
    	height:30px;
    	padding-left: 25px;
    	FONT-SIZE: 12px;
    	COLOR: #226699; 
    	FONT-FAMILY: "tahoma";
    }
    .qq3 A:link { FONT-FAMILY: "tahoma"; COLOR: #226699; TEXT-DECORATION: none;}
.qq3 A:active { FONT-FAMILY: "tahoma";COLOR: #226699; TEXT-DECORATION: none;}
.qq3 A:visited { FONT-FAMILY: "tahoma";COLOR: #226699; TEXT-DECORATION: none;}
.qq3 A:hover { FONT-FAMILY: "tahoma";COLOR: #FF0065; TEXT-DECORATION: underline;}
</style>
<div style="margin-top: 10px; padding-bottom: 10px;">
    <table width="1002" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;"
        align="center">
        <tr>
            <td width="8" height="40" rowspan="2" background="<%=ResolveUrl("~/Home/Room/images/foot_left_blue.jpg") %>">
                &nbsp;
            </td>
            <td height="36" bgcolor="#669ACC">
                <table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="70" height="36" align="center" class="cyw_menu">
                            <a href="<%=ResolveUrl("~/UserLogin.aspx") %>" target="_blank">用户注册</a>
                        </td>
                        <td width="6" background="<%=ResolveUrl("~/Home/Room/images/foot_line_blue.jpg") %>">
                            &nbsp;
                        </td>
                        <td width="70" align="center" class="cyw_menu">
                            <a href="<%=ResolveUrl("~/BottomNavigationPages/about1.html") %>" target="_blank">关于我们</a>
                        </td>
                        <td width="6" background="<%=ResolveUrl("~/Home/Room/images/foot_line_blue.jpg") %>">
                            &nbsp;
                        </td>
                        <td width="70" align="center" class="cyw_menu">
                            <a href="<%=ResolveUrl("~/BottomNavigationPages/zz1.html") %>" target="_blank">资质荣誉</a>
                        </td>
                        <td width="6" background="<%=ResolveUrl("~/Home/Room/images/foot_line_blue.jpg") %>">
                            &nbsp;
                        </td>
                        <td width="70" align="center" class="cyw_menu">
                            <a href="<%=ResolveUrl("~/BottomNavigationPages/contact.html") %>" target="_blank">联系方式</a>
                        </td>
                        <td width="6" background="<%=ResolveUrl("~/Home/Room/images/foot_line_blue.jpg") %>">
                            &nbsp;
                        </td>
                        <td width="70" align="center" class="cyw_menu">
                            <a href="<%=ResolveUrl("~/BottomNavigationPages/job.html") %>" target="_blank">人才招聘</a>
                        </td>
                        <td width="6" background="<%=ResolveUrl("~/Home/Room/images/foot_line_blue.jpg") %>">
                            &nbsp;
                        </td>
                        <td width="80" align="center" class="cyw_menu">
                            <a href="<%=ResolveUrl("~/BottomNavigationPages/zlhz.html") %>" target="_blank">战略合作</a>
                        </td>
                        <td width="6" background="<%=ResolveUrl("~/Home/Room/images/foot_line_blue.jpg") %>">
                            &nbsp;
                        </td>
                        <td width="70" align="center" class="cyw_menu">
                            <a href="<%=ResolveUrl("~/SiteMap.html") %>" target="_blank">站点地图</a>
                        </td>
                        <td width="6" background="<%=ResolveUrl("~/Home/Room/images/foot_line_blue.jpg") %>">
                            &nbsp;
                        </td>
                        <!--
                            <td width="70" align="center" class="cyw_menu">
                                <a href="<%=ResolveUrl("~/Home/Room/BottomNavigationPages/falv.html") %>" target="_blank">法律声明</a>
                            </td>
                           
                            <td width="6" background="<%=ResolveUrl("~/Home/Room/images/foot_line_blue.jpg") %>">
                                &nbsp;
                            </td> -->
                        <td width="70" align="center" class="cyw_menu">
                            <a href="<%=ResolveUrl("~/BottomNavigationPages/FriendLink.aspx") %>" target="_blank">
                                友情链接</a>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="8" rowspan="2" background="<%=ResolveUrl("~/Home/Room/images/foot_right_blue.jpg") %>">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td height="4" bgcolor="#F0F0F0">
            </td>
        </tr>
    </table>
    <table width="970" border="0" cellspacing="0" cellpadding="0" align="center">
        <tbody>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="hui12" align="center">
                    <span style="margin-top: 10px;">版权所有：<%= _Site.Company %>
                        增值电信业务经营许可证：<a href="images/zz_1.gif" target="_blank">粤B1-20070214</a> ICP备案：粤ICP备08000656号<br />
                        公司地址：<%=_Site.Address%>
                        &nbsp;&nbsp;客服热线：<%= _Site.ServiceTelephone %>
                        &nbsp;&nbsp;邮政编码：<%= _Site.PostCode %>
                        <!-- MENU-LOCATION=NONE -->
                        <!-- MENU-LOCATION=NONE -->
                        <!-- MENU-LOCATION=NONE -->
                        <br />
                        <!--中国.深圳.南山区东滨路与南新路交叉口-->
                        <%--中国.深圳.南山区东滨路与南新路交叉口--%>
                        <span style="text-indent: 30px;"><a href="<%=ResolveUrl("~/BottomNavigationPages/about1.html") %>">
                            <%= _Site.Name %></a></span>&nbsp;郑重提示：彩票有风险，投注需谨慎 不向未满18周岁的青少年出售彩票！</span>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="577" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="155" align="center">
                                <img src="<%=ResolveUrl("~/BottomNavigationPages/images/link_04.gif") %>" width="99"
                                    height="41" />
                            </td>
                            <td width="125" align="center">
                                <img src="<%=ResolveUrl("~/BottomNavigationPages/images/link_05.gif") %>" width="99"
                                    height="41" />
                            </td>
                            <td width="145" align="center">
                                <img src="<%=ResolveUrl("~/BottomNavigationPages/images/link_06.gif") %>" width="99"
                                    height="41" />
                            </td>
                            <td width="65" align="center">
                                <img src="<%=ResolveUrl("~/BottomNavigationPages/images/foot_logo_6.jpg") %>" width="41"
                                    height="49" />
                            </td>
                            <td width="61" align="center">
                                <img src="<%=ResolveUrl("~/BottomNavigationPages/images/foot_logo_4.jpg") %>" width="30"
                                    height="49" />
                            </td>
                            <td width="6" height="55">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;
                </td>
            </tr>
        </tbody>
    </table>
</div>

<script type="text/javascript" language="JavaScript">
    suspendcode = "<DIV id=lovexin1 style='Z-INDEX: 10; LEFT: 6px; POSITION: absolute; TOP: 220px; width: 100; height: 300px;'>";    
    suspendcode += "</DIV>";
    //document.write(suspendcode);

    suspendcode += "<DIV id=lovexin2 style='Z-INDEX: 10; right: 10px; POSITION: absolute; TOP: 220px; width: 100; height: 300px;' align='center'>";
    suspendcode += "<table border='0' width='101' cellspacing='0' cellpadding='0'>";
    suspendcode += "<tr>";
    suspendcode += "<td class='qq1'></td>";
    suspendcode += "</tr>";
    suspendcode += "<tr>";
    suspendcode += "<td align='left' class='qq3'><a href='http://wpa.qq.com/msgrd?V=1&Uin=80069987&Site=sansun&Menu=yes' target='_blank'>客服1</a></td>";
    suspendcode += "</tr>";
    suspendcode += "<tr>";
    suspendcode += "<td align='left' class='qq3'><a href='http://wpa.qq.com/msgrd?V=1&Uin=595795&Site=sansun&Menu=yes' target='_blank'>客服2</a></td>";
    suspendcode += "</tr>";
    suspendcode += "<tr>";
    suspendcode += "<td align='left' class='qq3'><a href='http://wpa.qq.com/msgrd?V=1&Uin=343900769&Site=sansun&Menu=yes' target='_blank'>客服3</a></td>";
    suspendcode += "</tr>";
    suspendcode += "<tr>";
    suspendcode += "<td align='left' class='qq3'><a href='http://wpa.qq.com/msgrd?V=1&Uin=1010608428&Site=sansun&Menu=yes' target='_blank'>客服4</a></td>";
    suspendcode += "</tr>";
    suspendcode += "<tr>";
    suspendcode += "<td align='left' class='qq3'><a href='http://wpa.qq.com/msgrd?V=1&Uin=157895953&Site=sansun&Menu=yes' target='_blank'>客服5</a></td>";
    suspendcode += "</tr>";
    suspendcode += "<tr>";
    suspendcode += "<td class='qq2' style='cursor: hand;' onclick='javascript:lovexin2.style.display=\"none\";'></td>";
    suspendcode += "</tr>";
    suspendcode += "</table>";
    suspendcode += "</DIV>";

    document.write(suspendcode);

    var originalTop = parseInt(document.getElementById("lovexin1").style.top);
    function heartBeat(){
        var diffY = document.body.scrollTop||document.documentElement.scrollTop;
        var percent = (diffY + originalTop - document.getElementById("lovexin1").offsetTop)/10;
        percent = percent>0? Math.ceil(percent):Math.floor(percent);
        document.getElementById("lovexin1").style.top = document.getElementById("lovexin2").style.top = document.getElementById("lovexin1").offsetTop + percent + "px";
    }
    function hide()  {   
        lovexin1.style.visibility = "hidden"; 
        lovexin2.style.visibility = "hidden";
    }
    window.setInterval(heartBeat,10);
</script>

