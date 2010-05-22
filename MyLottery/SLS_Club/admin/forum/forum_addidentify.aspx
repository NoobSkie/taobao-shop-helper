<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.addidentify, SLS.Club" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>鉴定添加</title>		
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
    </head>

	<body>
		<form id="Form1" method="post" runat="server">
		<div class="ManagerForm">
        <fieldset>
		    <legend style="background:url(../images/icons/icon49.jpg) no-repeat 6px 50%;">鉴定添加</legend>
			<table class="table1" cellspacing="0" cellPadding="4" width="100%"  align="center" >
			    <tr>
                    <td  class="panelbox" align="left" width="50%">
                        <table width="100%">
                            <tr>
					            <td style="width:70px;">名称:</td>
					            <td>
							            <cc1:TextBox id="name" runat="server" CanBeNull="必填" Text="" MaxLength="50" Size="20"></cc1:TextBox>
					            </td>
                            </tr>
                        </table>
                    </td>
                    <td align="right" class="panelbox" width="50%">
                        <table width="100%">
                            <tr>
					            <td style="width: 70px;">上传图片:</td>
					            <td>
						            <cc1:UpFile id="uploadfile" IsShowTextArea=false runat="server" HintTitle="提示" 
						            HintInfo="上传的文件扩展名为<b>jpg</b> ,<b>gif</b>,<b>png</b>,文件大小最好不要超过512 KB" 
						            UpFilePath="../../images/identify/" FileType=".jpg|.gif|.png"></cc1:UpFile>
					            </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
		</fieldset>
		<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		<div align="center">
		    <cc1:Button id="AddIdentifyInfo" runat="server" Text=" 提 交 "></cc1:Button>
		</div>
		</div>
		</form>
		
	</body>
</html>
