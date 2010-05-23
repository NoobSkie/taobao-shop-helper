namespace DAL
{
    using Shove.Database;
    using System;
    using System.Data;

    public class Tables
    {
        public class T_ActiveAllBuyStar : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field LotterieID;
            public MSSQL.Field Order;
            public MSSQL.Field UserList;

            public T_ActiveAllBuyStar()
            {
                base.TableName = "T_ActiveAllBuyStar";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.LotterieID = new MSSQL.Field(this, "LotterieID", "LotterieID", SqlDbType.Int, false);
                this.UserList = new MSSQL.Field(this, "UserList", "UserList", SqlDbType.VarChar, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.Int, false);
            }
        }

        public class T_Activities21CN : MSSQL.TableBase
        {
            public MSSQL.Field AlipayName;
            public MSSQL.Field DateTime;
            public MSSQL.Field DayBalanceAdd;
            public MSSQL.Field DaySchemeMoney;
            public MSSQL.Field DayWinMoney;
            public MSSQL.Field ID;
            public MSSQL.Field IsReward1;
            public MSSQL.Field IsReward10;
            public MSSQL.Field IsReward2;
            public MSSQL.Field IsReward200;
            public MSSQL.Field UserID;

            public T_Activities21CN()
            {
                base.TableName = "T_Activities21CN";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.AlipayName = new MSSQL.Field(this, "AlipayName", "AlipayName", SqlDbType.VarChar, false);
                this.IsReward1 = new MSSQL.Field(this, "IsReward1", "IsReward1", SqlDbType.Bit, false);
                this.DayBalanceAdd = new MSSQL.Field(this, "DayBalanceAdd", "DayBalanceAdd", SqlDbType.Money, false);
                this.IsReward2 = new MSSQL.Field(this, "IsReward2", "IsReward2", SqlDbType.Bit, false);
                this.DaySchemeMoney = new MSSQL.Field(this, "DaySchemeMoney", "DaySchemeMoney", SqlDbType.Money, false);
                this.IsReward10 = new MSSQL.Field(this, "IsReward10", "IsReward10", SqlDbType.Bit, false);
                this.DayWinMoney = new MSSQL.Field(this, "DayWinMoney", "DayWinMoney", SqlDbType.Money, false);
                this.IsReward200 = new MSSQL.Field(this, "IsReward200", "IsReward200", SqlDbType.Bit, false);
            }
        }

        public class T_Activities360 : MSSQL.TableBase
        {
            public MSSQL.Field AlipayName;
            public MSSQL.Field DateTime;
            public MSSQL.Field DayBalanceAdd;
            public MSSQL.Field DaySchemeMoney;
            public MSSQL.Field DayWinMoney;
            public MSSQL.Field ID;
            public MSSQL.Field IsReward1;
            public MSSQL.Field IsReward10;
            public MSSQL.Field IsReward2;
            public MSSQL.Field IsReward200;
            public MSSQL.Field UserID;

            public T_Activities360()
            {
                base.TableName = "T_Activities360";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.AlipayName = new MSSQL.Field(this, "AlipayName", "AlipayName", SqlDbType.VarChar, false);
                this.IsReward1 = new MSSQL.Field(this, "IsReward1", "IsReward1", SqlDbType.Bit, false);
                this.DayBalanceAdd = new MSSQL.Field(this, "DayBalanceAdd", "DayBalanceAdd", SqlDbType.Money, false);
                this.IsReward2 = new MSSQL.Field(this, "IsReward2", "IsReward2", SqlDbType.Bit, false);
                this.DaySchemeMoney = new MSSQL.Field(this, "DaySchemeMoney", "DaySchemeMoney", SqlDbType.Money, false);
                this.IsReward10 = new MSSQL.Field(this, "IsReward10", "IsReward10", SqlDbType.Bit, false);
                this.DayWinMoney = new MSSQL.Field(this, "DayWinMoney", "DayWinMoney", SqlDbType.Money, false);
                this.IsReward200 = new MSSQL.Field(this, "IsReward200", "IsReward200", SqlDbType.Bit, false);
            }
        }

        public class T_ActivitiesAlipay : MSSQL.TableBase
        {
            public MSSQL.Field AlipayName;
            public MSSQL.Field DateTime;
            public MSSQL.Field DayBalanceAdd;
            public MSSQL.Field DaySchemeMoney;
            public MSSQL.Field DayWinMoney;
            public MSSQL.Field ID;
            public MSSQL.Field IsReward1;
            public MSSQL.Field IsReward10;
            public MSSQL.Field IsReward2;
            public MSSQL.Field IsReward200;
            public MSSQL.Field UserID;

            public T_ActivitiesAlipay()
            {
                base.TableName = "T_ActivitiesAlipay";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.AlipayName = new MSSQL.Field(this, "AlipayName", "AlipayName", SqlDbType.VarChar, false);
                this.IsReward1 = new MSSQL.Field(this, "IsReward1", "IsReward1", SqlDbType.Bit, false);
                this.DayBalanceAdd = new MSSQL.Field(this, "DayBalanceAdd", "DayBalanceAdd", SqlDbType.Money, false);
                this.IsReward2 = new MSSQL.Field(this, "IsReward2", "IsReward2", SqlDbType.Bit, false);
                this.DaySchemeMoney = new MSSQL.Field(this, "DaySchemeMoney", "DaySchemeMoney", SqlDbType.Money, false);
                this.IsReward10 = new MSSQL.Field(this, "IsReward10", "IsReward10", SqlDbType.Bit, false);
                this.DayWinMoney = new MSSQL.Field(this, "DayWinMoney", "DayWinMoney", SqlDbType.Money, false);
                this.IsReward200 = new MSSQL.Field(this, "IsReward200", "IsReward200", SqlDbType.Bit, false);
            }
        }

        public class T_ActivitiesMytv365 : MSSQL.TableBase
        {
            public MSSQL.Field AlipayName;
            public MSSQL.Field DateTime;
            public MSSQL.Field DayBalanceAdd;
            public MSSQL.Field DaySchemeMoney;
            public MSSQL.Field DayWinMoney;
            public MSSQL.Field ID;
            public MSSQL.Field IsReward1;
            public MSSQL.Field IsReward10;
            public MSSQL.Field IsReward2;
            public MSSQL.Field IsReward200;
            public MSSQL.Field UserID;

            public T_ActivitiesMytv365()
            {
                base.TableName = "T_ActivitiesMytv365";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.AlipayName = new MSSQL.Field(this, "AlipayName", "AlipayName", SqlDbType.VarChar, false);
                this.IsReward1 = new MSSQL.Field(this, "IsReward1", "IsReward1", SqlDbType.Bit, false);
                this.DayBalanceAdd = new MSSQL.Field(this, "DayBalanceAdd", "DayBalanceAdd", SqlDbType.Money, false);
                this.IsReward2 = new MSSQL.Field(this, "IsReward2", "IsReward2", SqlDbType.Bit, false);
                this.DaySchemeMoney = new MSSQL.Field(this, "DaySchemeMoney", "DaySchemeMoney", SqlDbType.Money, false);
                this.IsReward10 = new MSSQL.Field(this, "IsReward10", "IsReward10", SqlDbType.Bit, false);
                this.DayWinMoney = new MSSQL.Field(this, "DayWinMoney", "DayWinMoney", SqlDbType.Money, false);
                this.IsReward200 = new MSSQL.Field(this, "IsReward200", "IsReward200", SqlDbType.Bit, false);
            }
        }

        public class T_ActivitiesZJL : MSSQL.TableBase
        {
            public MSSQL.Field AlipayName;
            public MSSQL.Field DateTime;
            public MSSQL.Field DayBalanceAdd;
            public MSSQL.Field DaySchemeMoney;
            public MSSQL.Field DayWinMoney;
            public MSSQL.Field ID;
            public MSSQL.Field IsReward1;
            public MSSQL.Field IsReward10;
            public MSSQL.Field IsReward2;
            public MSSQL.Field IsReward200;
            public MSSQL.Field UserID;

            public T_ActivitiesZJL()
            {
                base.TableName = "T_ActivitiesZJL";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.AlipayName = new MSSQL.Field(this, "AlipayName", "AlipayName", SqlDbType.VarChar, false);
                this.IsReward1 = new MSSQL.Field(this, "IsReward1", "IsReward1", SqlDbType.Bit, false);
                this.DayBalanceAdd = new MSSQL.Field(this, "DayBalanceAdd", "DayBalanceAdd", SqlDbType.Money, false);
                this.IsReward2 = new MSSQL.Field(this, "IsReward2", "IsReward2", SqlDbType.Bit, false);
                this.DaySchemeMoney = new MSSQL.Field(this, "DaySchemeMoney", "DaySchemeMoney", SqlDbType.Money, false);
                this.IsReward10 = new MSSQL.Field(this, "IsReward10", "IsReward10", SqlDbType.Bit, false);
                this.DayWinMoney = new MSSQL.Field(this, "DayWinMoney", "DayWinMoney", SqlDbType.Money, false);
                this.IsReward200 = new MSSQL.Field(this, "IsReward200", "IsReward200", SqlDbType.Bit, false);
            }
        }

        public class T_Advertisements : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field isShow;
            public MSSQL.Field LotteryID;
            public MSSQL.Field Name;
            public MSSQL.Field Order;
            public MSSQL.Field Title;
            public MSSQL.Field Url;

            public T_Advertisements()
            {
                base.TableName = "T_Advertisements";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.Url = new MSSQL.Field(this, "Url", "Url", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.Int, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
            }
        }

        public class T_AlipayBuyTemp : MSSQL.TableBase
        {
            public MSSQL.Field AdditionasXml;
            public MSSQL.Field AssureMoney;
            public MSSQL.Field AssureShare;
            public MSSQL.Field BuyMoney;
            public MSSQL.Field BuyShare;
            public MSSQL.Field ChaseTaskID;
            public MSSQL.Field DateTime;
            public MSSQL.Field Description;
            public MSSQL.Field HandleResult;
            public MSSQL.Field ID;
            public MSSQL.Field IsChase;
            public MSSQL.Field IsCoBuy;
            public MSSQL.Field IsuseID;
            public MSSQL.Field LotteryID;
            public MSSQL.Field LotteryNumber;
            public MSSQL.Field Money;
            public MSSQL.Field Multiple;
            public MSSQL.Field Number;
            public MSSQL.Field OpenUsers;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field SchemeID;
            public MSSQL.Field SecrecyLevel;
            public MSSQL.Field Share;
            public MSSQL.Field SiteID;
            public MSSQL.Field StopwhenwinMoney;
            public MSSQL.Field SumMoney;
            public MSSQL.Field Title;
            public MSSQL.Field UpdateloadFileContent;
            public MSSQL.Field UserID;

            public T_AlipayBuyTemp()
            {
                base.TableName = "T_AlipayBuyTemp";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.HandleResult = new MSSQL.Field(this, "HandleResult", "HandleResult", SqlDbType.SmallInt, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.ChaseTaskID = new MSSQL.Field(this, "ChaseTaskID", "ChaseTaskID", SqlDbType.BigInt, false);
                this.IsChase = new MSSQL.Field(this, "IsChase", "IsChase", SqlDbType.Bit, false);
                this.IsCoBuy = new MSSQL.Field(this, "IsCoBuy", "IsCoBuy", SqlDbType.Bit, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.StopwhenwinMoney = new MSSQL.Field(this, "StopwhenwinMoney", "StopwhenwinMoney", SqlDbType.Money, false);
                this.AdditionasXml = new MSSQL.Field(this, "AdditionasXml", "AdditionasXml", SqlDbType.NText, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.Multiple = new MSSQL.Field(this, "Multiple", "Multiple", SqlDbType.Int, false);
                this.BuyMoney = new MSSQL.Field(this, "BuyMoney", "BuyMoney", SqlDbType.Money, false);
                this.SumMoney = new MSSQL.Field(this, "SumMoney", "SumMoney", SqlDbType.Money, false);
                this.AssureMoney = new MSSQL.Field(this, "AssureMoney", "AssureMoney", SqlDbType.Money, false);
                this.Share = new MSSQL.Field(this, "Share", "Share", SqlDbType.Int, false);
                this.BuyShare = new MSSQL.Field(this, "BuyShare", "BuyShare", SqlDbType.Int, false);
                this.AssureShare = new MSSQL.Field(this, "AssureShare", "AssureShare", SqlDbType.Int, false);
                this.SecrecyLevel = new MSSQL.Field(this, "SecrecyLevel", "SecrecyLevel", SqlDbType.SmallInt, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.LotteryNumber = new MSSQL.Field(this, "LotteryNumber", "LotteryNumber", SqlDbType.VarChar, false);
                this.UpdateloadFileContent = new MSSQL.Field(this, "UpdateloadFileContent", "UpdateloadFileContent", SqlDbType.VarChar, false);
                this.OpenUsers = new MSSQL.Field(this, "OpenUsers", "OpenUsers", SqlDbType.VarChar, false);
                this.Number = new MSSQL.Field(this, "Number", "Number", SqlDbType.Int, false);
            }
        }

        public class T_AlipayRegDonate : MSSQL.TableBase
        {
            public MSSQL.Field AlipayName;
            public MSSQL.Field DateTime;
            public MSSQL.Field HandleResult;
            public MSSQL.Field ID;
            public MSSQL.Field UserID;

            public T_AlipayRegDonate()
            {
                base.TableName = "T_AlipayRegDonate";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.AlipayName = new MSSQL.Field(this, "AlipayName", "AlipayName", SqlDbType.VarChar, false);
                this.HandleResult = new MSSQL.Field(this, "HandleResult", "HandleResult", SqlDbType.SmallInt, false);
            }
        }

        public class T_BankDetails : MSSQL.TableBase
        {
            public MSSQL.Field BankName;
            public MSSQL.Field BankTypeName;
            public MSSQL.Field CityName;
            public MSSQL.Field ID;
            public MSSQL.Field ProvinceName;

            public T_BankDetails()
            {
                base.TableName = "T_BankDetails";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.ProvinceName = new MSSQL.Field(this, "ProvinceName", "ProvinceName", SqlDbType.VarChar, false);
                this.CityName = new MSSQL.Field(this, "CityName", "CityName", SqlDbType.VarChar, false);
                this.BankTypeName = new MSSQL.Field(this, "BankTypeName", "BankTypeName", SqlDbType.VarChar, false);
                this.BankName = new MSSQL.Field(this, "BankName", "BankName", SqlDbType.VarChar, false);
            }
        }

        public class T_Banks : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field Name;
            public MSSQL.Field Order;

            public T_Banks()
            {
                base.TableName = "T_Banks";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.SmallInt, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.SmallInt, false);
            }
        }

        public class T_BuyDetails : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field DetailMoney;
            public MSSQL.Field ID;
            public MSSQL.Field isAutoFollowScheme;
            public MSSQL.Field isWhenInitiate;
            public MSSQL.Field QuashStatus;
            public MSSQL.Field SchemeID;
            public MSSQL.Field Share;
            public MSSQL.Field SiteID;
            public MSSQL.Field UserID;
            public MSSQL.Field WinMoneyNoWithTax;

            public T_BuyDetails()
            {
                base.TableName = "T_BuyDetails";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.Share = new MSSQL.Field(this, "Share", "Share", SqlDbType.Int, false);
                this.QuashStatus = new MSSQL.Field(this, "QuashStatus", "QuashStatus", SqlDbType.SmallInt, false);
                this.isWhenInitiate = new MSSQL.Field(this, "isWhenInitiate", "isWhenInitiate", SqlDbType.Bit, false);
                this.WinMoneyNoWithTax = new MSSQL.Field(this, "WinMoneyNoWithTax", "WinMoneyNoWithTax", SqlDbType.Money, false);
                this.isAutoFollowScheme = new MSSQL.Field(this, "isAutoFollowScheme", "isAutoFollowScheme", SqlDbType.Bit, false);
                this.DetailMoney = new MSSQL.Field(this, "DetailMoney", "DetailMoney", SqlDbType.Money, false);
            }
        }

        public class T_CardPasswordAgentDetails : MSSQL.TableBase
        {
            public MSSQL.Field AgentID;
            public MSSQL.Field Amount;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field Memo;
            public MSSQL.Field OperatorType;

            public T_CardPasswordAgentDetails()
            {
                base.TableName = "T_CardPasswordAgentDetails";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.AgentID = new MSSQL.Field(this, "AgentID", "AgentID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.OperatorType = new MSSQL.Field(this, "OperatorType", "OperatorType", SqlDbType.SmallInt, false);
                this.Amount = new MSSQL.Field(this, "Amount", "Amount", SqlDbType.Money, false);
                this.Memo = new MSSQL.Field(this, "Memo", "Memo", SqlDbType.VarChar, false);
            }
        }

        public class T_CardPasswordAgents : MSSQL.TableBase
        {
            public MSSQL.Field Balance;
            public MSSQL.Field Company;
            public MSSQL.Field ID;
            public MSSQL.Field IPAddressLimit;
            public MSSQL.Field Key;
            public MSSQL.Field Name;
            public MSSQL.Field Password;
            public MSSQL.Field State;
            public MSSQL.Field Url;

            public T_CardPasswordAgents()
            {
                base.TableName = "T_CardPasswordAgents";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Key = new MSSQL.Field(this, "Key", "Key", SqlDbType.VarChar, false);
                this.Password = new MSSQL.Field(this, "Password", "Password", SqlDbType.VarChar, false);
                this.Company = new MSSQL.Field(this, "Company", "Company", SqlDbType.VarChar, false);
                this.Url = new MSSQL.Field(this, "Url", "Url", SqlDbType.VarChar, false);
                this.State = new MSSQL.Field(this, "State", "State", SqlDbType.SmallInt, false);
                this.IPAddressLimit = new MSSQL.Field(this, "IPAddressLimit", "IPAddressLimit", SqlDbType.VarChar, false);
                this.Balance = new MSSQL.Field(this, "Balance", "Balance", SqlDbType.Money, false);
            }
        }

        public class T_CardPasswordAgentsTrys : MSSQL.TableBase
        {
            public MSSQL.Field AddedMoneyByMonth;
            public MSSQL.Field AddedUserByDay;
            public MSSQL.Field AgentTitle;
            public MSSQL.Field Departments;
            public MSSQL.Field ID;
            public MSSQL.Field InitUserCount;
            public MSSQL.Field InitUserMoneyCount;
            public MSSQL.Field Money;
            public MSSQL.Field Name;
            public MSSQL.Field Place;
            public MSSQL.Field SchemeDetails;
            public MSSQL.Field State;
            public MSSQL.Field Type;

            public T_CardPasswordAgentsTrys()
            {
                base.TableName = "T_CardPasswordAgentsTrys";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Departments = new MSSQL.Field(this, "Departments", "Departments", SqlDbType.VarChar, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.Type = new MSSQL.Field(this, "Type", "Type", SqlDbType.VarChar, false);
                this.AgentTitle = new MSSQL.Field(this, "AgentTitle", "AgentTitle", SqlDbType.VarChar, false);
                this.Place = new MSSQL.Field(this, "Place", "Place", SqlDbType.VarChar, false);
                this.SchemeDetails = new MSSQL.Field(this, "SchemeDetails", "SchemeDetails", SqlDbType.VarChar, false);
                this.InitUserCount = new MSSQL.Field(this, "InitUserCount", "InitUserCount", SqlDbType.BigInt, false);
                this.InitUserMoneyCount = new MSSQL.Field(this, "InitUserMoneyCount", "InitUserMoneyCount", SqlDbType.Money, false);
                this.AddedUserByDay = new MSSQL.Field(this, "AddedUserByDay", "AddedUserByDay", SqlDbType.BigInt, false);
                this.AddedMoneyByMonth = new MSSQL.Field(this, "AddedMoneyByMonth", "AddedMoneyByMonth", SqlDbType.Money, false);
                this.State = new MSSQL.Field(this, "State", "State", SqlDbType.SmallInt, false);
            }
        }

        public class T_CardPasswords : MSSQL.TableBase
        {
            public MSSQL.Field AgentID;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field Money;
            public MSSQL.Field Period;
            public MSSQL.Field State;
            public MSSQL.Field UseDateTime;
            public MSSQL.Field UserID;

            public T_CardPasswords()
            {
                base.TableName = "T_CardPasswords";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.AgentID = new MSSQL.Field(this, "AgentID", "AgentID", SqlDbType.Int, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Period = new MSSQL.Field(this, "Period", "Period", SqlDbType.DateTime, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.NChar, false);
                this.State = new MSSQL.Field(this, "State", "State", SqlDbType.SmallInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.UseDateTime = new MSSQL.Field(this, "UseDateTime", "UseDateTime", SqlDbType.DateTime, false);
            }
        }

        public class T_CardPasswordsValid : MSSQL.TableBase
        {
            public MSSQL.Field CardPasswordsNum;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field Mobile;
            public MSSQL.Field UserID;

            public T_CardPasswordsValid()
            {
                base.TableName = "T_CardPasswordsValid";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.Mobile = new MSSQL.Field(this, "Mobile", "Mobile", SqlDbType.VarChar, false);
                this.CardPasswordsNum = new MSSQL.Field(this, "CardPasswordsNum", "CardPasswordsNum", SqlDbType.VarChar, false);
            }
        }

        public class T_CardPasswordTryErrors : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field Number;
            public MSSQL.Field UserID;

            public T_CardPasswordTryErrors()
            {
                base.TableName = "T_CardPasswordTryErrors";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Number = new MSSQL.Field(this, "Number", "Number", SqlDbType.VarChar, false);
            }
        }

        public class T_CelebComments : MSSQL.TableBase
        {
            public MSSQL.Field CelebID;
            public MSSQL.Field CommentserID;
            public MSSQL.Field CommentserName;
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field isShow;

            public T_CelebComments()
            {
                base.TableName = "T_CelebComments";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.CelebID = new MSSQL.Field(this, "CelebID", "CelebID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.CommentserID = new MSSQL.Field(this, "CommentserID", "CommentserID", SqlDbType.BigInt, false);
                this.CommentserName = new MSSQL.Field(this, "CommentserName", "CommentserName", SqlDbType.VarChar, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_Celebs : MSSQL.TableBase
        {
            public MSSQL.Field Comment;
            public MSSQL.Field ID;
            public MSSQL.Field Intro;
            public MSSQL.Field isRecommended;
            public MSSQL.Field Order;
            public MSSQL.Field Say;
            public MSSQL.Field Score;
            public MSSQL.Field SiteID;
            public MSSQL.Field Title;
            public MSSQL.Field UserID;

            public T_Celebs()
            {
                base.TableName = "T_Celebs";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.BigInt, false);
                this.isRecommended = new MSSQL.Field(this, "isRecommended", "isRecommended", SqlDbType.Bit, false);
                this.Intro = new MSSQL.Field(this, "Intro", "Intro", SqlDbType.VarChar, false);
                this.Say = new MSSQL.Field(this, "Say", "Say", SqlDbType.VarChar, false);
                this.Comment = new MSSQL.Field(this, "Comment", "Comment", SqlDbType.VarChar, false);
                this.Score = new MSSQL.Field(this, "Score", "Score", SqlDbType.VarChar, false);
            }
        }

        public class T_ChaseLotteryNumber : MSSQL.TableBase
        {
            public MSSQL.Field ChaseID;
            public MSSQL.Field ID;
            public MSSQL.Field LotteryNumber;

            public T_ChaseLotteryNumber()
            {
                base.TableName = "T_ChaseLotteryNumber";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.ChaseID = new MSSQL.Field(this, "ChaseID", "ChaseID", SqlDbType.BigInt, false);
                this.LotteryNumber = new MSSQL.Field(this, "LotteryNumber", "LotteryNumber", SqlDbType.VarChar, false);
            }
        }

        public class T_Chases : MSSQL.TableBase
        {
            public MSSQL.Field BetType;
            public MSSQL.Field DateTime;
            public MSSQL.Field EndTime;
            public MSSQL.Field ID;
            public MSSQL.Field IsuseCount;
            public MSSQL.Field LotteryID;
            public MSSQL.Field LotteryNumber;
            public MSSQL.Field Money;
            public MSSQL.Field Multiple;
            public MSSQL.Field Nums;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field Price;
            public MSSQL.Field QuashStatus;
            public MSSQL.Field StartTime;
            public MSSQL.Field StopTypeWhenWin;
            public MSSQL.Field StopTypeWhenWinMoney;
            public MSSQL.Field Title;
            public MSSQL.Field Type;
            public MSSQL.Field UserID;

            public T_Chases()
            {
                base.TableName = "T_Chases";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.Type = new MSSQL.Field(this, "Type", "Type", SqlDbType.SmallInt, false);
                this.StartTime = new MSSQL.Field(this, "StartTime", "StartTime", SqlDbType.DateTime, false);
                this.EndTime = new MSSQL.Field(this, "EndTime", "EndTime", SqlDbType.DateTime, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.IsuseCount = new MSSQL.Field(this, "IsuseCount", "IsuseCount", SqlDbType.Int, false);
                this.Multiple = new MSSQL.Field(this, "Multiple", "Multiple", SqlDbType.Int, false);
                this.Nums = new MSSQL.Field(this, "Nums", "Nums", SqlDbType.Int, false);
                this.BetType = new MSSQL.Field(this, "BetType", "BetType", SqlDbType.SmallInt, false);
                this.LotteryNumber = new MSSQL.Field(this, "LotteryNumber", "LotteryNumber", SqlDbType.VarChar, false);
                this.StopTypeWhenWin = new MSSQL.Field(this, "StopTypeWhenWin", "StopTypeWhenWin", SqlDbType.SmallInt, false);
                this.StopTypeWhenWinMoney = new MSSQL.Field(this, "StopTypeWhenWinMoney", "StopTypeWhenWinMoney", SqlDbType.Money, false);
                this.QuashStatus = new MSSQL.Field(this, "QuashStatus", "QuashStatus", SqlDbType.SmallInt, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.Price = new MSSQL.Field(this, "Price", "Price", SqlDbType.Int, false);
            }
        }

        public class T_ChaseTaskDetailRedundancy : MSSQL.TableBase
        {
            public MSSQL.Field ChaseTaskDetailID;

            public T_ChaseTaskDetailRedundancy()
            {
                base.TableName = "T_ChaseTaskDetailRedundancy";
                this.ChaseTaskDetailID = new MSSQL.Field(this, "ChaseTaskDetailID", "ChaseTaskDetailID", SqlDbType.BigInt, false);
            }
        }

        public class T_ChaseTaskDetails : MSSQL.TableBase
        {
            public MSSQL.Field AssureShare;
            public MSSQL.Field BuyedShare;
            public MSSQL.Field ChaseTaskID;
            public MSSQL.Field DateTime;
            public MSSQL.Field Executed;
            public MSSQL.Field ID;
            public MSSQL.Field IsuseID;
            public MSSQL.Field LotteryNumber;
            public MSSQL.Field Money;
            public MSSQL.Field Multiple;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field QuashStatus;
            public MSSQL.Field SchemeID;
            public MSSQL.Field SecrecyLevel;
            public MSSQL.Field Share;
            public MSSQL.Field SiteID;

            public T_ChaseTaskDetails()
            {
                base.TableName = "T_ChaseTaskDetails";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.ChaseTaskID = new MSSQL.Field(this, "ChaseTaskID", "ChaseTaskID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.Multiple = new MSSQL.Field(this, "Multiple", "Multiple", SqlDbType.Int, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.QuashStatus = new MSSQL.Field(this, "QuashStatus", "QuashStatus", SqlDbType.SmallInt, false);
                this.Executed = new MSSQL.Field(this, "Executed", "Executed", SqlDbType.Bit, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.SecrecyLevel = new MSSQL.Field(this, "SecrecyLevel", "SecrecyLevel", SqlDbType.SmallInt, false);
                this.LotteryNumber = new MSSQL.Field(this, "LotteryNumber", "LotteryNumber", SqlDbType.VarChar, false);
                this.Share = new MSSQL.Field(this, "Share", "Share", SqlDbType.Int, false);
                this.BuyedShare = new MSSQL.Field(this, "BuyedShare", "BuyedShare", SqlDbType.Int, false);
                this.AssureShare = new MSSQL.Field(this, "AssureShare", "AssureShare", SqlDbType.Int, false);
            }
        }

        public class T_ChaseTasks : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field Description;
            public MSSQL.Field ID;
            public MSSQL.Field LotteryID;
            public MSSQL.Field QuashStatus;
            public MSSQL.Field SchemeBonusScale;
            public MSSQL.Field SiteID;
            public MSSQL.Field StopWhenWinMoney;
            public MSSQL.Field Title;
            public MSSQL.Field UserID;

            public T_ChaseTasks()
            {
                base.TableName = "T_ChaseTasks";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.QuashStatus = new MSSQL.Field(this, "QuashStatus", "QuashStatus", SqlDbType.SmallInt, false);
                this.StopWhenWinMoney = new MSSQL.Field(this, "StopWhenWinMoney", "StopWhenWinMoney", SqlDbType.Money, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.SchemeBonusScale = new MSSQL.Field(this, "SchemeBonusScale", "SchemeBonusScale", SqlDbType.Float, false);
            }
        }

        public class T_Citys : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field Name;
            public MSSQL.Field ProvinceID;

            public T_Citys()
            {
                base.TableName = "T_Citys";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, false);
                this.ProvinceID = new MSSQL.Field(this, "ProvinceID", "ProvinceID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
            }
        }

        public class T_Competences : MSSQL.TableBase
        {
            public MSSQL.Field Code;
            public MSSQL.Field Description;
            public MSSQL.Field ID;
            public MSSQL.Field Name;

            public T_Competences()
            {
                base.TableName = "T_Competences";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.SmallInt, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Code = new MSSQL.Field(this, "Code", "Code", SqlDbType.VarChar, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
            }
        }

        public class T_CompetencesOfGroups : MSSQL.TableBase
        {
            public MSSQL.Field CompetenceID;
            public MSSQL.Field GroupID;

            public T_CompetencesOfGroups()
            {
                base.TableName = "T_CompetencesOfGroups";
                this.GroupID = new MSSQL.Field(this, "GroupID", "GroupID", SqlDbType.SmallInt, false);
                this.CompetenceID = new MSSQL.Field(this, "CompetenceID", "CompetenceID", SqlDbType.SmallInt, false);
            }
        }

        public class T_CompetencesOfUsers : MSSQL.TableBase
        {
            public MSSQL.Field CompetenceID;
            public MSSQL.Field UserID;

            public T_CompetencesOfUsers()
            {
                base.TableName = "T_CompetencesOfUsers";
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.CompetenceID = new MSSQL.Field(this, "CompetenceID", "CompetenceID", SqlDbType.SmallInt, false);
            }
        }

        public class T_Cps : MSSQL.TableBase
        {
            public MSSQL.Field Address;
            public MSSQL.Field BonusScale;
            public MSSQL.Field CommendID;
            public MSSQL.Field Company;
            public MSSQL.Field ContactPerson;
            public MSSQL.Field DateTime;
            public MSSQL.Field DomainName;
            public MSSQL.Field Email;
            public MSSQL.Field Fax;
            public MSSQL.Field ID;
            public MSSQL.Field IsShow;
            public MSSQL.Field LogoUrl;
            public MSSQL.Field MD5Key;
            public MSSQL.Field Mobile;
            public MSSQL.Field Name;
            public MSSQL.Field ON;
            public MSSQL.Field OperatorID;
            public MSSQL.Field OwnerUserID;
            public MSSQL.Field PageFootConctrolFilelName;
            public MSSQL.Field PageHeadConctroFilelName;
            public MSSQL.Field PageTitleName;
            public MSSQL.Field ParentID;
            public MSSQL.Field PostCode;
            public MSSQL.Field QQ;
            public MSSQL.Field ResponsiblePerson;
            public MSSQL.Field ServiceTelephone;
            public MSSQL.Field SiteID;
            public MSSQL.Field Telephone;
            public MSSQL.Field Type;
            public MSSQL.Field Url;

            public T_Cps()
            {
                base.TableName = "T_Cps";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, false);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.OwnerUserID = new MSSQL.Field(this, "OwnerUserID", "OwnerUserID", SqlDbType.BigInt, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Url = new MSSQL.Field(this, "Url", "Url", SqlDbType.VarChar, false);
                this.LogoUrl = new MSSQL.Field(this, "LogoUrl", "LogoUrl", SqlDbType.VarChar, false);
                this.BonusScale = new MSSQL.Field(this, "BonusScale", "BonusScale", SqlDbType.Float, false);
                this.ON = new MSSQL.Field(this, "ON", "ON", SqlDbType.Bit, false);
                this.Company = new MSSQL.Field(this, "Company", "Company", SqlDbType.VarChar, false);
                this.Address = new MSSQL.Field(this, "Address", "Address", SqlDbType.VarChar, false);
                this.PostCode = new MSSQL.Field(this, "PostCode", "PostCode", SqlDbType.VarChar, false);
                this.ResponsiblePerson = new MSSQL.Field(this, "ResponsiblePerson", "ResponsiblePerson", SqlDbType.VarChar, false);
                this.ContactPerson = new MSSQL.Field(this, "ContactPerson", "ContactPerson", SqlDbType.VarChar, false);
                this.Telephone = new MSSQL.Field(this, "Telephone", "Telephone", SqlDbType.VarChar, false);
                this.Fax = new MSSQL.Field(this, "Fax", "Fax", SqlDbType.VarChar, false);
                this.Mobile = new MSSQL.Field(this, "Mobile", "Mobile", SqlDbType.VarChar, false);
                this.Email = new MSSQL.Field(this, "Email", "Email", SqlDbType.VarChar, false);
                this.QQ = new MSSQL.Field(this, "QQ", "QQ", SqlDbType.VarChar, false);
                this.ServiceTelephone = new MSSQL.Field(this, "ServiceTelephone", "ServiceTelephone", SqlDbType.VarChar, false);
                this.MD5Key = new MSSQL.Field(this, "MD5Key", "MD5Key", SqlDbType.VarChar, false);
                this.Type = new MSSQL.Field(this, "Type", "Type", SqlDbType.SmallInt, false);
                this.DomainName = new MSSQL.Field(this, "DomainName", "DomainName", SqlDbType.VarChar, false);
                this.ParentID = new MSSQL.Field(this, "ParentID", "ParentID", SqlDbType.BigInt, false);
                this.OperatorID = new MSSQL.Field(this, "OperatorID", "OperatorID", SqlDbType.BigInt, false);
                this.CommendID = new MSSQL.Field(this, "CommendID", "CommendID", SqlDbType.BigInt, false);
                this.IsShow = new MSSQL.Field(this, "IsShow", "IsShow", SqlDbType.Bit, false);
                this.PageTitleName = new MSSQL.Field(this, "PageTitleName", "PageTitleName", SqlDbType.VarChar, false);
                this.PageHeadConctroFilelName = new MSSQL.Field(this, "PageHeadConctroFilelName", "PageHeadConctroFilelName", SqlDbType.VarChar, false);
                this.PageFootConctrolFilelName = new MSSQL.Field(this, "PageFootConctrolFilelName", "PageFootConctrolFilelName", SqlDbType.VarChar, false);
            }
        }

        public class T_Cps_Help : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field ID;
            public MSSQL.Field Title;

            public T_Cps_Help()
            {
                base.TableName = "T_Cps_Help";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_CPS_SNS_SiteManager : MSSQL.TableBase
        {
            public MSSQL.Field CpsID;
            public MSSQL.Field ID;
            public MSSQL.Field Pid;
            public MSSQL.Field UnShowClub;
            public MSSQL.Field Url;

            public T_CPS_SNS_SiteManager()
            {
                base.TableName = "T_CPS_SNS_SiteManager";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Pid = new MSSQL.Field(this, "Pid", "Pid", SqlDbType.Int, false);
                this.CpsID = new MSSQL.Field(this, "CpsID", "CpsID", SqlDbType.Int, false);
                this.Url = new MSSQL.Field(this, "Url", "Url", SqlDbType.VarChar, false);
                this.UnShowClub = new MSSQL.Field(this, "UnShowClub", "UnShowClub", SqlDbType.Bit, false);
            }
        }

        public class T_CpsAccountRevenue : MSSQL.TableBase
        {
            public MSSQL.Field CpsBonus;
            public MSSQL.Field CpsID;
            public MSSQL.Field CpsWithSiteMoneySum;
            public MSSQL.Field DayNewUserCount;
            public MSSQL.Field DayNewUserPayCount;
            public MSSQL.Field DayNewUserPaySum;
            public MSSQL.Field DayTime;
            public MSSQL.Field ID;
            public MSSQL.Field TotalUserCount;

            public T_CpsAccountRevenue()
            {
                base.TableName = "T_CpsAccountRevenue";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.CpsID = new MSSQL.Field(this, "CpsID", "CpsID", SqlDbType.Int, false);
                this.DayTime = new MSSQL.Field(this, "DayTime", "DayTime", SqlDbType.DateTime, false);
                this.TotalUserCount = new MSSQL.Field(this, "TotalUserCount", "TotalUserCount", SqlDbType.Int, false);
                this.DayNewUserCount = new MSSQL.Field(this, "DayNewUserCount", "DayNewUserCount", SqlDbType.Int, false);
                this.DayNewUserPayCount = new MSSQL.Field(this, "DayNewUserPayCount", "DayNewUserPayCount", SqlDbType.Int, false);
                this.DayNewUserPaySum = new MSSQL.Field(this, "DayNewUserPaySum", "DayNewUserPaySum", SqlDbType.Money, false);
                this.CpsBonus = new MSSQL.Field(this, "CpsBonus", "CpsBonus", SqlDbType.Money, false);
                this.CpsWithSiteMoneySum = new MSSQL.Field(this, "CpsWithSiteMoneySum", "CpsWithSiteMoneySum", SqlDbType.Money, false);
            }
        }

        public class T_CpsBonusDetails : MSSQL.TableBase
        {
            public MSSQL.Field BonusScale;
            public MSSQL.Field BuyDetailID;
            public MSSQL.Field DateTime;
            public MSSQL.Field FromUserCpsID;
            public MSSQL.Field FromUserID;
            public MSSQL.Field ID;
            public MSSQL.Field IsAddInAllowBonus;
            public MSSQL.Field LotteryID;
            public MSSQL.Field Memo;
            public MSSQL.Field Money;
            public MSSQL.Field OperatorID;
            public MSSQL.Field OperatorType;
            public MSSQL.Field OwnerUserID;
            public MSSQL.Field PayBank;
            public MSSQL.Field PayNumber;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field PrintOutDatetime;
            public MSSQL.Field SchemeID;

            public T_CpsBonusDetails()
            {
                base.TableName = "T_CpsBonusDetails";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.OwnerUserID = new MSSQL.Field(this, "OwnerUserID", "OwnerUserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.BonusScale = new MSSQL.Field(this, "BonusScale", "BonusScale", SqlDbType.Float, false);
                this.IsAddInAllowBonus = new MSSQL.Field(this, "IsAddInAllowBonus", "IsAddInAllowBonus", SqlDbType.Bit, false);
                this.OperatorType = new MSSQL.Field(this, "OperatorType", "OperatorType", SqlDbType.SmallInt, false);
                this.FromUserID = new MSSQL.Field(this, "FromUserID", "FromUserID", SqlDbType.BigInt, false);
                this.FromUserCpsID = new MSSQL.Field(this, "FromUserCpsID", "FromUserCpsID", SqlDbType.BigInt, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.BuyDetailID = new MSSQL.Field(this, "BuyDetailID", "BuyDetailID", SqlDbType.BigInt, false);
                this.PayNumber = new MSSQL.Field(this, "PayNumber", "PayNumber", SqlDbType.VarChar, false);
                this.PayBank = new MSSQL.Field(this, "PayBank", "PayBank", SqlDbType.VarChar, false);
                this.OperatorID = new MSSQL.Field(this, "OperatorID", "OperatorID", SqlDbType.BigInt, false);
                this.Memo = new MSSQL.Field(this, "Memo", "Memo", SqlDbType.VarChar, false);
                this.PrintOutDatetime = new MSSQL.Field(this, "PrintOutDatetime", "PrintOutDatetime", SqlDbType.DateTime, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.BigInt, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.BigInt, false);
            }
        }

        public class T_CpsBonusScaleSetting : MSSQL.TableBase
        {
            public MSSQL.Field CommenderBonusScale;
            public MSSQL.Field CommendSiteBonusScale;
            public MSSQL.Field LotteryID;
            public MSSQL.Field LotteryName;
            public MSSQL.Field Memo;
            public MSSQL.Field SiteBonusScale;
            public MSSQL.Field TypeID;
            public MSSQL.Field UnionBonusScale;

            public T_CpsBonusScaleSetting()
            {
                base.TableName = "T_CpsBonusScaleSetting";
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.BigInt, false);
                this.LotteryName = new MSSQL.Field(this, "LotteryName", "LotteryName", SqlDbType.NVarChar, false);
                this.TypeID = new MSSQL.Field(this, "TypeID", "TypeID", SqlDbType.BigInt, false);
                this.UnionBonusScale = new MSSQL.Field(this, "UnionBonusScale", "UnionBonusScale", SqlDbType.Float, false);
                this.SiteBonusScale = new MSSQL.Field(this, "SiteBonusScale", "SiteBonusScale", SqlDbType.Float, false);
                this.CommenderBonusScale = new MSSQL.Field(this, "CommenderBonusScale", "CommenderBonusScale", SqlDbType.Float, false);
                this.CommendSiteBonusScale = new MSSQL.Field(this, "CommendSiteBonusScale", "CommendSiteBonusScale", SqlDbType.Float, false);
                this.Memo = new MSSQL.Field(this, "Memo", "Memo", SqlDbType.VarChar, false);
            }
        }

        public class T_CpsLog : MSSQL.TableBase
        {
            public MSSQL.Field Datetime;
            public MSSQL.Field ID;
            public MSSQL.Field LogContent;

            public T_CpsLog()
            {
                base.TableName = "T_CpsLog";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.Datetime = new MSSQL.Field(this, "Datetime", "Datetime", SqlDbType.DateTime, false);
                this.LogContent = new MSSQL.Field(this, "LogContent", "LogContent", SqlDbType.VarChar, false);
            }
        }

        public class T_CpsTrys : MSSQL.TableBase
        {
            public MSSQL.Field Address;
            public MSSQL.Field BonusScale;
            public MSSQL.Field CommendID;
            public MSSQL.Field Company;
            public MSSQL.Field ContactPerson;
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field DomainName;
            public MSSQL.Field Email;
            public MSSQL.Field Fax;
            public MSSQL.Field HandlelDateTime;
            public MSSQL.Field HandleResult;
            public MSSQL.Field ID;
            public MSSQL.Field LogoUrl;
            public MSSQL.Field MD5Key;
            public MSSQL.Field Mobile;
            public MSSQL.Field Name;
            public MSSQL.Field ParentID;
            public MSSQL.Field PostCode;
            public MSSQL.Field QQ;
            public MSSQL.Field ResponsiblePerson;
            public MSSQL.Field ServiceTelephone;
            public MSSQL.Field SiteID;
            public MSSQL.Field Telephone;
            public MSSQL.Field Type;
            public MSSQL.Field Url;
            public MSSQL.Field UserID;

            public T_CpsTrys()
            {
                base.TableName = "T_CpsTrys";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, false);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.HandleResult = new MSSQL.Field(this, "HandleResult", "HandleResult", SqlDbType.SmallInt, false);
                this.HandlelDateTime = new MSSQL.Field(this, "HandlelDateTime", "HandlelDateTime", SqlDbType.DateTime, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Url = new MSSQL.Field(this, "Url", "Url", SqlDbType.VarChar, false);
                this.LogoUrl = new MSSQL.Field(this, "LogoUrl", "LogoUrl", SqlDbType.VarChar, false);
                this.Company = new MSSQL.Field(this, "Company", "Company", SqlDbType.VarChar, false);
                this.Address = new MSSQL.Field(this, "Address", "Address", SqlDbType.VarChar, false);
                this.PostCode = new MSSQL.Field(this, "PostCode", "PostCode", SqlDbType.VarChar, false);
                this.ResponsiblePerson = new MSSQL.Field(this, "ResponsiblePerson", "ResponsiblePerson", SqlDbType.VarChar, false);
                this.ContactPerson = new MSSQL.Field(this, "ContactPerson", "ContactPerson", SqlDbType.VarChar, false);
                this.Telephone = new MSSQL.Field(this, "Telephone", "Telephone", SqlDbType.VarChar, false);
                this.Fax = new MSSQL.Field(this, "Fax", "Fax", SqlDbType.VarChar, false);
                this.Mobile = new MSSQL.Field(this, "Mobile", "Mobile", SqlDbType.VarChar, false);
                this.Email = new MSSQL.Field(this, "Email", "Email", SqlDbType.VarChar, false);
                this.QQ = new MSSQL.Field(this, "QQ", "QQ", SqlDbType.VarChar, false);
                this.ServiceTelephone = new MSSQL.Field(this, "ServiceTelephone", "ServiceTelephone", SqlDbType.VarChar, false);
                this.MD5Key = new MSSQL.Field(this, "MD5Key", "MD5Key", SqlDbType.VarChar, false);
                this.Type = new MSSQL.Field(this, "Type", "Type", SqlDbType.SmallInt, false);
                this.DomainName = new MSSQL.Field(this, "DomainName", "DomainName", SqlDbType.VarChar, false);
                this.ParentID = new MSSQL.Field(this, "ParentID", "ParentID", SqlDbType.BigInt, false);
                this.BonusScale = new MSSQL.Field(this, "BonusScale", "BonusScale", SqlDbType.Float, false);
                this.CommendID = new MSSQL.Field(this, "CommendID", "CommendID", SqlDbType.BigInt, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_CpsType : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field Name;

            public T_CpsType()
            {
                base.TableName = "T_CpsType";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.SmallInt, true);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
            }
        }

        public class T_CustomFollowSchemes : MSSQL.TableBase
        {
            public MSSQL.Field BuyShareEnd;
            public MSSQL.Field BuyShareStart;
            public MSSQL.Field DateTime;
            public MSSQL.Field FollowSchemeID;
            public MSSQL.Field ID;
            public MSSQL.Field MoneyEnd;
            public MSSQL.Field MoneyStart;
            public MSSQL.Field SiteID;
            public MSSQL.Field Type;
            public MSSQL.Field UserID;

            public T_CustomFollowSchemes()
            {
                base.TableName = "T_CustomFollowSchemes";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.FollowSchemeID = new MSSQL.Field(this, "FollowSchemeID", "FollowSchemeID", SqlDbType.BigInt, false);
                this.MoneyStart = new MSSQL.Field(this, "MoneyStart", "MoneyStart", SqlDbType.Money, false);
                this.MoneyEnd = new MSSQL.Field(this, "MoneyEnd", "MoneyEnd", SqlDbType.Money, false);
                this.BuyShareStart = new MSSQL.Field(this, "BuyShareStart", "BuyShareStart", SqlDbType.Int, false);
                this.BuyShareEnd = new MSSQL.Field(this, "BuyShareEnd", "BuyShareEnd", SqlDbType.Int, false);
                this.Type = new MSSQL.Field(this, "Type", "Type", SqlDbType.SmallInt, false);
            }
        }

        public class T_CustomFriendFollowSchemes : MSSQL.TableBase
        {
            public MSSQL.Field BuyShareEnd;
            public MSSQL.Field BuyShareStart;
            public MSSQL.Field DateTime;
            public MSSQL.Field FollowUserID;
            public MSSQL.Field ID;
            public MSSQL.Field LotteryID;
            public MSSQL.Field MoneyEnd;
            public MSSQL.Field MoneyStart;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field SiteID;
            public MSSQL.Field Type;
            public MSSQL.Field UserID;

            public T_CustomFriendFollowSchemes()
            {
                base.TableName = "T_CustomFriendFollowSchemes";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.FollowUserID = new MSSQL.Field(this, "FollowUserID", "FollowUserID", SqlDbType.BigInt, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.MoneyStart = new MSSQL.Field(this, "MoneyStart", "MoneyStart", SqlDbType.Money, false);
                this.MoneyEnd = new MSSQL.Field(this, "MoneyEnd", "MoneyEnd", SqlDbType.Money, false);
                this.BuyShareStart = new MSSQL.Field(this, "BuyShareStart", "BuyShareStart", SqlDbType.Int, false);
                this.BuyShareEnd = new MSSQL.Field(this, "BuyShareEnd", "BuyShareEnd", SqlDbType.Int, false);
                this.Type = new MSSQL.Field(this, "Type", "Type", SqlDbType.SmallInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
            }
        }

        public class T_Downloads : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field FileUrl;
            public MSSQL.Field ID;
            public MSSQL.Field isShow;
            public MSSQL.Field SiteID;
            public MSSQL.Field Title;

            public T_Downloads()
            {
                base.TableName = "T_Downloads";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.FileUrl = new MSSQL.Field(this, "FileUrl", "FileUrl", SqlDbType.VarChar, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
            }
        }

        public class T_ElectronTicketAgentDetails : MSSQL.TableBase
        {
            public MSSQL.Field AgentID;
            public MSSQL.Field Amount;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field Memo;
            public MSSQL.Field OperatorType;

            public T_ElectronTicketAgentDetails()
            {
                base.TableName = "T_ElectronTicketAgentDetails";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.AgentID = new MSSQL.Field(this, "AgentID", "AgentID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.OperatorType = new MSSQL.Field(this, "OperatorType", "OperatorType", SqlDbType.SmallInt, false);
                this.Amount = new MSSQL.Field(this, "Amount", "Amount", SqlDbType.Money, false);
                this.Memo = new MSSQL.Field(this, "Memo", "Memo", SqlDbType.VarChar, false);
            }
        }

        public class T_ElectronTicketAgents : MSSQL.TableBase
        {
            public MSSQL.Field Balance;
            public MSSQL.Field Company;
            public MSSQL.Field ID;
            public MSSQL.Field IPAddressLimit;
            public MSSQL.Field Key;
            public MSSQL.Field Name;
            public MSSQL.Field Password;
            public MSSQL.Field State;
            public MSSQL.Field Url;
            public MSSQL.Field UseLotteryList;

            public T_ElectronTicketAgents()
            {
                base.TableName = "T_ElectronTicketAgents";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Key = new MSSQL.Field(this, "Key", "Key", SqlDbType.VarChar, false);
                this.Password = new MSSQL.Field(this, "Password", "Password", SqlDbType.VarChar, false);
                this.Company = new MSSQL.Field(this, "Company", "Company", SqlDbType.VarChar, false);
                this.Url = new MSSQL.Field(this, "Url", "Url", SqlDbType.VarChar, false);
                this.Balance = new MSSQL.Field(this, "Balance", "Balance", SqlDbType.Money, false);
                this.State = new MSSQL.Field(this, "State", "State", SqlDbType.SmallInt, false);
                this.UseLotteryList = new MSSQL.Field(this, "UseLotteryList", "UseLotteryList", SqlDbType.VarChar, false);
                this.IPAddressLimit = new MSSQL.Field(this, "IPAddressLimit", "IPAddressLimit", SqlDbType.VarChar, false);
            }
        }

        public class T_ElectronTicketAgentSchemeDetails : MSSQL.TableBase
        {
            public MSSQL.Field AlipayName;
            public MSSQL.Field Amount;
            public MSSQL.Field Email;
            public MSSQL.Field ID;
            public MSSQL.Field IDCard;
            public MSSQL.Field Mobile;
            public MSSQL.Field Name;
            public MSSQL.Field RealityName;
            public MSSQL.Field SchemeID;
            public MSSQL.Field Share;
            public MSSQL.Field Telephone;

            public T_ElectronTicketAgentSchemeDetails()
            {
                base.TableName = "T_ElectronTicketAgentSchemeDetails";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.AlipayName = new MSSQL.Field(this, "AlipayName", "AlipayName", SqlDbType.VarChar, false);
                this.RealityName = new MSSQL.Field(this, "RealityName", "RealityName", SqlDbType.VarChar, false);
                this.IDCard = new MSSQL.Field(this, "IDCard", "IDCard", SqlDbType.VarChar, false);
                this.Telephone = new MSSQL.Field(this, "Telephone", "Telephone", SqlDbType.VarChar, false);
                this.Mobile = new MSSQL.Field(this, "Mobile", "Mobile", SqlDbType.VarChar, false);
                this.Email = new MSSQL.Field(this, "Email", "Email", SqlDbType.VarChar, false);
                this.Share = new MSSQL.Field(this, "Share", "Share", SqlDbType.Int, false);
                this.Amount = new MSSQL.Field(this, "Amount", "Amount", SqlDbType.Money, false);
            }
        }

        public class T_ElectronTicketAgentSchemes : MSSQL.TableBase
        {
            public MSSQL.Field AgentID;
            public MSSQL.Field Amount;
            public MSSQL.Field BettingDescription;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field Identifiers;
            public MSSQL.Field InitiateAlipayID;
            public MSSQL.Field InitiateAlipayName;
            public MSSQL.Field InitiateBonusLimitLower;
            public MSSQL.Field InitiateBonusLimitUpper;
            public MSSQL.Field InitiateBonusScale;
            public MSSQL.Field InitiateEmail;
            public MSSQL.Field InitiateIDCard;
            public MSSQL.Field InitiateMobile;
            public MSSQL.Field InitiateName;
            public MSSQL.Field InitiateRealityName;
            public MSSQL.Field InitiateTelephone;
            public MSSQL.Field IsuseID;
            public MSSQL.Field LotteryID;
            public MSSQL.Field LotteryNumber;
            public MSSQL.Field Multiple;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field SchemeNumber;
            public MSSQL.Field Share;
            public MSSQL.Field State;
            public MSSQL.Field WinDescription;
            public MSSQL.Field WinMoney;
            public MSSQL.Field WinMoneyWithoutTax;
            public MSSQL.Field WriteOff;

            public T_ElectronTicketAgentSchemes()
            {
                base.TableName = "T_ElectronTicketAgentSchemes";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.AgentID = new MSSQL.Field(this, "AgentID", "AgentID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.SchemeNumber = new MSSQL.Field(this, "SchemeNumber", "SchemeNumber", SqlDbType.VarChar, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.Amount = new MSSQL.Field(this, "Amount", "Amount", SqlDbType.Money, false);
                this.Multiple = new MSSQL.Field(this, "Multiple", "Multiple", SqlDbType.Int, false);
                this.Share = new MSSQL.Field(this, "Share", "Share", SqlDbType.Int, false);
                this.InitiateName = new MSSQL.Field(this, "InitiateName", "InitiateName", SqlDbType.VarChar, false);
                this.InitiateAlipayName = new MSSQL.Field(this, "InitiateAlipayName", "InitiateAlipayName", SqlDbType.VarChar, false);
                this.InitiateAlipayID = new MSSQL.Field(this, "InitiateAlipayID", "InitiateAlipayID", SqlDbType.VarChar, false);
                this.InitiateRealityName = new MSSQL.Field(this, "InitiateRealityName", "InitiateRealityName", SqlDbType.VarChar, false);
                this.InitiateIDCard = new MSSQL.Field(this, "InitiateIDCard", "InitiateIDCard", SqlDbType.VarChar, false);
                this.InitiateTelephone = new MSSQL.Field(this, "InitiateTelephone", "InitiateTelephone", SqlDbType.VarChar, false);
                this.InitiateMobile = new MSSQL.Field(this, "InitiateMobile", "InitiateMobile", SqlDbType.VarChar, false);
                this.InitiateEmail = new MSSQL.Field(this, "InitiateEmail", "InitiateEmail", SqlDbType.VarChar, false);
                this.InitiateBonusScale = new MSSQL.Field(this, "InitiateBonusScale", "InitiateBonusScale", SqlDbType.Float, false);
                this.InitiateBonusLimitLower = new MSSQL.Field(this, "InitiateBonusLimitLower", "InitiateBonusLimitLower", SqlDbType.Money, false);
                this.InitiateBonusLimitUpper = new MSSQL.Field(this, "InitiateBonusLimitUpper", "InitiateBonusLimitUpper", SqlDbType.Money, false);
                this.State = new MSSQL.Field(this, "State", "State", SqlDbType.SmallInt, false);
                this.BettingDescription = new MSSQL.Field(this, "BettingDescription", "BettingDescription", SqlDbType.VarChar, false);
                this.WinMoney = new MSSQL.Field(this, "WinMoney", "WinMoney", SqlDbType.Money, false);
                this.WinMoneyWithoutTax = new MSSQL.Field(this, "WinMoneyWithoutTax", "WinMoneyWithoutTax", SqlDbType.Money, false);
                this.WinDescription = new MSSQL.Field(this, "WinDescription", "WinDescription", SqlDbType.VarChar, false);
                this.Identifiers = new MSSQL.Field(this, "Identifiers", "Identifiers", SqlDbType.VarChar, false);
                this.WriteOff = new MSSQL.Field(this, "WriteOff", "WriteOff", SqlDbType.Bit, false);
                this.LotteryNumber = new MSSQL.Field(this, "LotteryNumber", "LotteryNumber", SqlDbType.VarChar, false);
            }
        }

        public class T_ElectronTicketAgentSchemesElectronTickets : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field HandleDateTime;
            public MSSQL.Field HandleDescription;
            public MSSQL.Field HandleResult;
            public MSSQL.Field ID;
            public MSSQL.Field Identifiers;
            public MSSQL.Field Money;
            public MSSQL.Field Multiple;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field SchemeID;
            public MSSQL.Field Sends;
            public MSSQL.Field Ticket;

            public T_ElectronTicketAgentSchemesElectronTickets()
            {
                base.TableName = "T_ElectronTicketAgentSchemesElectronTickets";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.Multiple = new MSSQL.Field(this, "Multiple", "Multiple", SqlDbType.Int, false);
                this.Sends = new MSSQL.Field(this, "Sends", "Sends", SqlDbType.SmallInt, false);
                this.HandleDateTime = new MSSQL.Field(this, "HandleDateTime", "HandleDateTime", SqlDbType.DateTime, false);
                this.HandleResult = new MSSQL.Field(this, "HandleResult", "HandleResult", SqlDbType.SmallInt, false);
                this.HandleDescription = new MSSQL.Field(this, "HandleDescription", "HandleDescription", SqlDbType.VarChar, false);
                this.Identifiers = new MSSQL.Field(this, "Identifiers", "Identifiers", SqlDbType.VarChar, false);
                this.Ticket = new MSSQL.Field(this, "Ticket", "Ticket", SqlDbType.VarChar, false);
            }
        }

        public class T_ElectronTicketAgentSchemesNumber : MSSQL.TableBase
        {
            public MSSQL.Field AgendID;
            public MSSQL.Field SchemeNumber;

            public T_ElectronTicketAgentSchemesNumber()
            {
                base.TableName = "T_ElectronTicketAgentSchemesNumber";
                this.AgendID = new MSSQL.Field(this, "AgendID", "AgendID", SqlDbType.BigInt, false);
                this.SchemeNumber = new MSSQL.Field(this, "SchemeNumber", "SchemeNumber", SqlDbType.VarChar, false);
            }
        }

        public class T_ElectronTicketAgentSchemesSendToCenter : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field HandleDateTime;
            public MSSQL.Field HandleDescription;
            public MSSQL.Field HandleResult;
            public MSSQL.Field ID;
            public MSSQL.Field Identifiers;
            public MSSQL.Field Money;
            public MSSQL.Field Multiple;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field SchemeID;
            public MSSQL.Field Sends;
            public MSSQL.Field Ticket;

            public T_ElectronTicketAgentSchemesSendToCenter()
            {
                base.TableName = "T_ElectronTicketAgentSchemesSendToCenter";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.Multiple = new MSSQL.Field(this, "Multiple", "Multiple", SqlDbType.Int, false);
                this.Sends = new MSSQL.Field(this, "Sends", "Sends", SqlDbType.SmallInt, false);
                this.HandleDateTime = new MSSQL.Field(this, "HandleDateTime", "HandleDateTime", SqlDbType.DateTime, false);
                this.HandleResult = new MSSQL.Field(this, "HandleResult", "HandleResult", SqlDbType.SmallInt, false);
                this.HandleDescription = new MSSQL.Field(this, "HandleDescription", "HandleDescription", SqlDbType.VarChar, false);
                this.Identifiers = new MSSQL.Field(this, "Identifiers", "Identifiers", SqlDbType.VarChar, false);
                this.Ticket = new MSSQL.Field(this, "Ticket", "Ticket", SqlDbType.VarChar, false);
            }
        }

        public class T_ElectronTicketLog : MSSQL.TableBase
        {
            public MSSQL.Field datetime;
            public MSSQL.Field id;
            public MSSQL.Field Send;
            public MSSQL.Field TransMessage;
            public MSSQL.Field TransType;

            public T_ElectronTicketLog()
            {
                base.TableName = "T_ElectronTicketLog";
                this.id = new MSSQL.Field(this, "id", "id", SqlDbType.BigInt, true);
                this.TransType = new MSSQL.Field(this, "TransType", "TransType", SqlDbType.VarChar, false);
                this.datetime = new MSSQL.Field(this, "datetime", "datetime", SqlDbType.DateTime, false);
                this.Send = new MSSQL.Field(this, "Send", "Send", SqlDbType.Bit, false);
                this.TransMessage = new MSSQL.Field(this, "TransMessage", "TransMessage", SqlDbType.VarChar, false);
            }
        }

        public class T_ExecutedChases : MSSQL.TableBase
        {
            public MSSQL.Field ChaseID;
            public MSSQL.Field SchemeID;

            public T_ExecutedChases()
            {
                base.TableName = "T_ExecutedChases";
                this.ChaseID = new MSSQL.Field(this, "ChaseID", "ChaseID", SqlDbType.BigInt, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
            }
        }

        public class T_Experts : MSSQL.TableBase
        {
            public MSSQL.Field BonusScale;
            public MSSQL.Field DateTime;
            public MSSQL.Field Description;
            public MSSQL.Field ID;
            public MSSQL.Field isCanIssued;
            public MSSQL.Field isCommend;
            public MSSQL.Field LotteryID;
            public MSSQL.Field MaxPrice;
            public MSSQL.Field ON;
            public MSSQL.Field ReadCount;
            public MSSQL.Field SiteID;
            public MSSQL.Field UserID;

            public T_Experts()
            {
                base.TableName = "T_Experts";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.isCanIssued = new MSSQL.Field(this, "isCanIssued", "isCanIssued", SqlDbType.Bit, false);
                this.MaxPrice = new MSSQL.Field(this, "MaxPrice", "MaxPrice", SqlDbType.Money, false);
                this.BonusScale = new MSSQL.Field(this, "BonusScale", "BonusScale", SqlDbType.Float, false);
                this.ON = new MSSQL.Field(this, "ON", "ON", SqlDbType.Bit, false);
                this.ReadCount = new MSSQL.Field(this, "ReadCount", "ReadCount", SqlDbType.Int, false);
                this.isCommend = new MSSQL.Field(this, "isCommend", "isCommend", SqlDbType.Bit, false);
            }
        }

        public class T_ExpertsCommendRead : MSSQL.TableBase
        {
            public MSSQL.Field ExpertsCommendID;
            public MSSQL.Field ID;
            public MSSQL.Field SiteID;
            public MSSQL.Field UserID;

            public T_ExpertsCommendRead()
            {
                base.TableName = "T_ExpertsCommendRead";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.ExpertsCommendID = new MSSQL.Field(this, "ExpertsCommendID", "ExpertsCommendID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
            }
        }

        public class T_ExpertsCommends : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field ExpertsID;
            public MSSQL.Field ID;
            public MSSQL.Field isCommend;
            public MSSQL.Field IsuseID;
            public MSSQL.Field Number;
            public MSSQL.Field Price;
            public MSSQL.Field ReadCount;
            public MSSQL.Field SiteID;
            public MSSQL.Field Title;
            public MSSQL.Field WinMoney;

            public T_ExpertsCommends()
            {
                base.TableName = "T_ExpertsCommends";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.ExpertsID = new MSSQL.Field(this, "ExpertsID", "ExpertsID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.Price = new MSSQL.Field(this, "Price", "Price", SqlDbType.Money, false);
                this.ReadCount = new MSSQL.Field(this, "ReadCount", "ReadCount", SqlDbType.Int, false);
                this.WinMoney = new MSSQL.Field(this, "WinMoney", "WinMoney", SqlDbType.Money, false);
                this.isCommend = new MSSQL.Field(this, "isCommend", "isCommend", SqlDbType.Bit, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
                this.Number = new MSSQL.Field(this, "Number", "Number", SqlDbType.VarChar, false);
            }
        }

        public class T_ExpertsPredict : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field Description;
            public MSSQL.Field ID;
            public MSSQL.Field LotteryID;
            public MSSQL.Field Name;
            public MSSQL.Field ON;
            public MSSQL.Field URL;

            public T_ExpertsPredict()
            {
                base.TableName = "T_ExpertsPredict";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.ON = new MSSQL.Field(this, "ON", "ON", SqlDbType.Bit, false);
                this.URL = new MSSQL.Field(this, "URL", "URL", SqlDbType.VarChar, false);
            }
        }

        public class T_ExpertsPredictCommends : MSSQL.TableBase
        {
            public MSSQL.Field CommendID;
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field ExpertsPredictID;
            public MSSQL.Field ID;
            public MSSQL.Field IsShow;

            public T_ExpertsPredictCommends()
            {
                base.TableName = "T_ExpertsPredictCommends";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.ExpertsPredictID = new MSSQL.Field(this, "ExpertsPredictID", "ExpertsPredictID", SqlDbType.Int, false);
                this.CommendID = new MSSQL.Field(this, "CommendID", "CommendID", SqlDbType.BigInt, false);
                this.IsShow = new MSSQL.Field(this, "IsShow", "IsShow", SqlDbType.Bit, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
            }
        }

        public class T_ExpertsPredictNews : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field Description;
            public MSSQL.Field ExpertsPredictID;
            public MSSQL.Field ID;
            public MSSQL.Field isWinning;
            public MSSQL.Field ON;
            public MSSQL.Field URL;

            public T_ExpertsPredictNews()
            {
                base.TableName = "T_ExpertsPredictNews";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.ExpertsPredictID = new MSSQL.Field(this, "ExpertsPredictID", "ExpertsPredictID", SqlDbType.Int, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.ON = new MSSQL.Field(this, "ON", "ON", SqlDbType.Bit, false);
                this.URL = new MSSQL.Field(this, "URL", "URL", SqlDbType.VarChar, false);
                this.isWinning = new MSSQL.Field(this, "isWinning", "isWinning", SqlDbType.Bit, false);
            }
        }

        public class T_ExpertsTrys : MSSQL.TableBase
        {
            public MSSQL.Field BonusScale;
            public MSSQL.Field DateTime;
            public MSSQL.Field Description;
            public MSSQL.Field HandleDateTime;
            public MSSQL.Field HandleResult;
            public MSSQL.Field ID;
            public MSSQL.Field LotteryID;
            public MSSQL.Field MaxPrice;
            public MSSQL.Field SiteID;
            public MSSQL.Field UserID;

            public T_ExpertsTrys()
            {
                base.TableName = "T_ExpertsTrys";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.MaxPrice = new MSSQL.Field(this, "MaxPrice", "MaxPrice", SqlDbType.Money, false);
                this.BonusScale = new MSSQL.Field(this, "BonusScale", "BonusScale", SqlDbType.Float, false);
                this.HandleResult = new MSSQL.Field(this, "HandleResult", "HandleResult", SqlDbType.SmallInt, false);
                this.HandleDateTime = new MSSQL.Field(this, "HandleDateTime", "HandleDateTime", SqlDbType.DateTime, false);
            }
        }

        public class T_ExpertsWinCommends : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field isCommend;
            public MSSQL.Field isShow;
            public MSSQL.Field IsuseID;
            public MSSQL.Field ON;
            public MSSQL.Field ReadCount;
            public MSSQL.Field SiteID;
            public MSSQL.Field Title;
            public MSSQL.Field UserID;

            public T_ExpertsWinCommends()
            {
                base.TableName = "T_ExpertsWinCommends";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
                this.ON = new MSSQL.Field(this, "ON", "ON", SqlDbType.Bit, false);
                this.ReadCount = new MSSQL.Field(this, "ReadCount", "ReadCount", SqlDbType.Int, false);
                this.isCommend = new MSSQL.Field(this, "isCommend", "isCommend", SqlDbType.Bit, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_FloatNotify : MSSQL.TableBase
        {
            public MSSQL.Field Color;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field isShow;
            public MSSQL.Field Order;
            public MSSQL.Field Title;
            public MSSQL.Field Url;

            public T_FloatNotify()
            {
                base.TableName = "T_FloatNotify";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.Color = new MSSQL.Field(this, "Color", "Color", SqlDbType.VarChar, false);
                this.Url = new MSSQL.Field(this, "Url", "Url", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.Int, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
            }
        }

        public class T_FocusImageNews : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field ImageUrl;
            public MSSQL.Field IsBig;
            public MSSQL.Field Title;
            public MSSQL.Field Url;

            public T_FocusImageNews()
            {
                base.TableName = "T_FocusImageNews";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.ImageUrl = new MSSQL.Field(this, "ImageUrl", "ImageUrl", SqlDbType.VarChar, false);
                this.Url = new MSSQL.Field(this, "Url", "Url", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.IsBig = new MSSQL.Field(this, "IsBig", "IsBig", SqlDbType.Bit, false);
            }
        }

        public class T_FocusNews : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field IsMaster;
            public MSSQL.Field Order;
            public MSSQL.Field Title;
            public MSSQL.Field Url;

            public T_FocusNews()
            {
                base.TableName = "T_FocusNews";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.Url = new MSSQL.Field(this, "Url", "Url", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.IsMaster = new MSSQL.Field(this, "IsMaster", "IsMaster", SqlDbType.Bit, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.SmallInt, false);
            }
        }

        public class T_FootballLeagueTypes : MSSQL.TableBase
        {
            public MSSQL.Field Code;
            public MSSQL.Field Description;
            public MSSQL.Field ID;
            public MSSQL.Field isUse;
            public MSSQL.Field MarkersColor;
            public MSSQL.Field Name;
            public MSSQL.Field Order;

            public T_FootballLeagueTypes()
            {
                base.TableName = "T_FootballLeagueTypes";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Code = new MSSQL.Field(this, "Code", "Code", SqlDbType.VarChar, false);
                this.MarkersColor = new MSSQL.Field(this, "MarkersColor", "MarkersColor", SqlDbType.VarChar, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.Int, false);
                this.isUse = new MSSQL.Field(this, "isUse", "isUse", SqlDbType.Bit, false);
            }
        }

        public class T_FriendshipLinks : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field isShow;
            public MSSQL.Field LinkName;
            public MSSQL.Field LogoUrl;
            public MSSQL.Field Order;
            public MSSQL.Field SiteID;
            public MSSQL.Field Url;

            public T_FriendshipLinks()
            {
                base.TableName = "T_FriendshipLinks";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.LinkName = new MSSQL.Field(this, "LinkName", "LinkName", SqlDbType.VarChar, false);
                this.LogoUrl = new MSSQL.Field(this, "LogoUrl", "LogoUrl", SqlDbType.VarChar, false);
                this.Url = new MSSQL.Field(this, "Url", "Url", SqlDbType.VarChar, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.Int, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
            }
        }

        public class T_Helps : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field ID;
            public MSSQL.Field Title;

            public T_Helps()
            {
                base.TableName = "T_Helps";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_IPAddress : MSSQL.TableBase
        {
            public MSSQL.Field City;
            public MSSQL.Field Country;
            public MSSQL.Field IPEnd;
            public MSSQL.Field IPStart;

            public T_IPAddress()
            {
                base.TableName = "T_IPAddress";
                this.IPStart = new MSSQL.Field(this, "IPStart", "IPStart", SqlDbType.Float, false);
                this.IPEnd = new MSSQL.Field(this, "IPEnd", "IPEnd", SqlDbType.Float, false);
                this.Country = new MSSQL.Field(this, "Country", "Country", SqlDbType.NVarChar, false);
                this.City = new MSSQL.Field(this, "City", "City", SqlDbType.NVarChar, false);
            }
        }

        public class T_IsShowedCustomFollowSchemesForIcaile : MSSQL.TableBase
        {
            public MSSQL.Field ID;

            public T_IsShowedCustomFollowSchemesForIcaile()
            {
                base.TableName = "T_IsShowedCustomFollowSchemesForIcaile";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, false);
            }
        }

        public class T_IsuseBonuses : MSSQL.TableBase
        {
            public MSSQL.Field defaultMoney;
            public MSSQL.Field DefaultMoneyNoWithTax;
            public MSSQL.Field ID;
            public MSSQL.Field IsuseID;
            public MSSQL.Field UserID;

            public T_IsuseBonuses()
            {
                base.TableName = "T_IsuseBonuses";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.defaultMoney = new MSSQL.Field(this, "defaultMoney", "defaultMoney", SqlDbType.Money, false);
                this.DefaultMoneyNoWithTax = new MSSQL.Field(this, "DefaultMoneyNoWithTax", "DefaultMoneyNoWithTax", SqlDbType.Money, false);
            }
        }

        public class T_IsuseForJQC : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field IsuseID;
            public MSSQL.Field No;
            public MSSQL.Field Team;

            public T_IsuseForJQC()
            {
                base.TableName = "T_IsuseForJQC";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.No = new MSSQL.Field(this, "No", "No", SqlDbType.SmallInt, false);
                this.Team = new MSSQL.Field(this, "Team", "Team", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.VarChar, false);
            }
        }

        public class T_IsuseForLCBQC : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field HostTeam;
            public MSSQL.Field ID;
            public MSSQL.Field IsuseID;
            public MSSQL.Field No;
            public MSSQL.Field QuestTeam;

            public T_IsuseForLCBQC()
            {
                base.TableName = "T_IsuseForLCBQC";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.No = new MSSQL.Field(this, "No", "No", SqlDbType.SmallInt, false);
                this.HostTeam = new MSSQL.Field(this, "HostTeam", "HostTeam", SqlDbType.VarChar, false);
                this.QuestTeam = new MSSQL.Field(this, "QuestTeam", "QuestTeam", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.VarChar, false);
            }
        }

        public class T_IsuseForLCDC : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field HostTeam;
            public MSSQL.Field ID;
            public MSSQL.Field IsuseID;
            public MSSQL.Field No;
            public MSSQL.Field QuestTeam;

            public T_IsuseForLCDC()
            {
                base.TableName = "T_IsuseForLCDC";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.No = new MSSQL.Field(this, "No", "No", SqlDbType.SmallInt, false);
                this.HostTeam = new MSSQL.Field(this, "HostTeam", "HostTeam", SqlDbType.VarChar, false);
                this.QuestTeam = new MSSQL.Field(this, "QuestTeam", "QuestTeam", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.VarChar, false);
            }
        }

        public class T_IsuseForSFC : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field HostTeam;
            public MSSQL.Field ID;
            public MSSQL.Field IsuseID;
            public MSSQL.Field No;
            public MSSQL.Field QuestTeam;

            public T_IsuseForSFC()
            {
                base.TableName = "T_IsuseForSFC";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.No = new MSSQL.Field(this, "No", "No", SqlDbType.SmallInt, false);
                this.HostTeam = new MSSQL.Field(this, "HostTeam", "HostTeam", SqlDbType.VarChar, false);
                this.QuestTeam = new MSSQL.Field(this, "QuestTeam", "QuestTeam", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.VarChar, false);
            }
        }

        public class T_IsuseForZCDC : MSSQL.TableBase
        {
            public MSSQL.Field AnalysisURL;
            public MSSQL.Field BQCSPF_SP;
            public MSSQL.Field BQCSPFResult;
            public MSSQL.Field DateTime;
            public MSSQL.Field HalftimeResult;
            public MSSQL.Field HostTeam;
            public MSSQL.Field ID;
            public MSSQL.Field IsuseID;
            public MSSQL.Field LeagueTypeID;
            public MSSQL.Field LetBall;
            public MSSQL.Field No;
            public MSSQL.Field QuestTeam;
            public MSSQL.Field Result;
            public MSSQL.Field SPF_SP;
            public MSSQL.Field SPFResult;
            public MSSQL.Field SXDS_SP;
            public MSSQL.Field SXDSResult;
            public MSSQL.Field ZJQ_SP;
            public MSSQL.Field ZJQResult;
            public MSSQL.Field ZQBF_SP;
            public MSSQL.Field ZQBFResult;

            public T_IsuseForZCDC()
            {
                base.TableName = "T_IsuseForZCDC";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.LeagueTypeID = new MSSQL.Field(this, "LeagueTypeID", "LeagueTypeID", SqlDbType.Int, false);
                this.No = new MSSQL.Field(this, "No", "No", SqlDbType.SmallInt, false);
                this.HostTeam = new MSSQL.Field(this, "HostTeam", "HostTeam", SqlDbType.VarChar, false);
                this.QuestTeam = new MSSQL.Field(this, "QuestTeam", "QuestTeam", SqlDbType.VarChar, false);
                this.LetBall = new MSSQL.Field(this, "LetBall", "LetBall", SqlDbType.SmallInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.VarChar, false);
                this.HalftimeResult = new MSSQL.Field(this, "HalftimeResult", "HalftimeResult", SqlDbType.VarChar, false);
                this.Result = new MSSQL.Field(this, "Result", "Result", SqlDbType.VarChar, false);
                this.SPFResult = new MSSQL.Field(this, "SPFResult", "SPFResult", SqlDbType.VarChar, false);
                this.SPF_SP = new MSSQL.Field(this, "SPF_SP", "SPF_SP", SqlDbType.Float, false);
                this.ZJQResult = new MSSQL.Field(this, "ZJQResult", "ZJQResult", SqlDbType.VarChar, false);
                this.ZJQ_SP = new MSSQL.Field(this, "ZJQ_SP", "ZJQ_SP", SqlDbType.Float, false);
                this.SXDSResult = new MSSQL.Field(this, "SXDSResult", "SXDSResult", SqlDbType.VarChar, false);
                this.SXDS_SP = new MSSQL.Field(this, "SXDS_SP", "SXDS_SP", SqlDbType.Float, false);
                this.ZQBFResult = new MSSQL.Field(this, "ZQBFResult", "ZQBFResult", SqlDbType.VarChar, false);
                this.ZQBF_SP = new MSSQL.Field(this, "ZQBF_SP", "ZQBF_SP", SqlDbType.Float, false);
                this.BQCSPFResult = new MSSQL.Field(this, "BQCSPFResult", "BQCSPFResult", SqlDbType.VarChar, false);
                this.BQCSPF_SP = new MSSQL.Field(this, "BQCSPF_SP", "BQCSPF_SP", SqlDbType.Float, false);
                this.AnalysisURL = new MSSQL.Field(this, "AnalysisURL", "AnalysisURL", SqlDbType.VarChar, false);
            }
        }

        public class T_Isuses : MSSQL.TableBase
        {
            public MSSQL.Field ChaseExecuted;
            public MSSQL.Field EndTime;
            public MSSQL.Field ID;
            public MSSQL.Field IsOpened;
            public MSSQL.Field LotteryID;
            public MSSQL.Field Name;
            public MSSQL.Field OpenAffiche;
            public MSSQL.Field OpenOperatorID;
            public MSSQL.Field StartTime;
            public MSSQL.Field State;
            public MSSQL.Field StateUpdateTime;
            public MSSQL.Field WinLotteryNumber;

            public T_Isuses()
            {
                base.TableName = "T_Isuses";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.StartTime = new MSSQL.Field(this, "StartTime", "StartTime", SqlDbType.DateTime, false);
                this.EndTime = new MSSQL.Field(this, "EndTime", "EndTime", SqlDbType.DateTime, false);
                this.ChaseExecuted = new MSSQL.Field(this, "ChaseExecuted", "ChaseExecuted", SqlDbType.Bit, false);
                this.IsOpened = new MSSQL.Field(this, "IsOpened", "IsOpened", SqlDbType.Bit, false);
                this.WinLotteryNumber = new MSSQL.Field(this, "WinLotteryNumber", "WinLotteryNumber", SqlDbType.VarChar, false);
                this.OpenOperatorID = new MSSQL.Field(this, "OpenOperatorID", "OpenOperatorID", SqlDbType.BigInt, false);
                this.State = new MSSQL.Field(this, "State", "State", SqlDbType.SmallInt, false);
                this.StateUpdateTime = new MSSQL.Field(this, "StateUpdateTime", "StateUpdateTime", SqlDbType.DateTime, false);
                this.OpenAffiche = new MSSQL.Field(this, "OpenAffiche", "OpenAffiche", SqlDbType.VarChar, false);
            }
        }

        public class T_Lotteries : MSSQL.TableBase
        {
            public MSSQL.Field Agreement;
            public MSSQL.Field ChaseExecuteDeferMinute;
            public MSSQL.Field Code;
            public MSSQL.Field Explain;
            public MSSQL.Field ID;
            public MSSQL.Field IntervalType;
            public MSSQL.Field MaxChaseIsuse;
            public MSSQL.Field Name;
            public MSSQL.Field OpenAfficheTemplate;
            public MSSQL.Field Order;
            public MSSQL.Field PrintOutType;
            public MSSQL.Field QuashExecuteDeferMinute;
            public MSSQL.Field SchemeExemple;
            public MSSQL.Field Type2;
            public MSSQL.Field TypeID;
            public MSSQL.Field WinNumberExemple;

            public T_Lotteries()
            {
                base.TableName = "T_Lotteries";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Code = new MSSQL.Field(this, "Code", "Code", SqlDbType.VarChar, false);
                this.MaxChaseIsuse = new MSSQL.Field(this, "MaxChaseIsuse", "MaxChaseIsuse", SqlDbType.VarChar, false);
                this.ChaseExecuteDeferMinute = new MSSQL.Field(this, "ChaseExecuteDeferMinute", "ChaseExecuteDeferMinute", SqlDbType.Int, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.Int, false);
                this.WinNumberExemple = new MSSQL.Field(this, "WinNumberExemple", "WinNumberExemple", SqlDbType.VarChar, false);
                this.IntervalType = new MSSQL.Field(this, "IntervalType", "IntervalType", SqlDbType.VarChar, false);
                this.PrintOutType = new MSSQL.Field(this, "PrintOutType", "PrintOutType", SqlDbType.SmallInt, false);
                this.TypeID = new MSSQL.Field(this, "TypeID", "TypeID", SqlDbType.SmallInt, false);
                this.Type2 = new MSSQL.Field(this, "Type2", "Type2", SqlDbType.SmallInt, false);
                this.Agreement = new MSSQL.Field(this, "Agreement", "Agreement", SqlDbType.VarChar, false);
                this.Explain = new MSSQL.Field(this, "Explain", "Explain", SqlDbType.VarChar, false);
                this.SchemeExemple = new MSSQL.Field(this, "SchemeExemple", "SchemeExemple", SqlDbType.VarChar, false);
                this.OpenAfficheTemplate = new MSSQL.Field(this, "OpenAfficheTemplate", "OpenAfficheTemplate", SqlDbType.VarChar, false);
                this.QuashExecuteDeferMinute = new MSSQL.Field(this, "QuashExecuteDeferMinute", "QuashExecuteDeferMinute", SqlDbType.Int, false);
            }
        }

        public class T_LotteryToolLinks : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field isShow;
            public MSSQL.Field LinkName;
            public MSSQL.Field LogoUrl;
            public MSSQL.Field LotteryID;
            public MSSQL.Field Order;
            public MSSQL.Field SiteID;
            public MSSQL.Field Url;

            public T_LotteryToolLinks()
            {
                base.TableName = "T_LotteryToolLinks";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.LinkName = new MSSQL.Field(this, "LinkName", "LinkName", SqlDbType.VarChar, false);
                this.LogoUrl = new MSSQL.Field(this, "LogoUrl", "LogoUrl", SqlDbType.VarChar, false);
                this.Url = new MSSQL.Field(this, "Url", "Url", SqlDbType.VarChar, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.Int, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
            }
        }

        public class T_LotteryType : MSSQL.TableBase
        {
            public MSSQL.Field Description;
            public MSSQL.Field ID;
            public MSSQL.Field Name;
            public MSSQL.Field Order;
            public MSSQL.Field ParentID;

            public T_LotteryType()
            {
                base.TableName = "T_LotteryType";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.SmallInt, true);
                this.ParentID = new MSSQL.Field(this, "ParentID", "ParentID", SqlDbType.SmallInt, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.SmallInt, false);
            }
        }

        public class T_LuckNumber : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field LotteryID;
            public MSSQL.Field LotteryNumber;
            public MSSQL.Field Name;
            public MSSQL.Field Type;

            public T_LuckNumber()
            {
                base.TableName = "T_LuckNumber";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.Type = new MSSQL.Field(this, "Type", "Type", SqlDbType.SmallInt, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.LotteryNumber = new MSSQL.Field(this, "LotteryNumber", "LotteryNumber", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
            }
        }

        public class T_MarketOutlook : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field isShow;
            public MSSQL.Field Title;

            public T_MarketOutlook()
            {
                base.TableName = "T_MarketOutlook";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_MaxMultiple : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field IsuseID;
            public MSSQL.Field MaxMultiple;
            public MSSQL.Field PlayTypeID;

            public T_MaxMultiple()
            {
                base.TableName = "T_MaxMultiple";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.MaxMultiple = new MSSQL.Field(this, "MaxMultiple", "MaxMultiple", SqlDbType.Int, false);
            }
        }

        public class T_News : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field ImageUrl;
            public MSSQL.Field isCanComments;
            public MSSQL.Field isCommend;
            public MSSQL.Field isHasImage;
            public MSSQL.Field isHot;
            public MSSQL.Field isShow;
            public MSSQL.Field IsusesId;
            public MSSQL.Field ReadCount;
            public MSSQL.Field SiteID;
            public MSSQL.Field Title;
            public MSSQL.Field TypeID;

            public T_News()
            {
                base.TableName = "T_News";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.TypeID = new MSSQL.Field(this, "TypeID", "TypeID", SqlDbType.Int, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.ImageUrl = new MSSQL.Field(this, "ImageUrl", "ImageUrl", SqlDbType.VarChar, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
                this.isHasImage = new MSSQL.Field(this, "isHasImage", "isHasImage", SqlDbType.Bit, false);
                this.isCanComments = new MSSQL.Field(this, "isCanComments", "isCanComments", SqlDbType.Bit, false);
                this.isCommend = new MSSQL.Field(this, "isCommend", "isCommend", SqlDbType.Bit, false);
                this.isHot = new MSSQL.Field(this, "isHot", "isHot", SqlDbType.Bit, false);
                this.ReadCount = new MSSQL.Field(this, "ReadCount", "ReadCount", SqlDbType.BigInt, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
                this.IsusesId = new MSSQL.Field(this, "IsusesId", "IsusesId", SqlDbType.Int, false);
            }
        }

        public class T_NewsComments : MSSQL.TableBase
        {
            public MSSQL.Field CommentserID;
            public MSSQL.Field CommentserName;
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field isShow;
            public MSSQL.Field NewsID;

            public T_NewsComments()
            {
                base.TableName = "T_NewsComments";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.NewsID = new MSSQL.Field(this, "NewsID", "NewsID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.CommentserID = new MSSQL.Field(this, "CommentserID", "CommentserID", SqlDbType.BigInt, false);
                this.CommentserName = new MSSQL.Field(this, "CommentserName", "CommentserName", SqlDbType.VarChar, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_NewsPaperIsuses : MSSQL.TableBase
        {
            public MSSQL.Field EndTime;
            public MSSQL.Field ID;
            public MSSQL.Field Name;
            public MSSQL.Field NPMessage;
            public MSSQL.Field StartTime;

            public T_NewsPaperIsuses()
            {
                base.TableName = "T_NewsPaperIsuses";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.StartTime = new MSSQL.Field(this, "StartTime", "StartTime", SqlDbType.DateTime, false);
                this.EndTime = new MSSQL.Field(this, "EndTime", "EndTime", SqlDbType.DateTime, false);
                this.NPMessage = new MSSQL.Field(this, "NPMessage", "NPMessage", SqlDbType.VarChar, false);
            }
        }

        public class T_NewsPaperTypes : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field isShow;
            public MSSQL.Field isSystem;
            public MSSQL.Field Name;
            public MSSQL.Field ParentID;
            public MSSQL.Field SiteID;

            public T_NewsPaperTypes()
            {
                base.TableName = "T_NewsPaperTypes";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.ParentID = new MSSQL.Field(this, "ParentID", "ParentID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
                this.isSystem = new MSSQL.Field(this, "isSystem", "isSystem", SqlDbType.Bit, false);
            }
        }

        public class T_NewsType : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field isShow;
            public MSSQL.Field isSystem;
            public MSSQL.Field Name;
            public MSSQL.Field ParentID;
            public MSSQL.Field SiteID;

            public T_NewsType()
            {
                base.TableName = "T_NewsType";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.ParentID = new MSSQL.Field(this, "ParentID", "ParentID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
                this.isSystem = new MSSQL.Field(this, "isSystem", "isSystem", SqlDbType.Bit, false);
            }
        }

        public class T_NewsTypes : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field IsShow;
            public MSSQL.Field IsSystem;
            public MSSQL.Field Name;
            public MSSQL.Field ParentID;
            public MSSQL.Field SiteID;

            public T_NewsTypes()
            {
                base.TableName = "T_NewsTypes";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, false);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.ParentID = new MSSQL.Field(this, "ParentID", "ParentID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.IsShow = new MSSQL.Field(this, "IsShow", "IsShow", SqlDbType.Bit, false);
                this.IsSystem = new MSSQL.Field(this, "IsSystem", "IsSystem", SqlDbType.Bit, false);
            }
        }

        public class T_NotificationTypes : MSSQL.TableBase
        {
            public MSSQL.Field Code;
            public MSSQL.Field Description;
            public MSSQL.Field ID;
            public MSSQL.Field Name;
            public MSSQL.Field TemplateEmail;
            public MSSQL.Field TemplateSMS;
            public MSSQL.Field TemplateStationSMS;

            public T_NotificationTypes()
            {
                base.TableName = "T_NotificationTypes";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.SmallInt, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Code = new MSSQL.Field(this, "Code", "Code", SqlDbType.VarChar, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.TemplateEmail = new MSSQL.Field(this, "TemplateEmail", "TemplateEmail", SqlDbType.VarChar, false);
                this.TemplateStationSMS = new MSSQL.Field(this, "TemplateStationSMS", "TemplateStationSMS", SqlDbType.VarChar, false);
                this.TemplateSMS = new MSSQL.Field(this, "TemplateSMS", "TemplateSMS", SqlDbType.VarChar, false);
            }
        }

        public class T_Options : MSSQL.TableBase
        {
            public MSSQL.Field Description;
            public MSSQL.Field ID;
            public MSSQL.Field Key;
            public MSSQL.Field Value;

            public T_Options()
            {
                base.TableName = "T_Options";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.SmallInt, false);
                this.Key = new MSSQL.Field(this, "Key", "Key", SqlDbType.VarChar, false);
                this.Value = new MSSQL.Field(this, "Value", "Value", SqlDbType.VarChar, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
            }
        }

        public class T_Personages : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field IsShow;
            public MSSQL.Field LotteryID;
            public MSSQL.Field Order;
            public MSSQL.Field UserName;

            public T_Personages()
            {
                base.TableName = "T_Personages";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.UserName = new MSSQL.Field(this, "UserName", "UserName", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.Int, false);
                this.IsShow = new MSSQL.Field(this, "IsShow", "IsShow", SqlDbType.Bit, false);
            }
        }

        public class T_PiaoPiaoRules : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field PPCount;
            public MSSQL.Field Scale;
            public MSSQL.Field TimePeriod;
            public MSSQL.Field TimeUnit;
            public MSSQL.Field TypeName;

            public T_PiaoPiaoRules()
            {
                base.TableName = "T_PiaoPiaoRules";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, false);
                this.TypeName = new MSSQL.Field(this, "TypeName", "TypeName", SqlDbType.NVarChar, false);
                this.TimePeriod = new MSSQL.Field(this, "TimePeriod", "TimePeriod", SqlDbType.Int, false);
                this.TimeUnit = new MSSQL.Field(this, "TimeUnit", "TimeUnit", SqlDbType.SmallInt, false);
                this.PPCount = new MSSQL.Field(this, "PPCount", "PPCount", SqlDbType.Int, false);
                this.Scale = new MSSQL.Field(this, "Scale", "Scale", SqlDbType.SmallInt, false);
            }
        }

        public class T_PiaoPiaoToCpsUid : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field LastDateTime;
            public MSSQL.Field TotalPPCount;
            public MSSQL.Field TypeID;
            public MSSQL.Field UID;

            public T_PiaoPiaoToCpsUid()
            {
                base.TableName = "T_PiaoPiaoToCpsUid";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UID = new MSSQL.Field(this, "UID", "UID", SqlDbType.BigInt, false);
                this.TypeID = new MSSQL.Field(this, "TypeID", "TypeID", SqlDbType.Int, false);
                this.LastDateTime = new MSSQL.Field(this, "LastDateTime", "LastDateTime", SqlDbType.SmallDateTime, false);
                this.TotalPPCount = new MSSQL.Field(this, "TotalPPCount", "TotalPPCount", SqlDbType.Int, false);
            }
        }

        public class T_PlayTypes : MSSQL.TableBase
        {
            public MSSQL.Field BuyFileName;
            public MSSQL.Field ID;
            public MSSQL.Field LotteryID;
            public MSSQL.Field MaxFollowSchemeNumberOf;
            public MSSQL.Field MaxMultiple;
            public MSSQL.Field Name;
            public MSSQL.Field Price;
            public MSSQL.Field SystemEndAheadMinute;

            public T_PlayTypes()
            {
                base.TableName = "T_PlayTypes";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.SystemEndAheadMinute = new MSSQL.Field(this, "SystemEndAheadMinute", "SystemEndAheadMinute", SqlDbType.Int, false);
                this.Price = new MSSQL.Field(this, "Price", "Price", SqlDbType.Money, false);
                this.BuyFileName = new MSSQL.Field(this, "BuyFileName", "BuyFileName", SqlDbType.VarChar, false);
                this.MaxFollowSchemeNumberOf = new MSSQL.Field(this, "MaxFollowSchemeNumberOf", "MaxFollowSchemeNumberOf", SqlDbType.Int, false);
                this.MaxMultiple = new MSSQL.Field(this, "MaxMultiple", "MaxMultiple", SqlDbType.Int, false);
            }
        }

        public class T_PoliciesAndRegulations : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field isShow;
            public MSSQL.Field Title;

            public T_PoliciesAndRegulations()
            {
                base.TableName = "T_PoliciesAndRegulations";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_Provinces : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field Name;

            public T_Provinces()
            {
                base.TableName = "T_Provinces";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
            }
        }

        public class T_Questionnaire : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field Options1Content;
            public MSSQL.Field Options1Count;
            public MSSQL.Field Options2Content;
            public MSSQL.Field Options2Count;
            public MSSQL.Field Options3Content;
            public MSSQL.Field Options3Count;
            public MSSQL.Field Options4Content;
            public MSSQL.Field Options4Count;
            public MSSQL.Field Title;

            public T_Questionnaire()
            {
                base.TableName = "T_Questionnaire";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.Options1Content = new MSSQL.Field(this, "Options1Content", "Options1Content", SqlDbType.VarChar, false);
                this.Options2Content = new MSSQL.Field(this, "Options2Content", "Options2Content", SqlDbType.VarChar, false);
                this.Options3Content = new MSSQL.Field(this, "Options3Content", "Options3Content", SqlDbType.VarChar, false);
                this.Options4Content = new MSSQL.Field(this, "Options4Content", "Options4Content", SqlDbType.VarChar, false);
                this.Options1Count = new MSSQL.Field(this, "Options1Count", "Options1Count", SqlDbType.Int, false);
                this.Options2Count = new MSSQL.Field(this, "Options2Count", "Options2Count", SqlDbType.Int, false);
                this.Options3Count = new MSSQL.Field(this, "Options3Count", "Options3Count", SqlDbType.Int, false);
                this.Options4Count = new MSSQL.Field(this, "Options4Count", "Options4Count", SqlDbType.Int, false);
            }
        }

        public class T_QuestionnaireSurveyAnswer : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field IsSystem;
            public MSSQL.Field Name;
            public MSSQL.Field QuestionID;
            public MSSQL.Field SelectCount;

            public T_QuestionnaireSurveyAnswer()
            {
                base.TableName = "T_QuestionnaireSurveyAnswer";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.QuestionID = new MSSQL.Field(this, "QuestionID", "QuestionID", SqlDbType.Int, false);
                this.SelectCount = new MSSQL.Field(this, "SelectCount", "SelectCount", SqlDbType.Int, false);
                this.IsSystem = new MSSQL.Field(this, "IsSystem", "IsSystem", SqlDbType.Bit, false);
            }
        }

        public class T_QuestionnaireSurveyQuestions : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field IsCanSelectMuch;
            public MSSQL.Field IsCustomAnswer;
            public MSSQL.Field Name;

            public T_QuestionnaireSurveyQuestions()
            {
                base.TableName = "T_QuestionnaireSurveyQuestions";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.IsCanSelectMuch = new MSSQL.Field(this, "IsCanSelectMuch", "IsCanSelectMuch", SqlDbType.Bit, false);
                this.IsCustomAnswer = new MSSQL.Field(this, "IsCustomAnswer", "IsCustomAnswer", SqlDbType.Bit, false);
            }
        }

        public class T_QuestionnaireSurveySuggestions : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field Suggestions;

            public T_QuestionnaireSurveySuggestions()
            {
                base.TableName = "T_QuestionnaireSurveySuggestions";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Suggestions = new MSSQL.Field(this, "Suggestions", "Suggestions", SqlDbType.VarChar, false);
            }
        }

        public class T_Questions : MSSQL.TableBase
        {
            public MSSQL.Field Answer;
            public MSSQL.Field AnswerDateTime;
            public MSSQL.Field AnswerOperatorID;
            public MSSQL.Field AnswerStatus;
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field HandleDateTime;
            public MSSQL.Field HandleOperatorID;
            public MSSQL.Field ID;
            public MSSQL.Field SiteID;
            public MSSQL.Field Telephone;
            public MSSQL.Field TypeID;
            public MSSQL.Field UserID;

            public T_Questions()
            {
                base.TableName = "T_Questions";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.TypeID = new MSSQL.Field(this, "TypeID", "TypeID", SqlDbType.SmallInt, false);
                this.Telephone = new MSSQL.Field(this, "Telephone", "Telephone", SqlDbType.VarChar, false);
                this.AnswerStatus = new MSSQL.Field(this, "AnswerStatus", "AnswerStatus", SqlDbType.SmallInt, false);
                this.HandleDateTime = new MSSQL.Field(this, "HandleDateTime", "HandleDateTime", SqlDbType.DateTime, false);
                this.HandleOperatorID = new MSSQL.Field(this, "HandleOperatorID", "HandleOperatorID", SqlDbType.BigInt, false);
                this.AnswerOperatorID = new MSSQL.Field(this, "AnswerOperatorID", "AnswerOperatorID", SqlDbType.BigInt, false);
                this.AnswerDateTime = new MSSQL.Field(this, "AnswerDateTime", "AnswerDateTime", SqlDbType.DateTime, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
                this.Answer = new MSSQL.Field(this, "Answer", "Answer", SqlDbType.VarChar, false);
            }
        }

        public class T_QuestionTypes : MSSQL.TableBase
        {
            public MSSQL.Field Description;
            public MSSQL.Field ID;
            public MSSQL.Field Name;
            public MSSQL.Field UseType;

            public T_QuestionTypes()
            {
                base.TableName = "T_QuestionTypes";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.SmallInt, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.UseType = new MSSQL.Field(this, "UseType", "UseType", SqlDbType.SmallInt, false);
            }
        }

        public class T_RecallingAllBuyStar : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field InitiatorName;
            public MSSQL.Field ProfitIndex;
            public MSSQL.Field SchemesID;
            public MSSQL.Field SchemesMoney;
            public MSSQL.Field SchemesWinMoney;
            public MSSQL.Field State;

            public T_RecallingAllBuyStar()
            {
                base.TableName = "T_RecallingAllBuyStar";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.SchemesID = new MSSQL.Field(this, "SchemesID", "SchemesID", SqlDbType.Int, false);
                this.InitiatorName = new MSSQL.Field(this, "InitiatorName", "InitiatorName", SqlDbType.VarChar, false);
                this.SchemesMoney = new MSSQL.Field(this, "SchemesMoney", "SchemesMoney", SqlDbType.VarChar, false);
                this.SchemesWinMoney = new MSSQL.Field(this, "SchemesWinMoney", "SchemesWinMoney", SqlDbType.VarChar, false);
                this.ProfitIndex = new MSSQL.Field(this, "ProfitIndex", "ProfitIndex", SqlDbType.VarChar, false);
                this.State = new MSSQL.Field(this, "State", "State", SqlDbType.Int, false);
            }
        }

        public class T_SchemeChatContents : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field FromUserID;
            public MSSQL.Field ID;
            public MSSQL.Field SchemeID;
            public MSSQL.Field SiteID;
            public MSSQL.Field ToUserID;
            public MSSQL.Field Type;

            public T_SchemeChatContents()
            {
                base.TableName = "T_SchemeChatContents";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.FromUserID = new MSSQL.Field(this, "FromUserID", "FromUserID", SqlDbType.BigInt, false);
                this.ToUserID = new MSSQL.Field(this, "ToUserID", "ToUserID", SqlDbType.BigInt, false);
                this.Type = new MSSQL.Field(this, "Type", "Type", SqlDbType.SmallInt, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_SchemeChatContentsReaded : MSSQL.TableBase
        {
            public MSSQL.Field ContentID;
            public MSSQL.Field UserID;

            public T_SchemeChatContentsReaded()
            {
                base.TableName = "T_SchemeChatContentsReaded";
                this.ContentID = new MSSQL.Field(this, "ContentID", "ContentID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
            }
        }

        public class T_SchemeElectronTickets : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field HandleDateTime;
            public MSSQL.Field HandleDescription;
            public MSSQL.Field HandleResult;
            public MSSQL.Field ID;
            public MSSQL.Field Identifiers;
            public MSSQL.Field Money;
            public MSSQL.Field Multiple;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field SchemeID;
            public MSSQL.Field Sends;
            public MSSQL.Field Ticket;

            public T_SchemeElectronTickets()
            {
                base.TableName = "T_SchemeElectronTickets";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.Multiple = new MSSQL.Field(this, "Multiple", "Multiple", SqlDbType.Int, false);
                this.Sends = new MSSQL.Field(this, "Sends", "Sends", SqlDbType.SmallInt, false);
                this.HandleDateTime = new MSSQL.Field(this, "HandleDateTime", "HandleDateTime", SqlDbType.DateTime, false);
                this.HandleResult = new MSSQL.Field(this, "HandleResult", "HandleResult", SqlDbType.SmallInt, false);
                this.HandleDescription = new MSSQL.Field(this, "HandleDescription", "HandleDescription", SqlDbType.VarChar, false);
                this.Identifiers = new MSSQL.Field(this, "Identifiers", "Identifiers", SqlDbType.VarChar, false);
                this.Ticket = new MSSQL.Field(this, "Ticket", "Ticket", SqlDbType.VarChar, false);
            }
        }

        public class T_SchemeIsCalcuteScore : MSSQL.TableBase
        {
            public MSSQL.Field SchemeID;

            public T_SchemeIsCalcuteScore()
            {
                base.TableName = "T_SchemeIsCalcuteScore";
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
            }
        }

        public class T_SchemeOpenUsers : MSSQL.TableBase
        {
            public MSSQL.Field SchemeID;
            public MSSQL.Field UserID;

            public T_SchemeOpenUsers()
            {
                base.TableName = "T_SchemeOpenUsers";
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
            }
        }

        public class T_Schemes : MSSQL.TableBase
        {
            public MSSQL.Field AssureMoney;
            public MSSQL.Field AtTopStatus;
            public MSSQL.Field Buyed;
            public MSSQL.Field BuyedShare;
            public MSSQL.Field BuyOperatorID;
            public MSSQL.Field CorrelationSchemeID;
            public MSSQL.Field DateTime;
            public MSSQL.Field Description;
            public MSSQL.Field EditWinMoney;
            public MSSQL.Field EditWinMoneyNoWithTax;
            public MSSQL.Field ID;
            public MSSQL.Field Identifiers;
            public MSSQL.Field InitiateBonus;
            public MSSQL.Field InitiateUserID;
            public MSSQL.Field isCanChat;
            public MSSQL.Field isOpened;
            public MSSQL.Field IsSchemeCalculatedBonus;
            public MSSQL.Field IsuseID;
            public MSSQL.Field LotteryNumber;
            public MSSQL.Field Money;
            public MSSQL.Field Multiple;
            public MSSQL.Field OpenOperatorID;
            public MSSQL.Field Ot;
            public MSSQL.Field OutTo;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field PreWinMoney;
            public MSSQL.Field PreWinMoneyNoWithTax;
            public MSSQL.Field PrintOutDateTime;
            public MSSQL.Field PrintOutType;
            public MSSQL.Field QuashStatus;
            public MSSQL.Field ReSchedule;
            public MSSQL.Field Schedule;
            public MSSQL.Field SchemeBonusScale;
            public MSSQL.Field SchemeNumber;
            public MSSQL.Field SecrecyLevel;
            public MSSQL.Field Share;
            public MSSQL.Field SiteID;
            public MSSQL.Field Title;
            public MSSQL.Field UpdateDatetime;
            public MSSQL.Field UploadFileContent;
            public MSSQL.Field WinDescription;
            public MSSQL.Field WinImage;
            public MSSQL.Field WinMoney;
            public MSSQL.Field WinMoneyNoWithTax;

            public T_Schemes()
            {
                base.TableName = "T_Schemes";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.SchemeNumber = new MSSQL.Field(this, "SchemeNumber", "SchemeNumber", SqlDbType.VarChar, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.InitiateUserID = new MSSQL.Field(this, "InitiateUserID", "InitiateUserID", SqlDbType.BigInt, false);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.Multiple = new MSSQL.Field(this, "Multiple", "Multiple", SqlDbType.Int, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.AssureMoney = new MSSQL.Field(this, "AssureMoney", "AssureMoney", SqlDbType.Money, false);
                this.Share = new MSSQL.Field(this, "Share", "Share", SqlDbType.Int, false);
                this.SecrecyLevel = new MSSQL.Field(this, "SecrecyLevel", "SecrecyLevel", SqlDbType.SmallInt, false);
                this.QuashStatus = new MSSQL.Field(this, "QuashStatus", "QuashStatus", SqlDbType.SmallInt, false);
                this.Buyed = new MSSQL.Field(this, "Buyed", "Buyed", SqlDbType.Bit, false);
                this.BuyOperatorID = new MSSQL.Field(this, "BuyOperatorID", "BuyOperatorID", SqlDbType.BigInt, false);
                this.PrintOutType = new MSSQL.Field(this, "PrintOutType", "PrintOutType", SqlDbType.SmallInt, false);
                this.Identifiers = new MSSQL.Field(this, "Identifiers", "Identifiers", SqlDbType.VarChar, false);
                this.isOpened = new MSSQL.Field(this, "isOpened", "isOpened", SqlDbType.Bit, false);
                this.OpenOperatorID = new MSSQL.Field(this, "OpenOperatorID", "OpenOperatorID", SqlDbType.BigInt, false);
                this.WinMoney = new MSSQL.Field(this, "WinMoney", "WinMoney", SqlDbType.Money, false);
                this.WinMoneyNoWithTax = new MSSQL.Field(this, "WinMoneyNoWithTax", "WinMoneyNoWithTax", SqlDbType.Money, false);
                this.InitiateBonus = new MSSQL.Field(this, "InitiateBonus", "InitiateBonus", SqlDbType.Money, false);
                this.AtTopStatus = new MSSQL.Field(this, "AtTopStatus", "AtTopStatus", SqlDbType.SmallInt, false);
                this.isCanChat = new MSSQL.Field(this, "isCanChat", "isCanChat", SqlDbType.Bit, false);
                this.PreWinMoney = new MSSQL.Field(this, "PreWinMoney", "PreWinMoney", SqlDbType.Money, false);
                this.PreWinMoneyNoWithTax = new MSSQL.Field(this, "PreWinMoneyNoWithTax", "PreWinMoneyNoWithTax", SqlDbType.Money, false);
                this.EditWinMoney = new MSSQL.Field(this, "EditWinMoney", "EditWinMoney", SqlDbType.Money, false);
                this.EditWinMoneyNoWithTax = new MSSQL.Field(this, "EditWinMoneyNoWithTax", "EditWinMoneyNoWithTax", SqlDbType.Money, false);
                this.BuyedShare = new MSSQL.Field(this, "BuyedShare", "BuyedShare", SqlDbType.Int, false);
                this.Schedule = new MSSQL.Field(this, "Schedule", "Schedule", SqlDbType.Float, false);
                this.ReSchedule = new MSSQL.Field(this, "ReSchedule", "ReSchedule", SqlDbType.Float, false);
                this.IsSchemeCalculatedBonus = new MSSQL.Field(this, "IsSchemeCalculatedBonus", "IsSchemeCalculatedBonus", SqlDbType.Bit, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.LotteryNumber = new MSSQL.Field(this, "LotteryNumber", "LotteryNumber", SqlDbType.VarChar, false);
                this.UploadFileContent = new MSSQL.Field(this, "UploadFileContent", "UploadFileContent", SqlDbType.VarChar, false);
                this.WinDescription = new MSSQL.Field(this, "WinDescription", "WinDescription", SqlDbType.VarChar, false);
                this.WinImage = new MSSQL.Field(this, "WinImage", "WinImage", SqlDbType.VarChar, false);
                this.UpdateDatetime = new MSSQL.Field(this, "UpdateDatetime", "UpdateDatetime", SqlDbType.DateTime, false);
                this.PrintOutDateTime = new MSSQL.Field(this, "PrintOutDateTime", "PrintOutDateTime", SqlDbType.DateTime, false);
                this.Ot = new MSSQL.Field(this, "Ot", "Ot", SqlDbType.SmallInt, false);
                this.OutTo = new MSSQL.Field(this, "OutTo", "OutTo", SqlDbType.SmallInt, false);
                this.CorrelationSchemeID = new MSSQL.Field(this, "CorrelationSchemeID", "CorrelationSchemeID", SqlDbType.BigInt, false);
                this.SchemeBonusScale = new MSSQL.Field(this, "SchemeBonusScale", "SchemeBonusScale", SqlDbType.Float, false);
            }
        }

        public class T_SchemesNumber : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field LotteryNumber;
            public MSSQL.Field Money;
            public MSSQL.Field Multiple;
            public MSSQL.Field SchemeID;

            public T_SchemesNumber()
            {
                base.TableName = "T_SchemesNumber";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.Multiple = new MSSQL.Field(this, "Multiple", "Multiple", SqlDbType.Int, false);
                this.LotteryNumber = new MSSQL.Field(this, "LotteryNumber", "LotteryNumber", SqlDbType.VarChar, false);
            }
        }

        public class T_SchemesSendToCenter : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field HandleDateTime;
            public MSSQL.Field HandleDescription;
            public MSSQL.Field HandleResult;
            public MSSQL.Field ID;
            public MSSQL.Field Identifiers;
            public MSSQL.Field Money;
            public MSSQL.Field Multiple;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field SchemeID;
            public MSSQL.Field Sends;
            public MSSQL.Field Ticket;

            public T_SchemesSendToCenter()
            {
                base.TableName = "T_SchemesSendToCenter";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.Multiple = new MSSQL.Field(this, "Multiple", "Multiple", SqlDbType.Int, false);
                this.Sends = new MSSQL.Field(this, "Sends", "Sends", SqlDbType.SmallInt, false);
                this.HandleDateTime = new MSSQL.Field(this, "HandleDateTime", "HandleDateTime", SqlDbType.DateTime, false);
                this.HandleResult = new MSSQL.Field(this, "HandleResult", "HandleResult", SqlDbType.SmallInt, false);
                this.HandleDescription = new MSSQL.Field(this, "HandleDescription", "HandleDescription", SqlDbType.VarChar, false);
                this.Identifiers = new MSSQL.Field(this, "Identifiers", "Identifiers", SqlDbType.VarChar, false);
                this.Ticket = new MSSQL.Field(this, "Ticket", "Ticket", SqlDbType.VarChar, false);
            }
        }

        public class T_SchemeSupperCobuy : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field SchemeID;
            public MSSQL.Field TypeState;

            public T_SchemeSupperCobuy()
            {
                base.TableName = "T_SchemeSupperCobuy";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.TypeState = new MSSQL.Field(this, "TypeState", "TypeState", SqlDbType.Int, false);
            }
        }

        public class T_SchemeToTicketed : MSSQL.TableBase
        {
            public MSSQL.Field OurOrAgent;
            public MSSQL.Field SchemeID;

            public T_SchemeToTicketed()
            {
                base.TableName = "T_SchemeToTicketed";
                this.OurOrAgent = new MSSQL.Field(this, "OurOrAgent", "OurOrAgent", SqlDbType.SmallInt, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
            }
        }

        public class T_SchemeUpload : MSSQL.TableBase
        {
            public MSSQL.Field LotteryID;
            public MSSQL.Field SchemeContent;

            public T_SchemeUpload()
            {
                base.TableName = "T_SchemeUpload";
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.BigInt, false);
                this.SchemeContent = new MSSQL.Field(this, "SchemeContent", "SchemeContent", SqlDbType.VarChar, false);
            }
        }

        public class T_ScoreChange : MSSQL.TableBase
        {
            public MSSQL.Field ComodityID;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field IsWin;
            public MSSQL.Field Score;
            public MSSQL.Field Type;
            public MSSQL.Field UserID;

            public T_ScoreChange()
            {
                base.TableName = "T_ScoreChange";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.ComodityID = new MSSQL.Field(this, "ComodityID", "ComodityID", SqlDbType.BigInt, false);
                this.Type = new MSSQL.Field(this, "Type", "Type", SqlDbType.SmallInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Score = new MSSQL.Field(this, "Score", "Score", SqlDbType.Int, false);
                this.IsWin = new MSSQL.Field(this, "IsWin", "IsWin", SqlDbType.Bit, false);
            }
        }

        public class T_ScoreChangeAddress : MSSQL.TableBase
        {
            public MSSQL.Field Address;
            public MSSQL.Field Memo;
            public MSSQL.Field Mobile;
            public MSSQL.Field Name;
            public MSSQL.Field Phone;
            public MSSQL.Field PostCode;
            public MSSQL.Field UserID;

            public T_ScoreChangeAddress()
            {
                base.TableName = "T_ScoreChangeAddress";
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Address = new MSSQL.Field(this, "Address", "Address", SqlDbType.VarChar, false);
                this.PostCode = new MSSQL.Field(this, "PostCode", "PostCode", SqlDbType.VarChar, false);
                this.Phone = new MSSQL.Field(this, "Phone", "Phone", SqlDbType.VarChar, false);
                this.Mobile = new MSSQL.Field(this, "Mobile", "Mobile", SqlDbType.VarChar, false);
                this.Memo = new MSSQL.Field(this, "Memo", "Memo", SqlDbType.VarChar, false);
            }
        }

        public class T_ScoreCommodities : MSSQL.TableBase
        {
            public MSSQL.Field ChangedScore;
            public MSSQL.Field DrawedScore;
            public MSSQL.Field ID;
            public MSSQL.Field Images;
            public MSSQL.Field Introduce;
            public MSSQL.Field IsCanChange;
            public MSSQL.Field IsCanDraw;
            public MSSQL.Field IsCommend;
            public MSSQL.Field Name;
            public MSSQL.Field Qty;
            public MSSQL.Field TypeID;

            public T_ScoreCommodities()
            {
                base.TableName = "T_ScoreCommodities";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.TypeID = new MSSQL.Field(this, "TypeID", "TypeID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Qty = new MSSQL.Field(this, "Qty", "Qty", SqlDbType.Int, false);
                this.ChangedScore = new MSSQL.Field(this, "ChangedScore", "ChangedScore", SqlDbType.Int, false);
                this.DrawedScore = new MSSQL.Field(this, "DrawedScore", "DrawedScore", SqlDbType.Int, false);
                this.Images = new MSSQL.Field(this, "Images", "Images", SqlDbType.VarChar, false);
                this.Introduce = new MSSQL.Field(this, "Introduce", "Introduce", SqlDbType.VarChar, false);
                this.IsCanChange = new MSSQL.Field(this, "IsCanChange", "IsCanChange", SqlDbType.Bit, false);
                this.IsCanDraw = new MSSQL.Field(this, "IsCanDraw", "IsCanDraw", SqlDbType.Bit, false);
                this.IsCommend = new MSSQL.Field(this, "IsCommend", "IsCommend", SqlDbType.Bit, false);
            }
        }

        public class T_ScoreCommodityType : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field Name;
            public MSSQL.Field ParentID;

            public T_ScoreCommodityType()
            {
                base.TableName = "T_ScoreCommodityType";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.ParentID = new MSSQL.Field(this, "ParentID", "ParentID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
            }
        }

        public class T_ScoreGoldType : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field IsScore;
            public MSSQL.Field TypeId;
            public MSSQL.Field TypeName;

            public T_ScoreGoldType()
            {
                base.TableName = "T_ScoreGoldType";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.IsScore = new MSSQL.Field(this, "IsScore", "IsScore", SqlDbType.Bit, false);
                this.TypeId = new MSSQL.Field(this, "TypeId", "TypeId", SqlDbType.Int, false);
                this.TypeName = new MSSQL.Field(this, "TypeName", "TypeName", SqlDbType.NVarChar, false);
            }
        }

        public class T_ScorePresentIn : MSSQL.TableBase
        {
            public MSSQL.Field CreateTime;
            public MSSQL.Field ID;
            public MSSQL.Field OperatorID;
            public MSSQL.Field PresentID;
            public MSSQL.Field Qty;

            public T_ScorePresentIn()
            {
                base.TableName = "T_ScorePresentIn";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.PresentID = new MSSQL.Field(this, "PresentID", "PresentID", SqlDbType.BigInt, false);
                this.Qty = new MSSQL.Field(this, "Qty", "Qty", SqlDbType.Int, false);
                this.CreateTime = new MSSQL.Field(this, "CreateTime", "CreateTime", SqlDbType.SmallDateTime, false);
                this.OperatorID = new MSSQL.Field(this, "OperatorID", "OperatorID", SqlDbType.BigInt, false);
            }
        }

        public class T_ScorePresentInventory : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field PhotoDir;
            public MSSQL.Field PresentName;
            public MSSQL.Field Price;
            public MSSQL.Field ProductDetail;
            public MSSQL.Field ProductImage;
            public MSSQL.Field Qty;
            public MSSQL.Field ShopID;
            public MSSQL.Field TypeID;

            public T_ScorePresentInventory()
            {
                base.TableName = "T_ScorePresentInventory";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.TypeID = new MSSQL.Field(this, "TypeID", "TypeID", SqlDbType.BigInt, false);
                this.Qty = new MSSQL.Field(this, "Qty", "Qty", SqlDbType.Int, false);
                this.Price = new MSSQL.Field(this, "Price", "Price", SqlDbType.Money, false);
                this.ShopID = new MSSQL.Field(this, "ShopID", "ShopID", SqlDbType.BigInt, false);
                this.PresentName = new MSSQL.Field(this, "PresentName", "PresentName", SqlDbType.NVarChar, false);
                this.ProductImage = new MSSQL.Field(this, "ProductImage", "ProductImage", SqlDbType.Image, false);
                this.ProductDetail = new MSSQL.Field(this, "ProductDetail", "ProductDetail", SqlDbType.NText, false);
                this.PhotoDir = new MSSQL.Field(this, "PhotoDir", "PhotoDir", SqlDbType.VarChar, false);
            }
        }

        public class T_ScorePresentOut : MSSQL.TableBase
        {
            public MSSQL.Field ChangeID;
            public MSSQL.Field CreateDate;
            public MSSQL.Field ID;
            public MSSQL.Field Qty;
            public MSSQL.Field Status;
            public MSSQL.Field UserID;
            public MSSQL.Field UserName;

            public T_ScorePresentOut()
            {
                base.TableName = "T_ScorePresentOut";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.UserName = new MSSQL.Field(this, "UserName", "UserName", SqlDbType.NVarChar, false);
                this.Qty = new MSSQL.Field(this, "Qty", "Qty", SqlDbType.Int, false);
                this.ChangeID = new MSSQL.Field(this, "ChangeID", "ChangeID", SqlDbType.BigInt, false);
                this.CreateDate = new MSSQL.Field(this, "CreateDate", "CreateDate", SqlDbType.SmallDateTime, false);
                this.Status = new MSSQL.Field(this, "Status", "Status", SqlDbType.SmallInt, false);
            }
        }

        public class T_ScorePresentRule : MSSQL.TableBase
        {
            public MSSQL.Field AllowWinMember;
            public MSSQL.Field ChangeMemo;
            public MSSQL.Field ChangeType;
            public MSSQL.Field GoldNumber;
            public MSSQL.Field ID;
            public MSSQL.Field IsHot;
            public MSSQL.Field IsScore;
            public MSSQL.Field PresentID;
            public MSSQL.Field PresentOrder;
            public MSSQL.Field Qty;
            public MSSQL.Field ScoreNumber;
            public MSSQL.Field Status;
            public MSSQL.Field TimeEnd;
            public MSSQL.Field TimeStart;

            public T_ScorePresentRule()
            {
                base.TableName = "T_ScorePresentRule";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.PresentID = new MSSQL.Field(this, "PresentID", "PresentID", SqlDbType.BigInt, false);
                this.ChangeType = new MSSQL.Field(this, "ChangeType", "ChangeType", SqlDbType.SmallInt, false);
                this.Qty = new MSSQL.Field(this, "Qty", "Qty", SqlDbType.Int, false);
                this.ScoreNumber = new MSSQL.Field(this, "ScoreNumber", "ScoreNumber", SqlDbType.Int, false);
                this.GoldNumber = new MSSQL.Field(this, "GoldNumber", "GoldNumber", SqlDbType.Int, false);
                this.ChangeMemo = new MSSQL.Field(this, "ChangeMemo", "ChangeMemo", SqlDbType.NVarChar, false);
                this.PresentOrder = new MSSQL.Field(this, "PresentOrder", "PresentOrder", SqlDbType.Int, false);
                this.Status = new MSSQL.Field(this, "Status", "Status", SqlDbType.SmallInt, false);
                this.IsScore = new MSSQL.Field(this, "IsScore", "IsScore", SqlDbType.SmallInt, false);
                this.AllowWinMember = new MSSQL.Field(this, "AllowWinMember", "AllowWinMember", SqlDbType.NVarChar, false);
                this.IsHot = new MSSQL.Field(this, "IsHot", "IsHot", SqlDbType.Bit, false);
                this.TimeStart = new MSSQL.Field(this, "TimeStart", "TimeStart", SqlDbType.SmallDateTime, false);
                this.TimeEnd = new MSSQL.Field(this, "TimeEnd", "TimeEnd", SqlDbType.SmallDateTime, false);
            }
        }

        public class T_ScorePresentShop : MSSQL.TableBase
        {
            public MSSQL.Field ContactName;
            public MSSQL.Field ID;
            public MSSQL.Field MobilePhone;
            public MSSQL.Field ShopName;
            public MSSQL.Field Telephone;

            public T_ScorePresentShop()
            {
                base.TableName = "T_ScorePresentShop";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.ShopName = new MSSQL.Field(this, "ShopName", "ShopName", SqlDbType.NVarChar, false);
                this.Telephone = new MSSQL.Field(this, "Telephone", "Telephone", SqlDbType.VarChar, false);
                this.MobilePhone = new MSSQL.Field(this, "MobilePhone", "MobilePhone", SqlDbType.VarChar, false);
                this.ContactName = new MSSQL.Field(this, "ContactName", "ContactName", SqlDbType.NVarChar, false);
            }
        }

        public class T_ScorePresentType : MSSQL.TableBase
        {
            public MSSQL.Field CreateDate;
            public MSSQL.Field ID;
            public MSSQL.Field OperatorID;
            public MSSQL.Field ParentID;
            public MSSQL.Field TypeName;

            public T_ScorePresentType()
            {
                base.TableName = "T_ScorePresentType";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.ParentID = new MSSQL.Field(this, "ParentID", "ParentID", SqlDbType.BigInt, false);
                this.TypeName = new MSSQL.Field(this, "TypeName", "TypeName", SqlDbType.NVarChar, false);
                this.CreateDate = new MSSQL.Field(this, "CreateDate", "CreateDate", SqlDbType.SmallDateTime, false);
                this.OperatorID = new MSSQL.Field(this, "OperatorID", "OperatorID", SqlDbType.BigInt, false);
            }
        }

        public class T_ScoreUserAddress : MSSQL.TableBase
        {
            public MSSQL.Field PresentAddress;
            public MSSQL.Field PresentCityID;
            public MSSQL.Field PresentContact;
            public MSSQL.Field PresentMemo;
            public MSSQL.Field PresentMobile;
            public MSSQL.Field PresentPhone;
            public MSSQL.Field PresentPostCode;
            public MSSQL.Field UserID;

            public T_ScoreUserAddress()
            {
                base.TableName = "T_ScoreUserAddress";
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.PresentCityID = new MSSQL.Field(this, "PresentCityID", "PresentCityID", SqlDbType.NChar, false);
                this.PresentAddress = new MSSQL.Field(this, "PresentAddress", "PresentAddress", SqlDbType.NVarChar, false);
                this.PresentPostCode = new MSSQL.Field(this, "PresentPostCode", "PresentPostCode", SqlDbType.VarChar, false);
                this.PresentPhone = new MSSQL.Field(this, "PresentPhone", "PresentPhone", SqlDbType.VarChar, false);
                this.PresentMobile = new MSSQL.Field(this, "PresentMobile", "PresentMobile", SqlDbType.VarChar, false);
                this.PresentContact = new MSSQL.Field(this, "PresentContact", "PresentContact", SqlDbType.NVarChar, false);
                this.PresentMemo = new MSSQL.Field(this, "PresentMemo", "PresentMemo", SqlDbType.NVarChar, false);
            }
        }

        public class T_ScoreUserChange : MSSQL.TableBase
        {
            public MSSQL.Field ChangeType;
            public MSSQL.Field CreateDate;
            public MSSQL.Field ID;
            public MSSQL.Field IsGetPresent;
            public MSSQL.Field IsGoldScore;
            public MSSQL.Field PresentRuleID;
            public MSSQL.Field Qty;
            public MSSQL.Field UserID;
            public MSSQL.Field UseScore;

            public T_ScoreUserChange()
            {
                base.TableName = "T_ScoreUserChange";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.PresentRuleID = new MSSQL.Field(this, "PresentRuleID", "PresentRuleID", SqlDbType.BigInt, false);
                this.ChangeType = new MSSQL.Field(this, "ChangeType", "ChangeType", SqlDbType.SmallInt, false);
                this.UseScore = new MSSQL.Field(this, "UseScore", "UseScore", SqlDbType.Int, false);
                this.IsGoldScore = new MSSQL.Field(this, "IsGoldScore", "IsGoldScore", SqlDbType.SmallInt, false);
                this.IsGetPresent = new MSSQL.Field(this, "IsGetPresent", "IsGetPresent", SqlDbType.Bit, false);
                this.CreateDate = new MSSQL.Field(this, "CreateDate", "CreateDate", SqlDbType.SmallDateTime, false);
                this.Qty = new MSSQL.Field(this, "Qty", "Qty", SqlDbType.Int, false);
            }
        }

        public class T_SendNoticeForQuashScheme : MSSQL.TableBase
        {
            public MSSQL.Field Email;
            public MSSQL.Field Email_QuashScheme;
            public MSSQL.Field ID;
            public MSSQL.Field IsEmailValided;
            public MSSQL.Field IsMobileValided;
            public MSSQL.Field IsSend;
            public MSSQL.Field Mobile;
            public MSSQL.Field SchemeID;
            public MSSQL.Field SMS_QuashScheme;
            public MSSQL.Field StationSMS_QuashScheme;
            public MSSQL.Field UserID;
            public MSSQL.Field UserName;

            public T_SendNoticeForQuashScheme()
            {
                base.TableName = "T_SendNoticeForQuashScheme";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.UserName = new MSSQL.Field(this, "UserName", "UserName", SqlDbType.VarChar, false);
                this.IsEmailValided = new MSSQL.Field(this, "IsEmailValided", "IsEmailValided", SqlDbType.Bit, false);
                this.Email = new MSSQL.Field(this, "Email", "Email", SqlDbType.VarChar, false);
                this.IsMobileValided = new MSSQL.Field(this, "IsMobileValided", "IsMobileValided", SqlDbType.Bit, false);
                this.Mobile = new MSSQL.Field(this, "Mobile", "Mobile", SqlDbType.VarChar, false);
                this.Email_QuashScheme = new MSSQL.Field(this, "Email_QuashScheme", "Email_QuashScheme", SqlDbType.VarChar, false);
                this.StationSMS_QuashScheme = new MSSQL.Field(this, "StationSMS_QuashScheme", "StationSMS_QuashScheme", SqlDbType.VarChar, false);
                this.SMS_QuashScheme = new MSSQL.Field(this, "SMS_QuashScheme", "SMS_QuashScheme", SqlDbType.VarChar, false);
                this.IsSend = new MSSQL.Field(this, "IsSend", "IsSend", SqlDbType.Bit, false);
            }
        }

        public class T_SiteAffiches : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field isCommend;
            public MSSQL.Field isShow;
            public MSSQL.Field SiteID;
            public MSSQL.Field Title;

            public T_SiteAffiches()
            {
                base.TableName = "T_SiteAffiches";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
                this.isCommend = new MSSQL.Field(this, "isCommend", "isCommend", SqlDbType.Bit, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_Sites : MSSQL.TableBase
        {
            public MSSQL.Field Address;
            public MSSQL.Field BonusScale;
            public MSSQL.Field Company;
            public MSSQL.Field ContactPerson;
            public MSSQL.Field Email;
            public MSSQL.Field Fax;
            public MSSQL.Field ICPCert;
            public MSSQL.Field ID;
            public MSSQL.Field Level;
            public MSSQL.Field LogoUrl;
            public MSSQL.Field MaxSubSites;
            public MSSQL.Field Mobile;
            public MSSQL.Field Name;
            public MSSQL.Field ON;
            public MSSQL.Field Opt_About;
            public MSSQL.Field Opt_BettingStationAddress;
            public MSSQL.Field Opt_BettingStationContactPreson;
            public MSSQL.Field Opt_BettingStationName;
            public MSSQL.Field Opt_BettingStationNumber;
            public MSSQL.Field Opt_BettingStationTelephone;
            public MSSQL.Field Opt_CheckCodeCharset;
            public MSSQL.Field Opt_CompanyQualification;
            public MSSQL.Field Opt_ContactUS;
            public MSSQL.Field Opt_Cps_Status_ON;
            public MSSQL.Field Opt_CpsBonusScale;
            public MSSQL.Field Opt_CpsPolicies;
            public MSSQL.Field Opt_CPSRegisterAgreement;
            public MSSQL.Field Opt_DefaultFirstPageType;
            public MSSQL.Field Opt_DefaultLotteryFirstPageType;
            public MSSQL.Field Opt_EmailServer_EmailServer;
            public MSSQL.Field Opt_EmailServer_From;
            public MSSQL.Field Opt_EmailServer_Password;
            public MSSQL.Field Opt_EmailServer_UserName;
            public MSSQL.Field Opt_Experts_Status_ON;
            public MSSQL.Field Opt_ExpertsNote;
            public MSSQL.Field Opt_FirstPageUnionBuyMaxRows;
            public MSSQL.Field Opt_FloatNotifiesTime;
            public MSSQL.Field Opt_ForumUrl;
            public MSSQL.Field Opt_FullSchemeCanQuash;
            public MSSQL.Field Opt_InitiateFollowSchemeMaxNum;
            public MSSQL.Field Opt_InitiateSchemeBonusScale;
            public MSSQL.Field Opt_InitiateSchemeLimitLowerScale;
            public MSSQL.Field Opt_InitiateSchemeLimitLowerScaleMoney;
            public MSSQL.Field Opt_InitiateSchemeLimitUpperScale;
            public MSSQL.Field Opt_InitiateSchemeLimitUpperScaleMoney;
            public MSSQL.Field Opt_InitiateSchemeMaxNum;
            public MSSQL.Field Opt_InitiateSchemeMinBuyAndAssureScale;
            public MSSQL.Field Opt_InitiateSchemeMinBuyScale;
            public MSSQL.Field Opt_isBuyValidPasswordAdv;
            public MSSQL.Field Opt_isFirstPageUnionBuyWithAll;
            public MSSQL.Field Opt_ISP_HostName;
            public MSSQL.Field Opt_ISP_HostPort;
            public MSSQL.Field Opt_ISP_RegCode;
            public MSSQL.Field Opt_ISP_ServiceNumber;
            public MSSQL.Field Opt_ISP_UserID;
            public MSSQL.Field Opt_ISP_UserPassword;
            public MSSQL.Field Opt_isShowChartNavigate;
            public MSSQL.Field Opt_isShowFloatAD;
            public MSSQL.Field Opt_isShowSMSSubscriptionNavigate;
            public MSSQL.Field Opt_isUseCheckCode;
            public MSSQL.Field Opt_isWriteLog;
            public MSSQL.Field Opt_LawAffirmsThat;
            public MSSQL.Field Opt_LotteryChannelPage;
            public MSSQL.Field Opt_LotteryCountOfMenuBarRow;
            public MSSQL.Field Opt_MaxShowLotteryNumberRows;
            public MSSQL.Field Opt_MemberSharing_Alipay_Status_ON;
            public MSSQL.Field Opt_MobileCheckCharset;
            public MSSQL.Field Opt_MobileCheckStringLength;
            public MSSQL.Field Opt_OfficialAuthorization;
            public MSSQL.Field Opt_PageKeywords;
            public MSSQL.Field Opt_PageTitle;
            public MSSQL.Field Opt_Promotion_Status_ON;
            public MSSQL.Field Opt_PromotionMemberBonusScale;
            public MSSQL.Field Opt_PromotionSiteBonusScale;
            public MSSQL.Field Opt_QuashSchemeMaxNum;
            public MSSQL.Field Opt_RightFloatADContent;
            public MSSQL.Field Opt_RoomLogoUrl;
            public MSSQL.Field Opt_RoomStyle;
            public MSSQL.Field Opt_SchemeChatRoom_MaxChatNumberOf;
            public MSSQL.Field Opt_SchemeChatRoom_StopChatDaysAfterOpened;
            public MSSQL.Field Opt_SchemeMaxMoney;
            public MSSQL.Field Opt_SchemeMinMoney;
            public MSSQL.Field Opt_Score_Compendium;
            public MSSQL.Field Opt_Score_PrententType;
            public MSSQL.Field Opt_Scoring_Status_ON;
            public MSSQL.Field Opt_ScoringExchangeRate;
            public MSSQL.Field Opt_ScoringOfCommendBuy;
            public MSSQL.Field Opt_ScoringOfSelfBuy;
            public MSSQL.Field Opt_SMSPayType;
            public MSSQL.Field Opt_SMSPrice;
            public MSSQL.Field Opt_SMSSubscription;
            public MSSQL.Field Opt_SurrogateFAQ;
            public MSSQL.Field Opt_UpdateLotteryDateTime;
            public MSSQL.Field Opt_UserRegisterAgreement;
            public MSSQL.Field OwnerUserID;
            public MSSQL.Field ParentID;
            public MSSQL.Field PostCode;
            public MSSQL.Field QQ;
            public MSSQL.Field ResponsiblePerson;
            public MSSQL.Field ServiceTelephone;
            public MSSQL.Field Telephone;
            public MSSQL.Field TemplateEmail_CustomChaseWin;
            public MSSQL.Field TemplateEmail_DistillAccept;
            public MSSQL.Field TemplateEmail_DistillNoAccept;
            public MSSQL.Field TemplateEmail_ExecChaseTaskDetail;
            public MSSQL.Field TemplateEmail_ForgetPassword;
            public MSSQL.Field TemplateEmail_InitiateChaseTask;
            public MSSQL.Field TemplateEmail_InitiateScheme;
            public MSSQL.Field TemplateEmail_IntiateCustomChase;
            public MSSQL.Field TemplateEmail_JoinScheme;
            public MSSQL.Field TemplateEmail_MobileValid;
            public MSSQL.Field TemplateEmail_MobileValided;
            public MSSQL.Field TemplateEmail_Quash;
            public MSSQL.Field TemplateEmail_QuashChaseTask;
            public MSSQL.Field TemplateEmail_QuashChaseTaskDetail;
            public MSSQL.Field TemplateEmail_QuashScheme;
            public MSSQL.Field TemplateEmail_Register;
            public MSSQL.Field TemplateEmail_RegisterAdv;
            public MSSQL.Field TemplateEmail_TryDistill;
            public MSSQL.Field TemplateEmail_UserEdit;
            public MSSQL.Field TemplateEmail_UserEditAdv;
            public MSSQL.Field TemplateEmail_Win;
            public MSSQL.Field TemplateSMS_CustomChaseWin;
            public MSSQL.Field TemplateSMS_DistillAccept;
            public MSSQL.Field TemplateSMS_DistillNoAccept;
            public MSSQL.Field TemplateSMS_ExecChaseTaskDetail;
            public MSSQL.Field TemplateSMS_ForgetPassword;
            public MSSQL.Field TemplateSMS_InitiateChaseTask;
            public MSSQL.Field TemplateSMS_InitiateScheme;
            public MSSQL.Field TemplateSMS_IntiateCustomChase;
            public MSSQL.Field TemplateSMS_JoinScheme;
            public MSSQL.Field TemplateSMS_MobileValid;
            public MSSQL.Field TemplateSMS_MobileValided;
            public MSSQL.Field TemplateSMS_Quash;
            public MSSQL.Field TemplateSMS_QuashChaseTask;
            public MSSQL.Field TemplateSMS_QuashChaseTaskDetail;
            public MSSQL.Field TemplateSMS_QuashScheme;
            public MSSQL.Field TemplateSMS_Register;
            public MSSQL.Field TemplateSMS_RegisterAdv;
            public MSSQL.Field TemplateSMS_TryDistill;
            public MSSQL.Field TemplateSMS_UserEdit;
            public MSSQL.Field TemplateSMS_UserEditAdv;
            public MSSQL.Field TemplateSMS_Win;
            public MSSQL.Field TemplateStationSMS_CustomChaseWin;
            public MSSQL.Field TemplateStationSMS_DistillAccept;
            public MSSQL.Field TemplateStationSMS_DistillNoAccept;
            public MSSQL.Field TemplateStationSMS_ExecChaseTaskDetail;
            public MSSQL.Field TemplateStationSMS_ForgetPassword;
            public MSSQL.Field TemplateStationSMS_InitiateChaseTask;
            public MSSQL.Field TemplateStationSMS_InitiateScheme;
            public MSSQL.Field TemplateStationSMS_IntiateCustomChase;
            public MSSQL.Field TemplateStationSMS_JoinScheme;
            public MSSQL.Field TemplateStationSMS_MobileValid;
            public MSSQL.Field TemplateStationSMS_MobileValided;
            public MSSQL.Field TemplateStationSMS_Quash;
            public MSSQL.Field TemplateStationSMS_QuashChaseTask;
            public MSSQL.Field TemplateStationSMS_QuashChaseTaskDetail;
            public MSSQL.Field TemplateStationSMS_QuashScheme;
            public MSSQL.Field TemplateStationSMS_Register;
            public MSSQL.Field TemplateStationSMS_RegisterAdv;
            public MSSQL.Field TemplateStationSMS_TryDistill;
            public MSSQL.Field TemplateStationSMS_UserEdit;
            public MSSQL.Field TemplateStationSMS_UserEditAdv;
            public MSSQL.Field TemplateStationSMS_Win;
            public MSSQL.Field UseLotteryList;
            public MSSQL.Field UseLotteryListQuickBuy;
            public MSSQL.Field UseLotteryListRestrictions;

            public T_Sites()
            {
                base.TableName = "T_Sites";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.ParentID = new MSSQL.Field(this, "ParentID", "ParentID", SqlDbType.BigInt, false);
                this.OwnerUserID = new MSSQL.Field(this, "OwnerUserID", "OwnerUserID", SqlDbType.BigInt, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.LogoUrl = new MSSQL.Field(this, "LogoUrl", "LogoUrl", SqlDbType.VarChar, false);
                this.Company = new MSSQL.Field(this, "Company", "Company", SqlDbType.VarChar, false);
                this.Address = new MSSQL.Field(this, "Address", "Address", SqlDbType.VarChar, false);
                this.PostCode = new MSSQL.Field(this, "PostCode", "PostCode", SqlDbType.VarChar, false);
                this.ResponsiblePerson = new MSSQL.Field(this, "ResponsiblePerson", "ResponsiblePerson", SqlDbType.VarChar, false);
                this.ContactPerson = new MSSQL.Field(this, "ContactPerson", "ContactPerson", SqlDbType.VarChar, false);
                this.Telephone = new MSSQL.Field(this, "Telephone", "Telephone", SqlDbType.VarChar, false);
                this.Fax = new MSSQL.Field(this, "Fax", "Fax", SqlDbType.VarChar, false);
                this.Mobile = new MSSQL.Field(this, "Mobile", "Mobile", SqlDbType.VarChar, false);
                this.Email = new MSSQL.Field(this, "Email", "Email", SqlDbType.VarChar, false);
                this.QQ = new MSSQL.Field(this, "QQ", "QQ", SqlDbType.VarChar, false);
                this.ServiceTelephone = new MSSQL.Field(this, "ServiceTelephone", "ServiceTelephone", SqlDbType.VarChar, false);
                this.ICPCert = new MSSQL.Field(this, "ICPCert", "ICPCert", SqlDbType.VarChar, false);
                this.Level = new MSSQL.Field(this, "Level", "Level", SqlDbType.SmallInt, false);
                this.ON = new MSSQL.Field(this, "ON", "ON", SqlDbType.Bit, false);
                this.BonusScale = new MSSQL.Field(this, "BonusScale", "BonusScale", SqlDbType.Float, false);
                this.MaxSubSites = new MSSQL.Field(this, "MaxSubSites", "MaxSubSites", SqlDbType.Int, false);
                this.UseLotteryListRestrictions = new MSSQL.Field(this, "UseLotteryListRestrictions", "UseLotteryListRestrictions", SqlDbType.VarChar, false);
                this.UseLotteryList = new MSSQL.Field(this, "UseLotteryList", "UseLotteryList", SqlDbType.VarChar, false);
                this.UseLotteryListQuickBuy = new MSSQL.Field(this, "UseLotteryListQuickBuy", "UseLotteryListQuickBuy", SqlDbType.VarChar, false);
                this.Opt_BettingStationName = new MSSQL.Field(this, "Opt_BettingStationName", "Opt_BettingStationName", SqlDbType.VarChar, false);
                this.Opt_BettingStationNumber = new MSSQL.Field(this, "Opt_BettingStationNumber", "Opt_BettingStationNumber", SqlDbType.VarChar, false);
                this.Opt_BettingStationAddress = new MSSQL.Field(this, "Opt_BettingStationAddress", "Opt_BettingStationAddress", SqlDbType.VarChar, false);
                this.Opt_BettingStationTelephone = new MSSQL.Field(this, "Opt_BettingStationTelephone", "Opt_BettingStationTelephone", SqlDbType.VarChar, false);
                this.Opt_BettingStationContactPreson = new MSSQL.Field(this, "Opt_BettingStationContactPreson", "Opt_BettingStationContactPreson", SqlDbType.VarChar, false);
                this.Opt_EmailServer_From = new MSSQL.Field(this, "Opt_EmailServer_From", "Opt_EmailServer_From", SqlDbType.VarChar, false);
                this.Opt_EmailServer_EmailServer = new MSSQL.Field(this, "Opt_EmailServer_EmailServer", "Opt_EmailServer_EmailServer", SqlDbType.VarChar, false);
                this.Opt_EmailServer_UserName = new MSSQL.Field(this, "Opt_EmailServer_UserName", "Opt_EmailServer_UserName", SqlDbType.VarChar, false);
                this.Opt_EmailServer_Password = new MSSQL.Field(this, "Opt_EmailServer_Password", "Opt_EmailServer_Password", SqlDbType.VarChar, false);
                this.Opt_ISP_HostName = new MSSQL.Field(this, "Opt_ISP_HostName", "Opt_ISP_HostName", SqlDbType.VarChar, false);
                this.Opt_ISP_HostPort = new MSSQL.Field(this, "Opt_ISP_HostPort", "Opt_ISP_HostPort", SqlDbType.VarChar, false);
                this.Opt_ISP_UserID = new MSSQL.Field(this, "Opt_ISP_UserID", "Opt_ISP_UserID", SqlDbType.VarChar, false);
                this.Opt_ISP_UserPassword = new MSSQL.Field(this, "Opt_ISP_UserPassword", "Opt_ISP_UserPassword", SqlDbType.VarChar, false);
                this.Opt_ISP_RegCode = new MSSQL.Field(this, "Opt_ISP_RegCode", "Opt_ISP_RegCode", SqlDbType.VarChar, false);
                this.Opt_ISP_ServiceNumber = new MSSQL.Field(this, "Opt_ISP_ServiceNumber", "Opt_ISP_ServiceNumber", SqlDbType.VarChar, false);
                this.Opt_ForumUrl = new MSSQL.Field(this, "Opt_ForumUrl", "Opt_ForumUrl", SqlDbType.VarChar, false);
                this.Opt_MobileCheckCharset = new MSSQL.Field(this, "Opt_MobileCheckCharset", "Opt_MobileCheckCharset", SqlDbType.SmallInt, false);
                this.Opt_MobileCheckStringLength = new MSSQL.Field(this, "Opt_MobileCheckStringLength", "Opt_MobileCheckStringLength", SqlDbType.SmallInt, false);
                this.Opt_SMSPayType = new MSSQL.Field(this, "Opt_SMSPayType", "Opt_SMSPayType", SqlDbType.SmallInt, false);
                this.Opt_SMSPrice = new MSSQL.Field(this, "Opt_SMSPrice", "Opt_SMSPrice", SqlDbType.Money, false);
                this.Opt_isUseCheckCode = new MSSQL.Field(this, "Opt_isUseCheckCode", "Opt_isUseCheckCode", SqlDbType.Bit, false);
                this.Opt_CheckCodeCharset = new MSSQL.Field(this, "Opt_CheckCodeCharset", "Opt_CheckCodeCharset", SqlDbType.SmallInt, false);
                this.Opt_isWriteLog = new MSSQL.Field(this, "Opt_isWriteLog", "Opt_isWriteLog", SqlDbType.Bit, false);
                this.Opt_InitiateSchemeBonusScale = new MSSQL.Field(this, "Opt_InitiateSchemeBonusScale", "Opt_InitiateSchemeBonusScale", SqlDbType.Float, false);
                this.Opt_InitiateSchemeMinBuyScale = new MSSQL.Field(this, "Opt_InitiateSchemeMinBuyScale", "Opt_InitiateSchemeMinBuyScale", SqlDbType.Float, false);
                this.Opt_InitiateSchemeMinBuyAndAssureScale = new MSSQL.Field(this, "Opt_InitiateSchemeMinBuyAndAssureScale", "Opt_InitiateSchemeMinBuyAndAssureScale", SqlDbType.Float, false);
                this.Opt_InitiateSchemeMaxNum = new MSSQL.Field(this, "Opt_InitiateSchemeMaxNum", "Opt_InitiateSchemeMaxNum", SqlDbType.SmallInt, false);
                this.Opt_InitiateFollowSchemeMaxNum = new MSSQL.Field(this, "Opt_InitiateFollowSchemeMaxNum", "Opt_InitiateFollowSchemeMaxNum", SqlDbType.SmallInt, false);
                this.Opt_QuashSchemeMaxNum = new MSSQL.Field(this, "Opt_QuashSchemeMaxNum", "Opt_QuashSchemeMaxNum", SqlDbType.SmallInt, false);
                this.Opt_FullSchemeCanQuash = new MSSQL.Field(this, "Opt_FullSchemeCanQuash", "Opt_FullSchemeCanQuash", SqlDbType.Bit, false);
                this.Opt_SchemeMinMoney = new MSSQL.Field(this, "Opt_SchemeMinMoney", "Opt_SchemeMinMoney", SqlDbType.Money, false);
                this.Opt_SchemeMaxMoney = new MSSQL.Field(this, "Opt_SchemeMaxMoney", "Opt_SchemeMaxMoney", SqlDbType.Money, false);
                this.Opt_FirstPageUnionBuyMaxRows = new MSSQL.Field(this, "Opt_FirstPageUnionBuyMaxRows", "Opt_FirstPageUnionBuyMaxRows", SqlDbType.SmallInt, false);
                this.Opt_isFirstPageUnionBuyWithAll = new MSSQL.Field(this, "Opt_isFirstPageUnionBuyWithAll", "Opt_isFirstPageUnionBuyWithAll", SqlDbType.Bit, false);
                this.Opt_isBuyValidPasswordAdv = new MSSQL.Field(this, "Opt_isBuyValidPasswordAdv", "Opt_isBuyValidPasswordAdv", SqlDbType.Bit, false);
                this.Opt_MaxShowLotteryNumberRows = new MSSQL.Field(this, "Opt_MaxShowLotteryNumberRows", "Opt_MaxShowLotteryNumberRows", SqlDbType.SmallInt, false);
                this.Opt_LotteryCountOfMenuBarRow = new MSSQL.Field(this, "Opt_LotteryCountOfMenuBarRow", "Opt_LotteryCountOfMenuBarRow", SqlDbType.SmallInt, false);
                this.Opt_ScoringOfSelfBuy = new MSSQL.Field(this, "Opt_ScoringOfSelfBuy", "Opt_ScoringOfSelfBuy", SqlDbType.Float, false);
                this.Opt_ScoringOfCommendBuy = new MSSQL.Field(this, "Opt_ScoringOfCommendBuy", "Opt_ScoringOfCommendBuy", SqlDbType.Float, false);
                this.Opt_ScoringExchangeRate = new MSSQL.Field(this, "Opt_ScoringExchangeRate", "Opt_ScoringExchangeRate", SqlDbType.Float, false);
                this.Opt_Scoring_Status_ON = new MSSQL.Field(this, "Opt_Scoring_Status_ON", "Opt_Scoring_Status_ON", SqlDbType.Bit, false);
                this.Opt_SchemeChatRoom_StopChatDaysAfterOpened = new MSSQL.Field(this, "Opt_SchemeChatRoom_StopChatDaysAfterOpened", "Opt_SchemeChatRoom_StopChatDaysAfterOpened", SqlDbType.SmallInt, false);
                this.Opt_SchemeChatRoom_MaxChatNumberOf = new MSSQL.Field(this, "Opt_SchemeChatRoom_MaxChatNumberOf", "Opt_SchemeChatRoom_MaxChatNumberOf", SqlDbType.SmallInt, false);
                this.Opt_isShowFloatAD = new MSSQL.Field(this, "Opt_isShowFloatAD", "Opt_isShowFloatAD", SqlDbType.Bit, false);
                this.Opt_MemberSharing_Alipay_Status_ON = new MSSQL.Field(this, "Opt_MemberSharing_Alipay_Status_ON", "Opt_MemberSharing_Alipay_Status_ON", SqlDbType.Bit, false);
                this.Opt_CpsBonusScale = new MSSQL.Field(this, "Opt_CpsBonusScale", "Opt_CpsBonusScale", SqlDbType.Float, false);
                this.Opt_Cps_Status_ON = new MSSQL.Field(this, "Opt_Cps_Status_ON", "Opt_Cps_Status_ON", SqlDbType.Bit, false);
                this.Opt_Experts_Status_ON = new MSSQL.Field(this, "Opt_Experts_Status_ON", "Opt_Experts_Status_ON", SqlDbType.Bit, false);
                this.Opt_PageTitle = new MSSQL.Field(this, "Opt_PageTitle", "Opt_PageTitle", SqlDbType.VarChar, false);
                this.Opt_PageKeywords = new MSSQL.Field(this, "Opt_PageKeywords", "Opt_PageKeywords", SqlDbType.VarChar, false);
                this.Opt_DefaultFirstPageType = new MSSQL.Field(this, "Opt_DefaultFirstPageType", "Opt_DefaultFirstPageType", SqlDbType.SmallInt, false);
                this.Opt_DefaultLotteryFirstPageType = new MSSQL.Field(this, "Opt_DefaultLotteryFirstPageType", "Opt_DefaultLotteryFirstPageType", SqlDbType.SmallInt, false);
                this.Opt_LotteryChannelPage = new MSSQL.Field(this, "Opt_LotteryChannelPage", "Opt_LotteryChannelPage", SqlDbType.VarChar, false);
                this.Opt_isShowSMSSubscriptionNavigate = new MSSQL.Field(this, "Opt_isShowSMSSubscriptionNavigate", "Opt_isShowSMSSubscriptionNavigate", SqlDbType.Bit, false);
                this.Opt_isShowChartNavigate = new MSSQL.Field(this, "Opt_isShowChartNavigate", "Opt_isShowChartNavigate", SqlDbType.Bit, false);
                this.Opt_RoomStyle = new MSSQL.Field(this, "Opt_RoomStyle", "Opt_RoomStyle", SqlDbType.SmallInt, false);
                this.Opt_RoomLogoUrl = new MSSQL.Field(this, "Opt_RoomLogoUrl", "Opt_RoomLogoUrl", SqlDbType.VarChar, false);
                this.Opt_UpdateLotteryDateTime = new MSSQL.Field(this, "Opt_UpdateLotteryDateTime", "Opt_UpdateLotteryDateTime", SqlDbType.DateTime, false);
                this.Opt_InitiateSchemeLimitLowerScaleMoney = new MSSQL.Field(this, "Opt_InitiateSchemeLimitLowerScaleMoney", "Opt_InitiateSchemeLimitLowerScaleMoney", SqlDbType.Money, false);
                this.Opt_InitiateSchemeLimitLowerScale = new MSSQL.Field(this, "Opt_InitiateSchemeLimitLowerScale", "Opt_InitiateSchemeLimitLowerScale", SqlDbType.Float, false);
                this.Opt_InitiateSchemeLimitUpperScaleMoney = new MSSQL.Field(this, "Opt_InitiateSchemeLimitUpperScaleMoney", "Opt_InitiateSchemeLimitUpperScaleMoney", SqlDbType.Money, false);
                this.Opt_InitiateSchemeLimitUpperScale = new MSSQL.Field(this, "Opt_InitiateSchemeLimitUpperScale", "Opt_InitiateSchemeLimitUpperScale", SqlDbType.Float, false);
                this.Opt_About = new MSSQL.Field(this, "Opt_About", "Opt_About", SqlDbType.VarChar, false);
                this.Opt_RightFloatADContent = new MSSQL.Field(this, "Opt_RightFloatADContent", "Opt_RightFloatADContent", SqlDbType.VarChar, false);
                this.Opt_ContactUS = new MSSQL.Field(this, "Opt_ContactUS", "Opt_ContactUS", SqlDbType.VarChar, false);
                this.Opt_UserRegisterAgreement = new MSSQL.Field(this, "Opt_UserRegisterAgreement", "Opt_UserRegisterAgreement", SqlDbType.VarChar, false);
                this.Opt_SurrogateFAQ = new MSSQL.Field(this, "Opt_SurrogateFAQ", "Opt_SurrogateFAQ", SqlDbType.VarChar, false);
                this.Opt_OfficialAuthorization = new MSSQL.Field(this, "Opt_OfficialAuthorization", "Opt_OfficialAuthorization", SqlDbType.VarChar, false);
                this.Opt_CompanyQualification = new MSSQL.Field(this, "Opt_CompanyQualification", "Opt_CompanyQualification", SqlDbType.VarChar, false);
                this.Opt_ExpertsNote = new MSSQL.Field(this, "Opt_ExpertsNote", "Opt_ExpertsNote", SqlDbType.VarChar, false);
                this.Opt_SMSSubscription = new MSSQL.Field(this, "Opt_SMSSubscription", "Opt_SMSSubscription", SqlDbType.VarChar, false);
                this.Opt_LawAffirmsThat = new MSSQL.Field(this, "Opt_LawAffirmsThat", "Opt_LawAffirmsThat", SqlDbType.VarChar, false);
                this.Opt_CpsPolicies = new MSSQL.Field(this, "Opt_CpsPolicies", "Opt_CpsPolicies", SqlDbType.VarChar, false);
                this.TemplateEmail_Register = new MSSQL.Field(this, "TemplateEmail_Register", "TemplateEmail_Register", SqlDbType.VarChar, false);
                this.TemplateEmail_RegisterAdv = new MSSQL.Field(this, "TemplateEmail_RegisterAdv", "TemplateEmail_RegisterAdv", SqlDbType.VarChar, false);
                this.TemplateEmail_ForgetPassword = new MSSQL.Field(this, "TemplateEmail_ForgetPassword", "TemplateEmail_ForgetPassword", SqlDbType.VarChar, false);
                this.TemplateEmail_UserEdit = new MSSQL.Field(this, "TemplateEmail_UserEdit", "TemplateEmail_UserEdit", SqlDbType.VarChar, false);
                this.TemplateEmail_UserEditAdv = new MSSQL.Field(this, "TemplateEmail_UserEditAdv", "TemplateEmail_UserEditAdv", SqlDbType.VarChar, false);
                this.TemplateEmail_InitiateScheme = new MSSQL.Field(this, "TemplateEmail_InitiateScheme", "TemplateEmail_InitiateScheme", SqlDbType.VarChar, false);
                this.TemplateEmail_JoinScheme = new MSSQL.Field(this, "TemplateEmail_JoinScheme", "TemplateEmail_JoinScheme", SqlDbType.VarChar, false);
                this.TemplateEmail_InitiateChaseTask = new MSSQL.Field(this, "TemplateEmail_InitiateChaseTask", "TemplateEmail_InitiateChaseTask", SqlDbType.VarChar, false);
                this.TemplateEmail_ExecChaseTaskDetail = new MSSQL.Field(this, "TemplateEmail_ExecChaseTaskDetail", "TemplateEmail_ExecChaseTaskDetail", SqlDbType.VarChar, false);
                this.TemplateEmail_TryDistill = new MSSQL.Field(this, "TemplateEmail_TryDistill", "TemplateEmail_TryDistill", SqlDbType.VarChar, false);
                this.TemplateEmail_DistillAccept = new MSSQL.Field(this, "TemplateEmail_DistillAccept", "TemplateEmail_DistillAccept", SqlDbType.VarChar, false);
                this.TemplateEmail_DistillNoAccept = new MSSQL.Field(this, "TemplateEmail_DistillNoAccept", "TemplateEmail_DistillNoAccept", SqlDbType.VarChar, false);
                this.TemplateEmail_Quash = new MSSQL.Field(this, "TemplateEmail_Quash", "TemplateEmail_Quash", SqlDbType.VarChar, false);
                this.TemplateEmail_QuashScheme = new MSSQL.Field(this, "TemplateEmail_QuashScheme", "TemplateEmail_QuashScheme", SqlDbType.VarChar, false);
                this.TemplateEmail_QuashChaseTaskDetail = new MSSQL.Field(this, "TemplateEmail_QuashChaseTaskDetail", "TemplateEmail_QuashChaseTaskDetail", SqlDbType.VarChar, false);
                this.TemplateEmail_QuashChaseTask = new MSSQL.Field(this, "TemplateEmail_QuashChaseTask", "TemplateEmail_QuashChaseTask", SqlDbType.VarChar, false);
                this.TemplateEmail_Win = new MSSQL.Field(this, "TemplateEmail_Win", "TemplateEmail_Win", SqlDbType.VarChar, false);
                this.TemplateEmail_MobileValid = new MSSQL.Field(this, "TemplateEmail_MobileValid", "TemplateEmail_MobileValid", SqlDbType.VarChar, false);
                this.TemplateEmail_MobileValided = new MSSQL.Field(this, "TemplateEmail_MobileValided", "TemplateEmail_MobileValided", SqlDbType.VarChar, false);
                this.TemplateStationSMS_Register = new MSSQL.Field(this, "TemplateStationSMS_Register", "TemplateStationSMS_Register", SqlDbType.VarChar, false);
                this.TemplateStationSMS_RegisterAdv = new MSSQL.Field(this, "TemplateStationSMS_RegisterAdv", "TemplateStationSMS_RegisterAdv", SqlDbType.VarChar, false);
                this.TemplateStationSMS_ForgetPassword = new MSSQL.Field(this, "TemplateStationSMS_ForgetPassword", "TemplateStationSMS_ForgetPassword", SqlDbType.VarChar, false);
                this.TemplateStationSMS_UserEdit = new MSSQL.Field(this, "TemplateStationSMS_UserEdit", "TemplateStationSMS_UserEdit", SqlDbType.VarChar, false);
                this.TemplateStationSMS_UserEditAdv = new MSSQL.Field(this, "TemplateStationSMS_UserEditAdv", "TemplateStationSMS_UserEditAdv", SqlDbType.VarChar, false);
                this.TemplateStationSMS_InitiateScheme = new MSSQL.Field(this, "TemplateStationSMS_InitiateScheme", "TemplateStationSMS_InitiateScheme", SqlDbType.VarChar, false);
                this.TemplateStationSMS_JoinScheme = new MSSQL.Field(this, "TemplateStationSMS_JoinScheme", "TemplateStationSMS_JoinScheme", SqlDbType.VarChar, false);
                this.TemplateStationSMS_InitiateChaseTask = new MSSQL.Field(this, "TemplateStationSMS_InitiateChaseTask", "TemplateStationSMS_InitiateChaseTask", SqlDbType.VarChar, false);
                this.TemplateStationSMS_ExecChaseTaskDetail = new MSSQL.Field(this, "TemplateStationSMS_ExecChaseTaskDetail", "TemplateStationSMS_ExecChaseTaskDetail", SqlDbType.VarChar, false);
                this.TemplateStationSMS_TryDistill = new MSSQL.Field(this, "TemplateStationSMS_TryDistill", "TemplateStationSMS_TryDistill", SqlDbType.VarChar, false);
                this.TemplateStationSMS_DistillAccept = new MSSQL.Field(this, "TemplateStationSMS_DistillAccept", "TemplateStationSMS_DistillAccept", SqlDbType.VarChar, false);
                this.TemplateStationSMS_DistillNoAccept = new MSSQL.Field(this, "TemplateStationSMS_DistillNoAccept", "TemplateStationSMS_DistillNoAccept", SqlDbType.VarChar, false);
                this.TemplateStationSMS_Quash = new MSSQL.Field(this, "TemplateStationSMS_Quash", "TemplateStationSMS_Quash", SqlDbType.VarChar, false);
                this.TemplateStationSMS_QuashScheme = new MSSQL.Field(this, "TemplateStationSMS_QuashScheme", "TemplateStationSMS_QuashScheme", SqlDbType.VarChar, false);
                this.TemplateStationSMS_QuashChaseTaskDetail = new MSSQL.Field(this, "TemplateStationSMS_QuashChaseTaskDetail", "TemplateStationSMS_QuashChaseTaskDetail", SqlDbType.VarChar, false);
                this.TemplateStationSMS_QuashChaseTask = new MSSQL.Field(this, "TemplateStationSMS_QuashChaseTask", "TemplateStationSMS_QuashChaseTask", SqlDbType.VarChar, false);
                this.TemplateStationSMS_Win = new MSSQL.Field(this, "TemplateStationSMS_Win", "TemplateStationSMS_Win", SqlDbType.VarChar, false);
                this.TemplateStationSMS_MobileValid = new MSSQL.Field(this, "TemplateStationSMS_MobileValid", "TemplateStationSMS_MobileValid", SqlDbType.VarChar, false);
                this.TemplateStationSMS_MobileValided = new MSSQL.Field(this, "TemplateStationSMS_MobileValided", "TemplateStationSMS_MobileValided", SqlDbType.VarChar, false);
                this.TemplateSMS_Register = new MSSQL.Field(this, "TemplateSMS_Register", "TemplateSMS_Register", SqlDbType.VarChar, false);
                this.TemplateSMS_RegisterAdv = new MSSQL.Field(this, "TemplateSMS_RegisterAdv", "TemplateSMS_RegisterAdv", SqlDbType.VarChar, false);
                this.TemplateSMS_ForgetPassword = new MSSQL.Field(this, "TemplateSMS_ForgetPassword", "TemplateSMS_ForgetPassword", SqlDbType.VarChar, false);
                this.TemplateSMS_UserEdit = new MSSQL.Field(this, "TemplateSMS_UserEdit", "TemplateSMS_UserEdit", SqlDbType.VarChar, false);
                this.TemplateSMS_UserEditAdv = new MSSQL.Field(this, "TemplateSMS_UserEditAdv", "TemplateSMS_UserEditAdv", SqlDbType.VarChar, false);
                this.TemplateSMS_InitiateScheme = new MSSQL.Field(this, "TemplateSMS_InitiateScheme", "TemplateSMS_InitiateScheme", SqlDbType.VarChar, false);
                this.TemplateSMS_JoinScheme = new MSSQL.Field(this, "TemplateSMS_JoinScheme", "TemplateSMS_JoinScheme", SqlDbType.VarChar, false);
                this.TemplateSMS_InitiateChaseTask = new MSSQL.Field(this, "TemplateSMS_InitiateChaseTask", "TemplateSMS_InitiateChaseTask", SqlDbType.VarChar, false);
                this.TemplateSMS_ExecChaseTaskDetail = new MSSQL.Field(this, "TemplateSMS_ExecChaseTaskDetail", "TemplateSMS_ExecChaseTaskDetail", SqlDbType.VarChar, false);
                this.TemplateSMS_TryDistill = new MSSQL.Field(this, "TemplateSMS_TryDistill", "TemplateSMS_TryDistill", SqlDbType.VarChar, false);
                this.TemplateSMS_DistillAccept = new MSSQL.Field(this, "TemplateSMS_DistillAccept", "TemplateSMS_DistillAccept", SqlDbType.VarChar, false);
                this.TemplateSMS_DistillNoAccept = new MSSQL.Field(this, "TemplateSMS_DistillNoAccept", "TemplateSMS_DistillNoAccept", SqlDbType.VarChar, false);
                this.TemplateSMS_Quash = new MSSQL.Field(this, "TemplateSMS_Quash", "TemplateSMS_Quash", SqlDbType.VarChar, false);
                this.TemplateSMS_QuashScheme = new MSSQL.Field(this, "TemplateSMS_QuashScheme", "TemplateSMS_QuashScheme", SqlDbType.VarChar, false);
                this.TemplateSMS_QuashChaseTaskDetail = new MSSQL.Field(this, "TemplateSMS_QuashChaseTaskDetail", "TemplateSMS_QuashChaseTaskDetail", SqlDbType.VarChar, false);
                this.TemplateSMS_QuashChaseTask = new MSSQL.Field(this, "TemplateSMS_QuashChaseTask", "TemplateSMS_QuashChaseTask", SqlDbType.VarChar, false);
                this.TemplateSMS_Win = new MSSQL.Field(this, "TemplateSMS_Win", "TemplateSMS_Win", SqlDbType.VarChar, false);
                this.TemplateSMS_MobileValid = new MSSQL.Field(this, "TemplateSMS_MobileValid", "TemplateSMS_MobileValid", SqlDbType.VarChar, false);
                this.TemplateSMS_MobileValided = new MSSQL.Field(this, "TemplateSMS_MobileValided", "TemplateSMS_MobileValided", SqlDbType.VarChar, false);
                this.Opt_CPSRegisterAgreement = new MSSQL.Field(this, "Opt_CPSRegisterAgreement", "Opt_CPSRegisterAgreement", SqlDbType.VarChar, false);
                this.Opt_PromotionMemberBonusScale = new MSSQL.Field(this, "Opt_PromotionMemberBonusScale", "Opt_PromotionMemberBonusScale", SqlDbType.Float, false);
                this.Opt_PromotionSiteBonusScale = new MSSQL.Field(this, "Opt_PromotionSiteBonusScale", "Opt_PromotionSiteBonusScale", SqlDbType.Float, false);
                this.Opt_Promotion_Status_ON = new MSSQL.Field(this, "Opt_Promotion_Status_ON", "Opt_Promotion_Status_ON", SqlDbType.Bit, false);
                this.Opt_FloatNotifiesTime = new MSSQL.Field(this, "Opt_FloatNotifiesTime", "Opt_FloatNotifiesTime", SqlDbType.SmallInt, false);
                this.Opt_Score_Compendium = new MSSQL.Field(this, "Opt_Score_Compendium", "Opt_Score_Compendium", SqlDbType.Decimal, false);
                this.Opt_Score_PrententType = new MSSQL.Field(this, "Opt_Score_PrententType", "Opt_Score_PrententType", SqlDbType.SmallInt, false);
                this.TemplateEmail_IntiateCustomChase = new MSSQL.Field(this, "TemplateEmail_IntiateCustomChase", "TemplateEmail_IntiateCustomChase", SqlDbType.VarChar, false);
                this.TemplateStationSMS_IntiateCustomChase = new MSSQL.Field(this, "TemplateStationSMS_IntiateCustomChase", "TemplateStationSMS_IntiateCustomChase", SqlDbType.VarChar, false);
                this.TemplateSMS_IntiateCustomChase = new MSSQL.Field(this, "TemplateSMS_IntiateCustomChase", "TemplateSMS_IntiateCustomChase", SqlDbType.VarChar, false);
                this.TemplateEmail_CustomChaseWin = new MSSQL.Field(this, "TemplateEmail_CustomChaseWin", "TemplateEmail_CustomChaseWin", SqlDbType.VarChar, false);
                this.TemplateStationSMS_CustomChaseWin = new MSSQL.Field(this, "TemplateStationSMS_CustomChaseWin", "TemplateStationSMS_CustomChaseWin", SqlDbType.VarChar, false);
                this.TemplateSMS_CustomChaseWin = new MSSQL.Field(this, "TemplateSMS_CustomChaseWin", "TemplateSMS_CustomChaseWin", SqlDbType.VarChar, false);
            }
        }

        public class T_SiteSendNotificationTypes : MSSQL.TableBase
        {
            public MSSQL.Field Manner;
            public MSSQL.Field NotificationTypeID;
            public MSSQL.Field SiteID;

            public T_SiteSendNotificationTypes()
            {
                base.TableName = "T_SiteSendNotificationTypes";
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.Manner = new MSSQL.Field(this, "Manner", "Manner", SqlDbType.SmallInt, false);
                this.NotificationTypeID = new MSSQL.Field(this, "NotificationTypeID", "NotificationTypeID", SqlDbType.SmallInt, false);
            }
        }

        public class T_SiteUrls : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field SiteID;
            public MSSQL.Field Url;

            public T_SiteUrls()
            {
                base.TableName = "T_SiteUrls";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.Url = new MSSQL.Field(this, "Url", "Url", SqlDbType.VarChar, false);
            }
        }

        public class T_SMS : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field From;
            public MSSQL.Field ID;
            public MSSQL.Field IsSent;
            public MSSQL.Field SiteID;
            public MSSQL.Field SMSID;
            public MSSQL.Field To;

            public T_SMS()
            {
                base.TableName = "T_SMS";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.SMSID = new MSSQL.Field(this, "SMSID", "SMSID", SqlDbType.BigInt, false);
                this.From = new MSSQL.Field(this, "From", "From", SqlDbType.VarChar, false);
                this.To = new MSSQL.Field(this, "To", "To", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
                this.IsSent = new MSSQL.Field(this, "IsSent", "IsSent", SqlDbType.Bit, false);
            }
        }

        public class T_SmsBettings : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field From;
            public MSSQL.Field HandleDescription;
            public MSSQL.Field HandleResult;
            public MSSQL.Field ID;
            public MSSQL.Field SchemeID;
            public MSSQL.Field SiteID;
            public MSSQL.Field SMSID;

            public T_SmsBettings()
            {
                base.TableName = "T_SmsBettings";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.SMSID = new MSSQL.Field(this, "SMSID", "SMSID", SqlDbType.BigInt, false);
                this.From = new MSSQL.Field(this, "From", "From", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.HandleResult = new MSSQL.Field(this, "HandleResult", "HandleResult", SqlDbType.Bit, false);
                this.HandleDescription = new MSSQL.Field(this, "HandleDescription", "HandleDescription", SqlDbType.VarChar, false);
            }
        }

        public class T_SNSFeedTemplate : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field ID;
            public MSSQL.Field OperateID;
            public MSSQL.Field Title;
            public MSSQL.Field Type;

            public T_SNSFeedTemplate()
            {
                base.TableName = "T_SNSFeedTemplate";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
                this.Type = new MSSQL.Field(this, "Type", "Type", SqlDbType.VarChar, false);
                this.OperateID = new MSSQL.Field(this, "OperateID", "OperateID", SqlDbType.Int, false);
            }
        }

        public class T_SoftDownloads : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field FileUrl;
            public MSSQL.Field ID;
            public MSSQL.Field ImageUrl;
            public MSSQL.Field isCommend;
            public MSSQL.Field isHot;
            public MSSQL.Field isShow;
            public MSSQL.Field LotteryID;
            public MSSQL.Field ReadCount;
            public MSSQL.Field SiteID;
            public MSSQL.Field Title;

            public T_SoftDownloads()
            {
                base.TableName = "T_SoftDownloads";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.FileUrl = new MSSQL.Field(this, "FileUrl", "FileUrl", SqlDbType.VarChar, false);
                this.ImageUrl = new MSSQL.Field(this, "ImageUrl", "ImageUrl", SqlDbType.VarChar, false);
                this.isHot = new MSSQL.Field(this, "isHot", "isHot", SqlDbType.Bit, false);
                this.isCommend = new MSSQL.Field(this, "isCommend", "isCommend", SqlDbType.Bit, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
                this.ReadCount = new MSSQL.Field(this, "ReadCount", "ReadCount", SqlDbType.Int, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_StationSMS : MSSQL.TableBase
        {
            public MSSQL.Field AimID;
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field isRead;
            public MSSQL.Field isShow;
            public MSSQL.Field SiteID;
            public MSSQL.Field SourceID;
            public MSSQL.Field Type;

            public T_StationSMS()
            {
                base.TableName = "T_StationSMS";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.SourceID = new MSSQL.Field(this, "SourceID", "SourceID", SqlDbType.BigInt, false);
                this.AimID = new MSSQL.Field(this, "AimID", "AimID", SqlDbType.BigInt, false);
                this.Type = new MSSQL.Field(this, "Type", "Type", SqlDbType.SmallInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
                this.isRead = new MSSQL.Field(this, "isRead", "isRead", SqlDbType.Bit, false);
            }
        }

        public class T_SurrogateNotifications : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field isShow;
            public MSSQL.Field SiteID;
            public MSSQL.Field Title;

            public T_SurrogateNotifications()
            {
                base.TableName = "T_SurrogateNotifications";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Title = new MSSQL.Field(this, "Title", "Title", SqlDbType.VarChar, false);
                this.isShow = new MSSQL.Field(this, "isShow", "isShow", SqlDbType.Bit, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_SurrogateTrys : MSSQL.TableBase
        {
            public MSSQL.Field Address;
            public MSSQL.Field Company;
            public MSSQL.Field ContactPerson;
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field Email;
            public MSSQL.Field Fax;
            public MSSQL.Field HandlelDateTime;
            public MSSQL.Field HandleResult;
            public MSSQL.Field ID;
            public MSSQL.Field LogoUrl;
            public MSSQL.Field Mobile;
            public MSSQL.Field Name;
            public MSSQL.Field PostCode;
            public MSSQL.Field QQ;
            public MSSQL.Field ResponsiblePerson;
            public MSSQL.Field ServiceTelephone;
            public MSSQL.Field SiteID;
            public MSSQL.Field Telephone;
            public MSSQL.Field Urls;
            public MSSQL.Field UseLotteryList;
            public MSSQL.Field UserID;

            public T_SurrogateTrys()
            {
                base.TableName = "T_SurrogateTrys";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.HandleResult = new MSSQL.Field(this, "HandleResult", "HandleResult", SqlDbType.SmallInt, false);
                this.HandlelDateTime = new MSSQL.Field(this, "HandlelDateTime", "HandlelDateTime", SqlDbType.DateTime, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.LogoUrl = new MSSQL.Field(this, "LogoUrl", "LogoUrl", SqlDbType.VarChar, false);
                this.Company = new MSSQL.Field(this, "Company", "Company", SqlDbType.VarChar, false);
                this.Address = new MSSQL.Field(this, "Address", "Address", SqlDbType.VarChar, false);
                this.PostCode = new MSSQL.Field(this, "PostCode", "PostCode", SqlDbType.VarChar, false);
                this.ResponsiblePerson = new MSSQL.Field(this, "ResponsiblePerson", "ResponsiblePerson", SqlDbType.VarChar, false);
                this.ContactPerson = new MSSQL.Field(this, "ContactPerson", "ContactPerson", SqlDbType.VarChar, false);
                this.Telephone = new MSSQL.Field(this, "Telephone", "Telephone", SqlDbType.VarChar, false);
                this.Fax = new MSSQL.Field(this, "Fax", "Fax", SqlDbType.VarChar, false);
                this.Mobile = new MSSQL.Field(this, "Mobile", "Mobile", SqlDbType.VarChar, false);
                this.Email = new MSSQL.Field(this, "Email", "Email", SqlDbType.VarChar, false);
                this.QQ = new MSSQL.Field(this, "QQ", "QQ", SqlDbType.VarChar, false);
                this.ServiceTelephone = new MSSQL.Field(this, "ServiceTelephone", "ServiceTelephone", SqlDbType.VarChar, false);
                this.UseLotteryList = new MSSQL.Field(this, "UseLotteryList", "UseLotteryList", SqlDbType.VarChar, false);
                this.Urls = new MSSQL.Field(this, "Urls", "Urls", SqlDbType.VarChar, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_SystemLog : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field Description;
            public MSSQL.Field ID;
            public MSSQL.Field IPAddress;
            public MSSQL.Field SiteID;
            public MSSQL.Field UserID;

            public T_SystemLog()
            {
                base.TableName = "T_SystemLog";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.IPAddress = new MSSQL.Field(this, "IPAddress", "IPAddress", SqlDbType.VarChar, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.SmallInt, false);
            }
        }

        public class T_TestNumber : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field IsuseID;
            public MSSQL.Field TestNumber;

            public T_TestNumber()
            {
                base.TableName = "T_TestNumber";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.TestNumber = new MSSQL.Field(this, "TestNumber", "TestNumber", SqlDbType.VarChar, false);
            }
        }

        public class T_TomActivities : MSSQL.TableBase
        {
            public MSSQL.Field AlipayName;
            public MSSQL.Field DateTime;
            public MSSQL.Field DayBalanceAdd;
            public MSSQL.Field DaySchemeMoney;
            public MSSQL.Field DayWinMoney;
            public MSSQL.Field ID;
            public MSSQL.Field IsReward1;
            public MSSQL.Field IsReward10;
            public MSSQL.Field IsReward2;
            public MSSQL.Field IsReward200;
            public MSSQL.Field UserID;

            public T_TomActivities()
            {
                base.TableName = "T_TomActivities";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.AlipayName = new MSSQL.Field(this, "AlipayName", "AlipayName", SqlDbType.VarChar, false);
                this.IsReward1 = new MSSQL.Field(this, "IsReward1", "IsReward1", SqlDbType.Bit, false);
                this.DayBalanceAdd = new MSSQL.Field(this, "DayBalanceAdd", "DayBalanceAdd", SqlDbType.Money, false);
                this.IsReward2 = new MSSQL.Field(this, "IsReward2", "IsReward2", SqlDbType.Bit, false);
                this.DaySchemeMoney = new MSSQL.Field(this, "DaySchemeMoney", "DaySchemeMoney", SqlDbType.Money, false);
                this.IsReward10 = new MSSQL.Field(this, "IsReward10", "IsReward10", SqlDbType.Bit, false);
                this.DayWinMoney = new MSSQL.Field(this, "DayWinMoney", "DayWinMoney", SqlDbType.Money, false);
                this.IsReward200 = new MSSQL.Field(this, "IsReward200", "IsReward200", SqlDbType.Bit, false);
            }
        }

        public class T_TotalMoney : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field IsuseID;
            public MSSQL.Field TotalMoney;

            public T_TotalMoney()
            {
                base.TableName = "T_TotalMoney";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.IsuseID = new MSSQL.Field(this, "IsuseID", "IsuseID", SqlDbType.BigInt, false);
                this.TotalMoney = new MSSQL.Field(this, "TotalMoney", "TotalMoney", SqlDbType.VarChar, false);
            }
        }

        public class T_TransferDetails : MSSQL.TableBase
        {
            public MSSQL.Field AcceptDateTime;
            public MSSQL.Field DateTime;
            public MSSQL.Field FormalitiesFees;
            public MSSQL.Field ID;
            public MSSQL.Field Memo;
            public MSSQL.Field Money;
            public MSSQL.Field Name;
            public MSSQL.Field NickName;
            public MSSQL.Field RelatedName;
            public MSSQL.Field RelatedNickName;
            public MSSQL.Field RelatedUserID;
            public MSSQL.Field Result;
            public MSSQL.Field SecurityAnswer;
            public MSSQL.Field SiteID;
            public MSSQL.Field UserID;

            public T_TransferDetails()
            {
                base.TableName = "T_TransferDetails";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.FormalitiesFees = new MSSQL.Field(this, "FormalitiesFees", "FormalitiesFees", SqlDbType.Money, false);
                this.RelatedUserID = new MSSQL.Field(this, "RelatedUserID", "RelatedUserID", SqlDbType.BigInt, false);
                this.AcceptDateTime = new MSSQL.Field(this, "AcceptDateTime", "AcceptDateTime", SqlDbType.DateTime, false);
                this.Result = new MSSQL.Field(this, "Result", "Result", SqlDbType.SmallInt, false);
                this.SecurityAnswer = new MSSQL.Field(this, "SecurityAnswer", "SecurityAnswer", SqlDbType.NVarChar, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.NickName = new MSSQL.Field(this, "NickName", "NickName", SqlDbType.VarChar, false);
                this.RelatedName = new MSSQL.Field(this, "RelatedName", "RelatedName", SqlDbType.VarChar, false);
                this.RelatedNickName = new MSSQL.Field(this, "RelatedNickName", "RelatedNickName", SqlDbType.VarChar, false);
                this.Memo = new MSSQL.Field(this, "Memo", "Memo", SqlDbType.VarChar, false);
            }
        }

        public class T_TrendCharts : MSSQL.TableBase
        {
            public MSSQL.Field ID;
            public MSSQL.Field LotteryID;
            public MSSQL.Field Order;
            public MSSQL.Field TrendChartName;
            public MSSQL.Field TrendChartUrl;

            public T_TrendCharts()
            {
                base.TableName = "T_TrendCharts";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.TrendChartName = new MSSQL.Field(this, "TrendChartName", "TrendChartName", SqlDbType.VarChar, false);
                this.TrendChartUrl = new MSSQL.Field(this, "TrendChartUrl", "TrendChartUrl", SqlDbType.VarChar, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.Int, false);
            }
        }

        public class T_UnionLinkScale : MSSQL.TableBase
        {
            public MSSQL.Field BonusScale;
            public MSSQL.Field ID;
            public MSSQL.Field SiteLinkPID;
            public MSSQL.Field UnionID;

            public T_UnionLinkScale()
            {
                base.TableName = "T_UnionLinkScale";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UnionID = new MSSQL.Field(this, "UnionID", "UnionID", SqlDbType.BigInt, false);
                this.SiteLinkPID = new MSSQL.Field(this, "SiteLinkPID", "SiteLinkPID", SqlDbType.VarChar, false);
                this.BonusScale = new MSSQL.Field(this, "BonusScale", "BonusScale", SqlDbType.Decimal, false);
            }
        }

        public class T_UserAcceptNotificationTypes : MSSQL.TableBase
        {
            public MSSQL.Field Manner;
            public MSSQL.Field NotificationTypeID;
            public MSSQL.Field UserID;

            public T_UserAcceptNotificationTypes()
            {
                base.TableName = "T_UserAcceptNotificationTypes";
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.Manner = new MSSQL.Field(this, "Manner", "Manner", SqlDbType.SmallInt, false);
                this.NotificationTypeID = new MSSQL.Field(this, "NotificationTypeID", "NotificationTypeID", SqlDbType.SmallInt, false);
            }
        }

        public class T_UserActions : MSSQL.TableBase
        {
            public MSSQL.Field Action;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field LastSchemeID;
            public MSSQL.Field UserID;

            public T_UserActions()
            {
                base.TableName = "T_UserActions";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.Action = new MSSQL.Field(this, "Action", "Action", SqlDbType.VarChar, false);
                this.LastSchemeID = new MSSQL.Field(this, "LastSchemeID", "LastSchemeID", SqlDbType.BigInt, false);
            }
        }

        public class T_UserBankBindDetails : MSSQL.TableBase
        {
            public MSSQL.Field BankCardNumber;
            public MSSQL.Field BankInCityName;
            public MSSQL.Field BankInProvinceName;
            public MSSQL.Field BankName;
            public MSSQL.Field BankType;
            public MSSQL.Field BankTypeName;
            public MSSQL.Field BankUserName;
            public MSSQL.Field UserID;

            public T_UserBankBindDetails()
            {
                base.TableName = "T_UserBankBindDetails";
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.BankType = new MSSQL.Field(this, "BankType", "BankType", SqlDbType.BigInt, false);
                this.BankName = new MSSQL.Field(this, "BankName", "BankName", SqlDbType.VarChar, false);
                this.BankCardNumber = new MSSQL.Field(this, "BankCardNumber", "BankCardNumber", SqlDbType.VarChar, false);
                this.BankInProvinceName = new MSSQL.Field(this, "BankInProvinceName", "BankInProvinceName", SqlDbType.VarChar, false);
                this.BankInCityName = new MSSQL.Field(this, "BankInCityName", "BankInCityName", SqlDbType.VarChar, false);
                this.BankUserName = new MSSQL.Field(this, "BankUserName", "BankUserName", SqlDbType.VarChar, false);
                this.BankTypeName = new MSSQL.Field(this, "BankTypeName", "BankTypeName", SqlDbType.VarChar, false);
            }
        }

        public class T_UserDetails : MSSQL.TableBase
        {
            public MSSQL.Field AlipayID;
            public MSSQL.Field AlipayName;
            public MSSQL.Field DateTime;
            public MSSQL.Field FormalitiesFees;
            public MSSQL.Field ID;
            public MSSQL.Field Memo;
            public MSSQL.Field Money;
            public MSSQL.Field OperatorID;
            public MSSQL.Field OperatorType;
            public MSSQL.Field PayBank;
            public MSSQL.Field PayNumber;
            public MSSQL.Field RelatedUserID;
            public MSSQL.Field SchemeID;
            public MSSQL.Field SiteID;
            public MSSQL.Field UserID;

            public T_UserDetails()
            {
                base.TableName = "T_UserDetails";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.OperatorType = new MSSQL.Field(this, "OperatorType", "OperatorType", SqlDbType.SmallInt, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.FormalitiesFees = new MSSQL.Field(this, "FormalitiesFees", "FormalitiesFees", SqlDbType.Money, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.RelatedUserID = new MSSQL.Field(this, "RelatedUserID", "RelatedUserID", SqlDbType.BigInt, false);
                this.PayNumber = new MSSQL.Field(this, "PayNumber", "PayNumber", SqlDbType.VarChar, false);
                this.PayBank = new MSSQL.Field(this, "PayBank", "PayBank", SqlDbType.VarChar, false);
                this.Memo = new MSSQL.Field(this, "Memo", "Memo", SqlDbType.VarChar, false);
                this.OperatorID = new MSSQL.Field(this, "OperatorID", "OperatorID", SqlDbType.BigInt, false);
                this.AlipayID = new MSSQL.Field(this, "AlipayID", "AlipayID", SqlDbType.VarChar, false);
                this.AlipayName = new MSSQL.Field(this, "AlipayName", "AlipayName", SqlDbType.VarChar, false);
            }
        }

        public class T_UserDistillPayByAlipayLog : MSSQL.TableBase
        {
            public MSSQL.Field Content;
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;

            public T_UserDistillPayByAlipayLog()
            {
                base.TableName = "T_UserDistillPayByAlipayLog";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.SmallDateTime, false);
                this.Content = new MSSQL.Field(this, "Content", "Content", SqlDbType.VarChar, false);
            }
        }

        public class T_UserDistillPaymentFileDetaills : MSSQL.TableBase
        {
            public MSSQL.Field DistillID;
            public MSSQL.Field ID;
            public MSSQL.Field PaymentFileID;
            public MSSQL.Field SequenceNumber;

            public T_UserDistillPaymentFileDetaills()
            {
                base.TableName = "T_UserDistillPaymentFileDetaills";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.PaymentFileID = new MSSQL.Field(this, "PaymentFileID", "PaymentFileID", SqlDbType.BigInt, false);
                this.SequenceNumber = new MSSQL.Field(this, "SequenceNumber", "SequenceNumber", SqlDbType.BigInt, false);
                this.DistillID = new MSSQL.Field(this, "DistillID", "DistillID", SqlDbType.BigInt, false);
            }
        }

        public class T_UserDistillPaymentFiles : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field FileName;
            public MSSQL.Field HandleOperatorID;
            public MSSQL.Field id;
            public MSSQL.Field Result;
            public MSSQL.Field Type;

            public T_UserDistillPaymentFiles()
            {
                base.TableName = "T_UserDistillPaymentFiles";
                this.id = new MSSQL.Field(this, "id", "id", SqlDbType.BigInt, true);
                this.FileName = new MSSQL.Field(this, "FileName", "FileName", SqlDbType.VarChar, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Result = new MSSQL.Field(this, "Result", "Result", SqlDbType.Int, false);
                this.HandleOperatorID = new MSSQL.Field(this, "HandleOperatorID", "HandleOperatorID", SqlDbType.BigInt, false);
                this.Type = new MSSQL.Field(this, "Type", "Type", SqlDbType.Int, false);
            }
        }

        public class T_UserDistills : MSSQL.TableBase
        {
            public MSSQL.Field AlipayID;
            public MSSQL.Field AlipayName;
            public MSSQL.Field BankCardNumber;
            public MSSQL.Field BankInCity;
            public MSSQL.Field BankInProvince;
            public MSSQL.Field BankName;
            public MSSQL.Field BankTypeName;
            public MSSQL.Field BankUserName;
            public MSSQL.Field DateTime;
            public MSSQL.Field DistillType;
            public MSSQL.Field FormalitiesFees;
            public MSSQL.Field HandleDateTime;
            public MSSQL.Field HandleOperatorID;
            public MSSQL.Field ID;
            public MSSQL.Field IsCps;
            public MSSQL.Field Memo;
            public MSSQL.Field Money;
            public MSSQL.Field Result;
            public MSSQL.Field SiteID;
            public MSSQL.Field UserID;

            public T_UserDistills()
            {
                base.TableName = "T_UserDistills";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.FormalitiesFees = new MSSQL.Field(this, "FormalitiesFees", "FormalitiesFees", SqlDbType.Money, false);
                this.Result = new MSSQL.Field(this, "Result", "Result", SqlDbType.SmallInt, false);
                this.HandleDateTime = new MSSQL.Field(this, "HandleDateTime", "HandleDateTime", SqlDbType.DateTime, false);
                this.BankName = new MSSQL.Field(this, "BankName", "BankName", SqlDbType.VarChar, false);
                this.BankCardNumber = new MSSQL.Field(this, "BankCardNumber", "BankCardNumber", SqlDbType.VarChar, false);
                this.Memo = new MSSQL.Field(this, "Memo", "Memo", SqlDbType.VarChar, false);
                this.HandleOperatorID = new MSSQL.Field(this, "HandleOperatorID", "HandleOperatorID", SqlDbType.BigInt, false);
                this.BankUserName = new MSSQL.Field(this, "BankUserName", "BankUserName", SqlDbType.VarChar, false);
                this.AlipayID = new MSSQL.Field(this, "AlipayID", "AlipayID", SqlDbType.VarChar, false);
                this.AlipayName = new MSSQL.Field(this, "AlipayName", "AlipayName", SqlDbType.VarChar, false);
                this.DistillType = new MSSQL.Field(this, "DistillType", "DistillType", SqlDbType.Int, false);
                this.BankTypeName = new MSSQL.Field(this, "BankTypeName", "BankTypeName", SqlDbType.VarChar, false);
                this.BankInProvince = new MSSQL.Field(this, "BankInProvince", "BankInProvince", SqlDbType.VarChar, false);
                this.BankInCity = new MSSQL.Field(this, "BankInCity", "BankInCity", SqlDbType.VarChar, false);
                this.IsCps = new MSSQL.Field(this, "IsCps", "IsCps", SqlDbType.Bit, false);
            }
        }

        public class T_UserEditQuestionAnswer : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field QuestionAnswerState;
            public MSSQL.Field UserID;
            public MSSQL.Field ValidedCount;

            public T_UserEditQuestionAnswer()
            {
                base.TableName = "T_UserEditQuestionAnswer";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.Int, false);
                this.QuestionAnswerState = new MSSQL.Field(this, "QuestionAnswerState", "QuestionAnswerState", SqlDbType.Int, false);
                this.ValidedCount = new MSSQL.Field(this, "ValidedCount", "ValidedCount", SqlDbType.Int, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
            }
        }

        public class T_UserForInitiateFollowSchemeTrys : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field Description;
            public MSSQL.Field HandleDateTime;
            public MSSQL.Field HandleResult;
            public MSSQL.Field ID;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field SiteID;
            public MSSQL.Field UserID;

            public T_UserForInitiateFollowSchemeTrys()
            {
                base.TableName = "T_UserForInitiateFollowSchemeTrys";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.HandleResult = new MSSQL.Field(this, "HandleResult", "HandleResult", SqlDbType.SmallInt, false);
                this.HandleDateTime = new MSSQL.Field(this, "HandleDateTime", "HandleDateTime", SqlDbType.DateTime, false);
            }
        }

        public class T_UserGroups : MSSQL.TableBase
        {
            public MSSQL.Field Description;
            public MSSQL.Field ID;
            public MSSQL.Field Name;

            public T_UserGroups()
            {
                base.TableName = "T_UserGroups";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.SmallInt, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
            }
        }

        public class T_UserHongbaoPromotion : MSSQL.TableBase
        {
            public MSSQL.Field AcceptUserID;
            public MSSQL.Field CreateDate;
            public MSSQL.Field ExpiryDate;
            public MSSQL.Field ID;
            public MSSQL.Field Money;
            public MSSQL.Field URL;
            public MSSQL.Field UseDate;
            public MSSQL.Field UserID;

            public T_UserHongbaoPromotion()
            {
                base.TableName = "T_UserHongbaoPromotion";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.CreateDate = new MSSQL.Field(this, "CreateDate", "CreateDate", SqlDbType.DateTime, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.AcceptUserID = new MSSQL.Field(this, "AcceptUserID", "AcceptUserID", SqlDbType.BigInt, false);
                this.UseDate = new MSSQL.Field(this, "UseDate", "UseDate", SqlDbType.DateTime, false);
                this.ExpiryDate = new MSSQL.Field(this, "ExpiryDate", "ExpiryDate", SqlDbType.DateTime, false);
                this.URL = new MSSQL.Field(this, "URL", "URL", SqlDbType.NVarChar, false);
            }
        }

        public class T_UserHongbaoPromotionUsed : MSSQL.TableBase
        {
            public MSSQL.Field PromotionID;

            public T_UserHongbaoPromotionUsed()
            {
                base.TableName = "T_UserHongbaoPromotionUsed";
                this.PromotionID = new MSSQL.Field(this, "PromotionID", "PromotionID", SqlDbType.BigInt, false);
            }
        }

        public class T_UserInGroups : MSSQL.TableBase
        {
            public MSSQL.Field GroupID;
            public MSSQL.Field UserID;

            public T_UserInGroups()
            {
                base.TableName = "T_UserInGroups";
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.GroupID = new MSSQL.Field(this, "GroupID", "GroupID", SqlDbType.SmallInt, false);
            }
        }

        public class T_UserInSchemeChatRooms : MSSQL.TableBase
        {
            public MSSQL.Field LastAccessTime;
            public MSSQL.Field SchemeID;
            public MSSQL.Field UserID;

            public T_UserInSchemeChatRooms()
            {
                base.TableName = "T_UserInSchemeChatRooms";
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.LastAccessTime = new MSSQL.Field(this, "LastAccessTime", "LastAccessTime", SqlDbType.DateTime, false);
            }
        }

        public class T_UserPayDetails : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field FormalitiesFees;
            public MSSQL.Field ID;
            public MSSQL.Field Money;
            public MSSQL.Field PayType;
            public MSSQL.Field Result;
            public MSSQL.Field SiteID;
            public MSSQL.Field UserID;

            public T_UserPayDetails()
            {
                base.TableName = "T_UserPayDetails";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.PayType = new MSSQL.Field(this, "PayType", "PayType", SqlDbType.VarChar, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
                this.FormalitiesFees = new MSSQL.Field(this, "FormalitiesFees", "FormalitiesFees", SqlDbType.Money, false);
                this.Result = new MSSQL.Field(this, "Result", "Result", SqlDbType.SmallInt, false);
            }
        }

        public class T_UserPayNumberList : MSSQL.TableBase
        {
            public MSSQL.Field Money;
            public MSSQL.Field PayNumber;

            public T_UserPayNumberList()
            {
                base.TableName = "T_UserPayNumberList";
                this.PayNumber = new MSSQL.Field(this, "PayNumber", "PayNumber", SqlDbType.BigInt, false);
                this.Money = new MSSQL.Field(this, "Money", "Money", SqlDbType.Money, false);
            }
        }

        public class T_UserPayOutDetails_99Bill : MSSQL.TableBase
        {
            public MSSQL.Field CreditCharge;
            public MSSQL.Field DealCharge;
            public MSSQL.Field DealID;
            public MSSQL.Field DebitCharge;
            public MSSQL.Field DistillID;
            public MSSQL.Field FailureCause;
            public MSSQL.Field ID;
            public MSSQL.Field ResultFlag;

            public T_UserPayOutDetails_99Bill()
            {
                base.TableName = "T_UserPayOutDetails_99Bill";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.DistillID = new MSSQL.Field(this, "DistillID", "DistillID", SqlDbType.BigInt, false);
                this.DealCharge = new MSSQL.Field(this, "DealCharge", "DealCharge", SqlDbType.Money, false);
                this.DebitCharge = new MSSQL.Field(this, "DebitCharge", "DebitCharge", SqlDbType.Money, false);
                this.CreditCharge = new MSSQL.Field(this, "CreditCharge", "CreditCharge", SqlDbType.Money, false);
                this.DealID = new MSSQL.Field(this, "DealID", "DealID", SqlDbType.VarChar, false);
                this.ResultFlag = new MSSQL.Field(this, "ResultFlag", "ResultFlag", SqlDbType.Bit, false);
                this.FailureCause = new MSSQL.Field(this, "FailureCause", "FailureCause", SqlDbType.VarChar, false);
            }
        }

        public class T_Users : MSSQL.TableBase
        {
            public MSSQL.Field Address;
            public MSSQL.Field AlipayID;
            public MSSQL.Field AlipayName;
            public MSSQL.Field Balance;
            public MSSQL.Field BankCardNumber;
            public MSSQL.Field BankName;
            public MSSQL.Field BankType;
            public MSSQL.Field BirthDay;
            public MSSQL.Field Bonus;
            public MSSQL.Field BonusAllow;
            public MSSQL.Field BonusThisMonth;
            public MSSQL.Field BonusUse;
            public MSSQL.Field CityID;
            public MSSQL.Field ComeFrom;
            public MSSQL.Field CommenderID;
            public MSSQL.Field CpsID;
            public MSSQL.Field Email;
            public MSSQL.Field Freeze;
            public MSSQL.Field FriendList;
            public MSSQL.Field HeadUrl;
            public MSSQL.Field ID;
            public MSSQL.Field IDCardNumber;
            public MSSQL.Field isAlipayCps;
            public MSSQL.Field isAlipayNameValided;
            public MSSQL.Field isCanLogin;
            public MSSQL.Field IsCrossLogin;
            public MSSQL.Field isEmailValided;
            public MSSQL.Field isMobileValided;
            public MSSQL.Field isPrivacy;
            public MSSQL.Field IsQQValided;
            public MSSQL.Field Key;
            public MSSQL.Field LastLoginIP;
            public MSSQL.Field LastLoginTime;
            public MSSQL.Field Level;
            public MSSQL.Field LoginCount;
            public MSSQL.Field MaxFollowNumber;
            public MSSQL.Field Memo;
            public MSSQL.Field Mobile;
            public MSSQL.Field Name;
            public MSSQL.Field NickName;
            public MSSQL.Field Password;
            public MSSQL.Field PasswordAdv;
            public MSSQL.Field PromotionMemberBonusScale;
            public MSSQL.Field PromotionSiteBonusScale;
            public MSSQL.Field QQ;
            public MSSQL.Field RealityName;
            public MSSQL.Field Reason;
            public MSSQL.Field RegisterTime;
            public MSSQL.Field Reward;
            public MSSQL.Field Scoring;
            public MSSQL.Field ScoringOfCommendBuy;
            public MSSQL.Field ScoringOfSelfBuy;
            public MSSQL.Field SecurityAnswer;
            public MSSQL.Field SecurityQuestion;
            public MSSQL.Field Sex;
            public MSSQL.Field SiteID;
            public MSSQL.Field Telephone;
            public MSSQL.Field UserType;
            public MSSQL.Field VisitSource;

            public T_Users()
            {
                base.TableName = "T_Users";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.RealityName = new MSSQL.Field(this, "RealityName", "RealityName", SqlDbType.VarChar, false);
                this.Password = new MSSQL.Field(this, "Password", "Password", SqlDbType.VarChar, false);
                this.PasswordAdv = new MSSQL.Field(this, "PasswordAdv", "PasswordAdv", SqlDbType.VarChar, false);
                this.CityID = new MSSQL.Field(this, "CityID", "CityID", SqlDbType.Int, false);
                this.Sex = new MSSQL.Field(this, "Sex", "Sex", SqlDbType.VarChar, false);
                this.BirthDay = new MSSQL.Field(this, "BirthDay", "BirthDay", SqlDbType.DateTime, false);
                this.IDCardNumber = new MSSQL.Field(this, "IDCardNumber", "IDCardNumber", SqlDbType.VarChar, false);
                this.Address = new MSSQL.Field(this, "Address", "Address", SqlDbType.VarChar, false);
                this.Email = new MSSQL.Field(this, "Email", "Email", SqlDbType.VarChar, false);
                this.isEmailValided = new MSSQL.Field(this, "isEmailValided", "isEmailValided", SqlDbType.Bit, false);
                this.QQ = new MSSQL.Field(this, "QQ", "QQ", SqlDbType.VarChar, false);
                this.Telephone = new MSSQL.Field(this, "Telephone", "Telephone", SqlDbType.VarChar, false);
                this.Mobile = new MSSQL.Field(this, "Mobile", "Mobile", SqlDbType.VarChar, false);
                this.isMobileValided = new MSSQL.Field(this, "isMobileValided", "isMobileValided", SqlDbType.Bit, false);
                this.isPrivacy = new MSSQL.Field(this, "isPrivacy", "isPrivacy", SqlDbType.Bit, false);
                this.isCanLogin = new MSSQL.Field(this, "isCanLogin", "isCanLogin", SqlDbType.Bit, false);
                this.RegisterTime = new MSSQL.Field(this, "RegisterTime", "RegisterTime", SqlDbType.DateTime, false);
                this.LastLoginTime = new MSSQL.Field(this, "LastLoginTime", "LastLoginTime", SqlDbType.DateTime, false);
                this.LastLoginIP = new MSSQL.Field(this, "LastLoginIP", "LastLoginIP", SqlDbType.VarChar, false);
                this.LoginCount = new MSSQL.Field(this, "LoginCount", "LoginCount", SqlDbType.Int, false);
                this.UserType = new MSSQL.Field(this, "UserType", "UserType", SqlDbType.SmallInt, false);
                this.BankType = new MSSQL.Field(this, "BankType", "BankType", SqlDbType.SmallInt, false);
                this.BankName = new MSSQL.Field(this, "BankName", "BankName", SqlDbType.VarChar, false);
                this.BankCardNumber = new MSSQL.Field(this, "BankCardNumber", "BankCardNumber", SqlDbType.VarChar, false);
                this.Balance = new MSSQL.Field(this, "Balance", "Balance", SqlDbType.Money, false);
                this.Freeze = new MSSQL.Field(this, "Freeze", "Freeze", SqlDbType.Money, false);
                this.ScoringOfSelfBuy = new MSSQL.Field(this, "ScoringOfSelfBuy", "ScoringOfSelfBuy", SqlDbType.Float, false);
                this.ScoringOfCommendBuy = new MSSQL.Field(this, "ScoringOfCommendBuy", "ScoringOfCommendBuy", SqlDbType.Float, false);
                this.Scoring = new MSSQL.Field(this, "Scoring", "Scoring", SqlDbType.Float, false);
                this.Level = new MSSQL.Field(this, "Level", "Level", SqlDbType.SmallInt, false);
                this.CommenderID = new MSSQL.Field(this, "CommenderID", "CommenderID", SqlDbType.BigInt, false);
                this.CpsID = new MSSQL.Field(this, "CpsID", "CpsID", SqlDbType.BigInt, false);
                this.AlipayID = new MSSQL.Field(this, "AlipayID", "AlipayID", SqlDbType.VarChar, false);
                this.Bonus = new MSSQL.Field(this, "Bonus", "Bonus", SqlDbType.Money, false);
                this.Reward = new MSSQL.Field(this, "Reward", "Reward", SqlDbType.Money, false);
                this.AlipayName = new MSSQL.Field(this, "AlipayName", "AlipayName", SqlDbType.VarChar, false);
                this.isAlipayNameValided = new MSSQL.Field(this, "isAlipayNameValided", "isAlipayNameValided", SqlDbType.Bit, false);
                this.isAlipayCps = new MSSQL.Field(this, "isAlipayCps", "isAlipayCps", SqlDbType.Bit, false);
                this.IsCrossLogin = new MSSQL.Field(this, "IsCrossLogin", "IsCrossLogin", SqlDbType.Bit, false);
                this.ComeFrom = new MSSQL.Field(this, "ComeFrom", "ComeFrom", SqlDbType.Int, false);
                this.Memo = new MSSQL.Field(this, "Memo", "Memo", SqlDbType.VarChar, false);
                this.BonusThisMonth = new MSSQL.Field(this, "BonusThisMonth", "BonusThisMonth", SqlDbType.Money, false);
                this.BonusAllow = new MSSQL.Field(this, "BonusAllow", "BonusAllow", SqlDbType.Money, false);
                this.BonusUse = new MSSQL.Field(this, "BonusUse", "BonusUse", SqlDbType.Money, false);
                this.PromotionMemberBonusScale = new MSSQL.Field(this, "PromotionMemberBonusScale", "PromotionMemberBonusScale", SqlDbType.Float, false);
                this.PromotionSiteBonusScale = new MSSQL.Field(this, "PromotionSiteBonusScale", "PromotionSiteBonusScale", SqlDbType.Float, false);
                this.MaxFollowNumber = new MSSQL.Field(this, "MaxFollowNumber", "MaxFollowNumber", SqlDbType.Int, false);
                this.VisitSource = new MSSQL.Field(this, "VisitSource", "VisitSource", SqlDbType.VarChar, false);
                this.Key = new MSSQL.Field(this, "Key", "Key", SqlDbType.VarChar, false);
                this.HeadUrl = new MSSQL.Field(this, "HeadUrl", "HeadUrl", SqlDbType.VarChar, false);
                this.FriendList = new MSSQL.Field(this, "FriendList", "FriendList", SqlDbType.VarChar, false);
                this.NickName = new MSSQL.Field(this, "NickName", "NickName", SqlDbType.VarChar, false);
                this.SecurityQuestion = new MSSQL.Field(this, "SecurityQuestion", "SecurityQuestion", SqlDbType.VarChar, false);
                this.SecurityAnswer = new MSSQL.Field(this, "SecurityAnswer", "SecurityAnswer", SqlDbType.NVarChar, false);
                this.Reason = new MSSQL.Field(this, "Reason", "Reason", SqlDbType.VarChar, false);
                this.IsQQValided = new MSSQL.Field(this, "IsQQValided", "IsQQValided", SqlDbType.Bit, false);
            }
        }

        public class T_UserScoringDetails : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field ID;
            public MSSQL.Field Memo;
            public MSSQL.Field OperatorType;
            public MSSQL.Field RelatedUserID;
            public MSSQL.Field SchemeID;
            public MSSQL.Field Scoring;
            public MSSQL.Field SiteID;
            public MSSQL.Field UserID;

            public T_UserScoringDetails()
            {
                base.TableName = "T_UserScoringDetails";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.OperatorType = new MSSQL.Field(this, "OperatorType", "OperatorType", SqlDbType.SmallInt, false);
                this.Scoring = new MSSQL.Field(this, "Scoring", "Scoring", SqlDbType.Float, false);
                this.SchemeID = new MSSQL.Field(this, "SchemeID", "SchemeID", SqlDbType.BigInt, false);
                this.RelatedUserID = new MSSQL.Field(this, "RelatedUserID", "RelatedUserID", SqlDbType.BigInt, false);
                this.Memo = new MSSQL.Field(this, "Memo", "Memo", SqlDbType.VarChar, false);
            }
        }

        public class T_UsersForInitiateFollowScheme : MSSQL.TableBase
        {
            public MSSQL.Field DateTime;
            public MSSQL.Field Description;
            public MSSQL.Field ID;
            public MSSQL.Field MaxNumberOf;
            public MSSQL.Field PlayTypeID;
            public MSSQL.Field SiteID;
            public MSSQL.Field UserID;

            public T_UsersForInitiateFollowScheme()
            {
                base.TableName = "T_UsersForInitiateFollowScheme";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.BigInt, true);
                this.SiteID = new MSSQL.Field(this, "SiteID", "SiteID", SqlDbType.BigInt, false);
                this.UserID = new MSSQL.Field(this, "UserID", "UserID", SqlDbType.BigInt, false);
                this.DateTime = new MSSQL.Field(this, "DateTime", "DateTime", SqlDbType.DateTime, false);
                this.PlayTypeID = new MSSQL.Field(this, "PlayTypeID", "PlayTypeID", SqlDbType.Int, false);
                this.Description = new MSSQL.Field(this, "Description", "Description", SqlDbType.VarChar, false);
                this.MaxNumberOf = new MSSQL.Field(this, "MaxNumberOf", "MaxNumberOf", SqlDbType.Int, false);
            }
        }

        public class T_UserToCpsUId : MSSQL.TableBase
        {
            public MSSQL.Field CpsID;
            public MSSQL.Field ID;
            public MSSQL.Field PID;
            public MSSQL.Field Uid;

            public T_UserToCpsUId()
            {
                base.TableName = "T_UserToCpsUId";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, false);
                this.Uid = new MSSQL.Field(this, "Uid", "Uid", SqlDbType.Int, false);
                this.CpsID = new MSSQL.Field(this, "CpsID", "CpsID", SqlDbType.Int, false);
                this.PID = new MSSQL.Field(this, "PID", "PID", SqlDbType.Int, false);
            }
        }

        public class T_WinTypes : MSSQL.TableBase
        {
            public MSSQL.Field DefaultMoney;
            public MSSQL.Field DefaultMoneyNoWithTax;
            public MSSQL.Field ID;
            public MSSQL.Field LotteryID;
            public MSSQL.Field Name;
            public MSSQL.Field Order;

            public T_WinTypes()
            {
                base.TableName = "T_WinTypes";
                this.ID = new MSSQL.Field(this, "ID", "ID", SqlDbType.Int, false);
                this.LotteryID = new MSSQL.Field(this, "LotteryID", "LotteryID", SqlDbType.Int, false);
                this.Name = new MSSQL.Field(this, "Name", "Name", SqlDbType.VarChar, false);
                this.Order = new MSSQL.Field(this, "Order", "Order", SqlDbType.Int, false);
                this.DefaultMoney = new MSSQL.Field(this, "DefaultMoney", "DefaultMoney", SqlDbType.Money, false);
                this.DefaultMoneyNoWithTax = new MSSQL.Field(this, "DefaultMoneyNoWithTax", "DefaultMoneyNoWithTax", SqlDbType.Money, false);
            }
        }
    }
}

