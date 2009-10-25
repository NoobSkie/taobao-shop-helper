
function ShowSearchWin(url, width, height, resizable, isInTest) {
    if (isInTest) {
        OpenWindow(url);
    }
    else {
        ShowModuleDialog(url, width, height, resizable);
    }
}

function AfterReturnData(ctrlId, type, postData) {
    if (type == "1") {
        if (postData != null && postData.length > 0) {
            PostBackPage(ctrlId, postData[0]);
        }
    }
    else {
        var json = new String();
        if (postData != null && postData.length > 0) {
            json += '{"Number":"' + postData.length + '","Detail":[';
            for (var i = 0; i < postData.length; i++) {
                if (i > 0) {
                    json += ",";
                }
                json += GetItemJson(postData[i]);
            }
            json += "]}";
        }
        PostBackPage(ctrlId, json);
    }
}

function GetItemJson(item) {
    var json = '{"Id":"' + item.Id + '","Nick":"' + item.Nick + '","Title":"' + item.Title + '","DetailUrl":"' + item.DetailUrl + '","ImageUrl":"' + item.ImageUrl + '","Price":"' + item.Price + '"}';
    return json;
}

function PostBackPage(ctrlId, args) {
    if (__doPostBack) {
        var postCtrlId = ctrlId + '_lbtnDoPostBack';
        var postCtrlName = GetCtrlNameByCtrlId(postCtrlId);
        __doPostBack(postCtrlName, args);
    }
}

function GetCtrlNameByCtrlId(ctrlId) {
    return ctrlId.replace(/\_/g, '$');
}