<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="TextareaResize" Src="../UserControls/TextareaResize.ascx" %>
<%@ page language="c#" validaterequest="false" inherits="Discuz.Web.Admin.editbbcode, SLS.Club" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title>Discuz!NT代码编辑</title>		
	    <script type="text/javascript" src="../js/common.js"></script>
	    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/modalpopup.js"></script>
    </head>

	<body>
		<form id="Form1" method="post" runat="server">
			<div class="ManagerForm">
        <fieldset>
		<legend style="background:url(../images/icons/icon47.jpg) no-repeat 6px 50%;">编辑Discuz!NT代码</legend>
		<table cellspacing="0" cellpadding="4" width="100%" align="center">
            <tr>
                <td  class="panelbox" align="left" width="50%">
                    <table width="100%">
                        <tr>
					        <td style="width: 80px">是否生效:</td>
					        <td>
					            <cc1:radiobuttonlist id="available" runat="server">
							        <asp:ListItem Value="1">生效</asp:ListItem>
							        <asp:ListItem Value="0" Selected="True">不生效</asp:ListItem>
						        </cc1:radiobuttonlist>
					        </td>
                        </tr>
                        <tr>
					        <td>标签:</td>
					        <td >
					            <cc1:textbox id="tag" runat="server" HintTitle="提示" HintInfo="方括号中的标签代码, 如 [tag] 的标签为 &amp;quot;tag&amp;quot;(不含引号)" 
					            CanBeNull="必填" RequiredFieldType="暂无校验" MaxLength="100" TextMode="MultiLine" Rows="3" Cols="20"   ></cc1:textbox>
					        </td>
                        </tr>
                        <tr>
					        <td>例子:</td>
					        <td>
						        <uc1:TextareaResize id="example" runat="server" HintTitle="提示" HintInfo="本代码作用的例子" controlname="example" cols="30" is_replace="true" maxlength="254">
						        </uc1:TextareaResize>
					        </td>
                        </tr>
                        <tr>
					        <td>参数个数:</td>
					        <td>
						        <cc1:TextBox id="param" runat="server" HintTitle="提示" HintInfo="本代码中使用到的动态参数个数" CanBeNull="必填" RequiredFieldType="数据校验" Text="0" size="3">
						        </cc1:TextBox>
					        </td>
                        </tr>
                        <tr>
					        <td>参数描述:</td>
					        <td>
						        <uc1:TextareaResize id="paramsdescript" runat="server" HintTitle="提示" 
						        HintInfo="在插入自定义标签时会弹出录入框,此描述为录入框提示信息,对应参数个数.多于一个参数,请用半角逗号(,)分隔." 
						        controlname="paramsdescript" cols="30" is_replace="true"></uc1:TextareaResize>
					        </td>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" align="right" width="50%">
                    <table width="100%">
				        <tr>
					        <td style="width: 80px">图标:</td>
					        <td>
						        <cc1:UpFile id="icon" runat="server" UpFilePath="../../editor/images/" FileType=".jpg|.gif|.png" IsShowTextArea="false" Width="60px"></cc1:UpFile>
					        </td>
				        </tr>
				        <tr>
					        <td>替换内容:</td>
					        <td>
						        <uc1:TextareaResize id="replacement" runat="server" HintTitle="提示" 
						        HintInfo="标签替换为的 html 代码内容, 支持至多三个动态参数<br />{1} 代表第一个参数<br />{2} 代表第二个参数<br />{3} 代表第三个参数<br />{RANDOM}代表随机生成的字符串" 
						        controlname="replacement" cols="30" is_replace="true"  HintShowType="down" HintHeight="0"></uc1:TextareaResize>					
					        </td>
				        </tr>
				        <tr>
					        <td>解释:</td>
					        <td>
						        <uc1:TextareaResize id="explanation" runat="server" HintTitle="提示" HintInfo="本代码功能的解释" controlname="explanation" cols="30" is_replace="true">
						        </uc1:TextareaResize>
					        </td>
				        </tr>
				        <tr>
					        <td>嵌套次数:</td>
					        <td>
					            <cc1:textbox id="nest" runat="server" HintTitle="提示" HintInfo="最大解析的代码嵌套次数(深度), 范围从 1～3" Text="0" 
					            CanBeNull="必填" RequiredFieldType="数据校验" size="3"></cc1:textbox>
					        </td>
				        </tr>
				        <tr>
					        <td>params默认值:</td>
					        <td>
						        <uc1:TextareaResize id="paramsdefvalue" runat="server" HintTitle="提示" 
						        HintInfo="在插入自定义标签时会弹出录入框,此默认值为录入框中默认显示的数值,对应参数个数.多于一个参数,请用半角逗号(,)分隔." 
						        controlname="paramsdefvalue" cols="30" is_replace="true"></uc1:TextareaResize>
					        </td>
				        </tr>
                    </table>
                </td>
            </tr>
        </table>
			</fieldset>
			<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
			<div align="center">
			    <cc1:Button id="UpdateBBCodeInfo" runat="server" Text=" 提 交 "></cc1:Button>&nbsp;&nbsp;
			    <cc1:Button id="DeleteBBCode" runat="server" Text=" 删 除 " ButtonImgUrl="../images/del.gif"></cc1:Button>
			</div>
			</div>
		</form>
		
	</body>
</html>
