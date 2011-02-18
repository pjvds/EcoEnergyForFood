using System;
using System.Linq;
using System.Web.Mvc;
using Commands;
using Website.Models;

namespace Website.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Add()
        {
            var customer = new CustomerModel {CustomerId = Guid.NewGuid()};

            return View(customer);
        }

        [HttpPost]
        public ActionResult Add(CustomerModel model)
        {
            var command = new CreateCustomer{CustomerId = model.CustomerId, Name = model.Name, BirthDate = model.BirthDate};
            
            WebsiteApplication.TheCommandService.Execute(command);
            return View();
        }

        public ActionResult List()
        {
            using(var context = new WebsiteReadModelDataContext())
            {
                var customers = context.CustomerModels.ToArray();
                return View(customers);
            }
        }

        public ActionResult ChangeName(Guid customerId)
        {
            var command = new ChangeNameOfCustomer{CustomerId = customerId, NewName = new WebsiteReadModelDataContext().CustomerModels.First(c=>c.CustomerId==customerId).Name};

            return View(command);
        }

        [HttpPost]
        public ActionResult ChangeName(ChangeNameOfCustomer command)
        {
            WebsiteApplication.TheCommandService.Execute(command);

            return View();
        }
    }
}
