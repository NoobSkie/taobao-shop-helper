<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMainMenu.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TOP.Applications.TaobaoShopHelper.ShopHelper.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CommonContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HolderContent" runat="server">
    <div class="MenuDivLevelTwo">
        <ul class="MenuItemList">
            <li><a href="ItemQuery.aspx"><span>导入宝贝</span></a></li>
            <li><a href="ItemQuery.aspx"><span>批量增加宝贝</span></a></li>
            <li class="Selected"><a href="ItemQuery.aspx"><span>店铺宝贝管理</span></a></li>
            <li><a href="ItemQuery.aspx"><span>库存</span></a></li>
        </ul>
    </div>
    <div style="width:1000px; margin:auto;">
     <%--店铺商品图表--%>
    <div class="ComminuteLine_Diagram">
        <div class="Photo_Diagram">
            <asp:Image ID="Image1" runat="server" ImageUrl="../Images/Shops/atg4123/0_T1EeVcXn8avACH3n.._113612.jpg"
                Height="80px" Width="80px" />
        </div>
        <div class="Summary_Diagram">
            <div class="SummaryTop_Diagram">
                <asp:Label ID="Label3" runat="server">【三件包邮】09韩版日系淑女款花朵休闲凉拖[X2828] </asp:Label>
            </div>
        </div>
        <div class="Price__Diagram">
            <div class="Text_Diagram">
                <asp:Label ID="Label1" runat="server" Text="Label">￥</asp:Label>
            </div>
            <div class="Number_Diagram">
                <asp:Label ID="Label2" runat="server" Text="Label">28.00元</asp:Label>
            </div>
        </div>
        <div class="Text_CommodityDiagram">
            <asp:Label ID="Label4" runat="server" Text="Label">已销售100件</asp:Label>
        </div>
        <div class="Text_CommodityDiagram">
            <asp:Label ID="Label5" runat="server" Text="Label">★★★★★(已有1000人评论)</asp:Label>
        </div>
    </div>
    <div class="ComminuteLine_Diagram">
        <div class="Photo_Diagram">
            <asp:Image ID="Image2" runat="server" ImageUrl="../Images/Shops/atg4123/0_T1EeVcXn8avACH3n.._113612.jpg"
                Height="80px" Width="80px" />
        </div>
        <div class="Summary_Diagram">
            <div class="SummaryTop_Diagram">
                <asp:Label ID="Label6" runat="server">【三件包邮】09韩版日系淑女款花朵休闲凉拖[X2828] </asp:Label>
            </div>
        </div>
        <div class="Price__Diagram">
            <div class="Text_Diagram">
                <asp:Label ID="Label7" runat="server" Text="Label">￥</asp:Label>
            </div>
            <div class="Number_Diagram">
                <asp:Label ID="Label8" runat="server" Text="Label">28.00元</asp:Label>
            </div>
        </div>
        <div class="Text_CommodityDiagram">
            <asp:Label ID="Label9" runat="server" Text="Label">已销售100件</asp:Label>
        </div>
        <div class="Text_CommodityDiagram">
            <asp:Label ID="Label10" runat="server" Text="Label">★★★★★(已有1000人评论)</asp:Label>
        </div>
    </div>
    <div class="ComminuteLine_Diagram">
        <div class="Photo_Diagram">
            <asp:Image ID="Image3" runat="server" ImageUrl="../Images/Shops/atg4123/0_T1EeVcXn8avACH3n.._113612.jpg"
                Height="80px" Width="80px" />
        </div>
        <div class="Summary_Diagram">
            <div class="SummaryTop_Diagram">
                <asp:Label ID="Label11" runat="server">【三件包邮】09韩版日系淑女款花朵休闲凉拖[X2828] </asp:Label>
            </div>
        </div>
        <div class="Price__Diagram">
            <div class="Text_Diagram">
                <asp:Label ID="Label12" runat="server" Text="Label">￥</asp:Label>
            </div>
            <div class="Number_Diagram">
                <asp:Label ID="Label13" runat="server" Text="Label">28.00元</asp:Label>
            </div>
        </div>
        <div class="Text_CommodityDiagram">
            <asp:Label ID="Label14" runat="server" Text="Label">已销售100件</asp:Label>
        </div>
        <div class="Text_CommodityDiagram">
            <asp:Label ID="Label15" runat="server" Text="Label">★★★★★(已有1000人评论)</asp:Label>
        </div>
    </div>
    <div class="ComminuteLine_Diagram">
        <div class="Photo_Diagram">
            <asp:Image ID="Image4" runat="server" ImageUrl="../Images/Shops/atg4123/0_T1EeVcXn8avACH3n.._113612.jpg"
                Height="80px" Width="80px" />
        </div>
        <div class="Summary_Diagram">
            <div class="SummaryTop_Diagram">
                <asp:Label ID="Label16" runat="server">【三件包邮】09韩版日系淑女款花朵休闲凉拖[X2828] </asp:Label>
            </div>
        </div>
        <div class="Price__Diagram">
            <div class="Text_Diagram">
                <asp:Label ID="Label17" runat="server" Text="Label">￥</asp:Label>
            </div>
            <div class="Number_Diagram">
                <asp:Label ID="Label18" runat="server" Text="Label">28.00元</asp:Label>
            </div>
        </div>
        <div class="Text_CommodityDiagram">
            <asp:Label ID="Label19" runat="server" Text="Label">已销售100件</asp:Label>
        </div>
        <div class="Text_CommodityDiagram">
            <asp:Label ID="Label20" runat="server" Text="Label">★★★★★(已有1000人评论)</asp:Label>
        </div>
    </div>
    <div class="Line"></div>
    <%--店铺商品列表--%>
    <div class="ComminuteLine">
            <div class="Photo">
                <asp:Image ID="Image5" runat="server" ImageUrl="../Images/Shops/bryantgasol/0_T1MylkXlwhAJO2L3k4_052742.jpg" Height="80px" Width="80px" />
            </div>
            <div class="Summary">
                <div class="SummaryTop">
                    <asp:Label ID="Label21" runat="server">【三件包邮】夏季韩版新品抢先报夹脚楔型毛巾凉鞋[XA010S] </asp:Label>
                </div>
            </div>
            <div class="Attribute_Commodity">
                <div class="Text_Commodity">
                    <asp:Label ID="Label22" runat="server">￥43.00 </asp:Label>
                </div>
                <div class="Text_Commodity">
                    <asp:Label ID="Label23" runat="server">已销售300件</asp:Label>
                </div>
                <div class="Text_Commodity">
                    <asp:Label ID="Label24" runat="server">★★★★★(已有100人评论)</asp:Label>
                </div>
            </div>
    </div>
    <div class="Line"></div>
    <%--查询图表--%>
    <div class="ComminuteLine_Diagram">
        <div class="Photo_Diagram">
            <asp:Image ID="Image6" runat="server" ImageUrl="../Images/Shops/bryantgasol/0_T1MylkXlwhAJO2L3k4_052742.jpg" Width="80px" Height="80px" />
        </div>
        <div class="Price__Diagram">
            <div class="Text_Diagram">
                <asp:Label ID="Label25" runat="server" Text="Label">一口价：</asp:Label>
            </div>
            <div class="Number_Diagram">
                <asp:Label ID="Label26" runat="server" Text="Label">6580.00</asp:Label>
            </div>
            <div class="LeaveWord ">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#">给我留言</asp:HyperLink>
            </div>
        </div>
        <div class="Legend_Diagram">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#">30天维修</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="#">如实描述</asp:HyperLink>
        </div>
        <div class="Summary_Diagram">
            <div class="SummaryBottom">
                <%--<asp:CheckBox ID="CheckBox1" runat="server" />--%></div>
            <div class="SummaryTop_Diagram">
                <asp:Label ID="Label27" runat="server">[特价双核电脑主机]AMD Ⅱ 250\昂达A785+\KST2G内存\板载HD420</asp:Label>
            </div>
        </div>
    </div>
    <div class="ComminuteLine_Diagram">
        <div class="Photo_Diagram">
            <asp:Image ID="Image7" runat="server" ImageUrl="../Images/Shops/bryantgasol/0_T1MylkXlwhAJO2L3k4_052742.jpg" Width="80px" Height="80px" />
        </div>
        <div class="Price__Diagram">
            <div class="Text_Diagram">
                <asp:Label ID="Label28" runat="server" Text="Label">一口价：</asp:Label>
            </div>
            <div class="Number_Diagram">
                <asp:Label ID="Label29" runat="server" Text="Label">6580.00</asp:Label>
            </div>
            <div class="LeaveWord ">
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="#">给我留言</asp:HyperLink>
            </div>
        </div>
        <div class="Legend_Diagram">
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="#">30天维修</asp:HyperLink>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="#">如实描述</asp:HyperLink>
        </div>
        <div class="Summary_Diagram">
            <div class="SummaryBottom">
                <%--<asp:CheckBox ID="CheckBox2" runat="server" />--%></div>
            <div class="SummaryTop_Diagram">
                <asp:Label ID="Label30" runat="server">[特价双核电脑主机]AMD Ⅱ 250\昂达A785+\KST2G内存\板载HD420</asp:Label>
            </div>
        </div>
    </div>
    <div class="ComminuteLine_Diagram">
        <div class="Photo_Diagram">
            <asp:Image ID="Image8" runat="server" ImageUrl="../Images/Shops/bryantgasol/0_T1MylkXlwhAJO2L3k4_052742.jpg" Width="80px" Height="80px" />
        </div>
        <div class="Price__Diagram">
            <div class="Text_Diagram">
                <asp:Label ID="Label31" runat="server" Text="Label">一口价：</asp:Label>
            </div>
            <div class="Number_Diagram">
                <asp:Label ID="Label32" runat="server" Text="Label">6580.00</asp:Label>
            </div>
            <div class="LeaveWord ">
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="#">给我留言</asp:HyperLink>
            </div>
        </div>
        <div class="Legend_Diagram">
            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="#">30天维修</asp:HyperLink>
            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="#">如实描述</asp:HyperLink>
        </div>
        <div class="Summary_Diagram">
            <div class="SummaryBottom">
                <%--<asp:CheckBox ID="CheckBox3" runat="server" />--%></div>
            <div class="SummaryTop_Diagram">
                <asp:Label ID="Label33" runat="server">[特价双核电脑主机]AMD Ⅱ 250\昂达A785+\KST2G内存\板载HD420</asp:Label>
            </div>
        </div>
    </div>
    <div class="ComminuteLine_Diagram">
        <div class="Photo_Diagram">
            <asp:Image ID="Image9" runat="server" ImageUrl="../Images/Shops/bryantgasol/0_T1MylkXlwhAJO2L3k4_052742.jpg" Width="80px" Height="80px" />
        </div>
        <div class="Price__Diagram">
            <div class="Text_Diagram">
                <asp:Label ID="Label34" runat="server" Text="Label">一口价：</asp:Label>
            </div>
            <div class="Number_Diagram">
                <asp:Label ID="Label35" runat="server" Text="Label">6580.00</asp:Label>
            </div>
            <div class="LeaveWord ">
                <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="#">给我留言</asp:HyperLink>
            </div>
        </div>
        <div class="Legend_Diagram">
            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="#">30天维修</asp:HyperLink>
            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="#">如实描述</asp:HyperLink>
        </div>
        <div class="Summary_Diagram">
            <div class="SummaryBottom">
                <%--<asp:CheckBox ID="CheckBox4" runat="server" />--%></div>
            <div class="SummaryTop_Diagram">
                <asp:Label ID="Label36" runat="server">[特价双核电脑主机]AMD Ⅱ 250\昂达A785+\KST2G内存\板载HD420</asp:Label>
            </div>
        </div>
    </div>
    <div class="Line"></div>
    <%--查询列表--%>
    <div class="ComminuteLine">
        <div class="Photo">
            <asp:Image ID="Image10" runat="server" ImageUrl="../Images/Shops/bryantgasol/0_T1MylkXlwhAJO2L3k4_052742.jpg" Height="80px" Width="80px" />
        </div>
        <div class="Summary">
            <div class="SummaryTop">
                <asp:Label ID="Label37" runat="server">[特价双核电脑主机]AMD Ⅱ 250\昂达A785+\KST2G内存\板载HD420</asp:Label>
            </div>
            <div class="SummaryBottom">
                <asp:Label ID="Label38" runat="server">卖家：</asp:Label>
                <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="#">太阳</asp:HyperLink>
                <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="#">给我留言</asp:HyperLink>
            </div>
        </div>
        <div class="Attribute">
            <div class="Price">
                <div class="Text">
                    <asp:Label ID="Label39" runat="server">一口价</asp:Label>
                </div>
                <div class="Number">
                    <asp:Label ID="Label40" runat="server">1020.00</asp:Label>
                </div>
            </div>
            <div class="Legend">
                <div>
                    <asp:Label ID="Label41" runat="server">30天维修</asp:Label>
                </div>
                <div>
                    <asp:Label ID="Label42" runat="server">如实描述</asp:Label>
                </div>
            </div>
            <div class="Shipping">
                <asp:Label ID="Label43" runat="server">10000</asp:Label>
            </div>
            <div class="Place">
                <asp:Label ID="Label44" runat="server">重庆</asp:Label>
            </div>
            <div class="Other">
                <%--<asp:CheckBox ID="CheckBox5" runat="server" />--%>
            </div>
        </div>
    </div>
    <div class="Line"></div>
    <%--查询店铺--%>
    <div class="ComminuteLine">
        <div class="Photo_Shop">
            <asp:Image ID="Image11" runat="server" ImageUrl="../Images/Shops/bryantgasol/0_T1MylkXlwhAJO2L3k4_052742.jpg" Width="80px" Height="" />
        </div>
        <div class="Summary">
            <div class="SummaryTop">
                <asp:Label ID="Label45" runat="server">优衣库官方旗舰店</asp:Label>
            </div>
            <div class="SummaryBottom">
                <asp:Label ID="Label46" runat="server">主营宝贝：</asp:Label>
                <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="#">优衣库 uniqlo 女装 短袖 印花t恤 分袖</asp:HyperLink>
            </div>
        </div>
        <div class="Attribute">
            <div class="Legend_Shop">
                <div>
                    <asp:Label ID="Label47" runat="server">700</asp:Label>
                </div>
            </div>
            <div class="Price_Shop">
                <div class="Text_Shop">
                    <asp:Label ID="Label48" runat="server">优衣库官方旗舰店 </asp:Label>
                </div>
                <div class="Number_Shop">
                    <asp:Label ID="Label49" runat="server">和我联系</asp:Label>
                </div>
            </div>
            <div class="Place">
                <asp:Label ID="Label50" runat="server">重庆</asp:Label>
            </div>
            <div class="Price_Shop">
                <div class="Text_Shop">
                    <asp:Label ID="Label51" runat="server">旗舰店 </asp:Label>
                </div>
                <div class="Number_Shop">
                    <asp:Label ID="Label52" runat="server">店铺动态评分</asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div class="Line"></div>
    </div>
</asp:Content>
