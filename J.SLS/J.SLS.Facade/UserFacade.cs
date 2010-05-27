using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Domain;
using J.SLS.Common;
using J.SLS.Common.Exceptions;

namespace J.SLS.Facade
{
    public class UserFacade : BaseFacade
    {
        public LoginInfo Login(string userId, string password)
        {
            try
            {
                UserManager manager = new UserManager(DbAccess);
                password = EncryptTool.MD5(password);
                UserEntity entity = manager.Authenticate(userId, password);
                return ConvertFromEntity(entity);
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
                throw new FacadeException(errMsg, ex);
            }
            catch (Exception ex)
            {
                string errMsg = "登录失败 - 系统异常，请联系系统管理员！";
                throw new FacadeException(errMsg, ex);
            }
        }

        public T GetUserInfo<T>(string userId)
            where T : LoginInfo, new()
        {
            try
            {
                ObjectPersistence persistence = new ObjectPersistence(DbAccess);
                return persistence.GetByKey<T>(userId);
            }
            catch (Exception ex)
            {
                string errMsg = "获取用户信息失败！";
                throw new FacadeException(errMsg, ex);
            }
        }

        private LoginInfo ConvertFromEntity(UserEntity entity)
        {
            if (entity == null) return null;

            LoginInfo info = new LoginInfo();
            info.UserId = entity.UserId;
            info.UserName = entity.UserName;
            info.RegisterTime = entity.RegisterTime;
            return info;
        }
    }
}
