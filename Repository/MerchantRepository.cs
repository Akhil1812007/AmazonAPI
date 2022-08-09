using Amazon.Models;
using Microsoft.EntityFrameworkCore;


namespace Amazon.Repository
{
    public  class MerchantRepository : IMerchantRepository
    {
        private readonly AmazonContext _context;
        public MerchantRepository(AmazonContext context)
        {
            _context = context;
        }

        public  async Task DeleteMerchant(int MerchantId)
        {
            try
            {
                Merchant merchant = _context.Merchants.Find(MerchantId);
                _context.Merchants.Remove(merchant);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<Merchant>> GetMerchant()
        {
            try
            {
                return await _context.Merchants.ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();

            }
        }

        public async Task<Merchant> GetMerchantByID(int MerchantId)
        {


            return await _context.Merchants.FindAsync(MerchantId);
            
            

        }

        public async Task<Merchant> InsertMerchant(Merchant merchant)
        {
            _context.Merchants.Add(merchant);
            await _context.SaveChangesAsync();
            return merchant;


        }

        public async  Task<Merchant> MerchantLogin(Merchant merchant)
        {
            var result = (from i in _context.Merchants
                          where i.MerchantEmail == merchant.MerchantEmail && i.MerchantPassword == merchant.MerchantPassword
                          select i).SingleOrDefaultAsync();
            if(result == null)
            {
                throw new Exception();
            }
            else
            {
                return await result;
            }
        }

        public async Task<Merchant> UpdateMerchant(int MerchantId, Merchant Merchant)
        {
            //Merchant _merchant = await _context.Merchants.FindAsync(MerchantId);
            _context.Update(Merchant);
            _context.SaveChanges();
            return Merchant;

        }
    }
}
