<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Web/Process/AboutCardPassword.aspx.cs" inherits="Home_Web_Process_AboutCardPassword" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>卡密使用说明-<%=_Site.Name %>欢迎您 ！</title>

    <script type="text/javascript">
<!--
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}
function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
//-->
    </script>

    <style type="text/css">
        .hei121
        {
            font-size: 12px;
            color: #333333;
            line-height: 20px;
        }
        .hei121
        {
            font-size: 12px;
            color: #333333;
            line-height: 20px;
        }
        body
        {
            margin: 0px;
        }
        #box
        {
            overflow: hidden;
            width: 980px;
            margin-right: auto;
            margin-left: auto;
            padding: 0px;
        }
        #head
        {
            width: 980px;
            padding: 0px;
            overflow: hidden;
        }
        #hr
        {
            border-top: 1px dashed #cccccc;
            height: 1px;
            overflow: hidden;
        }
        .content
        {
            width: 980px;
            padding: 0px;
            overflow: hidden;
        }
        .hei12
        {
            font-size: 12px;
            color: #333333;
            line-height: 20px;
        }
        .hei12 A:link
        {
            color: #333333;
            text-decoration: none;
        }
        .hei12 A:active
        {
            color: #333333;
            text-decoration: none;
        }
        .hei12 A:visited
        {
            color: #333333;
            text-decoration: none;
        }
        .hei12 A:hover
        {
            color: #333333;
            text-decoration: underline;
        }
        .font_blue12
        {
            font-size: 12px;
            color: #003399;
            line-height: 20px;
        }
        .font_blue12 A:link
        {
            color: #003399;
            text-decoration: underline;
        }
        .font_blue12 A:active
        {
            color: #003399;
            text-decoration: underline;
        }
        .font_blue12 A:visited
        {
            color: #003399;
            text-decoration: underline;
        }
        .font_blue12 A:hover
        {
            color: #ff6600;
            text-decoration: none;
        }
        .bai12
        {
            font-size: 12px;
            color: #ffffff;
            line-height: 20px;
        }
        .bai12 A:link
        {
            color: #ffffff;
            text-decoration: none;
        }
        .bai12 A:active
        {
            color: #ffffff;
            text-decoration: none;
        }
        .bai12 A:visited
        {
            color: #ffffff;
            text-decoration: none;
        }
        .bai12 A:hover
        {
            color: #ffffff;
            text-decoration: none;
        }
        .hui2
        {
            font-size: 12px;
            color: #999999;
            font-family: "tahoma";
            line-height: 20px;
        }
        .hui2 A:link
        {
            font-family: tahoma;
            color: #999999;
            text-decoration: underline;
        }
        .hui2 A:active
        {
            font-family: "tahoma";
            color: #999999;
            text-decoration: none;
        }
        .hui2 A:visited
        {
            font-family: "tahoma";
            color: #999999;
            text-decoration: none;
        }
        .hui2 A:hover
        {
            font-family: "tahoma";
            color: #ff6600;
            text-decoration: none;
        }
        .blue_menu
        {
            font-size: 12px;
            color: #103875;
            font-family: "tahoma";
            line-height: 20px;
            font-weight: bold;
        }
        .blue_menu A:link
        {
            font-family: "tahoma";
            color: #103875;
            text-decoration: none;
        }
        .blue_menu A:active
        {
            font-family: "tahoma";
            color: #103875;
            text-decoration: none;
        }
        .blue_menu A:visited
        {
            font-family: "tahoma";
            color: #103875;
            text-decoration: none;
        }
        .blue_menu A:hover
        {
            font-family: "tahoma";
            color: #ff6600;
            text-decoration: none;
        }
        .bai14
        {
            font-size: 14px;
            color: #ffffff;
            font-family: "tahoma";
            line-height: 20px;
            font-weight: bold;
        }
        .bai14 A:link
        {
            font-family: "tahoma";
            color: #ffffff;
            text-decoration: none;
        }
        .bai14 A:active
        {
            font-family: "tahoma";
            color: #ffffff;
            text-decoration: none;
        }
        .bai14 A:visited
        {
            font-family: "tahoma";
            color: #ffffff;
            text-decoration: none;
        }
        .bai14 A:hover
        {
            font-family: "tahoma";
            color: #ffff00;
            text-decoration: none;
        }
        img{ vertical-align:top;border: 0px;}
    </style>
</head><link rel="shortcut icon" href="../../../favicon.ico"/>
<body onload="MM_preloadImages('images/bt_1_2.jpg','images/bt_2_2.jpg','images/bt_3_2.jpg','images/bt_4_2.jpg','images/bt_5_2.jpg')">
    <form id="form1" runat="server">
    
    <div id="box">
        <div class="content">
            <div>
                <img src="images/km_r2_c2.jpg" width="980" height="31" /></div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <img src="images/km_r3_c2.jpg" width="637" height="33" />
                    </td>
                    <td>
                        <a href="../../../Default.aspx" target="_blank" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image32','','images/bt_1_2.jpg',1)">
                            <img src="images/bt_1.jpg" alt="#" name="Image32" width="91" height="33" border="0"
                                id="Image32" /></a>
                    </td>
                    <td>
                        <a href="../../Room/MyIcaile.aspx?SubPage=OnlinePay/CardPassword/Default.aspx" target="_blank" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image33','','images/bt_2_2.jpg',1)">
                            <img src="images/bt_2.jpg" name="Image33" width="177" height="33" border="0" id="Image33" /></a>
                    </td>
                    <td>
                        <img src="images/km_r3_c20.jpg" width="75" height="33" />
                    </td>
                </tr>
            </table>
            <div>
                <img src="images/km_r4_c2.jpg" width="980" height="95" /></div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <img src="images/km_r5_c2.jpg" width="801" height="32" />
                    </td>
                    <td>
                            <img src="images/km_r5_c18.jpg" name="Image34" width="117" height="32" border="0" id="Image34" />
                    </td>
                    <td>
                        <img src="images/km_r5_c21.jpg" width="62" height="32" />
                    </td>
                </tr>
            </table>
            <div>
                <img src="images/km_r6_c2.jpg" width="980" height="90" /></div>
            <div style="background-image: url(images/km_980_bg.jpg)">
                <table width="680" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="129">
                            <img src="images/f_1.jpg" width="126" height="31" />
                        </td>
                        <td width="551" class="hei12" style="padding-top: 8px;">
                            1、登录<%=_Site.Name %> 2、选择“购彩大厅” 3、选择“用户中心”4、选择卡密充值 5、充值成功，购买彩票
                        </td>
                    </tr>
                    <tr>
                        <td height="20" colspan="2">
                            <div id="hr">
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="680" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="149">
                            <img src="images/font_1.jpg" width="139" height="39" />
                        </td>
                        <td width="531" class="font_blue12" style="padding-top: 8px;">
                            <span class="hei12">我没有<%=_Site.Name %>账户</span>（<a href="../UserReg.aspx" target="_blank">注册新会员</a> | <a href="#"
                                target="_blank">注册会员图解</a>）
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-top: 10px;">
                            <img src="images/km_pic_1.jpg" width="680" height="200" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="padding: 10px 0px 10px 0px;">
                            <img src="images/km_jiantou.jpg" width="40" height="19" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <img src="images/km_pic_2.jpg" width="680" height="200" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="padding: 10px 0px 10px 0px;">
                            <img src="images/km_jiantou.jpg" width="40" height="19" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <img src="images/km_pic_3.jpg" width="680" height="200" />
                        </td>
                    </tr>
                    <tr>
                        <td height="20" colspan="2">
                            <div id="hr">
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="680" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="149">
                            <img src="images/font_2.jpg" width="180" height="39" />
                        </td>
                        <td style="padding-top: 8px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-top: 10px;">
                            <img src="images/km_pic_4.jpg" width="680" height="200" />
                        </td>
                    </tr>
                    <tr>
                        <td height="20" colspan="2">
                            <div id="hr">
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="680" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="149">
                            <img src="images/font_3.jpg" width="200" height="39" />
                        </td>
                        <td style="padding-top: 8px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-top: 10px;">
                            <img src="images/km_pic_5.jpg" width="680" height="200" />
                        </td>
                    </tr>
                    <tr>
                        <td height="20" colspan="2">
                            <div id="hr">
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="680" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="149">
                            <img src="images/font_4.jpg" width="200" height="39" />
                        </td>
                        <td class="font_blue121" style="padding-top: 8px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-top: 10px;">
                            <img src="images/km_pic_6.jpg" width="680" height="200" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="padding: 10px 0px 10px 0px;">
                            <img src="images/km_jiantou.jpg" width="40" height="19" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <img src="images/km_pic_7.jpg" width="680" height="200" />
                        </td>
                    </tr>
                    <tr>
                        <td height="20" colspan="2">
                            <div id="hr">
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="680" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="120">
                            <img src="images/font_5.jpg" width="120" height="39" />
                        </td>
                        <td width="124" align="right" class="hei121">
                            <a href="../../../Default.aspx" target="_blank" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image35','','images/bt_4_2.jpg',1)">
                                <img src="images/bt_4.jpg" name="Image35" width="99" height="39" border="0" id="Image35" /></a>
                        </td>
                        <td width="162" align="right" class="hei121">
                            <a href="../../Room/MyIcaile.aspx?SubPage=OnlinePay/CardPassword/Default.aspx" target="_blank" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image36','','images/bt_5_2.jpg',1)">
                                <img src="images/bt_5.jpg" name="Image36" width="157" height="39" border="0" id="Image36" /></a>
                        </td>
                        <td width="274" align="right" class="hei121">
                            <img src="images/km_tel.jpg" width="273" height="39" />
                        </td>
                    </tr>
                    <tr>
                        <td height="20" colspan="4">
                            <div id="hr">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <img src="images/km_980_foot.jpg" width="980" height="58" /></div>
        </div>
        <style type="text/css">
            .hui
            {
                font-size: 12px;
                color: #666666;
                font-family: "tahoma";
                line-height: 20px;
            }
            .hui A:link
            {
                font-family: tahoma;
                color: #666666;
                text-decoration: underline;
            }
            .hui A:active
            {
                font-family: "tahoma";
                color: #666666;
                text-decoration: none;
            }
            .hui A:visited
            {
                font-family: "tahoma";
                color: #666666;
                text-decoration: none;
            }
            .hui A:hover
            {
                font-family: "tahoma";
                color: #ff6600;
                text-decoration: none;
            }
        </style>
       
    </div>
    </form>
</body>
</html>
