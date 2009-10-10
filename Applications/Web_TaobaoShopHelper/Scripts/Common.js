function WriteCookie(name, value) {
    document.cookie = name + "=" + value + ";";
}

function ReadCookie(name) {
    var mycookie = document.cookie;
    var start1 = mycookie.indexOf(name + "=");
    if (start1 == -1)
        return null;
    else {
        start = mycookie.indexOf("=", start1) + 1;
        var end = mycookie.indexOf(";", start);
        if (end == -1) {
            end = mycookie.length;
            //return unescape(mycookie.substring(start,end));
        }
        return unescape(mycookie.substring(start, end));
    }
}