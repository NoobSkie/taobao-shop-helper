<%@ page language="C#" autoeventwireup="true" CodeFile="~/Home/Room/DistillByAlipay.aspx.cs" inherits="Home_Room_DistillByAlipay" enableEventValidation="false" %>

<%@ Register Assembly="Shove.Web.UI.4 For.NET 3.5" Namespace="Shove.Web.UI" TagPrefix="ShoveWebUI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link href="Style/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="javaScript/Public.js" language="javascript" charset="gbk"></script>

    <script type="text/javascript" language="javascript">
        function InputMask_Number() {
            if (window.event.keyCode < 48 || window.event.keyCode > 57)
                return false;
            return true;
        }
        function Show() {
            parent.document.getElementById("tb_remind").style.display = "";
            parent.document.getElementById("tb_times").style.display = "";
            parent.document.getElementById("td_Tips").style.display = "";
            parent.document.getElementById("tb_mains").style.backgroundColor = "#DDDDDD";
        }
    </script>
</head>
<body onload="Show();">
    <form id="form1" runat="server">
    <asp:Panel ID="pnlSafeSet" runat="server" Visible="true" Style="text-align: center;">
        <table width="90%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
            <tr bgcolor="#C0DBF9">
                <td colspan="2" height="30" align="left" bgcolor="#FFFFFF" class="red14">
                    第一步：设置安全保护问题
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="20" colspan="2" bgcolor="#FFFFFF" class="black12">
                    <div id="hr">
                    </div>
                </td>
            </tr>
            <tr  id="trOldQue"  runat="server" bgcolor="#C0DBF9" visible="false">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    原安全保护问题：
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <asp:Label ID="lbOQuestion" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr id="trOldAns" runat="server" visible="false" bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    原答案：
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <asp:TextBox ID="tbOAnswer" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td width="20%" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    安全保护问题：
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <asp:DropDownList ID="ddlQuestion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlQuestion_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
             <tr id="trMQ" runat="server" visible="false"  bgcolor="#C0DBF9">
                <td   height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    自定义问题：
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <asp:TextBox ID="tbMyQuestion" runat="server" MaxLength="90" Width="550"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                     答案：
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <asp:TextBox ID="tbAnswer" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="10" align="right" bgcolor="#FFFFFF" class="black12">
                    &nbsp;
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    &nbsp;
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    &nbsp;
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <ShoveWebUI:ShoveConfirmButton ID="ShoveConfirmButton2" Style="cursor: pointer;"
                        runat="server" Width="91px" Height="28px" CausesValidation="true" BackgroupImage="images/zfb_bt_xiayibu.jpg"
                        BorderStyle="None" OnClick="btnSafeSetNext_Click" />
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="10" align="right" bgcolor="#FFFFFF" class="black12">
                    &nbsp;
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    
     <asp:Panel ID="pnlUserEdit" runat="server" Visible="true" Style="text-align: center;">
        <table width="90%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
            <tr bgcolor="#C0DBF9">
                <td colspan="2" height="30" align="left" bgcolor="#FFFFFF" class="red14">
                   第二步：完善会员资料
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="20" colspan="2" bgcolor="#FFFFFF" class="black12">
                    <div id="hr">
                    </div>
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    真实姓名：<span class="red12"></span>
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <asp:TextBox ID="tbRealityName" runat="server" Width="160px"></asp:TextBox>
                            <asp:Label ID="lbRealityName" runat="server" Visible="false"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="lbIsRealityNameValided" runat="server"></asp:Label>
                </td>
            </tr>
            <tr id="trRealityName" runat="server" visible="true" bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    &nbsp;
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <span class="red12">非常重要，您提款的重要依据，提款时银行卡的户名必须是这里填写的真实姓名，一旦提交将不可更改！</span>
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td width="20%" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    身份证号码：<span class="red12"></span>
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <asp:TextBox ID="tbIdIDCardNumber" Text="" runat="server" Width="160px"></asp:TextBox>
                            <asp:Label ID="lbIdCardNumber" runat="server" Visible="false"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="lbIsIdCardNumberValided" runat="server"></asp:Label>
                </td>
            </tr>
             <tr id="trIdCardNumber" runat="server" visible="true"  bgcolor="#C0DBF9">
                <td   height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    &nbsp;
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <span class="blue12">填写成功后用户不能自行修改，如需修改，请点击&nbsp;</span><span
                                    class="red12">在线客服</span>&nbsp;<span class="blue12">咨询处理流程，请确认。</span>
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="10" align="right" bgcolor="#FFFFFF" class="black12">
                    &nbsp;
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    &nbsp;
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    &nbsp;
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <ShoveWebUI:ShoveConfirmButton ID="ShoveConfirmButton3" Style="cursor: pointer;"
                        runat="server" Width="91px" Height="28px" CausesValidation="true" BackgroupImage="images/zfb_bt_xiayibu.jpg"
                        BorderStyle="None" OnClick="btnUserEditNext_Click" />
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="10" align="right" bgcolor="#FFFFFF" class="black12">
                    &nbsp;
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    <asp:Panel ID="pnlFirst" runat="server" Visible="true" Style="text-align: center;">
        <table width="90%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px;">
            <tr bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="red14">
                    支付宝账号提款
                </td>
                <td align="left" bgcolor="#FFFFFF" class="blue12_2" style="padding-left: 10px;">
                    &nbsp;
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="20" colspan="2" bgcolor="#FFFFFF" class="black12">
                    <div id="hr">
                    </div>
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    当前可提款金额：
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <span class="red12">
                        <asp:Label ID="lbMoney" runat="server"></asp:Label></span> 元 (只能取整数金额)
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    提款金额：
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <asp:TextBox ID="tbMoney" CssClass="in_text_hui" runat="server" autocomplete="off"
                        onkeypress="return InputMask_Number();" />
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    支付宝账号：
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <span class="blue12">
                        <asp:Label ID="lbAlipayName" runat="server"></asp:Label></span>
                    <label id="labBindState" runat="server">
                    </label>
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="20" colspan="2" bgcolor="#FFFFFF" class="black12">
                    <div id="hr">
                    </div>
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    &nbsp;
                </td>
                <td align="left" bgcolor="#FFFFFF" class="red12" style="padding-left: 10px;">
                    （为了您的账户安全，请您输入以下信息进行确认）
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td width="20%" height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    核对真实姓名：
                </td>
                <td width="80%" align="left" bgcolor="#FFFFFF" class="blue12_2" style="padding-left: 10px;">
                    <label>
                        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                    </label>
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    安全保护问题：
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <asp:Label ID="lbQuestion" runat="server"></asp:Label>
                    &nbsp;&nbsp; <span class="blue12"><a href="SafeSet.aspx?FromUrl='Distill.aspx?Type=1'" target="_parent">
                        <asp:Label ID="lbQuestionInfo" runat="server"></asp:Label>
                    </a></span>
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    答案：
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <asp:TextBox ID="tbMyA" runat="server"></asp:TextBox>
                    <span class="red12">*</span>
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="10" align="right" bgcolor="#FFFFFF" class="black12">
                    &nbsp;
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    &nbsp;
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                    &nbsp;
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    <ShoveWebUI:ShoveConfirmButton ID="ShoveConfirmButton1" Style="cursor: pointer;"
                        runat="server" Width="91px" Height="28px" CausesValidation="true" BackgroupImage="images/zfb_bt_xiayibu.jpg"
                        BorderStyle="None" OnClick="btnNext_Click" />
                </td>
            </tr>
            <tr bgcolor="#C0DBF9">
                <td height="10" align="right" bgcolor="#FFFFFF" class="black12">
                    &nbsp;
                </td>
                <td align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlNext" runat="server" Visible="false">
        <table width="768" border="0" cellspacing="0" cellpadding="0" style="margin-top: 0px;">
            <tr bgcolor="#C0DBF9">
                <td height="15" bgcolor="#FFFFFF">
                    <table width="700" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                        <tr bgcolor="#C0DBF9">
                            <td height="30" colspan="3" align="left" bgcolor="#FFFFFF" class="black12">
                                尊敬的会员<span class="red12"><%=_User.RealityName %></span>，您本次提款业务明细如下：
                            </td>
                        </tr>
                        <tr bgcolor="#C0DBF9">
                            <td height="30" colspan="3" align="left" bgcolor="#FFFFFF" class="black12">
                                您原有预付款<span class="red12"><%=_User.Balance%></span>元，本次取款 <span class="red12">
                                    <asp:Label ID="lblDistillMoney" runat="server"></asp:Label></span>元后，您还有 <span class="red12">
                                        <asp:Label ID="lblLastMoney" runat="server"></asp:Label></span>元预付款。
                            </td>
                        </tr>
                        <tr bgcolor="#C0DBF9">
                            <td height="30" colspan="3" align="left" bgcolor="#FFFFFF" class="blue14">
                                此款项将发到您绑定的<span class="red14">支付宝账户</span>
                            </td>
                        </tr>
                        <tr bgcolor="#C0DBF9">
                            <td height="10" align="right" bgcolor="#FFFFFF" class="black12">
                                &nbsp;
                            </td>
                            <td colspan="2" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr bgcolor="#C0DBF9">
                            <td height="30" align="right" bgcolor="#FFFFFF" class="black12">
                                &nbsp;
                            </td>
                            <td width="23%" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                <ShoveWebUI:ShoveConfirmButton ID="btnOK" Style="cursor: pointer;" runat="server"
                                    Width="120" Height="32px" CausesValidation="true" BackgroupImage="images/zfb_bt_ok.jpg"
                                    BorderStyle="None" OnClick="btnOK_Click" />
                            </td>
                            <td width="64%" align="left" bgcolor="#FFFFFF" class="blue12" style="padding-left: 10px;">
                                <asp:LinkButton ID="lbReturn" runat="server" Text="返回上一步操作" OnClick="lbReturn_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr bgcolor="#C0DBF9">
                            <td height="10" align="right" bgcolor="#FFFFFF" class="black12">
                                &nbsp;
                            </td>
                            <td colspan="2" align="left" bgcolor="#FFFFFF" class="black12" style="padding-left: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:HiddenField ID="HidIsCps" runat="server" Value="0" />
    </form>
        <!--#includefile="../../Html/TrafficStatistics/1.htm"-->
</body>
</html>
