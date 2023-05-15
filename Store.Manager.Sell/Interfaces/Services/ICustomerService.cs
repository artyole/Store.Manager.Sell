using Store.Manager.Sell.Models;

namespace Store.Manager.Sell.Interfaces.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(int id, Customer customer);
        Customer DeleteCustomer(int id);
    }
}
