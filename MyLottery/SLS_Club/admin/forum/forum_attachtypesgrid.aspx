<%@ page language="c#" inherits="Discuz.Web.Admin.attachtypesgrid, SLS.Club" autoeventwireup="false" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="cc2" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="PageInfo" Src="../UserControls/PageInfo.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>上传附件类型列表</title>
		<link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" /> 
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
        <script type="text/javascript">
            function Check(form)
            {
                CheckAll(form);
                checkedEnabledButton(form,'id','DelRec')
            }
        </script>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:PageInfo id="info1" runat="server" Icon="information"
            Text="本功能可限定某特定类型附件的最大尺寸, 当这里设定的尺寸小于用户组允许的最大尺寸时, 指定类型的附件尺寸限制将按本设定为准"></uc1:PageInfo>
            <uc1:PageInfo ID="info2" runat="server" Icon="warning"
            Text="附件是否有效可在版块及用户组中设置, 且具体版块设置优先于用户组设置" />
			<cc1:datagrid id="DataGrid1" runat="server" IsFixConlumnControls="true"	OnPageIndexChanged="DataGrid_PageIndexChanged" OnSortCommand="Sort_Grid">
				<Columns>
				    <asp:TemplateColumn HeaderText="<input title='选中/取消' onclick='Check(this.form)' type='checkbox' name='chkall' id='chkall'>">
				        <HeaderStyle Width="20px" />
						<ItemTemplate>
							<input id="id" onclick="checkedEnabledButton(this.form,'id','DelRec')" type="checkbox" value="<%# DataBinder.Eval(Container, "DataItem.id").ToString() %>"	name="id" />
							<%# DataGrid1.LoadSelectedCheckBox(DataBinder.Eval(Container, "DataItem.id").ToString())%>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="id" SortExpression="id" HeaderText="id [递增]" Visible="false"></asp:BoundColumn>
					<asp:BoundColumn DataField="extension" SortExpression="extension" HeaderText="扩展名"></asp:BoundColumn>
					<asp:BoundColumn DataField="maxsize" SortExpression="maxsize" HeaderText="最大尺寸(单位:字节)"></asp:BoundColumn>
				</Columns>
			</cc1:datagrid>
			<p style="text-align:right;">
	            <cc1:Button id="SaveAttachType" runat="server" Text="保存附件修改"></cc1:Button>&nbsp;&nbsp;
				<cc1:Button id="DelRec" runat="server" Text=" 删 除 "  ButtonImgUrl="../images/del.gif" Enabled="false"></cc1:Button>&nbsp;&nbsp;
				<button type="button" class="ManagerButton" id="Button2" onclick="BOX_show('neworedit');"><img src="../images/add.gif"/> 添加附件类型 </button>
	        </p>
	    <div id="BOX_overlay" style="background: #000; position: absolute; z-index:100; filter:alpha(opacity=50);-moz-opacity: 0.6;opacity: 0.6;"></div>
        <div id="neworedit" style="display: none; background :#fff; padding:10px; border:1px solid #999; width:350px;">
		<div class="ManagerForm">
        <fieldset>
		<legend style="background:url(../images/icons/icon50.jpg) no-repeat 6px 50%;">添加附件类型</legend>
			<table cellspacing="0" cellPadding="4" class="table1" align="center" width="100%">
				<tr>
					<td style="width: 70px;height:35px;">扩展名:</td>
					<td>
						<cc2:TextBox id="extension" runat="server" RequiredFieldType="暂无校验" IsReplaceInvertedComma="true" MaxLength="15" Size="15" HintInfo="允许上传的附件类型,不用输入&quot;.&quot;"></cc2:TextBox>
					</td>
				</tr>
				<tr>
					<td style="height:35px;">最大尺寸:</td>
					<td>
						<cc2:TextBox id="maxsize" runat="server" RequiredFieldType="数据校验"  size="9" MaxLength="8"></cc2:TextBox>(单位:字节)
						<select onchange="document.getElementById('maxsize').value=this.value">
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
					<td colspan="2" align="center" style="height:35px;">
					    <cc1:Button id="AddNewRec" runat="server" Text=" 提 交 "></cc1:Button>&nbsp;&nbsp;
					    <button type="button" class="ManagerButton" id="Button1" onclick="BOX_remove('neworedit');"><img src="../images/state1.gif"/> 取 消 </button>
					</td>
				</tr>
			</table>
			</fieldset>
			</div>
			</div>
			<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		</form>
		<div id="setting" />
		
	</body>
</html>
