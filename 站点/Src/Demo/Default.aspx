<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:v="urn:schemas-microsoft-com:vml">
<head runat="server">
    <title></title>

    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true_or_false&amp;key=ABQIAAAA7XG9THjQpszHvujJpUO3WhTi1TYEAKBDhGPc356rHfjSOijN0BSMkZIHVovLuUzErn5LIJ4wVA8m2g"
        type="text/javascript"></script>

    <script type="text/javascript" src="http://www.google.cn/jsapi?key=ABQIAAAA7XG9THjQpszHvujJpUO3WhTi1TYEAKBDhGPc356rHfjSOijN0BSMkZIHVovLuUzErn5LIJ4wVA8m2g"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="divGoogleMap" style="width: 500px; height: 300px;">
    </div>
    </form>

    <script type="text/javascript">

        google.load("maps", "2.x", { base_domain: "ditu.google.cn", language: "zh-CN" });

        // Call this function when the page has been loaded
        function initialize() {
            var container = document.getElementById("divGoogleMap");
            var map = new google.maps.Map2(container);
            map.setCenter(new google.maps.LatLng(39.9493, 116.3975), 13);
        }
        google.setOnLoadCallback(initialize);
        //    function LoadMap() {
        //        var container = document.getElementById("divGoogleMap");
        //        var gMap = new google.maps.GMap2(container);
        //    }
    </script>

</body>
</html>
