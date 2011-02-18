using System;
using Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace Commands
{
    [MapsToAggregateRootMethod(typeof(Customer), "ChangeName")]
    public class ChangeNameOfCustomer : CommandBase
    {
        [AggregateRootId]
        public Guid CustomerId { get; set; }
        public string NewName { get; set; }
    }
}
