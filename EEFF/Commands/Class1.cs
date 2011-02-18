using System;
using Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Commands
{
    [MapsToAggregateRootConstructor(typeof(Customer))]
    public class CreateCustomer : CommandBase
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
