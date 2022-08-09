using Amazon.Models;
using Amazon.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repository;
        public AdminController(IAdminRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("AddAdmin")]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
            return await _repository.AddAdmin(admin);
        }
        [HttpPost("AddCategory")]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            return await _repository.AddCategory(category);
        }
        [HttpPost("DeleteCategory")]
        public async Task DeleteCategory(int  CategoryId)
        {
             await _repository.DeleteCategory(CategoryId);
        }


    }
}
