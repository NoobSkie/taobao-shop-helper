<%@ page language="c#" inherits="Discuz.Web.Admin.usergrid, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>用户列表</title>
    <link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />
    <link href="../styles/calendar.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/common.js"></script>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/modalpopup.js"></script>
    <script type="text/javascript">
        function Check(form,checked)
        {
            CheckByName(form,'uid',checked);
            checkedEnabledButton(form,'uid','StopTalk','DeleteUser')
        }
    </script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <div class="ManagerForm">
            <fieldset>
                <legend style="background: url(../images/icons/icon32.jpg) no-repeat 6px 50%;">搜索用户</legend>
                <asp:Panel ID="searchtable" runat="server" Visible="true">
                <table cellspacing="0" cellpadding="4" width="100%" align="center">
                    <tr>
                        <td  class="panelbox" width="50%" align="left">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">用 户 名:</td>
                                    <td>
                                        <cc1:TextBox ID="Username" runat="server" RequiredFieldType="暂无校验" Width="100"></cc1:TextBox>&nbsp;
                                        模糊查找<input id="islike" type="checkbox" value="1" name="cins" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>用 户 组:</td>
                                    <td>
                                        <cc1:DropDownList ID="UserGroup" runat="server">
                                        </cc1:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>用户ID (UID):</td>
                                    <td>
                                        <cc1:TextBox ID="uid" runat="server" RequiredFieldType="暂无校验" Width="100"></cc1:TextBox>&nbsp;格式:1,2,3
                                        <asp:RegularExpressionValidator ID="homephone" runat="SERVER" ControlToValidate="uid"
                                            ErrorMessage="输入错误" ValidationExpression="^([1-9]*,)*[0-9]*$">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>用户金币:</td>
                                    <td>
                                        大于或等于:<cc1:TextBox ID="credits_start" runat="server" RequiredFieldType="数据校验" Size="8" MaxLength="9"></cc1:TextBox><br />
                                        小于或等于:<cc1:TextBox ID="credits_end" runat="server" RequiredFieldType="数据校验" Size="8" MaxLength="9"></cc1:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>用户发帖数:</td>
                                    <td>
                                        大于或等于:<cc1:TextBox ID="posts" runat="server" RequiredFieldType="数据校验" Width="80"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  class="panelbox" width="50%" align="right">
                            <table width="100%">
                                <tr>
                                    <td style="width: 80px">昵 称:</td>
                                    <td>
                                        <cc1:TextBox ID="nickname" runat="server" RequiredFieldType="暂无校验" Width="150"></cc1:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Email 包含:</td>
                                    <td>
                                        <cc1:TextBox ID="email" runat="server" RequiredFieldType="暂无校验" Width="150"></cc1:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>注册日期:</td>
                                    <td>
                                        从&nbsp;<cc1:Calendar ID="joindateStart" runat="server" ReadOnly="False" ScriptPath="../js/calendar.js">
                                        </cc1:Calendar>
                                        到&nbsp;<cc1:Calendar ID="joindateEnd" runat="server" ReadOnly="False" ScriptPath="../js/calendar.js">
                                        </cc1:Calendar><br />
                                        使用日期查找<input id="ispostdatetime" type="checkbox" value="1" name="cins" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>最后登陆IP:</td>
                                    <td>
                                        <cc1:TextBox ID="lastip" runat="server" RequiredFieldType="IP地址" Width="150"></cc1:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>用户精华帖数:</td>
                                    <td>
                                        大于或等于:<cc1:TextBox ID="digestposts" runat="server" RequiredFieldType="数据校验" Width="80"></cc1:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>                    
                    <tr>
                        <td align="center" colspan="2">
                            <cc1:Button ID="Search" runat="server" Text="开始搜索"></cc1:Button>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <cc1:Button ID="ResetSearchTable" runat="server" Text="重设搜索条件" Visible="False"></cc1:Button>
            </fieldset>
        </div>
        <br />
        <table width="100%">
            <tr>
                <td>
                    <cc1:DataGrid ID="DataGrid1" runat="server" OnPageIndexChanged="DataGrid_PageIndexChanged" align="center">
                        <Columns>
                            <asp:TemplateColumn HeaderText="<input title='选中/取消' onclick='Check(this.form,this.checked)' type='checkbox' name='chkall' id='chkall' />">
                                <HeaderStyle Width="20px" />
                                <ItemTemplate>
						            <%# DataBinder.Eval(Container, "DataItem.uid").ToString() != "1" ? "<input id=\"uid\" onclick=\"checkedEnabledButton(this.form,'uid','StopTalk','DeleteUser')\" type=\"checkbox\" value=\"" + DataBinder.Eval(Container, "DataItem.uid").ToString() + "\"	name=\"uid\">" : ""%>
						        </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="">
                                <ItemTemplate>
							        <a href="#" onclick="javascript:window.location.href='global_edituser.aspx?uid=<%# DataBinder.Eval(Container, "DataItem.uid").ToString()%>&condition=<%=ViewState["condition"]==null?"":Discuz.Common.Utils.HtmlEncode(ViewState["condition"].ToString().Replace("'","~^").Replace("%","~$"))%>';">编辑</a>
						        </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="">
                                <ItemTemplate>
					    	        <a href="#" onclick="javascript:window.location.href='global_givemedals.aspx?uid=<%# DataBinder.Eval(Container, "DataItem.uid").ToString()%>&condition=<%=ViewState["condition"]==null?"":Discuz.Common.Utils.HtmlEncode(ViewState["condition"].ToString().Replace("'","~^").Replace("%","~$"))%>';">勋章</a>
						        </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="uid" HeaderText="用户ID" Visible="false"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="用户名">
                                <ItemTemplate>
							        <a href="../../userinfo-<%# DataBinder.Eval(Container, "DataItem.uid")%>.aspx" target="_blank"><%# DataBinder.Eval(Container, "DataItem.username")%></a>
						        </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="grouptitle" HeaderText="所属组"></asp:BoundColumn>
                            <asp:BoundColumn DataField="nickname" HeaderText="昵称"></asp:BoundColumn>
                            <asp:BoundColumn DataField="posts" HeaderText="发帖数"></asp:BoundColumn>
                            <asp:BoundColumn DataField="lastactivity" HeaderText="最后活动时间"></asp:BoundColumn>
                            <asp:BoundColumn DataField="joindate" HeaderText="注册时间" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
                            <asp:BoundColumn DataField="credits" HeaderText="金币"></asp:BoundColumn>
                            <asp:BoundColumn DataField="email" HeaderText="邮箱"></asp:BoundColumn>
                            <asp:BoundColumn DataField="lastvisit" HeaderText="上次访问时间"></asp:BoundColumn>
                        </Columns>
                    </cc1:DataGrid>
                </td>
            </tr>
        </table>
        <p style="text-align:right;">
            <table style="float:right">
                <tr>
                    <td><cc1:Button ID="StopTalk" runat="server" Text=" 禁 言 " designtimedragdrop="247" Enabled="false"></cc1:Button>&nbsp;&nbsp;</td>
                    <td><cc1:Button ID="DeleteUser" runat="server" Text=" 删 除 " ButtonImgUrl="../images/del.gif" Enabled="false"></cc1:Button>&nbsp;&nbsp;</td>
                    <td>
                        <cc1:CheckBoxList ID="deltype" runat="server" RepeatColumns="1" RepeatLayout="flow">
                            <asp:ListItem Value="1">删除但保留该用户所发帖子</asp:ListItem>
                            <asp:ListItem Value="2">删除但保留该用户已发送的短消息</asp:ListItem>
                        </cc1:CheckBoxList>
                    </td>
                </tr>
            </table>              
        </p>
    </form>
    
</body>
</html>
