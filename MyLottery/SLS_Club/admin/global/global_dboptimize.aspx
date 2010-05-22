<%@ page language="C#" autoeventwireup="true" inherits="Discuz.Web.Admin.dboptimize, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     	<link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />		
	    <script type="text/javascript" src="../js/common.js"></script>
	    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:datagrid id="DataGrid1" runat="server">
	    <Columns>
		    <asp:TemplateColumn HeaderText="<input value='checkbox' OnClick='CheckAll(this.form)' type='checkbox' name='chkall' id='chkall'/>">
			    <ItemTemplate>
				    <input id="tablename" onclick="javascript:SH_SelectOne(this)" type="checkbox" 
				    value="<%# DataBinder.Eval(Container, "DataItem.tablename").ToString() %>" name="tablename" />
			    </ItemTemplate>
		    </asp:TemplateColumn>
		    <asp:BoundColumn DataField="tablename" HeaderText="数据表"></asp:BoundColumn>
		    <asp:BoundColumn DataField="tabletype" HeaderText="类型"></asp:BoundColumn>
		    <asp:BoundColumn DataField="rowcount" HeaderText="记录数"></asp:BoundColumn>
		    <asp:BoundColumn DataField="tabledata" HeaderText="数据"></asp:BoundColumn>
		    <asp:BoundColumn DataField="index" HeaderText="索引"></asp:BoundColumn>
		    <asp:BoundColumn DataField="datafree" HeaderText="碎片"></asp:BoundColumn>
	    </Columns>
	</cc1:datagrid>
    <div align="center"><cc1:Button id="Yh" runat="server" Text=" 优 化 "   ButtonImgUrl="../images/submit.gif"></cc1:Button></div>
    </form>
    
</body>
</html>
