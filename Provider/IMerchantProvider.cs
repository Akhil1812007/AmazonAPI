using Amazon.Models;

namespace Amazon.Provider
{
    public interface IMerchantProvider
    {
        Task<List<Merchant>> GetMerchant();
        Task<Merchant> GetMerchantByID(int MerchantId);
        Task<Merchant> InsertMerchant(Merchant Merchant);
        Task DeleteMerchant(int MerchantId);
        Task<Merchant> UpdateMerchant(int MerchantId, Merchant merchant);
        Task<Merchant>  MerchantLogin(Merchant merchant);

    }
}
