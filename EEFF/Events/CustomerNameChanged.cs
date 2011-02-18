using System;
using Ncqrs.Eventing.Sourcing;

namespace Events
{
    public class CustomerNameChanged : SourcedEvent
    {
        public Guid CustomerId { get { return EventSourceId; } }

        public string NewName { get; set; }
    }
}
