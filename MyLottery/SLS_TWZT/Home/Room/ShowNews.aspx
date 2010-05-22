<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/ShowNews.aspx.cs" inherits="Home_Room_ShowNews" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Src="UserControls/ZCDCHead.ascx" TagName="ZCDCHead" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>新闻内容-<%=_Site.Name %>－手机买彩票，就上<%=_Site.Name %> ！</title>
    <meta name="description" content="<%=_Site.Name %>彩票网<%=_Site.Url %>是一家服务于中国彩民的互联网彩票合买代购交易平台，涉及中国彩票彩种最全的网站，包含双色球,大乐透,七星彩,3d,足彩等众多彩种的实时开奖信息,图表走势、分析预测以及开奖信息等!" />
    <meta name="keywords" content="双色球合买,体育彩票,福利彩票,双色球开奖信息." />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <link href="../Web/Style/css.css" rel="stylesheet" type="text/css" />
    <link href="../Web/Style/div.css" rel="stylesheet" type="text/css" />
<link rel="shortcut icon" href="../../favicon.ico" /></head>
<body>
    <form id="form1" runat="server">
    <div id="box">
        <div>
            <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
            <uc1:ZCDCHead ID="ZCDCHead1" runat="server" />
        </div>
        <div>
            <div class="content" style="padding-top: 10px">
                <div class="content1_l">
                    <!-- 这里添加新闻列表的内容 -->
                     <table width="230" border="0" cellspacing="1" cellpadding="0" bgcolor="#BED2E9">
                    <tr>
                        <td height="26" background="ZQDC/images/bg_blue_28.jpg" style="padding: 0px 10px 0px 10px;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="4%">
                                        <img src="ZQDC/images/zc_point_red.jpg" width="3" height="14" />
                                    </td>
                                    <td width="62%" class="red14_2" style="padding-top: 3px;">
                                        焦点新闻
                                    </td>
                                    <td width="34%" align="right" class="hui12" style="padding-top: 3px;">
                                       更多&gt;&gt;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" bgcolor="#FFFFFF" style="padding: 10px 5px 10px 5px; background-image: url(ZQDC/images/bg_foot.jpg);
                            background-repeat: repeat-x; background-position: center bottom;">
                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                <tbody style="height: 24px;">
                                    <asp:Repeater ID="rptNews" runat="server" OnItemDataBound="rptNews_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td width="4%" class="hui14">
                                                    ·
                                                </td>
                                                <td width="96%" class="black12">
                                                    <asp:HyperLink ID="hlNewsTitle" runat="server" Target="_blank"></asp:HyperLink>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
                </div>
                <div class="content1_740">
                    <table width="740" border="0" cellpadding="0" cellspacing="1" bgcolor="#9BBFCA">
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" background="../Web/images/bg_title_27.jpg">
                                    <tr>
                                        <td width="28" height="26" align="center" class="blue">
                                            <img src="../Web/images/icon_red_line.gif" width="3" height="12" />
                                        </td>
                                        <td width="712" class="hui" style="padding-top: 2px;">
                                            当前位置：<a href="../../Default.aspx">首页</a> &gt;
                                            <asp:HyperLink ID="hlNewsType" runat="server"></asp:HyperLink>
                                            &gt; 新闻详细
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#FFFFFF" style="padding: 15px 20px 15px 20px;">
                                <!--startprint-->
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="36" align="center" class="red20">
                                            <asp:Label ID="lbTitle" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" bgcolor="#E1E1E1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="black12">
                                            <asp:Label ID="lbContent" runat="server"></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td height="1" bgcolor="#E1E1E1">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Image ID="ImgUrl" runat="server"></asp:Image>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" align="right" class="hui" style="padding-right: 20px;">
                                            日期：<asp:Label ID="lbDateTime" runat="server"></asp:Label>
                                            浏览次数：<asp:Label ID="lbCount" runat="server"></asp:Label>
                                            [<a onclick="window.close();" href="#">关闭本页</a>] [<a onclick="doPrint()" href="javascript:;">打印</a>]
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr id="ShowInfo" runat="server">
                                        <td>
                                            <table width="100%" align="center" border="0" cellpadding="0" cellspacing="1" style="background-color: #CDCDCD"
                                                id="NoNewsComments" runat="server" visible="false">
                                                <tr>
                                                    <td align="left" style="padding: 5px;" bgcolor="white" height="25px" class="black12">
                                                        暂无此文章的评论信息
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="CommentContents" runat="server">
                                        <td>
                                            <asp:Repeater ID="rptNewsComments" runat="server">
                                                <HeaderTemplate>
                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CDCDCD">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
                                                                <tr>
                                                                    <td align="right" valign="middle" height="25" width="45%" style="padding-right: 10px;"
                                                                        class="black12">
                                                                        网友：<%# Eval("CommentserName")%>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="55%" class="black12" height="25">
                                                                        评论时间：
                                                                        <%# Eval("DateTime")%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" valign="top" align="left" style="padding-left: 10px; padding-right: 10px;
                                                                        padding-top: 10px; padding-bottom: 10px;" class="black12">
                                                                        <%# Eval("Content")%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                    <tr id="Comments" runat="server">
                                        <td>
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CDCDCD">
                                                <tr>
                                                    <td style="width: 100%;" valign="top" bgcolor="#FFFFFF">
                                                        <br />
                                                        <table style="width: 100%;" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td height="26" align="left" style="padding: 5px;" class="black12">
                                                                    称呼：<asp:TextBox ID="tbCommentserName" runat="server" MaxLength="40">
                                                                    </asp:TextBox>&nbsp;&nbsp;现有 <font color="#F8332D">
                                                                        <asp:Label ID="labNewsComments" runat="server" Text="0"></asp:Label>
                                                                    </font>人对本文发表评论
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:TextBox ID="tbContent" TextMode="MultiLine" runat="server" Style="height: 80px;
                                                                        width: 98%;"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" valign="middle" height="30">
                                                                    <ShoveWebUI:ShoveConfirmButton ID="btnComments" runat="server" BackgroupImage="images/butt22.gif"
                                                                        Height="21px" OnClientClick="if(!isNull()) return false;" Width="61px" OnClick="btnComments_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <!--endprint-->
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div>
            <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
        </div>
    </div>
    <asp:HiddenField ID="hID" runat="server" />
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>

<script src="JavaScript/Public.js" type="text/javascript"></script>

<script type="text/javascript" language="javascript">
    function isNull() {
        var name = document.getElementById('tbCommentserName');
        var content = document.getElementById('tbContent');

        if (name.value == "") {
            alert("请输入您的姓名！");
            name.focus();

            return false;
        }

        if (content.value == "") {
            alert("请输入评价的内容！");
            content.focus();

            return false;
        }
        return confirm("您确信要发表评论吗？");

    }
    function doPrint() {
        bdhtml = window.document.body.innerHTML;
        sprnstr = "<!--startprint-->";
        eprnstr = "<!--endprint-->";
        prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
        prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
        window.document.body.innerHTML = prnhtml;
        window.print();
        window.document.body.innerHTML = bdhtml;
        window.document.location.reload();
    }
   
</script>

