<%@ page language="C#" autoeventwireup="true" CodeFile="Default.aspx.cs" inherits="Admin_Default" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../Style/Admin.css" type="text/css" rel="stylesheet" />
</head>
    <frameset border="1" framespacing="0" rows="118,*,30" frameborder="NO" cols="*">
        <FRAME name="topFrame" src="FrameTop.aspx" noResize scrolling="no">
        <FRAMESET border="2" frameSpacing="0" rows="*" frameBorder="NO" cols="185,*">
            <FRAME name="leftFrame" src="FrameLeft.aspx" noResize scrolling="yes">
            <FRAME name="mainFrame" src="<%=SubPage %>">
        </FRAMESET>
        <FRAME id="bottomFrame" name="bottomFrame" src="FrameBottom.aspx" noResize scrolling="no">
    </frameset>
</html>
