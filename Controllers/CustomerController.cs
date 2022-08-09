using Amazon.Models;
using Amazon.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetMerchant(int id)
        {
            return await _repository.GetCustomerById(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> PutMerchant(int id, Customer customer)
        {
            return await _repository.UpdateCustomer(id, customer);

        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostMerchant(Customer customer)
        {
            return await _repository.AddCustomer(customer);


        }


       
        [Route("CustomerLogin")]
        [HttpPost]
        public async Task<ActionResult<Customer>> CustomerLogin(Customer customer)
        {
            var ans = await _repository.CustomerLogin(customer);
            return Ok(ans);
        }

    }
}
