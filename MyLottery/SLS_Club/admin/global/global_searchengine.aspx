<%@ page language="C#" validaterequest="false" autoeventwireup="true" inherits="Discuz.Web.Admin.searchengine, SLS.Club" %>

<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="TextareaResize" Src="../UserControls/TextareaResize.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>registerandvisit</title>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="../js/common.js"></script>

    <script type="text/javascript" src="../js/modalpopup.js"></script>

</head>
<body>
    <div class="ManagerForm">
        <form id="Form1" method="post" runat="server">
        <fieldset>
            <legend style="background: url(../images/icons/icon13.jpg) no-repeat 6px 50%;">搜索引擎优化</legend>
            <table cellspacing="0" cellpadding="4" width="100%" align="center">
                <tr>
                    <td colspan="2">
                        <table width="100%">
                            <tr>
                                <td style="width: 132px">
                                    &nbsp;&nbsp;启用Archiver:
                                </td>
                                <td>
                                    <cc1:RadioButtonList ID="archiverstatus" runat="server" RepeatColumns="1" HintTitle="提示"
                                        HintShowType="down" HintHeight="80" HintInfo="Discuz!NT Archiver 能够将论坛公开的内容模拟成静态页面, 以便搜索引擎获取其中的内容. 高级使用技巧请参考《用户使用说明书》"
                                        HintTopFirefoxOffset="60">
                                        <asp:ListItem Value="0" Selected="True">关闭</asp:ListItem>
                                        <asp:ListItem Value="1">完全启用</asp:ListItem>
                                        <asp:ListItem Value="2">启用, 但用户从搜索引擎点击时自动转向动态页面</asp:ListItem>
                                        <asp:ListItem Value="3">启用, 但用户使用浏览器访问时自动转向动态页面</asp:ListItem>
                                    </cc1:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="panelbox" width="50%" align="left">
                        <table width="100%">
                            <tr>
                                <td style="width: 110px">
                                    标题附加字:
                                </td>
                                <td>
                                    <uc1:TextareaResize ID="seotitle" runat="server" cols="33" controlname="seotitle"
                                        HintTitle="提示" HintInfo="网页标题通常是搜索引擎关注的重点, 本附加字设置将出现在标题中论坛名称的前面, 如果有多个关键字, 建议用	&amp;quot;|&amp;quot;、&amp;quot;,&amp;quot;(不含引号) 等符号分隔">
                                    </uc1:TextareaResize>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Meta Description:
                                </td>
                                <td>
                                    <uc1:TextareaResize ID="seodescription" runat="server" cols="33" controlname="seodescription"
                                        HintTitle="提示" HintInfo="Description 出现在页面头部的 Meta 标签中, 用于记录本页面的概要与描述"></uc1:TextareaResize>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="panelbox" width="50%" align="right">
                        <table width="100%">
                            <tr>
                                <td style="width: 110px">
                                    Meta Keywords:
                                </td>
                                <td>
                                    <uc1:TextareaResize ID="seokeywords" runat="server" cols="33" controlname="seokeywords"
                                        HintTitle="提示" HintInfo="Keywords 项出现在页面头部的 Meta 标签中, 用于记录本页面的关键字, 多个关键字间请用半角逗号 &amp;quot;,&amp;quot; 隔开">
                                    </uc1:TextareaResize>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    其他头部信息:
                                </td>
                                <td>
                                    <uc1:TextareaResize ID="seohead" runat="server" cols="33" controlname="seohead" HintTitle="提示"
                                        HintInfo="如需在 &amp;lt;head&amp;gt;&amp;lt;/head&amp;gt; 中添加其他的 html 代码, 可以使用本设置, 否则请留空">
                                    </uc1:TextareaResize>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </fieldset>
        <cc1:Hint ID="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
        <div align="center">
            <cc1:Button ID="SaveInfo" runat="server" Text=" 提 交 "></cc1:Button>
        </div>
        </form>
    </div>
</body>
</html>
