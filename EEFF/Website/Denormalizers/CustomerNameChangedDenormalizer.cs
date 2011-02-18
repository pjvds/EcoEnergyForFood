using System;
using Events;
using Ncqrs.Eventing.ServiceModel.Bus;
using Website.Models;
using System.Linq;

namespace Website.Denormalizers
{
    public class CustomerNameChangedDenormalizer : IEventHandler<CustomerNameChanged>
    {
        public void Handle(CustomerNameChanged evnt)
        {
            using(var context = new WebsiteReadModelDataContext())
            {
                var customerToUpdate = context.CustomerModels.First(c => c.CustomerId == evnt.CustomerId);
                customerToUpdate.Name = evnt.NewName;

                context.SubmitChanges();
            }
        }
    }
}