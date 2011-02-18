using System;
using Events;
using Ncqrs.Domain;

namespace Domain
{
    public class Customer : AggregateRootMappedByConvention
    {
        private string _name;
        private DateTime? _birthDate;

        public Guid CustomerId
        {
            get { return EventSourceId; }
        }

        protected Customer()
        {
            // DO NOT USE.
        }

        public Customer(Guid customerId, string name, DateTime? birthDate)
        {
            EventSourceId = customerId;

            var e = new CustomerCreated{ CustomerId = customerId, Name = name, BirthDate = birthDate };
            ApplyEvent(e);
        }

        private void OnCustomerCreated(CustomerCreated e)
        {
            _name = e.Name;
            _birthDate = e.BirthDate;
        }
    }
}
