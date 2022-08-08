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
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantProvider _provider;

        public MerchantController(IMerchantProvider provider)
        {
            _provider = provider;

        }

        [HttpGet]
        public async Task<ActionResult<List<Merchant>>> GetMerchants()
        {
            return await _provider.GetMerchant();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Merchant>> GetMerchant(int id)
        {
          return await _provider.GetMerchantByID(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Merchant>> PutMerchant(int id, Merchant merchant)
        {
            return await _provider.UpdateMerchant(id, merchant);
           
        }

        [HttpPost]
        public async Task<ActionResult<Merchant>> PostMerchant(Merchant merchant)
        {
            return await _provider.InsertMerchant(merchant);
             
          
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchant(int id)
        {
            await _provider?.DeleteMerchant(id);  

            return NoContent();
        }

        

    }
}
