<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shove.Web.UI.ImageLibrary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>图片元素库</title>
    <base target="_self" />
    <style type="text/css">
        body
        {
            font-family: "宋体";
            color: #3C3C3C;
            font-size: 10pt;
            line-height: 14pt;
            margin-left: 0px;
            margin-right: 0px;
            margin-top: 0px;
        }
        .a:link
        {
            color: #000000;
            text-decoration: none;
        }
        .a:active
        {
            color: #000000;
            text-decoration: none;
        }
        .a:visited
        {
            color: #000000;
            text-decoration: none;
        }
        .a:hover
        {
            color: #000000;
            text-decoration: underline;
        }
        .black12
        {
            font-size: 12px;
            color: #333333;
            font-family: "tahoma";
            line-height: 18px;
        }
        .black12 A:link
        {
            color: #333333;
            text-decoration: none;
        }
        .black12 A:active
        {
            color: #333333;
            text-decoration: none;
        }
        .black12 A:visited
        {
            color: #333333;
            text-decoration: none;
        }
        .black12 A:hover
        {
            color: #333333;
            text-decoration: underline;
        }
        .orange12
        {
            font-size: 12px;
            color: #ff6600;
            font-family: "tahoma";
            line-height: 18px;
            font-weight: bold;
        }
        .orange12 A:link
        {
            color: #ff6600;
            text-decoration: none;
        }
        .orange12 A:active
        {
            color: #ff6600;
            text-decoration: none;
        }
        .orange12 A:visited
        {
            color: #ff6600;
            text-decoration: none;
        }
        .orange12 A:hover
        {
            color: #ff6600;
            text-decoration: underline;
        }
        .style3
        {
            width: 20%;
        }
        .photo
        {
            padding: 2px;
            border: 1px solid #CCCCCC;
            background-color: #FFFFFF;
        }
        .in_p
        {
            height: 18px;
            border: 1px solid #21517F;
            font-family: "Arial" ,;
        }
    </style>

    <script type="text/javascript">
    function showObj() 
    {
        var div = document.getElementById("odiv");
        var img = document.getElementById("Img");

        if(div.style.display == "inline")
        {
            div.style.display = "none";
            img.src = "../Images/dian_2.jpg";
        }
        else
        {
            div.style.display = "inline";
            img.src = "../Images/dian_1.jpg";
        }
    }
    </script>

</head>
<body style="margin: 0px; background-color: buttonface;">
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
            <tr>
                <td height="25" style="background-image: url(../Images/pic_bg_25.jpg)" bgcolor="#f7f7f7" class="black12">
                    &nbsp;&nbsp;&nbsp;元素库 &gt; 图片库
                    <asp:Label runat="server" ID="lblNav"></asp:Label>
                </td>
            </tr>
            <tr>
                <td bgcolor="#f7f7f7">
                    <table width="800" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="170" valign="top">
                                <table width="150" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                </table>
                                <table width="150" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                    <tr>
                                        <td height="25" style="background-image: url(../Images/pic_bg_25.jpg)" bgcolor="#FFFFFF">
                                            <asp:TreeView ID="tvImgDir" Font-Bold="false" Font-Size="10pt" ForeColor="#003366" runat="server" OnSelectedNodeChanged="tvImgDir_SelectedNodeChanged">
                                            </asp:TreeView>
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellspacing="0" cellpadding="0" style="width: 152px">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="649" valign="top">
                                <table width="150" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                </table>
                                <table width="630" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="right" height="28" width="20%" class="black12">
                                            请输入关键字：
                                        </td>
                                        <td align="left" style="padding-left: 10px;" class="black12">
                                            <asp:TextBox runat="server" ID="tbKey" CssClass="in_p" Width="180px"></asp:TextBox>&nbsp;&nbsp;
                                            <asp:ImageButton runat="server" ID="ibSearch" ImageUrl="../Images/img_search.jpg" OnClick="ibSearch_Click" />&nbsp;
                                            <asp:Label runat="server" ID="lblMsg3" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table runat="server" id="tableUpLoadImg" visible="false" width="630" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="right" height="28" width="20%" class="black12">
                                            请选择图片：
                                        </td>
                                        <td align="left" style="padding-left: 10px;" class="black12">
                                            <asp:FileUpload runat="server" ID="fuUpLoadImg"  CssClass="in_p/>&nbsp;&nbsp;
                                            <asp:ImageButton runat="server" ID="ibUpLoad" ImageUrl="../Images/pic_botton_2.jpg" OnClick="ibUpLoad_Click" />&nbsp;
                                            <asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <table width="630" runat="server" id="tableUpLoadElement" visible="false" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left">
                                            <a href="#" onclick="showObj()">
                                                <img src="../Images/dian_2.jpg" id="Img" alt="" style="border: 0;" /></a><br />
                                            <div id="odiv" style="display: none; text-align: center; width:630;">
                                                <table  width="100%" style="background-color: #CCCCCC;" border="0" align="center" cellpadding="0" cellspacing="1">
                                                    <tr>
                                                        <td align="right" height="28" style="background-color: #FFFFFF;" width="20%" class="black12">
                                                            请选择元素类型：
                                                        </td>
                                                        <td align="left" style="padding-left: 10px; background-color: #FFFFFF;">
                                                            <asp:DropDownList runat="server" ID="ddlImgTypes" AutoPostBack="true" Height="28" CssClass="in_p" OnSelectedIndexChanged="ddlImgTypes_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" height="28" style="background-color: #FFFFFF;" width="20%" class="black12">
                                                            元素名：
                                                        </td>
                                                        <td align="left" style="padding-left: 10px; background-color: #FFFFFF;">
                                                            <asp:TextBox runat="server" ID="tbElementName" CssClass="in_p" Width="150px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" height="28" style="background-color: #FFFFFF;" width="20%" class="black12">
                                                            元素宽度：
                                                        </td>
                                                        <td align="left" style="padding-left: 10px; background-color: #FFFFFF;">
                                                            <asp:TextBox runat="server" ID="tbElementWidth" CssClass="in_p" Width="80px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" height="28" style="background-color: #FFFFFF;" width="20%" class="black12">
                                                            元素高度：
                                                        </td>
                                                        <td align="left" style="padding-left: 10px; background-color: #FFFFFF;">
                                                            <asp:TextBox runat="server" ID="tbElementHeight" CssClass="in_p" Width="80px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" height="28" style="background-color: #FFFFFF;" width="20%" class="black12">
                                                            备注描述：
                                                        </td>
                                                        <td align="left" style="padding-left: 10px; background-color: #FFFFFF;">
                                                            <asp:TextBox runat="server" ID="tbDescription" Width="200px" CssClass="in_p"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" height="28" style="background-color: #FFFFFF;" width="20%" class="black12">
                                                            请选择元素：
                                                        </td>
                                                        <td align="left" style="padding-left: 10px; background-color: #FFFFFF;" class="black12">
                                                            <asp:FileUpload runat="server" ID="fuUpLoadElement" CssClass="in_p" />&nbsp;
                                                            <asp:ImageButton runat="server" ID="ibUpLoadElement" ImageUrl="../Images/pic_botton_2.jpg" OnClick="ibUpLoadElement_Click" />&nbsp; &nbsp;
                                                            <asp:Label runat="server" ID="lblMsg2" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <table width="150" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                </table>
                                <table width="630" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                                    <tr>
                                        <td bgcolor="#FFFFFF">
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="8">
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="610" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:DataList runat="server" ID="ImageList" RepeatDirection="Horizontal" Width="100%" RepeatColumns="3">
                                                            <ItemTemplate>
                                                                <table width="180" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="21">
                                                                            <asp:CheckBox runat="server" ID="chk" CssClass='<%# Eval("imgUrl")%>' />
                                                                        </td>
                                                                        <td width="159" height="110">
                                                                            <img src='<%# Eval("imgUrl")%>' alt="" id="img" width="150" height="90" class="photo" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                        <td height="22" class="black12">
                                                                            名称：<asp:Label runat="server" ID="imgName" Text='<%# Eval("imgName") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="5" colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="8">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table width="630" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="10" colspan="4">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="91">
                                            <asp:ImageButton runat="server" ID="imgSelectAll" ImageUrl="../Images/pic_botton_5.jpg" OnClick="imgSelectAll_Click" />
                                        </td>
                                        <td width="90">
                                            <asp:ImageButton runat="server" ID="imgDelete" ImageUrl="../Images/pic_botton_4.jpg" OnClick="imgDelete_Click" />
                                        </td>
                                        <td width="410">
                                            <asp:ImageButton runat="server" ID="Submit" ImageUrl="../Images/pic_botton_3.jpg" OnClick="Submit_Click" />
                                            &nbsp;<asp:Label runat="server" ID="lblDeleteInfo" ForeColor="Red"></asp:Label>
                                        </td>
                                        <td width="39">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10" colspan="4">
                                        </td>
                                    </tr>
                                </table>
                                <table width="630" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="1" bgcolor="#CCCCCC">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="91" height="1" bgcolor="#FFFFFF">
                                        </td>
                                    </tr>
                                </table>
                                <table width="630" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="297" height="30" class="black12" align="center">
                                            <asp:LinkButton runat="server" CommandArgument="first" ID="lnkFirst" Text="首页" class="a" OnCommand="Page_Click"></asp:LinkButton>&nbsp;
                                            <asp:LinkButton runat="server" ID="lnkPrev" Text="上一页" CommandArgument="prev" class="a" OnCommand="Page_Click"></asp:LinkButton>&nbsp;
                                            <asp:LinkButton runat="server" ID="lnkNext" Text="下一页" CommandArgument="next" class="a" OnCommand="Page_Click"> </asp:LinkButton>&nbsp;
                                            <asp:LinkButton runat="server" ID="lnkLast" Text="尾页" CommandArgument="last" class="a" OnCommand="Page_Click"></asp:LinkButton>&nbsp; | 共 <span style="color: Red">
                                                <asp:Label runat="server" ID="lblTotalPage"></asp:Label></span> 页
                                        </td>
                                        <td width="47" class="black12">
                                            跳转到
                                        </td>
                                        <td width="69" class="black12">
                                            <label>
                                                <asp:TextBox runat="server" ID="tbPage" Width="57px"></asp:TextBox>
                                            </label>
                                        </td>
                                        <td width="30" class="black12" align="center">
                                            页
                                        </td>
                                        <td width="187" class="black12">
                                            <asp:ImageButton runat="server" ID="pageSubmit" ImageUrl="../Images/pic_botton_1.jpg" OnClick="pageSubmit_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <table width="150" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
