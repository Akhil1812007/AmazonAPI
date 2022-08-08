using Amazon.Models;
using Amazon.Repository;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Provider
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository _repository;
        public ProductProvider(IProductRepository repository)
        {
            _repository=repository;
        }

            
        public async  Task<Product> AddProduct(Product product)
        {
            return await _repository.AddProduct(product);
        }

        public async Task DeleteProduct(int productId)
        {
            await _repository.DeleteProduct(productId); 
        }

        public async Task<Product> EditProduct(int ProductId,Product product)
        {
            return await _repository.EditProduct(ProductId,product);    
        }

        public async  Task<List<Product>> GetAllProduct()
        {
            return await _repository.GetAllProduct();
        }
    }
}
