using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;

namespace J.SLS.Domain
{
    public class IssuseManager
    {
        private readonly ObjectPersistence persistence = null;
        public IssuseManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public IssueEntity GetIssue(string gameName, string number)
        {
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("GameName", gameName));
            cri.Add(Expression.Equal("IssuseNumber", number));
            IList<IssueEntity> list = persistence.GetList<IssueEntity>(cri);
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        public bool IsIssueExists(string gameName, string number)
        {
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("GameName", gameName));
            cri.Add(Expression.Equal("IssuseNumber", number));
            IList<IssueEntity> list = persistence.GetList<IssueEntity>(cri);
            return (list.Count > 0);
        }

        public void SaveIssue(IssueEntity entity)
        {
            if (IsIssueExists(entity.GameName, entity.IssuseNumber))
            {
                IssueEntity tmpEntity = GetIssue(entity.GameName, entity.IssuseNumber);
                tmpEntity.BonusCode = entity.BonusCode;
                tmpEntity.BonusMoney = entity.BonusMoney;
                tmpEntity.SalesMoney = entity.SalesMoney;
                tmpEntity.Status = entity.Status;
                UpdateIssueStatus(tmpEntity);
            }
            else
            {
                AddIssue(entity);
            }
        }

        public void AddIssue(IssueEntity entity)
        {
            persistence.Add(entity);
        }

        public void UpdateIssueStatus(IssueEntity entity)
        {
            persistence.Modify(entity);
        }
    }
}
