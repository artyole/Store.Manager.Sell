using Store.Manager.Sell.Models;

namespace Store.Manager.Sell.Interfaces.Repositories
{
    public interface ISalesRepository
    {
        void Add(Sale sale);
        IQueryable<Sale> GetAll();
        Sale GetById(int saleId);
    }
}
