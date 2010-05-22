<%@ page language="c#" inherits="Discuz.Web.Admin.safecontrol, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>安全控制</title>
    <script type="text/javascript" src="../js/common.js"></script>
    <script type="text/javascript">
        function setstatus(obj)
        {
            if(obj.id == "seccodestatus_select_5")
            {
                document.getElementById("seccodestatus_select_2").checked = obj.checked;
                document.getElementById("seccodestatus_select_2").disabled = obj.checked;
            }
            
            if(obj.id == "seccodestatus_select_2")
            {
                document.getElementById("seccodestatus_select_5").checked = obj.checked;
                document.getElementById("seccodestatus_select_5").disabled = obj.checked;
            }
            
            if(obj.id == "seccodestatus_select_6")
            {
                //document.getElementById("seccodestatus_select_2").checked = obj.checked;
                //document.getElementById("seccodestatus_select_9").disabled = obj.checked;
                document.getElementById("seccodestatus_select_3").checked = obj.checked;
                document.getElementById("seccodestatus_select_3").disabled = obj.checked;
                //document.getElementById("seccodestatus_select_5").checked = obj.checked;
                //document.getElementById("seccodestatus_select_5").disabled = obj.checked;
            }
            
            /*if(obj.id == "seccodestatus_select_9")
            {
                document.getElementById("seccodestatus_select_1").checked = obj.checked;
                document.getElementById("seccodestatus_select_1").disabled = obj.checked;
                document.getElementById("seccodestatus_select_2").checked = obj.checked;
                document.getElementById("seccodestatus_select_2").disabled = obj.checked;
                document.getElementById("seccodestatus_select_5").checked = obj.checked;
                document.getElementById("seccodestatus_select_5").disabled = obj.checked;
            }*/
            checkselecedpage();
        }
    </script>
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/modalpopup.js"></script>
</head>
<body>
    <div class="ManagerForm">
        <form id="Form1" method="post" runat="server">
            <fieldset>
                <legend style="background: url(../images/icons/icon22.jpg) no-repeat 6px 50%;">安全控制</legend>
                    <table cellspacing="0" cellpadding="4" width="100%" align="center">
                        <tr>
                            <td class="panelbox" colspan="2">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 110px">验证码显示方式:</td>
                                        <td class="td1"><cc1:DropDownList ID="VerifyImage" runat="server"></cc1:DropDownList></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="panelbox" colspan="2">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 110px">使用验证码<br />的页面列表:</td>
                                        <td style="width: 200px">                                        
                                            <cc1:TextBox ID="seccodestatus" runat="server" HintShowType="down" CssClass="" RequiredFieldType="暂无校验"
                                                TextMode="MultiLine" Height="90px" Rows="4" Cols="30" 
                                                HintInfo="请选取相应的页面复选框, 并在相应页面模板表单中加入{_vcode}校验码子模板, 就可以增加校验码判断功能."
                                                HintTitle="提示"></cc1:TextBox>&nbsp;
                                        </td>    
                                        <td style="padding:1px">
                                            <table id="seccodestatus_select">
                                                <tr>
                                                    <td style="padding:0px">
                                                        <input id="seccodestatus_select_0" type="checkbox" name="seccodestatus_select:0" onclick="checkselecedpage()" value="register" />
                                                        <label for="seccodestatus_select_0">新用户注册</label>
                                                    </td>
                                                    <td style="padding: 0px">
                                                        <input id="seccodestatus_select_5" type="checkbox" name="seccodestatus_select:5" onclick="setstatus(this);" value="showforum" />
                                                        <label for="seccodestatus_select_5">查看(已设置密码)版块</label>
                                                    </td>
                                                    <td style="padding:0px">
                                                        <input id="seccodestatus_select_1" type="checkbox" name="seccodestatus_select:1" onclick="checkselecedpage();" value="login" />
                                                        <label for="seccodestatus_select_1">用户登录</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding:0px">
                                                        <input id="seccodestatus_select_6" type="checkbox" name="seccodestatus_select:6" onclick="setstatus(this)" value="showtopic" />
                                                        <label for="seccodestatus_select_6">快速回复(主题页)</label>
                                                    </td>
                                                    <td style="padding:0px">
                                                        <input id="seccodestatus_select_2" type="checkbox" name="seccodestatus_select:2" onclick="setstatus(this);" value="posttopic" />
                                                        <label for="seccodestatus_select_2">发表主题</label>
                                                    </td>
                                                    <td style="padding:0px">
                                                        <input id="seccodestatus_select_7" type="checkbox" name="seccodestatus_select:7" onclick="checkselecedpage()" value="usercpprofile" />
                                                        <label for="seccodestatus_select_7">修改个人密码</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding:0px">
                                                        <input id="seccodestatus_select_3" type="checkbox" name="seccodestatus_select:3" onclick="checkselecedpage()" value="postreply" />
                                                        <label for="seccodestatus_select_3">发表回复</label>
                                                    </td>
                                                    <td style="padding:0px">
                                                        <input id="seccodestatus_select_8" type="checkbox" name="seccodestatus_select:8" onclick="checkselecedpage()" value="editpost" />
                                                        <label for="seccodestatus_select_8">修改帖子</label>
                                                    </td>
                                                    <td style="padding:0px">
                                                        <input id="seccodestatus_select_4" type="checkbox" name="seccodestatus_select:4" onclick="checkselecedpage()" value="usercppostpm" />
                                                        <label for="seccodestatus_select_4">发送短消息</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <!--td style="padding:0px">
                                                        <input id="seccodestatus_select_9" type="checkbox" name="seccodestatus_select:9" onclick="setstatus(this);" value="website" />
                                                        <label for="seccodestatus_select_9">聚合首页登陆</label>
                                                    </td-->                                                    
                                                    <td style="padding:0px">
                                                        <input id="seccodestatus_select_9" type="checkbox" name="seccodestatus_select:9" onclick="checkselecedpage()" value="editgoods" />
                                                        <label for="seccodestatus_select_9">编辑商品</label>
                                                    </td>
                                                    <td style="padding:0px">
                                                        <input id="seccodestatus_select_10" type="checkbox" name="seccodestatus_select:10" onclick="checkselecedpage()" value="showgoods" />
                                                        <label for="seccodestatus_select_10">显示商品</label>
                                                    </td>
                                                    <td style="padding:0px">
                                                        <input id="seccodestatus_select_11" type="checkbox" name="seccodestatus_select:11" onclick="checkselecedpage()" value="postgoods" />
                                                        <label for="seccodestatus_select_11">发送商品</label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>                        
                        <tr>
                            <td  class="panelbox" width="50%" align="left">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 110px">最大在线人数:</td>
                                        <td>
                                            <cc1:TextBox SetFocusButtonID="SaveInfo" ID="maxonlines" runat="server" 
                                                HintInfo="请设置合理的数值, 范围 10~65535, 建议设置为平均在线人数的 10 倍左右"
                                                HintTitle="提示" RequiredFieldType="数据校验" CanBeNull="必填" Text="9000" MaxLength="5"
                                                Size="6" MinimumValue="10" MaximumValue="65535"></cc1:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>搜索时间限制:</td>
                                        <td class="td2">
                                            <cc1:TextBox SetFocusButtonID="SaveInfo" ID="searchctrl" runat="server" 
                                                HintInfo="两次搜索间隔小于此时间将被禁止, 0 为不限制"
                                                HintTitle="提示" RequiredFieldType="数据校验" CanBeNull="必填" Text="0" MaxLength="5"
                                                Size="6"></cc1:TextBox>(单位:秒)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>用户登录时是否<br />启用安全问题:</td>
                                        <td>
                                            <cc1:RadioButtonList ID="secques" runat="server" RepeatLayout="flow" HintInfo="用户登录时是否启用安全问题" HintTitle="提示">
                                                <asp:ListItem Value="1" Selected>是</asp:ListItem>
                                                <asp:ListItem Value="0">否</asp:ListItem>
                                            </cc1:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td  class="panelbox" width="50%" align="right">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 110px">发帖灌水预防:</td>
                                        <td>
                                            <cc1:TextBox SetFocusButtonID="SaveInfo" ID="postinterval" runat="server" 
                                                HintInfo="两次发帖间隔小于此时间, 或两次发送短消息间隔小于此时间的二倍将被禁止, 0 为不限制"
                                                HintTitle="提示" RequiredFieldType="数据校验" CanBeNull="必填" Text="15" MaxLength="5"
                                                Size="6"></cc1:TextBox>(单位:秒)
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td>60 秒最大搜索次数:</td>
                                        <td>
                                            <cc1:TextBox SetFocusButtonID="SaveInfo" ID="maxspm" runat="server" 
                                            HintInfo="论坛系统每 60 秒系统响应的最大搜索次数, 0 为不限制. 注意: 如果服务器负担较重, 建议设置为 5, 或在 5~20 范围内取值, 以避免过于频繁的搜索造成数据表被锁"
                                                HintTitle="提示" RequiredFieldType="数据校验" CanBeNull="必填" Text="0" MaxLength="3"
                                                Size="4"></cc1:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>是否使用管理<br />员客户端工具:</td>
                                        <td>
                                            <cc1:RadioButtonList ID="admintools" runat="server" RepeatColumns="1" RepeatLayout="flow" HintTitle="提示"
                                                HintInfo="是否使用管理员客户端工具" HintPosOffSet="180">
                                                <asp:ListItem Value="0">不使用</asp:ListItem>
                                                <asp:ListItem Value="1">仅论坛创始人可用</asp:ListItem>
                                                <asp:ListItem Value="2">管理员可用</asp:ListItem>
                                            </cc1:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
            </fieldset>
            <cc1:Hint ID="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>
            <div class="Navbutton">
                <cc1:Button ID="SaveInfo" runat="server" Text=" 提 交 "></cc1:Button>
            </div>
            <script type="text/javascript">
                var seccodestatus='<%=ViewState["Seccodestatus"].ToString().Trim()%>';
                loadseccodestatus();
                function loadseccodestatus()
                {
	                if(seccodestatus.indexOf('register')>=0) 
	                {
		                document.getElementById("seccodestatus_select_0").checked=true;
	                }
	                if(seccodestatus.indexOf('login')>=0) 
	                {
		                document.getElementById("seccodestatus_select_1").checked=true;
	                }
	                if(seccodestatus.indexOf('posttopic')>=0) 
	                {
		                document.getElementById("seccodestatus_select_2").checked=true;
	                }
	                if(seccodestatus.indexOf('postreply')>=0) 
	                {
		                document.getElementById("seccodestatus_select_3").checked=true;
	                }
	                if(seccodestatus.indexOf('usercppostpm')>=0) 
	                {
		                document.getElementById("seccodestatus_select_4").checked =true;
	                }
	                if(seccodestatus.indexOf('showforum')>=0) 
	                {
		                document.getElementById("seccodestatus_select_5").checked=true;
	                }
	                if(seccodestatus.indexOf('showtopic')>=0) 
	                {
		                document.getElementById("seccodestatus_select_6").checked=true;
	                }
	                if(seccodestatus.indexOf('usercpnewpassword')>=0) 
	                {
		                document.getElementById("seccodestatus_select_7").checked=true;
	                }
	                if(seccodestatus.indexOf('editpost')>=0) 
	                {
		                document.getElementById("seccodestatus_select_8").checked=true;
	                }  
	                /*if(seccodestatus.indexOf('website')>=0) 
	                {
		                document.getElementById("seccodestatus_select_9").checked=true;
	                }*/	                
	                if(seccodestatus.indexOf('editgoods')>=0)
	                {
	                    document.getElementById("seccodestatus_select_9").checked = true;
	                } 
	                if(seccodestatus.indexOf('showgoods')>=0)
	                {
	                    document.getElementById("seccodestatus_select_10").checked = true;
	                }
	                if(seccodestatus.indexOf('postgoods')>=0)
	                {
	                    document.getElementById("seccodestatus_select_11").checked = true;
	                }
                }

                function checkselecedpage()
                {
	                document.getElementById("seccodestatus").value='';
                    var selectstr='';
                    if(document.getElementById("seccodestatus_select_0").checked)
                    {
                       selectstr+='register.aspx\r\n';
                    }
                    if(document.getElementById("seccodestatus_select_1").checked)
                    {
                       selectstr+='login.aspx\r\n';
                    }
                    if(document.getElementById("seccodestatus_select_2").checked)
                    {
                       selectstr+='posttopic.aspx\r\n';
                    }
                    if(document.getElementById("seccodestatus_select_3").checked)
                    {
                       selectstr+='postreply.aspx\r\n';
                    }
                    if(document.getElementById("seccodestatus_select_4").checked)
                    {
                       selectstr+='usercppostpm.aspx\r\nusercpshowpm.aspx\r\n';
                    }
                    if(document.getElementById("seccodestatus_select_5").checked)
                    {
                       selectstr+='showforum.aspx\r\n';
                    }
                    if(document.getElementById("seccodestatus_select_6").checked)
                    {
                       selectstr+='showtopic.aspx\r\najax.aspx\r\nshowdebate.aspx\r\nshowtree.aspx\r\nshowbonus.aspx\r\n';
                    }
                    if(document.getElementById("seccodestatus_select_7").checked)
                    {
                       selectstr+='usercpnewpassword.aspx\r\n';
                    }
                    if(document.getElementById("seccodestatus_select_8").checked)
                    {
                       selectstr+='editpost.aspx\r\n';
                    }
                    /*if(document.getElementById("seccodestatus_select_9").checked)
                    {
                       selectstr+='website.aspx\r\n';
                    }*/
                    if(document.getElementById("seccodestatus_select_9").checked)
                    {
                        selectstr+='editgoods.aspx\r\n';
                    }
                    if(document.getElementById("seccodestatus_select_10").checked)
                    {
                        selectstr+='showgoods.aspx\r\n';
                    }
                    if(document.getElementById("seccodestatus_select_11").checked)
                    {
                        selectstr+='postgoods.aspx\r\n';
                    }
	                document.getElementById("seccodestatus").value=selectstr;
                }      
            </script>
        </form>
    </div>
    
</body>
</html>
