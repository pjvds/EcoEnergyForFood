using System;
using Events;
using Ncqrs.Eventing.ServiceModel.Bus;
using Website.Models;

namespace Website.Denormalizers
{
    public class CustomerCreatedDenormalizer : IEventHandler<CustomerCreated>
    {
        public void Handle(CustomerCreated evnt)
        {
            using(var context = new WebsiteReadModelDataContext())
            {
                var newCustomerModel = new CustomerModel
                {
                    CustomerId = evnt.CustomerId,
                    Name = evnt.Name,
                    BirthDate = evnt.BirthDate
                };

                context.CustomerModels.InsertOnSubmit(newCustomerModel);
                context.SubmitChanges();
            }
        }
    }
}