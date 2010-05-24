using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LHBIS.Database.DBAccess;
using LHBIS.Database.ORM;

namespace J.SLS.Domain
{
    public class UserManager
    {
        private readonly ObjectPersistence persistence = null;
        public UserManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public void Add(UserEntity entity)
        {
            entity.Password = entity.Password;
            persistence.Add(entity);
        }

        public void Delete(string userId)
        {
            persistence.Delete(new UserEntity { UserId = userId });
        }

        public void Modify(string userId, string oldPassword, string newPassword)
        {
            UserEntity user = persistence.GetByKey<UserEntity>(userId);
            if (user == null)
            {
            }
            if (user.Password != oldPassword)
            {
            }
            user.Password = newPassword;
            persistence.Modify(user);
        }
    }
}
