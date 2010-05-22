<%@ Page Language="C#" ValidateRequest=false Trace="false" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<script runat="server">
protected void Page_Load(Object Src, EventArgs E) {

    //Sites site = new Sites()[Shove._Web.Utility.GetUrlWithoutHttp()];

    //if (site == null)
    //{
    //    this.Response.Write("不能访问此页面。");
    //    this.Response.End();

    //    return;
    //}

    //Users user = Users.GetCurrentUser(site.ID);

    //if ((user == null) || (user.Competences.CompetencesList == ""))
    //{
    //    this.Response.Write("不能访问此页面。");
    //    this.Response.End();

    //    return;
    //}

    int uid = Discuz.Forum.Users.GetUserIDFromCookie();
    if (uid != 0)
    {
        int groupid = Discuz.Forum.Users.GetUserInfo(uid).Groupid;
        if (groupid != 1)
        {
            this.Response.Write("不能访问此页面。");
            Response.End();
        }
        return;
    }
    
	// *** remove this return statement to use the following code ***
	return;
/*
	string currentFolder = ImageGallery1.CurrentImagesFolder;
	
	// modify the directories allowed
	if (currentFolder == "~/images") {

		// these are the default directories FTB:ImageGallery will find
		string[] defaultDirectories = System.IO.Directory.GetDirectories(Server.MapPath(currentFolder),"*");
		
		// user defined custom directories
		string[] customDirectories = new string[] {"folder1","folder2"};
		
		// the gallery will use these images in this instance
		ImageGallery1.CurrentDirectories = customDirectories;
	}
	
	
	// modify the images allowed
	if (currentFolder == "~/images") {

		System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(Server.MapPath(currentFolder));

		// these are the default images FTB:ImageGallery will find
		System.IO.FileInfo[] defaultImages = directoryInfo.GetFiles("*");
		
		// user defined custom images (here, we're just allowing the first two)
		System.IO.FileInfo[] customImages = new System.IO.FileInfo[2] {defaultImages[0], defaultImages[1]};
		
		// the gallery will use these images in this instance
		ImageGallery1.CurrentImages = customImages;
	}	
*/	
}
</script>
<html>
<head>
	<title>Image Gallery</title>
</head>
<body>

    <form id="Form1" runat="server" enctype="multipart/form-data">  
    
		<FTB:ImageGallery id="ImageGallery1" 
			JavaScriptLocation="InternalResource" 
			UtilityImagesLocation="InternalResource" 
			SupportFolder="~/FreeTextBox/"
			AllowImageDelete="true" AllowImageUpload="true" AllowDirectoryCreate="true" AllowDirectoryDelete="true" runat="Server" />
		
	</form>

</body>
</html>
