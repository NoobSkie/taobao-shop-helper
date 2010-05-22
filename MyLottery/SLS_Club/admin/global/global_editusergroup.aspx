<%@ page language="c#" inherits="Discuz.Web.Admin.editusergroup, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="cc3" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register Src="../UserControls/PageInfo.ascx" TagName="PageInfo" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="UserGroupPowerSetting" Src="../UserControls/usergrouppowersetting.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>编辑用户组</title>
    <link href="../styles/tab.css" type="text/css" rel="stylesheet" />
    <link href="../styles/colorpicker.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/common.js"></script>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/modalpopup.js"></script>
    <script type="text/javascript">	    
	    function validate(theform)
	    {
	        if(document.getElementById("TabControl1_tabPage51_groupTitle").value == "")
	        {
	            resetPage();
	            alert("用户组名称不能为空");
	            document.getElementById("TabControl1_tabPage51_groupTitle").focus();
	            return false;
	        }
	        var creditshigher = document.getElementById("TabControl1_tabPage51_creditshigher").value;
	        var creditslower = document.getElementById("TabControl1_tabPage51_creditslower").value;
	        if(!isNumber(creditshigher))
	        {
	            resetPage();
	            alert("金币下限为非数字");
	            document.getElementById("TabControl1_tabPage51_creditshigher").focus();
	            document.getElementById("TabControl1_tabPage51_creditshigher").value = "";
	            return false;
	        }
	        if(!isNumber(creditslower))
	        {
	            resetPage();
	            alert("金币上限为非数字");
	            document.getElementById("TabControl1_tabPage51_creditslower").focus();
	            document.getElementById("TabControl1_tabPage51_creditslower").value = "";
	            return false;
	        }
	        creditshigher = parseInt(creditshigher);
	        creditslower = parseInt(creditslower);
	        if (creditshigher >= creditslower)
            {
                resetPage();
                alert("金币下限必须小于金币上限");
                document.getElementById("TabControl1_tabPage51_creditshigher").focus();
                return;
            }
	        return validatebonusprice();
	    }
	    
	    function resetPage()
	    {
	        document.getElementById('success').style.display = 'none'
	        document.getElementById("UpdateUserGroupInf").disabled = false;
	    }
	</script>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <uc1:PageInfo ID="info1" runat="server" Icon="information" Text="编辑用户组时金币的上限和下限必须在当前用户组金币上下限范围之内.  <br />例如: 新手上路(已有)的金币上下限分别是50和0 ,那么编辑该用户组的金币上下限必须在(50≥上下限 ≥0) 之间. 而当要编辑的上下限跨越多个用户组金币上下限区间时, 系统将视为无效. " />
        <uc1:PageInfo ID="PageInfo1" runat="server" Icon="Warning" Text="如果想要扩展金币的上下限时可通过缩小相邻用户组金币的上下限来进行调整. <br />例如: 新手上路(已有)的金币上下限分别是50和0 , 如果想把上限扩展为55 ,只需调整相邻的&quot;注册会员&quot;组(上下限为200和50) 的上下限修改为200和55即可. 调整下限的方法与调整上限的方法类似. " />
        <table class="table1" cellspacing="0" cellpadding="4" width="100%" border="0">
            <tr>
                <td width="2px"></td>
                <td>
                    <cc3:TabControl ID="TabControl1" SelectionMode="Client" runat="server" TabScriptPath="../js/tabstrip.js" Width="660" Height="100%">
                        <cc3:TabPage Caption="基本信息" ID="tabPage51">
                            <table cellspacing="0" cellpadding="4" width="100%" align="center">
                                <tr>
                                    <td  class="panelbox" width="50%" align="left">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 110px">用户组名称:</td>
                                                <td>
                                                    <cc1:TextBox ID="groupTitle" runat="server" CanBeNull="必填" RequiredFieldType="暂无校验" Width="180" MaxLength="50"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>金币下限:</td>
                                                <td>
                                                    <cc1:TextBox ID="creditshigher" runat="server" CanBeNull="必填" RequiredFieldType="数据校验" HintInfo="所属该用户组用户的最低金币数" Text="0" Size="10" MaxLength="9"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>星星数:</td>
                                                <td>
                                                    <cc1:TextBox ID="stars" runat="server" CanBeNull="必填" RequiredFieldType="数据校验" HintInfo="该用户组显示的星星数" Text="0" Size="5" MaxLength="4"></cc1:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="SERVER" ControlToValidate="stars"
                                                        ErrorMessage="请输入正整数或者零" ValidationExpression="^[0-9]*$">
                                                    </asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>主题最高售价:</td>
                                                <td>
                                                    <cc1:TextBox ID="maxprice" runat="server" CanBeNull="必填" RequiredFieldType="数据校验"
                                                        Text="0" Size="5" MaxLength="4" HintInfo="主题出售使得作者可以将自己发表的主题隐藏起来,只有当浏览者向作者支付相应的交易金币后才能查看主题内容.此处设置用户出售主题时允许设置的最高价格,0 为不允许用户出售."></cc1:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="SERVER" ControlToValidate="maxprice"
                                                        ErrorMessage="请输入正整数或者零" ValidationExpression="^[0-9]*$">
                                                    </asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>签名最多字节:</td>
                                                <td>
                                                    <cc1:TextBox ID="maxsigsize" runat="server" CanBeNull="必填" RequiredFieldType="数据校验"
                                                        Text="0" Size="5" MaxLength="4" HintInfo="设置用户签名最大字节数,0 为不允许用户使用签名"></cc1:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="SERVER" ControlToValidate="maxsigsize"
                                                        ErrorMessage="请输入正整数或者零" ValidationExpression="^[0-9]*$">
                                                    </asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>论坛每天允许上<br />传附件总字节数:</td>
                                                <td>
                                                    <cc1:TextBox ID="maxsizeperday" runat="server" HintInfo="设置用户每 24 小时可以上传的附件总字节数.注意: 本功能会加重服务器负担,建议仅在必要时使用."
                                                        HintTitle="提示" CanBeNull="必填" RequiredFieldType="数据校验" Text="0" Size="10" MaxLength="9"></cc1:TextBox>(单位:字节)
                                                    <select onchange="document.getElementById('TabControl1_tabPage51_maxsizeperday').value=this.value">
                                                        <option value="">请选择</option>
                                                        <option value="51200">50K</option>
                                                        <option value="102400">100K</option>
                                                        <option value="153600">150K</option>
                                                        <option value="204800">200K</option>
                                                        <option value="256000">250K</option>
                                                        <option value="307200">300K</option>
                                                        <option value="358400">350K</option>
                                                        <option value="409600">400K</option>
                                                        <option value="512000">500K</option>
                                                        <option value="614400">600K</option>
                                                        <option value="716800">700K</option>
                                                        <option value="819200">800K</option>
                                                        <option value="921600">900K</option>
                                                        <option value="1024000">1M</option>
                                                        <option value="2048000">2M</option>
                                                        <option value="4096000">4M</option>
                                                        <option value="6144000">6M</option>
                                                        <option value="8192000">8M</option>
                                                        <option value="10240000">10M</option>
                                                        <option value="12288000">12M</option>
                                                        <option value="14336000">14M</option>
                                                        <option value="16384000">16M</option>
                                                        <option value="18432000">18M</option>
                                                        <option value="20480000">20M</option>
                                                        <option value="22528000">22M</option>
                                                        <option value="24576000">24M</option>
                                                        <option value="26624000">26M</option>
                                                        <option value="28672000">28M</option>
                                                        <option value="30720000">30M</option>
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>允许的评分范围:</td>
                                                <td>
                                                    <a href="#" class="TextButton" onclick="javascript:window.location.href='global_allowparticipatescore.aspx?pagename=global_editusergroup&groupid=<%=Request.Params["groupid"]%>'">
                                                        编辑评分范围</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td  class="panelbox" width="50%" align="right">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 110px">组名称颜色:</td>
                                                <td>
                                                    <cc1:ColorPicker ID="color" runat="server" ReadOnly="True" LeftOffSet="-23" TopOffSet="-212" HintInfo="用户组名称的显示颜色">
                                                    </cc1:ColorPicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>金币上限:</td>
                                                <td>
                                                    <cc1:TextBox ID="creditslower" runat="server" CanBeNull="必填" RequiredFieldType="数据校验" HintInfo="所属该用户组用户的最高金币数" Text="0" Size="10" MaxLength="9"></cc1:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>阅读权限:</td>
                                                <td>
                                                    <cc1:TextBox ID="readaccess" runat="server" CanBeNull="必填" RequiredFieldType="数据校验"
                                                        Size="5" MaxLength="4" HintInfo="设置用户浏览帖子或附件的权限级别,范围 0~255,0 为禁止用户浏览任何帖子或附件.当用户的阅读权限小于帖子或附件的阅读权限许可(默认时为 1)时,用户将不能阅读该帖子或下载该附件"></cc1:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="SERVER" ControlToValidate="readaccess"
                                                        ErrorMessage="请输入整数" ValidationExpression="^[-]?\d+\d*$">
                                                    </asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>短消息最多条数:</td>
                                                <td>
                                                    <cc1:TextBox ID="maxpmnum" runat="server" CanBeNull="必填" RequiredFieldType="数据校验"
                                                        Text="0" Size="5" MaxLength="4" HintInfo="设置用户短消息最大可保存的消息数目,0 为禁止使用短消息"></cc1:TextBox>
                                                    <asp:RegularExpressionValidator ID="homephone" runat="SERVER" ControlToValidate="maxpmnum"
                                                        ErrorMessage="请输入正整数或者零" ValidationExpression="^[0-9]*$">
                                                    </asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>上传单个附件允<br />许的最大字节数:</td>
                                                <td>
                                                    <cc1:TextBox ID="maxattachsize" runat="server" HintInfo="设置上传单个附件允许最大字节数." HintTitle="提示"
                                                        CanBeNull="必填" RequiredFieldType="数据校验" Text="0" Size="10" MaxLength="9"></cc1:TextBox>(单位:字节)
                                                    <select onchange="document.getElementById('TabControl1_tabPage51_maxattachsize').value=this.value">
                                                        <option value="">请选择</option>
                                                        <option value="51200">50K</option>
                                                        <option value="102400">100K</option>
                                                        <option value="153600">150K</option>
                                                        <option value="204800">200K</option>
                                                        <option value="256000">250K</option>
                                                        <option value="307200">300K</option>
                                                        <option value="358400">350K</option>
                                                        <option value="409600">400K</option>
                                                        <option value="512000">500K</option>
                                                        <option value="614400">600K</option>
                                                        <option value="716800">700K</option>
                                                        <option value="819200">800K</option>
                                                        <option value="921600">900K</option>
                                                        <option value="1024000">1M</option>
                                                        <option value="2048000">2M</option>
                                                        <option value="4096000">4M</option>
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>允许附件类型:</td>
                                                <td>
                                                    <cc1:CheckBoxList ID="attachextensions" runat="server" HintHeight="80" HintInfo="如果要允许所有附件类型, 则不要点选右侧任何附件类型, 且具体版块设置优先于用户组设置"
                                                        HintTitle="提示" RepeatColumns="3">
                                                    </cc1:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </cc3:TabPage>
                        <cc3:TabPage Caption="权限信息" ID="tabPage22">
                            <uc1:UserGroupPowerSetting ID="usergrouppowersetting" runat="server" />
                        </cc3:TabPage>
                    </cc3:TabControl>
                </td>
            </tr>
        </table>
        <cc1:Hint ID="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
        <div class="Navbutton">
            <cc1:Button ID="UpdateUserGroupInf" runat="server" ValidateForm="true" Text=" 提 交 "></cc1:Button>&nbsp;&nbsp;
            <cc1:Button ID="DeleteUserGroupInf" runat="server" Text=" 删 除 " ButtonImgUrl="../images/del.gif"></cc1:Button>&nbsp;&nbsp;
            <button type="button" class="ManagerButton" id="Button3" onclick="window.location='global_usergroupgrid.aspx';"><img src="../images/arrow_undo.gif"/> 返 回 </button>
        </div>
        <div id="topictypes" style="display: none; width: 100%;">
            <tr>
                <td class="td1">
                    用户组头像:</td>
                <td class="td1">
                    <cc1:TextBox ID="groupavatar" runat="server" RequiredFieldType="暂无校验" Width="80%"></cc1:TextBox></td>
            </tr>
        </div>
    </form>
    
    
</body>
</html>
