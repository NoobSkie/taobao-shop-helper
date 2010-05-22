<%@ page language="C#" autoeventwireup="true" CodeFile="UserDistill.aspx.cs" inherits="Admin_UserDistill" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/css.css" type="text/css" rel="stylesheet" />
    <link href="../Style/main.css" type="text/css" rel="stylesheet" />

    <style type="text/css">
        .visibility 
        {
            margin: 0px; 
        }
        .hidden 
        {
        	display: none;
        	margin: 0px; 
        }

    </style>

    <script language="javascript" type="text/jscript">
        function CheckAll(form) {
            for (var i = 0; i < form.elements.length; i++) {
                var e = form.elements[i];
                if (e.type == "checkbox")
                    e.checked = form.chkAll.checked;
            }
        }
        function checkAddSMS(form) {
            var bln = false;
            for (i = 0; i < form.elements.length; i++) {
                var e = form.elements[i];
                if (e.type == "checkbox" && e.checked && e.name != "chkAll") {
                    bln = true;
                    break;
                }
            }

            if (bln) {
                if (confirm('确定要将选定的客户加入到短信营销吗?')) {
                    return true;
                }
                else {
                    for (var i = 0; i < form.elements.length; i++) {
                        var e = form.elements[i];
                        if (e.type == "checkbox")
                            e.checked = false;
                    }

                    return false;
                }
            }
            else {
                alert('请选择您要操作的客户');
                for (var i = 0; i < form.elements.length; i++) {
                    var e = form.elements[i];
                    if (e.type == "checkbox")
                        e.checked = false;
                }

                return;
            }
        }

        function checkAddEMail(form) {
            var bln = false;
            for (i = 0; i < form.elements.length; i++) {
                var e = form.elements[i];
                if (e.type == "checkbox" && e.checked && e.name != "chkAll") {
                    bln = true;
                    break;
                }
            }

            if (bln) {
                if (confirm('确定要选定的客户加入到邮件群发吗?')) {
                    return true;
                }
                else {
                    for (var i = 0; i < form.elements.length; i++) {
                        var e = form.elements[i];
                        if (e.type == "checkbox")
                            e.checked = false;
                    }

                    return false;
                }
            }
            else {
                alert('请选择您要操作的客户');
                for (var i = 0; i < form.elements.length; i++) {
                    var e = form.elements[i];
                    if (e.type == "checkbox")
                        e.checked = false;
                }

                return;
            }
        }
    </script>

</head>
<body>
    <div>
        <br />
        <form id="form1" runat="server">
        <table id="Table1" cellspacing="0" cellpadding="0" width="96%" border="0" align="center">
            <tr>
                <td align="center">
                    <asp:DataList ID="g" runat="server" Width="100%" OnItemCommand="g_ItemCommand">
                        <ItemTemplate>
                            <font face="宋体">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td style="height: 19px" align="left">
                                            <input id="tbSiteID" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"SiteID") %>'
                                                runat="server" />
                                            <input id="tbID" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"ID") %>'
                                                runat="server" />
                                            <input id="tbUserID" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"UserID") %>'
                                                runat="server" />
                                            <input id="tbMoney" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"Money") %>'
                                                runat="server" />
                                            <input id="tbRealityName" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"RealityName") %>'
                                                runat="server" />
                                            <input id="tbProvince" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"Province") %>'
                                                runat="server" />
                                            <input id="tbCity" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"City") %>'
                                                runat="server" />
                                            <input id="tbBankUserName" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"BankUserName") %>'
                                                runat="server" />
                                            <input id="tbAlipayID" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"AlipayID") %>'
                                                runat="server" />
                                            <input id="tbAlipayName" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"AlipayName") %>'
                                                runat="server" />
                                            <input id="tbMemo" type="hidden" size="1" value='<%# DataBinder.Eval(Container.DataItem,"Memo") %>'
                                                runat="server" />
                                            <input id="tbPersonal" type="hidden" size="1" value='-1' runat="server" />
                                            用户姓名&nbsp;<font color="#ff0000"><%# DataBinder.Eval(Container.DataItem,"Name")%></font>&nbsp;
                                            真实姓名&nbsp;<font color="#ff0000"><%# DataBinder.Eval(Container.DataItem,"RealityName")%></font>&nbsp;
                                            省份&nbsp;<font color="#ff0000"><%# DataBinder.Eval(Container.DataItem,"Province")%></font>&nbsp;
                                            城市&nbsp;<font color="#ff0000"><%# DataBinder.Eval(Container.DataItem,"City")%></font>&nbsp;
                                            身份证号&nbsp;<font color="#ff0000"><%# DataBinder.Eval(Container.DataItem,"IDCardNumber")%></font>
                                
                                            <span id="Span1"   class='<%# DataBinder.Eval(Container.DataItem,"BankName").ToString()==""?"hidden":"visibility" %>' runat="server">
                                                开户银行&nbsp;<font color="#ff0000"><%# DataBinder.Eval(Container.DataItem,"BankTypeName")%></font>&nbsp;
                                                支行名称&nbsp;<font color="#ff0000"><%# DataBinder.Eval(Container.DataItem,"BankName")%></font>&nbsp;
                                                卡号&nbsp;<font color="#ff0000"><%# DataBinder.Eval(Container.DataItem,"BankCardNumber")%></font>
                                                帐户名&nbsp;<font color="#ff0000"><%# DataBinder.Eval(Container.DataItem,"BankUserName") %></font>&nbsp;
                                            </span>   
                                            <span id="Span2"  class='<%# DataBinder.Eval(Container.DataItem,"AlipayName").ToString().Trim()==""?"hidden":"visibility"%>' runat="server">
                                                支付宝ID&nbsp;<font color="#ff0000"><%# DataBinder.Eval(Container.DataItem,"AlipayID") %></font>&nbsp;
                                                支付宝用户名&nbsp;<font color="#ff0000"><%# DataBinder.Eval(Container.DataItem, "AlipayName")%></font>&nbsp;
                                            </span>   
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px" align="left">
                                           
                                            申请时间&nbsp;<font color="#ff0000"><%# DataBinder.Eval(Container.DataItem,"DateTime")%></font>
                                            &nbsp;提取金额<font color="#ff0000">
                                                <%# DataBinder.Eval(Container.DataItem,"Money")%></font>&nbsp;账户余额 <font color="#ff0000">
                                                    <%# double.Parse(Eval("Balance").ToString()).ToString("N")%></font>&nbsp;冻结金额
                                            <font color="#ff0000">
                                                <%# double.Parse(Eval("Freeze").ToString()).ToString("N")%></font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            理由
                                            <asp:TextBox ID="tbMemo1" runat="server" Width="442px" MaxLength="50"></asp:TextBox>&nbsp;
                                            <ShoveWebUI:ShoveConfirmButton ID="btnNoAccept" runat="server" Width="80px" CommandName="btnNoAccept"
                                                Height="20px" Text="拒绝提款" AlertText="确定要拒绝比条用户提款申请吗？" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td2" height="30" align="left">
                                            摘要
                                            <asp:TextBox ID="tbMemo2" runat="server" Width="442px" MaxLength="50"></asp:TextBox>&nbsp;
                                            <ShoveWebUI:ShoveConfirmButton ID="btnAccept" runat="server" Width="80px" CommandName="btnAccept"
                                                Height="20px" Text="接受提款" AlertText="确定接受提款吗？" />
                                            <input id="tbBankName" type="hidden" runat="server" value='<%# DataBinder.Eval(Container.DataItem,"BankName")%>' />
                                            <input id="tbBankCardNumber" type="hidden" runat="server" value='<%# DataBinder.Eval(Container.DataItem,"BankCardNumber")%>' />
                                            <input id="tbIsCps" type="hidden" runat="server" value='<%# DataBinder.Eval(Container.DataItem,"IsCps")%>' />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </font>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="labTip" runat="server" ForeColor="Red" Text="暂无提款申请。"></asp:Label>
                </td>
            </tr>
        </table>
        </form>
        <br />
    </div>
    <!--#includefile="~/Html/TrafficStatistics/1.htm"-->
</body>
</html>
