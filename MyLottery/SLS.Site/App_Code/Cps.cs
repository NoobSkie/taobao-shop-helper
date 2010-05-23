using SLS.Site.App_Code.DAL;
using System;

namespace SLS.Site.App_Code
{
    public class Cps
    {
        public string Address;
        public double BonusScale;
        public long CommendID;
        public string Company;
        public string ContactPerson;
        public string Content;
        public System.DateTime DateTime;
        public string DomainName;
        public string Email;
        public string Fax;
        public long ID;
        public bool IsShow;
        public string LogoUrl;
        public string MD5Key;
        public string Mobile;
        public string Name;
        public bool ON;
        public long OperatorID;
        public long OwnerUserID;
        public long ParentID;
        public string PostCode;
        public string QQ;
        public string ResponsiblePerson;
        public string ServiceTelephone;
        public long SiteID;
        public string Telephone;
        public short Type;
        public string Url;
        public Users User;

        public Cps()
        {
            this.ID = -1L;
            this.SiteID = -1L;
            this.OwnerUserID = -1L;
            this.Name = "";
            this.Url = "";
            this.LogoUrl = "";
            this.BonusScale = 0.0;
            this.ON = false;
            this.IsShow = true;
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
            this.MD5Key = "";
            this.Type = -1;
            this.DomainName = "";
            this.ParentID = -1L;
            this.OperatorID = 1L;
            this.CommendID = -1L;
            this.DateTime = System.DateTime.Now;
            this.Content = null;
        }

        public Cps(Users user)
        {
            this.User = user;
            this.ID = -1L;
            this.SiteID = user.SiteID;
            this.OwnerUserID = user.ID;
            this.Name = "";
            this.Url = "";
            this.LogoUrl = "";
            this.BonusScale = 0.0;
            this.ON = false;
            this.IsShow = true;
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
            this.MD5Key = "";
            this.Type = -1;
            this.DomainName = "";
            this.ParentID = -1L;
            this.OperatorID = 1L;
            this.CommendID = -1L;
            this.DateTime = System.DateTime.Now;
            this.Content = null;
        }

        public int Add(ref string ReturnDescription)
        {
            if ((this.SiteID < 0L) || (this.OwnerUserID < 0L))
            {
                throw new Exception("Cps 尚未初始化 SiteID、 OwnerUserID 变量，无法增加数据");
            }
            ReturnDescription = "";
            if (Procedures.P_CpsAdd(this.User.Site.ID, this.OwnerUserID, this.Name, this.Url, this.LogoUrl, this.BonusScale, this.ON, this.Company, this.Address, this.PostCode, this.ResponsiblePerson, this.ContactPerson, this.Telephone, this.Fax, this.Mobile, this.Email, this.QQ, this.ServiceTelephone, this.MD5Key, this.Type, this.ParentID, this.DomainName, this.OperatorID, this.CommendID, ref this.ID, ref ReturnDescription) < 0)
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

        public void Clone(Cps cps)
        {
            cps.ID = this.ID;
            cps.SiteID = this.SiteID;
            cps.OwnerUserID = this.OwnerUserID;
            cps.Name = this.Name;
            cps.DateTime = this.DateTime;
            cps.Url = this.Url;
            cps.LogoUrl = this.LogoUrl;
            cps.BonusScale = this.BonusScale;
            cps.ON = this.ON;
            cps.Company = this.Company;
            cps.Address = this.Address;
            cps.PostCode = this.PostCode;
            cps.ResponsiblePerson = this.ResponsiblePerson;
            cps.ContactPerson = this.ContactPerson;
            cps.Telephone = this.Telephone;
            cps.Fax = this.Fax;
            cps.Mobile = this.Mobile;
            cps.Email = this.Email;
            cps.QQ = this.QQ;
            cps.ServiceTelephone = this.ServiceTelephone;
            cps.MD5Key = this.MD5Key;
            cps.Type = this.Type;
            cps.DomainName = this.DomainName;
            cps.ParentID = this.ParentID;
            cps.OperatorID = this.OperatorID;
            cps.CommendID = this.CommendID;
            cps.Content = this.Content;
            cps.User = this.User;
        }

        public int EditByID(ref string ReturnDescription)
        {
            if (((this.ID < 0L) || (this.SiteID < 0L)) || (this.OwnerUserID < 0L))
            {
                throw new Exception("Cps 尚未初始化到具体的数据实例上，请先使用 GetCpsInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_CpsEdit(this.User.Site.ID, this.ID, this.Name, this.Url, this.LogoUrl, this.BonusScale, this.ON, this.Company, this.Address, this.PostCode, this.ResponsiblePerson, this.ContactPerson, this.Telephone, this.Fax, this.Mobile, this.Email, this.QQ, this.ServiceTelephone, this.MD5Key, this.Type, this.DomainName, this.IsShow, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            return returnValue;
        }

        public int GetCpsInformationByID(ref string ReturnDescription)
        {
            if ((this.SiteID < 0L) || (this.ID < 0L))
            {
                throw new Exception("Cps 尚未初始化 SiteID、 ID 变量，无法获取信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            Cps cps = new Cps();
            this.Clone(cps);
            if (Procedures.P_GetCpsInformationByID(this.SiteID, this.ID, ref this.OwnerUserID, ref this.Name, ref this.DateTime, ref this.Url, ref this.LogoUrl, ref this.BonusScale, ref this.ON, ref this.Company, ref this.Address, ref this.PostCode, ref this.ResponsiblePerson, ref this.ContactPerson, ref this.Telephone, ref this.Fax, ref this.Mobile, ref this.Email, ref this.QQ, ref this.ServiceTelephone, ref this.MD5Key, ref this.Type, ref this.ParentID, ref this.DomainName, ref returnValue, ref ReturnDescription) < 0)
            {
                cps.Clone(this);
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                cps.Clone(this);
                return returnValue;
            }
            return 0;
        }

        public int GetCpsInformationByOwnerUserID(ref string ReturnDescription)
        {
            if ((this.SiteID < 0L) || (this.OwnerUserID < 0L))
            {
                throw new Exception("Cps 尚未初始化 SiteID、 OwnerUserID 变量，无法获取信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            Cps cps = new Cps();
            this.Clone(cps);
            if (Procedures.P_GetCpsInformationByOwnerUserID(this.SiteID, this.OwnerUserID, ref this.ID, ref this.Name, ref this.DateTime, ref this.Url, ref this.LogoUrl, ref this.BonusScale, ref this.ON, ref this.Company, ref this.Address, ref this.PostCode, ref this.ResponsiblePerson, ref this.ContactPerson, ref this.Telephone, ref this.Fax, ref this.Mobile, ref this.Email, ref this.QQ, ref this.ServiceTelephone, ref this.MD5Key, ref this.Type, ref this.ParentID, ref this.DomainName, ref returnValue, ref ReturnDescription) < 0)
            {
                cps.Clone(this);
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                cps.Clone(this);
                return returnValue;
            }
            return 0;
        }

        public int Try(ref string ReturnDescription)
        {
            if ((this.SiteID < 0L) || (this.OwnerUserID < 0L))
            {
                throw new Exception("Cps 尚未初始化 SiteID、 OwnerUserID 变量，无法增加数据");
            }
            ReturnDescription = "";
            if (Procedures.P_CpsTry(this.User.Site.ID, this.OwnerUserID, this.Content, this.Name, this.Url, this.LogoUrl, this.Company, this.Address, this.PostCode, this.ResponsiblePerson, this.ContactPerson, this.Telephone, this.Fax, this.Mobile, this.Email, this.QQ, this.ServiceTelephone, this.MD5Key, this.Type, this.DomainName, this.ParentID, this.BonusScale, this.CommendID, ref this.ID, ref ReturnDescription) < 0)
            {
                return -1;
            }
            return 0;
        }
    }
}
