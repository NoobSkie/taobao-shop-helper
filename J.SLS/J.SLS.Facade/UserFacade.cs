using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Domain;
using J.SLS.Common;
using J.SLS.Common.Exceptions;
using J.SLS.Common.Logs;
using J.SLS.Database.DBAccess;

namespace J.SLS.Facade
{
    public class UserFacade : BaseFacade
    {
        public UserInfo Login(string userId, string password)
        {
            try
            {
                UserManager manager = new UserManager(DbAccess);
                password = EncryptTool.MD5(password);
                LoginEntity entity = manager.Authenticate(userId, password);

                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                return persistence.GetByKey<UserInfo>(userId);
            }
            catch (LoginException ex)
            {
                string errMsg = "登录失败";
                switch (ex.LoginErrorType)
                {
                    case LoginErrorType.UserIdOrPasswordError:
                        errMsg += " - 输入的用户名或密码错误！";
                        break;
                    case LoginErrorType.UserCannotLogin:
                        errMsg += " - 用户被限制登录，请联系系统管理员！";
                        break;
                }
                throw HandleException(LogCategory.Login, errMsg, ex);
            }
            catch (Exception ex)
            {
                string errMsg = "登录失败 - 系统异常，请联系系统管理员！";
                throw HandleException(LogCategory.Login, errMsg, ex);
            }
        }

        public bool CheckUserIdCanRegister(string userId)
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                LoginEntity user = persistence.GetByKey<LoginEntity>(userId);
                return (user == null);
            }
            catch (Exception ex)
            {
                string errMsg = "检查用户ID失败！";
                throw HandleException(LogCategory.SearchUser, errMsg, ex);
            }
        }

        public void Register(UserInfo user, string password)
        {
            LoginEntity loginEntity = new LoginEntity();
            loginEntity.UserId = user.UserId;
            loginEntity.UserName = user.UserName;
            loginEntity.IsCanLogin = true;

            UserBaseEntity userBaseEntity = new UserBaseEntity();
            userBaseEntity.UserId = user.UserId;
            userBaseEntity.RealName = user.RealName;
            userBaseEntity.Email = user.Email;
            userBaseEntity.CardType = user.IdCardType;
            userBaseEntity.CardNumber = user.IdCardNumber;
            userBaseEntity.Mobile = user.Mobile;

            UserBalanceEntity balanceEntity = new UserBalanceEntity();
            balanceEntity.UserId = user.UserId;
            balanceEntity.Balance = 0;
            balanceEntity.Freeze = 0;

            try
            {
                using (ILHDBTran tran = BeginTran())
                {
                    UserManager manager = new UserManager(tran);
                    password = EncryptTool.MD5(password);
                    manager.AddLogin(loginEntity, password);
                    manager.AddUserBase(userBaseEntity);
                    manager.AddBalance(balanceEntity);
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                string errMsg = "注册新用户失败 - 系统异常，请联系系统管理员！";
                throw HandleException(LogCategory.Register, errMsg, ex);
            }
        }

        public UserInfo GetUserInfo(string userId)
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                return persistence.GetByKey<UserInfo>(userId);
            }
            catch (Exception ex)
            {
                string errMsg = "获取用户信息失败！";
                throw HandleException(LogCategory.SearchUser, errMsg, ex);
            }
        }

        public void RequestGetMoney(string userId, int bankType, string bankName, string cardNumber, decimal money)
        {
            try
            {
                using (ILHDBTran tran = BeginTran())
                {
                    UserManager userManager = new UserManager(tran);
                    MoneyManager moneyManager = new MoneyManager(tran);

                    UserBalanceEntity balance = userManager.GetBalance(userId);
                    if (money > balance.EnableMoney)
                    {
                        throw new FacadeException("余额不足");
                    }
                    MoneyGetDetailEntity moneyGetRequest = new MoneyGetDetailEntity();
                    moneyGetRequest.UserId = userId;
                    moneyGetRequest.BankType = bankType;
                    moneyGetRequest.BankName = bankName;
                    moneyGetRequest.BankCardNumber = cardNumber;
                    moneyGetRequest.RequestMoney = money;
                    moneyGetRequest.Status = (int)MoneyGetStatus.Requesting;
                    moneyManager.AddMoneyGetRequest(moneyGetRequest);

                    if (balance.Freeze.HasValue)
                    {
                        balance.Freeze = balance.Freeze.Value + money;
                    }
                    else
                    {
                        balance.Freeze = money;
                    }
                    userManager.ModifyBalance(balance);

                    tran.Commit();
                }
            }
            catch (FacadeException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                HandleException(LogCategory.Money, "申请提款失败！", ex);
                throw new FacadeException("申请提款失败！");
            }
        }

        public RequestGetMoneyInfo GetRequestMoneyInfo(long id)
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                return persistence.GetByKey<RequestGetMoneyInfo>(id);
            }
            catch (Exception ex)
            {
                string errMsg = "获取用户请求提款失败！";
                throw HandleException(LogCategory.Money, errMsg, ex);
            }
        }

        public IList<RequestGetMoneyInfo> GetRequestMoneyList(string userId)
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                Criteria cri = new Criteria();
                cri.Add(Expression.Equal("UserId", userId));
                return persistence.GetList<RequestGetMoneyInfo>(cri, new SortInfo("Status"), new SortInfo("RequestTime", SortDirection.Desc));
            }
            catch (Exception ex)
            {
                string errMsg = "获取用户请求提款失败！";
                throw HandleException(LogCategory.Money, errMsg, ex);
            }
        }

        public IList<RequestGetMoneyInfo> GetUnhandleRequestMoneyList()
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                Criteria cri = new Criteria();
                cri.Add(Expression.Equal("Status", MoneyGetStatus.Requesting));
                return persistence.GetList<RequestGetMoneyInfo>(cri, new SortInfo("RequestTime", SortDirection.Desc));
            }
            catch (Exception ex)
            {
                string errMsg = "获取用户请求提款失败！";
                throw HandleException(LogCategory.Money, errMsg, ex);
            }
        }

        public void AcceptRequestGetMoney(long id, string operateUserId, string message)
        {
            try
            {
                using (ILHDBTran tran = BeginTran())
                {
                    UserManager userManager = new UserManager(tran);
                    MoneyManager moneyManager = new MoneyManager(tran);

                    MoneyGetDetailEntity moneyGetDetail = moneyManager.GetMoneyGetDetailEntity(id);
                    if (moneyGetDetail.Status != (int)MoneyGetStatus.Requesting)
                    {
                        throw new FacadeException("此请求已经被处理！");
                    }
                    UserBalanceEntity balance = userManager.GetBalance(moneyGetDetail.UserId);
                    if (balance.Freeze.Value < moneyGetDetail.RequestMoney)
                    {
                        throw new FacadeException("用户账户发生异常，冻结金额不足！");
                    }

                    moneyGetDetail.Status = (int)MoneyGetStatus.Accepted;
                    moneyGetDetail.ResponseUserId = operateUserId;
                    moneyGetDetail.ResponseMoney = moneyGetDetail.RequestMoney;
                    moneyGetDetail.ResponseMessage = message;
                    moneyManager.ModifyMoneyGetResponseStatus(moneyGetDetail);

                    balance.Freeze -= moneyGetDetail.RequestMoney;
                    balance.Balance -= moneyGetDetail.RequestMoney;
                    userManager.ModifyBalance(balance);

                    tran.Commit();
                }
            }
            catch (FacadeException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                HandleException(LogCategory.Money, "处理接受提款申请失败！", ex);
                throw new FacadeException("处理接受提款申请失败！");
            }
        }

        public void RejectRequestGetMoney(long id, string operateUserId, string message)
        {
            try
            {
                using (ILHDBTran tran = BeginTran())
                {
                    UserManager userManager = new UserManager(tran);
                    MoneyManager moneyManager = new MoneyManager(tran);

                    MoneyGetDetailEntity moneyGetDetail = moneyManager.GetMoneyGetDetailEntity(id);
                    if (moneyGetDetail.Status != (int)MoneyGetStatus.Requesting)
                    {
                        throw new FacadeException("此请求已经被处理！");
                    }
                    UserBalanceEntity balance = userManager.GetBalance(moneyGetDetail.UserId);
                    if (balance.Freeze.Value < moneyGetDetail.RequestMoney)
                    {
                        throw new FacadeException("用户账户发生异常，冻结金额不足！");
                    }

                    moneyGetDetail.Status = (int)MoneyGetStatus.Rejected;
                    moneyGetDetail.ResponseUserId = operateUserId;
                    moneyGetDetail.ResponseMoney = moneyGetDetail.RequestMoney;
                    moneyGetDetail.ResponseMessage = message;
                    moneyManager.ModifyMoneyGetResponseStatus(moneyGetDetail);

                    balance.Freeze -= moneyGetDetail.RequestMoney;
                    userManager.ModifyBalance(balance);

                    tran.Commit();
                }
            }
            catch (FacadeException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                HandleException(LogCategory.Money, "处理拒绝提款申请失败！", ex);
                throw new FacadeException("处理拒绝提款申请失败！");
            }
        }
    }
}
