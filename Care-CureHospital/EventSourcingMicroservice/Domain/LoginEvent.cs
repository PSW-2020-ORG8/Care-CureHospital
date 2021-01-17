using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcingMicroservice.Domain
{
    public class LoginEvent : DomainEvent
    {
        public EventType EventType;
        public String UserName { get; set; }
        public int UserId { get; set; }

        public LoginEvent(String userName, int userId) : base() 
        {
            UserName = userName;
            UserId = userId;
            EventType = EventType.LOGIN_EVENT;
        }
    }
}
