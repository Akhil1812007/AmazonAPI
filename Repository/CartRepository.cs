using Amazon.Models;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly AmazonContext _context;
        public CartRepository( AmazonContext context)
        {
            _context = context;
        }

        public async  Task<Cart>? AddToCart(Cart cart)
        {
           _context.carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }
       
        public async  Task DeleteFromCart(int id)
        {
            try
            {
                Cart? cart = _context.carts.Find(id);
                _context.carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public Task<List<Cart>> GetAllCart(int customerId)
        {
            var cartList = (from c in _context.carts where c.CustomerId == customerId select c).ToListAsync();
            return cartList;    
        }

        public Task<Cart> GetCartById(int cartid)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> ModifyCart(int id)
        {
            throw new NotImplementedException();
        }
    }
}
