using System;
using Ncqrs.Eventing.Sourcing;

namespace Events
{
    public class CustomerCreated : SourcedEvent
    {
        public Guid CustomerId { get { return EventSourceId;  } }

        public String Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
