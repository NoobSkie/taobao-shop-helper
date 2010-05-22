<%@ page language="c#" inherits="Discuz.Web.Admin.attach, SLS.Club" %>

<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>baseset</title>
    <script type="text/javascript" src="../js/common.js"></script>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/modalpopup.js"></script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <div class="ManagerForm">
            <fieldset>
                <legend style="background: url(../images/icons/icon24.jpg) no-repeat 6px 50%;">附件设置</legend>
                    <table cellspacing="0" cellpadding="4" width="100%" align="center">
		                <tr>
		                    <td  class="panelbox" width="50%" align="left">
		                        <table width="100%">
		                            <tr>
                                        <td style="width: 130px">帖子中显示图片附件:</td>
                                        <td>
                                            <cc1:RadioButtonList ID="attachimgpost" runat="server" HintTitle="提示" HintInfo="在帖子中直接将图片或动画附件显示出来, 而不需要点击附件链接" RepeatLayout="flow">
                                                <asp:ListItem Value="1">是</asp:ListItem>
                                                <asp:ListItem Value="0">否</asp:ListItem>
                                            </cc1:RadioButtonList>
                                        </td>
		                            </tr>
		                            <tr>
                                        <td>附件保存方式:</td>
                                        <td>
                                            <cc1:RadioButtonList ID="attachsave" runat="server" HintTitle="提示" HintInfo="本设置只影响新上传的附件, 设置更改之前的附件仍存放在原来位置." RepeatColumns="1" RepeatLayout="flow">
                                                <asp:ListItem Value="0">按年/月/日存入不同目录</asp:ListItem>
                                                <asp:ListItem Value="1">按年/月/日/论坛存入不同目录</asp:ListItem>
                                                <asp:ListItem Value="2">按版块存入不同目录 [不推荐]</asp:ListItem>
                                                <asp:ListItem Value="3">按文件类型存入不同目录 [不推荐]</asp:ListItem>
                                            </cc1:RadioButtonList>
                                        </td>
		                            </tr>
		                            <tr>
                                        <td>文字型水印的内容:</td>
                                        <td>
                                            <cc1:TextBox ID="watermarktext" runat="server" HintTitle="提示" 
                                                HintInfo="可以使用替换变量: {1}表示论坛标题 {2}表示论坛地址 {3}表示当前日期 {4}表示当前时间.例如: {3} {4}上传于{1} {2}"
                                                Width="200px" RequiredFieldType="暂无校验" CanBeNull="必填" IsReplaceInvertedComma="false"></cc1:TextBox>
                                        </td>
		                            </tr>
		                            <tr>
                                        <td>图片附件文字水印字体:</td>
                                        <td>
                                            <cc1:DropDownList ID="watermarkfontname" runat="server">
                                            </cc1:DropDownList>
                                        </td>
		                            </tr>
		                            <tr>
                                        <td>图片附件地址显示开关:</td>
                                        <td>
                                            <cc1:RadioButtonList ID="showattachmentpath" HintTitle="提示" HintInfo="如果选择是, 则系统会以真实路径显示图片.如果选择否, 则以程序路径显示"
                                                runat="server" RepeatLayout="flow">
                                                <asp:ListItem Value="1">显示</asp:ListItem>
                                                <asp:ListItem Value="0">不显示</asp:ListItem>
                                            </cc1:RadioButtonList>
                                        </td>
		                            </tr>
		                            <tr>
                                        <td>图片最大高度:</td>
                                        <td>
                                            <cc1:TextBox ID="attachimgmaxheight" runat="server" HintTitle="提示" HintInfo="0为不受限制.本设置只适用于bmp/png/jpeg格式图片"
                                                Size="7" CanBeNull="必填" RequiredFieldType="数据校验" Text="0" MaxLength="5"></cc1:TextBox>(单位:像素)
                                        </td>
		                            </tr>
		                            <tr>
                                        <td>选择水印位置:</td>
                                        <td>
                                            <table cellspacing="0" cellpadding="4">
                                                <tr class="altbg2" align="left">
                                                    <td title="请在此选择水印添加的位置(共 9 个位置可选).添加水印暂不支持动画 GIF 格式. 附加的水印图片在下面的使用的 图片水印文件 中指定.">
                                                        <asp:Literal ID="position" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
		                            </tr>
		                        </table>
		                    </td>
		                    <td  class="panelbox" width="50%" align="right">
		                        <table width="100%">
                                    <tr>
                                        <td style="width: 130px">下载附件来路检查:</td>
                                        <td>
                                            <cc1:RadioButtonList ID="attachrefcheck" runat="server" HintTitle="提示" HintShowType="down" HintTopOffSet="25" RepeatLayout="flow"
                                            HintInfo="选择&amp;quot;是&amp;quot;将检查下载附件的来路, 来自其他网站或论坛的下载请求将被禁止. 注意: 本功能在开启&amp;quot;帖子中显示图片附件&amp;quot;时,会加重服务器负担">
                                                <asp:ListItem Value="1">是</asp:ListItem>
                                                <asp:ListItem Value="0">否</asp:ListItem>
                                            </cc1:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>图片附件水印类型:</td>
                                        <td>
                                            <cc1:RadioButtonList ID="watermarktype" runat="server" RepeatLayout="flow">
                                                <asp:ListItem Value="0">文字</asp:ListItem>
                                                <asp:ListItem Value="1">图片</asp:ListItem>
                                            </cc1:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>图片型水印文件:</td>
                                        <td>
                                            <cc1:TextBox ID="watermarkpic" runat="server" HintTitle="提示" 
                                                HintInfo="附加的水印图片需存放到论坛目录的watermark子目录下.注意:如果图片不存在系统将使用文字类型的水印. "
                                                Width="200px" RequiredFieldType="暂无校验" CanBeNull="必填" IsReplaceInvertedComma="false"></cc1:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>图片附件文字水印大小:</td>
                                        <td>
                                            <cc1:TextBox ID="watermarkfontsize" runat="server" Size="7" CanBeNull="必填" RequiredFieldType="数据校验"
                                                MaxLength="5"></cc1:TextBox>(单位:像素)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>JPG图片质量:</td>
                                        <td>
                                            <cc1:TextBox ID="attachimgquality" runat="server" HintTitle="提示" HintInfo="本设置只适用于加水印的jpeg格式图片.取值范围 0-100, 0质量最低, 100质量最高, 默认80"
                                                Size="5" CanBeNull="必填" RequiredFieldType="数据校验" Text="80" MaxLength="3"></cc1:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>图片最大宽度:</td>
                                        <td>
                                            <cc1:TextBox ID="attachimgmaxwidth" runat="server" HintTitle="提示" HintInfo="0为不受限制.本设置只适用于bmp/png/jpeg格式图片"
                                                CanBeNull="必填" RequiredFieldType="数据校验" Size="7" Text="0" MaxLength="5"></cc1:TextBox>(单位:像素)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>图片水印透明度:</td>
                                        <td>
                                            <cc1:TextBox ID="watermarktransparency" runat="server" HintTitle="提示" HintInfo="取值范围1--10 (10为不透明)."
                                                RequiredFieldType="数据校验" MaxLength="2" CanBeNull="必填" Size="5"></cc1:TextBox>
                                        </td>
                                    </tr>
		                        </table>
		                    </td>
		                </tr>
		            </table>
            </fieldset>
            <cc1:Hint ID="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
            <div class="Navbutton"><cc1:Button ID="SaveInfo" runat="server" Text=" 提 交 "></cc1:Button></div>
        </div>
    </form>
    
</body>
</html>
