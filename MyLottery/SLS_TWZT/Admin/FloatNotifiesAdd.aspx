<%@ page language="C#" autoeventwireup="true" CodeFile="FloatNotifiesAdd.aspx.cs" inherits="Admin_FloatNotifiesAdd" enableEventValidation="false" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
<link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
    .colorblue,.colorfocus{font-family:Arial, Helvetica, sans-serif;border: 1px #B9CDE3 double;background-color: #fff;padding:0.2em 0;margin:2px;}
.colorfocus {border: 1px #99CC00 double;}
	.lightbutton {font-family:Arial, Helvetica, sans-serif;color: #036;background-color: #F5FAFE;border: 1px solid #95D2F0;height: 24px;padding:0 3px;margin-right: 5px;}
	a.newbutton { padding:7px 22px; text-align:center; background:url(images/userbutton3.gif) no-repeat left center; text-decoration:none; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
            <tr>
                <td>
                    顺序
                    <asp:TextBox ID="tbOrder" runat="server" MaxLength="10" Width="100px">1</asp:TextBox>&nbsp;<asp:CheckBox
                        ID="cbisShow" runat="server" Text="是否显示" Checked="True"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td>
                    <font face="宋体">标题
                        <asp:TextBox ID="tbName" runat="server" Width="400px" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    颜色:
                    <script type="text/javascript" src="../Home/Web/JavaScript/template_colorpicker.js"></script>

                    <input type="text" value="#000000" name="highlight_color" id="highlight_color" size="7"
                        class="colorblue" onfocus="this.className='colorfocus';" onblur="this.className='colorblue';" />
                    <select name="highlight_colorselect" id="highlight_colorselect" onchange="selectoptioncolor(this)"
                        style="margin-bottom: 2px; width:50px;">
                        <option style="background: #000000" value="#000000"></option>
                        <option style="background: #FF0000" value="#FF0000"></option>
                        <option style="background: #FF8000" value="#FF8000"></option>
                        <option style="background: #00FF00" value="#00FF00"></option>
                        <option style="background: #0080ff" value="#0080ff"></option>
                        <option style="background: #0000A0" value="#0000A0"></option>
                        <option style="background: #8000FF" value="#8000FF"></option>
                    </select>
                    <img class="img" title="选择颜色" src="../Home/Web/images/colorpicker.gif" id="s_bgcolor"
                        onclick="IsShowColorPanel(this);" style="cursor: hand; border: 0px;" />
                </td>
            </tr>
            <tr>
                <td>
                    <font face="宋体">网址
                        <asp:TextBox ID="tbUrl" runat="server" MaxLength="255" Width="400px"></asp:TextBox></font>
                </td>
            </tr>
            <tr>
                <td style="height: 50px" align="center">
                    <ShoveWebUI:ShoveConfirmButton ID="btnAdd" runat="server" Width="60px" Height="20px"
                        BackgroupImage="../Images/Admin/buttbg.gif" Text="保存" OnClick="btnAdd_Click" />
                    <span style="margin-left: 100px;"></span>
                    <ShoveWebUI:ShoveConfirmButton ID="btnCancel" runat="server" Width="60px" Height="20px"
                        BackgroupImage="../Images/Admin/buttbg.gif" Text="取消" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div  id="ColorPicker" title="ColorPicker" style="display:none;cursor:crosshair;border: black 1px solid;position: absolute; z-index: 10;background-color: aliceblue; width:250px;background: #FFFFFF;padding: 4px; margin-left:150px;" onmouseover="ShowColorPanel();">
						<table border="0" cellPadding="0" cellSpacing="10" onmouseover="ShowColorPanel();">
						<tr>
						<td>
						<table border="0" cellPadding="0" cellSpacing="0" id="ColorTable" style="cursor:crosshair;"  onmouseover="ShowColorPanel();">
						<script type="text/javascript">
						function wc(r, g, b, n){
							r = ((r * 16 + r) * 3 * (15 - n) + 0x80 * n) / 15;
							g = ((g * 16 + g) * 3 * (15 - n) + 0x80 * n) / 15;
							b = ((b * 16 + b) * 3 * (15 - n) + 0x80 * n) / 15;
							document.write('<td BGCOLOR=#' + ToHex(r) + ToHex(g) + ToHex(b) + ' title="#' + ToHex(r) + ToHex(g) + ToHex(b) + '" height=8 width=8 onmouseover="ColorTableMouseOver(this)" onmousedown="ColorTableMouseDown(this)"  onmouseout="ColorTableMouseOut(this)" ></TD>');
						}
						var cnum = new Array(1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0);
						for(i = 0; i < 16; i ++){
							document.write('<TR>');
							for(j = 0; j < 30; j ++){
								n1 = j % 5;
								n2 = Math.floor(j / 5) * 3;
								n3 = n2 + 3;
								wc((cnum[n3] * n1 + cnum[n2] * (5 - n1)),
								(cnum[n3 + 1] * n1 + cnum[n2 + 1] * (5 - n1)),
								(cnum[n3 + 2] * n1 + cnum[n2 + 2] * (5 - n1)), i);
							}
							document.writeln('</TR>');
						}
						</script>
						</table></td>
						<td>
						<table border="0" cellPadding="0" cellSpacing="0" id="GrayTable" style="CURSOR: hand;cursor:crosshair;"  onmouseover="ShowColorPanel();">
						<script type="text/javascript">
						for(i = 255; i >= 0; i -= 8.5)
						document.write('<tr BGCOLOR=#' + ToHex(i) + ToHex(i) + ToHex(i) + '><td TITLE=' + Math.floor(i * 16 / 17) + ' height=4 width=20 onmouseover="GrayTableMouseOver(this)" onmousedown="GrayTableMouseDown(this)"  onmouseout="GrayTableMouseOut(this)" ></td></tr>');
						</script>
						</table></td></tr></table>
						<table border="0" cellPadding="0" cellSpacing="10" onmouseover="ShowColorPanel();">
						<tr>
						<td rowSpan="2">选中色彩
						<table border="1" cellPadding="0" cellSpacing="0" height="30" id="ShowColor" width="40" bgcolor="">
						<tr>
						<td></td></tr></table></td>
						<td rowSpan=2>基色: <span id="RGB"></span><br />亮度: <span id="GRAY">120</span><br />代码: <input id="SelColor" size="7" value="" border="0" name="SelColor" /></TD>
						<td><input type="button" onclick="javascript:ColorPickerOK();" value="确定" ID="ok"/></td></tr>
						<tr>
						<td><input type="button" onclick="javascript:document.getElementById('highlight_color').value='';document.getElementById('s_bgcolor').style.background='#FFFFFF';HideColorPanel();" value="取消" ID="Button2" NAME="Button2"/></td></tr></table>
</div>
    </form>
</body>
</html>
