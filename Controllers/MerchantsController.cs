using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Amazon.Models;
using Amazon.Provider;

namespace Amazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly IMerchantProvider _provider;

        public MerchantsController(IMerchantProvider provider)
        {
            _provider = provider;

        }

        // GET: api/Merchants
        [HttpGet]
        public  ActionResult<IEnumerable<Merchant>> GetMerchants()
        {
            return _provider.GetMerchant().ToList();
        }

        // GET: api/Merchants/5
        [HttpGet("{id}")]
        public ActionResult<Merchant> GetMerchant(int id)
        {
          return _provider.GetMerchantByID(id);
        }

        // PUT: api/Merchants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutMerchant(int id, Merchant merchant)
        {
           _provider.UpdateMerchant(id, merchant);
            return NoContent(); 
        }

        // POST: api/Merchants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostMerchant(Merchant merchant)
        {
            _provider.InsertMerchant(merchant);
            return NoContent();
          
        }

        // DELETE: api/Merchants/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMerchant(int id)
        {
            _provider?.DeleteMerchant(id);  

            return NoContent();
        }

        

    }
}
