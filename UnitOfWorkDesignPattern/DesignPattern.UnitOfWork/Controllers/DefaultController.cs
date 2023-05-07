using DesignPattern.BusinessLayer.Abstract;
using DesignPattern.EntityLayer.Concrete;
using DesignPattern.UnitOfWork.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPattern.UnitOfWork.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICustomerService _customerService;

        public DefaultController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerViewModel model)
        {
            var value1 = _customerService.TGetById(model.SenderId);
            var value2 = _customerService.TGetById(model.ReceiverId);

            value1.Balance -= model.Amount;
            value2.Balance += model.Amount;

            List<Customer> modifiedCustomer = new List<Customer>()
            {
                value1,
                value2
            };

            _customerService.TMultiUpdate(modifiedCustomer);

            return View();
        }
    }
}
