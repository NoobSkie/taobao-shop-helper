<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="WebForm1.aspx.cs"
    Inherits="TOP.Applications.TaobaoShopHelper.Templates.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="../Scripts/Common.js" type="text/javascript"></script>

    <script src="../Scripts/TemplateOperate.js" type="text/javascript"></script>

    <script src="../Scripts/TemplateBlock.js" type="text/javascript"></script>

    <script type="text/javascript">

        var templateHelper = new TemplateHelper();

        function InitContainer(index, category, title, dataType, defaultValue, showTitle, isFloat, titleWidth, inputWidth, inputHeight, parentId) {
            if (parentId == -1) {
                templateHelper.AddTemplateBlock_List(index, title, category, dataType, defaultValue, parentId);
            }
            else {
                templateHelper.AddTemplateBlock_Item(index, title, category, dataType, defaultValue, showTitle, isFloat, titleWidth, inputWidth, inputHeight, parentId);
            }
        }

        function FinishInit() {
            for (var i = 0; i < templateHelper.TemplateBlockList.length; i++) {
                var block = templateHelper.TemplateBlockList[i];
                if (block.SetDefaultValue && !block.SetDefaultValue()) {
                    if (block.CreateChildren) {
                        block.CreateChildren();
                    }
                }
            }
        }

        function AddBlock() {
            templateHelper.AddTemplateBlock();
        }

        function AddBlockWithLog() {
            AddBlock();
            AddLog("add");
        }

        function Save() {
            var json = templateHelper.GetJsonString();
            document.getElementById("spanText").innerHTML = json;
        }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="Button1" type="button" onclick="AddBlockWithLog();" value="添加" />
        <input id="Button2" type="button" onclick="ClearCookie();" value="清空cookie" />
        <input id="Button3" type="button" onclick="Save();" value="保存" />
        <br />
        <span id="spanText"></span>
    </div>
    <div id="divTemplate" class="TemplateContainer">
    </div>

    <script type="text/javascript">

        function ClearCookie() {
            WriteCookie("TemplateOperateLog", "");
        }

        function AddLog(logText) {
            var log = ReadCookie("TemplateOperateLog");
            log += "," + logText;
            WriteCookie("TemplateOperateLog", log);
        }

        function Reload() {
            var log = ReadCookie("TemplateOperateLog");
            if (log && log != "") {
                var items = log.split(",");
                for (var i = 0; i < items.length; i++) {
                    if (items[i] == "add") {
                        AddBlock();
                    }
                }
            }
        }

        var container = document.getElementById("divTemplate");
        templateHelper.InitContainer(container);

        Reload();
        
    </script>

    </form>
</body>
</html>
