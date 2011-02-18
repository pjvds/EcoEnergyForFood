using System;
using Events;
using Ncqrs.Domain;

namespace Domain
{
    public class Customer : AggregateRootMappedByConvention
    {
        private string _name;
        private DateTime _birthDate;

        protected Customer()
        {
            // DO NOT USE.
        }

        public Customer(string name, DateTime birthDate)
        {
            var e = new CustomerCreated{ Name = name, BirthDate = birthDate };
            ApplyEvent(e);
        }

        private void OnCustomerCreated(CustomerCreated e)
        {
            _name = e.Name;
            _birthDate = e.BirthDate;
        }
    }
}
