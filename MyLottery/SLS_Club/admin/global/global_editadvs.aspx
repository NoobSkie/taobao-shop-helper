<%@ Register TagPrefix="uc1" TagName="TextareaResize" Src="../usercontrols/TextareaResize.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc2" TagName="forumstree" Src="../usercontrols/forumstree.ascx" %>
<%@ page language="c#" validaterequest="false" inherits="Discuz.Web.Admin.editadvs, SLS.Club" %>
<%@ Register Src="../UserControls/PageInfo.ascx" TagName="PageInfo" TagPrefix="uc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>编辑广告</title>
    <link href="../styles/calendar.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/common.js"></script>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/modalpopup.js"></script>
</head>
<body>
    <div class="ManagerForm">
        <form id="Form1" method="post" runat="server">
            <div id="adtype1" style="width: 100%; display: none">
                <uc1:PageInfo ID="info1" runat="server" Icon="information" Text="<ul><li>展现方式: 头部横幅广告显示于论坛页面右上方, 通常使用 468x60 图片或 Flash 的形式. 当前页面有多个头部横幅广告时, 系统会随机选取其中之一显示.  </ul>  <ul><li>价值分析: 由于能够在页面打开的第一时间将广告内容展现于最醒目的位置, 因此成为了网页中价位最高、最适合进行商业宣传或品牌推广的广告类型之一. </ul>" />
            </div>
            <div id="adtype2" style="width: 100%; display: none">
                <uc1:PageInfo ID="PageInfo1" runat="server" Icon="information" Text="<ul><li>展现方式: 尾部横幅广告显示于论坛页面中下方, 通常使用 468x60 或其他尺寸图片、Flash 的形式. 当前页面有多个尾部横幅广告时, 系统会随机选取其中之一显示. </ul>  <ul><li>价值分析: 与页面头部和中部相比, 页面尾部的展现机率相对较低, 通常不会引起访问者的反感, 同时又基本能够覆盖所有对广告内容感兴趣的受众, 因此适合中性而温和的推广. </ul>" />
            </div>
            <div id="adtype3" style="width: 100%; display: none">
                <uc1:PageInfo ID="PageInfo2" runat="server" Icon="information" Text="<ul><li>展现方式: 页内文字广告以表格的形式, 显示于首页、主题列表和帖子内容三个页面的中上方, 通常使用文字的形式, 也可使用小图片和 Flash. 当前页面有多个文字广告时, 系统会以表格的形式按照设定的显示顺序全部展现, 同时能够对表格列数在 3~5 的范围内动态排布, 以自动实现最佳的广告排列效果.  </ul>  <ul><li>价值分析: 由于此类广告通常以文字形式展现, 但其所在的较靠上的页面位置, 使得此类广告成为了访问者必读的内容之一. 同一页面可以呈现多达十几条文字广告的特性, 也决定了它是一种平民化但性价比较高的推广方式, 同时还可用于论坛自身的宣传和公告之用. </ul>" />
            </div>
            <div id="adtype4" style="width: 100%; display: none">
                <uc1:PageInfo ID="PageInfo3" runat="server" Icon="information" Text="<ul><li>展现方式: 帖内广告显示于帖子标题的上方, 通常使用文字的形式. 当前页面有多个帖内广告时, 系统会从中抽取与每页帖数相等的条目进行随机显示. 您可以在 Discuz!NT 选项中的其他设置中修改每帖显示的广告数量.  </ul>  <ul><li>价值分析: 由于帖子是论坛最核心的组成部分, 位于帖子内容上方的帖内广告, 便可在用户浏览帖子内容时自然的被接受, 加上随机播放的特性, 适合于特定内容的有效推广, 也可用于论坛自身的宣传和公告之用. 建议设置多条帖内广告以实现广告内容的差异化, 从而吸引更多访问者的注意力. </ul>" />
            </div>
            <div id="adtype5" style="width: 100%; display: none">
                <uc1:PageInfo ID="PageInfo4" runat="server" Icon="information" Text="<ul><li>展现方式: 漂浮广告展现于页面左下角, 当页面滚动时广告会自行移动以保持原来的位置, 通常使用小图片或 Flash 的形式. 当前页面有多个漂浮广告时, 系统会随机选取其中之一显示.  </ul>  <ul><li>价值分析: 漂浮广告是进行强力商业推广的有效手段, 其在页面中的浮动性, 使其与固定的图片和文字相比, 更容易被关注, 正因为如此, 这种强制性的关注也可能招致对此广告内容不感兴趣的访问者的反感. 请注意不要将过大的图片或 Flash 以漂浮广告的形式显示, 以免影响页面阅读. </ul>" />
            </div>
            <div id="adtype6" style="width: 100%; display: none">
                <uc1:PageInfo ID="PageInfo5" runat="server" Icon="information" Text="<ul><li>展现方式: 对联广告以长方形图片的形式显示于页面顶部两侧, 形似一幅对联, 通常使用宽小高大的长方形图片或 Flash 的形式. 对联广告一般只在使用像素约定主表格宽度的情况下使用, 如使用超过 90% 以上的百分比约定主表格宽度时, 可能会影响访问者的正常流量. 当访问者浏览器宽度小于 800 像素时, 自动不显示此类广告. 当前页面有多个对联广告时, 系统会随机选取其中之一显示.  </ul>  <ul><li>价值分析: 对联广告由于只展现于高分辨率(1024x768 或更高)屏幕的两侧, 只占用页面的空白区域, 因此不会招致访问者反感, 能够良好的突出推广内容. 但由于对分辨率和主表格宽度的特殊要求, 使得广告的受众比例无法达到 100%. </ul>" />
            </div>
            <div id="adtype7" style="width: 100%; display: none">
                <uc1:PageInfo ID="PageInfo6" runat="server" Icon="information" Text="<ul><li>展现方式: Silverlight媒体广告以视频、图片、文字相结合的方式进行展现,通常从屏幕右下角浮现出来.  </ul>  <ul><li>价值分析: 视频背后是大图片广告,视觉冲击效果配合文字描述会带来意想不到的展现效果,是最有效的广告形式. </ul>" />
            </div>
            <div id="adtype8" style="width: 100%; display: none">
                <uc1:PageInfo ID="PageInfo7" runat="server" Icon="information" Text="<ul><li>展现方式: 帖间通栏广告显示于楼主和2楼帖子之间, 通常使用 728*90 图片或 Flash 的形式. 当前页面有多个帖间通栏广告时, 系统会随机选取其中之一显示.  </ul>  <ul><li>价值分析: 对帖子的质量有举足轻重作用的楼主与沙发之间的黄金地段, 往往容易受到访问者的大量关注. </ul>" />
            </div>
            <div id="adtype9" style="width: 100%; display: none">
                <uc1:PageInfo ID="PageInfo8" runat="server" Icon="information" Text="<ul><li>展现方式: 分类间广告显示于论坛分类之间  </ul>  <ul><li>价值分析: 当论坛分类过多时, 可能对访问者造成困扰. </ul>" />
            </div>
            <div id="adtype10" style="width: 100%; display: none">
                <uc1:PageInfo ID="PageInfo9" runat="server" Icon="information" Text="<ul><li>展现方式: 快速发帖栏上方广告显示于发帖框附近  </ul>  <ul><li>价值分析: 当用户想要发帖时必然会看到此类型的广告, 是十分有效的展示方式 </ul>" />
            </div>
              <div id="adtype11" style="width: 100%; display: none">
                <uc1:PageInfo ID="PageInfo10" runat="server" Icon="information" Text="<ul><li>展现方式: 快速编辑器背景广告  </ul>  <ul><li>价值分析: 当用户想要发帖时必然会看到此类型的广告, 是十分有效的展示方式 </ul>" />
            </div>
            <fieldset>
                <legend style="background: url(../images/icons/icon36.jpg) no-repeat 6px 50%;">编辑广告</legend>
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td class="panelbox" align="left" width="50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">是否生效:</td>
                                    <td>
                                        <cc1:RadioButtonList ID="available" runat="server">
                                            <asp:ListItem Value="1" Selected="True">生效</asp:ListItem>
                                            <asp:ListItem Value="0">不生效</asp:ListItem>
                                        </cc1:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>展现方式:</td>
                                    <td id="paramselect">
                                        <cc1:DropDownList ID="parameters" runat="server" HintTitle="提示" HintInfo="请选择所需的广告展现方式">
                                        </cc1:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>生效时间:</td>
                                    <td>
                                        <cc1:Calendar ID="starttime" runat="server" HintTitle="提示" HintInfo="设置广告起始生效的时间, 格式 yyyy-mm-dd, 留空为不限制起始时间"
                                            ReadOnly="False" ScriptPath="../js/calendar.js"></cc1:Calendar>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  class="panelbox" align="right" width="50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">广告类型:</td>
                                    <td>
                                        <cc1:DropDownList ID="type" runat="server" HintInfo="广告在前台展现的类型">
                                        </cc1:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>显示顺序:</td>
                                    <td>
                                        <cc1:TextBox ID="displayorder" runat="server" CanBeNull="必填" RequiredFieldType="数据校验"
                                            Text="0" Width="56px" MultiLine="true" MaxLength="7"></cc1:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 80px">结束时间:</td>
                                    <td>
                                        <cc1:Calendar ID="endtime" runat="server" HintTitle="提示" HintInfo="设置广告广告结束的时间, 格式 yyyy-mm-dd, 留空为不限制结束时间"
                                            ReadOnly="False" ScriptPath="../js/calendar.js"></cc1:Calendar>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox" colspan="2">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">广告标题:</td>
                                    <td>
                                        <cc1:TextBox ID="tbtitle" runat="server" HintTitle="提示" HintInfo="广告标题只为识别辨认不同广告条目之用, 并不在广告中显示"
                                            RequiredFieldType="暂无校验" CanBeNull="必填" Size="60" MaxLength="50"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox" colspan="2">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">广告投放范围:</td>
                                    <td>
                                        <div style="overflow: auto; height: 150px; width: 70%;border:1px double #ccc">
                                            <uc2:forumstree ID="TargetFID" runat="server" HintTitle="提示" HintInfo="设置本广告投放的页面或论坛范围"
                                                PageName="advertisement"></uc2:forumstree>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                
                <div id="inpostad" style="width: 100%;">
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox" align="left" width="50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">广告投放位置:</td>
                                    <td>
                                        <cc1:RadioButtonList ID="inpostposition" runat="server" RepeatColumns="1" HintTitle="提示"
                                            HintInfo="帖子内容上方和下方的广告适合使用文字形式，而帖子右侧广告适合使用图片或 Flash 形式">
                                            <asp:ListItem Selected="True" Value="0">帖子下方</asp:ListItem>
                                            <asp:ListItem Value="1">帖子上方</asp:ListItem>
                                            <asp:ListItem Value="2">帖子右侧</asp:ListItem>
                                        </cc1:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  class="panelbox" align="right" width="50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">广告显示位置:</td>
                                    <td>
                                        <cc1:ListBox ID="inpostfloor" runat="server" HintTitle="提示" HintInfo="选项 #1 #2 #3 ... 表示帖子顺序，可以按住 CTRL 多选."
                                            HintTopFirefoxOffset="-170" Width="80px">
                                            <asp:ListItem Value="0">&nbsp;>全部</asp:ListItem>
                                            <asp:ListItem Value="-1">---------</asp:ListItem>
                                        </cc1:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </div>
                
                <div id="htmlcode" style="width: 100%; display: none">
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td style="width: 80px">广告内容:</td>
                        <td>
                            <img src="../images/zoomin.gif" onClick="AddWith(100)" style="cursor: hand" />
                            <img src="../images/zoomout.gif" onClick="AddWith(-100)" style="cursor: hand" />
                            <cc1:TextBox ID="code" runat="server" Rows="4" IsReplaceInvertedComma="false" HintTitle="提示"
                                HintInfo="请直接输入需要展现的广告的 html 代码" RequiredFieldType="暂无校验" CanBeNull="可为空" TextMode="MultiLine"
                                Width="70%" Height="150" HintLeftOffSet="50"></cc1:TextBox>
                        </td>                    
                    </tr>
                </table>
                </div>
                
                <div id="word" style="width: 100%; display: none">
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox" align="left" width="50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">文字内容:</td>
                                    <td>
                                        <cc1:TextBox ID="wordcontent" runat="server" HintTitle="提示" HintInfo="请输入文字广告的显示内容"
                                            Width="200px" RequiredFieldType="暂无校验" CanBeNull="可为空"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  class="panelbox" align="right" width="50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">文字大小:</td>
                                    <td>
                                        <cc1:TextBox ID="wordfont" runat="server" HintTitle="提示" HintInfo="请输入文字广告的内容显示字体, 可使用 pt、px、em 为单位"
                                            Width="40px" RequiredFieldType="暂无校验" CanBeNull="可为空"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">文字链接:</td>
                                    <td>
                                        <cc1:TextBox ID="wordlink" runat="server" HintTitle="提示" HintInfo="请输入文字广告指向的 URL 链接地址, 以http://开头 建议选择640px * 1250px 的图片"
                                            Width="344px" RequiredFieldType="暂无校验" CanBeNull="可为空" Text=""></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </div>
                
                <div id="image" style="width: 100%; display: none">
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox" align="left" width="50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">图片地址:</td>
                                    <td>
                                        <cc1:TextBox ID="imgsrc" runat="server" HintTitle="提示" HintInfo="请输入图片广告的图片调用地址, 以http://开头 建议选择640px * 130px的图片"
                                            Width="250px" RequiredFieldType="暂无校验" CanBeNull="可为空" Text=""></cc1:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 80px"><div id="imgwidthtxt">图片宽度:</div></td>
                                    <td>
                                        <cc1:TextBox ID="imgwidth" runat="server" HintTitle="提示" HintInfo="请输入图片广告的宽度, 单位为像素"
                                            Width="40px" RequiredFieldType="数据校验" CanBeNull="可为空"></cc1:TextBox><div id="pxwidth">px</div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  class="panelbox" align="right" width="50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">广告链接地址:</td>
                                    <td>
                                        <cc1:TextBox ID="imglink" runat="server" HintTitle="提示" HintInfo="请输入图片广告指向的 URL 链接地址, 以http://开头"
                                            Width="250px" RequiredFieldType="暂无校验" CanBeNull="可为空" Text=""></cc1:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 80px"><div id="imgheighttxt">图片高度:</div></td>
                                    <td>
                                        <cc1:TextBox ID="imgheight" runat="server" HintTitle="提示" HintInfo="请输入图片广告的高度, 单位为像素"
                                            Width="40px" RequiredFieldType="数据校验" CanBeNull="可为空"></cc1:TextBox><div id="pxhtight">px</div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px"><div id="imgtitletxt">图片替换文字:</div></td>
                                    <td>
                                        <cc1:TextBox ID="imgtitle" runat="server" HintTitle="提示" HintInfo="请输入图片广告的鼠标悬停文字信息"
                                            Width="344px" RequiredFieldType="暂无校验" CanBeNull="可为空"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </div>
                
                <div id="flash" style="width: 100%; display: none">
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox" align="left" width="50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">Flash 宽度:</td>
                                    <td>
                                        <cc1:TextBox ID="flashwidth" runat="server" HintTitle="提示" HintInfo="请输入 Flash 广告的宽度, 单位为像素"
                                            Width="40px" RequiredFieldType="数据校验" CanBeNull="可为空"></cc1:TextBox>px
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  class="panelbox" align="right" width="50%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">Flash 高度:</td>
                                    <td>
                                        <cc1:TextBox ID="flashheight" runat="server" HintTitle="提示" HintInfo="请输入 Flash 广告的高度, 单位为像素"
                                            Width="40px" RequiredFieldType="数据校验" CanBeNull="可为空"></cc1:TextBox>px
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">Flash 地址:</td>
                                    <td>
                                        <cc1:TextBox ID="flashsrc" runat="server" HintTitle="提示" HintInfo="请输入 Flash 广告的调用地址, 以http://开头"
                                            Width="344px" RequiredFieldType="暂无校验" CanBeNull="可为空" Text=""></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </div>
                
                <div id="silverlight" style="width: 100%; display: none;">
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">wmv 地址:</td>
                                    <td>
                                        <cc1:TextBox ID="slwmvsrc" runat="server" HintTitle="提示" HintInfo="请输入 Wmv 广告的调用地址, 以http://开头"
                                            Width="344px" RequiredFieldType="暂无校验" CanBeNull="可为空" Text=""></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">广告背景大图:</td>
                                    <td>
                                        <cc1:TextBox ID="slimage" runat="server" HintTitle="提示" HintInfo="请输入图片绝对地址, 以http://开头"
                                            Width="344px" RequiredFieldType="暂无校验" CanBeNull="可为空"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">底部浮现图片:</td>
                                    <td>
                                        <cc1:TextBox ID="buttomimg" runat="server" HintTitle="提示" HintInfo="请输入图片绝对地址, 以http://开头"
                                            Width="344px" RequiredFieldType="暂无校验" CanBeNull="可为空" Text=""></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">文字一:</td>
                                    <td>
                                        <cc1:TextBox ID="words1" runat="server" Width="344px" RequiredFieldType="暂无校验" CanBeNull="可为空"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">文字二:</td>
                                    <td>
                                        <cc1:TextBox ID="words2" runat="server" Width="344px" RequiredFieldType="暂无校验" CanBeNull="可为空" Text=""></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="panelbox">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">文字三:</td>
                                    <td>
                                        <cc1:TextBox ID="words3" runat="server" Width="344px" RequiredFieldType="暂无校验" CanBeNull="可为空"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </div>
            </fieldset>
            <script type="text/javascript">
		        showadhint();
		        function showadhint()
		        {
			        adtype1.style.display='none';
			        adtype2.style.display='none';
			        adtype3.style.display='none';
			        adtype4.style.display='none';
			        adtype5.style.display='none';
			        adtype6.style.display='none';
			        adtype7.style.display='none';
			        adtype8.style.display = 'none';
			        adtype9.style.display = 'none';	
			        adtype10.style.display = 'none';
			        adtype11.style.display = 'none';				
			        inpostad.style.display = 'none';
        			
			        paramselect.style.display = 'block';
			        silverlight.style.display='none';		        
			        
			        showparameters();
        			
        			
		            switch(Form1.type.value)
		            {
		                case "0":
		                {
					        adtype1.style.display='block';
					        break;
				        }
				        case "1":
				        {
					        adtype2.style.display='block';
					        break;
				        }
				        case "2":
				        {
					        adtype3.style.display='block';
					        break;
				        }
				        case "3":
				        {
					        adtype4.style.display='block';					
					        inpostad.style.display = 'block';
					        break;
				        }
				        case "4":
				        {
					        adtype5.style.display='block';
					        break;
				        }
				        case "5":
				        {
					        adtype6.style.display='block';
					        break;
		                }
				        case "6":
				        {
				            paramselect.style.display = 'none';
					        adtype7.style.display='block';
		                    htmlcode.style.display='none';
			                word.style.display='none';
			                image.style.display='none';
			                flash.style.display='none';
			                silverlight.style.display='block';
					        break;
		                }
		                case "7":
		                {
		                    adtype8.style.display = 'block';
		                    break;
		                }
		                case "8":
		                {
		                    adtype9.style.display = 'block';
		                    break;
		                }
		                case "9":
		                {
		                    adtype10.style.display = 'block';
		                    break;
		                }
		            }
		            updateparameters();
		            showparameters();
		        }
        		
		        function updateparameters()
		        {
		           Form1.parameters.length=0;
		           var htmlcode = new Option('代码','htmlcode',false,false);
		           var word  = new Option('文字','word',false,false); 
                   var image = new Option('图片','image',false,false); 
                   var flash = new Option('flash','flash',false,false); 
                   Form1.parameters.options[0] = htmlcode;
                   Form1.parameters.options[1] = word;
                   Form1.parameters.options[2] = image;
                   Form1.parameters.options[3] = flash;
		        
		            if((Form1.type.value=='4')||(Form1.type.value=='5'))
		            {
		                if(Form1.parameters[1].value=='word')
		                {
		                   Form1.parameters.remove(1); 
		                   //去掉文字
		                }
		            }
		            else if(Form1.type.value=='16')
		            {
                        Form1.parameters.length = 0;
                        var image = new Option('图片','image',false,false);
                        Form1.parameters.options[0] = image;
		            }
		            else
		            {
		           
		               if(Form1.parameters[1].value!='word')
		               {
		                   var htmlcode = new Option('代码','htmlcode',false,false);
                           var image = new Option('图片','image',false,false); 
                           var flash = new Option('flash','flash',false,false); 
                           Form1.parameters.options[1] = htmlcode;
                           Form1.parameters.options[2] = image;
                           Form1.parameters.options[3] = flash;
                           
		               }
		            }
		            
		           
		        }
        		
		        showparameters();
		        showadhint();
		        function showparameters()
		        {
			        //	alert(parameters);
		            htmlcode.style.display='none';
			        word.style.display='none';
			        image.style.display='none';
			        flash.style.display='none';
			        silverlight.style.display='none';
        			
		            switch(Form1.parameters.value)
		            {
		                case "htmlcode":
		                {
					        htmlcode.style.display='block';
					        break;
				        }
				        case "word":
				        {
					        word.style.display='block';
					        break;
				        }
				        case "image":
				        {
					        image.style.display='block';
					        break;
				        }
				        case "flash":
				        {
					        flash.style.display='block';
					        break;
				        }
		            }
		            
		            if(Form1.type.value=='16')
		            {
		                  $('imgheight').style.display="none";
                          $('imgwidth').style.display="none";
                          $('imgtitle').style.display="none";
                          $('pxwidth').style.display="none";
                          $('pxhtight').style.display="none";
                          $('imgwidthtxt').style.display="none";
                          $('imgheighttxt').style.display="none";
                          $('imgtitletxt').style.display="none";
		            }
		        }
        		
		        function AddWith(change)
		        {
        	

	          var newheight = parseInt(document.getElementById("<%=code.ClientID%>").style.height, 10) + change;    
        	
               if(newheight >= 100) {  
                 document.getElementById("<%=code.ClientID%>").style.height = newheight + 'px';   
                 
                                    }    
              }
            </script>
        <cc1:Hint ID="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
        <div class="Navbutton">
            <cc1:Button ID="UpdateADInfo" runat="server" Text=" 提 交 "></cc1:Button>&nbsp;&nbsp;
            <cc1:Button ID="DeleteADInfo" runat="server" Text=" 删 除 " ButtonImgUrl="../images/del.gif"></cc1:Button>&nbsp;&nbsp;
            <button type="button" class="ManagerButton" id="Button3" onClick="window.history.back();"><img src="../images/arrow_undo.gif"/> 返 回 </button>
        </div>
    </form> 
    </div>
    
</body>
</html>
