using Store.Manager.Sell.Interfaces.Repositories;
using Store.Manager.Sell.Interfaces.Services;
using Store.Manager.Sell.Models;

namespace Store.Manager.Sell.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer CreateCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
            _customerRepository.SaveChanges();

            return customer;
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            _customerRepository.Update(customer);
            _customerRepository.SaveChanges();

            return customer;
        }

        public Customer DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return null;
            }

            _customerRepository.Delete(customer);
            _customerRepository.SaveChanges();

            return customer;
        }
    }
}
