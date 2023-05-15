using Store.Manager.Sell.Interfaces.Repositories;
using Store.Manager.Sell.Interfaces.Services;
using Store.Manager.Sell.Models;

namespace Store.Manager.Sell.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public Product CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public void UpdateProduct(int id, Product product)
        {
            var existingProduct = _productRepository.GetProductById(id);
            if (existingProduct == null)
            {
                throw new ArgumentException("Product not found.");
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Product name is required.");
            }

            if (product.Price <= 0)
            {
                throw new ArgumentException("Product price must be greater than zero.");
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;

            _productRepository.UpdateProduct(existingProduct);
        }

        public void DeleteProduct(int id)
        {
            var existingProduct = _productRepository.GetProductById(id);
            if (existingProduct == null)
            {
                throw new ArgumentException("Product not found.");
            }

            _productRepository.DeleteProduct(existingProduct);
        }
    }
}
