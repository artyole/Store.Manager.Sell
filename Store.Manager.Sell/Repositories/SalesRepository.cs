using Microsoft.EntityFrameworkCore;
using Store.Manager.Sell.Context;
using Store.Manager.Sell.Interfaces.Repositories;
using Store.Manager.Sell.Models;

namespace Store.Manager.Sell.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly AppDbContext _context;

        public SalesRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        IQueryable<Sale> ISalesRepository.GetAll()
        {
            return _context.Sales.AsQueryable();
        }

        public Sale GetById(int saleId)
        {
            return _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Products)
                    .ThenInclude(sp => sp.Id)
                .SingleOrDefault(s => s.Id == saleId);
        }
    }
}
