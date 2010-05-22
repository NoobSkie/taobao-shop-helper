<%@ page language="C#" autoeventwireup="true" CodeFile="OpenManual.aspx.cs" inherits="Admin_OpenManual" validaterequest="false" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table id="Table1" cellspacing="0" cellpadding="0" width="90%" align="center" border="0">
                <tr>
                    <td style="height: 21px">
                        <font face="宋体">请选择
                            <asp:DropDownList ID="ddlLottery" runat="server" AutoPostBack="True" Width="140px" OnSelectedIndexChanged="ddlLottery_SelectedIndexChanged">
                            </asp:DropDownList>&nbsp;
                            <asp:DropDownList ID="ddlIsuse" runat="server" AutoPostBack="True" Width="120px" OnSelectedIndexChanged="ddlIsuse_SelectedIndexChanged">
                            </asp:DropDownList></font></td>
                </tr>
                <tr>
                    <td align="center">
                        <ShoveWebUI:ShoveDataList ID="g" runat="server" Width="100%" AllowPaging="True" OnPageIndexChanged="g_PageIndexChanged" OnItemCommand="g_ItemCommand">
                            <HeaderTemplate>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="td4" width="6%">
                                            <strong>发起人</strong></td>
                                        <td class="td4" width="12%">
                                            <strong>方案编号</strong></td>
                                        <td class="td4" width="7%">
                                            <strong>玩法</strong></td>
                                        <td class="td4" width="20%">
                                            <strong>购买内容</strong></td>
                                        <td class="td4" width="4%">
                                            <strong>倍数</strong></td>
                                        <td class="td4" width="8%">
                                            <strong>金额</strong></td>
                                        <td class="td4" width="8%">
                                            <strong>中奖奖金</strong></td>
                                        <td class="td4" width="8%">
                                            <strong>税后奖金</strong></td>
                                        <td class="td4" width="20%">
                                            <strong>中奖描述</strong></td>
                                        <td class="td4" width="5%">
                                            <strong>开奖</strong></td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <PagerStyle HorizontalAlign="Center"></PagerStyle>
                            <FooterTemplate>
                                <hr size="1">
                            </FooterTemplate>
                            <ItemTemplate>
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td width="6%">
                                            <%# DataBinder.Eval(Container.DataItem,"InitiateName")%>
                                            <input id="tbSiteID" style="width: 37px; height: 21px" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"SiteID")%>' name="tbSiteID" runat="server">
                                            <input id="tbSchemeID" style="width: 37px; height: 21px" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"ID")%>' name="tbSchemeID" runat="server">
                                        </td>
                                        <td width="12%">
                                            <a class="li3" href='../Home/Room/Scheme.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>' target="_blank">
                                                <%# DataBinder.Eval(Container.DataItem,"SchemeNumber")%>
                                            </a>
                                        </td>
                                        <td width="7%">
                                            <%# DataBinder.Eval(Container.DataItem, "PlayTypeName")%>
                                        </td>
                                        <td width="20%">
                                            <%# DataBinder.Eval(Container.DataItem,"LotteryNumber")%>
                                        </td>
                                        <td width="4%">
                                            <%# int.Parse(Eval("Multiple").ToString()) == 0 ? (Eval("LocateWaysAndMultiples")) : (Eval("Multiple"))%>
                                        </td>
                                        <td width="8%">
                                            <font color="#ff0000">
                                                <%# DataBinder.Eval(Container.DataItem,"Money")%>
                                            </font>
                                        </td>
                                        <td width="8%">
                                            <asp:TextBox ID="tbWinMoney" runat="server" Width="60px" MaxLength="14">0</asp:TextBox></td>
                                        <td width="8%">
                                            <asp:TextBox ID="tbWinMoneyNoWithTax" runat="server" Width="60px" MaxLength="14">0</asp:TextBox></td>
                                        <td width="20%">
                                            <asp:TextBox ID="tbWinDescription" runat="server" Width="180px" MaxLength="14"></asp:TextBox></td>
                                        <td width="5%">
                                            <ShoveWebUI:ShoveConfirmButton ID="btnWin" runat="server" Width="60px" Height="20px" Text="开奖" BackgroupImage="../Images/Admin/buttbg.gif" AlertText="确信输入正确吗？" CommandName="btnWin" /></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </ShoveWebUI:ShoveDataList>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div style="width: 100%; position: relative; height: 86px; left: 0px; top: 0px;">
                            <asp:Label ID="Label1" Style="z-index: 100; left: 80px; position: absolute; top: 38px" runat="server">开奖号码</asp:Label>
                            <asp:TextBox ID="tbWinLotteryNumber" Style="z-index: 101; left: 151px; position: absolute; top: 37px" runat="server" Width="216px" MaxLength="50"></asp:TextBox>
                            <asp:Label ID="lbTipLotteryNumber" Style="z-index: 102; left: 451px; position: absolute; top: 37px" runat="server" ForeColor="Red">格式：31032200111220</asp:Label>
                            <asp:Label ID="Label7" Style="z-index: 103; left: 80px; position: absolute; top: 64px" runat="server">开奖公告：</asp:Label>
                            <ShoveWebUI:ShoveConfirmButton ID="btnEnd" Style="z-index: 103; left: 381px; position: absolute; top: 37px" runat="server" Width="60px" Height="20px" BackgroupImage="../Images/Admin/buttbg.gif" Text="开奖结束" AlertText="确信输入无误，并立即结束本期开奖吗？" OnClick="btnEnd_Click" />
                            <asp:Label ID="Label2" Style="z-index: 105; left: 16px; position: absolute; top: 8px" runat="server">开奖结束工作：</asp:Label>
                            <asp:Label ID="Label3" Style="z-index: 106; left: 104px; position: absolute; top: 8px" runat="server" ForeColor="Red">(当确信手工开奖工作结束后，填写下面信息并点击“开奖结束”按钮，系统将执行所有清理工作)</asp:Label>
                        </div>
                        <FTB:FreeTextBox ID="tbOpenAffiche" Width="100%" Height="340px" runat="server" SupportFolder="../FreeTextBox/" ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough;Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImageFromGallery,InsertRule|Cut,Copy,Paste;Undo,Redo,Print" ButtonSet="OfficeXP" ImageGalleryUrl="../FreeTextBox/ftb.imagegallery.aspx?rif={0}&cif={0}" Language="zh-cn" DesignModeCss="../Style/main.css" HtmlModeCssClass="../Style/main.css">
                        </FTB:FreeTextBox>
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
