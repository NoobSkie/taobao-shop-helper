<%@ Page Language="C#" MasterPageFile="~/FrontWebPage/FrontSubMasterPage.master"
    AutoEventWireup="true" CodeFile="DataBehavior.aspx.cs" Inherits="FrontWebPage_DataBehavior"
    Title="数据走势" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="kcanotice">
        <ul>
            <li><span>会员222</span>喜中时时选六复式<strong>360</strong>元</li>
            <li><span>会员222</span>喜中时时彩三星组选六复式<strong>360</strong>元</li>
            <li><span>会员222</span>喜中时时彩三星复式<strong>360</strong>元</li>
            <li><span>会员222</span>喜中时六复式<strong>360</strong>元</li>
        </ul>
    </div>
    <div class="ssc_menu1">
        <li><a href="DataBehavior.aspx">重庆时时彩</a></li>
        <li><a href="DataBehavior.aspx">江西时时彩</a></li>
        <li><a href="DataBehavior.aspx">山东11选5</a></li>
        <li><a href="DataBehavior.aspx">江西11选5</a></li>
        <li><a href="DataBehavior.aspx">22选5</a></li>
        <li class="s"><a href="DataBehavior.aspx" class="s">时时乐</a></li>
        <li><a href="DataBehavior.aspx">福彩3D</a></li>
        <li><a href="DataBehavior.aspx">排列三</a></li>
        <li><a href="DataBehavior.aspx">双色球</a></li>
        <li><a href="DataBehavior.aspx">超级大乐透</a></li>
        <li><a href="DataBehavior.aspx">七星彩</a></li>
        <li><a href="DataBehavior.aspx">七彩乐</a></li>
    </div>
    <div class="ssc_menu2 cl">
        <strong>时时乐:</strong><input id="Radio1" type="radio" />综合分布图（基本走势图）
        <input id="Radio2" type="radio" />012路（除3余数）走势图
        <input id="Radio3" type="radio" />大小分析走势图
        <input id="Radio4" type="radio" />奇偶分析走势图
        <input id="Radio5" type="radio" />质合分析走势图
        <input id="Radio6" type="radio" />和值走势图</div>
    <div class="ssc_menu3">
        <span class="fr">
            <input type="button" class="tb" value="显示30期" />
            <input type="button" class="tb" value="显示50期" />
            <input type="button" class="tb" value="显示100期" />
        </span><strong>上海时时乐 综合分布走势图</strong> 起始期数：<input class="time" value="2010012804" />
        至
        <input class="time" value="2010012804" />
        <input type="button" class="tb" value="搜索" /></div>
    <div class="ssc_menu4" style="text-align: center;">
        <a href="#">时时乐投注/合买</a> <a href="#">时时乐中奖查询</a></div>
    <div class="help_box">
        <img src="../images/t.gif" />
    </div>
    <div class="notice">
        <strong>健康游戏公告:</strong> 彩市有风险，投注须谨慎，注意自我保护，谨防受骗上当。未满18周岁严禁购买彩票。</div>
    <div class="cb">
    </div>
</asp:Content>
