using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.DBAccess;
using J.SLS.Database.ORM;
using J.SLS.Common;

namespace J.SLS.Domain
{
    public class TicketManager
    {
        private readonly ObjectPersistence persistence = null;
        public TicketManager(IDBAccess dbAccess)
        {
            persistence = new ObjectPersistence(dbAccess);
        }

        public void AddTicket(TicketEntity ticket)
        {
            persistence.Add(ticket);
        }

        public void AddAnteCode(TicketAnteCodeEntity anteCode)
        {
            persistence.Add(anteCode);
        }

        public void AddTicketDetail(TicketDetailEntity ticketDetail)
        {
            persistence.Add(ticketDetail);
        }

        public void AddTicketChase(ChaseEntity chaseEntity)
        {
            persistence.Add(chaseEntity);
        }

        public IList<TicketAnteCodeEntity> GetAnteCodeListByTicket(string ticketId)
        {
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("TicketId", ticketId));
            return persistence.GetList<TicketAnteCodeEntity>(cri);
        }

        public IList<ChaseEntity> GetChaseListByIssue(string gameName, string issueNumber, int status)
        {
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("GameName", gameName));
            cri.Add(Expression.Equal("IssuseNumber", issueNumber));
            cri.Add(Expression.Equal("Status", status));
            return persistence.GetList<ChaseEntity>(cri);
        }

        public void ModifyTicket(TicketEntity ticket)
        {
            persistence.Modify(ticket);
        }

        public void ModifyChaseStatus(ChaseEntity chase)
        {
            chase.ResponseTime = DateTime.Now;
            persistence.Modify(chase);
        }

        public TicketEntity GetTicket(string ticketId)
        {
            return persistence.GetByKey<TicketEntity>(ticketId);
        }

        public TicketDetailEntity GetFreezeTicketDetail(string ticketId, string userId)
        {
            Criteria cri = new Criteria();
            cri.Add(Expression.Equal("TicketId", ticketId));
            cri.Add(Expression.Equal("UserId", userId));
            IList<TicketDetailEntity> tmp = persistence.GetList<TicketDetailEntity>(cri);
            if (tmp.Count == 1 && tmp[0].Status == (int)TicketStatus.Requesting)
            {
                return tmp[0];
            }
            return null;
        }
    }
}
