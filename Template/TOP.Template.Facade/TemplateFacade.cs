using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOP.Common.Logic;
using TOP.Template.Domain;
using TOP.Common.DbHelper;

namespace TOP.Template.Facade
{
    public class TemplateFacade : FacadeBase
    {
        public string CreateTemplate(string name, string content, string userId)
        {
            string id = Guid.NewGuid().ToString();
            TOP.Template.Domain.Template template = new TOP.Template.Domain.Template();
            template.Name = name;
            template.Content = content;
            template.CreateUserId = userId;
            template.LastUpdateUserId = userId;

            #region 执行SQL以创建对象

            TemplateManager manager = new TemplateManager();
            string sqlCreate = manager.GetCreateSql(template);
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
                    throw new FacadeException("创建模板发生异常 - ", ex);
                }
            }

            #endregion
        }
    }
}
