using Store.Manager.Sell.Models;
using Store.Manager.Sell.Report;

namespace Store.Manager.Sell.Interfaces.Services
{
    public interface ISalesService
    {
        Sale CreateSale(int customerId, List<int> productIds);
        List<Sale> GetSales();
        List<SaleReportItem> GetSalesReport();
        Sale GetSaleById(int saleId);
    }
}
