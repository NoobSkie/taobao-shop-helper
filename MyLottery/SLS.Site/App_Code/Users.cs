using SLS.Site.App_Code.DAL;
using Shove;
using Shove._Security;
using Shove._Web;
using System;
using System.Data;
using System.Reflection;
using System.Web;

namespace SLS.Site.App_Code
{
    [Serializable]
    public class Users
    {
        private long _id;
        private string _password;
        private string _passwordadv;
        private long _siteid;
        public string Address;
        public string AlipayID;
        public string AlipayName;
        public double Balance;
        public double cardPasswordM;
        public double cardPassword;
        public string BankCardNumber;
        public string BankName;
        public short BankType;
        public DateTime BirthDay;
        public double Bonus;
        public double BonusAllow;
        public double BonusThisMonth;
        public double BonusUse;
        public int CityID;
        public int ComeFrom;
        public long CommenderID;
        public Competences Competences;
        public Cps cps;
        public long CpsID;
        public string Email;
        public double Freeze;
        public string FriendList;
        public string HeadUrl;
        public string IDCardNumber;
        public bool isAlipayCps;
        public bool isAlipayNameValided;
        public bool isCanLogin;
        public bool IsCrossLogin;
        public bool isEmailValided;
        public bool isMobileValided;
        public bool isPrivacy;
        public bool isQQValided;
        public string LastLoginIP;
        public DateTime LastLoginTime;
        public short Level;
        public int LoginCount;
        public string Memo;
        public string Mobile;
        public string Name;
        public string NickName;
        public string OwnerSites;
        public double PromotionMemberBonusScale;
        public double PromotionSiteBonusScale;
        public string QQ;
        public string RealityName;
        public string Reason;
        public DateTime RegisterTime;
        public double Reward;
        public double Scoring;
        public double ScoringOfCommendBuy;
        public double ScoringOfSelfBuy;
        public string SecurityAnswer;
        public string SecurityQuestion;
        public string Sex;
        public Sites Site;
        public string Telephone;
        public short UserType;
        public string VisitSource;

        public Users()
        {
            this.Site = new Sites();
            this.HeadUrl = "";
            throw new Exception("不能用无参数的 Users 类的构造来申明实例。此无参数构造函数是为了能使其序列化。");
        }

        public Users(long siteid)
        {
            this.Site = new Sites();
            this.HeadUrl = "";
            this.cps = new Cps(this);
            this.Competences = new Competences(this);
            this.SiteID = siteid;
            this._id = -1L;
            this.Name = "";
            this.NickName = "";
            this.RealityName = "";
            this.Password = "";
            this.PasswordAdv = "";
            this.Sex = "男";
            this.BirthDay = DateTime.Parse("1980-01-01");
            this.IDCardNumber = "";
            this.CityID = 1;
            this.Address = "";
            this.Email = "";
            this.isEmailValided = false;
            this.QQ = "";
            this.isQQValided = false;
            this.Telephone = "";
            this.Mobile = "";
            this.isMobileValided = false;
            this.isPrivacy = false;
            this.isCanLogin = true;
            this.RegisterTime = DateTime.Now;
            this.LastLoginTime = DateTime.Now;
            try
            {
                this.LastLoginIP = HttpContext.Current.Request.UserHostAddress;
            }
            catch
            {
                this.LastLoginIP = "";
            }
            this.LoginCount = 0;
            this.UserType = 1;
            this.BankType = 1;
            this.BankName = "";
            this.BankCardNumber = "";
            this.Balance = 0.0;
            this.cardPasswordM = 0.0;
            this.Freeze = 0.0;
            this.ScoringOfSelfBuy = 0.0;
            this.ScoringOfCommendBuy = 0.0;
            this.Scoring = 0.0;
            this.Level = 0;
            this.CommenderID = -1L;
            this.CpsID = -1L;
            this.isAlipayCps = false;
            this.Bonus = 0.0;
            this.Reward = 0.0;
            this.AlipayID = "";
            this.AlipayName = "";
            this.isAlipayNameValided = false;
            this.Memo = "";
            this.BonusThisMonth = 0.0;
            this.BonusAllow = 0.0;
            this.BonusUse = 0.0;
            this.PromotionMemberBonusScale = 0.0;
            this.PromotionSiteBonusScale = 0.0;
            this.OwnerSites = "";
            this.ComeFrom = 0;
            this.IsCrossLogin = false;
            this.VisitSource = "";
            this.HeadUrl = "";
            this.SecurityQuestion = "";
            this.SecurityAnswer = "";
            this.FriendList = "";
            this.Reason = "";
        }

        public int Add(ref string ReturnDescription)
        {
            this.RegisterTime = DateTime.Now;
            ReturnDescription = "";
            if (Procedures.P_UserAdd(this.SiteID, this.Name, this.RealityName, this.Password, this.PasswordAdv, this.CityID, this.Sex, this.BirthDay, this.IDCardNumber, this.Address, this.Email, this.isEmailValided, this.QQ, this.isQQValided, this.Telephone, this.Mobile, this.isMobileValided, this.isPrivacy, this.UserType, this.BankType, this.BankName, this.BankCardNumber, this.CommenderID, this.CpsID, this.AlipayName, this.Memo, this.VisitSource, ref this._id, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (this._id >= 0L)
            {
                this.ID = this._id;
                string subject = "";
                string body = "";
                if (this.UserType == 1)
                {
                    this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "Register"], ref subject, ref body);
                    if ((subject != "") && (body != ""))
                    {
                        subject = subject.Replace("[UserName]", this.Name);
                        body = body.Replace("[UserName]", this.Name).Replace("[UserPassword]", this.Password).Replace("[UserEmail]", this.Email);
                        PF.SendEmail(this.Site, this.Email, subject, body);
                    }
                }
                else
                {
                    this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "RegisterAdv"], ref subject, ref body);
                    if (((subject != "") && (body != "")) && Functions.F_GetIsSendNotification(this.SiteID, 2, "RegisterAdv", this.ID))
                    {
                        subject = subject.Replace("[UserRealityName]", this.RealityName);
                        body = body.Replace("[UserRealityName]", this.RealityName).Replace("[UserName]", this.Name).Replace("[UserPassword]", this.Password).Replace("[UserPassword_2]", this.PasswordAdv).Replace("[UserEmail]", this.Email).Replace("[UserIDCardNumber]", this.IDCardNumber).Replace("[UserCity]", Functions.F_GetProvinceCity(this.CityID)).Replace("[UserSex]", this.Sex).Replace("[UserBirthDay]", this.BirthDay.ToShortDateString()).Replace("[UserTelphone]", this.Telephone).Replace("[UserMobile]", this.Mobile).Replace("[UserQQ]", this.QQ).Replace("[UserAddress]", this.Address).Replace("[UserBankType]", Functions.F_GetBankTypeName(this.BankType)).Replace("[UserBankName]", this.BankName).Replace("[UserBankCardNumber]", this.BankCardNumber);
                        PF.SendEmail(this.Site, this.Email, subject, body);
                    }
                }
            }
            return (int)this._id;
        }

        public int AddUserBalance(double Money, double FormalitiesFees, string PayNumber, string PayBank, string Memo, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_UserAddMoney(this.SiteID, this.ID, Money, FormalitiesFees, PayNumber, PayBank, Memo, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            return 0;
        }

        public int AddUserBalanceManual(double Money, string Memo, long OperatorID, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_UserAddMoneyManual(this.SiteID, this.ID, Money, Memo, OperatorID, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            return 0;
        }

        public void Clone(Users user)
        {
            user._id = this._id;
            user._siteid = this._siteid;
            user._password = this._password;
            user._passwordadv = this._passwordadv;
            user.Name = this.Name;
            user.RealityName = this.RealityName;
            user.Sex = this.Sex;
            user.BirthDay = this.BirthDay;
            user.IDCardNumber = this.IDCardNumber;
            user.CityID = this.CityID;
            user.Address = this.Address;
            user.Email = this.Email;
            user.isEmailValided = this.isEmailValided;
            user.QQ = this.QQ;
            user.isQQValided = this.isQQValided;
            user.Telephone = this.Telephone;
            user.Mobile = this.Mobile;
            user.isMobileValided = this.isMobileValided;
            user.isPrivacy = this.isPrivacy;
            user.isCanLogin = this.isCanLogin;
            user.RegisterTime = this.RegisterTime;
            user.LastLoginTime = this.LastLoginTime;
            user.LastLoginIP = this.LastLoginIP;
            user.LoginCount = this.LoginCount;
            user.UserType = this.UserType;
            user.BankType = this.BankType;
            user.BankName = this.BankName;
            user.BankCardNumber = this.BankCardNumber;
            user.Balance = this.Balance;
            user.Freeze = this.Freeze;
            user.ScoringOfSelfBuy = this.ScoringOfSelfBuy;
            user.ScoringOfCommendBuy = this.ScoringOfCommendBuy;
            user.Scoring = this.Scoring;
            user.Bonus = this.Bonus;
            user.Reward = this.Reward;
            user.Level = this.Level;
            user.CommenderID = this.CommenderID;
            user.CpsID = this.CpsID;
            user.cps = this.cps;
            user.isAlipayCps = this.isAlipayCps;
            user.AlipayID = this.AlipayID;
            user.AlipayName = this.AlipayName;
            user.isAlipayNameValided = this.isAlipayNameValided;
            user.Site = this.Site;
            user.Competences = this.Competences;
            user.OwnerSites = this.OwnerSites;
            user.VisitSource = this.VisitSource;
        }

        public int CpsDistill(double Money, double FormalitiesFees, string BankUserName, string _BankName, string _BankCardNumber, string Memo, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_CpsDistill(this.Site.ID, this.ID, Money, FormalitiesFees, BankUserName, _BankName, _BankCardNumber, Memo, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            return 0;
        }

        public int CpsDistillAccept(long DistillID, string PayName, string PayBank, string PayCardNumber, string Memo, long HandleOperatorID, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_CpsDistillAccept(this.Site.ID, this.ID, DistillID, PayName, PayBank, PayCardNumber, Memo, HandleOperatorID, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            return 0;
        }

        public int CpsDistillNoAccept(long DistillID, string Memo, long HandleOperatorID, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_CpsDistillNoAccept(this.Site.ID, this.ID, DistillID, Memo, HandleOperatorID, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            return 0;
        }

        public int CpsDistillQuash(long DistillID, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_CpsDistillQuash(this.Site.ID, this.ID, DistillID, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            return 0;
        }

        public int Distill(int DistillType, double Money, double FormalitiesFees, string BankUserName, string _BankName, string _BankCardNumber, string _AlipayID, string _AlipayName, string Memo, bool IsCps, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_Distill(this.Site.ID, this.ID, DistillType, Money, FormalitiesFees, BankUserName, _BankName, _BankCardNumber, _AlipayID, _AlipayName, Memo, IsCps, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            return 0;
        }

        public int DistillAccept(long DistillID, string PayName, string PayBank, string PayCardNumber, string _AlipayID, string _AlipayName, string Memo, long HandleOperatorID, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_DistillAccept(this.Site.ID, this.ID, DistillID, PayName, PayBank, PayCardNumber, _AlipayID, _AlipayName, Memo, HandleOperatorID, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            return 0;
        }

        public int DistillNoAccept(long DistillID, string Memo, long HandleOperatorID, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_DistillNoAccept(this.Site.ID, this.ID, DistillID, Memo, HandleOperatorID, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            return 0;
        }

        public int DistillQuash(long DistillID, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_DistillQuash(this.Site.ID, this.ID, DistillID, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            return 0;
        }

        public int EditByID(ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_UserEditByID(this.SiteID, this.ID, this.Name, this.RealityName, this.Password, this.PasswordAdv, this.CityID, this.Sex, this.BirthDay, this.IDCardNumber, this.Address, this.Email, this.isEmailValided, this.QQ, this.isQQValided, this.Telephone, this.Mobile, this.isMobileValided, this.isPrivacy, this.isCanLogin, this.UserType, this.BankType, this.BankName, this.BankCardNumber, this.ScoringOfSelfBuy, this.ScoringOfCommendBuy, this.Level, this.AlipayID, this.AlipayName, this.isAlipayNameValided, this.PromotionMemberBonusScale, this.PromotionSiteBonusScale, this.IsCrossLogin, this.Reason, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            this.SendNotificationForUserEdit();
            return 0;
        }

        public int EditByName(ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_UserEditByName(this.SiteID, this.ID, this.Name, this.RealityName, this.Password, this.PasswordAdv, this.CityID, this.Sex, this.BirthDay, this.IDCardNumber, this.Address, this.Email, this.isEmailValided, this.QQ, this.isQQValided, this.Telephone, this.Mobile, this.isMobileValided, this.isPrivacy, this.isCanLogin, this.UserType, this.BankType, this.BankName, this.BankCardNumber, this.ScoringOfSelfBuy, this.ScoringOfCommendBuy, this.Level, this.AlipayID, this.AlipayName, this.isAlipayNameValided, this.PromotionMemberBonusScale, this.PromotionSiteBonusScale, this.IsCrossLogin, this.Reason, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            this.SendNotificationForUserEdit();
            return 0;
        }

        public int ExecChaseTaskDetail(long ChaseTaskDetailID, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_ExecChaseTaskDetail(this.Site.ID, ChaseTaskDetailID, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            if ((this.Email != "") && Functions.F_GetIsSendNotification(this.SiteID, 2, "ExecChaseTaskDetail", this.ID))
            {
                string subject = "";
                string body = "";
                this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "ExecChaseTaskDetail"], ref subject, ref body);
                if ((subject != "") && (body != ""))
                {
                    subject = subject.Replace("[UserName]", this.Name);
                    body = body.Replace("[UserName]", this.Name).Replace("[Chase_id]", ChaseTaskDetailID.ToString());
                    PF.SendEmail(this.Site, this.Email, subject, body);
                }
            }
            if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "ExecChaseTaskDetail", this.ID))
            {
                string content = this.Site.SiteNotificationTemplates[1, "ExecChaseTaskDetail"];
                if (content != "")
                {
                    content = content.Replace("[UserName]", this.Name).Replace("[Chase_id]", ChaseTaskDetailID.ToString());
                    PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                }
            }
            if (Functions.F_GetIsSendNotification(this.SiteID, 3, "ExecChaseTaskDetail", this.ID))
            {
                string str5 = this.Site.SiteNotificationTemplates[3, "ExecChaseTaskDetail"];
                if (str5 != "")
                {
                    str5 = str5.Replace("[UserName]", this.Name).Replace("[Chase_id]", ChaseTaskDetailID.ToString());
                    PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str5);
                }
            }
            return 0;
        }

        public static Users GetCurrentUser(long siteid)
        {
            string str = "SLS.Center.LoginUserID";
            HttpCookie cookie = HttpContext.Current.Request.Cookies[str];
            if ((cookie != null) && !string.IsNullOrEmpty(cookie.Value))
            {
                string input = cookie.Value;
                try
                {
                    input = Encrypt.UnEncryptString(PF.GetCallCert(), Encrypt.Decrypt3DES(PF.GetCallCert(), input, PF.DesKey));
                }
                catch
                {
                    input = "";
                }
                long num = -1L;
                Users users = null;
                if (!string.IsNullOrEmpty(input))
                {
                    num = _Convert.StrToLong(input, -1L);
                    if (num > 0L)
                    {
                        users = new Users(siteid)[siteid, num];
                        if (users != null)
                        {
                            return users;
                        }
                    }
                }
            }
            return null;
        }

        public string GetPromotionURL(int type)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            string str = "PromoteUserReg.aspx";
            if (type == 1)
            {
                str = "PromoteCpsReg.aspx";
            }
            return (Utility.GetUrl() + "/Home/Room/" + str + "?id=" + this.ID.ToString().PadLeft(10, '0') + this.GetSign().ToString());
        }

        public int GetSign()
        {
            int num = 0;
            int[] numArray = new int[] { 8, 2, 5, 7, 1 };
            for (int i = 0; i < this.ID.ToString().Length; i++)
            {
                num += _Convert.StrToInt(this.ID.ToString().Substring(i, 1), 0) * numArray[i % 5];
            }
            return (num % 10);
        }

        public int GetUserInformationByID(ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            Users user = new Users(this.SiteID);
            this.Clone(user);
            if (Procedures.P_GetUserInformationByID(this.ID, this.SiteID, ref this.Name, ref this.NickName, ref this.RealityName, ref this._password, ref this._passwordadv, ref this.CityID, ref this.Sex, ref this.BirthDay, ref this.IDCardNumber, ref this.Address, ref this.Email, ref this.isEmailValided, ref this.QQ, ref this.isQQValided, ref this.Telephone, ref this.Mobile, ref this.isMobileValided, ref this.isPrivacy, ref this.isCanLogin, ref this.RegisterTime, ref this.LastLoginTime, ref this.LastLoginIP, ref this.LoginCount, ref this.UserType, ref this.BankType, ref this.BankName, ref this.BankCardNumber, ref this.Balance, ref this.cardPasswordM, ref this.Freeze, ref this.ScoringOfSelfBuy, ref this.ScoringOfCommendBuy, ref this.Scoring, ref this.Level, ref this.CommenderID, ref this.CpsID, ref this.OwnerSites, ref this.AlipayID, ref this.Bonus, ref this.Reward, ref this.AlipayName, ref this.isAlipayNameValided, ref this.ComeFrom, ref this.IsCrossLogin, ref this.Memo, ref this.BonusThisMonth, ref this.BonusAllow, ref this.BonusUse, ref this.PromotionMemberBonusScale, ref this.PromotionSiteBonusScale, ref this.VisitSource, ref this.HeadUrl, ref this.SecurityQuestion, ref this.SecurityAnswer, ref this.FriendList, ref returnValue, ref ReturnDescription) < 0)
            {
                user.Clone(this);
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                user.Clone(this);
                return returnValue;
            }
            this.cps.OwnerUserID = this.ID;
            ReturnDescription = "";
            this.cps.GetCpsInformationByOwnerUserID(ref ReturnDescription);
            if ((this.cps.SiteID > 0L) && (this.cps.ID < 0L))
            {
                ReturnDescription = "";
            }
            return 0;
        }

        public int GetUserInformationByName(ref string ReturnDescription)
        {
            int returnValue = -1;
            ReturnDescription = "";
            Users user = new Users(this.SiteID);
            this.Clone(user);
            if (Procedures.P_GetUserInformationByName(this.Name, this.SiteID, ref this._id, ref this.NickName, ref this.RealityName, ref this._password, ref this._passwordadv, ref this.CityID, ref this.Sex, ref this.BirthDay, ref this.IDCardNumber, ref this.Address, ref this.Email, ref this.isEmailValided, ref this.QQ, ref this.isQQValided, ref this.Telephone, ref this.Mobile, ref this.isMobileValided, ref this.isPrivacy, ref this.isCanLogin, ref this.RegisterTime, ref this.LastLoginTime, ref this.LastLoginIP, ref this.LoginCount, ref this.UserType, ref this.BankType, ref this.BankName, ref this.BankCardNumber, ref this.Balance, ref this.Freeze, ref this.ScoringOfSelfBuy, ref this.ScoringOfCommendBuy, ref this.Scoring, ref this.Level, ref this.CommenderID, ref this.CpsID, ref this.OwnerSites, ref this.AlipayID, ref this.Bonus, ref this.Reward, ref this.AlipayName, ref this.isAlipayNameValided, ref this.ComeFrom, ref this.isCanLogin, ref this.Memo, ref this.BonusThisMonth, ref this.BonusAllow, ref this.BonusUse, ref this.PromotionMemberBonusScale, ref this.PromotionSiteBonusScale, ref this.VisitSource, ref this.HeadUrl, ref this.SecurityQuestion, ref this.SecurityAnswer, ref this.FriendList, ref returnValue, ref ReturnDescription) < 0)
            {
                user.Clone(this);
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                user.Clone(this);
                return returnValue;
            }
            this.cps.OwnerUserID = this.ID;
            ReturnDescription = "";
            this.cps.GetCpsInformationByOwnerUserID(ref ReturnDescription);
            if ((this.cps.SiteID > 0L) && (this.cps.ID < 0L))
            {
                ReturnDescription = "";
            }
            return 0;
        }

        public int InitiateChaseTask(string Title, string Description, int LotteryID, double StopWhenWinMoney, string DetailXML, string LotteryNumber, double SchemeBonusScalec, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            ReturnDescription = "";
            long chaseTaskID = -1L;
            if (Procedures.P_InitiateChaseTask(this.Site.ID, this.ID, Title, Description, LotteryID, StopWhenWinMoney, DetailXML, LotteryNumber, SchemeBonusScalec, ref chaseTaskID, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (chaseTaskID >= 0L)
            {
                string returnDescription = "";
                this.GetUserInformationByID(ref returnDescription);
                if ((this.Email != "") && Functions.F_GetIsSendNotification(this.SiteID, 2, "InitiateChaseTask", this.ID))
                {
                    string subject = "";
                    string body = "";
                    this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "InitiateChaseTask"], ref subject, ref body);
                    if ((subject != "") && (body != ""))
                    {
                        subject = subject.Replace("[UserName]", this.Name);
                        body = body.Replace("[UserName]", this.Name).Replace("[Chase_id]", chaseTaskID.ToString());
                        PF.SendEmail(this.Site, this.Email, subject, body);
                    }
                }
                if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "InitiateChaseTask", this.ID))
                {
                    string content = this.Site.SiteNotificationTemplates[1, "InitiateChaseTask"];
                    if (content != "")
                    {
                        content = content.Replace("[UserName]", this.Name).Replace("[Chase_id]", chaseTaskID.ToString());
                        PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                    }
                }
                if (Functions.F_GetIsSendNotification(this.SiteID, 3, "InitiateChaseTask", this.ID))
                {
                    string str5 = this.Site.SiteNotificationTemplates[3, "InitiateChaseTask"];
                    if (str5 != "")
                    {
                        str5 = str5.Replace("[UserName]", this.Name).Replace("[Chase_id]", chaseTaskID.ToString());
                        PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str5);
                    }
                }
            }
            return (int)chaseTaskID;
        }

        public int InitiateCustomChase(int LotteryID, int PlayTypeID, int Price, short Type, DateTime EndTime, int IsuseCount, int Multiple, int Nums, short BetType, string LotteryNumber, short StopType, double stopMoney, double Money, string Title, string ChaseXML, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            ReturnDescription = "";
            int chaseID = -1;
            if (Procedures.P_ChasesAdd(this.ID, LotteryID, PlayTypeID, Price, Type, DateTime.Now, EndTime, IsuseCount, Multiple, Nums, BetType, LotteryNumber, StopType, stopMoney, Money, Title, ChaseXML, ref chaseID, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (chaseID >= 0)
            {
                string returnDescription = "";
                this.GetUserInformationByID(ref returnDescription);
                if (((this.Email != "") && this.isEmailValided) && Functions.F_GetIsSendNotification(this.SiteID, 2, "IntiateCustomChase", this.ID))
                {
                    string subject = "";
                    string body = "";
                    this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "IntiateCustomChase"], ref subject, ref body);
                    if ((subject != "") && (body != ""))
                    {
                        subject = subject.Replace("[UserName]", this.Name);
                        body = body.Replace("[UserName]", this.Name).Replace("[Chase_id]", chaseID.ToString());
                        PF.SendEmail(this.Site, this.Email, subject, body);
                    }
                }
                if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "IntiateCustomChase", this.ID))
                {
                    string content = this.Site.SiteNotificationTemplates[1, "IntiateCustomChase"];
                    if (content != "")
                    {
                        content = content.Replace("[UserName]", this.Name).Replace("[Chase_id]", chaseID.ToString());
                        PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                    }
                }
                if (Functions.F_GetIsSendNotification(this.SiteID, 3, "IntiateCustomChase", this.ID))
                {
                    string str5 = this.Site.SiteNotificationTemplates[3, "IntiateCustomChase"];
                    if (str5 != "")
                    {
                        str5 = str5.Replace("[UserName]", this.Name).Replace("[ChaseID]", chaseID.ToString());
                        PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str5);
                    }
                }
            }
            return chaseID;
        }

        public long InitiateScheme(long IsuseID, int PlayTypeID, string Title, string Description, string LotteryNumber, string UpdateloadFileContent, int Multiple, double Money, double AssureMoney, int Share, int BuyShare, string OpenUsers, short SecrecyLevel, double SchemeBonusScale, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            ReturnDescription = "";
            if ((SecrecyLevel < 0) || (SecrecyLevel > 3))
            {
                SecrecyLevel = 0;
            }
            long schemeID = -1L;
            if (Procedures.P_InitiateScheme(this.SiteID, this.ID, IsuseID, PlayTypeID, Title, Description, LotteryNumber, UpdateloadFileContent, Multiple, Money, AssureMoney, Share, BuyShare, OpenUsers.Replace('，', ','), SecrecyLevel, SchemeBonusScale, ref schemeID, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1L;
            }
            if (schemeID >= 0L)
            {
                string returnDescription = "";
                this.GetUserInformationByID(ref returnDescription);
                if ((this.Email != "") && Functions.F_GetIsSendNotification(this.SiteID, 2, "InitiateScheme", this.ID))
                {
                    string subject = "";
                    string body = "";
                    this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "InitiateScheme"], ref subject, ref body);
                    if ((subject != "") && (body != ""))
                    {
                        subject = subject.Replace("[UserName]", this.Name);
                        body = body.Replace("[UserName]", this.Name).Replace("[SchemeID]", schemeID.ToString()).Replace("[LotteryNumber]", LotteryNumber.Replace("\n", "<BR />")).Replace("[Multiple]", Multiple.ToString()).Replace("[Money]", Money.ToString("N")).Replace("[AssureMoney]", AssureMoney.ToString("N")).Replace("[Share]", Share.ToString()).Replace("[BuyShare]", BuyShare.ToString()).Replace("[OpenUserList]", OpenUsers);
                        PF.SendEmail(this.Site, this.Email, subject, body);
                    }
                }
                if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "InitiateScheme", this.ID))
                {
                    string content = this.Site.SiteNotificationTemplates[1, "InitiateScheme"];
                    if (content != "")
                    {
                        content = content.Replace("[UserName]", this.Name).Replace("[SchemeID]", schemeID.ToString());
                        PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                    }
                }
                if (Functions.F_GetIsSendNotification(this.SiteID, 3, "InitiateScheme", this.ID))
                {
                    string str5 = this.Site.SiteNotificationTemplates[3, "InitiateScheme"];
                    if (str5 != "")
                    {
                        str5 = str5.Replace("[UserName]", this.Name).Replace("[SchemeID]", schemeID.ToString());
                        PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str5);
                    }
                }
            }
            return schemeID;
        }

        public bool isCanViewSchemeContent(long SchemeID)
        {
            bool flag = this.ID == Functions.F_GetSchemeInitiateUserID(this.SiteID, SchemeID);
            bool flag2 = this.isInOpenUsers(SchemeID);
            bool flag3 = this.isOwnedViewSchemeCompetence();
            if (!flag && !flag2)
            {
                return flag3;
            }
            return true;
        }

        public bool isInOpenUsers(long SchemeID)
        {
            return this.isInOpenUsers(Functions.F_GetSchemeOpenUsers(SchemeID));
        }

        public bool isInOpenUsers(string OpenUsers)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            return ((OpenUsers == "") || (OpenUsers.IndexOf("[" + this.ID.ToString() + "]") >= 0));
        }

        public bool isOwnedViewSchemeCompetence()
        {
            return this.Competences.IsOwnedCompetences(Competences.BuildCompetencesList(new string[] { "Administrator", "LotteryBuy", "LotteryWin", "Finance" }));
        }

        public int JoinScheme(long SchemeID, int Share, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_JoinScheme(this.Site.ID, this.ID, SchemeID, Share, false, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            if ((this.Email != "") && Functions.F_GetIsSendNotification(this.SiteID, 2, "JoinScheme", this.ID))
            {
                string subject = "";
                string body = "";
                this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "JoinScheme"], ref subject, ref body);
                if ((subject != "") && (body != ""))
                {
                    DataTable table = new Tables.T_Schemes().Open("", "[id] = " + SchemeID.ToString(), "");
                    string str4 = "";
                    int num3 = 0;
                    double num4 = 0.0;
                    int num5 = 0;
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        str4 = table.Rows[0]["LotteryNumber"].ToString();
                        num3 = _Convert.StrToInt(table.Rows[0]["Multiple"].ToString(), 0);
                        num4 = _Convert.StrToDouble(table.Rows[0]["Money"].ToString(), 0.0);
                        num5 = _Convert.StrToInt(table.Rows[0]["Share"].ToString(), 0);
                    }
                    if (((str4 != "") && (num3 > 0)) && ((num4 > 0.0) && (num5 > 0)))
                    {
                        subject = subject.Replace("[UserName]", this.Name);
                        body = body.Replace("[UserName]", this.Name).Replace("[SchemeID]", SchemeID.ToString()).Replace("[LotteryNumber]", str4.Replace("\n", "<BR />")).Replace("[Multiple]", num3.ToString()).Replace("[Money]", num4.ToString("N")).Replace("[Share]", num5.ToString()).Replace("[BuyShare]", Share.ToString());
                        PF.SendEmail(this.Site, this.Email, subject, body);
                    }
                }
            }
            if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "JoinScheme", this.ID))
            {
                string content = this.Site.SiteNotificationTemplates[1, "JoinScheme"];
                if (content != "")
                {
                    content = content.Replace("[UserName]", this.Name).Replace("[SchemeID]", SchemeID.ToString());
                    PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                }
            }
            if (Functions.F_GetIsSendNotification(this.SiteID, 3, "JoinScheme", this.ID))
            {
                string str6 = this.Site.SiteNotificationTemplates[3, "JoinScheme"];
                if (str6 != "")
                {
                    str6 = str6.Replace("[UserName]", this.Name).Replace("[SchemeID]", SchemeID.ToString());
                    PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str6);
                }
            }
            return 0;
        }

        public int Login(ref string ReturnDescription)
        {
            int returnValue = -1;
            ReturnDescription = "";
            int num2 = Procedures.P_Login(this.SiteID, this.Name, this.Password, this.LastLoginIP, ref this._id, ref this._passwordadv, ref this.RealityName, ref this.CityID, ref this.Sex, ref this.BirthDay, ref this.IDCardNumber, ref this.Address, ref this.Email, ref this.isEmailValided, ref this.QQ, ref this.isQQValided, ref this.Telephone, ref this.Mobile, ref this.isMobileValided, ref this.isPrivacy, ref this.isCanLogin, ref this.RegisterTime, ref this.LastLoginTime, ref this.LastLoginIP, ref this.LoginCount, ref this.UserType, ref this.BankType, ref this.BankName, ref this.BankCardNumber, ref this.Balance, ref this.cardPasswordM, ref this.Freeze, ref this.ScoringOfSelfBuy, ref this.ScoringOfCommendBuy, ref this.Scoring, ref this.Level, ref this.CommenderID, ref this.CpsID, ref this.AlipayID, ref this.AlipayName, ref this.isAlipayNameValided, ref this.Bonus, ref this.Reward, ref this.Memo, ref this.BonusThisMonth, ref this.BonusAllow, ref this.BonusUse, ref this.PromotionMemberBonusScale, ref this.PromotionSiteBonusScale, ref returnValue, ref ReturnDescription);
            if (num2 < 0)
            {
                return num2;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            this.ID = this._id;
            this.SaveUserIDToCookie();
            return 0;
        }

        public int LoginDirect(ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            ReturnDescription = "";
            if (!this.isCanLogin)
            {
                ReturnDescription = "用户被限制登录";
                return -1;
            }
            this.SaveUserIDToCookie();
            return 0;
        }

        public int Logout(ref string ReturnDescription)
        {
            ReturnDescription = "";
            this.RemoveUserIDFromCookie();
            return 0;
        }

        public int Quash(long BuyDetailID, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_Quash(this.SiteID, BuyDetailID, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            if ((this.Email != "") && Functions.F_GetIsSendNotification(this.SiteID, 2, "Quash", this.ID))
            {
                string subject = "";
                string body = "";
                this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "Quash"], ref subject, ref body);
                if ((subject != "") && (body != ""))
                {
                    subject = subject.Replace("[UserName]", this.Name);
                    body = body.Replace("[UserName]", this.Name).Replace("[LotteryBuyDetail_id]", BuyDetailID.ToString());
                    PF.SendEmail(this.Site, this.Email, subject, body);
                }
            }
            if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "Quash", this.ID))
            {
                string content = this.Site.SiteNotificationTemplates[1, "Quash"];
                if (content != "")
                {
                    content = content.Replace("[UserName]", this.Name).Replace("[LotteryBuyDetail_id]", BuyDetailID.ToString());
                    PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                }
            }
            if (Functions.F_GetIsSendNotification(this.SiteID, 3, "Quash", this.ID))
            {
                string str5 = this.Site.SiteNotificationTemplates[3, "Quash"];
                if (str5 != "")
                {
                    str5 = str5.Replace("[UserName]", this.Name).Replace("[LotteryBuyDetail_id]", BuyDetailID.ToString());
                    PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str5);
                }
            }
            return 0;
        }

        public int QuashChaseTask(long ChaseTaskID, bool isSystemQuashed, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_QuashChaseTask(this.Site.ID, ChaseTaskID, isSystemQuashed, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            if ((this.Email != "") && Functions.F_GetIsSendNotification(this.SiteID, 2, "QuashChaseTask", this.ID))
            {
                string subject = "";
                string body = "";
                this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "QuashChaseTask"], ref subject, ref body);
                if ((subject != "") && (body != ""))
                {
                    subject = subject.Replace("[UserName]", this.Name);
                    body = body.Replace("[UserName]", this.Name).Replace("[Chase_id]", ChaseTaskID.ToString());
                    PF.SendEmail(this.Site, this.Email, subject, body);
                }
            }
            if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "QuashChaseTask", this.ID))
            {
                string content = this.Site.SiteNotificationTemplates[1, "QuashChaseTask"];
                if (content != "")
                {
                    content = content.Replace("[UserName]", this.Name).Replace("[Chase_id]", ChaseTaskID.ToString());
                    PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                }
            }
            if (Functions.F_GetIsSendNotification(this.SiteID, 3, "QuashChaseTask", this.ID))
            {
                string str5 = this.Site.SiteNotificationTemplates[3, "QuashChaseTask"];
                if (str5 != "")
                {
                    str5 = str5.Replace("[UserName]", this.Name).Replace("[Chase_id]", ChaseTaskID.ToString());
                    PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str5);
                }
            }
            return 0;
        }

        public int QuashChaseTaskDetail(long ChaseTaskDetailID, bool isSystemQuashed, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_QuashChaseTaskDetail(this.Site.ID, ChaseTaskDetailID, isSystemQuashed, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            if ((this.Email != "") && Functions.F_GetIsSendNotification(this.SiteID, 2, "QuashChaseTaskDetail", this.ID))
            {
                string subject = "";
                string body = "";
                this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "QuashChaseTaskDetail"], ref subject, ref body);
                if ((subject != "") && (body != ""))
                {
                    subject = subject.Replace("[UserName]", this.Name);
                    body = body.Replace("[UserName]", this.Name);
                    PF.SendEmail(this.Site, this.Email, subject, body);
                }
            }
            if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "QuashChaseTaskDetail", this.ID))
            {
                string content = this.Site.SiteNotificationTemplates[1, "QuashChaseTaskDetail"];
                if (content != "")
                {
                    content = content.Replace("[UserName]", this.Name);
                    PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                }
            }
            if (Functions.F_GetIsSendNotification(this.SiteID, 3, "QuashChaseTaskDetail", this.ID))
            {
                string str5 = this.Site.SiteNotificationTemplates[3, "QuashChaseTaskDetail"];
                if (str5 != "")
                {
                    str5 = str5.Replace("[UserName]", this.Name);
                    PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str5);
                }
            }
            return 0;
        }

        public int QuashScheme(long SchemeID, bool isSystemQuashed, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_QuashScheme(this.Site.ID, SchemeID, isSystemQuashed, false, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            if (((this.Email != "") && this.isEmailValided) && Functions.F_GetIsSendNotification(this.SiteID, 2, "QuashScheme", this.ID))
            {
                string subject = "";
                string body = "";
                this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "QuashScheme"], ref subject, ref body);
                if ((subject != "") && (body != ""))
                {
                    subject = subject.Replace("[UserName]", this.Name);
                    body = body.Replace("[UserName]", this.Name).Replace("[Scheme_id]", SchemeID.ToString());
                    PF.SendEmail(this.Site, this.Email, subject, body);
                }
            }
            if (((this.Mobile != "") && this.isMobileValided) && (isSystemQuashed && Functions.F_GetIsSendNotification(this.SiteID, 1, "QuashScheme", this.ID)))
            {
                string content = this.Site.SiteNotificationTemplates[1, "QuashScheme"];
                if (content != "")
                {
                    content = content.Replace("[UserName]", this.Name).Replace("[Scheme_id]", SchemeID.ToString());
                    PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                }
            }
            if (Functions.F_GetIsSendNotification(this.SiteID, 3, "QuashScheme", this.ID))
            {
                string str5 = this.Site.SiteNotificationTemplates[3, "QuashScheme"];
                if (str5 != "")
                {
                    str5 = str5.Replace("[UserName]", this.Name).Replace("[SchemeID]", SchemeID.ToString());
                    PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str5);
                }
            }
            return 0;
        }

        private void RemoveUserIDFromCookie()
        {
            string name = "SLS.Center.LoginUserID";
            string str2 = "LastLoginShowFloatNotifyUserID";
            HttpCookie cookie = new HttpCookie(str2)
            {
                Value = "",
                Expires = DateTime.Now.AddYears(-20)
            };
            try
            {
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch
            {
            }
            HttpCookie cookie2 = new HttpCookie(name)
            {
                Value = "",
                Expires = DateTime.Now.AddYears(-20),
                Path = "/"
            };
            try
            {
                HttpContext.Current.Response.Cookies.Add(cookie2);
            }
            catch
            {
            }
        }

        private void SaveUserIDToCookie()
        {
            string name = "SLS.Center.LoginUserID";
            string str2 = "LastLoginShowFloatNotifyUserID";
            HttpCookie cookie = new HttpCookie(str2, Encrypt.Encrypt3DES(PF.GetCallCert(), Encrypt.EncryptString(PF.GetCallCert(), this.ID.ToString()), PF.DesKey));
            try
            {
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch
            {
            }
            HttpCookie cookie2 = new HttpCookie(name, Encrypt.Encrypt3DES(PF.GetCallCert(), Encrypt.EncryptString(PF.GetCallCert(), this.ID.ToString()), PF.DesKey))
            {
                Path = "/"
            };
            try
            {
                HttpContext.Current.Response.Cookies.Add(cookie2);
            }
            catch
            {
            }
        }

        public int ScoringExchange(double Scoring, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            int returnValue = -1;
            ReturnDescription = "";
            if (Procedures.P_ScoringExchange(this.Site.ID, this.ID, Scoring, ref returnValue, ref ReturnDescription) < 0)
            {
                ReturnDescription = "数据库读写错误";
                return -1;
            }
            if (returnValue < 0)
            {
                return returnValue;
            }
            string returnDescription = "";
            this.GetUserInformationByID(ref returnDescription);
            return 0;
        }

        private void SendNotificationForUserEdit()
        {
            if (this.UserType == 1)
            {
                if ((this.Email != "") && Functions.F_GetIsSendNotification(this.SiteID, 2, "UserEdit", this.ID))
                {
                    string subject = "";
                    string body = "";
                    this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "UserEdit"], ref subject, ref body);
                    if ((subject != "") && (body != ""))
                    {
                        subject = subject.Replace("[UserName]", this.Name);
                        body = body.Replace("[UserName]", this.Name).Replace("[UserPassword]", this.Password).Replace("[UserEmail]", this.Email);
                        PF.SendEmail(this.Site, this.Email, subject, body);
                    }
                }
            }
            else
            {
                if ((this.Email != "") && Functions.F_GetIsSendNotification(this.SiteID, 2, "UserEditAdv", this.ID))
                {
                    string str3 = "";
                    string str4 = "";
                    this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "UserEditAdv"], ref str3, ref str4);
                    if ((str3 != "") && (str4 != ""))
                    {
                        str3 = str3.Replace("[UserRealityName]", this.RealityName);
                        str4 = str4.Replace("[UserRealityName]", this.RealityName).Replace("[UserName]", this.Name).Replace("[UserPassword]", this.Password).Replace("[UserPassword_2]", this.PasswordAdv).Replace("[UserEmail]", this.Email).Replace("[UserIDCardNumber]", this.IDCardNumber).Replace("[UserCity]", Functions.F_GetProvinceCity(this.CityID)).Replace("[UserSex]", this.Sex).Replace("[UserBirthDay]", this.BirthDay.ToShortDateString()).Replace("[UserTelephone]", this.Telephone).Replace("[UserMobile]", this.Mobile).Replace("[UserQQ]", this.QQ).Replace("[UserAddress]", this.Address).Replace("[UserBankType]", Functions.F_GetBankTypeName(this.BankType)).Replace("[UserBankName]", this.BankName).Replace("[UserBankCardNumber]", this.BankCardNumber);
                        PF.SendEmail(this.Site, this.Email, str3, str4);
                    }
                }
                if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "UserEditAdv", this.ID))
                {
                    string content = this.Site.SiteNotificationTemplates[1, "UserEditAdv"];
                    if (content != "")
                    {
                        content = content.Replace("[UserRealityName]", this.RealityName);
                        PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                    }
                }
                if (Functions.F_GetIsSendNotification(this.SiteID, 3, "UserEditAdv", this.ID))
                {
                    string str6 = this.Site.SiteNotificationTemplates[3, "UserEditAdv"];
                    if (str6 != "")
                    {
                        str6 = str6.Replace("[UserRealityName]", this.RealityName);
                        PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str6);
                    }
                }
            }
        }

        public int Win(long SchemeID, double Money, ref string ReturnDescription)
        {
            if (this.ID < 0L)
            {
                throw new Exception("Users 尚未初始化到具体的数据实例上，请先使用 GetUserInformation 等获取数据信息");
            }
            ReturnDescription = "";
            if ((this.Email != "") && Functions.F_GetIsSendNotification(this.SiteID, 2, "Win", this.ID))
            {
                string subject = "";
                string body = "";
                this.Site.SiteNotificationTemplates.SplitEmailTemplate(this.Site.SiteNotificationTemplates[2, "Win"], ref subject, ref body);
                if ((subject != "") && (body != ""))
                {
                    subject = subject.Replace("[UserName]", this.Name);
                    body = body.Replace("[UserName]", this.Name).Replace("[SchemeID]", SchemeID.ToString()).Replace("[Money]", Money.ToString("N"));
                    PF.SendEmail(this.Site, this.Email, subject, body);
                }
            }
            if (((this.Mobile != "") && this.isMobileValided) && Functions.F_GetIsSendNotification(this.SiteID, 1, "Win", this.ID))
            {
                string content = this.Site.SiteNotificationTemplates[1, "Win"];
                if (content != "")
                {
                    content = content.Replace("[UserName]", this.Name).Replace("[SchemeID]", SchemeID.ToString()).Replace("[Money]", Money.ToString("N"));
                    PF.SendSMS(this.Site, this.ID, this.Mobile, content);
                }
            }
            if (Functions.F_GetIsSendNotification(this.SiteID, 3, "Win", this.ID))
            {
                string str4 = this.Site.SiteNotificationTemplates[3, "Win"];
                if (str4 != "")
                {
                    str4 = str4.Replace("[UserName]", this.Name).Replace("[SchemeID]", SchemeID.ToString()).Replace("[Money]", Money.ToString("N"));
                    PF.SendStationSMS(this.Site, this.Site.AdministratorID, this.ID, 2, str4);
                }
            }
            return 0;
        }

        public long ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
                this.cps.OwnerUserID = value;
                string returnDescription = "";
                if (this.GetUserInformationByID(ref returnDescription) < 0)
                {
                    this._id = -1L;
                    this.cps.OwnerUserID = -1L;
                }
            }
        }

        public Users this[long siteid, long id]
        {
            get
            {
                return new Users(siteid) { ID = id };
            }
        }

        public Users this[long siteid, string name]
        {
            get
            {
                Users users = new Users(siteid)
                {
                    Name = name
                };
                string returnDescription = "";
                if (users.GetUserInformationByName(ref returnDescription) < 0)
                {
                    return null;
                }
                return users;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = PF.EncryptPassword(value);
            }
        }

        public string PasswordAdv
        {
            get
            {
                return this._passwordadv;
            }
            set
            {
                this._passwordadv = PF.EncryptPassword(value);
            }
        }

        public long SiteID
        {
            get
            {
                return this._siteid;
            }
            set
            {
                this._siteid = value;
                this.Site.ID = value;
                string returnDescription = "";
                this.Site.GetSiteInformationByID(ref returnDescription);
                this.cps.SiteID = value;
            }
        }
    }
}
