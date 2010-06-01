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
            userBaseEntity.CardType = user.CardType;
            userBaseEntity.CardNumber = user.CardNumber;
            userBaseEntity.Mobile = user.Mobile;

            try
            {
                using (ILHDBTran tran = BeginTran())
                {
                    UserManager manager = new UserManager(tran);
                    password = EncryptTool.MD5(password);
                    manager.AddLogin(loginEntity, password);
                    manager.AddUserBase(userBaseEntity);
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
    }
}
