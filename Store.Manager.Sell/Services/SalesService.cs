using Microsoft.EntityFrameworkCore;
using Store.Manager.Sell.Interfaces.Repositories;
using Store.Manager.Sell.Interfaces.Services;
using Store.Manager.Sell.Models;
using Store.Manager.Sell.Report;

namespace Store.Manager.Sell.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public SalesService(ISalesRepository salesRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _salesRepository = salesRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public List<Sale> GetSales()
        {
            return _salesRepository.GetAll()
                .Include(s => s.Customer)
                .Include(s => s.Products)
                    .ThenInclude(sp => sp.Id)
                .ToList();
        }

        public List<SaleReportItem> GetSalesReport()
        {
            var sales = _salesRepository.GetAll()
                .Include(s => s.Products)
                    .ThenInclude(sp => sp.Id)
                .ToList();

            return sales.Select(s => new SaleReportItem
            {
                SaleId = s.Id,
                SaleDate = s.SaleDate,
                Products = s.Products.Select(sp => new ProductReportItem
                {
                    ProductId = sp.Id,
                    Name = sp.Name,
                    Price = sp.Price
                }).ToList()
            }).ToList();
        }
        public Sale GetSaleById(int saleId)
        {
            return _salesRepository.GetById(saleId);
        }

        public Sale CreateSale(int customerId, List<int> productIds)
        {
            var products = new List<Product>();
            // Verificar se o cliente existe
            var customer = _customerRepository.GetById(customerId);
            if (customer == null)
            {
                throw new Exception("Cliente não encontrado.");
            }

            // Obter os produtos pelo ID
            foreach (var id in productIds)
            {
                products.Add(_productRepository.GetProductById(id));
            }

            // Criar a venda
            var sale = new Sale
            {
                CustomerId = customerId,
                SaleDate = DateTime.Now,
                Products = products
            };

            _salesRepository.Add(sale);

            return sale;
        }
    }
}
