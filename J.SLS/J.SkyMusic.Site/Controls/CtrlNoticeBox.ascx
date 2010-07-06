<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CtrlNoticeBox.ascx.cs"
    Inherits="Controls_CtrlNoticeBox" %>
<div class="<%= HasNotice?"NoticeBox":"HiddenDiv" %>" id="divNoticeContainer">
    <marquee id="noticContainer" height="60" scrollamount="3" direction="left" onmouseover="this.stop()"
        onmouseout="this.start()">
    <asp:Repeater ID="rptNoticeList" runat="server" OnItemDataBound="rptNoticeList_ItemDataBound">
        <ItemTemplate>
            <asp:HyperLink ID="hlnk" Target="_blank" runat="server"></asp:HyperLink>
        </ItemTemplate>
    </asp:Repeater>
    </marquee>
</div>

<script type="text/javascript">

    var currentDisplayNoticeNum = 0;
    function ShowNext() {
        var nextNum = currentDisplayNoticeNum + 1;
        var oldNumString = currentDisplayNoticeNum.toString();
        var newNumString = nextNum.toString();
        if (currentDisplayNoticeNum < 10) {
            oldNumString = "0" + oldNumString;
        }
        if (nextNum < 10) {
            newNumString = "0" + newNumString;
        }
        var oldId = "<%= rptNoticeList.ClientID %>_ctl" + oldNumString + "_hlnk";
        var newId = "<%= rptNoticeList.ClientID %>_ctl" + newNumString + "_hlnk";
        var oldObj = document.getElementById(oldId);
        if (oldObj) {
            oldObj.style.display = "none";
        }
        var newObj = document.getElementById(newId);
        if (newObj) {
            newObj.style.display = "";
        }
        else {
            nextNum = 0;
            newId = "<%= rptNoticeList.ClientID %>_ctl00_hlnk";
            newObj = document.getElementById(newId);
            if (newObj) {
                newObj.style.display = "";
            }
        }
        currentDisplayNoticeNum = nextNum;
    }
    
//    var hasNotice = '<%= HasNotice %>'.toLowerCase();
//    if(hasNotice=='true'){
//        setInterval("ShowNext();", <%= NoticeDelay %>);
//    }
</script>

