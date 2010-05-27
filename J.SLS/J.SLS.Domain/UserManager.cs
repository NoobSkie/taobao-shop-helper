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

        public UserEntity Authenticate(string userId, string password)
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

        //public void Add(UserEntity entity)
        //{
        //    entity.Password = entity.Password;
        //    persistence.Add(entity);
        //}

        public void Delete(string userId)
        {
            persistence.Delete(new UserEntity { UserId = userId });
        }

        public void Modify(string userId, string oldPassword, string newPassword)
        {
            //UserEntity user = persistence.GetByKey<UserEntity>(userId);
            //if (user == null)
            //{
            //}
            //if (user.Password != oldPassword)
            //{
            //}
            //user.Password = newPassword;
            //persistence.Modify(user);
        }

        private class UserPassowrdEntity : UserEntity
        {
            [EntityMappingField("Password")]
            public string Password { get; set; }
        }
    }
}
