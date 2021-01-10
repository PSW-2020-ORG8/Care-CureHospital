using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcingMicroservice.Domain
{
    public class URLEvent : DomainEvent
    {
        public EventType EventType;
        public string Url { get; private set; }
        public string Method { get; private set; }
        public URLEvent(string url, string method) : base()
        { 
            Url = url;
            Method = method;
            EventType = EventType.URL_EVENT;
        }
    }
}
