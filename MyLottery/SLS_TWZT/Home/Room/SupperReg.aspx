<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/SupperReg.aspx.cs" inherits="Home_Room_SupperReg" enableEventValidation="false" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <link href="Style/div.css" rel="stylesheet" type="text/css" />

    <script src="../../../javaScript/Public.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="user_r">
           <table width="778" border="0" cellspacing="0" cellpadding="0">
             
           </table>
           <table width="778" border="0" cellspacing="0" cellpadding="0">
             <tr>
               <td width="25" height="25" align="left" class="black12" style="padding-left:10px;"><img src="images/user_icon_man.gif" width="19" height="15" /></span></td>
               <td align="left" class="black12">
                 <a href="MyIcaile.aspx" target="_top">用户中心</a> &gt;
                 <a href="Invest.aspx" target="_self">我的彩票记录</a> &gt; 申请超级发起人</td>
               <td width="11">&nbsp;</td>
             </tr>
             <tr>
               <td height="2" colspan="3" bgcolor="#cc0000"></td>
             </tr>
           </table>
           <table width="778" border="0" cellspacing="0" cellpadding="0" background="images/zfb_left_bg_2.jpg" style="margin-top:10px;">
             <tr>
               <td width="10" height="33" align="left">&nbsp;</td>
               <td width="125" align="center" background="images/zfb_left_qh_125.jpg" class="white14"><a href="user_我的彩票记录.htm">申请超级发起人</a></td>
               <td width="6">&nbsp;</td>
               <td width="6">&nbsp;</td>
               <td align="center" class="blue14">&nbsp;</td>
               <td width="168" class="black12">&nbsp;</td>
             </tr>
           </table>
           <table width="768" border="0" cellpadding="0" cellspacing="1" bgcolor="#C0DBF9" >
             <tr>
               <td width="17%" height="30" align="right" bgcolor="#F8F8F8" class="black12">超级发起人：<span class="red12"></span></td>
               <td width="83%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left:10px;">
                    <asp:Label ID="lbUserName" runat="server" Text=""></asp:Label>
               </td>
             </tr>
             <tr>
               <td height="30" align="right" bgcolor="#F8F8F8" class="black12">彩种：</td>
               <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left:10px;">
                    <asp:DropDownList ID="ddlLotteries" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLotteries_SelectedIndexChanged">
                    </asp:DropDownList>
                    <%--<select name="select2" id="select3">
                     <option>选择彩种</option>
                     <option>双色球</option>
                     <option>福彩3D</option>
                     <option>时时乐</option>
                     <option>大乐透</option>
                   </select>--%>
               </td>
             </tr>
             <tr>
               <td height="30" align="right" bgcolor="#F8F8F8" class="black12">玩法：</td>
               <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left:10px;"><span class="blue12_2">
                    <asp:DropDownList ID="ddlPlayTypes" runat="server">
                    </asp:DropDownList>
                 <%--<select name="select" id="select">
                   <option>选择玩法</option>
                   <option>单式合买</option>
                   <option>复式合买</option>
                   <option>胆拖合买</option>
                 </select>--%>
               </span></td>
             </tr>
             <tr>
               <td height="30" align="right" bgcolor="#F8F8F8" class="black12">超级发起描述：</td>
               <td align="left" bgcolor="#FFFFFF" class="black12" style="padding:10px;"><label>
                 <textarea name="content" id="textarea" runat="server" cols="45" rows="5"></textarea>
               </label></td>
             </tr>
             <tr>
               <td height="30" align="right" bgcolor="#F8F8F8" class="black12">&nbsp;</td>
               <td align="left" bgcolor="#FFFFFF" class="black12" style="padding:10px;">
                    <ShoveWebUI:ShoveConfirmButton ID="btn_OK" runat="server" OnClick="btn_OK_Click"
                      AlertText="确认申请超级发起人?" style="background-image:url('Images/zfb_bt_queding.jpg');border:0px;width:60px;height:28px;" />
                      &nbsp;&nbsp;&nbsp;
                      <%--<a href="#"><img src="images/zfb_bt_quxiao.jpg" width="60" height="28" border="0" /></a>--%></td>
             </tr>
           </table>
           <table width="768" border="0" cellspacing="1" cellpadding="0"  bgcolor="#D8D8D8" style="margin-top:10px;">
             <tr>
               <td width="775" bgcolor="#FFFEDF" class="red12" style="padding:5px 10px 5px 10px;"> (注意：超级发起人每期最多能发起3个合买方案。) </td>
             </tr>
           </table>
         </div>
    </form>
<!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
