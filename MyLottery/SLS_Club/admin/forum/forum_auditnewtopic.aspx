<%@ page language="c#" inherits="Discuz.Web.Admin.auditnewtopic, SLS.Club" autoeventwireup="false" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="AjaxPostInfo" Src="../UserControls/AjaxPostInfo.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>auditnewtopic</title>		
	    <link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
		<script type="text/javascript" src="../js/common.js"></script>
		<script type="text/javascript" src="../js/AjaxHelper.js"></script>		
        <script type="text/javascript">	
         function  LoadInfo(istopic,pid,tid)
         {
             AjaxHelper.Updater('../UserControls/AjaxPostInfo','AjaxPostInfo','istopic='+istopic+'&pid='+pid+'&tid='+tid);         
             document.getElementById('PostInfo').style.display = "block";
         }
         
         function Check(form)
         {
            CheckAll(form);
            checkedEnabledButton(form,'tid','SelectPass','SelectDelete');
         }
        </script>
    </head>

	<body>
		<form id="Form1" method="post" runat="server">
			
			<cc1:datagrid id="DataGrid1" runat="server" OnPageIndexChanged="DataGrid_PageIndexChanged" OnSortCommand="Sort_Grid" >
				<Columns>
				 <asp:TemplateColumn HeaderText="<input title='选中/取消' onclick='Check(this.form)' type='checkbox' name='chkall' id='chkall' />">
				        <HeaderStyle Width="20px" />
					    <ItemTemplate>
						    <input id="tid" type="checkbox" onclick="checkedEnabledButton(this.form,'tid','SelectPass','SelectDelete')" value="<%# DataBinder.Eval(Container, "DataItem.tid").ToString() %>" name="tid" />
					    </ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="tid" SortExpression="tid"  HeaderText="tid [递增]" Visible="false"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="标题">
					    <ItemStyle HorizontalAlign="Left" />
						<ItemTemplate>
							 <a href="javascript:void(0);" onclick="javascript:LoadInfo('true','0','<%# DataBinder.Eval(Container, "DataItem.tid").ToString() %>');">
							 <%# DataBinder.Eval(Container, "DataItem.title").ToString() %></a>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="作者">
                        <ItemTemplate>
                            <%# (DataBinder.Eval(Container, "DataItem.posterid").ToString() != "-1") ? "<a href='../../userinfo.aspx?userid=" + DataBinder.Eval(Container, "DataItem.posterid").ToString() + "' target='_blank'>" + DataBinder.Eval(Container, "DataItem.poster").ToString() + "</a>" : DataBinder.Eval(Container, "DataItem.poster").ToString()%>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="highlight" SortExpression="highlight" HeaderText="主题高亮识别号"></asp:BoundColumn>
					<asp:BoundColumn DataField="digest" SortExpression="digest" HeaderText="精华级别"></asp:BoundColumn>
					<asp:BoundColumn DataField="rate" SortExpression="rate" HeaderText="评分分数"></asp:BoundColumn>
					<asp:BoundColumn DataField="displayorder" SortExpression="displayorder" HeaderText="显示顺序"></asp:BoundColumn>
					<asp:BoundColumn DataField="postdatetime" SortExpression="postdatetime" HeaderText="发布时间"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="是否含有附件">
                        <ItemTemplate>
                            <img src="../images/<%# (DataBinder.Eval(Container, "DataItem.attachment").ToString() == "0") ? "cancel" : "ok"%>.gif" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="是否关闭">
                        <ItemTemplate>
                            <img src="../images/<%# (DataBinder.Eval(Container, "DataItem.closed").ToString() == "0") ? "cancel" : "ok"%>.gif" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
			   	</Columns>
			</cc1:datagrid>
			<p style="text-align:right;">
			    <cc1:Button id="SelectPass" runat="server" Text=" 通 过 " Enabled="false"></cc1:Button> &nbsp;&nbsp;
			    <cc1:Button id="SelectDelete" runat="server" Text=" 删 除 " ButtonImgUrl="../images/del.gif" Enabled="false"></cc1:Button>
			</p>			
			<div id="AjaxPostInfo" style="overflow-y: auto;" valign="top">
				<uc1:AjaxPostInfo id="AjaxPostInfo1" runat="server"></uc1:AjaxPostInfo>
			</div>	
			
			<div id="Div1" style="display:none">
			<tr>
				<td bgcolor="#f8f8f8" colspan="2"><asp:literal id="msg" runat="server" Text="没有等待审核新主题" Visible="False"></asp:literal></td>
			</tr>
			</div>
		</form>
		
	</body>
</html>
