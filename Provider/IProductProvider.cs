using Amazon.Models;

namespace Amazon.Provider
{
    public interface IProductProvider
    {
        Task<Product> AddProduct(Product product);
        Task<Product> EditProduct(int ProductId, Product product);
        Task DeleteProduct(int productId);
        Task<List<Product>> GetAllProduct();

    }
}
