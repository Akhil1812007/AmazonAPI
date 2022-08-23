using Amazon.Models;
using AmazonAPI.Models;

namespace Amazon.Repository
{
    public interface IMerchantRepository 
    {
        Task<List<Merchant>> GetMerchant();
        Task<Merchant> GetMerchantByID(int MerchantId);
        Task<Merchant> InsertMerchant(Merchant Merchant);
        Task DeleteMerchant(int MerchantId);
        Task<Merchant> UpdateMerchant(int MerchantId,Merchant merchant);
        Task<MerchantToken> MerchantLogin(Merchant merchant);

        Task<List<Product>> GetProductByMerchantId(int id);



    }
}
