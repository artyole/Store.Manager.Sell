using Store.Manager.Sell.Models;

namespace Store.Manager.Sell.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        void SaveChanges();
    }
}
