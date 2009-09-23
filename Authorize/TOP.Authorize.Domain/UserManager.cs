using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.DbHelper;

namespace TOP.Authorize.Domain
{
    public class UserManager : DbEntityManager<User>
    {
        public UserManager()
        {
        }
    }
}
