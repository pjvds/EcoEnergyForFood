using System;
using System.IO;
using Events;
using Ncqrs.Domain;
using Ncqrs.Eventing.Sourcing.Mapping;

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

            if (!GenericValidationRules.ValidName(name)) throw new InvalidDataException("name not valid.");

            var e = new CustomerCreated{ CustomerId = customerId, Name = name, BirthDate = birthDate };
            ApplyEvent(e);
        }

        public void ChangeName(string newName)
        {
            if(!GenericValidationRules.ValidName(newName)) throw new InvalidDataException("name not valid.");

            var e = new CustomerNameChanged {NewName = newName};
            ApplyEvent(e);
        }

        private void OnCreated(CustomerCreated e)
        {
            _name = e.Name;
            _birthDate = e.BirthDate;
        }

        private void OnNameChanged(CustomerNameChanged e)
        {
            _name = e.NewName;
        }
    }
}
