<%@ page language="c#" inherits="Discuz.Web.Admin.forumbatchset, SLS.Club" %>
<%@ Register TagPrefix="uc1" TagName="ForumsTree" Src="../UserControls/forumstree.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>forumbatchset</title>		
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
	</head>
<body>
	<div class="ManagerForm">
	<form id="Form1" method="post" runat="server">	
		<table class="table1" cellspacing="0" cellpadding="4" width="100%" align="center" style="border:solid 1px #cccccc;width:100%; padding: 0px; ">
			<tbody>
				<tr>
				    <td valign="top" width="19%" height="100%">
				        <div style="OVERFLOW: auto;HEIGHT:95%">										
								<uc1:ForumsTree id="Forumtree1" runat="server"  PageName="forumbatchset"  WithCheckBox="true"></uc1:ForumsTree>
					    </div>
					</td>
					<td  width="81%" valign="top" style="border-left:#b1bdcb solid 1px">
					<div style="height:30px">&nbsp; &nbsp; <b>源论坛:</b> <%=__foruminfo.Name%></div>
					<table cellspacing="0" cellpadding="4" width="100%" align="center">
					    <tr>
					        <td colspan="2" class="panelbox">
					            <table width="100%">
					                <tr>
					                    <td style="width:120px;"><input onclick="CheckByName(this.form,'set','setting:')" type="checkbox" name="chkall" id="chkall" />选择复制所有设置/取消</td>
					                </tr>
					            </table>
					        </td>
					    </tr>
                        <tr>
                            <td  class="panelbox" align="left" width="50%">
                                <table width="100%">
                                    <tr>
								        <td style="width:120px;">
								            <input id="setpassword" type="checkbox" checked value="1" name="setpassword" runat="server" />访问本论坛的密码
								        </td>
								        <td>
								            <cc1:TextBox ID="password" runat="server" HintInfo="留空为不需密码" HintTitle="提示"
                                            RequiredFieldType="暂无校验" Width="150px" />
                                        </td>
                                    </tr>
                                    <tr>
								        <td colspan="2">
								            <input id="setpostcredits" type="checkbox" checked value="1" name="settopicscore" runat="server" />应用发主题金币策略
								        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="panelbox" align="right" width="50%">
                                <table width="100%">
                                    <tr>
								        <td style="width:120px;">
								            <input id="setattachextensions" type="checkbox" checked value="1" name="setattachextensions" runat="server" />论坛上传附件类型
								        </td>
								        <td>
								            <cc1:checkboxlist id="attachextensions" runat="server" RepeatColumns="3" HintTitle="提示" 
								            HintInfo="允许在本论坛上传的附件类型,留空为使用用户组及系统默认设置"></cc1:checkboxlist>
								        </td>
                                    </tr>
							        <tr>
								        <td>
								            <input id="setreplycredits" type="checkbox" checked value="1" name="setpostscore" runat="server" />应用发回复金币策略
								        </td>
							        </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="panelbox" colspan="2">
                                <table width="100%">
							        <tr>
								        <td style="width:120px;">
								            <input id="setsetting" type="checkbox" checked value="1" name="setsetting" runat="server" />设置
								        </td>
								        <td>
									        <asp:checkboxlist id="setting" runat="server" Width="100%" RepeatColumns="3" >
										        <asp:ListItem Value="allowsmilies">允许使用表情符</asp:ListItem>
										        <asp:ListItem Value="allowrss">允许RSS</asp:ListItem>
										        <asp:ListItem Value="allowbbcode">允许Discuz!NT代码</asp:ListItem>
										        <asp:ListItem Value="allowimgcode">允许[img]代码</asp:ListItem>
										        <asp:ListItem Value="recyclebin">打开回收站</asp:ListItem>
										        <asp:ListItem Value="modnewposts">发帖需要审核</asp:ListItem>
										        <asp:ListItem Value="jammer">帖子中添加干扰码</asp:ListItem>
										        <asp:ListItem Value="disablewatermark">禁止附件自动水印</asp:ListItem>
										        <asp:ListItem Value="inheritedmod">继承上级论坛或分类的版主设定</asp:ListItem>
										        <asp:ListItem Value="allowthumbnail">主题列表中显示缩略图</asp:ListItem>
									        </asp:checkboxlist>
								        </td>
							        </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="panelbox" colspan="2">
                                <table width="100%">
							        <tr>
								        <td style="width:120px;">
								            <input id="setviewperm" type="checkbox" checked value="1" name="setviewperm" runat="server" />浏览权限设定
								        </td>
								        <td><cc1:checkboxlist id="viewperm" runat="server" RepeatColumns="4" ></cc1:checkboxlist></td>
							        </tr>
							        <tr>
								        <td>
								            <input id="setpostperm" type="checkbox" checked value="1" name="setpostperm" runat="server" />发主题权限设定
								        </td>
								        <td><cc1:checkboxlist id="postperm" runat="server" RepeatColumns="4" ></cc1:checkboxlist></td>
							        </tr>
							        <tr>
								        <td>
								            <input id="setreplyperm" type="checkbox" checked value="1" name="setreplyperm" runat="server" />发回复权限设定
								        </td>
								        <td><cc1:checkboxlist id="replyperm" runat="server" RepeatColumns="4" ></cc1:checkboxlist></td>
							        </tr>
							        <tr>
								        <td>
								            <input id="setgetattachperm" type="checkbox" checked value="1" name="setgetattachperm" runat="server" />下载附件权限设定
								        </td>
								        <td><cc1:checkboxlist id="getattachperm" runat="server" RepeatColumns="4" ></cc1:checkboxlist></td>
							        </tr>
							        <tr>
								        <td>
								            <input id="setpostattachperm" type="checkbox" checked value="1" name="setpostattachperm" runat="server" />上传附件权限设定
								        </td>
								        <td><cc1:checkboxlist id="postattachperm" runat="server" RepeatColumns="4" ></cc1:checkboxlist></td>
							        </tr>
                                </table>
                            </td>                            
                        </tr>
                    </table>
					</td>
				</tr>
			</tbody>
		</table><br />		
		<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
        <div align="center">
            <cc1:Button id="SubmitBatchSet" runat="server" ButtontypeMode="WithImage" Text=" 提 交 " XpBGImgFilePath="../images/"
			ApplyDefaultStyle="false" ButtonImgUrl="../images/ok.gif"></cc1:Button>
		</div>
    </form>
    </div>
    
	</body>
</html>