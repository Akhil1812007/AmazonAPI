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
            
            
                Cart? cart = _context.carts.Find(id);
                _context.carts.Remove(cart);
                await _context.SaveChangesAsync();
            
            
        }

        public async   Task<List<Cart>>? GetAllCart(int customerId)
        {
            List<Cart> cartList = await (from c in _context.carts.Include(x => x.Product) where c.CustomerId == customerId select c).ToListAsync();

            return  cartList;    
        }

        public async  Task<Cart> GetCartById(int cartid)
        {
            var result= (from c in _context.carts.Include(x => x.Product) where c.CartId == cartid select c).SingleOrDefault();
            return result;
        }

        public Task<Cart> ModifyCart(int id)
        {
            throw new NotImplementedException();
        }
    }
}
