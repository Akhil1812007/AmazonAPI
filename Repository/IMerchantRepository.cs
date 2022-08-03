using Amazon.Models;

namespace Amazon.Repository
{
    public interface IMerchantRepository 
    {
        IEnumerable<Merchant> GetMerchant();
        Merchant GetMerchantByID(int MerchantId);
        void InsertMerchant(Merchant Merchant);
        void DeleteMerchant(int MerchantId);
        void UpdateMerchant(int MerchantId,Merchant merchant);

       
    }
}
