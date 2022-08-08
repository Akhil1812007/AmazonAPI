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
    public class ProductController : ControllerBase
    {
        private readonly IProductProvider _provider;

        public ProductController(IProductProvider provider)
        {
            _provider = provider;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {

            return await _provider.GetAllProduct();
        }

        
       
        
        [HttpPost("authenticate")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            return await _provider.AddProduct(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int productId,Product product)
        {
            return await _provider.EditProduct(productId,product);

        }
        [HttpDelete("id")]
        public async Task DeleteProduct(int id)
        {
            await _provider.DeleteProduct(id);
        }





    }
}
