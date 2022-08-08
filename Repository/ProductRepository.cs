using Amazon.Models;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AmazonContext _context;
        public ProductRepository(AmazonContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task DeleteProduct(int productId)
        {
            try
            {
                Product? product  = _context.Products.Find(productId);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Product> EditProduct(int ProductId,Product product)
        {
            _context.Update(product);
            await  _context.SaveChangesAsync();
            return product;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();

            }

        }
    }
}
