using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Manager.Sell.Context;
using Store.Manager.Sell.Interfaces.Services;
using Store.Manager.Sell.Models;

namespace Store.Manager.Sell.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer request)
        {
            var customer = _customerService.CreateCustomer(request);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public ActionResult<Customer> UpdateCustomer(int id, Customer request)
        {
            var updatedCustomer = _customerService.UpdateCustomer(id, request);
            if (updatedCustomer == null)
            {
                return NotFound();
            }
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public ActionResult<Customer> DeleteCustomer(int id)
        {
            var deletedCustomer = _customerService.DeleteCustomer(id);
            if (deletedCustomer == null)
            {
                return NotFound();
            }
            return Ok(deletedCustomer);
        }
    }
}
