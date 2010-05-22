<%@ page language="c#" inherits="Discuz.Web.Admin.aggregation_recommendtopic, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>推荐版块选择</title>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" /> 
		<link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />
		<script type="text/javascript">
		    function getTextBoxName(obj)
		    {
		        return obj.substring(obj.lastIndexOf("_") + 1,obj.length);
		    }
		    function resetPage()
	        {
	            document.getElementById('success').style.display = 'none'
	            document.getElementById("Btn_SaveInfo").disabled = false;
	        }

		    function validate(form)
		    {
		        for (var i=0;i<form.elements.length;i++)
                {
                    var e = form.elements[i];
                    if (e.type == "text")
                    {
                        var name = getTextBoxName(e.id);
                        if(e.value == "")   //如果信息未输入
                        {
                            resetPage();
                            switch(name)
                            {
                                case "tid":
                                    alert("帖子ID不能为空");
                                    break;
                                case "title":
                                    alert("帖子标题不能为空");
                                    break;
                                case "img":
                                    alert("图片地址不能为空");
                                    break;
                            }
                            e.focus();
                            return false;
                        }
                        else
                        {
                            switch(name)
                            {
                                case "tid":
                                    if(!/^\d+$/.test(e.value))  //验证帖子ID是否是数字
                                    {
                                        resetPage();
                                        alert("帖子ID必须是数字");
                                        e.value = "";
                                        e.focus();
                                        return false;
                                    }
                                    break;
                            }
                        }
                    }
                }
                return true;
		    } 
		</script>
  </head>
	<body>
		<form id="Form1" method="post" runat="server">
		<div class="ManagerForm">
		<fieldset>
		    <legend style="background:url(../images/legendimg.jpg) no-repeat 6px 50%;">推荐版块图片选择</legend> 
		    <cc1:datagrid id="DataGrid1" runat="server" IsFixConlumnControls="true" OnItemDataBound="DataGrid_ItemDataBound">
				<Columns>
				    <asp:TemplateColumn HeaderText="版块名称">
						<ItemTemplate>
							<%# DataBinder.Eval(Container, "DataItem.name").ToString() %>
							<%# DataGrid1.LoadSelectedCheckBox(DataBinder.Eval(Container, "DataItem.fid").ToString())%>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="tid"  HeaderText="帖子ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="title" HeaderText="帖子标题"></asp:BoundColumn>
					<asp:BoundColumn DataField="img"  HeaderText="图片地址"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="图片"><HeaderStyle Width="10%" />
						<ItemTemplate>
							<a href="<%# DataBinder.Eval(Container, "DataItem.img").ToString() %>" target="_blank" title="查看原图">
							    <img src ="<%# DataBinder.Eval(Container, "DataItem.img").ToString() %>" height="25" width="25"  border="0px" />
							</a>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</cc1:datagrid>
		</fieldset><br />
		<div align="center">
		    <cc1:Button id="Btn_SaveInfo" runat="server" Text="  保存  " ButtonImgUrl="../images/submit.gif" ValidateForm="true"></cc1:Button>
		</div>
		</div>
		</form>
		
	</body>
</html>
