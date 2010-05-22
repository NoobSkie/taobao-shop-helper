 <%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/FollowFriendScheme.aspx.cs" inherits="Home_Room_FollowFriendScheme" enableEventValidation="false" %>
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
     
    <link href="Style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function showDialog(url)
        {
            var dialogWidth = 800;
            var dialogHeight = 450;
            var w = window.showModalDialog(url + "&r=" + Math.random(),"","dialogWidth:"+dialogWidth+"px;dialogHeight="+dialogHeight+"px;center:yes;status:no;help:no;");
            
            if(w == "1")
            {
                
            }
            else
            {
                return false;
            }
        }
    </script>
</head>
<body onkeydown="if(event.keyCode==13){__doPostBack('btnSearch','');}">
    <form id="form1" runat="server">
    <asp:HiddenField ID="HidLotteryID" runat="server" />
    <asp:HiddenField ID="HidNumber" runat="server" />
    <div style=" padding-bottom:8px;">
        <table cellpadding="0" cellspacing="0" style="width:100%;" bgcolor="#F2F2F2" style=" height:50px" >
            <tr>
                <td style="font-weight: bold; color: #FF0065; padding-left:30px; width:100px;">
                    添加好友跟单
                </td>
                <td style="padding-left:15px; width:100px ;">
                    <asp:TextBox ID="TxtName" runat="server" CssClass="in_text" value="输入用户名"
                        size="25" onfocus="if(this.value=='输入用户名')this.value='';" onblur="if(this.value=='')this.value='输入用户名';"></asp:TextBox>
                </td>
                <td style="padding-left:24px; width:100px;">
                    <ShoveWebUI:ShoveConfirmButton ID="btnSearch" runat="server" BackgroupImage="images/button_sousuo.jpg"
                        Style="cursor: hand;" BorderStyle="None" Height="23px" OnClick="btnSearch_Click"
                        Width="72px" />
                </td>
                <td style="padding-left:24px;">
                    <asp:HyperLink ID="hlCancel" runat="server">返回</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:DataGrid ID="g" runat="server" Width="100%" BorderStyle="None" AllowSorting="True" bordercolorlight="#BCD2E9" bgcolor="#E9F1F8"
            AllowPaging="True" PageSize="22" AutoGenerateColumns="False" CellPadding="0"
            BackColor="#E9F1F8" OnItemDataBound="g_ItemDataBound" CellSpacing="0" OnItemCommand="g_ItemCommand"
            GridLines="None">
             <HeaderStyle HorizontalAlign="Center" CssClass="blue12_line" Height="30px" ForeColor="#0066BA">
        </HeaderStyle>
        <ItemStyle Height="30px" HorizontalAlign="Center" BackColor="#FFFFFF" CssClass="blue12">
        </ItemStyle>
            <Columns>
                <asp:BoundColumn DataField="Name" HeaderText="好友">
                    <HeaderStyle HorizontalAlign="Center" Width="16%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="战绩">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" ForeColor="Black"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="已定制/可定制">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="所有跟单人">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:BoundColumn HeaderText="我的定制状态">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="定制自动跟单">
                    <ItemTemplate>
                        <asp:Label ID="lbEdit" runat="server"></asp:Label>
                        <ShoveWebUI:ShoveLinkButton ID="Cancel" runat="server" CommandName="Cancel" AlertText="您确认取消此定制跟单吗?">取消</ShoveWebUI:ShoveLinkButton>
                    </ItemTemplate>
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                </asp:TemplateColumn>
                <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
            </Columns>
            <PagerStyle Visible="False"></PagerStyle>
        </asp:DataGrid>
        <ShoveWebUI:ShoveGridPager ID="gPager" runat="server" Width="100%" PageSize="22"
            ShowSelectColumn="False" DataGrid="g" AlternatingRowColor="#F8F8F8" GridColor="#FFFFFF"
            HotColor="MistyRose" OnPageWillChange="gPager_PageWillChange" OnSortBefore="gPager_SortBefore" RowCursorStyle="" />
    </div>
    </form>
    <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
<script type="text/javascript" language="javascript">
    parent.document.getElementById('iframeFollowScheme').style.height = parent.iframeFollowScheme.document.body.scrollHeight;
    document.getElementById("g").setAttribute("border", "1");
    document.getElementById("g").removeAttribute("style");
    document.getElementById("g").setAttribute("width", "100%");
    </script>