<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.scorestrategy, SLS.Club" %>
<%@ Register TagPrefix="uc1" TagName="PageInfo" Src="../UserControls/PageInfo.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
  <head>
		<title>金币策略</title>
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    </head>
	<body>
		<form id="Form1" method="post" runat="server">
        <uc1:PageInfo id="info1" runat="server" Icon="Information"
        Text="您所编辑的字段必段是在[<a href=../global/global_scoreset.aspx>金币设置</a>]中指定了金币字段的名称, 未指定项无效"></uc1:PageInfo>
        <div class="ManagerForm">
		<fieldset>
		<legend style="background:url(../images/icons/legendimg.jpg) no-repeat 6px 50%;"><a name="#comment"></a><asp:Literal id="Literal1" runat="server"></asp:Literal></legend>
        <table cellspacing="0" cellpadding="4" width="100%" align="center">
		    <tr>
                <td class="panelbox" colspan="2">
                    <table width="100%">
				        <tr>
					        <td style="width: 90px">是否生效:</td>
					        <td>
						        <cc1:RadioButtonList id="available" runat="server">
							        <asp:ListItem Value="True">生效</asp:ListItem>
							        <asp:ListItem Value="False" Selected="True">不生效</asp:ListItem>
						        </cc1:RadioButtonList></td>
				        </tr>
                    </table>
                </td>
            </tr>                        
            <tr>
                <td  class="panelbox" align="left" width="50%">
                    <table width="100%">
                        <tr>
					        <td style="width: 90px">
					            <asp:Literal id="extcredits1name" runat="server" Text="extcredits1"></asp:Literal>:
					        </td>
					        <td>
					            <cc1:TextBox id="extcredits1" runat="server" RequiredFieldType="数据校验" Width="64px" 
					            HintInfo="请在相关字段中设置有效的值(正数为增加量字段值,负数为减少量)"></cc1:TextBox>
					        </td>
                        </tr>
                        <tr>
					        <td>
					            <asp:Literal id="extcredits3name" runat="server" Text="extcredits3"></asp:Literal>:
					        </td>
					        <td>
					            <cc1:TextBox id="extcredits3" runat="server" Width="64px" RequiredFieldType="数据校验" 
					            HintInfo="请在相关字段中设置有效的值(正数为增加量字段值,负数为减少量)"></cc1:TextBox>
					        </td>
                        </tr>
                        <tr>
					        <td>
					            <asp:Literal id="extcredits5name" runat="server" Text="extcredits5"></asp:Literal>:
					        </td>
					        <td>
					            <cc1:TextBox id="extcredits5" runat="server" Width="64px" RequiredFieldType="数据校验" 
					            HintInfo="请在相关字段中设置有效的值(正数为增加量字段值,负数为减少量)"></cc1:TextBox>
					        </td>
                        </tr>
                        <tr>
					        <td>
					            <asp:Literal id="extcredits7name" runat="server" Text="extcredits7"></asp:Literal>:
					        </td>
					        <td>
					            <cc1:TextBox id="extcredits7" runat="server" Width="64px" RequiredFieldType="数据校验" 
					            HintInfo="请在相关字段中设置有效的值(正数为增加量字段值,负数为减少量)"></cc1:TextBox>
					        </td>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" align="right" width="50%">
                    <table width="100%">
				        <tr>
					        <td style="width: 90px">
					            <asp:Literal id="extcredits2name" runat="server" Text="extcredits2"></asp:Literal>:
					        </td>
					        <td>
					            <cc1:TextBox id="extcredits2" runat="server" RequiredFieldType="数据校验" Width="64px" 
					            HintInfo="请在相关字段中设置有效的值(正数为增加量字段值,负数为减少量)"></cc1:TextBox>
					        </td>
				        </tr>
				        <tr>
					        <td>
					            <asp:Literal id="extcredits4name" runat="server" Text="extcredits4"></asp:Literal>:
					        </td>
					        <td>
					            <cc1:TextBox id="extcredits4" runat="server" Width="64px" RequiredFieldType="数据校验" 
					            HintInfo="请在相关字段中设置有效的值(正数为增加量字段值,负数为减少量)"></cc1:TextBox>
					        </td>
				        </tr>
				        <tr>
					        <td>
					            <asp:Literal id="extcredits6name" runat="server" Text="extcredits6"></asp:Literal>:
					        </td>
					        <td>
				                <cc1:TextBox id="extcredits6" runat="server" Width="64px" RequiredFieldType="数据校验" 
				                HintInfo="请在相关字段中设置有效的值(正数为增加量字段值,负数为减少量)"></cc1:TextBox>
				            </td>
				        </tr>
				        <tr>
					        <td>
					            <asp:Literal id="extcredits8name" runat="server" Text="extcredits8"></asp:Literal>:
					        </td>
					        <td>
					            <cc1:TextBox id="extcredits8" runat="server" Width="64px" RequiredFieldType="数据校验" 
					            HintInfo="请在相关字段中设置有效的值(正数为增加量字段值,负数为减少量)"></cc1:TextBox>
					        </td>
				        </tr>
                    </table>
                </td>
            </tr>
        </table>
			</fieldset>
			<div class="Navbutton">
			    <cc1:Button id="SaveInfo" runat="server" Text=" 提 交 "></cc1:Button>&nbsp;&nbsp;
			    <cc1:Button id="DeleteSet" runat="server" Text="删除设置" ButtonImgUrl="../images/del.gif"></cc1:Button>
			</div>
		</div>
		<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		
		</form>
	</body>
</html>
