<%@ page language="c#" inherits="Discuz.Web.Admin.searchattchment, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>searchattchment</title>		
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
    </head>

	<body>
		<form id="Form1" method="post" runat="server">
		<div class="ManagerForm">
        <fieldset>
		<legend style="background:url(../images/icons/icon19.jpg) no-repeat 6px 50%;">搜索附件</legend>
		<table cellspacing="0" cellpadding="4" width="100%" align="center">
		    <tr>
                <td class="panelbox" colspan="2">
                    <table width="100%">
                        <tr>                        
					        <td style="width: 110px">所在论坛:</td>
					        <td>
				                <cc1:dropdowntreelist id="forumid" runat="server"></cc1:dropdowntreelist>
				            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td  class="panelbox" align="left" width="50%">
                    <table width="100%">
                        <tr>
					        <td style="width: 110px">附件尺寸小于:</td>
					        <td>
				                  <cc1:TextBox id="filesizemin" runat="server" RequiredFieldType="数据校验" Size="10"></cc1:TextBox>(单位:字节)
				                  <select onchange="document.getElementById('filesizemin').value=this.value">
								        <option value="">请选择</option>
								        <option value="51200">50K</option>
								        <option value="102400">100K</option>
								        <option value="153600">150K</option>
								        <option value="204800">200K</option>
								        <option value="256000">250K</option>
								        <option value="307200">300K</option>
								        <option value="358400">350K</option>
								        <option value="409600">400K</option>
								        <option value="512000">500K</option>
								        <option value="614400">600K</option>
								        <option value="716800">700K</option>
								        <option value="819200">800K</option>
								        <option value="921600">900K</option>
								        <option value="1024000">1M</option>
								        <option value="2048000">2M</option>
								        <option value="4096000">4M</option>								
						            </select>
				            </td>
                        </tr>
                        <tr>
					        <td>被下载次数小于:</td>
					        <td><cc1:TextBox id="downloadsmin" runat="server" Size="6" RequiredFieldType="数据校验"></cc1:TextBox></td>
                        </tr>
                        <tr>
					        <td>发表于多少天前:</td>
					        <td><cc1:TextBox id="postdatetime" runat="server" Size="4" RequiredFieldType="数据校验"></cc1:TextBox></td>
                        </tr>
                        <tr>
					        <td>描述关键字:</td>
					        <td>
				                <cc1:TextBox id="description" runat="server" HintTitle="提示" HintInfo="多关键字中间请用半角逗号 &amp;quot;,&amp;quot; 分割" 
				                RequiredFieldType="暂无校验" Width="200"></cc1:TextBox>
				            </td>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" align="right" width="50%">
                    <table width="100%">
				        <tr>
					        <td style="width: 110px">附件尺寸大于:</td>
					        <td>
				                  <cc1:TextBox ID="filesizemax" runat="server" RequiredFieldType="数据校验" Size="10" />(单位:字节)
				                  <select onchange="document.getElementById('filesizemax').value=this.value">
							            <option value="">请选择</option>
							            <option value="51200">50K</option>
							            <option value="102400">100K</option>
							            <option value="153600">150K</option>
							            <option value="204800">200K</option>
							            <option value="256000">250K</option>
							            <option value="307200">300K</option>
							            <option value="358400">350K</option>
							            <option value="409600">400K</option>
							            <option value="512000">500K</option>
							            <option value="614400">600K</option>
							            <option value="716800">700K</option>
							            <option value="819200">800K</option>
							            <option value="921600">900K</option>
							            <option value="1024000">1M</option>
							            <option value="2048000">2M</option>
							            <option value="4096000">4M</option>									
							        </select>
				            </td>
				        </tr>
				        <tr>
					        <td>被下载次数大于:</td>
					        <td><cc1:TextBox id="downloadsmax" runat="server" RequiredFieldType="数据校验" Size="6" /></td>
				        </tr>
				        <tr>
					        <td>存储文件名:</td>
					        <td><cc1:TextBox id="filename" runat="server" RequiredFieldType="暂无校验" Width="200"></cc1:TextBox></td>
				        </tr>
				        <tr>
					        <td>作者:</td>
					        <td><cc1:TextBox id="poster" runat="server" RequiredFieldType="暂无校验" Width="100"></cc1:TextBox></td>
				        </tr>
                    </table>
                </td>
            </tr>
        </table>
		</fieldset>
		<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		<div class="Navbutton"><cc1:Button id="SaveSearchCondition" runat="server" Text="搜索附件" ButtonImgUrl="../images/search.gif"></cc1:Button></div>
		</div>
		</form>
		
	</body>
</html>
