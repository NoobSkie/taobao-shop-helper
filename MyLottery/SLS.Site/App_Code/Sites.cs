using SLS.Site.App_Code.DAL;
using System;
using System.Reflection;
using System.Web;

namespace SLS.Site.App_Code
{
    [Serializable]
    public class Sites
    {
        private string _urls;
        public string Address;
        public long AdministratorID;
        public double BonusScale;
        public string Company;
        public string ContactPerson;
        public string Email;
        public string Fax;
        public string ICPCert;
        public long ID;
        public short Level;
        public string LogoUrl;
        public int MaxSubSites;
        public string Mobile;
        public string Name;
        public bool ON;
        public long OwnerUserID;
        public string PageKeywords;
        public string PageTitle;
        public long ParentID;
        public string PostCode;
        public string QQ;
        public string ResponsiblePerson;
        public string ServiceTelephone;
        public SiteNotificationTemplates SiteNotificationTemplates;
        public SiteOptions SiteOptions;
        public string Telephone;
        public string Url;
        public string UseLotteryList;
        public string UseLotteryListQuickBuy;
        public string UseLotteryListRestrictions;

        public Sites()
        {
            this.SiteNotificationTemplates = new SiteNotificationTemplates(this);
            this.SiteOptions = new SiteOptions(this);
            this.ID = -1L;
            this.ParentID = -1L;
            this.OwnerUserID = -1L;
            this.Name = "";
            this.LogoUrl = "";
            this.Company = "";
            this.Address = "";
            this.PostCode = "";
            this.ResponsiblePerson = "";
            this.ContactPerson = "";
            this.Telephone = "";
            this.Fax = "";
            this.Mobile = "";
            this.Email = "";
            this.QQ = "";
            this.ServiceTelephone = "";
            this.ICPCert = "";
            this.Level = -1;
            this.ON = false;
            this.BonusScale = 0.0;
            this.MaxSubSites = 0;
            this.UseLotteryList = "";
            this.AdministratorID = -1L;
            this._urls = "";
            this.Url = "";
            this.PageTitle = "";
            this.PageKeywords = "";
        }

        public Sites(long siteid)
        {
            this.SiteNotificationTemplates = new SiteNotificationTemplates(this);
            this.SiteOptions = new SiteOptions(this);
            this.ID = siteid;
            this.ParentID = -1L;
            this.OwnerUserID = -1L;
            this.Name = "";
            this.LogoUrl = "";
            this.Company = "";
            this.Address = "";
            this.PostCode = "";
            this.ResponsiblePerson = "";
            this.ContactPerson = "";
            this.Telephone = "";
            this.Fax = "";
            this.Mobile = "";
            this.Email = "";
            this.QQ = "";
            this.ServiceTelephone = "";
            this.ICPCert = "";
            this.Level = -1;
            this.ON = false;
            this.BonusScale = 0.0;
            this.MaxSubSites = 0;
            this.UseLotteryListRestrictions = "";
            this.UseLotteryList = "";
            this.UseLotteryListQuickBuy = "";
            this.AdministratorID = -1L;
            this._urls = "";
            this.Url = "";
            this.PageTitle = "";
            this.PageKeywords = "";
        }

        public int Add(ref string ReturnDescription)
        {
            if ((this.ParentID < 0L) || (this.OwnerUserID < 0L))
            {
                throw new Exception("Sites 尚未初始化 ParentID、OwnerUserID 变量，无法增加数据");
            }
            ReturnDescription = "";
            if (Procedures.P_SiteAdd(this.ParentID, this.OwnerUserID, this.Name, this.LogoUrl, this.Company, this.Address, this.PostCode, this.ResponsiblePerson, this.ContactPerson, this.Telephone, this.Fax, this.Mobile, this.Email, this.QQ, this.ServiceTelephone, this.ICPCert, this.Level, this.ON, this.BonusScale, this.MaxSubSites, this.UseLotteryListRestrictions, this.UseLotteryList, this.UseLotteryListQuickBuy, this.Urls, ref this.AdministratorID, ref this.ID, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (this.ID < 0L)
            {
                return (int)this.ID;
            }
            return 0;
        }

        public void Clone(Sites site)
        {
            site.ID = this.ID;
            site.ParentID = this.ParentID;
            site.OwnerUserID = this.OwnerUserID;
            site.Name = this.Name;
            site.LogoUrl = this.LogoUrl;
            site.Company = this.Company;
            site.Address = this.Address;
            site.PostCode = this.PostCode;
            site.ResponsiblePerson = this.ResponsiblePerson;
            site.ContactPerson = this.ContactPerson;
            site.Telephone = this.Telephone;
            site.Fax = this.Fax;
            site.Mobile = this.Mobile;
            site.Email = this.Email;
            site.QQ = this.QQ;
            site.ServiceTelephone = this.ServiceTelephone;
            site.ICPCert = this.ICPCert;
            site.Level = this.Level;
            site.ON = this.ON;
            site.BonusScale = this.BonusScale;
            site.MaxSubSites = this.MaxSubSites;
            site.UseLotteryListRestrictions = this.UseLotteryListRestrictions;
            site.UseLotteryList = this.UseLotteryList;
            site.UseLotteryListQuickBuy = this.UseLotteryListQuickBuy;
            site.AdministratorID = this.AdministratorID;
            site._urls = this._urls;
            site.Url = this.Url;
            site.SiteNotificationTemplates = this.SiteNotificationTemplates;
            site.SiteOptions = this.SiteOptions;
            site.PageTitle = this.PageTitle;
            site.PageKeywords = this.PageKeywords;
        }

        public int EditByID(ref string ReturnDescription)
        {
            if (((this.ID < 0L) || ((this.ParentID < 0L) && (this.ID != 1L))) || (this.OwnerUserID < 0L))
            {
                throw new Exception("Sites 尚未初始化到具体的数据实例上，请先使用 GetSiteInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_SiteEdit(this.ID, this.Name, this.LogoUrl, this.Company, this.Address, this.PostCode, this.ResponsiblePerson, this.ContactPerson, this.Telephone, this.Fax, this.Mobile, this.Email, this.QQ, this.ServiceTelephone, this.ICPCert, this.ON, this.BonusScale, this.MaxSubSites, this.UseLotteryListRestrictions, this.UseLotteryList, this.UseLotteryListQuickBuy, this.Urls, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            string str = "Site_";
            try
            {
                HttpContext.Current.Application.Lock();
                foreach (string str2 in this.Urls.Split(new char[] { ',' }))
                {
                    HttpContext.Current.Application.Remove(str + str2);
                }
            }
            catch
            {
            }
            finally
            {
                try
                {
                    HttpContext.Current.Application.UnLock();
                }
                catch
                {
                }
            }
            return returnValue;
        }

        public int GetSiteInformationByID(ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Sites 尚未初始化 ID 变量，无法获取信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            Sites site = new Sites();
            this.Clone(site);
            if (Procedures.P_GetSiteInformationByID(this.ID, ref this.ParentID, ref this.OwnerUserID, ref this.Name, ref this.LogoUrl, ref this.Company, ref this.Address, ref this.PostCode, ref this.ResponsiblePerson, ref this.ContactPerson, ref this.Telephone, ref this.Fax, ref this.Mobile, ref this.Email, ref this.QQ, ref this.ServiceTelephone, ref this.ICPCert, ref this.Level, ref this.ON, ref this.BonusScale, ref this.MaxSubSites, ref this.UseLotteryListRestrictions, ref this.UseLotteryList, ref this.UseLotteryListQuickBuy, ref this._urls, ref this.AdministratorID, ref this.PageTitle, ref this.PageKeywords, ref returnValue, ref ReturnDescription) < 0)
            {
                site.Clone(this);
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                site.Clone(this);
                return returnValue;
            }
            this.Urls = this._urls;
            return 0;
        }

        public int GetSiteInformationByUrl(ref string ReturnDescription)
        {
            if ((this.Url == null) || (this.Url == ""))
            {
                throw new Exception("Sites 尚未初始化 Url 变量，无法获取信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            Sites site = new Sites();
            this.Clone(site);
            if (Procedures.P_GetSiteInformationByUrl(this.Url, ref this.ID, ref this.ParentID, ref this.OwnerUserID, ref this.Name, ref this.LogoUrl, ref this.Company, ref this.Address, ref this.PostCode, ref this.ResponsiblePerson, ref this.ContactPerson, ref this.Telephone, ref this.Fax, ref this.Mobile, ref this.Email, ref this.QQ, ref this.ServiceTelephone, ref this.ICPCert, ref this.Level, ref this.ON, ref this.BonusScale, ref this.MaxSubSites, ref this.UseLotteryListRestrictions, ref this.UseLotteryList, ref this.UseLotteryListQuickBuy, ref this._urls, ref this.AdministratorID, ref this.PageTitle, ref this.PageKeywords, ref returnValue, ref ReturnDescription) < 0)
            {
                site.Clone(this);
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                site.Clone(this);
                return returnValue;
            }
            this.Urls = this._urls;
            return 0;
        }

        public void ReBuildUseLotteryList()
        {
            if (this.UseLotteryListRestrictions == "")
            {
                this.UseLotteryList = "";
                this.UseLotteryListQuickBuy = "";
            }
            else
            {
                string[] strArray = this.UseLotteryList.Split(new char[] { ',' });
                if (strArray.Length > 0)
                {
                    this.UseLotteryList = "";
                    foreach (string str in strArray)
                    {
                        if (("," + this.UseLotteryListRestrictions + ",").IndexOf("," + str + ",") >= 0)
                        {
                            this.UseLotteryList = this.UseLotteryList + ((this.UseLotteryList == "") ? "" : ",") + str;
                        }
                    }
                }
                strArray = this.UseLotteryListQuickBuy.Split(new char[] { ',' });
                if (strArray.Length > 0)
                {
                    this.UseLotteryListQuickBuy = "";
                    foreach (string str2 in strArray)
                    {
                        if (("," + this.UseLotteryListRestrictions + ",").IndexOf("," + str2 + ",") >= 0)
                        {
                            this.UseLotteryListQuickBuy = this.UseLotteryListQuickBuy + ((this.UseLotteryListQuickBuy == "") ? "" : ",") + str2;
                        }
                    }
                }
            }
        }

        public Sites this[string url]
        {
            get
            {
                string str = "Site_";
                Sites sites = null;
                try
                {
                    sites = (Sites)HttpContext.Current.Application[str + url];
                }
                catch
                {
                }
                if (sites == null)
                {
                    sites = new Sites
                    {
                        Url = url
                    };
                    string returnDescription = "";
                    if (sites.GetSiteInformationByUrl(ref returnDescription) < 0)
                    {
                        return null;
                    }
                    try
                    {
                        HttpContext.Current.Application.Lock();
                        HttpContext.Current.Application.Add(str + url, sites);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        try
                        {
                            HttpContext.Current.Application.UnLock();
                        }
                        catch
                        {
                        }
                    }
                }
                return sites;
            }
        }

        public Sites this[long siteid]
        {
            get
            {
                Sites sites = new Sites
                {
                    ID = siteid
                };
                string returnDescription = "";
                if (sites.GetSiteInformationByID(ref returnDescription) < 0)
                {
                    return null;
                }
                return sites;
            }
        }

        public string Urls
        {
            get
            {
                return this._urls;
            }
            set
            {
                this._urls = value;
                this.Url = "";
                try
                {
                    this.Url = value.Split(new char[] { ',' })[0];
                }
                catch
                {
                }
            }
        }
    }
}
