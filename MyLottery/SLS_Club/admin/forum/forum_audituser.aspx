<%@ page language="c#" inherits="Discuz.Web.Admin.auditnewuser, SLS.Club" autoeventwireup="true" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="PageInfo" Src="../UserControls/PageInfo.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>audituser</title>	
		<link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />		
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
		<script type="text/javascript">
		    function validate(form1)
		    {
		        var regbefore = document.getElementById("regbefore").value;
		        if(regbefore != "" && !/^\d+$/.test(regbefore))
		        {
		            alert("注册时间于多少天前项必须为数字!");
		            document.getElementById("regbefore").value = "";
		            document.getElementById('success').style.display = 'none'
	                document.getElementById("searchuser").disabled = false;
		            return false;
		        }
		        return true;
		    }
		    
		    function Check(form)
		    {
		        CheckAll(form);
		        checkedEnabledButton(form,'uid','SelectPass','SelectDelete');
		    }
		</script>
	</head>
	<body>
			<form id="Form1" method="post" runat="server">
			<uc1:PageInfo id="info1" runat="server" Icon="Information"
             Text="本功能仅在 Discuz!NT 选项 的 &quot;注册与访问控制&quot; - &quot;新用户注册验证&quot; 中设置为 &quot;人工审核&quot; 时才有效"></uc1:PageInfo>
			<div class="ManagerForm">
			<fieldset>
		    <legend style="background:url(../images/icons/icon32.jpg) no-repeat 6px 50%;">查询等待验证用户</legend>
			<table cellspacing="1" cellpadding="4" width="100%" align="center" class="table1">
				<tr>
				    <td style="width: 70px">用户名:</td>
				    <td><cc1:TextBox id="searchusername" runat="server" Width="120px"></cc1:TextBox></td>
					<td style="width: 130px">注册时间于多少天前:</td>
					<td><cc1:TextBox id="regbefore" runat="server" RequiredFieldType="数据校验" Width="50px"></cc1:TextBox></td>
					<td style="width: 160px">注册 IP 开头 (如 192.168):</td>
					<td>
					    <cc1:TextBox id="regip" runat="server" Width="100px" 
					    ValidationExpression="^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])(\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0))*(\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0))*(\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9]))*$" RequiredFieldType="IP地址" >
					    </cc1:TextBox>
					</td>
					<td><cc1:Button id="searchuser" runat="server" Text="查询等待验证用户" ValidateForm="true" onclick="searchuser_Click"/></td>
				</tr>
			</table>
			</fieldset>
			</div>
			<cc1:datagrid id="DataGrid1" runat="server" PageSize="15" OnPageIndexChanged="DataGrid_PageIndexChanged" OnSortCommand="Sort_Grid">
				<Columns>
					<asp:TemplateColumn HeaderText="<input title='选中/取消选' onclick='Check(this.form)' type='checkbox' name='chkall' id='chkall' />">
					    <HeaderStyle Width="20px" />
						<ItemTemplate>
							<input id="uid" onclick="checkedEnabledButton(this.form,'uid','SelectPass','SelectDelete')" type="checkbox" value="<%# DataBinder.Eval(Container, "DataItem.uid").ToString() %>" name="uid" />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="uid" SortExpression="uid"  HeaderText="用户ID" Visible="false"></asp:BoundColumn>
					  <asp:TemplateColumn HeaderText="用户名">
						<ItemTemplate>
							<a href="../../userinfo.aspx?userid=<%# DataBinder.Eval(Container, "DataItem.uid").ToString()%>" target="_blank">
							    <%# DataBinder.Eval(Container, "DataItem.username").ToString()%>
							</a>
							<a href="../global/global_edituser.aspx?uid=<%# DataBinder.Eval(Container, "DataItem.uid").ToString()%>" >[编辑]</a>
						</ItemTemplate>
					</asp:TemplateColumn>
					  <asp:TemplateColumn HeaderText="昵称">
						<ItemTemplate>
							<a href="../global/global_edituser.aspx?uid=<%# DataBinder.Eval(Container, "DataItem.uid").ToString() %>" >
							    <%# DataBinder.Eval(Container, "DataItem.nickname").ToString()%>
							</a>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="joindate" SortExpression="joindate" HeaderText="注册时间" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
					<asp:BoundColumn DataField="regip" SortExpression="regip" HeaderText="注册IP"></asp:BoundColumn>
					<asp:BoundColumn DataField="credits" SortExpression="credits" HeaderText="金币"></asp:BoundColumn>
					<asp:BoundColumn DataField="email" SortExpression="email" HeaderText="邮箱"></asp:BoundColumn>
					<asp:BoundColumn DataField="accessmasks" SortExpression="accessmasks" HeaderText="特殊权限"></asp:BoundColumn>
				</Columns>
			</cc1:datagrid><br />
			<p style="text-align:right;">
			    <cc1:Button id="SelectPass" runat="server" Text="通过选择的用户" Enabled="false"></cc1:Button>&nbsp;&nbsp;
			    <cc1:Button id="SelectDelete" runat="server" Text="删除选择的用户" ButtonImgUrl="../images/del.gif" Enabled="false"></cc1:Button>&nbsp;&nbsp;
			    <cc1:Button id="AllPass" runat="server" Text="全部通过"></cc1:Button>&nbsp;&nbsp;
			    <cc1:Button id="AllDelete" runat="server" Text="全部删除" ButtonImgUrl="../images/del.gif"></cc1:Button>&nbsp;&nbsp;
			    <input type="checkbox" name="sendemail" id="sendemail" value="1" checked="checked" runat="server" />
			    发Email 通知被审核用户
			</p>
		</form>
		
	</body>
</html>
