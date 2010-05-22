<%@ page language="C#" autoeventwireup="true" CodeFile="~/NewsPapers/NewsPaperList.aspx.cs" inherits="NewsPapers_NewsPaperList" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>彩友报－<%=_Site.Name %>主办－手机买彩票，就上<%=_Site.Name %></title>
    <meta runat="server" id="key" name="keywords" content="彩友报" />
    <meta runat="server" id="des" name="description" content="彩友报是<%=_Site.Name %>为广大彩民定期提供的一份彩票咨询电子期刊。" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
            font-family: "宋体";
            font-size: 12px;
        }
        .black24
        {
            font-family: "宋体";
            font-size: 14px;
            font-weight: bold;
            color: #4A4A4A;
            text-decoration: none;
        }
        .black24 A:link
        {
            font-family: "宋体";
            font-size: 14px;
            font-weight: bold;
            color: #4A4A4A;
            text-decoration: none;
        }
        .black24 A:visited
        {
            font-size: 14px;
            font-weight: bold;
            color: #4A4A4A;
            text-decoration: none;
            font-family: "宋体";
        }
        .black24 A:hover
        {
            font-size: 14px;
            font-weight: bold;
            color: #4A4A4A;
            text-decoration: underline;
        }
        .red14
        {
            font-size: 14px;
            color: #FF0065;
            font-family: "tahoma";
            line-height: 20px;
            font-weight: bold;
        }
        A
        {
            text-decoration: none;
        }
        A:hover
        {
            text-decoration: underline;
        }
        -- ></style>
    <link href="../Home/Room/Style/css.css" rel="stylesheet" type="text/css" />
    <link href="../Home/Room/Style/cyb.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../favicon.ico" />
</head>

<body>
    <form id="form1" runat="server">
    <table align="center">
        <tr>
            <td>
                <asp:PlaceHolder ID="phHead" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
    </table>
    <table width="1002" border="0" align="center" cellpadding="0" cellspacing="0" style="border: 1px solid #DDDDDD;">
        <tr>
            <td height="35" class="hui12" style="padding-left: 20px;" bgcolor="#F1F1F1">
                <asp:Label ID="lbTime" runat="server" Text="Label"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <span class="red12"><a href="<%=  ResolveUrl("~/NewsPapers") %>"><font style="color:Red;"> 彩友报首页</font> </a></span>
            </td>
            <td style="padding-right: 20px; text-align: right;" bgcolor="#F1F1F1">
                <span style="color: #6C6C6C;">选择期号</span>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlIsusesID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIsusesID_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table width="1002" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td id="tdIsuseOpenInfo" runat="server">
            </td>
        </tr>
    </table>
    <table align="center" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:PlaceHolder ID="phFoot" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
    </table>
    <map name="Map" id="Map">
        <area shape="rect" coords="7,27,147,69" href="http://club.icaile.com/showtopic-16552.aspx"
            target="_blank" />
    </map>
    <div>
    </div>
    </form>
    <!--#includefile="../Html/TrafficStatistics/1.htm"-->
</body>
</html>
