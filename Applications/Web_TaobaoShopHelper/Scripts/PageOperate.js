function ShowModuleDialog(url, width, height, resizable) {
    var args = "dialogWidth=" + width + ";dialogHeight=" + height + ";center=yes;resizable=" + resizable + ";";
    return window.showModalDialog(url, window, args);
}

function OpenWindow(url, width, height, resizable) {
    window.open(url);
}