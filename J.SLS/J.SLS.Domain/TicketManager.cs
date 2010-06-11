using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.DBAccess;
using J.SLS.Database.ORM;

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
    }
}
