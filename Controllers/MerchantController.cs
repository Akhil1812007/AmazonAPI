using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Amazon.Models;
using Amazon.Repository;

namespace Amazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantRepository _repository;

        public MerchantController(IMerchantRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<ActionResult<List<Merchant>>> GetMerchants()
        {
            return await _repository.GetMerchant();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Merchant>> GetMerchant(int id)
        {
          return await _repository.GetMerchantByID(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Merchant>> PutMerchant(int id, Merchant merchant)
        {
            return await _repository.UpdateMerchant(id, merchant);
           
        }

        [HttpPost]
        public async Task<ActionResult<Merchant>> PostMerchant(Merchant merchant)
        {
            return await _repository.InsertMerchant(merchant);
             
          
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchant(int id)
        {
            await _repository?.DeleteMerchant(id);  

            return NoContent();
        }
        [HttpPost("MerchantLogin")]
        public async Task<ActionResult<Merchant>> MerchantLogin(Merchant m)
        {
            return await _repository.MerchantLogin(m);


        }
        



    }
}
