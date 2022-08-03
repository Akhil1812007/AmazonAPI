using Amazon.Models;
using Amazon.Repository;

namespace Amazon.Provider
{
    public class MerchantProvider :IMerchantProvider
    {
        private readonly IMerchantRepository _repository;
        public MerchantProvider(IMerchantRepository repository)
        {
            _repository = repository;
        }
        
        public void DeleteMerchant(int MerchantId)
        {
            _repository.DeleteMerchant(MerchantId); 
        }

        public IEnumerable<Merchant> GetMerchant()
        {
            
             return _repository.GetMerchant();
           
        }

        public Merchant GetMerchantByID(int MerchantId)
        {
           
             return _repository.GetMerchantByID(MerchantId);
        
        }

        public void InsertMerchant(Merchant Merchant)
        {
            _repository.InsertMerchant(Merchant);
        }



        public void UpdateMerchant(int MerchantId, Merchant Merchant)
        {
            _repository.UpdateMerchant(MerchantId, Merchant);
            
            
        }
    }
}
