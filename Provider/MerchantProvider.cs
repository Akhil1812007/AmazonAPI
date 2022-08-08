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
        
        public async Task DeleteMerchant(int MerchantId)
        {
            await _repository.DeleteMerchant(MerchantId); 
        }

        public async Task<List<Merchant>> GetMerchant()
        {
            
             return await _repository.GetMerchant();
           
        }

        public async Task<Merchant> GetMerchantByID(int MerchantId)
        {
           
             return await _repository.GetMerchantByID(MerchantId);
            

        
        }

        public async Task<Merchant>  InsertMerchant(Merchant Merchant)
        {
            await _repository.InsertMerchant(Merchant);
            return Merchant;
        }



        public async Task<Merchant> UpdateMerchant(int MerchantId, Merchant Merchant)
        {
            return await _repository.UpdateMerchant(MerchantId, Merchant);
            
            
        }
    }
}
