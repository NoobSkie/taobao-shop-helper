<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ page language="c#" inherits="Discuz.Web.Admin.addsmile, SLS.Club" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>添加表情</title>		
		<script type="text/javascript" src="../js/common.js"></script>
		<link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
    </head>

	<body>
		<form id="Form1" method="post" runat="server">
		<div class="ManagerForm">
        <fieldset>
		<legend style="background:url(../images/icons/icon49.jpg) no-repeat 6px 50%;">表情添加</legend>
			<table class="table1" cellspacing="0" cellPadding="4" width="100%"  align="center" >
			    <tr>
                    <td  class="panelbox" align="left" width="50%">
                        <table width="100%">
                            <tr>
					            <td style="width:90px;">显示顺序:</td>
					            <td>
						            <cc1:TextBox id="displayorder" runat="server" RequiredFieldType="数据校验" CanBeNull="必填" Text="0" MaxLength="4" Size="4"></cc1:TextBox>
					            </td>
                            </tr>
                            <tr>
					            <td>上传图片:</td>
					            <td>
						            <cc1:UpFile id="url" IsShowTextArea="false" runat="server" HintTitle="提示" 
						            HintInfo="上传的文件扩展名为<b>jpg</b> ,<b>gif</b>,<b>png</b>,文件大小最好不要超过512 KB" 
						            UpFilePath="../../editor/images/smilies/" FileType=".jpg|.gif|.png"></cc1:UpFile>
					            </td>
                            </tr>
                        </table>
                    </td>
                    <td class="panelbox" align="right" width="50%">
                        <table width="100%">
                            <tr>
					            <td style="width:90px;">代码:</td>
					            <td>
						            <cc1:TextBox id="code" runat="server" RequiredFieldType="暂无校验" CanBeNull="必填" MaxLength="30"></cc1:TextBox>
					            </td>
                            </tr>
                        </table>
                    </td>                    
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <cc1:Button id="AddSmileInfo" runat="server" Text=" 提 交 "></cc1:Button>&nbsp;&nbsp;
                        <button type="button" class="ManagerButton" id="Button3" onclick="history.go(-1);"><img src="../images/arrow_undo.gif"/> 返 回 </button>
                    </td>
                </tr>
            </table>
		</fieldset>
		<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
		</div>
		</form>
		
	</body>
</html>
