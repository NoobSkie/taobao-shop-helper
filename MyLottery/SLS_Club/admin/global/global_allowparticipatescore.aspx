<%@ page language="c#" inherits="Discuz.Web.Admin.allowparticipatescore, SLS.Club" %>
<%@ Register Src="../UserControls/PageInfo.ascx" TagName="PageInfo" TagPrefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>允许评分范围列表</title>
    <link href="../styles/datagrid.css" type="text/css" rel="stylesheet" />
    <link href="../styles/dntmanager.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/common.js"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
        <uc1:PageInfo ID="info1" runat="server" Icon="information" Text="您所编辑的字段必段是在[<a href=../global/global_scoreset.aspx>金币设置</a>]中指定了金币字段的名称, 未指定项无效" />
        <uc1:PageInfo ID="PageInfo1" runat="server" Icon="warning" Text="您所编辑的评分最小值字段可以为负值, 如-5即扣5分." />
        <br />
        &nbsp; <a href="<%=Request.Params["pagename"]%>.aspx?groupid=<%=Request.Params["groupid"]%>" class="TextButton">返 回</a>
        <br />
        <cc1:DataGrid ID="DataGrid1" runat="server" OnCancelCommand="DataGrid_Cancel" OnEditCommand="DataGrid_Edit"
            OnPageIndexChanged="DataGrid_PageIndexChanged" OnSortCommand="Sort_Grid" OnUpdateCommand="DataGrid_Update">
            <Columns>
                <asp:BoundColumn DataField="id" HeaderText="id [递增]" Visible="false"></asp:BoundColumn>
                <asp:TemplateColumn HeaderText="参与评分">
                    <headerstyle width="7%" />
                    <itemtemplate>
                        <%# GetImgLink(DataBinder.Eval(Container.DataItem,"available").ToString())%>
                    </itemtemplate>
                    <edititemtemplate>
					    <div align="center">
					        <asp:CheckBox id="available" runat="server" Checked='<%# GetAvailable(DataBinder.Eval(Container, "DataItem.available").ToString())%>'></asp:CheckBox>
					    </div>
					</edititemtemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="ScoreCode" HeaderText="金币代号" ReadOnly="true">
                    <headerstyle width="15%" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ScoreName" HeaderText="金币名称" ReadOnly="true">
                    <headerstyle width="25%" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Min" HeaderText="评分最小值">
                    <headerstyle width="15%" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Max" HeaderText="评分最大值">
                    <headerstyle width="15%" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="MaxInDay" HeaderText="24小时最大评分数">
                    <headerstyle width="15%" />
                </asp:BoundColumn>
            </Columns>
        </cc1:DataGrid>
        <p style="text-align:right;">
            <button type="button" class="ManagerButton" id="Button3" onclick="window.history.back();"><img src="../images/arrow_undo.gif"/> 返 回 </button>
        </p>
    </form>
    
</body>
</html>
