<%@ control language="c#" inherits="Discuz.Web.Admin.OnlineEditor, SLS.Club" %>
<%@ Register TagPrefix="cc1" Namespace="Discuz.Control" Assembly="Discuz" %>
    
<textarea name="DataTextarea" id="DataTextarea" runat="server" cols="80" rows="20"></textarea>
	
<script type="text/javascript" src="../../javascript/common.js"></script>
<script type="text/javascript" src="../../javascript/menu.js"></script>
<script type="text/javascript" src="../../javascript/dnteditor.js"></script>
<script type="text/javascript" src="../../javascript/post.js"></script>
<script type="text/javascript">
    var dntEditor;
      
    function CreateEditor()
    {
        dntEditor = new DNTeditor('<% =controlname%>_DataTextarea', '90%', '250',document.getElementById('<% = DataTextarea.ClientID%>').value);
        dntEditor.BasePath = '<%= Shove._Web.Utility.GetUrl() +"/" %>';
        dntEditor.ReplaceTextarea();
    }

    function PrepareSave()
    {
        document.getElementById('<% =controlname%>_DataTextarea').value = dntEditor.GetHtml();
    }

    function validate(theform)
    {
       PrepareSave();
       return true;
    }

    CreateEditor();
</script>