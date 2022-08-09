using Amazon.Models;

namespace Amazon.Repository
{
    public interface ICartRepository
    {
        Task<Cart> AddToCart(Cart cart);
        Task DeleteFromCart(int id);
        Task<Cart> GetCartById(int id);
        Task<List<Cart>> GetAllCart();
        Task<Cart> ModifyCart(int id);



    }
}
