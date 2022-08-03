using Amazon.Models;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Repository
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly AmazonContext _context;
        public MerchantRepository(AmazonContext context)
        {
            _context = context;
        }

        public  async void DeleteMerchant(int MerchantId)
        {
            try
            {
                Merchant merchant = _context.Merchants.Find(MerchantId);
                _context.Merchants.Remove(merchant);
                _context.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Merchant> GetMerchant()
        {
            try
            {
                return _context.Merchants.ToList();
            }
            catch
            {
                throw new NotImplementedException();

            }
        }

        public Merchant GetMerchantByID(int MerchantId)
        {
            try
            {
                return _context.Merchants.Find(MerchantId);
            }
            catch
            {
                throw new NotImplementedException();

            }

        }

        public void InsertMerchant(Merchant Merchant)
        {
            _context.Merchants.Add(Merchant);
            _context.SaveChanges();
        }

        

        public void UpdateMerchant(int MerchantId, Merchant Merchant)
        {
            _context.Entry(Merchant).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
