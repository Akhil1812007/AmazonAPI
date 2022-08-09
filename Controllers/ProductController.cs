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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {

            return await _repository.GetAllProduct();
        }

        
       
        
        [HttpPost("AddProduct")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            return await _repository.AddProduct(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int productId,Product product)
        {
            return await _repository.EditProduct(productId,product);

        }
        [HttpDelete("id")]
        public async Task DeleteProduct(int id)
        {
            await _repository.DeleteProduct(id);
        }





    }
}
