using ASP;
using DAL;
using Shove._Web;
using System;
using System.Data;
using System.Web.Profile;

public partial class Home_Room_UserControls_Index_banner : UserControlBase
{
    public string imagsBanner = "";
    public string linksBanner = "";
    public string textBanner = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string key = "Home_Room_UserControls_Index_banner_ImagePlay";
        DataTable cacheAsDataTable = Shove._Web.Cache.GetCacheAsDataTable(key);
        if (cacheAsDataTable == null)
        {
            cacheAsDataTable = new Tables.T_FocusImageNews().Open("", "", "ID Desc");
            if (cacheAsDataTable == null)
            {
                PF.GoError(4, "数据库繁忙，请重试", base.GetType().BaseType.FullName);
                return;
            }
            Shove._Web.Cache.SetCache(key, cacheAsDataTable, 0xe10);
        }
        DataRow[] rowArray = cacheAsDataTable.Select("IsBig=1", "ID desc");
        for (int i = 0; (i < rowArray.Length) && (i < 6); i++)
        {
            string imagsBanner = this.imagsBanner;
            this.imagsBanner = imagsBanner + "Private/" + base._Site.ID.ToString() + "/NewsImages/" + rowArray[i]["ImageUrl"].ToString() + ",";
            this.textBanner = this.textBanner + rowArray[i]["Title"].ToString() + ",";
            this.linksBanner = this.linksBanner + rowArray[i]["Url"].ToString() + ",";
        }
    }
}

