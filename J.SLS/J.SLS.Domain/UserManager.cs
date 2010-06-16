using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.DBAccess;
using J.SLS.Database.ORM;
using J.SLS.Common;
using J.SLS.Common.Exceptions;

namespace J.SLS.Domain
{
    public class UserManager
    {
        private readonly ObjectPersistence persistence = null;
        public UserManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public LoginEntity Authenticate(string userId, string password)
        {
            password = EncryptTool.MD5(password);
            Criteria cri = new Criteria();
            cri.Add(
                Expression.And(
                    Expression.Equal("UserId", userId)
                    , Expression.Equal("Password", password)
                ));
            IList<UserPassowrdEntity> users = persistence.GetList<UserPassowrdEntity>(cri);
            if (users.Count > 0)
            {
                if (users[0].IsCanLogin)
                {
                    return users[0];
                }
                throw new LoginException(LoginErrorType.UserCannotLogin);
            }
            throw new LoginException(LoginErrorType.UserIdOrPasswordError);
        }

        public void AddLogin(LoginEntity loginEntity, string password)
        {
            UserPassowrdEntity pwdEntity = new UserPassowrdEntity();
            pwdEntity.UserId = loginEntity.UserId;
            pwdEntity.UserName = loginEntity.UserName;
            pwdEntity.IsCanLogin = loginEntity.IsCanLogin;
            pwdEntity.RegisterTime = DateTime.Now;
            pwdEntity.Password = EncryptTool.MD5(password);

            persistence.Add(pwdEntity);
        }

        public void AddUserBase(UserBaseEntity userEntity)
        {
            persistence.Add(userEntity);
        }

        public void AddBalance(UserBalanceEntity balanceEntity)
        {
            persistence.Add(balanceEntity);
        }

        private class UserPassowrdEntity : LoginEntity
        {
            [EntityMappingField("RegisterTime")]
            public DateTime RegisterTime { get; set; }

            [EntityMappingField("Password")]
            public string Password { get; set; }
        }

        public UserBalanceEntity GetBalance(string userId)
        {
            return persistence.GetByKey<UserBalanceEntity>(userId);
        }

        public void ModifyBalance(UserBalanceEntity balance)
        {
            persistence.Modify(balance);
        }
    }
}
