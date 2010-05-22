<%@ page language="C#" autoeventwireup="false" inherits="Discuz.Web.Admin.forum_userrights, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>无标题页</title>
        <script type="text/javascript" src="../js/common.js"></script>		
	    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
	    <script type="text/javascript" src="../js/modalpopup.js"></script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="ManagerForm">
		        <fieldset>
		            <legend style="background:url(../images/icons/icon42.jpg) no-repeat 6px 50%;">用户权限</legend>
		            <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox" align="left" width="50%">
                            <table width="100%">
                                <tr>
			                        <td style="width: 130px">允许重复评分:</td>
                                    <td>
					                    <cc1:RadioButtonList id="dupkarmarate" runat="server" RepeatLayout="flow" 
					                    HintInfo="选择&amp;quot;是&amp;quot;将允许用户对一个帖子进行多次评分, 默认为&amp;quot;否&amp;quot;" HintTitle="提示">
						                    <asp:ListItem Value="1">是</asp:ListItem>
						                    <asp:ListItem Value="0">否</asp:ListItem>
					                    </cc1:RadioButtonList>
				                    </td>
                                </tr>
                                 <tr>
				                    <td>最大允许的上传附件数:</td>
				                    <td>
					                    <cc1:TextBox ID="maxattachments" runat="server" CanBeNull="必填" HintInfo="最大允许的上传附件数" HintTitle="提示" MaxLength="5" RequiredFieldType="数据校验" Size="6" />
					                    <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ControlToValidate="maxattachments"
					                    ErrorMessage="请输入正整数或者零" ValidationExpression="^[0-9]*$">
                                        </asp:RegularExpressionValidator>
				                    </td>
                                </tr>
                                <tr>
				                    <td>评分时间限制:</td>
				                    <td>
					                    <cc1:TextBox id="karmaratelimit" runat="server"  HintInfo="帖子发表后超过此时间限制其他用户将不能对此帖评分, 版主和管理员不受此限制, 0 为不限制" 
					                    HintTitle="提示" Text="10" RequiredFieldType="数据校验"  CanBeNull="必填" Size="5" MaxLength="4"></cc1:TextBox>(单位:小时)
			                            <asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ControlToValidate="karmaratelimit" 
			                            ErrorMessage="请输入正整数或者零" ValidationExpression="^[0-9]*$">
                                        </asp:RegularExpressionValidator>
				                    </td>
                                </tr>
                                <tr>
				                    <td>收藏夹容量:</td>
                                    <td>
					                    <cc1:TextBox id="maxfavorites" runat="server" CanBeNull="必填"  RequiredFieldType="数据校验" Text=""  Size="8" MaxLength="7" 
					                    HintInfo="允许收藏的最大板块 / 主题数, 默认为100" HintTitle="提示"></cc1:TextBox>
				                        <asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ControlToValidate="maxfavorites" 
				                        ErrorMessage="请输入正整数或者零" ValidationExpression="^[0-9]*$">
                                        </asp:RegularExpressionValidator>
				                    </td>
                                </tr>
                                <tr>
				                    <td>头像最大宽度:</td>
				                    <td>
					                    <cc1:TextBox id="maxavatarwidth" runat="server" CanBeNull="必填"  RequiredFieldType="数据校验" Text="" Size="8"  MaxLength="7" 
					                    HintInfo="用户头像将被缩小到此大小范围之内" HintTitle="提示"></cc1:TextBox>(单位:像素)
				                        <asp:RegularExpressionValidator id="RegularExpressionValidator5" runat="server" ControlToValidate="maxavatarwidth" 
				                        ErrorMessage="请输入正整数或者零" ValidationExpression="^[0-9]*$">
                                        </asp:RegularExpressionValidator>	
				                    </td>
                                </tr>
                                <tr>
				                    <td>主题查看页面显<br />示管理操作否:</td>
                                    <td>
					                    <cc1:RadioButtonList ID="moderactions" runat="server" HintInfo="是否在主题查看页面显示管理操作" HintTitle="提示" RepeatLayout="flow">
						                    <asp:ListItem Value="1">显示</asp:ListItem>
						                    <asp:ListItem Value="0">不显示</asp:ListItem>
					                    </cc1:RadioButtonList>
				                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right" class="panelbox" width="50%">
                            <table width="100%">
			                    <tr>
				                    <td style="width: 130px">投票最大选项数:</td>
                                    <td>
				                        <cc1:TextBox id="maxpolloptions" runat="server" CanBeNull="必填"  RequiredFieldType="数据校验" Text=""  Size="8" 
				                        MaxLength="7" HintInfo="设定发布投票包含的最大选项数" HintTitle="提示"></cc1:TextBox>
			                            <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="maxpolloptions" 
			                            ErrorMessage="请输入正整数或者零" ValidationExpression="^[0-9]*$">
                                        </asp:RegularExpressionValidator>
			                        </td>
			                    </tr>
			                    <tr>
				                    <td>帖子最小字数:</td>
                                    <td>
					                    <cc1:TextBox id="minpostsize" runat="server" CanBeNull="必填"  RequiredFieldType="数据校验" Text=""  Size="8"  MaxLength="7" 
					                    HintInfo="管理组成员可通过&amp;quot;发帖不受限制&amp;quot;设置而不受影响, 0 为不限制" HintTitle="提示"></cc1:TextBox>(单位:字节)
					                    <select onchange="document.getElementById('minpostsize').value=this.value">
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
				                    <td>帖子最大字数:</td>
                                    <td>
					                    <cc1:TextBox id="maxpostsize" runat="server" CanBeNull="必填"  RequiredFieldType="数据校验" Text=""  Size="8" MaxLength="7" 
					                    HintInfo="管理组成员可通过&amp;quot;发帖不受限制&amp;quot;设置而不受影响" HintTitle="提示"></cc1:TextBox>(单位:字节)
					                    <select onchange="document.getElementById('maxpostsize').value=this.value">
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
				                    <td>头像最大字节数:</td>
                                    <td>
					                    <cc1:TextBox id="maxavatarsize" runat="server" CanBeNull="必填"  RequiredFieldType="数据校验" Text=""  Size="8" MaxLength="7" 
					                    HintInfo="用户上传头像不能超过此限制, 0 为不限制" HintTitle="提示"></cc1:TextBox>(单位:字节)
					                    <select onchange="document.getElementById('maxavatarsize').value=this.value">
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
				                    <td>头像最大高度:</td>
				                    <td>
					                    <cc1:TextBox id="maxavatarheight" runat="server" CanBeNull="必填"  RequiredFieldType="数据校验" Text="" Size="8"  MaxLength="7" 
					                    HintInfo="用户头像将被缩小到此大小范围之内" HintTitle="提示"></cc1:TextBox>(单位:像素)
				                        <asp:RegularExpressionValidator id="RegularExpressionValidator6" runat="server" ControlToValidate="maxavatarheight" 
				                        ErrorMessage="请输入正整数或者零" ValidationExpression="^[0-9]*$">
                                        </asp:RegularExpressionValidator>	
				                    </td>
			                    </tr>
			                    <tr>
				                    <td>允许使用HTML标题:</td>					
				                    <td><cc1:CheckBoxList id="UserGroup" Runat="server"  RepeatColumns="2" /></td>
			                    </tr>
                            </table>
                        </td>
                    </tr>
                    </table>
		        </fieldset>	
		        <cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		        <div align="center">
		            <cc1:Button id="SaveInfo" runat="server" Text=" 提 交 "></cc1:Button>
		        </div>
	        </div>	
        </form>
    
    </body>
</html>
