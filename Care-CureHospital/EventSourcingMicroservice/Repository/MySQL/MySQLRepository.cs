using EventSourcingMicroservice.DataBase;
using EventSourcingMicroservice.Domain;
using System.Collections.Generic;
using System.Linq;

namespace EventSourcingMicroservice.Repository.MySQL
{
    public class MySQLRepository : IRepository
    {
        private readonly ESDataBaseContext _context;

        public MySQLRepository (ESDataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<DomainEvent> Load(EventType eventType)
        {
            if (eventType.Equals(EventType.LOGIN_EVENT))
                return _context.LoginEvents.ToList();
            else if (eventType.Equals(EventType.URL_EVENT))
                return _context.URLEvents.ToList();

            return null;
        }

        public DomainEvent Save(DomainEvent domainEvent)
        {
            var @event = (dynamic)domainEvent;
            if (@event is LoginEvent) _context.LoginEvents.Add(@event);
            if (@event is URLEvent) _context.URLEvents.Add(@event);
            
            _context.SaveChanges();
            return domainEvent;
        }
    }
}
