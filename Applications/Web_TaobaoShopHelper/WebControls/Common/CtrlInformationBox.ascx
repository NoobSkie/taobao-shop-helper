<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlInformationBox.ascx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.WebControls.Common.CtrlInformationBox" %>
<%@ Register Src="~/WebControls/Common/CtrlInformationItem.ascx" TagName="InformationItem"
    TagPrefix="item" %>
<div class="InformationBox">
    <img class="IcoType" alt="<%= InformationIcoTypeName %>" title="<%= InformationIcoTypeName %>" src="<%= IcoUrl %>" visible="<%= IsDisplayIco %>" />
    <ul>
        <asp:Repeater ID="rptInformationList" runat="server">
            <ItemTemplate>
                <item:InformationItem InformationObject="<%# Container.DataItem %>" runat="server">
                </item:InformationItem>
            </ItemTemplate>
            <SeparatorTemplate>
                <hr class="SeparatorLine">
            </SeparatorTemplate>
        </asp:Repeater>
    </ul>
</div>
