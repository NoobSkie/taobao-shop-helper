<%@ page language="C#" autoeventwireup="true" inherits="Discuz.Web.Admin.option, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<%@ Register TagPrefix="uc1" TagName="TextareaResize" Src="../UserControls/TextareaResize.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>论坛选项</title>
        <script type="text/javascript" src="../js/common.js"></script>		
	    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />        
        <link href="../styles/modelpopup.css" type="text/css" rel="stylesheet" />
	    <script type="text/javascript" src="../js/modalpopup.js"></script>
    	
        <script type="text/javascript">
            function ratevalveimg(ratelevel)
            {
                var imgelement =  '<img src="../images/agree.gif" border="0" alt="" style="vertical-align:middle;"/>';
                var valveimg = '';
                if(isie())
                {
                    imgelement = '<img src="../images/agree.gif" border="0" alt="" />';
                }
	            for(i = 0; i < ratelevel; i++) {
		            valveimg += imgelement;  
	            }            	
	            return valveimg;
            }
        </script>
    </head>
    <body>
    <form id="Form1" runat="server">
    <div class="ManagerForm">
    <fieldset>
		<legend style="background:url(../images/icons/legendimg.jpg) no-repeat 6px 50%;">论坛选项</legend>
		<table cellspacing="0" cellpadding="4" width="100%" align="center">
            <tr>
                <td  class="panelbox" align="left" width="50%">
                    <table width="100%">
                        <tr>
			                <td style="width: 120px">主题浏览统计队列:</td>
			                <td>
			                    <span id="Span1"  onmouseover="showhintinfo(this,0,35,'提示','建议访问量大时开启,访问积累一定数量统一更新,减少服务器压力. 如开启,建议队列长度为20-50','50','down','0');" onmouseout="hidehintinfo();">
			                    <input id="Topicqueuestats_1" runat="server" 
			                    type="radio" name="Topicqueuestats" value="1" checked="true" onclick="document.getElementById('topicqueuestatscount').style.visibility='visible';" />开启
			                    <input id="Topicqueuestats_0" runat="server" type="radio" name="Topicqueuestats" value="0" 
			                    onclick="document.getElementById('topicqueuestatscount').style.visibility='hidden';" />关闭
			                    </span>
				                &nbsp;&nbsp;<cc1:TextBox id="topicqueuestatscount" runat="server" RequiredFieldType="数据校验" CanBeNull="必填" Text="10" Size="5" 
				                MaxLength="4" MaximumValue="1000" MinimumValue="0"></cc1:TextBox>
			                </td>
                        </tr>                        
                        <tr>
			                <td>使用论坛流量统计:</td>
			                <td>
			                    <cc1:RadioButtonList id="statstatus" runat="server" HintInfo="选择&amp;quot;是&amp;quot;将打开论坛统计功能,提供详细的论坛访问统计信息." HintTitle="提示" RepeatLayout="flow">
					                <asp:ListItem Value="1">是</asp:ListItem>
					                <asp:ListItem Value="0">否</asp:ListItem>
				                </cc1:RadioButtonList>
			                </td>
			            </tr>
                        <tr>
		                    <td>是否显示组别:</td>
			                <td>
				                <cc1:RadioButtonList id="userstatusby" runat="server"  RepeatLayout="flow" HintTitle="提示" 
				                HintInfo="浏览帖子时是否显示用户所在的组">
					                <asp:ListItem Value="1" Selected>是</asp:ListItem>	
					                <asp:ListItem Value="0">否</asp:ListItem>					
				                </cc1:RadioButtonList>
		                    </td>
                        </tr>			            
			            <tr>
			                <td style="width: 130px">统计系统缓存时间:</td>
			                <td>
			                    <cc1:TextBox id="statscachelife" runat="server" CanBeNull="必填" RequiredFieldType="数据校验"  Size="6" MaxLength="4" HintTitle="提示" 
			                    HintInfo="统计数据缓存更新的时间,数值越大,数据更新频率越低,越节约资源,但数据实时程度越低,建议设置为 60 以上,以免占用过多的服务器资源"></cc1:TextBox>(单位:分钟)
			                </td>
			            </tr>
                        <tr>
			                <td style="width: 130px">管理记录保留时间:</td>
			                <td>
			                    <cc1:TextBox id="maxmodworksmonths" runat="server" CanBeNull="必填" RequiredFieldType="数据校验"  Size="6" MaxLength="4" HintTitle="提示" 
			                    HintInfo="系统中保留管理记录的时间,默认为 3 个月,建议在 3～6 个月的范围内取值"></cc1:TextBox>(单位:月)
			                </td>
			            </tr>
                        <tr>
			                <td>缓存游客页面<br />的失效时间:</td>
			                <td>
			                    <cc1:TextBox id="guestcachepagetimeout" runat="server"  HintTitle="提示" 
			                    HintInfo="论坛在线人数大时建议开启, 为0不缓存, 大于0则缓存该值的时间,单位为分钟, 建议值为10." RequiredFieldType="数据校验" CanBeNull="必填" Size="4" 
			                    Text="10" MaxLength="3"></cc1:TextBox>(单位:分钟)
			                </td>
                        </tr>
                        <!--tr>
		                    <td>管理操作理由<br />是否通知作者:</td>
                            <td>
				                <cc1:RadioButtonList id="reasonpm" runat="server" HintInfo="是否将管理操作的理由短消息通知作者" HintTitle="提示" RepeatLayout="flow">
					                <asp:ListItem Value="1">是</asp:ListItem>
					                <asp:ListItem Value="0">否</asp:ListItem>
				                </cc1:RadioButtonList>
			                </td>
                        </tr-->
                        <tr>
			                <td>编辑帖子<br />时间限制:</td>
			                <td>
				                <cc1:TextBox id="edittimelimit" runat="server" HintInfo="帖子作者发帖后超过此时间限制将不能再编辑帖, 版主和管理员不受此限制, 0 为不限制" 
				                HintTitle="提示" Text="5" RequiredFieldType="数据校验"  CanBeNull="必填" Size="5" MaxLength="4"></cc1:TextBox>(单位:分钟)
			                </td>
                        </tr>
                        <tr>
		                    <td>每页主题数:</td>
			                <td>
                                <cc1:TextBox id="tpp" runat="server" RequiredFieldType="数据校验" CanBeNull="必填" Size="6" MaxLength="4" HintTitle="提示" HintInfo="版块每页显示的主题数"></cc1:TextBox>
                            </td>
                        </tr>
                        <tr>
		                    <td>热门话题最低帖数:</td>
			                <td>
				                <cc1:TextBox id="hottopic" runat="server" CanBeNull="必填" RequiredFieldType="数据校验" Size="6" MaxLength="4" HintTitle="提示" 
				                HintInfo="超过一定帖子数的话题将显示为热门话题"></cc1:TextBox>
			                </td>
                        </tr>
                        <tr>
		                    <td>是否允许使用<br />标签(Tag)功能:</td>
		                    <td>
                                <cc1:RadioButtonList ID="enabletag" runat="server" HintInfo="选择允许使用标签功能."
                                    HintTitle="提示" RepeatLayout="flow">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </cc1:RadioButtonList>
		                    </td>
                        </tr>                        
                        <tr>
			                <td>首页显示热门<br />标签(Tag)数量设置:</td>
			                <td>
			                    <cc1:TextBox id="hottagcount" runat="server" CanBeNull="必填" RequiredFieldType="数据校验" MinimumValue="0" MaximumValue="60" Size="6" MaxLength="2" HintTitle="提示" 
			                    HintInfo="取值范围为0~60.如果取值为0,则关闭首页热门标签(Tag)的显示"></cc1:TextBox>
			                </td>
			            </tr>
                        <tr>
		                    <td>快速发帖:</td>
		                    <td>
		                        <cc1:radiobuttonlist id="fastpost" runat="server" RepeatColumns="1" HintTitle="提示" HintInfo="浏览论坛和帖子页面底部显示快速发帖表单">
				                    <asp:ListItem Value="0">不显示</asp:ListItem>
				                    <asp:ListItem Value="1">只显示快速发表主题</asp:ListItem>
				                    <asp:ListItem Value="2">只显示快速发表回复</asp:ListItem>
				                    <asp:ListItem Value="3">同时显示快速发表主题和回复</asp:ListItem>
			                    </cc1:radiobuttonlist>
		                    </td>
                        </tr>
                        <tr>
                            <td>新用户广告<br />强力屏蔽:</td>
                            <td>
                                <cc1:RadioButtonList ID="disablepostad" runat="server" HintInfo="是否启用新用户广告强力屏蔽功能"
                                    HintTitle="提示" RepeatLayout="flow">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </cc1:RadioButtonList><br />
                                <div id="postadstatus" runat="server">
                                    <table width="100%">
                                    <tr>
                                    <td>注册分钟:</td>
                                    <td><cc1:TextBox id="disablepostadregminute" runat="server" CanBeNull="必填" RequiredFieldType="数据校验" Size="6" MaxLength="4" HintTitle="提示" 
				                        HintInfo="用户注册N分钟内进行新用户广告强力屏蔽功能检查,0为不行进该项检查"></cc1:TextBox>(分钟)
				                     </td>
				                     </tr>
				                     <tr>
				                     <td>发帖数:</td>
				                     <td><cc1:TextBox id="disablepostadpostcount" runat="server" CanBeNull="必填" RequiredFieldType="数据校验" Size="6" MaxLength="4" HintTitle="提示" 
				                        HintInfo="用户发帖N帖内进行新用户广告强力屏蔽功能检查,0为不行进该项检查"></cc1:TextBox>(帖)
				                     </td>
				                     </tr>
				                     <tr>
				                     <td colspan="2">正则式:</td>
				                     </tr>
				                     <tr>
				                     <td colspan="2">
				                         <uc1:TextareaResize id="disablepostadregular" runat="server"  cols="35" controlname="disablepostadregular" HintTitle="提示" 
				                            HintInfo="用于对新用户进行广告屏蔽的正则表达式,每条正则表达式用回车符间隔" HintPosOffSet="160"></uc1:TextareaResize>
                                     </td>
				                     </tr>                            
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td  class="panelbox" align="right" width="50%">
                    <table width="100%">
		                <tr>						        
			                <td style="width: 100px">是否允许使用<br />HTML标题:</td>
                            <td>
				                <cc1:RadioButtonList id="allowhtmltitle" runat="server" HintInfo="如果允许使用HTML标题,还需在&amp;quot;用户权限&amp;quot;中设置哪些组可以使用." 
				                HintTitle="提示" RepeatLayout="flow">
					                <asp:ListItem Value="1">是</asp:ListItem>
					                <asp:ListItem Value="0">否</asp:ListItem>
				                </cc1:RadioButtonList>
			                </td>
		                </tr>
		                <tr>
		                    <td>启用论坛管<br />理工作日志:</td>
			                <td>
				                <cc1:RadioButtonList id="modworkstatus" runat="server"  RepeatLayout="flow" HintTitle="提示" 
				                HintInfo="论坛管理工作统计可以使管理员了解版主等管理人员的工作状况. 注意: 本功能会轻微加重系统负担">
					                <asp:ListItem Value="1">是</asp:ListItem>
					                <asp:ListItem Value="0">否</asp:ListItem>
				                </cc1:RadioButtonList>
			                </td>
		                </tr>
			            <tr>
			                <td>用户在线时间<br />更新时长:</td>
			                <td>
			                    <cc1:TextBox id="oltimespan" runat="server" CanBeNull="必填" RequiredFieldType="数据校验"  Size="6" MaxLength="4" HintTitle="提示" 
			                    HintInfo="可统计每个用户总共和当月的在线时间,本设置用以设定更新用户在线时间的时间频率.例如设置为 10,则用户每在线 10 分钟更新一次记录.本设置值越小,则统计越精确,但消耗资源越大.建议设置为 5～30 范围内,0 为不记录用户在线时间"></cc1:TextBox>(单位:分钟)
			                </td>
			            </tr>
		                <tr>
			                <td>缓存游客查看主<br />题页面的权重:</td>
			                <td>
				                <cc1:TextBox id="topiccachemark" runat="server" HintTitle="提示" HintInfo="为0则不缓存, 范围0 - 100  (数字越大, 缓存数据越多)" 
				                RequiredFieldType="数据校验" CanBeNull="必填" Text="10"  Size="4" MaxLength="3" MaximumValue="100" MinimumValue="0"></cc1:TextBox>
			                </td>
		                </tr>
		                <tr>
			                <td>删帖不减积<br />分时间期限:</td>
                            <td>
				                <cc1:TextBox id="losslessdel" runat="server"  
				                HintInfo="设置版主或管理员从前台删除发表于多少天以前的帖子时, 不更新用户金币, 可用于清理老帖子而不对作者金币造成损失. 0 为不使用此功能, 始终更新用户金币" 
				                HintTitle="提示" Text="5" RequiredFieldType="数据校验"  CanBeNull="必填" Size="5" MaxLength="4"></cc1:TextBox>(单位:天)
			                </td>
		                </tr>
		                <tr>
			                <td>编辑帖子附<br />加编辑记录:</td>
                            <td>
				                <cc1:RadioButtonList id="editedby" runat="server" RepeatLayout="flow" HintInfo="在 60 秒后编辑帖子添加“本帖由 xxx 于 xxxx-xx-xx 编辑”字样. 管理员编辑不受此限制" 
				                HintTitle="提示">
					                <asp:ListItem Value="1">是</asp:ListItem>
					                <asp:ListItem Value="0">否</asp:ListItem>
				                </cc1:RadioButtonList>
			                </td>
		                </tr>
		                <tr>
                            <td>每页帖子数:</td>
			                <td>
                                <cc1:TextBox id="ppp" runat="server" RequiredFieldType="数据校验" CanBeNull="必填" Size="6" MaxLength="4" HintTitle="提示" HintInfo="查看主题时每页帖子数"></cc1:TextBox>
                            </td>
		                </tr>
		                <tr>
			                <td>星星升级阀值:</td>
				                <td>
			                    <cc1:TextBox id="starthreshold" runat="server" CanBeNull="必填" RequiredFieldType="数据校验"  Size="6" MaxLength="4" HintTitle="提示" 
			                    HintInfo="N 个星星显示为 1 个月亮、N 个月亮显示为 1 个太阳. 默认值为 2, 如设为 0 则取消此项功能, 始终以星星显示"></cc1:TextBox>
		                    </td>
		                </tr>
                        <tr>
		                    <td>默认的编辑器模式:</td>
                            <td>
				                <cc1:RadioButtonList ID="defaulteditormode" runat="server" HintInfo="默认的编辑器模式" HintTitle="提示" RepeatColumns="1">
					                <asp:ListItem Value="0">Discuz!NT代码编辑器</asp:ListItem>
					                <asp:ListItem Value="1">可视化编辑器</asp:ListItem>
				                </cc1:RadioButtonList>
			                </td>
                        </tr>
		                <tr>
			                <td>是否允许切换<br />编辑器模式:</td>
                            <td>
				                <cc1:RadioButtonList id="allowswitcheditor" runat="server" HintInfo="选择否将禁止用户在 Discuz!NT 代码模式和所见即所得模式之间切换." HintTitle="提示" RepeatLayout="flow">
					                <asp:ListItem Value="1">是</asp:ListItem>
					                <asp:ListItem Value="0">否</asp:ListItem>
				                </cc1:RadioButtonList>
			                </td>
		                </tr>
		                <tr>			    
		                    <td>评分等级:</td>
		                    <td>
		                        <cc1:TextBox id="ratevalveset1" runat="server" CanBeNull="必填" Size="3" MaxLength="3"></cc1:TextBox> <script type="text/javascript">document.write(ratevalveimg(1));</script><br />
		                        <cc1:TextBox id="ratevalveset2" runat="server" CanBeNull="必填" Size="3" MaxLength="3"></cc1:TextBox> <script type="text/javascript">document.write(ratevalveimg(2));</script><br />
		                        <cc1:TextBox id="ratevalveset3" runat="server" CanBeNull="必填" Size="3" MaxLength="3"></cc1:TextBox> <script type="text/javascript">document.write(ratevalveimg(3));</script><br />
		                        <cc1:TextBox id="ratevalveset4" runat="server" CanBeNull="必填" Size="3" MaxLength="3"></cc1:TextBox> <script type="text/javascript">document.write(ratevalveimg(4));</script><br />
		                        <cc1:TextBox id="ratevalveset5" runat="server" CanBeNull="必填" Size="3" MaxLength="3"></cc1:TextBox> <script type="text/javascript">document.write(ratevalveimg(5));</script>
		                    </td>
		                </tr>
                    </table>
                </td>
            </tr>
        </table>
	</fieldset>
	<cc1:Hint id="Hint1" runat="server" HintImageUrl="../images"></cc1:Hint>	
    <div class="Navbutton">
	    <cc1:Button id="SaveInfo" runat="server" Text=" 提 交 "></cc1:Button>
	</div>
    </div>   
		        <div style="display:none">
		            <tr>		            
			            <td width="17%">我的话题全文搜索:</td>
			            <td width="36%">
				            <cc1:RadioButtonList id="fullmytopics" runat="server"  RepeatColumns="1" HintShowType="down" HintTitle="提示" HintTopOffSet="35" 
				            HintInfo="选择&amp;quot;是&amp;quot;, 用户点击首页&amp;quot;我的话题&amp;quot;链接将返回用户参与过的所有主题, 反之则返回用户发起的所有主题. 注意: 当使用本功能的用户很多时, 本功能会明显加重服务器负担">
					            <asp:ListItem Value="1">搜索用户是主题发表者或回复者的主题</asp:ListItem>
					            <asp:ListItem Value="0">只搜索用户是主题发表者的主题</asp:ListItem>
				            </cc1:RadioButtonList>
			            </td>
			            <td></td>
			            <td></td>
		            </tr>
		        </div>
    </form>
    
</body>
</html>

