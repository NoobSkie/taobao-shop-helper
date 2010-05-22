<%@ page language="c#" inherits="Discuz.Web.Admin.uploadonlieninco, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<html>
<head>
    <title>uploadonlieninco</title>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <br />
        <table class="ntcplist" >
        <tr>
        <td>
        <table class="datalist" id="DataGrid1" style="border-collapse: collapse;" border="1" cellspacing="0" rules="all">
            <tr class="category">
		        <td style="border: 1px solid rgb(234, 233, 225);" nowrap="nowrap" width="50%">图片</td>
                <td style="border: 1px solid rgb(234, 233, 225);" nowrap="nowrap" width="50%">名称</td>
            </tr>
            <cc1:Repeater id="incolist" runat="server">
                <ItemTemplate>
                    <tr onmouseover="this.className='mouseoverstyle'" onmouseout="this.className='mouseoutstyle'" style="cursor:hand;">
                        <td nowrap="nowrap" style="border-color:#EAE9E1;border-width:1px;border-style:Solid;width:70px;">
                            <img src="../../images/groupicons/<%# DataBinder.Eval(Container.DataItem,"imgfile").ToString()%>" width="20">
                        </td>
                        <td nowrap="nowrap" style="border-color:#EAE9E1;border-width:1px;border-style:Solid;width:70px;">
                            <%# DataBinder.Eval(Container.DataItem,"imgfile").ToString()%>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr onmouseover="this.className='mouseoverstyle'" onmouseout="this.className='mouseoutstyle'" style="cursor:hand;">
                        <td nowrap="nowrap" style="border-color:#EAE9E1;border-width:1px;border-style:Solid;width:70px;">
                            <img src="../../images/groupicons/<%# DataBinder.Eval(Container.DataItem,"imgfile").ToString()%>" width="20">
                        </td>
                        <td nowrap="nowrap" style="border-color:#EAE9E1;border-width:1px;border-style:Solid;width:70px;">
                            <%# DataBinder.Eval(Container.DataItem,"imgfile").ToString()%>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </cc1:Repeater>
        </table>
        </td>
        </tr>
        </table>
        <div class="ManagerForm">
            <fieldset>
                <legend style="background:url(../images/icons/icon35.jpg) no-repeat 6px 50%;">添加在线列表图片</legend>
                <table width="100%">		
                    <tr>
                        <td style="width: 120px">用户在线图片上传:</td>
                        <td style="width: 340px">
                            <cc1:UpFile id="image" runat="server" UpFilePath="../../images/groupicons/" FileType=".jpg|.gif|.png" IsShowTextArea="false"></cc1:UpFile>
                        </td>
                        <td align="left">
                            <cc1:Button id="UpdateOnLineIncoCache" runat="server" Text="上传并重新加载图例列表"  ShowPostDiv="false"></cc1:Button>&nbsp;&nbsp;
                            <button type="button" class="ManagerButton" id="Button3" onclick="window.history.back();"><img src="../images/arrow_undo.gif"/> 返 回 </button>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
    
</body>
</html>
