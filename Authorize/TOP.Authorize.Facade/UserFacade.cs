using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.Logic;
using TOP.Common.DbHelper;
using System.Data;
using TOP.Authorize.Domain;

namespace TOP.Authorize.Facade
{
    public class UserFacade : FacadeBase
    {
        /// <summary>
        /// 登录，并返回登录用户。如果登录失败，则返回null。
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="password">加密后的密码</param>
        /// <returns></returns>
        public UserInfo Login(string loginName, string password)
        {
            string sqlSelect = sqlHelper.GenerateSelectViewSql(typeof(UserInfo));
            sqlSelect += string.Format("WHERE [LoginName] = N'{0}' AND [Password] = N'{1}'", loginName, password);
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                DataTable dt = dbOperator.GetTable(sqlSelect);
                if (dt.Rows.Count > 0)
                {
                    return TransferInfo<UserInfo>(dt.Rows[0]);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 注册新用户。返回用户Id。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loginName">登录名</param>
        /// <param name="password">加密后的密码</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public string Register(string id, string loginName, string password, string userName)
        {
            #region 构造要新增的对象

            if (string.IsNullOrEmpty(id) || id == Guid.Empty.ToString())
            {
                id = Guid.NewGuid().ToString();
            }

            User _user = new User();
            _user.Id = id;
            _user.LoginName = loginName;
            _user.Password = password;
            _user.UserName = userName;

            #endregion

            #region 执行SQL以创建对象

            UserManager manager = new UserManager();
            string sqlCreate = manager.GetCreateSql(_user);
            using (DbOperator dbOperator = new DbOperator(ConnString))
            {
                try
                {
                    dbOperator.BeginTran();
                    dbOperator.ExecSql(sqlCreate);
                    dbOperator.CommintTran();

                    return id;
                }
                catch (Exception ex)
                {
                    dbOperator.RollbackTran();
                    throw new FacadeException("注册用户发生异常 - ", ex);
                }
            }

            #endregion
        }
    }
}
