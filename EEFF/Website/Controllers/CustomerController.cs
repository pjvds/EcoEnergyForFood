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
    }
}
