using Store.Manager.Sell.Models;

namespace Store.Manager.Sell.Interfaces.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        Product CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
