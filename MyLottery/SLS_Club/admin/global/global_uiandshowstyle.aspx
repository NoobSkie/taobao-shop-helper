<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.uiandshowstyle, SLS.Club" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
	<title>registerandvisit</title>		
	<script type="text/javascript" src="../js/common.js"></script>			    
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
	<script type="text/javascript" src="../js/modalpopup.js"></script>
	<script type="text/javascript">
	    function LoadImage(index)
	    {
	        document.getElementById("preview").src = images[index];
	    }
	</script>
</head>
<body>
	<div class="ManagerForm">
		<form id="Form1" method="post" runat="server">
			<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		    <fieldset>
		        <legend style="background:url(../images/icons/icon18.jpg) no-repeat 6px 50%;">界面与显示方式设置</legend>
			    <table cellspacing="0" cellpadding="4" width="100%" align="center">
			    <tr>
			        <td  class="panelbox" width="50%" align="left">
			            <table width="100%">
			                <tr>
			                    <td style="width: 120px">默认论坛风格:</td>
				                <td>
				                    <cc1:dropdownlist id="templateid" runat="server"  HintTitle="提示" HintInfo="论坛默认的界面风格, 游客和使用默认风格的会员将以此风格显示">
					                </cc1:dropdownlist>
				                </td>
				            </tr>
				            <tr>
                                <td>浏览自动生成:</td>
                                <td>
                                  <cc1:radiobuttonlist id="browsecreatetemplate" runat="server" RepeatLayout="Flow" HintTitle="提示" 
                                    HintInfo="设置当页面模板不存在,用户浏览时是否自动生成.不推荐使用">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                  </cc1:radiobuttonlist>
                                </td>
			                </tr>
			                <tr>					    
				                <td>显示风格下拉菜单:</td>
				                <td>
				                    <cc1:radiobuttonlist id="stylejump" runat="server" RepeatLayout="Flow" HintTitle="提示" 
				                        HintInfo="设置是否在论坛底部显示可用的论坛风格下拉菜单, 用户可以通过此菜单切换不同的论坛风格">
						                <asp:ListItem Value="1">是</asp:ListItem>
						                <asp:ListItem Value="0">否</asp:ListItem>
					                </cc1:radiobuttonlist>
				                </td>				
                            </tr><tr>			    
                                <td>显示最近访问<br />论坛数量:</td>
                                <td>
                                    <cc1:TextBox id="visitedforums" runat="server"  CanBeNull="必填" RequiredFieldType="数据校验" Size="6"  MaxLength="4" HintTitle="提示" 
                                    HintInfo="设置在论坛列表和帖子浏览中, 显示的最近访问过的论坛下拉列表数量, 建议设置为 30 以内, 0 为关闭此功能"></cc1:TextBox>
                                </td>
                            </tr>
                            <tr>
				                <td>最大签名高度:</td>
				                <td>
				                    <cc1:TextBox id="maxsigrows" runat="server" CanBeNull="必填" RequiredFieldType="数据校验"  Size="6" MaxLength="4" HintTitle="提示" 
				                    HintInfo="设置帖子中允许显示签名的最大高度, 0 为不限制. 注意: 本限制只对 IE 浏览器有效"></cc1:TextBox>(单位:行)
				                </td>
                            </tr>
                            <tr>
					            <td>是否显示签名:</td>
					            <td>
					                <cc1:radiobuttonlist id="showsignatures" runat="server" RepeatLayout="Flow" HintTitle="提示" HintInfo="是否在帖子中显示会员签名">
							            <asp:ListItem Value="1">是</asp:ListItem>
							            <asp:ListItem Value="0">否</asp:ListItem>
						            </cc1:radiobuttonlist>
					            </td>
                            </tr>
                            <tr>
					            <td>是否显示图片:</td>
					            <td>
					                <cc1:radiobuttonlist id="showimages" runat="server" RepeatLayout="Flow" HintTitle="提示" HintInfo="是否在帖子中显示图片(包括上传的附件图片和 [img] 代码图片)">
							            <asp:ListItem Value="1">是</asp:ListItem>
							            <asp:ListItem Value="0">否</asp:ListItem>
						            </cc1:radiobuttonlist>
					            </td>
                            </tr>
                            <tr>
				                <td>显示可点击表情符:</td>
                                <td>
						            <cc1:RadioButtonList id="smileyinsert" runat="server" HintInfo="发帖页面包含表情符快捷工具, 点击图标即可插入表情符" HintTitle="提示" RepeatLayout="flow">
							            <asp:ListItem Value="1">是</asp:ListItem>
							            <asp:ListItem Value="0">否</asp:ListItem>
						            </cc1:RadioButtonList>
					            </td>
                            </tr>
                            <tr>
				                <td>帖子中显示作者状态:</td>
				                <td>
						            <cc1:RadioButtonList id="showauthorstatusinpost" runat="server"  RepeatColumns="1" HintTitle="提示" 
						            HintInfo="浏览帖子时显示作者在线状态, 如果在线用户数量较多时, 启用&amp;quot;精确判断作者在线状态&amp;quot;功能会加重服务器负担, 此时建议使用&amp;quot;简单判断作者在线状态&amp;quot;">
							            <asp:ListItem Value="1" selected="true">简单判断作者在线状态并显示(推荐)</asp:ListItem>
							            <asp:ListItem Value="2">精确判断作者在线状态并显示</asp:ListItem>
						            </cc1:RadioButtonList>
					            </td>
                            </tr>
                            <tr>
					            <td>显示论坛跳转菜单:</td>
					            <td>
						            <cc1:RadioButtonList id="forumjump" runat="server"  RepeatLayout="flow" HintTitle="提示" 
						            HintInfo="选择&amp;quot;是&amp;quot;将在列表页面下部显示快捷跳转菜单. 只有在本设置启用时JS菜单中的论坛跳转设置才有效. 注意: 当分论坛很多时, 本功能会严重加重服务器负担">
							            <asp:ListItem Value="1">是</asp:ListItem>
							            <asp:ListItem Value="0">否</asp:ListItem>
						            </cc1:RadioButtonList>
					            </td>
                            </tr>
                            <tr>
					            <td>查看新帖时间(分钟):</td>
					            <td>
					                <cc1:TextBox id="viewnewtopicminute" runat="server" Size="5" MaxLength="5" HintTitle="提示" HintInfo="设置多长时间内发布的帖子算是新帖" 
					                MinimumValue="5" MaximumValue="14400"></cc1:TextBox>
					            </td>
                            </tr>
                            <tr>
                                <td>是否开启左右分栏:</td>
                                <td>
                                    <cc1:radiobuttonlist id="isframeshow" runat="server" RepeatLayout="Flow" RepeatColumns="1" HintTitle="提示" 
				                        HintInfo="开启此功能后，论坛的头部会出现切换的链接(平板模式/分栏模式)" HintTopOffSet="-100">
						                <asp:ListItem Value="0">关闭</asp:ListItem>
						                <asp:ListItem Value="1">开启，默认为平板模式</asp:ListItem>
						                <asp:ListItem Value="2">开启，默认为分栏模式</asp:ListItem>
					                </cc1:radiobuttonlist>
                                </td>
                            </tr>
			            </table>			        
			        </td>
			        <td  class="panelbox" width="50%" align="right">
			            <table width="100%">
                            <tr>
                              <td style="width: 110px">选择模板预览:</td>
                              <td><img id="preview" runat="server" alt="选择模板预览" src="../../templates/default/about.png" /></td>
                            </tr>
		                    <tr>
				                <td>版主显示方式:</td>
                                <td>
                                    <cc1:radiobuttonlist id="moddisplay" runat="server" RepeatLayout="Flow" HintTitle="提示" HintInfo="首页论坛列表中版主显示方式">
                                        <asp:ListItem Value="1">下拉菜单</asp:ListItem>
                                        <asp:ListItem Value="0">平面显示</asp:ListItem>
                                    </cc1:radiobuttonlist>
                                </td>
			                </tr>
			                <tr>
					            <td>是否显示头像:</td>
					            <td>
					                <cc1:radiobuttonlist id="showavatars" runat="server" RepeatLayout="Flow" HintTitle="提示" HintInfo="是否在帖子中显示会员头像">
							            <asp:ListItem Value="1">是</asp:ListItem>
							            <asp:ListItem Value="0">否</asp:ListItem>
						            </cc1:radiobuttonlist>
					            </td>
				            </tr>
			                <tr>
					            <td>帖子中同一表情符<br />出现的最大次数:</td>
					            <td>
					                <cc1:TextBox id="smiliesmax" runat="server" RequiredFieldType="数据校验" CanBeNull="必填" Width="60px" size="6" MaxLength="4" HintTitle="提示" HintInfo="设置在帖子中出现同一表情的次数,默认值为5"></cc1:TextBox>
					             </td>
				            </tr>
				            
				            <tr>
					            <td>显示在线用户:</td>
					            <td>
						            <cc1:RadioButtonList id="whosonlinestatus" runat="server"  RepeatColumns="1" HintTitle="提示" 
						            HintInfo="在首页和论坛列表页显示在线会员列表(最大在线超过 500 人系统将自动缩略显示在线列表)">
							            <asp:ListItem Value="0">不显示</asp:ListItem>
							            <asp:ListItem Value="1">仅在首页显示</asp:ListItem>
							            <asp:ListItem Value="2">仅在分论坛显示</asp:ListItem>
							            <asp:ListItem Value="3">在首页和分论坛显示</asp:ListItem>
						            </cc1:RadioButtonList>
					            </td>
				            </tr>
				            <tr>
					            <td>在线列表是否隐藏游客:</td>
					            <td>
						            <cc1:RadioButtonList id="whosonlinecontact" runat="server" RepeatLayout="Flow" HintTitle="提示" 
						            HintInfo="在线列表是否隐藏游客">
							            <asp:ListItem Value="1">是</asp:ListItem>
							            <asp:ListItem Value="0">否</asp:ListItem>
						            </cc1:RadioButtonList>
					            </td>
				            </tr>
				            <tr>
					            <td>最多显示在线人数:</td>
					            <td>
						            <cc1:TextBox id="maxonlinelist" runat="server" RequiredFieldType="数据校验" CanBeNull="必填" Size="5" MaxLength="4" HintTitle="提示" 
						            HintInfo="此设置只有在显示在线用户启用时才有效. 设置为0则为不限制"></cc1:TextBox>
					            </td>
				            </tr>
				            <tr>
					            <td>无动作离线时间:</td>
					            <td>
						            <cc1:TextBox id="onlinetimeout" runat="server" RequiredFieldType="数据校验" CanBeNull="必填" Size="5" Text="10" MaxLength="4" HintTitle="提示" 
						            HintInfo="多久无动作视为离线, 默认为10"></cc1:TextBox>(单位:分钟)
					            </td>
				            </tr>
			            </table>
			        </td>
			    </tr>
			    </table>
		    </fieldset>
		    <div class="Navbutton">
		        <cc1:Button id="SaveInfo" runat="server" Text=" 提 交 "></cc1:Button>
		    </div>
		</form>
	</div>			
	
</body>
</html>
