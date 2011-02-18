using System;
using Ncqrs.Eventing.Sourcing;

namespace Events
{
    public class CustomerCreated : SourcedEvent
    {
        public Guid CustomerId { get; set; }

        public String Name { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
